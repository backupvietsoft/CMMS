Namespace VS.Classes.Catalogue
    Public Class clsLICH_TAU_THIET_BInfo
        Private _STT As Integer
        Private _MS_MAY As String
        Private _TU_NGAY As String
        Private _TU_GIO As String
        Private _DEN_NGAY As String
        Private _DEN_GIO As String
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
        Public Property TU_NGAY() As String
            Get
                Return _TU_NGAY
            End Get
            Set(ByVal value As String)
                _TU_NGAY = value
            End Set
        End Property
        Public Property TU_GIO() As String
            Get
                Return _TU_GIO
            End Get
            Set(ByVal value As String)
                _TU_GIO = value
            End Set
        End Property
        Public Property DEN_NGAY() As String
            Get
                Return _DEN_NGAY
            End Get
            Set(ByVal value As String)
                _DEN_NGAY = value
            End Set
        End Property
        Public Property DEN_GIO() As String
            Get
                Return _DEN_GIO
            End Get
            Set(ByVal value As String)
                _DEN_GIO = value
            End Set
        End Property
    End Class
End Namespace

