<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDS_VT_PT
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_seach = New System.Windows.Forms.TextBox
        Me.bt_Chon = New DevExpress.XtraEditors.SimpleButton
        Me.bt_BoQua = New DevExpress.XtraEditors.SimpleButton
        Me.gvListPhuTung = New System.Windows.Forms.DataGridView
        Me.MS_PT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_PT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QUY_CACH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.cb_LoaiVT = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gvListPhuTung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.gvListPhuTung, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_LoaiVT, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(788, 519)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 5)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(782, 38)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DANH SÁCH VẬT TƯ  PHỤ TÙNG"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_seach)
        Me.Panel1.Controls.Add(Me.bt_Chon)
        Me.Panel1.Controls.Add(Me.bt_BoQua)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 482)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(782, 34)
        Me.Panel1.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Mã VT-PT :"
        '
        'txt_seach
        '
        Me.txt_seach.Location = New System.Drawing.Point(68, 8)
        Me.txt_seach.Name = "txt_seach"
        Me.txt_seach.Size = New System.Drawing.Size(115, 21)
        Me.txt_seach.TabIndex = 2
        '
        'bt_Chon
        '
        Me.bt_Chon.Dock = System.Windows.Forms.DockStyle.Right
        Me.bt_Chon.Location = New System.Drawing.Point(632, 0)
        Me.bt_Chon.Name = "bt_Chon"
        Me.bt_Chon.Size = New System.Drawing.Size(75, 34)
        Me.bt_Chon.TabIndex = 1
        Me.bt_Chon.Text = "Thực hiện"

        '
        'bt_BoQua
        '
        Me.bt_BoQua.Dock = System.Windows.Forms.DockStyle.Right
        Me.bt_BoQua.Location = New System.Drawing.Point(707, 0)
        Me.bt_BoQua.Name = "bt_BoQua"
        Me.bt_BoQua.Size = New System.Drawing.Size(75, 34)
        Me.bt_BoQua.TabIndex = 0
        Me.bt_BoQua.Text = "Bỏ qua"

        '
        'gvListPhuTung
        '
        Me.gvListPhuTung.AllowUserToAddRows = False
        Me.gvListPhuTung.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvListPhuTung.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gvListPhuTung.BackgroundColor = System.Drawing.Color.White
        Me.gvListPhuTung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvListPhuTung.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_PT, Me.TEN_PT, Me.QUY_CACH, Me.TEN_1, Me.CHON})
        Me.TableLayoutPanel1.SetColumnSpan(Me.gvListPhuTung, 5)
        Me.gvListPhuTung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvListPhuTung.Location = New System.Drawing.Point(3, 77)
        Me.gvListPhuTung.Name = "gvListPhuTung"
        Me.gvListPhuTung.RowHeadersVisible = False
        Me.gvListPhuTung.Size = New System.Drawing.Size(782, 399)
        Me.gvListPhuTung.TabIndex = 0
        '
        'MS_PT
        '
        Me.MS_PT.HeaderText = "Mã VT-PT"
        Me.MS_PT.Name = "MS_PT"
        Me.MS_PT.ReadOnly = True
        '
        'TEN_PT
        '
        Me.TEN_PT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_PT.HeaderText = "Tên Vật Tư"
        Me.TEN_PT.MinimumWidth = 150
        Me.TEN_PT.Name = "TEN_PT"
        Me.TEN_PT.ReadOnly = True
        '
        'QUY_CACH
        '
        Me.QUY_CACH.HeaderText = "Quy Cách"
        Me.QUY_CACH.Name = "QUY_CACH"
        Me.QUY_CACH.ReadOnly = True
        '
        'TEN_1
        '
        Me.TEN_1.HeaderText = "Đơn vị tính"
        Me.TEN_1.Name = "TEN_1"
        Me.TEN_1.ReadOnly = True
        '
        'CHON
        '
        Me.CHON.HeaderText = "Chọn"
        Me.CHON.Name = "CHON"
        Me.CHON.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(34, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 28)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Loại VT - PT:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cb_LoaiVT
        '
        Me.cb_LoaiVT.FormattingEnabled = True
        Me.cb_LoaiVT.Location = New System.Drawing.Point(126, 41)
        Me.cb_LoaiVT.Name = "cb_LoaiVT"
        Me.cb_LoaiVT.Size = New System.Drawing.Size(147, 21)
        Me.cb_LoaiVT.TabIndex = 4
        '
        'frmDS_VT_PT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 519)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDS_VT_PT"
        Me.Text = "VT-PT"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gvListPhuTung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gvListPhuTung As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_Chon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bt_BoQua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_LoaiVT As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_seach As System.Windows.Forms.TextBox
    Friend WithEvents MS_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_PT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUY_CACH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
