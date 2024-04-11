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
    public partial class frm_PdfMerge : Form
    {
        public frm_PdfMerge()
        {
            InitializeComponent();
        }

        private void frm_PdfMerge_Load(object sender, EventArgs e)
        {

        }

        private void lst_file_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void lst_file_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var fs = DocFormHelper.GetValidDocList(files, new DocType[] { DocType.Pdf});
            DocFormHelper.ListViewItemAdd(this.lst_file, fs);
           
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            DocFormHelper.ListViewItemUpDown(this.lst_file, -1);
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            DocFormHelper.ListViewItemUpDown(this.lst_file, 1);
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lst_file.SelectedItems)
            {
                this.lst_file.Items.RemoveAt(item.Index);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var ok = this.sfd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                var fname = this.sfd.FileName;
                List<string> items = new List<string>();
                foreach(ListViewItem item in this.lst_file.Items)
                {
                    items.Add(item.SubItems[0].Text);
                }
                PdfUtil.MergePDFs(fname, items.ToArray());
                MessageBox.Show("완료되었습니다.-" + fname);
            }
            //
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var ok = this.ofd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                var fs = DocFormHelper.GetValidDocList(this.ofd.FileNames, new DocType[] { DocType.Pdf });
                DocFormHelper.ListViewItemAdd(this.lst_file, fs);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lst_file.SelectedItems)
            {
                this.lst_file.Items.RemoveAt(item.Index);
            }
        }
    }
}
