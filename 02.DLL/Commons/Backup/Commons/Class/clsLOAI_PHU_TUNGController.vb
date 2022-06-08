Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class LOAI_PHU_TUNGController
        Public Function GetLOAI_PHU_TUNGs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_PHU_TUNGs"))
            Return objDataTable
        End Function

        Public Function GetLOAI_PHU_TUNG(ByVal MS_LOAI_PT As Integer, ByVal userdn As String) As LOAI_PHU_TUNGInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_PHU_TUNG", MS_LOAI_PT, userdn)
            Dim objLOAI_PHU_TUNGInfo As New LOAI_PHU_TUNGInfo
            While objDataReader.Read
                objLOAI_PHU_TUNGInfo.MS_LOAI_PT = objDataReader.Item("MS_LOAI_PT")
                objLOAI_PHU_TUNGInfo.TEN_LOAI_PT = objDataReader.Item("TEN_LOAI_PT")
                objLOAI_PHU_TUNGInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
            End While
            objDataReader.Close()
            Return objLOAI_PHU_TUNGInfo
        End Function

        Public Function AddLOAI_PHU_TUNG(ByVal objLOAI_PHU_TUNGInfo As LOAI_PHU_TUNGInfo) As Integer
            Return CInt(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddLOAI_PHU_TUNG", objLOAI_PHU_TUNGInfo.TEN_LOAI_PT, objLOAI_PHU_TUNGInfo.GHI_CHU))

        End Function

        Public Sub UpdateLOAI_PHU_TUNG(ByVal objLOAI_PHU_TUNGInfo As LOAI_PHU_TUNGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLOAI_PHU_TUNG", _
                objLOAI_PHU_TUNGInfo.MS_LOAI_PT, objLOAI_PHU_TUNGInfo.TEN_LOAI_PT, objLOAI_PHU_TUNGInfo.GHI_CHU)
        End Sub
        Public Sub InsertLOAI_PHU_TUNG_LOG(ByVal ID As Integer, ByVal FORMNAME As String, ByVal USERSIGN As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLOAI_PHU_TUNG_LOG", ID, FORMNAME, USERSIGN, THAO_TAC)
        End Sub
        Public Function DeleteLOAI_PHU_TUNG(ByVal MS_LOAI_PT As Integer) As Boolean
            Try
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteLOAI_PHU_TUNG", MS_LOAI_PT)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function CheckTEN_LOAI_PT(ByVal TEN_LOAI_PT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_LOAI_PT", TEN_LOAI_PT)
        End Function

        Public Function CheckLOAI_PHU_TUNG(ByVal MS_LOAI_PT As Integer, ByVal TEN_LOAI_PT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckLOAI_PHU_TUNG", MS_LOAI_PT, TEN_LOAI_PT)
        End Function

        Public Function CheckExistLOAI_PHU_TUNG(ByVal TEN_LOAI_PT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistLOAI_PHU_TUNG", TEN_LOAI_PT)
        End Function
        Public Sub DeleteNHOM_LOAI_PHU_TUNG_1(ByVal MS_LOAI_PT As Integer, ByVal USERNAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNHOM_LOAI_PHU_TUNG_1", MS_LOAI_PT, USERNAME)
        End Sub
#Region "Relatives"
        Public Function CheckUsedLOAI_PHU_TUNG_IC_PHU_TUNG(ByVal MS_LOAI_PT As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedLOAI_PHU_TUNG_IC_PHU_TUNG", MS_LOAI_PT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedUSER_LOAI_PHU_TUNG(ByVal MS_LOAI_PT As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedUSER_LOAI_PHU_TUNG", MS_LOAI_PT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
#End Region
    End Class
End Namespace

