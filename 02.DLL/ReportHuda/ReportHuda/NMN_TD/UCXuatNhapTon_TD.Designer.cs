namespace ReportHuda.NMN_TD
{
    partial class UCXuatNhapTon_TD
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
            this.txtFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.txtTo = new DevExpress.XtraEditors.DateEdit();
            this.lblKho = new System.Windows.Forms.Label();
            this.cmbKho = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExcute = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKho.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.Controls.Add(this.txtFrom, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTuNgay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDenNgay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTo, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKho, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbKho, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 418);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtFrom
            // 
            this.txtFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFrom.EditValue = null;
            this.txtFrom.Location = new System.Drawing.Point(176, 18);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFrom.Properties.LookAndFeel.SkinName = "Blue";
            this.txtFrom.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFrom.Size = new System.Drawing.Size(199, 20);
            this.txtFrom.TabIndex = 3;
            this.txtFrom.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtFrom_EditValueChanging);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuNgay.Location = new System.Drawing.Point(87, 15);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(83, 25);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "lblTuNgay";
            this.lblTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenNgay.Location = new System.Drawing.Point(381, 15);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(83, 25);
            this.lblDenNgay.TabIndex = 1;
            this.lblDenNgay.Text = "lblDenNgay";
            this.lblDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTo
            // 
            this.txtTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTo.EditValue = null;
            this.txtTo.Location = new System.Drawing.Point(470, 18);
            this.txtTo.Name = "txtTo";
            this.txtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTo.Properties.LookAndFeel.SkinName = "Blue";
            this.txtTo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtTo.Size = new System.Drawing.Size(199, 20);
            this.txtTo.TabIndex = 7;
            this.txtTo.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTo_EditValueChanging);
            // 
            // lblKho
            // 
            this.lblKho.AutoSize = true;
            this.lblKho.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKho.Location = new System.Drawing.Point(87, 40);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(83, 26);
            this.lblKho.TabIndex = 2;
            this.lblKho.Text = "lblKho";
            this.lblKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbKho
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbKho, 3);
            this.cmbKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbKho.Location = new System.Drawing.Point(176, 43);
            this.cmbKho.Name = "cmbKho";
            this.cmbKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKho.Properties.LookAndFeel.SkinName = "Blue";
            this.cmbKho.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmbKho.Size = new System.Drawing.Size(493, 20);
            this.cmbKho.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 6);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.Controls.Add(this.btnExcute, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 379);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(750, 36);
            this.tableLayoutPanel2.TabIndex = 37;
            // 
            // btnExcute
            // 
            this.btnExcute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExcute.Image = global::ReportHuda.Properties.Resources.btnthuchien;
            this.btnExcute.Location = new System.Drawing.Point(533, 3);
            this.btnExcute.LookAndFeel.SkinName = "Blue";
            this.btnExcute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(104, 30);
            this.btnExcute.TabIndex = 6;
            this.btnExcute.Text = "Thực hiện";
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ReportHuda.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(643, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 36;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // UCXuatNhapTon_TD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "UCXuatNhapTon_TD";
            this.Size = new System.Drawing.Size(756, 418);
            this.Load += new System.EventHandler(this.UCXuatNhapTon_TD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKho.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblKho;
        private DevExpress.XtraEditors.DateEdit txtFrom;
        private DevExpress.XtraEditors.LookUpEdit cmbKho;
        private DevExpress.XtraEditors.SimpleButton btnExcute;
        private DevExpress.XtraEditors.DateEdit txtTo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}
