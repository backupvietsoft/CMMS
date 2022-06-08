namespace ImportExcels.UserControl
{
    partial class ucPCBT
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdCN = new DevExpress.XtraGrid.GridControl();
            this.grvCN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtNhomTB = new DevExpress.XtraEditors.TextEdit();
            this.txtLoaiTB = new DevExpress.XtraEditors.TextEdit();
            this.lbQuan = new System.Windows.Forms.Label();
            this.lblTinh = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnKGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomTB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoaiTB.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.TableLayoutPanel1.Controls.Add(this.txtNhomTB, 4, 1);
            this.TableLayoutPanel1.Controls.Add(this.txtLoaiTB, 2, 1);
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
            this.TableLayoutPanel1.Size = new System.Drawing.Size(718, 466);
            this.TableLayoutPanel1.TabIndex = 10;
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
            this.grdCN.Size = new System.Drawing.Size(712, 368);
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
            this.lblTitle.Size = new System.Drawing.Size(712, 30);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "PHÂN CÔNG BẢO TRÌ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNhomTB
            // 
            this.txtNhomTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNhomTB.Location = new System.Drawing.Point(457, 33);
            this.txtNhomTB.Name = "txtNhomTB";
            this.txtNhomTB.Properties.MaxLength = 100;
            this.txtNhomTB.Properties.ReadOnly = true;
            this.txtNhomTB.Size = new System.Drawing.Size(204, 20);
            this.txtNhomTB.TabIndex = 13;
            // 
            // txtLoaiTB
            // 
            this.txtLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLoaiTB.Location = new System.Drawing.Point(151, 33);
            this.txtLoaiTB.Name = "txtLoaiTB";
            this.txtLoaiTB.Properties.MaxLength = 100;
            this.txtLoaiTB.Properties.ReadOnly = true;
            this.txtLoaiTB.Size = new System.Drawing.Size(204, 20);
            this.txtLoaiTB.TabIndex = 12;
            // 
            // lbQuan
            // 
            this.lbQuan.AutoSize = true;
            this.lbQuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbQuan.Location = new System.Drawing.Point(55, 30);
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
            this.lblTinh.Location = new System.Drawing.Point(361, 30);
            this.lblTinh.Name = "lblTinh";
            this.lblTinh.Size = new System.Drawing.Size(90, 27);
            this.lblTinh.TabIndex = 10;
            this.lblTinh.Text = "Tỉnh";
            this.lblTinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.panel2, 6);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnKGhi);
            this.panel2.Controls.Add(this.btnGhi);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 434);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 29);
            this.panel2.TabIndex = 17;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Location = new System.Drawing.Point(611, 0);
            this.btnExit.LookAndFeel.SkinName = "Blue";
            this.btnExit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 29);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Th&oát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnKGhi
            // 
            this.btnKGhi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKGhi.Appearance.Options.UseFont = true;
            this.btnKGhi.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnKGhi.Enabled = false;
            this.btnKGhi.Location = new System.Drawing.Point(202, 0);
            this.btnKGhi.LookAndFeel.SkinName = "Blue";
            this.btnKGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKGhi.Name = "btnKGhi";
            this.btnKGhi.Size = new System.Drawing.Size(101, 29);
            this.btnKGhi.TabIndex = 16;
            this.btnKGhi.Text = "&Hủy";
            this.btnKGhi.Click += new System.EventHandler(this.btnKGhi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGhi.Appearance.Options.UseFont = true;
            this.btnGhi.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGhi.Enabled = false;
            this.btnGhi.Location = new System.Drawing.Point(101, 0);
            this.btnGhi.LookAndFeel.SkinName = "Blue";
            this.btnGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(101, 29);
            this.btnGhi.TabIndex = 7;
            this.btnGhi.Text = "&Lưu";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThem.Location = new System.Drawing.Point(0, 0);
            this.btnThem.LookAndFeel.SkinName = "Blue";
            this.btnThem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(101, 29);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "&ThêmSua";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.textEdit1, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(-97, 3);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.MaxLength = 100;
            this.textEdit1.Size = new System.Drawing.Size(196, 20);
            this.textEdit1.TabIndex = 12;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(109, 30);
            this.gridControl1.LookAndFeel.SkinName = "Blue";
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(224, 1);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowRowSizing = true;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // ucPCBT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimumSize = new System.Drawing.Size(718, 466);
            this.Name = "ucPCBT";
            this.Size = new System.Drawing.Size(718, 466);
            this.Load += new System.EventHandler(this.ucPCBT_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomTB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoaiTB.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private System.Windows.Forms.Label lbQuan;
        private System.Windows.Forms.Label lblTinh;
        private DevExpress.XtraEditors.TextEdit txtLoaiTB;
        private DevExpress.XtraEditors.TextEdit txtNhomTB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnKGhi;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl grdCN;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCN;
    }
}
