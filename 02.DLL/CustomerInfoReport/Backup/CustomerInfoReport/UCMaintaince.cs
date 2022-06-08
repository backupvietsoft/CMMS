using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace CustomerInfoReport
{
    public partial class UCMaintaince : UserControl
    {
        public UCMaintaince()
        {
            InitializeComponent();
        }
        private void LoadCity()
        {
            try
            {
                var lst = new CustomInfoDataContext(Conn).Y_Tinhs.OrderBy(pr => pr.ma_qg);
                cmbCity.DataSource = lst;
                cmbCity.DisplayMember = "Ten_QG";
                cmbCity.ValueMember = "Ma_QG";
            }
            catch { }
        }
        private void LoadNguoiTH()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Conn, "SP_NHU_Y_GET_CONG_NHAN"));
            cmbNguoiThucHien.DataSource = _table;
            cmbNguoiThucHien.DisplayMember = "TEN_CONG_NHAN";
            cmbNguoiThucHien.ValueMember  = "MS_CONG_NHAN";
                
        }
        private void LoadDistrict(string code)
        {

            var lst = new CustomInfoDataContext(Conn).Y_Districts.OrderBy(pr => pr.ma_qg).ToList();
            if (code != "-1")
            {
                lst = lst.Where(pr => pr.ms_cha.Equals(code)).OrderBy(pr => pr.ma_qg).ToList();
                List<Y_District> objY = new List<Y_District>();
                Y_District obj = new Y_District();
                obj.ma_qg = "-1";
                obj.ten_qg = "All";
                objY = lst;
                objY.Insert(0, obj);
                cmbDistrict.DataSource = objY;
                cmbDistrict.DisplayMember = "Ten_QG";
                cmbDistrict.ValueMember = "Ma_QG";
            }
            else
            {
                List<Y_District> objY = new List<Y_District>();
                Y_District obj = new Y_District();
                obj.ma_qg = "-1";
                obj.ten_qg = "All";
                objY.Insert(0, obj);
                cmbDistrict.DataSource = objY;
                cmbDistrict.DisplayMember = "Ten_QG";
                cmbDistrict.ValueMember = "Ma_QG";
            }
        }
        private void LoadStreet(string code)
        {

            if (code != "-1")
            {
                var lst = new CustomInfoDataContext(Conn).Y_Duongs.OrderBy(pr => pr.Duong_TV).ToList();
                lst = lst.Where(pr => pr.MS_Quan.Equals(code)).OrderBy(pr => pr.Duong_TV).ToList();
                List<Y_Duong> objY = new List<Y_Duong>();
                Y_Duong obj = new Y_Duong();
                obj.MS_Duong = "-1";
                obj.Duong_TV = "All";
                objY = lst;
                objY.Insert(0, obj);
                cmbStreet.DataSource = objY;
                cmbStreet.DisplayMember = "Duong_TV";
                cmbStreet.ValueMember = "MS_Duong";
            }
            else
            {

                var lst = new CustomInfoDataContext(Conn).View_Duong_Not_Districts.Where(pr => pr.ms_Tinh.Equals(cmbCity.SelectedValue.ToString())).OrderBy(pr => pr.ten_v).ToList();
                List<View_Duong_Not_District> objY = new List<View_Duong_Not_District>();
                View_Duong_Not_District obj = new View_Duong_Not_District();
                obj.ms_Duong = "-1";
                obj.ten_v = "All";
                objY = lst;
                objY.Insert(0, obj);
                cmbStreet.DataSource = objY;
                cmbStreet.DisplayMember = "ten_v";
                cmbStreet.ValueMember = "ms_Duong";
            }
        }
        private void LoadFactory(string city,string district, string street)
        {

            cmbFactory.DataSource = new CustomInfoDataContext(Conn).Get_Nha_Xuong_All(city, district, street);
            cmbFactory.DisplayMember = "TEN_N_XUONG";
            cmbFactory.ValueMember = "MS_N_XUONG";
           
        }


        private void LoadCatMachine()
        {
            var lst = new CustomInfoDataContext(Conn).LOAI_MAYs.ToList();
            List<LOAI_MAY> objY = new List<LOAI_MAY>();
            LOAI_MAY obj = new LOAI_MAY();
            obj.MS_LOAI_MAY = "-1";
            obj.TEN_LOAI_MAY = "All";
            objY = lst;
            objY.Insert(0, obj);
            cmbCatMachine.DataSource = objY;
            cmbCatMachine.DisplayMember = "TEN_LOAI_MAY";
            cmbCatMachine.ValueMember = "MS_LOAI_MAY";
        }
        private void LoadGroupMachine(string catMachine)
        {
            var lst = new CustomInfoDataContext(Conn).NHOM_MAYs.ToList();
            List<NHOM_MAY> objY = new List<NHOM_MAY>();
            NHOM_MAY obj = new NHOM_MAY();
            if (catMachine != "-1")
            {
                lst = lst.Where(pr => pr.MS_LOAI_MAY.Equals(catMachine)).ToList();
                obj.MS_NHOM_MAY = "-1";
                obj.TEN_NHOM_MAY = "All";
                objY = lst;
                objY.Insert(0, obj);
                cmbGroupMachine.DataSource = objY;
                cmbGroupMachine.DisplayMember = "TEN_NHOM_MAY";
                cmbGroupMachine.ValueMember = "MS_NHOM_MAY";
            }
            else
            {
                obj.MS_NHOM_MAY = "-1";
                obj.TEN_NHOM_MAY = "All";

                objY.Insert(0, obj);
                cmbGroupMachine.DataSource = objY;
                cmbGroupMachine.DisplayMember = "TEN_NHOM_MAY";
                cmbGroupMachine.ValueMember = "MS_NHOM_MAY";
            }
        }
        private void LoadMaintaince()
        {
            var lst = new CustomInfoDataContext(Conn).LOAI_BAO_TRIs.ToList();
            
            cmbMaintaint.DataSource = lst;
            cmbMaintaint.DisplayMember = "TEN_LOAI_BT";
            cmbMaintaint.ValueMember = "MS_LOAI_BT";
   
        }
        private string Conn
        {
            get
            {
                string s = Vietsoft.Information.ConnectionString;
                // s = @"Data Source=Lenovo-pc\sqlexpress;Initial Catalog=CMMS;User ID=sa;Pwd=123";
                return s;

            }
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbDistrict.DataSource = null;
                LoadDistrict(cmbCity.SelectedValue.ToString());
            }
            catch { }
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbStreet.DataSource = null;
                LoadStreet(cmbDistrict.SelectedValue.ToString());
            }
            catch { }
        }

        private void cmbStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadFactory(cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString());
            }
            catch { }
        }

       

        private void cmbCatMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroupMachine(cmbCatMachine.SelectedValue.ToString());
        }

        private void btnThuchien_Click(object sender, EventArgs e)
        {
            
            ReportMaintaince obj = new ReportMaintaince();
            if (!string.IsNullOrEmpty(Convert.ToString(cmbCity.SelectedValue)))
            {
                if (!string.IsNullOrEmpty(Convert.ToString(cmbDistrict.SelectedValue)))
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(cmbStreet.SelectedValue)))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(cmbFactory.SelectedValue)))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(cmbCatMachine.SelectedValue)))
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(cmbGroupMachine.SelectedValue)))
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(cmbMaintaint.SelectedValue)))
                                    {
                                        if (!string.IsNullOrEmpty(Convert.ToString(cmbNguoiThucHien.SelectedValue)))
                                        {
                                            if (Convert.ToDateTime(txtToDate.Value.ToShortDateString()) >= Convert.ToDateTime(txtFromDate.Value.ToShortDateString()))
                                            {
                                                #region
                                                obj._city = cmbCity.SelectedValue.ToString();
                                                obj._district = cmbDistrict.SelectedValue.ToString();
                                                obj._street = cmbStreet.SelectedValue.ToString();
                                                obj._factory = cmbFactory.SelectedValue.ToString();
                                                obj._catmachine = cmbCatMachine.SelectedValue.ToString();
                                                obj._groupmachine = cmbGroupMachine.SelectedValue.ToString();
                                                obj._catMaintaice = Convert.ToInt32(cmbMaintaint.SelectedValue);
                                                obj._fromDate = Convert.ToDateTime(txtFromDate.Value.ToShortDateString());
                                                obj._toDate = Convert.ToDateTime(txtToDate.Value.ToShortDateString());
                                                obj._nguoiTH = cmbNguoiThucHien.SelectedValue.ToString();
                                                bool pn = false;
                                                
                                                string sql = "SELECT DISTINCT PHONG_NGUA FROM";
                                                sql += " LOAI_BAO_TRI INNER JOIN HINH_THUC_BAO_TRI";
                                                sql += " ON LOAI_BAO_TRI.MS_HT_BT=HINH_THUC_BAO_TRI.MS_HT_BT WHERE LOAI_BAO_TRI.MS_LOAI_BT='" + obj._catMaintaice + "'";
                                                pn = Convert.ToBoolean(SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, CommandType.Text, sql));
                                                obj.is_Bao_Tri = pn;
                                                if (!pn)
                                                    obj._tableSource.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "SP_NHU_GET_THONG_TIN_BAO_TRI_CHI_TIET", Vietsoft.Information.Username,
                                                    obj._fromDate.ToString("MM-dd-yyyy"), obj._toDate.ToString("MM-dd-yyyy"), obj._catmachine, obj._groupmachine, obj._catMaintaice, obj._factory,
                                                    obj._city, obj._district, obj._street,obj._nguoiTH));
                                                else
                                                {
                                                    obj._tableSource.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_BAO_TRI_CHI_TIET_PHONG_NGUA", Vietsoft.Information.Username,
                                                  obj._fromDate.ToString("MM-dd-yyyy"), obj._toDate.ToString("MM-dd-yyyy"), obj._catmachine, obj._groupmachine, obj._catMaintaice, obj._factory,
                                                  obj._city, obj._district, obj._street, obj._nguoiTH));
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                //ngay khong hop le
                                                MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListMaintain", "DateError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                txtToDate.Focus();
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListMaintain", "NguoiTHError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            cmbNguoiThucHien.Focus();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        //maintaince is not valid
                                        MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListMaintain", "MaintainceError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        cmbMaintaint.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    //group machine is not valid
                                    MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListMaintain", "GroupMachineError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cmbGroupMachine.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                //catmachine is not valid
                                MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListMaintain", "CatMachineError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbCatMachine.Focus();
                                return;
                            }
                        }
                        else
                        {
                            //factory is not valid
                            MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListMaintain", "FactoryError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbFactory.Focus();
                            return;
                        }
                    }
                    else
                    {
                        //street is not valid
                        MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListMaintain", "StreetError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbStreet.Focus();
                        return;
                    }
                }
                else
                {
                    //district is not valid
                    MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListMaintain", "DistrictError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDistrict.Focus();
                    return;
                }
               
            }
            else
            {
                MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName,"ListMaintain","CityError",Vietsoft.Information.Language),"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                cmbCity.Focus();
                return;
            }
           
            //name
            obj._tungay = lblFromDate.Text + " " + txtFromDate.Text + " " + lblToDate.Text + " " + txtToDate.Text;
            obj._cityName =lblCity.Text + ":" +  cmbCity.Text;
            obj._districtName =lblDistrict.Text + ":" + cmbDistrict.Text;
            obj._streetName =lblStreet.Text + ":" + cmbStreet.Text;
            obj._factoryName = lblNhaXuong.Text + ":" + cmbFactory.Text;
            obj._catmachineName =lblCatMachine.Text + ":"+ cmbCatMachine.Text;
            obj._groupmachineName =lblGroupMachine.Text + ":"  + cmbGroupMachine.Text;
            obj._catMaintainceName =lblCatMaintaint.Text +":" + cmbMaintaint.Text;
            obj._nguoiTHName = lblNguoiThucHien.Text + ":" + cmbNguoiThucHien.Text;
            obj.ShowDialog();
        }

        private void UCMaintaince_Load(object sender, EventArgs e)
        {
            try
            {

                txtToDate.Value = DateTime.Now;
                txtFromDate.Value = DateTime.Now.AddDays(-7);
                LoadCity();
                LoadFactory(cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString());
                LoadCatMachine();
                LoadMaintaince();
                LoadNguoiTH();
            }
            catch { }
        }

       


     
    }
}
