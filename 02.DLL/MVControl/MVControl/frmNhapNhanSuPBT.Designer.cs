namespace MVControl
{
    partial class frmNhapNhanSuPBT
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
            this.cboLBTri = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLBaoTri = new System.Windows.Forms.Label();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDChuyen = new MVControl.ucComboboxTreeList();
            this.lblLMay = new System.Windows.Forms.Label();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.cboDDiem = new MVControl.ucComboboxTreeList();
            this.datDNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblDNgay = new System.Windows.Forms.Label();
            this.grpMay = new DevExpress.XtraEditors.GroupControl();
            this.grdBT = new DevExpress.XtraGrid.GridControl();
            this.grvBT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTNgay = new System.Windows.Forms.Label();
            this.datTNgay = new DevExpress.XtraEditors.DateEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.btnNotALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnChonNS = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboLBTri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMay)).BeginInit();
            this.grpMay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLBTri
            // 
            this.cboLBTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLBTri.Location = new System.Drawing.Point(582, 68);
            this.cboLBTri.Name = "cboLBTri";
            this.cboLBTri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLBTri.Properties.NullText = "";
            this.cboLBTri.Size = new System.Drawing.Size(209, 20);
            this.cboLBTri.TabIndex = 5;
            this.cboLBTri.EditValueChanged += new System.EventHandler(this.cboLBTri_EditValueChanged);
            // 
            // lblLBaoTri
            // 
            this.lblLBaoTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLBaoTri.Location = new System.Drawing.Point(470, 65);
            this.lblLBaoTri.Name = "lblLBaoTri";
            this.lblLBaoTri.Size = new System.Drawing.Size(106, 25);
            this.lblLBaoTri.TabIndex = 9;
            this.lblLBaoTri.Text = "lblLBaoTri";
            this.lblLBaoTri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLMay
            // 
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(255, 68);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Properties.NullText = "";
            this.cboLMay.Size = new System.Drawing.Size(209, 20);
            this.cboLMay.TabIndex = 5;
            this.cboLMay.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // cboDChuyen
            // 
            this.cboDChuyen.ColumnDisplayName = null;
            this.cboDChuyen.DataSource = null;
            this.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDChuyen.EditValue = null;
            this.cboDChuyen.KeyFieldName = null;
            this.cboDChuyen.Location = new System.Drawing.Point(583, 44);
            this.cboDChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.cboDChuyen.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDChuyen.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDChuyen.Name = "cboDChuyen";
            this.cboDChuyen.ParentFieldName = null;
            this.cboDChuyen.ReadOnly = false;
            this.cboDChuyen.SelectedIndex = 0;
            this.cboDChuyen.Size = new System.Drawing.Size(207, 20);
            this.cboDChuyen.TabIndex = 5;
            this.cboDChuyen.TextValue = null;
            this.cboDChuyen.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDChuyen_EditValuedChanged);
            // 
            // lblLMay
            // 
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLMay.Location = new System.Drawing.Point(143, 65);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(106, 25);
            this.lblLMay.TabIndex = 9;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDChuyen.Location = new System.Drawing.Point(470, 40);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(106, 25);
            this.lblDChuyen.TabIndex = 9;
            this.lblDChuyen.Text = "lblDChuyen";
            this.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDDiem
            // 
            this.lblDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDDiem.Location = new System.Drawing.Point(143, 40);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(106, 25);
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
            this.cboDDiem.Location = new System.Drawing.Point(256, 44);
            this.cboDDiem.Margin = new System.Windows.Forms.Padding(4);
            this.cboDDiem.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cboDDiem.MinimumSize = new System.Drawing.Size(10, 20);
            this.cboDDiem.Name = "cboDDiem";
            this.cboDDiem.ParentFieldName = null;
            this.cboDDiem.ReadOnly = false;
            this.cboDDiem.SelectedIndex = 0;
            this.cboDDiem.Size = new System.Drawing.Size(207, 20);
            this.cboDDiem.TabIndex = 5;
            this.cboDDiem.TextValue = null;
            this.cboDDiem.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cboDDiem_EditValuedChanged);
            // 
            // datDNgay
            // 
            this.datDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datDNgay.EditValue = null;
            this.datDNgay.Location = new System.Drawing.Point(582, 18);
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
            this.datDNgay.Size = new System.Drawing.Size(209, 20);
            this.datDNgay.TabIndex = 2;
            this.datDNgay.EditValueChanged += new System.EventHandler(this.datDNgay_EditValueChanged);
            // 
            // lblDNgay
            // 
            this.lblDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNgay.Location = new System.Drawing.Point(470, 15);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(106, 25);
            this.lblDNgay.TabIndex = 10;
            this.lblDNgay.Text = "lblDNgay";
            this.lblDNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grpMay, 6);
            this.grpMay.Controls.Add(this.grdBT);
            this.grpMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMay.Location = new System.Drawing.Point(3, 101);
            this.grpMay.LookAndFeel.SkinName = "Blue";
            this.grpMay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpMay.Name = "grpMay";
            this.grpMay.Size = new System.Drawing.Size(930, 325);
            this.grpMay.TabIndex = 16;
            this.grpMay.Text = "groupControl1";
            // 
            // grdBT
            // 
            this.grdBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBT.Location = new System.Drawing.Point(2, 22);
            this.grdBT.LookAndFeel.SkinName = "Blue";
            this.grdBT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdBT.MainView = this.grvBT;
            this.grdBT.Name = "grdBT";
            this.grdBT.Size = new System.Drawing.Size(926, 301);
            this.grdBT.TabIndex = 6;
            this.grdBT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBT,
            this.gridView1});
            // 
            // grvBT
            // 
            this.grvBT.GridControl = this.grdBT;
            this.grvBT.Name = "grvBT";
            this.grvBT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvBT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvBT.OptionsView.ShowGroupPanel = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdBT;
            this.gridView1.Name = "gridView1";
            // 
            // lblTNgay
            // 
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNgay.Location = new System.Drawing.Point(143, 15);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(106, 25);
            this.lblTNgay.TabIndex = 9;
            this.lblTNgay.Text = "lblTNgay";
            this.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datTNgay
            // 
            this.datTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(255, 18);
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
            this.datTNgay.Size = new System.Drawing.Size(209, 20);
            this.datTNgay.TabIndex = 1;
            this.datTNgay.EditValueChanged += new System.EventHandler(this.datTNgay_EditValueChanged);
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
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.datTNgay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTNgay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpMay, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDNgay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.datDNgay, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboDDiem, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDDiem, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDChuyen, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLMay, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboDChuyen, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboLMay, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLBaoTri, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboLBTri, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(936, 471);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 6);
            this.panel1.Controls.Add(this.txtTKiem);
            this.panel1.Controls.Add(this.btnNotALL);
            this.panel1.Controls.Add(this.btnALL);
            this.panel1.Controls.Add(this.btnChonNS);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 36);
            this.panel1.TabIndex = 17;
            // 
            // txtTKiem
            // 
            this.txtTKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTKiem.Location = new System.Drawing.Point(-3, 18);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(174, 20);
            this.txtTKiem.TabIndex = 27;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // btnNotALL
            // 
            this.btnNotALL.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotALL.Appearance.Options.UseFont = true;
            this.btnNotALL.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNotALL.Location = new System.Drawing.Point(512, 0);
            this.btnNotALL.LookAndFeel.SkinName = "Blue";
            this.btnNotALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNotALL.Name = "btnNotALL";
            this.btnNotALL.Size = new System.Drawing.Size(105, 36);
            this.btnNotALL.TabIndex = 10;
            this.btnNotALL.Text = "Bỏ chọn";
            this.btnNotALL.Click += new System.EventHandler(this.btnNotALL_Click);
            // 
            // btnALL
            // 
            this.btnALL.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALL.Appearance.Options.UseFont = true;
            this.btnALL.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnALL.Location = new System.Drawing.Point(617, 0);
            this.btnALL.LookAndFeel.SkinName = "Blue";
            this.btnALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(105, 36);
            this.btnALL.TabIndex = 9;
            this.btnALL.Text = "Chọn hết";
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // btnChonNS
            // 
            this.btnChonNS.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChonNS.Location = new System.Drawing.Point(722, 0);
            this.btnChonNS.LookAndFeel.SkinName = "Blue";
            this.btnChonNS.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnChonNS.Name = "btnChonNS";
            this.btnChonNS.Size = new System.Drawing.Size(104, 36);
            this.btnChonNS.TabIndex = 6;
            this.btnChonNS.Text = "btnChonNS";
            this.btnChonNS.Click += new System.EventHandler(this.btnChonNS_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.Location = new System.Drawing.Point(826, 0);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 36);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            // 
            // frmNhapNhanSuPBT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmNhapNhanSuPBT";
            this.Text = "frmNhapNhanSuPBT";
            this.Load += new System.EventHandler(this.frmNhapNhanSuPBT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboLBTri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMay)).EndInit();
            this.grpMay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboLBTri;
        private System.Windows.Forms.Label lblLBaoTri;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
        private ucComboboxTreeList cboDChuyen;
        private System.Windows.Forms.Label lblLMay;
        private System.Windows.Forms.Label lblDChuyen;
        private System.Windows.Forms.Label lblDDiem;
        private ucComboboxTreeList cboDDiem;
        private DevExpress.XtraEditors.DateEdit datDNgay;
        private System.Windows.Forms.Label lblDNgay;
        private DevExpress.XtraEditors.GroupControl grpMay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.DateEdit datTNgay;
        private System.Windows.Forms.Label lblTNgay;
        private DevExpress.XtraGrid.GridControl grdBT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnNotALL;
        private DevExpress.XtraEditors.SimpleButton btnALL;
        private DevExpress.XtraEditors.SimpleButton btnChonNS;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
    }
}