Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class clsCONG_NHANController

        Public Sub New()
        End Sub

#Region "Public Method"
        'Public Function GetCONG_NHANs() As DataTable
        '    Dim objDataTable As DataTable = New DataTable
        '    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHANs"))
        '    Return objDataTable
        'End Function
        Public Function GetLocAllCONG_NHANs(ByVal MS_TO As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLocAllCONG_NHANs", MS_TO))
            Return objDataTable
        End Function

        Public Function GetLocLVCONG_NHANs(ByVal MS_TO As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLocLVCONG_NHANs", MS_TO))
            Return objDataTable
        End Function

        Public Function GetLocBVCONG_NHANs(ByVal MS_TO As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLocBVCONG_NHANs", MS_TO))
            Return objDataTable
        End Function

        Public Function GetLocAllCONG_NHAN_AllTos(ByVal MS_DON_VI As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLocAllCONG_NHAN_AllTos", MS_DON_VI))
            Return objDataTable
        End Function

        Public Function GetLocLVCONG_NHAN_AllTos(ByVal MS_DON_VI As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLocLVCONG_NHAN_AllTos", MS_DON_VI))
            Return objDataTable
        End Function

        Public Function GetLocBVCONG_NHAN_AllTos(ByVal MS_DON_VI As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLocBVCONG_NHAN_AllTos", MS_DON_VI))
            Return objDataTable
        End Function

        'Public Function GetLastCHUC_VU(ByVal MS_CONG_NHAN As String) As DataTable
        '    Dim objDataTable As DataTable = New DataTable
        '    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLastCHUC_VU", MS_CONG_NHAN))
        '    Return objDataTable
        'End Function

        Public Function GetLastCHUC_VU(ByVal MS_CONG_NHAN As String) As CONG_NHANInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLastCHUC_VU", MS_CONG_NHAN)
            Dim objCONG_NHANInfo As New CONG_NHANInfo
            While objDataReader.Read
                objCONG_NHANInfo.CHUC_VU = objDataReader.Item("TEN_CHUC_VU")
            End While
            objDataReader.Close()
            Return objCONG_NHANInfo
        End Function

        Public Function GetDonviTo_of_CN(ByVal MS_CONG_NHAN As String) As CONG_NHANInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonviTo_of_CN", MS_CONG_NHAN)
            Dim objCONG_NHANInfo As New CONG_NHANInfo
            While objDataReader.Read
                objCONG_NHANInfo.MS_TO = objDataReader.Item("MS_TO")
                objCONG_NHANInfo.MS_DON_VI = objDataReader.Item("MS_DON_VI")
            End While
            objDataReader.Close()
            Return objCONG_NHANInfo
        End Function

        Public Function GetcboCONG_NHANs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetcboCONG_NHANs"))
            Return objDataTable
        End Function

        Public Function GetCONG_NHAN(ByVal ID As Integer) As CONG_NHANInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN", ID)
            Dim objCONG_NHANInfo As New CONG_NHANInfo
            While objDataReader.Read
                objCONG_NHANInfo.MS_CONG_NHAN = objDataReader.Item("MS_CONG_NHAN")
                objCONG_NHANInfo.HO = objDataReader.Item("HO")
                objCONG_NHANInfo.TEN = objDataReader.Item("TEN")
                objCONG_NHANInfo.NGAY_SINH = objDataReader.Item("NGAY_SINH")
                objCONG_NHANInfo.NOI_SINH = objDataReader.Item("NOI_SINH")
                objCONG_NHANInfo.PHAI = objDataReader.Item("PHAI")
                objCONG_NHANInfo.DIA_CHI_THUONG_TRU = objDataReader.Item("DIA_CHI_THUONG_TRU")
                objCONG_NHANInfo.SO_CMND = objDataReader.Item("SO_CMND")
                objCONG_NHANInfo.NGAY_CAP = objDataReader.Item("NGAY_CAP")
                objCONG_NHANInfo.NOI_CAP = objDataReader.Item("NOI_CAP")
                objCONG_NHANInfo.MS_TO = objDataReader.Item("MS_TO")
                objCONG_NHANInfo.NGAY_VAO_LAM = objDataReader.Item("NGAY_VAO_LAM")
                objCONG_NHANInfo.BO_VIEC = objDataReader.Item("BO_VIEC")
                objCONG_NHANInfo.NGAY_NGHI_VIEC = objDataReader.Item("NGAY_NGHI_VIEC")
                objCONG_NHANInfo.LY_DO_NGHI = objDataReader.Item("LY_DO_NGHI")
                objCONG_NHANInfo.MS_TRINH_DO = objDataReader.Item("MS_TRINH_DO")
                objCONG_NHANInfo.NGOAI_NGU = objDataReader.Item("NGOAI_NGU")
                objCONG_NHANInfo.Hinh_CN = objDataReader.Item("Hinh_CN")
                objCONG_NHANInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
                objCONG_NHANInfo.MS_THE_CC = objDataReader.Item("MS_THE_CC")
                objCONG_NHANInfo.SO_DT_NHA_RIENG = objDataReader.Item("SO_DT_NHA_RIENG")
                objCONG_NHANInfo.SO_DTDD = objDataReader.Item("SO_DTDD")
                objCONG_NHANInfo.TEN_NGUOI_THAN = objDataReader.Item("TEN_NGUOI_THAN")
                objCONG_NHANInfo.QUAN_HE = objDataReader.Item("QUAN_HE")
                objCONG_NHANInfo.USER_MAIL = objDataReader.Item("USER_MAIL")
            End While
            Return objCONG_NHANInfo
        End Function

        Public Function AddCONG_NHAN(ByVal objCONG_NHANInfo As CONG_NHANInfo, ByVal FORM_NAME As String) As Integer
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddCONG_NHAN", _
            objCONG_NHANInfo.MS_CONG_NHAN, objCONG_NHANInfo.HO, objCONG_NHANInfo.TEN, _
            objCONG_NHANInfo.NGAY_SINH, objCONG_NHANInfo.NOI_SINH, objCONG_NHANInfo.PHAI, _
            objCONG_NHANInfo.DIA_CHI_THUONG_TRU, objCONG_NHANInfo.SO_CMND, objCONG_NHANInfo.NGAY_CAP, _
            objCONG_NHANInfo.NOI_CAP, objCONG_NHANInfo.MS_TO, objCONG_NHANInfo.NGAY_VAO_LAM, _
            objCONG_NHANInfo.BO_VIEC, objCONG_NHANInfo.NGAY_NGHI_VIEC, objCONG_NHANInfo.LY_DO_NGHI, _
            objCONG_NHANInfo.MS_TRINH_DO, objCONG_NHANInfo.NGOAI_NGU, objCONG_NHANInfo.Hinh_CN, _
            objCONG_NHANInfo.GHI_CHU, objCONG_NHANInfo.MS_THE_CC, objCONG_NHANInfo.SO_DT_NHA_RIENG, _
            objCONG_NHANInfo.SO_DTDD, objCONG_NHANInfo.TEN_NGUOI_THAN, objCONG_NHANInfo.QUAN_HE, _
            objCONG_NHANInfo.BANG_CAP, objCONG_NHANInfo.USER_MAIL)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_LOG", objCONG_NHANInfo.MS_CONG_NHAN, FORM_NAME, Commons.Modules.UserName, 1)
        End Function

        Public Sub UpdateCONG_NHAN(ByVal objCONG_NHANInfo As CONG_NHANInfo, ByVal FORM_NAME As String)

            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_LOG", objCONG_NHANInfo.MS_CONG_NHAN, FORM_NAME, Commons.Modules.UserName, 2)

            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCONG_NHAN", _
            objCONG_NHANInfo.MS_CONG_NHAN, objCONG_NHANInfo.HO, objCONG_NHANInfo.TEN, _
            objCONG_NHANInfo.NGAY_SINH, objCONG_NHANInfo.NOI_SINH, objCONG_NHANInfo.PHAI, _
            objCONG_NHANInfo.DIA_CHI_THUONG_TRU, objCONG_NHANInfo.SO_CMND, objCONG_NHANInfo.NGAY_CAP, _
            objCONG_NHANInfo.NOI_CAP, objCONG_NHANInfo.MS_TO, objCONG_NHANInfo.NGAY_VAO_LAM, _
            objCONG_NHANInfo.BO_VIEC, objCONG_NHANInfo.NGAY_NGHI_VIEC, objCONG_NHANInfo.LY_DO_NGHI, _
            objCONG_NHANInfo.MS_TRINH_DO, objCONG_NHANInfo.NGOAI_NGU, objCONG_NHANInfo.Hinh_CN, _
            objCONG_NHANInfo.GHI_CHU, objCONG_NHANInfo.MS_THE_CC, objCONG_NHANInfo.SO_DT_NHA_RIENG, _
            objCONG_NHANInfo.SO_DTDD, objCONG_NHANInfo.TEN_NGUOI_THAN, objCONG_NHANInfo.QUAN_HE, _
            objCONG_NHANInfo.BANG_CAP, objCONG_NHANInfo.MS_CN_Temp, objCONG_NHANInfo.USER_MAIL)
        End Sub

        Public Sub UpdateHinhCONG_NHAN(ByVal MS_CONG_NHAN As String, ByVal Hinh_CN As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateHinhCONG_NHAN", MS_CONG_NHAN, Hinh_CN)
        End Sub

        Public Sub DeleteCONG_NHAN(ByVal MS_CONG_NHAN As String, ByVal FORM_NAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_LOG", MS_CONG_NHAN, FORM_NAME, Commons.Modules.UserName, 3)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCONG_NHAN", MS_CONG_NHAN)
        End Sub
#End Region

    End Class
End Namespace