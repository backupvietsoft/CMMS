Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class CAUSE_LIST_Controller

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetCAUSE_LISTs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCAUSE_LISTs"))
            Return objDataTable
        End Function

        Public Function GetPROBLEM_CAUSE(ByVal PROBLEM_ID As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSE", PROBLEM_ID))
            Return objDataTable
        End Function

        Public Function GetCAUSE_LIST(ByVal ID As Integer) As CAUSE_LIST_Info
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHUC_VU", ID)
            Dim objCauseList As New CAUSE_LIST_Info
            While objDataReader.Read
                objCauseList.CAUSE_ID = objDataReader.Item("CAUSE_ID")
                objCauseList.CAUSE_CODE = objDataReader.Item("CAUSE_CODE")
                objCauseList.CAUSE_NAME = objDataReader.Item("CAUSE_NAME")
                objCauseList.CAUSE_NOTE = objDataReader.Item("CAUSE_NOTE")
            End While
            objDataReader.Close()
            Return objCauseList
        End Function

        Public Sub AddCAUSE_LIST(ByVal objCauseList As CAUSE_LIST_Info)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddCAUSE_LIST", _
            objCauseList.CAUSE_ID, objCauseList.CAUSE_CODE, objCauseList.CAUSE_NAME, objCauseList.CAUSE_NOTE)
        End Sub

        Public Sub UpdateCAUSE_LIST(ByVal objCauseList As CAUSE_LIST_Info)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCAUSE_LIST", _
            objCauseList.CAUSE_ID, objCauseList.CAUSE_CODE, objCauseList.CAUSE_NAME, objCauseList.CAUSE_NOTE)
        End Sub

        Public Function DeleteCAUSE_LIST(ByVal CAUSE_ID As String) As Integer
            Return SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteCAUSE_LIST", CAUSE_ID)
        End Function
#End Region

    End Class
End Namespace