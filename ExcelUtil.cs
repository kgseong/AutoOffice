using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Data.OleDb;
using System.Data;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Drawing;
//using Microsoft.Office.Interop.Excel;


namespace AutoOffice
{
    public  class ExcelUtil
    {
        public DataSet ds { get; set; }
        public string ExcelFile { get; set; }
        public DataSet OpenExcelToDataSet()
        {
            //DataSet ds = null;
            using (SpreadsheetDocument oSpreadSheetDoc = SpreadsheetDocument.Open(ExcelFile, false))
            {
                WorkbookPart oWorkbookPart = oSpreadSheetDoc.WorkbookPart;

                OpenXmlElementList lstOpenXmlElements = oSpreadSheetDoc.WorkbookPart.Workbook.ChildElements;
                foreach (Sheets vSheets in lstOpenXmlElements.OfType<Sheets>())
                {
                    ds = new DataSet();

                    foreach (Sheet vSheet in vSheets)
                    {
                        DataTable dt = new DataTable(vSheet.Name);
                        //dt.Name = vSheet.Name;
                        String vRelationId = vSheet.Id.Value;
                        WorksheetPart oWorksheetPart = (WorksheetPart)oWorkbookPart.GetPartById(vRelationId);
                        Worksheet oWorksheet = oWorksheetPart.Worksheet;

                        OpenXmlElementList lstOpenXmlChildElements = oWorksheet.ChildElements;
                        foreach (SheetData vSheetData in lstOpenXmlChildElements.OfType<SheetData>())
                        {
                            IEnumerable<Row> enumRows = vSheetData.Descendants<Row>();
                            if (enumRows.Count() == 0)
                                continue;

                            var vFirstRow = enumRows.First();

                            // Make Columns with first row...
                            IEnumerable<Cell> enumFirstRowCells = vFirstRow.Descendants<Cell>();
                            for (int i = 0; i < enumFirstRowCells.Count(); ++i)
                            {
                                Cell vCell = enumFirstRowCells.ElementAt(i);
                                String sCellValue = vCell.CellValue?.InnerXml;
                                if ((vCell.DataType != null)
                                    && (vCell.DataType.Value == CellValues.SharedString))
                                {
                                    sCellValue = oWorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements[Int32.Parse(sCellValue)].InnerText;
                                }
                                dt.Columns.Add(sCellValue);
                            }

                            foreach (Row vRow in enumRows)
                            {
                                DataRow dtRow = dt.NewRow();

                                IEnumerable<Cell> enumCells = vRow.Descendants<Cell>();
                                for (int i = 0; i < enumCells.Count(); ++i)
                                {
                                    Cell vCell = enumCells.ElementAt(i);
                                    String sCellValue = vCell.CellValue?.InnerXml;
                                    if ((vCell.DataType != null)
                                        && (vCell.DataType.Value == CellValues.SharedString))
                                    {
                                        sCellValue = oWorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements[Int32.Parse(sCellValue)].InnerText;
                                    }
                                    if (sCellValue != null) dtRow[i] = sCellValue;
                                }
                                dt.Rows.Add(dtRow);
                            }
                            dt.Rows.RemoveAt(0);
                            ds.Tables.Add(dt);
                        }
                    }
                }
            }
            return ds;
        }

        public DataTable SQL(string tableName, string Where )
        {
            var items = ds.Tables[tableName].Select(Where);
            DataTable dt = ds.Tables[tableName].Clone();
            dt.TableName = "sql_" + tableName;
            foreach(var item in items)
            {
                dt.Rows.Add(item.ItemArray);
            }
            dt.AcceptChanges();
            return dt;
        }
        public DataTable JoinTable(DataTable tbl1, DataTable tbl2, List<Tuple<string, string>> match_cols )
        {
           
            DataTable dt = new DataTable(tbl1.TableName + "_" + tbl2.TableName);
            foreach(DataColumn col in tbl1.Columns)
            {
                var _col = dt.Columns.Add(tbl1.TableName + "_" + col.ColumnName);
                _col.DataType = col.DataType;
            }
            foreach (DataColumn col in tbl2.Columns)
            {
                var _col = dt.Columns.Add(tbl2.TableName + "_" +  col.ColumnName);
                _col.DataType = col.DataType;
            }
            foreach(DataRow s_r in tbl1.Rows)
            {
                var s_vals = s_r.ItemArray;

                string where = "";
                foreach (var match_col in match_cols)
                {
                    where += "and " + match_col.Item2 + "='" + s_r[ match_col.Item1] + "' \n";
                }
                var _find_drs = tbl2.Select(where.Substring(4));

                if (_find_drs.Length > 0)
                {
                    foreach (DataRow d_r in _find_drs)
                    {
                        var d_vals = d_r.ItemArray;

                        object[] vals = new object[s_vals.Length + d_vals.Length];
                        s_vals.CopyTo(vals, 0);
                        d_vals.CopyTo(vals, s_vals.Length);
                        dt.Rows.Add(vals);
                    }
                }
                else
                {
                    dt.Rows.Add(s_r.ItemArray);
                }
            }
            dt.AcceptChanges();
            return dt;
        }

        public void ExportDSToExcel(DataTable dt, string save_path)
        {
            var _ds = ds.Copy();
            _ds.Tables.Add(dt);
            using (var workbook = SpreadsheetDocument.Create(save_path, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                uint sheetId = 1;

                foreach (DataTable table in _ds.Tables)
                {
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }

                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                    List<String> columns = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                        headerRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(headerRow);

                    foreach (DataRow dsrow in table.Rows)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        foreach (String col in columns)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString()); //
                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }
                }
            }
        }

    }
}
