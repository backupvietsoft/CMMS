using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmrptVENDOR_REPORT_GOOD_RECEIPT : UserControl
    {
        DateTime tungay;
        DateTime denngay;
        string loaivt = "";
        string maqg = "", tenqg = "", tenqg1 = "";
        string grandtotal = "=";
        int col = 0;
        int[] totalcountry;
        int[] grand;
        int ttotal = 0;
        int tgrand = 0;
        public frmrptVENDOR_REPORT_GOOD_RECEIPT()
        {
            InitializeComponent();
        }
        private System.Data.DataTable List_Table()
        {
            tungay = dtTungay.Value;
            denngay = dtDenngay.Value;
            int i = 0;

            System.Data.DataTable _table = new System.Data.DataTable();
            System.Data.DataTable _merge_table = new System.Data.DataTable();
            Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);


            while (i < gvQuocgia.Rows.Count)
            {
                string ma_qg = "";
                try
                {
                    if ((bool)gvQuocgia.Rows[i].Cells["CHON"].Value)
                    {

                        ma_qg = gvQuocgia.Rows[i].Cells["MA_QG"].Value.ToString();

                        System.Data.DataTable _myTable = new System.Data.DataTable();
                        int kho = (int)cbKho.SelectedValue;

                        if (cbLoaiVT.SelectedValue.ToString() == "-1")
                        {
                            _table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetrptVENDOR_REPORT_GOOD_RECEIPT", kho, tungay, denngay, 0, ma_qg, Vietsoft.Information.Language, (rdVND.Checked) ? "1" : "0"));
                            //_table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "Getrpt_VENDOR_REPORT_PURCHASING_ORDER", tungay, denngay, 0, ma_qg, Vietsoft.Information.Language, (rdVND.Checked) ? "1" : "0"));
                            _merge_table.Merge(_table);
                            _table = new System.Data.DataTable();
                            _table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetrptVENDOR_REPORT_GOOD_RECEIPT", kho, tungay, denngay, 1, ma_qg, Vietsoft.Information.Language, (rdVND.Checked) ? "1" : "0"));
                            //_table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "Getrpt_VENDOR_REPORT_PURCHASING_ORDER", tungay, denngay, 1, ma_qg, Vietsoft.Information.Language, (rdVND.Checked) ? "1" : "0"));
                            _merge_table.Merge(_table);
                        }
                        else
                        {
                            _table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetrptVENDOR_REPORT_GOOD_RECEIPT", kho, tungay, denngay, Convert.ToInt16(cbLoaiVT.SelectedValue.ToString()), ma_qg, Vietsoft.Information.Language, (rdVND.Checked) ? "1" : "0"));
                            //_table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "Getrpt_VENDOR_REPORT_PURCHASING_ORDER", tungay, denngay, Convert.ToInt16(cbLoaiVT.SelectedIndex.ToString()), ma_qg, Vietsoft.Information.Language, (rdVND.Checked) ? "1" : "0"));
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
            frmReportViewer_Y_Good_Receiver obj = new frmReportViewer_Y_Good_Receiver();
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
                string t1 = "", t2 = "", t3 = "", t4 = "", t5 = "", t6 = "", t7 = "", t8 = "", t9 = "", t10 = "", t11 = "", t12 = "";

                foreach (DataColumn column in obj._TableSource.Columns)
                {
                    string colName = column.ColumnName;
                    switch (colName)
                    {
                        case "No":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "No", Vietsoft.Information.Language);
                            break;
                        case "VATTU":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "VATTU", Vietsoft.Information.Language);
                            groupColumn1 = column.ColumnName;
                            break;
                        case "TEN_CONG_TY":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "Vendor", Vietsoft.Information.Language);
                            break;
                        case "QUOCGIA":
                            column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_PURCHASING_ORDER", "Country", Vietsoft.Information.Language);
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
            //loaivt = "";
            //maqg = ""; tenqg = "";
            //try
            //{
            //    tungay = dtTungay.Value;
            //    denngay = dtDenngay.Value;
            //    int i = 0;
            //    while (i < gvQuocgia.Rows.Count)
            //    {
            //        try
            //        {
            //            if ((bool)gvQuocgia.Rows[i].Cells["CHON"].Value)
            //            {
            //                if (maqg == "")
            //                    maqg = "'" + gvQuocgia.Rows[i].Cells["MA_QG"].Value.ToString() + "'";
            //                else
            //                    maqg += ", '" + gvQuocgia.Rows[i].Cells["MA_QG"].Value.ToString() + "'";

            //                if (tenqg == "")
            //                    tenqg = gvQuocgia.Rows[i].Cells["TEN_QG"].Value.ToString();
            //                else
            //                    tenqg += ", " + gvQuocgia.Rows[i].Cells["TEN_QG"].Value.ToString();
            //            }
            //        }
            //        catch
            //        { }
            //        i++;
            //    }

            //    XuatExcel();
            //}
            //catch { }
        }

        private void frmrptVENDOR_REPORT_GOOD_RECEIPT_Load(object sender, EventArgs e)
        {
            LoadLoaivt();
            LoadQuocGia();
            LoadKho();
            dtTungay.Value = DateTime.Today.AddMonths(-1);
            dtDenngay.Value = DateTime.Today;
        }
        private void LoadKho()
        {
            try
            {
                System.Data.DataTable dtTable = new System.Data.DataTable();
                Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

                dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetIC_KHOs"));
                DataRow rowall = dtTable.NewRow();
                rowall["MS_KHO"] = -1;
                rowall["TEN_KHO"] = "All";
                dtTable.Rows.Add(rowall);
                cbKho.DataSource = dtTable;
                cbKho.DisplayMember = "TEN_KHO";
                cbKho.ValueMember = "MS_KHO";
            }
            catch { }
        }

        private void LoadQuocGia()
        {
            try
            {
                System.Data.DataTable dtTable = new System.Data.DataTable();
                Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

                dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetQUOC_GIAbyLoaiVT", cbLoaiVT.SelectedValue));
                gvQuocgia.DataSource = dtTable;
                gvQuocgia.Columns["CHON"].ReadOnly = false;
                gvQuocgia.Columns["MA_QG"].ReadOnly = true;
                gvQuocgia.Columns["TEN_QG"].Visible = true;
                gvQuocgia.Columns["MA_QG"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "MA_QG", Vietsoft.Information.Language);
                gvQuocgia.Columns["TEN_QG"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "TEN_QG", Vietsoft.Information.Language);
                gvQuocgia.Columns["CHON"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "CHON", Vietsoft.Information.Language);
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
            row["LoaiVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "SparePart", Vietsoft.Information.Language);
            dt.Rows.Add(row);

            DataRow row1 = dt.NewRow();
            row1["LoaiID"] = 1;
            row1["LoaiVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "Consumtion", Vietsoft.Information.Language);
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


        private void XuatExcel()
        {
            try
            {
                if (tungay <= denngay)
                {
                    grandtotal = "=";
                    if (denngay.Month > tungay.Month && tungay.Year == denngay.Year)
                        col = denngay.Month - tungay.Month + 1;
                    else if (tungay.Year < denngay.Year)
                        col = 12 + denngay.Month - tungay.Month + 1;
                    else
                        col = 1;
                }
                else
                {
                    Vietsoft.Information.MsgBox(this.ParentForm, "tuthangnhohondenthang", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (maqg.Trim() != "")
                {
                    #region Title Excel

                    Excel.Application ExcelApp;
                    Excel.Workbook objBook;
                    Excel.Worksheet objSheet;

                    ExcelApp = new Excel.ApplicationClass();

                    ExcelApp.Visible = false;
                    this.Cursor = Cursors.WaitCursor;
                    objBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                    objSheet = (Excel.Worksheet)objBook.Sheets["Sheet1"];
                    objSheet.Name = "MAINTENANCE VENDORS REPORT";

                    objSheet.Cells[1, 1] = "Details";

                    System.Data.DataTable dtThongtin = new System.Data.DataTable();
                    Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

                    dtThongtin.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetTHONG_TIN_CHUNG"));

                    Excel.Range namecompany = objSheet.get_Range("A1", "C1");
                    namecompany.Font.Bold = true;
                    namecompany.MergeCells = true;
                    namecompany.Font.Bold = true;
                    namecompany.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    namecompany.Value2 = dtThongtin.Rows[0]["TEN_CTY_TIENG_ANH"].ToString();

                    Excel.Range dccty = objSheet.get_Range("A2", "C2");
                    dccty.Font.Bold = true;
                    dccty.MergeCells = true;
                    dccty.Font.Bold = true;
                    dccty.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    dccty.Value2 = dtThongtin.Rows[0]["DIA_CHI_ANH"].ToString();

                    Excel.Range tel = objSheet.get_Range("A3", "B3");
                    tel.Font.Bold = true;
                    tel.MergeCells = true;
                    tel.Font.Bold = true;
                    tel.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    tel.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "Tel", Vietsoft.Information.Language) + " " + dtThongtin.Rows[0]["Phone"].ToString();

                    Excel.Range fax = objSheet.get_Range("C3", "D3");
                    fax.Font.Bold = true;
                    fax.MergeCells = true;
                    fax.Font.Bold = true;
                    fax.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    fax.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "Fax", Vietsoft.Information.Language) + " " + dtThongtin.Rows[0]["Fax"].ToString();


                    Excel.Range TieuDe = objSheet.get_Range("A4", "O4");
                    TieuDe.Merge(true);
                    TieuDe.MergeCells = true;
                    TieuDe.Font.Bold = true;
                    TieuDe.Font.Size = 18;
                    TieuDe.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "rptVENDOR_REPORT_GOOD_RECEIPT", Vietsoft.Information.Language);
                    TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                    Excel.Range ngay = objSheet.get_Range("A5", "O5");
                    ngay.Font.Bold = true;
                    ngay.Merge(true);
                    ngay.MergeCells = true;
                    ngay.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    ngay.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "tuthang", Vietsoft.Information.Language) + " " + tungay.ToShortDateString().Remove(0, 3) + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "denthang", Vietsoft.Information.Language) + " " + denngay.ToShortDateString().Remove(0, 3);

                    Excel.Range country = objSheet.get_Range("A6", "O6");
                    country.Font.Bold = true;
                    country.Merge(true);
                    country.MergeCells = true;
                    country.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    country.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "Country", Vietsoft.Information.Language) + " " + tenqg.Replace("'", "");

                    Excel.Range currency = objSheet.get_Range("A7", "O7");
                    currency.Font.Bold = true;
                    currency.Merge(true);
                    currency.MergeCells = true;
                    currency.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    currency.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "Currency", Vietsoft.Information.Language) + " " + (string)((rdUSD.Checked) ? "USD" : "VND");

                    Excel.Range mate_type = objSheet.get_Range("A8", "O8");
                    mate_type.Font.Bold = true;
                    mate_type.Merge(true);
                    mate_type.MergeCells = true;
                    mate_type.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    mate_type.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "Warehouse", Vietsoft.Information.Language) + " " + cbKho.Text;

                    #endregion
                    int row = 10;
                    int i = 0;
                    totalcountry = new int[2];
                    grand = new int[gvQuocgia.Rows.Count * 2];
                    tgrand = 0;
                    while (i < gvQuocgia.Rows.Count)
                    {
                        string ten_qg = "", ma_qg = "";
                        try
                        {
                            int f = -1, f1 = -1, f2 = -1;
                            if ((bool)gvQuocgia.Rows[i].Cells["CHON"].Value)
                            {
                                ma_qg = "'" + gvQuocgia.Rows[i].Cells["MA_QG"].Value.ToString() + "'";
                                ten_qg = gvQuocgia.Rows[i].Cells["TEN_QG"].Value.ToString();

                                System.Data.DataTable dtTable = new System.Data.DataTable();

                                HeaderTable(objSheet, ten_qg, row);
                                int kho = (int)cbKho.SelectedValue;
                                if (cbKho.Text != "")
                                    if (cbLoaiVT.SelectedValue.ToString() == "-1")
                                    {
                                        ttotal = 0;
                                        dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetrptVENDOR_REPORT_GOOD_RECEIPT", kho, tungay, denngay, 0, ma_qg, Vietsoft.Information.Language, (rdVND.Checked) ? "1" : "0"));
                                        if (dtTable.Rows.Count > 0)
                                        {
                                            f1 = 0;
                                            row = row + 2;
                                            row = PrintData(objSheet, row, dtTable, 1);

                                        }
                                        else
                                        {
                                            f1 = 1;
                                            row--;
                                        }
                                        dtTable.Clear();

                                        dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetrptVENDOR_REPORT_GOOD_RECEIPT", kho, tungay, denngay, 1, ma_qg, Vietsoft.Information.Language, (rdVND.Checked) ? "1" : "0"));
                                        if (dtTable.Rows.Count > 0)
                                        {
                                            f2 = 0;
                                            row = row + 1;
                                            row = PrintData(objSheet, row, dtTable, 2);
                                        }
                                        else
                                            f2 = 1;
                                    }
                                    else
                                    {
                                        dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetrptVENDOR_REPORT_GOOD_RECEIPT", kho, tungay, denngay, cbLoaiVT.SelectedValue, ma_qg, Vietsoft.Information.Language, (rdVND.Checked) ? "1" : "0"));
                                        if (dtTable.Rows.Count > 0)
                                        {
                                            f = 0;
                                            ttotal = 0;
                                            row = row + 2;
                                            int lovt = Int32.Parse(((DataRowView)cbLoaiVT.Items[cbLoaiVT.SelectedIndex])[0].ToString());
                                            row = PrintData(objSheet, row, dtTable, lovt + 1);
                                        }
                                        else
                                            f = 1;
                                    }
                            }
                            row++;
                            if ((f1 == 0 && f2 == 0) || (f1 == 1 && f2 == 0) || (f1 == 0 && f2 == 1) || f == 0)
                            {
                                //total of country
                                Excel.Range totalofcountry = objSheet.get_Range("A" + row.ToString(), "B" + row.ToString());
                                totalofcountry.Font.Bold = true;
                                totalofcountry.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                totalofcountry.Merge(true);
                                totalofcountry.MergeCells = true;
                                totalofcountry.HorizontalAlignment = XlHAlign.xlHAlignRight;
                                totalofcountry.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "TotalOfCountry", Vietsoft.Information.Language);

                                for (int c = 0; c < col; c++)
                                {
                                    //Excel.XlBorderWeight.xlThin
                                    Excel.Range CountryTotal = objSheet.get_Range(getCol(c) + row.ToString(), getCol(c) + row.ToString());
                                    CountryTotal.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                    CountryTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                                    CountryTotal.Font.Bold = true;
                                    string ssum = "=";
                                    for (int s = 0; s < totalcountry.Length; s++)
                                    {
                                        if (totalcountry[s] != 0)
                                        {
                                            if (ssum != "=")
                                                ssum += "+" + getCol(c) + totalcountry[s];
                                            else ssum += getCol(c) + totalcountry[s];
                                        }
                                    }
                                    CountryTotal.Value2 = ssum;
                                }
                            }

                            row++;
                        }
                        catch
                        { }
                        i++;
                    }
                    //Grand Total
                    Excel.Range GrandTotal = objSheet.get_Range("A" + row.ToString(), "B" + row.ToString());
                    GrandTotal.Font.Bold = true;
                    GrandTotal.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    GrandTotal.Merge(true);
                    GrandTotal.MergeCells = true;
                    GrandTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    GrandTotal.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "GrandTotal", Vietsoft.Information.Language);

                    for (int c = 0; c < col; c++)
                    {
                        Excel.Range grTotal = objSheet.get_Range(getCol(c) + row.ToString(), getCol(c) + row.ToString());
                        grTotal.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        grTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        grTotal.Font.Bold = true;
                        string ssum = "=";
                        for (int s = 0; s < grand.Length; s++)
                        {
                            if (grand[s] != 0)
                            {
                                if (ssum != "=")
                                    ssum += "+" + getCol(c) + grand[s];
                                else ssum += getCol(c) + grand[s];
                            }
                        }
                        grTotal.Value2 = ssum;
                    }

                    Excel.Range GrandTotal1 = objSheet.get_Range(getCol(col) + row.ToString(), getCol(col) + row.ToString());
                    GrandTotal1.Font.Bold = true;
                    GrandTotal1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    GrandTotal1.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    GrandTotal1.Value2 = "";
                    Excel.Range GrandTotal2 = objSheet.get_Range(getCol(col + 1) + row.ToString(), getCol(col + 1) + row.ToString());
                    GrandTotal2.Font.Bold = true;
                    GrandTotal2.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    GrandTotal2.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    GrandTotal2.Value2 = "";

                    ExcelApp.Visible = true;
                }
                else
                {
                    Vietsoft.Information.MsgBox(this.ParentForm, "MsgKocodulieu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                }
            }
            catch { }


            this.Cursor = Cursors.Default;
        }

        private int PrintData(Excel.Worksheet objSheet, int row, System.Data.DataTable dtDetail, int vt)
        {
            int count = 0;
            try
            {
                int top = row + 1;
                Excel.Range loaivt = objSheet.get_Range("A" + row, getCol(col + 1) + row);
                loaivt.Merge(true);
                loaivt.MergeCells = true;
                loaivt.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                loaivt.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                loaivt.Value2 = ((DataRowView)cbLoaiVT.Items[vt])[1].ToString();
                loaivt.Font.Bold = true;

                row++;

                for (int c = 1; c <= col; c++)
                {
                    int r = row;
                    DataRow[] drow = dtDetail.Select();
                    DataView dv = dtDetail.DefaultView;
                    System.Data.DataTable dt = dv.ToTable(true, "TEN_CONG_TY");


                    int index = 0;
                    for (index = 0; index < dt.Rows.Count; index++)
                    {
                        int thang = tungay.Month;

                        //Excel.Range subTotal1 = objSheet.get_Range(getCol(col) + count.ToString(), getCol(col) + count.ToString());
                        //subTotal1.Font.Bold = true;
                        //subTotal1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        //subTotal1.HorizontalAlignment = XlHAlign.xlHAlignRight;
                        //subTotal1.Value2 = "";


                        Excel.Range No = objSheet.get_Range("A" + r.ToString(), "A" + r.ToString());
                        No.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        No.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        No.Value2 = index + 1;

                        Excel.Range CTY = objSheet.get_Range("B" + r.ToString(), "B" + r.ToString());
                        CTY.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        CTY.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        CTY.WrapText = true;
                        CTY.Value2 = dt.Rows[index][0];
                        for (int co = 0; co < col; co++)
                        {
                            try
                            {
                                string select = "TEN_CONG_TY = '" + dt.Rows[index][0].ToString() + "' AND MON='" + (thang).ToString() + "'";
                                DataRow[] rowdt = dtDetail.Select(select);

                                if (rowdt != null)
                                {

                                    Excel.Range TT = objSheet.get_Range(getCol(co) + r.ToString(), getCol(co) + r.ToString());
                                    TT.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                    TT.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    TT.Value2 = rowdt[0]["TIEN_THANG"];
                                    TT.NumberFormat = "#,##0.00";
                                }

                            }
                            catch { }
                            if (thang > 12) thang = 1;
                            else thang++;
                        }

                        Excel.Range TOTAL = objSheet.get_Range(getCol(col) + r.ToString(), getCol(col) + r.ToString());
                        TOTAL.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        TOTAL.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        TOTAL.Font.Bold = true;
                        TOTAL.Value2 = "=SUM(C" + r.ToString() + ":" + getCol(col - 1) + r.ToString() + ")";
                        TOTAL.NumberFormat = "#,##0.00";

                        Excel.Range modulo = objSheet.get_Range(getCol(col + 1) + r.ToString(), getCol(col + 1) + r.ToString());
                        modulo.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        modulo.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        modulo.Font.Bold = true;
                        modulo.Value2 = "";
                        r++;
                    }
                    count = r;

                }

                Excel.Range lblSubTotal = objSheet.get_Range("A" + count.ToString(), "B" + count.ToString());
                lblSubTotal.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                lblSubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                lblSubTotal.Merge(true);
                lblSubTotal.Font.Bold = true;
                lblSubTotal.MergeCells = true;
                lblSubTotal.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "SubTotal", Vietsoft.Information.Language);


                for (int c = 0; c < col; c++)
                {
                    Excel.Range SubTotal = objSheet.get_Range(getCol(c) + count.ToString(), getCol(c) + count.ToString());
                    SubTotal.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    SubTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    SubTotal.Font.Bold = true;
                    SubTotal.NumberFormat = "#,##0.00";
                    if (top != count - 1)
                        SubTotal.Value2 = "=SUM(" + getCol(c) + top + ":" + getCol(c) + (count - 1) + ")";
                    else
                        SubTotal.Value2 = "=" + getCol(c) + top;
                }

                Excel.Range subTotal1 = objSheet.get_Range(getCol(col) + count.ToString(), getCol(col) + count.ToString());
                subTotal1.Font.Bold = true;
                subTotal1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                subTotal1.HorizontalAlignment = XlHAlign.xlHAlignRight;
                subTotal1.Value2 = "";
                Excel.Range subTotal2 = objSheet.get_Range(getCol(col + 1) + count.ToString(), getCol(col + 1) + count.ToString());
                subTotal2.Font.Bold = true;
                subTotal2.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                subTotal2.HorizontalAlignment = XlHAlign.xlHAlignRight;
                subTotal2.Value2 = "";

                totalcountry[ttotal] = count;
                ttotal++;

                grand[tgrand] = count;
                tgrand++;
                Excel.Range GrandTotal = objSheet.get_Range(getCol(col) + count.ToString(), getCol(col) + count.ToString());
                GrandTotal.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                GrandTotal.HorizontalAlignment = XlHAlign.xlHAlignRight;
                GrandTotal.Font.Bold = true;
                GrandTotal.NumberFormat = "#,##0.00";
                GrandTotal.Value2 = "=SUM(" + getCol(col) + top + ":" + getCol(col) + (count - 1) + ")";

                Excel.Range amountnull = objSheet.get_Range(getCol(col + 1) + count.ToString(), getCol(col + 1) + count.ToString());
                amountnull.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                amountnull.Value2 = "";
            }
            catch { }
            return count;
        }

        private void HeaderTable(Excel.Worksheet objSheet, string tenqg, int row)
        {
            Excel.Range quocgia = objSheet.get_Range("A" + row, getCol(col + 1) + row);
            quocgia.Font.Bold = true;
            quocgia.Merge(true);
            quocgia.MergeCells = true;
            quocgia.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            quocgia.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            quocgia.Value2 = tenqg;

            row++;
            //header table
            Excel.Range date = objSheet.get_Range("A" + row, "A" + row);
            date.Font.Bold = true;
            date.ColumnWidth = 10;
            date.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            date.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            date.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "No", Vietsoft.Information.Language);

            Excel.Range company = objSheet.get_Range("B" + row, "B" + row);
            company.Font.Bold = true;
            company.ColumnWidth = 15;
            company.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            company.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            company.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "Vendor", Vietsoft.Information.Language);

            int j = 0;
            int ngay = tungay.Month - 1;
            for (j = 0; j < col; j++)
            {
                Excel.Range request = objSheet.get_Range(getCol(j) + row, getCol(j) + row);
                request.Font.Bold = true;
                request.ColumnWidth = 10;
                request.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                request.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                request.Value2 = getMonth(ngay);
                ngay += 1;
                if (ngay > 11) ngay %= 12;
            }
            Excel.Range materialcode = objSheet.get_Range(getCol(j) + row, getCol(j) + row);
            materialcode.ColumnWidth = 15;
            materialcode.Font.Bold = true;
            materialcode.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            materialcode.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            materialcode.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "Total", Vietsoft.Information.Language);

            j++;
            Excel.Range materialname = objSheet.get_Range(getCol(j) + row, getCol(j) + row);
            materialname.Font.Bold = true;
            materialname.ColumnWidth = 25;
            materialname.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            materialname.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            materialname.Value2 = "%";

        }

        private string getMonth(int index)
        {
            string var = "";
            switch (index)
            {
                case 0: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "JAN", Vietsoft.Information.Language); break;
                case 1: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "FEB", Vietsoft.Information.Language); break;
                case 2: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "MAR", Vietsoft.Information.Language); break;
                case 3: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "APR", Vietsoft.Information.Language); break;
                case 4: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "MAY", Vietsoft.Information.Language); break;
                case 5: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "JUN", Vietsoft.Information.Language); break;
                case 6: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "JUL", Vietsoft.Information.Language); break;
                case 7: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "AUG", Vietsoft.Information.Language); break;
                case 8: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "SEP", Vietsoft.Information.Language); break;
                case 9: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "OCT", Vietsoft.Information.Language); break;
                case 10: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "NOV", Vietsoft.Information.Language); break;
                case 11: var = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVENDOR_REPORT_GOOD_RECEIPT", "DEC", Vietsoft.Information.Language); break;
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
     
    }
}
