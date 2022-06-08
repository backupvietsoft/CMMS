Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsNhacviecController

        Public Sub New()
        End Sub
        Public Function GetThietBiDenHanHC(ByVal TYPE As Integer, ByVal TU_NGAY As String, ByVal DEN_NGAY As String, ByVal USERNAME As String, ByVal NOI As Integer, ByVal MS_LOAI_MAY As String, ByVal MS_N_XUONG As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThietBiDenHanHC", TYPE, TU_NGAY, DEN_NGAY, USERNAME, NOI, MS_LOAI_MAY, MS_N_XUONG))
            Return objDataTable
        End Function
        Public Function GetDSThietBiDenHanHC(ByVal TU_NGAY As Date, ByVal DEN_NGAY As Date, ByVal USERNAME As String, ByVal MS_LOAI_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDSThietBiDenHanHC", TU_NGAY, DEN_NGAY, USERNAME, MS_LOAI_MAY))
            Return objDataTable
        End Function
        Public Function GetPhieuBTtrongngay(ByVal MS_LOAI_MAY As String, ByVal USERNAME As String, ByVal MS_N_XUONG As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhieuBTtrongngay", MS_LOAI_MAY, USERNAME, MS_N_XUONG, Format(Now.Date, "dd/MMM/yyyy")))
            Return objDataTable
        End Function
        Public Function GetPhieuBTquahanketthuc(ByVal MS_LOAI_MAY As String, ByVal USERNAME As String, ByVal MS_N_XUONG As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhieuBTquahanketthuc", MS_LOAI_MAY, USERNAME, MS_N_XUONG))
            Return objDataTable
        End Function
        Public Function GetPTcoSLtonnhohontontoithieu(ByVal MS_KHO As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPTcoSLtonnhohontontoithieu", MS_KHO, Commons.Modules.UserName))
            Return objDataTable
        End Function
    End Class
End Namespace
