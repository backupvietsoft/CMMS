namespace CustomerInfoReport
{
    partial class ListCustomerInfo
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
            this.ucReportInfo1 = new CustomerInfoReport.UCReportInfo();
            this.SuspendLayout();
            // 
            // ucReportInfo1
            // 
            this.ucReportInfo1.Location = new System.Drawing.Point(12, 12);
            this.ucReportInfo1.Name = "ucReportInfo1";
            this.ucReportInfo1.Size = new System.Drawing.Size(300, 210);
            this.ucReportInfo1.TabIndex = 0;
            // 
            // ListCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 262);
            this.Controls.Add(this.ucReportInfo1);
            this.Name = "ListCustomerInfo";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ListCustomerInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCReportInfo ucReportInfo1;
    }
}