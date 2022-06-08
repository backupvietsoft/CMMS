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
    public partial class ucIncident : DevExpress.XtraEditors.XtraUserControl
    {
        public ucIncident()
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
            frmIncidents frm = new frmIncidents();
            frm.quan = cmbDistrict.EditValue.ToString();
            frm.tinh = cmbCity.EditValue.ToString();
            frm._tu_ngay = Convert.ToDateTime("01/" + datFromDate.DateTime.Month + "/" + datFromDate.DateTime.Year);
            frm._den_ngay = Convert.ToDateTime("01/" + datToDate.DateTime.Month + "/" + datToDate.DateTime.Year);
            frm.loai_may = cmbCatmachine.EditValue.ToString();
            frm.nhom_may = cmbGroupMachine.EditValue.ToString();
            frm._district = lblDistrict.Text + ":" + cmbDistrict.Text;
            frm._group = lblNhomMay.Text + ":" + cmbGroupMachine.Text;
            frm._date = lblTuThang.Text + " " + datFromDate.DateTime.Month + "/" + datFromDate.DateTime.Year + " " + lblDenThang.Text + " " + datToDate.DateTime.Month + "/" + datToDate.DateTime.Year;
            frm._city = lblCity.Text + ":" + cmbCity.Text;
            frm._cat = lblCatMachine.Text + ":" + cmbCatmachine.Text;
            frm.ShowDialog();
        }
        private void ucIncident_Load(object sender, EventArgs e)
        {
            LoadTinh();
            LoadCatMachine();
            datFromDate.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Year);
            datToDate.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "btnThuchien", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "btnExit", Commons.Modules.TypeLanguage);
        }

        private void cmbCity_EditValueChanged(object sender, EventArgs e)
        {
            LoadDistrict();
        }

        private void cmbCatmachine_EditValueChanged(object sender, EventArgs e)
        {
            LoadGroupMachine();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        
    }
}
