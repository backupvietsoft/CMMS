namespace MVControl
{
    partial class ucBCThoiGianCVNhanVien
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.prbIN = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.datTNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblTNgay = new System.Windows.Forms.Label();
            this.lblDNgay = new System.Windows.Forms.Label();
            this.datDNgay = new DevExpress.XtraEditors.DateEdit();
            this.cboDonVi = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.cboPhongBan = new DevExpress.XtraEditors.LookUpEdit();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhongBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.prbIN, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.datTNgay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTNgay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDNgay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.datDNgay, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboDonVi, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDonVi, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPhongBan, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboPhongBan, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.grdChung, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 452);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // prbIN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.prbIN, 6);
            this.prbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prbIN.EditValue = "";
            this.prbIN.Location = new System.Drawing.Point(3, 388);
            this.prbIN.Name = "prbIN";
            this.prbIN.Properties.AllowFocused = false;
            this.prbIN.Properties.LookAndFeel.SkinName = "Blue";
            this.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.prbIN.Properties.MarqueeAnimationSpeed = 10;
            this.prbIN.Properties.NullText = "Exporting excel, please wait..\";";
            this.prbIN.Properties.Stopped = true;
            this.prbIN.Size = new System.Drawing.Size(798, 18);
            this.prbIN.TabIndex = 28;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 6);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel5.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnExecute, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 412);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(798, 37);
            this.tableLayoutPanel5.TabIndex = 17;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(691, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 31);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Location = new System.Drawing.Point(581, 3);
            this.btnExecute.LookAndFeel.SkinName = "Blue";
            this.btnExecute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 31);
            this.btnExecute.TabIndex = 9;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // datTNgay
            // 
            this.datTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(219, 18);
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datTNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datTNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.datTNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.datTNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datTNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.datTNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datTNgay.Size = new System.Drawing.Size(178, 20);
            this.datTNgay.TabIndex = 1;
            // 
            // lblTNgay
            // 
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNgay.Location = new System.Drawing.Point(123, 15);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(90, 25);
            this.lblTNgay.TabIndex = 9;
            this.lblTNgay.Text = "lblTNgay";
            this.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDNgay
            // 
            this.lblDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNgay.Location = new System.Drawing.Point(403, 15);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(90, 25);
            this.lblDNgay.TabIndex = 10;
            this.lblDNgay.Text = "lblDNgay";
            this.lblDNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datDNgay
            // 
            this.datDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datDNgay.EditValue = null;
            this.datDNgay.Location = new System.Drawing.Point(499, 18);
            this.datDNgay.Name = "datDNgay";
            this.datDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datDNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datDNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDNgay.Properties.LookAndFeel.SkinName = "Blue";
            this.datDNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.datDNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datDNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.datDNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datDNgay.Size = new System.Drawing.Size(178, 20);
            this.datDNgay.TabIndex = 2;
            // 
            // cboDonVi
            // 
            this.cboDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDonVi.Location = new System.Drawing.Point(219, 43);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDonVi.Properties.LookAndFeel.SkinName = "Blue";
            this.cboDonVi.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDonVi.Properties.NullText = "";
            this.cboDonVi.Size = new System.Drawing.Size(178, 20);
            this.cboDonVi.TabIndex = 5;
            this.cboDonVi.EditValueChanged += new System.EventHandler(this.cboDonVi_EditValueChanged);
            // 
            // lblDonVi
            // 
            this.lblDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonVi.Location = new System.Drawing.Point(123, 40);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(90, 25);
            this.lblDonVi.TabIndex = 9;
            this.lblDonVi.Text = "lblDDiem";
            this.lblDonVi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPhongBan
            // 
            this.lblPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhongBan.Location = new System.Drawing.Point(403, 40);
            this.lblPhongBan.Name = "lblPhongBan";
            this.lblPhongBan.Size = new System.Drawing.Size(90, 25);
            this.lblPhongBan.TabIndex = 9;
            this.lblPhongBan.Text = "lblDChuyen";
            this.lblPhongBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPhongBan.Location = new System.Drawing.Point(499, 43);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPhongBan.Properties.LookAndFeel.SkinName = "Blue";
            this.cboPhongBan.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboPhongBan.Properties.NullText = "";
            this.cboPhongBan.Size = new System.Drawing.Size(178, 20);
            this.cboPhongBan.TabIndex = 5;
            // 
            // grdChung
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdChung, 6);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 76);
            this.grdChung.LookAndFeel.SkinName = "Blue";
            this.grdChung.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.grdChung.Size = new System.Drawing.Size(798, 306);
            this.grdChung.TabIndex = 6;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            this.grdChung.Visible = false;
            // 
            // grvChung
            // 
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvChung.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // ucBCThoiGianCVNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucBCThoiGianCVNhanVien";
            this.Size = new System.Drawing.Size(804, 452);
            this.Load += new System.EventHandler(this.ucBCThoiGianCVNhanVien_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prbIN.Properties)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhongBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.DateEdit datTNgay;
        private System.Windows.Forms.Label lblTNgay;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private System.Windows.Forms.Label lblDNgay;
        private DevExpress.XtraEditors.DateEdit datDNgay;
        private DevExpress.XtraEditors.LookUpEdit cboDonVi;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.Label lblPhongBan;
        private DevExpress.XtraEditors.LookUpEdit cboPhongBan;
        private DevExpress.XtraEditors.MarqueeProgressBarControl prbIN;
    }
}
