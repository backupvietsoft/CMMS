Namespace VS.Classes.Catalogue
    Public Class NGAN_SACHInfo
        Private _MS_BP_CHIU_PHI As Integer
        Private _NGAN_SACH_NAM As Integer
        Private _SO_TIEN As Integer
        Private _NGOAI_TE As String
        Public Property MS_BP_CHIU_PHI() As Integer
            Get
                Return _MS_BP_CHIU_PHI
            End Get
            Set(ByVal value As Integer)
                _MS_BP_CHIU_PHI = value
            End Set
        End Property
        Public Property NGAN_SACH_NAM() As Integer
            Get
                Return _NGAN_SACH_NAM
            End Get
            Set(ByVal value As Integer)
                _NGAN_SACH_NAM = value
            End Set
        End Property
        Public Property SO_TIEN() As Integer
            Get
                Return _SO_TIEN
            End Get
            Set(ByVal value As Integer)
                _SO_TIEN = value
            End Set
        End Property
        Public Property NGOAI_TE() As String
            Get
                Return _NGOAI_TE
            End Get
            Set(ByVal value As String)
                _NGOAI_TE = value
            End Set
        End Property
    End Class
End Namespace
