
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDanhSachThietBiConKhauHao
    Private SqlText As String = String.Empty

    Private Sub frmrptDanhSachThietBiConKhauHao_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
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
    Private Sub frmrptDanhSachThietBiConKhauHao_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadLoaiTB()
        LoadNhaxuong()
    End Sub

    Sub LoadLoaiTB()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_Loai_TB", Commons.Modules.UserName))
        Dim dtRow As DataRow
        dtRow = dt.NewRow
        dtRow("MS_LOAI_MAY") = -1
        dtRow("TEN_LOAI_MAY") = " < ALL > "
        dt.Rows.InsertAt(dtRow, 0)
        cboLoaiThietBi.DataSource = dt
        cboLoaiThietBi.ValueMember = "MS_LOAI_MAY"
        cboLoaiThietBi.DisplayMember = "TEN_LOAI_MAY"
    End Sub
    Sub LoadNhaxuong()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHA_XUONGs1", Commons.Modules.UserName))
        Dim dtRow As DataRow
        dtRow = dt.NewRow
        dtRow("MS_N_XUONG") = -1
        dtRow("Ten_N_XUONG") = " < ALL > "
        dt.Rows.InsertAt(dtRow, 0)
        cboNhaxuong.DataSource = dt
        cboNhaxuong.ValueMember = "MS_N_XUONG"
        cboNhaxuong.DisplayMember = "Ten_N_XUONG"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Commons.clsXuLy.CreateTitleReport()
        Call CreateData3()
        Call Printpreview3()
    End Sub

    Sub RefeshHeaderReport()
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
        SqlText = "SELECT * INTO  [dbo].MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD,SO_NAM_KHAU_HAO, LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,GIA_MUA ,SO_NAM_KHAU_HAO HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex = 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = "SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD,SO_NAM_KHAU_HAO, LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex = 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, SO_NAM_KHAU_HAO,LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP ,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND  NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If cboNhaxuong.SelectedIndex <> 0 And cboLoaiThietBi.SelectedIndex <> 0 Then
            SqlText = " SELECT NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, SO_NAM_KHAU_HAO,LOAI_MAY.TEN_LOAI_MAY, DATEADD(YEAR,[MAY].[SO_NAM_KHAU_HAO],[MAY].[NGAY_DUA_VAO_SD]) AS NGAY_HET_KHAU_HAO,NGOAI_TE,GIA_MUA INTO [dbo].DANH_SACH_TB_CON_KHAU_HAO_TMP FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN (MAY INNER JOIN (NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & " ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_N_XUONG) ON MAY.MS_MAY = MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY NHA_XUONG.Ten_N_XUONG, MAY.MS_MAY, MAY.SO_THE, NHOM_MAY.TEN_NHOM_MAY, MAY.NGAY_DUA_VAO_SD, LOAI_MAY.TEN_LOAI_MAY,[MAY].[SO_NAM_KHAU_HAO], [MAY].[NGAY_DUA_VAO_SD],[MAY].[SO_NAM_KHAU_HAO]+[MAY].[NGAY_DUA_VAO_SD],LOAI_MAY.MS_LOAI_MAY,NHA_XUONG.MS_N_XUONG,MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP,NGOAI_TE,SO_NAM_KHAU_HAO,GIA_MUA HAVING  (([MAY].[SO_NAM_KHAU_HAO]*365)+[MAY].[NGAY_DUA_VAO_SD])>='" & TDateFormat(Now) & "' AND MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ".NGAY_NHAP<='" & TDateFormat(Now) & "'AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi.SelectedValue & "'AND NHA_XUONG.MS_N_XUONG='" & cboNhaxuong.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Sub Printpreview3()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM DANH_SACH_TB_CON_KHAU_HAO_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        'Call ReportPreview("reports\rptDanhSachThietBiConKhauHao.rpt")




        ''''
        Dim frmRepot As frmXMLReport = New frmXMLReport()


        frmRepot.rptName = "rptDanhSachThietBiConKhauHao"


        Dim vtbData As New DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP"))
        vtbData.TableName = "rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP"
        Dim vtbTitle As New DataTable()
        vtbTitle.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM DANH_SACH_TB_CON_KHAU_HAO_TMP"))
        vtbTitle.TableName = "DANH_SACH_TB_CON_KHAU_HAO_TMP"

        frmRepot.AddDataTableSource(vtbData)
        frmRepot.AddDataTableSource(vtbTitle)
        frmRepot.ShowDialog()

KetThuc:  ''''''
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

        Cursor = Cursors.Default

    End Sub

    Private Sub RefeshLanguageReport3()
        Dim danhsachthietbiconkhauhao, tennhaxuong, tenloaimay, stt, maso, ngayhetkh As String
        Dim sothe, tennhommay, ngaysudung, sonamkhauhao, gtconlai, tiente, trang As String

        danhsachthietbiconkhauhao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "danhsachthietbiconkhauhao", Commons.Modules.TypeLanguage)
        ngaysudung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "ngaysudung", Commons.Modules.TypeLanguage)
        sonamkhauhao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "sonamkhauhao", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", " stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "maso", Commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "sothe", Commons.Modules.TypeLanguage)
        tennhommay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tennhommay", Commons.Modules.TypeLanguage)
        gtconlai = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", " gtconlai", Commons.Modules.TypeLanguage)
        ngayhetkh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", " ngayhetkh", Commons.Modules.TypeLanguage)

        tiente = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "tiente", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiConKhauHao", "trang", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_CON_KHAU_HAO_TMP (   DANH_SACH_THIET_BI_CON_KHAU_HAO_  nvarchar(250),     NGAY_SU_DUNG_ nvarchar(250),SO_NAM_KHAU_HAO_  nvarchar(250),TEN_NHA_XUONG_ nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),TEN_NHOM_MAY_ nvarchar(250),GT_CON_LAI_ nvarchar(250),TIEN_TE_ nvarchar(250),TRANG_ nvarchar(250),NGAY_HET_KH nvarchar(250))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanhSachThietBiConKhauHao", danhsachthietbiconkhauhao, ngaysudung, sonamkhauhao, tennhaxuong, tenloaimay, stt, maso, sothe, tennhommay, gtconlai, tiente, trang, ngayhetkh)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
