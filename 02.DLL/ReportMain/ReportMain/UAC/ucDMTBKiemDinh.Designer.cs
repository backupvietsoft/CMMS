namespace ReportMain
{
    partial class ucDMTBKiemDinh
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
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.lblTNam = new System.Windows.Forms.Label();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.datTNgay = new ReportMain.MMonthYearEdit();
            this.txtNKSoat = new DevExpress.XtraEditors.TextEdit();
            this.lblNguoiKiemSoat = new System.Windows.Forms.Label();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLMay = new System.Windows.Forms.Label();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.cboDChuyen = new MVControl.ucComboboxTreeList();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.cboDDiem = new MVControl.ucComboboxTreeList();
            this.lblPBan = new System.Windows.Forms.Label();
            this.cboPBan = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNKSoat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPBan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblTNam, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.prbIN, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.datTNgay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNKSoat, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNguoiKiemSoat, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboLMay, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblLMay, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDChuyen, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboDChuyen, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDDiem, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboDDiem, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPBan, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboPBan, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 519);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // grdChung
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdChung, 6);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 126);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemImageComboBox3});
            this.grdChung.Size = new System.Drawing.Size(728, 318);
            this.grdChung.TabIndex = 7;
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
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 38, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DisplayMember = "Name";
            this.repositoryItemLookUpEdit1.DropDownRows = 3;
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.PopupWidth = 200;
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            this.repositoryItemLookUpEdit1.ValueMember = "ID";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Full Name", 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit2.DisplayMember = "FullName";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.ShowFooter = false;
            this.repositoryItemLookUpEdit2.ShowHeader = false;
            this.repositoryItemLookUpEdit2.ValueMember = "ID";
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("New", 1, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Postponed", 2, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Fixed", 3, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Rejected", 4, 5)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Medium", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", 3, 8)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Bug", true, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Request", false, 1)});
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdChung;
            this.gridView2.Name = "gridView2";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 6);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnExecute, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 472);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(728, 36);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ReportMain.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(641, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 30);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnExecute.Location = new System.Drawing.Point(551, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(84, 30);
            this.btnExecute.TabIndex = 10;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblTNam
            // 
            this.lblTNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNam.Location = new System.Drawing.Point(113, 15);
            this.lblTNam.Name = "lblTNam";
            this.lblTNam.Size = new System.Drawing.Size(82, 25);
            this.lblTNam.TabIndex = 9;
            this.lblTNam.Text = "lblTNam";
            this.lblTNam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prbIN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.prbIN, 6);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 450);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(728, 16);
            this.prbIN.TabIndex = 8;
            // 
            // datTNgay
            // 
            this.datTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(201, 18);
            this.datTNgay.MMonthYear = true;
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.DisplayFormat.FormatString = "yyyy";
            this.datTNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.EditFormat.FormatString = "yyyy";
            this.datTNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.datTNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.datTNgay.Properties.Mask.EditMask = "yyyy";
            this.datTNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datTNgay.Size = new System.Drawing.Size(162, 20);
            this.datTNgay.TabIndex = 1;
            // 
            // txtNKSoat
            // 
            this.txtNKSoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNKSoat.Location = new System.Drawing.Point(201, 43);
            this.txtNKSoat.Name = "txtNKSoat";
            this.txtNKSoat.Properties.LookAndFeel.SkinName = "Blue";
            this.txtNKSoat.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtNKSoat.Size = new System.Drawing.Size(162, 20);
            this.txtNKSoat.TabIndex = 2;
            // 
            // lblNguoiKiemSoat
            // 
            this.lblNguoiKiemSoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNguoiKiemSoat.Location = new System.Drawing.Point(113, 40);
            this.lblNguoiKiemSoat.Name = "lblNguoiKiemSoat";
            this.lblNguoiKiemSoat.Size = new System.Drawing.Size(82, 25);
            this.lblNguoiKiemSoat.TabIndex = 9;
            this.lblNguoiKiemSoat.Text = "lblNguoiKiemSoat";
            this.lblNguoiKiemSoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboLMay, 3);
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(201, 93);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLMay.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboLMay.Size = new System.Drawing.Size(418, 20);
            this.cboLMay.TabIndex = 6;
            // 
            // lblLMay
            // 
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLMay.Location = new System.Drawing.Point(113, 90);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(82, 25);
            this.lblLMay.TabIndex = 9;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDChuyen.Location = new System.Drawing.Point(369, 65);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(82, 25);
            this.lblDChuyen.TabIndex = 9;
            this.lblDChuyen.Text = "lblDChuyen";
            this.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDChuyen
            // 
            this.cboDChuyen.ColumnDisplayName = null;
            this.cboDChuyen.DataSource = null;
            this.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDChuyen.EditValue = null;
            this.cboDChuyen.KeyFieldName = null;
            this.cboDChuyen.Location = new System.Drawing.Point(457, 68);
            this.cboDChuyen.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDChuyen.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.ParentFieldName = null;
            this.cboDChuyen.ReadOnly = false;
            this.cboDChuyen.SelectedIndex = 0;
            this.cboDChuyen.Size = new System.Drawing.Size(162, 20);
            this.cboDChuyen.TabIndex = 5;
            this.cboDChuyen.TextValue = null;
            this.cboDChuyen.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDChuyen_EditValueChanged);
            // 
            // lblDDiem
            // 
            this.lblDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDDiem.Location = new System.Drawing.Point(113, 65);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(82, 25);
            this.lblDDiem.TabIndex = 9;
            this.lblDDiem.Text = "lblDDiem";
            this.lblDDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDDiem
            // 
            this.cboDDiem.ColumnDisplayName = null;
            this.cboDDiem.DataSource = null;
            this.cboDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDDiem.EditValue = null;
            this.cboDDiem.KeyFieldName = null;
            this.cboDDiem.Location = new System.Drawing.Point(201, 68);
            this.cboDDiem.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDDiem.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.ParentFieldName = null;
            this.cboDDiem.ReadOnly = false;
            this.cboDDiem.SelectedIndex = 0;
            this.cboDDiem.Size = new System.Drawing.Size(162, 20);
            this.cboDDiem.TabIndex = 4;
            this.cboDDiem.TextValue = null;
            // 
            // lblPBan
            // 
            this.lblPBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPBan.Location = new System.Drawing.Point(369, 40);
            this.lblPBan.Name = "lblPBan";
            this.lblPBan.Size = new System.Drawing.Size(82, 25);
            this.lblPBan.TabIndex = 9;
            this.lblPBan.Text = "lblPBan";
            this.lblPBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPBan
            // 
            this.cboPBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPBan.Location = new System.Drawing.Point(457, 43);
            this.cboPBan.Name = "cboPBan";
            this.cboPBan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboPBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPBan.Properties.LookAndFeel.SkinName = "Blue";
            this.cboPBan.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboPBan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboPBan.Size = new System.Drawing.Size(162, 20);
            this.cboPBan.TabIndex = 3;
            this.cboPBan.EditValueChanged += new System.EventHandler(this.cboPBan_EditValueChanged);
            // 
            // ucDMTBKiemDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucDMTBKiemDinh";
            this.Size = new System.Drawing.Size(734, 519);
            this.Load += new System.EventHandler(this.ucDMTBKiemDinh_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNKSoat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPBan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private System.Windows.Forms.Label lblTNam;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private MMonthYearEdit datTNgay;
        private DevExpress.XtraEditors.TextEdit txtNKSoat;
        private System.Windows.Forms.Label lblNguoiKiemSoat;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
        private System.Windows.Forms.Label lblLMay;
        private System.Windows.Forms.Label lblDChuyen;
       private MVControl.ucComboboxTreeList cboDChuyen;
        private System.Windows.Forms.Label lblDDiem;
        private MVControl.ucComboboxTreeList cboDDiem;
        private System.Windows.Forms.Label lblPBan;
        private DevExpress.XtraEditors.LookUpEdit cboPBan;
    }
}
