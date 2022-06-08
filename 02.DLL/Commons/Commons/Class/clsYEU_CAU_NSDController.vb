Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsYEU_CAU_NSDController

        Public Sub New()
        End Sub
        Public Function getYEU_CAU_NSDs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getYEU_CAU_NSDs"))
            Return objDataTable
        End Function

        Public Function GetNGUOI_YEU_CAUs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGUOI_YEU_CAUs"))
            Return objDataTable
        End Function
        Public Function GetYEU_CAU_NSD(ByVal strNGUOI_YEU_CAU As String, ByVal strTU_NGAY As String, ByVal strDEN_NGAY As String, ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD", strNGUOI_YEU_CAU, strTU_NGAY, strDEN_NGAY, USERNAME, Commons.Modules.TypeLanguage))
            Return objDataTable
        End Function
        Public Function AddYEU_CAU_NSD(ByVal objYEU_CAU_NSDInfo As YEU_CAU_NSDInfo) As Integer
            Return SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddYEU_CAU_NSD", _
               objYEU_CAU_NSDInfo.NGAY, objYEU_CAU_NSDInfo.GIO_YEU_CAU, objYEU_CAU_NSDInfo.NGUOI_YEU_CAU, objYEU_CAU_NSDInfo.HOAN_THANH, _
                    objYEU_CAU_NSDInfo.USER_COMMENT, objYEU_CAU_NSDInfo.REVIEWER_COMMENT, objYEU_CAU_NSDInfo.USER_LAP, _
                    objYEU_CAU_NSDInfo.EMAIL_NSD, objYEU_CAU_NSDInfo.SO_YEU_CAU)
        End Function
        Public Function getSTT_YC_NSD() As Integer
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getSTT_YC_NSD")
            Dim intSTT As Integer = -1
            While objDataReader.Read
                intSTT = objDataReader.Item("STT")
            End While
            Return intSTT
        End Function
        Public Sub UpdateYEU_CAU_NSD(ByVal objYEU_CAU_NSDInfo As YEU_CAU_NSDInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateYEU_CAU_NSD", _
                       objYEU_CAU_NSDInfo.STT, objYEU_CAU_NSDInfo.NGAY, objYEU_CAU_NSDInfo.GIO_YEU_CAU, _
                       objYEU_CAU_NSDInfo.NGUOI_YEU_CAU, objYEU_CAU_NSDInfo.HOAN_THANH, objYEU_CAU_NSDInfo.USER_COMMENT, _
                       objYEU_CAU_NSDInfo.DA_KIEM_TRA, objYEU_CAU_NSDInfo.USERNAME, objYEU_CAU_NSDInfo.REVIEWER_COMMENT, _
                       objYEU_CAU_NSDInfo.USER_LAP, objYEU_CAU_NSDInfo.EMAIL_NSD, objYEU_CAU_NSDInfo.SO_YEU_CAU)
        End Sub
        Public Sub DeleteYEU_CAU_NSD(ByVal intSTT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteYEU_CAU_NSD", intSTT)
        End Sub
        
    End Class
End Namespace
