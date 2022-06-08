<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBIEU_DO_MAIN_HOUR
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
        Me.dtpDenngay = New System.Windows.Forms.DateTimePicker()
        Me.dtpTungay = New System.Windows.Forms.DateTimePicker()
        Me.cbBPCP = New System.Windows.Forms.ComboBox()
        Me.lblDenngay = New System.Windows.Forms.Label()
        Me.lblTungay = New System.Windows.Forms.Label()
        Me.lblBPCP = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpDenngay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpDenngay, 2)
        Me.dtpDenngay.CustomFormat = "MM/yyyy"
        Me.dtpDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenngay.Location = New System.Drawing.Point(457, 18)
        Me.dtpDenngay.Name = "dtpDenngay"
        Me.dtpDenngay.Size = New System.Drawing.Size(228, 21)
        Me.dtpDenngay.TabIndex = 8
        '
        'dtpTungay
        '
        Me.dtpTungay.CustomFormat = "MM/yyyy"
        Me.dtpTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTungay.Location = New System.Drawing.Point(223, 18)
        Me.dtpTungay.Name = "dtpTungay"
        Me.dtpTungay.Size = New System.Drawing.Size(118, 21)
        Me.dtpTungay.TabIndex = 9
        '
        'cbBPCP
        '
        Me.cbBPCP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbBPCP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbBPCP, 4)
        Me.cbBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbBPCP.FormattingEnabled = True
        Me.cbBPCP.Location = New System.Drawing.Point(223, 43)
        Me.cbBPCP.Name = "cbBPCP"
        Me.cbBPCP.Size = New System.Drawing.Size(462, 21)
        Me.cbBPCP.TabIndex = 7
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngay.Location = New System.Drawing.Point(347, 15)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(104, 25)
        Me.lblDenngay.TabIndex = 4
        Me.lblDenngay.Text = "Đến tháng"
        Me.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTungay.Location = New System.Drawing.Point(113, 15)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(104, 25)
        Me.lblTungay.TabIndex = 5
        Me.lblTungay.Text = "Từ tháng"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBPCP
        '
        Me.lblBPCP.AutoSize = True
        Me.lblBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBPCP.Location = New System.Drawing.Point(113, 40)
        Me.lblBPCP.Name = "lblBPCP"
        Me.lblBPCP.Size = New System.Drawing.Size(104, 25)
        Me.lblBPCP.TabIndex = 6
        Me.lblBPCP.Text = "Bộ phận chịu phí"
        Me.lblBPCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblBPCP, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDenngay, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbBPCP, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTungay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTungay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenngay, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 5, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(799, 572)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = Global.Commons.My.Resources.Resources.Thoat
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(691, 535)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(105, 30)
        Me.btnThoat.TabIndex = 17
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(581, 535)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 16
        Me.btnThucHien.Text = "Thực hiện"
        '
        'frmrptBIEU_DO_MAIN_HOUR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptBIEU_DO_MAIN_HOUR"
        Me.Size = New System.Drawing.Size(799, 572)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpDenngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbBPCP As System.Windows.Forms.ComboBox
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents lblBPCP As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
