Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Namespace VS.UserControls

    ' <summary>
    ' Created by Nghiem Quan, Lieu email nghiemquan_lieu@yahoo.com
    ' Create date: 21/06/06
    ' Description:	QLGrid Control
    ' </summary>
    ' <remarks></remarks>

    Public Class QLGrid
        Inherits DataGridView

        Public Sub New()
        End Sub

        Protected Overloads Overrides Sub OnRowPostPaint(ByVal e As DataGridViewRowPostPaintEventArgs)
            Dim strRowNumber As String = (e.RowIndex + 1).ToString
            While strRowNumber.Length < Me.RowCount.ToString.Length
                strRowNumber = "0" + strRowNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
            If Me.RowHeadersWidth < CType((size.Width + 20), Integer) Then
                Me.RowHeadersWidth = CType((size.Width + 20), Integer)
            End If
            Dim b As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
            MyBase.OnRowPostPaint(e)
        End Sub
    End Class
End Namespace
