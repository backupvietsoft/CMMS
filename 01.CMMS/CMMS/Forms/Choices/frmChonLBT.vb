Public Class frmChonLBT 
    Dim sMsMay As String
    Public bLapNhieu As Boolean = False


    Public Property sMS_MAY() As String
        Get
            Return sMsMay
        End Get
        Set(ByVal value As String)
            sMsMay = value
        End Set
    End Property

    Dim iLBT As Integer
    Public Property iLoaiBT() As Integer
        Get
            Return iLBT
        End Get
        Set(ByVal value As Integer)
            iLBT = value
        End Set
    End Property

    Dim sNguoiLap As String
    Public Property sNLap() As String
        Get
            Return sNguoiLap
        End Get
        Set(ByVal value As String)
            sNguoiLap = value
        End Set
    End Property

    Dim sNguoiGS As String
    Public Property sNGSat() As String
        Get
            Return sNguoiGS
        End Get
        Set(ByVal value As String)
            sNguoiGS = value
        End Set
    End Property

    Dim dNgayBDKH As String
    Public Property dNBDKH() As Date
        Get
            Return dNgayBDKH
        End Get
        Set(ByVal value As Date)
            dNgayBDKH = value
        End Set
    End Property

    Dim dNgayKTKH As String
    Public Property dNKTKH() As Date
        Get
            Return dNgayKTKH
        End Get
        Set(ByVal value As Date)
            dNgayKTKH = value
        End Set
    End Property

    


    Private Sub frmChonLBT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.SQLString = ""
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Dim dtTmp As New DataTable
        dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                    "GetLOAI_BAO_TRI_PBT_THEO_BTPN", sMS_MAY))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLBT, dtTmp, "MS_LOAI_BT", "TEN_LOAI_BT", lblLBT.Text)
        If bLapNhieu = False And iLBT = -1 Then
            cboLBT.EditValue = -1
        Else
            cboLBT.EditValue = iLoaiBT
            cboLBT.Enabled = False
            'datNgayBDKH.Enabled = False
            'datNgayKTKH.Enabled = False
        End If

        If bLapNhieu Then
            datNgayBDKH.Enabled = False
            datNgayKTKH.Enabled = False
        End If
        dtTmp = New DataTable
        dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                    "MGetCongNhanPBTTN", 2, "-1"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguoiLap, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", lblLBT.Text)

        Try
            cboNguoiLap.EditValue = sNguoiLap
            If cboNguoiLap.Text = "" Then
                cboNguoiLap.EditValue = dtTmp.Rows(0)("MS_CONG_NHAN")
            End If
        Catch ex As Exception
        End Try

        dtTmp = New DataTable
        dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                    "MGetCongNhanPBTTN", 3, "-1"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguoiGS, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", lblLBT.Text)
        Try
            cboNguoiGS.EditValue = sNguoiGS
            If cboNguoiGS.Text = "" Then
                cboNguoiGS.EditValue = dtTmp.Rows(0)("MS_CONG_NHAN")
            End If

        Catch ex As Exception
        End Try

        Try
            datNgayBDKH.DateTime = dNgayBDKH
        Catch ex As Exception

        End Try

        Try
            datNgayKTKH.DateTime = dNgayKTKH
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        Try
            If CDate(datNgayBDKH.Text) > CDate(datNgayKTKH.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, FrmPhieuBaoTri_New.Name, "MsgNgayKTKH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgNgayKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End Try
        If cboLBT.EditValue = -1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaChonLoaiPBT", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Return
        End If

        Commons.Modules.SQLString = cboLBT.EditValue.ToString
        iLoaiBT = cboLBT.EditValue.ToString
        sNguoiLap = cboNguoiLap.EditValue
        sNguoiGS = cboNguoiGS.EditValue
        dNgayBDKH = datNgayBDKH.DateTime.Date
        dNgayKTKH = datNgayKTKH.DateTime.Date
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Commons.Modules.SQLString = ""
        iLoaiBT = -1
        sNguoiLap = ""
        sNguoiGS = ""
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class