<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMTBF_TheoDC
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
        Me.dgvShow = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBoChon = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonAll = New DevExpress.XtraEditors.SimpleButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvShow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvShow
        '
        Me.dgvShow.AllowUserToAddRows = False
        Me.dgvShow.AllowUserToDeleteRows = False
        Me.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShow.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgvShow.Location = New System.Drawing.Point(12, 12)
        Me.dgvShow.Name = "dgvShow"
        Me.dgvShow.Size = New System.Drawing.Size(599, 333)
        Me.dgvShow.TabIndex = 8
        '
        'Column1
        '
        Me.Column1.HeaderText = "   Chọn"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 55
        '
        'Column2
        '
        Me.Column2.HeaderText = "                            Mã số hệ thống"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 240
        '
        'Column3
        '
        Me.Column3.HeaderText = "                                Tên hệ thống"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 243
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Appearance.Options.UseFont = True
        Me.btnThoat.Location = New System.Drawing.Point(536, 353)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 23)
        Me.btnThoat.TabIndex = 13
        Me.btnThoat.Text = "Tho&át"
        '
        'btnThucHien
        '
        Me.btnThucHien.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnThucHien.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThucHien.Appearance.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnThucHien.Appearance.Options.UseFont = True
        Me.btnThucHien.Appearance.Options.UseForeColor = True
        Me.btnThucHien.Location = New System.Drawing.Point(450, 353)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(80, 23)
        Me.btnThucHien.TabIndex = 12
        Me.btnThucHien.Text = "&Thực hiện"
        '
        'btnBoChon
        '
        Me.btnBoChon.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBoChon.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBoChon.Appearance.Options.UseFont = True
        Me.btnBoChon.Appearance.Options.UseForeColor = True
        Me.btnBoChon.Location = New System.Drawing.Point(125, 353)
        Me.btnBoChon.Name = "btnBoChon"
        Me.btnBoChon.Size = New System.Drawing.Size(107, 23)
        Me.btnBoChon.TabIndex = 10
        Me.btnBoChon.Text = "&Bỏ chọn tất cả"
        '
        'btnChonAll
        '
        Me.btnChonAll.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnChonAll.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChonAll.Appearance.Options.UseFont = True
        Me.btnChonAll.Appearance.Options.UseForeColor = True
        Me.btnChonAll.Location = New System.Drawing.Point(12, 353)
        Me.btnChonAll.Name = "btnChonAll"
        Me.btnChonAll.Size = New System.Drawing.Size(107, 23)
        Me.btnChonAll.TabIndex = 11
        Me.btnChonAll.Text = "&Chọn tất cả"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "                               Mã số máy"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 240
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "                                 Nhóm máy"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 243
        '
        'frmMTBF_TheoDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 384)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.btnThucHien)
        Me.Controls.Add(Me.btnBoChon)
        Me.Controls.Add(Me.btnChonAll)
        Me.Controls.Add(Me.dgvShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMTBF_TheoDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chọn dây chuyền"
        CType(Me.dgvShow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvShow As System.Windows.Forms.DataGridView
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBoChon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChonAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
