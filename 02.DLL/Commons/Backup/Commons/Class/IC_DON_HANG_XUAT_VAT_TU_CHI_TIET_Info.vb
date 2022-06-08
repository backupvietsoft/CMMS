Namespace VS.Classes.Catalogue
    Public Class IC_DON_HANG_XUAT_VAT_TU_CHI_TIET_Info
        Private _MS_DH_XUAT_PT As String
        Private _MS_PT As String
        Private _STT As Integer
        Private _MS_DH_NHAP_PT As String
        Private _MS_VI_TRI As Integer
        Private _SL_VT As String
        Private _ID_XUAT As Double
        Private _DON_GIA As Double
        Private _TEN_NGOAI_TE As String


        Public Property MS_DH_XUAT_PT() As String
            Get
                Return _MS_DH_XUAT_PT
            End Get
            Set(ByVal value As String)
                _MS_DH_XUAT_PT = value
            End Set
        End Property
        Public Property MS_PT() As String
            Get
                Return _MS_PT
            End Get
            Set(ByVal value As String)
                _MS_PT = value
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
        Public Property MS_DH_NHAP_PT() As String
            Get
                Return _MS_DH_NHAP_PT
            End Get
            Set(ByVal value As String)
                _MS_DH_NHAP_PT = value
            End Set
        End Property
        Public Property MS_VI_TRI() As Integer
            Get
                Return _MS_VI_TRI
            End Get
            Set(ByVal value As Integer)
                _MS_VI_TRI = value
            End Set
        End Property
        Public Property SL_VT() As String
            Get
                Return _SL_VT
            End Get
            Set(ByVal value As String)
                _SL_VT = value
            End Set
        End Property
        Public Property ID_XUAT() As Double
            Get
                Return _ID_XUAT
            End Get
            Set(ByVal value As Double)
                _ID_XUAT = value
            End Set
        End Property


        Public Property DON_GIA() As Double
            Get
                Return _DON_GIA
            End Get
            Set(ByVal value As Double)
                _DON_GIA = value
            End Set
        End Property

        Public Property TEN_NGOAI_TE() As String
            Get
                Return _TEN_NGOAI_TE
            End Get
            Set(ByVal value As String)
                _TEN_NGOAI_TE = value
            End Set
        End Property

    End Class
End Namespace