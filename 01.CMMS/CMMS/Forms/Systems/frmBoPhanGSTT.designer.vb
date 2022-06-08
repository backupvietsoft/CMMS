<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoPhanGSTT
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
        Me.BtnSua = New System.Windows.Forms.Button()
        Me.BtnThoat = New System.Windows.Forms.Button()
        Me.BtnXoa = New System.Windows.Forms.Button()
        Me.GrpDanhsachBoPhanGSTT = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GrdDanhmucBoPhanGSTT = New System.Windows.Forms.DataGridView()
        Me.GrpNhapBoPhanGSTT = New System.Windows.Forms.GroupBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblTEN_BP_GSTT_TA = New System.Windows.Forms.Label()
        Me.lblTEN_BP_GSTT_TV = New System.Windows.Forms.Label()
        Me.BtnThem = New System.Windows.Forms.Button()
        Me.BtnGhi = New System.Windows.Forms.Button()
        Me.BtnKhongghi = New System.Windows.Forms.Button()
        Me.LblTieudeBoPhanGSTT = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtTEN_BP_GSTT_TA = New Commons.utcTextBox()
        Me.txtTEN_BP_GSTT_TV = New Commons.utcTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtMS_BP_GSTT = New Commons.utcTextBox()
        Me.GrpDanhsachBoPhanGSTT.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.GrdDanhmucBoPhanGSTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.txtTEN_BP_GSTT_TA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTEN_BP_GSTT_TV.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtMS_BP_GSTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSua
        '
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnSua.Location = New System.Drawing.Point(296, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(98, 30)
        Me.BtnSua.TabIndex = 5
        Me.BtnSua.Text = "&Sửa"
        Me.BtnSua.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Red
        Me.BtnThoat.Location = New System.Drawing.Point(688, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(98, 30)
        Me.BtnThoat.TabIndex = 7
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnXoa.Location = New System.Drawing.Point(394, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(98, 30)
        Me.BtnXoa.TabIndex = 6
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'GrpDanhsachBoPhanGSTT
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpDanhsachBoPhanGSTT, 2)
        Me.GrpDanhsachBoPhanGSTT.Controls.Add(Me.TableLayoutPanel2)
        Me.GrpDanhsachBoPhanGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpDanhsachBoPhanGSTT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhsachBoPhanGSTT.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsachBoPhanGSTT.Location = New System.Drawing.Point(3, 99)
        Me.GrpDanhsachBoPhanGSTT.Name = "GrpDanhsachBoPhanGSTT"
        Me.GrpDanhsachBoPhanGSTT.Size = New System.Drawing.Size(786, 384)
        Me.GrpDanhsachBoPhanGSTT.TabIndex = 36
        Me.GrpDanhsachBoPhanGSTT.TabStop = False
        Me.GrpDanhsachBoPhanGSTT.Text = "Danh sách bộ phận giám sát tình trạng"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GrdDanhmucBoPhanGSTT, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(780, 363)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'GrdDanhmucBoPhanGSTT
        '
        Me.GrdDanhmucBoPhanGSTT.AllowUserToAddRows = False
        Me.GrdDanhmucBoPhanGSTT.AllowUserToDeleteRows = False
        Me.GrdDanhmucBoPhanGSTT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhmucBoPhanGSTT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhmucBoPhanGSTT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhmucBoPhanGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhmucBoPhanGSTT.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.GrdDanhmucBoPhanGSTT.Location = New System.Drawing.Point(3, 6)
        Me.GrdDanhmucBoPhanGSTT.MultiSelect = False
        Me.GrdDanhmucBoPhanGSTT.Name = "GrdDanhmucBoPhanGSTT"
        Me.GrdDanhmucBoPhanGSTT.ReadOnly = True
        Me.GrdDanhmucBoPhanGSTT.RowHeadersWidth = 25
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhmucBoPhanGSTT.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.GrdDanhmucBoPhanGSTT.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrdDanhmucBoPhanGSTT.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrdDanhmucBoPhanGSTT.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrdDanhmucBoPhanGSTT.Size = New System.Drawing.Size(774, 354)
        Me.GrdDanhmucBoPhanGSTT.TabIndex = 3
        '
        'GrpNhapBoPhanGSTT
        '
        Me.GrpNhapBoPhanGSTT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapBoPhanGSTT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapBoPhanGSTT.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapBoPhanGSTT.Location = New System.Drawing.Point(49, 44)
        Me.GrpNhapBoPhanGSTT.Name = "GrpNhapBoPhanGSTT"
        Me.GrpNhapBoPhanGSTT.Size = New System.Drawing.Size(695, 81)
        Me.GrpNhapBoPhanGSTT.TabIndex = 35
        Me.GrpNhapBoPhanGSTT.TabStop = False
        Me.GrpNhapBoPhanGSTT.Text = "Nhập bộ phận giám sát tình trạng"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'lblTEN_BP_GSTT_TA
        '
        Me.lblTEN_BP_GSTT_TA.AutoSize = True
        Me.lblTEN_BP_GSTT_TA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTEN_BP_GSTT_TA.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblTEN_BP_GSTT_TA.ForeColor = System.Drawing.Color.Black
        Me.lblTEN_BP_GSTT_TA.Location = New System.Drawing.Point(3, 71)
        Me.lblTEN_BP_GSTT_TA.Name = "lblTEN_BP_GSTT_TA"
        Me.lblTEN_BP_GSTT_TA.Size = New System.Drawing.Size(244, 25)
        Me.lblTEN_BP_GSTT_TA.TabIndex = 6
        Me.lblTEN_BP_GSTT_TA.Text = "Tên tiếng Anh"
        Me.lblTEN_BP_GSTT_TA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTEN_BP_GSTT_TV
        '
        Me.lblTEN_BP_GSTT_TV.AutoSize = True
        Me.lblTEN_BP_GSTT_TV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTEN_BP_GSTT_TV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTEN_BP_GSTT_TV.ForeColor = System.Drawing.Color.Black
        Me.lblTEN_BP_GSTT_TV.Location = New System.Drawing.Point(3, 46)
        Me.lblTEN_BP_GSTT_TV.Name = "lblTEN_BP_GSTT_TV"
        Me.lblTEN_BP_GSTT_TV.Size = New System.Drawing.Size(244, 25)
        Me.lblTEN_BP_GSTT_TV.TabIndex = 5
        Me.lblTEN_BP_GSTT_TV.Text = "Tên tiếng Việt"
        Me.lblTEN_BP_GSTT_TV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnThem
        '
        Me.BtnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnThem.Location = New System.Drawing.Point(198, 0)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(98, 30)
        Me.BtnThem.TabIndex = 4
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnGhi.Location = New System.Drawing.Point(492, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(98, 30)
        Me.BtnGhi.TabIndex = 8
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(590, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(98, 30)
        Me.BtnKhongghi.TabIndex = 9
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'LblTieudeBoPhanGSTT
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.LblTieudeBoPhanGSTT, 2)
        Me.LblTieudeBoPhanGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTieudeBoPhanGSTT.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieudeBoPhanGSTT.ForeColor = System.Drawing.Color.Black
        Me.LblTieudeBoPhanGSTT.Location = New System.Drawing.Point(3, 0)
        Me.LblTieudeBoPhanGSTT.Name = "LblTieudeBoPhanGSTT"
        Me.LblTieudeBoPhanGSTT.Size = New System.Drawing.Size(786, 46)
        Me.LblTieudeBoPhanGSTT.TabIndex = 43
        Me.LblTieudeBoPhanGSTT.Text = "BỘ PHẬN GIÁM SÁT TÌNH TRẠNG"
        Me.LblTieudeBoPhanGSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtTEN_BP_GSTT_TA, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LblTieudeBoPhanGSTT, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTEN_BP_GSTT_TV, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpDanhsachBoPhanGSTT, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTEN_BP_GSTT_TA, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTEN_BP_GSTT_TV, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(792, 522)
        Me.TableLayoutPanel1.TabIndex = 45
        '
        'txtTEN_BP_GSTT_TA
        '
        Me.txtTEN_BP_GSTT_TA.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_BP_GSTT_TA.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTEN_BP_GSTT_TA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTEN_BP_GSTT_TA.ErrorProviderControl = Me.ErrorProvider
        Me.txtTEN_BP_GSTT_TA.FieldName = ""
        Me.txtTEN_BP_GSTT_TA.IsNull = True
        Me.txtTEN_BP_GSTT_TA.Location = New System.Drawing.Point(253, 74)
        Me.txtTEN_BP_GSTT_TA.MaxLength = 0
        Me.txtTEN_BP_GSTT_TA.Multiline = False
        Me.txtTEN_BP_GSTT_TA.Name = "txtTEN_BP_GSTT_TA"
        Me.txtTEN_BP_GSTT_TA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_BP_GSTT_TA.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_BP_GSTT_TA.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_BP_GSTT_TA.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTEN_BP_GSTT_TA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTEN_BP_GSTT_TA.Properties.ReadOnly = True
        Me.txtTEN_BP_GSTT_TA.ReadOnly = True
        Me.txtTEN_BP_GSTT_TA.Size = New System.Drawing.Size(536, 20)
        Me.txtTEN_BP_GSTT_TA.TabIndex = 1
        Me.txtTEN_BP_GSTT_TA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_BP_GSTT_TA.TextTypeMode = Commons.TypeMode.None
        '
        'txtTEN_BP_GSTT_TV
        '
        Me.txtTEN_BP_GSTT_TV.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_BP_GSTT_TV.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTEN_BP_GSTT_TV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTEN_BP_GSTT_TV.ErrorProviderControl = Me.ErrorProvider
        Me.txtTEN_BP_GSTT_TV.FieldName = ""
        Me.txtTEN_BP_GSTT_TV.IsNull = False
        Me.txtTEN_BP_GSTT_TV.Location = New System.Drawing.Point(253, 49)
        Me.txtTEN_BP_GSTT_TV.MaxLength = 0
        Me.txtTEN_BP_GSTT_TV.Multiline = False
        Me.txtTEN_BP_GSTT_TV.Name = "txtTEN_BP_GSTT_TV"
        Me.txtTEN_BP_GSTT_TV.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_BP_GSTT_TV.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_BP_GSTT_TV.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_BP_GSTT_TV.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTEN_BP_GSTT_TV.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTEN_BP_GSTT_TV.Properties.ReadOnly = True
        Me.txtTEN_BP_GSTT_TV.ReadOnly = True
        Me.txtTEN_BP_GSTT_TV.Size = New System.Drawing.Size(536, 20)
        Me.txtTEN_BP_GSTT_TV.TabIndex = 0
        Me.txtTEN_BP_GSTT_TV.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_BP_GSTT_TV.TextTypeMode = Commons.TypeMode.None
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Location = New System.Drawing.Point(3, 489)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 30)
        Me.Panel1.TabIndex = 44
        '
        'TxtMS_BP_GSTT
        '
        Me.TxtMS_BP_GSTT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtMS_BP_GSTT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtMS_BP_GSTT.ErrorProviderControl = Me.ErrorProvider
        Me.TxtMS_BP_GSTT.FieldName = ""
        Me.TxtMS_BP_GSTT.IsNull = True
        Me.TxtMS_BP_GSTT.Location = New System.Drawing.Point(12, 12)
        Me.TxtMS_BP_GSTT.MaxLength = 0
        Me.TxtMS_BP_GSTT.Multiline = False
        Me.TxtMS_BP_GSTT.Name = "TxtMS_BP_GSTT"
        Me.TxtMS_BP_GSTT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtMS_BP_GSTT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtMS_BP_GSTT.Properties.Appearance.Options.UseBackColor = True
        Me.TxtMS_BP_GSTT.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtMS_BP_GSTT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TxtMS_BP_GSTT.Properties.ReadOnly = True
        Me.TxtMS_BP_GSTT.ReadOnly = True
        Me.TxtMS_BP_GSTT.Size = New System.Drawing.Size(81, 20)
        Me.TxtMS_BP_GSTT.TabIndex = 44
        Me.TxtMS_BP_GSTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtMS_BP_GSTT.TextTypeMode = Commons.TypeMode.None
        Me.TxtMS_BP_GSTT.Visible = False
        '
        'frmBoPhanGSTT
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 522)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TxtMS_BP_GSTT)
        Me.Controls.Add(Me.GrpNhapBoPhanGSTT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(798, 550)
        Me.Name = "frmBoPhanGSTT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bộ phận giám sát tình trạng"
        Me.GrpDanhsachBoPhanGSTT.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.GrdDanhmucBoPhanGSTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.txtTEN_BP_GSTT_TA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTEN_BP_GSTT_TV.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.TxtMS_BP_GSTT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSua As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents GrpDanhsachBoPhanGSTT As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhmucBoPhanGSTT As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhapBoPhanGSTT As System.Windows.Forms.GroupBox
    Friend WithEvents lblTEN_BP_GSTT_TV As System.Windows.Forms.Label
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents txtTEN_BP_GSTT_TV As Commons.utcTextBox
    Friend WithEvents LblTieudeBoPhanGSTT As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtTEN_BP_GSTT_TA As Commons.utcTextBox
    Friend WithEvents lblTEN_BP_GSTT_TA As System.Windows.Forms.Label
    Friend WithEvents TxtMS_BP_GSTT As Commons.utcTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
End Class
