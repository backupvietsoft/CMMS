Imports System.Data.SqlClient
Public Class cls_May
    Public Function GetList_May(ByVal SQLString As String) As SqlDataReader
        Dim myReader As SqlDataReader
        Dim provide As New cls_DataProvider
        myReader = provide.executeQuery(SQLString)
        Return myReader
    End Function
End Class
