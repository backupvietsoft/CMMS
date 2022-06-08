namespace ImportExcels
{
    partial class frmPCBT
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdCN = new DevExpress.XtraGrid.GridControl();
            this.grvCN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTinh = new DevExpress.XtraEditors.TextEdit();
            this.txtQuan = new DevExpress.XtraEditors.TextEdit();
            this.lbQuan = new System.Windows.Forms.Label();
            this.lblTinh = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtMSCN = new DevExpress.XtraEditors.TextEdit();
            this.lblMSCN = new System.Windows.Forms.Label();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuan.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSCN.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 6;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel1.Controls.Add(this.grdCN, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.txtTinh, 4, 1);
            this.TableLayoutPanel1.Controls.Add(this.txtQuan, 2, 1);
            this.TableLayoutPanel1.Controls.Add(this.lbQuan, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.lblTinh, 3, 1);
            this.TableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 4;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(710, 439);
            this.TableLayoutPanel1.TabIndex = 11;
            // 
            // grdCN
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.grdCN, 6);
            this.grdCN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCN.Location = new System.Drawing.Point(3, 60);
            this.grdCN.LookAndFeel.SkinName = "Blue";
            this.grdCN.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdCN.MainView = this.grvCN;
            this.grdCN.Name = "grdCN";
            this.grdCN.Size = new System.Drawing.Size(704, 341);
            this.grdCN.TabIndex = 18;
            this.grdCN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCN});
            // 
            // grvCN
            // 
            this.grvCN.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvCN.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCN.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCN.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCN.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvCN.GridControl = this.grdCN;
            this.grvCN.Name = "grvCN";
            this.grvCN.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvCN.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvCN.OptionsCustomization.AllowColumnMoving = false;
            this.grvCN.OptionsCustomization.AllowRowSizing = true;
            this.grvCN.OptionsLayout.Columns.AddNewColumns = false;
            this.grvCN.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grvCN.OptionsSelection.MultiSelect = true;
            this.grvCN.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvCN.OptionsView.ShowGroupPanel = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.TableLayoutPanel1.SetColumnSpan(this.lblTitle, 6);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(704, 30);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "PHÂN CÔNG BẢO TRÌ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTinh
            // 
            this.txtTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTinh.Location = new System.Drawing.Point(453, 33);
            this.txtTinh.Name = "txtTinh";
            this.txtTinh.Properties.MaxLength = 100;
            this.txtTinh.Properties.ReadOnly = true;
            this.txtTinh.Size = new System.Drawing.Size(201, 20);
            this.txtTinh.TabIndex = 13;
            // 
            // txtQuan
            // 
            this.txtQuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuan.Location = new System.Drawing.Point(150, 33);
            this.txtQuan.Name = "txtQuan";
            this.txtQuan.Properties.MaxLength = 100;
            this.txtQuan.Properties.ReadOnly = true;
            this.txtQuan.Size = new System.Drawing.Size(201, 20);
            this.txtQuan.TabIndex = 12;
            // 
            // lbQuan
            // 
            this.lbQuan.AutoSize = true;
            this.lbQuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbQuan.Location = new System.Drawing.Point(54, 30);
            this.lbQuan.Name = "lbQuan";
            this.lbQuan.Size = new System.Drawing.Size(90, 27);
            this.lbQuan.TabIndex = 11;
            this.lbQuan.Text = "Quận";
            this.lbQuan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTinh
            // 
            this.lblTinh.AutoSize = true;
            this.lblTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTinh.Location = new System.Drawing.Point(357, 30);
            this.lblTinh.Name = "lblTinh";
            this.lblTinh.Size = new System.Drawing.Size(90, 27);
            this.lblTinh.TabIndex = 10;
            this.lblTinh.Text = "Tỉnh";
            this.lblTinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.panel2, 6);
            this.panel2.Controls.Add(this.txtTen);
            this.panel2.Controls.Add(this.lblTen);
            this.panel2.Controls.Add(this.txtMSCN);
            this.panel2.Controls.Add(this.lblMSCN);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnKhong);
            this.panel2.Controls.Add(this.btnThoat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 407);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(704, 29);
            this.panel2.TabIndex = 17;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(178, 6);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(93, 20);
            this.txtTen.TabIndex = 21;
            this.txtTen.EditValueChanged += new System.EventHandler(this.txtTen_EditValueChanged);
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(147, 9);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(25, 13);
            this.lblTen.TabIndex = 20;
            this.lblTen.Text = "Ten";
            this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMSCN
            // 
            this.txtMSCN.Location = new System.Drawing.Point(48, 6);
            this.txtMSCN.Name = "txtMSCN";
            this.txtMSCN.Size = new System.Drawing.Size(93, 20);
            this.txtMSCN.TabIndex = 19;
            this.txtMSCN.EditValueChanged += new System.EventHandler(this.txtMSCN_EditValueChanged);
            // 
            // lblMSCN
            // 
            this.lblMSCN.AutoSize = true;
            this.lblMSCN.Location = new System.Drawing.Point(9, 10);
            this.lblMSCN.Name = "lblMSCN";
            this.lblMSCN.Size = new System.Drawing.Size(35, 13);
            this.lblMSCN.TabIndex = 18;
            this.lblMSCN.Text = "MSCN";
            this.lblMSCN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThem.Location = new System.Drawing.Point(300, 0);
            this.btnThem.LookAndFeel.SkinName = "Blue";
            this.btnThem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(101, 29);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm &Sua";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(401, 0);
            this.btnSave.LookAndFeel.SkinName = "Blue";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 29);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhong.Appearance.Options.UseFont = true;
            this.btnKhong.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKhong.Enabled = false;
            this.btnKhong.Location = new System.Drawing.Point(502, 0);
            this.btnKhong.LookAndFeel.SkinName = "Blue";
            this.btnKhong.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(101, 29);
            this.btnKhong.TabIndex = 7;
            this.btnKhong.Text = "&Hủy";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.Location = new System.Drawing.Point(603, 0);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(101, 29);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmPCBT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 439);
            this.Controls.Add(this.TableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimumSize = new System.Drawing.Size(718, 466);
            this.Name = "frmPCBT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPCBT";
            this.Load += new System.EventHandler(this.frmPCBT_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuan.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSCN.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdCN;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCN;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.TextEdit txtTinh;
        private DevExpress.XtraEditors.TextEdit txtQuan;
        private System.Windows.Forms.Label lbQuan;
        private System.Windows.Forms.Label lblTinh;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.Label lblMSCN;
        private DevExpress.XtraEditors.TextEdit txtMSCN;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private System.Windows.Forms.Label lblTen;
    }
}