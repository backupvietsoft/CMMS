namespace Vs.Support
{
    partial class frmVSReply
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvReply = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTNgay = new System.Windows.Forms.Label();
            this.lblDNgay = new System.Windows.Forms.Label();
            this.lblSoYC = new System.Windows.Forms.Label();
            this.txtTNgay = new System.Windows.Forms.DateTimePicker();
            this.txtDNgay = new System.Windows.Forms.DateTimePicker();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.cboContract = new System.Windows.Forms.ComboBox();
            this.chkHoanThanh = new System.Windows.Forms.CheckBox();
            this.lblContract = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnItemXemTheoCD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemXemCT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemTroLai = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReply)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.dgvReply, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblTNgay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDNgay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSoYC, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTNgay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDNgay, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomer, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboCustomer, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboContract, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkHoanThanh, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblContract, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvReply
            // 
            this.dgvReply.AllowUserToAddRows = false;
            this.dgvReply.AllowUserToDeleteRows = false;
            this.dgvReply.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvReply, 5);
            this.dgvReply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReply.Location = new System.Drawing.Point(11, 83);
            this.dgvReply.Name = "dgvReply";
            this.dgvReply.ReadOnly = true;
            this.dgvReply.Size = new System.Drawing.Size(862, 434);
            this.dgvReply.TabIndex = 21;
            this.dgvReply.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReply_CellClick);
            this.dgvReply.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReply_CellMouseUp);
            this.dgvReply.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvReply_CellPainting);
            this.dgvReply.DoubleClick += new System.EventHandler(this.dgvReply_DoubleClick);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 5);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(11, 523);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 35);
            this.panel1.TabIndex = 29;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(217, 20);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.Location = new System.Drawing.Point(754, 0);
            this.btnThoat.MaximumSize = new System.Drawing.Size(108, 34);
            this.btnThoat.MinimumSize = new System.Drawing.Size(108, 34);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(108, 34);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblTNgay
            // 
            this.lblTNgay.AutoSize = true;
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNgay.Location = new System.Drawing.Point(11, 8);
            this.lblTNgay.Name = "lblTNgay";
            this.lblTNgay.Size = new System.Drawing.Size(114, 26);
            this.lblTNgay.TabIndex = 30;
            this.lblTNgay.Text = "lblTNgay";
            this.lblTNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDNgay
            // 
            this.lblDNgay.AutoSize = true;
            this.lblDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNgay.Location = new System.Drawing.Point(385, 8);
            this.lblDNgay.Name = "lblDNgay";
            this.lblDNgay.Size = new System.Drawing.Size(114, 26);
            this.lblDNgay.TabIndex = 32;
            this.lblDNgay.Text = "lblDNgay";
            this.lblDNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoYC
            // 
            this.lblSoYC.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblSoYC, 5);
            this.lblSoYC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoYC.Location = new System.Drawing.Point(11, 60);
            this.lblSoYC.Name = "lblSoYC";
            this.lblSoYC.Size = new System.Drawing.Size(862, 20);
            this.lblSoYC.TabIndex = 34;
            this.lblSoYC.Text = "lblSoYC";
            this.lblSoYC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTNgay
            // 
            this.txtTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtTNgay.Location = new System.Drawing.Point(131, 11);
            this.txtTNgay.Name = "txtTNgay";
            this.txtTNgay.Size = new System.Drawing.Size(248, 20);
            this.txtTNgay.TabIndex = 35;
            this.txtTNgay.ValueChanged += new System.EventHandler(this.txtTNgay_ValueChanged);
            // 
            // txtDNgay
            // 
            this.txtDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDNgay.Location = new System.Drawing.Point(505, 11);
            this.txtDNgay.Name = "txtDNgay";
            this.txtDNgay.Size = new System.Drawing.Size(248, 20);
            this.txtDNgay.TabIndex = 36;
            this.txtDNgay.ValueChanged += new System.EventHandler(this.txtDNgay_ValueChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomer.Location = new System.Drawing.Point(11, 34);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(114, 26);
            this.lblCustomer.TabIndex = 37;
            this.lblCustomer.Text = "lblCustomer";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(131, 37);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(248, 21);
            this.cboCustomer.TabIndex = 38;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // cboContract
            // 
            this.cboContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContract.FormattingEnabled = true;
            this.cboContract.Location = new System.Drawing.Point(505, 37);
            this.cboContract.Name = "cboContract";
            this.cboContract.Size = new System.Drawing.Size(248, 21);
            this.cboContract.TabIndex = 39;
            this.cboContract.SelectedIndexChanged += new System.EventHandler(this.cboContract_SelectedIndexChanged);
            // 
            // chkHoanThanh
            // 
            this.chkHoanThanh.AutoSize = true;
            this.chkHoanThanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkHoanThanh.Location = new System.Drawing.Point(759, 37);
            this.chkHoanThanh.Name = "chkHoanThanh";
            this.chkHoanThanh.Size = new System.Drawing.Size(114, 20);
            this.chkHoanThanh.TabIndex = 40;
            this.chkHoanThanh.Text = "chkHoanThanh";
            this.chkHoanThanh.UseVisualStyleBackColor = true;
            this.chkHoanThanh.CheckedChanged += new System.EventHandler(this.chkHoanThanh_CheckedChanged);
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = true;
            this.lblContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContract.Location = new System.Drawing.Point(385, 34);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(114, 26);
            this.lblContract.TabIndex = 41;
            this.lblContract.Text = "lblContract";
            this.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnItemXemTheoCD,
            this.mnItemXemCT,
            this.mnItemTroLai});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 70);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // mnItemXemTheoCD
            // 
            this.mnItemXemTheoCD.Name = "mnItemXemTheoCD";
            this.mnItemXemTheoCD.Size = new System.Drawing.Size(153, 22);
            this.mnItemXemTheoCD.Text = "lblXemTheoCD";
            this.mnItemXemTheoCD.Click += new System.EventHandler(this.lblXemTheoCDToolStripMenuItem_Click);
            // 
            // mnItemXemCT
            // 
            this.mnItemXemCT.Name = "mnItemXemCT";
            this.mnItemXemCT.Size = new System.Drawing.Size(153, 22);
            this.mnItemXemCT.Text = "lblXemCT";
            this.mnItemXemCT.Click += new System.EventHandler(this.mnItemXemCT_Click);
            // 
            // mnItemTroLai
            // 
            this.mnItemTroLai.Name = "mnItemTroLai";
            this.mnItemTroLai.Size = new System.Drawing.Size(153, 22);
            this.mnItemTroLai.Text = "lblTroLai";
            this.mnItemTroLai.Click += new System.EventHandler(this.lblTroLaiToolStripMenuItem_Click);
            // 
            // frmVSReply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmVSReply";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmVSReply";
            this.Load += new System.EventHandler(this.frmVSReply_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReply)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvReply;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblTNgay;
        private System.Windows.Forms.Label lblDNgay;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker txtTNgay;
        private System.Windows.Forms.DateTimePicker txtDNgay;
        private System.Windows.Forms.Label lblSoYC;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnItemXemTheoCD;
        private System.Windows.Forms.ToolStripMenuItem mnItemXemCT;
        private System.Windows.Forms.ToolStripMenuItem mnItemTroLai;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.ComboBox cboContract;
        private System.Windows.Forms.CheckBox chkHoanThanh;
        private System.Windows.Forms.Label lblContract;
    }
}