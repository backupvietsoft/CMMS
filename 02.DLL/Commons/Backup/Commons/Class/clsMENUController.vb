Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data



Public Class MENUController
    Public Sub New()

    End Sub

#Region "Public Method"
    Public Function GetMENU(ByVal USERNAME As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMENU", USERNAME))
        Return objDataTable
    End Function

    Public Function GetMENU_USER(ByVal USERNAME As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSER_MENU", USERNAME))
        Return objDataTable
    End Function

    Public Function AddMENU(ByVal objMENUInfo As MENUInfo) As String
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddUSER_MENU", _
            objMENUInfo.USERNAME, objMENUInfo.MENU_ID)
        Return objMENUInfo.USERNAME
    End Function

    Public Sub UpdateMENU(ByVal objMENUInfo As MENUInfo)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateUSER_MENU", _
            objMENUInfo.USERNAME, objMENUInfo.MENU_ID)
    End Sub

    Public Sub DeleteMENU(ByVal USER As String, ByVal MENU_ID As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteUSER_MENU", USER, MENU_ID)
    End Sub
#End Region
End Class


