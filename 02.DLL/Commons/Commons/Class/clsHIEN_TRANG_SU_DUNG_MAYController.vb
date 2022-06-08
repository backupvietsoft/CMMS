Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class HIEN_TRANG_SU_DUNG_MAYController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetHIEN_TRANG_SU_DUNG_MAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHIEN_TRANG_SU_DUNG_MAYs"))
            Return objDataTable
        End Function

        Public Function GetHIEN_TRANG_SU_DUNG_MAY(ByVal ID As Integer) As HIEN_TRANG_SU_DUNG_MAYInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHIEN_TRANG_SU_DUNG_MAY", ID)
            Dim objHIEN_TRANG_SU_DUNG_MAYInfo As New HIEN_TRANG_SU_DUNG_MAYInfo
            While objDataReader.Read
                objHIEN_TRANG_SU_DUNG_MAYInfo.MS_HIEN_TRANG = objDataReader.Item("MS_HIEN_TRANG")
                objHIEN_TRANG_SU_DUNG_MAYInfo.TEN_HIEN_TRANG = objDataReader.Item("TEN_HIEN_TRANG")
            End While
            objDataReader.Close()
            Return objHIEN_TRANG_SU_DUNG_MAYInfo
        End Function

        Public Function AddHIEN_TRANG_SU_DUNG_MAY(ByVal objHIEN_TRANG_SU_DUNG_MAYInfo As HIEN_TRANG_SU_DUNG_MAYInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddHIEN_TRANG_SU_DUNG_MAY", objHIEN_TRANG_SU_DUNG_MAYInfo.TEN_HIEN_TRANG), Integer)
        End Function

        Public Sub UpdateHIEN_TRANG_SU_DUNG_MAY(ByVal objHIEN_TRANG_SU_DUNG_MAYInfo As HIEN_TRANG_SU_DUNG_MAYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateHIEN_TRANG_SU_DUNG_MAY", objHIEN_TRANG_SU_DUNG_MAYInfo.MS_HIEN_TRANG, objHIEN_TRANG_SU_DUNG_MAYInfo.TEN_HIEN_TRANG)
        End Sub

        Public Sub DeleteHIEN_TRANG_SU_DUNG_MAY(ByVal MS_HIEN_TRANG As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteHIEN_TRANG_SU_DUNG_MAY", MS_HIEN_TRANG)
        End Sub
#End Region

    End Class
End Namespace
