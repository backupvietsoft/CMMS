Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices

Public Class clsGetHDDSerial
    ' begin cSerial.vb, HD Serial Number class
    <StructLayout(LayoutKind.Sequential, Size:=8)> Public Class IDEREGS
        Public bFeaturesReg As Byte
        Public bSectorCountReg As Byte
        Public bSectorNumberReg As Byte
        Public bCylLowReg As Byte
        Public bCylHighReg As Byte
        Public bDriveHeadReg As Byte
        Public bCommandReg As Byte
        Public bReserved As Byte
    End Class

    <StructLayout(LayoutKind.Sequential, Size:=32)> Public Class SENDCMDINPARAMS
        Public cBufferSize As Integer
        Public irDriveRegs As IDEREGS
        Public bDriveNumber As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> Public bReserved() As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Public dwReserved() As Integer
        Public Sub New()
            irDriveRegs = New IDEREGS
            bReserved = New Byte(2) {}
            dwReserved = New Integer(3) {}
        End Sub
    End Class

    <StructLayout(LayoutKind.Sequential, Size:=12)> Public Class DRIVERSTATUS
        Public bDriveError As Byte
        Public bIDEStatus As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Public bReserved() As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Public dwReserved() As Integer
        Public Sub New()
            bReserved = New Byte(1) {}
            dwReserved = New Integer(1) {}
        End Sub
    End Class

    <StructLayout(LayoutKind.Sequential)> Public Class IDSECTOR
        Public wGenConfig As Short
        Public wNumCyls As Short
        Public wReserved As Short
        Public wNumHeads As Short
        Public wBytesPerTrack As Short
        Public wBytesPerSector As Short
        Public wSectorsPerTrack As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> Public wVendorUnique() As Short
        '<MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public sSerialNumber As String
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=20)> Public sSerialNumber() As Char
        Public wBufferclass As Short
        Public wBufferSize As Short
        Public wECCSize As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public sFirmwareRev() As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=40)> Public sModelNumber() As Char
        '<MarshalAs(UnmanagedType.ByValTStr, SizeConst:=8)> Public sFirmwareRev As String
        '<MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public sModelNumber As String
        Public wMoreVendorUnique As Short
        Public wDoubleWordIO As Short
        Public wCapabilities As Short
        Public wReserved1 As Short
        Public wPIOTiming As Short
        Public wDMATiming As Short
        Public wBS As Short
        Public wNumCurrentCyls As Short
        Public wNumCurrentHeads As Short
        Public wNumCurrentSectorsPerTrack As Short
        Public ulCurrentSectorCapacity As Integer
        Public wMultSectorCapacity As Short
        Public wMultSectorStuff As Short
        Public ulTotalAddressableSectors As Integer
        Public wSingleWordDMA As Short
        Public wMultiWordDMA As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=382)> Public bReserved() As Byte ' padding
        Public Sub New()
            wVendorUnique = New Short(2) {}
            bReserved = New Byte(381) {}
            sFirmwareRev = New Char(7) {}
            sSerialNumber = New Char(19) {}
            sModelNumber = New Char(39) {}
        End Sub
    End Class

    <StructLayout(LayoutKind.Sequential)> Public Class SENDCMDOUTPARAMS
        Public cBufferSize As Integer
        Public DStatus As DRIVERSTATUS
        Public ids As IDSECTOR
        Public Sub New()
            DStatus = New DRIVERSTATUS
            ids = New IDSECTOR
        End Sub
    End Class

    Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Integer
    Private Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, _
    ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As Integer, _
    ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As Integer

    Private Declare Function DeviceIoControl Lib "kernel32" (ByVal hDevice As Integer, _
    ByVal dwIoControlCode As Integer, <[In](), Out()> ByVal lpInBuffer As SENDCMDINPARAMS, _
    ByVal nInBufferSize As Integer, <[In](), Out()> ByVal lpOutBuffer As SENDCMDOUTPARAMS, _
    ByVal nOutBufferSize As Integer, ByRef lpBytesReturned As Integer, ByVal lpOverlapped As Integer) As Integer

    Private Const VER_PLATFORM_WIN32_NT As Integer = 2
    Private Const FILE_SHARE_READ As Integer = &H1
    Private Const FILE_SHARE_WRITE As Integer = &H2
    Private Const GENERIC_READ As Integer = &H80000000
    Private Const GENERIC_WRITE As Integer = &H40000000
    Private Const CREATE_NEW As Integer = 1
    Private Const OPEN_EXISTING As Integer = 3
    Private Const DFP_RECEIVE_DRIVE_DATA As Integer = &H7C088
    Private Const INVALID_HANDLE_VALUE As Integer = -1

    Private Function SwapChars(ByVal sChars() As Char) As String
        Dim i As Integer

        For i = 0 To sChars.Length - 2 Step 2
            Array.Reverse(sChars, i, 2)
            'sChars.Reverse(sChars, i, 2)
        Next i

        SwapChars = New String(sChars).Trim
    End Function

    Public Function GetHDData(ByVal lDriveNumber As Integer, ByRef sSerial As String, ByRef sModel As String, ByRef sFirmware As String) As Boolean
        Dim hFile As Integer
        Dim lReturnSize As Integer
        Dim sci As New SENDCMDINPARAMS
        Dim sco As New SENDCMDOUTPARAMS

        If Environment.OSVersion.Platform = PlatformID.Win32NT Then
            hFile = CreateFile("\\.\PhysicalDrive" & CStr(lDriveNumber), GENERIC_READ Or GENERIC_WRITE, FILE_SHARE_READ Or FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0)
        Else ' 9X
            hFile = CreateFile("\\.\Smartvsd", 0, 0, 0, CREATE_NEW, 0, 0)
        End If

        If hFile <> INVALID_HANDLE_VALUE Then
            sci.bDriveNumber = CType(lDriveNumber, Byte)
            sci.cBufferSize = Marshal.SizeOf(sco)
            sci.irDriveRegs.bDriveHeadReg = CType(&HA0 Or (lDriveNumber << 4), Byte)
            sci.irDriveRegs.bCommandReg = &HEC
            sci.irDriveRegs.bSectorCountReg = 1
            sci.irDriveRegs.bSectorNumberReg = 1

            If DeviceIoControl(hFile, DFP_RECEIVE_DRIVE_DATA, sci, Marshal.SizeOf(sci), sco, Marshal.SizeOf(sco), lReturnSize, 0) <> 0 Then
                sSerial = SwapChars(sco.ids.sSerialNumber)
                sModel = SwapChars(sco.ids.sModelNumber)
                sFirmware = SwapChars(sco.ids.sFirmwareRev)
                GetHDData = True
            End If

            CloseHandle(hFile)
        End If
    End Function
End Class