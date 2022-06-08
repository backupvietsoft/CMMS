Namespace VS.Classes.Catalogue
    Public Class clsEOR_TINH_TRANGInfo
        Private _EOR_ID As String
        Private _STT As Integer
        Private _BO_PHAN As String
        Private _MS_TINH_TRANG As Integer
        Private _MS_GIAI_PHAP As Integer
        Private _BO_PHAN_TMP As String
        Private _MS_TINH_TRANG_TMP As Integer
        Private _MS_GIAI_PHAP_TMP As Integer
        Public Property EOR_ID() As String
            Get
                Return _EOR_ID
            End Get
            Set(ByVal value As String)
                _EOR_ID = value
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
        Public Property BO_PHAN() As String
            Get
                Return _BO_PHAN
            End Get
            Set(ByVal value As String)
                _BO_PHAN = value
            End Set
        End Property
        Public Property MS_TINH_TRANG() As Integer
            Get
                Return _MS_TINH_TRANG
            End Get
            Set(ByVal value As Integer)
                _MS_TINH_TRANG = value
            End Set
        End Property
        Public Property MS_GIAI_PHAP() As Integer
            Get
                Return _MS_GIAI_PHAP
            End Get
            Set(ByVal value As Integer)
                _MS_GIAI_PHAP = value
            End Set
        End Property
        Public Property BO_PHAN_TMP() As String
            Get
                Return _BO_PHAN_TMP
            End Get
            Set(ByVal value As String)
                _BO_PHAN_TMP = value
            End Set
        End Property
        Public Property MS_GIAI_PHAP_TMP() As Integer
            Get
                Return _MS_GIAI_PHAP_TMP
            End Get
            Set(ByVal value As Integer)
                _MS_GIAI_PHAP_TMP = value
            End Set
        End Property
        Public Property MS_TINH_TRANG_TMP() As Integer
            Get
                Return _MS_TINH_TRANG_TMP
            End Get
            Set(ByVal value As Integer)
                _MS_TINH_TRANG_TMP = value
            End Set
        End Property
    End Class
End Namespace
