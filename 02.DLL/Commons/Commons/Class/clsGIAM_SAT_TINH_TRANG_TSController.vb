Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsGIAM_SAT_TINH_TRANG_TSController

        Public Sub New()
        End Sub
#Region "giám sat dịnh tinh ts"

        Public Function GetGIAM_SAT_TINH_TRANG_TSs(ByVal intSTT As Integer, ByVal LOAI As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_TSs", intSTT, Commons.Modules.UserName, LOAI))
            Return objDataTable
        End Function

        Public Function GetGIAM_SAT_TINH_TRANG_TS_MS_MAYs(ByVal intSTT As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_TS_MS_MAYs", intSTT))
            Return objDataTable
        End Function
        Public Function GetGIAM_SAT_TINH_TRANG_TSs_DAT(ByVal intSTT As Integer, ByVal bDat As Boolean, ByVal strMS_MAY As String, ByVal loai As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_TSs_DAT", intSTT, bDat, strMS_MAY, loai))
            Return objDataTable
        End Function
        Public Sub AddGIAM_SAT_TINH_TRANG_TS(ByVal obj As clsGIAM_SAT_TINH_TRANG_TSInfo)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddGIAM_SAT_TINH_TRANG_TS", obj.STT, obj.MS_MAY, obj.MS_TS_GSTT, obj.MS_BO_PHAN, Double.Parse(obj.GIA_TRI_DO), obj.MS_TT, obj.MS_CACH_TH, obj.MS_CONG_NHAN, obj.MS_PBT, obj.HANG_MUC_ID_KE_HOACH, obj.USERNAME, obj.STT_VAN_DE, obj.GHI_CHU, obj.TG_TT, obj.THOI_GIAN, obj.CACH_THUC_HIEN, obj.TIEU_CHUAN_KT, obj.YEU_CAU_NS, obj.YEU_CAU_DUNG_CU, obj.PATH_HD)

            'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddGIAM_SAT_TINH_TRANG_TS", obj.STT, obj.MS_MAY, obj.MS_TS_GSTT, obj.MS_BO_PHAN, Double.Parse(obj.GIA_TRI_DO), obj.MS_TT, obj.MS_CACH_TH, obj.MS_CONG_NHAN, obj.TG_XU_LY, obj.MS_PBT, obj.HANG_MUC_ID_KE_HOACH, obj.USERNAME, obj.STT_VAN_DE, obj.GHI_CHU, obj.TG_TT, obj.THOI_GIAN, obj.CACH_THUC_HIEN, obj.TIEU_CHUAN_KT, obj.YEU_CAU_NS, obj.YEU_CAU_DUNG_CU, obj.PATH_HD, obj.ID_DD, obj.DD_SN, obj.DD_NGAY)
        End Sub
        Public Sub DeleteGIAM_SAT_TINH_TRANG_TS_1(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG_TS_1", intSTT, strMS_MAY, intMS_TS_GSTT, strMS_BO_PHAN)
        End Sub

        Public Function CheckGIAM_SAT_TINH_TRANG_TS(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String, ByVal strMS_TT As Integer) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckGIAM_SAT_TINH_TRANG_TS", intSTT, strMS_MAY, intMS_TS_GSTT, strMS_BO_PHAN, strMS_TT)
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            Return False
        End Function

        Public Sub UpdateGIAM_SAT_TINH_TRANG_TS(ByVal obj As clsGIAM_SAT_TINH_TRANG_TSInfo)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateGIAM_SAT_TINH_TRANG_TS", obj.STT, obj.MS_MAY, obj.MS_TS_GSTT, obj.MS_BO_PHAN, obj.MS_TT, obj.GIA_TRI_DO)
        End Sub

        Public Sub DeleteGIAM_SAT_TINH_TRANG_TS_2(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String, ByVal intSTT_GT As Integer)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG_TS_2", intSTT, strMS_MAY, intMS_TS_GSTT, intSTT_GT, strMS_BO_PHAN)
        End Sub
#End Region
#Region "giám sat định tính ts dt"
        Public Sub AddGIAM_SAT_TINH_TRANG_TS_DT(ByVal obj As GIAM_SAT_TINH_TRANG_TS_DTInfo)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddGIAM_SAT_TINH_TRANG_TS_DT", obj.STT, obj.MS_MAY, obj.MS_TS_GSTT, obj.MS_BO_PHAN, obj.STT_GT, obj.MS_TT)
        End Sub
        Public Sub DeleteGIAM_SAT_TINH_TRANG_TS_DT(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String, ByVal intSTT_GT As Integer)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG_TS_DT", intSTT, strMS_MAY, intMS_TS_GSTT, strMS_BO_PHAN, intSTT_GT)
        End Sub
        Public Function CheckGIAM_SAT_TINH_TRANG_TS_DT(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String, ByVal intSTT_GT As Integer, ByVal strMS_TT As Integer) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckGIAM_SAT_TINH_TRANG_TS_DT", intSTT, strMS_MAY, intMS_TS_GSTT, strMS_BO_PHAN, intSTT_GT, strMS_TT)
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            Return False
        End Function
        Public Sub DeleteGIAM_SAT_TINH_TRANG_TS_DL(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String, ByVal intMSTT As Integer)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG_TS_DL", intSTT, strMS_MAY, intMS_TS_GSTT, strMS_BO_PHAN, intMSTT)
        End Sub
#End Region
    End Class

End Namespace
