Imports Commons

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhmucdonvi
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
        Me.lblTenngan = New System.Windows.Forms.Label()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.grpNhapdanhmucDV = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMaso = New System.Windows.Forms.Label()
        Me.txtMS_DON_VI = New Commons.utcTextBox()
        Me.lblTendonvi = New System.Windows.Forms.Label()
        Me.txtFAX = New Commons.utcTextBox()
        Me.txtTEN_DON_VI = New Commons.utcTextBox()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.txtDIEN_THOAI = New Commons.utcTextBox()
        Me.txtTEN_NGAN = New Commons.utcTextBox()
        Me.lblDienthoai = New System.Windows.Forms.Label()
        Me.lblDiachi = New System.Windows.Forms.Label()
        Me.txtDIA_CHI = New Commons.utcTextBox()
        Me.chkThuengoai = New System.Windows.Forms.CheckBox()
        Me.chkMacdinh = New System.Windows.Forms.CheckBox()
        Me.lblTRutGon = New System.Windows.Forms.Label()
        Me.txtTRutGon = New Commons.utcTextBox()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.grdDanhsachdonvi = New System.Windows.Forms.DataGridView()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.grpDanhsachdonvi = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNhapdanhmucDV.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.txtMS_DON_VI.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFAX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTEN_DON_VI.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDIEN_THOAI.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTEN_NGAN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDIA_CHI.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTRutGon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDanhsachdonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachdonvi.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTenngan
        '
        Me.lblTenngan.AutoSize = True
        Me.lblTenngan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenngan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenngan.ForeColor = System.Drawing.Color.Black
        Me.lblTenngan.Location = New System.Drawing.Point(3, 60)
        Me.lblTenngan.Name = "lblTenngan"
        Me.lblTenngan.Size = New System.Drawing.Size(114, 30)
        Me.lblTenngan.TabIndex = 45
        Me.lblTenngan.Text = "Tên viết tắt"
        Me.lblTenngan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnGhi
        '
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Location = New System.Drawing.Point(638, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(80, 30)
        Me.BtnGhi.TabIndex = 12
        Me.BtnGhi.Text = "&Ghi"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = True
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Location = New System.Drawing.Point(718, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(80, 30)
        Me.BtnKhongghi.TabIndex = 13
        Me.BtnKhongghi.Text = "&Không"
        '
        'grpNhapdanhmucDV
        '
        Me.grpNhapdanhmucDV.Controls.Add(Me.TableLayoutPanel2)
        Me.grpNhapdanhmucDV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNhapdanhmucDV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNhapdanhmucDV.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhapdanhmucDV.Location = New System.Drawing.Point(0, 0)
        Me.grpNhapdanhmucDV.Name = "grpNhapdanhmucDV"
        Me.grpNhapdanhmucDV.Size = New System.Drawing.Size(500, 481)
        Me.grpNhapdanhmucDV.TabIndex = 0
        Me.grpNhapdanhmucDV.TabStop = False
        Me.grpNhapdanhmucDV.Text = "Nhập danh mục đơn vị"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblMaso, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMS_DON_VI, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTendonvi, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtFAX, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTEN_DON_VI, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblFax, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTenngan, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDIEN_THOAI, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTEN_NGAN, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDienthoai, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDiachi, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDIA_CHI, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.chkThuengoai, 2, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.chkMacdinh, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTRutGon, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTRutGon, 1, 6)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 9
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(494, 460)
        Me.TableLayoutPanel2.TabIndex = 51
        '
        'lblMaso
        '
        Me.lblMaso.AutoSize = True
        Me.lblMaso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMaso.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaso.ForeColor = System.Drawing.Color.Black
        Me.lblMaso.Location = New System.Drawing.Point(3, 0)
        Me.lblMaso.Name = "lblMaso"
        Me.lblMaso.Size = New System.Drawing.Size(114, 30)
        Me.lblMaso.TabIndex = 44
        Me.lblMaso.Text = "Mã Số"
        Me.lblMaso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMS_DON_VI
        '
        Me.txtMS_DON_VI.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMS_DON_VI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtMS_DON_VI, 2)
        Me.txtMS_DON_VI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMS_DON_VI.ErrorProviderControl = Me.ErrorProvider
        Me.txtMS_DON_VI.FieldName = ""
        Me.txtMS_DON_VI.IsNull = True
        Me.txtMS_DON_VI.Location = New System.Drawing.Point(123, 3)
        Me.txtMS_DON_VI.MaxLength = 6
        Me.txtMS_DON_VI.Multiline = False
        Me.txtMS_DON_VI.Name = "txtMS_DON_VI"
        Me.txtMS_DON_VI.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMS_DON_VI.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMS_DON_VI.Properties.Appearance.Options.UseBackColor = True
        Me.txtMS_DON_VI.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMS_DON_VI.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtMS_DON_VI.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMS_DON_VI.Properties.MaxLength = 6
        Me.txtMS_DON_VI.Properties.ReadOnly = True
        Me.txtMS_DON_VI.ReadOnly = True
        Me.txtMS_DON_VI.Size = New System.Drawing.Size(368, 20)
        Me.txtMS_DON_VI.TabIndex = 0
        Me.txtMS_DON_VI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMS_DON_VI.TextTypeMode = Commons.TypeMode.None
        '
        'lblTendonvi
        '
        Me.lblTendonvi.AutoSize = True
        Me.lblTendonvi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTendonvi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTendonvi.ForeColor = System.Drawing.Color.Black
        Me.lblTendonvi.Location = New System.Drawing.Point(3, 30)
        Me.lblTendonvi.Name = "lblTendonvi"
        Me.lblTendonvi.Size = New System.Drawing.Size(114, 30)
        Me.lblTendonvi.TabIndex = 3
        Me.lblTendonvi.Text = "Tên đơn vị"
        Me.lblTendonvi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFAX
        '
        Me.txtFAX.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtFAX.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtFAX, 2)
        Me.txtFAX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFAX.ErrorProviderControl = Me.ErrorProvider
        Me.txtFAX.FieldName = ""
        Me.txtFAX.IsNull = True
        Me.txtFAX.Location = New System.Drawing.Point(123, 153)
        Me.txtFAX.MaxLength = 15
        Me.txtFAX.Multiline = False
        Me.txtFAX.Name = "txtFAX"
        Me.txtFAX.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFAX.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtFAX.Properties.Appearance.Options.UseBackColor = True
        Me.txtFAX.Properties.Appearance.Options.UseTextOptions = True
        Me.txtFAX.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtFAX.Properties.MaxLength = 15
        Me.txtFAX.Properties.ReadOnly = True
        Me.txtFAX.ReadOnly = True
        Me.txtFAX.Size = New System.Drawing.Size(368, 20)
        Me.txtFAX.TabIndex = 5
        Me.txtFAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtFAX.TextTypeMode = Commons.TypeMode.IsNumber
        '
        'txtTEN_DON_VI
        '
        Me.txtTEN_DON_VI.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_DON_VI.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtTEN_DON_VI, 2)
        Me.txtTEN_DON_VI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTEN_DON_VI.ErrorProviderControl = Me.ErrorProvider
        Me.txtTEN_DON_VI.FieldName = ""
        Me.txtTEN_DON_VI.IsNull = True
        Me.txtTEN_DON_VI.Location = New System.Drawing.Point(123, 33)
        Me.txtTEN_DON_VI.MaxLength = 255
        Me.txtTEN_DON_VI.Multiline = False
        Me.txtTEN_DON_VI.Name = "txtTEN_DON_VI"
        Me.txtTEN_DON_VI.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_DON_VI.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_DON_VI.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_DON_VI.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTEN_DON_VI.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTEN_DON_VI.Properties.MaxLength = 255
        Me.txtTEN_DON_VI.Properties.ReadOnly = True
        Me.txtTEN_DON_VI.ReadOnly = True
        Me.txtTEN_DON_VI.Size = New System.Drawing.Size(368, 20)
        Me.txtTEN_DON_VI.TabIndex = 1
        Me.txtTEN_DON_VI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_DON_VI.TextTypeMode = Commons.TypeMode.None
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFax.ForeColor = System.Drawing.Color.Black
        Me.lblFax.Location = New System.Drawing.Point(3, 150)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(114, 30)
        Me.lblFax.TabIndex = 50
        Me.lblFax.Text = "Fax"
        Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDIEN_THOAI
        '
        Me.txtDIEN_THOAI.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtDIEN_THOAI.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtDIEN_THOAI, 2)
        Me.txtDIEN_THOAI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDIEN_THOAI.ErrorProviderControl = Me.ErrorProvider
        Me.txtDIEN_THOAI.FieldName = ""
        Me.txtDIEN_THOAI.IsNull = True
        Me.txtDIEN_THOAI.Location = New System.Drawing.Point(123, 123)
        Me.txtDIEN_THOAI.MaxLength = 15
        Me.txtDIEN_THOAI.Multiline = False
        Me.txtDIEN_THOAI.Name = "txtDIEN_THOAI"
        Me.txtDIEN_THOAI.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDIEN_THOAI.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtDIEN_THOAI.Properties.Appearance.Options.UseBackColor = True
        Me.txtDIEN_THOAI.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDIEN_THOAI.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtDIEN_THOAI.Properties.MaxLength = 15
        Me.txtDIEN_THOAI.ReadOnly = False
        Me.txtDIEN_THOAI.Size = New System.Drawing.Size(368, 20)
        Me.txtDIEN_THOAI.TabIndex = 4
        Me.txtDIEN_THOAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDIEN_THOAI.TextTypeMode = Commons.TypeMode.IsNumber
        '
        'txtTEN_NGAN
        '
        Me.txtTEN_NGAN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_NGAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtTEN_NGAN, 2)
        Me.txtTEN_NGAN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTEN_NGAN.ErrorProviderControl = Me.ErrorProvider
        Me.txtTEN_NGAN.FieldName = ""
        Me.txtTEN_NGAN.IsNull = True
        Me.txtTEN_NGAN.Location = New System.Drawing.Point(123, 63)
        Me.txtTEN_NGAN.MaxLength = 20
        Me.txtTEN_NGAN.Multiline = False
        Me.txtTEN_NGAN.Name = "txtTEN_NGAN"
        Me.txtTEN_NGAN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_NGAN.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_NGAN.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_NGAN.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTEN_NGAN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTEN_NGAN.Properties.MaxLength = 20
        Me.txtTEN_NGAN.Properties.ReadOnly = True
        Me.txtTEN_NGAN.ReadOnly = True
        Me.txtTEN_NGAN.Size = New System.Drawing.Size(368, 20)
        Me.txtTEN_NGAN.TabIndex = 2
        Me.txtTEN_NGAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_NGAN.TextTypeMode = Commons.TypeMode.IsNumber
        '
        'lblDienthoai
        '
        Me.lblDienthoai.AutoSize = True
        Me.lblDienthoai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDienthoai.ForeColor = System.Drawing.Color.Black
        Me.lblDienthoai.Location = New System.Drawing.Point(3, 120)
        Me.lblDienthoai.Name = "lblDienthoai"
        Me.lblDienthoai.Size = New System.Drawing.Size(114, 30)
        Me.lblDienthoai.TabIndex = 48
        Me.lblDienthoai.Text = "Điện thoại"
        Me.lblDienthoai.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDiachi
        '
        Me.lblDiachi.AutoSize = True
        Me.lblDiachi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDiachi.ForeColor = System.Drawing.Color.Black
        Me.lblDiachi.Location = New System.Drawing.Point(3, 90)
        Me.lblDiachi.Name = "lblDiachi"
        Me.lblDiachi.Size = New System.Drawing.Size(114, 30)
        Me.lblDiachi.TabIndex = 5
        Me.lblDiachi.Text = "Địa chỉ"
        Me.lblDiachi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDIA_CHI
        '
        Me.txtDIA_CHI.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtDIA_CHI.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtDIA_CHI, 2)
        Me.txtDIA_CHI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDIA_CHI.ErrorProviderControl = Me.ErrorProvider
        Me.txtDIA_CHI.FieldName = ""
        Me.txtDIA_CHI.IsNull = True
        Me.txtDIA_CHI.Location = New System.Drawing.Point(123, 93)
        Me.txtDIA_CHI.MaxLength = 100
        Me.txtDIA_CHI.Multiline = False
        Me.txtDIA_CHI.Name = "txtDIA_CHI"
        Me.txtDIA_CHI.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDIA_CHI.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtDIA_CHI.Properties.Appearance.Options.UseBackColor = True
        Me.txtDIA_CHI.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDIA_CHI.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtDIA_CHI.Properties.MaxLength = 100
        Me.txtDIA_CHI.Properties.ReadOnly = True
        Me.txtDIA_CHI.ReadOnly = True
        Me.txtDIA_CHI.Size = New System.Drawing.Size(368, 20)
        Me.txtDIA_CHI.TabIndex = 3
        Me.txtDIA_CHI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDIA_CHI.TextTypeMode = Commons.TypeMode.IsNumber
        '
        'chkThuengoai
        '
        Me.chkThuengoai.AutoSize = True
        Me.chkThuengoai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkThuengoai.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkThuengoai.Location = New System.Drawing.Point(310, 213)
        Me.chkThuengoai.Name = "chkThuengoai"
        Me.chkThuengoai.Size = New System.Drawing.Size(181, 24)
        Me.chkThuengoai.TabIndex = 8
        Me.chkThuengoai.Text = "Thuê ngoài"
        Me.chkThuengoai.UseVisualStyleBackColor = True
        '
        'chkMacdinh
        '
        Me.chkMacdinh.AutoSize = True
        Me.chkMacdinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkMacdinh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkMacdinh.Location = New System.Drawing.Point(123, 213)
        Me.chkMacdinh.Name = "chkMacdinh"
        Me.chkMacdinh.Size = New System.Drawing.Size(181, 24)
        Me.chkMacdinh.TabIndex = 7
        Me.chkMacdinh.Text = "Mặc định"
        Me.chkMacdinh.UseVisualStyleBackColor = True
        '
        'lblTRutGon
        '
        Me.lblTRutGon.AutoSize = True
        Me.lblTRutGon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTRutGon.ForeColor = System.Drawing.Color.Black
        Me.lblTRutGon.Location = New System.Drawing.Point(3, 180)
        Me.lblTRutGon.Name = "lblTRutGon"
        Me.lblTRutGon.Size = New System.Drawing.Size(114, 30)
        Me.lblTRutGon.TabIndex = 50
        Me.lblTRutGon.Text = "lblTRutGon"
        Me.lblTRutGon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTRutGon
        '
        Me.txtTRutGon.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTRutGon.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtTRutGon, 2)
        Me.txtTRutGon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTRutGon.ErrorProviderControl = Nothing
        Me.txtTRutGon.FieldName = ""
        Me.txtTRutGon.IsNull = True
        Me.txtTRutGon.Location = New System.Drawing.Point(123, 183)
        Me.txtTRutGon.MaxLength = 5
        Me.txtTRutGon.Multiline = False
        Me.txtTRutGon.Name = "txtTRutGon"
        Me.txtTRutGon.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTRutGon.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTRutGon.Properties.Appearance.Options.UseBackColor = True
        Me.txtTRutGon.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTRutGon.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTRutGon.Properties.MaxLength = 5
        Me.txtTRutGon.Properties.ReadOnly = True
        Me.txtTRutGon.ReadOnly = True
        Me.txtTRutGon.Size = New System.Drawing.Size(368, 20)
        Me.txtTRutGon.TabIndex = 6
        Me.txtTRutGon.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTRutGon.TextTypeMode = Commons.TypeMode.IsNumber
        '
        'BtnThem
        '
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThem.Location = New System.Drawing.Point(398, 0)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(80, 30)
        Me.BtnThem.TabIndex = 8
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnSua
        '
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Location = New System.Drawing.Point(478, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(80, 30)
        Me.BtnSua.TabIndex = 9
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Appearance.Options.UseFont = True
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Location = New System.Drawing.Point(798, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(80, 30)
        Me.BtnThoat.TabIndex = 11
        Me.BtnThoat.Text = "T&hoát"
        '
        'grdDanhsachdonvi
        '
        Me.grdDanhsachdonvi.AllowUserToAddRows = False
        Me.grdDanhsachdonvi.AllowUserToDeleteRows = False
        Me.grdDanhsachdonvi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDanhsachdonvi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachdonvi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachdonvi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachdonvi.Location = New System.Drawing.Point(3, 18)
        Me.grdDanhsachdonvi.MultiSelect = False
        Me.grdDanhsachdonvi.Name = "grdDanhsachdonvi"
        Me.grdDanhsachdonvi.ReadOnly = True
        Me.grdDanhsachdonvi.RowHeadersWidth = 25
        Me.grdDanhsachdonvi.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grdDanhsachdonvi.ShowEditingIcon = False
        Me.grdDanhsachdonvi.Size = New System.Drawing.Size(369, 460)
        Me.grdDanhsachdonvi.TabIndex = 0
        '
        'BtnXoa
        '
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Location = New System.Drawing.Point(558, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(80, 30)
        Me.BtnXoa.TabIndex = 10
        Me.BtnXoa.Text = "&Xóa"
        '
        'grpDanhsachdonvi
        '
        Me.grpDanhsachdonvi.Controls.Add(Me.grdDanhsachdonvi)
        Me.grpDanhsachdonvi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachdonvi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhsachdonvi.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachdonvi.Location = New System.Drawing.Point(0, 0)
        Me.grpDanhsachdonvi.Name = "grpDanhsachdonvi"
        Me.grpDanhsachdonvi.Size = New System.Drawing.Size(375, 481)
        Me.grpDanhsachdonvi.TabIndex = 1
        Me.grpDanhsachdonvi.TabStop = False
        Me.grpDanhsachdonvi.Text = "Danh sách đơn vị"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainer1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 52
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 41)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpDanhsachdonvi)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Splitter1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpNhapdanhmucDV)
        Me.SplitContainer1.Size = New System.Drawing.Size(878, 481)
        Me.SplitContainer1.SplitterDistance = 375
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 52
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 481)
        Me.Splitter1.TabIndex = 0
        Me.Splitter1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 528)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(878, 30)
        Me.Panel1.TabIndex = 53
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnVideo, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnHelp, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(817, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(64, 32)
        Me.TableLayoutPanel3.TabIndex = 54
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(33, 1)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(30, 30)
        Me.btnVideo.TabIndex = 100
        Me.btnVideo.Tag = "CMMS!frmDanhmucdonvi"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(1, 1)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(30, 30)
        Me.btnHelp.TabIndex = 99
        Me.btnHelp.Tag = "CMMS!frmDanhmucdonvi"
        '
        'frmDanhmucdonvi
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDanhmucdonvi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh mục đơn vị"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNhapdanhmucDV.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.txtMS_DON_VI.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFAX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTEN_DON_VI.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDIEN_THOAI.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTEN_NGAN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDIA_CHI.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTRutGon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDanhsachdonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachdonvi.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTenngan As System.Windows.Forms.Label
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtMS_DON_VI As Commons.utcTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpNhapdanhmucDV As System.Windows.Forms.GroupBox
    Friend WithEvents txtTEN_NGAN As Commons.utcTextBox
    Friend WithEvents lblMaso As System.Windows.Forms.Label
    Friend WithEvents txtDIA_CHI As Commons.utcTextBox
    Friend WithEvents txtTEN_DON_VI As Commons.utcTextBox
    Friend WithEvents lblTendonvi As System.Windows.Forms.Label
    Friend WithEvents lblDiachi As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpDanhsachdonvi As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachdonvi As System.Windows.Forms.DataGridView
    Friend WithEvents chkThuengoai As System.Windows.Forms.CheckBox
    Friend WithEvents chkMacdinh As System.Windows.Forms.CheckBox
    Friend WithEvents txtFAX As Commons.utcTextBox
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents txtDIEN_THOAI As Commons.utcTextBox
    Friend WithEvents lblDienthoai As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTRutGon As System.Windows.Forms.Label
    Friend WithEvents txtTRutGon As Commons.utcTextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
End Class
