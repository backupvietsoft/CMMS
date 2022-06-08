Namespace QL.Events
    ' <summary>
    ' Create By Nghiem Quan, Lieu Email nghiemquan_lieu@yahoo.com
    ' Date 1/9/2006
    ' </summary>
    ' <remarks></remarks>
    Public Class QLCallBackEvent
        Public Sub New()

        End Sub
        Public Delegate Sub CallBack(ByVal hasData As Hashtable)
        Private _callback As CallBack
        Public Custom Event OnCallBack As CallBack
            AddHandler(ByVal value As CallBack)
                _callback = CType([Delegate].Combine(_callback, value), CallBack)
            End AddHandler

            RemoveHandler(ByVal value As CallBack)
                _callback = CType([Delegate].Remove(_callback, value), CallBack)
            End RemoveHandler

            RaiseEvent(ByVal hasData As Hashtable)
                If _callback IsNot Nothing Then
                    _callback.Invoke(hasData)
                End If
            End RaiseEvent
        End Event
        Public Sub Called(ByVal hasData As Hashtable)
            RaiseEvent OnCallBack(hasData)
        End Sub
    End Class
End Namespace