using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace ReportMain
{
    public partial class frmDNThemReport : DevExpress.XtraEditors.XtraForm
    {
        public frmDNThemReport()
        {
            InitializeComponent();
        }

        private void frmDNThemReport_Load(object sender, EventArgs e)
        {
            LoadLuoi("-1");
            LoadLoaiReport();
            LockUnLock(true);

            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void LoadLuoi(String RName)
        {
            
            DataTable dtTmp = new DataTable();
            string sSql = "SELECT [REPORT_NAME], [TEN_REPORT_VIET], [TEN_REPORT_ANH], [LOAI_REPORT],[NAMES], [TYPE],[REPORT_MAIL] " +
                            " FROM DS_REPORT WHERE LEFT(REPORT_NAME,8) = 'Addon_UC' ORDER BY REPORT_NAME";

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,CommandType.Text,sSql));
            dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["REPORT_NAME"] };
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdReport, grvReport, dtTmp, false, false, true, true);
            if (RName != "-1")
            {
                int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(RName));
                grvReport.FocusedRowHandle = grvReport.GetRowHandle(index);
            }
            grvReport.Columns["LOAI_REPORT"].Visible = false;
            grvReport.Columns["NAMES"].Visible = false;
            grvReport.Columns["TYPE"].Visible = false;
            grvReport.Columns["REPORT_MAIL"].Visible = false;
            

        }

        private void LoadLoaiReport()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGroupReports", Commons.Modules.TypeLanguage,1));
            dtTmp.Columns["TEN_L_REPORT"].ReadOnly = false;
            string str;
            foreach (DataRow drRow in dtTmp.Rows)
            {
                str = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmReports", drRow["TEN_L_REPORT"].ToString(), Commons.Modules.TypeLanguage);

                drRow["TEN_L_REPORT"] = str;
            }
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiReport, dtTmp, "MS_LOAI", "TEN_L_REPORT", lblLoaiReport.Text); 

        }

        private void LockUnLock(Boolean iLock)
        {
            txtRName.Properties.ReadOnly = iLock;
            txtTViet.Properties.ReadOnly = iLock;
            txtTAnh.Properties.ReadOnly = iLock;
            cboLoaiReport.Enabled = !iLock;
            optBCao.Properties.ReadOnly = iLock;

            btnThem.Visible = iLock;
            btnSua.Visible = iLock;
            btnXoa.Visible = iLock;
            btnThoat.Visible = iLock;

            btnGhi.Visible = !iLock;
            btnKhong.Visible = !iLock;

            grdReport.Enabled = iLock;
        }

        private void LoadTextTrong()
        {
            txtRName.Text = "";
            txtTViet.Text = "";
            txtTAnh.Text = "";
            cboLoaiReport.EditValue = 0;
            optBCao.SelectedIndex = 0;
        }

        private void LoadText()
        {
            if (grvReport.RowCount == 0) LoadTextTrong();
            else
            {
                txtRName.Text = grvReport.GetFocusedRowCellValue("REPORT_NAME").ToString();
                txtTViet.Text = grvReport.GetFocusedRowCellValue("TEN_REPORT_VIET").ToString();
                txtTAnh.Text = grvReport.GetFocusedRowCellValue("TEN_REPORT_ANH").ToString();
                cboLoaiReport.EditValue = grvReport.GetFocusedRowCellValue("LOAI_REPORT");
                if (int.Parse(grvReport.GetFocusedRowCellValue("TYPE").ToString()) == 1)
                    optBCao.SelectedIndex = 0;
                else
                    optBCao.SelectedIndex = 1;
            }
        }

        private void grvReport_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoadTextTrong();
            LockUnLock(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockUnLock(false);
            txtRName.Properties.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvReport.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDNThemReport", "KhongCoDuLieuXoa",
                    Commons.Modules.TypeLanguage));
                return;
            }

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDNThemReport","CoChaCXoa", 
                Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;



            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            SqlTransaction tran;

            if (con.State == ConnectionState.Closed)
                con.Open();
            tran = con.BeginTransaction();
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(tran, "MGetLicType", Commons.Modules.TypeLanguage));

                foreach (DataRow dr in dtTmp.Rows)
                {
                    SqlHelper.ExecuteNonQuery(tran, "MDelPQuyen", 3, Commons.Modules.ObjSystems.MaHoaDL(dr["TYPE_LIC"].ToString()),
                        Commons.Modules.ObjSystems.MaHoaDL(txtRName.Text));
                }
                string sSql;
                sSql = "DELETE FROM NHOM_REPORT WHERE REPORT_NAME = N'" + txtRName.Text + "'";
                SqlHelper.ExecuteNonQuery(tran,CommandType.Text,sSql);
                sSql = "DELETE FROM DS_REPORT WHERE REPORT_NAME = N'" + txtRName.Text + "'";
                SqlHelper.ExecuteNonQuery(tran,CommandType.Text,sSql);

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmDNThemReport", "CapNhapKhongThanhCong", Commons.Modules.TypeLanguage));

            }
            con.Close();
            LoadLuoi("-1");
            grvReport.FocusedRowHandle = grvReport.GetRowHandle(grvReport.RowCount);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
#region Kiem Ghi
            string sSql;
            DataTable dtTmp = new DataTable();

            if (txtRName.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmDNThemReport", "ChuaNhapRepotName", Commons.Modules.TypeLanguage));
                txtRName.Focus();
                return;
            }
            if (txtRName.Text.Length < 9)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmDNThemReport", "ReportNamePhaiBatDauLaAddon_uc", Commons.Modules.TypeLanguage));
                txtRName.Focus();
                return;
            }
            if (txtRName.Text.Substring(0, 8).ToString().ToUpper() != "Addon_uc".ToUpper())
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmDNThemReport", "ReportNamePhaiBatDauLaAddon_uc", Commons.Modules.TypeLanguage));
                txtRName.Focus();
                return;
            }
            if (txtTViet.Text.Trim().ToString() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmDNThemReport", "ChuaNhapTenViet", Commons.Modules.TypeLanguage));
                txtTViet.Focus();
                return;
            }
            if (txtTAnh.Text.Trim().ToString() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmDNThemReport", "ChuaNhapTenAnh", Commons.Modules.TypeLanguage));
                txtTAnh.Focus();
                return;
            }
            if (!txtRName.Properties.ReadOnly)
            {
                sSql = "SELECT * FROM DS_REPORT WHERE REPORT_NAME = N'" + txtRName.Text + "'";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmDNThemReport", "DaCoReportName", Commons.Modules.TypeLanguage));
                    txtRName.Focus();
                    return;
                }
            }
#endregion
            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            SqlTransaction tran;
            
            if (con.State == ConnectionState.Closed)
                con.Open();
            tran = con.BeginTransaction();
            try
            {

                SqlHelper.ExecuteNonQuery(tran, "MInsertDSReport", txtRName.Text, txtTViet.Text, txtTAnh.Text, 
                    cboLoaiReport.EditValue, optBCao.SelectedIndex);

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(tran, "MGetLicType", Commons.Modules.TypeLanguage));

                foreach (DataRow dr in dtTmp.Rows)
                {
                    SqlHelper.ExecuteNonQuery(tran, "MAddPQuyen", 3, Commons.Modules.ObjSystems.MaHoaDL(dr["TYPE_LIC"].ToString()),
                        Commons.Modules.ObjSystems.MaHoaDL(txtRName.Text));
                }
                tran.Commit();
            }
            catch {
                tran.Rollback();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmDNThemReport", "CapNhapKhongThanhCong", Commons.Modules.TypeLanguage));

            }
            con.Close();
            LoadLuoi(txtRName.Text);
            LockUnLock(true);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            LoadLuoi(txtRName.Text);
            LockUnLock(true);
        }

        private void grvReport_DataSourceChanged(object sender, EventArgs e)
        {
            LoadText();
        }

    }
}