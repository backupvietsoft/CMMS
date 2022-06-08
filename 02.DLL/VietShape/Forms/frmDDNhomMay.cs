using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace VietShape
{
    public partial class frmDDNhomMay : DevExpress.XtraEditors.XtraForm
    {
        public frmDDNhomMay()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void LoadCmb()
        {
            DataTable dt = new DataTable();
            #region "Load nha xuong"
            try
            {
                dt = new DataTable();
                dt = Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1);
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cbtDDiem, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
            #endregion

            #region "Load day chuyen"
            try
            {
                dt = new DataTable();
                dt = Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1);

                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cbtDChuyen, dt, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
            #endregion

            #region "Load loai may"
            try
            {
                dt = Commons.Modules.ObjSystems.MLoadDataLoaiMay(1);
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
            #endregion

            #region "Load Nhom Dieu Do"
            LoadNhomDD();
            #endregion
        }
        private void LoadNhomDD()
        {
            #region "Load Nhom Dieu Do"
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spDDNhomMay", 1, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomDD, dt, "ID_NHOM_DD", "TEN_NHOM", "");
            }
            catch { }
            #endregion
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();
            //khi nut btnGhi.Visible = true thi la them sua luc do action la 4, nguoc lai la view = 2 
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spDDNhomMay", (btnGhi.Visible ? 4 : 2), Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            dt.Columns["ID_NHOM_DD"].ReadOnly = (btnGhi.Visible ? false : true);
            if (grdChung.DataSource == null)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dt, (btnGhi.Visible ? true : false), true, true, true, true, this.Name);
                TaoCmbLuoi();
                grvChung.Columns["MS_N_XUONG"].Visible = false;
                grvChung.Columns["MS_HE_THONG"].Visible = false;
                grvChung.Columns["MS_LOAI_MAY"].Visible = false;

                grvChung.Columns["MS_NX_CHA"].Visible = false;
                grvChung.Columns["MS_HT_CHA"].Visible = false;

                grvChung.BestFitColumns();
                grvChung.Columns["MS_MAY"].OptionsColumn.ReadOnly = true;
                grvChung.Columns["TEN_MAY"].OptionsColumn.ReadOnly = true;
                grvChung.Columns["ID_NHOM_DD"].OptionsColumn.ReadOnly = false;
            }
            else Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dt, (btnGhi.Visible ? true : false), false, true, false, true, this.Name);
            LocDuLieu();
        }

        private void TaoCmbLuoi() {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spDDNhomMay", 3, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            RepositoryItemLookUpEdit cboNhomDD = new RepositoryItemLookUpEdit();
            cboNhomDD.Name = "LOAI_CV";
            cboNhomDD.DataSource = dtTmp;
            cboNhomDD.NullText = "";
            cboNhomDD.PopulateColumns();
            cboNhomDD.ValueMember = "ID_NHOM_DD";
            cboNhomDD.DisplayMember = "TEN_NHOM";
            cboNhomDD.Columns["ID_NHOM_DD"].Visible = false;
            cboNhomDD.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cboNhomDD.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            cboNhomDD.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            cboNhomDD.ShowHeader = false;
            grvChung.Columns["ID_NHOM_DD"].ColumnEdit = cboNhomDD;
        }


        private void frmDDNhomMay_Load(object sender, EventArgs e)
        {
            LoadCmb();
            LoadData();
        }

        private void cboNhomDD_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index != 1) return;
            frmDDNhom frm = new frmDDNhom();
            frm.ShowDialog();
            LoadNhomDD();
        }
        private void ThemSua()
        {
            btnGhi.Visible = !btnGhi.Visible;
            btnKhongghi.Visible = !btnKhongghi.Visible;
            btnAll.Visible = !btnAll.Visible;
            btnNoAll.Visible = !btnNoAll.Visible;
            btnThemSua.Visible = !btnThemSua.Visible;
            btnThoat.Visible = !btnThoat.Visible;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnThemSua_Click(object sender, EventArgs e)
        {
            ThemSua();
            LoadData();
        }
        private void btnKhongghi_Click(object sender, EventArgs e)
        {
            ThemSua();
            LoadData();
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            string sBT = "DDNhomMayCNTmp" + Commons.Modules.UserName;
            DataTable dtTmp = new DataTable();
            SqlConnection sql = new SqlConnection(Commons.IConnections.ConnectionString);
            if (sql.State == ConnectionState.Closed)
                sql.Open();

            SqlTransaction tran = null;
            tran = sql.BeginTransaction();
            try
            {

                if (grdChung.DataSource == null) return;
                dtTmp = (DataTable)grdChung.DataSource;
                if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, ""))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTaoTableDDKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tran.Rollback();
                    return;
                }
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE dbo.DIEU_DO_NHOM_MAY  INSERT INTO dbo.DIEU_DO_NHOM_MAY(ID_NHOM_DD, MS_MAY, GHI_CHU) SELECT ID_NHOM_DD, MS_MAY, GHI_CHU FROM " + sBT + " WHERE ID_NHOM_DD <> -99");
                Commons.Modules.ObjSystems.XoaTable(sBT);
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ThemSua();
            LoadData();
        }


        private void LocDuLieu()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (cbtDDiem.EditValue == null) return;
            if (cbtDChuyen.EditValue == null) return;
            if (cboLMay.EditValue == null) return;
            if (cboNhomDD.EditValue == null) return;

            DataTable dtTmp = new DataTable();
            string sDK = " (1 = 1) ";
            try
            {
                if (txtTKiem.Text.Length != 0) sDK = sDK + " AND (  (MS_MAY LIKE '%" + txtTKiem.Text + "%') OR  (TEN_MAY LIKE '%" + txtTKiem.Text + "%')) ";
                if (grdChung.DataSource == null) return;
                dtTmp = (DataTable)grdChung.DataSource;
                if (cbtDDiem.EditValue.ToString() != "-1")
                    sDK = sDK + " AND (MS_N_XUONG = '" + cbtDDiem.EditValue.ToString() + "' OR MS_NX_CHA LIKE '%" + cbtDDiem.EditValue.ToString() + "%') ";
                if (cbtDChuyen.EditValue.ToString() != "-1")
                    sDK = sDK + " AND (MS_HE_THONG = " + cbtDChuyen.EditValue.ToString() + " OR MS_HT_CHA LIKE '%" + cbtDChuyen.EditValue.ToString() + "%') ";
                if (cboLMay.EditValue.ToString() != "-1")
                    sDK = sDK + " AND (MS_LOAI_MAY = '" + cboLMay.EditValue.ToString() + "')  ";
                if (cboNhomDD.EditValue.ToString() != "-1")
                    sDK = sDK + " AND (ID_NHOM_DD = '" + cboNhomDD.EditValue.ToString() + "')  ";
                dtTmp.DefaultView.RowFilter = sDK;
            }
            catch 
            { dtTmp.DefaultView.RowFilter = ""; }
        }

        private void cbtDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LocDuLieu();
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LocDuLieu();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            frmDDNhom frm = new frmDDNhom();
            frm.iLoai = -99;
            if (frm.ShowDialog() == DialogResult.Cancel) return;
            DialogResult sRes;
            sRes = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanMuonCapNhapCacMayNull(Y)HayAllMay(N)HayKhongCapNhap(C)", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (sRes == DialogResult.Cancel) return;
            try
            {
                for (int i = 0; i < grvChung.RowCount; i++)
                {
                    if (sRes == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(grvChung.GetRowCellValue(i, "ID_NHOM_DD").ToString().Trim()))
                            grvChung.SetRowCellValue(i, "ID_NHOM_DD", frm.iLoai);
                    }
                    else
                        grvChung.SetRowCellValue(i, "ID_NHOM_DD", frm.iLoai);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNoAll_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult sRes;
                sRes = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanMuonCapNhapCacMayNullTheoNhomDD(Y)HayAllMay(N)HayKhongCapNhap(C)", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (sRes == DialogResult.Cancel) return;
                int iDD = -1;
                int.TryParse(grvChung.GetFocusedRowCellValue("ID_NHOM_DD").ToString(), out iDD);

                for (int i = 0; i < grvChung.RowCount; i++)
                {
                    if (sRes == DialogResult.Yes)
                    {
                        if (int.Parse(grvChung.GetRowCellValue(i, "ID_NHOM_DD").ToString().Trim()) == iDD)
                            grvChung.SetRowCellValue(i, "ID_NHOM_DD", null);
                    }
                    else
                        grvChung.SetRowCellValue(i, "ID_NHOM_DD", null);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
