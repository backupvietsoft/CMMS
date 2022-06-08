
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDSCYCBTDaNghiemThuTheoNV
    Private SqlText As String = String.Empty

    Private Sub frmrptDSCYCBTDaNghiemThuTheoNV_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDenNgay.Value = DateTime.Now
        dtpTuNgay.Value = DateTime.Now.AddMonths(-1)
        LoadNhanvien()
    End Sub

    Private Sub LoadNhanvien()
        cboNVien.DataSource = tblCNFullName()
        cboNVien.ValueMember = "MS_CN"
        cboNVien.DisplayMember = "hoten"
    End Sub
    Private Function tblCNFullName() As DataTable
        Dim dtCN As New DataTable
        Dim str As String = "SELECT * FROM CONG_NHAN WHERE NGAY_NGHI_VIEC IS NULL ORDER BY HO, TEN "
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

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Commons.clsXuLy.CreateTitleReport()
        Call CreateData16()
        Call Printpreview16()
    End Sub
    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Private Sub RefeshLanguageReport16()
        Dim NGAY_IN, TIEU_DE, TU_NGAY, DEN_NGAY, NHAN_VIEN, DIA_DIEM, STT, PHIEU_BT, MS_TB, TEN_TB, LOAI_BT, NGAY_BD, NGAY_KT, TINH_TRANG_TRUOC_BT, TINH_TRANG_SAU_BT, TRANG As String
        NGAY_IN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "NGAY_IN", Commons.Modules.TypeLanguage)
        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TIEU_DE", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "DEN_NGAY", Commons.Modules.TypeLanguage)
        NHAN_VIEN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "NHAN_VIEN", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "DIA_DIEM", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "STT", Commons.Modules.TypeLanguage)
        PHIEU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "PHIEU_BT", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "MS_TB", Commons.Modules.TypeLanguage)
        TEN_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TEN_TB", Commons.Modules.TypeLanguage)
        LOAI_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "LOAI_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "NGAY_KT", Commons.Modules.TypeLanguage)
        TINH_TRANG_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TINH_TRANG_TRUOC_BT", Commons.Modules.TypeLanguage)
        TINH_TRANG_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TINH_TRANG_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTDaNghiemThuTheoNV_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSCYCBTDaNghiemThuTheoNV_lbl_TMP(NGAY_IN_ nvarchar(50), TIEU_DE_ nvarchar(250), TU_NGAY_ nvarchar(50), DEN_NGAY_ nvarchar(50), NHAN_VIEN_ nvarchar(50),DIA_DIEM_ nvarchar(50),STT_ nvarchar(50),PHIEU_BT_ nvarchar(50),MS_TB_ nvarchar(50),TEN_TB_ nvarchar(50), LOAI_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TINH_TRANG_TRUOC_BT_ nvarchar(50), TINH_TRANG_SAU_BT_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSCYCBTDaNghiemThuTheoNV", NGAY_IN, TIEU_DE, TU_NGAY, DEN_NGAY, NHAN_VIEN, DIA_DIEM, STT, PHIEU_BT, MS_TB, TEN_TB, LOAI_BT, NGAY_BD, NGAY_KT, TINH_TRANG_TRUOC_BT, TINH_TRANG_SAU_BT, TRANG)

    End Sub


    Sub CreateData16()
        RefeshLanguageReport16()
        Cursor = Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTDaNghiemThuTheoNV_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        'Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day
        'Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month
        'Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year
        Dim date_TN As String '= (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        'Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day
        'Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month
        'Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year
        Dim date_DN As String '= (thang_DN & "/" & ngay_DN & "/" & nam_DN)

        date_DN = dtpDenNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        date_TN = dtpTuNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        If cboNVien.SelectedIndex > 0 Then
            'SqlText = "SELECT  dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN AS TEN_NHAN_VIEN,dbo.NHA_XUONG.MS_N_XUONG, dbo.NHA_XUONG.Ten_N_XUONG, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, MAY.TEN_MAY AS TEN_NHOM_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, " & _
            '                " dbo.PHIEU_BAO_TRI.TT_SAU_BT, CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU, dbo.LOAI_MAY.TEN_LOAI_MAY       " & _
            '                " into [dbo].rptDSCYCBTDaNghiemThuTheoNV_TMP             FROM  dbo.V_MAY_NHA_XUONG_MAX INNER JOIN  dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN  dbo.MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN  dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN  dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI.NGUOI_LAP = dbo.CONG_NHAN.MS_CONG_NHAN INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY ON dbo.V_MAY_NHA_XUONG_MAX.MS_MAY = dbo.MAY.MS_MAY  WHERE (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS NOT NULL) " & _
            '                " AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "')   AND (dbo.CONG_NHAN.MS_CONG_NHAN = '" & cboNVien.SelectedValue & "') order by NGAY_BD_KH"


            SqlText = " SELECT     TOP (100) PERCENT T1.HO + ' ' + T1.TEN AS TEN_NHAN_VIEN, T10.MS_N_XUONG, T10.Ten_N_XUONG, T6.MS_PHIEU_BAO_TRI, T4.MS_MAY, T4.TEN_MAY AS TEN_NHOM_MAY, T7.TEN_LOAI_BT, " & _
                            "                       T6.NGAY_BD_KH, T6.NGAY_KT_KH, T6.LY_DO_BT AS TINH_TRANG_PBT, T6.TT_SAU_BT, CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY,  " & _
                            "                       T6.NGAY_NGHIEM_THU, T8.TEN_LOAI_MAY " & _
                            " into [dbo].rptDSCYCBTDaNghiemThuTheoNV_TMP FROM         dbo.CONG_NHAN AS T1 INNER JOIN " & _
                            "                       dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU AS T2 ON T1.MS_CONG_NHAN = T2.MS_CONG_NHAN INNER JOIN " & _
                            "                       dbo.PHIEU_BAO_TRI_CONG_VIEC AS T3 ON T2.MS_PHIEU_BAO_TRI = T3.MS_PHIEU_BAO_TRI AND T2.MS_CV = T3.MS_CV AND T2.MS_BO_PHAN = T3.MS_BO_PHAN INNER JOIN " & _
                            "                       dbo.MAY AS T4 INNER JOIN " & _
                            "                       dbo.NHOM_MAY AS T5 ON T4.MS_NHOM_MAY = T5.MS_NHOM_MAY INNER JOIN " & _
                            "                       dbo.PHIEU_BAO_TRI AS T6 ON T4.MS_MAY = T6.MS_MAY INNER JOIN " & _
                            "                       dbo.LOAI_BAO_TRI AS T7 ON T6.MS_LOAI_BT = T7.MS_LOAI_BT INNER JOIN " & _
                            "                       dbo.LOAI_MAY AS T8 ON T5.MS_LOAI_MAY = T8.MS_LOAI_MAY INNER JOIN " & _
                            "                       dbo.V_MAY_NHA_XUONG_MAX AS T9 INNER JOIN " & _
                            "                       dbo.NHA_XUONG AS T10 ON T9.MS_N_XUONG = T10.MS_N_XUONG ON T4.MS_MAY = T9.MS_MAY ON T3.MS_PHIEU_BAO_TRI = T6.MS_PHIEU_BAO_TRI " & _
                            " WHERE     (T6.NGAY_NGHIEM_THU IS NOT NULL) AND (T6.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "')  " & _
                            " AND (T1.MS_CONG_NHAN = '" & cboNVien.SelectedValue & "')" & _
                            " ORDER BY T6.NGAY_BD_KH "
        Else
            'SqlText = "SELECT  dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN AS TEN_NHAN_VIEN,dbo.NHA_XUONG.MS_N_XUONG, dbo.NHA_XUONG.Ten_N_XUONG, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, MAY.TEN_MAY AS TEN_NHOM_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT, CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU, dbo.LOAI_MAY.TEN_LOAI_MAY          into [dbo].rptDSCYCBTDaNghiemThuTheoNV_TMP             FROM  dbo.V_MAY_NHA_XUONG_MAX INNER JOIN  dbo.NHA_XUONG ON dbo.V_MAY_NHA_XUONG_MAX.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN  dbo.MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN  dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN  dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI.NGUOI_LAP = dbo.CONG_NHAN.MS_CONG_NHAN INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY ON dbo.V_MAY_NHA_XUONG_MAX.MS_MAY = dbo.MAY.MS_MAY  WHERE (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS NOT NULL) AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "') order by NGAY_BD_KH"
            SqlText = " SELECT     TOP (100) PERCENT T1.HO + ' ' + T1.TEN AS TEN_NHAN_VIEN, T10.MS_N_XUONG, T10.Ten_N_XUONG, T6.MS_PHIEU_BAO_TRI, T4.MS_MAY, T4.TEN_MAY AS TEN_NHOM_MAY, T7.TEN_LOAI_BT, " & _
                            "                       T6.NGAY_BD_KH, T6.NGAY_KT_KH, T6.LY_DO_BT AS TINH_TRANG_PBT, T6.TT_SAU_BT, CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY,  " & _
                            "                       T6.NGAY_NGHIEM_THU, T8.TEN_LOAI_MAY " & _
                            " into [dbo].rptDSCYCBTDaNghiemThuTheoNV_TMP FROM         dbo.CONG_NHAN AS T1 INNER JOIN " & _
                            "                       dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU AS T2 ON T1.MS_CONG_NHAN = T2.MS_CONG_NHAN INNER JOIN " & _
                            "                       dbo.PHIEU_BAO_TRI_CONG_VIEC AS T3 ON T2.MS_PHIEU_BAO_TRI = T3.MS_PHIEU_BAO_TRI AND T2.MS_CV = T3.MS_CV AND T2.MS_BO_PHAN = T3.MS_BO_PHAN INNER JOIN " & _
                            "                       dbo.MAY AS T4 INNER JOIN " & _
                            "                       dbo.NHOM_MAY AS T5 ON T4.MS_NHOM_MAY = T5.MS_NHOM_MAY INNER JOIN " & _
                            "                       dbo.PHIEU_BAO_TRI AS T6 ON T4.MS_MAY = T6.MS_MAY INNER JOIN " & _
                            "                       dbo.LOAI_BAO_TRI AS T7 ON T6.MS_LOAI_BT = T7.MS_LOAI_BT INNER JOIN " & _
                            "                       dbo.LOAI_MAY AS T8 ON T5.MS_LOAI_MAY = T8.MS_LOAI_MAY INNER JOIN " & _
                            "                       dbo.V_MAY_NHA_XUONG_MAX AS T9 INNER JOIN " & _
                            "                       dbo.NHA_XUONG AS T10 ON T9.MS_N_XUONG = T10.MS_N_XUONG ON T4.MS_MAY = T9.MS_MAY ON T3.MS_PHIEU_BAO_TRI = T6.MS_PHIEU_BAO_TRI " & _
                            " WHERE     (T6.NGAY_NGHIEM_THU IS NOT NULL) AND (T6.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "')  " & _
                            " ORDER BY T6.NGAY_BD_KH "

        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


    End Sub
    Sub Printpreview16()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSCYCBTDaNghiemThuTheoNV_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCYCBTDaNghiemThuTheoNV", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        Dim frmRP As frmXMLReport = New frmXMLReport()
        frmRP.rptName = "rptDSCYCBTDaNghiemThuTheoNV"
        Dim sSql As String
        Dim dtTMP = New DataTable
        sSql = "SELECT * FROM rptDSCYCBTDaNghiemThuTheoNV_TMP"
        dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        dtTMP.TableName = "rptDSCYCBTDaNghiemThuTheoNV_TMP"
        frmRP.AddDataTableSource(dtTMP)

        dtTMP = New DataTable
        sSql = "SELECT * FROM rptDSCYCBTDaNghiemThuTheoNV_lbl_TMP"
        dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        dtTMP.TableName = "rptDSCYCBTDaNghiemThuTheoNV_lbl_TMP"
        frmRP.AddDataTableSource(dtTMP)

        frmRP.ShowDialog()


        'Call ReportPreview("reports\rptDSCYCBTDaNghiemThuTheoNV.rpt")
        Cursor = Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTDaNghiemThuTheoNV_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSCYCBTDaNghiemThuTheoNV_lbl_TMP"
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

    Private Sub cboNVien_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNVien.SelectedIndexChanged

    End Sub

    Private Sub dtpTuNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTuNgay.ValueChanged

    End Sub

    Private Sub dtpDenNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDenNgay.ValueChanged

    End Sub

    Private Sub lblDenngay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDenngay.Click

    End Sub

    Private Sub lblTungay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTungay.Click

    End Sub

    Private Sub lblNhanvien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNhanvien.Click

    End Sub

End Class
