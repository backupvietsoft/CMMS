namespace MVControl
{
    partial class frmNgayNghiTheoNhaXuong
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
            this.tvwNhaXuong = new DevExpress.XtraTreeList.TreeList();
            this.grdNgayNghi = new DevExpress.XtraGrid.GridControl();
            this.grvNgayNghi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTimkiem = new DevExpress.XtraEditors.TextEdit();
            this.btnThemSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongghi = new DevExpress.XtraEditors.SimpleButton();
            this.dtTNgay = new DevExpress.XtraEditors.DateEdit();
            this.dtDNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblTNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblDNgay = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvwNhaXuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNgayNghi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNgayNghi)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimkiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtTNgay, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtDNgay, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTNgay, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDNgay, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // splitContainer1
            // 
            this.splitContainer1.AutoSize = true;
            this.splitContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer1, 6);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.LookAndFeel.SkinName = "Blue";
            this.splitContainer1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.tvwNhaXuong);
            this.splitContainer1.Panel2.Controls.Add(this.grdNgayNghi);
            this.splitContainer1.Size = new System.Drawing.Size(878, 490);
            this.splitContainer1.SplitterPosition = 439;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvwNhaXuong
            // 
            this.tvwNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNhaXuong.Location = new System.Drawing.Point(0, 0);
            this.tvwNhaXuong.Name = "tvwNhaXuong";
            this.tvwNhaXuong.OptionsBehavior.Editable = false;
            this.tvwNhaXuong.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tvwNhaXuong.Size = new System.Drawing.Size(439, 490);
            this.tvwNhaXuong.TabIndex = 25;
            this.tvwNhaXuong.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tvwNhaXuong_FocusedNodeChanged);
            // 
            // grdNgayNghi
            // 
            this.grdNgayNghi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNgayNghi.Location = new System.Drawing.Point(0, 0);
            this.grdNgayNghi.LookAndFeel.SkinName = "Blue";
            this.grdNgayNghi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdNgayNghi.MainView = this.grvNgayNghi;
            this.grdNgayNghi.Name = "grdNgayNghi";
            this.grdNgayNghi.Size = new System.Drawing.Size(433, 490);
            this.grdNgayNghi.TabIndex = 1;
            this.grdNgayNghi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNgayNghi});
            // 
            // grvNgayNghi
            // 
            this.grvNgayNghi.GridControl = this.grdNgayNghi;
            this.grvNgayNghi.Name = "grvNgayNghi";
            this.grvNgayNghi.OptionsView.ShowGroupPanel = false;
            this.grvNgayNghi.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvNgayNghi_InitNewRow);
            this.grvNgayNghi.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvNgayNghi_InvalidRowException);
            this.grvNgayNghi.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvNgayNghi_ValidateRow);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 6);
            this.panel1.Controls.Add(this.txtTimkiem);
            this.panel1.Controls.Add(this.btnThemSua);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Controls.Add(this.btnKhongghi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 524);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 34);
            this.panel1.TabIndex = 13;
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimkiem.Location = new System.Drawing.Point(0, 7);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Properties.LookAndFeel.SkinName = "Blue";
            this.txtTimkiem.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTimkiem.Size = new System.Drawing.Size(170, 20);
            this.txtTimkiem.TabIndex = 76;
            this.txtTimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimkiem_KeyDown);
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
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(770, 2);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
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
            this.btnKhongghi.Location = new System.Drawing.Point(770, 2);
            this.btnKhongghi.LookAndFeel.SkinName = "Blue";
            this.btnKhongghi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKhongghi.Name = "btnKhongghi";
            this.btnKhongghi.Size = new System.Drawing.Size(104, 30);
            this.btnKhongghi.TabIndex = 11;
            this.btnKhongghi.Text = "Không lưu";
            this.btnKhongghi.Visible = false;
            this.btnKhongghi.Click += new System.EventHandler(this.btnKhongghi_Click);
            // 
            // dtTNgay
            // 
            this.dtTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTNgay.EditValue = null;
            this.dtTNgay.Location = new System.Drawing.Point(305, 3);
            this.dtTNgay.Name = "dtTNgay";
            this.dtTNgay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtTNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.dtTNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtTNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtTNgay.Size = new System.Drawing.Size(134, 20);
            this.dtTNgay.TabIndex = 14;
            this.dtTNgay.EditValueChanged += new System.EventHandler(this.dtDNgay_EditValueChanged);
            // 
            // dtDNgay
            // 
            this.dtDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDNgay.EditValue = null;
            this.dtDNgay.Location = new System.Drawing.Point(565, 3);
            this.dtDNgay.Name = "dtDNgay";
            this.dtDNgay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtDNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.dtDNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtDNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDNgay.Size = new System.Drawing.Size(134, 20);
            this.dtDNgay.TabIndex = 14;
            this.dtDNgay.EditValueChanged += new System.EventHandler(this.dtDNgay_EditValueChanged);
            // 
            // lblTNgay
            // 
            this.lblTNgay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNgay.Location = new System.Drawing.Point(185, 3);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(114, 19);
            this.lblTNgay.TabIndex = 15;
            this.lblTNgay.Text = "lblTNgay";
            // 
            // lblDNgay
            // 
            this.lblDNgay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNgay.Location = new System.Drawing.Point(445, 3);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(114, 19);
            this.lblDNgay.TabIndex = 15;
            this.lblDNgay.Text = "lblDNgay";
            // 
            // frmNgayNghiTheoNhaXuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmNgayNghiTheoNhaXuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNgayNghiTheoNhaXuong";
            this.Load += new System.EventHandler(this.frmNgayNghiTheoNhaXuong_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvwNhaXuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNgayNghi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNgayNghi)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTimkiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDNgay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private DevExpress.XtraGrid.GridControl grdNgayNghi;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNgayNghi;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhongghi;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnThemSua;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        internal DevExpress.XtraTreeList.TreeList tvwNhaXuong;
        private DevExpress.XtraEditors.DateEdit dtTNgay;
        private DevExpress.XtraEditors.DateEdit dtDNgay;
        private DevExpress.XtraEditors.LabelControl lblTNgay;
        private DevExpress.XtraEditors.LabelControl lblDNgay;
        internal DevExpress.XtraEditors.TextEdit txtTimkiem;
    }
}