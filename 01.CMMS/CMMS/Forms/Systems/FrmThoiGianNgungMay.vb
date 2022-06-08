
Imports Microsoft.ApplicationBlocks.Data
Imports Microsoft.VisualBasic

Public Class FrmThoiGianNgungMay

    Private Sub FrmThoiGianNgungMay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLoaithietbi()
        mtxtTuNgay.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtDenNgay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        vTuNgay = DateTime.Now.AddMonths(-1)
        vDenNgay = DateTime.Now.Date


        AddHandler cbxLoaiMay.SelectedIndexChanged, AddressOf cbxLoaiMay_SelectedIndexChanged
        AddHandler mtxtTuNgay.Validating, AddressOf mtxtTuNgay_Validating
        AddHandler mtxtDenNgay.Validating, AddressOf mtxtDenNgay_Validating

    End Sub

#Region "Du lieu thanh phan"
    Private vEvent As String = "N"
    Private vMsMay As String = String.Empty

    Private vTuNgay As DateTime
    Private vDenNgay As DateTime


#End Region

#Region "Du lieu khoi tao"
    Sub LoadLoaithietbi()
        cbxLoaiMay.Value = "MS_LOAI_MAY"
        cbxLoaiMay.Display = "TEN_LOAI_MAY"
        cbxLoaiMay.StoreName = "GetLOAI_MAY_SEC"
        cbxLoaiMay.Param = Commons.Modules.UserName
        cbxLoaiMay.BindDataSource()
    End Sub

#End Region

#Region "Tab view"

    Sub LoadDiaDiem()
        vcboDiaDiem.Value = "MS_N_XUONG"
        vcboDiaDiem.Display = "TEN_N_XUONG"
        vcboDiaDiem.StoreName = "PermisionNHA_XUONG"
        vcboDiaDiem.Param = Commons.Modules.UserName
        vcboDiaDiem.BindDataSource()
    End Sub



#End Region
    Private Sub TabMain_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabMain.Selecting
        If vEvent = "E" Then
            e.Cancel = True

        End If

    End Sub

    Private Sub cbxLoaiMay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cbxLoaiMay.SelectedIndexChanged

    End Sub

    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles mtxtTuNgay.Validating
        If btnKhongGhi.Focused = True Then
            Exit Sub
        End If

    End Sub

    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles mtxtDenNgay.Validating

    End Sub


    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click

    End Sub
End Class