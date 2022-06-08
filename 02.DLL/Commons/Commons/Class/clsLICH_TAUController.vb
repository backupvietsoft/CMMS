Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsLICH_TAUController

        Public Sub New()
        End Sub
        Public Function GetLICH_TAUs(ByVal USERNAME As String, ByVal TU_NGAY As String, ByVal DEN_NGAY As String, ByVal SUA As Boolean) As DataTable
            Dim objDataTable As DataTable = New DataTable
            If SUA Then
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLICH_TAUs", USERNAME, TU_NGAY, DEN_NGAY, 0))
            Else
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLICH_TAUs", USERNAME, TU_NGAY, DEN_NGAY, 1))
            End If
            Return objDataTable
        End Function

        Public Function GetLICH_TAU_THIET_BIs(ByVal intSTT As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLICH_TAU_THIET_BIs", intSTT))
            Return objDataTable
        End Function

        Public Function GetLICH_TAU_STT() As Integer
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLICH_TAU_STT"))
            Return objDataTable.Rows(0).Item(0)
        End Function
        Public Function AddLICH_TAU(ByVal objLICH_TAUInfo As clsLICH_TAUInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddLICH_TAU", _
             objLICH_TAUInfo.TEN_CHUYEN_TAU, objLICH_TAUInfo.TU_NGAY, _
            objLICH_TAUInfo.TU_GIO, objLICH_TAUInfo.DEN_NGAY, objLICH_TAUInfo.DEN_GIO, objLICH_TAUInfo.GHI_CHU, objLICH_TAUInfo.BEN, objLICH_TAUInfo.NGAY_CAP_NHAT_CUOI, objLICH_TAUInfo.DA_XONG), Integer)
        End Function
        Public Sub AddLICH_TAU_THIET_BI(ByVal objLICH_TAU_THIET_BIInfo As clsLICH_TAU_THIET_BInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddLICH_TAU_THIET_BI", _
            objLICH_TAU_THIET_BIInfo.STT, objLICH_TAU_THIET_BIInfo.MS_MAY, objLICH_TAU_THIET_BIInfo.TU_NGAY, _
            objLICH_TAU_THIET_BIInfo.TU_GIO, objLICH_TAU_THIET_BIInfo.DEN_NGAY, objLICH_TAU_THIET_BIInfo.DEN_GIO)
        End Sub

        Public Sub UpdateLICH_TAU(ByVal objLICH_TAUInfo As clsLICH_TAUInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLICH_TAU", _
            objLICH_TAUInfo.STT, objLICH_TAUInfo.TEN_CHUYEN_TAU, objLICH_TAUInfo.TU_NGAY, objLICH_TAUInfo.TU_GIO, _
            objLICH_TAUInfo.DEN_NGAY, objLICH_TAUInfo.DEN_GIO, objLICH_TAUInfo.GHI_CHU, objLICH_TAUInfo.BEN, objLICH_TAUInfo.NGAY_CAP_NHAT_CUOI, objLICH_TAUInfo.DA_XONG)
        End Sub

        Public Sub DeleteLICH_TAU_THIET_BI_Theo_STT(ByVal intSTT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteLICH_TAU_THIET_BI_Theo_STT", intSTT)
        End Sub

        Public Sub DeleteLICH_TAU(ByVal intSTT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteLICH_TAU", intSTT)
        End Sub

        Public Sub DeleteLICH_TAU_THIET_BI(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal TU_NGAY As DateTime, ByVal TU_GIO As DateTime)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteLICH_TAU_THIET_BI", intSTT, strMS_MAY, TU_NGAY, Format(TU_GIO, "Long time"))
        End Sub
    End Class
End Namespace
