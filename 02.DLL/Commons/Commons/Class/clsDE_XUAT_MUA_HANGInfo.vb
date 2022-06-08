Namespace VS.Classes.Catalogue
    Public Class clsDE_XUAT_MUA_HANGInfo
        Private _SO_DE_XUAT As String
        Private _SO_DE_XUAT_CU As String
        Private _MS_DON_VI As String
        Private _NGAY As String
        Private _NGUOI_NHAN As String
        Private _NGUOI_DUYET As String
        Private _NGAY_GIAO As String
        Private _TO_PHONG_BAN As String
        Private _THEOKH As Integer
        Private _THEOYEUCAU As Integer
        Private _GHI_CHU As String

        Public Property GHI_CHU() As String
            Get
                Return _GHI_CHU
            End Get
            Set(ByVal value As String)
                _GHI_CHU = value
            End Set
        End Property

        Public Property THEOKH() As Integer
            Get
                Return _THEOKH
            End Get
            Set(ByVal value As Integer)
                _THEOKH = value
            End Set
        End Property

        Public Property THEOYEUCAU() As Integer
            Get
                Return _THEOYEUCAU
            End Get
            Set(ByVal value As Integer)
                _THEOYEUCAU = value
            End Set
        End Property

        Public Property SO_DE_XUAT() As String
            Get
                Return _SO_DE_XUAT
            End Get
            Set(ByVal value As String)
                _SO_DE_XUAT = value
            End Set
        End Property
        Public Property SO_DE_XUAT_CU() As String
            Get
                Return _SO_DE_XUAT_CU
            End Get
            Set(ByVal value As String)
                _SO_DE_XUAT_CU = value
            End Set
        End Property
        Public Property MS_DON_VI() As String
            Get
                Return _MS_DON_VI
            End Get
            Set(ByVal value As String)
                _MS_DON_VI = value
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
        Public Property NGUOI_NHAN() As String
            Get
                Return _NGUOI_NHAN
            End Get
            Set(ByVal value As String)
                _NGUOI_NHAN = value
            End Set
        End Property
        Public Property NGUOI_DUYET() As String
            Get
                Return _NGUOI_DUYET
            End Get
            Set(ByVal value As String)
                _NGUOI_DUYET = value
            End Set
        End Property
        Public Property NGAY_GIAO() As String
            Get
                Return _NGAY_GIAO
            End Get
            Set(ByVal value As String)
                _NGAY_GIAO = value
            End Set
        End Property
        Public Property TO_PHONG_BAN() As String
            Get
                Return _TO_PHONG_BAN
            End Get
            Set(ByVal value As String)
                _TO_PHONG_BAN = value
            End Set
        End Property
    End Class
End Namespace
