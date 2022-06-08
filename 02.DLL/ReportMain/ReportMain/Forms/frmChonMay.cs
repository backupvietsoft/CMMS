using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class frmChonMay : DevExpress.XtraEditors.XtraForm
    {
        public frmChonMay()
        {
            InitializeComponent();
        }

        #region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong",
                    Commons.Modules.UserName, "-1", "-1", "-1"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, dtTmp, "MS_N_XUONG", "TEN_N_XUONG", lblDDiem.Text);
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", lblDChuyen.Text);
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void LoadBPChiuPhi()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT MS_BP_CHIU_PHI , TEN_BP_CHIU_PHI  FROM BO_PHAN_CHIU_PHI UNION SELECT '-1',' < ALL > ' ORDER BY TEN_BP_CHIU_PHI "));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBPCPhi, _table, "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", lblBPCPhi.Text);
            }
            catch { }
        }

        private void LoadNhomMay()
        {
            try
            {
                DataTable _table = new DataTable();
                try
                {
                    _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, cboLMay.EditValue.ToString());
                }
                catch { _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, "-1"); }
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, _table, "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNhomMay.Text);
            }
            catch { }

        }

        private void LoadVT()
        {
            try
            {
                string sSql = "SELECT DISTINCT  " +
                                " CONVERT(BIT, 0) AS CHON, PT.MS_PT, PT.TEN_PT, PT.TEN_PT_VIET, PT.QUY_CACH, PT.MS_PT_CTY, PT.MS_PT_NCC, HSX.TEN_HSX, PT.DVT, PT.ACTIVE_PT, CASE THEO_KHO WHEN 0 THEN ISNULL((T.SL_VT), 0) ELSE 0 END AS TON_HT " +
                                " FROM            dbo.IC_PHU_TUNG AS PT LEFT OUTER JOIN " +
                                "                          dbo.IC_PHU_TUNG_LOAI_MAY ON PT.MS_PT = dbo.IC_PHU_TUNG_LOAI_MAY.MS_PT LEFT OUTER JOIN " +
                                "                          dbo.IC_PHU_TUNG_LOAI_PHU_TUNG ON PT.MS_PT = dbo.IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT LEFT OUTER JOIN " +
                                "                          dbo.VI_TRI_KHO ON PT.MS_VI_TRI = dbo.VI_TRI_KHO.MS_VI_TRI LEFT OUTER JOIN " +
                                "                              (SELECT        MS_PT, SUM(SL_VT) AS SL_VT, MS_KHO, MS_VI_TRI " +
                                "                                FROM            dbo.VI_TRI_KHO_VAT_TU " +
                                "                                WHERE(ISNULL(SL_VT, 0) > 0) " +
                                "                                GROUP BY MS_PT, MS_KHO, MS_VI_TRI) AS T ON T.MS_VI_TRI = dbo.VI_TRI_KHO.MS_VI_TRI AND dbo.VI_TRI_KHO.MS_KHO = T.MS_KHO AND PT.MS_PT = T.MS_PT LEFT OUTER JOIN " +
                                "                          dbo.HANG_SAN_XUAT AS HSX ON PT.MS_HSX = HSX.MS_HSX " +
                                " ORDER BY PT.MS_PT, PT.TEN_PT";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, false, true);
                for (int i = 1; i <= dtTmp.Columns.Count - 1;)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                    grvChung.Columns[i].OptionsColumn.ReadOnly = true;
                    i++;
                }
                dtTmp.Columns[0].ReadOnly = false;
                grvChung.Columns[0].OptionsColumn.ReadOnly = false;

                grvChung.Columns["CHON"].Width = 80;
            }
            catch { }
        }

        private void LoadMay()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayNXHTLMBPCP", Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, false, true);
                for (int i = 1; i <= dtTmp.Columns.Count - 1;)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                    grvChung.Columns[i].OptionsColumn.ReadOnly = true;
                    i++;
                }
                dtTmp.Columns[0].ReadOnly = false;
                grvChung.Columns[0].OptionsColumn.ReadOnly = false;

                grvChung.Columns["MS_N_XUONG"].Visible = false;
                grvChung.Columns["MS_HE_THONG"].Visible = false;
                grvChung.Columns["MS_LOAI_MAY"].Visible = false;
                grvChung.Columns["MS_NHOM_MAY"].Visible = false;
                grvChung.Columns["MS_BP_CHIU_PHI"].Visible = false;
                grvChung.Columns["CHON"].Width = 80;
                grvChung.Columns["MS_MAY"].Width = 120;
                grvChung.Columns["SERIAL_NUMBER"].Width = 120;
                grvChung.Columns["TEN_MAY"].Width = 300;
                grvChung.Columns["MO_TA"].Width = 250;
            }
            catch { }

        }
        #endregion

        private void frmChonMay_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            LoadNX();
            LoadDChuyen();
            LoadBPChiuPhi();
            LoadLoaiMay();
            LoadMay();
            Commons.Modules.SQLString = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }


        private void LocDuLieu()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtMay = new DataTable();
            dtMay = (DataTable)grdChung.DataSource;
            string sDK = " AND 1 = 1 ";
            string sTK = "";
            try
            {
                if (optBCao.SelectedIndex == 0)
                {
                    if (cboDChuyen.EditValue.ToString() != "-1") sDK = sDK + " AND MS_HE_THONG = '" + cboDChuyen.EditValue.ToString() + "' ";
                    if (cboDDiem.EditValue.ToString() != "-1") sDK = sDK + " AND MS_N_XUONG = '" + cboDDiem.EditValue.ToString() + "' ";
                    if (cboBPCPhi.EditValue.ToString() != "-1") sDK = sDK + " AND MS_BP_CHIU_PHI = '" + cboBPCPhi.EditValue.ToString() + "' ";
                    if (cboLMay.EditValue.ToString() != "-1") sDK = sDK + " AND MS_LOAI_MAY = '" + cboLMay.EditValue.ToString() + "' ";
                    if (cboNhomMay.EditValue.ToString() != "-1") sDK = sDK + " AND MS_NHOM_MAY = '" + cboNhomMay.EditValue.ToString() + "' ";
                    
                    if (txtTKiem.Text.Length != 0) sTK = sTK + " OR MS_MAY LIKE '%" + txtTKiem.Text + "%' ";
                    if (txtTKiem.Text.Length != 0) sTK = sTK + " OR TEN_MAY LIKE '%" + txtTKiem.Text + "%' ";
                    if (sTK.Length > 0) sTK = " AND (" + sTK.Substring(3) + ")";
                    sDK = sDK.Substring(5);

                }
                if (optBCao.SelectedIndex == 1)
                {
                    if (txtTKiem.Text.Length != 0) sDK = " MS_PT LIKE '%" + txtTKiem.Text + "%' OR TEN_PT LIKE '%" + txtTKiem.Text + "%' OR TEN_PT_VIET LIKE '%" + txtTKiem.Text + "%'  OR MS_PT_CTY LIKE '%" + txtTKiem.Text + "%'  OR MS_PT_NCC LIKE '%" + txtTKiem.Text + "%' ";
                }


                dtMay.DefaultView.RowFilter = "(" + sDK + ")" + sTK;
            }
            catch { dtMay.DefaultView.RowFilter = ""; }
        }

        private void cboDDiem_EditValueChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void cboDChuyen_EditValueChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void cboBPCPhi_EditValueChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
            LocDuLieu();
        }

        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvChung);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvChung);
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LocDuLieu();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdChung.DataSource).Copy();

            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();

            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "ChuaChonDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string sBT = "MAY_BARCODE";
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
            dtTmp = new DataTable();
            string sSql = "";
            if(optBCao.SelectedIndex==0)
                sSql = "SELECT MS_MAY, TEN_MAY, ISNULL(SERIAL_NUMBER,'') AS SERIAL_NUMBER,NGAY_MUA FROM  " + sBT + " ORDER BY MS_MAY,TEN_MAY";
            else
                sSql = "SELECT MS_PT AS MS_MAY, TEN_PT AS TEN_MAY, ISNULL(MS_PT_CTY,'') AS SERIAL_NUMBER, CONVERT(DATETIME,NULL) AS NGAY_MUA FROM  " + sBT + " ORDER BY MS_PT,TEN_PT";

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.TableName = "MAY";
            Commons.Modules.ObjSystems.XoaTable(sBT);

            frmReport frmBC = new frmReport();
            frmBC.rptName = "rptInBarCodeMay";
            frmBC.AddDataTableSource(dtTmp);

            frmBC.ShowDialog(this);

        }


        private void optBCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optBCao.SelectedIndex == 0)
            {
                Lock(false);
                LoadMay();
            }
            else
            {
                Lock(true);
                LoadVT();
            }

        }
        private void Lock(bool locked)
        {
            cboDDiem.Properties.ReadOnly = locked;
            cboDChuyen.Properties.ReadOnly = locked;
            cboBPCPhi.Properties.ReadOnly = locked;
            cboLMay.Properties.ReadOnly = locked;
            cboNhomMay.Properties.ReadOnly = locked;
        }
    }
}