using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;

namespace AutoOffice
{
    public class RxUtil : FormUtil
    {
        public static Dictionary<string, Regex> _RxDic;

        public static Dictionary<string, Regex> RxDic
        {
            get
            {
                if (_RxDic == null)
                {
                    _RxDic = new Dictionary<string, Regex>();
                    RxDic.Add("None", null);
                    RxDic.Add("이메일", new Regex(@"[a-z0-9_+.-]+@([a-z0-9-]+\.)+[a-z0-9]{2,4}"));
                    RxDic.Add("Url", new Regex(@"(file|gopher|news|nntp|telnet|https?|ftps?|sftp)://([a-z0-9-]+\.)+[a-z0-9]{2,4}."));
                    RxDic.Add("태그", new Regex(@"<(/?[^\>]+)\>"));
                    RxDic.Add("전화번호", new Regex(@"(\d{3}).*(\d{3}).*(\d{4})"));
                    RxDic.Add("날짜", new Regex(@"(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])"));
                    RxDic.Add("주민번호", new Regex(@"(?:[0-9]{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[1,2][0-9]|3[0,1]))-[1-4][0-9]{6}"));
                    RxDic.Add("한글", new Regex(@"[가-힣\s]+"));
                    RxDic.Add("신용카드번호", new Regex(@"[0-9]{4}[-\s\.]?[0-9]{4}[-\s\.]?[0-9]{4}[-\s\.]?[0-9]{4}"));
                    RxDic.Add("링크주소", new Regex(@"<a href=[""'].*?[""'].*?>.*?</a>"));
                    RxDic.Add("이미지원본", new Regex(@"<img[^>]+src=[""']?([^>""']+)[""']?[^>]*>"));
                    RxDic.Add("우편번호", new Regex(@"\d{3}-?\d{3}"));
                    RxDic.Add("숫자만", new Regex(@"[0-9]*"));
                    RxDic.Add("괄호안()", new Regex(@"\([^\[\]]+\)"));
                    RxDic.Add("중괄호안{}", new Regex(@"\{[^\[\]]+\}"));
                    RxDic.Add("대괄호안[]", new Regex(@"\[[^\[\]]+\]"));
                }
                return _RxDic;

            }
        }

        public static string FindStr(string txt, string rxKey)
        {
            if (rxKey == null) return txt;  //검색하지 않으면 원문 그래도
            if (RxDic.ContainsKey(rxKey) == true)
            {
                Regex rx = RxDic[rxKey];
                if (rx == null)
                {
                    return "";
                }
                var matches = rx.Matches(txt);
                string result = "";
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        result += match.Value + " ";
                    }
                    return result.Substring(0, result.Length - 1);
                }
            }
            return txt;
        }

        public static List<string> RxDivs
        {
            get
            {
                return RxUtil.RxDic.Keys.ToList();
            }
        }

        public DataTable FindRx()
        {
            DataTable tbl = Tbl.Clone();
            tbl.TableName = "결과";
            foreach (DataRow dr in Tbl.Rows)
            {
                DataRow new_dr = tbl.NewRow();
                foreach (DataColumn col in tbl.Columns)
                {
                    var fld = Schema.Find(x => x.ColumnName == col.ColumnName);
                    //if (fld != null && string.IsNullOrEmpty(fld.SelectedRx) == false)
                    if (fld != null)
                    {
                        new_dr[col.ColumnName] = FindStr(dr[col.ColumnName].ToString(), fld.SelectedRx);
                    }
                    else
                    {
                        new_dr[col.ColumnName] = dr[col.ColumnName];
                    }    
                }
                tbl.Rows.Add(new_dr);
            }
            tbl.AcceptChanges();
            return tbl;
        }


    }
}
