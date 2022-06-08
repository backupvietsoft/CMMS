Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class BAC_THOController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetBAC_THOs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBAC_THOs"))
            Return objDataTable
        End Function

        Public Function GetBAC_THO(ByVal ID As Integer) As BAC_THOInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBAC_THO", ID)
            Dim objBAC_THOInfo As New BAC_THOInfo
            While objDataReader.Read
                objBAC_THOInfo.MS_BT = objDataReader.Item("MS_BT")
                objBAC_THOInfo.TEN_BT = objDataReader.Item("TEN_BT")
            End While
            objDataReader.Close()
            Return objBAC_THOInfo
        End Function

        Public Sub AddBAC_THO(ByVal objBAC_THOInfo As BAC_THOInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddBAC_THO", objBAC_THOInfo.TEN_BT)
        End Sub

        Public Sub UpdateBAC_THO(ByVal objBAC_THOInfo As BAC_THOInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateBAC_THO", objBAC_THOInfo.MS_BT, objBAC_THOInfo.TEN_BT)
        End Sub

        Public Sub DeleteBAC_THO(ByVal MS_BT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteBAC_THO", MS_BT)
        End Sub
#End Region

    End Class

End Namespace