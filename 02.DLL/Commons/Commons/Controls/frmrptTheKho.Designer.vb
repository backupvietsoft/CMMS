<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptTheKho
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Me.lbaTuNgay = New System.Windows.Forms.Label()
        Me.lbaKho = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.cbxVTPT = New System.Windows.Forms.ComboBox()
        Me.lbaDenNgay = New System.Windows.Forms.Label()
        Me.lbaVTPT = New System.Windows.Forms.Label()
        Me.cbxKho = New System.Windows.Forms.ComboBox()
        Me.dtTNgay = New DevExpress.XtraEditors.DateEdit()
        Me.dtDNgay = New DevExpress.XtraEditors.DateEdit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dtTNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaTuNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaTuNgay.Location = New System.Drawing.Point(155, 18)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(46, 25)
        Me.lbaTuNgay.TabIndex = 0
        Me.lbaTuNgay.Text = "Từ ngày"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaKho
        '
        Me.lbaKho.AutoSize = True
        Me.lbaKho.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaKho.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaKho.Location = New System.Drawing.Point(155, 43)
        Me.lbaKho.Name = "lbaKho"
        Me.lbaKho.Size = New System.Drawing.Size(26, 25)
        Me.lbaKho.TabIndex = 2
        Me.lbaKho.Text = "Kho"
        Me.lbaKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxVTPT, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaVTPT, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxKho, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaKho, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtTNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtDNgay, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1125, 616)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 576)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1113, 36)
        Me.TableLayoutPanel2.TabIndex = 19
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(1006, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(896, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 18
        Me.btnThucHien.Text = "Thực hiện"
        '
        'cbxVTPT
        '
        Me.cbxVTPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxVTPT.DropDownWidth = 400
        Me.cbxVTPT.FormattingEnabled = True
        Me.cbxVTPT.Location = New System.Drawing.Point(674, 46)
        Me.cbxVTPT.Name = "cbxVTPT"
        Me.cbxVTPT.Size = New System.Drawing.Size(293, 21)
        Me.cbxVTPT.TabIndex = 7
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaDenNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaDenNgay.Location = New System.Drawing.Point(564, 18)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(53, 25)
        Me.lbaDenNgay.TabIndex = 6
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaVTPT
        '
        Me.lbaVTPT.AutoSize = True
        Me.lbaVTPT.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaVTPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaVTPT.Location = New System.Drawing.Point(564, 43)
        Me.lbaVTPT.Name = "lbaVTPT"
        Me.lbaVTPT.Size = New System.Drawing.Size(44, 25)
        Me.lbaVTPT.TabIndex = 3
        Me.lbaVTPT.Text = "VT - PT"
        Me.lbaVTPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxKho
        '
        Me.cbxKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxKho.DropDownWidth = 150
        Me.cbxKho.FormattingEnabled = True
        Me.cbxKho.Location = New System.Drawing.Point(265, 46)
        Me.cbxKho.Name = "cbxKho"
        Me.cbxKho.Size = New System.Drawing.Size(293, 21)
        Me.cbxKho.TabIndex = 1
        '
        'dtTNgay
        '
        Me.dtTNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtTNgay.EditValue = Nothing
        Me.dtTNgay.Location = New System.Drawing.Point(265, 21)
        Me.dtTNgay.Name = "dtTNgay"
        Me.dtTNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTNgay.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtTNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtTNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtTNgay.Size = New System.Drawing.Size(293, 20)
        Me.dtTNgay.TabIndex = 20
        '
        'dtDNgay
        '
        Me.dtDNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDNgay.EditValue = Nothing
        Me.dtDNgay.Location = New System.Drawing.Point(674, 21)
        Me.dtDNgay.Name = "dtDNgay"
        Me.dtDNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtDNgay.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtDNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtDNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtDNgay.Size = New System.Drawing.Size(293, 20)
        Me.dtDNgay.TabIndex = 21
        '
        'frmrptTheKho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptTheKho"
        Me.Size = New System.Drawing.Size(1125, 616)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.dtTNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents lbaKho As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbxVTPT As System.Windows.Forms.ComboBox
    Friend WithEvents cbxKho As System.Windows.Forms.ComboBox
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents lbaVTPT As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtTNgay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtDNgay As DevExpress.XtraEditors.DateEdit
End Class
