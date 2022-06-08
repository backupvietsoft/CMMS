Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient

Public Class frmrptChuKyHieuChuanKeTiep

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptChuKyHieuChuanKeTiep", cboLoaithietbi3.SelectedValue, cboNhomthietbi3.SelectedValue, cboThietbi3.SelectedValue)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "Select COUNT(*) AS Tong FROM rptChuKyHieuChuanKeTiep")
        While objReader.Read
            If objReader.Item("Tong") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()
        CreaterptChuKyHieuChuanKeTiep()
        ReportPreview("reports\rptChuKyHieuChuanKeTiep.rpt")
    End Sub

    Private Sub frmrptChuKyHieuChuanKeTiep_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadcboDiaDiem()
        Bind_cboLoaithietbi3()
        Bind_cboNhomthietbi3()
        Bind_cbothietbi3()
    End Sub
    Sub LoadcboDiaDiem()
        cboDiaDiem.Value = "MS_N_XUONG"
        cboDiaDiem.Display = "TEN_N_XUONG"
        cboDiaDiem.Param = Commons.Modules.UserName
        cboDiaDiem.StoreName = "PermisionNHA_XUONG"
        cboDiaDiem.BindDataSource()
    End Sub
    Private Sub cboLoaithietbi3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaithietbi3.SelectedIndexChanged
        Bind_cboNhomthietbi3()
        Bind_cbothietbi3()
    End Sub

    Private Sub cboNhomthietbi3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNhomthietbi3.SelectedIndexChanged
        Bind_cbothietbi3()
    End Sub
    Sub Bind_cboLoaithietbi3()
        Dim str As String = ""
        If cboDiaDiem.Text = "" Then
            Exit Sub
        End If
        str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " & _
        " FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE MS_N_XUONG='" & cboDiaDiem.SelectedValue & "' AND USERNAME='" & Commons.Modules.UserName & "'"
        cboLoaithietbi3.Display = "TEN_LOAI_MAY"
        cboLoaithietbi3.Value = "MS_LOAI_MAY"
        cboLoaithietbi3.Param = str
        cboLoaithietbi3.StoreName = "QL_SEARCH"
        cboLoaithietbi3.BindDataSource()
        If cboLoaithietbi3.Items.Count = 0 Then
            cboLoaithietbi3.Text = ""
        End If
    End Sub

    Sub Bind_cboNhomthietbi3()
        If cboLoaithietbi3.SelectedIndex = -1 Then
            cboNhomthietbi3.Text = ""
            Exit Sub
        End If
        cboNhomthietbi3.Display = "TEN_NHOM_MAY"
        cboNhomthietbi3.Value = "MS_NHOM_MAY"
        'cboNhomthietbi3.Param = cboLoaithietbi3.SelectedValue
        If cboLoaithietbi3.SelectedValue.ToString = "-1" Then
            cboNhomthietbi3.Param = "SELECT NHOM_MAY.* FROM NHOM_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        Else
            cboNhomthietbi3.Param = "SELECT NHOM_MAY.* FROM NHOM_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID WHERE NHOM_LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "' AND (USERS.USERNAME = '" & Commons.Modules.UserName & "')"
        End If
        'cboNhomthietbi.StoreName = "Get_rptNhomThietBi"
        cboNhomthietbi3.StoreName = "QL_SEARCH"
        cboNhomthietbi3.BindDataSource()
        If cboNhomthietbi3.Items.Count = 0 Then
            cboNhomthietbi3.Text = ""
        End If
    End Sub

    Sub Bind_cbothietbi3()
        If cboNhomthietbi3.SelectedIndex = -1 Then
            cboThietbi3.Text = ""
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT DISTINCT MAY.MS_MAY, MAY.MS_MAY AS MAY FROM MAY INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN " & _
        " USERS ON NHOM.GROUP_ID = USERS.GROUP_ID where USERNAME='" & Commons.Modules.UserName & "' AND MS_N_XUONG='" & cboDiaDiem.SelectedValue & "'"
        If cboLoaithietbi3.SelectedValue <> "-1" Then
            str = str + " and LOAI_MAY.MS_LOAI_MAY='" & cboLoaithietbi3.SelectedValue & "'"
        End If
        If cboNhomthietbi3.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomthietbi3.SelectedValue & "'"
        End If
        cboThietbi3.Display = "MAY"
        cboThietbi3.Value = "MS_MAY"
        cboThietbi3.Param = str
        cboThietbi3.StoreName = "QL_SEARCH"
        cboThietbi3.BindDataSource()
        If cboThietbi3.Items.Count = 0 Then
            cboThietbi3.Text = ""
        End If
    End Sub

    Sub CreaterptChuKyHieuChuanKeTiep()
        Dim str As String = ""
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table rptTieuDeSubChuKyHC")
        Catch ex As Exception
        End Try
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table rptTieuDeChuKyHC")
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "TieuDe", commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "TrangIn", commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "NgayIn", commons.Modules.TypeLanguage)
        Dim LoaiMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "LoaiMay", commons.Modules.TypeLanguage)
        Dim NhomMay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "NhomMay", commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "ThietBi", commons.Modules.TypeLanguage)
        Dim ChuKyHC As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "ChuKyHC", commons.Modules.TypeLanguage)
        Dim NgayHCKT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "NgayHCKT", commons.Modules.TypeLanguage)
        Dim NgayHCCuoi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "NgayHCCuoi", commons.Modules.TypeLanguage)
        Dim TenViTri As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "TenViTri", commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeChuKyHC(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255),LoaiMay nvarchar(50)," & _
        "NhomMay nvarchar(50),ThietBi nvarchar(50),ChuKyHC nvarchar(50),NgayHCKT nvarchar(50)) Insert into [DBO].rptTieuDeChuKyHC values(" & commons.Modules.TypeLanguage & ",N'" & _
        NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & LoaiMay & "',N'" & NhomMay & "',N'" & ThietBi & "',N'" & ChuKyHC & "',N'" & NgayHCKT & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "TenPT", commons.Modules.TypeLanguage)
        Dim ViTri As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "ViTri", commons.Modules.TypeLanguage)
        Dim Noi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "Noi", commons.Modules.TypeLanguage)
        Dim Ngoai As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptChuKyHieuChuanKeTiep", "Ngoai", commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeSubChuKyHC(TenPT nvarchar(50),ViTri nvarchar(50),ChuKyHieuChuan nvarchar(50),Noi nvarchar(60),Ngoai nvarchar(60),NgayHCKT nvarchar(100),NgayHCCuoi nvarchar(50),TenViTri nvarchar(50))" & _
        " Insert into [DBO].rptTieuDeSubChuKyHC values(N'" & TenPT & "',N'" & ViTri & "',N'" & ChuKyHC & "',N'" & Noi & "',N'" & Ngoai & "',N'" & NgayHCKT & "',N'" & NgayHCCuoi & "',N'" & TenViTri & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub cboDiaDiem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDiaDiem.SelectedIndexChanged
        Bind_cboLoaithietbi3()
        Bind_cboNhomthietbi3()
        Bind_cbothietbi3()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
