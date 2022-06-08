Imports System.IO
Imports System.Configuration

    Public Class IConnections
        Private Shared _Server As String
        Private Shared _Database As String
        Private Shared _Username As String
    Private Shared _Password As String

        Public Shared Property Server() As String
            Get
                Return _Server
            End Get
            Set(ByVal value As String)
                _Server = value
            End Set
        End Property
        Public Shared Property Database() As String
            Get
                Return _Database
            End Get
            Set(ByVal value As String)
                _Database = value
            End Set
        End Property
        Public Shared Property Username() As String
            Get
                Return _Username
            End Get
            Set(ByVal value As String)
                _Username = value
            End Set
        End Property
        Public Shared Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
            End Set
        End Property
        Public Shared ReadOnly Property ConnectionString() As String
            Get
            Return "Server=" & _Server & ";database=" & _Database & ";uid=" & _Username & ";pwd=" & _Password & ";Connect Timeout=0;"
            End Get
        End Property
    End Class