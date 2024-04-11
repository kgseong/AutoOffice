using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOffice
{
    public class Field
    {
        private static List<string> _RxDiv;
        public static string FldMark = "#";

        //데이터순번(1부터 시작)
        [DisplayName("데이터순번")]
        public int FldIdx { get; set; }
        //데이터의 컬럼명
        [DisplayName("컬럼명")]
        public string ColumnName { get; set; }
        //(한글:누름틀 이름, 엑셀:셀명칭-ex) A1
        [DisplayName("필드명")]
        public string FldName { get; set; }
        //저장시 해당 데이터가 파일명으로 사용됨
        [DisplayName("파일명사용")]
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
    }
}
