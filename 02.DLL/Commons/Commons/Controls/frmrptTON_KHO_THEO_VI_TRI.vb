
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptTON_KHO_THEO_VI_TRI
    Dim vtbThongtinchung As DataTable = New DataTable()
    Private SqlText As String = String.Empty
    Private Sub frmrptTON_KHO_THEO_VI_TRI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_KHO_KHO", Commons.Modules.UserName))
        cboKho.DataSource = dt
        cboKho.DisplayMember = "TEN_KHO"
        cboKho.ValueMember = "MS_KHO"

        dtTuNgay_Kho.Value = "01/01/" + DateTime.Now.Year.ToString()
        dtDenNgay_Kho.Value = "31/12/" + DateTime.Now.Year.ToString()
    End Sub
    Sub WriteXml()
        Dim frmRP As frmXMLReport = New frmXMLReport()
        Dim vtbValue As DataTable = New DataTable()
        'vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetThietBiConHanBaoHanh", vDay, cbxNhaXuong.SelectedValue, cboLoaiTB.SelectedValue))
        'Dim str As String = ""
        'Try
        '    str = "DROP TABLE dbo.TON_KHO_THEO_VI_TRI_TMP"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        'Catch ex As Exception
        'End Try
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), "GET_TON_KHO_THEO_VI_TRI", cboKho.SelectedValue, dtTuNgay_Kho.Value.Date, dtDenNgay_Kho.Value, Commons.Modules.TypeLanguage)
        'vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT * FROM TON_KHO_THEO_VI_TRI_TMP"))
        vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GET_TON_KHO_THEO_VI_TRI", cboKho.SelectedValue, dtTuNgay_Kho.Value.Date, dtDenNgay_Kho.Value, Commons.Modules.TypeLanguage))

        vtbValue.TableName = "TON_KHO_THEO_VI_TRI_TMP"
        frmRP.rptName = "rptTON_KHO_THEO_VI_TRI"
        If vtbValue.Rows.Count > 0 Then
            Dim vtblg As DataTable = New DataTable()
            RefeshHeaderReport()
            vtblg = CreaterptTIEU_DE_TON_KHO_THEO_VI_TRI()
            frmRP.AddDataTableSource(vtbThongtinchung)
            frmRP.AddDataTableSource(vtblg)
            frmRP.AddDataTableSource(vtbValue)
            frmRP.ShowDialog()
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "KhongCoDuLieuDeIn", Commons.Modules.TypeLanguage))
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
    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'clsXuLy.CreateTitleReport()
        'ShowrptTON_THEO_VI_TRI()
        WriteXml()
        Me.Cursor = Cursors.Default
    End Sub

    Sub ShowrptTON_THEO_VI_TRI()
        Try
            Dim str As String = ""
            Try
                str = "DROP TABLE dbo.TON_KHO_THEO_VI_TRI_TMP"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), "GET_TON_KHO_THEO_VI_TRI", cboKho.SelectedValue, dtTuNgay_Kho.Value.Date, dtDenNgay_Kho.Value, Commons.Modules.TypeLanguage)
            CreaterptTIEU_DE_TON_KHO_THEO_VI_TRI()
            ReportPreview("reports/rptTON_KHO_THEO_VI_TRI.rpt")
        Catch ex As Exception

        End Try


    End Sub
    Function CreaterptTIEU_DE_TON_KHO_THEO_VI_TRI() As DataTable
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TieuDe4", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TrangIn", Commons.Modules.TypeLanguage)
        Dim sMaKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "MaKho", Commons.Modules.TypeLanguage)
        Dim sTenKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenKho", Commons.Modules.TypeLanguage) & " : " & cboKho.Text
        Dim sMaPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "MaPT", Commons.Modules.TypeLanguage)
        Dim sTenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenPT", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sTenViTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenViTri", Commons.Modules.TypeLanguage)
        Dim sDVT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sDVT", Commons.Modules.TypeLanguage)
        Dim sTonDK As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TonDK", Commons.Modules.TypeLanguage)
        Dim sNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sNhap", Commons.Modules.TypeLanguage)
        Dim sXuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sXuat", Commons.Modules.TypeLanguage)

        Dim sTonCK As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TonCK", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Tong", Commons.Modules.TypeLanguage)
        Dim ChuyenDi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Di_Chuyen", Commons.Modules.TypeLanguage)
        Dim ChuyenDen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "CL_KK", Commons.Modules.TypeLanguage)
        Dim ThoiGian As String = lblTungay.Text & " " & dtTuNgay_Kho.Value & "  " & lblDenngay.Text & " " & Format(dtDenNgay_Kho.Value, "short date") '  cboThang.SelectedValue
        Dim Part_no As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Part_No", Commons.Modules.TypeLanguage)
        Dim Gia_Tri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Gia_Tri", Commons.Modules.TypeLanguage)
        Dim Ton_Min As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Ton_Min", Commons.Modules.TypeLanguage)
        Dim Ten_Class As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Ten_Class", Commons.Modules.TypeLanguage)
        Dim T1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T1", Commons.Modules.TypeLanguage)
        Dim T2 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T2", Commons.Modules.TypeLanguage)
        Dim T3 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T3", Commons.Modules.TypeLanguage)
        Dim T4 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T4", Commons.Modules.TypeLanguage)
        Dim T5 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T5", Commons.Modules.TypeLanguage)
        Dim T6 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T6", Commons.Modules.TypeLanguage)
        Dim T7 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T7", Commons.Modules.TypeLanguage)

        Dim vTbTitle As DataTable = New DataTable()
        vTbTitle.Columns.Add("TypeLanguage", Type.GetType("System.String"))
        vTbTitle.Columns.Add("Trangin", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NgayIn", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TieuDe", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MaKho", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TenKho", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MaPT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TenPT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("QuyCach", Type.GetType("System.String"))
        vTbTitle.Columns.Add("sDVT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TenViTri", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TonDK", Type.GetType("System.String"))
        vTbTitle.Columns.Add("sNhap", Type.GetType("System.String"))
        vTbTitle.Columns.Add("sXuat", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TonCK", Type.GetType("System.String"))
        vTbTitle.Columns.Add("Tong", Type.GetType("System.String"))
        vTbTitle.Columns.Add("STT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("ChuyenDi", Type.GetType("System.String"))
        vTbTitle.Columns.Add("ChuyenDen", Type.GetType("System.String"))
        vTbTitle.Columns.Add("ThoiGian", Type.GetType("System.String"))
        vTbTitle.Columns.Add("PART_NO", Type.GetType("System.String"))
        vTbTitle.Columns.Add("GIA_TRI", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TON_MIN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TEN_CLASS", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T1", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T2", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T3", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T4", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T5", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T6", Type.GetType("System.String"))
        vTbTitle.Columns.Add("T7", Type.GetType("System.String"))
        Dim rowNew As DataRow = vTbTitle.NewRow()
        rowNew("TypeLanguage") = Commons.Modules.TypeLanguage
        rowNew("Trangin") = sTrangIn
        rowNew("NgayIn") = sNgayIn
        rowNew("TieuDe") = sTieudeReport
        rowNew("MaKho") = sMaKho
        rowNew("TenKho") = sTenKho
        rowNew("MaPT") = sMaPT
        rowNew("TenPT") = sTenPT
        rowNew("QuyCach") = sQuyCach
        rowNew("sDVT") = sDVT
        rowNew("TenViTri") = sTenViTri
        rowNew("TonDK") = sTonDK
        rowNew("sNhap") = sNhap
        rowNew("sXuat") = sXuat
        rowNew("ChuyenDi") = ChuyenDi
        rowNew("ChuyenDen") = ChuyenDen
        rowNew("TonCK") = sTonCK
        rowNew("Tong") = sTong
        rowNew("STT") = sSTT
        rowNew("ThoiGian") = ThoiGian
        rowNew("PART_NO") = Part_no
        rowNew("GIA_TRI") = Gia_Tri
        rowNew("TON_MIN") = Ton_Min
        rowNew("TEN_CLASS") = Ten_Class
        rowNew("T1") = T1
        rowNew("T2") = T2
        rowNew("T3") = T3
        rowNew("T4") = T4
        rowNew("T5") = T5
        rowNew("T6") = T6
        rowNew("T7") = T7
        vTbTitle.Rows.Add(rowNew)
        Return vTbTitle

    End Function
    'Sub CreaterptTIEU_DE_TON_KHO_THEO_VI_TRI()
    '    Dim str As String = ""
    '    Try
    '        str = "DROP TABLE rptTIEU_DE_TON_KHO_THEO_VI_TRI"
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    '    Catch ex As Exception

    '    End Try
    '    str = "CREATE TABLE DBO.rptTIEU_DE_TON_KHO_THEO_VI_TRI(TypeLanguage int , Trangin nvarchar(120), NgayIn nvarchar(120),TieuDe nvarchar(255),MaKho nvarchar(120)," & _
    '            "TenKho nvarchar(130),MaPT nvarchar(120),TenPT nvarchar(130),QuyCach nvarchar(130),TenViTri nvarchar(130),sDVT nvarchar(120),TonDK nvarchar(120),sNhap nvarchar(120),sXuat nvarchar(120)," & _
    '            "ChuyenDi nvarchar(120),ChuyenDen nvarchar(120), TonCK nvarchar(120),Tong nvarchar(120),STT nvarchar(15),ThoiGian nvarchar(200),PART_NO NVARCHAR (256),GIA_TRI NVARCHAR (256),TON_MIN NVARCHAR (256), TEN_CLASS NVARCHAR (256),T1 NVARCHAR (256),T2 NVARCHAR (256),T3 NVARCHAR (256),T4 NVARCHAR (256),T5 NVARCHAR (256),T6 NVARCHAR (256),T7 NVARCHAR (256))"
    '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

    '    Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TieuDe4", Commons.Modules.TypeLanguage)
    '    Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "STT", Commons.Modules.TypeLanguage)
    '    Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "NgayIn", Commons.Modules.TypeLanguage)
    '    Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TrangIn", Commons.Modules.TypeLanguage)
    '    Dim sMaKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "MaKho", Commons.Modules.TypeLanguage)
    '    Dim sTenKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenKho", Commons.Modules.TypeLanguage) & " : " & cboKho.Text
    '    Dim sMaPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "MaPT", Commons.Modules.TypeLanguage)
    '    Dim sTenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenPT", Commons.Modules.TypeLanguage)
    '    Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "QuyCach", Commons.Modules.TypeLanguage)
    '    Dim sTenViTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TenViTri", Commons.Modules.TypeLanguage)
    '    Dim sDVT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sDVT", Commons.Modules.TypeLanguage)
    '    Dim sTonDK As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TonDK", Commons.Modules.TypeLanguage)
    '    Dim sNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sNhap", Commons.Modules.TypeLanguage)
    '    Dim sXuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "sXuat", Commons.Modules.TypeLanguage)
    '    Dim sChuyenDi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "DI_CHUYEN", Commons.Modules.TypeLanguage)
    '    Dim sChuyenDen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "CL_KK", Commons.Modules.TypeLanguage)
    '    Dim sTonCK As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "TonCK", Commons.Modules.TypeLanguage)
    '    Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Tong", Commons.Modules.TypeLanguage) '
    '    Dim ThoiGian As String = lblTungay.Text & " " & dtTuNgay_Kho.Value & "  " & lblDenngay.Text & " " & Format(dtDenNgay_Kho.Value, "short date") 'cboThang.SelectedValue"
    '    Dim Part_no As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Part_No", Commons.Modules.TypeLanguage)
    '    Dim Gia_Tri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Gia_Tri", Commons.Modules.TypeLanguage)
    '    Dim Ton_Min As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Ton_Min", Commons.Modules.TypeLanguage)
    '    Dim Ten_Class As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "Ten_Class", Commons.Modules.TypeLanguage)
    '    Dim T1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T1", Commons.Modules.TypeLanguage)
    '    Dim T2 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T2", Commons.Modules.TypeLanguage)
    '    Dim T3 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T3", Commons.Modules.TypeLanguage)
    '    Dim T4 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T4", Commons.Modules.TypeLanguage)
    '    Dim T5 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T5", Commons.Modules.TypeLanguage)
    '    Dim T6 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T6", Commons.Modules.TypeLanguage)
    '    Dim T7 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_VI_TRI", "T7", Commons.Modules.TypeLanguage)
    '    str = "INSERT INTO [DBO].rptTIEU_DE_TON_KHO_THEO_VI_TRI(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
    '            "MaKho,TenKho,MaPT,TenPT,QuyCach,TenViTri,sDVT,TonDK,sNhap,sXuat,ChuyenDi,ChuyenDen,TonCK,Tong,STT,ThoiGian ,Part_No,Gia_Tri,Ton_Min,Ten_Class,T1,T2,T3,T4,T5,T6,T7)" & _
    '            "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
    '            "N'" & sTieudeReport & "',N'" & sMaKho & "',N'" & sTenKho & "',N'" & sMaPT & "',N'" & sTenPT & "',N'" & sQuyCach & "',N'" & sTenViTri & "',N'" & sDVT & "',N'" & sTonDK & "',N'" & sNhap & "'," & _
    '        "N'" & sXuat & "',N'" & sChuyenDi & "',N'" & sChuyenDen & "',N'" & sTonCK & "',N'" & sTong & "',N'" & sSTT & "',N'" & ThoiGian & "'" & ",N'" & Part_no & "'" & ",N'" & Gia_Tri & "'" & ",N'" & Ton_Min & "'" & ",N'" & Ten_Class & "'" & ",N'" & T1 & "'" & ",N'" & T2 & "'" & ",N'" & T3 & "'" & ",N'" & T4 & "'" & ",N'" & T5 & "'" & ",N'" & T6 & "'" & ",N'" & T7 & "')"
    '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)


    'End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
