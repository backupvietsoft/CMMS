<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNgoaite
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
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsachngoaite = New System.Windows.Forms.GroupBox()
        Me.GrdDanhsachngoaite = New System.Windows.Forms.DataGridView()
        Me.GrpNhapngoaite = New System.Windows.Forms.GroupBox()
        Me.TxtTenngoaite = New Commons.utcTextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtMangoaite = New Commons.utcTextBox()
        Me.ChkMacdinh = New System.Windows.Forms.CheckBox()
        Me.LblMangoaite = New System.Windows.Forms.Label()
        Me.LblTenngoaite = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.LblTieudengoaite = New System.Windows.Forms.Label()
        Me.GrpDanhsachngoaite.SuspendLayout()
        CType(Me.GrdDanhsachngoaite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhapngoaite.SuspendLayout()
        CType(Me.TxtTenngoaite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMangoaite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Location = New System.Drawing.Point(414, 424)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 6
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Location = New System.Drawing.Point(624, 424)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 8
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Location = New System.Drawing.Point(519, 424)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 7
        Me.BtnXoa.Text = "&Xóa"
        '
        'GrpDanhsachngoaite
        '
        Me.GrpDanhsachngoaite.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhsachngoaite.Controls.Add(Me.GrdDanhsachngoaite)
        Me.GrpDanhsachngoaite.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhsachngoaite.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsachngoaite.Location = New System.Drawing.Point(12, 135)
        Me.GrpDanhsachngoaite.Name = "GrpDanhsachngoaite"
        Me.GrpDanhsachngoaite.Size = New System.Drawing.Size(711, 282)
        Me.GrpDanhsachngoaite.TabIndex = 36
        Me.GrpDanhsachngoaite.TabStop = False
        Me.GrpDanhsachngoaite.Text = "Danh sách ngoại tệ"
        '
        'GrdDanhsachngoaite
        '
        Me.GrdDanhsachngoaite.AllowDrop = True
        Me.GrdDanhsachngoaite.AllowUserToAddRows = False
        Me.GrdDanhsachngoaite.AllowUserToDeleteRows = False
        Me.GrdDanhsachngoaite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhsachngoaite.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhsachngoaite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhsachngoaite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhsachngoaite.Location = New System.Drawing.Point(3, 18)
        Me.GrdDanhsachngoaite.MultiSelect = False
        Me.GrdDanhsachngoaite.Name = "GrdDanhsachngoaite"
        Me.GrdDanhsachngoaite.ReadOnly = True
        Me.GrdDanhsachngoaite.RowHeadersWidth = 25
        Me.GrdDanhsachngoaite.ShowEditingIcon = False
        Me.GrdDanhsachngoaite.Size = New System.Drawing.Size(705, 261)
        Me.GrdDanhsachngoaite.TabIndex = 4
        '
        'GrpNhapngoaite
        '
        Me.GrpNhapngoaite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapngoaite.Controls.Add(Me.TxtTenngoaite)
        Me.GrpNhapngoaite.Controls.Add(Me.TxtMangoaite)
        Me.GrpNhapngoaite.Controls.Add(Me.ChkMacdinh)
        Me.GrpNhapngoaite.Controls.Add(Me.LblMangoaite)
        Me.GrpNhapngoaite.Controls.Add(Me.LblTenngoaite)
        Me.GrpNhapngoaite.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapngoaite.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapngoaite.Location = New System.Drawing.Point(34, 43)
        Me.GrpNhapngoaite.Name = "GrpNhapngoaite"
        Me.GrpNhapngoaite.Size = New System.Drawing.Size(664, 83)
        Me.GrpNhapngoaite.TabIndex = 35
        Me.GrpNhapngoaite.TabStop = False
        Me.GrpNhapngoaite.Text = "Nhập ngoại tệ"
        '
        'TxtTenngoaite
        '
        Me.TxtTenngoaite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTenngoaite.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtTenngoaite.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtTenngoaite.ErrorProviderControl = Me.ErrorProvider
        Me.TxtTenngoaite.FieldName = ""
        Me.TxtTenngoaite.IsNull = False
        Me.TxtTenngoaite.Location = New System.Drawing.Point(114, 49)
        Me.TxtTenngoaite.MaxLength = 0
        Me.TxtTenngoaite.Multiline = False
        Me.TxtTenngoaite.Name = "TxtTenngoaite"
        Me.TxtTenngoaite.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtTenngoaite.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtTenngoaite.Properties.Appearance.Options.UseBackColor = True
        Me.TxtTenngoaite.ReadOnly = True
        Me.TxtTenngoaite.Size = New System.Drawing.Size(529, 20)
        Me.TxtTenngoaite.TabIndex = 2
        Me.TxtTenngoaite.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtTenngoaite.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TxtMangoaite
        '
        Me.TxtMangoaite.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtMangoaite.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtMangoaite.ErrorProviderControl = Me.ErrorProvider
        Me.TxtMangoaite.FieldName = ""
        Me.TxtMangoaite.IsNull = False
        Me.TxtMangoaite.Location = New System.Drawing.Point(114, 21)
        Me.TxtMangoaite.MaxLength = 6
        Me.TxtMangoaite.Multiline = False
        Me.TxtMangoaite.Name = "TxtMangoaite"
        Me.TxtMangoaite.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtMangoaite.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtMangoaite.Properties.Appearance.Options.UseBackColor = True
        Me.TxtMangoaite.Properties.MaxLength = 6
        Me.TxtMangoaite.ReadOnly = True
        Me.TxtMangoaite.Size = New System.Drawing.Size(161, 20)
        Me.TxtMangoaite.TabIndex = 1
        Me.TxtMangoaite.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtMangoaite.TextTypeMode = Commons.TypeMode.None
        '
        'ChkMacdinh
        '
        Me.ChkMacdinh.AutoSize = True
        Me.ChkMacdinh.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkMacdinh.ForeColor = System.Drawing.Color.Black
        Me.ChkMacdinh.Location = New System.Drawing.Point(306, 23)
        Me.ChkMacdinh.Name = "ChkMacdinh"
        Me.ChkMacdinh.Size = New System.Drawing.Size(15, 14)
        Me.ChkMacdinh.TabIndex = 3
        Me.ChkMacdinh.UseVisualStyleBackColor = True
        '
        'LblMangoaite
        '
        Me.LblMangoaite.AutoSize = True
        Me.LblMangoaite.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMangoaite.ForeColor = System.Drawing.Color.Black
        Me.LblMangoaite.Location = New System.Drawing.Point(12, 25)
        Me.LblMangoaite.Name = "LblMangoaite"
        Me.LblMangoaite.Size = New System.Drawing.Size(44, 14)
        Me.LblMangoaite.TabIndex = 3
        Me.LblMangoaite.Text = "Mã NT"
        '
        'LblTenngoaite
        '
        Me.LblTenngoaite.AutoSize = True
        Me.LblTenngoaite.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTenngoaite.ForeColor = System.Drawing.Color.Black
        Me.LblTenngoaite.Location = New System.Drawing.Point(12, 55)
        Me.LblTenngoaite.Name = "LblTenngoaite"
        Me.LblTenngoaite.Size = New System.Drawing.Size(58, 14)
        Me.LblTenngoaite.TabIndex = 5
        Me.LblTenngoaite.Text = "Ngoại tệ"
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Location = New System.Drawing.Point(309, 424)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 5
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Location = New System.Drawing.Point(519, 424)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 9
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Location = New System.Drawing.Point(624, 424)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 10
        Me.BtnKhongghi.Text = "&Không"
        '
        'LblTieudengoaite
        '
        Me.LblTieudengoaite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTieudengoaite.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieudengoaite.ForeColor = System.Drawing.Color.Navy
        Me.LblTieudengoaite.Location = New System.Drawing.Point(0, 9)
        Me.LblTieudengoaite.Name = "LblTieudengoaite"
        Me.LblTieudengoaite.Size = New System.Drawing.Size(734, 29)
        Me.LblTieudengoaite.TabIndex = 43
        Me.LblTieudengoaite.Text = "NGOẠI TỆ"
        Me.LblTieudengoaite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmNgoaite
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.LblTieudengoaite)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.GrpDanhsachngoaite)
        Me.Controls.Add(Me.GrpNhapngoaite)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmNgoaite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ngoại tệ"
        Me.GrpDanhsachngoaite.ResumeLayout(False)
        CType(Me.GrdDanhsachngoaite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhapngoaite.ResumeLayout(False)
        Me.GrpNhapngoaite.PerformLayout()
        CType(Me.TxtTenngoaite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMangoaite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhsachngoaite As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhsachngoaite As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhapngoaite As System.Windows.Forms.GroupBox
    Friend WithEvents LblMangoaite As System.Windows.Forms.Label
    Friend WithEvents LblTenngoaite As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ChkMacdinh As System.Windows.Forms.CheckBox
    Friend WithEvents TxtTenngoaite As Commons.utcTextBox
    Friend WithEvents TxtMangoaite As Commons.utcTextBox
    Friend WithEvents LblTieudengoaite As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
End Class
