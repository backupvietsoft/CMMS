namespace ReportMail
{
    partial class frmMailBTDKCThucHien
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
            this.ucMailBTDKCThucHien2 = new ReportMail.Mail.ucMailBTDKCThucHien();
            this.SuspendLayout();
            // 
            // ucMailBTDKCThucHien2
            // 
            this.ucMailBTDKCThucHien2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMailBTDKCThucHien2.Location = new System.Drawing.Point(0, 0);
            this.ucMailBTDKCThucHien2.LookAndFeel.SkinName = "Blue";
            this.ucMailBTDKCThucHien2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ucMailBTDKCThucHien2.Name = "ucMailBTDKCThucHien2";
            this.ucMailBTDKCThucHien2.Size = new System.Drawing.Size(664, 506);
            this.ucMailBTDKCThucHien2.TabIndex = 0;
            // 
            // frmMailBTDKCThucHien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 506);
            this.Controls.Add(this.ucMailBTDKCThucHien2);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmMailBTDKCThucHien";
            this.Text = "frmMailBTDKCThucHien";
            this.Load += new System.EventHandler(this.frmMailBTDKCThucHien_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ReportMail.Mail.ucMailBTDKCThucHien ucMailBTDKCThucHien2;
    }
}