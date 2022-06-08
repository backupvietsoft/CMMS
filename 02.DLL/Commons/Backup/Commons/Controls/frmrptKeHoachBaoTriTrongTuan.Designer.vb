<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptKeHoachBaoTriTrongTuan
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.btnExecute = New DevExpress.XtraEditors.SimpleButton
        Me.lblTuannam = New System.Windows.Forms.Label
        Me.cboTuanNam = New DevExpress.XtraEditors.LookUpEdit
        Me.lblNhaxuong = New System.Windows.Forms.Label
        Me.cboNhaXuongPBT = New DevExpress.XtraEditors.LookUpEdit
        Me.lblLoaiTB = New System.Windows.Forms.Label
        Me.cboLoaithietbi3 = New DevExpress.XtraEditors.LookUpEdit
        Me.lblLoaiCV = New System.Windows.Forms.Label
        Me.cboLoai_CV = New DevExpress.XtraEditors.LookUpEdit
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.cboTuanNam.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNhaXuongPBT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLoaithietbi3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLoai_CV.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTuannam, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTuanNam, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiCV, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoai_CV, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaithietbi3, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiTB, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaXuongPBT, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNhaxuong, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(896, 456)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnExecute, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 417)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(890, 36)
        Me.TableLayoutPanel2.TabIndex = 34
        '
        'btnThoat
        '
        Me.btnThoat.Location = New System.Drawing.Point(783, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 12
        Me.btnThoat.Text = "Thoát"
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(673, 3)
        Me.btnExecute.LookAndFeel.SkinName = "Blue"
        Me.btnExecute.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(104, 30)
        Me.btnExecute.TabIndex = 11
        Me.btnExecute.Text = "Thực hiện"
        '
        'lblTuannam
        '
        Me.lblTuannam.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTuannam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuannam.Location = New System.Drawing.Point(137, 15)
        Me.lblTuannam.Name = "lblTuannam"
        Me.lblTuannam.Size = New System.Drawing.Size(101, 25)
        Me.lblTuannam.TabIndex = 3
        Me.lblTuannam.Text = "Tuần năm"
        Me.lblTuannam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTuanNam
        '
        Me.cboTuanNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTuanNam.Location = New System.Drawing.Point(244, 18)
        Me.cboTuanNam.Name = "cboTuanNam"
        Me.cboTuanNam.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTuanNam.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboTuanNam.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboTuanNam.Properties.NullText = ""
        Me.cboTuanNam.Size = New System.Drawing.Size(200, 20)
        Me.cboTuanNam.TabIndex = 36
        '
        'lblNhaxuong
        '
        Me.lblNhaxuong.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhaxuong.Location = New System.Drawing.Point(137, 40)
        Me.lblNhaxuong.Name = "lblNhaxuong"
        Me.lblNhaxuong.Size = New System.Drawing.Size(101, 25)
        Me.lblNhaxuong.TabIndex = 2
        Me.lblNhaxuong.Text = "Nhà xưởng"
        Me.lblNhaxuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNhaXuongPBT
        '
        Me.cboNhaXuongPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaXuongPBT.Location = New System.Drawing.Point(244, 43)
        Me.cboNhaXuongPBT.Name = "cboNhaXuongPBT"
        Me.cboNhaXuongPBT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNhaXuongPBT.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboNhaXuongPBT.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboNhaXuongPBT.Properties.NullText = ""
        Me.cboNhaXuongPBT.Size = New System.Drawing.Size(200, 20)
        Me.cboNhaXuongPBT.TabIndex = 35
        '
        'lblLoaiTB
        '
        Me.lblLoaiTB.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiTB.Location = New System.Drawing.Point(450, 40)
        Me.lblLoaiTB.Name = "lblLoaiTB"
        Me.lblLoaiTB.Size = New System.Drawing.Size(101, 25)
        Me.lblLoaiTB.TabIndex = 1
        Me.lblLoaiTB.Text = "Loại thiết bị"
        Me.lblLoaiTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLoaithietbi3
        '
        Me.cboLoaithietbi3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaithietbi3.Location = New System.Drawing.Point(557, 43)
        Me.cboLoaithietbi3.Name = "cboLoaithietbi3"
        Me.cboLoaithietbi3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLoaithietbi3.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLoaithietbi3.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLoaithietbi3.Properties.NullText = ""
        Me.cboLoaithietbi3.Size = New System.Drawing.Size(200, 20)
        Me.cboLoaithietbi3.TabIndex = 36
        '
        'lblLoaiCV
        '
        Me.lblLoaiCV.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLoaiCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiCV.Location = New System.Drawing.Point(450, 15)
        Me.lblLoaiCV.Name = "lblLoaiCV"
        Me.lblLoaiCV.Size = New System.Drawing.Size(101, 25)
        Me.lblLoaiCV.TabIndex = 0
        Me.lblLoaiCV.Text = "Loại công việc"
        Me.lblLoaiCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLoai_CV
        '
        Me.cboLoai_CV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoai_CV.Location = New System.Drawing.Point(557, 18)
        Me.cboLoai_CV.Name = "cboLoai_CV"
        Me.cboLoai_CV.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLoai_CV.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLoai_CV.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLoai_CV.Properties.NullText = ""
        Me.cboLoai_CV.Size = New System.Drawing.Size(200, 20)
        Me.cboLoai_CV.TabIndex = 36
        '
        'frmrptKeHoachBaoTriTrongTuan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptKeHoachBaoTriTrongTuan"
        Me.Size = New System.Drawing.Size(896, 456)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.cboTuanNam.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNhaXuongPBT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLoaithietbi3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLoai_CV.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLoaiCV As System.Windows.Forms.Label
    Friend WithEvents lblLoaiTB As System.Windows.Forms.Label
    Friend WithEvents lblNhaxuong As System.Windows.Forms.Label
    Friend WithEvents lblTuannam As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents cboTuanNam As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents cboNhaXuongPBT As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents cboLoaithietbi3 As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents cboLoai_CV As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnExecute As DevExpress.XtraEditors.SimpleButton

End Class
