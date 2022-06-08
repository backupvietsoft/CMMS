namespace Update
{
    partial class FRM_INTERNET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_INTERNET));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPhienBanCN = new System.Windows.Forms.Label();
            this.lbPhienbanHT = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.progressDownload = new System.Windows.Forms.ProgressBar();
            this.progressCopy = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser1.Location = new System.Drawing.Point(0, 155);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(398, 1);
            this.webBrowser1.TabIndex = 9;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox1.Image = global::Update.Properties.Resources.update;
            this.PictureBox1.Location = new System.Drawing.Point(2, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(118, 122);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 10;
            this.PictureBox1.TabStop = false;
            // 
            // lbPhienBanCN
            // 
            this.lbPhienBanCN.AutoSize = true;
            this.lbPhienBanCN.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbPhienBanCN.Location = new System.Drawing.Point(258, 31);
            this.lbPhienBanCN.Name = "lbPhienBanCN";
            this.lbPhienBanCN.Size = new System.Drawing.Size(44, 13);
            this.lbPhienBanCN.TabIndex = 19;
            this.lbPhienBanCN.Text = "Y.Y.Y.Y";
            this.lbPhienBanCN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPhienbanHT
            // 
            this.lbPhienbanHT.AutoSize = true;
            this.lbPhienbanHT.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbPhienbanHT.Location = new System.Drawing.Point(258, 6);
            this.lbPhienbanHT.Name = "lbPhienbanHT";
            this.lbPhienbanHT.Size = new System.Drawing.Size(44, 13);
            this.lbPhienbanHT.TabIndex = 18;
            this.lbPhienbanHT.Text = "X.X.X.X";
            this.lbPhienbanHT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label4.Location = new System.Drawing.Point(122, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Phiên bản cập nhật";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label5.Location = new System.Drawing.Point(122, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Phiên bản hiện tại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label1.Location = new System.Drawing.Point(122, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tải về dữ liệu cập nhật";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label2.Location = new System.Drawing.Point(122, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 14);
            this.label2.TabIndex = 22;
            this.label2.Text = "Xử lý cập nhật dữ liệu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(277, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "---------------------------------------------------------------------------------" +
    "---------";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdate.Location = new System.Drawing.Point(0, 132);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(398, 23);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "THỰC HIỆN CẬP NHẬT";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // progressDownload
            // 
            this.progressDownload.Location = new System.Drawing.Point(261, 73);
            this.progressDownload.Name = "progressDownload";
            this.progressDownload.Size = new System.Drawing.Size(131, 23);
            this.progressDownload.TabIndex = 25;
            // 
            // progressCopy
            // 
            this.progressCopy.Location = new System.Drawing.Point(261, 102);
            this.progressCopy.Name = "progressCopy";
            this.progressCopy.Size = new System.Drawing.Size(131, 23);
            this.progressCopy.TabIndex = 25;
            // 
            // FRM_INTERNET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(398, 156);
            this.Controls.Add(this.progressCopy);
            this.Controls.Add(this.progressDownload);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPhienBanCN);
            this.Controls.Add(this.lbPhienbanHT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(473, 245);
            this.MinimizeBox = false;
            this.Name = "FRM_INTERNET";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẬP NHẬT PHIÊN BẢN";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_INTERNET_FormClosed);
            this.Load += new System.EventHandler(this.FRM_INTERNET_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser webBrowser1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label lbPhienBanCN;
        internal System.Windows.Forms.Label lbPhienbanHT;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.ProgressBar progressDownload;
        internal System.Windows.Forms.ProgressBar progressCopy;
    }
}

