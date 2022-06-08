
Imports Commons.VS.Classes.Admin
Imports Microsoft.ApplicationBlocks.Data
Public Class frmChoiStreet

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnChoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoice.Click
        Validate()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class