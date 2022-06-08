Namespace VS.Classes.Catalogue
    Public Class clsEOR_REFFERENCEInfo
        Private _EOR_ID As String
        Private _STT As Integer
        Private _TEN_TAI_LIEU As String
        Private _DUONG_DAN As String
        Private _STT_YC_NSD As Integer
        Private _STT_GSTT As Integer
        Private _LOAI_TAI_LIEU1 As Integer
        Public Property EOR_ID() As String
            Get
                Return _EOR_ID
            End Get
            Set(ByVal value As String)
                _EOR_ID = value
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
        Public Property TEN_TAI_LIEU() As String
            Get
                Return _TEN_TAI_LIEU
            End Get
            Set(ByVal value As String)
                _TEN_TAI_LIEU = value
            End Set
        End Property
        Public Property DUONG_DAN() As String
            Get
                Return _DUONG_DAN
            End Get
            Set(ByVal value As String)
                _DUONG_DAN = value
            End Set
        End Property
        Public Property STT_YC_NSD() As Integer
            Get
                Return _STT_YC_NSD
            End Get
            Set(ByVal value As Integer)
                _STT_YC_NSD = value
            End Set
        End Property
        Public Property STT_GSTT() As Integer
            Get
                Return _STT_GSTT
            End Get
            Set(ByVal value As Integer)
                _STT_GSTT = value
            End Set
        End Property
        Public Property LOAI_TAI_LIEU1() As Integer
            Get
                Return _LOAI_TAI_LIEU1
            End Get
            Set(ByVal value As Integer)
                _LOAI_TAI_LIEU1 = value
            End Set
        End Property
    End Class
End Namespace
