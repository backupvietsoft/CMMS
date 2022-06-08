<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptKE_HOACH_BT_TUAN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptKE_HOACH_BT_TUAN))
        Me.labTuNgay = New System.Windows.Forms.Label()
        Me.labDenNgay = New System.Windows.Forms.Label()
        Me.FromDate = New System.Windows.Forms.DateTimePicker()
        Me.labNhaXuong = New System.Windows.Forms.Label()
        Me.labLoaiCV = New System.Windows.Forms.Label()
        Me.labGroupBy = New System.Windows.Forms.Label()
        Me.cboPlace = New System.Windows.Forms.ComboBox()
        Me.tlMaint = New System.Windows.Forms.TableLayoutPanel()
        Me.ToDate = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.cboTypeJob = New System.Windows.Forms.ComboBox()
        Me.cboGroup = New System.Windows.Forms.ComboBox()
        Me.tlMaint.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'labTuNgay
        '
        Me.labTuNgay.AutoSize = True
        Me.labTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labTuNgay.Location = New System.Drawing.Point(95, 0)
        Me.labTuNgay.Name = "labTuNgay"
        Me.labTuNgay.Size = New System.Drawing.Size(67, 25)
        Me.labTuNgay.TabIndex = 0
        Me.labTuNgay.Text = "Từ ngày"
        Me.labTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labDenNgay
        '
        Me.labDenNgay.AutoSize = True
        Me.labDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labDenNgay.Location = New System.Drawing.Point(309, 0)
        Me.labDenNgay.Name = "labDenNgay"
        Me.labDenNgay.Size = New System.Drawing.Size(67, 25)
        Me.labDenNgay.TabIndex = 1
        Me.labDenNgay.Text = "Đến ngày"
        Me.labDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FromDate
        '
        Me.FromDate.CustomFormat = "dd/MM/yyyy"
        Me.FromDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FromDate.Location = New System.Drawing.Point(168, 3)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(135, 20)
        Me.FromDate.TabIndex = 2
        Me.FromDate.Value = New Date(2009, 4, 26, 0, 0, 0, 0)
        '
        'labNhaXuong
        '
        Me.labNhaXuong.AutoSize = True
        Me.labNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labNhaXuong.Location = New System.Drawing.Point(95, 25)
        Me.labNhaXuong.Name = "labNhaXuong"
        Me.labNhaXuong.Size = New System.Drawing.Size(67, 25)
        Me.labNhaXuong.TabIndex = 4
        Me.labNhaXuong.Text = "Nhà xưởng"
        Me.labNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labLoaiCV
        '
        Me.labLoaiCV.AutoSize = True
        Me.labLoaiCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labLoaiCV.Location = New System.Drawing.Point(309, 25)
        Me.labLoaiCV.Name = "labLoaiCV"
        Me.labLoaiCV.Size = New System.Drawing.Size(67, 25)
        Me.labLoaiCV.TabIndex = 5
        Me.labLoaiCV.Text = "Loại công việc"
        Me.labLoaiCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labGroupBy
        '
        Me.labGroupBy.AutoSize = True
        Me.labGroupBy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labGroupBy.Location = New System.Drawing.Point(95, 50)
        Me.labGroupBy.Name = "labGroupBy"
        Me.labGroupBy.Size = New System.Drawing.Size(67, 25)
        Me.labGroupBy.TabIndex = 6
        Me.labGroupBy.Text = "Nhóm theo"
        Me.labGroupBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPlace
        '
        Me.cboPlace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPlace.FormattingEnabled = True
        Me.cboPlace.Location = New System.Drawing.Point(168, 28)
        Me.cboPlace.Name = "cboPlace"
        Me.cboPlace.Size = New System.Drawing.Size(135, 21)
        Me.cboPlace.TabIndex = 8
        '
        'tlMaint
        '
        Me.tlMaint.ColumnCount = 6
        Me.tlMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.tlMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.tlMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.tlMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.tlMaint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlMaint.Controls.Add(Me.labDenNgay, 3, 0)
        Me.tlMaint.Controls.Add(Me.ToDate, 4, 0)
        Me.tlMaint.Controls.Add(Me.TableLayoutPanel1, 0, 4)
        Me.tlMaint.Controls.Add(Me.FromDate, 2, 0)
        Me.tlMaint.Controls.Add(Me.labTuNgay, 1, 0)
        Me.tlMaint.Controls.Add(Me.cboPlace, 2, 1)
        Me.tlMaint.Controls.Add(Me.labNhaXuong, 1, 1)
        Me.tlMaint.Controls.Add(Me.labLoaiCV, 3, 1)
        Me.tlMaint.Controls.Add(Me.cboTypeJob, 4, 1)
        Me.tlMaint.Controls.Add(Me.labGroupBy, 1, 2)
        Me.tlMaint.Controls.Add(Me.cboGroup, 2, 2)
        Me.tlMaint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlMaint.Location = New System.Drawing.Point(0, 0)
        Me.tlMaint.Name = "tlMaint"
        Me.tlMaint.RowCount = 5
        Me.tlMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlMaint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlMaint.Size = New System.Drawing.Size(616, 465)
        Me.tlMaint.TabIndex = 1
        '
        'ToDate
        '
        Me.ToDate.CustomFormat = "dd/MM/yyyy"
        Me.ToDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ToDate.Location = New System.Drawing.Point(382, 3)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(135, 20)
        Me.ToDate.TabIndex = 3
        Me.ToDate.Value = New Date(2009, 4, 26, 0, 0, 0, 0)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.tlMaint.SetColumnSpan(Me.TableLayoutPanel1, 6)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 426)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(610, 36)
        Me.TableLayoutPanel1.TabIndex = 25
        '
        'btnThoat
        '


        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(523, 3)
        Me.btnThoat.Name = "btnThoat"

        Me.btnThoat.Size = New System.Drawing.Size(84, 30)
        Me.btnThoat.TabIndex = 33
        Me.btnThoat.Text = "Thoát"


        '
        'btnThucHien
        '


        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(433, 3)
        Me.btnThucHien.Name = "btnThucHien"

        Me.btnThucHien.Size = New System.Drawing.Size(84, 30)
        Me.btnThucHien.TabIndex = 18
        Me.btnThucHien.Text = "Thực hiện"


        '
        'cboTypeJob
        '
        Me.cboTypeJob.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTypeJob.FormattingEnabled = True
        Me.cboTypeJob.Location = New System.Drawing.Point(382, 28)
        Me.cboTypeJob.Name = "cboTypeJob"
        Me.cboTypeJob.Size = New System.Drawing.Size(135, 21)
        Me.cboTypeJob.TabIndex = 9
        '
        'cboGroup
        '
        Me.tlMaint.SetColumnSpan(Me.cboGroup, 3)
        Me.cboGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboGroup.FormattingEnabled = True
        Me.cboGroup.Location = New System.Drawing.Point(168, 53)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.Size = New System.Drawing.Size(349, 21)
        Me.cboGroup.TabIndex = 10
        '
        'frmrptKE_HOACH_BT_TUAN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlMaint)
        Me.Name = "frmrptKE_HOACH_BT_TUAN"
        Me.Size = New System.Drawing.Size(616, 465)
        Me.tlMaint.ResumeLayout(False)
        Me.tlMaint.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labTuNgay As System.Windows.Forms.Label
    Friend WithEvents labDenNgay As System.Windows.Forms.Label
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents tlMaint As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents labNhaXuong As System.Windows.Forms.Label
    Friend WithEvents labLoaiCV As System.Windows.Forms.Label
    Friend WithEvents labGroupBy As System.Windows.Forms.Label
    Friend WithEvents cboPlace As System.Windows.Forms.ComboBox
    Friend WithEvents cboGroup As System.Windows.Forms.ComboBox
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboTypeJob As System.Windows.Forms.ComboBox

End Class
