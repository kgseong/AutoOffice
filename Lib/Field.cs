using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOffice
{
    /// <summary>
    /// Doc Form Field
    /// </summary>
    public class Field
    {
        private static List<string> _RxDiv;
        public static string FldMark = "#";

        //데이터순번(1부터 시작)
        
        public int FldIdx { get; set; }
        //데이터의 컬럼명
        
        public string ColumnName { get; set; }
        //(한글:누름틀 이름, 엑셀:셀명칭-ex) A1
        
        public string FldName { get; set; }
        //저장시 해당 데이터가 파일명으로 사용됨
        public bool isFileName { get; set; } = false;

        public string Value { get; set; }
        public string FldMarkName
        {
            get
            {
                if (string.IsNullOrEmpty(FldName) == true)
                {
                    return null;
                }
                return FldMark + FldName + FldMark;
            }
        }

        public string SelectedRx { get; set; }

        public List<string> RxDiv
        {
            get
            {
                return RxUtil.RxDivs;
            }
        }
        public static string GetFieldName(string fldname)
        {
            return FldMark + fldname + FldMark;
        }
    }
}
