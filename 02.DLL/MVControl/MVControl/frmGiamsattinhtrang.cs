using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MVControl
{
    public partial class frmGiamsattinhtrang : DevExpress.XtraEditors.XtraForm
    {

        string sBTamGiaTri = "GIA_TRI_TMP" + Commons.Modules.UserName;
        string sBTamGiaTriDL = "GIA_TRI_TMPDL" + Commons.Modules.UserName;
        public Form frmThongsoGSTT;
        public frmGiamsattinhtrang()
        {
            InitializeComponent();
        }
        #region khởi tạo biến
        bool co = true;
        bool bXoa = false;
        #endregion

        #region hàm load dữ liệu
        //load cbb Nhân viên kỹ thuật
        public void cbbNVKT()
        {
            cboCNKT.Properties.DataSource = null;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", -1, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboCNKT, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "");
        }
        //loadtext
        private void LoadText(bool bNull)
        {
            if (bNull)
            {
                txtSoPhieu.Text = "";
                datTNgayKT.DateTime = DateTime.Now.Date;
                timKT.Text = "";
                txtUser.Text = Commons.Modules.UserName;
                try
                {
                    if (String.IsNullOrEmpty(Commons.Modules.sMaNhanVienMD))
                        cboCNKT.EditValue = ((DataTable)(cboCNKT.Properties.DataSource)).Rows[0][0].ToString();
                    else
                        cboCNKT.EditValue = Commons.Modules.sMaNhanVienMD;
                }
                catch { }
                txtGhiChu.Text = "";
                txtsttGSTT.Text = "-1";
                chkXong.EditValue = false;
                txtTongTG.Text = "0";
            }
            else
            {
                if (grvDSLGS.RowCount == 0)
                {
                    txtSoPhieu.Text = "";
                    datTNgayKT.DateTime = DateTime.Now.Date;
                    timKT.Text = "";
                    txtUser.Text = Commons.Modules.UserName;
                    try
                    {
                        if (String.IsNullOrEmpty(Commons.Modules.sMaNhanVienMD))
                            cboCNKT.EditValue = ((DataTable)(cboCNKT.Properties.DataSource)).Rows[0][0].ToString();
                        else
                            cboCNKT.EditValue = Commons.Modules.sMaNhanVienMD;
                    }
                    catch { }
                    txtGhiChu.Text = "";
                    txtsttGSTT.Text = "-1";
                    chkXong.EditValue = false;
                    txtTongTG.Text = "0";
                }
                else
                {
                    try
                    {
                        txtSoPhieu.Text = (string.IsNullOrEmpty(grvDSLGS.GetFocusedRowCellValue("SO_PHIEU").ToString()) ? "" : grvDSLGS.GetFocusedRowCellValue("SO_PHIEU").ToString());
                        datTNgayKT.DateTime = Convert.ToDateTime(grvDSLGS.GetFocusedRowCellValue("NGAY_KT").ToString());
                        timKT.Time = Convert.ToDateTime(grvDSLGS.GetFocusedRowCellValue("GIO_KT").ToString());
                        cboCNKT.EditValue = grvDSLGS.GetFocusedRowCellValue("MS_CONG_NHAN").ToString();
                        txtUser.Text = grvDSLGS.GetFocusedRowCellValue("USERNAME").ToString();
                        txtGhiChu.Text = grvDSLGS.GetFocusedRowCellValue("GHI_CHU").ToString();
                        try
                        {
                            txtTongTG.Text = Math.Round(Convert.ToDouble(grvDSLGS.GetFocusedRowCellValue("TONG_TG").ToString()), 2).ToString("N0");
                        }
                        catch { txtTongTG.EditValue = 0; }
                        txtsttGSTT.Text = grvDSLGS.GetFocusedRowCellValue("STT").ToString();
                        chkXong.EditValue = Convert.ToBoolean(grvDSLGS.GetFocusedRowCellValue("HOAN_THANH"));
                    }
                    catch (Exception ex) { }
                }
            }
        }
        //hafm reset
        public void loadDSGSTT(int iSTT)
        {
            if (Commons.Modules.SQLString == "0load") return;
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_GetLOAIDSGSTT", DatNgayBD.DateTime, datNgayKT.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["STT"] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            grdDSLGS.DataSource = null;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSLGS, grvDSLGS, dt, false, true, false, true, true, this.Name);
            grvDSLGS.Columns["SO_PHIEU"].Width = 200;
            grvDSLGS.Columns["NGAY_GIO"].Width = 200;
            grvDSLGS.Columns["NGAY_GIO"].DisplayFormat.FormatType = FormatType.DateTime;
            grvDSLGS.Columns["NGAY_GIO"].DisplayFormat.FormatString = "D";
            grvDSLGS.Columns["TEN_CN"].Width = 200;
            grvDSLGS.Columns["GHI_CHU"].Width = 400;
            grvDSLGS.Columns["NGAY_KT"].Visible = false;
            grvDSLGS.Columns["GIO_KT"].Visible = false;
            grvDSLGS.Columns["USERNAME"].Width = 100;
            grvDSLGS.Columns["HOAN_THANH"].Visible = false;
            grvDSLGS.Columns["GHI_CHU"].Width = 300;
            grvDSLGS.Columns["STT"].Visible = false;
            grvDSLGS.Columns["TONG_TG"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(0);
            grvDSLGS.Columns["TONG_TG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            if (iSTT != -1)
            {
                int index = dt.Rows.IndexOf(dt.Rows.Find(iSTT));
                grvDSLGS.FocusedRowHandle = grvDSLGS.GetRowHandle(index);
            }

            //colUnitsInStock1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
            //colUnitsInStock1.SummaryItem.DisplayFormat = "Average = {0:n2}";

        }
        //load ngày mặc định
        public void loaddatNgay()
        {
            try
            {
                DatNgayBD.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);//DateTime.Now.Year);
                datNgayKT.DateTime = DatNgayBD.DateTime.AddMonths(1).AddDays(-1);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
        #endregion

        #region sự kiện control form
        private void frmGSTT_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0load";
            loaddatNgay();
            cbbNVKT();
            Commons.Modules.SQLString = "";
            loadDSGSTT(-1);
            LoadText(false);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        #endregion

        #region tìm kiếm
        //tìm kiếm theo ngày
        private void DatNgayBD_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DatNgayBD.Text) || string.IsNullOrEmpty(datNgayKT.Text))
            {
                loaddatNgay();
            }
            try
            {
                if (Commons.Modules.SQLString == "0load") return;
                loadDSGSTT(-1);
            }
            catch (Exception ex) { }
        }
        #endregion

        #region hàm sử lý enable và readonly
        private void VisThemSua(bool bThemSua)
        {
            btnThem.Visible = !bThemSua;
            btnSua.Visible = !bThemSua;
            btnXoa.Visible = !bThemSua;
            btnThoat.Visible = !bThemSua;


            BtnChonTSDT.Visible = bThemSua;
            BtnChonTSDL.Visible = bThemSua;
            btnGhi.Visible = bThemSua;
            btnKhongGhi.Visible = bThemSua;

            tableLayoutPanel2.Enabled = !tableLayoutPanel2.Enabled;
            txtGhiChu.Properties.ReadOnly = !txtGhiChu.Properties.ReadOnly;
            timKT.Enabled = !timKT.Enabled;
            cboCNKT.Enabled = !cboCNKT.Enabled;
            datTNgayKT.Enabled = !datTNgayKT.Enabled;
            chkXong.Enabled = !chkXong.Enabled;

            if (!btnGhi.Visible) return;
            if (tabThongSo.SelectedTabPageIndex == 0)
            {
                BtnChonTSDT.Visible = true;
                BtnChonTSDL.Visible = false;
            }
            else
            {
                BtnChonTSDT.Visible = false;
                BtnChonTSDL.Visible = true;
            }
        }
        #endregion

        #region thêm dữ liệu cho giám sát tình trạng

        //hàm load ngay mặt định
        public void loadngayhientai()
        {
            datTNgayKT.EditValue = DateTime.Now;
            timKT.EditValue = DateTime.Now;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!TaoBangTam()) return;
            if (!TaoBangTamDL()) return;
            listcongviec.Clear();
            try
            {
                
                VisThemSua(true);
                datTNgayKT.Focus();
                loadngayhientai();
                loaddanhsachDT(-1);
                loaddanhsachDL(-1);
                LoadText(true);
                txtsttGSTT.EditValue = -1;
                txtSoPhieu.Text = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "select dbo.AUTO_CREATE_SO_PHIEU_GSTT('" + datTNgayKT.DateTime.Date.ToString("MM/dd/yyyy") + "')"));
                co = true;
                if (tabChung.SelectedTabPageIndex == 1) return;
                tabChung.SelectedTabPageIndex = 1;
            }
            catch { }
        }
        #endregion

        #region hàm edit dữ liệu form giám sát tình trạng

        //xóa dữ liệu
        public void DELETE_GSTT(int co)
        {
            List<SqlParameter> parameter = new List<SqlParameter>() {
                new SqlParameter("@SO_PHIEU", txtSoPhieu.EditValue.ToString()),
                new SqlParameter("@co", co)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "sp_DeleteGiamSatTinhTrang", parameter.ToArray());
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
        #endregion

        #region sự kiện button
        private void btnSua_Click(object sender, EventArgs e)
        {
            if(grvDSLGS.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChonGiamSat", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listcongviec.Clear();
            this.Cursor = Cursors.WaitCursor;
            loadngayhientai();
            VisThemSua(true);
            datNgayKT.Focus();
            co = false;
            Commons.Modules.SQLString = "0Load1";
            adddulieuvaobangtam();
            Commons.Modules.SQLString = "";
            LoadCTDTDL();
            this.Cursor = Cursors.Default;
            //KHI LƯU chuyển tab về 2
            if (tabChung.SelectedTabPageIndex == 1) return;
            tabChung.SelectedTabPageIndex = 1;
        }
        private void adddulieuvaobangtam()
        {
            //if (grvTSDinhTinh.DataSource == null) return;
            Commons.Modules.ObjSystems.XoaTable(sBTamGiaTri);
            Commons.Modules.ObjSystems.XoaTable(sBTamGiaTriDL);
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spUpDateDanhSachDinhTinh", txtsttGSTT.EditValue, sBTamGiaTri);
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spUpDateDanhSachDinhLuong", txtsttGSTT.EditValue, sBTamGiaTriDL);
            loaddanhsachDT(Convert.ToInt16(txtsttGSTT.EditValue));
            loaddanhsachDL(Convert.ToInt16(txtsttGSTT.EditValue));
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //DialogResult dl = XtraMessageBox.Show("Bạn có muốn xóa " + grvDSLGS.GetFocusedRowCellValue("SO_PHIEU").ToString() + " ", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dl == DialogResult.Yes)
            //{
            //    try
            //    {
            //        DELETE_GSTT("sp_DELETEGIAMSATTRANG");
            //        loadDSGSTT();
            //        LoadText(false);
            //    }
            //    catch
            //    {
            //        XtraMessageBox.Show("Số phiếu " + grvDSLGS.GetFocusedRowCellValue("SO_PHIEU").ToString() + ", đã tồn tại thiết bị ", "không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDuLieuMaySai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //}
            if (tabChung.SelectedTabPageIndex == 0) XoaLanGS(); else XoaChiTietGS();
            return;
        }

        private void XoaLanGS()
        {
            try
            {
                if (grvDSLGS.RowCount == 0 || grdDSLGS.DataSource == null)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 STT FROM dbo.GIAM_SAT_TINH_TRANG_TS WHERE STT = " + txtsttGSTT.EditValue + " UNION SELECT TOP 1 STT FROM dbo.GIAM_SAT_TINH_TRANG_HINH WHERE STT = " + txtsttGSTT.EditValue + ""));
                if (dtTmp.Rows.Count > 0)
                {
                    if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoa2", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return;
                }
                else
                {
                    if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoa4", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return;
                }
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spXoaGiamSatTinhTrang", txtsttGSTT.EditValue, "-1", "-1", "-1", -1, -1, 1);
                DatNgayBD_EditValueChanged(null, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }


        private void XoaChiTietGS()
        {
            if (tabThongSo.SelectedTabPageIndex == 0)
            {
                if (grvTSDinhTinh.RowCount == 0 || grvTSDinhTinh.DataSource == null)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (grvTSDinhLuong.RowCount == 0 || grvTSDinhLuong.DataSource == null)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string msthongso; string msmay; string msbp; int sttHinh; int msTT;
            try
            {
                msTT = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TT").ToString()));
            }
            catch { msTT = -1; }
            try
            {
                msthongso = tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_TS_GSTT").ToString();
            }
            catch { msthongso = "-1"; }

            try
            {
                msmay = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_MAY").ToString());
            }
            catch { msmay = "-1"; }


            try
            {
                msbp = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_BO_PHAN").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_BO_PHAN").ToString());
            }
            catch { msbp = "-1"; }
            Boolean bXoaGS = false;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 * FROM dbo.GIAM_SAT_TINH_TRANG_HINH WHERE STT =" + txtsttGSTT.EditValue + " AND MS_MAY='" + msmay + "'AND MS_TS_GSTT ='" + msthongso + "' AND MS_BO_PHAN ='" + msbp + "' AND MS_TT ='" + msTT + "'"));
            if (dtTmp.Rows.Count > 0)
            {
                if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoa2", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return;
            }
            else
            {
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM dbo.GIAM_SAT_TINH_TRANG_TS WHERE STT = " + txtsttGSTT.EditValue));
                if (dtTmp.Rows.Count <= 1)
                {
                    if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgConDongCuoiCoMuonXoaLuonLanGiamSat", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return;
                    bXoaGS = true;
                }
                else
                {
                    if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoa4", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return;
                    bXoaGS = false;
                }
            }
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spXoaGiamSatTinhTrang", txtsttGSTT.EditValue, msmay, msthongso, msbp, msTT, -1, bXoaGS);

            bXoa = true;
            if (bXoaGS)
            {
                DatNgayBD_EditValueChanged(null, null);
                LoadText(false);
            }
            kiemtraload();
            bXoa = false;

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if(grvTSDinhTinh.RowCount == 0 && grvTSDinhLuong.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Commons.Modules.UserName,
                                    "msgChuaNhapGiaTriGiamSatNao", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int iSTT = -1;
            try
            {
                iSTT = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "sp_ADDGIAMSATTRANG", txtsttGSTT.Text, txtSoPhieu.Text, timKT.EditValue, datTNgayKT.DateTime.Date, cboCNKT.EditValue, txtGhiChu.Text, Commons.Modules.UserName, chkXong.EditValue, sBTamGiaTri, sBTamGiaTriDL).ToString());
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message.ToString()); }
            VisThemSua(false);
            Commons.Modules.SQLString = "0Load";
            loadDSGSTT(iSTT);
            LoadText(false);
            Commons.Modules.SQLString = "";
            loaddanhsachDT(int.Parse(txtsttGSTT.Text));
            loaddanhsachDL(int.Parse(txtsttGSTT.Text));
            //loaddanhsachthongso(int.Parse(txtsttGSTT.Text));
            LoadCTDTDL();
            Commons.Modules.ObjSystems.XoaTable(sBTamGiaTri);
            Commons.Modules.ObjSystems.XoaTable(sBTamGiaTriDL);
            //luu danh sach cong viec
            LuuListCongViec(iSTT);
            optGDat_EditValueChanged(null, null);
        }
        //không lưu
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            listcongviec.Clear();
            VisThemSua(false);
            LoadText(false);
            loaddanhsachDT(Convert.ToInt16(txtsttGSTT.EditValue));
            loaddanhsachDL(Convert.ToInt16(txtsttGSTT.EditValue));
            Commons.Modules.ObjSystems.XoaTable(sBTamGiaTri);
            Commons.Modules.ObjSystems.XoaTable(sBTamGiaTriDL);
            optGDat_EditValueChanged(null, null);
        }
        #endregion
        public void loadmay(int stt)
        {
            cbbThietBi.Properties.DataSource = null;
            DataTable _table = new DataTable();
            try
            {
                //if (int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("STT").ToString()) == stt) return;
            }
            catch { }
            if (btnGhi.Visible)
            {
                if (tabThongSo.SelectedTabPageIndex == 0)
                {
                    //load cac thiet bi tu bang tam dinh tinh
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT DISTINCT T1.MS_MAY, T2.TEN_MAY FROM " + sBTamGiaTri + " T1 INNER JOIN dbo.MAY T2 ON T2.MS_MAY = T1.MS_MAY ORDER BY T1.MS_MAY"));
                }
                else
                {
                    //load thiet bi tu bang tam dinh luong
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT DISTINCT T1.MS_MAY, T2.TEN_MAY FROM " + sBTamGiaTriDL + " T1 INNER JOIN dbo.MAY T2 ON T2.MS_MAY = T1.MS_MAY WHERE T1.GIA_TRI_DO IS NOT NULL ORDER BY T1.MS_MAY"));
                }
            }
            else
            {
                if (tabThongSo.SelectedTabPageIndex == 0)
                {
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_GetDanhSachThietBiByLoaiTS", stt, 1));
                }
                else
                {
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_GetDanhSachThietBiByLoaiTS", stt, 0));

                }
            }
            DataRow row = _table.NewRow();
            row["MS_MAY"] = "-1";
            row["TEN_MAY"] = "< ALL >";
            _table.Rows.Add(row);
            _table.DefaultView.Sort = "TEN_MAY";
            _table = _table.DefaultView.ToTable();
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cbbThietBi, _table, "MS_MAY", "TEN_MAY", "");
            }
            catch { }
        }
        public void loaddanhsachDT(int STT)
        {
            if (tabThongSo.SelectedTabPageIndex != 0) return;
            if (Commons.Modules.SQLString == "0Load") return;

            DataTable dt = new DataTable();
            try
            {
                grdTSDinhTinh.DataSource = null;
                if (btnGhi.Visible)
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spChonDanhSachThongSoDT", sBTamGiaTri, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    //if (txtsttGSTT.Text != "-1")
                    //{
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdTSDinhTinh, grvTSDinhTinh, dt, true, true, true, true, true, this.Name);
                        for (int i = 0; i <= 5; i++)
                        {
                            dt.Columns[i].ReadOnly = true;
                        }
                    //}
                    //else Commons.Modules.ObjSystems.MLoadXtraGrid(grdTSDinhTinh, grvTSDinhTinh, dt, false, true, true, true, true, this.Name);
                }
                else
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_DanhSachGiamSatTinhTrangDinhTinh", STT, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdTSDinhTinh, grvTSDinhTinh, dt, false, true, true, true, true, this.Name);
                }

                grvTSDinhTinh.Columns["MS_TS_GSTT"].Visible = false;
                grvTSDinhTinh.Columns["DAT"].Visible = false;
                grvTSDinhTinh.Columns["STT"].Visible = false;
                grvTSDinhTinh.Columns["MS_TT"].Visible = false;
                grvTSDinhTinh.Columns["MS_BO_PHAN"].Visible = false;
                grvTSDinhTinh.Columns["CT_CVIEC"].Width = 20;
                grvTSDinhTinh.Columns["MS_MAY"].Width = 80;
                grvTSDinhTinh.Columns["TEN_TS_GSTT"].Width = 200;

                grvTSDinhTinh.Columns["TG_TT"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(0);
                grvTSDinhTinh.Columns["TG_TT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                grvTSDinhTinh.Columns["TG_XU_LY"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(0);
                grvTSDinhTinh.Columns["TG_XU_LY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;



                RepositoryItemButtonEdit btnCTiet = new RepositoryItemButtonEdit();
                btnCTiet.TextEditStyle = TextEditStyles.HideTextEditor;
                btnCTiet.Buttons[0].Kind = ButtonPredefines.Glyph;
                btnCTiet.Buttons[0].Caption = "...";
                //btnCTiet.Buttons[0].Image = ;//Global.Commons.My.Resources.Resources.attachment
                grvTSDinhTinh.Columns["CT_CVIEC"].ColumnEdit = btnCTiet;
                grvTSDinhTinh.Columns["CT_CVIEC"].Visible = true;
                grvTSDinhTinh.Columns["TG_TT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grvTSDinhTinh.Columns["TG_TT"].SummaryItem.DisplayFormat = "Sum = {0:n0}";

                grvTSDinhTinh.Columns["TG_XU_LY"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grvTSDinhTinh.Columns["TG_XU_LY"].SummaryItem.DisplayFormat = "Sum = {0:n0}";

                try
                {
                    btnCTiet.Click += new System.EventHandler(this.btnCTiet_Click);
                }
                   

                catch { }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        public void loaddanhsachDL(int STT)
        {
            if (tabThongSo.SelectedTabPageIndex != 1) return;
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                //int n = int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("STT").ToString());
                //if (int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("STT").ToString()) == Convert.ToInt16(txtsttGSTT.EditValue) && !btnGhi.Visible) return;
            }
            catch { }
            DataTable dt = new DataTable();
            try
            {
                grdTSDinhLuong.DataSource = null;
                if (btnGhi.Visible)
                {
                    //load theo bang tao
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_DSGiamSatTinhTrangDinhLuongByBT", sBTamGiaTriDL, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    //dt.Columns["GIA_TRI_DO"].ReadOnly = false;
                    //dt.Columns["TG_TT"].ReadOnly = false;
                    if (txtsttGSTT.Text.ToString() != "-1")
                    {
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdTSDinhLuong, grvTSDinhLuong, dt, true, true, true, true, true, this.Name);
                        grvTSDinhLuong.Columns["GIA_TRI_DO"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
                        grvTSDinhLuong.Columns["GIA_TRI_DO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        grvTSDinhLuong.Columns["TG_TT"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
                        grvTSDinhLuong.Columns["TG_TT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        for (int i = 0; i < 11; i++)
                        {
                            if (i == 6 || i == 10)
                            {
                                dt.Columns[i].ReadOnly = false;
                            }
                            else
                            {
                                dt.Columns[i].ReadOnly = true;
                            }
                        }
                    }
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdTSDinhLuong, grvTSDinhLuong, dt, false, true, true, true, true, this.Name);

                }
                else
                {
                    //load theo he thong
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_DanhSachGiamSatTinhTrangDinhLuong", STT, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdTSDinhLuong, grvTSDinhLuong, dt, false, true, true, true, true, this.Name);
                }

                grvTSDinhLuong.Columns["MS_TS_GSTT"].Visible = false;
                //grvTSDinhLuong.Columns["STT_CTTB"].Visible = false;
                grvTSDinhLuong.Columns["MS_TT"].Visible = false;
                //grvTSDinhLuong.Columns["STT"].Visible = false;
                //grvTSDinhLuong.Columns["DAT"].Visible = false;

                RepositoryItemButtonEdit btnCTietDL = new RepositoryItemButtonEdit();
                btnCTietDL.TextEditStyle = TextEditStyles.HideTextEditor;
                btnCTietDL.Buttons[0].Kind = ButtonPredefines.Glyph;
                btnCTietDL.Buttons[0].Caption = "...";
                //btnCTiet.Buttons[0].Image = ;//Global.Commons.My.Resources.Resources.attachment
                grvTSDinhLuong.Columns["CT_CVIEC"].ColumnEdit = btnCTietDL;
                grvTSDinhLuong.Columns["CT_CVIEC"].Visible = true;
                grvTSDinhLuong.Columns["CT_CVIEC"].Width = 25;
                
                try
                {
                    grvTSDinhLuong.Columns["TG_TT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    grvTSDinhLuong.Columns["TG_TT"].SummaryItem.DisplayFormat = "Sum = {0:n0}";
                    grvTSDinhLuong.Columns["THOI_GIAN"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    grvTSDinhLuong.Columns["THOI_GIAN"].SummaryItem.DisplayFormat = "Sum = {0:n0}";
                    btnCTietDL.ButtonClick += BtnCTietDL_ButtonClick;
                }
                catch { }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void BtnCTietDL_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (txtsttGSTT.EditValue.ToString() == "-1") return;
            //MessageBox.Show(grvTSDinhTinh.FocusedColumn.Name.ToString());
            //if (grvTSDinhTinh.FocusedColumn.Name.ToString() != "colCT_CVIEC") return;
            TaoDanhListDanhSachCV();
        }

        public void kiemtraload()
        {
            switch (tabChung.SelectedTabPageIndex)
            {
                case 0:
                    {
                    }
                    break;
                case 1:
                    {

                        Commons.Modules.SQLString = "0Load";
                        loadmay(Convert.ToInt16(txtsttGSTT.EditValue));
                        Commons.Modules.SQLString = "";
                        if (tabThongSo.SelectedTabPageIndex == 0)
                        {
                            if (grvDSLGS.RowCount == 0 || grdDSLGS.DataSource == null)
                                loaddanhsachDT(-1);
                            else
                                loaddanhsachDT(Convert.ToInt16(txtsttGSTT.EditValue));
                        }
                        else
                        {
                            if (grvDSLGS.RowCount == 0 || grdDSLGS.DataSource == null)
                                loaddanhsachDL(-1);
                            else
                                loaddanhsachDL(Convert.ToInt16(txtsttGSTT.EditValue));
                        }

                        LoadCTDTDL();
                        CreateMenuGSTT(grdTSDinhTinh, grdTSDinhLuong);
                    }
                    break;
            }
        }
        //load chi báo cáo chi tiết
        public void loadCboDD()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDiadiem, Commons.Modules.ObjSystems.MLoadDataNhaXuong(1), "MS_N_XUONG", "TEN_N_XUONG", "");
        }
        public void loadCboDayChuyen()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDayChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", "");
        }
        public void loadCboCongViec()
        {
            DataTable dtTmp = new DataTable();
            string sSql = " SELECT T1.MS_LOAI_CV,T1.TEN_LOAI_CV FROM LOAI_CONG_VIEC T1 INNER JOIN NHOM_LOAI_CONG_VIEC T2 ON  T1.MS_LOAI_CV = T2.MS_LOAI_CV INNER JOIN USERS T3 ON T2.GROUP_ID = T3.GROUP_ID  WHERE USERNAME = 'admin'  UNION SELECT -1, ' < ALL > '  UNION SELECT -99, N'.Chưa phân loại'  ORDER BY TEN_LOAI_CV";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiCongViec, dtTmp, "MS_LOAI_CV", "TEN_LOAI_CV", "");
        }
        public void loadCboLoaiMay()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaithietbi, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
        }

        public void loadgrdBC()
        {
            if (Commons.Modules.SQLString == "0LoadBC") return;
            if (string.IsNullOrEmpty(cboLoaiCongViec.EditValue.ToString())) return;
            if (string.IsNullOrEmpty(cboDiadiem.EditValue.ToString())) return;
            if (string.IsNullOrEmpty(cboDayChuyen.EditValue.ToString())) return;
            if (string.IsNullOrEmpty(cboLoaiCongViec.EditValue.ToString())) return;
            grdBC.DataSource = null;
            DataTable tb = new DataTable();
            tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spBCGiamSatTinhTrangCT", dtTuNgayBC.DateTime.Date, dtDenngayBC.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage, cboLoaiCongViec.EditValue, cboDiadiem.EditValue, cboDayChuyen.EditValue, cboLoaithietbi.EditValue));

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, tb, false, true, true, true, true, this.Name);
            grvBC.Columns["MS_TS_GSTT"].Visible = false;
            //grvBC.Columns["DAT"].Width = 60;
            //grvBC.Columns["THOI_GIAN"].Width = 70;
            //grvBC.Columns["TG_TT"].Width = 70;
        }
        private void loadNgayBC()
        {
            dtTuNgayBC.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);//DateTime.Now.Year);
            dtDenngayBC.DateTime = dtTuNgayBC.DateTime.AddMonths(1).AddDays(-1);
        }
        private void tabChung_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabChung.SelectedTabPageIndex == 1 && grvDSLGS.RowCount == 0) return;
            if (btnGhi.Visible)
            {
                tabChung.SelectedTabPageIndex = 1; return;
            }
            kiemtraload();
            if (tabChung.SelectedTabPageIndex == 2)
            {
                BtnInCT.Visible = true;
                btnThem.Visible = false;
                btnXoa.Visible = false;
                btnSua.Visible = false;
                //kiểm tra dữ liệu nếu null thì không cho load
                if (grdBC.DataSource != null) return;
                Commons.Modules.SQLString = "0LoadBC";
                loadCboCongViec();
                loadCboDayChuyen();
                loadCboDD();
                loadCboLoaiMay();
                loadNgayBC();
                Commons.Modules.SQLString = "";
                loadgrdBC();

            }
            else
            {
                BtnInCT.Visible = false;
                btnThem.Visible = true;
                btnXoa.Visible = true;
                btnSua.Visible = true;
            }
        }
        #region tìm kiếm trực tiếp trên datasoucre
        private void TKBaoCao()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                dtTmp = (DataTable)grdBC.DataSource;

                if (optChonDat.SelectedIndex == 1) sdkien = "(DAT = 1)";
                if (optChonDat.SelectedIndex == 2) sdkien = "(DAT = 0)";

                if (txtTimKiem.Text.Length != 0) sdkien = " ( " + " HO_TEN LIKE '%" + txtTimKiem.Text + "%' OR MS_BO_PHAN LIKE '%" + txtTimKiem.Text + "%' OR MS_MAY LIKE '%" +
                    txtTimKiem.Text + "%' OR TEN_BO_PHAN LIKE '%" +
                    txtTimKiem.Text + "%' OR Ten_May LIKE '%" + txtTimKiem.Text + "%' ) ";
                dtTmp.DefaultView.RowFilter = sdkien;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }
        private void TKtab1()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                dtTmp = (DataTable)grdDSLGS.DataSource;

                if (optHThanh.SelectedIndex == 1) sdkien = "(HOAN_THANH = 0)";
                if (optHThanh.SelectedIndex == 2) sdkien = "(HOAN_THANH = 1)";

                if (txtTimKiem.Text.Length != 0) sdkien = " ( " + " SO_PHIEU LIKE '%" + txtTimKiem.Text + "%' OR TEN_CN LIKE '%" + txtTimKiem.Text + "%' OR MS_MAY LIKE '%" +
                    txtTimKiem.Text + "%' OR MS_CONG_NHAN LIKE '%" +
                    txtTimKiem.Text + "%' OR Ten_May LIKE '%" + txtTimKiem.Text + "%' ) ";
                dtTmp.DefaultView.RowFilter = sdkien;
                LoadText(false);
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }
        private void TKtabTSDT()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                dtTmp = (DataTable)grdTSDinhTinh.DataSource;
                if (optGDat.SelectedIndex == 1) sdkien = " (DAT = 1) ";
                if (optGDat.SelectedIndex == 2) sdkien = " (DAT = 0) ";

                if (cbbThietBi.EditValue != "-1") sdkien = sdkien + " AND (MS_MAY = '" + cbbThietBi.EditValue + "')";


                if (txtTimKiem.Text.Length != 0) sdkien = sdkien + "AND (" + " MS_MAY LIKE '%" + txtTimKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTimKiem.Text + "%' OR MS_MAY LIKE '%" +
                  txtTimKiem.Text + "%' OR MS_BO_PHAN LIKE '%" +
                  txtTimKiem.Text + "%' OR TEN_BO_PHAN LIKE '%" + txtTimKiem.Text + "%') ";
                dtTmp.DefaultView.RowFilter = sdkien;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }
        private void TKtabTSDL()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                dtTmp = (DataTable)grdTSDinhLuong.DataSource;
                if (optGDat.SelectedIndex == 1) sdkien = " (DAT = 1) ";
                if (optGDat.SelectedIndex == 2) sdkien = " (DAT = 0) ";
                if (cbbThietBi.EditValue != "-1") sdkien = sdkien + "AND (MS_MAY ='" + cbbThietBi.EditValue + "')";
                if (txtTimKiem.Text.Length != 0) sdkien = sdkien + " AND( " + " MS_MAY LIKE '%" + txtTimKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTimKiem.Text + "%' OR MS_MAY LIKE '%" +
                  txtTimKiem.Text + "%' OR MS_BO_PHAN LIKE '%" +
                  txtTimKiem.Text + "%' OR TEN_BO_PHAN LIKE '%" + txtTimKiem.Text + "%')";
                dtTmp.DefaultView.RowFilter = sdkien;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }

        private void txtTimKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (tabChung.SelectedTabPageIndex == 0) TKtab1();
            else
            {
                if (tabChung.SelectedTabPageIndex == 2)
                {
                    TKBaoCao();
                }
                else
                {
                    if (tabThongSo.SelectedTabPageIndex == 0) TKtabTSDT();
                    else
                        TKtabTSDL();
                }
            }
            loaddanhsachthongso(Convert.ToInt32(txtsttGSTT.EditValue));
        }
        #endregion

        private void datTNgayKT_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(datTNgayKT.Text))
            {
                datTNgayKT.EditValue = DateTime.Now;
            }
            try
            {
                if (!btnGhi.Visible) return;
                if (txtSoPhieu.Text.Substring(3, 6) == datNgayKT.DateTime.Date.ToString("yyyyMM")) return;
                txtSoPhieu.Text = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "select dbo.AUTO_CREATE_SO_PHIEU_GSTT('" + datTNgayKT.DateTime.Date.ToString("MM/dd/yyyy") + "')"));
            }
            catch { }
        }

        //load text
        private void grvDSLGS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadText(false);
        }

        //chuyển task
        private void grvDSLGS_DoubleClick(object sender, EventArgs e)
        {
            tabChung.SelectedTabPageIndex = 1;
        }


        public void loaddanhsachthongso(int stt)
        {
            if (Commons.Modules.SQLString == "0Load1") return;
            int msthongso; int loaits; string msmay; string msbp;

            try
            {
                msthongso = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TS_GSTT").ToString()));
            }
            catch { msthongso = -1; }

            try
            {
                loaits = (tabThongSo.SelectedTabPageIndex == 0 ? 1 : 0);
            }
            catch { loaits = -1; }
            try
            {
                msmay = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_MAY").ToString());
            }
            catch { msmay = "-1"; }

            try
            {
                msbp = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_BO_PHAN").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_BO_PHAN").ToString());
            }
            catch { msbp = "-1"; }
            DataTable dt = new DataTable();
            try
            {
                grdDSGiaTri.DataSource = null;
                //load theo bản tạm
                if (tabThongSo.SelectedTabPageIndex == 0)
                {
                    if (btnGhi.Visible)
                    {
                        //load bang tam dinh tinh
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spDanhSachGiaTriBT", stt, msthongso, 1/*1 dịnh tính*/, msmay, msbp, sBTamGiaTri, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                        dt.Columns["GHI_CHU"].ReadOnly = false;
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSGiaTri, grvDSGiaTri, dt, true, true, true, true, true, this.Name);
                        grvDSGiaTri.Columns["STT"].Visible = false;
                        dt.Columns[0].ReadOnly = true;
                    }
                    else
                    {
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_GetDanhSachGiaTri", stt, msthongso, loaits, msmay, msbp, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSGiaTri, grvDSGiaTri, dt, false, true, true, true, true, this.Name);
                        grvDSGiaTri.Columns["STT_GT"].Visible = false;
                    }
                }


                //    //load bang tam dinh luong
                //    string sSql = "SELECT TEN_GT,GIA_TRI_DUOI, GIA_TRI_TREN FROM "+ sBTamGiaTriDL + " WHERE MS_MAY='" + msmay + "' AND MS_TS_GSTT ='" + msthongso + "' AND MS_BO_PHAN ='" + msbp + "'";

                //    DataTable dtTmp = new DataTable();
                //    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                //    grdDSGiaTri.DataSource = null;
                //    Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSGiaTri, grvDSGiaTri, dtTmp, false, true, true, true, true, this.Name);
                //    grvDSGiaTri.Columns["GIA_TRI_DUOI"].Width = 50;
                //    grvDSGiaTri.Columns["GIA_TRI_TREN"].Width = 50;
                else
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_GetDanhSachGiaTri", stt, msthongso, loaits, msmay, msbp, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSGiaTri, grvDSGiaTri, dt, false, true, true, true, true, this.Name);
                    if (loaits == 0)
                    {
                        grvDSGiaTri.Columns["GIA_TRI_DUOI"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
                        grvDSGiaTri.Columns["GIA_TRI_DUOI"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        grvDSGiaTri.Columns["GIA_TRI_TREN"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
                        grvDSGiaTri.Columns["GIA_TRI_TREN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    }
                    else
                    {
                        grvDSGiaTri.Columns["STT_GT"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        public void loadhinh(int n)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "0Load1") return;
            int msthongso; string msmay; string msbp;
            try
            {
                msthongso = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TS_GSTT").ToString()));
            }
            catch { msthongso = -1; }
            try
            {
                msmay = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_MAY").ToString());
            }
            catch { msmay = "-1"; }
            try
            {
                msbp = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_BO_PHAN").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_BO_PHAN").ToString());
            }
            catch { msbp = "-1"; }
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_DanhSachHinh", Convert.ToInt16(txtsttGSTT.EditValue), msthongso, msmay, msbp, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                dt.Columns["GHI_CHU"].ReadOnly = false;
                grdDSHinh.DataSource = null;
                if (btnGhi.Visible)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHinh, grvDSHinh, dt, false, true, true, true, true, this.Name);
                    grvDSHinh.OptionsBehavior.Editable = false;
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHinh, grvDSHinh, dt, true, true, true, true, true, this.Name);
                    dt.Columns[0].ReadOnly = true;
                }
                grvDSHinh.Columns["DUONG_DAN"].Width = 150;
                grvDSHinh.Columns["STT_HINH"].Visible = false;

                try
                {
                    RepositoryItemButtonEdit btnMoFile = new RepositoryItemButtonEdit();

                    btnMoFile.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis;
                    btnMoFile.Buttons[0].Caption = "...";

                    try
                    {
                        btnMoFile.ButtonClick += RiButton_ButtonClick;
                    }
                    catch { }
                    grvDSHinh.Columns["DUONG_DAN"].ColumnEdit = btnMoFile;
                }
                catch { }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void RiButton_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //mo file
            try
            {
                System.Diagnostics.Process.Start(grvDSHinh.GetFocusedRowCellValue("DUONG_DAN").ToString());
            }
            catch
            {
                //'File đã bị thay đổi đường dẫn, hay không xem được định dạng file này trên máy người dùng! Vui lòng kiểm tra lại
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Commons.Modules.UserName,
                                    "MsgKiemtra9", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void tabThongSo_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            loadmay(Convert.ToInt16(txtsttGSTT.Text.ToString()));
            kiemtraload();
            if (!btnGhi.Visible)
            {
                if (tabThongSo.SelectedTabPageIndex == 0)
                    optGDat.Enabled = true;
                else
                    optGDat.Enabled = false;
            }
            else
            {
                if (tabThongSo.SelectedTabPageIndex == 0)
                {
                    optGDat.Enabled = true;
                    BtnChonTSDT.Visible = true;
                    BtnChonTSDL.Visible = false;
                }
                else
                {
                    optGDat.Enabled = false;
                    BtnChonTSDT.Visible = false;
                    BtnChonTSDL.Visible = true;
                }
            }
        }

        private void LoadCTDTDL()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            loaddanhsachthongso(Convert.ToInt16(txtsttGSTT.EditValue));
            loadhinh(Convert.ToInt16(txtsttGSTT.EditValue));
            optGDat_EditValueChanged(null, null);
        }

        private void optGDat_EditValueChanged(object sender, EventArgs e)
        {
            txtTimKiem_EditValueChanging(null, null);
        }

        private void cbbThietBi_EditValueChanged(object sender, EventArgs e)
        {
            txtTimKiem_EditValueChanging(null, null);
        }

        private void optHThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTimKiem_EditValueChanging(null, null);
        }

        private void grdDSHinh_DoubleClick(object sender, EventArgs e)
        {
            if (tabThongSo.SelectedTabPageIndex == 0)
            {
                if (grvTSDinhTinh.DataRowCount == 0)
                { return; }
            }
            else
            {
                if (grvTSDinhLuong.DataRowCount == 0)
                { return; }
            }
            LuuHinh();
            LoadCTDTDL();
        }

        public void Addhinh(int stt, string duongdan)
        {

            int mstt; int sttgs; string msmay; string msbp; string ghichu = "";

            try
            {
                mstt = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TT").ToString()));
            }
            catch { return; }
            try
            {
                sttgs = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TS_GSTT").ToString()));
            }
            catch { return; }

            try
            {
                msmay = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_MAY").ToString());
            }
            catch { return; }

            try
            {
                msbp = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_BO_PHAN").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_BO_PHAN").ToString());
            }
            catch { return; }

            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddGIAM_SAT_TINH_TRANG_HINH", stt, msmay, sttgs, msbp, mstt, duongdan, ghichu);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void LuuHinh()
        {
            if (btnGhi.Visible) return;
            OpenFileDialog ofdHinh = new OpenFileDialog();
            System.Drawing.Imaging.ImageCodecInfo[] codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            //ofdHinh.Filter = string.Format("{0}| All image files ({1})|{1}|All files|*",
            //    string.Join("|", codecs.Select(codec =>
            //    string.Format("{0} ({1})|{1}", codec.CodecName, codec.FilenameExtension)).ToArray()),
            //    string.Join(";", codecs.Select(codec => codec.FilenameExtension).ToArray()));
            ofdHinh.Filter = "All Files|*.*";

            //ofdHinh.
            ofdHinh.Multiselect = true;
            if (ofdHinh.ShowDialog() != DialogResult.OK) return;
            List<string> listhinh = ofdHinh.FileNames.ToList();
            string msmay = "";
            string sServer = "";
            string sPathMoi = "";
            try
            {
                msmay = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_MAY").ToString());
            }
            catch { msmay = "-1"; }

            int iSTTHinh = 1;
            try
            {
                iSTTHinh = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT ISNULL(MAX(STT_HINH),0) AS STT_HINH FROM dbo.GIAM_SAT_TINH_TRANG_HINH WHERE MS_MAY = '" + msmay + "' ").ToString()) + 1;
            }
            catch { }
            sServer = Commons.Modules.ObjSystems.CapnhatTL(false, msmay);
            foreach (var item in listhinh)
            {
                sPathMoi = sServer + @"\" + "GSTT" + "_" + msmay + "_" + DateTime.Now.Date.ToString("yyyyMMdd") + "_" + iSTTHinh + Commons.Modules.ObjSystems.LayDuoiFile(item);
                Addhinh(Convert.ToInt16(Convert.ToInt16(txtsttGSTT.EditValue)), sPathMoi);
                Commons.Modules.ObjSystems.LuuDuongDan(item, sPathMoi);
                iSTTHinh++;
            }
        }
        public bool deleteHinh()
        {
            if (grvDSHinh.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoa1", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return false;
            try
            {
                int msthongso; string msmay; string msbp; int sttHinh; int msTT; string sDDan;
                try
                {
                    msTT = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TT").ToString()));
                }
                catch { msTT = -1; }
                try
                {
                    msthongso = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TS_GSTT").ToString()));
                }
                catch { msthongso = -1; }

                try
                {
                    msmay = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_MAY").ToString());
                }
                catch { msmay = "-1"; }


                try
                {
                    msbp = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_BO_PHAN").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_BO_PHAN").ToString());
                }
                catch { msbp = "-1"; }
                try
                {
                    sttHinh = int.Parse(grvDSHinh.GetFocusedRowCellValue("STT_HINH").ToString());
                }
                catch { sttHinh = -1; }
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "DeleteGIAM_SAT_TINH_TRANG_HINH", Convert.ToInt16(txtsttGSTT.EditValue), msmay, msthongso, msbp, sttHinh, msTT);
                try
                {
                    sDDan = grvDSHinh.GetFocusedRowCellValue("DUONG_DAN").ToString();
                }
                catch { sDDan = "-1"; }
                try
                {
                    Commons.Modules.ObjSystems.Xoahinh(sDDan);
                }
                catch { }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void grdDSHinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Delete) return;
            if (!btnGhi.Visible)
                if (!deleteHinh()) return;

            var grid = sender as DevExpress.XtraGrid.GridControl;
            var view = grid.FocusedView as GridView;
            view.DeleteSelectedRows();
            e.Handled = true;
            ((DataTable)grdDSHinh.DataSource).AcceptChanges();
        }
        //tao bang tam dinh tinh
        private Boolean TaoBangTam()
        {
            try
            {
                Commons.Modules.ObjSystems.XoaTable(sBTamGiaTri);
                string sSql = "SELECT TOP 0 CONVERT(BIT,0) AS CHON,TEN_GIA_TRI,T1.DAT,T1.GHI_CHU, STT,T2.MS_MAY,T1.MS_TS_GSTT,T2.MS_BO_PHAN,T2.MS_TT, T2.THOI_GIAN,T2.THOI_GIAN AS TG_TT INTO " + sBTamGiaTri + " FROM dbo.GIA_TRI_TS_GSTT T1, dbo.CAU_TRUC_THIET_BI_TS_GSTT T2 ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        //tao bang tam dinh luong
        private Boolean TaoBangTamDL()
        {
            try
            {
                Commons.Modules.ObjSystems.XoaTable(sBTamGiaTriDL);
                //string sSql = "SELECT TOP 0 T1.MS_MAY,T1.MS_TS_GSTT,T1.MS_BO_PHAN,T1.MS_TT,T1.THOI_GIAN,T1.THOI_GIAN AS TG_TT,T1.GIA_TRI_DO ,T2.TEN_GT, T2.GIA_TRI_TREN,T2.GIA_TRI_DUOI                 INTO " + sBTamGiaTriDL + " FROM dbo.GIAM_SAT_TINH_TRANG_TS T1, dbo.CAU_TRUC_THIET_BI_TS_GSTT T2 ";

                string sSql = "SELECT TOP 0 T1.MS_MAY,T1.MS_TS_GSTT,T1.MS_BO_PHAN,T1.MS_TT,T1.THOI_GIAN,T1.THOI_GIAN AS TG_TT,T1.GIA_TRI_DO INTO " + sBTamGiaTriDL + " FROM dbo.GIAM_SAT_TINH_TRANG_TS T1";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        private void InsertVaoDuLieuBangTamDL()
        {
            string sSQL = "INSERT INTO  " + sBTamGiaTriDL + " SELECT DISTINCT T2.MS_MAY,T1.MS_TS_GSTT,T2.MS_BO_PHAN,0 AS MS_TT,T1.THOI_GIAN,T1.THOI_GIAN AS TG_TT, NULL AS GIA_TRI_DO FROM dbo.THONG_SO_GSTT AS T1 INNER JOIN dbo.CAU_TRUC_THIET_BI_TS_GSTT AS T2 ON T1.MS_TS_GSTT = T2.MS_TS_GSTT INNER JOIN dbo.CAU_TRUC_THIET_BI AS T3 ON T2.MS_MAY = T3.MS_MAY INNER JOIN dbo.DON_VI_DO AS T4 ON T1.MS_DV_DO = T4.MS_DV_DO WHERE(ISNULL(T2.ACTIVE, 0) = 1) AND NOT EXISTS( SELECT * FROM   "+sBTamGiaTriDL+" B WHERE B.MS_MAY = T2.MS_MAY AND B.MS_BO_PHAN = T2.MS_BO_PHAN AND B.MS_TS_GSTT  = T1.MS_TS_GSTT)";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSQL);
        }

        //cap nhat thoi gian thuc te

        private void CapNhatThoiGianThucTe()
        {
            int msthongso; string msmay; string msbp; float thoigiantt; int mstt;

            try
            {
                msthongso = int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString());
            }
            catch { msthongso = -1; }

            try
            {
                msmay = grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString();
            }
            catch { msmay = "-1"; }

            try
            {
                msbp = grvTSDinhTinh.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
            }
            catch { msbp = "-1"; }
            try
            {
                thoigiantt = float.Parse(grvTSDinhTinh.GetFocusedRowCellValue("TG_TT").ToString());

            }
            catch { thoigiantt = -1; }
            try
            {
                mstt = int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TT").ToString());
            }
            catch { mstt = -1; }

            string query = "UPDATE " + sBTamGiaTri + " SET TG_TT = " + Math.Round(thoigiantt, 2) + " WHERE MS_MAY ='" + msmay + "' AND MS_TS_GSTT =" + msthongso + " AND MS_BO_PHAN ='" + msbp + "' AND MS_TT = " + mstt + "";
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, query);
            }
            catch { }
        }
        private void grvTSDinhTinh_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            CapNhatThoiGianThucTe();
        }
        private void grvDSGiaTri_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            int msthongso; string msmay; string msbp; string ghichu; int mstt; int sttgiatri;
            try
            {
                msthongso = int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString());
            }
            catch { msthongso = -1; }

            try
            {
                msmay = grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString();
            }
            catch { msmay = "-1"; }

            try
            {
                msbp = grvTSDinhTinh.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
            }
            catch { msbp = "-1"; }
            try
            {
                ghichu = grvDSGiaTri.GetFocusedRowCellValue("GHI_CHU").ToString();
            }
            catch { ghichu = "-1"; }
            try
            {
                mstt = int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TT").ToString());
            }
            catch { mstt = -1; }

            try
            {
                sttgiatri = int.Parse(grvDSGiaTri.GetFocusedRowCellValue("STT").ToString());
            }
            catch { sttgiatri = -1; }
            string query = "UPDATE " + sBTamGiaTri + " SET GHI_CHU = N'" + ghichu + "' WHERE MS_MAY ='" + msmay + "' AND MS_TS_GSTT =" + msthongso + " AND MS_BO_PHAN ='" + msbp + "' AND MS_TT = " + mstt + "AND STT = " + sttgiatri;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, query);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }

        private void grvDSHinh_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            int msthongso; string msmay; string msbp; string ghichu; int mstt; int stthinh;
            try
            {
                mstt = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TT").ToString()));
            }
            catch { return; }
            try
            {
                msthongso = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TS_GSTT").ToString()));
            }
            catch { return; }

            try
            {
                msmay = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_MAY").ToString());
            }
            catch { return; }

            try
            {
                msbp = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_BO_PHAN").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_BO_PHAN").ToString());
            }
            catch { return; }

            try
            {
                ghichu = grvDSHinh.GetFocusedRowCellValue("GHI_CHU").ToString();
            }
            catch { ghichu = "-1"; }
            //try
            //{
            //    msthongso = int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString());
            //}
            //catch { msthongso = -1; }

            try
            {
                stthinh = int.Parse(grvDSHinh.GetFocusedRowCellValue("STT_HINH").ToString());
            }
            catch { stthinh = -1; }

            //try
            //{
            //    msmay = grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString();
            //}
            //catch { msmay = "-1"; }

            //try
            //{
            //    msbp = grvTSDinhTinh.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
            //}
            //catch { msbp = "-1"; }

            //try
            //{
            //    mstt = int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TT").ToString());
            //}
            //catch { mstt = -1; }
            string query = "UPDATE dbo.GIAM_SAT_TINH_TRANG_HINH SET GHI_CHU =N'" + ghichu + "' WHERE STT =" + Convert.ToInt16(txtsttGSTT.EditValue) + " AND MS_MAY='" + msmay + "' AND MS_TS_GSTT='" + msthongso + "' AND MS_BO_PHAN ='" + msbp + "' AND MS_TT =" + mstt + " AND STT_HINH = " + stthinh;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, query);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }


        List<clsTinhTrangThietBi> listcongviec = new List<clsTinhTrangThietBi>();

        private void LuuListCongViec(int iSTTGS)
        {
            string sServer, sPathMoi;
            foreach (clsTinhTrangThietBi item in listcongviec)
            {
                try
                {
                    sServer = Commons.Modules.ObjSystems.CapnhatTL(true, "GSTT_TSDT");
                    if (item.sTaiLieu.ToString() != "")
                    {
                        sPathMoi = sServer + @"\" + "GSTT_TSDT" + "_" + "GSTT_TSDT" + "_" + item.msmay + "_" + item.msbp + "_" + item.msthongso + "_" + Commons.Modules.ObjSystems.LayDuoiFile(item.sTaiLieu);
                    }
                    else { sPathMoi = ""; }
                    string sSql = "UPDATE dbo.GIAM_SAT_TINH_TRANG_TS SET CACH_THUC_HIEN =N'" + item.sThaoTac + "', TIEU_CHUAN_KT =N'" + item.sTieuChuan + "',YEU_CAU_NS =N'" + item.sYeuCauNS + "',YEU_CAU_DUNG_CU =N'" + item.sYeuCauDC + "', PATH_HD=N'" + sPathMoi + "'WHERE STT =" + iSTTGS + " AND MS_MAY = '" + item.msmay + "' AND MS_TS_GSTT = '" + item.msthongso + "' AND MS_BO_PHAN = '" + item.msbp + "' AND MS_TT = " + item.mstt + "";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                    Commons.Modules.ObjSystems.LuuDuongDan(item.sTaiLieu, sPathMoi);
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }
            //xoa du lieu khoa list
            listcongviec.Clear();
        }
        private void grvTSDinhTinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadCTDTDL();
        }

        private void TaoDanhListDanhSachCV()
        {
            int msthongso; string msmay; string msbp; int mstt; string stents;
            try
            {
                msthongso = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TS_GSTT").ToString()));

                //msthongso = (tabThongSo.SelectedTabPageIndex == 0 ? int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TS_GSTT").ToString()) : int.Parse(grvTSDinhLuong.GetFocusedRowCellValue("MS_TS_GSTT").ToString()));
            }
            catch { msthongso = -1; }
            try
            {
                msmay = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_MAY").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_MAY").ToString());
            }
            catch { msmay = "-1"; }

            try
            {
                msbp = (tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("MS_BO_PHAN").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("MS_BO_PHAN").ToString());
            }
            catch { msbp = "-1"; }

            try
            {
                string sSqll = "SELECT TOP 1 MS_TT FROM dbo.GIAM_SAT_TINH_TRANG_TS WHERE STT =" + Convert.ToUInt16(txtsttGSTT.EditValue) + " AND MS_MAY = '" + msmay + "' AND MS_BO_PHAN ='" + msbp + "' AND MS_TS_GSTT ='" + msthongso + "'";
                int ns;
                ns = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSqll));

                mstt = tabThongSo.SelectedTabPageIndex == 0 ? Convert.ToInt16(grvTSDinhTinh.GetFocusedRowCellValue("MS_TT").ToString()) : ns;
                //mstt = int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TT").ToString());
            }
            catch { mstt = -1; }

            try
            {
                stents = tabThongSo.SelectedTabPageIndex == 0 ? grvTSDinhTinh.GetFocusedRowCellValue("TEN_TS_GSTT").ToString() : grvTSDinhLuong.GetFocusedRowCellValue("TEN_TS_GSTT").ToString();
                //mstt = int.Parse(grvTSDinhTinh.GetFocusedRowCellValue("MS_TT").ToString());
            }
            catch { stents = "-1"; }

            //lay danh sach tiet cong viec
            string sSql = "IF((SELECT COUNT (*)FROM dbo.GIAM_SAT_TINH_TRANG_TS WHERE STT = " + Convert.ToInt16(txtsttGSTT.EditValue) + " AND MS_MAY ='" + msmay + "' AND MS_TS_GSTT ='" + msthongso + "' AND MS_BO_PHAN ='" + msbp + "' AND MS_TT= " + mstt + " AND (CACH_THUC_HIEN IS NOT NULL or TIEU_CHUAN_KT IS NOT NULL or YEU_CAU_NS IS NOT NULL or YEU_CAU_DUNG_CU IS NOT NULL or PATH_HD IS NOT NULL)) =1) SELECT CACH_THUC_HIEN, TIEU_CHUAN_KT, YEU_CAU_NS, YEU_CAU_DUNG_CU, PATH_HD FROM dbo.GIAM_SAT_TINH_TRANG_TS WHERE STT = " + Convert.ToInt16(txtsttGSTT.EditValue) + " AND MS_MAY = '" + msmay + "' AND MS_TS_GSTT ='" + msthongso + "' AND MS_BO_PHAN = '" + msbp + "' AND MS_TT = " + mstt + " ELSE SELECT CACH_THUC_HIEN,TIEU_CHUAN_KT,YEU_CAU_NS,YEU_CAU_DUNG_CU,PATH_HD FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE  MS_MAY = '" + msmay + "' AND MS_TS_GSTT ='" + msthongso + "' AND MS_BO_PHAN = '" + msbp + "' AND MS_TT = " + mstt + "";
            //sua
            
            int n = listcongviec.Count(x => x.msmay.Equals(msmay) && x.msthongso.Equals(msthongso) && x.msbp.Equals(msbp) && x.mstt.Equals(mstt));
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));

            frmChiTietCongViec congviec = new frmChiTietCongViec();
            //congviec.sTenCV = row["sTenCV"].ToString();
            if (txtsttGSTT.Text == "-1")
            {
                if (n == 0)
                {
                    congviec.sTenCV = stents;
                    congviec.sThaoTac = "";
                    congviec.sTieuChuan = "";
                    congviec.sYeuCauDC = "";
                    congviec.sYeuCauNS = "";
                    congviec.sTaiLieu = "";
                    congviec.bView = !btnGhi.Visible;
                }
                if (n != 0)
                {
                    clsTinhTrangThietBi cv = listcongviec.Where(x => x.msmay.Equals(msmay) && x.msthongso.Equals(msthongso) && x.msbp.Equals(msbp) && x.mstt.Equals(mstt)).FirstOrDefault();
                    congviec.sTenCV = stents;
                    congviec.sThaoTac = cv.sThaoTac;
                    congviec.sTieuChuan = cv.sTieuChuan;
                    congviec.sYeuCauDC = cv.sYeuCauDC;
                    congviec.sYeuCauNS = cv.sYeuCauNS;
                    congviec.sTaiLieu = cv.sTaiLieu;
                    congviec.bView = !btnGhi.Visible;
                }
            }
            else
            {
                if (btnGhi.Visible)
                {
                    if (n == 0)
                    {
                        try
                        {
                            DataRow row = dt.Rows[0];
                            congviec.sTenCV = stents;
                            congviec.sThaoTac = row["CACH_THUC_HIEN"].ToString();
                            congviec.sTieuChuan = row["TIEU_CHUAN_KT"].ToString();
                            congviec.sYeuCauDC = row["YEU_CAU_DUNG_CU"].ToString();
                            congviec.sYeuCauNS = row["YEU_CAU_NS"].ToString();
                            congviec.sTaiLieu = row["PATH_HD"].ToString();
                            congviec.bView = !btnGhi.Visible;
                        }
                        catch (Exception ex)
                        {
                            congviec.sTenCV = stents;
                            congviec.sThaoTac = "";
                            congviec.sTieuChuan = "";
                            congviec.sYeuCauDC = "";
                            congviec.sYeuCauNS = "";
                            congviec.sTaiLieu = "";
                            congviec.bView = !btnGhi.Visible;
                        }

                    }
                    else
                    {
                        clsTinhTrangThietBi cv = listcongviec.Where(x => x.msmay.Equals(msmay) && x.msthongso.Equals(msthongso) && x.msbp.Equals(msbp) && x.mstt.Equals(mstt)).FirstOrDefault();
                        congviec.sTenCV = stents;
                        congviec.sThaoTac = cv.sThaoTac;
                        congviec.sTieuChuan = cv.sTieuChuan;
                        congviec.sYeuCauDC = cv.sYeuCauDC;
                        congviec.sYeuCauNS = cv.sYeuCauNS;
                        congviec.sTaiLieu = cv.sTaiLieu;
                        congviec.bView = !btnGhi.Visible;
                    }
                }
                else
                {
                    DataRow row = dt.Rows[0];
                    congviec.sTenCV = stents;
                    congviec.iSTTGS = Convert.ToInt16(grvDSLGS.GetFocusedRowCellValue("STT").ToString());
                    congviec.msthongso = msthongso;
                    congviec.msmay = msmay;
                    congviec.msbp = msbp;
                    congviec.mstt = mstt;

                    congviec.sThaoTac = row["CACH_THUC_HIEN"].ToString();
                    congviec.sTieuChuan = row["TIEU_CHUAN_KT"].ToString();
                    congviec.sYeuCauDC = row["YEU_CAU_DUNG_CU"].ToString();
                    congviec.sYeuCauNS = row["YEU_CAU_NS"].ToString();
                    congviec.sTaiLieu = row["PATH_HD"].ToString();
                    congviec.bView = !btnGhi.Visible;
                }
            }
            if (congviec.ShowDialog() == DialogResult.Cancel) return;
            //kiem tra neu chua ton tại thì thêm vào list
            if (n == 0)
            {
                clsTinhTrangThietBi cv = new clsTinhTrangThietBi();
                cv.msmay = msmay;
                cv.msbp = msbp;
                cv.msthongso = msthongso;
                cv.mstt = mstt;
                cv.sThaoTac = congviec.sThaoTac;
                cv.sTieuChuan = congviec.sTieuChuan;
                cv.sYeuCauDC = congviec.sYeuCauDC;
                cv.sYeuCauNS = congviec.sYeuCauNS;
                cv.sTaiLieu = congviec.sTaiLieu;
                listcongviec.Add(cv);
            }
            //nếu tồn tại rồi thì cập nhật
            else
            {
                clsTinhTrangThietBi cv = listcongviec.Where(x => x.msmay.Equals(msmay) && x.msthongso.Equals(msthongso) && x.msbp.Equals(msbp) && x.mstt.Equals(mstt)).FirstOrDefault();
                cv.sThaoTac = congviec.sThaoTac;
                cv.sTieuChuan = congviec.sTieuChuan;
                cv.sYeuCauDC = congviec.sYeuCauDC;
                cv.sYeuCauNS = congviec.sYeuCauNS;
                cv.sTaiLieu = congviec.sTaiLieu;
            }
        }

        private void btnCTiet_Click(object sender, EventArgs e)
        {
            if (txtsttGSTT.EditValue.ToString() == "-1") return;
            if (grvTSDinhTinh.FocusedColumn.Name.ToString() != "colCT_CVIEC") return;
            TaoDanhListDanhSachCV();
        }

        private void grvTSDinhTinh_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (txtsttGSTT.EditValue.ToString() == "-1") return;
            if (grvTSDinhTinh.FocusedColumn.Name.ToString() != "colCT_CVIEC") return;
            TaoDanhListDanhSachCV();
        }

        private void grvTSDinhLuong_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (txtsttGSTT.EditValue.ToString() == "-1") return;
            if (grvTSDinhLuong.FocusedColumn.Name.ToString() != "colCT_CVIEC") return;
            TaoDanhListDanhSachCV();
        }

        private void datTNgayKT_Validating(object sender, CancelEventArgs e)
        {
            //MessageBox.Show("das");
            ////String.Format("dd / MM / yyyy", datTNgayKT.DateTime.Date);
        }

        private void chkXong_CheckedChanged(object sender, EventArgs e)
        {
            if (txtsttGSTT.EditValue.ToString() == "-1") return;
            if (chkXong.Checked == false && btnGhi.Visible)
            {
                DialogResult dl = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgLanGiamSatNayDaSongBanCoChacMuonThayDoi", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl == DialogResult.Yes)
                {
                    string sSql = "SELECT COUNT(*) FROM dbo.GIAM_SAT_TINH_TRANG_TS WHERE STT =" + Convert.ToInt16(txtsttGSTT.Text) + " AND ISNULL(MS_PBT,'')!=''";
                    int n = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (n == 0) chkXong.Checked = false;
                    else
                    {
                        DialogResult dll = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgLanGiamSatNayDaTonTaiSoPhieuBaoTriBanCoChanMuonThayDoiNo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dll == DialogResult.Yes)
                            chkXong.Checked = false;
                        else chkXong.Checked = true;
                    }
                }
                else chkXong.Checked = true;
            }
        }

        private void DatNgayBD_Validating(object sender, CancelEventArgs e)
        {
            //MessageBox.Show("dasd");
        }

        private void BtnChonTSDT_Click(object sender, EventArgs e)
        {
            frmChonThongSoGSTTDinhTinh tsdt = new frmChonThongSoGSTTDinhTinh();
            if (tsdt.ShowDialog() == DialogResult.Cancel) return;
            loadmay(-1);
            loaddanhsachDT(-1);
            LoadCTDTDL();
        }

        private void BtnChonTSDL_Click(object sender, EventArgs e)
        {
            //load form định lượng
            if (txtsttGSTT.Text.ToString() == "-1")
            {
                InsertVaoDuLieuBangTamDL();
            }
            else
            {
                // UpateDuLieuBangTamDL();
            }
            frmChonThongSoGSTTDinhLuong tsdt = new frmChonThongSoGSTTDinhLuong();
            if (tsdt.ShowDialog() == DialogResult.Cancel) return;
            loaddanhsachDL(-1);
            loadmay(-1);
            LoadCTDTDL();
        }

        private void grvTSDinhLuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadCTDTDL();
        }

        private void grvTSDinhLuong_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (!btnGhi.Visible) return;
            string sMaThongSo, sMaMay, sMaBP;
            int iMaTT;
            double dGiaTriDo, dThoiGianTT;
            try
            {
                sMaThongSo = grvTSDinhLuong.GetFocusedRowCellValue("MS_TS_GSTT").ToString();
            }
            catch { sMaThongSo = "-1"; }
            try
            {
                sMaMay = grvTSDinhLuong.GetFocusedRowCellValue("MS_MAY").ToString();
            }
            catch { sMaMay = "-1"; }

            try
            {
                sMaBP = grvTSDinhLuong.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
            }
            catch { sMaBP = "-1"; }

            try
            {
                dGiaTriDo = Convert.ToDouble(grvTSDinhLuong.GetFocusedRowCellValue("GIA_TRI_DO").ToString());
            }
            catch { dGiaTriDo = 0; }
            try
            {
                dThoiGianTT = Convert.ToDouble(grvTSDinhLuong.GetFocusedRowCellValue("TG_TT").ToString());
            }
            catch { dThoiGianTT = 0; }

            try
            {
                iMaTT = Convert.ToInt16(grvDSGiaTri.GetFocusedRowCellValue("MS_TT").ToString());
            }
            catch { iMaTT = -1; }

            double min = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT MIN(GIA_TRI_DUOI) FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY ='" + sMaMay + "' AND MS_TS_GSTT ='" + sMaThongSo + "' AND MS_BO_PHAN ='" + sMaBP + "'"));

            double max = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT MAX(GIA_TRI_TREN) FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY ='" + sMaMay + "' AND MS_TS_GSTT ='" + sMaThongSo + "' AND MS_BO_PHAN ='" + sMaBP + "'"));
            if (dGiaTriDo < min || dGiaTriDo >= max)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                            "Msgkhongnamtrongkhoanggiatri", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string sSql = "UPDATE " + sBTamGiaTriDL + " SET GIA_TRI_DO = " + Math.Round(dGiaTriDo, 2) + ",TG_TT =" + Math.Round(dThoiGianTT, 2) + " ,MS_TT = (SELECT MS_TT FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY ='" + sMaMay + "' AND MS_TS_GSTT='" + sMaThongSo + "' AND MS_BO_PHAN ='" + sMaBP + "'AND GIA_TRI_TREN > " + dGiaTriDo + " AND GIA_TRI_DUOI <= " + dGiaTriDo + ") WHERE MS_MAY = '" + sMaMay + "' AND MS_TS_GSTT = '" + sMaThongSo + "' AND MS_BO_PHAN = '" + sMaBP + "'";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }
        }

        private void cboLoaithietbi_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtTuNgayBC.Text) || string.IsNullOrEmpty(dtDenngayBC.Text))
            {
                loadNgayBC();
            }
            loadgrdBC();
        }

        private void optChonDat_SelectedIndexChanged(object sender, EventArgs e)
        {
            TKBaoCao();
        }
        public void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx"); // "C:\Users\Administrator\Desktop\frmrptCTY_DA_CUNG_CAP_VAT_TU.xls" '
            if (sPath == "")
                return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvBC.Columns.Count - 1;
                int TDong = grvBC.RowCount;
                int Dong = 1;

                grdBC.ExportToXlsx(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks xlWBooks = xlApp.Workbooks;
                Excel.Workbook xlWBook = xlWBooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);

                Excel.Worksheet xlWSheet = (Excel.Worksheet)xlWBook.Sheets[1];

                Dong = Commons.Modules.MExcel.TaoTTChung(xlWSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWSheet, 0, 0, 110, 45, xlApp.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);


                Dong += 1;

                Commons.Modules.MExcel.DinhDang(xlWSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                string stmp = "";

                Dong += 1;
                stmp = lblTungayBC.Text + " : " + dtTuNgayBC.DateTime.Date.ToShortDateString() + " " + lblDenngayBC.Text + dtDenngayBC.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 1, "@", 12, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);


                Dong += 1;
                stmp = lblDiadiem.Text + " : " + cboDiadiem.Text;
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);

                stmp = lblDayChuyen.Text + " : " + cboDayChuyen.Text;
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 4, "@", 10, true, true, Dong, 10);

                Dong += 1;
                stmp = lblLoaithietbi.Text + " : " + cboLoaithietbi.Text;
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);

                stmp = lblLoaiCongViec.Text + " : " + cboLoaiCongViec.Text;
                Commons.Modules.MExcel.DinhDang(xlWSheet, stmp, Dong, 4, "@", 10, true, true, Dong, 10);


                Excel.Range title;
                Dong += 2;


                title = Commons.Modules.MExcel.GetRange(xlWSheet, Dong, 1, Dong, TCot);
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = Commons.Modules.MExcel.GetRange(xlWSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color;
                title.Font.Bold = true;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                title = Commons.Modules.MExcel.GetRange(xlWSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = Commons.Modules.MExcel.GetRange(xlWSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color;


                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWBook, xlWSheet, false, true, true, true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 12, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 12, "dd/MM/yyyy", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 20, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 15, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 40, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 12, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 40, "@", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 40, "@", true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 30, "@", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 10, "@", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 10, "@", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 40, "@", true, Dong + 1, 12, TDong + Dong, 12);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 8, "@", true, Dong + 1, 13, TDong + Dong, 13);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 8, "@", true, Dong + 1, 14, TDong + Dong, 14);
                Commons.Modules.MExcel.ColumnWidth(xlWSheet, 8, "@", true, Dong + 1, 15, TDong + Dong, 15);


                title = Commons.Modules.MExcel.GetRange(xlWSheet, 1, 16, 1, 16);
                title.EntireColumn.Delete();

                // Excel.Range range = (Excel.Range)sheet.get_Range("C1", Missing.Value);
                // range.EntireColumn.Delete(Missing.Value);
                // System.Runtime.InteropServices.Marshal.ReleaseComObject(range);

                title = Commons.Modules.MExcel.GetRange(xlWSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                xlWBook.Save();
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWBook);

                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptCTY_DA_CUNG_CAP_VAT_TU", "InKhongThanhCong", Commons.Modules.TypeLanguage) + Excel.Constants.xlAll + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void BtnInCT_Click(object sender, EventArgs e)
        {

            if (tabChung.SelectedTabPageIndex == 2)
            {
                InDuLieu();
            }
        }

        private void grvTSDinhLuong_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = 0;
                if (grvTSDinhLuong.FocusedColumn.Name.ToString() == "colGIA_TRI_DO")
                {
                    grvTSDinhLuong.SetFocusedRowCellValue("GIA_TRI_DO", 0);
                }
                else
                {
                    grvTSDinhLuong.SetFocusedRowCellValue("TG_TT", 0);
                }
            }
        }

        private void grvTSDinhTinh_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = 0;
                grvTSDinhTinh.SetFocusedRowCellValue("TG_TT", 0);
            }
        }

        private void dtTuNgayBC_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(dtTuNgayBC.Text) || string.IsNullOrEmpty(dtDenngayBC.Text))
            //{
            //    loaddatNgay();
            //}
        }
        private void CreateMenuGSTT(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.GridControl grd1)
        {
            try
            {
                foreach (var conTrol in grd.Controls)
                {
                    if (conTrol is DevExpress.XtraBars.BarDockControl) ;
                }
            }
            catch (Exception ex)
            {
            }
            DevExpress.XtraBars.BarManager BarManager = new DevExpress.XtraBars.BarManager();
            BarManager.Form = grd;
            BarManager.ItemClick += BarManager_ItemClick;
            BarManager.BeginUpdate();
            DevExpress.XtraBars.PopupMenu popup = new DevExpress.XtraBars.PopupMenu(BarManager);
            BarManager.SetPopupContextMenu(grd, popup);
            string sStr;
            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkmnuGSTT", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuGSTT = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuGSTT.Name = "mnuGSTT";
            popup.AddItems(new DevExpress.XtraBars.BarItem[] { mnuGSTT });
            BarManager.EndUpdate();
            try
            {
                foreach (var conTrol in grd1.Controls)
                {
                    if (conTrol is DevExpress.XtraBars.BarDockControl)
                        return;
                }
            }
            catch (Exception ex)
            {
            }
            DevExpress.XtraBars.BarManager BarManagerDL = new DevExpress.XtraBars.BarManager();
            BarManagerDL.Form = grd1;
            BarManagerDL.ItemClick += BarManager_ItemClick;
            BarManagerDL.BeginUpdate();
            DevExpress.XtraBars.PopupMenu popupDL = new DevExpress.XtraBars.PopupMenu(BarManagerDL);
            BarManagerDL.SetPopupContextMenu(grd1, popupDL);
            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkmnuGSTTDL", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuGSTTDL = new DevExpress.XtraBars.BarButtonItem(BarManagerDL, sStr);
            mnuGSTTDL.Name = "mnuGSTTDL";
            popupDL.AddItems(new DevExpress.XtraBars.BarItem[] { mnuGSTTDL });
            BarManagerDL.EndUpdate();
        }
        private void BarManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           frmThongsoGSTT frmThongsoGSTT = new frmThongsoGSTT();
            DevExpress.XtraBars.BarSubItem subMenu = e.Item as DevExpress.XtraBars.BarSubItem;
            DevExpress.XtraBars.BarManager barMenu = sender as DevExpress.XtraBars.BarManager;
            DevExpress.XtraGrid.GridControl grd = this.Controls.Find(barMenu.Form.Name, true).FirstOrDefault() as DevExpress.XtraGrid.GridControl;
            DevExpress.XtraGrid.Views.Grid.GridView grv = grd.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            DataTable dt = new DataTable();
            try
            {
                switch (e.Item.Name.ToUpper().ToString())
                {
                    case "MNUGSTT":
                        {
                            string str = "select * from NHOM_MENU WHERE MENU_ID = N'mnuThongsoGSTT' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" + Commons.Modules.UserName + "')";
                            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                            if ((dt.Rows.Count == 0))
                            {
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, frmThongsoGSTT.Name);
                            string sMaSo = "";
                            sMaSo = grv.GetFocusedRowCellValue("MS_TS_GSTT").ToString();
                            frmThongsoGSTT.MS_GS_TT = sMaSo;
                            frmThongsoGSTT.LOAI_TS = false;
                            frmMain.ShowForm(frmThongsoGSTT);
                            break;
                        }
                    case "MNUGSTTDL":
                        {
                            string str = "select * from NHOM_MENU WHERE MENU_ID = N'mnuThongsoGSTT' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" + Commons.Modules.UserName + "')";
                            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                            if ((dt.Rows.Count == 0))
                            {
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, frmThongsoGSTT.Name);
                            string sMaSo;
                            sMaSo = grv.GetFocusedRowCellValue("MS_TS_GSTT").ToString();
                            frmThongsoGSTT.MS_GS_TT = sMaSo;
                            frmThongsoGSTT.LOAI_TS = true;
                            frmMain.ShowForm(frmThongsoGSTT);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }



}

