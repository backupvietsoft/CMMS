Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsPHAN_QUYEN_GIAI_QUYETController

        Public Sub New()
        End Sub
        Public Function GethCHUC_NANG_DA_CHON(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GethCHUC_NANG_DA_CHON", USERNAME))

            Return objDataTable
        End Function
        Public Function GethCHUC_NANG_CHUA_CHON(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GethCHUC_NANG_CHUA_CHON", USERNAME))

            Return objDataTable
        End Function

        Public Sub AddUSER_CHUC_NANG(ByVal USERNAME As String, ByVal intSTT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddUSER_CHUC_NANG", USERNAME, intSTT)
        End Sub
        Public Sub DeleteUSER_CHUC_NANG(ByVal USERNAME As String, ByVal intSTT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteUSER_CHUC_NANG", USERNAME, intSTT)
        End Sub

        Public Function GetCHUC_NANG_1(ByVal USERNAME As String) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHUC_NANG_1", USERNAME)
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            objDataReader.Close()
            Return False
        End Function
    End Class
End Namespace
