
Imports Commons
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class utcTextBox
    Inherits DevExpress.XtraEditors.TextEdit
    Public Sub New()
        Me.BackColor = Color.White
    End Sub

#Region "Variables"
    Private _TypeMode As TypeMode
    Private _ErrorProvider As ErrorProvider
    Private _FieldName As String = ""
    Private _IsNull As Boolean = True
    Private _ReadOnly As Boolean = True
    Private _TextAlign As HorizontalAlignment = Nothing
    Private _PasswordChar As Char
    Private _Multiline As Boolean
    Private _MaxLength As Integer
    Private _CharacterCasing As System.Windows.Forms.CharacterCasing
#End Region

#Region "Properties"
    Public Property [CharacterCasing] As System.Windows.Forms.CharacterCasing
        Get
            Return _CharacterCasing
        End Get
        Set(ByVal value As System.Windows.Forms.CharacterCasing)
            _CharacterCasing = value
            Me.Properties.CharacterCasing = value
        End Set
    End Property


    Public Property [MaxLength]() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            Me.Properties.MaxLength = value
        End Set
    End Property

    Public Property [Multiline]() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
        End Set
    End Property

    Public Property PasswordChar() As Char
        Get
            Return _PasswordChar
        End Get
        Set(ByVal value As Char)
            _PasswordChar = value
            Me.Properties.PasswordChar = value
        End Set
    End Property


    Public Property [TextAlign]() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            Me.Properties.Appearance.Options.UseTextOptions = True
            If (value = HorizontalAlignment.Left) Then
                Me.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            ElseIf (value = HorizontalAlignment.Right) Then
                Me.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            ElseIf (value = HorizontalAlignment.Center) Then
                Me.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End If
        End Set
    End Property


    Public Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            Me.Properties.ReadOnly = value
        End Set
    End Property

    Public Property TextTypeMode() As TypeMode
        Get
            Return _TypeMode
        End Get
        Set(ByVal value As TypeMode)
            _TypeMode = value
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
    Public Property FieldName() As String
        Get
            Return _FieldName
        End Get
        Set(ByVal value As String)
            _FieldName = value

        End Set
    End Property
    Public Property IsNull() As Boolean
        Get
            Return _IsNull
        End Get
        Set(ByVal value As Boolean)
            _IsNull = value
        End Set
    End Property
#End Region

#Region "Methods"
    Public Function IsValidated() As Boolean
        If IsNull = True Then
            If Text.Length > 0 Then
                Return Validate()
            Else
                Return True
            End If
        Else
            If Text.Length < 1 Then
                ErrorProviderControl.SetError(Me, "Required enter data")
                Return False
            Else
                Return Validate()
            End If

        End If
    End Function
    'Const WM_NCPAINT As Integer = &H85
    'Const RDW_INVALIDATE As UInteger = &H1
    'Const RDW_IUPDATENOW As UInteger = &H100
    'Const RDW_FRAME As UInteger = &H400
    '<DllImport("user32.dll")>
    'Private Shared Function GetWindowDC(hWnd As IntPtr) As IntPtr
    'End Function
    '<DllImport("user32.dll")>
    'Private Shared Function ReleaseDC(hWnd As IntPtr, hDC As IntPtr) As Integer
    'End Function
    '<DllImport("user32.dll")>
    'Private Shared Function RedrawWindow(hWnd As IntPtr, lprc As IntPtr, hrgn As IntPtr, flags As UInteger) As Boolean
    'End Function
    Private m_borderColor As Color = ColorTranslator.FromHtml("#ABC1DE")
    Public Property BorderColor() As Color
        Get
            Return m_borderColor
        End Get
        Set
            m_borderColor = Value
            '  RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, RDW_FRAME Or RDW_IUPDATENOW Or RDW_INVALIDATE)

        End Set
    End Property
    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    MyBase.WndProc(m)
    '    If m.Msg = WM_NCPAINT AndAlso BorderColor <> Color.Transparent Then 'AndAlso BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle 

    '        Dim hdc = GetWindowDC(Me.Handle)
    '        Using g = Graphics.FromHdcInternal(hdc)
    '            Using p = New Pen(BorderColor)
    '                g.DrawRectangle(p, New Rectangle(0, 0, Width - 1, Height - 1))
    '            End Using
    '        End Using
    '        ReleaseDC(Me.Handle, hdc)
    '    End If
    'End Sub
    Function Validate() As Boolean
        Invalidate()
        If TextTypeMode = TypeMode.IsNumber Then
            Me.Text = Me.Text.Replace(",", "")
        End If
        Select Case TextTypeMode
            Case TypeMode.IsNumber
                Return RegexValidator.IsNumber(Me, ErrorProviderControl)
            Case TypeMode.IsCreditCardIDNumber
                Return RegexValidator.IsCreditCardIDNumber(Me, ErrorProviderControl)

            Case TypeMode.IsCreditCardNumber
                Return RegexValidator.IsCreditCardNumber(Me, ErrorProviderControl)

            Case TypeMode.IsEmailAddress
                Return RegexValidator.IsEmailAddress(Me, ErrorProviderControl)

            Case TypeMode.IsExperationDate
                Return RegexValidator.IsExperationDate(Me, ErrorProviderControl)

            Case TypeMode.IsIPAdress
                Return RegexValidator.IsIPAdress(Me, ErrorProviderControl)

            Case TypeMode.IsLongDate
                Return RegexValidator.IsLongDate(Me, ErrorProviderControl)

            Case TypeMode.IsPresent
                Return RegexValidator.IsPresent(Me, ErrorProviderControl, FieldName)

            Case TypeMode.IsShortDate
                Return RegexValidator.IsShortDate(Me, ErrorProviderControl)

            Case TypeMode.IsTime
                Return RegexValidator.IsTime(Me, ErrorProviderControl)

            Case TypeMode.IsURL
                Return RegexValidator.IsURL(Me, ErrorProviderControl)

            Case TypeMode.IsUSPhoneNumber
                Return RegexValidator.IsUSPhoneNumber(Me, ErrorProviderControl)

            Case TypeMode.IsUSSocialSecurityNumber
                Return RegexValidator.IsUSSocialSecurityNumber(Me, ErrorProviderControl)

            Case TypeMode.IsUSStateAbbreviation
                Return RegexValidator.IsUSStateAbbreviation(Me, ErrorProviderControl)

            Case TypeMode.IsUSZipCode
                Return RegexValidator.IsUSZipCode(Me, ErrorProviderControl)

            Case Else
                Return True
        End Select
    End Function
#End Region

    Private Sub Textbox_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            Me.BackColor = Color.White
        Else
            Me.BackColor = Color.White
        End If
    End Sub
#Region "Events"

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        On Error Resume Next
        MyBase.OnKeyPress(e)
        RegexValidator.ResetError(Me, ErrorProviderControl)
    End Sub

    Public Sub Clear()
        Me.ResetText()
    End Sub

#End Region

    Private Sub InitializeComponent()
        'Me.SuspendLayout()
        ''
        ''utcTextBox
        ''

        'Me.ResumeLayout(False)

    End Sub
End Class


Public Enum TypeMode
    None
    IsURL
    IsNumber
    IsTime
    IsPresent
    IsLongDate
    IsIPAdress
    IsShortDate
    IsUSZipCode
    IsEmailAddress
    IsUSPhoneNumber
    IsExperationDate
    IsCreditCardNumber
    IsCreditCardIDNumber
    IsUSStateAbbreviation
    IsUSSocialSecurityNumber
End Enum
