Imports System
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace VS.Validation

    ' <summary>
    ' Created by Nghiem Quan, Lieu
    ' Create date: 21/06/06
    ' Description:	Class RegexValidatior Control
    ' </summary>
    ' <remarks></remarks>
    Public Class RegexValidator
        Private Sub New()
        End Sub

        Public Shared Function IsWithinRange(ByVal control As Control, ByVal errorProvider As ErrorProvider, ByVal min As Decimal, ByVal max As Decimal, ByVal fieldName As String) As Boolean
            Dim formatErrorString As String = "The number entered could not be converted to " & Microsoft.VisualBasic.Chr(10) & "" + "into a deciaml, please enter only numeric values."
            Dim errorString As String = fieldName + " must be between " & Microsoft.VisualBasic.Chr(10) & "" + min.ToString + " and " + max.ToString + "."
            Try
                Dim number As Decimal = Convert.ToDecimal(control.Text)
                If number <= min OrElse number >= max Then
                    errorProvider.SetError(control, errorString)
                    control.Focus()
                    Return False
                Else
                    errorProvider.SetError(control, Nothing)
                    Return True
                End If
            Catch generatedExceptionVariable0 As FormatException
                errorProvider.SetError(control, formatErrorString)
                control.Focus()
                Return False
            End Try
        End Function

        Public Shared Function IsUSPhoneNumber(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim phoneRegex As Regex = New Regex("^\(?[\d]{3}\)?[\s-]?[\d]{3}[\s-]?[\d]{4}$")
            Dim errorString As String = "The phone number must be in US format; " & Microsoft.VisualBasic.Chr(10) & "" + "i.e. (xxx) xxx-xxxx or (xxx)xxx-xxxx or " & Microsoft.VisualBasic.Chr(10) & "" + "xxx-xxx-xxxx"
            If Not phoneRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsUSZipCode(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            'Dim zipCodeRegex As Regex = New Regex("^(?(^00000(|-0000))|(\d{5}(|-\d{4})))$")
            Dim zipCodeRegex As Regex = New Regex("(\d{5}(|-\d{4}))$")
            Dim errorString As String = "The zip code must be in US format; " & Microsoft.VisualBasic.Chr(10) & "" + "i.e. 12345 or 12345-6789."
            If Not zipCodeRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsUSSocialSecurityNumber(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim ssnRegex As Regex = New Regex("^(?!000)([0-6]\d{2}|7([0-6]\d|7[012]))([ -]?)(?!00)\d\d\3(?!0000)\d{4}$")
            Dim errorString As String = "The social security number must be in US format; " & Microsoft.VisualBasic.Chr(10) & "" + "i.e. 123-45-6789 or 123 45 6789 or 123456789."
            If Not ssnRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsUSStateAbbreviation(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            control.Text = control.Text.ToUpper
            Dim stateRegex As Regex = New Regex("^(?-i:A[LKSZRAP]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[ADLN]|K[SY]|L" + "A|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|" + "V[AIT]|W[AIVY])$")
            Dim errorString As String = "The state must be in US abbreviation format; " & Microsoft.VisualBasic.Chr(10) & "" + "i.e. TX, AL, etc."
            If Not stateRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsCreditCardNumber(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim creditCardRegex As Regex = New Regex("(\d{6}[-\s]?\d{12})|(\d{4}[-\s]?\d{4}[-\s]?\d{4}[-\s]?\d{4})")
            Dim errorString As String = "The credit card number must be in the format " & Microsoft.VisualBasic.Chr(10) & "" + "5111 1111 1111 11118 or 1234123412341324 " & Microsoft.VisualBasic.Chr(10) & "" + "or 123456 123456789012."
            If Not creditCardRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsCreditCardIDNumber(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim idNumberRegex As Regex = New Regex("^([0-9]{3,4})$")
            Dim errorString As String = "The credit card idenification number must be " + "" & Microsoft.VisualBasic.Chr(10) & "" + "3 or 4 digits; i.e. 123 or 1234."
            If Not idNumberRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsExperationDate(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim expRegex As Regex = New Regex("^((0[1-9])|(1[0-2]))\/(\d{2})$")
            Dim errorString As String = "The experation date must be in " + "" & Microsoft.VisualBasic.Chr(10) & "" + "month/year format; " + " i.e. 01/05."
            If Not expRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsPresent(ByVal control As Control, ByVal errorProvider As ErrorProvider, ByVal fieldName As String) As Boolean
            Dim errorString As String = fieldName + " is a required field."
            If control.Text Is Nothing Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsLongDate(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim longDateRegex As Regex = New Regex("^((31(?!\ (Feb(ruary)?|Apr(il)?|June?|(Sept|Nov)(ember)?)))|((30|29)" + "(?!\ Feb(ruary)?))|(29(?=\ Feb(ruary)?\ (((1[6-9]|[2-9]\d)(0[48]|[2468]" + "[048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])" + "\ (Jan(uary)?|Feb(ruary)?|Ma(r(ch)?|y)|Apr(il)?|Ju((ly?)|(ne?))|Aug(ust)?|Oct" + "(ober)?|(Sept|Nov|Dec)(ember)?)\ ((1[6-9]|[2-9]\d)\d{2})$")
            Dim errorString As String = "The date must be in the day/month/year format; " & Microsoft.VisualBasic.Chr(10) & "" + "i.e. 01 Jan 2005 or 01 January 2005. Make sure the months " & Microsoft.VisualBasic.Chr(10) & "" + "name starts with a capital letter."
            If Not longDateRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsShortDate(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim shortDateRegex As Regex = New Regex("(?<Month>\d{1,2})/(?<Day>\d{1,2})/(?<Year>(?:\d{4}|\d{2}))")
            Dim errorString As String = "The date must be in the format dd/mm/yy or m/dd/yyy or " + "" & Microsoft.VisualBasic.Chr(10) & "" + "mm/dd/yy; i.e. 02/06/83, 6/02/83 or 06/02/1983 or 06/2/83."
            If Not shortDateRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsTime(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim timeRegex As Regex = New Regex("(?<Time>^(?:0?[1-9]:[0-5]|1(?=[012])\d:[0-5])\d(?:[ap]m)?)")
            Dim errorString As String = "The time must be in the format hh:mm AM or hh:mm PM or " & Microsoft.VisualBasic.Chr(10) & "" + "hh:mm; i.e. 4:45 PM or 4:45 AM or 4:45."
            If Not timeRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsEmailAddress(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim emailRegex As Regex = New Regex("^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")
            Dim errorString As String = "The email address must be in the correct format; " & Microsoft.VisualBasic.Chr(10) & "" + "i.e. someone@somewhere.com, .net, .org, etc."
            If Not emailRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsIPAdress(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim ipRegex As Regex = New Regex("^(?:(?:25[0-5]|2[0-4]\d|[01]\d\d|\d?\d)(?(?=\.?\d)\.)){4}$")
            Dim errorString As String = "The IP address must be in the correct format; " & Microsoft.VisualBasic.Chr(10) & "" + "i.e. 255.255.255.255."
            If Not ipRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function IsURL(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim urlRegex As Regex = New Regex("(?<http>(http:[/][/]|www.)([a-z]|[A-Z]|[0-9]|[/.]|[~])*)")
            Dim errorString As String = "The URL must be in the correct format; " & Microsoft.VisualBasic.Chr(10) & "" + "i.e. www.somewhere.com, or .net, .org, .uk, etc."
            If Not urlRegex.IsMatch(control.Text) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                errorProvider.SetError(control, Nothing)
                Return True
            End If
        End Function

        Public Shared Function ResetError(ByVal control As Control, ByVal errorProvider As ErrorProvider)
            Try

                errorProvider.SetError(control, Nothing)
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function IsNumber(ByVal control As Control, ByVal errorProvider As ErrorProvider) As Boolean
            Dim zipCodeRegex As Regex = New Regex("([0-9][0-9][0-9][0-9])")
            Dim errorString As String = "The data must be number; " & Microsoft.VisualBasic.Chr(10) & ""
            If Not zipCodeRegex.IsMatch(Right("000" & control.Text, 4)) Then
                errorProvider.SetError(control, errorString)
                control.Focus()
                Return False
            Else
                If CType(control.Text, Double) < 0 Then
                    errorProvider.SetError(control, errorString)
                    control.Focus()
                    Return False
                Else
                    errorProvider.SetError(control, Nothing)
                    Return True
                End If
                
            End If
        End Function
    End Class
End Namespace
