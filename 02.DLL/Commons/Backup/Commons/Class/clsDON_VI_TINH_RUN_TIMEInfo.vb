Namespace VS.Classes.Catalogue
    Public Class DON_VI_TINH_RUN_TIMEInfo
        Private _MS_DVT_RT As Integer
        Private _TEN_DVT_RT As String
        Public Property MS_DVT_RT() As Integer
            Get
                Return _MS_DVT_RT
            End Get
            Set(ByVal value As Integer)
                _MS_DVT_RT = value
            End Set
        End Property
        Public Property TEN_DVT_RT() As String
            Get
                Return _TEN_DVT_RT
            End Get
            Set(ByVal value As String)
                _TEN_DVT_RT = value
            End Set
        End Property
    End Class
End Namespace
