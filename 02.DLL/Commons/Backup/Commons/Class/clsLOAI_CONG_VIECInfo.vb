Namespace VS.Classes.Catalogue
    Public Class LOAI_CONG_VIECInfo
        Private _MS_LOAI_CV As Integer
        Private _TEN_LOAI_CV As String
        Public Property MS_LOAI_CV() As Integer
            Get
                Return _MS_LOAI_CV
            End Get
            Set(ByVal value As Integer)
                _MS_LOAI_CV = value
            End Set
        End Property
        Public Property TEN_LOAI_CV() As String
            Get
                Return _TEN_LOAI_CV
            End Get
            Set(ByVal value As String)
                _TEN_LOAI_CV = value
            End Set
        End Property
    End Class
End Namespace
