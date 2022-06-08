Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports Microsoft.ApplicationBlocks.Data

Public Class Hyperlink

    Private Shared Function GetParentForm(parent As Control) As Form
        Dim form As Form = TryCast(parent, Form)
        If form IsNot Nothing Then
            Return form
        End If
        If parent IsNot Nothing Then
            Return GetParentForm(parent.Parent)
        End If
        Return Nothing
    End Function

    Private Shared Function GetParentForm(parent As Control, formName As String) As Form
        Dim frm As Form = TryCast(parent, Form)
        If frm IsNot Nothing Then
            If frm.Name = formName Then
                Return frm
            End If
        End If
        If parent IsNot Nothing Then
            Return GetParentForm(parent.Parent, formName)
        End If
        Return frm
    End Function

    Public Shared Sub ToPhieuBaoTri(ByVal form As Form, ByVal msPBT As String)
        If msPBT = "" Then Return
        Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'MnuPhieuBaoTri' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If (dt.Rows.Count = 0) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Commons.Modules.PermisString = Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "FrmPhieuBaoTri_New")
        Dim frmMain As Form = GetParentForm(form.Parent, "frmMain")
        Dim frmPBT As FrmPhieuBaoTri_New
        Try
            For Each frm As Form In frmMain.MdiChildren
                If frm.Name.ToLower().Equals("frmphieubaotri_new") Then
                    frmPBT = TryCast(frm, FrmPhieuBaoTri_New)
                    frmPBT.sMsPBTLink = msPBT
                    frmPBT.Activate()
                    Return
                End If
            Next
        Catch ex As Exception

        End Try

        frmPBT = New FrmPhieuBaoTri_New()
        frmPBT.MdiParent = frmMain
        frmPBT.WindowState = FormWindowState.Maximized
        frmPBT.sMsPBTLink = msPBT
        frmPBT.Show()
    End Sub

    Public Shared Sub ToGSTT(ByVal form As Form, ByVal msTS As String)
        If msTS = "" Then Return
        Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'mnuThongsoGSTT' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If (dt.Rows.Count = 0) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim frmThongsoGSTT As frmThongsoGSTT
        Commons.Modules.PermisString = Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "frmThongsoGSTT")
        Dim frmMain As Form = GetParentForm(form.Parent, "frmMain")

        Try
            For Each frmChild As Form In frmMain.MdiChildren
                If (frmChild.Name.ToLower().Equals("frmthongsogstt")) Then
                    frmThongsoGSTT = TryCast(frmChild, frmThongsoGSTT)
                    frmThongsoGSTT.MS_GS_TT = msTS
                    frmThongsoGSTT.LOAI_TS = False
                    frmThongsoGSTT.Activate()
                    frmThongsoGSTT.findThongSo()
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
        frmThongsoGSTT = New frmThongsoGSTT()
        frmThongsoGSTT.MS_GS_TT = msTS
        frmThongsoGSTT.LOAI_TS = True
        frmThongsoGSTT.MdiParent = frmMain
        frmThongsoGSTT.WindowState = FormWindowState.Maximized
        frmThongsoGSTT.Show()
    End Sub

    Public Shared Sub ToGSTTDL(ByVal form As Form, ByVal msTS As String)
        If msTS = "" Then Return
        Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'mnuThongsoGSTT' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If (dt.Rows.Count = 0) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim frmThongsoGSTT As frmThongsoGSTT
        Commons.Modules.PermisString = Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "frmThongsoGSTT")
        Dim frmMain As Form = GetParentForm(form.Parent, "frmMain")

        Try
            For Each frmChild As Form In frmMain.MdiChildren
                If (frmChild.Name.ToLower().Equals("frmthongsogstt")) Then
                    frmThongsoGSTT = TryCast(frmChild, frmThongsoGSTT)
                    frmThongsoGSTT.MS_GS_TT = msTS
                    frmThongsoGSTT.LOAI_TS = True
                    frmThongsoGSTT.Activate()
                    frmThongsoGSTT.findThongSo()
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
        frmThongsoGSTT = New frmThongsoGSTT()
        frmThongsoGSTT.MS_GS_TT = msTS
        frmThongsoGSTT.LOAI_TS = False
        frmThongsoGSTT.MdiParent = frmMain
        frmThongsoGSTT.WindowState = FormWindowState.Maximized
        frmThongsoGSTT.Show()
    End Sub

    Public Shared Sub ToMay(ByVal form As Form, ByVal msMAY As String)
        If msMAY = "" Then Return
        Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'mnuEquipmentInformation' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
        Dim DT As New DataTable
        DT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If (DT.Rows.Count = 0) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Commons.Modules.PermisString = Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "frmThongtinthietbi")
        Dim frmThongtinthietbi As frmThongtinthietbi
        Dim frmMain As Form = GetParentForm(form.Parent, "frmMain")
        Try
            For Each frmChild As Form In frmMain.MdiChildren
                If (frmChild.Name.ToLower().Equals("frmthongtinthietbi")) Then
                    frmThongtinthietbi = TryCast(frmChild, frmThongtinthietbi)
                    frmThongtinthietbi.MSMAY = msMAY
                    frmThongtinthietbi.Activate()
                    frmThongtinthietbi.txtTimMay.Text = msMAY
                    frmThongtinthietbi.LocDuLieu()
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
        frmThongtinthietbi = New frmThongtinthietbi()
        frmThongtinthietbi.MSMAY = msMAY
        frmThongtinthietbi.MdiParent = frmMain
        frmThongtinthietbi.WindowState = FormWindowState.Maximized
        frmThongtinthietbi.Show()
    End Sub

    Public Shared Sub ToPhuTung(ByVal form As Form, ByVal msPT As String)
        If msPT = "" Then Return
        Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'mnuSparePart' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If (dt.Rows.Count = 0) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If '
        Dim frmDanhmucphutung_CS As frmDanhmucphutung_CS
        Commons.Modules.PermisString = Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "frmDanhmucphutung_CS")
        Dim frmMain As Form = GetParentForm(form.Parent, "frmMain")
        Try
            For Each frmChild As Form In frmMain.MdiChildren
                If (frmChild.Name.ToLower().Equals("frmdanhmucphutung_cs")) Then
                    frmDanhmucphutung_CS = TryCast(frmChild, frmDanhmucphutung_CS)
                    frmDanhmucphutung_CS.MSPT = msPT
                    frmDanhmucphutung_CS.Activate()
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
        frmDanhmucphutung_CS = New frmDanhmucphutung_CS()
        frmDanhmucphutung_CS.MSPT = msPT
        frmDanhmucphutung_CS.MdiParent = frmMain
        frmDanhmucphutung_CS.WindowState = FormWindowState.Maximized
        frmDanhmucphutung_CS.Show()
    End Sub

    Public Shared Sub ToCongViec(ByVal form As Form, ByVal msCV As String)
        If msCV = "" Then Return
        Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'mnuWork' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
        Dim dt As New DataTable

        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If (dt.Rows.Count = 0) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Commons.Modules.PermisString = Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "frmDanhmuccongviec")
        Dim frmMain As Form = GetParentForm(form.Parent, "frmMain")
        Dim frmDanhmuccongviec As MVControl.frmDanhmuccongviec

        Try
            For Each frmChild As Form In frmMain.MdiChildren
                If (frmChild.Name.ToLower().Equals("frmdanhmuccongviec")) Then
                    frmDanhmuccongviec = TryCast(frmChild, MVControl.frmDanhmuccongviec)
                    frmDanhmuccongviec.MS_CVIEC = msCV
                    frmDanhmuccongviec.Activate()
                    frmDanhmuccongviec.findCongViec()
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
        frmDanhmuccongviec = New MVControl.frmDanhmuccongviec()
        frmDanhmuccongviec.MS_CVIEC = msCV
        frmDanhmuccongviec.MdiParent = frmMain
        frmDanhmuccongviec.WindowState = FormWindowState.Maximized
        frmDanhmuccongviec.Show()
    End Sub

    Public Shared Sub ToTiepNhanYC(ByVal form As Form, ByVal msmay As String, ByVal fromday As DateTime, ByVal today As DateTime)
        If msmay = "" Then Return
        Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'mnuYeucauNSD_DBT' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
        Dim dt As New DataTable

        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If (dt.Rows.Count = 0) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Commons.Modules.PermisString = Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "frmYeuCauBT")
        Dim frmMain As Form = GetParentForm(form.Parent, "frmMain")
        Dim frmYCBT As frmYeuCauBT
        Try
            For Each frmChild As Form In frmMain.MdiChildren
                If (frmChild.Name.ToLower().Equals("frmYeuCauBT")) Then
                    frmYCBT = TryCast(frmChild, frmYeuCauBT)
                    'frmYCBT.msm = msCV
                    frmYCBT.Activate()
                    frmYCBT.FindForm()
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
        frmYCBT = New frmYeuCauBT()
        frmYCBT.MdiParent = frmMain
        frmYCBT.WindowState = FormWindowState.Maximized
        frmYCBT.Show()
    End Sub

End Class
