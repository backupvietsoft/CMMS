Namespace VS.Events
    ' <summary>
    ' Create By Nghiem Quan, Lieu
    ' Date 1/9/2006
    ' </summary>
    ' <remarks></remarks>
    Public Class EventViewForm
        Public Sub New()

        End Sub
        Public Delegate Sub CallBack(ByVal frmName As String)
        Private _callback As CallBack
        Public Custom Event OnCallBack As CallBack
            AddHandler(ByVal value As CallBack)
                _callback = CType([Delegate].Combine(_callback, value), CallBack)
            End AddHandler

            RemoveHandler(ByVal value As CallBack)
                _callback = CType([Delegate].Remove(_callback, value), CallBack)
            End RemoveHandler

            RaiseEvent(ByVal frmName As String)
                If _callback IsNot Nothing Then
                    _callback.Invoke(frmName)
                End If
            End RaiseEvent
        End Event
        Public Sub Called(ByVal frmName As String)
            RaiseEvent OnCallBack(frmName)
        End Sub
    End Class
End Namespace