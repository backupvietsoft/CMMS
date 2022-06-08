using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Excel;
namespace WareHouse
{
    public partial class frmrptVENDOR_REPORT_PURCHASING_ORDER : UserControl
    {
        DateTime tungay;
        DateTime denngay;
        string loaivt = "";
        string maqg = "", tenqg = "",tenqg1="";
        string grandtotal = "=";
        int col = 0;
        int[] totalcountry;
        int[] grand;
        int ttotal = 0;
        int tgrand = 0;
        public frmrptVENDOR_REPORT_PURCHASING_ORDER()
        {
            InitializeComponent();
        }

        private void frmrptVENDOR_REPORT_PURCHASING_ORDER_Load(object sender, EventArgs e)
        {
            LoadLoaivt();
            LoadQuocGia();
            LoadKho();
            dtTungay.Value = DateTime.Today.AddMonths(-1);
            dtDenngay.Value = DateTime.Today;
        }

        private void LoadQuocGia()
        {
            try
            {
                System.Data.DataTable dtTable = new System.Data.DataTable();
                Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

                dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetQUOC_GIAbyLoaiVT1", cbLoaiVT.SelectedValue));
                gvQuocgia.DataSource = dtTable;
                gvQuocgia.Columns["CHON"].ReadOnly = false;
                gvQuocgia.Columns["MA_QG"].ReadOnly = true;
                gvQuocgia.Columns["TEN_QG"].Visible = true;
                gvQuocgia.Columns["MA_QG"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "MA_QG", Commons.Modules.TypeLanguage);
                gvQuocgia.Columns["TEN_QG"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "TEN_QG", Commons.Modules.TypeLanguage);
                gvQuocgia.Columns["CHON"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "CHON", Commons.Modules.TypeLanguage);
            }
            catch { }
        }

        private void LoadKho()
        {
            try
            {
                System.Data.DataTable dtTable = new System.Data.DataTable();
                Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

                dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "MGetKhoByLoaiVT", cbLoaiVT.SelectedValue));
                gvKho.DataSource = dtTable;
                gvKho.Columns["CHON_KHO"].ReadOnly = false;
                gvKho.Columns["MS_KHO"].ReadOnly = true;
                gvKho.Columns["TEN_KHO"].Visible = true;
                gvKho.Columns["MS_KHO"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "MS_KHO", Commons.Modules.TypeLanguage);
                gvKho.Columns["TEN_KHO"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "TEN_KHO", Commons.Modules.TypeLanguage);
                gvKho.Columns["CHON_KHO"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "CHON_KHO", Commons.Modules.TypeLanguage);
            }
            catch { }
        }

        private void LoadLoaivt()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("LoaiID");
            dt.Columns.Add("LoaiVT");

            DataRow rowall = dt.NewRow();
            rowall["LoaiID"] = -1;
            rowall["LoaiVT"] = "All";
            dt.Rows.Add(rowall);

            DataRow row = dt.NewRow();
            row["LoaiID"] = 0;
            row["LoaiVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "SparePart", Commons.Modules.TypeLanguage);
            dt.Rows.Add(row);

            DataRow row1 = dt.NewRow();
            row1["LoaiID"] = 1;
            row1["LoaiVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "Consumtion", Commons.Modules.TypeLanguage);
            dt.Rows.Add(row1);

            cbLoaiVT.DataSource = dt;
            cbLoaiVT.ValueMember = "LoaiID";
            cbLoaiVT.DisplayMember = "LoaiVT";


        }
        private System.Data.DataTable List_Table()
        {
            tungay = dtTungay.Value;
            denngay = dtDenngay.Value;
            int i = 0;

            System.Data.DataTable _table = new System.Data.DataTable();
            System.Data.DataTable _merge_table = new System.Data.DataTable();
            Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

            string MsKho = "";
            i = 0;
            while (i < gvKho.Rows.Count)
            {
                try
                {
                    if ((bool)gvKho.Rows[i].Cells["CHON_KHO"].Value)
                    {
                        MsKho = MsKho + " , " + gvKho.Rows[i].Cells["MS_KHO"].Value.ToString();
                    }
                }
                catch { }
                i++;

            }
            if (MsKho.Length > 0) MsKho = MsKho.Substring(3, MsKho.ToString().Length - 3);
            i = 0;

            while (i < gvQuocgia.Rows.Count)
            {
                string  ma_qg = "";
                try
                {
                    if ((bool)gvQuocgia.Rows[i].Cells["CHON"].Value)
                    {
                       
                        ma_qg =gvQuocgia.Rows[i].Cells["MA_QG"].Value.ToString();
                       
                        System.Data.DataTable _myTable = new System.Data.DataTable();
                        if (cbLoaiVT.SelectedValue.ToString() == "-1")
                        {
                            _table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "Getrpt_VENDOR_REPORT_PURCHASING_ORDER", tungay, denngay, 0, ma_qg, Commons.Modules.TypeLanguage, (rdVND.Checked) ? "1" : "0", MsKho));
                            _merge_table.Merge(_table);
                            _table = new System.Data.DataTable();
                            _table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "Getrpt_VENDOR_REPORT_PURCHASING_ORDER", tungay, denngay, 1, ma_qg, Commons.Modules.TypeLanguage, (rdVND.Checked) ? "1" : "0", MsKho));
                            _merge_table.Merge(_table);
                        }
                        else
                        {
                            _table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "Getrpt_VENDOR_REPORT_PURCHASING_ORDER", tungay, denngay,Convert.ToInt16(cbLoaiVT.SelectedValue.ToString()), ma_qg, Commons.Modules.TypeLanguage, (rdVND.Checked) ? "1" : "0"));
                            _merge_table.Merge(_table);
                        }
                    }

                }
                catch
                { }
                i++;

            }
            return _merge_table;

        }
        private void btnThuchien_Click(object sender, EventArgs e)
        {

            frmReportViewer_Y_PURCHASING_ORDER obj = new frmReportViewer_Y_PURCHASING_ORDER();
            obj._TableSource = List_Table();
            if (obj._TableSource.Rows.Count > 0)
            {
                obj.tungay = dtTungay.Value;
                obj.denngay = dtDenngay.Value;
                obj.loaiVt = cbLoaiVT.Text;
                tenqg1 = "";
                foreach (DataGridViewRow row in gvQuocgia.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        tenqg1 = tenqg1 + " " + row.Cells["TEN_QG"].Value.ToString();
                    }
                }

                obj.tenqg = tenqg1;
                obj.curr = rdVND.Checked ? "VNĐ" : "USD";
                string groupColumn = "", groupColumn1 = "";
                string t1 = "", t2 = "", t3 = "", t4 = "", t5 = "", t6 = "", t7 = "", t8 = "", t9 = "", t10 = "", t11 = "",t12="";
                
                foreach (DataColumn column in obj._TableSource.Columns)
                {
                    string colName = column.ColumnName;
                    switch (colName)
                    {
                        case "No":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "No", Commons.Modules.TypeLanguage);
                            break;
                        case "VATTU":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "VATTU", Commons.Modules.TypeLanguage);
                            groupColumn1 = column.ColumnName;
                            break;
                        case "TEN_CONG_TY":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "Vendor", Commons.Modules.TypeLanguage);
                            break;
                        case "QUOCGIA":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "Country", Commons.Modules.TypeLanguage);
                            groupColumn = column.ColumnName;
                            break;
                        case "1":
                            column.ColumnName = getMonth(0);
                            t1 = column.ColumnName;
                            break;
                        case "2":
                            column.ColumnName = getMonth(1);
                            t12 = column.ColumnName;
                            break;
                        case "3":
                            column.ColumnName = getMonth(2);
                            t3 = column.ColumnName;
                            break;
                        case "4":
                            column.ColumnName = getMonth(3);
                            t4 = column.ColumnName;
                            break;
                        case "5":
                            column.ColumnName = getMonth(4);
                            t5 = column.ColumnName;
                            break;
                        case "6":
                            column.ColumnName = getMonth(5);
                            t6 = column.ColumnName;
                            break;
                        case "7":
                            column.ColumnName = getMonth(6);
                            t7 = column.ColumnName;
                            break;
                        case "8":
                            column.ColumnName = getMonth(7);
                            t8 = column.ColumnName;
                            break;
                        case "9":
                            column.ColumnName = getMonth(8);
                            t9 = column.ColumnName;
                            break;
                        case "10":
                            column.ColumnName = getMonth(9);
                            t10 = column.ColumnName;
                            break;
                        case "11":
                            column.ColumnName = getMonth(10);
                            t11 = column.ColumnName;
                            break;
                        case "12":
                            column.ColumnName = getMonth(11);
                            t12 = column.ColumnName;
                            break;
                    }

                }
                
                obj.ecomaintGrid1.DataSource = obj._TableSource;
                obj.gridView1.PopulateColumns();
                obj.ecomaintGrid1.ExpressionGroupBy(obj.gridView1, groupColumn);
                obj.ecomaintGrid1.ExpressionGroupBy(obj.gridView1, groupColumn1);
                if (!string.IsNullOrEmpty(t1))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t1);
                if (!string.IsNullOrEmpty(t2))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t2);
                if (!string.IsNullOrEmpty(t3))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t3);

                if (!string.IsNullOrEmpty(t4))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t4);

                if (!string.IsNullOrEmpty(t5))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t5);

                if (!string.IsNullOrEmpty(t6))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t6);

                if (!string.IsNullOrEmpty(t7))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t7);

                if (!string.IsNullOrEmpty(t8))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t8);

                if (!string.IsNullOrEmpty(t9))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t9);
                if (!string.IsNullOrEmpty(t10))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t10);

                if (!string.IsNullOrEmpty(t11))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t11);

                if (!string.IsNullOrEmpty(t12))
                    obj.ecomaintGrid1.ExpressionSum(obj.gridView1, t12);

                obj.ShowDialog();
            }
            else
            {
                Vietsoft.Information.MsgBox(this.ParentForm, "MsgKocodulieu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            
            
           
        }
        private void cbLoaiVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadQuocGia();
                LoadKho();
            }
            catch { }
        }

        private void btnChonhetQG_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvQuocgia.Rows.Count)
            {
                try
                {
                    gvQuocgia.Rows[i].Cells["CHON"].Value = true;

                }
                catch
                { }
                i++;
            }
        }

        private void btnBochonQG_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvQuocgia.Rows.Count)
            {
                try
                {
                    gvQuocgia.Rows[i].Cells["CHON"].Value = false;

                }
                catch
                { }
                i++;
            }
        }


      

        private string getMonth(int index)
        {
            string var = "";
            switch (index)
            {
                case 0: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "JAN", Commons.Modules.TypeLanguage); break;
                case 1: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "FEB", Commons.Modules.TypeLanguage); break;
                case 2: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "MAR", Commons.Modules.TypeLanguage); break;
                case 3: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "APR", Commons.Modules.TypeLanguage); break;
                case 4: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "MAY", Commons.Modules.TypeLanguage); break;
                case 5: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "JUN", Commons.Modules.TypeLanguage); break;
                case 6: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "JUL", Commons.Modules.TypeLanguage); break;
                case 7: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "AUG", Commons.Modules.TypeLanguage); break;
                case 8: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "SEP", Commons.Modules.TypeLanguage); break;
                case 9: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "OCT", Commons.Modules.TypeLanguage); break;
                case 10: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "NOV", Commons.Modules.TypeLanguage); break;
                case 11: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "DEC", Commons.Modules.TypeLanguage); break;
            }
            return var;
        }
        private string getCol(int index)
        {
            string var = "";
            switch (index)
            {
                case 0: var = "C"; break;
                case 1: var = "D"; break;
                case 2: var = "E"; break;
                case 3: var = "F"; break;
                case 4: var = "G"; break;
                case 5: var = "H"; break;
                case 6: var = "I"; break;
                case 7: var = "J"; break;
                case 8: var = "K"; break;
                case 9: var = "L"; break;
                case 10: var = "M"; break;
                case 11: var = "N"; break;
                case 12: var = "O"; break;
                case 13: var = "P"; break;
                case 14: var = "Q"; break;
                case 15: var = "R"; break;
                case 16: var = "S"; break;
                case 17: var = "T"; break;
            }
            return var;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnALL_Click(object sender, EventArgs e)
        { 
            int i = 0;
            while (i < gvKho.Rows.Count)
            {
                try
                {
                    gvKho.Rows[i].Cells["CHON_KHO"].Value = true;
                }
                catch
                { }
                i++;
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvKho.Rows.Count)
            {
                try
                {
                    gvKho.Rows[i].Cells["CHON_KHO"].Value = false;
                }
                catch
                { }
                i++;
            }
        }
    }
}
