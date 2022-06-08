Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptCHI_PHI_THEO_DAY_CHUYEN

    Private Sub frmrptCHI_PHI_THEO_DAY_CHUYEN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpTuNam_TKCP.Value = CDate("1/1/" & Year(Now))
        dtpDenNam_TKCP.Value = CDate("31/12/" & Year(Now))
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDAY_CHUYEN", Commons.Modules.UserName))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        dt.Rows.InsertAt(row, 0)
        cboDayChuyenSXTB_CP.DataSource = dt
        cboDayChuyenSXTB_CP.DisplayMember = "TEN_HE_THONG"
        cboDayChuyenSXTB_CP.ValueMember = "MS_HE_THONG"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        ShowrptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN()
        Me.Cursor = Cursors.Default
    End Sub

    Sub ShowrptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN()
        Dim str As String = "", strDayChuyen As String = ""
        Try
            str = "DROP TABLE rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        If cboDayChuyenSXTB_CP.SelectedValue.ToString <> "-1" Then strDayChuyen = " AND (dbo.MAY_HE_THONG.MS_HE_THONG = '" & cboDayChuyenSXTB_CP.SelectedValue & "') "

        'str = "SELECT MS_MAY, TEN_HE_THONG, SUM(CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(CHI_PHI_VAT_TU) AS CHI_PHI_VAT_TU, SUM(CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, SUM(CHI_PHI_DV) AS CHI_PHI_DICH_VU, SUM(CHI_PHI_KHAC) AS CHI_PHI_KHAC, SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY " & _
        '      "INTO [DBO].rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN " & _
        '      "FROM (SELECT dbo.MAY.MS_MAY, dbo.HE_THONG.TEN_HE_THONG, MAX(dbo.MAY_HE_THONG.NGAY_NHAP) AS NGAY_NHAP, " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC,0 AS CHI_PHI_HANG_NGAY " & _
        '            "FROM dbo.MAY_HE_THONG INNER JOIN " & _
        '                   "dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN " & _
        '                   "dbo.MAY INNER JOIN " & _
        '                   "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI ON " & _
        '                   "dbo.MAY_HE_THONG.MS_MAY = dbo.MAY.MS_MAY " & _
        '            "WHERE (dbo.MAY_HE_THONG.NGAY_NHAP BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        'If strDayChuyen.Length > 0 Then str = str & strDayChuyen & " "

        'str = str & "GROUP BY dbo.HE_THONG.TEN_HE_THONG, dbo.MAY.MS_MAY, dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI, " & _
        '                     "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, " & _
        '                     "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC " & _
        '            "UNION SELECT dbo.MAY_HE_THONG.MS_MAY, '' as TEN_HE_THONG, '', 0, 0, 0, 0, 0, ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC, 0) + ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT, 0) AS CHI_PHI_HANG_NGAY " & _
        '            "FROM dbo.MAY_HE_THONG INNER JOIN " & _
        '                 "dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN " & _
        '                 "dbo.MAY INNER JOIN " & _
        '                 "dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY INNER JOIN " & _
        '                 "dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV ON " & _
        '                 "dbo.MAY_HE_THONG.MS_MAY = dbo.MAY.MS_MAY " & _
        '            "WHERE (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        'If strDayChuyen.Length > 0 Then str = str & strDayChuyen & " "

        'str = str & ") TMP GROUP BY MS_MAY, TEN_HE_THONG"
        Dim vTn As String = dtpTuNam_TKCP.Value.ToString("MM/dd/yyyy")
        Dim vDn As String = dtpDenNam_TKCP.Value.ToString("MM/dd/yyyy")



        str = "  SELECT MS_MAY ,MS_HE_THONG, TEN_HE_THONG ,CASE WHEN SUM ( CHI_PHI_PHU_TUNG) IS NULL THEN 0 ELSE SUM ( CHI_PHI_PHU_TUNG) END AS CHI_PHI_PHU_TUNG  , CASE WHEN SUM ( CHI_PHI_VAT_TU ) IS NULL THEN 0 ELSE SUM ( CHI_PHI_VAT_TU ) END AS CHI_PHI_VAT_TU , " & _
                " CASE WHEN SUM (CHI_PHI_NHAN_CONG) IS NULL THEN 0 ELSE SUM (CHI_PHI_NHAN_CONG) END AS CHI_PHI_NHAN_CONG , CASE WHEN SUM (CHI_PHI_DV ) IS NULL THEN 0 ELSE SUM (CHI_PHI_DV ) END AS CHI_PHI_DV , CASE WHEN SUM (CHI_PHI_KHAC ) IS NULL THEN 0 ELSE SUM (CHI_PHI_KHAC ) END AS CHI_PHI_KHAC , CASE WHEN SUM (CHI_PHI_HANG_NGAY) IS NULL THEN 0 ELSE SUM (CHI_PHI_HANG_NGAY)END AS CHI_PHI_HANG_NGAY " & _
                "INTO [DBO].rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN " & _
                " FROM ( SELECT     dbo.PHIEU_BAO_TRI.MS_MAY, dbo.HE_THONG.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG, " & _
                " SUM(dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU) " & _
                " AS CHI_PHI_VAT_TU, SUM(dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, " & _
                "  SUM(dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV) AS CHI_PHI_DV, SUM(dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC) AS CHI_PHI_KHAC , 0 AS CHI_PHI_HANG_NGAY " & _
                " FROM         dbo.PHIEU_BAO_TRI INNER JOIN " & _
                " dbo.MAY_HE_THONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY_HE_THONG.MS_MAY INNER JOIN " & _
                " dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG INNER JOIN " & _
                " dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI " & _
                " INNER Join " & _
                " (Select dbo.PHIEU_BAO_TRI.MS_MAY, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, Max(dbo.MAY_HE_THONG.NGAY_NHAP) as NGAY " & _
                " From dbo.PHIEU_BAO_TRI " & _
                " INNER JOIN dbo.MAY_HE_THONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY_HE_THONG.MS_MAY " & _
                " WHERE dbo.PHIEU_BAO_TRI.NGAY_BD_KH >= dbo.MAY_HE_THONG.NGAY_NHAP "
        If strDayChuyen.Length > 0 Then str = str & strDayChuyen & " "
        str = str & " Group by dbo.PHIEU_BAO_TRI.MS_MAY, dbo.PHIEU_BAO_TRI.NGAY_BD_KH)A " & _
                " ON PHIEU_BAO_TRI.MS_MAY = A.MS_MAY AND PHIEU_BAO_TRI.NGAY_BD_KH = A.NGAY_BD_KH AND MAY_HE_THONG.NGAY_NHAP = A.NGAY " & _
                " GROUP BY dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.MS_MAY, dbo.HE_THONG.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG, dbo.MAY_HE_THONG.NGAY_NHAP, " & _
                " dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, dbo.HE_THONG.MS_HE_THONG, dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT " & _
                "HAVING      (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT >= 3) AND (dbo.PHIEU_BAO_TRI.NGAY_BD_KH >= '" & vTn & "') AND " & _
                " (dbo.PHIEU_BAO_TRI.NGAY_BD_KH < '" & vDn & "')" & _
                "UNION SELECT     dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY, dbo.HE_THONG.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG, 0 as CHI_PHI_PHU_TUNG , 0 AS CHI_PHI_VT  , 0 AS CHI_PHI_NC , " & _
                " 0 AS CHI_PHI_DV , 0 AS CHI_PHI_KHAC , SUM ( CASE WHEN dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT IS NULL THEN 0 ELSE dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT END + CASE WHEN dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC IS NULL THEN 0 ELSE dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC END) AS CHI_PHI_HANG_NGAY " & _
                " FROM         dbo.CONG_VIEC_HANG_NGAY INNER JOIN " & _
                " dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.CONG_VIEC_HANG_NGAY.STT_CV = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV INNER JOIN " & _
                " dbo.MAY_HE_THONG INNER JOIN " & _
                " dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG ON  " & _
                " dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY = dbo.MAY_HE_THONG.MS_MAY " & _
                " INNER JOIN ( " & _
                " SELECT     dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY,dbo.CONG_VIEC_HANG_NGAY.NGAY_TH, MAX (dbo.MAY_HE_THONG.NGAY_NHAP) AS NGAY_NHAP " & _
                " FROM         dbo.CONG_VIEC_HANG_NGAY INNER JOIN " & _
                " dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.CONG_VIEC_HANG_NGAY.STT_CV = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV INNER JOIN " & _
                " dbo.MAY_HE_THONG INNER JOIN " & _
                " dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG ON  " & _
                " dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY = dbo.MAY_HE_THONG.MS_MAY  " & _
                " WHERE dbo.CONG_VIEC_HANG_NGAY.NGAY_TH >= dbo.MAY_HE_THONG.NGAY_NHAP AND (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH >= '" & vTn & "' AND dbo.CONG_VIEC_HANG_NGAY.NGAY_TH < '" & vDn & "')"
        If strDayChuyen.Length > 0 Then str = str & strDayChuyen & " "
        str = str & " GROUP BY dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY,dbo.CONG_VIEC_HANG_NGAY.NGAY_TH ) A " & _
                " ON A.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY AND A.NGAY_TH =  dbo.CONG_VIEC_HANG_NGAY.NGAY_TH AND A.NGAY_NHAP = dbo.MAY_HE_THONG.NGAY_NHAP " & _
                " group by dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY, dbo.HE_THONG.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG  )TMP " & _
                " GROUP BY TMP.MS_MAY, MS_HE_THONG, TMP.TEN_HE_THONG "

        '" WHERE MS_HE_THONG = '" + cboDayChuyenSXTB_CP.SelectedValue "'"& _
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_THEO_DAY_CHUYEN", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        CreaterptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN()
        ReportPreview("reports/rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN.rpt")
KetThuc:
        Try
            str = "DROP TABLE rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Sub CreaterptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TrangIn", Commons.Modules.TypeLanguage)
        Dim sTieude As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN", "Tieude", Commons.Modules.TypeLanguage)
        Dim sMaSoMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN", "MaSoMay", Commons.Modules.TypeLanguage)
        Dim sTenLoaiMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN", "TenLoaiMay", Commons.Modules.TypeLanguage)
        Dim sTenNhomMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TenNhomMay", Commons.Modules.TypeLanguage)
        Dim sTenHeThong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_DAY_CHUYEN", "TenHeThong", Commons.Modules.TypeLanguage)
        Dim sChiPhiPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiPT", Commons.Modules.TypeLanguage)
        Dim sChiPhiVT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiVT", Commons.Modules.TypeLanguage)
        Dim sChiPhiNC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiNC", Commons.Modules.TypeLanguage)
        Dim sChiPhiDV As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiDV", Commons.Modules.TypeLanguage)
        Dim sChiPhiKhac As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiKhac", Commons.Modules.TypeLanguage)
        Dim sChiPhiHangNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiHangNgay", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "Tong", Commons.Modules.TypeLanguage)
        Dim DKLoc As String = lblTuNam_TKCP.Text & " " & dtpTuNam_TKCP.Value & "  -  " & lblDenNam_TKCP.Text & " " & dtpDenNam_TKCP.Value

        str = "CREATE TABLE [DBO].rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN(TypeLanguage int , Trangin nvarchar(20), NgayIn nvarchar(20),TieuDe nvarchar(255),MaSoMay nvarchar(30)," & _
              "TenLoaiMay nvarchar(30),TenNhomMay nvarchar(30),TenHeThong nvarchar(30),ChiPhiPT nvarchar(20),ChiPhiVT nvarchar(30),ChiPhiNC nvarchar(30),ChiPhiDV nvarchar(20),ChiPhiKhac nvarchar(20),ChiPhiHangNgay nvarchar(20),Tong nvarchar(15),PhieuBT nvarchar(30),DKLoc nvarchar(255)) " & _
              "INSERT INTO [DBO].rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_DAY_CHUYEN(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe,MaSoMay, " & _
              "TenLoaiMay,TenNhomMay,TenHeThong,ChiPhiPT,ChiPhiVT,ChiPhiNC,ChiPhiDV,ChiPhiKhac,ChiPhiHangNgay,Tong,DKLoc)" & _
              "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
              "N'" & sTieude & "',N'" & sMaSoMay & "',N'" & sTenLoaiMay & "',N'" & sTenNhomMay & "',N'" & sTenHeThong & "',N'" & sChiPhiPT & "',N'" & sChiPhiVT & "',N'" & sChiPhiNC & "',N'" & sChiPhiDV & "',N'" & sChiPhiKhac & "',N'" & sChiPhiHangNgay & "'," & _
              "N'" & sTong & "',N'" & DKLoc & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
