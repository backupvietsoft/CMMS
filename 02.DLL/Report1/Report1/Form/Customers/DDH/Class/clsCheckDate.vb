Public Class clsCheckDate

    Public Shared Sub ChecKed_Value_Date(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            If (Not CType(sender, MaskedTextBox).Text.Trim.Equals("/  /")) Then
                Dim vDate As System.DateTime = System.DateTime.ParseExact(CType(sender, MaskedTextBox).Text, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)
            End If
        Catch ex As Exception
            MessageBox.Show("Định dạng ngày/tháng/Năm chưa đúng, Bạn vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK)
            e.Cancel = True
            Exit Sub
        End Try
    End Sub

End Class
