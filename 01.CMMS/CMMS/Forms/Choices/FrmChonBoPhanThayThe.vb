Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin

Public Class FrmChonBoPhanThayThe
    Dim dtTableTam, dtTableOne As DataTable
    Dim sql As String
    Dim _intRowInd As Integer
    Dim _MS_MAY As String
    Dim _MS_BO_PHAN As String = ""
    Dim _MS_MAY_THAY_THE As String = ""
    Dim _MS_BO_PHAN_THAY_THE As String = ""


    Public Property intRowInd() As Integer
        Get
            Return _intRowInd
        End Get
        Set(ByVal value As Integer)
            _intRowInd = value
        End Set
    End Property

    Public Property MS_MAY() As String
        Get
            Return _MS_MAY
        End Get
        Set(ByVal value As String)
            _MS_MAY = value
        End Set
    End Property
    Public Property MS_MAY_THAY_THE() As String
        Get
            Return _MS_MAY_THAY_THE
        End Get
        Set(ByVal value As String)
            _MS_MAY_THAY_THE = value
        End Set
    End Property
    Public Property MS_BO_PHAN_THAY_THE() As String
        Get
            Return _MS_BO_PHAN_THAY_THE
        End Get
        Set(ByVal value As String)
            _MS_BO_PHAN_THAY_THE = value
        End Set
    End Property
    Public Property MS_BO_PHAN() As String
        Get
            Return _MS_BO_PHAN
        End Get
        Set(ByVal value As String)
            _MS_BO_PHAN = value
        End Set
    End Property

    Private Sub frmPartner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        LoadMay()
        ShowTreeRootChonBoPhanMuonThay(_MS_MAY, True)
        txtMSMayCanThay.Text = _MS_MAY
        AddHandler CboMSMayThayThe.SelectedIndexChanged, AddressOf Me.CboMSMayThayThe_SelectedIndexChanged
        TVChonBoPhanDeThay.HideSelection = False
        TVChonBoPhanMuonThay.HideSelection = False
    End Sub

    Sub LoadMay()
        Dim dtTable As New DataTable
        commons.Modules.SQLString = "SELECT MS_MAY,MS_MAY AS MSMAY FROM MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY " & _
       " WHERE MS_MAY<> N'" & _MS_MAY & "' AND NHOM_MAY.MS_LOAI_MAY=(SELECT MS_LOAI_MAY FROM MAY M INNER JOIN NHOM_MAY N  " & _
       " ON M.MS_NHOM_MAY=N.MS_NHOM_MAY AND M.MS_MAY=N'" & _MS_MAY & "')"

        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        CboMSMayThayThe.ValueMember = "MS_MAY"
        CboMSMayThayThe.DisplayMember = "MSMAY"
        CboMSMayThayThe.DataSource = dtTable
        CboMSMayThayThe.SelectedIndex = -1
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        RemoveHandler CboMSMayThayThe.SelectedIndexChanged, AddressOf Me.CboMSMayThayThe_SelectedIndexChanged
        TVChonBoPhanDeThay.Nodes.Clear()
        TVChonBoPhanMuonThay.Nodes.Clear()
        CboMSMayThayThe.SelectedIndex = -1
        Me.Close()
    End Sub

    Private Sub BtnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        FrmPhieuBaoTri_KIDO.grdDiChuyenBoPhan.BeginEdit(True)
        Try
            Dim str As String = ""
            str = "Select MS_BO_PHAN FROM BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName & " WHERE MS_BO_PHAN_THAY_THE='" & TVChonBoPhanDeThay.SelectedNode.Name & "' AND MS_MAY_THAY_THE=N'" & CboMSMayThayThe.SelectedValue & "'"
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objReader.Read
                If objReader.Item("MS_BO_PHAN").ToString <> "" Then
                    'Bo phan thay the cua may nay da duoc may khac muon va chua tra
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgBoPhan", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                    objReader.Close()
                    GoTo KetThuc
                End If
            End While
            objReader.Close()
            FrmPhieuBaoTri_KIDO.grdDiChuyenBoPhan.Rows(_intRowInd).Cells("MS_BO_PHAN").Value = TVChonBoPhanMuonThay.SelectedNode.Name
            FrmPhieuBaoTri_KIDO.grdDiChuyenBoPhan.Rows(_intRowInd).Cells("MS_BO_PHAN_THAY_THE").Value = TVChonBoPhanDeThay.SelectedNode.Name
            str = "INSERT INTO BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName & "(MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE,MS_MAY,MS_BO_PHAN,TON_TAI) values( N'" & CboMSMayThayThe.SelectedValue & "',N'" & TVChonBoPhanDeThay.SelectedNode.Name & "',N'" & MS_MAY & "',N'" & TVChonBoPhanMuonThay.SelectedNode.Name & "',3)"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Catch ex As Exception
            GoTo Loi
        End Try

        FrmPhieuBaoTri_KIDO.grdDiChuyenBoPhan.Rows(_intRowInd).Cells("TEN_BO_PHAN").Value = TVChonBoPhanMuonThay.SelectedNode.Text
        FrmPhieuBaoTri_KIDO.grdDiChuyenBoPhan.Rows(_intRowInd).Cells("TEN_BO_PHAN_THAY_THE").Value = TVChonBoPhanDeThay.SelectedNode.Text
        FrmPhieuBaoTri_KIDO.grdDiChuyenBoPhan.Rows(_intRowInd).Cells("MS_MAY_THAY_THE").Value = CboMSMayThayThe.SelectedValue
        FrmPhieuBaoTri_KIDO.grdDiChuyenBoPhan.RefreshEdit()
KetThuc:
        RemoveHandler CboMSMayThayThe.SelectedIndexChanged, AddressOf Me.CboMSMayThayThe_SelectedIndexChanged
        TVChonBoPhanDeThay.Nodes.Clear()
        TVChonBoPhanMuonThay.Nodes.Clear()
        CboMSMayThayThe.SelectedIndex = -1
        FrmPhieuBaoTri_KIDO.grdDiChuyenBoPhan.EndEdit(True)
        Me.Close()
        Exit Sub
Loi:
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKT1", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
        Exit Sub
    End Sub

    Private Sub CboMSMayThayThe_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        TVChonBoPhanDeThay.Nodes.Clear()
        ShowTreeRootChonBoPhanDeThay(Me.CboMSMayThayThe.SelectedValue, False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RefeshLanguage()
        LblChonCV.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblChonCV.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThucHien.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        LblTieude.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieude.Name, commons.Modules.TypeLanguage)

    End Sub

#Region "BoPhan"

    Dim OldNode As TreeNode                             'Lưu dữ giá trị của node hiện tại lúc không lưu dữ liệu
    Dim PrevOldNode As TreeNode                         'Lưu dữ giá trị của node trước trong trường hợp xóa
    Dim sTrangThaiTabThietbi As String = String.Empty   'Ghi nhận trạng thái là thêm hay sửa
    Dim sMA_BP_OLD As String = String.Empty
    Dim sTEN_BP_OLD As String = String.Empty
    ' <summary>
    ' Thủ tục nạp dữ liệu lên Treeview theo mã máy
    ' </summary>
    ' <remarks></remarks>
    Sub ShowTreeRootChonBoPhanMuonThay(ByVal sMS_MAY As String, ByVal bThay As Boolean)

        If sMS_MAY.Trim().Length <= 0 Then
            Return
        End If

        TVChonBoPhanMuonThay.Nodes.Clear()

        Dim oNode As TreeNode = New TreeNode("Root")
        oNode = TVChonBoPhanMuonThay.Nodes.Add(sMS_MAY, sMS_MAY)

        Dim SqlText As String
        SqlText = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN_CHA=N'" & sMS_MAY & "'"

        Dim dtRoot As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlText).Tables(0)

        If dtRoot.Rows.Count <= 0 Then
            Return
        End If

        For Each drRoot As DataRow In dtRoot.Rows
            Dim sMaBP As String = drRoot("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drRoot("TEN_BO_PHAN").ToString()
            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)
            Call ShowTreeNode(sMS_MAY, sMaBP, oChildNode, bThay)
        Next

        TVChonBoPhanMuonThay.ExpandAll()
        TVChonBoPhanMuonThay.Focus()

    End Sub

    Sub ShowTreeRootChonBoPhanDeThay(ByVal sMS_MAY As String, ByVal bThay As Boolean)

        If sMS_MAY.Trim().Length <= 0 Then
            Return
        End If

        TVChonBoPhanDeThay.Nodes.Clear()

        Dim oNode As TreeNode = New TreeNode("Root")
        oNode = TVChonBoPhanDeThay.Nodes.Add(sMS_MAY, sMS_MAY)

        Dim SqlText As String
        SqlText = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN_CHA='" & sMS_MAY & "'"

        Dim dtRoot As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlText).Tables(0)

        If dtRoot.Rows.Count <= 0 Then
            Return
        End If

        For Each drRoot As DataRow In dtRoot.Rows
            Dim sMaBP As String = drRoot("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drRoot("TEN_BO_PHAN").ToString()
            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)
            Call ShowTreeNode(sMS_MAY, sMaBP, oChildNode, bThay)
        Next

        TVChonBoPhanDeThay.ExpandAll()
        TVChonBoPhanDeThay.Focus()

    End Sub

    Sub ShowTreeNode(ByVal sMS_MAY As String, ByVal sMS_BP As String, ByVal oNode As TreeNode, ByVal bthay As Boolean)
        If sMS_BP.Trim().Length <= 0 Then
            Return
        End If
        Dim SqlTextNode As String = ""
        If bthay Then
            SqlTextNode = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA=N'" & sMS_BP & "' AND MS_MAY = N'" & sMS_MAY & "'" & _
                            " AND MS_BO_PHAN NOT IN(select MS_BO_PHAN FROM BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName & " WHERE MS_MAY=N'" & sMS_MAY & "')"
        Else
            SqlTextNode = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA=N'" & sMS_BP & "' AND MS_MAY = N'" & sMS_MAY & "'" & _
                           " AND MS_BO_PHAN NOT IN(select MS_BO_PHAN_THAY_THE FROM BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName & " WHERE MS_MAY_THAY_THE=N'" & CboMSMayThayThe.SelectedValue & "')"
        End If

        Dim dtNode As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlTextNode).Tables(0)
        If dtNode.Rows.Count <= 0 Then
            Return
        End If

        For Each drNode As DataRow In dtNode.Rows
            Dim sMaBP As String = drNode("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drNode("TEN_BO_PHAN").ToString()

            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)

            Call ShowTreeNode(sMS_MAY, sMaBP, oChildNode, bthay)
        Next
    End Sub

#End Region

End Class