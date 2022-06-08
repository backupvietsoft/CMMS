<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMucUT
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
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.grpDanhsachmucUT = New System.Windows.Forms.GroupBox()
        Me.grdMUT = New DevExpress.XtraGrid.GridControl()
        Me.grvMUT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtMucUT = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMaso = New System.Windows.Forms.Label()
        Me.txtSoNgayKT = New Commons.utcTextBox()
        Me.txtSoNgayBD = New Commons.utcTextBox()
        Me.txtMaso = New Commons.utcTextBox()
        Me.lblMucUT = New System.Windows.Forms.Label()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachmucUT.SuspendLayout()
        CType(Me.grdMUT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvMUT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMucUT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSoNgayKT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSoNgayBD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaso.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(307, 3)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 2
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(517, 3)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 6
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(622, 3)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 7
        Me.BtnKhongghi.Text = "&Không"
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(412, 3)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 3
        Me.BtnSua.Text = "&Sửa"
        '
        'grpDanhsachmucUT
        '
        Me.grpDanhsachmucUT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDanhsachmucUT, 7)
        Me.grpDanhsachmucUT.Controls.Add(Me.grdMUT)
        Me.grpDanhsachmucUT.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grpDanhsachmucUT.Location = New System.Drawing.Point(3, 65)
        Me.grpDanhsachmucUT.Name = "grpDanhsachmucUT"
        Me.grpDanhsachmucUT.Size = New System.Drawing.Size(728, 352)
        Me.grpDanhsachmucUT.TabIndex = 1
        Me.grpDanhsachmucUT.TabStop = False
        Me.grpDanhsachmucUT.Text = "Danh sách mức ưu tiên"
        '
        'grdMUT
        '
        Me.grdMUT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMUT.Location = New System.Drawing.Point(3, 17)
        Me.grdMUT.LookAndFeel.SkinName = "Blue"
        Me.grdMUT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdMUT.MainView = Me.grvMUT
        Me.grdMUT.Name = "grdMUT"
        Me.grdMUT.Size = New System.Drawing.Size(722, 332)
        Me.grdMUT.TabIndex = 4
        Me.grdMUT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvMUT})
        '
        'grvMUT
        '
        Me.grvMUT.GridControl = Me.grdMUT
        Me.grvMUT.Name = "grvMUT"
        Me.grvMUT.OptionsCustomization.AllowGroup = False
        Me.grvMUT.OptionsView.ShowGroupPanel = False
        '
        'txtMucUT
        '
        Me.txtMucUT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMucUT.EditValue = ""
        Me.txtMucUT.Location = New System.Drawing.Point(472, 11)
        Me.txtMucUT.Name = "txtMucUT"
        Me.txtMucUT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtMucUT.Size = New System.Drawing.Size(203, 20)
        Me.txtMucUT.TabIndex = 79
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(368, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 25)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Số ngày kết thúc"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(55, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 25)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Số ngày bắt đầu"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMaso
        '
        Me.lblMaso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMaso.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaso.ForeColor = System.Drawing.Color.Black
        Me.lblMaso.Location = New System.Drawing.Point(55, 8)
        Me.lblMaso.Name = "lblMaso"
        Me.lblMaso.Size = New System.Drawing.Size(98, 25)
        Me.lblMaso.TabIndex = 80
        Me.lblMaso.Text = "Mã số"
        Me.lblMaso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSoNgayKT
        '
        Me.txtSoNgayKT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtSoNgayKT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtSoNgayKT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSoNgayKT.ErrorProviderControl = Nothing
        Me.txtSoNgayKT.FieldName = ""
        Me.txtSoNgayKT.IsNull = True
        Me.txtSoNgayKT.Location = New System.Drawing.Point(472, 36)
        Me.txtSoNgayKT.MaxLength = 0
        Me.txtSoNgayKT.Multiline = False
        Me.txtSoNgayKT.Name = "txtSoNgayKT"
        Me.txtSoNgayKT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSoNgayKT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtSoNgayKT.Properties.Appearance.Options.UseBackColor = True
        Me.txtSoNgayKT.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSoNgayKT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtSoNgayKT.Properties.ReadOnly = True
        Me.txtSoNgayKT.ReadOnly = True
        Me.txtSoNgayKT.Size = New System.Drawing.Size(203, 20)
        Me.txtSoNgayKT.TabIndex = 0
        Me.txtSoNgayKT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSoNgayKT.TextTypeMode = Commons.TypeMode.None
        '
        'txtSoNgayBD
        '
        Me.txtSoNgayBD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtSoNgayBD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtSoNgayBD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSoNgayBD.ErrorProviderControl = Nothing
        Me.txtSoNgayBD.FieldName = ""
        Me.txtSoNgayBD.IsNull = True
        Me.txtSoNgayBD.Location = New System.Drawing.Point(159, 36)
        Me.txtSoNgayBD.MaxLength = 0
        Me.txtSoNgayBD.Multiline = False
        Me.txtSoNgayBD.Name = "txtSoNgayBD"
        Me.txtSoNgayBD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSoNgayBD.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtSoNgayBD.Properties.Appearance.Options.UseBackColor = True
        Me.txtSoNgayBD.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSoNgayBD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtSoNgayBD.Properties.ReadOnly = True
        Me.txtSoNgayBD.ReadOnly = True
        Me.txtSoNgayBD.Size = New System.Drawing.Size(203, 20)
        Me.txtSoNgayBD.TabIndex = 0
        Me.txtSoNgayBD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSoNgayBD.TextTypeMode = Commons.TypeMode.None
        '
        'txtMaso
        '
        Me.txtMaso.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMaso.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMaso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMaso.ErrorProviderControl = Me.ErrorProvider
        Me.txtMaso.FieldName = ""
        Me.txtMaso.IsNull = True
        Me.txtMaso.Location = New System.Drawing.Point(159, 11)
        Me.txtMaso.MaxLength = 0
        Me.txtMaso.Multiline = False
        Me.txtMaso.Name = "txtMaso"
        Me.txtMaso.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMaso.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMaso.Properties.Appearance.Options.UseBackColor = True
        Me.txtMaso.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMaso.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtMaso.Properties.ReadOnly = True
        Me.txtMaso.ReadOnly = True
        Me.txtMaso.Size = New System.Drawing.Size(203, 20)
        Me.txtMaso.TabIndex = 0
        Me.txtMaso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMaso.TextTypeMode = Commons.TypeMode.None
        '
        'lblMucUT
        '
        Me.lblMucUT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMucUT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMucUT.ForeColor = System.Drawing.Color.Black
        Me.lblMucUT.Location = New System.Drawing.Point(368, 8)
        Me.lblMucUT.Name = "lblMucUT"
        Me.lblMucUT.Size = New System.Drawing.Size(98, 25)
        Me.lblMucUT.TabIndex = 5
        Me.lblMucUT.Text = "Mức ưu tiên"
        Me.lblMucUT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Location = New System.Drawing.Point(622, 3)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 5
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(517, 3)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 4
        Me.BtnXoa.Text = "&Xóa"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.139794!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28959!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57062!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28959!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57062!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.139796!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSoNgayKT, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMucUT, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachmucUT, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSoNgayBD, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMaso, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMaso, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMucUT, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 461)
        Me.TableLayoutPanel1.TabIndex = 79
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 6)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 423)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(728, 35)
        Me.Panel1.TabIndex = 80
        '
        'frmMucUT
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "frmMucUT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh mục trình độ"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachmucUT.ResumeLayout(False)
        CType(Me.grdMUT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvMUT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMucUT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSoNgayKT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSoNgayBD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaso.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtMaso As Commons.utcTextBox
    Friend WithEvents grpDanhsachmucUT As System.Windows.Forms.GroupBox
    Friend WithEvents lblMucUT As System.Windows.Forms.Label
    Friend WithEvents lblMaso As System.Windows.Forms.Label
    Private WithEvents txtMucUT As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSoNgayKT As Commons.utcTextBox
    Friend WithEvents txtSoNgayBD As Commons.utcTextBox
    Private WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Private WithEvents grdMUT As DevExpress.XtraGrid.GridControl
    Private WithEvents grvMUT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
End Class
