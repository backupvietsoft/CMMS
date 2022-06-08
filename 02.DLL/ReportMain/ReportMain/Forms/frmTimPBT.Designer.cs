namespace ReportMain
{
    partial class frmTimPBT
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
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.cboNNhan = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNNhan = new System.Windows.Forms.Label();
            this.cboNGSat = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNGSat = new System.Windows.Forms.Label();
            this.cboNLap = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNguoiLap = new System.Windows.Forms.Label();
            this.cboLBTri = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLBTri = new System.Windows.Forms.Label();
            this.cboMay = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMay = new System.Windows.Forms.Label();
            this.cboNhomMay = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNhomMay = new System.Windows.Forms.Label();
            this.lblLMay = new System.Windows.Forms.Label();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDChuyen = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.cboDDiem = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.datDNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblDNgay = new System.Windows.Forms.Label();
            this.lblTNgay = new System.Windows.Forms.Label();
            this.datTNgay = new DevExpress.XtraEditors.DateEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNGSat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNLap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLBTri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 6);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel5.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnExecute, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 154);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(581, 32);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ReportMain.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(488, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 26);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnExecute.Location = new System.Drawing.Point(392, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(90, 26);
            this.btnExecute.TabIndex = 14;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cboNNhan
            // 
            this.cboNNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNNhan.Location = new System.Drawing.Point(396, 111);
            this.cboNNhan.Name = "cboNNhan";
            this.cboNNhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNNhan.Properties.LookAndFeel.SkinName = "Blue";
            this.cboNNhan.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboNNhan.Size = new System.Drawing.Size(177, 20);
            this.cboNNhan.TabIndex = 9;
            // 
            // lblNNhan
            // 
            this.lblNNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNNhan.Location = new System.Drawing.Point(296, 108);
            this.lblNNhan.Name = "lblNNhan";
            this.lblNNhan.Size = new System.Drawing.Size(94, 25);
            this.lblNNhan.TabIndex = 9;
            this.lblNNhan.Text = "lblNNhan";
            this.lblNNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNGSat
            // 
            this.cboNGSat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNGSat.Location = new System.Drawing.Point(113, 111);
            this.cboNGSat.Name = "cboNGSat";
            this.cboNGSat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNGSat.Properties.LookAndFeel.SkinName = "Blue";
            this.cboNGSat.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboNGSat.Size = new System.Drawing.Size(177, 20);
            this.cboNGSat.TabIndex = 9;
            // 
            // lblNGSat
            // 
            this.lblNGSat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNGSat.Location = new System.Drawing.Point(13, 108);
            this.lblNGSat.Name = "lblNGSat";
            this.lblNGSat.Size = new System.Drawing.Size(94, 25);
            this.lblNGSat.TabIndex = 9;
            this.lblNGSat.Text = "lblNGSat";
            this.lblNGSat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNLap
            // 
            this.cboNLap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNLap.Location = new System.Drawing.Point(396, 86);
            this.cboNLap.Name = "cboNLap";
            this.cboNLap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNLap.Properties.LookAndFeel.SkinName = "Blue";
            this.cboNLap.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboNLap.Size = new System.Drawing.Size(177, 20);
            this.cboNLap.TabIndex = 9;
            // 
            // lblNguoiLap
            // 
            this.lblNguoiLap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNguoiLap.Location = new System.Drawing.Point(296, 83);
            this.lblNguoiLap.Name = "lblNguoiLap";
            this.lblNguoiLap.Size = new System.Drawing.Size(94, 25);
            this.lblNguoiLap.TabIndex = 9;
            this.lblNguoiLap.Text = "lblNguoiLap";
            this.lblNguoiLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLBTri
            // 
            this.cboLBTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLBTri.Location = new System.Drawing.Point(113, 86);
            this.cboLBTri.Name = "cboLBTri";
            this.cboLBTri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLBTri.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLBTri.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLBTri.Size = new System.Drawing.Size(177, 20);
            this.cboLBTri.TabIndex = 9;
            // 
            // lblLBTri
            // 
            this.lblLBTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLBTri.Location = new System.Drawing.Point(13, 83);
            this.lblLBTri.Name = "lblLBTri";
            this.lblLBTri.Size = new System.Drawing.Size(94, 25);
            this.lblLBTri.TabIndex = 9;
            this.lblLBTri.Text = "lblMay";
            this.lblLBTri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMay
            // 
            this.cboMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMay.Location = new System.Drawing.Point(396, 61);
            this.cboMay.Name = "cboMay";
            this.cboMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboMay.Size = new System.Drawing.Size(177, 20);
            this.cboMay.TabIndex = 9;
            // 
            // lblMay
            // 
            this.lblMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMay.Location = new System.Drawing.Point(296, 58);
            this.lblMay.Name = "lblMay";
            this.lblMay.Size = new System.Drawing.Size(94, 25);
            this.lblMay.TabIndex = 9;
            this.lblMay.Text = "lblMay";
            this.lblMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNhomMay
            // 
            this.cboNhomMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNhomMay.Location = new System.Drawing.Point(113, 61);
            this.cboNhomMay.Name = "cboNhomMay";
            this.cboNhomMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhomMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboNhomMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboNhomMay.Size = new System.Drawing.Size(177, 20);
            this.cboNhomMay.TabIndex = 9;
            this.cboNhomMay.EditValueChanged += new System.EventHandler(this.cboNhomMay_EditValueChanged);
            // 
            // lblNhomMay
            // 
            this.lblNhomMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhomMay.Location = new System.Drawing.Point(13, 58);
            this.lblNhomMay.Name = "lblNhomMay";
            this.lblNhomMay.Size = new System.Drawing.Size(94, 25);
            this.lblNhomMay.TabIndex = 9;
            this.lblNhomMay.Text = "lblNhomMay";
            this.lblNhomMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLMay
            // 
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLMay.Location = new System.Drawing.Point(296, 33);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(94, 25);
            this.lblLMay.TabIndex = 9;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLMay
            // 
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(396, 36);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Size = new System.Drawing.Size(177, 20);
            this.cboLMay.TabIndex = 8;
            this.cboLMay.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // cboDChuyen
            // 
            this.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDChuyen.Location = new System.Drawing.Point(113, 36);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDChuyen.Size = new System.Drawing.Size(177, 20);
            this.cboDChuyen.TabIndex = 7;
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDChuyen.Location = new System.Drawing.Point(13, 33);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(94, 25);
            this.lblDChuyen.TabIndex = 9;
            this.lblDChuyen.Text = "lblDChuyen";
            this.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDDiem
            // 
            this.cboDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDDiem.Location = new System.Drawing.Point(113, 136);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDDiem.Size = new System.Drawing.Size(177, 20);
            this.cboDDiem.TabIndex = 6;
            // 
            // lblDDiem
            // 
            this.lblDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDDiem.Location = new System.Drawing.Point(13, 133);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(94, 18);
            this.lblDDiem.TabIndex = 9;
            this.lblDDiem.Text = "lblDDiem";
            this.lblDDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datDNgay
            // 
            this.datDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datDNgay.EditValue = null;
            this.datDNgay.Location = new System.Drawing.Point(396, 11);
            this.datDNgay.Name = "datDNgay";
            this.datDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datDNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datDNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datDNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.datDNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datDNgay.Size = new System.Drawing.Size(177, 20);
            this.datDNgay.TabIndex = 2;
            // 
            // lblDNgay
            // 
            this.lblDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNgay.Location = new System.Drawing.Point(296, 8);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(94, 25);
            this.lblDNgay.TabIndex = 10;
            this.lblDNgay.Text = "lblDNgay";
            this.lblDNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTNgay
            // 
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNgay.Location = new System.Drawing.Point(13, 8);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(94, 25);
            this.lblTNgay.TabIndex = 9;
            this.lblTNgay.Text = "lblTNgay";
            this.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datTNgay
            // 
            this.datTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(113, 11);
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datTNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datTNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datTNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.datTNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datTNgay.Size = new System.Drawing.Size(177, 20);
            this.datTNgay.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.datTNgay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTNgay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDNgay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.datDNgay, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDChuyen, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboDChuyen, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboLMay, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLMay, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNhomMay, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboNhomMay, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMay, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboMay, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLBTri, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboLBTri, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblNguoiLap, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboNLap, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblNGSat, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cboNGSat, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblNNhan, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.cboNNhan, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblDDiem, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cboDDiem, 2, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(587, 189);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // frmTimPBT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 189);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimPBT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimPBT";
            this.Load += new System.EventHandler(this.frmTimPBT_Load);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboNNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNGSat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNLap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLBTri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.DateEdit datTNgay;
        private System.Windows.Forms.Label lblTNgay;
        private System.Windows.Forms.Label lblDNgay;
        private DevExpress.XtraEditors.DateEdit datDNgay;
        private System.Windows.Forms.Label lblDChuyen;
        private DevExpress.XtraEditors.LookUpEdit cboDChuyen;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
        private System.Windows.Forms.Label lblLMay;
        private System.Windows.Forms.Label lblNhomMay;
        private DevExpress.XtraEditors.LookUpEdit cboNhomMay;
        private System.Windows.Forms.Label lblMay;
        private DevExpress.XtraEditors.LookUpEdit cboMay;
        private System.Windows.Forms.Label lblLBTri;
        private DevExpress.XtraEditors.LookUpEdit cboLBTri;
        private System.Windows.Forms.Label lblNguoiLap;
        private DevExpress.XtraEditors.LookUpEdit cboNLap;
        private System.Windows.Forms.Label lblNGSat;
        private DevExpress.XtraEditors.LookUpEdit cboNGSat;
        private System.Windows.Forms.Label lblNNhan;
        private DevExpress.XtraEditors.LookUpEdit cboNNhan;
        private System.Windows.Forms.Label lblDDiem;
        private DevExpress.XtraEditors.LookUpEdit cboDDiem;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
    }
}