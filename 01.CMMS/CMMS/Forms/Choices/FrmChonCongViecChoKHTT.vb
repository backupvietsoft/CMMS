Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin
Imports System.Linq
Imports DevExpress.XtraEditors

Public Class FrmChonCongViecChoKHTT
    Dim dtTableOne As DataTable
    Dim sql As String
    Dim _sMS_MAY As String
    Dim _sHANG_MUC_ID, _sLOC, _iRecNum As Integer
    Public _lstCV As New List(Of Integer)
    Dim _frm_khbt As String

    Public Property MS_MAY() As String
        Get
            Return _sMS_MAY
        End Get
        Set(ByVal value As String)
            _sMS_MAY = value
        End Set
    End Property

    Public Property Frm_KeHoachBaoTri() As String
        Get
            Return _frm_khbt
        End Get
        Set(ByVal value As String)
            _frm_khbt = value
        End Set
    End Property


    Public Property HANG_MUC_ID() As Integer
        Get
            Return _sHANG_MUC_ID
        End Get
        Set(ByVal value As Integer)
            _sHANG_MUC_ID = value
        End Set
    End Property

    Public Property LOC() As Integer
        Get
            Return _sLOC
        End Get
        Set(ByVal value As Integer)
            _sLOC = value
        End Set
    End Property

    Public Property RecNum() As Integer
        Get
            Return _iRecNum
        End Get
        Set(ByVal value As Integer)
            _iRecNum = value
        End Set
    End Property

    Private Sub frmPartner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Commons.Modules.ObjSystems.DinhDang()
            LoadLoaiCongViec()
            txtGiatri.Text = ""
            Try
                grdChonCongViec.Columns.Clear()
                grdChonCongViec.DataSource = System.DBNull.Value
            Catch ex As Exception

            End Try

            ShowTreeRoot(_sMS_MAY)
            AddHandler CboLoaiCongViec.SelectedIndexChanged, AddressOf Me.CboLoaiCongViec_SelectedIndexChanged
            Commons.Modules.ObjSystems.XoaTable("CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName)

            Commons.Modules.SQLString = "SELECT CAU_TRUC_THIET_BI_CONG_VIEC.*,MO_TA_CV,TEN_BO_PHAN,0 AS CHON INTO CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName &
                        " FROM CAU_TRUC_THIET_BI_CONG_VIEC INNER JOIN CAU_TRUC_THIET_BI ON CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY=CAU_TRUC_THIET_BI.MS_MAY " &
                        " AND CAU_TRUC_THIET_BI_CONG_VIEC.MS_BO_PHAN=CAU_TRUC_THIET_BI.MS_BO_PHAN INNER JOIN CONG_VIEC ON CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV=CONG_VIEC.MS_CV " &
                        " WHERE CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY=N'" & _sMS_MAY & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            CreateMenuCV(grdChonCongViec)
            TVw.ExpandAll()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub LoadLoaiCongViec()
        CboLoaiCongViec.Value = "MS_LOAI_CV"
        CboLoaiCongViec.Display = "TEN_LOAI_CV"
        CboLoaiCongViec.StoreName = "GetLOAI_CONG_VIEC_PQ"
        CboLoaiCongViec.Param = Commons.Modules.UserName
        CboLoaiCongViec.ClassName = "frmLoaicongviec"
        CboLoaiCongViec.BindDataSource()

    End Sub
    Private Function returnParentNode(ByVal nodeChild As String) As String
        Dim i As Integer = 0
        Dim parentNode As String
        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_BO_PHAN_CHA FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN=N'" & nodeChild & "'"))
        parentNode = dt.Rows(0)(0).ToString()
        If parentNode = MS_MAY Then
            Return Nothing
        End If
        Return (parentNode & "<" & returnParentNode(parentNode))
    End Function
    Private Sub printClickNode()
        Dim str As String = ""
        Dim filename As String
        Dim SqlText As String = ""
        If TVw.Nodes.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHOI_TAO_LSTB", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        If TVw.SelectedNode.Level = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_CTTB", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        'If MS_MAY = "" Then
        '    txtMayTT.Text = txtMS_MAY.Text
        'End If
        Try
            SqlText = "DROP TABLE DBO.EXPORT_TO_EXCEL"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Dim ngay_TN As String = "" 'Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day.ToString()
        Dim thang_TN As String = "" ' Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month.ToString()
        Dim nam_TN As String = "" ' Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year.ToString()
        Dim _date_TN As String = "" 'thang_TN & "/" & ngay_TN & "/" & nam_TN
        Dim ngay_DN As String = "" 'Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day.ToString()
        Dim thang_DN As String = "" ' Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month.ToString()
        Dim nam_DN As String = "" 'Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year.ToString()
        Dim _date_DN As String = thang_DN & "/" & ngay_DN & "/" & nam_DN

        SqlText = "SELECT     " &
                      "dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY AS MAY_TH, dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN AS TEN_BP_TH, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH,  " &
                      "dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.CONG_VIEC.MO_TA_CV, dbo.PHIEU_BAO_TRI_CONG_VIEC.PHU_TUNG_TT,  " &
                      "dbo.PHIEU_BAO_TRI_CONG_VIEC.GHI_CHU,  dbo.NHOM_MAY.MS_LOAI_MAY, dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_MAY_TT, dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN_TT " &
                      "INTO DBO.EXPORT_TO_EXCEL FROM dbo.PHIEU_BAO_TRI_CONG_VIEC INNER JOIN " &
                      "dbo.PHIEU_BAO_TRI ON dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI INNER JOIN " &
                      "dbo.MAY ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " &
                      "dbo.NHOM_MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN " &
                      "dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN " &
                      "dbo.CONG_VIEC ON dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV = dbo.CONG_VIEC.MS_CV INNER JOIN                       dbo.CAU_TRUC_THIET_BI ON dbo.MAY.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND                       dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN " &
                    "WHERE (dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN_TT IS NOT NULL) and " &
                    "(dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_MAY_TT = N'" & MS_MAY & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Dim dt_ClickNode, dtFirst_ClickNode As New DataTable()
        dtFirst_ClickNode.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM DBO.EXPORT_TO_EXCEL"))
        If dtFirst_ClickNode.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DL_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        dt_ClickNode.Columns.Add("MS_PHIEU_BAO_TRI")
        dt_ClickNode.Columns.Add("MAY_TH")
        dt_ClickNode.Columns.Add("TEN_BP_TH")
        dt_ClickNode.Columns.Add("TEN_LOAI_BT")
        dt_ClickNode.Columns.Add("NGAY_BD_KH")
        dt_ClickNode.Columns.Add("NGAY_KT_KH")
        dt_ClickNode.Columns.Add("MO_TA_CV")
        dt_ClickNode.Columns.Add("PHU_TUNG_TT")
        dt_ClickNode.Columns.Add("GHI_CHU")
        dt_ClickNode.Columns.Add("MS_LOAI_MAY")
        dt_ClickNode.Columns.Add("MS_MAY_TT")
        dt_ClickNode.Columns.Add("MS_BO_PHAN_TT")
        dt_ClickNode.Columns.Add("TU_NGAY")
        dt_ClickNode.Columns.Add("DEN_NGAY")
        Dim drr_ClickNode As DataRow
        For Each drFirst As DataRow In dtFirst_ClickNode.Rows
            drr_ClickNode = dt_ClickNode.NewRow()
            drr_ClickNode("MS_PHIEU_BAO_TRI") = drFirst("MS_PHIEU_BAO_TRI").ToString()
            drr_ClickNode("MAY_TH") = drFirst("MAY_TH").ToString()
            drr_ClickNode("TEN_BP_TH") = drFirst("TEN_BP_TH").ToString()
            drr_ClickNode("TEN_LOAI_BT") = drFirst("TEN_LOAI_BT").ToString()
            drr_ClickNode("NGAY_BD_KH") = Format(drFirst("NGAY_BD_KH").ToString(), "short date")
            drr_ClickNode("NGAY_KT_KH") = Format(drFirst("NGAY_KT_KH").ToString(), "short date")
            drr_ClickNode("MO_TA_CV") = drFirst("MO_TA_CV").ToString()
            drr_ClickNode("PHU_TUNG_TT") = drFirst("PHU_TUNG_TT").ToString()
            drr_ClickNode("GHI_CHU") = drFirst("GHI_CHU").ToString()
            drr_ClickNode("MS_LOAI_MAY") = drFirst("MS_LOAI_MAY").ToString()
            drr_ClickNode("MS_MAY_TT") = drFirst("MS_MAY_TT").ToString()
            drr_ClickNode("MS_BO_PHAN_TT") = drFirst("MS_BO_PHAN_TT").ToString()
            dt_ClickNode.Rows.Add(drr_ClickNode)
        Next

        Dim Excel_ClickNode As Object = CreateObject("Excel.Application")
        If Excel_ClickNode Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "EXCEL_NOT_INSTALL", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical)
            Return
        End If

        With Excel_ClickNode
            .SheetsInNewWorkbook = 1
            .Workbooks.Add()
            .Worksheets(1).Select()

            Dim colCell As Integer = 1
            Dim rowCell As Integer = 4
            Dim dtDistinct As New DataTable()
            dtDistinct.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT DISTINCT TOP 100 PERCENT MS_BO_PHAN_TT   FROM  dbo.EXPORT_TO_EXCEL   ORDER BY MS_BO_PHAN_TT"))

            'Tạo bảng lấy các mã bộ phận có dữ liệu của thiết bị đang chọn
            Dim notData As Boolean = True
            For Each dr As DataRow In dtDistinct.Rows
                str = dr("MS_BO_PHAN_TT").ToString() & "<" & returnParentNode(dr("MS_BO_PHAN_TT").ToString()) & MS_MAY
                Dim strFirst() As String = str.Split("<")

                'Kiểm tra xem mã thiết bị có là con của node đang chọn hay ko
                For ident As Integer = strFirst.Length - 1 To 0 Step -1
                    If strFirst(ident).ToString() = TVw.SelectedNode.Name.ToString() Then
                        notData = False
                        colCell = 1

                        'IN CÁC GROUP
                        Dim levelNode As Integer = TVw.SelectedNode.Level + 1 ' 1 đv cấu trúc vòng lập
                        For k As Integer = (strFirst.Length - levelNode) To 0 Step -1
                            .cells(rowCell, colCell).EntireRow.Font.Bold = True
                            .Cells(rowCell, colCell).Value = strFirst(k).ToString()
                            .cells(rowCell, colCell).EntireRow.Font.Color = RGB(0, 100, 200)

                            For i As Integer = rowCell - 1 To 1 Step -1
                                If .cells(rowCell, colCell).value = .cells(i, colCell).value Then
                                    .Cells(rowCell, colCell).Value = ""
                                    .cells(rowCell, colCell).EntireRow.Font.Bold = False
                                End If
                            Next
                            rowCell += 1
                            colCell += 1
                        Next
                        colCell -= 1 ' In tên các trường và dữ liệu ngay dưới Group cuối 
                        Dim colCellCurrent As Integer = colCell

                        'IN TÊN CÁC TRƯỜNG
                        Try
                            .Cells(rowCell, colCell).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
                            .cells(rowCell, colCell).Font.Bold = True
                            colCell += 1
                            .Cells(rowCell, colCell).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THUC_HIEN_TREN_TB", Commons.Modules.TypeLanguage)
                            .cells(rowCell, colCell).Font.Bold = True
                            colCell += 1
                            .Cells(rowCell, colCell).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THUC_HIEN_TREN_BP", Commons.Modules.TypeLanguage)
                            .cells(rowCell, colCell).Font.Bold = True
                            colCell += 1
                            .Cells(rowCell, colCell).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOAI_BT", Commons.Modules.TypeLanguage)
                            .cells(rowCell, colCell).Font.Bold = True
                            colCell += 1
                            .Cells(rowCell, colCell).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_BT", Commons.Modules.TypeLanguage)
                            .cells(rowCell, colCell).Font.Bold = True
                            colCell += 1
                            .Cells(rowCell, colCell).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_KT", Commons.Modules.TypeLanguage)
                            .cells(rowCell, colCell).Font.Bold = True
                            colCell += 1
                            .Cells(rowCell, colCell).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MO_TA_CV", Commons.Modules.TypeLanguage)
                            .cells(rowCell, colCell).Font.Bold = True
                            colCell += 1
                            .Cells(rowCell, colCell).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHU_TUNG_TT", Commons.Modules.TypeLanguage)
                            .cells(rowCell, colCell).Font.Bold = True
                            colCell += 1
                            .Cells(rowCell, colCell).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
                            .cells(rowCell, colCell).Font.Bold = True


                            'IN NỘI DUNG
                            For Each drFilter As DataRow In dt_ClickNode.Rows
                                If drFilter("MS_BO_PHAN_TT").ToString().Trim() = dr("MS_BO_PHAN_TT").ToString().Trim() Then
                                    rowCell += 1
                                    colCell = colCellCurrent

                                    For dcol As Integer = 0 To dt_ClickNode.Columns.Count - 6

                                        .Cells(rowCell, colCell).Value = drFilter(dcol).ToString()
                                        .cells(rowCell, colCell).Font.Bold = False
                                        .Cells(rowCell, colCell).Borders.LineStyle = 1
                                        .Cells(rowCell, colCell).Columns.AutoFit()
                                        colCell += 1
                                    Next
                                End If
                            Next
                            rowCell += 1
                        Catch ex As Exception
                            'MsgBox("vao catch")
                        End Try
                    End If
                Next ' Kết thúc kiểm tra xem mã thiết bị có là con của node đang chọn hay ko
            Next ' Kết thúc tạo bảng lấy các mã bộ phận có dữ liệu của thiết bị đang chọn

            If notData = True Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DL_IN", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            'IN TIÊU ĐỀ VÀ NGÀY
            '.Range(.Cells(1, 1).Address & ":" & .Cells(1, colCell - 1).Address).Merge()
            .Cells(1, 1).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TIEU_DE_LICH_SU_TB", Commons.Modules.TypeLanguage) & "   " & MS_MAY
            .Cells(1, 1).Font.Bold = True
            .Cells(1, 1).Font.Size = 16
            '.Cells(2, 1).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TU_NGAY", commons.Modules.TypeLanguage) & " " & dt_ClickNode.Rows(0)("TU_NGAY").ToString() & "   " & Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DEN_NGAY", commons.Modules.TypeLanguage) & " " & dt_ClickNode.Rows(0)("DEN_NGAY").ToString()
            '.Range(.Cells(2, 1).Address & ":" & .Cells(2, colCell).Address).HorizontalAlignment = HorizontalAlignment.Center

            filename = "C:\Documents and Settings\LichSuCauTrucThietBi" & Format(Now(), "dd-MM-yyyy_hh-mm-ss") & ".xls"
            .ActiveCell.Worksheet.SaveAs(filename)
        End With

        System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel_ClickNode)
        Excel_ClickNode = Nothing
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "XUAT_TC", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
        Try
            System.Diagnostics.Process.Start(filename)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        CboLoaiCongViec.DataSource = Nothing
        grdChonCongViec.DataSource = DBNull.Value
        TVw.Nodes.Clear()
        Me.Close()
    End Sub

    Private Sub BtnChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTatCa.Click
        Dim i As Integer
        While i < grdChonCongViec.RowCount
            grdChonCongViec.Rows(i).Cells("chkChon").Value = True
            Commons.Modules.SQLString = "UPDATE CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName & " SET CHON=1 WHERE MS_MAY=N'" & _sMS_MAY & "' AND MS_BO_PHAN='" & grdChonCongViec.Rows(i).Cells("MS_BO_PHAN").Value & "' AND MS_CV=" & grdChonCongViec.Rows(i).Cells("MS_CV").Value
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            i = i + 1
        End While
    End Sub

    Private Sub BtnBoChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoChonTatCa.Click
        Dim i As Integer
        While i < grdChonCongViec.RowCount
            grdChonCongViec.Rows(i).Cells("chkChon").Value = False
            Commons.Modules.SQLString = "UPDATE CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName & " SET CHON=0 WHERE MS_MAY=N'" & _sMS_MAY & "' AND MS_BO_PHAN='" & grdChonCongViec.Rows(i).Cells("MS_BO_PHAN").Value & "' AND MS_CV=" & grdChonCongViec.Rows(i).Cells("MS_CV").Value
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            i = i + 1
        End While
    End Sub

    Private Sub BtnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        'Dim i As Integer
        Dim dtReader As SqlDataReader

        dtTableOne = New DataTable
        Commons.Modules.SQLString = "SELECT * FROM CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName & " WHERE CHON=1"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Dim idtmp As Integer = 1

        While dtReader.Read
            idtmp = idtmp + 1
            Try
                Dim TGKH As Double = 0
                Try
                    TGKH = dtReader.Item("TG_KH")
                Catch ex As Exception
                End Try



                If Frm_KeHoachBaoTri = "frmKehoachtongtheNew" Then
                    Commons.Modules.SQLString = "INSERT INTO KHTCV_TMP" & Commons.Modules.UserName &
                        "(ID,MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,TG_KH) VALUES( '" & idtmp & "' ,  N'" & _sMS_MAY & "'," & _sHANG_MUC_ID & "," &
                        dtReader.Item("MS_CV") & ",'" & dtReader.Item("MS_BO_PHAN") & "' ," & TGKH & " )"
                Else
                    Commons.Modules.SQLString = "INSERT INTO KHTCV_TMP" & Commons.Modules.UserName &
                        "(MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,THOI_GIAN_DU_KIEN) VALUES( N'" & _sMS_MAY & "'," & _sHANG_MUC_ID & "," &
                        dtReader.Item("MS_CV") & ",'" & dtReader.Item("MS_BO_PHAN") & "'," & TGKH & ")"
                End If

                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            Catch ex As Exception
            End Try
        End While

        dtReader.Close()
        CboLoaiCongViec.DataSource = Nothing
        grdChonCongViec.DataSource = DBNull.Value
        TVw.Nodes.Clear()
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub CboLoaiCongViec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowCongviecBoPhan(CboLoaiCongViec.SelectedValue)
    End Sub

    Private Sub RefeshLanguage()
        LblChonCV.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, LblChonCV.Name, Commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.BtnBoChonTatCa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnBoChonTatCa.Name, Commons.Modules.TypeLanguage)
        Me.BtnChonTatCa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnChonTatCa.Name, Commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThoat.Name, Commons.Modules.TypeLanguage)
        Me.BtnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThucHien.Name, Commons.Modules.TypeLanguage)
        LblTieuDe.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, LblTieuDe.Name, Commons.Modules.TypeLanguage)
        Me.grdChonCongViec.Columns("MO_TA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MO_TA_CV", Commons.Modules.TypeLanguage)
        Me.grdChonCongViec.Columns("chkChon").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON", Commons.Modules.TypeLanguage)
        Me.grdChonCongViec.Columns("TG_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TG_KH", Commons.Modules.TypeLanguage)
        Me.GrpChonBoPhan.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.GrpChonBoPhan.Name, Commons.Modules.TypeLanguage)
        Me.GrpChonCV.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.GrpChonCV.Name, Commons.Modules.TypeLanguage)
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
    Sub ShowTreeRoot(ByVal sMS_MAY As String)

        'tvwCautrucTB.CheckBoxes = True
        If sMS_MAY.Trim().Length <= 0 Then
            Return
        End If

        TVw.Nodes.Clear()

        Dim oNode As TreeNode = New TreeNode("Root")
        oNode = TVw.Nodes.Add(sMS_MAY, sMS_MAY)

        Dim SqlText As String
        SqlText = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN_CHA=N'" & sMS_MAY & "' ORDER BY ISNULL(STT, 999)"

        Dim dtRoot As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlText).Tables(0)

        If dtRoot.Rows.Count <= 0 Then
            Return
        End If

        For Each drRoot As DataRow In dtRoot.Rows
            Dim sMaBP As String = drRoot("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drRoot("MS_BO_PHAN").ToString() + " - " + drRoot("TEN_BO_PHAN").ToString()
            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)
            Call ShowTreeNode(sMaBP, oChildNode)
        Next

        TVw.Nodes(0).Expand()
        TVw.Focus()

    End Sub

    Sub ShowTreeNode(ByVal sMS_BP As String, ByVal oNode As TreeNode)
        If sMS_BP.Trim().Length <= 0 Then
            Return
        End If

        Dim SqlTextNode As String = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA=N'" & sMS_BP & "' AND MS_MAY = N'" & _sMS_MAY & "' ORDER BY ISNULL(STT, 999)"

        Dim dtNode As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlTextNode).Tables(0)
        If dtNode.Rows.Count <= 0 Then
            Return
        End If

        For Each drNode As DataRow In dtNode.Rows
            Dim sMaBP As String = drNode("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drNode("MS_BO_PHAN").ToString() + " - " + drNode("TEN_BO_PHAN").ToString()

            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)

            Call ShowTreeNode(sMaBP, oChildNode)
        Next
        'RefeshLanguage2()
    End Sub

    Private Sub tvw_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TVw.AfterSelect
        ShowCongviecBoPhan(CboLoaiCongViec.SelectedValue)
    End Sub

    Sub ShowCongviecBoPhan(ByVal intLoaiCV As Integer)
        Dim dtTable As New DataTable
        Dim a As String
        Try
            a = TVw.SelectedNode.Name
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            grdChonCongViec.Columns.Clear()
        Catch ex As Exception

        End Try
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_CHON_CV_KHTT", _sMS_MAY, TVw.SelectedNode.Name, intLoaiCV, Commons.Modules.UserName))

        Me.grdChonCongViec.DataSource = dtTable
        Dim column As New DataGridViewCheckBoxColumn

        With column
            .Name = "chkChon"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With
        grdChonCongViec.Columns.Insert(4, column)


        Try
            Dim _vtbChecked As New DataTable
            _vtbChecked.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select * from CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName & " where chon = CONVERT(bit,1) and ms_bo_phan = '" & TVw.SelectedNode.Name & "'"))
            For _c As Integer = 0 To _vtbChecked.Rows.Count - 1
                For _r As Integer = 0 To grdChonCongViec.Rows.Count - 1
                    If grdChonCongViec.Rows(_r).Cells("MS_CV").Value.ToString = _vtbChecked.Rows(_c)("MS_CV").ToString Then
                        grdChonCongViec.Rows(_r).Cells("chkChon").Value = True
                    End If
                Next
            Next

        Catch ex As Exception
        End Try

        Try
            grdChonCongViec.Columns("MS_MAY").Visible = False
            grdChonCongViec.Columns("ACTIVE").Visible = False
            grdChonCongViec.Columns("GHI_CHU").Visible = False
            grdChonCongViec.Columns("MS_BO_PHAN").Visible = False
            grdChonCongViec.Columns("TEN_BO_PHAN").Visible = False
            grdChonCongViec.Columns("MS_CV").Visible = False
            Me.grdChonCongViec.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdChonCongViec.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            'Me.grdChonCongViec.Columns("MO_TA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MO_TA_CV", commons.Modules.TypeLanguage)
            'grdChonCongViec.Columns("TG_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TG_KH", commons.Modules.TypeLanguage)
            grdChonCongViec.Rows(0).Cells("MO_TA_CV").Selected = True
            grdChonCongViec.Columns("MO_TA_CV").Width = 325
        Catch ex As Exception

        End Try
        RefeshLanguage()
    End Sub

    Private Sub grdChonCongViec_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdChonCongViec.CellEndEdit
        If e.ColumnIndex = 4 Then
            If Me.grdChonCongViec.Rows(e.RowIndex).Cells("chkChon").Value = True Then
                Commons.Modules.SQLString = "UPDATE CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName & " SET CHON=1 WHERE MS_MAY=N'" & _sMS_MAY & "' AND MS_BO_PHAN='" & grdChonCongViec.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_CV=" & grdChonCongViec.Rows(e.RowIndex).Cells("MS_CV").Value
            Else
                Commons.Modules.SQLString = "UPDATE CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName & " SET CHON=0 WHERE MS_MAY=N'" & _sMS_MAY & "' AND MS_BO_PHAN='" & grdChonCongViec.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_CV=" & grdChonCongViec.Rows(e.RowIndex).Cells("MS_CV").Value
            End If
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        End If
    End Sub
#End Region

    Private arrMaNode As New List(Of String)
    Private arrTenNode As New List(Of String)

    Private Sub txtGiatri_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGiatri.KeyDown
        If txtGiatri.Text = "" Then Exit Sub
        If IsDBNull(txtGiatri.Text) Then Exit Sub
        'test
        Static t As Integer
        Dim oNode As TreeNode()
        Static Dim strOldTenNode As String

        If e.KeyValue = 13 Then
            Dim ie As IEnumerator = TVw.Nodes.GetEnumerator
            If Trim(strOldTenNode) <> "" And Trim(strOldTenNode) = Trim(txtGiatri.Text) Then
                t += 1
                If arrTenNode.Count <= 0 Then Exit Sub
                If t >= arrTenNode.Count Then
                    If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT32", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        t = 0
                    Else
                        Exit Sub
                    End If

                End If

                oNode = TVw.Nodes.Find(arrTenNode(t), True)
                If oNode.Length > 0 Then TVw.SelectedNode = oNode(0)
            Else
                If ie.MoveNext Then
                    t = 0
                    arrTenNode.Clear()
                    strOldTenNode = txtGiatri.Text
                    parseTenNode(ie.Current)
                    If arrTenNode.Count <= 0 Then

                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT33", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        strOldTenNode = ""
                        Exit Sub
                    End If

                    oNode = TVw.Nodes.Find(arrTenNode(0), True)
                    If oNode.Length > 0 Then TVw.SelectedNode = oNode(0)
                End If
            End If
        End If
    End Sub
    Sub parseTenNode(ByVal tn As TreeNode)

        Dim ie As IEnumerator = tn.Nodes.GetEnumerator
        Dim parentnode As String = ""

        parentnode = tn.Text
        While ie.MoveNext()
            Dim ctn As TreeNode = ie.Current
            If ctn.GetNodeCount(True) = 0 Then
                If LCase(ctn.Text).Contains(LCase(Me.txtGiatri.Text)) Then
                    arrTenNode.Add(ctn.Name)
                End If
            Else
                If LCase(ctn.Text).Contains(LCase(Me.txtGiatri.Text)) Then
                    arrTenNode.Add(ctn.Name)
                End If
                If (ctn.GetNodeCount(True) > 0) Then
                    parseTenNode(ctn)
                End If
            End If
        End While
    End Sub

    Private Sub BtnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIn.Click
        printClickNode()
    End Sub

    Private Sub CreateMenuCV(ByVal grd As DataGridView)
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkCongViec", Commons.Modules.TypeLanguage)
        Dim mnuCongViec As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuCongViec.Name = "mnuCongViec"


        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuCongViec})



        BarManager.EndUpdate()
    End Sub

    Private Sub btnThemCV_Click(sender As Object, e As EventArgs) Handles btnThemCV.Click
        Try

            If TVw.SelectedNode.Text.Contains(MS_MAY) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "MsgQuyenKT26", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim frmChonCVChoBP As New FrmChonCongViecBoPhan()
            frmChonCVChoBP.SO_DONG = grdChonCongViec.RowCount
            frmChonCVChoBP.MS_BO_PHAN = TVw.SelectedNode.Name.Trim
            frmChonCVChoBP.MS_LOAI_MAY = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "select MS_LOAI_MAY from NHOM_MAY WHERE MS_NHOM_MAY = (SELECT MS_NHOM_MAY FROM MAY WHERE MS_MAY = N'" & MS_MAY & "')")
            frmChonCVChoBP.MS_MAY = MS_MAY
            frmChonCVChoBP.formName = "PhieuBaoTri"
            frmChonCVChoBP.dtTableTam = New DataTable()
            frmChonCVChoBP.ShowDialog()

            frmChonCVChoBP.dtTableTam.DefaultView.RowFilter = "CHON = TRUE"
            frmChonCVChoBP.dtTableTam = frmChonCVChoBP.dtTableTam.DefaultView.ToTable()

            Dim sSql As String = ""
            Dim dtTmp As DataTable = CType(grdChonCongViec.DataSource, DataTable)
            If (frmChonCVChoBP.dtTableTam.Rows.Count > 0) Then
                For Each row As DataRow In frmChonCVChoBP.dtTableTam.Rows
                    Try
                        Dim dr = dtTmp.NewRow()
                        dr("MS_MAY") = MS_MAY
                        dr("MS_CV") = row("MS_CV")
                        dr("MS_BO_PHAN") = TVw.SelectedNode.Name.Trim
                        dr("MO_TA_CV") = row("MO_TA_CV")
                        dr("ACTIVE") = 1
                        dr("TEN_BO_PHAN") = TVw.SelectedNode.Text
                        dr("TG_KH") = row("THOI_GIAN_DU_KIEN")
                        dr("GHI_CHU") = ""
                        dtTmp.Rows.Add(dr)
                        dtTmp.AcceptChanges()
                        Try
                            sSql = " INSERT INTO CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName & "(CHON, [MS_MAY], [MS_BO_PHAN], [MS_CV], [GHI_CHU], [ACTIVE], TG_KH, MO_TA_CV, TEN_BO_PHAN) " &
                             " VALUES (0, N'" & MS_MAY & "', N'" & TVw.SelectedNode.Name.Trim & "'," & row("MS_CV") & ",N'', " & 1 & ", " & IIf(row("THOI_GIAN_DU_KIEN") = 0, "NULL", row("THOI_GIAN_DU_KIEN")) & ", N'" & row("MO_TA_CV") & "', N'" & TVw.SelectedNode.Text & "')"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                        Catch
                        End Try
                    Catch
                    End Try
                Next
            End If

        Catch
        End Try
    End Sub

    Private Sub LblTieuDe_Click(sender As Object, e As EventArgs) Handles LblTieuDe.Click

    End Sub

    Private Sub barManager_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim subMenu As DevExpress.XtraBars.BarSubItem = TryCast(e.Item, DevExpress.XtraBars.BarSubItem)
        Dim barMenu As DevExpress.XtraBars.BarManager = TryCast(sender, DevExpress.XtraBars.BarManager)
        If Not subMenu Is Nothing Then Return
        Dim grd As DataGridView = TryCast(Me.Controls.Find(barMenu.Form.Name, True).FirstOrDefault(), DataGridView)
        Dim dt As New DataTable()
        Try
            Select Case e.Item.Name.ToUpper
                Case "mnuCongViec".ToUpper

                    Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'mnuWork' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                    If (dt.Rows.Count = 0) Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Dim frmDanhmuccongviec As New MVControl.frmDanhmuccongviec
                    Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, frmDanhmuccongviec.Name)


                    Dim sMaSo As String
                    sMaSo = grd.SelectedRows(0).Cells("MS_CV").Value
                    frmDanhmuccongviec.MS_CVIEC = sMaSo

                    frmDanhmuccongviec.Size = New Size(900, 600)
                    frmDanhmuccongviec.ShowDialog()

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdChonCongViec_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grdChonCongViec.CellMouseDown
        If e.RowIndex = -1 Then Exit Sub
        If e.ColumnIndex = -1 Then Exit Sub
        If e.Button <> MouseButtons.Right Then Exit Sub

        grdChonCongViec.ClearSelection()
        grdChonCongViec.Rows(e.RowIndex).Selected = True
    End Sub


End Class