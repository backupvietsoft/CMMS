Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.ViewInfo
Imports Microsoft.ApplicationBlocks.Data

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim uc As New Commons.frmrptHieuSuatSuDungMay()
        Dim uc As New Commons.frmrptDanhsach_VTPT()
        Controls.Add(uc)
        uc.Dock = DockStyle.Fill
        'Commons.Modules.ObjSystems.MAutoCompleteTextEdit(txt, "SELECT DISTINCT MS_MAY FROM MAY union SELECT DISTINCT MS_MAY FROM MAY ORDER BY MS_MAY ", "MS_MAY")
        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM dbo.NGUYEN_NHAN_DUNG_MAY"))
        Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl1, GridView1, dt, False, False, True, True, True, Me.Name)
    End Sub

    Private Sub Form1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDoubleClick
        If Form.ModifierKeys = Keys.Control And Form.ModifierKeys = Keys.Shift And e.Button = MouseButtons.Left Then
            Dim sText As String = ""
            sText = XtraInputBox.Show(sText, True)
        End If
    End Sub

    '''''Private Sub optBCao_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles optBCao.MouseDoubleClick
    '''''    'var cEdit = (RadioGroup)sender;
    '''''    '        RadioGroupViewInfo cInfo = (RadioGroupViewInfo)cEdit.GetViewInfo();
    '''''    Dim Ctl As RadioGroup

    '''''    Ctl = CType(sender, RadioGroup)


    '''''    Dim sText As String = ""
    '''''    sText = Ctl.Properties.Items(Ctl.SelectedIndex).Description


    '''''    sText = XtraInputBox.Show(sText, True)
    '''''    Dim sName As String = GetParentForm(Ctl).Name.ToString
    '''''End Sub

    '''''Public Function GetParentForm(parent As Control) As Form
    '''''    Dim form As Form = TryCast(parent, Form)
    '''''    If form IsNot Nothing Then
    '''''        Return form
    '''''    End If
    '''''    If parent IsNot Nothing Then
    '''''        Return GetParentForm(parent.Parent)
    '''''    End If
    '''''    Return Nothing
    '''''End Function

End Class