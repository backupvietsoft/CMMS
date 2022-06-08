using System;

namespace VietShape
{
    public partial class ucPBTChuaTGNM : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPBTChuaTGNM()
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
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
        }

        private void LoadNhomMay(string sLMay)
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNMay, Commons.Modules.ObjSystems.MLoadDataNhomMay(1, sLMay), "MS_NHOM_MAY", "TEN_NHOM_MAY", "");
            }
            catch { }
        }


        #endregion

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (cboLMay.Text == "") return;
            string sLMay = "-1";
            try
            {
                sLMay = cboLMay.EditValue.ToString();
            }
            catch { sLMay = "-1"; }
            Commons.Modules.SQLString = "0LM";
            LoadNhomMay(sLMay);
            Commons.Modules.SQLString = "";
        }

        private void ucPBTChuaTGNM_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            datTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datDNgay.DateTime = datTNgay.DateTime.Date.AddMonths(1).AddDays(-1);

            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay("-1");
            Commons.Modules.SQLString = "";
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }


        private void btnExecute_Click(object sender, EventArgs e)
        {
            //sPath = "";
            //sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            //if (sPath == "") return;

            //if (datDNgay.DateTime.Date < datTNgay.DateTime.Date)
            //{
            //    Commons.MssBox.Show(sBC, "msgTuNgayLonHonDenNgay");
            //    return;
            //}

            //BeginInvoke((Action)(() =>
            //{
            //    prbIN.Properties.Stopped = false;
            //}));



            //Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
            //t.Start(true);

        }

    }
}
