<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDowtimeType
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
        Me.lblTieudeDowtimeType = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSTT = New System.Windows.Forms.TextBox()
        Me.BtnKhongGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.groDSLoaiNguyenNhan = New DevExpress.XtraEditors.GroupControl()
        Me.grdDowtimeType = New DevExpress.XtraGrid.GridControl()
        Me.grvDowtimeType = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblTenLoaiNN = New DevExpress.XtraEditors.LabelControl()
        Me.lblTenLoaiNN_A = New DevExpress.XtraEditors.LabelControl()
        Me.lblTenLoaiNN_H = New DevExpress.XtraEditors.LabelControl()
        Me.lblGhiChu = New DevExpress.XtraEditors.LabelControl()
        Me.lblKeHoach = New DevExpress.XtraEditors.LabelControl()
        Me.lblHieuLuc = New DevExpress.XtraEditors.LabelControl()
        Me.txtTenLoaiNN = New DevExpress.XtraEditors.TextEdit()
        Me.txtTenLoaiNN_A = New DevExpress.XtraEditors.TextEdit()
        Me.txtTenLoaiNN_H = New DevExpress.XtraEditors.TextEdit()
        Me.txtGhiChu = New DevExpress.XtraEditors.TextEdit()
        Me.chkKeHoach = New DevExpress.XtraEditors.CheckEdit()
        Me.chkHieuLuc = New DevExpress.XtraEditors.CheckEdit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.groDSLoaiNguyenNhan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groDSLoaiNguyenNhan.SuspendLayout()
        CType(Me.grdDowtimeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvDowtimeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTenLoaiNN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTenLoaiNN_A.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTenLoaiNN_H.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGhiChu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkKeHoach.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHieuLuc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieudeDowtimeType, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.groDSLoaiNguyenNhan, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTenLoaiNN, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTenLoaiNN_A, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTenLoaiNN_H, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGhiChu, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblKeHoach, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHieuLuc, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTenLoaiNN, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTenLoaiNN_A, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTenLoaiNN_H, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGhiChu, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chkKeHoach, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.chkHieuLuc, 4, 3)
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
        'lblTieudeDowtimeType
        '
        Me.lblTieudeDowtimeType.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieudeDowtimeType, 6)
        Me.lblTieudeDowtimeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieudeDowtimeType.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTieudeDowtimeType.ForeColor = System.Drawing.Color.Navy
        Me.lblTieudeDowtimeType.Location = New System.Drawing.Point(1, 0)
        Me.lblTieudeDowtimeType.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblTieudeDowtimeType.Name = "lblTieudeDowtimeType"
        Me.lblTieudeDowtimeType.Size = New System.Drawing.Size(882, 40)
        Me.lblTieudeDowtimeType.TabIndex = 0
        Me.lblTieudeDowtimeType.Text = "Loại Nguyên Nhân"
        Me.lblTieudeDowtimeType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'groDSLoaiNguyenNhan
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.groDSLoaiNguyenNhan, 6)
        Me.groDSLoaiNguyenNhan.Controls.Add(Me.grdDowtimeType)
        Me.groDSLoaiNguyenNhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groDSLoaiNguyenNhan.Location = New System.Drawing.Point(3, 118)
        Me.groDSLoaiNguyenNhan.Name = "groDSLoaiNguyenNhan"
        Me.groDSLoaiNguyenNhan.Size = New System.Drawing.Size(878, 400)
        Me.groDSLoaiNguyenNhan.TabIndex = 10
        Me.groDSLoaiNguyenNhan.Text = "groDSLoaiNguyenNhan"
        '
        'grdDowtimeType
        '
        Me.grdDowtimeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDowtimeType.Location = New System.Drawing.Point(2, 22)
        Me.grdDowtimeType.LookAndFeel.SkinName = "Blue"
        Me.grdDowtimeType.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdDowtimeType.MainView = Me.grvDowtimeType
        Me.grdDowtimeType.Name = "grdDowtimeType"
        Me.grdDowtimeType.Size = New System.Drawing.Size(874, 376)
        Me.grdDowtimeType.TabIndex = 3
        Me.grdDowtimeType.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvDowtimeType})
        '
        'grvDowtimeType
        '
        Me.grvDowtimeType.GridControl = Me.grdDowtimeType
        Me.grvDowtimeType.Name = "grvDowtimeType"
        Me.grvDowtimeType.OptionsCustomization.AllowGroup = False
        Me.grvDowtimeType.OptionsView.ShowGroupPanel = False
        '
        'lblTenLoaiNN
        '
        Me.lblTenLoaiNN.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTenLoaiNN.Appearance.Options.UseFont = True
        Me.lblTenLoaiNN.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTenLoaiNN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenLoaiNN.Location = New System.Drawing.Point(53, 43)
        Me.lblTenLoaiNN.Name = "lblTenLoaiNN"
        Me.lblTenLoaiNN.Size = New System.Drawing.Size(114, 19)
        Me.lblTenLoaiNN.TabIndex = 11
        Me.lblTenLoaiNN.Text = "lblTenLoaiNN"
        '
        'lblTenLoaiNN_A
        '
        Me.lblTenLoaiNN_A.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTenLoaiNN_A.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenLoaiNN_A.Location = New System.Drawing.Point(53, 68)
        Me.lblTenLoaiNN_A.Name = "lblTenLoaiNN_A"
        Me.lblTenLoaiNN_A.Size = New System.Drawing.Size(114, 19)
        Me.lblTenLoaiNN_A.TabIndex = 11
        Me.lblTenLoaiNN_A.Text = "lblTenLoaiNN_A"
        '
        'lblTenLoaiNN_H
        '
        Me.lblTenLoaiNN_H.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTenLoaiNN_H.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenLoaiNN_H.Location = New System.Drawing.Point(53, 93)
        Me.lblTenLoaiNN_H.Name = "lblTenLoaiNN_H"
        Me.lblTenLoaiNN_H.Size = New System.Drawing.Size(114, 19)
        Me.lblTenLoaiNN_H.TabIndex = 11
        Me.lblTenLoaiNN_H.Text = "lblTenLoaiNN_H"
        '
        'lblGhiChu
        '
        Me.lblGhiChu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGhiChu.Location = New System.Drawing.Point(445, 43)
        Me.lblGhiChu.Name = "lblGhiChu"
        Me.lblGhiChu.Size = New System.Drawing.Size(114, 19)
        Me.lblGhiChu.TabIndex = 11
        Me.lblGhiChu.Text = "lblGhiChu"
        '
        'lblKeHoach
        '
        Me.lblKeHoach.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblKeHoach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKeHoach.Location = New System.Drawing.Point(445, 68)
        Me.lblKeHoach.Name = "lblKeHoach"
        Me.lblKeHoach.Size = New System.Drawing.Size(114, 19)
        Me.lblKeHoach.TabIndex = 11
        Me.lblKeHoach.Text = "lblKeHoach"
        '
        'lblHieuLuc
        '
        Me.lblHieuLuc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblHieuLuc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHieuLuc.Location = New System.Drawing.Point(445, 93)
        Me.lblHieuLuc.Name = "lblHieuLuc"
        Me.lblHieuLuc.Size = New System.Drawing.Size(114, 19)
        Me.lblHieuLuc.TabIndex = 11
        Me.lblHieuLuc.Text = "lblHieuLuc"
        '
        'txtTenLoaiNN
        '
        Me.txtTenLoaiNN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTenLoaiNN.Location = New System.Drawing.Point(173, 43)
        Me.txtTenLoaiNN.Name = "txtTenLoaiNN"
        Me.txtTenLoaiNN.Size = New System.Drawing.Size(266, 20)
        Me.txtTenLoaiNN.TabIndex = 12
        '
        'txtTenLoaiNN_A
        '
        Me.txtTenLoaiNN_A.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTenLoaiNN_A.Location = New System.Drawing.Point(173, 68)
        Me.txtTenLoaiNN_A.Name = "txtTenLoaiNN_A"
        Me.txtTenLoaiNN_A.Size = New System.Drawing.Size(266, 20)
        Me.txtTenLoaiNN_A.TabIndex = 12
        '
        'txtTenLoaiNN_H
        '
        Me.txtTenLoaiNN_H.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTenLoaiNN_H.Location = New System.Drawing.Point(173, 93)
        Me.txtTenLoaiNN_H.Name = "txtTenLoaiNN_H"
        Me.txtTenLoaiNN_H.Size = New System.Drawing.Size(266, 20)
        Me.txtTenLoaiNN_H.TabIndex = 12
        '
        'txtGhiChu
        '
        Me.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGhiChu.Location = New System.Drawing.Point(565, 43)
        Me.txtGhiChu.Name = "txtGhiChu"
        Me.txtGhiChu.Size = New System.Drawing.Size(266, 20)
        Me.txtGhiChu.TabIndex = 12
        '
        'chkKeHoach
        '
        Me.chkKeHoach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkKeHoach.Location = New System.Drawing.Point(565, 68)
        Me.chkKeHoach.Name = "chkKeHoach"
        Me.chkKeHoach.Properties.Caption = "CheckEdit1"
        Me.chkKeHoach.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.chkKeHoach.Size = New System.Drawing.Size(266, 16)
        Me.chkKeHoach.TabIndex = 13
        '
        'chkHieuLuc
        '
        Me.chkHieuLuc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkHieuLuc.Location = New System.Drawing.Point(565, 93)
        Me.chkHieuLuc.Name = "chkHieuLuc"
        Me.chkHieuLuc.Properties.Caption = "CheckEdit1"
        Me.chkHieuLuc.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.chkHieuLuc.Size = New System.Drawing.Size(266, 16)
        Me.chkHieuLuc.TabIndex = 13
        '
        'frmDowtimeType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "frmDowtimeType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDowtimeType"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.groDSLoaiNguyenNhan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groDSLoaiNguyenNhan.ResumeLayout(False)
        CType(Me.grdDowtimeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvDowtimeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTenLoaiNN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTenLoaiNN_A.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTenLoaiNN_H.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGhiChu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkKeHoach.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHieuLuc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents grdDowtimeType As DevExpress.XtraGrid.GridControl
    Private WithEvents grvDowtimeType As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblTieudeDowtimeType As Label
    Friend WithEvents groDSLoaiNguyenNhan As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblTenLoaiNN As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTenLoaiNN_A As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTenLoaiNN_H As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblGhiChu As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblKeHoach As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblHieuLuc As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTenLoaiNN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTenLoaiNN_A As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTenLoaiNN_H As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtGhiChu As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkKeHoach As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkHieuLuc As DevExpress.XtraEditors.CheckEdit
End Class
