namespace WareHouse
{
    partial class frmrptVENDOR_REPORT_GOOD_RECEIPT
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
            this.cbKho = new System.Windows.Forms.ComboBox();
            this.btnBochonQG = new System.Windows.Forms.Button();
            this.btnChonhetQG = new System.Windows.Forms.Button();
            this.rdUSD = new System.Windows.Forms.RadioButton();
            this.rdVND = new System.Windows.Forms.RadioButton();
            this.cbLoaiVT = new System.Windows.Forms.ComboBox();
            this.dtDenngay = new System.Windows.Forms.DateTimePicker();
            this.dtTungay = new System.Windows.Forms.DateTimePicker();
            this.gboQuocGia = new System.Windows.Forms.GroupBox();
            this.gvQuocgia = new System.Windows.Forms.DataGridView();
            this.CHON = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblDenngay = new System.Windows.Forms.Label();
            this.lblLoaiVT = new System.Windows.Forms.Label();
            this.lblKho = new System.Windows.Forms.Label();
            this.lblTungay = new System.Windows.Forms.Label();
            this.btnThuchien = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gboQuocGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuocgia)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbKho
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbKho, 3);
            this.cbKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKho.FormattingEnabled = true;
            this.cbKho.Location = new System.Drawing.Point(66, 3);
            this.cbKho.Name = "cbKho";
            this.cbKho.Size = new System.Drawing.Size(489, 21);
            this.cbKho.TabIndex = 25;
            // 
            // btnBochonQG
            // 
            this.btnBochonQG.BackgroundImage = global::WareHouse.Properties.Resources.btnuncheckall;
            this.btnBochonQG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBochonQG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBochonQG.Location = new System.Drawing.Point(93, 3);
            this.btnBochonQG.Name = "btnBochonQG";
            this.btnBochonQG.Size = new System.Drawing.Size(84, 23);
            this.btnBochonQG.TabIndex = 23;
            this.btnBochonQG.Text = "Bỏ chọn";
            this.btnBochonQG.UseVisualStyleBackColor = true;
            this.btnBochonQG.Click += new System.EventHandler(this.btnBochonQG_Click);
            // 
            // btnChonhetQG
            // 
            this.btnChonhetQG.BackgroundImage = global::WareHouse.Properties.Resources.btnall;
            this.btnChonhetQG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChonhetQG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChonhetQG.Location = new System.Drawing.Point(3, 3);
            this.btnChonhetQG.Name = "btnChonhetQG";
            this.btnChonhetQG.Size = new System.Drawing.Size(84, 23);
            this.btnChonhetQG.TabIndex = 24;
            this.btnChonhetQG.Text = "Chọn hết";
            this.btnChonhetQG.UseVisualStyleBackColor = true;
            this.btnChonhetQG.Click += new System.EventHandler(this.btnChonhetQG_Click);
            // 
            // rdUSD
            // 
            this.rdUSD.AutoSize = true;
            this.rdUSD.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdUSD.Location = new System.Drawing.Point(177, 0);
            this.rdUSD.Name = "rdUSD";
            this.rdUSD.Size = new System.Drawing.Size(48, 22);
            this.rdUSD.TabIndex = 21;
            this.rdUSD.Text = "USD";
            this.rdUSD.UseVisualStyleBackColor = true;
            // 
            // rdVND
            // 
            this.rdVND.AutoSize = true;
            this.rdVND.Checked = true;
            this.rdVND.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdVND.Location = new System.Drawing.Point(225, 0);
            this.rdVND.Name = "rdVND";
            this.rdVND.Size = new System.Drawing.Size(48, 22);
            this.rdVND.TabIndex = 22;
            this.rdVND.TabStop = true;
            this.rdVND.Text = "VND";
            this.rdVND.UseVisualStyleBackColor = true;
            // 
            // cbLoaiVT
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbLoaiVT, 3);
            this.cbLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLoaiVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiVT.FormattingEnabled = true;
            this.cbLoaiVT.Location = new System.Drawing.Point(66, 54);
            this.cbLoaiVT.Name = "cbLoaiVT";
            this.cbLoaiVT.Size = new System.Drawing.Size(489, 21);
            this.cbLoaiVT.TabIndex = 18;
            this.cbLoaiVT.SelectedIndexChanged += new System.EventHandler(this.cbLoaiVT_SelectedIndexChanged);
            // 
            // dtDenngay
            // 
            this.dtDenngay.CustomFormat = "MM/yyyy";
            this.dtDenngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenngay.Location = new System.Drawing.Point(345, 28);
            this.dtDenngay.Name = "dtDenngay";
            this.dtDenngay.Size = new System.Drawing.Size(210, 20);
            this.dtDenngay.TabIndex = 17;
            this.dtDenngay.Value = new System.DateTime(2009, 12, 15, 0, 0, 0, 0);
            // 
            // dtTungay
            // 
            this.dtTungay.CustomFormat = "MM/yyyy";
            this.dtTungay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTungay.Location = new System.Drawing.Point(66, 28);
            this.dtTungay.Name = "dtTungay";
            this.dtTungay.Size = new System.Drawing.Size(210, 20);
            this.dtTungay.TabIndex = 15;
            this.dtTungay.Value = new System.DateTime(2009, 12, 15, 0, 0, 0, 0);
            // 
            // gboQuocGia
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gboQuocGia, 4);
            this.gboQuocGia.Controls.Add(this.gvQuocgia);
            this.gboQuocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboQuocGia.Location = new System.Drawing.Point(3, 108);
            this.gboQuocGia.Name = "gboQuocGia";
            this.gboQuocGia.Size = new System.Drawing.Size(552, 328);
            this.gboQuocGia.TabIndex = 16;
            this.gboQuocGia.TabStop = false;
            this.gboQuocGia.Text = "Quoc Gia KH";
            // 
            // gvQuocgia
            // 
            this.gvQuocgia.AllowUserToAddRows = false;
            this.gvQuocgia.AllowUserToDeleteRows = false;
            this.gvQuocgia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvQuocgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvQuocgia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHON});
            this.gvQuocgia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvQuocgia.Location = new System.Drawing.Point(3, 16);
            this.gvQuocgia.Name = "gvQuocgia";
            this.gvQuocgia.RowHeadersWidth = 21;
            this.gvQuocgia.Size = new System.Drawing.Size(546, 309);
            this.gvQuocgia.TabIndex = 4;
            // 
            // CHON
            // 
            this.CHON.HeaderText = "CHON";
            this.CHON.Name = "CHON";
            this.CHON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // lblDenngay
            // 
            this.lblDenngay.AutoSize = true;
            this.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenngay.Location = new System.Drawing.Point(282, 25);
            this.lblDenngay.Name = "lblDenngay";
            this.lblDenngay.Size = new System.Drawing.Size(57, 26);
            this.lblDenngay.TabIndex = 12;
            this.lblDenngay.Text = "Đến tháng";
            this.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLoaiVT
            // 
            this.lblLoaiVT.AutoSize = true;
            this.lblLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiVT.Location = new System.Drawing.Point(3, 51);
            this.lblLoaiVT.Name = "lblLoaiVT";
            this.lblLoaiVT.Size = new System.Drawing.Size(57, 26);
            this.lblLoaiVT.TabIndex = 11;
            this.lblLoaiVT.Text = "Loại vật tư";
            this.lblLoaiVT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKho
            // 
            this.lblKho.AutoSize = true;
            this.lblKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKho.Location = new System.Drawing.Point(3, 0);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(57, 25);
            this.lblKho.TabIndex = 14;
            this.lblKho.Text = "Kho";
            this.lblKho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTungay
            // 
            this.lblTungay.AutoSize = true;
            this.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTungay.Location = new System.Drawing.Point(3, 25);
            this.lblTungay.Name = "lblTungay";
            this.lblTungay.Size = new System.Drawing.Size(57, 26);
            this.lblTungay.TabIndex = 13;
            this.lblTungay.Text = "Từ tháng";
            this.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnThuchien
            // 
            this.btnThuchien.BackgroundImage = global::WareHouse.Properties.Resources.btnthuchien;
            this.btnThuchien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThuchien.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThuchien.Location = new System.Drawing.Point(347, 3);
            this.btnThuchien.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnThuchien.Name = "btnThuchien";
            this.btnThuchien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThuchien.Size = new System.Drawing.Size(90, 23);
            this.btnThuchien.TabIndex = 29;
            this.btnThuchien.Text = "Thuc hien";
            this.btnThuchien.UseVisualStyleBackColor = true;
            this.btnThuchien.Click += new System.EventHandler(this.btnThuchien_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblKho, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTungay, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbKho, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtTungay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDenngay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtDenngay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.gboQuocGia, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbLoaiVT, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLoaiVT, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(558, 474);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.rdUSD);
            this.panel1.Controls.Add(this.rdVND);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(282, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 22);
            this.panel1.TabIndex = 31;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnThoat, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnChonhetQG, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBochonQG, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnThuchien, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 442);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(552, 29);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = global::WareHouse.Properties.Resources.btnthoat;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThoat.Location = new System.Drawing.Point(455, 3);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(82, 23);
            this.btnThoat.TabIndex = 31;
            this.btnThoat.Text = "Thuc hien";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmrptVENDOR_REPORT_GOOD_RECEIPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmrptVENDOR_REPORT_GOOD_RECEIPT";
            this.Size = new System.Drawing.Size(558, 474);
            this.Load += new System.EventHandler(this.frmrptVENDOR_REPORT_GOOD_RECEIPT_Load);
            this.gboQuocGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvQuocgia)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbKho;
        private System.Windows.Forms.Button btnBochonQG;
        private System.Windows.Forms.Button btnChonhetQG;
        private System.Windows.Forms.RadioButton rdUSD;
        private System.Windows.Forms.RadioButton rdVND;
        private System.Windows.Forms.ComboBox cbLoaiVT;
        private System.Windows.Forms.DateTimePicker dtDenngay;
        private System.Windows.Forms.DateTimePicker dtTungay;
        private System.Windows.Forms.GroupBox gboQuocGia;
        private System.Windows.Forms.DataGridView gvQuocgia;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHON;
        private System.Windows.Forms.Label lblDenngay;
        private System.Windows.Forms.Label lblLoaiVT;
        private System.Windows.Forms.Label lblKho;
        private System.Windows.Forms.Label lblTungay;
        private System.Windows.Forms.Button btnThuchien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnThoat;
    }
}
