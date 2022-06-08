Namespace VS.Classes.Catalogue
    Public Class clsEOR_CONG_VIECInfo
        Private _EOR_ID As String
        Private _MS_CV As Integer
        Private _MS_BO_PHAN As String
        Private _TU_GIO As String
        Private _TU_NGAY As String
        Private _DEN_GIO As String
        Private _DEN_NGAY As String
        Private _THOI_GIAN_VICT As String
        Private _THOI_GIAN_VENDOR As String
        Private _NHAN_VIEN As String
        Private _MS_PHIEU_BAO_TRI As String
        Public Property EOR_ID() As String
            Get
                Return _EOR_ID
            End Get
            Set(ByVal value As String)
                _EOR_ID = value
            End Set
        End Property
        Public Property MS_CV() As Integer
            Get
                Return _MS_CV
            End Get
            Set(ByVal value As Integer)
                _MS_CV = value
            End Set
        End Property
        Public Property TU_GIO() As String
            Get
                Return _TU_GIO
            End Get
            Set(ByVal value As String)
                _TU_GIO = value
            End Set
        End Property
        Public Property TU_NGAY() As String
            Get
                Return _TU_NGAY
            End Get
            Set(ByVal value As String)
                _TU_NGAY = value
            End Set
        End Property
        Public Property DEN_GIO() As String
            Get
                Return _DEN_GIO
            End Get
            Set(ByVal value As String)
                _DEN_GIO = value
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
        Public Property MS_BO_PHAN() As String
            Get
                Return _MS_BO_PHAN
            End Get
            Set(ByVal value As String)
                _MS_BO_PHAN = value
            End Set
        End Property
        Public Property THOI_GIAN_VICT() As String
            Get
                Return _THOI_GIAN_VICT
            End Get
            Set(ByVal value As String)
                _THOI_GIAN_VICT = value
            End Set
        End Property
        Public Property THOI_GIAN_VENDOR() As String
            Get
                Return _THOI_GIAN_VENDOR
            End Get
            Set(ByVal value As String)
                _THOI_GIAN_VENDOR = value
            End Set
        End Property
        Public Property NHAN_VIEN() As String
            Get
                Return _NHAN_VIEN
            End Get
            Set(ByVal value As String)
                _NHAN_VIEN = value
            End Set
        End Property
        Public Property MS_PHIEU_BAO_TRI() As String
            Get
                Return _MS_PHIEU_BAO_TRI
            End Get
            Set(ByVal value As String)
                _MS_PHIEU_BAO_TRI = value
            End Set
        End Property
    End Class
End Namespace
