Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class REMEDY_CAUSE_Controller

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetREMEDY_CAUSEs(ByVal CAUSE_ID As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", CAUSE_ID))
            Return objDataTable
        End Function

        Public Function GetREMEDY_CAUSE(ByVal CAUSE_ID As String, ByVal REMEDY_ID As String) As REMEDY_CAUSE_Info
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSE", CAUSE_ID, REMEDY_ID)
            Dim objREMEDY_CAUSE_Info As New REMEDY_CAUSE_Info
            While objDataReader.Read
                objREMEDY_CAUSE_Info.CAUSE_ID = objDataReader.Item("CAUSE_ID")
                objREMEDY_CAUSE_Info.REMEDY_ID = objDataReader.Item("REMEDY_ID")
                objREMEDY_CAUSE_Info.REMEDY_CODE = objDataReader.Item("REMEDY_CODE")
                objREMEDY_CAUSE_Info.REMEDY_NAME = objDataReader.Item("REMEDY_NAME")
                objREMEDY_CAUSE_Info.NOTE = objDataReader.Item("NOTE")
                objREMEDY_CAUSE_Info.LINK = objDataReader.Item("LINK")
            End While
            objDataReader.Close()
            Return objREMEDY_CAUSE_Info
        End Function

        Public Sub AddREMEDY_CAUSE(ByVal objREMEDY_CAUSE_Info As REMEDY_CAUSE_Info)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddREMEDY_CAUSE", _
            objREMEDY_CAUSE_Info.CAUSE_ID, objREMEDY_CAUSE_Info.REMEDY_ID, objREMEDY_CAUSE_Info.REMEDY_CODE, objREMEDY_CAUSE_Info.REMEDY_NAME, objREMEDY_CAUSE_Info.LINK, objREMEDY_CAUSE_Info.NOTE)
        End Sub

        Public Sub UpdateREMEDY_CAUSE(ByVal objREMEDY_CAUSE_Info As REMEDY_CAUSE_Info)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateREMEDY_CAUSE", _
            objREMEDY_CAUSE_Info.CAUSE_ID, objREMEDY_CAUSE_Info.REMEDY_ID, objREMEDY_CAUSE_Info.REMEDY_CODE, objREMEDY_CAUSE_Info.REMEDY_NAME, objREMEDY_CAUSE_Info.LINK, objREMEDY_CAUSE_Info.NOTE)
        End Sub

        Public Function DeleteREMEDY_CAUSE(ByVal CAUSE_ID As String, ByVal REMEDY_ID As String) As Integer
            Return SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteREMEDY_CAUSE", CAUSE_ID, REMEDY_ID)
        End Function
      
#End Region

    End Class
End Namespace