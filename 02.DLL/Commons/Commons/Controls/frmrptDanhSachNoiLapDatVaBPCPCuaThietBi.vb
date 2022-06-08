
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDanhSachNoiLapDatVaBPCPCuaThietBi
    Private SqlText As String = String.Empty
    Private Sub frmrptDanhSachNoiLapDatVaBPCPCuaThietBi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadThietbi()
    End Sub

    Sub LoadThietbi()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHIET_BIs", Commons.Modules.UserName))
        Dim dtRow As DataRow
        dtRow = dt.NewRow
        dtRow("MS_MAY") = -1
        dtRow("MS_MAY") = " < ALL > "
        dt.Rows.InsertAt(dtRow, 0)
        cboThietBi.DataSource = dt
        cboThietBi.ValueMember = "MS_MAY"
        cboThietBi.DisplayMember = "MS_MAY"
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
    Sub CreateData6()
        Cursor = Cursors.WaitCursor

        RefeshHeaderReport()
        RefeshLanguageReport6()
        Try
            SqlText = "DROP TABLE LD_CP" & Commons.Modules.UserName & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception

        End Try

        SqlText = "SELECT MS_MAY, NGAY_NHAP,CONVERT(NVARCHAR(100),'') AS MS_N_XUONG, CONVERT(NVARCHAR(100),'') AS MS_BP_CHIU_PHI INTO [DBO].LD_CP" & Commons.Modules.UserName & " FROM MAY_NHA_XUONG ORDER BY MS_MAY , NGAY_NHAP"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "INSERT INTO [DBO].LD_CP" & Commons.Modules.UserName & "(MS_MAY, NGAY_NHAP, MS_N_XUONG, MS_BP_CHIU_PHI)SELECT MS_MAY, NGAY_NHAP,CONVERT(NVARCHAR(100),'') AS MS_N_XUONG, CONVERT(NVARCHAR(100),'') AS MS_BP_CHIU_PHI FROM MAY_BO_PHAN_CHIU_PHI WHERE (MS_MAY + ''+ CONVERT(NVARCHAR,NGAY_NHAP)) NOT IN (SELECT (MS_MAY + ''+ CONVERT(NVARCHAR,NGAY_NHAP)) FROM LD_CP" & Commons.Modules.UserName & ")"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "UPDATE [DBO].LD_CP" & Commons.Modules.UserName & " SET MS_N_XUONG = NHA_XUONG.Ten_N_XUONG FROM NHA_XUONG INNER JOIN(LD_CP" & Commons.Modules.UserName & " INNER JOIN MAY_NHA_XUONG ON LD_CP" & Commons.Modules.UserName & ".MS_MAY= MAY_NHA_XUONG.MS_MAY AND LD_CP" & Commons.Modules.UserName & ".NGAY_NHAP= MAY_NHA_XUONG.NGAY_NHAP)ON NHA_XUONG.MS_N_XUONG=MAY_NHA_XUONG.MS_N_XUONG"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "UPDATE [DBO].LD_CP" & Commons.Modules.UserName & " SET MS_BP_CHIU_PHI = BO_PHAN_CHIU_PHI.TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI INNER JOIN( LD_CP" & Commons.Modules.UserName & " INNER JOIN MAY_BO_PHAN_CHIU_PHI ON LD_CP" & Commons.Modules.UserName & ".MS_MAY= MAY_BO_PHAN_CHIU_PHI.MS_MAY AND LD_CP" & Commons.Modules.UserName & ".NGAY_NHAP= MAY_BO_PHAN_CHIU_PHI.NGAY_NHAP )ON BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI=MAY_BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Try
            SqlText = "DROP TABLE dbo.MAY_NHOM_LOAI_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        SqlText = "SELECT MAY.MS_MAY, MAY.SO_THE, LOAI_MAY.TEN_LOAI_MAY, NHOM_MAY.TEN_NHOM_MAY INTO [dbo].MAY_NHOM_LOAI_TMP FROM (LOAI_MAY INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY) INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Try
            SqlText = "DROP TABLE dbo.MAY_LD_CP_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.MAY_LD_CP_TMP(   STT  smallint      IDENTITY(1,1)     ,   MS_MAY       Nvarchar(50)     NOT NULL     ,   NGAY_NHAP      DATETIME     NOT NULL     ,   MS_N_XUONG      Nvarchar(50)     NOT NULL         ,   MS_BP_CHIU_PHI     Nvarchar(50)     NOT NULL)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        If cboThietBi.SelectedIndex <> 0 Then
            SqlText = "INSERT dbo.MAY_LD_CP_TMP (MS_MAY,NGAY_NHAP,MS_N_XUONG,MS_BP_CHIU_PHI)select * from LD_CP" & Commons.Modules.UserName & " WHERE (((LD_CP" & Commons.Modules.UserName & ".MS_MAY)='" & cboThietBi.SelectedValue & "')) ORDER BY MS_MAY , NGAY_NHAP  "
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
                        SqlText = "UPDATE dbo.MAY_LD_CP_TMP SET MS_N_XUONG =N'" & tbl1.Rows(i - 1).Item("MS_N_XUONG") & "'WHERE dbo.MAY_LD_CP_TMP.STT='" & tbl1.Rows(i).Item("STT") & "' "
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                    End If
                End If

                If tbl1.Rows(i - 1).Item("MS_BP_CHIU_PHI") <> "" Then
                    If tbl1.Rows(i).Item("MS_BP_CHIU_PHI") = "" Then
                        SqlText = "UPDATE dbo.MAY_LD_CP_TMP SET MS_BP_CHIU_PHI =N'" & tbl1.Rows(i - 1).Item("MS_BP_CHIU_PHI") & "'WHERE dbo.MAY_LD_CP_TMP.STT='" & tbl1.Rows(i).Item("STT") & "' "
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
                    End If
                End If
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Sub Printpreview6()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM MAY_NHOM_LOAI_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        Call ReportPreview("reports\rptDanhSachNoiLapDatVaBPCPCuaThietBi.rpt")
        Cursor = Cursors.Default
KetThuc:
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

    Private Sub RefeshLanguageReport6()
        Dim danhsachnoilapdat, ngaynhap, bophanchiuphi As String
        Dim tennhaxuong, tenloaimay, stt, maso, nhomthietbi, trang, sothe As String

        danhsachnoilapdat = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "danhsachnoilapdat", Commons.Modules.TypeLanguage)
        ngaynhap = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "ngaynhap", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "maso", Commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "sothe", Commons.Modules.TypeLanguage)
        bophanchiuphi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "bophanchiuphi", Commons.Modules.TypeLanguage)
        nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "nhomthietbi", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachNoiLapDatVaBPCPCuaThietBi", "trang", Commons.Modules.TypeLanguage)

        Try
            SqlText = "DROP TABLE dbo.rptDANH_SACH_NOI_LAP_DAT_BPCP_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDANH_SACH_NOI_LAP_DAT_BPCP_TMP(   DANH_SACH_NOI_LAP_DAT_  nvarchar(250),     NGAY_NHAP_ nvarchar(250),TEN_NHA_XUONG_  nvarchar(250),TEN_LOAI_MAY_ nvarchar(250),STT_ nvarchar(250),MA_SO_ nvarchar(250),SO_THE_ nvarchar(250),BO_PHAN_CHIU_PHI_ nvarchar(250),NHOM_THIET_BI_ nvarchar(250),TRANG_ nvarchar(250))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "rptDanh_SachThietBiTrongHeThong", danhsachnoilapdat, ngaynhap, tennhaxuong, tenloaimay, stt, maso, sothe, bophanchiuphi, nhomthietbi, trang)
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
