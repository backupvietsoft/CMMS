Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class MUC_UU_TIENController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetMUC_UU_TIENs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIENs"))
            Return objDataTable
        End Function

        Public Function GetMUC_UU_TIEN(ByVal ID As Integer) As MUC_UU_TIENInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIEN", ID)
            Dim objMUC_UU_TIENInfo As New MUC_UU_TIENInfo
            While objDataReader.Read
                objMUC_UU_TIENInfo.MS_UU_TIEN = objDataReader.Item("MS_UU_TIEN")
                objMUC_UU_TIENInfo.TEN_UU_TIEN = objDataReader.Item("TEN_UU_TIEN")
            End While
            objDataReader.Close()
            Return objMUC_UU_TIENInfo
        End Function

        Public Sub AddMUC_UU_TIEN(ByVal objMUC_UU_TIENInfo As MUC_UU_TIENInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddMUC_UU_TIEN", _
                                    objMUC_UU_TIENInfo.MS_UU_TIEN, objMUC_UU_TIENInfo.TEN_UU_TIEN)
        End Sub

        Public Sub UpdateMUC_UU_TIEN(ByVal objMUC_UU_TIENInfo As MUC_UU_TIENInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMUC_UU_TIEN", _
                                    objMUC_UU_TIENInfo.MS_UU_TIEN, objMUC_UU_TIENInfo.TEN_UU_TIEN, _
                                    objMUC_UU_TIENInfo.MS_UU_TIEN_tmp)
        End Sub

        Public Sub DeleteMUC_UU_TIEN(ByVal MS_UU_TIEN As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteMUC_UU_TIEN", MS_UU_TIEN)
        End Sub
#End Region

    End Class

End Namespace