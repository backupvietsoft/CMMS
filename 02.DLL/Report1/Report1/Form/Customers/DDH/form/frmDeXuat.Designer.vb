<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeXuat
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.gvDeXuat = New System.Windows.Forms.DataGridView
        Me.SO_DE_XUAT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NGAY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_seach = New System.Windows.Forms.TextBox
        Me.bt_chon = New DevExpress.XtraEditors.SimpleButton
        Me.bt_boChon = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.gvDeXuat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.gvDeXuat, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(688, 430)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'gvDeXuat
        '
        Me.gvDeXuat.AllowUserToAddRows = False
        Me.gvDeXuat.AllowUserToDeleteRows = False
        Me.gvDeXuat.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvDeXuat.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gvDeXuat.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.Format = "N2"
        Me.gvDeXuat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvDeXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvDeXuat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SO_DE_XUAT, Me.NGAY, Me.CHON})
        Me.gvDeXuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvDeXuat.Location = New System.Drawing.Point(3, 39)
        Me.gvDeXuat.Name = "gvDeXuat"
        Me.gvDeXuat.RowHeadersVisible = False
        Me.gvDeXuat.Size = New System.Drawing.Size(682, 349)
        Me.gvDeXuat.TabIndex = 0
        '
        'SO_DE_XUAT
        '
        Me.SO_DE_XUAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SO_DE_XUAT.HeaderText = "Số đề xuất"
        Me.SO_DE_XUAT.MinimumWidth = 200
        Me.SO_DE_XUAT.Name = "SO_DE_XUAT"
        Me.SO_DE_XUAT.ReadOnly = True
        '
        'NGAY
        '
        Me.NGAY.HeaderText = "Ngày đề xuất"
        Me.NGAY.Name = "NGAY"
        Me.NGAY.ReadOnly = True
        Me.NGAY.Width = 130
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
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(682, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ĐỀ XUẤT ĐẶT HÀNG"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_seach)
        Me.Panel1.Controls.Add(Me.bt_chon)
        Me.Panel1.Controls.Add(Me.bt_boChon)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 394)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(682, 33)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Số đề xuất:"
        '
        'txt_seach
        '
        Me.txt_seach.Location = New System.Drawing.Point(71, 7)
        Me.txt_seach.Name = "txt_seach"
        Me.txt_seach.Size = New System.Drawing.Size(130, 21)
        Me.txt_seach.TabIndex = 2
        '
        'bt_chon
        '
        Me.bt_chon.Dock = System.Windows.Forms.DockStyle.Right
        Me.bt_chon.Location = New System.Drawing.Point(532, 0)
        Me.bt_chon.Name = "bt_chon"
        Me.bt_chon.Size = New System.Drawing.Size(75, 33)
        Me.bt_chon.TabIndex = 1
        Me.bt_chon.Text = "Chọn"
        
        '
        'bt_boChon
        '
        Me.bt_boChon.Dock = System.Windows.Forms.DockStyle.Right
        Me.bt_boChon.Location = New System.Drawing.Point(607, 0)
        Me.bt_boChon.Name = "bt_boChon"
        Me.bt_boChon.Size = New System.Drawing.Size(75, 33)
        Me.bt_boChon.TabIndex = 0
        Me.bt_boChon.Text = "Bỏ chọn"
        
        '
        'frmDeXuat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 430)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDeXuat"
        Me.Text = "Đề xuất"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.gvDeXuat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gvDeXuat As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_chon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bt_boChon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_seach As System.Windows.Forms.TextBox
    Friend WithEvents SO_DE_XUAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NGAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
