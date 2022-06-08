<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHangsanxuat
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.grpDanhsachHSX = New System.Windows.Forms.GroupBox()
        Me.grdDanhsachHSX = New System.Windows.Forms.DataGridView()
        Me.grpNhaptenHSX = New System.Windows.Forms.GroupBox()
        Me.lblWebsite = New System.Windows.Forms.Label()
        Me.lblDiachi = New System.Windows.Forms.Label()
        Me.txtWebsite = New Commons.utcTextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtDiachi = New Commons.utcTextBox()
        Me.txtTenHSX = New Commons.utcTextBox()
        Me.lblTenHSX = New System.Windows.Forms.Label()
        Me.lblTieudeHangSX = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.txtMasoHSX = New Commons.utcTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpDanhsachHSX.SuspendLayout()
        CType(Me.grdDanhsachHSX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNhaptenHSX.SuspendLayout()
        CType(Me.txtWebsite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiachi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTenHSX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMasoHSX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(510, 2)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 7
        Me.BtnXoa.Text = "&Xóa"
        '
        'grpDanhsachHSX
        '
        Me.grpDanhsachHSX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDanhsachHSX.Controls.Add(Me.grdDanhsachHSX)
        Me.grpDanhsachHSX.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhsachHSX.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachHSX.Location = New System.Drawing.Point(12, 158)
        Me.grpDanhsachHSX.Name = "grpDanhsachHSX"
        Me.grpDanhsachHSX.Size = New System.Drawing.Size(710, 260)
        Me.grpDanhsachHSX.TabIndex = 86
        Me.grpDanhsachHSX.TabStop = False
        Me.grpDanhsachHSX.Text = "Danh sách hãng sản xuất"
        '
        'grdDanhsachHSX
        '
        Me.grdDanhsachHSX.AllowUserToAddRows = False
        Me.grdDanhsachHSX.AllowUserToDeleteRows = False
        Me.grdDanhsachHSX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.Format = "N2"
        Me.grdDanhsachHSX.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachHSX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachHSX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachHSX.Location = New System.Drawing.Point(3, 18)
        Me.grdDanhsachHSX.Name = "grdDanhsachHSX"
        Me.grdDanhsachHSX.ReadOnly = True
        Me.grdDanhsachHSX.RowHeadersWidth = 25
        Me.grdDanhsachHSX.Size = New System.Drawing.Size(704, 239)
        Me.grdDanhsachHSX.TabIndex = 4
        '
        'grpNhaptenHSX
        '
        Me.grpNhaptenHSX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNhaptenHSX.Controls.Add(Me.lblWebsite)
        Me.grpNhaptenHSX.Controls.Add(Me.lblDiachi)
        Me.grpNhaptenHSX.Controls.Add(Me.txtWebsite)
        Me.grpNhaptenHSX.Controls.Add(Me.txtDiachi)
        Me.grpNhaptenHSX.Controls.Add(Me.txtTenHSX)
        Me.grpNhaptenHSX.Controls.Add(Me.lblTenHSX)
        Me.grpNhaptenHSX.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNhaptenHSX.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhaptenHSX.Location = New System.Drawing.Point(45, 53)
        Me.grpNhaptenHSX.Name = "grpNhaptenHSX"
        Me.grpNhaptenHSX.Size = New System.Drawing.Size(643, 99)
        Me.grpNhaptenHSX.TabIndex = 85
        Me.grpNhaptenHSX.TabStop = False
        Me.grpNhaptenHSX.Text = "Nhập hãng sản xuất"
        '
        'lblWebsite
        '
        Me.lblWebsite.AutoSize = True
        Me.lblWebsite.ForeColor = System.Drawing.Color.Black
        Me.lblWebsite.Location = New System.Drawing.Point(6, 68)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Size = New System.Drawing.Size(52, 14)
        Me.lblWebsite.TabIndex = 38
        Me.lblWebsite.Text = "Website"
        '
        'lblDiachi
        '
        Me.lblDiachi.AutoSize = True
        Me.lblDiachi.ForeColor = System.Drawing.Color.Black
        Me.lblDiachi.Location = New System.Drawing.Point(6, 45)
        Me.lblDiachi.Name = "lblDiachi"
        Me.lblDiachi.Size = New System.Drawing.Size(42, 14)
        Me.lblDiachi.TabIndex = 37
        Me.lblDiachi.Text = "Địa chỉ"
        '
        'txtWebsite
        '
        Me.txtWebsite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWebsite.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtWebsite.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtWebsite.ErrorProviderControl = Me.ErrorProvider
        Me.txtWebsite.FieldName = ""
        Me.txtWebsite.IsNull = True
        Me.txtWebsite.Location = New System.Drawing.Point(134, 65)
        Me.txtWebsite.MaxLength = 0
        Me.txtWebsite.Multiline = False
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWebsite.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtWebsite.Properties.Appearance.Options.UseBackColor = True
        Me.txtWebsite.Properties.Appearance.Options.UseTextOptions = True
        Me.txtWebsite.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtWebsite.Properties.ReadOnly = True
        Me.txtWebsite.ReadOnly = True
        Me.txtWebsite.Size = New System.Drawing.Size(495, 20)
        Me.txtWebsite.TabIndex = 3
        Me.txtWebsite.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtWebsite.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'txtDiachi
        '
        Me.txtDiachi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiachi.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtDiachi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtDiachi.ErrorProviderControl = Me.ErrorProvider
        Me.txtDiachi.FieldName = ""
        Me.txtDiachi.IsNull = True
        Me.txtDiachi.Location = New System.Drawing.Point(134, 42)
        Me.txtDiachi.MaxLength = 0
        Me.txtDiachi.Multiline = False
        Me.txtDiachi.Name = "txtDiachi"
        Me.txtDiachi.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDiachi.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtDiachi.Properties.Appearance.Options.UseBackColor = True
        Me.txtDiachi.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDiachi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtDiachi.Properties.ReadOnly = True
        Me.txtDiachi.ReadOnly = True
        Me.txtDiachi.Size = New System.Drawing.Size(495, 20)
        Me.txtDiachi.TabIndex = 2
        Me.txtDiachi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDiachi.TextTypeMode = Commons.TypeMode.None
        '
        'txtTenHSX
        '
        Me.txtTenHSX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTenHSX.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTenHSX.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTenHSX.ErrorProviderControl = Me.ErrorProvider
        Me.txtTenHSX.FieldName = ""
        Me.txtTenHSX.IsNull = False
        Me.txtTenHSX.Location = New System.Drawing.Point(134, 19)
        Me.txtTenHSX.MaxLength = 0
        Me.txtTenHSX.Multiline = False
        Me.txtTenHSX.Name = "txtTenHSX"
        Me.txtTenHSX.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTenHSX.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTenHSX.Properties.Appearance.Options.UseBackColor = True
        Me.txtTenHSX.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTenHSX.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTenHSX.Properties.ReadOnly = True
        Me.txtTenHSX.ReadOnly = True
        Me.txtTenHSX.Size = New System.Drawing.Size(495, 20)
        Me.txtTenHSX.TabIndex = 1
        Me.txtTenHSX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTenHSX.TextTypeMode = Commons.TypeMode.None
        '
        'lblTenHSX
        '
        Me.lblTenHSX.AutoSize = True
        Me.lblTenHSX.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenHSX.ForeColor = System.Drawing.Color.Black
        Me.lblTenHSX.Location = New System.Drawing.Point(6, 22)
        Me.lblTenHSX.Name = "lblTenHSX"
        Me.lblTenHSX.Size = New System.Drawing.Size(96, 14)
        Me.lblTenHSX.TabIndex = 5
        Me.lblTenHSX.Text = "Hãng sản xuất"
        '
        'lblTieudeHangSX
        '
        Me.lblTieudeHangSX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTieudeHangSX.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTieudeHangSX.ForeColor = System.Drawing.Color.Navy
        Me.lblTieudeHangSX.Location = New System.Drawing.Point(12, 9)
        Me.lblTieudeHangSX.Name = "lblTieudeHangSX"
        Me.lblTieudeHangSX.Size = New System.Drawing.Size(707, 31)
        Me.lblTieudeHangSX.TabIndex = 93
        Me.lblTieudeHangSX.Text = "HÃNG SẢN XUẤT"
        Me.lblTieudeHangSX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(300, 2)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 5
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(510, 2)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 9
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(615, 2)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 10
        Me.BtnKhongghi.Text = "&Không"
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(405, 2)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 6
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Location = New System.Drawing.Point(615, 2)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 8
        Me.BtnThoat.Text = "T&hoát"
        '
        'txtMasoHSX
        '
        Me.txtMasoHSX.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMasoHSX.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMasoHSX.ErrorProviderControl = Me.ErrorProvider
        Me.txtMasoHSX.FieldName = ""
        Me.txtMasoHSX.IsNull = True
        Me.txtMasoHSX.Location = New System.Drawing.Point(12, 4)
        Me.txtMasoHSX.MaxLength = 0
        Me.txtMasoHSX.Multiline = False
        Me.txtMasoHSX.Name = "txtMasoHSX"
        Me.txtMasoHSX.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMasoHSX.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMasoHSX.Properties.Appearance.Options.UseBackColor = True
        Me.txtMasoHSX.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMasoHSX.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtMasoHSX.Properties.ReadOnly = True
        Me.txtMasoHSX.ReadOnly = True
        Me.txtMasoHSX.Size = New System.Drawing.Size(14, 20)
        Me.txtMasoHSX.TabIndex = 92
        Me.txtMasoHSX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMasoHSX.TextTypeMode = Commons.TypeMode.None
        Me.txtMasoHSX.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Location = New System.Drawing.Point(0, 423)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(722, 34)
        Me.Panel1.TabIndex = 94
        '
        'frmHangsanxuat
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.grpDanhsachHSX)
        Me.Controls.Add(Me.grpNhaptenHSX)
        Me.Controls.Add(Me.lblTieudeHangSX)
        Me.Controls.Add(Me.txtMasoHSX)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHangsanxuat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hãng sản xuất"
        Me.grpDanhsachHSX.ResumeLayout(False)
        CType(Me.grdDanhsachHSX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNhaptenHSX.ResumeLayout(False)
        Me.grpNhaptenHSX.PerformLayout()
        CType(Me.txtWebsite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiachi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTenHSX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMasoHSX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpDanhsachHSX As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachHSX As System.Windows.Forms.DataGridView
    Friend WithEvents grpNhaptenHSX As System.Windows.Forms.GroupBox
    Friend WithEvents txtTenHSX As Commons.utcTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblTieudeHangSX As System.Windows.Forms.Label
    Friend WithEvents txtMasoHSX As Commons.utcTextBox
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTenHSX As System.Windows.Forms.Label
    Friend WithEvents txtWebsite As Commons.utcTextBox
    Friend WithEvents txtDiachi As Commons.utcTextBox
    Friend WithEvents lblWebsite As System.Windows.Forms.Label
    Friend WithEvents lblDiachi As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
