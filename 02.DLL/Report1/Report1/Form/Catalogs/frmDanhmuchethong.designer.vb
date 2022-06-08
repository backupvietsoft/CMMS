<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDanhmuchethong
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.lblNoLine = New DevExpress.XtraEditors.LabelControl()
        Me.LblTenHT = New DevExpress.XtraEditors.LabelControl()
        Me.lblMSHThong = New DevExpress.XtraEditors.LabelControl()
        Me.txtMSHThong = New DevExpress.XtraEditors.TextEdit()
        Me.lblGhiChu = New DevExpress.XtraEditors.LabelControl()
        Me.txtGhiChu = New DevExpress.XtraEditors.TextEdit()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.chkNoLine = New DevExpress.XtraEditors.CheckEdit()
        Me.lblTHTAnh = New DevExpress.XtraEditors.LabelControl()
        Me.TxtTenHT = New DevExpress.XtraEditors.TextEdit()
        Me.TxtTenHTAnh = New DevExpress.XtraEditors.TextEdit()
        Me.lblTHTHoa = New DevExpress.XtraEditors.LabelControl()
        Me.TxtTenHTHoa = New DevExpress.XtraEditors.TextEdit()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTKiem = New DevExpress.XtraEditors.TextEdit()
        Me.grdHThong = New DevExpress.XtraGrid.GridControl()
        Me.grvHThong = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtMaHT = New DevExpress.XtraEditors.TextEdit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMSHThong.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGhiChu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.chkNoLine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTenHT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTenHTAnh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTenHTHoa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtTKiem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdHThong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvHThong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMaHT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Location = New System.Drawing.Point(684, 2)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 6
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Location = New System.Drawing.Point(894, 2)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 10
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Location = New System.Drawing.Point(999, 2)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 11
        Me.BtnKhongghi.Text = "&Không"
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Location = New System.Drawing.Point(789, 2)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 7
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Location = New System.Drawing.Point(999, 2)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 9
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Location = New System.Drawing.Point(894, 2)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 8
        Me.BtnXoa.Text = "&Xóa"
        '
        'lblNoLine
        '
        Me.lblNoLine.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblNoLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNoLine.Location = New System.Drawing.Point(332, 11)
        Me.lblNoLine.Name = "lblNoLine"
        Me.lblNoLine.Size = New System.Drawing.Size(104, 19)
        Me.lblNoLine.TabIndex = 5
        Me.lblNoLine.Text = "lblNoLine"
        '
        'LblTenHT
        '
        Me.LblTenHT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LblTenHT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTenHT.Location = New System.Drawing.Point(557, 11)
        Me.LblTenHT.Name = "LblTenHT"
        Me.LblTenHT.Size = New System.Drawing.Size(104, 19)
        Me.LblTenHT.TabIndex = 5
        Me.LblTenHT.Text = "Tên hệ thống"
        '
        'lblMSHThong
        '
        Me.lblMSHThong.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblMSHThong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMSHThong.Location = New System.Drawing.Point(107, 11)
        Me.lblMSHThong.Name = "lblMSHThong"
        Me.lblMSHThong.Size = New System.Drawing.Size(104, 19)
        Me.lblMSHThong.TabIndex = 5
        Me.lblMSHThong.Text = "lblMSHThong"
        '
        'txtMSHThong
        '
        Me.txtMSHThong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMSHThong.Location = New System.Drawing.Point(217, 11)
        Me.txtMSHThong.Name = "txtMSHThong"
        Me.txtMSHThong.Properties.ReadOnly = True
        Me.txtMSHThong.Size = New System.Drawing.Size(109, 20)
        Me.txtMSHThong.TabIndex = 1
        '
        'lblGhiChu
        '
        Me.lblGhiChu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGhiChu.Location = New System.Drawing.Point(107, 61)
        Me.lblGhiChu.Name = "lblGhiChu"
        Me.lblGhiChu.Size = New System.Drawing.Size(104, 19)
        Me.lblGhiChu.TabIndex = 5
        Me.lblGhiChu.Text = "lblGhiChu"
        '
        'txtGhiChu
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtGhiChu, 7)
        Me.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGhiChu.Location = New System.Drawing.Point(217, 61)
        Me.txtGhiChu.Name = "txtGhiChu"
        Me.txtGhiChu.Properties.ReadOnly = True
        Me.txtGhiChu.Size = New System.Drawing.Size(784, 20)
        Me.txtGhiChu.TabIndex = 4
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 16
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0!))
        Me.TableLayoutPanel1.Controls.Add(Me.chkNoLine, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNoLine, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMSHThong, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMSHThong, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblTenHT, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTHTAnh, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTenHT, 9, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTenHTAnh, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTHTHoa, 8, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTenHTHoa, 9, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGhiChu, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGhiChu, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.grdHThong, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnHelp, 13, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnVideo, 14, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtMaHT, 12, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1111, 680)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'chkNoLine
        '
        Me.chkNoLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkNoLine.Location = New System.Drawing.Point(442, 11)
        Me.chkNoLine.Name = "chkNoLine"
        Me.chkNoLine.Size = New System.Drawing.Size(109, 18)
        Me.chkNoLine.TabIndex = 3
        '
        'lblTHTAnh
        '
        Me.lblTHTAnh.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTHTAnh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTHTAnh.Location = New System.Drawing.Point(107, 36)
        Me.lblTHTAnh.Name = "lblTHTAnh"
        Me.lblTHTAnh.Size = New System.Drawing.Size(104, 19)
        Me.lblTHTAnh.TabIndex = 5
        Me.lblTHTAnh.Text = "lblTHTAnh"
        '
        'TxtTenHT
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtTenHT, 3)
        Me.TxtTenHT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTenHT.Location = New System.Drawing.Point(667, 11)
        Me.TxtTenHT.Name = "TxtTenHT"
        Me.TxtTenHT.Properties.ReadOnly = True
        Me.TxtTenHT.Size = New System.Drawing.Size(334, 20)
        Me.TxtTenHT.TabIndex = 1
        '
        'TxtTenHTAnh
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtTenHTAnh, 3)
        Me.TxtTenHTAnh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTenHTAnh.Location = New System.Drawing.Point(217, 36)
        Me.TxtTenHTAnh.Name = "TxtTenHTAnh"
        Me.TxtTenHTAnh.Properties.ReadOnly = True
        Me.TxtTenHTAnh.Size = New System.Drawing.Size(334, 20)
        Me.TxtTenHTAnh.TabIndex = 1
        '
        'lblTHTHoa
        '
        Me.lblTHTHoa.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTHTHoa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTHTHoa.Location = New System.Drawing.Point(557, 36)
        Me.lblTHTHoa.Name = "lblTHTHoa"
        Me.lblTHTHoa.Size = New System.Drawing.Size(104, 19)
        Me.lblTHTHoa.TabIndex = 5
        Me.lblTHTHoa.Text = "lblTHTHoa"
        '
        'TxtTenHTHoa
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtTenHTHoa, 3)
        Me.TxtTenHTHoa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTenHTHoa.Location = New System.Drawing.Point(667, 36)
        Me.TxtTenHTHoa.Name = "TxtTenHTHoa"
        Me.TxtTenHTHoa.Properties.ReadOnly = True
        Me.TxtTenHTHoa.Size = New System.Drawing.Size(334, 20)
        Me.TxtTenHTHoa.TabIndex = 1
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 16)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.txtTKiem)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 642)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1105, 35)
        Me.Panel1.TabIndex = 54
        '
        'txtTKiem
        '
        Me.txtTKiem.Location = New System.Drawing.Point(3, 12)
        Me.txtTKiem.Name = "txtTKiem"
        Me.txtTKiem.Size = New System.Drawing.Size(205, 20)
        Me.txtTKiem.TabIndex = 1
        '
        'grdHThong
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdHThong, 16)
        Me.grdHThong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdHThong.Location = New System.Drawing.Point(3, 90)
        Me.grdHThong.MainView = Me.grvHThong
        Me.grdHThong.Name = "grdHThong"
        Me.grdHThong.Size = New System.Drawing.Size(1105, 546)
        Me.grdHThong.TabIndex = 98
        Me.grdHThong.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvHThong})
        '
        'grvHThong
        '
        Me.grvHThong.GridControl = Me.grdHThong
        Me.grvHThong.Name = "grvHThong"
        Me.grvHThong.OptionsView.ShowGroupPanel = False
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(1051, 9)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(27, 23)
        Me.btnHelp.TabIndex = 96
        Me.btnHelp.Tag = "CMMS!frmDanhmuchethong"
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(1080, 9)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(27, 23)
        Me.btnVideo.TabIndex = 97
        Me.btnVideo.Tag = "CMMS!frmDanhmuchethong"
        '
        'TxtMaHT
        '
        Me.TxtMaHT.Location = New System.Drawing.Point(1007, 11)
        Me.TxtMaHT.Name = "TxtMaHT"
        Me.TxtMaHT.Properties.ReadOnly = True
        Me.TxtMaHT.Size = New System.Drawing.Size(14, 20)
        Me.TxtMaHT.TabIndex = 52
        Me.TxtMaHT.Visible = False
        '
        'frmDanhmuchethong
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1111, 680)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDanhmuchethong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh mục hệ thống"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMSHThong.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGhiChu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.chkNoLine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTenHT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTenHTAnh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTenHTHoa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtTKiem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdHThong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvHThong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMaHT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents TxtMaHT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LblTenHT As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblNoLine As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblGhiChu As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtGhiChu As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblMSHThong As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMSHThong As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTHTAnh As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtTenHT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtTenHTAnh As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblTHTHoa As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtTenHTHoa As DevExpress.XtraEditors.TextEdit
    Friend WithEvents grdHThong As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvHThong As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkNoLine As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtTKiem As DevExpress.XtraEditors.TextEdit
End Class
