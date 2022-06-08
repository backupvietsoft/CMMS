Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class clsCHUC_VUController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetCHUC_VUs(ByVal MS_CONG_NHAN As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHUC_VUs", MS_CONG_NHAN))
            Return objDataTable
        End Function

        Public Function GetCHUC_VU(ByVal ID As Integer) As CHUC_VUInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHUC_VU", ID)
            Dim objCHUC_VUInfo As New CHUC_VUInfo
            While objDataReader.Read
                objCHUC_VUInfo.MS_CONG_NHAN = objDataReader.Item("MS_CONG_NHAN")
                objCHUC_VUInfo.NGAY = objDataReader.Item("NGAY")
                objCHUC_VUInfo.TEN_CHUC_VU = objDataReader.Item("TEN_CHUC_VU")
            End While
            objDataReader.Close()
            Return objCHUC_VUInfo
        End Function

        Public Sub AddCHUC_VU(ByVal objCHUC_VUInfo As CHUC_VUInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddCHUC_VU", _
            objCHUC_VUInfo.MS_CONG_NHAN, objCHUC_VUInfo.NGAY, objCHUC_VUInfo.TEN_CHUC_VU)
        End Sub

        Public Sub UpdateCHUC_VU(ByVal objCHUC_VUInfo As CHUC_VUInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCHUC_VU", _
            objCHUC_VUInfo.MS_CONG_NHAN, objCHUC_VUInfo.NGAY, objCHUC_VUInfo.TEN_CHUC_VU, objCHUC_VUInfo.NGAY_Tmp)
        End Sub

        Public Sub DeleteCHUC_VU(ByVal MS_CONG_NHAN As String, ByVal NGAY As Date)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCHUC_VU", MS_CONG_NHAN, NGAY)
        End Sub
        ' Xóa toàn bộ chức vụ của nhân viên.
        Public Sub DeleteCHUC_VU_CN(ByVal MS_CONG_NHAN As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCHUC_VU_CN", MS_CONG_NHAN)
        End Sub
#End Region

    End Class
End Namespace