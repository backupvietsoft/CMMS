namespace MVControl
{
    partial class frmChonThongSoGSTTDinhLuong
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtTimKiem = new DevExpress.XtraEditors.TextEdit();
            this.BtnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.BtnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.dtNgay = new DevExpress.XtraEditors.DateEdit();
            this.SplitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdDS = new DevExpress.XtraGrid.GridControl();
            this.grvDS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdDSGiaTri = new DevExpress.XtraGrid.GridControl();
            this.grvDSGiaTri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkHangmucdenhangGS = new System.Windows.Forms.RadioButton();
            this.cboThongsogiamsat = new DevExpress.XtraEditors.LookUpEdit();
            this.chkTatCa = new System.Windows.Forms.RadioButton();
            this.lblThongsogiamsat = new System.Windows.Forms.Label();
            this.lblThietbi = new System.Windows.Forms.Label();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.cboThietbi = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLoaithietbi = new System.Windows.Forms.Label();
            this.lblNhaXuong = new System.Windows.Forms.Label();
            this.lblHThong = new System.Windows.Forms.Label();
            this.cboDDiem = new MVControl.ucComboboxTreeList();
            this.cboDChuyen = new MVControl.ucComboboxTreeList();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1)).BeginInit();
            this.SplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSGiaTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDSGiaTri)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboThongsogiamsat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietbi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.Panel1, 7);
            this.Panel1.Controls.Add(this.txtTimKiem);
            this.Panel1.Controls.Add(this.BtnThoat);
            this.Panel1.Controls.Add(this.BtnThucHien);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 425);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(806, 34);
            this.Panel1.TabIndex = 99;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimKiem.Location = new System.Drawing.Point(0, 11);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtTimKiem.Properties.Appearance.Options.UseBackColor = true;
            this.txtTimKiem.Size = new System.Drawing.Size(153, 20);
            this.txtTimKiem.TabIndex = 98;
            this.txtTimKiem.EditValueChanged += new System.EventHandler(this.txtTimKiem_EditValueChanged);
            // 
            // BtnThoat
            // 
            this.BtnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnThoat.Location = new System.Drawing.Point(700, 4);
            this.BtnThoat.Name = "BtnThoat";
            this.BtnThoat.Size = new System.Drawing.Size(104, 30);
            this.BtnThoat.TabIndex = 97;
            this.BtnThoat.Text = "Thoát";
            this.BtnThoat.Click += new System.EventHandler(this.BtnThoat_Click);
            // 
            // BtnThucHien
            // 
            this.BtnThucHien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnThucHien.Location = new System.Drawing.Point(595, 4);
            this.BtnThucHien.LookAndFeel.SkinName = "Blue";
            this.BtnThucHien.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnThucHien.Name = "BtnThucHien";
            this.BtnThucHien.Size = new System.Drawing.Size(104, 30);
            this.BtnThucHien.TabIndex = 96;
            this.BtnThucHien.Text = "Thực hiện";
            this.BtnThucHien.Click += new System.EventHandler(this.BtnThucHien_Click);
            // 
            // dtNgay
            // 
            this.dtNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgay.EditValue = new System.DateTime(2017, 1, 12, 13, 47, 0, 172);
            this.dtNgay.Enabled = false;
            this.dtNgay.Location = new System.Drawing.Point(617, 61);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Properties.Appearance.Options.UseFont = true;
            this.dtNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.dtNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtNgay.Properties.ShowWeekNumbers = true;
            this.dtNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgay.Size = new System.Drawing.Size(92, 20);
            this.dtNgay.TabIndex = 45;
            this.dtNgay.EditValueChanged += new System.EventHandler(this.dtNgay_EditValueChanged);
            // 
            // SplitContainerControl1
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.SplitContainerControl1, 7);
            this.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.SplitContainerControl1.Location = new System.Drawing.Point(3, 90);
            this.SplitContainerControl1.Name = "SplitContainerControl1";
            this.SplitContainerControl1.Panel1.Controls.Add(this.grdDS);
            this.SplitContainerControl1.Panel1.Text = "Panel1";
            this.SplitContainerControl1.Panel2.Controls.Add(this.grdDSGiaTri);
            this.SplitContainerControl1.Panel2.Text = "Panel2";
            this.SplitContainerControl1.Size = new System.Drawing.Size(806, 329);
            this.SplitContainerControl1.SplitterPosition = 432;
            this.SplitContainerControl1.TabIndex = 106;
            this.SplitContainerControl1.Text = "SplitContainerControl1";
            // 
            // grdDS
            // 
            this.grdDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDS.Location = new System.Drawing.Point(0, 0);
            this.grdDS.LookAndFeel.SkinName = "Blue";
            this.grdDS.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdDS.MainView = this.grvDS;
            this.grdDS.Name = "grdDS";
            this.grdDS.Size = new System.Drawing.Size(432, 329);
            this.grdDS.TabIndex = 3;
            this.grdDS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDS});
            // 
            // grvDS
            // 
            this.grvDS.GridControl = this.grdDS;
            this.grvDS.Name = "grvDS";
            this.grvDS.OptionsView.ShowGroupPanel = false;
            this.grvDS.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvDS_FocusedRowChanged);
            this.grvDS.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvDS_ValidateRow_1);
            this.grvDS.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvDS_ValidatingEditor);
            // 
            // grdDSGiaTri
            // 
            this.grdDSGiaTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDSGiaTri.Location = new System.Drawing.Point(0, 0);
            this.grdDSGiaTri.LookAndFeel.SkinName = "Blue";
            this.grdDSGiaTri.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdDSGiaTri.MainView = this.grvDSGiaTri;
            this.grdDSGiaTri.Name = "grdDSGiaTri";
            this.grdDSGiaTri.Size = new System.Drawing.Size(368, 329);
            this.grdDSGiaTri.TabIndex = 2;
            this.grdDSGiaTri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDSGiaTri});
            // 
            // grvDSGiaTri
            // 
            this.grvDSGiaTri.GridControl = this.grdDSGiaTri;
            this.grvDSGiaTri.Name = "grvDSGiaTri";
            this.grvDSGiaTri.OptionsView.ShowGroupPanel = false;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 7;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableLayoutPanel1.Controls.Add(this.dtNgay, 5, 3);
            this.TableLayoutPanel1.Controls.Add(this.chkHangmucdenhangGS, 4, 3);
            this.TableLayoutPanel1.Controls.Add(this.cboThongsogiamsat, 2, 3);
            this.TableLayoutPanel1.Controls.Add(this.chkTatCa, 3, 3);
            this.TableLayoutPanel1.Controls.Add(this.lblThongsogiamsat, 1, 3);
            this.TableLayoutPanel1.Controls.Add(this.SplitContainerControl1, 0, 5);
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 6);
            this.TableLayoutPanel1.Controls.Add(this.lblThietbi, 3, 2);
            this.TableLayoutPanel1.Controls.Add(this.cboLMay, 2, 2);
            this.TableLayoutPanel1.Controls.Add(this.cboThietbi, 4, 2);
            this.TableLayoutPanel1.Controls.Add(this.lblLoaithietbi, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.lblNhaXuong, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.lblHThong, 3, 1);
            this.TableLayoutPanel1.Controls.Add(this.cboDDiem, 2, 1);
            this.TableLayoutPanel1.Controls.Add(this.cboDChuyen, 4, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 7;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(812, 462);
            this.TableLayoutPanel1.TabIndex = 100;
            // 
            // chkHangmucdenhangGS
            // 
            this.chkHangmucdenhangGS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkHangmucdenhangGS.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkHangmucdenhangGS.Location = new System.Drawing.Point(519, 61);
            this.chkHangmucdenhangGS.Name = "chkHangmucdenhangGS";
            this.chkHangmucdenhangGS.Size = new System.Drawing.Size(92, 19);
            this.chkHangmucdenhangGS.TabIndex = 43;
            this.chkHangmucdenhangGS.Text = "Hạng mục đến hạn giám sát";
            this.chkHangmucdenhangGS.UseVisualStyleBackColor = true;
            this.chkHangmucdenhangGS.CheckedChanged += new System.EventHandler(this.chkHangmucdenhangGS_CheckedChanged);
            // 
            // cboThongsogiamsat
            // 
            this.cboThongsogiamsat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboThongsogiamsat.Location = new System.Drawing.Point(213, 61);
            this.cboThongsogiamsat.Name = "cboThongsogiamsat";
            this.cboThongsogiamsat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboThongsogiamsat.Properties.LookAndFeel.SkinName = "Blue";
            this.cboThongsogiamsat.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboThongsogiamsat.Properties.NullText = "";
            this.cboThongsogiamsat.Size = new System.Drawing.Size(190, 20);
            this.cboThongsogiamsat.TabIndex = 29;
            this.cboThongsogiamsat.EditValueChanged += new System.EventHandler(this.cboThongsogiamsat_EditValueChanged);
            // 
            // chkTatCa
            // 
            this.chkTatCa.Checked = true;
            this.chkTatCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTatCa.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkTatCa.Location = new System.Drawing.Point(409, 61);
            this.chkTatCa.Name = "chkTatCa";
            this.chkTatCa.Size = new System.Drawing.Size(104, 19);
            this.chkTatCa.TabIndex = 44;
            this.chkTatCa.TabStop = true;
            this.chkTatCa.Text = "Tất cả";
            this.chkTatCa.UseVisualStyleBackColor = true;
            // 
            // lblThongsogiamsat
            // 
            this.lblThongsogiamsat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThongsogiamsat.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblThongsogiamsat.ForeColor = System.Drawing.Color.Black;
            this.lblThongsogiamsat.Location = new System.Drawing.Point(103, 58);
            this.lblThongsogiamsat.Name = "lblThongsogiamsat";
            this.lblThongsogiamsat.Size = new System.Drawing.Size(104, 25);
            this.lblThongsogiamsat.TabIndex = 27;
            this.lblThongsogiamsat.Text = "Thông số giám sát ";
            this.lblThongsogiamsat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThietbi
            // 
            this.lblThietbi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThietbi.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblThietbi.ForeColor = System.Drawing.Color.Black;
            this.lblThietbi.Location = new System.Drawing.Point(409, 33);
            this.lblThietbi.Name = "lblThietbi";
            this.lblThietbi.Size = new System.Drawing.Size(104, 25);
            this.lblThietbi.TabIndex = 27;
            this.lblThietbi.Text = "Thiết bị ";
            this.lblThietbi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLMay
            // 
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(213, 36);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLMay.Properties.NullText = "";
            this.cboLMay.Size = new System.Drawing.Size(190, 20);
            this.cboLMay.TabIndex = 23;
            this.cboLMay.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // cboThietbi
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.cboThietbi, 2);
            this.cboThietbi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboThietbi.Location = new System.Drawing.Point(519, 36);
            this.cboThietbi.Name = "cboThietbi";
            this.cboThietbi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboThietbi.Properties.LookAndFeel.SkinName = "Blue";
            this.cboThietbi.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboThietbi.Properties.NullText = "";
            this.cboThietbi.Size = new System.Drawing.Size(190, 20);
            this.cboThietbi.TabIndex = 30;
            this.cboThietbi.EditValueChanged += new System.EventHandler(this.cboThietbi_EditValueChanged);
            // 
            // lblLoaithietbi
            // 
            this.lblLoaithietbi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaithietbi.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblLoaithietbi.ForeColor = System.Drawing.Color.Black;
            this.lblLoaithietbi.Location = new System.Drawing.Point(103, 33);
            this.lblLoaithietbi.Name = "lblLoaithietbi";
            this.lblLoaithietbi.Size = new System.Drawing.Size(104, 25);
            this.lblLoaithietbi.TabIndex = 21;
            this.lblLoaithietbi.Text = "Loại thiết bị";
            this.lblLoaithietbi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNhaXuong
            // 
            this.lblNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhaXuong.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblNhaXuong.ForeColor = System.Drawing.Color.Black;
            this.lblNhaXuong.Location = new System.Drawing.Point(103, 8);
            this.lblNhaXuong.Name = "lblNhaXuong";
            this.lblNhaXuong.Size = new System.Drawing.Size(104, 25);
            this.lblNhaXuong.TabIndex = 21;
            this.lblNhaXuong.Text = "lblNhaXuong";
            this.lblNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHThong
            // 
            this.lblHThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHThong.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblHThong.ForeColor = System.Drawing.Color.Black;
            this.lblHThong.Location = new System.Drawing.Point(409, 8);
            this.lblHThong.Name = "lblHThong";
            this.lblHThong.Size = new System.Drawing.Size(104, 25);
            this.lblHThong.TabIndex = 21;
            this.lblHThong.Text = "lblHThong";
            this.lblHThong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDDiem
            // 
            this.cboDDiem.ColumnDisplayName = null;
            this.cboDDiem.DataSource = null;
            this.cboDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDDiem.EditValue = null;
            this.cboDDiem.KeyFieldName = null;
            this.cboDDiem.Location = new System.Drawing.Point(213, 11);
            this.cboDDiem.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDDiem.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.ParentFieldName = null;
            this.cboDDiem.ReadOnly = false;
            this.cboDDiem.SelectedIndex = 0;
            this.cboDDiem.Size = new System.Drawing.Size(190, 20);
            this.cboDDiem.TabIndex = 107;
            this.cboDDiem.TextValue = null;
            this.cboDDiem.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDDiem_EditValuedChanged);
            // 
            // cboDChuyen
            // 
            this.cboDChuyen.ColumnDisplayName = null;
            this.TableLayoutPanel1.SetColumnSpan(this.cboDChuyen, 2);
            this.cboDChuyen.DataSource = null;
            this.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDChuyen.EditValue = null;
            this.cboDChuyen.KeyFieldName = null;
            this.cboDChuyen.Location = new System.Drawing.Point(519, 11);
            this.cboDChuyen.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDChuyen.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.ParentFieldName = null;
            this.cboDChuyen.ReadOnly = false;
            this.cboDChuyen.SelectedIndex = 0;
            this.cboDChuyen.Size = new System.Drawing.Size(190, 20);
            this.cboDChuyen.TabIndex = 107;
            this.cboDChuyen.TextValue = null;
            this.cboDChuyen.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDChuyen_EditValuedChanged);
            // 
            // frmChonThongSoGSTTDinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 462);
            this.Controls.Add(this.TableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChonThongSoGSTTDinhLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChonThongSoGSTTDinhLuong";
            this.Load += new System.EventHandler(this.frmChonThongSoGSTTDinhLuong_Load);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1)).EndInit();
            this.SplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSGiaTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDSGiaTri)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboThongsogiamsat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietbi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal DevExpress.XtraEditors.DateEdit dtNgay;
        internal System.Windows.Forms.RadioButton chkHangmucdenhangGS;
        internal DevExpress.XtraEditors.LookUpEdit cboThongsogiamsat;
        internal System.Windows.Forms.RadioButton chkTatCa;
        internal System.Windows.Forms.Label lblThongsogiamsat;
        internal DevExpress.XtraEditors.SplitContainerControl SplitContainerControl1;
        internal System.Windows.Forms.Label lblThietbi;
        internal DevExpress.XtraEditors.LookUpEdit cboLMay;
        internal DevExpress.XtraEditors.LookUpEdit cboThietbi;
        internal System.Windows.Forms.Label lblLoaithietbi;
        internal DevExpress.XtraEditors.SimpleButton BtnThoat;
        internal DevExpress.XtraEditors.SimpleButton BtnThucHien;
        private DevExpress.XtraGrid.GridControl grdDS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDS;
        private DevExpress.XtraGrid.GridControl grdDSGiaTri;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDSGiaTri;
        internal System.Windows.Forms.Label lblNhaXuong;
        internal System.Windows.Forms.Label lblHThong;
        private MVControl.ucComboboxTreeList cboDDiem;
        private MVControl.ucComboboxTreeList cboDChuyen;
        private DevExpress.XtraEditors.TextEdit txtTimKiem;
    }
}