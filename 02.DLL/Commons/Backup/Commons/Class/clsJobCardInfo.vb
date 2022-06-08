Namespace VS.Classes.Catalogue
    Public Class clsJobCardInfo

        Private _PHIEU_BT As String
        Private _BO_PHAN As String
        Private _CONG_VIEC As Integer

        Private _STT As Integer
        Private _CONG_NHAN As String

        Private _NGAY As String
        Private _TU_GIO As String
        Private _DEN_GIO As String
        Private _DEN_NGAY As String

        Private _NGAY_tmp As String
        Private _TU_GIO_tmp As String
        Private _CONG_NHAN_tmp As String
        Private _HOAN_THANH As Boolean

        Public Property PHIEU_BT() As String
            Get
                Return _PHIEU_BT
            End Get
            Set(ByVal value As String)
                _PHIEU_BT = value
            End Set
        End Property
        Public Property BO_PHAN() As String
            Get
                Return _BO_PHAN
            End Get
            Set(ByVal value As String)
                _BO_PHAN = value
            End Set
        End Property
        Public Property CONG_VIEC() As Integer
            Get
                Return _CONG_VIEC
            End Get
            Set(ByVal value As Integer)
                _CONG_VIEC = value
            End Set
        End Property
        Public Property STT() As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
            End Set
        End Property
        Public Property CONG_NHAN() As String
            Get
                Return _CONG_NHAN
            End Get
            Set(ByVal value As String)
                _CONG_NHAN = value
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
        Public Property NGAY_tmp() As String
            Get
                Return _NGAY_tmp
            End Get
            Set(ByVal value As String)
                _NGAY_tmp = value
            End Set
        End Property
        Public Property TU_GIO_tmp() As String
            Get
                Return _TU_GIO_tmp
            End Get
            Set(ByVal value As String)
                _TU_GIO_tmp = value
            End Set
        End Property
        Public Property CONG_NHAN_tmp() As String
            Get
                Return _CONG_NHAN_tmp
            End Get
            Set(ByVal value As String)
                _CONG_NHAN_tmp = value
            End Set
        End Property
        Public Property HOAN_THANH() As Boolean
            Get
                Return _HOAN_THANH
            End Get
            Set(ByVal value As Boolean)
                _HOAN_THANH = value
            End Set
        End Property
    End Class
End Namespace

