Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class MAY_LOAI_BTPNController
        Public Sub New()

        End Sub

#Region "public method BTPN"
        Public Function GetMAY_LOAI_BTPN(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetMAY_LOAI_BTPN", MS_MAY))
            Return objDataTable
        End Function
        Public Function AddMAY_LOAI_BTPN(ByVal objMAY_LOAI_BTPNInfo As MAY_LOAI_BTPN) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddMAY_LOAI_BTPN", _
                objMAY_LOAI_BTPNInfo.MS_MAY, objMAY_LOAI_BTPNInfo.MS_LOAI_BT, objMAY_LOAI_BTPNInfo.NGAY_CUOI)
            Return True
        End Function

#End Region
#Region "Public Method Chu Ky"
        Public Function GetMAY_LOAI_BTPN_CHU_KYs(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetMAY_LOAI_BTPN_CHU_KYs", MS_MAY))
            Return objDataTable
        End Function

        Public Function GetDON_VI_TINH_RUN_TIMEs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_TINH_RUN_TIMEs"))
            Return objDataTable
        End Function

        Public Function GetDON_VI_THOI_GIANs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_THOI_GIANs", commons.Modules.TypeLanguage))
            Return objDataTable
        End Function

        Public Function GetMAY_LOAI_BTPN_CHU_KY(ByVal MS_MAY As String, Optional ByVal MS_LOAI_BT As Integer = 0) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOAI_BTPN_CHU_KY", MS_MAY, MS_LOAI_BT))
            Return objDataTable
        End Function

        Public Function AddMAY_LOAI_BTPN_CHU_KY(ByVal Sqltran As SqlTransaction, ByVal objMAY_LOAI_BTPNInfo As MAY_LOAI_BTPNInfo) As String
            SqlHelper.ExecuteScalar(Sqltran, "AddMAY_LOAI_BTPN_CHU_KY", _
                objMAY_LOAI_BTPNInfo.MS_MAY, objMAY_LOAI_BTPNInfo.MS_LOAI_BT, objMAY_LOAI_BTPNInfo.NGAY_AD, objMAY_LOAI_BTPNInfo.CHU_KY, objMAY_LOAI_BTPNInfo.MS_DV_TG, objMAY_LOAI_BTPNInfo.RUN_TIME, objMAY_LOAI_BTPNInfo.MS_DVT_RT, objMAY_LOAI_BTPNInfo.MOVEMENT)
            Return True
        End Function

        Public Sub UpdateMAY_LOAI_BTPN_CHU_KY(ByVal objMAY_LOAI_BTPNInfo As MAY_LOAI_BTPNInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_LOAI_BTPN_CHU_KY", _
                objMAY_LOAI_BTPNInfo.MS_MAY, objMAY_LOAI_BTPNInfo.MS_LOAI_BT, objMAY_LOAI_BTPNInfo.NGAY_AD, objMAY_LOAI_BTPNInfo.CHU_KY, objMAY_LOAI_BTPNInfo.MS_DV_TG, objMAY_LOAI_BTPNInfo.RUN_TIME, objMAY_LOAI_BTPNInfo.MS_DVT_RT)
        End Sub

        Public Sub DeleteMAY_LOAI_BTPN_CHU_KY(ByVal MS_MAY As String, ByVal MS_LOAI_BT As Integer, ByVal NGAY_AD As Date)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteMAY_LOAI_BTPN_CHU_KY", MS_MAY, MS_LOAI_BT, NGAY_AD)
        End Sub

#End Region
    End Class
End Namespace
