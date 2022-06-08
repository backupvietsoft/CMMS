<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDanhSachNoiLapDatVaBPCPCuaThietBi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptDanhSachNoiLapDatVaBPCPCuaThietBi))
        Me.lblThietbi = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.cboThietBi = New System.Windows.Forms.ComboBox
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblThietbi
        '
        Me.lblThietbi.AutoSize = True
        Me.lblThietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblThietbi.Location = New System.Drawing.Point(3, 0)
        Me.lblThietbi.Name = "lblThietbi"
        Me.lblThietbi.Size = New System.Drawing.Size(42, 26)
        Me.lblThietbi.TabIndex = 1
        Me.lblThietbi.Text = "Thiết bị"
        Me.lblThietbi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblThietbi, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboThietBi, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(526, 434)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'cboThietBi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboThietBi, 2)
        Me.cboThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboThietBi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboThietBi.FormattingEnabled = True
        Me.cboThietBi.Location = New System.Drawing.Point(51, 3)
        Me.cboThietBi.Name = "cboThietBi"
        Me.cboThietBi.Size = New System.Drawing.Size(472, 21)
        Me.cboThietBi.TabIndex = 5
        '
        'btnThucHien
        '


        Me.TableLayoutPanel1.SetColumnSpan(Me.btnThucHien, 2)
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(326, 407)

        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Size = New System.Drawing.Size(90, 24)
        Me.btnThucHien.TabIndex = 19
        Me.btnThucHien.Text = "Thực hiện"


        '
        'btnThoat
        '


        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(429, 407)

        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Size = New System.Drawing.Size(87, 24)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"


        '
        'frmrptDanhSachNoiLapDatVaBPCPCuaThietBi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptDanhSachNoiLapDatVaBPCPCuaThietBi"
        Me.Size = New System.Drawing.Size(526, 434)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblThietbi As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboThietBi As System.Windows.Forms.ComboBox
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
