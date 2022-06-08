Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsprintnhanvien
    Public Sub Printlylichcongnhan(ByVal manhanvien As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Printlylichcongnhan", manhanvien)
    End Sub

    Public Sub Update_bangngayhuhong()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_bangngayhuhong")
    End Sub

    Public Sub PrintTainancongnhan(ByVal manhanvien As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "PrintTainancongnhan", manhanvien)
    End Sub

    Public Sub Deletecongnhan()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Deletecongnhan")
    End Sub

    Public Sub PrintBactho(ByVal manhanvien As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "PrintBactho", manhanvien)
    End Sub
    Public Function PrintBacluong(ByVal manhanvien As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PrintBacluong", manhanvien))
        Return objDataTable
    End Function
    Public Function Getdonvibaocao() As DataTable
        Dim objDataTable As New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getdonvibaocao"))
        Return objDataTable
    End Function
    Public Function Gettophongbanbaocao(ByVal manv As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Gettophongbanbaocao", manv))
        Return objDataTable
    End Function


    Public Sub Updateimage(ByVal manhanvien As String, ByVal IMAGE() As Byte)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Updateimage", manhanvien, IMAGE)
    End Sub

    Public Function CheckYeucauNSD(ByVal stt As Double) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckYeucauNSD", stt))
        Return objDataTable
    End Function
    Public Function Getchucvu_cn(ByVal manhanvien As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getchucvu_cn", manhanvien))
        Return objDataTable
    End Function

    Public Function Getbocongnhanbyma(ByVal MS_CONG_NHAN As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getbocongnhanbyma", MS_CONG_NHAN))
        Return objDataTable
    End Function
    Public Function Getduongdan(ByVal MS_CONG_NHAN As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getduongdan", MS_CONG_NHAN))
        Return objDataTable
    End Function
    Public Function Getbaocaonhanvien(ByVal madv As String, ByVal maban As String, ByVal dk As Integer) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getbaocaonhanvien", madv, maban, dk))
        Return objDataTable
    End Function
    Public Function Getnhanvienbaocao(ByVal msto As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getnhanvienbaocao", msto))
        Return objDataTable
    End Function
    Public Function Getbaocaodonvi() As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getbaocaodonvi"))
        Return objDataTable
    End Function
    Public Function GetbaocaoToban(ByVal manv As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetbaocaoToban", manv))
        Return objDataTable
    End Function
    Public Function GETMAXNGAYNHAP(ByVal maMAY As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GETMAXNGAYNHAP", maMAY))
        Return objDataTable
    End Function
    Public Function GETHETHONG(ByVal MS_MAY As String, ByVal ngay_nhap As DateTime) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GETHETHONG", MS_MAY, ngay_nhap))
        Return objDataTable
    End Function
    Public Function Getnguyennhanhuhong(ByVal ms_nguyen_nhan As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getnguyennhanhuhong", ms_nguyen_nhan))
        Return objDataTable
    End Function
    Public Function Getquy_baocao() As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getquy_baocao"))
        Return objDataTable
    End Function
    Public Function Getthang_baocao() As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getthang_baocao"))
        Return objDataTable
    End Function
    Public Function Getnam_baocao() As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Getnam_baocao"))
        Return objDataTable
    End Function

    Public Function Tinhthoigian_baocao(ByVal MS_MAY As String, ByVal quy As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Tinhthoigian_baocao", MS_MAY, quy))
        Return objDataTable
    End Function
    Public Function Tinhthoigianbythang(ByVal MS_MAY As String, ByVal thang As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Tinhthoigianbythang", MS_MAY, thang))
        Return objDataTable
    End Function
    Public Function Tinhthoigianbaocaobynam(ByVal MS_MAY As String, ByVal nam As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Tinhthoigianbaocaobynam", MS_MAY, nam))
        Return objDataTable
    End Function
    Public Sub BAOCAOGIAMSATTINHTRANGDENHAN(ByVal ms_n_xuong As String, ByVal den_ngay As DateTime)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "BAOCAOGIAMSATTINHTRANGDENHAN", ms_n_xuong, den_ngay)
    End Sub
    Public Sub BAOCAOGIAMSATTINHTRANGDENHAN_CHUYEN(ByVal ms_n_xuong As String, ByVal den_ngay As DateTime)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "BAOCAOGIAMSATTINHTRANGDENHAN_CHUYEN", ms_n_xuong, den_ngay)
    End Sub

    Public Sub Rpttinhthoigiantrungbinh()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Rpttinhthoigiantrungbinh")
    End Sub

    Public Sub Rpttinhthoigiantrungbinh_byDC()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Rpttinhthoigiantrungbinh_byDC")
    End Sub
    Public Function Baocao_Tinhthoigiantrungbinh_quy(ByVal MS_MAY As String, ByVal quy As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Baocao_Tinhthoigiantrungbinh_quy", MS_MAY, quy))
        Return objDataTable
    End Function
    Public Function GETALLNHAXUONG() As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GETALLNHAXUONG"))
        Return objDataTable
    End Function
    Public Function GETALLHETHONG() As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GETALLHETHONG"))
        Return objDataTable
    End Function


    Public Function Baocao_Tinhthoigiantrungbinh_thang(ByVal MS_MAY As String, ByVal thang As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Baocao_Tinhthoigiantrungbinh_thang", MS_MAY, thang))
        Return objDataTable
    End Function
    Public Function Baocao_Tinhthoigiantrungbinh_nam(ByVal MS_MAY As String, ByVal nam As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Baocao_Tinhthoigiantrungbinh_nam", MS_MAY, nam))
        Return objDataTable
    End Function

    'viet add
    'frmTGSC_TheoDC
    Public Function Baocao_Tinhthoigiansuachuatrungbinh_quy(ByVal MS_MAY As String, ByVal quy As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "rptTinhthoigiansuachuatrungbinh_quy", MS_MAY, quy))
        Return objDataTable
    End Function

    Public Function Baocao_Tinhthoigiansuachuatrungbinh_thang(ByVal MS_MAY As String, ByVal thang As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "rptTinhthoigiansuachuatrungbinh_thang", MS_MAY, thang))
        Return objDataTable
    End Function
    Public Function Baocao_Tinhthoigiansuachuatrungbinh_nam(ByVal MS_MAY As String, ByVal nam As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "rptTinhthoigiansuachuatrungbinh_nam", MS_MAY, nam))
        Return objDataTable
    End Function

    'frmTGSC_TheoMay
    Public Sub Rpttinhthoigiansuachuatrungbinh()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Rpttinhthoigiansuachuatrungbinh")
    End Sub
End Class
