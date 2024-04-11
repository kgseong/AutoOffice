namespace AutoOffice
{
    partial class frm_toPdf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_toPdf));
            this.btn_run = new System.Windows.Forms.Button();
            this.lst_file = new System.Windows.Forms.ListView();
            this.col_file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_help = new System.Windows.Forms.RichTextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_run
            // 
            this.btn_run.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_run.Location = new System.Drawing.Point(12, 7);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(167, 53);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "PDF로 변환하기";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // lst_file
            // 
            this.lst_file.CheckBoxes = true;
            this.lst_file.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_file});
            this.lst_file.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_file.FullRowSelect = true;
            this.lst_file.HideSelection = false;
            this.lst_file.Location = new System.Drawing.Point(0, 0);
            this.lst_file.Name = "lst_file";
            this.lst_file.ShowItemToolTips = true;
            this.lst_file.Size = new System.Drawing.Size(800, 347);
            this.lst_file.TabIndex = 0;
            this.lst_file.UseCompatibleStateImageBehavior = false;
            this.lst_file.View = System.Windows.Forms.View.Details;
            // 
            // col_file
            // 
            this.col_file.Text = "파일";
            this.col_file.Width = 600;
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
            this.splitContainer1.Panel1.Controls.Add(this.btn_del);
            this.splitContainer1.Panel1.Controls.Add(this.btn_add);
            this.splitContainer1.Panel1.Controls.Add(this.txt_help);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_status);
            this.splitContainer1.Panel1.Controls.Add(this.progress);
            this.splitContainer1.Panel1.Controls.Add(this.btn_run);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lst_file);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 99;
            this.splitContainer1.TabIndex = 1;
            // 
            // btn_del
            // 
            this.btn_del.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_del.ForeColor = System.Drawing.Color.Red;
            this.btn_del.Location = new System.Drawing.Point(105, 66);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(74, 30);
            this.btn_del.TabIndex = 9;
            this.btn_del.Text = "파일제거";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_add.ForeColor = System.Drawing.Color.Blue;
            this.btn_add.Location = new System.Drawing.Point(12, 66);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 30);
            this.btn_add.TabIndex = 8;
            this.btn_add.Text = "파일추가";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_help
            // 
            this.txt_help.BackColor = System.Drawing.Color.Khaki;
            this.txt_help.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_help.Location = new System.Drawing.Point(185, 7);
            this.txt_help.Name = "txt_help";
            this.txt_help.Size = new System.Drawing.Size(540, 53);
            this.txt_help.TabIndex = 7;
            this.txt_help.Text = "워드, 엑셀, 파워포인트 파일을 PDF파일로 변환합니다.\n파일탐색기에서 변환할 파일을 아래 박스에 드래그앤 드롭하세요";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(745, 70);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(23, 12);
            this.lbl_status.TabIndex = 6;
            this.lbl_status.Text = "0/0";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(185, 80);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(540, 16);
            this.progress.Step = 1;
            this.progress.TabIndex = 5;
            // 
            // ofd
            // 
            this.ofd.Filter = "MS Office Files|*.xls;*.xlsx;*.doc;*.docx;*.ppt;*.pptx";
            // 
            // frm_toPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_toPdf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "오피스파일 PDF변환";
            this.Load += new System.EventHandler(this.frmPdf_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.ListView lst_file;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.ColumnHeader col_file;
        private System.Windows.Forms.RichTextBox txt_help;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.OpenFileDialog ofd;
    }
}