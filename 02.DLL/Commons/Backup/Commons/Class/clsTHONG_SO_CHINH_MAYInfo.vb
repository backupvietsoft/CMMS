Namespace VS.Classes.Catalogue    Public Class THONG_SO_CHINH_MAYInfo        Private _MS_MAY As String        Private _MS_THONG_SO_MAY As Integer        Private _GIA_TRI As String        Private _GIA_TRI_MIN As Double        Private _GIA_TRI_MAX As Double        Private _GHI_CHU As String        Public Property MS_MAY() As String            Get                Return _MS_MAY            End Get            Set(ByVal value As String)                _MS_MAY = value            End Set        End Property        Public Property MS_THONG_SO_MAY() As Integer            Get                Return _MS_THONG_SO_MAY            End Get            Set(ByVal value As Integer)                _MS_THONG_SO_MAY = value            End Set        End Property        Public Property GIA_TRI() As String            Get                Return _GIA_TRI            End Get            Set(ByVal value As String)                _GIA_TRI = value            End Set        End Property        Public Property GIA_TRI_MIN() As Double            Get                Return _GIA_TRI_MIN            End Get            Set(ByVal value As Double)                _GIA_TRI_MIN = value            End Set        End Property        Public Property GIA_TRI_MAX() As Double            Get                Return _GIA_TRI_MAX            End Get            Set(ByVal value As Double)                _GIA_TRI_MAX = value            End Set        End Property        Public Property GHI_CHU() As String            Get                Return _GHI_CHU            End Get            Set(ByVal value As String)                _GHI_CHU = value            End Set        End Property    End ClassEnd Namespace