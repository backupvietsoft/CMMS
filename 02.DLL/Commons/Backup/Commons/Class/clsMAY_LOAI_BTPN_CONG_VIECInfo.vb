Namespace VS.Classes.CataloguePublic Class MAY_LOAI_BTPN_CONG_VIECInfo        Private _MS_MAY As String        Private _MS_LOAI_BT As Integer        Private _MS_CV As Integer        Private _MS_BO_PHAN As String        Public Property MS_MAY() As String            Get                Return _MS_MAY            End Get            Set(ByVal value As String)                _MS_MAY = value            End Set        End Property    Public Property MS_LOAI_BT() As Integer        Get            return _MS_LOAI_BT        End Get        Set(Byval value As Integer)            _MS_LOAI_BT = value        End Set    End Property    Public Property MS_CV() As Integer        Get            return _MS_CV        End Get        Set(Byval value As Integer)            _MS_CV = value        End Set        End Property        Public Property MS_BO_PHAN() As String            Get                Return _MS_BO_PHAN            End Get            Set(ByVal value As String)                _MS_BO_PHAN = value            End Set        End PropertyEnd ClassEnd Namespace