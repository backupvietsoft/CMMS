<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmThoiGianNgungMaytheoNguyenNhan
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbaTuNgay = New System.Windows.Forms.Label()
        Me.lbaDenNgay = New System.Windows.Forms.Label()
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox()
        Me.lbaNguyenNhan = New System.Windows.Forms.Label()
        Me.cbxNguyenNhan = New Commons.UtcComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaDayChuyen = New System.Windows.Forms.Label()
        Me.gvDaychuyen = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBochon = New System.Windows.Forms.Button()
        Me.btnChonhet = New System.Windows.Forms.Button()
        Me.btnThucHien = New System.Windows.Forms.Button()
        Me.btnThoat = New System.Windows.Forms.Button()
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDaychuyen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNguyenNhan, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNguyenNhan, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDayChuyen, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.gvDaychuyen, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(466, 230)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(3, 0)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(81, 28)
        Me.lbaTuNgay.TabIndex = 0
        Me.lbaTuNgay.Text = "Từ ngày"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(189, 0)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(80, 28)
        Me.lbaDenNgay.TabIndex = 1
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Location = New System.Drawing.Point(90, 3)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(93, 21)
        Me.mtxtTuNgay.TabIndex = 2
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'lbaNguyenNhan
        '
        Me.lbaNguyenNhan.AutoSize = True
        Me.lbaNguyenNhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNguyenNhan.Location = New System.Drawing.Point(3, 28)
        Me.lbaNguyenNhan.Name = "lbaNguyenNhan"
        Me.lbaNguyenNhan.Size = New System.Drawing.Size(81, 30)
        Me.lbaNguyenNhan.TabIndex = 4
        Me.lbaNguyenNhan.Text = "Nguyên nhân"
        Me.lbaNguyenNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxNguyenNhan
        '
        Me.cbxNguyenNhan.AssemblyName = ""
        Me.cbxNguyenNhan.BackColor = System.Drawing.Color.White
        Me.cbxNguyenNhan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxNguyenNhan.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxNguyenNhan.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxNguyenNhan, 3)
        Me.cbxNguyenNhan.Display = ""
        Me.cbxNguyenNhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNguyenNhan.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxNguyenNhan.FormattingEnabled = True
        Me.cbxNguyenNhan.IsAll = True
        Me.cbxNguyenNhan.isInputNull = False
        Me.cbxNguyenNhan.IsNew = False
        Me.cbxNguyenNhan.IsNull = True
        Me.cbxNguyenNhan.ItemAll = " < ALL > "
        Me.cbxNguyenNhan.ItemNew = "...New"
        Me.cbxNguyenNhan.Location = New System.Drawing.Point(90, 31)
        Me.cbxNguyenNhan.MethodName = ""
        Me.cbxNguyenNhan.Name = "cbxNguyenNhan"
        Me.cbxNguyenNhan.Param = ""
        Me.cbxNguyenNhan.Param2 = ""
        Me.cbxNguyenNhan.Size = New System.Drawing.Size(373, 21)
        Me.cbxNguyenNhan.StoreName = ""
        Me.cbxNguyenNhan.TabIndex = 5
        Me.cbxNguyenNhan.Table = Nothing
        Me.cbxNguyenNhan.TextReadonly = False
        Me.cbxNguyenNhan.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbaDayChuyen
        '
        Me.lbaDayChuyen.AutoSize = True
        Me.lbaDayChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDayChuyen.Location = New System.Drawing.Point(3, 58)
        Me.lbaDayChuyen.Name = "lbaDayChuyen"
        Me.lbaDayChuyen.Size = New System.Drawing.Size(81, 139)
        Me.lbaDayChuyen.TabIndex = 7
        Me.lbaDayChuyen.Text = "Dây Chuyền"
        '
        'gvDaychuyen
        '
        Me.gvDaychuyen.AllowUserToAddRows = False
        Me.gvDaychuyen.AllowUserToDeleteRows = False
        Me.gvDaychuyen.AllowUserToResizeRows = False
        Me.gvDaychuyen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gvDaychuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvDaychuyen.ColumnHeadersVisible = False
        Me.TableLayoutPanel1.SetColumnSpan(Me.gvDaychuyen, 3)
        Me.gvDaychuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvDaychuyen.Location = New System.Drawing.Point(90, 61)
        Me.gvDaychuyen.Name = "gvDaychuyen"
        Me.gvDaychuyen.ReadOnly = True
        Me.gvDaychuyen.RowHeadersWidth = 21
        Me.gvDaychuyen.Size = New System.Drawing.Size(373, 133)
        Me.gvDaychuyen.TabIndex = 9
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.btnBochon)
        Me.Panel1.Controls.Add(Me.btnChonhet)
        Me.Panel1.Controls.Add(Me.btnThucHien)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 200)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(460, 27)
        Me.Panel1.TabIndex = 8
        '
        'btnBochon
        '
        Me.btnBochon.Location = New System.Drawing.Point(163, 1)
        Me.btnBochon.Name = "btnBochon"
        Me.btnBochon.Size = New System.Drawing.Size(75, 23)
        Me.btnBochon.TabIndex = 2
        Me.btnBochon.Text = "Bỏ chọn"
        Me.btnBochon.UseVisualStyleBackColor = True
        '
        'btnChonhet
        '
        Me.btnChonhet.Location = New System.Drawing.Point(87, 1)
        Me.btnChonhet.Name = "btnChonhet"
        Me.btnChonhet.Size = New System.Drawing.Size(75, 23)
        Me.btnChonhet.TabIndex = 2
        Me.btnChonhet.Text = "Chọn hết"
        Me.btnChonhet.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThucHien.ForeColor = System.Drawing.Color.Navy
        Me.btnThucHien.Location = New System.Drawing.Point(310, 0)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(75, 27)
        Me.btnThucHien.TabIndex = 1
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(385, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 27)
        Me.btnThoat.TabIndex = 0
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'mtxtDenNgay
        '
        Me.mtxtDenNgay.Location = New System.Drawing.Point(275, 3)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(98, 21)
        Me.mtxtDenNgay.TabIndex = 3
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'FrmThoiGianNgungMaytheoNguyenNhan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 230)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(482, 269)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(340, 165)
        Me.Name = "FrmThoiGianNgungMaytheoNguyenNhan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmThoiGianNgungMaytheoNguyenNhan"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDaychuyen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbaNguyenNhan As System.Windows.Forms.Label
    Friend WithEvents cbxNguyenNhan As Commons.UtcComboBox
    Friend WithEvents lbaDayChuyen As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gvDaychuyen As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnBochon As System.Windows.Forms.Button
    Friend WithEvents btnChonhet As System.Windows.Forms.Button
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button
End Class
