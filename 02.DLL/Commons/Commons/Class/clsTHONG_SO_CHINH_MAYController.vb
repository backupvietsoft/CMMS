Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class THONG_SO_CHINH_MAYController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetTHONG_SO_CHINH_MAYs(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_CHINH_MAYs", MS_MAY))
            Return objDataTable
        End Function
        Public Function GetTHONG_SO_CHINH_MAYsSC(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetTHONG_SO_CHINH_MAYs", MS_MAY))
            Return objDataTable
        End Function
        Public Function AddTHONG_SO_CHINH_MAY(ByVal objTSMAYInfo As THONG_SO_CHINH_MAYInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTHONG_SO_CHINH_MAY", _
                objTSMAYInfo.MS_MAY, objTSMAYInfo.MS_THONG_SO_MAY, objTSMAYInfo.GIA_TRI, objTSMAYInfo.GHI_CHU, objTSMAYInfo.GIA_TRI_MIN, objTSMAYInfo.GIA_TRI_MAX)
            Return True
        End Function
        Public Function AddTHONG_SO_CHINH_MAYSC(ByVal Sqltran As SqlTransaction, ByVal objTSMAYInfo As THONG_SO_CHINH_MAYInfo) As String
            SqlHelper.ExecuteScalar(Sqltran, "AddTHONG_SO_CHINH_MAY", _
                objTSMAYInfo.MS_MAY, objTSMAYInfo.MS_THONG_SO_MAY, objTSMAYInfo.GIA_TRI, objTSMAYInfo.GHI_CHU, objTSMAYInfo.GIA_TRI_MIN, objTSMAYInfo.GIA_TRI_MAX)
            Return True
        End Function
        Public Function UpdateTHONG_SO_CHINH_MAY(ByVal objTSMAYInfo As THONG_SO_CHINH_MAYInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTHONG_SO_CHINH_MAY", _
                objTSMAYInfo.MS_MAY, objTSMAYInfo.MS_THONG_SO_MAY, objTSMAYInfo.GIA_TRI, objTSMAYInfo.GHI_CHU)
            Return True
        End Function

        Public Sub DeleteTHONG_SO_CHINH_MAY(ByVal MS_MAY As String, ByVal MS_THONG_SO_MAY As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTHONG_SO_CHINH_MAY", MS_MAY, MS_THONG_SO_MAY)
        End Sub
#End Region

    End Class
End Namespace

