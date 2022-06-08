Imports System.Net.Mail
Imports System.Text
Imports System.Net
Imports Microsoft.ApplicationBlocks


Public Class MMail
    'Danh sách email được ngăn cách nhau bởi dấu ";"
#Region "Goi Mail"
    Dim myHost As String = System.Net.Dns.GetHostName.Trim

    Public Function MSendEmail(ByVal SendTo As String, _
                                ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                                ByVal AttachmentPath As String, ByVal sSmtp As String, ByVal sPort As String) As String
        Try
            If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
                SendTo = "ecomaint.cmms@gmail.com"
            End If
            Commons.Modules.ObjSystems.MBoMailUser(SendTo)

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()
            'If Commons.Modules.ObjSystems.MCheckEmail(SendTo, mMailF) = False Then
            '    result = False
            '    Return "Invalid e-mail. - " + mMailF
            'End If

            Dim mMailF As String
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If

            If result = True Then
                Try

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))

                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If



                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If


                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject

                    '#Region "Kiem Attach"
                    If AttachmentPath.Trim() <> "" Then
                        MAddAttachment(message, AttachmentPath)
                    End If

                    '#End Region
                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    client.Send(message)
                    message.Dispose()
                    Return ""
                Catch ex As Exception
                    Return ex.Message
                End Try
            Else
                Return "Email not sent"
            End If
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function MSendEmail(ByVal SendTo As String, ByVal SendCC As String, _
                                ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                                ByVal AttachmentPath As String, ByVal sSmtp As String, ByVal sPort As String) As String
        Try
            If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
                SendTo = "ecomaint.cmms@gmail.com"
                SendCC = ""
            End If
            Commons.Modules.ObjSystems.MBoMailUser(SendTo)
            Commons.Modules.ObjSystems.MBoMailUser(SendCC)


            'Danh sách email được ngăn cách nhau bởi dấu ";"

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()
            Dim mMailF As String
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If

            mMailF = ""
            If Not MKiemMail(SendCC, mMailF) Then
                result = False
                Return mMailF
            End If

            If result = True Then
                Try

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If

                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject


                    '#Region "Kiem CC"
                    result = True
                    If SendCC.Trim() <> "" Then
                        ALL_EMAILS = SendCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.CC.Add(emailaddress)
                            End If
                        Next
                    End If

                    '#End Region

                    '#Region "Kiem Attach"
                    If AttachmentPath.Trim() <> "" Then
                        'Dim attach As New Attachment(AttachmentPath)
                        'message.Attachments.Add(attach)
                        MAddAttachment(message, AttachmentPath)
                    End If
                    '#End Region
                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    client.Send(message)
                    message.Dispose()
                    Return ""
                Catch ex As Exception
                    Return ex.Message
                End Try
            Else
                Return "Email not sent"
            End If
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function MSendEmail(ByVal SendTo As String, ByVal SendCC As String, ByVal SendBCC As String, _
                            ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                            ByVal AttachmentPath As String, ByVal sSmtp As String, ByVal sPort As String) As String
        Try
            If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
                SendTo = "ecomaint.cmms@gmail.com"
                SendCC = ""
                SendBCC = ""
            End If

            Commons.Modules.ObjSystems.MBoMailUser(SendTo)
            Commons.Modules.ObjSystems.MBoMailUser(SendCC)
            Commons.Modules.ObjSystems.MBoMailUser(SendBCC)

            'Danh sách email được ngăn cách nhau bởi dấu ";"
            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()
            Dim mMailF As String
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If

            mMailF = ""
            If Not MKiemMail(SendCC, mMailF) Then
                result = False
                Return mMailF
            End If

            If result = True Then
                Try

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If

                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject


                    '#Region "Kiem CC"
                    result = True
                    If SendCC.Trim() <> "" Then
                        ALL_EMAILS = SendCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.CC.Add(emailaddress)
                            End If
                        Next
                    End If

                    '#End Region

                    '#Region "Kiem BCC"
                    result = True
                    If SendBCC.Trim() <> "" Then
                        ALL_EMAILS = SendBCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.Bcc.Add(emailaddress)
                            End If
                        Next
                    End If
                    '#End Region

                    '#Region "Kiem Attach"
                    If AttachmentPath.Trim() <> "" Then
                        'Dim attach As New Attachment(AttachmentPath)
                        'message.Attachments.Add(attach)
                        MAddAttachment(message, AttachmentPath)
                    End If
                    '#End Region
                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    client.Send(message)
                    message.Dispose()
                    Return ""
                Catch ex As Exception
                    Return ex.Message
                End Try
            Else
                Return "Email not sent"
            End If
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

#Region "Goi Mail"
    Public Function MGoiMail(ByVal xlWorkBook As Excel.Workbook, ByVal sPath As String, ByVal sPathFileSend As String, ByVal sMail As String, ByVal sMailCC As String, ByVal sTieuDe As String, _
     ByVal sBody As String, ByRef sKetQuaSent As String) As [Boolean]
        Try
            xlWorkBook.SaveAs(sPathFileSend, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, False, False, _
             Excel.XlSaveAsAccessMode.xlShared, False, False, Type.Missing, Type.Missing)
            Commons.Modules.ObjSystems.Xoahinh(sPath)
            Commons.Modules.ObjSystems.Xoahinh(sPath)

            Dim sKetQua As String

            If sMailCC = "" Then
                sKetQua = Commons.Modules.MMail.MSendEmail(sMail, Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, sTieuDe, sBody, sPathFileSend, _
                 Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort)
            Else
                sKetQua = Commons.Modules.MMail.MSendEmail(sMail, sMailCC, Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, sTieuDe, sBody, _
                 sPathFileSend, Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort)
            End If


            Commons.Modules.ObjSystems.Xoahinh(sPathFileSend)
            Commons.Modules.ObjSystems.Xoahinh(sPathFileSend)

            Select Case sKetQua.ToUpper()
                Case "Invalid e-mail."
                    sKetQuaSent = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPBTBanHanh", "KhongPhaiMail", Commons.Modules.TypeLanguage)
                    Return False
                Case "Email not sent"
                    sKetQuaSent = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPBTBanHanh", "KhongGoiDuoc", Commons.Modules.TypeLanguage)
                    Return False
                Case ""
                    sKetQuaSent = ""
                    Return True
                Case Else
                    sKetQuaSent = sKetQua
                    Return False
            End Select
        Catch ex As Exception
            sKetQuaSent = ex.Message
            Return False
        End Try

    End Function

#End Region


#End Region

#Region "Goi Mail Co ProgressBar"

    Public Function MSendEmail(ByVal SendTo As String, _
                                ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                                ByVal AttachmentPath As String, ByVal sSmtp As String, ByVal sPort As String, _
                                ByVal prbBar As DevExpress.XtraEditors.ProgressBarControl) As String
        If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
            SendTo = "ecomaint.cmms@gmail.com"
        End If
        Commons.Modules.ObjSystems.MBoMailUser(SendTo)

        Dim iViTri As Integer
        iViTri = prbBar.Position + 9
        Try

            prbBar.PerformStep()
            prbBar.Update()

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()

            prbBar.PerformStep()
            prbBar.Update()

            Dim mMailF As String
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If


            prbBar.PerformStep()
            prbBar.Update()
            If result = True Then
                Try
                    prbBar.PerformStep()
                    prbBar.Update()

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If

                    prbBar.PerformStep()
                    prbBar.Update()

                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject

                    prbBar.PerformStep()
                    prbBar.Update()


                    '#Region "Kiem Attach"
                    If AttachmentPath.Trim() <> "" Then
                        'Dim attach As New Attachment(AttachmentPath)
                        'message.Attachments.Add(attach)
                        MAddAttachment(message, AttachmentPath)
                    End If

                    prbBar.PerformStep()
                    prbBar.Update()


                    '#End Region
                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    prbBar.PerformStep()
                    prbBar.Update()


                    client.Send(message)
                    message.Dispose()

                    prbBar.PerformStep()
                    prbBar.Update()

                    prbBar.Position = iViTri

                    Return ""
                Catch ex As Exception
                    prbBar.Position = iViTri
                    Return ex.Message
                End Try
            Else
                prbBar.Position = iViTri
                Return "Email not sent"
            End If
        Catch ex As Exception
            prbBar.Position = iViTri
            Return ex.Message
        End Try
    End Function

    Public Function MSendEmail(ByVal SendTo As String, ByVal SendCC As String, _
                                ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                                ByVal AttachmentPath As String, ByVal sSmtp As String, ByVal sPort As String, _
                                ByVal prbBar As DevExpress.XtraEditors.ProgressBarControl) As String
        If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
            SendTo = "ecomaint.cmms@gmail.com"
            SendCC = ""
        End If
        Commons.Modules.ObjSystems.MBoMailUser(SendTo)
        Commons.Modules.ObjSystems.MBoMailUser(SendCC)

        Dim iViTri As Integer
        iViTri = prbBar.Position + 9

        Try
            prbBar.PerformStep()
            prbBar.Update()

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()
            prbBar.PerformStep()
            prbBar.Update()

            Dim mMailF As String
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If

            mMailF = ""
            If Not MKiemMail(SendCC, mMailF) Then
                result = False
                Return mMailF
            End If


            prbBar.PerformStep()
            prbBar.Update()

            If result = True Then
                Try
                    prbBar.PerformStep()
                    prbBar.Update()

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If

                    prbBar.PerformStep()
                    prbBar.Update()

                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject

                    prbBar.PerformStep()
                    prbBar.Update()

                    '#Region "Kiem CC"
                    result = True
                    If SendCC.Trim() <> "" Then
                        ALL_EMAILS = SendCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.CC.Add(emailaddress)
                            End If
                        Next
                    End If

                    '#End Region
                    prbBar.PerformStep()
                    prbBar.Update()

                    '#Region "Kiem Attach"
                    If AttachmentPath.Trim() <> "" Then
                        'Dim attach As New Attachment(AttachmentPath)
                        'message.Attachments.Add(attach)
                        MAddAttachment(message, AttachmentPath)
                    End If
                    '#End Region
                    prbBar.PerformStep()
                    prbBar.Update()

                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    client.Send(message)
                    message.Dispose()
                    prbBar.PerformStep()
                    prbBar.Update()

                    prbBar.Position = iViTri
                    Return ""
                Catch ex As Exception
                    prbBar.Position = iViTri
                    Return ex.Message
                End Try
            Else
                prbBar.Position = iViTri
                Return "Email not sent"
            End If
        Catch ex As Exception
            prbBar.Position = iViTri
            Return ex.Message
        End Try
    End Function

    Public Function MSendEmail(ByVal SendTo As String, ByVal SendCC As String, ByVal SendBCC As String, _
                            ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                            ByVal AttachmentPath As String, ByVal sSmtp As String, ByVal sPort As String, _
                                ByVal prbBar As DevExpress.XtraEditors.ProgressBarControl) As String
        If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
            SendTo = "ecomaint.cmms@gmail.com"
            SendCC = ""
            SendBCC = ""
        End If
        Commons.Modules.ObjSystems.MBoMailUser(SendTo)
        Commons.Modules.ObjSystems.MBoMailUser(SendCC)
        Commons.Modules.ObjSystems.MBoMailUser(SendBCC)

        Dim iViTri As Integer
        iViTri = prbBar.Position + 9

        Try
            prbBar.PerformStep()
            prbBar.Update()

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()
            prbBar.PerformStep()
            prbBar.Update()

            Dim mMailF As String
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If

            mMailF = ""
            If Not MKiemMail(SendCC, mMailF) Then
                result = False
                Return mMailF
            End If

            prbBar.PerformStep()
            prbBar.Update()

            If result = True Then
                Try
                    prbBar.PerformStep()
                    prbBar.Update()

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If

                    prbBar.PerformStep()
                    prbBar.Update()

                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject
                    prbBar.PerformStep()
                    prbBar.Update()


                    '#Region "Kiem CC"
                    result = True
                    If SendCC.Trim() <> "" Then
                        ALL_EMAILS = SendCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.CC.Add(emailaddress)
                            End If
                        Next
                    End If

                    '#End Region
                    prbBar.PerformStep()
                    prbBar.Update()

                    '#Region "Kiem BCC"
                    result = True
                    If SendBCC.Trim() <> "" Then
                        ALL_EMAILS = SendBCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.Bcc.Add(emailaddress)
                            End If
                        Next
                    End If
                    '#End Region
                    prbBar.PerformStep()
                    prbBar.Update()

                    '#Region "Kiem Attach"
                    If AttachmentPath.Trim() <> "" Then
                        'Dim attach As New Attachment(AttachmentPath)
                        'message.Attachments.Add(attach)
                        MAddAttachment(message, AttachmentPath)
                    End If
                    '#End Region
                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    client.Send(message)
                    message.Dispose()
                    prbBar.PerformStep()
                    prbBar.Update()

                    prbBar.Position = iViTri
                    Return ""
                Catch ex As Exception
                    prbBar.Position = iViTri
                    Return ex.Message
                End Try
            Else
                prbBar.Position = iViTri
                Return "Email not sent"
            End If
        Catch ex As Exception
            prbBar.Position = iViTri
            Return ex.Message
        End Try
    End Function

#Region "Goi Mail"
    Public Function MGoiMail(ByVal xlWorkBook As Excel.Workbook, ByVal sPath As String, ByVal sPathFileSend As String, ByVal sMail As String, ByVal sMailCC As String, ByVal sTieuDe As String, _
     ByVal sBody As String, ByRef sKetQuaSent As String, ByVal prbBar As DevExpress.XtraEditors.ProgressBarControl) As [Boolean]
        Try
            xlWorkBook.SaveAs(sPathFileSend, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, False, False, _
             Excel.XlSaveAsAccessMode.xlShared, False, False, Type.Missing, Type.Missing)
            Commons.Modules.ObjSystems.Xoahinh(sPath)
            Commons.Modules.ObjSystems.Xoahinh(sPath)

            prbBar.PerformStep()
            prbBar.Update()


            Dim sKetQua As String

            If sMailCC = "" Then
                sKetQua = Commons.Modules.MMail.MSendEmail(sMail, Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, sTieuDe, sBody, sPathFileSend, _
                 Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort, prbBar)
            Else
                sKetQua = Commons.Modules.MMail.MSendEmail(sMail, sMailCC, Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, sTieuDe, sBody, _
                 sPathFileSend, Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort, prbBar)
            End If


            Commons.Modules.ObjSystems.Xoahinh(sPathFileSend)
            Commons.Modules.ObjSystems.Xoahinh(sPathFileSend)

            prbBar.PerformStep()
            prbBar.Update()

            Select Case sKetQua.ToUpper()
                Case "Invalid e-mail."
                    sKetQuaSent = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPBTBanHanh", "KhongPhaiMail", Commons.Modules.TypeLanguage)
                    Return False
                Case "Email not sent"
                    sKetQuaSent = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPBTBanHanh", "KhongGoiDuoc", Commons.Modules.TypeLanguage)
                    Return False
                Case ""
                    Return True
                Case Else
                    sKetQuaSent = sKetQua
                    Return False
            End Select
        Catch
            Return False
        End Try

    End Function
#End Region

#End Region

#Region "Dua File Vao CSDL"
    Public Function CapNhapMailVaoCSDL(ByVal sFileName As String, ByVal sPath As String, ByVal sMailTo As String, ByVal sMailCC As String, ByVal sMailBCC As String, ByVal sTieuDe As String, _
     ByVal sBody As String, ByRef sKetQua As String) As Boolean
        Try
            Commons.Modules.ObjSystems.MBoMailUser(sMailTo)
            Commons.Modules.ObjSystems.MBoMailUser(sMailCC)
            Commons.Modules.ObjSystems.MBoMailUser(sMailBCC)

            If Not Commons.Modules.ObjSystems.KiemThuMucTonTai(Commons.Modules.sDDanMail) Then
                System.IO.Directory.CreateDirectory(Commons.Modules.sDDanMail)
            End If
            Commons.Modules.ObjSystems.LuuDuongDan(sPath, Commons.Modules.sDDanMail + "\" & sFileName)
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "MAddMailSent", sFileName, Commons.Modules.sDDanMail + "\" & sFileName, sMailTo, sMailCC, _
             sMailBCC, sTieuDe, sBody)
        Catch ex As Exception
            sKetQua = ex.Message
            Return False
        End Try
        Return True
    End Function

    Public Function CapNhapMailVaoCSDL(ByVal sFileName As String, ByVal sPath As String, ByVal sMailTo As String, ByVal sMailCC As String, ByVal sMailBCC As String, ByVal sTieuDe As String, _
        ByVal sBody As String, ByRef sKetQua As String, ByVal sPathLuu As String) As Boolean
        Try
            Commons.Modules.ObjSystems.MBoMailUser(sMailTo)
            Commons.Modules.ObjSystems.MBoMailUser(sMailCC)
            Commons.Modules.ObjSystems.MBoMailUser(sMailBCC)

            If Not Commons.Modules.ObjSystems.KiemThuMucTonTai(sPathLuu) Then
                System.IO.Directory.CreateDirectory(sPathLuu)
            End If
            Commons.Modules.ObjSystems.LuuDuongDan(sPath, sPathLuu + "\" & sFileName)
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "MAddMailSent", sFileName, sPathLuu + "\" & sFileName, sMailTo, sMailCC, _
             sMailBCC, sTieuDe, sBody)
        Catch ex As Exception
            sKetQua = ex.Message
            Return False
        End Try
        Return True
    End Function

#End Region


#Region "Goi Mail Khong Attachment"

    Public Function MSendEmailNotAttachment(ByVal SendTo As String, _
                                ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                                ByVal sSmtp As String, ByVal sPort As String) As String
        Try
            If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
                SendTo = "ecomaint.cmms@gmail.com"
            End If
            Commons.Modules.ObjSystems.MBoMailUser(SendTo)

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()


            Dim mMailF As String
            mMailF = ""
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If



            If result = True Then
                Try

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If


                    Dim planview As AlternateView = AlternateView.CreateAlternateViewFromString("This is my plain text content, viewable tby those clients that don't support html")
                    Dim htmlview As AlternateView = AlternateView.CreateAlternateViewFromString("<b>This is bold text and viewable by those mail clients that support html<b>")



                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject

                    '#End Region
                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    client.Send(message)
                    message.Dispose()
                    Return ""
                Catch ex As Exception
                    Return ex.Message
                End Try
            Else
                Return "Email not sent"
            End If
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function MSendEmailNotAttachment(ByVal SendTo As String, ByVal SendCC As String, _
                                ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                                ByVal sSmtp As String, ByVal sPort As String) As String
        Try
            If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
                SendTo = "ecomaint.cmms@gmail.com"
                SendCC = ""
            End If
            Commons.Modules.ObjSystems.MBoMailUser(SendTo)
            Commons.Modules.ObjSystems.MBoMailUser(SendCC)

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()

            Dim mMailF As String
            mMailF = ""
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If

            mMailF = ""
            If Not MKiemMail(SendCC, mMailF) Then
                result = False
                Return mMailF
            End If

            If result = True Then
                Try

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If



                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject


                    '#Region "Kiem CC"
                    result = True
                    If SendCC.Trim() <> "" Then
                        ALL_EMAILS = SendCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.CC.Add(emailaddress)
                            End If
                        Next
                    End If

                    '#End Region

                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    client.Send(message)
                    message.Dispose()
                    Return ""
                Catch ex As Exception
                    Return ex.Message
                End Try
            Else
                Return "Email not sent"
            End If
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function MSendEmailNotAttachment(ByVal SendTo As String, ByVal SendCC As String, ByVal SendBCC As String, _
                            ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                            ByVal sSmtp As String, ByVal sPort As String) As String
        Try
            If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
                SendTo = "ecomaint.cmms@gmail.com"
                SendCC = ""
                SendBCC = ""
            End If
            Commons.Modules.ObjSystems.MBoMailUser(SendTo)
            Commons.Modules.ObjSystems.MBoMailUser(SendCC)
            Commons.Modules.ObjSystems.MBoMailUser(SendBCC)

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()


            Dim mMailF As String
            mMailF = ""
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If

            mMailF = ""
            If Not MKiemMail(SendCC, mMailF) Then
                result = False
                Return mMailF
            End If

            If result = True Then
                Try

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If



                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.IsBodyHtml = True
                    message.Body = sBody
                    message.Subject = sSubject


                    '#Region "Kiem CC"
                    result = True
                    If SendCC.Trim() <> "" Then
                        ALL_EMAILS = SendCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.CC.Add(emailaddress)
                            End If
                        Next
                    End If

                    '#End Region

                    '#Region "Kiem BCC"
                    result = True
                    If SendBCC.Trim() <> "" Then
                        ALL_EMAILS = SendBCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.Bcc.Add(emailaddress)
                            End If
                        Next
                    End If
                    '#End Region

                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    client.Send(message)
                    message.Dispose()
                    Return ""
                Catch ex As Exception
                    Return ex.Message
                End Try
            Else
                Return "Email not sent"
            End If
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

#Region "Goi Mail"
    Public Function MGoiMailNotAttachment(ByVal sMail As String, ByVal sMailCC As String, ByVal sTieuDe As String, _
     ByVal sBody As String, ByRef sKetQuaSent As String) As [Boolean]
        Try
            Dim sKetQua As String

            If sMailCC = "" Then
                sKetQua = Commons.Modules.MMail.MSendEmailNotAttachment(sMail, Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, sTieuDe, sBody, _
                 Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort)
            Else
                sKetQua = Commons.Modules.MMail.MSendEmailNotAttachment(sMail, sMailCC, Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, sTieuDe, sBody, _
                 Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort)
            End If

            Select Case sKetQua.ToUpper()
                Case "Invalid e-mail."
                    sKetQuaSent = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPBTBanHanh", "KhongPhaiMail", Commons.Modules.TypeLanguage)
                    Return False
                Case "Email not sent"
                    sKetQuaSent = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPBTBanHanh", "KhongGoiDuoc", Commons.Modules.TypeLanguage)
                    Return False
                Case ""
                    sKetQuaSent = ""
                    Return True
                Case Else
                    sKetQuaSent = sKetQua
                    Return False
            End Select
        Catch ex As Exception
            sKetQuaSent = ex.Message
            Return False
        End Try

    End Function

#End Region


#End Region

#Region "Goi Mail Co ProgressBar Khong Attachment"

    Public Function MSendEmailNotAttachment(ByVal SendTo As String, _
                                ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                                ByVal sSmtp As String, ByVal sPort As String, _
                                ByVal prbBar As DevExpress.XtraEditors.ProgressBarControl) As String
        Dim iViTri As Integer
        iViTri = prbBar.Position + 9
        Try
            If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
                SendTo = "ecomaint.cmms@gmail.com"
            End If
            Commons.Modules.ObjSystems.MBoMailUser(SendTo)

            prbBar.PerformStep()
            prbBar.Update()

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()

            prbBar.PerformStep()
            prbBar.Update()

            Dim mMailF As String
            mMailF = ""
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If



            prbBar.PerformStep()
            prbBar.Update()
            If result = True Then
                Try
                    prbBar.PerformStep()
                    prbBar.Update()

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If



                    prbBar.PerformStep()
                    prbBar.Update()

                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject

                    prbBar.PerformStep()
                    prbBar.Update()


                    prbBar.PerformStep()
                    prbBar.Update()


                    '#End Region
                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    prbBar.PerformStep()
                    prbBar.Update()


                    client.Send(message)
                    message.Dispose()

                    prbBar.PerformStep()
                    prbBar.Update()

                    prbBar.Position = iViTri

                    Return ""
                Catch ex As Exception
                    prbBar.Position = iViTri
                    Return ex.Message
                End Try
            Else
                prbBar.Position = iViTri
                Return "Email not sent"
            End If
        Catch ex As Exception
            prbBar.Position = iViTri
            Return ex.Message
        End Try
    End Function

    Public Function MSendEmailNotAttachment(ByVal SendTo As String, ByVal SendCC As String, _
                                ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                                ByVal sSmtp As String, ByVal sPort As String, _
                                ByVal prbBar As DevExpress.XtraEditors.ProgressBarControl) As String
        Dim iViTri As Integer
        iViTri = prbBar.Position + 9
        If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
            SendTo = "ecomaint.cmms@gmail.com"
            SendCC = ""
        End If
        Commons.Modules.ObjSystems.MBoMailUser(SendTo)
        Commons.Modules.ObjSystems.MBoMailUser(SendCC)

        Try
            prbBar.PerformStep()
            prbBar.Update()

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()

            prbBar.PerformStep()
            prbBar.Update()

            Dim mMailF As String
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If

            mMailF = ""
            If Not MKiemMail(SendCC, mMailF) Then
                result = False
                Return mMailF
            End If

            prbBar.PerformStep()
            prbBar.Update()

            If result = True Then
                Try
                    prbBar.PerformStep()
                    prbBar.Update()

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If


                    prbBar.PerformStep()
                    prbBar.Update()

                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject

                    prbBar.PerformStep()
                    prbBar.Update()

                    '#Region "Kiem CC"
                    result = True
                    If SendCC.Trim() <> "" Then
                        ALL_EMAILS = SendCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.CC.Add(emailaddress)
                            End If
                        Next
                    End If

                    '#End Region
                    prbBar.PerformStep()
                    prbBar.Update()

                    prbBar.PerformStep()
                    prbBar.Update()

                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    client.Send(message)
                    message.Dispose()
                    prbBar.PerformStep()
                    prbBar.Update()

                    prbBar.Position = iViTri
                    Return ""
                Catch ex As Exception
                    prbBar.Position = iViTri
                    Return ex.Message
                End Try
            Else
                prbBar.Position = iViTri
                Return "Email not sent"
            End If
        Catch ex As Exception
            prbBar.Position = iViTri
            Return ex.Message
        End Try
    End Function

    Public Function MSendEmailNotAttachment(ByVal SendTo As String, ByVal SendCC As String, ByVal SendBCC As String, _
                            ByVal SendFrom As String, ByVal SendFromPass As String, ByVal sSubject As String, ByVal sBody As String, _
                            ByVal sSmtp As String, ByVal sPort As String, _
                            ByVal prbBar As DevExpress.XtraEditors.ProgressBarControl) As String
        Dim iViTri As Integer
        iViTri = prbBar.Position + 9
        If myHost.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then
            SendTo = "ecomaint.cmms@gmail.com"
            SendCC = ""
            SendBCC = ""
        End If
        Commons.Modules.ObjSystems.MBoMailUser(SendTo)
        Commons.Modules.ObjSystems.MBoMailUser(SendCC)
        Commons.Modules.ObjSystems.MBoMailUser(SendBCC)

        Try
            prbBar.PerformStep()
            prbBar.Update()

            Dim result As Boolean = True
            Dim ALL_EMAILS As [String]()

            prbBar.PerformStep()
            prbBar.Update()

            Dim mMailF As String
            mMailF = ""
            If Not MKiemMail(SendTo, mMailF) Then
                result = False
                Return mMailF
            End If

            mMailF = ""
            If Not MKiemMail(SendCC, mMailF) Then
                result = False
                Return mMailF
            End If

            prbBar.PerformStep()
            prbBar.Update()

            If result = True Then
                Try
                    prbBar.PerformStep()
                    prbBar.Update()

                    Dim client As New SmtpClient(sSmtp, Integer.Parse(sPort))
                    If Commons.Modules.bSSL = True Then
                        client.EnableSsl = True
                    Else
                        If sSmtp = "smtp.gmail.com" Then
                            client.EnableSsl = True
                        End If
                    End If
                    Dim message As New MailMessage()
                    message.From = New MailAddress(SendFrom, "CMMS")
                    result = True
                    If SendTo.Trim() <> "" Then
                        ALL_EMAILS = SendTo.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.To.Add(emailaddress)
                            End If
                        Next
                    End If


                    prbBar.PerformStep()
                    prbBar.Update()

                    message.SubjectEncoding = Encoding.UTF8
                    message.BodyEncoding = Encoding.UTF8
                    message.IsBodyHtml = True
                    message.Priority = MailPriority.High
                    message.Body = sBody
                    message.Subject = sSubject
                    prbBar.PerformStep()
                    prbBar.Update()


                    '#Region "Kiem CC"
                    result = True
                    If SendCC.Trim() <> "" Then
                        ALL_EMAILS = SendCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.CC.Add(emailaddress)
                            End If
                        Next
                    End If

                    '#End Region
                    prbBar.PerformStep()
                    prbBar.Update()

                    '#Region "Kiem BCC"
                    result = True
                    If SendBCC.Trim() <> "" Then
                        ALL_EMAILS = SendBCC.Split(";"c)
                        For Each emailaddress As String In ALL_EMAILS
                            result = Commons.Modules.ObjSystems.MCheckEmail(emailaddress)
                            If result Then
                                message.Bcc.Add(emailaddress)
                            End If
                        Next
                    End If
                    '#End Region
                    prbBar.PerformStep()
                    prbBar.Update()

                    Dim myCreds As New NetworkCredential(SendFrom, SendFromPass, "")
                    client.Credentials = myCreds
                    'client.SendAsync(message,string.Empty);
                    client.Send(message)
                    message.Dispose()
                    prbBar.PerformStep()
                    prbBar.Update()

                    prbBar.Position = iViTri
                    Return ""
                Catch ex As Exception
                    prbBar.Position = iViTri
                    Return ex.Message
                End Try
            Else
                prbBar.Position = iViTri
                Return "Email not sent"
            End If
        Catch ex As Exception
            prbBar.Position = iViTri
            Return ex.Message
        End Try
    End Function

#Region "Goi Mail"
    Public Function MGoiMailNotAttachment(ByVal sMail As String, ByVal sMailCC As String, ByVal sTieuDe As String, _
     ByVal sBody As String, ByRef sKetQuaSent As String, ByVal prbBar As DevExpress.XtraEditors.ProgressBarControl) As [Boolean]
        Try
            prbBar.PerformStep()
            prbBar.Update()


            Dim sKetQua As String

            If sMailCC = "" Then
                sKetQua = Commons.Modules.MMail.MSendEmailNotAttachment(sMail, Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, sTieuDe, sBody, _
                Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort, prbBar)
            Else
                sKetQua = Commons.Modules.MMail.MSendEmailNotAttachment(sMail, sMailCC, Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, sTieuDe, sBody, _
                 Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort, prbBar)
            End If

            prbBar.PerformStep()
            prbBar.Update()

            Select Case sKetQua.ToUpper()
                Case "Invalid e-mail."
                    sKetQuaSent = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPBTBanHanh", "KhongPhaiMail", Commons.Modules.TypeLanguage)
                    Return False
                Case "Email not sent"
                    sKetQuaSent = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPBTBanHanh", "KhongGoiDuoc", Commons.Modules.TypeLanguage)
                    Return False
                Case ""
                    Return True
                Case Else
                    sKetQuaSent = sKetQua
                    Return False
            End Select
        Catch
            Return False
        End Try

    End Function
#End Region

#End Region

    Private Sub MAddAttachment(ByVal Message As MailMessage, ByVal sALLAttPaths As String)
        Dim AllAttPath As [String]() = sALLAttPaths.Split(";"c)
        Dim result As Boolean
        Try
            For Each strAttPath As String In AllAttPath
                result = System.IO.File.Exists(strAttPath)
                If result Then
                    Message.Attachments.Add(New Net.Mail.Attachment(strAttPath))
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Function MKiemMail(ByVal MailKiem As String, ByRef sLoi As String) As Boolean
        If MailKiem.Trim = "" Then Return True
        Dim mMailF As String
        mMailF = ""
        If Commons.Modules.ObjSystems.MCheckEmail(MailKiem, mMailF) = False Then
            sLoi = "Invalid e-mail. - " + mMailF
            Return False
        End If
        sLoi = ""
        Return True
    End Function
End Class

