Namespace VS.Classes.Catalogue
    Public Class cls_LY_DO_SUA_CHUA_Info
        Private _STT As Integer
        Private _TEN_LY_DO_VIET As String
        Private _TEN_LY_DO_ANH As String
        Private _TEN_LY_DO_HOA As String

        Public Property STT() As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
            End Set
        End Property

        Public Property TEN_LY_DO_VIET() As String
            Get
                Return _TEN_LY_DO_VIET
            End Get
            Set(ByVal value As String)
                _TEN_LY_DO_VIET = value
            End Set
        End Property

        Public Property TEN_LY_DO_ANH() As String
            Get
                Return _TEN_LY_DO_ANH
            End Get
            Set(ByVal value As String)
                _TEN_LY_DO_ANH = value
            End Set
        End Property

        Public Property TEN_LY_DO_HOA() As String
            Get
                Return _TEN_LY_DO_HOA
            End Get
            Set(ByVal value As String)
                _TEN_LY_DO_HOA = value
            End Set
        End Property
    End Class
End Namespace

