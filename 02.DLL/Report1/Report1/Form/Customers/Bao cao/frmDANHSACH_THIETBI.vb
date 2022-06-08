Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports System
Imports System.Globalization
Imports System.Threading
Imports Commons.VS.Classes.Admin
Imports System.Windows.Forms.Control

Public Class frmDANHSACH_THIETBI
    Dim SqlText As String = String.Empty

    Private Sub frmDANHSACH_THIETBI_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmDANHSACH_THIETBI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboNhaxuong.Value = "MS_N_XUONG"
        cboNhaxuong.Display = "Ten_N_XUONG"
        cboNhaxuong.StoreName = "GetNHA_XUONGs"
        cboNhaxuong.BindDataSource()

        cboLoaiThietBi.Value = "MS_LOAI_MAY"
        cboLoaiThietBi.Display = "TEN_LOAI_MAY"
        cboLoaiThietBi.StoreName = "GetLOAI_MAYs"
        cboLoaiThietBi.BindDataSource()

        cboHeThong.Value = "MS_HE_THONG"
        cboHeThong.Display = "TEN_HE_THONG"
        cboHeThong.StoreName = "GetHE_THONGs"
        cboHeThong.BindDataSource()

        cboThietBi.Value = "MS_MAY"
        cboThietBi.Display = "MSMAY"
        cboThietBi.StoreName = "GetMAY_MS"
        cboThietBi.BindDataSource()

        cboPhuTung.Value = "MS_PT"
        cboPhuTung.Display = "TEN_PT"
        cboPhuTung.StoreName = "GetIC_PHU_TUNG_NCCs"
        cboPhuTung.BindDataSource()

        RefeshLanguage()
        radDanhsachThietBi.Checked = True
    End Sub
    Private Sub RefeshLanguage()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Sub CreateData1()
        RefeshHeaderReport()
        Cursor = Cursors.WaitCursor
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try


        'SqlText = "DELETE FROM DANH_SACH_THIET_BI_TMP"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Try
            SqlText = "DROP dbo.TABLE DANH_SACH_THIET_BI_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try


        SqlText = "SELECT * INTO  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            ' SqlText = "INSERT INTO DANH_SACH_THIET_BI_TMP SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'"
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY INTO dbo.DANH_SACH_THIET_BI_TMP FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP HAVING MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY INTO dbo.DANH_SACH_THIET_BI_TMP FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY INTO dbo.DANH_SACH_THIET_BI_TMP FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX, LOAI_MAY.TEN_LOAI_MAY INTO dbo.DANH_SACH_THIET_BI_TMP FROM LOAI_MAY INNER JOIN (HANG_SAN_XUAT INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON HANG_SAN_XUAT.MS_HSX = MAY.MS_HSX) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        RefeshLanguageReport1()
        Cursor = Cursors.Default


    End Sub
    Sub Printpreview1()
        Cursor = Cursors.WaitCursor

        Call Commons.mdShowReport.ReportPreview("reports\rptDanhSach_ThietBi.rpt")
        Cursor = Cursors.Default
        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_THIET_BI_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
    End Sub
    Sub RefeshHeaderReport()
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        If commons.Modules.TypeLanguage = 1 Then

            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS TEN_CTY, THONG_TIN_CHUNG.TEN_NGAN_TIENG_ANH AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngayanh & "' INTO dbo.rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If commons.Modules.TypeLanguage = 0 Then

            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngay & "' INTO dbo.rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If

    End Sub
    Private Sub RefeshLanguageReport1()
        Dim danhsachthietbi, tennhaxuong, tenloaimay, stt, maso, sothe, nhomthietbi, chucnang, hangsx, nuocsx, trang As String
        Me.lblBao_cao_thong_tin_thiet_bi.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        danhsachthietbi = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "rptDanhSach_ThietBi  ", commons.Modules.TypeLanguage)
        'danhsachthietbi
        'CINT
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "tennhaxuong", commons.Modules.TypeLanguage)
        '  Label1.Text = danhsachthietbi
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "tenloaimay", commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "stt", commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "maso", commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "sothe", commons.Modules.TypeLanguage)
        nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "nhomthietbi", commons.Modules.TypeLanguage)
        chucnang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "chucnang", commons.Modules.TypeLanguage)
        hangsx = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "hangsx", commons.Modules.TypeLanguage)
        nuocsx = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "nuocsx", commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSach_ThietBi", "trang", commons.Modules.TypeLanguage)


        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_TMP (   TIEUDE_  nvarchar(250),     TEN_NHA_XUONG_  nvarchar(250), TEN_LOAI_MAY_  nvarchar(250),STT_ nvarchar(250),MA_SO_  nvarchar(250),SO_THE_  nvarchar(250),NHOM_THIET_BI_ nvarchar(250),CHUC_NANG_ nvarchar(250),HANG_SX_ nvarchar(250),NUOC_SX_ nvarchar(250)  ,TRANG nvarchar(250)   )"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        ' SqlText = "INSERT INTO dbo.rptDANH_SACH_THIET_BI_TMP VALUES ('danh sách thiết bị','" & tennhaxuong & "','" & tenloaimay & "','" & stt & "','" & maso & "','" & sothe & "','" & nhomthietbi & "','" & chucnang & "','" & hangsx & "','" & nuocsx & "')"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        ' SqlText = "INSERT INTO dbo.rptDANH_SACH_THIET_BI_TMP VALUES ('danh sách thiết bị')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDANH_SACH_THIET_BI", danhsachthietbi, tennhaxuong, tenloaimay, stt, maso, sothe, nhomthietbi, chucnang, hangsx, nuocsx, trang)

        'SqlText = "INSERT INTO dbo.rptDANH_SACH_THIET_BI_TMP VALUES ('" & danhsachthietbi & "','" & tennhaxuong & "','" & tenloaimay & "','" & stt & "','" & maso & "','" & sothe & "','" & nhomthietbi & "','" & chucnang & "','" & hangsx & "','" & nuocsx & "')"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub


    Private Sub RefeshLanguageReport4()
        Dim danhsachthietbihetkhauhao, tennhaxuong, tenloaimay, stt, maso As String
        Dim sothe, tennhommay, ngaysudung, sonamkhauhao, ngayhetkhauhao, trang As String

        danhsachthietbihetkhauhao = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "danhsachthietbihetkhauhao", commons.Modules.TypeLanguage)
        ngaysudung = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "ngaysudung", commons.Modules.TypeLanguage)
        sonamkhauhao = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "sonamkhauhao", commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "tennhaxuong", commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "tenloaimay", commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "stt", commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", " maso", commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "sothe", commons.Modules.TypeLanguage)
        tennhommay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "tennhommay", commons.Modules.TypeLanguage)
        ngayhetkhauhao = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "ngayhetkhauhao", commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachTBHET_KH", "trang", commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_HET_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_HET_KHAU_HAO_TMP (   DANH_SACH_THIET_BI_HET_KHAU_HAO  nvarchar(250),     NGAY_SU_DUNG_ nvarchar(250),SO_NAM_KH_  nvarchar(250),TEN_NHA_XUONG_ nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),TEN_NHOM_MAY_ nvarchar(250),NGAY_HET_KHAU_HAO_ nvarchar(250),TRANG_ nvarchar(250))    "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanhSachThietBiHetKhauHao", danhsachthietbihetkhauhao, ngaysudung, sonamkhauhao, tennhaxuong, tenloaimay, stt, maso, sothe, tennhommay, ngayhetkhauhao, trang)
        '  SqlText = "INSERT INTO rptDANH_SACH_THIET_BI_HET_KHAU_HAO_TMP VALUES ('" & danhsachthietbihetkhauhao & "','" & ngaysudung & "','" & sonamkhauhao & "','" & tennhaxuong & "','" & tenloaimay & "','" & stt & "','" & maso & "','" & sothe & "','" & tennhommay & "','" & ngayhetkhauhao & "','" & trang & "')"
        ' SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub
    Private Sub RefeshLanguageReport5()
        Dim danhsachthietbitronghethong, tenhethong As String
        Dim tennhaxuong, tenloaimay, stt, maso, sothe, nhomthietbi, chucnang As String
        Dim hangsx, nuocsx, trang As String

        danhsachthietbitronghethong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "danhsachthietbitronghethong", commons.Modules.TypeLanguage)
        tenhethong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "tenhethong", commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "tennhaxuong", commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "tenloaimay", commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "stt", commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "maso", commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "sothe", commons.Modules.TypeLanguage)
        nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "nhomthietbi", commons.Modules.TypeLanguage)
        chucnang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "chucnang", commons.Modules.TypeLanguage)
        hangsx = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "hangsx", commons.Modules.TypeLanguage)
        nuocsx = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "nuocsx", commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiTrongHeThong", "trang", commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP dbo.TABLE rptDANH_SACH_THIET_BI_TRONG_HE_THONG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try


        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_TRONG_HE_THONG_TMP (   DANH_SACH_THIET_BI_TRONG_HE_THONG  nvarchar(250),     TEN_HE_THONG_ nvarchar(250),TEN_NHA_XUONG_  nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),NHOM_THIET_BI_ nvarchar(250),CHUC_NANG_ nvarchar(250),HANG_SX_ nvarchar(250),NUOC_SX_ nvarchar(250),TRANG_ nvarchar(250))    "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


        'SqlText = "INSERT INTO rptDANH_SACH_THIET_BI_TRONG_HE_THONG_TMP VALUES ('" & danhsachthietbitronghethong & "','" & tenhethong & "','" & tennhaxuong & "','" & tenloaimay & "','" & stt & "','" & maso & "','" & sothe & "','" & nhomthietbi & "','" & chucnang & "','" & hangsx & "','" & nuocsx & "','" & trang & "')"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanhSachThietBiTrongHeThong", danhsachthietbitronghethong, tenhethong, tennhaxuong, tenloaimay, stt, maso, sothe, nhomthietbi, chucnang, hangsx, nuocsx, trang)
    End Sub
    Private Sub RefeshLanguageReport6()
        Dim danhsachnoilapdat, ngaynhap, bophanchiuphi As String
        Dim tennhaxuong, tenloaimay, stt, maso, nhomthietbi, trang, sothe As String


        danhsachnoilapdat = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "danhsachnoilapdat", commons.Modules.TypeLanguage)
        ngaynhap = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "ngaynhap", commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "tennhaxuong", commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "tenloaimay", commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "stt", commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "maso", commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "sothe", commons.Modules.TypeLanguage)
        bophanchiuphi = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "bophanchiuphi", commons.Modules.TypeLanguage)
        '  bophanchiuphi = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "bophanchiuphi", commons.Modules.TypeLanguage)
        nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "nhomthietbi", commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "trang", commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_NOI_LAP_DAT_BPCP_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDANH_SACH_NOI_LAP_DAT_BPCP_TMP(   DANH_SACH_NOI_LAP_DAT_  nvarchar(250),     NGAY_NHAP_ nvarchar(250),TEN_NHA_XUONG_  nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),BO_PHAN_CHIU_PHI_ nvarchar(250),NHOM_THIET_BI_ nvarchar(250),TRANG_ nvarchar(250))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


        'SqlText = "INSERT INTO rptDANH_SACH_NOI_LAP_DAT_BPCP_TMP VALUES ('" & danhsachnoilapdat & "','" & ngaynhap & "','" & tennhaxuong & "','" & tenloaimay & "','" & stt & "','" & maso & "','" & sothe & "','" & bophanchiuphi & "','" & nhomthietbi & "','" & trang & "')"
        ' SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanh_SachThietBiTrongHeThong", danhsachnoilapdat, ngaynhap, tennhaxuong, tenloaimay, stt, maso, sothe, bophanchiuphi, nhomthietbi, trang)

    End Sub
    Private Sub RefeshLanguageReport7()
        Dim danhsachthietbisungphutung, msphutung, tenphutung, partNo, msCongty, dvt As String
        Dim tennhaxuong, tenloaimay, stt, maso, nhomthietbi, soluong, trang As String


        danhsachthietbisungphutung = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "danhsachthietbisungphutung", commons.Modules.TypeLanguage)
        msphutung = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "msphutung", commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "tennhaxuong", commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "tenloaimay", commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "stt", commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "maso", commons.Modules.TypeLanguage)
        tenphutung = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "tenphutung", commons.Modules.TypeLanguage)
        nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "nhomthietbi", commons.Modules.TypeLanguage)
        partNo = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "partNo", commons.Modules.TypeLanguage)
        msCongty = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "msCongty", commons.Modules.TypeLanguage)
        dvt = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "dvt", commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "trang", commons.Modules.TypeLanguage)
        soluong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "soluong", commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_SU_DUNG_PHU_TUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_SU_DUNG_PHU_TUNG_TMP (   DANH_SACH_THIET_BI_SU_DUNG_PT_  nvarchar(250),     MS_PHU_TUNG_ nvarchar(250),TEN_NHA_XUONG_ nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),TEN_PHU_TUNG_ nvarchar(250),NHOM_THIET_BI_ nvarchar(250),PART_No_ nvarchar(250),MS_CTY_ nvarchar(250),DVT_ nvarchar(250),SO_LUONG_ nvarchar(250),TRANG_ nvarchar(250)    )"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanhSachThietBiSuDungPhuTung", danhsachthietbisungphutung, msphutung, tennhaxuong, tenloaimay, stt, maso, tenphutung, nhomthietbi, partNo, msCongty, dvt, soluong, trang)

    End Sub
    Private Sub RefeshLanguageReport2()
        Dim danhsachthietbihethanbaohanh, tungay, denngay, tennhaxuong, tenloaimay, stt, maso As String
        Dim sothe, tennhommay, sothangbh, ngayhethanbh, trang As String

        danhsachthietbihethanbaohanh = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "danhsachthietbihethanbaohanh", commons.Modules.TypeLanguage)
        tungay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "tungay", commons.Modules.TypeLanguage)
        denngay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "denngay", commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "tennhaxuong", commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "tenloaimay", commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "stt", commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", " maso", commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "sothe", commons.Modules.TypeLanguage)
        tennhommay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", " tennhommay", commons.Modules.TypeLanguage)
        sothangbh = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "sothangbh", commons.Modules.TypeLanguage)
        ngayhethanbh = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", " ngayhethanbh", commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "trang", commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_HET_HAN_BAO_HANH_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try


        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_HET_HAN_BAO_HANH_TMP (   DANH_SACH_HET_HAN_BH_  nvarchar(250),     TU_NGAY_ nvarchar(250),DEN_NGAY_  nvarchar(250),TEN_NHA_XUONG_ nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),TEN_NHOM_MAY_ nvarchar(250),SO_THANG_BH_ nvarchar(250),NGAY_HET_HAN_BH_ nvarchar(250),TRANG_  nvarchar(250))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDANHSACHTHIETBIHETHANBAOHANH", danhsachthietbihethanbaohanh, tungay, denngay, tennhaxuong, tenloaimay, stt, maso, sothe, tennhommay, sothangbh, ngayhethanbh, trang)
        'SqlText = "INSERT INTO rptDANH_SACH_THIET_BI_HET_HAN_BAO_HANH_TMP VALUES ('" & danhsachthietbihethanbaohanh & "','" & tungay & "','" & denngay & "','" & tennhaxuong & "','" & tenloaimay & "','" & stt & "','" & maso & "','" & sothe & "','" & tennhommay & "','" & sothangbh & "','" & ngayhethanbh & "','" & trang & "')"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub
    Sub CreateData2()
        Cursor = Cursors.WaitCursor
        RefeshHeaderReport()
        RefeshLanguageReport2()
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP dbo.TABLE HET_HAN_BH_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        'SqlText = "DELETE FROM HET_HAN_BH_TMP"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlText = "SELECT * INTO  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH] AS HET_HAN_BH,TUNGAY='" & CStr(txtTungay.Text) & "',DENNGAY='" & CStr(txtDenngay.Text) & "', LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP INTO dbo.HET_HAN_BH_TMP  FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (NHA_XUONG INNER JOIN (MAY INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH], LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP HAVING  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND [NGAY_BD_BAO_HANH]+[SO_THANG_BH]>='" & TDateFormat(txtTungay.Text) & "' And [NGAY_BD_BAO_HANH]+[SO_THANG_BH]<='" & TDateFormat(txtDenngay.Text) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH] AS HET_HAN_BH,TUNGAY='" & CStr(txtTungay.Text) & "',DENNGAY='" & CStr(txtDenngay.Text) & "', LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP INTO dbo.HET_HAN_BH_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (NHA_XUONG INNER JOIN (MAY INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH], LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,LOAI_MAY.MS_LOAI_MAY HAVING  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'AND [NGAY_BD_BAO_HANH]+[SO_THANG_BH]>='" & TDateFormat(txtTungay.Text) & "' And [NGAY_BD_BAO_HANH]+[SO_THANG_BH]<='" & TDateFormat(txtDenngay.Text) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH] AS HET_HAN_BH,TUNGAY='" & CStr(txtTungay.Text) & "',DENNGAY='" & CStr(txtDenngay.Text) & "', LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP INTO dbo.HET_HAN_BH_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (NHA_XUONG INNER JOIN (MAY INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH], LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NHA_XUONG.MS_N_XUONG HAVING  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'AND [NGAY_BD_BAO_HANH]+[SO_THANG_BH]>='" & TDateFormat(txtTungay.Text) & "' And [NGAY_BD_BAO_HANH]+[SO_THANG_BH]<='" & TDateFormat(txtDenngay.Text) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH] AS HET_HAN_BH,TUNGAY='" & TDateFormat(txtTungay.Text) & "',DENNGAY='" & TDateFormat(txtDenngay.Text) & "', LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP dbo.INTO HET_HAN_BH_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (NHA_XUONG INNER JOIN (MAY INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.SO_THANG_BH, MAY.NGAY_BD_BAO_HANH, [MAY].[NGAY_BD_BAO_HANH]+[MAY].[SO_THANG_BH], LOAI_MAY.TEN_LOAI_MAY, MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG HAVING  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'AND  NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'AND [NGAY_BD_BAO_HANH]+[SO_THANG_BH]>='" & TDateFormat(txtTungay.Text) & "' And [NGAY_BD_BAO_HANH]+[SO_THANG_BH]<='" & TDateFormat(txtDenngay.Text) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If

        Cursor = Cursors.Default

    End Sub
    Sub Printpreview2()
        Cursor = Cursors.WaitCursor

        Call Commons.mdShowReport.ReportPreview("reports\rptDanhSachHetHanBaoHanh.rpt")
        Cursor = Cursors.Default
        Try
            SqlText = "DROP TABLE dbo.HET_HAN_BH_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_HET_HAN_BAO_HANH_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
    End Sub
    Sub CreateData4()
        Cursor = Cursors.WaitCursor

        RefeshHeaderReport()
        RefeshLanguageReport4()
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = "SELECT * INTO  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD,SO_NAM_KHAU_HAO, LOAI_MAY.TEN_LOAI_MAY, [MAY].[SO_NAM_KHAU_HAO]*365+[MAY].[NGAY_DUA_VAO_SD] AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,GIA_MUA ,SO_NAM_KHAU_HAO HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])<='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD,SO_NAM_KHAU_HAO, LOAI_MAY.TEN_LOAI_MAY, [MAY].[SO_NAM_KHAU_HAO]*365+[MAY].[NGAY_DUA_VAO_SD] AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])<='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, SO_NAM_KHAU_HAO,LOAI_MAY.TEN_LOAI_MAY, [MAY].[SO_NAM_KHAU_HAO]*365+[MAY].[NGAY_DUA_VAO_SD] AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP ,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])<='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND  NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, SO_NAM_KHAU_HAO,LOAI_MAY.TEN_LOAI_MAY, [MAY].[SO_NAM_KHAU_HAO]*365+[MAY].[NGAY_DUA_VAO_SD] AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])<='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        Cursor = Cursors.Default
    End Sub
    Sub Printpreview4()

        Cursor = Cursors.WaitCursor

        Call Commons.mdShowReport.ReportPreview("reports\rptDanhSachThietBiHetKhauHao.rpt")
        Cursor = Cursors.Default
        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_HET_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub RefeshLanguageReport3()
        Dim danhsachthietbiconkhauhao, tennhaxuong, tenloaimay, stt, maso, ngayhetkh As String
        Dim sothe, tennhommay, ngaysudung, sonamkhauhao, gtconlai, tiente, trang As String

        danhsachthietbiconkhauhao = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "danhsachthietbiconkhauhao", commons.Modules.TypeLanguage)
        ngaysudung = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "ngaysudung", commons.Modules.TypeLanguage)
        sonamkhauhao = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "sonamkhauhao", commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tennhaxuong", commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tenloaimay", commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", " stt", commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "maso", commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "sothe", commons.Modules.TypeLanguage)
        tennhommay = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tennhommay", commons.Modules.TypeLanguage)
        gtconlai = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", " gtconlai", commons.Modules.TypeLanguage)
        ngayhetkh = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", " ngayhetkh", commons.Modules.TypeLanguage)

        tiente = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tiente", commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "trang", commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try


        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP (   DANH_SACH_THIET_BI_CON_KHAU_HAO_  nvarchar(250),     NGAY_SU_DUNG_ nvarchar(250),SO_NAM_KHAU_HAO_  nvarchar(250),TEN_NHA_XUONG_ nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),TEN_NHOM_MAY_ nvarchar(250),GT_CON_LAI_ nvarchar(250),TIEN_TE_ nvarchar(250),TRANG_ nvarchar(250),NGAY_HET_KH nvarchar(250))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanhSachThietBiConKhauHao", danhsachthietbiconkhauhao, ngaysudung, sonamkhauhao, tennhaxuong, tenloaimay, stt, maso, sothe, tennhommay, gtconlai, tiente, trang, ngayhetkh)
        ' SqlText = "INSERT INTO rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP VALUES ('" & danhsachthietbiconkhauhao & "','" & ngaysudung & "','" & sonamkhauhao & "','" & tennhaxuong & "','" & tenloaimay & "','" & stt & "','" & maso & "','" & sothe & "','" & tennhommay & "','" & gtconlai & "','" & tiente & "','" & trang & "','" & ngayhetkh & "')"
        '  SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub
    Sub CreateData3()
        RefeshHeaderReport()
        RefeshLanguageReport3()
        Cursor = Cursors.WaitCursor
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = "SELECT * INTO  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD,SO_NAM_KHAU_HAO, LOAI_MAY.TEN_LOAI_MAY, [MAY].[SO_NAM_KHAU_HAO]*365+[MAY].[NGAY_DUA_VAO_SD] AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,GIA_MUA ,SO_NAM_KHAU_HAO HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD,SO_NAM_KHAU_HAO, LOAI_MAY.TEN_LOAI_MAY, [MAY].[SO_NAM_KHAU_HAO]*365+[MAY].[NGAY_DUA_VAO_SD] AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, SO_NAM_KHAU_HAO,LOAI_MAY.TEN_LOAI_MAY, [MAY].[SO_NAM_KHAU_HAO]*365+[MAY].[NGAY_DUA_VAO_SD] AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP ,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND  NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, SO_NAM_KHAU_HAO,LOAI_MAY.TEN_LOAI_MAY, [MAY].[SO_NAM_KHAU_HAO]*365+[MAY].[NGAY_DUA_VAO_SD] AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        Cursor = Cursors.Default
    End Sub
    Sub Printpreview3()
        Cursor = Cursors.WaitCursor

        Call Commons.mdShowReport.ReportPreview("reports\rptDanhSachThietBiConKhauHao.rpt")
        Cursor = Cursors.Default
        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_TB_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
    End Sub
    Sub CreateData6()
        Cursor = Cursors.WaitCursor

        RefeshHeaderReport()
        RefeshLanguageReport6()
        Try
            SqlText = "DROP TABLE LD_CP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception

        End Try

        SqlText = "SELECT MS_MAY, NGAY_NHAP,CONVERT(NVARCHAR(100),'') AS MS_N_XUONG, CONVERT(NVARCHAR(100),'') AS MS_BP_CHIU_PHI INTO LD_CP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG ORDER BY MS_MAY , NGAY_NHAP"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "INSERT INTO LD_CP" & Commons.Modules.UserName & "(MS_MAY, NGAY_NHAP, MS_N_XUONG, MS_BP_CHIU_PHI)SELECT MS_MAY, NGAY_NHAP,CONVERT(NVARCHAR(100),'') AS MS_N_XUONG, CONVERT(NVARCHAR(100),'') AS MS_BP_CHIU_PHI FROM MAY_BO_PHAN_CHIU_PHI WHERE (MS_MAY + ''+ CONVERT(NVARCHAR,NGAY_NHAP)) NOT IN (SELECT (MS_MAY + ''+ CONVERT(NVARCHAR,NGAY_NHAP)) FROM LD_CP" & Commons.Modules.UserName & ")"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "UPDATE LD_CP" & Commons.Modules.UserName & " SET LD_CP" & Commons.Modules.UserName & ".MS_N_XUONG = NHA_XUONG.Ten_N_XUONG FROM NHA_XUONG INNER JOIN(LD_CP" & Commons.Modules.UserName & " INNER JOIN MAY_NHA_XUONG ON LD_CP" & Commons.Modules.UserName & ".MS_MAY= MAY_NHA_XUONG.MS_MAY AND LD_CP" & Commons.Modules.UserName & ".NGAY_NHAP= MAY_NHA_XUONG.NGAY_NHAP)ON NHA_XUONG.MS_N_XUONG=MAY_NHA_XUONG.MS_N_XUONG"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "UPDATE LD_CP" & Commons.Modules.UserName & " SET MS_BP_CHIU_PHI = BO_PHAN_CHIU_PHI.TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI INNER JOIN( LD_CP" & Commons.Modules.UserName & " INNER JOIN MAY_BO_PHAN_CHIU_PHI ON LD_CP" & Commons.Modules.UserName & ".MS_MAY= MAY_BO_PHAN_CHIU_PHI.MS_MAY AND LD_CP" & Commons.Modules.UserName & ".NGAY_NHAP= MAY_BO_PHAN_CHIU_PHI.NGAY_NHAP )ON BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI=MAY_BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


        Try
            SqlText = "DROP TABLE dbo.MAY_NHOM_LOAI_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception

        End Try
        'SqlText = "DELETE FROM MAY_NHOM_LOAI_TMP"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlText = "SELECT MAY.MS_MAY, MAY.SO_THE, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY INTO dbo.MAY_NHOM_LOAI_TMP FROM (LOAI_MAY INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY) INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


        Try
            SqlText = "DROP TABLE dbo.MAY_LD_CP_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception

        End Try
        SqlText = "CREATE TABLE dbo.MAY_LD_CP_TMP(   STT  smallint      IDENTITY(1,1)     ,   MS_MAY       Nvarchar(50)     NOT NULL     ,   NGAY_NHAP      DATETIME     NOT NULL     ,   MS_N_XUONG      Nvarchar(50)     NOT NULL         ,   MS_BP_CHIU_PHI     Nvarchar(50)     NOT NULL)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboThietBi.SelectedIndex <> 0 Then
            SqlText = "INSERT dbo.MAY_LD_CP_TMP (MS_MAY,NGAY_NHAP,MS_N_XUONG,MS_BP_CHIU_PHI)select * from LD_CP" & Commons.Modules.UserName & " WHERE (((LD_CP" & Commons.Modules.UserName & ".MS_MAY)=N'" & cboThietBi.SelectedValue & "')) ORDER BY MS_MAY , NGAY_NHAP  "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        End If
        If cboThietBi.SelectedIndex = 0 Then
            SqlText = "INSERT dbo.MAY_LD_CP_TMP (MS_MAY,NGAY_NHAP,MS_N_XUONG,MS_BP_CHIU_PHI)select * from LD_CP" & Commons.Modules.UserName & " ORDER BY MS_MAY , NGAY_NHAP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        End If



        Dim tbl As New DataTable
        Dim tbl1 As New DataTable
        tbl.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LD_CP_TMP"))
        Dim i As Integer
        For i = 0 To tbl.Rows.Count - 1
            tbl1.Clear()
            tbl1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LD_CP_TMP"))
            If i <> 0 Then
                If tbl1.Rows(i - 1).Item("MS_N_XUONG") <> "" Then
                    If tbl1.Rows(i).Item("MS_N_XUONG") = "" Then
                        SqlText = "UPDATE dbo.MAY_LD_CP_TMP SET MS_N_XUONG ='" & tbl1.Rows(i - 1).Item("MS_N_XUONG") & "'WHERE dbo.MAY_LD_CP_TMP.STT='" & tbl1.Rows(i).Item("STT") & "' "
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                    End If
                End If

                If tbl1.Rows(i - 1).Item("MS_BP_CHIU_PHI") <> "" Then
                    If tbl1.Rows(i).Item("MS_BP_CHIU_PHI") = "" Then
                        SqlText = "UPDATE dbo.MAY_LD_CP_TMP SET MS_BP_CHIU_PHI ='" & tbl1.Rows(i - 1).Item("MS_BP_CHIU_PHI") & "'WHERE dbo.MAY_LD_CP_TMP.STT='" & tbl1.Rows(i).Item("STT") & "' "
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                    End If
                End If
            End If




        Next

        Cursor = Cursors.Default
    End Sub
    Sub Printpreview6()
        Cursor = Cursors.WaitCursor

        Call Commons.mdShowReport.ReportPreview("reports\rptDanhSachNoiLapDatVaBPCPCuaThietBi.rpt")
        Cursor = Cursors.Default
        Try
            SqlText = "DROP TABLE dbo.MAY_LD_CP_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception

        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_NOI_LAP_DAT_BPCP_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE LD_CP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE dbo.MAY_NHOM_LOAI_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception

        End Try
    End Sub
    Sub Printpreview5()
        Cursor = Cursors.WaitCursor

        Call Commons.mdShowReport.ReportPreview("reports\rptDanhSachThietBiTrongHeThong.rpt")
        Cursor = Cursors.Default
        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_TB_TRONG_HE_THONG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_TRONG_HE_THONG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Try
            SqlText = "DROP TABLE MAY_HE_THONG" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub
    Sub CreateData5()
        Cursor = Cursors.WaitCursor
        RefeshHeaderReport()
        RefeshLanguageReport5()
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Try
            SqlText = "DROP TABLE MAY_HE_THONG" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE dbo.DANH_SACH_TB_TRONG_HE_THONG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        'SqlText = "DELETE FROM DANH_SACH_TB_TRONG_HE_THONG_TMP"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "SELECT * INTO  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = " SELECT *INTO MAY_HE_THONG" & Commons.Modules.UserName & " FROM MAY_HE_THONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_HE_THONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


        If cboHeThong.SelectedIndex <> 0 Then
            SqlText = "SELECT HE_THONG.TEN_HE_THONG, MAY_HE_THONG" & Commons.Modules.UserName & ".MS_MAY, MAY.SO_THE, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY, NHA_XUONG.Ten_N_XUONG, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX INTO dbo.DANH_SACH_TB_TRONG_HE_THONG_TMP FROM ((LOAI_MAY INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY) INNER JOIN ((MAY INNER JOIN (HE_THONG INNER JOIN MAY_HE_THONG" & Commons.Modules.UserName & " ON HE_THONG.MS_HE_THONG = MAY_HE_THONG" & Commons.Modules.UserName & ".MS_HE_THONG) ON MAY.MS_MAY = MAY_HE_THONG" & Commons.Modules.UserName & ".MS_MAY) INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) INNER JOIN HANG_SAN_XUAT ON MAY.MS_HSX = HANG_SAN_XUAT.MS_HSX GROUP BY HE_THONG.TEN_HE_THONG, MAY_HE_THONG" & Commons.Modules.UserName & ".MS_MAY, MAY.SO_THE, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY, NHA_XUONG.Ten_N_XUONG, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX,HE_THONG.MS_HE_THONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP HAVING HE_THONG.MS_HE_THONG='" & cboHeThong.SelectedValue & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboHeThong.SelectedIndex = 0 Then
            SqlText = "SELECT HE_THONG.TEN_HE_THONG, MAY_HE_THONG" & Commons.Modules.UserName & ".MS_MAY, MAY.SO_THE, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY, NHA_XUONG.Ten_N_XUONG, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX INTO dbo.DANH_SACH_TB_TRONG_HE_THONG_TMP FROM ((LOAI_MAY INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY) INNER JOIN ((MAY INNER JOIN (HE_THONG INNER JOIN MAY_HE_THONG" & Commons.Modules.UserName & " ON HE_THONG.MS_HE_THONG = MAY_HE_THONG" & Commons.Modules.UserName & ".MS_HE_THONG) ON MAY.MS_MAY = MAY_HE_THONG" & Commons.Modules.UserName & ".MS_MAY) INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) INNER JOIN HANG_SAN_XUAT ON MAY.MS_HSX = HANG_SAN_XUAT.MS_HSX GROUP BY HE_THONG.TEN_HE_THONG, MAY_HE_THONG" & Commons.Modules.UserName & ".MS_MAY, MAY.SO_THE, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY, NHA_XUONG.Ten_N_XUONG, MAY.NHIEM_VU_THIET_BI, HANG_SAN_XUAT.TEN_HSX, MAY.NUOC_SX ,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP HAVING  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If

        Cursor = Cursors.Default
    End Sub
    Sub Printpreview7()
        Cursor = Cursors.WaitCursor

        Call Commons.mdShowReport.ReportPreview("reports\rptDanhSachThietBiSuDungPhuTung.rpt") 'rptDanhSachTH_Trong_He_Thong.rpt")
        Cursor = Cursors.Default

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_SU_DUNG_PHU_TUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE dbo.MAY_NHA_XUONG_LOAI_NHOM_TMP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE  dbo.MAY_PHU_TUNG_SO_LUONG_TMP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub
    Sub CreateData7()
        Cursor = Cursors.WaitCursor
        RefeshHeaderReport()
        RefeshLanguageReport7()
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        SqlText = " SELECT * INTO  MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Try
            SqlText = "DROP TABLE dbo.MAY_NHA_XUONG_LOAI_NHOM_TMP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        SqlText = " SELECT MAY.MS_MAY, NHA_XUONG.Ten_N_XUONG, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY INTO dbo.MAY_NHA_XUONG_LOAI_NHOM_TMP  FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN ((NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) INNER JOIN MAY ON MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY = MAY.MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY MAY.MS_MAY, NHA_XUONG.Ten_N_XUONG, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Try
            SqlText = "DROP TABLE  dbo.MAY_PHU_TUNG_SO_LUONG_TMP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        '  Dim dvt As String
        If commons.Modules.TypeLanguage = 0 Then
            ' dvt = "DON_VI_TINH.TEN_1"
            If cboPhuTung.SelectedIndex <> 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 AS TEN  INTO dbo.MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 HAVING (((CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT)='" & cboPhuTung.SelectedValue & "'))"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
            If cboPhuTung.SelectedIndex = 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 AS TEN  INTO dbo.MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
        End If
        If commons.Modules.TypeLanguage = 1 Then
            If cboPhuTung.SelectedIndex <> 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 AS TEN  INTO dbo.MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 HAVING (((CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT)='" & cboPhuTung.SelectedValue & "'))"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
            If cboPhuTung.SelectedIndex = 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_2 AS TEN  INTO dbo.MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_2"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
        End If


        Cursor = Cursors.Default
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        If radDanhsachThietBi.Checked Then
            Call CreateData1()
            Call Printpreview1()
        End If
        If radHetHanBaoHanh.Checked Then
            If txtDenngay.Value < txtTungay.Value Then
                MsgBox("Chon ngay khong hop le")
            Else
                Call CreateData2()
                Call Printpreview2()
            End If
        End If
        If radDanhSachTBConKhauHao.Checked Then
            Call CreateData3()
            Call Printpreview3()
        End If
        If radDachSachTBHetKH.Checked Then
            Call CreateData4()
            Call Printpreview4()
        End If
        If radDanhSachTB_ThuocHT.Checked Then
            Call CreateData5()
            Call Printpreview5()
        End If
        If radDanhSach_LD_BPCP.Checked Then
            Call CreateData6()
            Call Printpreview6()
        End If
        If radDachSach_TB_PT.Checked Then
            Call CreateData7()
            Call Printpreview7()
        End If
    End Sub
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub
    Private Sub radDanhsachThietBi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDanhsachThietBi.CheckedChanged
        If radDanhsachThietBi.Checked Then
            cboLoaiThietBi.Enabled = True
        Else
            cboLoaiThietBi.Enabled = False
        End If
    End Sub
    Private Sub radDanhSachTBConKhauHao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDanhSachTBConKhauHao.CheckedChanged
        If radDanhSachTBConKhauHao.Checked Then
            cboLoaiThietBi.Enabled = True
        Else
            cboLoaiThietBi.Enabled = False
        End If
    End Sub
    Private Sub radDachSachTBHetKH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDachSachTBHetKH.CheckedChanged
        If radDachSachTBHetKH.Checked Then
            cboLoaiThietBi.Enabled = True
        Else
            cboLoaiThietBi.Enabled = False
        End If
    End Sub
    Private Sub radDanhSachTB_ThuocHT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDanhSachTB_ThuocHT.CheckedChanged
        If radDanhSachTB_ThuocHT.Checked Then
            cboHeThong.Enabled = True
        Else
            cboHeThong.Enabled = False
        End If
    End Sub
    Private Sub radHetHanBaoHanh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radHetHanBaoHanh.CheckedChanged
        If radHetHanBaoHanh.Checked Then
            cboLoaiThietBi.Enabled = True
            txtTungay.Enabled = True
            txtDenngay.Enabled = True
        Else
            cboLoaiThietBi.Enabled = False
            txtTungay.Enabled = False
            txtDenngay.Enabled = False
        End If
    End Sub
    Private Sub radDanhSach_LD_BPCP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDanhSach_LD_BPCP.CheckedChanged
        If radDanhSach_LD_BPCP.Checked Then
            cboThietBi.Enabled = True
        Else
            cboThietBi.Enabled = False
        End If
    End Sub
    Private Sub radDachSach_TB_PT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDachSach_TB_PT.CheckedChanged
        If radDachSach_TB_PT.Checked Then
            cboPhuTung.Enabled = True
        Else
            cboPhuTung.Enabled = False
        End If
    End Sub

    Sub check_radCheck(ByVal grp As GroupBox)
        For Each ctrl As Control In grp.Controls
            If ctrl.GetType.Name = "RadioButton" Then
                radCheck(ctrl)
            End If
        Next
    End Sub

    Sub radCheck(ByVal rad As RadioButton)
        rad.Checked = False
    End Sub

    Private Sub radDachSach_TB_PT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDachSach_TB_PT.Click
        check_radCheck(grp1)
        check_radCheck(grp2)
    End Sub

    Private Sub radDanhSach_LD_BPCP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDanhSach_LD_BPCP.Click
        check_radCheck(grp1)
        check_radCheck(grp3)
    End Sub

    Private Sub radHetHanBaoHanh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radHetHanBaoHanh.Click
        check_radCheck(grp3)
        check_radCheck(grp2)
    End Sub

    Private Sub radDanhSachTB_ThuocHT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDanhSachTB_ThuocHT.Click
        check_radCheck(grp3)
        check_radCheck(grp2)
    End Sub

    Private Sub radDachSachTBHetKH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDachSachTBHetKH.Click
        check_radCheck(grp3)
        check_radCheck(grp2)
    End Sub

    Private Sub radDanhSachTBConKhauHao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDanhSachTBConKhauHao.Click
        check_radCheck(grp3)
        check_radCheck(grp2)
    End Sub

    Private Sub radDanhsachThietBi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDanhsachThietBi.Click
        check_radCheck(grp3)
        check_radCheck(grp2)
    End Sub
End Class