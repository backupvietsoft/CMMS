Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class CHUYEN_MONController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetCHUYEN_MONs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHUYEN_MONs"))
            Return objDataTable
        End Function

        Public Function GetCHUYEN_MON(ByVal ID As Integer) As CHUYEN_MONInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHUYEN_MON", ID)
            Dim objCHUYEN_MONInfo As New CHUYEN_MONInfo
            While objDataReader.Read
                objCHUYEN_MONInfo.MS_CM = objDataReader.Item("MS_CM")
                objCHUYEN_MONInfo.TEN_CM = objDataReader.Item("TEN_CM")
            End While
            objDataReader.Close()
            Return objCHUYEN_MONInfo
        End Function

        Public Sub AddCHUYEN_MON(ByVal objCHUYEN_MONInfo As CHUYEN_MONInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddCHUYEN_MON", _
                objCHUYEN_MONInfo.TEN_CM)
        End Sub

        Public Sub UpdateCHUYEN_MON(ByVal objCHUYEN_MONInfo As CHUYEN_MONInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCHUYEN_MON", _
                objCHUYEN_MONInfo.MS_CM, objCHUYEN_MONInfo.TEN_CM)
        End Sub

        Public Sub DeleteCHUYEN_MON(ByVal MS_CM As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCHUYEN_MON", MS_CM)
        End Sub

#End Region
    End Class
End Namespace
