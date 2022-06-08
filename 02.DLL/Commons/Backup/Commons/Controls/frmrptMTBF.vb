Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptMTBF
    Public Shared baocao As Integer
    Public Shared tu As String
    Public Shared den As String
    Public Shared strNam As String

    Private Sub frmrptMTBF_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("NHOC_QUY")
        Commons.Modules.ObjSystems.XoaTable("NHOC_thang")
        Commons.Modules.ObjSystems.XoaTable("NHOC_NAM")
    End Sub
    Private Sub frmrptMTBF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtttuthang.Text = "01/" + DateTime.Now.Year.ToString()
        txtdenthang1.Text = "12/" + DateTime.Now.Year.ToString()
        txtTuNam_MTBF.Text = DateTime.Now.Year.ToString()
        txtDenNam_MTBF.Text = DateTime.Now.Year.ToString()
        txtTuQuy.Text = "1/" + DateTime.Now.Year.ToString()
        txtDenQuy.Text = "4/" + DateTime.Now.Year.ToString()
        cboInTheo.SelectedIndex = 0

        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDAY_CHUYEN", Commons.Modules.UserName))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        dt.Rows.InsertAt(row, 0)
        cbxDaychuyen.DataSource = dt
        cbxDaychuyen.ValueMember = "MS_HE_THONG"
        cbxDaychuyen.DisplayMember = "TEN_HE_THONG"
        cbxDaychuyen.Visible = False
        lbaDayChuyen.Visible = False
    End Sub

    Private Function Kiemtranhap(ByVal so As Integer) As Boolean
        Try

            Kiemtranhap = True
            If so = 0 Then
                Dim intTuQuy, intDenQuy, nam, nam1 As Integer
                intTuQuy = Convert.ToInt64(Microsoft.VisualBasic.Left(txtttuthang.Text, 2))
                intDenQuy = Convert.ToInt64(Microsoft.VisualBasic.Left(txtdenthang1.Text, 2))
                nam = Convert.ToInt64(Microsoft.VisualBasic.Right(txtdenthang1.Text, 4))
                nam1 = Convert.ToInt64(Microsoft.VisualBasic.Right(txtttuthang.Text, 4))
                If intTuQuy > 12 Or intDenQuy > 12 Then
                    Kiemtranhap = False
                    Exit Function
                End If
                If nam1 > nam Then
                    Kiemtranhap = False
                    Exit Function
                Else
                    If nam1 = nam Then
                        If intTuQuy > intDenQuy Then
                            Kiemtranhap = False
                            Exit Function
                        End If
                    End If
                End If
            End If
            If so = 1 Then
                Dim intTuQuy, intDenQuy, nam, nam1 As Integer
                intTuQuy = Convert.ToInt64(Microsoft.VisualBasic.Left(txtTuQuy.Text, 1))
                intDenQuy = Convert.ToInt64(Microsoft.VisualBasic.Left(txtDenQuy.Text, 1))
                nam = Convert.ToInt64(Microsoft.VisualBasic.Right(txtDenQuy.Text, 4))
                nam1 = Convert.ToInt64(Microsoft.VisualBasic.Right(txtTuQuy.Text, 4))
                If intTuQuy > 4 Or intDenQuy > 4 Then
                    Kiemtranhap = False
                    Exit Function
                End If
                If nam1 > nam Then
                    Kiemtranhap = False
                    Exit Function
                Else
                    If nam1 = nam Then
                        If intTuQuy > intDenQuy Then
                            Kiemtranhap = False
                            Exit Function
                        End If
                    End If
                End If
                'If intTuQuy + nam1 > intDenQuy + nam Then
                '    Kiemtranhap = False
                'End If
            End If
            If so = 2 Then
                Dim intTuNam, intDenNam As Integer
                intTuNam = txtTuNam_MTBF.Text
                intDenNam = txtDenNam_MTBF.Text
                If intTuNam > intDenNam Then
                    Kiemtranhap = False
                    Exit Function
                End If
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Sub btnTheoDC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTheoDC.Click
        'If IsDate("01/" & txtTuthang.Text) = False Or IsDate("01/" & txtDenthang.Text) = False Then
        '    MsgBox("Đều kiện cần in không hợp lệ !", MsgBoxStyle.Critical)
        '    txtTungay.Focus()
        '    Exit Sub
        'End If

        If cboInTheo.SelectedIndex = 1 And (txtTuQuy.Text.Trim = "" Or txtDenQuy.Text.Trim = "") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn Quý", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If cboInTheo.SelectedIndex = 0 And (txtttuthang.Text.Trim = "" Or txtdenthang1.Text.Trim = "") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn tháng", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If cboInTheo.SelectedIndex = 2 And (txtTuNam_MTBF.Text.Trim = "" Or txtDenNam_MTBF.Text.Trim = "") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn Năm", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If Kiemtranhap(cboInTheo.SelectedIndex) = False Then
            MessageBox.Show("Nhập số liệu không chính xác", "Thông báo", MessageBoxButtons.OK)
            Exit Sub
        End If
        'If cboInTheo.SelectedIndex = 0 Then
        '    bolQuy = True
        'Else
        '    bolQuy = False
        'End If
        Select Case cboInTheo.SelectedIndex
            Case 0
                frmReports.baocao = 0
            Case 1
                frmReports.baocao = 1
            Case 2
                frmReports.baocao = 2
        End Select

        Select Case cboInTheo.SelectedIndex
            Case 0 'thang
                Dim tuquy As String
                Dim denquy As String
                tuquy = txtttuthang.Text
                denquy = txtdenthang1.Text
                tu = txtttuthang.Text
                den = txtdenthang1.Text
                Dim strNam1 As String
                If tuquy.Length = 7 And denquy.Length = 7 Then

                    Dim dt As New DataTable
                    Dim intTuQuy, intDenQuy As Int16
                    intTuQuy = Microsoft.VisualBasic.Left(txtttuthang.Text, 2)
                    intDenQuy = Microsoft.VisualBasic.Left(txtdenthang1.Text, 2)
                    strNam = Microsoft.VisualBasic.Right(txtdenthang1.Text, 4).ToString
                    strNam1 = Microsoft.VisualBasic.Right(txtttuthang.Text, 4).ToString
                    Commons.Modules.ObjSystems.XoaTable("dbo.NHOC_thang")
                    Commons.Modules.SQLString = "CREATE TABLE dbo.NHOC_thang(thang NVARCHAR(7))"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    If strNam = strNam1 Then
                        For i As Int16 = intTuQuy To intDenQuy
                            Commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + i.ToString + "/" + strNam + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        Next
                    Else
                        Dim i As Integer
                        Dim st As Integer
                        If (strNam - strNam1) > 1 Then
                            st = (strNam - strNam1 - 1) * 12
                            st = st + (intDenQuy) + (12 - intTuQuy)
                        Else
                            If strNam1 = strNam Then
                                st = intDenQuy - intTuQuy
                            Else
                                st = intDenQuy + (12 - intTuQuy)
                            End If
                        End If
                        Dim x As Integer = intTuQuy - 1
                        Dim nam As Integer = strNam1
                        For i = intTuQuy To st + intTuQuy
                            x = x + 1
                            If x > 12 Then
                                x = 1
                                nam += 1
                            End If
                            Commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + x.ToString + "/" + nam.ToString + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                        Next
                        'Dim i As Integer
                        'For i = intTuQuy To 12
                        '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + i.ToString + "/" + strNam1 + "')"
                        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        'Next
                        'For i = 1 To intDenQuy
                        '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + i.ToString + "/" + strNam + "')"
                        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        'Next
                    End If
                End If

            Case 1 'quy
                Dim tuquy As String
                Dim denquy As String
                tuquy = txtTuQuy.Text
                denquy = txtDenQuy.Text

                If tuquy.Length = 6 And denquy.Length = 6 Then

                    Dim dt As New DataTable
                    Dim intTuQuy, intDenQuy As Int16
                    Dim strNam1 As String
                    intTuQuy = Microsoft.VisualBasic.Left(txtTuQuy.Text, 1)
                    intDenQuy = Microsoft.VisualBasic.Left(txtDenQuy.Text, 1)
                    tu = txtTuQuy.Text
                    den = txtDenQuy.Text
                    strNam = Microsoft.VisualBasic.Right(txtDenQuy.Text, 4).ToString
                    strNam1 = Microsoft.VisualBasic.Right(txtTuQuy.Text, 4).ToString
                    Commons.Modules.ObjSystems.XoaTable("NHOC_QUY")
                    Commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_QUY(QUY NVARCHAR(7))"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    If strNam = strNam1 Then
                        For i As Int16 = intTuQuy To intDenQuy
                            Commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        Next
                    Else
                        Dim i As Integer
                        Dim st As Integer
                        If (strNam - strNam1) > 1 Then
                            st = (strNam - strNam1 - 1) * 4
                            st = st + (intDenQuy) + (4 - intTuQuy)
                        Else
                            If strNam1 = strNam Then
                                st = intDenQuy - intTuQuy
                            Else
                                st = intDenQuy + (12 - intTuQuy)
                            End If
                        End If
                        Dim x As Integer = intTuQuy - 1
                        Dim nam As Integer = strNam1
                        For i = intTuQuy To st + intTuQuy
                            x = x + 1
                            If x > 4 Then
                                x = 1
                                nam += 1
                            End If
                            Commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + x.ToString + "/" + nam.ToString + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                        Next

                        'Dim i As Integer
                        'For i = intTuQuy To 4
                        '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam1 + "')"
                        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        'Next
                        'For i = 1 To intDenQuy
                        '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam + "')"
                        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        'Next
                    End If

                End If
            Case 2 'nam
                Dim tunam As String
                Dim dennam As String
                Dim dt As New DataTable
                Dim intTuNam, intDenNam As Int16
                tunam = txtTuNam_MTBF.Text
                dennam = txtDenNam_MTBF.Text
                tu = txtTuNam_MTBF.Text
                den = txtDenNam_MTBF.Text
                If tunam.Length = 4 And dennam.Length = 4 Then
                    intTuNam = txtTuNam_MTBF.Text
                    intDenNam = txtDenNam_MTBF.Text
                    Commons.Modules.ObjSystems.XoaTable("NHOC_NAM")
                    Commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_NAM(NAM NVARCHAR(5))"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    For i As Int16 = intTuNam To intDenNam
                        Commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_NAM VALUES(N'" + i.ToString + "')"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    Next
                End If
        End Select
        Dim frm As New frmMTBF_TheoDC
        frm.loaibaocao = 1
        frm.ShowDialog()
        Commons.Modules.ObjSystems.XoaTable("NHOC_QUY")
        Commons.Modules.ObjSystems.XoaTable("NHOC_thang")
        Commons.Modules.ObjSystems.XoaTable("NHOC_NAM")
    End Sub

    Private Sub btnTheoMay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTheoMay.Click
        'intTuQuy = Microsoft.VisualBasic.Left(txtTuQuy.Text, 1)
        If cboInTheo.SelectedIndex = 1 And (txtTuQuy.Text.Trim = "/" Or txtDenQuy.Text.Trim = "/") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn Quý", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If cboInTheo.SelectedIndex = 0 And (txtttuthang.Text.Trim = "/" Or txtdenthang1.Text.Trim = "/") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn tháng", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If cboInTheo.SelectedIndex = 2 And (txtTuNam_MTBF.Text.Trim = "/" Or txtDenNam_MTBF.Text.Trim = "/") Then
            MsgBox("Vui lòng nhập đầy đủ giai đoạn Năm", MsgBoxStyle.Information, "Thông báo")
            Return
        End If
        If Kiemtranhap(cboInTheo.SelectedIndex) = False Then
            MessageBox.Show("Nhập số liệu không chính xác", "Thông báo", MessageBoxButtons.OK)
            Exit Sub
        End If
        'If cboInTheo.SelectedIndex = 0 Then
        '    bolQuy = True
        'Else
        '    bolQuy = False
        'End If
        Select Case cboInTheo.SelectedIndex
            Case 0
                frmReports.baocao = 0
            Case 1
                frmReports.baocao = 1
            Case 2
                frmReports.baocao = 2
        End Select

        Select Case cboInTheo.SelectedIndex

            Case 0
                Dim tuquy As String
                Dim denquy As String
                tuquy = txtttuthang.Text
                denquy = txtdenthang1.Text
                tu = txtttuthang.Text
                den = txtdenthang1.Text

                Dim strNam1 As String
                If tuquy.Length = 7 And denquy.Length = 7 Then

                    Dim dt As New DataTable
                    Dim intTuQuy, intDenQuy As Int16
                    intTuQuy = Microsoft.VisualBasic.Left(txtttuthang.Text, 2)
                    intDenQuy = Microsoft.VisualBasic.Left(txtdenthang1.Text, 2)
                    strNam = Microsoft.VisualBasic.Right(txtdenthang1.Text, 4).ToString
                    strNam1 = Microsoft.VisualBasic.Right(txtttuthang.Text, 4).ToString
                    Commons.Modules.ObjSystems.XoaTable("NHOC_thang")
                    Commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_thang(thang NVARCHAR(7))"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    If strNam = strNam1 Then
                        For i As Int16 = intTuQuy To intDenQuy
                            Commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + i.ToString + "/" + strNam + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        Next
                    Else
                        Dim i As Integer
                        Dim st As Integer
                        If (strNam - strNam1) > 1 Then
                            st = (strNam - strNam1 - 1) * 12
                            st = st + (intDenQuy) + (12 - intTuQuy)
                        Else
                            If strNam1 = strNam Then
                                st = intDenQuy - intTuQuy
                            Else
                                st = intDenQuy + (12 - intTuQuy)
                            End If
                        End If
                        Dim x As Integer = intTuQuy - 1
                        Dim nam As Integer = strNam1
                        For i = intTuQuy To st + intTuQuy
                            x = x + 1
                            If x > 12 Then
                                x = 1
                                nam += 1
                            End If
                            Commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_thang VALUES(N'" + x.ToString + "/" + nam.ToString + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        Next
                    End If
                End If

            Case 1
                Dim tuquy As String
                Dim denquy As String
                tuquy = txtTuQuy.Text
                denquy = txtDenQuy.Text

                If tuquy.Length = 6 And denquy.Length = 6 Then

                    Dim dt As New DataTable
                    Dim intTuQuy, intDenQuy As Int16
                    Dim strNam1 As String
                    intTuQuy = Microsoft.VisualBasic.Left(txtTuQuy.Text, 1)
                    intDenQuy = Microsoft.VisualBasic.Left(txtDenQuy.Text, 1)
                    tu = txtTuQuy.Text
                    den = txtDenQuy.Text
                    strNam = Microsoft.VisualBasic.Right(txtDenQuy.Text, 4).ToString
                    strNam1 = Microsoft.VisualBasic.Right(txtTuQuy.Text, 4).ToString
                    Commons.Modules.ObjSystems.XoaTable("NHOC_QUY")
                    Commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_QUY(QUY NVARCHAR(7))"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    If strNam = strNam1 Then
                        For i As Int16 = intTuQuy To intDenQuy
                            Commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        Next
                    Else
                        Dim i As Integer
                        Dim st As Integer
                        If (strNam - strNam1) > 1 Then
                            st = (strNam - strNam1 - 1) * 4
                            st = st + (intDenQuy) + (4 - intTuQuy)
                        Else
                            If strNam1 = strNam Then
                                st = intDenQuy - intTuQuy
                            Else
                                st = intDenQuy + (12 - intTuQuy)
                            End If
                        End If
                        Dim x As Integer = intTuQuy - 1
                        Dim nam As Integer = strNam1
                        For i = intTuQuy To st + intTuQuy
                            x = x + 1
                            If x > 4 Then
                                x = 1
                                nam += 1
                            End If
                            Commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + x.ToString + "/" + nam.ToString + "')"
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                        Next
                        'Dim i As Integer
                        'For i = intTuQuy To 4
                        '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam1 + "')"
                        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        'Next
                        'For i = 1 To intDenQuy
                        '    commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_QUY VALUES(N'" + i.ToString + "/" + strNam + "')"
                        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        'Next
                    End If

                End If
            Case 2
                Dim tunam As String
                Dim dennam As String
                Dim dt As New DataTable
                Dim intTuNam, intDenNam As Int16
                tunam = txtTuNam_MTBF.Text
                dennam = txtDenNam_MTBF.Text
                tu = txtTuNam_MTBF.Text
                den = txtDenNam_MTBF.Text
                If tunam.Length = 4 And dennam.Length = 4 Then
                    intTuNam = txtTuNam_MTBF.Text
                    intDenNam = txtDenNam_MTBF.Text
                    Commons.Modules.ObjSystems.XoaTable("NHOC_NAM")
                    Commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_NAM(NAM NVARCHAR(5))"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    For i As Int16 = intTuNam To intDenNam
                        Commons.Modules.SQLString = "INSERT INTO [dbo].NHOC_NAM VALUES(N'" + i.ToString + "')"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    Next
                End If
        End Select
        frmReports.tu = tu
        frmReports.den = den
        Dim frm As New frmMTBF_TheoMay
        frm.loaibaocao = 1
        frm.ShowDialog()
        Commons.Modules.ObjSystems.XoaTable("NHOC_QUY")
        Commons.Modules.ObjSystems.XoaTable("NHOC_thang")
        Commons.Modules.ObjSystems.XoaTable("NHOC_NAM")
    End Sub

    Private Sub cboInTheo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboInTheo.SelectedIndexChanged
        Select Case cboInTheo.SelectedIndex
            Case 0
                lblTuQuy.Visible = False
                lblDenQuy.Visible = False
                txtTuQuy.Visible = False
                txtDenQuy.Visible = False
                lblTuNam_MTBF.Visible = False
                lblDenNam_MTBF.Visible = False
                txtTuNam_MTBF.Visible = False
                txtDenNam_MTBF.Visible = False

                lbdenthang.Visible = True
                Lbtuthang.Visible = True
                txtttuthang.Visible = True
                txtdenthang1.Visible = True
            Case 1
                lblTuQuy.Visible = True
                lblDenQuy.Visible = True
                txtTuQuy.Visible = True
                txtDenQuy.Visible = True
                lblTuNam_MTBF.Visible = False
                lblDenNam_MTBF.Visible = False
                txtTuNam_MTBF.Visible = False
                txtDenNam_MTBF.Visible = False
                lbdenthang.Visible = False
                Me.Lbtuthang.Visible = False
                Me.txtttuthang.Visible = False
                Me.txtdenthang1.Visible = False
            Case 2
                lblTuQuy.Visible = False
                lblDenQuy.Visible = False
                txtTuQuy.Visible = False
                txtDenQuy.Visible = False
                lblTuNam_MTBF.Visible = True
                lblDenNam_MTBF.Visible = True
                txtTuNam_MTBF.Visible = True
                txtDenNam_MTBF.Visible = True
                lbdenthang.Visible = False
                Me.Lbtuthang.Visible = False
                Me.txtttuthang.Visible = False
                Me.txtdenthang1.Visible = False


        End Select
    End Sub
End Class
