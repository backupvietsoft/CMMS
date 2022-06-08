Namespace VS.Classes.Catalogue
    Public Class clsMAY_ATTACHMENTInfo
        Private _TU_NGAY As String
        Private _DEN_NGAY As String
        Private _MS_MAY As String
        Private _MS_ATTACHMENT As String
        Private _MS_ATTACHMENT_TMP As String
        Private _TU_NGAY_TMP As String
        Public Property MS_MAY() As String
            Get
                Return _MS_MAY
            End Get
            Set(ByVal value As String)
                _MS_MAY = value
            End Set
        End Property
        Public Property MS_ATTACHMENT() As String
            Get
                Return _MS_ATTACHMENT
            End Get
            Set(ByVal value As String)
                _MS_ATTACHMENT = value
            End Set
        End Property
        Public Property TU_NGAY() As String
            Get
                Return _TU_NGAY
            End Get
            Set(ByVal value As String)
                _TU_NGAY = value
            End Set
        End Property
        Public Property DEN_NGAY() As String
            Get
                Return _DEN_NGAY
            End Get
            Set(ByVal value As String)
                _DEN_NGAY = value
            End Set
        End Property
        Public Property MS_ATTACHMENT_TMP() As String
            Get
                Return _MS_ATTACHMENT_TMP
            End Get
            Set(ByVal value As String)
                _MS_ATTACHMENT_TMP = value
            End Set
        End Property
        Public Property TU_NGAY_TMP() As String
            Get
                Return _TU_NGAY_TMP
            End Get
            Set(ByVal value As String)
                _TU_NGAY_TMP = value
            End Set
        End Property
    End Class
End Namespace
