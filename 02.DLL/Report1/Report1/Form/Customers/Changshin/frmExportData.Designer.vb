<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportData
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.labTitle = New System.Windows.Forms.Label
        Me.grbPhieuNhap = New System.Windows.Forms.GroupBox
        Me.grvPhieuNhap = New System.Windows.Forms.DataGridView
        Me.grbMayNhap = New System.Windows.Forms.GroupBox
        Me.grvMayNhap = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtTuNgay = New System.Windows.Forms.DateTimePicker
        Me.dtDenNgay = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnExport = New DevExpress.XtraEditors.SimpleButton
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grbPhieuNhap.SuspendLayout()
        CType(Me.grvPhieuNhap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbMayNhap.SuspendLayout()
        CType(Me.grvMayNhap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.labTitle, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grbPhieuNhap, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grbMayNhap, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtTuNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtDenNgay, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(688, 528)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'labTitle
        '
        Me.labTitle.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.labTitle, 6)
        Me.labTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labTitle.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.labTitle.Location = New System.Drawing.Point(3, 0)
        Me.labTitle.Name = "labTitle"
        Me.labTitle.Size = New System.Drawing.Size(682, 35)
        Me.labTitle.TabIndex = 0
        Me.labTitle.Text = "EXPORT DATA TO ORACLE"
        Me.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grbPhieuNhap
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grbPhieuNhap, 6)
        Me.grbPhieuNhap.Controls.Add(Me.grvPhieuNhap)
        Me.grbPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbPhieuNhap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbPhieuNhap.Location = New System.Drawing.Point(3, 65)
        Me.grbPhieuNhap.Name = "grbPhieuNhap"
        Me.grbPhieuNhap.Size = New System.Drawing.Size(682, 209)
        Me.grbPhieuNhap.TabIndex = 1
        Me.grbPhieuNhap.TabStop = False
        Me.grbPhieuNhap.Text = "Phiếu nhập kho"
        '
        'grvPhieuNhap
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grvPhieuNhap.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvPhieuNhap.Location = New System.Drawing.Point(3, 17)
        Me.grvPhieuNhap.Name = "grvPhieuNhap"
        Me.grvPhieuNhap.Size = New System.Drawing.Size(676, 189)
        Me.grvPhieuNhap.TabIndex = 0
        '
        'grbMayNhap
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grbMayNhap, 6)
        Me.grbMayNhap.Controls.Add(Me.grvMayNhap)
        Me.grbMayNhap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbMayNhap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbMayNhap.Location = New System.Drawing.Point(3, 280)
        Me.grbMayNhap.Name = "grbMayNhap"
        Me.grbMayNhap.Size = New System.Drawing.Size(682, 209)
        Me.grbMayNhap.TabIndex = 2
        Me.grbMayNhap.TabStop = False
        Me.grbMayNhap.Text = "Danh sách máy mới nhập"
        '
        'grvMayNhap
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grvMayNhap.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grvMayNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvMayNhap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvMayNhap.Location = New System.Drawing.Point(3, 17)
        Me.grvMayNhap.Name = "grvMayNhap"
        Me.grvMayNhap.Size = New System.Drawing.Size(676, 189)
        Me.grvMayNhap.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 38)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 21)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Từ ngày"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(343, 38)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Đến ngày"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtTuNgay
        '
        Me.dtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtTuNgay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTuNgay.Location = New System.Drawing.Point(193, 38)
        Me.dtTuNgay.Name = "dtTuNgay"
        Me.dtTuNgay.Size = New System.Drawing.Size(144, 21)
        Me.dtTuNgay.TabIndex = 5
        '
        'dtDenNgay
        '
        Me.dtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDenNgay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDenNgay.Location = New System.Drawing.Point(403, 38)
        Me.dtDenNgay.Name = "dtDenNgay"
        Me.dtDenNgay.Size = New System.Drawing.Size(144, 21)
        Me.dtDenNgay.TabIndex = 6
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 6)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 495)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 60, 0)
        Me.Panel1.Size = New System.Drawing.Size(682, 30)
        Me.Panel1.TabIndex = 7
        '
        'btnExport
        '
        Me.btnExport.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(472, 0)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 30)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "&Chuyển"

        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(547, 0)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 30)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Th&oát"
        
        '
        'frmExportData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 528)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmExportData"
        Me.Text = "Export Oracle"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.grbPhieuNhap.ResumeLayout(False)
        CType(Me.grvPhieuNhap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbMayNhap.ResumeLayout(False)
        CType(Me.grvMayNhap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents labTitle As System.Windows.Forms.Label
    Friend WithEvents grbPhieuNhap As System.Windows.Forms.GroupBox
    Friend WithEvents grbMayNhap As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents grvPhieuNhap As System.Windows.Forms.DataGridView
    Friend WithEvents grvMayNhap As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
End Class
