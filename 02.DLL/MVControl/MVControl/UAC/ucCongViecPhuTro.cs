using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;


namespace MVControl
{
    public partial class ucCongViecPhuTro : DevExpress.XtraEditors.XtraUserControl
    {

        public int iTTPBTri { get; set; }
        public string sMsPBT { get; set; }
        public ucCongViecPhuTro()
        {
            InitializeComponent();

        }
        public void LoadPBTCVPhuTro(int iSTT)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CV_PHU_TROs", sMsPBT));

                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["STT"] };

                dtTmp.Columns["STT_CV"].AllowDBNull = true;
                dtTmp.Columns["STT_CV"].ReadOnly = false;
                dtTmp.Columns["STT"].ReadOnly = false;

                if (grdCViec.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdCViec, grvCViec, dtTmp, false, true, true, true, true, "FrmPhieuBaoTri_New");
                    grvCViec.Columns["SO_GIO_KH"].Width = 20;
                    grvCViec.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
                    grvCViec.Columns["STT"].Visible = false;
                    grvCViec.Columns["NGAY_HOAN_THANH"].Visible = false;
                    grvCViec.Columns["NGAY_BDCV"].Visible = false;
                    grvCViec.Columns["NGAY_KTCV"].Visible = false;
                    grvCViec.Columns["STT_CV"].Visible = false;
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdCViec, grvCViec, dtTmp, false, false, true, false, true, "FrmPhieuBaoTri_New");
                }
                LoadSoGioSoPhut();

                if (iSTT != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(iSTT));
                    grvCViec.FocusedRowHandle = grvCViec.GetRowHandle(index);
                }
                if (dtTmp.Rows.Count == 0)
                {
                    LoadPBTCVPhuTroVatTu(-1, "-1");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Commons.Modules.SQLString != "0Load") LoadPBTCVPhuTroVatTu(-1, "-1");
        }
        private void LoadPBTCVPhuTroVatTu(int iSTT, string sMsPT)
        {
            try
            {
                if (grdCViec.DataSource == null) return;
                if (Commons.Modules.SQLString == "0Load") return;
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG", sMsPBT, Commons.Modules.TypeLanguage));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["MS_PT_STT"] };
                if (grdVTu.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdVTu, grvVTu, dtTmp, false, true, true, true, true, "FrmPhieuBaoTri_New");
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdVTu, grvVTu, dtTmp, false, false, true, false, true, "FrmPhieuBaoTri_New");
                }
                grvVTu.Columns["STT"].Visible = false;
                grvVTu.Columns["MS_PT_STT"].Visible = false;
                grvVTu.Columns["MS_PT"].OptionsColumn.ReadOnly = true;
                grvVTu.Columns["TEN_PT"].OptionsColumn.ReadOnly = true;
                grvVTu.Columns["QUY_CACH"].OptionsColumn.ReadOnly = true;
                grvVTu.Columns["SL_TT"].OptionsColumn.ReadOnly = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grvCViec_FocusedRowChanged(null, null);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        private void grvCViec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grdVTu.DataSource == null) return;
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = new DataTable();
                dtTmp = (DataTable)grdVTu.DataSource;
                dtTmp.DefaultView.RowFilter = " STT = " + grvCViec.GetFocusedRowCellValue("STT").ToString();
                dtTmp = dtTmp.DefaultView.ToTable();
            }
            catch { dtTmp.DefaultView.RowFilter = " STT = -1"; }
        }
        public void bThemSua(Boolean bTSua)
        {
            btnChonPT.Visible = !btnChonPT.Visible;
            btnGhi.Visible = !btnGhi.Visible;
            btnKhongghi.Visible = !btnKhongghi.Visible;

            btnThemSua.Visible = !btnThemSua.Visible;
            btnXoa.Visible = !btnXoa.Visible;
            btnThoat.Visible = !btnThoat.Visible;

            if (bTSua)
            {
                grvCViec.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                grvCViec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                grvCViec.OptionsBehavior.Editable = true;

                grvVTu.OptionsBehavior.Editable = true;

            }
            else
            {
                grvCViec.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                grvCViec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                grvCViec.OptionsBehavior.Editable = false;

                grvVTu.OptionsBehavior.Editable = false;
            }
        }

        public Boolean KiemHoanThanh()
        {
            try
            {
                if (iTTPBTri == 3)
                {
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmPhieuBaoTri_New", "DaHoanThanhMuonChinhSua", Commons.Modules.TypeLanguage), "Vietsoft Ecomaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Commons.clsPHIEU_BAO_TRIController objPBT = new Commons.clsPHIEU_BAO_TRIController();
                        objPBT.UpdatePHIEU_BAO_TRI_TINH_TRANGs(sMsPBT, 2);

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void HoanThanhNgiemThu(Boolean bAnHien)
        {
            btnThemSua.Enabled = bAnHien;
            btnXoa.Enabled = bAnHien;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {

            DataTable dtCV = new DataTable();
            DataTable dtVT = new DataTable();
            DataTable dtTmp = new DataTable();
            string sBTCV = "BT_CV_TMP" + Commons.Modules.UserName;
            string sBTVT = "BT_CVPT_TMP" + Commons.Modules.UserName;

            #region Luu du lieu
            int iSTYLuu = -1;
            try
            {
                iSTYLuu = int.Parse(grvCViec.GetFocusedRowCellValue("STT").ToString());
            }
            catch { }

            string sMSPTLuu = "-1";
            try
            {
                sMSPTLuu = grvVTu.GetFocusedRowCellValue("MS_PT").ToString();
            }
            catch { }
            #endregion

            try
            {


                #region Kiem du lieu Ghi
                dtCV = (DataTable)grdCViec.DataSource;
                dtTmp = dtCV.Copy();
                dtTmp.DefaultView.RowFilter = " ISNULL(TEN_CONG_VIEC,'') = '' ";
                if ((dtTmp.DefaultView.ToTable()).Rows.Count > 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapCongViec", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //dtTmp = new DataTable();
                //dtTmp = dtCV.Copy();
                //dtTmp.DefaultView.RowFilter = " ISNULL(SO_GIO_KH,0) = 0";
                //if ((dtTmp.DefaultView.ToTable()).Rows.Count > 0)
                //{
                //    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapSoPhut", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                #endregion

                #region Tao Du Lieu Ghi
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTCV, dtCV, "");

                dtVT = (DataTable)grdVTu.DataSource;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTVT, dtVT, "");
                #endregion

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "InsertCongViecPhuTro", sMsPBT, sBTCV, sBTVT);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Commons.Modules.ObjSystems.XoaTable(sBTCV);
                Commons.Modules.ObjSystems.XoaTable(sBTVT);
            }
            bThemSua(false);
            Commons.Modules.SQLString = "0Load";
            LoadPBTCVPhuTro(iSTYLuu);
            Commons.Modules.SQLString = "";
            LoadPBTCVPhuTroVatTu(iSTYLuu, sMSPTLuu + iSTYLuu.ToString());
            Commons.Modules.ObjSystems.XoaTable(sBTCV);
            Commons.Modules.ObjSystems.XoaTable(sBTVT);
        }
        private void btnKhongghi_Click(object sender, EventArgs e)
        {
            bThemSua(false);
            int iSTYLuu = -1;
            try
            {
                iSTYLuu = int.Parse(grvCViec.GetFocusedRowCellValue("STT").ToString());
            }
            catch { }
            Commons.Modules.SQLString = "0Load";
            LoadPBTCVPhuTro(iSTYLuu);
            Commons.Modules.SQLString = "";
            LoadPBTCVPhuTroVatTu(iSTYLuu, "-1");
        }
        private void btnChonPT_Click(object sender, EventArgs e)
        {

            try
            {
                if (String.IsNullOrEmpty(grvCViec.GetFocusedRowCellValue("STT").ToString()) || String.IsNullOrEmpty(grvCViec.GetFocusedRowCellValue("MS_PHIEU_BAO_TRI").ToString()))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapCongViec", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapCongViec", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (((DataTable)grdVTu.DataSource).DefaultView.ToTable()).Copy();
                String sBT = "CVPTVTPT_CHON" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");


                frmChonVTPT frm = new frmChonVTPT();
                frm.iLoaiChon = 0;
                frm.dtChon = new DataTable();
                frm.dtChon.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetVTPTChon", Commons.Modules.UserName, sBT, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.XoaTable(sBT);

                if (frm.ShowDialog() == DialogResult.Cancel) return;

                frm.dtChon.DefaultView.RowFilter = "CHON = TRUE";
                dtTmp = frm.dtChon.DefaultView.ToTable();
                DataRow drVTu;
                DataTable dtVatTu = new DataTable();
                dtVatTu = (DataTable)grdVTu.DataSource;
                foreach (DataRow drRow in dtTmp.Rows)
                {
                    drVTu = dtVatTu.NewRow();
                    drVTu["MS_PT"] = drRow["MS_PT"].ToString();
                    drVTu["TEN_PT"] = drRow["TEN_PT"].ToString();
                    drVTu["QUY_CACH"] = drRow["QUY_CACH"].ToString();
                    drVTu["SL_KH"] = 1;
                    drVTu["SL_TT"] = 0;
                    drVTu["STT"] = grvCViec.GetFocusedRowCellValue("STT").ToString();
                    drVTu["MS_PT_STT"] = drRow["MS_PT"].ToString() + grvCViec.GetFocusedRowCellValue("STT").ToString();

                    dtVatTu.Rows.Add(drVTu);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Commons.Modules.ObjSystems.XoaTable("CVPTVTPT_CHON" + Commons.Modules.UserName);
            }
        }

        private void grvCViec_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                if (!btnGhi.Visible) return;
                if (String.IsNullOrEmpty(grvCViec.GetFocusedRowCellValue("STT").ToString())) grvCViec.SetFocusedRowCellValue("STT", grvCViec.RowCount + 1);
                if (String.IsNullOrEmpty(grvCViec.GetFocusedRowCellValue("STT_CV").ToString())) grvCViec.SetFocusedRowCellValue("STT_CV", -1);
                if (String.IsNullOrEmpty(grvCViec.GetFocusedRowCellValue("MS_PHIEU_BAO_TRI").ToString())) grvCViec.SetFocusedRowCellValue("MS_PHIEU_BAO_TRI", sMsPBT);
            }
            catch {}
        }


        private void grvCViec_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {


                if (!btnGhi.Visible) return;
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                DevExpress.XtraGrid.Columns.GridColumn sTenCViec = view.Columns["TEN_CONG_VIEC"];
                DevExpress.XtraGrid.Columns.GridColumn fSoLuong = view.Columns["SO_GIO_KH"];
                grvCViec.Columns.View.ClearColumnErrors();

                if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, sTenCViec).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(sTenCViec, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTenCongViecKhongDuocTrong", Commons.Modules.TypeLanguage));
                    return;
                }
                else
                {
                    if (view.GetRowCellValue(e.RowHandle, sTenCViec).ToString().Length > 250)
                    {
                        e.Valid = false;
                        view.SetColumnError(sTenCViec, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTenCongViecDaiHon250KyTu", Commons.Modules.TypeLanguage));
                        return;
                    }

                }

                if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, fSoLuong).ToString()))
                {
                    try
                    {
                        view.SetFocusedRowCellValue(fSoLuong, DBNull.Value);
                    }
                    catch { }
                }
                e.Valid = true;
                grvCViec.RefreshData();
            }
            catch {}
        }

        private void grvCViec_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapDuDuLieu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void btnXoaPT_Click(object sender, EventArgs e)
        {
            if (grvVTu.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmPhieuBaoTri_New", "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), "Vietsoft Ecomaint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmPhieuBaoTri_New",
                    "MsgChacXoaCongViecPhuTroPhuTung", Commons.Modules.TypeLanguage), "Vietsoft Ecomaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                #region Luu du lieu
                int iSTYLuu = -1;
                try
                {
                    iSTYLuu = int.Parse(grvCViec.GetFocusedRowCellValue("STT").ToString());
                }
                catch { }

                string sMSPTLuu = "-1";
                try
                {
                    sMSPTLuu = grvVTu.GetFocusedRowCellValue("MS_PT").ToString();
                }
                catch { }
                #endregion

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text,
                    "DELETE FROM PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG WHERE MS_PT = N'" + grvVTu.GetFocusedRowCellValue("MS_PT").ToString() + "' " +
                        " AND MS_PHIEU_BAO_TRI = N'" + sMsPBT + "' AND STT = " + grvCViec.GetFocusedRowCellValue("STT").ToString());

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text,
                    "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO WHERE MS_PT = N'" + grvVTu.GetFocusedRowCellValue("MS_PT").ToString() + "' " +
                        " AND MS_CV = " + grvCViec.GetFocusedRowCellValue("STT").ToString() + " AND MS_BO_PHAN = N'" + grvCViec.GetFocusedRowCellValue("STT").ToString() + "' " +
                        " AND MS_PHIEU_BAO_TRI = N'" + sMsPBT + "' AND STT = " + grvCViec.GetFocusedRowCellValue("STT").ToString());
                LoadPBTCVPhuTroVatTu(iSTYLuu, sMSPTLuu + iSTYLuu.ToString());
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message, "Vietsoft Ecomaint", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnXoaCV_Click(object sender, EventArgs e)
        {
            if (grvCViec.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmPhieuBaoTri_New", "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), "Vietsoft Ecomaint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT TOP 1  MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI = '" + sMsPBT + "' and STT = '" + grvCViec.GetFocusedRowCellValue("STT").ToString() + "'"));
            if (dtTmp.Rows.Count > 0)
            {
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmPhieuBaoTri_New",
                        "msgConTonTaiNhanSuBanMuonXoaLun", Commons.Modules.TypeLanguage), "Vietsoft Ecomaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }
            else
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT TOP 1  MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG WHERE MS_PHIEU_BAO_TRI = '" + sMsPBT + "' and STT = '" + grvCViec.GetFocusedRowCellValue("STT").ToString() + "'"));
                if (dtTmp.Rows.Count > 0)
                {
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmPhieuBaoTri_New",
                            "msgConTonTaiPhuTungBanMuonXoaHetPT", Commons.Modules.TypeLanguage), "Vietsoft Ecomaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                }
                else
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmPhieuBaoTri_New",
                            "MsgXoaCongViecPhuTro", Commons.Modules.TypeLanguage), "Vietsoft Ecomaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                try
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_CV_PHU_TRO", sMsPBT, grvCViec.GetFocusedRowCellValue("STT"));
                }
                catch (Exception ex)
                { XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            LoadPBTCVPhuTro(-1);
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            AnXoa(false);
        }
        public void AnXoa(Boolean AnHien)
        {
            btnXoa.Visible = AnHien;
            btnXoaCV.Visible = AnHien;
            btnXoaPT.Visible = AnHien;
            btnTroVe.Visible = AnHien;

            btnThemSua.Visible = !AnHien;
            btnXoa.Visible = !AnHien;
            btnThoat.Visible = !AnHien;

        }

        private void txtTimkiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (btnGhi.Visible) return;
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdCViec.DataSource;

            try
            {
                string dk = "";
                if (txtTimkiem.Text.Length != 0) dk = " TEN_CONG_VIEC LIKE '%" + txtTimkiem.Text + "%' " + dk;
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

        public void LoadFormCVPT()
        {
            if (Commons.Modules.PermisString.Equals("Read only"))
            {
                btnThemSua.Visible = false;
                btnXoa.Visible = false;
            }
            LoadSoGioSoPhut();
        }

        private void LoadSoGioSoPhut()
        {
            //iPhutGioPBT =          PHUT_GIO_PBT: Định nghĩa đơn ví tính là giờ hay phút (0 - dùng giờ, 1 dùng phút )
            try
            {
                if (Commons.Modules.iPhutGioPBT == 1)
                {
                    grvCViec.Columns["SO_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0";
                    grvCViec.Columns["SO_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    grvCViec.Columns["SO_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT", Commons.Modules.TypeLanguage);
                }
                else
                {
                    grvCViec.Columns["SO_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0.#00";
                    grvCViec.Columns["SO_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    grvCViec.Columns["SO_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO", Commons.Modules.TypeLanguage);
                }
            }
            catch { }
        }
        private void grvCViec_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(grvCViec.GetFocusedDataRow()["SO_GIO_KH"].ToString()))
                {
                    if (Commons.Modules.SQLString == "0Load") return;
                    Commons.Modules.SQLString = "0Load";
                    grvCViec.SetFocusedRowCellValue("SO_GIO_KH", DBNull.Value);
                    Commons.Modules.SQLString = "";
                }
            }
            catch { }
        }




        private void grvCViec_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                var gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;

                if (gv.FocusedColumn.FieldName.ToUpper() == "SO_GIO_KH")
                {
                    if (e.Value != DBNull.Value && Convert.ToString(e.Value) == "")
                    {
                        Commons.Modules.SQLString = "0Load";
                        e.Value = DBNull.Value;
                        Commons.Modules.SQLString = "";
                    }
                }
                
            }
            catch { }
        }
    }
}
