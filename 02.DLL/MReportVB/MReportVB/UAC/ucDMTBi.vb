
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class ucDMTBi
    Public dtTBi As New DataTable
    Public dtTuNgay, dtDenNgay As DateTime
    Public MsLoaiMay, MsNhomMay As String

    Sub ShowMAY()
        If dtTBi.Rows.Count <= 0 Then Exit Sub

        Try
            txtMS_MAY.Text = dtTBi.Rows(0)("MS_MAY").ToString()
            txtTEN_MAY.Text = dtTBi.Rows(0)("TEN_MAY").ToString()
            cboMS_LOAI_MAY.Text = dtTBi.Rows(0)("TEN_LOAI_MAY").ToString()
            cboMS_NHOM_MAY.Text = dtTBi.Rows(0)("TEN_NHOM_MAY").ToString()
            If String.IsNullOrEmpty(dtTBi.Rows(0)("TEN_HSX").ToString()) Then CboMS_HSX.EditValue = -99 Else CboMS_HSX.Text = dtTBi.Rows(0)("TEN_HSX").ToString()

            cboMS_HIEN_TRANG.EditValue = dtTBi.Rows(0)("MS_HIEN_TRANG")

            If String.IsNullOrEmpty(dtTBi.Rows(0)("TEN_CONG_TY").ToString()) Then cboMS_NCC.EditValue = "-99" Else cboMS_NCC.Text = dtTBi.Rows(0)("TEN_CONG_TY").ToString()

            txtSO_NAM_KHAU_HAO.Text = dtTBi.Rows(0)("SO_NAM_KHAU_HAO").ToString()
            txtMO_TA.Text = dtTBi.Rows(0)("MO_TA").ToString()
            txtNHIEM_VU_THIET_BI.Text = dtTBi.Rows(0)("NHIEM_VU_THIET_BI").ToString()
            txtMODEL.Text = dtTBi.Rows(0)("MODEL").ToString()
            txtSERIAL_NUMBER.Text = dtTBi.Rows(0)("SERIAL_NUMBER").ToString()

            If dtTBi.Rows(0)("NGAY_SX").ToString() <> "" Then txtNGAY_SX.DateTime = Convert.ToDateTime(dtTBi.Rows(0)("NGAY_SX").ToString()) Else txtNGAY_SX.Text = ""


            txtNUOC_SX.Text = dtTBi.Rows(0)("NUOC_SX").ToString()

            If dtTBi.Rows(0)("NGAY_BD_BAO_HANH").ToString() <> "" Then txtNGAY_BD_BAO_HANH.DateTime = Convert.ToDateTime(dtTBi.Rows(0)("NGAY_BD_BAO_HANH").ToString()) Else txtNGAY_BD_BAO_HANH.Text = ""

            If dtTBi.Rows(0)("NGAY_DUA_VAO_SD").ToString() <> "" Then txtNGAY_DUA_VAO_SD.DateTime = Convert.ToDateTime(dtTBi.Rows(0)("NGAY_DUA_VAO_SD").ToString()) Else txtNGAY_DUA_VAO_SD.Text = ""


            txtSO_THE.Text = dtTBi.Rows(0)("SO_THE").ToString()
            txtSoCT.Text = dtTBi.Rows(0)("SO_CT").ToString()
            txtSO_NGAY_LV_TRONG_TUAN.Text = dtTBi.Rows(0)("SO_NGAY_LV_TRONG_TUAN").ToString()
            txtSO_GIO_LV_TRONG_NGAY.Text = dtTBi.Rows(0)("SO_GIO_LV_TRONG_NGAY").ToString()
            'Row("MS_DVT_RT") = "-99"
            'Row("TEN_DVT_RT") = ""
            If dtTBi.Rows(0)("TEN_DVT_RT").ToString() = "" Then
                cboMS_DVT_RT.EditValue = -99
            Else
                cboMS_DVT_RT.Text = dtTBi.Rows(0)("TEN_DVT_RT").ToString()

            End If

            Try
                txtDinhMucSL.Text = dtTBi.Rows(0)("DINH_MUC_SL").ToString()
                cmbDVTSL.Text = dtTBi.Rows(0)("DVT_SL").ToString()
                cmbDVTG.EditValue = Convert.ToInt32(dtTBi.Rows(0)("DON_VI_THOI_GIAN").ToString())

            Catch
                cmbDVTG.EditValue = 0

            End Try

            txtTY_LE_CON_LAI.Text = dtTBi.Rows(0)("TY_LE_CON_LAI").ToString()
            cboMUC_UU_TIEN.Text = dtTBi.Rows(0)("TEN_UU_TIEN").ToString()
            txtSO_THANG_BH.Text = dtTBi.Rows(0)("SO_THANG_BH").ToString()
            txtGIA_MUA.Text = dtTBi.Rows(0)("GIA_MUA").ToString()
            txtTiGiaVND.Text = dtTBi.Rows(0)("TI_GIA_VND").ToString()
            If String.IsNullOrEmpty(dtTBi.Rows(0)("TI_GIA_USD").ToString()) = False Then
                txtTiGiaUSD.Text = CType(dtTBi.Rows(0)("TI_GIA_USD").ToString(), Double).ToString("###,##0.######")
            Else
                txtTiGiaUSD.Text = String.Empty
            End If
            cboNGOAI_TE.Text = IIf(IsDBNull(dtTBi.Rows(0)("NGOAI_TE").ToString()), "", dtTBi.Rows(0)("NGOAI_TE").ToString())
            txtChukyHC.Text = dtTBi.Rows(0)("CHU_KY_HC_TB").ToString()


            txtCKHCTB_Ngoai.Text = dtTBi.Rows(0)("CHU_KY_HIEU_CHUAN_TB_NGOAI").ToString()
            txtCKKDTB.Text = dtTBi.Rows(0)("CHU_KY_KD_TB").ToString()
            If chkHienthihinhTB.Checked Then
                PtcAnhTB.ImageLocation = dtTBi.Rows(0)("Anh_TB").ToString()
            Else
                PtcAnhTB.ImageLocation = ""
            End If
            InitMayHeThongBPCPNhaXuongTmp(txtMS_MAY.Text)
            Try
                If dtTBi.Rows(0)("NGAY_DUA_VAO_SD").ToString() <> "" Then
                    dtTuNgay = DateTime.Parse(dtTBi.Rows(0)("NGAY_DUA_VAO_SD").ToString())
                    dtDenNgay = DateTime.Parse(dtTBi.Rows(0)("NGAY_DUA_VAO_SD").ToString())
                End If
            Catch ex As Exception

            End Try
            Try
                MsLoaiMay = cboMS_LOAI_MAY.EditValue.ToString
            Catch ex As Exception

            End Try
            Try
                MsNhomMay = cboMS_NHOM_MAY.EditValue.ToString
            Catch ex As Exception

            End Try


            If String.IsNullOrEmpty(dtTBi.Rows(0)("USER_INSERT").ToString()) Then _
                    txtUInsert.Text = "" Else txtUInsert.Text = dtTBi.Rows(0)("USER_INSERT").ToString()
            If String.IsNullOrEmpty(dtTBi.Rows(0)("NGAY_INSERT").ToString()) Then _
                    txtNInsert.Text = "" Else txtNInsert.Text = dtTBi.Rows(0)("NGAY_INSERT").ToString()


            If String.IsNullOrEmpty(dtTBi.Rows(0)("USER_UPDATE").ToString()) Then _
                    txtUUpdate.Text = "" Else txtUUpdate.Text = dtTBi.Rows(0)("USER_UPDATE").ToString()
            If String.IsNullOrEmpty(dtTBi.Rows(0)("NGAY_UPDATE").ToString()) Then _
                    txtNUpdate.Text = "" Else txtNUpdate.Text = dtTBi.Rows(0)("NGAY_UPDATE").ToString()


            If dtTBi.Rows(0)("NGAY_MUA").ToString() <> "" Then txtNGAY_MUA.DateTime = Convert.ToDateTime(dtTBi.Rows(0)("NGAY_MUA").ToString()) Else txtNGAY_MUA.Text = ""


        Catch ex As Exception

        End Try
    End Sub


    Sub InitMayHeThongBPCPNhaXuongTmp(ByVal MS_MAY As String)
        Dim dtReader As SqlDataReader
        Dim sSql As String = ""
        TxtMS_HE_THONG.Text = ""
        sSql = "SELECT TEN_HE_THONG FROM HE_THONG INNER JOIN MAY_HE_THONG ON " &
                "HE_THONG.MS_HE_THONG = MAY_HE_THONG.MS_HE_THONG WHERE MS_MAY=N'" & MS_MAY & "' AND " &
                "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_HE_THONG WHERE MS_MAY=N'" & MS_MAY & "')"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        While dtReader.Read
            TxtMS_HE_THONG.Text = dtReader.Item("TEN_HE_THONG")
        End While

        dtReader.Close()
        sSql = "SELECT TEN_N_XUONG + CASE WHEN GHI_CHU IS NULL OR GHI_CHU = '' THEN '' ELSE '(' + GHI_CHU + ')' END AS TEN_N_XUONG,NHA_XUONG.MS_N_XUONG FROM NHA_XUONG INNER JOIN MAY_NHA_XUONG ON " &
                "NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG.MS_N_XUONG WHERE MS_MAY=N'" & MS_MAY & "' AND " &
                "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_NHA_XUONG WHERE MS_MAY=N'" & MS_MAY & "')"

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        TxtMS_NHA_XUONG.Text = ""
        While dtReader.Read
            TxtMS_NHA_XUONG.Text = dtReader.Item("TEN_N_XUONG")
        End While
        dtReader.Close()
        sSql = "SELECT TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI INNER JOIN MAY_BO_PHAN_CHIU_PHI ON " &
                        "BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI = MAY_BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI WHERE MS_MAY=N'" & MS_MAY & "' AND " &
                        "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY=N'" & MS_MAY & "')"

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        While dtReader.Read
            TxtMS_BP_CHIU_PHI.Text = dtReader.Item("TEN_BP_CHIU_PHI")
        End While
        dtReader.Close()
    End Sub


End Class
