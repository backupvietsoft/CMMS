namespace ReportHuda.General
{
    partial class frmViewFullImage
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
            this.img1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.img1)).BeginInit();
            this.SuspendLayout();
            // 
            // img1
            // 
            this.img1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.img1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.img1.Location = new System.Drawing.Point(0, 0);
            this.img1.Name = "img1";
            this.img1.Size = new System.Drawing.Size(284, 262);
            this.img1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img1.TabIndex = 0;
            this.img1.TabStop = false;
            // 
            // frmViewFullImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.img1);
            this.Name = "frmViewFullImage";
            this.Text = "frmViewFullImage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.img1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox img1;

    }
}