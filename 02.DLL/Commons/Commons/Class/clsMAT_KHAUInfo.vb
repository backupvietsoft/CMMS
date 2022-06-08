Namespace VS.Classes.IEStock    Public Class MAT_KHAUInfo
        Private _CHUC_NANG As String        Private _MAT_KHAU As String        Public Property CHUC_NANG() As String            Get                Return _CHUC_NANG            End Get            Set(ByVal value As String)                _CHUC_NANG = value            End Set        End Property
        Public Property MAT_KHAU() As String            Get                Return _MAT_KHAU            End Get            Set(ByVal value As String)                _MAT_KHAU = value            End Set        End Property
    End Class
End Namespace
