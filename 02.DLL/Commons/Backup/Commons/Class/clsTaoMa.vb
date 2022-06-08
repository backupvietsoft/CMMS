Imports System.Data.SqlClient

Public Class clsTaoMa


    Public Shared Function RandomId(ByVal tmpStoreProcedure As String, ByVal table As String, ByVal table_id As String, ByVal id As String) As String
        Dim num As Integer = 0
        Dim strCode As String = ""
        Dim sql As String = ""

        Dim connection As SqlConnection = New SqlConnection()
        Dim cmdstore As New System.Data.SqlClient.SqlCommand()
        cmdstore.Connection = connection
        Try
            If clsConnect.OpenConnect(connection) Then

                Dim command As New System.Data.SqlClient.SqlCommand()
                command.Connection = connection
                sql = (" select count(" & table_id & ") total from ") + table
                command.CommandText = sql
                Dim dataAdapter As New SqlDataAdapter()
                dataAdapter.SelectCommand = command
                dataAdapter.TableMappings.Add("Table", table)
                Dim dataSet As New DataSet()
                dataAdapter.Fill(dataSet)
                Dim myDataRow As DataRow = dataSet.Tables(table).Rows(0)
                Dim dataColumn As DataColumn = dataSet.Tables(table).Columns(0)
                num = CInt(myDataRow(dataColumn))
                'Create Check Primary Store Proc
                sql = (("create proc " & tmpStoreProcedure & "(@id varchar(16)," & "@Result int=1 Output) as " & "If not Exists(SELECT * FROM ") + table & " where ") + table_id & "=@id) " & "begin" & " SELECT @Result=0 " & " end " & " else " & " begin " & " SELECT @Result=1 " & " end " & " return "
                cmdstore.CommandText = sql
                cmdstore.ExecuteNonQuery()
                For i As Integer = 1 To num + 1
                    If i < 10 Then
                        strCode = (id & "0") & i.ToString()
                    Else
                        strCode = id & i.ToString()
                    End If

                    Dim cmd As New SqlCommand(tmpStoreProcedure, connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim param As SqlParameter = cmd.Parameters.AddWithValue("@id", strCode)
                    param = cmd.Parameters.AddWithValue("@Result", 0)
                    param.Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    Dim retVal As String = Convert.ToString(cmd.Parameters("@Result").Value)
                    If retVal = "0" Then
                        Return (strCode)

                    End If
                Next

            End If
        Finally
            sql = "drop proc " & tmpStoreProcedure
            cmdstore.CommandText = sql
            cmdstore.ExecuteNonQuery()
            clsConnect.CloseConect(connection)

        End Try
        Return ""
    End Function


End Class
