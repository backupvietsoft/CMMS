Namespace VS.Classes.Catalogue
    Public Class clsEORInfo
        Private _EOR_ID As String
        Private _MS_MAY As String
        Private _MO_TA_VAN_DE As String
        Private _BAN_TO_LAP As Integer
        Private _NGAY_LAP As DateTime
        Private _NGUOI_LAP As String
        Private _MS_UU_TIEN As Integer
        Private _MS_CN As String
        Private _MS_CN1 As String
        Private _NGAY_KT_EOR As String
        Private _NGAY_BD_KH As DateTime
        Private _NGAY_KT_KH As DateTime
        Private _LEADER_DUYET As Boolean
        Private _LEADER_COMMENT As String
        Private _GHI_CHU_1 As String
        Private _COST_CONTROL_DUYET As Boolean
        Private _COST_CONTROL_COMMENT As String
        Private _GHI_CHU_2 As String
        Private _HEAD_DUYET As Boolean
        Private _GHI_CHU_3 As String
        Private _HEAD_COMMENT As String
        Private _MANAGER_DUYET As String
        Private _GHI_CHU_4 As String
        Private _SO_ROA As String
        Private _NGAY_ROA As String
        Private _LOCK As Boolean
        Private _LY_DO_KHAC As String
        Private _LEADER_NAME As String
        Private _COST_CONTROL_NAME As String
        Private _HEAD_NAME As String
        Private _MANAGER_NAME As String
        Public Property EOR_ID() As String
            Get
                Return _EOR_ID
            End Get
            Set(ByVal value As String)
                _EOR_ID = value
            End Set
        End Property
        Public Property MS_MAY() As String
            Get
                Return _MS_MAY
            End Get
            Set(ByVal value As String)
                _MS_MAY = value
            End Set
        End Property
        Public Property MO_TA_VAN_DE() As String
            Get
                Return _MO_TA_VAN_DE
            End Get
            Set(ByVal value As String)
                _MO_TA_VAN_DE = value
            End Set
        End Property
        Public Property BAN_TO_LAP() As Integer
            Get
                Return _BAN_TO_LAP
            End Get
            Set(ByVal value As Integer)
                _BAN_TO_LAP = value
            End Set
        End Property
        Public Property NGAY_LAP() As DateTime
            Get
                Return _NGAY_LAP
            End Get
            Set(ByVal value As DateTime)
                _NGAY_LAP = value
            End Set
        End Property
        Public Property NGUOI_LAP() As String
            Get
                Return _NGUOI_LAP
            End Get
            Set(ByVal value As String)
                _NGUOI_LAP = value
            End Set
        End Property
        Public Property MS_UU_TIEN() As Integer
            Get
                Return _MS_UU_TIEN
            End Get
            Set(ByVal value As Integer)
                _MS_UU_TIEN = value
            End Set
        End Property
        Public Property MS_CN() As String
            Get
                Return _MS_CN
            End Get
            Set(ByVal value As String)
                _MS_CN = value
            End Set
        End Property
        Public Property MS_CN1() As String
            Get
                Return _MS_CN1
            End Get
            Set(ByVal value As String)
                _MS_CN1 = value
            End Set
        End Property
        Public Property NGAY_KT_EOR() As String
            Get
                Return _NGAY_KT_EOR
            End Get
            Set(ByVal value As String)
                _NGAY_KT_EOR = value
            End Set
        End Property
        Public Property NGAY_BD_KH() As DateTime
            Get
                Return _NGAY_BD_KH
            End Get
            Set(ByVal value As DateTime)
                _NGAY_BD_KH = value
            End Set
        End Property
        Public Property NGAY_KT_KH() As DateTime
            Get
                Return _NGAY_KT_KH
            End Get
            Set(ByVal value As DateTime)
                _NGAY_KT_KH = value
            End Set
        End Property
        Public Property LEADER_DUYET() As Boolean
            Get
                Return _LEADER_DUYET
            End Get
            Set(ByVal value As Boolean)
                _LEADER_DUYET = value
            End Set
        End Property
        Public Property LEADER_COMMENT() As String
            Get
                Return _LEADER_COMMENT
            End Get
            Set(ByVal value As String)
                _LEADER_COMMENT = value
            End Set
        End Property
        Public Property GHI_CHU_1() As String
            Get
                Return _GHI_CHU_1
            End Get
            Set(ByVal value As String)
                _GHI_CHU_1 = value
            End Set
        End Property
        Public Property COST_CONTROL_DUYET() As Boolean
            Get
                Return _COST_CONTROL_DUYET
            End Get
            Set(ByVal value As Boolean)
                _COST_CONTROL_DUYET = value
            End Set
        End Property
        Public Property COST_CONTROL_COMMENT() As String
            Get
                Return _COST_CONTROL_COMMENT
            End Get
            Set(ByVal value As String)
                _COST_CONTROL_COMMENT = value
            End Set
        End Property
        Public Property GHI_CHU_2() As String
            Get
                Return _GHI_CHU_2
            End Get
            Set(ByVal value As String)
                _GHI_CHU_2 = value
            End Set
        End Property
        Public Property HEAD_DUYET() As Boolean
            Get
                Return _HEAD_DUYET
            End Get
            Set(ByVal value As Boolean)
                _HEAD_DUYET = value
            End Set
        End Property
        Public Property HEAD_COMMENT() As String
            Get
                Return _HEAD_COMMENT
            End Get
            Set(ByVal value As String)
                _HEAD_COMMENT = value
            End Set
        End Property
        Public Property GHI_CHU_3() As String
            Get
                Return _GHI_CHU_3
            End Get
            Set(ByVal value As String)
                _GHI_CHU_3 = value
            End Set
        End Property
        Public Property MANAGER_DUYET() As Boolean
            Get
                Return _MANAGER_DUYET
            End Get
            Set(ByVal value As Boolean)
                _MANAGER_DUYET = value
            End Set
        End Property
        
        Public Property GHI_CHU_4() As String
            Get
                Return _GHI_CHU_4
            End Get
            Set(ByVal value As String)
                _GHI_CHU_4 = value
            End Set
        End Property
        Public Property SO_ROA() As String
            Get
                Return _SO_ROA
            End Get
            Set(ByVal value As String)
                _SO_ROA = value
            End Set
        End Property
        Public Property NGAY_ROA() As String
            Get
                Return _NGAY_ROA
            End Get
            Set(ByVal value As String)
                _NGAY_ROA = value
            End Set
        End Property
        Public Property LOCK() As Boolean
            Get
                Return _LOCK
            End Get
            Set(ByVal value As Boolean)
                _LOCK = value
            End Set
        End Property
        Public Property LY_DO_KHAC() As String
            Get
                Return _LY_DO_KHAC
            End Get
            Set(ByVal value As String)
                _LY_DO_KHAC = value
            End Set
        End Property
        Public Property LEADER_NAME() As String
            Get
                Return _LEADER_NAME
            End Get
            Set(ByVal value As String)
                _LEADER_NAME = value
            End Set
        End Property
        Public Property COST_CONTROL_NAME() As String
            Get
                Return _COST_CONTROL_NAME
            End Get
            Set(ByVal value As String)
                _COST_CONTROL_NAME = value
            End Set
        End Property
        Public Property HEAD_NAME() As String
            Get
                Return _HEAD_NAME
            End Get
            Set(ByVal value As String)
                _HEAD_NAME = value
            End Set
        End Property
        Public Property MANAGER_NAME() As String
            Get
                Return _MANAGER_NAME
            End Get
            Set(ByVal value As String)
                _MANAGER_NAME = value
            End Set
        End Property
    End Class
End Namespace
