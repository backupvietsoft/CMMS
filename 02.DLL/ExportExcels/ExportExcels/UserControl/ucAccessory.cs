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
    public partial class ucAccessory : DevExpress.XtraEditors.XtraUserControl
    {
        public ucAccessory()
        {
            InitializeComponent();
        }
        private void LoadTinh()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,"S_Tinh"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbCity, _table, "MA_QG", "TEN_QG", lblCity.Text);
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
            frmAccessory  frm = new frmAccessory ();
            frm._tu_ngay =lblTuNgay.Text + " "  + datFromDate.DateTime.ToShortDateString();
            frm._tu_ngay += " " + lblDenNgay.Text + " " + datToDate.DateTime.ToShortDateString();
           
            frm.loai_may =lblCatMachine.Text + ":" +  cmbCatmachine.Text;
            frm.nhom_may =lblNhomMay.Text +":" + cmbGroupMachine.Text;
            frm.tinh =lblCity.Text + ":" + cmbCity.Text;
            frm.quan =lblDistrict.Text + ":" +  cmbDistrict.Text;
            string sql = "SELECT PBT_KHO FROM THONG_TIN_CHUNG";
            var kho = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql);
            if (Convert.ToBoolean(kho))
            frm._TableSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_ACCESSORY_USED",
                                                          datFromDate.DateTime,datToDate.DateTime,cmbCatmachine.EditValue.ToString(),
                                                          cmbGroupMachine.EditValue.ToString(),cmbCity.EditValue.ToString(),cmbDistrict.EditValue.ToString()));
            else
                frm._TableSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_ACCESSORY_USED_NOT_STOCK",
                                                         datFromDate.DateTime, datToDate.DateTime, cmbCatmachine.EditValue.ToString(),
                                                         cmbGroupMachine.EditValue.ToString(), cmbCity.EditValue.ToString(), cmbDistrict.EditValue.ToString()));
            frm.ShowDialog();
        }
     
        private void cmbCity_EditValueChanged(object sender, EventArgs e)
        {
            LoadDistrict();
        }

        private void cmbCatmachine_EditValueChanged(object sender, EventArgs e)
        {
            LoadGroupMachine();
        }

        private void ucAccessory_Load(object sender, EventArgs e)
        {
            LoadTinh();
            LoadCatMachine();
            if (DateTime.Now.Month ==1)
                datFromDate.DateTime = Convert.ToDateTime("12/" + (DateTime.Now.Year - 1));
            else
                datFromDate.DateTime = Convert.ToDateTime((DateTime.Now.Month - 1) + "/" + DateTime.Now.Year);
            datToDate.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmAccessory", "btnThuchien", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmAccessory", "btnExit", Commons.Modules.TypeLanguage);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        
    }
}
