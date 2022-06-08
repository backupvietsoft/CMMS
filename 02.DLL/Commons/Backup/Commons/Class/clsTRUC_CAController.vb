Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class clsTRUC_CAController

        Public Sub New()
        End Sub
        'AddTRUC_CA
        Public Function AddTRUC_CA(ByVal objCaTruc As clsTRUC_CAInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTRUC_CA", _
                objCaTruc.MS_CONG_NHAN, objCaTruc.NGAY, objCaTruc.STT_CA, objCaTruc.TU_GIO, objCaTruc.DEN_GIO, objCaTruc.MS_LOAI_MAY)
            Return True
        End Function

        Public Function AddTRUC_CA_CHI_TIET(ByVal objCaTruc As clsTRUC_CAInfo) As Integer
            Return SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTRUC_CA_CHI_TIET", _
                objCaTruc.NGAY, objCaTruc.STT_CA, objCaTruc.MS_LOAI_MAY, objCaTruc.MS_MAY, objCaTruc.TINH_TRANG, objCaTruc.THOI_GIAN_XAY_RA, objCaTruc.DEN_GIO_CT, objCaTruc.GIAI_PHAP, objCaTruc.GHI_CHU, objCaTruc.MS_TRANG_THAI, objCaTruc.CHI_SO_DONG_HO)
        End Function
        Public Function AddTRUC_CA_CONG_NHAN(ByVal objCaTruc As clsTRUC_CAInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTRUC_CA_CONG_NHAN", _
                objCaTruc.STT_CA, objCaTruc.MS_LOAI_MAY, objCaTruc.MS_MAY, objCaTruc.NGAY, objCaTruc.STT, objCaTruc.CN_GIAI_QUYET)
            Return True
        End Function

        Public Function UpdateTRUC_CA(ByVal objCaTruc As clsTRUC_CAInfo) As Integer
            Return SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTRUC_CA", _
                objCaTruc.MS_CONG_NHAN, objCaTruc.MS_LOAI_MAY, objCaTruc.NGAY, objCaTruc.NGAY_TMP, objCaTruc.STT_CA, objCaTruc.STT_CA_TMP, objCaTruc.TU_GIO, objCaTruc.DEN_GIO)
        End Function
        Public Function UpdateTRUC_CA_CHI_TIET(ByVal objCaTruc As clsTRUC_CAInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTRUC_CA_CHI_TIET", _
                objCaTruc.STT, objCaTruc.MS_MAY, objCaTruc.TINH_TRANG, objCaTruc.THOI_GIAN_XAY_RA, objCaTruc.DEN_GIO_CT, objCaTruc.GIAI_PHAP, objCaTruc.GIAI_PHAP, objCaTruc.MS_TRANG_THAI, objCaTruc.CHI_SO_DONG_HO)
            Return True
        End Function

        Public Function DeleteTRUC_CA(ByVal objCaTruc As clsTRUC_CAInfo) As Integer
            Return SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTRUC_CA", _
                objCaTruc.NGAY, objCaTruc.STT_CA, objCaTruc.MS_LOAI_MAY)
        End Function
        Public Function DeleteTRUC_CA_CONG_NHAN(ByVal objCaTruc As clsTRUC_CAInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTRUC_CA_CONG_NHAN", _
                 objCaTruc.NGAY, objCaTruc.STT_CA, objCaTruc.MS_LOAI_MAY, objCaTruc.MS_MAY, objCaTruc.STT, objCaTruc.CN_GIAI_QUYET)
            Return True
        End Function
        Public Function GetTRUC_CA_CONG_NHAN(ByVal STT_CA As Integer, ByVal MS_LOAI_MAY As String, ByVal MS_MAY As String, ByVal NGAY As String, ByVal STT As Integer) As DataTable
            Return SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetTRUC_CA_CONG_NHAN", STT_CA, MS_LOAI_MAY, MS_MAY, NGAY, STT).Tables(0)
        End Function

        Public Function GetTRUC_CA_CHI_TIET(ByVal NGAY As String, ByVal STT_CA As Integer, ByVal MS_MAY As String) As DataTable
            Return SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetTRUC_CA_CHI_TIET", NGAY, STT_CA, MS_MAY).Tables(0)
        End Function
    End Class
End Namespace
