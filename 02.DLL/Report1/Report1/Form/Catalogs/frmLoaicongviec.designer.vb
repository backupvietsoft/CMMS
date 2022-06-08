<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoaicongviec
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
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhmucloaicv = New System.Windows.Forms.GroupBox()
        Me.grdLCV = New DevExpress.XtraGrid.GridControl()
        Me.grvLCV = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GrpNhaploaicongviec = New System.Windows.Forms.GroupBox()
        Me.txtTenAnh = New Commons.utcTextBox()
        Me.lblTenAnh = New System.Windows.Forms.Label()
        Me.TxtTenloaicv = New Commons.utcTextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LblTenloaicongviec = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtMaloaicv = New Commons.utcTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhmucloaicv.SuspendLayout()
        CType(Me.grdLCV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvLCV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhaploaicongviec.SuspendLayout()
        CType(Me.txtTenAnh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTenloaicv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtMaloaicv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(411, 2)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 4
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Location = New System.Drawing.Point(621, 2)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 6
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(516, 2)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 5
        Me.BtnXoa.Text = "&Xóa"
        '
        'GrpDanhmucloaicv
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpDanhmucloaicv, 5)
        Me.GrpDanhmucloaicv.Controls.Add(Me.grdLCV)
        Me.GrpDanhmucloaicv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpDanhmucloaicv.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhmucloaicv.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhmucloaicv.Location = New System.Drawing.Point(3, 125)
        Me.GrpDanhmucloaicv.Name = "GrpDanhmucloaicv"
        Me.GrpDanhmucloaicv.Size = New System.Drawing.Size(728, 293)
        Me.GrpDanhmucloaicv.TabIndex = 45
        Me.GrpDanhmucloaicv.TabStop = False
        Me.GrpDanhmucloaicv.Text = "Danh mục loại công việc"
        '
        'grdLCV
        '
        Me.grdLCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLCV.Location = New System.Drawing.Point(3, 18)
        Me.grdLCV.MainView = Me.grvLCV
        Me.grdLCV.Name = "grdLCV"
        Me.grdLCV.Size = New System.Drawing.Size(722, 272)
        Me.grdLCV.TabIndex = 99
        Me.grdLCV.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvLCV})
        '
        'grvLCV
        '
        Me.grvLCV.GridControl = Me.grdLCV
        Me.grvLCV.Name = "grvLCV"
        Me.grvLCV.OptionsView.ShowGroupPanel = False
        '
        'GrpNhaploaicongviec
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpNhaploaicongviec, 5)
        Me.GrpNhaploaicongviec.Controls.Add(Me.txtTenAnh)
        Me.GrpNhaploaicongviec.Controls.Add(Me.lblTenAnh)
        Me.GrpNhaploaicongviec.Controls.Add(Me.TxtTenloaicv)
        Me.GrpNhaploaicongviec.Controls.Add(Me.LblTenloaicongviec)
        Me.GrpNhaploaicongviec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpNhaploaicongviec.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhaploaicongviec.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhaploaicongviec.Location = New System.Drawing.Point(3, 41)
        Me.GrpNhaploaicongviec.Name = "GrpNhaploaicongviec"
        Me.GrpNhaploaicongviec.Size = New System.Drawing.Size(728, 74)
        Me.GrpNhaploaicongviec.TabIndex = 44
        Me.GrpNhaploaicongviec.TabStop = False
        Me.GrpNhaploaicongviec.Text = "Nhập loại công việc"
        '
        'txtTenAnh
        '
        Me.txtTenAnh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTenAnh.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTenAnh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTenAnh.ErrorProviderControl = Nothing
        Me.txtTenAnh.FieldName = ""
        Me.txtTenAnh.IsNull = False
        Me.txtTenAnh.Location = New System.Drawing.Point(138, 41)
        Me.txtTenAnh.MaxLength = 0
        Me.txtTenAnh.Multiline = False
        Me.txtTenAnh.Name = "txtTenAnh"
        Me.txtTenAnh.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTenAnh.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTenAnh.Properties.Appearance.Options.UseBackColor = True
        Me.txtTenAnh.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTenAnh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTenAnh.Properties.ReadOnly = True
        Me.txtTenAnh.ReadOnly = True
        Me.txtTenAnh.Size = New System.Drawing.Size(542, 20)
        Me.txtTenAnh.TabIndex = 1
        Me.txtTenAnh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTenAnh.TextTypeMode = Commons.TypeMode.None
        '
        'lblTenAnh
        '
        Me.lblTenAnh.AutoSize = True
        Me.lblTenAnh.ForeColor = System.Drawing.Color.Black
        Me.lblTenAnh.Location = New System.Drawing.Point(12, 44)
        Me.lblTenAnh.Name = "lblTenAnh"
        Me.lblTenAnh.Size = New System.Drawing.Size(55, 14)
        Me.lblTenAnh.TabIndex = 5
        Me.lblTenAnh.Text = "Ten Anh"
        '
        'TxtTenloaicv
        '
        Me.TxtTenloaicv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTenloaicv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtTenloaicv.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtTenloaicv.ErrorProviderControl = Me.ErrorProvider
        Me.TxtTenloaicv.FieldName = ""
        Me.TxtTenloaicv.IsNull = False
        Me.TxtTenloaicv.Location = New System.Drawing.Point(138, 20)
        Me.TxtTenloaicv.MaxLength = 0
        Me.TxtTenloaicv.Multiline = False
        Me.TxtTenloaicv.Name = "TxtTenloaicv"
        Me.TxtTenloaicv.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtTenloaicv.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtTenloaicv.Properties.Appearance.Options.UseBackColor = True
        Me.TxtTenloaicv.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtTenloaicv.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TxtTenloaicv.Properties.ReadOnly = True
        Me.TxtTenloaicv.ReadOnly = True
        Me.TxtTenloaicv.Size = New System.Drawing.Size(542, 20)
        Me.TxtTenloaicv.TabIndex = 1
        Me.TxtTenloaicv.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtTenloaicv.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'LblTenloaicongviec
        '
        Me.LblTenloaicongviec.AutoSize = True
        Me.LblTenloaicongviec.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTenloaicongviec.ForeColor = System.Drawing.Color.Black
        Me.LblTenloaicongviec.Location = New System.Drawing.Point(12, 23)
        Me.LblTenloaicongviec.Name = "LblTenloaicongviec"
        Me.LblTenloaicongviec.Size = New System.Drawing.Size(74, 14)
        Me.LblTenloaicongviec.TabIndex = 5
        Me.LblTenloaicongviec.Text = "Tên loại CV"
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(306, 2)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 3
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(516, 2)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 7
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(621, 2)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 8
        Me.BtnKhongghi.Text = "&Không"
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 5)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 424)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(728, 34)
        Me.Panel1.TabIndex = 52
        '
        'TxtMaloaicv
        '
        Me.TxtMaloaicv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtMaloaicv.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtMaloaicv.ErrorProviderControl = Me.ErrorProvider
        Me.TxtMaloaicv.FieldName = ""
        Me.TxtMaloaicv.IsNull = True
        Me.TxtMaloaicv.Location = New System.Drawing.Point(358, 37)
        Me.TxtMaloaicv.MaxLength = 0
        Me.TxtMaloaicv.Multiline = False
        Me.TxtMaloaicv.Name = "TxtMaloaicv"
        Me.TxtMaloaicv.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtMaloaicv.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtMaloaicv.Properties.Appearance.Options.UseBackColor = True
        Me.TxtMaloaicv.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtMaloaicv.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TxtMaloaicv.Properties.ReadOnly = True
        Me.TxtMaloaicv.ReadOnly = True
        Me.TxtMaloaicv.Size = New System.Drawing.Size(15, 20)
        Me.TxtMaloaicv.TabIndex = 51
        Me.TxtMaloaicv.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtMaloaicv.TextTypeMode = Commons.TypeMode.None
        Me.TxtMaloaicv.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnHelp, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnVideo, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpDanhmucloaicv, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpNhaploaicongviec, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 461)
        Me.TableLayoutPanel1.TabIndex = 53
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(685, 9)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(28, 28)
        Me.btnHelp.TabIndex = 104
        Me.btnHelp.Tag = "CMMS!frmLoaicongviec"
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(655, 9)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(28, 28)
        Me.btnVideo.TabIndex = 103
        Me.btnVideo.Tag = "CMMS!frmLoaicongviec"
        '
        'frmLoaicongviec
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TxtMaloaicv)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmLoaicongviec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loại công việc"
        Me.GrpDanhmucloaicv.ResumeLayout(False)
        CType(Me.grdLCV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvLCV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhaploaicongviec.ResumeLayout(False)
        Me.GrpNhaploaicongviec.PerformLayout()
        CType(Me.txtTenAnh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTenloaicv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.TxtMaloaicv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhmucloaicv As System.Windows.Forms.GroupBox
    Friend WithEvents GrpNhaploaicongviec As System.Windows.Forms.GroupBox
    Friend WithEvents LblTenloaicongviec As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtTenloaicv As Commons.utcTextBox
    Friend WithEvents TxtMaloaicv As Commons.utcTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdLCV As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvLCV As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtTenAnh As Commons.utcTextBox
    Friend WithEvents lblTenAnh As Label
End Class
