Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class clsLUONG_CO_BANController

        Public Sub New()
        End Sub

        Public Function GetLUONG_CO_BANs(ByVal MS_CN As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLUONG_CO_BANs", MS_CN))
            Return objDataTable
        End Function

        Public Sub AddLUONG_CO_BAN(ByVal objLUONG_CO_BANInfo As LUONG_CO_BANInfo, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddLUONG_CO_BAN", _
            objLUONG_CO_BANInfo.MS_CONG_NHAN, objLUONG_CO_BANInfo.SO_QUYET_DINH, objLUONG_CO_BANInfo.NGAY_KY, _
            objLUONG_CO_BANInfo.NGUOI_KY, objLUONG_CO_BANInfo.NGAY_HIEU_LUC, objLUONG_CO_BANInfo.LUONG_CO_BAN, _
            objLUONG_CO_BANInfo.NGOAI_TE, objLUONG_CO_BANInfo.HIEU_SUAT)

            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_LUONG_CO_BAN_LOG", objLUONG_CO_BANInfo.MS_CONG_NHAN, objLUONG_CO_BANInfo.SO_QUYET_DINH, form_name, Commons.Modules.UserName, 1)

        End Sub

        Public Sub UpdateLUONG_CO_BAN(ByVal objLUONG_CO_BANInfo As LUONG_CO_BANInfo, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_LUONG_CO_BAN_LOG", objLUONG_CO_BANInfo.MS_CONG_NHAN, objLUONG_CO_BANInfo.SO_QUYET_DINH, form_name, Commons.Modules.UserName, 2)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLUONG_CO_BAN", _
            objLUONG_CO_BANInfo.MS_CONG_NHAN, objLUONG_CO_BANInfo.SO_QUYET_DINH, objLUONG_CO_BANInfo.NGAY_KY, _
            objLUONG_CO_BANInfo.NGUOI_KY, objLUONG_CO_BANInfo.NGAY_HIEU_LUC, objLUONG_CO_BANInfo.LUONG_CO_BAN, _
            objLUONG_CO_BANInfo.NGOAI_TE, objLUONG_CO_BANInfo.HIEU_SUAT, objLUONG_CO_BANInfo.SO_QD_Tmp)
        End Sub

        Public Sub DeleteLUONG_CO_BAN(ByVal MS_CN As String, ByVal SO_QD As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteLUONG_CO_BAN", MS_CN, SO_QD)
        End Sub
    End Class
End Namespace