'Imports VS.Validation
Imports Commons
Imports System.Windows.Forms
Imports System.Drawing

' <summary>
' Created by Nghiem Quan, Lieu
' Create date: 21/06/06
' Description:	TextBox User Control
' </summary>
' <remarks></remarks>
Public Class utcTextBox
    Inherits TextBox
    Public Sub New()
        Me.BackColor = Color.White
    End Sub

#Region "Variables"
    Private _TypeMode As TypeMode
    Private _ErrorProvider As ErrorProvider
    Private _FieldName As String = ""
    Private _IsNull As Boolean = True
#End Region

#Region "Properties"
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
    Function Validate() As Boolean
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

    'Private Sub Textbox_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
    '    If Me.Enabled Then
    '        Me.BackColor = Color.White
    '    Else
    '        Me.BackColor = Color.White
    '    End If
    'End Sub
#Region "Events"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        On Error Resume Next
        MyBase.OnKeyPress(e)
        RegexValidator.ResetError(Me, ErrorProviderControl)
    End Sub


#End Region

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'utcTextBox
        '
        Me.ResumeLayout(False)

    End Sub
End Class


' <summary>
' Created by Nghiem Quan, Lieu
' Create date: 21/06/06
' Description:	TypeMode of TextBox User Control
' </summary>
' <remarks></remarks>
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
