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
    public partial class frmrptMONTHLY_PO_APPROVED : UserControl
    {
        DateTime tungay;
        DateTime denngay;
        string loaivt = "";
        string maqg = "", tenqg = "",tenqg1;
        string grandtotal = "=";
        public frmrptMONTHLY_PO_APPROVED()
        {
            InitializeComponent();
        }

        private void frmrptMONTHLY_PO_APPROVED_Load(object sender, EventArgs e)
        {
            LoadLoaivt();
            LoadQuocGia();
            LoadKho();
            dtTungay.Value = DateTime.Today.AddMonths(-1);
            dtDenngay.Value = DateTime.Today;
        }
        private Boolean KiemChon(DataGridView dtg, string CotChon)
        {
            int i = 0;
            

            while (i < dtg.Rows.Count)
            {
                try
                {
                    if ((bool)dtg.Rows[i].Cells[CotChon].Value)
                    {
                        return true;
                    }
                }
                catch { }
                i++;
            }


            return false;
        }

        private void btnThuchien_Click(object sender, EventArgs e)
        {
            if (!KiemChon(gvQuocgia, "CHON"))
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "KhongChonQuocGia",
                    Commons.Modules.TypeLanguage));
                return;
            }
            if (!KiemChon(gvKho, "CHON_KHO"))
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "KhongChonKho",
                    Commons.Modules.TypeLanguage));
                return;
            }
 
            frmReportViewer_Approved obj = new frmReportViewer_Approved();
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
                string groupColumn = "";
                string amount = "";
                foreach (DataColumn column in obj._TableSource.Columns)
                {
                    string colName = column.ColumnName;
                    switch (colName)
                    {
                        case "No":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "No", Commons.Modules.TypeLanguage);
                            break;
                        case "SO_DON_DAT_HANG":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "PoNo", Commons.Modules.TypeLanguage);
                            break;
                        case "SO_DE_XUAT":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "RequestNo", Commons.Modules.TypeLanguage);
                            break;

                        case "GHI_CHU":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "Description", Commons.Modules.TypeLanguage);
                            break;
                        case "THANH_TIEN":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "Amount", Commons.Modules.TypeLanguage);
                            amount = column.ColumnName;
                            break;
                        case "TEN_CONG_TY":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "Vendor", Commons.Modules.TypeLanguage);
                            break;
                        case "QUOCGIA":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "Country", Commons.Modules.TypeLanguage);
                            groupColumn = column.ColumnName;
                            break;

                    }
                }
                obj.ecomaintGrid1.DataSource = obj._TableSource;
                obj.gridView1.PopulateColumns();
                obj.ecomaintGrid1.ExpressionGroupBy(obj.gridView1, groupColumn);

                obj.ecomaintGrid1.ExpressionSum(obj.gridView1, amount);
                obj.ShowDialog();
            }
            else
            {
                Vietsoft.Information.MsgBox(this.ParentForm, "MsgKocodulieu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
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
                gvQuocgia.Columns["MA_QG"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "MA_QG", Commons.Modules.TypeLanguage);
                gvQuocgia.Columns["TEN_QG"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "TEN_QG", Commons.Modules.TypeLanguage);
                gvQuocgia.Columns["CHON"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_PO_APPROVED", "CHON", Commons.Modules.TypeLanguage);
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
            DataRow row = dt.NewRow();
            row["LoaiID"] = "0";
            row["LoaiVT"] = "Spare Part";
            dt.Rows.Add(row);

            DataRow row1 = dt.NewRow();
            row1["LoaiID"] = "1";
            row1["LoaiVT"] = "Consumtion";
            dt.Rows.Add(row1);

            cbLoaiVT.DataSource = dt;
            cbLoaiVT.ValueMember = "LoaiID";
            cbLoaiVT.DisplayMember = "LoaiVT";


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
                        // ma_qg = gvQuocgia.Rows[i].Cells["MA_QG"].Value.ToString();
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
                           // ma_qg = gvQuocgia.Rows[i].Cells["MA_QG"].Value.ToString();
                            ma_qg = "'" + gvQuocgia.Rows[i].Cells["MA_QG"].Value.ToString() + "'";
                           // ten_qg = gvQuocgia.Rows[i].Cells["TEN_QG"].Value.ToString();
                            System.Data.DataTable _myTable = new System.Data.DataTable();
                            _table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "Getrpt_MonthlyPOApproved", tungay, denngay, cbLoaiVT.SelectedValue, ma_qg, Commons.Modules.TypeLanguage, (rdVND.Checked) ? "1" : "0", MsKho));
                            
                            _merge_table.Merge(_table);
                        }

                    }
                    catch
                    { }
                    i++;

                }
                return _merge_table;
           
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

        private void btnNO_Click(object sender, EventArgs e)
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
