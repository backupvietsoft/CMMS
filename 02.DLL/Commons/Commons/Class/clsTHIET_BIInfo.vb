Namespace VS.Classes.Catalogue
    Public Class MAYInfo
        Private _MS_MAY As String
        Private _TEN_MAY As String
        Private _MS_NHOM_MAY As String
        Private _MS_HSX As String
        Private _MS_HIEN_TRANG As String
        Private _MS_HE_THONG As Integer
        Private _MS_KH As String
        Private _SO_NAM_KHAU_HAO As Integer
        Private _MO_TA As String
        Private _NHIEM_VU_THIET_BI As String
        Private _MODEL As String
        Private _SERIAL_NUMBER As String
        Private _NGAY_SX As Date
        Private _NUOC_SX As String
        Private _NGAY_MUA As Date
        Private _NGAY_BD_BAO_HANH As Date
        Private _NGAY_DUA_VAO_SD As Date
        Private _SO_THE As String
        Private _SO_CT As String
        Private _SO_NGAY_LV_TRONG_TUAN As Integer
        Private _SO_GIO_LV_TRONG_NGAY As Integer
        Private _MS_DVT_RT As String
        Private _TY_LE_CON_LAI As String
        Private _MUC_UU_TIEN As Integer
        Private _SO_THANG_BH As Integer
        Private _GIA_MUA As Double
        Private _TI_GIA_VND As Double
        Private _TI_GIA_USD As Double
        Private _NGOAI_TE As String
        Private _LUU_Y_SU_DUNG As String
        Private _ANH_TB As String
        Private _MS_MAY_TMP As String
        Private _MS_THONG_SO_MAY As Integer
        Private _GIA_TRI As String
        Private _GHI_CHU As String
        Private _CHU_KY_HC_TB As Integer

        Private _CHU_KY_HC_TB_NGOAI As Integer
        Private _CHU_KY_KD_TB As Integer
        Private _DON_VI_TG As Integer
        Public Property MS_MAY() As String
            Get
                Return _MS_MAY
            End Get
            Set(ByVal value As String)
                _MS_MAY = value
            End Set
        End Property
        Public Property TEN_MAY() As String
            Get
                Return _TEN_MAY
            End Get
            Set(ByVal value As String)
                _TEN_MAY = value
            End Set
        End Property
        Public Property MS_NHOM_MAY() As String
            Get
                Return _MS_NHOM_MAY
            End Get
            Set(ByVal value As String)
                _MS_NHOM_MAY = value
            End Set
        End Property
        Public Property MS_HSX() As String
            Get
                Return _MS_HSX
            End Get
            Set(ByVal value As String)
                _MS_HSX = value
            End Set
        End Property
        Public Property MS_HIEN_TRANG() As String
            Get
                Return _MS_HIEN_TRANG
            End Get
            Set(ByVal value As String)
                _MS_HIEN_TRANG = value
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
        Public Property MS_KH() As String
            Get
                Return _MS_KH
            End Get
            Set(ByVal value As String)
                _MS_KH = value
            End Set
        End Property
        Public Property SO_NAM_KHAU_HAO() As Integer
            Get
                Return _SO_NAM_KHAU_HAO
            End Get
            Set(ByVal value As Integer)
                _SO_NAM_KHAU_HAO = value
            End Set
        End Property
        Public Property MO_TA() As String
            Get
                Return _MO_TA
            End Get
            Set(ByVal value As String)
                _MO_TA = value
            End Set
        End Property
        Public Property NHIEM_VU_THIET_BI() As String
            Get
                Return _NHIEM_VU_THIET_BI
            End Get
            Set(ByVal value As String)
                _NHIEM_VU_THIET_BI = value
            End Set
        End Property
        Public Property MODEL() As String
            Get
                Return _MODEL
            End Get
            Set(ByVal value As String)
                _MODEL = value
            End Set
        End Property
        Public Property SERIAL_NUMBER() As String
            Get
                Return _SERIAL_NUMBER
            End Get
            Set(ByVal value As String)
                _SERIAL_NUMBER = value
            End Set
        End Property
        Public Property NGAY_SX() As Date
            Get
                Return _NGAY_SX
            End Get
            Set(ByVal value As Date)
                _NGAY_SX = value
            End Set
        End Property
        Public Property NUOC_SX() As String
            Get
                Return _NUOC_SX
            End Get
            Set(ByVal value As String)
                _NUOC_SX = value
            End Set
        End Property
        Public Property NGAY_MUA() As Date
            Get
                Return _NGAY_MUA
            End Get
            Set(ByVal value As Date)
                _NGAY_MUA = value
            End Set
        End Property
        Public Property NGAY_BD_BAO_HANH() As Date
            Get
                Return _NGAY_BD_BAO_HANH
            End Get
            Set(ByVal value As Date)
                _NGAY_BD_BAO_HANH = value
            End Set
        End Property
        Public Property NGAY_DUA_VAO_SD() As Date
            Get
                Return _NGAY_DUA_VAO_SD
            End Get
            Set(ByVal value As Date)
                _NGAY_DUA_VAO_SD = value
            End Set
        End Property
        Public Property SO_THE() As String
            Get
                Return _SO_THE
            End Get
            Set(ByVal value As String)
                _SO_THE = value
            End Set
        End Property
        Public Property SO_CT() As String
            Get
                Return _SO_CT
            End Get
            Set(ByVal value As String)
                _SO_CT = value
            End Set
        End Property
        Public Property SO_NGAY_LV_TRONG_TUAN() As Integer
            Get
                Return _SO_NGAY_LV_TRONG_TUAN
            End Get
            Set(ByVal value As Integer)
                _SO_NGAY_LV_TRONG_TUAN = value
            End Set
        End Property
        Public Property SO_GIO_LV_TRONG_NGAY() As Integer
            Get
                Return _SO_GIO_LV_TRONG_NGAY
            End Get
            Set(ByVal value As Integer)
                _SO_GIO_LV_TRONG_NGAY = value
            End Set
        End Property
        Public Property MS_DVT_RT() As String
            Get
                Return _MS_DVT_RT
            End Get
            Set(ByVal value As String)
                _MS_DVT_RT = value
            End Set
        End Property
        Public Property TY_LE_CON_LAI() As String
            Get
                Return _TY_LE_CON_LAI
            End Get
            Set(ByVal value As String)
                _TY_LE_CON_LAI = value
            End Set
        End Property
        Public Property MUC_UU_TIEN() As Integer
            Get
                Return _MUC_UU_TIEN
            End Get
            Set(ByVal value As Integer)
                _MUC_UU_TIEN = value
            End Set
        End Property
        Public Property SO_THANG_BH() As Integer
            Get
                Return _SO_THANG_BH
            End Get
            Set(ByVal value As Integer)
                _SO_THANG_BH = value
            End Set
        End Property
        Public Property GIA_MUA() As Double
            Get
                Return _GIA_MUA
            End Get
            Set(ByVal value As Double)
                _GIA_MUA = value
            End Set
        End Property
        Public Property TI_GIA_VND() As Double
            Get
                Return _TI_GIA_VND
            End Get
            Set(ByVal value As Double)
                _TI_GIA_VND = value
            End Set
        End Property
        Public Property TI_GIA_USD() As Double
            Get
                Return _TI_GIA_USD
            End Get
            Set(ByVal value As Double)
                _TI_GIA_USD = value
            End Set
        End Property
        Public Property NGOAI_TE() As String
            Get
                Return _NGOAI_TE
            End Get
            Set(ByVal value As String)
                _NGOAI_TE = value
            End Set
        End Property
        Public Property LUU_Y_SU_DUNG() As String
            Get
                Return _LUU_Y_SU_DUNG
            End Get
            Set(ByVal value As String)
                _LUU_Y_SU_DUNG = value
            End Set
        End Property
        Public Property ANH_TB() As String
            Get
                Return _ANH_TB
            End Get
            Set(ByVal value As String)
                _ANH_TB = value
            End Set
        End Property

        Public Property MS_THONG_SO_MAY() As Integer
            Get
                Return _MS_THONG_SO_MAY
            End Get
            Set(ByVal value As Integer)
                _MS_THONG_SO_MAY = value
            End Set
        End Property

        Public Property GIA_TRI() As String
            Get
                Return _GIA_TRI
            End Get
            Set(ByVal value As String)
                _GIA_TRI = value
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

        Public Property MS_MAY_TMP() As String
            Get
                Return _MS_MAY_TMP
            End Get
            Set(ByVal value As String)
                _MS_MAY_TMP = value
            End Set
        End Property
        Public Property CHU_KY_HC_TB() As Integer
            Get
                Return _CHU_KY_HC_TB
            End Get
            Set(ByVal value As Integer)
                _CHU_KY_HC_TB = value
            End Set
        End Property

        Public Property CHU_KY_HC_TB_NGOAI() As Integer
            Get
                Return _CHU_KY_HC_TB_NGOAI
            End Get
            Set(ByVal value As Integer)
                _CHU_KY_HC_TB_NGOAI = value
            End Set
        End Property
        Public Property CHU_KY_KD_TB() As Integer
            Get
                Return _CHU_KY_KD_TB
            End Get
            Set(ByVal value As Integer)
                _CHU_KY_KD_TB = value
            End Set
        End Property
        Public Property DON_VI_TG() As Integer
            Get
                Return _DON_VI_TG
            End Get
            Set(ByVal value As Integer)
                _DON_VI_TG = value
            End Set
        End Property
    End Class
End Namespace