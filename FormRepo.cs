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
    
    internal class val: col
    {
        public string value { get; set; } = "";
    }
    internal class col
    {
        //데이터순번(1부터 시작)
        [DisplayName("데이터순번")]
        public int col_idx { get; set; }
        //데이터의 컬럼명
        [DisplayName("컬럼명")]
        public string column_name{ get; set; }
        //(한글:누름틀 이름, 엑셀:셀명칭-ex) A1
        [DisplayName("필드명")]
        public string name { get; set; }
        //저장시 해당 데이터가 파일명으로 사용됨
        [DisplayName("파일명사용")]
        public bool is_key { get; set; } = false;

        public string fldname
        {
            get
            {
                if(string.IsNullOrEmpty(name) == true)
                {
                    return null;
                }
                return "#" + name + "#";
            }
        }
    }
   
    internal class FormRepo
    {
        public DataSet ds { get; set; } = new DataSet();

        public DataTable dt { 
            get{
                if (ds == null || ds.Tables.Count==0)
                {
                    return null;
                }
                return ds.Tables[0];
            } 
        }

        public List<col> schema { get; set; } = new List<col>();

        public void MakeDataSet()
        {
            ds = new DataSet();
            DataTable _dt = ds.Tables.Add();
            foreach(var item in schema)
            {

                var _col = _dt.Columns.Add();
                _col.ColumnName = item.col_idx.ToString();
                _col.DataType = "".GetType();
            }
            ds.AcceptChanges();
        }
        public void MakeDataSet(string txt)
        {

            var lns = txt.Split('\n');
            int col_cnt = 0;
            foreach (var ln in lns)
            {
                var vals = ln.Split('\t');
                int _col_cnt = vals.Length;
                for(int _i=vals.Length-1; _i>=0; _i--) 
                {
                    if (string.IsNullOrEmpty(vals[_i].Trim())==false)
                    {
                        _col_cnt = _i + 1;
                        break;
                    }
                }
                if (col_cnt < _col_cnt)
                {
                    col_cnt = _col_cnt;
                }
            }

            for(int i=1;i<col_cnt +1; i++)
            {
                schema.Add(new col() { col_idx = i, name = "field" + i.ToString(), is_key = i == 1 ? true : false });
            }
            MakeDataSet();
        }
        public void SetData(string txt)
        {
            var lns = txt.Split('\n');
            foreach(var ln in lns)
            {
                var vals = ln.Split('\t');

                if (string.IsNullOrEmpty(ln.Trim()) == true) continue;

                var new_row = dt.NewRow();
                for (int i = 0; i < vals.Length; i++)
                {
                    if (string.IsNullOrEmpty(vals[i].Trim())) continue;
                    var _col_name = (i+1).ToString();
                    if (dt.Columns.Contains(_col_name) == true)
                    {
                        new_row[_col_name] = vals[i];
                    }
                }
                dt.Rows.Add(new_row);
            }
            ds.AcceptChanges();
        }

        public List<val> toVals(DataRow rowitem, bool is_index = true)
        {
            List<val> vals = new List<val>();
            foreach(DataColumn c in dt.Columns)
            {
                col _col;
                if (is_index == true)
                {
                    int _idx = int.Parse(c.ColumnName);
                    _col = schema.Find(x => x.col_idx == _idx);
                }else
                {
                    _col = schema.Find(x => x.column_name == c.ColumnName);
                }
                
                if (_col == null) continue;

                val _val = new val();
                _val.col_idx = _col.col_idx;
                _val.column_name = c.ColumnName;
                _val.name = _col.name;
                _val.is_key = _col.is_key;
                _val.value = rowitem[c.ColumnName].ToString();

                vals.Add(_val);
            }
            return vals;
        }

        public string CheckKey()
        {
            if (this.dt == null) return "";
            Hashtable hash = new Hashtable();
            
            foreach (DataRow row in dt.Rows)
            {
                var items = toVals(row, false);
                var file_sufix = "";
                Dictionary<string, string> values = new Dictionary<string, string>();
                foreach (var item in items)
                {
                    values.Add(item.name, item.value);

                    if (item.is_key == true)
                    {
                        file_sufix += "_" + item.value;
                    }
                }
                if (hash.Contains(file_sufix) == true)
                {
                    return "파일명이 중복될 수 있습니다. 파일명으로 사용할 필드를 다시 선택해 주세요";
                }
                hash.Add(file_sufix, 0);
            }
            return "";
        }
        public void FindKey()
        {
            int tot_cnt = dt.Rows.Count;
            foreach(DataColumn col in dt.Columns)
            {
                var distinctNames = (from row in dt.AsEnumerable()
                                     select row.Field<string>(col.ColumnName)).Distinct();
                if (distinctNames.Count() == tot_cnt)
                {
                    foreach(var _col in schema)
                    {
                        if (_col.col_idx.ToString() == col.ColumnName)
                        {
                            _col.is_key = true;
                            return;
                        }
                    }
                }
            }
        }

        public void SetData(DataTable _dt)
        {
            ds.Clear();
            ds.AcceptChanges();
            ds.Tables.Add(_dt.Copy());

            this.schema.Clear();
            int cnt = 0;
            foreach (DataColumn col in dt.Columns)
            {
                cnt += 1;
                this.schema.Add(new AutoOffice.col() { col_idx = cnt, column_name = col.ColumnName, name = col.ColumnName, is_key = cnt == 1 ? true:false }) ;
            }
            ds.AcceptChanges();
        }
    }
}
