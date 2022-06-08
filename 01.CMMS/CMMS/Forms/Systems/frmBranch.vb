Imports System.IO
Imports System.Text
Imports Commons.VS.Classes.Admin
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Microsoft.VisualBasic.DateAndTime
Imports DevExpress.XtraEditors

Public Class frmBranch
    Public MsNX As String = Nothing
    Private IsNew As Boolean = False
    Private TSource As DataTable = Nothing
    Private duongdan As String
    Private arrMaNode As New List(Of String)
    Private repositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private _dtCopy As DataTable

    Private Sub frmBranch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Commons.Modules.sPrivate <> "VECO" Then
            Commons.Modules.ObjSystems.MRemoveRow(TableLayoutPanel1, 5)
            TableLayoutPanel1.RowStyles(5).SizeType = SizeType.AutoSize
            TableLayoutPanel1.RowStyles(6).SizeType = SizeType.AutoSize
        End If
        BindingComboBox()
        BindingSource()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThemNX.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
        AnHienMail(True)
        TaoCmbLoaiMail()
    End Sub
    Private Sub BindingComboBox()
        Dim TUnit As DataTable = New DataTable()
        TUnit.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM dbo.DON_VI ORDER BY MS_DON_VI "))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDON_VI, TUnit, "MS_DON_VI", "TEN_DON_VI", "")
        cboDON_VI.ItemIndex = -1
    End Sub
    Private Sub BindingSource()
        TSource = New DataTable()
        TSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select * from dbo.NHA_XUONG"))
        For Each Column As DataColumn In TSource.Columns
            Column.AllowDBNull = True
            Column.ReadOnly = False
        Next
        CreateTreeView()
        BindingControl()
        ReadOnlyControl(True)
        EnabledButton(True)


    End Sub
    Private Sub CreateTreeView()
        trvList.Nodes.Clear()
        Dim nRoot As TreeNode = New TreeNode()
        nRoot.Name = "ROOT"
        nRoot.Text = "Địa điểm"
        trvList.Nodes.Add(nRoot)

        TSource.DefaultView.RowFilter = "MS_CHA is null or MS_CHA = ''"
        Dim TParent As DataTable = TSource.DefaultView.ToTable()
        For Each Row In TParent.Rows
            Dim nNew As TreeNode = New TreeNode()
            nNew.Name = Row("MS_N_XUONG").ToString().Trim()
            If Row("GHI_CHU").ToString().Trim() = "" Then
                nNew.Text = Row("TEN_N_XUONG").ToString().Trim()
            Else
                nNew.Text = Row("TEN_N_XUONG").ToString().Trim() + "(" + Row("GHI_CHU").ToString().Trim() + ")"
            End If
            nNew.Tag = Row
            nRoot.Nodes.Add(nNew)
            CreateTreeNode(nNew)
        Next
        trvList.ExpandAll()
        trvList.Focus()
        If (MsNX <> Nothing) Then
            Dim tn As TreeNode() = trvList.Nodes.Find(MsNX, True)
            If tn.Length > 0 Then
                For i As Integer = 0 To tn.Length - 1
                    trvList.SelectedNode = tn(i)
                    'trvList.SelectedNode.BackColor = Color.Yellow
                Next
            Else
                Dim tag As String = String.Empty
                tag = trvList.Text

                If tag <> String.Empty Then
                    Dim tnc As TreeNodeCollection
                    tnc = trvList.Nodes
                    For i As Integer = 0 To trvList.Nodes(0).Nodes.Count - 1
                        If tag = DirectCast(tnc(i).Tag, String) Then

                            'tnc(i).BackColor = Color.Red
                        End If

                    Next

                End If
            End If
        End If
    End Sub
    Private Sub CreateTreeNode(ByVal nParent As TreeNode)
        TSource.DefaultView.RowFilter = "MS_CHA = '" + nParent.Name + "'"
        Dim TParent As DataTable = TSource.DefaultView.ToTable()
        For Each Row In TParent.Rows
            Dim nNew As TreeNode = New TreeNode()
            nNew.Name = Row("MS_N_XUONG").ToString().Trim()
            If Row("GHI_CHU").ToString().Trim() = "" Then
                nNew.Text = Row("TEN_N_XUONG").ToString().Trim()
            Else
                nNew.Text = Row("TEN_N_XUONG").ToString().Trim() + "(" + Row("GHI_CHU").ToString().Trim() + ")"
            End If
            nNew.Tag = Row
            nParent.Nodes.Add(nNew)
            CreateTreeNode(nNew)
        Next
    End Sub
    Private Sub BindingControl()
        If trvList.SelectedNode Is Nothing Then
            ClearConten()
        Else
            If trvList.SelectedNode.Name = "ROOT" Then
                ClearConten()
            Else
                txtMS.Text = CType(trvList.SelectedNode.Tag, DataRow)("MS_N_XUONG").ToString().Trim()
                txtTEN_V.Text = CType(trvList.SelectedNode.Tag, DataRow)("TEN_N_XUONG").ToString().Trim()
                txtTEN_A.Text = CType(trvList.SelectedNode.Tag, DataRow)("TEN_N_XUONG_A").ToString().Trim()
                txtTEN_H.Text = CType(trvList.SelectedNode.Tag, DataRow)("TEN_N_XUONG_H").ToString().Trim()
                cboDON_VI.EditValue = CType(trvList.SelectedNode.Tag, DataRow)("MS_DON_VI")
                txtTRU_SO.Text = CType(trvList.SelectedNode.Tag, DataRow)("TRU_SO").ToString().Trim()
                txtNGUOI_DAI_DIEN.Text = CType(trvList.SelectedNode.Tag, DataRow)("NGUOI_DAI_DIEN").ToString().Trim()
                txtDIEN_THOAI.Text = CType(trvList.SelectedNode.Tag, DataRow)("DIEN_THOAI").ToString().Trim()
                spnDIEN_TICH.Value = IIf(CType(trvList.SelectedNode.Tag, DataRow)("DIEN_TICH") Is Nothing Or CType(trvList.SelectedNode.Tag, DataRow).IsNull("DIEN_TICH"), 0, CType(trvList.SelectedNode.Tag, DataRow)("DIEN_TICH"))
                spnKHOANG_CACH.Value = IIf(CType(trvList.SelectedNode.Tag, DataRow)("KHOANG_CACH") Is Nothing Or CType(trvList.SelectedNode.Tag, DataRow).IsNull("KHOANG_CACH"), 0, CType(trvList.SelectedNode.Tag, DataRow)("KHOANG_CACH"))
                txtGHI_CHU.Text = CType(trvList.SelectedNode.Tag, DataRow)("GHI_CHU").ToString().Trim()

                If Not IsDBNull(CType(trvList.SelectedNode.Tag, DataRow)("HINH_ANH")) Then
                    Dim arrPicture As Byte() = CType(trvList.SelectedNode.Tag, DataRow)("HINH_ANH")
                    If arrPicture.Length <> 0 Then
                        Dim ms As New MemoryStream(arrPicture)
                        picLogo.Image = Image.FromStream(ms)
                        picLogo.SizeMode = PictureBoxSizeMode.CenterImage
                        picLogo.BorderStyle = BorderStyle.Fixed3D
                        picLogo.Visible = True
                    Else
                        picLogo.Image = Nothing
                    End If
                Else
                    picLogo.Image = Nothing
                    'picLogo.Visible = False
                End If
                If (Commons.Modules.sPrivate = "VECO") Then
                    Try
                        Dim str As String = "SELECT INVECO, TARGET FROM NHA_XUONG WHERE MS_N_XUONG = '" & txtMS.Text.Trim() & "'"
                        Dim dt As New DataTable
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                        TXTSTTIN.Text = dt.Rows(0)(0)
                        txtTaget.Text = dt.Rows(0)(1)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
    End Sub
    Private Sub ClearConten()
        txtMS.Text = ""
        txtTEN_V.Text = ""
        txtTEN_A.Text = ""
        txtTEN_H.Text = ""
        cboDON_VI.ItemIndex = -1
        txtTRU_SO.Text = ""
        txtNGUOI_DAI_DIEN.Text = ""
        txtDIEN_THOAI.Text = ""
        spnDIEN_TICH.Value = 0
        spnKHOANG_CACH.Value = 0
        txtGHI_CHU.Text = ""
        If Commons.Modules.sPrivate = "VECO" Then
            txtTaget.Value = Nothing
            TXTSTTIN.Value = Nothing
        End If
    End Sub
    Private Sub ReadOnlyControl(ByVal Flag As Boolean)
        If Not Flag Then
            If IsNew Then
                txtMS.Properties.ReadOnly = Flag
            Else
                txtMS.Properties.ReadOnly = Not Flag
            End If
        Else
            txtMS.Properties.ReadOnly = Flag
        End If
        txtTEN_V.Properties.ReadOnly = Flag
        txtTEN_A.Properties.ReadOnly = Flag
        txtTEN_H.Properties.ReadOnly = Flag
        cboDON_VI.Properties.ReadOnly = Flag
        txtTRU_SO.Properties.ReadOnly = Flag
        txtNGUOI_DAI_DIEN.Properties.ReadOnly = Flag
        txtDIEN_THOAI.Properties.ReadOnly = Flag
        spnDIEN_TICH.Properties.ReadOnly = Flag
        spnKHOANG_CACH.Properties.ReadOnly = Flag
        txtGHI_CHU.Properties.ReadOnly = Flag
        trvList.Enabled = Flag
        txtTaget.Properties.ReadOnly = Flag
        TXTSTTIN.Properties.ReadOnly = Flag
    End Sub
    Private Sub EnabledButton(ByVal Flag As Boolean)
        btnEdit.Visible = Flag
        btnDelete.Visible = Flag
        btnMove.Visible = Flag
        btnThemNX.Visible = Flag
        btnExit.Visible = Flag

        btnThemNX.Enabled = Flag
        btnSave.Enabled = Not Flag
        btnCancel.Enabled = Not Flag
        btnChoose.Enabled = Not Flag
        btnDeleteImage.Enabled = Not Flag
        btnMove.Enabled = Flag

        If Flag Then
            If Not trvList.SelectedNode Is Nothing Then
                If trvList.SelectedNode.Name <> "ROOT" Then
                    btnEdit.Enabled = Flag
                    btnMove.Enabled = Flag
                    btnDelete.Enabled = Flag
                Else
                    btnEdit.Enabled = Not Flag
                    btnDelete.Enabled = Not Flag
                    btnMove.Enabled = Not Flag
                End If
            Else
                btnEdit.Enabled = Not Flag
                btnDelete.Enabled = Not Flag
                btnMove.Enabled = Not Flag
            End If
        Else
            btnEdit.Visible = Flag
            btnDelete.Visible = Flag
            btnMove.Visible = Flag
            btnThemNX.Visible = Flag
            btnExit.Visible = Flag
        End If
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemNX.Click
        If trvList.SelectedNode Is Nothing Then
            Commons.MssBox.Show(Me.Name, "CHON_CAP_TREN")
            trvList.Focus()
            Return
        End If
        IsNew = True
        ReadOnlyControl(False)
        EnabledButton(False)
        ClearConten()
        picLogo.Image = Nothing
    End Sub
    Public Shared Function ImageToByte(ByVal img As Image) As Byte()
        Dim converter As New ImageConverter()
        Return DirectCast(converter.ConvertTo(img, GetType(Byte())), Byte())
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Validate()
        If txtMS.Text.Trim() = "" Then
            Commons.MssBox.Show(Me.Name, "CHUA_NHAP_MS_N_XUONG")
            txtMS.Focus()
            Return
        End If
        If txtTEN_V.Text.Trim() = "" Then
            Commons.MssBox.Show(Me.Name, "CHUA_NHAP_TEN_N_XUONG")
            txtTEN_V.Focus()
            Return
        End If
        If IsNew Then
            If CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "select count(*) from dbo.NHA_XUONG where MS_N_XUONG = N'" + txtMS.Text.Trim() + "'"), Integer) > 0 Then
                Commons.MssBox.Show(Me.Name, "MS_N_XUONG_DA_CO")
                txtMS.Focus()
                Return
            End If
        End If
        If (Commons.Modules.sPrivate = "VECO") Then
            Try
                Convert.ToInt32(TXTSTTIN.Text.Trim())
            Catch ex As Exception
                Commons.MssBox.Show(Me.Name, "STT_InBaoCaoPhaiLaSo")
                TXTSTTIN.Focus()
                Return
            End Try

            Try
                Convert.ToDouble(txtTaget.Text.Trim())
            Catch ex As Exception
                Commons.MssBox.Show(Me.Name, "Target_InBaoCaoPhaiLaSo")
                TXTSTTIN.Focus()
                Return
            End Try

        End If
        Try
            Dim arrImage As Byte() = Nothing
            arrImage = ImageToByte(picLogo.Image)
            Dim ms_n_xuong As String = txtMS.Text
            Dim ms_cha As String = IIf(trvList.SelectedNode.Name = "ROOT", "-1", trvList.SelectedNode.Name)
            Dim ten_nx_v As String = txtTEN_V.Text
            Dim ten_nx_a As String = txtTEN_A.Text
            Dim ten_nx_h As String = txtTEN_H.Text
            Dim tru_so As String = txtTRU_SO.Text
            Dim nguoi_dd As String = txtNGUOI_DAI_DIEN.Text
            Dim dt As String = txtDIEN_THOAI.Text

            Dim dia_chi As String = ""
            Dim dien_tich As String = spnDIEN_TICH.Value.ToString()
            Dim khoang_cach As String = spnKHOANG_CACH.Value.ToString
            Dim ghi_chu As String = txtGHI_CHU.Text
            Dim don_vi As String = ""
            Try
                don_vi = cboDON_VI.EditValue
            Catch ex As Exception

            End Try
            Dim OldNode1 As New TreeNode
            If IsNew Then
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_NHU_Y_INSERT_NHA_XUONG", ms_n_xuong, ms_cha, ten_nx_v, ten_nx_a, ten_nx_h, tru_so, nguoi_dd, dt, Nothing, Nothing, dia_chi, dien_tich, khoang_cach, ghi_chu, don_vi, arrImage)
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "MashjAddNHOM_NHA_XUONG", ms_n_xuong, Commons.Modules.UserName)
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateNHA_XUONG_LOG", txtMS.Text.Trim, Me.Name, Commons.Modules.UserName, 1)
            Else
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateNHA_XUONG_LOG", txtMS.Text.Trim, Me.Name, Commons.Modules.UserName, 2)
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_NHU_Y_UPDATE_NHA_XUONG", ms_n_xuong, ten_nx_v, ten_nx_a, ten_nx_h, tru_so, nguoi_dd, dt, Nothing, Nothing, dia_chi, dien_tich, khoang_cach, ghi_chu, don_vi, arrImage)
            End If


            If (Commons.Modules.sPrivate = "VECO") Then
                Dim str As String
                If TXTSTTIN.Text.Trim() = 7 Then
                    str = "UPDATE NHA_XUONG SET INVECO = '" + TXTSTTIN.Text + "', TARGET = '" + txtTaget.Text + "' WHERE INVECO = 7"
                Else
                    str = "UPDATE NHA_XUONG SET INVECO = '" + TXTSTTIN.Text + "', TARGET = '" + txtTaget.Text + "' WHERE MS_N_XUONG = '" + ms_n_xuong + "'"
                End If

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If




            If IsNew Then
                Dim nNew As TreeNode = New TreeNode()
                nNew.Name = txtMS.Text.Trim()
                nNew.Text = txtTEN_V.Text.Trim()
                Dim dtRow As DataRow = TSource.NewRow()
                dtRow("MS_N_XUONG") = txtMS.Text.Trim()
                dtRow("TEN_N_XUONG") = txtTEN_V.Text.Trim()
                dtRow("TEN_N_XUONG_A") = txtTEN_A.Text.Trim()
                dtRow("TEN_N_XUONG_H") = txtTEN_H.Text.Trim()
                dtRow("TRU_SO") = txtTRU_SO.Text.Trim()
                dtRow("NGUOI_DAI_DIEN") = txtNGUOI_DAI_DIEN.Text.Trim()
                dtRow("DIEN_THOAI") = txtDIEN_THOAI.Text.Trim()
                dtRow("MS_QG") = Nothing
                dtRow("MS_DUONG") = Nothing
                dtRow("DIA_CHI") = Nothing
                dtRow("DIEN_TICH") = spnDIEN_TICH.Value
                dtRow("KHOANG_CACH") = spnKHOANG_CACH.Value
                dtRow("GHI_CHU") = txtGHI_CHU.Text.Trim()
                dtRow("MS_DON_VI") = cboDON_VI.EditValue
                dtRow("HINH_ANH") = arrImage
                TSource.Rows.Add(dtRow)
                nNew.Tag = dtRow
                trvList.SelectedNode.Nodes.Add(nNew)
                trvList.SelectedNode = nNew
            Else
                CType(trvList.SelectedNode.Tag, DataRow)("MS_N_XUONG") = txtMS.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("TEN_N_XUONG") = txtTEN_V.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("TEN_N_XUONG_A") = txtTEN_A.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("TEN_N_XUONG_H") = txtTEN_H.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("TRU_SO") = txtTRU_SO.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("NGUOI_DAI_DIEN") = txtNGUOI_DAI_DIEN.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("DIEN_THOAI") = txtDIEN_THOAI.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("DIEN_TICH") = spnDIEN_TICH.Value
                CType(trvList.SelectedNode.Tag, DataRow)("KHOANG_CACH") = spnKHOANG_CACH.Value
                CType(trvList.SelectedNode.Tag, DataRow)("GHI_CHU") = txtGHI_CHU.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("MS_DON_VI") = cboDON_VI.EditValue
                CType(trvList.SelectedNode.Tag, DataRow)("HINH_ANH") = arrImage
            End If
            trvList.Update()
            TSource.AcceptChanges()
            IsNew = False
            BindingControl()
            ReadOnlyControl(True)
            EnabledButton(True)
            BindingSource()
            Try
                OldNode1 = trvList.Nodes.Find(ms_n_xuong, True)(0)
                trvList.SelectedNode = OldNode1
            Catch ex As Exception
            End Try
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOI_CAP_NHAT_NHA_XUONG", Commons.Modules.TypeLanguage) & vbCrLf & ex.Message)
            Return
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        IsNew = False
        TSource.RejectChanges()
        BindingControl()
        ReadOnlyControl(True)
        EnabledButton(True)
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        IsNew = False
        ReadOnlyControl(False)
        EnabledButton(False)
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim SQL_TMP As String = "SELECT * FROM Shapes WHERE Code =  N'NX-' + N'" & txtMS.Text.Trim() & "'"
        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "TonTaiTrongShapes")
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        Dim Cnn As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim sqlTran As SqlTransaction = Cnn.BeginTransaction()



        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HOI_KHI_XOA_NHA_XUONG", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            Try
                SqlHelper.ExecuteNonQuery(sqlTran, "UpdateNHA_XUONG_LOG", txtMS.Text.Trim, Me.Name, Commons.Modules.UserName, 3)
                SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, "DELETE NHOM_NHA_XUONG WHERE MS_N_XUONG = N'" + txtMS.Text.Trim() + "'")
                SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, "DELETE NHA_XUONG_EMAIL WHERE MS_N_XUONG = N'" + txtMS.Text.Trim() + "'")
                SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, "DELETE NHA_XUONG WHERE MS_N_XUONG = N'" + txtMS.Text.Trim() + "'")
                For Each dtRow As DataRow In TSource.Rows
                    If (dtRow("MS_N_XUONG").Equals(txtMS.Text.Trim())) Then
                        TSource.Rows.Remove(dtRow)
                        Exit For
                    End If
                Next
                trvList.Nodes.Remove(trvList.SelectedNode)
                TSource.AcceptChanges()
                BindingControl()
                ReadOnlyControl(True)
                EnabledButton(True)
                sqlTran.Commit()
            Catch ex As Exception
                sqlTran.Rollback()
                TSource.RejectChanges()
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_CAP_TREN", Commons.Modules.TypeLanguage) & vbCrLf & ex.Message)
                Return
            End Try
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabControl.SelectedPageChanged
        If Not btnThemNX.Enabled Then
            tabControl.SelectedTabPage.Name = tabTTNX.Name
            Exit Sub
        End If
        If Not btnThem.Enabled Then
            tabControl.SelectedTabPage.Name = tabTLNX.Name
            Exit Sub
        End If
        If txtMail.Properties.ReadOnly = False Then
            tabControl.SelectedTabPage.Name = tabMail.Name
            Exit Sub
        End If
    End Sub
    Private SERVER_PATH As String
    Private rowCount1 As Integer
    Sub EnableButton(ByVal An As Boolean)
        btnThem.Visible = Not An
        btnGhi.Visible = An
        btnKhongGhi.Visible = An
        btnView.Visible = Not An
        btnOpen.Visible = Not An
        btnThoat.Visible = Not An
        btnXoa.Visible = Not An
        txtSearch.Visible = Not An
        GrdDanhMucTaiLieu.AllowUserToAddRows = An
        txtSearch.Text = ""
    End Sub
    Private dtTAI_LIEU As New DataTable
    Sub BindDataDMTL()
        Try


            dtTAI_LIEU = New DataTable()
            dtTAI_LIEU.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_NHA_XUONG_TAI_LIEU", txtMS.Text))
            GrdDanhMucTaiLieu.DataSource = dtTAI_LIEU
            Me.GrdDanhMucTaiLieu.Columns("MS_N_XUONG").Visible = False
            GrdDanhMucTaiLieu.Columns("MS_TAI_LIEU").Visible = False
            GrdDanhMucTaiLieu.Columns("HINH").Visible = False

            GrdDanhMucTaiLieu.Columns("SO_TAI_LIEU").Width = 120
            GrdDanhMucTaiLieu.Columns("TEN_TAI_LIEU").Width = 150
            GrdDanhMucTaiLieu.Columns("NOI_LUU_TRU").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            GrdDanhMucTaiLieu.Columns("GHI_CHU").Width = 200
            GrdDanhMucTaiLieu.ReadOnly = True
            If Me.GrdDanhMucTaiLieu.Rows.Count > 1 Then
                Me.GrdDanhMucTaiLieu.Rows(0).Selected = True
            End If
            Try
                Me.GrdDanhMucTaiLieu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.GrdDanhMucTaiLieu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception
            End Try
            RefeshLang()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        If txtMS.Text = "" Then
            Commons.MssBox.Show(Me.Name, "CHUACONHAXUONG")
            Exit Sub
        End If
        SERVER_PATH = Commons.Modules.ObjSystems.CapnhatTL(True, "NX")
        EnableButton(True)
        rowCount1 = GrdDanhMucTaiLieu.Rows.Count - 1
        GrdDanhMucTaiLieu.ReadOnly = False
        GrdDanhMucTaiLieu.Columns(2).ReadOnly = True
    End Sub
    Sub GhiTailieu()
        Dim ms_nha_xuong, noi_luu_tru, hinh, ten_tai_lieu, ghi_chu, so_tai_lieu As String
        Dim ma_tai_lieu As Integer
        For i As Integer = 0 To GrdDanhMucTaiLieu.Rows.Count - 2
            ms_nha_xuong = txtMS.Text
            noi_luu_tru = GrdDanhMucTaiLieu.Rows(i).Cells("NOI_LUU_TRU").Value
            ten_tai_lieu = GrdDanhMucTaiLieu.Rows(i).Cells("TEN_TAI_LIEU").Value

            Try
                ghi_chu = GrdDanhMucTaiLieu.Rows(i).Cells("GHI_CHU").Value
            Catch ex As Exception
                ghi_chu = ""
            End Try

            hinh = GrdDanhMucTaiLieu.Rows(i).Cells("HINH").Value
            so_tai_lieu = GrdDanhMucTaiLieu.Rows(i).Cells("SO_TAI_LIEU").Value
            If i < rowCount1 Then
                ma_tai_lieu = GrdDanhMucTaiLieu.Rows(i).Cells("MS_TAI_LIEU").Value
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_NHU_Y_UPDATE_NHA_XUONG_TAI_LIEU", ma_tai_lieu, ten_tai_lieu, noi_luu_tru, so_tai_lieu, ghi_chu)
                'objMAY_TAI_LIEUController.UpdateMAY_TAI_LIEU(objMAY_TAI_LIEUInfo)
            Else
                'objMAY_TAI_LIEUController.AddMAY_TAI_LIEU(objMAY_TAI_LIEUInfo)
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_NHU_Y_ADD_NHA_XUONG_TAI_LIEU", ms_nha_xuong, ten_tai_lieu, noi_luu_tru, so_tai_lieu, ghi_chu)

                Commons.Modules.ObjSystems.LuuDuongDan(hinh, noi_luu_tru)
            End If

        Next
    End Sub
    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click, btnGhiTL.Click
        Dim j As Integer = 0
        While j < Me.GrdDanhMucTaiLieu.RowCount - 1
            If Me.GrdDanhMucTaiLieu.Rows(j).Cells("TEN_TAI_LIEU").Value.ToString.Trim = "" Then
                Commons.MssBox.Show(Me.Name, "MsgTentailieurong")
                Me.GrdDanhMucTaiLieu.Rows(j).Cells("TEN_TAI_LIEU").Selected = True
                Exit Sub
            End If

            If Me.GrdDanhMucTaiLieu.Rows(j).Cells("SO_TAI_LIEU").Value.ToString.Trim = "" Then
                Commons.MssBox.Show(Me.Name, "MsgSotailieurong")
                Me.GrdDanhMucTaiLieu.Rows(j).Cells("SO_TAI_LIEU").Selected = True
                Exit Sub
            End If

            j = j + 1
        End While
        GhiTailieu()
        BindDataDMTL()
        EnableButton(False)
    End Sub

    Private Sub btnKhongGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click, btnKhongGhiTL.Click
        EnableButton(False)
        BindDataDMTL()
    End Sub
    Private NOI_LUU_TRU As String
    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If GrdDanhMucTaiLieu.RowCount <= 0 Then
            Commons.MssBox.Show(Me.Name, "khongcodulieudexoa")
        End If
        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "bancomuonxoakhong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then Exit Sub
        NOI_LUU_TRU = GrdDanhMucTaiLieu.CurrentRow.Cells("NOI_LUU_TRU").Value.ToString
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_NHU_Y_DELETE_NHA_XUONG_TAI_LIEU", GrdDanhMucTaiLieu.CurrentRow.Cells("MS_TAI_LIEU").Value)
        If System.IO.File.Exists(NOI_LUU_TRU) Then
            System.IO.File.Delete(NOI_LUU_TRU)
        End If
        BindDataDMTL()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If GrdDanhMucTaiLieu.RowCount < 1 Then
            Exit Sub
        End If
        Try
            System.Diagnostics.Process.Start(Me.GrdDanhMucTaiLieu.CurrentRow.Cells(2).Value)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "dathaydoiduongdan", Commons.Modules.TypeLanguage) & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        If GrdDanhMucTaiLieu.RowCount < 1 Then
            Exit Sub
        End If
        Try
            Dim str As String = Me.GrdDanhMucTaiLieu.CurrentRow.Cells(2).Value
            Dim folder As String = Path.GetDirectoryName(str)
            System.Diagnostics.Process.Start(folder)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "dathaydoiduongdan", Commons.Modules.TypeLanguage) & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub
    Dim intSTT As Integer = 0
    Sub LayDuongDan()
        If ofdTaiLieu.FileNames(0) = "" Then Exit Sub

        Dim FILE_PATHs As String()
        FILE_PATHs = ofdTaiLieu.FileNames()
        Dim tmp As New DataTable()
        tmp = dtTAI_LIEU.Clone()
        tmp.Columns(2).AllowDBNull = True
        For i As Integer = 0 To GrdDanhMucTaiLieu.Rows.Count - 2
            Dim dr As DataRow
            dr = tmp.NewRow
            dr.Item(0) = GrdDanhMucTaiLieu.Rows(i).Cells("MS_N_XUONG").Value   'dtTAI_LIEU.Rows(i).Item(0)
            dr.Item(1) = GrdDanhMucTaiLieu.Rows(i).Cells("MS_TAI_LIEU").Value
            dr.Item(2) = GrdDanhMucTaiLieu.Rows(i).Cells("NOI_LUU_TRU").Value.ToString
            dr.Item(3) = GrdDanhMucTaiLieu.Rows(i).Cells("TEN_TAI_LIEU").Value.ToString
            dr.Item(4) = GrdDanhMucTaiLieu.Rows(i).Cells("SO_TAI_LIEU").Value.ToString
            dr.Item(5) = GrdDanhMucTaiLieu.Rows(i).Cells("GHI_CHU").Value.ToString
            dr.Item(6) = GrdDanhMucTaiLieu.Rows(i).Cells("HINH").Value.ToString
            tmp.Rows.Add(dr)
        Next
        For i As Integer = 0 To FILE_PATHs.Length - 1
            Dim dr As DataRow
            dr = tmp.NewRow

            dr.Item(0) = txtMS.Text
            dr.Item(1) = 0
            dr.Item(2) = SERVER_PATH & "\" & txtMS.Text & "-" & Path.GetFileNameWithoutExtension(FILE_PATHs(i)) & "_" & IIf(Day(Now()).ToString.Length < 2, 0 & Day(Now()), Day(Now())) & IIf(Month(Now()).ToString.Length < 2, 0 & Month(Now()), Month(Now())) & Year(Now()) & "_" & intSTT & Commons.Modules.ObjSystems.LayDuoiFile(FILE_PATHs(i))
            dr.Item(3) = ""
            dr.Item(4) = ""
            dr.Item(6) = FILE_PATHs(i)
            tmp.Rows.Add(dr)
            intSTT = intSTT + 1
        Next
        dtTAI_LIEU = tmp
        GrdDanhMucTaiLieu.DataSource = dtTAI_LIEU
        Me.GrdDanhMucTaiLieu.Columns("MS_N_XUONG").Visible = False
        GrdDanhMucTaiLieu.Columns("MS_TAI_LIEU").Visible = False
        GrdDanhMucTaiLieu.Columns("HINH").Visible = False
        GrdDanhMucTaiLieu.Columns("SO_TAI_LIEU").Width = 120
        GrdDanhMucTaiLieu.Columns("TEN_TAI_LIEU").Width = 150
        GrdDanhMucTaiLieu.Columns("NOI_LUU_TRU").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        GrdDanhMucTaiLieu.Columns("GHI_CHU").Width = 150
    End Sub
    Private Sub ofdTaiLieu_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdTaiLieu.FileOk
        LayDuongDan()
    End Sub

    Private Sub GrdDanhMucTaiLieu_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhMucTaiLieu.CellDoubleClick
        If btnGhi.Visible Then
            If e.ColumnIndex = 2 Then
                ofdTaiLieu.FileName = ""
                ofdTaiLieu.Multiselect = True
                ofdTaiLieu.ShowDialog()
            End If
        Else
            btnView_Click(Nothing, Nothing)
        End If

    End Sub

    Dim _dt As New DataTable
    Private Sub TaoLuoiMail(ByVal iLoai As Integer)
        Dim sSql As String
        sSql = "SELECT A.EMAIL, B.TEN_LOAI_EMAIL, A.GHI_CHU, A.MS_LOAI_EMAIL FROM dbo.NHA_XUONG_EMAIL AS A " &
                    " INNER JOIN dbo.LOAI_GUI_MAIL AS B ON A.MS_LOAI_EMAIL = B.MS_LOAI_EMAIL  WHERE A.MS_N_XUONG  = '" & txtMS.Text & "' ORDER BY EMAIL"
        Dim dtTmp As DataTable = New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        Dim vKey(1) As DataColumn
        vKey(0) = dtTmp.Columns("MS_LOAI_EMAIL")
        dtTmp.PrimaryKey = vKey
        Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl1, GridView1, sSql, False, False, True, False, True, Me.Name.ToString())
        If iLoai <> -1 Then
            Dim index As Integer
            index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(iLoai))
            GridView1.FocusedRowHandle = GridView1.GetRowHandle(index)
        End If

        LoadTextMail()
        GridView1.Columns("MS_LOAI_EMAIL").Visible = False
        If GridView1.Columns("MS_LOAI_EMAIL").Visible = False Then Exit Sub
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.Columns("MS_LOAI_EMAIL").Visible = False
        GridView1.Columns("EMAIL").Width = 200
        GridView1.Columns("TEN_LOAI_EMAIL").Width = 150
        GridView1.Columns("GHI_CHU").Width = 300

        Commons.Modules.ObjSystems.MLoadNNXtraGrid(GridView1, Me.Name)
    End Sub
    Private Sub TaoCmbLoaiMail()
        Dim sSql As String
        sSql = "SELECT MS_LOAI_EMAIL, TEN_LOAI_EMAIL FROM LOAI_GUI_MAIL ORDER BY MS_LOAI_EMAIL"
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiMail, sSql, "MS_LOAI_EMAIL", "TEN_LOAI_EMAIL", "")
    End Sub


    Private Sub trvList_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvList.AfterSelect
        BindingControl()
        BindDataDMTL()
        EnabledButton(True)
        TaoLuoiMail(-1)
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThemNX.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub
    Private Sub RefeshLang()
        GrdDanhMucTaiLieu.Columns("SO_TAI_LIEU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_TAI_LIEU", Commons.Modules.TypeLanguage)
        GrdDanhMucTaiLieu.Columns("SO_TAI_LIEU").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrdDanhMucTaiLieu.Columns("TEN_TAI_LIEU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_TAI_LIEU", Commons.Modules.TypeLanguage)
        GrdDanhMucTaiLieu.Columns("TEN_TAI_LIEU").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrdDanhMucTaiLieu.Columns("NOI_LUU_TRU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NOI_LUU_TRU", Commons.Modules.TypeLanguage)
        GrdDanhMucTaiLieu.Columns("NOI_LUU_TRU").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrdDanhMucTaiLieu.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
        GrdDanhMucTaiLieu.Columns("GHI_CHU").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim _dt As New DataTable()
        _dt = dtTAI_LIEU.Copy()
        _dt.DefaultView.RowFilter = "SO_TAI_LIEU LIKE '%" + txtSearch.Text + "%' OR TEN_TAI_LIEU LIKE '%" + txtSearch.Text + "%'"
        _dt = _dt.DefaultView.ToTable()
        GrdDanhMucTaiLieu.DataSource = _dt
        Me.GrdDanhMucTaiLieu.Columns("MS_N_XUONG").Visible = False
        GrdDanhMucTaiLieu.Columns("MS_TAI_LIEU").Visible = False
        GrdDanhMucTaiLieu.Columns("HINH").Visible = False

        GrdDanhMucTaiLieu.Columns("SO_TAI_LIEU").Width = 120
        GrdDanhMucTaiLieu.Columns("TEN_TAI_LIEU").Width = 150
        GrdDanhMucTaiLieu.Columns("NOI_LUU_TRU").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        GrdDanhMucTaiLieu.Columns("GHI_CHU").Width = 200
        GrdDanhMucTaiLieu.ReadOnly = True
        If Me.GrdDanhMucTaiLieu.Rows.Count > 1 Then
            Me.GrdDanhMucTaiLieu.Rows(0).Selected = True
        End If
        Try
            Me.GrdDanhMucTaiLieu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.GrdDanhMucTaiLieu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        RefeshLang()
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click

        'If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmChonNX.Name) = False Then Exit Sub

        Dim res As DialogResult = frmChonNX.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_NHU_Y_UPDATE_NHA_XUONG_MS_CHA", frmChonNX.ms_n_xuong, txtMS.Text)
            Commons.MssBox.Show(Me.Name, "DICHUYENTHANHCONG")
            trvList.Nodes.Clear()
            BindingSource()
        End If
    End Sub


    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        Dim oOpen As New OpenFileDialog()
        'oOpen.InitialDirectory = "C:\"
        oOpen.Filter = "All Files|*.*|Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
        oOpen.FilterIndex = 2
        If oOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                picLogo.Image = Image.FromFile(oOpen.FileName)
                picLogo.SizeMode = PictureBoxSizeMode.CenterImage
                picLogo.BorderStyle = BorderStyle.Fixed3D
                duongdan = oOpen.FileName
                picLogo.Visible = True
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End If
    End Sub


    Private Sub btnDeleteImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteImage.Click
        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBranch", "xoahinh", Commons.Modules.TypeLanguage), "VietSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            picLogo.Image = Nothing
            picLogo.BorderStyle = BorderStyle.None
            duongdan = Nothing
        End If
    End Sub

    Private Sub LoadTextMail()
        Try
            cboLoaiMail.EditValue = GridView1.GetFocusedRowCellValue("MS_LOAI_EMAIL")
        Catch ex As Exception
            cboLoaiMail.EditValue = ""
        End Try
        Try
            txtMail.Text = GridView1.GetFocusedRowCellValue("EMAIL")
        Catch ex As Exception
            txtMail.Text = ""
        End Try
        Try
            txtGChu.Text = GridView1.GetFocusedRowCellValue("GHI_CHU")
        Catch ex As Exception
            txtGChu.Text = ""
        End Try
        Try
            txtLoai.Text = GridView1.GetFocusedRowCellValue("MS_LOAI_EMAIL")
        Catch ex As Exception
            txtLoai.Text = ""
        End Try
    End Sub
    Private Sub GridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        LoadTextMail()
    End Sub

    Private Sub AnHienMail(ByVal bVi As Boolean)
        btnThemMail.Visible = bVi
        btnSua.Visible = bVi
        btnXoaMail.Visible = bVi
        btnThoatMail.Visible = bVi
        btnGhiMail.Visible = Not bVi
        btnKhongMail.Visible = Not bVi

        cboLoaiMail.Enabled = Not bVi
        txtMail.Properties.ReadOnly = bVi
        txtGChu.Properties.ReadOnly = bVi
        trvList.Enabled = bVi
    End Sub
    Private Sub btnThemMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemMail.Click
        If txtMS.Text = "" Then
            Commons.MssBox.Show(Me.Name, "ChuaChonNhaXuong")
            trvList.Focus()
            Exit Sub
        End If

        AnHienMail(False)
        txtLoai.Text = "-1"
        cboLoaiMail.EditValue = ""
        txtMail.Text = ""
        txtGChu.Text = ""
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If txtMS.Text = "" Then
            Commons.MssBox.Show(Me.Name, "ChuaChonNhaXuong")
            trvList.Focus()
            Exit Sub
        End If
        AnHienMail(False)
    End Sub

    Private Sub btnXoaMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaMail.Click
        If txtMS.Text = "" Then
            Commons.MssBox.Show(Me.Name, "ChuaChonNhaXuong")
            trvList.Focus()
            Exit Sub
        End If
        If GridView1.RowCount = 0 Then
            Commons.MssBox.Show(Me.Name, "KhongCoMailXoa")
            Exit Sub
        End If

        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BanCoChacXoaMail", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then Exit Sub
        Dim sSql As String
        sSql = "DELETE FROM NHA_XUONG_EMAIL WHERE MS_N_XUONG = '" & txtMS.Text & "' AND MS_LOAI_EMAIL = " & Convert.ToInt32(cboLoaiMail.EditValue)
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

        TaoLuoiMail(-1)

    End Sub

    Private Sub btnThoatMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoatMail.Click
        Close()
    End Sub

    Private Sub btnGhiMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhiMail.Click

        If cboLoaiMail.EditValue Is Nothing Then
            Commons.MssBox.Show(Me.Name, "ChuaNhapLoaiMail")
            cboLoaiMail.Focus()
            Exit Sub
        End If

        If txtMail.Text = "" Then
            Commons.MssBox.Show(Me.Name, "ChuaNhapMail")
            txtMail.Focus()
            Exit Sub
        End If

        Dim sMail() As String = Split(txtMail.Text, ";")
        For i As Integer = 0 To sMail.Length - 1
            If Commons.Modules.ObjSystems.MCheckEmail(sMail(i)) = False Then
                Commons.MssBox.Show(Me.Name, "KhongPhaiMail")
                txtMail.Focus()
                Exit Sub
            End If
        Next
        Dim sSql As String
        Dim dtTmp As DataTable = New DataTable()
        If txtLoai.Text = "" Then txtLoai.Text = "-1"
        sSql = " SELECT * FROM NHA_XUONG_EMAIL WHERE ([MS_N_XUONG] = '" & txtMS.Text & "') AND (MS_LOAI_EMAIL <> " & txtLoai.Text & ") AND (MS_LOAI_EMAIL = " & cboLoaiMail.EditValue & ")"
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        If dtTmp.Rows.Count > 0 Then
            Commons.MssBox.Show(Me.Name, "LoaiMailNayDaCo")
            cboLoaiMail.Focus()
            Exit Sub
        End If
        sSql = "DELETE FROM NHA_XUONG_EMAIL WHERE ([MS_N_XUONG] = '" & txtMS.Text & "') AND (MS_LOAI_EMAIL = " & txtLoai.Text & ") "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

        sSql = "INSERT INTO [NHA_XUONG_EMAIL]([MS_N_XUONG],[MS_LOAI_EMAIL],[EMAIL],[GHI_CHU]) " & _
                    " VALUES ('" & txtMS.Text & "', " & cboLoaiMail.EditValue & ", N'" & txtMail.Text & "' , N'" & txtGChu.Text & "' ) "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        sSql = cboLoaiMail.EditValue
        AnHienMail(True)
        TaoLuoiMail(Convert.ToInt32(sSql))

    End Sub

    Private Sub btnKhongMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongMail.Click
        AnHienMail(True)
    End Sub

    Private Sub txtTimkiem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTimkiem.KeyDown
        Try
            If txtTimkiem.Text.Trim = "" Then Exit Sub
            If IsDBNull(txtTimkiem.Text.Trim) Then Exit Sub
            'test
            Static k As Integer
            Dim oNode As TreeNode()
            Static Dim strOldMaNode As String
            If e.KeyValue = 13 Then
                Dim ie As IEnumerator = trvList.Nodes.GetEnumerator
                If Trim(strOldMaNode) <> "" And Trim(strOldMaNode) = Trim(txtTimkiem.Text.Trim) Then
                    k += 1
                    If arrMaNode.Count <= 0 Then Exit Sub
                    If k >= arrMaNode.Count Then
                        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDaduyetxong_coduyetlaikhong", Commons.Modules.TypeLanguage), "VietSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            k = 0
                        Else
                            Exit Sub
                            End If
                        End If

                        oNode = trvList.Nodes.Find(arrMaNode(k), True)
                    If oNode.Length > 0 Then trvList.SelectedNode = oNode(0)
                Else
                    If ie.MoveNext Then
                        k = 0
                        arrMaNode.Clear()
                        strOldMaNode = txtTimkiem.Text.Trim
                        parseMaNode(ie.Current, txtTimkiem.Text.Trim)
                        If arrMaNode.Count <= 0 Then
                            Commons.MssBox.Show(Me.Name, "MsgKhongtimthay")
                            strOldMaNode = 0
                            Exit Sub
                        End If

                        oNode = trvList.Nodes.Find(arrMaNode(0), True)
                        If oNode.Length > 0 Then trvList.SelectedNode = oNode(0)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub parseMaNode(ByVal tn As TreeNode, ByVal tenNode As String)

        Dim ie As IEnumerator = tn.Nodes.GetEnumerator
        Dim parentnode As String = ""
        parentnode = tn.Text
        While ie.MoveNext()
            Dim ctn As TreeNode = ie.Current
            If ctn.GetNodeCount(True) = 0 Then
                If LCase(ctn.Text).Contains(LCase(tenNode)) Then
                    arrMaNode.Add(ctn.Name)
                ElseIf LCase(ctn.Name).Contains(LCase(tenNode)) Then
                    arrMaNode.Add(ctn.Name)
                End If
            Else
                If LCase(ctn.Text).Contains(LCase(tenNode)) Then
                    arrMaNode.Add(ctn.Name)
                ElseIf LCase(ctn.Name).Contains(LCase(tenNode)) Then
                    arrMaNode.Add(ctn.Name)
                End If
                If (ctn.GetNodeCount(True) > 0) Then
                    parseMaNode(ctn, tenNode)
                End If
            End If
        End While
    End Sub

    Private Sub TableLayoutPanel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel5.Paint

    End Sub
End Class