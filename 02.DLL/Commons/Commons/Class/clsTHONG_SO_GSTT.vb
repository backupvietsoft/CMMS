Namespace VS.Classes.Catalogue
    Public Class THONG_SO_GSTTInfo
        Private _MS_TS_GSTT As String
        Private _TEN_TS_GSTT As String
        Private _MS_DV_DO As Integer
        Private _LOAI_TS As Boolean
        Private _TINH_TRANG As String
        Private _GHI_CHU As String
        Private _MS_BP_GSTT As Integer
        Private _DUONG_DAN As String

        Public Property MS_TS_GSTT() As String
            Get
                Return _MS_TS_GSTT
            End Get
            Set(ByVal value As String)
                _MS_TS_GSTT = value
            End Set
        End Property
        Public Property TEN_TS_GSTT() As String
            Get
                Return _TEN_TS_GSTT
            End Get
            Set(ByVal value As String)
                _TEN_TS_GSTT = value
            End Set
        End Property
        Public Property MS_DV_DO() As Integer
            Get
                Return _MS_DV_DO
            End Get
            Set(ByVal value As Integer)
                _MS_DV_DO = value
            End Set
        End Property
        Public Property MS_BP_GSTT() As Integer
            Get
                Return _MS_BP_GSTT
            End Get
            Set(ByVal value As Integer)
                _MS_BP_GSTT = value
            End Set
        End Property
        Public Property LOAI_TS() As Boolean
            Get
                Return _LOAI_TS
            End Get
            Set(ByVal value As Boolean)
                _LOAI_TS = value
            End Set
        End Property
        Public Property TINH_TRANG() As String
            Get
                Return _TINH_TRANG
            End Get
            Set(ByVal value As String)
                _TINH_TRANG = value
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
        Public Property DUONG_DAN() As String
            Get
                Return _DUONG_DAN
            End Get
            Set(ByVal value As String)
                _DUONG_DAN = value
            End Set
        End Property
    End Class
End Namespace

