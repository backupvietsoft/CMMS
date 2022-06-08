namespace Vietsoft.Reminder
{
    partial class frmReport
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
            this.CrystalReportViewer_maint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrystalReportViewer_maint
            // 
            this.CrystalReportViewer_maint.ActiveViewIndex = -1;
            this.CrystalReportViewer_maint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer_maint.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewer_maint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalReportViewer_maint.Location = new System.Drawing.Point(0, 0);
            this.CrystalReportViewer_maint.Name = "CrystalReportViewer_maint";
            this.CrystalReportViewer_maint.SelectionFormula = "";
            this.CrystalReportViewer_maint.Size = new System.Drawing.Size(797, 486);
            this.CrystalReportViewer_maint.TabIndex = 0;
            this.CrystalReportViewer_maint.ViewTimeSelectionFormula = "";
            this.CrystalReportViewer_maint.Load += new System.EventHandler(this.CrystalReportViewer_maint_Load);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 486);
            this.Controls.Add(this.CrystalReportViewer_maint);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReport_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer_maint;
    }
}