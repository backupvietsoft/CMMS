<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoaichiphi
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
        Me.GrpDanhsachloaichiphi = New System.Windows.Forms.GroupBox()
        Me.GrdDanhsachloaichiphi = New System.Windows.Forms.DataGridView()
        Me.GrpNhaploaichiphi = New System.Windows.Forms.GroupBox()
        Me.txtGhichu = New Commons.utcTextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LblGhichu = New System.Windows.Forms.Label()
        Me.TxtTenloaichiphi = New Commons.utcTextBox()
        Me.LblTenloaichiphi = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.LblTieudeloaichiphi = New System.Windows.Forms.Label()
        Me.TxtMaso = New Commons.utcTextBox()
        Me.GrpDanhsachloaichiphi.SuspendLayout()
        CType(Me.GrdDanhsachloaichiphi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhaploaichiphi.SuspendLayout()
        CType(Me.txtGhichu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTenloaichiphi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMaso.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(355, 426)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 5
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Location = New System.Drawing.Point(565, 426)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 7
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(460, 426)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 6
        Me.BtnXoa.Text = "&Xóa"
        '
        'GrpDanhsachloaichiphi
        '
        Me.GrpDanhsachloaichiphi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhsachloaichiphi.Controls.Add(Me.GrdDanhsachloaichiphi)
        Me.GrpDanhsachloaichiphi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhsachloaichiphi.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsachloaichiphi.Location = New System.Drawing.Point(12, 131)
        Me.GrpDanhsachloaichiphi.Name = "GrpDanhsachloaichiphi"
        Me.GrpDanhsachloaichiphi.Size = New System.Drawing.Size(660, 289)
        Me.GrpDanhsachloaichiphi.TabIndex = 36
        Me.GrpDanhsachloaichiphi.TabStop = False
        Me.GrpDanhsachloaichiphi.Text = "Danh sách loại chi phí"
        '
        'GrdDanhsachloaichiphi
        '
        Me.GrdDanhsachloaichiphi.AllowUserToAddRows = False
        Me.GrdDanhsachloaichiphi.AllowUserToDeleteRows = False
        Me.GrdDanhsachloaichiphi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhsachloaichiphi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhsachloaichiphi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhsachloaichiphi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhsachloaichiphi.Location = New System.Drawing.Point(3, 18)
        Me.GrdDanhsachloaichiphi.MultiSelect = False
        Me.GrdDanhsachloaichiphi.Name = "GrdDanhsachloaichiphi"
        Me.GrdDanhsachloaichiphi.ReadOnly = True
        Me.GrdDanhsachloaichiphi.RowHeadersWidth = 25
        Me.GrdDanhsachloaichiphi.Size = New System.Drawing.Size(654, 268)
        Me.GrdDanhsachloaichiphi.TabIndex = 3
        '
        'GrpNhaploaichiphi
        '
        Me.GrpNhaploaichiphi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhaploaichiphi.Controls.Add(Me.txtGhichu)
        Me.GrpNhaploaichiphi.Controls.Add(Me.LblGhichu)
        Me.GrpNhaploaichiphi.Controls.Add(Me.TxtTenloaichiphi)
        Me.GrpNhaploaichiphi.Controls.Add(Me.LblTenloaichiphi)
        Me.GrpNhaploaichiphi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhaploaichiphi.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhaploaichiphi.Location = New System.Drawing.Point(59, 40)
        Me.GrpNhaploaichiphi.Name = "GrpNhaploaichiphi"
        Me.GrpNhaploaichiphi.Size = New System.Drawing.Size(566, 85)
        Me.GrpNhaploaichiphi.TabIndex = 35
        Me.GrpNhaploaichiphi.TabStop = False
        Me.GrpNhaploaichiphi.Text = "Nhập loại chi phí"
        '
        'txtGhichu
        '
        Me.txtGhichu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGhichu.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtGhichu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtGhichu.ErrorProviderControl = Me.ErrorProvider
        Me.txtGhichu.FieldName = ""
        Me.txtGhichu.IsNull = True
        Me.txtGhichu.Location = New System.Drawing.Point(108, 47)
        Me.txtGhichu.MaxLength = 0
        Me.txtGhichu.Multiline = False
        Me.txtGhichu.Name = "txtGhichu"
        Me.txtGhichu.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtGhichu.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtGhichu.Properties.Appearance.Options.UseBackColor = True
        Me.txtGhichu.Properties.Appearance.Options.UseTextOptions = True
        Me.txtGhichu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtGhichu.Properties.ReadOnly = True
        Me.txtGhichu.ReadOnly = True
        Me.txtGhichu.Size = New System.Drawing.Size(443, 20)
        Me.txtGhichu.TabIndex = 2
        Me.txtGhichu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtGhichu.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'LblGhichu
        '
        Me.LblGhichu.AutoSize = True
        Me.LblGhichu.ForeColor = System.Drawing.Color.Black
        Me.LblGhichu.Location = New System.Drawing.Point(10, 50)
        Me.LblGhichu.Name = "LblGhichu"
        Me.LblGhichu.Size = New System.Drawing.Size(48, 14)
        Me.LblGhichu.TabIndex = 35
        Me.LblGhichu.Text = "Ghi chú"
        '
        'TxtTenloaichiphi
        '
        Me.TxtTenloaichiphi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTenloaichiphi.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtTenloaichiphi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtTenloaichiphi.ErrorProviderControl = Me.ErrorProvider
        Me.TxtTenloaichiphi.FieldName = ""
        Me.TxtTenloaichiphi.IsNull = False
        Me.TxtTenloaichiphi.Location = New System.Drawing.Point(108, 20)
        Me.TxtTenloaichiphi.MaxLength = 0
        Me.TxtTenloaichiphi.Multiline = False
        Me.TxtTenloaichiphi.Name = "TxtTenloaichiphi"
        Me.TxtTenloaichiphi.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtTenloaichiphi.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtTenloaichiphi.Properties.Appearance.Options.UseBackColor = True
        Me.TxtTenloaichiphi.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtTenloaichiphi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TxtTenloaichiphi.Properties.ReadOnly = True
        Me.TxtTenloaichiphi.ReadOnly = True
        Me.TxtTenloaichiphi.Size = New System.Drawing.Size(443, 20)
        Me.TxtTenloaichiphi.TabIndex = 1
        Me.TxtTenloaichiphi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtTenloaichiphi.TextTypeMode = Commons.TypeMode.None
        '
        'LblTenloaichiphi
        '
        Me.LblTenloaichiphi.AutoSize = True
        Me.LblTenloaichiphi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTenloaichiphi.ForeColor = System.Drawing.Color.Black
        Me.LblTenloaichiphi.Location = New System.Drawing.Point(10, 23)
        Me.LblTenloaichiphi.Name = "LblTenloaichiphi"
        Me.LblTenloaichiphi.Size = New System.Drawing.Size(76, 14)
        Me.LblTenloaichiphi.TabIndex = 5
        Me.LblTenloaichiphi.Text = "Loại chi phí"
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(250, 426)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 4
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(460, 426)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 8
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(565, 426)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 9
        Me.BtnKhongghi.Text = "&Không"
        '
        'LblTieudeloaichiphi
        '
        Me.LblTieudeloaichiphi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTieudeloaichiphi.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.LblTieudeloaichiphi.ForeColor = System.Drawing.Color.Navy
        Me.LblTieudeloaichiphi.Location = New System.Drawing.Point(12, 3)
        Me.LblTieudeloaichiphi.Name = "LblTieudeloaichiphi"
        Me.LblTieudeloaichiphi.Size = New System.Drawing.Size(659, 27)
        Me.LblTieudeloaichiphi.TabIndex = 42
        Me.LblTieudeloaichiphi.Text = "LOAÏI CHI PHÍ"
        Me.LblTieudeloaichiphi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtMaso
        '
        Me.TxtMaso.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtMaso.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtMaso.ErrorProviderControl = Nothing
        Me.TxtMaso.FieldName = ""
        Me.TxtMaso.IsNull = True
        Me.TxtMaso.Location = New System.Drawing.Point(15, 12)
        Me.TxtMaso.MaxLength = 0
        Me.TxtMaso.Multiline = False
        Me.TxtMaso.Name = "TxtMaso"
        Me.TxtMaso.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtMaso.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtMaso.Properties.Appearance.Options.UseBackColor = True
        Me.TxtMaso.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtMaso.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TxtMaso.Properties.ReadOnly = True
        Me.TxtMaso.ReadOnly = True
        Me.TxtMaso.Size = New System.Drawing.Size(14, 20)
        Me.TxtMaso.TabIndex = 33
        Me.TxtMaso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtMaso.TextTypeMode = Commons.TypeMode.None
        Me.TxtMaso.Visible = False
        '
        'frmLoaichiphi
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 461)
        Me.Controls.Add(Me.LblTieudeloaichiphi)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.TxtMaso)
        Me.Controls.Add(Me.GrpDanhsachloaichiphi)
        Me.Controls.Add(Me.GrpNhaploaichiphi)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmLoaichiphi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loại chi phí"
        Me.GrpDanhsachloaichiphi.ResumeLayout(False)
        CType(Me.GrdDanhsachloaichiphi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhaploaichiphi.ResumeLayout(False)
        Me.GrpNhaploaichiphi.PerformLayout()
        CType(Me.txtGhichu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTenloaichiphi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMaso.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhsachloaichiphi As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhsachloaichiphi As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhaploaichiphi As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTenloaichiphi As Commons.utcTextBox
    Friend WithEvents TxtMaso As Commons.utcTextBox
    Friend WithEvents LblTenloaichiphi As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LblTieudeloaichiphi As System.Windows.Forms.Label
    Friend WithEvents txtGhichu As Commons.utcTextBox
    Friend WithEvents LblGhichu As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
End Class
