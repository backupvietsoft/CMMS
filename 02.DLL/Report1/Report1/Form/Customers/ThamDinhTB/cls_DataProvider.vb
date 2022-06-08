Imports System.Data
Imports System.Data.SqlClient


Public Class cls_DataProvider
    Public myConnect As New SqlConnection
    Public myCommand As New SqlCommand
    Public myDataAdapter As New SqlDataAdapter
    Public Shared ketNoi As String

    ' Thực hiện kết nối tới csdl
    '
    Public Function Connect() As Boolean
        myConnect = New SqlConnection
        Try
            ' myCommons.IConnections.ConnectionString = "Initial Catalog= CMMS_DUY_TAN ; Data Source= YEN; uid = sa; pwd =10366173 ;"
            ' myCommons.IConnections.ConnectionString = "Initial Catalog= CMMS_DUY_TAN ; Data Source= YEN; uid = sa; pwd =10366173 ;"
            'myCommons.IConnections.ConnectionString = " Server = dung; uid = sa; pwd ="" ;Database = CMMS_DUNG "
            'protected static string _connectionString = ("Data Source=172.29.64.72;Initial Catalog=Lab52_ws16;User ID=Lab52_ws16");
            If (ketNoi = Nothing) Then
                ketNoi = "Initial Catalog= CMMS_DUNG ;Data Source=localhost;Integrated Security=SSPI;"
            End If
            myConnect.ConnectionString = ketNoi
            myConnect.Open()
            Return True
        Catch ex As Exception
            MessageBox.Show("Loi ket noi")
        End Try
        Return False

    End Function
    Public Function DisConnect() As Boolean
        Try
            myConnect.Close()
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function
    Public Function executeQuery(ByVal SQLString As String) As SqlDataReader
        Connect()
        myCommand = New SqlCommand(SQLString, myConnect)

        Try
            Dim myReader As SqlDataReader
            myReader = myCommand.ExecuteReader()
            Return myReader
        Catch ex As Exception
            Return Nothing
        End Try
        DisConnect()
    End Function
    Public Function OpentDataSet(ByVal SQLString As String) As DataSet
        Connect()
        Dim da As New SqlDataAdapter(SQLString, myConnect)
        Dim ds As New DataSet
        ds.Clear()
        da.Fill(ds)
        DisConnect()
        Return ds
    End Function
    Public Function OpentDataTable(ByVal SQLString As String) As DataTable
        Connect()
        Dim da As New SqlDataAdapter(SQLString, myConnect)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        DisConnect()
        Return dt
    End Function
    Public Function executeScalar(ByVal SQLString As String) As Object
        Connect()
        myCommand = New SqlCommand(SQLString, myConnect)
        Dim obj As Object
        obj = myCommand.ExecuteScalar()
        DisConnect()
        Return obj
    End Function
    Public Sub executeNonQuery(ByVal SQLString As String)
        Connect()
        myCommand = New SqlCommand(SQLString, myConnect)
        myCommand.ExecuteNonQuery()
        DisConnect()
    End Sub

    Public Sub Update_Table(ByVal ds As DataSet)
        Connect()
        Dim da As New SqlDataAdapter("Select * From MAY", myConnect)
        Dim cb As SqlCommandBuilder
        cb = New SqlCommandBuilder(da)
        da.Update(ds.Tables(0))
        DisConnect()
    End Sub
    Public Sub temp(ByVal ds As DataSet)

        Dim sql As SqlTransaction = myConnect.BeginTransaction()
        myCommand.Transaction = sql
        Try
            '//
            'add code
            For i As Integer = 0 To 10

            Next
            ' //
            sql.Commit()
        Catch ex As Exception
            sql.Rollback()

        End Try
    End Sub
    Public Function Update(ByVal ICollection As Collection, ByVal sql As String) As Boolean
        Connect()
        Dim tran As SqlTransaction
        tran = myConnect.BeginTransaction()
        Dim count As Integer
        count = ICollection.Count
        Dim command As SqlCommand
        Try
            ' Xoa du lieu
            command = New SqlCommand(sql, myConnect, tran)
            command.ExecuteNonQuery()
            'Them du lieu
            For i As Integer = 1 To count
                command = New SqlCommand(ICollection.Item(i).ToString, myConnect, tran)
                command.ExecuteNonQuery()
            Next
            tran.Commit()
            'MessageBox.Show("Thêm/Sửa thành công")
            Return True
        Catch ex As Exception
            tran.Rollback()
            MessageBox.Show("Thêm không thành công ! Khóa bị trùng. Vui lòng kiểm tra lại dữ liệu", "Thêm lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

End Class
