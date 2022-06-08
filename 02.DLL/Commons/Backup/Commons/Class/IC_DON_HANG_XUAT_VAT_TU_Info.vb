Namespace VS.Classes.Catalogue
    Public Class IC_DON_HANG_XUAT_VAT_TU_Info
        Private _MS_DH_XUAT_PT As String
        Private _MS_PT As String
        Private _SO_LUONG_CTU As Double
        Private _SO_LUONG_THUC_XUAT As Double
        Private _GHI_CHU As String

        Private _DVT As String
        Private _TEN_PT As String
        Private _ITEM_CODE As String
        Private _PART_NO As String
        Private _TG_PB As Integer


        Public Property MS_DH_XUAT_PT() As String
            Get
                Return _MS_DH_XUAT_PT
            End Get
            Set(ByVal value As String)
                _MS_DH_XUAT_PT = value
            End Set
        End Property
        Public Property MS_PT() As String
            Get
                Return _MS_PT
            End Get
            Set(ByVal value As String)
                _MS_PT = value
            End Set
        End Property
        Public Property SO_LUONG_CTU() As Double
            Get
                Return _SO_LUONG_CTU
            End Get
            Set(ByVal value As Double)
                _SO_LUONG_CTU = value
            End Set
        End Property

        Public Property SO_LUONG_THUC_XUAT() As Double
            Get
                Return _SO_LUONG_THUC_XUAT
            End Get
            Set(ByVal value As Double)
                _SO_LUONG_THUC_XUAT = value
            End Set
        End Property

        Public Property DVT() As String
            Get
                Return _DVT
            End Get
            Set(ByVal value As String)
                _DVT = value
            End Set
        End Property

        Public Property TEN_PT() As String
            Get
                Return _TEN_PT
            End Get
            Set(ByVal value As String)
                _TEN_PT = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return _MS_PT
        End Function
        Public Property ITEM_CODE() As String
            Get
                Return _ITEM_CODE
            End Get
            Set(ByVal value As String)
                _ITEM_CODE = value
            End Set
        End Property
        Public Property PART_NO() As String
            Get
                Return _PART_NO
            End Get
            Set(ByVal value As String)
                _PART_NO = value
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

        Public Property TG_PB() As Integer
            Get
                Return _TG_PB
            End Get
            Set(ByVal value As Integer)
                _TG_PB = value
            End Set
        End Property

    End Class
End Namespace