Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsChonthongsoGSTTdinhluongController
        Public Sub New()
        End Sub
#Region "định lượng"
        Public Function GetGIA_TRI_DINH_LUONGs(ByVal intMS_TS_GSTT As Integer, ByVal strMS_MAY As String) As DataTable

            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                    "GetGIA_TRI_DINH_LUONGs", intMS_TS_GSTT, strMS_MAY))
            Return objDataTable
        End Function
        Public Function MGetGIA_TRI_DINH_LUONGsDN(ByVal intMS_TS_GSTT As Integer, ByVal strMS_MAY As String, _
                ByVal NgayDL As DateTime) As DataTable

            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                    "MGetGIA_TRI_DINH_LUONGsDN", intMS_TS_GSTT, strMS_MAY, NgayDL))
            Return objDataTable
        End Function
        Public Function GetMS_MAYs_GIA_TRI_TS_GSTT(ByVal intMS_N_XUONG As Integer, ByVal strMS_LOAI_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_MAYs_GIA_TRI_TS_GSTT", intMS_N_XUONG, strMS_LOAI_MAY))
            Return objDataTable
        End Function
        Public Function GetMS_TS_GSTT_MAY_TS_GSTT(ByVal strMS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_TS_GSTT_MAY_TS_GSTT", strMS_MAY))
            Return objDataTable
        End Function
#End Region
#Region "định tính"

        Public Function GetGIA_TRI_DINH_TINHs(ByVal intMS_TS_GSTT As String, ByVal strMS_MAY As String, ByVal strMS_BO_PHAN As String, ByVal STT As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIA_TRI_DINH_TINHs", intMS_TS_GSTT, strMS_MAY, strMS_BO_PHAN, STT))
            Return objDataTable
        End Function
        Public Function GetCAU_TRUC_THIET_BI_TS_GSTT(ByVal strMS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCAU_TRUC_THIET_BI_TS_GSTT", strMS_MAY))
            Return objDataTable
        End Function
        Public Function GetCAU_TRUC_THIET_BI_TS_GSTT_GS(ByVal strMS_MAY As String, ByVal strMS_BO_PHAN As String, ByVal bDenHan As Boolean) As DataTable
            Dim objDataTable As DataTable = New DataTable
            If bDenHan = False Then
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCAU_TRUC_THIET_BI_TS_GSTT_GS", strMS_MAY, strMS_BO_PHAN, 1))
            Else
                Commons.Modules.SQLString = "SELECT DISTINCT CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT, THONG_SO_GSTT.TEN_TS_GSTT " & _
                                       "FROM CAU_TRUC_THIET_BI_TS_GSTT INNER JOIN THONG_SO_GSTT ON CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = THONG_SO_GSTT.MS_TS_GSTT INNER JOIN " & _
                                            "HANG_MUC_DEN_HAN_TMP118" & Commons.Modules.UserName & " ON CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = HANG_MUC_DEN_HAN_TMP118" & Commons.Modules.UserName & ".MS_BO_PHAN AND " & _
                                            "CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = HANG_MUC_DEN_HAN_TMP118" & Commons.Modules.UserName & ".MS_TS_GSTT " & _
                                       "WHERE (CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY = N'" & strMS_MAY & "') AND (CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN = '" & strMS_BO_PHAN & "')"

                '                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCAU_TRUC_THIET_BI_TS_GSTT_GS_DEN_HAN", strMS_MAY, strMS_BO_PHAN))
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
            End If
            Return objDataTable
        End Function
#End Region
    End Class
End Namespace
