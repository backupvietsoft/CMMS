Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class THONG_SO_BO_PHANController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetTHONG_SO_BO_PHAN(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetTHONG_SO_BO_PHAN", MS_MAY))
            Return objDataTable
        End Function
        Public Function AddTHONG_SO_BO_PHAN(ByVal Sqltran As SqlTransaction, ByVal objTHONG_SO_BO_PHANInfo As THONG_SO_BO_PHANInfo) As String
            SqlHelper.ExecuteScalar(Sqltran, "AddTHONG_SO_BO_PHAN", _
                objTHONG_SO_BO_PHANInfo.MS_MAY, objTHONG_SO_BO_PHANInfo.MS_BO_PHAN, objTHONG_SO_BO_PHANInfo.STT, objTHONG_SO_BO_PHANInfo.TEN_THONG_SO, objTHONG_SO_BO_PHANInfo.GIA_TRI_THONG_SO)
            Return True
        End Function

#End Region
    End Class
End Namespace
