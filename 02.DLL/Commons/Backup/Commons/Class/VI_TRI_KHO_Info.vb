Namespace VS.Classes.Catalogue
    Public Class VI_TRI_KHO_Info

        Private _MS_KHO As Integer
        Private _MS_VI_TRI As Integer
        Private _TEN_VI_TRI As String = ""

        Public Sub New()

        End Sub

        Public Property MS_KHO() As Integer
            Get
                Return _MS_KHO
            End Get
            Set(ByVal value As Integer)
                _MS_KHO = value
            End Set
        End Property
        Public Property MS_VI_TRI() As Integer
            Get
                Return _MS_VI_TRI
            End Get
            Set(ByVal value As Integer)
                _MS_VI_TRI = value
            End Set
        End Property
        Public Property TEN_VI_TRI() As String
            Get
                Return _TEN_VI_TRI
            End Get
            Set(ByVal value As String)
                _TEN_VI_TRI = value
            End Set
        End Property
    End Class
End Namespace