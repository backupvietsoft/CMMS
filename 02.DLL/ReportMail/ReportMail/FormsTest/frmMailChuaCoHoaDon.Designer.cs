namespace ReportMail.FormsTest
{
    partial class frmMailChuaCoHoaDon
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
            this.ucMailChuaCoHoaDon1 = new ReportMail.Mail.ucMailChuaCoHoaDon();
            this.SuspendLayout();
            // 
            // ucMailChuaCoHoaDon1
            // 
            this.ucMailChuaCoHoaDon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMailChuaCoHoaDon1.Location = new System.Drawing.Point(0, 0);
            this.ucMailChuaCoHoaDon1.Name = "ucMailChuaCoHoaDon1";
            this.ucMailChuaCoHoaDon1.Size = new System.Drawing.Size(743, 447);
            this.ucMailChuaCoHoaDon1.TabIndex = 0;
            // 
            // frmMailChuaCoHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 447);
            this.Controls.Add(this.ucMailChuaCoHoaDon1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmMailChuaCoHoaDon";
            this.Text = "frmMailChuaCoHoaDon";
            this.ResumeLayout(false);

        }

        #endregion

        private ReportMail.Mail.ucMailChuaCoHoaDon ucMailChuaCoHoaDon1;
    }
}