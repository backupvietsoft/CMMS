Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class MAT_KHAUController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetMAT_KHAU(ByVal CHUC_NANG As String) As String
            Dim MAT_KHAU_VALUE As String = String.Empty
            Dim MAT_KHAU_READER As SqlDataReader
            MAT_KHAU_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAT_KHAU", CHUC_NANG)
            If MAT_KHAU_READER.Read Then
                MAT_KHAU_VALUE = MAT_KHAU_READER.Item("MAT_KHAU")
            End If
            Return MAT_KHAU_VALUE
        End Function
        Public Sub UpdateMAT_KHAU(ByVal objMAT_KHAUInfo As MAT_KHAUInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAT_KHAU", objMAT_KHAUInfo.CHUC_NANG, objMAT_KHAUInfo.MAT_KHAU)
        End Sub
#End Region

    End Class
End Namespace
