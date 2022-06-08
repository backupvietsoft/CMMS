Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class LOAI_MAYController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetLOAI_MAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_MAY1"))
            Return objDataTable
        End Function

        Public Function GetLOAI_MAY(ByVal ID As Integer) As LOAI_MAYInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_MAY", ID)
            Dim objLOAI_MAYInfo As New LOAI_MAYInfo
            While objDataReader.Read
                objLOAI_MAYInfo.MS_LOAI_MAY = objDataReader.Item("MS_LOAI_MAY")
                objLOAI_MAYInfo.TEN_LOAI_MAY = objDataReader.Item("TEN_LOAI_MAY")
                objLOAI_MAYInfo.STT_MAY = objDataReader.Item("STT_MAY")

            End While
            objDataReader.Close()
            Return objLOAI_MAYInfo
        End Function

        Public Function AddLOAI_MAY(ByVal objLOAI_MAYInfo As LOAI_MAYInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddLOAI_MAY", _
                objLOAI_MAYInfo.MS_LOAI_MAY, objLOAI_MAYInfo.TEN_LOAI_MAY, objLOAI_MAYInfo.STT_MAY, objLOAI_MAYInfo.ATTACHMENT)
            Return True
        End Function

        Public Sub UpdateLOAI_MAY(ByVal objLOAI_MAYInfo As LOAI_MAYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLOAI_MAY", _
                objLOAI_MAYInfo.MS_LOAI_MAY, objLOAI_MAYInfo.TEN_LOAI_MAY, objLOAI_MAYInfo.STT_MAY, objLOAI_MAYInfo.MS_LOAI_MAY_TMP, objLOAI_MAYInfo.ATTACHMENT)
        End Sub

        Public Sub DeleteLOAI_MAY(ByVal MS_LOAI_MAY As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteLOAI_MAY", MS_LOAI_MAY)
        End Sub
        Public Sub InsertLOAI_MAY(ByVal ID As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_LOAI_MAY_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub
        Public Function CheckTEN_LOAI_MAY(ByVal TEN_LOAI_MAY As String) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_LOAI_MAY", TEN_LOAI_MAY)
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            objDataReader.Close()
            Return False
        End Function

        Public Function CheckTRUNG_LOAI_MAY(ByVal MS_LOAI_MAY As String) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTRUNG_LOAI_MAY", MS_LOAI_MAY)
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            objDataReader.Close()
            Return False
        End Function

        Public Sub DeleteNHOM_LOAI_MAY_1(ByVal MS_LOAI_MAY As String, ByVal USERNAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNHOM_LOAI_MAY_1", MS_LOAI_MAY, USERNAME)
        End Sub
        Public Sub InsertNHOM_LOAI_MAY_1(ByVal ID As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_LOAI_MAY_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub
#End Region
    End Class
End Namespace
