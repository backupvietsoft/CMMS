Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Admin
    Public Class USER_NHA_XUONGController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetUSER_NHA_XUONGs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSER_NHA_XUONGs"))
            Return objDataTable
        End Function

        Public Function AddUSER_NHA_XUONG(ByVal objUSER_NHA_XUONGInfo As USER_NHA_XUONGInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddUSER_NHA_XUONG", _
                objUSER_NHA_XUONGInfo.MS_NX, objUSER_NHA_XUONGInfo.USERNAME)
            Return objUSER_NHA_XUONGInfo.USERNAME
        End Function

        Public Sub DeleteUSER_NHA_XUONG(ByVal User As String, ByVal MsNX As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteUSER_NHA_XUONG", MsNX, User)
        End Sub

        Public Function PermisionNHA_XUONG(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionNHA_XUONG", User))
            Return objDataTable
        End Function

        Public Function ProhibitNHA_XUONG(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "ProhibitNHA_XUONG", User))
            Return objDataTable
        End Function

#End Region

    End Class

End Namespace

