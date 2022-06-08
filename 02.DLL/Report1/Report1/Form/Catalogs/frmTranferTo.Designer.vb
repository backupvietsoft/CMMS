<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTranferTo
    'Inherits System.Windows.Forms.Form
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtTranferTo = New DevExpress.XtraEditors.TextEdit()
        Me.lblTieudeTranferTo = New System.Windows.Forms.Label()
        Me.lblTenTranferTo = New System.Windows.Forms.Label()
        Me.grpTranferTo = New System.Windows.Forms.GroupBox()
        Me.grdTranferTo = New DevExpress.XtraGrid.GridControl()
        Me.grvTranferTo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSTT = New System.Windows.Forms.TextBox()
        Me.BtnKhongGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.txtTranferTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTranferTo.SuspendLayout()
        CType(Me.grdTranferTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvTranferTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtTranferTo, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieudeTranferTo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTenTranferTo, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grpTranferTo, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtTranferTo
        '
        Me.txtTranferTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTranferTo.EditValue = ""
        Me.txtTranferTo.Location = New System.Drawing.Point(311, 43)
        Me.txtTranferTo.Name = "txtTranferTo"
        Me.txtTranferTo.Size = New System.Drawing.Size(436, 20)
        Me.txtTranferTo.TabIndex = 63
        '
        'lblTieudeTranferTo
        '
        Me.lblTieudeTranferTo.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieudeTranferTo, 4)
        Me.lblTieudeTranferTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieudeTranferTo.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTieudeTranferTo.ForeColor = System.Drawing.Color.Navy
        Me.lblTieudeTranferTo.Location = New System.Drawing.Point(1, 0)
        Me.lblTieudeTranferTo.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblTieudeTranferTo.Name = "lblTieudeTranferTo"
        Me.lblTieudeTranferTo.Size = New System.Drawing.Size(882, 40)
        Me.lblTieudeTranferTo.TabIndex = 0
        Me.lblTieudeTranferTo.Text = "lblTieudeTranferTo"
        Me.lblTieudeTranferTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTenTranferTo
        '
        Me.lblTenTranferTo.AutoSize = True
        Me.lblTenTranferTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenTranferTo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenTranferTo.ForeColor = System.Drawing.Color.Black
        Me.lblTenTranferTo.Location = New System.Drawing.Point(135, 40)
        Me.lblTenTranferTo.Name = "lblTenTranferTo"
        Me.lblTenTranferTo.Size = New System.Drawing.Size(170, 25)
        Me.lblTenTranferTo.TabIndex = 6
        Me.lblTenTranferTo.Text = "lblTenTranferTo"
        Me.lblTenTranferTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpTranferTo
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpTranferTo, 4)
        Me.grpTranferTo.Controls.Add(Me.grdTranferTo)
        Me.grpTranferTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTranferTo.Location = New System.Drawing.Point(1, 74)
        Me.grpTranferTo.Margin = New System.Windows.Forms.Padding(1)
        Me.grpTranferTo.Name = "grpTranferTo"
        Me.grpTranferTo.Padding = New System.Windows.Forms.Padding(1)
        Me.grpTranferTo.Size = New System.Drawing.Size(882, 446)
        Me.grpTranferTo.TabIndex = 8
        Me.grpTranferTo.TabStop = False
        Me.grpTranferTo.Text = "grpTranferTo"
        '
        'grdTranferTo
        '
        Me.grdTranferTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTranferTo.Location = New System.Drawing.Point(1, 15)
        Me.grdTranferTo.LookAndFeel.SkinName = "Blue"
        Me.grdTranferTo.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdTranferTo.MainView = Me.grvTranferTo
        Me.grdTranferTo.Name = "grdTranferTo"
        Me.grdTranferTo.Size = New System.Drawing.Size(880, 430)
        Me.grdTranferTo.TabIndex = 3
        Me.grdTranferTo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvTranferTo})
        '
        'grvTranferTo
        '
        Me.grvTranferTo.GridControl = Me.grdTranferTo
        Me.grvTranferTo.Name = "grvTranferTo"
        Me.grvTranferTo.OptionsCustomization.AllowGroup = False
        Me.grvTranferTo.OptionsView.ShowGroupPanel = False
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Controls.Add(Me.txtSTT)
        Me.Panel1.Controls.Add(Me.BtnKhongGhi)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 522)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(882, 38)
        Me.Panel1.TabIndex = 9
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Location = New System.Drawing.Point(460, 5)
        Me.BtnThem.LookAndFeel.SkinName = "Blue"
        Me.BtnThem.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 11
        Me.BtnThem.Text = "Thêm"
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Location = New System.Drawing.Point(565, 5)
        Me.BtnSua.LookAndFeel.SkinName = "Blue"
        Me.BtnSua.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 10
        Me.BtnSua.Text = "Sửa"
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Appearance.Options.UseFont = True
        Me.btnThoat.Location = New System.Drawing.Point(775, 5)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 8
        Me.btnThoat.Text = "Thoát"
        '
        'txtSTT
        '
        Me.txtSTT.Location = New System.Drawing.Point(1, 2)
        Me.txtSTT.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSTT.Name = "txtSTT"
        Me.txtSTT.Size = New System.Drawing.Size(40, 21)
        Me.txtSTT.TabIndex = 6
        Me.txtSTT.Visible = False
        '
        'BtnKhongGhi
        '
        Me.BtnKhongGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongGhi.Appearance.Options.UseFont = True
        Me.BtnKhongGhi.Location = New System.Drawing.Point(775, 5)
        Me.BtnKhongGhi.LookAndFeel.SkinName = "Blue"
        Me.BtnKhongGhi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnKhongGhi.Name = "BtnKhongGhi"
        Me.BtnKhongGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongGhi.TabIndex = 12
        Me.BtnKhongGhi.Text = "Không Ghi"
        Me.BtnKhongGhi.Visible = False
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Location = New System.Drawing.Point(670, 5)
        Me.BtnXoa.LookAndFeel.SkinName = "Blue"
        Me.BtnXoa.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 9
        Me.BtnXoa.Text = "Xóa"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Location = New System.Drawing.Point(670, 5)
        Me.BtnGhi.LookAndFeel.SkinName = "Blue"
        Me.BtnGhi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 13
        Me.BtnGhi.Text = "Ghi"
        Me.BtnGhi.Visible = False
        '
        'frmTranferTo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "frmTranferTo"
        Me.Text = "frmTranferTo"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.txtTranferTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTranferTo.ResumeLayout(False)
        CType(Me.grdTranferTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvTranferTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblTieudeTranferTo As Label
    Friend WithEvents lblTenTranferTo As Label
    Friend WithEvents grpTranferTo As GroupBox
    Friend WithEvents Panel1 As Panel
    Private WithEvents txtTranferTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSTT As TextBox
    Private WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnKhongGhi As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Private WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Private WithEvents grdTranferTo As DevExpress.XtraGrid.GridControl
    Private WithEvents grvTranferTo As DevExpress.XtraGrid.Views.Grid.GridView
End Class
