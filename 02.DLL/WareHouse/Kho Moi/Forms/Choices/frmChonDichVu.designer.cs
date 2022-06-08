namespace WareHouse
{
    partial class frmChonDichVu : DevExpress.XtraEditors.XtraForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TlbSelectItem = new System.Windows.Forms.TableLayoutPanel();
            this.PelSelectItem = new System.Windows.Forms.Panel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.DgvSelect = new Vietsoft.DataGridViewEditor();
            this.CHON = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MS_DE_XUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MS_DICH_VU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEN_DICH_VU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SO_LUONG_DE_XUAT = new Vietsoft.DataGridViewColumnEditor();
            this.DON_GIA = new Vietsoft.DataGridViewColumnEditor();
            this.NGOAI_TE = new Vietsoft.DataGridViewColumnEditor();
            this.TY_GIA = new Vietsoft.DataGridViewColumnEditor();
            this.TY_GIA_USD = new Vietsoft.DataGridViewColumnEditor();
            this.THANH_TIEN = new Vietsoft.DataGridViewColumnEditor();
            this.THANH_TIEN_VND = new Vietsoft.DataGridViewColumnEditor();
            this.THANH_TIEN_USD = new Vietsoft.DataGridViewColumnEditor();
            this.GHI_CHU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabTitle = new System.Windows.Forms.Label();
            this.TlbSelectItem.SuspendLayout();
            this.PelSelectItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // TlbSelectItem
            // 
            this.TlbSelectItem.ColumnCount = 4;
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlbSelectItem.Controls.Add(this.PelSelectItem, 0, 2);
            this.TlbSelectItem.Controls.Add(this.DgvSelect, 0, 1);
            this.TlbSelectItem.Controls.Add(this.LabTitle, 0, 0);
            this.TlbSelectItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlbSelectItem.Location = new System.Drawing.Point(0, 0);
            this.TlbSelectItem.Name = "TlbSelectItem";
            this.TlbSelectItem.RowCount = 3;
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlbSelectItem.Size = new System.Drawing.Size(782, 486);
            this.TlbSelectItem.TabIndex = 1;
            // 
            // PelSelectItem
            // 
            this.TlbSelectItem.SetColumnSpan(this.PelSelectItem, 4);
            this.PelSelectItem.Controls.Add(this.BtnOK);
            this.PelSelectItem.Controls.Add(this.BtnExit);
            this.PelSelectItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PelSelectItem.Location = new System.Drawing.Point(0, 462);
            this.PelSelectItem.Margin = new System.Windows.Forms.Padding(0);
            this.PelSelectItem.Name = "PelSelectItem";
            this.PelSelectItem.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.PelSelectItem.Size = new System.Drawing.Size(782, 24);
            this.PelSelectItem.TabIndex = 1;
            // 
            // BtnOK
            // 
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Location = new System.Drawing.Point(562, 0);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(85, 24);
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
            this.BtnExit.Size = new System.Drawing.Size(85, 24);
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
            this.CHON,
            this.MS_DE_XUAT,
            this.MS_DICH_VU,
            this.TEN_DICH_VU,
            this.DVT,
            this.SO_LUONG_DE_XUAT,
            this.DON_GIA,
            this.NGOAI_TE,
            this.TY_GIA,
            this.TY_GIA_USD,
            this.THANH_TIEN,
            this.THANH_TIEN_VND,
            this.THANH_TIEN_USD,
            this.GHI_CHU});
            this.TlbSelectItem.SetColumnSpan(this.DgvSelect, 4);
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSelect.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSelect.Location = new System.Drawing.Point(3, 31);
            this.DgvSelect.Name = "DgvSelect";
            this.DgvSelect.RowHeadersVisible = false;
            this.DgvSelect.RowHeadersWidth = 30;
            this.DgvSelect.Size = new System.Drawing.Size(776, 428);
            this.DgvSelect.TabIndex = 2;
            // 
            // CHON
            // 
            this.CHON.HeaderText = "";
            this.CHON.MinimumWidth = 40;
            this.CHON.Name = "CHON";
            this.CHON.Width = 40;
            // 
            // MS_DE_XUAT
            // 
            this.MS_DE_XUAT.HeaderText = "Mã số đề xuất";
            this.MS_DE_XUAT.MinimumWidth = 120;
            this.MS_DE_XUAT.Name = "MS_DE_XUAT";
            this.MS_DE_XUAT.Width = 120;
            // 
            // MS_DICH_VU
            // 
            this.MS_DICH_VU.HeaderText = "Mã số dịch vụ";
            this.MS_DICH_VU.MinimumWidth = 120;
            this.MS_DICH_VU.Name = "MS_DICH_VU";
            this.MS_DICH_VU.Width = 120;
            // 
            // TEN_DICH_VU
            // 
            this.TEN_DICH_VU.HeaderText = "Tên dịch vụ";
            this.TEN_DICH_VU.MinimumWidth = 140;
            this.TEN_DICH_VU.Name = "TEN_DICH_VU";
            this.TEN_DICH_VU.Width = 140;
            // 
            // DVT
            // 
            this.DVT.HeaderText = "ĐVT";
            this.DVT.MinimumWidth = 120;
            this.DVT.Name = "DVT";
            this.DVT.Width = 120;
            // 
            // SO_LUONG_DE_XUAT
            // 
            this.SO_LUONG_DE_XUAT.DataType = 2;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.SO_LUONG_DE_XUAT.DefaultCellStyle = dataGridViewCellStyle2;
            this.SO_LUONG_DE_XUAT.HeaderText = "Số lượng đề xuất";
            this.SO_LUONG_DE_XUAT.InPutMask = "";
            this.SO_LUONG_DE_XUAT.MaxLength = 32700;
            this.SO_LUONG_DE_XUAT.MinimumWidth = 100;
            this.SO_LUONG_DE_XUAT.Name = "SO_LUONG_DE_XUAT";
            this.SO_LUONG_DE_XUAT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SO_LUONG_DE_XUAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SO_LUONG_DE_XUAT.StringFormat = "N2";
            // 
            // DON_GIA
            // 
            this.DON_GIA.DataType = 2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.DON_GIA.DefaultCellStyle = dataGridViewCellStyle3;
            this.DON_GIA.HeaderText = "Đơn giá";
            this.DON_GIA.InPutMask = "";
            this.DON_GIA.MaxLength = 32700;
            this.DON_GIA.MinimumWidth = 120;
            this.DON_GIA.Name = "DON_GIA";
            this.DON_GIA.StringFormat = "N2";
            this.DON_GIA.Width = 120;
            // 
            // NGOAI_TE
            // 
            this.NGOAI_TE.DataType = 2;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.NGOAI_TE.DefaultCellStyle = dataGridViewCellStyle4;
            this.NGOAI_TE.HeaderText = "Ngoại tệ";
            this.NGOAI_TE.InPutMask = "";
            this.NGOAI_TE.MaxLength = 32700;
            this.NGOAI_TE.MinimumWidth = 140;
            this.NGOAI_TE.Name = "NGOAI_TE";
            this.NGOAI_TE.StringFormat = "N2";
            this.NGOAI_TE.Width = 140;
            // 
            // TY_GIA
            // 
            this.TY_GIA.DataType = 2;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.TY_GIA.DefaultCellStyle = dataGridViewCellStyle5;
            this.TY_GIA.HeaderText = "Tỷ giá";
            this.TY_GIA.InPutMask = "";
            this.TY_GIA.MaxLength = 32700;
            this.TY_GIA.MinimumWidth = 100;
            this.TY_GIA.Name = "TY_GIA";
            this.TY_GIA.StringFormat = "N2";
            // 
            // TY_GIA_USD
            // 
            this.TY_GIA_USD.DataType = 2;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.TY_GIA_USD.DefaultCellStyle = dataGridViewCellStyle6;
            this.TY_GIA_USD.HeaderText = "Tỷ giá USD";
            this.TY_GIA_USD.InPutMask = "";
            this.TY_GIA_USD.MaxLength = 32700;
            this.TY_GIA_USD.MinimumWidth = 100;
            this.TY_GIA_USD.Name = "TY_GIA_USD";
            this.TY_GIA_USD.StringFormat = "N2";
            // 
            // THANH_TIEN
            // 
            this.THANH_TIEN.DataType = 2;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.THANH_TIEN.DefaultCellStyle = dataGridViewCellStyle7;
            this.THANH_TIEN.HeaderText = "Thành tiền";
            this.THANH_TIEN.InPutMask = "";
            this.THANH_TIEN.MaxLength = 32700;
            this.THANH_TIEN.Name = "THANH_TIEN";
            this.THANH_TIEN.StringFormat = "N2";
            this.THANH_TIEN.Width = 120;
            // 
            // THANH_TIEN_VND
            // 
            this.THANH_TIEN_VND.DataType = 2;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.THANH_TIEN_VND.DefaultCellStyle = dataGridViewCellStyle8;
            this.THANH_TIEN_VND.HeaderText = "Thành tiền VNĐ";
            this.THANH_TIEN_VND.InPutMask = "";
            this.THANH_TIEN_VND.MaxLength = 32700;
            this.THANH_TIEN_VND.Name = "THANH_TIEN_VND";
            this.THANH_TIEN_VND.StringFormat = "N2";
            this.THANH_TIEN_VND.Width = 120;
            // 
            // THANH_TIEN_USD
            // 
            this.THANH_TIEN_USD.DataType = 2;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.THANH_TIEN_USD.DefaultCellStyle = dataGridViewCellStyle9;
            this.THANH_TIEN_USD.HeaderText = "Thành tiền USD";
            this.THANH_TIEN_USD.InPutMask = "";
            this.THANH_TIEN_USD.MaxLength = 32700;
            this.THANH_TIEN_USD.Name = "THANH_TIEN_USD";
            this.THANH_TIEN_USD.StringFormat = "N2";
            this.THANH_TIEN_USD.Width = 120;
            // 
            // GHI_CHU
            // 
            this.GHI_CHU.HeaderText = "Ghi chú";
            this.GHI_CHU.Name = "GHI_CHU";
            this.GHI_CHU.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GHI_CHU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GHI_CHU.Width = 140;
            // 
            // LabTitle
            // 
            this.LabTitle.AutoSize = true;
            this.TlbSelectItem.SetColumnSpan(this.LabTitle, 4);
            this.LabTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabTitle.ForeColor = System.Drawing.Color.Navy;
            this.LabTitle.Location = new System.Drawing.Point(3, 0);
            this.LabTitle.Name = "LabTitle";
            this.LabTitle.Size = new System.Drawing.Size(776, 28);
            this.LabTitle.TabIndex = 5;
            this.LabTitle.Text = "CHỌN DỊCH VỤ ĐẶT HÀNG TỪ ĐỀ XUẤT";
            this.LabTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmChonDichVu
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 486);
            this.Controls.Add(this.TlbSelectItem);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChonDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmChonDichVu";
            this.Load += new System.EventHandler(this.frmChonDichVu_Load);
            this.TlbSelectItem.ResumeLayout(false);
            this.TlbSelectItem.PerformLayout();
            this.PelSelectItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlbSelectItem;
        private System.Windows.Forms.Panel PelSelectItem;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnExit;
        private Vietsoft.DataGridViewEditor DgvSelect;
        private System.Windows.Forms.Label LabTitle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHON;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_DE_XUAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_DICH_VU;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN_DICH_VU;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVT;
        private Vietsoft.DataGridViewColumnEditor SO_LUONG_DE_XUAT;
        private Vietsoft.DataGridViewColumnEditor DON_GIA;
        private Vietsoft.DataGridViewColumnEditor NGOAI_TE;
        private Vietsoft.DataGridViewColumnEditor TY_GIA;
        private Vietsoft.DataGridViewColumnEditor TY_GIA_USD;
        private Vietsoft.DataGridViewColumnEditor THANH_TIEN;
        private Vietsoft.DataGridViewColumnEditor THANH_TIEN_VND;
        private Vietsoft.DataGridViewColumnEditor THANH_TIEN_USD;
        private System.Windows.Forms.DataGridViewTextBoxColumn GHI_CHU;
    }
}