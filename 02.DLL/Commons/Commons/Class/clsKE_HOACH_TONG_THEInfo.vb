Namespace VS.Classes.Catalogue
    Public Class KE_HOACH_TONG_THEInfo
        Private _MS_MAY As String
        Private _NGAY As Date
        Private _MS_LOAI_BT As Integer
        Private _NGAY_BTPN As Date

        Public Property MS_MAY() As String
            Get
                Return _MS_MAY
            End Get
            Set(ByVal value As String)
                _MS_MAY = value
            End Set
        End Property
        Public Property NGAY() As Date
            Get
                Return _NGAY
            End Get
            Set(ByVal value As Date)
                _NGAY = value
            End Set
        End Property
        Public Property MS_LOAI_BT() As Integer
            Get
                Return _MS_LOAI_BT
            End Get
            Set(ByVal value As Integer)
                _MS_LOAI_BT = value
            End Set
        End Property
        Public Property NGAY_BTPN() As Date
            Get
                Return _NGAY_BTPN
            End Get
            Set(ByVal value As Date)
                _NGAY_BTPN = value
            End Set
        End Property
    End Class
End Namespace
