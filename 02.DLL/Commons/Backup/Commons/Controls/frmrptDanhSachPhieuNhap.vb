Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Imports Commons.VS.Classes.Catalogue
Imports System.Globalization
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data
Imports Commons.VS.Classes.Admin
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms

Public Class frmrptDanhSachPhieuNhap
    Dim sqlColection As String
    Private SqlText As String = String.Empty
    Dim _isLoad = False
    Dim tuNgay As New DateTime()
    Dim denNgay As New DateTime()
    Dim dsTable As New DataSet
    Public Function CreateDataTable() As DataTable
        Dim table As DataTable
        table = New DataTable
        table.Columns.Add(New DataColumn("MS_NHAP", Type.GetType("System.String")))
        table.Columns.Add(New DataColumn("DANG_NHAP_VIET", Type.GetType("System.String")))
        table.Columns.Add(New DataColumn("DANG_NHAP", Type.GetType("System.String")))
        table.Columns.Add(New DataColumn("DANG_NHAP_ANH", Type.GetType("System.String")))
        table.Columns.Add(New DataColumn("DANG_NHAP_HOA", Type.GetType("System.String")))
        Return table
    End Function

    Sub RefeshLanguageGridView()
        Me.gvPhieuNhapKho.Columns("DANG_NHAP").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "DANG_NHAP", Commons.Modules.TypeLanguage)
        Try
            Me.gvPhieuNhapKho.Columns("CHON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "CHON", Commons.Modules.TypeLanguage)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub GetTuNgay_DenNgay(ByVal date1 As DateTime, ByVal date2 As DateTime)
        tuNgay = date1
        denNgay = date2
    End Sub

    Private Sub frmrptDanhSachPhieuNhap_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Try
            SqlText = "DROP TABLE dbo.rptDanhSachPhieuNhap_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmrptDanhSachPhieuNhap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        daTimeTuNgay.EditValue = GetFirstDayOfMonth(DateTime.Now.Month)
        daTimeDenNgay.EditValue = GetLastDayOfMonth(DateTime.Now.Month)
        GetTuNgay_DenNgay(daTimeTuNgay.EditValue, daTimeDenNgay.EditValue)
        Load_TenKho()
        LoadGrid_PhieuNhap(cmbKho.Text, tuNgay, denNgay)
        RefeshLanguageGridView()
        _isLoad = True
    End Sub
    ' Load ten kho len combo kho
    Public Sub Load_TenKho()

        Commons.Modules.SQLString = "Select MS_KHO , Ten_Kho from IC_Kho "
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbKho, dt, "MS_KHO", "Ten_Kho", "")

    End Sub
    Public Function ConverDateYMD(ByVal ngay As DateTime) As String
        Return (ngay.Year.ToString + "/" + ngay.Month.ToString + "/" + ngay.Day.ToString)
    End Function
    ' Load len gridview Phieu nhap kho
    'Public Sub Load_Grid_DangNhap(ByVal tenKho As String, ByVal date1 As DateTime, ByVal date2 As DateTime)
    '    
    '    Dim ngay1, ngay2 As String
    '    ' denNgay + 1
    '    date2 = denNgay
    '    date2 = date2.AddDays(1)
    '    ngay1 = ConvertDateYMD(date1)
    '    ngay2 = ConvertDateYMD(date2)
    '    commons.Modules.SQLString = "Select dbo.DANG_NHAP.MS_DANG_NHAP, dbo.DANG_NHAP.DANG_NHAP_VIET, dbo.DANG_NHAP.DANG_NHAP_ANH, dbo.DANG_NHAP.DANG_NHAP_HOA"
    '    commons.Modules.SQLString += " From IC_KHO , IC_DON_HANG_NHAP , DANG_NHAP "
    '    commons.Modules.SQLString += " Where dbo.IC_KHO.MS_KHO = dbo.IC_DON_HANG_NHAP.MS_KHO and  dbo.DANG_NHAP.MS_DANG_NHAP = dbo.IC_DON_HANG_NHAP.MS_DANG_NHAP"
    '    commons.Modules.SQLString += "  And dbo.IC_DON_HANG_NHAP.NGAY Between '" + ngay1 + "' and '" + ngay2 + "'   "
    '    'commons.Modules.SQLString += "  And hn.NGAY_CHUNG_TU >= '" + ngay1 + "' and hn.NGAY_CHUNG_TU <= '" + ngay2 + "'   "
    '    commons.Modules.SQLString += " Group by dbo.DANG_NHAP.MS_DANG_NHAP, dbo.DANG_NHAP.DANG_NHAP_VIET, dbo.DANG_NHAP.DANG_NHAP_ANH, dbo.DANG_NHAP.DANG_NHAP_HOA"
    '    Dim myReader As SqlDataReader
    '    Dim dt As DataTable
    '    dt = CreateDataTable()
    '    myReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
    '    Try
    '        While (myReader.Read)
    '            Dim myRow As DataRow = dt.NewRow
    '            myRow("Mã dạng nhập") = myReader("MS_DANG_NHAP").ToString
    '            myRow("Dạng nhập Việt") = myReader("DANG_NHAP_VIET").ToString
    '            myRow("Dạng nhập") = myReader("DANG_NHAP_VIET").ToString
    '            myRow("Dạng nhập Anh") = myReader("DANG_NHAP_ANH").ToString
    '            myRow("Dạng nhập Hoa") = myReader("DANG_NHAP_HOA").ToString
    '            dt.Rows.Add(myRow)
    '        End While
    '    Catch ex As Exception

    '    End Try
    '    gvPhieuNhapKho.DataSource = Nothing
    '    gvPhieuNhapKho.Columns.Clear()
    '    gvPhieuNhapKho.DataSource = dt
    '    Visible_ColumsGridView()
    '    gvPhieuNhapKho.AllowUserToAddRows = False
    '    Add_Check_GridView(gvPhieuNhapKho)
    'End Sub
    ' Add check box vào da ta grid view
    Public Sub Add_Check_GridView(ByVal gv As DataGridView)
        Dim check As New DataGridViewCheckBoxColumn
        check.Name = "CHON"
        check.HeaderText = "CHON"
        check.Selected = False
        gv.Columns.Add(check)
    End Sub
    Public Sub Visible_ColumsGridView()
        gvPhieuNhapKho.Columns("DANG_NHAP_ANH").Visible = False
        gvPhieuNhapKho.Columns("DANG_NHAP_HOA").Visible = False
        gvPhieuNhapKho.Columns("DANG_NHAP_VIET").Visible = False
        gvPhieuNhapKho.Columns("MS_NHAP").Visible = False
    End Sub

    Public Sub GetParameterReport(ByVal ds As DataSet, ByVal tenKho As String, ByVal date1 As DateTime, ByVal date2 As DateTime)
        'frmReportPhieuNhap.danhSach = ds
        'frmReportPhieuNhap.tenKho = tenKho
        'frmReportPhieuNhap.tuNgay = date1
        'frmReportPhieuNhap.denNgay = date2
    End Sub

    Public Function Get_MaKho(ByVal tenKho As String) As Integer

        Dim maKho As Integer
        Commons.Modules.SQLString = "Select MS_KHO From IC_KHO Where TEN_KHO like N'%" + tenKho + "%'"
        maKho = Integer.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString).ToString())
        Return maKho
    End Function

    Public Function ConvertDateYMD(ByVal ngay As DateTime) As String
        Return (ngay.Year.ToString + "/" + ngay.Month.ToString + "/" + ngay.Day.ToString)
    End Function
    Public Function DuyetGridView(ByVal maKho As String, ByVal tenKho As String, ByVal date1 As DateTime, ByVal date2 As DateTime) As Collection
        Dim arrSql As New Collection
        Try
            Dim ngay1, ngay2 As String
            Dim msNhap, Sql As String
            date2 = date2.AddDays(1)
            ngay1 = ConvertDateYMD(date1)
            ngay2 = ConvertDateYMD(date2)
            Dim i As Integer


            For i = 0 To gvPhieuNhapKho.Rows.Count - 1
                Dim dt As New DataGridViewCheckBoxCell
                dt = gvPhieuNhapKho.Rows(i).Cells("CHON")
                Sql = ""
                If (dt.Value = -1) Then
                    msNhap = gvPhieuNhapKho.Rows(i).Cells("MS_NHAP").Value.ToString
                    Sql = " SELECT     DBO.IC_DON_HANG_NHAP.NGAY, DBO.IC_DON_HANG_NHAP.SO_PHIEU_XN, DBO.IC_DON_HANG_NHAP.MS_KHO, DBO.DANG_NHAP.DANG_NHAP_VIET, "
                    Sql += " DBO.IC_DON_HANG_NHAP.SO_CHUNG_TU, DBO.IC_DON_HANG_NHAP.GHI_CHU, DBO.View_GT_DH_NHAP.GIA_TRI, DBO.IC_KHO.TEN_KHO "
                    Sql += " From IC_DON_HANG_NHAP , View_GT_DH_NHAP , DANG_NHAP , IC_KHO  "
                    Sql += " Where  DBO.IC_DON_HANG_NHAP.MS_DH_NHAP_PT = View_GT_DH_NHAP.MS_DH_NHAP_PT and DBO.IC_DON_HANG_NHAP.MS_DANG_NHAP = DBO.DANG_NHAP.MS_DANG_NHAP and "
                    Sql += " dbo.IC_KHO.MS_KHO = dbo.IC_DON_HANG_NHAP.MS_KHO And DBO.IC_DON_HANG_NHAP.MS_KHO = '" + maKho + "' "
                    Sql += " And DANG_NHAP.MS_DANG_NHAP = '" + msNhap + "'"
                    Sql += " And DBO.IC_DON_HANG_NHAP.Ngay Between '" + ngay1 + "' and '" + ngay2 + "'"
                    Sql += " union "
                    arrSql.Add(Sql)
                End If
            Next
            Return arrSql
        Catch ex As Exception
            Return arrSql
        End Try

    End Function
    Public Function XuatBaoCao(ByVal arrSql As Collection) As DataSet
        Dim i As Integer
        Dim ds As New DataSet
        Dim sql As String = ""
        For i = 1 To arrSql.Count
            sql += arrSql(i).ToString
        Next
        If (sql.Length > 0) Then
            sql = sql.Substring(0, sql.Length - "union ".Length)
            sqlColection = sql
            ds = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        Else
            MessageBox.Show("Chưa chọn dữ liệu để in", "Thông báo", MessageBoxButtons.OK)
        End If

        Return ds
    End Function


    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Sub RefeshHeaderReport()
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        Try
            SqlText = "DROP TABLE rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        If Commons.Modules.TypeLanguage = 1 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS TEN_CTY, THONG_TIN_CHUNG.TEN_NGAN_TIENG_ANH AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngayanh & "' INTO [dbo].rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngay & "' INTO [dbo].rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
    End Sub
    Public Sub CreateTitleObjectReport()
        Dim TIEU_DE, NGAY_IN, NHAP_TU_KHO, TU_NGAY, DEN_NGAY, CHO_CAC_DANG_NHAP As String
        Dim SO_PHIEU_NHAP, NGAY, TEN_KHO, SO_CHUNG_TU, LY_DO_NHAP, MUC_DICH_NHAP, GIA_TRI As String
        Dim DIEN_THOAI, FAX, TONG_SO, TONG_CONG, TRANG_IN, NGAY_THANG_NAM As String
        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "TIEU_DE", Commons.Modules.TypeLanguage)
        NGAY_IN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "NGAY_IN", Commons.Modules.TypeLanguage)
        NHAP_TU_KHO = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "NHAP_TU_KHO", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "DEN_NGAY", Commons.Modules.TypeLanguage)
        CHO_CAC_DANG_NHAP = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "CHO_CAC_DANG_NHAP", Commons.Modules.TypeLanguage)
        SO_PHIEU_NHAP = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "SO_PHIEU_NHAP", Commons.Modules.TypeLanguage)
        NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "NGAY", Commons.Modules.TypeLanguage)
        TEN_KHO = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "TEN_KHO", Commons.Modules.TypeLanguage)
        SO_CHUNG_TU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "SO_CHUNG_TU", Commons.Modules.TypeLanguage)
        LY_DO_NHAP = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "LY_DO_NHAP", Commons.Modules.TypeLanguage)
        MUC_DICH_NHAP = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "MUC_DICH_NHAP", Commons.Modules.TypeLanguage)
        GIA_TRI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "GIA_TRI", Commons.Modules.TypeLanguage)
        DIEN_THOAI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "DIEN_THOAI", Commons.Modules.TypeLanguage)
        GIA_TRI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "GIA_TRI", Commons.Modules.TypeLanguage)
        FAX = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "FAX", Commons.Modules.TypeLanguage)
        TONG_SO = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "TONG_SO", Commons.Modules.TypeLanguage)
        TONG_CONG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "TONG_CONG", Commons.Modules.TypeLanguage)
        TRANG_IN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "TRANG_IN", Commons.Modules.TypeLanguage)
        NGAY_THANG_NAM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuNhap", "NGAY_THANG_NAM", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDanhSachPhieuNhap_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDanhSachPhieuNhap_TMP "
        SqlText += " (TypeLanguage int ,TIEU_DE nvarchar(250), NGAY_IN nvarchar(50), NHAP_TU_KHO nvarchar(250), TU_NGAY nvarchar(50), DEN_NGAY nvarchar(50), CHO_CAC_DANG_NHAP nvarchar(400), SO_PHIEU_NHAP nvarchar(50), NGAY nvarchar(50),TEN_KHO nvarchar(250),SO_CHUNG_TU nvarchar(50),LY_DO_NHAP nvarchar(250), MUC_DICH_NHAP NVARCHAR(250), GIA_TRI nvarchar(50)  , "
        SqlText += " DIEN_THOAI nvarchar(20), FAX nvarchar(20) , TONG_SO nvarchar(20), TONG_CONG nvarchar(20), TRANG_IN nvarchar(20) , NGAY_THANG_NAM nvarchar(250)) "
        SqlText += " INSERT INTO [DBO].rptDanhSachPhieuNhap_TMP(commons.Modules.TypeLanguage,TIEU_DE, NGAY_IN,NHAP_TU_KHO,TU_NGAY, "
        SqlText += " DEN_NGAY,CHO_CAC_DANG_NHAP,SO_PHIEU_NHAP,NGAY ,TEN_KHO,SO_CHUNG_TU,LY_DO_NHAP, MUC_DICH_NHAP,GIA_TRI, "
        SqlText += " DIEN_THOAI, FAX, TONG_SO, TONG_CONG, TRANG_IN, NGAY_THANG_NAM )"
        SqlText += " VALUES(" & Commons.Modules.TypeLanguage & ",N'" & TIEU_DE & "',N'" & NGAY_IN & "',N'" & NHAP_TU_KHO & "',"
        SqlText += " N'" & TU_NGAY & "',N'" & DEN_NGAY & "',N'" & CHO_CAC_DANG_NHAP & "',N'" & SO_PHIEU_NHAP & "',N'" & NGAY & "',N'" & TEN_KHO & "',"
        SqlText += " N'" & SO_CHUNG_TU & "',N'" & LY_DO_NHAP & "',N'" & MUC_DICH_NHAP & "',N'" & GIA_TRI & "', "
        SqlText += " N'" & DIEN_THOAI & "',N'" & FAX & "',N'" & TONG_SO & "', "
        SqlText += " N'" & TONG_CONG & "',N'" & TRANG_IN & "',N'" & NGAY_THANG_NAM & "') "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub
    ' Ghi du lieu chung ra file xml
    Public Sub WriteXml()
        Dim frmShow As frmXMLReport = New frmXMLReport()

        RefeshHeaderReport()
        Dim ds As New DataSet
        Dim da As SqlDataAdapter
        ' Lay tieu de
        Dim sql As String
        Try
            Dim dt As New DataTable
            sql = "Select * From dbo.rptTHONG_TIN_CHUNG_TMP "
            da = New SqlDataAdapter(sql, Commons.IConnections.ConnectionString)
            dt.TableName = "rptTHONG_TIN_CHUNG_TMP"
            da.Fill(dt)
            'ds.Tables.Add(dt)

            frmShow.AddDataTableSource(dt)
            ' Lay tieu de tu frmDanhSachPhieuXuat
        Catch ex As Exception
        End Try
        'Dim dt As New DataTable
        Try
            CreateTitleObjectReport()
            Dim dt As New DataTable
            sql = "Select * From rptDanhSachPhieuNhap_TMP "
            dt.TableName = "rptDanhSachPhieuNhap_TMP"
            da = New SqlDataAdapter(sql, Commons.IConnections.ConnectionString)
            da.Fill(dt)
            'ds.Tables.Add(dt)
            frmShow.AddDataTableSource(dt)
        Catch ex As Exception

        End Try
        Try
            Dim dt As New DataTable
            dt.TableName = "Values"
            da = New SqlDataAdapter(sqlColection, Commons.IConnections.ConnectionString)
            da.Fill(dt)
            'ds.Tables.Add(dt)
            frmShow.AddDataTableSource(dt)
        Catch ex As Exception
        End Try

        Try
            Dim clTenKho As DataColumn = New DataColumn("TenKho", Type.GetType("System.String"))
            Dim clTuNgay As DataColumn = New DataColumn("TuNgay", Type.GetType("System.String"))
            Dim clDenNgay As DataColumn = New DataColumn("DenNgay", Type.GetType("System.String"))
            Dim cldsDangNhap As DataColumn = New DataColumn("DSDangNhap", Type.GetType("System.String"))
            Dim Tb As DataTable = New DataTable("TIEU_DE")
            Tb.Columns.Add(clTenKho)
            Tb.Columns.Add(clTuNgay)
            Tb.Columns.Add(clDenNgay)
            Tb.Columns.Add(cldsDangNhap)

            Dim rows As DataRow = Tb.NewRow()
            rows("TenKho") = cmbKho.Text
            rows("TuNgay") = daTimeTuNgay.Text
            rows("DenNgay") = daTimeDenNgay.Text
            Dim dsDangNhap As String = ""

            Try
                Dim dn(10) As Integer
                Dim i As Integer = 0
                Dim tbn As DataTable = New DataTable()
                tbn = CType(gvPhieuNhapKho.DataSource, DataTable).Copy()
                dn(i) = 0
                For Each gvrow As DataGridViewRow In Me.gvPhieuNhapKho.Rows
                    If gvrow.Cells("CHON").Value = True Then
                        Dim daco As Integer = 0
                        For j As Integer = 0 To i
                            If dn(j) = Integer.Parse(gvrow.Cells("MS_NHAP").Value.ToString) Then
                                daco = 1
                            End If
                        Next
                        If daco = 0 Then
                            i = i + 1
                            dsDangNhap = dsDangNhap & " - " & gvrow.Cells("DANG_NHAP_VIET").Value
                            dn(i) = Integer.Parse(gvrow.Cells("MS_NHAP").Value.ToString)

                        End If

                    End If
                Next
            Catch ex As Exception
            End Try
            rows("DSDangNhap") = dsDangNhap

            Tb.Rows.Add(rows)
            'ds.Tables.Add(Tb)
            frmShow.AddDataTableSource(Tb)
        Catch ex As Exception
        End Try

        Try

        Catch ex As Exception
        End Try


        frmShow.rptName = "rptDanhSachPhieuNhap"
        frmShow.ShowDialog()

        'frmReportPhieuNhap.danhSach = ds
        'dsTable = ds
        'ds.WriteXml("XML\PhieuNhapKho.xml", XmlWriteMode.WriteSchema)
    End Sub
    ' Load  du lieu len gridview
    Public Sub LoadGrid_PhieuNhap(ByVal tenKho As String, ByVal date1 As DateTime, ByVal date2 As DateTime)

        gvPhieuNhapKho.Columns.Clear()
        gvPhieuNhapKho.DataSource = Nothing

        Dim ngay1, ngay2 As String
        date2 = date2.AddDays(1)
        ngay1 = date1.Year.ToString + "/" + date1.Month.ToString + "/" + date1.Day.ToString
        ngay2 = date2.Year.ToString + "/" + date2.Month.ToString + "/" + date2.Day.ToString
        Commons.Modules.SQLString = "Select dbo.DANG_NHAP.MS_DANG_NHAP, dbo.DANG_NHAP.DANG_NHAP_VIET, dbo.DANG_NHAP.DANG_NHAP_ANH, dbo.DANG_NHAP.DANG_NHAP_HOA"
        Commons.Modules.SQLString += " From IC_KHO , IC_DON_HANG_NHAP , DANG_NHAP "
        Commons.Modules.SQLString += " Where dbo.IC_KHO.MS_KHO = dbo.IC_DON_HANG_NHAP.MS_KHO And  dbo.DANG_NHAP.MS_DANG_NHAP = dbo.IC_DON_HANG_NHAP.MS_DANG_NHAP"
        Commons.Modules.SQLString += " And dbo.IC_DON_HANG_NHAP.NGAY Between '" + ngay1 + "' and '" + ngay2 + "' "
        If (Not cmbKho.Properties.DataSource Is Nothing) Then
            Commons.Modules.SQLString += " and dbo.IC_KHO.MS_KHO =  " & cmbKho.EditValue & " "
        End If
        Commons.Modules.SQLString += " Group by dbo.DANG_NHAP.MS_DANG_NHAP, dbo.DANG_NHAP.DANG_NHAP_VIET, dbo.DANG_NHAP.DANG_NHAP_ANH, dbo.DANG_NHAP.DANG_NHAP_HOA "
        Try
            Dim dt As DataTable
            dt = GetList_PhieuNhap(Commons.Modules.SQLString)
            gvPhieuNhapKho.DataSource = Nothing
            gvPhieuNhapKho.Columns.Clear()
            gvPhieuNhapKho.DataSource = dt
            gvPhieuNhapKho.Columns("DANG_NHAP_ANH").Visible = False
            gvPhieuNhapKho.Columns("DANG_NHAP_HOA").Visible = False
            gvPhieuNhapKho.Columns("DANG_NHAP_VIET").Visible = False
            gvPhieuNhapKho.Columns("MS_NHAP").Visible = False
            gvPhieuNhapKho.AllowUserToAddRows = False
            Add_Check_GridView(gvPhieuNhapKho)
        Catch ex As Exception

        End Try
        RefeshLanguageGridView()
    End Sub
    Public Function GetList_PhieuNhap(ByVal SQLString As String) As DataTable
        ' Dim provider As New cls_DataProvider
        Dim myReader As SqlDataReader
        Dim dt As DataTable
        dt = CreateDataTable()
        'myReader = provider.executeQuery(commons.Modules.SQLString)
        myReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQLString)
        Try
            While (myReader.Read)
                Dim myRow As DataRow = dt.NewRow
                myRow("MS_NHAP") = myReader("MS_DANG_NHAP").ToString
                myRow("DANG_NHAP_VIET") = myReader("DANG_NHAP_VIET").ToString
                myRow("DANG_NHAP") = myReader("DANG_NHAP_VIET").ToString
                myRow("DANG_NHAP_ANH") = myReader("DANG_NHAP_ANH").ToString
                myRow("DANG_NHAP_HOA") = myReader("DANG_NHAP_HOA").ToString
                dt.Rows.Add(myRow)
            End While
        Catch ex As Exception

        End Try
        Return dt
    End Function


    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim arrSql As Collection
        ' Dim frmPhieuNhap As New frmReportPhieuNhap
        Dim maKho As String = Get_MaKho(cmbKho.Text).ToString
        arrSql = DuyetGridView(maKho, cmbKho.Text, tuNgay, denNgay)
        Dim ds As DataSet
        ds = XuatBaoCao(arrSql)
        If (ds.Tables.Count > 0) Then
            WriteXml()

            'Dim rptDocument As ReportDocument = New ReportDocument()
            'Dim s As String = Application.StartupPath & "\reports\rptDSTBTNLDHienTai_DHG.rpt"

            'rptDocument.Load(Application.StartupPath & "\reports\rptDSTBTNLDHienTai_DHG.rpt")
            'rptDocument.SetDataSource(ds)
            'Dim frmShow As frmShowXMLReport = New frmShowXMLReport()
            'frmShow.CrystalReportViewer_maint.ReportSource = rptDocument
            'frmShow.ShowDialog()
            'GetParameterReport(dsTable, cmbKho.Text, tuNgay, denNgay)
            'frmPhieuNhap.ShowDialog()
        End If
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Try
            SqlText = "DROP TABLE dbo.rptDanhSachPhieuNhap_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Me.ParentForm.Close()
    End Sub

    Private Sub daTimeTuNgay_EditValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles daTimeTuNgay.EditValueChanged
        If _isLoad Then
            If (daTimeTuNgay.DateTime > DateTime.Now()) Then
                MessageBox.Show("Từ ngày không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK)
                daTimeTuNgay.EditValue = DateTime.Now()
                daTimeTuNgay.Focus()
            Else
                GetTuNgay_DenNgay(daTimeTuNgay.DateTime, daTimeDenNgay.EditValue)
                LoadGrid_PhieuNhap(cmbKho.Text, tuNgay, denNgay)
            End If
        End If
    End Sub

    Private Sub daTimeDenNgay_EditValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles daTimeDenNgay.EditValueChanged
        If _isLoad Then
            GetTuNgay_DenNgay(daTimeTuNgay.EditValue, daTimeDenNgay.EditValue)
            LoadGrid_PhieuNhap(cmbKho.Text, tuNgay, denNgay)
        End If
    End Sub


    Public Function GetFirstDayOfMonth(ByVal iMonth As Integer) As Date
        Dim dtResult As New DateTime(DateTime.Now.Year, iMonth, 1)
        dtResult = dtResult.AddDays((-dtResult.Day) + 1)
        Return dtResult
    End Function

    Public Function GetLastDayOfMonth(ByVal iMonth As Integer) As Date
        Dim dtResult As New DateTime(DateTime.Now.Year, iMonth, 1)
        dtResult = dtResult.AddMonths(1)
        dtResult = dtResult.AddDays((-dtResult.Day))
        Return dtResult
    End Function

    Private Sub cmbKho1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKho.EditValueChanged
        If _isLoad Then
            LoadGrid_PhieuNhap(cmbKho.Text, tuNgay, denNgay)
        End If
    End Sub
End Class
