Public Class Modules
    Private Shared _MConvertFont As MConvertFont = New MConvertFont()
    Public Shared Property MConvertFont() As MConvertFont
        Get
            Return _MConvertFont
        End Get
        Set(ByVal value As MConvertFont)
            _MConvertFont = value
        End Set
    End Property


End Class
