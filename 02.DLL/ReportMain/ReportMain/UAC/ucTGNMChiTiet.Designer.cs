namespace ReportMain
{
    partial class ucTGNMChiTiet
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdTGNMCT = new DevExpress.XtraGrid.GridControl();
            this.grvTGNMCT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdTGNMCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTGNMCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTGNMCT
            // 
            this.grdTGNMCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTGNMCT.Location = new System.Drawing.Point(0, 0);
            this.grdTGNMCT.LookAndFeel.SkinName = "Blue";
            this.grdTGNMCT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdTGNMCT.MainView = this.grvTGNMCT;
            this.grdTGNMCT.Name = "grdTGNMCT";
            this.grdTGNMCT.Size = new System.Drawing.Size(1042, 576);
            this.grdTGNMCT.TabIndex = 8;
            this.grdTGNMCT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTGNMCT,
            this.gridView2});
            // 
            // grvTGNMCT
            // 
            this.grvTGNMCT.GridControl = this.grdTGNMCT;
            this.grvTGNMCT.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.grvTGNMCT.Name = "grvTGNMCT";
            this.grvTGNMCT.OptionsView.ShowGroupPanel = false;
            this.grvTGNMCT.PreviewFieldName = "Description";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdTGNMCT;
            this.gridView2.Name = "gridView2";
            // 
            // ucTGNMChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdTGNMCT);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucTGNMChiTiet";
            this.Size = new System.Drawing.Size(1042, 576);
            this.Load += new System.EventHandler(this.ucTGNMChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTGNMCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTGNMCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdTGNMCT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTGNMCT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}
