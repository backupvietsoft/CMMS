
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptCTY_DA_CUNG_CAP_VAT_TU
    Private SqlText As String = String.Empty

    Private Sub frmrptCTY_DA_CUNG_CAP_VAT_TU_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNCC_Kho"))
        cboNCC.DataSource = dt
        cboNCC.DisplayMember = "TEN_CONG_TY"
        cboNCC.ValueMember = "NGUOI_NHAP"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        ShowrptCTY_DA_CUNG_CAP_VAT_TU()
        Me.Cursor = Cursors.Default
    End Sub

    Sub ShowrptCTY_DA_CUNG_CAP_VAT_TU()
        If cboNCC.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""
        Try
            str = "DROP TABLE rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE [DBO].rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY(MS_PT  NVARCHAR(25),TEN_PT NVARCHAR(250),QUY_CACH NVARCHAR(255),TEN_CONG_TY NVARCHAR(255)," & _
        " TEN_NDD NVARCHAR(250),DIA_CHI NVARCHAR(255),sFAX NVARCHAR(30),NGAY DATETIME,DON_GIA FLOAT, SO_LUONG FLOAT, sTEL nvarchar(15), NGOAI_TE NVARCHAR (6)) " & _
        " INSERT INTO [DBO].rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY " & _
        " SELECT * FROM(SELECT DISTINCT   IC_DON_HANG_NHAP_VAT_TU.MS_PT,TEN_PT,QUY_CACH,KHACH_HANG.TEN_CONG_TY,TEN_NDD,KHACH_HANG.DIA_CHI ,KHACH_HANG.FAX " & _
        " ,( select TOP 1 MAX(NGAY)AS NGAY  FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP)" & _
        " AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT  )AS NGAY, " & _
        "(select TOP 1 DON_GIA FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
       "  AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND NGAY=(select TOP 1 MAX(NGAY)AS NGAY " & _
        " FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
        " AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT ))AS DON_GIA, " & _
       " ( SELECT SUM(SL_THUC_NHAP) FROM  IC_DON_HANG_NHAP D , IC_DON_HANG_NHAP_VAT_TU DVT WHERE " & _
       "  D.MS_DH_NHAP_PT=DVT.MS_DH_NHAP_PT AND D.NGUOI_NHAP= dbo.IC_DON_HANG_NHAP.NGUOI_NHAP AND " & _
       " DVT.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT )AS SO_LUONG ,KHACH_HANG.TEL,IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE" & _
       " FROM         IC_DON_HANG_NHAP INNER JOIN " & _
                     " IC_DON_HANG_NHAP_VAT_TU ON IC_DON_HANG_NHAP.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT INNER JOIN " & _
                     " KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP = KHACH_HANG.MS_KH  INNER JOIN IC_PHU_TUNG " & _
       " ON IC_DON_HANG_NHAP_VAT_TU.MS_PT=IC_PHU_TUNG.MS_PT AND KHACH_HANG.MS_KH='" & cboNCC.SelectedValue & "') TMP WHERE SO_LUONG>0"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        CreaterptTIEU_DE_CONG_TY_VAT_TU()
        ReportPreview("reports/rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY.rpt")
KetThuc:
        Try
            str = "DROP TABLE rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "DROP TABLE rptTIEU_DE_CONG_TY_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
    End Sub

    Sub CreaterptTIEU_DE_CONG_TY_VAT_TU()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_CONG_TY_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE dbo.rptTIEU_DE_CONG_TY_VAT_TU(TypeLanguage int, Ngayin nvarchar(20), TrangIn nvarchar(20), TieuDe nvarchar(255)," & _
            "NhaCungCap nvarchar(50), DiaChi nvarchar(20),NguoiDaiDien nvarchar(50),DienThoai nvarchar(30), stFax nvarchar(5), " & _
            "STT nvarchar(5),MaPhuTung nvarchar(30),TenPT nvarchar(50), QuyCach nvarchar(30), SoLuong nvarchar(30), DonGia nvarchar(20), " & _
            "NgayCuoi nvarchar(30),Tong nvarchar(20), ThoiGian nvarchar(70)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim sTieudeReport As String = ""
        sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TieuDe2", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TrangIn", Commons.Modules.TypeLanguage)
        Dim sNhaCungCap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "NhaCungCap", Commons.Modules.TypeLanguage)
        Dim sDiaChi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "DiaChi", Commons.Modules.TypeLanguage)
        Dim sNguoiDaiDien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TenNDD", Commons.Modules.TypeLanguage)
        Dim sDienThoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "stTel", Commons.Modules.TypeLanguage)
        Dim stFax As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "stFax", Commons.Modules.TypeLanguage)
        Dim sMaPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "MaPT", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sSoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "SoLuong", Commons.Modules.TypeLanguage)
        Dim sDonGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "DonGia", Commons.Modules.TypeLanguage)
        Dim sNgayCuoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "NgayCuoi", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "Tong", Commons.Modules.TypeLanguage)
        Dim sThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TenPT", Commons.Modules.TypeLanguage)

        SqlText = "INSERT INTO [DBO].rptTIEU_DE_CONG_TY_VAT_TU(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
                "NhaCungCap,DiaChi,NguoiDaiDien,DienThoai,stFax,MaPhuTung,TenPT,QuyCach,SoLuong,DonGia,NgayCuoi,Tong,ThoiGian,STT )" & _
                "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
                "N'" & sTieudeReport & "',N'" & sNhaCungCap & "',N'" & sDiaChi & "',N'" & sNguoiDaiDien & "',N'" & sDienThoai & "',N'" & stFax & "',N'" & sMaPhuTung & "',N'" & TenPT & "',N'" & sQuyCach & "',N'" & sSoLuong & "',N'" & sDonGia & "'," & _
                        "N'" & sNgayCuoi & "',N'" & sTong & "',N'" & sThoiGian & "',N'" & sSTT & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
