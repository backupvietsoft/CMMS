Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class IC_VAT_TUController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetIC_VAT_TUs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_VAT_TUs"))
            Return objDataTable
        End Function

        Public Function GetDON_VI_TINHs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_TINHs"))
            Return objDataTable
        End Function

        Public Function GetIC_VAT_TU(ByVal ID As String) As IC_VAT_TUInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_VAT_TU", ID)
            Dim objIC_VAT_TUInfo As New IC_VAT_TUInfo
            While objDataReader.Read
                objIC_VAT_TUInfo.MS_VAT_TU = objDataReader.Item("MS_VAT_TU")
                objIC_VAT_TUInfo.TEN_VAT_TU = objDataReader.Item("TEN_VAT_TU")
                objIC_VAT_TUInfo.TON_TOI_THIEU = objDataReader.Item("TON_TOI_THIEU")
                objIC_VAT_TUInfo.SL_DA_DAT_CHUA_MUA = objDataReader.Item("SL_DA_DAT_CHUA_MUA")
                objIC_VAT_TUInfo.TON_KHO = objDataReader.Item("TON_KHO")
                objIC_VAT_TUInfo.DVT = objDataReader.Item("DVT")
            End While
            objDataReader.Close()
            Return objIC_VAT_TUInfo
        End Function

        Public Function AddIC_VAT_TU(ByVal objIC_VAT_TUInfo As IC_VAT_TUInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_VAT_TU", _
                objIC_VAT_TUInfo.MS_VAT_TU, objIC_VAT_TUInfo.TEN_VAT_TU, objIC_VAT_TUInfo.TON_TOI_THIEU, objIC_VAT_TUInfo.SL_DA_DAT_CHUA_MUA, objIC_VAT_TUInfo.TON_KHO, objIC_VAT_TUInfo.DVT, objIC_VAT_TUInfo.TOOL)
            Return True
        End Function

        Public Sub UpdateIC_VAT_TU(ByVal objIC_VAT_TUInfo As IC_VAT_TUInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateIC_VAT_TU", _
                objIC_VAT_TUInfo.MS_VAT_TU, objIC_VAT_TUInfo.TEN_VAT_TU, objIC_VAT_TUInfo.TON_TOI_THIEU, objIC_VAT_TUInfo.SL_DA_DAT_CHUA_MUA, objIC_VAT_TUInfo.TON_KHO, objIC_VAT_TUInfo.DVT, objIC_VAT_TUInfo.TOOL)
        End Sub

        Public Sub DeleteIC_VAT_TU(ByVal MS_VAT_TU As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteIC_VAT_TU", MS_VAT_TU)
        End Sub
        Public Function CheckTEN_VAT_TU(ByVal TEN_VAT_TU As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_VAT_TU", TEN_VAT_TU)
        End Function
        Public Function CheckIC_VAT_TU(ByVal MS_VAT_TU As String, ByVal TEN_VAT_TU As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckIC_VAT_TU", MS_VAT_TU, TEN_VAT_TU)
        End Function
#End Region
    End Class
End Namespace
