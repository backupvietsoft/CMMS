Namespace VS.Classes.Catalogue
    Public Class HANG_SAN_XUATInfo
        Private _MS_HSX As Integer
        Private _TEN_HSX As String
        Private _DIA_CHI As String
        Private _WEBSITE As String
        Public Property MS_HSX() As Integer
            Get
                Return _MS_HSX
            End Get
            Set(ByVal value As Integer)
                _MS_HSX = value
            End Set
        End Property
        Public Property TEN_HSX() As String
            Get
                Return _TEN_HSX
            End Get
            Set(ByVal value As String)
                _TEN_HSX = value
            End Set
        End Property
        Public Property DIA_CHI() As String
            Get
                Return _DIA_CHI
            End Get
            Set(ByVal value As String)
                _DIA_CHI = value
            End Set
        End Property
        Public Property WEBSITE() As String
            Get
                Return _WEBSITE
            End Get
            Set(ByVal value As String)
                _WEBSITE = value
            End Set
        End Property
    End Class
End Namespace
