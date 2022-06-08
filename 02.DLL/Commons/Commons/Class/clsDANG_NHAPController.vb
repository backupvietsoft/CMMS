Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class DANG_NHAPController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetDANG_NHAPs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANG_NHAPs"))
            Return objDataTable
        End Function

        Public Function AddDANG_NHAP(ByVal objDANG_NHAPInfo As DANG_NHAPInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddDANG_NHAP", objDANG_NHAPInfo.DANG_NHAP), Integer)
        End Function

        Public Sub UpdateDANG_NHAP(ByVal MS_DANG_NHAP As Integer, ByVal DANG_NHAP As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDANG_NHAP", MS_DANG_NHAP, DANG_NHAP)
        End Sub

        Public Sub DeleteDANG_NHAP(ByVal MS_DANG_NHAP As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteDANG_NHAP", MS_DANG_NHAP)
        End Sub
        Public Function getDANG_NHAP(ByVal DANG_NHAP As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANG_NHAP", DANG_NHAP)
        End Function
        Public Function getTENDANG_NHAP(ByVal MS_DANG_NHAP As Integer, ByVal DANG_NHAP As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTENDANG_NHAP", MS_DANG_NHAP, DANG_NHAP)
        End Function
#End Region
    End Class
End Namespace
