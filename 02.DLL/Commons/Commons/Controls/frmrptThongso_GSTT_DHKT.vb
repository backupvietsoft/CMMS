Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient

Public Class frmrptThongso_GSTT_DHKT

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_THONG_SO_GSTT_DEN_HAN_KT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = " CREATE TABLE [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT(LOAI_MAY NVARCHAR(20)," & _
                "NHOM_MAY NVARCHAR(20),MAY NVARCHAR(30),THONG_SO NVARCHAR(50),NGAY_KIEM_TRA_CUOI DATETIME," & _
                "MS_DV_TG INT, CHU_KY_DO INT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        If cboLoaithietbi3.SelectedValue = "-1" Then
            If cboNhomthietbi3.SelectedValue = "-1" Then
                If cboThietbi3.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG "
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            Else
                If cboThietbi3.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & "'"
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & _
                            "' AND GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            End If
        Else
            If cboNhomthietbi3.SelectedValue = "-1" Then
                If cboThietbi3.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & "'"
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & _
                            "' AND GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            Else
                If cboThietbi3.SelectedValue = "-1" Then
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & _
                            "' AND MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & "'"
                Else
                    SqlText = "INSERT INTO [dbo].rpt_THONG_SO_GSTT_DEN_HAN_KT SELECT TEN_LOAI_MAY, TEN_NHOM_MAY, GIAM_SAT_TINH_TRANG_TS.MS_MAY," & _
                            "TEN_TS_GSTT, NGAY_KT,MAY_THONG_SO_GSTT.MS_DV_TG,CHU_KY_DO " & _
                            "FROM GIAM_SAT_TINH_TRANG " & _
                            "INNER JOIN GIAM_SAT_TINH_TRANG_TS ON GIAM_SAT_TINH_TRANG.STT = GIAM_SAT_TINH_TRANG_TS.STT " & _
                            "INNER JOIN MAY_THONG_SO_GSTT ON (MAY_THONG_SO_GSTT.MS_MAY=GIAM_SAT_TINH_TRANG_TS.MS_MAY AND " & _
                                               "MAY_THONG_SO_GSTT.MS_TS_GSTT=GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT) " & _
                            "INNER JOIN THONG_SO_GSTT ON THONG_SO_GSTT.MS_TS_GSTT=MAY_THONG_SO_GSTT.MS_TS_GSTT " & _
                            "INNER JOIN MAY ON MAY.MS_MAY=MAY_THONG_SO_GSTT.MS_MAY " & _
                            "INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
                            "INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " & _
                            "INNER JOIN DON_VI_THOI_GIAN ON MAY_THONG_SO_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " & _
                            "WHERE NHOM_MAY.MS_LOAI_MAY = '" & cboLoaithietbi3.SelectedValue & _
                            "' AND MAY.MS_NHOM_MAY = '" & cboNhomthietbi3.SelectedValue & _
                            "' AND GIAM_SAT_TINH_TRANG_TS.MS_MAY = '" & cboThietbi3.SelectedValue & "'"
                End If
            End If
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rpt_THONG_SO_GSTT_DEN_HAN_KT")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()

        Create_TitleReport_TSGSTT()
        ReportPreview("reports/rptThongso_GSTT_DHKT.rpt")
        Try
            SqlText = " DROP TABLE rpt_THONG_SO_GSTT_DEN_HAN_KT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            SqlText = " DROP TABLE rpt_Title_THONG_SO_GSTT_DEN_HAN_KT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmrptThongso_GSTT_DHKT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadcboDiaDiem()
        Bind_cboLoaithietbi3()
        Bind_cboNhomthietbi3()
        Bind_cbothietbi3()
    End Sub
    Sub LoadcboDiaDiem()
        cboDiaDiem.Value = "MS_N_XUONG"
        cboDiaDiem.Display = "TEN_N_XUONG"
        cboDiaDiem.Param = Commons.Modules.UserName
        cboDiaDiem.StoreName = "PermisionNHA_XUONG"
        cboDiaDiem.BindDataSource()
    End Sub
    Sub Bind_cboLoaithietbi3()
        Dim str As String = ""
        If cboDiaDiem.Text = "" Then
            Exit Sub
        End If
        str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " & _
        " FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND USERNAME='" & Commons.Modules.UserName & "'"
        cboLoaithietbi3.Display = "TEN_LOAI_MAY"
        cboLoaithietbi3.Value = "MS_LOAI_MAY"
        cboLoaithietbi3.Param = str
        cboLoaithietbi3.StoreName = "QL_SEARCH"
        cboLoaithietbi3.BindDataSource()
        If cboLoaithietbi3.Items.Count = 0 Then
            cboLoaithietbi3.Text = ""
        End If
    End Sub

    Sub Bind_cboNhomthietbi3()
        If cboLoaithietbi3.SelectedIndex = -1 Then
            cboNhomthietbi3.Text = ""
            Exit Sub
        End If
        cboNhomthietbi3.Display = "TEN_NHOM_MAY"
        cboNhomthietbi3.Value = "MS_NHOM_MAY"
        'cboNhomthietbi3.Param = cboLoaithietbi3.SelectedValue
        If cboLoaithietbi3.SelectedValue.ToString = "-1" Then
            cboNhomthietbi3.Param = "SELECT NHOM_MAY.* FROM NHOM_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        Else
            cboNhomthietbi3.Param = "SELECT NHOM_MAY.* FROM NHOM_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE NHOM_LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "' AND (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        End If
        'cboNhomthietbi.StoreName = "Get_rptNhomThietBi"
        cboNhomthietbi3.StoreName = "QL_SEARCH"
        cboNhomthietbi3.BindDataSource()
        If cboNhomthietbi3.Items.Count = 0 Then
            cboNhomthietbi3.Text = ""
        End If
    End Sub

    Sub Bind_cbothietbi3()
        If cboNhomthietbi3.SelectedIndex = -1 Then
            cboThietbi3.Text = ""
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT DISTINCT MAY.MS_MAY, MAY.MS_MAY AS MAY FROM MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN " & _
        " USERS ON NHOM.GROUP_ID = USERS.GROUP_ID where USERNAME='" & Commons.Modules.UserName & "' AND MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        If cboLoaithietbi3.SelectedValue <> "-1" Then
            str = str + " and LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "'"
        End If
        If cboNhomthietbi3.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomthietbi3.SelectedValue & "'"
        End If
        cboThietbi3.Display = "MAY"
        cboThietbi3.Value = "MS_MAY"
        cboThietbi3.Param = str
        cboThietbi3.StoreName = "QL_SEARCH"
        cboThietbi3.BindDataSource()
        If cboThietbi3.Items.Count = 0 Then
            cboThietbi3.Text = ""
        End If
    End Sub

    Sub Create_TitleReport_TSGSTT()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rpt_Title_THONG_SO_GSTT_DEN_HAN_KT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = "CREATE TABLE [dbo].rpt_Title_THONG_SO_GSTT_DEN_HAN_KT(TypeLanguage int," & _
                "TrangIn NVARCHAR(50),NgayIn NVARCHAR(50),TieudeReport NVARCHAR(255)," & _
                "Ngay NVARCHAR(50),Loai_May NVARCHAR(50),Nhom_May NVARCHAR(50),May NVARCHAR(50)," & _
                "Thong_so NVARCHAR(50),Ngay_kiem_tra_cuoi NVARCHAR(50),Ngay_kiem_tra_ke_tiep NVARCHAR(50))"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "TieudeReport_GSTT", commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "Ngayin", commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "Trangin", commons.Modules.TypeLanguage)
        Dim sNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "Ngay", commons.Modules.TypeLanguage)

        Dim sLoai_May As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "Loai_May", commons.Modules.TypeLanguage)
        Dim sNhom_May As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "Nhom_May", commons.Modules.TypeLanguage)
        Dim sMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "May", commons.Modules.TypeLanguage)

        Dim sThong_so As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "Thong_so", commons.Modules.TypeLanguage)
        Dim sNgay_kiem_tra_cuoi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "Ngay_kiem_tra_cuoi", commons.Modules.TypeLanguage)
        Dim sNgay_kiem_tra_ke_tiep As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThongso_GSTT_DHKT", "Ngay_kiem_tra_ke_tiep", commons.Modules.TypeLanguage)

        'SqlText = "INSERT INTO rpt_Title_THONG_SO_GSTT_DEN_HAN_KT(commons.Modules.TypeLanguage,TrangIn,NgayIn,TieudeReport,Ngay,Loai_May,Nhom_May,May,Thong_so,Ngay_kiem_tra_cuoi,Ngay_kiem_tra_ke_tiep) " & _
        '                "VALUES(" & commons.Modules.TypeLanguage & ",N'" & sTrangIn & "',N'" & sNgayIn & "'," & _
        '                "N'" & sTieudeReport & "',N'" & sNgay & "',N'" & sLoai_May & "',N'" & sNhom_May & _
        '                "',N'" & sMay & "',N'" & sThong_so & "',N'" & sNgay_kiem_tra_cuoi & _
        '                "',N'" & sNgay_kiem_tra_ke_tiep & "')"

        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Private Sub cboDiaDiem_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDiaDiem.SelectionChangeCommitted
        Bind_cboLoaithietbi3()
        Bind_cboNhomthietbi3()
        Bind_cbothietbi3()
    End Sub

    Private Sub cboLoaithietbi3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaithietbi3.SelectedIndexChanged
        Bind_cboNhomthietbi3()
        Bind_cbothietbi3()
    End Sub

    Private Sub cboNhomthietbi3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNhomthietbi3.SelectedIndexChanged
        Bind_cbothietbi3()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
