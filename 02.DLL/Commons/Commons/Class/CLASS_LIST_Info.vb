Public Class CLASS_LIST_Info
    Private _CLASS_ID As String
    Private _CLASS_CODE As String
    Private _CLASS_NAME As String
    Private _CLASS_NOTE As String

    Public Sub New()
        _CLASS_ID = clsTaoMa.RandomId("creatClassID", "CLASS_LIST", "CLASS_ID", "CLASS")
        _CLASS_CODE = ""
        _CLASS_NAME = ""
        _CLASS_NOTE = ""
    End Sub

    ' This is the public factory method.
    Public Shared Function CreateNew() As CLASS_LIST_Info
        Return New CLASS_LIST_Info()
    End Function

    Public Property CLASS_ID() As String
        Get
            Return _CLASS_ID
        End Get
        Set(ByVal value As String)
            _CLASS_ID = value
        End Set
    End Property
    Public Property CLASS_CODE() As String
        Get
            Return _CLASS_CODE
        End Get
        Set(ByVal value As String)
            _CLASS_CODE = value
        End Set
    End Property
    Public Property CLASS_NAME() As String
        Get
            Return _CLASS_NAME
        End Get
        Set(ByVal value As String)
            _CLASS_NAME = value
        End Set
    End Property
    Public Property CLASS_NOTE() As String
        Get
            Return _CLASS_NOTE
        End Get
        Set(ByVal value As String)
            _CLASS_NOTE = value
        End Set
    End Property
End Class