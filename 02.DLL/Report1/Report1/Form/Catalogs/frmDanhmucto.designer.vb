<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhmucto
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
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblTotruong = New System.Windows.Forms.Label()
        Me.grdDanhsachto = New System.Windows.Forms.DataGridView()
        Me.lblSoTT = New System.Windows.Forms.Label()
        Me.lblTento = New System.Windows.Forms.Label()
        Me.lblTieude = New System.Windows.Forms.Label()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.grpNhapdanhmucto = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtSTT_TO = New Commons.utcTextBox()
        Me.cboDON_VI = New Commons.UtcComboBox()
        Me.lblDonvi = New System.Windows.Forms.Label()
        Me.txtTO_TRUONG = New Commons.utcTextBox()
        Me.txtTEN_TO = New Commons.utcTextBox()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.grpDanhsachto = New System.Windows.Forms.GroupBox()
        Me.grpTo = New System.Windows.Forms.GroupBox()
        Me.grdTo = New System.Windows.Forms.DataGridView()
        Me.TEN_TO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnXoaphongban = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTrove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoato = New DevExpress.XtraEditors.SimpleButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtMS_TO = New Commons.utcTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDanhsachto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNhapdanhmucto.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.txtSTT_TO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTO_TRUONG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTEN_TO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachto.SuspendLayout()
        Me.grpTo.SuspendLayout()
        CType(Me.grdTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMS_TO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'lblTotruong
        '
        Me.lblTotruong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotruong.ForeColor = System.Drawing.Color.Black
        Me.lblTotruong.Location = New System.Drawing.Point(3, 28)
        Me.lblTotruong.Name = "lblTotruong"
        Me.lblTotruong.Size = New System.Drawing.Size(104, 29)
        Me.lblTotruong.TabIndex = 48
        Me.lblTotruong.Text = "Trưởng ban"
        Me.lblTotruong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdDanhsachto
        '
        Me.grdDanhsachto.AllowUserToAddRows = False
        Me.grdDanhsachto.AllowUserToDeleteRows = False
        Me.grdDanhsachto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDanhsachto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachto.Location = New System.Drawing.Point(3, 18)
        Me.grdDanhsachto.MultiSelect = False
        Me.grdDanhsachto.Name = "grdDanhsachto"
        Me.grdDanhsachto.ReadOnly = True
        Me.grdDanhsachto.RowHeadersWidth = 25
        Me.grdDanhsachto.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grdDanhsachto.ShowEditingIcon = False
        Me.grdDanhsachto.Size = New System.Drawing.Size(469, 275)
        Me.grdDanhsachto.TabIndex = 0
        '
        'lblSoTT
        '
        Me.lblSoTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSoTT.ForeColor = System.Drawing.Color.Black
        Me.lblSoTT.Location = New System.Drawing.Point(342, 28)
        Me.lblSoTT.Name = "lblSoTT"
        Me.lblSoTT.Size = New System.Drawing.Size(104, 29)
        Me.lblSoTT.TabIndex = 50
        Me.lblSoTT.Text = "Số TT"
        Me.lblSoTT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTento
        '
        Me.lblTento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTento.ForeColor = System.Drawing.Color.Black
        Me.lblTento.Location = New System.Drawing.Point(342, 0)
        Me.lblTento.Name = "lblTento"
        Me.lblTento.Size = New System.Drawing.Size(104, 28)
        Me.lblTento.TabIndex = 3
        Me.lblTento.Text = "Phòng ban"
        Me.lblTento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTieude
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieude, 4)
        Me.lblTieude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(3, 0)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(765, 35)
        Me.lblTieude.TabIndex = 60
        Me.lblTieude.Text = "DANH SÁCH TỔ PHÒN BAN"
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(603, 4)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(80, 27)
        Me.BtnGhi.TabIndex = 9
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = True
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(682, 4)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(80, 27)
        Me.BtnKhongghi.TabIndex = 10
        Me.BtnKhongghi.Text = "&Không"
        '
        'grpNhapdanhmucto
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpNhapdanhmucto, 2)
        Me.grpNhapdanhmucto.Controls.Add(Me.TableLayoutPanel2)
        Me.grpNhapdanhmucto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNhapdanhmucto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNhapdanhmucto.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhapdanhmucto.Location = New System.Drawing.Point(43, 38)
        Me.grpNhapdanhmucto.Name = "grpNhapdanhmucto"
        Me.grpNhapdanhmucto.Size = New System.Drawing.Size(684, 78)
        Me.grpNhapdanhmucto.TabIndex = 0
        Me.grpNhapdanhmucto.TabStop = False
        Me.grpNhapdanhmucto.Text = "Nhập phòng ban"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtSTT_TO, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboDON_VI, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSoTT, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDonvi, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTO_TRUONG, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTento, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTotruong, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTEN_TO, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(678, 57)
        Me.TableLayoutPanel2.TabIndex = 61
        '
        'txtSTT_TO
        '
        Me.txtSTT_TO.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtSTT_TO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtSTT_TO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSTT_TO.ErrorProviderControl = Me.ErrorProvider
        Me.txtSTT_TO.FieldName = ""
        Me.txtSTT_TO.IsNull = True
        Me.txtSTT_TO.Location = New System.Drawing.Point(452, 31)
        Me.txtSTT_TO.MaxLength = 4
        Me.txtSTT_TO.Multiline = False
        Me.txtSTT_TO.Name = "txtSTT_TO"
        Me.txtSTT_TO.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSTT_TO.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtSTT_TO.Properties.Appearance.Options.UseBackColor = True
        Me.txtSTT_TO.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSTT_TO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtSTT_TO.Properties.MaxLength = 4
        Me.txtSTT_TO.Properties.ReadOnly = True
        Me.txtSTT_TO.ReadOnly = True
        Me.txtSTT_TO.Size = New System.Drawing.Size(223, 20)
        Me.txtSTT_TO.TabIndex = 3
        Me.txtSTT_TO.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSTT_TO.TextTypeMode = Commons.TypeMode.IsNumber
        '
        'cboDON_VI
        '
        Me.cboDON_VI.AssemblyName = ""
        Me.cboDON_VI.BackColor = System.Drawing.Color.White
        Me.cboDON_VI.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboDON_VI.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboDON_VI.ClassName = ""
        Me.cboDON_VI.Display = ""
        Me.cboDON_VI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDON_VI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDON_VI.ErrorProviderControl = Me.ErrorProvider
        Me.cboDON_VI.FormattingEnabled = True
        Me.cboDON_VI.IsAll = False
        Me.cboDON_VI.isInputNull = False
        Me.cboDON_VI.IsNew = True
        Me.cboDON_VI.IsNull = True
        Me.cboDON_VI.ItemAll = " < ALL > "
        Me.cboDON_VI.ItemNew = "...New"
        Me.cboDON_VI.Location = New System.Drawing.Point(113, 3)
        Me.cboDON_VI.MethodName = ""
        Me.cboDON_VI.Name = "cboDON_VI"
        Me.cboDON_VI.Param = ""
        Me.cboDON_VI.Param2 = ""
        Me.cboDON_VI.Size = New System.Drawing.Size(223, 22)
        Me.cboDON_VI.StoreName = ""
        Me.cboDON_VI.TabIndex = 0
        Me.cboDON_VI.Table = Nothing
        Me.cboDON_VI.TextReadonly = False
        Me.cboDON_VI.Value = ""
        '
        'lblDonvi
        '
        Me.lblDonvi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDonvi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDonvi.ForeColor = System.Drawing.Color.Black
        Me.lblDonvi.Location = New System.Drawing.Point(3, 0)
        Me.lblDonvi.Name = "lblDonvi"
        Me.lblDonvi.Size = New System.Drawing.Size(104, 28)
        Me.lblDonvi.TabIndex = 52
        Me.lblDonvi.Text = "Đơn vị"
        Me.lblDonvi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTO_TRUONG
        '
        Me.txtTO_TRUONG.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTO_TRUONG.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTO_TRUONG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTO_TRUONG.ErrorProviderControl = Me.ErrorProvider
        Me.txtTO_TRUONG.FieldName = ""
        Me.txtTO_TRUONG.IsNull = True
        Me.txtTO_TRUONG.Location = New System.Drawing.Point(113, 31)
        Me.txtTO_TRUONG.MaxLength = 50
        Me.txtTO_TRUONG.Multiline = False
        Me.txtTO_TRUONG.Name = "txtTO_TRUONG"
        Me.txtTO_TRUONG.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTO_TRUONG.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTO_TRUONG.Properties.Appearance.Options.UseBackColor = True
        Me.txtTO_TRUONG.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTO_TRUONG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTO_TRUONG.Properties.MaxLength = 50
        Me.txtTO_TRUONG.Properties.ReadOnly = True
        Me.txtTO_TRUONG.ReadOnly = True
        Me.txtTO_TRUONG.Size = New System.Drawing.Size(223, 20)
        Me.txtTO_TRUONG.TabIndex = 2
        Me.txtTO_TRUONG.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTO_TRUONG.TextTypeMode = Commons.TypeMode.IsNumber
        '
        'txtTEN_TO
        '
        Me.txtTEN_TO.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_TO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTEN_TO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTEN_TO.ErrorProviderControl = Me.ErrorProvider
        Me.txtTEN_TO.FieldName = ""
        Me.txtTEN_TO.IsNull = True
        Me.txtTEN_TO.Location = New System.Drawing.Point(452, 3)
        Me.txtTEN_TO.MaxLength = 50
        Me.txtTEN_TO.Multiline = False
        Me.txtTEN_TO.Name = "txtTEN_TO"
        Me.txtTEN_TO.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_TO.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_TO.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_TO.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTEN_TO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTEN_TO.Properties.MaxLength = 50
        Me.txtTEN_TO.Properties.ReadOnly = True
        Me.txtTEN_TO.ReadOnly = True
        Me.txtTEN_TO.Size = New System.Drawing.Size(223, 20)
        Me.txtTEN_TO.TabIndex = 1
        Me.txtTEN_TO.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_TO.TextTypeMode = Commons.TypeMode.None
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(524, 4)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(80, 27)
        Me.BtnSua.TabIndex = 6
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Appearance.Options.UseFont = True
        Me.BtnThoat.Location = New System.Drawing.Point(682, 4)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(80, 27)
        Me.BtnThoat.TabIndex = 8
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(445, 4)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(80, 27)
        Me.BtnThem.TabIndex = 5
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(603, 4)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(80, 27)
        Me.BtnXoa.TabIndex = 7
        Me.BtnXoa.Text = "&Xóa"
        '
        'grpDanhsachto
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDanhsachto, 2)
        Me.grpDanhsachto.Controls.Add(Me.grdDanhsachto)
        Me.grpDanhsachto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhsachto.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachto.Location = New System.Drawing.Point(3, 122)
        Me.grpDanhsachto.Name = "grpDanhsachto"
        Me.grpDanhsachto.Size = New System.Drawing.Size(475, 296)
        Me.grpDanhsachto.TabIndex = 1
        Me.grpDanhsachto.TabStop = False
        Me.grpDanhsachto.Text = "Danh sách phòng ban"
        '
        'grpTo
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpTo, 2)
        Me.grpTo.Controls.Add(Me.grdTo)
        Me.grpTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTo.ForeColor = System.Drawing.Color.Maroon
        Me.grpTo.Location = New System.Drawing.Point(484, 122)
        Me.grpTo.Name = "grpTo"
        Me.grpTo.Size = New System.Drawing.Size(284, 296)
        Me.grpTo.TabIndex = 61
        Me.grpTo.TabStop = False
        Me.grpTo.Text = "Danh sách tổ"
        '
        'grdTo
        '
        Me.grdTo.AllowUserToAddRows = False
        Me.grdTo.AllowUserToDeleteRows = False
        Me.grdTo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TEN_TO})
        Me.grdTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTo.Location = New System.Drawing.Point(3, 18)
        Me.grdTo.Name = "grdTo"
        Me.grdTo.RowHeadersWidth = 25
        Me.grdTo.Size = New System.Drawing.Size(278, 275)
        Me.grdTo.TabIndex = 0
        '
        'TEN_TO
        '
        Me.TEN_TO.FillWeight = 111.6751!
        Me.TEN_TO.HeaderText = "TEN_TO"
        Me.TEN_TO.Name = "TEN_TO"
        '
        'btnXoaphongban
        '
        Me.btnXoaphongban.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoaphongban.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXoaphongban.Appearance.ForeColor = System.Drawing.Color.Red
        Me.btnXoaphongban.Appearance.Options.UseFont = True
        Me.btnXoaphongban.Appearance.Options.UseForeColor = True
        Me.btnXoaphongban.Location = New System.Drawing.Point(445, 4)
        Me.btnXoaphongban.Name = "btnXoaphongban"
        Me.btnXoaphongban.Size = New System.Drawing.Size(108, 27)
        Me.btnXoaphongban.TabIndex = 62
        Me.btnXoaphongban.Text = "Xóa phòng ban"
        '
        'btnTrove
        '
        Me.btnTrove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTrove.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrove.Appearance.ForeColor = System.Drawing.Color.Black
        Me.btnTrove.Appearance.Options.UseFont = True
        Me.btnTrove.Appearance.Options.UseForeColor = True
        Me.btnTrove.Location = New System.Drawing.Point(659, 4)
        Me.btnTrove.Name = "btnTrove"
        Me.btnTrove.Size = New System.Drawing.Size(103, 27)
        Me.btnTrove.TabIndex = 63
        Me.btnTrove.Text = "Trở về"
        '
        'btnXoato
        '
        Me.btnXoato.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoato.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXoato.Appearance.ForeColor = System.Drawing.Color.Red
        Me.btnXoato.Appearance.Options.UseFont = True
        Me.btnXoato.Appearance.Options.UseForeColor = True
        Me.btnXoato.Location = New System.Drawing.Point(552, 4)
        Me.btnXoato.Name = "btnXoato"
        Me.btnXoato.Size = New System.Drawing.Size(108, 27)
        Me.btnXoato.TabIndex = 64
        Me.btnXoato.Text = "Xóa tổ"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "TEN_TO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 185
        '
        'txtMS_TO
        '
        Me.txtMS_TO.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMS_TO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMS_TO.ErrorProviderControl = Me.ErrorProvider
        Me.txtMS_TO.FieldName = ""
        Me.txtMS_TO.IsNull = True
        Me.txtMS_TO.Location = New System.Drawing.Point(12, 12)
        Me.txtMS_TO.MaxLength = 0
        Me.txtMS_TO.Multiline = False
        Me.txtMS_TO.Name = "txtMS_TO"
        Me.txtMS_TO.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMS_TO.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMS_TO.Properties.Appearance.Options.UseBackColor = True
        Me.txtMS_TO.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMS_TO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtMS_TO.Properties.ReadOnly = True
        Me.txtMS_TO.ReadOnly = True
        Me.txtMS_TO.Size = New System.Drawing.Size(24, 20)
        Me.txtMS_TO.TabIndex = 20
        Me.txtMS_TO.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMS_TO.TextTypeMode = Commons.TypeMode.None
        Me.txtMS_TO.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.91304!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.08696!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieude, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grpTo, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grpNhapdanhmucto, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachto, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(771, 461)
        Me.TableLayoutPanel1.TabIndex = 65
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.btnXoaphongban)
        Me.Panel1.Controls.Add(Me.btnXoato)
        Me.Panel1.Controls.Add(Me.btnTrove)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 424)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(765, 34)
        Me.Panel1.TabIndex = 66
        '
        'frmDanhmucto
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.txtMS_TO)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmDanhmucto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh mục tổ"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDanhsachto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNhapdanhmucto.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.txtSTT_TO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTO_TRUONG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTEN_TO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachto.ResumeLayout(False)
        Me.grpTo.ResumeLayout(False)
        CType(Me.grdTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMS_TO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSTT_TO As Commons.utcTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpNhapdanhmucto As System.Windows.Forms.GroupBox
    Friend WithEvents lblSoTT As System.Windows.Forms.Label
    Friend WithEvents txtTO_TRUONG As Commons.utcTextBox
    Friend WithEvents lblTotruong As System.Windows.Forms.Label
    Friend WithEvents txtMS_TO As Commons.utcTextBox
    Friend WithEvents txtTEN_TO As Commons.utcTextBox
    Friend WithEvents lblTento As System.Windows.Forms.Label
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpDanhsachto As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachto As System.Windows.Forms.DataGridView
    Friend WithEvents cboDON_VI As Commons.UtcComboBox
    Friend WithEvents lblDonvi As System.Windows.Forms.Label
    Friend WithEvents grpTo As System.Windows.Forms.GroupBox
    Friend WithEvents grdTo As System.Windows.Forms.DataGridView
    Friend WithEvents btnXoato As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTrove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoaphongban As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TEN_TO As DataGridViewTextBoxColumn
End Class
