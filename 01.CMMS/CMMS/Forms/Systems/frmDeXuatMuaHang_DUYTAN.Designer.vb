<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeXuatMuaHang_DUYTAN
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
        Me.lblTieuDe = New System.Windows.Forms.Label
        Me.lblSoDeXuat = New System.Windows.Forms.Label
        Me.lblBoPhanDeXuat = New System.Windows.Forms.Label
        Me.lblNgay = New System.Windows.Forms.Label
        Me.lblGiaoCho = New System.Windows.Forms.Label
        Me.lblNguoiDuyet = New System.Windows.Forms.Label
        Me.lblNgayGiao = New System.Windows.Forms.Label
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.txtNguoiDuyet = New System.Windows.Forms.TextBox
        Me.grpPhieuDeXuat = New System.Windows.Forms.GroupBox
        Me.grdDanhsachvattu = New Commons.QLGrid
        Me.chkDuyet = New System.Windows.Forms.CheckBox
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnIn = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnKhongGhi = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnDuyet = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnChonVTPT = New System.Windows.Forms.Button
        Me.txtNgayGiao = New System.Windows.Forms.MaskedTextBox
        Me.txtGiaoCho = New Commons.utcTextBox
        Me.cboBoPhanDeXuat = New Commons.UtcComboBox
        Me.cboSoDeXuat = New Commons.UtcComboBox
        Me.txtSoDeXuat = New Commons.utcTextBox
        Me.grpPhieuDeXuat.SuspendLayout()
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieuDe
        '
        Me.lblTieuDe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieuDe.Location = New System.Drawing.Point(12, 9)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(800, 28)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "ĐỀ XUẤT ĐẶT MUA HÀNG"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSoDeXuat
        '
        Me.lblSoDeXuat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoDeXuat.Location = New System.Drawing.Point(14, 77)
        Me.lblSoDeXuat.Name = "lblSoDeXuat"
        Me.lblSoDeXuat.Size = New System.Drawing.Size(89, 21)
        Me.lblSoDeXuat.TabIndex = 0
        Me.lblSoDeXuat.Text = "Số đề xuất:"
        Me.lblSoDeXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBoPhanDeXuat
        '
        Me.lblBoPhanDeXuat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoPhanDeXuat.Location = New System.Drawing.Point(248, 77)
        Me.lblBoPhanDeXuat.Name = "lblBoPhanDeXuat"
        Me.lblBoPhanDeXuat.Size = New System.Drawing.Size(145, 21)
        Me.lblBoPhanDeXuat.TabIndex = 0
        Me.lblBoPhanDeXuat.Text = "Bộ phận đề xuất:"
        Me.lblBoPhanDeXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNgay
        '
        Me.lblNgay.Location = New System.Drawing.Point(552, 77)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(126, 21)
        Me.lblNgay.TabIndex = 0
        Me.lblNgay.Text = "Ngày đề xuất:"
        Me.lblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGiaoCho
        '
        Me.lblGiaoCho.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGiaoCho.Location = New System.Drawing.Point(12, 108)
        Me.lblGiaoCho.Name = "lblGiaoCho"
        Me.lblGiaoCho.Size = New System.Drawing.Size(91, 22)
        Me.lblGiaoCho.TabIndex = 0
        Me.lblGiaoCho.Text = "Giao cho:"
        Me.lblGiaoCho.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNguoiDuyet
        '
        Me.lblNguoiDuyet.Location = New System.Drawing.Point(248, 108)
        Me.lblNguoiDuyet.Name = "lblNguoiDuyet"
        Me.lblNguoiDuyet.Size = New System.Drawing.Size(145, 22)
        Me.lblNguoiDuyet.TabIndex = 0
        Me.lblNguoiDuyet.Text = "Người duyệt:"
        Me.lblNguoiDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNgayGiao
        '
        Me.lblNgayGiao.Location = New System.Drawing.Point(551, 108)
        Me.lblNgayGiao.Name = "lblNgayGiao"
        Me.lblNgayGiao.Size = New System.Drawing.Size(127, 22)
        Me.lblNgayGiao.TabIndex = 0
        Me.lblNgayGiao.Text = "Ngày giao:"
        Me.lblNgayGiao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpNgay
        '
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgay.Location = New System.Drawing.Point(684, 77)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(86, 21)
        Me.dtpNgay.TabIndex = 2
        '
        'txtNguoiDuyet
        '
        Me.txtNguoiDuyet.Location = New System.Drawing.Point(399, 108)
        Me.txtNguoiDuyet.Name = "txtNguoiDuyet"
        Me.txtNguoiDuyet.Size = New System.Drawing.Size(147, 21)
        Me.txtNguoiDuyet.TabIndex = 3
        '
        'grpPhieuDeXuat
        '
        Me.grpPhieuDeXuat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPhieuDeXuat.Controls.Add(Me.grdDanhsachvattu)
        Me.grpPhieuDeXuat.Location = New System.Drawing.Point(12, 167)
        Me.grpPhieuDeXuat.Name = "grpPhieuDeXuat"
        Me.grpPhieuDeXuat.Size = New System.Drawing.Size(800, 279)
        Me.grpPhieuDeXuat.TabIndex = 4
        Me.grpPhieuDeXuat.TabStop = False
        Me.grpPhieuDeXuat.Text = "Chi tiết phiếu đề xuất"
        '
        'grdDanhsachvattu
        '
        Me.grdDanhsachvattu.AllowUserToAddRows = False
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
        Me.grdDanhsachvattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachvattu.Location = New System.Drawing.Point(3, 17)
        Me.grdDanhsachvattu.Name = "grdDanhsachvattu"
        Me.grdDanhsachvattu.Size = New System.Drawing.Size(794, 259)
        Me.grdDanhsachvattu.TabIndex = 1
        '
        'chkDuyet
        '
        Me.chkDuyet.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkDuyet.AutoSize = True
        Me.chkDuyet.Checked = True
        Me.chkDuyet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDuyet.Location = New System.Drawing.Point(341, 150)
        Me.chkDuyet.Name = "chkDuyet"
        Me.chkDuyet.Size = New System.Drawing.Size(180, 17)
        Me.chkDuyet.TabIndex = 0
        Me.chkDuyet.Text = "Đề xuất đặt mua hàng đã duyệt"
        Me.chkDuyet.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(725, 452)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(87, 28)
        Me.btnThoat.TabIndex = 5
        Me.btnThoat.Text = "T&hoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnIn
        '
        Me.btnIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnIn.Location = New System.Drawing.Point(638, 452)
        Me.btnIn.Name = "btnIn"
        Me.btnIn.Size = New System.Drawing.Size(87, 28)
        Me.btnIn.TabIndex = 5
        Me.btnIn.Text = "&In"
        Me.btnIn.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSua.ForeColor = System.Drawing.Color.Teal
        Me.btnSua.Location = New System.Drawing.Point(551, 452)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(87, 28)
        Me.btnSua.TabIndex = 5
        Me.btnSua.Text = "&Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXoa.ForeColor = System.Drawing.Color.Red
        Me.btnXoa.Location = New System.Drawing.Point(464, 452)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(87, 28)
        Me.btnXoa.TabIndex = 5
        Me.btnXoa.Text = "&Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThem.ForeColor = System.Drawing.Color.Blue
        Me.btnThem.Location = New System.Drawing.Point(377, 452)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(87, 28)
        Me.btnThem.TabIndex = 5
        Me.btnThem.Text = "&Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnKhongGhi
        '
        Me.btnKhongGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKhongGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKhongGhi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnKhongGhi.Location = New System.Drawing.Point(725, 452)
        Me.btnKhongGhi.Name = "btnKhongGhi"
        Me.btnKhongGhi.Size = New System.Drawing.Size(87, 28)
        Me.btnKhongGhi.TabIndex = 5
        Me.btnKhongGhi.Text = "&Không ghi"
        Me.btnKhongGhi.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGhi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnGhi.Location = New System.Drawing.Point(638, 452)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(87, 28)
        Me.btnGhi.TabIndex = 5
        Me.btnGhi.Text = "&Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnDuyet
        '
        Me.btnDuyet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDuyet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDuyet.ForeColor = System.Drawing.Color.Navy
        Me.btnDuyet.Location = New System.Drawing.Point(12, 452)
        Me.btnDuyet.Name = "btnDuyet"
        Me.btnDuyet.Size = New System.Drawing.Size(119, 28)
        Me.btnDuyet.TabIndex = 5
        Me.btnDuyet.Text = "&Duyệt"
        Me.btnDuyet.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnChonVTPT
        '
        Me.btnChonVTPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChonVTPT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChonVTPT.ForeColor = System.Drawing.Color.Navy
        Me.btnChonVTPT.Location = New System.Drawing.Point(12, 452)
        Me.btnChonVTPT.Name = "btnChonVTPT"
        Me.btnChonVTPT.Size = New System.Drawing.Size(119, 28)
        Me.btnChonVTPT.TabIndex = 5
        Me.btnChonVTPT.Text = "Chọn VT PT"
        Me.btnChonVTPT.UseVisualStyleBackColor = True
        Me.btnChonVTPT.Visible = False
        '
        'txtNgayGiao
        '
        Me.txtNgayGiao.BackColor = System.Drawing.Color.White
        Me.txtNgayGiao.Location = New System.Drawing.Point(684, 109)
        Me.txtNgayGiao.Mask = "00/00/0000"
        Me.txtNgayGiao.Name = "txtNgayGiao"
        Me.txtNgayGiao.Size = New System.Drawing.Size(86, 21)
        Me.txtNgayGiao.TabIndex = 7
        Me.txtNgayGiao.ValidatingType = GetType(Date)
        '
        'txtGiaoCho
        '
        Me.txtGiaoCho.BackColor = System.Drawing.Color.White
        Me.txtGiaoCho.ErrorProviderControl = Me.ErrorProvider1
        Me.txtGiaoCho.FieldName = ""
        Me.txtGiaoCho.IsNull = False
        Me.txtGiaoCho.Location = New System.Drawing.Point(109, 108)
        Me.txtGiaoCho.Name = "txtGiaoCho"
        Me.txtGiaoCho.Size = New System.Drawing.Size(133, 21)
        Me.txtGiaoCho.TabIndex = 8
        Me.txtGiaoCho.TextTypeMode = Commons.TypeMode.None
        '
        'cboBoPhanDeXuat
        '
        Me.cboBoPhanDeXuat.AssemblyName = ""
        Me.cboBoPhanDeXuat.BackColor = System.Drawing.Color.White
        Me.cboBoPhanDeXuat.ClassName = ""
        Me.cboBoPhanDeXuat.Display = ""
        Me.cboBoPhanDeXuat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBoPhanDeXuat.ErrorProviderControl = Me.ErrorProvider1
        Me.cboBoPhanDeXuat.FormattingEnabled = True
        Me.cboBoPhanDeXuat.IsAll = False
        Me.cboBoPhanDeXuat.IsNew = False
        Me.cboBoPhanDeXuat.ItemAll = " < ALL > "
        Me.cboBoPhanDeXuat.ItemNew = "...New"
        Me.cboBoPhanDeXuat.Location = New System.Drawing.Point(399, 77)
        Me.cboBoPhanDeXuat.MethodName = ""
        Me.cboBoPhanDeXuat.Name = "cboBoPhanDeXuat"
        Me.cboBoPhanDeXuat.Param = ""
        Me.cboBoPhanDeXuat.Size = New System.Drawing.Size(147, 21)
        Me.cboBoPhanDeXuat.StoreName = ""
        Me.cboBoPhanDeXuat.TabIndex = 1
        Me.cboBoPhanDeXuat.Table = Nothing
        Me.cboBoPhanDeXuat.TextReadonly = False
        Me.cboBoPhanDeXuat.Value = ""
        '
        'cboSoDeXuat
        '
        Me.cboSoDeXuat.AssemblyName = ""
        Me.cboSoDeXuat.BackColor = System.Drawing.Color.White
        Me.cboSoDeXuat.ClassName = ""
        Me.cboSoDeXuat.Display = ""
        Me.cboSoDeXuat.ErrorProviderControl = Me.ErrorProvider1
        Me.cboSoDeXuat.FormattingEnabled = True
        Me.cboSoDeXuat.IsAll = False
        Me.cboSoDeXuat.IsNew = False
        Me.cboSoDeXuat.ItemAll = " < ALL > "
        Me.cboSoDeXuat.ItemNew = "...New"
        Me.cboSoDeXuat.Location = New System.Drawing.Point(109, 77)
        Me.cboSoDeXuat.MethodName = ""
        Me.cboSoDeXuat.Name = "cboSoDeXuat"
        Me.cboSoDeXuat.Param = ""
        Me.cboSoDeXuat.Size = New System.Drawing.Size(133, 21)
        Me.cboSoDeXuat.StoreName = ""
        Me.cboSoDeXuat.TabIndex = 1
        Me.cboSoDeXuat.Table = Nothing
        Me.cboSoDeXuat.TextReadonly = False
        Me.cboSoDeXuat.Value = ""
        '
        'txtSoDeXuat
        '
        Me.txtSoDeXuat.BackColor = System.Drawing.Color.White
        Me.txtSoDeXuat.ErrorProviderControl = Me.ErrorProvider1
        Me.txtSoDeXuat.FieldName = ""
        Me.txtSoDeXuat.IsNull = False
        Me.txtSoDeXuat.Location = New System.Drawing.Point(109, 77)
        Me.txtSoDeXuat.Name = "txtSoDeXuat"
        Me.txtSoDeXuat.Size = New System.Drawing.Size(133, 21)
        Me.txtSoDeXuat.TabIndex = 6
        Me.txtSoDeXuat.TextTypeMode = Commons.TypeMode.None
        '
        'frmDeXuatMuaHang_DUYTAN
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 492)
        Me.Controls.Add(Me.txtGiaoCho)
        Me.Controls.Add(Me.txtNgayGiao)
        Me.Controls.Add(Me.btnDuyet)
        Me.Controls.Add(Me.chkDuyet)
        Me.Controls.Add(Me.btnThem)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnSua)
        Me.Controls.Add(Me.btnIn)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.grpPhieuDeXuat)
        Me.Controls.Add(Me.txtNguoiDuyet)
        Me.Controls.Add(Me.dtpNgay)
        Me.Controls.Add(Me.cboBoPhanDeXuat)
        Me.Controls.Add(Me.lblNgayGiao)
        Me.Controls.Add(Me.lblNguoiDuyet)
        Me.Controls.Add(Me.lblGiaoCho)
        Me.Controls.Add(Me.lblNgay)
        Me.Controls.Add(Me.lblBoPhanDeXuat)
        Me.Controls.Add(Me.lblSoDeXuat)
        Me.Controls.Add(Me.lblTieuDe)
        Me.Controls.Add(Me.btnGhi)
        Me.Controls.Add(Me.btnKhongGhi)
        Me.Controls.Add(Me.cboSoDeXuat)
        Me.Controls.Add(Me.txtSoDeXuat)
        Me.Controls.Add(Me.btnChonVTPT)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeXuatMuaHang_DUYTAN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDeXuatMuaHang_DUYTAN"
        Me.grpPhieuDeXuat.ResumeLayout(False)
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents lblSoDeXuat As System.Windows.Forms.Label
    Friend WithEvents lblBoPhanDeXuat As System.Windows.Forms.Label
    Friend WithEvents lblNgay As System.Windows.Forms.Label
    Friend WithEvents lblGiaoCho As System.Windows.Forms.Label
    Friend WithEvents lblNguoiDuyet As System.Windows.Forms.Label
    Friend WithEvents lblNgayGiao As System.Windows.Forms.Label
    Friend WithEvents cboSoDeXuat As Commons.UtcComboBox
    Friend WithEvents cboBoPhanDeXuat As Commons.UtcComboBox
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNguoiDuyet As System.Windows.Forms.TextBox
    Friend WithEvents grpPhieuDeXuat As System.Windows.Forms.GroupBox
    Friend WithEvents chkDuyet As System.Windows.Forms.CheckBox
    Friend WithEvents grdDanhsachvattu As Commons.QLGrid
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents btnIn As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnKhongGhi As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnDuyet As System.Windows.Forms.Button
    Friend WithEvents btnChonVTPT As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtSoDeXuat As Commons.utcTextBox
    Friend WithEvents txtNgayGiao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtGiaoCho As Commons.utcTextBox
End Class
