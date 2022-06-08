Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDanhSachThietBiSuDungPhuTung
    Private SqlText As String = String.Empty
    Private Sub frmrptDanhSachThietBiSuDungPhuTung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPhutung()
    End Sub
    Sub LoadPhutung()
        Dim s As String
        s = ""
        Try

            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNG1", Commons.Modules.UserName))
            'Try

            '    For Each row As DataRow In dt.Rows
            '        row("TEN_MA") = row("MS_PT") + " - " + row("TEN_MA")
            '    Next
            'Catch ex As Exception

            'End Try
            'Dim i As Integer
            'i = s.Length()

            Dim dtRow As DataRow
            dtRow = dt.NewRow
            dtRow("MS_PT") = -1
            dtRow("TEN_MA") = " < ALL > "
            dtRow("TEN_PT") = " < ALL > "
            dt.Rows.InsertAt(dtRow, 0)
            cboPhuTung.DataSource = dt
            cboPhuTung.ValueMember = "MS_PT"
            cboPhuTung.DisplayMember = "TEN_MA"
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim str As String = Convert.ToString(cboPhuTung.SelectedValue)
        If (String.IsNullOrEmpty(str)) Then
            cboPhuTung.Focus()
            Exit Sub
        End If
        Commons.clsXuLy.CreateTitleReport()
        Call CreateData7()
        Call Printpreview7()
    End Sub

    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
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

    Sub CreateData7()
        Cursor = Cursors.WaitCursor
        RefeshHeaderReport()
        RefeshLanguageReport7()
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = " SELECT * INTO  [dbo].MAY_NHA_XUONG_TMP FROM MAY_NHA_XUONG WHERE NGAY_NHAP IN (SELECT MAX(NGAY_NHAP)AS NGAY_NHAP FROM MAY_NHA_XUONG GROUP BY MS_MAY)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Try
            SqlText = "DROP TABLE dbo.MAY_NHA_XUONG_LOAI_NHOM_TMP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = " SELECT MAY.MS_MAY, NHA_XUONG.Ten_N_XUONG, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY INTO [dbo].MAY_NHA_XUONG_LOAI_NHOM_TMP  FROM LOAI_MAY INNER JOIN (NHOM_MAY INNER JOIN ((NHA_XUONG INNER JOIN MAY_NHA_XUONG_TMP ON NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG_TMP.MS_N_XUONG) INNER JOIN MAY ON MAY_NHA_XUONG_TMP.MS_MAY = MAY.MS_MAY) ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY) ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY GROUP BY MAY.MS_MAY, NHA_XUONG.Ten_N_XUONG, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Try
            SqlText = "DROP TABLE  dbo.MAY_PHU_TUNG_SO_LUONG_TMP "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        If Commons.Modules.TypeLanguage = 0 Then
            If cboPhuTung.SelectedIndex <> 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 AS TEN  INTO [dbo].MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 HAVING (((CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT)='" & cboPhuTung.SelectedValue & "'))"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
            If cboPhuTung.SelectedIndex = 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 AS TEN  INTO [dbo].MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
        End If
        If Commons.Modules.TypeLanguage = 1 Then
            If cboPhuTung.SelectedIndex <> 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 AS TEN  INTO [dbo].MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_1 HAVING (((CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT)='" & cboPhuTung.SelectedValue & "'))"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
            If cboPhuTung.SelectedIndex = 0 Then
                SqlText = "SELECT CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, Sum(CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS SO_LUONG, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_2 AS TEN  INTO [dbo].MAY_PHU_TUNG_SO_LUONG_TMP  FROM (IC_PHU_TUNG INNER JOIN (CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN MAY ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY.MS_MAY) ON IC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT) INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT GROUP BY CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, MAY.MS_NHOM_MAY, DON_VI_TINH.TEN_2"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub Printpreview7()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM MAY_PHU_TUNG_SO_LUONG_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        WriteXml()
        'Call ReportPreview("reports\rptDanhSachThietBiSuDungPhuTung.rpt") 'rptDanhSachTH_Trong_He_Thong.rpt")
        Cursor = Cursors.Default
KetThuc:
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
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP"
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
    Public Sub WriteXml()
        Dim frmShow As frmXMLReport = New frmXMLReport()
        Dim ds As New DataSet
        Dim da As SqlDataAdapter
        ' Lay tieu de
        Dim sql As String
        Try
            Dim dt As New DataTable
            sql = "Select * From dbo.rptTHONG_TIN_CHUNG"
            da = New SqlDataAdapter(sql, Commons.IConnections.ConnectionString)
            dt.TableName = "rptTHONG_TIN_CHUNG_TMP"
            da.Fill(dt)
            'ds.Tables.Add(dt)

            frmShow.AddDataTableSource(dt)
            ' Lay tieu de tu frmDanhSachPhieuXuat
        Catch ex As Exception
        End Try
        'Dim dt As New DataTable

        Try
            'CreateTitleObjectReport()
            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DSPT_SUDUNG_TB"))
            dt.TableName = "rptDSTBSDPT"
            'ds.Tables.Add(dt)
            frmShow.AddDataTableSource(dt)
        Catch ex As Exception

        End Try
        Try
            'CreateTitleObjectReport()
            Dim dt As New DataTable
            sql = "Select * From rptDANH_SACH_THIET_BI_SU_DUNG_PHU_TUNG_TMP"
            dt.TableName = "rptDANH_SACH_THIET_BI_SU_DUNG_PHU_TUNG_TMP"
            da = New SqlDataAdapter(sql, Commons.IConnections.ConnectionString)
            da.Fill(dt)
            'ds.Tables.Add(dt)
            frmShow.AddDataTableSource(dt)
        Catch ex As Exception

        End Try
        sql = "select private from THONG_TIN_CHUNG"
        Dim condition As String = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        If condition = "HUDA" Then
            frmShow.rptName = "rptDanhSachThietBiSuDungPhuTung_Huda"
        Else
            frmShow.rptName = "rptDanhSachThietBiSuDungPhuTung"
        End If

        frmShow.ShowDialog()

        'frmReportPhieuNhap.danhSach = ds
        'dsTable = ds
        'ds.WriteXml("XML\PhieuNhapKho.xml", XmlWriteMode.WriteSchema)
    End Sub
    Private Sub RefeshLanguageReport7()
        Dim danhsachthietbisungphutung, msphutung, tenphutung, partNo, quyCach, msCongty, dvt As String
        Dim tennhaxuong, tenloaimay, stt, maso, nhomthietbi, soluong, trang As String

        danhsachthietbisungphutung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "danhsachthietbisungphutung", Commons.Modules.TypeLanguage)
        msphutung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "msphutung", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "maso", Commons.Modules.TypeLanguage)
        tenphutung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "tenphutung", Commons.Modules.TypeLanguage)
        nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "nhomthietbi", Commons.Modules.TypeLanguage)
        partNo = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "partNo", Commons.Modules.TypeLanguage)
        quyCach = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "quyCach", Commons.Modules.TypeLanguage)
        msCongty = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "msCongty", Commons.Modules.TypeLanguage)
        dvt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "dvt", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "trang", Commons.Modules.TypeLanguage)
        soluong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiSuDungPhuTung", "soluong", Commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_THIET_BI_SU_DUNG_PHU_TUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "CREATE TABLE dbo.rptDANH_SACH_THIET_BI_SU_DUNG_PHU_TUNG_TMP (   DANH_SACH_THIET_BI_SU_DUNG_PT_  nvarchar(250),     MS_PHU_TUNG_ nvarchar(250),TEN_NHA_XUONG_ nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),TEN_PHU_TUNG_ nvarchar(250),NHOM_THIET_BI_ nvarchar(250),PART_No_ nvarchar(250),quyCach nvarchar(255),MS_CTY_ nvarchar(250),DVT_ nvarchar(250),SO_LUONG_ nvarchar(250),TRANG_ nvarchar(250)    )"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanhSachThietBiSuDungPhuTung", danhsachthietbisungphutung, msphutung, tennhaxuong, tenloaimay, stt, maso, tenphutung, nhomthietbi, partNo, quyCach, msCongty, dvt, soluong, trang)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.ParentForm.Close()
    End Sub
End Class
