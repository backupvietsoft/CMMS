<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKhachHang
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.gv_KhachHang = New System.Windows.Forms.DataGridView()
        Me.MS_KH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEN_CONG_TY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEN_RUT_GON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIA_CHI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_seach = New System.Windows.Forms.TextBox()
        Me.lba_KHchon = New System.Windows.Forms.Label()
        Me.tb_Chon = New DevExpress.XtraEditors.SimpleButton()
        Me.bt_BoChon = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.gv_KhachHang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.gv_KhachHang, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(717, 468)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'gv_KhachHang
        '
        Me.gv_KhachHang.AllowUserToAddRows = False
        Me.gv_KhachHang.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gv_KhachHang.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gv_KhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_KhachHang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_KH, Me.TEN_CONG_TY, Me.TEN_RUT_GON, Me.DIA_CHI, Me.CHON})
        Me.TableLayoutPanel1.SetColumnSpan(Me.gv_KhachHang, 2)
        Me.gv_KhachHang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gv_KhachHang.Location = New System.Drawing.Point(3, 34)
        Me.gv_KhachHang.Name = "gv_KhachHang"
        Me.gv_KhachHang.RowHeadersVisible = False
        Me.gv_KhachHang.Size = New System.Drawing.Size(711, 398)
        Me.gv_KhachHang.TabIndex = 0
        '
        'MS_KH
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.Format = "N2"
        Me.MS_KH.DefaultCellStyle = DataGridViewCellStyle2
        Me.MS_KH.HeaderText = "MA KH"
        Me.MS_KH.Name = "MS_KH"
        Me.MS_KH.ReadOnly = True
        Me.MS_KH.Width = 70
        '
        'TEN_CONG_TY
        '
        Me.TEN_CONG_TY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_CONG_TY.HeaderText = "Tên khách hàng"
        Me.TEN_CONG_TY.MinimumWidth = 150
        Me.TEN_CONG_TY.Name = "TEN_CONG_TY"
        Me.TEN_CONG_TY.ReadOnly = True
        '
        'TEN_RUT_GON
        '
        Me.TEN_RUT_GON.HeaderText = "Tên rút gọn"
        Me.TEN_RUT_GON.Name = "TEN_RUT_GON"
        Me.TEN_RUT_GON.ReadOnly = True
        Me.TEN_RUT_GON.Width = 150
        '
        'DIA_CHI
        '
        Me.DIA_CHI.HeaderText = "Địa Chỉ"
        Me.DIA_CHI.Name = "DIA_CHI"
        Me.DIA_CHI.ReadOnly = True
        Me.DIA_CHI.Width = 150
        '
        'CHON
        '
        Me.CHON.HeaderText = "Chọn"
        Me.CHON.Name = "CHON"
        Me.CHON.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(711, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DANH SÁCH KHÁCH HÀNG"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_seach)
        Me.Panel1.Controls.Add(Me.lba_KHchon)
        Me.Panel1.Controls.Add(Me.tb_Chon)
        Me.Panel1.Controls.Add(Me.bt_BoChon)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 438)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(711, 27)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Mã KH:"
        '
        'txt_seach
        '
        Me.txt_seach.Location = New System.Drawing.Point(49, 5)
        Me.txt_seach.Name = "txt_seach"
        Me.txt_seach.Size = New System.Drawing.Size(133, 21)
        Me.txt_seach.TabIndex = 3
        '
        'lba_KHchon
        '
        Me.lba_KHchon.AutoSize = True
        Me.lba_KHchon.Dock = System.Windows.Forms.DockStyle.Left
        Me.lba_KHchon.Location = New System.Drawing.Point(0, 0)
        Me.lba_KHchon.Name = "lba_KHchon"
        Me.lba_KHchon.Size = New System.Drawing.Size(0, 13)
        Me.lba_KHchon.TabIndex = 2
        '
        'tb_Chon
        '
        Me.tb_Chon.Dock = System.Windows.Forms.DockStyle.Right
        Me.tb_Chon.Location = New System.Drawing.Point(561, 0)
        Me.tb_Chon.Name = "tb_Chon"
        Me.tb_Chon.Size = New System.Drawing.Size(75, 27)
        Me.tb_Chon.TabIndex = 1
        Me.tb_Chon.Text = "Chọn"
        '
        'bt_BoChon
        '
        Me.bt_BoChon.Dock = System.Windows.Forms.DockStyle.Right
        Me.bt_BoChon.Location = New System.Drawing.Point(636, 0)
        Me.bt_BoChon.Name = "bt_BoChon"
        Me.bt_BoChon.Size = New System.Drawing.Size(75, 27)
        Me.bt_BoChon.TabIndex = 0
        Me.bt_BoChon.Text = "Bỏ chọn"
        '
        'frmKhachHang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 468)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmKhachHang"
        Me.Text = "Khách hàng"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.gv_KhachHang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gv_KhachHang As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tb_Chon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bt_BoChon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MS_KH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_CONG_TY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_RUT_GON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIA_CHI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lba_KHchon As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_seach As System.Windows.Forms.TextBox
End Class
