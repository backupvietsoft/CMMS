
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptTON_KHO_KHONG_THEO_VI_TRI
    Private SqlText As String = String.Empty
    Dim vtbThongtinchung As DataTable = New DataTable()
    Private Sub frmrptTON_KHO_KHONG_THEO_VI_TRI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_KHO_KHO", Commons.Modules.UserName))
        cboKho.DataSource = dt
        cboKho.DisplayMember = "TEN_KHO"
        cboKho.ValueMember = "MS_KHO"

        dtTuNgay_Kho.Value = "01/01/" + DateTime.Now.Year.ToString()
        dtDenNgay_Kho.Value = "31/12/" + DateTime.Now.Year.ToString()

    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'clsXuLy.CreateTitleReport()
        'ShowrptTON_KHONG_THEO_VI_TRI()
        WriteXml()
        Me.Cursor = Cursors.Default
    End Sub
    Sub WriteXml()
        Dim frmRP As frmXMLReport = New frmXMLReport()
        Dim vtbValue As DataTable = New DataTable()
        'vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetThietBiConHanBaoHanh", vDay, cbxNhaXuong.SelectedValue, cboLoaiTB.SelectedValue))
        Dim str As String = ""
        Try
            str = "DROP TABLE dbo.TON_KHO_KHONG_THEO_VI_TRI_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), "GET_TON_KHO_KHONG_THEO_VI_TRI", cboKho.SelectedValue, dtTuNgay_Kho.Value.Date, dtDenNgay_Kho.Value, Commons.Modules.TypeLanguage)
        vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT * FROM TON_KHO_KHONG_THEO_VI_TRI_TMP"))
        vtbValue.TableName = "TON_KHO_KHONG_THEO_VI_TRI_TMP"
        frmRP.rptName = "rptTON_KHO_KHONG_THEO_VI_TRI"
        If vtbValue.Rows.Count > 0 Then
            Dim vtblg As DataTable = New DataTable()
            RefeshHeaderReport()
            vtblg = CreaterptTIEU_DE_TON_KHO_KHONG_THEO_VI_TRI()
            frmRP.AddDataTableSource(vtbThongtinchung)
            frmRP.AddDataTableSource(vtblg)
            frmRP.AddDataTableSource(vtbValue)
            frmRP.Show()
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "KhongCoDuLieuDeIn", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
    End Sub
    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Sub RefeshHeaderReport()
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        'Dim source As DataSet = New DataSet()
        'Try
        '    SqlText = "DROP TABLE rptTHONG_TIN_CHUNG_TMP"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        'Catch ex As Exception
        'End Try
        vtbThongtinchung = New DataTable("rptTHONG_TIN_CHUNG_TMP")
        If Commons.Modules.TypeLanguage = 1 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS THONG_TIN_CTY, THONG_TIN_CHUNG.LOGO,  THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI_CTY, THONG_TIN_CHUNG.phone as DIEN_THOAI ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT,THONG_TIN_CHUNG.LE_TREN_LOGO,ngay_in='" & TDateFormat(Now) & "'   FROM THONG_TIN_CHUNG"
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS THONG_TIN_CTY, THONG_TIN_CHUNG.LOGO,  THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI_CTY, THONG_TIN_CHUNG.phone as DIEN_THOAI ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT,THONG_TIN_CHUNG.LE_TREN_LOGO,ngay_in='" & TDateFormat(Now) & "'   FROM THONG_TIN_CHUNG"
            'SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngay & "' INTO rptTHONG_TIN_CHUNG FROM THONG_TIN_CHUNG "
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
    End Sub
    Sub ShowrptTON_KHONG_THEO_VI_TRI()
        Try
            Dim str As String = ""
            Try
                str = "DROP TABLE dbo.TON_KHO_KHONG_THEO_VI_TRI_TMP"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), "GET_TON_KHO_KHONG_THEO_VI_TRI", cboKho.SelectedValue, dtTuNgay_Kho.Value.Date, dtDenNgay_Kho.Value, Commons.Modules.TypeLanguage)
            CreaterptTIEU_DE_TON_KHO_KHONG_THEO_VI_TRI()
            ReportPreview("reports/rptTON_KHO_KHONG_THEO_VI_TRI.rpt")
        Catch ex As Exception
        End Try
    End Sub

    Function CreaterptTIEU_DE_TON_KHO_KHONG_THEO_VI_TRI() As DataTable
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TieuDe5", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TrangIn", Commons.Modules.TypeLanguage)
        Dim sMaKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "MaKho", Commons.Modules.TypeLanguage)
        Dim sTenKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TenKho", Commons.Modules.TypeLanguage) & " : " & cboKho.Text
        Dim sMaPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "MaPT", Commons.Modules.TypeLanguage)
        Dim sTenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TenPT", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sDVT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "sDVT", Commons.Modules.TypeLanguage)
        Dim sTonDK As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TonDK", Commons.Modules.TypeLanguage)
        Dim sNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "sNhap", Commons.Modules.TypeLanguage)
        Dim sXuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "sXuat", Commons.Modules.TypeLanguage)
        Dim sTonCK As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "TonCK", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "Tong", Commons.Modules.TypeLanguage)
        Dim ChuyenDi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "Di_Chuyen", Commons.Modules.TypeLanguage)
        Dim ChuyenDen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "CL_KK", Commons.Modules.TypeLanguage)
        Dim ThoiGian As String = lblTungay.Text & " " & dtTuNgay_Kho.Value & "  " & lblDenngay.Text & " " & Format(dtDenNgay_Kho.Value, "short date") '  cboThang.SelectedValue

        Dim NgayBaoCao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "NgayBaoCao", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_KHONG_THEO_VI_TRI", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim vTbTitle As DataTable = New DataTable()
        vTbTitle.Columns.Add("TypeLanguage", Type.GetType("System.String"))
        vTbTitle.Columns.Add("Trangin", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NgayIn", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TieuDe1", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MaKho", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TenKho", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MaPT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TenPT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("QuyCach", Type.GetType("System.String"))
        vTbTitle.Columns.Add("sDVT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TonDK", Type.GetType("System.String"))
        vTbTitle.Columns.Add("sNhap", Type.GetType("System.String"))
        vTbTitle.Columns.Add("sXuat", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TonCK", Type.GetType("System.String"))
        vTbTitle.Columns.Add("Tong", Type.GetType("System.String"))
        vTbTitle.Columns.Add("STT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("ChuyenDi", Type.GetType("System.String"))
        vTbTitle.Columns.Add("ChuyenDen", Type.GetType("System.String"))
        vTbTitle.Columns.Add("ThoiGian", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NgayBaoCao", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NguoiLap", Type.GetType("System.String"))
        Dim rowNew As DataRow = vTbTitle.NewRow()
        rowNew("TypeLanguage") = Commons.Modules.TypeLanguage
        rowNew("Trangin") = sTrangIn
        rowNew("NgayIn") = sNgayIn
        rowNew("TieuDe1") = sTieudeReport
        rowNew("MaKho") = sMaKho
        rowNew("TenKho") = sTenKho
        rowNew("MaPT") = sMaPT
        rowNew("TenPT") = sTenPT
        rowNew("QuyCach") = sQuyCach
        rowNew("sDVT") = sDVT
        rowNew("TonDK") = sTonDK
        rowNew("sNhap") = sNhap

        rowNew("sXuat") = sXuat
        rowNew("TonCK") = sTonCK
        rowNew("Tong") = sTong
        rowNew("STT") = sSTT
        rowNew("ChuyenDi") = ChuyenDi
        rowNew("ChuyenDen") = ChuyenDen
        rowNew("ThoiGian") = ThoiGian
        rowNew("NgayBaoCao") = NgayBaoCao
        rowNew("NguoiLap") = NguoiLap
        vTbTitle.Rows.Add(rowNew)

        Return vTbTitle

    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE dbo.TON_KHO_KHONG_THEO_VI_TRI_TMP")
        Catch ex As Exception
        End Try
        Me.ParentForm.Close()
    End Sub
End Class
