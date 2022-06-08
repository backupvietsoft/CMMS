<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDonvithoigian
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
        Me.lblTieudedonviTG = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsachdonviTG = New System.Windows.Forms.GroupBox()
        Me.GrdDanhsachdonviTG = New System.Windows.Forms.DataGridView()
        Me.GrpNhapdonviTG = New System.Windows.Forms.GroupBox()
        Me.txtTendonviTG = New Commons.utcTextBox()
        Me.lblTenDVTG = New System.Windows.Forms.Label()
        Me.txtMadonviTG = New Commons.utcTextBox()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDanhsachdonviTG.SuspendLayout()
        CType(Me.GrdDanhsachdonviTG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhapdonviTG.SuspendLayout()
        CType(Me.txtTendonviTG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMadonviTG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieudedonviTG
        '
        Me.lblTieudedonviTG.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTieudedonviTG.ForeColor = System.Drawing.Color.Navy
        Me.lblTieudedonviTG.Location = New System.Drawing.Point(15, 9)
        Me.lblTieudedonviTG.Name = "lblTieudedonviTG"
        Me.lblTieudedonviTG.Size = New System.Drawing.Size(704, 24)
        Me.lblTieudedonviTG.TabIndex = 53
        Me.lblTieudedonviTG.Text = "ÑÔN VÒ THÔØI GIAN"
        Me.lblTieudedonviTG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(397, 435)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 3
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(560, 435)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 7
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = True
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(641, 435)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 8
        Me.BtnKhongghi.Text = "&Không"
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(479, 435)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(81, 25)
        Me.BtnSua.TabIndex = 4
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Appearance.Options.UseFont = True
        Me.BtnThoat.Location = New System.Drawing.Point(641, 435)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 6
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(560, 435)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 5
        Me.BtnXoa.Text = "&Xóa"
        '
        'GrpDanhsachdonviTG
        '
        Me.GrpDanhsachdonviTG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhsachdonviTG.Controls.Add(Me.GrdDanhsachdonviTG)
        Me.GrpDanhsachdonviTG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhsachdonviTG.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsachdonviTG.Location = New System.Drawing.Point(12, 112)
        Me.GrpDanhsachdonviTG.Name = "GrpDanhsachdonviTG"
        Me.GrpDanhsachdonviTG.Size = New System.Drawing.Size(710, 317)
        Me.GrpDanhsachdonviTG.TabIndex = 46
        Me.GrpDanhsachdonviTG.TabStop = False
        Me.GrpDanhsachdonviTG.Text = "Danh sách đơn vị thời gian"
        '
        'GrdDanhsachdonviTG
        '
        Me.GrdDanhsachdonviTG.AllowUserToAddRows = False
        Me.GrdDanhsachdonviTG.AllowUserToDeleteRows = False
        Me.GrdDanhsachdonviTG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhsachdonviTG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhsachdonviTG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhsachdonviTG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhsachdonviTG.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.GrdDanhsachdonviTG.Location = New System.Drawing.Point(3, 18)
        Me.GrdDanhsachdonviTG.Name = "GrdDanhsachdonviTG"
        Me.GrdDanhsachdonviTG.ReadOnly = True
        Me.GrdDanhsachdonviTG.RowHeadersWidth = 25
        Me.GrdDanhsachdonviTG.Size = New System.Drawing.Size(704, 296)
        Me.GrdDanhsachdonviTG.TabIndex = 2
        '
        'GrpNhapdonviTG
        '
        Me.GrpNhapdonviTG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapdonviTG.Controls.Add(Me.txtTendonviTG)
        Me.GrpNhapdonviTG.Controls.Add(Me.lblTenDVTG)
        Me.GrpNhapdonviTG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapdonviTG.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapdonviTG.Location = New System.Drawing.Point(55, 54)
        Me.GrpNhapdonviTG.Name = "GrpNhapdonviTG"
        Me.GrpNhapdonviTG.Size = New System.Drawing.Size(624, 52)
        Me.GrpNhapdonviTG.TabIndex = 45
        Me.GrpNhapdonviTG.TabStop = False
        Me.GrpNhapdonviTG.Text = "Nhập đơn vị thời gian"
        '
        'txtTendonviTG
        '
        Me.txtTendonviTG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTendonviTG.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTendonviTG.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTendonviTG.ErrorProviderControl = Me.ErrorProvider
        Me.txtTendonviTG.FieldName = ""
        Me.txtTendonviTG.IsNull = False
        Me.txtTendonviTG.Location = New System.Drawing.Point(102, 20)
        Me.txtTendonviTG.MaxLength = 0
        Me.txtTendonviTG.Multiline = False
        Me.txtTendonviTG.Name = "txtTendonviTG"
        Me.txtTendonviTG.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTendonviTG.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTendonviTG.Properties.Appearance.Options.UseBackColor = True
        Me.txtTendonviTG.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTendonviTG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTendonviTG.Properties.ReadOnly = True
        Me.txtTendonviTG.ReadOnly = True
        Me.txtTendonviTG.Size = New System.Drawing.Size(512, 20)
        Me.txtTendonviTG.TabIndex = 1
        Me.txtTendonviTG.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTendonviTG.TextTypeMode = Commons.TypeMode.None
        '
        'lblTenDVTG
        '
        Me.lblTenDVTG.AutoSize = True
        Me.lblTenDVTG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenDVTG.ForeColor = System.Drawing.Color.Black
        Me.lblTenDVTG.Location = New System.Drawing.Point(6, 23)
        Me.lblTenDVTG.Name = "lblTenDVTG"
        Me.lblTenDVTG.Size = New System.Drawing.Size(90, 14)
        Me.lblTenDVTG.TabIndex = 5
        Me.lblTenDVTG.Text = "Tên đơn vị TG"
        '
        'txtMadonviTG
        '
        Me.txtMadonviTG.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMadonviTG.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMadonviTG.ErrorProviderControl = Me.ErrorProvider
        Me.txtMadonviTG.FieldName = ""
        Me.txtMadonviTG.IsNull = True
        Me.txtMadonviTG.Location = New System.Drawing.Point(15, 9)
        Me.txtMadonviTG.MaxLength = 0
        Me.txtMadonviTG.Multiline = False
        Me.txtMadonviTG.Name = "txtMadonviTG"
        Me.txtMadonviTG.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMadonviTG.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMadonviTG.Properties.Appearance.Options.UseBackColor = True
        Me.txtMadonviTG.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMadonviTG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtMadonviTG.Properties.ReadOnly = True
        Me.txtMadonviTG.ReadOnly = True
        Me.txtMadonviTG.Size = New System.Drawing.Size(14, 20)
        Me.txtMadonviTG.TabIndex = 52
        Me.txtMadonviTG.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMadonviTG.TextTypeMode = Commons.TypeMode.None
        Me.txtMadonviTG.Visible = False
        '
        'frmDonvithoigian
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.lblTieudedonviTG)
        Me.Controls.Add(Me.txtMadonviTG)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.GrpDanhsachdonviTG)
        Me.Controls.Add(Me.GrpNhapdonviTG)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDonvithoigian"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Đơn vị thời gian"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDanhsachdonviTG.ResumeLayout(False)
        CType(Me.GrdDanhsachdonviTG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhapdonviTG.ResumeLayout(False)
        Me.GrpNhapdonviTG.PerformLayout()
        CType(Me.txtTendonviTG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMadonviTG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTieudedonviTG As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtMadonviTG As Commons.utcTextBox
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhsachdonviTG As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhsachdonviTG As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhapdonviTG As System.Windows.Forms.GroupBox
    Friend WithEvents txtTendonviTG As Commons.utcTextBox
    Friend WithEvents lblTenDVTG As System.Windows.Forms.Label
End Class
