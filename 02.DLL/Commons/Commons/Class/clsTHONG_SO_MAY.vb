Namespace VS.Classes.Catalogue
    Public Class THONG_SO_MAYInfo
        Private _MS_THONG_SO_MAY As Integer
        Private _TEN_THONG_SO_MAY As String
        Private _GHI_CHU As String
        Private _MS_DV_DO As Integer
        Public Property MS_THONG_SO_MAY() As Integer
            Get
                Return _MS_THONG_SO_MAY
            End Get
            Set(ByVal value As Integer)
                _MS_THONG_SO_MAY = value
            End Set
        End Property
        Public Property TEN_THONG_SO_MAY() As String
            Get
                Return _TEN_THONG_SO_MAY
            End Get
            Set(ByVal value As String)
                _TEN_THONG_SO_MAY = value
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
        Public Property MS_DV_DO() As Integer
            Get
                Return _MS_DV_DO
            End Get
            Set(ByVal value As Integer)
                _MS_DV_DO = value
            End Set
        End Property
    End Class
End Namespace
