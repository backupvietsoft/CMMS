Namespace VS.Classes.Catalogue
    Public Class HIEU_CHUAN_MAYInfo
        Private _MS_MAY As String
        Private _NGAY_HC As String
        Private _GIAY_CHUNG_NHAN As String
        Private _CO_QUAN_HIEU_CHUAN As String
        Private _DANH_GIA As String
        Private _TAI_LIEU As String
        Private _GHI_CHU As String
        Private _LOAI_HIEU_CHUAN As String

        Private _MS_MAY_TMP As String
        Private _NGAY_HC_TMP As String
        Private _NGAY_KH As String

        Public Property TAI_LIEU() As String
            Get
                Return _TAI_LIEU
            End Get
            Set(ByVal value As String)
                _TAI_LIEU = value
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

        Public Property LOAI_HIEU_CHUAN() As String
            Get
                Return _LOAI_HIEU_CHUAN
            End Get
            Set(ByVal value As String)
                _LOAI_HIEU_CHUAN = value
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

        Public Property NGAY_HC() As String
            Get
                Return _NGAY_HC
            End Get
            Set(ByVal value As String)
                _NGAY_HC = value
            End Set
        End Property
        Public Property MS_MAY_TMP() As String
            Get
                Return _MS_MAY_TMP
            End Get
            Set(ByVal value As String)
                _MS_MAY_TMP = value
            End Set
        End Property
        Public Property NGAY_HC_TMP() As String
            Get
                Return _NGAY_HC_TMP
            End Get
            Set(ByVal value As String)
                _NGAY_HC_TMP = value
            End Set
        End Property
        Public Property GIAY_CHUNG_NHAN() As String
            Get
                Return _GIAY_CHUNG_NHAN
            End Get
            Set(ByVal value As String)
                _GIAY_CHUNG_NHAN = value
            End Set
        End Property
        Public Property CO_QUAN_HIEU_CHUAN() As String
            Get
                Return _CO_QUAN_HIEU_CHUAN
            End Get
            Set(ByVal value As String)
                _CO_QUAN_HIEU_CHUAN = value
            End Set
        End Property
        Public Property DANH_GIA() As String
            Get
                Return _DANH_GIA
            End Get
            Set(ByVal value As String)
                _DANH_GIA = value
            End Set
        End Property
        Public Property NGAY_KH() As String
            Get
                Return _NGAY_KH
            End Get
            Set(ByVal value As String)
                _NGAY_KH = value
            End Set
        End Property

    End Class
End Namespace