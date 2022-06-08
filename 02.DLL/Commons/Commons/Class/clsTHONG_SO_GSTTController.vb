Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class THONG_SO_GSTTController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetTHONG_SO_GSTTs(ByVal NGON_NGU As Integer, ByVal LOAI As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_GSTTs", NGON_NGU, LOAI))
            Return objDataTable
        End Function

        Public Function GetTHONG_SO_GSTTs_Theo_MS_BP_GSTT(ByVal NGON_NGU As Integer, ByVal intMS_BP_GSTT As Integer, ByVal Loai As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_GSTTs_Theo_MS_BP_GSTT", NGON_NGU, intMS_BP_GSTT, Loai))
            Return objDataTable
        End Function
        Public Function GetTHONG_SO_GSTTs_Theo_DON_VI_DO(ByVal NGON_NGU As Integer, ByVal MS_DV_DO As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_GSTTs_Theo_DON_VI_DO", NGON_NGU, MS_DV_DO))
            Return objDataTable
        End Function
        Public Function GetTHONG_SO_GSTT(ByVal ID As Integer) As THONG_SO_GSTTInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_GSTT", ID)
            Dim objTHONG_SO_GSTTInfo As New THONG_SO_GSTTInfo
            While objDataReader.Read
                objTHONG_SO_GSTTInfo.MS_TS_GSTT = objDataReader.Item("MS_TS_GSTT")
                objTHONG_SO_GSTTInfo.TEN_TS_GSTT = objDataReader.Item("TEN_TS_GSTT")
                objTHONG_SO_GSTTInfo.MS_DV_DO = objDataReader.Item("MS_DV_DO")
                objTHONG_SO_GSTTInfo.LOAI_TS = objDataReader.Item("LOAI_TS")
                objTHONG_SO_GSTTInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
            End While
            objDataReader.Close()
            Return objTHONG_SO_GSTTInfo
        End Function

        Public Sub AddTHONG_SO_GSTT(ByVal objTHONG_SO_GSTTInfo As THONG_SO_GSTTInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTHONG_SO_GSTT", objTHONG_SO_GSTTInfo.MS_TS_GSTT, objTHONG_SO_GSTTInfo.TEN_TS_GSTT, objTHONG_SO_GSTTInfo.MS_DV_DO, IIf(objTHONG_SO_GSTTInfo.LOAI_TS, 1, 0), objTHONG_SO_GSTTInfo.GHI_CHU, objTHONG_SO_GSTTInfo.MS_BP_GSTT, objTHONG_SO_GSTTInfo.DUONG_DAN)
        End Sub

        Public Sub UpdateTHONG_SO_GSTT(ByVal objTHONG_SO_GSTTInfo As THONG_SO_GSTTInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTHONG_SO_GSTT", objTHONG_SO_GSTTInfo.MS_TS_GSTT, objTHONG_SO_GSTTInfo.TEN_TS_GSTT, objTHONG_SO_GSTTInfo.MS_DV_DO, objTHONG_SO_GSTTInfo.LOAI_TS, objTHONG_SO_GSTTInfo.GHI_CHU, objTHONG_SO_GSTTInfo.MS_BP_GSTT, objTHONG_SO_GSTTInfo.DUONG_DAN)
        End Sub
        Public Sub InsertTHONG_SO_GSTT_LOG(ByVal ID As Integer, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTHONG_SO_GSTT_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub

        Public Sub DeleteTHONG_SO_GSTT(ByVal MS_TS_GSTT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTHONG_SO_GSTT", MS_TS_GSTT)
        End Sub
#End Region

    End Class
End Namespace
