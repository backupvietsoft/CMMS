Public Class DON_VIInfo    Private _MS_DON_VI As String    Private _TEN_DON_VI As String    Private _TEN_NGAN As String    Private _DIA_CHI As String    Private _THUE_NGOAI As Boolean    Private _MAC_DINH As Boolean    Private _DIEN_THOAI As String    Private _FAX As String    Private _MS_DON_VI_tmp As String    Private _TEN_RUT_GON As String    Public Property MS_DON_VI() As String        Get            Return _MS_DON_VI        End Get        Set(ByVal value As String)            _MS_DON_VI = value        End Set    End Property    Public Property TEN_DON_VI() As String        Get            return _TEN_DON_VI        End Get        Set(Byval value As String)            _TEN_DON_VI = value        End Set    End Property    Public Property TEN_NGAN() As String        Get            return _TEN_NGAN        End Get        Set(Byval value As String)            _TEN_NGAN = value        End Set    End Property    Public Property DIA_CHI() As String        Get            return _DIA_CHI        End Get        Set(Byval value As String)            _DIA_CHI = value        End Set    End Property    Public Property THUE_NGOAI() As Boolean        Get            return _THUE_NGOAI        End Get        Set(Byval value As Boolean)            _THUE_NGOAI = value        End Set    End Property    Public Property MAC_DINH() As Boolean        Get            return _MAC_DINH        End Get        Set(Byval value As Boolean)            _MAC_DINH = value        End Set    End Property    Public Property DIEN_THOAI() As String        Get            return _DIEN_THOAI        End Get        Set(Byval value As String)            _DIEN_THOAI = value        End Set    End Property    Public Property FAX() As String        Get            return _FAX        End Get        Set(Byval value As String)            _FAX = value        End Set    End Property    Public Property MS_DON_VI_tmp() As String        Get            Return _MS_DON_VI_tmp        End Get        Set(ByVal value As String)            _MS_DON_VI_tmp = value        End Set    End Property    Public Property TEN_RUT_GON() As String        Get            Return _TEN_RUT_GON        End Get        Set(ByVal value As String)            _TEN_RUT_GON = value        End Set    End PropertyEnd Class