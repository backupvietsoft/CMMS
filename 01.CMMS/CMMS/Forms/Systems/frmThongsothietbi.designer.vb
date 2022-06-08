<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongsothietbi
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
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhmucthongsoTB = New System.Windows.Forms.GroupBox()
        Me.GrpNhapthongsoTB = New System.Windows.Forms.GroupBox()
        Me.txtGhichu = New DevExpress.XtraEditors.TextEdit()
        Me.lblGhichu = New System.Windows.Forms.Label()
        Me.lblDonvido = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider()
        Me.TxtTenthongsoTB = New DevExpress.XtraEditors.TextEdit()
        Me.LblTenthongsoTB = New System.Windows.Forms.Label()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.LblTieudethongsoTB = New System.Windows.Forms.Label()
        Me.TxtMaso = New DevExpress.XtraEditors.TextEdit()
        Me.grdThongSo = New DevExpress.XtraGrid.GridControl()
        Me.grvThongSo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cboDonvido = New DevExpress.XtraEditors.LookUpEdit()
        Me.GrpDanhmucthongsoTB.SuspendLayout()
        Me.GrpNhapthongsoTB.SuspendLayout()
        CType(Me.txtGhichu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTenthongsoTB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMaso.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdThongSo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvThongSo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDonvido.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Location = New System.Drawing.Point(154, 369)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 5
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Location = New System.Drawing.Point(364, 369)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 9
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Location = New System.Drawing.Point(469, 369)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 8
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Location = New System.Drawing.Point(469, 369)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 10
        Me.BtnKhongghi.Text = "&Không"
        '
        'GrpDanhmucthongsoTB
        '
        Me.GrpDanhmucthongsoTB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDanhmucthongsoTB.Controls.Add(Me.grdThongSo)
        Me.GrpDanhmucthongsoTB.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhmucthongsoTB.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhmucthongsoTB.Location = New System.Drawing.Point(11, 161)
        Me.GrpDanhmucthongsoTB.Name = "GrpDanhmucthongsoTB"
        Me.GrpDanhmucthongsoTB.Size = New System.Drawing.Size(564, 205)
        Me.GrpDanhmucthongsoTB.TabIndex = 90
        Me.GrpDanhmucthongsoTB.TabStop = False
        Me.GrpDanhmucthongsoTB.Text = "Danh mục thông số thiết bị"
        '
        'GrpNhapthongsoTB
        '
        Me.GrpNhapthongsoTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNhapthongsoTB.Controls.Add(Me.cboDonvido)
        Me.GrpNhapthongsoTB.Controls.Add(Me.txtGhichu)
        Me.GrpNhapthongsoTB.Controls.Add(Me.lblGhichu)
        Me.GrpNhapthongsoTB.Controls.Add(Me.lblDonvido)
        Me.GrpNhapthongsoTB.Controls.Add(Me.TxtTenthongsoTB)
        Me.GrpNhapthongsoTB.Controls.Add(Me.LblTenthongsoTB)
        Me.GrpNhapthongsoTB.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapthongsoTB.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapthongsoTB.Location = New System.Drawing.Point(67, 45)
        Me.GrpNhapthongsoTB.Name = "GrpNhapthongsoTB"
        Me.GrpNhapthongsoTB.Size = New System.Drawing.Size(439, 100)
        Me.GrpNhapthongsoTB.TabIndex = 89
        Me.GrpNhapthongsoTB.TabStop = False
        Me.GrpNhapthongsoTB.Text = "Nhập thông số thiết bị"
        '
        'txtGhichu
        '
        Me.txtGhichu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGhichu.Location = New System.Drawing.Point(144, 71)
        Me.txtGhichu.Name = "txtGhichu"
        Me.txtGhichu.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtGhichu.Properties.Appearance.Options.UseBackColor = True
        Me.txtGhichu.Size = New System.Drawing.Size(271, 20)
        Me.txtGhichu.TabIndex = 3
        '
        'lblGhichu
        '
        Me.lblGhichu.AutoSize = True
        Me.lblGhichu.ForeColor = System.Drawing.Color.Black
        Me.lblGhichu.Location = New System.Drawing.Point(20, 72)
        Me.lblGhichu.Name = "lblGhichu"
        Me.lblGhichu.Size = New System.Drawing.Size(42, 13)
        Me.lblGhichu.TabIndex = 73
        Me.lblGhichu.Text = "Ghi chú"
        '
        'lblDonvido
        '
        Me.lblDonvido.AutoSize = True
        Me.lblDonvido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDonvido.ForeColor = System.Drawing.Color.Black
        Me.lblDonvido.Location = New System.Drawing.Point(20, 49)
        Me.lblDonvido.Name = "lblDonvido"
        Me.lblDonvido.Size = New System.Drawing.Size(60, 13)
        Me.lblDonvido.TabIndex = 72
        Me.lblDonvido.Text = "Đơn vị đo"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TxtTenthongsoTB
        '
        Me.TxtTenthongsoTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTenthongsoTB.Location = New System.Drawing.Point(144, 23)
        Me.TxtTenthongsoTB.Name = "TxtTenthongsoTB"
        Me.TxtTenthongsoTB.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtTenthongsoTB.Properties.Appearance.Options.UseBackColor = True
        Me.TxtTenthongsoTB.Size = New System.Drawing.Size(271, 20)
        Me.TxtTenthongsoTB.TabIndex = 1
        '
        'LblTenthongsoTB
        '
        Me.LblTenthongsoTB.AutoSize = True
        Me.LblTenthongsoTB.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTenthongsoTB.ForeColor = System.Drawing.Color.Black
        Me.LblTenthongsoTB.Location = New System.Drawing.Point(20, 27)
        Me.LblTenthongsoTB.Name = "LblTenthongsoTB"
        Me.LblTenthongsoTB.Size = New System.Drawing.Size(80, 13)
        Me.LblTenthongsoTB.TabIndex = 5
        Me.LblTenthongsoTB.Text = "Tên thông số"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Location = New System.Drawing.Point(364, 369)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 7
        Me.BtnXoa.Text = "&Xóa"
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Location = New System.Drawing.Point(259, 369)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 6
        Me.BtnSua.Text = "&Sửa"
        '
        'LblTieudethongsoTB
        '
        Me.LblTieudethongsoTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTieudethongsoTB.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieudethongsoTB.ForeColor = System.Drawing.Color.Navy
        Me.LblTieudethongsoTB.Location = New System.Drawing.Point(13, 9)
        Me.LblTieudethongsoTB.Name = "LblTieudethongsoTB"
        Me.LblTieudethongsoTB.Size = New System.Drawing.Size(560, 23)
        Me.LblTieudethongsoTB.TabIndex = 96
        Me.LblTieudethongsoTB.Text = "THOÂNG SOÁ THIEÁT BÒ"
        Me.LblTieudethongsoTB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtMaso
        '
        Me.TxtMaso.Location = New System.Drawing.Point(11, 3)
        Me.TxtMaso.Name = "TxtMaso"
        Me.TxtMaso.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtMaso.Properties.Appearance.Options.UseBackColor = True
        Me.TxtMaso.Size = New System.Drawing.Size(12, 20)
        Me.TxtMaso.TabIndex = 69
        Me.TxtMaso.Visible = False
        '
        'grdThongSo
        '
        Me.grdThongSo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdThongSo.Location = New System.Drawing.Point(3, 17)
        Me.grdThongSo.LookAndFeel.SkinName = "Blue"
        Me.grdThongSo.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdThongSo.MainView = Me.grvThongSo
        Me.grdThongSo.Name = "grdThongSo"
        Me.grdThongSo.Size = New System.Drawing.Size(558, 185)
        Me.grdThongSo.TabIndex = 26
        Me.grdThongSo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvThongSo, Me.GridView7})
        '
        'grvThongSo
        '
        Me.grvThongSo.GridControl = Me.grdThongSo
        Me.grvThongSo.Name = "grvThongSo"
        Me.grvThongSo.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvThongSo.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvThongSo.OptionsBehavior.Editable = False
        Me.grvThongSo.OptionsLayout.Columns.AddNewColumns = False
        Me.grvThongSo.OptionsLayout.Columns.RemoveOldColumns = False
        Me.grvThongSo.OptionsView.ColumnAutoWidth = False
        Me.grvThongSo.OptionsView.ShowGroupPanel = False
        '
        'GridView7
        '
        Me.GridView7.GridControl = Me.grdThongSo
        Me.GridView7.Name = "GridView7"
        '
        'cboDonvido
        '
        Me.cboDonvido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDonvido.Location = New System.Drawing.Point(144, 47)
        Me.cboDonvido.Name = "cboDonvido"
        Me.cboDonvido.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboDonvido.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.cboDonvido.Properties.DropDownRows = 3
        Me.cboDonvido.Properties.NullText = ""
        Me.cboDonvido.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.cboDonvido.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboDonvido.Size = New System.Drawing.Size(271, 20)
        Me.cboDonvido.TabIndex = 97
        '
        'frmThongsothietbi
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 404)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.GrpDanhmucthongsoTB)
        Me.Controls.Add(Me.GrpNhapthongsoTB)
        Me.Controls.Add(Me.TxtMaso)
        Me.Controls.Add(Me.LblTieudethongsoTB)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmThongsothietbi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thông số máy"
        Me.GrpDanhmucthongsoTB.ResumeLayout(False)
        Me.GrpNhapthongsoTB.ResumeLayout(False)
        Me.GrpNhapthongsoTB.PerformLayout()
        CType(Me.txtGhichu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTenthongsoTB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMaso.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdThongSo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvThongSo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDonvido.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhmucthongsoTB As System.Windows.Forms.GroupBox
    Friend WithEvents GrpNhapthongsoTB As System.Windows.Forms.GroupBox
    Friend WithEvents txtGhichu As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LblTieudethongsoTB As System.Windows.Forms.Label
    Friend WithEvents lblGhichu As System.Windows.Forms.Label
    Friend WithEvents lblDonvido As System.Windows.Forms.Label
    Friend WithEvents TxtTenthongsoTB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtMaso As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LblTenthongsoTB As System.Windows.Forms.Label
    Friend WithEvents grdThongSo As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvThongSo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboDonvido As DevExpress.XtraEditors.LookUpEdit
End Class
