Namespace VS.Classes.Catalogue

    Public Class clsCONG_VIEC_HANG_NGAY_VTInfo
        Private _STT_CV As Integer
        Private _MS_PT As String
        Private _SO_LUONG As Double
        Private _D0N_GIA As Double
        Private _THANH_TIEN As Double
        Private _MS_DH_XUAT As String
        Private _MS_DH_NHAP As String
        Private _ID As Integer

        Public Property MS_DH_XUAT() As String
            Get
                Return _MS_DH_XUAT
            End Get
            Set(ByVal value As String)
                _MS_DH_XUAT = value
            End Set
        End Property
        Public Property MS_DH_NHAP() As String
            Get
                Return _MS_DH_NHAP
            End Get
            Set(ByVal value As String)
                _MS_DH_NHAP = value
            End Set
        End Property


        Public Property STT_CV() As Integer
            Get
                Return _STT_CV
            End Get
            Set(ByVal value As Integer)
                _STT_CV = value
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

        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property

    End Class
End Namespace
