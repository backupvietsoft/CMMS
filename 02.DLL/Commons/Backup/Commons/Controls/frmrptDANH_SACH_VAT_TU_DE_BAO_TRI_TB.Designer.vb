<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDANH_SACH_VAT_TU_DE_BAO_TRI_TB
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
        Me.lbaNxuong = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaDenNgay = New System.Windows.Forms.Label
        Me.lbaTuNgay = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnExecute = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.datDNgay = New DevExpress.XtraEditors.DateEdit
        Me.datTNgay = New DevExpress.XtraEditors.DateEdit
        Me.cboDDiem = New DevExpress.XtraEditors.LookUpEdit
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.datDNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datTNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datTNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDDiem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbaNxuong
        '
        Me.lbaNxuong.AutoSize = True
        Me.lbaNxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNxuong.Location = New System.Drawing.Point(122, 25)
        Me.lbaNxuong.Name = "lbaNxuong"
        Me.lbaNxuong.Size = New System.Drawing.Size(89, 25)
        Me.lbaNxuong.TabIndex = 16
        Me.lbaNxuong.Text = "Nhà xưởng"
        Me.lbaNxuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(400, 0)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(89, 25)
        Me.lbaDenNgay.TabIndex = 10
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(122, 0)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(89, 25)
        Me.lbaTuNgay.TabIndex = 9
        Me.lbaTuNgay.Text = "Từ ngày"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNxuong, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.datDNgay, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.datTNgay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDDiem, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(796, 445)
        Me.TableLayoutPanel1.TabIndex = 17
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnExecute, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 406)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(790, 36)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'btnExecute
        '
        Me.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExecute.Location = New System.Drawing.Point(573, 3)
        Me.btnExecute.LookAndFeel.SkinName = "Blue"
        Me.btnExecute.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(104, 30)
        Me.btnExecute.TabIndex = 37
        Me.btnExecute.Text = "Thực hiện"
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(683, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 38
        Me.btnThoat.Text = "Thoát"
        '
        'datDNgay
        '
        Me.datDNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datDNgay.EditValue = Nothing
        Me.datDNgay.Location = New System.Drawing.Point(495, 3)
        Me.datDNgay.Name = "datDNgay"
        Me.datDNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datDNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.datDNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.datDNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.datDNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.datDNgay.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.datDNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.datDNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.datDNgay.Size = New System.Drawing.Size(177, 20)
        Me.datDNgay.TabIndex = 35
        '
        'datTNgay
        '
        Me.datTNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datTNgay.EditValue = Nothing
        Me.datTNgay.Location = New System.Drawing.Point(217, 3)
        Me.datTNgay.Name = "datTNgay"
        Me.datTNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datTNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.datTNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.datTNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.datTNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.datTNgay.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.datTNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.datTNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.datTNgay.Size = New System.Drawing.Size(177, 20)
        Me.datTNgay.TabIndex = 34
        '
        'cboDDiem
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboDDiem, 3)
        Me.cboDDiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDDiem.Location = New System.Drawing.Point(217, 28)
        Me.cboDDiem.Name = "cboDDiem"
        Me.cboDDiem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDDiem.Size = New System.Drawing.Size(455, 20)
        Me.cboDDiem.TabIndex = 36
        '
        'frmrptDANH_SACH_VAT_TU_DE_BAO_TRI_TB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptDANH_SACH_VAT_TU_DE_BAO_TRI_TB"
        Me.Size = New System.Drawing.Size(796, 445)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.datDNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datTNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datTNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDDiem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbaNxuong As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents datTNgay As DevExpress.XtraEditors.DateEdit
    Private WithEvents datDNgay As DevExpress.XtraEditors.DateEdit
    Private WithEvents cboDDiem As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents btnExecute As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
