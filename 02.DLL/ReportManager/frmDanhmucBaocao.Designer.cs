namespace ReportManager
{
    partial class frmDanhmucBaocao
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
            this.grdReports = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.REPORT_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_REPORT_VIET = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_REPORT_ANH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_REPORT_HOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LOAI_REPORT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_loairpt = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUSTUMER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NAMES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_type = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_loairpt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_type)).BeginInit();
            this.SuspendLayout();
            // 
            // grdReports
            // 
            this.grdReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReports.Location = new System.Drawing.Point(0, 0);
            this.grdReports.LookAndFeel.SkinName = "Blue";
            this.grdReports.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdReports.MainView = this.gridView1;
            this.grdReports.Name = "grdReports";
            this.grdReports.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_loairpt,
            this.repositoryItemLookUpEdit_type});
            this.grdReports.Size = new System.Drawing.Size(606, 432);
            this.grdReports.TabIndex = 0;
            this.grdReports.UseEmbeddedNavigator = true;
            this.grdReports.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.REPORT_NAME,
            this.TEN_REPORT_VIET,
            this.TEN_REPORT_ANH,
            this.TEN_REPORT_HOA,
            this.LOAI_REPORT,
            this.STT,
            this.CUSTUMER,
            this.NOTE,
            this.NAMES,
            this.TYPE});
            this.gridView1.GridControl = this.grdReports;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            // 
            // REPORT_NAME
            // 
            this.REPORT_NAME.Caption = "Report Name";
            this.REPORT_NAME.FieldName = "REPORT_NAME";
            this.REPORT_NAME.Name = "REPORT_NAME";
            this.REPORT_NAME.Visible = true;
            this.REPORT_NAME.VisibleIndex = 0;
            // 
            // TEN_REPORT_VIET
            // 
            this.TEN_REPORT_VIET.Caption = "Ten Viet";
            this.TEN_REPORT_VIET.FieldName = "TEN_REPORT_VIET";
            this.TEN_REPORT_VIET.Name = "TEN_REPORT_VIET";
            this.TEN_REPORT_VIET.Visible = true;
            this.TEN_REPORT_VIET.VisibleIndex = 1;
            // 
            // TEN_REPORT_ANH
            // 
            this.TEN_REPORT_ANH.Caption = "Ten Anh";
            this.TEN_REPORT_ANH.FieldName = "TEN_REPORT_ANH";
            this.TEN_REPORT_ANH.Name = "TEN_REPORT_ANH";
            this.TEN_REPORT_ANH.Visible = true;
            this.TEN_REPORT_ANH.VisibleIndex = 2;
            // 
            // TEN_REPORT_HOA
            // 
            this.TEN_REPORT_HOA.Caption = "Ten Hoa";
            this.TEN_REPORT_HOA.FieldName = "TEN_REPORT_HOA";
            this.TEN_REPORT_HOA.Name = "TEN_REPORT_HOA";
            this.TEN_REPORT_HOA.Visible = true;
            this.TEN_REPORT_HOA.VisibleIndex = 3;
            // 
            // LOAI_REPORT
            // 
            this.LOAI_REPORT.Caption = "Nhom Report";
            this.LOAI_REPORT.ColumnEdit = this.repositoryItemLookUpEdit_loairpt;
            this.LOAI_REPORT.FieldName = "LOAI_REPORT";
            this.LOAI_REPORT.Name = "LOAI_REPORT";
            this.LOAI_REPORT.Visible = true;
            this.LOAI_REPORT.VisibleIndex = 4;
            // 
            // repositoryItemLookUpEdit_loairpt
            // 
            this.repositoryItemLookUpEdit_loairpt.AutoHeight = false;
            this.repositoryItemLookUpEdit_loairpt.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_loairpt.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_L_REPORT", "Loai Report"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_L_REPORT_EN", "Loai Report EN")});
            this.repositoryItemLookUpEdit_loairpt.DisplayMember = "TEN_L_REPORT";
            this.repositoryItemLookUpEdit_loairpt.DropDownRows = 10;
            this.repositoryItemLookUpEdit_loairpt.Name = "repositoryItemLookUpEdit_loairpt";
            this.repositoryItemLookUpEdit_loairpt.ValueMember = "MS_LOAI";
            // 
            // STT
            // 
            this.STT.Caption = "Stt";
            this.STT.FieldName = "STT";
            this.STT.Name = "STT";
            this.STT.Visible = true;
            this.STT.VisibleIndex = 5;
            // 
            // CUSTUMER
            // 
            this.CUSTUMER.Caption = "Khach hang";
            this.CUSTUMER.FieldName = "CUSTUMER";
            this.CUSTUMER.Name = "CUSTUMER";
            this.CUSTUMER.Visible = true;
            this.CUSTUMER.VisibleIndex = 6;
            // 
            // NOTE
            // 
            this.NOTE.Caption = "Ghi chu";
            this.NOTE.FieldName = "NOTE";
            this.NOTE.Name = "NOTE";
            this.NOTE.Visible = true;
            this.NOTE.VisibleIndex = 7;
            // 
            // NAMES
            // 
            this.NAMES.Caption = "Namespace";
            this.NAMES.FieldName = "NAMES";
            this.NAMES.Name = "NAMES";
            this.NAMES.Visible = true;
            this.NAMES.VisibleIndex = 8;
            // 
            // TYPE
            // 
            this.TYPE.Caption = "Loai Report";
            this.TYPE.ColumnEdit = this.repositoryItemLookUpEdit_type;
            this.TYPE.FieldName = "TYPE";
            this.TYPE.Name = "TYPE";
            this.TYPE.Visible = true;
            this.TYPE.VisibleIndex = 9;
            // 
            // repositoryItemLookUpEdit_type
            // 
            this.repositoryItemLookUpEdit_type.AutoHeight = false;
            this.repositoryItemLookUpEdit_type.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_type.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TYPE_RPT", "Loai Report")});
            this.repositoryItemLookUpEdit_type.DisplayMember = "LOAI_RPT";
            this.repositoryItemLookUpEdit_type.Name = "repositoryItemLookUpEdit_type";
            // 
            // frmDanhmucBaocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 432);
            this.Controls.Add(this.grdReports);
            this.Name = "frmDanhmucBaocao";
            this.Text = "frmDanhmucBaocao";
            this.Load += new System.EventHandler(this.frmDanhmucBaocao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_loairpt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_type)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdReports;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn REPORT_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_REPORT_VIET;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_REPORT_ANH;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_REPORT_HOA;
        private DevExpress.XtraGrid.Columns.GridColumn LOAI_REPORT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_loairpt;
        private DevExpress.XtraGrid.Columns.GridColumn STT;
        private DevExpress.XtraGrid.Columns.GridColumn CUSTUMER;
        private DevExpress.XtraGrid.Columns.GridColumn NOTE;
        private DevExpress.XtraGrid.Columns.GridColumn NAMES;
        private DevExpress.XtraGrid.Columns.GridColumn TYPE;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_type;
    }
}