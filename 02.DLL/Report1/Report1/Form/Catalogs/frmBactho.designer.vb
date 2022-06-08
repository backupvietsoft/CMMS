
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBactho
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
        Me.GrpDanhmucbactho = New System.Windows.Forms.GroupBox()
        Me.GrdDanhmucbactho = New System.Windows.Forms.DataGridView()
        Me.GrpNhapbactho = New System.Windows.Forms.GroupBox()
        Me.TxtTenbactho = New Commons.utcTextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LblTenbactho = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtMabactho = New Commons.utcTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GrpDanhmucbactho.SuspendLayout()
        CType(Me.GrdDanhmucbactho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTenbactho.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMabactho.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnSua
        '
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Location = New System.Drawing.Point(208, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 4
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Location = New System.Drawing.Point(624, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 6
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Location = New System.Drawing.Point(312, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 5
        Me.BtnXoa.Text = "&Xóa"
        '
        'GrpDanhmucbactho
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpDanhmucbactho, 4)
        Me.GrpDanhmucbactho.Controls.Add(Me.GrdDanhmucbactho)
        Me.GrpDanhmucbactho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpDanhmucbactho.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhmucbactho.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhmucbactho.Location = New System.Drawing.Point(3, 66)
        Me.GrpDanhmucbactho.Name = "GrpDanhmucbactho"
        Me.GrpDanhmucbactho.Size = New System.Drawing.Size(728, 356)
        Me.GrpDanhmucbactho.TabIndex = 1
        Me.GrpDanhmucbactho.TabStop = False
        Me.GrpDanhmucbactho.Text = "Danh mục bậc thợ"
        '
        'GrdDanhmucbactho
        '
        Me.GrdDanhmucbactho.AllowUserToAddRows = False
        Me.GrdDanhmucbactho.AllowUserToDeleteRows = False
        Me.GrdDanhmucbactho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhmucbactho.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhmucbactho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhmucbactho.Location = New System.Drawing.Point(3, 18)
        Me.GrdDanhmucbactho.MultiSelect = False
        Me.GrdDanhmucbactho.Name = "GrdDanhmucbactho"
        Me.GrdDanhmucbactho.ReadOnly = True
        Me.GrdDanhmucbactho.RowHeadersWidth = 25
        Me.GrdDanhmucbactho.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrdDanhmucbactho.ShowEditingIcon = False
        Me.GrdDanhmucbactho.Size = New System.Drawing.Size(719, 338)
        Me.GrdDanhmucbactho.TabIndex = 2
        '
        'GrpNhapbactho
        '
        Me.GrpNhapbactho.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapbactho.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapbactho.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapbactho.Location = New System.Drawing.Point(96, 45)
        Me.GrpNhapbactho.Name = "GrpNhapbactho"
        Me.GrpNhapbactho.Size = New System.Drawing.Size(542, 51)
        Me.GrpNhapbactho.TabIndex = 0
        Me.GrpNhapbactho.TabStop = False
        Me.GrpNhapbactho.Text = "Nhập bậc thợ"
        '
        'TxtTenbactho
        '
        Me.TxtTenbactho.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtTenbactho.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtTenbactho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTenbactho.ErrorProviderControl = Me.ErrorProvider
        Me.TxtTenbactho.FieldName = ""
        Me.TxtTenbactho.IsNull = False
        Me.TxtTenbactho.Location = New System.Drawing.Point(237, 38)
        Me.TxtTenbactho.MaxLength = 0
        Me.TxtTenbactho.Multiline = False
        Me.TxtTenbactho.Name = "TxtTenbactho"
        Me.TxtTenbactho.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtTenbactho.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtTenbactho.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTenbactho.Properties.Appearance.Options.UseBackColor = True
        Me.TxtTenbactho.Properties.Appearance.Options.UseFont = True
        Me.TxtTenbactho.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtTenbactho.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TxtTenbactho.Properties.ReadOnly = True
        Me.TxtTenbactho.ReadOnly = True
        Me.TxtTenbactho.Size = New System.Drawing.Size(368, 21)
        Me.TxtTenbactho.TabIndex = 1
        Me.TxtTenbactho.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtTenbactho.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'LblTenbactho
        '
        Me.LblTenbactho.AutoSize = True
        Me.LblTenbactho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTenbactho.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTenbactho.ForeColor = System.Drawing.Color.Black
        Me.LblTenbactho.Location = New System.Drawing.Point(127, 35)
        Me.LblTenbactho.Name = "LblTenbactho"
        Me.LblTenbactho.Size = New System.Drawing.Size(104, 28)
        Me.LblTenbactho.TabIndex = 5
        Me.LblTenbactho.Text = "Tên bậc thợ"
        Me.LblTenbactho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnThem
        '
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThem.Location = New System.Drawing.Point(104, 0)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 3
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Location = New System.Drawing.Point(416, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 7
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Location = New System.Drawing.Point(520, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 8
        Me.BtnKhongghi.Text = "&Không"
        '
        'TxtMabactho
        '
        Me.TxtMabactho.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtMabactho.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtMabactho.ErrorProviderControl = Me.ErrorProvider
        Me.TxtMabactho.FieldName = ""
        Me.TxtMabactho.IsNull = True
        Me.TxtMabactho.Location = New System.Drawing.Point(33, 12)
        Me.TxtMabactho.MaxLength = 0
        Me.TxtMabactho.Multiline = False
        Me.TxtMabactho.Name = "TxtMabactho"
        Me.TxtMabactho.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtMabactho.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtMabactho.Properties.Appearance.Options.UseBackColor = True
        Me.TxtMabactho.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtMabactho.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TxtMabactho.Properties.ReadOnly = True
        Me.TxtMabactho.ReadOnly = True
        Me.TxtMabactho.Size = New System.Drawing.Size(18, 20)
        Me.TxtMabactho.TabIndex = 69
        Me.TxtMabactho.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtMabactho.TextTypeMode = Commons.TypeMode.None
        Me.TxtMabactho.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTenbactho, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblTenbactho, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpDanhmucbactho, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 461)
        Me.TableLayoutPanel1.TabIndex = 70
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 428)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(728, 30)
        Me.Panel1.TabIndex = 70
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(53, 23)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'frmBactho
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TxtMabactho)
        Me.Controls.Add(Me.GrpNhapbactho)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmBactho"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bậc thợ"
        Me.GrpDanhmucbactho.ResumeLayout(False)
        CType(Me.GrdDanhmucbactho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTenbactho.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMabactho.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhmucbactho As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhmucbactho As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhapbactho As System.Windows.Forms.GroupBox
    Friend WithEvents LblTenbactho As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtTenbactho As Commons.utcTextBox
    Friend WithEvents TxtMabactho As Commons.utcTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
End Class
