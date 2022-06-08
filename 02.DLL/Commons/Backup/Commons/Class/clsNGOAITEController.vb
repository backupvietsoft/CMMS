Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class NGOAI_TEController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetNGOAI_TEs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGOAI_TE"))
            Return objDataTable
        End Function

        Public Function GetNGOAI_TE(ByVal ID As Integer) As NGOAI_TEInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGOAI_TE", ID)
            Dim objNGOAI_TEInfo As New NGOAI_TEInfo
            While objDataReader.Read
                objNGOAI_TEInfo.NGOAI_TE = objDataReader.Item("NGOAI_TE")
                objNGOAI_TEInfo.TEN_NGOAI_TE = objDataReader.Item("TEN_NGOAI_TE")
                objNGOAI_TEInfo.MAC_DINH = objDataReader.Item("MAC_DINH")

            End While
            objDataReader.Close()
            Return objNGOAI_TEInfo
        End Function

        Public Function AddNGOAI_TE(ByVal objNGOAI_TEInfo As NGOAI_TEInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddNGOAI_TE", _
                objNGOAI_TEInfo.NGOAI_TE, objNGOAI_TEInfo.TEN_NGOAI_TE, objNGOAI_TEInfo.MAC_DINH)
            Return True
        End Function

        Public Sub UpdateNGOAI_TE(ByVal objNGOAI_TEInfo As NGOAI_TEInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateNGOAI_TE", _
                objNGOAI_TEInfo.NGOAI_TE, objNGOAI_TEInfo.TEN_NGOAI_TE, objNGOAI_TEInfo.MAC_DINH, objNGOAI_TEInfo.NGOAI_TE_TMP)
        End Sub

        Public Sub DeleteNGOAI_TE(ByVal NGOAI_TE As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNGOAI_TE", NGOAI_TE)
        End Sub
        Public Function CheckTEN_NGOAI_TE(ByVal TEN_NGOAI_TE As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_NGOAI_TE", TEN_NGOAI_TE)
        End Function
        Public Function CheckNGOAI_TE(ByVal NGOAI_TE As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckNGOAI_TE", NGOAI_TE)
        End Function
        Public Function CheckMAC_DINH() As Integer
            Dim VALUE_READER As SqlDataReader
            Dim DEFAULT_VALUE As Integer
            VALUE_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckMAC_DINH")
            If VALUE_READER.Read Then
                DEFAULT_VALUE = VALUE_READER.Item(0)
            End If
            VALUE_READER.Close()
            Return DEFAULT_VALUE
        End Function

        Public Function Check_UsedIC_CHI_TIET_DH_NHAP_PT(ByVal NGOAI_TE As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedIC_CHI_TIET_DH_NHAP_PT", NGOAI_TE))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function Check_UsedEOR_SERVICE_CHUNG(ByVal NGOAI_TE As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_UsedEOR_SERVICE_CHUNG", NGOAI_TE))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function Check_UsedEOR_SERVICE_MNR(ByVal NGOAI_TE As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_UsedEOR_SERVICE_MNR", NGOAI_TE))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function Check_UsedKINH_PHI_NAM(ByVal NGOAI_TE As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_UsedKINH_PHI_NAM", NGOAI_TE))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function Check_UsedLUONG_CO_BAN(ByVal NGOAI_TE As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_UsedLUONG_CO_BAN", NGOAI_TE))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function Check_UsedMAY(ByVal NGOAI_TE As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_UsedMAY", NGOAI_TE))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function Check_UsedTI_GIA_NT(ByVal NGOAI_TE As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_UsedTI_GIA_NT", NGOAI_TE))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
#End Region
    End Class
End Namespace
