<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlDMTBDL
    Inherits System.Windows.Forms.UserControl

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblLoaiThietBi = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cmbLoaiMay = New DevExpress.XtraEditors.LookUpEdit
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btnSelect = New DevExpress.XtraEditors.SimpleButton
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.btnUnSelect = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.cmbLoaiMay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GridControl1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(604, 432)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblLoaiThietBi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(104, 22)
        Me.Panel1.TabIndex = 0
        '
        'lblLoaiThietBi
        '
        Me.lblLoaiThietBi.AutoSize = True
        Me.lblLoaiThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiThietBi.Location = New System.Drawing.Point(0, 0)
        Me.lblLoaiThietBi.Name = "lblLoaiThietBi"
        Me.lblLoaiThietBi.Size = New System.Drawing.Size(61, 13)
        Me.lblLoaiThietBi.TabIndex = 2
        Me.lblLoaiThietBi.Text = "Loại thiết bị"
        '
        'Panel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.cmbLoaiMay)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(113, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(488, 22)
        Me.Panel2.TabIndex = 1
        '
        'cmbLoaiMay
        '
        Me.cmbLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLoaiMay.Location = New System.Drawing.Point(0, 0)
        Me.cmbLoaiMay.Name = "cmbLoaiMay"
        Me.cmbLoaiMay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmbLoaiMay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbLoaiMay.Properties.DropDownRows = 20
        Me.cmbLoaiMay.Properties.NullText = ""
        Me.cmbLoaiMay.Properties.ShowFooter = False
        Me.cmbLoaiMay.Properties.ShowHeader = False
        Me.cmbLoaiMay.Size = New System.Drawing.Size(488, 20)
        Me.cmbLoaiMay.TabIndex = 0
        '
        'GridControl1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GridControl1, 3)
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(3, 31)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(598, 361)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnSelect)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 398)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(104, 31)
        Me.Panel3.TabIndex = 3
        '
        'btnSelect
        '
        Me.btnSelect.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSelect.Location = New System.Drawing.Point(0, 0)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(103, 31)
        Me.btnSelect.TabIndex = 0
        Me.btnSelect.Text = "Select"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnThucHien)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(360, 398)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(241, 31)
        Me.Panel4.TabIndex = 4
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(138, 0)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(103, 31)
        Me.btnThucHien.TabIndex = 0
        Me.btnThucHien.Text = "SimpleButton1"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnUnSelect)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(113, 398)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(241, 31)
        Me.Panel5.TabIndex = 5
        '
        'btnUnSelect
        '
        Me.btnUnSelect.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnUnSelect.Location = New System.Drawing.Point(0, 0)
        Me.btnUnSelect.Name = "btnUnSelect"
        Me.btnUnSelect.Size = New System.Drawing.Size(103, 31)
        Me.btnUnSelect.TabIndex = 2
        Me.btnUnSelect.Text = "UnSelect"
        '
        'ctlDMTBDL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ctlDMTBDL"
        Me.Size = New System.Drawing.Size(604, 432)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.cmbLoaiMay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblLoaiThietBi As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbLoaiMay As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnSelect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnUnSelect As DevExpress.XtraEditors.SimpleButton

End Class
