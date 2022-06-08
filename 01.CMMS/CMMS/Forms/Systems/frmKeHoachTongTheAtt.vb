Imports Commons.VS.Classes.Admin
Imports Commons.VS.Classes.Catalogue
Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.DateAndTime
Imports System.IO
Public Class frmKeHoachTongTheAtt

    Private Sub frmKeHoachTongTheAtt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        BindDataBTDK()
        dtpDenNgayBTDK1.Focus()
        If Commons.Modules.PermisString.Equals("Read only") Then
            BtnLapPBT.Enabled = False
        Else
            BtnLapPBT.Enabled = True
        End If
    End Sub
    Private Sub dtpDenNgayBTDK1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDenNgayBTDK1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpDenNgayBTDK1.Text = "  /  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GIO_NHAP_NULL", commons.Modules.TypeLanguage))
                Me.dtpDenNgayBTDK1.Focus()
            ElseIf Not IsDate(dtpDenNgayBTDK1.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GIO_NHAP_ERROR", commons.Modules.TypeLanguage))
                Me.dtpDenNgayBTDK1.Focus()
            Else
                Me.Cursor = Cursors.WaitCursor
                LayDuLieu()
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub
    Sub BindDataBTDK()
        LoadLoaiMay()
        LoadNhomMay()
        LoadMay()
        LoadNguoiLap()
    End Sub
    Sub LoadNguoiLap()
        cboNguoiLap.Value = "MS_CONG_NHAN"
        cboNguoiLap.Display = "HO_TEN_CONG_NHAN"
        cboNguoiLap.StoreName = "GetCONG_NHANs1"
        cboNguoiLap.BindDataSource()
    End Sub
    Sub LoadMay()
        Try
            CboMaSoThietBiBTDK.Value = "MS_MAY"
            CboMaSoThietBiBTDK.Display = "MSMAY"
            If CboNhomThietBiBTDK.SelectedValue Is Nothing Then
                CboMaSoThietBiBTDK.DataSource = Nothing
            ElseIf CboNhomThietBiBTDK.SelectedValue.ToString = "-1" Then
                CboMaSoThietBiBTDK.Param = cboLoaiThietBiBTDK.SelectedValue
                CboMaSoThietBiBTDK.StoreName = "GetMAY_KHTT_LOAI_MAY"
                CboMaSoThietBiBTDK.BindDataSource()
            Else
                CboMaSoThietBiBTDK.Param = CboNhomThietBiBTDK.SelectedValue
                CboMaSoThietBiBTDK.StoreName = "GetMAY_KHTT_NHOM_MAY"
                CboMaSoThietBiBTDK.BindDataSource()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub LoadLoaiMay()
        cboLoaiThietBiBTDK.Value = "MS_LOAI_MAY"
        cboLoaiThietBiBTDK.Display = "TEN_LOAI_MAY"
        cboLoaiThietBiBTDK.Param = Commons.Modules.UserName
        cboLoaiThietBiBTDK.StoreName = "GetLOAI_MAY_ATT" ' "GetLOAI_MAY_SEC"
        cboLoaiThietBiBTDK.BindDataSource()
    End Sub

    Sub LoadNhomMay()
        Try
            CboNhomThietBiBTDK.Value = "MS_NHOM_MAY"
            CboNhomThietBiBTDK.Display = "TEN_NHOM_MAY"
            CboNhomThietBiBTDK.Param = cboLoaiThietBiBTDK.SelectedValue
            CboNhomThietBiBTDK.StoreName = "PermisionNHOM_MAY_KHTT"
            CboNhomThietBiBTDK.BindDataSource()
        Catch ex As Exception

        End Try
    End Sub
    Sub LayDuLieu()
        If (CboMaSoThietBiBTDK.Text = "" Or IsDBNull(CboMaSoThietBiBTDK)) And (cboLoaiThietBiBTDK.Text = "" Or IsDBNull(cboLoaiThietBiBTDK)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenKT1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            'Không có dữ liệu 
            Exit Sub
        End If
        If dtpDenNgayBTDK1.Text = "  /  /" Then
            Exit Sub
        ElseIf Not IsDate(dtpDenNgayBTDK1.Text) Then
            Exit Sub
        End If
        Dim objLichBTPN As New clsLichBTPN
        objLichBTPN.TaoDuLieu(DateValue(Me.dtpDenNgayBTDK1.Text))
        objLichBTPN.XoaP4CK(prgBTDK)
        layDuLieuSub()
    End Sub
    Sub layDuLieuSub()
        Try
            grdDanhsachBTDKcanthuchien.DataSource = DBNull.Value
        Catch ex As Exception

        End Try

        Try
            commons.Modules.SQLString = "DROP TABLE DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
        Catch ex As Exception

        End Try

        commons.Modules.SQLString = "SELECT MAY_LOAI_BTPN_CHU_KY.* INTO DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " FROM (SELECT MS_MAY,MS_LOAI_BT,MAX(NGAY_AD) AS NGAY_AD_MAX FROM MAY_LOAI_BTPN_CHU_KY GROUP BY MS_MAY,MS_LOAI_BT) AS TAM INNER JOIN MAY_LOAI_BTPN_CHU_KY ON TAM.MS_MAY=MAY_LOAI_BTPN_CHU_KY.MS_MAY AND TAM.MS_LOAI_BT=MAY_LOAI_BTPN_CHU_KY.MS_LOAI_BT AND TAM.NGAY_AD_MAX=MAY_LOAI_BTPN_CHU_KY.NGAY_AD ORDER BY MAY_LOAI_BTPN_CHU_KY.MS_MAY,MAY_LOAI_BTPN_CHU_KY.MS_LOAI_BT"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

        Try
            commons.Modules.SQLString = "DROP TABLE DBO.DL_BTDK" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
        Catch EX As Exception

        End Try
        'sua cho att
        commons.Modules.SQLString = "SELECT TEN_NHOM_MAY,DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY,TEN_N_XUONG,TEN_LOAI_BT,MAY_LOAI_BTPN.NGAY_CUOI,DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI AS NGAY_BTKT,CAST(RUN_TIME AS NVARCHAR) + ' ' + TEN_DVT_RT AS TGCM,NULL AS TGCM_HIEN_TAI,MOVEMENT,NULL AS MOVEMENT_HIEN_TAI,LOAI_BAO_TRI.MS_LOAI_BT INTO DBO.DL_BTDK" & Commons.Modules.UserName & " FROM DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " INNER JOIN MAY ON DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY=MAY.MS_MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_BAO_TRI ON DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_LOAI_BT=LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " ON DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY = DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_MAY And DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_LOAI_BT = DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_LOAI_BT INNER JOIN DON_VI_TINH_RUN_TIME ON DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT INNER JOIN V_MAY_NHA_XUONG_MAX ON MAY.MS_MAY=V_MAY_NHA_XUONG_MAX.MS_MAY INNER JOIN NHA_XUONG ON NHA_XUONG.MS_N_XUONG=V_MAY_NHA_XUONG_MAX.MS_N_XUONG INNER JOIN MAY_LOAI_BTPN ON MAY_LOAI_BTPN.MS_MAY=DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_MAY AND MAY_LOAI_BTPN.MS_LOAI_BT=DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_LOAI_BT WHERE DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI NOT IN (SELECT NGAY_BTPN FROM KE_HOACH_TONG_THE WHERE NGAY_BTPN IS NOT NULL AND MS_MAY IN (SELECT MS_MAY FROM DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ")) AND DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI NOT IN (SELECT NGAY_BTPN FROM PHIEU_BAO_TRI WHERE NGAY_BTPN IS NOT NULL AND MS_MAY IN (SELECT MS_MAY FROM DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ")) ORDER BY TEN_NHOM_MAY,DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY,TEN_N_XUONG,LOAI_BAO_TRI.MS_LOAI_BT,DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI"
        commons.Modules.SQLString = "SELECT TEN_NHOM_MAY,DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY,null as  TEN_N_XUONG,TEN_LOAI_BT,MAY_LOAI_BTPN.NGAY_CUOI,DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI AS NGAY_BTKT,/*CAST(RUN_TIME AS NVARCHAR) + ' ' + TEN_DVT_RT*/null AS TGCM,NULL AS TGCM_HIEN_TAI,MOVEMENT,NULL AS MOVEMENT_HIEN_TAI,LOAI_BAO_TRI.MS_LOAI_BT INTO DBO.DL_BTDK" & Commons.Modules.UserName & " FROM DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & " INNER JOIN MAY ON DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY=MAY.MS_MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_BAO_TRI ON DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_LOAI_BT=LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " ON DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY = DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_MAY And DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_LOAI_BT = DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_LOAI_BT /*INNER JOIN DON_VI_TINH_RUN_TIME ON DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_DVT_RT=DON_VI_TINH_RUN_TIME.MS_DVT_RT INNER JOIN V_MAY_NHA_XUONG_MAX ON MAY.MS_MAY=V_MAY_NHA_XUONG_MAX.MS_MAY INNER JOIN NHA_XUONG ON NHA_XUONG.MS_N_XUONG=V_MAY_NHA_XUONG_MAX.MS_N_XUONG*/ INNER JOIN MAY_LOAI_BTPN ON MAY_LOAI_BTPN.MS_MAY=DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_MAY AND MAY_LOAI_BTPN.MS_LOAI_BT=DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & ".MS_LOAI_BT WHERE DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI NOT IN (SELECT NGAY_BTPN FROM KE_HOACH_TONG_THE WHERE NGAY_BTPN IS NOT NULL AND MS_MAY IN (SELECT MS_MAY FROM DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ")) AND DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI NOT IN (SELECT NGAY_BTPN FROM PHIEU_BAO_TRI WHERE NGAY_BTPN IS NOT NULL AND MS_MAY IN (SELECT MS_MAY FROM DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ")) ORDER BY TEN_NHOM_MAY,DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".MS_MAY,/*TEN_N_XUONG,*/LOAI_BAO_TRI.MS_LOAI_BT,DBO.DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName & ".NGAY_CUOI"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

        commons.Modules.SQLString = "SELECT MS_MAY,MIN(NGAY_BTKT) AS NGAY INTO DBO.BT_TMP" & Commons.Modules.UserName & " FROM DBO.DL_BTDK" & Commons.Modules.UserName & " GROUP BY MS_MAY"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

        commons.Modules.SQLString = "SELECT A.MS_MAY,NGAY_CUOI,NGAY AS NGAY_BT INTO NGAY_CUOI_TMP" & Commons.Modules.UserName & " FROM DBO.BT_TMP" & Commons.Modules.UserName & " A INNER JOIN DBO.DL_BTDK" & Commons.Modules.UserName & " B ON A.MS_MAY=B.MS_MAY AND A.NGAY=B.NGAY_BTKT"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
        'att có thể không cần thực hiện
        commons.Modules.SQLString = "UPDATE A SET A.MOVEMENT_HIEN_TAI=B.MOVEMENT_HIEN_TAI FROM DBO.DL_BTDK" & Commons.Modules.UserName & " A LEFT JOIN (SELECT THOI_GIAN_CHAY_MAY.MS_MAY,SUM(SO_MOVEMENT) AS MOVEMENT_HIEN_TAI FROM THOI_GIAN_CHAY_MAY INNER JOIN NGAY_CUOI_TMP" & Commons.Modules.UserName & " ON THOI_GIAN_CHAY_MAY.MS_MAY=NGAY_CUOI_TMP" & Commons.Modules.UserName & ".MS_MAY WHERE NGAY>NGAY_CUOI AND NGAY<='" & Format(CType(dtpDenNgayBTDK1.Text, Date), "MM/dd/yyyy") & "' GROUP BY THOI_GIAN_CHAY_MAY.MS_MAY) B ON A.MS_MAY=B.MS_MAY LEFT JOIN NGAY_CUOI_TMP" & Commons.Modules.UserName & " C ON A.MS_MAY=C.MS_MAY WHERE A.NGAY_BTKT=C.NGAY_BT"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

        'commons.Modules.SQLString = "UPDATE A SET A.TGCM_HIEN_TAI=B.TGCM_HIEN_TAI FROM DBO.DL_BTDK" & Commons.Modules.UserName & " A LEFT JOIN (SELECT TAM_MAX.MS_MAY,CHI_SO_DONG_HO_MAX-CHI_SO_DONG_HO_MIN AS TGCM_HIEN_TAI FROM (SELECT THOI_GIAN_CHAY_MAY.MS_MAY,MAX(CHI_SO_DONG_HO) AS CHI_SO_DONG_HO_MAX FROM THOI_GIAN_CHAY_MAY INNER JOIN NGAY_CUOI_TMP" & Commons.Modules.UserName & " ON THOI_GIAN_CHAY_MAY.MS_MAY=NGAY_CUOI_TMP" & Commons.Modules.UserName & ".MS_MAY WHERE NGAY>NGAY_CUOI AND NGAY<='" & Format(CType(dtpDenNgayBTDK1.Text, Date), "MM/dd/yyyy") & "' GROUP BY THOI_GIAN_CHAY_MAY.MS_MAY) AS TAM_MAX INNER JOIN (SELECT THOI_GIAN_CHAY_MAY.MS_MAY,MIN(CHI_SO_DONG_HO) AS CHI_SO_DONG_HO_MIN FROM THOI_GIAN_CHAY_MAY INNER JOIN NGAY_CUOI_TMP" & Commons.Modules.UserName & " ON THOI_GIAN_CHAY_MAY.MS_MAY=NGAY_CUOI_TMP" & Commons.Modules.UserName & ".MS_MAY WHERE NGAY>NGAY_CUOI AND NGAY<='" & Format(CType(dtpDenNgayBTDK1.Text, Date), "MM/dd/yyyy") & "' GROUP BY THOI_GIAN_CHAY_MAY.MS_MAY) AS TAM_MIN ON TAM_MAX.MS_MAY=TAM_MIN.MS_MAY)  B ON A.MS_MAY=B.MS_MAY LEFT JOIN NGAY_CUOI_TMP" & Commons.Modules.UserName & " C ON A.MS_MAY=C.MS_MAY WHERE A.NGAY_BTKT=C.NGAY_BT"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

        TaoLuoiBTDK()

        Try
            commons.Modules.SQLString = "DROP TABLE DBO.PHU" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
        Catch ex As Exception

        End Try

        Try
            commons.Modules.SQLString = "DROP TABLE NGAY_CUOI_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
        Catch ex As Exception

        End Try

        Try
            commons.Modules.SQLString = "DROP TABLE DBO.BT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
        Catch ex As Exception

        End Try
    End Sub
    Sub TaoLuoiBTDK()
        If CboMaSoThietBiBTDK.SelectedValue <> "-1" Then
            commons.Modules.SQLString = "SELECT A.MS_MAY,TEN_LOAI_BT,NGAY_CUOI,NGAY_BTKT,CONVERT(NVARCHAR(10),RUN_TIME)+' '+TEN_DVT_RT AS TGCM,CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0) from thoi_gian_chay_may " & _
            " where MS_MAY = A.MS_MAY AND NGAY>CASE MS_DV_TG WHEN 1 THEN DATEADD(DAY,-CHU_KY,NGAY_BTKT)WHEN 2 THEN DATEADD(DAY,-CHU_KY*7,NGAY_BTKT) " & _
            " WHEN 3 THEN DATEADD(MONTH,-CHU_KY,NGAY_BTKT)ELSE DATEADD(YEAR,-CHU_KY,NGAY_BTKT) END  " & _
            " AND NGAY <NGAY_BTKT) AS NVARCHAR) + ' ' + TEN_DVT_RT AS TGCM_HIEN_TAI/*,A.MOVEMENT,MOVEMENT_HIEN_TAI*/,A.MS_LOAI_BT,TEN_NHOM_MAY/*,TEN_N_XUONG*/ FROM DBO.DL_BTDK" & Commons.Modules.UserName & " A INNER JOIN DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " B ON A.MS_MAY = B.MS_MAY And A.MS_LOAI_BT = B.MS_LOAI_BT INNER JOIN MAY ON MAY.MS_MAY=A.MS_MAY  left JOIN DON_VI_TINH_RUN_TIME C ON MAY.MS_DVT_RT=C.MS_DVT_RT WHERE A.MS_MAY=N'" & CboMaSoThietBiBTDK.SelectedValue & "'"
        Else
            If CboNhomThietBiBTDK.SelectedValue.ToString = "-1" Then
                commons.Modules.SQLString = "SELECT A.MS_MAY,TEN_LOAI_BT,NGAY_CUOI,NGAY_BTKT,CONVERT(NVARCHAR(10),RUN_TIME)+' '+TEN_DVT_RT AS TGCM,CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0) from thoi_gian_chay_may " & _
                " where MS_MAY = A.MS_MAY AND NGAY>CASE MS_DV_TG WHEN 1 THEN DATEADD(DAY,-CHU_KY,NGAY_BTKT)WHEN 2 THEN DATEADD(DAY,-CHU_KY*7,NGAY_BTKT) " & _
                " WHEN 3 THEN DATEADD(MONTH,-CHU_KY,NGAY_BTKT)ELSE DATEADD(YEAR,-CHU_KY,NGAY_BTKT) END  " & _
                " AND NGAY <NGAY_BTKT) AS NVARCHAR) + ' ' + TEN_DVT_RT AS TGCM_HIEN_TAI/*,A.MOVEMENT,MOVEMENT_HIEN_TAI*/,A.MS_LOAI_BT,E.TEN_NHOM_MAY/*,TEN_N_XUONG*/ FROM DBO.DL_BTDK" & Commons.Modules.UserName & " A INNER JOIN DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " B ON A.MS_MAY = B.MS_MAY And A.MS_LOAI_BT = B.MS_LOAI_BT /*left JOIN DON_VI_TINH_RUN_TIME C ON B.MS_DVT_RT=C.MS_DVT_RT INNER JOIN V_MAY_NHA_XUONG_MAX D ON A.MS_MAY=D.MS_MAY*/ INNER JOIN MAY ON A.MS_MAY=MAY.MS_MAY INNER JOIN NHOM_MAY E ON MAY.MS_NHOM_MAY=E.MS_NHOM_MAY left JOIN DON_VI_TINH_RUN_TIME C ON MAY.MS_DVT_RT=C.MS_DVT_RT WHERE MS_LOAI_MAY='" & cboLoaiThietBiBTDK.SelectedValue & "'"
            Else
                commons.Modules.SQLString = "SELECT A.MS_MAY,TEN_LOAI_BT,NGAY_CUOI,NGAY_BTKT,CONVERT(NVARCHAR(10),RUN_TIME)+' '+TEN_DVT_RT AS TGCM,CAST((select ISNULL(SUM(CHI_SO_DONG_HO),0) from thoi_gian_chay_may " & _
                " where MS_MAY = A.MS_MAY AND NGAY>CASE MS_DV_TG WHEN 1 THEN DATEADD(DAY,-CHU_KY,NGAY_BTKT)WHEN 2 THEN DATEADD(DAY,-CHU_KY*7,NGAY_BTKT) " & _
                " WHEN 3 THEN DATEADD(MONTH,-CHU_KY,NGAY_BTKT)ELSE DATEADD(YEAR,-CHU_KY,NGAY_BTKT) END  " & _
                " AND NGAY <NGAY_BTKT) AS NVARCHAR) + ' ' + TEN_DVT_RT AS TGCM_HIEN_TAI/*,A.MOVEMENT,MOVEMENT_HIEN_TAI*/,A.MS_LOAI_BT,TEN_NHOM_MAY/*,TEN_N_XUONG*/ FROM DBO.DL_BTDK" & Commons.Modules.UserName & " A INNER JOIN DBO.MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName & " B ON A.MS_MAY = B.MS_MAY And A.MS_LOAI_BT = B.MS_LOAI_BT /*left JOIN DON_VI_TINH_RUN_TIME C ON B.MS_DVT_RT=C.MS_DVT_RT INNER JOIN V_MAY_NHA_XUONG_MAX D ON A.MS_MAY=D.MS_MAY*/ INNER JOIN MAY ON A.MS_MAY=MAY.MS_MAY left JOIN DON_VI_TINH_RUN_TIME C ON MAY.MS_DVT_RT=C.MS_DVT_RT WHERE MS_NHOM_MAY='" & Me.CboNhomThietBiBTDK.SelectedValue & "'"
            End If
        End If
        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        Try
            grdDanhsachBTDKcanthuchien.Columns.Clear()
        Catch ex As Exception

        End Try
        grdDanhsachBTDKcanthuchien.DataSource = dtTable
        Dim dgCol As New DataGridViewCheckBoxColumn
        With dgCol
            .Name = "chkChon"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With
        grdDanhsachBTDKcanthuchien.Columns.Insert(0, dgCol)
        'grdDanhsachBTDKcanthuchien.Columns(0).Frozen = True
        grdDanhsachBTDKcanthuchien.Columns("MS_LOAI_BT").Visible = False
        Dim i As Integer = 0
        For i = 1 To grdDanhsachBTDKcanthuchien.Columns.Count - 1
            grdDanhsachBTDKcanthuchien.Columns(i).ReadOnly = True
        Next
        Try
            Me.grdDanhsachBTDKcanthuchien.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachBTDKcanthuchien.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try

        RefreshLanguage()
    End Sub
    Sub RefreshLanguage()
        Try
            Me.grdDanhsachBTDKcanthuchien.Columns("TEN_NHOM_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_NHOM_MAY", commons.Modules.TypeLanguage)
            Me.grdDanhsachBTDKcanthuchien.Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_MAY", commons.Modules.TypeLanguage)
            'Me.grdDanhsachBTDKcanthuchien.Columns("TEN_N_XUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_N_XUONG", commons.Modules.TypeLanguage)
            Me.grdDanhsachBTDKcanthuchien.Columns("TEN_LOAI_BT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LOAI_BT", commons.Modules.TypeLanguage)
            Me.grdDanhsachBTDKcanthuchien.Columns("NGAY_CUOI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_CUOI", commons.Modules.TypeLanguage)
            Me.grdDanhsachBTDKcanthuchien.Columns("TGCM").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TGCM", commons.Modules.TypeLanguage)
            Me.grdDanhsachBTDKcanthuchien.Columns("chkCHON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "chkCHON", commons.Modules.TypeLanguage)
            Me.grdDanhsachBTDKcanthuchien.Columns("TGCM_HIEN_TAI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TGCM_HIEN_TAI", commons.Modules.TypeLanguage)
            Me.grdDanhsachBTDKcanthuchien.Columns("NGAY_BTKT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_BTKT", commons.Modules.TypeLanguage)
            Me.grdDanhsachBTDKcanthuchien.Columns("TEN_NHOM_MAY").Width = 150
            Me.grdDanhsachBTDKcanthuchien.Columns("MS_MAY").Width = 120
            Me.grdDanhsachBTDKcanthuchien.Columns("chkCHON").Width = 60
            Me.grdDanhsachBTDKcanthuchien.Columns("TEN_LOAI_BT").Width = 120
            Me.grdDanhsachBTDKcanthuchien.Columns("NGAY_CUOI").Width = 90
            Me.grdDanhsachBTDKcanthuchien.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachBTDKcanthuchien.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cboLoaiThietBiBTDK_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoaiThietBiBTDK.SelectionChangeCommitted
        LoadNhomMay()
        LoadMay()
    End Sub

    Private Sub CboNhomThietBiBTDK_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboNhomThietBiBTDK.SelectionChangeCommitted
        LoadMay()
    End Sub

    Private Sub BtnLapPBT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLapPBT.Click
        Dim i As Integer = 0
        Dim strGioTam, MS_PBT As String
        strGioTam = TimeValue(Now)
        Dim blnChon As Boolean = False
        If IsDBNull(cboNguoiLap.SelectedValue) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenKT22", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            cboNguoiLap.Focus()
            Exit Sub
        End If
        While i < grdDanhsachBTDKcanthuchien.RowCount
            If grdDanhsachBTDKcanthuchien.Rows(i).Cells("chkChon").Value = True Then
                blnChon = True
            End If
            i += 1
        End While
        If blnChon = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenKT24", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        i = 0
        Dim dtReader As SqlDataReader
        While i < grdDanhsachBTDKcanthuchien.RowCount
            If grdDanhsachBTDKcanthuchien.Rows(i).Cells("chkChon").Value = True Then
                MS_PBT = commons.Modules.ObjSystems.TangMS_PBT
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPHIEU_BAO_TRI", MS_PBT, _
                                        Me.grdDanhsachBTDKcanthuchien.Rows(i).Cells("MS_MAY").Value, _
                                        grdDanhsachBTDKcanthuchien.Rows(i).Cells("MS_LOAI_BT").Value, DateValue(Now), strGioTam.ToString, _
                                        Me.grdDanhsachBTDKcanthuchien.Rows(i).Cells("TEN_LOAI_BT").Value, 1, _
                                        Me.grdDanhsachBTDKcanthuchien.Rows(i).Cells("NGAY_BTKT").Value, Me.cboNguoiLap.SelectedValue, _
                                        Commons.Modules.UserName, DateValue(Now), DateValue(Now), "-1")

                commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI_CONG_VIEC(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,SO_GIO_KH) SELECT '" & MS_PBT & "',MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MS_BO_PHAN,THOI_GIAN_DU_KIEN FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_CV=CONG_VIEC.MS_CV WHERE MS_MAY=N'" & grdDanhsachBTDKcanthuchien.Rows(i).Cells("MS_MAY").Value & "' AND MS_LOAI_BT=" & grdDanhsachBTDKcanthuchien.Rows(i).Cells("MS_LOAI_BT").Value
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                commons.Modules.SQLString = "SELECT MS_CV FROM PHIEU_BAO_TRI_CONG_VIEC INNER JOIN PHIEU_BAO_TRI ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI WHERE MS_MAY =N'" & grdDanhsachBTDKcanthuchien.Rows(i).Cells("MS_MAY").Value & "' AND MS_LOAI_BT=" & grdDanhsachBTDKcanthuchien.Rows(i).Cells("MS_LOAI_BT").Value & " AND PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI='" & MS_PBT & "'"

                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                While dtReader.Read
                    commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH) SELECT '" & MS_PBT & "'," & dtReader.Item("MS_CV") & ",MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & grdDanhsachBTDKcanthuchien.Rows(i).Cells("MS_MAY").Value & "' AND MS_LOAI_BT=" & grdDanhsachBTDKcanthuchien.Rows(i).Cells("MS_LOAI_BT").Value & " AND MS_CV=" & dtReader.Item(0)
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                End While
                dtReader.Close()
            End If
            i = i + 1
        End While

        layDuLieuSub()

        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenKT23", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    End Sub

    Private Sub BtnThoatBTDK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoatBTDK.Click
        Me.Close()
    End Sub
End Class