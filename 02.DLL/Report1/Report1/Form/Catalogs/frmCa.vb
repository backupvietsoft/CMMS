

Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Convert
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Utils

'public partial class frmDanhmuccongviec : XtraForm
Public Class frmCa

    Private bThem As Boolean = False
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Commons.Modules.ObjSystems.DinhDang()
            flag = True
            BindData()
            flag = False
            LockData(True)
            VisibleButton(True)

            If Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "frmCa").ToString().ToLower().Trim().Equals("read only") Then
                BtnThem.Enabled = False
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub


    Sub Refesh()
        txtSTT.Text = ""
        txtCA.Text = ""
        TETuGio.EditValue = "00:00"
        TEDenGio.EditValue = "00:00:00"

    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        txtCA.Properties.ReadOnly = blnLock
        txtCA.Enabled = Not blnLock
        TEDenGio.Enabled = Not blnLock
        TETuGio.Enabled = Not blnLock
        grdCA.Enabled = blnLock

    End Sub

    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        btnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongGhi.Visible = Not blnVisible
    End Sub

    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        VisibleButton(False)
        LockData(False)
        txtCA.Text = ""
        Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu = ""
        bThem = True
        txtSTT.Text = -1
        txtCA.Focus()
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongGhi.Click
        Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu = ""
        'BindData()
        VisibleButton(True)
        LockData(True)
        ShowData(grvCA.FocusedRowHandle)
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If txtCA.Text.Trim() = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTen", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtCA.Focus()
            Exit Sub
        End If
        Dim iID As Integer
        iID = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT ISNULL(COUNT(*),0) AS ICOUNT FROM dbo.CA WHERE STT <> " & txtSTT.Text & " AND CA = N'" & txtCA.Text.Trim() & "'"))
        If iID > 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTenCa", Commons.Modules.TypeLanguage))
            txtCA.Focus()
            Exit Sub
        End If



        If bThem Then
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO CA(CA,TU_GIO,DEN_GIO) values( N'" + txtCA.Text + "', '" + TETuGio.Text + "','" + TEDenGio.Text + "')")
        Else
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE CA SET CA = N'" + txtCA.Text + "', TU_GIO = '" + TETuGio.Text + "', DEN_GIO = '" + TEDenGio.Text + "' where STT = '" + txtSTT.Text + "'")
        End If


        If Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu <> "" Then
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE CA SET CA_ANH = N'" + Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu + "' WHERE STT = '" + txtSTT.Text + "'")
        End If
        Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu = ""

        BindData()

        bThem = False
        VisibleButton(True)
        LockData(True)
        ShowData(grvCA.FocusedRowHandle)
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grvCA.RowCount = 0 Then
            Exit Sub
        End If

        Dim traloi As String = ""
        traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaCa", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text)
        If traloi = vbYes Then

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM CA WHERE STT = '" + grvCA.GetFocusedDataRow()("STT").ToString + "'")

            BindData()
        End If
    End Sub
    Sub ShowData(ByVal intRow As Integer)
        If grvCA.RowCount = 0 Then Exit Sub
        If IsDBNull(grdCA.DataSource) Then Exit Sub

        Refesh()
        txtSTT.Text = grvCA.GetRowCellValue(intRow, "STT").ToString
        txtCA.Text = grvCA.GetRowCellValue(intRow, "CA").ToString
        TETuGio.EditValue = grvCA.GetRowCellValue(intRow, "TU_GIO")
        TEDenGio.EditValue = grvCA.GetRowCellValue(intRow, "DEN_GIO")
    End Sub

    Private Sub BtnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        bThem = False
        VisibleButton(False)
        LockData(False)
        txtCA.Focus()
    End Sub

    Dim flag As Boolean = False
    Sub BindData()
        Dim dtTmp As New DataTable

        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_CA", Commons.Modules.TypeLanguage))

        If flag = vbTrue Then
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCA, grvCA, dtTmp, False, True, True, True, True, "")
        Else
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCA, grvCA, dtTmp, False, False, True, True, True, "")
        End If

        If grvCA.RowCount = 0 Then
            BtnSua.Enabled = False
            BtnXoa.Enabled = False
        Else
            BtnSua.Enabled = True
            BtnXoa.Enabled = True
        End If

        grvCA.Columns("TU_GIO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        grvCA.Columns("TU_GIO").DisplayFormat.FormatString = "HH:mm"
        grvCA.Columns("DEN_GIO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        grvCA.Columns("DEN_GIO").DisplayFormat.FormatString = "HH:mm"


        grvCA.Columns("STT").Visible = False

    End Sub




    Private Sub BtnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub txtNguyennhan_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtCA.ButtonClick
        If txtCA.Text.Trim = "" Then Exit Sub
        Dim sLoi As String = ""
        'If BtnGhi.Visible = False Then
        If Vietsoft.MCapNhapNgonNguAnhHoa.Update(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblfrmCA", Commons.Modules.TypeLanguage),
                                                     "CA", "CA_ANH", " WHERE CA = " + txtCA.Text + "AND STT = " + txtSTT.Text + "'", sLoi) = False Then
            MessageBox.Show(sLoi)
        End If
        'End If
    End Sub

    Private Sub grdCA_FocusedRowChanged(sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvCA.FocusedRowChanged
        Try
            If grvCA.RowCount = 0 Then Exit Sub
            If IsDBNull(grdCA.DataSource) Then Exit Sub

            ShowData(e.FocusedRowHandle)
        Catch ex As Exception
        End Try
    End Sub

End Class