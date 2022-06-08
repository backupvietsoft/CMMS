
    Public Class ILanguages
        Private _STT As Integer
        Private _MS_MODULE As String
        Private _FORM As String
        Private _KEYWORD As String
        Private _VIETNAM As String
        Private _ENGLISH As String
        Public Property STT() As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
            End Set
        End Property
        Public Property MS_MODULE() As String
            Get
                Return _MS_MODULE
            End Get
            Set(ByVal value As String)
                _MS_MODULE = value
            End Set
        End Property
        Public Property FORM() As String
            Get
                Return _FORM
            End Get
            Set(ByVal value As String)
                _FORM = value
            End Set
        End Property
        Public Property KEYWORD() As String
            Get
                Return _KEYWORD
            End Get
            Set(ByVal value As String)
                _KEYWORD = value
            End Set
        End Property
        Public Property VIETNAM() As String
            Get
                Return _VIETNAM
            End Get
            Set(ByVal value As String)
                _VIETNAM = value
            End Set
        End Property
        Public Property ENGLISH() As String
            Get
                Return _ENGLISH
            End Get
            Set(ByVal value As String)
                _ENGLISH = value
            End Set
        End Property
    End Class

