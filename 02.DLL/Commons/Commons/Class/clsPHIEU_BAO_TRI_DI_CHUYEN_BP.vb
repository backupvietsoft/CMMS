Namespace VS.Classes.Catalogue
    Public Class PHIEU_BAO_TRI_DI_CHUYEN_BPInfo
        Private _MS_PHIEU_BAO_TRI As String
        Private _MS_BO_PHAN As String
        Private _MS_MAY_THAY_THE As String
        Private _MS_BO_PHAN_THAY_THE As String
        Private _NGUOI_CHO_PHEP As String
        Private _DAI_HAN As Boolean
        Private _DEN_NGAY As String
        Private _NGAY_TRA_TT As String
        Public Property MS_PHIEU_BAO_TRI() As String
            Get
                Return _MS_PHIEU_BAO_TRI
            End Get
            Set(ByVal value As String)
                _MS_PHIEU_BAO_TRI = value
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
        Public Property MS_MAY_THAY_THE() As String
            Get
                Return _MS_MAY_THAY_THE
            End Get
            Set(ByVal value As String)
                _MS_MAY_THAY_THE = value
            End Set
        End Property
        Public Property MS_BO_PHAN_THAY_THE() As String
            Get
                Return _MS_BO_PHAN_THAY_THE
            End Get
            Set(ByVal value As String)
                _MS_BO_PHAN_THAY_THE = value
            End Set
        End Property
        Public Property NGUOI_CHO_PHEP() As String
            Get
                Return _NGUOI_CHO_PHEP
            End Get
            Set(ByVal value As String)
                _NGUOI_CHO_PHEP = value
            End Set
        End Property
        Public Property DAI_HAN() As Boolean
            Get
                Return _DAI_HAN
            End Get
            Set(ByVal value As Boolean)
                _DAI_HAN = value
            End Set
        End Property
        Public Property DEN_NGAY() As String
            Get
                Return _DEN_NGAY
            End Get
            Set(ByVal value As String)
                _DEN_NGAY = value
            End Set
        End Property
        Public Property NGAY_TRA_TT() As String
            Get
                Return _NGAY_TRA_TT
            End Get
            Set(ByVal value As String)
                _NGAY_TRA_TT = value
            End Set
        End Property
    End Class
End Namespace

