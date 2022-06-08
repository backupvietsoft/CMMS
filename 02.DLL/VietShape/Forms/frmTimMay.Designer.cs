namespace VietShape
{
    partial class frmTimMay
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
            this.grdMay = new DevExpress.XtraGrid.GridControl();
            this.grvMay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.lblLMay = new System.Windows.Forms.Label();
            this.lblNhomMay = new System.Windows.Forms.Label();
            this.cboLMay = new DevExpress.XtraEditors.LookUpEdit();
            this.cboNhomMay = new DevExpress.XtraEditors.LookUpEdit();
            this.btnALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotALL = new DevExpress.XtraEditors.SimpleButton();
            this.chkKhongHM = new DevExpress.XtraEditors.CheckEdit();
            this.chkHangMuc = new DevExpress.XtraEditors.CheckEdit();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKhongHM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHangMuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.grdMay, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTieuDe, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThoat, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnExecute, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblLMay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNhomMay, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboLMay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboNhomMay, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnALL, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnNotALL, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkKhongHM, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkHangMuc, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTKiem, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grdMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdMay, 8);
            this.grdMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMay.Location = new System.Drawing.Point(3, 99);
            this.grdMay.LookAndFeel.SkinName = "Blue";
            this.grdMay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdMay.MainView = this.grvMay;
            this.grdMay.Name = "grdMay";
            this.grdMay.Size = new System.Drawing.Size(878, 423);
            this.grdMay.TabIndex = 4;
            this.grdMay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMay});
            // 
            // grvMay
            // 
            this.grvMay.GridControl = this.grdMay;
            this.grvMay.Name = "grvMay";
            this.grvMay.OptionsBehavior.FocusLeaveOnTab = true;
            this.grvMay.OptionsCustomization.AllowColumnMoving = false;
            this.grvMay.OptionsCustomization.AllowGroup = false;
            this.grvMay.OptionsView.ShowGroupPanel = false;
            this.grvMay.ShownEditor += new System.EventHandler(this.grvMay_ShownEditor);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTieuDe, 8);
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
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(777, 528);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Location = new System.Drawing.Point(667, 528);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblLMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblLMay, 2);
            this.lblLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLMay.Location = new System.Drawing.Point(123, 38);
            this.lblLMay.Name = "lblLMay";
            this.lblLMay.Size = new System.Drawing.Size(114, 25);
            this.lblLMay.TabIndex = 27;
            this.lblLMay.Text = "lblLMay";
            this.lblLMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNhomMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblNhomMay, 2);
            this.lblNhomMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhomMay.Location = new System.Drawing.Point(123, 63);
            this.lblNhomMay.Name = "lblNhomMay";
            this.lblNhomMay.Size = new System.Drawing.Size(114, 25);
            this.lblNhomMay.TabIndex = 27;
            this.lblNhomMay.Text = "lblNhomMay";
            this.lblNhomMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboLMay, 4);
            this.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLMay.Location = new System.Drawing.Point(243, 41);
            this.cboLMay.Name = "cboLMay";
            this.cboLMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLMay.Size = new System.Drawing.Size(528, 20);
            this.cboLMay.TabIndex = 1;
            this.cboLMay.EditValueChanged += new System.EventHandler(this.cboLMay_EditValueChanged);
            // 
            // cboNhomMay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboNhomMay, 4);
            this.cboNhomMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNhomMay.Location = new System.Drawing.Point(243, 66);
            this.cboNhomMay.Name = "cboNhomMay";
            this.cboNhomMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhomMay.Size = new System.Drawing.Size(528, 20);
            this.cboNhomMay.TabIndex = 2;
            this.cboNhomMay.EditValueChanged += new System.EventHandler(this.cboNhomMay_EditValueChanged);
            // 
            // btnALL
            // 
            this.btnALL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALL.Appearance.Options.UseFont = true;
            this.btnALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnALL.Location = new System.Drawing.Point(447, 528);
            this.btnALL.LookAndFeel.SkinName = "Blue";
            this.btnALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(104, 30);
            this.btnALL.TabIndex = 30;
            this.btnALL.Text = "Chọn hết";
            this.btnALL.Visible = false;
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // btnNotALL
            // 
            this.btnNotALL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotALL.Appearance.Options.UseFont = true;
            this.btnNotALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNotALL.Location = new System.Drawing.Point(557, 528);
            this.btnNotALL.LookAndFeel.SkinName = "Blue";
            this.btnNotALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNotALL.Name = "btnNotALL";
            this.btnNotALL.Size = new System.Drawing.Size(104, 30);
            this.btnNotALL.TabIndex = 31;
            this.btnNotALL.Text = "Bỏ chọn";
            this.btnNotALL.Visible = false;
            this.btnNotALL.Click += new System.EventHandler(this.btnNotALL_Click);
            // 
            // chkKhongHM
            // 
            this.chkKhongHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkKhongHM.EditValue = true;
            this.chkKhongHM.Location = new System.Drawing.Point(777, 41);
            this.chkKhongHM.Name = "chkKhongHM";
            this.chkKhongHM.Properties.Caption = "chkKhongHM";
            this.chkKhongHM.Size = new System.Drawing.Size(104, 18);
            this.chkKhongHM.TabIndex = 32;
            this.chkKhongHM.Visible = false;
            this.chkKhongHM.CheckedChanged += new System.EventHandler(this.chkKhongHM_CheckedChanged);
            // 
            // chkHangMuc
            // 
            this.chkHangMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkHangMuc.EditValue = true;
            this.chkHangMuc.Location = new System.Drawing.Point(777, 66);
            this.chkHangMuc.Name = "chkHangMuc";
            this.chkHangMuc.Properties.Caption = "chkHangMuc";
            this.chkHangMuc.Size = new System.Drawing.Size(104, 18);
            this.chkHangMuc.TabIndex = 32;
            this.chkHangMuc.Visible = false;
            this.chkHangMuc.CheckedChanged += new System.EventHandler(this.chkHangMuc_CheckedChanged);
            // 
            // txtTKiem
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTKiem, 2);
            this.txtTKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTKiem.Location = new System.Drawing.Point(3, 538);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(174, 20);
            this.txtTKiem.TabIndex = 5;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // frmTimMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmTimMay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimMay";
            this.Load += new System.EventHandler(this.frmTimMay_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKhongHM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHangMuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdMay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMay;
        private System.Windows.Forms.Label lblTieuDe;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private System.Windows.Forms.Label lblLMay;
        private System.Windows.Forms.Label lblNhomMay;
        private DevExpress.XtraEditors.LookUpEdit cboLMay;
        private DevExpress.XtraEditors.LookUpEdit cboNhomMay;
        private DevExpress.XtraEditors.SimpleButton btnALL;
        private DevExpress.XtraEditors.SimpleButton btnNotALL;
        private DevExpress.XtraEditors.CheckEdit chkKhongHM;
        private DevExpress.XtraEditors.CheckEdit chkHangMuc;
    }
}