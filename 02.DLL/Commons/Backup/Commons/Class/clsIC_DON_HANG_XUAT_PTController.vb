Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class IC_DON_HANG_XUAT_PTController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetMS_DH_XUAT_PT() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_DH_XUAT_PT"))
            Return objDataTable
        End Function
        Public Function GetNGAY_XUATs() As DataTable
            Try
                Dim objDataTable As New DataTable
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAY_XUATs"))
                Return objDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Sub AddIC_DON_HANG_XUAT_PT(ByVal MS_DH_XUAT_PT As String, ByVal SO_PHIEU_XN As String, ByVal NGAY As Date, ByVal NGUOI_NHAN As String, ByVal MS_KHO As Integer, ByVal GHI_CHU As String, ByVal MS_DANG_XUAT As Integer, ByVal LOCK As Integer, ByVal GIO As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_DON_HANG_XUAT_PT", MS_DH_XUAT_PT, SO_PHIEU_XN, NGAY, NGUOI_NHAN, MS_KHO, GHI_CHU, MS_DANG_XUAT, LOCK, GIO)
        End Sub
        Public Sub UpdateIC_DON_HANG_XUAT_PT(ByVal MS_DH_XUAT_PT As String, ByVal SO_PHIEU_XN As String, ByVal NGAY As Date, ByVal NGUOI_NHAN As String, ByVal MS_KHO As Integer, ByVal GHI_CHU As String, ByVal MS_DANG_XUAT As Integer, ByVal LOCK As Integer, ByVal GIO As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateIC_DON_HANG_XUAT_PT", MS_DH_XUAT_PT, SO_PHIEU_XN, NGAY, NGUOI_NHAN, MS_KHO, GHI_CHU, MS_DANG_XUAT, LOCK, GIO)
        End Sub
        Public Function GetIC_DON_HANG_XUAT_PT(ByVal THANG As Integer, ByVal NAM As Integer, ByVal LANGUAGE As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            Dim QUERY As String = String.Empty
            If LANGUAGE = 0 Then
                QUERY = "SELECT MS_DH_XUAT_PT, NGUOI_NHAN, NGAY, TEN_KHO, GHI_CHU, SO_PHIEU_XN, DANG_XUAT_VIET, LOCK, GIO FROM IC_DON_HANG_XUAT_PT A, IC_KHO B, DANG_XUAT C WHERE A.MS_KHO=B.MS_KHO AND A.MS_DANG_XUAT=C.MS_DANG_XUAT AND MONTH(NGAY)=" & THANG & " AND YEAR(NGAY)=" & NAM
            ElseIf LANGUAGE = 1 Then
                QUERY = "SELECT MS_DH_XUAT_PT, NGUOI_NHAN, NGAY, TEN_KHO, GHI_CHU, SO_PHIEU_XN, DANG_XUAT_ANH, LOCK, GIO FROM IC_DON_HANG_XUAT_PT A, IC_KHO B, DANG_XUAT C WHERE A.MS_KHO=B.MS_KHO AND A.MS_DANG_XUAT=C.MS_DANG_XUAT AND MONTH(NGAY)=" & THANG & " AND YEAR(NGAY)=" & NAM
            ElseIf LANGUAGE = 2 Then
                QUERY = "SELECT MS_DH_XUAT_PT, NGUOI_NHAN, NGAY, TEN_KHO, GHI_CHU, SO_PHIEU_XN, DANG_XUAT_HOA, LOCK, GIO FROM IC_DON_HANG_XUAT_PT A, IC_KHO B, DANG_XUAT C WHERE A.MS_KHO=B.MS_KHO AND A.MS_DANG_XUAT=C.MS_DANG_XUAT AND MONTH(NGAY)=" & THANG & " AND YEAR(NGAY)=" & NAM
            End If
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
        Public Function CheckExistedMS_DH_XUAT_PT(ByVal MS_DH_XUAT_PT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistedMS_DH_XUAT_PT", MS_DH_XUAT_PT)
        End Function
        Public Sub DeleteIC_DON_HANG_XUAT_PT(ByVal MS_DH_XUAT_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteIC_DON_HANG_XUAT_PT", MS_DH_XUAT_PT)
        End Sub
#End Region
    End Class
End Namespace
