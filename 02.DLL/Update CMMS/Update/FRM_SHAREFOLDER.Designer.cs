namespace Update
{
    partial class FRM_SHAREFOLDER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SHAREFOLDER));
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPhienBanCN = new System.Windows.Forms.Label();
            this.lbPhienbanHT = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChon = new System.Windows.Forms.Button();
            this.ProgressBarControl2 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox1
            // 
            this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox1.Image = global::Update.Properties.Resources.update;
            this.PictureBox1.Location = new System.Drawing.Point(4, 6);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(115, 103);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            // 
            // lbPhienBanCN
            // 
            this.lbPhienBanCN.AutoSize = true;
            this.lbPhienBanCN.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbPhienBanCN.Location = new System.Drawing.Point(255, 38);
            this.lbPhienBanCN.Name = "lbPhienBanCN";
            this.lbPhienBanCN.Size = new System.Drawing.Size(51, 14);
            this.lbPhienBanCN.TabIndex = 15;
            this.lbPhienBanCN.Text = "1.0.0.1";
            // 
            // lbPhienbanHT
            // 
            this.lbPhienbanHT.AutoSize = true;
            this.lbPhienbanHT.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbPhienbanHT.Location = new System.Drawing.Point(255, 9);
            this.lbPhienbanHT.Name = "lbPhienbanHT";
            this.lbPhienbanHT.Size = new System.Drawing.Size(51, 14);
            this.lbPhienbanHT.TabIndex = 14;
            this.lbPhienbanHT.Text = "1.0.0.1";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Label2.Location = new System.Drawing.Point(125, 38);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(113, 14);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Phiên bản cập nhật";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Label1.Location = new System.Drawing.Point(125, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(105, 14);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Phiên bản hiện tại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "---------------------------------------------------------------------------------" +
    "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label4.Location = new System.Drawing.Point(125, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "Xử lý cập nhật dữ liệu";
            // 
            // btnChon
            // 
            this.btnChon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnChon.Location = new System.Drawing.Point(0, 120);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(384, 23);
            this.btnChon.TabIndex = 26;
            this.btnChon.Text = "THỰC HIỆN CẬP NHẬT";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // ProgressBarControl2
            // 
            this.ProgressBarControl2.Location = new System.Drawing.Point(258, 86);
            this.ProgressBarControl2.Name = "ProgressBarControl2";
            this.ProgressBarControl2.Size = new System.Drawing.Size(114, 23);
            this.ProgressBarControl2.TabIndex = 27;
            // 
            // FRM_SHAREFOLDER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 143);
            this.Controls.Add(this.ProgressBarControl2);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbPhienBanCN);
            this.Controls.Add(this.lbPhienbanHT);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_SHAREFOLDER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẬP NHẬT PHIÊN BẢN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_SHAREFOLDER_FormClosed);
            this.Load += new System.EventHandler(this.FRM_SHAREFOLDER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label lbPhienBanCN;
        internal System.Windows.Forms.Label lbPhienbanHT;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChon;
        internal System.Windows.Forms.ProgressBar ProgressBarControl2;
    }
}