namespace WareHouse
{
    partial class frmChonPTDatHang : DevExpress.XtraEditors.XtraForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TlbSelectItem = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMSPT = new System.Windows.Forms.Label();
            this.txtMSPT = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.btnNotALL = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.DgvSelect = new Vietsoft.DataGridViewEditor();
            this.CHON = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MS_PT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MS_PT_CTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MS_DE_XUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEN_LOAI_VT_TV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PART_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEN_PT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUY_CACH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TON_KHO = new Vietsoft.DataGridViewColumnEditor();
            this.TON_MIN = new Vietsoft.DataGridViewColumnEditor();
            this.TON_MAX = new Vietsoft.DataGridViewColumnEditor();
            this.SL_DE_XUAT = new Vietsoft.DataGridViewColumnEditor();
            this.SL_DAT_HANG = new Vietsoft.DataGridViewColumnEditor();
            this.NGAY_CUOI = new Vietsoft.DataGridViewColumnEditor();
            this.NHA_CUONG_CAP_CUOI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DON_GIA_CUOI = new Vietsoft.DataGridViewColumnEditor();
            this.NGOAI_TE_CUOI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THUE_VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabKho = new System.Windows.Forms.Label();
            this.CboKho = new System.Windows.Forms.ComboBox();
            this.LabTitle = new System.Windows.Forms.Label();
            this.chkDeXuat = new System.Windows.Forms.CheckBox();
            this.TlbSelectItem.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // TlbSelectItem
            // 
            this.TlbSelectItem.ColumnCount = 5;
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 242F));
            this.TlbSelectItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlbSelectItem.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.TlbSelectItem.Controls.Add(this.DgvSelect, 0, 2);
            this.TlbSelectItem.Controls.Add(this.LabKho, 1, 1);
            this.TlbSelectItem.Controls.Add(this.CboKho, 2, 1);
            this.TlbSelectItem.Controls.Add(this.LabTitle, 0, 0);
            this.TlbSelectItem.Controls.Add(this.chkDeXuat, 3, 1);
            this.TlbSelectItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlbSelectItem.Location = new System.Drawing.Point(0, 0);
            this.TlbSelectItem.Name = "TlbSelectItem";
            this.TlbSelectItem.RowCount = 4;
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbSelectItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.TlbSelectItem.Size = new System.Drawing.Size(884, 561);
            this.TlbSelectItem.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.TlbSelectItem.SetColumnSpan(this.tableLayoutPanel1, 5);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.lblMSPT, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMSPT, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThoat, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnOK, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNotALL, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAll, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 522);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 36);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lblMSPT
            // 
            this.lblMSPT.AutoSize = true;
            this.lblMSPT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMSPT.Location = new System.Drawing.Point(3, 23);
            this.lblMSPT.Name = "lblMSPT";
            this.lblMSPT.Size = new System.Drawing.Size(114, 13);
            this.lblMSPT.TabIndex = 5;
            this.lblMSPT.Text = "Loc theo MSPT";
            // 
            // txtMSPT
            // 
            this.txtMSPT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtMSPT.Location = new System.Drawing.Point(123, 12);
            this.txtMSPT.Name = "txtMSPT";
            this.txtMSPT.Size = new System.Drawing.Size(114, 21);
            this.txtMSPT.TabIndex = 4;
            this.txtMSPT.TextChanged += new System.EventHandler(this.txtMSPT_TextChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(771, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Th&oát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Location = new System.Drawing.Point(661, 3);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(104, 30);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "&Thực hiện";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnNotALL
            // 
            this.btnNotALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNotALL.Location = new System.Drawing.Point(541, 3);
            this.btnNotALL.Name = "btnNotALL";
            this.btnNotALL.Size = new System.Drawing.Size(114, 30);
            this.btnNotALL.TabIndex = 3;
            this.btnNotALL.Text = "Clear";
            this.btnNotALL.UseVisualStyleBackColor = true;
            this.btnNotALL.Click += new System.EventHandler(this.btnNotAll_Click);
            // 
            // btnAll
            // 
            this.btnAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAll.Location = new System.Drawing.Point(421, 3);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(114, 30);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // DgvSelect
            // 
            this.DgvSelect.AllowUserToAddRows = false;
            this.DgvSelect.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSelect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHON,
            this.MS_PT,
            this.MS_PT_CTY,
            this.MS_DE_XUAT,
            this.TEN_LOAI_VT_TV,
            this.PART_NO,
            this.TEN_PT,
            this.QUY_CACH,
            this.DVT,
            this.TON_KHO,
            this.TON_MIN,
            this.TON_MAX,
            this.SL_DE_XUAT,
            this.SL_DAT_HANG,
            this.NGAY_CUOI,
            this.NHA_CUONG_CAP_CUOI,
            this.DON_GIA_CUOI,
            this.NGOAI_TE_CUOI,
            this.THUE_VAT});
            this.TlbSelectItem.SetColumnSpan(this.DgvSelect, 5);
            this.DgvSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSelect.Location = new System.Drawing.Point(3, 53);
            this.DgvSelect.Name = "DgvSelect";
            this.DgvSelect.RowHeadersVisible = false;
            this.DgvSelect.RowHeadersWidth = 30;
            this.DgvSelect.Size = new System.Drawing.Size(878, 463);
            this.DgvSelect.TabIndex = 2;
            // 
            // CHON
            // 
            this.CHON.HeaderText = "";
            this.CHON.MinimumWidth = 40;
            this.CHON.Name = "CHON";
            this.CHON.Width = 40;
            // 
            // MS_PT
            // 
            this.MS_PT.HeaderText = "Mã số PT";
            this.MS_PT.MinimumWidth = 120;
            this.MS_PT.Name = "MS_PT";
            this.MS_PT.Width = 120;
            // 
            // MS_PT_CTY
            // 
            this.MS_PT_CTY.FillWeight = 120F;
            this.MS_PT_CTY.HeaderText = "MS_PT_CTY";
            this.MS_PT_CTY.Name = "MS_PT_CTY";
            this.MS_PT_CTY.Width = 120;
            // 
            // MS_DE_XUAT
            // 
            this.MS_DE_XUAT.HeaderText = "Mã số đề xuất";
            this.MS_DE_XUAT.MinimumWidth = 120;
            this.MS_DE_XUAT.Name = "MS_DE_XUAT";
            this.MS_DE_XUAT.Width = 120;
            // 
            // TEN_LOAI_VT_TV
            // 
            this.TEN_LOAI_VT_TV.HeaderText = "Loại vật tư phụ tùng";
            this.TEN_LOAI_VT_TV.MinimumWidth = 140;
            this.TEN_LOAI_VT_TV.Name = "TEN_LOAI_VT_TV";
            this.TEN_LOAI_VT_TV.Width = 140;
            // 
            // PART_NO
            // 
            this.PART_NO.HeaderText = "Part no";
            this.PART_NO.MinimumWidth = 120;
            this.PART_NO.Name = "PART_NO";
            this.PART_NO.Width = 120;
            // 
            // TEN_PT
            // 
            this.TEN_PT.HeaderText = "Tên phụ tùng";
            this.TEN_PT.MinimumWidth = 140;
            this.TEN_PT.Name = "TEN_PT";
            this.TEN_PT.Width = 140;
            // 
            // QUY_CACH
            // 
            this.QUY_CACH.HeaderText = "Quy cách";
            this.QUY_CACH.MinimumWidth = 140;
            this.QUY_CACH.Name = "QUY_CACH";
            this.QUY_CACH.Width = 140;
            // 
            // DVT
            // 
            this.DVT.HeaderText = "ĐVT";
            this.DVT.MinimumWidth = 140;
            this.DVT.Name = "DVT";
            this.DVT.Width = 140;
            // 
            // TON_KHO
            // 
            this.TON_KHO.DataType = 2;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.TON_KHO.DefaultCellStyle = dataGridViewCellStyle10;
            this.TON_KHO.HeaderText = "Tồn kho";
            this.TON_KHO.InPutMask = "";
            this.TON_KHO.MaxLength = 32700;
            this.TON_KHO.MinimumWidth = 120;
            this.TON_KHO.Name = "TON_KHO";
            this.TON_KHO.StringFormat = "N2";
            this.TON_KHO.Width = 120;
            // 
            // TON_MIN
            // 
            this.TON_MIN.DataType = 2;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.TON_MIN.DefaultCellStyle = dataGridViewCellStyle11;
            this.TON_MIN.HeaderText = "Tồn min";
            this.TON_MIN.InPutMask = "";
            this.TON_MIN.MaxLength = 32700;
            this.TON_MIN.MinimumWidth = 120;
            this.TON_MIN.Name = "TON_MIN";
            this.TON_MIN.StringFormat = "N2";
            this.TON_MIN.Width = 120;
            // 
            // TON_MAX
            // 
            this.TON_MAX.DataType = 2;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.TON_MAX.DefaultCellStyle = dataGridViewCellStyle12;
            this.TON_MAX.HeaderText = "Tồn max";
            this.TON_MAX.InPutMask = "";
            this.TON_MAX.MaxLength = 32700;
            this.TON_MAX.MinimumWidth = 120;
            this.TON_MAX.Name = "TON_MAX";
            this.TON_MAX.StringFormat = "N2";
            this.TON_MAX.Width = 120;
            // 
            // SL_DE_XUAT
            // 
            this.SL_DE_XUAT.DataType = 2;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            this.SL_DE_XUAT.DefaultCellStyle = dataGridViewCellStyle13;
            this.SL_DE_XUAT.HeaderText = "Sl đề xuất";
            this.SL_DE_XUAT.InPutMask = "";
            this.SL_DE_XUAT.MaxLength = 32700;
            this.SL_DE_XUAT.MinimumWidth = 120;
            this.SL_DE_XUAT.Name = "SL_DE_XUAT";
            this.SL_DE_XUAT.StringFormat = "N2";
            this.SL_DE_XUAT.Width = 120;
            // 
            // SL_DAT_HANG
            // 
            this.SL_DAT_HANG.DataType = 2;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            this.SL_DAT_HANG.DefaultCellStyle = dataGridViewCellStyle14;
            this.SL_DAT_HANG.HeaderText = "Sl đặt hang";
            this.SL_DAT_HANG.InPutMask = "";
            this.SL_DAT_HANG.MaxLength = 32700;
            this.SL_DAT_HANG.MinimumWidth = 120;
            this.SL_DAT_HANG.Name = "SL_DAT_HANG";
            this.SL_DAT_HANG.StringFormat = "N2";
            this.SL_DAT_HANG.Width = 120;
            // 
            // NGAY_CUOI
            // 
            this.NGAY_CUOI.DataType = 4;
            dataGridViewCellStyle15.Format = "dd/MM/yyyy";
            this.NGAY_CUOI.DefaultCellStyle = dataGridViewCellStyle15;
            this.NGAY_CUOI.HeaderText = "Ngày cuối";
            this.NGAY_CUOI.InPutMask = "00/00/0000";
            this.NGAY_CUOI.MaxLength = 32700;
            this.NGAY_CUOI.MinimumWidth = 100;
            this.NGAY_CUOI.Name = "NGAY_CUOI";
            this.NGAY_CUOI.StringFormat = "dd/MM/yyyy";
            // 
            // NHA_CUONG_CAP_CUOI
            // 
            this.NHA_CUONG_CAP_CUOI.HeaderText = "Nhà cung cấp";
            this.NHA_CUONG_CAP_CUOI.MinimumWidth = 140;
            this.NHA_CUONG_CAP_CUOI.Name = "NHA_CUONG_CAP_CUOI";
            this.NHA_CUONG_CAP_CUOI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NHA_CUONG_CAP_CUOI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NHA_CUONG_CAP_CUOI.Width = 140;
            // 
            // DON_GIA_CUOI
            // 
            this.DON_GIA_CUOI.DataType = 2;
            dataGridViewCellStyle16.Format = "N2";
            this.DON_GIA_CUOI.DefaultCellStyle = dataGridViewCellStyle16;
            this.DON_GIA_CUOI.HeaderText = "Đơn giá cuối";
            this.DON_GIA_CUOI.InPutMask = "";
            this.DON_GIA_CUOI.MaxLength = 32700;
            this.DON_GIA_CUOI.MinimumWidth = 120;
            this.DON_GIA_CUOI.Name = "DON_GIA_CUOI";
            this.DON_GIA_CUOI.StringFormat = "N2";
            this.DON_GIA_CUOI.Width = 120;
            // 
            // NGOAI_TE_CUOI
            // 
            this.NGOAI_TE_CUOI.HeaderText = "Ngoại tệ cuối";
            this.NGOAI_TE_CUOI.MinimumWidth = 140;
            this.NGOAI_TE_CUOI.Name = "NGOAI_TE_CUOI";
            this.NGOAI_TE_CUOI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NGOAI_TE_CUOI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NGOAI_TE_CUOI.Width = 140;
            // 
            // THUE_VAT
            // 
            this.THUE_VAT.HeaderText = "THUE_VAT";
            this.THUE_VAT.Name = "THUE_VAT";
            this.THUE_VAT.Visible = false;
            // 
            // LabKho
            // 
            this.LabKho.AutoSize = true;
            this.LabKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabKho.Location = new System.Drawing.Point(178, 28);
            this.LabKho.Margin = new System.Windows.Forms.Padding(0);
            this.LabKho.Name = "LabKho";
            this.LabKho.Size = new System.Drawing.Size(85, 22);
            this.LabKho.TabIndex = 3;
            this.LabKho.Text = "Chọn kho";
            this.LabKho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CboKho
            // 
            this.CboKho.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CboKho.FormattingEnabled = true;
            this.CboKho.Location = new System.Drawing.Point(263, 29);
            this.CboKho.Margin = new System.Windows.Forms.Padding(0);
            this.CboKho.Name = "CboKho";
            this.CboKho.Size = new System.Drawing.Size(200, 21);
            this.CboKho.TabIndex = 4;
            this.CboKho.SelectedValueChanged += new System.EventHandler(this.CboKho_SelectedValueChanged);
            // 
            // LabTitle
            // 
            this.LabTitle.AutoSize = true;
            this.TlbSelectItem.SetColumnSpan(this.LabTitle, 5);
            this.LabTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabTitle.ForeColor = System.Drawing.Color.Navy;
            this.LabTitle.Location = new System.Drawing.Point(3, 0);
            this.LabTitle.Name = "LabTitle";
            this.LabTitle.Size = new System.Drawing.Size(878, 28);
            this.LabTitle.TabIndex = 5;
            this.LabTitle.Text = "CHỌN PHỤ TÙNG ĐẶT HÀNG";
            this.LabTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkDeXuat
            // 
            this.chkDeXuat.AutoSize = true;
            this.chkDeXuat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDeXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkDeXuat.Location = new System.Drawing.Point(466, 31);
            this.chkDeXuat.Name = "chkDeXuat";
            this.chkDeXuat.Size = new System.Drawing.Size(236, 16);
            this.chkDeXuat.TabIndex = 8;
            this.chkDeXuat.Text = "chkDeXuat";
            this.chkDeXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDeXuat.UseVisualStyleBackColor = true;
            this.chkDeXuat.CheckedChanged += new System.EventHandler(this.chkDeXuat_CheckedChanged);
            // 
            // frmChonPTDatHang
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.TlbSelectItem);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChonPTDatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmChonPTDatHang";
            this.Load += new System.EventHandler(this.frmChonPTDatHang_Load);
            this.TlbSelectItem.ResumeLayout(false);
            this.TlbSelectItem.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlbSelectItem;
        private Vietsoft.DataGridViewEditor DgvSelect;
        private System.Windows.Forms.Label LabKho;
        private System.Windows.Forms.ComboBox CboKho;
        private System.Windows.Forms.Label LabTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMSPT;
        private System.Windows.Forms.TextBox txtMSPT;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button btnNotALL;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHON;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_PT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_PT_CTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_DE_XUAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN_LOAI_VT_TV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN_PT;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUY_CACH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVT;
        private Vietsoft.DataGridViewColumnEditor TON_KHO;
        private Vietsoft.DataGridViewColumnEditor TON_MIN;
        private Vietsoft.DataGridViewColumnEditor TON_MAX;
        private Vietsoft.DataGridViewColumnEditor SL_DE_XUAT;
        private Vietsoft.DataGridViewColumnEditor SL_DAT_HANG;
        private Vietsoft.DataGridViewColumnEditor NGAY_CUOI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NHA_CUONG_CAP_CUOI;
        private Vietsoft.DataGridViewColumnEditor DON_GIA_CUOI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGOAI_TE_CUOI;
        private System.Windows.Forms.DataGridViewTextBoxColumn THUE_VAT;
        private System.Windows.Forms.CheckBox chkDeXuat;


    }
}