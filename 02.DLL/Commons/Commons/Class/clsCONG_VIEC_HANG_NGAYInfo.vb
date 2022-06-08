Namespace VS.Classes.Catalogue
    Public Class clsCONG_VIEC_HANG_NGAYInfo
        Private _STT_CV As Integer
        Private _MS_CONG_NHAN As String
        Private _SO_GIO As Double
        Private _LUONG As Double
        Private _THANH_TIEN As Double
        Public Property STT_CV() As Integer            Get                Return _STT_CV            End Get            Set(ByVal value As Integer)                _STT_CV = value            End Set        End Property
        Public Property MS_CONG_NHAN() As String            Get                Return _MS_CONG_NHAN            End Get            Set(ByVal value As String)                _MS_CONG_NHAN = value            End Set        End Property
        Public Property SO_GIO() As Double            Get                Return _SO_GIO            End Get            Set(ByVal value As Double)                _SO_GIO = value            End Set        End Property
        Public Property LUONG() As Double            Get                Return _LUONG            End Get            Set(ByVal value As Double)                _LUONG = value            End Set        End Property
        Public Property THANH_TIEN() As Double            Get                Return _THANH_TIEN            End Get            Set(ByVal value As Double)                _THANH_TIEN = value            End Set        End Property
    End Class
End Namespace
