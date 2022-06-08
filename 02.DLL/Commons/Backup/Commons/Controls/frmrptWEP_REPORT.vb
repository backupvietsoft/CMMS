Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptWEP_REPORT
    Private SqlText As String = String.Empty
    Dim TU_NGAY As String = String.Empty
    Dim DEN_NGAY As String = String.Empty
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If cboThietbi3.Text = "" Then
            Exit Sub
        End If
        setTextNGAY(cboNam.SelectedValue, cboTuan.SelectedValue)
        RefeshLanguageReport9()
        Cursor = Cursors.WaitCursor
        Dim str As String = ""
        Try
            str = "drop table rptWEEKLY_EQUIP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "SELECT DISTINCT PP.MS_MAY, " & _
        " ISNULL((SELECT DISTINCT MAX(CHI_SO_DONG_HO)-MIN(CHI_SO_DONG_HO) FROM THOI_GIAN_CHAY_MAY " & _
        " WHERE NGAY BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DateAdd(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103))AND MS_MAY=PP.MS_MAY),0)AS OP, " & _
        " ISNULL((select CONVERT(FLOAT,SUM(DATEDIFF (minute,TU_GIO,DEN_GIO)))/60  from thoi_gian_ngung_may " & _
        " WHERE NGAY BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DateAdd(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103))AND MS_MAY=PP.MS_MAY),0)AS DT, " & _
        " (SELECT    ISNULL(CONVERT(FLOAT,SUM(DATEDIFF (minute,TU_GIO,DEN_GIO)))/60,0)  " & _
        " FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET P3 INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU P2 ON   " & _
        " P3.MS_PHIEU_BAO_TRI = P2.MS_PHIEU_BAO_TRI AND P3.MS_CV = P2.MS_CV AND  P3.MS_BO_PHAN = P2.MS_BO_PHAN AND  " & _
        " P3.MS_CONG_NHAN = P2.MS_CONG_NHAN INNER JOIN PHIEU_BAO_TRI_CONG_VIEC P1 ON P2.MS_PHIEU_BAO_TRI = P1.MS_PHIEU_BAO_TRI  " & _
        " AND  P2.MS_CV = P1.MS_CV AND P2.MS_BO_PHAN = P1.MS_BO_PHAN INNER JOIN  PHIEU_BAO_TRI P ON  " & _
        " P1.MS_PHIEU_BAO_TRI = P.MS_PHIEU_BAO_TRI WHERE     (TINH_TRANG_PBT=3 OR TINH_TRANG_PBT = 4) " & _
        " AND NGAY_LAP BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DateAdd(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103))AND P.MS_MAY=PP.MS_MAY) AS PMR " & _
        " INTO [DBO].rptWEEKLY_EQUIP " & _
        " FROM (SELECT  MS_MAY FROM THOI_GIAN_CHAY_MAY WHERE NGAY BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DateAdd(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103)) UNION " & _
        " SELECT MS_MAY FROM THOI_GIAN_NGUNG_MAY WHERE NGAY BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DateAdd(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103)) UNION " & _
        " SELECT MS_MAY FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET PP3 INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU PP2 ON  " & _
        " PP3.MS_PHIEU_BAO_TRI = PP2.MS_PHIEU_BAO_TRI AND PP3.MS_CV = PP2.MS_CV AND  " & _
        " PP3.MS_BO_PHAN = PP2.MS_BO_PHAN AND PP3.MS_CONG_NHAN = PP2.MS_CONG_NHAN INNER JOIN " & _
        " PHIEU_BAO_TRI_CONG_VIEC PP1 ON PP2.MS_PHIEU_BAO_TRI = PP1.MS_PHIEU_BAO_TRI AND  " & _
        " PP2.MS_CV = PP1.MS_CV AND PP2.MS_BO_PHAN = PP1.MS_BO_PHAN INNER JOIN " & _
        " PHIEU_BAO_TRI ON PP1.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " & _
        " WHERE(TINH_TRANG_PBT = 3 Or TINH_TRANG_PBT = 4) " & _
        " AND NGAY_LAP BETWEEN CONVERT(DATETIME,'" & TU_NGAY & "',103) AND DATEADD(day,1, CONVERT(DATETIME,'" & DEN_NGAY & "',103))) AS PP " & _
        " INNER JOIN MAY ON PP.MS_MAY=MAY.MS_MAY INNER JOIN NHOM_MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY " & _
        " INNER JOIN MAY_NHA_XUONG ON MAY_NHA_XUONG.MS_MAY=MAY.MS_MAY AND MAY_NHA_XUONG.NGAY_NHAP=(SELECT MAX(NGAY_NHAP) FROM MAY_NHA_XUONG A WHERE A.MS_MAY=PP.MS_MAY) " & _
        " INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
        " INNER JOIN NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
        " INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM_NHA_XUONG.GROUP_ID=NHOM.GROUP_ID " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID  WHERE USERNAME='" & Commons.Modules.UserName & "' AND NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        If cboLoaithietbi3.SelectedValue <> "-1" Then
            str = str + " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "'"
        End If
        If cboNhomthietbi3.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomthietbi3.SelectedValue & "'"
        End If
        If cboThietbi3.SelectedValue <> "-1" Then
            str = str + " and PP.MS_MAY=N'" & cboThietbi3.SelectedValue & "'"
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Printpreview9()
    End Sub

    Private Sub setTextNGAY(ByVal year As String, ByVal tuan As String)
        For Each row As DataRow In dtTUAN(year).Rows
            If row("TUAN").ToString() = tuan Then
                txtTuan_TN.Text = (Convert.ToDateTime(row("TU_NGAY").ToString()).Month.ToString() + "/" + Convert.ToDateTime(row("TU_NGAY").ToString()).Day.ToString() + "/" + Convert.ToDateTime(row("TU_NGAY").ToString()).Year.ToString())
                txtTuan_DN.Text = (Convert.ToDateTime(row("DEN_NGAY").ToString()).Month.ToString() + "/" + Convert.ToDateTime(row("DEN_NGAY").ToString()).Day.ToString() + "/" + Convert.ToDateTime(row("DEN_NGAY").ToString()).Year.ToString())
                TU_NGAY = row("TU_NGAY").ToString()
                DEN_NGAY = row("DEN_NGAY").ToString()
            End If
        Next

    End Sub

    Private Function dtTUAN(ByVal year As String) As DataTable
        Dim date_TN As Date = "01/01/" + year
        Dim date_DN As Date = "07/01/" + year
        Dim week As Integer = 1
        Dim dt, dtRowFull As New DataTable
        Dim drFirst, drNext, drFull As DataRow
        dt.Columns.Add("TU_NGAY")
        dt.Columns.Add("DEN_NGAY")
        dt.Columns.Add("TUAN")
        drFirst = dt.NewRow()
        drFirst("TU_NGAY") = date_TN.ToShortDateString()
        drFirst("DEN_NGAY") = date_DN.ToShortDateString()
        drFirst("TUAN") = week
        dt.Rows.Add(drFirst)
        While (1)
            Dim count As Integer = 6
            count = count + 1
            date_TN = DateSerial(Convert.ToDateTime(date_TN).Year, Convert.ToDateTime(date_TN).Month, Convert.ToDateTime(date_TN).Day + count).Date
            Dim count1 As Integer = 6
            count1 = count1 + 1
            date_DN = DateSerial(Convert.ToDateTime(date_DN).Year, Convert.ToDateTime(date_DN).Month, Convert.ToDateTime(date_DN).Day + count1).Date
            If date_DN > CDate("31/12/" + year) Then
                Exit While
            End If
            drNext = dt.NewRow()
            drNext("TU_NGAY") = date_TN.ToShortDateString()
            drNext("DEN_NGAY") = date_DN.ToShortDateString()
            week = week + 1
            drNext("TUAN") = week
            dt.Rows.Add(drNext)
        End While

        dtRowFull.Columns.Add("TU_NGAY")
        dtRowFull.Columns.Add("DEN_NGAY")
        dtRowFull.Columns.Add("TUAN")
        dtRowFull.Columns.Add("TN_DN_TUAN")
        For Each row As DataRow In dt.Rows
            drFull = dtRowFull.NewRow()
            drFull("TU_NGAY") = row("TU_NGAY").ToString()
            drFull("DEN_NGAY") = row("DEN_NGAY").ToString()
            drFull("TUAN") = row("TUAN").ToString()
            drFull("TN_DN_TUAN") = "Tuần " & row("TUAN").ToString() & " (" & row("TU_NGAY").ToString() & " đến " & row("DEN_NGAY").ToString() & ")"
            dtRowFull.Rows.Add(drFull)
        Next
        Return dtRowFull
    End Function


    Private Sub RefeshLanguageReport9()
        Dim str As String = ""
        Try
            str = " drop table rptTieuDeWeeklyEuip"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "TieuDe", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "NgayIn", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "ThietBi", Commons.Modules.TypeLanguage)
        Dim ThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim ThoiGianChayMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "ThoiGianChayMay", Commons.Modules.TypeLanguage)
        Dim ThoiGianNgungMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "ThoiGianNgungMay", Commons.Modules.TypeLanguage)
        Dim ThoiGianBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "ThoiGianBaoTri", Commons.Modules.TypeLanguage)
        Dim AV As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "AV", Commons.Modules.TypeLanguage)
        Dim Gio As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "Gio", Commons.Modules.TypeLanguage)
        Dim Remark As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "Remark", Commons.Modules.TypeLanguage)
        Dim Reviewed As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "Reviewed", Commons.Modules.TypeLanguage)
        Dim CraneSection As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "CraneSection", Commons.Modules.TypeLanguage)
        Dim RTGSection As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "RTGSection", Commons.Modules.TypeLanguage)
        Dim VEHLeader As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptWEP_REPORT", "VEHLeader", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        If Commons.Modules.TypeLanguage = 0 Then
            DieuKienLoc = "Từ ngày " & Format(CDate(TU_NGAY), "dd/MM/yyyy") & " đến ngày " & Format(CDate(DEN_NGAY), "dd/MM/yyyy")
        Else
            DieuKienLoc = "From date " & Format(CDate(TU_NGAY), "dd/MM/yyyy") & " to date " & Format(CDate(DEN_NGAY), "dd/MM/yyyy")
        End If
        str = "Create table dbo.rptTieuDeWeeklyEuip(TypeLanguage int,NgayIn nvarchar(50),TrangIn nvarchar(50),TieuDe nvarchar(255)," & _
        " DieuKienLoc nvarchar(255),STT nvarchar(5), ThietBi nvarchar(50),ThoiGianChayMay nvarchar(100),ThoiGianNgungMay nvarchar(100)," & _
        " ThoiGianBaoTri nvarchar(100),AV nvarchar(100),Gio nvarchar(10),ThoiGian nvarchar(150),Remark nvarchar(30), " & _
        " Reviewed nvarchar(100),CraneSection nvarchar(100),RTGSection nvarchar(100),VEHLeader nvarchar(100))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Insert into [dbo].rptTieuDeWeeklyEuip values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        DieuKienLoc & "',N'" & STT & "',N'" & ThietBi & "',N'" & ThoiGianChayMay & "',N'" & ThoiGianNgungMay & "',N'" & ThoiGianBaoTri & "',N'" & _
        AV & "',N'" & Gio & "',N'" & ThoiGian & "',N'" & Remark & "',N'" & Reviewed & "',N'" & CraneSection & "',N'" & RTGSection & "',N'" & VEHLeader & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

    End Sub


    Sub Printpreview9()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptWEEKLY_EQUIP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptWEP_REPORT", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Call ReportPreview("reports\rptWEP_REPORT.rpt")
        Cursor = Cursors.Default
KetThuc:
        Try
            Commons.Modules.SQLString = "DROP TABLE dbo.rptWEEKLY_EQUIP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try
        Try
            Commons.Modules.SQLString = "DROP TABLE dbo.rptTieuDeWeeklyEuip"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub frmrptWEP_REPORT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadcboDiaDiem()
        Bind_cboLoaithietbi3()
        Bind_cboNhomthietbi3()
        Bind_cbothietbi3()
    End Sub

    Sub LoadcboDiaDiem()
        cboDiaDiem.Value = "MS_N_XUONG"
        cboDiaDiem.Display = "TEN_N_XUONG"
        cboDiaDiem.Param = Commons.Modules.UserName
        cboDiaDiem.StoreName = "PermisionNHA_XUONG"
        cboDiaDiem.BindDataSource()
    End Sub
    Sub Bind_cboLoaithietbi3()
        Dim str As String = ""
        If cboDiaDiem.Text = "" Then
            Exit Sub
        End If
        str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " & _
        " FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND USERNAME='" & Commons.Modules.UserName & "'"
        cboLoaithietbi3.Display = "TEN_LOAI_MAY"
        cboLoaithietbi3.Value = "MS_LOAI_MAY"
        cboLoaithietbi3.Param = str
        cboLoaithietbi3.StoreName = "QL_SEARCH"
        cboLoaithietbi3.BindDataSource()
        If cboLoaithietbi3.Items.Count = 0 Then
            cboLoaithietbi3.Text = ""
        End If
    End Sub

    Sub Bind_cboNhomthietbi3()
        If cboLoaithietbi3.SelectedIndex = -1 Then
            cboNhomthietbi3.Text = ""
            Exit Sub
        End If
        cboNhomthietbi3.Display = "TEN_NHOM_MAY"
        cboNhomthietbi3.Value = "MS_NHOM_MAY"
        'cboNhomthietbi3.Param = cboLoaithietbi3.SelectedValue
        If cboLoaithietbi3.SelectedValue.ToString = "-1" Then
            cboNhomthietbi3.Param = "SELECT NHOM_MAY.* FROM NHOM_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        Else
            cboNhomthietbi3.Param = "SELECT NHOM_MAY.* FROM NHOM_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE NHOM_LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "' AND (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        End If
        'cboNhomthietbi.StoreName = "Get_rptNhomThietBi"
        cboNhomthietbi3.StoreName = "QL_SEARCH"
        cboNhomthietbi3.BindDataSource()
        If cboNhomthietbi3.Items.Count = 0 Then
            cboNhomthietbi3.Text = ""
        End If
    End Sub

    Sub Bind_cbothietbi3()
        If cboNhomthietbi3.SelectedIndex = -1 Then
            cboThietbi3.Text = ""
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT DISTINCT MAY.MS_MAY, MAY.MS_MAY AS MAY FROM MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN " & _
        " USERS ON NHOM.GROUP_ID = USERS.GROUP_ID where USERNAME='" & Commons.Modules.UserName & "' AND MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        If cboLoaithietbi3.SelectedValue <> "-1" Then
            str = str + " and LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "'"
        End If
        If cboNhomthietbi3.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomthietbi3.SelectedValue & "'"
        End If
        cboThietbi3.Display = "MAY"
        cboThietbi3.Value = "MS_MAY"
        cboThietbi3.Param = str
        cboThietbi3.StoreName = "QL_SEARCH"
        cboThietbi3.BindDataSource()
        If cboThietbi3.Items.Count = 0 Then
            cboThietbi3.Text = ""
        End If
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
