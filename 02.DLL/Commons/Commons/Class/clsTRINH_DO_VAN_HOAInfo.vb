Public Class TRINH_DO_VAN_HOAInfo    Private _MS_TRINH_DO As Integer    Private _TEN_GOI As String    Public Property MS_TRINH_DO() As Integer        Get            Return _MS_TRINH_DO        End Get        Set(ByVal value As Integer)            _MS_TRINH_DO = value        End Set    End Property    Public Property TEN_GOI() As String        Get            return _TEN_GOI        End Get        Set(Byval value As String)            _TEN_GOI = value        End Set    End PropertyEnd Class