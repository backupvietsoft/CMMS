Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid

Public Class frmYCNSDXemTL
    Public dtChung As New DataTable
    Private inplaceEditor As BaseEdit

    Private Sub frmYCNSDXemTL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtChung, True, True, True, True)

        For i As Integer = 0 To grvChung.Columns.Count - 1
            grvChung.Columns(i).OptionsColumn.ReadOnly = True

            If grvChung.Columns(i).Name.ToUpper() = "COLMS_MAY" Or grvChung.Columns(i).Name.ToUpper() = "COLDUONG_DAN" Or grvChung.Columns(i).Name.ToUpper() = "COLGHI_CHU" Then
                grvChung.Columns(i).Visible = True
            Else
                grvChung.Columns(i).Visible = False
            End If
        Next
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Close()
    End Sub

    Private Sub grvChung_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grvChung.ShownEditor
        inplaceEditor = (CType(sender, GridView)).ActiveEditor
        AddHandler inplaceEditor.DoubleClick, AddressOf inplaceEditor_DoubleClick
    End Sub

    Private Sub inplaceEditor_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim editor As BaseEdit = CType(sender, BaseEdit)
            Dim grid As GridControl = CType(editor.Parent, GridControl)
            Dim pt As Point = grid.PointToClient(Control.MousePosition)
            Dim view As GridView = CType(grid.FocusedView, GridView)
            DoRowDoubleClick(view, pt)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        Try
            If info.InRow OrElse info.InRowCell Then
                Dim colCaption As String
                If info.Column Is Nothing Then
                    colCaption = "N/A"
                Else
                    colCaption = info.Column.GetCaption()
                End If
                Dim sDDan As String
                sDDan = grvChung.GetFocusedRowCellValue("DUONG_DAN").ToString()
                Me.Cursor = Cursors.WaitCursor
                System.Diagnostics.Process.Start(sDDan)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnXemTL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemTL.Click
        Dim sDDan As String
        Try

            sDDan = grvChung.GetFocusedRowCellValue("DUONG_DAN").ToString()
            Me.Cursor = Cursors.WaitCursor
            System.Diagnostics.Process.Start(sDDan)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
End Class