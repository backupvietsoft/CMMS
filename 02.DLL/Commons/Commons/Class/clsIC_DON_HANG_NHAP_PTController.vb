Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.IEStock

Namespace VS.Classes.IEStock
    Public Class IC_DON_HANG_NHAP_PTController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetNHA_CUNG_CAPs() As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHA_CUNG_CAPs"))
            Return objDataTable
        End Function
        Public Function GetCONG_NHANs() As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHANs"))
            Return objDataTable
        End Function
        Public Function GetNHAP_KHACs() As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHAP_KHACs"))
            Return objDataTable
        End Function
        'Public Function GetMS_DH_NHAP_PT() As DataTable
        '    Dim objDataTable As DataTable = New DataTable
        '    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_DH_NHAP_PT"))
        '    Return objDataTable
        'End Function
        Public Function GetMS_DH_NHAP_PT() As Integer
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_DH_NHAP_PT")
            While objDataReader.Read
                If IsDBNull(objDataReader.Item("MS_DH_NHAP_PT")) Then
                    objDataReader.Close()
                    Return 0
                End If
                Dim MS_DH_NHAP_PT As Integer = objDataReader.Item("MS_DH_NHAP_PT")
                objDataReader.Close()
                Return MS_DH_NHAP_PT
            End While
            objDataReader.Close()
            Return 0
        End Function
        Public Sub AddIC_DON_HANG_NHAP_PT(ByVal objDHN_Info As IC_DON_HANG_NHAP_PTInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_DON_HANG_NHAP_PT", _
                objDHN_Info.MS_DH_NHAP_PT, objDHN_Info.SO_PHIEU_XN, objDHN_Info.MS_DANG_NHAP, _
                objDHN_Info.NGUOI_NHAP, objDHN_Info.NGAY, objDHN_Info.MS_KHO, objDHN_Info.GHI_CHU, _
                objDHN_Info.NGAY_CHUNG_TU, objDHN_Info.SO_CHUNG_TU, objDHN_Info.LOCK, objDHN_Info.GIO, _
                objDHN_Info.DIEM, objDHN_Info.DANH_GIA)
        End Sub
        Public Function GetIC_DON_HANG_NHAP_PTs(ByVal MONTH As String, ByVal YEAR As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_DON_HANG_NHAP_PTs", MONTH, YEAR))
            Return objDataTable
        End Function
        Public Function GetIC_DON_HANG_NHAP_PT(ByVal THANG As Integer, ByVal NAM As Integer, ByVal LANGUAGE As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            Dim QUERY As String = String.Empty
            If LANGUAGE = 0 Then
                QUERY = "SELECT MS_DH_NHAP_PT, SO_PHIEU_XN, DANG_NHAP_VIET, NGUOI_NHAP, NGAY, TEN_KHO, NGAY_CHUNG_TU, SO_CHUNG_TU, LOCK, GHI_CHU, DIEM, DANH_GIA, GIO FROM IC_DON_HANG_NHAP_PT, IC_KHO, DANG_NHAP WHERE IC_DON_HANG_NHAP_PT.MS_KHO = IC_KHO.MS_KHO AND IC_DON_HANG_NHAP_PT.MS_DANG_NHAP = DANG_NHAP.MS_DANG_NHAP AND MONTH(NGAY)=" & THANG & " AND YEAR(NGAY)=" & NAM
            ElseIf LANGUAGE = 1 Then
                QUERY = "SELECT MS_DH_NHAP_PT, SO_PHIEU_XN, DANG_NHAP_ANH, NGUOI_NHAP, NGAY, TEN_KHO, NGAY_CHUNG_TU, SO_CHUNG_TU, LOCK, GHI_CHU, DIEM, DANH_GIA, GIO FROM IC_DON_HANG_NHAP_PT, IC_KHO, DANG_NHAP WHERE IC_DON_HANG_NHAP_PT.MS_KHO = IC_KHO.MS_KHO AND IC_DON_HANG_NHAP_PT.MS_DANG_NHAP = DANG_NHAP.MS_DANG_NHAP AND MONTH(NGAY)=" & THANG & " AND YEAR(NGAY)=" & NAM
            ElseIf LANGUAGE = 2 Then
                QUERY = "SELECT MS_DH_NHAP_PT, SO_PHIEU_XN, DANG_NHAP_HOA, NGUOI_NHAP, NGAY, TEN_KHO, NGAY_CHUNG_TU, SO_CHUNG_TU, LOCK, GHI_CHU, DIEM, DANH_GIA, GIO FROM IC_DON_HANG_NHAP_PT, IC_KHO, DANG_NHAP WHERE IC_DON_HANG_NHAP_PT.MS_KHO = IC_KHO.MS_KHO AND IC_DON_HANG_NHAP_PT.MS_DANG_NHAP = DANG_NHAP.MS_DANG_NHAP AND MONTH(NGAY)=" & THANG & " AND YEAR(NGAY)=" & NAM
            End If
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
        Public Sub UpdateIC_DON_HANG_NHAP_PT(ByVal objDHN_Info As IC_DON_HANG_NHAP_PTInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateIC_DON_HANG_NHAP_PT", _
                        objDHN_Info.MS_DH_NHAP_PT, objDHN_Info.SO_PHIEU_XN, objDHN_Info.MS_DANG_NHAP, _
                        objDHN_Info.NGUOI_NHAP, objDHN_Info.NGAY, objDHN_Info.MS_KHO, objDHN_Info.GHI_CHU, _
                        objDHN_Info.NGAY_CHUNG_TU, objDHN_Info.SO_CHUNG_TU, objDHN_Info.LOCK, _
                        objDHN_Info.GIO, objDHN_Info.DIEM, objDHN_Info.DANH_GIA)
        End Sub
        Public Sub DeleteIC_DON_HANG_NHAP_PT(ByVal MS_DH_NHAP_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteIC_DON_HANG_NHAP_PT", MS_DH_NHAP_PT)
        End Sub

        Public Function CheckExistMS_DH_NHAP_PT(ByVal MS_DH_NHAP_PT As String) As Boolean
            Dim objDatatable As New DataTable
            objDatatable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistMS_DH_NHAP_PT", MS_DH_NHAP_PT))
            If objDatatable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function CheckExistedSO_PHIEU_XN(ByVal SO_PHIEU_NHAP) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistedSO_PHIEU_XN", SO_PHIEU_NHAP)
        End Function
        Public Function GetNGAYs() As DataTable
            'Try
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAYs"))
            Return objDataTable
            'Catch ex As Exception
            '    Throw ex
            'End Try
        End Function
        Public Function GetDIEMs() As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDIEMs"))
            Return objDataTable
        End Function
        Public Function GetMS_DH_NHAP_PTs(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String) As DataTable
            Dim objDataTable As New DataTable
            Dim query As String
            query = "SELECT IC.MS_DH_NHAP_PT AS IC_MS_DH_NHAP_PT, PT.MS_PT AS PT_MS_PT, PT.TEN_PT AS PT_TEN_PT, IC.DVT AS IC_DVT FROM IC_CHI_TIET_DH_NHAP_PT IC, IC_PHU_TUNG PT WHERE IC.MS_PT=PT.MS_PT AND IC.MS_DH_NHAP_PT !=" & "'" & MS_DH_NHAP_PT & "'" & " AND PT.MS_PT NOT IN(" & MS_PT & ")"
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, query))
            Return objDataTable
        End Function
        Public Function GetTEN_CONG_TY(ByVal MS_KH As String) As String
            Dim TEN_CONG_TY As String = String.Empty
            Dim TEN_CTY_READER As SqlDataReader
            Dim QUERY As String = "SELECT TEN_CONG_TY FROM KHACH_HANG WHERE MS_KH='" & MS_KH & "'"
            TEN_CTY_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
            If TEN_CTY_READER.Read Then
                TEN_CONG_TY = TEN_CTY_READER.Item("TEN_CONG_TY")
            End If
            Return TEN_CONG_TY
        End Function
        Public Function GetTEN_CONG_NHAN(ByVal MS_CONG_NHAN As String) As String
            Dim TEN_CONG_NHAN As String = String.Empty
            Dim TEN_CONG_NHAN_READER As SqlDataReader
            Dim QUERY As String = "SELECT (HO + ' ' + TEN) AS TEN_CONG_NHAN FROM CONG_NHAN WHERE MS_CONG_NHAN='" & MS_CONG_NHAN & "'"
            TEN_CONG_NHAN_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
            If TEN_CONG_NHAN_READER.Read Then
                TEN_CONG_NHAN = TEN_CONG_NHAN_READER.Item("TEN_CONG_NHAN")
            End If
            Return TEN_CONG_NHAN
        End Function
#End Region
    End Class
End Namespace
