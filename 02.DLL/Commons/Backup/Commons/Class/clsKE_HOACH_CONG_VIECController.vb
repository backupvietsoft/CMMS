Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class KE_HOACH_THUC_HIENController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetKE_HOACH_THUC_HIEN_CHUA_HT(ByVal MS_CN As String, ByVal DEN_NGAY As Date) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKE_HOACH_THUC_HIEN_CHUA_HT", MS_CN, DEN_NGAY))
            Return objDataTable
        End Function

        Public Function GetKE_HOACH_THUC_HIEN_DA_HT(ByVal MS_CN As String, ByVal TU_NGAY As Date, ByVal DEN_NGAY As Date) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKE_HOACH_THUC_HIEN_DA_HT", MS_CN, TU_NGAY, DEN_NGAY))
            Return objDataTable
        End Function

        Public Sub AddKE_HOACH_THUC_HIEN(ByVal objKH_THInfo As KE_HOACH_THUC_HIENInfo, ByVal FORM_NAME As String)
            Dim STT As Integer
            Try

                STT = CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddKE_HOACH_THUC_HIEN", _
                                objKH_THInfo.MS_CONG_NHAN, objKH_THInfo.NGAY, objKH_THInfo.TEN_CONG_VIEC, _
                                objKH_THInfo.GHI_CHU, objKH_THInfo.MS_UU_TIEN, objKH_THInfo.USER_LAST, objKH_THInfo.THOI_HAN, _
                                objKH_THInfo.THOI_GIAN_DK, objKH_THInfo.DA_XONG, objKH_THInfo.TU_GIO, objKH_THInfo.DEN_GIO), Integer)
            Catch ex As Exception

            End Try

            Try
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKE_HOACH_THUC_HIEN_LOG", objKH_THInfo.MS_CONG_NHAN, objKH_THInfo.NGAY, STT, FORM_NAME, Commons.Modules.UserName, 1)
            Catch ex As Exception

            End Try

        End Sub

        Public Sub UpdateKE_HOACH_THUC_HIEN(ByVal objKH_THInfo As KE_HOACH_THUC_HIENInfo, ByVal FORM_NAME As String)
            'UpdateKE_HOACH_THUC_HIEN_LOG
            Try
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKE_HOACH_THUC_HIEN_LOG", objKH_THInfo.MS_CONG_NHAN, objKH_THInfo.NGAY, objKH_THInfo.STT, FORM_NAME, Commons.Modules.UserName, 2)
            Catch ex As Exception

            End Try

            Try

                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKE_HOACH_THUC_HIEN", _
                                        objKH_THInfo.MS_CONG_NHAN, objKH_THInfo.NGAY, objKH_THInfo.STT, objKH_THInfo.TEN_CONG_VIEC, _
                                        objKH_THInfo.GHI_CHU, objKH_THInfo.MS_UU_TIEN, objKH_THInfo.USER_LAST, objKH_THInfo.PREVIOUS_USER, _
                                        objKH_THInfo.THOI_GIAN_SUA, objKH_THInfo.THOI_HAN, objKH_THInfo.THOI_GIAN_DK, objKH_THInfo.DA_XONG, _
                                        objKH_THInfo.NGAY_tmp, objKH_THInfo.TU_GIO, objKH_THInfo.DEN_GIO)
            Catch ex As Exception

            End Try

        End Sub

        Public Sub DeleteKE_HOACH_THUC_HIEN(ByVal MS_CN As String, ByVal NGAY As Date, ByVal STT As Integer, ByVal FORM_NAME As String)
            Try
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKE_HOACH_THUC_HIEN_LOG", MS_CN, NGAY, STT, FORM_NAME, Commons.Modules.UserName, 3)
            Catch ex As Exception

            End Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKE_HOACH_THUC_HIEN", MS_CN, NGAY, STT)
        End Sub

        Public Function Get_MUC_UT() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_View_Mucuutien"))
            Return objDataTable
        End Function
        Public Sub InsertKE_HOACH_THUC_HIEN(ByVal MS_CN As String, ByVal NGAY As String, ByVal DEN_NGAY As String, ByVal HOAN_THANH As Boolean)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertKE_HOACH_THUC_HIEN", MS_CN, NGAY, DEN_NGAY, HOAN_THANH)
        End Sub
#End Region
    End Class
End Namespace
