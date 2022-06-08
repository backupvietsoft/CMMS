Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsReportController
        Public Sub New()
        End Sub

        Public Function Get_lstDanhsachbaocao(ByVal userlog As String, ByVal Loai_report As Integer, ByVal Ngon_ngu As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_lstDanhsachbaocao", userlog, Loai_report, Ngon_ngu))
            Return objDataTable
        End Function
    End Class
End Namespace

