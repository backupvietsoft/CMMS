<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonVatTuTrongKho
    Inherits DevExpress.XtraEditors.XtraForm
    'Inherits DevExpress.XtraEditors.XtraForm

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblTieuDe = New System.Windows.Forms.Label
        Me.lblLanChon = New System.Windows.Forms.Label
        Me.lblThoiGianChon = New System.Windows.Forms.Label
        Me.lblUsername = New System.Windows.Forms.Label
        Me.dtThoigianchon = New System.Windows.Forms.DateTimePicker
        Me.grpDieukienloc = New System.Windows.Forms.GroupBox
        Me.txtGiaTri = New Commons.utcTextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboTimvattu = New Commons.UtcComboBox
        Me.lblTimvattu = New System.Windows.Forms.Label
        Me.cboKho = New Commons.UtcComboBox
        Me.lblKho = New System.Windows.Forms.Label
        Me.grpDanhsachvattuchon = New System.Windows.Forms.GroupBox
        Me.grdDanhsachvattu = New Commons.QLGrid
        Me.BtnThem = New System.Windows.Forms.Button
        Me.BtnSua = New System.Windows.Forms.Button
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnXoa = New System.Windows.Forms.Button
        Me.BtnGhi = New System.Windows.Forms.Button
        Me.BtnKhongghi = New System.Windows.Forms.Button
        Me.BtnIn = New System.Windows.Forms.Button
        Me.BtnXoaAll = New System.Windows.Forms.Button
        Me.BtnXoa1Dong = New System.Windows.Forms.Button
        Me.BtnTrove = New System.Windows.Forms.Button
        Me.llblChonAll = New System.Windows.Forms.LinkLabel
        Me.llblBotatca = New System.Windows.Forms.LinkLabel
        Me.txtUsername = New Commons.utcTextBox
        Me.cboLanChon = New Commons.UtcComboBox
        Me.grpDieukienloc.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachvattuchon.SuspendLayout()
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieuDe
        '
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieuDe.Location = New System.Drawing.Point(180, 3)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(638, 35)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "CHỌN VẬT TƯ TRONG KHO"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLanChon
        '
        Me.lblLanChon.AutoSize = True
        Me.lblLanChon.Location = New System.Drawing.Point(99, 53)
        Me.lblLanChon.Name = "lblLanChon"
        Me.lblLanChon.Size = New System.Drawing.Size(50, 13)
        Me.lblLanChon.TabIndex = 1
        Me.lblLanChon.Text = "Lần chọn"
        '
        'lblThoiGianChon
        '
        Me.lblThoiGianChon.AutoSize = True
        Me.lblThoiGianChon.Location = New System.Drawing.Point(323, 50)
        Me.lblThoiGianChon.Name = "lblThoiGianChon"
        Me.lblThoiGianChon.Size = New System.Drawing.Size(76, 13)
        Me.lblThoiGianChon.TabIndex = 2
        Me.lblThoiGianChon.Text = "Thời gian chọn"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(573, 53)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblUsername.TabIndex = 3
        Me.lblUsername.Text = "Username"
        '
        'dtThoigianchon
        '
        Me.dtThoigianchon.CustomFormat = ""
        Me.dtThoigianchon.Enabled = False
        Me.dtThoigianchon.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtThoigianchon.Location = New System.Drawing.Point(424, 50)
        Me.dtThoigianchon.Name = "dtThoigianchon"
        Me.dtThoigianchon.Size = New System.Drawing.Size(127, 21)
        Me.dtThoigianchon.TabIndex = 5
        '
        'grpDieukienloc
        '
        Me.grpDieukienloc.Controls.Add(Me.txtGiaTri)
        Me.grpDieukienloc.Controls.Add(Me.cboTimvattu)
        Me.grpDieukienloc.Controls.Add(Me.lblTimvattu)
        Me.grpDieukienloc.Controls.Add(Me.cboKho)
        Me.grpDieukienloc.Controls.Add(Me.lblKho)
        Me.grpDieukienloc.ForeColor = System.Drawing.Color.Maroon
        Me.grpDieukienloc.Location = New System.Drawing.Point(29, 73)
        Me.grpDieukienloc.Name = "grpDieukienloc"
        Me.grpDieukienloc.Size = New System.Drawing.Size(798, 52)
        Me.grpDieukienloc.TabIndex = 7
        Me.grpDieukienloc.TabStop = False
        Me.grpDieukienloc.Text = "Diều kiện lọc"
        '
        'txtGiaTri
        '
        Me.txtGiaTri.BackColor = System.Drawing.Color.White
        Me.txtGiaTri.ErrorProviderControl = Me.ErrorProvider1
        Me.txtGiaTri.FieldName = ""
        Me.txtGiaTri.IsNull = True
        Me.txtGiaTri.Location = New System.Drawing.Point(591, 19)
        Me.txtGiaTri.Name = "txtGiaTri"
        Me.txtGiaTri.Size = New System.Drawing.Size(183, 21)
        Me.txtGiaTri.TabIndex = 4
        Me.txtGiaTri.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cboTimvattu
        '
        Me.cboTimvattu.AssemblyName = ""
        Me.cboTimvattu.BackColor = System.Drawing.Color.White
        Me.cboTimvattu.ClassName = ""
        Me.cboTimvattu.Display = ""
        Me.cboTimvattu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimvattu.ErrorProviderControl = Me.ErrorProvider1
        Me.cboTimvattu.ForeColor = System.Drawing.Color.Black
        Me.cboTimvattu.FormattingEnabled = True
        Me.cboTimvattu.IsAll = False
        Me.cboTimvattu.IsNew = False
        Me.cboTimvattu.ItemAll = " < ALL > "
        Me.cboTimvattu.ItemNew = "...New"
        Me.cboTimvattu.Items.AddRange(New Object() {"Tìm theo mã vật tư", "Tìm theo tên vật tư"})
        Me.cboTimvattu.Location = New System.Drawing.Point(436, 19)
        Me.cboTimvattu.MethodName = ""
        Me.cboTimvattu.Name = "cboTimvattu"
        Me.cboTimvattu.Param = ""
        Me.cboTimvattu.Size = New System.Drawing.Size(143, 21)
        Me.cboTimvattu.StoreName = ""
        Me.cboTimvattu.TabIndex = 3
        Me.cboTimvattu.Table = Nothing
        Me.cboTimvattu.TextReadonly = False
        Me.cboTimvattu.Value = ""
        '
        'lblTimvattu
        '
        Me.lblTimvattu.AutoSize = True
        Me.lblTimvattu.ForeColor = System.Drawing.Color.Black
        Me.lblTimvattu.Location = New System.Drawing.Point(335, 23)
        Me.lblTimvattu.Name = "lblTimvattu"
        Me.lblTimvattu.Size = New System.Drawing.Size(81, 13)
        Me.lblTimvattu.TabIndex = 2
        Me.lblTimvattu.Text = "Tìm vật tư theo"
        '
        'cboKho
        '
        Me.cboKho.AssemblyName = ""
        Me.cboKho.BackColor = System.Drawing.Color.White
        Me.cboKho.ClassName = ""
        Me.cboKho.Display = ""
        Me.cboKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKho.ErrorProviderControl = Me.ErrorProvider1
        Me.cboKho.ForeColor = System.Drawing.Color.Black
        Me.cboKho.FormattingEnabled = True
        Me.cboKho.IsAll = True
        Me.cboKho.IsNew = False
        Me.cboKho.ItemAll = " < ALL > "
        Me.cboKho.ItemNew = "...New"
        Me.cboKho.Location = New System.Drawing.Point(88, 19)
        Me.cboKho.MethodName = ""
        Me.cboKho.Name = "cboKho"
        Me.cboKho.Param = ""
        Me.cboKho.Size = New System.Drawing.Size(163, 21)
        Me.cboKho.StoreName = ""
        Me.cboKho.TabIndex = 1
        Me.cboKho.Table = Nothing
        Me.cboKho.TextReadonly = False
        Me.cboKho.Value = ""
        '
        'lblKho
        '
        Me.lblKho.AutoSize = True
        Me.lblKho.ForeColor = System.Drawing.Color.Black
        Me.lblKho.Location = New System.Drawing.Point(23, 23)
        Me.lblKho.Name = "lblKho"
        Me.lblKho.Size = New System.Drawing.Size(25, 13)
        Me.lblKho.TabIndex = 0
        Me.lblKho.Text = "Kho"
        '
        'grpDanhsachvattuchon
        '
        Me.grpDanhsachvattuchon.Controls.Add(Me.grdDanhsachvattu)
        Me.grpDanhsachvattuchon.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachvattuchon.Location = New System.Drawing.Point(10, 131)
        Me.grpDanhsachvattuchon.Name = "grpDanhsachvattuchon"
        Me.grpDanhsachvattuchon.Size = New System.Drawing.Size(838, 457)
        Me.grpDanhsachvattuchon.TabIndex = 8
        Me.grpDanhsachvattuchon.TabStop = False
        Me.grpDanhsachvattuchon.Text = "Danh sách vật tư chọn in pick list"
        '
        'grdDanhsachvattu
        '
        Me.grdDanhsachvattu.AllowUserToAddRows = False
        Me.grdDanhsachvattu.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachvattu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachvattu.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachvattu.Location = New System.Drawing.Point(9, 88)
        Me.grdDanhsachvattu.MultiSelect = False
        Me.grdDanhsachvattu.Name = "grdDanhsachvattu"
        Me.grdDanhsachvattu.Size = New System.Drawing.Size(830, 435)
        Me.grdDanhsachvattu.TabIndex = 1
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Location = New System.Drawing.Point(445, 593)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 14
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnSua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Location = New System.Drawing.Point(526, 593)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(81, 25)
        Me.BtnSua.TabIndex = 15
        Me.BtnSua.Text = "&Sửa"
        Me.BtnSua.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(769, 593)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 17
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(607, 593)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 16
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Location = New System.Drawing.Point(687, 593)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 18
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnKhongghi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(769, 593)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 19
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'BtnIn
        '
        Me.BtnIn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnIn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIn.ForeColor = System.Drawing.Color.Blue
        Me.BtnIn.Location = New System.Drawing.Point(688, 593)
        Me.BtnIn.Name = "BtnIn"
        Me.BtnIn.Size = New System.Drawing.Size(81, 25)
        Me.BtnIn.TabIndex = 20
        Me.BtnIn.Text = "In"
        Me.BtnIn.UseVisualStyleBackColor = True
        '
        'BtnXoaAll
        '
        Me.BtnXoaAll.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnXoaAll.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoaAll.ForeColor = System.Drawing.Color.Red
        Me.BtnXoaAll.Location = New System.Drawing.Point(605, 593)
        Me.BtnXoaAll.Name = "BtnXoaAll"
        Me.BtnXoaAll.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoaAll.TabIndex = 21
        Me.BtnXoaAll.Text = "Xóa tât cả"
        Me.BtnXoaAll.UseVisualStyleBackColor = True
        '
        'BtnXoa1Dong
        '
        Me.BtnXoa1Dong.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnXoa1Dong.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa1Dong.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa1Dong.Location = New System.Drawing.Point(687, 593)
        Me.BtnXoa1Dong.Name = "BtnXoa1Dong"
        Me.BtnXoa1Dong.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa1Dong.TabIndex = 22
        Me.BtnXoa1Dong.Text = "Xóa dòng"
        Me.BtnXoa1Dong.UseVisualStyleBackColor = True
        '
        'BtnTrove
        '
        Me.BtnTrove.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnTrove.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTrove.Location = New System.Drawing.Point(768, 593)
        Me.BtnTrove.Name = "BtnTrove"
        Me.BtnTrove.Size = New System.Drawing.Size(81, 25)
        Me.BtnTrove.TabIndex = 23
        Me.BtnTrove.Text = "Trở về"
        Me.BtnTrove.UseVisualStyleBackColor = True
        '
        'llblChonAll
        '
        Me.llblChonAll.AutoSize = True
        Me.llblChonAll.Location = New System.Drawing.Point(10, 599)
        Me.llblChonAll.Name = "llblChonAll"
        Me.llblChonAll.Size = New System.Drawing.Size(63, 13)
        Me.llblChonAll.TabIndex = 24
        Me.llblChonAll.TabStop = True
        Me.llblChonAll.Text = "Chọn tất cả"
        '
        'llblBotatca
        '
        Me.llblBotatca.AutoSize = True
        Me.llblBotatca.Location = New System.Drawing.Point(86, 599)
        Me.llblBotatca.Name = "llblBotatca"
        Me.llblBotatca.Size = New System.Drawing.Size(50, 13)
        Me.llblBotatca.TabIndex = 25
        Me.llblBotatca.TabStop = True
        Me.llblBotatca.Text = "Bỏ tất cả"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.White
        Me.txtUsername.Enabled = False
        Me.txtUsername.ErrorProviderControl = Me.ErrorProvider1
        Me.txtUsername.FieldName = ""
        Me.txtUsername.IsNull = True
        Me.txtUsername.Location = New System.Drawing.Point(663, 50)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(94, 21)
        Me.txtUsername.TabIndex = 6
        Me.txtUsername.TextTypeMode = Commons.TypeMode.None
        '
        'cboLanChon
        '
        Me.cboLanChon.AssemblyName = ""
        Me.cboLanChon.BackColor = System.Drawing.Color.White
        Me.cboLanChon.ClassName = ""
        Me.cboLanChon.Display = ""
        Me.cboLanChon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLanChon.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLanChon.FormattingEnabled = True
        Me.cboLanChon.IsAll = False
        Me.cboLanChon.IsNew = False
        Me.cboLanChon.ItemAll = " < ALL > "
        Me.cboLanChon.ItemNew = "...New"
        Me.cboLanChon.Location = New System.Drawing.Point(175, 47)
        Me.cboLanChon.MethodName = ""
        Me.cboLanChon.Name = "cboLanChon"
        Me.cboLanChon.Param = ""
        Me.cboLanChon.Size = New System.Drawing.Size(132, 21)
        Me.cboLanChon.StoreName = ""
        Me.cboLanChon.TabIndex = 4
        Me.cboLanChon.Table = Nothing
        Me.cboLanChon.TextReadonly = False
        Me.cboLanChon.Value = ""
        '
        'frmChonVatTuTrongKho
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 624)
        Me.Controls.Add(Me.llblBotatca)
        Me.Controls.Add(Me.llblChonAll)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.grpDanhsachvattuchon)
        Me.Controls.Add(Me.grpDieukienloc)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.dtThoigianchon)
        Me.Controls.Add(Me.cboLanChon)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblThoiGianChon)
        Me.Controls.Add(Me.lblLanChon)
        Me.Controls.Add(Me.lblTieuDe)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.BtnTrove)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnIn)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.Controls.Add(Me.BtnXoa1Dong)
        Me.Controls.Add(Me.BtnXoaAll)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChonVatTuTrongKho"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmChonVatTuTrongKho"
        Me.grpDieukienloc.ResumeLayout(False)
        Me.grpDieukienloc.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachvattuchon.ResumeLayout(False)
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents lblLanChon As System.Windows.Forms.Label
    Friend WithEvents lblThoiGianChon As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents cboLanChon As Commons.UtcComboBox
    Friend WithEvents dtThoigianchon As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtUsername As Commons.utcTextBox
    Friend WithEvents grpDieukienloc As System.Windows.Forms.GroupBox
    Friend WithEvents txtGiaTri As Commons.utcTextBox
    Friend WithEvents cboTimvattu As Commons.UtcComboBox
    Friend WithEvents lblTimvattu As System.Windows.Forms.Label
    Friend WithEvents cboKho As Commons.UtcComboBox
    Friend WithEvents lblKho As System.Windows.Forms.Label
    Friend WithEvents grpDanhsachvattuchon As System.Windows.Forms.GroupBox
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnSua As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents BtnIn As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnXoa1Dong As System.Windows.Forms.Button
    Friend WithEvents BtnXoaAll As System.Windows.Forms.Button
    Friend WithEvents BtnTrove As System.Windows.Forms.Button
    Friend WithEvents llblBotatca As System.Windows.Forms.LinkLabel
    Friend WithEvents llblChonAll As System.Windows.Forms.LinkLabel
    Friend WithEvents grdDanhsachvattu As Commons.QLGrid
End Class
