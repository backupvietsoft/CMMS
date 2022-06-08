
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Public Class MaskedTextBoxNew
    Inherits MaskedTextBox
    Const WM_NCPAINT As Integer = &H85
    Const RDW_INVALIDATE As UInteger = &H1
    Const RDW_IUPDATENOW As UInteger = &H100
    Const RDW_FRAME As UInteger = &H400
    <DllImport("user32.dll")>
    Private Shared Function GetWindowDC(hWnd As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Shared Function ReleaseDC(hWnd As IntPtr, hDC As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function RedrawWindow(hWnd As IntPtr, lprc As IntPtr, hrgn As IntPtr, flags As UInteger) As Boolean
    End Function
    Private m_borderColor As Color = ColorTranslator.FromHtml("#ABC1DE")
    Public Property BorderColor() As Color
        Get
            Return m_borderColor
        End Get
        Set
            m_borderColor = Value
            RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, RDW_FRAME Or RDW_IUPDATENOW Or RDW_INVALIDATE)
        End Set
    End Property
    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)
        If m.Msg = WM_NCPAINT AndAlso BorderColor <> Color.Transparent AndAlso BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D Then
            Dim hdc = GetWindowDC(Me.Handle)
            Using g = Graphics.FromHdcInternal(hdc)
                Using p = New Pen(BorderColor)
                    g.DrawRectangle(p, New Rectangle(0, 0, Width - 1, Height - 1))
                End Using
            End Using
            ReleaseDC(Me.Handle, hdc)
        End If
    End Sub
End Class
