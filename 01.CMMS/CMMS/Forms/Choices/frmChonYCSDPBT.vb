Imports Microsoft.ApplicationBlocks.Data

Public Class frmChonYCSDPBT
    Dim sMsMay As String
    Public Property sMS_MAY() As String
        Get
            Return sMsMay
        End Get
        Set(ByVal value As String)
            sMsMay = value
        End Set
    End Property

    Dim dNgayKTKH As Date
    Public Property dNGAY_KTKH() As Date
        Get
            Return dNgayKTKH
        End Get
        Set(ByVal value As Date)
            dNgayKTKH = value
        End Set
    End Property

    Private Sub frmChonYCSDPBT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLuoi()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub txtTKiem_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtTKiem.EditValueChanging
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(grdYCBT.DataSource, DataTable)
            Dim str As String
            If txtTKiem.Text = "" Then str = "" Else str = " MS_YEU_CAU like '%" + txtTKiem.Text + "%' " & _
                    " OR SO_YEU_CAU like '%" + txtTKiem.Text + "%' OR  MO_TA_TINH_TRANG like '%" + txtTKiem.Text + "%' " & _
                    " OR YEU_CAU like '%" + txtTKiem.Text + "%'"
            dtTmp.DefaultView.RowFilter = str
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
        End Try
        dtTmp = dtTmp.DefaultView.ToTable()
    End Sub

    Private Sub LoadLuoi()
        Dim dtTmp As New DataTable
        Dim sBT As String = "SD_CHON" & Commons.Modules.UserName
        Dim sBTam As String = "SDQYC_CHON" & Commons.Modules.UserName

        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetChonYeuCauNSDBaoTri", sMsMay, dNgayKTKH))
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "")

        sBT = " SELECT  CHON,MS_YEU_CAU, SO_YEU_CAU, MO_TA_TINH_TRANG, YEU_CAU, NGAY_GIO_XR, THOI_GIAN_DSX, " & _
                    " USERNAME_DSX, NGAY_DBT, USERNAME_DBT,STT_VAN_DE , MS_MAY ,STT,NGAY_XAY_RA, GIO_XAY_RA FROM " & sBTam & " A  " & _
                    " WHERE NOT EXISTS (SELECT * FROM " & sBT & " B WHERE A.STT = B.STT AND A.MS_MAY = B.MS_MAY AND A.STT_VAN_DE = B.STT_VAN_DE) " & _
                    " ORDER BY MS_YEU_CAU, SO_YEU_CAU, MO_TA_TINH_TRANG, YEU_CAU "
        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sBT))
        dtTmp.Columns(0).ReadOnly = False
        Commons.Modules.ObjSystems.XoaTable("SD_CHON" & Commons.Modules.UserName)
        Commons.Modules.ObjSystems.XoaTable(sBTam)

        Commons.Modules.ObjSystems.MLoadXtraGrid(grdYCBT, grvYCBT, dtTmp, True, True, True, True)
        For i As Integer = 1 To dtTmp.Columns.Count - 1
            dtTmp.Columns(i).ReadOnly = True
            grvYCBT.Columns(i).OptionsColumn.ReadOnly = True
            If i > 9 Then
                grvYCBT.Columns(i).Visible = False
            End If
        Next
        grvYCBT.Columns("NGAY_GIO_XR").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        grvYCBT.Columns("NGAY_GIO_XR").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        grvYCBT.Columns("THOI_GIAN_DSX").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        grvYCBT.Columns("THOI_GIAN_DSX").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        grvYCBT.Columns("NGAY_DBT").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        grvYCBT.Columns("NGAY_DBT").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        grvYCBT.OptionsView.ColumnAutoWidth = False
        grvYCBT.Columns("NGAY_GIO_XR").Width = 120
        grvYCBT.Columns("MO_TA_TINH_TRANG").Width = 300
        grvYCBT.Columns("YEU_CAU").Width = 120
        grvYCBT.Columns("CHON").Width = 90
        grvYCBT.Columns("THOI_GIAN_DSX").Width = 120
        grvYCBT.Columns("NGAY_DBT").Width = 120

        ' ,  ,,, 

        grvYCBT.Columns("STT_VAN_DE").Visible = False
        grvYCBT.Columns("MS_MAY").Visible = False
        grvYCBT.Columns("STT").Visible = False
        grvYCBT.Columns("NGAY_XAY_RA").Visible = False
        grvYCBT.Columns("GIO_XAY_RA").Visible = False
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        FrmPhieuBaoTri_New.dtYCSDung = CType(grdYCBT.DataSource, DataTable)
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnThoatYCBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoatYCBT.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class