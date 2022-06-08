namespace WareHouse
{
    partial class frmrptMONTHLY_MAINTENANCE_MATERIAL_REPORT
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
            this.lblTungay = new System.Windows.Forms.Label();
            this.lblLoaiVT = new System.Windows.Forms.Label();
            this.lblDenngay = new System.Windows.Forms.Label();
            this.dtTungay = new System.Windows.Forms.DateTimePicker();
            this.dtDenngay = new System.Windows.Forms.DateTimePicker();
            this.cbLoaiVT = new System.Windows.Forms.ComboBox();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rdVND = new System.Windows.Forms.RadioButton();
            this.rdUSD = new System.Windows.Forms.RadioButton();
            this.lblKho = new System.Windows.Forms.Label();
            this.cbKho = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.btnThuchien = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTungay
            // 
            this.lblTungay.AutoSize = true;
            this.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTungay.Location = new System.Drawing.Point(3, 25);
            this.lblTungay.Name = "lblTungay";
            this.lblTungay.Size = new System.Drawing.Size(57, 25);
            this.lblTungay.TabIndex = 0;
            this.lblTungay.Text = "Từ ngày";
            this.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLoaiVT
            // 
            this.lblLoaiVT.AutoSize = true;
            this.lblLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiVT.Location = new System.Drawing.Point(3, 50);
            this.lblLoaiVT.Name = "lblLoaiVT";
            this.lblLoaiVT.Size = new System.Drawing.Size(57, 26);
            this.lblLoaiVT.TabIndex = 0;
            this.lblLoaiVT.Text = "Loại vật tư";
            this.lblLoaiVT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDenngay
            // 
            this.lblDenngay.AutoSize = true;
            this.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenngay.Location = new System.Drawing.Point(274, 25);
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
            this.dtTungay.Location = new System.Drawing.Point(66, 28);
            this.dtTungay.Name = "dtTungay";
            this.dtTungay.Size = new System.Drawing.Size(202, 20);
            this.dtTungay.TabIndex = 2;
            this.dtTungay.Value = new System.DateTime(2009, 12, 15, 0, 0, 0, 0);
            // 
            // dtDenngay
            // 
            this.dtDenngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDenngay.Location = new System.Drawing.Point(333, 28);
            this.dtDenngay.Name = "dtDenngay";
            this.dtDenngay.Size = new System.Drawing.Size(202, 20);
            this.dtDenngay.TabIndex = 3;
            this.dtDenngay.Value = new System.DateTime(2009, 12, 15, 0, 0, 0, 0);
            // 
            // cbLoaiVT
            // 
            this.cbLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLoaiVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiVT.FormattingEnabled = true;
            this.cbLoaiVT.Location = new System.Drawing.Point(66, 53);
            this.cbLoaiVT.Name = "cbLoaiVT";
            this.cbLoaiVT.Size = new System.Drawing.Size(202, 21);
            this.cbLoaiVT.TabIndex = 4;
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
            this.rdVND.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdVND.Location = new System.Drawing.Point(127, 0);
            this.rdVND.Name = "rdVND";
            this.rdVND.Size = new System.Drawing.Size(48, 17);
            this.rdVND.TabIndex = 6;
            this.rdVND.TabStop = true;
            this.rdVND.Text = "VND";
            this.rdVND.UseVisualStyleBackColor = true;
            // 
            // rdUSD
            // 
            this.rdUSD.AutoSize = true;
            this.rdUSD.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdUSD.Location = new System.Drawing.Point(79, 0);
            this.rdUSD.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.rdUSD.Name = "rdUSD";
            this.rdUSD.Size = new System.Drawing.Size(48, 17);
            this.rdUSD.TabIndex = 7;
            this.rdUSD.Text = "USD";
            this.rdUSD.UseVisualStyleBackColor = true;
            // 
            // lblKho
            // 
            this.lblKho.AutoSize = true;
            this.lblKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKho.Location = new System.Drawing.Point(3, 0);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(57, 25);
            this.lblKho.TabIndex = 0;
            this.lblKho.Text = "Loại vật tư";
            this.lblKho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbKho
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbKho, 3);
            this.cbKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKho.FormattingEnabled = true;
            this.cbKho.Location = new System.Drawing.Point(66, 3);
            this.cbKho.Name = "cbKho";
            this.cbKho.Size = new System.Drawing.Size(469, 21);
            this.cbKho.TabIndex = 1;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClass.Location = new System.Drawing.Point(274, 50);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(53, 26);
            this.lblClass.TabIndex = 0;
            this.lblClass.Text = "Class";
            this.lblClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbClass
            // 
            this.cbClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(333, 53);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(202, 21);
            this.cbClass.TabIndex = 5;
            // 
            // btnThuchien
            // 
            this.btnThuchien.BackgroundImage = global::WareHouse.Properties.Resources.btnthuchien;
            this.btnThuchien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThuchien.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThuchien.Location = new System.Drawing.Point(327, 3);
            this.btnThuchien.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnThuchien.Name = "btnThuchien";
            this.btnThuchien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThuchien.Size = new System.Drawing.Size(90, 22);
            this.btnThuchien.TabIndex = 31;
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
            this.tableLayoutPanel1.Controls.Add(this.cbKho, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbClass, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblKho, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtDenngay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbLoaiVT, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblClass, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTungay, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDenngay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLoaiVT, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtTungay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(538, 407);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.rdUSD);
            this.panel1.Controls.Add(this.rdVND);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(348, 79);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 17);
            this.panel1.TabIndex = 33;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnThoat, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnThuchien, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 376);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(532, 28);
            this.tableLayoutPanel2.TabIndex = 34;
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = global::WareHouse.Properties.Resources.btnthoat;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThoat.Location = new System.Drawing.Point(435, 3);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(82, 22);
            this.btnThoat.TabIndex = 32;
            this.btnThoat.Text = "Thuc hien";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmrptMONTHLY_MAINTENANCE_MATERIAL_REPORT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmrptMONTHLY_MAINTENANCE_MATERIAL_REPORT";
            this.Size = new System.Drawing.Size(538, 407);
            this.Load += new System.EventHandler(this.frmrptMONTHLY_MAINTENANCE_MATERIAL_REPORT_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTungay;
        private System.Windows.Forms.Label lblLoaiVT;
        private System.Windows.Forms.Label lblDenngay;
        private System.Windows.Forms.DateTimePicker dtTungay;
        private System.Windows.Forms.DateTimePicker dtDenngay;
        private System.Windows.Forms.ComboBox cbLoaiVT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.RadioButton rdVND;
        private System.Windows.Forms.RadioButton rdUSD;
        private System.Windows.Forms.Label lblKho;
        private System.Windows.Forms.ComboBox cbKho;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnThuchien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnThoat;
    }
}
