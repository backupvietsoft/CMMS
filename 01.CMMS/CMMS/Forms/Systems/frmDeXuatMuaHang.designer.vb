<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeXuatMuaHang
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblTieuDe = New System.Windows.Forms.Label
        Me.lblSoDeXuat = New System.Windows.Forms.Label
        Me.lblPhongYC = New System.Windows.Forms.Label
        Me.lblNgay = New System.Windows.Forms.Label
        Me.dtNgay = New System.Windows.Forms.DateTimePicker
        Me.grpDanhsachvattu = New System.Windows.Forms.GroupBox
        Me.grdDanhsachvattu = New System.Windows.Forms.DataGridView
        Me.chkDuyet = New System.Windows.Forms.CheckBox
        Me.BtnSua = New System.Windows.Forms.Button
        Me.BtnThem = New System.Windows.Forms.Button
        Me.BtnXoa = New System.Windows.Forms.Button
        Me.BtnGhi = New System.Windows.Forms.Button
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnKhongghi = New System.Windows.Forms.Button
        Me.lblGiaoCho = New System.Windows.Forms.Label
        Me.lblNguoiDuyet = New System.Windows.Forms.Label
        Me.lblNgayGiao = New System.Windows.Forms.Label
        Me.txtNgayGiao = New System.Windows.Forms.MaskedTextBox
        Me.BtnChonVatTu = New System.Windows.Forms.Button
        Me.BtnIn = New System.Windows.Forms.Button
        Me.BtnDuyet = New System.Windows.Forms.Button
        Me.txtNguoiDuyet = New Commons.utcTextBox
        Me.txtGiaoCho = New Commons.utcTextBox
        Me.cboPhongYC = New Commons.UtcComboBox
        Me.cbosoDeXuat = New Commons.UtcComboBox
        Me.txtSoDeXuat = New Commons.utcTextBox
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachvattu.SuspendLayout()
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblTieuDe
        '
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieuDe.Location = New System.Drawing.Point(12, 9)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(655, 29)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "ĐỀ XUẤT MUA HÀNG" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSoDeXuat
        '
        Me.lblSoDeXuat.AutoSize = True
        Me.lblSoDeXuat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoDeXuat.Location = New System.Drawing.Point(3, 55)
        Me.lblSoDeXuat.Name = "lblSoDeXuat"
        Me.lblSoDeXuat.Size = New System.Drawing.Size(67, 13)
        Me.lblSoDeXuat.TabIndex = 1
        Me.lblSoDeXuat.Text = "Số đề xuất"
        '
        'lblPhongYC
        '
        Me.lblPhongYC.AutoSize = True
        Me.lblPhongYC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhongYC.Location = New System.Drawing.Point(242, 55)
        Me.lblPhongYC.Name = "lblPhongYC"
        Me.lblPhongYC.Size = New System.Drawing.Size(89, 13)
        Me.lblPhongYC.TabIndex = 2
        Me.lblPhongYC.Text = "Phòng yêu cầu"
        '
        'lblNgay
        '
        Me.lblNgay.AutoSize = True
        Me.lblNgay.Location = New System.Drawing.Point(512, 56)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(32, 13)
        Me.lblNgay.TabIndex = 3
        Me.lblNgay.Text = "Ngày"
        '
        'dtNgay
        '
        Me.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtNgay.Location = New System.Drawing.Point(586, 52)
        Me.dtNgay.Name = "dtNgay"
        Me.dtNgay.Size = New System.Drawing.Size(81, 21)
        Me.dtNgay.TabIndex = 3
        '
        'grpDanhsachvattu
        '
        Me.grpDanhsachvattu.Controls.Add(Me.grdDanhsachvattu)
        Me.grpDanhsachvattu.Controls.Add(Me.chkDuyet)
        Me.grpDanhsachvattu.ForeColor = System.Drawing.Color.Black
        Me.grpDanhsachvattu.Location = New System.Drawing.Point(4, 107)
        Me.grpDanhsachvattu.Name = "grpDanhsachvattu"
        Me.grpDanhsachvattu.Size = New System.Drawing.Size(663, 288)
        Me.grpDanhsachvattu.TabIndex = 7
        Me.grpDanhsachvattu.TabStop = False
        Me.grpDanhsachvattu.Text = "Danh sách phụ tùng"
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
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachvattu.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachvattu.Location = New System.Drawing.Point(4, 44)
        Me.grdDanhsachvattu.Name = "grdDanhsachvattu"
        Me.grdDanhsachvattu.Size = New System.Drawing.Size(655, 240)
        Me.grdDanhsachvattu.TabIndex = 0
        '
        'chkDuyet
        '
        Me.chkDuyet.AutoSize = True
        Me.chkDuyet.Checked = True
        Me.chkDuyet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDuyet.ForeColor = System.Drawing.Color.Maroon
        Me.chkDuyet.Location = New System.Drawing.Point(185, 20)
        Me.chkDuyet.Name = "chkDuyet"
        Me.chkDuyet.Size = New System.Drawing.Size(220, 17)
        Me.chkDuyet.TabIndex = 20
        Me.chkDuyet.Text = "Đề xuất mua hàng chưa duyệt/đã duyệt"
        Me.chkDuyet.UseVisualStyleBackColor = True
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Location = New System.Drawing.Point(353, 401)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(81, 25)
        Me.BtnSua.TabIndex = 11
        Me.BtnSua.Text = "&Sửa"
        Me.BtnSua.UseVisualStyleBackColor = True
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Location = New System.Drawing.Point(272, 401)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 10
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(515, 401)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 12
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Location = New System.Drawing.Point(515, 401)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 14
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(596, 401)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 13
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(596, 401)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 15
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'lblGiaoCho
        '
        Me.lblGiaoCho.AutoSize = True
        Me.lblGiaoCho.Location = New System.Drawing.Point(3, 87)
        Me.lblGiaoCho.Name = "lblGiaoCho"
        Me.lblGiaoCho.Size = New System.Drawing.Size(48, 13)
        Me.lblGiaoCho.TabIndex = 16
        Me.lblGiaoCho.Text = "Giao cho"
        '
        'lblNguoiDuyet
        '
        Me.lblNguoiDuyet.AutoSize = True
        Me.lblNguoiDuyet.Location = New System.Drawing.Point(242, 87)
        Me.lblNguoiDuyet.Name = "lblNguoiDuyet"
        Me.lblNguoiDuyet.Size = New System.Drawing.Size(66, 13)
        Me.lblNguoiDuyet.TabIndex = 17
        Me.lblNguoiDuyet.Text = "Người duyệt"
        '
        'lblNgayGiao
        '
        Me.lblNgayGiao.AutoSize = True
        Me.lblNgayGiao.Location = New System.Drawing.Point(512, 87)
        Me.lblNgayGiao.Name = "lblNgayGiao"
        Me.lblNgayGiao.Size = New System.Drawing.Size(55, 13)
        Me.lblNgayGiao.TabIndex = 18
        Me.lblNgayGiao.Text = "Ngày giao"
        '
        'txtNgayGiao
        '
        Me.txtNgayGiao.BackColor = System.Drawing.Color.White
        Me.txtNgayGiao.Location = New System.Drawing.Point(586, 84)
        Me.txtNgayGiao.Mask = "00/00/0000"
        Me.txtNgayGiao.Name = "txtNgayGiao"
        Me.txtNgayGiao.Size = New System.Drawing.Size(81, 21)
        Me.txtNgayGiao.TabIndex = 6
        Me.txtNgayGiao.ValidatingType = GetType(Date)
        '
        'BtnChonVatTu
        '
        Me.BtnChonVatTu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnChonVatTu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChonVatTu.ForeColor = System.Drawing.Color.Blue
        Me.BtnChonVatTu.Location = New System.Drawing.Point(4, 401)
        Me.BtnChonVatTu.Name = "BtnChonVatTu"
        Me.BtnChonVatTu.Size = New System.Drawing.Size(130, 25)
        Me.BtnChonVatTu.TabIndex = 7
        Me.BtnChonVatTu.Text = "Chọn vật tư"
        Me.BtnChonVatTu.UseVisualStyleBackColor = True
        '
        'BtnIn
        '
        Me.BtnIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnIn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIn.ForeColor = System.Drawing.Color.Blue
        Me.BtnIn.Location = New System.Drawing.Point(434, 401)
        Me.BtnIn.Name = "BtnIn"
        Me.BtnIn.Size = New System.Drawing.Size(81, 25)
        Me.BtnIn.TabIndex = 19
        Me.BtnIn.Text = "&In"
        Me.BtnIn.UseVisualStyleBackColor = True
        '
        'BtnDuyet
        '
        Me.BtnDuyet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDuyet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDuyet.ForeColor = System.Drawing.Color.Maroon
        Me.BtnDuyet.Location = New System.Drawing.Point(4, 401)
        Me.BtnDuyet.Name = "BtnDuyet"
        Me.BtnDuyet.Size = New System.Drawing.Size(130, 25)
        Me.BtnDuyet.TabIndex = 21
        Me.BtnDuyet.Text = "Duyệt"
        Me.BtnDuyet.UseVisualStyleBackColor = True
        '
        'txtNguoiDuyet
        '
        Me.txtNguoiDuyet.BackColor = System.Drawing.Color.White
        Me.txtNguoiDuyet.ErrorProviderControl = Me.ErrorProvider1
        Me.txtNguoiDuyet.FieldName = ""
        Me.txtNguoiDuyet.IsNull = True
        Me.txtNguoiDuyet.Location = New System.Drawing.Point(349, 87)
        Me.txtNguoiDuyet.Name = "txtNguoiDuyet"
        Me.txtNguoiDuyet.Size = New System.Drawing.Size(157, 21)
        Me.txtNguoiDuyet.TabIndex = 5
        Me.txtNguoiDuyet.TextTypeMode = Commons.TypeMode.None
        '
        'txtGiaoCho
        '
        Me.txtGiaoCho.BackColor = System.Drawing.Color.White
        Me.txtGiaoCho.ErrorProviderControl = Me.ErrorProvider1
        Me.txtGiaoCho.FieldName = ""
        Me.txtGiaoCho.IsNull = True
        Me.txtGiaoCho.Location = New System.Drawing.Point(85, 84)
        Me.txtGiaoCho.Name = "txtGiaoCho"
        Me.txtGiaoCho.Size = New System.Drawing.Size(151, 21)
        Me.txtGiaoCho.TabIndex = 4
        Me.txtGiaoCho.TextTypeMode = Commons.TypeMode.None
        '
        'cboPhongYC
        '
        Me.cboPhongYC.AssemblyName = ""
        Me.cboPhongYC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPhongYC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPhongYC.BackColor = System.Drawing.Color.White
        Me.cboPhongYC.ClassName = ""
        Me.cboPhongYC.Display = ""
        Me.cboPhongYC.ErrorProviderControl = Me.ErrorProvider1
        Me.cboPhongYC.FormattingEnabled = True
        Me.cboPhongYC.IsAll = False
        Me.cboPhongYC.IsNew = False
        Me.cboPhongYC.ItemAll = " < ALL > "
        Me.cboPhongYC.ItemNew = "...New"
        Me.cboPhongYC.Location = New System.Drawing.Point(349, 52)
        Me.cboPhongYC.MethodName = ""
        Me.cboPhongYC.Name = "cboPhongYC"
        Me.cboPhongYC.Param = ""
        Me.cboPhongYC.Size = New System.Drawing.Size(157, 21)
        Me.cboPhongYC.StoreName = ""
        Me.cboPhongYC.TabIndex = 2
        Me.cboPhongYC.Table = Nothing
        Me.cboPhongYC.TextReadonly = False
        Me.cboPhongYC.Value = ""
        '
        'cbosoDeXuat
        '
        Me.cbosoDeXuat.AssemblyName = ""
        Me.cbosoDeXuat.BackColor = System.Drawing.Color.White
        Me.cbosoDeXuat.ClassName = ""
        Me.cbosoDeXuat.Display = ""
        Me.cbosoDeXuat.ErrorProviderControl = Me.ErrorProvider1
        Me.cbosoDeXuat.FormattingEnabled = True
        Me.cbosoDeXuat.IsAll = False
        Me.cbosoDeXuat.IsNew = False
        Me.cbosoDeXuat.ItemAll = " < ALL > "
        Me.cbosoDeXuat.ItemNew = "...New"
        Me.cbosoDeXuat.Location = New System.Drawing.Point(85, 52)
        Me.cbosoDeXuat.MethodName = ""
        Me.cbosoDeXuat.Name = "cbosoDeXuat"
        Me.cbosoDeXuat.Param = ""
        Me.cbosoDeXuat.Size = New System.Drawing.Size(151, 21)
        Me.cbosoDeXuat.StoreName = ""
        Me.cbosoDeXuat.TabIndex = 0
        Me.cbosoDeXuat.Table = Nothing
        Me.cbosoDeXuat.TextReadonly = False
        Me.cbosoDeXuat.Value = ""
        '
        'txtSoDeXuat
        '
        Me.txtSoDeXuat.BackColor = System.Drawing.Color.White
        Me.txtSoDeXuat.ErrorProviderControl = Me.ErrorProvider1
        Me.txtSoDeXuat.FieldName = ""
        Me.txtSoDeXuat.IsNull = False
        Me.txtSoDeXuat.Location = New System.Drawing.Point(85, 52)
        Me.txtSoDeXuat.Name = "txtSoDeXuat"
        Me.txtSoDeXuat.Size = New System.Drawing.Size(151, 21)
        Me.txtSoDeXuat.TabIndex = 0
        Me.txtSoDeXuat.TextTypeMode = Commons.TypeMode.None
        '
        'frmDeXuatMuaHang
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 427)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.BtnIn)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnDuyet)
        Me.Controls.Add(Me.BtnChonVatTu)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.txtNgayGiao)
        Me.Controls.Add(Me.txtNguoiDuyet)
        Me.Controls.Add(Me.txtGiaoCho)
        Me.Controls.Add(Me.lblNgayGiao)
        Me.Controls.Add(Me.lblNguoiDuyet)
        Me.Controls.Add(Me.lblGiaoCho)
        Me.Controls.Add(Me.grpDanhsachvattu)
        Me.Controls.Add(Me.dtNgay)
        Me.Controls.Add(Me.cboPhongYC)
        Me.Controls.Add(Me.lblNgay)
        Me.Controls.Add(Me.lblPhongYC)
        Me.Controls.Add(Me.lblSoDeXuat)
        Me.Controls.Add(Me.lblTieuDe)
        Me.Controls.Add(Me.cbosoDeXuat)
        Me.Controls.Add(Me.txtSoDeXuat)
        Me.Controls.Add(Me.BtnGhi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeXuatMuaHang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDeXuatMuaHang"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachvattu.ResumeLayout(False)
        Me.grpDanhsachvattu.PerformLayout()
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents dtNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSoDeXuat As Commons.utcTextBox
    Friend WithEvents cboPhongYC As Commons.UtcComboBox
    Friend WithEvents lblNgay As System.Windows.Forms.Label
    Friend WithEvents lblPhongYC As System.Windows.Forms.Label
    Friend WithEvents lblSoDeXuat As System.Windows.Forms.Label
    Friend WithEvents grpDanhsachvattu As System.Windows.Forms.GroupBox
    Friend WithEvents lblGiaoCho As System.Windows.Forms.Label
    Friend WithEvents BtnSua As System.Windows.Forms.Button
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents txtNgayGiao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNguoiDuyet As Commons.utcTextBox
    Friend WithEvents txtGiaoCho As Commons.utcTextBox
    Friend WithEvents lblNgayGiao As System.Windows.Forms.Label
    Friend WithEvents lblNguoiDuyet As System.Windows.Forms.Label
    Friend WithEvents BtnChonVatTu As System.Windows.Forms.Button
    Friend WithEvents grdDanhsachvattu As System.Windows.Forms.DataGridView
    Friend WithEvents cbosoDeXuat As Commons.UtcComboBox
    Friend WithEvents BtnIn As System.Windows.Forms.Button
    Friend WithEvents BtnDuyet As System.Windows.Forms.Button
    Friend WithEvents chkDuyet As System.Windows.Forms.CheckBox
End Class
