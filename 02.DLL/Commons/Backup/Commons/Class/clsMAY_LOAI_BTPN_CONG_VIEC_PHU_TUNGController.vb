Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNGController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNGs(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNGs", MS_MAY))
            Return objDataTable
        End Function
        Public Function AddMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG(ByVal Sqltran As SqlTransaction, ByVal objMAY_LOAI_BTPN_CONG_VIECInfo As MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNGInfo) As String
            SqlHelper.ExecuteScalar(Sqltran, "AddMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG", _
                objMAY_LOAI_BTPN_CONG_VIECInfo.MS_MAY, objMAY_LOAI_BTPN_CONG_VIECInfo.MS_LOAI_BT, objMAY_LOAI_BTPN_CONG_VIECInfo.MS_CV, _
                objMAY_LOAI_BTPN_CONG_VIECInfo.MS_PT, objMAY_LOAI_BTPN_CONG_VIECInfo.SO_LUONG, _
                objMAY_LOAI_BTPN_CONG_VIECInfo.MS_BO_PHAN, objMAY_LOAI_BTPN_CONG_VIECInfo.GHI_CHU_BTPN, objMAY_LOAI_BTPN_CONG_VIECInfo.QUI_CACH)
            Return True
        End Function

#End Region
    End Class
End Namespace

