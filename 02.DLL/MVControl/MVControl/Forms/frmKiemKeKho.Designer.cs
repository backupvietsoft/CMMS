namespace MVControl
{
    partial class frmKiemKeKho
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
            this.cboKho = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.btnVideo = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLock = new DevExpress.XtraEditors.SimpleButton();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXemHinh = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnTinhTon = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapNhatSL = new DevExpress.XtraEditors.SimpleButton();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.grdChon = new DevExpress.XtraGrid.GridControl();
            this.grvChon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblKho = new System.Windows.Forms.Label();
            this.dtGio = new DevExpress.XtraEditors.TimeEdit();
            this.lblNgayKK = new System.Windows.Forms.Label();
            this.cboNgayKK = new DevExpress.XtraEditors.LookUpEdit();
            this.lblGio = new System.Windows.Forms.Label();
            this.ckLock = new DevExpress.XtraEditors.CheckEdit();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.cboKho.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChon)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNgayKK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckLock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // cboKho
            // 
            this.cboKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKho.Location = new System.Drawing.Point(259, 3);
            this.cboKho.Name = "cboKho";
            this.cboKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKho.Properties.NullText = "";
            this.cboKho.Size = new System.Drawing.Size(123, 20);
            this.cboKho.TabIndex = 1;
            this.cboKho.EditValueChanged += new System.EventHandler(this.cboKho_EditValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Controls.Add(this.btnHelp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnVideo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.grdChon, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ckLock, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1060, 527);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnHelp
            // 
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnHelp.Location = new System.Drawing.Point(1003, 7);
            this.btnHelp.LookAndFeel.SkinName = "Blue";
            this.btnHelp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnHelp.Margin = new System.Windows.Forms.Padding(1);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 27);
            this.btnHelp.TabIndex = 100;
            this.btnHelp.Tag = "CMMS!frmKiemKeKho";
            // 
            // btnVideo
            // 
            this.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnVideo.Location = new System.Drawing.Point(1032, 7);
            this.btnVideo.LookAndFeel.SkinName = "Blue";
            this.btnVideo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnVideo.Margin = new System.Windows.Forms.Padding(1);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(27, 27);
            this.btnVideo.TabIndex = 101;
            this.btnVideo.Tag = "CMMS!frmKiemKeKho";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.btnLock);
            this.panel1.Controls.Add(this.txtTKiem);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnXemHinh);
            this.panel1.Controls.Add(this.btnKhongGhi);
            this.panel1.Controls.Add(this.btnTinhTon);
            this.panel1.Controls.Add(this.btnCapNhatSL);
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 494);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 30);
            this.panel1.TabIndex = 28;
            // 
            // btnLock
            // 
            this.btnLock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLock.Location = new System.Drawing.Point(423, 0);
            this.btnLock.LookAndFeel.SkinName = "Blue";
            this.btnLock.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(104, 30);
            this.btnLock.TabIndex = 8;
            this.btnLock.Text = "btnLock";
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // txtTKiem
            // 
            this.txtTKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTKiem.Location = new System.Drawing.Point(3, 5);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(165, 20);
            this.txtTKiem.TabIndex = 5;
            this.txtTKiem.EditValueChanged += new System.EventHandler(this.txtTKiem_EditValueChanged);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(633, 0);
            this.btnSua.LookAndFeel.SkinName = "Blue";
            this.btnSua.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(104, 30);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(528, 0);
            this.btnThem.LookAndFeel.SkinName = "Blue";
            this.btnThem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(104, 30);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXemHinh
            // 
            this.btnXemHinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXemHinh.Location = new System.Drawing.Point(171, 0);
            this.btnXemHinh.LookAndFeel.SkinName = "Blue";
            this.btnXemHinh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXemHinh.Name = "btnXemHinh";
            this.btnXemHinh.Size = new System.Drawing.Size(104, 30);
            this.btnXemHinh.TabIndex = 6;
            this.btnXemHinh.Text = "btnXoa";
            this.btnXemHinh.Click += new System.EventHandler(this.btnXemHinh_Click);
            // 
            // btnKhongGhi
            // 
            this.btnKhongGhi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhongGhi.Location = new System.Drawing.Point(948, 0);
            this.btnKhongGhi.LookAndFeel.SkinName = "Blue";
            this.btnKhongGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKhongGhi.Name = "btnKhongGhi";
            this.btnKhongGhi.Size = new System.Drawing.Size(104, 30);
            this.btnKhongGhi.TabIndex = 8;
            this.btnKhongGhi.Text = "btnKhongGhi";
            this.btnKhongGhi.Visible = false;
            this.btnKhongGhi.Click += new System.EventHandler(this.btnKhongGhi_Click);
            // 
            // btnTinhTon
            // 
            this.btnTinhTon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTinhTon.Location = new System.Drawing.Point(715, 0);
            this.btnTinhTon.LookAndFeel.SkinName = "Blue";
            this.btnTinhTon.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnTinhTon.Name = "btnTinhTon";
            this.btnTinhTon.Size = new System.Drawing.Size(127, 30);
            this.btnTinhTon.TabIndex = 6;
            this.btnTinhTon.Text = "btnTinhTon";
            this.btnTinhTon.Visible = false;
            this.btnTinhTon.Click += new System.EventHandler(this.btnTinhTon_Click);
            // 
            // btnCapNhatSL
            // 
            this.btnCapNhatSL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapNhatSL.Location = new System.Drawing.Point(541, 0);
            this.btnCapNhatSL.LookAndFeel.SkinName = "Blue";
            this.btnCapNhatSL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCapNhatSL.Name = "btnCapNhatSL";
            this.btnCapNhatSL.Size = new System.Drawing.Size(173, 30);
            this.btnCapNhatSL.TabIndex = 8;
            this.btnCapNhatSL.Text = "btnCapNhatSL";
            this.btnCapNhatSL.Visible = false;
            this.btnCapNhatSL.Click += new System.EventHandler(this.btnCapNhatSL_Click);
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Location = new System.Drawing.Point(843, 0);
            this.btnIn.LookAndFeel.SkinName = "Blue";
            this.btnIn.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(104, 30);
            this.btnIn.TabIndex = 6;
            this.btnIn.Text = "btnIn";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Location = new System.Drawing.Point(948, 0);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(843, 0);
            this.btnGhi.LookAndFeel.SkinName = "Blue";
            this.btnGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(104, 30);
            this.btnGhi.TabIndex = 8;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(738, 0);
            this.btnXoa.LookAndFeel.SkinName = "Blue";
            this.btnXoa.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(104, 30);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // grdChon
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdChon, 3);
            this.grdChon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChon.Location = new System.Drawing.Point(3, 44);
            this.grdChon.LookAndFeel.SkinName = "Blue";
            this.grdChon.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChon.MainView = this.grvChon;
            this.grdChon.Name = "grdChon";
            this.grdChon.Size = new System.Drawing.Size(1054, 444);
            this.grdChon.TabIndex = 4;
            this.grdChon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChon});
            // 
            // grvChon
            // 
            this.grvChon.GridControl = this.grdChon;
            this.grvChon.Name = "grvChon";
            this.grvChon.OptionsBehavior.FocusLeaveOnTab = true;
            this.grvChon.OptionsCustomization.AllowColumnMoving = false;
            this.grvChon.OptionsCustomization.AllowGroup = false;
            this.grvChon.OptionsView.ShowGroupPanel = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel2.Controls.Add(this.dtNgay, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboKho, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblKho, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtGio, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblNgayKK, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboNgayKK, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblGio, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 9);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(996, 23);
            this.tableLayoutPanel2.TabIndex = 29;
            // 
            // dtNgay
            // 
            this.dtNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgay.EditValue = null;
            this.dtNgay.Location = new System.Drawing.Point(3, 3);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay.Size = new System.Drawing.Size(155, 20);
            this.dtNgay.TabIndex = 28;
            this.dtNgay.Visible = false;
            // 
            // lblKho
            // 
            this.lblKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKho.Location = new System.Drawing.Point(164, 0);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(89, 23);
            this.lblKho.TabIndex = 27;
            this.lblKho.Text = "lblKho";
            this.lblKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtGio
            // 
            this.dtGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGio.EditValue = new System.DateTime(2017, 5, 3, 0, 0, 0, 0);
            this.dtGio.Enabled = false;
            this.dtGio.Location = new System.Drawing.Point(707, 3);
            this.dtGio.Name = "dtGio";
            this.dtGio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtGio.Size = new System.Drawing.Size(123, 20);
            this.dtGio.TabIndex = 30;
            // 
            // lblNgayKK
            // 
            this.lblNgayKK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayKK.Location = new System.Drawing.Point(388, 0);
            this.lblNgayKK.Name = "lblNgayKK";
            this.lblNgayKK.Size = new System.Drawing.Size(89, 23);
            this.lblNgayKK.TabIndex = 27;
            this.lblNgayKK.Text = "lblNgayKK";
            this.lblNgayKK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNgayKK
            // 
            this.cboNgayKK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNgayKK.Location = new System.Drawing.Point(483, 3);
            this.cboNgayKK.Name = "cboNgayKK";
            this.cboNgayKK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNgayKK.Properties.NullText = "";
            this.cboNgayKK.Size = new System.Drawing.Size(123, 20);
            this.cboNgayKK.TabIndex = 1;
            this.cboNgayKK.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboNgayKK_ButtonClick);
            this.cboNgayKK.EditValueChanged += new System.EventHandler(this.cboNgayKK_EditValueChanged);
            this.cboNgayKK.Click += new System.EventHandler(this.cboNgayKK_Click);
            // 
            // lblGio
            // 
            this.lblGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGio.Location = new System.Drawing.Point(612, 0);
            this.lblGio.Name = "lblGio";
            this.lblGio.Size = new System.Drawing.Size(89, 23);
            this.lblGio.TabIndex = 27;
            this.lblGio.Text = "lblGio";
            this.lblGio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckLock
            // 
            this.ckLock.Location = new System.Drawing.Point(3, 38);
            this.ckLock.Name = "ckLock";
            this.ckLock.Properties.Caption = "checkEdit1";
            this.ckLock.Size = new System.Drawing.Size(28, 18);
            this.ckLock.TabIndex = 31;
            this.ckLock.Visible = false;
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(3, 3);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(101, 1);
            this.grdChung.TabIndex = 31;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            this.grdChung.Visible = false;
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            // 
            // gridView3
            // 
            this.gridView3.Name = "gridView3";
            // 
            // frmKiemKeKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 527);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmKiemKeKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmKiemKeKho";
            this.Load += new System.EventHandler(this.frmKiemKeKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboKho.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChon)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNgayKK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckLock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LookUpEdit cboKho;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblKho;
        private System.Windows.Forms.Label lblNgayKK;
        private DevExpress.XtraEditors.LookUpEdit cboNgayKK;
        private System.Windows.Forms.Label lblGio;
        private DevExpress.XtraGrid.GridControl grdChon;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChon;
        private DevExpress.XtraEditors.DateEdit dtNgay;
        private DevExpress.XtraEditors.TimeEdit dtGio;
        internal DevExpress.XtraEditors.SimpleButton btnVideo;
        internal DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.CheckEdit ckLock;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnLock;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXemHinh;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnKhongGhi;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnTinhTon;
        private DevExpress.XtraEditors.SimpleButton btnCapNhatSL;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}