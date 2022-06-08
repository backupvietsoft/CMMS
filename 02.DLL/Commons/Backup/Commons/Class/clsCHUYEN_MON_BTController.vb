Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsCHUYEN_MON_BTController

        Public Sub New()
        End Sub

#Region "Public Method"
        ' Các hàm xử lý bảng CONG_NHAN_CHUYEN_MON
        Public Function GetCONG_NHAN_CMs(ByVal MS_CN As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN_CMs", MS_CN))
            Return objDataTable
        End Function

        Public Sub AddCONG_NHAN_CM(ByVal MS_CONG_NHAN As String, ByVal MS_CHUYEN_MON As Integer, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddCONG_NHAN_CM", MS_CONG_NHAN, MS_CHUYEN_MON)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_CHUYEN_MON_LOG", MS_CONG_NHAN, MS_CHUYEN_MON, FORM_NAME, Commons.Modules.UserName, 1)
        End Sub

        Public Sub UpdateCONG_NHAN_CM(ByVal MS_CONG_NHAN As String, ByVal MS_CHUYEN_MON As Integer, ByVal MS_CHUYEN_MON_Tmp As Integer, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_CHUYEN_MON_LOG", MS_CONG_NHAN, MS_CHUYEN_MON_Tmp, form_name, Commons.Modules.UserName, 2)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCONG_NHAN_CM", MS_CONG_NHAN, MS_CHUYEN_MON, MS_CHUYEN_MON_Tmp)
        End Sub

        Public Sub DeleteCONG_NHAN_CM(ByVal MS_CN As String, ByVal MS_CM As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCONG_NHAN_CM", MS_CN, MS_CM)
        End Sub

        ' Các hàm xử lý bảng CONG_NHAN_CHUYEN_MON_BAC_THO
        Public Function GetCONG_NHAN_CM_BTs(ByVal MS_CN As String, ByVal MS_CM As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN_CM_BTs", MS_CN, MS_CM))
            Return objDataTable
        End Function

        Public Sub AddCONG_NHAN_CM_BT(ByVal MS_CONG_NHAN As String, ByVal MS_CHUYEN_MON As Integer, _
                    ByVal NGAY As DateTime, ByVal MS_BAC_THO As Integer, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddCONG_NHAN_CM_BT", _
                MS_CONG_NHAN, MS_CHUYEN_MON, NGAY, MS_BAC_THO)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_CHUYEN_MON_BAC_THO_LOG", MS_CONG_NHAN, MS_CHUYEN_MON, MS_BAC_THO, FORM_NAME, Commons.Modules.UserName, 1)
        End Sub

        Public Sub UpdateCONG_NHAN_CM_BT(ByVal MS_CONG_NHAN As String, ByVal MS_CHUYEN_MON As Integer, _
                    ByVal NGAY As DateTime, ByVal MS_BAC_THO As Integer, ByVal MS_BT_Tmp As Integer, ByVal FORM_NAME As String)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_CHUYEN_MON_BAC_THO_LOG", MS_CONG_NHAN, MS_CHUYEN_MON, MS_BAC_THO, FORM_NAME, Commons.Modules.UserName, 2)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCONG_NHAN_CM_BT", _
                MS_CONG_NHAN, MS_CHUYEN_MON, NGAY, MS_BAC_THO, MS_BT_Tmp)
        End Sub

        Public Sub DeleteCONG_NHAN_CM_BT(ByVal MS_CN As String, ByVal MS_CM As Integer, ByVal MS_BT As Integer, ByVal FORM_NAME As String)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_CHUYEN_MON_BAC_THO_LOG", MS_CN, MS_CM, MS_BT, FORM_NAME, Commons.Modules.UserName, 3)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCONG_NHAN_CM_BT", MS_CN, MS_CM, MS_BT)
        End Sub
#End Region
    End Class
End Namespace