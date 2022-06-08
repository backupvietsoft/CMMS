Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class IC_CHI_TIET_DH_NHAP_PTController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetIC_CHI_TIET_DH_NHAP_PT(ByVal MS_DH_NHAP_PT As String) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_CHI_TIET_DH_NHAP_PT", MS_DH_NHAP_PT))
            Return objDataTable
        End Function
        Public Function GetXUAT_XUs() As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetXUAT_XUs"))
            Return objDataTable
        End Function
        Public Function GetIC_PHU_TUNGs(ByVal MS_PT As String, ByVal VALID_DATA As Integer, ByVal LANGUAGE As Integer, Optional ByVal MS_LOAI_MAY As String = "", Optional ByVal MS_LOAI_PT As Integer = 0) As DataTable
            Dim objDataTable As DataTable = New DataTable
            Dim QUERY As String = String.Empty
            If VALID_DATA = 1 Then
                If LANGUAGE = 0 Then
                    QUERY = "SELECT MS_PT, TEN_PT, MS_PT_CTY, MS_PT_NCC, B.TEN_1 AS DVT, ANH_PT FROM IC_PHU_TUNG A, DON_VI_TINH B WHERE A.DVT=B.DVT AND A.MS_PT NOT IN ('" & MS_PT & "') AND MS_LOAI_MAY='" & MS_LOAI_MAY & "' AND MS_LOAI_PT=" & MS_LOAI_PT
                ElseIf LANGUAGE = 1 Then
                    QUERY = "SELECT MS_PT, TEN_PT, MS_PT_CTY, MS_PT_NCC, B.TEN_2 AS DVT, ANH_PT FROM IC_PHU_TUNG A, DON_VI_TINH B WHERE A.DVT=B.DVT AND A.MS_PT NOT IN ('" & MS_PT & "') AND MS_LOAI_MAY='" & MS_LOAI_MAY & "' AND MS_LOAI_PT=" & MS_LOAI_PT
                ElseIf LANGUAGE = 2 Then
                    QUERY = "SELECT MS_PT, TEN_PT, MS_PT_CTY, MS_PT_NCC, B.TEN_3 AS DVT, ANH_PT FROM IC_PHU_TUNG A, DON_VI_TINH B WHERE A.DVT=B.DVT AND A.MS_PT NOT IN ('" & MS_PT & "') AND MS_LOAI_MAY='" & MS_LOAI_MAY & "' AND MS_LOAI_PT=" & MS_LOAI_PT
                End If
            ElseIf VALID_DATA = 2 Then
                If LANGUAGE = 0 Then
                    QUERY = "SELECT MS_PT, TEN_PT, MS_PT_CTY, MS_PT_NCC, B.TEN_1 AS DVT, ANH_PT FROM IC_PHU_TUNG A, DON_VI_TINH B WHERE A.DVT=B.DVT AND MS_LOAI_MAY='" & MS_LOAI_MAY & "' AND MS_LOAI_PT=" & MS_LOAI_PT
                ElseIf LANGUAGE = 1 Then
                    QUERY = "SELECT MS_PT, TEN_PT, MS_PT_CTY, MS_PT_NCC, B.TEN_2 AS DVT, ANH_PT FROM IC_PHU_TUNG A, DON_VI_TINH B WHERE A.DVT=B.DVT AND MS_LOAI_MAY='" & MS_LOAI_MAY & "' AND MS_LOAI_PT=" & MS_LOAI_PT
                ElseIf LANGUAGE = 2 Then
                    QUERY = "SELECT MS_PT, TEN_PT, MS_PT_CTY, MS_PT_NCC, B.TEN_3 AS DVT, ANH_PT FROM IC_PHU_TUNG A, DON_VI_TINH B WHERE A.DVT=B.DVT AND MS_LOAI_MAY='" & MS_LOAI_MAY & "' AND MS_LOAI_PT=" & MS_LOAI_PT
                End If
            End If
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
        Public Function GetIC_PHU_TUNG(ByVal MS_PT As String) As String
            Dim TEN_PHU_TUNG As String = String.Empty
            Dim reader As SqlDataReader
            reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNG", MS_PT)
            If reader.Read Then
                TEN_PHU_TUNG = reader.Item("TEN_PT")
            End If
            Return TEN_PHU_TUNG
        End Function
        Public Function GetNGOAI_TEs() As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGOAI_TEs"))
            Return objDataTable
        End Function
        Public Function GetTEMPs() As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTEMPs"))
            Return objDataTable
        End Function
        Public Function GetTI_GIA(ByVal NGOAI_TE As String) As String
            Dim TY_GIA As Double
            Dim reader As SqlDataReader
            reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA", NGOAI_TE)
            If reader.Read Then
                TY_GIA = reader.Item("TI_GIA")
            End If
            Return TY_GIA
        End Function
        Public Function checkMS_PT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "checkMS_PT", MS_DH_NHAP_PT, MS_PT)
        End Function
        Public Function CheckExistBO_TRI_NHAP_KHO_PT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistBO_TRI_NHAP_KHO_PT", MS_DH_NHAP_PT, MS_PT, MS_VI_TRI)
        End Function
        Public Function AddIC_CHI_TIET_DH_NHAP_PT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String, ByVal SO_LUONG As Double, ByVal SO_LUONG_CTU As Double, ByVal DVT As String, ByVal DON_GIA As Double, ByVal NGOAI_TE As String, ByVal TY_GIA As Double, ByVal DON_GIA_VN As Double, ByVal MS_NCC As String, ByVal XUAT_XU As String, ByVal BAO_HANH_DEN_NGAY As String) As Integer
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_CHI_TIET_DH_NHAP_PT", MS_DH_NHAP_PT, MS_PT, SO_LUONG, SO_LUONG_CTU, DVT, DON_GIA, NGOAI_TE, TY_GIA, DON_GIA_VN, MS_NCC, XUAT_XU, BAO_HANH_DEN_NGAY)
        End Function
        Public Sub AddBO_TRI_NHAP_KHO_PT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer, ByVal SO_LUONG As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddBO_TRI_NHAP_KHO_PT", MS_DH_NHAP_PT, MS_PT, MS_VI_TRI, SO_LUONG)
        End Sub
        Public Function UpdateIC_CHI_TIET_DH_NHAP_PT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String, ByVal SO_LUONG As Double, ByVal SO_LUONG_CTU As Double, ByVal DVT As String, ByVal DON_GIA As Double, ByVal NGOAI_TE As String, ByVal TY_GIA As Double, ByVal DON_GIA_VN As Double, ByVal MS_NCC As String, ByVal XUAT_XU As String, ByVal BAO_HANH_DEN_NGAY As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateIC_CHI_TIET_DH_NHAP_PT", MS_DH_NHAP_PT, MS_PT, SO_LUONG, SO_LUONG_CTU, DVT, DON_GIA, NGOAI_TE, TY_GIA, DON_GIA_VN, MS_NCC, XUAT_XU, BAO_HANH_DEN_NGAY), Integer)
        End Function
        Public Sub UpdateBO_TRI_NHAP_KHO_PT(ByVal MS_DH_NHAP_PT As String, ByVal OLD_MS_PT As String, ByVal NEW_MS_PT As String, ByVal OLD_MS_VI_TRI As Integer, ByVal NEW_MS_VI_TRI As Integer, ByVal SO_LUONG As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateBO_TRI_NHAP_KHO_PT", MS_DH_NHAP_PT, OLD_MS_PT, NEW_MS_PT, OLD_MS_VI_TRI, NEW_MS_VI_TRI, SO_LUONG)
        End Sub
        Public Sub DeleteIC_CHI_TIET_DH_NHAP_PT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteIC_CHI_TIET_DH_NHAP_PT", MS_DH_NHAP_PT, MS_PT)
        End Sub
        Public Sub DeleteBO_TRI_KHO_NHAP_PTs(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteBO_TRI_KHO_NHAP_PTs", MS_DH_NHAP_PT, MS_PT)
        End Sub
        Public Sub DeleteBO_TRI_KHO_NHAP_PT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteBO_TRI_KHO_NHAP_PT", MS_DH_NHAP_PT, MS_PT, MS_VI_TRI)
        End Sub
        Public Function GetMS_DVT(ByVal TEN_DVT As String, ByVal LANGUAGE As Integer) As String
            Dim DVT_READER As SqlDataReader
            Dim MSDVT As String = String.Empty
            Dim QUERY As String = String.Empty
            If LANGUAGE = 0 Then
                QUERY = "SELECT DVT FROM DON_VI_TINH WHERE TEN_1='" & TEN_DVT & "'"
            ElseIf LANGUAGE = 1 Then
                QUERY = "SELECT DVT FROM DON_VI_TINH WHERE TEN_2='" & TEN_DVT & "'"
            ElseIf LANGUAGE = 2 Then
                QUERY = "SELECT DVT FROM DON_VI_TINH WHERE TEN_3='" & TEN_DVT & "'"
            End If
            DVT_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
            If DVT_READER.Read Then
                MSDVT = DVT_READER.Item(0)
            End If
            Return MSDVT
        End Function
        Public Function GetMS_KH(ByVal TEN_CONG_TY As String) As String
            Dim MS_KH_READER As SqlDataReader
            Dim MS_KH As String = String.Empty
            MS_KH_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_KH", TEN_CONG_TY)
            If MS_KH_READER.Read Then
                MS_KH = MS_KH_READER.Item(0)
            End If
            Return MS_KH
        End Function
        Public Function GetTEN_CONG_TY(ByVal MS_KH As String) As String
            Dim TEN_CT_READER As SqlDataReader
            Dim TEN_CONG_TY As String = String.Empty
            Dim QUERY As String = "SELECT TEN_CONG_TY FROM KHACH_HANG WHERE MS_KH='" & MS_KH & "'"
            TEN_CT_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
            If TEN_CT_READER.Read Then
                TEN_CONG_TY = TEN_CT_READER.Item(0)
            End If
            Return TEN_CONG_TY
        End Function
        Public Function GetTEN_DVT(ByVal DVT As String, ByVal LANGUAGE As Integer) As String
            Dim TEN_DVT_READER As SqlDataReader
            Dim TEN_DVT As String = String.Empty
            Dim QUERY As String = String.Empty
            If LANGUAGE = 0 Then
                QUERY = "SELECT TEN_1 FROM DON_VI_TINH WHERE DVT='" & DVT & "'"
            ElseIf LANGUAGE = 1 Then
                QUERY = "SELECT TEN_2 FROM DON_VI_TINH WHERE DVT='" & DVT & "'"
            ElseIf LANGUAGE = 2 Then
                QUERY = "SELECT TEN_3 FROM DON_VI_TINH WHERE DVT='" & DVT & "'"
            End If
            TEN_DVT_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
            If TEN_DVT_READER.Read Then
                TEN_DVT = TEN_DVT_READER.Item(0)
            End If
            Return TEN_DVT
        End Function
        Public Function GetMS_DON_HANG_NHAP_PT(ByVal MS_DH_NHAP_PT As String) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_DON_HANG_NHAP_PT", MS_DH_NHAP_PT))
            Return objDataTable
        End Function
        Public Function GetIC_CT_DH_NHAP_PT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_CT_DH_NHAP_PT", MS_DH_NHAP_PT, MS_PT))
            Return objDataTable
        End Function
        Public Function GetTEN_PHU_TUNG(ByVal MS_PT As String) As String
            Dim TEN_PT_READER As SqlDataReader
            Dim TEN_PHU_TUNG As String = String.Empty
            TEN_PT_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTEN_PT", MS_PT)
            If TEN_PT_READER.Read Then
                TEN_PHU_TUNG = TEN_PT_READER.Item(0)
            End If
            Return TEN_PHU_TUNG
        End Function
        Public Function GetMS_PHU_TUNG(ByVal TEN_PT As String) As String
            Dim TEN_PHU_TUNG As String = String.Empty
            Dim TEN_PT_READER As SqlDataReader
            TEN_PT_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_PHU_TUNG", TEN_PT)
            If TEN_PT_READER.Read Then
                TEN_PHU_TUNG = TEN_PT_READER.Item(0)
            End If
            Return TEN_PHU_TUNG
        End Function
        Public Sub UpdateSO_LUONG_CHI_TIET_NHAP_PT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String, ByVal SO_LUONG As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateSO_LUONG_CHI_TIET_NHAP_PT", MS_DH_NHAP_PT, MS_PT, SO_LUONG)
        End Sub

        Public Function GetSPARE_PART(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String) As DataTable
            Dim QUERY As String = "SELECT MS_PT, DVT FROM IC_CHI_TIET_DH_NHAP_PT WHERE MS_DH_NHAP_PT='" & MS_DH_NHAP_PT & "'" & " AND MS_PT NOT IN ('" & MS_PT & "')"
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
        Public Function GetALL_SPARE_PARTs(ByVal MS_DH_NHAP_PT As String) As DataTable
            Dim QUERY As String = "SELECT MS_PT, DVT FROM IC_CHI_TIET_DH_NHAP_PT WHERE MS_DH_NHAP_PT='" & MS_DH_NHAP_PT & "'"
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function
        Public Function GetLOAI_THIET_BI(ByVal USERNAME As String) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_THIET_BI", USERNAME))
            Return objDataTable
        End Function
        Public Function GetLOAI_PHU_TUNG(ByVal USERNAME As String) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_PT", USERNAME))
            Return objDataTable
        End Function
        Public Function GetVI_TRI_KHOs(ByVal MS_KHO As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTEN_VI_TRI_KHOs", MS_KHO))
            Return objDataTable
        End Function
        Public Function GetBO_TRI_NHAP_KHO_PT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_TRI_NHAP_KHO_PT", MS_DH_NHAP_PT, MS_PT))
            Return objDataTable
        End Function
        'GetBO_TRI_NHAP_KHO_PT_TMP
        Public Function GetBO_TRI_NHAP_KHO_PT_TMP(ByVal MS_KHO As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_TRI_NHAP_KHO_PT_TMP", MS_KHO))
            Return objDataTable
        End Function
#End Region
    End Class
End Namespace
