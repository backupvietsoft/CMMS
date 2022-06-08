Public Class clsCheckValuecell

    Public Shared Sub Check_Value_Cell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs)
        Try

            If (CType(sender, DataGridView).Columns(e.ColumnIndex).DefaultCellStyle.Format = "N2") Then
                If (Not e.FormattedValue.Equals("")) Then
                    Dim vNumber As Double = Double.Parse(e.FormattedValue)
                    If vNumber < 0 Then
                        MessageBox.Show(CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText & " không được < 0 !", "Thông báo", MessageBoxButtons.OK)
                        e.Cancel = True
                    End If
                Else
                    MessageBox.Show(CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText & " không được để trống !", "Thông báo", MessageBoxButtons.OK)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText & " phải là số", "Thông báo", MessageBoxButtons.OK)
            e.Cancel = True
        End Try
    End Sub

    ' kiem tra gia tri lon hon khong
    Public Shared Function Check_Value_CellUpO(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) As Boolean
        Try

            If (CType(sender, DataGridView).Columns(e.ColumnIndex).DefaultCellStyle.Format = "N2") Then
                If (Not e.FormattedValue.Equals("")) Then
                    Dim vNumber As Double = Double.Parse(e.FormattedValue)
                    If vNumber <= 0 Then
                        MessageBox.Show(CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText & " không được < 0 !", "Thông báo", MessageBoxButtons.OK)
                        e.Cancel = True
                        Return False
                    End If
                Else
                    MessageBox.Show(CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText & " không được để trống !", "Thông báo", MessageBoxButtons.OK)
                    e.Cancel = True
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show(CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText & " phải là số", "Thông báo", MessageBoxButtons.OK)
            e.Cancel = True
            Return False
        End Try
    End Function


End Class
