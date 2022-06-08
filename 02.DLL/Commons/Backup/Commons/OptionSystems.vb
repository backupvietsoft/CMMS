Public Class OptionSystems
    Private Shared _FillterStreet As Boolean = False
    Public Shared Property FillterStreet() As Boolean
        Get
            Return _FillterStreet
        End Get
        Set(ByVal value As Boolean)
            _FillterStreet = value
        End Set
    End Property

End Class
