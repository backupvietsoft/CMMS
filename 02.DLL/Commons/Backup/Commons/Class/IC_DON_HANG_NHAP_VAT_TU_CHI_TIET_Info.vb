Namespace VS.Classes.Catalogue
    Public Class IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info
        Private _MS_DH_NHAP_PT As String
        Private _MS_PT As String
        Private _MS_VI_TRI As Integer
        Private _SL_VT As Double

        Public Property MS_DH_NHAP_PT() As String
            Get
                Return _MS_DH_NHAP_PT
            End Get
            Set(ByVal value As String)
                _MS_DH_NHAP_PT = value
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
        Public Property MS_VI_TRI() As Integer
            Get
                Return _MS_VI_TRI
            End Get
            Set(ByVal value As Integer)
                _MS_VI_TRI = value
            End Set
        End Property
        Public Property SL_VT() As Double
            Get
                Return _SL_VT
            End Get
            Set(ByVal value As Double)
                _SL_VT = value
            End Set
        End Property
    End Class
End Namespace