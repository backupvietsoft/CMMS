Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class DANG_XUATController
        Public Sub New()
        End Sub

#Region "Public Methods"
        Public Function GetDANG_XUATs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            Dim QUERY As String = "SELECT * FROM DANG_XUAT"
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
#End Region
    End Class
End Namespace
