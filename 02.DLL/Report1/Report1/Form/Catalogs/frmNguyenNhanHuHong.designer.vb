<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNguyenNhanHuHong
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpNhapNguyenNhan = New System.Windows.Forms.GroupBox()
        Me.TxtMa = New System.Windows.Forms.Label()
        Me.txtNN_CH = New Commons.utcTextBox()
        Me.lblNN_CH = New System.Windows.Forms.Label()
        Me.txtNN_EN = New Commons.utcTextBox()
        Me.lblNN_EN = New System.Windows.Forms.Label()
        Me.txtNN_Viet = New Commons.utcTextBox()
        Me.lblMaNguyenNhan = New System.Windows.Forms.Label()
        Me.lblNN_Viet = New System.Windows.Forms.Label()
        Me.LblTieude = New System.Windows.Forms.Label()
        Me.grpDanhSachNN = New System.Windows.Forms.GroupBox()
        Me.dgrDanhsachNguyenNhan = New System.Windows.Forms.DataGridView()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNhapNguyenNhan.SuspendLayout()
        CType(Me.txtNN_CH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNN_EN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNN_Viet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhSachNN.SuspendLayout()
        CType(Me.dgrDanhsachNguyenNhan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'grpNhapNguyenNhan
        '
        Me.grpNhapNguyenNhan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNhapNguyenNhan.Controls.Add(Me.TxtMa)
        Me.grpNhapNguyenNhan.Controls.Add(Me.txtNN_CH)
        Me.grpNhapNguyenNhan.Controls.Add(Me.lblNN_CH)
        Me.grpNhapNguyenNhan.Controls.Add(Me.txtNN_EN)
        Me.grpNhapNguyenNhan.Controls.Add(Me.lblNN_EN)
        Me.grpNhapNguyenNhan.Controls.Add(Me.txtNN_Viet)
        Me.grpNhapNguyenNhan.Controls.Add(Me.lblMaNguyenNhan)
        Me.grpNhapNguyenNhan.Controls.Add(Me.lblNN_Viet)
        Me.grpNhapNguyenNhan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNhapNguyenNhan.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhapNguyenNhan.Location = New System.Drawing.Point(49, 41)
        Me.grpNhapNguyenNhan.Name = "grpNhapNguyenNhan"
        Me.grpNhapNguyenNhan.Size = New System.Drawing.Size(639, 105)
        Me.grpNhapNguyenNhan.TabIndex = 36
        Me.grpNhapNguyenNhan.TabStop = False
        Me.grpNhapNguyenNhan.Text = "Nhập nguyên nhân hư hỏng"
        '
        'TxtMa
        '
        Me.TxtMa.AutoSize = True
        Me.TxtMa.Location = New System.Drawing.Point(75, 28)
        Me.TxtMa.Name = "TxtMa"
        Me.TxtMa.Size = New System.Drawing.Size(0, 14)
        Me.TxtMa.TabIndex = 10
        '
        'txtNN_CH
        '
        Me.txtNN_CH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNN_CH.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtNN_CH.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtNN_CH.ErrorProviderControl = Me.ErrorProvider1
        Me.txtNN_CH.FieldName = ""
        Me.txtNN_CH.IsNull = False
        Me.txtNN_CH.Location = New System.Drawing.Point(270, 72)
        Me.txtNN_CH.MaxLength = 0
        Me.txtNN_CH.Multiline = False
        Me.txtNN_CH.Name = "txtNN_CH"
        Me.txtNN_CH.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNN_CH.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtNN_CH.Properties.Appearance.Options.UseBackColor = True
        Me.txtNN_CH.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNN_CH.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtNN_CH.Properties.ReadOnly = True
        Me.txtNN_CH.ReadOnly = True
        Me.txtNN_CH.Size = New System.Drawing.Size(348, 20)
        Me.txtNN_CH.TabIndex = 9
        Me.txtNN_CH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtNN_CH.TextTypeMode = Commons.TypeMode.None
        '
        'lblNN_CH
        '
        Me.lblNN_CH.AutoSize = True
        Me.lblNN_CH.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblNN_CH.ForeColor = System.Drawing.Color.Black
        Me.lblNN_CH.Location = New System.Drawing.Point(148, 80)
        Me.lblNN_CH.Name = "lblNN_CH"
        Me.lblNN_CH.Size = New System.Drawing.Size(86, 14)
        Me.lblNN_CH.TabIndex = 8
        Me.lblNN_CH.Text = "Tên tiếng Hoa"
        '
        'txtNN_EN
        '
        Me.txtNN_EN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNN_EN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtNN_EN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtNN_EN.ErrorProviderControl = Me.ErrorProvider1
        Me.txtNN_EN.FieldName = ""
        Me.txtNN_EN.IsNull = False
        Me.txtNN_EN.Location = New System.Drawing.Point(270, 46)
        Me.txtNN_EN.MaxLength = 0
        Me.txtNN_EN.Multiline = False
        Me.txtNN_EN.Name = "txtNN_EN"
        Me.txtNN_EN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNN_EN.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtNN_EN.Properties.Appearance.Options.UseBackColor = True
        Me.txtNN_EN.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNN_EN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtNN_EN.Properties.ReadOnly = True
        Me.txtNN_EN.ReadOnly = True
        Me.txtNN_EN.Size = New System.Drawing.Size(348, 20)
        Me.txtNN_EN.TabIndex = 7
        Me.txtNN_EN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtNN_EN.TextTypeMode = Commons.TypeMode.None
        '
        'lblNN_EN
        '
        Me.lblNN_EN.AutoSize = True
        Me.lblNN_EN.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblNN_EN.ForeColor = System.Drawing.Color.Black
        Me.lblNN_EN.Location = New System.Drawing.Point(147, 50)
        Me.lblNN_EN.Name = "lblNN_EN"
        Me.lblNN_EN.Size = New System.Drawing.Size(87, 14)
        Me.lblNN_EN.TabIndex = 6
        Me.lblNN_EN.Text = "Tên tiếng Anh"
        '
        'txtNN_Viet
        '
        Me.txtNN_Viet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNN_Viet.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtNN_Viet.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtNN_Viet.ErrorProviderControl = Me.ErrorProvider1
        Me.txtNN_Viet.FieldName = ""
        Me.txtNN_Viet.IsNull = False
        Me.txtNN_Viet.Location = New System.Drawing.Point(270, 20)
        Me.txtNN_Viet.MaxLength = 0
        Me.txtNN_Viet.Multiline = False
        Me.txtNN_Viet.Name = "txtNN_Viet"
        Me.txtNN_Viet.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNN_Viet.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtNN_Viet.Properties.Appearance.Options.UseBackColor = True
        Me.txtNN_Viet.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNN_Viet.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtNN_Viet.Properties.ReadOnly = True
        Me.txtNN_Viet.ReadOnly = True
        Me.txtNN_Viet.Size = New System.Drawing.Size(348, 20)
        Me.txtNN_Viet.TabIndex = 2
        Me.txtNN_Viet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtNN_Viet.TextTypeMode = Commons.TypeMode.None
        '
        'lblMaNguyenNhan
        '
        Me.lblMaNguyenNhan.AutoSize = True
        Me.lblMaNguyenNhan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaNguyenNhan.ForeColor = System.Drawing.Color.Black
        Me.lblMaNguyenNhan.Location = New System.Drawing.Point(40, 28)
        Me.lblMaNguyenNhan.Name = "lblMaNguyenNhan"
        Me.lblMaNguyenNhan.Size = New System.Drawing.Size(25, 14)
        Me.lblMaNguyenNhan.TabIndex = 3
        Me.lblMaNguyenNhan.Text = "Mã"
        '
        'lblNN_Viet
        '
        Me.lblNN_Viet.AutoSize = True
        Me.lblNN_Viet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNN_Viet.ForeColor = System.Drawing.Color.Black
        Me.lblNN_Viet.Location = New System.Drawing.Point(147, 24)
        Me.lblNN_Viet.Name = "lblNN_Viet"
        Me.lblNN_Viet.Size = New System.Drawing.Size(93, 14)
        Me.lblNN_Viet.TabIndex = 5
        Me.lblNN_Viet.Text = "Tên tiếng Việt"
        '
        'LblTieude
        '
        Me.LblTieude.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTieude.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.LblTieude.ForeColor = System.Drawing.Color.Navy
        Me.LblTieude.Location = New System.Drawing.Point(-1, 6)
        Me.LblTieude.Name = "LblTieude"
        Me.LblTieude.Size = New System.Drawing.Size(733, 29)
        Me.LblTieude.TabIndex = 44
        Me.LblTieude.Text = "NGUYÊN NHÂN HƯ HỎNG"
        Me.LblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpDanhSachNN
        '
        Me.grpDanhSachNN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDanhSachNN.Controls.Add(Me.dgrDanhsachNguyenNhan)
        Me.grpDanhSachNN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhSachNN.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhSachNN.Location = New System.Drawing.Point(8, 152)
        Me.grpDanhSachNN.Name = "grpDanhSachNN"
        Me.grpDanhSachNN.Size = New System.Drawing.Size(714, 264)
        Me.grpDanhSachNN.TabIndex = 45
        Me.grpDanhSachNN.TabStop = False
        Me.grpDanhSachNN.Text = "Danh sách nguyên nhân hư hỏng"
        '
        'dgrDanhsachNguyenNhan
        '
        Me.dgrDanhsachNguyenNhan.AllowUserToAddRows = False
        Me.dgrDanhsachNguyenNhan.AllowUserToDeleteRows = False
        Me.dgrDanhsachNguyenNhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrDanhsachNguyenNhan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgrDanhsachNguyenNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrDanhsachNguyenNhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrDanhsachNguyenNhan.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgrDanhsachNguyenNhan.Location = New System.Drawing.Point(3, 18)
        Me.dgrDanhsachNguyenNhan.MultiSelect = False
        Me.dgrDanhsachNguyenNhan.Name = "dgrDanhsachNguyenNhan"
        Me.dgrDanhsachNguyenNhan.ReadOnly = True
        Me.dgrDanhsachNguyenNhan.RowHeadersWidth = 25
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.Format = "N2"
        Me.dgrDanhsachNguyenNhan.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgrDanhsachNguyenNhan.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgrDanhsachNguyenNhan.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgrDanhsachNguyenNhan.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.dgrDanhsachNguyenNhan.Size = New System.Drawing.Size(708, 243)
        Me.dgrDanhsachNguyenNhan.TabIndex = 3
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(408, 425)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 11
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(303, 425)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 10
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Location = New System.Drawing.Point(618, 425)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 13
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(618, 425)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 15
        Me.BtnKhongghi.Text = "&Không"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(513, 425)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 12
        Me.BtnXoa.Text = "&Xóa"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(513, 425)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 14
        Me.BtnGhi.Text = "&Ghi"
        '
        'frmNguyenNhanHuHong
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.grpDanhSachNN)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.LblTieude)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.Controls.Add(Me.grpNhapNguyenNhan)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnGhi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmNguyenNhanHuHong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ngyên nhân hư hỏng"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNhapNguyenNhan.ResumeLayout(False)
        Me.grpNhapNguyenNhan.PerformLayout()
        CType(Me.txtNN_CH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNN_EN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNN_Viet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhSachNN.ResumeLayout(False)
        CType(Me.dgrDanhsachNguyenNhan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpNhapNguyenNhan As System.Windows.Forms.GroupBox
    Friend WithEvents txtNN_CH As Commons.utcTextBox
    Friend WithEvents lblNN_CH As System.Windows.Forms.Label
    Friend WithEvents txtNN_EN As Commons.utcTextBox
    Friend WithEvents lblNN_EN As System.Windows.Forms.Label
    Friend WithEvents txtNN_Viet As Commons.utcTextBox
    Friend WithEvents lblMaNguyenNhan As System.Windows.Forms.Label
    Friend WithEvents lblNN_Viet As System.Windows.Forms.Label
    Friend WithEvents LblTieude As System.Windows.Forms.Label
    Friend WithEvents grpDanhSachNN As System.Windows.Forms.GroupBox
    Friend WithEvents dgrDanhsachNguyenNhan As System.Windows.Forms.DataGridView
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtMa As System.Windows.Forms.Label
End Class
