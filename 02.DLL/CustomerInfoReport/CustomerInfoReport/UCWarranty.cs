using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomerInfoReport
{
    public partial class UCWarranty : UserControl
    {
        public int AmountDate = 15;
        private bool isFirst = false;
        public UCWarranty()
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
        private void LoadFactory(string city, string district, string street)
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
        private void UCWarranty_Load(object sender, EventArgs e)
        {
            try
            {

                txtTuNgay.DateTime =Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                txtDenNgay.DateTime = DateTime.Now;
                isFirst = true;
                LoadCity();
                LoadFactory(cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString());
                LoadCatMachine();

            }
            catch { }
        }
        private void btnThuchien_Click(object sender, EventArgs e)
        {
            ListWarranty obj = new ListWarranty();
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
                               

                                    obj._city = cmbCity.SelectedValue.ToString();
                                    obj._district = cmbDistrict.SelectedValue.ToString();
                                    obj._street = cmbStreet.SelectedValue.ToString();
                                    obj._factory = cmbFactory.SelectedValue.ToString();
                                    obj._catmachine = cmbCatMachine.SelectedValue.ToString();
                                    obj._amountDate = Convert.ToInt16(txtDateAmount.Text);
                                    obj._tungay =Convert.ToDateTime(txtTuNgay.DateTime.ToShortDateString());
                                    obj._den_ngay =Convert.ToDateTime(txtDenNgay.DateTime.ToShortDateString());
                                    //obj._groupmachine = cmbGroupMachine.SelectedValue.ToString();


                              
                            }
                            else
                            {
                                //catmachine is not valid
                                MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListCustomerInfo", "CatMachineError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbCatMachine.Focus();
                                return;
                            }
                        }
                        else
                        {
                            //factory is not valid
                            MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListCustomerInfo", "FactoryError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbFactory.Focus();
                            return;
                        }
                    }
                    else
                    {
                        //street is not valid
                        MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListCustomerInfo", "StreetError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbStreet.Focus();
                        return;
                    }
                }
                else
                {
                    //district is not valid
                    MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListCustomerInfo", "DistrictError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDistrict.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListCustomerInfo", "CityError", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCity.Focus();
                return;
            }

            //name

            obj._cityName =lblCity.Text + ":" + cmbCity.Text;
            obj._districtName =lblDisctrict.Text + ":" + cmbDistrict.Text;
            obj._streetName =lblStreet.Text + ":" + cmbStreet.Text;
            obj._factoryName =lblFactory.Text + ":" + cmbFactory.Text;
            obj._catmachineName =lblCatMachine.Text + ":" +  cmbCatMachine.Text;
            obj._amountDateText = lblDateAmount.Text + ":" + txtDateAmount.Text;
            obj._ngay = lblTuNgay.Text + ":" + txtTuNgay.Text + " " + lblDenNgay.Text + ":" + txtDenNgay.Text;
            obj.ShowDialog();
        }

        private void txtDateAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AmountDate = Convert.ToInt16(txtDateAmount.Text);
                if (AmountDate <= 0)
                {
                    txtDateAmount.Text = "15";
                    AmountDate = 15;
                }
            }
            catch {
                txtDateAmount.Text = "15";
            }
        }

        private void txtTuNgay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue > txtDenNgay.DateTime)
                    {

                        MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListCustomerInfo", "MsgToDateLonFromDate", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                     
                        e.Cancel = true;
                    }
                }
            }
            catch { }
        }

        private void txtDenNgay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if ((DateTime)e.NewValue < txtTuNgay.DateTime)
                    {
                        MessageBox.Show(Vietsoft.Information.GetLanguage(Vietsoft.Information.ModuleName, "ListCustomerInfo", "MsgToDateLonFromDate", Vietsoft.Information.Language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        e.Cancel = true;
                    }

                }
            }
            catch { }
        }
    }
}
