
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Convert
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Public Class frmNguyenNhanDungMay
    Public baotri As String = String.Empty
    Private bThem As Boolean = False

    Private Sub frmNguyenNhanDungMay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Commons.Modules.ObjSystems.DinhDang()
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            BindData()
            LockData(True)
            VisibleButton(True)
            Dim sTmp As String
            sTmp = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "frmNguyenNhanDungMay")
            If sTmp.Equals("Read only") Then
                BtnThem.Enabled = False
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub BindData()
        GrdDanhmucnguyennhan.DataSource = New clsNGUYEN_NHAN_DUNG_MAYController().GetNGUYEN_NHAN_DUNG_MAYs()
        GrdDanhmucnguyennhan.Columns("MS_NGUYEN_NHAN").Visible = False
        If GrdDanhmucnguyennhan.Rows.Count = 0 Then
            BtnSua.Enabled = False
            BtnXoa.Enabled = False
        Else
            BtnSua.Enabled = True
            BtnXoa.Enabled = True
        End If
        Me.GrdDanhmucnguyennhan.Columns("TEN_NGUYEN_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_NGUYEN_NHAN", commons.Modules.TypeLanguage)
        Me.GrdDanhmucnguyennhan.Columns("hu_hong").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "hu_hong", commons.Modules.TypeLanguage)
        Me.GrdDanhmucnguyennhan.Columns("BTDK").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BTDK", Commons.Modules.TypeLanguage)
        Me.GrdDanhmucnguyennhan.Columns("MAC_DINH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MAC_DINH", Commons.Modules.TypeLanguage)
        Try
            Me.GrdDanhmucnguyennhan.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.GrdDanhmucnguyennhan.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try

        Me.GrdDanhmucnguyennhan.Columns("hu_hong").Width = 100
        Me.GrdDanhmucnguyennhan.Columns("BTDK").Width = 100
        Me.GrdDanhmucnguyennhan.Columns("MAC_DINH").Width = 100
        Me.GrdDanhmucnguyennhan.Columns("MAC_DINH").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

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
        txtNguyennhan.Properties.ReadOnly = blnLock
        CHKHUHONG.Enabled = Not blnLock
        chkBTDK.Enabled = Not blnLock
        chkMacDinh.Enabled = Not blnLock
        Me.GrdDanhmucnguyennhan.Enabled = blnLock
    End Sub

    Sub ShowData(ByVal intRow As Integer)
        txtMS_NGUYEN_NHAN.Text = GrdDanhmucnguyennhan.Rows(intRow).Cells("MS_NGUYEN_NHAN").Value
        txtNguyennhan.Text = GrdDanhmucnguyennhan.Rows(intRow).Cells("TEN_NGUYEN_NHAN").Value

        If GrdDanhmucnguyennhan.Rows(intRow).Cells("hu_hong").Value.ToString = "True" Then
            Me.CHKHUHONG.Checked = True
        Else
            Me.CHKHUHONG.Checked = False
        End If

        If GrdDanhmucnguyennhan.Rows(intRow).Cells("BTDK").Value.ToString = "True" Then
            chkBTDK.Checked = True
        Else
            chkBTDK.Checked = False
        End If

        If GrdDanhmucnguyennhan.Rows(intRow).Cells("MAC_DINH").Value.ToString = "True" Then
            chkMacDinh.Checked = True
        Else
            chkMacDinh.Checked = False
        End If
    End Sub
    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        VisibleButton(False)
        LockData(False)
        txtNguyennhan.Text = ""
        Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu = ""
        bThem = True
        txtMS_NGUYEN_NHAN.Text = -1
        Me.CHKHUHONG.Checked = False
        chkBTDK.Checked = False
        chkMacDinh.Checked = False
        AddHandler txtNguyennhan.Validating, AddressOf Me.txtNguyennhan_Validating
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        RemoveHandler txtNguyennhan.Validating, AddressOf Me.txtNguyennhan_Validating
        Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu = ""
        BindData()
        VisibleButton(True)
        LockData(True)

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If txtNguyennhan.Text.ToString().Trim() = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTen", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtNguyennhan.Focus()
            Exit Sub
        End If

        If CHKHUHONG.Checked = True And chkBTDK.Checked = True Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "KHONG_CHON_CA_HAI", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If


        Dim tmp As Integer
        Try
            tmp = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) FROM NGUYEN_NHAN_DUNG_MAY WHERE MAC_DINH = 1 AND MS_NGUYEN_NHAN <> " + txtMS_NGUYEN_NHAN.Text))
            If tmp > 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChiDuocChonMotNguyenNhanMacDinh", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Catch ex As Exception
        End Try


        Dim objNguyenNhan As New clsNGUYEN_NHAN_DUNG_MAYController()
        Dim huhong As Integer, btdk As Integer

        If Me.CHKHUHONG.Checked = True Then
            huhong = 1
        Else
            huhong = 0
        End If
        If Me.chkBTDK.Checked = True Then
            btdk = 1
        Else
            btdk = 0
        End If



        If bThem Then
            Dim msNguyenNhan As Integer = objNguyenNhan.AddNGUYEN_NHAN_DUNG_MAY(txtNguyennhan.Text.Trim(), huhong, btdk)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_NGUYEN_NHAN_DUNG_MAY_LOG", msNguyenNhan, Me.Name, Commons.Modules.UserName, 1)
        Else
            tmp = txtMS_NGUYEN_NHAN.Text
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_NGUYEN_NHAN_DUNG_MAY_LOG", txtMS_NGUYEN_NHAN.Text, Me.Name, Commons.Modules.UserName, 2)
            objNguyenNhan.UpdateNGUYEN_NHAN_DUNG_MAY(txtMS_NGUYEN_NHAN.Text, txtNguyennhan.Text.Trim(), huhong, btdk)
        End If

        If Me.chkMacDinh.Checked = True Then
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE NGUYEN_NHAN_DUNG_MAY SET MAC_DINH = 1 WHERE MS_NGUYEN_NHAN = " + txtMS_NGUYEN_NHAN.Text)
        Else
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE NGUYEN_NHAN_DUNG_MAY SET MAC_DINH = 0 WHERE MS_NGUYEN_NHAN = " + txtMS_NGUYEN_NHAN.Text)
        End If

        If Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu <> "" Then
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE NGUYEN_NHAN_DUNG_MAY SET TEN_NGUYEN_NHAN_ANH = N'" + Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu + "' WHERE MS_NGUYEN_NHAN = " + txtMS_NGUYEN_NHAN.Text)
        End If
        Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu = ""

        BindData()
        If Not bThem Then
            For i As Integer = 0 To GrdDanhmucnguyennhan.Rows.Count - 1
                If GrdDanhmucnguyennhan.Rows(i).Cells("MS_NGUYEN_NHAN").Value = tmp Then
                    GrdDanhmucnguyennhan.CurrentCell() = GrdDanhmucnguyennhan.Rows(i).Cells("TEN_NGUYEN_NHAN")
                    GrdDanhmucnguyennhan.Focus()
                    Exit For
                End If
            Next
        End If
        bThem = False
        VisibleButton(True)
        LockData(True)
        RemoveHandler txtNguyennhan.Validating, AddressOf Me.txtNguyennhan_Validating
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        If (String.IsNullOrEmpty(baotri)) Then
            Me.Close()
        Else
            Try
                baotri = Convert.ToString(GrdDanhmucnguyennhan.CurrentRow.Cells("MS_Nguyen_nhan").Value)
                Me.Close()
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChonNN", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End Try

        End If

    End Sub

    Private Sub BtnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If GrdDanhmucnguyennhan.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_NGUYEN_NHAN FROM THOI_GIAN_NGUNG_MAY WHERE MS_NGUYEN_NHAN=" & txtMS_NGUYEN_NHAN.Text)
        While objReader.Read
            If objReader.Item("MS_NGUYEN_NHAN").ToString <> "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDuocSD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()
        Dim traloi As String = ""
        traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text)
        If traloi = vbYes Then
            Dim objNguyenNhan As New clsNGUYEN_NHAN_DUNG_MAYController()
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_NGUYEN_NHAN_DUNG_MAY_LOG", txtMS_NGUYEN_NHAN.Text, Me.Name, Commons.Modules.UserName, 3)
            objNguyenNhan.DeleteNGUYEN_NHAN_DUNG_MAY(txtMS_NGUYEN_NHAN.Text)
            Try


            Catch ex As Exception

            End Try
            BindData()
        End If
    End Sub

    Private Sub GrdDanhmucnguyennhan_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhmucnguyennhan.RowEnter
        ShowData(e.RowIndex)
    End Sub

    Private Sub txtNguyennhan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNguyennhan.Validating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        Dim objNguyenNhanDung As New clsNGUYEN_NHAN_DUNG_MAYController()
        If bThem Then
            If objNguyenNhanDung.CheckNGUYEN_NHAN_DUNG_MAY(0, txtNguyennhan.Text.Trim(), 0) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTen", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtNguyennhan.Focus()
                Exit Sub
            End If
        Else
            If objNguyenNhanDung.CheckNGUYEN_NHAN_DUNG_MAY(txtMS_NGUYEN_NHAN.Text, txtNguyennhan.Text.Trim(), 1) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTen", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtNguyennhan.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub BtnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        bThem = False
        VisibleButton(False)
        LockData(False)
        txtNguyennhan.Focus()
        AddHandler txtNguyennhan.Validating, AddressOf Me.txtNguyennhan_Validating
    End Sub

    Private Sub txtNguyennhan_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtNguyennhan.ButtonClick
        If txtMS_NGUYEN_NHAN.Text.Trim = "" Then Exit Sub
        Dim sLoi As String = ""
        'If BtnGhi.Visible = False Then
        If Vietsoft.MCapNhapNgonNguAnhHoa.Update(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblfrmNguyenNhanNgungMayAnh", Commons.Modules.TypeLanguage),
                                                     "NGUYEN_NHAN_DUNG_MAY", "TEN_NGUYEN_NHAN_ANH", " WHERE MS_NGUYEN_NHAN = " + txtMS_NGUYEN_NHAN.Text, sLoi) = False Then
            MessageBox.Show(sLoi)
        End If
        'End If
    End Sub

    Private Sub txtNguyennhan_EditValueChanged(sender As Object, e As EventArgs) Handles txtNguyennhan.EditValueChanged

    End Sub
End Class