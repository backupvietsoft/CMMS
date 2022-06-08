Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class HANG_SAN_XUATController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetHANG_SAN_XUATs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHANG_SAN_XUATs"))
            Return objDataTable
        End Function

        Public Function GetHANG_SAN_XUAT(ByVal ID As Integer) As HANG_SAN_XUATInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHANG_SAN_XUAT", ID)
            Dim objHANG_SAN_XUATInfo As New HANG_SAN_XUATInfo
            While objDataReader.Read
                objHANG_SAN_XUATInfo.MS_HSX = objDataReader.Item("MS_HSX")
                objHANG_SAN_XUATInfo.TEN_HSX = objDataReader.Item("TEN_HSX")
                objHANG_SAN_XUATInfo.DIA_CHI = objDataReader.Item("DIA_CHI")
                objHANG_SAN_XUATInfo.WEBSITE = objDataReader.Item("WEBSITE")
            End While
            objDataReader.Close()
            Return objHANG_SAN_XUATInfo
        End Function

        Public Function AddHANG_SAN_XUAT(ByVal objHANG_SAN_XUATInfo As HANG_SAN_XUATInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddHANG_SAN_XUAT", objHANG_SAN_XUATInfo.TEN_HSX, objHANG_SAN_XUATInfo.DIA_CHI, objHANG_SAN_XUATInfo.WEBSITE), Integer)
        End Function

        Public Sub UpdateHANG_SAN_XUAT(ByVal objHANG_SAN_XUATInfo As HANG_SAN_XUATInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateHANG_SAN_XUAT", objHANG_SAN_XUATInfo.MS_HSX, objHANG_SAN_XUATInfo.TEN_HSX, objHANG_SAN_XUATInfo.DIA_CHI, objHANG_SAN_XUATInfo.WEBSITE)
        End Sub

        Public Sub DeleteHANG_SAN_XUAT(ByVal MS_HSX As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteHANG_SAN_XUAT", MS_HSX)
        End Sub
#End Region

    End Class
End Namespace
