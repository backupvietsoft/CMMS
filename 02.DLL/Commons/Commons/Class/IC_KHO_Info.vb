Namespace VS.Classes.Catalogue
    Public Class IC_KHO_Info
        Private _MS_KHO As Integer
        Private _TEN_KHO As String
        Private _DIA_CHI As String
        Private _SO_DO As String

        Public Property MS_KHO() As Integer
            Get
                Return _MS_KHO
            End Get
            Set(ByVal value As Integer)
                _MS_KHO = value
            End Set
        End Property

        Public Property TEN_KHO() As String
            Get
                Return _TEN_KHO
            End Get
            Set(ByVal value As String)
                _TEN_KHO = value
            End Set
        End Property

        Public Property DIA_CHI() As String
            Get
                Return _DIA_CHI
            End Get
            Set(ByVal value As String)
                _DIA_CHI = value
            End Set
        End Property

        Public Property SO_DO() As String
            Get
                Return _SO_DO
            End Get
            Set(ByVal value As String)
                _SO_DO = value
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return Me._TEN_KHO
        End Function

    End Class
End Namespace