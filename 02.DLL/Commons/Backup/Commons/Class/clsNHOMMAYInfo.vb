Namespace VS.Classes.Catalogue    Public Class NHOM_MAYInfo        Private _MS_NHOM_MAY As String        Private _TEN_NHOM_MAY As String        Private _MS_LOAI_MAY As String        Private _MS_NHOM_MAY_TMP As String        Private _MS_LOAI_MAY_TMP As String        Public Property MS_NHOM_MAY() As String            Get                Return _MS_NHOM_MAY            End Get            Set(ByVal value As String)                _MS_NHOM_MAY = value            End Set        End Property        Public Property TEN_NHOM_MAY() As String            Get                Return _TEN_NHOM_MAY            End Get            Set(ByVal value As String)                _TEN_NHOM_MAY = value            End Set        End Property        Public Property MS_LOAI_MAY() As String            Get                Return _MS_LOAI_MAY            End Get            Set(ByVal value As String)                _MS_LOAI_MAY = value            End Set        End Property        Public Property MS_NHOM_MAY_TMP() As String            Get                Return _MS_NHOM_MAY_TMP            End Get            Set(ByVal value As String)                _MS_NHOM_MAY_TMP = value            End Set        End Property        Public Property MS_LOAI_MAY_TMP() As String            Get                Return _MS_LOAI_MAY_TMP            End Get            Set(ByVal value As String)                _MS_LOAI_MAY_TMP = value            End Set        End Property    End ClassEnd Namespace