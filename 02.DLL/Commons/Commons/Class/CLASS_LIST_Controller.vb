Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class CLASS_LIST_Controller

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetCLASS_LISTs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCLASS_LISTs"))
            Return objDataTable
        End Function

        Public Function GetCLASS_LIST(ByVal ID As Integer) As CLASS_LIST_Info
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCLASS_LIST", ID)
            Dim objCLASS_LIST_Info As New CLASS_LIST_Info
            While objDataReader.Read
                objCLASS_LIST_Info.CLASS_ID = objDataReader.Item("CLASS_ID")
                objCLASS_LIST_Info.CLASS_CODE = objDataReader.Item("CLASS_CODE")
                objCLASS_LIST_Info.CLASS_NAME = objDataReader.Item("CLASS_NAME")
                objCLASS_LIST_Info.CLASS_NOTE = objDataReader.Item("CLASS_NOTE")
            End While
            objDataReader.Close()
            Return objCLASS_LIST_Info
        End Function

        Public Sub AddCLASS_LIST(ByVal objCLASS_LIST_Info As CLASS_LIST_Info)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddCLASS_LIST", _
            objCLASS_LIST_Info.CLASS_ID, objCLASS_LIST_Info.CLASS_CODE, objCLASS_LIST_Info.CLASS_NAME, objCLASS_LIST_Info.CLASS_NOTE)
        End Sub

        Public Sub UpdateCLASS_LIST(ByVal objCLASS_LIST_Info As CLASS_LIST_Info)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCLASS_LIST", _
            objCLASS_LIST_Info.CLASS_ID, objCLASS_LIST_Info.CLASS_CODE, objCLASS_LIST_Info.CLASS_NAME, objCLASS_LIST_Info.CLASS_NOTE)
        End Sub

        Public Function DeleteCLASS_LIST(ByVal CLASS_ID As String) As Integer
            Return SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteCLASS_LIST", CLASS_ID)
        End Function
#End Region

    End Class
End Namespace