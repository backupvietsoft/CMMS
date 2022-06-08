Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class NHOM_MAYController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetNHOM_MAYs(ByVal MS_LOAI_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHOM_MAY", MS_LOAI_MAY))
            Return objDataTable
        End Function

        Public Function GetLOAI_MAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_MAYs"))
            Return objDataTable
        End Function

        Public Function GetNHOM_MAY(ByVal ID As Integer) As NHOM_MAYInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHOM_MAY", ID)
            Dim objNHOM_MAYInfo As New NHOM_MAYInfo
            While objDataReader.Read
                objNHOM_MAYInfo.MS_NHOM_MAY = objDataReader.Item("MS_NHOM_MAY")
                objNHOM_MAYInfo.TEN_NHOM_MAY = objDataReader.Item("TEN_NHOM_MAY")
            End While
            objDataReader.Close()
            Return objNHOM_MAYInfo
        End Function

        Public Sub AddNHOM_MAY(ByVal objNHOM_MAYInfo As NHOM_MAYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddNHOM_MAY", _
                objNHOM_MAYInfo.MS_NHOM_MAY, objNHOM_MAYInfo.TEN_NHOM_MAY, objNHOM_MAYInfo.MS_LOAI_MAY)
        End Sub

        Public Sub UpdateNHOM_MAY(ByVal objNHOM_MAYInfo As NHOM_MAYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateNHOM_MAY", _
                objNHOM_MAYInfo.MS_NHOM_MAY, objNHOM_MAYInfo.TEN_NHOM_MAY, objNHOM_MAYInfo.MS_LOAI_MAY, _
                objNHOM_MAYInfo.MS_NHOM_MAY_TMP, objNHOM_MAYInfo.MS_LOAI_MAY_TMP)
        End Sub
        Public Sub InsertNHOM_MAY_LOG(ByVal ID As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_MAY_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub
        Public Sub DeleteNHOM_MAY(ByVal MS_NHOM_MAY As String, ByVal MS_LOAI_MAY As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNHOM_MAY", MS_NHOM_MAY, MS_LOAI_MAY)
        End Sub
        Public Sub InsertNHOM_MAY(ByVal ID As String, ByVal ID1 As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_MAY_LOG_1", ID, ID1, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub
        Public Function CheckTEN_NHOM_MAY(ByVal TEN_NHOM_MAY As String, ByVal MS_LOAI_MAY As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_NHOM_MAY", TEN_NHOM_MAY, MS_LOAI_MAY)
        End Function
        Public Function CheckNHOM_MAY(ByVal MS_NHOM_MAY As String, ByVal TEN_NHOM_MAY As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckNHOM_MAY", MS_NHOM_MAY, TEN_NHOM_MAY)
        End Function
        Public Function CheckTRUNG_NHOM_MAY(ByVal MS_NHOM_MAY As String) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTRUNG_NHOM_MAY", MS_NHOM_MAY)
            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            objDataReader.Close()
            Return False
        End Function
#End Region
    End Class
End Namespace
