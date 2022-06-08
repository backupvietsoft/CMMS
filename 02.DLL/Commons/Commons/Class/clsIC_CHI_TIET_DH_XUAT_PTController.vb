
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class IC_CHI_TIET_DH_XUAT_PTController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetIC_CHI_TIET_DH_XUAT_PT(ByVal MS_DH_XUAT_PT As String) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_CHI_TIET_DH_XUAT_PT", MS_DH_XUAT_PT))
            Return objDataTable
        End Function
        Public Function GetBO_TRI_XUAT_KHO_PT(ByVal MS_DH_XUAT_PT As String, ByVal MS_PT As String) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_TRI_XUAT_KHO_PT", MS_DH_XUAT_PT, MS_PT))
            Return objDataTable
        End Function
        Public Function CheckMS_PT_XUAT(ByVal MS_DH_XUAT_PT As String, ByVal MS_PT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckMS_PT_XUAT", MS_DH_XUAT_PT, MS_PT)
        End Function
        Public Sub AddIC_CHI_TIET_DH_XUAT_PT(ByVal MS_DH_XUAT_PT As String, ByVal MS_PT As String, ByVal SO_LUONG As Double, ByVal SL_CHUNG_TU As Double, ByVal DVT As String)
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "AddIC_CHI_TIET_DH_XUAT_PT", MS_DH_XUAT_PT, MS_PT, SO_LUONG, SL_CHUNG_TU, DVT)
        End Sub
        Public Sub AddBO_TRI_XUAT_KHO_PT(ByVal MS_DH_XUAT_PT As String, ByVal MS_PT As String, ByVal MS_VI_TRI As String, ByVal SO_LUONG As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddBO_TRI_XUAT_KHO_PT", MS_DH_XUAT_PT, MS_PT, MS_VI_TRI, SO_LUONG)
        End Sub
        Public Sub UpdateIC_CHI_TIET_DH_XUAT_PT(ByVal MS_DH_XUAT_PT As String, ByVal MS_PT As String, ByVal SO_LUONG As Double, ByVal SL_CHUNG_TU As Double, ByVal DVT As String)
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "UpdateIC_CHI_TIET_DH_XUAT_PT", MS_DH_XUAT_PT, MS_PT, SO_LUONG, SL_CHUNG_TU, DVT)
        End Sub
        Public Sub UpdateSO_LUONG_CHI_TIET_XUAT_PT(ByVal MS_DH_XUAT_PT As String, ByVal MS_PT As String, ByVal SO_LUONG As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateSO_LUONG_CHI_TIET_XUAT_PT", MS_DH_XUAT_PT, MS_PT, SO_LUONG)
        End Sub
        Public Sub DeleteBO_TRI_KHO_XUAT_PTs(ByVal MS_DH_XUAT_PT As String, ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteBO_TRI_KHO_XUAT_PTs", MS_DH_XUAT_PT, MS_PT)
        End Sub
        Public Sub DeleteIC_CHI_TIET_DH_XUAT_PT(ByVal MS_DH_XUAT_PT As String, ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteIC_CHI_TIET_DH_XUAT_PT", MS_DH_XUAT_PT, MS_PT)
        End Sub
        Public Sub DeleteBO_TRI_KHO_XUAT_PT(ByVal MS_DH_XUAT_PT As String, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteBO_TRI_KHO_XUAT_PT", MS_DH_XUAT_PT, MS_PT, MS_VI_TRI)
        End Sub
        Public Function GetPHU_TUNG_XUAT_KHOs(ByVal LANGUAGE As Integer, ByVal MS_KHO As Integer, Optional ByVal MS_LOAI_MAY As String = "", Optional ByVal MS_LOAI_PT As Integer = 0) As DataTable
            Dim QUERY As String = String.Empty
            Dim objDataTable As New DataTable
            If LANGUAGE = 0 Then
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNG_XUAT_KHO1s", MS_KHO, MS_LOAI_MAY, MS_LOAI_PT))
            ElseIf LANGUAGE = 1 Then
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNG_XUAT_KHO2s", MS_KHO, MS_LOAI_MAY, MS_LOAI_PT))
            ElseIf LANGUAGE = 2 Then
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNG_XUAT_KHO3s", MS_KHO, MS_LOAI_MAY, MS_LOAI_PT))
            End If
            Return objDataTable
        End Function
        Public Function GetPHU_TUNG_XUAT_KHO(ByVal LANGUAGE As Integer, ByVal MS_KHO As Integer) As DataTable
            Dim QUERY As String = String.Empty
            Dim objDataTable As New DataTable
            If LANGUAGE = 0 Then
                QUERY = "SELECT A.MS_PT AS MS_PT, TEN_PT, MS_PT_CTY, MS_PT_NCC, TEN_VI_TRI, TEN_1, SL_TON, ANH_PT, C.NGAY AS NGAY, B.MS_VI_TRI AS MS_VI_TRI FROM IC_PHU_TUNG A, VI_TRI_KHO B, KIEM_KE_PT C, DON_VI_TINH E, KIEM_KE_PT_VI_TRI F WHERE B.MS_KHO = C.MS_KHO And A.MS_PT = C.MS_PT And E.DVT = A.DVT AND C.NGAY LIKE (SELECT MAX(NGAY) FROM KIEM_KE_PT) AND B.MS_VI_TRI IN (SELECT MS_VI_TRI FROM KIEM_KE_PT_VI_TRI) AND C.MS_KHO=F.MS_KHO AND C.MS_PT=F.MS_PT"
            ElseIf LANGUAGE = 1 Then
                QUERY = "SELECT A.MS_PT AS MS_PT, TEN_PT, MS_PT_CTY, MS_PT_NCC, TEN_VI_TRI, TEN_2, SL_TON, ANH_PT, C.NGAY AS NGAY, B.MS_VI_TRI AS MS_VI_TRI FROM IC_PHU_TUNG A, VI_TRI_KHO B, KIEM_KE_PT C, DON_VI_TINH E, KIEM_KE_PT_VI_TRI F WHERE B.MS_KHO = C.MS_KHO And A.MS_PT = C.MS_PT And E.DVT = A.DVT AND C.NGAY LIKE (SELECT MAX(NGAY) FROM KIEM_KE_PT) AND B.MS_VI_TRI IN (SELECT MS_VI_TRI FROM KIEM_KE_PT_VI_TRI) AND C.MS_KHO=F.MS_KHO AND C.MS_PT=F.MS_PT"
            ElseIf LANGUAGE = 2 Then
                QUERY = "SELECT A.MS_PT AS MS_PT, TEN_PT, MS_PT_CTY, MS_PT_NCC, TEN_VI_TRI, TEN_3, SL_TON, ANH_PT, C.NGAY AS NGAY, B.MS_VI_TRI AS MS_VI_TRI FROM IC_PHU_TUNG A, VI_TRI_KHO B, KIEM_KE_PT C, DON_VI_TINH E, KIEM_KE_PT_VI_TRI F WHERE B.MS_KHO = C.MS_KHO And A.MS_PT = C.MS_PT And E.DVT = A.DVT AND C.NGAY LIKE (SELECT MAX(NGAY) FROM KIEM_KE_PT) AND B.MS_VI_TRI IN (SELECT MS_VI_TRI FROM KIEM_KE_PT_VI_TRI) AND C.MS_KHO=F.MS_KHO AND C.MS_PT=F.MS_PT"
            End If
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
#End Region
    End Class
End Namespace

