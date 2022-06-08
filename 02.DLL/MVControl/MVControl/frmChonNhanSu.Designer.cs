namespace MVControl
{
    partial class frmChonNhanSu
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnALL = new DevExpress.XtraEditors.SimpleButton();
            this.txtTKiem = new DevExpress.XtraEditors.TextEdit();
            this.lblDonvi = new System.Windows.Forms.Label();
            this.grdNhanSu = new DevExpress.XtraGrid.GridControl();
            this.grvNhanSu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblDoi = new System.Windows.Forms.Label();
            this.lblTCong = new System.Windows.Forms.Label();
            this.cboDonVi = new DevExpress.XtraEditors.LookUpEdit();
            this.cboPBan = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTo = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNhanSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhanSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDonvi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdNhanSu, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDoi, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTCong, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboDonVi, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboPBan, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboTo, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTo, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 558);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 9);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.Controls.Add(this.btnThoat, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnExecute, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnNotALL, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnALL, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTKiem, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 519);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(968, 36);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(861, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Location = new System.Drawing.Point(751, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 30);
            this.btnExecute.TabIndex = 9;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnNotALL
            // 
            this.btnNotALL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotALL.Appearance.Options.UseFont = true;
            this.btnNotALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNotALL.Location = new System.Drawing.Point(641, 3);
            this.btnNotALL.LookAndFeel.SkinName = "Blue";
            this.btnNotALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNotALL.Name = "btnNotALL";
            this.btnNotALL.Size = new System.Drawing.Size(104, 30);
            this.btnNotALL.TabIndex = 8;
            this.btnNotALL.Text = "Bỏ chọn";
            this.btnNotALL.Click += new System.EventHandler(this.btnNotALL_Click);
            // 
            // btnALL
            // 
            this.btnALL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALL.Appearance.Options.UseFont = true;
            this.btnALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnALL.Location = new System.Drawing.Point(531, 3);
            this.btnALL.LookAndFeel.SkinName = "Blue";
            this.btnALL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(104, 30);
            this.btnALL.TabIndex = 7;
            this.btnALL.Text = "Chọn hết";
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // txtTKiem
            // 
            this.txtTKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTKiem.Location = new System.Drawing.Point(3, 13);
            this.txtTKiem.Name = "txtTKiem";
            this.txtTKiem.Size = new System.Drawing.Size(174, 20);
            this.txtTKiem.TabIndex = 26;
            this.txtTKiem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTKiem_EditValueChanging);
            // 
            // lblDonvi
            // 
            this.lblDonvi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonvi.Location = new System.Drawing.Point(51, 15);
            this.lblDonvi.Name = "lblDonvi";
            this.lblDonvi.Size = new System.Drawing.Size(91, 25);
            this.lblDonvi.TabIndex = 9;
            this.lblDonvi.Text = "lblDonvi";
            this.lblDonvi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdNhanSu
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdNhanSu, 8);
            this.grdNhanSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNhanSu.Location = new System.Drawing.Point(3, 76);
            this.grdNhanSu.LookAndFeel.SkinName = "Blue";
            this.grdNhanSu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdNhanSu.MainView = this.grvNhanSu;
            this.grdNhanSu.Name = "grdNhanSu";
            this.grdNhanSu.Size = new System.Drawing.Size(968, 437);
            this.grdNhanSu.TabIndex = 6;
            this.grdNhanSu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNhanSu});
            // 
            // grvNhanSu
            // 
            this.grvNhanSu.GridControl = this.grdNhanSu;
            this.grvNhanSu.Name = "grvNhanSu";
            this.grvNhanSu.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvNhanSu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvNhanSu.OptionsView.ShowGroupPanel = false;
            this.grvNhanSu.ShownEditor += new System.EventHandler(this.grvNhanSu_ShownEditor);
            this.grvNhanSu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvNhanSu_MouseDown);
            // 
            // lblDoi
            // 
            this.lblDoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoi.Location = new System.Drawing.Point(342, 15);
            this.lblDoi.Name = "lblDoi";
            this.lblDoi.Size = new System.Drawing.Size(91, 25);
            this.lblDoi.TabIndex = 9;
            this.lblDoi.Text = "lblDoi";
            this.lblDoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTCong
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblTCong, 4);
            this.lblTCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTCong.Location = new System.Drawing.Point(439, 40);
            this.lblTCong.Name = "lblTCong";
            this.lblTCong.Size = new System.Drawing.Size(532, 25);
            this.lblTCong.TabIndex = 9;
            this.lblTCong.Text = "lblLMay";
            this.lblTCong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDonVi
            // 
            this.cboDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDonVi.Location = new System.Drawing.Point(148, 18);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDonVi.Properties.LookAndFeel.SkinName = "Blue";
            this.cboDonVi.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDonVi.Properties.NullText = "";
            this.cboDonVi.Size = new System.Drawing.Size(188, 20);
            this.cboDonVi.TabIndex = 5;
            this.cboDonVi.EditValueChanged += new System.EventHandler(this.cboDonVi_EditValueChanged);
            // 
            // cboPBan
            // 
            this.cboPBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPBan.Location = new System.Drawing.Point(439, 18);
            this.cboPBan.Name = "cboPBan";
            this.cboPBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPBan.Properties.LookAndFeel.SkinName = "Blue";
            this.cboPBan.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboPBan.Properties.NullText = "";
            this.cboPBan.Size = new System.Drawing.Size(188, 20);
            this.cboPBan.TabIndex = 5;
            this.cboPBan.EditValueChanged += new System.EventHandler(this.cboPBan_EditValueChanged);
            // 
            // cboTo
            // 
            this.cboTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTo.Location = new System.Drawing.Point(730, 18);
            this.cboTo.Name = "cboTo";
            this.cboTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTo.Properties.LookAndFeel.SkinName = "Blue";
            this.cboTo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboTo.Properties.NullText = "";
            this.cboTo.Size = new System.Drawing.Size(188, 20);
            this.cboTo.TabIndex = 5;
            this.cboTo.EditValueChanged += new System.EventHandler(this.cboTo_EditValueChanged);
            // 
            // lblTo
            // 
            this.lblTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTo.Location = new System.Drawing.Point(633, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(91, 25);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "lblTo";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmChonNhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 558);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChonNhanSu";
            this.Text = "frmChonNhanSu";
            this.Load += new System.EventHandler(this.frmChonNhanSu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNhanSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhanSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.SimpleButton btnNotALL;
        private DevExpress.XtraEditors.SimpleButton btnALL;
        private DevExpress.XtraEditors.TextEdit txtTKiem;
        private System.Windows.Forms.Label lblDonvi;
        private DevExpress.XtraGrid.GridControl grdNhanSu;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNhanSu;
        private System.Windows.Forms.Label lblDoi;
        private System.Windows.Forms.Label lblTCong;
        private DevExpress.XtraEditors.LookUpEdit cboDonVi;
        private DevExpress.XtraEditors.LookUpEdit cboPBan;
        private DevExpress.XtraEditors.LookUpEdit cboTo;
        private System.Windows.Forms.Label lblTo;
    }
}