Namespace VS.Classes.Catalogue
    Public Class clsLOAI_VAT_TUInfo
        Private _MS_LOAI_VT As String
        Private _TEN_LOAI_VT_TV As String
        Private _TEN_LOAI_VT_TA As String
        Private _TEN_LOAI_VT_TH As String
        Private _VAT_TU As Boolean

        Public Property MS_LOAI_VT() As String
            Get
                Return _MS_LOAI_VT
            End Get
            Set(ByVal value As String)
                _MS_LOAI_VT = value
            End Set
        End Property
        Public Property TEN_LOAI_VT_TV() As String
            Get
                Return _TEN_LOAI_VT_TV
            End Get
            Set(ByVal value As String)
                _TEN_LOAI_VT_TV = value
            End Set
        End Property
        Public Property TEN_LOAI_VT_TA() As String
            Get
                Return _TEN_LOAI_VT_TA
            End Get
            Set(ByVal value As String)
                _TEN_LOAI_VT_TA = value
            End Set
        End Property
        Public Property TEN_LOAI_VT_TH() As String
            Get
                Return _TEN_LOAI_VT_TH
            End Get
            Set(ByVal value As String)
                _TEN_LOAI_VT_TH = value
            End Set
        End Property
        Public Property VAT_TU() As Boolean
            Get
                Return _VAT_TU
            End Get
            Set(ByVal value As Boolean)
                _VAT_TU = value
            End Set
        End Property
    End Class
End Namespace
