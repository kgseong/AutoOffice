using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoOffice
{
   /// <summary>
   /// Doc Form Data
   /// </summary>
    public class FormData
    {
        public DataSet Ds { get; set; } = new DataSet();
        
        public DataTable Tbl { 
            get{
                if (Ds == null || Ds.Tables.Count==0)
                {
                    return null;
                }
                return Ds.Tables[0];
            } 
        }

        public List<Field> FldSchema { get; set; } = new List<Field>();
     
        public List<Field> RowToField(DataRow rowitem, bool is_index = true)
        {
            List<Field> vals = new List<Field>();
            foreach(DataColumn c in Tbl.Columns)
            {
                Field _col;
                if (is_index == true)
                {
                    int _idx = int.Parse(c.ColumnName);
                    _col = FldSchema.Find(x => x.FldIdx == _idx);
                }else
                {
                    _col = FldSchema.Find(x => x.ColumnName == c.ColumnName);
                }
                
                if (_col == null) continue;

                Field _val = new Field();
                _val.FldIdx = _col.FldIdx;
                _val.ColumnName = c.ColumnName;
                _val.FldName = _col.FldName;
                _val.isFileName = _col.isFileName;
                _val.Value = rowitem[c.ColumnName].ToString();

                vals.Add(_val);
            }
            return vals;
        }

        //
        /// <summary>
        /// return only valid value and filename suffix
        /// </summary>
        /// <param name="vals"></param>
        /// <returns>item1:field value, item2:filename suffix</returns>
        public Tuple<Dictionary<string, string>, string> GetFldValues(List<Field> vals)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string file_sufix = "";
            foreach (var item in vals)
            {
                values.Add(item.FldName, item.Value);

                if (item.isFileName == true)
                {
                    file_sufix += "_" + item.Value;
                }
            }
            return new Tuple<Dictionary<string, string>, string>(values, file_sufix);
            /*
            var items = from item in vals
                        where item.isFileName == true
                        select item.Value;
            return string.Join("_", items.ToArray());
            */
        }

        /// <summary>
        /// Check for duplicate file name suffix
        /// </summary>
        /// <returns>item1: ok , item2:err message</returns>
        public Tuple<bool, string> CheckKey()
        {
            if (this.Tbl == null) return new Tuple<bool, string>(true, "");
            Hashtable hash = new Hashtable();
            
            foreach (DataRow row in Tbl.Rows)
            {
                var items = RowToField(row, false);
                var vals = GetFldValues(items);
                if (hash.Contains(vals.Item2) == true)
                {
                    return new Tuple<bool, string>(false, "파일명이 중복될 수 있습니다. 파일명으로 사용할 필드를 다시 선택해 주세요");
                }
                hash.Add(vals.Item2, 0);
            }
            return new Tuple<bool, string>(true,"");
        }

        /// <summary>
        /// find fields for not duplicate file name suffix
        /// </summary>
        public void FindKey()
        {
            int tot_cnt = Tbl.Rows.Count;
            foreach(DataColumn col in Tbl.Columns)
            {
                var distinctNames = (from row in Tbl.AsEnumerable()
                                     select row.Field<string>(col.ColumnName)).Distinct();
                if (distinctNames.Count() == tot_cnt)
                {
                    foreach(var fld in FldSchema)
                    {
                        if (fld.ColumnName == col.ColumnName)
                        {
                            fld.isFileName = true;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Set data from datatable
        /// </summary>
        /// <param name="_dt"></param>
        public void SetData(DataTable _dt)
        {
            
            Ds = new DataSet();
            //Ds.AcceptChanges();
            Ds.Tables.Add(_dt.Copy());
            this.FldSchema.Clear();

            int cnt = 0;
            foreach (DataColumn col in Tbl.Columns)
            {
                cnt += 1;
                this.FldSchema.Add(new Field() { FldIdx = cnt, ColumnName = col.ColumnName, FldName = col.ColumnName, isFileName = cnt == 1 ? true:false }) ;
            }
            Ds.AcceptChanges();
        }

        /// <summary>
        /// set data from string (tab divided)
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="first_is_head">first line is head column</param>
        public void SetData(string txt, bool first_is_head = false)
        {
            MakeDataSet(txt, first_is_head);
            var lns = txt.Split('\n');
            int ln_no = 0;
            foreach (var ln in lns)
            {
                
                if (string.IsNullOrEmpty(ln.Trim()) == true) continue;

                if (first_is_head == true)
                {
                    if (ln_no == 0)
                    {
                        ln_no += 1;
                        continue;
                    }
                }
                var vals = ln.Trim().Split('\t');
                if (vals.Length == Tbl.Columns.Count)
                {
                    Tbl.Rows.Add(vals);
                }
                
                /*
                var new_row = Tbl.NewRow();
                for (int i = 0; i < vals.Length; i++)
                {
                    if (string.IsNullOrEmpty(vals[i].Trim())) continue;
                    var _col_name = (i + 1).ToString();
                    if (Tbl.Columns.Contains(_col_name) == true)
                    {
                        new_row[_col_name] = vals[i];
                    }
                }
                Tbl.Rows.Add(new_row);
                */
                ln_no += 1;
            }
            Ds.AcceptChanges();
        }
        /*
        public void MakeDataSet()
        {
            Ds = new DataSet();
            DataTable _dt = Ds.Tables.Add();
            foreach (var item in Schema)
            {

                var _col = _dt.Columns.Add();
                _col.ColumnName = item.FldIdx.ToString();
                _col.DataType = "".GetType();
            }
            Ds.AcceptChanges();
        }*/

        /// <summary>
        /// make dataset from head column line
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="first_is_head"></param>
        private void MakeDataSet(string txt, bool first_is_head = false)
        {

            var lns = txt.Split('\n');
            int col_cnt = 0;
            int ln_no = 0;
            List<string> cols = new List<string>();
            foreach (var ln in lns)
            {
                if (string.IsNullOrEmpty(ln.Trim()) == true) continue;
                var vals = ln.Trim().Split('\t');
                int _col_cnt = vals.Length;
                if (first_is_head == true && ln_no ==0)
                {
                    foreach(var val in vals)
                    {
                        cols.Add(val.Trim());
                    }
                }
                for (int _i = vals.Length - 1; _i >= 0; _i--)
                {
                    if (string.IsNullOrEmpty(vals[_i].Trim()) == false)
                    {
                        _col_cnt = _i + 1;
                        break;
                    }
                }
                if (col_cnt < _col_cnt)
                {
                    col_cnt = _col_cnt;
                }
                ln_no += 1;
            }


            Ds = new DataSet();
            this.FldSchema.Clear();
            var tbl = Ds.Tables.Add();
            if (first_is_head == true)
            {
                int _col_idx = 1;
                foreach(var col in cols)
                {
                    var col_item = tbl.Columns.Add();
                    col_item.ColumnName = col;
                    col_item.DataType = "".GetType();
                    FldSchema.Add(new Field() { FldIdx = _col_idx, ColumnName=col, FldName = col, isFileName = _col_idx == 1 ? true : false });
                    _col_idx += 1;
                }

            }else
            {
                for (int _col_idx = 1; _col_idx < col_cnt + 1; _col_idx++)
                {
                    string col = "fld_" + _col_idx.ToString();

                    var col_item = tbl.Columns.Add();
                    col_item.ColumnName = col;
                    col_item.DataType = "".GetType();

                    FldSchema.Add(new Field() { FldIdx = _col_idx, ColumnName = col, FldName = col, isFileName = _col_idx == 1 ? true : false });
                    //_col_idx += 1;
                }
            }

            Ds.AcceptChanges();
        }

    }
}
