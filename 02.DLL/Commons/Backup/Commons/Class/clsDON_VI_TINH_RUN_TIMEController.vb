Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class DON_VI_TINH_RUN_TIMEController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetDON_VI_TINH_RUN_TIMEs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_TINH_RUN_TIMEs"))
            Return objDataTable
        End Function

        Public Function GetDON_VI_TINH_RUN_TIME(ByVal ID As Integer) As DON_VI_TINH_RUN_TIMEInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_TINH_RUN_TIME", ID)
            Dim objDON_VI_TINH_RUN_TIMEInfo As New DON_VI_TINH_RUN_TIMEInfo
            While objDataReader.Read
                objDON_VI_TINH_RUN_TIMEInfo.MS_DVT_RT = objDataReader.Item("MS_DVT_RT")
                objDON_VI_TINH_RUN_TIMEInfo.TEN_DVT_RT = objDataReader.Item("TEN_DVT_RT")
            End While
            objDataReader.Close()
            Return objDON_VI_TINH_RUN_TIMEInfo
        End Function

        Public Function AddDON_VI_TINH_RUN_TIME(ByVal objDON_VI_TINH_RUN_TIMEInfo As DON_VI_TINH_RUN_TIMEInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddDON_VI_TINH_RUN_TIME", objDON_VI_TINH_RUN_TIMEInfo.TEN_DVT_RT), Integer)
        End Function

        Public Sub UpdateDON_VI_TINH_RUN_TIME(ByVal objDON_VI_TINH_RUN_TIMEInfo As DON_VI_TINH_RUN_TIMEInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDON_VI_TINH_RUN_TIME", objDON_VI_TINH_RUN_TIMEInfo.MS_DVT_RT, objDON_VI_TINH_RUN_TIMEInfo.TEN_DVT_RT)
        End Sub
        Public Sub InsertDON_VI_TINH_RUN_TIME_LOG(ByVal ID As Integer, ByVal FORMNAME As String, ByVal USERSIGN As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDON_VI_TINH_RUN_TIME_LOG", ID, FORMNAME, USERSIGN, THAO_TAC)
        End Sub
        Public Sub DeleteDON_VI_TINH_RUN_TIME(ByVal MS_DVT_RT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteDON_VI_TINH_RUN_TIME", MS_DVT_RT)
        End Sub

        Public Function CheckExistTEN_DVT_RT(ByVal TEN_DVT_RT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistTEN_DVT_RT", TEN_DVT_RT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace
