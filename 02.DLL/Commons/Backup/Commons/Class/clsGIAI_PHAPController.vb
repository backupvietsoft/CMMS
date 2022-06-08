Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class clsGIAI_PHAPController
        Public Sub New()
        End Sub
#Region "Public Method"
        Public Function GetGIAI_PHAPs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIAIPHAPs"))
            Return objDataTable
        End Function

        Public Sub AddPRIORITY(ByVal objGIAI_PHAPInfo As clsGIAI_PHAPInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddGIAI_PHAP", objGIAI_PHAPInfo.MA, objGIAI_PHAPInfo.TEN_1, objGIAI_PHAPInfo.TEN_2, objGIAI_PHAPInfo.TEN_3)
        End Sub
        Public Sub UpdateGIAI_PHAP(ByVal objGIAI_PHAPInfo As clsGIAI_PHAPInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateGIAI_PHAP", objGIAI_PHAPInfo.MA_TMP, objGIAI_PHAPInfo.MA, objGIAI_PHAPInfo.TEN_1, objGIAI_PHAPInfo.TEN_2, objGIAI_PHAPInfo.TEN_3)
        End Sub
        Public Sub DeleteGIAI_PHAP(ByVal STT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIAI_PHAP", STT)
        End Sub
#End Region
    End Class
End Namespace

