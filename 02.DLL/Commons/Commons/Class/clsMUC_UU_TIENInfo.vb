Namespace VS.Classes.Catalogue
    Public Class MUC_UU_TIENInfo
        Private _MS_UU_TIEN As Integer
        Private _TEN_UU_TIEN As String
        Private _MS_UU_TIEN_tmp As Integer
        Public Property MS_UU_TIEN() As Integer
            Get
                Return _MS_UU_TIEN
            End Get
            Set(ByVal value As Integer)
                _MS_UU_TIEN = value
            End Set
        End Property
        Public Property TEN_UU_TIEN() As String
            Get
                Return _TEN_UU_TIEN
            End Get
            Set(ByVal value As String)
                _TEN_UU_TIEN = value
            End Set
        End Property
        Public Property MS_UU_TIEN_tmp() As Integer
            Get
                Return _MS_UU_TIEN_tmp
            End Get
            Set(ByVal value As Integer)
                _MS_UU_TIEN_tmp = value
            End Set
        End Property
    End Class
End Namespace
