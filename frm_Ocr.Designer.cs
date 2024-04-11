namespace AutoOffice
{
    partial class frm_Ocr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Ocr));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbo_langs = new System.Windows.Forms.ComboBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picb = new System.Windows.Forms.PictureBox();
            this.txt_out = new System.Windows.Forms.RichTextBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.cbo_langs);
            this.splitContainer1.Panel1.Controls.Add(this.btn_run);
            this.splitContainer1.Panel1.Controls.Add(this.btn_open);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 729);
            this.splitContainer1.SplitterDistance = 65;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbo_langs
            // 
            this.cbo_langs.FormattingEnabled = true;
            this.cbo_langs.Location = new System.Drawing.Point(273, 36);
            this.cbo_langs.Name = "cbo_langs";
            this.cbo_langs.Size = new System.Drawing.Size(167, 20);
            this.cbo_langs.TabIndex = 3;
            // 
            // btn_run
            // 
            this.btn_run.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_run.Location = new System.Drawing.Point(508, 15);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(224, 41);
            this.btn_run.TabIndex = 2;
            this.btn_run.Text = "이미지에서 텍스트 읽기";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_open
            // 
            this.btn_open.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_open.Location = new System.Drawing.Point(12, 15);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(186, 41);
            this.btn_open.TabIndex = 1;
            this.btn_open.Text = "이미지파일선택";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txt_out);
            this.splitContainer2.Size = new System.Drawing.Size(1008, 660);
            this.splitContainer2.SplitterDistance = 504;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.picb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 660);
            this.panel1.TabIndex = 0;
            // 
            // picb
            // 
            this.picb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picb.Location = new System.Drawing.Point(0, 0);
            this.picb.Name = "picb";
            this.picb.Size = new System.Drawing.Size(500, 656);
            this.picb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picb.TabIndex = 1;
            this.picb.TabStop = false;
            // 
            // txt_out
            // 
            this.txt_out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_out.Location = new System.Drawing.Point(0, 0);
            this.txt_out.Name = "txt_out";
            this.txt_out.Size = new System.Drawing.Size(500, 660);
            this.txt_out.TabIndex = 0;
            this.txt_out.Text = "";
            this.txt_out.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(271, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "인식할 언어 선택";
            // 
            // frm_Ocr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Ocr";
            this.Text = "이미지에서 텍스트 추출";
            this.Load += new System.EventHandler(this.frm_Ocr_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox picb;
        private System.Windows.Forms.RichTextBox txt_out;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbo_langs;
        private System.Windows.Forms.Label label1;
    }
}