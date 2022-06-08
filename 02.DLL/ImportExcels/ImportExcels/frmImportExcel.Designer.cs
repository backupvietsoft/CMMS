namespace ImportExcels
{
    partial class frmImportExcel
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboLImportParent = new DevExpress.XtraEditors.LookUpEdit();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnFile = new DevExpress.XtraEditors.ButtonEdit();
            this.lokSheet = new DevExpress.XtraEditors.LookUpEdit();
            this.cboLImport = new DevExpress.XtraEditors.LookUpEdit();
            this.lblChon = new System.Windows.Forms.Label();
            this.lblLevelImport = new System.Windows.Forms.Label();
            this.lblChonImport = new System.Windows.Forms.Label();
            this.chkLoad = new System.Windows.Forms.CheckBox();
            this.grdSource = new DevExpress.XtraGrid.GridControl();
            this.grvSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblTong = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.btnALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnNoALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportTemplate = new DevExpress.XtraEditors.SimpleButton();
            this.chkGT = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLImportParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokSheet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLImport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkGT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.tableLayoutPanel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1275, 73);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Thông tin import";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Controls.Add(this.cboLImportParent, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFile, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lokSheet, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboLImport, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblChon, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLevelImport, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblChonImport, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkLoad, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1271, 49);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cboLImportParent
            // 
            this.cboLImportParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLImportParent.Location = new System.Drawing.Point(123, 28);
            this.cboLImportParent.Name = "cboLImportParent";
            this.cboLImportParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLImportParent.Properties.NullText = "";
            this.cboLImportParent.Size = new System.Drawing.Size(499, 20);
            this.cboLImportParent.TabIndex = 7;
            this.cboLImportParent.EditValueChanged += new System.EventHandler(this.cboLImportParent_EditValueChanged);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFile.Location = new System.Drawing.Point(3, 3);
            this.lblFile.Margin = new System.Windows.Forms.Padding(3);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(114, 19);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "File excel";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFile
            // 
            this.btnFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFile.EditValue = "";
            this.btnFile.Location = new System.Drawing.Point(123, 3);
            this.btnFile.Name = "btnFile";
            this.btnFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnFile.Size = new System.Drawing.Size(499, 20);
            this.btnFile.TabIndex = 2;
            this.btnFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnFile_ButtonClick);
            this.btnFile.DoubleClick += new System.EventHandler(this.btnFile_DoubleClick);
            // 
            // lokSheet
            // 
            this.lokSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lokSheet.Location = new System.Drawing.Point(748, 3);
            this.lokSheet.Name = "lokSheet";
            this.lokSheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokSheet.Properties.NullText = "";
            this.lokSheet.Size = new System.Drawing.Size(499, 20);
            this.lokSheet.TabIndex = 3;
            this.lokSheet.EditValueChanged += new System.EventHandler(this.lokSheet_EditValueChanged);
            // 
            // cboLImport
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboLImport, 2);
            this.cboLImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLImport.Location = new System.Drawing.Point(748, 28);
            this.cboLImport.Name = "cboLImport";
            this.cboLImport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLImport.Properties.NullText = "";
            this.cboLImport.Size = new System.Drawing.Size(520, 20);
            this.cboLImport.TabIndex = 4;
            this.cboLImport.EditValueChanged += new System.EventHandler(this.cboLImport_EditValueChanged);
            // 
            // lblChon
            // 
            this.lblChon.AutoSize = true;
            this.lblChon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChon.Location = new System.Drawing.Point(628, 3);
            this.lblChon.Margin = new System.Windows.Forms.Padding(3);
            this.lblChon.Name = "lblChon";
            this.lblChon.Size = new System.Drawing.Size(114, 19);
            this.lblChon.TabIndex = 1;
            this.lblChon.Text = "Chọn sheet";
            this.lblChon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLevelImport
            // 
            this.lblLevelImport.AutoSize = true;
            this.lblLevelImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLevelImport.Location = new System.Drawing.Point(3, 28);
            this.lblLevelImport.Margin = new System.Windows.Forms.Padding(3);
            this.lblLevelImport.Name = "lblLevelImport";
            this.lblLevelImport.Size = new System.Drawing.Size(114, 19);
            this.lblLevelImport.TabIndex = 6;
            this.lblLevelImport.Text = "lblLevelImport";
            this.lblLevelImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChonImport
            // 
            this.lblChonImport.AutoSize = true;
            this.lblChonImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChonImport.Location = new System.Drawing.Point(628, 28);
            this.lblChonImport.Margin = new System.Windows.Forms.Padding(3);
            this.lblChonImport.Name = "lblChonImport";
            this.lblChonImport.Size = new System.Drawing.Size(114, 19);
            this.lblChonImport.TabIndex = 1;
            this.lblChonImport.Text = "lblChonImport";
            this.lblChonImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkLoad
            // 
            this.chkLoad.AutoSize = true;
            this.chkLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLoad.Location = new System.Drawing.Point(1253, 3);
            this.chkLoad.Name = "chkLoad";
            this.chkLoad.Size = new System.Drawing.Size(15, 19);
            this.chkLoad.TabIndex = 8;
            this.chkLoad.Text = "checkBox1";
            this.chkLoad.UseVisualStyleBackColor = true;
            // 
            // grdSource
            // 
            this.grdSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSource.Location = new System.Drawing.Point(2, 22);
            this.grdSource.MainView = this.grvSource;
            this.grdSource.Name = "grdSource";
            this.grdSource.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdSource.Size = new System.Drawing.Size(1271, 530);
            this.grdSource.TabIndex = 6;
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
            this.grvSource.HorzScrollStep = 1;
            this.grvSource.Name = "grvSource";
            this.grvSource.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvSource.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvSource.OptionsCustomization.AllowColumnMoving = false;
            this.grvSource.OptionsCustomization.AllowRowSizing = true;
            this.grvSource.OptionsLayout.Columns.AddNewColumns = false;
            this.grvSource.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grvSource.OptionsSelection.MultiSelect = true;
            this.grvSource.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvSource.OptionsView.ColumnAutoWidth = false;
            this.grvSource.OptionsView.ShowGroupPanel = false;
            this.grvSource.ShownEditor += new System.EventHandler(this.grvSource_ShownEditor);
            this.grvSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvSource_KeyDown);
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.lblTong);
            this.groupControl2.Controls.Add(this.grdSource);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 82);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1275, 554);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Dữ liệu import";
            // 
            // lblTong
            // 
            this.lblTong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTong.Location = new System.Drawing.Point(959, 4);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(311, 13);
            this.lblTong.TabIndex = 7;
            this.lblTong.Text = "label1";
            this.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.prbIN, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1281, 703);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // prbIN
            // 
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 642);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(1275, 16);
            this.prbIN.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.Controls.Add(this.btnXoa, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExit, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnImport, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnALL, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnNoALL, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExportTemplate, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkGT, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 664);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1275, 36);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoa.Location = new System.Drawing.Point(3, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(104, 30);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "&Xoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(1168, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 30);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Th&oát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnImport
            // 
            this.btnImport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImport.Location = new System.Drawing.Point(1058, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(104, 30);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "&Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnALL
            // 
            this.btnALL.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALL.Appearance.Options.UseFont = true;
            this.btnALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnALL.Location = new System.Drawing.Point(842, 3);
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(100, 30);
            this.btnALL.TabIndex = 9;
            this.btnALL.Text = "btn&ALL";
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // btnNoALL
            // 
            this.btnNoALL.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoALL.Appearance.Options.UseFont = true;
            this.btnNoALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNoALL.Location = new System.Drawing.Point(948, 3);
            this.btnNoALL.Name = "btnNoALL";
            this.btnNoALL.Size = new System.Drawing.Size(104, 30);
            this.btnNoALL.TabIndex = 9;
            this.btnNoALL.Text = "btn&NoALL";
            this.btnNoALL.Click += new System.EventHandler(this.btnNoALL_Click);
            // 
            // btnExportTemplate
            // 
            this.btnExportTemplate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportTemplate.Appearance.Options.UseFont = true;
            this.btnExportTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportTemplate.Location = new System.Drawing.Point(732, 3);
            this.btnExportTemplate.Name = "btnExportTemplate";
            this.btnExportTemplate.Size = new System.Drawing.Size(104, 30);
            this.btnExportTemplate.TabIndex = 12;
            this.btnExportTemplate.Text = "Export Template";
            this.btnExportTemplate.Click += new System.EventHandler(this.btnExportTemplate_Click);
            // 
            // chkGT
            // 
            this.chkGT.Location = new System.Drawing.Point(113, 3);
            this.chkGT.Name = "chkGT";
            this.chkGT.Properties.Caption = "chkGT";
            this.chkGT.Size = new System.Drawing.Size(57, 18);
            this.chkGT.TabIndex = 5;
            this.chkGT.Visible = false;
            // 
            // frmImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 703);
            this.Controls.Add(this.tableLayoutPanel3);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmImportExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmImportExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLImportParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokSheet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLImport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkGT.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSource;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblChon;
        private DevExpress.XtraEditors.ButtonEdit btnFile;
        private DevExpress.XtraEditors.LookUpEdit lokSheet;
        private DevExpress.XtraEditors.LookUpEdit cboLImport;
        private System.Windows.Forms.Label lblChonImport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private System.Windows.Forms.Label lblLevelImport;
        private DevExpress.XtraEditors.LookUpEdit cboLImportParent;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnALL;
        private DevExpress.XtraEditors.SimpleButton btnNoALL;
        private DevExpress.XtraEditors.SimpleButton btnExportTemplate;
        private DevExpress.XtraEditors.CheckEdit chkGT;
        private System.Windows.Forms.CheckBox chkLoad;
        private System.Windows.Forms.Label lblTong;
    }
}