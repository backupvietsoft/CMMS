Namespace VS.Classes.Catalogue
    Public Class LOAI_BAO_TRIInfo
        Private _MS_LOAI_BT As Integer
        Private _MS_HT_BT As Integer
        Private _TEN_LOAI_BT As String
        Private _GHI_CHU As String
        Private _THU_TU As Integer
        Public Property MS_LOAI_BT() As Integer
            Get
                Return _MS_LOAI_BT
            End Get
            Set(ByVal value As Integer)
                _MS_LOAI_BT = value
            End Set
        End Property
        Public Property MS_HT_BT() As Integer
            Get
                Return _MS_HT_BT
            End Get
            Set(ByVal value As Integer)
                _MS_HT_BT = value
            End Set
        End Property
        Public Property TEN_LOAI_BT() As String
            Get
                Return _TEN_LOAI_BT
            End Get
            Set(ByVal value As String)
                _TEN_LOAI_BT = value
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
        Public Property THU_TU() As Integer
            Get
                Return _THU_TU
            End Get
            Set(ByVal value As Integer)
                _THU_TU = value
            End Set
        End Property
    End Class
End Namespace
