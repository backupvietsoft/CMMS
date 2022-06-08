<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDanhsach_NCC
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboLoaiTB = New System.Windows.Forms.ComboBox()
        Me.lblLoaithietbi = New System.Windows.Forms.Label()
        Me.cboNoisudung = New System.Windows.Forms.ComboBox()
        Me.lblNoiSD = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiTB, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaithietbi, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNoisudung, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNoiSD, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(415, 290)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cboLoaiTB
        '
        Me.cboLoaiTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaiTB.FormattingEnabled = True
        Me.cboLoaiTB.Location = New System.Drawing.Point(114, 3)
        Me.cboLoaiTB.Name = "cboLoaiTB"
        Me.cboLoaiTB.Size = New System.Drawing.Size(89, 21)
        Me.cboLoaiTB.TabIndex = 19
        Me.cboLoaiTB.Visible = False
        '
        'lblLoaithietbi
        '
        Me.lblLoaithietbi.AutoSize = True
        Me.lblLoaithietbi.Location = New System.Drawing.Point(65, 0)
        Me.lblLoaithietbi.Name = "lblLoaithietbi"
        Me.lblLoaithietbi.Size = New System.Drawing.Size(40, 25)
        Me.lblLoaithietbi.TabIndex = 1
        Me.lblLoaithietbi.Text = "Loại thiết bị"
        Me.lblLoaithietbi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLoaithietbi.Visible = False
        '
        'cboNoisudung
        '
        Me.cboNoisudung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNoisudung.FormattingEnabled = True
        Me.cboNoisudung.Location = New System.Drawing.Point(258, 3)
        Me.cboNoisudung.Name = "cboNoisudung"
        Me.cboNoisudung.Size = New System.Drawing.Size(89, 21)
        Me.cboNoisudung.TabIndex = 20
        Me.cboNoisudung.Visible = False
        '
        'lblNoiSD
        '
        Me.lblNoiSD.AutoSize = True
        Me.lblNoiSD.Location = New System.Drawing.Point(209, 0)
        Me.lblNoiSD.Name = "lblNoiSD"
        Me.lblNoiSD.Size = New System.Drawing.Size(40, 25)
        Me.lblNoiSD.TabIndex = 1
        Me.lblNoiSD.Text = "Nơi sử dụng"
        Me.lblNoiSD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNoiSD.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 251)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(409, 36)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(192, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 18
        Me.btnThucHien.Text = "Thực hiện"
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(302, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"
        '
        'frmrptDanhsach_NCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptDanhsach_NCC"
        Me.Size = New System.Drawing.Size(415, 290)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLoaithietbi As System.Windows.Forms.Label
    Friend WithEvents lblNoiSD As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboLoaiTB As System.Windows.Forms.ComboBox
    Friend WithEvents cboNoisudung As System.Windows.Forms.ComboBox
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
