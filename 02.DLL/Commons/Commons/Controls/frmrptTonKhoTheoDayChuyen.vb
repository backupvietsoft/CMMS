Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Imports Commons.VS.Classes.Admin
Imports System.Data
Public Class frmrptTonKhoTheoDayChuyen
    Private TbLine As DataTable = New DataTable()
    Private TbMech As DataTable = New DataTable()
    Private Sub frmrptTonKhoTheoDayChuyen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim TbWh As DataTable = New DataTable()
        TbWh.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT MS_KHO,TEN_KHO FROM dbo.IC_KHO"))
        CboKho.DataSource = TbWh
        CboKho.ValueMember = "MS_KHO"
        CboKho.DisplayMember = "TEN_KHO"
        TbLine.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT CONVERT (BIT,0) AS CHON , MS_HE_THONG,TEN_HE_THONG FROM dbo.HE_THONG"))
        TbLine.Columns("CHON").ReadOnly = False
        Dgvline.AutoGenerateColumns = False
        Dgvline.DataSource = TbLine
        CHON_HT.DataPropertyName = "CHON"
        HE_THONG.DataPropertyName = "TEN_HE_THONG"
        Dim SqlFilter As String = " SELECT CONVERT (BIT,0) AS CHON, TMP1.MS_HE_THONG,dbo.MAY.MS_MAY , dbo.MAY.TEN_MAY" & _
                                  " FROM" & _
                                  " (SELECT     T1_1.MS_MAY, T2.MS_HE_THONG " & _
                                  " FROM          (SELECT     MS_MAY, MAX(NGAY_NHAP) AS NGAY_NHAP" & _
                                  " FROM          dbo.MAY_HE_THONG AS T " & _
                                  " GROUP BY MS_MAY) AS T1_1 INNER JOIN " & _
                                  " dbo.MAY_HE_THONG AS T2 ON T1_1.MS_MAY = T2.MS_MAY AND T1_1.NGAY_NHAP = T2.NGAY_NHAP) TMP1 INNER JOIN dbo.MAY " & _
                                  " ON TMP1.MS_MAY = dbo.MAY.MS_MAY "
        TbMech.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, SqlFilter))
        TbMech.Columns("CHON").ReadOnly = False
        Try
            TbMech.DefaultView.RowFilter = "MS_HE_THONG = " & CType(Dgvline.CurrentRow.DataBoundItem, DataRowView).Row("MS_HE_THONG").ToString().Trim()
        Catch ex As Exception
            TbMech.DefaultView.RowFilter = "1=0"
        End Try
        Dgvmay.AutoGenerateColumns = False
        Dgvmay.DataSource = TbMech.DefaultView
        CHON_MAY.DataPropertyName = "CHON"
        MS_MAY.DataPropertyName = "MS_MAY"
        TEN_MAY.DataPropertyName = "TEN_MAY"
    End Sub

    Private Sub Dgvline_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgvline.RowEnter
        Try
            TbMech.DefaultView.RowFilter = "MS_HE_THONG = " & CType(Dgvline.Rows(e.RowIndex).DataBoundItem, DataRowView).Row("MS_HE_THONG").ToString().Trim()
        Catch ex As Exception
            TbMech.DefaultView.RowFilter = "1=0"
        End Try
    End Sub

    Private Sub Dgvmay_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Dgvmay.CellBeginEdit
        If (Dgvline.CurrentRow.Cells("CHON_HT").Value.Equals(False)) Then
            e.Cancel = True
        End If
    End Sub
    Private Sub BtnAllmay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAllmay.Click
        If (Dgvline.CurrentRow.Cells("CHON_HT").Value.Equals(True)) Then
            For i As Integer = 0 To Dgvmay.Rows.Count - 1
                Dgvmay.Rows(i).Cells("CHON_MAY").Value = True
            Next
        End If
    End Sub
    Private Sub BtnClearmay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearmay.Click
        For i As Integer = 0 To Dgvmay.Rows.Count - 1
            Dgvmay.Rows(i).Cells("CHON_MAY").Value = False
        Next
    End Sub
    Private Sub BtnAllline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAllline.Click
        For i As Integer = 0 To Dgvline.Rows.Count - 1
            Dgvline.Rows(i).Cells("CHON_HT").Value = True
        Next
    End Sub
    Private Sub BtnClearline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearline.Click
        For i As Integer = 0 To Dgvline.Rows.Count - 1
            Dgvline.Rows(i).Cells("CHON_HT").Value = False
        Next
        For j As Integer = 0 To TbMech.Rows.Count - 1
            TbMech.Rows(j)("CHON") = False
        Next
    End Sub
    Private Sub Dgvline_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgvline.CellValueChanged
        If e.RowIndex > 0 Then
            If (Dgvline.Columns(e.ColumnIndex).Name = "CHON_HT") Then
                If Dgvline.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.Equals(False) Then
                    For i As Integer = 0 To Dgvmay.Rows.Count - 1
                        Dgvmay.Rows(i).Cells("CHON_MAY").Value = False
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub Dgvline_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgvline.CellContentClick
        If (Dgvline.Columns(e.ColumnIndex).Name = "CHON_HT") Then
            If Dgvline.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.Equals(True) Then
                For i As Integer = 0 To Dgvmay.Rows.Count - 1
                    Dgvmay.Rows(i).Cells("CHON_MAY").Value = False
                Next
            End If
        End If
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim MS_HE_THONG As String = String.Empty
        Dim MS_MAY As String = String.Empty
        Dim FLAG As Boolean = False
        For i As Integer = 0 To TbLine.Rows.Count - 1
            If (TbLine.Rows(i)("CHON").Equals(True)) Then
                MS_HE_THONG = MS_HE_THONG & TbLine.Rows(i)("MS_HE_THONG").ToString().Trim() & ","
            End If
        Next
        If (Not MS_HE_THONG.Equals(String.Empty)) Then
            MS_HE_THONG = MS_HE_THONG.Substring(0, MS_HE_THONG.Length - 1)
        End If
        For j As Integer = 0 To TbMech.Rows.Count - 1
            If (TbMech.Rows(j)("CHON").Equals(True)) Then
                MS_MAY = MS_MAY & "'" & TbMech.Rows(j)("MS_MAY").ToString().Trim() & "',"
            End If
        Next
        If (Not MS_MAY.Equals(String.Empty)) Then
            MS_MAY = MS_MAY.Substring(0, MS_MAY.Length - 1)
        End If
        If (Not MS_HE_THONG.Equals(String.Empty) And Not MS_MAY.Equals(String.Empty)) Then
            Dim TbSource As DataTable = New DataTable()
            TbSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_TON_KHO_THEO_MAY", CboKho.SelectedValue, MS_HE_THONG, MS_MAY))
            Dim Tbtitle As DataTable = New DataTable()
            Tbtitle.Columns.Add("Title")
            Tbtitle.Columns.Add("T1")
            Tbtitle.Columns.Add("T2")
            Tbtitle.Columns.Add("T3")
            Tbtitle.Columns.Add("T4")
            Tbtitle.Columns.Add("T5")
            Tbtitle.Columns.Add("T6")
            Tbtitle.Columns.Add("T7")
            Tbtitle.Columns.Add("STT")
            Tbtitle.Columns.Add("MS_PT")
            Tbtitle.Columns.Add("PART_NO")
            Tbtitle.Columns.Add("TEN_PT")
            Tbtitle.Columns.Add("QUY_CACH")
            Tbtitle.Columns.Add("HSX")
            Tbtitle.Columns.Add("DVT")
            Tbtitle.Columns.Add("SL_SD")
            Tbtitle.Columns.Add("SL_TON")
            Tbtitle.Columns.Add("GIA_TRI")
            Tbtitle.Columns.Add("TON_MIN")
            Tbtitle.Columns.Add("KHO")
            Tbtitle.Columns.Add("MS_MAY")
            Tbtitle.Columns.Add("TEN_MAY")
            Tbtitle.Columns.Add("HE_THONG")
            Tbtitle.Columns.Add("HSX_MAY")

            Dim title As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "TIEU_DE", commons.Modules.TypeLanguage)
            Dim T1 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "T1", commons.Modules.TypeLanguage)
            Dim T2 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "T2", commons.Modules.TypeLanguage)
            Dim T3 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "T3", commons.Modules.TypeLanguage)
            Dim T4 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "T4", commons.Modules.TypeLanguage)
            Dim T5 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "T5", commons.Modules.TypeLanguage)
            Dim T6 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "T6", commons.Modules.TypeLanguage)
            Dim T7 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "T7", commons.Modules.TypeLanguage)
            Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "STT", commons.Modules.TypeLanguage)
            Dim MS_PT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "MS_PT", commons.Modules.TypeLanguage)
            Dim PART_NO As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "PART_NO", commons.Modules.TypeLanguage)
            Dim TEN_PT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "TEN_PT", commons.Modules.TypeLanguage)
            Dim QUY_CACH As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "QUY_CACH", commons.Modules.TypeLanguage)
            Dim HSX As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "HSX", commons.Modules.TypeLanguage)
            Dim DVT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "DVT", commons.Modules.TypeLanguage)
            Dim SL_SD As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "SL_SD", commons.Modules.TypeLanguage)
            Dim SL_TON As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "SL_TON", commons.Modules.TypeLanguage)
            Dim GIA_TRI As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "GIA_TRI", commons.Modules.TypeLanguage)
            Dim TON_MIN As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "TON_MIN", commons.Modules.TypeLanguage)
            Dim KHO As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "KHO", commons.Modules.TypeLanguage) & CboKho.Text
            Dim MS_MAY_T As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "MS_MAY", commons.Modules.TypeLanguage)
            Dim TEN_MAY As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "TEN_MAY", commons.Modules.TypeLanguage)
            Dim HE_THONG As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "HE_THONG", commons.Modules.TypeLanguage)
            Dim HSX_MAY As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptTonKhoTheoDayChuyen", "HSX_MAY", commons.Modules.TypeLanguage)
            Tbtitle.Rows.Add(title, T1, T2, T3, T4, T5, T6, T7, STT, MS_PT, PART_NO, TEN_PT, QUY_CACH, HSX, DVT, SL_SD, SL_TON, GIA_TRI, TON_MIN, KHO, MS_MAY_T, TEN_MAY, HE_THONG, HSX_MAY)
            Dim frmReport As frmXMLReport = New frmXMLReport()
            frmReport.rptName = "rptTonKhoTheoDayChuyen"
            frmReport.AddDataTableSource(TbSource)
            frmReport.AddDataTableSource(Tbtitle)
            frmReport.ShowDialog()
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmrptTonKhoTheoDayChuyen", "MsgChonDuLieuIn", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
