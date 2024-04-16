using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoOffice
{
    public partial class frm_toForm : Form
    {
        private FormData oForm = new FormData();
        private ExcelUtil oExcel = new ExcelUtil();

        private string FormPath { get; set; }
        private string SavePath { get; set; }

        TabPage[] tabs;
        string[] help = { @"help_toform_1.htm", @"help_toform_2-1.htm", @"help_toform_2-2.htm", @"help_toform_3.htm", @"help_toform_4.htm" };
        int top = -1;
        int count;
        
        public frm_toForm()
        {
            InitializeComponent();
        }

        private void frm_form_main_Load(object sender, EventArgs e)
        {
            this.ofd.Filter = Helper.Filter_Office;
            //tabs = new TabPage[] { this.tp_selform, this.tp_data, this.tp_map, this.tp_save };
            tabs = new TabPage[] { this.tp_selform, this.tp_xl_data, this.tp_data,  this.tp_map, this.tp_save };
            count = tabs.Length;
            Next();
        }
        private void LoadTab()
        {
            for (int i=0; i < tabs.Length; i++){
                if (i == top)
                {
                    if (this.tab_main.TabPages.Contains(tabs[i]) ==false)
                    {
                        this.tab_main.TabPages.Add(tabs[i]);
                    }
                }
                else
                {
                    if (this.tab_main.TabPages.Contains(tabs[i]) == true)
                    {
                        this.tab_main.TabPages.Remove(tabs[i]);
                    }
                }
            }
            //tabs[top].Show();
            tab_main.SelectTab(tabs[top]);

            string appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            web.Url = new Uri(Path.Combine(new string[] { appDir, "help", help[top] }));
           
            
        }
        private void Back()
        {
            
            top--;
            //데이터입력시 선택 엑셀입력폼으로
            switch(top)
            {
                case 1:
                    top--;
                    break;
                case 2:
                    if (this.chk_data_from_excel.Checked == true) top--;
                    break;
            }
            /*
            if (top == 2 || top == 1)
            {
                if (this.chk_data_from_excel.Checked == true) top--;
            }*/

            if (top <= -1)
            {
                return;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                LoadTab();
                if (top - 1 <= -1)
                {
                    btnBack.Enabled = false;
                }
            }

            if (top >= count)
            {
                btnNext.Enabled = false;
            }
        }
        private void Next()
        {
            top++;
            //데이터입력시 선택 엑셀입력폼으로
            switch (top)
            {
                case 1:
                    if (this.chk_data_from_excel.Checked == false) top++;
                    break;
                case 2:
                    top++;
                    break;
            }
            

            if (top >= count)
            {
                return;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                LoadTab();
                if (top + 1 == count)
                {
                    btnNext.Enabled = false;
                }
            }

            if (top <= 0)
            {
                btnBack.Enabled = false;
            }
        }

        private void btn_selform_Click(object sender, EventArgs e)
        {
            this.ofd.Filter = Helper.Filter_All;
            var ok = this.ofd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                this.txt_form_path.Text = this.ofd.FileName;
                this.FormPath = this.ofd.FileName;
                //OficeUtil.RunDoc(this.FormPath);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_data_Click(object sender, EventArgs e)
        {
            
            this.oForm.SetData(this.txt_data_in.Text,  this.chk_is_first_head.Checked);
            this.oForm.FindKey();

            this.colBindingSource.DataSource = this.oForm.FldSchema;
            this.dg_data.DataSource = this.oForm.Tbl;
        }

        private void tp_map_Leave(object sender, EventArgs e)
        {
            var ok = this.oForm.CheckKey();
            if (ok.Item1 == false)
            {
                MessageBox.Show(ok.Item2);
                return;
            }
        }

        private void progress_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_dir_Click(object sender, EventArgs e)
        {
            var ok = this.fbd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                this.txt_save_path.Text = this.fbd.SelectedPath;
                this.SavePath = this.fbd.SelectedPath;
            }
        }

        private string CheckFileDup()
        {
            foreach (DataRow row in this.oForm.Tbl.Rows)
            {
                var items = this.oForm.RowToField(row, false);

                
                var vals = this.oForm.GetFldValues(items);
                var file_sufix = vals.Item2;
                Dictionary<string, string> values = vals.Item1;
                /*
                var file_sufix = "";
                foreach (var item in items)
                {
                    if (item.isFileName == true)
                    {
                        file_sufix += "_" + item.Value;
                    }
                } */
                string fname = System.IO.Path.GetFileNameWithoutExtension(this.FormPath) + file_sufix + System.IO.Path.GetExtension(this.FormPath);
                var fpath = System.IO.Path.Combine(this.SavePath, fname);

                if (System.IO.File.Exists(fpath))
                {
                    return "이미 파일이 있습니다. : " + fpath + "\n먼저 해당파일을 삭제 후 다시 시작하세요 ";
                }
            }
            return null;
        }

        private void OnDoneEvent(object sender, DoneArgs e)
        {
            this.progress.PerformStep();
            this.lbl_step.Text = string.Format("{0}/{1}", this.progress.Value, this.progress.Maximum);

        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SavePath) == true)
            {
                MessageBox.Show("저장할 디렉토리를 선택해 주세요");
                this.btn_save_dir.Focus();
                return;
            }
            string msg = CheckFileDup();
            if (string.IsNullOrEmpty(msg) == false)
            {
                MessageBox.Show(msg);
                return;
            }

            this.progress.Maximum = this.oForm.Tbl.Rows.Count;
            this.lbl_step.Text = string.Format("0/{0}", this.oForm.Tbl.Rows.Count);

            foreach (DataRow row in this.oForm.Tbl.Rows)
            {
                var items = this.oForm.RowToField(row, false);
                var vals = this.oForm.GetFldValues(items);
                var file_sufix = vals.Item2;
                Dictionary<string, string> values = vals.Item1;
                /*
                //Dictionary<string, string> values = new Dictionary<string, string>();
                foreach (var item in items)
                {
                    values.Add(item.FldName, item.Value);

                    if (item.isFileName == true)
                    {
                        file_sufix += "_" + item.Value;
                    }
                }
                */
                string fname = System.IO.Path.GetFileNameWithoutExtension(this.FormPath) + file_sufix + System.IO.Path.GetExtension(this.FormPath);
                var fpath = System.IO.Path.Combine(this.SavePath, fname);

                //var doc = Helper.GetDoc(this.FormPath, fpath);
                var doc = DocFormBase.GetDoc(this.FormPath, fpath);
                doc.DoneEvent += OnDoneEvent;
                doc.FillData(values);


                Application.DoEvents();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
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
                this.oForm.FindKey();
            }
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

        private void cbo_sheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.oForm.SetData(this.oExcel.Ds.Tables[this.cbo_sheet.SelectedItem.ToString()].Copy());
            this.oForm.FindKey();
            this.colBindingSource.DataSource = this.oForm.FldSchema;
            this.dg_data.DataSource = this.oForm.Tbl;
        }

        private void btn_openForm_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.FormPath) == true)
            {
                Helper.OpenDoc(this.FormPath);
            }
        }
    }
}
