﻿Public Class MConvertFont
    Public Shared Function MVni2Uni(ByVal mVnistr As String) As String
        MVni2Uni = ""
        Dim c As String, i As Integer
        Dim db As Boolean
        For i = 1 To Len(mVnistr)
            db = False
            If i < Len(mVnistr) Then
                c = Mid(mVnistr, i + 1, 1)
                If c = "ù" Or c = "ø" Or c = "û" Or c = "õ" Or c = "ï" Or _
                c = "ê" Or c = "é" Or c = "è" Or c = "ú" Or c = "ü" Or c = "ë" Or _
                c = "â" Or c = "á" Or c = "à" Or c = "å" Or c = "ã" Or c = "ä" Or _
                c = "Ù" Or c = "Ø" Or c = "Û" Or c = "Õ" Or c = "Ï" Or _
                c = "Ê" Or c = "É" Or c = "È" Or c = "Ú" Or c = "Ü" Or c = "Ë" Or _
                c = "Â" Or c = "Á" Or c = "À" Or c = "Å" Or c = "Ã" Or c = "Ä" Then db = True
            End If
            If db Then
                c = Mid(mVnistr, i, 2)
                Select Case c
                    Case "aù" : c = ChrW(225)
                    Case "aø" : c = ChrW(224)
                    Case "aû" : c = ChrW(7843)
                    Case "aõ" : c = ChrW(227)
                    Case "aï" : c = ChrW(7841)
                    Case "aê" : c = ChrW(259)
                    Case "aé" : c = ChrW(7855)
                    Case "aè" : c = ChrW(7857)
                    Case "aú" : c = ChrW(7859)
                    Case "aü" : c = ChrW(7861)
                    Case "aë" : c = ChrW(7863)
                    Case "aâ" : c = ChrW(226)
                    Case "aá" : c = ChrW(7845)
                    Case "aà" : c = ChrW(7847)
                    Case "aå" : c = ChrW(7849)
                    Case "aã" : c = ChrW(7851)
                    Case "aä" : c = ChrW(7853)
                    Case "eù" : c = ChrW(233)
                    Case "eø" : c = ChrW(232)
                    Case "eû" : c = ChrW(7867)
                    Case "eõ" : c = ChrW(7869)
                    Case "eï" : c = ChrW(7865)
                    Case "eâ" : c = ChrW(234)
                    Case "eá" : c = ChrW(7871)
                    Case "eà" : c = ChrW(7873)
                    Case "eå" : c = ChrW(7875)
                    Case "eã" : c = ChrW(7877)
                    Case "eä" : c = ChrW(7879)
                    Case "où" : c = ChrW(243)
                    Case "oø" : c = ChrW(242)
                    Case "oû" : c = ChrW(7887)
                    Case "oõ" : c = ChrW(245)
                    Case "oï" : c = ChrW(7885)
                    Case "oâ" : c = ChrW(244)
                    Case "oá" : c = ChrW(7889)
                    Case "oà" : c = ChrW(7891)
                    Case "oå" : c = ChrW(7893)
                    Case "oã" : c = ChrW(7895)
                    Case "oä" : c = ChrW(7897)
                    Case "ôù" : c = ChrW(7899)
                    Case "ôø" : c = ChrW(7901)
                    Case "ôû" : c = ChrW(7903)
                    Case "ôõ" : c = ChrW(7905)
                    Case "ôï" : c = ChrW(7907)
                    Case "uù" : c = ChrW(250)
                    Case "uø" : c = ChrW(249)
                    Case "uû" : c = ChrW(7911)
                    Case "uõ" : c = ChrW(361)
                    Case "uï" : c = ChrW(7909)
                    Case "öù" : c = ChrW(7913)
                    Case "öø" : c = ChrW(7915)
                    Case "öû" : c = ChrW(7917)
                    Case "öõ" : c = ChrW(7919)
                    Case "öï" : c = ChrW(7921)
                    Case "yù" : c = ChrW(253)
                    Case "yø" : c = ChrW(7923)
                    Case "yû" : c = ChrW(7927)
                    Case "yõ" : c = ChrW(7929)
                    Case "AÙ" : c = ChrW(193)
                    Case "AØ" : c = ChrW(192)
                    Case "AÛ" : c = ChrW(7842)
                    Case "AÕ" : c = ChrW(195)
                    Case "AÏ" : c = ChrW(7840)
                    Case "AÊ" : c = ChrW(258)
                    Case "AÉ" : c = ChrW(7854)
                    Case "AÈ" : c = ChrW(7856)
                    Case "AÚ" : c = ChrW(7858)
                    Case "AÜ" : c = ChrW(7860)
                    Case "AË" : c = ChrW(7862)
                    Case "AÂ" : c = ChrW(194)
                    Case "AÁ" : c = ChrW(7844)
                    Case "AÀ" : c = ChrW(7846)
                    Case "AÅ" : c = ChrW(7848)
                    Case "AÃ" : c = ChrW(7850)
                    Case "AÄ" : c = ChrW(7852)
                    Case "EÙ" : c = ChrW(201)
                    Case "EØ" : c = ChrW(200)
                    Case "EÛ" : c = ChrW(7866)
                    Case "EÕ" : c = ChrW(7868)
                    Case "EÏ" : c = ChrW(7864)
                    Case "EÂ" : c = ChrW(202)
                    Case "EÁ" : c = ChrW(7870)
                    Case "EÀ" : c = ChrW(7872)
                    Case "EÅ" : c = ChrW(7874)
                    Case "EÃ" : c = ChrW(7876)
                    Case "EÄ" : c = ChrW(7878)
                    Case "OÙ" : c = ChrW(211)
                    Case "OØ" : c = ChrW(210)
                    Case "OÛ" : c = ChrW(7886)
                    Case "OÕ" : c = ChrW(213)
                    Case "OÏ" : c = ChrW(7884)
                    Case "OÂ" : c = ChrW(212)
                    Case "OÁ" : c = ChrW(7888)
                    Case "OÀ" : c = ChrW(7890)
                    Case "OÅ" : c = ChrW(7892)
                    Case "OÃ" : c = ChrW(7894)
                    Case "OÄ" : c = ChrW(7896)
                    Case "ÔÙ" : c = ChrW(7898)
                    Case "ÔØ" : c = ChrW(7900)
                    Case "ÔÛ" : c = ChrW(7902)
                    Case "ÔÕ" : c = ChrW(7904)
                    Case "ÔÏ" : c = ChrW(7906)
                    Case "UÙ" : c = ChrW(218)
                    Case "UØ" : c = ChrW(217)
                    Case "UÛ" : c = ChrW(7910)
                    Case "UÕ" : c = ChrW(360)
                    Case "UÏ" : c = ChrW(7908)
                    Case "ÖÙ" : c = ChrW(7912)
                    Case "ÖØ" : c = ChrW(7914)
                    Case "ÖÛ" : c = ChrW(7916)
                    Case "ÖÕ" : c = ChrW(7918)
                    Case "ÖÏ" : c = ChrW(7920)
                    Case "YÙ" : c = ChrW(221)
                    Case "YØ" : c = ChrW(7922)
                    Case "YÛ" : c = ChrW(7926)
                    Case "YÕ" : c = ChrW(7928)
                End Select
            Else
                c = Mid(mVnistr, i, 1)
                Select Case c
                    Case "ô" : c = ChrW(417)
                    Case "í" : c = ChrW(237)
                    Case "ì" : c = ChrW(236)
                    Case "æ" : c = ChrW(7881)
                    Case "ó" : c = ChrW(297)
                    Case "ò" : c = ChrW(7883)
                    Case "ö" : c = ChrW(432)
                    Case "î" : c = ChrW(7925)
                    Case "ñ" : c = ChrW(273)
                    Case "Ô" : c = ChrW(416)
                    Case "Í" : c = ChrW(205)
                    Case "Ì" : c = ChrW(204)
                    Case "Æ" : c = ChrW(7880)
                    Case "Ó" : c = ChrW(296)
                    Case "Ò" : c = ChrW(7882)
                    Case "Ö" : c = ChrW(431)
                    Case "Î" : c = ChrW(7924)
                    Case "Ñ" : c = ChrW(272)
                End Select
            End If
            MVni2Uni = MVni2Uni + c
            If db Then i = i + 1
        Next i
    End Function
End Class
