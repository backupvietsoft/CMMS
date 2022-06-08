
'Namespace VS.Classes.Catalogue
Public Class clsTHONG_TIN_CHUNGInfo
    Private _STT As Integer
    Private _TEN_CTY_TIENG_VIET As String
    Private _TEN_CTY_TIENG_ANH As String
    Private _TEN_NGAN_TIENG_VIET As String
    Private _TEN_NGAN_TIENG_ANH As String
    Private _LOGO As Byte()
    Private _LOGO_PATH As String
    Private _DIA_CHI_VIET As String
    Private _DIA_CHI_ANH As String
    Private _Phone As String
    Private _Fax As String
    Private _WIDTH As Integer
    Private _HEIGHT As Integer
    Private _TI_LE_PHAN_TRAM As Integer
    Private _STRETCH As Boolean
    Private _LE_PHAI_LOGO As Integer
    Private _LE_TREN_LOGO As Integer
    Private _LOGO_TEN_CTY As Integer
    Private _LIM_NUMBER As String
    Private _USE_NUMBER As String
    Private _NGAY_TAO As DateTime
    Private _VI_TRI_KHO As Boolean
    Private _DUONG_DAN_TL As String
    Public Property STT() As Integer
        Get
            Return _STT
        End Get
        Set(ByVal value As Integer)
            _STT = value
        End Set
    End Property
    Public Property TEN_CTY_TIENG_VIET() As String
        Get
            Return _TEN_CTY_TIENG_VIET
        End Get
        Set(ByVal value As String)
            _TEN_CTY_TIENG_VIET = value
        End Set
    End Property
    Public Property TEN_CTY_TIENG_ANH() As String
        Get
            Return _TEN_CTY_TIENG_ANH
        End Get
        Set(ByVal value As String)
            _TEN_CTY_TIENG_ANH = value
        End Set
    End Property
    Public Property TEN_NGAN_TIENG_ANH() As String
        Get
            Return _TEN_NGAN_TIENG_ANH
        End Get
        Set(ByVal value As String)
            _TEN_NGAN_TIENG_ANH = value
        End Set
    End Property
    Public Property TEN_NGAN_TIENG_VIET() As String
        Get
            Return _TEN_NGAN_TIENG_VIET
        End Get
        Set(ByVal value As String)
            _TEN_NGAN_TIENG_VIET = value
        End Set
    End Property
    Public Property LOGO() As Byte()
        Get
            Return _LOGO
        End Get
        Set(ByVal value As Byte())
            _LOGO = value
        End Set
    End Property
    Public Property LOGO_PATH() As String
        Get
            Return _LOGO_PATH
        End Get
        Set(ByVal value As String)
            _LOGO_PATH = value
        End Set
    End Property
    Public Property PHONE() As String
        Get
            Return _Phone
        End Get
        Set(ByVal value As String)
            _Phone = value
        End Set
    End Property
    Public Property FAX() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            _Fax = value
        End Set
    End Property
    Public Property WIDTH() As Integer
        Get
            Return _WIDTH
        End Get
        Set(ByVal value As Integer)
            _WIDTH = value
        End Set
    End Property
    Public Property HEIGHT() As Integer
        Get
            Return _HEIGHT
        End Get
        Set(ByVal value As Integer)
            _HEIGHT = value
        End Set
    End Property
    Public Property TI_LE_PHAN_TRAM() As Integer
        Get
            Return _TI_LE_PHAN_TRAM
        End Get
        Set(ByVal value As Integer)
            _TI_LE_PHAN_TRAM = value
        End Set
    End Property

    Public Property STRETCH() As Boolean
        Get
            Return _STRETCH
        End Get
        Set(ByVal value As Boolean)
            _STRETCH = value
        End Set
    End Property
    Public Property LE_PHAI_LOGO() As Integer
        Get
            Return _LE_PHAI_LOGO
        End Get
        Set(ByVal value As Integer)
            _LE_PHAI_LOGO = value
        End Set
    End Property
    Public Property LE_TREN_LOGO() As Integer
        Get
            Return _LE_TREN_LOGO
        End Get
        Set(ByVal value As Integer)
            _LE_TREN_LOGO = value
        End Set
    End Property
    Public Property LOGO_TEN_CTY() As Integer
        Get
            Return _LOGO_TEN_CTY
        End Get
        Set(ByVal value As Integer)
            _LOGO_TEN_CTY = value
        End Set
    End Property
    Public Property LIM_NUMBER() As String
        Get
            Return _LIM_NUMBER
        End Get
        Set(ByVal value As String)
            _LIM_NUMBER = value
        End Set
    End Property
    Public Property USE_NUMBER() As String
        Get
            Return _USE_NUMBER
        End Get
        Set(ByVal value As String)
            _USE_NUMBER = value
        End Set
    End Property
    Public Property NGAY_TAO() As DateTime
        Get
            Return _NGAY_TAO
        End Get
        Set(ByVal value As DateTime)
            _NGAY_TAO = value
        End Set
    End Property
    Public Property VI_TRI_KHO() As Boolean
        Get
            Return _VI_TRI_KHO
        End Get
        Set(ByVal value As Boolean)
            _VI_TRI_KHO = value
        End Set
    End Property
    Public Property DUONG_DAN_TL() As String
        Get
            Return _DUONG_DAN_TL
        End Get
        Set(ByVal value As String)
            _DUONG_DAN_TL = value
        End Set
    End Property
End Class
'End Namespace
