Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data



Namespace VS.Classes.Admin
    Public Class USER_LOAI_PHU_TUNGController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetUSER_LOAI_PTs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSER_LOAI_PTs"))
            Return objDataTable
        End Function

        Public Function AddUSER_LOAI_PT(ByVal objUSER_LOAI_PTInfo As USER_LOAI_PHU_TUNGInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddUSER_LOAI_PT", _
                objUSER_LOAI_PTInfo.MS_LOAI_PT, objUSER_LOAI_PTInfo.USERNAME)
            Return objUSER_LOAI_PTInfo.USERNAME
        End Function

        Public Sub UpdateUSER_LOAI_PT(ByVal objUSER_LOAI_PTInfo As USER_LOAI_PHU_TUNGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateUSER_LOAI_PT", _
                 objUSER_LOAI_PTInfo.MS_LOAI_PT, objUSER_LOAI_PTInfo.USERNAME)
        End Sub

        Public Sub DeleteUSER_LOAI_PT(ByVal User As String, ByVal MsLoaiPT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteUSER_LOAI_PT", MsLoaiPT, User)
        End Sub

        Public Function PermisionLOAI_PT(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_PT", User))
            Return objDataTable
        End Function

        Public Function ProhibitLOAI_PT(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "ProhibitLOAI_PT", User))
            Return objDataTable
        End Function
#End Region

    End Class
End Namespace

