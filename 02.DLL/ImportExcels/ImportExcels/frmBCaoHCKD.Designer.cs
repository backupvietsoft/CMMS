namespace ImportExcels
{
    partial class frmBCaoHCKD
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
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grdSource = new DevExpress.XtraGrid.GridControl();
            this.grvSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Image = global::ImportExcels.Properties.Resources.btnexcel;
            this.btnExport.Location = new System.Drawing.Point(478, 444);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 26);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "&Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdSource, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(715, 473);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Image = global::ImportExcels.Properties.Resources.btnthoat;
            this.btnExit.Location = new System.Drawing.Point(568, 444);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 26);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Th&oát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 4);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(709, 32);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Visible = false;
            // 
            // grdSource
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdSource, 4);
            this.grdSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSource.Location = new System.Drawing.Point(3, 35);
            this.grdSource.LookAndFeel.SkinName = "Blue";
            this.grdSource.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdSource.MainView = this.grvSource;
            this.grdSource.Name = "grdSource";
            this.grdSource.Size = new System.Drawing.Size(709, 403);
            this.grdSource.TabIndex = 7;
            this.grdSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSource});
            // 
            // grvSource
            // 
            this.grvSource.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvSource.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSource.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvSource.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvSource.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvSource.GridControl = this.grdSource;
            this.grvSource.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.grvSource.Name = "grvSource";
            this.grvSource.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvSource.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvSource.OptionsBehavior.Editable = false;
            this.grvSource.OptionsCustomization.AllowRowSizing = true;
            this.grvSource.OptionsLayout.Columns.AddNewColumns = false;
            this.grvSource.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grvSource.OptionsView.AllowHtmlDrawHeaders = true;
            // 
            // frmBCaoHCKD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 473);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmBCaoHCKD";
            this.Text = "frmBCaoHCKD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBCaoHCKD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraGrid.GridControl grdSource;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSource;

    }
}