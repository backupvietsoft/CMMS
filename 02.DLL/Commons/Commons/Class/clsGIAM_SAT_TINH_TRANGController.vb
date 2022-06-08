Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class GIAM_SAT_TINH_TRANGController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetGIAM_SAT_TINH_TRANGs(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANGs", MS_MAY))
            Return objDataTable
        End Function

        Public Function GetCONG_NHANs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHANs"))
            Return objDataTable
        End Function

        Public Function GetGIAM_SAT_TINH_TRANG_ALLs(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_ALLs", MS_MAY))
            Return objDataTable
        End Function

        Public Function GetGIAM_SAT_TINH_TRANG(ByVal ID As Integer) As THONG_SO_GSTTInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG", ID)
            Dim objTHONG_SO_GSTTInfo As New THONG_SO_GSTTInfo
            While objDataReader.Read
                objTHONG_SO_GSTTInfo.MS_TS_GSTT = objDataReader.Item("MS_TS_GSTT")
                objTHONG_SO_GSTTInfo.TEN_TS_GSTT = objDataReader.Item("TEN_TS_GSTT")
                objTHONG_SO_GSTTInfo.MS_DV_DO = objDataReader.Item("MS_DV_DO")
                objTHONG_SO_GSTTInfo.LOAI_TS = objDataReader.Item("LOAI_TS")
                objTHONG_SO_GSTTInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
            End While
            objDataReader.Close()
            Return objTHONG_SO_GSTTInfo
        End Function

        Public Sub AddGIAM_SAT_TINH_TRANG(ByVal objTHONG_SO_GSTTInfo As THONG_SO_GSTTInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddGIAM_SAT_TINH_TRANG", objTHONG_SO_GSTTInfo.MS_TS_GSTT, objTHONG_SO_GSTTInfo.TEN_TS_GSTT, objTHONG_SO_GSTTInfo.MS_DV_DO, objTHONG_SO_GSTTInfo.LOAI_TS, objTHONG_SO_GSTTInfo.GHI_CHU)
        End Sub

        'Public Sub UpdateTHONG_SO_GSTT(ByVal objTHONG_SO_GSTTInfo As THONG_SO_GSTTInfo)
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTHONG_SO_GSTT", objTHONG_SO_GSTTInfo.MS_TS_GSTT, objTHONG_SO_GSTTInfo.TEN_TS_GSTT, objTHONG_SO_GSTTInfo.MS_DV_DO, objTHONG_SO_GSTTInfo.LOAI_TS, objTHONG_SO_GSTTInfo.GHI_CHU)
        'End Sub

        Public Sub DeleteGIAM_SAT_TINH_TRANG(ByVal MS_TS_GSTT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG", MS_TS_GSTT)
        End Sub
#End Region
#Region "PRIVATE"
        Public Function GetGIAM_SAT_TINH_TRANG_ALL(ByVal strTU_NGAY As String, ByVal strDEN_NGAY As String, ByVal strMS_CONG_NHAN As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_ALL", strTU_NGAY, strDEN_NGAY, strMS_CONG_NHAN))
            Return objDataTable
        End Function
        Public Function GetGIAM_SAT_TINH_TRANG_MS_CONG_NHANs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_MS_CONG_NHANs"))
            Return objDataTable
        End Function
        Public Function GetNHOM_MAYs_MS_N_XUONG_MS_LOAI_MAY(ByVal strMS_LOAI_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHOM_MAYs_MS_N_XUONG_MS_LOAI_MAY", strMS_LOAI_MAY))
            Return objDataTable
        End Function
        Public Function GetMS_MAYs_MS_N_XUONG_MS_LOAI_MAY_MS_NHOM_MAY(ByVal intMS_N_XUONG As Integer, ByVal strMS_LOAI_MAY As String, ByVal strMS_NHOM_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_MAYs_MS_N_XUONG_MS_LOAI_MAY_MS_NHOM_MAY", intMS_N_XUONG, strMS_LOAI_MAY, strMS_NHOM_MAY))
            Return objDataTable
        End Function

        Public Function GetGIAM_SAT_TINH_TRANG_STT_MAX() As Integer
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAM_SAT_TINH_TRANG_STT_MAX")
            Dim intTam As Integer = 0
            While objDataReader.Read
                intTam = objDataReader.Item("STT")
            End While
            objDataReader.Close()
            Return intTam
        End Function
        Public Sub DeleteGIAM_SAT_TINH_TRANG_TS(ByVal intSTT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG_TS", intSTT)
        End Sub
        Public Sub DeleteGIAM_SAT_TINH_TRANG(ByVal intSTT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_GIAM_SAT_TINH_TRANG_LOG", intSTT, "frmGiamsattinhtrang", Commons.Modules.UserName, 3)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG", intSTT)
        End Sub
        Public Function AddGIAM_SAT_TINH_TRANG_1(ByVal obj As GIAM_SAT_TINH_TRANGInfo) As Integer
            Return SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddGIAM_SAT_TINH_TRANG_1", obj.GIO_KT, obj.DEN_GIO, obj.NGAY_KT, obj.MS_CONG_NHAN, obj.GIO_CHAY_MAY, obj.NHAN_XET, obj.USERNAME, obj.SO_PHIEU, obj.HOAN_THANH, obj.NGAY_KT_GOC)
        End Function
        Public Sub UpdateGIAM_SAT_TINH_TRANG(ByVal obj As GIAM_SAT_TINH_TRANGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateGIAM_SAT_TINH_TRANG", obj.STT, obj.GIO_KT, obj.DEN_GIO, obj.NGAY_KT, obj.MS_CONG_NHAN)
        End Sub
#End Region

    End Class
End Namespace
