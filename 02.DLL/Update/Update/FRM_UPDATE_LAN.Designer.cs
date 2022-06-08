namespace Update
{
    partial class FRM_UPDATE_LAN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_UPDATE_LAN));
            this.bgWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtUrlUpdate = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDownload = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbPT = new System.Windows.Forms.Label();
            this.lbDetail = new System.Windows.Forms.ListBox();
            this.lbProgress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.btCancel = new System.Windows.Forms.Button();
            this.btDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bgWorker1
            // 
            this.bgWorker1.WorkerReportsProgress = true;
            this.bgWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker1_DoWork);
            this.bgWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker1_ProgressChanged);
            this.bgWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker1_RunWorkerCompleted);
            // 
            // txtUrlUpdate
            // 
            this.txtUrlUpdate.Location = new System.Drawing.Point(38, 165);
            this.txtUrlUpdate.Name = "txtUrlUpdate";
            this.txtUrlUpdate.Size = new System.Drawing.Size(277, 20);
            this.txtUrlUpdate.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnDownload.Location = new System.Drawing.Point(284, 228);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 27);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Update";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 75);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(468, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // lbPT
            // 
            this.lbPT.AutoSize = true;
            this.lbPT.BackColor = System.Drawing.Color.White;
            this.lbPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPT.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbPT.Location = new System.Drawing.Point(442, 52);
            this.lbPT.Name = "lbPT";
            this.lbPT.Size = new System.Drawing.Size(27, 13);
            this.lbPT.TabIndex = 3;
            this.lbPT.Text = "0 %";
            this.lbPT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDetail
            // 
            this.lbDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetail.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbDetail.FormattingEnabled = true;
            this.lbDetail.Location = new System.Drawing.Point(10, 103);
            this.lbDetail.Name = "lbDetail";
            this.lbDetail.Size = new System.Drawing.Size(468, 121);
            this.lbDetail.TabIndex = 5;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProgress.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbProgress.Location = new System.Drawing.Point(7, 53);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(147, 13);
            this.lbProgress.TabIndex = 6;
            this.lbProgress.Text = "Process download file ...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(48, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Update in Progress";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Update.Properties.Resources.Other_Update_Metro_icon;
            this.pictureBox1.Location = new System.Drawing.Point(10, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Image = global::Update.Properties.Resources.Untitled1;
            this.label3.Location = new System.Drawing.Point(10, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(468, 13);
            this.label3.TabIndex = 9;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(10, 75);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(468, 23);
            this.progressBar2.TabIndex = 10;
            this.progressBar2.Visible = false;
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btCancel.Location = new System.Drawing.Point(385, 228);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(94, 27);
            this.btCancel.TabIndex = 11;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btDetail
            // 
            this.btDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDetail.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btDetail.Location = new System.Drawing.Point(9, 228);
            this.btDetail.Name = "btDetail";
            this.btDetail.Size = new System.Drawing.Size(94, 27);
            this.btDetail.TabIndex = 12;
            this.btDetail.Text = "Detail";
            this.btDetail.UseVisualStyleBackColor = true;
            this.btDetail.Click += new System.EventHandler(this.btDetail_Click);
            // 
            // FRM_UPDATE_LAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 284);
            this.ControlBox = false;
            this.Controls.Add(this.btDetail);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.lbDetail);
            this.Controls.Add(this.lbPT);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtUrlUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_UPDATE_LAN";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update CMMS";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_UPDATE_FormClosed);
            this.Load += new System.EventHandler(this.FRM_UPDATE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgWorker1;
        private System.Windows.Forms.TextBox txtUrlUpdate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbPT;
        private System.Windows.Forms.ListBox lbDetail;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btDetail;
    }
}

