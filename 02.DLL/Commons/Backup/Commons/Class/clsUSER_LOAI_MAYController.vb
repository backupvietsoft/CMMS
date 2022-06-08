Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data



Namespace VS.Classes.Admin
    Public Class USER_LOAI_MAYController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetUSER_LOAI_MAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSER_LOAI_MAYs"))
            Return objDataTable
        End Function

        Public Function AddUSER_LOAI_MAY(ByVal objUSER_LOAI_MAYInfo As USER_LOAI_MAYInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddUSER_LOAI_MAY", _
                objUSER_LOAI_MAYInfo.MS_LOAI_MAY, objUSER_LOAI_MAYInfo.USERNAME)
            Return objUSER_LOAI_MAYInfo.USERNAME
        End Function

        Public Sub UpdateUSER_LOAI_MAY(ByVal objUSER_LOAI_MAYInfo As USER_LOAI_MAYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateUSER_LOAI_MAY", _
                 objUSER_LOAI_MAYInfo.MS_LOAI_MAY, objUSER_LOAI_MAYInfo.USERNAME)
        End Sub

        Public Sub DeleteUSER_LOAI_MAY(ByVal User As String, ByVal MsLoaiMay As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteUSER_LOAI_MAY", MsLoaiMay, User)
        End Sub

        Public Function PermisionLOAI_MAY(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_MAY", User))
            Return objDataTable
        End Function

        Public Function ProhibitLOAI_MAY(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "ProhibitLOAI_MAY", User))
            Return objDataTable
        End Function
#End Region

    End Class
End Namespace

