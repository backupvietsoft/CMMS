Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Admin
    Public Class USER_HE_THONGController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetUSER_HE_THONGs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSER_HE_THONGs"))
            Return objDataTable
        End Function

        Public Function AddUSER_HE_THONG(ByVal objUSER_HE_THONGInfo As USER_HE_THONGInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddUSER_HE_THONG", _
                objUSER_HE_THONGInfo.USERNAME, objUSER_HE_THONGInfo.MS_HT)
            Return objUSER_HE_THONGInfo.USERNAME
        End Function

        Public Sub DeleteUSER_HE_THONG(ByVal User As String, ByVal MsHeThong As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteUSER_HE_THONG", User, MsHeThong)
        End Sub

        Public Function PermisionHE_THONG(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionHE_THONG", User))
            Return objDataTable
        End Function

        Public Function ProhibitHE_THONG(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "ProhibitHE_THONG", User))
            Return objDataTable
        End Function
#End Region
    End Class

End Namespace

