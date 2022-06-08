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
    public partial class frmrptMONTHLY_MATERIAL_OUTPUT_LIST : UserControl
    {
        DateTime tungay;
        DateTime denngay;
        string loaivt = "";
        string madx = "", tendx = "",tendx1="";
        string mavt = "";
        string grandtotal = "=";
        int col = 0;
        int[] totalcountry;
        int[] grand;
        int ttotal = 0;
        int tgrand = 0;
        System.Data.DataTable dtTable = new System.Data.DataTable();

        public frmrptMONTHLY_MATERIAL_OUTPUT_LIST()
        {
            InitializeComponent();
        }

        private void frmrptMONTHLY_MATERIAL_OUTPUT_LIST_Load(object sender, EventArgs e)
        {
            LoadLoaivt();
            LoadKho();
            LoadDangXuat();
            dtTungay.Value = DateTime.Today.AddMonths(-1);
            dtDenngay.Value = DateTime.Today;
        }
        private System.Data.DataTable List_Table()
        {
            loaivt = "";
            madx = "<ROOT>"; tendx = "";
            mavt = "<ROOT>";

            tungay = dtTungay.Value;
            denngay = dtDenngay.Value;
            int kho = (int)cbKho.SelectedValue;
            int i = 0;
            while (i < gvDangxuat.Rows.Count)
            {
                try
                {
                    if ((bool)gvDangxuat.Rows[i].Cells["CHON"].Value)
                    {
                        if (madx == "<ROOT>")
                            madx += "<DX ID=\"" + gvDangxuat.Rows[i].Cells["MS_DANG_XUAT"].Value.ToString() + "\"/>";
                        else
                            madx += "<DX ID=\"" + gvDangxuat.Rows[i].Cells["MS_DANG_XUAT"].Value.ToString() + "\"/>";

                        if (tendx == "")
                            tendx = gvDangxuat.Rows[i].Cells["DANG_XUAT"].Value.ToString();
                        else
                            tendx += ", " + gvDangxuat.Rows[i].Cells["DANG_XUAT"].Value.ToString();
                    }
                }
                catch
                { }
                i++;
            }
            madx += "</ROOT>";
            i = 0;
            while (i < gvVTPT.Rows.Count)
            {
                try
                {
                    if ((bool)gvVTPT.Rows[i].Cells["CHONPT"].Value)
                    {
                        if (mavt == "<ROOT>")
                            mavt += "<PHUTUNG id=\"" + gvVTPT.Rows[i].Cells["MS_PT"].Value.ToString() + "\"/>";
                        else
                            mavt += "<PHUTUNG id=\"" + gvVTPT.Rows[i].Cells["MS_PT"].Value.ToString() + "\"/>";
                    }
                }
                catch
                { }
                i++;
            }
            mavt += "</ROOT>";
            System.Data.DataTable _table = new System.Data.DataTable();
            Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            _table.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetrptMONTHLY_MATERIAL_OUTPUT_LIST", kho, tungay, denngay, cbLoaiVT.SelectedValue, mavt, madx, Commons.Modules.TypeLanguage, (rdVND.Checked) ? "1" : "0"));
            return _table;

        }
        private void btnThuchien_Click(object sender, EventArgs e)
        {
            
            //loaivt = "";
            if (tungay <= denngay)
            {
                if (denngay.Month > tungay.Month && tungay.Year == denngay.Year)
                    col = denngay.Month - tungay.Month + 1;
                else if (tungay.Year < denngay.Year)
                    col = 12 + denngay.Month - tungay.Month + 1;
                else
                    col = 1;
            }
            else
            {
                Vietsoft.Information.MsgBox(this.ParentForm, "tungaynhohondenngay", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            tendx1 = "";
            foreach (DataGridViewRow row in gvDangxuat.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    if (tendx1.Length>0)
                        tendx1 = tendx1 + " ; " + row.Cells["DANG_XUAT"].Value.ToString();
                    else
                        tendx1 = row.Cells["DANG_XUAT"].Value.ToString();
                }
            }
            
            frmReportViewer_Y_OUTPUT_LIST obj = new frmReportViewer_Y_OUTPUT_LIST();
            obj._TableSource = List_Table();
            obj.tungay = tungay;
            obj.denngay = denngay;
            obj.curr = rdVND.Checked ? "VNĐ" : "USD";
            obj.nha_kho = cbKho.Text;
            obj.loai_vt = cbLoaiVT.Text;
            obj.tendangxuat = tendx1;
            string groupColumn = "";
            string amount = "";
            string qty = "";
            string unit = "";
            foreach (DataColumn column in obj._TableSource.Columns)
            {
                string colName = column.ColumnName;
                switch (colName)
                {
                    case "No":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "No", Commons.Modules.TypeLanguage);
                        break;
                    
                    
                    case "MS_PT":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "MaterialCode", Commons.Modules.TypeLanguage);
                        break;
                    case "TEN_PT":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "MaterialName", Commons.Modules.TypeLanguage);
                        break;
                    case "QUY_CACH":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "SPEC", Commons.Modules.TypeLanguage);
                        break;
                    case "SO_LUONG":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "Qty", Commons.Modules.TypeLanguage);
                        qty = column.ColumnName;
                        break;
                    
                    case "DON_GIA":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "UPrice", Commons.Modules.TypeLanguage);
                        unit = column.ColumnName;
                        break;
                    case "THANH_TIEN":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "Amount", Commons.Modules.TypeLanguage);
                        amount = column.ColumnName;
                        break;
                    case "TEN_DX":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "IssuedType", Commons.Modules.TypeLanguage);
                        groupColumn = column.ColumnName;
                        break;
                   
                       
                }
            }
            obj.ecomaintGrid1.DataSource = obj._TableSource;
            obj.ecomaintGrid1.ExpressionGroupBy(obj.gridView1, groupColumn);
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, amount);
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, unit);
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, qty);
            obj.ShowDialog();
            //madx = "<ROOT>"; tendx = "";
            //mavt = "<ROOT>";
            //try
            //{
            //    tungay = dtTungay.Value;
            //    denngay = dtDenngay.Value;
            //    int i = 0;
            //    while (i < gvDangxuat.Rows.Count)
            //    {
            //        try
            //        {
            //            if ((bool)gvDangxuat.Rows[i].Cells["CHON"].Value)
            //            {
            //                if (madx == "<ROOT>")
            //                    madx += "<DX ID=\"" + gvDangxuat.Rows[i].Cells["MS_DANG_XUAT"].Value.ToString() + "\"/>";
            //                else
            //                    madx += "<DX ID=\"" + gvDangxuat.Rows[i].Cells["MS_DANG_XUAT"].Value.ToString() + "\"/>";

            //                if (tendx == "")
            //                    tendx = gvDangxuat.Rows[i].Cells["DANG_XUAT"].Value.ToString();
            //                else
            //                    tendx += ", " + gvDangxuat.Rows[i].Cells["DANG_XUAT"].Value.ToString();
            //            }
            //        }
            //        catch
            //        { }
            //        i++;
            //    }
            //    madx += "</ROOT>";
            //    i = 0;
            //    while (i < gvVTPT.Rows.Count)
            //    {
            //        try
            //        {
            //            if ((bool)gvVTPT.Rows[i].Cells["CHONPT"].Value)
            //            {
            //                if (mavt == "<ROOT>")
            //                    mavt += "<PHUTUNG id=\"" + gvVTPT.Rows[i].Cells["MS_PT"].Value.ToString() + "\"/>";
            //                else
            //                    mavt += "<PHUTUNG id=\"" + gvVTPT.Rows[i].Cells["MS_PT"].Value.ToString() + "\"/>";
            //            }
            //        }
            //        catch
            //        { }
            //        i++;
            //    }
            //    mavt += "</ROOT>";

               // XuatExcel();
            //}
            //catch { }
        }

        private void LoadKho()
        {
            try
            {
                System.Data.DataTable dtTable = new System.Data.DataTable();
                Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

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
            row["LoaiID"] = 0;
            row["LoaiVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "SparePart", Commons.Modules.TypeLanguage);
            dt.Rows.Add(row);

            DataRow row1 = dt.NewRow();
            row1["LoaiID"] = 1;
            row1["LoaiVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "Consumtion", Commons.Modules.TypeLanguage);
            dt.Rows.Add(row1);

            cbLoaiVT.DataSource = dt;
            cbLoaiVT.ValueMember = "LoaiID";
            cbLoaiVT.DisplayMember = "LoaiVT";


        }

        private void LoadDangXuat()
        {
            try
            {
                System.Data.DataTable dtTable = new System.Data.DataTable();
                Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetDANG_XUATALL", Commons.Modules.TypeLanguage));
                gvDangxuat.DataSource = dtTable;
                gvDangxuat.Columns["CHON"].ReadOnly = false;
                gvDangxuat.Columns["MS_DANG_XUAT"].Visible = false;
                gvDangxuat.Columns["DANG_XUAT"].Visible = true;
                gvDangxuat.Columns["MS_DANG_XUAT"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "MS_DANG_XUAT", Commons.Modules.TypeLanguage);
                gvDangxuat.Columns["DANG_XUAT"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "DANG_XUAT", Commons.Modules.TypeLanguage);
                gvDangxuat.Columns["CHON"].HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "CHON", Commons.Modules.TypeLanguage);
            }
            catch { }
        }

        private void cbLoaiVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvDangxuat.Rows.Count)
            {
                try
                {
                    gvDangxuat.Rows[i].Cells["CHON"].Value = false;

                }
                catch
                { }
                i++;
            }
            dtTable = new System.Data.DataTable();
            gvVTPT.DataSource = dtTable;
        }

        private void btnChonhetQG_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvDangxuat.Rows.Count)
            {
                try
                {
                    gvDangxuat.Rows[i].Cells["CHON"].Value = true;

                }
                catch
                { }
                i++;
            }
            LoadVattu();
        }

        private void btnBochonQG_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvDangxuat.Rows.Count)
            {
                try
                {
                    gvDangxuat.Rows[i].Cells["CHON"].Value = false;

                }
                catch
                { }
                i++;
            }
            dtTable = new System.Data.DataTable();
            gvVTPT.DataSource = dtTable;
        }

        private void btnChonhetVT_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvVTPT.Rows.Count)
            {
                try
                {
                    gvVTPT.Rows[i].Cells["CHONPT"].Value = true;

                }
                catch
                { }
                i++;
            }
        }

        private void btnBochonVT_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvVTPT.Rows.Count)
            {
                try
                {
                    gvVTPT.Rows[i].Cells["CHONPT"].Value = false;

                }
                catch
                { }
                i++;
            }
        }

        private void XuatExcel()
        {
            //try
            //{
            //    if (tungay <= denngay)
            //    {
            //        grandtotal = "=";
            //        if (denngay.Month > tungay.Month && tungay.Year == denngay.Year)
            //            col = denngay.Month - tungay.Month + 1;
            //        else if (tungay.Year < denngay.Year)
            //            col = 12 + denngay.Month - tungay.Month + 1;
            //        else
            //            col = 1;
            //    }
            //    else
            //    {
            //        Vietsoft.Information.MsgBox(this.ParentForm, "tungaynhohondenngay", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //        return;
            //    }
            //    if (madx.Trim() != "" && mavt != "" && cbKho.Text != "")
            //    {
            //        #region Title Excel

            //        Excel.Application ExcelApp;
            //        Excel.Workbook objBook;
            //        Excel.Worksheet objSheet;

            //        ExcelApp = new Excel.ApplicationClass();
            //        ExcelApp.Visible = false;
            //        this.Cursor = Cursors.WaitCursor;
            //        objBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //        objSheet = (Excel.Worksheet)objBook.Sheets["Sheet1"];
            //        objSheet.Name = "MONTHLY MATERIAL OUTPUT LIST";

            //        objSheet.Cells[1, 1] = "Details";

            //        System.Data.DataTable dtThongtin = new System.Data.DataTable();
            //        Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

            //        dtThongtin.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetTHONG_TIN_CHUNG"));

            //        Excel.Range namecompany = objSheet.get_Range("A1", "F1");
            //        namecompany.Font.Bold = true;
            //        namecompany.MergeCells = true;
            //        namecompany.Font.Bold = true;
            //        namecompany.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //        namecompany.Value2 = dtThongtin.Rows[0]["TEN_CTY_TIENG_ANH"].ToString();

            //        Excel.Range dccty = objSheet.get_Range("A2", "C2");
            //        dccty.Font.Bold = true;
            //        dccty.MergeCells = true;
            //        dccty.Font.Bold = true;
            //        dccty.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //        dccty.Value2 = dtThongtin.Rows[0]["DIA_CHI_ANH"].ToString();

            //        Excel.Range tel = objSheet.get_Range("A3", "B3");
            //        tel.Font.Bold = true;
            //        tel.MergeCells = true;
            //        tel.Font.Bold = true;
            //        tel.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //        tel.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "Tel", Commons.Modules.TypeLanguage) + " " + dtThongtin.Rows[0]["Phone"].ToString();

            //        Excel.Range fax = objSheet.get_Range("C3", "D3");
            //        fax.Font.Bold = true;
            //        fax.MergeCells = true;
            //        fax.Font.Bold = true;
            //        fax.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //        fax.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "Fax", Commons.Modules.TypeLanguage) + " " + dtThongtin.Rows[0]["Fax"].ToString();


            //        Excel.Range TieuDe = objSheet.get_Range("A4", "G4");
            //        TieuDe.Merge(true);
            //        TieuDe.MergeCells = true;
            //        TieuDe.Font.Bold = true;
            //        TieuDe.Font.Size = 18;
            //        TieuDe.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "rptMONTHLY_MATERIAL_OUTPUT_LIST", Commons.Modules.TypeLanguage);
            //        TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            //        Excel.Range ngay = objSheet.get_Range("A5", "G5");
            //        ngay.Font.Bold = true;
            //        ngay.Merge(true);
            //        ngay.MergeCells = true;
            //        ngay.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //        ngay.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "tungay", Commons.Modules.TypeLanguage) + " " + tungay.ToShortDateString() + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "denngay", Commons.Modules.TypeLanguage) + " " + denngay.ToShortDateString();

            //        Excel.Range warehouse = objSheet.get_Range("A6", "G6");
            //        warehouse.Font.Bold = true;
            //        warehouse.Merge(true);
            //        warehouse.MergeCells = true;
            //        warehouse.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //        warehouse.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "Warehouse", Commons.Modules.TypeLanguage) + " " + cbKho.Text;


            //        Excel.Range country = objSheet.get_Range("A7", "G7");
            //        country.Font.Bold = true;
            //        country.Merge(true);
            //        country.MergeCells = true;
            //        country.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //        country.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "MaterialType", Commons.Modules.TypeLanguage) + " " + cbLoaiVT.Text;

            //        Excel.Range currency = objSheet.get_Range("A8", "G8");
            //        currency.Font.Bold = true;
            //        currency.Merge(true);
            //        currency.MergeCells = true;
            //        currency.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //        currency.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "Currency", Commons.Modules.TypeLanguage) + " " + (string)((rdUSD.Checked) ? "USD" : "VND");

            //        Excel.Range mate_type = objSheet.get_Range("A9", "G9");
            //        mate_type.Font.Bold = true;
            //        mate_type.Merge(true);
            //        mate_type.MergeCells = true;
            //        mate_type.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //        mate_type.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "IssuedType", Commons.Modules.TypeLanguage) + " " + tendx;


            //        #endregion
            //        int row = 11;
            //        try
            //        {
            //            System.Data.DataTable dtTable = new System.Data.DataTable();

            //            HeaderTable(objSheet, row);
            //            int kho = (int)cbKho.SelectedValue;


            //            dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetrptMONTHLY_MATERIAL_OUTPUT_LIST", kho, tungay, denngay, cbLoaiVT.SelectedValue, mavt, madx, Commons.Modules.TypeLanguage, (rdVND.Checked) ? "1" : "0"));
            //            if (dtTable.Rows.Count > 0)
            //            {
            //                row = row + 1;
            //                PrintData(objSheet, row, dtTable);

            //            }
            //            ExcelApp.Visible = true;
            //        }
            //        catch { }
            //    }
            //    else
            //    {
            //        Vietsoft.Information.MsgBox(this.ParentForm, "MsgKocodulieu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            //    }

            //    this.Cursor = Cursors.Default;

            //}
            //catch { }
        }

        private void PrintData(Microsoft.Office.Interop.Excel.Worksheet objSheet, int row, System.Data.DataTable dtDetail)
        {
            //try
            //{
            //    int top = row;

            //    for (int i = 0; i < dtDetail.Rows.Count; i++)
            //    {
            //        Range No = objSheet.get_Range("A" + row, "A" + row);
            //        No.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //        No.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //        No.Value2 = i + 1;

            //        Range macode = objSheet.get_Range("B" + row, "B" + row);
            //        macode.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //        macode.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //        macode.Value2 = dtDetail.Rows[i]["MS_PT"].ToString();

            //        Range maname = objSheet.get_Range("C" + row, "C" + row);
            //        maname.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //        maname.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //        maname.Value2 = dtDetail.Rows[i]["TEN_PT"].ToString();
            //        maname.WrapText = true;

            //        Range spec = objSheet.get_Range("D" + row, "D" + row);
            //        spec.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //        spec.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //        spec.Value2 = dtDetail.Rows[i]["QUY_CACH"].ToString();
            //        spec.WrapText = true;

            //        Range qty = objSheet.get_Range("E" + row, "E" + row);
            //        qty.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //        qty.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //        qty.Value2 = dtDetail.Rows[i]["SO_LUONG"].ToString();

            //        Range price = objSheet.get_Range("F" + row, "F" + row);
            //        price.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //        price.HorizontalAlignment = XlHAlign.xlHAlignRight;
            //        price.Value2 = dtDetail.Rows[i]["DON_GIA"].ToString();
            //        price.NumberFormat = "#,##0.00";

            //        Range amount = objSheet.get_Range("G" + row, "G" + row);
            //        amount.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //        amount.HorizontalAlignment = XlHAlign.xlHAlignRight;
            //        amount.Value2 = "=E" + row + "*" + "F" + row;
            //        amount.NumberFormat = "#,##0.00";
            //        row++;
            //    }

            //    Excel.Range lblGrand = objSheet.get_Range("A" + row, "F" + row);
            //    lblGrand.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //    lblGrand.Font.Bold = true;
            //    lblGrand.Merge(true);
            //    lblGrand.MergeCells = true;
            //    lblGrand.HorizontalAlignment = XlHAlign.xlHAlignRight;
            //    lblGrand.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "GRAND TOTAL", Commons.Modules.TypeLanguage);

            //    Range Grand = objSheet.get_Range("G" + row, "G" + row);
            //    Grand.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //    Grand.HorizontalAlignment = XlHAlign.xlHAlignRight;
            //    Grand.Value2 = "=SUM(G" + top + ":" + "G" + (row - 1) + ")";
            //    Grand.NumberFormat = "#,##0.00";
            //}
            //catch { }
        }

        private void HeaderTable(Microsoft.Office.Interop.Excel.Worksheet objSheet, int row)
        {
            //header table
            //Excel.Range No = objSheet.get_Range("A" + row, "A" + row);
            //No.Font.Bold = true;
            //No.ColumnWidth = 10;
            //No.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //No.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //No.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "No", Commons.Modules.TypeLanguage);

            //Range materialcode = objSheet.get_Range("B" + row, "B" + row);
            //materialcode.Font.Bold = true;
            //materialcode.ColumnWidth = 15;
            //materialcode.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //materialcode.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //materialcode.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "MaterialCode", Commons.Modules.TypeLanguage);

            //Range materialname = objSheet.get_Range("C" + row, "C" + row);
            //materialname.ColumnWidth = 35;
            //materialname.Font.Bold = true;
            //materialname.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //materialname.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //materialname.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "MaterialName", Commons.Modules.TypeLanguage);

            //Range spec = objSheet.get_Range("D" + row, "D" + row);
            //spec.ColumnWidth = 15;
            //spec.Font.Bold = true;
            //spec.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //spec.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //spec.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "SPEC", Commons.Modules.TypeLanguage);

            //Range qty = objSheet.get_Range("E" + row, "E" + row);
            //qty.ColumnWidth = 15;
            //qty.Font.Bold = true;
            //qty.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //qty.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //qty.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "Qty", Commons.Modules.TypeLanguage);

            //Range price = objSheet.get_Range("F" + row, "F" + row);
            //price.ColumnWidth = 15;
            //price.Font.Bold = true;
            //price.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //price.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //price.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "UPrice", Commons.Modules.TypeLanguage);

            //Range amount = objSheet.get_Range("G" + row, "G" + row);
            //amount.ColumnWidth = 20;
            //amount.Font.Bold = true;
            //amount.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //amount.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //amount.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_MATERIAL_OUTPUT_LIST", "Amount", Commons.Modules.TypeLanguage);

        }

        private void LoadVattu()
        {
            try
            {
                //string madx = "";
                //int i = 0;
                //while (i < gvDangxuat.Rows.Count)
                //{
                //    try
                //    {
                //        if ((bool)gvDangxuat.Rows[i].Cells["CHON"].Value)
                //        {
                //            if (madx == "")
                //                madx = gvDangxuat.Rows[i].Cells["MS_DANG_XUAT"].Value.ToString();
                //            else
                //                madx += "," + gvDangxuat.Rows[i].Cells["MS_DANG_XUAT"].Value.ToString();

                //        }
                //    }
                //    catch
                //    { }
                //    i++;
                //}
                //if (madx == "") madx = "-1";
                //load grid vattu
                dtTable = new System.Data.DataTable();
                Vietsoft.SqlInfo SqlPhieu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

                dtTable.Load(SqlPhieu.ExecuteReader(CommandType.StoredProcedure, "GetchonVTPTbyLoaiVT", cbLoaiVT.SelectedValue, (int)cbKho.SelectedValue, dtTungay.Value, dtDenngay.Value));
                gvVTPT.DataSource = dtTable;
                gvVTPT.Columns["CHONPT"].ReadOnly = false;
                gvVTPT.Columns["MS_PT_NCC"].ReadOnly = true;
                gvVTPT.Columns["MS_PT"].Visible = true;
                gvVTPT.Columns["TEN_PT"].Visible = true;
                gvVTPT.Columns["QUY_CACH"].Visible = true;

            }
            catch { }
        }

        private void gvDangxuat_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            //        LoadVattu();
            //}
            //catch { }
        }

        private void gvDangxuat_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            //        LoadVattu();
            //}
            //catch { }
        }

        private void cbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvDangxuat.Rows.Count)
            {
                try
                {
                    gvDangxuat.Rows[i].Cells["CHON"].Value = false;

                }
                catch
                { }
                i++;
            }
            dtTable = new System.Data.DataTable();
            gvVTPT.DataSource = dtTable;
        }

        private void gvDangxuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                LoadVattu();
                System.Data.DataTable _table = new System.Data.DataTable();
                System.Data.DataTable _table_merge = new System.Data.DataTable();
                foreach (DataGridViewRow row in gvDangxuat.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].EditedFormattedValue) == true)
                    {
                        string _madx = row.Cells["MS_DANG_XUAT"].Value.ToString() ;

                        dtTable.DefaultView.RowFilter = "MS_DANG_XUAT='" + _madx + "'";
                        _table = dtTable.DefaultView.ToTable();
                        _table_merge.Merge(_table);
                    }
                }


                gvVTPT.DataSource = _table_merge;
            }
        }

        private void dtTungay_ValueChanged(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvDangxuat.Rows.Count)
            {
                try
                {
                    gvDangxuat.Rows[i].Cells["CHON"].Value = false;

                }
                catch
                { }
                i++;
            }
            dtTable = new System.Data.DataTable();
            gvVTPT.DataSource = dtTable;
        }

        private void dtDenngay_ValueChanged(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvDangxuat.Rows.Count)
            {
                try
                {
                    gvDangxuat.Rows[i].Cells["CHON"].Value = false;

                }
                catch
                { }
                i++;
            }
            dtTable = new System.Data.DataTable();
            gvVTPT.DataSource = dtTable;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
