using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoOffice
{
    internal static class Program
    {
        //public static FormRepo Db { get; set; } 
        //public static string FormPath { get; set; }
        //public static string SavePath { get; set; }
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Db = new FormRepo();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
            //Application.Run(new frmTop());
            //Application.Run(new frmExcelSql());
            //Application.Run(new frm_form_main());
            Application.Run(new frmMain());
        }
    }
}
