namespace ImportExcels
{
    partial class frmBCTonKhoSum
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
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.grdSum = new DevExpress.XtraGrid.GridControl();
            this.grvSum = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.grdCost = new DevExpress.XtraGrid.GridControl();
            this.grvCost = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSum)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCost)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Image = global::ImportExcels.Properties.Resources.btnexcel;
            this.btnExport.Location = new System.Drawing.Point(633, 492);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(104, 30);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "&Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.xtraTabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(850, 525);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 4);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(844, 32);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xtraTabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.xtraTabControl1, 4);
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 35);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(844, 451);
            this.xtraTabControl1.TabIndex = 6;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.grdSum);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(837, 423);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // grdSum
            // 
            this.grdSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSum.Location = new System.Drawing.Point(0, 0);
            this.grdSum.LookAndFeel.SkinName = "Blue";
            this.grdSum.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdSum.MainView = this.grvSum;
            this.grdSum.Name = "grdSum";
            this.grdSum.Size = new System.Drawing.Size(837, 423);
            this.grdSum.TabIndex = 8;
            this.grdSum.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSum});
            // 
            // grvSum
            // 
            this.grvSum.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvSum.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSum.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvSum.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvSum.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvSum.GridControl = this.grdSum;
            this.grvSum.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.grvSum.Name = "grvSum";
            this.grvSum.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvSum.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvSum.OptionsBehavior.Editable = false;
            this.grvSum.OptionsCustomization.AllowRowSizing = true;
            this.grvSum.OptionsLayout.Columns.AddNewColumns = false;
            this.grvSum.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grvSum.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvSum.OptionsView.ShowFooter = true;
            this.grvSum.OptionsView.ShowGroupPanel = false;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.grdCost);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(711, 316);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // grdCost
            // 
            this.grdCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCost.Location = new System.Drawing.Point(0, 0);
            this.grdCost.LookAndFeel.SkinName = "Blue";
            this.grdCost.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdCost.MainView = this.grvCost;
            this.grdCost.Name = "grdCost";
            this.grdCost.Size = new System.Drawing.Size(711, 316);
            this.grdCost.TabIndex = 8;
            this.grdCost.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCost});
            // 
            // grvCost
            // 
            this.grvCost.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvCost.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCost.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCost.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCost.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvCost.GridControl = this.grdCost;
            this.grvCost.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.grvCost.Name = "grvCost";
            this.grvCost.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvCost.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvCost.OptionsBehavior.Editable = false;
            this.grvCost.OptionsCustomization.AllowRowSizing = true;
            this.grvCost.OptionsLayout.Columns.AddNewColumns = false;
            this.grvCost.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grvCost.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvCost.OptionsView.ShowFooter = true;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Image = global::ImportExcels.Properties.Resources.btnthoat;
            this.btnExit.Location = new System.Drawing.Point(743, 492);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 30);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Th&oát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmBCTonKhoSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 525);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmBCTonKhoSum";
            this.Text = "frmBCTonKhoSum";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBCTonKhoSum_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSum)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl grdSum;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSum;
        private DevExpress.XtraGrid.GridControl grdCost;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCost;
    }
}