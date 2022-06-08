Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class KINH_PHI_NAMController
        Dim sda As SqlDataAdapter
        Dim scb As SqlCommandBuilder
        Dim scmd As SqlCommand


        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetKINH_PHI_NAM(ByVal MS_BP_CHIU_PHI As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKINH_PHI_NAM", MS_BP_CHIU_PHI))
            'Xét cột khóa chính cho bảng
            Dim PrimaryKeyColumns(1) As DataColumn
            PrimaryKeyColumns(0) = objDataTable.Columns("MS_BP_CHIU_PHI")
            PrimaryKeyColumns(1) = objDataTable.Columns("NAM")
            objDataTable.PrimaryKey = PrimaryKeyColumns
            Return objDataTable
        End Function

        Public Function GetKINH_PHI_NAM_CS(ByVal MS_BP_CHIU_PHI As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKINH_PHI_NAM_CS", MS_BP_CHIU_PHI))
            'Xét cột khóa chính cho bảng
            Dim PrimaryKeyColumns(3) As DataColumn
            PrimaryKeyColumns(0) = objDataTable.Columns("MS_BP_CHIU_PHI")
            PrimaryKeyColumns(1) = objDataTable.Columns("THANG")
            PrimaryKeyColumns(2) = objDataTable.Columns("MS_LOAI_CP")
            objDataTable.PrimaryKey = PrimaryKeyColumns
            Return objDataTable
        End Function


        Public Function AddKINH_PHI_NAM(ByVal objKINH_PHI_NAMInfo As KINH_PHI_NAMInfo) As Integer
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddKINH_PHI_NAM", objKINH_PHI_NAMInfo.MS_BP_CHIU_PHI, objKINH_PHI_NAMInfo.NAM, objKINH_PHI_NAMInfo.SO_TIEN, objKINH_PHI_NAMInfo.NGOAI_TE, objKINH_PHI_NAMInfo.TY_GIA, objKINH_PHI_NAMInfo.THANH_TIEN)
            Return True
        End Function
        Public Function AddKINH_PHI_NAM_CS(ByVal objKINH_PHI_NAMInfo As KINH_PHI_NAMInfo) As Integer
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddKINH_PHI_NAM_CS", objKINH_PHI_NAMInfo.MS_BP_CHIU_PHI, objKINH_PHI_NAMInfo.THANG, objKINH_PHI_NAMInfo.MS_LOAI_CP, objKINH_PHI_NAMInfo.SO_TIEN, objKINH_PHI_NAMInfo.NGOAI_TE, objKINH_PHI_NAMInfo.TY_GIA, objKINH_PHI_NAMInfo.TY_GIA_USD)
            Return True
        End Function
        Public Function GetADDED_MS_BP_CHIU_PHI() As Integer
            Dim MAX_MS_BP_CHIU_PHI As Integer
            Dim READER_BP_CP As SqlDataReader
            Dim QUERY As String = "SELECT MAX(MS_BP_CHIU_PHI) FROM BO_PHAN_CHIU_PHI"
            READER_BP_CP = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
            If READER_BP_CP.Read Then
                MAX_MS_BP_CHIU_PHI = READER_BP_CP.Item(0)
            End If
            READER_BP_CP.Close()
            Return MAX_MS_BP_CHIU_PHI
        End Function


        'Public Sub UpdateKINH_PHI_NAM(ByVal objKINH_PHI_NAMInfo As KINH_PHI_NAMInfo)
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKINH_PHI_NAM", objKINH_PHI_NAMInfo.MS_BP_CHIU_PHI, objKINH_PHI_NAMInfo.NAM, objKINH_PHI_NAMInfo.SO_TIEN, objKINH_PHI_NAMInfo.NGOAI_TE, objKINH_PHI_NAMInfo.TY_GIA)
        'End Sub

        'Public Sub UpdateData(ByVal dt As DataTable, ByVal MS_BP_CHIU_PHI As Integer)

        '    Try
        '        If (dt.HasErrors) Then
        '            If (Reconcile(dt)) Then
        '                ' Fixed all errors.
        '                dt.AcceptChanges()
        '            Else
        '                ' Couldn'table fix all errors.
        '                dt.RejectChanges()
        '            End If
        '        Else
        '            ' If no errors, AcceptChanges.
        '            'dt.AcceptChanges()
        '        End If
        '        If sda Is Nothing Then
        '            GetKINH_PHI_NAM(MS_BP_CHIU_PHI)
        '        End If

        '        sda.Update(dt)
        '    Catch ex As Exception
        '        MsgBox(ex.ToString)
        '    End Try
        'End Sub

        'Private Function Reconcile(ByVal thisTable As DataTable) As Boolean
        '    Dim row As DataRow
        '    For Each row In thisTable.Rows
        '        'Insert code to try to reconcile error.

        '        ' If there are still errors return immediately
        '        ' since the caller rejects all changes upon error.
        '        If row.HasErrors Then
        '            Reconcile = False
        '            Exit Function
        '        End If
        '    Next row
        '    Reconcile = True
        'End Function

        Public Sub DeleteKINH_PHI_NAM(ByVal MS_BP_CHIU_PHI As Integer, ByVal NAM As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKINH_PHI_NAM", MS_BP_CHIU_PHI, NAM)
        End Sub
        Public Sub DeleteKINH_PHI_NAM_CS(ByVal MS_BP_CHIU_PHI As Integer, ByVal THANG As Date, ByVal MS_LOAI_CP As String, ByVal FORMNAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_KINH_PHI_NAM_LOG", MS_BP_CHIU_PHI, THANG, FORMNAME, Commons.Modules.UserName, 3)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKINH_PHI_NAM_CS", MS_BP_CHIU_PHI, THANG, MS_LOAI_CP)
        End Sub
        Public Sub DeleteKINH_PHI_NAMs(ByVal MS_BP_CHIU_PHI As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKINH_PHI_NAMs", MS_BP_CHIU_PHI)
        End Sub
        Public Sub DeleteKINH_PHI_NAM_CSS(ByVal MS_BP_CHIU_PHI As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKINH_PHI_NAM_CSS", MS_BP_CHIU_PHI)
        End Sub
#End Region


    End Class

End Namespace
