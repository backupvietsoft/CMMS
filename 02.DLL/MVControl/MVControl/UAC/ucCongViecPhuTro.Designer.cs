namespace MVControl
{
    partial class ucCongViecPhuTro
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
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdCViec = new DevExpress.XtraGrid.GridControl();
            this.grvCViec = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdVTu = new DevExpress.XtraGrid.GridControl();
            this.grvVTu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTimkiem = new DevExpress.XtraEditors.TextEdit();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongghi = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaPT = new DevExpress.XtraEditors.SimpleButton();
            this.btnChonPT = new DevExpress.XtraEditors.SimpleButton();
            this.btnTroVe = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaCV = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCViec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCViec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVTu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimkiem.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AutoSize = true;
            this.splitContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.LookAndFeel.SkinName = "Blue";
            this.splitContainer1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.grdCViec);
            this.splitContainer1.Panel2.Controls.Add(this.grdVTu);
            this.splitContainer1.Size = new System.Drawing.Size(894, 552);
            this.splitContainer1.SplitterPosition = 388;
            this.splitContainer1.TabIndex = 0;
            // 
            // grdCViec
            // 
            this.grdCViec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCViec.Location = new System.Drawing.Point(0, 0);
            this.grdCViec.LookAndFeel.SkinName = "Blue";
            this.grdCViec.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdCViec.MainView = this.grvCViec;
            this.grdCViec.Name = "grdCViec";
            this.grdCViec.Size = new System.Drawing.Size(389, 552);
            this.grdCViec.TabIndex = 1;
            this.grdCViec.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCViec});
            // 
            // grvCViec
            // 
            this.grvCViec.GridControl = this.grdCViec;
            this.grvCViec.Name = "grvCViec";
            this.grvCViec.OptionsView.ShowGroupPanel = false;
            this.grvCViec.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvCViec_InitNewRow);
            this.grvCViec.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvCViec_FocusedRowChanged);
            this.grvCViec.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvCViec_CellValueChanged);
            this.grvCViec.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvCViec_InvalidRowException);
            this.grvCViec.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvCViec_ValidateRow);
            this.grvCViec.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvCViec_ValidatingEditor);
            // 
            // grdVTu
            // 
            this.grdVTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVTu.Location = new System.Drawing.Point(0, 0);
            this.grdVTu.LookAndFeel.SkinName = "Blue";
            this.grdVTu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdVTu.MainView = this.grvVTu;
            this.grdVTu.Name = "grdVTu";
            this.grdVTu.Size = new System.Drawing.Size(499, 552);
            this.grdVTu.TabIndex = 1;
            this.grdVTu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVTu});
            // 
            // grvVTu
            // 
            this.grvVTu.GridControl = this.grdVTu;
            this.grvVTu.Name = "grvVTu";
            this.grvVTu.OptionsView.ShowGroupPanel = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTimkiem);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnKhongghi);
            this.panel1.Controls.Add(this.btnXoaPT);
            this.panel1.Controls.Add(this.btnChonPT);
            this.panel1.Controls.Add(this.btnTroVe);
            this.panel1.Controls.Add(this.btnXoaCV);
            this.panel1.Controls.Add(this.btnThemSua);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 561);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 36);
            this.panel1.TabIndex = 13;
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimkiem.Location = new System.Drawing.Point(3, 12);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Properties.LookAndFeel.SkinName = "Blue";
            this.txtTimkiem.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTimkiem.Size = new System.Drawing.Size(170, 20);
            this.txtTimkiem.TabIndex = 75;
            this.txtTimkiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTimkiem_EditValueChanging);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(682, 4);
            this.btnXoa.LookAndFeel.SkinName = "Blue";
            this.btnXoa.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(104, 30);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(682, 4);
            this.btnGhi.LookAndFeel.SkinName = "Blue";
            this.btnGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(104, 30);
            this.btnGhi.TabIndex = 10;
            this.btnGhi.Text = "Lưu";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(787, 4);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThemSua
            // 
            this.btnThemSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemSua.Location = new System.Drawing.Point(577, 4);
            this.btnThemSua.LookAndFeel.SkinName = "Blue";
            this.btnThemSua.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThemSua.Name = "btnThemSua";
            this.btnThemSua.Size = new System.Drawing.Size(104, 30);
            this.btnThemSua.TabIndex = 7;
            this.btnThemSua.Text = "Sửa";
            // 
            // btnKhongghi
            // 
            this.btnKhongghi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhongghi.Location = new System.Drawing.Point(787, 4);
            this.btnKhongghi.LookAndFeel.SkinName = "Blue";
            this.btnKhongghi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKhongghi.Name = "btnKhongghi";
            this.btnKhongghi.Size = new System.Drawing.Size(104, 30);
            this.btnKhongghi.TabIndex = 11;
            this.btnKhongghi.Text = "Không lưu";
            this.btnKhongghi.Visible = false;
            this.btnKhongghi.Click += new System.EventHandler(this.btnKhongghi_Click);
            // 
            // btnXoaPT
            // 
            this.btnXoaPT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaPT.Location = new System.Drawing.Point(682, 4);
            this.btnXoaPT.LookAndFeel.SkinName = "Blue";
            this.btnXoaPT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXoaPT.Name = "btnXoaPT";
            this.btnXoaPT.Size = new System.Drawing.Size(104, 30);
            this.btnXoaPT.TabIndex = 7;
            this.btnXoaPT.Text = "btnXoaPT";
            this.btnXoaPT.Visible = false;
            this.btnXoaPT.Click += new System.EventHandler(this.btnXoaPT_Click);
            // 
            // btnChonPT
            // 
            this.btnChonPT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChonPT.Location = new System.Drawing.Point(577, 4);
            this.btnChonPT.LookAndFeel.SkinName = "Blue";
            this.btnChonPT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnChonPT.Name = "btnChonPT";
            this.btnChonPT.Size = new System.Drawing.Size(104, 30);
            this.btnChonPT.TabIndex = 12;
            this.btnChonPT.Text = "btnChonPT";
            this.btnChonPT.Visible = false;
            this.btnChonPT.Click += new System.EventHandler(this.btnChonPT_Click);
            // 
            // btnTroVe
            // 
            this.btnTroVe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTroVe.Location = new System.Drawing.Point(787, 4);
            this.btnTroVe.LookAndFeel.SkinName = "Blue";
            this.btnTroVe.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(104, 30);
            this.btnTroVe.TabIndex = 6;
            this.btnTroVe.Text = "btnTroVe";
            this.btnTroVe.Visible = false;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnXoaCV
            // 
            this.btnXoaCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaCV.Location = new System.Drawing.Point(577, 4);
            this.btnXoaCV.LookAndFeel.SkinName = "Blue";
            this.btnXoaCV.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXoaCV.Name = "btnXoaCV";
            this.btnXoaCV.Size = new System.Drawing.Size(104, 30);
            this.btnXoaCV.TabIndex = 7;
            this.btnXoaCV.Text = "btnXoaCV";
            this.btnXoaCV.Visible = false;
            this.btnXoaCV.Click += new System.EventHandler(this.btnXoaCV_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 600);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // gridView2
            // 
            this.gridView2.Name = "gridView2";
            // 
            // gridView3
            // 
            this.gridView3.Name = "gridView3";
            // 
            // ucCongViecPhuTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucCongViecPhuTro";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCViec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCViec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVTu)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTimkiem.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVTu;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnKhongghi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnChonPT;
        public DevExpress.XtraEditors.SimpleButton btnThemSua;
        public DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnTroVe;
        public DevExpress.XtraEditors.SimpleButton btnXoaPT;
        public DevExpress.XtraEditors.SimpleButton btnXoaCV;
        internal DevExpress.XtraEditors.TextEdit txtTimkiem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        public DevExpress.XtraGrid.GridControl grdCViec;
        public DevExpress.XtraGrid.Views.Grid.GridView grvCViec;
        public DevExpress.XtraEditors.SimpleButton btnGhi;
        public DevExpress.XtraGrid.GridControl grdVTu;
    }
}
