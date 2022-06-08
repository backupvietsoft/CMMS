
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDanhSachThietBiDaHC
    Private SqlText As String = String.Empty
    Private Sub frmrptDanhSachThietBiDaHC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtNam.Text = Now.Year.ToString()
        Load_LoaiHieuChuan()
    End Sub
    Sub Load_LoaiHieuChuan()
        'H_GET_NHA_XUONG_LOAI_MAY
        cbHieuChuan.Value = "MS_LOAI_HIEU_CHUAN"
        cbHieuChuan.Display = "TEN_LOAI_HIEU_CHUAN"
        cbHieuChuan.StoreName = "H_GET_LOAI_HIEU_CHUANs"


        cbHieuChuan.BindDataSource()
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim LoaiHieuChuan As String = ""
        Try
            LoaiHieuChuan = cbHieuChuan.SelectedValue
        Catch ex As Exception

        End Try
        If LoaiHieuChuan = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "MsgChonHieuChuan", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical)
            cbHieuChuan.Focus()
            Exit Sub
        End If
        If txtNam.Text <> "" And txtNam.Text.Length = 4 Then
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Commons.clsXuLy.CreateTitleReport()
            ShowrptDanhSachThietBiDaHC()
            Me.Cursor = Cursors.Default
        Else
            MsgBox("Năm cần in báo cáo không hợp lệ !", MsgBoxStyle.Critical, "Thông báo")
            txtNam.Focus()
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
    Private Sub RefeshHeaderReport()
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

    Sub ShowrptDanhSachThietBiDaHC()

        Commons.Modules.ObjSystems.XoaTable("rptDanhSachThietBiDaHC")

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetDanhSachThietBiDaHC", txtNam.Text, cbHieuChuan.SelectedValue, Commons.Modules.UserName)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) AS TONG FROM rptDanhSachThietBiDaHC")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()
        CreaterptTieudeDanhSachThietBiDaHC()
        ReportPreview("reports\rptDanhSachThietBiDaHC.rpt")
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptDanhSachThietBiDaHC")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTieuDeDanhSachThietBiDaHC")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTHONG_TIN_CHUNG_TMP")
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.XoaTable("rptDanhSachThietBiDaHC")
    End Sub

    Sub CreaterptTieudeDanhSachThietBiDaHC()
        Dim str As String = ""
        Try
            RefeshHeaderReport()
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTieuDeDanhSachThietBiDaHC")
        Catch ex As Exception
        End Try
        Dim LoaiHieuChuan As Integer
        Dim TieuDe As String = ""
        LoaiHieuChuan = cbHieuChuan.SelectedValue
        Select Case LoaiHieuChuan
            Case -1
                TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TieuDe", Commons.Modules.TypeLanguage) & " " & txtNam.Text
            Case 1
                TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TieuDe1", Commons.Modules.TypeLanguage) & " " & txtNam.Text
            Case 2
                TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TieuDe2", Commons.Modules.TypeLanguage) & " " & txtNam.Text
            Case 3
                TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TieuDe3", Commons.Modules.TypeLanguage) & " " & txtNam.Text
        End Select
        'Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TieuDe", Commons.Modules.TypeLanguage) & " " & txtNam.Text
        'Dim TieuDe1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TieuDe1", Commons.Modules.TypeLanguage) & " " & txtNam.Text
        'Dim TieuDe2 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TieuDe2", Commons.Modules.TypeLanguage) & " " & txtNam.Text
        'Dim TieuDe3 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TieuDe3", Commons.Modules.TypeLanguage) & " " & txtNam.Text

        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "TrangIn", Commons.Modules.TypeLanguage)
        Dim MSMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "MSMay", Commons.Modules.TypeLanguage)
        Dim NhomMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "NhomMay", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "SoThe", Commons.Modules.TypeLanguage)
        Dim NgayHCCuoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "NgayHCCuoi", Commons.Modules.TypeLanguage)
        Dim CKHieuChuan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "CKHieuChuan", Commons.Modules.TypeLanguage)
        Dim NgayHCKe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "NgayHCKe", Commons.Modules.TypeLanguage)
        Dim NhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "NhaXuong", Commons.Modules.TypeLanguage)
        Dim CoQuanThucHien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "CoQuanThucHien", Commons.Modules.TypeLanguage)
        Dim GiayChungNhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachThietBiDaHC", "GiayChungNhan", Commons.Modules.TypeLanguage)

        str = "CREATE TABLE [dbo].rptTieuDeDanhSachThietBiDaHC(TypeLanguage int, TIEUDE NVARCHAR(100),NGAYIN NVARCHAR(30),TRANGIN NVARCHAR(30),MSMAY NVARCHAR(30),NHOMMAY NVARCHAR(30),SOTHE NVARCHAR(30),NGAYHCCUOI NVARCHAR(50),CKHIEUCHUAN NVARCHAR(50),NGAYHCKE NVARCHAR(50),NHAXUONG NVARCHAR(30),GiayChungNhan nvarchar(255) , CoQuanThucHien nvarchar(255) ) " & _
              " INSERT INTO [dbo].rptTieuDeDanhSachThietBiDaHC(commons.Modules.TypeLanguage,TIEUDE,NGAYIN,TRANGIN,MSMAY,NHOMMAY,SOTHE,NGAYHCCUOI,CKHIEUCHUAN,NGAYHCKE,NHAXUONG) VALUES(" & _
              Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & MSMay & "',N'" & NhomMay & "',N'" & SoThe & "',N'" & NgayHCCuoi & "',N'" & CKHieuChuan & "',N'" & NgayHCKe & "',N'" & NhaXuong & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
