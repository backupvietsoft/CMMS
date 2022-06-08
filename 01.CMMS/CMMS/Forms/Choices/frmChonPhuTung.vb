Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin

Public Class frmChonPhuTung
    Dim _sMS_MAY As String
    Dim _sMS_BP As String
    Dim _sMS_LOAI_MAY As String


    Public Property MS_MAY() As String
        Get
            Return _sMS_MAY
        End Get
        Set(ByVal value As String)
            _sMS_MAY = value
        End Set
    End Property

    Public Property MS_LOAI_MAY() As String
        Get
            Return _sMS_LOAI_MAY
        End Get
        Set(ByVal value As String)
            _sMS_LOAI_MAY = value
        End Set
    End Property

    Public Property MS_BP() As String
        Get
            Return _sMS_BP
        End Get
        Set(ByVal value As String)
            _sMS_BP = value
        End Set
    End Property

    Sub ShowData()


        Try
            Dim dtPT As DataTable = New DataTable()
            If chkDanhmucPhuTung.Checked = True Then
                dtPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_ViewPhutung", MS_LOAI_MAY,
                    Commons.Modules.TypeLanguage, Convert.ToInt32(cboLoaiPT.EditValue), Commons.Modules.UserName))
            Else
                dtPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_ViewPhutung_MsMAY_LOAIMAY", MS_LOAI_MAY,
                    Commons.Modules.TypeLanguage, Convert.ToInt32(cboLoaiPT.EditValue), Commons.Modules.UserName))
            End If

            FindCheck(dtPT) 'Xóa phụ tùng bộ phận cha

            Try
                grvPT.Columns.Clear()
                grdPT.DataSource = Nothing
            Catch ex As Exception
            End Try

            dtPT.Columns.Add(New DataColumn("TxtSoDong", Type.GetType("System.String")))
            For Each col As DataColumn In dtPT.Columns
                col.ReadOnly = True
            Next

            dtPT.Columns("chkChon").ReadOnly = False
            dtPT.Columns("TxtSoDong").ReadOnly = False
            dtPT.Columns("TxtSoDong").AllowDBNull = True

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdPT, grvPT, dtPT, True, True, True, True, True, Name)
            With grvPT
                .Columns(0).Width = 110
                .Columns(1).Width = 100
                .Columns(2).Width = 100
                .Columns(3).Width = 150
                .Columns(4).Width = 120
                .Columns(5).Width = 90
                .Columns(6).Width = 90
                .Columns(7).Width = 100
                .Columns(8).Width = 80
                .Columns("DVT1").Visible = False
            End With
        Catch ex As Exception
        End Try
    End Sub

    Sub FindCheck(ByRef dtPhutung As DataTable)
        If dtPhutung.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim SqlText As String

        SqlText = "SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & Me.MS_MAY & "' AND MS_BO_PHAN ='" & Me.MS_BP & "' ORDER BY MS_PT"

        Dim dtCheck As New DataTable
        dtCheck.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        If dtCheck.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim i As Integer
        For i = 0 To dtCheck.Rows.Count - 1
            Dim sMS_PT As String = IIf(IsDBNull(dtCheck.Rows(i)("MS_PT")), String.Empty, dtCheck.Rows(i)("MS_PT").ToString())
            Dim drr As DataRow() = dtPhutung.Select("MS_PT = '" & sMS_PT & "' ")
            For j As Integer = 0 To drr.Length - 1
                drr(j).Delete()
            Next
        Next i
        dtPhutung.AcceptChanges()
    End Sub

    Sub SelectAll()
        Dim i As Integer
        For i = 0 To grvPT.RowCount - 1
            grvPT.SetRowCellValue(i, "chkChon", True)
            grvPT.SetRowCellValue(i, "TxtSoDong", 1)
            grvPT.UpdateCurrentRow()
        Next
    End Sub

    Sub DeSelectAll()
        Dim i As Integer
        For i = 0 To grvPT.RowCount - 1
            grvPT.SetRowCellValue(i, "chkChon", False)
            grvPT.SetRowCellValue(i, "TxtSoDong", 0)
            grvPT.UpdateCurrentRow()
        Next
    End Sub

    Private Sub frmChonPhuTung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.SQLString = "0Load"
        Dim tb As New DataTable()
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_LOAI_PT", Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiPT, tb, "MS_LOAI_PT", "TEN_LOAI_PT", "")

        Try
            cboLoaiPT.EditValue = -1
        Catch ex As Exception
        End Try
        Commons.Modules.SQLString = ""
        cboLoaiPT_EditValueChanged(Nothing, Nothing)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub btnChapnhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChapnhan.Click

        Dim dt As DataTable = CType(grdPT.DataSource, DataTable).Copy()
        dt.DefaultView.RowFilter = " chkChon = true "
        If dt.DefaultView.ToTable().Rows.Count = 0 Then
            lFlag = True
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        '
        lFlag = False
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Close()
    End Sub


    Private Sub cboLoaiPT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowData()
    End Sub




    Dim thutu As Integer = -1
    Dim GiaTri As String = ""
    Dim GiaTri1 As String = ""
    Dim thutu1 As Integer = -1

    Private Sub BtnChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTatCa.Click
        Call SelectAll()
    End Sub

    Private Sub BtnBoChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoChonTatCa.Click
        Call DeSelectAll()
    End Sub

    Private Sub txtTimMaCTTB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTimMaCTTB.TextChanged
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(grdPT.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = "MS_PT like '%" + txtTimMaCTTB.Text + "%' OR MS_PT_CTY like '%" + txtTimMaCTTB.Text + "%' " +
                    " OR MS_PT_NCC like '%" + txtTimMaCTTB.Text + "%' OR TEN_PT like '%" + txtTimMaCTTB.Text + "%' " +
                    " OR QUY_CACH like '%" + txtTimMaCTTB.Text + "%' OR TEN_PT_VIET like '%" + txtTimMaCTTB.Text + "%'"
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
        End Try
    End Sub

    Private Sub ckDanhMucPhuTung_EditValueChanged(sender As Object, e As EventArgs) Handles chkDanhmucPhuTung.EditValueChanged
        ShowData()
    End Sub

    Private Sub grvPT_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvPT.ValidateRow
        If grvPT.GetDataRow(e.RowHandle)("TxtSoDong").ToString() <> "" Then
            If Not IsNumeric(grvPT.GetDataRow(e.RowHandle)("TxtSoDong").ToString()) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT2", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                e.Valid = False
                Exit Sub
            End If
        Else
            grvPT.SetRowCellValue(e.RowHandle, "TxtSoDong", 1)
        End If

        Try
            If (Convert.ToDouble(grvPT.GetDataRow(e.RowHandle)("TxtSoDong").ToString()) <= 0) Then
                grvPT.SetRowCellValue(e.RowHandle, "TxtSoDong", 1)
            End If

        Catch ex As Exception
            grvPT.SetRowCellValue(e.RowHandle, "TxtSoDong", 1)
        End Try
        grvPT.UpdateCurrentRow()
    End Sub

    Private Sub grvPT_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvPT.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvPT_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvPT.CellValueChanged
        If e.Column.FieldName = "chkChon" Then
            If grvPT.RowCount <= 0 Then Exit Sub
            If Convert.ToBoolean(grvPT.GetDataRow(e.RowHandle)("chkChon")) = True Then
                Try
                    If Convert.ToInt32(grvPT.GetDataRow(e.RowHandle)("TxtSoDong")) <= 0 Then
                        grvPT.SetRowCellValue(e.RowHandle, "TxtSoDong", 1)
                    End If
                Catch ex As Exception
                    grvPT.SetRowCellValue(e.RowHandle, "TxtSoDong", 0)
                End Try
            Else
                grvPT.SetRowCellValue(e.RowHandle, "TxtSoDong", 0)
            End If
            grvPT.UpdateCurrentRow()
        End If
    End Sub

    Private Sub cboLoaiPT_EditValueChanged(sender As Object, e As EventArgs) Handles cboLoaiPT.EditValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        ShowData()
    End Sub
End Class