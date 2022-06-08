Namespace VS.Classes.Catalogue
    Public Class clsTHOI_GIAN_NHUNG_MAYInfo
        Private _MS_MAY As String
        Private _NGAY As String
        Private _DEN_NGAY As String
        Private _TU_GIO As String
        Private _DEN_GIO As String
        Private _MS_NGUYEN_NHAN As Integer
        Private _MS_PHIEU_BAO_TRI As String
        Private _GHI_CHU As String
        Private _NGUOI_GIAI_QUYET As String
        Private _DUNG As Boolean
        Private _MS_HE_THONG As String
        Private _THOI_GIAN_SUA_CHUA As Double
        Private _MS_N_XUONG As String
        Private _STT As Integer

        Private _NGAY_SUA As String
        Private _GIO_SUA As String
        Private _NGUOI_DUNG_MAY As String

        Public Property NGUOI_DUNG_MAY() As String
            Get
                Return _NGUOI_DUNG_MAY
            End Get
            Set(ByVal value As String)
                _NGUOI_DUNG_MAY = value
            End Set
        End Property


        Public Property NGAY_SUA() As String
            Get
                Return _NGAY_SUA
            End Get
            Set(ByVal value As String)
                _NGAY_SUA = value
            End Set
        End Property

        Public Property GIO_SUA() As String
            Get
                Return _GIO_SUA
            End Get
            Set(ByVal value As String)
                _GIO_SUA = value
            End Set
        End Property

        'HIEU THEM 13/06/08
        Public Property STT() As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
            End Set
        End Property

        'HIEU THEM 13/06/08
        Public Property THOI_GIAN_SUA_CHUA() As Double
            Get
                Return _THOI_GIAN_SUA_CHUA
            End Get
            Set(ByVal value As Double)
                _THOI_GIAN_SUA_CHUA = value
            End Set
        End Property

        Public Property MS_N_XUONG() As String
            Get
                Return _MS_N_XUONG
            End Get
            Set(ByVal value As String)
                _MS_N_XUONG = value
            End Set
        End Property
        Public Property MS_HE_THONG() As Integer
            Get
                Return _MS_HE_THONG
            End Get
            Set(ByVal value As Integer)
                _MS_HE_THONG = value
            End Set
        End Property

        Public Property MS_MAY() As String
            Get
                Return _MS_MAY
            End Get
            Set(ByVal value As String)
                _MS_MAY = value
            End Set
        End Property
        Public Property NGAY() As String
            Get
                Return _NGAY
            End Get
            Set(ByVal value As String)
                _NGAY = value
            End Set
        End Property
        Public Property DEN_NGAY() As String
            Get
                Return _DEN_NGAY
            End Get
            Set(ByVal value As String)
                _DEN_NGAY = value
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
        Public Property DEN_GIO() As String
            Get
                Return _DEN_GIO
            End Get
            Set(ByVal value As String)
                _DEN_GIO = value
            End Set
        End Property
        Public Property MS_NGUYEN_NHAN() As Integer
            Get
                Return _MS_NGUYEN_NHAN
            End Get
            Set(ByVal value As Integer)
                _MS_NGUYEN_NHAN = value
            End Set
        End Property
        Public Property MS_PHIEU_BAO_TRI() As String
            Get
                Return _MS_PHIEU_BAO_TRI
            End Get
            Set(ByVal value As String)
                _MS_PHIEU_BAO_TRI = value
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
        Public Property NGUOI_GIAI_QUYET() As String
            Get
                Return _NGUOI_GIAI_QUYET
            End Get
            Set(ByVal value As String)
                _NGUOI_GIAI_QUYET = value
            End Set
        End Property
        Public Property DUNG() As Boolean
            Get
                Return _DUNG
            End Get
            Set(ByVal value As Boolean)
                _DUNG = value
            End Set
        End Property
    End Class
End Namespace
