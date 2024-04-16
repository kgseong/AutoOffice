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
    public partial class frm_Rx : Form
    {
        private RxUtil oRx = new RxUtil();
        private ExcelUtil oExcel = new ExcelUtil();
        DataTable tbl_result;
        System.Windows.Forms.TabPage Tp_Result = new TabPage();
        System.Windows.Forms.DataGridView Gv_Result = new DataGridView();

        private string FormPath { get; set; }
        private string SavePath { get; set; }

        public frm_Rx()
        {
            InitializeComponent();
        }

        private void frm_Rx_Load(object sender, EventArgs e)
        {
            this.cbo_dg_schema_rx_div.DataSource = RxUtil.RxDivs;
            Tp_Result.Text = "결과보기";
            Tp_Result.Controls.Add(Gv_Result);
            Gv_Result.Dock = DockStyle.Fill;
            Gv_Result.AutoGenerateColumns = true;
        }



        void fillData()
        {
            var ds = oExcel.ExcelToDataSet();
            foreach (DataTable tbl in ds.Tables)
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
                this.cbo_sheet.Items.Add(tbl.TableName);
            }
            if (ds.Tables.Count > 0)
            {
                this.cbo_sheet.SelectedIndex = 0;
            }
        }

        private void btn_sel_xlDataFile_Click(object sender, EventArgs e)
        {
            this.ofd.Filter = Helper.Filter_Excel;
            var ok = this.ofd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                this.txt_xlDataFile.Text = this.ofd.FileName;
                oExcel.ExcelFile = this.txt_xlDataFile.Text;
                oExcel.ExcelToDataSet();
                fillData();
            }
        }

        private void cbo_sheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.oRx.SetData(this.oExcel.Ds.Tables[this.cbo_sheet.SelectedItem.ToString()].Copy());
            this.colBindingSource.DataSource = this.oRx.FldSchema;
            //this.dg_data.DataSource = this.oForm.Tbl;
        }

        private void btn_find_txt_Click(object sender, EventArgs e)
        {
            tbl_result = oRx.FindRx();
            this.Gv_Result.DataSource = tbl_result;
            if (this.tab_data.TabPages.Contains(Tp_Result) == false)
            {
                this.tab_data.TabPages.Add(Tp_Result);
                this.tab_data.SelectedTab = Tp_Result;
            };
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var ok = this.sfd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                oExcel.ExportDataTableToExcel(tbl_result, this.sfd.FileName);
            }
        }
    }
}
