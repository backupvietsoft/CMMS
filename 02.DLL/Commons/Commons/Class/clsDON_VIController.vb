Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsDON_VIController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetDON_VIs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VIs", Modules.UserName))
            Return objDataTable
        End Function

        Public Sub AddDON_VI(ByVal objDON_VIInfo As DON_VIInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddDON_VI", _
            objDON_VIInfo.MS_DON_VI, objDON_VIInfo.TEN_DON_VI, objDON_VIInfo.TEN_NGAN, _
            objDON_VIInfo.DIA_CHI, objDON_VIInfo.THUE_NGOAI, objDON_VIInfo.MAC_DINH, _
            objDON_VIInfo.DIEN_THOAI, objDON_VIInfo.FAX, objDON_VIInfo.TEN_RUT_GON)
        End Sub

        Public Sub UpdateDON_VI(ByVal objDON_VIInfo As DON_VIInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDON_VI", _
            objDON_VIInfo.MS_DON_VI, objDON_VIInfo.TEN_DON_VI, objDON_VIInfo.TEN_NGAN, _
            objDON_VIInfo.DIA_CHI, objDON_VIInfo.THUE_NGOAI, objDON_VIInfo.MAC_DINH, _
            objDON_VIInfo.DIEN_THOAI, objDON_VIInfo.FAX, objDON_VIInfo.MS_DON_VI_tmp, objDON_VIInfo.TEN_RUT_GON)
        End Sub

        Public Sub DeleteDON_VI(ByVal MS_DON_VI As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteDON_VI", MS_DON_VI)
        End Sub
#End Region
    End Class
End Namespace
