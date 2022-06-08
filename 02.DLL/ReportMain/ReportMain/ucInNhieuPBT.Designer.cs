namespace ReportMain
{
    partial class frmInNhieuPBT
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.lblTKiem = new DevExpress.XtraEditors.LabelControl();
            this.btnALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotALL = new DevExpress.XtraEditors.SimpleButton();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.prbIN = new DevExpress.XtraEditors.ProgressBarControl();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdTmp = new DevExpress.XtraGrid.GridControl();
            this.grvTmp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTNgay = new System.Windows.Forms.Label();
            this.lblDNgay = new System.Windows.Forms.Label();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.cboDDiem = new MVControl.ucComboboxTreeList();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.cboDChuyen = new MVControl.ucComboboxTreeList();
            this.lblLMay = new System.Windows.Forms.Label();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNMay = new System.Windows.Forms.Label();
            this.cboNMay = new DevExpress.XtraEditors.LookUpEdit();
            this.grdPBT = new DevExpress.XtraGrid.GridControl();
            this.grvPBT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dateTNgay = new DevExpress.XtraEditors.DateEdit();
            this.dateDNgay = new DevExpress.XtraEditors.DateEdit();
            this.chkTTBT = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.lblTTBaoTri = new System.Windows.Forms.Label();
            this.lblTThai = new System.Windows.Forms.Label();
            this.cboTThai = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTTBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTThai.Properties)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.prbIN, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdTmp, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTNgay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDNgay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDDiem, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboDDiem, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDChuyen, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboDChuyen, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLMay, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboLMay, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNMay, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboNMay, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.grdPBT, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.dateTNgay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateDNgay, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkTTBT, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTTBaoTri, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTThai, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cboTThai, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 7);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.btnThoat, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnExecute, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTKiem, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnALL, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnNotALL, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTKiem, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 522);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(878, 36);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(771, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Location = new System.Drawing.Point(661, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 9;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblTKiem
            // 
            this.lblTKiem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTKiem.Location = new System.Drawing.Point(3, 3);
            this.lblTKiem.Name = "lblTKiem";
            this.lblTKiem.Size = new System.Drawing.Size(114, 30);
            this.lblTKiem.TabIndex = 27;
            this.lblTKiem.Text = "lblTKiem";
            // 
            // btnALL
            // 
            this.btnALL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALL.Appearance.Options.UseFont = true;
            this.btnALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnALL.Location = new System.Drawing.Point(303, 3);
            this.btnALL.LookAndFeel.SkinName = "Blue";
            this.btnALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(104, 30);
            this.btnALL.TabIndex = 7;
            this.btnALL.Text = "Chọn hết";
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // btnNotALL
            // 
            this.btnNotALL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotALL.Appearance.Options.UseFont = true;
            this.btnNotALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNotALL.Location = new System.Drawing.Point(413, 3);
            this.btnNotALL.LookAndFeel.SkinName = "Blue";
            this.btnNotALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNotALL.Name = "btnNotALL";
            this.btnNotALL.Size = new System.Drawing.Size(104, 30);
            this.btnNotALL.TabIndex = 8;
            this.btnNotALL.Text = "Bỏ chọn";
            this.btnNotALL.Click += new System.EventHandler(this.btnNotALL_Click);
            // 
            // txtTKiem
            // 
            this.txtTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTKiem.Location = new System.Drawing.Point(123, 13);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(174, 20);
            this.txtTKiem.TabIndex = 26;
            // 
            // prbIN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.prbIN, 6);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.Location = new System.Drawing.Point(3, 498);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.Maximum = 0;
            this.prbIN.Properties.Step = 1;
            this.prbIN.Size = new System.Drawing.Size(878, 18);
            this.prbIN.TabIndex = 19;
            // 
            // grdChung
            // 
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 11);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(126, 20);
            this.grdChung.TabIndex = 24;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            this.grdChung.Visible = false;
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvChung.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // grdTmp
            // 
            this.grdTmp.Location = new System.Drawing.Point(3, 37);
            this.grdTmp.LookAndFeel.SkinName = "Blue";
            this.grdTmp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdTmp.MainView = this.grvTmp;
            this.grdTmp.Name = "grdTmp";
            this.grdTmp.Size = new System.Drawing.Size(114, 20);
            this.grdTmp.TabIndex = 25;
            this.grdTmp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTmp});
            this.grdTmp.Visible = false;
            // 
            // grvTmp
            // 
            this.grvTmp.GridControl = this.grdTmp;
            this.grvTmp.Name = "grvTmp";
            this.grvTmp.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvTmp.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvTmp.OptionsView.ShowGroupPanel = false;
            // 
            // lblTNgay
            // 
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNgay.Location = new System.Drawing.Point(135, 8);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(100, 26);
            this.lblTNgay.TabIndex = 9;
            this.lblTNgay.Text = "lblTNgay";
            this.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDNgay
            // 
            this.lblDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNgay.Location = new System.Drawing.Point(444, 8);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(100, 26);
            this.lblDNgay.TabIndex = 9;
            this.lblDNgay.Text = "lblDNgay";
            this.lblDNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDDiem
            // 
            this.lblDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDDiem.Location = new System.Drawing.Point(135, 34);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(100, 26);
            this.lblDDiem.TabIndex = 9;
            this.lblDDiem.Text = "lblDDiem";
            this.lblDDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDDiem
            // 
            this.cboDDiem.ColumnDisplayName = null;
            this.cboDDiem.DataSource = null;
            this.cboDDiem.EditValue = null;
            this.cboDDiem.KeyFieldName = null;
            this.cboDDiem.Location = new System.Drawing.Point(241, 37);
            this.cboDDiem.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDDiem.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.ParentFieldName = null;
            this.cboDDiem.ReadOnly = false;
            this.cboDDiem.SelectedIndex = 0;
            this.cboDDiem.Size = new System.Drawing.Size(197, 20);
            this.cboDDiem.TabIndex = 5;
            this.cboDDiem.TextValue = null;
            this.cboDDiem.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDDiem_EditValueChanged);
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDChuyen.Location = new System.Drawing.Point(444, 34);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(100, 26);
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
            this.cboDChuyen.Location = new System.Drawing.Point(550, 37);
            this.cboDChuyen.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDChuyen.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.ParentFieldName = null;
            this.cboDChuyen.ReadOnly = false;
            this.cboDChuyen.SelectedIndex = 0;
            this.cboDChuyen.Size = new System.Drawing.Size(197, 20);
            this.cboDChuyen.TabIndex = 5;
            this.cboDChuyen.TextValue = null;
            this.cboDChuyen.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDChuyen_EditValueChanged);
            // 
            // lblLMay
            // 
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLMay.Location = new System.Drawing.Point(135, 60);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(100, 26);
            this.lblLMay.TabIndex = 9;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLMay
            // 
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(241, 63);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLMay.Size = new System.Drawing.Size(197, 20);
            this.cboLMay.TabIndex = 5;
            this.cboLMay.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // lblNMay
            // 
            this.lblNMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNMay.Location = new System.Drawing.Point(444, 60);
            this.lblNMay.Name = "lblNMay";
            this.lblNMay.Size = new System.Drawing.Size(100, 26);
            this.lblNMay.TabIndex = 9;
            this.lblNMay.Text = "lblNMay";
            this.lblNMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNMay
            // 
            this.cboNMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNMay.Location = new System.Drawing.Point(550, 63);
            this.cboNMay.Name = "cboNMay";
            this.cboNMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboNMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboNMay.Size = new System.Drawing.Size(197, 20);
            this.cboNMay.TabIndex = 5;
            this.cboNMay.EditValueChanged += new System.EventHandler(this.cboNMay_EditValueChanged);
            // 
            // grdPBT
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdPBT, 6);
            this.grdPBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPBT.Location = new System.Drawing.Point(3, 143);
            this.grdPBT.LookAndFeel.SkinName = "Blue";
            this.grdPBT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdPBT.MainView = this.grvPBT;
            this.grdPBT.Name = "grdPBT";
            this.grdPBT.Size = new System.Drawing.Size(878, 349);
            this.grdPBT.TabIndex = 25;
            this.grdPBT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPBT});
            // 
            // grvPBT
            // 
            this.grvPBT.GridControl = this.grdPBT;
            this.grvPBT.Name = "grvPBT";
            this.grvPBT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvPBT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvPBT.OptionsView.ShowGroupPanel = false;
            // 
            // dateTNgay
            // 
            this.dateTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTNgay.EditValue = null;
            this.dateTNgay.Location = new System.Drawing.Point(241, 11);
            this.dateTNgay.Name = "dateTNgay";
            this.dateTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateTNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateTNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.dateTNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dateTNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateTNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateTNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTNgay.Size = new System.Drawing.Size(197, 20);
            this.dateTNgay.TabIndex = 27;
            this.dateTNgay.EditValueChanged += new System.EventHandler(this.dateTNgay_EditValueChanged);
            // 
            // dateDNgay
            // 
            this.dateDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateDNgay.EditValue = null;
            this.dateDNgay.Location = new System.Drawing.Point(550, 11);
            this.dateDNgay.Name = "dateDNgay";
            this.dateDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateDNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateDNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateDNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateDNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.dateDNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dateDNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateDNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateDNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateDNgay.Size = new System.Drawing.Size(197, 20);
            this.dateDNgay.TabIndex = 27;
            this.dateDNgay.EditValueChanged += new System.EventHandler(this.dateDNgay_EditValueChanged);
            // 
            // chkTTBT
            // 
            this.chkTTBT.Appearance.BackColor = System.Drawing.Color.White;
            this.chkTTBT.Appearance.Options.UseBackColor = true;
            this.chkTTBT.Appearance.Options.UseTextOptions = true;
            this.chkTTBT.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tableLayoutPanel1.SetColumnSpan(this.chkTTBT, 3);
            this.chkTTBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTTBT.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "chkDSoan"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "chkDThucHien"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "chkHThanh"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "chkDNThu"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "chkDKhoa")});
            this.chkTTBT.Location = new System.Drawing.Point(241, 89);
            this.chkTTBT.LookAndFeel.SkinName = "Blue";
            this.chkTTBT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkTTBT.MultiColumn = true;
            this.chkTTBT.Name = "chkTTBT";
            this.chkTTBT.Size = new System.Drawing.Size(506, 22);
            this.chkTTBT.TabIndex = 29;
            // 
            // lblTTBaoTri
            // 
            this.lblTTBaoTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTTBaoTri.Location = new System.Drawing.Point(135, 86);
            this.lblTTBaoTri.Name = "lblTTBaoTri";
            this.lblTTBaoTri.Size = new System.Drawing.Size(100, 28);
            this.lblTTBaoTri.TabIndex = 28;
            this.lblTTBaoTri.Text = "lblTTBTri";
            this.lblTTBaoTri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTThai
            // 
            this.lblTThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTThai.Location = new System.Drawing.Point(135, 114);
            this.lblTThai.Name = "lblTThai";
            this.lblTThai.Size = new System.Drawing.Size(100, 26);
            this.lblTThai.TabIndex = 9;
            this.lblTThai.Text = "lblTThai";
            this.lblTThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTThai
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboTThai, 3);
            this.cboTThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTThai.Location = new System.Drawing.Point(241, 117);
            this.cboTThai.Name = "cboTThai";
            this.cboTThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTThai.Properties.LookAndFeel.SkinName = "Blue";
            this.cboTThai.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboTThai.Size = new System.Drawing.Size(506, 20);
            this.cboTThai.TabIndex = 26;
            // 
            // frmInNhieuPBT
            // 
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmInNhieuPBT";
            this.Load += new System.EventHandler(this.ucInNhieuPBT_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPBT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPBT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTTBT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTThai.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTNgay;
        private MVControl.ucComboboxTreeList cboDDiem;
        private System.Windows.Forms.Label lblDDiem;
        private System.Windows.Forms.Label lblDChuyen;
        private System.Windows.Forms.Label lblLMay;
       private MVControl.ucComboboxTreeList cboDChuyen;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
        private DevExpress.XtraEditors.ProgressBarControl prbIN;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraGrid.GridControl grdTmp;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTmp;
        private System.Windows.Forms.Label lblDNgay;
        private System.Windows.Forms.Label lblNMay;
        private DevExpress.XtraEditors.LookUpEdit cboNMay;
        private DevExpress.XtraGrid.GridControl grdPBT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPBT;
        private System.Windows.Forms.Label lblTThai;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboTThai;
        private DevExpress.XtraEditors.DateEdit dateTNgay;
        private DevExpress.XtraEditors.DateEdit dateDNgay;
        private DevExpress.XtraEditors.CheckedListBoxControl chkTTBT;
        private System.Windows.Forms.Label lblTTBaoTri;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.LabelControl lblTKiem;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private DevExpress.XtraEditors.SimpleButton btnALL;
        private DevExpress.XtraEditors.SimpleButton btnNotALL;
    }
}
