namespace ReportMain
{
    partial class ucDanhSachVTPT
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
            this.optBCao = new DevExpress.XtraEditors.RadioGroup();
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
            this.btnTimMay = new DevExpress.XtraEditors.SimpleButton();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblMTBi = new System.Windows.Forms.Label();
            this.cboThietBi = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.cboDChuyen = new MVControl.ucComboboxTreeList();
            this.lblLMay = new System.Windows.Forms.Label();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTNgay = new System.Windows.Forms.Label();
            this.datTNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblDNgay = new System.Windows.Forms.Label();
            this.datDNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.cboDDiem = new MVControl.ucComboboxTreeList();
            this.lblLBCao = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLoaiBT = new System.Windows.Forms.Label();
            this.optTuyChon = new DevExpress.XtraEditors.RadioGroup();
            this.cboLoaiBT = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.optBCao.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.cboThietBi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optTuyChon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiBT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // optBCao
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.optBCao, 3);
            this.optBCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBCao.Location = new System.Drawing.Point(212, 144);
            this.optBCao.Name = "optBCao";
            this.optBCao.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optBCao.Properties.Appearance.Options.UseBackColor = true;
            this.optBCao.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optBCao.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optNoGroup", "optNoGroup"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optDiaDiem", "optDiaDiem"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optDChuyen", "optDChuyen"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optLoaiTB", "optLoaiTB"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optTBi", "optTBi")});
            this.optBCao.Properties.LookAndFeel.SkinName = "Blue";
            this.optBCao.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.optBCao.Size = new System.Drawing.Size(443, 23);
            this.optBCao.TabIndex = 8;
            // 
            // grdChung
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.grdChung, 6);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 181);
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
            this.grdChung.Size = new System.Drawing.Size(769, 363);
            this.grdChung.TabIndex = 9;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung,
            this.gridView2});
            this.grdChung.Visible = false;
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
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
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel5, 6);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel5.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnExecute, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 572);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(769, 36);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ReportMain.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(662, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnExecute.Location = new System.Drawing.Point(552, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 11;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnTimMay
            // 
            this.btnTimMay.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTimMay.Location = new System.Drawing.Point(661, 92);
            this.btnTimMay.LookAndFeel.SkinName = "Blue";
            this.btnTimMay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnTimMay.Name = "btnTimMay";
            this.btnTimMay.Size = new System.Drawing.Size(22, 20);
            this.btnTimMay.TabIndex = 7;
            this.btnTimMay.Text = "...";
            this.btnTimMay.Click += new System.EventHandler(this.btnTimMay_Click);
            // 
            // prbIN
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.prbIN, 6);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 550);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(769, 16);
            this.prbIN.TabIndex = 19;
            // 
            // lblMTBi
            // 
            this.lblMTBi.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMTBi.Location = new System.Drawing.Point(390, 89);
            this.lblMTBi.Name = "lblMTBi";
            this.lblMTBi.Size = new System.Drawing.Size(87, 26);
            this.lblMTBi.TabIndex = 9;
            this.lblMTBi.Text = "lblMTBi";
            this.lblMTBi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboThietBi
            // 
            this.cboThietBi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboThietBi.Location = new System.Drawing.Point(483, 92);
            this.cboThietBi.Name = "cboThietBi";
            this.cboThietBi.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboThietBi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboThietBi.Properties.LookAndFeel.SkinName = "Blue";
            this.cboThietBi.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboThietBi.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboThietBi.Size = new System.Drawing.Size(172, 20);
            this.cboThietBi.TabIndex = 6;
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDChuyen.Location = new System.Drawing.Point(390, 63);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(87, 26);
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
            this.cboDChuyen.Location = new System.Drawing.Point(483, 66);
            this.cboDChuyen.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDChuyen.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.ParentFieldName = null;
            this.cboDChuyen.ReadOnly = false;
            this.cboDChuyen.SelectedIndex = 0;
            this.cboDChuyen.Size = new System.Drawing.Size(172, 20);
            this.cboDChuyen.TabIndex = 4;
            this.cboDChuyen.TextValue = null;
            this.cboDChuyen.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDChuyen_EditValueChanged);
            // 
            // lblLMay
            // 
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLMay.Location = new System.Drawing.Point(119, 89);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(87, 26);
            this.lblLMay.TabIndex = 9;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLMay
            // 
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(212, 92);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLMay.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboLMay.Size = new System.Drawing.Size(172, 20);
            this.cboLMay.TabIndex = 5;
            this.cboLMay.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // lblTNgay
            // 
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTNgay.Location = new System.Drawing.Point(119, 37);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(87, 26);
            this.lblTNgay.TabIndex = 9;
            this.lblTNgay.Text = "lblTNgay";
            this.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datTNgay
            // 
            this.datTNgay.Dock = System.Windows.Forms.DockStyle.Left;
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(212, 40);
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datTNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datTNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.datTNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.datTNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datTNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.datTNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datTNgay.Size = new System.Drawing.Size(172, 20);
            this.datTNgay.TabIndex = 1;
            // 
            // lblDNgay
            // 
            this.lblDNgay.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDNgay.Location = new System.Drawing.Point(390, 37);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(87, 26);
            this.lblDNgay.TabIndex = 10;
            this.lblDNgay.Text = "lblDNgay";
            this.lblDNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datDNgay
            // 
            this.datDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datDNgay.EditValue = null;
            this.datDNgay.Location = new System.Drawing.Point(483, 40);
            this.datDNgay.Name = "datDNgay";
            this.datDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datDNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datDNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.datDNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.datDNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datDNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.datDNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datDNgay.Size = new System.Drawing.Size(172, 20);
            this.datDNgay.TabIndex = 2;
            // 
            // lblDDiem
            // 
            this.lblDDiem.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDDiem.Location = new System.Drawing.Point(119, 63);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(87, 26);
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
            this.cboDDiem.Location = new System.Drawing.Point(212, 66);
            this.cboDDiem.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDDiem.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.ParentFieldName = null;
            this.cboDDiem.ReadOnly = false;
            this.cboDDiem.SelectedIndex = 0;
            this.cboDDiem.Size = new System.Drawing.Size(172, 20);
            this.cboDDiem.TabIndex = 3;
            this.cboDDiem.TextValue = null;
            this.cboDDiem.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDChuyen_EditValueChanged);
            // 
            // lblLBCao
            // 
            this.lblLBCao.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLBCao.Location = new System.Drawing.Point(119, 141);
            this.lblLBCao.Name = "lblLBCao";
            this.lblLBCao.Size = new System.Drawing.Size(87, 29);
            this.lblLBCao.TabIndex = 9;
            this.lblLBCao.Text = "lblLBCao";
            this.lblLBCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.lblLoaiBT, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.grdChung, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.prbIN, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.optBCao, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblTNgay, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.datTNgay, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblDNgay, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnTimMay, 5, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblLBCao, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.datDNgay, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblDDiem, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cboThietBi, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblMTBi, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.cboDDiem, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblDChuyen, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.cboLMay, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblLMay, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cboDChuyen, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.optTuyChon, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.cboLoaiBT, 2, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(775, 611);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // lblLoaiBT
            // 
            this.lblLoaiBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiBT.Location = new System.Drawing.Point(119, 115);
            this.lblLoaiBT.Name = "lblLoaiBT";
            this.lblLoaiBT.Size = new System.Drawing.Size(87, 26);
            this.lblLoaiBT.TabIndex = 22;
            this.lblLoaiBT.Text = "lblLVT";
            this.lblLoaiBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // optTuyChon
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.optTuyChon, 3);
            this.optTuyChon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optTuyChon.EditValue = "optDaSudung";
            this.optTuyChon.Location = new System.Drawing.Point(212, 11);
            this.optTuyChon.Name = "optTuyChon";
            this.optTuyChon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optTuyChon.Properties.Appearance.Options.UseBackColor = true;
            this.optTuyChon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optTuyChon.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optDaSudung", "optDaSudung"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("optSeCanSuDung", "optSeCanSuDung")});
            this.optTuyChon.Properties.LookAndFeel.SkinName = "Blue";
            this.optTuyChon.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.optTuyChon.Size = new System.Drawing.Size(443, 23);
            this.optTuyChon.TabIndex = 20;
            // 
            // cboLoaiBT
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cboLoaiBT, 3);
            this.cboLoaiBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiBT.Location = new System.Drawing.Point(212, 118);
            this.cboLoaiBT.Name = "cboLoaiBT";
            this.cboLoaiBT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiBT.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLoaiBT.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLoaiBT.Size = new System.Drawing.Size(443, 20);
            this.cboLoaiBT.TabIndex = 21;
            // 
            // ucDanhSachVTPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucDanhSachVTPT";
            this.Size = new System.Drawing.Size(775, 611);
            this.Load += new System.EventHandler(this.ucDanhSachVTPT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.optBCao.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.cboThietBi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optTuyChon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiBT.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
        private DevExpress.XtraEditors.SimpleButton btnTimMay;
        private DevExpress.XtraEditors.DateEdit datTNgay;
        private System.Windows.Forms.Label lblTNgay;
        private System.Windows.Forms.Label lblDNgay;
        private DevExpress.XtraEditors.DateEdit datDNgay;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private System.Windows.Forms.Label lblMTBi;
        private DevExpress.XtraEditors.LookUpEdit cboThietBi;
        private System.Windows.Forms.Label lblDChuyen;
       private MVControl.ucComboboxTreeList cboDChuyen;
        private System.Windows.Forms.Label lblLMay;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
        private System.Windows.Forms.Label lblDDiem;
        private MVControl.ucComboboxTreeList cboDDiem;
        private DevExpress.XtraEditors.RadioGroup optBCao;
        private System.Windows.Forms.Label lblLBCao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.RadioGroup optTuyChon;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboLoaiBT;
        private System.Windows.Forms.Label lblLoaiBT;
    }
}
