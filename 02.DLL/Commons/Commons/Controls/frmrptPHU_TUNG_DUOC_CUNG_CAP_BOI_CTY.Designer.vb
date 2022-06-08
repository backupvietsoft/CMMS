<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY))
        Me.lblDSVT = New System.Windows.Forms.Label()
        Me.cboVattu = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdChung = New DevExpress.XtraGrid.GridControl()
        Me.grvChung = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDSVT
        '
        Me.lblDSVT.AutoSize = True
        Me.lblDSVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDSVT.Location = New System.Drawing.Point(66, 0)
        Me.lblDSVT.Name = "lblDSVT"
        Me.lblDSVT.Size = New System.Drawing.Size(44, 31)
        Me.lblDSVT.TabIndex = 29
        Me.lblDSVT.Text = "Nhà cung cấp"
        Me.lblDSVT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVattu
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboVattu, 3)
        Me.cboVattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboVattu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVattu.FormattingEnabled = True
        Me.cboVattu.Location = New System.Drawing.Point(116, 3)
        Me.cboVattu.Name = "cboVattu"
        Me.cboVattu.Size = New System.Drawing.Size(238, 21)
        Me.cboVattu.TabIndex = 30
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
        Me.TableLayoutPanel1.Controls.Add(Me.grdChung, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboVattu, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDSVT, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(424, 398)
        Me.TableLayoutPanel1.TabIndex = 21
        '
        'grdChung
        '
        Me.grdChung.Location = New System.Drawing.Point(3, 3)
        Me.grdChung.MainView = Me.grvChung
        Me.grdChung.Name = "grdChung"
        Me.grdChung.Size = New System.Drawing.Size(53, 25)
        Me.grdChung.TabIndex = 38
        Me.grdChung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChung})
        Me.grdChung.Visible = False
        '
        'grvChung
        '
        Me.grvChung.GridControl = Me.grdChung
        Me.grvChung.Name = "grvChung"
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 364)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(418, 31)
        Me.TableLayoutPanel2.TabIndex = 37
        '
        'btnThucHien
        '


        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(238, 0)
        
        Me.btnThucHien.Name = "btnThucHien"

        Me.btnThucHien.Size = New System.Drawing.Size(90, 31)
        Me.btnThucHien.TabIndex = 20
        Me.btnThucHien.Text = "Thực hiện"


        '
        'btnThoat
        '


        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(328, 0)
        
        Me.btnThoat.Name = "btnThoat"

        Me.btnThoat.Size = New System.Drawing.Size(90, 31)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"


        '
        'frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY"
        Me.Size = New System.Drawing.Size(424, 398)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDSVT As System.Windows.Forms.Label
    Friend WithEvents cboVattu As System.Windows.Forms.ComboBox
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdChung As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvChung As DevExpress.XtraGrid.Views.Grid.GridView
End Class
