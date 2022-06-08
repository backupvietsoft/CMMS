namespace ImportExcels.UserControl
{
    partial class ucKHKDThietBi
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
            this.grdDuLieu = new DevExpress.XtraGrid.GridControl();
            this.grvDL = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcute = new DevExpress.XtraEditors.SimpleButton();
            this.datToDate = new DevExpress.XtraEditors.DateEdit();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.datFromDate = new DevExpress.XtraEditors.DateEdit();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.cmbKho = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTenNhaXuong = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDL)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKho.Properties)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.grdDuLieu, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.datToDate, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDenNgay, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.datFromDate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTuNgay, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbKho, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTenNhaXuong, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(575, 361);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // grdDuLieu
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdDuLieu, 6);
            this.grdDuLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDuLieu.Location = new System.Drawing.Point(3, 53);
            this.grdDuLieu.LookAndFeel.SkinName = "Blue";
            this.grdDuLieu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdDuLieu.MainView = this.grvDL;
            this.grdDuLieu.Name = "grdDuLieu";
            this.grdDuLieu.Size = new System.Drawing.Size(569, 263);
            this.grdDuLieu.TabIndex = 32;
            this.grdDuLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDL});
            // 
            // grvDL
            // 
            this.grvDL.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvDL.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDL.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvDL.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvDL.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvDL.GridControl = this.grdDuLieu;
            this.grvDL.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.grvDL.Name = "grvDL";
            this.grvDL.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvDL.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvDL.OptionsBehavior.Editable = false;
            this.grvDL.OptionsCustomization.AllowRowSizing = true;
            this.grvDL.OptionsLayout.Columns.AddNewColumns = false;
            this.grvDL.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grvDL.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvDL.OptionsView.ShowFooter = true;
            this.grvDL.OptionsView.ShowGroupPanel = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 6);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExcute, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 322);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(569, 36);
            this.tableLayoutPanel2.TabIndex = 37;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ImportExcels.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(482, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 30);
            this.btnThoat.TabIndex = 34;
            this.btnThoat.Text = "Thoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExcute
            // 
            this.btnExcute.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcute.Appearance.Options.UseFont = true;
            this.btnExcute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExcute.Image = global::ImportExcels.Properties.Resources.btnthuchien;
            this.btnExcute.Location = new System.Drawing.Point(392, 3);
            this.btnExcute.LookAndFeel.SkinName = "Blue";
            this.btnExcute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(84, 30);
            this.btnExcute.TabIndex = 30;
            this.btnExcute.Text = "Thực hiện";
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // datToDate
            // 
            this.datToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datToDate.EditValue = null;
            this.datToDate.Location = new System.Drawing.Point(359, 3);
            this.datToDate.Name = "datToDate";
            this.datToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datToDate.Size = new System.Drawing.Size(126, 20);
            this.datToDate.TabIndex = 36;
            this.datToDate.EditValueChanged += new System.EventHandler(this.datToDate_EditValueChanged);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenNgay.Location = new System.Drawing.Point(290, 0);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(63, 25);
            this.lblDenNgay.TabIndex = 34;
            this.lblDenNgay.Text = "Đến ngày";
            this.lblDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datFromDate
            // 
            this.datFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datFromDate.EditValue = null;
            this.datFromDate.Location = new System.Drawing.Point(158, 3);
            this.datFromDate.Name = "datFromDate";
            this.datFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datFromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datFromDate.Size = new System.Drawing.Size(126, 20);
            this.datFromDate.TabIndex = 35;
            this.datFromDate.EditValueChanged += new System.EventHandler(this.datFromDate_EditValueChanged);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuNgay.Location = new System.Drawing.Point(89, 0);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(63, 25);
            this.lblTuNgay.TabIndex = 33;
            this.lblTuNgay.Text = "Từ ngày";
            this.lblTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbKho
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbKho, 3);
            this.cmbKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbKho.Location = new System.Drawing.Point(158, 28);
            this.cmbKho.Name = "cmbKho";
            this.cmbKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKho.Size = new System.Drawing.Size(327, 20);
            this.cmbKho.TabIndex = 31;
            this.cmbKho.EditValueChanged += new System.EventHandler(this.cmbKho_EditValueChanged);
            // 
            // lblTenNhaXuong
            // 
            this.lblTenNhaXuong.AutoSize = true;
            this.lblTenNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNhaXuong.Location = new System.Drawing.Point(89, 25);
            this.lblTenNhaXuong.Name = "lblTenNhaXuong";
            this.lblTenNhaXuong.Size = new System.Drawing.Size(63, 25);
            this.lblTenNhaXuong.TabIndex = 0;
            this.lblTenNhaXuong.Text = "Tên nhà xưởng";
            this.lblTenNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucKHKDThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucKHKDThietBi";
            this.Size = new System.Drawing.Size(575, 361);
            this.Load += new System.EventHandler(this.ucKHKDThietBi_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDL)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKho.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTenNhaXuong;
        private DevExpress.XtraEditors.SimpleButton btnExcute;
        private DevExpress.XtraEditors.LookUpEdit cmbKho;
        private DevExpress.XtraGrid.GridControl grdDuLieu;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDL;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private DevExpress.XtraEditors.DateEdit datFromDate;
        private DevExpress.XtraEditors.DateEdit datToDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}
