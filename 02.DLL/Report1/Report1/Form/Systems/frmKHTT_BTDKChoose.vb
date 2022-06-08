Imports Commons.VS.Classes.Admin
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Public Class frmKHTT_BTDKChoose

    Private objLichBTPN As New clsLichBTPN
    Private fromdate As New DateTime(2014, 1, 1)
    Private todate As New DateTime(2014, 3, 31)

    Public DataBTDKSelected As New DataTable

    Private loaiMay As String = "-1"
    Private tinh As String = "-1"
    Private huyen As String = "-1"
    Private diadiem As String = "-1"
    Private daychuyen As String = "-1"
    Private LoaiThietBi As String = "-1"
    Private nhomthietbi As String = "-1"
    Private thietbi As String = "-1"
    Private TheoGio As Boolean = False

    Public KHType As String = "1"
    Public KHNam As Integer = 2014
    Public KHThang As Integer = 0


    Dim j As Integer = 0 ' STT Ms hang muc

    Private Sub getDataBTDK()
        Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
        scon.Open()
        Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
        Try
            Dim commandGetBTDK As SqlCommand = scon.CreateCommand()
            commandGetBTDK.Connection = scon
            commandGetBTDK.CommandTimeout = 9999
            commandGetBTDK.Transaction = sqlTrans
            commandGetBTDK.CommandType = CommandType.StoredProcedure
            commandGetBTDK.CommandText = "SP_GET_BTDK_FOR_KHBT"
            commandGetBTDK.Parameters.Add("@TUNGAY", SqlDbType.Date)
            commandGetBTDK.Parameters("@TUNGAY").Value = fromdate

            commandGetBTDK.Parameters.Add("@DENNGAY", SqlDbType.Date)
            commandGetBTDK.Parameters("@DENNGAY").Value = todate

            commandGetBTDK.Parameters.Add("@USER", SqlDbType.NVarChar)
            commandGetBTDK.Parameters("@USER").Value = Commons.Modules.UserName

            Dim daGetBTDK As New SqlDataAdapter(commandGetBTDK)
            Dim dsBTDK As New DataSet()
            daGetBTDK.Fill(dsBTDK)

            gdBTDK.DataSource = dsBTDK.Tables(0)

            sqlTrans.Commit()
            scon.Close()

        Catch ex As Exception
            sqlTrans.Rollback()
            scon.Close()
        End Try



    End Sub

    Sub LayDuLieu()
        'If (CboMaSoThietBiBTDK.Text = "" Or IsDBNull(CboMaSoThietBiBTDK)) And (cboLoaiThietBiBTDK.Text = "" Or IsDBNull(cboLoaiThietBiBTDK)) Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '    'Không có dữ liệu 
        '    Exit Sub
        'End If

        'dtpDenNgayBTDK1.Text = dtpDenNgay.Value



        objLichBTPN.TaoDuLieu2(ProgressBar1, fromdate, todate, _
                "-1", "-1", "-1", _
                "-1", "-1", "-1", "", "-1")

        objLichBTPN.XoaP4CK(ProgressBar1)
        layDuLieuSub()
        ProgressBar1.PerformStep()
    End Sub

    Sub layDuLieuSub()
        Try
            Commons.Modules.SQLString = "DROP TABLE MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception

        End Try

        Commons.Modules.SQLString = "SELECT MAY_LOAI_BTPN_CHU_KY.*,LOAI_BAO_TRI.THU_TU INTO MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " FROM (SELECT MS_MAY,MS_LOAI_BT,MAX(NGAY_AD) AS NGAY_AD_MAX FROM MAY_LOAI_BTPN_CHU_KY GROUP BY MS_MAY,MS_LOAI_BT) AS TAM INNER JOIN MAY_LOAI_BTPN_CHU_KY ON TAM.MS_MAY=MAY_LOAI_BTPN_CHU_KY.MS_MAY AND TAM.MS_LOAI_BT=MAY_LOAI_BTPN_CHU_KY.MS_LOAI_BT AND TAM.NGAY_AD_MAX=MAY_LOAI_BTPN_CHU_KY.NGAY_AD INNER JOIN LOAI_BAO_TRI ON TAM.MS_LOAI_BT = LOAI_BAO_TRI.MS_LOAI_BT ORDER BY MAY_LOAI_BTPN_CHU_KY.MS_MAY,MAY_LOAI_BTPN_CHU_KY.MS_LOAI_BT"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Try
            Commons.Modules.SQLString = "DROP TABLE DL_BTDK" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch EX As Exception

        End Try

        'sua cho att
        Commons.Modules.SQLString = "SELECT TEN_NHOM_MAY,DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY,TEN_N_XUONG,TEN_LOAI_BT,MAY_LOAI_BTPN.NGAY_CUOI,DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI AS NGAY_BTKT,CAST(RUN_TIME AS NVARCHAR) + ' ' + TEN_DVT_RT AS TGCM,NULL AS TGCM_HIEN_TAI,MOVEMENT,NULL AS MOVEMENT_HIEN_TAI,LOAI_BAO_TRI.MS_LOAI_BT,DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".THU_TU INTO DL_BTDK" & Commons.Modules.UserName & " FROM DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " INNER JOIN MAY ON DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY=MAY.MS_MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_BAO_TRI ON DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_LOAI_BT=LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " ON DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY = MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_MAY And DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_LOAI_BT = MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_LOAI_BT INNER JOIN DON_VI_TINH_RUN_TIME ON MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT INNER JOIN V_MAY_NHA_XUONG_MAX ON MAY.MS_MAY=V_MAY_NHA_XUONG_MAX.MS_MAY INNER JOIN NHA_XUONG ON NHA_XUONG.MS_N_XUONG=V_MAY_NHA_XUONG_MAX.MS_N_XUONG INNER JOIN MAY_LOAI_BTPN ON MAY_LOAI_BTPN.MS_MAY=MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_MAY AND MAY_LOAI_BTPN.MS_LOAI_BT=MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_LOAI_BT WHERE DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI NOT IN (SELECT NGAY_BTPN FROM KE_HOACH_TONG_THE WHERE NGAY_BTPN IS NOT NULL AND MS_MAY =DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY) AND DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI NOT IN (SELECT NGAY_BTPN FROM PHIEU_BAO_TRI WHERE NGAY_BTPN IS NOT NULL AND MS_MAY  =DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY) ORDER BY TEN_NHOM_MAY,DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY,TEN_N_XUONG,LOAI_BAO_TRI.MS_LOAI_BT,DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Try
            Commons.Modules.SQLString = "DROP TABLE BT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch EX As Exception

        End Try

        Try
            Commons.Modules.SQLString = "DROP TABLE NGAY_CUOI_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch EX As Exception

        End Try

        Commons.Modules.SQLString = "SELECT MS_MAY,MIN(NGAY_BTKT) AS NGAY INTO BT_TMP" & Commons.Modules.UserName & " FROM DL_BTDK" & Commons.Modules.UserName & " GROUP BY MS_MAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Commons.Modules.SQLString = "SELECT A.MS_MAY,NGAY_CUOI,NGAY AS NGAY_BT INTO NGAY_CUOI_TMP" & Commons.Modules.UserName & " FROM BT_TMP" & Commons.Modules.UserName & " A INNER JOIN DL_BTDK" & Commons.Modules.UserName & " B ON A.MS_MAY=B.MS_MAY AND A.NGAY=B.NGAY_BTKT"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        'att có thể không cần thực hiện
        Commons.Modules.SQLString = "UPDATE A SET A.MOVEMENT_HIEN_TAI=B.MOVEMENT_HIEN_TAI FROM DL_BTDK" & Commons.Modules.UserName & " A LEFT JOIN (SELECT THOI_GIAN_CHAY_MAY.MS_MAY,SUM(SO_MOVEMENT) AS MOVEMENT_HIEN_TAI FROM THOI_GIAN_CHAY_MAY INNER JOIN NGAY_CUOI_TMP" & Commons.Modules.UserName & " ON THOI_GIAN_CHAY_MAY.MS_MAY=NGAY_CUOI_TMP" & Commons.Modules.UserName & ".MS_MAY WHERE NGAY>NGAY_CUOI AND NGAY<='" & Format(CType(todate, Date), "MM/dd/yyyy") & "' GROUP BY THOI_GIAN_CHAY_MAY.MS_MAY) B ON A.MS_MAY=B.MS_MAY LEFT JOIN NGAY_CUOI_TMP" & Commons.Modules.UserName & " C ON A.MS_MAY=C.MS_MAY WHERE A.NGAY_BTKT=C.NGAY_BT"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        TaoLuoiBTDK()
        Try
            Commons.Modules.SQLString = "DROP TABLE PHU" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception

        End Try

        Try
            Commons.Modules.SQLString = "DROP TABLE NGAY_CUOI_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception

        End Try

        Try
            Commons.Modules.SQLString = "DROP TABLE BT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception

        End Try
    End Sub

    Sub TaoLuoiBTDK()

        Try
            If thietbi <> "-1" Then
                Commons.Modules.SQLString = "SELECT DISTINCT A.MS_MAY,TEN_LOAI_BT,A.THU_TU,NGAY_CUOI,NGAY_BTKT,CONVERT(NVARCHAR(10),RUN_TIME)+' '+TEN_DVT_RT AS TGCM, " & _
                    " CASE WHEN NGAY_BTKT < (SELECT NGAY_BTKT_TMP  FROM ( SELECT  MS_MAY, MS_LOAI_BT , " & _
                    " MAX (NGAY_BTKT) AS NGAY_BTKT_TMP FROM DL_BTDK" & Commons.Modules.UserName & " " & _
                    " WHERE(NGAY_BTKT <= GETDATE()) GROUP BY MS_MAY, MS_LOAI_BT ) T1 " & _
                    " WHERE A.MS_MAY = T1.MS_MAY AND A.MS_LOAI_BT = T1.MS_LOAI_BT ) " & _
                    " THEN  CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0) from thoi_gian_chay_may " & _
                    " where(MS_MAY = A.MS_MAY And NGAY > NGAY_CUOI And NGAY <= NGAY_BTKT)) AS NVARCHAR) " & _
                    " Else CASE WHEN NGAY_BTKT = (SELECT NGAY_BTKT_TMP  FROM ( " & _
                    " SELECT  MS_MAY, MS_LOAI_BT , MAX (NGAY_BTKT) AS NGAY_BTKT_TMP  " & _
                    " FROM DL_BTDK" & Commons.Modules.UserName & " WHERE(NGAY_BTKT <= GETDATE())" & _
                    " GROUP BY MS_MAY, MS_LOAI_BT ) T1 " & _
                    " WHERE A.MS_MAY = T1.MS_MAY AND A.MS_LOAI_BT = T1.MS_LOAI_BT ) THEN " & _
                    " CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0) from thoi_gian_chay_may " & _
                    " where(MS_MAY = A.MS_MAY And NGAY > NGAY_CUOI And NGAY <= GETDATE()) ) AS NVARCHAR) " & _
                    " Else CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0) from Thoi_gian_chay_may " & _
                    " where MS_MAY = A.MS_MAY AND NGAY> =  CASE MS_DV_TG WHEN 1 THEN  " & _
                    " DATEADD(DAY,-CHU_KY,NGAY_BTKT)WHEN 2 THEN DATEADD(DAY,-CHU_KY*7,NGAY_BTKT)  " & _
                    " WHEN 3 THEN DATEADD(MONTH,-CHU_KY,NGAY_BTKT)ELSE DATEADD(YEAR,-CHU_KY,NGAY_BTKT)  " & _
                    " END   AND NGAY <NGAY_BTKT  ) AS NVARCHAR) End End " & _
                    " AS TG_THUC_HIEN ,RUN_TIME,A.MS_LOAI_BT,TEN_NHOM_MAY,TEN_DVT_RT/*,TEN_N_XUONG*/  " & _
                    " FROM DL_BTDK" & Commons.Modules.UserName & " A INNER JOIN  " & _
                    " MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " B ON A.MS_MAY = B.MS_MAY  " & _
                    " And A.MS_LOAI_BT = B.MS_LOAI_BT INNER JOIN DON_VI_TINH_RUN_TIME C ON  " & _
                    " B.MS_DVT_RT=C.MS_DVT_RT INNER JOIN V_MAY_NHA_XUONG_MAX D ON A.MS_MAY=D.MS_MAY  " & _
                    " INNER JOIN dbo.NHA_XUONG ON D.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN  " & _
                    " dbo.Y_District ON dbo.Y_District.ma_qg = dbo.NHA_XUONG.MS_QG INNER JOIN " & _
                    " dbo.Y_Tinh ON dbo.Y_District.ms_cha = dbo.Y_Tinh.ma_qg INNER JOIN  " & _
                    " (SELECT * FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & diadiem & "')) " & _
                    " AS NNX ON D.MS_N_XUONG =NNX.MS_N_XUONG  " & _
                    " WHERE (NGAY_BTKT BETWEEN '" & Format(fromdate, "MM/dd/yyyy") & "'  " & _
                    " AND '" & Format(todate, "MM/dd/yyyy") & "')   "
                If thietbi <> "-1" Then
                    Commons.Modules.SQLString = Commons.Modules.SQLString & _
                        " AND A.MS_MAY= N'" & thietbi & "'"
                End If

            Else
                'If nhomthietbi.SelectedValue Is Nothing Then GoTo TT
                If nhomthietbi = "-1" Then
                    Commons.Modules.SQLString = "SELECT DISTINCT A.MS_MAY,TEN_LOAI_BT,A.THU_TU,NGAY_CUOI,NGAY_BTKT,CONVERT(NVARCHAR(10),RUN_TIME)+' '+TEN_DVT_RT AS TGCM, " & _
                        " CASE WHEN NGAY_BTKT < " & _
                        " (SELECT NGAY_BTKT_TMP  " & _
                        " FROM ( " & _
                        " SELECT  MS_MAY, MS_LOAI_BT , MAX (NGAY_BTKT) AS NGAY_BTKT_TMP " & _
                        " FROM DL_BTDK" & Commons.Modules.UserName & " " & _
                        " WHERE(NGAY_BTKT <= GETDATE())" & _
                        " GROUP BY MS_MAY, MS_LOAI_BT " & _
                        " ) T1 " & _
                        " WHERE A.MS_MAY = T1.MS_MAY AND A.MS_LOAI_BT = T1.MS_LOAI_BT ) " & _
                        " THEN  " & _
                        " CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0) " & _
                        " from thoi_gian_chay_may " & _
                        " where(MS_MAY = A.MS_MAY And NGAY > NGAY_CUOI And NGAY <= NGAY_BTKT)" & _
                        " ) AS NVARCHAR)" & _
                        " Else " & _
                        " CASE WHEN NGAY_BTKT =  " & _
                        " (SELECT NGAY_BTKT_TMP  " & _
                        " FROM ( " & _
                        " SELECT  MS_MAY, MS_LOAI_BT , MAX (NGAY_BTKT) AS NGAY_BTKT_TMP  " & _
                        " FROM DL_BTDK" & Commons.Modules.UserName & " " & _
                        " WHERE(NGAY_BTKT <= GETDATE())" & _
                        " GROUP BY MS_MAY, MS_LOAI_BT " & _
                        " ) T1 " & _
                        " WHERE A.MS_MAY = T1.MS_MAY AND A.MS_LOAI_BT = T1.MS_LOAI_BT )" & _
                        " THEN " & _
                        " CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0) " & _
                        " from thoi_gian_chay_may " & _
                        " where(MS_MAY = A.MS_MAY And NGAY > NGAY_CUOI And NGAY <= GETDATE()) " & _
                        " ) AS NVARCHAR) " & _
                        " Else " & _
                        " CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0)  " & _
                        " from Thoi_gian_chay_may " & _
                        " where MS_MAY = A.MS_MAY AND NGAY> = " & _
                        " CASE MS_DV_TG WHEN 1 THEN  " & _
                        " DATEADD(DAY,-CHU_KY,NGAY_BTKT)WHEN 2 THEN DATEADD(DAY,-CHU_KY*7,NGAY_BTKT)  " & _
                        " WHEN 3 THEN DATEADD(MONTH,-CHU_KY,NGAY_BTKT)ELSE DATEADD(YEAR,-CHU_KY,NGAY_BTKT)  " & _
                        " END   AND NGAY <NGAY_BTKT " & _
                        " ) AS NVARCHAR) " & _
                        " End " & _
                        " End " & _
                        " AS TG_THUC_HIEN  " & _
                        " , RUN_TIME,A.MS_LOAI_BT, E.TEN_NHOM_MAY,TEN_DVT_RT/*,TEN_N_XUONG*/ FROM DL_BTDK" & Commons.Modules.UserName & " A INNER JOIN MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " B ON A.MS_MAY = B.MS_MAY And A.MS_LOAI_BT = B.MS_LOAI_BT INNER JOIN DON_VI_TINH_RUN_TIME C ON B.MS_DVT_RT=C.MS_DVT_RT INNER JOIN V_MAY_NHA_XUONG_MAX D ON A.MS_MAY=D.MS_MAY INNER JOIN MAY ON A.MS_MAY=MAY.MS_MAY INNER JOIN NHOM_MAY E ON MAY.MS_NHOM_MAY=E.MS_NHOM_MAY " & _
                        " INNER JOIN dbo.NHA_XUONG ON D.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN  " & _
                        " dbo.Y_District ON dbo.Y_District.ma_qg = dbo.NHA_XUONG.MS_QG INNER JOIN " & _
                        " dbo.Y_Tinh ON dbo.Y_District.ms_cha = dbo.Y_Tinh.ma_qg INNER JOIN  " & _
                        " (SELECT * FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & diadiem & "')) " & _
                        " AS NNX ON D.MS_N_XUONG =NNX.MS_N_XUONG  " & _
                        " WHERE (NGAY_BTKT BETWEEN '" & Format(fromdate, "MM/dd/yyyy") & "' AND '" & Format(todate, "MM/dd/yyyy") & "') "
                    If nhomthietbi <> "-1" Then
                        Commons.Modules.SQLString = Commons.Modules.SQLString & _
                            " AND MS_LOAI_MAY = '" & nhomthietbi & "'"
                    End If
                Else
TT:
                    Commons.Modules.SQLString = "SELECT DISTINCT A.MS_MAY,TEN_LOAI_BT,A.THU_TU,NGAY_CUOI,NGAY_BTKT,CONVERT(NVARCHAR(10),RUN_TIME)+' '+TEN_DVT_RT AS TGCM, " & _
                        " CASE WHEN NGAY_BTKT < " & _
                        " (SELECT NGAY_BTKT_TMP  " & _
                        " FROM ( " & _
                        " SELECT  MS_MAY, MS_LOAI_BT , MAX (NGAY_BTKT) AS NGAY_BTKT_TMP " & _
                        " FROM DL_BTDK" & Commons.Modules.UserName & " " & _
                        " WHERE(NGAY_BTKT <= GETDATE())" & _
                        " GROUP BY MS_MAY, MS_LOAI_BT " & _
                        " ) T1 " & _
                        " WHERE A.MS_MAY = T1.MS_MAY AND A.MS_LOAI_BT = T1.MS_LOAI_BT ) " & _
                        " THEN  " & _
                        " CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0) " & _
                        " from thoi_gian_chay_may " & _
                        " where(MS_MAY = A.MS_MAY And NGAY > NGAY_CUOI And NGAY <= NGAY_BTKT)" & _
                        " ) AS NVARCHAR)" & _
                        " Else " & _
                        " CASE WHEN NGAY_BTKT =  " & _
                        " (SELECT NGAY_BTKT_TMP  " & _
                        " FROM ( " & _
                        " SELECT  MS_MAY, MS_LOAI_BT , MAX (NGAY_BTKT) AS NGAY_BTKT_TMP  " & _
                        " FROM DL_BTDK" & Commons.Modules.UserName & " " & _
                        " WHERE(NGAY_BTKT <= GETDATE())" & _
                        " GROUP BY MS_MAY, MS_LOAI_BT " & _
                        " ) T1 " & _
                        " WHERE A.MS_MAY = T1.MS_MAY AND A.MS_LOAI_BT = T1.MS_LOAI_BT )" & _
                        " THEN " & _
                        " CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0) " & _
                        " from thoi_gian_chay_may " & _
                        " where(MS_MAY = A.MS_MAY And NGAY > NGAY_CUOI And NGAY <= GETDATE()) " & _
                        " ) AS NVARCHAR) " & _
                        " Else " & _
                        " CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0)  " & _
                        " from Thoi_gian_chay_may " & _
                        " where MS_MAY = A.MS_MAY AND NGAY> = " & _
                        " CASE MS_DV_TG WHEN 1 THEN  " & _
                        " DATEADD(DAY,-CHU_KY,NGAY_BTKT)WHEN 2 THEN DATEADD(DAY,-CHU_KY*7,NGAY_BTKT)  " & _
                        " WHEN 3 THEN DATEADD(MONTH,-CHU_KY,NGAY_BTKT)ELSE DATEADD(YEAR,-CHU_KY,NGAY_BTKT)  " & _
                        " END   AND NGAY <NGAY_BTKT " & _
                        " ) AS NVARCHAR) " & _
                        " End " & _
                        " End " & _
                        " AS TG_THUC_HIEN  " & _
                        " , RUN_TIME,A.MS_LOAI_BT,TEN_NHOM_MAY, TEN_DVT_RT/*,TEN_N_XUONG*/ FROM DL_BTDK" & Commons.Modules.UserName & " A INNER JOIN MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " B ON A.MS_MAY = B.MS_MAY And A.MS_LOAI_BT = B.MS_LOAI_BT INNER JOIN DON_VI_TINH_RUN_TIME C ON B.MS_DVT_RT=C.MS_DVT_RT INNER JOIN V_MAY_NHA_XUONG_MAX D ON A.MS_MAY=D.MS_MAY INNER JOIN MAY ON A.MS_MAY=MAY.MS_MAY " & _
                        " INNER JOIN dbo.NHA_XUONG ON D.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG INNER JOIN  " & _
                        " dbo.Y_District ON dbo.Y_District.ma_qg = dbo.NHA_XUONG.MS_QG INNER JOIN " & _
                        " dbo.Y_Tinh ON dbo.Y_District.ms_cha = dbo.Y_Tinh.ma_qg INNER JOIN  " & _
                        " (SELECT * FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & diadiem & "')) " & _
                        " AS NNX ON D.MS_N_XUONG =NNX.MS_N_XUONG  " & _
                        " WHERE (NGAY_BTKT BETWEEN '" & Format(fromdate, "MM/dd/yyyy") & "' " & _
                        " AND '" & Format(todate, "MM/dd/yyyy") & "') "
                    If nhomthietbi <> "-1" Then
                        Commons.Modules.SQLString = Commons.Modules.SQLString & _
                            " AND MS_NHOM_MAY='" & nhomthietbi & "'"
                    End If
                End If
            End If


            Commons.Modules.SQLString = " SELECT DISTINCT A.MS_MAY, A.TEN_LOAI_BT, A.THU_TU, A.NGAY_CUOI, A.NGAY_BTKT,  " & _
                " CONVERT(NVARCHAR(10), B.RUN_TIME) + ' ' + C.TEN_DVT_RT AS TGCM, CASE WHEN NGAY_BTKT < " & _
                " (SELECT     NGAY_BTKT_TMP " & _
                " FROM          (SELECT     MS_MAY, MS_LOAI_BT, MAX(NGAY_BTKT) AS NGAY_BTKT_TMP " & _
                " FROM          DL_BTDK" & Commons.Modules.UserName & " " & _
                " WHERE      (NGAY_BTKT <= GETDATE()) " & _
                " GROUP BY MS_MAY, MS_LOAI_BT) T1 " & _
                " WHERE      A.MS_MAY = T1.MS_MAY AND A.MS_LOAI_BT = T1.MS_LOAI_BT) THEN CAST " & _
                " ((SELECT     ISNULL(SUM(CHI_SO_DONG_HO), 0) " & _
                " FROM         thoi_gian_chay_may " & _
                " WHERE     (MS_MAY = A.MS_MAY AND NGAY > NGAY_CUOI AND NGAY <= NGAY_BTKT)) AS NVARCHAR) ELSE CASE WHEN NGAY_BTKT = " & _
                " (SELECT     NGAY_BTKT_TMP " & _
                " FROM          (SELECT     MS_MAY, MS_LOAI_BT, MAX(NGAY_BTKT) AS NGAY_BTKT_TMP " & _
                " FROM          DL_BTDK" & Commons.Modules.UserName & " " & _
                " WHERE      (NGAY_BTKT <= GETDATE()) " & _
                " GROUP BY MS_MAY, MS_LOAI_BT) T1 " & _
                " WHERE      A.MS_MAY = T1.MS_MAY AND A.MS_LOAI_BT = T1.MS_LOAI_BT) THEN CAST " & _
                " ((SELECT     ISNULL(SUM(CHI_SO_DONG_HO), 0) " & _
                " FROM         thoi_gian_chay_may " & _
                " WHERE     (MS_MAY = A.MS_MAY AND NGAY > NGAY_CUOI AND NGAY <= GETDATE())) AS NVARCHAR) ELSE CAST " & _
                " ((SELECT     ISNULL(SUM(CHI_SO_DONG_HO), 0) " & _
                " FROM         Thoi_gian_chay_may " & _
                " WHERE     MS_MAY = A.MS_MAY AND NGAY >= CASE MS_DV_TG WHEN 1 THEN DATEADD(DAY, - CHU_KY, NGAY_BTKT) WHEN 2 THEN DATEADD(DAY, - CHU_KY * 7, NGAY_BTKT)  " & _
                " WHEN 3 THEN DATEADD(MONTH, - CHU_KY, NGAY_BTKT) ELSE DATEADD(YEAR, - CHU_KY, NGAY_BTKT) END AND NGAY < NGAY_BTKT) AS NVARCHAR)  " & _
                " END END AS TG_THUC_HIEN, B.RUN_TIME, A.MS_LOAI_BT, A.TEN_NHOM_MAY, C.TEN_DVT_RT " & _
                " FROM         (SELECT     MS_N_XUONG " & _
                " FROM          dbo.MashjGetNXUser('" & Commons.Modules.UserName & "', '" & diadiem & "') AS MashjGetNXUser_1) AS NNX INNER JOIN " & _
                " dbo.DL_BTDK" & Commons.Modules.UserName & " AS A INNER JOIN " & _
                " dbo.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " AS B ON A.MS_MAY = B.MS_MAY AND A.MS_LOAI_BT = B.MS_LOAI_BT INNER JOIN " & _
                " dbo.DON_VI_TINH_RUN_TIME AS C ON B.MS_DVT_RT = C.MS_DVT_RT INNER JOIN " & _
                " dbo.V_MAY_NHA_XUONG_MAX AS D ON A.MS_MAY = D.MS_MAY INNER JOIN " & _
                " dbo.NHA_XUONG ON D.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON NNX.MS_N_XUONG = D.MS_N_XUONG INNER JOIN " & _
                " dbo.MAY ON A.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " & _
                " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY LEFT OUTER JOIN " & _
                " dbo.Y_Tinh INNER JOIN " & _
            " dbo.Y_District ON dbo.Y_Tinh.MA_QG = dbo.Y_District.ms_cha ON dbo.Y_District.ma_qg = dbo.NHA_XUONG.MS_QG " & _
                " WHERE     (A.NGAY_BTKT BETWEEN '" & Format(fromdate, "MM/dd/yyyy") & "' AND '" & Format(todate, "MM/dd/yyyy") & "') "

            If tinh <> "-1" Then Commons.Modules.SQLString = Commons.Modules.SQLString & _
                    " AND dbo.Y_Tinh.ma_qg = '" & tinh & "' "
            If huyen <> "-1" Then Commons.Modules.SQLString = Commons.Modules.SQLString & _
                    " AND dbo.Y_District.ma_qg = '" & huyen & "' "
            If thietbi <> "-1" Then
                Commons.Modules.SQLString = Commons.Modules.SQLString & _
                    " AND A.MS_MAY= N'" & thietbi & "'"
            End If
            If LoaiThietBi <> "-1" Then
                Commons.Modules.SQLString = Commons.Modules.SQLString & _
                    " AND dbo.NHOM_MAY.MS_LOAI_MAY = '" & LoaiThietBi & "'"
            End If
            If nhomthietbi <> "-1" Then
                Commons.Modules.SQLString = Commons.Modules.SQLString & _
                    " AND dbo.NHOM_MAY.MS_NHOM_MAY='" & nhomthietbi & "'"
            End If
            If daychuyen <> "-1" Then Commons.Modules.SQLString = Commons.Modules.SQLString & _
                    " AND (dbo.MGetHTTheoNgay(A.MS_MAY , '" & Format(DateValue(fromdate), "MM/dd/yyyy") & "') =  " & daychuyen & " )"


            If TheoGio Then
                Commons.Modules.SQLString = "SELECT DISTINCT CONVERT(BIT,0) AS chkChon, MS_MAY, TEN_LOAI_BT, NGAY_CUOI, NGAY_BTKT, TGCM, TG_THUC_HIEN + ' ' + TEN_DVT_RT AS TGCM_HIEN_TAI, MS_LOAI_BT, THU_TU, TEN_NHOM_MAY FROM (" & Commons.Modules.SQLString & ") RESULTS WHERE CONVERT(NUMERIC,RESULTS.TG_THUC_HIEN) >= RESULTS.RUN_TIME"
            Else
                Commons.Modules.SQLString = "SELECT DISTINCT CONVERT(BIT,0) AS chkChon,MS_MAY, TEN_LOAI_BT, NGAY_CUOI, NGAY_BTKT, TGCM, TG_THUC_HIEN + ' ' + TEN_DVT_RT AS TGCM_HIEN_TAI, MS_LOAI_BT, THU_TU, TEN_NHOM_MAY FROM (" & Commons.Modules.SQLString & ") RESULTS"
            End If

            Dim dtTable As New DataTable
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))

            dtTable.Columns("chkChon").ReadOnly = False
            gdBTDK.DataSource = dtTable

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvBTDK.Columns
                If col.FieldName = "chkChon" Then
                    col.Width = 50
                    col.OptionsColumn.AllowEdit = True
                    col.OptionsColumn.ReadOnly = False
                Else
                    col.Width = 200
                    col.OptionsColumn.AllowEdit = False
                    col.OptionsColumn.ReadOnly = True
                End If

                col.AppearanceHeader.Options.UseTextOptions = True
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
            Next

            gvBTDK.Columns("MS_LOAI_BT").Visible = False
            gvBTDK.Columns("THU_TU").Visible = False
        Catch ex As Exception
            gdBTDK.DataSource = Nothing
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhongThanhCong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub LoadKHType()
        Dim _vtb As New DataTable()
        _vtb.Columns.Add("Code", Type.GetType("System.String"))
        _vtb.Columns.Add("Name", Type.GetType("System.String"))
        _vtb.Rows.Add("1", "Kế hoạch năm")
        _vtb.Rows.Add("2", "Kế hoạch tháng")
        cbType.DataSource = _vtb
        cbType.DisplayMember = "Name"
        cbType.ValueMember = "Code"

        cbType.SelectedValue = KHType
        If KHType = 1 Then
            cbThang.Visible = False
            Label3.Visible = False
        Else
            cbThang.Visible = True
            Label3.Visible = True
        End If

        'AddHandler cbKHType.SelectedValueChanged, AddressOf Me.cbKHType_SelectedValueChanged
    End Sub
    Private Sub LoadNamData()
        Dim _vtb As New DataTable()
        _vtb.Columns.Add("Code", Type.GetType("System.String"))
        _vtb.Columns.Add("Name", Type.GetType("System.String"))
        _vtb.Rows.Add("2013", "2013")
        _vtb.Rows.Add("2014", "2014")
        _vtb.Rows.Add("2015", "2015")
        _vtb.Rows.Add("2016", "2016")
        _vtb.Rows.Add("2017", "2017")
        _vtb.Rows.Add("2018", "2018")
        _vtb.Rows.Add("2019", "2019")
        _vtb.Rows.Add("2020", "2020")
        cbNam.DataSource = _vtb.Copy()
        cbNam.DisplayMember = "Name"
        cbNam.ValueMember = "Code"
        cbNam.SelectedValue = KHNam
    End Sub
    Private Sub LoadThangData()
        Dim _vtb As New DataTable()
        _vtb.Columns.Add("Code", Type.GetType("System.String"))
        _vtb.Columns.Add("Name", Type.GetType("System.String"))
        _vtb.Rows.Add("01", "01")
        _vtb.Rows.Add("02", "02")
        _vtb.Rows.Add("03", "03")
        _vtb.Rows.Add("04", "04")
        _vtb.Rows.Add("05", "05")
        _vtb.Rows.Add("06", "06")
        _vtb.Rows.Add("07", "07")
        _vtb.Rows.Add("08", "08")
        _vtb.Rows.Add("09", "09")
        _vtb.Rows.Add("10", "10")
        _vtb.Rows.Add("11", "11")
        _vtb.Rows.Add("12", "12")

        cbThang.DataSource = _vtb
        cbThang.DisplayMember = "Name"
        cbThang.ValueMember = "Code"
        If KHType = 1 Then
            cbThang.SelectedValue = Date.Now.ToString("MM")
        Else
            cbThang.SelectedValue = KHThang.ToString("0#")
        End If
    End Sub

    Private Sub frmKHTT_BTDKChoose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadKHType()
        LoadNamData()
        LoadThangData()

        If KHType = 1 Then
            fromdate = New DateTime(KHNam, 1, 1)
            todate = New DateTime(KHNam, 12, 31)
        Else
            fromdate = New DateTime(KHNam, KHThang, 1)
            todate = New DateTime(KHNam, KHThang, Date.DaysInMonth(KHNam, KHThang))
        End If
        cbType.Enabled = False
        cbNam.Enabled = False
        cbThang.Enabled = False

        Dim _tblUUTien = New DataTable()
        _tblUUTien.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIENs"))
        Dim repositoryItemLookUpEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        repositoryItemLookUpEdit3.NullText = ""
        repositoryItemLookUpEdit3.ValueMember = "MS_UU_TIEN"
        repositoryItemLookUpEdit3.DisplayMember = "TEN_UU_TIEN"
        repositoryItemLookUpEdit3.DataSource = _tblUUTien
        repositoryItemLookUpEdit3.Columns.Clear()
        repositoryItemLookUpEdit3.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_UU_TIEN"))
        MS_UU_TIEN.ColumnEdit = repositoryItemLookUpEdit3
        getDataBTDK()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If CheckDataBeforeCreateKH() = False Then
            Exit Sub
        End If

        If gdBTDK.DataSource Is Nothing Then Exit Sub
        Dim i As Integer = 0
        Dim strTenHangMuc As String
        Dim blnChon As Boolean = False
        Dim HangMucID As Integer = -1
        Dim _dt As New DataTable
        Dim _temp As New DataTable()
        _dt = CType(gdBTDK.DataSource, DataTable)

        _temp = _dt.Copy()
        _temp.DefaultView.RowFilter = "chkChon=True"

        _temp = _temp.DefaultView.ToTable()
        If _temp.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_RECORD", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim sql As String = "SELECT ISNULL(MAX(HANG_MUC_ID),0) FROM KE_HOACH_TONG_THE"
        j = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        j = j + 1

        Dim tran As SqlTransaction
        Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        tran = con.BeginTransaction()
        Dim _dt_temp As New DataTable()
        Try
            For Each _row As DataRow In _temp.Rows
                Dim _sql As String = "SET IDENTITY_INSERT KE_HOACH_TONG_THE ON"
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, _sql)
                strTenHangMuc = "Chuyển từ BTPN " & _row("TEN_HANG_MUC")
                Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_THE(HANG_MUC_ID,MS_MAY,NGAY,MS_LOAI_BT ,NGAY_BTPN,TEN_HANG_MUC,LY_DO_SC,NGAY_DK_HT,USERNAME , MS_UU_TIEN, CP_VT_NN_NGOAI_DM, CP_VT_NGOAI_DM, CP_THUE_NGOAI ) VALUES(" & j & ",N'" & _row("MS_MAY") & "','" & Format(_row("TU_NGAY"), "MM/dd/yyyy") & "'," & _row("MS_LOAI_BT") & ",'" & Format(_row("TU_NGAY"), "MM/dd/yyyy") & "',N'" & strTenHangMuc & "',2,'" & Format(_row("DEN_NGAY"), "MM/dd/yyyy") & "','" & Commons.Modules.UserName & "'" & _
                " ,'" & _row("MS_UU_TIEN") & "' , '" & _row("CP_VT_NN_NGOAI_DM") & "' , '" & _row("CP_VT_NGOAI_DM") & "', '" & _row("CP_THUE_NGOAI") & "')"
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                'Them vao khbt chi tiet
                If KHType = "1" Then
                    Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_THE_CHI_TIET (MA_HANG_MUC, KH_NAM ,TU_NGAY, DEN_NGAY , KH_TYPE , MS_UU_TIEN, CP_VT_NN_NGOAI_DM, CP_VT_NGOAI_DM, CP_THUE_NGOAI )   VALUES(" & j & " , '" & KHNam & "', '" & Format(_row("TU_NGAY"), "MM/dd/yyyy") & "' , '" & Format(_row("DEN_NGAY"), "MM/dd/yyyy") & "' ,'1' " & _
                   " ,'" & _row("MS_UU_TIEN") & "' , '" & _row("CP_VT_NN_NGOAI_DM") & "' , '" & _row("CP_VT_NGOAI_DM") & "', '" & _row("CP_THUE_NGOAI") & "')"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                ElseIf KHType = "2" Then
                    Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_THE_CHI_TIET (MA_HANG_MUC, KH_NAM , KH_THANG , TU_NGAY , DEN_NGAY, KH_TYPE, MS_UU_TIEN, CP_VT_NN_NGOAI_DM, CP_VT_NGOAI_DM, CP_THUE_NGOAI ) VALUES(" & j & " , '" & KHNam & "' , '" & KHThang & "' , '" & Format(_row("TU_NGAY"), "MM/dd/yyyy") & "' , '" & Format(_row("DEN_NGAY"), "MM/dd/yyyy") & "' ,'2' " & _
                    " ,'" & _row("MS_UU_TIEN") & "' , '" & _row("CP_VT_NN_NGOAI_DM") & "' , '" & _row("CP_VT_NGOAI_DM") & "', '" & _row("CP_THUE_NGOAI") & "')"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                End If

                Try
                    SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_THE_LOG", j, Me.Name, Commons.Modules.UserName, 1)
                Catch ex As Exception

                End Try
                Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC(MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN , MS_UU_TIEN) SELECT N'" & _row("MS_MAY") & "'," & j & ", MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN , '" & _row("MS_UU_TIEN") & "' AS MS_UU_TIEN FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CAU_TRUC_THIET_BI_CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY AND MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN = CAU_TRUC_THIET_BI_CONG_VIEC.MS_BO_PHAN AND MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV WHERE MAY_LOAI_BTPN_CONG_VIEC.MS_MAY=N'" & _row("MS_MAY") & "' AND MAY_LOAI_BTPN_CONG_VIEC.MS_LOAI_BT=" & _row("MS_LOAI_BT")
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                'Them vao khbt cong viec chi tiet
                If KHType = "1" Then
                    Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC_CHI_TIET( MS_MAY, MA_HANG_MUC, MA_CV, MA_BO_PHAN, KH_NAM , TU_NGAY , DEN_NGAY , KH_TYPE , MS_UU_TIEN, TG_KH ) SELECT N'" & _
                    _row("MS_MAY") & "'," & j & ", MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN , '" & KHNam & "' AS KH_NAM  , '" & Format(_row("TU_NGAY"), "MM/dd/yyyy") & "' , '" & Format(_row("DEN_NGAY"), "MM/dd/yyyy") & "' , '1' AS KH_TYPE , '" & _row("MS_UU_TIEN") & "' AS MS_UU_TIEN, TG_KH   FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CAU_TRUC_THIET_BI_CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY AND MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN = CAU_TRUC_THIET_BI_CONG_VIEC.MS_BO_PHAN AND MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV WHERE MAY_LOAI_BTPN_CONG_VIEC.MS_MAY=N'" & _row("MS_MAY") & "' AND MAY_LOAI_BTPN_CONG_VIEC.MS_LOAI_BT=" & _row("MS_LOAI_BT")
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                ElseIf KHType = "2" Then
                    Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC_CHI_TIET( MS_MAY, MA_HANG_MUC, MA_CV, MA_BO_PHAN, KH_NAM , KH_THANG ,TU_NGAY , DEN_NGAY, KH_TYPE,MS_UU_TIEN, TG_KH) SELECT N'" & _
                    _row("MS_MAY") & "'," & j & ", MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN , '" & KHNam & "' AS KH_NAM, '" & KHThang & "' AS KH_THANG , '" & Format(_row("TU_NGAY"), "MM/dd/yyyy") & "' , '" & Format(_row("DEN_NGAY"), "MM/dd/yyyy") & "' , '2' AS KH_TYPE , '" & _row("MS_UU_TIEN") & "' AS MS_UU_TIEN , TG_KH  FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CAU_TRUC_THIET_BI_CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY AND MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN = CAU_TRUC_THIET_BI_CONG_VIEC.MS_BO_PHAN AND MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV WHERE MAY_LOAI_BTPN_CONG_VIEC.MS_MAY=N'" & _row("MS_MAY") & "' AND MAY_LOAI_BTPN_CONG_VIEC.MS_LOAI_BT=" & _row("MS_LOAI_BT")
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                End If

                Try
                    Dim vtb As New DataTable
                    sql = "SELECT N'" & _row("MS_MAY") & "' as MS_MAY ," & j & " as HANG_MUC_ID , MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CAU_TRUC_THIET_BI_CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY AND MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN = CAU_TRUC_THIET_BI_CONG_VIEC.MS_BO_PHAN AND MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV WHERE MAY_LOAI_BTPN_CONG_VIEC.MS_MAY=N'" & _row("MS_MAY") & "' AND MAY_LOAI_BTPN_CONG_VIEC.MS_LOAI_BT=" & _row("MS_LOAI_BT")
                    vtb.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, sql))
                    For Each vr As DataRow In vtb.Rows
                        SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_LOG", vr("MS_MAY"), vr("HANG_MUC_ID"), vr("MS_CV"), vr("MS_BO_PHAN"), Me.Name, Commons.Modules.UserName, 1)

                    Next
                Catch ex As Exception

                End Try

                Commons.Modules.SQLString = "SELECT DISTINCT HANG_MUC_ID,MS_CV FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID NOT IN (SELECT HANG_MUC_ID FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY ='" & _row("MS_MAY") & "') AND MS_MAY=N'" & _row("MS_MAY") & "' AND HANG_MUC_ID=" & j
                _dt_temp = New DataTable()
                _dt_temp.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString))
                For Each _dt_row In _dt_temp.Rows
                    If KHType = "1" Then
                        Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET(KH_TYPE, KH_NAM,KH_THANG,KH_TUAN,MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG) SELECT '1' AS KH_TYPE,'" & KHNam & "' AS KH_NAM,NULL AS KH_THANG,NULL AS KH_TUAN , '" & _row("MS_MAY") & "'," & _dt_row(0) & "," & _dt_row(1) & ",MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & _dt_row(1)
                        SqlHelper.ExecuteScalar(tran, CommandType.Text, Commons.Modules.SQLString)
                    Else
                        Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET(KH_TYPE, KH_NAM,KH_THANG,KH_TUAN,MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG) SELECT '2' AS KH_TYPE,  '" & KHNam & "' AS KH_NAM, '" & KHThang & "' AS KH_THANG, NULL AS KH_TUAN , '" & _row("MS_MAY") & "'," & _dt_row(0) & "," & _dt_row(1) & ",MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & _dt_row(1)
                        SqlHelper.ExecuteScalar(tran, CommandType.Text, Commons.Modules.SQLString)
                    End If
                    Try
                        sql = "SELECT '" & _row("MS_MAY") & "' as MS_MAY ," & _dt_row(0) & " as HANG_MUC_ID ," & _dt_row(1) & " as MS_CV ,MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & _dt_row(1)
                        Dim vtb As New DataTable
                        vtb.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, sql))
                        For Each vr As DataRow In vtb.Rows
                            SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_LOG", vr("MS_MAY"), vr("HANG_MUC_ID"), vr("MS_CV"), vr("MS_BO_PHAN"), vr("MS_PT"), Me.Name, Commons.Modules.UserName, 1)
                        Next
                    Catch ex As Exception

                    End Try
                Next
                j = j + 1
            Next
            tran.Commit()
            con.Close()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            tran.Rollback()
            con.Close()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TAO_KHBT_KO_THANH_CONG", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)

        End Try


        'Dim dtb As New DataTable
        'dtb = CType(gdBTDK.DataSource, DataTable)

        'Dim dvTmp As New DataView(CType(gdBTDK.DataSource, DataTable), "chkChon = true", "MS_MAY", DataViewRowState.CurrentRows)
        'DataBTDKSelected = dvTmp.ToTable()
    End Sub
    Private Function CheckDataBeforeCreateKH() As Boolean
        Dim _vtb As DataView
        _vtb = CType(gvBTDK.DataSource, DataView)
        Dim _vtbChoose As New DataView(_vtb.ToTable(), "chkChon = true", "MS_MAY", DataViewRowState.CurrentRows)
        'KTRA CHON
        If _vtbChoose.ToTable().Rows.Count <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_THIET_BI", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
            Return False
        End If
        'KTRA NGAY
        Dim _GioiHanTuNgay As String = ""
        Dim _ngayHienTai As String = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)

        If KHType = "1" Then
            _GioiHanTuNgay = KHNam.ToString("####") + "0101"
        Else
            _GioiHanTuNgay = KHNam.ToString("####") + KHThang.ToString("0#") + "01"
        End If

        For i As Integer = 0 To _vtbChoose.ToTable().Rows.Count - 1

            If _vtbChoose.ToTable().Rows(i)("TEN_HANG_MUC").ToString.Trim = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHAI_NHAP_TEN_HANG_MUC", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                Return False
            End If

            If _vtbChoose.ToTable().Rows(i)("TU_NGAY").ToString().Trim() = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHAI_NHAP_TU_NGAY", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                Return False
            End If

            If _vtbChoose.ToTable().Rows(i)("DEN_NGAY").ToString().Trim() = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHAI_NHAP_DEN_NGAY", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                Return False
            End If

            Dim _tu_ngaytmp As String = CType(_vtbChoose.ToTable().Rows(i)("TU_NGAY"), DateTime).ToString("yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)
            Dim _den_ngaytmp As String = CType(_vtbChoose.ToTable().Rows(i)("DEN_NGAY"), DateTime).ToString("yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)

            If _tu_ngaytmp > _den_ngaytmp Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY_PHAI_NHO_HON_DEN_NGAY", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                Return False
            End If

            If KHType = "1" Then
                If _GioiHanTuNgay > _tu_ngaytmp Or _GioiHanTuNgay.Substring(0, 4) <> _tu_ngaytmp.Substring(0, 4) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY_PHAI_NAM_TRONG_GIOI_HAN_NAM", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                    Return False
                End If
            Else
                If _GioiHanTuNgay > _tu_ngaytmp Or _GioiHanTuNgay.Substring(0, 6) <> _tu_ngaytmp.Substring(0, 6) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY_PHAI_NAM_TRONG_GIOI_HAN_THANG", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnBoChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoChonAll.Click
        For r As Integer = 0 To gvBTDK.RowCount - 1
            CType(gdBTDK.DataSource, DataTable).Rows(r)("chkChon") = False
        Next
    End Sub

    Private Sub btnChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonAll.Click
        For r As Integer = 0 To gvBTDK.RowCount - 1
            CType(gdBTDK.DataSource, DataTable).Rows(r)("chkChon") = True
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        getDataBTDK()
    End Sub
End Class