Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class DON_VI_DOController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetDON_VI_DOs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_DOs"))
            Return objDataTable
        End Function

        Public Function GetDON_VI_DO(ByVal ID As Integer) As DON_VI_DOInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_DO", ID)
            Dim objDON_VI_DOInfo As New DON_VI_DOInfo
            While objDataReader.Read
                objDON_VI_DOInfo.MS_DV_DO = objDataReader.Item("MS_DV_DO")
                objDON_VI_DOInfo.TEN_DV_DO = objDataReader.Item("TEN_DV_DO")
            End While
            objDataReader.Close()
            Return objDON_VI_DOInfo
        End Function

        Public Function CheckTEN_DV_DO(ByVal TEN_DV_DO As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_TEN_DV_DO", TEN_DV_DO)
        End Function

        Public Function CheckDON_VI_DO(ByVal MS_DV_DO As Integer, ByVal TEN_DV_DO As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckDON_VI_DO", MS_DV_DO, TEN_DV_DO)
        End Function

        Public Function AddDON_VI_DO(ByVal objDON_VI_DOInfo As DON_VI_DOInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddDON_VI_DO", objDON_VI_DOInfo.TEN_DV_DO), Integer)
        End Function
        Public Sub InsertDON_VI_DO_LOG(ByVal ID As Integer, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDON_VI_DO_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub
        Public Sub UpdateDON_VI_DO(ByVal objDON_VI_DOInfo As DON_VI_DOInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDON_VI_DO", objDON_VI_DOInfo.MS_DV_DO, objDON_VI_DOInfo.TEN_DV_DO)
        End Sub

        Public Sub DeleteDON_VI_DO(ByVal MS_DV_DO As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteDON_VI_DO", MS_DV_DO)
        End Sub
#End Region
    End Class
End Namespace

