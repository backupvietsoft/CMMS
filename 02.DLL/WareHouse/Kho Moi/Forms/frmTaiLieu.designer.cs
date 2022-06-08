namespace WareHouse
{
    partial class frmTaiLieu : DevExpress.XtraEditors.XtraForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TlbTaiLieu = new System.Windows.Forms.TableLayoutPanel();
            this.SplTaiLieu = new System.Windows.Forms.SplitContainer();
            this.GrbTaiLieu = new System.Windows.Forms.GroupBox();
            this.DgvTaiLieu = new System.Windows.Forms.DataGridView();
            this.TEN_TAI_LIEU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TlbQTDuyet = new System.Windows.Forms.TableLayoutPanel();
            this.LabTTLV = new System.Windows.Forms.Label();
            this.GrbQLDTL = new System.Windows.Forms.GroupBox();
            this.DgvQTDTL = new System.Windows.Forms.DataGridView();
            this.STT_SX = new Vietsoft.DataGridViewColumnEditor();
            this.UserName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MS_CN = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.VAI_TRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DON_VI = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.QUYET_DINH = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BAT_BUOC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblQT = new System.Windows.Forms.Label();
            this.chkMDinh = new DevExpress.XtraEditors.CheckEdit();
            this.TxtTL_V = new DevExpress.XtraEditors.TextEdit();
            this.cboQT = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMDinh = new System.Windows.Forms.Label();
            this.TxtTL_H = new DevExpress.XtraEditors.TextEdit();
            this.LabTTLH = new System.Windows.Forms.Label();
            this.LabTTLE = new System.Windows.Forms.Label();
            this.TxtTL_E = new DevExpress.XtraEditors.TextEdit();
            this.lblMsTo = new System.Windows.Forms.Label();
            this.cboTo = new DevExpress.XtraEditors.LookUpEdit();
            this.PelTailieu = new System.Windows.Forms.Panel();
            this.BtnLuu = new System.Windows.Forms.Button();
            this.BtnHuy = new System.Windows.Forms.Button();
            this.BtnThem = new System.Windows.Forms.Button();
            this.BtnSua = new System.Windows.Forms.Button();
            this.BtnXoa = new System.Windows.Forms.Button();
            this.BtnIn = new System.Windows.Forms.Button();
            this.BtnThoat = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnVideo = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TlbTaiLieu.SuspendLayout();
            this.SplTaiLieu.Panel1.SuspendLayout();
            this.SplTaiLieu.Panel2.SuspendLayout();
            this.SplTaiLieu.SuspendLayout();
            this.GrbTaiLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTaiLieu)).BeginInit();
            this.TlbQTDuyet.SuspendLayout();
            this.GrbQLDTL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvQTDTL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMDinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTL_V.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTL_H.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTL_E.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).BeginInit();
            this.PelTailieu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TlbTaiLieu
            // 
            this.TlbTaiLieu.ColumnCount = 2;
            this.TlbTaiLieu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbTaiLieu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.TlbTaiLieu.Controls.Add(this.SplTaiLieu, 0, 1);
            this.TlbTaiLieu.Controls.Add(this.PelTailieu, 0, 2);
            this.TlbTaiLieu.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.TlbTaiLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlbTaiLieu.Location = new System.Drawing.Point(0, 0);
            this.TlbTaiLieu.Name = "TlbTaiLieu";
            this.TlbTaiLieu.RowCount = 3;
            this.TlbTaiLieu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.TlbTaiLieu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbTaiLieu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TlbTaiLieu.Size = new System.Drawing.Size(1186, 705);
            this.TlbTaiLieu.TabIndex = 1;
            // 
            // SplTaiLieu
            // 
            this.TlbTaiLieu.SetColumnSpan(this.SplTaiLieu, 2);
            this.SplTaiLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplTaiLieu.Location = new System.Drawing.Point(3, 41);
            this.SplTaiLieu.Name = "SplTaiLieu";
            // 
            // SplTaiLieu.Panel1
            // 
            this.SplTaiLieu.Panel1.Controls.Add(this.GrbTaiLieu);
            // 
            // SplTaiLieu.Panel2
            // 
            this.SplTaiLieu.Panel2.Controls.Add(this.TlbQTDuyet);
            this.SplTaiLieu.Size = new System.Drawing.Size(1180, 631);
            this.SplTaiLieu.SplitterDistance = 307;
            this.SplTaiLieu.TabIndex = 1;
            // 
            // GrbTaiLieu
            // 
            this.GrbTaiLieu.Controls.Add(this.DgvTaiLieu);
            this.GrbTaiLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbTaiLieu.Location = new System.Drawing.Point(0, 0);
            this.GrbTaiLieu.Name = "GrbTaiLieu";
            this.GrbTaiLieu.Size = new System.Drawing.Size(307, 631);
            this.GrbTaiLieu.TabIndex = 0;
            this.GrbTaiLieu.TabStop = false;
            this.GrbTaiLieu.Text = "Danh sách tài liệu";
            // 
            // DgvTaiLieu
            // 
            this.DgvTaiLieu.AllowUserToAddRows = false;
            this.DgvTaiLieu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvTaiLieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvTaiLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTaiLieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TEN_TAI_LIEU});
            this.DgvTaiLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTaiLieu.Location = new System.Drawing.Point(3, 17);
            this.DgvTaiLieu.Name = "DgvTaiLieu";
            this.DgvTaiLieu.RowHeadersWidth = 30;
            this.DgvTaiLieu.Size = new System.Drawing.Size(301, 611);
            this.DgvTaiLieu.TabIndex = 0;
            this.DgvTaiLieu.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTaiLieu_CellEnter);
            // 
            // TEN_TAI_LIEU
            // 
            this.TEN_TAI_LIEU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TEN_TAI_LIEU.HeaderText = "Tên tài liệu";
            this.TEN_TAI_LIEU.MinimumWidth = 140;
            this.TEN_TAI_LIEU.Name = "TEN_TAI_LIEU";
            // 
            // TlbQTDuyet
            // 
            this.TlbQTDuyet.ColumnCount = 4;
            this.TlbQTDuyet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TlbQTDuyet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TlbQTDuyet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.TlbQTDuyet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TlbQTDuyet.Controls.Add(this.LabTTLV, 0, 0);
            this.TlbQTDuyet.Controls.Add(this.GrbQLDTL, 0, 3);
            this.TlbQTDuyet.Controls.Add(this.lblQT, 2, 1);
            this.TlbQTDuyet.Controls.Add(this.chkMDinh, 3, 2);
            this.TlbQTDuyet.Controls.Add(this.TxtTL_V, 1, 0);
            this.TlbQTDuyet.Controls.Add(this.cboQT, 3, 1);
            this.TlbQTDuyet.Controls.Add(this.lblMDinh, 2, 2);
            this.TlbQTDuyet.Controls.Add(this.TxtTL_H, 1, 2);
            this.TlbQTDuyet.Controls.Add(this.LabTTLH, 0, 2);
            this.TlbQTDuyet.Controls.Add(this.LabTTLE, 0, 1);
            this.TlbQTDuyet.Controls.Add(this.TxtTL_E, 1, 1);
            this.TlbQTDuyet.Controls.Add(this.lblMsTo, 2, 0);
            this.TlbQTDuyet.Controls.Add(this.cboTo, 3, 0);
            this.TlbQTDuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlbQTDuyet.Location = new System.Drawing.Point(0, 0);
            this.TlbQTDuyet.Name = "TlbQTDuyet";
            this.TlbQTDuyet.RowCount = 4;
            this.TlbQTDuyet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TlbQTDuyet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TlbQTDuyet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TlbQTDuyet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbQTDuyet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlbQTDuyet.Size = new System.Drawing.Size(869, 631);
            this.TlbQTDuyet.TabIndex = 0;
            // 
            // LabTTLV
            // 
            this.LabTTLV.AutoSize = true;
            this.LabTTLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabTTLV.Location = new System.Drawing.Point(3, 0);
            this.LabTTLV.Name = "LabTTLV";
            this.LabTTLV.Size = new System.Drawing.Size(104, 25);
            this.LabTTLV.TabIndex = 0;
            this.LabTTLV.Text = "Tên tài liệu việt";
            this.LabTTLV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GrbQLDTL
            // 
            this.TlbQTDuyet.SetColumnSpan(this.GrbQLDTL, 4);
            this.GrbQLDTL.Controls.Add(this.DgvQTDTL);
            this.GrbQLDTL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbQLDTL.Location = new System.Drawing.Point(0, 75);
            this.GrbQLDTL.Margin = new System.Windows.Forms.Padding(0);
            this.GrbQLDTL.Name = "GrbQLDTL";
            this.GrbQLDTL.Size = new System.Drawing.Size(869, 556);
            this.GrbQLDTL.TabIndex = 6;
            this.GrbQLDTL.TabStop = false;
            this.GrbQLDTL.Text = "Quy trình duyệt tài liệu";
            // 
            // DgvQTDTL
            // 
            this.DgvQTDTL.AllowUserToAddRows = false;
            this.DgvQTDTL.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvQTDTL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvQTDTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvQTDTL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT_SX,
            this.UserName,
            this.MS_CN,
            this.VAI_TRO,
            this.DON_VI,
            this.QUYET_DINH,
            this.BAT_BUOC});
            this.DgvQTDTL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvQTDTL.Location = new System.Drawing.Point(3, 17);
            this.DgvQTDTL.Name = "DgvQTDTL";
            this.DgvQTDTL.RowHeadersWidth = 30;
            this.DgvQTDTL.Size = new System.Drawing.Size(863, 536);
            this.DgvQTDTL.TabIndex = 0;
            this.DgvQTDTL.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvQTDTL_UserDeletingRow);
            this.DgvQTDTL.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvQTDTL_CellBeginEdit);
            this.DgvQTDTL.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvQTDTL_UserDeletedRow);
            this.DgvQTDTL.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DgvQTDTL_CellValidating);
            this.DgvQTDTL.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvQTDTL_DataError);
            // 
            // STT_SX
            // 
            this.STT_SX.DataType = 2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.STT_SX.DefaultCellStyle = dataGridViewCellStyle3;
            this.STT_SX.HeaderText = "Bước";
            this.STT_SX.InPutMask = "";
            this.STT_SX.MaxLength = 32700;
            this.STT_SX.MinimumWidth = 60;
            this.STT_SX.Name = "STT_SX";
            this.STT_SX.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STT_SX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.STT_SX.StringFormat = "N0";
            this.STT_SX.Width = 60;
            // 
            // UserName
            // 
            this.UserName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.UserName.HeaderText = "User name";
            this.UserName.MinimumWidth = 140;
            this.UserName.Name = "UserName";
            this.UserName.Width = 140;
            // 
            // MS_CN
            // 
            this.MS_CN.DataPropertyName = "UserName";
            this.MS_CN.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.MS_CN.HeaderText = "MS_CN";
            this.MS_CN.Name = "MS_CN";
            this.MS_CN.ReadOnly = true;
            this.MS_CN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MS_CN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MS_CN.Width = 150;
            // 
            // VAI_TRO
            // 
            this.VAI_TRO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VAI_TRO.HeaderText = "Vai trò";
            this.VAI_TRO.MinimumWidth = 140;
            this.VAI_TRO.Name = "VAI_TRO";
            // 
            // DON_VI
            // 
            this.DON_VI.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DON_VI.HeaderText = "Đơn vị";
            this.DON_VI.MinimumWidth = 140;
            this.DON_VI.Name = "DON_VI";
            this.DON_VI.Width = 140;
            // 
            // QUYET_DINH
            // 
            this.QUYET_DINH.HeaderText = "Quyết định";
            this.QUYET_DINH.MinimumWidth = 80;
            this.QUYET_DINH.Name = "QUYET_DINH";
            this.QUYET_DINH.Width = 80;
            // 
            // BAT_BUOC
            // 
            this.BAT_BUOC.DataPropertyName = "BAT_BUOC";
            this.BAT_BUOC.HeaderText = "BAT_BUOC";
            this.BAT_BUOC.MinimumWidth = 80;
            this.BAT_BUOC.Name = "BAT_BUOC";
            this.BAT_BUOC.Width = 80;
            // 
            // lblQT
            // 
            this.lblQT.AutoSize = true;
            this.lblQT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQT.Location = new System.Drawing.Point(567, 25);
            this.lblQT.Name = "lblQT";
            this.lblQT.Size = new System.Drawing.Size(104, 25);
            this.lblQT.TabIndex = 0;
            this.lblQT.Text = "lblQT";
            this.lblQT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkMDinh
            // 
            this.chkMDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkMDinh.EditValue = true;
            this.chkMDinh.Location = new System.Drawing.Point(677, 53);
            this.chkMDinh.Name = "chkMDinh";
            this.chkMDinh.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkMDinh.Properties.Appearance.Options.UseBackColor = true;
            this.chkMDinh.Properties.Caption = "";
            this.chkMDinh.Size = new System.Drawing.Size(189, 18);
            this.chkMDinh.TabIndex = 26;
            this.chkMDinh.CheckedChanged += new System.EventHandler(this.chkMDinh_CheckedChanged);
            // 
            // TxtTL_V
            // 
            this.TxtTL_V.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtTL_V.EnterMoveNextControl = true;
            this.TxtTL_V.Location = new System.Drawing.Point(113, 3);
            this.TxtTL_V.Name = "TxtTL_V";
            this.TxtTL_V.Size = new System.Drawing.Size(448, 20);
            this.TxtTL_V.TabIndex = 27;
            // 
            // cboQT
            // 
            this.cboQT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboQT.EnterMoveNextControl = true;
            this.cboQT.Location = new System.Drawing.Point(677, 28);
            this.cboQT.Name = "cboQT";
            this.cboQT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboQT.Properties.NullText = "";
            this.cboQT.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboQT.Size = new System.Drawing.Size(189, 20);
            this.cboQT.TabIndex = 28;
            // 
            // lblMDinh
            // 
            this.lblMDinh.AutoSize = true;
            this.lblMDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMDinh.Location = new System.Drawing.Point(567, 50);
            this.lblMDinh.Name = "lblMDinh";
            this.lblMDinh.Size = new System.Drawing.Size(104, 25);
            this.lblMDinh.TabIndex = 0;
            this.lblMDinh.Text = "lblMDinh";
            this.lblMDinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtTL_H
            // 
            this.TxtTL_H.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtTL_H.EnterMoveNextControl = true;
            this.TxtTL_H.Location = new System.Drawing.Point(113, 53);
            this.TxtTL_H.Name = "TxtTL_H";
            this.TxtTL_H.Size = new System.Drawing.Size(448, 20);
            this.TxtTL_H.TabIndex = 27;
            // 
            // LabTTLH
            // 
            this.LabTTLH.AutoSize = true;
            this.LabTTLH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabTTLH.Location = new System.Drawing.Point(3, 50);
            this.LabTTLH.Name = "LabTTLH";
            this.LabTTLH.Size = new System.Drawing.Size(104, 25);
            this.LabTTLH.TabIndex = 2;
            this.LabTTLH.Text = "Tên tài liệu hoa";
            this.LabTTLH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabTTLE
            // 
            this.LabTTLE.AutoSize = true;
            this.LabTTLE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabTTLE.Location = new System.Drawing.Point(3, 25);
            this.LabTTLE.Name = "LabTTLE";
            this.LabTTLE.Size = new System.Drawing.Size(104, 25);
            this.LabTTLE.TabIndex = 1;
            this.LabTTLE.Text = "Tên tài liệu anh";
            this.LabTTLE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtTL_E
            // 
            this.TxtTL_E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtTL_E.EnterMoveNextControl = true;
            this.TxtTL_E.Location = new System.Drawing.Point(113, 28);
            this.TxtTL_E.Name = "TxtTL_E";
            this.TxtTL_E.Size = new System.Drawing.Size(448, 20);
            this.TxtTL_E.TabIndex = 27;
            // 
            // lblMsTo
            // 
            this.lblMsTo.AutoSize = true;
            this.lblMsTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMsTo.Location = new System.Drawing.Point(567, 0);
            this.lblMsTo.Name = "lblMsTo";
            this.lblMsTo.Size = new System.Drawing.Size(104, 25);
            this.lblMsTo.TabIndex = 0;
            this.lblMsTo.Text = "lblMsTo";
            this.lblMsTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTo
            // 
            this.cboTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTo.EnterMoveNextControl = true;
            this.cboTo.Location = new System.Drawing.Point(677, 3);
            this.cboTo.Name = "cboTo";
            this.cboTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTo.Properties.NullText = "";
            this.cboTo.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cboTo.Size = new System.Drawing.Size(189, 20);
            this.cboTo.TabIndex = 28;
            // 
            // PelTailieu
            // 
            this.TlbTaiLieu.SetColumnSpan(this.PelTailieu, 2);
            this.PelTailieu.Controls.Add(this.BtnLuu);
            this.PelTailieu.Controls.Add(this.BtnHuy);
            this.PelTailieu.Controls.Add(this.BtnThem);
            this.PelTailieu.Controls.Add(this.BtnSua);
            this.PelTailieu.Controls.Add(this.BtnXoa);
            this.PelTailieu.Controls.Add(this.BtnIn);
            this.PelTailieu.Controls.Add(this.BtnThoat);
            this.PelTailieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PelTailieu.Location = new System.Drawing.Point(0, 675);
            this.PelTailieu.Margin = new System.Windows.Forms.Padding(0);
            this.PelTailieu.Name = "PelTailieu";
            this.PelTailieu.Size = new System.Drawing.Size(1186, 30);
            this.PelTailieu.TabIndex = 2;
            // 
            // BtnLuu
            // 
            this.BtnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLuu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLuu.Location = new System.Drawing.Point(931, 0);
            this.BtnLuu.Name = "BtnLuu";
            this.BtnLuu.Size = new System.Drawing.Size(85, 30);
            this.BtnLuu.TabIndex = 6;
            this.BtnLuu.Text = "&Lưu";
            this.BtnLuu.UseVisualStyleBackColor = true;
            this.BtnLuu.Click += new System.EventHandler(this.BtnLuu_Click);
            // 
            // BtnHuy
            // 
            this.BtnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnHuy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHuy.Location = new System.Drawing.Point(1016, 0);
            this.BtnHuy.Name = "BtnHuy";
            this.BtnHuy.Size = new System.Drawing.Size(85, 30);
            this.BtnHuy.TabIndex = 5;
            this.BtnHuy.Text = "&Hủy";
            this.BtnHuy.UseVisualStyleBackColor = true;
            this.BtnHuy.Click += new System.EventHandler(this.BtnHuy_Click);
            // 
            // BtnThem
            // 
            this.BtnThem.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnThem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnThem.Location = new System.Drawing.Point(761, 0);
            this.BtnThem.Name = "BtnThem";
            this.BtnThem.Size = new System.Drawing.Size(85, 30);
            this.BtnThem.TabIndex = 4;
            this.BtnThem.Text = "&Thêm";
            this.BtnThem.UseVisualStyleBackColor = true;
            this.BtnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // BtnSua
            // 
            this.BtnSua.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSua.Location = new System.Drawing.Point(846, 0);
            this.BtnSua.Name = "BtnSua";
            this.BtnSua.Size = new System.Drawing.Size(85, 30);
            this.BtnSua.TabIndex = 3;
            this.BtnSua.Text = "&Sửa";
            this.BtnSua.UseVisualStyleBackColor = true;
            this.BtnSua.Click += new System.EventHandler(this.BtnSua_Click);
            // 
            // BtnXoa
            // 
            this.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnXoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnXoa.Location = new System.Drawing.Point(931, 0);
            this.BtnXoa.Name = "BtnXoa";
            this.BtnXoa.Size = new System.Drawing.Size(85, 30);
            this.BtnXoa.TabIndex = 2;
            this.BtnXoa.Text = "&Xóa";
            this.BtnXoa.UseVisualStyleBackColor = true;
            this.BtnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // BtnIn
            // 
            this.BtnIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnIn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIn.Location = new System.Drawing.Point(1016, 0);
            this.BtnIn.Name = "BtnIn";
            this.BtnIn.Size = new System.Drawing.Size(85, 30);
            this.BtnIn.TabIndex = 1;
            this.BtnIn.Text = "&In";
            this.BtnIn.UseVisualStyleBackColor = true;
            // 
            // BtnThoat
            // 
            this.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnThoat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnThoat.Location = new System.Drawing.Point(1101, 0);
            this.BtnThoat.Name = "BtnThoat";
            this.BtnThoat.Size = new System.Drawing.Size(85, 30);
            this.BtnThoat.TabIndex = 0;
            this.BtnThoat.Text = "Th&oát";
            this.BtnThoat.UseVisualStyleBackColor = true;
            this.BtnThoat.Click += new System.EventHandler(this.BtnThoat_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnVideo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnHelp, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1125, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(58, 32);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnVideo
            // 
            this.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnVideo.Location = new System.Drawing.Point(30, 1);
            this.btnVideo.Margin = new System.Windows.Forms.Padding(1);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(27, 30);
            this.btnVideo.TabIndex = 101;
            this.btnVideo.Tag = "Warehouse!frmTaiLieu";
            // 
            // btnHelp
            // 
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnHelp.Location = new System.Drawing.Point(1, 1);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(1);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 30);
            this.btnHelp.TabIndex = 100;
            this.btnHelp.Tag = "Warehouse!frmTaiLieu";
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên tài liệu";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 140;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Bước";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Vai trò";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 140;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // frmTaiLieu
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 705);
            this.Controls.Add(this.TlbTaiLieu);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmTaiLieu";
            this.Text = "Tài Liệu - Quy Trình Duyệt Tài Liệu";
            this.Load += new System.EventHandler(this.frmDocument_Load);
            this.TlbTaiLieu.ResumeLayout(false);
            this.SplTaiLieu.Panel1.ResumeLayout(false);
            this.SplTaiLieu.Panel2.ResumeLayout(false);
            this.SplTaiLieu.ResumeLayout(false);
            this.GrbTaiLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTaiLieu)).EndInit();
            this.TlbQTDuyet.ResumeLayout(false);
            this.TlbQTDuyet.PerformLayout();
            this.GrbQLDTL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvQTDTL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMDinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTL_V.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTL_H.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTL_E.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).EndInit();
            this.PelTailieu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TlbTaiLieu;
        internal System.Windows.Forms.SplitContainer SplTaiLieu;
        internal System.Windows.Forms.GroupBox GrbTaiLieu;
        internal System.Windows.Forms.DataGridView DgvTaiLieu;
        internal System.Windows.Forms.DataGridViewTextBoxColumn TEN_TAI_LIEU;
        internal System.Windows.Forms.TableLayoutPanel TlbQTDuyet;
        internal System.Windows.Forms.Label LabTTLV;
        internal System.Windows.Forms.Label LabTTLE;
        internal System.Windows.Forms.Label LabTTLH;
        internal System.Windows.Forms.GroupBox GrbQLDTL;
        internal System.Windows.Forms.DataGridView DgvQTDTL;
        internal System.Windows.Forms.Panel PelTailieu;
        internal System.Windows.Forms.Button BtnLuu;
        internal System.Windows.Forms.Button BtnHuy;
        internal System.Windows.Forms.Button BtnThem;
        internal System.Windows.Forms.Button BtnSua;
        internal System.Windows.Forms.Button BtnXoa;
        internal System.Windows.Forms.Button BtnIn;
        internal System.Windows.Forms.Button BtnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        internal System.Windows.Forms.Label lblMsTo;
        internal System.Windows.Forms.Label lblQT;
        internal System.Windows.Forms.Label lblMDinh;
        private DevExpress.XtraEditors.CheckEdit chkMDinh;
        private DevExpress.XtraEditors.TextEdit TxtTL_V;
        private DevExpress.XtraEditors.TextEdit TxtTL_E;
        private DevExpress.XtraEditors.TextEdit TxtTL_H;
        private DevExpress.XtraEditors.LookUpEdit cboTo;
        private DevExpress.XtraEditors.LookUpEdit cboQT;
        private Vietsoft.DataGridViewColumnEditor STT_SX;
        private System.Windows.Forms.DataGridViewComboBoxColumn UserName;
        private System.Windows.Forms.DataGridViewComboBoxColumn MS_CN;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAI_TRO;
        private System.Windows.Forms.DataGridViewComboBoxColumn DON_VI;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QUYET_DINH;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BAT_BUOC;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal DevExpress.XtraEditors.SimpleButton btnHelp;
        internal DevExpress.XtraEditors.SimpleButton btnVideo;
    }
}

