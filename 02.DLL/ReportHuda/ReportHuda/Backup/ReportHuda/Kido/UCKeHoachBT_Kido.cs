using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda.Kido
{
    public partial class UCKeHoachBT_Kido : DevExpress.XtraEditors.XtraUserControl
    {
       private bool isFirst=false ;
        public UCKeHoachBT_Kido()
        {
            InitializeComponent();
        }
        #region Prepare Data
        private void LoadCity()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Tinh"));
            cmbCity.DataSource = _table;
            cmbCity.DisplayMember = "ten_qg";
            cmbCity.ValueMember = "ma_qg";
            cmbCity.SelectedValue = "-1";

        }
        private void LoadDistrict()
        {
            DataTable _table = new DataTable();
            if (cmbCity.SelectedValue.ToString().Equals("-1"))
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT ma_qg,ten_qg FROM Y_DISTRICT WHERE MS_CHA='-1' UNION SELECT '-1','All'"));
            else
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_District", cmbCity.SelectedValue.ToString()));
            cmbDistrict.DataSource = _table;
            cmbDistrict.DisplayMember = "ten_qg";
            cmbDistrict.ValueMember = "ma_qg";
            cmbDistrict.SelectedValue = "-1";
        }
        private void LoadStreet()
        {
            DataTable _table = new DataTable();
     
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Duong", cmbCity.SelectedValue.ToString(),cmbDistrict.SelectedValue.ToString()));
            cmbStreet.DataSource = _table;
            cmbStreet.DisplayMember = "DUONG_TV";
            cmbStreet.ValueMember = "MS_DUONG";
            cmbStreet.SelectedValue = "-1";
        }
        private void LoadNX()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"));
            cmbFactory.ValueMember = "MS_N_XUONG";
            cmbFactory.DisplayMember = "TEN_N_XUONG";
            cmbFactory.DataSource = _table;
            cmbFactory.SelectedValue  = "-1";
        }
        private void LoadCatMachine()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_LOAI_MAY,TEN_LOAI_MAY FROM LOAI_MAY UNION SELECT '-1','All' ORDER BY TEN_LOAI_MAY "));
            cmbCategory.DataSource = _table;
            cmbCategory.DisplayMember = "TEN_LOAI_MAY";
            cmbCategory.ValueMember = "MS_LOAI_MAY";
            cmbCategory.SelectedValue  = "-1";
            
        }
        private void LoadGroupMachine()
        {
            DataTable _table = new DataTable();
            if (cmbCategory.SelectedValue.ToString().Equals("-1"))
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_NHOM_MAY,TEN_NHOM_MAY FROM NHOM_MAY WHERE MS_LOAI_MAY='-1' UNION SELECT '-1','All'"));
            else
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_GROUP_MACHINE", cmbCategory.SelectedValue.ToString()));
            cmbGroup.DataSource = _table;
            cmbGroup.DisplayMember = "TEN_NHOM_MAY";
            cmbGroup.ValueMember = "MS_NHOM_MAY";
            cmbGroup.SelectedValue = "-1";
        }
        #endregion
        #region Event
        private void cmbCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDistrict();
            LoadStreet();
            LoadNX();
        }
        private void cmbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadStreet();
            LoadNX();
        }
        private void cmbStreet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadNX();
        }
        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadGroupMachine();
        }
        #endregion
        #region validating data
        private void cmbCity_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                cmbCity.SelectedValue.ToString();
                
            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "CityIsNotValid", Commons.Modules.TypeLanguage));
                cmbCity.Focus();
                e.Cancel = true;
            }
            
        }

        private void cmbDistrict_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                cmbDistrict.SelectedValue.ToString();

            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "DistrictIsNotValid", Commons.Modules.TypeLanguage));
                cmbDistrict.Focus();
                e.Cancel = true;
            }
        }

        private void cmbStreet_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                cmbStreet.SelectedValue.ToString();

            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "StreetIsNotValid", Commons.Modules.TypeLanguage));
                cmbStreet.Focus();
                e.Cancel = true;
            }
        }

        private void cmbFactory_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                cmbFactory.SelectedValue.ToString();

            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "FactoryIsNotValid", Commons.Modules.TypeLanguage));
                cmbFactory.Focus();
                e.Cancel = true;
            }
        }

        private void cmbCategory_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                cmbCategory.SelectedValue.ToString();

            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "CategoryIsNotValid", Commons.Modules.TypeLanguage));
                cmbCategory.Focus();
                e.Cancel = true;
            }
        }

        private void cmbGroup_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                cmbGroup.SelectedValue.ToString();

            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "GroupIsNotValid", Commons.Modules.TypeLanguage));
                cmbGroup.Focus();
                e.Cancel = true;
            }
        }

        private void txtFromDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue > txtToDate.DateTime)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "MsgToDateLonFromDate", Commons.Modules.TypeLanguage));
                        e.Cancel = true;
                    }
                }
                else
                    isFirst = false;
            }
            catch { }
        }

        private void txtToDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue < txtFromDate.DateTime)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "MsgToDateLonFromDate", Commons.Modules.TypeLanguage));
                        e.Cancel = true;
                    }
                }
                else
                {
                    isFirst = false;
                }
            }
            catch { }
        }

        #endregion
        private void UCKeHoachBT_Kido_Load(object sender, EventArgs e)
        {
            #region LoadData
            txtFromDate.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            txtToDate.DateTime = DateTime.Now;
            LoadCity();
            LoadDistrict();
            LoadStreet();
            LoadNX();
            LoadCatMachine();
            LoadGroupMachine();
            isFirst = true;
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "btnExcute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "btnThoat", Commons.Modules.TypeLanguage);
            #endregion
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            frmBaoCaoKHBT_Kido obj = new frmBaoCaoKHBT_Kido();
            obj._table_source = new DataTable();
            obj.day = lblFromDate.Text + ":" + txtFromDate.Text + " " + lblToDate.Text + ":" + txtToDate.Text;
            obj.city = lblCity.Text + ":" + cmbCity.Text;
            obj.district = lblDistrict.Text + ":" + cmbDistrict.Text;
            obj.street = lblStreet.Text + ":" + cmbStreet.Text;
            obj.factory = lblFactory.Text + ":" + cmbFactory.Text;
            obj.cat = lblCategoryMachine.Text + ":" + cmbCategory.Text;
            obj.group = lblGroupMachine.Text + ":" + cmbGroup.Text;
            obj._table_source.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_KE_HOACH_BAO_TRI_TB_KIDO", txtFromDate.DateTime, txtToDate.DateTime,
                                                           cmbFactory.SelectedValue,cmbCategory.SelectedValue,cmbGroup.SelectedValue,Commons.Modules.UserName,Commons.Modules.UserName,
                                                           Commons.Modules.TypeLanguage,cmbCity.SelectedValue,cmbDistrict.SelectedValue,cmbStreet.SelectedValue));
            obj._table_source.Columns["No"].ReadOnly = false;
            obj._table_source.Columns["No"].MaxLength = 100000;
            for (int i = 0; i < obj._table_source.Rows.Count;i++ )
                obj._table_source.Rows[i]["No"] = i+1;
            if (obj._table_source.Rows.Count>0)
                obj.ShowDialog();
            else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBaoCaoKHBT_Kido", "NoDataToPrint", Commons.Modules.TypeLanguage));
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
