Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsCHON_VT_CHO_EORController
        Public Sub New()
        End Sub
        Public Function GetLOAI_PHU_TUNG_PQ(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_PHU_TUNG_PQ", USERNAME))
            Return objDataTable
        End Function

        Public Function GetLOAI_MAY_PQ(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_MAY_PQ", USERNAME))
            Return objDataTable
        End Function

        Public Function GetLOAI_VT(ByVal intTypeLanguage As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_VT", intTypeLanguage))
            Return objDataTable
        End Function

        Public Function GetVAT_TU_CHO_EORs(ByVal MS_LOAI_MAY As String, ByVal MS_LOAI_PT As Integer, ByVal MS_LOAI_VT As Integer, ByVal EOR_ID As String, ByVal intTypeLanguage As Integer, ByVal GIA_TRI As String, ByVal LOAI As Byte) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetVAT_TU_CHO_EORs", MS_LOAI_MAY, MS_LOAI_PT, MS_LOAI_VT, EOR_ID, intTypeLanguage, GIA_TRI, LOAI))
            Return objDataTable
        End Function
    End Class
End Namespace
