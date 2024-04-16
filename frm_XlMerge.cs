using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace AutoOffice
{
    public partial class frm_XlMerge : Form
    {

        ExcelUtil oExcel = new ExcelUtil();
        //object tree_drag_item;

        TabPage[] tabs;
        string[] help = { @"help_xlmerge.htm" };

        System.Windows.Forms.TabPage tp_merge = new TabPage();
        System.Windows.Forms.DataGridView gv_merge = new DataGridView();
        System.Data.DataTable dt_merge;

        public frm_XlMerge()
        {
            InitializeComponent();
        }

        private void btn_sel_file_Click(object sender, EventArgs e)
        {
            var ok = this.ofd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                this.txt_sel_path.Text = this.ofd.FileName;
                oExcel.ExcelFile = this.txt_sel_path.Text;
                fillData();
            }
        }


        void fillData()
        {
            var ds = oExcel.ExcelToDataSet();
            foreach (System.Data.DataTable tbl in ds.Tables)
            {
                System.Windows.Forms.TabPage tp = new TabPage();
                tp.Text = tbl.TableName;
                this.tab_data.TabPages.Add(tp);

                System.Windows.Forms.DataGridView gv = new DataGridView();
                tp.Controls.Add(gv);
                gv.Dock = DockStyle.Fill;
                gv.AutoGenerateColumns = true;
                gv.DataSource = tbl;

                //
                this.cbo_src.Items.Add(tbl.TableName);
                this.cbo_dst.Items.Add(tbl.TableName);
            }
            if (ds.Tables.Count > 0)
            {
                this.cbo_src.SelectedIndex = 0;
                this.cbo_dst.SelectedIndex = 0;
            }
            if (ds.Tables.Count > 1)
            {
                this.cbo_dst.SelectedIndex = 1;
            }

        }
        void fillSchema(string tablename, ListView view)
        {
            System.Data.DataTable tbl = oExcel.Ds.Tables[tablename];
            view.Items.Clear();
            foreach (DataColumn col in tbl.Columns)
            {
                view.Items.Add(col.ColumnName);
            }
        }
        void fillMap()
        {
            if (lst_src.CheckedItems.Count == 0 || lst_dst.CheckedItems.Count == 0) return;
            if (lst_src.CheckedItems.Count != lst_dst.CheckedItems.Count) return;
            string map = "";
            for (int i = 0; i < lst_src.CheckedItems.Count; i++)
            {
                map += lst_src.CheckedItems[i].SubItems[0].Text + "=" + lst_dst.CheckedItems[i].SubItems[0].Text + "\n";
            }
            this.txt_map.Text = map.TrimEnd(); ;
        }
        void DoMerge()
        {
            List<Tuple<string, string>> map = new List<Tuple<string, string>>();
            var lns = this.txt_map.Text.Split('\n');
            foreach (var ln in lns)
            {
                var vals = ln.Split('=');
                if (vals.Length != 2) continue;
                map.Add(new Tuple<string, string>(vals[0].Trim(), vals[1].Trim()));
            }
            string tbl_src = this.cbo_src.SelectedItem.ToString();
            string tbl_dst = this.cbo_dst.SelectedItem.ToString();
            dt_merge = oExcel.JoinTable(oExcel.Ds.Tables[tbl_src], oExcel.Ds.Tables[tbl_dst], map);


            tp_merge.Text = dt_merge.TableName;
            gv_merge.DataSource = dt_merge;

            if (this.tab_data.TabPages.Contains(tp_merge) == false)
            {
                this.tab_data.TabPages.Add(tp_merge);
                this.tab_data.SelectedTab = tp_merge;
            }
        }

        private void cbo_src_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSchema(cbo_src.SelectedItem.ToString(), lst_src);
        }

        private void cbo_dst_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSchema(cbo_dst.SelectedItem.ToString(), lst_dst);
        }

        private void lst_src_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            fillMap();
        }

        private void lst_dst_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            fillMap();
        }

        private void btn_merge_Click(object sender, EventArgs e)
        {
            DoMerge();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var ok = this.sfd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                oExcel.ExportDataTableToExcel(dt_merge, this.sfd.FileName);
            }
        }

        private void frm_XlMerge_Load(object sender, EventArgs e)
        {
            tp_merge.Controls.Add(gv_merge);
            gv_merge.Dock = DockStyle.Fill;
            gv_merge.AutoGenerateColumns = true;

            string appDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            web.Url = new Uri(Path.Combine(new string[] { appDir, "help", help[0] }));
        }
    }
}
