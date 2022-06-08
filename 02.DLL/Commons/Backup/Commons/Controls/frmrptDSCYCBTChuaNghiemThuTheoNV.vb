
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDSCYCBTChuaNghiemThuTheoNV
    Private SqlText As String = String.Empty
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Commons.clsXuLy.CreateTitleReport()
        Call CreateData17()
        Call Printpreview17()
    End Sub

    Private Sub LoadNhanvien()
        cboNVien.DataSource = tblCNFullName()
        cboNVien.ValueMember = "MS_CN"
        cboNVien.DisplayMember = "hoten"
    End Sub
    Private Function tblCNFullName() As DataTable
        Dim dtCN As New DataTable
        Dim str As String = "SELECT * FROM CONG_NHAN WHERE NGAY_NGHI_VIEC IS NULL ORDER BY HO,TEN"
        dtCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        'cboLoaiBT.DataSource = dt
        'cboLoaiBT.ValueMember = "TEN_LOAI_BT"
        'cboLoaiBT.DisplayMember = "TEN_LOAI_BT"
        Dim dtCNFullName As New DataTable
        dtCNFullName.Columns.Add("MS_CN")
        dtCNFullName.Columns.Add("HoTen")
        Dim rowFName, row As DataRow
        For Each row In dtCN.Rows
            rowFName = dtCNFullName.NewRow()
            rowFName("ms_cn") = row("MS_CONG_NHAN")
            rowFName("hoten") = row("ho").ToString() & " " & row("ten").ToString()
            dtCNFullName.Rows.Add(rowFName)
        Next
        Dim rowall As DataRow
        rowall = dtCNFullName.NewRow()
        rowall(0) = -1
        rowall(1) = " < ALL > "
        dtCNFullName.Rows.InsertAt(rowall, 0)
        Return dtCNFullName
    End Function

    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Private Sub frmrptDSCYCBTChuaNghiemThuTheoNV_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDenNgay.Value = DateTime.Now
        dtpTuNgay.Value = DateTime.Now.AddMonths(-1)
        LoadNhanvien()
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
    Private Sub RefeshLanguageReport17()
        Dim NGAY_IN, TIEU_DE, TU_NGAY, DEN_NGAY, NHAN_VIEN, DIA_DIEM, STT, PHIEU_BT, MS_TB, TEN_TB, LOAI_BT, NGAY_BD, NGAY_KT, TINH_TRANG_TRUOC_BT, TINH_TRANG_SAU_BT, TRANG As String
        NGAY_IN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "NGAY_IN", Commons.Modules.TypeLanguage)
        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TIEU_DE", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "DEN_NGAY", Commons.Modules.TypeLanguage)
        NHAN_VIEN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "NHAN_VIEN", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "DIA_DIEM", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "STT", Commons.Modules.TypeLanguage)
        PHIEU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "PHIEU_BT", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "MS_TB", Commons.Modules.TypeLanguage)
        TEN_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TEN_TB", Commons.Modules.TypeLanguage)
        LOAI_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "LOAI_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "NGAY_KT", Commons.Modules.TypeLanguage)
        TINH_TRANG_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TINH_TRANG_TRUOC_BT", Commons.Modules.TypeLanguage)
        TINH_TRANG_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TINH_TRANG_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTChuaNghiemThuTheoNV_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSCYCBTChuaNghiemThuTheoNV_lbl_TMP(NGAY_IN_ nvarchar(50), TIEU_DE_ nvarchar(50), TU_NGAY_ nvarchar(50), DEN_NGAY_ nvarchar(50), NHAN_VIEN_ nvarchar(50),DIA_DIEM_ nvarchar(50),STT_ nvarchar(50),PHIEU_BT_ nvarchar(50),MS_TB_ nvarchar(50),TEN_TB_ nvarchar(50), LOAI_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TINH_TRANG_TRUOC_BT_ nvarchar(50), TINH_TRANG_SAU_BT_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSCYCBTChuaNghiemThuTheoNV", NGAY_IN, TIEU_DE, TU_NGAY, DEN_NGAY, NHAN_VIEN, DIA_DIEM, STT, PHIEU_BT, MS_TB, TEN_TB, LOAI_BT, NGAY_BD, NGAY_KT, TINH_TRANG_TRUOC_BT, TINH_TRANG_SAU_BT, TRANG)

    End Sub

    Sub CreateData17()

        RefeshHeaderReport()
        RefeshLanguageReport17()
        Cursor = Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTChuaNghiemThuTheoNV_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Dim date_TN As String ' = (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        Dim date_DN As String '= (thang_DN & "/" & ngay_DN & "/" & nam_DN)

        date_DN = dtpDenNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        date_TN = dtpTuNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        If cboNVien.SelectedIndex > 0 Then
            SqlText = " SELECT     TOP (100) PERCENT T9.HO + ' ' + T9.TEN AS TEN_NHAN_VIEN, T8.MS_N_XUONG, T8.Ten_N_XUONG, T4.MS_PHIEU_BAO_TRI, T2.MS_MAY, T2.TEN_MAY AS TEN_NHOM_MAY, T5.TEN_LOAI_BT, " & _
                            "                       T4.NGAY_BD_KH, T4.NGAY_KT_KH, T4.LY_DO_BT AS TINH_TRANG_PBT, T4.TT_SAU_BT, CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY,  " & _
                            "             T4.NGAY_NGHIEM_THU, T6.TEN_LOAI_MAY into [dbo].rptDSCYCBTChuaNghiemThuTheoNV_TMP " & _
                            " FROM         dbo.PHIEU_BAO_TRI_CONG_VIEC AS T1 INNER JOIN " & _
                            "                       dbo.MAY AS T2 INNER JOIN " & _
                            "                       dbo.NHOM_MAY AS T3 ON T2.MS_NHOM_MAY = T3.MS_NHOM_MAY INNER JOIN " & _
                            "                       dbo.PHIEU_BAO_TRI AS T4 ON T2.MS_MAY = T4.MS_MAY INNER JOIN " & _
                            "                       dbo.LOAI_BAO_TRI AS T5 ON T4.MS_LOAI_BT = T5.MS_LOAI_BT INNER JOIN " & _
                            "                       dbo.LOAI_MAY AS T6 ON T3.MS_LOAI_MAY = T6.MS_LOAI_MAY INNER JOIN " & _
                            "                       dbo.V_MAY_NHA_XUONG_MAX AS T7 INNER JOIN " & _
                            "                       dbo.NHA_XUONG AS T8 ON T7.MS_N_XUONG = T8.MS_N_XUONG ON T2.MS_MAY = T7.MS_MAY ON T1.MS_PHIEU_BAO_TRI = T4.MS_PHIEU_BAO_TRI INNER JOIN " & _
                            "                       dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU AS T10 ON T1.MS_PHIEU_BAO_TRI = T10.MS_PHIEU_BAO_TRI AND T1.MS_CV = T10.MS_CV AND T1.MS_BO_PHAN = T10.MS_BO_PHAN INNER JOIN " & _
                            "                       dbo.CONG_NHAN AS T9 ON T10.MS_CONG_NHAN = T9.MS_CONG_NHAN " & _
                            " WHERE     (T4.NGAY_LAP BETWEEN '" & date_TN & "' AND DATEADD(day, 1, '" & date_DN & "')) AND (T4.TINH_TRANG_PBT < 3) " & _
                            " AND (T9.MS_CONG_NHAN = '" & cboNVien.SelectedValue & "') " & _
                            " ORDER BY T4.NGAY_BD_KH DESC"
        Else
            SqlText = " SELECT     TOP (100) PERCENT T9.HO + ' ' + T9.TEN AS TEN_NHAN_VIEN, T8.MS_N_XUONG, T8.Ten_N_XUONG, T4.MS_PHIEU_BAO_TRI, T2.MS_MAY, T2.TEN_MAY AS TEN_NHOM_MAY, T5.TEN_LOAI_BT, " & _
                            "                       T4.NGAY_BD_KH, T4.NGAY_KT_KH, T4.LY_DO_BT AS TINH_TRANG_PBT, T4.TT_SAU_BT, CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY,  " & _
                            "             T4.NGAY_NGHIEM_THU, T6.TEN_LOAI_MAY into [dbo].rptDSCYCBTChuaNghiemThuTheoNV_TMP " & _
                            " FROM         dbo.PHIEU_BAO_TRI_CONG_VIEC AS T1 INNER JOIN " & _
                            "                       dbo.MAY AS T2 INNER JOIN " & _
                            "                       dbo.NHOM_MAY AS T3 ON T2.MS_NHOM_MAY = T3.MS_NHOM_MAY INNER JOIN " & _
                            "                       dbo.PHIEU_BAO_TRI AS T4 ON T2.MS_MAY = T4.MS_MAY INNER JOIN " & _
                            "                       dbo.LOAI_BAO_TRI AS T5 ON T4.MS_LOAI_BT = T5.MS_LOAI_BT INNER JOIN " & _
                            "                       dbo.LOAI_MAY AS T6 ON T3.MS_LOAI_MAY = T6.MS_LOAI_MAY INNER JOIN " & _
                            "                       dbo.V_MAY_NHA_XUONG_MAX AS T7 INNER JOIN " & _
                            "                       dbo.NHA_XUONG AS T8 ON T7.MS_N_XUONG = T8.MS_N_XUONG ON T2.MS_MAY = T7.MS_MAY ON T1.MS_PHIEU_BAO_TRI = T4.MS_PHIEU_BAO_TRI INNER JOIN " & _
                            "                       dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU AS T10 ON T1.MS_PHIEU_BAO_TRI = T10.MS_PHIEU_BAO_TRI AND T1.MS_CV = T10.MS_CV AND T1.MS_BO_PHAN = T10.MS_BO_PHAN INNER JOIN " & _
                            "                       dbo.CONG_NHAN AS T9 ON T10.MS_CONG_NHAN = T9.MS_CONG_NHAN " & _
                            " WHERE     (T4.NGAY_LAP BETWEEN '" & date_TN & "' AND DATEADD(day, 1, '" & date_DN & "')) AND (T4.TINH_TRANG_PBT < 3) " & _
                            " ORDER BY T4.NGAY_BD_KH DESC"

        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


    End Sub
    Sub Printpreview17()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSCYCBTChuaNghiemThuTheoNV_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTChuaNghiemThuTheoNV", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        ReportPreview("reports\rptDSCYCBTChuaNghiemThuTheoNV.rpt")
        Cursor = Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTChuaNghiemThuTheoNV_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTChuaNghiemThuTheoNV_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
