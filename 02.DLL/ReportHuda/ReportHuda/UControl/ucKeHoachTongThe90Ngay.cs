using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda
{
    public partial class ucKeHoachTongThe90Ngay : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKeHoachTongThe90Ngay()
        {
            InitializeComponent();
        }
        #region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong",
                    Commons.Modules.UserName, "-1", "-1", "-1"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNXuong, _table, "MS_N_XUONG", "TEN_N_XUONG", lblNXuong.Text);
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            DataTable dtTmp = new DataTable();
            dtTmp = Commons.Modules.ObjSystems.MLoadDataDayChuyen(0);
            System.Data.DataColumn cChon = new System.Data.DataColumn("CHON", typeof(System.Boolean));
            cChon.DefaultValue = "0";
            dtTmp.Columns.Add(cChon);
            cChon.DefaultValue = false;
            cChon.SetOrdinal(0);
            dtTmp.Columns["CHON"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDChuyen, grvDChuyen, dtTmp, true, true, true, false, true, "ucKeHoachTongThe90Ngay");
            for (int i = 1; i < grvDChuyen.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            grvDChuyen.Columns["CHON"].Width = 150;
            grvDChuyen.Columns["TEN_HE_THONG"].Width = grdDChuyen.Width - 155;
            grvDChuyen.Columns["MS_HE_THONG"].Visible = false;

        }


        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }

        }
        
        #endregion

        #region Event chuan
        private void btnAll_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvDChuyen);

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvDChuyen);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion

        private void ucKeHoachTongThe90Ngay_Load(object sender, EventArgs e)
        {
            dtDNgay.DateTime = DateTime.Now;
            dtTNgay.DateTime = DateTime.Parse("01/01/" + DateTime.Now.Year.ToString());

            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdDChuyen.DataSource;
            dtTmp = dtTmp.Copy();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            #region Day Chuyen
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "ucKeHoachTongThe90Ngay", "msgChuaChonDayChuyen", Commons.Modules.TypeLanguage));
                return;
            }
            string sHT = "KHTT90_DC" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sHT, dtTmp, "");
            #endregion
        }

        private void txtTKDChuyen_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdDChuyen.DataSource;
            try
            {
                string dk = "";
                if (txtTKDChuyen.Text.Length != 0) dk = " OR  TEN_HE_THONG LIKE '%" + txtTKDChuyen.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }


    }
}
