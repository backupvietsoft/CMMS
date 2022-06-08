Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class THONG_SO_MAYController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetTHONG_SO_MAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_MAYs"))
            Return objDataTable
        End Function

        Public Function GetTHONG_SO_MAY(ByVal ID As Integer) As THONG_SO_MAYInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_MAY", ID)
            Dim objTHONG_SO_MAYInfo As New THONG_SO_MAYInfo
            While objDataReader.Read
                objTHONG_SO_MAYInfo.MS_THONG_SO_MAY = objDataReader.Item("MS_THONG_SO_MAY")
                objTHONG_SO_MAYInfo.TEN_THONG_SO_MAY = objDataReader.Item("TEN_THONG_SO_MAY")
                objTHONG_SO_MAYInfo.MS_DV_DO = objDataReader.Item("MS_DV_DO")
                objTHONG_SO_MAYInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
            End While
            objDataReader.Close()
            Return objTHONG_SO_MAYInfo
        End Function

        Function AddTHONG_SO_MAY(ByVal objTHONG_SO_MAYInfo As THONG_SO_MAYInfo) As Integer
            Return SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTHONG_SO_MAY", _
            objTHONG_SO_MAYInfo.TEN_THONG_SO_MAY, objTHONG_SO_MAYInfo.GHI_CHU, objTHONG_SO_MAYInfo.MS_DV_DO)
        End Function

        Public Sub UpdateTHONG_SO_MAY(ByVal objTHONG_SO_MAYInfo As THONG_SO_MAYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTHONG_SO_MAY", _
            objTHONG_SO_MAYInfo.MS_THONG_SO_MAY, objTHONG_SO_MAYInfo.TEN_THONG_SO_MAY, _
            objTHONG_SO_MAYInfo.GHI_CHU, objTHONG_SO_MAYInfo.MS_DV_DO)
        End Sub

        Public Sub DeleteTHONG_SO_MAY(ByVal MS_THONG_SO_MAY As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTHONG_SO_MAY", MS_THONG_SO_MAY)
        End Sub
#End Region

    End Class
End Namespace
