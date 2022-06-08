Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin

Namespace VS.Classes.Admin
    Public Class CHI_TIET_FORMController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetCHI_TIET_FORMs(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHI_TIET_FORMs", User))
            Return objDataTable
        End Function

        Public Function GetCHI_TIET_FORM(ByVal FormName As String) As CHI_TIET_FORMInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                "GetCHI_TIET_FORM", FormName)
            Dim objCHI_TIET_FORMInfo As New CHI_TIET_FORMInfo
            While objDataReader.Read
                objCHI_TIET_FORMInfo.FORM_NAME = objDataReader.Item("FORM_NAME")
                objCHI_TIET_FORMInfo.TEN_FORMS_ANH = objDataReader.Item("TEN_FORMS_ANH")
                objCHI_TIET_FORMInfo.TEN_FORMS_VIET = objDataReader.Item("TEN_FORMS_VIET")
            End While
            Return objCHI_TIET_FORMInfo
        End Function

        Public Function AddCHI_TIET_FORM(ByVal objCHI_TIET_FORMInfo As CHI_TIET_FORMInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddCHI_TIET_FORM", _
                objCHI_TIET_FORMInfo.FORM_NAME, objCHI_TIET_FORMInfo.TEN_FORMS_ANH, _
                objCHI_TIET_FORMInfo.TEN_FORMS_VIET)
            Return objCHI_TIET_FORMInfo.FORM_NAME
        End Function

        Public Sub UpdateCHI_TIET_FORM(ByVal objCHI_TIET_FORMInfo As CHI_TIET_FORMInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCHI_TIET_FORM", _
                objCHI_TIET_FORMInfo.FORM_NAME, objCHI_TIET_FORMInfo.TEN_FORMS_ANH, _
                objCHI_TIET_FORMInfo.TEN_FORMS_VIET)
        End Sub

        Public Sub DeleteCHI_TIET_FORM(ByVal FormName As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCHI_TIET_FORM", FormName)
        End Sub
#End Region
    End Class

End Namespace

