Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsYEU_CAU_NSD_CHI_TIET_HINHController

        Public Sub New()
        End Sub
        Public Function GetYEU_CAU_NSD_CHI_TIET_HINHs(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intSTT_VAN_DE As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_CHI_TIET_HINHs", intSTT, strMS_MAY, intSTT_VAN_DE))
            Return objDataTable
        End Function

        Public Function GetTONG_SO_HINHs(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intSTT_VAN_DE As Integer) As Integer
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_CHI_TIET_HINHs", intSTT, strMS_MAY, intSTT_VAN_DE))
            Return (objDataTable.Rows.Count - 1)
        End Function

        Public Function AddYEU_CAU_NSD_CHI_TIET_HINH(ByVal objYEU_CAU_NSDInfo As clsYEU_CAU_NSD_CHI_TIET_HINHInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddYEU_CAU_NSD_CHI_TIET_HINH", _
               objYEU_CAU_NSDInfo.STT, objYEU_CAU_NSDInfo.MS_MAY, objYEU_CAU_NSDInfo.STT_VAN_DE, objYEU_CAU_NSDInfo.DUONG_DAN, objYEU_CAU_NSDInfo.GHI_CHU)
            Return True
        End Function
        Public Sub UpdateYEU_CAU_NSD_CHI_TIET_HINH(ByVal objYEU_CAU_NSD_CT_HINHInfo As clsYEU_CAU_NSD_CHI_TIET_HINHInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateYEU_CAU_NSD_CHI_TIET_HINH", _
                           objYEU_CAU_NSD_CT_HINHInfo.STT, objYEU_CAU_NSD_CT_HINHInfo.MS_MAY, objYEU_CAU_NSD_CT_HINHInfo.STT_VAN_DE, objYEU_CAU_NSD_CT_HINHInfo.STT_HINH, _
                            objYEU_CAU_NSD_CT_HINHInfo.DUONG_DAN, objYEU_CAU_NSD_CT_HINHInfo.GHI_CHU)
        End Sub

        Public Sub UpdateYEU_CAU_NSD_CHI_TIET_HINH_GHI_CHU(ByVal objYEU_CAU_NSD_CT_HINHInfo As clsYEU_CAU_NSD_CHI_TIET_HINHInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateYEU_CAU_NSD_CHI_TIET_HINH_GHI_CHU", _
                           objYEU_CAU_NSD_CT_HINHInfo.STT, objYEU_CAU_NSD_CT_HINHInfo.MS_MAY, objYEU_CAU_NSD_CT_HINHInfo.STT_VAN_DE, objYEU_CAU_NSD_CT_HINHInfo.STT_HINH, _
                            objYEU_CAU_NSD_CT_HINHInfo.GHI_CHU)
        End Sub
        Public Sub DeleteYEU_CAU_NSD_CHI_TIET_HINH(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intSTT_VAN_DE As Integer, ByVal intSTT_HINH As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteYEU_CAU_NSD_CHI_TIET_HINH", intSTT, strMS_MAY, intSTT_VAN_DE, intSTT_HINH)
        End Sub
    End Class
End Namespace

