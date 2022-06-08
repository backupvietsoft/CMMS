<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptGiaphutungtheodonhang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptGiaphutungtheodonhang))
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.lblLoaithietbi = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.cboPhuTung = New System.Windows.Forms.ComboBox
        Me.lblTungay = New System.Windows.Forms.Label
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.dtpTungay = New System.Windows.Forms.DateTimePicker
        Me.dtpDenngay = New System.Windows.Forms.DateTimePicker
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnThucHien
        '


        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(278, 314)

        Me.btnThucHien.Name = "btnThucHien"

        Me.btnThucHien.Size = New System.Drawing.Size(90, 24)
        Me.btnThucHien.TabIndex = 18
        Me.btnThucHien.Text = "Thực hiện"


        '
        'lblLoaithietbi
        '
        Me.lblLoaithietbi.AutoSize = True
        Me.lblLoaithietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaithietbi.Location = New System.Drawing.Point(3, 50)
        Me.lblLoaithietbi.Name = "lblLoaithietbi"
        Me.lblLoaithietbi.Size = New System.Drawing.Size(61, 25)
        Me.lblLoaithietbi.TabIndex = 1
        Me.lblLoaithietbi.Text = "Loại thiết bị"
        Me.lblLoaithietbi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaithietbi, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPhuTung, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTungay, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenngay, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTungay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDenngay, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(478, 341)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'cboPhuTung
        '
        Me.cboPhuTung.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPhuTung.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboPhuTung, 2)
        Me.cboPhuTung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPhuTung.FormattingEnabled = True
        Me.cboPhuTung.Location = New System.Drawing.Point(70, 53)
        Me.cboPhuTung.Name = "cboPhuTung"
        Me.cboPhuTung.Size = New System.Drawing.Size(405, 21)
        Me.cboPhuTung.TabIndex = 19
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTungay.Location = New System.Drawing.Point(3, 0)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(61, 25)
        Me.lblTungay.TabIndex = 1
        Me.lblTungay.Text = "Từ ngày"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngay.Location = New System.Drawing.Point(3, 25)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(61, 25)
        Me.lblDenngay.TabIndex = 1
        Me.lblDenngay.Text = "Đến ngày"
        Me.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTungay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpTungay, 2)
        Me.dtpTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTungay.Location = New System.Drawing.Point(70, 3)
        Me.dtpTungay.Name = "dtpTungay"
        Me.dtpTungay.Size = New System.Drawing.Size(405, 20)
        Me.dtpTungay.TabIndex = 20
        '
        'dtpDenngay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpDenngay, 2)
        Me.dtpDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDenngay.Location = New System.Drawing.Point(70, 28)
        Me.dtpDenngay.Name = "dtpDenngay"
        Me.dtpDenngay.Size = New System.Drawing.Size(405, 20)
        Me.dtpDenngay.TabIndex = 20
        Me.dtpDenngay.Value = New Date(2010, 10, 25, 0, 0, 0, 0)
        '
        'btnThoat
        '


        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(381, 314)
        
        Me.btnThoat.Name = "btnThoat"

        Me.btnThoat.Size = New System.Drawing.Size(87, 24)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"


        '
        'frmrptGiaphutungtheodonhang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptGiaphutungtheodonhang"
        Me.Size = New System.Drawing.Size(478, 341)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLoaithietbi As System.Windows.Forms.Label
    Friend WithEvents cboPhuTung As System.Windows.Forms.ComboBox
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents dtpTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDenngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
