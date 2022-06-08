Namespace VS.Classes.Catalogue
    Public Class clsLICH_TAUInfo
        Private _STT As Integer
        Private _TEN_CHUYEN_TAU As String
        Private _TU_NGAY As DateTime
        Private _TU_GIO As String
        Private _DEN_NGAY As DateTime
        Private _DEN_GIO As String
        Private _GHI_CHU As String
        Private _BEN As String
        Private _NGAY_CAP_NHAT_CUOI As String
        Private _DA_XONG As Boolean
        Public Property STT() As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
            End Set
        End Property
        Public Property TEN_CHUYEN_TAU() As String
            Get
                Return _TEN_CHUYEN_TAU
            End Get
            Set(ByVal value As String)
                _TEN_CHUYEN_TAU = value
            End Set
        End Property
        Public Property TU_NGAY() As DateTime
            Get
                Return _TU_NGAY
            End Get
            Set(ByVal value As DateTime)
                _TU_NGAY = value
            End Set
        End Property
        Public Property TU_GIO() As String
            Get
                Return _TU_GIO
            End Get
            Set(ByVal value As String)
                _TU_GIO = value
            End Set
        End Property
        Public Property DEN_NGAY() As DateTime
            Get
                Return _DEN_NGAY
            End Get
            Set(ByVal value As DateTime)
                _DEN_NGAY = value
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
        Public Property BEN() As String
            Get
                Return _BEN
            End Get
            Set(ByVal value As String)
                _BEN = value
            End Set
        End Property
        Public Property NGAY_CAP_NHAT_CUOI() As String
            Get
                Return _NGAY_CAP_NHAT_CUOI
            End Get
            Set(ByVal value As String)
                _NGAY_CAP_NHAT_CUOI = value
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
        Public Property DA_XONG() As Boolean
            Get
                Return _DA_XONG
            End Get
            Set(ByVal value As Boolean)
                _DA_XONG = value
            End Set
        End Property
    End Class
End Namespace
