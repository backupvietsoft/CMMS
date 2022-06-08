<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLyDo
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblTEN_BP_GSTT_TH = New System.Windows.Forms.Label()
        Me.LblTieude = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTEN_BP_GSTT_TA = New System.Windows.Forms.Label()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsachlydosuachua = New System.Windows.Forms.GroupBox()
        Me.GrdDanhsachlydosuachua = New System.Windows.Forms.DataGridView()
        Me.GrpNhaplydosuachua = New System.Windows.Forms.GroupBox()
        Me.txtTEN_BP_GSTT_TH = New Commons.utcTextBox()
        Me.txtTEN_BP_GSTT_TA = New Commons.utcTextBox()
        Me.txtTEN_BP_GSTT_TV = New Commons.utcTextBox()
        Me.lblTEN_BP_GSTT_TV = New System.Windows.Forms.Label()
        Me.Txt_STT = New Commons.utcTextBox()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDanhsachlydosuachua.SuspendLayout()
        CType(Me.GrdDanhsachlydosuachua, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhaplydosuachua.SuspendLayout()
        CType(Me.txtTEN_BP_GSTT_TH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTEN_BP_GSTT_TA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTEN_BP_GSTT_TV.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_STT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'lblTEN_BP_GSTT_TH
        '
        Me.lblTEN_BP_GSTT_TH.AutoSize = True
        Me.lblTEN_BP_GSTT_TH.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTEN_BP_GSTT_TH.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblTEN_BP_GSTT_TH.ForeColor = System.Drawing.Color.Black
        Me.lblTEN_BP_GSTT_TH.Location = New System.Drawing.Point(13, 72)
        Me.lblTEN_BP_GSTT_TH.Name = "lblTEN_BP_GSTT_TH"
        Me.lblTEN_BP_GSTT_TH.Size = New System.Drawing.Size(86, 14)
        Me.lblTEN_BP_GSTT_TH.TabIndex = 8
        Me.lblTEN_BP_GSTT_TH.Text = "Tên tiếng Hoa"
        '
        'LblTieude
        '
        Me.LblTieude.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTieude.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.LblTieude.ForeColor = System.Drawing.Color.Navy
        Me.LblTieude.Location = New System.Drawing.Point(4, 7)
        Me.LblTieude.Name = "LblTieude"
        Me.LblTieude.Size = New System.Drawing.Size(679, 29)
        Me.LblTieude.TabIndex = 53
        Me.LblTieude.Text = "LÝ DO SỬA CHỮA"
        Me.LblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(351, 458)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 45
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = True
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(595, 458)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 50
        Me.BtnKhongghi.Text = "&Không"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(514, 458)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 49
        Me.BtnGhi.Text = "&Ghi"
        '
        'lblTEN_BP_GSTT_TA
        '
        Me.lblTEN_BP_GSTT_TA.AutoSize = True
        Me.lblTEN_BP_GSTT_TA.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblTEN_BP_GSTT_TA.ForeColor = System.Drawing.Color.Black
        Me.lblTEN_BP_GSTT_TA.Location = New System.Drawing.Point(13, 48)
        Me.lblTEN_BP_GSTT_TA.Name = "lblTEN_BP_GSTT_TA"
        Me.lblTEN_BP_GSTT_TA.Size = New System.Drawing.Size(87, 14)
        Me.lblTEN_BP_GSTT_TA.TabIndex = 6
        Me.lblTEN_BP_GSTT_TA.Text = "Tên tiếng Anh"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Appearance.Options.UseFont = True
        Me.BtnThoat.Location = New System.Drawing.Point(595, 458)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 48
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(514, 458)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 47
        Me.BtnXoa.Text = "&Xóa"
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(433, 458)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(81, 25)
        Me.BtnSua.TabIndex = 46
        Me.BtnSua.Text = "&Sửa"
        '
        'GrpDanhsachlydosuachua
        '
        Me.GrpDanhsachlydosuachua.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhsachlydosuachua.Controls.Add(Me.GrdDanhsachlydosuachua)
        Me.GrpDanhsachlydosuachua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhsachlydosuachua.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsachlydosuachua.Location = New System.Drawing.Point(10, 156)
        Me.GrpDanhsachlydosuachua.Name = "GrpDanhsachlydosuachua"
        Me.GrpDanhsachlydosuachua.Size = New System.Drawing.Size(666, 296)
        Me.GrpDanhsachlydosuachua.TabIndex = 52
        Me.GrpDanhsachlydosuachua.TabStop = False
        Me.GrpDanhsachlydosuachua.Text = "Danh sách lý do sửa chữa"
        '
        'GrdDanhsachlydosuachua
        '
        Me.GrdDanhsachlydosuachua.AllowUserToAddRows = False
        Me.GrdDanhsachlydosuachua.AllowUserToDeleteRows = False
        Me.GrdDanhsachlydosuachua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhsachlydosuachua.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.GrdDanhsachlydosuachua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhsachlydosuachua.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhsachlydosuachua.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.GrdDanhsachlydosuachua.Location = New System.Drawing.Point(3, 18)
        Me.GrdDanhsachlydosuachua.MultiSelect = False
        Me.GrdDanhsachlydosuachua.Name = "GrdDanhsachlydosuachua"
        Me.GrdDanhsachlydosuachua.ReadOnly = True
        Me.GrdDanhsachlydosuachua.RowHeadersWidth = 25
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.Format = "N2"
        Me.GrdDanhsachlydosuachua.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GrdDanhsachlydosuachua.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrdDanhsachlydosuachua.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrdDanhsachlydosuachua.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrdDanhsachlydosuachua.Size = New System.Drawing.Size(660, 275)
        Me.GrdDanhsachlydosuachua.TabIndex = 3
        '
        'GrpNhaplydosuachua
        '
        Me.GrpNhaplydosuachua.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhaplydosuachua.Controls.Add(Me.txtTEN_BP_GSTT_TH)
        Me.GrpNhaplydosuachua.Controls.Add(Me.lblTEN_BP_GSTT_TH)
        Me.GrpNhaplydosuachua.Controls.Add(Me.txtTEN_BP_GSTT_TA)
        Me.GrpNhaplydosuachua.Controls.Add(Me.lblTEN_BP_GSTT_TA)
        Me.GrpNhaplydosuachua.Controls.Add(Me.txtTEN_BP_GSTT_TV)
        Me.GrpNhaplydosuachua.Controls.Add(Me.lblTEN_BP_GSTT_TV)
        Me.GrpNhaplydosuachua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhaplydosuachua.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhaplydosuachua.Location = New System.Drawing.Point(148, 44)
        Me.GrpNhaplydosuachua.Name = "GrpNhaplydosuachua"
        Me.GrpNhaplydosuachua.Size = New System.Drawing.Size(390, 101)
        Me.GrpNhaplydosuachua.TabIndex = 51
        Me.GrpNhaplydosuachua.TabStop = False
        Me.GrpNhaplydosuachua.Text = "Nhập lý do sửa chữa"
        '
        'txtTEN_BP_GSTT_TH
        '
        Me.txtTEN_BP_GSTT_TH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTEN_BP_GSTT_TH.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_BP_GSTT_TH.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTEN_BP_GSTT_TH.ErrorProviderControl = Me.ErrorProvider
        Me.txtTEN_BP_GSTT_TH.FieldName = ""
        Me.txtTEN_BP_GSTT_TH.IsNull = True
        Me.txtTEN_BP_GSTT_TH.Location = New System.Drawing.Point(131, 69)
        Me.txtTEN_BP_GSTT_TH.MaxLength = 0
        Me.txtTEN_BP_GSTT_TH.Multiline = False
        Me.txtTEN_BP_GSTT_TH.Name = "txtTEN_BP_GSTT_TH"
        Me.txtTEN_BP_GSTT_TH.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_BP_GSTT_TH.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_BP_GSTT_TH.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_BP_GSTT_TH.ReadOnly = True
        Me.txtTEN_BP_GSTT_TH.Size = New System.Drawing.Size(247, 20)
        Me.txtTEN_BP_GSTT_TH.TabIndex = 2
        Me.txtTEN_BP_GSTT_TH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_BP_GSTT_TH.TextTypeMode = Commons.TypeMode.None
        '
        'txtTEN_BP_GSTT_TA
        '
        Me.txtTEN_BP_GSTT_TA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTEN_BP_GSTT_TA.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_BP_GSTT_TA.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTEN_BP_GSTT_TA.ErrorProviderControl = Me.ErrorProvider
        Me.txtTEN_BP_GSTT_TA.FieldName = ""
        Me.txtTEN_BP_GSTT_TA.IsNull = True
        Me.txtTEN_BP_GSTT_TA.Location = New System.Drawing.Point(131, 45)
        Me.txtTEN_BP_GSTT_TA.MaxLength = 0
        Me.txtTEN_BP_GSTT_TA.Multiline = False
        Me.txtTEN_BP_GSTT_TA.Name = "txtTEN_BP_GSTT_TA"
        Me.txtTEN_BP_GSTT_TA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_BP_GSTT_TA.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_BP_GSTT_TA.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_BP_GSTT_TA.ReadOnly = True
        Me.txtTEN_BP_GSTT_TA.Size = New System.Drawing.Size(247, 20)
        Me.txtTEN_BP_GSTT_TA.TabIndex = 1
        Me.txtTEN_BP_GSTT_TA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_BP_GSTT_TA.TextTypeMode = Commons.TypeMode.None
        '
        'txtTEN_BP_GSTT_TV
        '
        Me.txtTEN_BP_GSTT_TV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTEN_BP_GSTT_TV.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_BP_GSTT_TV.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTEN_BP_GSTT_TV.ErrorProviderControl = Me.ErrorProvider
        Me.txtTEN_BP_GSTT_TV.FieldName = ""
        Me.txtTEN_BP_GSTT_TV.IsNull = False
        Me.txtTEN_BP_GSTT_TV.Location = New System.Drawing.Point(131, 21)
        Me.txtTEN_BP_GSTT_TV.MaxLength = 0
        Me.txtTEN_BP_GSTT_TV.Multiline = False
        Me.txtTEN_BP_GSTT_TV.Name = "txtTEN_BP_GSTT_TV"
        Me.txtTEN_BP_GSTT_TV.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_BP_GSTT_TV.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_BP_GSTT_TV.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_BP_GSTT_TV.ReadOnly = True
        Me.txtTEN_BP_GSTT_TV.Size = New System.Drawing.Size(247, 20)
        Me.txtTEN_BP_GSTT_TV.TabIndex = 0
        Me.txtTEN_BP_GSTT_TV.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_BP_GSTT_TV.TextTypeMode = Commons.TypeMode.None
        '
        'lblTEN_BP_GSTT_TV
        '
        Me.lblTEN_BP_GSTT_TV.AutoSize = True
        Me.lblTEN_BP_GSTT_TV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTEN_BP_GSTT_TV.ForeColor = System.Drawing.Color.Black
        Me.lblTEN_BP_GSTT_TV.Location = New System.Drawing.Point(13, 24)
        Me.lblTEN_BP_GSTT_TV.Name = "lblTEN_BP_GSTT_TV"
        Me.lblTEN_BP_GSTT_TV.Size = New System.Drawing.Size(93, 14)
        Me.lblTEN_BP_GSTT_TV.TabIndex = 5
        Me.lblTEN_BP_GSTT_TV.Text = "Tên tiếng Việt"
        '
        'Txt_STT
        '
        Me.Txt_STT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Txt_STT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Txt_STT.ErrorProviderControl = Me.ErrorProvider
        Me.Txt_STT.FieldName = ""
        Me.Txt_STT.IsNull = True
        Me.Txt_STT.Location = New System.Drawing.Point(12, 77)
        Me.Txt_STT.MaxLength = 0
        Me.Txt_STT.Multiline = False
        Me.Txt_STT.Name = "Txt_STT"
        Me.Txt_STT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Txt_STT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.Txt_STT.Properties.Appearance.Options.UseBackColor = True
        Me.Txt_STT.ReadOnly = True
        Me.Txt_STT.Size = New System.Drawing.Size(13, 20)
        Me.Txt_STT.TabIndex = 54
        Me.Txt_STT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Txt_STT.TextTypeMode = Commons.TypeMode.None
        Me.Txt_STT.Visible = False
        '
        'FrmLyDo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 485)
        Me.Controls.Add(Me.Txt_STT)
        Me.Controls.Add(Me.LblTieude)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.GrpDanhsachlydosuachua)
        Me.Controls.Add(Me.GrpNhaplydosuachua)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.Controls.Add(Me.BtnGhi)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmLyDo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLyDo"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDanhsachlydosuachua.ResumeLayout(False)
        CType(Me.GrdDanhsachlydosuachua, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhaplydosuachua.ResumeLayout(False)
        Me.GrpNhaplydosuachua.PerformLayout()
        CType(Me.txtTEN_BP_GSTT_TH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTEN_BP_GSTT_TA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTEN_BP_GSTT_TV.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_STT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTEN_BP_GSTT_TH As Commons.utcTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Txt_STT As Commons.utcTextBox
    Friend WithEvents LblTieude As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhsachlydosuachua As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhsachlydosuachua As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhaplydosuachua As System.Windows.Forms.GroupBox
    Friend WithEvents lblTEN_BP_GSTT_TH As System.Windows.Forms.Label
    Friend WithEvents txtTEN_BP_GSTT_TA As Commons.utcTextBox
    Friend WithEvents lblTEN_BP_GSTT_TA As System.Windows.Forms.Label
    Friend WithEvents txtTEN_BP_GSTT_TV As Commons.utcTextBox
    Friend WithEvents lblTEN_BP_GSTT_TV As System.Windows.Forms.Label
End Class
