Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class NGAN_SACHController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetNGAN_SACHs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAN_SACHs"))
            Return objDataTable
        End Function

        Public Function GetNGAN_SACH(ByVal ID As Integer) As NGAN_SACHInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAN_SACH", ID)
            Dim objNGAN_SACHInfo As New NGAN_SACHInfo
            While objDataReader.Read
                objNGAN_SACHInfo.MS_BP_CHIU_PHI = objDataReader.Item("MS_BP_CHIU_PHI")
                objNGAN_SACHInfo.NGAN_SACH_NAM = objDataReader.Item("NGAN_SACH_NAM")
                objNGAN_SACHInfo.SO_TIEN = objDataReader.Item("SO_TIEN")
                objNGAN_SACHInfo.NGOAI_TE = objDataReader.Item("NGOAI_TE")
            End While
            objDataReader.Close()
            Return objNGAN_SACHInfo
        End Function

        Public Sub AddNGAN_SACH(ByVal objNGAN_SACHInfo As NGAN_SACHInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddNGAN_SACH", _
            objNGAN_SACHInfo.MS_BP_CHIU_PHI, objNGAN_SACHInfo.NGAN_SACH_NAM, _
            objNGAN_SACHInfo.SO_TIEN, objNGAN_SACHInfo.NGOAI_TE)
        End Sub

        Public Sub UpdateNGAN_SACH(ByVal objNGAN_SACHInfo As NGAN_SACHInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateNGAN_SACH", _
            objNGAN_SACHInfo.MS_BP_CHIU_PHI, objNGAN_SACHInfo.NGAN_SACH_NAM, _
            objNGAN_SACHInfo.SO_TIEN, objNGAN_SACHInfo.NGOAI_TE)
        End Sub

        Public Sub DeleteNGAN_SACH(ByVal MS_BP_CHIU_PHI As Integer, ByVal NGAN_SACH_NAM As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNGAN_SACH", MS_BP_CHIU_PHI, NGAN_SACH_NAM)
        End Sub
#End Region

    End Class

End Namespace
