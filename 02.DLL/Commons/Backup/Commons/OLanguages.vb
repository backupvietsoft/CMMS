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
        Dim dtReader As SqlDataReader
        Dim tam As String
        dtReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLanguage", Modules.ModuleName, FormName, Keyword)
        If dtReader.HasRows Then
            While dtReader.Read
                If Modules.TypeLanguage = 0 Then
                    tam = dtReader.Item("VIETNAM").ToString
                Else
                    If Modules.TypeLanguage = 1 Then
                        tam = dtReader.Item("ENGLISH").ToString
                    Else
                        tam = dtReader.Item("CHINESE").ToString
                    End If
                End If
                dtReader.Close()
                Return tam
            End While

        Else
            dtReader.Close()
            Dim sTV As String = "@" + Keyword + "@"
            Dim sTA As String = "@" + Keyword + "@"
            Dim sTH As String = "@" + Keyword + "@"
            Dim sSql As String = " SELECT TOP 1 ISNULL(VIETNAM,'') AS VIETNAM, ISNULL(ENGLISH,'') AS ENGLISH,ISNULL(CHINESE,'') AS CHINESE " & _
                        " FROM [LANGUAGES] WHERE KEYWORD = N'" & Keyword & "'   AND SUBSTRING(VIETNAM,1,1) <> '@' " & _
                        " GROUP BY VIETNAM , ENGLISH, CHINESE ORDER BY COUNT(KEYWORD) DESC"

            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

            If dtTmp.Rows.Count > 0 Then
                Try
                    If dtTmp.Rows(0)("VIETNAM").ToString() <> "" Then sTV = dtTmp.Rows(0)("VIETNAM").ToString()
                Catch ex As Exception
                    sTV = "@" + Keyword + "@"
                End Try
                Try
                    If dtTmp.Rows(0)("ENGLISH").ToString() <> "" Then sTA = dtTmp.Rows(0)("ENGLISH").ToString()
                Catch ex As Exception
                    sTA = "@" + Keyword + "@"
                End Try
                Try
                    If dtTmp.Rows(0)("CHINESE").ToString() <> "" Then sTH = dtTmp.Rows(0)("CHINESE").ToString()
                Catch ex As Exception
                    sTH = "@" + Keyword + "@"
                End Try
            End If
            Dim result As Integer = SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, CommandType.Text, _
                " INSERT INTO [LANGUAGES]([MS_MODULE],[FORM],[KEYWORD],[VIETNAM],[ENGLISH],[CHINESE]," & _
                        " [FORM_HAY_REPORT],[VIETNAM_OR],[ENGLISH_OR],[CHINESE_OR]) " & _
                        " VALUES(N'" + Modules.ModuleName + "',N'" + FormName + "',N'" + Keyword + "',N'" + sTV + "',N'" + sTA + "',N'" + sTH + "'," & _
                        " 0,N'" + sTV + "',N'" + sTA + "',N'" + sTH + "')")
            If Modules.TypeLanguage = 0 Then
                tam = sTV
            Else
                If Modules.TypeLanguage = 1 Then
                    tam = sTA
                Else
                    tam = sTH
                End If
            End If
            dtReader.Close()
            Return tam
        End If
        If dtReader.IsClosed Then
            dtReader.Close()
        End If
        Return "?" & Keyword & "?"
    End Function


    Public Function GetLanguage(ByVal ModuleName As String, ByVal FormName As String, ByVal Keyword As String, ByVal TypeLanguage As Integer) As String
        Dim dtReader As SqlDataReader
        Dim tam As String
        'MsgBox(Connect.ConnectionString)            
        dtReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLanguage", ModuleName, FormName, Keyword)
        If dtReader.HasRows Then
            While dtReader.Read
                If TypeLanguage = 0 Then
                    tam = dtReader.Item("VIETNAM").ToString
                Else
                    If TypeLanguage = 1 Then
                        tam = dtReader.Item("ENGLISH").ToString
                    Else
                        tam = dtReader.Item("CHINESE").ToString
                    End If
                End If
                dtReader.Close()
                Return tam
            End While

        Else
            dtReader.Close()
            Dim sTV As String = "@" + Keyword + "@"
            Dim sTA As String = "@" + Keyword + "@"
            Dim sTH As String = "@" + Keyword + "@"
            Dim sSql As String = " SELECT TOP 1 ISNULL(VIETNAM,'') AS VIETNAM, ISNULL(ENGLISH,'') AS ENGLISH,ISNULL(CHINESE,'') AS CHINESE " & _
                        " FROM [LANGUAGES] WHERE KEYWORD = N'" & Keyword & "'   AND SUBSTRING(VIETNAM,1,1) <> '@' " & _
                        " GROUP BY VIETNAM , ENGLISH, CHINESE ORDER BY COUNT(KEYWORD) DESC"

            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

            If dtTmp.Rows.Count > 0 Then
                Try
                    If dtTmp.Rows(0)("VIETNAM").ToString() <> "" Then sTV = dtTmp.Rows(0)("VIETNAM").ToString()
                Catch ex As Exception
                    sTV = "@" + Keyword + "@"
                End Try
                Try
                    If dtTmp.Rows(0)("ENGLISH").ToString() <> "" Then sTA = dtTmp.Rows(0)("ENGLISH").ToString()
                Catch ex As Exception
                    sTA = "@" + Keyword + "@"
                End Try
                Try
                    If dtTmp.Rows(0)("CHINESE").ToString() <> "" Then sTH = dtTmp.Rows(0)("CHINESE").ToString()
                Catch ex As Exception
                    sTH = "@" + Keyword + "@"
                End Try
            End If
            Dim result As Integer = SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, CommandType.Text, _
                " INSERT INTO [LANGUAGES]([MS_MODULE],[FORM],[KEYWORD],[VIETNAM],[ENGLISH],[CHINESE]," & _
                        " [FORM_HAY_REPORT],[VIETNAM_OR],[ENGLISH_OR],[CHINESE_OR]) " & _
                        " VALUES(N'" + ModuleName + "',N'" + FormName + "',N'" + Keyword + "',N'" + sTV + "',N'" + sTA + "',N'" + sTH + "'," & _
                        " 0,N'" + sTV + "',N'" + sTA + "',N'" + sTH + "')")
            If TypeLanguage = 0 Then
                tam = sTV
            Else
                If TypeLanguage = 1 Then
                    tam = sTA
                Else
                    tam = sTH
                End If
            End If
            dtReader.Close()
            Return tam
        End If
        If dtReader.IsClosed Then
            dtReader.Close()
        End If
        Return "?" & Keyword & "?"
    End Function

    Public Function GetLanguages() As DataTable
        Dim dtTable As DataTable = New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLanguages"))
        Return dtTable
    End Function
#End Region
    End Class