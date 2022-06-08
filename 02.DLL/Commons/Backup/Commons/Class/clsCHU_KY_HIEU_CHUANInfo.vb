Namespace VS.Classes.Catalogue

    Public Class CHU_KY_HIEU_CHUANInfo
        Private _MS_MAY As String
        Private _MS_PT As String
        Private _MS_VI_TRI As String
        Private _CHU_KY_HC_NOI As Integer
        Private _CHU_KY_HC_NGOAI As Integer
        Private _MS_DV_TG As Integer
        Private _GHI_CHU As String
        Private _TEN_VI_TRI As String

        Private _CHU_KY_KD As Integer
        Private _CHU_KY_KT As Integer

        Public Property TEN_VI_TRI() As String
            Get
                Return _TEN_VI_TRI
            End Get
            Set(ByVal value As String)
                _TEN_VI_TRI = value
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
        Public Property MS_PT() As String
            Get
                Return _MS_PT
            End Get
            Set(ByVal value As String)
                _MS_PT = value
            End Set
        End Property
        Public Property MS_VI_TRI() As String
            Get
                Return _MS_VI_TRI
            End Get
            Set(ByVal value As String)
                _MS_VI_TRI = value
            End Set
        End Property
        Public Property CHU_KY_HC_NOI() As Integer
            Get
                Return _CHU_KY_HC_NOI
            End Get
            Set(ByVal value As Integer)
                _CHU_KY_HC_NOI = value
            End Set
        End Property
        Public Property CHU_KY_HC_NGOAI() As Integer
            Get
                Return _CHU_KY_HC_NGOAI
            End Get
            Set(ByVal value As Integer)
                _CHU_KY_HC_NGOAI = value
            End Set
        End Property
        Public Property MS_DV_TG() As Integer
            Get
                Return _MS_DV_TG
            End Get
            Set(ByVal value As Integer)
                _MS_DV_TG = value
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

        Public Property CHU_KY_KD() As Integer
            Get
                Return _CHU_KY_KD
            End Get
            Set(ByVal value As Integer)
                _CHU_KY_KD = value
            End Set
        End Property
        Public Property CHU_KY_KT() As Integer
            Get
                Return _CHU_KY_KT
            End Get
            Set(ByVal value As Integer)
                _CHU_KY_KT = value
            End Set
        End Property
    End Class
End Namespace