Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsGIAM_SAT_TINH_TRANG_HINHController

        Public Sub New()
        End Sub
        Public Function GetGIAM_SAT_TINH_TRANG_HINHs(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal MS_BO_PHAN As String, ByVal MS_TT As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_HINHs", intSTT, strMS_MAY, intMS_TS_GSTT, MS_BO_PHAN, MS_TT))
            Return objDataTable
        End Function
        Public Function GetGIAM_SAT_TINH_TRANG_TS_DT(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal MS_BO_PHAN As String, ByVal LOAI As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_TS_DT", intSTT, strMS_MAY, MS_BO_PHAN, intMS_TS_GSTT, LOAI))
            Return objDataTable
        End Function
        Public Function GetGIAM_SAT_TINH_TRANG_HINHs_ALL(ByVal intSTT As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_HINHs_ALL", intSTT))
            Return objDataTable
        End Function
        Public Sub AddGIAM_SAT_TINH_TRANG_HINH(ByVal objGIAM_SAT_TINH_TRANG_HINHInfo As clsGIAM_SAT_TINH_TRANG_HINHInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddGIAM_SAT_TINH_TRANG_HINH", _
           objGIAM_SAT_TINH_TRANG_HINHInfo.STT, objGIAM_SAT_TINH_TRANG_HINHInfo.MS_MAY, objGIAM_SAT_TINH_TRANG_HINHInfo.MS_TS_GSTT, objGIAM_SAT_TINH_TRANG_HINHInfo.MS_BO_PHAN, _
           objGIAM_SAT_TINH_TRANG_HINHInfo.MS_TT, objGIAM_SAT_TINH_TRANG_HINHInfo.DUONG_DAN, objGIAM_SAT_TINH_TRANG_HINHInfo.GHI_CHU)
        End Sub
        Public Sub DeleteGIAM_SAT_TINH_TRANG_HINH(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String, ByVal intSTT_HINH As Integer, ByVal intMSTT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG_HINH", intSTT, strMS_MAY, intMS_TS_GSTT, strMS_BO_PHAN, intSTT_HINH, intMSTT)
        End Sub

        Public Sub UpdateGIAM_SAT_TINH_TRANG_HINH(ByVal objGIAM_SAT_TINH_TRANG_HINHInfo As clsGIAM_SAT_TINH_TRANG_HINHInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateGIAM_SAT_TINH_TRANG_HINH", _
           objGIAM_SAT_TINH_TRANG_HINHInfo.STT, objGIAM_SAT_TINH_TRANG_HINHInfo.MS_MAY, objGIAM_SAT_TINH_TRANG_HINHInfo.MS_TS_GSTT, objGIAM_SAT_TINH_TRANG_HINHInfo.MS_BO_PHAN, _
           objGIAM_SAT_TINH_TRANG_HINHInfo.MS_TT, objGIAM_SAT_TINH_TRANG_HINHInfo.STT_HINH, objGIAM_SAT_TINH_TRANG_HINHInfo.GHI_CHU)
        End Sub
    End Class
End Namespace

