Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class MAYController
        Dim v_all As DataTable = New DataTable()
        Dim v_all_may As DataTable = New DataTable()
        Dim v_all_running As DataTable = New DataTable()
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetTHONG_SO_GSTT_BP(ByVal MS_MAY As String, ByVal NN As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_GSTT_BP", MS_MAY, NN))
            Return objDataTable
        End Function

        Public Function GetMAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAYs"))
            Return objDataTable
        End Function

        Public Function GetMAY_PQ(ByVal UserName As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_PQ", UserName))
            Return objDataTable
        End Function

        Public Function GetMAY(ByVal Sqltran As SqlTransaction, ByVal ID As String) As MAYInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Sqltran, "GetMAY", ID)
            Dim objMayInfo As New MAYInfo
            While objDataReader.Read
                objMayInfo.ANH_TB = objDataReader.Item("ANH_TB").ToString
                objMayInfo.GIA_MUA = objDataReader.Item("GIA_MUA").ToString
                objMayInfo.LUU_Y_SU_DUNG = objDataReader.Item("LUU_Y_SU_DUNG").ToString
                objMayInfo.MO_TA = objDataReader.Item("MO_TA").ToString
                objMayInfo.MODEL = objDataReader.Item("MODEL").ToString
                objMayInfo.MS_DVT_RT = IIf(IsDBNull(objDataReader.Item("MS_DVT_RT")), Nothing, objDataReader.Item("MS_DVT_RT"))
                objMayInfo.MS_HIEN_TRANG = objDataReader.Item("MS_HIEN_TRANG").ToString
                objMayInfo.MS_HSX = objDataReader.Item("MS_HSX").ToString
                objMayInfo.MS_MAY = objDataReader.Item("MS_MAY").ToString
                objMayInfo.MS_MAY_TMP = objDataReader.Item("MS_MAY").ToString
                objMayInfo.MS_KH = objDataReader.Item("MS_KH").ToString
                objMayInfo.MS_NHOM_MAY = objDataReader.Item("MS_NHOM_MAY").ToString
                Try
                    objMayInfo.CHU_KY_HC_TB = objDataReader.Item("CHU_KY_HC_TB").ToString
                Catch ex As Exception

                End Try
                objMayInfo.MUC_UU_TIEN = objDataReader.Item("MUC_UU_TIEN").ToString
                objMayInfo.NGAY_BD_BAO_HANH = objDataReader.Item("NGAY_BD_BAO_HANH").ToString
                objMayInfo.NGAY_DUA_VAO_SD = objDataReader.Item("NGAY_DUA_VAO_SD").ToString
                objMayInfo.NGAY_MUA = objDataReader.Item("NGAY_MUA").ToString
                objMayInfo.NGAY_SX = objDataReader.Item("NGAY_SX").ToString
                objMayInfo.NGOAI_TE = objDataReader.Item("NGOAI_TE").ToString
                objMayInfo.NHIEM_VU_THIET_BI = objDataReader.Item("NHIEM_VU_THIET_BI").ToString
                objMayInfo.NUOC_SX = objDataReader.Item("NUOC_SX").ToString
                objMayInfo.SERIAL_NUMBER = objDataReader.Item("SERIAL_NUMBER").ToString
                objMayInfo.SO_GIO_LV_TRONG_NGAY = objDataReader.Item("SO_GIO_LV_TRONG_NGAY").ToString
                objMayInfo.SO_NAM_KHAU_HAO = objDataReader.Item("SO_NAM_KHAU_HAO").ToString
                objMayInfo.SO_NGAY_LV_TRONG_TUAN = objDataReader.Item("SO_NGAY_LV_TRONG_TUAN").ToString
                objMayInfo.SO_THANG_BH = objDataReader.Item("SO_THANG_BH").ToString
                objMayInfo.SO_THE = objDataReader.Item("SO_THE").ToString
                objMayInfo.TY_LE_CON_LAI = objDataReader.Item("TY_LE_CON_LAI").ToString

            End While
            objDataReader.Close()
            Return objMayInfo
        End Function

        Public Function GetPHU_TUNG() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNG"))
            Return objDataTable
        End Function

        Public Function GetDON_VI_THOI_GIANs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_THOI_GIANs", commons.Modules.TypeLanguage))
            Return objDataTable
        End Function

        Public Function GetLOAI_BAO_TRI() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_BAO_TRI"))
            Return objDataTable
        End Function

        Public Function GetLOAI_BAO_TRIs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_BAO_TRIs"))
            Return objDataTable
        End Function

        Public Function GetMAY_LOAI_BTPN(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable

            'TEST
            Try
                commons.Modules.SQLString = "DROP TABLE DBO.MAY_LOAI_BTPN_CHU_KY_TMP" & Commons.Modules.UserName
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            Catch ex As Exception
            End Try
            Try
                commons.Modules.SQLString = "DROP TABLE DBO.MAY_LOAI_BTPN_CHU_KY_TMP1" & Commons.Modules.UserName
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            Catch ex As Exception
            End Try
            commons.Modules.SQLString = "SELECT MS_MAY,MS_LOAI_BT,MAX(NGAY_AD) AS NGAY_AD_MAX INTO DBO.MAY_LOAI_BTPN_CHU_KY_TMP" & Commons.Modules.UserName & " FROM MAY_LOAI_BTPN_CHU_KY WHERE MS_MAY=N'" & MS_MAY & "' GROUP BY MS_MAY,MS_LOAI_BT "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            commons.Modules.SQLString = "SELECT MAY_LOAI_BTPN_CHU_KY.* INTO DBO.MAY_LOAI_BTPN_CHU_KY_TMP1" & Commons.Modules.UserName & " FROM MAY_LOAI_BTPN_CHU_KY INNER JOIN DBO.MAY_LOAI_BTPN_CHU_KY_TMP" & Commons.Modules.UserName & " ON MAY_LOAI_BTPN_CHU_KY.MS_MAY=DBO.MAY_LOAI_BTPN_CHU_KY_TMP" & Commons.Modules.UserName & ".MS_MAY AND MAY_LOAI_BTPN_CHU_KY.MS_LOAI_BT=DBO.MAY_LOAI_BTPN_CHU_KY_TMP" & Commons.Modules.UserName & ".MS_LOAI_BT AND MAY_LOAI_BTPN_CHU_KY.NGAY_AD=DBO.MAY_LOAI_BTPN_CHU_KY_TMP" & Commons.Modules.UserName & ".NGAY_AD_MAX "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = "SELECT LOAI_BAO_TRI.THU_TU,MAY_LOAI_BTPN.MS_LOAI_BT,NGAY_CUOI, " & _
                    " cast(CHU_KY as nvarchar(50)) + ' ' + CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_DV_TG ELSE TEN_DV_TG_ANH " & _
                    " END AS CHU_KYS,cast(RUN_TIME as nvarchar(50)) + ' ' + TEN_DVT_RT AS RUN_TIMES,SO_NGAY," & _
                    " MOVEMENT,MAY_LOAI_BTPN.MS_LOAI_BT AS MS_LOAI_BT_OLD, THUC_HIEN_BOI, MAY_LOAI_BTPN.GHI_CHU " & _
                    " FROM ((MAY_LOAI_BTPN LEFT JOIN MAY_LOAI_BTPN_CHU_KY_TMP1" & Commons.Modules.UserName & " ON " & _
                    " MAY_LOAI_BTPN.MS_MAY=DBO.MAY_LOAI_BTPN_CHU_KY_TMP1" & Commons.Modules.UserName & ".MS_MAY " & _
                    " AND MAY_LOAI_BTPN.MS_LOAI_BT=DBO.MAY_LOAI_BTPN_CHU_KY_TMP1" & Commons.Modules.UserName & ".MS_LOAI_BT) " & _
                    " LEFT JOIN DON_VI_THOI_GIAN ON DON_VI_THOI_GIAN.MS_DV_TG=DBO.MAY_LOAI_BTPN_CHU_KY_TMP1" & Commons.Modules.UserName & ".MS_DV_TG ) " & _
                    " LEFT JOIN DON_VI_TINH_RUN_TIME ON DON_VI_TINH_RUN_TIME.MS_DVT_RT=DBO.MAY_LOAI_BTPN_CHU_KY_TMP1" & Commons.Modules.UserName & ".MS_DVT_RT " & _
                    " INNER JOIN LOAI_BAO_TRI ON LOAI_BAO_TRI.MS_LOAI_BT=MAY_LOAI_BTPN.MS_LOAI_BT WHERE MAY_LOAI_BTPN.MS_MAY=N'" & MS_MAY & "' " & _
                    " AND (NGAY_AD IN (SELECT MAX(NGAY_AD) FROM DBO.MAY_LOAI_BTPN_CHU_KY_TMP1" & Commons.Modules.UserName & _
                    " WHERE MS_MAY=N'" & MS_MAY & "' GROUP BY MS_MAY,MS_LOAI_BT) OR NGAY_AD IS NULL) ORDER BY LOAI_BAO_TRI.THU_TU"
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))

            Dim priCol(0) As DataColumn
            priCol(0) = objDataTable.Columns("MS_LOAI_BT")
            objDataTable.PrimaryKey = priCol
            objDataTable.Columns("MS_LOAI_BT_OLD").AllowDBNull = True
            Return objDataTable
        End Function

        Public Function GetPHU_TUNG_BTPN(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNG_BTPN", MS_MAY))
            Return objDataTable
        End Function

        Public Function GetCHU_KY_HIEU_CHUAN(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHU_KY_HIEU_CHUAN", MS_MAY))
            If objDataTable.Rows.Count > 0 Then
                Dim priCol(1) As DataColumn
                priCol(0) = objDataTable.Columns("MS_PT")
                priCol(0).AllowDBNull = True
                priCol(1) = objDataTable.Columns("MS_VI_TRI")
                objDataTable.PrimaryKey = priCol
            End If
            Return objDataTable
        End Function

        Public Function GetMAY_LOAI_BTPN_CONG_VIEC(ByVal MS_MAY As String, ByVal MS_LOAI_BT As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOAI_BTPN_CONG_VIEC", MS_MAY, MS_LOAI_BT))
            Return objDataTable
        End Function

        Public Function GetMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG(ByVal MS_MAY As String, ByVal MS_LOAI_BT As Integer, ByVal MS_CV As Integer, ByVal NGON_NGU As Byte, ByVal MS_BO_PHAN As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG", MS_MAY, MS_LOAI_BT, MS_CV, NGON_NGU, MS_BO_PHAN))
            Return objDataTable
        End Function

        Public Function GetTHONG_SO_CHINH_MAYs(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_CHINH_MAYs", MS_MAY))
            Dim priCol(1) As DataColumn
            priCol(0) = objDataTable.Columns("MS_MAY")
            priCol(1) = objDataTable.Columns("MS_THONG_SO_MAY")
            objDataTable.PrimaryKey = priCol
            Return objDataTable
        End Function

        Public Function GetTHONG_SO_MAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_MAYs"))
            Return objDataTable
        End Function

        Public Function GetMAY_TAI_LIEUs(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_TAI_LIEUs", MS_MAY))
            Return objDataTable
        End Function

        Public Function GetMAY_LOC_HE_THONGs(ByVal MS_HE_THONG As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_HE_THONGs", MS_HE_THONG))
            Return objDataTable
        End Function
        Public Function GetMAY_LOC_HE_THONG(ByVal MS_HE_THONG As Integer, ByVal iLocTheoMS As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_HE_THONG", MS_HE_THONG, Commons.Modules.UserName, iLocTheoMS))
            Return objDataTable
        End Function

        Public Function GetMAY_LOC_NHA_XUONGs(ByVal MS_N_XUONG As String, ByVal iLocTheoMS As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_NHA_XUONGs", MS_N_XUONG, Commons.Modules.UserName, iLocTheoMS))
            Return objDataTable
        End Function


        Public Function GetMAY_LOC_NHA_XUONGs(ByVal MS_N_XUONG As String, ByVal Loai As Boolean) As DataTable
            Dim objDataTable As DataTable = New DataTable
            Try
                If Loai Then
                    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_NHA_XUONGs", MS_N_XUONG, 1))
                Else
                    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_NHA_XUONGs", MS_N_XUONG, 0))
                End If
            Catch ex As Exception

            End Try

            Return objDataTable
        End Function

        Public Function GetMAY_LOC_NHOM_MAYs(ByVal MS_NHOM_MAY As String, ByVal MS_LOAI_MAY As String, ByVal iLocTheoMS As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_NHOM_MAYs", _
                            MS_NHOM_MAY, MS_LOAI_MAY, Commons.Modules.UserName, iLocTheoMS))
            Return objDataTable
        End Function

        Public Function PermisionALL(ByVal USERS As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionALL", USERS))
            Return objDataTable
        End Function

        Public Function PermisionALL(ByVal USERS As String, ByVal Loai As Boolean, ByVal iLocTheoMS As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            Try 'nhoc
                If Loai Then
                    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionALL", USERS, 1, iLocTheoMS))
                Else
                    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionALL", USERS, 0, iLocTheoMS))
                End If
            Catch ex As Exception
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionALL", USERS, 0, iLocTheoMS))
            End Try

            Return objDataTable
        End Function

        Public Function PermisionLOAI_MAY(ByVal USER As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_MAY", USER))
            Return objDataTable
        End Function

        Public Function GetNHOM_MAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHOM_MAYs"))
            Return objDataTable
        End Function

        Public Function AddMAYSC(ByVal Sqltran As SqlTransaction, ByVal objMAYInfo As MAYInfo) As String
            Try 'nhoc
                SqlHelper.ExecuteNonQuery(Sqltran, "AddMAY", _
                                objMAYInfo.MS_MAY, IIf(objMAYInfo.TEN_MAY = "", System.DBNull.Value, objMAYInfo.TEN_MAY), _
                                objMAYInfo.MS_NHOM_MAY, IIf(objMAYInfo.MS_HSX = "", System.DBNull.Value, objMAYInfo.MS_HSX), _
                                objMAYInfo.MS_HIEN_TRANG, objMAYInfo.MS_KH, objMAYInfo.SO_NAM_KHAU_HAO, objMAYInfo.MO_TA, _
                                objMAYInfo.NHIEM_VU_THIET_BI, objMAYInfo.MODEL, objMAYInfo.SERIAL_NUMBER, objMAYInfo.NGAY_SX, _
                                objMAYInfo.NUOC_SX, objMAYInfo.NGAY_MUA, objMAYInfo.NGAY_BD_BAO_HANH, objMAYInfo.NGAY_DUA_VAO_SD, _
                                objMAYInfo.SO_THE, objMAYInfo.SO_NGAY_LV_TRONG_TUAN, objMAYInfo.SO_GIO_LV_TRONG_NGAY, objMAYInfo.MS_DVT_RT, _
                                objMAYInfo.TY_LE_CON_LAI, objMAYInfo.MUC_UU_TIEN, objMAYInfo.SO_THANG_BH, objMAYInfo.GIA_MUA, _
                                IIf(objMAYInfo.NGOAI_TE = "", System.DBNull.Value, objMAYInfo.NGOAI_TE), objMAYInfo.CHU_KY_HC_TB, _
                                objMAYInfo.SO_CT, objMAYInfo.TI_GIA_VND, objMAYInfo.TI_GIA_USD, objMAYInfo.CHU_KY_HC_TB_NGOAI, _
                                objMAYInfo.CHU_KY_KD_TB, objMAYInfo.DON_VI_TG)
            Catch ex As Exception

            End Try
            Return True
        End Function


        Public Function AddMAY(ByVal objMAYInfo As MAYInfo) As String
            Try 'nhoc
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddMAY", _
                                objMAYInfo.MS_MAY, IIf(objMAYInfo.TEN_MAY = "", System.DBNull.Value, objMAYInfo.TEN_MAY), _
                                objMAYInfo.MS_NHOM_MAY, IIf(objMAYInfo.MS_HSX = "-1", System.DBNull.Value, objMAYInfo.MS_HSX), _
                                objMAYInfo.MS_HIEN_TRANG, objMAYInfo.MS_KH, objMAYInfo.SO_NAM_KHAU_HAO, objMAYInfo.MO_TA, _
                                objMAYInfo.NHIEM_VU_THIET_BI, objMAYInfo.MODEL, objMAYInfo.SERIAL_NUMBER, objMAYInfo.NGAY_SX, _
                                objMAYInfo.NUOC_SX, objMAYInfo.NGAY_MUA, objMAYInfo.NGAY_BD_BAO_HANH, objMAYInfo.NGAY_DUA_VAO_SD, _
                                objMAYInfo.SO_THE, objMAYInfo.SO_NGAY_LV_TRONG_TUAN, objMAYInfo.SO_GIO_LV_TRONG_NGAY, objMAYInfo.MS_DVT_RT, _
                                objMAYInfo.TY_LE_CON_LAI, objMAYInfo.MUC_UU_TIEN, objMAYInfo.SO_THANG_BH, objMAYInfo.GIA_MUA, _
                                IIf(objMAYInfo.NGOAI_TE = "", System.DBNull.Value, objMAYInfo.NGOAI_TE), objMAYInfo.CHU_KY_HC_TB, _
                                objMAYInfo.SO_CT, objMAYInfo.TI_GIA_VND, objMAYInfo.TI_GIA_USD, objMAYInfo.CHU_KY_HC_TB_NGOAI, _
                                objMAYInfo.CHU_KY_KD_TB, objMAYInfo.DON_VI_TG)
            Catch ex As Exception
            End Try
            Return True
        End Function

        Public Function AddTHONG_SO_CHINH_MAY(ByVal objMAYInfo As MAYInfo) As String
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddTHONG_SO_CHINH_MAY", _
                objMAYInfo.MS_MAY, objMAYInfo.MS_THONG_SO_MAY, objMAYInfo.GIA_TRI, objMAYInfo.GHI_CHU)
            Return True
        End Function

        Public Function UpdateTHONG_SO_CHINH_MAY(ByVal objMAYInfo As MAYInfo) As String
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateTHONG_SO_CHINH_MAY", _
                objMAYInfo.MS_MAY, objMAYInfo.MS_THONG_SO_MAY, objMAYInfo.GIA_TRI, objMAYInfo.GHI_CHU)
            Return True
        End Function

        Public Sub UpdateMAY(ByVal objMAYInfo As MAYInfo)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateMAY", _
                objMAYInfo.MS_MAY, objMAYInfo.TEN_MAY, objMAYInfo.MS_NHOM_MAY, objMAYInfo.MS_HSX, objMAYInfo.MS_HIEN_TRANG, objMAYInfo.MS_KH, objMAYInfo.SO_NAM_KHAU_HAO, _
                objMAYInfo.MO_TA, objMAYInfo.NHIEM_VU_THIET_BI, objMAYInfo.MODEL, objMAYInfo.SERIAL_NUMBER, objMAYInfo.NGAY_SX, objMAYInfo.NUOC_SX, objMAYInfo.NGAY_MUA, _
                objMAYInfo.NGAY_BD_BAO_HANH, objMAYInfo.NGAY_DUA_VAO_SD, objMAYInfo.SO_THE, objMAYInfo.SO_NGAY_LV_TRONG_TUAN, objMAYInfo.SO_GIO_LV_TRONG_NGAY, _
                objMAYInfo.MS_DVT_RT, objMAYInfo.TY_LE_CON_LAI, objMAYInfo.MUC_UU_TIEN, objMAYInfo.SO_THANG_BH, objMAYInfo.GIA_MUA, objMAYInfo.NGOAI_TE, _
                objMAYInfo.MS_MAY_TMP, objMAYInfo.CHU_KY_HC_TB, objMAYInfo.SO_CT, objMAYInfo.TI_GIA_VND, objMAYInfo.TI_GIA_USD, objMAYInfo.CHU_KY_HC_TB_NGOAI, _
                objMAYInfo.CHU_KY_KD_TB, objMAYInfo.DON_VI_TG)
        End Sub

        Public Sub DeleteMAY(ByVal MS_MAY As String)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteMAY", MS_MAY)
        End Sub

        Public Sub DeleteTHONG_SO_CHINH_MAY(ByVal MS_MAY As String, ByVal MS_THONG_SO_MAY As Integer)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteTHONG_SO_CHINH_MAY", MS_MAY, MS_THONG_SO_MAY)
        End Sub
        Public Sub DeleteMAY_TAI_LIEU(ByVal MA_TAI_LIEU As Integer, ByVal MS_MAY As String)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteMAY_TAI_LIEU", MA_TAI_LIEU, MS_MAY)
        End Sub
        Public Function GetTool() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTool"))
            Return objDataTable
        End Function
        Public Function GetMAY_LOAI_BTPN_CONG_VIEC_TOOL(ByVal MS_MAY As String, ByVal MS_LOAI_BT As Integer, ByVal MS_CV As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOAI_BTPN_CONG_VIEC_TOOL", MS_MAY, MS_LOAI_BT, MS_CV))
            Return objDataTable
        End Function

        Public Function GetNGAY_HC_MAX_of_TB(ByVal MS_MAY As String, ByVal MS_LOAI_HIEU_CHUAN As Integer) As String
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_NGAY_HC_GAN_NHAT", MS_MAY, MS_LOAI_HIEU_CHUAN)
            Dim tmp As String = ""
            While objDataReader.Read
                tmp = objDataReader.Item("NGAY_HC_MAX").ToString
            End While
            objDataReader.Close()
            Return tmp
        End Function
        Public Function GetDUONG_DAN_HINH(ByVal STT As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDUONG_DAN_HINH", STT))
            Return objDataTable
        End Function
        Public Sub AddMAY_TAI_LIEU(ByVal MS_MAY As String, ByVal TEN_TAI_LIEU As String, ByVal NOI_LUU_TRU As String)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddMAY_TAI_LIEU", MS_MAY, TEN_TAI_LIEU, NOI_LUU_TRU)
        End Sub
        Public Sub DeleteMAY_TAI_LIEUs(ByVal MS_MAY As String)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteMAY_TAI_LIEUs", MS_MAY)
        End Sub


#End Region
#Region "LY NHU Y"
#Region "THONG TIN THIET BI"
    
        Public Function GetMay_Nha_Xuong(ByVal ms_nx As String, ByVal city As String, ByVal district As String, ByVal street As String, ByVal order As Integer) As DataTable
            Dim _table As DataTable = New DataTable
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_NHA_XUONG_New", Commons.Modules.UserName, ms_nx, city, district, street, order))
            Return _table
        End Function
#End Region
#Region "THOI GIAN CHAY MAY"
        Public Function GET_MAY_RUNNING(ByVal ms_n_xuong As String) As DataTable
            If ms_n_xuong <> "-1" Then
                Dim objDataTable As DataTable = New DataTable
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[GET_MACHINE_RUNNING]", Commons.Modules.UserName))
                Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + ms_n_xuong + "'", "", DataViewRowState.CurrentRows)
                Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG ='" + ms_n_xuong + "'", "", DataViewRowState.CurrentRows)
                Dim nhom_may As String = vDataDetail(0)("MS_NHOM_MAY").ToString()
                Dim temp As DataView = vDataParent
                If String.IsNullOrEmpty(nhom_may) Then
                    For Each vr As DataRow In vDataParent.ToTable().Rows
                        If String.IsNullOrEmpty(vr("MS_MAY").ToString()) Then
                            Try
                                temp.Table.TableName = "test"
                                temp.Table = GET_MAY_RUNNING(vr("MS_N_Xuong"))
                            Catch ex As Exception

                            End Try
                        Else
                            Try
                                If (v_all_running.Rows.Count <= 0) Then
                                    v_all_running = vDataParent.ToTable().Copy()
                                    v_all_running.Clear()
                                End If
                                v_all_running.Rows.Add(vr.ItemArray)
                            Catch ex As Exception

                            End Try



                        End If
                    Next

                    ' v_all_running.Merge(temp.ToTable())

                    Return v_all_running
                Else
                    temp = vDataDetail
                    Return temp.ToTable()
                    'vDataParent.
                End If
            Else
                Dim objDataTable As DataTable = New DataTable
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[GET_MACHINE_RUNNING]", Commons.Modules.UserName))
                Return objDataTable
            End If
        End Function
        Public Function Get_MAY_RUNNING(ByVal ms_nx As String, ByVal lstnha_xuong As String, ByVal city As String, ByVal district As String, ByVal street As String) As DataTable
            Dim _table As DataTable = New DataTable
            _table = Get_MAY_RUNNING(ms_nx)
            If ms_nx = "-1" Then
                Dim nha_xuong = "MS_N_Xuong in (" + lstnha_xuong + ")"
                _table.DefaultView.RowFilter = nha_xuong
                _table = _table.DefaultView.ToTable()
            End If
            If _table.Rows.Count > 0 Then

                Dim _city As String = ""
                Dim _district As String = ""
                Dim _street As String = ""
                If city <> "-1" Then
                    _city = "MS_TINH = '" + city + "'"
                    _table.DefaultView.RowFilter = _city
                    _table = _table.DefaultView.ToTable()
                End If
                If district <> "-1" Then
                    _district = "MS_QUAN = '" + district + "'"
                    _table.DefaultView.RowFilter = _district
                    _table = _table.DefaultView.ToTable()
                End If
                If street <> "-1" Then
                    _street = "MS_DUONG = '" + street + "'"
                    _table.DefaultView.RowFilter = _street
                    _table = _table.DefaultView.ToTable()
                End If
                Dim _ms_may As String = ""
                _ms_may = "MS_MAY<>'' and MS_MAY <> ' ' and MS_MAY is not null"
                _table.DefaultView.RowFilter = _ms_may
                _table = _table.DefaultView.ToTable()
            End If
            Return _table
        End Function
#End Region
#Region "THOI GIAN NGUNG MAY"
        Private Function Get_Thoi_Gian_Ngung_May(ByVal ms_n_xuong As String, ByVal ms_may As String, ByVal ms_loai_may As String, ByVal ms_ht As String, ByVal ms_nn As String, ByVal tu_ngay As Date, ByVal den_ngay As Date) As DataTable
            If ms_n_xuong <> "-1" Then
                Dim objDataTable As DataTable = New DataTable
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[GetTHOI_GIAN_NGUNG_MAY_SO_LAN_NEW]", Commons.Modules.UserName, ms_may, ms_loai_may, _
                                                          ms_ht, ms_nn, tu_ngay, den_ngay))
                Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + ms_n_xuong + "'", "", DataViewRowState.CurrentRows)
                Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + ms_n_xuong + "'", "", DataViewRowState.CurrentRows)
                Dim nhom_may As String = vDataDetail(0)("MS_NHOM_MAY").ToString()
                Dim temp As DataView = vDataParent
                If String.IsNullOrEmpty(nhom_may) Then
                    For Each vr As DataRow In vDataParent.ToTable().Rows
                        If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                            Try
                                temp.Table.TableName = "test"
                                temp.Table = Get_Thoi_Gian_Ngung_May(vr("MS_N_XUONG_FINAL"), ms_may, ms_loai_may, ms_ht, ms_nn, tu_ngay, den_ngay)
                            Catch ex As Exception

                            End Try

                        Else
                            Try
                                If (v_all.Rows.Count <= 0) Then
                                    v_all = vDataParent.ToTable().Copy()
                                    v_all.Clear()
                                End If
                                v_all.Rows.Add(vr.ItemArray)
                            Catch ex As Exception

                            End Try

                        End If
                    Next

                    'v_all.Merge(temp.ToTable())

                    Return v_all
                Else
                    temp = vDataDetail
                    Return temp.ToTable()
                    'vDataParent.
                End If
            Else
                Dim objDataTable As DataTable = New DataTable
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_NGUNG_MAY_SO_LAN_NEW", Commons.Modules.UserName, ms_may, ms_loai_may, _
                                                          ms_ht, ms_nn, tu_ngay, den_ngay))
                Return objDataTable
            End If
        End Function

        Public Function Get_Thoi_Gian_Ngung_May(ByVal ms_n_xuong As String, ByVal lstnha_xuong As String, ByVal ms_may As String, ByVal ms_loai_may As String, ByVal ms_ht As String, ByVal ms_nn As String, ByVal tu_ngay As Date, ByVal den_ngay As Date, ByVal city As String, ByVal district As String, ByVal street As String) As DataTable
            Dim _table As DataTable = New DataTable
            _table = Get_Thoi_Gian_Ngung_May(ms_n_xuong, ms_may, ms_loai_may, ms_ht, ms_nn, tu_ngay, den_ngay)
            Dim t As DataTable = New DataTable
            Dim _city As String = ""
            Dim _district As String = ""
            Dim _street As String = ""
            If ms_n_xuong = "-1" Then
                Dim nha_xuong = "MS_N_XUONG_FINAL in (" + lstnha_xuong + ")"
                _table.DefaultView.RowFilter = nha_xuong
                _table = _table.DefaultView.ToTable()
            End If
            If _table.Rows.Count > 0 Then


                If city <> "-1" Then
                    _city = "MS_TINH = '" + city + "'"
                    _table.DefaultView.RowFilter = _city
                    _table = _table.DefaultView.ToTable()
                End If
                If district <> "-1" Then
                    _district = "MS_QUAN = '" + district + "'"
                    _table.DefaultView.RowFilter = _district
                    _table = _table.DefaultView.ToTable()
                End If
                If street <> "-1" Then
                    _street = "MS_DUONG = '" + street + "'"
                    _table.DefaultView.RowFilter = _street
                    _table = _table.DefaultView.ToTable()
                End If
                Dim _ms_may As String = ""
                _ms_may = "MS_MAY<>'' and MS_MAY <> ' ' and MS_MAY is not null"
                _table.DefaultView.RowFilter = _ms_may
                _table = _table.DefaultView.ToTable()
                '_table.DefaultView
                'Dim _t As DataTable = _table.DefaultView.ToTable()
            End If
            Return _table
        End Function


#End Region
#Region "GIAM SAT TINH TRANG"

        Public Function Get_Loai_May(ByVal MS_N_XUONG As String, ByVal city As String, ByVal district As String, ByVal street As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_GET_LOAI_MAY_BY_NHA_XUONG]", Commons.Modules.UserName, MS_N_XUONG, city, district, street))
            Return objDataTable

        End Function
#End Region
#End Region

#Region "Attachment"
        Public Function GetMAY_ATTACHMENTs(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_ATTACHMENTs", MS_MAY))
            Return objDataTable
        End Function
        Public Function GetAttachment(ByVal USERNAME As String, ByVal lstMAY_MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetAttachment", USERNAME, lstMAY_MS_MAY))
            Return objDataTable
        End Function

        Public Sub AddMAY_ATTACHMENT(ByVal objAttachment As clsMAY_ATTACHMENTInfo)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddMAY_ATTACHMENT", objAttachment.MS_MAY, objAttachment.MS_ATTACHMENT, objAttachment.TU_NGAY, objAttachment.DEN_NGAY)
        End Sub
        Public Sub UpdateMAY_ATTACHMENT(ByVal objAttachment As clsMAY_ATTACHMENTInfo)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateMAY_ATTACHMENT", objAttachment.MS_MAY, objAttachment.MS_ATTACHMENT, objAttachment.TU_NGAY, objAttachment.DEN_NGAY, objAttachment.MS_ATTACHMENT_TMP, objAttachment.TU_NGAY_TMP)
        End Sub

        Public Sub DeleteMAY_ATTACHMENT(ByVal objAttachment As clsMAY_ATTACHMENTInfo)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteMAY_ATTACHMENT", objAttachment.MS_MAY, objAttachment.MS_ATTACHMENT, objAttachment.TU_NGAY)
        End Sub
#End Region
    End Class
End Namespace
