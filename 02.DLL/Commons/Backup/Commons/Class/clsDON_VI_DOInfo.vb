Namespace VS.Classes.Catalogue
    Public Class DON_VI_DOInfo
        Private _MS_DV_DO As Integer
        Private _TEN_DV_DO As String
        Public Property MS_DV_DO() As Integer
            Get
                Return _MS_DV_DO
            End Get
            Set(ByVal value As Integer)
                _MS_DV_DO = value
            End Set
        End Property
        Public Property TEN_DV_DO() As String
            Get
                Return _TEN_DV_DO
            End Get
            Set(ByVal value As String)
                _TEN_DV_DO = value
            End Set
        End Property
    End Class
End Namespace
