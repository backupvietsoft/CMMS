namespace WareHouse
{
    partial class frmrptMONTHLY_PO_APPROVED
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
            this.gboQuocGia = new System.Windows.Forms.GroupBox();
            this.gvQuocgia = new System.Windows.Forms.DataGridView();
            this.CHON = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rdVND = new System.Windows.Forms.RadioButton();
            this.rdUSD = new System.Windows.Forms.RadioButton();
            this.btnChonhetQG = new System.Windows.Forms.Button();
            this.btnBochonQG = new System.Windows.Forms.Button();
            this.cbLoaiVT = new System.Windows.Forms.ComboBox();
            this.lblLoaiVT = new System.Windows.Forms.Label();
            this.dtDenngay = new System.Windows.Forms.DateTimePicker();
            this.lblDenngay = new System.Windows.Forms.Label();
            this.dtTungay = new System.Windows.Forms.DateTimePicker();
            this.lblTungay = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gvKho = new System.Windows.Forms.DataGridView();
            this.CHON_KHO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnNO = new System.Windows.Forms.Button();
            this.btnThuchien = new System.Windows.Forms.Button();
            this.btnALL = new System.Windows.Forms.Button();
            this.gboQuocGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuocgia)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvKho)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboQuocGia
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.gboQuocGia, 4);
            this.gboQuocGia.Controls.Add(this.gvQuocgia);
            this.gboQuocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboQuocGia.Location = new System.Drawing.Point(3, 83);
            this.gboQuocGia.Name = "gboQuocGia";
            this.gboQuocGia.Size = new System.Drawing.Size(540, 190);
            this.gboQuocGia.TabIndex = 1;
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
            this.gvQuocgia.Size = new System.Drawing.Size(534, 171);
            this.gvQuocgia.TabIndex = 4;
            // 
            // CHON
            // 
            this.CHON.HeaderText = "CHON";
            this.CHON.Name = "CHON";
            this.CHON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "CHON";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.Width = 60;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "CHON";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 60;
            // 
            // rdVND
            // 
            this.rdVND.AutoSize = true;
            this.rdVND.Checked = true;
            this.rdVND.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdVND.Location = new System.Drawing.Point(0, 0);
            this.rdVND.Name = "rdVND";
            this.rdVND.Size = new System.Drawing.Size(48, 23);
            this.rdVND.TabIndex = 8;
            this.rdVND.TabStop = true;
            this.rdVND.Text = "VND";
            this.rdVND.UseVisualStyleBackColor = true;
            // 
            // rdUSD
            // 
            this.rdUSD.AutoSize = true;
            this.rdUSD.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdUSD.Location = new System.Drawing.Point(48, 0);
            this.rdUSD.Name = "rdUSD";
            this.rdUSD.Size = new System.Drawing.Size(48, 23);
            this.rdUSD.TabIndex = 8;
            this.rdUSD.Text = "USD";
            this.rdUSD.UseVisualStyleBackColor = true;
            // 
            // btnChonhetQG
            // 
            this.btnChonhetQG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChonhetQG.BackgroundImage = global::WareHouse.Properties.Resources.btnall;
            this.btnChonhetQG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChonhetQG.Location = new System.Drawing.Point(3, 54);
            this.btnChonhetQG.Name = "btnChonhetQG";
            this.btnChonhetQG.Size = new System.Drawing.Size(84, 23);
            this.btnChonhetQG.TabIndex = 9;
            this.btnChonhetQG.Text = "Chọn hết";
            this.btnChonhetQG.UseVisualStyleBackColor = true;
            this.btnChonhetQG.Click += new System.EventHandler(this.btnChonhetQG_Click);
            // 
            // btnBochonQG
            // 
            this.btnBochonQG.BackgroundImage = global::WareHouse.Properties.Resources.btnuncheckall;
            this.btnBochonQG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBochonQG.Location = new System.Drawing.Point(93, 54);
            this.btnBochonQG.Name = "btnBochonQG";
            this.btnBochonQG.Size = new System.Drawing.Size(84, 23);
            this.btnBochonQG.TabIndex = 9;
            this.btnBochonQG.Text = "Bỏ chọn";
            this.btnBochonQG.UseVisualStyleBackColor = true;
            this.btnBochonQG.Click += new System.EventHandler(this.btnBochonQG_Click);
            // 
            // cbLoaiVT
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cbLoaiVT, 3);
            this.cbLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLoaiVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiVT.FormattingEnabled = true;
            this.cbLoaiVT.Location = new System.Drawing.Point(93, 28);
            this.cbLoaiVT.Name = "cbLoaiVT";
            this.cbLoaiVT.Size = new System.Drawing.Size(450, 21);
            this.cbLoaiVT.TabIndex = 3;
            this.cbLoaiVT.SelectedIndexChanged += new System.EventHandler(this.cbLoaiVT_SelectedIndexChanged);
            // 
            // lblLoaiVT
            // 
            this.lblLoaiVT.AutoSize = true;
            this.lblLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiVT.Location = new System.Drawing.Point(3, 25);
            this.lblLoaiVT.Name = "lblLoaiVT";
            this.lblLoaiVT.Size = new System.Drawing.Size(84, 26);
            this.lblLoaiVT.TabIndex = 0;
            this.lblLoaiVT.Text = "Loại vật tư";
            this.lblLoaiVT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtDenngay
            // 
            this.dtDenngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDenngay.Location = new System.Drawing.Point(350, 3);
            this.dtDenngay.Name = "dtDenngay";
            this.dtDenngay.Size = new System.Drawing.Size(193, 20);
            this.dtDenngay.TabIndex = 2;
            this.dtDenngay.Value = new System.DateTime(2009, 12, 15, 0, 0, 0, 0);
            // 
            // lblDenngay
            // 
            this.lblDenngay.AutoSize = true;
            this.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenngay.Location = new System.Drawing.Point(291, 0);
            this.lblDenngay.Name = "lblDenngay";
            this.lblDenngay.Size = new System.Drawing.Size(53, 25);
            this.lblDenngay.TabIndex = 0;
            this.lblDenngay.Text = "Đến ngày";
            this.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtTungay
            // 
            this.dtTungay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTungay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTungay.Location = new System.Drawing.Point(93, 3);
            this.dtTungay.Name = "dtTungay";
            this.dtTungay.Size = new System.Drawing.Size(192, 20);
            this.dtTungay.TabIndex = 1;
            this.dtTungay.Value = new System.DateTime(2009, 12, 15, 0, 0, 0, 0);
            // 
            // lblTungay
            // 
            this.lblTungay.AutoSize = true;
            this.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTungay.Location = new System.Drawing.Point(3, 0);
            this.lblTungay.Name = "lblTungay";
            this.lblTungay.Size = new System.Drawing.Size(84, 25);
            this.lblTungay.TabIndex = 0;
            this.lblTungay.Text = "Từ ngày";
            this.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.gvKho, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnBochonQG, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnChonhetQG, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTungay, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtTungay, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDenngay, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.gboQuocGia, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.dtDenngay, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLoaiVT, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbLoaiVT, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(546, 507);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // gvKho
            // 
            this.gvKho.AllowUserToAddRows = false;
            this.gvKho.AllowUserToDeleteRows = false;
            this.gvKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHON_KHO});
            this.tableLayoutPanel2.SetColumnSpan(this.gvKho, 4);
            this.gvKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvKho.Location = new System.Drawing.Point(3, 279);
            this.gvKho.Name = "gvKho";
            this.gvKho.RowHeadersWidth = 21;
            this.gvKho.Size = new System.Drawing.Size(540, 190);
            this.gvKho.TabIndex = 4;
            // 
            // CHON_KHO
            // 
            this.CHON_KHO.HeaderText = "CHON";
            this.CHON_KHO.Name = "CHON_KHO";
            this.CHON_KHO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.rdUSD);
            this.panel1.Controls.Add(this.rdVND);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(428, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 23);
            this.panel1.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel1, 4);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnThoat, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNO, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThuchien, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnALL, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 475);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 29);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = global::WareHouse.Properties.Resources.btnthoat;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThoat.Location = new System.Drawing.Point(443, 3);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(82, 23);
            this.btnThoat.TabIndex = 31;
            this.btnThoat.Text = "Thuc hien";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnNO
            // 
            this.btnNO.BackgroundImage = global::WareHouse.Properties.Resources.btnuncheckall;
            this.btnNO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNO.Location = new System.Drawing.Point(93, 3);
            this.btnNO.Name = "btnNO";
            this.btnNO.Size = new System.Drawing.Size(84, 23);
            this.btnNO.TabIndex = 9;
            this.btnNO.Text = "Bỏ chọn";
            this.btnNO.UseVisualStyleBackColor = true;
            this.btnNO.Click += new System.EventHandler(this.btnNO_Click);
            // 
            // btnThuchien
            // 
            this.btnThuchien.BackgroundImage = global::WareHouse.Properties.Resources.btnthuchien;
            this.btnThuchien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThuchien.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThuchien.Location = new System.Drawing.Point(335, 3);
            this.btnThuchien.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnThuchien.Name = "btnThuchien";
            this.btnThuchien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThuchien.Size = new System.Drawing.Size(90, 23);
            this.btnThuchien.TabIndex = 28;
            this.btnThuchien.Text = "Thuc hien";
            this.btnThuchien.UseVisualStyleBackColor = true;
            this.btnThuchien.Click += new System.EventHandler(this.btnThuchien_Click);
            // 
            // btnALL
            // 
            this.btnALL.BackgroundImage = global::WareHouse.Properties.Resources.btnall;
            this.btnALL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnALL.Location = new System.Drawing.Point(3, 3);
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(84, 23);
            this.btnALL.TabIndex = 9;
            this.btnALL.Text = "Chọn hết";
            this.btnALL.UseVisualStyleBackColor = true;
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // frmrptMONTHLY_PO_APPROVED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "frmrptMONTHLY_PO_APPROVED";
            this.Size = new System.Drawing.Size(546, 507);
            this.Load += new System.EventHandler(this.frmrptMONTHLY_PO_APPROVED_Load);
            this.gboQuocGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvQuocgia)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvKho)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboQuocGia;
        private System.Windows.Forms.DataGridView gvQuocgia;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHON;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.RadioButton rdVND;
        private System.Windows.Forms.RadioButton rdUSD;
        private System.Windows.Forms.Button btnChonhetQG;
        private System.Windows.Forms.Button btnBochonQG;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTungay;
        private System.Windows.Forms.DateTimePicker dtTungay;
        private System.Windows.Forms.Label lblDenngay;
        private System.Windows.Forms.DateTimePicker dtDenngay;
        private System.Windows.Forms.Label lblLoaiVT;
        private System.Windows.Forms.ComboBox cbLoaiVT;
        private System.Windows.Forms.Button btnThuchien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView gvKho;
        private System.Windows.Forms.Button btnNO;
        private System.Windows.Forms.Button btnALL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHON_KHO;
    }
}
