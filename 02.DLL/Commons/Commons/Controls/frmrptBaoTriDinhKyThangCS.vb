
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms

Public Class frmrptBaoTriDinhKyThangCS
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Dim v_all As System.Data.DataTable = New System.Data.DataTable()
    Dim v_all1 As System.Data.DataTable = New System.Data.DataTable()
    Dim rcount As Integer = 3

    Private Sub frmrptBaoTriDinhKyThangCS_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("BTDK_TMP")
        Commons.Modules.ObjSystems.XoaTable("BaoTriDinhDinhKyThang_CS" + Commons.Modules.UserName)

    End Sub
    Private Sub frmrptBaoTriDinhKyThang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        vTuNgay = DateTime.Parse("01/" & DateTime.Now.Month.ToString() & "/" & DateTime.Now.Year.ToString())
        vDenNgay = vTuNgay.AddMonths(1)
        mtxtTuNgay.Text = vTuNgay.ToString("MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        loadNhaXuong()
        'loadNhaXuong()
        GetDaychuyen()
        Dim i As Integer = cbxTrangThai.Items.Count
        Try
            cbxTrangThai.SelectedIndex = 2
        Catch ex As Exception
        End Try
    End Sub
    'set ngon ngu
    Private Sub refeshLanguage()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "rptBaoTriDinhKyThangCS", Commons.Modules.TypeLanguage)
        Me.lbaChonThang.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", lbaChonThang.Name, Commons.Modules.TypeLanguage)
        Me.btnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", btnThucHien.Name, Commons.Modules.TypeLanguage)
        Me.lbaTrangThai.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", lbaTrangThai.Name, Commons.Modules.TypeLanguage)
        ' Me.lbaHienTrang.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", lbaHienTrang.Name, commons.Modules.TypeLanguage)
        Me.lbaNhaXuong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", lbaNhaXuong.Name, Commons.Modules.TypeLanguage)

    End Sub
    'Load combo nhà xưởng
    Sub loadNhaXuong()
        'cbxNhaXuong.Value = "MS_N_XUONG"
        'cbxNhaXuong.Display = "TEN_N_XUONG"
        'cbxNhaXuong.StoreName = "GetNHA_XUONGs"
        'cbxNhaXuong.Param = Commons.Modules.UserName
        'cbxNhaXuong.BindDataSource()
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
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

    'Kiểm tra Từ ngày
    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact("01/" & mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TuNgayChuaDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
    End Sub
    'set ngon ngu bao cao khong an toan
    Private Function languageReport() As System.Data.DataTable
        Dim vTbTitle As System.Data.DataTable = New System.Data.DataTable("Title")
        Dim TenCty As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Total", Commons.Modules.TypeLanguage)
        Dim PhongBan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "ToTal_Line", Commons.Modules.TypeLanguage)
        Dim TieuDeAnh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TieuDeAnh1", Commons.Modules.TypeLanguage)
        Dim TieuDeViet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TieuDeViet1", Commons.Modules.TypeLanguage)
        Dim Maso As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Maso1", Commons.Modules.TypeLanguage)
        Dim TotalPage As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TotalPage", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "NgayLap", Commons.Modules.TypeLanguage)
        Dim NguoiDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "NguoiDuyet", Commons.Modules.TypeLanguage)
        Dim NgayDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "NgayDuyet", Commons.Modules.TypeLanguage)
        Dim KyTen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KyTen", Commons.Modules.TypeLanguage)
        Dim Line As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Line", Commons.Modules.TypeLanguage)
        Dim TenMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TenMay", Commons.Modules.TypeLanguage)
        Dim MaMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "MaMay", Commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "BoPhan", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "STT", Commons.Modules.TypeLanguage)
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "CongViec", Commons.Modules.TypeLanguage)
        Dim MoTa As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "MoTa", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "PhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim TanSuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TanSuat", Commons.Modules.TypeLanguage)
        Dim TuanThucHien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TuanThucHien", Commons.Modules.TypeLanguage)
        Dim THboi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "THboi", Commons.Modules.TypeLanguage)
        Dim KetQua As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KetQua", Commons.Modules.TypeLanguage)
        Dim KTBoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KTBoi", Commons.Modules.TypeLanguage)
        Dim KyHieu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KyHieu", Commons.Modules.TypeLanguage)

        Dim Thang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Thang", Commons.Modules.TypeLanguage)
        Dim TuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TuNgay", Commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "DenNgay", Commons.Modules.TypeLanguage)

        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "GHI_CHU", Commons.Modules.TypeLanguage)


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
        rowNew("NGUOIDUYET_ND") = ""
        rowNew("NGUOILAP_ND") = ""
        rowNew("NGAY_LAP_ND") = ""
        rowNew("NGAY_DUYET_ND") = ""
        rowNew("KYHIEU") = KyHieu
        rowNew("THANG_TD") = Thang
        rowNew("TU_NGAY") = TuNgay
        rowNew("DEN_NGAY") = DenNgay
        rowNew("TU_NGAY_ND") = mtxtTuNgay.Text
        rowNew("DEN_NGAY_ND") = ""

        rowNew("GHI_CHU") = GhiChu & " " & FromDatetoDate()

        vTbTitle.Rows.Add(rowNew)
        Return vTbTitle
    End Function
    'set ngon ngu bao cao an toan 
    Private Function languageReportAnToan() As System.Data.DataTable
        Dim vTbTitle As System.Data.DataTable = New System.Data.DataTable("Title")
        Dim TenCty As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Total", Commons.Modules.TypeLanguage)
        Dim PhongBan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "ToTal_Line", Commons.Modules.TypeLanguage)
        Dim TieuDeAnh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TieuDeAnh2", Commons.Modules.TypeLanguage)
        Dim TieuDeViet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TieuDeViet2", Commons.Modules.TypeLanguage)
        Dim Maso As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Maso2", Commons.Modules.TypeLanguage)
        Dim TotalPage As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TotalPage", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "NgayLap", Commons.Modules.TypeLanguage)
        Dim NguoiDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "NguoiDuyet", Commons.Modules.TypeLanguage)
        Dim NgayDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "NgayDuyet", Commons.Modules.TypeLanguage)
        Dim KyTen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KyTen", Commons.Modules.TypeLanguage)
        Dim Line As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Line", Commons.Modules.TypeLanguage)
        Dim TenMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TenMay", Commons.Modules.TypeLanguage)
        Dim MaMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "MaMay", Commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "BoPhan", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "STT", Commons.Modules.TypeLanguage)
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "CongViec", Commons.Modules.TypeLanguage)
        Dim MoTa As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "MoTa", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "PhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim TanSuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TanSuat", Commons.Modules.TypeLanguage)
        Dim TuanThucHien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TuanThucHien", Commons.Modules.TypeLanguage)
        Dim THboi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "THboi", Commons.Modules.TypeLanguage)
        Dim KetQua As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KetQua", Commons.Modules.TypeLanguage)
        Dim KTBoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KTBoi", Commons.Modules.TypeLanguage)
        Dim KyHieu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KyHieu", Commons.Modules.TypeLanguage)

        Dim Thang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Thang", Commons.Modules.TypeLanguage)
        Dim TuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "TuNgay", Commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "DenNgay", Commons.Modules.TypeLanguage)

        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "GHI_CHU", Commons.Modules.TypeLanguage)



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
        rowNew("NGUOIDUYET_ND") = ""
        rowNew("NGUOILAP_ND") = ""
        rowNew("NGAY_LAP_ND") = ""
        rowNew("NGAY_DUYET_ND") = ""
        rowNew("KYHIEU") = KyHieu
        rowNew("THANG_TD") = Thang
        rowNew("TU_NGAY") = TuNgay
        rowNew("DEN_NGAY") = DenNgay
        rowNew("TU_NGAY_ND") = mtxtTuNgay.Text
        rowNew("DEN_NGAY_ND") = ""

        rowNew("GHI_CHU") = GhiChu & " " & FromDatetoDate()

        vTbTitle.Rows.Add(rowNew)
        Return vTbTitle
    End Function

    Function FromDatetoDate() As String
        Dim strDate As String = ""
        strDate = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay).ToString & "/" & vTuNgay.Year.ToString & "(" & vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay, DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(7)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(7), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay.AddDays(7), DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(14)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(14), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay.AddDays(14), DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(21)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(21), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & LastDayOfWeek(vTuNgay.AddDays(21), DayOfWeek.Sunday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")" & _
            "; " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Tuan", Commons.Modules.TypeLanguage) & " " & GetTuan(vTuNgay.AddDays(28)).ToString & "/" & vTuNgay.Year.ToString & " (" & FirstDayOfWeek(vTuNgay.AddDays(28), DayOfWeek.Monday).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & " - " & vTuNgay.AddDays(28).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture) & ")"
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

        v_all = New System.Data.DataTable()
        v_all1 = New System.Data.DataTable()
        If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "PhaiNhapTuNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            mtxtTuNgay.Focus()
            Exit Sub
        End If

        If gvHethong.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "khongcodaychuyen", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)

            Exit Sub
        Else
            Dim t As Integer = 0
            For Each ro As DataGridViewRow In gvHethong.Rows
                If Not ro.Cells("CHON").Value Is DBNull.Value Then
                    t = 1
                    Exit For
                End If
            Next
            If t = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "chuachondaychuyen", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If

        If cbxTrangThai.Text.Trim.ToString = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "ChuaChonTrangThai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            cbxTrangThai.Focus()
            Exit Sub
        End If

        Dim vTbData As System.Data.DataTable = New System.Data.DataTable()

        'Dim vtbLgangua As DataTable = languageReport()
        'frmRP.AddDataTableSource(vtbLgangua)
        Dim cnn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
        If (cnn.State = ConnectionState.Closed) Then
            cnn.Open()
        End If
        Try
            Cursor = Cursors.WaitCursor
            vTuNgay = Date.Parse("01/" & mtxtTuNgay.Text)
            vDenNgay = Date.Parse("01/" & mtxtTuNgay.Text).AddMonths(1)

            vTbData = Get_DataTable_ALL(cbxNhaXuong.SelectedValue.ToString(), vDenNgay, "-1", "-1", "-1")
            If (vTbData.Rows.Count > 0) Then
                For Each row As DataRow In vTbData.Rows
                    Dim ngaychuky As DateTime
                    Dim ngaycuoi As DateTime
                    ngaychuky = row("NGAY_CUOI")
                    ngaycuoi = row("NGAY_CUOI")

                    While ngaychuky <= vDenNgay
                        If Not row("CHU_KY").Equals(DBNull.Value) Then
                            Select Case row("MS_DV_TG")
                                Case 1
                                    ngaychuky = ngaychuky.AddDays(Double.Parse(row("CHU_KY").ToString))
                                Case 2
                                    ngaychuky = ngaychuky.AddDays(Double.Parse(row("CHU_KY").ToString) * 7)
                                Case 3
                                    ngaychuky = ngaychuky.AddMonths(Double.Parse(row("CHU_KY").ToString))
                                Case 4
                                    ngaychuky = ngaychuky.AddYears(Double.Parse(row("CHU_KY").ToString))
                            End Select
                            If ngaychuky >= vTuNgay And ngaychuky <= vDenNgay Then
                                If ngaychuky.DayOfWeek = DayOfWeek.Sunday Then
                                    ngaychuky = ngaychuky.AddDays(1)
                                End If
                                SqlHelper.ExecuteNonQuery(cnn, "Add_BTDK_TMP", row("MS_MAY"), row("MS_LOAI_BT"), ngaycuoi, ngaychuky, row("CHU_KY"), row("MS_DV_TG"), row("MS_HE_THONG"))
                            End If
                        Else
                            Exit While
                        End If
                    End While
                Next
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KhongCoDLDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                If (cnn.State = ConnectionState.Open) Then
                    cnn.Close()
                End If
                Exit Sub
            End If

            Dim tbTx As New System.Data.DataTable
            tbTx.Load(SqlHelper.ExecuteReader(cnn, CommandType.Text, "SELECT * FROM BTDK_TMP ORDER BY MS_MAY,MS_DV_TG,MS_LOAI_BT"))
            For Each rx As DataRow In tbTx.Rows

                Dim tbT As New System.Data.DataTable
                tbT.Load(SqlHelper.ExecuteReader(cnn, CommandType.Text, "SELECT * FROM BTDK_TMP	WHERE MS_MAY =N'" & rx("MS_MAY").ToString & "' AND MS_LOAI_BT IN (SELECT MS_LOAI_BT_CD FROM LOAI_BAO_TRI_QH WHERE MS_LOAI_BT_CT = " & rx("MS_LOAI_BT").ToString & ")"))

                Dim ngayke1 As DateTime
                ngayke1 = rx("NGAYKE")

                'Dim msm As String = "MS_MAY = '" & rx("MS_MAY").ToString & "' AND (NGAYKE>'" & r1("NGAYKE").ToString & "' or NGAYKE<'" & r1("NGAYKE") & "')"
                'Dim rs() As DataRow = Nothing
                'rs = tbT.Select(msm)
                For Each r2 As DataRow In tbT.Rows
                    Try
                        If Not rx("MS_DV_TG").Equals(DBNull.Value) Then
                            Dim ngayke2 As DateTime
                            Dim chuky As Double
                            ngayke2 = r2("NGAYKE")
                            chuky = Double.Parse(r2("MS_DV_TG").ToString)
                            Select Case chuky
                                Case 1
                                    If ngayke1 >= ngayke2.AddDays(-(chuky / 4)) And ngayke1 <= ngayke2.AddDays(chuky / 4) Then
                                        SqlHelper.ExecuteNonQuery(cnn, "Delete_BTDK_TMP", r2("MS_MAY"), r2("MS_LOAI_BT"), r2("NGAYKE"), r2("MS_DV_TG"))
                                    End If
                                Case 2
                                    If ngayke1 >= ngayke2.AddDays(-(chuky * 7 / 4)) And ngayke1 <= ngayke2.AddDays(chuky * 7 / 4) Then
                                        SqlHelper.ExecuteNonQuery(cnn, "Delete_BTDK_TMP", r2("MS_MAY"), r2("MS_LOAI_BT"), r2("NGAYKE"), r2("MS_DV_TG"))
                                    End If
                                Case 3
                                    If ngayke1 >= ngayke2.AddMonths(-(chuky / 4)) And ngayke1 <= ngayke2.AddMonths(chuky / 4) Then
                                        SqlHelper.ExecuteNonQuery(cnn, "Delete_BTDK_TMP", r2("MS_MAY"), r2("MS_LOAI_BT"), r2("NGAYKE"), r2("MS_DV_TG"))
                                    End If
                                Case 4
                                    If ngayke1 >= ngayke2.AddYears(-(chuky / 4)) And ngayke1 <= ngayke2.AddYears(chuky / 4) Then
                                        SqlHelper.ExecuteNonQuery(cnn, "Delete_BTDK_TMP", r2("MS_MAY"), r2("MS_LOAI_BT"), r2("NGAYKE"), r2("MS_DV_TG"))
                                    End If
                            End Select
                        Else
                            'Exit For
                        End If
                    Catch ex As Exception
                    End Try

                Next
            Next

            Dim tbT1 As New System.Data.DataTable
            tbT1.Load(SqlHelper.ExecuteReader(cnn, "GET_BTCVBP"))
            For Each r As DataRow In tbT1.Rows
                Dim tb2 As New System.Data.DataTable
                Dim lstPhutung As String = ""
                tb2.Load(SqlHelper.ExecuteReader(cnn, "GET_BTCVBP_TMP", r("MS_MAY"), r("MS_LOAI_BT"), r("MS_CV"), r("MS_BO_PHAN")))
                For Each r1 As DataRow In tb2.Rows
                    If lstPhutung = "" Then
                        lstPhutung = r1("TEN_PT") & " " & r1("SO_LUONG") & " " & r1("DVT")
                    Else
                        lstPhutung = lstPhutung & ", " & r1("TEN_PT") & " " & r1("SO_LUONG") & " " & r1("DVT")
                    End If
                Next
                SqlHelper.ExecuteNonQuery(cnn, "ADD_CONG_VIEC_PHU_TUNG_LIST_TMP", r("MS_MAY").ToString, r("MS_LOAI_BT").ToString, r("MS_CV").ToString, r("MS_BO_PHAN").ToString, lstPhutung)

            Next
            vTbData = New System.Data.DataTable()
            vTbData = Get_DataTable(cbxNhaXuong.SelectedValue.ToString(), cbxTrangThai.SelectedIndex, vTuNgay, vDenNgay, "-1", "-1", "-1")
            rcount = 3
            If vTbData.Rows.Count > 0 Then
                Dim sql As String = "(0"
                For Each row As DataGridViewRow In gvHethong.Rows
                    If Not row.Cells("CHON").Value Is DBNull.Value Then
                        sql = sql & "," & row.Cells("MS_HE_THONG").Value.ToString()
                    End If
                Next
                sql = sql & ")"
                Dim tbdt As New System.Data.DataTable
                vTbData.DefaultView.RowFilter = "MS_HE_THONG IN " & sql
                'tbdt = GetParentBophan(vTbData.DefaultView.ToTable())
                If vTbData.Rows.Count > 0 Then
                    ExportExcel(vTbData.DefaultView.ToTable())
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KhongCoDLDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                End If

            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "KhongCoDLDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
            If (cnn.State = ConnectionState.Open) Then
                cnn.Close()
            End If
        Catch ex As Exception
            If (cnn.State = ConnectionState.Open) Then
                cnn.Close()
            End If
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ExportExcel(ByVal tbData As System.Data.DataTable)
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)

            With ExcelSheets
                .Range("A1", "AL1").Font.Bold = True
                .Range("A1", "AL1").Merge(True)
                .Range("A1", "AL1").MergeCells = True
                .Range("A1", "AL1").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A1", "AL1").VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("A1", "AL1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "titleBaotridinhkythang", Commons.Modules.TypeLanguage)

                .Range("A2", "B2").Font.Bold = True
                .Range("A2", "B2").Merge(True)
                .Range("A2", "B2").MergeCells = True
                .Range("A2", "B2").HorizontalAlignment = XlHAlign.xlHAlignLeft
                .Range("A2", "B2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Nhaxuong", Commons.Modules.TypeLanguage) + " " + cbxNhaXuong.Text
            End With

            For Each row As DataGridViewRow In gvHethong.Rows
                If Not row.Cells("CHON").Value.Equals(DBNull.Value) Then
                    If row.Cells("CHON").Value = True Then
                        tbData.DefaultView.RowFilter = "MS_HE_THONG=" & row.Cells("MS_HE_THONG").Value.ToString
                        If tbData.DefaultView.ToTable().Rows.Count > 0 Then
                            With ExcelSheets
                                .Range("A" & rcount.ToString, "G" & rcount.ToString).Font.Bold = True
                                .Range("A" & rcount.ToString, "G" & rcount.ToString).Merge(True)
                                .Range("A" & rcount.ToString, "G" & rcount.ToString).MergeCells = True
                                .Range("A" & rcount.ToString, "G" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                .Range("A" & rcount.ToString, "G" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Daychuyen", Commons.Modules.TypeLanguage) + " " + row.Cells("TEN_HE_THONG").Value.ToString

                                .Range("H" & rcount.ToString, "AL" & rcount.ToString).Font.Bold = True
                                .Range("H" & rcount.ToString, "AL" & rcount.ToString).Merge(True)
                                .Range("H" & rcount.ToString, "AL" & rcount.ToString).MergeCells = True
                                .Range("H" & rcount.ToString, "AL" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                .Range("H" & rcount.ToString, "AL" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Thang", Commons.Modules.TypeLanguage) + " " + mtxtTuNgay.Text
                            End With
                            rcount = rcount + 1
                            AddHeader(ExcelSheets)
                            rcount = rcount + 1
                            AddDetail(tbData.DefaultView.ToTable(), ExcelSheets)
                            'rcount = rcount + 1
                        End If
                    End If

                End If
            Next

            ExcelApp.Visible = True
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub AddHeader(ByVal ExcelSheets As Excel.Worksheet)
        With ExcelSheets
            .Range("A" & rcount.ToString, "A" & rcount.ToString).Font.Bold = True
            .Range("A" & rcount.ToString, "A" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A" & rcount.ToString, "A" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("A" & rcount.ToString, "A" & rcount.ToString).ColumnWidth = 5
            .Range("A" & rcount.ToString, "A" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "STT", Commons.Modules.TypeLanguage)

            .Range("B" & rcount.ToString, "B" & rcount.ToString).Font.Bold = True
            .Range("B" & rcount.ToString, "B" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("B" & rcount.ToString, "B" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("B" & rcount.ToString, "B" & rcount.ToString).ColumnWidth = 25
            .Range("B" & rcount.ToString, "B" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "MACHINENAME", Commons.Modules.TypeLanguage)

            .Range("C" & rcount.ToString, "C" & rcount.ToString).Font.Bold = True
            .Range("C" & rcount.ToString, "C" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("C" & rcount.ToString, "C" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("C" & rcount.ToString, "C" & rcount.ToString).ColumnWidth = 15
            .Range("C" & rcount.ToString, "C" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "ID", Commons.Modules.TypeLanguage)

            .Range("D" & rcount.ToString, "D" & rcount.ToString).Font.Bold = True
            .Range("D" & rcount.ToString, "D" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignLeft
            .Range("D" & rcount.ToString, "D" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("D" & rcount.ToString, "D" & rcount.ToString).ColumnWidth = 15
            .Range("D" & rcount.ToString, "D" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "MODEL", Commons.Modules.TypeLanguage)

            .Range("E" & rcount.ToString, "E" & rcount.ToString).Font.Bold = True
            .Range("E" & rcount.ToString, "E" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("E" & rcount.ToString, "E" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("E" & rcount.ToString, "E" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "LOAIBT", Commons.Modules.TypeLanguage)

            .Range("F" & rcount.ToString, "F" & rcount.ToString).Font.Bold = True
            .Range("F" & rcount.ToString, "F" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("F" & rcount.ToString, "F" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("F" & rcount.ToString, "F" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "CHUKY", Commons.Modules.TypeLanguage)

            .Range("G" & rcount.ToString, "G" & rcount.ToString).Font.Bold = True
            .Range("G" & rcount.ToString, "G" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("G" & rcount.ToString, "G" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("G" & rcount.ToString, "G" & rcount.ToString).ColumnWidth = 15
            .Range("G" & rcount.ToString, "G" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "NGAYCUOI", Commons.Modules.TypeLanguage)

            For i As Integer = 1 To 19
                .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Font.Bold = True
                .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).ColumnWidth = 2
                .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Value = i.ToString
                If DateTime.Parse(i.ToString & "/" & mtxtTuNgay.Text).DayOfWeek = DayOfWeek.Sunday Then
                    .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Interior.Color = RGB(255, 0, 0)
                End If
            Next
            For i As Integer = 0 To 11
                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Font.Bold = True
                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).ColumnWidth = 2
                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Value = (20 + i).ToString
                Try
                    If DateTime.Parse((20 + i).ToString & "/" & mtxtTuNgay.Text).DayOfWeek = DayOfWeek.Sunday Then
                        .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Interior.Color = RGB(255, 0, 0)
                    End If
                Catch ex As Exception

                End Try

            Next
        End With
    End Sub
    Private Sub AddDetail(ByVal dtData As System.Data.DataTable, ByVal ExcelSheets As Excel.Worksheet)
        Try
            Dim inx As Integer = 0
            For Each row As DataRow In dtData.Rows
                inx += 1
                With ExcelSheets
                    .Range("A" & rcount.ToString, "A" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("A" & rcount.ToString, "A" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("A" & rcount.ToString, "A" & rcount.ToString).Value = inx

                    .Range("B" & rcount.ToString, "B" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    .Range("B" & rcount.ToString, "B" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("B" & rcount.ToString, "B" & rcount.ToString).Value = row("TEN_MAY").ToString()

                    .Range("C" & rcount.ToString, "C" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("C" & rcount.ToString, "C" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("C" & rcount.ToString, "C" & rcount.ToString).Value = row("MS_MAY").ToString()

                    .Range("D" & rcount.ToString, "D" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("D" & rcount.ToString, "D" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("D" & rcount.ToString, "D" & rcount.ToString).Value = row("MODEL").ToString()

                    .Range("E" & rcount.ToString, "E" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("E" & rcount.ToString, "E" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("E" & rcount.ToString, "E" & rcount.ToString).Value = row("TEN_LOAI_BT").ToString()

                    .Range("F" & rcount.ToString, "F" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("F" & rcount.ToString, "F" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("F" & rcount.ToString, "F" & rcount.ToString).Value = row("CHU_KY").ToString() & " " & row("TEN_DV_TG").ToString()

                    Dim nc As DateTime = DateTime.Parse(row("NGAY_CUOI").ToString)
                    .Range("G" & rcount.ToString, "G" & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("G" & rcount.ToString, "G" & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("G" & rcount.ToString, "G" & rcount.ToString).Value = String.Format("{0:dd/MM/yyyy}", nc)


                    For i As Integer = 1 To 19
                        .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Value = "" 'IIf(row("T" & i).ToString <> "0", row("T" & i).ToString, "")
                        If Int32.Parse(row("T" & i).ToString) > 0 Then
                            .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Interior.Color = RGB(200, 160, 35)
                        End If
                        If DateTime.Parse(i.ToString & "/" & mtxtTuNgay.Text).DayOfWeek = DayOfWeek.Sunday Then
                            .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Interior.Color = RGB(255, 0, 0)
                        End If
                    Next
                    For i As Integer = 0 To 11
                        .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Value = "" 'IIf(row("T" & (i + 20).ToString).ToString <> "0", row("T" & (i + 20).ToString).ToString, "")
                        If Int32.Parse(row("T" & (i + 20).ToString).ToString()) > 0 Then
                            .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Interior.Color = RGB(200, 160, 35)
                        End If
                        Try
                            If DateTime.Parse((20 + i).ToString & "/" & mtxtTuNgay.Text).DayOfWeek = DayOfWeek.Sunday Then
                                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Interior.Color = RGB(255, 0, 0)
                            End If
                        Catch ex As Exception

                        End Try
                    Next
                End With
                rcount += 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetParentBophan(ByVal dt As System.Data.DataTable) As System.Data.DataTable
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
        Dim dt As System.Data.DataTable = New System.Data.DataTable()
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
        End If

        Return ""
    End Function

    'Tuần thứ bao nhiêu của ngày
    Private Function GetTuan(ByVal vNgay As DateTime) As Integer
        Dim Calendar As New System.Globalization.GregorianCalendar()
        Dim vt As Integer = Calendar.GetWeekOfYear(vNgay, Globalization.CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday)
        Return vt
    End Function

    'Load danh sach nhan vien 
    Private Function LoadNhanVien() As System.Data.DataTable
        Dim vtbNV As System.Data.DataTable = New System.Data.DataTable()
        vtbNV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_CONG_NHAN,(HO + ' ' + TEN) AS TEN_CONG_NHAN   from CONG_NHAN "))
        Return vtbNV
    End Function

    Private Sub GetDaychuyen()
        Dim dt As New System.Data.DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_HE_THONG", Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        Dim dtcCheck As New DataColumn("CHON")
        dtcCheck.DataType = System.Type.GetType("System.Boolean")
        dt.Columns.Add(dtcCheck)
        gvHethong.DataSource = dt
        gvHethong.ReadOnly = False
        gvHethong.Columns("CHON").ReadOnly = False
        gvHethong.Columns("MS_HE_THONG").Visible = False
    End Sub

    Private Sub btnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAll.Click
        For Each row As DataGridViewRow In gvHethong.Rows
            row.Cells("CHON").Value = 1
        Next
    End Sub

    Private Sub btnBochon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBochon.Click
        For Each row As DataGridViewRow In gvHethong.Rows
            row.Cells("CHON").Value = 0
        Next
    End Sub
#Region "Nhu Y"
  

    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal antoan As Integer, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_tinh As String, ByVal ms_quan As String, ByVal ms_duong As String) As System.Data.DataTable
        Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[getBaoTriDinhDinhKyThang_CS]", antoan, tungay, denngay, MS_N_Xuong, ms_tinh, ms_quan, ms_duong))
        Return objDataTable

    End Function

    Function Get_DataTable_ALL(ByVal MS_N_Xuong As String, ByVal denngay As Date, ByVal city As String, ByVal district As String, ByVal street As String) As System.Data.DataTable
        Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[getBaoTriDinhDinhKyThang_All]", denngay, MS_N_Xuong, Commons.Modules.UserName, city, district, street))

        Return objDataTable

    End Function

#End Region

  



    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
