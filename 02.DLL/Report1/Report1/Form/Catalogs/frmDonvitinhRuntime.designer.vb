<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDonvitinhRuntime
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
        Me.GrdDanhsachdonviRT = New System.Windows.Forms.DataGridView()
        Me.lblTenDVRT = New System.Windows.Forms.Label()
        Me.lblTieudedonviRT = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsachdonviRT = New System.Windows.Forms.GroupBox()
        Me.GrpNhapdonviRT = New System.Windows.Forms.GroupBox()
        Me.txtTendonviRT = New Commons.utcTextBox()
        Me.txtMadonviRT = New Commons.utcTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdDanhsachdonviRT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDanhsachdonviRT.SuspendLayout()
        Me.GrpNhapdonviRT.SuspendLayout()
        CType(Me.txtTendonviRT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMadonviRT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'GrdDanhsachdonviRT
        '
        Me.GrdDanhsachdonviRT.AllowUserToAddRows = False
        Me.GrdDanhsachdonviRT.AllowUserToDeleteRows = False
        Me.GrdDanhsachdonviRT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhsachdonviRT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhsachdonviRT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhsachdonviRT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhsachdonviRT.Location = New System.Drawing.Point(3, 18)
        Me.GrdDanhsachdonviRT.MultiSelect = False
        Me.GrdDanhsachdonviRT.Name = "GrdDanhsachdonviRT"
        Me.GrdDanhsachdonviRT.ReadOnly = True
        Me.GrdDanhsachdonviRT.RowHeadersWidth = 25
        Me.GrdDanhsachdonviRT.Size = New System.Drawing.Size(704, 294)
        Me.GrdDanhsachdonviRT.TabIndex = 2
        '
        'lblTenDVRT
        '
        Me.lblTenDVRT.AutoSize = True
        Me.lblTenDVRT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenDVRT.ForeColor = System.Drawing.Color.Black
        Me.lblTenDVRT.Location = New System.Drawing.Point(6, 23)
        Me.lblTenDVRT.Name = "lblTenDVRT"
        Me.lblTenDVRT.Size = New System.Drawing.Size(120, 14)
        Me.lblTenDVRT.TabIndex = 5
        Me.lblTenDVRT.Text = "Tên đơn vị tính RT"
        '
        'lblTieudedonviRT
        '
        Me.lblTieudedonviRT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieudedonviRT.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTieudedonviRT.ForeColor = System.Drawing.Color.Navy
        Me.lblTieudedonviRT.Location = New System.Drawing.Point(3, 0)
        Me.lblTieudedonviRT.Name = "lblTieudedonviRT"
        Me.lblTieudedonviRT.Size = New System.Drawing.Size(670, 29)
        Me.lblTieudedonviRT.TabIndex = 63
        Me.lblTieudedonviRT.Text = "ĐƠN VỊ TÍNH RUN-TIME"
        Me.lblTieudedonviRT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnThem
        '
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThem.Location = New System.Drawing.Point(146, 0)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(98, 30)
        Me.BtnThem.TabIndex = 3
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Location = New System.Drawing.Point(342, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(98, 30)
        Me.BtnGhi.TabIndex = 7
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = True
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Location = New System.Drawing.Point(538, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(98, 30)
        Me.BtnKhongghi.TabIndex = 8
        Me.BtnKhongghi.Text = "&Không"
        '
        'BtnSua
        '
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Location = New System.Drawing.Point(244, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(98, 30)
        Me.BtnSua.TabIndex = 4
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnThoat.Appearance.Options.UseFont = True
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Location = New System.Drawing.Point(636, 0)
        Me.BtnThoat.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(98, 30)
        Me.BtnThoat.TabIndex = 6
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Location = New System.Drawing.Point(440, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(98, 30)
        Me.BtnXoa.TabIndex = 5
        Me.BtnXoa.Text = "&Xóa"
        '
        'GrpDanhsachdonviRT
        '
        Me.GrpDanhsachdonviRT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhsachdonviRT.Controls.Add(Me.GrdDanhsachdonviRT)
        Me.GrpDanhsachdonviRT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhsachdonviRT.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsachdonviRT.Location = New System.Drawing.Point(12, 110)
        Me.GrpDanhsachdonviRT.Name = "GrpDanhsachdonviRT"
        Me.GrpDanhsachdonviRT.Size = New System.Drawing.Size(710, 315)
        Me.GrpDanhsachdonviRT.TabIndex = 56
        Me.GrpDanhsachdonviRT.TabStop = False
        Me.GrpDanhsachdonviRT.Text = "Danh sách đơn vị tính Run-time"
        '
        'GrpNhapdonviRT
        '
        Me.GrpNhapdonviRT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapdonviRT.Controls.Add(Me.txtTendonviRT)
        Me.GrpNhapdonviRT.Controls.Add(Me.lblTenDVRT)
        Me.GrpNhapdonviRT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapdonviRT.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapdonviRT.Location = New System.Drawing.Point(65, 52)
        Me.GrpNhapdonviRT.Name = "GrpNhapdonviRT"
        Me.GrpNhapdonviRT.Size = New System.Drawing.Size(604, 52)
        Me.GrpNhapdonviRT.TabIndex = 55
        Me.GrpNhapdonviRT.TabStop = False
        Me.GrpNhapdonviRT.Text = "Nhập đơn vị tính Run-time"
        '
        'txtTendonviRT
        '
        Me.txtTendonviRT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTendonviRT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTendonviRT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTendonviRT.ErrorProviderControl = Me.ErrorProvider
        Me.txtTendonviRT.FieldName = ""
        Me.txtTendonviRT.IsNull = False
        Me.txtTendonviRT.Location = New System.Drawing.Point(132, 20)
        Me.txtTendonviRT.MaxLength = 0
        Me.txtTendonviRT.Multiline = False
        Me.txtTendonviRT.Name = "txtTendonviRT"
        Me.txtTendonviRT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTendonviRT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTendonviRT.Properties.Appearance.Options.UseBackColor = True
        Me.txtTendonviRT.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTendonviRT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTendonviRT.Properties.ReadOnly = True
        Me.txtTendonviRT.ReadOnly = True
        Me.txtTendonviRT.Size = New System.Drawing.Size(459, 20)
        Me.txtTendonviRT.TabIndex = 1
        Me.txtTendonviRT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTendonviRT.TextTypeMode = Commons.TypeMode.None
        '
        'txtMadonviRT
        '
        Me.txtMadonviRT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMadonviRT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMadonviRT.ErrorProviderControl = Me.ErrorProvider
        Me.txtMadonviRT.FieldName = ""
        Me.txtMadonviRT.IsNull = True
        Me.txtMadonviRT.Location = New System.Drawing.Point(15, 75)
        Me.txtMadonviRT.MaxLength = 0
        Me.txtMadonviRT.Multiline = False
        Me.txtMadonviRT.Name = "txtMadonviRT"
        Me.txtMadonviRT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMadonviRT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMadonviRT.Properties.Appearance.Options.UseBackColor = True
        Me.txtMadonviRT.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMadonviRT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtMadonviRT.Properties.ReadOnly = True
        Me.txtMadonviRT.ReadOnly = True
        Me.txtMadonviRT.Size = New System.Drawing.Size(14, 20)
        Me.txtMadonviRT.TabIndex = 62
        Me.txtMadonviRT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMadonviRT.TextTypeMode = Commons.TypeMode.None
        Me.txtMadonviRT.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 431)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(734, 30)
        Me.Panel1.TabIndex = 64
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnVideo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnHelp, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieudedonviRT, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 29)
        Me.TableLayoutPanel1.TabIndex = 65
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(677, 1)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(27, 27)
        Me.btnVideo.TabIndex = 102
        Me.btnVideo.Tag = "CMMS!frmDonvitinhRuntime"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(706, 1)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(27, 27)
        Me.btnHelp.TabIndex = 101
        Me.btnHelp.Tag = "CMMS!frmDonvitinhRuntime"
        '
        'frmDonvitinhRuntime
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.txtMadonviRT)
        Me.Controls.Add(Me.GrpDanhsachdonviRT)
        Me.Controls.Add(Me.GrpNhapdonviRT)
        Me.Controls.Add(Me.Panel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDonvitinhRuntime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Đơn vị tính Run-time"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdDanhsachdonviRT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDanhsachdonviRT.ResumeLayout(False)
        Me.GrpNhapdonviRT.ResumeLayout(False)
        Me.GrpNhapdonviRT.PerformLayout()
        CType(Me.txtTendonviRT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMadonviRT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTendonviRT As Commons.utcTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblTieudedonviRT As System.Windows.Forms.Label
    Friend WithEvents txtMadonviRT As Commons.utcTextBox
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhsachdonviRT As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhsachdonviRT As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhapdonviRT As System.Windows.Forms.GroupBox
    Friend WithEvents lblTenDVRT As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
End Class
