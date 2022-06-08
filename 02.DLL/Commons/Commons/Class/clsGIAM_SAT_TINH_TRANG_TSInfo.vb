
Namespace VS.Classes.Catalogue
    Public Class clsGIAM_SAT_TINH_TRANG_TSInfo
        Private _STT As Integer
        Private _MS_MAY As String
        Private _MS_TS_GSTT As String
        Private _MS_BO_PHAN As String
        Private _GIA_TRI_DO As String
        Private _MS_TT As Integer

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

        Public Property GIA_TRI_DO() As String
            Get
                Return _GIA_TRI_DO
            End Get
            Set(ByVal value As String)
                _GIA_TRI_DO = value
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

        Private _MS_CONG_NHAN As String
        Public Property MS_CONG_NHAN() As String
            Get
                Return _MS_CONG_NHAN
            End Get
            Set(ByVal value As String)
                _MS_CONG_NHAN = value
            End Set
        End Property

        'Private _TG_XU_LY As DateTime
        'Public Property TG_XU_LY() As DateTime
        '    Get
        '        Return _TG_XU_LY
        '    End Get
        '    Set(ByVal value As DateTime)
        '        _TG_XU_LY = value
        '    End Set
        'End Property

        Private _MS_PBT As String
        Public Property MS_PBT() As String
            Get
                Return _MS_PBT
            End Get
            Set(ByVal value As String)
                _MS_PBT = value
            End Set
        End Property

        Private _HANG_MUC_ID_KE_HOACH As Integer
        Public Property HANG_MUC_ID_KE_HOACH() As Integer
            Get
                Return _HANG_MUC_ID_KE_HOACH
            End Get
            Set(ByVal value As Integer)
                _HANG_MUC_ID_KE_HOACH = value
            End Set
        End Property

        Private _USERNAME As String
        Public Property USERNAME() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
                _USERNAME = value
            End Set
        End Property

        Private _STT_VAN_DE As Integer
        Public Property STT_VAN_DE() As Integer
            Get
                Return _STT_VAN_DE
            End Get
            Set(ByVal value As Integer)
                _STT_VAN_DE = value
            End Set
        End Property

        Private _GHI_CHU As String
        Public Property GHI_CHU() As String
            Get
                Return _GHI_CHU
            End Get
            Set(ByVal value As String)
                _GHI_CHU = value
            End Set
        End Property

        Private _TG_TT As Double
        Public Property TG_TT() As Double
            Get
                Return _TG_TT
            End Get
            Set(ByVal value As Double)
                _TG_TT = value
            End Set
        End Property

        Private _THOI_GIAN As Double
        Public Property THOI_GIAN() As Double
            Get
                Return _THOI_GIAN
            End Get
            Set(ByVal value As Double)
                _THOI_GIAN = value
            End Set
        End Property
        Private _MS_CACH_TH As String
        Public Property MS_CACH_TH() As String
            Get
                Return _MS_CACH_TH
            End Get
            Set(ByVal value As String)
                _MS_CACH_TH = value
            End Set
        End Property
        Private _CACH_THUC_HIEN As String
        Public Property CACH_THUC_HIEN() As String
            Get
                Return _CACH_THUC_HIEN
            End Get
            Set(ByVal value As String)
                _CACH_THUC_HIEN = value
            End Set
        End Property

        Private _TIEU_CHUAN_KT As String
        Public Property TIEU_CHUAN_KT() As String
            Get
                Return _TIEU_CHUAN_KT
            End Get
            Set(ByVal value As String)
                _TIEU_CHUAN_KT = value
            End Set
        End Property

        Private _YEU_CAU_NS As String
        Public Property YEU_CAU_NS() As String
            Get
                Return _YEU_CAU_NS
            End Get
            Set(ByVal value As String)
                _YEU_CAU_NS = value
            End Set
        End Property

        Private _YEU_CAU_DUNG_CU As String
        Public Property YEU_CAU_DUNG_CU() As String
            Get
                Return _YEU_CAU_DUNG_CU
            End Get
            Set(ByVal value As String)
                _YEU_CAU_DUNG_CU = value
            End Set
        End Property

        Private _PATH_HD As String
        Public Property PATH_HD() As String
            Get
                Return _PATH_HD
            End Get
            Set(ByVal value As String)
                _PATH_HD = value
            End Set
        End Property

        'Private _ID_DD As Int64
        'Public Property ID_DD() As Int64
        '    Get
        '        Return _ID_DD
        '    End Get
        '    Set(ByVal value As Int64)
        '        _ID_DD = value
        '    End Set
        'End Property

        'Private _DD_SN As Double
        'Public Property DD_SN() As Double
        '    Get
        '        Return _DD_SN
        '    End Get
        '    Set(ByVal value As Double)
        '        _DD_SN = value
        '    End Set
        'End Property

        'Private _DD_NGAY As DateTime
        'Public Property DD_NGAY() As DateTime
        '    Get
        '        Return _DD_NGAY
        '    End Get
        '    Set(ByVal value As DateTime)
        '        _DD_NGAY = value
        '    End Set
        'End Property
    End Class
End Namespace
