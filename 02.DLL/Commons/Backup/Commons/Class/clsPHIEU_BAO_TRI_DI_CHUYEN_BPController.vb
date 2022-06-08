Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class PHIEU_BAO_TRI_DI_CHUYEN_BPController
        Public Sub New()
        End Sub

#Region "Methods"
        Function Get_PHIEU_BAO_TRI_DI_CHUYEN_BP_CT(ByVal LOAI_TB As String) As DataTable
            Dim dtTable As New DataTable
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_PHIEU_BAO_TRI_DI_CHUYEN_BP_CT", LOAI_TB))
            Return dtTable
        End Function

        Function Get_PHIEU_BAO_TRI_DI_CHUYEN_BP_DT(ByVal LOAI_TB As String) As DataTable
            Dim dtTable As New DataTable
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_PHIEU_BAO_TRI_DI_CHUYEN_BP_DT", LOAI_TB))
            Return dtTable
        End Function

        Sub Update_PHIEU_BAO_TRI_DI_CHUYEN_BP(ByVal obj_PBTDCBP As PHIEU_BAO_TRI_DI_CHUYEN_BPInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_PHIEU_BAO_TRI_DI_CHUYEN_BP", _
           obj_PBTDCBP.MS_PHIEU_BAO_TRI, obj_PBTDCBP.MS_BO_PHAN, obj_PBTDCBP.MS_MAY_THAY_THE, obj_PBTDCBP.MS_BO_PHAN_THAY_THE, _
            obj_PBTDCBP.NGAY_TRA_TT)
        End Sub

        Sub delete_PHIEU_BAO_TRI_DI_CHUYEN_BP(ByVal objInfo As PHIEU_BAO_TRI_DI_CHUYEN_BPInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "delete_PHIEU_BAO_TRI_DI_CHUYEN_BP", _
            objInfo.MS_PHIEU_BAO_TRI, objInfo.MS_MAY_THAY_THE, objInfo.MS_BO_PHAN_THAY_THE)
        End Sub
#End Region
    End Class
End Namespace

