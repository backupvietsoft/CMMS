Imports Commons.VS.Object

Public Class frmPassword
    Private IsReset As Boolean = False
    Private Username As String = ""
    Private PassOld As String = ""
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal _Username As String, ByVal _passOld As String, ByVal IsResetPass As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        IsReset = IsResetPass
        PassOld = _passOld
        Username = _Username
    End Sub
    Private Sub frmPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If IsReset = True Then
            txtUsername.Text = Username
            txtPassOld.Text = PassOld
            txtPassOld.ReadOnly = True
            txtPassNew.Focus()
        Else
            txtUsername.Text = Commons.Modules.UserName
            txtPassOld.Text = ""
            txtPassOld.ReadOnly = False
            txtPassOld.Focus()
        End If

    End Sub
    Private Sub btnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnChange.Click
        Try
            Dim vUserInfo As Commons.IUsers = New UserCtrl().GetUser(txtUsername.Text.Trim())
            If (Not vUserInfo.Password.Equals(Commons.clsXuLy.MaHoaDL(txtPassOld.Text))) Then
                Commons.MssBox.Show(Me.Name, "MsgKhongTrungPass", Me.Text, MessageBoxIcon.Exclamation)
                txtPassOld.Focus()
                Return
            End If
            If (Not txtPassNew.Text.Trim.Equals(txtComfirmPass.Text)) Then
                Commons.MssBox.Show(Me.Name, "MsgKhongTrungPassCom", Me.Text, MessageBoxIcon.Exclamation)
                txtComfirmPass.Focus()
                Return
            End If
            vUserInfo.Password = Commons.clsXuLy.MaHoaDL(txtPassNew.Text)
            Dim vUserCtrl As UserCtrl = New UserCtrl()
            vUserCtrl.UpdateUser(vUserInfo)
            Commons.MssBox.Show(Me.Name, "MsgDoiMKThanhCong", Me.Text, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmPassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnChange_Click(sender, e)
        End If
    End Sub

    Private Sub tlMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tlMain.Paint

    End Sub
End Class