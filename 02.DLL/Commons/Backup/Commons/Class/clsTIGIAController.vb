Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class TI_GIAController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetTI_GIA_NTs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA_NTs"))
            Return objDataTable
        End Function

        Public Function GetTI_GIA_NT_LOC_NGAY(ByVal NGAY As Integer, ByVal THANG As Integer, ByVal NAM As Integer) As DataTable
            Dim QUERY As String = "SELECT NGAY,TI_GIA_NT.NGOAI_TE,TEN_NGOAI_TE,TI_GIA,NGAY_NHAP,TI_GIA_USD FROM TI_GIA_NT INNER JOIN NGOAI_TE ON TI_GIA_NT.NGOAI_TE=NGOAI_TE.NGOAI_TE WHERE DAY(NGAY)='" & NGAY & "'" & " AND MONTH(NGAY)='" & THANG & "' AND YEAR(NGAY)='" & NAM & "'"
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY))
            Return objDataTable
        End Function


        Public Function Get_TI_GIA_NT_NGAY_CUOI() As String
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_TI_GIA_NT_NGAY_CUOI")
            Dim tmp As String = ""
            While objDataReader.Read
                If Not IsDBNull(objDataReader.Item("NGAY")) Then
                    tmp = objDataReader.Item("NGAY")
                End If
            End While
            objDataReader.Close()
            Return tmp
        End Function
        Public Function GetTI_GIA_NT(ByVal ID As Integer) As TI_GIAInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA_NT", ID)
            Dim objTI_GIAInfo As New TI_GIAInfo
            While objDataReader.Read
                objTI_GIAInfo.NGAY = objDataReader.Item("NGAY")
                objTI_GIAInfo.NGOAI_TE = objDataReader.Item("NGOAI_TE")
                objTI_GIAInfo.TI_GIA = objDataReader.Item("TI_GIA")
                objTI_GIAInfo.NGAY_NHAP = objDataReader.Item("NGAY_NHAP")
            End While
            objDataReader.Close()
            Return objTI_GIAInfo
        End Function

        Public Function AddTI_GIA_NT(ByVal objTI_GIAInfo As TI_GIAInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTI_GIA_NT", _
                objTI_GIAInfo.NGAY, objTI_GIAInfo.NGOAI_TE, objTI_GIAInfo.TI_GIA, objTI_GIAInfo.NGAY_NHAP)
            Return True
        End Function

        Public Function AddTI_GIA_NT_MOI(ByVal objTI_GIAInfo As TI_GIAInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTI_GIA_NT_MOI", _
                objTI_GIAInfo.NGAY, objTI_GIAInfo.NGOAI_TE, objTI_GIAInfo.TI_GIA, objTI_GIAInfo.NGAY_NHAP)
            Return True
        End Function

        Public Sub UpdateTI_GIA_NT(ByVal objTI_GIAInfo As TI_GIAInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTI_GIA_NT", _
                objTI_GIAInfo.NGAY, objTI_GIAInfo.NGOAI_TE, objTI_GIAInfo.TI_GIA, objTI_GIAInfo.NGAY_NHAP, objTI_GIAInfo.NGAY, objTI_GIAInfo.NGOAI_TE)
        End Sub

        Public Sub DeleteTI_GIA_NT(ByVal NGAY As Date, ByVal NGOAI_TE As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTI_GIA_NT", NGAY, NGOAI_TE)
        End Sub

#End Region
    End Class
End Namespace
