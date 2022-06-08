using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmNhapNhanSuPBT : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapNhanSuPBT()
        {
            InitializeComponent();
        }
        #region Load Du Lieu

        private void LoadNX()
        {
            try
            {

                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                DataTable _table = new DataTable();
                _table = Commons.Modules.ObjSystems.MLoadDataLoaiMay(1);
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, _table, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
            
        }

        private void LoadLoaiBT()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetLoaiBaoTri"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLBTri, _table, "MS_LOAI_BT", "TEN_LOAI_BT", lblLBaoTri.Text);
            }
            catch { }
        }

        #endregion

        private void frmNhapNhanSuPBT_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0load";
            DateTime Ngay;
            Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datTNgay.DateTime = Ngay;
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadLoaiBT();            
            Commons.Modules.SQLString = "";
            LoadPhieuBT();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void LoadPhieuBT()
        {
            try
            {
                if (Commons.Modules.SQLString == "0load") return;
                string sDiaDiem = "";
                string sDayChuyen = "";

                try
                {
                    if (cboDDiem.EditValue.ToString() == "-1")
                        sDiaDiem = cboDDiem.EditValue.ToString();
                }
                catch { sDiaDiem = "-1"; }
                try
                {
                    if (cboDChuyen.EditValue.ToString() == "-1")
                        sDayChuyen = cboDChuyen.EditValue.ToString();
                }
                catch { sDayChuyen = "-1"; }

                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPBTNS",datTNgay.DateTime.Date, datDNgay.DateTime.Date,Commons.Modules.UserName,sDiaDiem,int.Parse(sDayChuyen)));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["MS_PHIEU_BAO_TRI"] };
                dt.Columns["CHON"].ReadOnly = false;
                if (grdBT.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdBT, grvBT, dt, true, true, false, true, true, this.Name);
                    grvBT.Columns["MS_LOAI_MAY"].Visible = false;
                    grvBT.Columns["MS_LOAI_BT"].Visible = false;

                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdBT, grvBT, dt, true, false, false, false, true, this.Name);
                }
                for (int i = 1; i <= grvBT.Columns.Count - 1; i++)
                {
                    
                    dt.Columns[i].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }

        }

        private void cboDDiem_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {
            LoadPhieuBT();
        }

        private void cboDChuyen_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {
            LoadPhieuBT();
        }

        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadPhieuBT();
        }

        private void datDNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadPhieuBT();
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBT);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBT);
        }

        private void TimKiem()
        {
            if (Commons.Modules.SQLString == "0load") return;
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";

            try
            {
                if (cboLBTri.EditValue.ToString() != "-1") sdkien = sdkien + " AND ( MS_LOAI_BT = " + cboLBTri.EditValue.ToString() + " ) ";
            }
            catch
            { }
            

            try
            { if (cboLMay.EditValue.ToString() != "-1") sdkien = sdkien + " AND ( MS_LOAI_MAY = '" + cboLMay.EditValue.ToString() + "' ) "; }
            catch { }
            

            sdkien = "( " + sdkien + ") ";

            try
            {

                dtTmp = (DataTable)grdBT.DataSource;
                if (txtTKiem.Text.Length != 0) sdkien = sdkien + " AND (MS_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_MAY LIKE '%" +
                    txtTKiem.Text + "%' OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTKiem.Text + "%'  OR MS_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_BT LIKE '%" + txtTKiem.Text + "%' OR TEN_BP_CHIU_PHI LIKE '%" + txtTKiem.Text + "%' OR MS_LOAI_MAY LIKE '%" + txtTKiem.Text + "%')  ";



                dtTmp.DefaultView.RowFilter = sdkien;
            }
            catch (Exception EX)
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }


        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            TimKiem();
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void cboLBTri_EditValueChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void btnChonNS_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdBT.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            String sBT = "PBT_TMP" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, dtTmp, "");

        }
    }
}
