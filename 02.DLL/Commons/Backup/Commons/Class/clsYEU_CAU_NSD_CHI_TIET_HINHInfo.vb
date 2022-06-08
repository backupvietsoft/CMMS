Namespace VS.Classes
    Public Class clsYEU_CAU_NSD_CHI_TIET_HINHInfo
        Private _STT As Integer
        Private _MS_MAY As String
        Private _STT_VAN_DE As Integer
        Private _STT_HINH As Integer
        Private _DUONG_DAN As String
        Private _GHI_CHU As String

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
        Public Property STT_VAN_DE() As Integer
            Get
                Return _STT_VAN_DE
            End Get
            Set(ByVal value As Integer)
                _STT_VAN_DE = value
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
    End Class
End Namespace
