Imports Microsoft.ApplicationBlocks.Data
Imports System.Globalization

Public Class frmrptDanhsach_NCC
    Private SqlText As String = String.Empty
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Commons.clsXuLy.CreateTitleReport()
        Call Print_preview1()
    End Sub

    Sub Bind_cboLoaiTB()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_MAY", Commons.Modules.UserName))
        cboLoaiTB.DataSource = dt
        cboLoaiTB.DisplayMember = "TEN_LOAI_MAY"
        cboLoaiTB.ValueMember = "MS_LOAI_MAY"
        If cboLoaiTB.Items.Count = 0 Then
            cboLoaiTB.Text = ""
        End If
    End Sub
    Sub Bind_cboNoisudung()

        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_PT", Commons.Modules.UserName))
        cboNoisudung.DataSource = dt
        cboNoisudung.DisplayMember = "TEN_LOAI_PT"
        cboNoisudung.ValueMember = "MS_LOAI_PT"
    End Sub
    'Sub Bind_cboLoaiCV()
    '    cboLoaiCV.Display = "TEN_LOAI_CV"
    '    cboLoaiCV.Value = "MS_LOAI_CV"
    '    cboLoaiCV.DropDownWidth = 200
    '    cboLoaiCV.Param = Commons.Modules.UserName
    '    cboLoaiCV.StoreName = "PermisionLOAI_CV"
    '    cboLoaiCV.BindDataSource()

    '    cboLoai_CV.Display = "TEN_LOAI_CV"
    '    cboLoai_CV.Value = "MS_LOAI_CV"
    '    cboLoai_CV.DropDownWidth = 200
    '    cboLoai_CV.Param = Commons.Modules.UserName
    '    cboLoai_CV.StoreName = "PermisionLOAI_CV"
    '    cboLoai_CV.BindDataSource()

    'End Sub

    Private Sub frmrptDanhsach_NCC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Bind_cboLoaiTB()
        Bind_cboNoisudung()
    End Sub

    Sub Print_preview1()
        Dim frm As New frmXMLReport
        Dim dtTmp As New DataTable
        dtTmp = RefeshHeaderReport()
        dtTmp.TableName = "rptTHONG_TIN_CHUNG_TMP"
        frm.AddDataTableSource(dtTmp)
        dtTmp = New DataTable
        dtTmp = Refesh_LanguageReport1()
        frm.AddDataTableSource(dtTmp)

        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM KHACH_HANG ORDER BY TEN_CONG_TY"))
        dtTmp.TableName = "KHACH_HANG"
        frm.AddDataTableSource(dtTmp)
        frm.rptName = "rptDanhsach_NCC"
        frm.ShowDialog()
    End Sub
    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function

    Function RefeshHeaderReport() As DataTable
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        'Try
        '    SqlText = "DROP TABLE rptTHONG_TIN_CHUNG_TMP"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        'Catch ex As Exception
        'End Try
        Dim dtTmp = New DataTable
        Try

            If Commons.Modules.TypeLanguage = 1 Then
                SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS TEN_CTY, THONG_TIN_CHUNG.TEN_NGAN_TIENG_ANH AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, " & _
                                " THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, " & _
                                " THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, " & _
                                " THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , " & _
                                " THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "'," & _
                                " tenngayin='" & ngayanh & "' FROM THONG_TIN_CHUNG"
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
            End If
            If Commons.Modules.TypeLanguage = 0 Then
                SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, " & _
                                " THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, " & _
                                " THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, " & _
                                " THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , " & _
                                " THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "'," & _
                                " tenngayin='" & ngay & "' FROM THONG_TIN_CHUNG "
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
            End If
        Catch ex As Exception

        End Try
        dtTmp.TableName = "rptTHONG_TIN_CHUNG_TMP"
        Return dtTmp
    End Function

    Function Refesh_LanguageReport1() As DataTable
        Dim dtTmp = New DataTable
        Try

            Dim tieude, stt, tenkhachhang, diachi, dienthoai, fax, nguoidaidien, trang, ngayin As String
            tieude = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "tieude", Commons.Modules.TypeLanguage)
            stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "stt", Commons.Modules.TypeLanguage)
            tenkhachhang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "tenkhachhang", Commons.Modules.TypeLanguage)
            diachi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "diachi", Commons.Modules.TypeLanguage)
            dienthoai = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "dienthoai", Commons.Modules.TypeLanguage)
            fax = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "fax", Commons.Modules.TypeLanguage)
            nguoidaidien = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "nguoidaidien", Commons.Modules.TypeLanguage)
            trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_NCC", "MsNCC", Commons.Modules.TypeLanguage)
            If Commons.Modules.TypeLanguage = 0 Then
                ngayin = "Ngày in: "
            Else
                ngayin = "Date print: "
            End If
            Try
                SqlText = "DROP TABLE dbo.rptDANH_SACH_NCC_TMP"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            Catch ex As Exception
            End Try
            SqlText = "CREATE TABLE dbo.rptDANH_SACH_NCC_TMP (TIEUDE_  nvarchar(250), STT_ nvarchar(20)," & _
                    "TEN_KHACH_HANG_ NVARCHAR(250),DIA_CHI_ NVARCHAR(250),DIEN_THOAI_ NVARCHAR(20)," & _
                    "FAX_ NVARCHAR(20),NGUOI_DAI_DIEN_ NVARCHAR(50),TRANG_ nvarchar(20),NGAY_IN_ NVARCHAR(20))"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDANH_SACH_NCC_TMP", tieude, stt, tenkhachhang, diachi, dienthoai, fax, nguoidaidien, trang, ngayin)

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptDANH_SACH_NCC_TMP"))

            Commons.Modules.ObjSystems.XoaTable("rptDANH_SACH_NCC_TMP")
        Catch ex As Exception

        End Try
        dtTmp.TableName = "rptDANH_SACH_NCC_TMP"
        Return dtTmp
    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
