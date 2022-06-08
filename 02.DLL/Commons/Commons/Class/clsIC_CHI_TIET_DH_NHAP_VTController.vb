Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class IC_CHI_TIET_DH_NHAP_VTController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetIC_CHI_TIET_DH_NHAP_VT(ByVal MS_DH_NHAP_VT As String) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_CHI_TIET_DH_NHAP_VT", MS_DH_NHAP_VT))
            Return objDataTable
        End Function
        Public Function checkMS_VT(ByVal MS_DH_NHAP_VT As String, ByVal MS_VT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "checkMS_VT", MS_DH_NHAP_VT, MS_VT)
        End Function
        Public Function UpdateIC_CHI_TIET_DH_NHAP_VT(ByVal MS_DH_NHAP_VT As String, ByVal MS_VT As String, ByVal SO_LUONG_NHAP As Double, ByVal SO_LUONG_CTU As Double, ByVal DVT As String, ByVal DON_GIA As Double, ByVal NGOAI_TE As String, ByVal DON_GIA_VN As Double, ByVal TY_GIA As Double) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateIC_CHI_TIET_DH_NHAP_VT", MS_DH_NHAP_VT, MS_VT, SO_LUONG_NHAP, SO_LUONG_CTU, DVT, DON_GIA, NGOAI_TE, DON_GIA_VN, TY_GIA), Integer)
        End Function
        Public Sub AddIC_CHI_TIET_DH_NHAP_VT(ByVal MS_DH_NHAP_VT As String, ByVal MS_VT As String, ByVal SO_LUONG_NHAP As Double, ByVal SO_LUONG_CTU As Double, ByVal DVT As String, ByVal DON_GIA As Double, ByVal NGOAI_TE As String, ByVal DON_GIA_VN As Double, ByVal TY_GIA As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_CHI_TIET_DH_NHAP_VT", MS_DH_NHAP_VT, MS_VT, SO_LUONG_NHAP, SO_LUONG_CTU, DVT, DON_GIA, NGOAI_TE, DON_GIA_VN, TY_GIA)
        End Sub
        Public Function DeleteIC_CHI_TIET_DH_NHAP_VT(ByVal MS_DH_NHAP_VT As String, ByVal MS_VT As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteIC_CHI_TIET_DH_NHAP_VAT_TU", MS_DH_NHAP_VT, MS_VT), Integer)
        End Function
        Public Function GetIC_VAT_TUs(ByVal LANGUAGE As Integer) As DataTable
            Dim objDataTable As New DataTable
            Dim QUERY As String = String.Empty
            If LANGUAGE = 0 Then
                QUERY = "SELECT MS_VAT_TU, TEN_VAT_TU, TEN_1 AS DVT FROM IC_VAT_TU A, DON_VI_TINH B WHERE A.DVT=B.DVT"
            ElseIf LANGUAGE = 1 Then
                QUERY = "SELECT MS_VAT_TU, TEN_VAT_TU, TEN_2 AS DVT FROM IC_VAT_TU A, DON_VI_TINH B WHERE A.DVT=B.DVT"
            ElseIf LANGUAGE = 2 Then
                QUERY = "SELECT MS_VAT_TU, TEN_VAT_TU, TEN_3 AS DVT FROM IC_VAT_TU A, DON_VI_TINH B WHERE A.DVT=B.DVT"
            End If
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
        Public Function GetIC_VAT_TU(ByVal MS_VT As String, ByVal LANGUAGE As Integer) As DataTable
            Dim objDataTable As New DataTable
            Dim QUERY As String = String.Empty
            If LANGUAGE = 0 Then
                QUERY = "SELECT MS_VAT_TU, TEN_VAT_TU, TEN_1 AS DVT FROM IC_VAT_TU A, DON_VI_TINH B WHERE A.DVT=B.DVT AND MS_VAT_TU NOT IN ('" & MS_VT & "')"
            ElseIf LANGUAGE = 1 Then
                QUERY = "SELECT MS_VAT_TU, TEN_VAT_TU, TEN_2 AS DVT FROM IC_VAT_TU A, DON_VI_TINH B WHERE A.DVT=B.DVT AND MS_VAT_TU NOT IN ('" & MS_VT & "')"
            ElseIf LANGUAGE = 2 Then
                QUERY = "SELECT MS_VAT_TU, TEN_VAT_TU, TEN_3 AS DVT FROM IC_VAT_TU A, DON_VI_TINH B WHERE A.DVT=B.DVT AND MS_VAT_TU NOT IN ('" & MS_VT & "')"
            End If
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
        Public Function GetMS_DON_HANG_NHAP_VT(ByVal MS_DH_NHAP_VT As String) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_DON_HANG_NHAP_VT", MS_DH_NHAP_VT))
            Return objDataTable
        End Function
        Public Function GetALL_MATERIALs(ByVal MS_DH_NHAP_VT As String) As DataTable
            Dim QUERY As String = "SELECT MS_VAT_TU, DVT FROM IC_CHI_TIET_DH_NHAP_VAT_TU WHERE MS_DH_NHAP_VT='" & MS_DH_NHAP_VT & "'"
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
        Public Function GetMATERIAL(ByVal MS_DH_NHAP_VT As String, ByVal MS_VT As String) As DataTable
            Dim QUERY As String = "SELECT MS_VAT_TU, DVT FROM IC_CHI_TIET_DH_NHAP_VAT_TU WHERE MS_DH_NHAP_VT='" & MS_DH_NHAP_VT & "'" & " AND MS_VAT_TU NOT IN ('" & MS_VT & "')"
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
        Public Function GetTEN_VAT_TU(ByVal MS_VT As String) As String
            Dim TEN_VT_READER As SqlDataReader
            Dim TEN_VAT_TU As String = String.Empty
            TEN_VT_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTEN_VT", MS_VT)
            If TEN_VT_READER.Read Then
                TEN_VAT_TU = TEN_VT_READER.Item(0)
            End If
            Return TEN_VAT_TU
        End Function
#End Region

    End Class
End Namespace
