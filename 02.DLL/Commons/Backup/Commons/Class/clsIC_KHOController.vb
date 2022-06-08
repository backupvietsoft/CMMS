Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class IC_KHOController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetIC_KHOs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_KHOs"))
            objDataTable.Columns("NGAY_LOCK1").AllowDBNull = True
            objDataTable.Columns("NGAY_LOCK1").ReadOnly = False

            objDataTable.Columns("GIO_LOCK1").AllowDBNull = True
            objDataTable.Columns("GIO_LOCK1").ReadOnly = False

            Return objDataTable
        End Function

        Public Function GetIC_KHO(ByVal MS_KHO As Integer) As IC_KHOInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_KHO", MS_KHO)
            Dim objIC_KHOInfo As New IC_KHOInfo
            While objDataReader.Read
                objIC_KHOInfo.MS_KHO = objDataReader.Item("MS_KHO")
                objIC_KHOInfo.TEN_KHO = objDataReader.Item("TEN_KHO")
                objIC_KHOInfo.DIA_CHI = objDataReader.Item("DIA_CHI")
                objIC_KHOInfo.SO_DO = objDataReader.Item("SO_DO")
                objIC_KHOInfo.NGAY_LOCK = objDataReader.Item("NGAY_LOCK")
                objIC_KHOInfo.GIO_LOCK = objDataReader.Item("GIO_LOCK")

                objIC_KHOInfo.KHO_DD = objDataReader.Item("KHO_DD")
                objIC_KHOInfo.MS_KHO_CHINH = objDataReader.Item("MS_KHO_CHINH")
                objIC_KHOInfo.MS_DON_VI = objDataReader.Item("MS_DON_VI")


            End While
            Return objIC_KHOInfo
        End Function

        Public Sub AddIC_KHO(ByVal objIC_KHOInfo As IC_KHOInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_KHO", objIC_KHOInfo.TEN_KHO, objIC_KHOInfo.DIA_CHI, _
                    objIC_KHOInfo.SO_DO, objIC_KHOInfo.KHO_DD, objIC_KHOInfo.MS_KHO_CHINH, objIC_KHOInfo.MS_DON_VI)
        End Sub

        Public Sub UpdateIC_KHO(ByVal objIC_KHOInfo As IC_KHOInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateIC_KHO", objIC_KHOInfo.MS_KHO, objIC_KHOInfo.TEN_KHO, _
                    objIC_KHOInfo.DIA_CHI, objIC_KHOInfo.SO_DO, objIC_KHOInfo.KHO_DD, objIC_KHOInfo.MS_KHO_CHINH, objIC_KHOInfo.MS_DON_VI)
        End Sub
        Public Sub DeleteIC_KHO(ByVal MS_KHO As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteIC_KHO", MS_KHO)
        End Sub

        Public Function GetVI_TRI_KHO(ByVal MS_KHO As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetVI_TRI_KHO", MS_KHO))
            Return objDataTable
        End Function
        Public Sub AddVI_TRI_KHO(ByVal TEN_VI_TRI As String, ByVal MS_KHO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddVI_TRI_KHO", TEN_VI_TRI, MS_KHO)
        End Sub

        Public Sub Update_VI_TRI_KHO(ByVal MS_VI_TRI As Integer, ByVal TEN_VI_TRI As String, ByVal MS_KHO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateVI_TRI_KHO", MS_VI_TRI, TEN_VI_TRI, MS_KHO)
        End Sub

        Public Sub DeleteVI_TRI_KHOs(ByVal MS_KHO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteVI_TRI_KHO", MS_KHO)
        End Sub

        Public Sub DeleteVI_TRI_KHO(ByVal MS_VI_TRI As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteVI_TRI", MS_VI_TRI)
        End Sub
        Public Sub DeleteNHOM_KHO_1(ByVal MS_KHO As Integer, ByVal USERNAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNHOM_KHO_1", MS_KHO, USERNAME)
        End Sub
#End Region

#Region "Relatives"
#Region "Kiểm tra MS_KHO đang được sử dụng trong các table khac"
        ' Kiểm tra MS_KHO có đang tồn tại trong table IC_DON_HANG_NHAP_PT không?
        Public Function CheckUsedIC_KHO_DH_NHAP_PT(ByVal MS_KHO As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedIC_KHO_DH_NHAP_PT", MS_KHO))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        ' Kiểm tra MS_KHO có đang tồn tại trong table IC_KHO_DH_XUAT_PT không?
        Public Function CheckUsedIC_KHO_DH_XUAT_PT(ByVal MS_KHO As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedIC_KHO_DH_XUAT_PT", MS_KHO))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        ' Kiểm tra MS_KHO có đang tồn tại trong table IC_KIEM_KE_PT không?
        Public Function CheckUsedIC_KHO_KK_PT(ByVal MS_KHO As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedIC_KHO_KK_PT", MS_KHO))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        ' Kiểm tra MS_KHO có đang tồn tại trong table VI_TRI_KHO không?
        Public Function CheckUsedIC_KHO_VT_KHO(ByVal MS_KHO As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedIC_KHO_VT_KHO", MS_KHO))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

#End Region
        ' Hàm này dùng để kiểm tra tên kho này đã tồn tại hay chưa.
        ' Nều đã tồn tại thì yêu cầu nhập tên khác.
        Public Function CheckTEN_KHO(ByVal TEN_KHO As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_KHO", TEN_KHO))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        ' Hàm này dùng để lấy mã số của kho vừa mới được nhập vào.
        ' Vì mã số kho là tăng tự đông, nên chi khi kho được thêm vào trong CSDL thì mã số mới được tạo ra.
        ' Do đó, cần phải lấy MS_KHO tương ứng để sau đó thực hiện thêm vào vị trí của các kho tương ứng.
        Public Function GET_MS_KHO_new(ByVal TEN_KHO As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_MS_KHO_new", TEN_KHO))
            Return objDataTable
        End Function

#Region "Kiem tra vị trí dang tồn tại trong các bảng khác"
        ' Kiểm tra MS_VI_TRI có đang tồn tại trong table KIEM_KE_PT_VI_TRI không?
        Public Function CheckUsedKIEM_KE_PT_VI_TRI(ByVal MS_VI_TRI As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedKIEM_KE_PT_VI_TRI", MS_VI_TRI))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function CheckUsedIC_VAT_TU_PT(ByVal MS_VI_TRI As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedIC_VAT_TU_PT", MS_VI_TRI))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        ' Kiểm tra MS_VI_TRI có đang tồn tại trong table BO_TRI_NHAP_KHO_PT không?
        Public Function CheckUsedBO_TRI_NHAP_KHO_PT(ByVal MS_VI_TRI As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVT_BO_TRI_NHAP_KHO_PT", MS_VI_TRI))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        ' Kiểm tra MS_VI_TRI có đang tồn tại trong table BO_TRI_XUAT_KHO_PT không?
        Public Function CheckUsedVITRI_KHO_XUAT_PT(ByVal MS_VI_TRI As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVITRI_KHO_XUAT_PT", MS_VI_TRI))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function CheckUsedVI_TRI_KHO_VAT_TU(ByVal MS_VI_TRI As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVI_TRI_KHO_VAT_TU", MS_VI_TRI))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function CheckUsedIC_DON_HANG_NHAP_VAT_TU_CHI_TIET(ByVal MS_VI_TRI As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedIC_DON_HANG_NHAP_VAT_TU_CHI_TIET", MS_VI_TRI))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedVI_TRI_KHO_VAT_TU_MS_KHO(ByVal MS_KHO As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVI_TRI_KHO_VAT_TU_MS_KHO", MS_KHO))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function CheckUsedDI_CHUYEN_VI_TRI_TRONG_KHO_MS_KHO(ByVal MS_KHO As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedDI_CHUYEN_VI_TRI_TRONG_KHO_MS_KHO", MS_KHO))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
#End Region
#End Region

    End Class
End Namespace

