Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsCHON_CV_CHO_EORController
        Public Sub New()
        End Sub

        Public Function GetKE_HOACH_TONG_THEs(ByVal MS_MAY As String, ByVal TU_NGAY As String, ByVal DEN_NGAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKE_HOACH_TONG_THEs", MS_MAY, TU_NGAY, DEN_NGAY))
            Return objDataTable
        End Function

        Public Function GetKE_HOACH_TONG_THE_CONG_VIECs(ByVal HANG_MUC_ID As Integer, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKE_HOACH_TONG_THE_CONG_VIECs", HANG_MUC_ID, MS_MAY))
            Return objDataTable
        End Function

        Public Function GetKE_HOACH_TONG_THE_CONG_VIEC_PHU_TUNGs(ByVal HANG_MUC_ID As Integer, ByVal MS_MAY As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String, ByVal intType As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKE_HOACH_TONG_THE_CONG_VIEC_PHU_TUNGs", HANG_MUC_ID, MS_MAY, MS_CV, MS_BO_PHAN, intType))
            Return objDataTable
        End Function

        Public Function GetCONG_VIEC_Q(ByVal MS_MAY As String, ByVal MS_BO_PHAN As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_Q", MS_MAY, MS_BO_PHAN))
            Return objDataTable
        End Function
        Public Function GetBo_PHAN_CONG_VIEC(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBo_PHAN_CONG_VIEC", MS_MAY))
            Return objDataTable
        End Function

    End Class
End Namespace