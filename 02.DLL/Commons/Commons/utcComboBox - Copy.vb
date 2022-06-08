Imports Microsoft.ApplicationBlocks.Data
Imports System.Data

Imports System.Windows.Forms
Imports System.Reflection
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.ComponentModel

Public Class UtcComboBox
    Inherits DevExpress.XtraEditors.LookUpEdit 'ComboBox
    Public Sub New()
        MyBase.New()
    End Sub


#Region "Variables"
    Private _StoreName As String = ""
    Private _Value As String = ""
    Private _Display As String = ""
    Private _Param As String = ""
    Private _Param2 As String = ""
    Private _ErrorProvider As ErrorProvider
    Private _IsNull As Boolean = True

    Private _isNew As Boolean
    Private _isInputNull As Boolean = False
    Private _isAll As Boolean
    Private _className As String = ""
    Private _assemblyName As String = "Application.ExecutablePath"
    Private _methodName As String = ""
    Private _dtTable As DataTable
    Private _itemNew As String = "...New"
    Private _itemAll As String = "<All>"
    Private _TextReadOnly As Boolean


#End Region

#Region "Properties"


    Public Property IsNull() As Boolean
        Get
            Return _IsNull
        End Get
        Set(ByVal value As Boolean)
            _IsNull = value
        End Set
    End Property
    Public Property StoreName() As String
        Get
            Return _StoreName
        End Get
        Set(ByVal value As String)
            _StoreName = value
        End Set
    End Property

    Public Property Param() As String
        Get
            Return _Param
        End Get
        Set(ByVal value As String)
            _Param = value
        End Set
    End Property
    Public Property Param2() As String
        Get
            Return _Param2
        End Get
        Set(ByVal value As String)
            _Param2 = value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property
    Public Property Display() As String
        Get
            Return _Display
        End Get
        Set(ByVal value As String)
            _Display = value
        End Set
    End Property
    Public Property ErrorProviderControl() As ErrorProvider
        Get
            Return _ErrorProvider
        End Get
        Set(ByVal value As ErrorProvider)
            _ErrorProvider = value
        End Set
    End Property
    Public Property IsNew() As Boolean
        Get
            Return _isNew
        End Get
        Set(ByVal value As Boolean)
            _isNew = value
        End Set
    End Property
    Public Property isInputNull() As Boolean
        Get
            Return _isInputNull
        End Get
        Set(ByVal value As Boolean)
            _isInputNull = value
        End Set
    End Property
    Public Property IsAll() As Boolean
        Get
            Return _isAll
        End Get
        Set(ByVal value As Boolean)
            _isAll = value
        End Set
    End Property
    Public Property ClassName() As String
        Get
            Return _className
        End Get
        Set(ByVal value As String)
            _className = value
        End Set
    End Property
    Public Property AssemblyName() As String
        Get
            Return _assemblyName
        End Get
        Set(ByVal value As String)
            _assemblyName = value
        End Set
    End Property
    Public Property MethodName() As String
        Get
            Return _methodName
        End Get
        Set(ByVal value As String)
            _methodName = value
        End Set
    End Property
    Public Property Table() As DataTable
        Get
            Return _dtTable
        End Get
        Set(ByVal value As DataTable)
            _dtTable = value
        End Set
    End Property
    Public Property ItemNew() As String
        Get
            Return _itemNew
        End Get
        Set(ByVal value As String)
            _itemNew = value
        End Set
    End Property

    Public Property ItemAll() As String
        Get
            Return _itemAll
        End Get
        Set(ByVal value As String)
            _itemAll = value
        End Set
    End Property
    Public Property TextReadonly() As Boolean
        Get
            Return _TextReadOnly
        End Get
        Set(ByVal value As Boolean)
            _TextReadOnly = value
        End Set
    End Property
#End Region

#Region "Public Methods"
    Public Sub BindDataSource()
        Try
            Me.BackColor = Color.White
            Dim dtTable As DataTable = New DataTable()
            Dim i As Integer
            'RemoveHandler Me.DrawItem, AddressOf Me.EnableDisplayCombo_DrawItem
            'RemoveHandler Me.EnabledChanged, AddressOf Me.EnableDisplayCombo_EnabledChanged
            RemoveHandler Me.SelectedValueChanged, AddressOf Me.ValueChanged

            If Param.Trim() = "" Then
                'Try
                dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, StoreName))
                'Catch ex As Exception
                '    'dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, StoreName, _Param))
                'End Try

            Else
                Try
                    If Param2.Trim() = "" Then
                        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, StoreName, Param))
                    Else
                        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, StoreName, Param, Param2))
                    End If

                Catch ex As Exception
                    dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, StoreName))
                End Try
            End If




            Dim dtRow As DataRow
            If _isAll Then
                If dtTable.Rows.Count > 0 Then
                    dtRow = dtTable.NewRow
                    dtRow(0) = -1
                    dtRow(1) = _itemAll

                    For i = 1 To dtTable.Columns.Count - 2
                        If IsNumeric(dtTable.Rows(0).Item(i + 1)) Then
                            dtRow(i + 1) = 0
                            Continue For
                        End If
                        'dtRow(i + 1) = 0
                        dtRow(i + 1) = _itemAll
                    Next
                    dtTable.Rows.InsertAt(dtRow, 0)
                End If
            End If

            If _isNew Then
                dtRow = dtTable.NewRow
                dtRow(0) = 0
                dtRow(1) = _itemNew
                For i = 1 To dtTable.Columns.Count - 2
                    dtRow(i + 1) = 0
                Next
                dtTable.Rows.Add(dtRow)
            End If
            If _isInputNull Then
                dtRow = dtTable.NewRow
                dtRow(0) = -99
                dtRow(1) = ""
                For i = 1 To dtTable.Columns.Count - 2
                    dtRow(i + 1) = ""
                Next
                dtTable.Rows.Add(dtRow)
            End If
            Me.SelectedIndex = -1
            Me.DataSource = dtTable
            Me.DisplayMember = Display
            Me.ValueMember = Value
            AddHandler Me.SelectedValueChanged, AddressOf Me.ValueChanged
        Catch ex As Exception

        End Try

    End Sub
    Public Function IsValidated() As Boolean
        If IsNull = True Then
            If IsNew = True And Text <> "...New" Then
                Text = ""
                Return True
            Else
                Return True
            End If
        Else
            If Text.Length < 1 Then
                ErrorProviderControl.SetError(Me, "Required enter data")
                Return False
            Else
                If IsNew = True Then
                    If Text = "...New" Then
                        ErrorProviderControl.SetError(Me, "Required enter data")
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
            End If

        End If
    End Function
    Function Validate() As Boolean
        'If Me.IsNull = True Then Return True
        Dim dtTable As DataTable = New DataTable()
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, Mid(StoreName, 1, Len(StoreName) - 1), Me.SelectedValue))
        If dtTable.Rows.Count = 0 Then
            ErrorProviderControl.SetError(Me, "Data not exist !")
            Me.Focus()
            Return False
        End If
        Return True
    End Function

#End Region

    Private _borderColor As Color = ColorTranslator.FromHtml("#ABC1DE")
    Private _borderStyle As ButtonBorderStyle = ButtonBorderStyle.Solid
    Private Shared WM_PAINT As Integer = &HF
    Private ArrowBrush As Brush = New SolidBrush(SystemColors.ControlText)
    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        If m.Msg = WM_PAINT Then
            Dim g As Graphics = Graphics.FromHwnd(Handle)
            Dim bounds As New Rectangle(0, 0, Width, Height)
            ControlPaint.DrawBorder(g, bounds, _borderColor, _borderStyle)
        End If
    End Sub

    <Category("Appearance")>
    Public Property BorderColor() As Color
        Get
            Return _borderColor
        End Get
        Set
            _borderColor = Value
            ' causes control to be redrawn
            Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property BorderStyle() As ButtonBorderStyle
        Get
            Return _borderStyle
        End Get
        Set
            _borderStyle = Value
            Invalidate()
        End Set
    End Property
#Region "Private methods"

    Sub EnableDisplayCombo_EnabledChanged(ByVal sender As Object, ByVal e As EventArgs)
        'If Me.Enabled Then
        Me.DropDownStyle = ComboBoxStyle.DropDownList
        'Else
        '    Me.DropDownStyle = ComboBoxStyle.DropDownList
        'End If
    End Sub

    Sub EnableDisplayCombo_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)
        'Dim g As System.Drawing.Graphics = e.Graphics
        'Dim r As Rectangle = e.Bounds

        'If e.Index >= 0 Then
        '    Dim label As String = CType(Me.Items(e.Index), DataRowView).Item(DisplayMember).ToString
        '    If e.State = (DrawItemState.Disabled Or DrawItemState.NoAccelerator Or DrawItemState.NoFocusRect Or DrawItemState.ComboBoxEdit) Then
        '        e.Graphics.FillRectangle(Brushes.White, r)
        '        g.DrawString(label, e.Font, Brushes.Black, r)
        '        e.DrawFocusRectangle()
        '    Else
        '        If e.State = (DrawItemState.NoAccelerator Or DrawItemState.NoFocusRect) Then
        '            e.Graphics.FillRectangle(Brushes.White, r)
        '            g.DrawString(label, e.Font, Brushes.Black, r)
        '            e.DrawFocusRectangle()
        '        Else
        '            e.Graphics.FillRectangle(Brushes.White, r)
        '            g.DrawString(label, e.Font, Brushes.Black, r)
        '            e.DrawFocusRectangle()
        '        End If
        '    End If
        'End If
        '    g.Dispose()
    End Sub



    Sub ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.SelectedItem Is Nothing Then Exit Sub
        Dim ID As String = CType(CType(Me.SelectedItem, DataRowView).Item(0).ToString, String)
        If String.IsNullOrEmpty(_assemblyName.ToString()) Then _assemblyName = "Application.ExecutablePath"

        If ID = "0" And IsNew = True Then
            Dim objForm As Object = QDynamicInvoke.InvokeNewForm(_assemblyName, _className, "ShowDialog", Nothing)
            Dim frm As Form = CType(objForm, Form)
            frm.ShowDialog()
            RemoveHandler Me.DrawItem, AddressOf Me.EnableDisplayCombo_DrawItem
            RemoveHandler Me.EnabledChanged, AddressOf Me.EnableDisplayCombo_EnabledChanged
            RemoveHandler Me.SelectedValueChanged, AddressOf Me.ValueChanged
            BindDataSource()
        End If
    End Sub
#End Region
#Region "Event"
    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '    MyBase.OnPaint(e)
    'End Sub
    Protected Overrides Sub OnSelectedValueChanged(ByVal e As System.EventArgs)
        Try
            MyBase.OnSelectedValueChanged(e)
            ErrorProviderControl.SetError(Me, Nothing)
        Catch ex As Exception

        End Try

    End Sub
#End Region

End Class
