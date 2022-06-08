<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNguyenNhanNgungMay
    'Inherits System.Windows.Forms.Form
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTieudeDowtimeCause = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSTT = New System.Windows.Forms.TextBox()
        Me.BtnKhongGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.groDSNguyenNhan = New DevExpress.XtraEditors.GroupControl()
        Me.grdDowtimeCause = New DevExpress.XtraGrid.GridControl()
        Me.grvDowtimeCause = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblTenNN = New DevExpress.XtraEditors.LabelControl()
        Me.lblTenNN_A = New DevExpress.XtraEditors.LabelControl()
        Me.lblTenLoaiNN = New DevExpress.XtraEditors.LabelControl()
        Me.txtTenNN = New DevExpress.XtraEditors.TextEdit()
        Me.txtTenNN_A = New DevExpress.XtraEditors.TextEdit()
        Me.chkActive = New DevExpress.XtraEditors.CheckEdit()
        Me.chkMacDinh = New DevExpress.XtraEditors.CheckEdit()
        Me.rdoLyDo = New DevExpress.XtraEditors.RadioGroup()
        Me.cboLoaiNN = New DevExpress.XtraEditors.LookUpEdit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.groDSNguyenNhan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groDSNguyenNhan.SuspendLayout()
        CType(Me.grdDowtimeCause, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvDowtimeCause, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTenNN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTenNN_A.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMacDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdoLyDo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLoaiNN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieudeDowtimeCause, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.groDSNguyenNhan, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTenNN, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTenNN_A, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTenLoaiNN, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTenNN, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTenNN_A, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.chkActive, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.chkMacDinh, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.rdoLyDo, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiNN, 2, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblTieudeDowtimeCause
        '
        Me.lblTieudeDowtimeCause.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieudeDowtimeCause, 6)
        Me.lblTieudeDowtimeCause.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieudeDowtimeCause.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTieudeDowtimeCause.ForeColor = System.Drawing.Color.Navy
        Me.lblTieudeDowtimeCause.Location = New System.Drawing.Point(1, 0)
        Me.lblTieudeDowtimeCause.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblTieudeDowtimeCause.Name = "lblTieudeDowtimeCause"
        Me.lblTieudeDowtimeCause.Size = New System.Drawing.Size(882, 40)
        Me.lblTieudeDowtimeCause.TabIndex = 0
        Me.lblTieudeDowtimeCause.Text = "Nguyên Nhân Ngừng Máy"
        Me.lblTieudeDowtimeCause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 6)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Controls.Add(Me.txtSTT)
        Me.Panel1.Controls.Add(Me.BtnKhongGhi)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 522)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(882, 38)
        Me.Panel1.TabIndex = 9
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Location = New System.Drawing.Point(460, 6)
        Me.BtnThem.LookAndFeel.SkinName = "Blue"
        Me.BtnThem.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 11
        Me.BtnThem.Text = "Thêm"
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Location = New System.Drawing.Point(565, 6)
        Me.BtnSua.LookAndFeel.SkinName = "Blue"
        Me.BtnSua.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 10
        Me.BtnSua.Text = "Sửa"
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Appearance.Options.UseFont = True
        Me.btnThoat.Location = New System.Drawing.Point(775, 6)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 8
        Me.btnThoat.Text = "Thoát"
        '
        'txtSTT
        '
        Me.txtSTT.Location = New System.Drawing.Point(2, 15)
        Me.txtSTT.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSTT.Name = "txtSTT"
        Me.txtSTT.Size = New System.Drawing.Size(40, 21)
        Me.txtSTT.TabIndex = 6
        Me.txtSTT.Visible = False
        '
        'BtnKhongGhi
        '
        Me.BtnKhongGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongGhi.Appearance.Options.UseFont = True
        Me.BtnKhongGhi.Location = New System.Drawing.Point(775, 6)
        Me.BtnKhongGhi.LookAndFeel.SkinName = "Blue"
        Me.BtnKhongGhi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnKhongGhi.Name = "BtnKhongGhi"
        Me.BtnKhongGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongGhi.TabIndex = 12
        Me.BtnKhongGhi.Text = "Không Ghi"
        Me.BtnKhongGhi.Visible = False
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Location = New System.Drawing.Point(670, 6)
        Me.BtnXoa.LookAndFeel.SkinName = "Blue"
        Me.BtnXoa.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 9
        Me.BtnXoa.Text = "Xóa"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Location = New System.Drawing.Point(670, 6)
        Me.BtnGhi.LookAndFeel.SkinName = "Blue"
        Me.BtnGhi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 13
        Me.BtnGhi.Text = "Ghi"
        Me.BtnGhi.Visible = False
        '
        'groDSNguyenNhan
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.groDSNguyenNhan, 6)
        Me.groDSNguyenNhan.Controls.Add(Me.grdDowtimeCause)
        Me.groDSNguyenNhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groDSNguyenNhan.Location = New System.Drawing.Point(3, 118)
        Me.groDSNguyenNhan.Name = "groDSNguyenNhan"
        Me.groDSNguyenNhan.Size = New System.Drawing.Size(878, 400)
        Me.groDSNguyenNhan.TabIndex = 10
        Me.groDSNguyenNhan.Text = "groDSNguyenNhan"
        '
        'grdDowtimeCause
        '
        Me.grdDowtimeCause.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDowtimeCause.Location = New System.Drawing.Point(2, 22)
        Me.grdDowtimeCause.LookAndFeel.SkinName = "Blue"
        Me.grdDowtimeCause.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdDowtimeCause.MainView = Me.grvDowtimeCause
        Me.grdDowtimeCause.Name = "grdDowtimeCause"
        Me.grdDowtimeCause.Size = New System.Drawing.Size(874, 376)
        Me.grdDowtimeCause.TabIndex = 3
        Me.grdDowtimeCause.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvDowtimeCause})
        '
        'grvDowtimeCause
        '
        Me.grvDowtimeCause.GridControl = Me.grdDowtimeCause
        Me.grvDowtimeCause.Name = "grvDowtimeCause"
        Me.grvDowtimeCause.OptionsCustomization.AllowGroup = False
        Me.grvDowtimeCause.OptionsView.ShowGroupPanel = False
        '
        'lblTenNN
        '
        Me.lblTenNN.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTenNN.Appearance.Options.UseFont = True
        Me.lblTenNN.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTenNN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenNN.Location = New System.Drawing.Point(53, 43)
        Me.lblTenNN.Name = "lblTenNN"
        Me.lblTenNN.Size = New System.Drawing.Size(114, 19)
        Me.lblTenNN.TabIndex = 11
        Me.lblTenNN.Text = "lblTenLoaiNN"
        '
        'lblTenNN_A
        '
        Me.lblTenNN_A.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTenNN_A.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenNN_A.Location = New System.Drawing.Point(53, 68)
        Me.lblTenNN_A.Name = "lblTenNN_A"
        Me.lblTenNN_A.Size = New System.Drawing.Size(114, 19)
        Me.lblTenNN_A.TabIndex = 11
        Me.lblTenNN_A.Text = "lblTenLoaiNN_A"
        '
        'lblTenLoaiNN
        '
        Me.lblTenLoaiNN.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTenLoaiNN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenLoaiNN.Location = New System.Drawing.Point(53, 93)
        Me.lblTenLoaiNN.Name = "lblTenLoaiNN"
        Me.lblTenLoaiNN.Size = New System.Drawing.Size(114, 19)
        Me.lblTenLoaiNN.TabIndex = 11
        Me.lblTenLoaiNN.Text = "lblTenLoaiNN"
        '
        'txtTenNN
        '
        Me.txtTenNN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTenNN.Location = New System.Drawing.Point(173, 43)
        Me.txtTenNN.Name = "txtTenNN"
        Me.txtTenNN.Size = New System.Drawing.Size(215, 20)
        Me.txtTenNN.TabIndex = 12
        '
        'txtTenNN_A
        '
        Me.txtTenNN_A.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTenNN_A.Location = New System.Drawing.Point(173, 68)
        Me.txtTenNN_A.Name = "txtTenNN_A"
        Me.txtTenNN_A.Size = New System.Drawing.Size(215, 20)
        Me.txtTenNN_A.TabIndex = 12
        '
        'chkActive
        '
        Me.chkActive.Location = New System.Drawing.Point(616, 69)
        Me.chkActive.Margin = New System.Windows.Forms.Padding(4)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Properties.Caption = "chkActive"
        Me.chkActive.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkActive.Size = New System.Drawing.Size(213, 18)
        Me.chkActive.TabIndex = 13
        '
        'chkMacDinh
        '
        Me.chkMacDinh.Location = New System.Drawing.Point(395, 69)
        Me.chkMacDinh.Margin = New System.Windows.Forms.Padding(4)
        Me.chkMacDinh.Name = "chkMacDinh"
        Me.chkMacDinh.Properties.Caption = "chkMacDinh"
        Me.chkMacDinh.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkMacDinh.Size = New System.Drawing.Size(213, 18)
        Me.chkMacDinh.TabIndex = 13
        '
        'rdoLyDo
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.rdoLyDo, 2)
        Me.rdoLyDo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoLyDo.Location = New System.Drawing.Point(391, 40)
        Me.rdoLyDo.Margin = New System.Windows.Forms.Padding(0)
        Me.rdoLyDo.Name = "rdoLyDo"
        Me.rdoLyDo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.rdoLyDo.Properties.Appearance.Options.UseBackColor = True
        Me.rdoLyDo.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "HuHong"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "BTDK")})
        Me.rdoLyDo.Size = New System.Drawing.Size(442, 25)
        Me.rdoLyDo.TabIndex = 14
        '
        'cboLoaiNN
        '
        Me.cboLoaiNN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiNN.Location = New System.Drawing.Point(173, 93)
        Me.cboLoaiNN.Name = "cboLoaiNN"
        Me.cboLoaiNN.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLoaiNN.Properties.NullText = ""
        Me.cboLoaiNN.Size = New System.Drawing.Size(215, 20)
        Me.cboLoaiNN.TabIndex = 15
        '
        'frmNguyenNhanNgungMay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "frmNguyenNhanNgungMay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNguyenNhanNgungMay"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.groDSNguyenNhan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groDSNguyenNhan.ResumeLayout(False)
        CType(Me.grdDowtimeCause, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvDowtimeCause, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTenNN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTenNN_A.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMacDinh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdoLyDo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLoaiNN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GrpCa As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSTT As TextBox
    Private WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnKhongGhi As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Private WithEvents grdDowtimeCause As DevExpress.XtraGrid.GridControl
    Private WithEvents grvDowtimeCause As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblTieudeDowtimeCause As Label
    Friend WithEvents groDSNguyenNhan As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblTenNN As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTenNN_A As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTenLoaiNN As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTenNN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTenNN_A As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkMacDinh As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rdoLyDo As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents cboLoaiNN As DevExpress.XtraEditors.LookUpEdit
End Class
