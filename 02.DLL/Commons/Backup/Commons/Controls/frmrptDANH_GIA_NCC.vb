
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDANH_GIA_NCC
    Private SqlText As String = String.Empty
    Private Sub frmrptDANH_GIA_NCC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNCC_Kho"))
        cboNCC.DataSource = dt
        cboNCC.DisplayMember = "TEN_CONG_TY"
        cboNCC.ValueMember = "NGUOI_NHAP"

        dtTuNgay_Kho.Value = CDate("1/1/" & Year(Now))
        dtDenNgay_Kho.Value = CDate("31/12/" & Year(Now))
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        ShowrptDANH_GIA_NCC()
        Me.Cursor = Cursors.Default
    End Sub

    Sub ShowrptDANH_GIA_NCC()
        If cboNCC.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""
        Try
            str = "DROP TABLE rptDANH_GIA_NCC"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        'str = "CREATE TABLE [DBO].rptDANH_GIA_NCC (TEN_CONG_TY NVARCHAR(255),DIA_CHI NVARCHAR(255),TEN_NDD NVARCHAR(50),TEL NVARCHAR(12), " & _
        '" FAX NVARCHAR(30),MS_DH_NHAP_PT NVARCHAR(30),MS_KH NVARCHAR(7), NGAY DATETIME,DANH_GIA NVARCHAR(255), DIEM INT) " & _
        '" INSERT INTO [DBO].rptDANH_GIA_NCC " & _
        '" SELECT KHACH_HANG.TEN_CONG_TY, KHACH_HANG.DIA_CHI, KHACH_HANG.TEN_NDD, KHACH_HANG.TEL, KHACH_HANG.FAX, " & _
        '" IC_DON_HANG_NHAP.MS_DH_NHAP_PT, KHACH_HANG.MS_KH, IC_DON_HANG_NHAP.NGAY, IC_DON_HANG_NHAP.DANH_GIA, " & _
        '" IC_DON_HANG_NHAP.DIEM FROM IC_DON_HANG_NHAP INNER JOIN " & _
        '" KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP = KHACH_HANG.MS_KH AND IC_DON_HANG_NHAP.NGUOI_NHAP='" & cboNCC.SelectedValue & "'" & _
        '" AND IC_DON_HANG_NHAP.NGAY BETWEEN convert(datetime,'" & dtTuNgay_Kho.Value & "',103) AND DateAdd(day,1,convert(datetime,'" & dtDenNgay_Kho.Value & "',103)) ORDER BY IC_DON_HANG_NHAP.NGAY DESC"

        str = " SELECT KHACH_HANG.TEN_CONG_TY, KHACH_HANG.DIA_CHI, KHACH_HANG.TEN_NDD, KHACH_HANG.TEL, KHACH_HANG.FAX, " & _
        " IC_DON_HANG_NHAP.MS_DH_NHAP_PT, KHACH_HANG.MS_KH, IC_DON_HANG_NHAP.NGAY, IC_DON_HANG_NHAP.DANH_GIA,CASE WHEN IC_DON_HANG_NHAP.DIEM IS NULL THEN 0 ELSE IC_DON_HANG_NHAP.DIEM END AS DIEM," & _
        " CASE WHEN IC_DON_HANG_NHAP.DIEM1 IS NULL THEN 0 ELSE IC_DON_HANG_NHAP.DIEM1 END AS DIEM1," & _
        " CASE WHEN IC_DON_HANG_NHAP.DIEM2 IS NULL THEN 0 ELSE IC_DON_HANG_NHAP.DIEM2 END AS DIEM2  " & _
        " INTO rptDANH_GIA_NCC " & _
        " FROM IC_DON_HANG_NHAP INNER JOIN KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP = KHACH_HANG.MS_KH AND IC_DON_HANG_NHAP.NGUOI_NHAP='" & cboNCC.SelectedValue & "'" & _
        " AND IC_DON_HANG_NHAP.NGAY BETWEEN convert(datetime,'" & dtTuNgay_Kho.Value & "',103) AND DateAdd(day,1,convert(datetime,'" & dtDenNgay_Kho.Value & "',103)) ORDER BY IC_DON_HANG_NHAP.NGAY DESC"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDANH_GIA_NCC")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        CreateTitleReportrptTIEU_DE_DANH_GIA_NHA_CUNG_CAP()
        ReportPreview("reports/rptDANH_GIA_NCC.rpt")
        Cursor = Cursors.Default
KetThuc:
        Try
            str = "DROP TABLE rptDANH_GIA_NCC"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            SqlText = " DROP TABLE rptTIEU_DE_DANH_GIA_NHA_CUNG_CAP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub

    Sub CreateTitleReportrptTIEU_DE_DANH_GIA_NHA_CUNG_CAP()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rptTIEU_DE_DANH_GIA_NHA_CUNG_CAP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "TieuDe1", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "TrangIn", Commons.Modules.TypeLanguage)
        Dim sTenNDD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "TenNDD", Commons.Modules.TypeLanguage)
        Dim sMaKH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "MaKH", Commons.Modules.TypeLanguage)
        Dim sTenCongTy As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "TenCongTy", Commons.Modules.TypeLanguage)
        Dim sDiaChi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "DiaChi", Commons.Modules.TypeLanguage)
        Dim stTel As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "stTel", Commons.Modules.TypeLanguage)
        Dim stFax As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "stFax", Commons.Modules.TypeLanguage)
        Dim sMaSoDHNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "MaPhieuNhapKho", Commons.Modules.TypeLanguage)
        Dim sNgayNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "NgayNhap", Commons.Modules.TypeLanguage)
        Dim sDanhGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "DanhGia", Commons.Modules.TypeLanguage)
        Dim sDiem As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "sDiem", Commons.Modules.TypeLanguage)
        Dim sDiemTB As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "DiemTB", Commons.Modules.TypeLanguage)
        Dim TuGio As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "TuGio", Commons.Modules.TypeLanguage)
        Dim DenGio As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "DenGio", Commons.Modules.TypeLanguage)

        Dim sDiem1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "sDiem1", Commons.Modules.TypeLanguage)
        Dim sDiem2 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "sDiem2", Commons.Modules.TypeLanguage)
        Dim sDiemTB1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_GIA_NCC", "sDiemTB1", Commons.Modules.TypeLanguage)


        Dim ThoiGian As String = ""
        ThoiGian = TuGio & " " & Format(dtTuNgay_Kho.Value, "Short date") & " " & DenGio & " " & Format(dtDenNgay_Kho.Value, "Short date")
        SqlText = "CREATE TABLE DBO.rptTIEU_DE_DANH_GIA_NHA_CUNG_CAP(TypeLanguage int, TrangIn nvarchar(20), NgayIn nvarchar(30),TieuDe nvarchar(255)," & _
        "TenNDD nvarchar(50),MaKH nvarchar(30),TenCongTy nvarchar(70),DiaChi nvarchar(30),stTel nvarchar(20)," & _
        "stFax nvarchar(20),MaSoDHNhap nvarchar(30),NgayNhap nvarchar(20),DanhGia nvarchar(30)," & _
        "sDiem nvarchar(20),DiemTB nvarchar(30),STT nvarchar(10), ThoiGian nvarchar(255), sDiem1 nvarchar(255), sDiem2 nvarchar(255), sDiemTB1 nvarchar(255) )"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "INSERT INTO [DBO].rptTIEU_DE_DANH_GIA_NHA_CUNG_CAP(commons.Modules.TypeLanguage,NgayIn,TrangIn,TieuDe, " & _
        "TenNDD,MaKH,TenCongTy,DiaChi,stTel,stFax,MaSoDHNhap,NgayNhap,DanhGia,sDiem,DiemTB,STT,ThoiGian,sDiem1,sDiem2,sDiemTB1)" & _
        "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
        "N'" & sTieudeReport & "',N'" & sTenNDD & "',N'" & sMaKH & "',N'" & sTenCongTy & "',N'" & sDiaChi & "',N'" & stTel & "',N'" & stFax & "',N'" & sMaSoDHNhap & "',N'" & sNgayNhap & "'," & _
                "N'" & sDanhGia & "',N'" & sDiem & "',N'" & sDiemTB & "',N'" & sSTT & "',N'" & ThoiGian & "',N'" & sDiem1 & "',N'" & sDiem2 & "',N'" & sDiemTB1 & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
