<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTinhGiaLai
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.lblThang = New DevExpress.XtraEditors.LabelControl()
        Me.dtThang = New ReportMain.MMonthYearEdit()
        Me.prbIN = New DevExpress.XtraEditors.ProgressBarControl()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dtThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtThang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdThucHien, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdThoat, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblThang, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtThang, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.prbIN, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(444, 123)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'cmdThucHien
        '
        Me.cmdThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThucHien.Image = Global.MReportVB.My.Resources.Resources.btnthuchien
        Me.cmdThucHien.Location = New System.Drawing.Point(227, 80)
        Me.cmdThucHien.LookAndFeel.SkinName = "Blue"
        Me.cmdThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdThucHien.Name = "cmdThucHien"
        Me.cmdThucHien.Size = New System.Drawing.Size(104, 32)
        Me.cmdThucHien.TabIndex = 0
        Me.cmdThucHien.Text = "cmdThucHien"
        '
        'cmdThoat
        '
        Me.cmdThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThoat.Image = Global.MReportVB.My.Resources.Resources.btnthoat
        Me.cmdThoat.Location = New System.Drawing.Point(337, 80)
        Me.cmdThoat.LookAndFeel.SkinName = "Blue"
        Me.cmdThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(104, 32)
        Me.cmdThoat.TabIndex = 1
        Me.cmdThoat.Text = "cmdThoat"
        '
        'lblThang
        '
        Me.lblThang.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblThang.Location = New System.Drawing.Point(113, 18)
        Me.lblThang.Name = "lblThang"
        Me.lblThang.Size = New System.Drawing.Size(84, 19)
        Me.lblThang.TabIndex = 1
        Me.lblThang.Text = "lblThang"
        '
        'dtThang
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtThang, 2)
        Me.dtThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtThang.EditValue = Nothing
        Me.dtThang.Location = New System.Drawing.Point(203, 18)
        Me.dtThang.MMonthYear = False
        Me.dtThang.Name = "dtThang"
        Me.dtThang.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.dtThang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtThang.Properties.DisplayFormat.FormatString = "MM/yyyy"
        Me.dtThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtThang.Properties.EditFormat.FormatString = "MM/yyyy"
        Me.dtThang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtThang.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtThang.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtThang.Properties.Mask.EditMask = "MM/yyyy"
        Me.dtThang.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtThang.Size = New System.Drawing.Size(128, 20)
        Me.dtThang.TabIndex = 0
        '
        'prbIN
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.prbIN, 5)
        Me.prbIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prbIN.Location = New System.Drawing.Point(3, 58)
        Me.prbIN.Name = "prbIN"
        Me.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.prbIN.Properties.LookAndFeel.SkinName = "Blue"
        Me.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.prbIN.Properties.Maximum = 0
        Me.prbIN.Properties.Step = 1
        Me.prbIN.Size = New System.Drawing.Size(438, 16)
        Me.prbIN.TabIndex = 15
        '
        'frmTinhGiaLai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 123)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmTinhGiaLai"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTinhGiaLai"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dtThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtThang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblThang As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtThang As ReportMain.MMonthYearEdit
    Private WithEvents prbIN As DevExpress.XtraEditors.ProgressBarControl
End Class
