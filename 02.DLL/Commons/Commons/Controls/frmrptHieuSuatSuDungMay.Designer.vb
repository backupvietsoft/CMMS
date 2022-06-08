<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptHieuSuatSuDungMay
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
        Me.components = New System.ComponentModel.Container()
        Me.lbaNhaXuong = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaLoaiMay = New System.Windows.Forms.Label()
        Me.lbaNam = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.prbIN = New DevExpress.XtraEditors.ProgressBarControl()
        Me.cbxNhaXuong = New MVControl.ucComboboxTreeList()
        Me.cbxLoaiMay = New Commons.UtcComboBox()
        Me.cbxNam = New Commons.UtcComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbaNhaXuong
        '
        Me.lbaNhaXuong.AutoSize = True
        Me.lbaNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhaXuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaNhaXuong.Location = New System.Drawing.Point(81, 35)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(56, 27)
        Me.lbaNhaXuong.TabIndex = 15
        Me.lbaNhaXuong.Text = "Nhà xưởng"
        Me.lbaNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbaLoaiMay
        '
        Me.lbaLoaiMay.AutoSize = True
        Me.lbaLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaLoaiMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaLoaiMay.Location = New System.Drawing.Point(81, 62)
        Me.lbaLoaiMay.Name = "lbaLoaiMay"
        Me.lbaLoaiMay.Size = New System.Drawing.Size(56, 28)
        Me.lbaLoaiMay.TabIndex = 13
        Me.lbaLoaiMay.Text = "Loại máy"
        Me.lbaLoaiMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaNam
        '
        Me.lbaNam.AutoSize = True
        Me.lbaNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaNam.Location = New System.Drawing.Point(81, 10)
        Me.lbaNam.Name = "lbaNam"
        Me.lbaNam.Size = New System.Drawing.Size(56, 25)
        Me.lbaNam.TabIndex = 12
        Me.lbaNam.Text = "Năm "
        Me.lbaNam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.prbIN, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNam, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaXuong, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxLoaiMay, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaXuong, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaLoaiMay, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNam, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 6)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(524, 385)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'prbIN
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.prbIN, 5)
        Me.prbIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prbIN.Location = New System.Drawing.Point(3, 327)
        Me.prbIN.Name = "prbIN"
        Me.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.prbIN.Properties.LookAndFeel.SkinName = "Blue"
        Me.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.prbIN.Properties.Maximum = 0
        Me.prbIN.Properties.Step = 1
        Me.prbIN.Size = New System.Drawing.Size(518, 18)
        Me.prbIN.TabIndex = 35
        '
        'cbxNhaXuong
        '
        Me.cbxNhaXuong.Appearance.BackColor = System.Drawing.Color.White
        Me.cbxNhaXuong.Appearance.Options.UseBackColor = True
        Me.cbxNhaXuong.ColumnDisplayName = Nothing
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxNhaXuong, 2)
        Me.cbxNhaXuong.DataSource = Nothing
        Me.cbxNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNhaXuong.EditValue = Nothing
        Me.cbxNhaXuong.KeyFieldName = Nothing
        Me.cbxNhaXuong.Location = New System.Drawing.Point(143, 38)
        Me.cbxNhaXuong.MaximumSize = New System.Drawing.Size(1000, 20)
        Me.cbxNhaXuong.MinimumSize = New System.Drawing.Size(10, 20)
        Me.cbxNhaXuong.Name = "cbxNhaXuong"
        Me.cbxNhaXuong.ParentFieldName = Nothing
        Me.cbxNhaXuong.ReadOnly = False
        Me.cbxNhaXuong.SelectedIndex = 0
        Me.cbxNhaXuong.Size = New System.Drawing.Size(296, 20)
        Me.cbxNhaXuong.TabIndex = 14
        Me.cbxNhaXuong.TextValue = Nothing
        '
        'cbxLoaiMay
        '
        Me.cbxLoaiMay.AssemblyName = ""
        Me.cbxLoaiMay.BackColor = System.Drawing.Color.White
        Me.cbxLoaiMay.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxLoaiMay.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxLoaiMay.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxLoaiMay, 2)
        Me.cbxLoaiMay.Display = ""
        Me.cbxLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxLoaiMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxLoaiMay.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxLoaiMay.FormattingEnabled = True
        Me.cbxLoaiMay.IsAll = False
        Me.cbxLoaiMay.isInputNull = False
        Me.cbxLoaiMay.IsNew = False
        Me.cbxLoaiMay.IsNull = True
        Me.cbxLoaiMay.ItemAll = " < ALL > "
        Me.cbxLoaiMay.ItemNew = "...New"
        Me.cbxLoaiMay.Location = New System.Drawing.Point(143, 65)
        Me.cbxLoaiMay.MethodName = ""
        Me.cbxLoaiMay.Name = "cbxLoaiMay"
        Me.cbxLoaiMay.Param = ""
        Me.cbxLoaiMay.Param2 = ""
        Me.cbxLoaiMay.Size = New System.Drawing.Size(296, 21)
        Me.cbxLoaiMay.StoreName = ""
        Me.cbxLoaiMay.TabIndex = 9
        Me.cbxLoaiMay.Table = Nothing
        Me.cbxLoaiMay.TextReadonly = False
        Me.cbxLoaiMay.Value = ""
        '
        'cbxNam
        '
        Me.cbxNam.AssemblyName = ""
        Me.cbxNam.BorderColor = System.Drawing.Color.Empty
        Me.cbxNam.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxNam.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxNam, 2)
        Me.cbxNam.Display = ""
        Me.cbxNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNam.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxNam.FormattingEnabled = True
        Me.cbxNam.IsAll = False
        Me.cbxNam.isInputNull = False
        Me.cbxNam.IsNew = False
        Me.cbxNam.IsNull = True
        Me.cbxNam.ItemAll = " < ALL > "
        Me.cbxNam.ItemNew = "...New"
        Me.cbxNam.Location = New System.Drawing.Point(143, 13)
        Me.cbxNam.MethodName = ""
        Me.cbxNam.Name = "cbxNam"
        Me.cbxNam.Param = ""
        Me.cbxNam.Param2 = ""
        Me.cbxNam.Size = New System.Drawing.Size(296, 21)
        Me.cbxNam.StoreName = ""
        Me.cbxNam.TabIndex = 8
        Me.cbxNam.Table = Nothing
        Me.cbxNam.TextReadonly = False
        Me.cbxNam.Value = ""
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 5)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 351)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(518, 31)
        Me.TableLayoutPanel2.TabIndex = 34
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(425, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(90, 25)
        Me.btnThoat.TabIndex = 33
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(315, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(90, 25)
        Me.btnThucHien.TabIndex = 16
        Me.btnThucHien.Text = "Thực hiện"
        '
        'frmrptHieuSuatSuDungMay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptHieuSuatSuDungMay"
        Me.Size = New System.Drawing.Size(524, 385)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label
    Friend WithEvents cbxNhaXuong As MVControl.ucComboboxTreeList
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaNam As System.Windows.Forms.Label
    Friend WithEvents cbxLoaiMay As Commons.UtcComboBox
    Friend WithEvents lbaLoaiMay As System.Windows.Forms.Label
    Friend WithEvents cbxNam As Commons.UtcComboBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Private WithEvents prbIN As DevExpress.XtraEditors.ProgressBarControl

End Class
