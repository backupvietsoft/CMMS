Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class MAY_LOAI_BTPN_CONG_VIECController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetMAY_LOAI_BTPN_CONG_VIECs(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetMAY_LOAI_BTPN_CONG_VIECs", MS_MAY))
            Return objDataTable
        End Function
        Public Function AddMAY_LOAI_BTPN_CONG_VIEC(ByVal Sqltran As SqlTransaction, ByVal objMAY_LOAI_BTPN_CONG_VIECInfo As MAY_LOAI_BTPN_CONG_VIECInfo) As String
            SqlHelper.ExecuteScalar(Sqltran, "AddMAY_LOAI_BTPN_CONG_VIEC", _
                objMAY_LOAI_BTPN_CONG_VIECInfo.MS_MAY, objMAY_LOAI_BTPN_CONG_VIECInfo.MS_LOAI_BT, objMAY_LOAI_BTPN_CONG_VIECInfo.MS_CV, objMAY_LOAI_BTPN_CONG_VIECInfo.MS_BO_PHAN)
            Return True
        End Function

#End Region
    End Class
End Namespace

