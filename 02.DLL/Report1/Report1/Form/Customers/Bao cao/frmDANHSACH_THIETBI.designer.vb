<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDANHSACH_THIETBI
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
        Me.components = New System.ComponentModel.Container
        Me.lblBao_cao_thong_tin_thiet_bi = New System.Windows.Forms.Label
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.lblNhaXuong = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.radDanhSachTB_ThuocHT = New System.Windows.Forms.RadioButton
        Me.radDachSachTBHetKH = New System.Windows.Forms.RadioButton
        Me.radDanhSachTBConKhauHao = New System.Windows.Forms.RadioButton
        Me.lblHe_thong = New System.Windows.Forms.Label
        Me.lblTungay = New System.Windows.Forms.Label
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.cboLoaiThietBi = New Commons.UtcComboBox
        Me.lblLoaiThietbi = New System.Windows.Forms.Label
        Me.txtTungay = New System.Windows.Forms.DateTimePicker
        Me.txtDenngay = New System.Windows.Forms.DateTimePicker
        Me.cboHeThong = New Commons.UtcComboBox
        Me.radHetHanBaoHanh = New System.Windows.Forms.RadioButton
        Me.radDanhsachThietBi = New System.Windows.Forms.RadioButton
        Me.grp2 = New System.Windows.Forms.GroupBox
        Me.radDanhSach_LD_BPCP = New System.Windows.Forms.RadioButton
        Me.cboThietBi = New Commons.UtcComboBox
        Me.lblThiet_bi = New System.Windows.Forms.Label
        Me.grp3 = New System.Windows.Forms.GroupBox
        Me.radDachSach_TB_PT = New System.Windows.Forms.RadioButton
        Me.lblPhu_Tung = New System.Windows.Forms.Label
        Me.cboPhuTung = New Commons.UtcComboBox
        Me.cboNhaxuong = New Commons.UtcComboBox
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp1.SuspendLayout()
        Me.grp2.SuspendLayout()
        Me.grp3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBao_cao_thong_tin_thiet_bi
        '
        Me.lblBao_cao_thong_tin_thiet_bi.AutoSize = True
        Me.lblBao_cao_thong_tin_thiet_bi.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBao_cao_thong_tin_thiet_bi.ForeColor = System.Drawing.Color.Navy
        Me.lblBao_cao_thong_tin_thiet_bi.Location = New System.Drawing.Point(150, 9)
        Me.lblBao_cao_thong_tin_thiet_bi.Name = "lblBao_cao_thong_tin_thiet_bi"
        Me.lblBao_cao_thong_tin_thiet_bi.Size = New System.Drawing.Size(423, 29)
        Me.lblBao_cao_thong_tin_thiet_bi.TabIndex = 0
        Me.lblBao_cao_thong_tin_thiet_bi.Text = "BÁO CÁO VỀ THÔNG TIN THIẾT BỊ"
        '
        'btnThucHien
        '
        Me.btnThucHien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThucHien.ForeColor = System.Drawing.Color.Blue
        Me.btnThucHien.Location = New System.Drawing.Point(467, 390)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(2)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(100, 27)
        Me.btnThucHien.TabIndex = 6
        Me.btnThucHien.Text = "Thực hiện"
        
        '
        'lblNhaXuong
        '
        Me.lblNhaXuong.AutoSize = True
        Me.lblNhaXuong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNhaXuong.Location = New System.Drawing.Point(173, 57)
        Me.lblNhaXuong.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNhaXuong.Name = "lblNhaXuong"
        Me.lblNhaXuong.Size = New System.Drawing.Size(60, 13)
        Me.lblNhaXuong.TabIndex = 9
        Me.lblNhaXuong.Text = "Nhà xưởng"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnThoat
        '
        Me.btnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.ForeColor = System.Drawing.Color.Black
        Me.btnThoat.Location = New System.Drawing.Point(567, 390)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(100, 27)
        Me.btnThoat.TabIndex = 21
        Me.btnThoat.Text = "Thoát"
        
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.radDanhSachTB_ThuocHT)
        Me.grp1.Controls.Add(Me.radDachSachTBHetKH)
        Me.grp1.Controls.Add(Me.radDanhSachTBConKhauHao)
        Me.grp1.Controls.Add(Me.lblHe_thong)
        Me.grp1.Controls.Add(Me.lblTungay)
        Me.grp1.Controls.Add(Me.lblDenngay)
        Me.grp1.Controls.Add(Me.cboLoaiThietBi)
        Me.grp1.Controls.Add(Me.lblLoaiThietbi)
        Me.grp1.Controls.Add(Me.txtTungay)
        Me.grp1.Controls.Add(Me.txtDenngay)
        Me.grp1.Controls.Add(Me.cboHeThong)
        Me.grp1.Controls.Add(Me.radHetHanBaoHanh)
        Me.grp1.Controls.Add(Me.radDanhsachThietBi)
        Me.grp1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp1.ForeColor = System.Drawing.Color.Maroon
        Me.grp1.Location = New System.Drawing.Point(14, 93)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(332, 288)
        Me.grp1.TabIndex = 27
        Me.grp1.TabStop = False
        Me.grp1.Text = "Nhóm báo cáo về danh sách thiết bị"
        '
        'radDanhSachTB_ThuocHT
        '
        Me.radDanhSachTB_ThuocHT.AutoSize = True
        Me.radDanhSachTB_ThuocHT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDanhSachTB_ThuocHT.ForeColor = System.Drawing.Color.Black
        Me.radDanhSachTB_ThuocHT.Location = New System.Drawing.Point(13, 213)
        Me.radDanhSachTB_ThuocHT.Name = "radDanhSachTB_ThuocHT"
        Me.radDanhSachTB_ThuocHT.Size = New System.Drawing.Size(186, 17)
        Me.radDanhSachTB_ThuocHT.TabIndex = 19
        Me.radDanhSachTB_ThuocHT.TabStop = True
        Me.radDanhSachTB_ThuocHT.Text = "Danh sách thiết bị trong hệ thống"
        Me.radDanhSachTB_ThuocHT.UseVisualStyleBackColor = True
        '
        'radDachSachTBHetKH
        '
        Me.radDachSachTBHetKH.AutoSize = True
        Me.radDachSachTBHetKH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDachSachTBHetKH.ForeColor = System.Drawing.Color.Black
        Me.radDachSachTBHetKH.Location = New System.Drawing.Point(13, 178)
        Me.radDachSachTBHetKH.Name = "radDachSachTBHetKH"
        Me.radDachSachTBHetKH.Size = New System.Drawing.Size(177, 17)
        Me.radDachSachTBHetKH.TabIndex = 18
        Me.radDachSachTBHetKH.TabStop = True
        Me.radDachSachTBHetKH.Text = "Danh sách thiết bị hết khấu hao"
        Me.radDachSachTBHetKH.UseVisualStyleBackColor = True
        '
        'radDanhSachTBConKhauHao
        '
        Me.radDanhSachTBConKhauHao.AutoSize = True
        Me.radDanhSachTBConKhauHao.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDanhSachTBConKhauHao.ForeColor = System.Drawing.Color.Black
        Me.radDanhSachTBConKhauHao.Location = New System.Drawing.Point(13, 147)
        Me.radDanhSachTBConKhauHao.Name = "radDanhSachTBConKhauHao"
        Me.radDanhSachTBConKhauHao.Size = New System.Drawing.Size(177, 17)
        Me.radDanhSachTBConKhauHao.TabIndex = 17
        Me.radDanhSachTBConKhauHao.TabStop = True
        Me.radDanhSachTBConKhauHao.Text = "Dach sách thiết bị còn khấu hao"
        Me.radDanhSachTBConKhauHao.UseVisualStyleBackColor = True
        '
        'lblHe_thong
        '
        Me.lblHe_thong.AutoSize = True
        Me.lblHe_thong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHe_thong.ForeColor = System.Drawing.Color.Black
        Me.lblHe_thong.Location = New System.Drawing.Point(13, 257)
        Me.lblHe_thong.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblHe_thong.Name = "lblHe_thong"
        Me.lblHe_thong.Size = New System.Drawing.Size(51, 13)
        Me.lblHe_thong.TabIndex = 9
        Me.lblHe_thong.Text = "Hệ thống"
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTungay.ForeColor = System.Drawing.Color.Black
        Me.lblTungay.Location = New System.Drawing.Point(13, 119)
        Me.lblTungay.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(47, 13)
        Me.lblTungay.TabIndex = 2
        Me.lblTungay.Text = "Từ ngày"
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDenngay.ForeColor = System.Drawing.Color.Black
        Me.lblDenngay.Location = New System.Drawing.Point(165, 119)
        Me.lblDenngay.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(54, 13)
        Me.lblDenngay.TabIndex = 3
        Me.lblDenngay.Text = "Đến ngày"
        '
        'cboLoaiThietBi
        '
        Me.cboLoaiThietBi.AssemblyName = ""
        Me.cboLoaiThietBi.BackColor = System.Drawing.Color.White
        Me.cboLoaiThietBi.ClassName = ""
        Me.cboLoaiThietBi.Display = ""
        Me.cboLoaiThietBi.Enabled = False
        Me.cboLoaiThietBi.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiThietBi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoaiThietBi.FormattingEnabled = True
        Me.cboLoaiThietBi.IsAll = True
        Me.cboLoaiThietBi.IsNew = False
        Me.cboLoaiThietBi.ItemAll = " < ALL > "
        Me.cboLoaiThietBi.ItemNew = "...New"
        Me.cboLoaiThietBi.Location = New System.Drawing.Point(110, 23)
        Me.cboLoaiThietBi.MethodName = ""
        Me.cboLoaiThietBi.Name = "cboLoaiThietBi"
        Me.cboLoaiThietBi.Param = ""
        Me.cboLoaiThietBi.Size = New System.Drawing.Size(179, 22)
        Me.cboLoaiThietBi.StoreName = ""
        Me.cboLoaiThietBi.TabIndex = 15
        Me.cboLoaiThietBi.Table = Nothing
        Me.cboLoaiThietBi.TextReadonly = False
        Me.cboLoaiThietBi.Value = ""
        '
        'lblLoaiThietbi
        '
        Me.lblLoaiThietbi.AutoSize = True
        Me.lblLoaiThietbi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoaiThietbi.ForeColor = System.Drawing.Color.Black
        Me.lblLoaiThietbi.Location = New System.Drawing.Point(13, 27)
        Me.lblLoaiThietbi.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLoaiThietbi.Name = "lblLoaiThietbi"
        Me.lblLoaiThietbi.Size = New System.Drawing.Size(62, 13)
        Me.lblLoaiThietbi.TabIndex = 9
        Me.lblLoaiThietbi.Text = "Loại thiết bị"
        '
        'txtTungay
        '
        Me.txtTungay.CalendarForeColor = System.Drawing.Color.Navy
        Me.txtTungay.Enabled = False
        Me.txtTungay.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTungay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtTungay.Location = New System.Drawing.Point(65, 114)
        Me.txtTungay.Name = "txtTungay"
        Me.txtTungay.Size = New System.Drawing.Size(95, 23)
        Me.txtTungay.TabIndex = 16
        '
        'txtDenngay
        '
        Me.txtDenngay.CalendarForeColor = System.Drawing.Color.Navy
        Me.txtDenngay.Enabled = False
        Me.txtDenngay.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDenngay.Location = New System.Drawing.Point(231, 114)
        Me.txtDenngay.Name = "txtDenngay"
        Me.txtDenngay.Size = New System.Drawing.Size(91, 23)
        Me.txtDenngay.TabIndex = 16
        '
        'cboHeThong
        '
        Me.cboHeThong.AssemblyName = ""
        Me.cboHeThong.BackColor = System.Drawing.Color.White
        Me.cboHeThong.ClassName = ""
        Me.cboHeThong.Display = ""
        Me.cboHeThong.Enabled = False
        Me.cboHeThong.ErrorProviderControl = Me.ErrorProvider1
        Me.cboHeThong.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHeThong.FormattingEnabled = True
        Me.cboHeThong.IsAll = True
        Me.cboHeThong.IsNew = False
        Me.cboHeThong.ItemAll = " < ALL > "
        Me.cboHeThong.ItemNew = "...New"
        Me.cboHeThong.Location = New System.Drawing.Point(94, 253)
        Me.cboHeThong.MethodName = ""
        Me.cboHeThong.Name = "cboHeThong"
        Me.cboHeThong.Param = ""
        Me.cboHeThong.Size = New System.Drawing.Size(219, 22)
        Me.cboHeThong.StoreName = ""
        Me.cboHeThong.TabIndex = 15
        Me.cboHeThong.Table = Nothing
        Me.cboHeThong.TextReadonly = False
        Me.cboHeThong.Value = ""
        '
        'radHetHanBaoHanh
        '
        Me.radHetHanBaoHanh.AutoSize = True
        Me.radHetHanBaoHanh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHetHanBaoHanh.ForeColor = System.Drawing.Color.Black
        Me.radHetHanBaoHanh.Location = New System.Drawing.Point(13, 90)
        Me.radHetHanBaoHanh.Margin = New System.Windows.Forms.Padding(2)
        Me.radHetHanBaoHanh.Name = "radHetHanBaoHanh"
        Me.radHetHanBaoHanh.Size = New System.Drawing.Size(199, 17)
        Me.radHetHanBaoHanh.TabIndex = 1
        Me.radHetHanBaoHanh.TabStop = True
        Me.radHetHanBaoHanh.Text = "Danh sách thiết bị hết hạn bảo hành"
        Me.radHetHanBaoHanh.UseVisualStyleBackColor = True
        '
        'radDanhsachThietBi
        '
        Me.radDanhsachThietBi.AutoSize = True
        Me.radDanhsachThietBi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDanhsachThietBi.ForeColor = System.Drawing.Color.Black
        Me.radDanhsachThietBi.Location = New System.Drawing.Point(13, 60)
        Me.radDanhsachThietBi.Margin = New System.Windows.Forms.Padding(2)
        Me.radDanhsachThietBi.Name = "radDanhsachThietBi"
        Me.radDanhsachThietBi.Size = New System.Drawing.Size(111, 17)
        Me.radDanhsachThietBi.TabIndex = 7
        Me.radDanhsachThietBi.TabStop = True
        Me.radDanhsachThietBi.Text = "Danh sách thiết bị"
        Me.radDanhsachThietBi.UseVisualStyleBackColor = True
        '
        'grp2
        '
        Me.grp2.Controls.Add(Me.radDanhSach_LD_BPCP)
        Me.grp2.Controls.Add(Me.cboThietBi)
        Me.grp2.Controls.Add(Me.lblThiet_bi)
        Me.grp2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp2.ForeColor = System.Drawing.Color.Maroon
        Me.grp2.Location = New System.Drawing.Point(352, 94)
        Me.grp2.Name = "grp2"
        Me.grp2.Size = New System.Drawing.Size(315, 131)
        Me.grp2.TabIndex = 28
        Me.grp2.TabStop = False
        Me.grp2.Text = "Nhóm báo cáo về thiết bị"
        '
        'radDanhSach_LD_BPCP
        '
        Me.radDanhSach_LD_BPCP.AutoSize = True
        Me.radDanhSach_LD_BPCP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDanhSach_LD_BPCP.ForeColor = System.Drawing.Color.Black
        Me.radDanhSach_LD_BPCP.Location = New System.Drawing.Point(23, 59)
        Me.radDanhSach_LD_BPCP.Name = "radDanhSach_LD_BPCP"
        Me.radDanhSach_LD_BPCP.Size = New System.Drawing.Size(226, 17)
        Me.radDanhSach_LD_BPCP.TabIndex = 16
        Me.radDanhSach_LD_BPCP.TabStop = True
        Me.radDanhSach_LD_BPCP.Text = "Dach sách nơi lắp đặt và BPCP của thiết bị"
        Me.radDanhSach_LD_BPCP.UseVisualStyleBackColor = True
        '
        'cboThietBi
        '
        Me.cboThietBi.AssemblyName = ""
        Me.cboThietBi.BackColor = System.Drawing.Color.White
        Me.cboThietBi.ClassName = ""
        Me.cboThietBi.Display = ""
        Me.cboThietBi.Enabled = False
        Me.cboThietBi.ErrorProviderControl = Me.ErrorProvider1
        Me.cboThietBi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboThietBi.FormattingEnabled = True
        Me.cboThietBi.IsAll = True
        Me.cboThietBi.IsNew = False
        Me.cboThietBi.ItemAll = " < ALL > "
        Me.cboThietBi.ItemNew = "...New"
        Me.cboThietBi.Location = New System.Drawing.Point(111, 89)
        Me.cboThietBi.MethodName = ""
        Me.cboThietBi.Name = "cboThietBi"
        Me.cboThietBi.Param = ""
        Me.cboThietBi.Size = New System.Drawing.Size(187, 22)
        Me.cboThietBi.StoreName = ""
        Me.cboThietBi.TabIndex = 15
        Me.cboThietBi.Table = Nothing
        Me.cboThietBi.TextReadonly = False
        Me.cboThietBi.Value = ""
        '
        'lblThiet_bi
        '
        Me.lblThiet_bi.AutoSize = True
        Me.lblThiet_bi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThiet_bi.ForeColor = System.Drawing.Color.Black
        Me.lblThiet_bi.Location = New System.Drawing.Point(23, 93)
        Me.lblThiet_bi.Name = "lblThiet_bi"
        Me.lblThiet_bi.Size = New System.Drawing.Size(42, 13)
        Me.lblThiet_bi.TabIndex = 0
        Me.lblThiet_bi.Text = "Thiết bị"
        '
        'grp3
        '
        Me.grp3.Controls.Add(Me.radDachSach_TB_PT)
        Me.grp3.Controls.Add(Me.lblPhu_Tung)
        Me.grp3.Controls.Add(Me.cboPhuTung)
        Me.grp3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp3.ForeColor = System.Drawing.Color.Maroon
        Me.grp3.Location = New System.Drawing.Point(352, 240)
        Me.grp3.Name = "grp3"
        Me.grp3.Size = New System.Drawing.Size(315, 141)
        Me.grp3.TabIndex = 29
        Me.grp3.TabStop = False
        Me.grp3.Text = "Nhóm báo cáo về phụ tùng "
        '
        'radDachSach_TB_PT
        '
        Me.radDachSach_TB_PT.AutoSize = True
        Me.radDachSach_TB_PT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDachSach_TB_PT.ForeColor = System.Drawing.Color.Black
        Me.radDachSach_TB_PT.Location = New System.Drawing.Point(23, 66)
        Me.radDachSach_TB_PT.Name = "radDachSach_TB_PT"
        Me.radDachSach_TB_PT.Size = New System.Drawing.Size(198, 17)
        Me.radDachSach_TB_PT.TabIndex = 25
        Me.radDachSach_TB_PT.TabStop = True
        Me.radDachSach_TB_PT.Text = "Dach sách thiết bị sử dụng phụ tùng"
        Me.radDachSach_TB_PT.UseVisualStyleBackColor = True
        '
        'lblPhu_Tung
        '
        Me.lblPhu_Tung.AutoSize = True
        Me.lblPhu_Tung.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhu_Tung.ForeColor = System.Drawing.Color.Black
        Me.lblPhu_Tung.Location = New System.Drawing.Point(23, 110)
        Me.lblPhu_Tung.Name = "lblPhu_Tung"
        Me.lblPhu_Tung.Size = New System.Drawing.Size(50, 13)
        Me.lblPhu_Tung.TabIndex = 26
        Me.lblPhu_Tung.Text = "Phụ tùng"
        '
        'cboPhuTung
        '
        Me.cboPhuTung.AssemblyName = ""
        Me.cboPhuTung.BackColor = System.Drawing.Color.White
        Me.cboPhuTung.ClassName = ""
        Me.cboPhuTung.Display = ""
        Me.cboPhuTung.Enabled = False
        Me.cboPhuTung.ErrorProviderControl = Me.ErrorProvider1
        Me.cboPhuTung.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPhuTung.FormattingEnabled = True
        Me.cboPhuTung.IsAll = True
        Me.cboPhuTung.IsNew = False
        Me.cboPhuTung.ItemAll = " < ALL > "
        Me.cboPhuTung.ItemNew = "...New"
        Me.cboPhuTung.Location = New System.Drawing.Point(111, 106)
        Me.cboPhuTung.MethodName = ""
        Me.cboPhuTung.Name = "cboPhuTung"
        Me.cboPhuTung.Param = ""
        Me.cboPhuTung.Size = New System.Drawing.Size(187, 22)
        Me.cboPhuTung.StoreName = ""
        Me.cboPhuTung.TabIndex = 15
        Me.cboPhuTung.Table = Nothing
        Me.cboPhuTung.TextReadonly = False
        Me.cboPhuTung.Value = ""
        '
        'cboNhaxuong
        '
        Me.cboNhaxuong.AssemblyName = ""
        Me.cboNhaxuong.BackColor = System.Drawing.Color.White
        Me.cboNhaxuong.ClassName = ""
        Me.cboNhaxuong.Display = ""
        Me.cboNhaxuong.ErrorProviderControl = Me.ErrorProvider1
        Me.cboNhaxuong.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNhaxuong.FormattingEnabled = True
        Me.cboNhaxuong.IsAll = True
        Me.cboNhaxuong.IsNew = False
        Me.cboNhaxuong.ItemAll = " < ALL > "
        Me.cboNhaxuong.ItemNew = "...New"
        Me.cboNhaxuong.Location = New System.Drawing.Point(272, 53)
        Me.cboNhaxuong.MethodName = ""
        Me.cboNhaxuong.Name = "cboNhaxuong"
        Me.cboNhaxuong.Param = ""
        Me.cboNhaxuong.Size = New System.Drawing.Size(207, 22)
        Me.cboNhaxuong.StoreName = ""
        Me.cboNhaxuong.TabIndex = 15
        Me.cboNhaxuong.Table = Nothing
        Me.cboNhaxuong.TextReadonly = False
        Me.cboNhaxuong.Value = ""
        '
        'frmDANHSACH_THIETBI
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 429)
        Me.Controls.Add(Me.grp3)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.grp2)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.cboNhaxuong)
        Me.Controls.Add(Me.btnThucHien)
        Me.Controls.Add(Me.lblBao_cao_thong_tin_thiet_bi)
        Me.Controls.Add(Me.lblNhaXuong)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDANHSACH_THIETBI"
        Me.Text = "Báo cáo về thông tin thiết bị"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        Me.grp2.ResumeLayout(False)
        Me.grp2.PerformLayout()
        Me.grp3.ResumeLayout(False)
        Me.grp3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblBao_cao_thong_tin_thiet_bi As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblNhaXuong As System.Windows.Forms.Label
    Friend WithEvents cboNhaxuong As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grp3 As System.Windows.Forms.GroupBox
    Friend WithEvents radDachSach_TB_PT As System.Windows.Forms.RadioButton
    Friend WithEvents lblPhu_Tung As System.Windows.Forms.Label
    Friend WithEvents cboPhuTung As Commons.UtcComboBox
    Friend WithEvents grp2 As System.Windows.Forms.GroupBox
    Friend WithEvents radDanhSach_LD_BPCP As System.Windows.Forms.RadioButton
    Friend WithEvents cboThietBi As Commons.UtcComboBox
    Friend WithEvents lblThiet_bi As System.Windows.Forms.Label
    Friend WithEvents grp1 As System.Windows.Forms.GroupBox
    Friend WithEvents radDanhSachTB_ThuocHT As System.Windows.Forms.RadioButton
    Friend WithEvents radDachSachTBHetKH As System.Windows.Forms.RadioButton
    Friend WithEvents radDanhSachTBConKhauHao As System.Windows.Forms.RadioButton
    Friend WithEvents lblHe_thong As System.Windows.Forms.Label
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents cboLoaiThietBi As Commons.UtcComboBox
    Friend WithEvents lblLoaiThietbi As System.Windows.Forms.Label
    Friend WithEvents txtTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDenngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboHeThong As Commons.UtcComboBox
    Friend WithEvents radHetHanBaoHanh As System.Windows.Forms.RadioButton
    Friend WithEvents radDanhsachThietBi As System.Windows.Forms.RadioButton
End Class


