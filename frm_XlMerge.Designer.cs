namespace AutoOffice
{
    partial class frm_XlMerge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_XlMerge));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.web = new System.Windows.Forms.WebBrowser();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txt_help = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_merge = new System.Windows.Forms.Button();
            this.txt_map = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_dst = new System.Windows.Forms.ListView();
            this.col_dst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lst_src = new System.Windows.Forms.ListView();
            this.col_src = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbo_src = new System.Windows.Forms.ComboBox();
            this.cbo_dst = new System.Windows.Forms.ComboBox();
            this.txt_sel_path = new System.Windows.Forms.TextBox();
            this.btn_sel_file = new System.Windows.Forms.Button();
            this.tab_data = new System.Windows.Forms.TabControl();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.web);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1053, 709);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // web
            // 
            this.web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web.Location = new System.Drawing.Point(0, 0);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(266, 709);
            this.web.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txt_help);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.btn_save);
            this.splitContainer2.Panel1.Controls.Add(this.btn_merge);
            this.splitContainer2.Panel1.Controls.Add(this.txt_map);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.lst_dst);
            this.splitContainer2.Panel1.Controls.Add(this.lst_src);
            this.splitContainer2.Panel1.Controls.Add(this.cbo_src);
            this.splitContainer2.Panel1.Controls.Add(this.cbo_dst);
            this.splitContainer2.Panel1.Controls.Add(this.txt_sel_path);
            this.splitContainer2.Panel1.Controls.Add(this.btn_sel_file);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tab_data);
            this.splitContainer2.Size = new System.Drawing.Size(783, 709);
            this.splitContainer2.SplitterDistance = 378;
            this.splitContainer2.TabIndex = 0;
            // 
            // txt_help
            // 
            this.txt_help.Location = new System.Drawing.Point(491, 226);
            this.txt_help.Name = "txt_help";
            this.txt_help.ReadOnly = true;
            this.txt_help.Size = new System.Drawing.Size(232, 127);
            this.txt_help.TabIndex = 20;
            this.txt_help.Text = "기준시트와 대상시트의 열을 맵핑합니다\n\"기준시트열명=대상시트열명\" 형식이며 \n여러 열을 일치시킬 수 있습니다.\n예)\n  학번=학번\n  이름=이름";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(488, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "시트간 열 맵핑 정보";
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_save.Location = new System.Drawing.Point(509, 48);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(214, 30);
            this.btn_save.TabIndex = 18;
            this.btn_save.Text = "결과저장하기";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_merge
            // 
            this.btn_merge.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_merge.Location = new System.Drawing.Point(509, 12);
            this.btn_merge.Name = "btn_merge";
            this.btn_merge.Size = new System.Drawing.Size(214, 30);
            this.btn_merge.TabIndex = 13;
            this.btn_merge.Text = "시트합치기실행";
            this.btn_merge.UseVisualStyleBackColor = true;
            this.btn_merge.Click += new System.EventHandler(this.btn_merge_Click);
            // 
            // txt_map
            // 
            this.txt_map.Location = new System.Drawing.Point(491, 110);
            this.txt_map.Name = "txt_map";
            this.txt_map.Size = new System.Drawing.Size(232, 110);
            this.txt_map.TabIndex = 17;
            this.txt_map.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(259, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "대상 엑셀 시트";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(35, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "기준 액셀 시트";
            // 
            // lst_dst
            // 
            this.lst_dst.CheckBoxes = true;
            this.lst_dst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_dst});
            this.lst_dst.FullRowSelect = true;
            this.lst_dst.HideSelection = false;
            this.lst_dst.Location = new System.Drawing.Point(262, 112);
            this.lst_dst.Name = "lst_dst";
            this.lst_dst.Size = new System.Drawing.Size(209, 243);
            this.lst_dst.TabIndex = 14;
            this.lst_dst.UseCompatibleStateImageBehavior = false;
            this.lst_dst.View = System.Windows.Forms.View.Details;
            this.lst_dst.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lst_dst_ItemChecked);
            // 
            // col_dst
            // 
            this.col_dst.Text = "일치시킬대상열";
            this.col_dst.Width = 200;
            // 
            // lst_src
            // 
            this.lst_src.CheckBoxes = true;
            this.lst_src.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_src});
            this.lst_src.FullRowSelect = true;
            this.lst_src.HideSelection = false;
            this.lst_src.Location = new System.Drawing.Point(37, 112);
            this.lst_src.Name = "lst_src";
            this.lst_src.Size = new System.Drawing.Size(209, 243);
            this.lst_src.TabIndex = 12;
            this.lst_src.UseCompatibleStateImageBehavior = false;
            this.lst_src.View = System.Windows.Forms.View.Details;
            this.lst_src.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lst_src_ItemChecked);
            // 
            // col_src
            // 
            this.col_src.Text = "기준 열";
            this.col_src.Width = 200;
            // 
            // cbo_src
            // 
            this.cbo_src.FormattingEnabled = true;
            this.cbo_src.Location = new System.Drawing.Point(37, 86);
            this.cbo_src.Name = "cbo_src";
            this.cbo_src.Size = new System.Drawing.Size(209, 20);
            this.cbo_src.TabIndex = 11;
            this.cbo_src.SelectedIndexChanged += new System.EventHandler(this.cbo_src_SelectedIndexChanged);
            // 
            // cbo_dst
            // 
            this.cbo_dst.FormattingEnabled = true;
            this.cbo_dst.Location = new System.Drawing.Point(262, 86);
            this.cbo_dst.Name = "cbo_dst";
            this.cbo_dst.Size = new System.Drawing.Size(209, 20);
            this.cbo_dst.TabIndex = 10;
            this.cbo_dst.SelectedIndexChanged += new System.EventHandler(this.cbo_dst_SelectedIndexChanged);
            // 
            // txt_sel_path
            // 
            this.txt_sel_path.Location = new System.Drawing.Point(182, 25);
            this.txt_sel_path.Name = "txt_sel_path";
            this.txt_sel_path.ReadOnly = true;
            this.txt_sel_path.Size = new System.Drawing.Size(310, 21);
            this.txt_sel_path.TabIndex = 4;
            // 
            // btn_sel_file
            // 
            this.btn_sel_file.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_sel_file.Location = new System.Drawing.Point(30, 12);
            this.btn_sel_file.Name = "btn_sel_file";
            this.btn_sel_file.Size = new System.Drawing.Size(136, 34);
            this.btn_sel_file.TabIndex = 3;
            this.btn_sel_file.Text = "엑셀파일 선택";
            this.btn_sel_file.UseVisualStyleBackColor = true;
            this.btn_sel_file.Click += new System.EventHandler(this.btn_sel_file_Click);
            // 
            // tab_data
            // 
            this.tab_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_data.Location = new System.Drawing.Point(0, 0);
            this.tab_data.Name = "tab_data";
            this.tab_data.SelectedIndex = 0;
            this.tab_data.Size = new System.Drawing.Size(783, 327);
            this.tab_data.TabIndex = 1;
            // 
            // ofd
            // 
            this.ofd.Filter = "Excel Files(.xls)|*.xls;*.xlsx";
            // 
            // sfd
            // 
            this.sfd.Filter = "Excel 통합 문서|*.xlsx";
            // 
            // frm_XlMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 709);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_XlMerge";
            this.Text = "엑셀 시트 합치기";
            this.Load += new System.EventHandler(this.frm_XlMerge_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.TextBox txt_sel_path;
        private System.Windows.Forms.Button btn_sel_file;
        private System.Windows.Forms.TabControl tab_data;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_merge;
        private System.Windows.Forms.RichTextBox txt_map;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lst_dst;
        private System.Windows.Forms.ColumnHeader col_dst;
        private System.Windows.Forms.ListView lst_src;
        private System.Windows.Forms.ColumnHeader col_src;
        private System.Windows.Forms.ComboBox cbo_src;
        private System.Windows.Forms.ComboBox cbo_dst;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.RichTextBox txt_help;
    }
}