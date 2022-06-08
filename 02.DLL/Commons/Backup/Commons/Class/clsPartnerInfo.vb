Namespace VS.Classes.Partner
    Public Class PartnerInfo
        Private _ID As Integer
        Private _PartnerName As String
        Private _Address As String
        Private _Phone As String
        Private _Fax As String
        Private _Email As String

        Public Sub New()

        End Sub

#Region "Property"

        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        Public Property PartnerName() As String
            Get
                Return _PartnerName
            End Get
            Set(ByVal value As String)
                _PartnerName = value
            End Set
        End Property
        Public Property Address() As String
            Get
                Return _Address
            End Get
            Set(ByVal value As String)
                _Address = value
            End Set
        End Property
        Public Property Phone() As String
            Get
                Return _Phone
            End Get
            Set(ByVal value As String)
                _Phone = value
            End Set
        End Property
        Public Property Fax() As String
            Get
                Return _Fax
            End Get
            Set(ByVal value As String)
                _Fax = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property
#End Region

    End Class
End Namespace
