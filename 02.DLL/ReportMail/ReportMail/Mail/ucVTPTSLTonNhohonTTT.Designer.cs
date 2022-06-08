namespace ReportMail.UControl
{
    partial class ucVTPTSLTonNhohonTTT
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
            this.cboLVTPT = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLVTPT = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnSchedules = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.lblKho = new DevExpress.XtraEditors.LabelControl();
            this.cboKho = new DevExpress.XtraEditors.LookUpEdit();
            this.ucSentTo1 = new ReportMail.Mail.ucSentTo();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLVTPT.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKho.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.grdData, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboLVTPT, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLVTPT, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblKho, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboKho, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.ucSentTo1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(925, 642);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdData
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdData, 6);
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(3, 317);
            this.grdData.LookAndFeel.SkinName = "Blue";
            this.grdData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(919, 282);
            this.grdData.TabIndex = 3;
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
            // cboLVTPT
            // 
            this.cboLVTPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLVTPT.Location = new System.Drawing.Point(260, 294);
            this.cboLVTPT.Name = "cboLVTPT";
            this.cboLVTPT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLVTPT.Properties.LookAndFeel.SkinName = "Blue";
            this.cboLVTPT.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLVTPT.Size = new System.Drawing.Size(199, 20);
            this.cboLVTPT.TabIndex = 1;
            // 
            // lblLVTPT
            // 
            this.lblLVTPT.Appearance.Options.UseTextOptions = true;
            this.lblLVTPT.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblLVTPT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLVTPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLVTPT.Location = new System.Drawing.Point(140, 294);
            this.lblLVTPT.Name = "lblLVTPT";
            this.lblLVTPT.Size = new System.Drawing.Size(114, 17);
            this.lblLVTPT.TabIndex = 41;
            this.lblLVTPT.Text = "lblLVTPT";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 6);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnSchedules);
            this.panel1.Controls.Add(this.btnKhong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 605);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 34);
            this.panel1.TabIndex = 4;
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
            this.btnThem.Location = new System.Drawing.Point(516, 2);
            this.btnThem.LookAndFeel.SkinName = "Blue";
            this.btnThem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(617, 2);
            this.btnSua.LookAndFeel.SkinName = "Blue";
            this.btnSua.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 30);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(718, 2);
            this.btnXoa.LookAndFeel.SkinName = "Blue";
            this.btnXoa.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 30);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(718, 2);
            this.btnGhi.LookAndFeel.SkinName = "Blue";
            this.btnGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(100, 30);
            this.btnGhi.TabIndex = 10;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(819, 2);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 30);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSchedules
            // 
            this.btnSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchedules.Location = new System.Drawing.Point(597, 2);
            this.btnSchedules.LookAndFeel.SkinName = "Blue";
            this.btnSchedules.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSchedules.Name = "btnSchedules";
            this.btnSchedules.Size = new System.Drawing.Size(120, 30);
            this.btnSchedules.TabIndex = 9;
            this.btnSchedules.Text = "btnThem";
            this.btnSchedules.Visible = false;
            this.btnSchedules.Click += new System.EventHandler(this.btnSchedules_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(819, 2);
            this.btnKhong.LookAndFeel.SkinName = "Blue";
            this.btnKhong.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(100, 30);
            this.btnKhong.TabIndex = 11;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Visible = false;
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // lblKho
            // 
            this.lblKho.Appearance.Options.UseTextOptions = true;
            this.lblKho.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblKho.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKho.Location = new System.Drawing.Point(465, 294);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(114, 17);
            this.lblKho.TabIndex = 41;
            this.lblKho.Text = "lblKho";
            // 
            // cboKho
            // 
            this.cboKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKho.Location = new System.Drawing.Point(585, 294);
            this.cboKho.Name = "cboKho";
            this.cboKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKho.Properties.LookAndFeel.SkinName = "Blue";
            this.cboKho.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboKho.Size = new System.Drawing.Size(199, 20);
            this.cboKho.TabIndex = 2;
            // 
            // ucSentTo1
            // 
            this.ucSentTo1.cHieuLuc = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ucSentTo1, 6);
            this.ucSentTo1.dNgayTao = new System.DateTime(((long)(0)));
            this.ucSentTo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSentTo1.Location = new System.Drawing.Point(3, 3);
            this.ucSentTo1.LookAndFeel.SkinName = "Blue";
            this.ucSentTo1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ucSentTo1.MinimumSize = new System.Drawing.Size(410, 151);
            this.ucSentTo1.Name = "ucSentTo1";
            this.ucSentTo1.Size = new System.Drawing.Size(919, 285);
            this.ucSentTo1.sMailBCC = "";
            this.ucSentTo1.sMailCC = "";
            this.ucSentTo1.sMailTo = "";
            this.ucSentTo1.sName = "";
            this.ucSentTo1.sNDung = "";
            this.ucSentTo1.sNgonNgu = 0;
            this.ucSentTo1.sSchedules = "";
            this.ucSentTo1.sSubject = "";
            this.ucSentTo1.sUserName = "";
            this.ucSentTo1.TabIndex = 0;
            // 
            // ucVTPTSLTonNhohonTTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucVTPTSLTonNhohonTTT";
            this.Size = new System.Drawing.Size(925, 642);
            this.Load += new System.EventHandler(this.ucVTPTSLTonNhohonTTT_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLVTPT.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKho.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.LookUpEdit cboLVTPT;
        private DevExpress.XtraEditors.LabelControl lblLVTPT;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl lblKho;
        private DevExpress.XtraEditors.LookUpEdit cboKho;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private ReportMail.Mail.ucSentTo ucSentTo1;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.SimpleButton btnSchedules;

    }
}
