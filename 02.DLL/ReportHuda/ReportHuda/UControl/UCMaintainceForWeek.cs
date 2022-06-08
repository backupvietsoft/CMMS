using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;
namespace ReportHuda
{
    public partial class UCMaintainceForWeek : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable _table;
        DataTable _tableFilter;
        DataTable _tableMaintaince;
        DataTable _tableMachine;
        DateTime _dateFrom,_dateTo;
        bool isFirst = false;
        public UCMaintainceForWeek()
        {
            InitializeComponent();
        }
        private void LoadWeek()
        {
            _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_TUAN_TRONG_NAM", "01/01/" + DateTime.Now.Year, "31/12/" + DateTime.Now.Year));
            cmbWeek.Properties.ValueMember = "TUAN";
            cmbWeek.Properties.DisplayMember = "TUAN";
            cmbWeek.Properties.DataSource = _table;
            cmbWeek.EditValue = 1;
        }
        private void LoadFactory()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", false, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            Commons.Modules.ObjSystems.MLoadCboTreeList(ref cmbFactory, _table, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
        }
        private void LoadMachine()
        {
            _tableMachine = new DataTable();
            _tableMachine.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DS_MAY_BY_NX", cmbFactory.EditValue));
            string caption = "";
            foreach (DataColumn col in _tableMachine.Columns)
            {
                caption = col.Caption;
                switch (caption)
                {
                    case "CHON":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "CHON", Commons.Modules.TypeLanguage);
                        break;
                    case "MS_MAY":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "MS_MAY", Commons.Modules.TypeLanguage);
                        break;
                    case "TEN_MAY":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "TEN_MAY", Commons.Modules.TypeLanguage);
                        break;
                }
                col.ReadOnly = true;
                
            }
            _tableMachine.Columns["CHON"].ReadOnly = false;
            gdMachine.DataSource = _tableMachine;
        }
        private void LoadMaintaince()
        {
            string sql = "SELECT CONVERT(BIT,0) AS CHON, MS_LOAI_BT,TEN_LOAI_BT FROM LOAI_BAO_TRI WHERE MS_HT_BT=1";
            _tableMaintaince = new DataTable();
            _tableMaintaince.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql));
            string caption = "";
            foreach (DataColumn col in _tableMaintaince.Columns)
            {
                caption = col.Caption;
                switch(caption)
                {
                    case "CHON":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "CHON", Commons.Modules.TypeLanguage);
                        break;
                    case "MS_LOAI_BT":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "MS_LOAI_BT", Commons.Modules.TypeLanguage);
                        break;
                    case "TEN_LOAI_BT":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "TEN_LOAI_BT", Commons.Modules.TypeLanguage);
                        break;
                }
                col.ReadOnly = true;
            }
            _tableMaintaince.Columns["CHON"].ReadOnly = false;
            gdMaintaince.DataSource = _tableMaintaince;
        }
        private void ChooseAll(bool choose,GridView  view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
            }
        }
        private void btnMachineChooseAll_Click(object sender, EventArgs e)
        {
            ChooseAll(true, gvMachine);
        }

        private void btnMachineUnChooseAll_Click(object sender, EventArgs e)
        {
            ChooseAll(false, gvMachine);
        }

        private void btnMaintaiceChooseAll_Click(object sender, EventArgs e)
        {
            ChooseAll(true, gvMaintaince);
        }

        private void btnMaitainceUnChooseAll_Click(object sender, EventArgs e)
        {
            ChooseAll(false, gvMaintaince);
        }
        private void SetLanguage()
        {
            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "btnExecute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "btnThoat", Commons.Modules.TypeLanguage);
            btnMachineChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "btnMachineChooseAll", Commons.Modules.TypeLanguage);
            btnMachineUnChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "btnMachineUnChooseAll", Commons.Modules.TypeLanguage);
            btnMaintaiceChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "btnMaintaiceChooseAll", Commons.Modules.TypeLanguage);
            btnMaitainceUnChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "btnMaitainceUnChooseAll", Commons.Modules.TypeLanguage);
        }
        private void UCMaintainceForWeek_Load(object sender, EventArgs e)
        {
            LoadWeek();
            LoadFactory();
            LoadMaintaince();
            SetLanguage();
        }
        private void cmbWeek_EditValueChanged(object sender, EventArgs e)
        {
            _tableFilter = new DataTable();
            _tableFilter = _table.Copy();
            _tableFilter.DefaultView.RowFilter = "TUAN=" + cmbWeek.EditValue;
            _tableFilter = _tableFilter.DefaultView.ToTable();
            _dateFrom = Convert.ToDateTime(_tableFilter.Rows[0][1].ToString());
            isFirst = false;
            dateFromDate.DateTime = _dateFrom;
            _dateTo = Convert.ToDateTime(_tableFilter.Rows[0][2].ToString());
            dateToDate.DateTime = _dateTo;
            isFirst = true;

        }
        
        private void dateFromDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue > dateToDate.DateTime || (DateTime)e.NewValue<_dateFrom)
                    {
                        Vietsoft.Information.MsgBox(this.ParentForm, "MsgFromDateNhoToDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        e.Cancel = true;
                    }
                }
                else
                    isFirst = false;
            }
            catch { }
        }

        private void dateToDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
         {
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue < dateFromDate.DateTime || (DateTime)e.NewValue > _dateTo)
                    {
                        Vietsoft.Information.MsgBox(this.ParentForm, "MsgToDateLonFromDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

        private void cmbFactory_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMachine();
        }
  
        private DataTable TableMaintaince
        {
            get
            {
                string filterMachine = "", filterMaintaince = "";
                DataTable _tableTemp = _tableMachine.Copy();
                _tableTemp.DefaultView.RowFilter = "CHON=TRUE";
                foreach (DataRow row in _tableTemp.DefaultView.ToTable().Rows)
                    filterMachine += "'" + row["MS_MAY"] + "',";
                if (filterMachine.Length > 0)
                    filterMachine = filterMachine.Remove(filterMachine.Length - 1, 1);
               
                DataTable _tableTemp1 = _tableMaintaince.Copy();
                _tableTemp1.DefaultView.RowFilter = "CHON=TRUE";
                foreach (DataRow row in _tableTemp1.DefaultView.ToTable().Rows)
                    filterMaintaince += "'" + row["MS_LOAI_BT"] + "',";
                if (filterMaintaince.Length > 0)
                    filterMaintaince = filterMaintaince.Remove(filterMaintaince.Length - 1, 1);
                if (filterMachine.Length <= 0 || filterMaintaince.Length<=0)
                {
                    //Vietsoft.Information.MsgBox(this.ParentForm, "banphaichonmayloaibt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    MessageBox.Show( Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "banphaichonmayloaibt",Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                DataTable _tableValue = new DataTable();
                _tableValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_NHU_Y_GET_KE_HOACH_BAO_TRI_TB]", dateFromDate.DateTime.ToString("MM/dd/yyyy"), dateToDate.DateTime.ToString("MM/dd/yyyy"), cmbFactory.EditValue, Commons.Modules.UserName, Commons.Modules.UserName,Commons.Modules.TypeLanguage));
                if (_tableValue.Rows.Count > 0)
                {
                    string filter = "MS_MAY IN (" + filterMachine + ") AND MS_LOAI_BT IN (" + filterMaintaince + ")";
                    _tableValue.DefaultView.RowFilter = filter;
                    _tableValue = _tableValue.DefaultView.ToTable("DSBT_TUAN", true, "MO_TA_CV", "MAY", "BP", "TEN_PT", "SO_LUONG"
                                                               , "DVT", "THUCHIEN", "ISCHECK");

                    string caption = "";
                    foreach (DataColumn col in _tableValue.Columns)
                    {
                        caption = col.Caption;
                        switch (caption)
                        {
                            case "NO":
                                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "NO", Commons.Modules.TypeLanguage);
                                break;
                            case "MAY":
                                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "MAY", Commons.Modules.TypeLanguage);
                                break;
                            case "BP":
                                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "BP", Commons.Modules.TypeLanguage);
                                break;
                            case "MO_TA_CV":
                                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "MO_TA_CV", Commons.Modules.TypeLanguage);
                                break;
                            case "TEN_PT":
                                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "TENPT", Commons.Modules.TypeLanguage);
                                break;
                            case "SO_LUONG":
                                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "SOLUONG", Commons.Modules.TypeLanguage);
                                break;
                            case "DVT":
                                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "DVT", Commons.Modules.TypeLanguage);
                                break;
                            case "THUCHIEN":
                                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "THUCHIEN", Commons.Modules.TypeLanguage);
                                break;
                            case "ISCHECK":
                                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "ISCHECK", Commons.Modules.TypeLanguage);
                                break;
                        }
                    }
                }
                return _tableValue;
            }
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableMaintaince.Rows.Count > 0)
                {
                    frmMaintainceForWeek frm = new frmMaintainceForWeek();
                    frm.TableSource = TableMaintaince;

                    frm.DKLoc = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "thoigianthuchien:", Commons.Modules.TypeLanguage);
                    frm.DKLoc += " " + lblFromDate.Text + ":" + dateFromDate.Text + lblToDate.Text + ":" + dateToDate.Text;
                    frm.SubTitle = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "dinhky:hangtuan", Commons.Modules.TypeLanguage);
                    frm.SubTitle += " " + lblWeek.Text + " " + cmbWeek.Text + "/" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "year", Commons.Modules.TypeLanguage) + DateTime.Now.Year;
                    try
                    {
                        if (frm.TableSource.Rows.Count > 0)
                            frm.ShowDialog();
                        else
                            return;
                    }
                    catch { }
                }
                else
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForWeek", "khongcodulieu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
