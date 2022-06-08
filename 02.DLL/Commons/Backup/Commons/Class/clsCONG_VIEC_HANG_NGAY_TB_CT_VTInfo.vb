Namespace VS.Classes.Catalogue
    Public Class clsCONG_VIEC_HANG_NGAY_TB_CT_VTInfo
        Private _STT_CV As Integer
        Private _MS_MAY As String
        Private _MS_PT As String
        Private _SO_LUONG As Double
        Private _D0N_GIA As Double
        Private _THANH_TIEN As Double
        Public Property STT_CV() As Integer
            Get
                Return _STT_CV
            End Get
            Set(ByVal value As Integer)
                _STT_CV = value
            End Set
        End Property
        Public Property MS_MAY() As String
            Get
                Return _MS_MAY
            End Get
            Set(ByVal value As String)
                _MS_MAY = value
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
        Public Property SO_LUONG() As Double
            Get
                Return _SO_LUONG
            End Get
            Set(ByVal value As Double)
                _SO_LUONG = value
            End Set
        End Property
        Public Property DON_GIA() As Double
            Get
                Return _D0N_GIA
            End Get
            Set(ByVal value As Double)
                _D0N_GIA = value
            End Set
        End Property
        Public Property THANH_TIEN() As Double
            Get
                Return _THANH_TIEN
            End Get
            Set(ByVal value As Double)
                _THANH_TIEN = value
            End Set
        End Property
    End Class
End Namespace
