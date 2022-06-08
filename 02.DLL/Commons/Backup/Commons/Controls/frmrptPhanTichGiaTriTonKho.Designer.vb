<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptPhanTichGiaTriTonKho
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptPhanTichGiaTriTonKho))
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaKho = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.cboKho = New Commons.UtcComboBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = CType(resources.GetObject("btnThucHien.BackgroundImage"), System.Drawing.Image)
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(206, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 18
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbaKho
        '
        Me.lbaKho.AutoSize = True
        Me.lbaKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaKho.Location = New System.Drawing.Point(67, 20)
        Me.lbaKho.Name = "lbaKho"
        Me.lbaKho.Size = New System.Drawing.Size(45, 25)
        Me.lbaKho.TabIndex = 19
        Me.lbaKho.Text = "Kho"
        Me.lbaKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cboKho, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaKho, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(429, 346)
        Me.TableLayoutPanel1.TabIndex = 21
        '
        'cboKho
        '
        Me.cboKho.AssemblyName = ""
        Me.cboKho.BackColor = System.Drawing.Color.White
        Me.cboKho.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboKho, 3)
        Me.cboKho.Display = ""
        Me.cboKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboKho.ErrorProviderControl = Me.ErrorProvider1
        Me.cboKho.FormattingEnabled = True
        Me.cboKho.IsAll = True
        Me.cboKho.isInputNull = False
        Me.cboKho.IsNew = False
        Me.cboKho.IsNull = True
        Me.cboKho.ItemAll = " < ALL > "
        Me.cboKho.ItemNew = "...New"
        Me.cboKho.Location = New System.Drawing.Point(118, 23)
        Me.cboKho.MethodName = ""
        Me.cboKho.Name = "cboKho"
        Me.cboKho.Param = ""
        Me.cboKho.Param2 = ""
        Me.cboKho.Size = New System.Drawing.Size(241, 21)
        Me.cboKho.StoreName = ""
        Me.cboKho.TabIndex = 20
        Me.cboKho.Table = Nothing
        Me.cboKho.TextReadonly = False
        Me.cboKho.Value = ""
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 307)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(423, 36)
        Me.TableLayoutPanel2.TabIndex = 37
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(316, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmrptPhanTichGiaTriTonKho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptPhanTichGiaTriTonKho"
        Me.Size = New System.Drawing.Size(429, 346)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents cboKho As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaKho As System.Windows.Forms.Label
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
