Namespace VS.Classes.Catalogue    Public Class KINH_PHI_NAMInfo        Private _MS_BP_CHIU_PHI As Integer        Private _NAM As Integer        Private _THANG As Date        Private _SO_TIEN As Double        Private _NGOAI_TE As String        Private _TY_GIA As Double        Private _TY_GIA_USD As Double        Private _THANH_TIEN As Double        Private _THANH_TIEN_USD As Double        Private _MS_LOAI_CP As String        Public Property MS_BP_CHIU_PHI() As Integer            Get                Return _MS_BP_CHIU_PHI            End Get            Set(ByVal value As Integer)                _MS_BP_CHIU_PHI = value            End Set        End Property        Public Property NAM() As Integer            Get                Return _NAM            End Get            Set(ByVal value As Integer)                _NAM = value            End Set        End Property        Public Property THANG() As Date            Get                Return _THANG            End Get            Set(ByVal value As Date)                _THANG = value            End Set        End Property        Public Property SO_TIEN() As Double            Get                Return _SO_TIEN            End Get            Set(ByVal value As Double)                _SO_TIEN = value            End Set        End Property        Public Property NGOAI_TE() As String            Get                Return _NGOAI_TE            End Get            Set(ByVal value As String)                _NGOAI_TE = value            End Set        End Property        Public Property MS_LOAI_CP() As String            Get                Return _MS_LOAI_CP            End Get            Set(ByVal value As String)                _MS_LOAI_CP = value            End Set        End Property        Public Property TY_GIA() As Double            Get                Return _TY_GIA            End Get            Set(ByVal value As Double)                _TY_GIA = value            End Set        End Property        Public Property TY_GIA_USD() As Double            Get                Return _TY_GIA_USD            End Get            Set(ByVal value As Double)                _TY_GIA_USD = value            End Set        End Property        Public Property THANH_TIEN() As Double            Get                Return _THANH_TIEN            End Get            Set(ByVal value As Double)                _THANH_TIEN = value            End Set        End Property        Public Property THANH_TIEN_USD() As Double            Get                Return _THANH_TIEN_USD            End Get            Set(ByVal value As Double)                _THANH_TIEN_USD = value            End Set        End Property    End ClassEnd Namespace