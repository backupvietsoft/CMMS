
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons

Public Class frmQuocGia

    Private ghi As Boolean
    Private maqg As String
    Private index As Integer
    Private vList As New DataTable()

    Private Sub frmQuocGia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnableButton(True)
        formatgrdList()
        BindData()
        InitData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        If Me.GrdDanhsach.RowCount > 0 Then
            Me.GrdDanhsach.Rows(0).Selected = True
        End If

    End Sub

    Private Sub InitData()
        TxtMaquocgia.DataBindings.Clear()
        TxtMaquocgia.DataBindings.Add("text", vList, "MA_QG", True, DataSourceUpdateMode.OnPropertyChanged)

        TxtTenquocgia.DataBindings.Clear()
        TxtTenquocgia.DataBindings.Add("text", vList, "TEN_QG", True, DataSourceUpdateMode.OnPropertyChanged)

    End Sub

    'Định dạng Gridview danh sách PO
    Sub formatgrdList()
        Dim cl1 As New DataGridViewTextBoxColumn()
        cl1.Name = "MA_QG"
        cl1.DataPropertyName = "MA_QG"
        cl1.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MA_QG", Commons.Modules.TypeLanguage)
        GrdDanhsach.Columns.Insert(0, cl1)

        Dim cl2 As New DataGridViewTextBoxColumn()
        cl2.Name = "TEN_QG"
        cl2.DataPropertyName = "TEN_QG"
        cl2.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_QG", Commons.Modules.TypeLanguage)
        GrdDanhsach.Columns.Insert(1, cl2)

        GrdDanhsach.AutoGenerateColumns = False
    End Sub

    Sub BindData()
        Try
            vList.Rows.Clear()
            vList.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetQUOC_GIAs"))
            GrdDanhsach.DataSource = vList
            'GrdDanhsach.Columns(0).Width = 5
            'GrdDanhsach.Columns(1).Width = 5
            Me.GrdDanhsach.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.GrdDanhsach.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2


        Catch ex As Exception
        End Try

        If Me.GrdDanhsach.RowCount > 0 Then
            Me.BtnSua.Enabled = True
            Me.BtnXoa.Enabled = True
        Else
            Me.BtnSua.Enabled = False
            Me.BtnXoa.Enabled = False
        End If
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        End If
    End Sub

    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
    End Sub

    Sub LockData(ByVal blnLock As Boolean)
        TxtMaquocgia.ReadOnly = blnLock
        TxtTenquocgia.ReadOnly = blnLock
        GrdDanhsach.Enabled = blnLock
    End Sub

    Private Sub RefeshLanguage()
        Me.LblMa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, LblMa.Name, Commons.Modules.TypeLanguage)
        Me.LblTen.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, LblTen.Name, Commons.Modules.TypeLanguage)
        Me.LblTieudequocgia.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, LblTieudequocgia.Name, Commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnGhi.Name, Commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, Commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnSua.Name, Commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThem.Name, Commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThoat.Name, Commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnXoa.Name, Commons.Modules.TypeLanguage)
        Me.GrpNhapqg.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, GrpNhapqg.Name, Commons.Modules.TypeLanguage)
        Me.GrpDanhsach.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, GrpDanhsach.Name, Commons.Modules.TypeLanguage)

        Me.GrdDanhsach.Columns("MA_QG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MA_QG", Commons.Modules.TypeLanguage)
        Me.GrdDanhsach.Columns("TEN_QG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_QG", Commons.Modules.TypeLanguage)
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub

#Region "Data Info"

    Public Function GetQUOC_GIAs() As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetQUOC_GIAs"))
        Return objDataTable
    End Function

    Public Function GetQUOC_GIA(ByVal ID As Integer) As QUOC_GIA_Info
        Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetQUOCGIA", ID)
        Dim objQUOC_GIA_Info As New QUOC_GIA_Info
        While objDataReader.Read
            objQUOC_GIA_Info.MA_QG = objDataReader.Item("MA_QG")
            objQUOC_GIA_Info.TEN_QG = objDataReader.Item("TEN_QG")

        End While
        objDataReader.Close()
        Return objQUOC_GIA_Info
    End Function

    Public Function AddQUOC_GIA(ByVal objQUOC_GIA_Info As QUOC_GIA_Info) As Integer
        Return SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddQUOC_GIA", _
            objQUOC_GIA_Info.MA_QG, objQUOC_GIA_Info.TEN_QG)

    End Function

    Public Function UpdateQUOC_GIA(ByVal objQUOC_GIA_Info As QUOC_GIA_Info) As Integer
        Return SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateQUOC_GIAs", _
            objQUOC_GIA_Info.MA_QG, objQUOC_GIA_Info.TEN_QG)
        Return UpdateQUOC_GIA(objQUOC_GIA_Info, String.Empty)
    End Function

    Public Function UpdateQUOC_GIA(ByVal objQUOC_GIA_Info As QUOC_GIA_Info, ByVal MA_QG As String) As Integer
        Return SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateQUOC_GIAs", MA_QG, objQUOC_GIA_Info.MA_QG, objQUOC_GIA_Info.TEN_QG)
    End Function

    Public Function DeleteQUOC_GIA(ByVal QUOC_GIA As String) As Integer
        Return SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteQUOC_GIA", QUOC_GIA)
    End Function

    Public Function CheckQUOC_GIA(ByVal QUOC_GIA As String) As SqlDataReader
        Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckQUOC_GIA", QUOC_GIA)
    End Function
#End Region

    Private Sub frmQuocGia_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Dim j As Integer
        'For i As Integer = 0 To Me.GrpDanhsach.Rows.Count(-1)
        '    If Me.GrdDanhsach.Rows(i).Cells("MAC_DINH").Value = True Then
        '        j = j + 1
        '    End If
        'Next
        'If j < 1 And Me.GrdDanhsach.RowCount > 0 Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSELECT_NT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        ghi = True
        Try
            index = GrdDanhsach.CurrentRow.Index
        Catch ex As Exception
            index = -1
        End Try
        VisibleButton(False)
        LockData(False)
        TxtMaquocgia.Focus()
        TxtMaquocgia.Text = ""
        TxtTenquocgia.Text = ""
        GrdDanhsach.Enabled = False
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        If TxtMaquocgia.Text <> String.Empty Then
            Try
                index = GrdDanhsach.CurrentRow.Index
            Catch ex As Exception
                index = -1
            End Try
            ghi = False
            VisibleButton(False)
            LockData(False)
            maqg = TxtMaquocgia.Text.Trim
            TxtMaquocgia.Focus()
            GrdDanhsach.Enabled = False
        End If
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If GrdDanhsach.RowCount <= 0 Then
            MsgBox("Không có dữ liệu để xóa !", MsgBoxStyle.OkOnly, "Thông báo")
            Exit Sub
        End If

        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim result = DeleteQUOC_GIA(TxtMaquocgia.Text)
            If result > 0 Then
                For Each vRow As DataRow In vList.Rows
                    If (vRow("MA_QG").ToString().Trim().Equals(GrdDanhsach.CurrentRow.Cells("MA_QG").Value.ToString().Trim())) Then
                        vList.Rows.Remove(vRow)
                        Exit For
                    End If
                Next
                vList.AcceptChanges()
            Else
                MsgBox("Không thể xóa quốc gia này!", MsgBoxStyle.OkOnly, "Thông báo")
            End If
            'BindData()
        End If
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Try
            If TxtMaquocgia.Text.Trim = String.Empty Then
                MsgBox("Mã quốc gia không thể để trống!", MsgBoxStyle.OkOnly, "Thông báo")
                TxtMaquocgia.Focus()
                Return
            End If
            If TxtTenquocgia.Text.Trim = String.Empty Then
                MsgBox("Tên quốc gia không thể để trống!", MsgBoxStyle.OkOnly, "Thông báo")
                TxtTenquocgia.Focus()
                Return
            End If
            Dim SQL_TMP As String = "SELECT MA_QG FROM IC_QUOC_GIA WHERE MA_QG = '" & TxtMaquocgia.Text.Replace("'", "''") & "'"
            Dim dttmp As DataTable = New DataTable
            dttmp = (SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)).Tables(0)
            If ghi = True Then 'add
                If dttmp.Rows.Count <= 0 Then
                    Dim objQUOC_GIA_Info As New QUOC_GIA_Info
                    objQUOC_GIA_Info.MA_QG = TxtMaquocgia.Text
                    objQUOC_GIA_Info.TEN_QG = TxtTenquocgia.Text
                    Dim result = AddQUOC_GIA(objQUOC_GIA_Info)
                    If result > 0 Then
                        BindData()
                    Else
                        vList.RejectChanges()
                        Return
                    End If
                Else
                    MsgBox("Mã quốc gia đã tồn tại!", MsgBoxStyle.OkOnly, "Thông báo")
                    TxtTenquocgia.Focus()
                    Return
                End If
            Else ' update
                Dim objQUOC_GIA_Info As New QUOC_GIA_Info
                objQUOC_GIA_Info.MA_QG = TxtMaquocgia.Text
                objQUOC_GIA_Info.TEN_QG = TxtTenquocgia.Text
                Dim result = UpdateQUOC_GIA(objQUOC_GIA_Info, maqg)
                If result >= 0 Then
                    vList.AcceptChanges()
                    BindData()
                Else
                    vList.RejectChanges()
                    TxtMaquocgia.Text = ""
                    TxtTenquocgia.Text = ""
                    If (index < GrdDanhsach.Rows.Count) And index >= 0 Then
                        GrdDanhsach.CurrentCell = GrdDanhsach.Rows(index).Cells(0)
                    End If
                End If
            End If
            GrdDanhsach.Enabled = True
            VisibleButton(True)
            LockData(True)
        Catch ex As Exception
            vList.RejectChanges()
        End Try
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Try
            BindData()
            If (index < GrdDanhsach.Rows.Count) And index >= 0 Then
                GrdDanhsach.CurrentCell = GrdDanhsach.Rows(index).Cells(0)
            End If
            VisibleButton(True)
            LockData(True)
            GrdDanhsach.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GrdDanhsach_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdDanhsach.RowHeaderMouseClick

        TxtMaquocgia.Text = GrdDanhsach.Rows(e.RowIndex).Cells("MA_QG").Value.ToString
        TxtTenquocgia.Text = GrdDanhsach.Rows(e.RowIndex).Cells("TEN_QG").Value.ToString
    End Sub
End Class


