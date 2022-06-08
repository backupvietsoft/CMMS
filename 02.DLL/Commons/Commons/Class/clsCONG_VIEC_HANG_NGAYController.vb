Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsCONG_VIEC_HANG_NGAYController

        Public Sub New()
        End Sub
        Public Function AddCONG_VIEC_HANG_NGAY(ByVal NGAY As String, ByVal GHI_CHU As String, ByVal USERNAME As String, ByVal objTran As SqlTransaction) As Integer
            Return SqlHelper.ExecuteScalar(objTran, "AddCONG_VIEC_HANG_NGAY", NGAY, GHI_CHU, USERNAME)
        End Function
        Public Sub InsertCONG_VIEC_HANG_NGAY(ByVal ID As Integer, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer, ByVal objTran As SqlTransaction)
            SqlHelper.ExecuteScalar(objTran, "UPDATE_CONG_VIEC_HANG_NGAY_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub
        Public Sub UpdateCONG_VIEC_HANG_NGAY(ByVal STT_CV As Integer, ByVal GHI_CHU As String, ByVal objTran As SqlTransaction)
            SqlHelper.ExecuteScalar(objTran, "UpdateCONG_VIEC_HANG_NGAY", STT_CV, GHI_CHU)
        End Sub
        Public Sub DeleteCONG_VIEC_HANG_NGAY_CT(ByVal STT_CV As Integer, ByVal objTran As SqlTransaction)
            SqlHelper.ExecuteScalar(objTran, "DeleteCONG_VIEC_HANG_NGAY_CT", STT_CV)
        End Sub
        Public Sub AddCONG_VIEC_HANG_NGAY_NV(ByVal objCONG_VIEC_HANG_NGAY_NV As clsCONG_VIEC_HANG_NGAYInfo, ByVal objTran As SqlTransaction, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(objTran, "AddCONG_VIEC_HANG_NGAY_NV", objCONG_VIEC_HANG_NGAY_NV.STT_CV, objCONG_VIEC_HANG_NGAY_NV.MS_CONG_NHAN, _
            objCONG_VIEC_HANG_NGAY_NV.SO_GIO, objCONG_VIEC_HANG_NGAY_NV.LUONG, objCONG_VIEC_HANG_NGAY_NV.THANH_TIEN)
            SqlHelper.ExecuteScalar(objTran, "UPDATE_CONG_VIEC_HANG_NGAY_NV_LOG", objCONG_VIEC_HANG_NGAY_NV.STT_CV, objCONG_VIEC_HANG_NGAY_NV.MS_CONG_NHAN, _
         FORM_NAME, Commons.Modules.UserName, 1)
        End Sub
        Public Sub AddCONG_VIEC_HANG_NGAY_VT(ByVal objCONG_VIEC_HANG_NGAY_VT As clsCONG_VIEC_HANG_NGAY_VTInfo, ByVal objTran As SqlTransaction, ByVal FORM_NAME As String)
            'SqlHelper.ExecuteScalar(objTran, "AddCONG_VIEC_HANG_NGAY_VT", objCONG_VIEC_HANG_NGAY_VT.STT_CV, objCONG_VIEC_HANG_NGAY_VT.MS_PT, _
            'objCONG_VIEC_HANG_NGAY_VT.SO_LUONG, objCONG_VIEC_HANG_NGAY_VT.DON_GIA, objCONG_VIEC_HANG_NGAY_VT.THANH_TIEN)

            SqlHelper.ExecuteScalar(objTran, "H_CONG_VIEC_HANG_NGAY_INSERT_VT", objCONG_VIEC_HANG_NGAY_VT.STT_CV, objCONG_VIEC_HANG_NGAY_VT.MS_PT, _
            objCONG_VIEC_HANG_NGAY_VT.MS_DH_XUAT, objCONG_VIEC_HANG_NGAY_VT.MS_DH_NHAP, objCONG_VIEC_HANG_NGAY_VT.SO_LUONG, objCONG_VIEC_HANG_NGAY_VT.ID)
            'UPDATE_CONG_VIEC_HANG_NGAY_VT_LOG
            SqlHelper.ExecuteScalar(objTran, "UPDATE_CONG_VIEC_HANG_NGAY_VT_LOG", objCONG_VIEC_HANG_NGAY_VT.STT_CV, objCONG_VIEC_HANG_NGAY_VT.MS_PT, _
            FORM_NAME, Commons.Modules.UserName, 1)
        End Sub
        Public Sub AddCONG_VIEC_HANG_NGAY_THIET_BI(ByVal objCONG_VIEC_HANG_NGAY_TB As clsCONG_VIEC_HANG_NGAY_TBInfo, ByVal objTran As SqlTransaction, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(objTran, "AddCONG_VIEC_HANG_NGAY_THIET_BI", objCONG_VIEC_HANG_NGAY_TB.STT_CV, objCONG_VIEC_HANG_NGAY_TB.MS_MAY, _
            objCONG_VIEC_HANG_NGAY_TB.NOI_DUNG, objCONG_VIEC_HANG_NGAY_TB.CHI_PHI_NC, objCONG_VIEC_HANG_NGAY_TB.CHI_PHI_VT)

            SqlHelper.ExecuteScalar(objTran, "UPDATE_CONG_VIEC_HANG_NGAY_THIET_BI_LOG", objCONG_VIEC_HANG_NGAY_TB.STT_CV, objCONG_VIEC_HANG_NGAY_TB.MS_MAY, _
         FORM_NAME, Commons.Modules.UserName, 1)
        End Sub

        Public Sub DeleteCONG_VIEC_HANG_NGAY(ByVal STT_CV As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCONG_VIEC_HANG_NGAY", STT_CV)
        End Sub
       
    End Class
End Namespace
