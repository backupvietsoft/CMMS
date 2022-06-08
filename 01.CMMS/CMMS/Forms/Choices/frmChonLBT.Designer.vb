<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonLBT
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
        Me.cboLBT = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnExcute = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblLBT = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNV = New DevExpress.XtraEditors.LabelControl()
        Me.cboNguoiLap = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblNGS = New DevExpress.XtraEditors.LabelControl()
        Me.cboNguoiGS = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblTNgayBDKH = New DevExpress.XtraEditors.LabelControl()
        Me.lblDNgayBDKH = New DevExpress.XtraEditors.LabelControl()
        Me.datNgayBDKH = New DevExpress.XtraEditors.DateEdit()
        Me.datNgayKTKH = New DevExpress.XtraEditors.DateEdit()
        CType(Me.cboLBT.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.cboNguoiLap.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cboNguoiGS.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.datNgayBDKH.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.datNgayBDKH.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.datNgayKTKH.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.datNgayKTKH.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cboLBT
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboLBT, 4)
        Me.cboLBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLBT.EditValue = ""
        Me.cboLBT.Location = New System.Drawing.Point(123, 3)
        Me.cboLBT.Name = "cboLBT"
        Me.cboLBT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLBT.Properties.NullText = ""
        Me.cboLBT.Size = New System.Drawing.Size(316, 20)
        Me.cboLBT.TabIndex = 25
        '
        'btnExcute
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnExcute, 2)
        Me.btnExcute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExcute.Location = New System.Drawing.Point(205, 103)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(114, 30)
        Me.btnExcute.TabIndex = 26
        Me.btnExcute.Text = "btnExcute"
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancel.Location = New System.Drawing.Point(325, 103)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(114, 30)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Text = "btnCancel"
        '
        'lblLBT
        '
        Me.lblLBT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblLBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLBT.Location = New System.Drawing.Point(3, 3)
        Me.lblLBT.Name = "lblLBT"
        Me.lblLBT.Size = New System.Drawing.Size(114, 19)
        Me.lblLBT.TabIndex = 28
        Me.lblLBT.Text = "lblLBT"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblLBT, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExcute, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLBT, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNV, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNguoiLap, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNGS, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNguoiGS, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTNgayBDKH, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDNgayBDKH, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.datNgayBDKH, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.datNgayKTKH, 4, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(442, 136)
        Me.TableLayoutPanel1.TabIndex = 29
        '
        'lblNV
        '
        Me.lblNV.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblNV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNV.Location = New System.Drawing.Point(3, 28)
        Me.lblNV.Name = "lblNV"
        Me.lblNV.Size = New System.Drawing.Size(114, 19)
        Me.lblNV.TabIndex = 28
        Me.lblNV.Text = "lblNV"
        '
        'cboNguoiLap
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNguoiLap, 4)
        Me.cboNguoiLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNguoiLap.EditValue = ""
        Me.cboNguoiLap.Location = New System.Drawing.Point(123, 28)
        Me.cboNguoiLap.Name = "cboNguoiLap"
        Me.cboNguoiLap.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNguoiLap.Properties.NullText = ""
        Me.cboNguoiLap.Size = New System.Drawing.Size(316, 20)
        Me.cboNguoiLap.TabIndex = 25
        '
        'lblNGS
        '
        Me.lblNGS.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblNGS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNGS.Location = New System.Drawing.Point(3, 53)
        Me.lblNGS.Name = "lblNGS"
        Me.lblNGS.Size = New System.Drawing.Size(114, 19)
        Me.lblNGS.TabIndex = 28
        Me.lblNGS.Text = "lblNGS"
        '
        'cboNguoiGS
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNguoiGS, 4)
        Me.cboNguoiGS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNguoiGS.EditValue = ""
        Me.cboNguoiGS.Location = New System.Drawing.Point(123, 53)
        Me.cboNguoiGS.Name = "cboNguoiGS"
        Me.cboNguoiGS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNguoiGS.Properties.NullText = ""
        Me.cboNguoiGS.Size = New System.Drawing.Size(316, 20)
        Me.cboNguoiGS.TabIndex = 25
        '
        'lblTNgayBDKH
        '
        Me.lblTNgayBDKH.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTNgayBDKH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTNgayBDKH.Location = New System.Drawing.Point(3, 78)
        Me.lblTNgayBDKH.Name = "lblTNgayBDKH"
        Me.lblTNgayBDKH.Size = New System.Drawing.Size(114, 19)
        Me.lblTNgayBDKH.TabIndex = 28
        Me.lblTNgayBDKH.Text = "lblTNgayBDKH"
        '
        'lblDNgayBDKH
        '
        Me.lblDNgayBDKH.Appearance.Options.UseTextOptions = true
        Me.lblDNgayBDKH.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblDNgayBDKH.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDNgayBDKH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDNgayBDKH.Location = New System.Drawing.Point(235, 78)
        Me.lblDNgayBDKH.Name = "lblDNgayBDKH"
        Me.lblDNgayBDKH.Size = New System.Drawing.Size(84, 19)
        Me.lblDNgayBDKH.TabIndex = 28
        Me.lblDNgayBDKH.Text = "lblDNgayBDKH"
        '
        'datNgayBDKH
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.datNgayBDKH, 2)
        Me.datNgayBDKH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datNgayBDKH.EditValue = Nothing
        Me.datNgayBDKH.Location = New System.Drawing.Point(123, 78)
        Me.datNgayBDKH.Name = "datNgayBDKH"
        Me.datNgayBDKH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datNgayBDKH.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datNgayBDKH.Size = New System.Drawing.Size(106, 20)
        Me.datNgayBDKH.TabIndex = 29
        '
        'datNgayKTKH
        '
        Me.datNgayKTKH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datNgayKTKH.EditValue = Nothing
        Me.datNgayKTKH.Location = New System.Drawing.Point(325, 78)
        Me.datNgayKTKH.Name = "datNgayKTKH"
        Me.datNgayKTKH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datNgayKTKH.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datNgayKTKH.Size = New System.Drawing.Size(114, 20)
        Me.datNgayKTKH.TabIndex = 29
        '
        'frmChonLBT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 136)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = false
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmChonLBT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmChonLBT"
        CType(Me.cboLBT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        CType(Me.cboNguoiLap.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboNguoiGS.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.datNgayBDKH.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.datNgayBDKH.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.datNgayKTKH.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.datNgayKTKH.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents cboLBT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnExcute As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblLBT As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblNV As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboNguoiLap As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblNGS As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboNguoiGS As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblTNgayBDKH As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDNgayBDKH As DevExpress.XtraEditors.LabelControl
    Friend WithEvents datNgayBDKH As DevExpress.XtraEditors.DateEdit
    Friend WithEvents datNgayKTKH As DevExpress.XtraEditors.DateEdit
End Class
