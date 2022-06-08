namespace ReportMain
{
    partial class frmInKHTT
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboDDiem = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.lblLMay = new System.Windows.Forms.Label();
            this.cboDChuyen = new DevExpress.XtraEditors.LookUpEdit();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblNhomMay = new System.Windows.Forms.Label();
            this.cboNhomMay = new DevExpress.XtraEditors.LookUpEdit();
            this.cboLoaiKH = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNam = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datNam = new ReportMain.MMonthYearEdit();
            this.datThang = new ReportMain.MMonthYearEdit();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblMSBP = new System.Windows.Forms.Label();
            this.txtMSBP = new DevExpress.XtraEditors.TextEdit();
            this.optBCao = new DevExpress.XtraEditors.RadioGroup();
            this.optTienDo = new DevExpress.XtraEditors.RadioGroup();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiKH.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datThang.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSBP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optBCao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optTienDo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.lblLoai, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboDDiem, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDDiem, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDChuyen, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLMay, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboDChuyen, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboLMay, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.prbIN, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblNhomMay, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cboNhomMay, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.cboLoaiKH, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNam, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblMSBP, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtMSBP, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.optBCao, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.optTienDo, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(741, 332);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 7;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 6);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel5.Controls.Add(this.btnThoat, 6, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnExecute, 5, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 295);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(735, 34);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ReportMain.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(628, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 28);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnExecute.Location = new System.Drawing.Point(518, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 28);
            this.btnExecute.TabIndex = 11;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblLoai
            // 
            this.lblLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoai.Location = new System.Drawing.Point(33, 15);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(104, 25);
            this.lblLoai.TabIndex = 9;
            this.lblLoai.Text = "lblLoai";
            this.lblLoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDDiem
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboDDiem, 3);
            this.cboDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDDiem.Location = new System.Drawing.Point(143, 43);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDDiem.Size = new System.Drawing.Size(563, 20);
            this.cboDDiem.TabIndex = 4;
            // 
            // lblDDiem
            // 
            this.lblDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDDiem.Location = new System.Drawing.Point(33, 40);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(104, 25);
            this.lblDDiem.TabIndex = 9;
            this.lblDDiem.Text = "lblDDiem";
            this.lblDDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDChuyen.Location = new System.Drawing.Point(33, 65);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(104, 25);
            this.lblDChuyen.TabIndex = 9;
            this.lblDChuyen.Text = "lblDChuyen";
            this.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLMay
            // 
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLMay.Location = new System.Drawing.Point(33, 90);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(104, 25);
            this.lblLMay.TabIndex = 9;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDChuyen
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboDChuyen, 3);
            this.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDChuyen.Location = new System.Drawing.Point(143, 68);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDChuyen.Size = new System.Drawing.Size(563, 20);
            this.cboDChuyen.TabIndex = 5;
            // 
            // cboLMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboLMay, 3);
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(143, 93);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Size = new System.Drawing.Size(563, 20);
            this.cboLMay.TabIndex = 6;
            this.cboLMay.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // prbIN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.prbIN, 6);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 271);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(735, 18);
            this.prbIN.TabIndex = 10;
            // 
            // lblNhomMay
            // 
            this.lblNhomMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhomMay.Location = new System.Drawing.Point(33, 115);
            this.lblNhomMay.Name = "lblNhomMay";
            this.lblNhomMay.Size = new System.Drawing.Size(104, 25);
            this.lblNhomMay.TabIndex = 9;
            this.lblNhomMay.Text = "lblNhomMay";
            this.lblNhomMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNhomMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboNhomMay, 3);
            this.cboNhomMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNhomMay.Location = new System.Drawing.Point(143, 118);
            this.cboNhomMay.Name = "cboNhomMay";
            this.cboNhomMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhomMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboNhomMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboNhomMay.Size = new System.Drawing.Size(563, 20);
            this.cboNhomMay.TabIndex = 7;
            // 
            // cboLoaiKH
            // 
            this.cboLoaiKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiKH.Location = new System.Drawing.Point(143, 18);
            this.cboLoaiKH.Name = "cboLoaiKH";
            this.cboLoaiKH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiKH.Size = new System.Drawing.Size(291, 20);
            this.cboLoaiKH.TabIndex = 1;
            this.cboLoaiKH.EditValueChanged += new System.EventHandler(this.cboLoaiKH_EditValueChanged);
            // 
            // lblNam
            // 
            this.lblNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNam.Location = new System.Drawing.Point(440, 15);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(68, 25);
            this.lblNam.TabIndex = 9;
            this.lblNam.Text = "lblNam";
            this.lblNam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.datNam);
            this.panel1.Controls.Add(this.datThang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(514, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 19);
            this.panel1.TabIndex = 23;
            // 
            // datNam
            // 
            this.datNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datNam.EditValue = null;
            this.datNam.Location = new System.Drawing.Point(0, 0);
            this.datNam.MMonthYear = true;
            this.datNam.Name = "datNam";
            this.datNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datNam.Properties.DisplayFormat.FormatString = "yyyy";
            this.datNam.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datNam.Properties.EditFormat.FormatString = "y";
            this.datNam.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datNam.Properties.Mask.EditMask = "yyyy";
            this.datNam.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datNam.Size = new System.Drawing.Size(192, 20);
            this.datNam.TabIndex = 2;
            // 
            // datThang
            // 
            this.datThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datThang.EditValue = null;
            this.datThang.Location = new System.Drawing.Point(0, 0);
            this.datThang.MMonthYear = true;
            this.datThang.Name = "datThang";
            this.datThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datThang.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.datThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datThang.Properties.EditFormat.FormatString = "MM/yyyy";
            this.datThang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datThang.Properties.Mask.EditMask = "MM/yyyy";
            this.datThang.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datThang.Size = new System.Drawing.Size(192, 20);
            this.datThang.TabIndex = 3;
            // 
            // grdChung
            // 
            this.grdChung.Location = new System.Drawing.Point(3, 93);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(24, 19);
            this.grdChung.TabIndex = 9;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            this.grdChung.Visible = false;
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsCustomization.AllowGroup = false;
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // lblMSBP
            // 
            this.lblMSBP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMSBP.Location = new System.Drawing.Point(33, 140);
            this.lblMSBP.Name = "lblMSBP";
            this.lblMSBP.Size = new System.Drawing.Size(104, 25);
            this.lblMSBP.TabIndex = 9;
            this.lblMSBP.Text = "lblNhomMay";
            this.lblMSBP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMSBP
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtMSBP, 3);
            this.txtMSBP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMSBP.Location = new System.Drawing.Point(143, 143);
            this.txtMSBP.Name = "txtMSBP";
            this.txtMSBP.Size = new System.Drawing.Size(563, 20);
            this.txtMSBP.TabIndex = 24;
            // 
            // optBCao
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.optBCao, 4);
            this.optBCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBCao.Location = new System.Drawing.Point(33, 196);
            this.optBCao.Name = "optBCao";
            this.optBCao.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optBCao.Properties.Appearance.Options.UseBackColor = true;
            this.optBCao.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optBCao.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "optAll"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "optChuaGiaiQuyet"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "optBoQua"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "optDaGiaiQuyet")});
            this.optBCao.Properties.LookAndFeel.SkinName = "Blue";
            this.optBCao.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.optBCao.Size = new System.Drawing.Size(673, 22);
            this.optBCao.TabIndex = 8;
            // 
            // optTienDo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.optTienDo, 4);
            this.optTienDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optTienDo.Location = new System.Drawing.Point(33, 168);
            this.optTienDo.Name = "optTienDo";
            this.optTienDo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optTienDo.Properties.Appearance.Options.UseBackColor = true;
            this.optTienDo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optTienDo.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "optTienDoCong"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "optTienDoChiPhi")});
            this.optTienDo.Properties.LookAndFeel.SkinName = "Blue";
            this.optTienDo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.optTienDo.Size = new System.Drawing.Size(673, 22);
            this.optTienDo.TabIndex = 8;
            // 
            // frmInKHTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 332);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmInKHTT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmInKHTT";
            this.Load += new System.EventHandler(this.frmInKHTT_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboDDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiKH.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datThang.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSBP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optBCao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optTienDo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private System.Windows.Forms.Label lblLoai;
        private DevExpress.XtraEditors.LookUpEdit cboDDiem;
        private System.Windows.Forms.Label lblDDiem;
        private System.Windows.Forms.Label lblDChuyen;
        private System.Windows.Forms.Label lblLMay;
        private DevExpress.XtraEditors.LookUpEdit cboDChuyen;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private System.Windows.Forms.Label lblNhomMay;
        private DevExpress.XtraEditors.LookUpEdit cboNhomMay;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiKH;
        private MMonthYearEdit datNam;
        private MMonthYearEdit datThang;
        private System.Windows.Forms.Label lblNam;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraEditors.RadioGroup optBCao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMSBP;
        private DevExpress.XtraEditors.TextEdit txtMSBP;
        private DevExpress.XtraEditors.RadioGroup optTienDo;
    }
}