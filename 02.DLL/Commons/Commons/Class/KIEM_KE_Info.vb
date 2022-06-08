
Imports System.Data
Imports System.Data.SqlClient
Imports Commons.QL.Common.Data
Imports Microsoft.ApplicationBlocks.Data
Namespace VS.Classes.Catalogue
    Public Class KIEM_KE_Info
        Private _NGAY As DateTime
        Private _MS_KHO As Integer
        Private _GIO As DateTime
        Private _LOCK As Boolean
        Public Sub New()

        End Sub

        Public Property NGAY() As DateTime
            Get
                Return _NGAY
            End Get
            Set(ByVal value As DateTime)
                _NGAY = value
            End Set
        End Property
        Public Property MS_KHO() As Integer
            Get
                Return _MS_KHO
            End Get
            Set(ByVal value As Integer)
                _MS_KHO = value
            End Set
        End Property
        Public Property GIO() As DateTime
            Get
                Return _GIO
            End Get
            Set(ByVal value As DateTime)
                _GIO = value
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
    End Class
End Namespace