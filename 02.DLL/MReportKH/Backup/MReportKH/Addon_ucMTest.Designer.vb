<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Addon_ucMTest
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboNhomMay = New System.Windows.Forms.ComboBox
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnExcel = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhomMay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnReport, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExcel, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(417, 67)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNhomMay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNhomMay, 4)
        Me.cboNhomMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhomMay.FormattingEnabled = True
        Me.cboNhomMay.Location = New System.Drawing.Point(123, 3)
        Me.cboNhomMay.Name = "cboNhomMay"
        Me.cboNhomMay.Size = New System.Drawing.Size(291, 21)
        Me.cboNhomMay.TabIndex = 1
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(340, 35)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(74, 29)
        Me.btnThoat.TabIndex = 2
        Me.btnThoat.Text = "btnThoat"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnReport.Location = New System.Drawing.Point(260, 35)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(74, 29)
        Me.btnReport.TabIndex = 3
        Me.btnReport.Text = "btnReport"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExcel.Location = New System.Drawing.Point(180, 35)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(74, 29)
        Me.btnExcel.TabIndex = 3
        Me.btnExcel.Text = "btnExcel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Addon_ucMTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Addon_ucMTest"
        Me.Size = New System.Drawing.Size(417, 67)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboNhomMay As System.Windows.Forms.ComboBox
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button

End Class
