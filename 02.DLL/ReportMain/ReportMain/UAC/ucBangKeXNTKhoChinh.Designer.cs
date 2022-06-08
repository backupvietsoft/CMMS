namespace ReportMain
{
    partial class ucBangKeXNTKhoChinh
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.cboKho = new DevExpress.XtraEditors.LookUpEdit();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTThang = new System.Windows.Forms.Label();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.datThang = new ReportMain.MMonthYearEdit();
            this.lblKho = new System.Windows.Forms.Label();
            this.cboLVT = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblLVT = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datThang.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLVT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.btnExecute, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnThoat, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.cboKho, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblTThang, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.prbIN, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.datThang, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKho, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboLVT, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLVT, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(899, 584);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnExecute.Location = new System.Drawing.Point(682, 534);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 32);
            this.btnExecute.TabIndex = 5;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ReportMain.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(792, 534);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 32);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cboKho
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboKho, 2);
            this.cboKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKho.Location = new System.Drawing.Point(223, 43);
            this.cboKho.Name = "cboKho";
            this.cboKho.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKho.Properties.LookAndFeel.SkinName = "Blue";
            this.cboKho.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboKho.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboKho.Size = new System.Drawing.Size(563, 20);
            this.cboKho.TabIndex = 2;
            // 
            // grdChung
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdChung, 5);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 101);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(893, 405);
            this.grdChung.TabIndex = 4;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung,
            this.gridView2});
            this.grdChung.Visible = false;
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsView.ShowGroupPanel = false;
            this.grvChung.PreviewFieldName = "Description";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdChung;
            this.gridView2.Name = "gridView2";
            // 
            // lblTThang
            // 
            this.lblTThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTThang.Location = new System.Drawing.Point(113, 15);
            this.lblTThang.Name = "lblTThang";
            this.lblTThang.Size = new System.Drawing.Size(104, 25);
            this.lblTThang.TabIndex = 9;
            this.lblTThang.Text = "lblTThang";
            this.lblTThang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prbIN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.prbIN, 5);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 512);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(893, 16);
            this.prbIN.TabIndex = 8;
            // 
            // datThang
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.datThang, 2);
            this.datThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datThang.EditValue = null;
            this.datThang.Location = new System.Drawing.Point(223, 18);
            this.datThang.MMonthYear = true;
            this.datThang.Name = "datThang";
            this.datThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datThang.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.datThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datThang.Properties.EditFormat.FormatString = "MM/yyyy";
            this.datThang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datThang.Properties.LookAndFeel.SkinName = "Blue";
            this.datThang.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.datThang.Properties.Mask.EditMask = "MM/yyyy";
            this.datThang.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datThang.Size = new System.Drawing.Size(563, 20);
            this.datThang.TabIndex = 1;
            // 
            // lblKho
            // 
            this.lblKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKho.Location = new System.Drawing.Point(113, 40);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(104, 25);
            this.lblKho.TabIndex = 9;
            this.lblKho.Text = "lblKho";
            this.lblKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLVT
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboLVT, 2);
            this.cboLVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLVT.Location = new System.Drawing.Point(223, 68);
            this.cboLVT.Name = "cboLVT";
            this.cboLVT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLVT.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLVT.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLVT.Size = new System.Drawing.Size(563, 20);
            this.cboLVT.TabIndex = 3;
            // 
            // lblLVT
            // 
            this.lblLVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLVT.Location = new System.Drawing.Point(113, 65);
            this.lblLVT.Name = "lblLVT";
            this.lblLVT.Size = new System.Drawing.Size(104, 25);
            this.lblLVT.TabIndex = 16;
            this.lblLVT.Text = "lblLVT";
            this.lblLVT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucBangKeXNTKhoChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucBangKeXNTKhoChinh";
            this.Size = new System.Drawing.Size(899, 584);
            this.Load += new System.EventHandler(this.ucBangKeXNTKhoChinh_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datThang.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLVT.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private System.Windows.Forms.Label lblTThang;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private MMonthYearEdit datThang;
        private System.Windows.Forms.Label lblKho;
        private DevExpress.XtraEditors.LookUpEdit cboKho;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboLVT;
        private System.Windows.Forms.Label lblLVT;
    }
}
