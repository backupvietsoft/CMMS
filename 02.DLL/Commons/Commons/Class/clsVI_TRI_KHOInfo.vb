Namespace VS.Classes.IEStock    Public Class VI_TRI_KHOInfo        Private _MS_VI_TRI As Integer        Private _TEN_VI_TRI As String        Private _MS_KHO As String        Public Property MS_VI_TRI() As Integer            Get                Return _MS_VI_TRI            End Get            Set(ByVal value As Integer)                _MS_VI_TRI = value            End Set        End Property        Public Property TEN_VI_TRI() As String            Get                Return _TEN_VI_TRI            End Get            Set(ByVal value As String)                _TEN_VI_TRI = value            End Set        End Property        Public Property MS_KHO() As String            Get                Return _MS_KHO            End Get            Set(ByVal value As String)                _MS_KHO = value            End Set        End Property    End ClassEnd Namespace