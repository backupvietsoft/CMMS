<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChiPhiTheoThang
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
        Me.lblChiphi = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnThem = New System.Windows.Forms.Button()
        Me.btnSua = New System.Windows.Forms.Button()
        Me.btnGhi = New System.Windows.Forms.Button()
        Me.btnKhongghi = New System.Windows.Forms.Button()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.btnThoat = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gvChiphithang = New System.Windows.Forms.DataGridView()
        Me.gbThongtin = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtThang = New System.Windows.Forms.DateTimePicker()
        Me.lblMSCP = New System.Windows.Forms.Label()
        Me.lblThang = New System.Windows.Forms.Label()
        Me.cbMSBPCP = New System.Windows.Forms.ComboBox()
        Me.lblNgoaite = New System.Windows.Forms.Label()
        Me.cboNgoaite = New System.Windows.Forms.ComboBox()
        Me.lblChiphilapdat = New System.Windows.Forms.Label()
        Me.txtChiphilapdat = New System.Windows.Forms.TextBox()
        Me.lblChiphiHDBT = New System.Windows.Forms.Label()
        Me.txtChiphiHDBT = New System.Windows.Forms.TextBox()
        Me.txtGhichu = New System.Windows.Forms.TextBox()
        Me.lblGhichu = New System.Windows.Forms.Label()
        Me.lblTygia = New System.Windows.Forms.Label()
        Me.lblTygiaUSD = New System.Windows.Forms.Label()
        Me.txtTygia = New System.Windows.Forms.TextBox()
        Me.txtTygiaUSD = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gvChiphithang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbThongtin.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblChiphi, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainer1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.21795!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.78205!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(675, 483)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblChiphi
        '
        Me.lblChiphi.AutoSize = True
        Me.lblChiphi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChiphi.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChiphi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblChiphi.Location = New System.Drawing.Point(3, 0)
        Me.lblChiphi.Name = "lblChiphi"
        Me.lblChiphi.Size = New System.Drawing.Size(669, 42)
        Me.lblChiphi.TabIndex = 0
        Me.lblChiphi.Text = "Chi Phi Theo Thang"
        Me.lblChiphi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnThem)
        Me.Panel1.Controls.Add(Me.btnSua)
        Me.Panel1.Controls.Add(Me.btnGhi)
        Me.Panel1.Controls.Add(Me.btnKhongghi)
        Me.Panel1.Controls.Add(Me.btnXoa)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 456)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(669, 24)
        Me.Panel1.TabIndex = 3
        '
        'btnThem
        '
        Me.btnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThem.Location = New System.Drawing.Point(219, 0)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(75, 24)
        Me.btnThem.TabIndex = 7
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSua.Location = New System.Drawing.Point(294, 0)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(75, 24)
        Me.btnSua.TabIndex = 8
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGhi.Location = New System.Drawing.Point(369, 0)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(75, 24)
        Me.btnGhi.TabIndex = 9
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnKhongghi
        '
        Me.btnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnKhongghi.Location = New System.Drawing.Point(444, 0)
        Me.btnKhongghi.Name = "btnKhongghi"
        Me.btnKhongghi.Size = New System.Drawing.Size(75, 24)
        Me.btnKhongghi.TabIndex = 10
        Me.btnKhongghi.Text = "Không ghi"
        Me.btnKhongghi.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnXoa.Location = New System.Drawing.Point(519, 0)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(75, 24)
        Me.btnXoa.TabIndex = 11
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(594, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 24)
        Me.btnThoat.TabIndex = 12
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 45)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gvChiphithang)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbThongtin)
        Me.TableLayoutPanel1.SetRowSpan(Me.SplitContainer1, 2)
        Me.SplitContainer1.Size = New System.Drawing.Size(669, 405)
        Me.SplitContainer1.SplitterDistance = 318
        Me.SplitContainer1.TabIndex = 7
        '
        'gvChiphithang
        '
        Me.gvChiphithang.AllowUserToAddRows = False
        Me.gvChiphithang.AllowUserToDeleteRows = False
        Me.gvChiphithang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvChiphithang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvChiphithang.Location = New System.Drawing.Point(0, 0)
        Me.gvChiphithang.Name = "gvChiphithang"
        Me.gvChiphithang.ReadOnly = True
        Me.gvChiphithang.Size = New System.Drawing.Size(318, 405)
        Me.gvChiphithang.TabIndex = 6
        '
        'gbThongtin
        '
        Me.gbThongtin.Controls.Add(Me.TableLayoutPanel2)
        Me.gbThongtin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbThongtin.Location = New System.Drawing.Point(0, 0)
        Me.gbThongtin.Name = "gbThongtin"
        Me.gbThongtin.Size = New System.Drawing.Size(347, 405)
        Me.gbThongtin.TabIndex = 1
        Me.gbThongtin.TabStop = False
        Me.gbThongtin.Text = "Thông tin"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtThang, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblMSCP, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblThang, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbMSBPCP, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNgoaite, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.cboNgoaite, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblChiphilapdat, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtChiphilapdat, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblChiphiHDBT, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtChiphiHDBT, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtGhichu, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.lblGhichu, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTygia, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTygiaUSD, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTygia, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTygiaUSD, 1, 6)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 8
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(341, 385)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'txtThang
        '
        Me.txtThang.CustomFormat = "MM/yyyy"
        Me.txtThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtThang.Location = New System.Drawing.Point(86, 28)
        Me.txtThang.Name = "txtThang"
        Me.txtThang.Size = New System.Drawing.Size(252, 21)
        Me.txtThang.TabIndex = 2
        '
        'lblMSCP
        '
        Me.lblMSCP.AutoSize = True
        Me.lblMSCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMSCP.Location = New System.Drawing.Point(3, 0)
        Me.lblMSCP.Name = "lblMSCP"
        Me.lblMSCP.Size = New System.Drawing.Size(77, 25)
        Me.lblMSCP.TabIndex = 0
        Me.lblMSCP.Text = "MS BPCP"
        Me.lblMSCP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblThang
        '
        Me.lblThang.AutoSize = True
        Me.lblThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblThang.Location = New System.Drawing.Point(3, 25)
        Me.lblThang.Name = "lblThang"
        Me.lblThang.Size = New System.Drawing.Size(77, 24)
        Me.lblThang.TabIndex = 0
        Me.lblThang.Text = "Tháng"
        Me.lblThang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbMSBPCP
        '
        Me.cbMSBPCP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbMSBPCP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbMSBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbMSBPCP.FormattingEnabled = True
        Me.cbMSBPCP.Location = New System.Drawing.Point(86, 3)
        Me.cbMSBPCP.Name = "cbMSBPCP"
        Me.cbMSBPCP.Size = New System.Drawing.Size(252, 21)
        Me.cbMSBPCP.TabIndex = 1
        '
        'lblNgoaite
        '
        Me.lblNgoaite.AutoSize = True
        Me.lblNgoaite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgoaite.Location = New System.Drawing.Point(3, 100)
        Me.lblNgoaite.Name = "lblNgoaite"
        Me.lblNgoaite.Size = New System.Drawing.Size(77, 29)
        Me.lblNgoaite.TabIndex = 6
        Me.lblNgoaite.Text = "Ngoại tệ"
        Me.lblNgoaite.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboNgoaite
        '
        Me.cboNgoaite.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNgoaite.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNgoaite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNgoaite.FormattingEnabled = True
        Me.cboNgoaite.Location = New System.Drawing.Point(86, 103)
        Me.cboNgoaite.Name = "cboNgoaite"
        Me.cboNgoaite.Size = New System.Drawing.Size(252, 21)
        Me.cboNgoaite.TabIndex = 5
        '
        'lblChiphilapdat
        '
        Me.lblChiphilapdat.AutoSize = True
        Me.lblChiphilapdat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChiphilapdat.Location = New System.Drawing.Point(3, 75)
        Me.lblChiphilapdat.Name = "lblChiphilapdat"
        Me.lblChiphilapdat.Size = New System.Drawing.Size(77, 25)
        Me.lblChiphilapdat.TabIndex = 0
        Me.lblChiphilapdat.Text = "Chi phí lắp đặt"
        Me.lblChiphilapdat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChiphilapdat
        '
        Me.txtChiphilapdat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChiphilapdat.Location = New System.Drawing.Point(86, 78)
        Me.txtChiphilapdat.Name = "txtChiphilapdat"
        Me.txtChiphilapdat.Size = New System.Drawing.Size(252, 21)
        Me.txtChiphilapdat.TabIndex = 4
        '
        'lblChiphiHDBT
        '
        Me.lblChiphiHDBT.AutoSize = True
        Me.lblChiphiHDBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChiphiHDBT.Location = New System.Drawing.Point(3, 49)
        Me.lblChiphiHDBT.Name = "lblChiphiHDBT"
        Me.lblChiphiHDBT.Size = New System.Drawing.Size(77, 26)
        Me.lblChiphiHDBT.TabIndex = 0
        Me.lblChiphiHDBT.Text = "Chi Phí HDBT"
        Me.lblChiphiHDBT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChiphiHDBT
        '
        Me.txtChiphiHDBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChiphiHDBT.Location = New System.Drawing.Point(86, 52)
        Me.txtChiphiHDBT.Name = "txtChiphiHDBT"
        Me.txtChiphiHDBT.Size = New System.Drawing.Size(252, 21)
        Me.txtChiphiHDBT.TabIndex = 3
        '
        'txtGhichu
        '
        Me.txtGhichu.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtGhichu.Location = New System.Drawing.Point(86, 183)
        Me.txtGhichu.Multiline = True
        Me.txtGhichu.Name = "txtGhichu"
        Me.txtGhichu.Size = New System.Drawing.Size(252, 77)
        Me.txtGhichu.TabIndex = 6
        '
        'lblGhichu
        '
        Me.lblGhichu.AutoSize = True
        Me.lblGhichu.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblGhichu.Location = New System.Drawing.Point(3, 180)
        Me.lblGhichu.Name = "lblGhichu"
        Me.lblGhichu.Size = New System.Drawing.Size(77, 13)
        Me.lblGhichu.TabIndex = 0
        Me.lblGhichu.Text = "Ghi chú"
        Me.lblGhichu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTygia
        '
        Me.lblTygia.AutoSize = True
        Me.lblTygia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTygia.Location = New System.Drawing.Point(3, 129)
        Me.lblTygia.Name = "lblTygia"
        Me.lblTygia.Size = New System.Drawing.Size(77, 24)
        Me.lblTygia.TabIndex = 7
        Me.lblTygia.Text = "Tỷ giá"
        Me.lblTygia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTygiaUSD
        '
        Me.lblTygiaUSD.AutoSize = True
        Me.lblTygiaUSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTygiaUSD.Location = New System.Drawing.Point(3, 153)
        Me.lblTygiaUSD.Name = "lblTygiaUSD"
        Me.lblTygiaUSD.Size = New System.Drawing.Size(77, 27)
        Me.lblTygiaUSD.TabIndex = 7
        Me.lblTygiaUSD.Text = "Tỷ giá USD"
        Me.lblTygiaUSD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTygia
        '
        Me.txtTygia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTygia.Location = New System.Drawing.Point(86, 132)
        Me.txtTygia.Name = "txtTygia"
        Me.txtTygia.Size = New System.Drawing.Size(252, 21)
        Me.txtTygia.TabIndex = 8
        '
        'txtTygiaUSD
        '
        Me.txtTygiaUSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTygiaUSD.Location = New System.Drawing.Point(86, 156)
        Me.txtTygiaUSD.Name = "txtTygiaUSD"
        Me.txtTygiaUSD.Size = New System.Drawing.Size(252, 21)
        Me.txtTygiaUSD.TabIndex = 8
        '
        'frmChiPhiTheoThang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 483)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChiPhiTheoThang"
        Me.Text = "frmChiPhiTheoThang"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gvChiphithang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbThongtin.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblChiphi As System.Windows.Forms.Label
    Friend WithEvents gbThongtin As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMSCP As System.Windows.Forms.Label
    Friend WithEvents lblChiphilapdat As System.Windows.Forms.Label
    Friend WithEvents lblGhichu As System.Windows.Forms.Label
    Friend WithEvents lblChiphiHDBT As System.Windows.Forms.Label
    Friend WithEvents lblThang As System.Windows.Forms.Label
    Friend WithEvents cbMSBPCP As System.Windows.Forms.ComboBox
    Friend WithEvents txtChiphiHDBT As System.Windows.Forms.TextBox
    Friend WithEvents txtChiphilapdat As System.Windows.Forms.TextBox
    Friend WithEvents txtGhichu As System.Windows.Forms.TextBox
    Friend WithEvents gvChiphithang As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnKhongghi As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents txtThang As System.Windows.Forms.DateTimePicker
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblNgoaite As System.Windows.Forms.Label
    Friend WithEvents cboNgoaite As System.Windows.Forms.ComboBox
    Friend WithEvents lblTygia As System.Windows.Forms.Label
    Friend WithEvents lblTygiaUSD As System.Windows.Forms.Label
    Friend WithEvents txtTygia As System.Windows.Forms.TextBox
    Friend WithEvents txtTygiaUSD As System.Windows.Forms.TextBox
End Class
