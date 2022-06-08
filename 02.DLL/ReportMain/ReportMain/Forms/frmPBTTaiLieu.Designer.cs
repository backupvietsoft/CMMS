namespace ReportMain
{
    partial class frmPBTTaiLieu
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
            this.grdTaiLieuPBT = new DevExpress.XtraGrid.GridControl();
            this.grvTaiLieuPBT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMSPBT = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXemTL = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.lblMSPBT1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTaiLieuPBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTaiLieuPBT)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.Controls.Add(this.grdTaiLieuPBT, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTieuDe, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMSPBT, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMSPBT1, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grdTaiLieuPBT
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdTaiLieuPBT, 9);
            this.grdTaiLieuPBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTaiLieuPBT.Location = new System.Drawing.Point(3, 66);
            this.grdTaiLieuPBT.LookAndFeel.SkinName = "Blue";
            this.grdTaiLieuPBT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdTaiLieuPBT.MainView = this.grvTaiLieuPBT;
            this.grdTaiLieuPBT.Name = "grdTaiLieuPBT";
            this.grdTaiLieuPBT.Size = new System.Drawing.Size(878, 456);
            this.grdTaiLieuPBT.TabIndex = 4;
            this.grdTaiLieuPBT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTaiLieuPBT});
            // 
            // grvTaiLieuPBT
            // 
            this.grvTaiLieuPBT.GridControl = this.grdTaiLieuPBT;
            this.grvTaiLieuPBT.Name = "grvTaiLieuPBT";
            this.grvTaiLieuPBT.OptionsBehavior.FocusLeaveOnTab = true;
            this.grvTaiLieuPBT.OptionsCustomization.AllowColumnMoving = false;
            this.grvTaiLieuPBT.OptionsCustomization.AllowGroup = false;
            this.grvTaiLieuPBT.OptionsView.ShowGroupPanel = false;
            this.grvTaiLieuPBT.DoubleClick += new System.EventHandler(this.grvTaiLieuPBT_DoubleClick);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTieuDe, 9);
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Navy;
            this.lblTieuDe.Location = new System.Drawing.Point(3, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(878, 38);
            this.lblTieuDe.TabIndex = 11;
            this.lblTieuDe.Text = "lblTieuDe";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMSPBT
            // 
            this.lblMSPBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMSPBT.Location = new System.Drawing.Point(123, 38);
            this.lblMSPBT.Name = "lblMSPBT";
            this.lblMSPBT.Size = new System.Drawing.Size(114, 25);
            this.lblMSPBT.TabIndex = 27;
            this.lblMSPBT.Text = "lblMSPBT";
            this.lblMSPBT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 9);
            this.panel1.Controls.Add(this.btnXemTL);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnKhongGhi);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 528);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 30);
            this.panel1.TabIndex = 32;
            // 
            // btnXemTL
            // 
            this.btnXemTL.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnXemTL.Location = new System.Drawing.Point(438, 0);
            this.btnXemTL.LookAndFeel.SkinName = "Blue";
            this.btnXemTL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXemTL.Name = "btnXemTL";
            this.btnXemTL.Size = new System.Drawing.Size(104, 30);
            this.btnXemTL.TabIndex = 35;
            this.btnXemTL.Text = "btnXemTL";
            this.btnXemTL.Click += new System.EventHandler(this.btnXemTL_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(878, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 30);
            this.panel2.TabIndex = 32;
            // 
            // btnThem
            // 
            this.btnThem.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnThem.Location = new System.Drawing.Point(548, 0);
            this.btnThem.LookAndFeel.SkinName = "Blue";
            this.btnThem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(104, 30);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnXoa.Location = new System.Drawing.Point(658, 0);
            this.btnXoa.LookAndFeel.SkinName = "Blue";
            this.btnXoa.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(104, 30);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Image = global::ReportMain.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(768, 0);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnKhongGhi
            // 
            this.btnKhongGhi.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnKhongGhi.Location = new System.Drawing.Point(768, 0);
            this.btnKhongGhi.LookAndFeel.SkinName = "Blue";
            this.btnKhongGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKhongGhi.Name = "btnKhongGhi";
            this.btnKhongGhi.Size = new System.Drawing.Size(104, 30);
            this.btnKhongGhi.TabIndex = 30;
            this.btnKhongGhi.Text = "Không ghi";
            this.btnKhongGhi.Visible = false;
            this.btnKhongGhi.Click += new System.EventHandler(this.btnKhongGhi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Image = global::ReportMain.Properties.Resources.btnthuchien;
            this.btnGhi.Location = new System.Drawing.Point(658, 0);
            this.btnGhi.LookAndFeel.SkinName = "Blue";
            this.btnGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(104, 30);
            this.btnGhi.TabIndex = 31;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // lblMSPBT1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblMSPBT1, 2);
            this.lblMSPBT1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMSPBT1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSPBT1.Location = new System.Drawing.Point(243, 38);
            this.lblMSPBT1.Name = "lblMSPBT1";
            this.lblMSPBT1.Size = new System.Drawing.Size(188, 25);
            this.lblMSPBT1.TabIndex = 27;
            this.lblMSPBT1.Text = "lblMSPBT1";
            this.lblMSPBT1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPBTTaiLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "frmPBTTaiLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPBTTaiLieu";
            this.Load += new System.EventHandler(this.frmPBTTaiLieu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTaiLieuPBT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTaiLieuPBT)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdTaiLieuPBT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTaiLieuPBT;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMSPBT;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnKhongGhi;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.Label lblMSPBT1;
        private DevExpress.XtraEditors.SimpleButton btnXemTL;
    }
}