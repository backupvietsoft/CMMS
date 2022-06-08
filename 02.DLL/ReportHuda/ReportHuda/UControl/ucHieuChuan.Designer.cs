namespace ReportHuda
{
    partial class ucHieuChuan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHieuChuan));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdHC = new DevExpress.XtraGrid.GridControl();
            this.grvHC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnThemSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.btnChonMay = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.lblTKiem = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grdHC, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 563);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdHC
            // 
            this.grdHC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHC.Location = new System.Drawing.Point(3, 3);
            this.grdHC.LookAndFeel.SkinName = "Blue";
            this.grdHC.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdHC.MainView = this.grvHC;
            this.grdHC.Name = "grdHC";
            this.grdHC.Size = new System.Drawing.Size(774, 515);
            this.grdHC.TabIndex = 8;
            this.grdHC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHC});
            // 
            // grvHC
            // 
            this.grvHC.GridControl = this.grdHC;
            this.grvHC.Name = "grvHC";
            this.grvHC.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvHC.OptionsCustomization.AllowColumnMoving = false;
            this.grvHC.OptionsCustomization.AllowGroup = false;
            this.grvHC.OptionsView.ShowGroupPanel = false;
            this.grvHC.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvHC_CellValueChanged);
            this.grvHC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvHC_KeyDown);
            this.grvHC.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvHC_CellValueChanging);
            this.grvHC.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvHC_InvalidRowException);
            this.grvHC.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvHC_ValidateRow);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnThemSua);
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Controls.Add(this.btnXoa);
            this.panelControl1.Controls.Add(this.btnKhong);
            this.panelControl1.Controls.Add(this.btnChonMay);
            this.panelControl1.Controls.Add(this.btnGhi);
            this.panelControl1.Controls.Add(this.txtTKiem);
            this.panelControl1.Controls.Add(this.lblTKiem);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 524);
            this.panelControl1.LookAndFeel.SkinName = "Blue";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(774, 36);
            this.panelControl1.TabIndex = 7;
            // 
            // btnThemSua
            // 
            this.btnThemSua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemSua.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSua.Appearance.Options.UseFont = true;
            this.btnThemSua.Location = new System.Drawing.Point(451, 0);
            this.btnThemSua.LookAndFeel.SkinName = "Blue";
            this.btnThemSua.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThemSua.Name = "btnThemSua";
            this.btnThemSua.Size = new System.Drawing.Size(107, 36);
            this.btnThemSua.TabIndex = 15;
            this.btnThemSua.Text = "btnThemSua";
            this.btnThemSua.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(667, 0);
            this.btnExit.LookAndFeel.SkinName = "Blue";
            this.btnExit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 36);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Th&oát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Location = new System.Drawing.Point(559, 0);
            this.btnXoa.LookAndFeel.SkinName = "Blue";
            this.btnXoa.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(107, 36);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhong.Appearance.Options.UseFont = true;
            this.btnKhong.Location = new System.Drawing.Point(667, 0);
            this.btnKhong.LookAndFeel.SkinName = "Blue";
            this.btnKhong.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(107, 36);
            this.btnKhong.TabIndex = 20;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Visible = false;
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnChonMay
            // 
            this.btnChonMay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChonMay.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonMay.Appearance.Options.UseFont = true;
            this.btnChonMay.Location = new System.Drawing.Point(451, 0);
            this.btnChonMay.LookAndFeel.SkinName = "Blue";
            this.btnChonMay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnChonMay.Name = "btnChonMay";
            this.btnChonMay.Size = new System.Drawing.Size(107, 36);
            this.btnChonMay.TabIndex = 18;
            this.btnChonMay.Text = "btnChonMay";
            this.btnChonMay.Visible = false;
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGhi.Appearance.Options.UseFont = true;
            this.btnGhi.Location = new System.Drawing.Point(559, 0);
            this.btnGhi.LookAndFeel.SkinName = "Blue";
            this.btnGhi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(107, 36);
            this.btnGhi.TabIndex = 19;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // txtTKiem
            // 
            this.txtTKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTKiem.Location = new System.Drawing.Point(94, 11);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(149, 20);
            this.txtTKiem.TabIndex = 3;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // lblTKiem
            // 
            this.lblTKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTKiem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTKiem.Location = new System.Drawing.Point(5, 12);
            this.lblTKiem.Name = "lblTKiem";
            this.lblTKiem.Size = new System.Drawing.Size(83, 19);
            this.lblTKiem.TabIndex = 0;
            this.lblTKiem.Text = "lblTKiem";
            // 
            // ucHieuChuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucHieuChuan";
            this.Size = new System.Drawing.Size(780, 563);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnThemSua;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.SimpleButton btnChonMay;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private DevExpress.XtraEditors.LabelControl lblTKiem;
        private DevExpress.XtraGrid.GridControl grdHC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHC;
    }
}
