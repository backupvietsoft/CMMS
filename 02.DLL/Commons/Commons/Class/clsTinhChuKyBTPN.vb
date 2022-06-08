Namespace VS.Classes.Admin
    Public Class clsTinhChuKyBTPN
        Public Function TinhChuKy(ByVal NgayTinh As Date, ByVal BuocNhay As Double, ByVal DVTG As Byte) As Date
            '            Dim NGAY, THANG, nam As Integer
            '            Dim Phanle, TAM

            '            NGAY = Left(NgayTinh, 2)
            '            THANG = Mid(NgayTinh, 4, 2)
            '            nam = Right(NgayTinh, 4)

            '            Select Case DVTG
            '                Case 1 ' ch—n ngøy'
            '                    TinhChuKy = DateAdd(DateInterval.Day, CInt(BuocNhay), DateValue(NgayTinh))
            '                    Exit Function
            '                Case 2 ' tinh theo tuan'

            '                    TinhChuKy = DateAdd(DateInterval.Day, CInt(BuocNhay * 7), DateValue(NgayTinh))
            '                    Exit Function
            '                Case 3 'tinh theo thang

            '                    If THANG = 12 Then
            '                        THANG = 1
            '                        nam = nam + 1
            '                    Else
            '                        THANG = THANG + BuocNhay
            '                    End If
            'TinhThang:

            '                    If LayPhanNguyen(THANG) > 12 Then ' tinh thang tron
            '                        nam = nam + (THANG \ 12)
            '                        THANG = THANG - (THANG \ 12) * 12
            '                    End If
            '                    '* * * * * *
            '                    If THANG < 0 Then
            '                        nam = nam - 1
            '                        THANG = THANG + 12
            '                    End If
            '                    Phanle = LayPhanLe(THANG)

            '                    If (THANG < 1) And (BuocNhay < 0) Then
            '                        THANG = 12
            '                        nam = nam - 1
            '                    Else
            '                        If THANG < 1 Then THANG = 1
            '                    End If

            '                    If Phanle <> 0 Then ' tinh thang le

            '                        NGAY = NGAY + LayPhanNguyen(Phanle * 30)
            '                        If NGAY > TinhSoNgayThang(LayPhanNguyen(THANG), LayPhanNguyen(nam)) Then
            '                            TAM = TinhSoNgayThang(LayPhanNguyen(THANG), LayPhanNguyen(nam))
            '                            If THANG = 12 Then
            '                                THANG = 1
            '                            Else
            '                                THANG = THANG + 1
            '                            End If
            '                            NGAY = NGAY - TAM
            '                        End If
            '                    Else
            '                        If NGAY > TinhSoNgayThang(LayPhanNguyen(THANG), LayPhanNguyen(nam - 0.5)) Then
            '                            TAM = TinhSoNgayThang(LayPhanNguyen(THANG), LayPhanNguyen(nam))
            '                            If THANG = 12 Then
            '                                THANG = 1
            '                            Else
            '                                THANG = THANG + 1
            '                            End If
            '                            NGAY = NGAY - TAM
            '                        End If
            '                    End If ' het tinh phan le

            '                Case 4 ' theo nam
            '                    nam = nam + BuocNhay
            'TinhNam:
            '                    Phanle = LayPhanLe(nam)
            '                    If Phanle <> 0 Then
            '                        THANG = THANG + Phanle * 12
            '                        GoTo TinhThang
            '                    End If 'het tinh theo nam
            '                Case Else
            '                    MsgBox("LÌi khi t»nh chu k¸ b¿o tr…!")
            '            End Select
            '            TAM = NGAY & "/" & LayPhanNguyen(THANG) & "/" & LayPhanNguyen(nam)
            '            TinhChuKy = DateValue(TAM)
            If DVTG = 1 Then
                Return DateAdd(DateInterval.Day, BuocNhay, Date.Parse(NgayTinh))
            Else
                If DVTG = 2 Then
                    Return DateAdd(DateInterval.Day, BuocNhay * 7, Date.Parse(NgayTinh))
                Else
                    If DVTG = 3 Then
                        Return DateAdd(DateInterval.Month, BuocNhay, Date.Parse(NgayTinh))
                    Else
                        Return DateAdd(DateInterval.Year, BuocNhay, Date.Parse(NgayTinh))
                    End If
                End If
            End If
        End Function

        Public Function LayPhanLe(ByVal So) As Double
            Dim TAM
            TAM = InStr(1, So, ".")
            If TAM <> 0 Then
                TAM = Mid(So, TAM, Len(So))
                TAM = "0" & TAM
            Else
                TAM = 0
            End If
            LayPhanLe = Val(TAM)
        End Function

        Public Function LayPhanNguyen(ByVal So) As Double
            Dim TAM
            TAM = InStr(1, So, ".")
            If TAM = 0 Then
                TAM = So
            Else
                TAM = Left(So, TAM)
            End If
            LayPhanNguyen = Val(TAM)

        End Function
        Public Function TinhSoNgayThang(ByVal THANG, ByVal nam) As Integer
            Select Case THANG
                Case 1, 3, 5, 7, 8, 10, 12
                    TinhSoNgayThang = 31
                Case 4, 6, 9, 11
                    TinhSoNgayThang = 30
                Case 2
                    If (nam Mod 4) = 0 Then
                        TinhSoNgayThang = 29
                    Else
                        TinhSoNgayThang = 28
                    End If
            End Select
        End Function
    End Class
End Namespace

