using DocumentFormat.OpenXml.Drawing;
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
    public partial class frm_toPdf : Form
    {
        public frm_toPdf()
        {
            InitializeComponent();
        }
        private void lst_file_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void lst_file_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var fs = Helper.GetValidDocList(files, new DocType[] { DocType.Word, DocType.Xls, DocType.Ppt });
            Helper.ListViewItemAdd(this.lst_file, fs);
            /*
            foreach (string file in files)
            {
                if (DocFormHelper.GetDocType(file) == DocType.Word || DocFormHelper.GetDocType(file) == DocType.Xls || DocFormHelper.GetDocType(file) == DocType.Ppt)
                {
                    var item = lst_file.Items.Add(file);
                    item.Checked = true;
                }
            }*/
        }

        private void frmPdf_Load(object sender, EventArgs e)
        {
            lst_file.AllowDrop = true;
            lst_file.DragDrop += lst_file_DragDrop;
            lst_file.DragEnter += lst_file_DragEnter;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            this.progress.Maximum = lst_file.Items.Count;
            this.lbl_status.Text = string.Format("{0}/{1}", 0, this.progress.Maximum);
            using (OficeUtil office = new OficeUtil())
            {
                //이벤트 등록
                office.DoneEvent += OnDoneEvent;

                foreach (ListViewItem item in lst_file.Items)
                {
                    Application.DoEvents();
                    if (item.Checked)
                    {
                        //pdf변환
                        string pdf_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(item.Text), System.IO.Path.GetFileNameWithoutExtension(item.Text) + ".pdf");
                        string ext = System.IO.Path.GetExtension(item.Text).ToLower();
                        var ok = office.ToPDF(item.Text, pdf_path);
                    }
                }
            }
        }

        private void OnDoneEvent(object sender, DoneArgs e)
        {
            this.progress.PerformStep();
            this.lbl_status.Text = string.Format("{0}/{1}", this.progress.Value, this.progress.Maximum);
            var item = FindItem(e.FileName);
            if (e.isOK == true)
            {
                if (item != null)
                {
                    item.BackColor = Color.Green;
                }
            }else
            {
                if (item != null)
                {
                    item.BackColor = Color.Orange;
                    item.ToolTipText = e.Message;
                }
            }
        }
        private ListViewItem FindItem(string txt)
        {
            for(int i = 0; i< this.lst_file.Items.Count; i++)
            {
                if (this.lst_file.Items[i].Text == txt)
                {
                    return this.lst_file.Items[i];
                }
            }
            return null;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lst_file.SelectedItems)
            {
                this.lst_file.Items.RemoveAt(item.Index);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var ok = this.ofd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                var fs = Helper.GetValidDocList(this.ofd.FileNames, new DocType[] { DocType.Word, DocType.Xls, DocType.Ppt });
                Helper.ListViewItemAdd(this.lst_file, fs);
            }
        }
    }
}
