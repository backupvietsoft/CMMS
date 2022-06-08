namespace VietShape
{
    partial class frmDDNhomMay
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.cbtDChuyen = new MVControl.ucComboboxTreeList();
            this.cbtDDiem = new MVControl.ucComboboxTreeList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.btnNoAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongghi = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnAll = new DevExpress.XtraEditors.SimpleButton();
            this.lblDChuyen = new System.Windows.Forms.Label();
            this.lblLMay = new System.Windows.Forms.Label();
            this.cboNhomDD = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNhomDD = new System.Windows.Forms.Label();
            this.lblDDiem = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomDD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.41667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.91666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.91666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.41667F));
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboLMay, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbtDChuyen, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbtDDiem, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDChuyen, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLMay, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboNhomDD, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNhomDD, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDDiem, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdChung
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdChung, 6);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 57);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(878, 455);
            this.grdChung.TabIndex = 114;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsView.ColumnAutoWidth = false;
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // cboLMay
            // 
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(242, 32);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLMay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLMay.Properties.NullText = "";
            this.cboLMay.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboLMay.Size = new System.Drawing.Size(196, 20);
            this.cboLMay.TabIndex = 13;
            this.cboLMay.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // cbtDChuyen
            // 
            this.cbtDChuyen.ColumnDisplayName = null;
            this.cbtDChuyen.DataSource = null;
            this.cbtDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbtDChuyen.EditValue = null;
            this.cbtDChuyen.KeyFieldName = null;
            this.cbtDChuyen.Location = new System.Drawing.Point(592, 8);
            this.cbtDChuyen.LookAndFeel.SkinName = "Blue";
            this.cbtDChuyen.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cbtDChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.cbtDChuyen.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cbtDChuyen.MinimumSize = new System.Drawing.Size(10, 20);
            this.cbtDChuyen.Name = "cbtDChuyen";
            this.cbtDChuyen.ParentFieldName = null;
            this.cbtDChuyen.ReadOnly = false;
            this.cbtDChuyen.SelectedIndex = 0;
            this.cbtDChuyen.Size = new System.Drawing.Size(194, 20);
            this.cbtDChuyen.TabIndex = 101;
            this.cbtDChuyen.TextValue = null;
            this.cbtDChuyen.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cbtDDiem_EditValuedChanged);
            // 
            // cbtDDiem
            // 
            this.cbtDDiem.ColumnDisplayName = null;
            this.cbtDDiem.DataSource = null;
            this.cbtDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbtDDiem.EditValue = null;
            this.cbtDDiem.KeyFieldName = null;
            this.cbtDDiem.Location = new System.Drawing.Point(243, 8);
            this.cbtDDiem.LookAndFeel.SkinName = "Blue";
            this.cbtDDiem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cbtDDiem.Margin = new System.Windows.Forms.Padding(4);
            this.cbtDDiem.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cbtDDiem.MinimumSize = new System.Drawing.Size(10, 20);
            this.cbtDDiem.Name = "cbtDDiem";
            this.cbtDDiem.ParentFieldName = null;
            this.cbtDDiem.ReadOnly = false;
            this.cbtDDiem.SelectedIndex = 0;
            this.cbtDDiem.Size = new System.Drawing.Size(194, 20);
            this.cbtDDiem.TabIndex = 101;
            this.cbtDDiem.TextValue = null;
            this.cbtDDiem.EditValuedChanged += new MVControl.ucComboboxTreeList.EventArgs(this.cbtDDiem_EditValuedChanged);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 6);
            this.panel1.Controls.Add(this.txtTKiem);
            this.panel1.Controls.Add(this.btnNoAll);
            this.panel1.Controls.Add(this.btnThemSua);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnKhongghi);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Controls.Add(this.btnAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 518);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 36);
            this.panel1.TabIndex = 113;
            // 
            // txtTKiem
            // 
            this.txtTKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTKiem.Location = new System.Drawing.Point(0, 14);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(174, 20);
            this.txtTKiem.TabIndex = 12;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // btnNoAll
            // 
            this.btnNoAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoAll.Location = new System.Drawing.Point(561, 4);
            this.btnNoAll.Name = "btnNoAll";
            this.btnNoAll.Size = new System.Drawing.Size(104, 30);
            this.btnNoAll.TabIndex = 11;
            this.btnNoAll.Text = "btnNoAll";
            this.btnNoAll.Visible = false;
            this.btnNoAll.Click += new System.EventHandler(this.btnNoAll_Click);
            // 
            // btnThemSua
            // 
            this.btnThemSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemSua.Location = new System.Drawing.Point(666, 4);
            this.btnThemSua.Name = "btnThemSua";
            this.btnThemSua.Size = new System.Drawing.Size(104, 30);
            this.btnThemSua.TabIndex = 7;
            this.btnThemSua.Text = "btnThemSua";
            this.btnThemSua.Click += new System.EventHandler(this.btnThemSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(771, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnKhongghi
            // 
            this.btnKhongghi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhongghi.Location = new System.Drawing.Point(771, 4);
            this.btnKhongghi.Name = "btnKhongghi";
            this.btnKhongghi.Size = new System.Drawing.Size(104, 30);
            this.btnKhongghi.TabIndex = 11;
            this.btnKhongghi.Text = "Không lưu";
            this.btnKhongghi.Visible = false;
            this.btnKhongghi.Click += new System.EventHandler(this.btnKhongghi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(666, 4);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(104, 30);
            this.btnGhi.TabIndex = 10;
            this.btnGhi.Text = "Lưu";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.Location = new System.Drawing.Point(456, 4);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(104, 30);
            this.btnAll.TabIndex = 10;
            this.btnAll.Text = "btnAll";
            this.btnAll.Visible = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // lblDChuyen
            // 
            this.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDChuyen.Location = new System.Drawing.Point(444, 4);
            this.lblDChuyen.Name = "lblDChuyen";
            this.lblDChuyen.Size = new System.Drawing.Size(141, 25);
            this.lblDChuyen.TabIndex = 13;
            this.lblDChuyen.Text = "lblDChuyen";
            this.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLMay
            // 
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLMay.Location = new System.Drawing.Point(95, 29);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(141, 25);
            this.lblLMay.TabIndex = 13;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNhomDD
            // 
            this.cboNhomDD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNhomDD.Location = new System.Drawing.Point(591, 32);
            this.cboNhomDD.Name = "cboNhomDD";
            this.cboNhomDD.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboNhomDD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "...", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.cboNhomDD.Properties.LookAndFeel.SkinName = "Blue";
            this.cboNhomDD.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboNhomDD.Properties.NullText = "";
            this.cboNhomDD.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboNhomDD.Size = new System.Drawing.Size(196, 20);
            this.cboNhomDD.TabIndex = 78;
            this.cboNhomDD.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboNhomDD_ButtonClick);
            this.cboNhomDD.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // lblNhomDD
            // 
            this.lblNhomDD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhomDD.Location = new System.Drawing.Point(444, 29);
            this.lblNhomDD.Name = "lblNhomDD";
            this.lblNhomDD.Size = new System.Drawing.Size(141, 25);
            this.lblNhomDD.TabIndex = 13;
            this.lblNhomDD.Text = "lblNhomDD";
            this.lblNhomDD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDDiem
            // 
            this.lblDDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDDiem.Location = new System.Drawing.Point(95, 4);
            this.lblDDiem.Name = "lblDDiem";
            this.lblDDiem.Size = new System.Drawing.Size(141, 25);
            this.lblDDiem.TabIndex = 13;
            this.lblDDiem.Text = "lblDDiem";
            this.lblDDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDDNhomMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmDDNhomMay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDDNhomMay";
            this.Load += new System.EventHandler(this.frmDDNhomMay_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomDD.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private DevExpress.XtraEditors.SimpleButton btnThemSua;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnKhongghi;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        public DevExpress.XtraEditors.LookUpEdit cboNhomDD;
        private System.Windows.Forms.Label lblNhomDD;
        internal DevExpress.XtraGrid.GridControl grdChung;
        internal DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private System.Windows.Forms.Label lblDChuyen;
        private System.Windows.Forms.Label lblLMay;
        private System.Windows.Forms.Label lblDDiem;
        internal MVControl.ucComboboxTreeList cbtDDiem;
        internal MVControl.ucComboboxTreeList cbtDChuyen;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
        private DevExpress.XtraEditors.SimpleButton btnNoAll;
        private DevExpress.XtraEditors.SimpleButton btnAll;
    }
}