Namespace VS.Classes.Catalogue
    Public Class GIAM_SAT_TINH_TRANGInfo
        Private _STT As Integer
        Private _GIO_KT As String
        Private _NGAY_KT As String
        Private _MS_CONG_NHAN As String
        Private _DEN_GIO As String
        Public Property STT As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
            End Set
        End Property
        Public Property GIO_KT As String
            Get
                Return _GIO_KT
            End Get
            Set(ByVal value As String)
                _GIO_KT = value
            End Set
        End Property
        Public Property DEN_GIO As String
            Get
                Return _DEN_GIO
            End Get
            Set(ByVal value As String)
                _DEN_GIO = value
            End Set
        End Property
        Public Property NGAY_KT As String
            Get
                Return _NGAY_KT
            End Get
            Set(ByVal value As String)
                _NGAY_KT = value
            End Set
        End Property
        Public Property MS_CONG_NHAN As String
            Get
                Return _MS_CONG_NHAN
            End Get
            Set(ByVal value As String)
                _MS_CONG_NHAN = value
            End Set
        End Property
        Private _GIO_CHAY_MAY As Double
        Public Property GIO_CHAY_MAY As Double
            Get
                Return _GIO_CHAY_MAY
            End Get
            Set(value As Double)
                _GIO_CHAY_MAY = value
            End Set
        End Property

        Private _NHAN_XET As String
        Public Property NHAN_XET As String
            Get
                Return _NHAN_XET
            End Get
            Set(value As String)
                _NHAN_XET = value
            End Set
        End Property
        Private _USERNAME As String
        Public Property USERNAME As String
            Get
                Return _USERNAME
            End Get
            Set(value As String)
                _USERNAME = value
            End Set
        End Property

        Private _SO_PHIEU As String
        Public Property SO_PHIEU As String
            Get
                Return _SO_PHIEU
            End Get
            Set(value As String)
                _SO_PHIEU = value
            End Set
        End Property

        Private _HOAN_THANH As Integer
        Public Property HOAN_THANH As Integer
            Get
                Return _HOAN_THANH
            End Get
            Set(value As Integer)
                _HOAN_THANH = value
            End Set
        End Property
        Private _NGAY_KT_GOC As DateTime
        Public Property NGAY_KT_GOC As DateTime
            Get
                Return _NGAY_KT_GOC
            End Get
            Set(value As DateTime)
                _NGAY_KT_GOC = value
            End Set
        End Property
    End Class
End Namespace

