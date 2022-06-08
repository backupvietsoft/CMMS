namespace MVControl
{
    partial class frmBaoTri
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
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdHinhThucBT = new DevExpress.XtraGrid.GridControl();
            this.grvHinhThucBT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLoaiBT = new DevExpress.XtraGrid.GridControl();
            this.grvLoaiBT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnColor = new DevExpress.XtraEditors.SimpleButton();
            this.BtnXoaNhomBT = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btQH = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongghi = new DevExpress.XtraEditors.SimpleButton();
            this.BtnXoaLoai = new DevExpress.XtraEditors.SimpleButton();
            this.btnTroVe = new DevExpress.XtraEditors.SimpleButton();
            this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnVideo = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHinhThucBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHinhThucBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLoaiBT)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnHelp, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnVideo, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // splitContainer1
            // 
            this.splitContainer1.AutoSize = true;
            this.splitContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer1, 5);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainer1.Location = new System.Drawing.Point(3, 40);
            this.splitContainer1.LookAndFeel.SkinName = "Blue";
            this.splitContainer1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.grdHinhThucBT);
            this.splitContainer1.Panel2.Controls.Add(this.grdLoaiBT);
            this.splitContainer1.Size = new System.Drawing.Size(878, 478);
            this.splitContainer1.SplitterPosition = 354;
            this.splitContainer1.TabIndex = 0;
            // 
            // grdHinhThucBT
            // 
            this.grdHinhThucBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHinhThucBT.Location = new System.Drawing.Point(0, 0);
            this.grdHinhThucBT.LookAndFeel.SkinName = "Blue";
            this.grdHinhThucBT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdHinhThucBT.MainView = this.grvHinhThucBT;
            this.grdHinhThucBT.Name = "grdHinhThucBT";
            this.grdHinhThucBT.Size = new System.Drawing.Size(354, 478);
            this.grdHinhThucBT.TabIndex = 1;
            this.grdHinhThucBT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHinhThucBT});
            // 
            // grvHinhThucBT
            // 
            this.grvHinhThucBT.GridControl = this.grdHinhThucBT;
            this.grvHinhThucBT.Name = "grvHinhThucBT";
            this.grvHinhThucBT.OptionsView.ShowGroupPanel = false;
            this.grvHinhThucBT.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvHinhThucBT_InitNewRow);
            this.grvHinhThucBT.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvHinhThucBT_FocusedRowChanged);
            this.grvHinhThucBT.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvHinhThucBT_InvalidRowException);
            this.grvHinhThucBT.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvHinhThucBT_ValidateRow);
            // 
            // grdLoaiBT
            // 
            this.grdLoaiBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLoaiBT.Location = new System.Drawing.Point(0, 0);
            this.grdLoaiBT.LookAndFeel.SkinName = "Blue";
            this.grdLoaiBT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdLoaiBT.MainView = this.grvLoaiBT;
            this.grdLoaiBT.Name = "grdLoaiBT";
            this.grdLoaiBT.Size = new System.Drawing.Size(518, 478);
            this.grdLoaiBT.TabIndex = 1;
            this.grdLoaiBT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLoaiBT});
            // 
            // grvLoaiBT
            // 
            this.grvLoaiBT.GridControl = this.grdLoaiBT;
            this.grvLoaiBT.Name = "grvLoaiBT";
            this.grvLoaiBT.OptionsView.ShowGroupPanel = false;
            this.grvLoaiBT.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvLoaiBT_RowCellStyle);
            this.grvLoaiBT.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvLoaiBT_InitNewRow);
            this.grvLoaiBT.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvLoaiBT_InvalidRowException);
            this.grvLoaiBT.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvLoaiBT_ValidateRow);
            this.grvLoaiBT.DoubleClick += new System.EventHandler(this.grvLoaiBT_DoubleClick);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 5);
            this.panel1.Controls.Add(this.btnColor);
            this.panel1.Controls.Add(this.BtnXoaNhomBT);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btQH);
            this.panel1.Controls.Add(this.btnThemSua);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Controls.Add(this.btnKhongghi);
            this.panel1.Controls.Add(this.BtnXoaLoai);
            this.panel1.Controls.Add(this.btnTroVe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 524);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 34);
            this.panel1.TabIndex = 13;
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.Location = new System.Drawing.Point(561, 2);
            this.btnColor.LookAndFeel.SkinName = "Blue";
            this.btnColor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(104, 30);
            this.btnColor.TabIndex = 10;
            this.btnColor.Text = "btnColor";
            this.btnColor.Visible = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // BtnXoaNhomBT
            // 
            this.BtnXoaNhomBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnXoaNhomBT.Location = new System.Drawing.Point(561, 2);
            this.BtnXoaNhomBT.LookAndFeel.SkinName = "Blue";
            this.BtnXoaNhomBT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnXoaNhomBT.Name = "BtnXoaNhomBT";
            this.BtnXoaNhomBT.Size = new System.Drawing.Size(104, 30);
            this.BtnXoaNhomBT.TabIndex = 7;
            this.BtnXoaNhomBT.Text = "BtnXoaNhomBT";
            this.BtnXoaNhomBT.Visible = false;
            this.BtnXoaNhomBT.Click += new System.EventHandler(this.BtnXoaNhomBT_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(771, 2);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btQH
            // 
            this.btQH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btQH.Location = new System.Drawing.Point(456, 2);
            this.btQH.LookAndFeel.SkinName = "Blue";
            this.btQH.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btQH.Name = "btQH";
            this.btQH.Size = new System.Drawing.Size(104, 30);
            this.btQH.TabIndex = 7;
            this.btQH.Text = "btQH";
            this.btQH.Click += new System.EventHandler(this.btQH_Click);
            // 
            // btnThemSua
            // 
            this.btnThemSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemSua.Location = new System.Drawing.Point(561, 2);
            this.btnThemSua.LookAndFeel.SkinName = "Blue";
            this.btnThemSua.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThemSua.Name = "btnThemSua";
            this.btnThemSua.Size = new System.Drawing.Size(104, 30);
            this.btnThemSua.TabIndex = 7;
            this.btnThemSua.Text = "Sửa";
            this.btnThemSua.Click += new System.EventHandler(this.btnThemSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(666, 2);
            this.btnXoa.LookAndFeel.SkinName = "Blue";
            this.btnXoa.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(104, 30);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(666, 2);
            this.btnGhi.LookAndFeel.SkinName = "Blue";
            this.btnGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(104, 30);
            this.btnGhi.TabIndex = 10;
            this.btnGhi.Text = "Lưu";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhongghi
            // 
            this.btnKhongghi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhongghi.Location = new System.Drawing.Point(771, 2);
            this.btnKhongghi.LookAndFeel.SkinName = "Blue";
            this.btnKhongghi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKhongghi.Name = "btnKhongghi";
            this.btnKhongghi.Size = new System.Drawing.Size(104, 30);
            this.btnKhongghi.TabIndex = 11;
            this.btnKhongghi.Text = "Không lưu";
            this.btnKhongghi.Visible = false;
            this.btnKhongghi.Click += new System.EventHandler(this.btnKhongghi_Click);
            // 
            // BtnXoaLoai
            // 
            this.BtnXoaLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnXoaLoai.Location = new System.Drawing.Point(666, 2);
            this.BtnXoaLoai.LookAndFeel.SkinName = "Blue";
            this.BtnXoaLoai.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnXoaLoai.Name = "BtnXoaLoai";
            this.BtnXoaLoai.Size = new System.Drawing.Size(104, 30);
            this.BtnXoaLoai.TabIndex = 7;
            this.BtnXoaLoai.Text = "BtnXoaLoai";
            this.BtnXoaLoai.Visible = false;
            this.BtnXoaLoai.Click += new System.EventHandler(this.BtnXoaLoai_Click);
            // 
            // btnTroVe
            // 
            this.btnTroVe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTroVe.Location = new System.Drawing.Point(771, 2);
            this.btnTroVe.LookAndFeel.SkinName = "Blue";
            this.btnTroVe.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(104, 30);
            this.btnTroVe.TabIndex = 6;
            this.btnTroVe.Text = "btnTroVe";
            this.btnTroVe.Visible = false;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnVideo.Location = new System.Drawing.Point(830, 9);
            this.btnVideo.Margin = new System.Windows.Forms.Padding(1);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(33, 23);
            this.btnVideo.TabIndex = 102;
            this.btnVideo.Tag = "CMMS!frmBaoTri";
            // 
            // btnHelp
            // 
            this.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnHelp.Location = new System.Drawing.Point(795, 9);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(1);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(33, 23);
            this.btnHelp.TabIndex = 101;
            this.btnHelp.Tag = "CMMS!frmBaoTri";
            // 
            // frmBaoTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmBaoTri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBaoTri";
            this.Load += new System.EventHandler(this.frmLoaiBaoTri_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHinhThucBT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHinhThucBT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiBT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLoaiBT)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        public DevExpress.XtraGrid.GridControl grdHinhThucBT;
        public DevExpress.XtraGrid.Views.Grid.GridView grvHinhThucBT;
        private DevExpress.XtraGrid.GridControl grdLoaiBT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLoaiBT;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnThemSua;
        private DevExpress.XtraEditors.SimpleButton btnKhongghi;
        private DevExpress.XtraEditors.SimpleButton btnTroVe;
        private DevExpress.XtraEditors.SimpleButton BtnXoaLoai;
        private DevExpress.XtraEditors.SimpleButton BtnXoaNhomBT;
        private DevExpress.XtraEditors.SimpleButton btnColor;
        private DevExpress.XtraEditors.SimpleButton btQH;
        internal System.Windows.Forms.ColorDialog ColorDialog1;
        internal DevExpress.XtraEditors.SimpleButton btnHelp;
        internal DevExpress.XtraEditors.SimpleButton btnVideo;
    }
}