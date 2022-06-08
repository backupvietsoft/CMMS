
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptChuKyHieuChuanNoi_Ngoai
    Private SqlText As String = String.Empty

    Private Sub frmrptChuKyHieuChuanNoi_Ngoai_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptDanhSachDHDDaHC")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmrptChuKyHieuChuanNoi_Ngoai_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtNam.Text = Now.Year.ToString
        BinDataLHC()
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If txtNam.Text = "" Then
            MsgBox("Bạn vui lòng nhập năm cần xem ", MsgBoxStyle.Information, "Thông báo ")
            txtNam.Focus()
            Exit Sub
        End If
        If txtNam.Text.Length < 4 Then
            MsgBox("Bạn nhập sai kiểu năm, vui lòng nhập lại ! ", MsgBoxStyle.Information, "Thông báo ")
            txtNam.Focus()
            Exit Sub
        End If
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        ShowrptDanhSachDHDDaHC()
        Me.Cursor = Cursors.Default
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
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS TEN_CTY, THONG_TIN_CHUNG.TEN_NGAN_TIENG_ANH AS TEN_NGAN, " & _
                            " THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI, THONG_TIN_CHUNG.Phone , " & _
                            " THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM,  " & _
                            " THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER,  " & _
                            " THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,  " & _
                            " NGAYIN ='" & TDateFormat(Now) & "', tenngayin='" & ngayanh & "' INTO [dbo].rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, " & _
                            " THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, " & _
                            " THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, " & _
                            " THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , " & _
                            " THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "', " & _
                            " tenngayin='" & ngay & "' INTO [dbo].rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
    End Sub
    Sub ShowrptDanhSachDHDDaHC()

        Commons.Modules.ObjSystems.XoaTable("rptDanhSachDHDDaHC")

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetDanhSachDHDDaHC", txtNam.Text, cboHC.SelectedValue, Commons.Modules.UserName)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) AS TONG FROM rptDanhSachDHDDaHC")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanNoi_Ngoai", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()
        CreaterptTieudeDanhSachDHDDaHC()
        ReportPreview("reports\rptDanhSachDHDDaHC.rpt")
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptDanhSachDHDDaHC")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTieuDeDanhSachDHDDaHC")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTHONG_TIN_CHUNG_TMP")
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.XoaTable("rptDanhSachDHDDaHC")
    End Sub


    Sub CreaterptTieudeDanhSachDHDDaHC()
        Dim str As String = ""
        Try
            RefeshHeaderReport()
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE rptTieuDeDanhSachDHDDaHC")
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "TieuDe_", Commons.Modules.TypeLanguage) & " " & txtNam.Text
        Dim LOAI_MAY As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "LOAI_MAY_", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "TrangIn_", Commons.Modules.TypeLanguage)
        Dim MSMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "MS_MAY_", Commons.Modules.TypeLanguage)
        Dim MS_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "MS_PT_", Commons.Modules.TypeLanguage)
        Dim TEN_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "TEN_PT_", Commons.Modules.TypeLanguage)
        Dim MS_VI_TRI As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "MS_VI_TRI_", Commons.Modules.TypeLanguage)
        Dim NGAY As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "NGAY_", Commons.Modules.TypeLanguage)
        Dim CHU_KY_HC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "CHU_KY_HC_", Commons.Modules.TypeLanguage)
        Dim LOAI_HC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTieuDeDanhSachDHDDaHC", "LOAI_HC_", Commons.Modules.TypeLanguage) & " : " & cboHC.Text


        str = "CREATE TABLE [dbo].rptTieuDeDanhSachDHDDaHC(TypeLanguage int, LOAI_HC NVARCHAR(250), TIEUDE NVARCHAR(100),LOAI_MAY NVARCHAR(30),TRANGIN NVARCHAR(30),MSMAY NVARCHAR(30),MS_PT NVARCHAR(30),TEN_PT NVARCHAR(100),MS_VI_TRI NVARCHAR(30),NGAY NVARCHAR (30),CKHIEUCHUAN NVARCHAR(50)) " & _
              " INSERT INTO [dbo].rptTieuDeDanhSachDHDDaHC(commons.Modules.TypeLanguage,LOAI_HC,TIEUDE,LOAI_MAY,TRANGIN,MSMAY,MS_PT,TEN_PT,MS_VI_TRI,NGAY,CKHIEUCHUAN) VALUES(" & _
              Commons.Modules.TypeLanguage & ",N'" & LOAI_HC & "',N'" & TieuDe & "', N'" & LOAI_MAY & "' , N'" & TrangIn & "',N'" & MSMay & "',N'" & MS_PT & "',N'" & TEN_PT & "',N'" & MS_VI_TRI & "',N'" & NGAY & "',N'" & CHU_KY_HC & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub ShowrptChuKyHieuChuanNoi_Ngoai()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetChuKyHieuChuanNoi_Ngoai", IIf(cboHC.SelectedValue, 1, 0), txtNam.Text)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "Select COUNT(*) AS Tong FROM rptChuKyHieuChuanKeTiepNoi_Ngoai")
        While objReader.Read
            If objReader.Item("Tong") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanNoi_Ngoai", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()
        CreaterptTieudeChuKyHCNoiNgoai()
        ReportPreview("reports\rptChuKyHieuChuanNoi_Ngoai.rpt")
    End Sub
    Sub CreaterptTieudeChuKyHCNoiNgoai()
        Dim str As String = ""
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table rptTieuDeChuKyHCNoiNgoai")
        Catch ex As Exception
        End Try
        Dim TieuDe As String = ""

        If cboHC.SelectedValue = 0 Then
            TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "HCNgoai", Commons.Modules.TypeLanguage)
        End If
        If cboHC.SelectedValue = 1 Then
            TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "HCNoi", Commons.Modules.TypeLanguage)
        End If
        If cboHC.SelectedValue = 2 Then
            TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "KDinh", Commons.Modules.TypeLanguage)
        End If
        If cboHC.SelectedValue = 3 Then
            TieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "KTra", Commons.Modules.TypeLanguage)
        End If

        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "NgayIn", Commons.Modules.TypeLanguage)
        Dim MaPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "MaPT", Commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "TenPT", Commons.Modules.TypeLanguage)
        Dim PartNo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "PartNo", Commons.Modules.TypeLanguage)
        Dim ItemCode As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "ItemCode", Commons.Modules.TypeLanguage)
        Dim DanhGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "DanhGia", Commons.Modules.TypeLanguage)
        Dim NoiSD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "NoiSD", Commons.Modules.TypeLanguage)
        Dim ChuKyHC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "ChuKyHieuChuan", Commons.Modules.TypeLanguage)
        Dim NgayKiemDinh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "NgayKiemDinh", Commons.Modules.TypeLanguage)
        Dim NgayHetHan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "NgayHetHan", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "STT", Commons.Modules.TypeLanguage)
        Dim NhaXuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "NhaXuong", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiepNoi_Ngoai", "ThietBi", Commons.Modules.TypeLanguage)
        TieuDe = TieuDe + " " + txtNam.Text


        str = "Create table [dbo].rptTieuDeChuKyHCNoiNgoai(TypeLanguage int,NgayIn nvarchar(20),TrangIn nvarchar(20),TieuDe nvarchar(255)," & _
        " STT nvarchar(5),MaPT nvarchar(30),TenPT nvarchar(50),PartNo nvarchar(30),ItemCode nvarchar(30), " & _
        "DanhGia nvarchar(20),ChuKyHC nvarchar(30),NgayKiemDinh nvarchar(50),NgayHetHan nvarchar(50),NoiSD nvarchar(20),NhaXuong nvarchar(100),ThietBi nvarchar(100)) " & _
        " Insert into [DBO].rptTieuDeChuKyHCNoiNgoai values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & _
        STT & "',N'" & MaPT & "',N'" & TenPT & "',N'" & PartNo & "',N'" & ItemCode & "',N'" & DanhGia & "',N'" & _
        ChuKyHC & "',N'" & NgayKiemDinh & "',N'" & NgayHetHan & "',N'" & NoiSD & "',N'" & NhaXuong & "',N'" & ThietBi & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub BinDataLHC()
        Dim TbLHC As New DataTable
        Dim Sql As String
        Sql = " SELECT MS_LOAI_HIEU_CHUAN AS MS, TEN_LOAI_HIEU_CHUAN AS TEN FROM LOAI_HIEU_CHUAN ORDER BY MS_LOAI_HIEU_CHUAN "
        TbLHC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql))
        cboHC.DataSource = TbLHC
        cboHC.ValueMember = "MS"
        cboHC.DisplayMember = "TEN"
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
