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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Reflection;

namespace VietShape
{
    public partial class frmDDNhom : DevExpress.XtraEditors.XtraForm
    {
        public Int64 iLoai = -1;  //-1 load form binh thuong -- -99 load form chon dieu do nhom

        public frmDDNhom()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNNNew(this);

        }
        private void LoadNhom(Int64 iMSo)
        {
            try
            {
                Commons.Modules.SQLString = "0Load";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spDDNhom", 1, -1, "-1", "-1", "-1", "-1"));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["ID_NHOM_DD"] };

                if (grdChung.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true, true, this.Name);
                    grvChung.Columns["ID_NHOM_DD"].Visible = false;
                }
                else Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, false, true, false, true, this.Name);

                Commons.Modules.SQLString = "";
                if (iMSo != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(iMSo));
                    grvChung.FocusedRowHandle = grvChung.GetRowHandle(index);
                }
                else grvChung_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmDDNhom_Load(object sender, EventArgs e)
        {
            ThemSua(false);
            LoadNhom(-1);
            if (iLoai == -99)
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnGhi.Visible = false;
                btnKhongghi.Visible = false;
                btnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "btnChon", Commons.Modules.TypeLanguage);
                btnXoa.Image = null;
            }
        }

        private void grvChung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadText();
        }
        private void LoadTextNull() { txtID.Text = "-1"; txtTViet.Text = ""; txtTAnh.Text = ""; txtTHoa.Text = ""; txtGChu.Text = ""; }
        private void LoadText()
        {
            try
            {
                txtID.Text = grvChung.GetFocusedRowCellValue("ID_NHOM_DD").ToString();
                txtTViet.Text = grvChung.GetFocusedRowCellValue("TEN_NHOM").ToString();
                txtTAnh.Text = grvChung.GetFocusedRowCellValue("TEN_NHOM_ANH").ToString();
                txtTHoa.Text = grvChung.GetFocusedRowCellValue("TEN_NHOM_HOA").ToString();
                txtGChu.Text = grvChung.GetFocusedRowCellValue("GHI_CHU").ToString();
            }
            catch { LoadTextNull(); }

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (iLoai == -99) DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua(true);
            LoadTextNull();
            txtID.Text = "-1";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ThemSua(true);
        }
        private void ThemSua(Boolean TSua)
        {
            txtTViet.Properties.ReadOnly = !TSua;
            txtTAnh.Properties.ReadOnly = !TSua;
            txtTHoa.Properties.ReadOnly = !TSua;
            txtGChu.Properties.ReadOnly = !TSua;

            btnThem.Visible = !TSua;
            btnSua.Visible = !TSua;
            btnXoa.Visible = !TSua;
            btnThoat.Visible = !TSua;

            btnGhi.Visible = TSua;
            btnKhongghi.Visible = TSua;
            grdChung.Enabled = !TSua;
        }
        private void btnKhongghi_Click(object sender, EventArgs e)
        {

            try
            {
                LoadNhom(Convert.ToInt64(txtID.Text));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadNhom(-1);
            }
            ThemSua(false);
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (txtTViet.Text.ToString().Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "msgChuaNhapTenNhomTV", Commons.Modules.TypeLanguage));
                return;
            }
            try
            {
                Int64 iID = -1;
                iID = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spDDNhom", 2, txtID.Text, txtTViet.Text, txtTAnh.Text, txtTHoa.Text, txtGChu.Text).ToString());
                LoadNhom(iID);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadNhom(-1);
            }
            ThemSua(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (iLoai == -99) {
                if (iLoai == -99) DialogResult = DialogResult.Yes;
                Int64.TryParse(grvChung.GetFocusedRowCellValue("ID_NHOM_DD").ToString(), out iLoai);                
                this.Close();

            }
            else
            {
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoMuonXoaNhomDieuDo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                Int16 iID = -1;
                iID = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spDDNhom", 3, txtID.Text, txtTViet.Text, txtTAnh.Text, txtTHoa.Text, txtGChu.Text).ToString());
                if (iID == 1)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "msgNhomDDDuocSuDungTrongNhomNhanVienKhongTheXoa", Commons.Modules.TypeLanguage));
                    return;
                }
                if (iID == 2)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "msgNhomDDDuocSuDungTrongNhomMayKhongTheXoa", Commons.Modules.TypeLanguage));
                    return;
                }
                if (iID == 3)
                {
                    LoadNhom(-1);
                }
                else
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            this.Name, "msgXoaKhongThanhCong", Commons.Modules.TypeLanguage));
                    return;
                }
            }
        }

        private void grvChung_DoubleClick(object sender, EventArgs e)
        {
            if (iLoai == -99)
            {
                try
                {
                    DXMouseEventArgs ea = e as DXMouseEventArgs;
                    GridView view = sender as GridView;
                    GridHitInfo info = view.CalcHitInfo(ea.Location);
                    if (info.InRow || info.InRowCell)
                    {
                        string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                        Int64.TryParse(grvChung.GetFocusedRowCellValue("ID_NHOM_DD").ToString(), out iLoai);
                        DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                }
                catch { }
            }
        }
    }
}
