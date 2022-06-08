namespace ImportExcels.UserControl
{
    partial class ucNSKido
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
            this.datToDate = new DevExpress.XtraEditors.DateEdit();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.datFromDate = new DevExpress.XtraEditors.DateEdit();
            this.cmbCatmachine = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCatMachine = new System.Windows.Forms.Label();
            this.cmbNhaXuong = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNhaXuong = new System.Windows.Forms.Label();
            this.cmbDistrict = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.cmbCity = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCity = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdCN = new DevExpress.XtraGrid.GridControl();
            this.grvCN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDSCN = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.btnChon = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtMSCN = new DevExpress.XtraEditors.TextEdit();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcute = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCatmachine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhaXuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDistrict.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCity.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCN)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSCN.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // datToDate
            // 
            this.datToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datToDate.EditValue = null;
            this.datToDate.Location = new System.Drawing.Point(373, 103);
            this.datToDate.Name = "datToDate";
            this.datToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.datToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datToDate.Size = new System.Drawing.Size(239, 20);
            this.datToDate.TabIndex = 7;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenNgay.Location = new System.Drawing.Point(313, 100);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(54, 25);
            this.lblDenNgay.TabIndex = 1;
            this.lblDenNgay.Text = "Đến ngày";
            this.lblDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datFromDate
            // 
            this.datFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datFromDate.EditValue = null;
            this.datFromDate.Location = new System.Drawing.Point(69, 103);
            this.datFromDate.Name = "datFromDate";
            this.datFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.datFromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datFromDate.Size = new System.Drawing.Size(238, 20);
            this.datFromDate.TabIndex = 6;
            // 
            // cmbCatmachine
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbCatmachine, 3);
            this.cmbCatmachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCatmachine.Location = new System.Drawing.Point(69, 78);
            this.cmbCatmachine.Name = "cmbCatmachine";
            this.cmbCatmachine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCatmachine.Size = new System.Drawing.Size(543, 20);
            this.cmbCatmachine.TabIndex = 31;
            // 
            // lblCatMachine
            // 
            this.lblCatMachine.AutoSize = true;
            this.lblCatMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCatMachine.Location = new System.Drawing.Point(3, 75);
            this.lblCatMachine.Name = "lblCatMachine";
            this.lblCatMachine.Size = new System.Drawing.Size(60, 25);
            this.lblCatMachine.TabIndex = 32;
            this.lblCatMachine.Text = "Loại máy";
            this.lblCatMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbNhaXuong
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbNhaXuong, 3);
            this.cmbNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNhaXuong.Location = new System.Drawing.Point(69, 53);
            this.cmbNhaXuong.Name = "cmbNhaXuong";
            this.cmbNhaXuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNhaXuong.Size = new System.Drawing.Size(543, 20);
            this.cmbNhaXuong.TabIndex = 33;
            // 
            // lblNhaXuong
            // 
            this.lblNhaXuong.AutoSize = true;
            this.lblNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhaXuong.Location = new System.Drawing.Point(3, 50);
            this.lblNhaXuong.Name = "lblNhaXuong";
            this.lblNhaXuong.Size = new System.Drawing.Size(60, 25);
            this.lblNhaXuong.TabIndex = 34;
            this.lblNhaXuong.Text = "Nhà xưởng";
            this.lblNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDistrict
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbDistrict, 3);
            this.cmbDistrict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDistrict.Location = new System.Drawing.Point(69, 28);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDistrict.Size = new System.Drawing.Size(543, 20);
            this.cmbDistrict.TabIndex = 28;
            this.cmbDistrict.EditValueChanged += new System.EventHandler(this.cmbDistrict_EditValueChanged);
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDistrict.Location = new System.Drawing.Point(3, 25);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(60, 25);
            this.lblDistrict.TabIndex = 3;
            this.lblDistrict.Text = "Quận";
            this.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCity
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbCity, 3);
            this.cmbCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCity.Location = new System.Drawing.Point(69, 3);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCity.Size = new System.Drawing.Size(543, 20);
            this.cmbCity.TabIndex = 27;
            this.cmbCity.EditValueChanged += new System.EventHandler(this.cmbCity_EditValueChanged);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCity.Location = new System.Drawing.Point(3, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(60, 25);
            this.lblCity.TabIndex = 2;
            this.lblCity.Text = "Tỉnh";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grdCN, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblCity, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCity, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDistrict, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbDistrict, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNhaXuong, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbNhaXuong, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCatMachine, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbCatmachine, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTuNgay, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.datFromDate, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDenNgay, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.datToDate, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDSCN, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(615, 408);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grdCN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdCN, 4);
            this.grdCN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCN.Location = new System.Drawing.Point(3, 144);
            this.grdCN.LookAndFeel.SkinName = "Blue";
            this.grdCN.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdCN.MainView = this.grvCN;
            this.grdCN.Name = "grdCN";
            this.grdCN.Size = new System.Drawing.Size(609, 224);
            this.grdCN.TabIndex = 36;
            this.grdCN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCN});
            // 
            // grvCN
            // 
            this.grvCN.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvCN.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCN.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCN.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCN.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvCN.GridControl = this.grdCN;
            this.grvCN.Name = "grvCN";
            this.grvCN.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvCN.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvCN.OptionsCustomization.AllowColumnMoving = false;
            this.grvCN.OptionsCustomization.AllowRowSizing = true;
            this.grvCN.OptionsLayout.Columns.AddNewColumns = false;
            this.grvCN.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grvCN.OptionsSelection.MultiSelect = true;
            this.grvCN.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvCN.OptionsView.ShowGroupPanel = false;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuNgay.Location = new System.Drawing.Point(3, 100);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(60, 25);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            this.lblTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDSCN
            // 
            this.lblDSCN.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblDSCN, 2);
            this.lblDSCN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDSCN.Location = new System.Drawing.Point(3, 125);
            this.lblDSCN.Name = "lblDSCN";
            this.lblDSCN.Size = new System.Drawing.Size(304, 16);
            this.lblDSCN.TabIndex = 0;
            this.lblDSCN.Text = "Danh sách nhân viên";
            this.lblDSCN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.lblTimKiem);
            this.panel1.Controls.Add(this.btnChon);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.txtMSCN);
            this.panel1.Controls.Add(this.btnKhong);
            this.panel1.Controls.Add(this.btnExcute);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 31);
            this.panel1.TabIndex = 38;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(3, 12);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(48, 13);
            this.lblTimKiem.TabIndex = 39;
            this.lblTimKiem.Text = "Tim Kiem";
            this.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnChon
            // 
            this.btnChon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChon.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChon.Appearance.Options.UseFont = true;
            this.btnChon.Image = global::ImportExcels.Properties.Resources.btnall;
            this.btnChon.Location = new System.Drawing.Point(230, 0);
            this.btnChon.LookAndFeel.SkinName = "Blue";
            this.btnChon.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(94, 28);
            this.btnChon.TabIndex = 6;
            this.btnChon.Text = "Chon";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Image = global::ImportExcels.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(512, 0);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(94, 28);
            this.btnThoat.TabIndex = 33;
            this.btnThoat.Text = "Thoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtMSCN
            // 
            this.txtMSCN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMSCN.Location = new System.Drawing.Point(66, 8);
            this.txtMSCN.Name = "txtMSCN";
            this.txtMSCN.Size = new System.Drawing.Size(98, 20);
            this.txtMSCN.TabIndex = 40;
            this.txtMSCN.EditValueChanged += new System.EventHandler(this.txtMSCN_EditValueChanged);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhong.Appearance.Options.UseFont = true;
            this.btnKhong.Image = global::ImportExcels.Properties.Resources.btnuncheckall;
            this.btnKhong.Location = new System.Drawing.Point(324, 0);
            this.btnKhong.LookAndFeel.SkinName = "Blue";
            this.btnKhong.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(94, 28);
            this.btnKhong.TabIndex = 7;
            this.btnKhong.Text = "bo chon";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnExcute
            // 
            this.btnExcute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcute.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcute.Appearance.Options.UseFont = true;
            this.btnExcute.Image = global::ImportExcels.Properties.Resources.btnthuchien;
            this.btnExcute.Location = new System.Drawing.Point(418, 0);
            this.btnExcute.LookAndFeel.SkinName = "Blue";
            this.btnExcute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(94, 28);
            this.btnExcute.TabIndex = 8;
            this.btnExcute.Text = "Thực hiện";
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // ucNSKido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucNSKido";
            this.Size = new System.Drawing.Size(615, 408);
            this.Load += new System.EventHandler(this.ucNSKido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCatmachine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhaXuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDistrict.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCity.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCN)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSCN.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit datToDate;
        private System.Windows.Forms.Label lblDenNgay;
        private DevExpress.XtraEditors.DateEdit datFromDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCity;
        private DevExpress.XtraEditors.LookUpEdit cmbCity;
        private System.Windows.Forms.Label lblDistrict;
        private DevExpress.XtraEditors.LookUpEdit cmbDistrict;
        private System.Windows.Forms.Label lblNhaXuong;
        private DevExpress.XtraEditors.LookUpEdit cmbNhaXuong;
        private System.Windows.Forms.Label lblCatMachine;
        private DevExpress.XtraEditors.LookUpEdit cmbCatmachine;
        private System.Windows.Forms.Label lblDSCN;
        private DevExpress.XtraGrid.GridControl grdCN;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnChon;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.SimpleButton btnExcute;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblTimKiem;
        private DevExpress.XtraEditors.TextEdit txtMSCN;

    }
}
