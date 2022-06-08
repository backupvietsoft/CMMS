
Namespace VS.Classes.Catalogue
    Public Class clsGIAM_SAT_TINH_TRANG_TSInfo
        Private _STT As Integer
        Private _MS_MAY As String
        Private _MS_TS_GSTT As String
        Private _MS_BO_PHAN As String
        Private _GIA_TRI_DO As String
        Private _MS_TT As Integer
        Public Property STT() As Integer
            Get
                Return _STT
            End Get
            Set(ByVal value As Integer)
                _STT = value
            End Set
        End Property
        Public Property MS_MAY() As String
            Get
                Return _MS_MAY
            End Get
            Set(ByVal value As String)
                _MS_MAY = value
            End Set
        End Property
        Public Property MS_TS_GSTT() As String
            Get
                Return _MS_TS_GSTT
            End Get
            Set(ByVal value As String)
                _MS_TS_GSTT = value
            End Set
        End Property
        Public Property MS_BO_PHAN() As String
            Get
                Return _MS_BO_PHAN
            End Get
            Set(ByVal value As String)
                _MS_BO_PHAN = value
            End Set
        End Property
        Public Property GIA_TRI_DO() As String
            Get
                Return _GIA_TRI_DO
            End Get
            Set(ByVal value As String)
                _GIA_TRI_DO = value
            End Set
        End Property
        Public Property MS_TT() As Integer
            Get
                Return _MS_TT
            End Get
            Set(ByVal value As Integer)
                _MS_TT = value
            End Set
        End Property
    End Class
End Namespace
