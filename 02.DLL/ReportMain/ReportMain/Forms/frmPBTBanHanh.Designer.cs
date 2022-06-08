namespace ReportMain
{
    partial class frmPBTBanHanh
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
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            this.SuspendLayout();
            // 
            // prbIN
            // 
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(0, 0);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(517, 18);
            this.prbIN.TabIndex = 20;
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(167, 0);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(183, 18);
            this.grdChung.TabIndex = 21;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            this.grdChung.Visible = false;
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsCustomization.AllowGroup = false;
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // frmPBTBanHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 18);
            this.ControlBox = false;
            this.Controls.Add(this.grdChung);
            this.Controls.Add(this.prbIN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(517, 18);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(517, 18);
            this.Name = "frmPBTBanHanh";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPBTBanHanh";
            this.Shown += new System.EventHandler(this.frmPBTBanHanh_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
    }
}