<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchPT
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
        Me.components = New System.ComponentModel.Container
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.grpLoctheodieukien = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboLocthietbi = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblLocloaivattu = New System.Windows.Forms.Label
        Me.cboLocvattu = New Commons.UtcComboBox
        Me.lblLocloaithietbi = New System.Windows.Forms.Label
        Me.cboLocNoisudung = New Commons.UtcComboBox
        Me.lblLocNoisudung = New System.Windows.Forms.Label
        Me.cbxClass = New Commons.UtcComboBox
        Me.grpTimkiem = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.LblTimtheomasopt = New System.Windows.Forms.Label
        Me.txtGiatritim = New Commons.utcTextBox
        Me.cboTimtheo = New Commons.UtcComboBox
        Me.lblGiatritim = New System.Windows.Forms.Label
        Me.radLoctheodieukien = New System.Windows.Forms.RadioButton
        Me.radTimkiem = New System.Windows.Forms.RadioButton
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.grpLoctheodieukien.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTimkiem.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThucHien.Location = New System.Drawing.Point(122, 171)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(2)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(3)
        Me.btnThucHien.Size = New System.Drawing.Size(87, 28)
        Me.btnThucHien.TabIndex = 0
        Me.btnThucHien.Text = "Thực hiện"
        
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(213, 171)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(2)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(3)
        Me.btnThoat.Size = New System.Drawing.Size(87, 28)
        Me.btnThoat.TabIndex = 1
        Me.btnThoat.Text = "Thoát"
        
        '
        'grpLoctheodieukien
        '
        Me.grpLoctheodieukien.Controls.Add(Me.TableLayoutPanel4)
        Me.grpLoctheodieukien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpLoctheodieukien.ForeColor = System.Drawing.Color.Blue
        Me.grpLoctheodieukien.Location = New System.Drawing.Point(0, 0)
        Me.grpLoctheodieukien.Name = "grpLoctheodieukien"
        Me.grpLoctheodieukien.Size = New System.Drawing.Size(416, 131)
        Me.grpLoctheodieukien.TabIndex = 58
        Me.grpLoctheodieukien.TabStop = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.cboLocthietbi, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblLocloaivattu, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.cboLocvattu, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.lblLocloaithietbi, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cboLocNoisudung, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.lblLocNoisudung, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.cbxClass, 1, 3)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 5
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(410, 111)
        Me.TableLayoutPanel4.TabIndex = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(3, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 28)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Mã số class "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLocthietbi
        '
        Me.cboLocthietbi.AssemblyName = ""
        Me.cboLocthietbi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocthietbi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocthietbi.BackColor = System.Drawing.SystemColors.Window
        Me.cboLocthietbi.ClassName = ""
        Me.cboLocthietbi.Display = ""
        Me.cboLocthietbi.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboLocthietbi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocthietbi.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLocthietbi.FormattingEnabled = True
        Me.cboLocthietbi.IsAll = True
        Me.cboLocthietbi.IsNew = False
        Me.cboLocthietbi.ItemAll = " < ALL > "
        Me.cboLocthietbi.ItemNew = "...New"
        Me.cboLocthietbi.Location = New System.Drawing.Point(133, 4)
        Me.cboLocthietbi.MethodName = ""
        Me.cboLocthietbi.Name = "cboLocthietbi"
        Me.cboLocthietbi.Param = ""
        Me.cboLocthietbi.Size = New System.Drawing.Size(274, 21)
        Me.cboLocthietbi.StoreName = ""
        Me.cboLocthietbi.TabIndex = 39
        Me.cboLocthietbi.Table = Nothing
        Me.cboLocthietbi.TextReadonly = False
        Me.cboLocthietbi.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblLocloaivattu
        '
        Me.lblLocloaivattu.AutoSize = True
        Me.lblLocloaivattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLocloaivattu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocloaivattu.ForeColor = System.Drawing.Color.Black
        Me.lblLocloaivattu.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLocloaivattu.Location = New System.Drawing.Point(3, 28)
        Me.lblLocloaivattu.Name = "lblLocloaivattu"
        Me.lblLocloaivattu.Size = New System.Drawing.Size(124, 28)
        Me.lblLocloaivattu.TabIndex = 34
        Me.lblLocloaivattu.Text = "Loại vật tư/phụ tùng"
        Me.lblLocloaivattu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLocvattu
        '
        Me.cboLocvattu.AssemblyName = ""
        Me.cboLocvattu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocvattu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocvattu.BackColor = System.Drawing.SystemColors.Window
        Me.cboLocvattu.ClassName = ""
        Me.cboLocvattu.Display = ""
        Me.cboLocvattu.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboLocvattu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocvattu.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLocvattu.FormattingEnabled = True
        Me.cboLocvattu.IsAll = True
        Me.cboLocvattu.IsNew = False
        Me.cboLocvattu.ItemAll = " < ALL > "
        Me.cboLocvattu.ItemNew = "...New"
        Me.cboLocvattu.Location = New System.Drawing.Point(133, 32)
        Me.cboLocvattu.MethodName = ""
        Me.cboLocvattu.Name = "cboLocvattu"
        Me.cboLocvattu.Param = ""
        Me.cboLocvattu.Size = New System.Drawing.Size(274, 21)
        Me.cboLocvattu.StoreName = ""
        Me.cboLocvattu.TabIndex = 33
        Me.cboLocvattu.Table = Nothing
        Me.cboLocvattu.TextReadonly = False
        Me.cboLocvattu.Value = ""
        '
        'lblLocloaithietbi
        '
        Me.lblLocloaithietbi.AutoSize = True
        Me.lblLocloaithietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLocloaithietbi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocloaithietbi.ForeColor = System.Drawing.Color.Black
        Me.lblLocloaithietbi.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLocloaithietbi.Location = New System.Drawing.Point(3, 0)
        Me.lblLocloaithietbi.Name = "lblLocloaithietbi"
        Me.lblLocloaithietbi.Size = New System.Drawing.Size(124, 28)
        Me.lblLocloaithietbi.TabIndex = 40
        Me.lblLocloaithietbi.Text = "Loại thiết bị"
        Me.lblLocloaithietbi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLocNoisudung
        '
        Me.cboLocNoisudung.AssemblyName = ""
        Me.cboLocNoisudung.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocNoisudung.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocNoisudung.BackColor = System.Drawing.SystemColors.Window
        Me.cboLocNoisudung.ClassName = ""
        Me.cboLocNoisudung.Display = ""
        Me.cboLocNoisudung.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboLocNoisudung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocNoisudung.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLocNoisudung.FormattingEnabled = True
        Me.cboLocNoisudung.IsAll = True
        Me.cboLocNoisudung.IsNew = False
        Me.cboLocNoisudung.ItemAll = " < ALL > "
        Me.cboLocNoisudung.ItemNew = "...New"
        Me.cboLocNoisudung.Location = New System.Drawing.Point(133, 60)
        Me.cboLocNoisudung.MethodName = ""
        Me.cboLocNoisudung.Name = "cboLocNoisudung"
        Me.cboLocNoisudung.Param = ""
        Me.cboLocNoisudung.Size = New System.Drawing.Size(274, 21)
        Me.cboLocNoisudung.StoreName = ""
        Me.cboLocNoisudung.TabIndex = 37
        Me.cboLocNoisudung.Table = Nothing
        Me.cboLocNoisudung.TextReadonly = False
        Me.cboLocNoisudung.Value = ""
        '
        'lblLocNoisudung
        '
        Me.lblLocNoisudung.AutoSize = True
        Me.lblLocNoisudung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLocNoisudung.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocNoisudung.ForeColor = System.Drawing.Color.Black
        Me.lblLocNoisudung.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLocNoisudung.Location = New System.Drawing.Point(3, 56)
        Me.lblLocNoisudung.Name = "lblLocNoisudung"
        Me.lblLocNoisudung.Size = New System.Drawing.Size(124, 28)
        Me.lblLocNoisudung.TabIndex = 38
        Me.lblLocNoisudung.Text = "Nơi sử dụng"
        Me.lblLocNoisudung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxClass
        '
        Me.cbxClass.AssemblyName = ""
        Me.cbxClass.BackColor = System.Drawing.Color.White
        Me.cbxClass.ClassName = ""
        Me.cbxClass.Display = ""
        Me.cbxClass.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbxClass.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxClass.FormattingEnabled = True
        Me.cbxClass.IsAll = True
        Me.cbxClass.IsNew = False
        Me.cbxClass.ItemAll = " < ALL > "
        Me.cbxClass.ItemNew = "...New"
        Me.cbxClass.Location = New System.Drawing.Point(133, 88)
        Me.cbxClass.MethodName = ""
        Me.cbxClass.Name = "cbxClass"
        Me.cbxClass.Param = ""
        Me.cbxClass.Size = New System.Drawing.Size(274, 21)
        Me.cbxClass.StoreName = ""
        Me.cbxClass.TabIndex = 69
        Me.cbxClass.Table = Nothing
        Me.cbxClass.TextReadonly = False
        Me.cbxClass.Value = ""
        '
        'grpTimkiem
        '
        Me.grpTimkiem.Controls.Add(Me.TableLayoutPanel3)
        Me.grpTimkiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTimkiem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.grpTimkiem.Location = New System.Drawing.Point(0, 0)
        Me.grpTimkiem.Name = "grpTimkiem"
        Me.grpTimkiem.Size = New System.Drawing.Size(416, 131)
        Me.grpTimkiem.TabIndex = 57
        Me.grpTimkiem.TabStop = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.LblTimtheomasopt, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtGiatritim, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cboTimtheo, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblGiatritim, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(410, 111)
        Me.TableLayoutPanel3.TabIndex = 38
        '
        'LblTimtheomasopt
        '
        Me.LblTimtheomasopt.AutoSize = True
        Me.LblTimtheomasopt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTimtheomasopt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LblTimtheomasopt.ForeColor = System.Drawing.Color.Black
        Me.LblTimtheomasopt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblTimtheomasopt.Location = New System.Drawing.Point(3, 0)
        Me.LblTimtheomasopt.Name = "LblTimtheomasopt"
        Me.LblTimtheomasopt.Size = New System.Drawing.Size(88, 28)
        Me.LblTimtheomasopt.TabIndex = 37
        Me.LblTimtheomasopt.Text = "Tìm theo"
        Me.LblTimtheomasopt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGiatritim
        '
        Me.txtGiatritim.BackColor = System.Drawing.SystemColors.Window
        Me.txtGiatritim.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtGiatritim.ErrorProviderControl = Me.ErrorProvider1
        Me.txtGiatritim.FieldName = ""
        Me.txtGiatritim.IsNull = True
        Me.txtGiatritim.Location = New System.Drawing.Point(97, 32)
        Me.txtGiatritim.Name = "txtGiatritim"
        Me.txtGiatritim.Size = New System.Drawing.Size(310, 21)
        Me.txtGiatritim.TabIndex = 31
        Me.txtGiatritim.TextTypeMode = Commons.TypeMode.None
        '
        'cboTimtheo
        '
        Me.cboTimtheo.AssemblyName = ""
        Me.cboTimtheo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTimtheo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTimtheo.BackColor = System.Drawing.SystemColors.Window
        Me.cboTimtheo.ClassName = ""
        Me.cboTimtheo.Display = ""
        Me.cboTimtheo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboTimtheo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimtheo.ErrorProviderControl = Me.ErrorProvider1
        Me.cboTimtheo.FormattingEnabled = True
        Me.cboTimtheo.IsAll = False
        Me.cboTimtheo.IsNew = False
        Me.cboTimtheo.ItemAll = " < ALL > "
        Me.cboTimtheo.ItemNew = "...New"
        Me.cboTimtheo.Location = New System.Drawing.Point(97, 4)
        Me.cboTimtheo.MethodName = ""
        Me.cboTimtheo.Name = "cboTimtheo"
        Me.cboTimtheo.Param = ""
        Me.cboTimtheo.Size = New System.Drawing.Size(310, 21)
        Me.cboTimtheo.StoreName = ""
        Me.cboTimtheo.TabIndex = 17
        Me.cboTimtheo.Table = Nothing
        Me.cboTimtheo.TextReadonly = False
        Me.cboTimtheo.Value = ""
        '
        'lblGiatritim
        '
        Me.lblGiatritim.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblGiatritim.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblGiatritim.ForeColor = System.Drawing.Color.Black
        Me.lblGiatritim.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGiatritim.Location = New System.Drawing.Point(3, 28)
        Me.lblGiatritim.Name = "lblGiatritim"
        Me.lblGiatritim.Size = New System.Drawing.Size(88, 26)
        Me.lblGiatritim.TabIndex = 37
        Me.lblGiatritim.Text = "Giá trị tìm"
        Me.lblGiatritim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'radLoctheodieukien
        '
        Me.radLoctheodieukien.AutoSize = True
        Me.radLoctheodieukien.Checked = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.radLoctheodieukien, 2)
        Me.radLoctheodieukien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radLoctheodieukien.Location = New System.Drawing.Point(123, 3)
        Me.radLoctheodieukien.Name = "radLoctheodieukien"
        Me.radLoctheodieukien.Size = New System.Drawing.Size(176, 26)
        Me.radLoctheodieukien.TabIndex = 55
        Me.radLoctheodieukien.TabStop = True
        Me.radLoctheodieukien.Text = "Lọc theo điều kiện lọc"
        Me.radLoctheodieukien.UseVisualStyleBackColor = True
        '
        'radTimkiem
        '
        Me.radTimkiem.AutoSize = True
        Me.radTimkiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radTimkiem.Location = New System.Drawing.Point(3, 3)
        Me.radTimkiem.Name = "radTimkiem"
        Me.radTimkiem.Size = New System.Drawing.Size(114, 26)
        Me.radTimkiem.TabIndex = 56
        Me.radTimkiem.Text = "Tìm kiếm"
        Me.radTimkiem.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.radLoctheodieukien, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.radTimkiem, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(422, 201)
        Me.TableLayoutPanel1.TabIndex = 59
        '
        'Panel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 4)
        Me.Panel2.Controls.Add(Me.grpLoctheodieukien)
        Me.Panel2.Controls.Add(Me.grpTimkiem)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 35)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(416, 131)
        Me.Panel2.TabIndex = 58
        '
        'frmSearchPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 201)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximumSize = New System.Drawing.Size(438, 239)
        Me.MinimumSize = New System.Drawing.Size(430, 235)
        Me.Name = "frmSearchPT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSearchPT"
        Me.grpLoctheodieukien.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTimkiem.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents radTimkiem As System.Windows.Forms.RadioButton
    Friend WithEvents radLoctheodieukien As System.Windows.Forms.RadioButton
    Friend WithEvents grpLoctheodieukien As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboLocthietbi As Commons.UtcComboBox
    Friend WithEvents lblLocloaivattu As System.Windows.Forms.Label
    Friend WithEvents cboLocvattu As Commons.UtcComboBox
    Friend WithEvents lblLocloaithietbi As System.Windows.Forms.Label
    Friend WithEvents cboLocNoisudung As Commons.UtcComboBox
    Friend WithEvents lblLocNoisudung As System.Windows.Forms.Label
    Friend WithEvents grpTimkiem As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LblTimtheomasopt As System.Windows.Forms.Label
    Friend WithEvents txtGiatritim As Commons.utcTextBox
    Friend WithEvents cboTimtheo As Commons.UtcComboBox
    Friend WithEvents lblGiatritim As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cbxClass As Commons.UtcComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
