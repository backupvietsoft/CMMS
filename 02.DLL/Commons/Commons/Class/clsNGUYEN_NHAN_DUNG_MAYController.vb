Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsNGUYEN_NHAN_DUNG_MAYController
        Public Sub New()
        End Sub
        Public Function GetNGUYEN_NHAN_DUNG_MAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGUYEN_NHAN_DUNG_MAYs"))
            Return objDataTable
        End Function
        Public Function CheckNGUYEN_NHAN_DUNG_MAY(ByVal MS_NGUYEN_NHAN As Integer, ByVal TEN_NGUYEN_NHAN As String, ByVal LOAI As Integer) As Boolean
            Dim tmp As Boolean = False
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckNGUYEN_NHAN_DUNG_MAY", MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN, LOAI)
            While objReader.Read
                If objReader.Item("TEN_NGUYEN_NHAN").ToString <> "" Then
                    tmp = True
                    Exit While
                End If
            End While
            objReader.Close()
            Return tmp
        End Function
        Public Function AddNGUYEN_NHAN_DUNG_MAY(ByVal TEN_NGUYEN_NHAN As String, ByVal huhong As Integer, ByVal btdk As Integer) As Integer
            Return (CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddNGUYEN_NHAN_DUNG_MAY", TEN_NGUYEN_NHAN, huhong, btdk), Integer))
        End Function

        Public Sub UpdateNGUYEN_NHAN_DUNG_MAY(ByVal MS_NGUYEN_NHAN As Integer, ByVal TEN_NGUYEN_NHAN As String, ByVal huhong As Integer, ByVal btdk As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateNGUYEN_NHAN_DUNG_MAY", MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN, huhong, btdk)
        End Sub

        Public Sub DeleteNGUYEN_NHAN_DUNG_MAY(ByVal MS_NGUYEN_NHAN As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNGUYEN_NHAN_DUNG_MAY", MS_NGUYEN_NHAN)
        End Sub
    End Class
End Namespace
