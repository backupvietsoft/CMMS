<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonCongViecChoBoPhan
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblTieuDe = New System.Windows.Forms.Label
        Me.grpDanhsachcongviec = New System.Windows.Forms.GroupBox
        Me.grvDSCongViec = New System.Windows.Forms.DataGridView
        Me.grpDanhsachmaybophan = New System.Windows.Forms.GroupBox
        Me.grdDanhsachmaybophan = New System.Windows.Forms.DataGridView
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.lblThietBi = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.grpDanhsachcongviec.SuspendLayout()
        CType(Me.grvDSCongViec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachmaybophan.SuspendLayout()
        CType(Me.grdDanhsachmaybophan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTieuDe
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieuDe, 4)
        Me.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieuDe.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieuDe.Location = New System.Drawing.Point(3, 0)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(784, 35)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "CHỌN CÔNG VIỆC CHO CÁC BỘ PHÂN THAY THẾ CỦA THIẾT BỊ"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpDanhsachcongviec
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDanhsachcongviec, 2)
        Me.grpDanhsachcongviec.Controls.Add(Me.grvDSCongViec)
        Me.grpDanhsachcongviec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachcongviec.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachcongviec.Location = New System.Drawing.Point(3, 66)
        Me.grpDanhsachcongviec.Name = "grpDanhsachcongviec"
        Me.grpDanhsachcongviec.Size = New System.Drawing.Size(389, 423)
        Me.grpDanhsachcongviec.TabIndex = 1
        Me.grpDanhsachcongviec.TabStop = False
        Me.grpDanhsachcongviec.Text = "Danh sách công việc theo bộ phận"
        '
        'grvDSCongViec
        '
        Me.grvDSCongViec.AllowUserToAddRows = False
        Me.grvDSCongViec.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grvDSCongViec.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grvDSCongViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grvDSCongViec.DefaultCellStyle = DataGridViewCellStyle4
        Me.grvDSCongViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvDSCongViec.Location = New System.Drawing.Point(3, 17)
        Me.grvDSCongViec.Name = "grvDSCongViec"
        Me.grvDSCongViec.ReadOnly = True
        Me.grvDSCongViec.RowHeadersWidth = 25
        Me.grvDSCongViec.Size = New System.Drawing.Size(383, 403)
        Me.grvDSCongViec.TabIndex = 0
        '
        'grpDanhsachmaybophan
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDanhsachmaybophan, 2)
        Me.grpDanhsachmaybophan.Controls.Add(Me.grdDanhsachmaybophan)
        Me.grpDanhsachmaybophan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachmaybophan.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachmaybophan.Location = New System.Drawing.Point(398, 66)
        Me.grpDanhsachmaybophan.Name = "grpDanhsachmaybophan"
        Me.grpDanhsachmaybophan.Size = New System.Drawing.Size(389, 423)
        Me.grpDanhsachmaybophan.TabIndex = 2
        Me.grpDanhsachmaybophan.TabStop = False
        Me.grpDanhsachmaybophan.Text = "Danh sách máy bộ phận"
        '
        'grdDanhsachmaybophan
        '
        Me.grdDanhsachmaybophan.AllowUserToAddRows = False
        Me.grdDanhsachmaybophan.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhsachmaybophan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachmaybophan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachmaybophan.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachmaybophan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachmaybophan.Location = New System.Drawing.Point(3, 17)
        Me.grdDanhsachmaybophan.Name = "grdDanhsachmaybophan"
        Me.grdDanhsachmaybophan.ReadOnly = True
        Me.grdDanhsachmaybophan.RowHeadersWidth = 25
        Me.grdDanhsachmaybophan.Size = New System.Drawing.Size(383, 403)
        Me.grdDanhsachmaybophan.TabIndex = 0
        '
        'BtnThoat
        '
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Red
        Me.BtnThoat.Location = New System.Drawing.Point(707, 495)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(80, 26)
        Me.BtnThoat.TabIndex = 18
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'lblThietBi
        '
        Me.lblThietBi.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblThietBi, 2)
        Me.lblThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblThietBi.Location = New System.Drawing.Point(348, 35)
        Me.lblThietBi.Name = "lblThietBi"
        Me.lblThietBi.Size = New System.Drawing.Size(94, 28)
        Me.lblThietBi.TabIndex = 19
        Me.lblThietBi.Text = "Thiết bị"
        Me.lblThietBi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblThietBi, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnThoat, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieuDe, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachmaybophan, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachcongviec, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(790, 524)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'frmChonCongViecChoBoPhan
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 524)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChonCongViecChoBoPhan"
        Me.Text = "frmChonCongViecChoBoPhan"
        Me.grpDanhsachcongviec.ResumeLayout(False)
        CType(Me.grvDSCongViec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachmaybophan.ResumeLayout(False)
        CType(Me.grdDanhsachmaybophan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents grpDanhsachcongviec As System.Windows.Forms.GroupBox
    Friend WithEvents grvDSCongViec As System.Windows.Forms.DataGridView
    Friend WithEvents grpDanhsachmaybophan As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachmaybophan As System.Windows.Forms.DataGridView
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents lblThietBi As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
