Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data



Namespace VS.Classes.Admin
    Public Class USER_LOAI_CONG_VIECController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetUSER_LOAI_CVs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSER_LOAI_CVs"))
            Return objDataTable
        End Function

        Public Function AddUSER_LOAI_CV(ByVal objUSER_LOAI_CVInfo As USER_LOAI_CONG_VIECInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddUSER_LOAI_CV", _
                objUSER_LOAI_CVInfo.MS_LOAI_CV, objUSER_LOAI_CVInfo.USERNAME)
            Return objUSER_LOAI_CVInfo.USERNAME
        End Function

        Public Sub UpdateUSER_LOAI_CV(ByVal objUSER_LOAI_CVInfo As USER_LOAI_CONG_VIECInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateUSER_LOAI_CV", _
                 objUSER_LOAI_CVInfo.MS_LOAI_CV, objUSER_LOAI_CVInfo.USERNAME)
        End Sub

        Public Sub DeleteUSER_LOAI_CV(ByVal User As String, ByVal MsLoaiCV As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteUSER_LOAI_CV", MsLoaiCV, User)
        End Sub

        Public Function PermisionLOAI_CV(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_CV", User))
            Return objDataTable
        End Function

        Public Function ProhibitLOAI_CV(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "ProhibitLOAI_CV", User))
            Return objDataTable
        End Function
#End Region

    End Class
End Namespace

