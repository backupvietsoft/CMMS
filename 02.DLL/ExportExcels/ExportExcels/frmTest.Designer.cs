namespace ExportExcels
{
    partial class frmTest
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
            this.ucIncident1 = new ExportExcels.ucIncident();
            this.SuspendLayout();
            // 
            // ucIncident1
            // 
            this.ucIncident1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIncident1.Location = new System.Drawing.Point(0, 0);
            this.ucIncident1.LookAndFeel.SkinName = "Blue";
            this.ucIncident1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ucIncident1.Name = "ucIncident1";
            this.ucIncident1.Size = new System.Drawing.Size(792, 525);
            this.ucIncident1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 525);
            this.Controls.Add(this.ucIncident1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private ucIncident ucIncident1;






    }
}