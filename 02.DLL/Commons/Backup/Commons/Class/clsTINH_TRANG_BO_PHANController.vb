Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class clsTINH_TRANG_BO_PHANController
        Public Sub New()
        End Sub
#Region "Public Method"
        Public Function GetTING_TRANGs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTINH_TRANGs"))
            Return objDataTable
        End Function

        Public Sub AddTINH_TRANG(ByVal objTINH_TRANGInfo As clsTINH_TRANG_BO_PHANInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTINH_TRANG", objTINH_TRANGInfo.MA, objTINH_TRANGInfo.TEN_1, objTINH_TRANGInfo.TEN_2, objTINH_TRANGInfo.TEN_3)
        End Sub
        Public Sub UpdateTINH_TRANG(ByVal objTINH_TRANGInfo As clsTINH_TRANG_BO_PHANInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTINH_TRANG", objTINH_TRANGInfo.MA_TMP, objTINH_TRANGInfo.MA, objTINH_TRANGInfo.TEN_1, objTINH_TRANGInfo.TEN_2, objTINH_TRANGInfo.TEN_3)
        End Sub
        Public Sub DeleteTINH_TRANG(ByVal STT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTINH_TRANG", STT)
        End Sub
#End Region
    End Class
End Namespace

