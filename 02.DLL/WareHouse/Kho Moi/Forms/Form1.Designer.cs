namespace WareHouse.Forms
{
    partial class Form1
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
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SplitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.TableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnLockPhieuXuat = new DevExpress.XtraEditors.SimpleButton();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnXoaVTPT = new DevExpress.XtraEditors.SimpleButton();
            this.btnTroVe = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaPhieu = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnLock = new DevExpress.XtraEditors.SimpleButton();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.btnChon_Vat_Tu = new DevExpress.XtraEditors.SimpleButton();
            this.btnKHONG_GHI = new DevExpress.XtraEditors.SimpleButton();
            this.BtnIN = new DevExpress.XtraEditors.SimpleButton();
            this.btnGHI = new DevExpress.XtraEditors.SimpleButton();
            this.btnSUA = new DevExpress.XtraEditors.SimpleButton();
            this.btnTHOAT_CT = new DevExpress.XtraEditors.SimpleButton();
            this.btnXOA = new DevExpress.XtraEditors.SimpleButton();
            this.BtnTHEM = new DevExpress.XtraEditors.SimpleButton();
            this.TableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.SplitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tblCondition = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1)).BeginInit();
            this.SplitContainerControl1.SuspendLayout();
            this.TableLayoutPanel5.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.TableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl2)).BeginInit();
            this.SplitContainerControl2.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView5
            // 
            this.gridView5.Name = "gridView5";
            // 
            // gridView6
            // 
            this.gridView6.Name = "gridView6";
            // 
            // SplitContainerControl1
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.SplitContainerControl1, 3);
            this.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.SplitContainerControl1.Location = new System.Drawing.Point(3, 41);
            this.SplitContainerControl1.Name = "SplitContainerControl1";
            this.SplitContainerControl1.Panel2.Controls.Add(this.TableLayoutPanel5);
            this.TableLayoutPanel1.SetRowSpan(this.SplitContainerControl1, 2);
            this.SplitContainerControl1.Size = new System.Drawing.Size(1100, 437);
            this.SplitContainerControl1.SplitterPosition = 195;
            this.SplitContainerControl1.TabIndex = 65;
            // 
            // TableLayoutPanel5
            // 
            this.TableLayoutPanel5.ColumnCount = 1;
            this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel5.Controls.Add(this.TableLayoutPanel6, 0, 1);
            this.TableLayoutPanel5.Controls.Add(this.Panel2, 0, 2);
            this.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel5.Name = "TableLayoutPanel5";
            this.TableLayoutPanel5.RowCount = 3;
            this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel5.Size = new System.Drawing.Size(899, 437);
            this.TableLayoutPanel5.TabIndex = 0;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Panel4);
            this.Panel2.Controls.Add(this.btnUnLock);
            this.Panel2.Controls.Add(this.Panel1);
            this.Panel2.Controls.Add(this.btnLockPhieuXuat);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(3, 397);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(893, 37);
            this.Panel2.TabIndex = 62;
            // 
            // btnLockPhieuXuat
            // 
            this.btnLockPhieuXuat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLockPhieuXuat.Enabled = false;
            this.btnLockPhieuXuat.Location = new System.Drawing.Point(-241, 4);
            this.btnLockPhieuXuat.Name = "btnLockPhieuXuat";
            this.btnLockPhieuXuat.Size = new System.Drawing.Size(123, 31);
            this.btnLockPhieuXuat.TabIndex = 57;
            this.btnLockPhieuXuat.Text = "Lock phiếu xuất ";
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.Controls.Add(this.btnXoaPhieu);
            this.Panel1.Controls.Add(this.btnTroVe);
            this.Panel1.Controls.Add(this.btnXoaVTPT);
            this.Panel1.Location = new System.Drawing.Point(508, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(383, 33);
            this.Panel1.TabIndex = 61;
            // 
            // btnXoaVTPT
            // 
            this.btnXoaVTPT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaVTPT.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaVTPT.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoaVTPT.Appearance.Options.UseFont = true;
            this.btnXoaVTPT.Appearance.Options.UseForeColor = true;
            this.btnXoaVTPT.Location = new System.Drawing.Point(192, 1);
            this.btnXoaVTPT.Name = "btnXoaVTPT";
            this.btnXoaVTPT.Size = new System.Drawing.Size(95, 31);
            this.btnXoaVTPT.TabIndex = 59;
            this.btnXoaVTPT.Text = "Xóa VT-PT";
            // 
            // btnTroVe
            // 
            this.btnTroVe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTroVe.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnTroVe.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTroVe.Appearance.Options.UseFont = true;
            this.btnTroVe.Appearance.Options.UseForeColor = true;
            this.btnTroVe.Location = new System.Drawing.Point(287, 1);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(95, 31);
            this.btnTroVe.TabIndex = 60;
            this.btnTroVe.Text = "Trở về";
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaPhieu.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaPhieu.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoaPhieu.Appearance.Options.UseFont = true;
            this.btnXoaPhieu.Appearance.Options.UseForeColor = true;
            this.btnXoaPhieu.Location = new System.Drawing.Point(97, 1);
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.Size = new System.Drawing.Size(95, 31);
            this.btnXoaPhieu.TabIndex = 58;
            this.btnXoaPhieu.Text = "Xóa phiếu";
            // 
            // btnUnLock
            // 
            this.btnUnLock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnLock.Location = new System.Drawing.Point(-241, 4);
            this.btnUnLock.Name = "btnUnLock";
            this.btnUnLock.Size = new System.Drawing.Size(123, 31);
            this.btnUnLock.TabIndex = 64;
            this.btnUnLock.Text = "btnUnLock";
            this.btnUnLock.Visible = false;
            // 
            // Panel4
            // 
            this.Panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel4.Controls.Add(this.BtnTHEM);
            this.Panel4.Controls.Add(this.btnXOA);
            this.Panel4.Controls.Add(this.btnTHOAT_CT);
            this.Panel4.Controls.Add(this.btnSUA);
            this.Panel4.Controls.Add(this.btnGHI);
            this.Panel4.Controls.Add(this.BtnIN);
            this.Panel4.Controls.Add(this.btnKHONG_GHI);
            this.Panel4.Controls.Add(this.btnChon_Vat_Tu);
            this.Panel4.Location = new System.Drawing.Point(342, 1);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(548, 36);
            this.Panel4.TabIndex = 62;
            // 
            // btnChon_Vat_Tu
            // 
            this.btnChon_Vat_Tu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChon_Vat_Tu.Enabled = false;
            this.btnChon_Vat_Tu.Location = new System.Drawing.Point(229, 3);
            this.btnChon_Vat_Tu.Name = "btnChon_Vat_Tu";
            this.btnChon_Vat_Tu.Size = new System.Drawing.Size(123, 31);
            this.btnChon_Vat_Tu.TabIndex = 17;
            this.btnChon_Vat_Tu.Text = "Chọn vật tư xuất ";
            // 
            // btnKHONG_GHI
            // 
            this.btnKHONG_GHI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKHONG_GHI.Location = new System.Drawing.Point(449, 3);
            this.btnKHONG_GHI.Name = "btnKHONG_GHI";
            this.btnKHONG_GHI.Size = new System.Drawing.Size(95, 31);
            this.btnKHONG_GHI.TabIndex = 25;
            this.btnKHONG_GHI.Text = "Không ghi";
            this.btnKHONG_GHI.Visible = false;
            // 
            // BtnIN
            // 
            this.BtnIN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnIN.Location = new System.Drawing.Point(257, 3);
            this.BtnIN.Name = "BtnIN";
            this.BtnIN.Size = new System.Drawing.Size(95, 31);
            this.BtnIN.TabIndex = 21;
            this.BtnIN.Text = "&In";
            // 
            // btnGHI
            // 
            this.btnGHI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGHI.Location = new System.Drawing.Point(353, 3);
            this.btnGHI.Name = "btnGHI";
            this.btnGHI.Size = new System.Drawing.Size(95, 31);
            this.btnGHI.TabIndex = 24;
            this.btnGHI.Text = "Ghi";
            this.btnGHI.Visible = false;
            // 
            // btnSUA
            // 
            this.btnSUA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSUA.Location = new System.Drawing.Point(161, 3);
            this.btnSUA.Name = "btnSUA";
            this.btnSUA.Size = new System.Drawing.Size(95, 31);
            this.btnSUA.TabIndex = 20;
            this.btnSUA.Text = "&Sửa";
            // 
            // btnTHOAT_CT
            // 
            this.btnTHOAT_CT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTHOAT_CT.Location = new System.Drawing.Point(449, 3);
            this.btnTHOAT_CT.Name = "btnTHOAT_CT";
            this.btnTHOAT_CT.Size = new System.Drawing.Size(95, 31);
            this.btnTHOAT_CT.TabIndex = 23;
            this.btnTHOAT_CT.Text = "Thoát";
            // 
            // btnXOA
            // 
            this.btnXOA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXOA.Location = new System.Drawing.Point(353, 3);
            this.btnXOA.Name = "btnXOA";
            this.btnXOA.Size = new System.Drawing.Size(95, 31);
            this.btnXOA.TabIndex = 22;
            this.btnXOA.Text = "&Xóa";
            // 
            // BtnTHEM
            // 
            this.BtnTHEM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnTHEM.Location = new System.Drawing.Point(65, 3);
            this.BtnTHEM.Name = "BtnTHEM";
            this.BtnTHEM.Size = new System.Drawing.Size(95, 31);
            this.BtnTHEM.TabIndex = 18;
            this.BtnTHEM.Text = "&Thêm";
            // 
            // TableLayoutPanel6
            // 
            this.TableLayoutPanel6.ColumnCount = 2;
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.TableLayoutPanel6.Controls.Add(this.SplitContainerControl2, 0, 0);
            this.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel6.Location = new System.Drawing.Point(3, 193);
            this.TableLayoutPanel6.Name = "TableLayoutPanel6";
            this.TableLayoutPanel6.RowCount = 1;
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel6.Size = new System.Drawing.Size(893, 198);
            this.TableLayoutPanel6.TabIndex = 1;
            // 
            // SplitContainerControl2
            // 
            this.TableLayoutPanel6.SetColumnSpan(this.SplitContainerControl2, 2);
            this.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.SplitContainerControl2.Location = new System.Drawing.Point(3, 3);
            this.SplitContainerControl2.Name = "SplitContainerControl2";
            this.SplitContainerControl2.Panel1.Text = "Panel1";
            this.SplitContainerControl2.Panel2.Text = "Panel2";
            this.SplitContainerControl2.Size = new System.Drawing.Size(887, 192);
            this.SplitContainerControl2.SplitterPosition = 520;
            this.SplitContainerControl2.TabIndex = 74;
            this.SplitContainerControl2.Text = "SplitContainerControl2";
            // 
            // TableLayoutPanel4
            // 
            this.TableLayoutPanel4.ColumnCount = 2;
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel4.Location = new System.Drawing.Point(1039, 3);
            this.TableLayoutPanel4.Name = "TableLayoutPanel4";
            this.TableLayoutPanel4.RowCount = 1;
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel4.Size = new System.Drawing.Size(64, 32);
            this.TableLayoutPanel4.TabIndex = 64;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 3;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Controls.Add(this.tblCondition, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel4, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.SplitContainerControl1, 0, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1106, 481);
            this.TableLayoutPanel1.TabIndex = 64;
            // 
            // tblCondition
            // 
            this.tblCondition.ColumnCount = 7;
            this.TableLayoutPanel1.SetColumnSpan(this.tblCondition, 2);
            this.tblCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCondition.Location = new System.Drawing.Point(3, 3);
            this.tblCondition.Name = "tblCondition";
            this.tblCondition.RowCount = 1;
            this.tblCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCondition.Size = new System.Drawing.Size(1030, 32);
            this.tblCondition.TabIndex = 63;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 481);
            this.Controls.Add(this.TableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1)).EndInit();
            this.SplitContainerControl1.ResumeLayout(false);
            this.TableLayoutPanel5.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.TableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl2)).EndInit();
            this.SplitContainerControl2.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        internal DevExpress.XtraEditors.SplitContainerControl SplitContainerControl1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.TableLayoutPanel tblCondition;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel4;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel5;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel6;
        internal DevExpress.XtraEditors.SplitContainerControl SplitContainerControl2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel Panel4;
        internal DevExpress.XtraEditors.SimpleButton BtnTHEM;
        internal DevExpress.XtraEditors.SimpleButton btnXOA;
        internal DevExpress.XtraEditors.SimpleButton btnTHOAT_CT;
        internal DevExpress.XtraEditors.SimpleButton btnSUA;
        internal DevExpress.XtraEditors.SimpleButton btnGHI;
        internal DevExpress.XtraEditors.SimpleButton BtnIN;
        internal DevExpress.XtraEditors.SimpleButton btnKHONG_GHI;
        internal DevExpress.XtraEditors.SimpleButton btnChon_Vat_Tu;
        internal DevExpress.XtraEditors.SimpleButton btnUnLock;
        internal System.Windows.Forms.Panel Panel1;
        internal DevExpress.XtraEditors.SimpleButton btnXoaPhieu;
        internal DevExpress.XtraEditors.SimpleButton btnTroVe;
        internal DevExpress.XtraEditors.SimpleButton btnXoaVTPT;
        internal DevExpress.XtraEditors.SimpleButton btnLockPhieuXuat;
    }
}