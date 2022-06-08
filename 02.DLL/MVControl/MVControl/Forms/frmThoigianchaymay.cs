using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MVControl
{
    public partial class frmThoigianchaymay : DevExpress.XtraEditors.XtraForm
    {

        public frmThoigianchaymay()
        {
            InitializeComponent();
        }
        private void frmThoigianchaymay_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            dtTNgay.DateTime = DateTime.Now.AddDays(-7);
            dtDNgay.DateTime = DateTime.Now;
            LoadCombo();
            LoadDataMay();
            Commons.Modules.SQLString = "";
            grvMay_FocusedRowChanged(null, null);
            layoutRuntime.RowStyles[0].Height = 0;
            layoutRuntime.RowStyles[2].Height = 0;
            Commons.Modules.ObjSystems.ThayDoiNN(this);

            btnThem.Enabled = true;
            btnXoa.Enabled = true;

        }

        private void LoadDataMay()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayUserALL", Commons.Modules.UserName, cboDiaDiem.EditValue, cboHeThong.EditValue, "-1", cboLoaimay.EditValue, "-1", "-1", DateTime.Now, Commons.Modules.TypeLanguage));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dt, false, false, false, true, true, "frmThoigianchaymay");
            if (grvMay.Columns["TEN_NHOM_MAY"].Visible == false) return;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvMay.Columns)
            {
                col.Visible = false;
            }
            grvMay.Columns["MS_MAY"].Visible = true;
            grvMay.Columns["TEN_MAY"].Visible = true;
            grvMay.Columns["MS_MAY"].VisibleIndex = 1;
            grvMay.Columns["TEN_MAY"].VisibleIndex = 2;
            grvMay.Columns["Ten_N_XUONG"].VisibleIndex = 3;
            grvMay.Columns["TEN_HE_THONG"].VisibleIndex = 4;
            grvMay.Columns["TEN_LOAI_MAY"].VisibleIndex = 5;
            grvMay.Columns["Ten_N_XUONG"].Visible = true;
            grvMay.Columns["TEN_HE_THONG"].Visible = true;
            grvMay.Columns["TEN_LOAI_MAY"].Visible = true;
        }

        private void LoadCombo()
        {
            try
            {
                try
                {
                    KiemApp.MLoadCboTreeList(ref cboDiaDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
                }
                catch { }
            }
            catch { }
            try
            {
                KiemApp.MLoadCboTreeList(ref cboHeThong, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_MAY", Commons.Modules.UserName));
                DataRow dr = dt.NewRow();
                dr["MS_LOAI_MAY"] = "-1";
                dr["TEN_LOAI_MAY"] = " < ALL > ";
                dr["USERNAME"] = Commons.Modules.UserName;
                dt.Rows.Add(dr);
                dt.DefaultView.Sort = "TEN_LOAI_MAY";
                dt = dt.DefaultView.ToTable();
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaimay, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
        }

        private void grvMay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadThoiGianChayMay();
        }
        private void LoadThoiGianChayMay()
        {
            if (grdMay.DataSource == null || grvMay.RowCount == 0)
            {
                grdRuntime.DataSource = null;
                return;
            }
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetThoiGianChayMayChiTiet", grvMay.GetFocusedDataRow()["MS_MAY"].ToString(), dtTNgay.DateTime.Date, dtDNgay.DateTime.AddHours(23 - dtDNgay.DateTime.Hour).AddMinutes(59).AddSeconds(59)));
                dt.Columns["CHI_SO_DONG_HO"].ReadOnly = false;
                dt.Columns["SO_GIO_LUY_KE"].ReadOnly = false;
                dt.Columns["SO_GIO_LUY_KE"].AllowDBNull = true;
                if (grdRuntime.DataSource == null)
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdRuntime, grvRuntime, dt, false, false, true, false);
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdRuntime, grvRuntime, dt, false, false, true, false);
                grvRuntime.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
                grvRuntime.Columns["NGAY"].Width = 100;
                grvRuntime.Columns["NGAY"].OptionsColumn.ReadOnly = true;
                grvRuntime.Columns["NGAY"].OptionsColumn.AllowEdit = false;
                grvRuntime.Columns["MS_MAY"].Visible = false;
                grvRuntime.Columns["SO_MOVEMENT"].Visible = false;
                grvRuntime.Columns["MS_PBT"].Visible = false;

                grvRuntime.Columns["NGAY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                grvRuntime.Columns["CHI_SO_DONG_HO"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                grvRuntime.Columns["SO_GIO_LUY_KE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            }
            catch (Exception)
            {
            }
        }

        private void SetVisibleButton(bool bln)
        {
            btnThem.Visible = bln;
            btnThoat.Visible = bln;
            btnXoa.Visible = bln;
            btnLuu.Visible = !bln;
            btnKhongLuu.Visible = !bln;
            grdMay.Enabled = bln;
            layoutCombo.Enabled = bln;
            txtTimMay.Enabled = bln;
            btnImport.Visible = bln;
        }
        double chiSoDenNgay = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtChuNhat.Text = "0";
            txtThuBay.Text = "0";
            txtNgayThuong.Text = "0";

            layoutRuntime.RowStyles[0].Height = 70;
            layoutRuntime.RowStyles[2].Height = 20;
            Application.DoEvents();
            SetVisibleButton(false);
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetThoiGianChayMayTheoRange", grvMay.GetFocusedDataRow()["MS_MAY"].ToString(), dtTNgay.DateTime.Date, dtDNgay.DateTime.Date, "-1", "-1"));
            dt.Columns["CHI_SO_DONG_HO"].ReadOnly = false;
            dt.Columns["SO_GIO_LUY_KE"].ReadOnly = false;
            dt.Columns["SO_GIO_LUY_KE"].AllowDBNull = true;
            if (grdRuntime.DataSource == null)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdRuntime, grvRuntime, dt, false, false, true, false);
            else Commons.Modules.ObjSystems.MLoadXtraGrid(grdRuntime, grvRuntime, dt, true, false, true, false);
            grvRuntime.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            grvRuntime.Columns["NGAY"].Width = 100;
            grvRuntime.Columns["NGAY"].OptionsColumn.ReadOnly = true;
            grvRuntime.Columns["NGAY"].OptionsColumn.AllowEdit = false;
            grvRuntime.Columns["MS_MAY"].Visible = false;
            grvRuntime.Columns["SO_MOVEMENT"].Visible = false;
            grvRuntime.Columns["MS_PBT"].Visible = false;
            string sSql = "SELECT ISNULL(SO_GIO_LUY_KE,0) FROM dbo.THOI_GIAN_CHAY_MAY WHERE NGAY in (SELECT MAX(NGAY) FROM  dbo.THOI_GIAN_CHAY_MAY WHERE  NGAY < CONVERT(DATETIME,'" + dtTNgay.DateTime.Month + "/" + dtTNgay.DateTime.Day + "/" + dtTNgay.DateTime.Year + "') AND	MS_MAY='" + grvMay.GetFocusedDataRow()["MS_MAY"].ToString() + "' ) AND	MS_MAY='" + grvMay.GetFocusedDataRow()["MS_MAY"].ToString() + "'";
            chiSoDenNgay = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            blChiSoDenNgay.Text = nnTmp + " " + dtTNgay.DateTime.Date.AddDays(-1).ToString("dd/MM/yyyy") + ": " + chiSoDenNgay.ToString();
        }
        string nnTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "blChiSoDenNgay", Commons.Modules.TypeLanguage);



        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (grvRuntime.RowCount == 0) return;
            string tableMay = "ThoiGianChayMayChon" + Commons.Modules.UserName;
            string tableListMay = "ThoiGianChayMayList" + Commons.Modules.UserName;
            DataTable tableRuntime = (DataTable)grdRuntime.DataSource;
            if (kiemtradl(tableRuntime) == false) return;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, tableMay, tableRuntime, "");
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, tableListMay, dtTmp, "");
            }
            else
            {
                tableListMay = "-1";
            }
            SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(trans, "spGhiThoiGianChayMay", tableMay, tableListMay, Commons.Modules.UserName);
                trans.Commit();
                layoutRuntime.RowStyles[0].Height = 0;
                layoutRuntime.RowStyles[2].Height = 0;
                Application.DoEvents();
                SetVisibleButton(true);
                dtTmp = null;
                grvMay_FocusedRowChanged(null, null);
                btnImport.Visible = true;
                lblThongBao.Visible = false;
                dtDNgay.Enabled = true;
                dtTNgay.Enabled = true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            grvMay_FocusedRowChanged(null, null);
            layoutRuntime.RowStyles[0].Height = 0;
            layoutRuntime.RowStyles[2].Height = 0;
            Application.DoEvents();
            SetVisibleButton(true);
            dtTmp = null;
            grvMay_FocusedRowChanged(null, null);
            btnImport.Visible = true;
            lblThongBao.Visible = false;
            dtDNgay.Enabled = true;
            dtTNgay.Enabled = true;
        }

        private void lnkCapNhatTungMay_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetThoiGianChayMayTheoRange", grvMay.GetFocusedDataRow()["MS_MAY"].ToString(), dtTNgay.DateTime.Date, dtDNgay.DateTime.Date, txtNgayThuong.Text + "|" + txtThuBay.Text + "|" + txtChuNhat.Text, "-1"));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            dt.Columns["CHI_SO_DONG_HO"].ReadOnly = false;
            dt.Columns["SO_GIO_LUY_KE"].ReadOnly = false;
            dt.Columns["SO_GIO_LUY_KE"].AllowDBNull = true;
            //lấy giá trị max 
            TinhGioLuyKe(dt, 0, true);
        }
        private DataTable TinhGioLuyKeTheoTungMay(string msmay)
        {
            double max = 0;

            DataTable tempt = new DataTable();
            string sSql = "SELECT ISNULL(SO_GIO_LUY_KE,0) FROM dbo.THOI_GIAN_CHAY_MAY WHERE NGAY in (SELECT MAX(NGAY) FROM  dbo.THOI_GIAN_CHAY_MAY WHERE  NGAY < CONVERT(DATETIME,'" + dtTNgay.DateTime.Month + "/" + dtTNgay.DateTime.Day + "/" + dtTNgay.DateTime.Year + "')) AND	MS_MAY='" + msmay + "'";
            try
            {
                max = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetThoiGianChayMayTheoRange", msmay, dtTNgay.DateTime.Date, dtDNgay.DateTime.Date, txtNgayThuong.Text + "|" + txtThuBay.Text + "|" + txtChuNhat.Text, "-1"));
                tempt.Columns["CHI_SO_DONG_HO"].ReadOnly = false;
                tempt.Columns["SO_GIO_LUY_KE"].ReadOnly = false;
                tempt.Columns["SO_GIO_LUY_KE"].AllowDBNull = true;
                for (int i = 0; i < tempt.Rows.Count; i++)
                {
                    //if (Convert.ToInt32(tempt.Rows[i]["IS_UPDATE"]) == 0)
                    //{//nếu không tồn tại thì lấy giá trị max + chỉ số đồng hồ đo
                    tempt.Rows[i]["SO_GIO_LUY_KE"] = max + Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]);
                    max += Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]);
                    //}
                    //else
                    //{//nếu không tồn tại giá trị thì gán cho max về số giờ lũy kế
                    //    max = Convert.ToDouble(tempt.Rows[i]["SO_GIO_LUY_KE"]);
                    //}
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            return tempt;
        }
        private void autoreport(DataTable tempt, int row, bool link)
        {
            double max = 0;
            grdRuntime.DataSource = null;
            int row0 = tempt.Rows.IndexOf(tempt.AsEnumerable().Where(x => x.Field<double>("SO_GIO_LUY_KE").Equals(0)).FirstOrDefault());
            if (link == false)
            {
                if (row >= row0)
                {
                    row0 = tempt.Rows.Count;
                }
            }
            else
            {
                row0 = tempt.Rows.Count;
            }
            try
            {
                if (row == 0)
                {
                    string sSql = "SELECT ISNULL(SO_GIO_LUY_KE,0) FROM dbo.THOI_GIAN_CHAY_MAY WHERE NGAY in (SELECT MAX(NGAY) FROM  dbo.THOI_GIAN_CHAY_MAY WHERE  NGAY < CONVERT(DATETIME,'" + dtTNgay.DateTime.Month + "/" + dtTNgay.DateTime.Day + "/" + dtTNgay.DateTime.Year + "') AND MS_MAY='" + grvMay.GetFocusedDataRow()["MS_MAY"].ToString() + "' ) AND MS_MAY='" + grvMay.GetFocusedDataRow()["MS_MAY"].ToString() + "'";
                    max = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    chiSoDenNgay = max;
                }
                else
                {
                    for (int i = row - 1; i >= 0; i--)
                    {
                        max = Convert.ToDouble(tempt.Rows[i]["SO_GIO_LUY_KE"]);
                        if (max > 0 || Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]) > 0)
                            break;
                    }
                }
                for (int i = row; i < row0; i++)
                {
                    if (Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]) > 0)
                    {
                        tempt.Rows[i]["SO_GIO_LUY_KE"] = max + Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]);
                        max += Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]);
                    }
                    else
                    {
                        tempt.Rows[i]["SO_GIO_LUY_KE"] = 0;
                        //break;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private void TinhGioLuyKe(DataTable tempt, int row, bool link)
        {
            autoreport(tempt, row, link);
            if (grdRuntime.DataSource == null)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdRuntime, grvRuntime, tempt, true, false, true, false);
            else Commons.Modules.ObjSystems.MLoadXtraGrid(grdRuntime, grvRuntime, tempt, true, false, true, false);
            grvRuntime.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            grvRuntime.Columns["NGAY"].Width = 100;
            grvRuntime.Columns["NGAY"].OptionsColumn.ReadOnly = true;
            grvRuntime.Columns["NGAY"].OptionsColumn.AllowEdit = false;
            grvRuntime.Columns["MS_MAY"].Visible = false;
            grvRuntime.Columns["SO_MOVEMENT"].Visible = false;
            grvRuntime.Columns["MS_PBT"].Visible = false;
        }
        private void TinhGioLuyKeNhapLuyKe(DataTable tempt, int row)
        {
            try
            {
                grdRuntime.DataSource = null;
                double max = Convert.ToDouble(tempt.Rows[row]["SO_GIO_LUY_KE"]);
                double resulst = 0;
                double maxtb = 0;
                for (int i = row - 1; i >= 0; i--)
                {
                    if (Convert.ToDouble(tempt.Rows[i]["SO_GIO_LUY_KE"]) > 0 || (Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]) > 0))
                    {
                        maxtb = Convert.ToDouble(tempt.Rows[i]["SO_GIO_LUY_KE"]);
                        break;
                    }
                }
                if (row == 0)
                {
                    //nếu là dòng đầu tiên thì chỉ số đồng hồ đo bằng chỉ số hiện tại trừ đi đến ngày
                    resulst = max - chiSoDenNgay;
                    tempt.Rows[row]["CHI_SO_DONG_HO"] = resulst > 0 ? resulst : (Convert.ToDouble(tempt.Rows[row]["CHI_SO_DONG_HO"]) > 0 ? (Convert.ToDouble(tempt.Rows[row]["CHI_SO_DONG_HO"])) : 0);
                }
                else
                {
                    //nếu không phải là dòng đầu tiên thì chỉ số đồng hồ đo bằng chỉ số hiện tại trừ đi số giờ lũy kế trước
                    resulst = max - (maxtb > 0 ? maxtb : chiSoDenNgay);
                    tempt.Rows[row]["CHI_SO_DONG_HO"] = resulst > 0 ? resulst : (Convert.ToDouble(tempt.Rows[row]["CHI_SO_DONG_HO"]) > 0 ? (Convert.ToDouble(tempt.Rows[row]["CHI_SO_DONG_HO"])) : 0);
                }
                int row0 = tempt.Rows.IndexOf(tempt.AsEnumerable().Where(x => x.Field<double>("SO_GIO_LUY_KE").Equals(0)).FirstOrDefault());
                if (row >= row0)
                {
                    row0 = tempt.Rows.Count;
                }
                for (int i = row + 1; i < row0; i++)
                {
                    if (Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]) > 0)
                    {
                        tempt.Rows[i]["SO_GIO_LUY_KE"] = max + Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]);
                        max += Convert.ToDouble(tempt.Rows[i]["CHI_SO_DONG_HO"]);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            if (grdRuntime.DataSource == null)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdRuntime, grvRuntime, tempt, true, false, true, false);
            else Commons.Modules.ObjSystems.MLoadXtraGrid(grdRuntime, grvRuntime, tempt, true, false, true, false);
            grvRuntime.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            grvRuntime.Columns["NGAY"].Width = 100;
            grvRuntime.Columns["NGAY"].OptionsColumn.ReadOnly = true;
            grvRuntime.Columns["NGAY"].OptionsColumn.AllowEdit = false;
            grvRuntime.Columns["MS_MAY"].Visible = false;
            grvRuntime.Columns["SO_MOVEMENT"].Visible = false;
            grvRuntime.Columns["MS_PBT"].Visible = false;
        }
        DataTable dtTmp = new DataTable();
        private void lnkCapNhatTatCaMay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (cboDiaDiem.EditValue.ToString() == "-1" && cboHeThong.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "msgBigData", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "frmThoigianchaymay", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (dtTmp == null || dtTmp.Rows.Count == 0)
                {
                    //lấy list mấy cần insert vào
                    DataTable tblMay = (DataTable)grdMay.DataSource;
                    dtTmp = (DataTable)grdRuntime.DataSource;
                    dtTmp.Clear();
                    var ListMay = tblMay.AsEnumerable().Select(row => new
                    {
                        May = row.Field<string>("MS_MAY")
                    });
                    foreach (var item in ListMay)
                    {
                        if (item.May != grvMay.GetFocusedDataRow()["MS_MAY"].ToString())
                            dtTmp.Merge(TinhGioLuyKeTheoTungMay(item.May));
                    }
                }
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetThoiGianChayMayTheoRange", grvMay.GetFocusedDataRow()["MS_MAY"].ToString(), dtTNgay.DateTime.Date, dtDNgay.DateTime.Date, txtNgayThuong.Text + "|" + txtThuBay.Text + "|" + txtChuNhat.Text, "-1"));
                dt.Columns["CHI_SO_DONG_HO"].ReadOnly = false;
                dt.Columns["SO_GIO_LUY_KE"].ReadOnly = false;
                dt.Columns["SO_GIO_LUY_KE"].AllowDBNull = true;
                TinhGioLuyKe(dt, 0, true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void cboDiaDiem_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {

            if (Commons.Modules.SQLString == "0Load") return;
            LoadDataMay();
        }
        private void cboHeThong_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadDataMay();
        }
        private void cboLoaimay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadDataMay();
        }

        private void grvRuntime_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                int chiSoDongHo = Convert.ToInt32(grvRuntime.GetFocusedDataRow()["CHI_SO_DONG_HO"].ToString());
                if (chiSoDongHo < 0)
                {
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "msgChiSoAm", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "frmThoigianchaymay", Commons.Modules.TypeLanguage), MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
                    {
                        e.Valid = false;
                        return;
                    }
                }
            }
            catch
            {
                e.Valid = false;
                return;
            }
            try
            {
                int soGioLuyKe = Convert.ToInt32(grvRuntime.GetFocusedDataRow()["SO_GIO_LUY_KE"].ToString());
                if (soGioLuyKe < 0)
                {
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "msgChiSoAm", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "frmThoigianchaymay", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Asterisk) ==
                      DialogResult.Cancel)
                    {
                        e.Valid = false;
                        return;
                    }
                }
            }
            catch
            {
                e.Valid = false;
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvRuntime.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "MsgKhongCoDuLieuXoa", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "frmThoigianchaymay", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "msgXoaDongHienTai", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "frmThoigianchaymay", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;

            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTHOI_GIAN_CHAY_MAY", grvRuntime.GetFocusedDataRow()["NGAY"].ToString(), grvMay.GetFocusedDataRow()["MS_MAY"].ToString());
            grvRuntime.DeleteRow(grvRuntime.FocusedRowHandle);
            grvRuntime.UpdateCurrentRow();
            grdRuntime.Update();
            //grvMay_FocusedRowChanged(null, null);
        }

        private void dtTNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (dtDNgay.DateTime < dtTNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "TNPhaiNhoHonBangDN", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "frmThoigianchaymay", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (btnLuu.Visible)
            {
                lnkCapNhatTungMay_Click(null, null);
                blChiSoDenNgay.Text = nnTmp + " " + dtTNgay.DateTime.Date.AddDays(-1).ToString("dd/MM/yyyy") + ": " + chiSoDenNgay.ToString();

            }
            else
            {
                LoadThoiGianChayMay();
            }
        }

        private void grvRuntime_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void txtNgayThuong_Validating(object sender, CancelEventArgs e)
        {
            if (btnLuu.Visible == false) return;
            SpinEdit txt = sender as SpinEdit;
            if ((!txt.Text.Equals(string.Empty)))
            {
                try
                {
                    if ((double.Parse(txt.Text) < 0 | double.Parse(txt.Text) > 24))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "TGKHONGHOPLE", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "frmThoigianchaymay", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "TGKHONGHOPLE", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "frmThoigianchaymay", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void txtNgayThuong_MouseUp(object sender, MouseEventArgs e)
        {
            SpinEdit txt = sender as SpinEdit;
            if (txt != null)
                txt.SelectAll();
        }

        private void txtTimMay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                try
                {
                    dt = (DataTable)grdMay.DataSource;
                    dt.DefaultView.RowFilter = "MS_MAY like '%" + txtTimMay.Text + "%'";

                    dt = dt.DefaultView.ToTable();
                }
                catch (Exception ex)
                {
                    dt.DefaultView.RowFilter = "";
                    dt = dt.DefaultView.ToTable();
                }
            }
            catch { }
        }
        int focustmp = 0;
        private void grvRuntime_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int n = e.RowHandle;
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;

                if (e.Column.FieldName == "CHI_SO_DONG_HO")
                {
                    try
                    {
                        DataTable tempt = (DataTable)grdRuntime.DataSource;
                        TinhGioLuyKe(tempt, e.RowHandle, false);
                    }
                    catch
                    {
                        return;
                    }
                }
                if (e.Column.FieldName == "SO_GIO_LUY_KE")
                {
                    try
                    {
                        DataTable tempt = (DataTable)grdRuntime.DataSource;
                        TinhGioLuyKeNhapLuyKe(tempt, e.RowHandle);
                    }
                    catch
                    {
                        return;
                    }
                }

            }
            catch { }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = grdRuntime.DataSource as DataTable;
                dt.Rows.Clear();
                grdRuntime.DataSource = dt;
            }
            catch { }

            lblThongBao.Visible = true;
            btnImport.Visible = false;
            txtChuNhat.Text = "0";
            txtThuBay.Text = "0";
            txtNgayThuong.Text = "0";
            layoutRuntime.RowStyles[0].Height = 0;
            layoutRuntime.RowStyles[2].Height = 0;
            SetVisibleButton(false);
            dtDNgay.Enabled = false;
            dtTNgay.Enabled = false;
        }
        private double TinhTongChiSoTrenLuoi()
        {
            double Tong = 0;
            grvRuntime.UpdateCurrentRow();
            grdRuntime.Update();
            for (int i = 0; i < grvRuntime.FocusedRowHandle; i++)
            {
                try
                {
                    Tong += Convert.ToDouble(grvRuntime.GetDataRow(i)["CHI_SO_DONG_HO"].ToString());
                }
                catch { }
            }
            return Tong;
        }
        private string ClipboardData
        {
            get
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (string.IsNullOrEmpty(iData.ToString()))
                {
                    return "";
                }

                if (iData.GetDataPresent(DataFormats.UnicodeText))
                {
                    return (string)iData.GetData(DataFormats.UnicodeText);
                }
                return "";
            }
            set { Clipboard.SetDataObject(value); }
        }
        private void AddRow(string data, ref DataTable dt)
        {
            if (data == string.Empty)
            {
                return;
            }
            string[] rowData = data.Split(new char[] { '\r', '\t' });
            DataRow newRow = dt.NewRow();
            newRow[0] = grvMay.GetFocusedDataRow()["MS_MAY"].ToString();
            int i = 0;
            while (i < rowData.Length - 1)
            {
                if (i >= dt.Columns.Count)
                {
                    break; // TODO: might not be correct. Was : Exit While
                }
                if (i > 0)
                {
                    try
                    {
                        newRow[i + 1] = Convert.ToDouble(rowData[i]);
                    }
                    catch
                    {
                        newRow[i + 1] = 0;
                    }
                }
                else
                {
                    newRow[i + 1] = rowData[i];
                }
                System.Math.Max(System.Threading.Interlocked.Increment(ref i), i - 1);
            }
            newRow[dt.Columns.Count - 1] = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 CASE ISNULL(COUNT(*), 0) WHEN 0 THEN 0 ELSE 1 END FROM THOI_GIAN_CHAY_MAY WHERE NGAY = '" + Convert.ToDateTime(rowData[0], new System.Globalization.CultureInfo("vi-vn")).ToString("yyyy/MM/dd") + "' AND MS_MAY = '" + newRow[0] + "'"));
            dt.Rows.Add(newRow);
        }
        private bool kiemtradl(DataTable dtSource)
        {
            bool resulst = true;
            foreach (DataRow dr in dtSource.Rows)
            {
                int n = dtSource.AsEnumerable().Where(x => x.Field<DateTime>("NGAY").Equals(Convert.ToDateTime(dr[1]))).Count();
                if (n > 1)
                {
                    resulst = false;
                    dr.SetColumnError(grvRuntime.Columns[1].FieldName.ToString(), "Ngày không thể bị trùng");
                }
                else
                {
                    dr.SetColumnError(grvRuntime.Columns[1].FieldName.ToString(), "");
                }
            }
            return resulst;
        }
        private void grvRuntime_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnImport.Visible != false) return;
            if (e.KeyCode == Keys.Delete)
            {
                grvRuntime.DeleteRow(grvRuntime.FocusedRowHandle);
                DataTable dt = (DataTable)grdRuntime.DataSource;

                if (kiemtradl(dt) == false) return;
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                try
                {
                    DataTable dt = grdRuntime.DataSource as DataTable;
                    dt.Rows.Clear();
                    try
                    {
                        dt.Columns.Remove("SO_MOVEMENT");
                    }
                    catch { }
                    try
                    {
                        dt.Columns.Remove("MS_PBT");
                    }
                    catch { }
                    try
                    {
                        dt.Columns.Add("IS_UPDATE", typeof(System.Boolean));
                    }
                    catch { }

                    string[] data = ClipboardData.Split('\n');
                    if (data.Length < 1)
                    {
                        return;
                    }
                    string error = "";
                    foreach (string row in data)
                    {
                        if (row.Split(new char[] { '\r', '\t' }).Length > 4) throw new Exception("Copy to Clipboard do not more than three columns");
                        try
                        {
                            AddRow(row, ref dt);
                        }
                        catch
                        {

                            error += row.Split(new char[] { '\r', '\t' })[0] + Environment.NewLine;
                        }
                    }
                    dtTNgay.DateTime = Convert.ToDateTime(dt.Rows[0]["NGAY"]);
                    dtDNgay.DateTime = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1]["NGAY"]);
                    autoreport(dt, 0, true);
                    grdRuntime.DataSource = dt;
                    kiemtradl(dt);
                    //grvRuntime.OptionsBehavior.Editable = true;
                    if (error != "")
                        XtraMessageBox.Show(error + Environment.NewLine + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "msgSaiDinhDang", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "frmThoigianchaymay", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.Message + Environment.NewLine + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "msgDungCauTruc", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianchaymay", "frmThoigianchaymay", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }
        private void grvRuntime_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            focustmp = e.FocusedRowHandle;
        }
        private void grvRuntime_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(e.Value);
            }
            catch (Exception)
            {
                e.Value = 0;
            }
        }

       
    }
}
