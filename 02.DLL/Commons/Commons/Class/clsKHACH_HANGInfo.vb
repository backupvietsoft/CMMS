Namespace VS.Classes.Catalogue
    Public Class KHACH_HANGInfo
        Private _MS_KH As String
        Private _TEN_CONG_TY As String
        Private _DIA_CHI As String
        Private _TEL As String
        Private _FAX As String
        Private _TEN_NDD As String
        Private _TEN_RUT_GON As String
        Private _EMAIL As String
        Private _MS_KH_tmp As String
        Private _QUOCGIA As String
        Private _TAI_KHOAN_ANH As String
        Private _MS_THUE As String
        ' Người đại diện.

        Private _STT As Integer
        Private _TEN_NDD2 As String
        Private _CHUC_VU As String
        Private _DI_DONG As String
        Private _TEL2 As String
        Private _HOME_TEL As String
        Private _EMAIL2 As String
        Private _GHI_CHU As String
        Private _HOME_ADD As String
        Public Property MS_THUE() As String
            Get
                Return _MS_THUE
            End Get
            Set(ByVal value As String)
                _MS_THUE = value
            End Set
        End Property

        Public Property TAI_KHOAN_ANH() As String
            Get
                Return _TAI_KHOAN_ANH
            End Get
            Set(ByVal value As String)
                _TAI_KHOAN_ANH = value
            End Set
        End Property

        Public Property MS_KH() As String
            Get
                Return _MS_KH
            End Get
            Set(ByVal value As String)
                _MS_KH = value
            End Set
        End Property
        Public Property TEN_CONG_TY() As String
            Get
                Return _TEN_CONG_TY
            End Get
            Set(ByVal value As String)
                _TEN_CONG_TY = value
            End Set
        End Property
        Public Property DIA_CHI() As String
            Get
                Return _DIA_CHI
            End Get
            Set(ByVal value As String)
                _DIA_CHI = value
            End Set
        End Property
        Public Property TEL() As String
            Get
                Return _TEL
            End Get
            Set(ByVal value As String)
                _TEL = value
            End Set
        End Property
        Public Property FAX() As String
            Get
                Return _FAX
            End Get
            Set(ByVal value As String)
                _FAX = value
            End Set
        End Property
        Public Property TEN_NDD() As String
            Get
                Return _TEN_NDD
            End Get
            Set(ByVal value As String)
                _TEN_NDD = value
            End Set
        End Property

        Public Property TEN_RUT_GON() As String
            Get
                Return _TEN_RUT_GON
            End Get
            Set(ByVal value As String)
                _TEN_RUT_GON = value
            End Set
        End Property
        Public Property EMAIL() As String
            Get
                Return _EMAIL
            End Get
            Set(ByVal value As String)
                _EMAIL = value
            End Set
        End Property
        Public Property MS_KH_tmp() As String
            Get
                Return _MS_KH_tmp
            End Get
            Set(ByVal value As String)
                _MS_KH_tmp = value
            End Set
        End Property

        Public Property QUOCGIA() As String
            Get
                Return _QUOCGIA
            End Get
            Set(ByVal value As String)
                _QUOCGIA = value
            End Set
        End Property

        ' Người đại diện
        Public Property STT() As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
            End Set
        End Property
        Public Property CHUC_VU() As String
            Get
                Return _CHUC_VU
            End Get
            Set(ByVal value As String)
                _CHUC_VU = value
            End Set
        End Property
        Public Property NGUOI_DAI_DIEN() As String
            Get
                Return _TEN_NDD2
            End Get
            Set(ByVal value As String)
                _TEN_NDD2 = value
            End Set
        End Property
        Public Property DI_DONG() As String
            Get
                Return _DI_DONG
            End Get
            Set(ByVal value As String)
                _DI_DONG = value
            End Set
        End Property
        Public Property DIEN_THOAI() As String
            Get
                Return _TEL2
            End Get
            Set(ByVal value As String)
                _TEL2 = value
            End Set
        End Property
        Public Property DIEN_THOAI_NHA() As String
            Get
                Return _HOME_TEL
            End Get
            Set(ByVal value As String)
                _HOME_TEL = value
            End Set
        End Property
        Public Property EMAIL2() As String
            Get
                Return _EMAIL2
            End Get
            Set(ByVal value As String)
                _EMAIL2 = value
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
        Public Property DIA_CHI_NHA_RIENG() As String
            Get
                Return _HOME_ADD
            End Get
            Set(ByVal value As String)
                _HOME_ADD = value
            End Set
        End Property
    End Class
End Namespace

