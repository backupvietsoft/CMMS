namespace ReportHuda.Colgate
{
    partial class ucMaintainMonth
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
            this.datFromDate = new DevExpress.XtraEditors.DateEdit();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.cmbNhaXuong = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbCatmachine = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNhaXuong = new System.Windows.Forms.Label();
            this.lblCatMachine = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcute = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhaXuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCatmachine.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.datFromDate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTuNgay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbNhaXuong, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbCatmachine, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNhaXuong, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCatMachine, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(415, 229);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // datFromDate
            // 
            this.datFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datFromDate.EditValue = null;
            this.datFromDate.Location = new System.Drawing.Point(114, 18);
            this.datFromDate.Name = "datFromDate";
            this.datFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFromDate.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.datFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datFromDate.Properties.EditFormat.FormatString = "MM/yyyy";
            this.datFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datFromDate.Properties.Mask.EditMask = "MM/yyyy";
            this.datFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.datFromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datFromDate.Size = new System.Drawing.Size(89, 20);
            this.datFromDate.TabIndex = 6;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuNgay.Location = new System.Drawing.Point(65, 15);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(43, 25);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            this.lblTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbNhaXuong
            // 
            this.cmbNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNhaXuong.Location = new System.Drawing.Point(114, 43);
            this.cmbNhaXuong.Name = "cmbNhaXuong";
            this.cmbNhaXuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNhaXuong.Size = new System.Drawing.Size(89, 20);
            this.cmbNhaXuong.TabIndex = 33;
            // 
            // cmbCatmachine
            // 
            this.cmbCatmachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCatmachine.Location = new System.Drawing.Point(258, 43);
            this.cmbCatmachine.Name = "cmbCatmachine";
            this.cmbCatmachine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCatmachine.Size = new System.Drawing.Size(89, 20);
            this.cmbCatmachine.TabIndex = 31;
            // 
            // lblNhaXuong
            // 
            this.lblNhaXuong.AutoSize = true;
            this.lblNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhaXuong.Location = new System.Drawing.Point(65, 40);
            this.lblNhaXuong.Name = "lblNhaXuong";
            this.lblNhaXuong.Size = new System.Drawing.Size(43, 25);
            this.lblNhaXuong.TabIndex = 34;
            this.lblNhaXuong.Text = "Nhà xưởng";
            this.lblNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCatMachine
            // 
            this.lblCatMachine.AutoSize = true;
            this.lblCatMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCatMachine.Location = new System.Drawing.Point(209, 40);
            this.lblCatMachine.Name = "lblCatMachine";
            this.lblCatMachine.Size = new System.Drawing.Size(43, 25);
            this.lblCatMachine.TabIndex = 32;
            this.lblCatMachine.Text = "Loại máy";
            this.lblCatMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 6);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExcute, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 190);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(409, 36);
            this.tableLayoutPanel2.TabIndex = 36;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Image = global::ReportHuda.Properties.Resources.btnthoat;
            this.btnThoat.Location = new System.Drawing.Point(302, 3);
            this.btnThoat.LookAndFeel.SkinName = "Blue";
            this.btnThoat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 35;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExcute
            // 
            this.btnExcute.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcute.Appearance.Options.UseFont = true;
            this.btnExcute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExcute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExcute.Image = global::ReportHuda.Properties.Resources.btnthuchien;
            this.btnExcute.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExcute.Location = new System.Drawing.Point(192, 3);
            this.btnExcute.LookAndFeel.SkinName = "Blue";
            this.btnExcute.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(104, 30);
            this.btnExcute.TabIndex = 30;
            this.btnExcute.Text = "Thực hiện";
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // ucMaintainMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ucMaintainMonth";
            this.Size = new System.Drawing.Size(415, 229);
            this.Load += new System.EventHandler(this.ucMaintainMonth_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhaXuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCatmachine.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTuNgay;
        private DevExpress.XtraEditors.DateEdit datFromDate;
        private DevExpress.XtraEditors.SimpleButton btnExcute;
        private DevExpress.XtraEditors.LookUpEdit cmbNhaXuong;
        private System.Windows.Forms.Label lblNhaXuong;
        private DevExpress.XtraEditors.LookUpEdit cmbCatmachine;
        private System.Windows.Forms.Label lblCatMachine;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
