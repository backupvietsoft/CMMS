Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class PROBLEM_LIST_Controller

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetPROBLEM_LISTs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPROBLEM_LISTs"))
            Return objDataTable
        End Function
        Public Function GetCLASS_PROBLEM(ByVal CLASS_ID As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCLASS_PROBLEM", CLASS_ID))
            Return objDataTable
        End Function

        Public Function GetPROBLEM_LIST(ByVal ID As Integer) As PROBLEM_LIST_Info
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPROBLEM_LIST", ID)
            Dim objPROBLEM_LIST As New PROBLEM_LIST_Info
            While objDataReader.Read
                objPROBLEM_LIST.PROBLEM_ID = objDataReader.Item("PROBLEM_ID")
                objPROBLEM_LIST.PROBLEM_CODE = objDataReader.Item("PROBLEM_CODE")
                objPROBLEM_LIST.PROBLEM_NAME = objDataReader.Item("PROBLEM_NAME")
                objPROBLEM_LIST.PROBLEM_NOTE = objDataReader.Item("PROBLEM_NOTE")
            End While
            objDataReader.Close()
            Return objPROBLEM_LIST
        End Function

        Public Sub AddPROBLEM_LIST(ByVal objPROBLEM_LIST As PROBLEM_LIST_Info)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPROBLEM_LIST", _
            objPROBLEM_LIST.PROBLEM_ID, objPROBLEM_LIST.PROBLEM_CODE, objPROBLEM_LIST.PROBLEM_NAME, objPROBLEM_LIST.PROBLEM_NOTE)
        End Sub

        Public Sub UpdatePROBLEM_LIST(ByVal objPROBLEM_LIST As PROBLEM_LIST_Info)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePROBLEM_LIST", _
             objPROBLEM_LIST.PROBLEM_ID, objPROBLEM_LIST.PROBLEM_CODE, objPROBLEM_LIST.PROBLEM_NAME, objPROBLEM_LIST.PROBLEM_NOTE)
        End Sub

        Public Function DeletePROBLEM_LIST(ByVal PROBLEM_ID As String) As Integer
            Return SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeletePROBLEM_LIST", PROBLEM_ID)
        End Function
       
#End Region

    End Class
End Namespace