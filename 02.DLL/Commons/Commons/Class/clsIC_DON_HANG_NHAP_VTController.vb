Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class IC_DON_HANG_NHAP_VTController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetIC_DON_HANG_NHAP_VTs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_DON_HANG_NHAP_VTs"))
            Return objDataTable
        End Function
        Public Function GetNGAYs() As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAY_NHAP_VTs"))
            Return objDataTable
        End Function
        Public Function GetIC_DON_HANG_NHAP_VT(ByVal MONTH As String, ByVal YEAR As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            Dim Query = "SELECT * FROM IC_DON_HANG_NHAP_VT WHERE MONTH(NGAY_NHAP)=" & MONTH & "AND YEAR(NGAY_NHAP) = " & YEAR
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Query))
            Return objDataTable
        End Function
        Public Function GetMS_DH_NHAP_VT() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_DH_NHAP_VT"))
            Return objDataTable
        End Function
        Public Function AddIC_DON_HANG_NHAP_VT(ByVal MS_DH_NHAP_VT As String, ByVal SO_PHIEU_XN As String, ByVal MS_DANG_NHAP As Integer, ByVal NGUOI_NHAP As String, ByVal NGAY_NHAP As Date, ByVal MS_KHO As Integer, ByVal GHI_CHU As String, ByVal NGAY_CHUNG_TU As Date, ByVal SO_CHUNG_TU As String, ByVal LOCK As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_DON_HANG_NHAP_VT", MS_DH_NHAP_VT, SO_PHIEU_XN, MS_DANG_NHAP, NGUOI_NHAP, NGAY_NHAP, MS_KHO, GHI_CHU, NGAY_CHUNG_TU, SO_CHUNG_TU, LOCK), Integer)
        End Function
        Public Function CheckMS_DH_NHAP_VT(ByVal MS_DH_NHAP_VT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckMS_DH_NHAP_VT", MS_DH_NHAP_VT)
        End Function
        Public Function UpdateIC_DON_HANG_NHAP_VT(ByVal MS_DH_NHAP_VT As String, ByVal SO_PHIEU_XN As String, ByVal MS_DANG_NHAP As Integer, ByVal NGUOI_NHAP As String, ByVal NGAY_NHAP As Date, ByVal MS_KHO As Integer, ByVal GHI_CHU As String, ByVal NGAY_CHUNG_TU As Date, ByVal SO_CHUNG_TU As String, ByVal LOCK As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateIC_DON_HANG_NHAP_VT", MS_DH_NHAP_VT, SO_PHIEU_XN, MS_DANG_NHAP, NGUOI_NHAP, NGAY_NHAP, MS_KHO, GHI_CHU, NGAY_CHUNG_TU, SO_CHUNG_TU, LOCK), Integer)
        End Function
        Public Function CheckExistMS_DH_NHAP_VT(ByVal MS_DH_NHAP_VT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistMS_DH_NHAP_VT", MS_DH_NHAP_VT)
        End Function
        Public Function DeleteIC_DON_HANG_NHAP_VT(ByVal MS_DH_NHAP_VT As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteIC_DON_HANG_NHAP_VT", MS_DH_NHAP_VT), Integer)
        End Function
        Public Function GetMS_DANG_NHAP(ByVal DANG_NHAP As String) As Integer
            Dim MS_DANG_NHAP As Integer
            Dim DANG_NHAP_READER As SqlDataReader
            DANG_NHAP_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_DANG_NHAP", DANG_NHAP)
            If DANG_NHAP_READER.Read Then
                MS_DANG_NHAP = DANG_NHAP_READER.Item(0)
            End If
            Return MS_DANG_NHAP
        End Function
#End Region
    End Class
End Namespace
