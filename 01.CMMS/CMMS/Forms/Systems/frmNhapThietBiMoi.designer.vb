<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhapThietBiMoi
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
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.rdDieukien = New System.Windows.Forms.RadioButton()
        Me.lblThongBao = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.grpThongtin = New DevExpress.XtraEditors.GroupControl()
        Me.chkTailieu = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLoaiBTPNCV_PT = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLoaiBTPNcongviec = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLoaiBTPNchuky = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLoaiBTPN = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCautructhietbiGSTT = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCautructhietbicongviec = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCautructhietbiphutung = New DevExpress.XtraEditors.CheckEdit()
        Me.chkThongsobophan = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCautructhietbi = New DevExpress.XtraEditors.CheckEdit()
        Me.chkChukyhieuchuan = New DevExpress.XtraEditors.CheckEdit()
        Me.chkThongsochingmay = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDaychuyen = New DevExpress.XtraEditors.CheckEdit()
        Me.chkBophanchiuphi = New DevExpress.XtraEditors.CheckEdit()
        Me.chkNhaxuong = New DevExpress.XtraEditors.CheckEdit()
        Me.GrpDanhSach = New DevExpress.XtraEditors.GroupControl()
        Me.grdMay = New DevExpress.XtraGrid.GridControl()
        Me.grvMay = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grpThongtin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpThongtin.SuspendLayout()
        CType(Me.chkTailieu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLoaiBTPNCV_PT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLoaiBTPNcongviec.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLoaiBTPNchuky.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLoaiBTPN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCautructhietbiGSTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCautructhietbicongviec.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCautructhietbiphutung.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkThongsobophan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCautructhietbi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkChukyhieuchuan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkThongsochingmay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDaychuyen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkBophanchiuphi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNhaxuong.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrpDanhSach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDanhSach.SuspendLayout()
        CType(Me.grdMay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvMay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Checked = True
        Me.rdAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdAll.Location = New System.Drawing.Point(217, 47)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(244, 22)
        Me.rdAll.TabIndex = 32
        Me.rdAll.TabStop = True
        Me.rdAll.Text = "Copy tất cả"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'rdDieukien
        '
        Me.rdDieukien.AutoSize = True
        Me.rdDieukien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdDieukien.Location = New System.Drawing.Point(467, 47)
        Me.rdDieukien.Name = "rdDieukien"
        Me.rdDieukien.Size = New System.Drawing.Size(245, 22)
        Me.rdDieukien.TabIndex = 33
        Me.rdDieukien.Text = "Copy theo điều kiện chọn"
        Me.rdDieukien.UseVisualStyleBackColor = True
        '
        'lblThongBao
        '
        Me.lblThongBao.AutoSize = True
        Me.lblThongBao.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblThongBao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblThongBao.Location = New System.Drawing.Point(3, 0)
        Me.lblThongBao.Name = "lblThongBao"
        Me.lblThongBao.Size = New System.Drawing.Size(489, 38)
        Me.lblThongBao.TabIndex = 0
        Me.lblThongBao.Text = "Vui lòng nhập mã số thiết bị chưa có trong cơ sở dữ liệu. Trong trường hợp trùng " &
    "mã số thì chương trình sẽ tự động xóa mã số đó"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel2.SetColumnSpan(Me.TableLayoutPanel1, 2)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblThongBao, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(217, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(495, 38)
        Me.TableLayoutPanel1.TabIndex = 36
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rdDieukien, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rdAll, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.grpThongtin, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.GrpDanhSach, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.481482!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.56481!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(715, 479)
        Me.TableLayoutPanel2.TabIndex = 38
        '
        'Panel3
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel3, 3)
        Me.Panel3.Controls.Add(Me.BtnThucHien)
        Me.Panel3.Controls.Add(Me.BtnThoat)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 444)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(709, 32)
        Me.Panel3.TabIndex = 38
        '
        'BtnThucHien
        '
        Me.BtnThucHien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThucHien.Location = New System.Drawing.Point(498, 1)
        Me.BtnThucHien.Name = "BtnThucHien"
        Me.BtnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.BtnThucHien.TabIndex = 30
        Me.BtnThucHien.Text = "&Thực hiện"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Location = New System.Drawing.Point(603, 1)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 31
        Me.BtnThoat.Text = "T&hoát"
        '
        'grpThongtin
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.grpThongtin, 2)
        Me.grpThongtin.Controls.Add(Me.chkTailieu)
        Me.grpThongtin.Controls.Add(Me.chkLoaiBTPNCV_PT)
        Me.grpThongtin.Controls.Add(Me.chkLoaiBTPNcongviec)
        Me.grpThongtin.Controls.Add(Me.chkLoaiBTPNchuky)
        Me.grpThongtin.Controls.Add(Me.chkLoaiBTPN)
        Me.grpThongtin.Controls.Add(Me.chkCautructhietbiGSTT)
        Me.grpThongtin.Controls.Add(Me.chkCautructhietbicongviec)
        Me.grpThongtin.Controls.Add(Me.chkCautructhietbiphutung)
        Me.grpThongtin.Controls.Add(Me.chkThongsobophan)
        Me.grpThongtin.Controls.Add(Me.chkCautructhietbi)
        Me.grpThongtin.Controls.Add(Me.chkChukyhieuchuan)
        Me.grpThongtin.Controls.Add(Me.chkThongsochingmay)
        Me.grpThongtin.Controls.Add(Me.chkDaychuyen)
        Me.grpThongtin.Controls.Add(Me.chkBophanchiuphi)
        Me.grpThongtin.Controls.Add(Me.chkNhaxuong)
        Me.grpThongtin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpThongtin.Location = New System.Drawing.Point(217, 75)
        Me.grpThongtin.Name = "grpThongtin"
        Me.grpThongtin.Size = New System.Drawing.Size(495, 363)
        Me.grpThongtin.TabIndex = 39
        Me.grpThongtin.Text = "Thông tin"
        '
        'chkTailieu
        '
        Me.chkTailieu.Location = New System.Drawing.Point(12, 141)
        Me.chkTailieu.Name = "chkTailieu"
        Me.chkTailieu.Properties.Caption = "Tài liệu máy"
        Me.chkTailieu.Size = New System.Drawing.Size(82, 18)
        Me.chkTailieu.TabIndex = 15
        '
        'chkLoaiBTPNCV_PT
        '
        Me.chkLoaiBTPNCV_PT.Location = New System.Drawing.Point(241, 212)
        Me.chkLoaiBTPNCV_PT.Name = "chkLoaiBTPNCV_PT"
        Me.chkLoaiBTPNCV_PT.Properties.Caption = "Loại bảo trì phòng ngừa công việc phụ tùng"
        Me.chkLoaiBTPNCV_PT.Size = New System.Drawing.Size(234, 18)
        Me.chkLoaiBTPNCV_PT.TabIndex = 14
        '
        'chkLoaiBTPNcongviec
        '
        Me.chkLoaiBTPNcongviec.Location = New System.Drawing.Point(241, 189)
        Me.chkLoaiBTPNcongviec.Name = "chkLoaiBTPNcongviec"
        Me.chkLoaiBTPNcongviec.Properties.Caption = "Loại bảo trì phòng ngừa công việc"
        Me.chkLoaiBTPNcongviec.Size = New System.Drawing.Size(188, 18)
        Me.chkLoaiBTPNcongviec.TabIndex = 13
        '
        'chkLoaiBTPNchuky
        '
        Me.chkLoaiBTPNchuky.Location = New System.Drawing.Point(241, 166)
        Me.chkLoaiBTPNchuky.Name = "chkLoaiBTPNchuky"
        Me.chkLoaiBTPNchuky.Properties.Caption = "Loại bảo trì phòng ngừa chu ky"
        Me.chkLoaiBTPNchuky.Size = New System.Drawing.Size(174, 18)
        Me.chkLoaiBTPNchuky.TabIndex = 12
        '
        'chkLoaiBTPN
        '
        Me.chkLoaiBTPN.Location = New System.Drawing.Point(205, 142)
        Me.chkLoaiBTPN.Name = "chkLoaiBTPN"
        Me.chkLoaiBTPN.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.chkLoaiBTPN.Properties.Appearance.Options.UseForeColor = True
        Me.chkLoaiBTPN.Properties.Caption = "Loại bảo trì phòng ngừa"
        Me.chkLoaiBTPN.Size = New System.Drawing.Size(140, 18)
        Me.chkLoaiBTPN.TabIndex = 11
        '
        'chkCautructhietbiGSTT
        '
        Me.chkCautructhietbiGSTT.Location = New System.Drawing.Point(241, 118)
        Me.chkCautructhietbiGSTT.Name = "chkCautructhietbiGSTT"
        Me.chkCautructhietbiGSTT.Properties.Caption = "Cấu trúc thiết bị GSTT"
        Me.chkCautructhietbiGSTT.Size = New System.Drawing.Size(131, 18)
        Me.chkCautructhietbiGSTT.TabIndex = 10
        '
        'chkCautructhietbicongviec
        '
        Me.chkCautructhietbicongviec.Location = New System.Drawing.Point(241, 49)
        Me.chkCautructhietbicongviec.Name = "chkCautructhietbicongviec"
        Me.chkCautructhietbicongviec.Properties.Caption = "Cấu trúc thiết bị công việc"
        Me.chkCautructhietbicongviec.Size = New System.Drawing.Size(151, 18)
        Me.chkCautructhietbicongviec.TabIndex = 9
        '
        'chkCautructhietbiphutung
        '
        Me.chkCautructhietbiphutung.Location = New System.Drawing.Point(241, 72)
        Me.chkCautructhietbiphutung.Name = "chkCautructhietbiphutung"
        Me.chkCautructhietbiphutung.Properties.Caption = "Cấu trúc thiết bị phụ tùng"
        Me.chkCautructhietbiphutung.Size = New System.Drawing.Size(149, 18)
        Me.chkCautructhietbiphutung.TabIndex = 8
        '
        'chkThongsobophan
        '
        Me.chkThongsobophan.Location = New System.Drawing.Point(241, 95)
        Me.chkThongsobophan.Name = "chkThongsobophan"
        Me.chkThongsobophan.Properties.Caption = "Thông số bộ phận"
        Me.chkThongsobophan.Size = New System.Drawing.Size(112, 18)
        Me.chkThongsobophan.TabIndex = 7
        '
        'chkCautructhietbi
        '
        Me.chkCautructhietbi.Location = New System.Drawing.Point(205, 26)
        Me.chkCautructhietbi.Name = "chkCautructhietbi"
        Me.chkCautructhietbi.Properties.Caption = "Cấu trúc thiết bị"
        Me.chkCautructhietbi.Size = New System.Drawing.Size(103, 18)
        Me.chkCautructhietbi.TabIndex = 6
        '
        'chkChukyhieuchuan
        '
        Me.chkChukyhieuchuan.Location = New System.Drawing.Point(12, 118)
        Me.chkChukyhieuchuan.Name = "chkChukyhieuchuan"
        Me.chkChukyhieuchuan.Properties.Caption = "Chu kỳ hiệu chuẩn"
        Me.chkChukyhieuchuan.Size = New System.Drawing.Size(114, 18)
        Me.chkChukyhieuchuan.TabIndex = 5
        '
        'chkThongsochingmay
        '
        Me.chkThongsochingmay.Location = New System.Drawing.Point(12, 95)
        Me.chkThongsochingmay.Name = "chkThongsochingmay"
        Me.chkThongsochingmay.Properties.Caption = "Thông số chính máy"
        Me.chkThongsochingmay.Size = New System.Drawing.Size(121, 18)
        Me.chkThongsochingmay.TabIndex = 4
        '
        'chkDaychuyen
        '
        Me.chkDaychuyen.Location = New System.Drawing.Point(12, 72)
        Me.chkDaychuyen.Name = "chkDaychuyen"
        Me.chkDaychuyen.Properties.Caption = "Dây chuyền"
        Me.chkDaychuyen.Size = New System.Drawing.Size(83, 18)
        Me.chkDaychuyen.TabIndex = 3
        '
        'chkBophanchiuphi
        '
        Me.chkBophanchiuphi.Location = New System.Drawing.Point(12, 49)
        Me.chkBophanchiuphi.Name = "chkBophanchiuphi"
        Me.chkBophanchiuphi.Properties.Caption = "Bộ phận chịu phí"
        Me.chkBophanchiuphi.Size = New System.Drawing.Size(104, 18)
        Me.chkBophanchiuphi.TabIndex = 2
        '
        'chkNhaxuong
        '
        Me.chkNhaxuong.Location = New System.Drawing.Point(12, 26)
        Me.chkNhaxuong.Name = "chkNhaxuong"
        Me.chkNhaxuong.Properties.Caption = "Nhà xưởng"
        Me.chkNhaxuong.Size = New System.Drawing.Size(79, 18)
        Me.chkNhaxuong.TabIndex = 1
        '
        'GrpDanhSach
        '
        Me.GrpDanhSach.Controls.Add(Me.grdMay)
        Me.GrpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpDanhSach.Location = New System.Drawing.Point(3, 3)
        Me.GrpDanhSach.Name = "GrpDanhSach"
        Me.TableLayoutPanel2.SetRowSpan(Me.GrpDanhSach, 3)
        Me.GrpDanhSach.Size = New System.Drawing.Size(208, 435)
        Me.GrpDanhSach.TabIndex = 39
        Me.GrpDanhSach.Text = "Nhập mã số thiết bị mới"
        '
        'grdMay
        '
        Me.grdMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMay.Location = New System.Drawing.Point(2, 22)
        Me.grdMay.MainView = Me.grvMay
        Me.grdMay.Name = "grdMay"
        Me.grdMay.Size = New System.Drawing.Size(204, 411)
        Me.grdMay.TabIndex = 83
        Me.grdMay.Tag = ""
        Me.grdMay.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvMay, Me.GridView2})
        '
        'grvMay
        '
        Me.grvMay.GridControl = Me.grdMay
        Me.grvMay.Name = "grvMay"
        Me.grvMay.OptionsLayout.Columns.StoreAllOptions = True
        Me.grvMay.OptionsLayout.StoreAllOptions = True
        Me.grvMay.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.grdMay
        Me.GridView2.Name = "GridView2"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(715, 479)
        Me.Panel2.TabIndex = 39
        '
        'frmNhapThietBiMoi
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 479)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmNhapThietBiMoi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nhập thiết bị mới"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grpThongtin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpThongtin.ResumeLayout(False)
        CType(Me.chkTailieu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLoaiBTPNCV_PT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLoaiBTPNcongviec.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLoaiBTPNchuky.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLoaiBTPN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCautructhietbiGSTT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCautructhietbicongviec.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCautructhietbiphutung.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkThongsobophan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCautructhietbi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkChukyhieuchuan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkThongsochingmay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDaychuyen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkBophanchiuphi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNhaxuong.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrpDanhSach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDanhSach.ResumeLayout(False)
        CType(Me.grdMay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvMay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdDieukien As System.Windows.Forms.RadioButton
    Friend WithEvents lblThongBao As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents chkTailieu As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLoaiBTPNCV_PT As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLoaiBTPNcongviec As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLoaiBTPNchuky As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLoaiBTPN As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCautructhietbiGSTT As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCautructhietbicongviec As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCautructhietbiphutung As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkThongsobophan As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCautructhietbi As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkChukyhieuchuan As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkThongsochingmay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDaychuyen As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkBophanchiuphi As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkNhaxuong As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GrpDanhSach As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grdMay As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvMay As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grpThongtin As DevExpress.XtraEditors.GroupControl
End Class
