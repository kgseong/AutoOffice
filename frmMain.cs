using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoOffice
{
    public partial class frmMain : Form
    {
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void btn_Form_Click(object sender, EventArgs e)
        {
            (new frm_toForm()).Show();
        }

        private void btn_Xl_Merge_Click(object sender, EventArgs e)
        {
            //(new frm_Excel_Merge()).Show();
            (new frm_XlMerge()).Show();
        }

        private void btn_toPrint_Click(object sender, EventArgs e)
        {
            (new frm_toPrint()).Show();
        }

        private void btn_toPdf_Click(object sender, EventArgs e)
        {
            (new frm_toPdf()).Show();
        }

        private void btn_PdfMerge_Click(object sender, EventArgs e)
        {
            (new frm_PdfMerge()).Show();
        }

        private void btn_test01_Click(object sender, EventArgs e)
        {
            //var file = @"B:\Data\Temp\양식테스트\휴학원.docx";
            //OficeUtil.RunDoc(file);

            (new frm_Ocr()).Show();
        }

        private void btn_Ocr_Click(object sender, EventArgs e)
        {
            (new frm_Ocr()).Show();
        }
    }
}
