Imports System.Management
Public Class HardKey
    Public Function GetHDSerial() As String
        Dim disk As New ManagementObject("Win32_LogicalDisk.DeviceID=""C:""")
        Dim diskPropertyA As PropertyData = disk.Properties("VolumeSerialNumber")
        Return diskPropertyA.Value.ToString()
    End Function
    Public Function GetCPUId() As String
        Dim cpuInfo As String = String.Empty
        Dim temp As String = String.Empty
        Dim mc As ManagementClass = New ManagementClass("Win32_Processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        For Each mo As ManagementObject In moc
            If cpuInfo = String.Empty Then
                cpuInfo = mo.Properties("ProcessorId").Value.ToString()
            End If
        Next
        Return cpuInfo
    End Function
    Public Function Tocodings(ByVal vCode As String) As String
        Dim vTocode As String = String.Empty
        For i As Integer = 0 To vCode.Length - 1
            Dim vChar As Integer = Microsoft.VisualBasic.AscW(vCode(i))
            vChar = vChar + (512 + i)
            vTocode = vTocode.Insert(0, Microsoft.VisualBasic.ChrW(vChar).ToString())
        Next
        Return vTocode
    End Function
    Public Function Decodings(ByVal vCode As String) As String
        Dim vDecode As String = String.Empty
        For i As Integer = 0 To vCode.Length - 1
            Dim vChar As Integer = Microsoft.VisualBasic.AscW(vCode(i))
            vChar = vChar - (512 + (vCode.Length - i - 1))
            vDecode = vDecode.Insert(0, Microsoft.VisualBasic.ChrW(vChar).ToString())
        Next
        Return vDecode
    End Function
    Public Function KeyCodings(ByVal _SerialKey As String) As String
        Dim vTocode As String = String.Empty
        '_SerialKey = _SerialKey.Replace("-", "")
        '_SerialKey = _SerialKey.Remove(_SerialKey.Length - 2, 2)
        For i As Integer = _SerialKey.Length - 1 To 0 Step -1
            Dim vChar As Integer = Microsoft.VisualBasic.AscW(_SerialKey(i))
            vChar = vChar + (7 - i)
            If ((vChar >= 48 And vChar <= 57) Or (vChar >= 65 And vChar <= 91)) Then
                vTocode = vTocode.Insert(0, Microsoft.VisualBasic.ChrW(vChar).ToString())
            Else
                If (i Mod 2 = 0) Then
                    vTocode = vTocode.Insert(0, "K")
                Else
                    If (i Mod 3 = 0) Then
                        vTocode = vTocode.Insert(0, "F")
                    Else
                        vTocode = vTocode.Insert(0, "Z")
                    End If

                End If
            End If
        Next
        Return vTocode
    End Function
End Class
