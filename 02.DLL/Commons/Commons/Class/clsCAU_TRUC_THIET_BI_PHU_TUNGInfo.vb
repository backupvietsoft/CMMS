Namespace VS.Classes.Catalogue
Public Class CAU_TRUC_THIET_BI_PHU_TUNGInfo
        Private _MS_MAY As String
        Private _MS_BO_PHAN As String
        Private _MS_PT As String
        Private _MS_VI_TRI_PT As String
        Private _SO_LUONG As Integer
        Private _ACTIVE As Boolean
        Private _CHUC_NANG As String


        Public Property MS_MAY() As String
            Get
                Return _MS_MAY
            End Get
            Set(ByVal value As String)
                _MS_MAY = value
            End Set
        End Property
    Public Property MS_BO_PHAN() As String
        Get
            return _MS_BO_PHAN
        End Get
        Set(Byval value As String)
            _MS_BO_PHAN = value
        End Set
    End Property
    Public Property MS_PT() As String
        Get
            return _MS_PT
        End Get
        Set(Byval value As String)
            _MS_PT = value
        End Set
        End Property
        Public Property MS_VI_TRI_PT() As String
            Get
                Return _MS_VI_TRI_PT
            End Get
            Set(ByVal value As String)
                _MS_VI_TRI_PT = value
            End Set
        End Property
        Public Property SO_LUONG() As Integer
            Get
                Return _SO_LUONG
            End Get
            Set(ByVal value As Integer)
                _SO_LUONG = value
            End Set
        End Property
        Public Property ACTIVE() As Boolean
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As Boolean)
                _ACTIVE = value
            End Set
        End Property
        Public Property CHUC_NANG() As String
            Get
                Return _CHUC_NANG
            End Get
            Set(ByVal value As String)
                _CHUC_NANG = value
            End Set
        End Property

End Class
End Namespace