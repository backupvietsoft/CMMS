<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGiatrithongsoGSTT
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LblTieudeGiatriTSGSTT = New System.Windows.Forms.Label()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsachTSGSTT = New System.Windows.Forms.GroupBox()
        Me.grdDanhsachgiatriTSGSTT = New System.Windows.Forms.DataGridView()
        Me.GrpNhapthongsoGSTT = New System.Windows.Forms.GroupBox()
        Me.chkDat = New System.Windows.Forms.CheckBox()
        Me.txtGhichu = New Commons.utcTextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblGhichu = New System.Windows.Forms.Label()
        Me.lblMaTSGSTT = New System.Windows.Forms.Label()
        Me.cboTHONG_SO_GSTT = New Commons.UtcComboBox()
        Me.txtGiatri = New Commons.utcTextBox()
        Me.lblgiatri = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSoTT = New Commons.utcTextBox()
        Me.GrpDanhsachTSGSTT.SuspendLayout()
        CType(Me.grdDanhsachgiatriTSGSTT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhapthongsoGSTT.SuspendLayout()
        CType(Me.txtGhichu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGiatri.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSoTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTieudeGiatriTSGSTT
        '
        Me.LblTieudeGiatriTSGSTT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTieudeGiatriTSGSTT.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.LblTieudeGiatriTSGSTT.ForeColor = System.Drawing.Color.Navy
        Me.LblTieudeGiatriTSGSTT.Location = New System.Drawing.Point(14, 9)
        Me.LblTieudeGiatriTSGSTT.Name = "LblTieudeGiatriTSGSTT"
        Me.LblTieudeGiatriTSGSTT.Size = New System.Drawing.Size(709, 29)
        Me.LblTieudeGiatriTSGSTT.TabIndex = 87
        Me.LblTieudeGiatriTSGSTT.Text = "GIÁ TRỊ THÔNG SỐ GSTT"
        Me.LblTieudeGiatriTSGSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(480, 423)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(81, 25)
        Me.BtnSua.TabIndex = 7
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Appearance.Options.UseFont = True
        Me.BtnThoat.Location = New System.Drawing.Point(642, 423)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 9
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(561, 423)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 8
        Me.BtnXoa.Text = "&Xóa"
        '
        'GrpDanhsachTSGSTT
        '
        Me.GrpDanhsachTSGSTT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhsachTSGSTT.Controls.Add(Me.grdDanhsachgiatriTSGSTT)
        Me.GrpDanhsachTSGSTT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhsachTSGSTT.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsachTSGSTT.Location = New System.Drawing.Point(11, 137)
        Me.GrpDanhsachTSGSTT.Name = "GrpDanhsachTSGSTT"
        Me.GrpDanhsachTSGSTT.Size = New System.Drawing.Size(712, 280)
        Me.GrpDanhsachTSGSTT.TabIndex = 81
        Me.GrpDanhsachTSGSTT.TabStop = False
        Me.GrpDanhsachTSGSTT.Text = "Danh sách giá trị thông số GSTT"
        '
        'grdDanhsachgiatriTSGSTT
        '
        Me.grdDanhsachgiatriTSGSTT.AllowUserToAddRows = False
        Me.grdDanhsachgiatriTSGSTT.AllowUserToDeleteRows = False
        Me.grdDanhsachgiatriTSGSTT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDanhsachgiatriTSGSTT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachgiatriTSGSTT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachgiatriTSGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachgiatriTSGSTT.Location = New System.Drawing.Point(3, 18)
        Me.grdDanhsachgiatriTSGSTT.Name = "grdDanhsachgiatriTSGSTT"
        Me.grdDanhsachgiatriTSGSTT.ReadOnly = True
        Me.grdDanhsachgiatriTSGSTT.RowHeadersWidth = 25
        Me.grdDanhsachgiatriTSGSTT.ShowEditingIcon = False
        Me.grdDanhsachgiatriTSGSTT.Size = New System.Drawing.Size(706, 259)
        Me.grdDanhsachgiatriTSGSTT.TabIndex = 5
        '
        'GrpNhapthongsoGSTT
        '
        Me.GrpNhapthongsoGSTT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapthongsoGSTT.Controls.Add(Me.chkDat)
        Me.GrpNhapthongsoGSTT.Controls.Add(Me.txtGhichu)
        Me.GrpNhapthongsoGSTT.Controls.Add(Me.lblGhichu)
        Me.GrpNhapthongsoGSTT.Controls.Add(Me.lblMaTSGSTT)
        Me.GrpNhapthongsoGSTT.Controls.Add(Me.cboTHONG_SO_GSTT)
        Me.GrpNhapthongsoGSTT.Controls.Add(Me.txtGiatri)
        Me.GrpNhapthongsoGSTT.Controls.Add(Me.lblgiatri)
        Me.GrpNhapthongsoGSTT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapthongsoGSTT.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapthongsoGSTT.Location = New System.Drawing.Point(18, 46)
        Me.GrpNhapthongsoGSTT.Name = "GrpNhapthongsoGSTT"
        Me.GrpNhapthongsoGSTT.Size = New System.Drawing.Size(702, 85)
        Me.GrpNhapthongsoGSTT.TabIndex = 80
        Me.GrpNhapthongsoGSTT.TabStop = False
        Me.GrpNhapthongsoGSTT.Text = "Nhập thông số GSTT"
        '
        'chkDat
        '
        Me.chkDat.AutoSize = True
        Me.chkDat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDat.ForeColor = System.Drawing.Color.Black
        Me.chkDat.Location = New System.Drawing.Point(454, 24)
        Me.chkDat.Name = "chkDat"
        Me.chkDat.Size = New System.Drawing.Size(45, 18)
        Me.chkDat.TabIndex = 4
        Me.chkDat.Text = "Đạt"
        Me.chkDat.UseVisualStyleBackColor = True
        '
        'txtGhichu
        '
        Me.txtGhichu.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtGhichu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtGhichu.ErrorProviderControl = Me.ErrorProvider
        Me.txtGhichu.FieldName = ""
        Me.txtGhichu.IsNull = True
        Me.txtGhichu.Location = New System.Drawing.Point(216, 47)
        Me.txtGhichu.MaxLength = 0
        Me.txtGhichu.Multiline = False
        Me.txtGhichu.Name = "txtGhichu"
        Me.txtGhichu.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtGhichu.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtGhichu.Properties.Appearance.Options.UseBackColor = True
        Me.txtGhichu.ReadOnly = True
        Me.txtGhichu.Size = New System.Drawing.Size(283, 20)
        Me.txtGhichu.TabIndex = 3
        Me.txtGhichu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtGhichu.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'lblGhichu
        '
        Me.lblGhichu.AutoSize = True
        Me.lblGhichu.ForeColor = System.Drawing.Color.Black
        Me.lblGhichu.Location = New System.Drawing.Point(128, 50)
        Me.lblGhichu.Name = "lblGhichu"
        Me.lblGhichu.Size = New System.Drawing.Size(48, 14)
        Me.lblGhichu.TabIndex = 73
        Me.lblGhichu.Text = "Ghi chú"
        '
        'lblMaTSGSTT
        '
        Me.lblMaTSGSTT.AutoSize = True
        Me.lblMaTSGSTT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaTSGSTT.ForeColor = System.Drawing.Color.Black
        Me.lblMaTSGSTT.Location = New System.Drawing.Point(128, 25)
        Me.lblMaTSGSTT.Name = "lblMaTSGSTT"
        Me.lblMaTSGSTT.Size = New System.Drawing.Size(82, 14)
        Me.lblMaTSGSTT.TabIndex = 72
        Me.lblMaTSGSTT.Text = "Mã TS_GSTT"
        '
        'cboTHONG_SO_GSTT
        '
        Me.cboTHONG_SO_GSTT.AssemblyName = ""
        Me.cboTHONG_SO_GSTT.BackColor = System.Drawing.SystemColors.Window
        Me.cboTHONG_SO_GSTT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboTHONG_SO_GSTT.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboTHONG_SO_GSTT.ClassName = ""
        Me.cboTHONG_SO_GSTT.Display = ""
        Me.cboTHONG_SO_GSTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTHONG_SO_GSTT.ErrorProviderControl = Me.ErrorProvider
        Me.cboTHONG_SO_GSTT.FormattingEnabled = True
        Me.cboTHONG_SO_GSTT.IsAll = False
        Me.cboTHONG_SO_GSTT.isInputNull = False
        Me.cboTHONG_SO_GSTT.IsNew = True
        Me.cboTHONG_SO_GSTT.IsNull = True
        Me.cboTHONG_SO_GSTT.ItemAll = " < ALL > "
        Me.cboTHONG_SO_GSTT.ItemNew = "...New"
        Me.cboTHONG_SO_GSTT.Location = New System.Drawing.Point(216, 22)
        Me.cboTHONG_SO_GSTT.MethodName = ""
        Me.cboTHONG_SO_GSTT.Name = "cboTHONG_SO_GSTT"
        Me.cboTHONG_SO_GSTT.Param = ""
        Me.cboTHONG_SO_GSTT.Param2 = ""
        Me.cboTHONG_SO_GSTT.Size = New System.Drawing.Size(99, 22)
        Me.cboTHONG_SO_GSTT.StoreName = ""
        Me.cboTHONG_SO_GSTT.TabIndex = 1
        Me.cboTHONG_SO_GSTT.Table = Nothing
        Me.cboTHONG_SO_GSTT.TextReadonly = False
        Me.cboTHONG_SO_GSTT.Value = ""
        '
        'txtGiatri
        '
        Me.txtGiatri.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtGiatri.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtGiatri.ErrorProviderControl = Me.ErrorProvider
        Me.txtGiatri.FieldName = ""
        Me.txtGiatri.IsNull = False
        Me.txtGiatri.Location = New System.Drawing.Point(389, 22)
        Me.txtGiatri.MaxLength = 0
        Me.txtGiatri.Multiline = False
        Me.txtGiatri.Name = "txtGiatri"
        Me.txtGiatri.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtGiatri.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtGiatri.Properties.Appearance.Options.UseBackColor = True
        Me.txtGiatri.ReadOnly = True
        Me.txtGiatri.Size = New System.Drawing.Size(62, 20)
        Me.txtGiatri.TabIndex = 2
        Me.txtGiatri.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtGiatri.TextTypeMode = Commons.TypeMode.None
        '
        'lblgiatri
        '
        Me.lblgiatri.AutoSize = True
        Me.lblgiatri.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgiatri.ForeColor = System.Drawing.Color.Black
        Me.lblgiatri.Location = New System.Drawing.Point(340, 25)
        Me.lblgiatri.Name = "lblgiatri"
        Me.lblgiatri.Size = New System.Drawing.Size(43, 14)
        Me.lblgiatri.TabIndex = 5
        Me.lblgiatri.Text = "Giá trị"
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(398, 423)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 6
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(561, 423)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 10
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = True
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(642, 423)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 11
        Me.BtnKhongghi.Text = "&Không"
        '
        'txtSoTT
        '
        Me.txtSoTT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtSoTT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtSoTT.ErrorProviderControl = Me.ErrorProvider
        Me.txtSoTT.FieldName = ""
        Me.txtSoTT.IsNull = True
        Me.txtSoTT.Location = New System.Drawing.Point(442, 3)
        Me.txtSoTT.MaxLength = 0
        Me.txtSoTT.Multiline = False
        Me.txtSoTT.Name = "txtSoTT"
        Me.txtSoTT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSoTT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtSoTT.Properties.Appearance.Options.UseBackColor = True
        Me.txtSoTT.ReadOnly = True
        Me.txtSoTT.Size = New System.Drawing.Size(14, 20)
        Me.txtSoTT.TabIndex = 69
        Me.txtSoTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSoTT.TextTypeMode = Commons.TypeMode.None
        Me.txtSoTT.Visible = False
        '
        'frmGiatrithongsoGSTT
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.LblTieudeGiatriTSGSTT)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.GrpDanhsachTSGSTT)
        Me.Controls.Add(Me.GrpNhapthongsoGSTT)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.txtSoTT)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmGiatrithongsoGSTT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Giá trị thông số GSTT"
        Me.GrpDanhsachTSGSTT.ResumeLayout(False)
        CType(Me.grdDanhsachgiatriTSGSTT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhapthongsoGSTT.ResumeLayout(False)
        Me.GrpNhapthongsoGSTT.PerformLayout()
        CType(Me.txtGhichu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGiatri.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSoTT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblTieudeGiatriTSGSTT As System.Windows.Forms.Label
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhsachTSGSTT As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachgiatriTSGSTT As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhapthongsoGSTT As System.Windows.Forms.GroupBox
    Friend WithEvents chkDat As System.Windows.Forms.CheckBox
    Friend WithEvents txtGhichu As Commons.utcTextBox
    Friend WithEvents lblGhichu As System.Windows.Forms.Label
    Friend WithEvents lblMaTSGSTT As System.Windows.Forms.Label
    Friend WithEvents cboTHONG_SO_GSTT As Commons.UtcComboBox
    Friend WithEvents txtGiatri As Commons.utcTextBox
    Friend WithEvents txtSoTT As Commons.utcTextBox
    Friend WithEvents lblgiatri As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
End Class
