Namespace VS.Classes.Catalogue
    Public Class HE_THONGInfo
        Private _MS_HE_THONG As Integer
        Private _MA_HE_THONG As String
        Private _TEN_HE_THONG As String

        Private _GHI_CHU As String
        Private _NO_LINE As Boolean



        Public Property MS_HE_THONG() As Integer
            Get
                Return _MS_HE_THONG
            End Get
            Set(ByVal value As Integer)
                _MS_HE_THONG = value
            End Set
        End Property

        Public Property MA_HE_THONG() As String
            Get
                Return _MA_HE_THONG
            End Get
            Set(ByVal value As String)
                _MA_HE_THONG = value
            End Set
        End Property

        Public Property TEN_HE_THONG() As String
            Get
                Return _TEN_HE_THONG
            End Get
            Set(ByVal value As String)
                _TEN_HE_THONG = value
            End Set
        End Property

        Public Property GHI_CHU() As String
            Get
                Return _GHI_CHU
            End Get
            Set(ByVal value As String)
                _GHI_CHU = value
            End Set
        End Property


        Public Property NO_LINE() As Boolean
            Get
                Return _NO_LINE
            End Get
            Set(ByVal value As Boolean)
                _NO_LINE = value
            End Set
        End Property

    End Class
End Namespace
