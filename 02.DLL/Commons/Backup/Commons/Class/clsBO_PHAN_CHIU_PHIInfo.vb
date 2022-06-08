Namespace VS.Classes.Catalogue
    Public Class BO_PHAN_CHIU_PHIInfo
        Private _MS_BP_CHIU_PHI As Integer
        Private _MA_BP_CHIU_PHI As String
        Private _TEN_BP_CHIU_PHI As String
        Private _LOAI_CHI_PHI As String
        Private _MSDV As String
        Private _GHI_CHU As String
        Private _ACCOUNT As String
        Private _SUBS As String

        Public Property MS_BP_CHIU_PHI() As Integer
            Get
                Return _MS_BP_CHIU_PHI
            End Get
            Set(ByVal value As Integer)
                _MS_BP_CHIU_PHI = value
            End Set
        End Property
        Public Property MA_BP_CHIU_PHI() As String
            Get
                Return _MA_BP_CHIU_PHI
            End Get
            Set(ByVal value As String)
                _MA_BP_CHIU_PHI = value
            End Set
        End Property
        Public Property TEN_BP_CHIU_PHI() As String
            Get
                Return _TEN_BP_CHIU_PHI
            End Get
            Set(ByVal value As String)
                _TEN_BP_CHIU_PHI = value
            End Set
        End Property
        Public Property LOAI_CHI_PHI() As String
            Get
                Return _LOAI_CHI_PHI
            End Get
            Set(ByVal value As String)
                _LOAI_CHI_PHI = value
            End Set
        End Property
        Public Property MSDV() As String
            Get
                Return _MSDV
            End Get
            Set(ByVal value As String)
                _MSDV = value
            End Set
        End Property
        Public Property GHI_CHU() As String
            Get
                Return _GHI_CHU
            End Get
            Set(ByVal value As String)
                _GHI_CHU = value
            End Set
        End Property

        Public Property ACCOUNT() As String
            Get
                Return _ACCOUNT
            End Get
            Set(ByVal value As String)
                _ACCOUNT = value
            End Set
        End Property

        Public Property SUBS() As String
            Get
                Return _SUBS
            End Get
            Set(ByVal value As String)
                _SUBS = value
            End Set
        End Property

    End Class

End Namespace
