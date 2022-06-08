<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonCongViec
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
        Me.components = New System.ComponentModel.Container()
        Me.LblTieudechukyBTPN = New System.Windows.Forms.Label()
        Me.LblChonCV = New System.Windows.Forms.Label()
        Me.grdChonCongViec = New System.Windows.Forms.DataGridView()
        Me.BtnThoat = New System.Windows.Forms.Button()
        Me.BtnThucHien = New System.Windows.Forms.Button()
        Me.BtnBoChonTatCa = New System.Windows.Forms.Button()
        Me.BtnChonTatCa = New System.Windows.Forms.Button()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CboLoaiCongViec = New Commons.UtcComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.grdChonCongViec,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        Me.Panel1.SuspendLayout
        Me.SuspendLayout
        '
        'LblTieudechukyBTPN
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.LblTieudechukyBTPN, 2)
        Me.LblTieudechukyBTPN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTieudechukyBTPN.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LblTieudechukyBTPN.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblTieudechukyBTPN.Location = New System.Drawing.Point(3, 0)
        Me.LblTieudechukyBTPN.Name = "LblTieudechukyBTPN"
        Me.LblTieudechukyBTPN.Size = New System.Drawing.Size(784, 35)
        Me.LblTieudechukyBTPN.TabIndex = 25
        Me.LblTieudechukyBTPN.Text = "CHỌN CÔNG VIỆC CHO BẢO TRÌ PHÒNG NGỪA"
        Me.LblTieudechukyBTPN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTieudechukyBTPN.UseCompatibleTextRendering = true
        '
        'LblChonCV
        '
        Me.LblChonCV.AutoSize = true
        Me.LblChonCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblChonCV.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LblChonCV.Location = New System.Drawing.Point(3, 35)
        Me.LblChonCV.Name = "LblChonCV"
        Me.LblChonCV.Size = New System.Drawing.Size(114, 28)
        Me.LblChonCV.TabIndex = 26
        Me.LblChonCV.Text = "Loại công việc"
        Me.LblChonCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdChonCongViec
        '
        Me.grdChonCongViec.AllowUserToAddRows = false
        Me.grdChonCongViec.AllowUserToDeleteRows = false
        Me.grdChonCongViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdChonCongViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdChonCongViec, 2)
        Me.grdChonCongViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdChonCongViec.Location = New System.Drawing.Point(3, 66)
        Me.grdChonCongViec.Name = "grdChonCongViec"
        Me.grdChonCongViec.RowHeadersWidth = 25
        Me.grdChonCongViec.Size = New System.Drawing.Size(784, 415)
        Me.grdChonCongViec.TabIndex = 27
        '
        'BtnThoat
        '
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Red
        Me.BtnThoat.Location = New System.Drawing.Point(694, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(90, 26)
        Me.BtnThoat.TabIndex = 85
        Me.BtnThoat.Text = "Thoát"
        Me.BtnThoat.UseVisualStyleBackColor = true
        '
        'BtnThucHien
        '
        Me.BtnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThucHien.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnThucHien.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.BtnThucHien.Location = New System.Drawing.Point(604, 0)
        Me.BtnThucHien.Name = "BtnThucHien"
        Me.BtnThucHien.Size = New System.Drawing.Size(90, 26)
        Me.BtnThucHien.TabIndex = 84
        Me.BtnThucHien.Text = "Thực hiện"
        Me.BtnThucHien.UseVisualStyleBackColor = true
        '
        'BtnBoChonTatCa
        '
        Me.BtnBoChonTatCa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnBoChonTatCa.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnBoChonTatCa.ForeColor = System.Drawing.Color.Red
        Me.BtnBoChonTatCa.Location = New System.Drawing.Point(514, 0)
        Me.BtnBoChonTatCa.Name = "BtnBoChonTatCa"
        Me.BtnBoChonTatCa.Size = New System.Drawing.Size(90, 26)
        Me.BtnBoChonTatCa.TabIndex = 87
        Me.BtnBoChonTatCa.Text = "Bỏ chọn tất cả"
        Me.BtnBoChonTatCa.UseVisualStyleBackColor = true
        '
        'BtnChonTatCa
        '
        Me.BtnChonTatCa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChonTatCa.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtnChonTatCa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.BtnChonTatCa.Location = New System.Drawing.Point(424, 0)
        Me.BtnChonTatCa.Name = "BtnChonTatCa"
        Me.BtnChonTatCa.Size = New System.Drawing.Size(90, 26)
        Me.BtnChonTatCa.TabIndex = 86
        Me.BtnChonTatCa.Text = "Chọn tất cả"
        Me.BtnChonTatCa.UseVisualStyleBackColor = true
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'CboLoaiCongViec
        '
        Me.CboLoaiCongViec.AssemblyName = ""
        Me.CboLoaiCongViec.BackColor = System.Drawing.Color.White
        Me.CboLoaiCongViec.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171,Byte),Integer), CType(CType(193,Byte),Integer), CType(CType(222,Byte),Integer))
        Me.CboLoaiCongViec.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.CboLoaiCongViec.ClassName = ""
        Me.CboLoaiCongViec.Display = ""
        Me.CboLoaiCongViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CboLoaiCongViec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLoaiCongViec.ErrorProviderControl = Me.ErrorProvider
        Me.CboLoaiCongViec.FormattingEnabled = true
        Me.CboLoaiCongViec.IsAll = false
        Me.CboLoaiCongViec.isInputNull = false
        Me.CboLoaiCongViec.IsNew = false
        Me.CboLoaiCongViec.IsNull = true
        Me.CboLoaiCongViec.ItemAll = " < ALL > "
        Me.CboLoaiCongViec.ItemNew = "...New"
        Me.CboLoaiCongViec.Location = New System.Drawing.Point(123, 38)
        Me.CboLoaiCongViec.MethodName = ""
        Me.CboLoaiCongViec.Name = "CboLoaiCongViec"
        Me.CboLoaiCongViec.Param = ""
        Me.CboLoaiCongViec.Param2 = ""
        Me.CboLoaiCongViec.Size = New System.Drawing.Size(664, 21)
        Me.CboLoaiCongViec.StoreName = ""
        Me.CboLoaiCongViec.TabIndex = 0
        Me.CboLoaiCongViec.Table = Nothing
        Me.CboLoaiCongViec.TextReadonly = false
        Me.CboLoaiCongViec.Value = ""
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.Controls.Add(Me.LblTieudechukyBTPN, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LblChonCV, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CboLoaiCongViec, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grdChonCongViec, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(790, 516)
        Me.TableLayoutPanel1.TabIndex = 88
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.BtnChonTatCa)
        Me.Panel1.Controls.Add(Me.BtnBoChonTatCa)
        Me.Panel1.Controls.Add(Me.BtnThucHien)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 487)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 26)
        Me.Panel1.TabIndex = 28
        '
        'FrmChonCongViec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 516)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = false
        Me.MinimumSize = New System.Drawing.Size(798, 550)
        Me.Name = "FrmChonCongViec"
        Me.Text = "Chọn công việc cho bảo trì phòng ngừa"
        CType(Me.grdChonCongViec,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.Panel1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents CboLoaiCongViec As Commons.UtcComboBox
    Friend WithEvents LblTieudechukyBTPN As System.Windows.Forms.Label
    Friend WithEvents LblChonCV As System.Windows.Forms.Label
    Friend WithEvents grdChonCongViec As System.Windows.Forms.DataGridView
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnThucHien As System.Windows.Forms.Button
    Friend WithEvents BtnBoChonTatCa As System.Windows.Forms.Button
    Friend WithEvents BtnChonTatCa As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
