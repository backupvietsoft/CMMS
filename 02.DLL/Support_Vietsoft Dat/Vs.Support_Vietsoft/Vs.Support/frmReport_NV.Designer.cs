namespace Vs.Support
{
    partial class frmReport_NV
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
            this.cboContractID = new System.Windows.Forms.ComboBox();
            this.cboCustomerID = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabThoiGianHoTro = new System.Windows.Forms.TabPage();
            this.dgvThoiGianHT = new System.Windows.Forms.DataGridView();
            this.tabDanhGia = new System.Windows.Forms.TabPage();
            this.dgvDanhGia = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rdAll = new System.Windows.Forms.RadioButton();
            this.rdCustomerID = new System.Windows.Forms.RadioButton();
            this.rdContractID = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabThoiGianHoTro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiGianHT)).BeginInit();
            this.tabDanhGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhGia)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboContractID
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboContractID, 2);
            this.cboContractID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboContractID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContractID.FormattingEnabled = true;
            this.cboContractID.Location = new System.Drawing.Point(523, 37);
            this.cboContractID.Name = "cboContractID";
            this.cboContractID.Size = new System.Drawing.Size(266, 21);
            this.cboContractID.TabIndex = 9;
            // 
            // cboCustomerID
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboCustomerID, 2);
            this.cboCustomerID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCustomerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerID.FormattingEnabled = true;
            this.cboCustomerID.Location = new System.Drawing.Point(131, 37);
            this.cboCustomerID.Name = "cboCustomerID";
            this.cboCustomerID.Size = new System.Drawing.Size(266, 21);
            this.cboCustomerID.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 6);
            this.tabControl1.Controls.Add(this.tabThoiGianHoTro);
            this.tabControl1.Controls.Add(this.tabDanhGia);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(11, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 343);
            this.tabControl1.TabIndex = 3;
            // 
            // tabThoiGianHoTro
            // 
            this.tabThoiGianHoTro.Controls.Add(this.dgvThoiGianHT);
            this.tabThoiGianHoTro.Location = new System.Drawing.Point(4, 22);
            this.tabThoiGianHoTro.Name = "tabThoiGianHoTro";
            this.tabThoiGianHoTro.Padding = new System.Windows.Forms.Padding(3);
            this.tabThoiGianHoTro.Size = new System.Drawing.Size(770, 317);
            this.tabThoiGianHoTro.TabIndex = 0;
            this.tabThoiGianHoTro.Text = "tabThoiGianHoTro";
            this.tabThoiGianHoTro.UseVisualStyleBackColor = true;
            // 
            // dgvThoiGianHT
            // 
            this.dgvThoiGianHT.AllowUserToAddRows = false;
            this.dgvThoiGianHT.AllowUserToDeleteRows = false;
            this.dgvThoiGianHT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThoiGianHT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThoiGianHT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThoiGianHT.Location = new System.Drawing.Point(3, 3);
            this.dgvThoiGianHT.Name = "dgvThoiGianHT";
            this.dgvThoiGianHT.ReadOnly = true;
            this.dgvThoiGianHT.Size = new System.Drawing.Size(764, 311);
            this.dgvThoiGianHT.TabIndex = 0;
            // 
            // tabDanhGia
            // 
            this.tabDanhGia.Controls.Add(this.dgvDanhGia);
            this.tabDanhGia.Location = new System.Drawing.Point(4, 22);
            this.tabDanhGia.Name = "tabDanhGia";
            this.tabDanhGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabDanhGia.Size = new System.Drawing.Size(770, 317);
            this.tabDanhGia.TabIndex = 1;
            this.tabDanhGia.Text = "tabDanhGia";
            this.tabDanhGia.UseVisualStyleBackColor = true;
            // 
            // dgvDanhGia
            // 
            this.dgvDanhGia.AllowUserToAddRows = false;
            this.dgvDanhGia.AllowUserToDeleteRows = false;
            this.dgvDanhGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhGia.Location = new System.Drawing.Point(3, 3);
            this.dgvDanhGia.Name = "dgvDanhGia";
            this.dgvDanhGia.Size = new System.Drawing.Size(764, 311);
            this.dgvDanhGia.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 6);
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(11, 412);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 35);
            this.panel1.TabIndex = 0;
            // 
            // btnIn
            // 
            this.btnIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIn.Location = new System.Drawing.Point(562, 0);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(108, 35);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "btnIn";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.Location = new System.Drawing.Point(670, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(108, 35);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.rdAll, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rdCustomerID, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rdContractID, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboCustomerID, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboContractID, 5, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rdAll
            // 
            this.rdAll.AutoSize = true;
            this.rdAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdAll.Location = new System.Drawing.Point(11, 11);
            this.rdAll.Name = "rdAll";
            this.rdAll.Size = new System.Drawing.Size(114, 20);
            this.rdAll.TabIndex = 10;
            this.rdAll.TabStop = true;
            this.rdAll.Text = "rdAll";
            this.rdAll.UseVisualStyleBackColor = true;
            this.rdAll.CheckedChanged += new System.EventHandler(this.rdAll_CheckedChanged);
            // 
            // rdCustomerID
            // 
            this.rdCustomerID.AutoSize = true;
            this.rdCustomerID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdCustomerID.Location = new System.Drawing.Point(11, 37);
            this.rdCustomerID.Name = "rdCustomerID";
            this.rdCustomerID.Size = new System.Drawing.Size(114, 20);
            this.rdCustomerID.TabIndex = 11;
            this.rdCustomerID.TabStop = true;
            this.rdCustomerID.Text = "rdCustomerID";
            this.rdCustomerID.UseVisualStyleBackColor = true;
            this.rdCustomerID.CheckedChanged += new System.EventHandler(this.rdCustomerID_CheckedChanged);
            // 
            // rdContractID
            // 
            this.rdContractID.AutoSize = true;
            this.rdContractID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdContractID.Location = new System.Drawing.Point(403, 37);
            this.rdContractID.Name = "rdContractID";
            this.rdContractID.Size = new System.Drawing.Size(114, 20);
            this.rdContractID.TabIndex = 12;
            this.rdContractID.TabStop = true;
            this.rdContractID.Text = "rdContractID";
            this.rdContractID.UseVisualStyleBackColor = true;
            this.rdContractID.CheckedChanged += new System.EventHandler(this.rdContractID_CheckedChanged);
            // 
            // frmReport_NV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmReport_NV";
            this.Text = "frmReport_NV";
            this.Load += new System.EventHandler(this.frmReport_NV_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabThoiGianHoTro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiGianHT)).EndInit();
            this.tabDanhGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhGia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboContractID;
        private System.Windows.Forms.ComboBox cboCustomerID;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.RadioButton rdAll;
        private System.Windows.Forms.RadioButton rdCustomerID;
        private System.Windows.Forms.RadioButton rdContractID;
        private System.Windows.Forms.TabPage tabThoiGianHoTro;
        private System.Windows.Forms.DataGridView dgvThoiGianHT;
        private System.Windows.Forms.TabPage tabDanhGia;
        private System.Windows.Forms.DataGridView dgvDanhGia;
    }
}