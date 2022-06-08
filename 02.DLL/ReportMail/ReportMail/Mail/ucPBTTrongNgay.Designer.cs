namespace ReportMail.Mail
{
    partial class ucPBTTrongNgay
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
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnSchedules = new DevExpress.XtraEditors.SimpleButton();
            this.ucSentTo1 = new ReportMail.Mail.ucSentTo();
            this.cboThietBi = new DevExpress.XtraEditors.LookUpEdit();
            this.lblThietBi = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietBi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 263F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grdData, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ucSentTo1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboThietBi, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblThietBi, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(693, 613);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdData
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdData, 5);
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(3, 317);
            this.grdData.LookAndFeel.SkinName = "Blue";
            this.grdData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(687, 253);
            this.grdData.TabIndex = 2;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData,
            this.advBandedGridView1,
            this.layoutView1,
            this.gridView1});
            // 
            // grvData
            // 
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvData_FocusedRowChanged);
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.GridControl = this.grdData;
            this.advBandedGridView1.Name = "advBandedGridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 189;
            // 
            // layoutView1
            // 
            this.layoutView1.GridControl = this.grdData;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewCard1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdData;
            this.gridView1.Name = "gridView1";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 5);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnKhong);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnSchedules);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 576);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 34);
            this.panel1.TabIndex = 3;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(3, 11);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(69, 20);
            this.txtID.TabIndex = 40;
            this.txtID.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(284, 2);
            this.btnThem.LookAndFeel.SkinName = "Blue";
            this.btnThem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(385, 2);
            this.btnSua.LookAndFeel.SkinName = "Blue";
            this.btnSua.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 30);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(486, 2);
            this.btnXoa.LookAndFeel.SkinName = "Blue";
            this.btnXoa.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 30);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(587, 2);
            this.btnKhong.LookAndFeel.SkinName = "Blue";
            this.btnKhong.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(100, 30);
            this.btnKhong.TabIndex = 9;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Visible = false;
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(486, 2);
            this.btnGhi.LookAndFeel.SkinName = "Blue";
            this.btnGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(100, 30);
            this.btnGhi.TabIndex = 8;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(587, 2);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 30);
            this.btnThoat.TabIndex = 39;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSchedules
            // 
            this.btnSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchedules.Location = new System.Drawing.Point(365, 2);
            this.btnSchedules.LookAndFeel.SkinName = "Blue";
            this.btnSchedules.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSchedules.Name = "btnSchedules";
            this.btnSchedules.Size = new System.Drawing.Size(120, 30);
            this.btnSchedules.TabIndex = 7;
            this.btnSchedules.Text = "btnThem";
            this.btnSchedules.Visible = false;
            this.btnSchedules.Click += new System.EventHandler(this.btnSchedules_Click);
            // 
            // ucSentTo1
            // 
            this.ucSentTo1.cHieuLuc = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ucSentTo1, 5);
            this.ucSentTo1.dNgayTao = new System.DateTime(((long)(0)));
            this.ucSentTo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSentTo1.Location = new System.Drawing.Point(3, 3);
            this.ucSentTo1.LookAndFeel.SkinName = "Blue";
            this.ucSentTo1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ucSentTo1.MinimumSize = new System.Drawing.Size(410, 151);
            this.ucSentTo1.Name = "ucSentTo1";
            this.ucSentTo1.Size = new System.Drawing.Size(687, 285);
            this.ucSentTo1.sMailBCC = "";
            this.ucSentTo1.sMailCC = "";
            this.ucSentTo1.sMailTo = "";
            this.ucSentTo1.sName = "";
            this.ucSentTo1.sNDung = "";
            this.ucSentTo1.sNgonNgu = 0;
            this.ucSentTo1.sSchedules = "";
            this.ucSentTo1.sSubject = "";
            this.ucSentTo1.sUserName = "";
            this.ucSentTo1.TabIndex = 1;
            // 
            // cboThietBi
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboThietBi, 2);
            this.cboThietBi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboThietBi.Location = new System.Drawing.Point(218, 294);
            this.cboThietBi.Name = "cboThietBi";
            this.cboThietBi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboThietBi.Properties.LookAndFeel.SkinName = "Blue";
            this.cboThietBi.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboThietBi.Size = new System.Drawing.Size(377, 20);
            this.cboThietBi.TabIndex = 1;
            // 
            // lblThietBi
            // 
            this.lblThietBi.Appearance.Options.UseTextOptions = true;
            this.lblThietBi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblThietBi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblThietBi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThietBi.Location = new System.Drawing.Point(98, 294);
            this.lblThietBi.Name = "lblThietBi";
            this.lblThietBi.Size = new System.Drawing.Size(114, 17);
            this.lblThietBi.TabIndex = 41;
            this.lblThietBi.Text = "lblLVTPT";
            // 
            // ucPBTTrongNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucPBTTrongNgay";
            this.Size = new System.Drawing.Size(693, 613);
            this.Load += new System.EventHandler(this.ucPBTTrongNgay_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietBi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.SimpleButton btnSchedules;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private ReportMail.Mail.ucSentTo ucSentTo1;
        private DevExpress.XtraEditors.LookUpEdit cboThietBi;
        private DevExpress.XtraEditors.LabelControl lblThietBi;
    }
}
