Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class clsTAI_NAN_LDController

        Public Sub New()
        End Sub

        Public Function GetTAI_NAN_LDs(ByVal MS_CN As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTAI_NAN_LDs", MS_CN))
            Return objDataTable
        End Function

        Public Sub AddTAI_NAN_LD(ByVal objTAI_NAN_LDInfo As TAI_NAN_LDInfo, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTAI_NAN_LD", _
            objTAI_NAN_LDInfo.MS_CONG_NHAN, objTAI_NAN_LDInfo.NGAY_TAI_NAN, objTAI_NAN_LDInfo.GIO, _
            objTAI_NAN_LDInfo.NOI_XAY_RA, objTAI_NAN_LDInfo.TINH_TRANG, objTAI_NAN_LDInfo.NGUYEN_NHAN, _
            objTAI_NAN_LDInfo.GIAI_QUYET)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_TAI_NAN_LD_LOG", objTAI_NAN_LDInfo.MS_CONG_NHAN, objTAI_NAN_LDInfo.NGAY_TAI_NAN, FORM_NAME, Commons.Modules.UserName, 1)
        End Sub

        Public Sub UpdateTAI_NAN_LD(ByVal objTAI_NAN_LDInfo As TAI_NAN_LDInfo, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_TAI_NAN_LD_LOG", objTAI_NAN_LDInfo.MS_CONG_NHAN, objTAI_NAN_LDInfo.NGAY_TAI_NAN, FORM_NAME, Commons.Modules.UserName, 2)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTAI_NAN_LD", _
            objTAI_NAN_LDInfo.MS_CONG_NHAN, objTAI_NAN_LDInfo.NGAY_TAI_NAN, objTAI_NAN_LDInfo.GIO, _
            objTAI_NAN_LDInfo.NOI_XAY_RA, objTAI_NAN_LDInfo.TINH_TRANG, objTAI_NAN_LDInfo.NGUYEN_NHAN, _
            objTAI_NAN_LDInfo.GIAI_QUYET, objTAI_NAN_LDInfo.NGAY_TN_TMP)
        End Sub

        Public Sub DeleteTAI_NAN_LD(ByVal MS_CN As String, ByVal NGAY_TN As DateTime, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_TAI_NAN_LD_LOG", MS_CN, NGAY_TN, form_name, Commons.Modules.UserName, 3)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTAI_NAN_LD", MS_CN, NGAY_TN)
        End Sub

        '' vai tro
        Public Function GetVAI_TROs(ByVal MS_CN As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetVAI_TROs", MS_CN))
            Return objDataTable
        End Function

    End Class
End Namespace