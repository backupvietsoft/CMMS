<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.barmanager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.optBCao = New DevExpress.XtraEditors.RadioGroup()
        Me.chkLChiPhi = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.barmanager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optBCao.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLChiPhi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barmanager
        '
        Me.barmanager.MaxItemId = 0
        '
        'optBCao
        '
        Me.optBCao.EditValue = "optExcel"
        Me.optBCao.Location = New System.Drawing.Point(327, 24)
        Me.optBCao.Name = "optBCao"
        Me.optBCao.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.optBCao.Properties.Appearance.Options.UseBackColor = True
        Me.optBCao.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.optBCao.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("optAll", "optAll"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optReport", "optReport"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optExcel", "optExcel")})
        Me.optBCao.Properties.LookAndFeel.SkinName = "Blue"
        Me.optBCao.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.optBCao.Size = New System.Drawing.Size(817, 23)
        Me.optBCao.TabIndex = 37
        '
        'chkLChiPhi
        '
        Me.chkLChiPhi.Appearance.BackColor = System.Drawing.Color.White
        Me.chkLChiPhi.Appearance.Options.UseBackColor = True
        Me.chkLChiPhi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.chkLChiPhi.Items.AddRange(New DevExpress.XtraEditors.Controls.CheckedListBoxItem() {New DevExpress.XtraEditors.Controls.CheckedListBoxItem(Nothing, "chkPhuTung", System.Windows.Forms.CheckState.Checked), New DevExpress.XtraEditors.Controls.CheckedListBoxItem(Nothing, "chkVatTu", System.Windows.Forms.CheckState.Checked), New DevExpress.XtraEditors.Controls.CheckedListBoxItem(Nothing, "chkNhanCong", System.Windows.Forms.CheckState.Checked), New DevExpress.XtraEditors.Controls.CheckedListBoxItem(Nothing, "chkDichVu", System.Windows.Forms.CheckState.Checked), New DevExpress.XtraEditors.Controls.CheckedListBoxItem(Nothing, "chkCPKhac", System.Windows.Forms.CheckState.Checked)})
        Me.chkLChiPhi.Location = New System.Drawing.Point(37, 12)
        Me.chkLChiPhi.LookAndFeel.SkinName = "Blue"
        Me.chkLChiPhi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.chkLChiPhi.MultiColumn = True
        Me.chkLChiPhi.Name = "chkLChiPhi"
        Me.chkLChiPhi.Size = New System.Drawing.Size(245, 79)
        Me.chkLChiPhi.TabIndex = 38
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GridControl1.Location = New System.Drawing.Point(0, 97)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.barmanager
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1185, 343)
        Me.GridControl1.TabIndex = 39
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1185, 440)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.chkLChiPhi)
        Me.Controls.Add(Me.optBCao)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.barmanager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optBCao.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLChiPhi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents barmanager As DevExpress.XtraBars.BarManager
    Private WithEvents optBCao As DevExpress.XtraEditors.RadioGroup
    Private WithEvents chkLChiPhi As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
