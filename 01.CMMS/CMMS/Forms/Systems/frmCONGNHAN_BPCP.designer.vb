<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCONGNHAN_BPCP
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblNgaynghi = New System.Windows.Forms.Label
        Me.lblBophan = New System.Windows.Forms.Label
        Me.gbDanhsachCN_BPCP = New System.Windows.Forms.GroupBox
        Me.gvDanhsach = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtLoc = New System.Windows.Forms.TextBox
        Me.lblLoc = New System.Windows.Forms.Label
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnKhongghi = New System.Windows.Forms.Button
        Me.btnThoat = New System.Windows.Forms.Button
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.lblCongnhan = New System.Windows.Forms.Label
        Me.cbCongnhan = New System.Windows.Forms.ComboBox
        Me.cbBophan = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbDanhsachCN_BPCP.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.lblBophan, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.gbDanhsachCN_BPCP, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCongnhan, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbCongnhan, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbBophan, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(646, 414)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTitle, 2)
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTitle.Location = New System.Drawing.Point(3, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(640, 44)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Công nhân - Bộ phận chịu phí"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNgaynghi
        '
        Me.lblNgaynghi.AutoSize = True
        Me.lblNgaynghi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgaynghi.Location = New System.Drawing.Point(3, 44)
        Me.lblNgaynghi.Name = "lblNgaynghi"
        Me.lblNgaynghi.Size = New System.Drawing.Size(165, 29)
        Me.lblNgaynghi.TabIndex = 0
        Me.lblNgaynghi.Text = "Ngày"
        Me.lblNgaynghi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBophan
        '
        Me.lblBophan.AutoSize = True
        Me.lblBophan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBophan.Location = New System.Drawing.Point(3, 102)
        Me.lblBophan.Name = "lblBophan"
        Me.lblBophan.Size = New System.Drawing.Size(165, 28)
        Me.lblBophan.TabIndex = 0
        Me.lblBophan.Text = "Bộ phận chịu phí"
        Me.lblBophan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbDanhsachCN_BPCP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gbDanhsachCN_BPCP, 2)
        Me.gbDanhsachCN_BPCP.Controls.Add(Me.gvDanhsach)
        Me.gbDanhsachCN_BPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDanhsachCN_BPCP.Location = New System.Drawing.Point(3, 133)
        Me.gbDanhsachCN_BPCP.Name = "gbDanhsachCN_BPCP"
        Me.gbDanhsachCN_BPCP.Size = New System.Drawing.Size(640, 246)
        Me.gbDanhsachCN_BPCP.TabIndex = 1
        Me.gbDanhsachCN_BPCP.TabStop = False
        Me.gbDanhsachCN_BPCP.Text = "Danh sách công nhân - BPCP"
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
        Me.gvDanhsach.Size = New System.Drawing.Size(634, 226)
        Me.gvDanhsach.TabIndex = 3
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.txtLoc)
        Me.Panel1.Controls.Add(Me.lblLoc)
        Me.Panel1.Controls.Add(Me.btnThem)
        Me.Panel1.Controls.Add(Me.btnSua)
        Me.Panel1.Controls.Add(Me.btnXoa)
        Me.Panel1.Controls.Add(Me.btnGhi)
        Me.Panel1.Controls.Add(Me.btnKhongghi)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 385)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 26)
        Me.Panel1.TabIndex = 2
        '
        'txtLoc
        '
        Me.txtLoc.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtLoc.Location = New System.Drawing.Point(23, 0)
        Me.txtLoc.Name = "txtLoc"
        Me.txtLoc.Size = New System.Drawing.Size(100, 21)
        Me.txtLoc.TabIndex = 6
        '
        'lblLoc
        '
        Me.lblLoc.AutoSize = True
        Me.lblLoc.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblLoc.Location = New System.Drawing.Point(0, 0)
        Me.lblLoc.Name = "lblLoc"
        Me.lblLoc.Size = New System.Drawing.Size(23, 13)
        Me.lblLoc.TabIndex = 5
        Me.lblLoc.Text = "Loc"
        Me.lblLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnThem
        '
        Me.btnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThem.Location = New System.Drawing.Point(190, 0)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(75, 26)
        Me.btnThem.TabIndex = 3
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSua.Location = New System.Drawing.Point(265, 0)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(75, 26)
        Me.btnSua.TabIndex = 2
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnXoa.Location = New System.Drawing.Point(340, 0)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(75, 26)
        Me.btnXoa.TabIndex = 1
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGhi.Location = New System.Drawing.Point(415, 0)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(75, 26)
        Me.btnGhi.TabIndex = 0
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnKhongghi
        '
        Me.btnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnKhongghi.Location = New System.Drawing.Point(490, 0)
        Me.btnKhongghi.Name = "btnKhongghi"
        Me.btnKhongghi.Size = New System.Drawing.Size(75, 26)
        Me.btnKhongghi.TabIndex = 1
        Me.btnKhongghi.Text = "Không ghi"
        Me.btnKhongghi.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(565, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 26)
        Me.btnThoat.TabIndex = 0
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'dtpNgay
        '
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgay.Location = New System.Drawing.Point(174, 47)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(127, 21)
        Me.dtpNgay.TabIndex = 1
        Me.dtpNgay.Value = New Date(2010, 3, 29, 0, 0, 0, 0)
        '
        'lblCongnhan
        '
        Me.lblCongnhan.AutoSize = True
        Me.lblCongnhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCongnhan.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCongnhan.Location = New System.Drawing.Point(3, 73)
        Me.lblCongnhan.Name = "lblCongnhan"
        Me.lblCongnhan.Size = New System.Drawing.Size(165, 29)
        Me.lblCongnhan.TabIndex = 3
        Me.lblCongnhan.Text = "Công nhân"
        Me.lblCongnhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbCongnhan
        '
        Me.cbCongnhan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCongnhan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCongnhan.FormattingEnabled = True
        Me.cbCongnhan.Location = New System.Drawing.Point(174, 76)
        Me.cbCongnhan.Name = "cbCongnhan"
        Me.cbCongnhan.Size = New System.Drawing.Size(278, 21)
        Me.cbCongnhan.TabIndex = 2
        '
        'cbBophan
        '
        Me.cbBophan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbBophan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbBophan.FormattingEnabled = True
        Me.cbBophan.Location = New System.Drawing.Point(174, 105)
        Me.cbBophan.Name = "cbBophan"
        Me.cbBophan.Size = New System.Drawing.Size(278, 21)
        Me.cbBophan.TabIndex = 3
        '
        'frmCONGNHAN_BPCP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 414)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmCONGNHAN_BPCP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCONGNHAN_BPCP"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gbDanhsachCN_BPCP.ResumeLayout(False)
        CType(Me.gvDanhsach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblNgaynghi As System.Windows.Forms.Label
    Friend WithEvents lblBophan As System.Windows.Forms.Label
    Friend WithEvents gbDanhsachCN_BPCP As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gvDanhsach As System.Windows.Forms.DataGridView
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnKhongghi As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCongnhan As System.Windows.Forms.Label
    Friend WithEvents cbCongnhan As System.Windows.Forms.ComboBox
    Friend WithEvents cbBophan As System.Windows.Forms.ComboBox
    Friend WithEvents txtLoc As System.Windows.Forms.TextBox
    Friend WithEvents lblLoc As System.Windows.Forms.Label
End Class
