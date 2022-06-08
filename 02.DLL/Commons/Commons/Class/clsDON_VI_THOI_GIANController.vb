Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class DON_VI_THOI_GIANController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetDON_VI_THOI_GIANs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_THOI_GIANs"))
            Return objDataTable
        End Function

        Public Function GetDON_VI_THOI_GIAN(ByVal ID As Integer) As DON_VI_THOI_GIANInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_THOI_GIAN", ID)
            Dim objDON_VI_THOI_GIANInfo As New DON_VI_THOI_GIANInfo
            While objDataReader.Read
                objDON_VI_THOI_GIANInfo.MS_DV_TG = objDataReader.Item("MS_DV_TG")
                objDON_VI_THOI_GIANInfo.TEN_DV_TG = objDataReader.Item("TEN_DV_TG")
            End While
            objDataReader.Close()
            Return objDON_VI_THOI_GIANInfo
        End Function

        Public Function AddDON_VI_THOI_GIAN(ByVal objDON_VI_THOI_GIANInfo As DON_VI_THOI_GIANInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddDON_VI_THOI_GIAN", objDON_VI_THOI_GIANInfo.TEN_DV_TG), Integer)
        End Function

        Public Sub UpdateDON_VI_THOI_GIAN(ByVal objDON_VI_THOI_GIANInfo As DON_VI_THOI_GIANInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDON_VI_THOI_GIAN", objDON_VI_THOI_GIANInfo.MS_DV_TG, objDON_VI_THOI_GIANInfo.TEN_DV_TG)
        End Sub

        Public Sub DeleteDON_VI_THOI_GIAN(ByVal MS_DV_TG As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteDON_VI_THOI_GIAN", MS_DV_TG)
        End Sub
#End Region
    End Class
End Namespace
