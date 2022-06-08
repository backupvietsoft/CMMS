Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDSPBTChuaNghiemThuTLBT
    Private SqlText As String = String.Empty
    Private Sub frmrptDSPBTChuaNghiemThuTLBT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDenNgay.Value = DateTime.Now
        dtpTuNgay.Value = DateTime.Now.AddMonths(-1)
        LoadLoaibaotri()
    End Sub
    Private Sub LoadLoaibaotri()
        Dim dt As New DataTable
        Dim str As String = "SELECT * FROM LOAI_BAO_TRI ORDER BY TEN_LOAI_BT"
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        cboLoaiBT.DataSource = dt
        cboLoaiBT.ValueMember = "TEN_LOAI_BT"
        cboLoaiBT.DisplayMember = "TEN_LOAI_BT"
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Commons.clsXuLy.CreateTitleReport()
        Call CreateData18()
        Call Printpreview18()
    End Sub

    Private Sub RefeshLanguageReport18()
        Dim TIEU_DE, TU_NGAY, DEN_NGAY, LOAI_BAO_TRI, DIA_DIEM, STT, YEU_CAU, MS_TB, TEN_TB, HINH_THUC_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TIEU_DE", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "DEN_NGAY", Commons.Modules.TypeLanguage)
        LOAI_BAO_TRI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "LOAI_BAO_TRI", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "DIA_DIEM", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "STT", Commons.Modules.TypeLanguage)
        YEU_CAU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "YEU_CAU", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "MS_TB", Commons.Modules.TypeLanguage)
        TEN_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TEN_TB", Commons.Modules.TypeLanguage)
        HINH_THUC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "HINH_THUC_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", " NGAY_KT", Commons.Modules.TypeLanguage)
        TT_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TT_TRUOC_BT", Commons.Modules.TypeLanguage)
        TT_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TT_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTDaNghiemThuTLBT", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSPBTDaNghiemThuTLBT_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSPBTDaNghiemThuTLBT_lbl_TMP(TIEU_DE_ nvarchar(50),TU_NGAY_ nvarchar(50),DEN_NGAY_ nvarchar(50),LOAI_BAO_TRI_ nvarchar(50),DIA_DIEM_ nvarchar(50),STT_ nvarchar(50),YEU_CAU_ nvarchar(50),MS_TB_ nvarchar(50),TEN_TB_ nvarchar(50),HINH_THUC_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TT_TRUOC_BT_ nvarchar(50), TT_SAU_BT_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSPBTDaNghiemThuTLBT", TIEU_DE, TU_NGAY, DEN_NGAY, LOAI_BAO_TRI, DIA_DIEM, STT, YEU_CAU, MS_TB, TEN_TB, HINH_THUC_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG)

    End Sub

    Private Sub RefeshHeaderReport()
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
    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Sub CreateData18()

        RefeshHeaderReport()
        RefeshLanguageReport18()
        Cursor = Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDSPBTChuaNghiemThuTLBT_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day
        Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month
        Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year
        Dim date_TN As String = (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day
        Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month
        Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year
        Dim date_DN As String = (thang_DN & "/" & ngay_DN & "/" & nam_DN)
        SqlText = "SELECT  dbo.NHA_XUONG.MS_N_XUONG,dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.NHA_XUONG.Ten_N_XUONG, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.HINH_THUC_BAO_TRI.TEN_HT_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT, dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU, '" & Format(dtpTuNgay.Value.Date, "dd/MM/yyyy") & "' AS TU_NGAY, '" & Format(dtpDenNgay.Value.Date, "dd/MM/yyyy") & "' AS DEN_NGAY  , MAY.TEN_MAY  INTO [dbo].rptDSPBTChuaNghiemThuTLBT_TMP       FROM dbo.NHA_XUONG INNER JOIN dbo.V_MAY_NHA_XUONG_MAX ON dbo.NHA_XUONG.MS_N_XUONG = dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG INNER JOIN dbo.LOAI_BAO_TRI INNER JOIN dbo.HINH_THUC_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_HT_BT = dbo.HINH_THUC_BAO_TRI.MS_HT_BT INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.NHOM_MAY INNER JOIN dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY ON dbo.V_MAY_NHA_XUONG_MAX.MS_MAY = dbo.MAY.MS_MAY WHERE (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS NULL) AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1, '" & date_DN & "')) AND (dbo.LOAI_BAO_TRI.TEN_LOAI_BT = N'" & cboLoaiBT.SelectedValue.ToString() & "') order by NGAY_BD_KH desc"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub
    Sub Printpreview18()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSPBTChuaNghiemThuTLBT_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSPBTChuaNghiemThuTLBT", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Call ReportPreview("reports\rptDSPBTChuaNghiemThuTLBT.rpt")
        Cursor = Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSPBTChuaNghiemThuTLBT_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSPBTChuaNghiemThuTLBT_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptDSPBTDaNghiemThuTLBT_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
