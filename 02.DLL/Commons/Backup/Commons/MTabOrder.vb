

Imports System
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics

Public Class MTabOrder
    Private Class MTabScheme
        Implements IComparer

        Private comparisonScheme As TabScheme

#Region "IComparer Members"

        Public Overridable Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare

            Dim control1 As Control = CType(x, Control)
            Dim control2 As Control = CType(y, Control)

            If IsNothing(control1) Or IsNothing(control2) Then
                Debug.Assert(False, "Attempting to compare a non-control")
                Return 0
            End If

            If comparisonScheme = TabScheme.AcrossFirst Then

                If control1.Top < control2.Top Then
                    Return -1
                ElseIf control1.Top > control2.Top Then
                    Return 1
                Else
                    Return (control1.Left.CompareTo(control2.Left))
                End If
            Else
                If control1.Left < control2.Left Then
                    Return -1
                ElseIf control1.Left > control2.Left Then
                    Return 1
                Else
                    Return (control1.Top.CompareTo(control2.Top))
                End If
            End If
        End Function

#End Region
        Public Sub New(ByVal scheme As TabScheme)
            comparisonScheme = scheme
        End Sub

    End Class

    Private container As Control
    Private schemeOverrides As Hashtable
    Private curTabIndex As Integer = 0
    Public Enum TabScheme
        None
        AcrossFirst
        DownFirst
    End Enum
    Public Sub New(ByVal container As Control)
        Me.container = container
        Me.curTabIndex = 0
        Me.schemeOverrides = New Hashtable
    End Sub

    Private Sub New(ByVal container As Control, ByVal curTabIndex As Integer, ByVal schemeOverrides As Hashtable)
        Me.container = container
        Me.curTabIndex = curTabIndex
        Me.schemeOverrides = schemeOverrides
    End Sub

    Public Sub SetSchemeForControl(ByVal c As Control, ByVal scheme As TabScheme)
        schemeOverrides(c) = scheme
    End Sub

    Public Function MSetTabOrder(ByVal scheme As TabScheme) As Integer
        Try
            Dim controlArraySorted As New ArrayList
            controlArraySorted.AddRange(container.Controls)
            controlArraySorted.Sort(New MTabScheme(scheme))

            Dim c As Control
            For Each c In controlArraySorted
                c.TabIndex = curTabIndex
                curTabIndex = curTabIndex + 1

                If c.Controls.Count > 0 Then
                    Dim childScheme As TabScheme = scheme
                    If schemeOverrides.Contains(c) Then
                        childScheme = CType(schemeOverrides(c), TabScheme)
                    End If
                    curTabIndex = (New MTabOrder(c, curTabIndex, schemeOverrides)).MSetTabOrder(childScheme)
                End If
            Next c

            Return curTabIndex
        Catch e As Exception
            Debug.Assert(False, "Exception in TabOrderManager.SetTabOrder:  " + e.Message)
            Return 0
        End Try
    End Function
End Class
