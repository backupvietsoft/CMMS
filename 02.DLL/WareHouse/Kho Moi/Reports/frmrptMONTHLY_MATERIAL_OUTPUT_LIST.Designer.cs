namespace WareHouse
{
    partial class frmrptMONTHLY_MATERIAL_OUTPUT_LIST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrptMONTHLY_MATERIAL_OUTPUT_LIST));
            this.cbKho = new System.Windows.Forms.ComboBox();
            this.btnBochonVT = new System.Windows.Forms.Button();
            this.btnChonhetVT = new System.Windows.Forms.Button();
            this.btnBochonQG = new System.Windows.Forms.Button();
            this.btnChonhetQG = new System.Windows.Forms.Button();
            this.rdUSD = new System.Windows.Forms.RadioButton();
            this.rdVND = new System.Windows.Forms.RadioButton();
            this.cbLoaiVT = new System.Windows.Forms.ComboBox();
            this.dtDenngay = new System.Windows.Forms.DateTimePicker();
            this.dtTungay = new System.Windows.Forms.DateTimePicker();
            this.gboVTPT = new System.Windows.Forms.GroupBox();
            this.gvVTPT = new System.Windows.Forms.DataGridView();
            this.CHONPT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gboDangxuat = new System.Windows.Forms.GroupBox();
            this.gvDangxuat = new System.Windows.Forms.DataGridView();
            this.CHON = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblDenngay = new System.Windows.Forms.Label();
            this.lblLoaiVT = new System.Windows.Forms.Label();
            this.lblKho = new System.Windows.Forms.Label();
            this.lblTungay = new System.Windows.Forms.Label();
            this.btnThuchien = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gboVTPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvVTPT)).BeginInit();
            this.gboDangxuat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDangxuat)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbKho
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbKho, 5);
            this.cbKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKho.FormattingEnabled = true;
            this.cbKho.Location = new System.Drawing.Point(66, 3);
            this.cbKho.Name = "cbKho";
            this.cbKho.Size = new System.Drawing.Size(780, 21);
            this.cbKho.TabIndex = 26;
            this.cbKho.SelectedIndexChanged += new System.EventHandler(this.cbKho_SelectedIndexChanged);
            // 
            // btnBochonVT
            // 
            this.btnBochonVT.BackgroundImage = global::WareHouse.Properties.Resources.btnuncheckall;
            this.btnBochonVT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBochonVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBochonVT.Location = new System.Drawing.Point(98, 3);
            this.btnBochonVT.Name = "btnBochonVT";
            this.btnBochonVT.Size = new System.Drawing.Size(89, 23);
            this.btnBochonVT.TabIndex = 23;
            this.btnBochonVT.Text = "Bỏ chọn";
            this.btnBochonVT.UseVisualStyleBackColor = true;
            this.btnBochonVT.Click += new System.EventHandler(this.btnBochonVT_Click);
            // 
            // btnChonhetVT
            // 
            this.btnChonhetVT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChonhetVT.BackgroundImage")));
            this.btnChonhetVT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChonhetVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChonhetVT.Location = new System.Drawing.Point(3, 3);
            this.btnChonhetVT.Name = "btnChonhetVT";
            this.btnChonhetVT.Size = new System.Drawing.Size(89, 23);
            this.btnChonhetVT.TabIndex = 22;
            this.btnChonhetVT.Text = "Chọn hết";
            this.btnChonhetVT.UseVisualStyleBackColor = true;
            this.btnChonhetVT.Click += new System.EventHandler(this.btnChonhetVT_Click);
            // 
            // btnBochonQG
            // 
            this.btnBochonQG.BackgroundImage = global::WareHouse.Properties.Resources.btnuncheckall;
            this.btnBochonQG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBochonQG.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBochonQG.Location = new System.Drawing.Point(98, 3);
            this.btnBochonQG.Name = "btnBochonQG";
            this.btnBochonQG.Size = new System.Drawing.Size(90, 23);
            this.btnBochonQG.TabIndex = 25;
            this.btnBochonQG.Text = "Bỏ chọn";
            this.btnBochonQG.UseVisualStyleBackColor = true;
            this.btnBochonQG.Click += new System.EventHandler(this.btnBochonQG_Click);
            // 
            // btnChonhetQG
            // 
            this.btnChonhetQG.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChonhetQG.BackgroundImage")));
            this.btnChonhetQG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChonhetQG.Location = new System.Drawing.Point(3, 3);
            this.btnChonhetQG.Name = "btnChonhetQG";
            this.btnChonhetQG.Size = new System.Drawing.Size(89, 23);
            this.btnChonhetQG.TabIndex = 24;
            this.btnChonhetQG.Text = "Chọn hết";
            this.btnChonhetQG.UseVisualStyleBackColor = true;
            this.btnChonhetQG.Click += new System.EventHandler(this.btnChonhetQG_Click);
            // 
            // rdUSD
            // 
            this.rdUSD.AutoSize = true;
            this.rdUSD.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdUSD.Location = new System.Drawing.Point(383, 0);
            this.rdUSD.Name = "rdUSD";
            this.rdUSD.Size = new System.Drawing.Size(48, 24);
            this.rdUSD.TabIndex = 20;
            this.rdUSD.Text = "USD";
            this.rdUSD.UseVisualStyleBackColor = true;
            // 
            // rdVND
            // 
            this.rdVND.AutoSize = true;
            this.rdVND.Checked = true;
            this.rdVND.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdVND.Location = new System.Drawing.Point(335, 0);
            this.rdVND.Name = "rdVND";
            this.rdVND.Size = new System.Drawing.Size(48, 24);
            this.rdVND.TabIndex = 21;
            this.rdVND.TabStop = true;
            this.rdVND.Text = "VND";
            this.rdVND.UseVisualStyleBackColor = true;
            // 
            // cbLoaiVT
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbLoaiVT, 5);
            this.cbLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLoaiVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiVT.FormattingEnabled = true;
            this.cbLoaiVT.Location = new System.Drawing.Point(66, 55);
            this.cbLoaiVT.Name = "cbLoaiVT";
            this.cbLoaiVT.Size = new System.Drawing.Size(780, 21);
            this.cbLoaiVT.TabIndex = 19;
            this.cbLoaiVT.SelectedIndexChanged += new System.EventHandler(this.cbLoaiVT_SelectedIndexChanged);
            // 
            // dtDenngay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.dtDenngay, 2);
            this.dtDenngay.CustomFormat = "MM/yyyy";
            this.dtDenngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenngay.Location = new System.Drawing.Point(471, 30);
            this.dtDenngay.Name = "dtDenngay";
            this.dtDenngay.Size = new System.Drawing.Size(375, 20);
            this.dtDenngay.TabIndex = 18;
            this.dtDenngay.Value = new System.DateTime(2009, 12, 15, 0, 0, 0, 0);
            this.dtDenngay.ValueChanged += new System.EventHandler(this.dtDenngay_ValueChanged);
            // 
            // dtTungay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.dtTungay, 2);
            this.dtTungay.CustomFormat = "MM/yyyy";
            this.dtTungay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTungay.Location = new System.Drawing.Point(66, 30);
            this.dtTungay.Name = "dtTungay";
            this.dtTungay.Size = new System.Drawing.Size(336, 20);
            this.dtTungay.TabIndex = 15;
            this.dtTungay.Value = new System.DateTime(2009, 12, 15, 0, 0, 0, 0);
            this.dtTungay.ValueChanged += new System.EventHandler(this.dtTungay_ValueChanged);
            // 
            // gboVTPT
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gboVTPT, 3);
            this.gboVTPT.Controls.Add(this.gvVTPT);
            this.gboVTPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboVTPT.Location = new System.Drawing.Point(408, 111);
            this.gboVTPT.Name = "gboVTPT";
            this.gboVTPT.Size = new System.Drawing.Size(438, 385);
            this.gboVTPT.TabIndex = 16;
            this.gboVTPT.TabStop = false;
            this.gboVTPT.Text = "Danh sách VT-PT";
            // 
            // gvVTPT
            // 
            this.gvVTPT.AllowUserToAddRows = false;
            this.gvVTPT.AllowUserToDeleteRows = false;
            this.gvVTPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvVTPT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHONPT});
            this.gvVTPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvVTPT.Location = new System.Drawing.Point(3, 16);
            this.gvVTPT.Name = "gvVTPT";
            this.gvVTPT.RowHeadersWidth = 21;
            this.gvVTPT.Size = new System.Drawing.Size(432, 366);
            this.gvVTPT.TabIndex = 4;
            // 
            // CHONPT
            // 
            this.CHONPT.HeaderText = "CHONPT";
            this.CHONPT.Name = "CHONPT";
            this.CHONPT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHONPT.Width = 60;
            // 
            // gboDangxuat
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gboDangxuat, 3);
            this.gboDangxuat.Controls.Add(this.gvDangxuat);
            this.gboDangxuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboDangxuat.Location = new System.Drawing.Point(3, 111);
            this.gboDangxuat.Name = "gboDangxuat";
            this.gboDangxuat.Size = new System.Drawing.Size(399, 385);
            this.gboDangxuat.TabIndex = 17;
            this.gboDangxuat.TabStop = false;
            this.gboDangxuat.Text = "Danh sách dạng xuất";
            // 
            // gvDangxuat
            // 
            this.gvDangxuat.AllowUserToAddRows = false;
            this.gvDangxuat.AllowUserToDeleteRows = false;
            this.gvDangxuat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDangxuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDangxuat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHON});
            this.gvDangxuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDangxuat.Location = new System.Drawing.Point(3, 16);
            this.gvDangxuat.Name = "gvDangxuat";
            this.gvDangxuat.RowHeadersWidth = 21;
            this.gvDangxuat.Size = new System.Drawing.Size(393, 366);
            this.gvDangxuat.TabIndex = 4;
            this.gvDangxuat.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvDangxuat_CellValidating);
            this.gvDangxuat.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDangxuat_CellEndEdit);
            this.gvDangxuat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDangxuat_CellContentClick);
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
            this.lblDenngay.Location = new System.Drawing.Point(408, 27);
            this.lblDenngay.Name = "lblDenngay";
            this.lblDenngay.Size = new System.Drawing.Size(57, 25);
            this.lblDenngay.TabIndex = 12;
            this.lblDenngay.Text = "Đến tháng";
            // 
            // lblLoaiVT
            // 
            this.lblLoaiVT.AutoSize = true;
            this.lblLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiVT.Location = new System.Drawing.Point(3, 52);
            this.lblLoaiVT.Name = "lblLoaiVT";
            this.lblLoaiVT.Size = new System.Drawing.Size(57, 26);
            this.lblLoaiVT.TabIndex = 11;
            this.lblLoaiVT.Text = "Loại vật tư";
            // 
            // lblKho
            // 
            this.lblKho.AutoSize = true;
            this.lblKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKho.Location = new System.Drawing.Point(3, 0);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(57, 27);
            this.lblKho.TabIndex = 14;
            this.lblKho.Text = "Kho";
            // 
            // lblTungay
            // 
            this.lblTungay.AutoSize = true;
            this.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTungay.Location = new System.Drawing.Point(3, 27);
            this.lblTungay.Name = "lblTungay";
            this.lblTungay.Size = new System.Drawing.Size(57, 25);
            this.lblTungay.TabIndex = 13;
            this.lblTungay.Text = "Từ tháng";
            // 
            // btnThuchien
            // 
            this.btnThuchien.BackgroundImage = global::WareHouse.Properties.Resources.btnthuchien;
            this.btnThuchien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThuchien.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThuchien.Location = new System.Drawing.Point(233, 3);
            this.btnThuchien.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnThuchien.Name = "btnThuchien";
            this.btnThuchien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThuchien.Size = new System.Drawing.Size(90, 23);
            this.btnThuchien.TabIndex = 30;
            this.btnThuchien.Text = "Thuc hien";
            this.btnThuchien.UseVisualStyleBackColor = true;
            this.btnThuchien.Click += new System.EventHandler(this.btnThuchien_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblKho, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbKho, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTungay, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtTungay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDenngay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtDenngay, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLoaiVT, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbLoaiVT, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.gboVTPT, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.gboDangxuat, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 3, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 534);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 3);
            this.panel3.Controls.Add(this.rdVND);
            this.panel3.Controls.Add(this.rdUSD);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(408, 81);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(431, 24);
            this.panel3.TabIndex = 34;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnBochonQG, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnChonhetQG, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 502);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(379, 29);
            this.tableLayoutPanel2.TabIndex = 35;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 3);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnThoat, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBochonVT, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnChonhetVT, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnThuchien, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(408, 502);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(438, 29);
            this.tableLayoutPanel3.TabIndex = 36;
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = global::WareHouse.Properties.Resources.btnthoat;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThoat.Location = new System.Drawing.Point(341, 3);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(82, 23);
            this.btnThoat.TabIndex = 31;
            this.btnThoat.Text = "Thuc hien";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmrptMONTHLY_MATERIAL_OUTPUT_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmrptMONTHLY_MATERIAL_OUTPUT_LIST";
            this.Size = new System.Drawing.Size(849, 534);
            this.Load += new System.EventHandler(this.frmrptMONTHLY_MATERIAL_OUTPUT_LIST_Load);
            this.gboVTPT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvVTPT)).EndInit();
            this.gboDangxuat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDangxuat)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbKho;
        private System.Windows.Forms.Button btnBochonVT;
        private System.Windows.Forms.Button btnChonhetVT;
        private System.Windows.Forms.Button btnBochonQG;
        private System.Windows.Forms.Button btnChonhetQG;
        private System.Windows.Forms.RadioButton rdUSD;
        private System.Windows.Forms.RadioButton rdVND;
        private System.Windows.Forms.ComboBox cbLoaiVT;
        private System.Windows.Forms.DateTimePicker dtDenngay;
        private System.Windows.Forms.DateTimePicker dtTungay;
        private System.Windows.Forms.GroupBox gboVTPT;
        private System.Windows.Forms.DataGridView gvVTPT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHONPT;
        private System.Windows.Forms.GroupBox gboDangxuat;
        private System.Windows.Forms.DataGridView gvDangxuat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHON;
        private System.Windows.Forms.Label lblDenngay;
        private System.Windows.Forms.Label lblLoaiVT;
        private System.Windows.Forms.Label lblKho;
        private System.Windows.Forms.Label lblTungay;
        private System.Windows.Forms.Button btnThuchien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnThoat;
    }
}
