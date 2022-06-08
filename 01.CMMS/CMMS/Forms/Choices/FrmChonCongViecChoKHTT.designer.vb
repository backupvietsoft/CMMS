<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonCongViecChoKHTT
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
        Me.LblTieuDe = New System.Windows.Forms.Label()
        Me.LblChonCV = New System.Windows.Forms.Label()
        Me.grdChonCongViec = New System.Windows.Forms.DataGridView()
        Me.BtnThoat = New System.Windows.Forms.Button()
        Me.BtnThucHien = New System.Windows.Forms.Button()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TVw = New System.Windows.Forms.TreeView()
        Me.GrpChonBoPhan = New System.Windows.Forms.GroupBox()
        Me.GrpChonCV = New System.Windows.Forms.GroupBox()
        Me.txtGiatri = New System.Windows.Forms.TextBox()
        Me.lblTimkiem = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnIn = New System.Windows.Forms.Button()
        Me.btnThemCV = New System.Windows.Forms.Button()
        Me.BtnBoChonTatCa = New System.Windows.Forms.Button()
        Me.BtnChonTatCa = New System.Windows.Forms.Button()
        Me.CboLoaiCongViec = New Commons.UtcComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.grdChonCongViec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpChonBoPhan.SuspendLayout()
        Me.GrpChonCV.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTieuDe
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.LblTieuDe, 4)
        Me.LblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTieuDe.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblTieuDe.Location = New System.Drawing.Point(3, 0)
        Me.LblTieuDe.Name = "LblTieuDe"
        Me.LblTieuDe.Size = New System.Drawing.Size(946, 35)
        Me.LblTieuDe.TabIndex = 25
        Me.LblTieuDe.Text = "CHỌN CÔNG VIỆC CHO KẾ HOẠCH TỔNG THỂ "
        Me.LblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTieuDe.UseCompatibleTextRendering = True
        '
        'LblChonCV
        '
        Me.LblChonCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblChonCV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChonCV.Location = New System.Drawing.Point(3, 35)
        Me.LblChonCV.Name = "LblChonCV"
        Me.LblChonCV.Size = New System.Drawing.Size(114, 28)
        Me.LblChonCV.TabIndex = 26
        Me.LblChonCV.Text = "Loại công việc"
        Me.LblChonCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdChonCongViec
        '
        Me.grdChonCongViec.AllowUserToAddRows = False
        Me.grdChonCongViec.AllowUserToDeleteRows = False
        Me.grdChonCongViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdChonCongViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdChonCongViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdChonCongViec.Location = New System.Drawing.Point(3, 17)
        Me.grdChonCongViec.Name = "grdChonCongViec"
        Me.grdChonCongViec.RowHeadersWidth = 25
        Me.grdChonCongViec.Size = New System.Drawing.Size(556, 440)
        Me.grdChonCongViec.TabIndex = 27
        '
        'BtnThoat
        '
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.ForeColor = System.Drawing.Color.Red
        Me.BtnThoat.Location = New System.Drawing.Point(472, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(90, 26)
        Me.BtnThoat.TabIndex = 85
        Me.BtnThoat.Text = "Thoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnThucHien
        '
        Me.BtnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThucHien.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThucHien.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnThucHien.Location = New System.Drawing.Point(386, 0)
        Me.BtnThucHien.Name = "BtnThucHien"
        Me.BtnThucHien.Size = New System.Drawing.Size(86, 26)
        Me.BtnThucHien.TabIndex = 84
        Me.BtnThucHien.Text = "Thực hiện"
        Me.BtnThucHien.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TVw
        '
        Me.TVw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TVw.HideSelection = False
        Me.TVw.Location = New System.Drawing.Point(3, 17)
        Me.TVw.Name = "TVw"
        Me.TVw.Size = New System.Drawing.Size(372, 440)
        Me.TVw.TabIndex = 88
        '
        'GrpChonBoPhan
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpChonBoPhan, 2)
        Me.GrpChonBoPhan.Controls.Add(Me.TVw)
        Me.GrpChonBoPhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpChonBoPhan.ForeColor = System.Drawing.Color.Maroon
        Me.GrpChonBoPhan.Location = New System.Drawing.Point(3, 66)
        Me.GrpChonBoPhan.Name = "GrpChonBoPhan"
        Me.GrpChonBoPhan.Size = New System.Drawing.Size(378, 460)
        Me.GrpChonBoPhan.TabIndex = 89
        Me.GrpChonBoPhan.TabStop = False
        Me.GrpChonBoPhan.Text = "Chọn bộ phận "
        '
        'GrpChonCV
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpChonCV, 2)
        Me.GrpChonCV.Controls.Add(Me.grdChonCongViec)
        Me.GrpChonCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpChonCV.ForeColor = System.Drawing.Color.Maroon
        Me.GrpChonCV.Location = New System.Drawing.Point(387, 66)
        Me.GrpChonCV.Name = "GrpChonCV"
        Me.GrpChonCV.Size = New System.Drawing.Size(562, 460)
        Me.GrpChonCV.TabIndex = 90
        Me.GrpChonCV.TabStop = False
        Me.GrpChonCV.Text = "Chọn công việc"
        '
        'txtGiatri
        '
        Me.txtGiatri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGiatri.Location = New System.Drawing.Point(71, 0)
        Me.txtGiatri.Multiline = True
        Me.txtGiatri.Name = "txtGiatri"
        Me.txtGiatri.Size = New System.Drawing.Size(307, 26)
        Me.txtGiatri.TabIndex = 92
        Me.txtGiatri.Visible = False
        '
        'lblTimkiem
        '
        Me.lblTimkiem.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTimkiem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimkiem.Location = New System.Drawing.Point(0, 0)
        Me.lblTimkiem.Name = "lblTimkiem"
        Me.lblTimkiem.Size = New System.Drawing.Size(71, 26)
        Me.lblTimkiem.TabIndex = 91
        Me.lblTimkiem.Text = "Tìm kiếm"
        Me.lblTimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTimkiem.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LblChonCV, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CboLoaiCongViec, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblTieuDe, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpChonBoPhan, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpChonCV, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(952, 561)
        Me.TableLayoutPanel1.TabIndex = 94
        '
        'Panel4
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.BtnIn)
        Me.Panel4.Controls.Add(Me.btnThemCV)
        Me.Panel4.Controls.Add(Me.BtnThucHien)
        Me.Panel4.Controls.Add(Me.BtnThoat)
        Me.Panel4.Controls.Add(Me.BtnBoChonTatCa)
        Me.Panel4.Controls.Add(Me.BtnChonTatCa)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(387, 532)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(562, 26)
        Me.Panel4.TabIndex = 92
        '
        'BtnIn
        '
        Me.BtnIn.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnIn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnIn.Location = New System.Drawing.Point(293, 0)
        Me.BtnIn.Name = "BtnIn"
        Me.BtnIn.Size = New System.Drawing.Size(93, 26)
        Me.BtnIn.TabIndex = 96
        Me.BtnIn.Text = "&In"
        Me.BtnIn.UseVisualStyleBackColor = True
        '
        'btnThemCV
        '
        Me.btnThemCV.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnThemCV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThemCV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnThemCV.Location = New System.Drawing.Point(183, 0)
        Me.btnThemCV.Name = "btnThemCV"
        Me.btnThemCV.Size = New System.Drawing.Size(101, 26)
        Me.btnThemCV.TabIndex = 35
        Me.btnThemCV.Text = "btnThemCV"
        Me.btnThemCV.UseVisualStyleBackColor = True
        '
        'BtnBoChonTatCa
        '
        Me.BtnBoChonTatCa.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnBoChonTatCa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBoChonTatCa.ForeColor = System.Drawing.Color.Red
        Me.BtnBoChonTatCa.Location = New System.Drawing.Point(90, 0)
        Me.BtnBoChonTatCa.Name = "BtnBoChonTatCa"
        Me.BtnBoChonTatCa.Size = New System.Drawing.Size(93, 26)
        Me.BtnBoChonTatCa.TabIndex = 95
        Me.BtnBoChonTatCa.Text = "Bỏ chọn tất cả"
        Me.BtnBoChonTatCa.UseVisualStyleBackColor = True
        '
        'BtnChonTatCa
        '
        Me.BtnChonTatCa.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnChonTatCa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChonTatCa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnChonTatCa.Location = New System.Drawing.Point(0, 0)
        Me.BtnChonTatCa.Name = "BtnChonTatCa"
        Me.BtnChonTatCa.Size = New System.Drawing.Size(90, 26)
        Me.BtnChonTatCa.TabIndex = 94
        Me.BtnChonTatCa.Text = "Chọn tất cả"
        Me.BtnChonTatCa.UseVisualStyleBackColor = True
        '
        'CboLoaiCongViec
        '
        Me.CboLoaiCongViec.AssemblyName = ""
        Me.CboLoaiCongViec.BackColor = System.Drawing.Color.White
        Me.CboLoaiCongViec.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.CboLoaiCongViec.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.CboLoaiCongViec.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.CboLoaiCongViec, 3)
        Me.CboLoaiCongViec.Display = ""
        Me.CboLoaiCongViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CboLoaiCongViec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLoaiCongViec.ErrorProviderControl = Me.ErrorProvider
        Me.CboLoaiCongViec.FormattingEnabled = True
        Me.CboLoaiCongViec.IsAll = True
        Me.CboLoaiCongViec.isInputNull = False
        Me.CboLoaiCongViec.IsNew = False
        Me.CboLoaiCongViec.IsNull = True
        Me.CboLoaiCongViec.ItemAll = "<All>"
        Me.CboLoaiCongViec.ItemNew = "...New"
        Me.CboLoaiCongViec.Location = New System.Drawing.Point(123, 38)
        Me.CboLoaiCongViec.MethodName = ""
        Me.CboLoaiCongViec.Name = "CboLoaiCongViec"
        Me.CboLoaiCongViec.Param = ""
        Me.CboLoaiCongViec.Param2 = ""
        Me.CboLoaiCongViec.Size = New System.Drawing.Size(826, 21)
        Me.CboLoaiCongViec.StoreName = ""
        Me.CboLoaiCongViec.TabIndex = 0
        Me.CboLoaiCongViec.Table = Nothing
        Me.CboLoaiCongViec.TextReadonly = False
        Me.CboLoaiCongViec.Value = ""
        '
        'Panel3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel3, 2)
        Me.Panel3.Controls.Add(Me.txtGiatri)
        Me.Panel3.Controls.Add(Me.lblTimkiem)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 532)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(378, 26)
        Me.Panel3.TabIndex = 91
        '
        'FrmChonCongViecChoKHTT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimumSize = New System.Drawing.Size(798, 550)
        Me.Name = "FrmChonCongViecChoKHTT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Chọn công việc cho kế hoạch tổng thể "
        CType(Me.grdChonCongViec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpChonBoPhan.ResumeLayout(False)
        Me.GrpChonCV.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CboLoaiCongViec As Commons.UtcComboBox
    Friend WithEvents LblTieuDe As System.Windows.Forms.Label
    Friend WithEvents LblChonCV As System.Windows.Forms.Label
    Friend WithEvents grdChonCongViec As System.Windows.Forms.DataGridView
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnThucHien As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents GrpChonCV As System.Windows.Forms.GroupBox
    Friend WithEvents GrpChonBoPhan As System.Windows.Forms.GroupBox
    Friend WithEvents TVw As System.Windows.Forms.TreeView
    Friend WithEvents txtGiatri As System.Windows.Forms.TextBox
    Friend WithEvents lblTimkiem As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThemCV As Button
    Friend WithEvents BtnChonTatCa As Button
    Friend WithEvents BtnBoChonTatCa As Button
    Friend WithEvents BtnIn As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
End Class
