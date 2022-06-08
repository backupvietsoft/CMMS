﻿Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptCHI_PHI_BAO_TRI_THEO_NHOM_TB

    Private Sub frmrptCHI_PHI_BAO_TRI_THEO_NHOM_TB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpTuNam_TKCP.Value = CDate("1/1/" & Year(Now))
        dtpDenNam_TKCP.Value = CDate("31/12/" & Year(Now))
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM NHOM_MAY ORDER BY TEN_NHOM_MAY"))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        dt.Rows.InsertAt(row, 0)
        cboNhomTB_CP.DataSource = dt
        cboNhomTB_CP.DisplayMember = "TEN_NHOM_MAY"
        cboNhomTB_CP.ValueMember = "MS_NHOM_MAY"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        ShowrptCHI_PHI_BAO_TRI_THEO_NHOM_TB()
        Me.Cursor = Cursors.Default
    End Sub


    Sub ShowrptCHI_PHI_BAO_TRI_THEO_NHOM_TB()
        Dim str As String = "", strNhom_TB As String = ""
        Try
            str = "DROP TABLE rptCHI_PHI_BAO_TRI_THEO_NHOM_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim vTn As String = dtpTuNam_TKCP.Value.ToString("MM/dd/yyyy")
        Dim vDn As String = dtpDenNam_TKCP.Value.ToString("MM/dd/yyyy")

        If cboNhomTB_CP.SelectedValue.ToString <> "-1" Then strNhom_TB = " AND (dbo.NHOM_MAY.MS_NHOM_MAY = '" & cboNhomTB_CP.SelectedValue & "') "

        str = "SELECT MS_MAY, TEN_NHOM_MAY, SUM(CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(CHI_PHI_VAT_TU) AS CHI_PHI_VAT_TU, SUM(CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, SUM(CHI_PHI_DV) AS CHI_PHI_DICH_VU, SUM(CHI_PHI_KHAC) AS CHI_PHI_KHAC, SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY " & _
              "INTO [DBO].rptCHI_PHI_BAO_TRI_THEO_NHOM_TB " & _
              "FROM (SELECT  dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, 0 AS CHI_PHI_HANG_NGAY " & _
                    "FROM    dbo.MAY INNER JOIN " & _
                            "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                            "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                            "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
                            "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI " & _
                            " WHERE dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT >=3 AND (dbo.PHIEU_BAO_TRI.NGAY_BD_KH >= '" & vTn & "' AND dbo.PHIEU_BAO_TRI.NGAY_BD_KH < '" & vDn & "')"
        '"WHERE  (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        If strNhom_TB.Length > 0 Then str = str & strNhom_TB & " "

        str = str & "UNION " & _
                    "SELECT dbo.MAY.MS_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, '' ,0,0,0,0,0, " & _
                            "ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC,0) + ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT,0) AS CHI_PHI_HANG_NGAY " & _
                    "FROM dbo.MAY INNER JOIN " & _
                         "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
                         "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                         "dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY INNER JOIN " & _
                         "dbo.CONG_VIEC_HANG_NGAY ON dbo.CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV = dbo.CONG_VIEC_HANG_NGAY.STT_CV " & _
                         " WHERE  (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH >= '" & vTn & "' AND dbo.CONG_VIEC_HANG_NGAY.NGAY_TH < '" & vDn & "')"  '(dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "
        '"WHERE (dbo.CONG_VIEC_HANG_NGAY.NGAY_TH BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "') "

        If strNhom_TB.Length > 0 Then str = str & strNhom_TB

        str = str & ") TMP GROUP BY MS_MAY, TEN_NHOM_MAY"

        'str = "SELECT MS_MAY,TEN_LOAI_MAY,MS_NHOM_MAY,TEN_NHOM_MAY,SUM(CHI_PHI_PHU_TUNG) AS CHI_PHI_PHU_TUNG, SUM(CHI_PHI_VAT_TU) AS CHI_PHI_VAT_TU, SUM(CHI_PHI_NHAN_CONG) AS CHI_PHI_NHAN_CONG, SUM(CHI_PHI_DV) AS CHI_PHI_DV, SUM(CHI_PHI_KHAC) AS CHI_PHI_KHAC, SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY " & _
        '      "INTO rptCHI_PHI_BAO_TRI_THEO_NHOM_TB " & _
        '      "FROM(SELECT dbo.MAY.MS_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.NHOM_MAY.MS_NHOM_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_PHU_TUNG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_VAT_TU, " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_NHAN_CONG, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_DV, dbo.PHIEU_BAO_TRI_CHI_PHI.CHI_PHI_KHAC, " & _
        '                   "(ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_NC,0) + ISNULL(dbo.CONG_VIEC_HANG_NGAY_THIET_BI.CHI_PHI_VT,0)) AS CHI_PHI_HANG_NGAY " & _
        '            "FROM dbo.MAY INNER JOIN " & _
        '                   "dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '                   "dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '                   "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " & _
        '                   "dbo.PHIEU_BAO_TRI_CHI_PHI ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CHI_PHI.MS_PHIEU_BAO_TRI LEFT OUTER JOIN " & _
        '                   "dbo.CONG_VIEC_HANG_NGAY_THIET_BI ON dbo.MAY.MS_MAY = dbo.CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY " & _
        '           "WHERE  dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & Format(dtpTuNam_TKCP.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNam_TKCP.Value, "MM/dd/yyyy") & "' "

        ''"WHERE (dbo.NHOM_MAY.MS_LOAI_MAY = 'AAAA') AND (dbo.MAY.MS_NHOM_MAY = 'SSSSSS')"

        'If cboNhomTB_CP.SelectedValue.ToString <> "-1" Then str = str & "AND (dbo.NHOM_MAY.MS_NHOM_MAY = '" & cboNhomTB_CP.SelectedValue & "')"
        'str = str & ") TMP GROUP BY MS_MAY,TEN_LOAI_MAY,MS_NHOM_MAY,TEN_NHOM_MAY"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptCHI_PHI_BAO_TRI_THEO_NHOM_TB")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_NHOM_TB", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        CreaterptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB()
        ReportPreview("reports/rptCHI_PHI_BAO_TRI_THEO_NHOM_TB.rpt")
KetThuc:
        Try
            str = "DROP TABLE rptCHI_PHI_BAO_TRI_THEO_NHOM_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Sub CreaterptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TrangIn", Commons.Modules.TypeLanguage)
        Dim sTieude As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_NHOM_TB", "Tieude", Commons.Modules.TypeLanguage)
        Dim sMaSoMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "MaSoMay", Commons.Modules.TypeLanguage)
        Dim sTenNhomMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "TenNhomMay", Commons.Modules.TypeLanguage)
        Dim sChiPhiPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiPT", Commons.Modules.TypeLanguage)
        Dim sChiPhiVT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiVT", Commons.Modules.TypeLanguage)
        Dim sChiPhiNC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiNC", Commons.Modules.TypeLanguage)
        Dim sChiPhiDV As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiDV", Commons.Modules.TypeLanguage)
        Dim sChiPhiKhac As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiKhac", Commons.Modules.TypeLanguage)
        Dim sChiPhiHangNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "ChiPhiHangNgay", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_LOAI_TB", "Tong", Commons.Modules.TypeLanguage)
        Dim sDKLoc As String = lblTuNam_TKCP.Text & " " & dtpTuNam_TKCP.Value & "  -  " & lblDenNam_TKCP.Text & " " & dtpDenNam_TKCP.Value

        str = "CREATE TABLE [DBO].rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB(TypeLanguage int , Trangin nvarchar(20), NgayIn nvarchar(20),TieuDe nvarchar(255),MaSoMay nvarchar(20)," & _
              "TenNhomMay nvarchar(30),ChiPhiPT nvarchar(20),ChiPhiVT nvarchar(30),ChiPhiNC nvarchar(30),ChiPhiDV nvarchar(20),ChiPhiKhac nvarchar(20),ChiPhiHangNgay nvarchar(20),Tong nvarchar(15),DKLoc nvarchar(255)) " & _
              "INSERT INTO [DBO].rptTIEU_DE_CHI_PHI_BAO_TRI_THEO_NHOM_TB(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
              "MaSoMay,TenNhomMay,ChiPhiPT,ChiPhiVT,ChiPhiNC,ChiPhiDV,ChiPhiKhac,ChiPhiHangNgay,Tong,DKLoc)" & _
              "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
              "N'" & sTieude & "',N'" & sMaSoMay & "',N'" & sTenNhomMay & "',N'" & sChiPhiPT & "',N'" & sChiPhiVT & "',N'" & sChiPhiNC & "',N'" & sChiPhiDV & "',N'" & sChiPhiKhac & "',N'" & sChiPhiHangNgay & "'," & _
              "N'" & sTong & "',N'" & sDKLoc & " ')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
