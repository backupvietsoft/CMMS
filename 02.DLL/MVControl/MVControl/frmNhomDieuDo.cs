using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace MVControl
{
    public partial class frmNhomDieuDo : DevExpress.XtraEditors.XtraForm
    {
        public frmNhomDieuDo()
        {
            InitializeComponent();
        }

        private void frmNhomDieuDo_Load(object sender, EventArgs e)
        {
            LoadDDNhom(-1);
            LoadText(false);
            if (grvNhomDD.RowCount == 0 || grvNhomDD.DataSource == null)
            {
                LoadChiTiet(-11);
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnChonDieuDo_Click(object sender, EventArgs e)
        {
            switch (tabChung.SelectedTabPageIndex)
            {
                case 0:
                    ChonMay();
                    break;
                case 1:
                    ChonNhanSu();
                    break;
            }

        }


        private void ChonMay()
        {
            try
            {
                DataTable dt = new DataTable();
                frmChonMay frmMay = new frmChonMay();
                if (grdDDMay.DataSource != null)
                {
                    try
                    {
                        dt = ((DataTable)grdDDMay.DataSource).Copy();
                        frmMay.lstMayChon = dt.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("MS_MAY")).ToList();
                    }
                    catch
                    { }
                }

                if (frmMay.ShowDialog() == DialogResult.Cancel) return;
                dt = new DataTable();
                DataView view = new DataView(frmMay.dtMayReturn);

                dt = view.ToTable(true, "MS_MAY", "TEN_MAY", "Ten_N_XUONG", "TEN_HE_THONG", "TEN_LOAI_MAY", "TEN_NHOM_MAY", "MS_LOAI_MAY", "MS_NHOM_MAY", "MS_N_XUONG", "MS_HE_THONG");

                if (grdDDMay.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdDDMay, grvDDMay, dt, false, true, true, true, true, this.Name);
                    grvDDMay.Columns["MS_LOAI_MAY"].Visible = false;
                    grvDDMay.Columns["MS_NHOM_MAY"].Visible = false;
                    grvDDMay.Columns["MS_N_XUONG"].Visible = false;
                    grvDDMay.Columns["MS_HE_THONG"].Visible = false;
                    grvDDMay.Columns["MS_MAY"].Width = 100;
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdDDMay, grvDDMay, dt, false, false, true, false, true, this.Name);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }

        }

        private void ChonNhanSu()
        {
            try
            {
                DataTable dt = new DataTable();
                frmChonNhanSu frmNS = new frmChonNhanSu();
                if (grdDDCNhan.DataSource != null)
                {
                    try
                    {
                        dt = ((DataTable)grdDDCNhan.DataSource).Copy();
                        frmNS.lstNhanSuChon = ((DataTable)grdDDCNhan.DataSource).Rows.OfType<DataRow>().Select(dr => dr.Field<string>("MS_CONG_NHAN")).ToList();
                    }
                    catch { }
                }

                if (frmNS.ShowDialog() == DialogResult.Cancel) return;
                dt = new DataTable();
                DataView view = new DataView(frmNS.dtNhanSuReturn);
                dt = view.ToTable(true, "MS_CONG_NHAN", "HOTEN", "TEN_DON_VI", "TEN_PHONG_BAN", "TEN_TO", "MS_TO", "MS_PHONG_BAN", "MS_DON_VI", "HO", "TEN");

                if (grdDDCNhan.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdDDCNhan, grvDDCNhan, dt, false, true, true, true, true, this.Name);
                    grvDDCNhan.Columns["HO"].Visible = false;
                    grvDDCNhan.Columns["TEN"].Visible = false;
                    grvDDCNhan.Columns["MS_TO"].Visible = false;
                    grvDDCNhan.Columns["MS_PHONG_BAN"].Visible = false;
                    grvDDCNhan.Columns["MS_DON_VI"].Visible = false;
                    grvDDCNhan.Columns["MS_CONG_NHAN"].Width = 100;
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdDDCNhan, grvDDCNhan, dt, false, false, true, false, true, this.Name);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadDDNhom(int iDD)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDieuDoNhom"));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID_NHOM_DD"] };

                if (grdNhomDD.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhomDD, grvNhomDD, dt, false, true, false, true, true, this.Name);
                    grvNhomDD.Columns["ID_NHOM_DD"].Visible = false;
                    grvNhomDD.Columns["TEN_NHOM_HOA"].Visible = false;
                    grvNhomDD.Columns["TEN_NHOM"].Width = 200;
                    grvNhomDD.Columns["TEN_NHOM_ANH"].Width = 200;
                    grvNhomDD.Columns["GHI_CHU"].Width = 400;
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhomDD, grvNhomDD, dt, false, false, false, false, true, this.Name);
                }
                if (iDD != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(iDD));
                    grvNhomDD.FocusedRowHandle = grvNhomDD.GetRowHandle(index);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }

        }

        private void LoadChiTiet(int iDD)
        {
            this.Cursor = Cursors.WaitCursor;
            switch (tabChung.SelectedTabPageIndex)
            {
                case 0:
                    LoadDDMay(iDD);
                    break;
                case 1:
                    LoadDDCNhan(iDD);
                    break;
            }
            this.Cursor = Cursors.Default;
        }
        private void LoadDDMay(int iDD)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDieuDoNhomMay", iDD, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

            if (grdDDMay.DataSource == null)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDDMay, grvDDMay, dt, false, true, true, true, true, this.Name);
                grvDDMay.Columns["MS_LOAI_MAY"].Visible = false;
                grvDDMay.Columns["MS_NHOM_MAY"].Visible = false;
                grvDDMay.Columns["MS_N_XUONG"].Visible = false;
                grvDDMay.Columns["MS_HE_THONG"].Visible = false;
                grvDDMay.Columns["MS_MAY"].Width = 100;
            }
            else
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDDMay, grvDDMay, dt, false, false, true, false, true, this.Name);
            }
        }
        private void LoadDDCNhan(int iDD)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDieuDoNhomCongNhan", iDD, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

            if (grdDDCNhan.DataSource == null)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDDCNhan, grvDDCNhan, dt, false, true, true, true, true, this.Name);
                grvDDCNhan.Columns["HO"].Visible = false;
                grvDDCNhan.Columns["TEN"].Visible = false;
                grvDDCNhan.Columns["MS_TO"].Visible = false;
                grvDDCNhan.Columns["MS_PHONG_BAN"].Visible = false;
                grvDDCNhan.Columns["MS_DON_VI"].Visible = false;
                grvDDCNhan.Columns["MS_CONG_NHAN"].Width = 100;
            }
            else
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDDCNhan, grvDDCNhan, dt, false, false, true, false, true, this.Name);
            }
        }

        private void LoadText(bool bNull)
        {
            if (bNull)
            {
                txtID.Text = "-1";
                txtTenNhom.Text = "";
                txtTenNhomAnh.Text = "";
                txtGhiChu.Text = "";
            }
            else
            {
                if (grvNhomDD.RowCount == 0)
                {
                    txtID.Text = "-1";
                    txtTenNhom.Text = "";
                    txtTenNhomAnh.Text = "";
                    txtGhiChu.Text = "";
                }
                else
                {
                    txtID.Text = grvNhomDD.GetFocusedRowCellValue("ID_NHOM_DD").ToString();
                    txtTenNhom.Text = grvNhomDD.GetFocusedRowCellValue("TEN_NHOM").ToString();
                    txtTenNhomAnh.Text = grvNhomDD.GetFocusedRowCellValue("TEN_NHOM_ANH").ToString();
                    txtGhiChu.Text = grvNhomDD.GetFocusedRowCellValue("GHI_CHU").ToString();
                }
            }


        }

        private void grvNhomDD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                LoadText(false);
                LoadChiTiet(int.Parse(txtID.Text));
            }
            catch
            {
                LoadChiTiet(-11);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoadText(true);
            LoadDDMay(-1);
            LoadDDCNhan(-1);
            VisThemSua(true);
            txtTenNhom.Focus();
        }

        private void VisThemSua(bool bThemSua)
        {
            btnThem.Visible = !bThemSua;
            btnSua.Visible = !bThemSua;
            btnXoa.Visible = !bThemSua;
            btnThoat.Visible = !bThemSua;

            btnChon.Visible = bThemSua;
            btnGhi.Visible = bThemSua;
            btnKhongGhi.Visible = bThemSua;

            tableLayoutPanel2.Enabled = !tableLayoutPanel2.Enabled;
            txtGhiChu.Properties.ReadOnly = !bThemSua;
            txtTenNhom.Properties.ReadOnly = !bThemSua;
            txtTenNhomAnh.Properties.ReadOnly = !bThemSua;
        }

        private void VisXoa(bool bXoa)
        {
            btnThem.Visible = !bXoa;
            btnSua.Visible = !bXoa;
            btnXoa.Visible = !bXoa;
            btnThoat.Visible = !bXoa;

            btnXoaNhom.Visible = bXoa;
            btnXoaChiTiet.Visible = bXoa;
            btnTroVe.Visible = bXoa;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            switch (tabChung.SelectedTabPageIndex)
            {
                case 1:
                    LoadDDMay(int.Parse(txtID.Text));
                    break;
                case 0:
                    LoadDDCNhan(int.Parse(txtID.Text));
                    break;
            }
            this.Cursor = Cursors.Default;
            VisThemSua(true);
            txtTenNhom.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            VisXoa(true);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!KiemKhi()) return;
            int iID = int.Parse(txtID.Text);

            try
            {
                string BTMay = "DD_MAY_TMP" + Commons.Modules.UserName;
                string BTCN = "DD_CN_TMP" + Commons.Modules.UserName;
                if (grdDDMay.DataSource != null)
                {
                    if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, BTMay, (DataTable)grdDDMay.DataSource, ""))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDuLieuMaySai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (grdDDCNhan.DataSource != null)
                {
                    if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, BTCN, (DataTable)grdDDCNhan.DataSource, ""))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDuLieuCongNhanSai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                SqlConnection sql = new SqlConnection(Commons.IConnections.ConnectionString);
                if (sql.State == ConnectionState.Closed)
                    sql.Open();

                SqlTransaction tran = null;
                try
                {
                    tran = sql.BeginTransaction();
                    iID = int.Parse(SqlHelper.ExecuteScalar(tran, "spCapNhapDieuDoNhom", Convert.ToInt32(txtID.Text), txtTenNhom.Text, txtTenNhomAnh.Text, "", txtGhiChu.Text, BTMay, BTCN).ToString());
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    XtraMessageBox.Show(ex.Message);
                }

            }
            catch(Exception ex)
            {
                
                XtraMessageBox.Show(ex.Message);
            }

            VisThemSua(false);
            LoadDDNhom(iID);
            if(grvNhomDD.GetFocusedRowCellValue("ID_NHOM_DD").ToString() != txtID.Text)
            {
                try
                {
                    LoadText(false);
                    LoadChiTiet(int.Parse(txtID.Text));
                }
                catch { LoadChiTiet(-11); }
            }
        }

        private bool KiemKhi()
        {
            try
            {
                if (txtTenNhom.Text.Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapTenNhom", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNhom.Focus();
                    return false;
                }


                if (Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM DIEU_DO_NHOM WHERE ID_NHOM_DD <> " + txtID.Text + " AND TEN_NHOM = N'" + txtTenNhom.Text + "' ").ToString()) > 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTenNhomDaCo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNhom.Focus();
                    return false;
                }

                if (Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM DIEU_DO_NHOM WHERE ID_NHOM_DD <> " + txtID.Text + " AND TEN_NHOM_ANH = N'" + txtTenNhomAnh.Text + "' AND ISNULL(TEN_NHOM_ANH,'') <> N'' ").ToString()) > 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTenNhomAnhDaCo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNhomAnh.Focus();
                    return false;
                }
                    
                
                if (grdDDMay.DataSource == null)
                {
                    if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonMayMuonChonLai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)) == DialogResult.Yes)
                        return false;
                }
                else
                {
                    if (grvDDMay.RowCount == 0)
                    {
                        if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonMayMuonChonLai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.Yes)
                            return false;
                    }

                }
                if (grdDDCNhan.DataSource == null)
                {
                    if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonCongNhanMuonChonLai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.Yes)
                        return false;
                }
                else
                {
                    if (grvDDCNhan.RowCount == 0)
                    {
                        if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonCongNhanMuonChonLai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.Yes)
                            return false;
                    }

                }

                return true;
            }
            catch
            {
                return false;
            }

        }
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            
            VisThemSua(false);
            grvNhomDD_FocusedRowChanged(null, null);
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            VisXoa(false);
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            if (XoaNhom())
            {
                LoadDDNhom(-1);
                LoadText(false);
                try
                {
                    if (grvNhomDD.GetFocusedRowCellValue("ID_NHOM_DD").ToString() != txtID.Text)
                        LoadChiTiet(int.Parse(txtID.Text));
                }catch
                { LoadChiTiet(-1); }
            }
        }

        private void tabChung_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (btnGhi.Visible) return;
            LoadChiTiet(int.Parse(txtID.Text));
        }

        private void grdDDMay_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Delete) return;
            if (!btnGhi.Visible)
                if (!XoaMay(true)) return;

            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            view.DeleteSelectedRows();
            e.Handled = true;
            ((DataTable)grdDDMay.DataSource).AcceptChanges();
        }


        private bool XoaMay(bool bXoaMot)
        {
            if (grdDDMay.DataSource == null)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (grvDDMay.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string sMsMay = grvDDMay.GetFocusedRowCellValue("MS_MAY").ToString();
            if (bXoaMot)
            {
                if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCoChacXoaMayNay", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return false;
                sMsMay = grvDDMay.GetFocusedRowCellValue("MS_MAY").ToString();
            }
            else
            {
                DialogResult sRes;
                sRes = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCoMuanXoaMotMay-Y-HayXoaHetMay-N", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (sRes == DialogResult.Cancel) return false;
                if (sRes == DialogResult.Yes) sMsMay = grvDDMay.GetFocusedRowCellValue("MS_MAY").ToString();
                if (sRes == DialogResult.No) sMsMay = "-1";

            }

            SqlConnection sql = new SqlConnection(Commons.IConnections.ConnectionString);
            if (sql.State == ConnectionState.Closed)
                sql.Open();
            SqlTransaction tran = null;
            try
            {
                tran = sql.BeginTransaction();
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE FROM DIEU_DO_NHOM_MAY WHERE (ID_NHOM_DD = " + txtID.Text + ") AND (MS_MAY = N'" + sMsMay + "' OR N'" + sMsMay + "' = '-1' )  ");
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                XtraMessageBox.Show(ex.Message.ToString());
                return false;
            }

            return true;
        }


        private void grdDDCNhan_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Delete) return;
            if (!btnGhi.Visible)
                if (!XoaCNhan(true)) return;

            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            view.DeleteSelectedRows();
            e.Handled = true;
            ((DataTable)grdDDCNhan.DataSource).AcceptChanges();
        }



        private bool XoaCNhan(bool bXoaMot)
        {
            if (grdDDCNhan.DataSource == null)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (grvDDCNhan.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }




            string sMsCN = grvDDCNhan.GetFocusedRowCellValue("MS_CONG_NHAN").ToString();
            if (bXoaMot)
            {
                if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCoChacXoaNhanVienNay", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return false;
                sMsCN = grvDDCNhan.GetFocusedRowCellValue("MS_CONG_NHAN").ToString();
            }
            else
            {
                DialogResult sRes;
                sRes = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCoMuanXoaMotNhanVien-Y-HayXoaHetNhanVien-N", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (sRes == DialogResult.Cancel) return false;
                if (sRes == DialogResult.Yes) sMsCN = grvDDMay.GetFocusedRowCellValue("MS_MAY").ToString();
                if (sRes == DialogResult.No) sMsCN = "-1";

            }


            if (!btnGhi.Visible)
            {
                SqlConnection sql = new SqlConnection(Commons.IConnections.ConnectionString);
                if (sql.State == ConnectionState.Closed)
                    sql.Open();
                SqlTransaction tran = null;
                try
                {
                    tran = sql.BeginTransaction();
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE FROM DIEU_DO_NHOM_CN WHERE ID_NHOM_DD = " + sMsCN + " AND MS_CONG_NHAN = N'" + sMsCN + "'  ");
                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    XtraMessageBox.Show(ex.Message.ToString());
                    return false;
                }
            }
            return true;
        }

        private void grdNhomDD_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (btnGhi.Visible) return;
            if (e.KeyData != Keys.Delete) return;
            if (!btnGhi.Visible)
            {
                if (!XoaNhom()) return;
            }
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            view.DeleteSelectedRows();
            e.Handled = true;
            try { ((DataTable)grdNhomDD.DataSource).AcceptChanges(); }catch { }
            try { ((DataTable)grdDDCNhan.DataSource).AcceptChanges(); }catch { }
            try { ((DataTable)grdDDMay.DataSource).AcceptChanges(); }catch { }
            grvNhomDD_FocusedRowChanged(null, null);
        }

        private bool XoaNhom()
        {
            try
            {
                if (grdNhomDD.DataSource == null)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (grvNhomDD.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                Int64 iID;
                iID = Int64.Parse(grvNhomDD.GetFocusedRowCellValue("ID_NHOM_DD").ToString());

                if (Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 ID_NHOM_DD,MS_MAY FROM DIEU_DO_NHOM_MAY WHERE ID_NHOM_DD = " + txtID.Text + " UNION SELECT TOP 1 ID_NHOM_DD,MS_CONG_NHAN FROM DIEU_DO_NHOM_CN WHERE ID_NHOM_DD = " + txtID.Text)) > 0)
                {
                    if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDuLieuChiTietConCoMuonXoaHet", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return false;
                }
                else
                {
                    if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCoChacXoaNhomNay", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) == DialogResult.No) return false;
                }

                SqlConnection sql = new SqlConnection(Commons.IConnections.ConnectionString);
                if (sql.State == ConnectionState.Closed)
                    sql.Open();
                SqlTransaction tran = null;
                try
                {
                    tran = sql.BeginTransaction();
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE FROM DIEU_DO_NHOM_MAY WHERE ID_NHOM_DD = " + iID.ToString());
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE FROM DIEU_DO_NHOM_CN WHERE ID_NHOM_DD = " + iID.ToString());
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE FROM DIEU_DO_NHOM WHERE ID_NHOM_DD = " + iID.ToString());
                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return false;
                    XtraMessageBox.Show(ex.Message.ToString());
                }
                return true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return false;
            }

        }
        private void btnXoaMayMoc_Click(object sender, EventArgs e)
        {
            switch (tabChung.SelectedTabPageIndex)
            {
                case 0:
                    if (!XoaMay(false)) return;
                    break;
                case 1:
                    if (!XoaCNhan(false)) return;
                    break;
            }
            grvNhomDD_FocusedRowChanged(null, null);
        }



        private void txtTKiem_EditValueChanging_1(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                
                dtTmp = (DataTable)grdNhomDD.DataSource;
                if (textEdit4.Text.Length != 0) sdkien = sdkien + " AND ( " + " TEN_NHOM LIKE '%" + textEdit4.Text + "%' OR TEN_NHOM_ANH LIKE '%" + textEdit4.Text + "%' OR TEN_NHOM_HOA LIKE '%" +
                    textEdit4.Text + "%' OR GHI_CHU LIKE '%" + textEdit4.Text + "%' ) ";


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
            grvNhomDD_FocusedRowChanged(null, null);
        }
    }
}
