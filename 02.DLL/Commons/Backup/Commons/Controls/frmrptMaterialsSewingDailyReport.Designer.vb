<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptMaterialsSewingDailyReport
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptMaterialsSewingDailyReport))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnBoChon = New System.Windows.Forms.Button
        Me.btnChonALL = New System.Windows.Forms.Button
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.lbaKho = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.lbaTuNgay = New System.Windows.Forms.Label
        Me.lbaDenNgay = New System.Windows.Forms.Label
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox
        Me.grbBPCP = New System.Windows.Forms.GroupBox
        Me.grdListBPCP = New System.Windows.Forms.DataGridView
        Me.MS_BP_CHIU_PHI = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TEN_BP_CHIU_PHI = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboKho = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grdListVTPT = New System.Windows.Forms.GroupBox
        Me.grdVTPT = New System.Windows.Forms.DataGridView
        Me.CHON_VTPT = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MS_PT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_PT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QUY_CACH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.btnBochonall1 = New System.Windows.Forms.Button
        Me.btnChonall1 = New System.Windows.Forms.Button
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.grbBPCP.SuspendLayout()
        CType(Me.grdListBPCP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grdListVTPT.SuspendLayout()
        CType(Me.grdVTPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBoChon
        '
        Me.btnBoChon.BackgroundImage = Global.Commons.My.Resources.Resources.UnCheck
        Me.btnBoChon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBoChon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoChon.Location = New System.Drawing.Point(103, 3)
        Me.btnBoChon.Name = "btnBoChon"
        Me.btnBoChon.Size = New System.Drawing.Size(90, 23)
        Me.btnBoChon.TabIndex = 3
        Me.btnBoChon.Text = "Bỏ chọn"
        Me.btnBoChon.UseVisualStyleBackColor = True
        '
        'btnChonALL
        '
        Me.btnChonALL.BackgroundImage = Global.Commons.My.Resources.Resources.Check
        Me.btnChonALL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnChonALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChonALL.Location = New System.Drawing.Point(3, 3)
        Me.btnChonALL.Name = "btnChonALL"
        Me.btnChonALL.Size = New System.Drawing.Size(90, 23)
        Me.btnChonALL.TabIndex = 2
        Me.btnChonALL.Text = "Chọn"
        Me.btnChonALL.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(260, 3)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 23)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'lbaKho
        '
        Me.lbaKho.AutoSize = True
        Me.lbaKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaKho.Location = New System.Drawing.Point(3, 36)
        Me.lbaKho.Name = "lbaKho"
        Me.lbaKho.Size = New System.Drawing.Size(62, 32)
        Me.lbaKho.TabIndex = 10
        Me.lbaKho.Text = "Kho"
        Me.lbaKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grbBPCP, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaKho, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboKho, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grdListVTPT, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(774, 487)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBoChon, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnChonALL, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(311, 455)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(460, 29)
        Me.TableLayoutPanel2.TabIndex = 18
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(363, 3)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(87, 23)
        Me.btnThoat.TabIndex = 35
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(3, 11)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(62, 25)
        Me.lbaTuNgay.TabIndex = 1
        Me.lbaTuNgay.Text = "Từ ngày"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(150, 11)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(62, 25)
        Me.lbaDenNgay.TabIndex = 2
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Location = New System.Drawing.Point(71, 14)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(73, 20)
        Me.mtxtTuNgay.TabIndex = 3
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'mtxtDenNgay
        '
        Me.mtxtDenNgay.Location = New System.Drawing.Point(218, 14)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(87, 20)
        Me.mtxtDenNgay.TabIndex = 4
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'grbBPCP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grbBPCP, 4)
        Me.grbBPCP.Controls.Add(Me.grdListBPCP)
        Me.grbBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbBPCP.Location = New System.Drawing.Point(3, 71)
        Me.grbBPCP.Name = "grbBPCP"
        Me.grbBPCP.Size = New System.Drawing.Size(302, 378)
        Me.grbBPCP.TabIndex = 7
        Me.grbBPCP.TabStop = False
        Me.grbBPCP.Text = "Bộ phận chịu phí"
        '
        'grdListBPCP
        '
        Me.grdListBPCP.AllowUserToAddRows = False
        Me.grdListBPCP.AllowUserToDeleteRows = False
        Me.grdListBPCP.AllowUserToResizeRows = False
        Me.grdListBPCP.BackgroundColor = System.Drawing.Color.White
        Me.grdListBPCP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdListBPCP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListBPCP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_BP_CHIU_PHI, Me.CHON, Me.TEN_BP_CHIU_PHI})
        Me.grdListBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListBPCP.Location = New System.Drawing.Point(3, 16)
        Me.grdListBPCP.Name = "grdListBPCP"
        Me.grdListBPCP.RowHeadersWidth = 25
        Me.grdListBPCP.Size = New System.Drawing.Size(296, 359)
        Me.grdListBPCP.TabIndex = 0
        '
        'MS_BP_CHIU_PHI
        '
        Me.MS_BP_CHIU_PHI.HeaderText = "MS_BP_CHIU_PHI"
        Me.MS_BP_CHIU_PHI.Name = "MS_BP_CHIU_PHI"
        Me.MS_BP_CHIU_PHI.Visible = False
        '
        'CHON
        '
        Me.CHON.HeaderText = "Chọn"
        Me.CHON.MinimumWidth = 60
        Me.CHON.Name = "CHON"
        Me.CHON.Width = 60
        '
        'TEN_BP_CHIU_PHI
        '
        Me.TEN_BP_CHIU_PHI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_BP_CHIU_PHI.HeaderText = "Tên BP Chịu phí"
        Me.TEN_BP_CHIU_PHI.Name = "TEN_BP_CHIU_PHI"
        Me.TEN_BP_CHIU_PHI.ReadOnly = True
        '
        'cboKho
        '
        Me.cboKho.AssemblyName = ""
        Me.cboKho.BackColor = System.Drawing.Color.White
        Me.cboKho.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboKho, 3)
        Me.cboKho.Display = ""
        Me.cboKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboKho.ErrorProviderControl = Me.ErrorProvider1
        Me.cboKho.FormattingEnabled = True
        Me.cboKho.IsAll = True
        Me.cboKho.IsNew = False
        Me.cboKho.ItemAll = " < ALL > "
        Me.cboKho.ItemNew = "...New"
        Me.cboKho.Location = New System.Drawing.Point(71, 39)
        Me.cboKho.MethodName = ""
        Me.cboKho.Name = "cboKho"
        Me.cboKho.Param = ""
        Me.cboKho.Size = New System.Drawing.Size(234, 21)
        Me.cboKho.StoreName = ""
        Me.cboKho.TabIndex = 11
        Me.cboKho.Table = Nothing
        Me.cboKho.TextReadonly = False
        Me.cboKho.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'grdListVTPT
        '
        Me.grdListVTPT.Controls.Add(Me.grdVTPT)
        Me.grdListVTPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListVTPT.Location = New System.Drawing.Point(311, 3)
        Me.grdListVTPT.Name = "grdListVTPT"
        Me.TableLayoutPanel1.SetRowSpan(Me.grdListVTPT, 4)
        Me.grdListVTPT.Size = New System.Drawing.Size(460, 446)
        Me.grdListVTPT.TabIndex = 8
        Me.grdListVTPT.TabStop = False
        Me.grdListVTPT.Text = "Danh sách vật tư phụ tùng"
        '
        'grdVTPT
        '
        Me.grdVTPT.AllowUserToAddRows = False
        Me.grdVTPT.AllowUserToDeleteRows = False
        Me.grdVTPT.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdVTPT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grdVTPT.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdVTPT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdVTPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdVTPT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON_VTPT, Me.MS_PT, Me.TEN_PT, Me.QUY_CACH})
        Me.grdVTPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdVTPT.Location = New System.Drawing.Point(3, 16)
        Me.grdVTPT.MultiSelect = False
        Me.grdVTPT.Name = "grdVTPT"
        Me.grdVTPT.RowHeadersWidth = 25
        Me.grdVTPT.Size = New System.Drawing.Size(454, 427)
        Me.grdVTPT.TabIndex = 0
        '
        'CHON_VTPT
        '
        Me.CHON_VTPT.DataPropertyName = "CHON_VTPT"
        Me.CHON_VTPT.HeaderText = "Chọn"
        Me.CHON_VTPT.MinimumWidth = 60
        Me.CHON_VTPT.Name = "CHON_VTPT"
        Me.CHON_VTPT.ReadOnly = True
        Me.CHON_VTPT.Width = 60
        '
        'MS_PT
        '
        Me.MS_PT.DataPropertyName = "MS_PT"
        Me.MS_PT.HeaderText = "Mã Phụ tùng"
        Me.MS_PT.MinimumWidth = 120
        Me.MS_PT.Name = "MS_PT"
        Me.MS_PT.ReadOnly = True
        Me.MS_PT.Width = 120
        '
        'TEN_PT
        '
        Me.TEN_PT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_PT.DataPropertyName = "TEN_PT"
        Me.TEN_PT.HeaderText = "Tên PT"
        Me.TEN_PT.MinimumWidth = 200
        Me.TEN_PT.Name = "TEN_PT"
        Me.TEN_PT.ReadOnly = True
        '
        'QUY_CACH
        '
        Me.QUY_CACH.DataPropertyName = "QUY_CACH"
        Me.QUY_CACH.HeaderText = "Quy cách"
        Me.QUY_CACH.MinimumWidth = 150
        Me.QUY_CACH.Name = "QUY_CACH"
        Me.QUY_CACH.ReadOnly = True
        Me.QUY_CACH.Width = 150
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel3, 4)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnBochonall1, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnChonall1, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 455)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(302, 29)
        Me.TableLayoutPanel3.TabIndex = 19
        '
        'btnBochonall1
        '
        Me.btnBochonall1.BackgroundImage = Global.Commons.My.Resources.Resources.UnCheck
        Me.btnBochonall1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBochonall1.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBochonall1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBochonall1.Location = New System.Drawing.Point(103, 3)
        Me.btnBochonall1.Name = "btnBochonall1"
        Me.btnBochonall1.Size = New System.Drawing.Size(90, 23)
        Me.btnBochonall1.TabIndex = 3
        Me.btnBochonall1.Text = "Bỏ chọn"
        Me.btnBochonall1.UseVisualStyleBackColor = True
        '
        'btnChonall1
        '
        Me.btnChonall1.BackgroundImage = Global.Commons.My.Resources.Resources.Check
        Me.btnChonall1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnChonall1.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnChonall1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChonall1.Location = New System.Drawing.Point(3, 3)
        Me.btnChonall1.Name = "btnChonall1"
        Me.btnChonall1.Size = New System.Drawing.Size(90, 23)
        Me.btnChonall1.TabIndex = 2
        Me.btnChonall1.Text = "Chọn"
        Me.btnChonall1.UseVisualStyleBackColor = True
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.HeaderText = "CHON_VTPT"
        Me.DataGridViewCheckBoxColumn2.MinimumWidth = 60
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 60
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "CHON"
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 60
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS_BP_CHIU_PHI"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "TEN_BP_CHIU_PHI"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "MS_PT"
        Me.DataGridViewTextBoxColumn3.HeaderText = "MS_PT"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "TEN_PT"
        Me.DataGridViewTextBoxColumn4.HeaderText = "TEN_PT"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "QUY_CACH"
        Me.DataGridViewTextBoxColumn5.HeaderText = "QUY_CACH"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'frmrptMaterialsSewingDailyReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptMaterialsSewingDailyReport"
        Me.Size = New System.Drawing.Size(774, 487)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.grbBPCP.ResumeLayout(False)
        CType(Me.grdListBPCP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grdListVTPT.ResumeLayout(False)
        CType(Me.grdVTPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBoChon As System.Windows.Forms.Button
    Friend WithEvents btnChonALL As System.Windows.Forms.Button
    Friend WithEvents lbaKho As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents grbBPCP As System.Windows.Forms.GroupBox
    Friend WithEvents grdListBPCP As System.Windows.Forms.DataGridView
    Friend WithEvents cboKho As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents grdListVTPT As System.Windows.Forms.GroupBox
    Friend WithEvents grdVTPT As System.Windows.Forms.DataGridView
    Friend WithEvents btnBochonall1 As System.Windows.Forms.Button
    Friend WithEvents btnChonall1 As System.Windows.Forms.Button
    Friend WithEvents MS_BP_CHIU_PHI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TEN_BP_CHIU_PHI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON_VTPT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUY_CACH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
