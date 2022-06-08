Namespace VS.Classes.Catalogue
    Public Class BAC_THOInfo
        Private _MS_BT As Integer
        Private _TEN_BT As String
        Public Property MS_BT() As Integer
            Get
                Return _MS_BT
            End Get
            Set(ByVal value As Integer)
                _MS_BT = value
            End Set
        End Property
        Public Property TEN_BT() As String
            Get
                Return _TEN_BT
            End Get
            Set(ByVal value As String)
                _TEN_BT = value
            End Set
        End Property
    End Class

End Namespace
