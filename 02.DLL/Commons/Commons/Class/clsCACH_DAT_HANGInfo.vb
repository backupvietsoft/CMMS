Namespace VS.Classes.Catalogue
    Public Class CACH_DAT_HANGInfo
        Private _MS_CACH_DAT_HANG As Integer
        Private _CACH_DAT_HANG As String
        Public Property MS_CACH_DAT_HANG() As Integer
            Get
                Return _MS_CACH_DAT_HANG
            End Get
            Set(ByVal value As Integer)
                _MS_CACH_DAT_HANG = value
            End Set
        End Property
        Public Property CACH_DAT_HANG() As String
            Get
                Return _CACH_DAT_HANG
            End Get
            Set(ByVal value As String)
                _CACH_DAT_HANG = value
            End Set
        End Property
    End Class
End Namespace
