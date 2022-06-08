
Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptBaoTriDinhKyThang
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Dim v_all As DataTable = New DataTable()

    Private Sub frmrptBaoTriDinhKyThang_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("BTDK_TMP")

    End Sub

    Private Sub frmrptBaoTriDinhKyThang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCity()
        vTuNgay = DateTime.Now.Date
        vDenNgay = vTuNgay.AddMonths(1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtNgayLap.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtNgayDuyet.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        'loadNhaXuong()
        Try
            cbxNguoiLap.DataSource = LoadNhanVien()
            cbxNguoiLap.ValueMember = "MS_CONG_NHAN"
            cbxNguoiLap.DisplayMember = "TEN_CONG_NHAN"
            cbxNguoiDuyet.DataSource = LoadNhanVien()
            cbxNguoiDuyet.ValueMember = "MS_CONG_NHAN"
            cbxNguoiDuyet.DisplayMember = "TEN_CONG_NHAN"
        Catch ex As Exception
        End Try
        Dim i As Integer = cbxTrangThai.Items.Count
        Try
            cbxTrangThai.SelectedItem = 1
        Catch ex As Exception
        End Try
    End Sub
    'set ngon ngu
    Private Sub refeshLanguage()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "rptBaoTriDinhKyThang", commons.Modules.TypeLanguage)
        Me.lbaTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", lbaTuNgay.Name, commons.Modules.TypeLanguage)
        Me.lbaDenNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", lbaDenNgay.Name, commons.Modules.TypeLanguage)
        Me.btnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", btnThucHien.Name, commons.Modules.TypeLanguage)
        Me.lbaNgayDuyet.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", lbaNgayDuyet.Name, commons.Modules.TypeLanguage)
        Me.lbaNgayLap.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", lbaNgayLap.Name, commons.Modules.TypeLanguage)
        Me.lbaNguoiDuyet.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", lbaNguoiDuyet.Name, commons.Modules.TypeLanguage)
        Me.lbaNguoiLap.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", lbaNguoiLap.Name, commons.Modules.TypeLanguage)
        Me.lbaTrangThai.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", lbaTrangThai.Name, commons.Modules.TypeLanguage)
        ' Me.lbaHienTrang.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", lbaHienTrang.Name, commons.Modules.TypeLanguage)
        Me.lbaNhaXuong.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", lbaNhaXuong.Name, commons.Modules.TypeLanguage)

    End Sub
    'Load combo nhà xưởng
    Sub loadNhaXuong()
        'cbxNhaXuong.Value = "MS_N_XUONG"
        'cbxNhaXuong.Display = "TEN_N_XUONG"
        'cbxNhaXuong.StoreName = "GetNHA_XUONGs"
        'cbxNhaXuong.Param = Commons.Modules.UserName
        'cbxNhaXuong.BindDataSource()
        Dim _table As DataTable = New DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString()))
        cbxNhaXuong.DisplayMember = "TEN_N_XUONG"
        cbxNhaXuong.ValueMember = "MS_N_XUONG"
        cbxNhaXuong.DataSource = _table
    End Sub

    'Sub loadHienTrang()
    '    cbxHienTrang.Value = "MS_HIEN_TRANG"
    '    cbxHienTrang.Display = "TEN_HIEN_TRANG"
    '    cbxHienTrang.StoreName = "H_GetHienTrangSuDungMay"
    '    cbxHienTrang.Param = Commons.Modules.UserName
    '    cbxHienTrang.BindDataSource()
    'End Sub

    'kiểm tra ngày lập
    Private Sub mtxtNgayLap_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtNgayLap.Validating
        Dim vNgayLap As DateTime
        Dim vNgayDuyet As DateTime

        Try
            If mtxtNgayLap.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vNgayLap = DateTime.ParseExact(mtxtNgayLap.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NgayLapChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        Try
            If mtxtNgayDuyet.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vNgayDuyet = DateTime.ParseExact(mtxtNgayDuyet.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NgayDuyetChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vNgayLap > vNgayDuyet Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NLPhaiNhoHonND", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub
    'kiểm tra ngày duyệt
    Private Sub mtxtNgayDuyet_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtNgayDuyet.Validating
        Dim vNgayLap As DateTime
        Dim vNgayDuyet As DateTime

        Try
            If mtxtNgayDuyet.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vNgayDuyet = DateTime.ParseExact(mtxtNgayDuyet.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NgayDuyetChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        Try
            If mtxtNgayLap.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vNgayLap = DateTime.ParseExact(mtxtNgayLap.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NgayLapChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vNgayLap > vNgayDuyet Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NDPhaiLonHonNL", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub
    'kiểm tra đến ngày
    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating
        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "DenNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "DNPhaiLonHonTN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

        If (GetTuan(vDenNgay) - GetTuan(vTuNgay)) >= 5 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TN_DNKoQua5Tuan", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If


    End Sub
    'Kiểm tra Từ ngày
    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "DenNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "DNPhaiLonHonTN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If
        If (GetTuan(vDenNgay) - GetTuan(vTuNgay)) >= 5 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TN_DNKoQua5Tuan", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub
    'set ngon ngu bao cao khong an toan
    Private Function languageReport() As DataTable
        Dim vTbTitle As DataTable = New DataTable("Title")
        Dim TenCty As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Total", commons.Modules.TypeLanguage)
        Dim PhongBan As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "ToTal_Line", commons.Modules.TypeLanguage)
        Dim TieuDeAnh As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TieuDeAnh1", commons.Modules.TypeLanguage)
        Dim TieuDeViet As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TieuDeViet1", commons.Modules.TypeLanguage)
        Dim Maso As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Maso1", commons.Modules.TypeLanguage)
        Dim TotalPage As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TotalPage", commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NguoiLap", commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NgayLap", commons.Modules.TypeLanguage)
        Dim NguoiDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NguoiDuyet", commons.Modules.TypeLanguage)
        Dim NgayDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NgayDuyet", commons.Modules.TypeLanguage)
        Dim KyTen As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "KyTen", commons.Modules.TypeLanguage)
        Dim Line As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Line", commons.Modules.TypeLanguage)
        Dim TenMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TenMay", commons.Modules.TypeLanguage)
        Dim MaMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "MaMay", commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "BoPhan", commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "STT", commons.Modules.TypeLanguage)
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "CongViec", commons.Modules.TypeLanguage)
        Dim MoTa As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "MoTa", commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "PhieuBaoTri", commons.Modules.TypeLanguage)
        Dim TanSuat As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TanSuat", commons.Modules.TypeLanguage)
        Dim TuanThucHien As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TuanThucHien", commons.Modules.TypeLanguage)
        Dim THboi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "THboi", commons.Modules.TypeLanguage)
        Dim KetQua As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "KetQua", commons.Modules.TypeLanguage)
        Dim KTBoi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "KTBoi", commons.Modules.TypeLanguage)
        Dim KyHieu As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "KyHieu", commons.Modules.TypeLanguage)

        Dim Thang As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Thang", commons.Modules.TypeLanguage)
        Dim TuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TuNgay", commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "DenNgay", commons.Modules.TypeLanguage)

        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "GHI_CHU", commons.Modules.TypeLanguage)


        vTbTitle.Columns.Add("THANG_TD", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TU_NGAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("DEN_NGAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TU_NGAY_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("DEN_NGAY_ND", Type.GetType("System.String"))

        vTbTitle.Columns.Add("TENCTY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("PHONGBAN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TIEUDEANH", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TIEUDEVIET", Type.GetType("System.String"))
        vTbTitle.Columns.Add("THANG", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MASO", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TOTALPAGE", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOILAP", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAYLAP", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOIDUYET", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAYDUYET", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KYTEN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("LINE", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TENMAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MAMAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("BOPHAN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("STT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("CONGVIEC", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MOTA", Type.GetType("System.String"))
        vTbTitle.Columns.Add("SOLUONG", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TANSUAT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TUANTHUCHIEN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T1", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T2", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T3", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T4", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T5", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TH_BOI", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KETQUA", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KT_BOI", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOIDUYET_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOILAP_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAY_LAP_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAY_DUYET_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KYHIEU", Type.GetType("System.String"))

        vTbTitle.Columns.Add("GHI_CHU", Type.GetType("System.String"))

        Dim rowNew As DataRow = vTbTitle.NewRow()
        rowNew("TENCTY") = TenCty
        rowNew("PHONGBAN") = PhongBan
        rowNew("TIEUDEANH") = TieuDeAnh
        rowNew("TIEUDEVIET") = TieuDeViet

        If vTuNgay.Month = vDenNgay.Month Then
            rowNew("THANG") = vTuNgay.Month.ToString & "/" & vTuNgay.Year
        Else
            If (30 - vTuNgay.Day) > (vDenNgay.Day - 1) Then
                rowNew("THANG") = vTuNgay.Month.ToString & "/" & vTuNgay.Year
            Else
                rowNew("THANG") = vDenNgay.Month.ToString & "/" & vDenNgay.Year
            End If
        End If
        rowNew("MASO") = Maso
        rowNew("TOTALPAGE") = TotalPage
        rowNew("NGUOILAP") = NguoiLap
        rowNew("NGAYLAP") = NgayLap
        rowNew("NGUOIDUYET") = NguoiDuyet
        rowNew("NGAYDUYET") = NgayDuyet
        rowNew("KYTEN") = KyTen
        rowNew("LINE") = Line
        rowNew("TENMAY") = TenMay
        rowNew("MAMAY") = MaMay
        rowNew("BOPHAN") = BoPhan
        rowNew("STT") = STT
        rowNew("CONGVIEC") = CongViec
        rowNew("MOTA") = MoTa
        rowNew("SOLUONG") = SoLuong
        rowNew("TANSUAT") = TanSuat
        rowNew("TUANTHUCHIEN") = TuanThucHien
        rowNew("T1") = GetTuan(vTuNgay).ToString & "/" & vTuNgay.Year.ToString
        rowNew("T2") = GetTuan(vTuNgay.AddDays(7)).ToString & "/" & vTuNgay.Year.ToString
        rowNew("T3") = GetTuan(vTuNgay.AddDays(14)).ToString & "/" & vTuNgay.Year.ToString
        rowNew("T4") = GetTuan(vTuNgay.AddDays(21)).ToString & "/" & vTuNgay.Year.ToString
        rowNew("T5") = GetTuan(vTuNgay.AddDays(28)).ToString & "/" & vTuNgay.Year.ToString
        rowNew("TH_BOI") = THboi
        rowNew("KETQUA") = KetQua
        rowNew("KT_BOI") = KTBoi
        rowNew("NGUOIDUYET_ND") = cbxNguoiDuyet.Text.Trim.ToString
        rowNew("NGUOILAP_ND") = cbxNguoiLap.Text.Trim.ToString
        rowNew("NGAY_LAP_ND") = mtxtNgayLap.Text
        rowNew("NGAY_DUYET_ND") = mtxtNgayDuyet.Text
        rowNew("KYHIEU") = KyHieu
        rowNew("THANG_TD") = Thang
        rowNew("TU_NGAY") = TuNgay
        rowNew("DEN_NGAY") = DenNgay
        rowNew("TU_NGAY_ND") = mtxtTuNgay.Text
        rowNew("DEN_NGAY_ND") = mtxtDenNgay.Text

        rowNew("GHI_CHU") = GhiChu & " " & FromDatetoDate()

        vTbTitle.Rows.Add(rowNew)
        Return vTbTitle
    End Function
    'set ngon ngu bao cao an toan 
    Private Function languageReportAnToan() As DataTable
        Dim vTbTitle As DataTable = New DataTable("Title")
        Dim TenCty As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Total", commons.Modules.TypeLanguage)
        Dim PhongBan As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "ToTal_Line", commons.Modules.TypeLanguage)
        Dim TieuDeAnh As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TieuDeAnh2", commons.Modules.TypeLanguage)
        Dim TieuDeViet As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TieuDeViet2", commons.Modules.TypeLanguage)
        Dim Maso As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Maso2", commons.Modules.TypeLanguage)
        Dim TotalPage As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TotalPage", commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NguoiLap", commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NgayLap", commons.Modules.TypeLanguage)
        Dim NguoiDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NguoiDuyet", commons.Modules.TypeLanguage)
        Dim NgayDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "NgayDuyet", commons.Modules.TypeLanguage)
        Dim KyTen As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "KyTen", commons.Modules.TypeLanguage)
        Dim Line As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Line", commons.Modules.TypeLanguage)
        Dim TenMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TenMay", commons.Modules.TypeLanguage)
        Dim MaMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "MaMay", commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "BoPhan", commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "STT", commons.Modules.TypeLanguage)
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "CongViec", commons.Modules.TypeLanguage)
        Dim MoTa As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "MoTa", commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "PhieuBaoTri", commons.Modules.TypeLanguage)
        Dim TanSuat As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TanSuat", commons.Modules.TypeLanguage)
        Dim TuanThucHien As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TuanThucHien", commons.Modules.TypeLanguage)
        Dim THboi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "THboi", commons.Modules.TypeLanguage)
        Dim KetQua As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "KetQua", commons.Modules.TypeLanguage)
        Dim KTBoi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "KTBoi", commons.Modules.TypeLanguage)
        Dim KyHieu As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "KyHieu", commons.Modules.TypeLanguage)

        Dim Thang As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Thang", commons.Modules.TypeLanguage)
        Dim TuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "TuNgay", commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "DenNgay", commons.Modules.TypeLanguage)

        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "GHI_CHU", commons.Modules.TypeLanguage)



        vTbTitle.Columns.Add("THANG_TD", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TU_NGAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("DEN_NGAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TU_NGAY_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("DEN_NGAY_ND", Type.GetType("System.String"))

        vTbTitle.Columns.Add("TENCTY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("PHONGBAN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TIEUDEANH", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TIEUDEVIET", Type.GetType("System.String"))
        vTbTitle.Columns.Add("THANG", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MASO", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TOTALPAGE", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOILAP", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAYLAP", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOIDUYET", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAYDUYET", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KYTEN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("LINE", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TENMAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MAMAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("BOPHAN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("STT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("CONGVIEC", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MOTA", Type.GetType("System.String"))
        vTbTitle.Columns.Add("SOLUONG", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TANSUAT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TUANTHUCHIEN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T1", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T2", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T3", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T4", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T5", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TH_BOI", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KETQUA", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KT_BOI", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOIDUYET_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOILAP_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAY_LAP_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAY_DUYET_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KYHIEU", Type.GetType("System.String"))

        vTbTitle.Columns.Add("GHI_CHU", Type.GetType("System.String"))


        Dim rowNew As DataRow = vTbTitle.NewRow()
        rowNew("TENCTY") = TenCty
        rowNew("PHONGBAN") = PhongBan
        rowNew("TIEUDEANH") = TieuDeAnh
        rowNew("TIEUDEVIET") = TieuDeViet

        If vTuNgay.Month = vDenNgay.Month Then
            rowNew("THANG") = vTuNgay.Month.ToString & "/" & vTuNgay.Year
        Else
            If (30 - vTuNgay.Day) > (vDenNgay.Day - 1) Then
                rowNew("THANG") = vTuNgay.Month.ToString & "/" & vTuNgay.Year
            Else
                rowNew("THANG") = vDenNgay.Month.ToString & "/" & vDenNgay.Year
            End If
        End If
        rowNew("MASO") = Maso
        rowNew("TOTALPAGE") = TotalPage
        rowNew("NGUOILAP") = NguoiLap
        rowNew("NGAYLAP") = NgayLap
        rowNew("NGUOIDUYET") = NguoiDuyet
        rowNew("NGAYDUYET") = NgayDuyet
        rowNew("KYTEN") = KyTen
        rowNew("LINE") = Line
        rowNew("TENMAY") = TenMay
        rowNew("MAMAY") = MaMay
        rowNew("BOPHAN") = BoPhan
        rowNew("STT") = STT
        rowNew("CONGVIEC") = CongViec
        rowNew("MOTA") = MoTa
        rowNew("SOLUONG") = SoLuong
        rowNew("TANSUAT") = TanSuat
        rowNew("TUANTHUCHIEN") = TuanThucHien
        rowNew("T1") = GetTuan(vTuNgay).ToString & "/" & vTuNgay.Year.ToString
        rowNew("T2") = GetTuan(vTuNgay.AddDays(7)).ToString & "/" & vTuNgay.Year.ToString
        rowNew("T3") = GetTuan(vTuNgay.AddDays(14)).ToString & "/" & vTuNgay.Year.ToString
        rowNew("T4") = GetTuan(vTuNgay.AddDays(21)).ToString & "/" & vTuNgay.Year.ToString
        rowNew("T5") = GetTuan(vTuNgay.AddDays(28)).ToString & "/" & vTuNgay.Year.ToString
        rowNew("TH_BOI") = THboi
        rowNew("KETQUA") = KetQua
        rowNew("KT_BOI") = KTBoi
        rowNew("NGUOIDUYET_ND") = cbxNguoiDuyet.Text.Trim.ToString
        rowNew("NGUOILAP_ND") = cbxNguoiLap.Text.Trim.ToString
        rowNew("NGAY_LAP_ND") = mtxtNgayLap.Text
        rowNew("NGAY_DUYET_ND") = mtxtNgayDuyet.Text
        rowNew("KYHIEU") = KyHieu
        rowNew("THANG_TD") = Thang
        rowNew("TU_NGAY") = TuNgay
        rowNew("DEN_NGAY") = DenNgay
        rowNew("TU_NGAY_ND") = mtxtTuNgay.Text
        rowNew("DEN_NGAY_ND") = mtxtDenNgay.Text

        rowNew("GHI_CHU") = GhiChu & " " & FromDatetoDate()

        vTbTitle.Rows.Add(rowNew)
        Return vTbTitle
    End Function




    Function FromDatetoDate() As String
        Dim strDate As String = ""
        strDate = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay).ToString & "/" & vTuNgay.Year.ToString & "(" & vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay, DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(7)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(7), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay.AddDays(7), DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(14)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(14), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay.AddDays(14), DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(21)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(21), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay.AddDays(21), DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(28)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(28), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & vTuNgay.AddDays(28).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")"
        Return strDate
    End Function


    Public Shared Function FirstDayOfWeek(ByVal day As DateTime, ByVal weekStarts As DayOfWeek) As DateTime
        Dim d As DateTime = day
        While (d.DayOfWeek <> weekStarts)
            d = d.AddDays(-1)
        End While
        Return (d)
    End Function

    Public Shared Function LastDayOfWeek(ByVal day As DateTime, ByVal weekStarts As DayOfWeek) As DateTime
        Dim d As DateTime = day
        While (d.DayOfWeek <> weekStarts)
            d = d.AddDays(+1)
        End While
        Return (d)
    End Function

    'Thực hiện In
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "PhaiNhapTuNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtTuNgay.Focus()
                Exit Sub
            End If

            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "PhaiNhapDenNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtDenNgay.Focus()
                Exit Sub
            End If

            If mtxtNgayLap.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "PhaiNhapNgayLap", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtNgayLap.Focus()
                Exit Sub
            End If

            If cbxTrangThai.Text.Trim.ToString = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "ChuaChonTrangThai", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                cbxTrangThai.Focus()
                Exit Sub
            End If

            Dim frmRP As frmXMLReport = New frmXMLReport()
            frmRP.rptName = "rptBaoTriDinhKyThang"

            Dim vTbData As DataTable = New DataTable()
            If cbxTrangThai.SelectedIndex = 1 Then
                Dim vtbLgangua As DataTable = languageReportAnToan()
                frmRP.AddDataTableSource(vtbLgangua)
            Else
                Dim vtbLgangua As DataTable = languageReport()
                frmRP.AddDataTableSource(vtbLgangua)
            End If

            vTbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getBaoTriDinhDinhKyThang_NEW", cbxTrangThai.SelectedIndex, vTuNgay, vDenNgay, cbxNhaXuong.SelectedValue.ToString(), cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString()))
            If vTbData.Rows.Count > 0 Then
                vTbData.TableName = "rptBaoTriDinhKyThang"
                frmRP.AddDataTableSource(vTbData)
                vTbData = GetParentBophan(vTbData)
                frmRP.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThang", "KhongCoDLDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Function GetParentBophan(ByVal dt As DataTable) As DataTable
        Try
            Dim sMamay As String
            Dim sTenbp As String
            If dt.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    Dim sMabp As String
                    sTenbp = ""
                    sMabp = dt.Rows(i)("MS_BO_PHAN").ToString()
                    sMamay = dt.Rows(i)("MS_MAY").ToString()
                    sTenbp = GetParent(sMabp, sMamay, sTenbp)
                    dt.Rows(i)("TEN_BO_PHAN") = sTenbp
                Next
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GetParent(ByVal mabp As String, ByVal msmay As String, ByVal sTenbp As String) As String
        Dim sql, mspbcha As String
        sql = "SELECT TEN_BO_PHAN,MS_BO_PHAN_CHA FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN =N'" + mabp + "' AND MS_MAY = N'" + msmay + "'"
        Dim dt As DataTable = New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        If dt.Rows.Count > 0 Then
            If sTenbp = "" Then
                sTenbp = dt.Rows(0)("TEN_BO_PHAN").ToString()
            Else
                sTenbp = dt.Rows(0)("TEN_BO_PHAN").ToString() + " >> " + sTenbp
            End If


            mspbcha = dt.Rows(0)("MS_BO_PHAN_CHA").ToString()
            If mspbcha <> msmay Then
                Return GetParent(mspbcha, msmay, sTenbp)
            Else
                Return sTenbp
            End If
        Else
            Return Nothing
        End If
    End Function

    'Tuần thứ bao nhiêu của ngày
    Private Function GetTuan(ByVal vNgay As DateTime) As Integer
        Dim Calendar As New System.Globalization.GregorianCalendar()
        Dim vt As Integer = Calendar.GetWeekOfYear(vNgay, Globalization.CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday)
        Return vt
    End Function
    'Load danh sach nhan vien 
    Private Function LoadNhanVien() As DataTable
        Dim vtbNV As DataTable = New DataTable()
        vtbNV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_CONG_NHAN,(HO + ' ' + TEN) AS TEN_CONG_NHAN   from CONG_NHAN "))
        Return vtbNV
    End Function
#Region "Nhu Y"
    Private Sub LoadCity()

        Try
            cmbCity.ValueMember = "ma_qg"
            cmbCity.DisplayMember = "ten_qg"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Tinh"))
            cmbCity.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadDistrict()

        Try
            cmbDistrict.ValueMember = "ma_qg"
            cmbDistrict.DisplayMember = "ten_qg"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_District", cmbCity.SelectedValue.ToString()))
            cmbDistrict.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadStreet()

        Try

            'cmbStreet.StoreName = "S_Duong"
            'cmbStreet.Param = cmbCity.SelectedValue.ToString()
            'If cmbDistrict.SelectedValue = Nothing Then
            'Else
            'cmbStreet.Param = cmbDistrict.SelectedValue.ToString()
            'End If
            'cmbStreet.Param = cmbDistrict.SelectedValue.ToString()
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Duong", cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString()))
            cmbStreet.DataSource = _table
            cmbStreet.ValueMember = "MS_Duong"
            cmbStreet.DisplayMember = "Duong_TV"
        Catch ex As Exception

        End Try

    End Sub
    
#End Region
    Private Sub cmbCity_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCity.SelectedValueChanged
        LoadDistrict()
    End Sub

    Private Sub cmbDistrict_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrict.SelectedValueChanged
        LoadStreet()
    End Sub

    Private Sub cmbStreet_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStreet.SelectedValueChanged
        loadNhaXuong()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
