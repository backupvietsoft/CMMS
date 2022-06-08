Namespace VS.Classes.Catalogue
    Public Class clsGIAM_SAT_TINH_TRANG_HINHInfo

        Private _STT As Integer
        Private _MS_MAY As String
        Private _MS_TS_GSTT As String
        Private _MS_BO_PHAN As String
        Private _MS_TT As Integer
        Private _STT_HINH As Integer
        Private _DUONG_DAN As String
        Private _GHI_CHU As String
        Private _HINH As String

        Public Property STT() As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
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
        Public Property MS_TS_GSTT() As String
            Get
                Return _MS_TS_GSTT
            End Get
            Set(ByVal value As String)
                _MS_TS_GSTT = value
            End Set
        End Property
        Public Property MS_BO_PHAN() As String
            Get
                Return _MS_BO_PHAN
            End Get
            Set(ByVal value As String)
                _MS_BO_PHAN = value
            End Set
        End Property
        Public Property MS_TT() As Integer
            Get
                Return _MS_TT
            End Get
            Set(ByVal value As Integer)
                _MS_TT = value
            End Set
        End Property
        Public Property STT_HINH() As Integer
            Get
                Return _STT_HINH
            End Get
            Set(ByVal value As Integer)
                _STT_HINH = value
            End Set
        End Property
        
        Public Property DUONG_DAN() As String
            Get
                Return _DUONG_DAN
            End Get
            Set(ByVal value As String)
                _DUONG_DAN = value
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
        Public Property HINH() As String
            Get
                Return _HINH
            End Get
            Set(ByVal value As String)
                _HINH = value
            End Set
        End Property
    End Class
End Namespace


