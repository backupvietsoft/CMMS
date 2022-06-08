Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class MAY_LOAI_BTPN_CONG_VIEC_TOOLController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetMAY_LOAI_BTPN_CONG_VIEC_TOOLs(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOAI_BTPN_CONG_VIEC_TOOLs", MS_MAY))
            Return objDataTable
        End Function
        Public Function AddMAY_LOAI_BTPN_CONG_VIEC_TOOL(ByVal objMAY_LOAI_BTPN_CONG_VIECInfo As MAY_LOAI_BTPN_CONG_VIEC_TOOLInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddMAY_LOAI_BTPN_CONG_VIEC_TOOL", _
                objMAY_LOAI_BTPN_CONG_VIECInfo.MS_MAY, objMAY_LOAI_BTPN_CONG_VIECInfo.MS_LOAI_BT, objMAY_LOAI_BTPN_CONG_VIECInfo.MS_CV, objMAY_LOAI_BTPN_CONG_VIECInfo.MS_VT)
            Return True
        End Function

#End Region
    End Class
End Namespace

