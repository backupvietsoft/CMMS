namespace Vs.Support
{
    partial class frmCustomerContract
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvCtmContract = new System.Windows.Forms.DataGridView();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.cboCustomerID = new System.Windows.Forms.ComboBox();
            this.rdo_All = new System.Windows.Forms.RadioButton();
            this.rdo_ConHan = new System.Windows.Forms.RadioButton();
            this.rdo_HetHan = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtmContract)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.dgvCtmContract, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerID, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboCustomerID, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.rdo_All, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.rdo_ConHan, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.rdo_HetHan, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 6);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(11, 523);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 35);
            this.panel1.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThem.Location = new System.Drawing.Point(654, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(108, 35);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "btnThem";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.Location = new System.Drawing.Point(762, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(108, 35);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvCtmContract
            // 
            this.dgvCtmContract.AllowUserToAddRows = false;
            this.dgvCtmContract.AllowUserToDeleteRows = false;
            this.dgvCtmContract.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCtmContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvCtmContract, 5);
            this.dgvCtmContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtmContract.Location = new System.Drawing.Point(11, 63);
            this.dgvCtmContract.Name = "dgvCtmContract";
            this.dgvCtmContract.ReadOnly = true;
            this.dgvCtmContract.Size = new System.Drawing.Size(862, 446);
            this.dgvCtmContract.TabIndex = 2;
            this.dgvCtmContract.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCtmContract_CellMouseUp);
            this.dgvCtmContract.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCtmContract_CellPainting);
            this.dgvCtmContract.DoubleClick += new System.EventHandler(this.dgvCtmContract_DoubleClick);
            this.dgvCtmContract.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCtmContract_KeyDown);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerID.Location = new System.Drawing.Point(11, 8);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(114, 26);
            this.lblCustomerID.TabIndex = 1;
            this.lblCustomerID.Text = "lblCustomerID";
            this.lblCustomerID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCustomerID
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboCustomerID, 4);
            this.cboCustomerID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCustomerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerID.FormattingEnabled = true;
            this.cboCustomerID.Location = new System.Drawing.Point(131, 11);
            this.cboCustomerID.Name = "cboCustomerID";
            this.cboCustomerID.Size = new System.Drawing.Size(742, 21);
            this.cboCustomerID.TabIndex = 1;
            this.cboCustomerID.SelectedIndexChanged += new System.EventHandler(this.cboCustomerID_SelectedIndexChanged);
            // 
            // rdo_All
            // 
            this.rdo_All.AutoSize = true;
            this.rdo_All.Location = new System.Drawing.Point(131, 37);
            this.rdo_All.Name = "rdo_All";
            this.rdo_All.Size = new System.Drawing.Size(36, 17);
            this.rdo_All.TabIndex = 3;
            this.rdo_All.TabStop = true;
            this.rdo_All.Text = "All";
            this.rdo_All.UseVisualStyleBackColor = true;
            this.rdo_All.CheckedChanged += new System.EventHandler(this.rdo_All_CheckedChanged);
            // 
            // rdo_ConHan
            // 
            this.rdo_ConHan.AutoSize = true;
            this.rdo_ConHan.Location = new System.Drawing.Point(251, 37);
            this.rdo_ConHan.Name = "rdo_ConHan";
            this.rdo_ConHan.Size = new System.Drawing.Size(65, 17);
            this.rdo_ConHan.TabIndex = 4;
            this.rdo_ConHan.TabStop = true;
            this.rdo_ConHan.Text = "Còn hạn";
            this.rdo_ConHan.UseVisualStyleBackColor = true;
            this.rdo_ConHan.CheckedChanged += new System.EventHandler(this.rdo_ConHan_CheckedChanged);
            // 
            // rdo_HetHan
            // 
            this.rdo_HetHan.AutoSize = true;
            this.rdo_HetHan.Location = new System.Drawing.Point(371, 37);
            this.rdo_HetHan.Name = "rdo_HetHan";
            this.rdo_HetHan.Size = new System.Drawing.Size(63, 17);
            this.rdo_HetHan.TabIndex = 5;
            this.rdo_HetHan.TabStop = true;
            this.rdo_HetHan.Text = "Hết hạn";
            this.rdo_HetHan.UseVisualStyleBackColor = true;
            this.rdo_HetHan.CheckedChanged += new System.EventHandler(this.rdo_HetHan_CheckedChanged);
            // 
            // frmCustomerContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmCustomerContract";
            this.Text = "frmCustomerContract";
            this.Load += new System.EventHandler(this.frmCustomerContract_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtmContract)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.DataGridView dgvCtmContract;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cboCustomerID;
        private System.Windows.Forms.RadioButton rdo_All;
        private System.Windows.Forms.RadioButton rdo_ConHan;
        private System.Windows.Forms.RadioButton rdo_HetHan;
    }
}