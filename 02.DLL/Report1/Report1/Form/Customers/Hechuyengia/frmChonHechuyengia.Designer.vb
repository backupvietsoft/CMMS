<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonHechuyengia
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBochon = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChon = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThuchien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.gvListChon = New System.Windows.Forms.DataGridView()
        Me.cCHON = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNOTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gvListChon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.gvListChon, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1070, 661)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1064, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Chọn Problem"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnBochon)
        Me.Panel1.Controls.Add(Me.btnChon)
        Me.Panel1.Controls.Add(Me.btnThuchien)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 635)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1064, 23)
        Me.Panel1.TabIndex = 1
        '
        'btnBochon
        '
        Me.btnBochon.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBochon.Location = New System.Drawing.Point(75, 0)
        Me.btnBochon.Name = "btnBochon"
        Me.btnBochon.Size = New System.Drawing.Size(75, 23)
        Me.btnBochon.TabIndex = 0
        Me.btnBochon.Text = "Bỏ chọn"
        '
        'btnChon
        '
        Me.btnChon.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnChon.Location = New System.Drawing.Point(0, 0)
        Me.btnChon.Name = "btnChon"
        Me.btnChon.Size = New System.Drawing.Size(75, 23)
        Me.btnChon.TabIndex = 0
        Me.btnChon.Text = "Chọn hết"
        '
        'btnThuchien
        '
        Me.btnThuchien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThuchien.Location = New System.Drawing.Point(914, 0)
        Me.btnThuchien.Name = "btnThuchien"
        Me.btnThuchien.Size = New System.Drawing.Size(75, 23)
        Me.btnThuchien.TabIndex = 0
        Me.btnThuchien.Text = "Thực hiện"
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(989, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 23)
        Me.btnThoat.TabIndex = 0
        Me.btnThoat.Text = "Thoát"
        '
        'gvListChon
        '
        Me.gvListChon.AllowUserToAddRows = False
        Me.gvListChon.AllowUserToDeleteRows = False
        Me.gvListChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gvListChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvListChon.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCHON, Me.cID, Me.cNAME, Me.cCODE, Me.cNOTE})
        Me.gvListChon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvListChon.Location = New System.Drawing.Point(3, 41)
        Me.gvListChon.Name = "gvListChon"
        Me.gvListChon.ReadOnly = True
        Me.gvListChon.RowHeadersWidth = 20
        Me.gvListChon.Size = New System.Drawing.Size(1064, 588)
        Me.gvListChon.TabIndex = 2
        '
        'cCHON
        '
        Me.cCHON.FillWeight = 30.45685!
        Me.cCHON.HeaderText = "CHON"
        Me.cCHON.Name = "cCHON"
        Me.cCHON.ReadOnly = True
        '
        'cID
        '
        Me.cID.HeaderText = "ID"
        Me.cID.Name = "cID"
        Me.cID.ReadOnly = True
        Me.cID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cID.Visible = False
        '
        'cNAME
        '
        Me.cNAME.FillWeight = 132.7151!
        Me.cNAME.HeaderText = "NAME"
        Me.cNAME.Name = "cNAME"
        Me.cNAME.ReadOnly = True
        '
        'cCODE
        '
        Me.cCODE.FillWeight = 136.828!
        Me.cCODE.HeaderText = "CODE"
        Me.cCODE.Name = "cCODE"
        Me.cCODE.ReadOnly = True
        '
        'cNOTE
        '
        Me.cNOTE.HeaderText = "NOTE"
        Me.cNOTE.Name = "cNOTE"
        Me.cNOTE.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 132.7151!
        Me.DataGridViewTextBoxColumn2.HeaderText = "NAME"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 231
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 136.828!
        Me.DataGridViewTextBoxColumn3.HeaderText = "CODE"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 238
        '
        'frmChonHechuyengia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 661)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmChonHechuyengia"
        Me.Text = "ftmChonHechuyengia"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.gvListChon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents gvListChon As System.Windows.Forms.DataGridView
    Friend WithEvents btnBochon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThuchien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCHON As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNOTE As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
