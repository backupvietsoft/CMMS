Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptThoiGianChayMayCuoiTuan
    Private SqlText As String = String.Empty
    Private Sub frmrptThoiGianChayMayCuoiTuan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Bind_cboLoaithietbi2()
        Bind_daychuyen()
        dtpTuNgayCuoiTuan.Value = CDate("1/" & Now.Month.ToString & "/" & Now.Year.ToString)
        dtpDenNgayCuoiTuan.Value = DateTime.Now
    End Sub
    Sub Bind_cboLoaithietbi2()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_MAY", Commons.Modules.UserName))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        row(2) = Commons.Modules.UserName
        dt.Rows.InsertAt(row, 0)
        cboLoaithietbi2.DataSource = dt
        cboLoaithietbi2.DisplayMember = "TEN_LOAI_MAY"
        cboLoaithietbi2.ValueMember = "MS_LOAI_MAY"
        If cboLoaithietbi2.Items.Count = 0 Then
            cboLoaithietbi2.Text = ""
        End If
    End Sub

    Sub Bind_daychuyen()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDAY_CHUYEN", Commons.Modules.UserName))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        dt.Rows.InsertAt(row, 0)
        cboDayChuyenCuoiTuan.DataSource = dt
        cboDayChuyenCuoiTuan.ValueMember = "MS_HE_THONG"
        cboDayChuyenCuoiTuan.DisplayMember = "TEN_HE_THONG"
    End Sub

    Private Sub btnTheoDayChuyen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTheoDayChuyen.Click
        Dim SqlText As String = ""
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Commons.clsXuLy.CreateTitleReport()
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_DC"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "SELECT DISTINCT [dbo].MAY_HE_THONG.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG, TG.MS_MAY, dbo.DON_VI_TINH_RUN_TIME.TEN_DVT_RT, TG.NGAY, TG.CHI_SO_DONG_HO, TG.SO_MOVEMENT, TG.MS_PBT " & _
                  "INTO [dbo].rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_DC " & _
                  "FROM dbo.THOI_GIAN_CHAY_MAY TG INNER JOIN dbo.MAY ON dbo.MAY.MS_MAY = TG.MS_MAY INNER JOIN dbo.DON_VI_TINH_RUN_TIME ON dbo.MAY.MS_DVT_RT = dbo.DON_VI_TINH_RUN_TIME.MS_DVT_RT INNER JOIN " & _
                       "dbo.MAY_HE_THONG ON TG.MS_MAY = dbo.MAY_HE_THONG.MS_MAY INNER JOIN dbo.HE_THONG ON dbo.MAY_HE_THONG.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG " & _
                  "WHERE (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "') AND (DATENAME(WEEKDAY, TG.NGAY) = 'Saturday' OR DATENAME(WEEKDAY, TG.NGAY) = 'Sunday')"

        If cboDayChuyenCuoiTuan.SelectedValue.ToString <> "-1" Then SqlText += " AND MAY_HE_THONG.MS_HE_THONG = " & cboDayChuyenCuoiTuan.SelectedValue

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_DC")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Create_TitleReport_TGCM(2, False)
        ReportPreview("reports/rptTHOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_DC.rpt")
KetThuc:
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_DC"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = " DROP TABLE rpt_Title_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnTheoLoaiMay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTheoLoaiMay.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim SqlText As String = ""


        Commons.clsXuLy.CreateTitleReport()
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        SqlText = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY,TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
          "INTO [dbo].rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN " & _
          "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
               "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
               "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
               "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
          "WHERE (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "') AND (DATENAME(WEEKDAY,NGAY)='Saturday' OR DATENAME(WEEKDAY,NGAY)='Sunday')"

        If cboLoaithietbi2.SelectedValue.ToString <> "-1" Then SqlText += " AND LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi2.SelectedValue.ToString & "'"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Create_TitleReport_TGCM(2, True)
        ReportPreview("reports/rptTHOI_GIAN_CHAY_MAY_CUOI_TUAN_THEO_LOAI_MAY.rpt")
KetThuc:
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_CUOI_TUAN"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = " DROP TABLE rpt_Title_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Sub Create_TitleReport_TGCM(ByVal iLoaiBC As Byte, Optional ByVal bTheoLoaiMay As Boolean = True)
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_Title_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = "CREATE TABLE [dbo].rpt_Title_THOI_GIAN_CHAY_MAY(TypeLanguage int,TrangIn NVARCHAR(50)," & _
                "NgayIn NVARCHAR(50),DKLoc NVARCHAR(100),TieudeReport NVARCHAR(255),DayChuyen NVARCHAR(30),Loai_May NVARCHAR(50),Nhom_May NVARCHAR(50)," & _
                "May NVARCHAR(50),Don_vi_RT NVARCHAR(50),Ngay NVARCHAR(50),Chi_so_dong_ho NVARCHAR(50)," & _
                "Chi_so_chu_trinh_lv NVARCHAR(50), So_phieu_bao_tri NVARCHAR(50))"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim sTieudeReport As String

        If iLoaiBC = 1 Then     'thoi gian chay may
            If bTheoLoaiMay = True Then
                sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY1", "TieuDe", Commons.Modules.TypeLanguage)
            Else
                sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY_THEO_DC1", "TieuDe", Commons.Modules.TypeLanguage)
            End If
        Else        'thoi gian chay may vao ngay cuoi tuan
            If bTheoLoaiMay = True Then
                sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY", "TieuDe", Commons.Modules.TypeLanguage)
            Else
                sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY_THEO_DC", "TieuDe", Commons.Modules.TypeLanguage)
            End If
        End If

        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "Ngayin", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "Trangin", Commons.Modules.TypeLanguage)
        Dim sDayChuyenSX As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY", "DayChuyenSX", Commons.Modules.TypeLanguage)
        Dim sLoai_May As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "Loai_May", Commons.Modules.TypeLanguage)
        Dim sNhom_May As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "Nhom_May", Commons.Modules.TypeLanguage)
        Dim sMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim sDon_vi_RT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "Don_vi_RT", Commons.Modules.TypeLanguage)
        Dim sNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "Ngay", Commons.Modules.TypeLanguage)
        Dim sChi_so_dong_ho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "Chi_so_dong_ho", Commons.Modules.TypeLanguage)
        Dim sChi_so_chu_trinh_lv As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "Chi_so_chu_trinh_lv", Commons.Modules.TypeLanguage)
        Dim sSo_phieu_bao_tri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoiGianChayMayCuoiTuan", "So_phieu_bao_tri", Commons.Modules.TypeLanguage)
        Dim DKLoc As String = lblTungayCuoiTuan.Text & "  " & Format(dtpTuNgayCuoiTuan.Value, "dd/MM/yyyy").ToString & "    " & lblDenngayCuoiTuan.Text & "  " & Format(dtpDenNgayCuoiTuan.Value, "dd/MM/yyyy").ToString
        SqlText = "INSERT INTO [DBO].rpt_Title_THOI_GIAN_CHAY_MAY(commons.Modules.TypeLanguage,TrangIn,NgayIn,DKLoc,TieudeReport,DayChuyen,Loai_May,Nhom_May,May,Don_vi_RT,Ngay,Chi_so_dong_ho,Chi_so_chu_trinh_lv,So_phieu_bao_tri) " & _
                        "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sTrangIn & "',N'" & sNgayIn & "'," & _
                        "N'" & DKLoc & "',N'" & sTieudeReport & "',N'" & sDayChuyenSX & "',N'" & sLoai_May & "',N'" & sNhom_May & _
                        "',N'" & sMay & "',N'" & sDon_vi_RT & "',N'" & sNgay & "',N'" & sChi_so_dong_ho & _
                        "',N'" & sChi_so_chu_trinh_lv & "',N'" & sSo_phieu_bao_tri & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
