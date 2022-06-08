Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class NHA_XUONGController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetNHA_XUONGs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNha_Xuongs"))
            Return objDataTable
        End Function

        Public Function GetNHA_XUONG(ByVal ID As String) As NHA_XUONGInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNha_Xuong", ID)
            Dim objNHA_XUONGInfo As New NHA_XUONGInfo
            While objDataReader.Read
                objNHA_XUONGInfo.DIA_CHI = objDataReader.Item("DIA_CHI").ToString()
                objNHA_XUONGInfo.DIEN_TICH = objDataReader.Item("DIEN_TICH")
                objNHA_XUONGInfo.GHI_CHU = objDataReader.Item("GHI_CHU").ToString()
                objNHA_XUONGInfo.KHOANG_CACH = objDataReader.Item("KHOANG_CACH")
                objNHA_XUONGInfo.MS_N_XUONG = objDataReader.Item("MS_N_XUONG")
                objNHA_XUONGInfo.Ten_N_XUONG = objDataReader.Item("Ten_N_XUONG")
                objNHA_XUONGInfo.DON_VI = objDataReader.Item("MS_DON_VI").ToString()
            End While
            objDataReader.Close()
            Return objNHA_XUONGInfo
        End Function

        Public Function GetNHA_XUONG_Ten_N_XUONG(ByVal TenNX As String, Optional ByVal MsNX As String = "") As NHA_XUONGInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHA_XUONG_Ten_N_XUONG", TenNX, MsNX)
            Dim objNHA_XUONGInfo As New NHA_XUONGInfo
            While objDataReader.Read
                objNHA_XUONGInfo.DIA_CHI = objDataReader.Item("DIA_CHI")
                objNHA_XUONGInfo.DIEN_TICH = objDataReader.Item("DIEN_TICH")
                objNHA_XUONGInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
                objNHA_XUONGInfo.KHOANG_CACH = objDataReader.Item("KHOANG_CACH")
                objNHA_XUONGInfo.MS_N_XUONG = objDataReader.Item("MS_N_XUONG")
                objNHA_XUONGInfo.Ten_N_XUONG = objDataReader.Item("Ten_N_XUONG")
                objNHA_XUONGInfo.DON_VI = objDataReader.Item("MS_DON_VI")
            End While
            objDataReader.Close()
            Return objNHA_XUONGInfo
        End Function

        Public Function AddNHA_XUONG(ByVal objNHA_XUONGInfo As NHA_XUONGInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddNha_Xuong", _
                objNHA_XUONGInfo.MS_N_XUONG, objNHA_XUONGInfo.Ten_N_XUONG, objNHA_XUONGInfo.DIA_CHI, _
                objNHA_XUONGInfo.DIEN_TICH, objNHA_XUONGInfo.KHOANG_CACH, objNHA_XUONGInfo.GHI_CHU, objNHA_XUONGInfo.DON_VI)
            Return objNHA_XUONGInfo.MS_N_XUONG
        End Function

        Public Sub UpdateNHA_XUONG(ByVal objNHA_XUONGInfo As NHA_XUONGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateNha_Xuong", _
                objNHA_XUONGInfo.MS_N_XUONG, objNHA_XUONGInfo.Ten_N_XUONG, objNHA_XUONGInfo.DIA_CHI, _
                objNHA_XUONGInfo.DIEN_TICH, objNHA_XUONGInfo.KHOANG_CACH, objNHA_XUONGInfo.GHI_CHU, objNHA_XUONGInfo.DON_VI)
        End Sub

        Public Sub DeleteNHA_XUONG(ByVal MS_N_XUONG As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNha_Xuong", MS_N_XUONG)
        End Sub

        Public Function PermisionNHA_XUONG(ByVal User As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionNHA_XUONG"), User)
            Return objDataTable
        End Function
        Public Function CheckTEN_N_XUONG(ByVal TEN_N_XUONG As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_N_XUONG", TEN_N_XUONG)
        End Function
        Public Function CheckNHA_XUONG(ByVal MS_N_XUONG As String, ByVal TEN_N_XUONG As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckNHA_XUONG", MS_N_XUONG, TEN_N_XUONG)
        End Function

        Public Sub DeleteNHOM_NHA_XUONG_1(ByVal MS_N_XUONG As String, ByVal USERNAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNHOM_NHA_XUONG_1", MS_N_XUONG, USERNAME)
        End Sub
#End Region

#Region "Relatives"
        Public Function CheckUsedMAY_NHA_XUONG(ByVal MSNX As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedMAY_NHA_XUONG", MSNX))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedUSER_NHA_XUONG(ByVal MSNX As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedUSER_NHA_XUONG", MSNX))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
#End Region
    End Class
End Namespace
