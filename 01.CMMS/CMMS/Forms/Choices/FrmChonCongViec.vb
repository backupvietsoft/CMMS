Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin

Public Class FrmChonCongViec
    Dim dtTableTam, dtTableOne As DataTable
    Dim sql As String


    Private Sub frmPartner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        commons.Modules.ObjSystems.DinhDang()
        BindData()
    End Sub

    Sub BindData()
        Dim column As New DataGridViewCheckBoxColumn
        Dim dtReader As SqlDataReader
        Dim MS_LOAI_MAY, MAYs As String
        Dim MS_LOAI_BT As Integer
        grdChonCongViec.Columns.Clear()
        With column
            .Name = "chkChon"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With

        LoadLoaiCongViec()
        sql = "SELECT MS_LOAI_MAY FROM MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY WHERE MS_MAY=N'" & frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        MS_LOAI_MAY = ""
        While dtReader.Read
            MS_LOAI_MAY = dtReader.Item(0)
        End While
        dtReader.Close()
        MS_LOAI_BT = frmThongtinthietbi.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
        dtTableTam = New DataTable
        MAYs = frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
        dtTableTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_LOAI_CV", CboLoaiCongViec.SelectedValue, MS_LOAI_BT, MAYs, MS_LOAI_MAY))
        grdChonCongViec.DataSource = dtTableTam
        grdChonCongViec.Columns.Insert(3, column)
        grdChonCongViec.Columns("MS_CV").Visible = False
        grdChonCongViec.Columns("MS_LOAI_CV").Visible = False
        Try
            Me.grdChonCongViec.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdChonCongViec.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
        RefeshLanguage()

        AddHandler CboLoaiCongViec.SelectedIndexChanged, AddressOf Me.CboLoaiCongViec_SelectedIndexChanged
    End Sub

    Sub LoadLoaiCongViec()
        CboLoaiCongViec.Value = "MS_LOAI_CV"
        CboLoaiCongViec.Display = "TEN_LOAI_CV"
        CboLoaiCongViec.StoreName = "GetLOAI_CONG_VIECs"
        CboLoaiCongViec.ClassName = "frmLoaicongviec"
        CboLoaiCongViec.BindDataSource()
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub BtnChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTatCa.Click
        Dim i As Integer
        While i < grdChonCongViec.RowCount
            grdChonCongViec.Rows(i).Cells("chkChon").Value = True
            i = i + 1
        End While
    End Sub

    Private Sub BtnBoChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoChonTatCa.Click
        Dim i As Integer
        While i < grdChonCongViec.RowCount
            grdChonCongViec.Rows(i).Cells("chkChon").Value = False
            i = i + 1
        End While
    End Sub

    Private Sub BtnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        Dim i As Integer
        Dim dtRow As DataRow
        Dim dtReader As SqlDataReader
        Dim loaibts As Integer
        dtTableOne = New DataTable
        loaibts = frmThongtinthietbi.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
        dtTableOne.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOAI_BTPN_CONG_VIEC", frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), loaibts))

        While i < dtTableTam.Rows.Count
            If grdChonCongViec.Rows(i).Cells("chkChon").Value = True Then
                dtRow = dtTableOne.NewRow
                dtRow.Item(0) = frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
                dtRow.Item(1) = frmThongtinthietbi.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
                dtRow.Item(2) = grdChonCongViec.Rows(i).Cells("MS_CV").Value
                sql = "SELECT MO_TA_CV FROM CONG_VIEC WHERE MS_CV=" & grdChonCongViec.Rows(i).Cells("MS_CV").Value
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                While dtReader.Read
                    dtRow.Item(3) = dtReader.Item(0)
                End While
                dtTableOne.Rows.Add(dtRow)
            End If
            i = i + 1
        End While

        frmThongtinthietbi.grdLoaiBTPN_CV.DataSource = dtTableOne
        frmThongtinthietbi.grvLoaiBTPN_CV.Columns(0).Visible = False
        frmThongtinthietbi.grvLoaiBTPN_CV.Columns(1).Visible = False
        frmThongtinthietbi.grvLoaiBTPN_CV.Columns(2).Visible = False

        Me.Close()
    End Sub

    Private Sub CboLoaiCongViec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dtReader As SqlDataReader
        Dim MS_LOAI_MAY As String
        Dim MS_LOAI_BT As Integer
        sql = "SELECT MS_LOAI_MAY FROM MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY WHERE MS_MAY=N'" & frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        MS_LOAI_MAY = ""
        While dtReader.Read
            MS_LOAI_MAY = dtReader.Item(0)
        End While

        MS_LOAI_BT = frmThongtinthietbi.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
        dtTableTam = New DataTable
        dtTableTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_LOAI_CV", CboLoaiCongViec.SelectedValue, MS_LOAI_BT, frmThongtinthietbi.grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), MS_LOAI_MAY))
        grdChonCongViec.DataSource = dtTableTam

    End Sub

    Private Sub RefeshLanguage()
        LblChonCV.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblChonCV.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnBoChonTatCa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnBoChonTatCa.Name, commons.Modules.TypeLanguage)
        Me.BtnChonTatCa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnChonTatCa.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThucHien.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        LblTieudechukyBTPN.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieudechukyBTPN.Name, commons.Modules.TypeLanguage)
        Me.grdChonCongViec.Columns("MO_TA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MO_TA_CV", commons.Modules.TypeLanguage)
        Me.grdChonCongViec.Columns(3).HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON", commons.Modules.TypeLanguage)
    End Sub
End Class