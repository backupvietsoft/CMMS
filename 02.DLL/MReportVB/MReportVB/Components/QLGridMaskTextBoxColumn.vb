Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Namespace VS.UserControls

    Public Class QLGridMaskedTextBoxColumn
        Inherits DataGridViewColumn

        Public Sub New()
            MyBase.New(New QLGridMaskedTextBoxCell())
        End Sub

        Private maskValue As String = ""
        ' <summary>
        ' MaskedTextBox
        ' </summary>
        Public Property Mask() As String
            Get
                Return Me.maskValue
            End Get
            Set(ByVal value As String)
                Me.maskValue = value
            End Set
        End Property

        Public Overrides Function Clone() As Object
            Dim col As QLGridMaskedTextBoxColumn = CType(MyBase.Clone(), QLGridMaskedTextBoxColumn)
            col.Mask = Me.Mask
            Return col
        End Function

        'CellTemplate
        Public Overrides Property CellTemplate() As DataGridViewCell
            Get
                Return MyBase.CellTemplate
            End Get
            Set(ByVal value As DataGridViewCell)
                'QLGridMaskedTextBoxCell CellTemplate
                If Not TypeOf value Is QLGridMaskedTextBoxCell Then
                    Throw New InvalidCastException( _
                        "Must be QLGridMaskedTextBoxCell")
                End If
                MyBase.CellTemplate = value
            End Set
        End Property
    End Class

    ' <summary>
    ' MaskedTextBox
    ' DataGridView
    ' </summary>
    Public Class QLGridMaskedTextBoxCell
        Inherits DataGridViewTextBoxCell

        Public Sub New()
        End Sub

        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

            Dim maskedBox As QLGridMaskedTextBoxEditingControl = _
                Me.DataGridView.EditingControl
            If Not (maskedBox Is Nothing) Then
                maskedBox.Text = IIf(Me.Value Is Nothing, "", Me.Value.ToString())
                Dim column As QLGridMaskedTextBoxColumn = Me.OwningColumn
                If Not (column Is Nothing) Then
                    maskedBox.Mask = column.Mask
                End If
            End If

        End Sub

        Public Overrides ReadOnly Property EditType() As Type
            Get
                Return GetType(QLGridMaskedTextBoxEditingControl)
            End Get
        End Property

        Public Overrides ReadOnly Property ValueType() As Type
            Get
                Return GetType(Object)
            End Get
        End Property

        Public Overrides ReadOnly Property DefaultNewRowValue() As Object
            Get
                Return MyBase.DefaultNewRowValue
            End Get
        End Property
    End Class

    ' <summary>
    ' QLGridMaskedTextBoxCell
    ' MaskedTextBox
    ' </summary>
    Public Class QLGridMaskedTextBoxEditingControl
        Inherits MaskedTextBox
        Implements IDataGridViewEditingControl

        Private dataGridView As DataGridView
        Private rowIndex As Integer
        Private valueChanged As Boolean

        Public Sub New()
            Me.TabStop = False
        End Sub

        Public Function GetEditingControlFormattedValue( _
            ByVal context As DataGridViewDataErrorContexts) As Object _
            Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

            Return Me.Text
        End Function

        Public Property EditingControlFormattedValue() As Object _
            Implements IDataGridViewEditingControl.EditingControlFormattedValue
            Get
                Return Me.GetEditingControlFormattedValue( _
                    DataGridViewDataErrorContexts.Formatting)
            End Get
            Set(ByVal value As Object)
                Me.Text = CStr(value)
            End Set
        End Property


        Public Sub ApplyCellStyleToEditingControl( _
            ByVal dataGridViewCellStyle As DataGridViewCellStyle) _
            Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

            Me.Font = dataGridViewCellStyle.Font
            Me.ForeColor = dataGridViewCellStyle.ForeColor
            Me.BackColor = dataGridViewCellStyle.BackColor
            Select Case dataGridViewCellStyle.Alignment
                Case DataGridViewContentAlignment.BottomCenter, _
                        DataGridViewContentAlignment.MiddleCenter, _
                        DataGridViewContentAlignment.TopCenter
                    Me.TextAlign = HorizontalAlignment.Center
                Case DataGridViewContentAlignment.BottomRight, _
                        DataGridViewContentAlignment.MiddleRight, _
                        DataGridViewContentAlignment.TopRight
                    Me.TextAlign = HorizontalAlignment.Right
                Case Else
                    Me.TextAlign = HorizontalAlignment.Left
            End Select
        End Sub

        Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
            Get
                Return Me.dataGridView
            End Get
            Set(ByVal value As DataGridView)
                Me.dataGridView = value
            End Set
        End Property

        Public Property EditingControlRowIndex() As Integer _
            Implements IDataGridViewEditingControl.EditingControlRowIndex
            Get
                Return Me.rowIndex
            End Get
            Set(ByVal value As Integer)
                Me.rowIndex = value
            End Set
        End Property

        Public Property EditingControlValueChanged() As Boolean _
            Implements IDataGridViewEditingControl.EditingControlValueChanged
            Get
                Return Me.valueChanged
            End Get
            Set(ByVal value As Boolean)
                Me.valueChanged = value
            End Set
        End Property

        Public Function EditingControlWantsInputKey(ByVal keyData As Keys, _
            ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
            Implements IDataGridViewEditingControl.EditingControlWantsInputKey

            Select Case keyData And Keys.KeyCode
                Case Keys.Right, Keys.End, Keys.Left, Keys.Home
                    Return True
                Case Else
                    Return False
            End Select
        End Function

        Public ReadOnly Property EditingPanelCursor() As Cursor _
            Implements IDataGridViewEditingControl.EditingPanelCursor
            Get
                Return MyBase.Cursor
            End Get
        End Property

        Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
            Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

            If selectAll Then
                Me.SelectAll()
            Else
                Me.SelectionStart = Me.TextLength
            End If
        End Sub

        Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
            MyBase.OnTextChanged(e)
            Me.valueChanged = True
            Me.dataGridView.NotifyCurrentCellDirty(True)
        End Sub

        Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements System.Windows.Forms.IDataGridViewEditingControl.RepositionEditingControlOnValueChange
            Get
                Return False
            End Get
        End Property
    End Class

End Namespace