using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace AutoOffice
{
    internal class XlsForm: IDocForm
    {

        public event EventHandler<DoneArgs> DoneEvent;
        public string FormFilePath { get; set; }
        public string SaveAsPath { get; set; }
        public XlsForm(string formFilePth, string saveAsPath)
        {
            FormFilePath = formFilePth;
            SaveAsPath = saveAsPath;
        }
        public bool FillData(Dictionary<string, string> values)
        {
            System.IO.File.Copy(FormFilePath, SaveAsPath);
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(SaveAsPath, true)) { 
                WorkbookPart workbookPart = doc.WorkbookPart;
                
                if (workbookPart != null)
                {
                    workbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                    workbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;

                    SharedStringTablePart sharedStringTablePart = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();


                    if (sharedStringTablePart != null)
                    {
                        
                        foreach (WorksheetPart worksheetPart in workbookPart.WorksheetParts)
                        {
                            
                            GetCells(worksheetPart).ForEach(cell => ProcessCell(values, cell, sharedStringTablePart));
                        }
                    }
                }
                doc.Save();
                doc.Close();

                OnDoneEvent(new DoneArgs(FormFilePath, true, SaveAsPath));
            }
            return true;
        }
        private static List<Cell> GetCells(WorksheetPart worksheetPart)
        {
            return worksheetPart.Worksheet.Elements<SheetData>().SelectMany(i => i.Elements<Row>())
                .SelectMany(i => i.Elements<Cell>()).ToList();
        }

        private static void ProcessCell(Dictionary<string, string> replacements, Cell cell, SharedStringTablePart sharedStringTablePart)
        {
            
            bool isValidCell = cell.DataType != null && cell.DataType.Value == CellValues.SharedString && cell.CellValue != null;

            if (isValidCell)
            {
                int sharedStringIndex = int.Parse(cell.CellValue.InnerText);
                SharedStringItem sharedStringItem = sharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(sharedStringIndex);

                string text = sharedStringItem.Text.Text;
                foreach (var replacement in replacements.Where(replacement => !string.IsNullOrEmpty(text) && text.Contains(DocFormHelper.GetFieldName( replacement.Key ))))
                {
                    cell.CellValue = new CellValue(replacement.Value);
                    cell.DataType = new EnumValue<CellValues>(CellValues.String);
                }
            }
        }

        protected virtual void OnDoneEvent(DoneArgs e)
        {
            EventHandler<DoneArgs> raiseEvent = DoneEvent;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }
    }
}
