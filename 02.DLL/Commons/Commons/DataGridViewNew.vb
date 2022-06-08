Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Public Class DataGridViewNew
    Inherits DataGridView
    Const WM_NCPAINT As Integer = &H85
    Const RDW_INVALIDATE As UInteger = &H1
    Const RDW_IUPDATENOW As UInteger = &H100
    Const RDW_FRAME As UInteger = &H400

    <DllImport("User32.dll", EntryPoint:="GetDCEx")>
    Friend Shared Function GetDCEx(hWnd As IntPtr, hRgn As IntPtr, flags As Integer) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function RedrawWindow(hWnd As IntPtr, lprc As IntPtr, hrgn As IntPtr, flags As UInteger) As Boolean
    End Function

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer
    Private m_borderColor As Color = ColorTranslator.FromHtml("#E3EFFF")
    Private m_gridCellColorWithoutHeader As Color = ColorTranslator.FromHtml("#D2E1F2")

    Public Property BorderColor() As Color
        Get
            Return m_borderColor
        End Get
        Set
            m_borderColor = Value
            RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, RDW_FRAME Or RDW_IUPDATENOW Or RDW_INVALIDATE)
        End Set
    End Property
    Public Property GridCellColorWithoutHeader() As Color
        Get
            Return m_gridCellColorWithoutHeader
        End Get
        Set
            m_gridCellColorWithoutHeader = Value
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Try
            MyBase.OnPaint(e)
            Dim hWnd As IntPtr = Me.Handle
            Dim hRgn As IntPtr = IntPtr.Zero
            Dim hdc As IntPtr = GetDCEx(hWnd, hRgn, 1027)

            Using grfx As Graphics = Graphics.FromHdc(hdc)
                Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height)
                Dim pen As New Pen(BorderColor, 1)
                grfx.DrawRectangle(pen, rect)
            End Using

        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub OnScroll(e As ScrollEventArgs)
        Try
            MyBase.OnScroll(e)
            Me.Invalidate()
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub OnCellPainting(e As DataGridViewCellPaintingEventArgs)
        Try
            MyBase.OnCellPainting(e)
            If HitTest(e.CellBounds.X, e.CellBounds.Y).Type <> DataGridViewHitTestType.ColumnHeader And HitTest(e.CellBounds.X, e.CellBounds.Y).Type <> DataGridViewHitTestType.RowHeader And HitTest(e.CellBounds.X, e.CellBounds.Y).Type <> DataGridViewHitTestType.TopLeftHeader Then
                Using backGroundPen = New Pen(GridCellColorWithoutHeader, 1) 'ColorTranslator.FromHtml("#D2E1F2")
                    Dim topLeftPoint = New Point(e.CellBounds.Left, e.CellBounds.Top)
                    Dim topRightPoint = New Point(e.CellBounds.Right - 1, e.CellBounds.Top)
                    Dim bottomRightPoint = New Point(e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    Dim bottomleftPoint = New Point(e.CellBounds.Left, e.CellBounds.Bottom - 1)
                    e.Paint(e.ClipBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.Border)
                    e.Graphics.DrawLine(backGroundPen, bottomRightPoint, bottomleftPoint)
                    e.Graphics.DrawLine(backGroundPen, bottomRightPoint, topRightPoint)
                    e.Handled = True
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        Try
            MyBase.OnLostFocus(e)
            ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(223, Byte), Integer))
            DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(223, Byte), Integer))
            RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(223, Byte), Integer))
            RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(254, Byte), Integer))
            RowHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(166, Byte), Integer))

        Catch ex As Exception
        End Try
    End Sub
    Protected Overrides Sub OnGotFocus(e As EventArgs)
        Try
            MyBase.OnGotFocus(e)
            ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
            DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
            RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
            RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(254, Byte), Integer))
            RowHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(166, Byte), Integer))
        Catch ex As Exception
        End Try
    End Sub


    <System.Diagnostics.DebuggerStepThrough()>
    Public Sub New()
        Try
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()

            Me.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

            Me.Size = New System.Drawing.Size(474, 388)

            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.BackgroundColor = System.Drawing.Color.White
            Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
            Me.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(254, Byte), Integer))
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.59!)
            DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(166, Byte), Integer))
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.ColumnHeadersHeight = 22
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(166, Byte), Integer))

            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DefaultCellStyle = DataGridViewCellStyle2
            Me.EnableHeadersVisualStyles = False
            Me.GridColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
            Me.Location = New System.Drawing.Point(2, 2)

            Me.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(254, Byte), Integer))
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(166, Byte), Integer))
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(166, Byte), Integer))
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.RowHeadersDefaultCellStyle = DataGridViewCellStyle3

            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
            DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            Me.RowsDefaultCellStyle = DataGridViewCellStyle4
            Me.RowHeadersWidth = 20
            Me.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            Me.TabIndex = 0
            MultiSelect = False


            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        Catch ex As Exception
        End Try
    End Sub
End Class
