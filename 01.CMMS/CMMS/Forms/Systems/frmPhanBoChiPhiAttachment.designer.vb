<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhanBoChiPhiAttachment
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblTieuDe = New System.Windows.Forms.Label
        Me.grpDanhsachAttachment = New System.Windows.Forms.GroupBox
        Me.cboLoaiTB = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblLoaimay = New System.Windows.Forms.Label
        Me.grdDanhsachAttachment = New System.Windows.Forms.DataGridView
        Me.grpChiphibaotri = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdChuaphanbohet = New System.Windows.Forms.RadioButton
        Me.rdTatca = New System.Windows.Forms.RadioButton
        Me.dtDenngay = New System.Windows.Forms.DateTimePicker
        Me.dtpTungay = New System.Windows.Forms.DateTimePicker
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.lblTuNgay = New System.Windows.Forms.Label
        Me.grdChiphibaotri = New System.Windows.Forms.DataGridView
        Me.BtnPhanbodeu = New System.Windows.Forms.Button
        Me.BtnThem = New System.Windows.Forms.Button
        Me.BtnXoa = New System.Windows.Forms.Button
        Me.BtnGhi = New System.Windows.Forms.Button
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnKhongghi = New System.Windows.Forms.Button
        Me.grdMayphanbo = New System.Windows.Forms.GroupBox
        Me.dtDenngay1 = New System.Windows.Forms.DateTimePicker
        Me.dtTungay1 = New System.Windows.Forms.DateTimePicker
        Me.lblDenngay1 = New System.Windows.Forms.Label
        Me.lblTungay1 = New System.Windows.Forms.Label
        Me.grdPhanbochiphi = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grpDanhsachAttachment.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDanhsachAttachment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpChiphibaotri.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdChiphibaotri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grdMayphanbo.SuspendLayout()
        CType(Me.grdPhanbochiphi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieuDe
        '
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.Color.Navy
        Me.lblTieuDe.Location = New System.Drawing.Point(12, 9)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(861, 27)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "PHÂN BỔ CHI PHÍ ATTACHMENT"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpDanhsachAttachment
        '
        Me.grpDanhsachAttachment.Controls.Add(Me.cboLoaiTB)
        Me.grpDanhsachAttachment.Controls.Add(Me.lblLoaimay)
        Me.grpDanhsachAttachment.Controls.Add(Me.grdDanhsachAttachment)
        Me.grpDanhsachAttachment.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachAttachment.Location = New System.Drawing.Point(2, 52)
        Me.grpDanhsachAttachment.Name = "grpDanhsachAttachment"
        Me.grpDanhsachAttachment.Size = New System.Drawing.Size(241, 498)
        Me.grpDanhsachAttachment.TabIndex = 1
        Me.grpDanhsachAttachment.TabStop = False
        Me.grpDanhsachAttachment.Text = "Danh sách Attachment"
        '
        'cboLoaiTB
        '
        Me.cboLoaiTB.AssemblyName = ""
        Me.cboLoaiTB.BackColor = System.Drawing.Color.White
        Me.cboLoaiTB.ClassName = ""
        Me.cboLoaiTB.Display = ""
        Me.cboLoaiTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaiTB.DropDownWidth = 250
        Me.cboLoaiTB.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiTB.FormattingEnabled = True
        Me.cboLoaiTB.IsAll = True
        Me.cboLoaiTB.IsNew = False
        Me.cboLoaiTB.ItemAll = " < ALL > "
        Me.cboLoaiTB.ItemNew = "...New"
        Me.cboLoaiTB.Location = New System.Drawing.Point(95, 22)
        Me.cboLoaiTB.MethodName = ""
        Me.cboLoaiTB.Name = "cboLoaiTB"
        Me.cboLoaiTB.Param = ""
        Me.cboLoaiTB.Size = New System.Drawing.Size(140, 21)
        Me.cboLoaiTB.StoreName = ""
        Me.cboLoaiTB.TabIndex = 7
        Me.cboLoaiTB.Table = Nothing
        Me.cboLoaiTB.TextReadonly = False
        Me.cboLoaiTB.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblLoaimay
        '
        Me.lblLoaimay.AutoSize = True
        Me.lblLoaimay.ForeColor = System.Drawing.Color.Black
        Me.lblLoaimay.Location = New System.Drawing.Point(7, 26)
        Me.lblLoaimay.Name = "lblLoaimay"
        Me.lblLoaimay.Size = New System.Drawing.Size(82, 13)
        Me.lblLoaimay.TabIndex = 6
        Me.lblLoaimay.Text = "Equipment type"
        '
        'grdDanhsachAttachment
        '
        Me.grdDanhsachAttachment.AllowUserToAddRows = False
        Me.grdDanhsachAttachment.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhsachAttachment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdDanhsachAttachment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachAttachment.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdDanhsachAttachment.Location = New System.Drawing.Point(6, 63)
        Me.grdDanhsachAttachment.Name = "grdDanhsachAttachment"
        Me.grdDanhsachAttachment.ReadOnly = True
        Me.grdDanhsachAttachment.RowHeadersWidth = 25
        Me.grdDanhsachAttachment.Size = New System.Drawing.Size(229, 426)
        Me.grdDanhsachAttachment.TabIndex = 0
        '
        'grpChiphibaotri
        '
        Me.grpChiphibaotri.Controls.Add(Me.GroupBox2)
        Me.grpChiphibaotri.Controls.Add(Me.dtDenngay)
        Me.grpChiphibaotri.Controls.Add(Me.dtpTungay)
        Me.grpChiphibaotri.Controls.Add(Me.lblDenngay)
        Me.grpChiphibaotri.Controls.Add(Me.lblTuNgay)
        Me.grpChiphibaotri.Controls.Add(Me.grdChiphibaotri)
        Me.grpChiphibaotri.ForeColor = System.Drawing.Color.Maroon
        Me.grpChiphibaotri.Location = New System.Drawing.Point(258, 52)
        Me.grpChiphibaotri.Name = "grpChiphibaotri"
        Me.grpChiphibaotri.Size = New System.Drawing.Size(620, 259)
        Me.grpChiphibaotri.TabIndex = 2
        Me.grpChiphibaotri.TabStop = False
        Me.grpChiphibaotri.Text = "Chi phí bảo trì"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdChuaphanbohet)
        Me.GroupBox2.Controls.Add(Me.rdTatca)
        Me.GroupBox2.Location = New System.Drawing.Point(343, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 43)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'rdChuaphanbohet
        '
        Me.rdChuaphanbohet.AutoSize = True
        Me.rdChuaphanbohet.ForeColor = System.Drawing.Color.Black
        Me.rdChuaphanbohet.Location = New System.Drawing.Point(90, 16)
        Me.rdChuaphanbohet.Name = "rdChuaphanbohet"
        Me.rdChuaphanbohet.Size = New System.Drawing.Size(112, 17)
        Me.rdChuaphanbohet.TabIndex = 1
        Me.rdChuaphanbohet.Text = "Chưa phân bổ hết"
        Me.rdChuaphanbohet.UseVisualStyleBackColor = True
        '
        'rdTatca
        '
        Me.rdTatca.AutoSize = True
        Me.rdTatca.Checked = True
        Me.rdTatca.ForeColor = System.Drawing.Color.Black
        Me.rdTatca.Location = New System.Drawing.Point(9, 16)
        Me.rdTatca.Name = "rdTatca"
        Me.rdTatca.Size = New System.Drawing.Size(55, 17)
        Me.rdTatca.TabIndex = 0
        Me.rdTatca.TabStop = True
        Me.rdTatca.Text = "Tất cả"
        Me.rdTatca.UseVisualStyleBackColor = True
        '
        'dtDenngay
        '
        Me.dtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDenngay.Location = New System.Drawing.Point(255, 26)
        Me.dtDenngay.Name = "dtDenngay"
        Me.dtDenngay.Size = New System.Drawing.Size(82, 21)
        Me.dtDenngay.TabIndex = 4
        '
        'dtpTungay
        '
        Me.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTungay.Location = New System.Drawing.Point(86, 26)
        Me.dtpTungay.Name = "dtpTungay"
        Me.dtpTungay.Size = New System.Drawing.Size(82, 21)
        Me.dtpTungay.TabIndex = 3
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.ForeColor = System.Drawing.Color.Black
        Me.lblDenngay.Location = New System.Drawing.Point(174, 30)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(47, 13)
        Me.lblDenngay.TabIndex = 2
        Me.lblDenngay.Text = "Từ ngày"
        '
        'lblTuNgay
        '
        Me.lblTuNgay.AutoSize = True
        Me.lblTuNgay.ForeColor = System.Drawing.Color.Black
        Me.lblTuNgay.Location = New System.Drawing.Point(10, 30)
        Me.lblTuNgay.Name = "lblTuNgay"
        Me.lblTuNgay.Size = New System.Drawing.Size(47, 13)
        Me.lblTuNgay.TabIndex = 1
        Me.lblTuNgay.Text = "Từ ngày"
        '
        'grdChiphibaotri
        '
        Me.grdChiphibaotri.AllowUserToAddRows = False
        Me.grdChiphibaotri.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdChiphibaotri.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdChiphibaotri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdChiphibaotri.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdChiphibaotri.Location = New System.Drawing.Point(6, 63)
        Me.grdChiphibaotri.Name = "grdChiphibaotri"
        Me.grdChiphibaotri.ReadOnly = True
        Me.grdChiphibaotri.RowHeadersWidth = 25
        Me.grdChiphibaotri.Size = New System.Drawing.Size(607, 190)
        Me.grdChiphibaotri.TabIndex = 0
        '
        'BtnPhanbodeu
        '
        Me.BtnPhanbodeu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPhanbodeu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPhanbodeu.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnPhanbodeu.Location = New System.Drawing.Point(611, 556)
        Me.BtnPhanbodeu.Name = "BtnPhanbodeu"
        Me.BtnPhanbodeu.Size = New System.Drawing.Size(104, 25)
        Me.BtnPhanbodeu.TabIndex = 37
        Me.BtnPhanbodeu.Text = "Phân bố đều"
        Me.BtnPhanbodeu.UseVisualStyleBackColor = True
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Location = New System.Drawing.Point(560, 556)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 36
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(641, 556)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(156, 25)
        Me.BtnXoa.TabIndex = 38
        Me.BtnXoa.Text = "&Xóa máy phân bổ"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Location = New System.Drawing.Point(716, 556)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 40
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(797, 556)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 39
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(797, 556)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 41
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'grdMayphanbo
        '
        Me.grdMayphanbo.Controls.Add(Me.dtDenngay1)
        Me.grdMayphanbo.Controls.Add(Me.dtTungay1)
        Me.grdMayphanbo.Controls.Add(Me.lblDenngay1)
        Me.grdMayphanbo.Controls.Add(Me.lblTungay1)
        Me.grdMayphanbo.Controls.Add(Me.grdPhanbochiphi)
        Me.grdMayphanbo.ForeColor = System.Drawing.Color.Maroon
        Me.grdMayphanbo.Location = New System.Drawing.Point(259, 317)
        Me.grdMayphanbo.Name = "grdMayphanbo"
        Me.grdMayphanbo.Size = New System.Drawing.Size(619, 233)
        Me.grdMayphanbo.TabIndex = 42
        Me.grdMayphanbo.TabStop = False
        Me.grdMayphanbo.Text = "Máy phân bổ"
        '
        'dtDenngay1
        '
        Me.dtDenngay1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDenngay1.Location = New System.Drawing.Point(382, 17)
        Me.dtDenngay1.Name = "dtDenngay1"
        Me.dtDenngay1.Size = New System.Drawing.Size(82, 21)
        Me.dtDenngay1.TabIndex = 9
        '
        'dtTungay1
        '
        Me.dtTungay1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTungay1.Location = New System.Drawing.Point(223, 17)
        Me.dtTungay1.Name = "dtTungay1"
        Me.dtTungay1.Size = New System.Drawing.Size(82, 21)
        Me.dtTungay1.TabIndex = 8
        '
        'lblDenngay1
        '
        Me.lblDenngay1.AutoSize = True
        Me.lblDenngay1.ForeColor = System.Drawing.Color.Black
        Me.lblDenngay1.Location = New System.Drawing.Point(311, 21)
        Me.lblDenngay1.Name = "lblDenngay1"
        Me.lblDenngay1.Size = New System.Drawing.Size(47, 13)
        Me.lblDenngay1.TabIndex = 7
        Me.lblDenngay1.Text = "Từ ngày"
        '
        'lblTungay1
        '
        Me.lblTungay1.AutoSize = True
        Me.lblTungay1.ForeColor = System.Drawing.Color.Black
        Me.lblTungay1.Location = New System.Drawing.Point(157, 21)
        Me.lblTungay1.Name = "lblTungay1"
        Me.lblTungay1.Size = New System.Drawing.Size(47, 13)
        Me.lblTungay1.TabIndex = 6
        Me.lblTungay1.Text = "Từ ngày"
        '
        'grdPhanbochiphi
        '
        Me.grdPhanbochiphi.AllowUserToAddRows = False
        Me.grdPhanbochiphi.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPhanbochiphi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdPhanbochiphi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdPhanbochiphi.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdPhanbochiphi.Location = New System.Drawing.Point(6, 49)
        Me.grdPhanbochiphi.Name = "grdPhanbochiphi"
        Me.grdPhanbochiphi.RowHeadersWidth = 25
        Me.grdPhanbochiphi.Size = New System.Drawing.Size(606, 175)
        Me.grdPhanbochiphi.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS_PHIEU_BAO_TRI"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "MS_MAY"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "NGAY_NGHIEM_THU"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "CHI_PHI_BAO_TRI"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "CHI_PHI_DA_PHAN_BO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "CHI_PHI_CON_LAI"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "MS_MAY"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "NHOM_MAY"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "LOAI_MAY"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "NGAY_ATT"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "SO_TIEN"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'frmPhanBoChiPhiAttachment
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 584)
        Me.Controls.Add(Me.grdMayphanbo)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.grpChiphibaotri)
        Me.Controls.Add(Me.grpDanhsachAttachment)
        Me.Controls.Add(Me.lblTieuDe)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnPhanbodeu)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmPhanBoChiPhiAttachment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmPhanBoChiPhiAttachment"
        Me.grpDanhsachAttachment.ResumeLayout(False)
        Me.grpDanhsachAttachment.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDanhsachAttachment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpChiphibaotri.ResumeLayout(False)
        Me.grpChiphibaotri.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdChiphibaotri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grdMayphanbo.ResumeLayout(False)
        Me.grdMayphanbo.PerformLayout()
        CType(Me.grdPhanbochiphi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents grpDanhsachAttachment As System.Windows.Forms.GroupBox
    Friend WithEvents grpChiphibaotri As System.Windows.Forms.GroupBox
    Friend WithEvents BtnPhanbodeu As System.Windows.Forms.Button
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents grdMayphanbo As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachAttachment As System.Windows.Forms.DataGridView
    Friend WithEvents dtDenngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents lblTuNgay As System.Windows.Forms.Label
    Friend WithEvents grdChiphibaotri As System.Windows.Forms.DataGridView
    Friend WithEvents grdPhanbochiphi As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdChuaphanbohet As System.Windows.Forms.RadioButton
    Friend WithEvents rdTatca As System.Windows.Forms.RadioButton
    Friend WithEvents dtDenngay1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtTungay1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDenngay1 As System.Windows.Forms.Label
    Friend WithEvents lblTungay1 As System.Windows.Forms.Label
    Friend WithEvents cboLoaiTB As Commons.UtcComboBox
    Friend WithEvents lblLoaimay As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
