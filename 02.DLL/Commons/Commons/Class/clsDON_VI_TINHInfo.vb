Namespace VS.Classes.Catalogue
    Public Class DON_VI_TINHInfo
        Private _DVT As String
        Private _DVT_TMP As String
        Private _TEN_1 As String
        Private _TEN_2 As String
        Private _TEN_3 As String
        Private _GHI_CHU As String
        Public Property DVT() As String
            Get
                Return _DVT
            End Get
            Set(ByVal value As String)
                _DVT = value
            End Set
        End Property
        Public Property DVT_TMP() As String
            Get
                Return _DVT_TMP
            End Get
            Set(ByVal value As String)
                _DVT_TMP = value
            End Set
        End Property
        Public Property TEN_1() As String
            Get
                Return _TEN_1
            End Get
            Set(ByVal value As String)
                _TEN_1 = value
            End Set
        End Property
        Public Property TEN_2() As String
            Get
                Return _TEN_2
            End Get
            Set(ByVal value As String)
                _TEN_2 = value
            End Set
        End Property
        Public Property TEN_3() As String
            Get
                Return _TEN_3
            End Get
            Set(ByVal value As String)
                _TEN_3 = value
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
