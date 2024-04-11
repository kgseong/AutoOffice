namespace AutoOffice
{
    partial class frm_Rx
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_xlDataFile = new System.Windows.Forms.TextBox();
            this.btn_sel_xlDataFile = new System.Windows.Forms.Button();
            this.cbo_sheet = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dg_schema = new System.Windows.Forms.DataGridView();
            this.tab_data = new System.Windows.Forms.TabControl();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.btn_find_txt = new System.Windows.Forms.Button();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbo_dg_schema_rx_div = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_schema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_find_txt);
            this.splitContainer1.Panel1.Controls.Add(this.txt_xlDataFile);
            this.splitContainer1.Panel1.Controls.Add(this.btn_sel_xlDataFile);
            this.splitContainer1.Panel1.Controls.Add(this.cbo_sheet);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(900, 545);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 0;
            // 
            // txt_xlDataFile
            // 
            this.txt_xlDataFile.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_xlDataFile.Location = new System.Drawing.Point(222, 21);
            this.txt_xlDataFile.Name = "txt_xlDataFile";
            this.txt_xlDataFile.ReadOnly = true;
            this.txt_xlDataFile.Size = new System.Drawing.Size(492, 26);
            this.txt_xlDataFile.TabIndex = 7;
            // 
            // btn_sel_xlDataFile
            // 
            this.btn_sel_xlDataFile.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_sel_xlDataFile.Location = new System.Drawing.Point(34, 21);
            this.btn_sel_xlDataFile.Name = "btn_sel_xlDataFile";
            this.btn_sel_xlDataFile.Size = new System.Drawing.Size(169, 26);
            this.btn_sel_xlDataFile.TabIndex = 6;
            this.btn_sel_xlDataFile.Text = "데이터파일 선택";
            this.btn_sel_xlDataFile.UseVisualStyleBackColor = true;
            this.btn_sel_xlDataFile.Click += new System.EventHandler(this.btn_sel_xlDataFile_Click);
            // 
            // cbo_sheet
            // 
            this.cbo_sheet.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo_sheet.FormattingEnabled = true;
            this.cbo_sheet.Location = new System.Drawing.Point(222, 58);
            this.cbo_sheet.Name = "cbo_sheet";
            this.cbo_sheet.Size = new System.Drawing.Size(237, 24);
            this.cbo_sheet.TabIndex = 5;
            this.cbo_sheet.SelectedIndexChanged += new System.EventHandler(this.cbo_sheet_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(74, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "데이터 시트 선택";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dg_schema);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tab_data);
            this.splitContainer2.Size = new System.Drawing.Size(900, 403);
            this.splitContainer2.SplitterDistance = 328;
            this.splitContainer2.TabIndex = 0;
            // 
            // dg_schema
            // 
            this.dg_schema.AutoGenerateColumns = false;
            this.dg_schema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_schema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.cbo_dg_schema_rx_div});
            this.dg_schema.DataSource = this.colBindingSource;
            this.dg_schema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_schema.Location = new System.Drawing.Point(0, 0);
            this.dg_schema.Name = "dg_schema";
            this.dg_schema.RowTemplate.Height = 23;
            this.dg_schema.Size = new System.Drawing.Size(328, 403);
            this.dg_schema.TabIndex = 2;
            // 
            // tab_data
            // 
            this.tab_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_data.Location = new System.Drawing.Point(0, 0);
            this.tab_data.Name = "tab_data";
            this.tab_data.SelectedIndex = 0;
            this.tab_data.Size = new System.Drawing.Size(568, 403);
            this.tab_data.TabIndex = 2;
            // 
            // ofd
            // 
            this.ofd.Filter = "Excel Files(.xls)|*.xls;*.xlsx";
            // 
            // sfd
            // 
            this.sfd.Filter = "Excel 통합 문서|*.xlsx";
            // 
            // btn_find_txt
            // 
            this.btn_find_txt.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_find_txt.Location = new System.Drawing.Point(505, 59);
            this.btn_find_txt.Name = "btn_find_txt";
            this.btn_find_txt.Size = new System.Drawing.Size(209, 34);
            this.btn_find_txt.TabIndex = 8;
            this.btn_find_txt.Text = "패턴 찾기 실행";
            this.btn_find_txt.UseVisualStyleBackColor = true;
            this.btn_find_txt.Click += new System.EventHandler(this.btn_find_txt_Click);
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "ColumnName";
            this.ColumnName.HeaderText = "컬럼";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // cbo_dg_schema_rx_div
            // 
            this.cbo_dg_schema_rx_div.DataPropertyName = "SelectedRx";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbo_dg_schema_rx_div.DefaultCellStyle = dataGridViewCellStyle1;
            this.cbo_dg_schema_rx_div.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cbo_dg_schema_rx_div.HeaderText = "찾기패턴";
            this.cbo_dg_schema_rx_div.Name = "cbo_dg_schema_rx_div";
            this.cbo_dg_schema_rx_div.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbo_dg_schema_rx_div.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cbo_dg_schema_rx_div.ToolTipText = "데이터찾기";
            this.cbo_dg_schema_rx_div.Width = 150;
            // 
            // colBindingSource
            // 
            this.colBindingSource.DataSource = typeof(AutoOffice.Field);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(44, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "데이터 찾기 패턴 설정";
            // 
            // frm_Rx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 545);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frm_Rx";
            this.Text = "패턴으로 데이터 찾기";
            this.Load += new System.EventHandler(this.frm_Rx_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_schema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.TextBox txt_xlDataFile;
        private System.Windows.Forms.Button btn_sel_xlDataFile;
        private System.Windows.Forms.ComboBox cbo_sheet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tab_data;
        private System.Windows.Forms.BindingSource colBindingSource;
        private System.Windows.Forms.DataGridView dg_schema;
        private System.Windows.Forms.Button btn_find_txt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbo_dg_schema_rx_div;
        private System.Windows.Forms.Label label1;
    }
}