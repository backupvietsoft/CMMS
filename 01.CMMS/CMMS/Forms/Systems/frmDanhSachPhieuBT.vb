
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports Microsoft.ApplicationBlocks.Data

Public Class frmDanhSachPhieuBT
    Public STT As String
    Public MS_MAY As String
    Public STT_VAN_DE As String


    Public iLoaiForm As Integer
    Private sql As String
    Public DSPhieu As New DataTable
    Dim viewChung As GridView
    Dim ptChung As Point

    ' iLoaiForm = 1 tim phieu bao tri
    ' iLoaiForm = 2 ke hoach tong the
    ' iLoaiForm = 3 Tim vat tu thong tin thiet bi

    Private Sub frmDanhSachPhieuBT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If STT = "" Then STT = "0"
            If MS_MAY = "" Then MS_MAY = ""
            If STT_VAN_DE = "" Then STT_VAN_DE = "0"

            If iLoaiForm = 1 Then
                sql = "exec sp_getDANH_SACH_MS_PHIEU_BAO_TRI '" & STT & "','" & MS_MAY & "','" & STT_VAN_DE & "'"
                DSPhieu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                Commons.Modules.ObjSystems.MLoadXtraGrid(GridControlDS, GridViewDS, DSPhieu, True, False, True, True)
                If txtMS_PHIEU.DataBindings.Count > 0 Then
                    txtMS_PHIEU.DataBindings.Clear()
                End If
                txtMS_PHIEU.DataBindings.Add("Text", DSPhieu, "MS_PHIEU_BAO_TRI")

                For i = 0 To DSPhieu.Columns.Count - 1
                    GridViewDS.Columns(i).OptionsColumn.AllowEdit = False
                    GridViewDS.Columns(i).OptionsColumn.AllowFocus = False
                Next
                txtMS_PHIEU.Visible = False
            End If
            If iLoaiForm = 2 Then
                sql = "exec sp_getDanhSachKHTT '" & STT & "','" & MS_MAY & "','" & STT_VAN_DE & "'"
                DSPhieu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                Commons.Modules.ObjSystems.MLoadXtraGrid(GridControlDS, GridViewDS, DSPhieu, True, False, True, True)
                If txtMS_PHIEU.DataBindings.Count > 0 Then
                    txtMS_PHIEU.DataBindings.Clear()
                End If
                txtMS_PHIEU.DataBindings.Add("Text", DSPhieu, "HANG_MUC_ID")

                For i = 0 To DSPhieu.Columns.Count - 1
                    GridViewDS.Columns(i).OptionsColumn.AllowEdit = False
                    GridViewDS.Columns(i).OptionsColumn.AllowFocus = False
                Next
                txtMS_PHIEU.Visible = False

            End If
            If iLoaiForm = 3 Then
                Commons.Modules.ObjSystems.MLoadXtraGrid(GridControlDS, GridViewDS, DSPhieu, True, False, True, True)
                If txtMS_PHIEU.DataBindings.Count > 0 Then
                    txtMS_PHIEU.DataBindings.Clear()
                End If
                txtMS_PHIEU.DataBindings.Add("Text", DSPhieu, "MS_PT")

                For i = 0 To DSPhieu.Columns.Count - 1
                    GridViewDS.Columns(i).OptionsColumn.AllowEdit = False
                    GridViewDS.Columns(i).OptionsColumn.AllowFocus = False
                Next
                txtMS_PHIEU.Visible = False

            End If
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            If iLoaiForm = 2 Then
                Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "frmNameChonHangMuc", Commons.Modules.TypeLanguage)
                'lblTieude.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTieuDeChonHangMuc", Commons.Modules.TypeLanguage)
            End If
            If iLoaiForm = 3 Then
                Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "frmNameChonVatTu", Commons.Modules.TypeLanguage)
                'lblTieude.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTieuDeChonVatTu", Commons.Modules.TypeLanguage)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Commons.Modules.SQLString = ""
        Me.Close()
    End Sub

    Private Sub cmdThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucHien.Click
        Try
            Commons.Modules.SQLString = txtMS_PHIEU.Text
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMS_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMS.EditValueChanged
        If iLoaiForm = 1 Then
            If GridViewDS.ActiveFilterString <> "" Then
                If txtMS.Text.Trim <> "" Then
                    DSPhieu.DefaultView.RowFilter = GridViewDS.ActiveFilterString & " and MS_PHIEU_BAO_TRI LIKE '%" & txtMS.Text.Trim & "%' "
                Else
                    DSPhieu.DefaultView.RowFilter = GridViewDS.ActiveFilterString
                End If
            Else
                If txtMS.Text.Trim <> "" Then
                    DSPhieu.DefaultView.RowFilter = "  MS_PHIEU_BAO_TRI LIKE '%" & txtMS.Text.Trim & "%' "
                Else
                    DSPhieu.DefaultView.RowFilter = " 1=1"
                End If
            End If
        End If
        If iLoaiForm = 2 Then
            If GridViewDS.ActiveFilterString <> "" Then
                If txtMS.Text.Trim <> "" Then
                    DSPhieu.DefaultView.RowFilter = GridViewDS.ActiveFilterString & " and TEN_HANG_MUC LIKE '%" & txtMS.Text.Trim & "%' "
                Else
                    DSPhieu.DefaultView.RowFilter = GridViewDS.ActiveFilterString
                End If
            Else
                If txtMS.Text.Trim <> "" Then
                    DSPhieu.DefaultView.RowFilter = "  TEN_HANG_MUC LIKE '%" & txtMS.Text.Trim & "%' "
                Else
                    DSPhieu.DefaultView.RowFilter = " 1=1"
                End If
            End If
        End If

        If iLoaiForm = 3 Then
            'T1.MS_PT, T1.TEN_PT, T1.TEN_PT_VIET, T1.QUY_CACH, T1.MS_PT_NCC, T1.MS_PT_CTY, T8.TEN_1, T3.TEN_LOAI_VT_TV
            If GridViewDS.ActiveFilterString <> "" Then
                If txtMS.Text.Trim <> "" Then
                    DSPhieu.DefaultView.RowFilter = GridViewDS.ActiveFilterString & " AND (TEN_PT LIKE '%" & txtMS.Text.Trim & "%' OR MS_PT LIKE '%" & txtMS.Text.Trim & "%'  " & _
                            " OR MS_PT_NCC LIKE '%" & txtMS.Text.Trim & "%'  OR MS_PT_CTY LIKE '%" & txtMS.Text.Trim & "%' " & _
                            " OR TEN_DVT LIKE '%" & txtMS.Text.Trim & "%'  OR TEN_LOAI_VT LIKE '%" & txtMS.Text.Trim & "%' " & _
                            " OR TEN_PT_VIET LIKE '%" & txtMS.Text.Trim & "%'  OR QUY_CACH LIKE '%" & txtMS.Text.Trim & "%' ) "
                Else
                    DSPhieu.DefaultView.RowFilter = GridViewDS.ActiveFilterString
                End If
            Else
                If txtMS.Text.Trim <> "" Then
                    DSPhieu.DefaultView.RowFilter = "  TEN_PT LIKE '%" & txtMS.Text.Trim & "%' OR  MS_PT LIKE '%" & txtMS.Text.Trim & "%'  " & _
                            " OR MS_PT_NCC LIKE '%" & txtMS.Text.Trim & "%'  OR MS_PT_CTY LIKE '%" & txtMS.Text.Trim & "%' " & _
                            " OR TEN_DVT LIKE '%" & txtMS.Text.Trim & "%'  OR TEN_LOAI_VT LIKE '%" & txtMS.Text.Trim & "%' " & _
                            " OR TEN_PT_VIET LIKE '%" & txtMS.Text.Trim & "%'  OR QUY_CACH LIKE '%" & txtMS.Text.Trim & "%'"
                Else
                    DSPhieu.DefaultView.RowFilter = " 1=1"
                End If
            End If
        End If

    End Sub


    Private Sub GridViewDS_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles GridViewDS.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        DoRowDoubleClick(view, pt)

    End Sub

    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        If info.InRow OrElse info.InRowCell Then
            Dim colCaption As String
            If info.Column Is Nothing Then
                colCaption = "N/A"
            Else
                colCaption = info.Column.GetCaption()
            End If
            'XtraMessageBox.Show(String.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption))

            'XtraMessageBox.Show(view.GetFocusedRowCellValue("MS_PHIEU_BAO_TRI").ToString())
            If iLoaiForm = 1 Then
                Commons.Modules.SQLString = view.GetFocusedRowCellValue("MS_PHIEU_BAO_TRI").ToString()
            End If
            If iLoaiForm = 2 Then
                Commons.Modules.SQLString = view.GetFocusedRowCellValue("HANG_MUC_ID").ToString()
            End If
            If iLoaiForm = 3 Then
                Commons.Modules.SQLString = view.GetFocusedRowCellValue("MS_PT").ToString()
            End If
            Me.Close()

        End If
    End Sub
End Class