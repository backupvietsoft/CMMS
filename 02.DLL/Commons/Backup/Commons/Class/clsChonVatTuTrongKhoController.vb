Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class clsChonVatTuTrongKhoController

        Public Sub New()

        End Sub
        Public Function GetPICK_LIST_CHI_TIETs(ByVal PICK_NO As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPICK_LIST_CHI_TIETs", PICK_NO))
            Return objDataTable
        End Function
        Public Function GetPICK_LIST_CHI_TIET_KHO(ByVal MS_KHO As Integer, ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPICK_LIST_CHI_TIET_KHO", MS_KHO, USERNAME))
            Return objDataTable
        End Function

        Public Function GetPICK_LIST_CHI_TIET_KHO_CHI_TIET(ByVal MS_KHO As Integer, ByVal USERNAME As String, ByVal LOAI As Integer, ByVal GIA_TRI As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPICK_LIST_CHI_TIET_KHO_CHI_TIET", MS_KHO, USERNAME, LOAI, GIA_TRI))
            Return objDataTable
        End Function
        Public Sub AddPICK_LIST(ByVal THOI_GIAN As DateTime, ByVal USERNAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPICK_LIST", THOI_GIAN, USERNAME)
        End Sub
        Public Sub AddPICK_LIST_CHI_TIET(ByVal PICK_NO As Integer, ByVal MS_KHO As Integer, ByVal MS_VI_TRI As Integer, ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPICK_LIST_CHI_TIET", PICK_NO, MS_KHO, MS_VI_TRI, MS_DH_NHAP_PT, MS_PT)
        End Sub

        Public Sub DeletePICK_LIST_CHI_TIET(ByVal PICK_NO As Integer, ByVal MS_KHO As Integer, ByVal MS_VI_TRI As Integer, ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePICK_LIST_CHI_TIET", PICK_NO, MS_KHO, MS_VI_TRI, MS_DH_NHAP_PT, MS_PT)
        End Sub

        Public Sub DeletePICK_LIST(ByVal PICK_NO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePICK_LIST", PICK_NO)
        End Sub
        Public Function GetPICK_NO() As Integer
            Dim tmp As Integer = 0
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPICK_NO")
            While objReader.Read
                tmp = objReader.Item("PICK_NO")

            End While
            objReader.Close()
            Return tmp
        End Function
    End Class
End Namespace

