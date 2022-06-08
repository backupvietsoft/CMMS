Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class clsPRIORITYController
        Public Sub New()
        End Sub
#Region "Public Method"
        Public Function GetPRIORITYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPRIORITYs"))
            Return objDataTable
        End Function

        Public Sub AddPRIORITY(ByVal objPRIORITYInfo As clsPRIORITYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPRIORITY", objPRIORITYInfo.MA, objPRIORITYInfo.TEN_1, objPRIORITYInfo.TEN_2, objPRIORITYInfo.TEN_3)
        End Sub
        Public Sub UpdatePRIORITY(ByVal objPRIORITYInfo As clsPRIORITYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePRIORITY", objPRIORITYInfo.MA_TMP, objPRIORITYInfo.MA, objPRIORITYInfo.TEN_1, objPRIORITYInfo.TEN_2, objPRIORITYInfo.TEN_3)
        End Sub
        Public Sub DeletePRIORITY(ByVal STT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePRIORITY", STT)
        End Sub
#End Region
    End Class
End Namespace

