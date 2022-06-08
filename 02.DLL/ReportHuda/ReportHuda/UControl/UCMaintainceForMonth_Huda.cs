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
    public partial class UCMaintainceForMonth_Huda : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable _tableMaintaince;
        DataTable _tableMachine;
        bool isFirst = false;
        public UCMaintainceForMonth_Huda()
        {
            InitializeComponent();
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
            foreach (DataColumn col in _tableMachine.Columns)
            {  
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", col.Caption , Commons.Modules.TypeLanguage);      
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
           // string caption = "";
            foreach (DataColumn col in _tableMaintaince.Columns)
            {
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", col.Caption, Commons.Modules.TypeLanguage);
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
            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "btnExecute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "btnThoat", Commons.Modules.TypeLanguage);
            btnMachineChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "btnMachineChooseAll", Commons.Modules.TypeLanguage);
            btnMachineUnChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "btnMachineUnChooseAll", Commons.Modules.TypeLanguage);
            btnMaintaiceChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "btnMaintaiceChooseAll", Commons.Modules.TypeLanguage);
            btnMaitainceUnChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "btnMaitainceUnChooseAll", Commons.Modules.TypeLanguage);
        }
       
     
        
        private void dateFromDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue > dateToDate.DateTime)
                    {
                        Vietsoft.Information.MsgBox(this.ParentForm, "MsgFromDateNhoToDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        e.Cancel = true;
                    }
                    else
                    {
                        if (!dateToDate.DateTime.Month.Equals(Convert.ToDateTime(e.NewValue).Month))
                        {
                            Vietsoft.Information.MsgBox(this.ParentForm, "MsgTrongThang", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                             e.Cancel = true;
                        }
                        else
                        {
                            if (!dateToDate.DateTime.Year.Equals(Convert.ToDateTime(e.NewValue).Year))
                            {
                                Vietsoft.Information.MsgBox(this.ParentForm, "MsgTrongThang", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                  e.Cancel = true;
                            }
                        }
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

                    if ((DateTime)e.NewValue < dateFromDate.DateTime)
                    {
                        Vietsoft.Information.MsgBox(this.ParentForm, "MsgToDateLonFromDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        e.Cancel = true;
                    }
                    else
                    {
                        if (!dateFromDate.DateTime.Month.Equals(Convert.ToDateTime(e.NewValue).Month))
                        {
                            Vietsoft.Information.MsgBox(this.ParentForm, "MsgTrongThang", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                             e.Cancel = true;
                        }
                        else
                        {
                            if (!dateFromDate.DateTime.Year.Equals(Convert.ToDateTime(e.NewValue).Year))
                            {
                                Vietsoft.Information.MsgBox(this.ParentForm, "MsgTrongThang", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                  e.Cancel = true;
                            }
                        }
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
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "banphaichonmayloaibt", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                DataTable _tableValue = new DataTable();
                _tableValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_NHU_Y_GET_KE_HOACH_BAO_TRI_THANG_HUDA]", dateFromDate.DateTime.ToString("MM/dd/yyyy"),dateToDate.DateTime.ToString("MM/dd/yyyy"), cmbFactory.EditValue, Commons.Modules.UserName, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                DataTable _table_CV = new DataTable();
                if (_tableValue.Rows.Count > 0)
                {
                    string filter = "MS_MAY IN (" + filterMachine + ") AND MS_LOAI_BT IN (" + filterMaintaince + ")";
                    _tableValue.DefaultView.RowFilter = filter;
                    _tableValue = _tableValue.DefaultView.ToTable();

                    
                    _table_CV = _tableValue.DefaultView.ToTable("DSBT_THANG", true, "MS_MAY", "MS_CV", "MS_BO_PHAN", "MAY", "BP", "MO_TA_CV");
                    int day = dateToDate.DateTime.Subtract(dateFromDate.DateTime).Days + 1;
                    for (int i = 1; i <= day; i++)
                        _table_CV.Columns.Add(i + "");
                    DataTable _table_temp = new DataTable();
                    foreach (DataRow _row_cv in _table_CV.Rows)
                    {
                        _tableValue.DefaultView.RowFilter = "MS_MAY='" + _row_cv["MS_MAY"] + "' AND MS_CV='" + _row_cv["MS_CV"] + "' AND MS_BO_PHAN = '" + _row_cv["MS_BO_PHAN"] + "'";
                        _table_temp = _tableValue.DefaultView.ToTable();
                        foreach (DataRow _row in _table_temp.Rows)
                        {
                            int d = Convert.ToDateTime(_row["NGAY_KE"]).Day;
                            _row_cv[d + ""] = "X";
                        }
                    }
                    string[] columnName = new string[day + 3];
                    columnName[2] = "MAY";
                    columnName[1] = "BP";
                    columnName[0] = "MO_TA_CV";
                    for (int i = 3; i < day + 3; i++)
                    {
                        columnName[i] = i - 2 + "";
                    }
                    _table_CV = _table_CV.DefaultView.ToTable("DSBT_THANG1", true, columnName);
                    return _table_CV;
                }
                else
                    return _table_CV;
            }
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableMaintaince.Rows.Count > 0)
                {
                    frmMaintainceForMonth_Huda frm = new frmMaintainceForMonth_Huda();
                    frm.TableSource = TableMaintaince;
                    frm._month = dateFromDate.DateTime.Month;
                    frm._year = dateFromDate.DateTime.Year;
                    frm.DKLoc = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "thoigianthuchien:", Commons.Modules.TypeLanguage);
                    frm.DKLoc += " " + lblFromDate.Text + ":" + dateFromDate.Text + lblToDate.Text + ":" + dateToDate.Text;
                    frm.SubTitle = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "dinhky:hangtuan", Commons.Modules.TypeLanguage);
                    // frm.SubTitle += " " + lblWeek.Text + " " + cmbWeek.Text + "/" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "year", Commons.Modules.TypeLanguage) + DateTime.Now.Year;
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
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceForMonth_Huda", "khongcodulieu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void UCMaintainceForMonth_Huda_Load(object sender, EventArgs e)
        {
            dateFromDate.DateTime =Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            dateToDate.DateTime = DateTime.Now;
            isFirst = true;
            LoadFactory();
            LoadMaintaince();
            SetLanguage();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

      
    }
}
