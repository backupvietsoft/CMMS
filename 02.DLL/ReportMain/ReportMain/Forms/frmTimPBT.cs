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
    public partial class frmTimPBT : DevExpress.XtraEditors.XtraForm
    {
#region Khai Bao Bien 
        #region Tu Ngay
        private DateTime dTuNgay;
        public DateTime TuNgay { get { return dTuNgay; } set { dTuNgay = value; } }
        #endregion

        #region Den Ngay
        private DateTime dDenNgay;
        public DateTime DenNgay { get { return dDenNgay; } set { dDenNgay = value; } }
        #endregion

        #region Tinh
        private string sMsTinh;
        public string MsTinh { get { return sMsTinh; } set { sMsTinh = value; } }
        #endregion

        #region Quan
        private string sMsQuan;
        public string MsQuan { get { return sMsQuan; } set { sMsQuan = value; } }
        #endregion

        #region Duong
        private string sMsDuong;
        public string MsDuong { get { return sMsDuong; } set { sMsDuong = value; } }
        #endregion

        #region Dia Diem
        private string sDiaDiem;
        public string DiaDiem { get { return sDiaDiem; } set { sDiaDiem = value; } }
        #endregion

        #region Day Chuyen
        private int iDayChuyen = -1;
        public int MsDayChuyen { get { return iDayChuyen; } set { iDayChuyen = value; } }
        #endregion

        #region Loai May
        private string sLoaiMay;
        public string LoaiMay { get { return sLoaiMay; } set { sLoaiMay = value; } }
        #endregion

        #region Nhom May
        private string sNhomMay;
        public string NhomMay { get { return sNhomMay; } set { sNhomMay = value; } }
        #endregion

        #region Ms May
        private string sMsMay;
        public string MsMay { get { return sMsMay; } set { sMsMay = value; } }
        #endregion

        #region Loai Bao Tri
        private int iLoaiBaoTri = -1;
        public int LoaiBaoTri { get { return iLoaiBaoTri; } set { iLoaiBaoTri = value; } }
        #endregion





        #region Nguoi Lap
        private string sNguoiLap;
        public string NguoiLap { get { return sNguoiLap; } set { sNguoiLap = value; } }
        #endregion

        #region Nguoi Giam sat
        private string sNguoiGSat;
        public string NguoiGSat { get { return sNguoiGSat; } set { sNguoiGSat = value; } }
        #endregion

        #region Nguyen Nhan
        private int iNguyenNhan = -1;
        public int NguyenNhan { get { return iNguyenNhan; } set { iNguyenNhan = value; } }
        #endregion

        private string _dkloc = "";
        
#endregion

#region Load Du Lieu
        private void LoadTinh()
        {
            //Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTinh,Commons.Modules.ObjSystems.MLoadDataTinh(1) , "MA_QG", "TEN_QG", lblTinh.Text);
        }

        private void LoadQuan(string MsTinh)
        {
            //Commons.Modules.ObjSystems.MLoadLookUpEdit(cboQuan, Commons.Modules.ObjSystems.MLoadDataQuan(1,MsTinh), "MA_QG", "TEN_QG", lblQuan.Text);
        }

        private void LoadDuong(string MsTinh, string MsQuan)
        {
            //Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDuong, Commons.Modules.ObjSystems.MLoadDataDuong(1, MsTinh, MsQuan), "MS_DUONG", "DUONG_TV", lblDuong.Text);
        }

        private void LoadNX()
        {
            //if (cboTinh.EditValue == null) return;
            //if (cboQuan.EditValue == null) return;
            //if (cboDuong.EditValue == null) return;
            try
            {
                DataTable _table = new DataTable();
                _table = Commons.Modules.ObjSystems.MLoadDataNhaXuong(1, "-1", "-1", "-1");
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, _table, "MS_N_XUONG", "TEN_N_XUONG", lblDDiem.Text);

                if (_dkloc  != "")
                    cboDDiem.EditValue = DiaDiem;
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", lblDChuyen.Text);
                if (_dkloc != "")
                    cboDChuyen.EditValue = MsDayChuyen;
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
        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0load") return;
            try
            {
                if ( 
                    cboDDiem.EditValue.ToString() == "" || cboDChuyen.EditValue.ToString() == "" || cboLMay.EditValue.ToString() == "" || cboNhomMay.EditValue.ToString() == "" )
                    return;

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayPBT",datTNgay.DateTime,datDNgay.DateTime,
                        "-1","-1","-1",
                        cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboMay, dtTmp, "MS_MAY", "TEN_MAY", this.Name);

                if (_dkloc != "")
                    cboMay.EditValue = MsMay;
                else
                    cboMay.EditValue = "-1";
            }
            catch { }
        }

        private void LoadLoaiBaoTri()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLBTri, "SELECT MS_LOAI_BT, TEN_LOAI_BT, THU_TU FROM LOAI_BAO_TRI  " +
                " UNION SELECT -1,' < ALL > ', 0 ORDER BY THU_TU ", "MS_LOAI_BT", "TEN_LOAI_BT", lblLBTri.Text);
                if (_dkloc != "")
                    cboLBTri.EditValue = LoaiBaoTri;
            }
            catch { }

        }

        private void LoadNLap()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCongNhanPBTTN", 2, "-1"));
                DataRow drRow = dtTmp.NewRow();
                drRow["MS_CONG_NHAN"] = "-1";
                drRow["HO_TEN_CONG_NHAN"] = " < ALL > ";
                dtTmp.Rows.Add(drRow);
                dtTmp.DefaultView.Sort = "HO_TEN_CONG_NHAN";
                dtTmp = dtTmp.DefaultView.ToTable();
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNLap, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", lblNguoiLap.Text);
                if (_dkloc != "")
                    cboNLap.EditValue = NguoiLap;
            }
            catch { }
        }

        private void LoadNGSat()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCongNhanPBTTN", 3, "-1"));
                DataRow drRow = dtTmp.NewRow();
                drRow["MS_CONG_NHAN"] = "-1";
                drRow["HO_TEN_CONG_NHAN"] = " < ALL > ";
                dtTmp.Rows.Add(drRow);
                dtTmp.DefaultView.Sort = "HO_TEN_CONG_NHAN";
                dtTmp = dtTmp.DefaultView.ToTable();
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNGSat, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", lblNGSat.Text);
                if (_dkloc != "")
                    cboNGSat.EditValue = NguoiGSat;
            }
            catch { }
        }

        private void LoadNNhan()
        {
            
                 try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNNhan, "SELECT MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY UNION SELECT -1,' < ALL > ' ORDER BY TEN_NGUYEN_NHAN ",
                        "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN", lblNNhan.Text);
                if (_dkloc != "")
                    cboNNhan.EditValue = NguyenNhan;
            }
            catch { }
        }

        #endregion
        #region Change du lieu
        public static int MonthDiff(DateTime from, DateTime to)
        {
            if (from > to)
            {
                var temp = from;
                from = to;
                to = temp;
            }

            var months = 0;
            while (from <= to) 
            {
                from = from.AddMonths(1);
                months++;
            }

            return months - 1;
        }

        private void cboTinh_EditValueChanged(object sender, EventArgs e)
        {
            //if (Commons.Modules.SQLString == "0load") return;
            //try
            //{
            //    if (cboTinh.EditValue != null) LoadQuan(cboTinh.EditValue.ToString());
            //    if (cboTinh.EditValue != null && cboQuan.EditValue != null) LoadDuong(cboTinh.EditValue.ToString(), cboQuan.EditValue.ToString());
            //    LoadNX();
            //}
            //catch { }

        }

        private void cboQuan_EditValueChanged(object sender, EventArgs e)
        {
            //if (Commons.Modules.SQLString == "0load") return;
            //try
            //{
            //    if (cboTinh.EditValue != null && cboQuan.EditValue != null) LoadDuong(cboTinh.EditValue.ToString(), cboQuan.EditValue.ToString());
            //    LoadNX();
            //}
            //catch { }
        }

        private void cboDuong_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0load") return;
            LoadNX();
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0load") return;
            LoadNhomMay();
        }

        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0load") return;
            LoadMay();
        }

        #endregion

        public frmTimPBT()
        {
            InitializeComponent();
            _dkloc = "";
        }
        public frmTimPBT(string dkLoc)
        {
            InitializeComponent();
            _dkloc = dkLoc;
            //TuNgay|DenNgay|MsDayChuyen|LoaiMay|NhomMay|MsMay|LoaiBaoTri|NguoiLap|NguoiGSat|NguyenNhan|DiaDiem
            try
            {
                TuNgay = DateTime.Parse(_dkloc.Split('|')[0].ToString());
                DenNgay = DateTime.Parse(_dkloc.Split('|')[1].ToString());
                MsDayChuyen = Int32.Parse(_dkloc.Split('|')[2].ToString());
                LoaiMay = _dkloc.Split('|')[3].ToString();
                NhomMay = _dkloc.Split('|')[4].ToString();
                MsMay = _dkloc.Split('|')[5].ToString();
                LoaiBaoTri = Int32.Parse(_dkloc.Split('|')[6].ToString());
                NguoiLap = _dkloc.Split('|')[7].ToString();
                NguoiGSat = _dkloc.Split('|')[8].ToString();
                NguyenNhan = Int32.Parse(_dkloc.Split('|')[9].ToString());
                DiaDiem = _dkloc.Split('|')[10].ToString();
            }
            catch (Exception)
            {

               
            }
            
        }

        private void frmTimPBT_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            Commons.Modules.SQLString = "0load";
            DateTime Ngay;
            Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year + "/01");

            if (TuNgay != null)
                datTNgay.DateTime = TuNgay;
            else
                datTNgay.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year + "/01");
            if (DenNgay != null)
                datDNgay.DateTime = DenNgay;
            else
                datDNgay.DateTime = DateTime.Now;
            //LoadTinh();
            //oadQuan("-1");
            //LoadDuong("-1", "-1");
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay();
            Commons.Modules.SQLString = "";
            LoadMay();
            LoadLoaiBaoTri();
            LoadNLap();
            LoadNGSat();
            LoadNNhan();
            

#region MacDinh
            try {if (dTuNgay.ToString() != "01/01/0001 00:00:00") datTNgay.DateTime = dTuNgay;}catch { }
            try{if (dDenNgay.ToString() != "01/01/0001 00:00:00") datDNgay.DateTime = dDenNgay;}catch { }
            //try{if (sMsTinh.ToString() != "") cboTinh.EditValue = sMsTinh;}catch { }
            //try{if (sMsQuan.ToString() != "") cboQuan.EditValue = sMsQuan;}catch { }
            //try{if (sMsDuong.ToString() != "") cboDuong.EditValue = sMsDuong;}catch { }
            try{if (sDiaDiem.ToString() != "") cboDDiem.EditValue = sDiaDiem;}catch { }
            try{if (iDayChuyen != -1) cboDChuyen.EditValue = iDayChuyen;}catch { }
            try{if (sLoaiMay.ToString() != "") cboLMay.EditValue = sLoaiMay;}catch { }
            try{if (sNhomMay.ToString() != "") cboNhomMay.EditValue = sNhomMay;}catch { }
            try{if (sMsMay.ToString() != "") cboMay.EditValue = sMsMay;}catch { }
            try{if (iLoaiBaoTri != -1) cboLBTri.EditValue = iLoaiBaoTri;}catch { }
#endregion

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            dTuNgay = datTNgay.DateTime;
            dDenNgay = datDNgay.DateTime;
            //sMsTinh = cboTinh.EditValue.ToString();
            //sMsQuan = cboQuan.EditValue.ToString();
            //sMsDuong = cboDuong.EditValue.ToString();

            
            sDiaDiem = cboDDiem.EditValue.ToString();
            iDayChuyen = int.Parse( cboDChuyen.EditValue.ToString());
            sLoaiMay = cboLMay.EditValue.ToString();
            sNhomMay = cboNhomMay.EditValue.ToString();
            sMsMay = cboMay.EditValue.ToString();
            iLoaiBaoTri = int.Parse(cboLBTri.EditValue.ToString());

            sNguoiLap = cboNLap.EditValue.ToString();
            sNguoiGSat = cboNGSat.EditValue.ToString();
            iNguyenNhan = int.Parse(cboNNhan.EditValue.ToString());

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}