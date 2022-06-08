namespace ReportHuda.General
{
    partial class frmFactoryStatistical
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNhaXuong = new System.Windows.Forms.Label();
            this.lblTNgay = new System.Windows.Forms.Label();
            this.lblTenNX = new System.Windows.Forms.Label();
            this.lblDNgay = new System.Windows.Forms.Label();
            this.txtMs_NX = new System.Windows.Forms.TextBox();
            this.txtTen_NX = new System.Windows.Forms.TextBox();
            this.txtTu_Ngay = new DevExpress.XtraEditors.DateEdit();
            this.txtDen_Ngay = new DevExpress.XtraEditors.DateEdit();
            this.cmbOption = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcute = new DevExpress.XtraEditors.SimpleButton();
            this.lblHanBH = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTu_Ngay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTu_Ngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDen_Ngay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDen_Ngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNhaXuong, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTNgay, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTenNX, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDNgay, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtMs_NX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTen_NX, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTu_Ngay, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDen_Ngay, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbOption, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblHanBH, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(785, 569);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 6);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(779, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNhaXuong
            // 
            this.lblNhaXuong.AutoSize = true;
            this.lblNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhaXuong.Location = new System.Drawing.Point(3, 40);
            this.lblNhaXuong.Name = "lblNhaXuong";
            this.lblNhaXuong.Size = new System.Drawing.Size(35, 25);
            this.lblNhaXuong.TabIndex = 1;
            this.lblNhaXuong.Text = "label2";
            this.lblNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTNgay
            // 
            this.lblTNgay.AutoSize = true;
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNgay.Location = new System.Drawing.Point(3, 65);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(35, 25);
            this.lblTNgay.TabIndex = 2;
            this.lblTNgay.Text = "label3";
            this.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenNX
            // 
            this.lblTenNX.AutoSize = true;
            this.lblTenNX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNX.Location = new System.Drawing.Point(264, 40);
            this.lblTenNX.Name = "lblTenNX";
            this.lblTenNX.Size = new System.Drawing.Size(35, 25);
            this.lblTenNX.TabIndex = 3;
            this.lblTenNX.Text = "label4";
            this.lblTenNX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDNgay
            // 
            this.lblDNgay.AutoSize = true;
            this.lblDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNgay.Location = new System.Drawing.Point(264, 65);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(35, 25);
            this.lblDNgay.TabIndex = 4;
            this.lblDNgay.Text = "label5";
            this.lblDNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMs_NX
            // 
            this.txtMs_NX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMs_NX.Enabled = false;
            this.txtMs_NX.Location = new System.Drawing.Point(44, 43);
            this.txtMs_NX.Name = "txtMs_NX";
            this.txtMs_NX.Size = new System.Drawing.Size(214, 21);
            this.txtMs_NX.TabIndex = 5;
            // 
            // txtTen_NX
            // 
            this.txtTen_NX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_NX.Enabled = false;
            this.txtTen_NX.Location = new System.Drawing.Point(305, 43);
            this.txtTen_NX.Name = "txtTen_NX";
            this.txtTen_NX.Size = new System.Drawing.Size(214, 21);
            this.txtTen_NX.TabIndex = 6;
            // 
            // txtTu_Ngay
            // 
            this.txtTu_Ngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTu_Ngay.EditValue = null;
            this.txtTu_Ngay.Location = new System.Drawing.Point(44, 68);
            this.txtTu_Ngay.Name = "txtTu_Ngay";
            this.txtTu_Ngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTu_Ngay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtTu_Ngay.Size = new System.Drawing.Size(214, 20);
            this.txtTu_Ngay.TabIndex = 7;
            this.txtTu_Ngay.EditValueChanged += new System.EventHandler(this.txtTu_Ngay_EditValueChanged);
            this.txtTu_Ngay.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTu_Ngay_EditValueChanging);
            // 
            // txtDen_Ngay
            // 
            this.txtDen_Ngay.AllowDrop = true;
            this.txtDen_Ngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDen_Ngay.EditValue = null;
            this.txtDen_Ngay.Location = new System.Drawing.Point(305, 68);
            this.txtDen_Ngay.Name = "txtDen_Ngay";
            this.txtDen_Ngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDen_Ngay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDen_Ngay.Size = new System.Drawing.Size(214, 20);
            this.txtDen_Ngay.TabIndex = 8;
            this.txtDen_Ngay.EditValueChanged += new System.EventHandler(this.txtDen_Ngay_EditValueChanged);
            this.txtDen_Ngay.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtDen_Ngay_EditValueChanging);
            // 
            // cmbOption
            // 
            this.cmbOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbOption.EditValue = "Hết hạn bảo hành";
            this.cmbOption.Location = new System.Drawing.Point(566, 68);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOption.Properties.Items.AddRange(new object[] {
            "Hết hạn bảo hành",
            "Tới hạn thay"});
            this.cmbOption.Size = new System.Drawing.Size(216, 20);
            this.cmbOption.TabIndex = 10;
            this.cmbOption.SelectedIndexChanged += new System.EventHandler(this.cmbOption_SelectedIndexChanged);
            // 
            // gridControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl1, 6);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 93);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(779, 433);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 6);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnExcute);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 532);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 34);
            this.panel1.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::ReportHuda.Properties.Resources.btnthoat;
            this.btnCancel.Location = new System.Drawing.Point(685, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExcute
            // 
            this.btnExcute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcute.Image = global::ReportHuda.Properties.Resources.btnexcel;
            this.btnExcute.Location = new System.Drawing.Point(590, 3);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(94, 29);
            this.btnExcute.TabIndex = 2;
            this.btnExcute.Text = "btnExcute";
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // lblHanBH
            // 
            this.lblHanBH.AutoSize = true;
            this.lblHanBH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHanBH.Location = new System.Drawing.Point(525, 65);
            this.lblHanBH.Name = "lblHanBH";
            this.lblHanBH.Size = new System.Drawing.Size(35, 25);
            this.lblHanBH.TabIndex = 9;
            this.lblHanBH.Text = "label6";
            this.lblHanBH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmFactoryStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 569);
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmFactoryStatistical";
            this.Text = "frmFactoryStatistical";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFactoryStatistical_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTu_Ngay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTu_Ngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDen_Ngay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDen_Ngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNhaXuong;
        private System.Windows.Forms.Label lblTNgay;
        private System.Windows.Forms.Label lblTenNX;
        private System.Windows.Forms.Label lblDNgay;
        private System.Windows.Forms.TextBox txtMs_NX;
        private System.Windows.Forms.TextBox txtTen_NX;
        private DevExpress.XtraEditors.DateEdit txtTu_Ngay;
        private DevExpress.XtraEditors.DateEdit txtDen_Ngay;
        private System.Windows.Forms.Label lblHanBH;
        private DevExpress.XtraEditors.ComboBoxEdit cmbOption;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnExcute;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
       
    }
}