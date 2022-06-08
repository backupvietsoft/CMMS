namespace ExportExcels
{
    partial class frmHinh
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
            this.imgHinh = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHinh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgHinh
            // 
            this.imgHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgHinh.Location = new System.Drawing.Point(0, 0);
            this.imgHinh.Name = "imgHinh";
            this.imgHinh.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.imgHinh.Size = new System.Drawing.Size(760, 530);
            this.imgHinh.TabIndex = 7;
            // 
            // frmHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 530);
            this.Controls.Add(this.imgHinh);
            this.Name = "frmHinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmHinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgHinh.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit imgHinh;
    }
}