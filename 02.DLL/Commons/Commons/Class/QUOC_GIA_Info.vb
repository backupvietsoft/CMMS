Public Class QUOC_GIA_Info
    Private _maQG As String
    Private _tenQG As String

    Public Property MA_QG() As String
        Get
            Return _maQG
        End Get
        Set(ByVal value As String)
            _maQG = value
        End Set
    End Property
    Public Property TEN_QG() As String
        Get
            Return _tenQG
        End Get
        Set(ByVal value As String)
            _tenQG = value
        End Set
    End Property
End Class
