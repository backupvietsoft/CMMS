Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class QLGridComboBoxColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        Me.CellTemplate = New QLGridComboBoxCell
    End Sub
End Class

Public Class QLGridComboBoxCell
    Inherits DataGridViewComboBoxCell
    Public Sub New()

    End Sub

    Public Overloads Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(QLGridComboBoxEditingControl)
        End Get
    End Property

    Public Overloads Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        Dim ctrl As QLGridComboBoxEditingControl = CType(DataGridView.EditingControl, QLGridComboBoxEditingControl)
        ctrl.ownerCell = Me
    End Sub

End Class

Public Class QLGridComboBoxEditingControl
    Inherits DataGridViewComboBoxEditingControl

    Public ownerCell As QLGridComboBoxCell

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            Me.DroppedDown = False
        Else
            Me.DroppedDown = True
        End If

        MyBase.OnKeyPress(e)
    End Sub
End Class
