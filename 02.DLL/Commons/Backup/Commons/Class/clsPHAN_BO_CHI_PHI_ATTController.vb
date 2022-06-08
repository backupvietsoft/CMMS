Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsPHAN_BO_CHI_PHI_ATTController

        Public Sub New()

        End Sub
        Public Function GetMAY_ATT(ByVal USERNAME As String, ByVal MS_LOAI_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_ATT", USERNAME, MS_LOAI_MAY))
            Return objDataTable
        End Function

        Public Function GetCHI_PHI_BAO_TRI_ATTs(ByVal MS_ATTACHMENT As String, ByVal TU_NGAY As String, ByVal DEN_NGAY As String, ByVal CHON As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHI_PHI_BAO_TRI_ATTs", MS_ATTACHMENT, TU_NGAY, DEN_NGAY, CHON))
            Return objDataTable
        End Function

        Public Function GetMAY_PHAN_BO_ATTs(ByVal MS_ATTACHMENT As String, ByVal MS_PHIEU_BAO_TRI As String, ByVal TU_NGAY As String, ByVal DEN_NGAY As String, ByVal USERNAME As String, ByVal THEM As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_PHAN_BO_ATTs", MS_ATTACHMENT, MS_PHIEU_BAO_TRI, TU_NGAY, DEN_NGAY, USERNAME, THEM))
            Return objDataTable
        End Function
    End Class
End Namespace
