using Commons;
using Commons.VS.Classes.Catalogue;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmGiamSatTinhTrangNew : DevExpress.XtraEditors.XtraForm
    {
        public frmGiamSatTinhTrangNew()
        {
            InitializeComponent();
            dtFromDate.EditValue = DateTime.Now.AddYears(-4);
            dtToDate.EditValue = DateTime.Now.AddYears(5);
            LoadListOfMonitoring();
        }

        private void LoadListOfMonitoring()
        {
            DataTable dtTmp = new DataTable();
            dtTmp = new GIAM_SAT_TINH_TRANGController().GetGIAM_SAT_TINH_TRANG_ALL(dtFromDate.DateTime.ToString("yyyy/MM/dd"), dtToDate.DateTime.ToString("yyyy/MM/dd"), "-1");
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdListMonitoring, grvListMonitoring, dtTmp, false, true, true, false, true, "frmGiamSatTinhTrang");

            grvListMonitoring.Columns["MS_CONG_NHAN"].Visible = false;
            grvListMonitoring.Columns["DEN_GIO"].Visible = false;
            grvListMonitoring.Columns["STT"].Visible = false;
            if (grvListMonitoring.RowCount == 0)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
               // BindData5();
            }
            else
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            grvListMonitoring.Columns["NGAY_KT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            grvListMonitoring.Columns["NGAY_KT"].DisplayFormat.FormatString = "d";

            grvListMonitoring.Columns["GIO_KT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            grvListMonitoring.Columns["GIO_KT"].DisplayFormat.FormatString = "HH:mm:ss";
            grvListMonitoring.Columns["MS_MAY"].Width = 100;
            grvListMonitoring.Columns["TEN_MAY"].Width = 100;
            grvListMonitoring.Columns["NGAY_KT"].Width = 100;
            grvListMonitoring.Columns["GIO_KT"].Width = 100;
            grvListMonitoring.Columns["HO_TEN"].Width = 150;
        }

        private void dtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            LoadListOfMonitoring();
        }

        private void grvListMonitoring_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            txtMonitoringID.Text = grvListMonitoring.GetFocusedDataRow()["SO_PHIEU"].ToString();
            txtComplain.Text = grvListMonitoring.GetFocusedDataRow()["NHAN_XET"].ToString();
            //txtTotalHours.Text = grvListMonitoring.GetFocusedDataRow()["SO_PHIEU"].ToString();
            //dtPlanDate.EditValue = grvListMonitoring.GetFocusedDataRow()["NGAY_KH"].ToString();
            dtCheck.EditValue = grvListMonitoring.GetFocusedDataRow()["NGAY_KT"].ToString();
            tCheck.Text = grvListMonitoring.GetFocusedDataRow()["GIO_KT"].ToString();
            cboStaff.EditValue = grvListMonitoring.GetFocusedDataRow()["MS_CONG_NHAN"].ToString();
        }

        private void frmGiamSatTinhTrangNew_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}