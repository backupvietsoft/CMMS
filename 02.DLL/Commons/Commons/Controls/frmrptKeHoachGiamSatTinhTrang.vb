
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptKeHoachGiamSatTinhTrang
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Dim v_all As DataTable = New DataTable()

    Private Sub frmrptKeHoachGiamSatTinhTrang_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("KE_HOACH_GSTT_TMP1")
        Commons.Modules.ObjSystems.XoaTable("KE_HOACH_GSTT_TMP")
    End Sub

    Private Sub frmrptnBaoTriDinhKyThang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vTuNgay = DateTime.Now.Date
        vDenNgay = vTuNgay.AddMonths(1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtNgayLap.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtNgayDuyet.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        loadNhaXuong()
        Try
            cbxNguoiLap.DataSource = LoadNhanVien()
            cbxNguoiLap.ValueMember = "MS_CONG_NHAN"
            cbxNguoiLap.DisplayMember = "TEN_CONG_NHAN"
            cbxNguoiDuyet.DataSource = LoadNhanVien()
            cbxNguoiDuyet.ValueMember = "MS_CONG_NHAN"
            cbxNguoiDuyet.DisplayMember = "TEN_CONG_NHAN"
        Catch ex As Exception
        End Try
    End Sub
    Sub loadNhaXuong()
        'H_GET_NHA_XUONG_FILTER
        'cbxNhaXuong.Value = "MS_N_XUONG"
        'cbxNhaXuong.Display = "Ten_N_XUONG"
        'cbxNhaXuong.StoreName = "H_GET_NHA_XUONG_FILTER"
        'cbxNhaXuong.BindDataSource()
        Dim _table As DataTable = New DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
        cbxNhaXuong.DisplayMember = "TEN_N_XUONG"
        cbxNhaXuong.ValueMember = "MS_N_XUONG"
        cbxNhaXuong.DataSource = _table
    End Sub


    'set ngon ngu
    Private Sub refeshLanguage()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "rptKeHoachGiamSatTinhTrang", Commons.Modules.TypeLanguage)
        Me.lbaTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", lbaTuNgay.Name, Commons.Modules.TypeLanguage)
        Me.lbaDenNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", lbaDenNgay.Name, Commons.Modules.TypeLanguage)
        Me.btnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", btnThucHien.Name, Commons.Modules.TypeLanguage)
        Me.lbaNgayDuyet.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", lbaNgayDuyet.Name, Commons.Modules.TypeLanguage)
        Me.lbaNgayLap.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", lbaNgayLap.Name, Commons.Modules.TypeLanguage)
        Me.lbaNguoiDuyet.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", lbaNguoiDuyet.Name, Commons.Modules.TypeLanguage)
        Me.lbaNguoiLap.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", lbaNguoiLap.Name, Commons.Modules.TypeLanguage)
        Me.lbaNhaXuong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", lbaNhaXuong.Name, Commons.Modules.TypeLanguage)

    End Sub
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
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NgayLapChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        Try
            If mtxtNgayDuyet.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vNgayDuyet = DateTime.ParseExact(mtxtNgayDuyet.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NgayDuyetChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vNgayLap > vNgayDuyet Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NLPhaiNhoHonND", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NgayDuyetChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        Try
            If mtxtNgayLap.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vNgayLap = DateTime.ParseExact(mtxtNgayLap.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NgayLapChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vNgayLap > vNgayDuyet Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NDPhaiLonHonNL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "DenNgayChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TuNgayChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "DNPhaiLonHonTN", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

        If (vDenNgay > vTuNgay.AddMonths(1)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TN_DNKoQua5Tuan", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TuNgayChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "DenNgayChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

    End Sub
    'set ngon ngu bao cao khong an toan
    Private Function languageReport() As DataTable
        Dim vTbTitle As DataTable = New DataTable("Title")
        Dim TenCty As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TenCty", Commons.Modules.TypeLanguage)
        Dim PhongBan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "PhongBan", Commons.Modules.TypeLanguage)
        Dim TieuDeAnh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TieuDeAnh", Commons.Modules.TypeLanguage)
        Dim TieuDeViet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TieuDeViet", Commons.Modules.TypeLanguage)
        Dim Maso As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Maso", Commons.Modules.TypeLanguage)
        Dim TotalPage As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TotalPage", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NgayLap", Commons.Modules.TypeLanguage)
        Dim NguoiDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NguoiDuyet", Commons.Modules.TypeLanguage)
        Dim NgayDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NgayDuyet", Commons.Modules.TypeLanguage)
        Dim KyTen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "KyTen", Commons.Modules.TypeLanguage)
        Dim Line As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Line", Commons.Modules.TypeLanguage)
        Dim TenMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TenMay", Commons.Modules.TypeLanguage)
        Dim MaMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "MaMay", Commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "BoPhan", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "STT", Commons.Modules.TypeLanguage)
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "CongViec", Commons.Modules.TypeLanguage)
        Dim MoTa As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "MoTa", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "SoLuong", Commons.Modules.TypeLanguage)
        Dim TanSuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TanSuat", Commons.Modules.TypeLanguage)
        Dim TuanThucHien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TuanThucHien", Commons.Modules.TypeLanguage)
        Dim THboi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "THboi", Commons.Modules.TypeLanguage)
        Dim KetQua As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "KetQua", Commons.Modules.TypeLanguage)
        Dim KTBoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "KTBoi", Commons.Modules.TypeLanguage)
        Dim KyHieu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "KyHieu", Commons.Modules.TypeLanguage)

        Dim Thang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Thang", Commons.Modules.TypeLanguage)
        Dim TuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TuNgay", Commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "DenNgay", Commons.Modules.TypeLanguage)
        Dim ChuKy As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "ChuKy", Commons.Modules.TypeLanguage)
        Dim NgayCuoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NgayCuoi", Commons.Modules.TypeLanguage)
        Dim GiaTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "GiaTri", Commons.Modules.TypeLanguage)
        Dim Dat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Dat", Commons.Modules.TypeLanguage)
        Dim kq As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "KetQua", Commons.Modules.TypeLanguage)
        Dim Tuan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Tuan", Commons.Modules.TypeLanguage)

        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Ghi_Chu", Commons.Modules.TypeLanguage)
        Dim trangin As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "trangIn", Commons.Modules.TypeLanguage)


        Dim TD1 As String = Commons.Modules.sPrivate 'Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TD1", commons.Modules.TypeLanguage)
        Try
            TD1 = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 ISNULL(TEN_NGAN_TIENG_VIET,'" & Commons.Modules.sPrivate & "') FROM THONG_TIN_CHUNG")
        Catch ex As Exception

        End Try


        Dim TD2 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TD2", Commons.Modules.TypeLanguage)
        Dim TD3 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TD3", Commons.Modules.TypeLanguage)

        Dim NhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "NhaXuong", Commons.Modules.TypeLanguage)


        vTbTitle.Columns.Add("CHUKY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAYCUOI", Type.GetType("System.String"))
        vTbTitle.Columns.Add("GIATRI", Type.GetType("System.String"))
        vTbTitle.Columns.Add("DAT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TUAN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KETQUA", Type.GetType("System.String"))
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

        vTbTitle.Columns.Add("KT_BOI", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOIDUYET_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOILAP_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAY_LAP_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAY_DUYET_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KYHIEU", Type.GetType("System.String"))

        vTbTitle.Columns.Add("GHI_CHU", Type.GetType("System.String"))
        vTbTitle.Columns.Add("trangIn", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TD1", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TD2", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TD3", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NhaXuong", Type.GetType("System.String"))

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

        Dim vNamTuan1 As String = IIf(GetTuan(vTuNgay) > 10 And vTuNgay.Month = 1, vTuNgay.AddYears(-1).Year.ToString, vTuNgay.Year.ToString)


        rowNew("T1") = GetTuan(vTuNgay).ToString & "/" & vNamTuan1
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

        rowNew("CHUKY") = ChuKy
        rowNew("NGAYCUOI") = NgayCuoi
        rowNew("GIATRI") = GiaTri
        rowNew("DAT") = Dat
        rowNew("TUAN") = Tuan
        rowNew("KETQUA") = kq

        rowNew("trangIn") = trangin
        rowNew("TD1") = TD1
        rowNew("TD2") = TD2
        rowNew("TD3") = TD3
        rowNew("NhaXuong") = NhaXuong & " " & cbxNhaXuong.Text

        rowNew("GHI_CHU") = GhiChu & FromDatetoDate()
        vTbTitle.Rows.Add(rowNew)
        Return vTbTitle
    End Function

    Function FromDatetoDate() As String

        Dim strDate As String = ""
        Dim vNamTuan1 As String = IIf(GetTuan(vTuNgay) > 10 And vTuNgay.Month = 1, vTuNgay.AddYears(-1).Year.ToString, vTuNgay.Year.ToString)

        strDate = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay).ToString & "/" & vNamTuan1 & "(" & vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay, DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(7)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(7), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay.AddDays(7), DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(14)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(14), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay.AddDays(14), DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(21)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(21), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay.AddDays(21), DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(28)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(28), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & vTuNgay.AddDays(28).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")"
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
            Try
                vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TuNgayChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End Try

            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "PhaiNhapTuNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtTuNgay.Focus()
                Exit Sub
            End If

            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "PhaiNhapDenNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtDenNgay.Focus()
                Exit Sub
            End If

            If mtxtNgayLap.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "PhaiNhapNgayLap", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtNgayLap.Focus()
                Exit Sub
            End If
            If vTuNgay > vDenNgay Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "DNPhaiLonHonTN", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtDenNgay.Focus()
                Exit Sub
            End If
            If (vDenNgay > vTuNgay.AddMonths(1)) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "TN_DNKoQua5Tuan", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtDenNgay.Focus()
                Exit Sub
            End If


            Dim frmRP As frmXMLReport = New frmXMLReport()
            frmRP.rptName = "rptKeHoachGiamSatTinhTrang"

            Dim vTbData As DataTable = New DataTable()

            Dim vtbLgangua As DataTable = languageReport()
            frmRP.AddDataTableSource(vtbLgangua)
            v_all = New DataTable()
            vTbData = Get_DataTable(cbxNhaXuong.SelectedValue.ToString(), vTuNgay, vDenNgay, "-1", "-1", "-1")
            If vTbData.Rows.Count <= 0 Or vTbData Is Nothing Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang", "MsgKhongcodulieuin", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            frmRP.AddDataTableSource(vTbData)
            frmRP.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

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
   
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date) As DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GetKeHoachGiamSatTinhTrang_NEW]", tungay, denngay))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), tungay, denngay)
                        Catch ex As Exception

                        End Try

                    Else
                        Try
                            If (v_all.Rows.Count <= 0) Then
                                v_all = vDataParent.ToTable().Copy()
                                v_all.Clear()
                            End If
                            v_all.Rows.Add(vr.ItemArray)
                        Catch ex As Exception

                        End Try

                    End If
                Next

                'v_all.Merge(temp.ToTable())

                Return v_all
            Else
                temp = vDataDetail
                Return temp.ToTable()
                'vDataParent.
            End If
        Else
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GetKeHoachGiamSatTinhTrang_NEW]", tungay, denngay))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As DataTable = New DataTable
        _table = Get_DataTable(MS_N_Xuong, tungay, denngay)
        Dim _city As String = ""
        Dim _district As String = ""
        Dim _street As String = ""
        If _table.Rows.Count > 0 Then

            If city <> "-1" Then
                _city = "MS_TINH = '" + city + "'"
                _table.DefaultView.RowFilter = _city
                _table = _table.DefaultView.ToTable()
            End If
            If district <> "-1" Then
                _district = "MS_QUAN = '" + district + "'"
                _table.DefaultView.RowFilter = _district
                _table = _table.DefaultView.ToTable()
            End If
            If street <> "-1" Then
                _street = "MS_DUONG = '" + street + "'"
                _table.DefaultView.RowFilter = _street
                _table = _table.DefaultView.ToTable()
            End If
            Dim _ms_may As String = ""
            _ms_may = "MS_MAY<>'' and MS_MAY <> ' ' and MS_MAY is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()

        End If
        Return _table
    End Function
#End Region
    
End Class
