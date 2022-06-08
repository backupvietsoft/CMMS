Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class clsChonTaiLieuChoEORController

        Public Sub New()
        End Sub
        Public Function GetYEU_CAU_NSD_Cho_EORs(ByVal TU_NGAY As String, ByVal DEN_NGAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_Cho_EORs", TU_NGAY, DEN_NGAY))
            Return objDataTable
        End Function
        Public Function GetGIAM_SAT_TINH_TRANG_Cho_EORs(ByVal TU_NGAY As String, ByVal DEN_NGAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_Cho_EORs", TU_NGAY, DEN_NGAY))
            Return objDataTable
        End Function
        Public Function GetYEU_CAU_NSD_CHI_TIET_HINHs_EOR(ByVal STT As Integer, ByVal MS_MAY As String, ByVal STT_VAN_DE As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_CHI_TIET_HINHs_EOR", STT, MS_MAY, STT_VAN_DE))
            Return objDataTable
        End Function
        Public Function GetGIAM_SAT_TINH_TRANG_HINHs_EOR(ByVal STT As Integer, ByVal MS_MAY As String, ByVal MS_TS_GSTT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_HINHs_EOR", STT, MS_MAY, MS_TS_GSTT))
            Return objDataTable
        End Function
    End Class
End Namespace
