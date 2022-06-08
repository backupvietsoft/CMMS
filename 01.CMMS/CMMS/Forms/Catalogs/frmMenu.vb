Imports DevExpress.XtraEditors
Imports Microsoft.ApplicationBlocks.Data

Imports VS.Object
Public Class frmMenu
    Private _MStatus As String = String.Empty
    Private _MSource As BindingSource = New BindingSource()
    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadSource()
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub
    Private Sub LoadSource()
        _MSource.DataSource = New MenuCtrl().GetAllMenu()
        dgvList.AutoGenerateColumns = False
        dgvList.DataSource = _MSource
        dgvList.Columns("clMENU_ID").DataPropertyName = "MENU_ID"
        dgvList.Columns("clMENU_IMAGE").DataPropertyName = "MENU_IMAGE"
        Select Case Commons.Modules.TypeLanguage
            Case 1
                dgvList.Columns("clMENU_TEXT").DataPropertyName = "MENU_ENGLISH"
            Case 2
                dgvList.Columns("clMENU_TEXT").DataPropertyName = "MENU_CHINESE"
            Case Else
                dgvList.Columns("clMENU_TEXT").DataPropertyName = "MENU_TEXT"
        End Select

        txtMENU_ID.DataBindings.Clear()
        txtMENU_ID.DataBindings.Add("Text", _MSource, "MENU_ID", False, DataSourceUpdateMode.OnPropertyChanged)
        txtMENU_INDEX.DataBindings.Clear()
        txtMENU_INDEX.DataBindings.Add("Text", _MSource, "MENU_INDEX", False, DataSourceUpdateMode.OnPropertyChanged)
        chkMENU_LINE.DataBindings.Clear()
        chkMENU_LINE.DataBindings.Add("Checked", _MSource, "MENU_LINE", False, DataSourceUpdateMode.OnPropertyChanged)
        txtMENU_TEXT.DataBindings.Clear()
        txtMENU_TEXT.DataBindings.Add("Text", _MSource, "MENU_TEXT", False, DataSourceUpdateMode.OnPropertyChanged)
        txtMENU_ENGLISH.DataBindings.Clear()
        txtMENU_ENGLISH.DataBindings.Add("Text", _MSource, "MENU_ENGLISH", False, DataSourceUpdateMode.OnPropertyChanged)
        txtMENU_CHINESE.DataBindings.Clear()
        txtMENU_CHINESE.DataBindings.Add("Text", _MSource, "MENU_CHINESE", False, DataSourceUpdateMode.OnPropertyChanged)
        cboMENU_PARENT.DataSource = New MenuCtrl().GetAllMenu()
        cboMENU_PARENT.ValueMember = "MENU_ID"
        Select Case Commons.Modules.TypeLanguage
            Case 1
                cboMENU_PARENT.DisplayMember = "MENU_ENGLISH"
            Case 2
                cboMENU_PARENT.DisplayMember = "MENU_CHINESE"
            Case Else
                cboMENU_PARENT.DisplayMember = "MENU_TEXT"
        End Select
        cboMENU_PARENT.DataBindings.Add("SelectedValue", _MSource, "MENU_PARENT", False, DataSourceUpdateMode.OnPropertyChanged)
        cboSHORT_KEY.DataSource = GetShortcutKey()
        cboSHORT_KEY.ValueMember = "ID"
        cboSHORT_KEY.DisplayMember = "NAME"
        cboSHORT_KEY.DataBindings.Clear()
        cboSHORT_KEY.DataBindings.Add("SelectedValue", _MSource, "SHORT_KEY", False, DataSourceUpdateMode.OnPropertyChanged)
        txtDLL_NAME.DataBindings.Clear()
        txtDLL_NAME.DataBindings.Add("Text", _MSource, "DLL_NAME", False, DataSourceUpdateMode.OnPropertyChanged)
        txtPROJECT_NAME.DataBindings.Clear()
        txtPROJECT_NAME.DataBindings.Add("Text", _MSource, "PROJECT_NAME", False, DataSourceUpdateMode.OnPropertyChanged)
        txtCLASS_NAME.DataBindings.Clear()
        txtCLASS_NAME.DataBindings.Add("Text", _MSource, "CLASS_NAME", False, DataSourceUpdateMode.OnPropertyChanged)
        txtFUNCTION_NAME.DataBindings.Clear()
        txtFUNCTION_NAME.DataBindings.Add("Text", _MSource, "FUNCTION_NAME", False, DataSourceUpdateMode.OnPropertyChanged)
        txtMENU_NOTE.DataBindings.Clear()
        txtMENU_NOTE.DataBindings.Add("Text", _MSource, "MENU_NOTE", False, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Private Function GetShortcutKey() As DataTable
        Dim TbSource As DataTable = New DataTable()
        TbSource.Columns.Add("ID")
        TbSource.Columns.Add("NAME")
        TbSource.Rows.Add(DBNull.Value, "[None]")
        TbSource.Rows.Add("Alt0", "Alt0")
        TbSource.Rows.Add("Alt1", "Alt1")
        TbSource.Rows.Add("Alt2", "Alt2")
        TbSource.Rows.Add("Alt3", "Alt3")
        TbSource.Rows.Add("Alt4", "Alt4")
        TbSource.Rows.Add("Alt5", "Alt5")
        TbSource.Rows.Add("Alt6", "Alt6")
        TbSource.Rows.Add("Alt7", "Alt7")
        TbSource.Rows.Add("Alt8", "Alt8")
        TbSource.Rows.Add("Alt9", "Alt9")
        TbSource.Rows.Add("AltBksp", "AltBksp")
        TbSource.Rows.Add("AltDownArrow", "AltDownArrow")
        TbSource.Rows.Add("AltF1", "AltF1")
        TbSource.Rows.Add("AltF10", "AltF10")
        TbSource.Rows.Add("AltF11", "AltF11")
        TbSource.Rows.Add("AltF12", "AltF12")
        TbSource.Rows.Add("AltF2", "AltF2")
        TbSource.Rows.Add("AltF3", "AltF3")
        TbSource.Rows.Add("AltF4", "AltF4")
        TbSource.Rows.Add("AltF5", "AltF5")
        TbSource.Rows.Add("AltF6", "AltF6")
        TbSource.Rows.Add("AltF7", "AltF7")
        TbSource.Rows.Add("AltF8", "AltF8")
        TbSource.Rows.Add("AltF9", "AltF9")
        TbSource.Rows.Add("AltLeftArrow", "AltLeftArrow")
        TbSource.Rows.Add("AltRightArrow", "AltRightArrow")
        TbSource.Rows.Add("AltUpArrow", "AltUpArrow")
        TbSource.Rows.Add("Ctrl0", "Ctrl0")
        TbSource.Rows.Add("Ctrl1", "Ctrl1")
        TbSource.Rows.Add("Ctrl2", "Ctrl2")
        TbSource.Rows.Add("Ctrl3", "Ctrl3")
        TbSource.Rows.Add("Ctrl4", "Ctrl4")
        TbSource.Rows.Add("Ctrl5", "Ctrl5")
        TbSource.Rows.Add("Ctrl6", "Ctrl6")
        TbSource.Rows.Add("Ctrl7", "Ctrl7")
        TbSource.Rows.Add("Ctrl8", "Ctrl8")
        TbSource.Rows.Add("Ctrl9", "Ctrl9")
        TbSource.Rows.Add("CtrlA", "CtrlA")
        TbSource.Rows.Add("CtrlB", "CtrlB")
        TbSource.Rows.Add("CtrlC", "CtrlC")
        TbSource.Rows.Add("CtrlD", "CtrlD")
        TbSource.Rows.Add("CtrlDel", "CtrlDel")
        TbSource.Rows.Add("CtrlE", "CtrlE")
        TbSource.Rows.Add("CtrlF", "CtrlF")
        TbSource.Rows.Add("CtrlF1", "CtrlF1")
        TbSource.Rows.Add("CtrlF10", "CtrlF10")
        TbSource.Rows.Add("CtrlF11", "CtrlF11")
        TbSource.Rows.Add("CtrlF12", "CtrlF12")
        TbSource.Rows.Add("CtrlF2", "CtrlF2")
        TbSource.Rows.Add("CtrlF3", "CtrlF3")
        TbSource.Rows.Add("CtrlF4", "CtrlF4")
        TbSource.Rows.Add("CtrlF5", "CtrlF5")
        TbSource.Rows.Add("CtrlF6", "CtrlF6")
        TbSource.Rows.Add("CtrlF7", "CtrlF7")
        TbSource.Rows.Add("CtrlF8", "CtrlF8")
        TbSource.Rows.Add("CtrlF9", "CtrlF9")
        TbSource.Rows.Add("CtrlG", "CtrlG")
        TbSource.Rows.Add("CtrlH", "CtrlH")
        TbSource.Rows.Add("CtrlI", "CtrlI")
        TbSource.Rows.Add("CtrlIns", "CtrlIns")
        TbSource.Rows.Add("CtrlJ", "CtrlJ")
        TbSource.Rows.Add("CtrlK", "CtrlK")
        TbSource.Rows.Add("CtrlL", "CtrlL")
        TbSource.Rows.Add("CtrlM", "CtrlM")
        TbSource.Rows.Add("CtrlN", "CtrlN")
        TbSource.Rows.Add("CtrlO", "CtrlO")
        TbSource.Rows.Add("CtrlP", "CtrlP")
        TbSource.Rows.Add("CtrlQ", "CtrlQ")
        TbSource.Rows.Add("CtrlR", "CtrlR")
        TbSource.Rows.Add("CtrlS", "CtrlS")
        TbSource.Rows.Add("CtrlShift0", "CtrlShift0")
        TbSource.Rows.Add("CtrlShift1", "CtrlShift1")
        TbSource.Rows.Add("CtrlShift2", "CtrlShift2")
        TbSource.Rows.Add("CtrlShift3", "CtrlShift3")
        TbSource.Rows.Add("CtrlShift4", "CtrlShift4")
        TbSource.Rows.Add("CtrlShift5", "CtrlShift5")
        TbSource.Rows.Add("CtrlShift6", "CtrlShift6")
        TbSource.Rows.Add("CtrlShift7", "CtrlShift7")
        TbSource.Rows.Add("CtrlShift8", "CtrlShift8")
        TbSource.Rows.Add("CtrlShift9", "CtrlShift9")
        TbSource.Rows.Add("CtrlShiftA", "CtrlShiftA")
        TbSource.Rows.Add("CtrlShiftB", "CtrlShiftB")
        TbSource.Rows.Add("CtrlShiftC", "CtrlShiftC")
        TbSource.Rows.Add("CtrlShiftD", "CtrlShiftD")
        TbSource.Rows.Add("CtrlShiftE", "CtrlShiftE")
        TbSource.Rows.Add("CtrlShiftF", "CtrlShiftF")
        TbSource.Rows.Add("CtrlShiftF1", "CtrlShiftF1")
        TbSource.Rows.Add("CtrlShiftF10", "CtrlShiftF10")
        TbSource.Rows.Add("CtrlShiftF11", "CtrlShiftF11")
        TbSource.Rows.Add("CtrlShiftF12", "CtrlShiftF12")
        TbSource.Rows.Add("CtrlShiftF2", "CtrlShiftF2")
        TbSource.Rows.Add("CtrlShiftF3", "CtrlShiftF3")
        TbSource.Rows.Add("CtrlShiftF4", "CtrlShiftF4")
        TbSource.Rows.Add("CtrlShiftF5", "CtrlShiftF5")
        TbSource.Rows.Add("CtrlShiftF6", "CtrlShiftF6")
        TbSource.Rows.Add("CtrlShiftF7", "CtrlShiftF7")
        TbSource.Rows.Add("CtrlShiftF8", "CtrlShiftF8")
        TbSource.Rows.Add("CtrlShiftF9", "CtrlShiftF9")
        TbSource.Rows.Add("CtrlShiftG", "CtrlShiftG")
        TbSource.Rows.Add("CtrlShiftH", "CtrlShiftH")
        TbSource.Rows.Add("CtrlShiftI", "CtrlShiftI")
        TbSource.Rows.Add("CtrlShiftJ", "CtrlShiftJ")
        TbSource.Rows.Add("CtrlShiftK", "CtrlShiftK")
        TbSource.Rows.Add("CtrlShiftL", "CtrlShiftL")
        TbSource.Rows.Add("CtrlShiftM", "CtrlShiftM")
        TbSource.Rows.Add("CtrlShiftN", "CtrlShiftN")
        TbSource.Rows.Add("CtrlShiftO", "CtrlShiftO")
        TbSource.Rows.Add("CtrlShiftP", "CtrlShiftP")
        TbSource.Rows.Add("CtrlShiftQ", "CtrlShiftQ")
        TbSource.Rows.Add("CtrlShiftR", "CtrlShiftR")
        TbSource.Rows.Add("CtrlShiftS", "CtrlShiftS")
        TbSource.Rows.Add("CtrlShiftT", "CtrlShiftT")
        TbSource.Rows.Add("CtrlShiftU", "CtrlShiftU")
        TbSource.Rows.Add("CtrlShiftV", "CtrlShiftV")
        TbSource.Rows.Add("CtrlShiftW", "CtrlShiftW")
        TbSource.Rows.Add("CtrlShiftX", "CtrlShiftX")
        TbSource.Rows.Add("CtrlShiftY", "CtrlShiftY")
        TbSource.Rows.Add("CtrlShiftZ", "CtrlShiftZ")
        TbSource.Rows.Add("CtrlT", "CtrlT")
        TbSource.Rows.Add("CtrlU", "CtrlU")
        TbSource.Rows.Add("CtrlV", "CtrlV")
        TbSource.Rows.Add("CtrlW", "CtrlW")
        TbSource.Rows.Add("CtrlX", "CtrlX")
        TbSource.Rows.Add("CtrlY", "CtrlY")
        TbSource.Rows.Add("CtrlZ", "CtrlZ")
        TbSource.Rows.Add("Del", "Del")
        TbSource.Rows.Add("F1", "F1")
        TbSource.Rows.Add("F10", "F10")
        TbSource.Rows.Add("F12", "F12")
        TbSource.Rows.Add("F2", "F2")
        TbSource.Rows.Add("F3", "F3")
        TbSource.Rows.Add("F4", "F4")
        TbSource.Rows.Add("F5", "F5")
        TbSource.Rows.Add("F6", "F6")
        TbSource.Rows.Add("F7", "F7")
        TbSource.Rows.Add("F8", "F8")
        TbSource.Rows.Add("F9", "F9")
        TbSource.Rows.Add("Ins", "Ins")
        TbSource.Rows.Add("ShiftDel", "ShiftDel")
        TbSource.Rows.Add("ShiftF1", "ShiftF1")
        TbSource.Rows.Add("ShiftF10", "ShiftF10")
        TbSource.Rows.Add("ShiftF11", "ShiftF11")
        TbSource.Rows.Add("ShiftF12", "ShiftF12")
        TbSource.Rows.Add("ShiftF2", "ShiftF2")
        TbSource.Rows.Add("ShiftF3", "ShiftF3")
        TbSource.Rows.Add("ShiftF4", "ShiftF4")
        TbSource.Rows.Add("ShiftF5", "ShiftF5")
        TbSource.Rows.Add("ShiftF6", "ShiftF6")
        TbSource.Rows.Add("ShiftF7", "ShiftF7")
        TbSource.Rows.Add("ShiftF8", "ShiftF8")
        TbSource.Rows.Add("ShiftF9", "ShiftF9")
        TbSource.Rows.Add("ShiftIns", "ShiftIns")
        Return TbSource
    End Function
End Class