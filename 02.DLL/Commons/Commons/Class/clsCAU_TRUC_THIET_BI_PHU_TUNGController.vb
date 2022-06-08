Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class CAU_TRUC_THIET_BI_PHU_TUNGController
        Public Sub New()

        End Sub

#Region "public method "
        Public Function GetCAU_TRUC_THIET_BI_PHU_TUNG(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetCAU_TRUC_THIET_BI_PHU_TUNG", MS_MAY))
            Return objDataTable
        End Function
        Public Function AddCAU_TRUC_THIET_BI_PHU_TUNG(ByVal Sqltran As SqlTransaction, ByVal objCAU_TRUC_THIET_BI_PTInfo As CAU_TRUC_THIET_BI_PHU_TUNGInfo) As String
            'Try

            If IsDBNull(objCAU_TRUC_THIET_BI_PTInfo.MS_PT) Or objCAU_TRUC_THIET_BI_PTInfo.MS_PT = "" Then
                Return False
            End If
            SqlHelper.ExecuteScalar(Sqltran, "AddCAU_TRUC_THIET_BI_PHU_TUNG", _
                objCAU_TRUC_THIET_BI_PTInfo.MS_MAY, objCAU_TRUC_THIET_BI_PTInfo.MS_BO_PHAN, objCAU_TRUC_THIET_BI_PTInfo.MS_PT, _
                objCAU_TRUC_THIET_BI_PTInfo.MS_VI_TRI_PT, objCAU_TRUC_THIET_BI_PTInfo.SO_LUONG, _
                objCAU_TRUC_THIET_BI_PTInfo.ACTIVE, objCAU_TRUC_THIET_BI_PTInfo.CHUC_NANG)
            Return True
            'Catch ex As Exception

            'End Try

        End Function

#End Region
    End Class
End Namespace

