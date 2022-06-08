Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Catalogue

Public Class FrmChonDichVuThueNgoaiChoPBT

    Dim dtTable As DataTable
    Private _TBDichVu As New DataTable
    Public Property TBDichVu() As DataTable
        Get
            Return _TBDichVu
        End Get
        Set(ByVal value As DataTable)
            _TBDichVu = value
        End Set
    End Property
#Region "Event form"
    Private Sub FrmChonDichVuThueNgoaiChoPBT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        LoadData()
        Checked_Data()
    End Sub
    Sub Checked_Data()
        For i As Integer = 0 To TBDichVu.Rows.Count - 1
            For j As Integer = 0 To dtTable.Rows.Count - 1
                If dtTable.Rows(j).Item("EOR_ID") = TBDichVu.Rows(i).Item("EOR_ID") And dtTable.Rows(j).Item("STT") = TBDichVu.Rows(i).Item("STT_EOR") And TBDichVu.Rows(i).Item("MnR") = dtTable.Rows(j).Item("MnR") Then
                    dgrDanhSachDV.Rows(j).Cells("CHON").Value = True
                    Exit For
                End If
            Next
        Next
    End Sub
    Private Sub dtpTuNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTuNgay.ValueChanged
        LoadData()
    End Sub
    Private Sub dtpDenNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDenNgay.ValueChanged
        LoadData()
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        'CapNhatDLChon()
        TBDichVu = New clsPHIEU_BAO_TRI_SERVICEController().GetDanhsachDVThueNgoai(FrmPhieuBaoTri_KIDO.txtMaSoPBT.Text.Trim)
        Dim strPBT As String = FrmPhieuBaoTri_KIDO.txtMaSoPBT.Text.Trim
        For i As Integer = 0 To dtTable.Rows.Count - 1
            If dtTable.Rows(i).Item("CHON") Then
                Dim dr As DataRow
                dr = TBDichVu.NewRow
                dr.Item("MS_PHIEU_BAO_TRI") = strPBT
                dr.Item("STT") = 0
                dr.Item("NOI_DUNG_SERVICE") = dtTable.Rows(i).Item("NOI_DUNG_SERVICE")
                dr.Item("MS_KH") = dtTable.Rows(i).Item("MS_KH")
                dr.Item("TEN_RUT_GON") = dtTable.Rows(i).Item("TEN_RUT_GON")
                dr.Item("SO_LUONG") = dtTable.Rows(i).Item("SO_LUONG")
                dr.Item("DON_GIA") = dtTable.Rows(i).Item("DON_GIA")
                dr.Item("NGOAI_TE") = dtTable.Rows(i).Item("NGOAI_TE")
                dr.Item("THANH_TIEN") = dtTable.Rows(i).Item("DON_GIA") * dtTable.Rows(i).Item("SO_LUONG")
                dr.Item("TY_GIA") = dtTable.Rows(i).Item("TY_GIA")
                dr.Item("TY_GIA_USD") = dtTable.Rows(i).Item("TY_GIA_USD")
                dr.Item("NGUOI_GIAO_DICH") = dtTable.Rows(i).Item("NGUOI_GIAO_DICH")
                dr.Item("EOR_ID") = dtTable.Rows(i).Item("EOR_ID")
                dr.Item("STT_EOR") = dtTable.Rows(i).Item("STT")
                dr.Item("MnR") = dtTable.Rows(i).Item("MnR")
                TBDichVu.Rows.Add(dr)
            End If
        Next
        DialogResult = Windows.Forms.DialogResult.OK
        'Me.Dispose()
    End Sub
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click

        Me.Dispose()
    End Sub
#End Region

#Region "Sub and function"
    Sub LoadData()
        dtTable = New clsPHIEU_BAO_TRI_SERVICEController().TaoDLChonServiceChung_Mnr(FrmPhieuBaoTri_KIDO.txtMaSoPBT.Text, _
            dtpTuNgay.Value, dtpDenNgay.Value)
        With dgrDanhSachDV
            .Columns.Clear()
            .DataSource = dtTable
            .Columns("CHON").ReadOnly = False
            .Columns("EOR_ID").Visible = False
            .Columns("STT").Visible = False
            .Columns("MS_MAY").Visible = False
            .Columns("EOR_ID").Visible = False
            .Columns("MS_KH").Visible = False
            .Columns("MNR").Visible = False
            .Columns("SO_LUONG").Visible = False
            .Columns("DON_GIA").Visible = False
            .Columns("TY_GIA").Visible = False
            .Columns("TY_GIA_USD").Visible = False
            .Columns("NGOAI_TE").Visible = False
            .Columns("NGUOI_GIAO_DICH").Visible = False
            .Columns("SO_ROA").ReadOnly = True
            .Columns("NGAY_ROA").ReadOnly = True
            .Columns("NOI_DUNG_SERVICE").ReadOnly = True
            .Columns("LOAI_DV").ReadOnly = True
            .Columns("TEN_RUT_GON").ReadOnly = True

            .Columns("SO_ROA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_ROA", commons.Modules.TypeLanguage)
            .Columns("NGAY_ROA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_ROA", commons.Modules.TypeLanguage)
            .Columns("NOI_DUNG_SERVICE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NOI_DUNG_SERVICE", commons.Modules.TypeLanguage)
            .Columns("LOAI_DV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LOAI_DV", commons.Modules.TypeLanguage)
            .Columns("TEN_RUT_GON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_RUT_GON", commons.Modules.TypeLanguage)
            .Columns("CHON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON", commons.Modules.TypeLanguage)

            .Columns("SO_ROA").Width = 100
            .Columns("NGAY_ROA").Width = 100
            .Columns("NOI_DUNG_SERVICE").Width = 216
            .Columns("LOAI_DV").Width = 136
            .Columns("TEN_RUT_GON").Width = 120
            .Columns("CHON").Width = 46
        End With
        Try
            Me.dgrDanhSachDV.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrDanhSachDV.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try


    End Sub
    'Sub CapNhatDLChon()
    '    Dim blnXNGhi As Boolean
    '    blnXNGhi = New clsPHIEU_BAO_TRI_SERVICEController().CapNhatDuLieuDVChon(dtTable, FrmPhieuBaoTri.txtMaSoPBT.Text)
    'End Sub
#End Region
End Class