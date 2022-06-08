Namespace VS.Classes.Catalogue
    Public Class GIA_TRI_TS_GSTTInfo
        Private _MS_TS_GSTT As String
        Private _STT As Integer
        Private _TEN_GIA_TRI As String
        Private _DAT As Boolean
        Private _GHI_CHU As String
        Public Property MS_TS_GSTT() As String
            Get
                Return _MS_TS_GSTT
            End Get
            Set(ByVal value As String)
                _MS_TS_GSTT = value
            End Set
        End Property
        Public Property STT() As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
            End Set
        End Property
        Public Property TEN_GIA_TRI() As String
            Get
                Return _TEN_GIA_TRI
            End Get
            Set(ByVal value As String)
                _TEN_GIA_TRI = value
            End Set
        End Property
        Public Property DAT() As Boolean
            Get
                Return _DAT
            End Get
            Set(ByVal value As Boolean)
                _DAT = value
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
