Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptThoigianchaymay
    Private SqlText As String = String.Empty
    Private Sub frmrptThoigianchaymay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Bind_cboLoaithietbi2()
        Bind_daychuyen()
        Bind_cbothietbi2()
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

    Sub Bind_cbothietbi2()
        If cboLoaithietbi2.SelectedIndex = -1 Then
            cbothietbi2.Text = ""
            Exit Sub
        End If

        If cboLoaithietbi2.SelectedValue.ToString = "-1" Then
            SqlText = "SELECT DISTINCT MAY.MS_MAY, MAY.MS_MAY AS MAY FROM USERS INNER JOIN NHOM_LOAI_MAY ON USERS.GROUP_ID = NHOM_LOAI_MAY.GROUP_ID INNER JOIN MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY MS_MAY"
        Else
            SqlText = "SELECT DISTINCT MAY.MS_MAY, MAY.MS_MAY AS MAY FROM USERS INNER JOIN NHOM_LOAI_MAY ON USERS.GROUP_ID = NHOM_LOAI_MAY.GROUP_ID INNER JOIN MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY WHERE  NHOM_MAY.MS_LOAI_MAY='" & cboLoaithietbi2.SelectedValue.ToString & "' AND (USERS.USERNAME = '" & Commons.Modules.UserName & "') ORDER BY MS_MAY"
        End If

        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        dt.Rows.InsertAt(row, 0)
        cbothietbi2.DataSource = dt
        cbothietbi2.DisplayMember = "MAY"
        cbothietbi2.ValueMember = "MS_MAY"

        If cbothietbi2.Items.Count = 0 Then cbothietbi2.Text = ""
    End Sub

    Private Sub btnTheoDayChuyen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTheoDayChuyen.Click
        Dim SqlText As String = ""
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Create_TitleReport_TGCM(1, False)
        print_reportThoigianchaymay_theodaychuyen()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnTheoLoaiMay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTheoLoaiMay.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim SqlText As String = ""

        Create_TitleReport_TGCM(1, True)
        Commons.clsXuLy.CreateTitleReport()
        print_reportThoigianchaymay_theoloaimay()

        Me.Cursor = Cursors.Default
    End Sub

    Sub print_reportThoigianchaymay_theodaychuyen()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_THEO_DC"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        SqlText = "SELECT DISTINCT HE_THONG.MS_HE_THONG,HE_THONG.TEN_HE_THONG,TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                  "INTO [dbo].rpt_THOI_GIAN_CHAY_MAY_THEO_DC " & _
                  "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY = TG.MS_MAY INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT = DON_VI_TINH_RUN_TIME.MS_DVT_RT INNER JOIN " & _
                        "NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN MAY_HE_THONG ON TG.MS_MAY = MAY_HE_THONG.MS_MAY INNER JOIN " & _
                        "HE_THONG ON MAY_HE_THONG.MS_HE_THONG = HE_THONG.MS_HE_THONG " & _
                  "WHERE (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "') ORDER BY TG.MS_MAY,NGAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rpt_THOI_GIAN_CHAY_MAY_THEO_DC")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        ReportPreview("reports/rptThoiGianChayMayTheoDC.rpt")
KetThuc:
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY_THEO_DC"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = " DROP TABLE rpt_Title_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
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

        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "Ngayin", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "Trangin", Commons.Modules.TypeLanguage)
        Dim sDayChuyenSX As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY", "DayChuyenSX", Commons.Modules.TypeLanguage)
        Dim sLoai_May As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "Loai_May", Commons.Modules.TypeLanguage)
        Dim sNhom_May As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "Nhom_May", Commons.Modules.TypeLanguage)
        Dim sMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_Title_THOI_GIAN_CHAY_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim sDon_vi_RT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "Don_vi_RT", Commons.Modules.TypeLanguage)
        Dim sNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "Ngay", Commons.Modules.TypeLanguage)
        Dim sChi_so_dong_ho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "Chi_so_dong_ho", Commons.Modules.TypeLanguage)
        Dim sChi_so_chu_trinh_lv As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "Chi_so_chu_trinh_lv", Commons.Modules.TypeLanguage)
        Dim sSo_phieu_bao_tri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "So_phieu_bao_tri", Commons.Modules.TypeLanguage)
        Dim DKLoc As String = lblTungayCuoiTuan.Text & "  " & Format(dtpTuNgayCuoiTuan.Value, "dd/MM/yyyy").ToString & "    " & lblDenngayCuoiTuan.Text & "  " & Format(dtpDenNgayCuoiTuan.Value, "dd/MM/yyyy").ToString
        SqlText = "INSERT INTO [DBO].rpt_Title_THOI_GIAN_CHAY_MAY(commons.Modules.TypeLanguage,TrangIn,NgayIn,DKLoc,TieudeReport,DayChuyen,Loai_May,Nhom_May,May,Don_vi_RT,Ngay,Chi_so_dong_ho,Chi_so_chu_trinh_lv,So_phieu_bao_tri) " & _
                        "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sTrangIn & "',N'" & sNgayIn & "'," & _
                        "N'" & DKLoc & "',N'" & sTieudeReport & "',N'" & sDayChuyenSX & "',N'" & sLoai_May & "',N'" & sNhom_May & _
                        "',N'" & sMay & "',N'" & sDon_vi_RT & "',N'" & sNgay & "',N'" & sChi_so_dong_ho & _
                        "',N'" & sChi_so_chu_trinh_lv & "',N'" & sSo_phieu_bao_tri & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub
    Sub print_reportThoigianchaymay_theoloaimay()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = " CREATE TABLE [dbo].rpt_THOI_GIAN_CHAY_MAY(LOAI_MAY NVARCHAR(50),NHOM_MAY NVARCHAR(50)," & _
                "MAY NVARCHAR(50),DON_VI_TINH_RT NVARCHAR(50),NGAY DATETIME,CHI_SO_DONG_HO INT," & _
                "SO_MOVEMENT INT,MS_PBT NVARCHAR(30))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        If cboLoaithietbi2.SelectedValue = "-1" Then
            'If cboNhomthietbi.SelectedValue = "-1" Then
            If cbothietbi2.SelectedValue = "-1" Then
                SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                            "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                            "WHERE (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
            Else
                SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                            "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                "WHERE TG.MS_MAY ='" & cbothietbi2.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
            End If
            'Else
            '    If cbothietbi2.SelectedValue = "-1" Then
            '        SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
            '                    "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
            '                        "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
            '                        "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
            '                        "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
            '                        "WHERE NHOM_MAY.MS_NHOM_MAY ='" & cboNhomthietbi.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
            '    Else
            '        SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
            '                    "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
            '                        "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
            '                        "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
            '                        "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
            '                        "WHERE NHOM_MAY.MS_NHOM_MAY ='" & cboNhomthietbi.SelectedValue & "' AND TG.MS_MAY ='" & cbothietbi2.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
            '    End If
            'End If
        Else
            'If cboNhomthietbi.SelectedValue = "-1" Then
            If cbothietbi2.SelectedValue = "-1" Then
                SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                            "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                "WHERE LOAI_MAY.MS_LOAI_MAY ='" & cboLoaithietbi2.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
            Else
                SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
                            "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
                                "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
                                "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                                "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
                                "WHERE LOAI_MAY.MS_LOAI_MAY ='" & cboLoaithietbi2.SelectedValue & "' AND TG.MS_MAY ='" & cbothietbi2.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
            End If
            'Else
            'If cbothietbi2.SelectedValue = "-1" Then
            '    SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
            '                "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
            '                    "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
            '                    "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
            '                    "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
            '                    "WHERE LOAI_MAY.MS_LOAI_MAY ='" & cboLoaithietbi2.SelectedValue & "' AND NHOM_MAY.MS_NHOM_MAY ='" & cboNhomthietbi.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
            'Else
            '    SqlText = "INSERT INTO [dbo].rpt_THOI_GIAN_CHAY_MAY SELECT DISTINCT TEN_LOAI_MAY,TEN_NHOM_MAY,TG.MS_MAY,TEN_DVT_RT,NGAY,CHI_SO_DONG_HO,SO_MOVEMENT,MS_PBT " & _
            '                "FROM THOI_GIAN_CHAY_MAY TG INNER JOIN MAY ON MAY.MS_MAY=TG.MS_MAY " & _
            '                    "INNER JOIN DON_VI_TINH_RUN_TIME ON MAY.MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT " & _
            '                    "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
            '                    "INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " & _
            '                    "WHERE LOAI_MAY.MS_LOAI_MAY ='" & cboLoaithietbi2.SelectedValue & "' AND NHOM_MAY.MS_NHOM_MAY ='" & cboNhomthietbi.SelectedValue & "' AND TG.MS_MAY ='" & cbothietbi2.SelectedValue & "' AND (NGAY BETWEEN '" & Format(dtpTuNgayCuoiTuan.Value, "MM/dd/yyyy") & "' AND '" & Format(dtpDenNgayCuoiTuan.Value, "MM/dd/yyyy") & "')"
            'End If
        End If


        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rpt_THOI_GIAN_CHAY_MAY")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThoigianchaymay", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        ReportPreview("reports/rptThoigianchaymay.rpt")
KetThuc:
        Try
            SqlText = " DROP TABLE rpt_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = " DROP TABLE rpt_Title_THOI_GIAN_CHAY_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cboLoaithietbi2_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaithietbi2.SelectedIndexChanged
        Bind_cbothietbi2()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.ParentForm.Close()
    End Sub
End Class
