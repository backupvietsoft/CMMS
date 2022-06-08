Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsCHON_CONG_VIEC_CHO_PBTController

    Public Sub New()
    End Sub
    Public Function GetDANH_SACH_ROAs(ByVal MS_MAY As String, ByVal TU_NGAY As String, ByVal DEN_NGAY As String, ByVal USERNAME As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_ROAs", MS_MAY, TU_NGAY, DEN_NGAY, USERNAME))
        Return objDataTable
    End Function
    Public Function GetDANH_SACH_EOR_CONG_VIECs(ByVal EOR_ID As String, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_EOR_CONG_VIECs", EOR_ID, USERNAME, MS_PHIEU_BAO_TRI))
        Return objDataTable
    End Function
    Public Function GetDANH_SACH_EOR_CONG_VIEC_PHU_TROs(ByVal EOR_ID As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_EOR_CONG_VIEC_PHU_TROs", EOR_ID))
        Return objDataTable
    End Function

    Public Function GetDANH_DACH_KE_HOACH_THONG_THEs(ByVal MS_MAY As String, ByVal TU_NGAY As DateTime, ByVal DEN_NGAY As DateTime, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_DACH_KE_HOACH_THONG_THEs", MS_MAY, TU_NGAY, DEN_NGAY, USERNAME, MS_PHIEU_BAO_TRI))

        Return objDataTable
    End Function

    Public Function GetDANH_DACH_KE_HOACH_THONG_THEs_KHBT(ByVal MS_MAY As String, ByVal TU_NGAY As DateTime, ByVal DEN_NGAY As DateTime, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String) As DataTable
        Dim objDataTable As DataTable = New DataTable


        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_DACH_KE_HOACH_THONG_THE_KHBTs", MS_MAY, TU_NGAY, DEN_NGAY, USERNAME, MS_PHIEU_BAO_TRI))

        Return objDataTable
    End Function

    Public Function GetDANH_DACH_KE_HOACH_THONG_THEs_THUE_NGOAI(ByVal MS_MAY As String, ByVal TU_NGAY As DateTime, ByVal DEN_NGAY As DateTime, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_DACH_KE_HOACH_THONG_THEs_THUE_NGOAI", MS_MAY, TU_NGAY, DEN_NGAY, USERNAME, MS_PHIEU_BAO_TRI))
        Return objDataTable
    End Function
    Public Function GetDANH_SACH_KE_HOACH_TONG_THE_CONG_VIECs(ByVal MS_MAY As String, ByVal HANG_MUC_ID As Integer, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_KE_HOACH_TONG_THE_CONG_VIECs", MS_MAY, HANG_MUC_ID, USERNAME, MS_PHIEU_BAO_TRI))
        Return objDataTable
    End Function
    Public Function GetDANH_SACH_KE_HOACH_TONG_THE_CONG_VIECs_KHBT(ByVal MS_MAY As String, ByVal HANG_MUC_ID As Integer, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String, ByVal KH_NAM As Integer, ByVal KH_THANG As Integer) As DataTable
        Dim objDataTable As DataTable = New DataTable
        ''KHBT

        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_KE_HOACH_TONG_THE_CONG_VIECs_KHBT", MS_MAY, HANG_MUC_ID, USERNAME, MS_PHIEU_BAO_TRI, KH_NAM, KH_THANG))

        Return objDataTable
    End Function

    Public Function GetDANH_SACH_KE_HOACH_TONG_THE_CONG_VIECs_THUE_NGOAI(ByVal MS_MAY As String, ByVal HANG_MUC_ID As Integer, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_KE_HOACH_TONG_THE_CONG_VIECs_THUE_NGOAI", MS_MAY, HANG_MUC_ID, USERNAME, MS_PHIEU_BAO_TRI))
        Return objDataTable
    End Function
    'Public Function GetDANH_SACH_KE_HOACH_TONG_CONG_VIEC_PHU_TUNGs(ByVal MS_MAY As String, ByVal HANG_MUC_ID As Integer, ByVal MS_CV As String, ByVal MS_BO_PHAN As String, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String) As DataTable
    '    Dim objDataTable As DataTable = New DataTable
    '    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_KE_HOACH_TONG_CONG_VIEC_PHU_TUNGs", MS_MAY, HANG_MUC_ID, MS_CV, MS_BO_PHAN, USERNAME, MS_PHIEU_BAO_TRI))
    '    Return objDataTable
    'End Function

    Public Function GetDANH_SACH_CAU_TRUC_THIET_BIs(ByVal MS_MAY As String, ByVal USERNAME As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_CAU_TRUC_THIET_BIs", MS_MAY, USERNAME))
        Return objDataTable
    End Function

    Public Function GetDANH_SACH_CAU_TRUC_THIET_BI_CONG_VIECs(ByVal MS_MAY As String, ByVal MS_BO_PHAN As String, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_CAU_TRUC_THIET_BI_CONG_VIECs", MS_MAY, MS_BO_PHAN, USERNAME, MS_PHIEU_BAO_TRI))
        Return objDataTable
    End Function
    Public Function GetDANH_SACH_VAT_TU_PHU_TUNGs(ByVal TYPE As Integer, ByVal MS_MAY As String, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_VAT_TU_PHU_TUNGs", TYPE, MS_MAY, USERNAME, MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN))
        Return objDataTable
    End Function
    Public Function GetDANH_SACH_CAU_TRUC_THIET_BI_PTs(ByVal TYPE As Integer, ByVal MS_MAY As String, ByVal MS_BO_PHAN As String, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_CAU_TRUC_THIET_BI_PTs", TYPE, MS_MAY, MS_BO_PHAN, USERNAME, MS_PHIEU_BAO_TRI, MS_CV))
        Return objDataTable
    End Function

    Public Function GetDANH_SACH_CAU_TRUC_THIET_BI_PT_THUE_NGOAIs(ByVal TYPE As Integer, ByVal MS_MAY As String, ByVal MS_BO_PHAN As String, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_CAU_TRUC_THIET_BI_PT_THUE_NGOAIs", TYPE, MS_MAY, MS_BO_PHAN, USERNAME, MS_PHIEU_BAO_TRI, MS_CV))
        Return objDataTable
    End Function
    Public Function GetDANH_SACH_CAU_TRUC_THIET_BI_PHU_TUNGs(ByVal TYPE As Integer, ByVal USERNAME As String, ByVal MS_MAY As String, ByVal MS_BO_PHAN As String, ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_CAU_TRUC_THIET_BI_PHU_TUNGs", TYPE, USERNAME, MS_MAY, MS_BO_PHAN, MS_PHIEU_BAO_TRI, MS_CV))
        Return objDataTable
    End Function
    Public Function GetDANH_SACH_CAU_TRUC_THIET_BI_PHU_TUNGs_ThueNgoai(ByVal TYPE As Integer, ByVal USERNAME As String, ByVal MS_MAY As String, ByVal MS_BO_PHAN As String, ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_CAU_TRUC_THIET_BI_PHU_TUNGs_ThueNgoai", TYPE, USERNAME, MS_MAY, MS_BO_PHAN, MS_PHIEU_BAO_TRI, MS_CV))
        Return objDataTable
    End Function
    Public Function GetDANH_SACH_KE_HOACH_TONG_CONG_VIEC_PHU_TUNGs(ByVal MS_MAY As String, ByVal HANG_MUC_ID As Integer, ByVal MS_CV As String, ByVal MS_BO_PHAN As String, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_KE_HOACH_TONG_CONG_VIEC_PHU_TUNGs", MS_MAY, HANG_MUC_ID, MS_CV, MS_BO_PHAN, USERNAME, MS_PHIEU_BAO_TRI))
        Return objDataTable
    End Function
    Public Function GetDANH_SACH_KE_HOACH_TONG_CONG_VIEC_PHU_TUNGs_KHBT(ByVal MS_MAY As String, ByVal HANG_MUC_ID As Integer, ByVal MS_CV As String, ByVal MS_BO_PHAN As String, ByVal USERNAME As String, ByVal MS_PHIEU_BAO_TRI As String, ByVal KH_NAM As Integer, ByVal KH_THANG As Integer) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANH_SACH_KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIETs_KHBT", MS_MAY, HANG_MUC_ID, MS_CV, MS_BO_PHAN, USERNAME, MS_PHIEU_BAO_TRI, KH_NAM, KH_THANG))
        Return objDataTable
    End Function


#Region "Chon tai lieu cho PBT"

    Public Function GetYEU_CAU_NSD_Cho_PBTs(ByVal TU_NGAY As String, ByVal DEN_NGAY As String, ByVal MS_MAY As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_Cho_PBTs", TU_NGAY, DEN_NGAY, MS_MAY))
        Return objDataTable
    End Function
    Public Function GetGIAM_SAT_TINH_TRANG_Cho_PBTs(ByVal TU_NGAY As String, ByVal DEN_NGAY As String, ByVal MS_MAY As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_Cho_PBTs", TU_NGAY, DEN_NGAY, MS_MAY))
        Return objDataTable
    End Function

#End Region
End Class
