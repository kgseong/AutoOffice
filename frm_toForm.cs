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
        private FormRepo Db = new FormRepo();
        private ExcelUtil excel = new ExcelUtil();

        private string FormPath { get; set; }
        private string SavePath { get; set; }

        TabPage[] tabs;
        string[] help = { "help_form1.htm", "help_form2.htm", "help_form3.htm", "help_form4.htm" };
        int top = -1;
        int count;
        
        public frm_toForm()
        {
            InitializeComponent();
        }

        private void frm_form_main_Load(object sender, EventArgs e)
        {
            this.ofd.Filter = DocFormHelper.Filter_Office;
            //tabs = new TabPage[] { this.tp_selform, this.tp_data, this.tp_map, this.tp_save };
            tabs = new TabPage[] { this.tp_selform, this.tp_xl_data, this.tp_map, this.tp_save };
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
            web.Url = new Uri(Path.Combine(appDir, help[top]));
        }
        private void Back()
        {
            top--;

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
            this.ofd.Filter = DocFormHelper.Filter_Office;
            var ok = this.ofd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                this.txt_form_path.Text = this.ofd.FileName;
                this.FormPath = this.ofd.FileName;
                OficeUtil.RunDoc(this.FormPath);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_data_Click(object sender, EventArgs e)
        {
            this.Db.MakeDataSet(this.txt_data_in.Text);
            this.Db.SetData(this.txt_data_in.Text);
            this.Db.FindKey();

            this.colBindingSource.DataSource = this.Db.schema;
            this.dg_data.DataSource = this.Db.dt;
        }

        private void tp_map_Leave(object sender, EventArgs e)
        {
            var msg = this.Db.CheckKey();
            if (string.IsNullOrEmpty(msg) == false)
            {
                MessageBox.Show(msg);
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
            foreach (DataRow row in this.Db.dt.Rows)
            {
                var items = this.Db.toVals(row, false);
                var file_sufix = "";
                foreach (var item in items)
                {
                    if (item.is_key == true)
                    {
                        file_sufix += "_" + item.value;
                    }
                }
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

            this.progress.Maximum = this.Db.dt.Rows.Count;
            this.lbl_step.Text = string.Format("0/{0}", this.Db.dt.Rows.Count);

            foreach (DataRow row in this.Db.dt.Rows)
            {
                var items = this.Db.toVals(row, false);
                var file_sufix = "";
                Dictionary<string, string> values = new Dictionary<string, string>();
                foreach (var item in items)
                {
                    values.Add(item.name, item.value);

                    if (item.is_key == true)
                    {
                        file_sufix += "_" + item.value;
                    }
                }
                string fname = System.IO.Path.GetFileNameWithoutExtension(this.FormPath) + file_sufix + System.IO.Path.GetExtension(this.FormPath);
                var fpath = System.IO.Path.Combine(this.SavePath, fname);

                var doc = DocFormHelper.GetDoc(this.FormPath, fpath);
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
            this.ofd.Filter = DocFormHelper.Filter_Excel;
            var ok = this.ofd.ShowDialog();
            if (ok == DialogResult.OK)
            {
                this.txt_xlDataFile.Text = this.ofd.FileName;
                excel.ExcelFile = this.txt_xlDataFile.Text;
                excel.OpenExcelToDataSet();
                fillData();
            }
        }

        void fillData()
        {
            var ds = excel.OpenExcelToDataSet();
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
            this.Db.SetData(this.excel.ds.Tables[this.cbo_sheet.SelectedItem.ToString()]);
            this.colBindingSource.DataSource = this.Db.schema;
            this.dg_data.DataSource = this.Db.dt;
        }
    }
}
