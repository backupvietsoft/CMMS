Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
    Public Class OLanguages
    Public Sub New()
    End Sub

#Region "Public Method"
    Public Sub AddLanguage(ByVal objLanguage As ILanguages)
        SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, "AddLaguage", objLanguage.MS_MODULE, objLanguage.FORM, objLanguage.KEYWORD, objLanguage.VIETNAM, objLanguage.ENGLISH)

    End Sub

    Public Sub UpdateLanguage(ByVal objLanguage As ILanguages)
        SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, "UpdateLaguage", objLanguage.STT, objLanguage.MS_MODULE, objLanguage.FORM, objLanguage.KEYWORD, objLanguage.VIETNAM, objLanguage.ENGLISH)

    End Sub
 
    Public Sub DeleteLanguage(ByVal ID As Integer)
        SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, "DeleteLaguage")
    End Sub

    Public Function GetLanguage(ByVal FormName As String, ByVal Keyword As String) As String
        Dim sStr As String
        Try
            sStr = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spGetNN", Modules.ModuleName, FormName, Keyword, Modules.TypeLanguage)
        Catch ex As Exception
            sStr = "?" & Keyword & "?"
        End Try
        Return sStr

    End Function


    Public Function GetLanguage(ByVal ModuleName As String, ByVal FormName As String, ByVal Keyword As String, ByVal TypeLanguage As Integer) As String
        Dim sStr As String
        Try
            sStr = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spGetNN", ModuleName, FormName, Keyword, TypeLanguage)
        Catch ex As Exception
            sStr = "?" & Keyword & "?"
        End Try
        Return sStr
    End Function

    Public Function GetLanguages() As DataTable
        Dim dtTable As DataTable = New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLanguages"))
        Return dtTable
    End Function
#End Region
    End Class