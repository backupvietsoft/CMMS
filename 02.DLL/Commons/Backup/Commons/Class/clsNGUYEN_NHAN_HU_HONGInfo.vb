Namespace VS.Classes.Catalogue
    Public Class clsNGUYEN_NHAN_HU_HONGInfo

        Private _MA As String
        Private _MA_TMP As String
        Private _TEN_1 As String
        Private _TEN_2 As String
        Private _TEN_3 As String
        Public Property MA() As String
            Get
                Return _MA
            End Get
            Set(ByVal value As String)
                _MA = value
            End Set
        End Property
        Public Property MA_TMP() As String
            Get
                Return _MA_TMP
            End Get
            Set(ByVal value As String)
                _MA_TMP = value
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
    End Class
End Namespace
