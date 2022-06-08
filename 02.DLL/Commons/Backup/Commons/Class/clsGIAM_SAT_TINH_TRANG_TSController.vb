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
        Public Sub AddGIAM_SAT_TINH_TRANG_TS(ByVal objGIAM_SAT_TINH_TRANGInfo As clsGIAM_SAT_TINH_TRANG_TSInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddGIAM_SAT_TINH_TRANG_TS", objGIAM_SAT_TINH_TRANGInfo.STT, objGIAM_SAT_TINH_TRANGInfo.MS_MAY, objGIAM_SAT_TINH_TRANGInfo.MS_TS_GSTT, objGIAM_SAT_TINH_TRANGInfo.MS_BO_PHAN, Double.Parse(objGIAM_SAT_TINH_TRANGInfo.GIA_TRI_DO), objGIAM_SAT_TINH_TRANGInfo.MS_TT)
        End Sub
        Public Sub DeleteGIAM_SAT_TINH_TRANG_TS_1(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG_TS_1", intSTT, strMS_MAY, intMS_TS_GSTT, strMS_BO_PHAN)
        End Sub

        Public Function CheckGIAM_SAT_TINH_TRANG_TS(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String, ByVal strMS_TT As Integer) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckGIAM_SAT_TINH_TRANG_TS", intSTT, strMS_MAY, intMS_TS_GSTT, strMS_BO_PHAN, strMS_TT)
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            Return False
        End Function

        Public Sub UpdateGIAM_SAT_TINH_TRANG_TS(ByVal objGIAM_SAT_TINH_TRANGInfo As clsGIAM_SAT_TINH_TRANG_TSInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateGIAM_SAT_TINH_TRANG_TS", objGIAM_SAT_TINH_TRANGInfo.STT, objGIAM_SAT_TINH_TRANGInfo.MS_MAY, objGIAM_SAT_TINH_TRANGInfo.MS_TS_GSTT, objGIAM_SAT_TINH_TRANGInfo.MS_BO_PHAN, objGIAM_SAT_TINH_TRANGInfo.MS_TT, objGIAM_SAT_TINH_TRANGInfo.GIA_TRI_DO)
        End Sub

        Public Sub DeleteGIAM_SAT_TINH_TRANG_TS_2(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String, ByVal intSTT_GT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG_TS_2", intSTT, strMS_MAY, intMS_TS_GSTT, intSTT_GT, strMS_BO_PHAN)
        End Sub
#End Region
#Region "giám sat định tính ts dt"
        Public Sub AddGIAM_SAT_TINH_TRANG_TS_DT(ByVal objGIAM_SAT_TINH_TRANGInfo As GIAM_SAT_TINH_TRANG_TS_DTInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddGIAM_SAT_TINH_TRANG_TS_DT", objGIAM_SAT_TINH_TRANGInfo.STT, objGIAM_SAT_TINH_TRANGInfo.MS_MAY, objGIAM_SAT_TINH_TRANGInfo.MS_TS_GSTT, objGIAM_SAT_TINH_TRANGInfo.MS_BO_PHAN, objGIAM_SAT_TINH_TRANGInfo.STT_GT, objGIAM_SAT_TINH_TRANGInfo.MS_TT)
        End Sub
        Public Sub DeleteGIAM_SAT_TINH_TRANG_TS_DT(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intMS_TS_GSTT As String, ByVal strMS_BO_PHAN As String, ByVal intSTT_GT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG_TS_DT", intSTT, strMS_MAY, intMS_TS_GSTT, strMS_BO_PHAN, intSTT_GT)
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
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIAM_SAT_TINH_TRANG_TS_DL", intSTT, strMS_MAY, intMS_TS_GSTT, strMS_BO_PHAN, intMSTT)
        End Sub
#End Region
    End Class

End Namespace
