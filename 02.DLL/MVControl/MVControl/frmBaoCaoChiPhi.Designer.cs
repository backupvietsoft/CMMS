namespace MVControl
{
    partial class frmBaoCaoChiPhi
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
            this.tvwChiPhi = new DevExpress.XtraTreeList.TreeList();
            this.button1 = new System.Windows.Forms.Button();
            this.grdMay = new DevExpress.XtraGrid.GridControl();
            this.grvMay = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.tvwChiPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).BeginInit();
            this.SuspendLayout();
            // 
            // tvwChiPhi
            // 
            this.tvwChiPhi.AllowDrop = true;
            this.tvwChiPhi.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.tvwChiPhi.Appearance.FocusedCell.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tvwChiPhi.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tvwChiPhi.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tvwChiPhi.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.tvwChiPhi.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.tvwChiPhi.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tvwChiPhi.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tvwChiPhi.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvwChiPhi.Location = new System.Drawing.Point(0, 0);
            this.tvwChiPhi.Name = "tvwChiPhi";
            this.tvwChiPhi.OptionsBehavior.Editable = false;
            this.tvwChiPhi.OptionsPrint.AutoRowHeight = false;
            this.tvwChiPhi.OptionsPrint.AutoWidth = false;
            this.tvwChiPhi.OptionsPrint.PrintHorzLines = false;
            this.tvwChiPhi.OptionsPrint.PrintImages = false;
            this.tvwChiPhi.OptionsPrint.PrintPageHeader = false;
            this.tvwChiPhi.OptionsPrint.PrintReportFooter = false;
            this.tvwChiPhi.OptionsPrint.PrintTree = false;
            this.tvwChiPhi.OptionsPrint.PrintTreeButtons = false;
            this.tvwChiPhi.OptionsPrint.PrintVertLines = false;
            this.tvwChiPhi.OptionsView.AutoCalcPreviewLineCount = true;
            this.tvwChiPhi.OptionsView.ShowHorzLines = false;
            this.tvwChiPhi.OptionsView.ShowPreview = true;
            this.tvwChiPhi.RootValue = -1;
            this.tvwChiPhi.Size = new System.Drawing.Size(991, 241);
            this.tvwChiPhi.TabIndex = 3;
            this.tvwChiPhi.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.tvwChiPhi_NodeCellStyle);
            this.tvwChiPhi.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.tvwChiPhi_CustomDrawNodeCell);
            this.tvwChiPhi.CustomDrawNodeImages += new DevExpress.XtraTreeList.CustomDrawNodeImagesEventHandler(this.tvwChiPhi_CustomDrawNodeImages);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(991, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grdMay
            // 
            this.grdMay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdMay.Location = new System.Drawing.Point(0, 247);
            this.grdMay.LookAndFeel.SkinName = "Blue";
            this.grdMay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdMay.MainView = this.grvMay;
            this.grdMay.Name = "grdMay";
            this.grdMay.Size = new System.Drawing.Size(991, 299);
            this.grdMay.TabIndex = 7;
            this.grdMay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMay});
            // 
            // grvMay
            // 
            this.grvMay.GridControl = this.grdMay;
            this.grvMay.Name = "grvMay";
            this.grvMay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvMay.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvMay.OptionsView.ShowGroupPanel = false;
            // 
            // frmBaoCaoChiPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 569);
            this.Controls.Add(this.grdMay);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tvwChiPhi);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmBaoCaoChiPhi";
            this.Text = "frmBaoCaoChiPhi";
            this.Load += new System.EventHandler(this.frmBaoCaoChiPhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tvwChiPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraTreeList.TreeList tvwChiPhi;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.GridControl grdMay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMay;
    }
}