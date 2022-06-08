Namespace VS.Classes.Catalogue

    Public Class clsCONG_VIEC_HANG_NGAY_TBInfo
        Private _STT_CV As Integer
        Private _MS_MAY As String
        Private _NOI_DUNG As String
        Private _CHI_PHI_NC As Double
        Private _CHI_PHI_VT As Double
        Public Property STT_CV() As Integer
            Get
                Return _STT_CV
            End Get
            Set(ByVal value As Integer)
                _STT_CV = value
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
        Public Property NOI_DUNG() As String
            Get
                Return _NOI_DUNG
            End Get
            Set(ByVal value As String)
                _NOI_DUNG = value
            End Set
        End Property
        Public Property CHI_PHI_NC() As Double
            Get
                Return _CHI_PHI_NC
            End Get
            Set(ByVal value As Double)
                _CHI_PHI_NC = value
            End Set
        End Property
        Public Property CHI_PHI_VT() As Double
            Get
                Return _CHI_PHI_VT
            End Get
            Set(ByVal value As Double)
                _CHI_PHI_VT = value
            End Set
        End Property
    End Class
End Namespace
