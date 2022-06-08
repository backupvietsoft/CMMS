Namespace VS.Classes.Catalogue
    Public Class GIAM_SAT_TINH_TRANGInfo
        Private _STT As Integer
        Private _GIO_KT As String
        Private _NGAY_KT As String
        Private _MS_CONG_NHAN As String
        Private _DEN_GIO As String


        Public Property STT() As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
            End Set
        End Property
        Public Property GIO_KT() As String
            Get
                Return _GIO_KT
            End Get
            Set(ByVal value As String)
                _GIO_KT = value
            End Set
        End Property
        Public Property DEN_GIO() As String
            Get
                Return _DEN_GIO
            End Get
            Set(ByVal value As String)
                _DEN_GIO = value
            End Set
        End Property
        Public Property NGAY_KT() As String
            Get
                Return _NGAY_KT
            End Get
            Set(ByVal value As String)
                _NGAY_KT = value
            End Set
        End Property
        Public Property MS_CONG_NHAN() As String
            Get
                Return _MS_CONG_NHAN
            End Get
            Set(ByVal value As String)
                _MS_CONG_NHAN = value
            End Set
        End Property

    End Class
End Namespace

