Namespace VS.Classes.Catalogue
    Public Class clsEOR_PHU_TUNGInfo
        Private _EOR_ID As String
        Private _MS_PT As String
        Private _SO_LUONG As Double
        Private _DON_GIA As Double
        Private _NGOAI_TE As String
        Private _TY_GIA As Double
        Private _TY_GIA_USD As Double
        Private _MS_KH As String
        Private _NGUOI_GIAO_DICH As Integer
        Private _GHI_CHU As String
        Public Property EOR_ID() As String
            Get
                Return _EOR_ID
            End Get
            Set(ByVal value As String)
                _EOR_ID = value
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
       
        Public Property DON_GIA() As Double
            Get
                Return _DON_GIA
            End Get
            Set(ByVal value As Double)
                _DON_GIA = value
            End Set
        End Property
        Public Property SO_LUONG() As Double
            Get
                Return _SO_LUONG
            End Get
            Set(ByVal value As Double)
                _SO_LUONG = value
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
        Public Property TY_GIA() As Double
            Get
                Return _TY_GIA
            End Get
            Set(ByVal value As Double)
                _TY_GIA = value
            End Set
        End Property
        Public Property TY_GIA_USD() As Double
            Get
                Return _TY_GIA_USD
            End Get
            Set(ByVal value As Double)
                _TY_GIA_USD = value
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
        Public Property NGUOI_GIAO_DICH() As Integer
            Get
                Return _NGUOI_GIAO_DICH
            End Get
            Set(ByVal value As Integer)
                _NGUOI_GIAO_DICH = value
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
    End Class
End Namespace
