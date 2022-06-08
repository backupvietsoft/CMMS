Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class CHU_KY_HIEU_CHUANController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetCHU_KY_HIEU_CHUAN(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetCHU_KY_HIEU_CHUAN", MS_MAY))
            Return objDataTable
        End Function

        Public Function AddCHU_KY_HIEU_CHUAN(ByVal Sqltran As SqlTransaction, ByVal objChuKyHCInfo As CHU_KY_HIEU_CHUANInfo) As Boolean
            SqlHelper.ExecuteScalar(Sqltran, "AddCHU_KY_HIEU_CHUAN", _
                objChuKyHCInfo.MS_MAY, objChuKyHCInfo.MS_PT, objChuKyHCInfo.MS_VI_TRI, objChuKyHCInfo.TEN_VI_TRI, _
                objChuKyHCInfo.CHU_KY_HC_NOI, objChuKyHCInfo.CHU_KY_HC_NGOAI, _
                objChuKyHCInfo.MS_DV_TG, objChuKyHCInfo.GHI_CHU, objChuKyHCInfo.CHU_KY_KD, objChuKyHCInfo.CHU_KY_KT)
            Return True
        End Function

        Public Function UpdateCHU_KY_HIEU_CHUAN(ByVal objChuKyHCInfo As CHU_KY_HIEU_CHUANInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCHU_KY_HIEU_CHUAN", _
                objChuKyHCInfo.MS_MAY, objChuKyHCInfo.MS_PT, objChuKyHCInfo.MS_VI_TRI, objChuKyHCInfo.CHU_KY_HC_NOI, objChuKyHCInfo.CHU_KY_HC_NGOAI, objChuKyHCInfo.MS_DV_TG, objChuKyHCInfo.GHI_CHU)
            Return True
        End Function

        Public Sub DeleteCHU_KY_HIEU_CHUAN(ByVal MS_MAY As String, ByVal MS_PT As String, ByVal MS_VTri As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCHU_KY_HIEU_CHUAN", MS_MAY, MS_PT, MS_VTri)
        End Sub
#End Region
    End Class

End Namespace
