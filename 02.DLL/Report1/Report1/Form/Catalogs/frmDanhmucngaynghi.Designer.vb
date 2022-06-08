<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhmucngaynghi
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblNgaynghi = New System.Windows.Forms.Label()
        Me.lblGhichu = New System.Windows.Forms.Label()
        Me.gbDanhsachngaynghi = New System.Windows.Forms.GroupBox()
        Me.gvDanhsach = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.txtGhichu = New System.Windows.Forms.TextBox()
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbDanhsachngaynghi.SuspendLayout()
        CType(Me.gvDanhsach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.60194!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.39806!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTitle, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNgaynghi, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGhichu, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.gbDanhsachngaynghi, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGhichu, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpNgay, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 461)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTitle, 2)
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.Navy
        Me.lblTitle.Location = New System.Drawing.Point(3, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(728, 38)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Ngày nghỉ lễ"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNgaynghi
        '
        Me.lblNgaynghi.AutoSize = True
        Me.lblNgaynghi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgaynghi.Location = New System.Drawing.Point(3, 38)
        Me.lblNgaynghi.Name = "lblNgaynghi"
        Me.lblNgaynghi.Size = New System.Drawing.Size(189, 25)
        Me.lblNgaynghi.TabIndex = 0
        Me.lblNgaynghi.Text = "Ngày"
        Me.lblNgaynghi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGhichu
        '
        Me.lblGhichu.AutoSize = True
        Me.lblGhichu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGhichu.Location = New System.Drawing.Point(3, 63)
        Me.lblGhichu.Name = "lblGhichu"
        Me.lblGhichu.Size = New System.Drawing.Size(189, 61)
        Me.lblGhichu.TabIndex = 0
        Me.lblGhichu.Text = "Ghi chú"
        Me.lblGhichu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbDanhsachngaynghi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gbDanhsachngaynghi, 2)
        Me.gbDanhsachngaynghi.Controls.Add(Me.gvDanhsach)
        Me.gbDanhsachngaynghi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDanhsachngaynghi.Location = New System.Drawing.Point(3, 127)
        Me.gbDanhsachngaynghi.Name = "gbDanhsachngaynghi"
        Me.gbDanhsachngaynghi.Size = New System.Drawing.Size(728, 299)
        Me.gbDanhsachngaynghi.TabIndex = 1
        Me.gbDanhsachngaynghi.TabStop = False
        Me.gbDanhsachngaynghi.Text = "Danh sách ngày nghỉ"
        '
        'gvDanhsach
        '
        Me.gvDanhsach.AllowUserToAddRows = False
        Me.gvDanhsach.AllowUserToDeleteRows = False
        Me.gvDanhsach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gvDanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvDanhsach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvDanhsach.Location = New System.Drawing.Point(3, 17)
        Me.gvDanhsach.Name = "gvDanhsach"
        Me.gvDanhsach.ReadOnly = True
        Me.gvDanhsach.Size = New System.Drawing.Size(722, 279)
        Me.gvDanhsach.TabIndex = 3
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.btnThem)
        Me.Panel1.Controls.Add(Me.btnSua)
        Me.Panel1.Controls.Add(Me.btnXoa)
        Me.Panel1.Controls.Add(Me.btnGhi)
        Me.Panel1.Controls.Add(Me.btnKhongghi)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 432)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(728, 26)
        Me.Panel1.TabIndex = 2
        '
        'btnThem
        '
        Me.btnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThem.Location = New System.Drawing.Point(278, 0)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(75, 26)
        Me.btnThem.TabIndex = 3
        Me.btnThem.Text = "Thêm"
        '
        'btnSua
        '
        Me.btnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSua.Location = New System.Drawing.Point(353, 0)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(75, 26)
        Me.btnSua.TabIndex = 2
        Me.btnSua.Text = "Sửa"
        '
        'btnXoa
        '
        Me.btnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnXoa.Location = New System.Drawing.Point(428, 0)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(75, 26)
        Me.btnXoa.TabIndex = 1
        Me.btnXoa.Text = "Xóa"
        '
        'btnGhi
        '
        Me.btnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGhi.Location = New System.Drawing.Point(503, 0)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(75, 26)
        Me.btnGhi.TabIndex = 0
        Me.btnGhi.Text = "Ghi"
        '
        'btnKhongghi
        '
        Me.btnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnKhongghi.Location = New System.Drawing.Point(578, 0)
        Me.btnKhongghi.Name = "btnKhongghi"
        Me.btnKhongghi.Size = New System.Drawing.Size(75, 26)
        Me.btnKhongghi.TabIndex = 1
        Me.btnKhongghi.Text = "Không ghi"
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(653, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 26)
        Me.btnThoat.TabIndex = 0
        Me.btnThoat.Text = "Thoát"
        '
        'txtGhichu
        '
        Me.txtGhichu.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtGhichu.Location = New System.Drawing.Point(198, 66)
        Me.txtGhichu.Multiline = True
        Me.txtGhichu.Name = "txtGhichu"
        Me.txtGhichu.Size = New System.Drawing.Size(298, 55)
        Me.txtGhichu.TabIndex = 2
        '
        'dtpNgay
        '
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgay.Location = New System.Drawing.Point(198, 41)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(127, 21)
        Me.dtpNgay.TabIndex = 1
        Me.dtpNgay.Value = New Date(2010, 3, 29, 0, 0, 0, 0)
        '
        'frmDanhmucngaynghi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDanhmucngaynghi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmDanhmucngaynghi"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gbDanhsachngaynghi.ResumeLayout(False)
        CType(Me.gvDanhsach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblNgaynghi As System.Windows.Forms.Label
    Friend WithEvents lblGhichu As System.Windows.Forms.Label
    Friend WithEvents gbDanhsachngaynghi As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gvDanhsach As System.Windows.Forms.DataGridView
    Friend WithEvents btnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtGhichu As System.Windows.Forms.TextBox
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
End Class
