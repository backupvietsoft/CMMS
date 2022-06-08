<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDanhSachPhieuNhap
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptDanhSachPhieuNhap))
        Me.labKho = New System.Windows.Forms.Label()
        Me.labTuNg = New System.Windows.Forms.Label()
        Me.labDenNg = New System.Windows.Forms.Label()
        Me.gvPhieuNhapKho = New System.Windows.Forms.DataGridView()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.daTimeTuNgay = New DevExpress.XtraEditors.DateEdit()
        Me.daTimeDenNgay = New DevExpress.XtraEditors.DateEdit()
        Me.cmbKho = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.gvPhieuNhapKho, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.daTimeTuNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.daTimeTuNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.daTimeDenNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.daTimeDenNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbKho.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labKho
        '
        Me.labKho.AutoSize = True
        Me.labKho.Dock = System.Windows.Forms.DockStyle.Left
        Me.labKho.Location = New System.Drawing.Point(105, 31)
        Me.labKho.Name = "labKho"
        Me.labKho.Size = New System.Drawing.Size(26, 31)
        Me.labKho.TabIndex = 0
        Me.labKho.Text = "Kho"
        Me.labKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labTuNg
        '
        Me.labTuNg.AutoSize = True
        Me.labTuNg.Dock = System.Windows.Forms.DockStyle.Left
        Me.labTuNg.Location = New System.Drawing.Point(105, 0)
        Me.labTuNg.Name = "labTuNg"
        Me.labTuNg.Size = New System.Drawing.Size(46, 31)
        Me.labTuNg.TabIndex = 1
        Me.labTuNg.Text = "Từ ngày"
        Me.labTuNg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labDenNg
        '
        Me.labDenNg.AutoSize = True
        Me.labDenNg.Dock = System.Windows.Forms.DockStyle.Left
        Me.labDenNg.Location = New System.Drawing.Point(344, 0)
        Me.labDenNg.Name = "labDenNg"
        Me.labDenNg.Size = New System.Drawing.Size(53, 31)
        Me.labDenNg.TabIndex = 2
        Me.labDenNg.Text = "Đến ngày"
        Me.labDenNg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gvPhieuNhapKho
        '
        Me.gvPhieuNhapKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvPhieuNhapKho.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvPhieuNhapKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel4.SetColumnSpan(Me.gvPhieuNhapKho, 6)
        Me.gvPhieuNhapKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvPhieuNhapKho.Location = New System.Drawing.Point(3, 65)
        Me.gvPhieuNhapKho.Name = "gvPhieuNhapKho"
        Me.gvPhieuNhapKho.Size = New System.Drawing.Size(680, 244)
        Me.gvPhieuNhapKho.TabIndex = 3
        '
        'btnThucHien
        '


        Me.btnThucHien.Location = New System.Drawing.Point(500, 0)

        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False

        Me.btnThucHien.Size = New System.Drawing.Size(90, 31)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"


        '
        'btnThoat
        '


        Me.btnThoat.Location = New System.Drawing.Point(590, 0)

        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False

        Me.btnThoat.Size = New System.Drawing.Size(90, 31)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"


        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.labDenNg, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.labTuNg, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.labKho, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.gvPhieuNhapKho, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel5, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.daTimeTuNgay, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.daTimeDenNgay, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbKho, 2, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(686, 349)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel4.SetColumnSpan(Me.TableLayoutPanel5, 6)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 315)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(680, 31)
        Me.TableLayoutPanel5.TabIndex = 6
        '
        'daTimeTuNgay
        '
        Me.daTimeTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.daTimeTuNgay.EditValue = Nothing
        Me.daTimeTuNgay.Location = New System.Drawing.Point(187, 3)
        Me.daTimeTuNgay.Name = "daTimeTuNgay"
        Me.daTimeTuNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.daTimeTuNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.daTimeTuNgay.Size = New System.Drawing.Size(151, 20)
        Me.daTimeTuNgay.TabIndex = 7
        '
        'daTimeDenNgay
        '
        Me.daTimeDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.daTimeDenNgay.EditValue = Nothing
        Me.daTimeDenNgay.Location = New System.Drawing.Point(426, 3)
        Me.daTimeDenNgay.Name = "daTimeDenNgay"
        Me.daTimeDenNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.daTimeDenNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.daTimeDenNgay.Size = New System.Drawing.Size(151, 20)
        Me.daTimeDenNgay.TabIndex = 10
        '
        'cmbKho
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.cmbKho, 3)
        Me.cmbKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbKho.Location = New System.Drawing.Point(187, 34)
        Me.cmbKho.Name = "cmbKho"
        Me.cmbKho.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbKho.Size = New System.Drawing.Size(390, 20)
        Me.cmbKho.TabIndex = 9
        '
        'frmrptDanhSachPhieuNhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.Name = "frmrptDanhSachPhieuNhap"
        Me.Size = New System.Drawing.Size(686, 349)
        CType(Me.gvPhieuNhapKho, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.daTimeTuNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.daTimeTuNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.daTimeDenNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.daTimeDenNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbKho.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labKho As System.Windows.Forms.Label
    Friend WithEvents labTuNg As System.Windows.Forms.Label
    Friend WithEvents labDenNg As System.Windows.Forms.Label
    Friend WithEvents gvPhieuNhapKho As System.Windows.Forms.DataGridView
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents daTimeTuNgay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmbKho As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents daTimeDenNgay As DevExpress.XtraEditors.DateEdit

End Class
