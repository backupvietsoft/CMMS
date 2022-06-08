namespace VietShape
{
    partial class frmDDNhomCNhan
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
            this.cboTo = new DevExpress.XtraEditors.LookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.btnNoAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongghi = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnAll = new DevExpress.XtraEditors.SimpleButton();
            this.lblPBan = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.cboNhomDD = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNhomDD = new System.Windows.Forms.Label();
            this.lblDonvi = new System.Windows.Forms.Label();
            this.cboDVi = new DevExpress.XtraEditors.LookUpEdit();
            this.cboPBan = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomDD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPBan.Properties)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.cboTo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPBan, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboNhomDD, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNhomDD, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDonvi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboDVi, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboPBan, 4, 1);
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
            // cboTo
            // 
            this.cboTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTo.Location = new System.Drawing.Point(242, 32);
            this.cboTo.Name = "cboTo";
            this.cboTo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTo.Properties.LookAndFeel.SkinName = "Blue";
            this.cboTo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboTo.Properties.NullText = "";
            this.cboTo.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboTo.Size = new System.Drawing.Size(196, 20);
            this.cboTo.TabIndex = 13;
            this.cboTo.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
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
            // lblPBan
            // 
            this.lblPBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPBan.Location = new System.Drawing.Point(444, 4);
            this.lblPBan.Name = "lblPBan";
            this.lblPBan.Size = new System.Drawing.Size(141, 25);
            this.lblPBan.TabIndex = 13;
            this.lblPBan.Text = "lblPBan";
            this.lblPBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTo
            // 
            this.lblTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTo.Location = new System.Drawing.Point(95, 29);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(141, 25);
            this.lblTo.TabIndex = 13;
            this.lblTo.Text = "lblTo";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lblDonvi
            // 
            this.lblDonvi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonvi.Location = new System.Drawing.Point(95, 4);
            this.lblDonvi.Name = "lblDonvi";
            this.lblDonvi.Size = new System.Drawing.Size(141, 25);
            this.lblDonvi.TabIndex = 13;
            this.lblDonvi.Tag = "";
            this.lblDonvi.Text = "lblDVi";
            this.lblDonvi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDVi
            // 
            this.cboDVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDVi.Location = new System.Drawing.Point(242, 7);
            this.cboDVi.Name = "cboDVi";
            this.cboDVi.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboDVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDVi.Properties.LookAndFeel.SkinName = "Blue";
            this.cboDVi.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDVi.Properties.NullText = "";
            this.cboDVi.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboDVi.Size = new System.Drawing.Size(196, 20);
            this.cboDVi.TabIndex = 13;
            this.cboDVi.EditValueChanged += new System.EventHandler(this.cboDVi_EditValueChanged);
            // 
            // cboPBan
            // 
            this.cboPBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPBan.Location = new System.Drawing.Point(591, 7);
            this.cboPBan.Name = "cboPBan";
            this.cboPBan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cboPBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPBan.Properties.LookAndFeel.SkinName = "Blue";
            this.cboPBan.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboPBan.Properties.NullText = "";
            this.cboPBan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboPBan.Size = new System.Drawing.Size(196, 20);
            this.cboPBan.TabIndex = 13;
            this.cboPBan.EditValueChanged += new System.EventHandler(this.cboPBan_EditValueChanged);
            // 
            // frmDDNhomCNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmDDNhomCNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDDNhomCNhan";
            this.Load += new System.EventHandler(this.frmDDNhomCNhan_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomDD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPBan.Properties)).EndInit();
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
        private System.Windows.Forms.Label lblPBan;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDonvi;
        private DevExpress.XtraEditors.SimpleButton btnNoAll;
        private DevExpress.XtraEditors.SimpleButton btnAll;
        private DevExpress.XtraEditors.LookUpEdit cboTo;
        private DevExpress.XtraEditors.LookUpEdit cboDVi;
        private DevExpress.XtraEditors.LookUpEdit cboPBan;
    }
}