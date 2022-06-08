using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
namespace ExportExcels
{
    public partial class ucIncidents_Non_Recurring : DevExpress.XtraEditors.XtraUserControl
    {
        public ucIncidents_Non_Recurring()
        {
            InitializeComponent();
        }
        private void LoadTinh()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,"S_Tinh"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbCity, _table, "MA_QG", "TEN_QG", lblCity.Text);

        }
        private void LoadNX()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", "Administrator", cmbCity.EditValue.ToString(), cmbDistrict.EditValue, "-1"));
            cmbNhaXuong.Properties.ValueMember = "MS_N_XUONG";
            cmbNhaXuong.Properties.DisplayMember = "TEN_N_XUONG";
            cmbNhaXuong.Properties.DataSource = _table;
            cmbNhaXuong.EditValue = "-1";
        }

        private void LoadDistrict()
        {
            DataTable _table = new DataTable();
            if(cmbCity.EditValue.ToString().Equals("-1"))
               _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,CommandType.Text,"SELECT ma_qg,ten_qg FROM Y_DISTRICT WHERE MS_CHA='-1' UNION SELECT '-1','All'"));
            else
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_District",cmbCity.EditValue.ToString()));
            cmbDistrict.Properties.DataSource = _table;
            cmbDistrict.Properties.DisplayMember = "ten_qg";
            cmbDistrict.Properties.ValueMember = "ma_qg";
            cmbDistrict.EditValue = "-1";
        }
        private void LoadCatMachine()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_LOAI_MAY,TEN_LOAI_MAY FROM LOAI_MAY UNION SELECT '-1','All' ORDER BY TEN_LOAI_MAY "));
            cmbCatmachine.Properties.DataSource = _table;
            cmbCatmachine.Properties.DisplayMember = "TEN_LOAI_MAY";
            cmbCatmachine.Properties.ValueMember = "MS_LOAI_MAY";
            cmbCatmachine.EditValue = "-1";
        }
        private void LoadGroupMachine()
        {
            DataTable _table = new DataTable();
            if(cmbCatmachine.EditValue.ToString().Equals("-1"))
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text ,"SELECT MS_NHOM_MAY,TEN_NHOM_MAY FROM NHOM_MAY WHERE MS_LOAI_MAY='-1' UNION SELECT '-1','All'"));
            else
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_GROUP_MACHINE",cmbCatmachine.EditValue.ToString()));
            cmbGroupMachine.Properties.DataSource = _table;
            cmbGroupMachine.Properties.DisplayMember = "TEN_NHOM_MAY";
            cmbGroupMachine.Properties.ValueMember = "MS_NHOM_MAY";
            cmbGroupMachine.EditValue = "-1";
        }
        private void btnExcute_Click(object sender, EventArgs e)
        {
            frmIncidents_Non_Recurring frm = new frmIncidents_Non_Recurring();
            frm._cat = cmbCatmachine.EditValue.ToString();
            frm._group = cmbGroupMachine.EditValue.ToString();
            frm._tu_ngay = Convert.ToDateTime("01/" + datFromDate.DateTime.Month + "/" + datFromDate.DateTime.Year);
            frm._den_ngay = Convert.ToDateTime("01/" + datToDate.DateTime.Month + "/" + datToDate.DateTime.Year);
            frm._date =lblTuNgay.Text + " " + datFromDate.DateTime.Month + "/" + datFromDate.DateTime.Year + " " + lblDenNgay.Text + " " + datToDate.DateTime.Month + "/" + datToDate.DateTime.Year;
          
            frm.nha_xuong = lblNhaXuong.Text + ":" + cmbNhaXuong.Text;
            frm.loai_may =lblCatMachine.Text + ":" +  cmbCatmachine.Text;
            frm.nhom_may =lblNhomMay.Text +":" + cmbGroupMachine.Text;
            frm.tinh = lblCity.Text + ":" + cmbCity.Text;
            frm.quan = lblDistrict.Text + ":" + cmbDistrict.Text;

            frm.MsTinh = cmbCity.EditValue.ToString();
            frm.MsQuan = cmbDistrict.EditValue.ToString();
            frm.MsNX = cmbNhaXuong.EditValue.ToString();


            frm._TableSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_INCIDENTS_NON_RECURRING",datFromDate.DateTime.Month + "/01/" + datFromDate.DateTime.Year,
                                                          datToDate.DateTime.Month + "/01/" + datToDate.DateTime.Year,cmbCatmachine.EditValue.ToString(),
                                                          cmbGroupMachine.EditValue.ToString(),cmbCity.EditValue.ToString(),cmbDistrict.EditValue.ToString(),cmbNhaXuong.EditValue,Commons.Modules.UserName));
            frm.ShowDialog();
        }
     
        private void cmbCity_EditValueChanged(object sender, EventArgs e)
        {
            LoadDistrict();
            LoadNX();
        }

        private void cmbCatmachine_EditValueChanged(object sender, EventArgs e)
        {
            LoadGroupMachine();
        }

       

        private void cmbDistrict_EditValueChanged(object sender, EventArgs e)
        {
            LoadNX();
        }

        private void ucIncident_Detai_Load(object sender, EventArgs e)
        {
            LoadTinh();
            LoadNX();
            LoadCatMachine();
            datFromDate.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Year);
            datToDate.DateTime = DateTime.Now;
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "btnThuchien", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents_Non_Recurring", "btnExit", Commons.Modules.TypeLanguage);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        
    }
}
