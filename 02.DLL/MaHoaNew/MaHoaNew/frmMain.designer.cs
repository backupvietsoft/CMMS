namespace MaHoaNew
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
            this.components = new System.ComponentModel.Container();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtClearText = new System.Windows.Forms.TextBox();
            this.txtCipherText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDecryptedText = new System.Windows.Forms.TextBox();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnLic = new System.Windows.Forms.Button();
            this.lblLicense = new System.Windows.Forms.Label();
            this.optDemo = new System.Windows.Forms.RadioButton();
            this.optStandard = new System.Windows.Forms.RadioButton();
            this.optPro = new System.Windows.Forms.RadioButton();
            this.lblHARDWARE = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtBegin = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(78, 263);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 0;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(190, 263);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 1;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtClearText
            // 
            this.txtClearText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClearText.Location = new System.Drawing.Point(94, 21);
            this.txtClearText.Name = "txtClearText";
            this.txtClearText.Size = new System.Drawing.Size(329, 20);
            this.txtClearText.TabIndex = 2;
            // 
            // txtCipherText
            // 
            this.txtCipherText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCipherText.Location = new System.Drawing.Point(94, 55);
            this.txtCipherText.Name = "txtCipherText";
            this.txtCipherText.Size = new System.Drawing.Size(329, 20);
            this.txtCipherText.TabIndex = 3;
            this.txtCipherText.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chuỗi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đã mã hóa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đã giải mã";
            // 
            // txtDecryptedText
            // 
            this.txtDecryptedText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecryptedText.Location = new System.Drawing.Point(94, 90);
            this.txtDecryptedText.Name = "txtDecryptedText";
            this.txtDecryptedText.ReadOnly = true;
            this.txtDecryptedText.Size = new System.Drawing.Size(329, 20);
            this.txtDecryptedText.TabIndex = 7;
            this.txtDecryptedText.TabStop = false;
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // btnLic
            // 
            this.btnLic.Location = new System.Drawing.Point(292, 263);
            this.btnLic.Name = "btnLic";
            this.btnLic.Size = new System.Drawing.Size(102, 23);
            this.btnLic.TabIndex = 1;
            this.btnLic.Text = "Create License";
            this.btnLic.UseVisualStyleBackColor = true;
            this.btnLic.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(6, 133);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(44, 13);
            this.lblLicense.TabIndex = 6;
            this.lblLicense.Text = "License";
            // 
            // optDemo
            // 
            this.optDemo.AutoSize = true;
            this.optDemo.Checked = true;
            this.optDemo.Location = new System.Drawing.Point(94, 131);
            this.optDemo.Name = "optDemo";
            this.optDemo.Size = new System.Drawing.Size(53, 17);
            this.optDemo.TabIndex = 8;
            this.optDemo.TabStop = true;
            this.optDemo.Text = "Demo";
            this.optDemo.UseVisualStyleBackColor = true;
            // 
            // optStandard
            // 
            this.optStandard.AutoSize = true;
            this.optStandard.Location = new System.Drawing.Point(230, 129);
            this.optStandard.Name = "optStandard";
            this.optStandard.Size = new System.Drawing.Size(68, 17);
            this.optStandard.TabIndex = 8;
            this.optStandard.TabStop = true;
            this.optStandard.Text = "Standard";
            this.optStandard.UseVisualStyleBackColor = true;
            // 
            // optPro
            // 
            this.optPro.AutoSize = true;
            this.optPro.Location = new System.Drawing.Point(382, 129);
            this.optPro.Name = "optPro";
            this.optPro.Size = new System.Drawing.Size(41, 17);
            this.optPro.TabIndex = 8;
            this.optPro.TabStop = true;
            this.optPro.Text = "Pro";
            this.optPro.UseVisualStyleBackColor = true;
            // 
            // lblHARDWARE
            // 
            this.lblHARDWARE.AutoSize = true;
            this.lblHARDWARE.Location = new System.Drawing.Point(6, 171);
            this.lblHARDWARE.Name = "lblHARDWARE";
            this.lblHARDWARE.Size = new System.Drawing.Size(53, 13);
            this.lblHARDWARE.TabIndex = 6;
            this.lblHARDWARE.Text = "Hardware";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(94, 164);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date";
            // 
            // txtEnd
            // 
            this.txtEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnd.Location = new System.Drawing.Point(265, 198);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(158, 20);
            this.txtEnd.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(346, 164);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(77, 20);
            this.textBox2.TabIndex = 2;
            // 
            // txtBegin
            // 
            this.txtBegin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBegin.Location = new System.Drawing.Point(94, 198);
            this.txtBegin.Name = "txtBegin";
            this.txtBegin.Size = new System.Drawing.Size(158, 20);
            this.txtBegin.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Location = new System.Drawing.Point(104, 223);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.Value = new System.DateTime(2017, 10, 12, 0, 0, 0, 0);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 298);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.optPro);
            this.Controls.Add(this.optStandard);
            this.Controls.Add(this.optDemo);
            this.Controls.Add(this.txtDecryptedText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHARDWARE);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCipherText);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtBegin);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtClearText);
            this.Controls.Add(this.btnLic);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Name = "frmMain";
            this.Text = "Main form";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtClearText;
        private System.Windows.Forms.TextBox txtCipherText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDecryptedText;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.Button btnLic;
        private System.Windows.Forms.RadioButton optPro;
        private System.Windows.Forms.RadioButton optStandard;
        private System.Windows.Forms.RadioButton optDemo;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHARDWARE;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtBegin;
    }
}

