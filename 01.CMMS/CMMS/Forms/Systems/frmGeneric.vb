Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmGeneric
    Private _connection As SqlConnection

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        If BeginConnection() Then
            Me.txtServerName.ReadOnly = True
            Me.txtUsername.ReadOnly = True
            Me.txtPassword.ReadOnly = True
            Me.txtDatabaseName.ReadOnly = True
            Me.txtNamespace.ReadOnly = False
            Me.cmdGeneric.Enabled = True
            Me.cmdConnect.Enabled = False
        End If
    End Sub

    Private Sub cmdGeneric_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGeneric.Click
        If BeginConnection() Then
            Dim command As SqlCommand = _connection.CreateCommand
            command.CommandText = "select name from sysobjects where type='u'"
            Dim reader As SqlDataReader = command.ExecuteReader
            Dim hasTables As Hashtable = New Hashtable
            Dim counter As Integer = 0
            While reader.Read
                Dim temp As String = reader.Item(0).ToString
                hasTables.Add(counter, temp)
                counter = counter + 1
            End While
            reader.Close()
            For i As Integer = 0 To hasTables.Count - 1
                Dim temp As String = hasTables.Item(i).ToString
                Dim adapter As SqlDataAdapter = New SqlDataAdapter("select * from [" & temp & "]", _connection)
                Dim ds As DataSet = New DataSet
                adapter.Fill(ds, temp)
                Dim content As String = ""
                Dim propertyContent As String = ""
                content = "Public Class " & temp & "Info" & Microsoft.VisualBasic.ChrW(13).ToString
                For Each column As DataColumn In ds.Tables(temp).Columns
                    Dim dataType As String = GetDataType(column.DataType.ToString)
                    Dim variable As String = column.ColumnName
                    content += "    Private _" & variable & " As " & dataType
                    content += Microsoft.VisualBasic.ChrW(13).ToString
                    propertyContent += "    Public Property " & column.ColumnName & "() As " & dataType
                    propertyContent += Microsoft.VisualBasic.ChrW(13).ToString
                    propertyContent += "        Get"
                    propertyContent += Microsoft.VisualBasic.ChrW(13).ToString
                    propertyContent += "            return _" & variable
                    propertyContent += Microsoft.VisualBasic.ChrW(13).ToString
                    propertyContent += "        End Get"
                    propertyContent += Microsoft.VisualBasic.ChrW(13).ToString
                    propertyContent += "        Set(Byval value As " & dataType & ")"
                    propertyContent += Microsoft.VisualBasic.ChrW(13).ToString
                    propertyContent += "            _" & variable & " = value"
                    propertyContent += Microsoft.VisualBasic.ChrW(13).ToString
                    propertyContent += "        End Set"
                    propertyContent += Microsoft.VisualBasic.ChrW(13).ToString
                    propertyContent += "    End Property"
                    propertyContent += Microsoft.VisualBasic.ChrW(13).ToString
                Next
                propertyContent += "End Class"
                If Me.txtNamespace.Text <> "" Then
                    content = "Namespace " & Me.txtNamespace.Text & Microsoft.VisualBasic.ChrW(13).ToString & content
                    propertyContent = propertyContent & Microsoft.VisualBasic.ChrW(13).ToString & "End Namespace"
                End If
                Dim write As TextWriter = New StreamWriter("Classes/" & temp & ".vb")
                write.Write(content + propertyContent)
                write.Close()
            Next
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Function BeginConnection() As Boolean
        Try
            _connection = New SqlConnection(ConnectionString)
            _connection.Open()
            Return True
        Catch ex As Exception
            XtraMessageBox.Show("Connection Server error")
            Return False
        End Try
    End Function

    Private Function ConnectionString() As String
        Dim strConnection As String = ""
        strConnection += "server=" & Me.txtServerName.Text & ";"
        strConnection += "database=" & Me.txtDatabaseName.Text & ";"
        strConnection += "uid=" & Me.txtUsername.Text & ";"
        strConnection += "pwd=" & Me.txtPassword.Text
        Return strConnection
    End Function
    Function GetDataType(ByVal type As String) As String
        Select Case type
            Case "System.String"
                Return "String"
            Case "System.Int16"
                Return "Integer"
            Case "System.Int32"
                Return "Integer"
            Case "System.Int64"
                Return "Long"
            Case "System.DateTime"
                Return "DateTime"
            Case "System.Double"
                Return "Double"
            Case "System.Boolean"
                Return "Boolean"
            Case "System.Long"
                Return "Long"
            Case "System.Single"
                Return "Single"
            Case "System.Decimal"
                Return "Decimal"
        End Select
        Return ""
    End Function

    Private Sub frmGeneric_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
