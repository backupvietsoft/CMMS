
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDDH
    Private SqlText As String = String.Empty
    Private Sub frmrptDDH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        If radChuaTH.Checked = True Then
            CreateData22()
            Printpreview22()
        Else
            CreateData21()
            Printpreview21()
        End If
        Me.Cursor = Cursors.Default
    End Sub
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
    Private Sub RefeshLanguageReport22()
        Dim TIEU_DE, SO_DDH, SO_PR, LAP_NGAY, STT, MA_HANG, TEN_HANG, DVT, SO_LUONG, DON_GIA, TONG_CONG, TG_GIAO_HANG, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "TIEU_DE", Commons.Modules.TypeLanguage)
        SO_DDH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "SO_DDH", Commons.Modules.TypeLanguage)
        SO_PR = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "SO_PR", Commons.Modules.TypeLanguage)
        LAP_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "LAP_NGAY", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "STT", Commons.Modules.TypeLanguage)
        MA_HANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "MA_HANG", Commons.Modules.TypeLanguage)
        TEN_HANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "TEN_HANG", Commons.Modules.TypeLanguage)
        DVT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "DVT", Commons.Modules.TypeLanguage)
        SO_LUONG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "SO_LUONG", Commons.Modules.TypeLanguage)
        DON_GIA = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "DON_GIA", Commons.Modules.TypeLanguage)
        TONG_CONG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "TONG_CONG", Commons.Modules.TypeLanguage)
        TG_GIAO_HANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "TG_GIAO_HANG", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_CHUA_HT", "TRANG", Commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDON_DAT_HANG_DA_HT_lbl"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDON_DAT_HANG_DA_HT_lbl(commons.Modules.TypeLanguage_ nvarchar(50), TIEU_DE_ nvarchar(50),SO_DDH_ nvarchar(50),SO_PR_ nvarchar(50),LAP_NGAY_ nvarchar(50),STT_ nvarchar(50),MA_HANG_ nvarchar(50),TEN_HANG_ nvarchar(50),DVT_ nvarchar(50),SO_LUONG_ nvarchar(50), DON_GIA_ nvarchar(50), TONG_CONG_ nvarchar(50), TG_GIAO_HANG_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "procInsertRptDDH_DA_HT", Commons.Modules.TypeLanguage, TIEU_DE, SO_DDH, SO_PR, LAP_NGAY, STT, MA_HANG, TEN_HANG, DVT, SO_LUONG, DON_GIA, TONG_CONG, TG_GIAO_HANG, TRANG)

    End Sub

    Sub CreateData22()

        RefeshHeaderReport()
        RefeshLanguageReport22()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "procRptDON_DAT_HANG_CHUA_HT", Commons.Modules.TypeLanguage)

    End Sub

    Sub Printpreview22()

        Dim dt As New DataTable
        Commons.Modules.SQLString = "SELECT * FROM dbo.rptDON_DAT_HANG_DA_HT"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        If dt.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Cursor = Cursors.Default
            GoTo KetThuc
        End If
        Call ReportPreview("reports\rptDonDatHangDaHT.rpt")
        Cursor = Cursors.Default
KetThuc:
        'commons.Modules.ObjSystems.XoaTable("dbo.rptDON_DAT_HANG_DA_HT")
        'commons.Modules.ObjSystems.XoaTable("dbo.rptDON_DAT_HANG_DA_HT_lbl")

    End Sub


    Private Sub RefeshLanguageReport21()
        Dim TIEU_DE, SO_DDH, SO_PR, LAP_NGAY, STT, MA_HANG, TEN_HANG, DVT, SO_LUONG, DON_GIA, TONG_CONG, TG_GIAO_HANG, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "TIEU_DE", Commons.Modules.TypeLanguage)
        SO_DDH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "SO_DDH", Commons.Modules.TypeLanguage)
        SO_PR = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "SO_PR", Commons.Modules.TypeLanguage)
        LAP_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "LAP_NGAY", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "STT", Commons.Modules.TypeLanguage)
        MA_HANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "MA_HANG", Commons.Modules.TypeLanguage)
        TEN_HANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "TEN_HANG", Commons.Modules.TypeLanguage)
        DVT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "DVT", Commons.Modules.TypeLanguage)
        SO_LUONG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "SO_LUONG", Commons.Modules.TypeLanguage)
        DON_GIA = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "DON_GIA", Commons.Modules.TypeLanguage)
        TONG_CONG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "TONG_CONG", Commons.Modules.TypeLanguage)
        TG_GIAO_HANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "TG_GIAO_HANG", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH_DA_HT", "TRANG", Commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDON_DAT_HANG_DA_HT_lbl"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE [dbo].rptDON_DAT_HANG_DA_HT_lbl(commons.Modules.TypeLanguage_ nvarchar(50),TIEU_DE_ nvarchar(50),SO_DDH_ nvarchar(50),SO_PR_ nvarchar(50),LAP_NGAY_ nvarchar(50),STT_ nvarchar(50),MA_HANG_ nvarchar(50),TEN_HANG_ nvarchar(50),DVT_ nvarchar(50),SO_LUONG_ nvarchar(50), DON_GIA_ nvarchar(50), TONG_CONG_ nvarchar(50), TG_GIAO_HANG_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "procInsertRptDDH_DA_HT", Commons.Modules.TypeLanguage, TIEU_DE, SO_DDH, SO_PR, LAP_NGAY, STT, MA_HANG, TEN_HANG, DVT, SO_LUONG, DON_GIA, TONG_CONG, TG_GIAO_HANG, TRANG)

    End Sub

    Sub CreateData21()

        RefeshHeaderReport()
        RefeshLanguageReport21()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "procRptDON_DAT_HANG_DA_HT", Commons.Modules.TypeLanguage)

    End Sub

    Sub Printpreview21()

        Dim dt As New DataTable
        Commons.Modules.SQLString = "SELECT * FROM dbo.rptDON_DAT_HANG_DA_HT"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        If dt.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDDH", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Cursor = Cursors.Default
            GoTo KetThuc
        End If
        Call ReportPreview("reports\rptDonDatHangDaHT.rpt")
        Cursor = Cursors.Default
KetThuc:
        'commons.Modules.ObjSystems.XoaTable("dbo.rptDON_DAT_HANG_DA_HT")
        'commons.Modules.ObjSystems.XoaTable("dbo.rptDON_DAT_HANG_DA_HT_lbl")

    End Sub


    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
