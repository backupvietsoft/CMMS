namespace WareHouse
{
    partial class frmChonDeXuat : DevExpress.XtraEditors.XtraForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LabTitle = new System.Windows.Forms.Label();
            this.TlbSelectItem = new System.Windows.Forms.TableLayoutPanel();
            this.PelSelectItem = new System.Windows.Forms.Panel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.DgvSelect = new Vietsoft.DataGridViewEditor();
            this.ClMS_DE_XUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClSO_DE_XUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClPHONG_BAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClNGAY_DE_XUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClNGUOI_DE_XUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TlbSelectItem.SuspendLayout();
            this.PelSelectItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // LabTitle
            // 
            this.LabTitle.AutoSize = true;
            this.LabTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabTitle.ForeColor = System.Drawing.Color.Navy;
            this.LabTitle.Location = new System.Drawing.Point(3, 0);
            this.LabTitle.Name = "LabTitle";
            this.LabTitle.Size = new System.Drawing.Size(776, 28);
            this.LabTitle.TabIndex = 5;
            this.LabTitle.Text = "CHỌN ĐỀ XUẤT MUA HÀNG";
            this.LabTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TlbSelectItem
            // 
            this.TlbSelectItem.ColumnCount = 1;
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlbSelectItem.Controls.Add(this.PelSelectItem, 0, 2);
            this.TlbSelectItem.Controls.Add(this.DgvSelect, 0, 1);
            this.TlbSelectItem.Controls.Add(this.LabTitle, 0, 0);
            this.TlbSelectItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlbSelectItem.Location = new System.Drawing.Point(0, 0);
            this.TlbSelectItem.Name = "TlbSelectItem";
            this.TlbSelectItem.RowCount = 3;
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.TlbSelectItem.Size = new System.Drawing.Size(782, 493);
            this.TlbSelectItem.TabIndex = 1;
            // 
            // PelSelectItem
            // 
            this.PelSelectItem.Controls.Add(this.BtnOK);
            this.PelSelectItem.Controls.Add(this.BtnExit);
            this.PelSelectItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PelSelectItem.Location = new System.Drawing.Point(0, 462);
            this.PelSelectItem.Margin = new System.Windows.Forms.Padding(0);
            this.PelSelectItem.Name = "PelSelectItem";
            this.PelSelectItem.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.PelSelectItem.Size = new System.Drawing.Size(782, 31);
            this.PelSelectItem.TabIndex = 1;
            // 
            // BtnOK
            // 
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Location = new System.Drawing.Point(562, 0);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(85, 31);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "&Thực hiện";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.Location = new System.Drawing.Point(647, 0);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(85, 31);
            this.BtnExit.TabIndex = 0;
            this.BtnExit.Text = "Th&oát";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // DgvSelect
            // 
            this.DgvSelect.AllowUserToAddRows = false;
            this.DgvSelect.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSelect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClMS_DE_XUAT,
            this.ClSO_DE_XUAT,
            this.ClPHONG_BAN,
            this.ClNGAY_DE_XUAT,
            this.ClNGUOI_DE_XUAT});
            this.DgvSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSelect.Location = new System.Drawing.Point(3, 31);
            this.DgvSelect.Name = "DgvSelect";
            this.DgvSelect.RowHeadersVisible = false;
            this.DgvSelect.RowHeadersWidth = 30;
            this.DgvSelect.Size = new System.Drawing.Size(776, 428);
            this.DgvSelect.TabIndex = 2;
            // 
            // ClMS_DE_XUAT
            // 
            this.ClMS_DE_XUAT.HeaderText = "Mã số đề xuất";
            this.ClMS_DE_XUAT.MinimumWidth = 120;
            this.ClMS_DE_XUAT.Name = "ClMS_DE_XUAT";
            this.ClMS_DE_XUAT.Width = 120;
            // 
            // ClSO_DE_XUAT
            // 
            this.ClSO_DE_XUAT.HeaderText = "Số đề xuất";
            this.ClSO_DE_XUAT.MinimumWidth = 120;
            this.ClSO_DE_XUAT.Name = "ClSO_DE_XUAT";
            this.ClSO_DE_XUAT.Width = 120;
            // 
            // ClPHONG_BAN
            // 
            this.ClPHONG_BAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClPHONG_BAN.HeaderText = "Phòng ban";
            this.ClPHONG_BAN.MinimumWidth = 150;
            this.ClPHONG_BAN.Name = "ClPHONG_BAN";
            // 
            // ClNGAY_DE_XUAT
            // 
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.ClNGAY_DE_XUAT.DefaultCellStyle = dataGridViewCellStyle2;
            this.ClNGAY_DE_XUAT.HeaderText = "Ngày đề xuất";
            this.ClNGAY_DE_XUAT.MinimumWidth = 100;
            this.ClNGAY_DE_XUAT.Name = "ClNGAY_DE_XUAT";
            // 
            // ClNGUOI_DE_XUAT
            // 
            this.ClNGUOI_DE_XUAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClNGUOI_DE_XUAT.HeaderText = "Người đề xuất";
            this.ClNGUOI_DE_XUAT.MinimumWidth = 120;
            this.ClNGUOI_DE_XUAT.Name = "ClNGUOI_DE_XUAT";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã số đề xuất";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Số đề xuất";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Phòng ban";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày đề xuất";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Người đề xuất";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // frmChonDeXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 493);
            this.Controls.Add(this.TlbSelectItem);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChonDeXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn Đề Xuất";
            this.Load += new System.EventHandler(this.frmChonDeXuat_Load);
            this.TlbSelectItem.ResumeLayout(false);
            this.TlbSelectItem.PerformLayout();
            this.PelSelectItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabTitle;
        private System.Windows.Forms.TableLayoutPanel TlbSelectItem;
        private System.Windows.Forms.Panel PelSelectItem;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnExit;
        private Vietsoft.DataGridViewEditor DgvSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClMS_DE_XUAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClSO_DE_XUAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClPHONG_BAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClNGAY_DE_XUAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClNGUOI_DE_XUAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}