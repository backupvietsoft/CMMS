using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Excel;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace WareHouse
{
    public partial class frmrptMONTHLY_MAINTENANCE_MATERIAL_REPORT : UserControl
    {
        
        DateTime tungay;
        DateTime denngay;
        Vietsoft.SqlInfo SqlPhieu;
        System.Data.DataTable vtbClass;
        int[] total; int ttotal = 0;
        public frmrptMONTHLY_MAINTENANCE_MATERIAL_REPORT()
        {
            InitializeComponent();
        }
        private void frmrptMONTHLY_MAINTENANCE_MATERIAL_REPORT_Load(object sender, EventArgs e)
        {
            SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            LoadLoaivt();
            LoadKho();
            LoadClass();
            dtTungay.Value = DateTime.Today.AddMonths(-1);
            dtDenngay.Value = DateTime.Today;
        }
        private void LoadClass()
        {
            try
            {
                vtbClass = new System.Data.DataTable();
                vtbClass.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "H_GET_CLASS"));

                DataRow vrAll = vtbClass.NewRow();
                vrAll["MS_CLASS"] = -1;
                vrAll["TEN_CLASS"] = "<All>";
                vtbClass.Rows.InsertAt(vrAll, 0);
                cbClass.DataSource = vtbClass;
                cbClass.ValueMember = "MS_CLASS";
                cbClass.DisplayMember = "TEN_CLASS";
            }
            catch { }
        }
        private void LoadKho()
        {
            try
            {
                System.Data.DataTable dtTable = new System.Data.DataTable();
                dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetIC_KHOs"));

                cbKho.DataSource = dtTable;
                cbKho.DisplayMember = "TEN_KHO";
                cbKho.ValueMember = "MS_KHO";
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
       

        private void btnThuchien_Click(object sender, EventArgs e)
        {
            //XuatExcel();
            
            System.Data.DataTable dtData = new System.Data.DataTable();
            dtData.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "Getrpt_MonthlyMaintanceMaterialReport", cbKho.SelectedValue, dtTungay.Value, dtDenngay.Value.AddDays(1).AddSeconds(-1), Commons.Modules.TypeLanguage, (rdVND.Checked) ? "1" : "0",Convert.ToInt32(cbClass.SelectedValue), cbLoaiVT.SelectedValue));
            frmReportViewer_Y_MATERIAL obj = new frmReportViewer_Y_MATERIAL();
            obj._TableSource = dtData;
            obj.tungay = dtTungay.Value;
            obj.denngay = dtDenngay.Value;
            obj.loaiVt = cbLoaiVT.Text;
            obj.nha_kho = cbKho.Text;
            obj.curr = rdVND.Checked ? "VNĐ" : "USD";
         
            obj.ecomaintGrid1.DataSource = obj._TableSource;
            try
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in obj.gridView1.Columns)
                {
                    col.AppearanceHeader.Options.UseTextOptions = true;
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", col.FieldName, Commons.Modules.TypeLanguage);
                }
            }
            catch { 
            }
            obj.ecomaintGrid1.ExpressionGroupBy(obj.gridView1, "TEN_CLASS");
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "SL_TON_DAU");
            //obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "GIA_TRI_TON_DAU");

            //GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            //item1.FieldName = "GIA_TRI_TON_DAU";
            //item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //item1.DisplayFormat = "Total {0:c2}";
            //item1.ShowInGroupColumnFooter = obj.gridView1.Columns["GIA_TRI_TON_DAU"];

            String sTong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MAINTENANCE_MATERIAL_REPORT", "excTongTien", Commons.Modules.TypeLanguage);

            obj.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GIA_TRI_TON_DAU",obj.gridView1.Columns["GIA_TRI_TON_DAU"],sTong + " {0:N2}")});



            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "SL_NHAP");
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "MOVED");
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "MOVE_AMOUNT");
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "SL_TON_HT");
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "GIA_TRI_TON_HT");
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "SL_XUAT");
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "GIA_TRI_XUAT");
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "GIA_TRI_NHAP");
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "CHENH_LECH_KIEM_KE");
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, "GIA_TRI_CHENH_LECH");
          
            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "SL_TON_DAU");
            //obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "GIA_TRI_TON_DAU");

            obj.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GIA_TRI_TON_DAU",obj.gridView1.Columns["GIA_TRI_TON_DAU"],"Total {0:N2}")});

            obj.gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "GIA_TRI_TON_DAU", obj.gridView1.Columns["GIA_TRI_TON_DAU"], sTong + " {0:N2}");
            obj.gridView1.Columns["GIA_TRI_TON_DAU"].SummaryItem.DisplayFormat = sTong + " {0:N2}";
            obj.gridView1.Columns["GIA_TRI_TON_DAU"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;


            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "SL_NHAP");
            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "MOVED");
            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "MOVE_AMOUNT");
            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "SL_TON_HT");
            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "GIA_TRI_TON_HT");
            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "SL_XUAT");
            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "GIA_TRI_XUAT");
            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "GIA_TRI_NHAP");
            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "CHENH_LECH_KIEM_KE");
            obj.ecomaintGrid1.ExpresSumFooter(obj.gridView1, "GIA_TRI_CHENH_LECH");
            
            
            obj.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
