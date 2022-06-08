Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Catalogue

Public Class KHACH_HANGController

    Public Sub New()

    End Sub

#Region "Public Method"
    Public Function GetKHACH_HANGs() As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHACH_HANGs"))
        Return objDataTable
    End Function

    Public Function GetKHACH_HANG(ByVal ID As Integer) As KHACH_HANGInfo
        Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHACH_HANG", ID)
        Dim objKHACH_HANGInfo As New KHACH_HANGInfo
        While objDataReader.Read
            objKHACH_HANGInfo.MS_KH = objDataReader.Item("MS_KH")
            objKHACH_HANGInfo.DIA_CHI = objDataReader.Item("DIA_CHI")
            objKHACH_HANGInfo.TEN_CONG_TY = objDataReader.Item("TEN_CONG_TY")
            objKHACH_HANGInfo.TEL = objDataReader.Item("TEL")
            objKHACH_HANGInfo.FAX = objDataReader.Item("FAX")
            objKHACH_HANGInfo.TEN_NDD = objDataReader.Item("TEN_NDD")
            objKHACH_HANGInfo.TEN_RUT_GON = objDataReader.Item("TEN_RUT_GON")
            objKHACH_HANGInfo.EMAIL = objDataReader.Item("EMAIL")
            objKHACH_HANGInfo.QUOCGIA = objDataReader.Item("QUOCGIA")
            objKHACH_HANGInfo.TAI_KHOAN_ANH = objDataReader.Item("TAI_KHOAN_ANH")
            objKHACH_HANGInfo.MS_THUE = objDataReader.Item("MS_THUE")
        End While
        objDataReader.Close()
        Return objKHACH_HANGInfo
    End Function

    Public Function AddKHACH_HANG(ByVal objKHACH_HANGInfo As KHACH_HANGInfo) As String
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddKHACH_HANG", _
            objKHACH_HANGInfo.MS_KH, objKHACH_HANGInfo.TEN_CONG_TY, objKHACH_HANGInfo.DIA_CHI, _
            objKHACH_HANGInfo.TEL, objKHACH_HANGInfo.FAX, objKHACH_HANGInfo.TEN_NDD, _
            objKHACH_HANGInfo.TEN_RUT_GON, objKHACH_HANGInfo.EMAIL, objKHACH_HANGInfo.QUOCGIA, objKHACH_HANGInfo.TAI_KHOAN_ANH, objKHACH_HANGInfo.MS_THUE)
        Return True
    End Function

    Public Sub Update_KHACH_HANG_MAY(ByVal objKHACH_HANGInfo As KHACH_HANGInfo)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_KHACH_HANG_MAY", _
            objKHACH_HANGInfo.MS_KH, objKHACH_HANGInfo.MS_KH_tmp)
    End Sub
    Public Sub InsertMay_LOG(ByVal ID As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
    End Sub
    Public Sub UpdateKHACH_HANG(ByVal objKHACH_HANGInfo As KHACH_HANGInfo)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKHACH_HANG", _
            objKHACH_HANGInfo.MS_KH, objKHACH_HANGInfo.TEN_CONG_TY, objKHACH_HANGInfo.DIA_CHI, _
            objKHACH_HANGInfo.TEL, objKHACH_HANGInfo.FAX, objKHACH_HANGInfo.TEN_NDD, _
            objKHACH_HANGInfo.TEN_RUT_GON, objKHACH_HANGInfo.EMAIL, objKHACH_HANGInfo.MS_KH_tmp, objKHACH_HANGInfo.QUOCGIA, objKHACH_HANGInfo.TAI_KHOAN_ANH, objKHACH_HANGInfo.MS_THUE)
    End Sub
    Public Sub InsertKHACH_HANG_LOG(ByVal ID As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKHACH_HANG_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
    End Sub

    Public Sub DeleteKHACH_HANG(ByVal MS_KH As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKHACH_HANG", MS_KH)
    End Sub
    Public Function CheckMS_KH(ByVal MS_KH As String) As SqlDataReader
        Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckMS_KH", MS_KH)
    End Function

    Public Function AddNguoidaidien(ByVal objkhachhanginfo As KHACH_HANGInfo, ByVal FORMNAME As String) As Integer
        Dim STT As Integer = CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddNGUOI_DAI_DIEN",
             objkhachhanginfo.MS_KH, objkhachhanginfo.NGUOI_DAI_DIEN, objkhachhanginfo.CHUC_VU,
             objkhachhanginfo.DI_DONG, objkhachhanginfo.DIEN_THOAI, objkhachhanginfo.DIEN_THOAI_NHA,
             objkhachhanginfo.EMAIL2, objkhachhanginfo.GHI_CHU, objkhachhanginfo.DIA_CHI_NHA_RIENG), Integer)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NGUOI_DAI_DIEN_LOG", STT, objkhachhanginfo.MS_KH, FORMNAME, Commons.Modules.UserName, 1)
        Return STT
    End Function

    Public Sub Update_Nguoidaidien(ByVal objkhachhanginfo As KHACH_HANGInfo, ByVal FORMNAME As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NGUOI_DAI_DIEN_LOG", objkhachhanginfo.STT, objkhachhanginfo.MS_KH, FORMNAME, Commons.Modules.UserName, 2)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_Nguoidaidien", _
            objkhachhanginfo.MS_KH, objkhachhanginfo.STT, objkhachhanginfo.NGUOI_DAI_DIEN, _
            objkhachhanginfo.CHUC_VU, objkhachhanginfo.DI_DONG, objkhachhanginfo.DIEN_THOAI, _
            objkhachhanginfo.DIEN_THOAI_NHA, objkhachhanginfo.EMAIL2, objkhachhanginfo.GHI_CHU, _
            objkhachhanginfo.DIA_CHI_NHA_RIENG)
    End Sub

    Public Sub deleteNguoidaidien(ByVal MS_KH As String, ByVal STT As Integer, ByVal FORMNAME As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NGUOI_DAI_DIEN_LOG", STT, MS_KH, FORMNAME, Commons.Modules.UserName, 3)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Delete_NGUOI_DAI_DIEN", MS_KH, STT)
    End Sub
    Public Sub InsertNGUOI_DAI_DIEN_LOG(ByVal ID As String, ByVal ID1 As Integer, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateNGUOI_DAI_DIEN_LOG", ID, ID1, FORM_NAME, USER_NAME, THAO_TAC)
    End Sub

    Public Sub deleteAllNguoidaidien(ByVal ms_kh As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Delete_All_NGUOI_DAI_DIEN", ms_kh)
    End Sub

    Public Function getNguoidaidien(ByVal ms_kh As String) As DataTable
        Dim objdatatable As DataTable = New DataTable
        objdatatable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_NGUOI_DAI_DIEN", ms_kh))
        Return objdatatable
    End Function

    Public Function CheckNguoidaidien(ByVal MS_KH As String, ByVal STT As Integer) As Boolean
        Dim objdatatable As DataTable = New DataTable
        objdatatable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckNguoidaidien", MS_KH, STT))
        If objdatatable.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
#End Region

End Class
