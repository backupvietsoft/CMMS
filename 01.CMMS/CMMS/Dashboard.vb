Public Class Dashboard
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        WebBrowser1.Document.Window.ScrollTo(0, 33)
    End Sub

    Private Sub Dashboard_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged

        Me.Text = Me.Size.Width.ToString()
        If (Size.Width < 768) Then
            WebBrowser1.ScrollBarsEnabled = True
        Else
            WebBrowser1.ScrollBarsEnabled = False
            Try
                If WebBrowser1.Document.Window.Position.Y <> 33 Then
                    WebBrowser1.Document.Window.ScrollTo(0, 33)
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub
End Class