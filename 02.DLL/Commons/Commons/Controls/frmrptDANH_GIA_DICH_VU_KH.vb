Imports System.Data.SqlClient

Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptDANH_GIA_DICH_VU_KH

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        ShowrptBangDanhGia_DVKH()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmrptDANH_GIA_DICH_VU_KH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDenNgay.Value = DateTime.Now
        dtpTuNgay.Value = DateTime.Now.AddMonths(-1)
    End Sub

    Sub ShowrptBangDanhGia_DVKH()

        Dim dtReader As SqlDataReader

        'xóa dl bảng tạm
        '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "if exists (select * from dbo.sysobjects where id = object_id(N'rptDANH_GIA_DICH_VU_KH_TMP11') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table rptDANH_GIA_DICH_VU_KH_TMP11")

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName)

        'chạy câu sql đổ dl vào bảng tạm
        Commons.Modules.SQLString = "SELECT dbo.KHACH_HANG.MS_KH, dbo.KHACH_HANG.TEN_CONG_TY, dbo.KHACH_HANG.TEN_RUT_GON, dbo.KHACH_HANG.DIA_CHI, " & _
                      "dbo.KHACH_HANG.TEL, dbo.KHACH_HANG.FAX, dbo.KHACH_HANG.EMAIL, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, " & _
                      "dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR, dbo.PHIEU_BAO_TRI.MS_MAY, dbo.PHIEU_BAO_TRI.NGAY_LAP, " & _
                      "dbo.DANH_GIA_SERVICE.ID,dbo.PHIEU_BAO_TRI_SERVICE.NOI_DUNG_SERVICE, dbo.DANH_GIA_SERVICE.NOI_DUNG, NULL AS GIA_CA, NULL AS THOI_GIAN, NULL AS CHAT_LUONG, NULL AS HAU_MAI " & _
                 "INTO rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName & " " & _
                 "FROM  dbo.PHIEU_BAO_TRI INNER JOIN dbo.DANH_GIA_SERVICE INNER JOIN " & _
                    "dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE ON dbo.DANH_GIA_SERVICE.ID = dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA INNER JOIN " & _
                    "dbo.PHIEU_BAO_TRI_SERVICE ON dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR = dbo.PHIEU_BAO_TRI_SERVICE.STT AND " & _
                    "dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT = dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI INNER JOIN " & _
                    "dbo.KHACH_HANG ON dbo.PHIEU_BAO_TRI_SERVICE.MS_KH = dbo.KHACH_HANG.MS_KH ON " & _
                    "dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT " & _
              "WHERE CONVERT(DATETIME,dbo.PHIEU_BAO_TRI.NGAY_LAP,103) BETWEEN CONVERT(DATETIME,'" & dtpTuNgay.Value.Date & "',103) AND CONVERT(DATETIME,'" & dtpDenNgay.Value.Date & "',103)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) AS TONG FROM rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName)
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_DICH_VU_KH", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        'lấy những dl có điểm trong PHIEU_BAO_TRI_DANH_GIA_SERICE cập nhật ngược lại bảng tạm rptDANH_GIA_DICH_VU_KH_TMP11
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE")
        While dtReader.Read
            Select Case dtReader.Item("MS_DANH_GIA")
                Case 1  'GIÁ CẢ
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName & " SET GIA_CA=" & dtReader.Item("DIEM") & " ,THOI_GIAN=NULL,CHAT_LUONG=NULL,HAU_MAI=NULL WHERE MS_PHIEU_BAO_TRI='" & dtReader.Item("MS_PBT") & "' AND STT_EOR=" & dtReader.Item("STT_EOR") & " AND ID=" & dtReader.Item("MS_DANH_GIA"))
                Case 2  'THỜI GIAN
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName & " SET THOI_GIAN=" & dtReader.Item("DIEM") & " ,GIA_CA=NULL,CHAT_LUONG=NULL,HAU_MAI=NULL WHERE MS_PHIEU_BAO_TRI='" & dtReader.Item("MS_PBT") & "' AND STT_EOR=" & dtReader.Item("STT_EOR") & " AND ID=" & dtReader.Item("MS_DANH_GIA"))
                Case 3  'CHẤT LƯỢNG
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE  rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName & " SET CHAT_LUONG=" & dtReader.Item("DIEM") & " ,THOI_GIAN=NULL,GIA_CA=NULL,HAU_MAI=NULL WHERE MS_PHIEU_BAO_TRI='" & dtReader.Item("MS_PBT") & "' AND STT_EOR=" & dtReader.Item("STT_EOR") & " AND ID=" & dtReader.Item("MS_DANH_GIA"))
                Case 4  'HẬU MÃI
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE  rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName & " SET HAU_MAI=" & dtReader.Item("DIEM") & " ,THOI_GIAN=NULL,CHAT_LUONG=NULL,GIA_CA=NULL WHERE MS_PHIEU_BAO_TRI='" & dtReader.Item("MS_PBT") & "' AND STT_EOR=" & dtReader.Item("STT_EOR") & " AND ID=" & dtReader.Item("MS_DANH_GIA"))
            End Select
        End While
        objReader.Close()

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDANH_GIA_DICH_VU_KH_TMP")

        'TẠO DL CUỐI IN RA REPORT
        Commons.Modules.SQLString = "SELECT DISTINCT MS_KH, TEN_CONG_TY, TEN_RUT_GON, DIA_CHI, TEL, FAX, EMAIL, MS_PHIEU_BAO_TRI, STT_EOR, MS_MAY, NGAY_LAP, NOI_DUNG_SERVICE, NULL AS GIA_CA, NULL AS THOI_GIAN, NULL AS CHAT_LUONG, NULL AS HAU_MAI INTO rptDANH_GIA_DICH_VU_KH_TMP FROM rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName
        SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Commons.Modules.SQLString = "SELECT * FROM rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName
        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While objReader.Read
            Select Case objReader.Item("ID")
                Case 1  'GIÁ CẢ
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDANH_GIA_DICH_VU_KH_TMP SET GIA_CA=" & objReader.Item("GIA_CA") & " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND STT_EOR=" & objReader.Item("STT_EOR"))
                Case 2  'THỜI GIAN
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDANH_GIA_DICH_VU_KH_TMP SET THOI_GIAN=" & objReader.Item("THOI_GIAN") & " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND STT_EOR=" & objReader.Item("STT_EOR"))
                Case 3  'CHẤT LƯỢNG
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE  rptDANH_GIA_DICH_VU_KH_TMP SET CHAT_LUONG=" & objReader.Item("CHAT_LUONG") & " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND STT_EOR=" & objReader.Item("STT_EOR"))
                Case 4  'HẬU MÃI
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE  rptDANH_GIA_DICH_VU_KH_TMP SET HAU_MAI=" & objReader.Item("HAU_MAI") & " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND STT_EOR=" & objReader.Item("STT_EOR"))
            End Select
        End While

        CreateTitleReportrptTIEU_DE_DANH_GIA_DICH_VU_KH()
        ReportPreview("reports/rptDANH_GIA_DICH_VU_KH.rpt")
KetThuc:
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptDANH_GIA_DICH_VU_KH_TMP")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptTIEU_DE_DANH_GIA_DICH_VU_KH")
        Catch ex As Exception

        End Try
    End Sub

    Sub CreateTitleReportrptTIEU_DE_DANH_GIA_DICH_VU_KH()
        Dim str As String = String.Empty
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table rptTIEU_DE_DANH_GIA_DICH_VU_KH")
        Catch ex As Exception
        End Try
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "TrangIn", Commons.Modules.TypeLanguage)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "TieuDe", Commons.Modules.TypeLanguage)
        Dim KhachHang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "KhachHang", Commons.Modules.TypeLanguage)
        Dim DienThoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "DienThoai", Commons.Modules.TypeLanguage)
        Dim Website As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "Website", Commons.Modules.TypeLanguage)
        Dim DiaChi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "DiaChi", Commons.Modules.TypeLanguage)
        Dim Fax As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "Fax", Commons.Modules.TypeLanguage)
        Dim PhieuBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "PhieuBT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "ThietBi", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "NgayLap", Commons.Modules.TypeLanguage)
        Dim NoiDungService As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "NoiDungService", Commons.Modules.TypeLanguage)
        Dim GiaCa As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "GiaCa", Commons.Modules.TypeLanguage)
        Dim ThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim ChatLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "ChatLuong", Commons.Modules.TypeLanguage)
        Dim HauMai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DANH_GIA_DICH_VU_KH", "HauMai", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = lblTungay.Text & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "    " & lblDenngay.Text & Format(dtpDenNgay.Value, "dd/MM/yyyy")


        'xóa dl bảng tạm
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[rptTIEU_DE_DANH_GIA_DICH_VU_KH]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[rptTIEU_DE_DANH_GIA_DICH_VU_KH]")

        str = "Create table [dbo].rptTIEU_DE_DANH_GIA_DICH_VU_KH(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," & _
        "KhachHang nvarchar(50), DienThoai nvarchar(30),Website nvarchar(30),DiaChi nvarchar(50),Fax nvarchar(20),PhieuBT nvarchar(30),ThietBi nvarchar(30)," & _
        "NgayLap nvarchar(30),NoiDungService nvarchar(50),GiaCa nvarchar(30),ThoiGian nvarchar(30),ChatLuong nvarchar(30),HauMai nvarchar(30),DieuKienLoc nvarchar(255)) " & _
        " Insert into [DBO].rptTIEU_DE_DANH_GIA_DICH_VU_KH(commons.Modules.TypeLanguage,NgayIn,TrangIn,TieuDe,KhachHang,DienThoai,Website,DiaChi,Fax,PhieuBT,ThietBi, " & _
        "NgayLap,NoiDungService,Giaca,ThoiGian,ChatLuong,HauMai,DieuKienLoc) " & _
        " values(" & Commons.Modules.TypeLanguage & ",'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & KhachHang & "',N'" & DienThoai & "',N'" & Website & "',N'" & DiaChi & "',N'" & Fax & "',N'" & PhieuBT & "',N'" & ThietBi & _
        "',N'" & NgayLap & "',N'" & NoiDungService & "',N'" & GiaCa & "',N'" & ThoiGian & "',N'" & ChatLuong & "',N'" & HauMai & "',N'" & DieuKienLoc & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDANH_GIA_DICH_VU_KH_TMP" & Commons.Modules.UserName)

        Me.ParentForm.Close()
    End Sub
End Class
