Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class CACH_DAT_HANGController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetCACH_DAT_HANGs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCACH_DAT_HANGs"))
            Return objDataTable
        End Function

        Public Function GetCACH_DAT_HANG(ByVal ID As Integer) As CACH_DAT_HANGInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCACH_DAT_HANG", ID)
            Dim objCACH_DAT_HANGInfo As New CACH_DAT_HANGInfo
            While objDataReader.Read
                objCACH_DAT_HANGInfo.MS_CACH_DAT_HANG = objDataReader.Item("MS_CACH_DAT_HANG")
                objCACH_DAT_HANGInfo.CACH_DAT_HANG = objDataReader.Item("CACH_DAT_HANG")
            End While
            objDataReader.Close()
            Return objCACH_DAT_HANGInfo
        End Function

        Public Function AddCACH_DAT_HANG(ByVal objCACH_DAT_HANGInfo As CACH_DAT_HANGInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddCACH_DAT_HANG", objCACH_DAT_HANGInfo.CACH_DAT_HANG), Integer)
        End Function

        Public Sub UpdateCACH_DAT_HANG(ByVal objCACH_DAT_HANGInfo As CACH_DAT_HANGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCACH_DAT_HANG", objCACH_DAT_HANGInfo.MS_CACH_DAT_HANG, objCACH_DAT_HANGInfo.CACH_DAT_HANG)
        End Sub

        Public Sub DeleteCACH_DAT_HANG(ByVal MS_CACH_DAT_HANG As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCACH_DAT_HANG", MS_CACH_DAT_HANG)
        End Sub
        Public Function CheckCACH_DAT_HANG(ByVal CACH_DAT_HANG As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckCACH_DAT_HANG", CACH_DAT_HANG)
        End Function
        Public Function CheckExistCACH_DAT_HANG(ByVal MS_CACH_DAT_HANG As Integer, ByVal CACH_DAT_HANG As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistCACH_DAT_HANG", MS_CACH_DAT_HANG, CACH_DAT_HANG)
        End Function
#End Region

    End Class
End Namespace
