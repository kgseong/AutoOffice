using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Tesseract;

namespace AutoOffice
{
    public partial class frm_Ocr : Form
    {
        OcrUtil oOcr;
        public frm_Ocr()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            var ok = this.ofd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                oOcr.ImagePath = this.ofd.FileName;
                this.picb.Image = Image.FromFile(oOcr.ImagePath);
            }
        }

     

        private void frm_Ocr_Load(object sender, EventArgs e)
        {
            foreach(var item in OcrUtil.Langs)
            {
                this.cbo_langs.Items.Add(item);
            }
            if (OcrUtil.Langs.Length > 0)
            {
                this.cbo_langs.SelectedIndex = 0;
            }
            oOcr = new OcrUtil();
            oOcr.DoneEvent += OnDoneEvent;

        }

        private void OnDoneEvent(object sender, DoneArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(this.cbo_langs.Text) == true)
            {
                MessageBox.Show("언어를 선택하세요");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            this.txt_out.Text = oOcr.ReadText(this.cbo_langs.Text);
        }
    }
}
