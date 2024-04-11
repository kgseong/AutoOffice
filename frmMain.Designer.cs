namespace AutoOffice
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_test01 = new System.Windows.Forms.Button();
            this.btn_PdfMerge = new System.Windows.Forms.Button();
            this.btn_toPdf = new System.Windows.Forms.Button();
            this.btn_toPrint = new System.Windows.Forms.Button();
            this.btn_Xl_Merge = new System.Windows.Forms.Button();
            this.btn_Form = new System.Windows.Forms.Button();
            this.txt_help = new System.Windows.Forms.RichTextBox();
            this.btn_Ocr = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Ocr);
            this.groupBox1.Controls.Add(this.btn_PdfMerge);
            this.groupBox1.Controls.Add(this.btn_toPdf);
            this.groupBox1.Controls.Add(this.btn_toPrint);
            this.groupBox1.Controls.Add(this.btn_Xl_Merge);
            this.groupBox1.Controls.Add(this.btn_Form);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(28, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 508);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MS Office 유틸리티";
            // 
            // btn_test01
            // 
            this.btn_test01.Location = new System.Drawing.Point(937, 7);
            this.btn_test01.Name = "btn_test01";
            this.btn_test01.Size = new System.Drawing.Size(115, 44);
            this.btn_test01.TabIndex = 6;
            this.btn_test01.Text = "테스트";
            this.btn_test01.UseVisualStyleBackColor = true;
            this.btn_test01.Click += new System.EventHandler(this.btn_test01_Click);
            // 
            // btn_PdfMerge
            // 
            this.btn_PdfMerge.BackColor = System.Drawing.Color.Khaki;
            this.btn_PdfMerge.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_PdfMerge.Location = new System.Drawing.Point(47, 334);
            this.btn_PdfMerge.Name = "btn_PdfMerge";
            this.btn_PdfMerge.Size = new System.Drawing.Size(336, 61);
            this.btn_PdfMerge.TabIndex = 4;
            this.btn_PdfMerge.Text = "PDF 합치기";
            this.btn_PdfMerge.UseVisualStyleBackColor = false;
            this.btn_PdfMerge.Click += new System.EventHandler(this.btn_PdfMerge_Click);
            // 
            // btn_toPdf
            // 
            this.btn_toPdf.BackColor = System.Drawing.Color.Khaki;
            this.btn_toPdf.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_toPdf.Location = new System.Drawing.Point(47, 267);
            this.btn_toPdf.Name = "btn_toPdf";
            this.btn_toPdf.Size = new System.Drawing.Size(336, 61);
            this.btn_toPdf.TabIndex = 3;
            this.btn_toPdf.Text = "오피스파일 PDF변환기";
            this.btn_toPdf.UseVisualStyleBackColor = false;
            this.btn_toPdf.Click += new System.EventHandler(this.btn_toPdf_Click);
            // 
            // btn_toPrint
            // 
            this.btn_toPrint.BackColor = System.Drawing.Color.Khaki;
            this.btn_toPrint.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_toPrint.Location = new System.Drawing.Point(47, 200);
            this.btn_toPrint.Name = "btn_toPrint";
            this.btn_toPrint.Size = new System.Drawing.Size(336, 61);
            this.btn_toPrint.TabIndex = 2;
            this.btn_toPrint.Text = "오피스파일 일괄출력기";
            this.btn_toPrint.UseVisualStyleBackColor = false;
            this.btn_toPrint.Click += new System.EventHandler(this.btn_toPrint_Click);
            // 
            // btn_Xl_Merge
            // 
            this.btn_Xl_Merge.BackColor = System.Drawing.Color.Khaki;
            this.btn_Xl_Merge.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Xl_Merge.Location = new System.Drawing.Point(47, 133);
            this.btn_Xl_Merge.Name = "btn_Xl_Merge";
            this.btn_Xl_Merge.Size = new System.Drawing.Size(336, 61);
            this.btn_Xl_Merge.TabIndex = 1;
            this.btn_Xl_Merge.Text = "엑셀시트 합치기";
            this.btn_Xl_Merge.UseVisualStyleBackColor = false;
            this.btn_Xl_Merge.Click += new System.EventHandler(this.btn_Xl_Merge_Click);
            // 
            // btn_Form
            // 
            this.btn_Form.BackColor = System.Drawing.Color.Khaki;
            this.btn_Form.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Form.Location = new System.Drawing.Point(47, 66);
            this.btn_Form.Name = "btn_Form";
            this.btn_Form.Size = new System.Drawing.Size(336, 61);
            this.btn_Form.TabIndex = 0;
            this.btn_Form.Text = "양식작성기";
            this.btn_Form.UseVisualStyleBackColor = false;
            this.btn_Form.Click += new System.EventHandler(this.btn_Form_Click);
            // 
            // txt_help
            // 
            this.txt_help.BackColor = System.Drawing.Color.Cornsilk;
            this.txt_help.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_help.Location = new System.Drawing.Point(475, 57);
            this.txt_help.Name = "txt_help";
            this.txt_help.Size = new System.Drawing.Size(589, 489);
            this.txt_help.TabIndex = 1;
            this.txt_help.Text = resources.GetString("txt_help.Text");
            // 
            // btn_Ocr
            // 
            this.btn_Ocr.BackColor = System.Drawing.Color.Khaki;
            this.btn_Ocr.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Ocr.Location = new System.Drawing.Point(47, 402);
            this.btn_Ocr.Name = "btn_Ocr";
            this.btn_Ocr.Size = new System.Drawing.Size(336, 61);
            this.btn_Ocr.TabIndex = 5;
            this.btn_Ocr.Text = "이미지에서 글자 추출";
            this.btn_Ocr.UseVisualStyleBackColor = false;
            this.btn_Ocr.Click += new System.EventHandler(this.btn_Ocr_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 593);
            this.Controls.Add(this.btn_test01);
            this.Controls.Add(this.txt_help);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "MS 오피스 유틸리티";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_toPdf;
        private System.Windows.Forms.Button btn_toPrint;
        private System.Windows.Forms.Button btn_Xl_Merge;
        private System.Windows.Forms.Button btn_Form;
        private System.Windows.Forms.RichTextBox txt_help;
        private System.Windows.Forms.Button btn_PdfMerge;
        private System.Windows.Forms.Button btn_test01;
        private System.Windows.Forms.Button btn_Ocr;
    }
}