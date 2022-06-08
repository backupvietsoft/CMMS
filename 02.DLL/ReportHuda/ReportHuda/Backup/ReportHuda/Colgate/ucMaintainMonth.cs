using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
namespace ReportHuda.Colgate
{
    public partial class ucMaintainMonth : DevExpress.XtraEditors.XtraUserControl
    {
        public ucMaintainMonth()
        {
            InitializeComponent();
        }
        private void LoadNX()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"));
            cmbNhaXuong.Properties.ValueMember = "MS_N_XUONG";
            cmbNhaXuong.Properties.DisplayMember = "TEN_N_XUONG";
            cmbNhaXuong.Properties.DataSource = _table;
            cmbNhaXuong.EditValue = "-1";
        }
        private void LoadCatMachine()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayAll", 1, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbCatmachine, _table, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblCatMachine.Text);
            //DataTable _table = new DataTable();
            //_table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_LOAI_MAY,TEN_LOAI_MAY FROM LOAI_MAY UNION SELECT '-1','All' ORDER BY TEN_LOAI_MAY "));
            //cmbCatmachine.Properties.DataSource = _table;
            //cmbCatmachine.Properties.DisplayMember = "TEN_LOAI_MAY";
            //cmbCatmachine.Properties.ValueMember = "MS_LOAI_MAY";
            //cmbCatmachine.EditValue = "-1";


            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "btnExecute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "btnThoat", Commons.Modules.TypeLanguage);
        }
        private void GetData()
        {

             int day = DateTime.DaysInMonth(datFromDate.DateTime.Year, datFromDate.DateTime.Month);
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_KE_HOACH_BAO_TRI_TB_THANG_COLGATE",
                                    "01/" + datFromDate.DateTime.Month + "/" + datFromDate.DateTime.Year,
                                    day + "/" + datFromDate.DateTime.Month + "/" + datFromDate.DateTime.Year, cmbNhaXuong.EditValue, cmbCatmachine.EditValue  ,Commons.Modules.UserName, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            DataTable _table_NX = new DataTable();
            _table_NX = _table.DefaultView.ToTable("NHA_XUONG", true, "MS_N_XUONG", "TEN_N_XUONG");
            DataTable _table_May = new DataTable();
            DataTable _table_May_BT = new DataTable();
            frmMaintaince_Colgate frm = new frmMaintaince_Colgate();
            frm._tableMaintaince = _table.DefaultView.ToTable(true,"THU_TU", "MS_LOAI_BT", "TEN_LOAI_BT", "R", "G", "B");
            DataView dataView = new DataView(frm._tableMaintaince);
            dataView.Sort = "THU_TU";
            frm._tableMaintaince = dataView.ToTable();
            DataRow _row = frm._tableSource.NewRow();
            string date = "";
            DateTime original = datFromDate.DateTime;
            // DataColumn column;
            frm._tableSource.Columns.Add("Machine Name");
            for (int i = 1; i <= day; i++)
            {
                
                date = datFromDate.DateTime.DayOfWeek.ToString().Substring(0, 1) + "_" + i;
                frm._tableSource.Columns.Add(date);
                datFromDate.DateTime = datFromDate.DateTime.AddDays(1);
                _row[date] = i;
            }

            //_row["Machine Name"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "Ngay", Commons.Modules.TypeLanguage);
            frm._tableSource.Rows.Add(_row);
            _row = frm._tableSource.NewRow();
            
            foreach (DataRow _row_nx in _table_NX.Rows)
            {
                _row["Machine Name"] = _row_nx[1];
                frm._tableSource.Rows.Add(_row);
                _table.DefaultView.RowFilter = "MS_N_XUONG='" + _row_nx[0] + "'";
                _table_May = _table.DefaultView.ToTable("MAY", true, "MS_MAY", "TEN_MAY");
                foreach (DataRow _rowMay in _table_May.Rows)
                {
                    _row = frm._tableSource.NewRow();
                    _table.DefaultView.RowFilter = "MS_N_XUONG='" + _row_nx[0] + "' AND MS_MAY ='" + _rowMay[0] + "'";
                    _table_May_BT = _table.DefaultView.ToTable("MAY", true, "MS_MAY", "TEN_MAY", "NGAY_KE", "MS_LOAI_BT", "R", "G", "B");
                    foreach (DataRow _row_BT in _table_May_BT.Rows)
                    {
                       
                        _row["Machine Name"] = _row_BT["TEN_MAY"];
                        int d = Convert.ToDateTime(_row_BT["NGAY_KE"]).Day;
                        _row[d] = _row_BT["R"] + " " + _row_BT["G"] + " " + _row_BT["B"];
                    }
                    frm._tableSource.Rows.Add(_row);
                }
               _row = frm._tableSource.NewRow();
            }
            frm._tableSource.Columns.Add("Total");
            datFromDate.DateTime = original;
            frm.date = datFromDate.DateTime.Month + "/" + datFromDate.DateTime.Year;
            frm.ShowDialog();
           
        }
        private void btnExcute_Click(object sender, EventArgs e)
        {
            GetData();  
        }
        private void ucMaintainMonth_Load(object sender, EventArgs e)
        {
            LoadNX();
            LoadCatMachine();
            datFromDate.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
          
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
