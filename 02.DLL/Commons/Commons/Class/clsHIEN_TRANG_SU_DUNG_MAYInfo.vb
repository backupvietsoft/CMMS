Namespace VS.Classes.Catalogue
    Public Class HIEN_TRANG_SU_DUNG_MAYInfo
        Private _MS_HIEN_TRANG As Integer
        Private _TEN_HIEN_TRANG As String
        Public Property MS_HIEN_TRANG() As Integer
            Get
                Return _MS_HIEN_TRANG
            End Get
            Set(ByVal value As Integer)
                _MS_HIEN_TRANG = value
            End Set
        End Property
        Public Property TEN_HIEN_TRANG() As String
            Get
                Return _TEN_HIEN_TRANG
            End Get
            Set(ByVal value As String)
                _TEN_HIEN_TRANG = value
            End Set
        End Property
    End Class
End Namespace
