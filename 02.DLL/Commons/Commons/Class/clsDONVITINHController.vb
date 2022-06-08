Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class DON_VI_TINHController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetDON_VI_TINHs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_TINHs"))
            Return objDataTable
        End Function

        Public Function GetDON_VI_TINH(ByVal ID As Integer) As DON_VI_TINHInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_TINH", ID)
            Dim objDON_VI_TINHInfo As New DON_VI_TINHInfo
            While objDataReader.Read
                objDON_VI_TINHInfo.DVT = objDataReader.Item("DVT")
                objDON_VI_TINHInfo.TEN_1 = objDataReader.Item("TEN_1")
            End While
            Return objDON_VI_TINHInfo
        End Function

        Public Sub AddDON_VI_TINH(ByVal objDON_VI_TINHInfo As DON_VI_TINHInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddDON_VI_TINH", objDON_VI_TINHInfo.DVT, objDON_VI_TINHInfo.TEN_1, objDON_VI_TINHInfo.TEN_2, objDON_VI_TINHInfo.TEN_3, objDON_VI_TINHInfo.GHI_CHU)
        End Sub
        Public Sub UpdateDON_VI_TINH(ByVal objDON_VI_TINHInfo As DON_VI_TINHInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDON_VI_TINH", objDON_VI_TINHInfo.DVT_TMP, objDON_VI_TINHInfo.DVT, objDON_VI_TINHInfo.TEN_1, objDON_VI_TINHInfo.TEN_2, objDON_VI_TINHInfo.TEN_3, objDON_VI_TINHInfo.GHI_CHU)
        End Sub
        Public Sub InsertDON_VI_TINH(ByVal ID As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDON_VI_TINH_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub
        Public Sub DeleteDON_VI_TINH(ByVal DVT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteDON_VI_TINH", DVT)
        End Sub
        Public Sub UpdateDVT_PHU_TUNG(ByVal OLD_DVT As String, ByVal NEW_DVT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatedDVT_PHU_TUNG", OLD_DVT, NEW_DVT)
        End Sub
        Public Sub UpdateDVT_VAT_TU(ByVal OLD_DVT As String, ByVal NEW_DVT As String)
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatedDVT_VAT_TU", OLD_DVT, NEW_DVT)
        End Sub
        Public Sub UpdateDVT_XUAT_VAT_TU(ByVal OLD_DVT As String, ByVal NEW_DVT As String)
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatedDVT_XUAT_VAT_TU", OLD_DVT, NEW_DVT)
        End Sub
        Public Sub UpdateDVT_XUAT_PHU_TUNG(ByVal OLD_DVT As String, ByVal NEW_DVT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatedDVT_XUAT_PHU_TUNG", OLD_DVT, NEW_DVT)
        End Sub
        Public Function CheckTEN_DON_VI_TINH(ByVal TEN As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_DON_VI_TINH", TEN)
        End Function

        Public Function CheckExistTEN_DON_VI_TINH(ByVal DVT As String, ByVal TEN As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistTEN_DON_VI_TINH", DVT, TEN)
        End Function
#End Region
    End Class
End Namespace


