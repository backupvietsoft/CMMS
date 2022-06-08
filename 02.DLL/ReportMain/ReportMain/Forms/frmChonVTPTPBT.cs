using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using Commons;
using DevExpress.XtraGrid.Views.Grid;

namespace ReportMain
{
    public partial class frmChonPhuTungcho_PBT : DevExpress.XtraEditors.XtraForm
    {
        string sBTCV = "PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName;
        string sBTPTCV = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" + Commons.Modules.UserName;
        string sBTVTX = "PHU_TU_XK" + Commons.Modules.UserName;
        string sBTDMVT = "DMVT" + Commons.Modules.UserName;

        public string MS_CVBT;
        public string MS_MAY;
        public string MS_PHIEU_BAO_TRI;
        public frmChonPhuTungcho_PBT()
        {
            InitializeComponent();
        }
        #region Kiem Du Lieu
        public bool KiemPTTonTaiNAV(string sMsPT)
        {
            // Return True ton tai
            string sSql = null;
            string sINTConnect = null;
            try
            {
                if (Commons.Modules.sPrivate != "BARIA")
                    return false;

                sSql = "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG";
                sINTConnect = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
                sSql = "SELECT ISNULL(SUM(SO_LUONG),0) AS SL FROM NAV_REQUEST WHERE MS_PHIEU_BAO_TRI = '" + MS_PHIEU_BAO_TRI + "' AND MS_MAY = '" + MS_MAY + "' AND MS_PT = '" + sMsPT + "' ";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(sINTConnect, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    if (double.Parse(dtTmp.Rows[0][0].ToString()) > 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDaChuyenDuLieuKhongTheXoa", Commons.Modules.TypeLanguage));
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }
        public bool KiemPTDaChon(int iLuoi, string sMsPT)
        {

            DataTable dtTmp = new DataTable();
            DataTable dtLuoi = new DataTable();

            string dk = "";
            dk = " (MS_BO_PHAN = '" + grdDanhsachcongviec.GetFocusedRowCellValue("MS_BO_PHAN").ToString() + "') " +
                        " AND (MS_CV = " + grdDanhsachcongviec.GetFocusedRowCellValue("MS_CV").ToString() + " ) AND (MS_PT = '" + sMsPT +"') ";
            //luoi phu tung 
            if (iLuoi != 1)
            {
                
                dtLuoi = (DataTable)grdDSPTCon.DataSource;
                dtTmp = dtLuoi.Copy();
                try
                {
                    dtTmp.DefaultView.RowFilter = dk + " AND ( CHON = 1)";
                }
                catch { dtTmp.DefaultView.RowFilter = ""; }
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "VatTuDaDuocChon", Commons.Modules.TypeLanguage));
                    return true;
                }

            }
            //luoi vat tu
            if (iLuoi != 2)
            {
                dtTmp = new DataTable();
                dtLuoi = new DataTable();
                dtLuoi = (DataTable)grdVTPT.DataSource;
                dtTmp = dtLuoi.Copy();
                try
                {
                    dtTmp.DefaultView.RowFilter = dk + " AND ( CHON = 1)";
                }
                catch { dtTmp.DefaultView.RowFilter = ""; }
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "VatTuDaDuocChon", Commons.Modules.TypeLanguage));
                    return true;
                }
            }
            //luoi xuat
            if (iLuoi != 3)
            {
                
                dtTmp = new DataTable();
                dtLuoi = new DataTable();
                dtLuoi = (DataTable)grdXuat.DataSource;
                dtTmp = dtLuoi.Copy();
                try
                {
                    dtTmp.DefaultView.RowFilter = dk + " AND ( CHON = 1)";
                }
                catch { dtTmp.DefaultView.RowFilter = ""; }
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "VatTuDaDuocChon", Commons.Modules.TypeLanguage));
                    return true;
                }
            }
            //luoi danh muc
            if (iLuoi != 4)
            {
                if (grdVT.DataSource == null) return false;
                dk = dk + " AND ( CHON = 1)";
                dtTmp = new DataTable();
                dtLuoi = new DataTable();
                dtLuoi = (DataTable)grdVT.DataSource;
                dtTmp = dtLuoi.Copy();
                try
                {
                    dtTmp.DefaultView.RowFilter = dk + " AND ( CHON = 1)";
                }
                catch { dtTmp.DefaultView.RowFilter = ""; }
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "VatTuDaDuocChon", Commons.Modules.TypeLanguage));
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region tao Du Lieu
        private void TaoLuoiCV()
        {
            try
            {
                string sSql = "";
                sSql = "SELECT DISTINCT MS_CV,TEN_BO_PHAN,MS_BO_PHAN,MA_CV,HANG_MUC_ID, " +
                            " CONVERT(NVARCHAR(250),MS_CV) +  CONVERT(NVARCHAR(250),MS_BO_PHAN) AS MSCVBT " +
                            " FROM " + sBTCV + " ORDER BY TEN_BO_PHAN,MA_CV";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["MSCVBT"] };

                
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCVBP, grdDanhsachcongviec, dtTmp, false, false, true, true);

                if (MS_CVBT != "-1")
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(MS_CVBT));
                    grdDanhsachcongviec.FocusedRowHandle = grdDanhsachcongviec.GetRowHandle(index);
                }
                grdDanhsachcongviec.Columns["MS_CV"].Visible = false;
                grdDanhsachcongviec.Columns["MS_BO_PHAN"].Visible = false;
                grdDanhsachcongviec.Columns["HANG_MUC_ID"].Visible = false;
                grdDanhsachcongviec.Columns["MSCVBT"].Visible = false;
                for (int i = 0; i <= grdDanhsachcongviec.Columns.Count - 1; i++)
                {
                    grdDanhsachcongviec.Columns[i].OptionsColumn.ReadOnly = true;
                }
            }
            catch { }
        }

        private void TaoLuoiPT()
        {
            try
            {
                DataTable dtTmp = new DataTable();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDSCauTrucThietBiPhuTung", Modules.TypeLanguage, Modules.UserName,sBTPTCV,sBTCV,  MS_MAY, MS_PHIEU_BAO_TRI));
                dtTmp.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSPTCon, grdDanhsachphutungcon, dtTmp, true, false, false, true);
                for (int i = 1; i <= grdDanhsachphutungcon.Columns.Count - 1; i++)
                {
                    grdDanhsachphutungcon.Columns[i].OptionsColumn.ReadOnly = true;
                }
                grdDanhsachphutungcon.Columns["MS_PT_CHA"].Visible = false;
                grdDanhsachphutungcon.Columns["MS_BO_PHAN"].Visible = false;
                grdDanhsachphutungcon.Columns["MS_CV"].Visible = false;
                grdDanhsachphutungcon.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
                grdDanhsachphutungcon.Columns["CHON"].OptionsColumn.FixedWidth = true;
                grdDanhsachphutungcon.Columns["MS_PT"].OptionsColumn.FixedWidth = true;
                grdDanhsachphutungcon.Columns["MS_PT_NCC"].OptionsColumn.FixedWidth = true;
                grdDanhsachphutungcon.Columns["MS_PT_CTY"].OptionsColumn.FixedWidth = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void TaoLuoiPTVT()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDSCauTrucThietBiPhuTungVatTu", Modules.TypeLanguage, Modules.UserName,sBTPTCV,sBTCV, MS_MAY, MS_PHIEU_BAO_TRI));
                dtTmp.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdVTPT, dgrDanhSachVatTuPhuTung, dtTmp, true, false, false, true);
                for (int i = 1; i <= dgrDanhSachVatTuPhuTung.Columns.Count - 1; i++)
                {
                    dgrDanhSachVatTuPhuTung.Columns[i].OptionsColumn.ReadOnly = true;
                }
                dgrDanhSachVatTuPhuTung.Columns["MS_PT_CHA"].Visible = false;
                dgrDanhSachVatTuPhuTung.Columns["MS_BO_PHAN"].Visible = false;
                dgrDanhSachVatTuPhuTung.Columns["MS_CV"].Visible = false;
                dgrDanhSachVatTuPhuTung.Columns["MS_PHIEU_BAO_TRI"].Visible = false;

                dgrDanhSachVatTuPhuTung.Columns["CHON"].OptionsColumn.FixedWidth = true;
                dgrDanhSachVatTuPhuTung.Columns["MS_PT"].OptionsColumn.FixedWidth = true;
                dgrDanhSachVatTuPhuTung.Columns["MS_PT_NCC"].OptionsColumn.FixedWidth = true;
                dgrDanhSachVatTuPhuTung.Columns["MS_PT_CTY"].OptionsColumn.FixedWidth = true;
            }
            catch { }
            Commons.Modules.ObjSystems.XoaTable("PBT_PTVT_TMP" + Modules.UserName);
        }

        private void TaoLuoiDMVT()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                
                string sSql = "";
                string sBoPhan;
                int iCV;
                sBoPhan = grdDanhsachcongviec.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
                iCV = int.Parse(grdDanhsachcongviec.GetFocusedRowCellValue("MS_CV").ToString());
                sSql = "SELECT * FROM " + sBTDMVT + " WHERE MS_BO_PHAN = '" + sBoPhan + "' AND MS_CV = '" + iCV.ToString() + "' ORDER BY MS_PT ";
                DataTable dtDMVT = new DataTable();
                dtDMVT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtDMVT.Rows.Count == 0)
                {
                    dtDMVT = new DataTable();
                    dtDMVT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDSDMVT", Modules.TypeLanguage, Modules.UserName, sBTPTCV, MS_PHIEU_BAO_TRI, MS_MAY, sBoPhan, iCV));
                    string sBT = "CHON_DMPT" + Commons.Modules.UserName;
                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    Modules.ObjSystems.MCreateTableToDatatable(IConnections.ConnectionString, sBT, dtDMVT, "");
                    sSql = "INSERT INTO " + sBTDMVT + " SELECT * FROM " + sBT;
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                    sSql = "SELECT * FROM " + sBTDMVT + " WHERE MS_BO_PHAN = '" + sBoPhan + "' AND MS_CV = '" + iCV.ToString() + "' ORDER BY MS_PT";
                    dtDMVT = new DataTable();
                    dtDMVT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));

                }
                dtDMVT.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdVT, grdDMVT, dtDMVT, true, false, true, true);
                Cursor = Cursors.Default;
                if (!grdDMVT.Columns["MS_BO_PHAN"].Visible) return;
                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grdDMVT, this.Name.ToString());

                for (int i = 1; i <= grdDMVT.Columns.Count - 1; i++)
                {
                    grdDMVT.Columns[i].OptionsColumn.ReadOnly = true;
                }
                grdDMVT.Columns["MS_BO_PHAN"].Visible = false;
                grdDMVT.Columns["MS_CV"].Visible = false;
                grdDMVT.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
                grdDMVT.Columns["MSCVBT"].Visible = false;
                grdDMVT.Columns["MS_PT"].OptionsColumn.FixedWidth = true;
                grdDMVT.Columns["CHON"].OptionsColumn.FixedWidth = true;
                grdDMVT.Columns["MS_PT_NCC"].OptionsColumn.FixedWidth = true;
                grdDMVT.Columns["MS_PT_CTY"].OptionsColumn.FixedWidth = true;
            }
            catch { }
            Cursor = Cursors.Default;
        }
     
        #endregion


        private void frmChonPhuTungcho_PBT_Load(object sender, EventArgs e)
        {
            if (MS_PHIEU_BAO_TRI == "-1")
            {
                sBTCV = "PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName;
                sBTPTCV = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" + Commons.Modules.UserName;
                sBTVTX = "PHU_TU_XK" + Commons.Modules.UserName;
                sBTDMVT = "DMVT" + Commons.Modules.UserName;

            }
            else
            {
                sBTCV = "PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName;
                sBTPTCV = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" + Commons.Modules.UserName;
                sBTVTX = "PHU_TU_XK" + Commons.Modules.UserName;
                sBTDMVT = "DMVT" + Commons.Modules.UserName;
            }
            Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();
                string sSql = "";
                Commons.Modules.SQLString = "0LOAD";
                TaoLuoiCV();
                Commons.Modules.SQLString = "";
                TaoLuoiPT();
                TaoLuoiPTVT();

                #region Tao Luoi Xuat
                dtTmp = new DataTable();
                sSql = "SELECT CONVERT(BIT,CHON) AS CHON, T1.MS_PHIEU_BAO_TRI, " +
                            " T1.MS_PT, T1.TEN_PT, T4.TEN_PT_VIET,T1.QUY_CACH, T1.MS_PT_NCC,T4.[MS_PT_CTY], SL_VT," +
                            " CASE " + Modules.TypeLanguage.ToString() + " WHEN 0 THEN B.TEN_LOAI_VT_TV WHEN 1 THEN B.TEN_LOAI_VT_TA ELSE B.TEN_LOAI_VT_TV END AS TEN_LOAI_VT_TV, " +
                            " CASE " + Modules.TypeLanguage.ToString() + " WHEN 0 THEN C.TEN_1 WHEN 1 THEN C.TEN_2 ELSE C.TEN_3 END AS TEN_1 ," +
                            " MS_DH_XUAT_PT, MS_DH_NHAP_PT, TEN_VI_TRI, T1.MS_BO_PHAN, T1.MS_CV FROM " + sBTVTX + " T1 INNER JOIN IC_PHU_TUNG T4 ON T4.MS_PT = T1.MS_PT " +
                            " LEFT JOIN dbo.LOAI_VT B ON T4.MS_LOAI_VT = B.MS_LOAI_VT LEFT JOIN DON_VI_TINH C ON T4.DVT = C.DVT ORDER BY T1.MS_PT , T1.TEN_PT ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dtTmp.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdXuat, grdPTXuatKho, dtTmp, true, false, true, true);
                for (int i = 1; i <= grdPTXuatKho.Columns.Count - 1; i++)
                {
                    grdPTXuatKho.Columns[i].OptionsColumn.ReadOnly = true;
                }
                grdPTXuatKho.Columns["MS_BO_PHAN"].Visible = false;
                grdPTXuatKho.Columns["MS_CV"].Visible = false;
                grdPTXuatKho.Columns["MS_PHIEU_BAO_TRI"].Visible = false;

                grdPTXuatKho.Columns["CHON"].OptionsColumn.FixedWidth = true;
                grdPTXuatKho.Columns["MS_PT"].OptionsColumn.FixedWidth = true;
                grdPTXuatKho.Columns["MS_PT_NCC"].OptionsColumn.FixedWidth = true;
                grdPTXuatKho.Columns["MS_PT_CTY"].OptionsColumn.FixedWidth = true;

                #endregion


                
                string sBoPhan;
                int iCV;
                try
                { sBoPhan = grdDanhsachcongviec.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
                iCV = int.Parse(grdDanhsachcongviec.GetFocusedRowCellValue("MS_CV").ToString());
                }
                catch { sBoPhan = "-1";
                iCV = -1;
                }
                

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDSDMVT", Modules.TypeLanguage, Modules.UserName,sBTPTCV, MS_PHIEU_BAO_TRI, MS_MAY, sBoPhan, iCV));
                Commons.Modules.ObjSystems.XoaTable(sBTDMVT);
                Modules.ObjSystems.MCreateTableToDatatable(IConnections.ConnectionString, sBTDMVT, dtTmp, "");


                TaoLuoiDMVT();
                LocDuLieu();
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                tabVatTu.TabPages[0].Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name.ToString(), "TabCautructhietbi", Commons.Modules.TypeLanguage);
                tabVatTu.TabPages[1].Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name.ToString(), "TabVTTuXuat", Commons.Modules.TypeLanguage);
                tabVatTu.TabPages[2].Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name.ToString(), "tabDMVT", Commons.Modules.TypeLanguage);
            }
            catch (Exception EX)
            {
                XtraMessageBox.Show(EX.Message);
            }
            Cursor = Cursors.Default;
            Commons.Modules.SQLString = "";
        }

        private void grdDanhsachcongviec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            Commons.Modules.SQLString = "";
            if (tabVatTu.SelectedTabPageIndex == 2)
                TaoLuoiDMVT();
            LocDuLieu();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LocDuLieu();
        }

        private void LocDuLieu()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            Commons.Modules.SQLString = "";
            DataTable dtTmp = new DataTable();
            
            string dk = "";
            dk = " (MS_BO_PHAN = '" + grdDanhsachcongviec.GetFocusedRowCellValue("MS_BO_PHAN").ToString() + "' AND MS_CV = " + grdDanhsachcongviec.GetFocusedRowCellValue("MS_CV").ToString() + " ) ";
            if (txtTKiem.Text != "") dk = dk + " AND (MS_PT LIKE '%" + txtTKiem.Text + "%' OR TEN_PT LIKE '%" + txtTKiem.Text + "%' " +
                " OR TEN_PT_VIET LIKE '%" + txtTKiem.Text + "%'  OR QUY_CACH LIKE '%" + txtTKiem.Text + "%' " +
                "   OR MS_PT_NCC LIKE '%" + txtTKiem.Text + "%'   OR MS_PT_CTY LIKE '%" + txtTKiem.Text + "%' " +
                "   OR TEN_LOAI_VT_TV LIKE '%" + txtTKiem.Text + "%'   OR TEN_1 LIKE '%" + txtTKiem.Text + "%' " +
                "   )";

            dtTmp = (DataTable)grdDSPTCon.DataSource;
            try
            {
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
            dtTmp = new DataTable();
            dtTmp = (DataTable)grdVTPT.DataSource;
            try
            {
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }

            dtTmp = new DataTable();
            dtTmp = (DataTable)grdXuat.DataSource;
            try
            {
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }

            if (tabVatTu.SelectedTabPageIndex != 2) return;
            dtTmp = new DataTable();
            dtTmp = (DataTable)grdVT.DataSource;
            try
            {
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

        #region Kiem Du Lieu Chon
        private void grdDanhsachphutungcon_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grdDanhsachphutungcon.FocusedColumn.FieldName.ToUpper() != "CHON") return;
            this.Cursor = Cursors.WaitCursor;
            GridView view = sender as GridView;
            DataTable dtTmp = new DataTable();
            #region Kiem da chon phu tung cha chua
            string sBTTmp = "KIEM_TMP" + Commons.Modules.UserName;
            try
            {

                dtTmp = (DataTable)grdDSPTCon.DataSource;
                Modules.ObjSystems.MCreateTableToDatatable(IConnections.ConnectionString, sBTTmp, dtTmp, "");
                string sSql = "";
                if (grdDanhsachphutungcon.GetFocusedRowCellValue("MS_PT_CHA").ToString().ToUpper() == "Y")
                {
                    sSql = "SELECT TOP 1 * FROM " + sBTTmp + " T1 WHERE EXISTS (SELECT MS_PT FROM CAU_TRUC_THIET_BI T2 WHERE MS_MAY=N'" + MS_MAY + "' AND MS_BO_PHAN ='" +
                        grdDanhsachphutungcon.GetFocusedRowCellValue("MS_BO_PHAN").ToString() + "' AND T1.MS_PT = T2.MS_PT AND T1.MS_BO_PHAN = T2.MS_BO_PHAN  ) AND (CHON = 1) " +
                        " AND (MS_CV = '" + grdDanhsachphutungcon.GetFocusedRowCellValue("MS_CV").ToString() + "') ";
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "DA_CHON_PT_CHA", Commons.Modules.TypeLanguage));
                        e.Cancel = true;
                        Modules.ObjSystems.XoaTable(sBTTmp);
                        return;
                    }
                }
            #endregion

                #region Kiem da chon phu tung con ma con chon phu tung cha
                if (grdDanhsachphutungcon.GetFocusedRowCellValue("MS_PT_CHA").ToString().ToUpper() == "YN")
                {
                    sSql = "SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" + MS_MAY + "' AND MS_BO_PHAN ='" + grdDanhsachphutungcon.GetFocusedRowCellValue("MS_BO_PHAN").ToString() + "'";
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        string sPT = dtTmp.Rows[0]["MS_PT"].ToString();
                        sSql = "SELECT COUNT(*) FROM " + sBTTmp + " T1 INNER JOIN dbo.IC_PHU_TUNG ON T1.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " +
                                        "dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT " +
                                 "WHERE (T1.MS_CV = '" + grdDanhsachphutungcon.GetFocusedRowCellValue("MS_CV").ToString() + "') " +
                                 " AND (T1.MS_BO_PHAN = '" + grdDanhsachphutungcon.GetFocusedRowCellValue("MS_BO_PHAN").ToString() + "') AND (dbo.LOAI_VT.VAT_TU = 0)  AND (CHON = 1) AND (T1.MS_PT <> '" + sPT + "' ) ";
                        dtTmp = new DataTable();
                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                        if (int.Parse(dtTmp.Rows[0][0].ToString()) > 0 && sPT.ToUpper() == grdDanhsachphutungcon.GetFocusedRowCellValue("MS_PT").ToString())
                        {
                            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                this.Name, "CO_MUON_CHON_PT_CHA", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                Modules.ObjSystems.XoaTable(sBTTmp);
                                e.Cancel = true;
                                return;
                            }
                            else
                            {
                                Commons.Modules.SQLString = "LOI";
                            }
                        }
                    }
                }
                #endregion


                if (bool.Parse(grdDanhsachphutungcon.GetFocusedRowCellValue("CHON").ToString()) == true && KiemPTTonTaiNAV(grdDanhsachphutungcon.GetFocusedRowCellValue("MS_PT").ToString()))
                    e.Cancel = true;

                if (bool.Parse(grdDanhsachphutungcon.GetFocusedRowCellValue("CHON").ToString()) == false && KiemPTDaChon(1,grdDanhsachphutungcon.GetFocusedRowCellValue("MS_PT").ToString()))
                    e.Cancel = true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
            Modules.ObjSystems.XoaTable(sBTTmp);
        }

        private void grdDanhsachphutungcon_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in view.Columns)
                {
                    if (col.Name.ToUpper() == "COLMS_PT_CHA")
                    {
                        if (e.RowHandle >= 0)
                        {
                            string TT;
                            TT = view.GetRowCellDisplayText(e.RowHandle, col);
                            if (TT == "YN")
                                e.Appearance.BackColor = ColorTranslator.FromHtml("#3a9da4");
                        }
                    }

                }
            }
            catch { }

            if (Commons.Modules.SQLString == "LOI")
            {
                Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grdDanhsachphutungcon);
                grdDanhsachphutungcon.SetFocusedRowCellValue("CHON", (bool)true);
                Commons.Modules.SQLString = "";
            }
        }

        private void dgrDanhSachVatTuPhuTung_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (dgrDanhSachVatTuPhuTung.FocusedColumn.FieldName.ToUpper() != "CHON") return;
            this.Cursor = Cursors.WaitCursor;
            if (bool.Parse(dgrDanhSachVatTuPhuTung.GetFocusedRowCellValue("CHON").ToString()) == true && KiemPTTonTaiNAV(dgrDanhSachVatTuPhuTung.GetFocusedRowCellValue("MS_PT").ToString()))
                e.Cancel = true;
            if (bool.Parse(dgrDanhSachVatTuPhuTung.GetFocusedRowCellValue("CHON").ToString()) == false && KiemPTDaChon(2,dgrDanhSachVatTuPhuTung.GetFocusedRowCellValue("MS_PT").ToString()))
                e.Cancel = true;
            this.Cursor = Cursors.Default;

        }

        private void grdPTXuatKho_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grdPTXuatKho.FocusedColumn.FieldName.ToUpper() != "CHON") return;
            this.Cursor = Cursors.WaitCursor;
            if (bool.Parse(grdPTXuatKho.GetFocusedRowCellValue("CHON").ToString()) == true && KiemPTTonTaiNAV(grdPTXuatKho.GetFocusedRowCellValue("MS_PT").ToString()))
                e.Cancel = true;
            if (bool.Parse(grdPTXuatKho.GetFocusedRowCellValue("CHON").ToString()) == false && KiemPTDaChon(3,grdPTXuatKho.GetFocusedRowCellValue("MS_PT").ToString()))
                e.Cancel = true;
            this.Cursor = Cursors.Default;

        }

        private void grdDMVT_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grdDMVT.FocusedColumn.FieldName.ToUpper() != "CHON") return;
            this.Cursor = Cursors.WaitCursor;
            if (bool.Parse(grdDMVT.GetFocusedRowCellValue("CHON").ToString()) == true && KiemPTTonTaiNAV(grdDMVT.GetFocusedRowCellValue("MS_PT").ToString()))
                e.Cancel = true;
            if (bool.Parse(grdDMVT.GetFocusedRowCellValue("CHON").ToString()) == false && KiemPTDaChon(4,grdDMVT.GetFocusedRowCellValue("MS_PT").ToString()))
                e.Cancel = true;
            this.Cursor = Cursors.Default;


        }
        #endregion


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Modules.ObjSystems.XoaTable(sBTDMVT);
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            // Return True ton tai
            string sSql ;            
            sSql = "DELETE FROM " + sBTPTCV;
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

            string sBT = "BTDL_TMP" + Modules.UserName;
            DataTable dtTmp = new DataTable();
            Modules.ObjSystems.XoaTable(sBT);
            try
            {
                if (grdDSPTCon.DataSource != null)
                {
                    dtTmp = new DataTable();
                    dtTmp = (DataTable)grdDSPTCon.DataSource;
                    Modules.ObjSystems.MCreateTableToDatatable(IConnections.ConnectionString, sBT, dtTmp, "");
                    sSql = "INSERT INTO " + sBTPTCV + " (MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY,TU_XUAT) " +
                                "SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,'Y',MS_PT_NCC,MS_PT_CTY,0 FROM " + sBT + " T1 WHERE CHON = 1" +
                                " AND NOT EXISTS (SELECT * FROM " + sBTPTCV + " T2 WHERE T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI AND T1.MS_BO_PHAN = T2.MS_BO_PHAN " +
                                " AND T1.MS_CV = T2.MS_CV  AND T1.MS_PT = T2.MS_PT)";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                }


                if (grdVTPT.DataSource != null)
                {

                    dtTmp = new DataTable();
                    dtTmp = (DataTable)grdVTPT.DataSource;
                    Modules.ObjSystems.MCreateTableToDatatable(IConnections.ConnectionString, sBT, dtTmp, "");
                    sSql = "INSERT INTO " + sBTPTCV + " (MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY,TU_XUAT) " +
                                "SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY,0 FROM " + sBT + " T1 WHERE CHON = 1" +
                                " AND NOT EXISTS (SELECT * FROM " + sBTPTCV + " T2 WHERE T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI AND T1.MS_BO_PHAN = T2.MS_BO_PHAN " +
                                " AND T1.MS_CV = T2.MS_CV  AND T1.MS_PT = T2.MS_PT)";
                    SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, CommandType.Text, sSql);

                }

                sSql = " UPDATE " + sBTVTX + " SET CHON = 0";
                SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, CommandType.Text, sSql);
                dtTmp = new DataTable();
                dtTmp = (DataTable)grdXuat.DataSource;
                Modules.ObjSystems.MCreateTableToDatatable(IConnections.ConnectionString, sBT, dtTmp, "");
                sSql = " UPDATE " + sBTVTX + " SET CHON = 1 FROM " + sBTVTX + " T1 INNER JOIN " + sBT + " T2 ON T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI AND T1.MS_BO_PHAN = T2.MS_BO_PHAN " +
                            " AND T1.MS_CV = T2.MS_CV  AND T1.MS_PT = T2.MS_PT WHERE T2.CHON = 1";
                SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, CommandType.Text, sSql);

                if (grdVT.DataSource != null)
                {
                    
                    //dtTmp = new DataTable();
                    //dtTmp = (DataTable)grdVT.DataSource;
                    //Modules.ObjSystems.MCreateTableToDatatable(IConnections.ConnectionString, sBT, dtTmp, "");

                    sSql = "INSERT INTO " + sBTPTCV + " (MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,MS_PT_CHA,MS_PT_NCC,MS_PT_CTY,TU_XUAT, VTPT) " +
                                " SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,'YN',MS_PT_NCC,MS_PT_CTY,0,1 FROM " + sBTDMVT + " T1 WHERE (CHON = 1) " +
                                " AND NOT EXISTS (SELECT * FROM " + sBTPTCV + " T2 WHERE T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI AND T1.MS_BO_PHAN = T2.MS_BO_PHAN " +
                                " AND T1.MS_CV = T2.MS_CV  AND T1.MS_PT = T2.MS_PT)";
                    SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, CommandType.Text, sSql);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            Modules.ObjSystems.XoaTable(sBT);
            Modules.ObjSystems.XoaTable(sBTDMVT);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void tabYCSDung_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabVatTu.SelectedTabPageIndex != 2) return;
            

            try
            {
                string sBoPhan;
                int iCV;
                sBoPhan = grdDanhsachcongviec.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
                iCV = int.Parse(grdDanhsachcongviec.GetFocusedRowCellValue("MS_CV").ToString());
                if (sBoPhan == grdDMVT.GetFocusedRowCellValue("MS_BO_PHAN").ToString() && iCV == int.Parse(grdDMVT.GetFocusedRowCellValue("MS_CV").ToString())) return;
            }
            catch { }

            Cursor = Cursors.WaitCursor;
            TaoLuoiDMVT();
            Cursor = Cursors.Default;
        }

        private void grdDMVT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.ToUpper() != "CHON") return;
            string sSql = "";
            string sBoPhan;
            int iCV;
            sBoPhan = grdDanhsachcongviec.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
            iCV = int.Parse(grdDanhsachcongviec.GetFocusedRowCellValue("MS_CV").ToString());




            sSql = "UPDATE " + sBTDMVT + " SET CHON = " + ( Boolean.Parse(e.Value.ToString()) == true? "1" : "0") + " WHERE MS_BO_PHAN = '" +
                    sBoPhan + "' AND MS_CV = '" + iCV.ToString() + "' AND MS_PT = '" + grdDMVT.GetFocusedRowCellValue("MS_PT").ToString() + "' ";
            SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, CommandType.Text, sSql); 

        }
    }
}