Namespace VS.Classes.Catalogue
    Public Class DON_VI_THOI_GIANInfo
        Private _MS_DV_TG As Integer
        Private _TEN_DV_TG As String
        Public Property MS_DV_TG() As Integer
            Get
                Return _MS_DV_TG
            End Get
            Set(ByVal value As Integer)
                _MS_DV_TG = value
            End Set
        End Property
        Public Property TEN_DV_TG() As String
            Get
                Return _TEN_DV_TG
            End Get
            Set(ByVal value As String)
                _TEN_DV_TG = value
            End Set
        End Property
    End Class
End Namespace
