Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsNGUYEN_NHAN_HU_HONGController
        Public Sub New()
        End Sub
#Region "Public Method"
        Public Function GetNGUYEN_NHAN_HU_HONGs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGUYEN_NHAN_HU_HONGs"))
            Return objDataTable
        End Function


        Public Sub AddNGUYEN_NHAN_HU_HONG(ByVal objNGUYEN_NHAN_HU_HONGInfo As clsNGUYEN_NHAN_HU_HONGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddNGUYEN_NHAN_HU_HONG", objNGUYEN_NHAN_HU_HONGInfo.MA, objNGUYEN_NHAN_HU_HONGInfo.TEN_1, objNGUYEN_NHAN_HU_HONGInfo.TEN_2, objNGUYEN_NHAN_HU_HONGInfo.TEN_3)
        End Sub
        Public Sub UpdateNGUYEN_NHAN_HU_HONG(ByVal objNGUYEN_NHAN_HU_HONGInfo As clsNGUYEN_NHAN_HU_HONGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateNGUYEN_NHAN_HU_HONG", objNGUYEN_NHAN_HU_HONGInfo.MA_TMP, objNGUYEN_NHAN_HU_HONGInfo.MA, objNGUYEN_NHAN_HU_HONGInfo.TEN_1, objNGUYEN_NHAN_HU_HONGInfo.TEN_2, objNGUYEN_NHAN_HU_HONGInfo.TEN_3)
        End Sub
        Public Sub DeleteNGUYEN_NHAN_HU_HONG(ByVal STT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNGUYEN_NHAN_HU_HONG", STT)
        End Sub
#End Region
    End Class
End Namespace

