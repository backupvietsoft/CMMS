Imports System.Data.SqlClient

Public Class clsConnect
    Public Shared Connectstring As String = " Data Source=YEN;Initial Catalog=CMMS_DUY_TAN;User ID=sa;password = 123"


    Public Shared Function OpenConnect(ByVal sqlCN As SqlConnection) As Boolean
        Try
            sqlCN.ConnectionString = Commons.IConnections.ConnectionString
            If (sqlCN.State = ConnectionState.Closed) Then
                sqlCN.Open()
            End If
            Return True

        Catch ex As Exception
            Windows.Forms.MessageBox.Show("Có lỗi kết nối. Bạn vui lòng kiểm tra lại !", "Thông báo")
            Return False
        End Try

    End Function

    Public Shared Function CloseConect(ByVal sqlCN As SqlConnection) As Boolean
        Try
            sqlCN = New SqlConnection(Commons.IConnections.ConnectionString)
            If (sqlCN.State = ConnectionState.Closed) Then
                Return True
                Exit Function
            Else
                sqlCN.Close()
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
