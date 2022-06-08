using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using DevExpress.XtraEditors;
using OfficeOpenXml.Drawing.Chart;
namespace MVControl
{
    public partial class ucBCTGNM : UserControl
    {
        String sBC = "ucBCTGNM";
        string btTongNN = "TONGNN" + Commons.Modules.UserName;
        string btDSNN = "TGNM" + Commons.Modules.UserName;
        string btDowntime = "Downtime" + Commons.Modules.UserName;
        string btSummary = "Summary" + Commons.Modules.UserName;
        string btSummaryinHour = "SummaryinHour" + Commons.Modules.UserName;
        private delegate void CallProcessBar(object dt);
        string sPath = "";
        public ucBCTGNM()
        {
            InitializeComponent();
        }

        #region load lưới
        private void ucBCThoiGianCVNhanVien_Load(object sender, EventArgs e)
        {
            LoadTTNMay();
            LoadHeThong();
            optInTheoThangNam_SelectedIndexChanged(null, null);
        }
        private void optInTheoThangNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optInTheoThangNam.SelectedIndex == 2) //Tháng
            {
                lblTNam.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "lblNgay", Commons.Modules.TypeLanguage);
                datTNgay.Properties.DisplayFormat.FormatString = "MM/yyyy";
                datTNgay.Properties.EditMask = "MM/yyyy";
                datTNgay.Properties.EditFormat.FormatString = "MM/yyyy";
                datTNgay.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
                datTNgay.MMonthYear = true;
            }
            else
            {
                lblTNam.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "lblNam", Commons.Modules.TypeLanguage);
                datTNgay.Properties.DisplayFormat.FormatString = "yyyy";
                datTNgay.Properties.EditMask = "yyyy";
                datTNgay.Properties.EditFormat.FormatString = "yyyy";
                datTNgay.DateTime = DateTime.Now;
                datTNgay.MMonthYear = false;
            }
        }
        private void LoadHeThong()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetListHeThong", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                newColumn.DefaultValue = true;
                dtTmp.Columns.Add(newColumn);
                newColumn.SetOrdinal(0);
                dtTmp.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdHeThong, grvHeThong, dtTmp, true, false, true, false);
                dtTmp.Columns["TEN_HE_THONG"].ReadOnly = true;
                dtTmp.Columns["GHI_CHU"].ReadOnly = true;
                grvHeThong.Columns["MS_HE_THONG"].Visible = false;
                grvHeThong.Columns["CHON"].Width = 100;
                grvHeThong.Columns["GHI_CHU"].Width = 200;
                grvHeThong.Columns["TEN_HE_THONG"].Width = 200;
                grvHeThong.Columns["NHOM_IN"].Width = 100;
                grvHeThong.Columns["NHOM_LINE"].Width = 100;
            }
            catch (Exception ex)
            {

            }
        }
        private void LoadTTNMay()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT CONVERT(BIT,1) AS CHON ,MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN, HU_HONG, BTDK, CONVERT(NVARCHAR,MS_NGUYEN_NHAN) AS MS_NN " +
                " FROM dbo.NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN"));
            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNNNgungMay, grvNNNgungMay, dtTmp, true, false, true, false);

            dtTmp.Columns["MS_NGUYEN_NHAN"].ReadOnly = true;
            dtTmp.Columns["TEN_NGUYEN_NHAN"].ReadOnly = true;
            dtTmp.Columns["HU_HONG"].ReadOnly = true;
            dtTmp.Columns["BTDK"].ReadOnly = true;
            grvNNNgungMay.Columns["MS_NN"].Visible = false;
            grvNNNgungMay.Columns["MS_NGUYEN_NHAN"].Visible = false;

            grvNNNgungMay.Columns["CHON"].Width = 100;
            grvNNNgungMay.Columns["HU_HONG"].Width = 100;
            grvNNNgungMay.Columns["BTDK"].Width = 100;
            grvNNNgungMay.Columns["TEN_NGUYEN_NHAN"].Width = 400;
            //LoadMay();
        }
        #endregion

        #region sự kiện button
        private void btnAllHeThong_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvHeThong);
        }
        private void btnNoAllHeThong_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvHeThong);
        }

        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
            }
        }
        private void btnALLNNNM_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvNNNgungMay);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            (ParentForm).Close();
        }
        private void btnNotALLNNNM_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvNNNgungMay);
        }
        #endregion

        #region tạo dữ liệu in báo cáo
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                if (sPath == "") return;
                Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
                t.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void ShowProcessBar(object dt)
        {
            if (prbIN.InvokeRequired)
            {
                prbIN.Invoke(new CallProcessBar(ShowProcessBar), dt);
            }
            else
            {
                BeginInvoke((Action)(() =>
                {
                    prbIN.Properties.Stopped = false;
                    btnExecute.Enabled = false;
                    btnThoat.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                }));
                Thread t = new Thread(new ParameterizedThreadStart(InExcel));
                t.Start(dt);
            }
        }

        private void InExcel(object dt)
        {
            try
            {
                DataTable tempt = (DataTable)grdHeThong.DataSource;
                DataTable tableHT = tempt.AsEnumerable().Where(x => x.Field<bool>("CHON") == true).CopyToDataTable();
                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }
                ExcelPackage pck = new ExcelPackage();
                DateTime dTNgay, dDNgay, Ngay;
                Ngay = Convert.ToDateTime("01/" + datTNgay.DateTime.Month + "/" + datTNgay.DateTime.Year);
                dTNgay = Ngay;
                dDNgay = Ngay.AddMonths(1).AddDays(-1);
                //tạo bảng tạm ds nguyên nhân xuống csdl
                createTableTGNN();
                if (optInTheoThangNam.SelectedIndex == 0)
                {
                    //load sheet summary
                    LoadSheetSumMary(pck, dTNgay, tableHT);
                }
                else
                    if (optInTheoThangNam.SelectedIndex == 1)
                {
                    //Load sheet sumary in hour
                    LoadSheetSumMaryInHourt(pck, dTNgay, tableHT);
                }
                else
                {
                    //Load sheet theo tháng
                    LoadWordShert(pck, dTNgay, dDNgay, Ngay.ToString("MMM") + " in " + Ngay.ToString("yy"), tableHT);
                }
                //int i = 1;
                //while (Ngay.Date <= datDNgay.DateTime.Date)
                //{
                //LoadWordShert(pck, dTNgay, dDNgay, Ngay.ToString("MMM") + " in " + Ngay.ToString("yy"), tableHT);
                //Ngay = Ngay.AddMonths(1);
                //dTNgay = Ngay;
                //dDNgay = Ngay.AddMonths(1).AddDays(-1);
                //i++;
                //}
                pck.SaveAs(fi);
                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);
                System.Diagnostics.Process.Start(fi.FullName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "XuatExcelKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                BeginInvoke((Action)(() =>
                {
                    this.Cursor = Cursors.Default;
                    btnExecute.Enabled = true;
                    btnThoat.Enabled = true;
                    prbIN.Properties.Stopped = true;
                }));
                sPath = "";
            }
            catch { }
        }
        private void RenameColumsMonth(DataTable dt)
        {
            try
            {
                dt.Columns["-1"].ColumnName = "Dec";
            }
            catch (Exception)
            {
            }
            dt.Columns["1"].ColumnName = "Jan";
            dt.Columns["2"].ColumnName = "Feb";
            dt.Columns["3"].ColumnName = "Mar";
            dt.Columns["4"].ColumnName = "Apr";
            dt.Columns["5"].ColumnName = "May";
            dt.Columns["6"].ColumnName = "Jun";
            dt.Columns["7"].ColumnName = "Jul";
            dt.Columns["8"].ColumnName = "Aug";
            dt.Columns["9"].ColumnName = "Sep";
            dt.Columns["10"].ColumnName = "Oct";
            dt.Columns["11"].ColumnName = "Nov";
            dt.Columns["12"].ColumnName = "Dec ";
        }
        //create sheet summari
        private void LoadSheetSumMary(ExcelPackage pck, DateTime dTNgay, DataTable tableHT)
        {
            DataTable tableTongHT = new DataTable();
            var ws1 = pck.Workbook.Worksheets.Add("Summary");
            ws1.Cells.Style.Font.Name = "Trebuchet MS";
            ws1.Cells.Style.Font.Size = 11;
            int iDong = 1;
            List<List<Object>> WidthColumns = new List<List<Object>>();
            List<Object> WidthColumnsName = new List<Object>();
            iDong++;
            int icount = 0, iAllRow = 0;
            WidthColumnsName = new List<Object>()
                    {" ",60};
            WidthColumns.Add(WidthColumnsName);
            foreach (DataRow item in tableHT.Rows)
            {
                DataTable tempt = new DataTable();
                tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetBCTGNMTong", dTNgay, item["MS_HE_THONG"], 1, btDSNN));
                DataTable tempt1 = tempt.AsEnumerable().Where(x => x["STT"].ToString() == "9998").CopyToDataTable();
                tempt1.AsEnumerable().Select(x => x["STT"] = Convert.ToInt32(item["NHOM_IN"].ToString())).ToList();
                tempt1.Rows[0]["TEN_NGUYEN_NHAN"] = item["TEN_HE_THONG"].ToString();
                tableTongHT.Merge(tempt1);
                tempt.Columns.Remove("STT");
                tempt.Columns["TEN_NGUYEN_NHAN"].ColumnName = item["TEN_HE_THONG"].ToString();
                RenameColumsMonth(tempt);
                ws1.Cells[iDong, 1].LoadFromDataTable(tempt, true);
                Commons.Modules.MExcel.MFormatExcel(ws1, tempt, iDong, sBC, false, false, false);
                //load biểu đồ
                loadbieudoSummary(ws1, iDong, tempt, tableHT);
                iDong += tempt.Rows.Count < 18 ? 19 : tempt.Rows.Count + 2;
                //iDong += tempt.Rows.Count + 2;
            }
            var dtNhomIn = tableHT.AsEnumerable().Select(row => new
            {
                NHOM_IN = row.Field<int>("NHOM_IN")
            })
            .Distinct().OrderBy(x=>x.NHOM_IN).ToList();
            if (dtNhomIn.Count == 0) return;
            createTabeSummary(tableTongHT);
            foreach (var row in dtNhomIn)
            {
                string sSql;
                //chưa theo dây chuyền
                //sSql = "SELECT TOP 1 GIO_KH FROM  dbo.KHSX_NGAY WHERE ISNULL(LOAI,0) = 1 AND NGAY BETWEEN CONVERT(DATE,'01/01/" + dTNgay.Year.ToString() + "') AND CONVERT(DATE,'12/31/" + dTNgay.Year.ToString() + "') AND MS_HE_THONG IN(SELECT MS_HE_THONG FROM dbo.HE_THONG WHERE NHOM_IN = " + row.NHOM_IN + ")";
                sSql = "SELECT TOP 1 GIO_KH FROM  dbo.KHSX_NGAY WHERE ISNULL(LOAI,0) = 1 AND NGAY BETWEEN CONVERT(DATE,'01/01/" + dTNgay.Year.ToString() + "') AND CONVERT(DATE,'12/31/" + dTNgay.Year.ToString() + "') AND MS_N_XUONG = " + row.NHOM_IN + "";

                double target = Convert.ToDouble((SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
                sSql = "SELECT * FROM " + btSummary + " WHERE STT = " + row.NHOM_IN + " UNION SELECT 9999,'Target'," + target + "," + target + "," + target + "," + target + "," + target + "," + target + "," + target + "," + target + "," + target + "," + target + "," + target + "," + target + "," + target + "";
                DataTable dttempt = new DataTable();
                dttempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dttempt.Columns.Remove("STT");
                dttempt.Columns["TEN_NGUYEN_NHAN"].ColumnName = " ";
                RenameColumsMonth(dttempt);
                dttempt.Columns.Remove("Dec");
                ws1.Cells[iDong, 1].LoadFromDataTable(dttempt, true);
                Commons.Modules.MExcel.MFormatExcel(ws1, dttempt, iDong, sBC, WidthColumns, false, false, false);
                var modeltbTongNN = ws1.Cells[iDong, 1, iDong + dttempt.Rows.Count, dttempt.Columns.Count];
                // Assign borders
                modeltbTongNN.Style.Border.Top.Style = ExcelBorderStyle.Hair;
                modeltbTongNN.Style.Border.Left.Style = ExcelBorderStyle.Hair;
                modeltbTongNN.Style.Border.Right.Style = ExcelBorderStyle.Hair;
                modeltbTongNN.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                loadbieudoSummaryNhomTheoHT(ws1, iDong, dttempt);
                iDong += 20;
            }
            ExcelRange allCells = ws1.Cells[2, 2, iDong, 14];
            //allCells.AutoFitColumns();
            allCells.Style.Numberformat.Format = "0.0%";
        }
        //create sheet summari
        private void LoadSheetSumMaryInHourt(ExcelPackage pck, DateTime dTNgay, DataTable tableHT)
        {
           
            DataTable tableTongHT = new DataTable();
            var ws1 = pck.Workbook.Worksheets.Add("Summary in Hrs");
            ws1.Cells.Style.Font.Name = "Trebuchet MS";
            ws1.Cells.Style.Font.Size = 11;
            int iDong = 1;
            for (int i = 2; i <= 14; i++)
            {
                ws1.Column(i).Style.Numberformat.Format = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
            }
            List<List<Object>> WidthColumns = new List<List<Object>>();
            List<Object> WidthColumnsName = new List<Object>();
            iDong++;
            int icount = 0, iAllRow = 0;
            WidthColumnsName = new List<Object>()
                    {" ",60};
            WidthColumns.Add(WidthColumnsName);
            DataTable tempt5 = new DataTable();
            string sSListHeThong ="";
            foreach (DataRow item in tableHT.Rows)
            {
                sSListHeThong += item["MS_HE_THONG"].ToString()+",";
                DataSet DataSet = new DataSet();
                DataSet = getdatasetInhour(Convert.ToInt32(item["MS_HE_THONG"]), dTNgay);
                DataTable tempt = new DataTable();
                tempt = DataSet.Tables[0];
                DataTable tempt8 = new DataTable();

                tempt5.Merge(DataSet.Tables[1]);
                DataTable tempt1 = new DataTable();
                tempt.Columns["STT"].ReadOnly = false;
                tempt.Rows[tempt.Rows.Count - 1]["STT"] = item["NHOM_LINE"];
                tableTongHT.Merge(tempt);
                tempt.Columns.Remove("STT");
                tempt.Columns["TEN_NGUYEN_NHAN"].ColumnName = item["TEN_HE_THONG"].ToString();
                RenameColumsMonth(tempt);
                //tempt.Columns.Remove("Dec");
                tempt.Columns["13"].ColumnName = "total";
                ws1.Cells[iDong, 1].LoadFromDataTable(tempt, true);
                Commons.Modules.MExcel.MFormatExcel(ws1, tempt, iDong, sBC, false, false, false);
                //load biểu đồ
                loadbieudoSummaryInHour(ws1, iDong, tempt, tableHT, item["TEN_HE_THONG"].ToString());
                iDong += tempt.Rows.Count < 18 ? 19 : tempt.Rows.Count + 2;
            }
            createTabeSummaryInHour(tableTongHT);
            string sResulst = sSListHeThong.Remove(sSListHeThong.Length -1);
            //load sum total chưa theo dây chuyền
            //string sSql = "SELECT 'Downtime' as [TEN_NGUYEN_NHAN],ROUND(SUM([1]),2) AS [1],ROUND(SUM([2]),2)AS [2],ROUND(SUM([3]),2)AS [3],ROUND(SUM([4]),2)AS [4],ROUND(SUM([5]),2)AS [5],ROUND(SUM([6]),2)AS [6],ROUND(SUM([7]),2)AS [7],ROUND(SUM([8]),2)AS [8],ROUND(SUM([9]),2)AS [9],ROUND(SUM([10]),2)AS [10],ROUND(SUM([11]),2)AS [11],ROUND(SUM([12]),2)AS [12] FROM " + btSummaryinHour + " WHERE TEN_NGUYEN_NHAN = 'total' GROUP BY TEN_NGUYEN_NHAN UNION SELECT 'FG Output', pvt.* FROM(SELECT MONTH(NGAY) AS THANG, GIO_KH FROM dbo.KHSX_NGAY WHERE LOAI = 2 AND NGAY BETWEEN CONVERT(DATE, '01/01/" + dTNgay.Year + "') AND CONVERT(DATE, '12/31/" + dTNgay.Year + "')) A PIVOT(SUM(A.GIO_KH) FOR A.THANG IN([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) AS pvt";
            string sSql = "SELECT 'Downtime' as [TEN_NGUYEN_NHAN],ROUND(SUM([1]),2) AS [1],ROUND(SUM([2]),2)AS [2],ROUND(SUM([3]),2)AS [3],ROUND(SUM([4]),2)AS [4],ROUND(SUM([5]),2)AS [5],ROUND(SUM([6]),2)AS [6],ROUND(SUM([7]),2)AS [7],ROUND(SUM([8]),2)AS [8],ROUND(SUM([9]),2)AS [9],ROUND(SUM([10]),2)AS [10],ROUND(SUM([11]),2)AS [11],ROUND(SUM([12]),2)AS [12] FROM " + btSummaryinHour + " WHERE TEN_NGUYEN_NHAN = 'total' GROUP BY TEN_NGUYEN_NHAN UNION SELECT 'FG Output', pvt.* FROM(SELECT MONTH(T2.NGAY) AS THANG, T2.GIO_KH  FROM dbo.HE_THONG T1 LEFT JOIN (SELECT * FROM  dbo.KHSX_NGAY  WHERE LOAI = 2 AND NGAY BETWEEN CONVERT(DATE,'01/01/" + dTNgay.Year + "') AND CONVERT(DATE,'12/31/" + dTNgay.Year + "'))T2 ON T2.MS_HE_THONG = T1.MS_HE_THONG AND T2.MS_HE_THONG IN("+sResulst+")) A PIVOT(SUM(A.GIO_KH) FOR A.THANG IN([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) AS pvt";
            DataTable dtsumtotal = new DataTable();
            dtsumtotal.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtsumtotal.Rows.Add("Output", null, null, null, null, null, null, null, null, null, null, null, null);
            dtsumtotal.Columns["TEN_NGUYEN_NHAN"].ColumnName = " ";
            int iDong1 = iDong;
            RenameColumsMonth(dtsumtotal);


            ws1.Cells[iDong, 1].LoadFromDataTable(dtsumtotal, true);
            Commons.Modules.MExcel.MFormatExcel(ws1, dtsumtotal, iDong, sBC, WidthColumns, false, false, false);
            var modeltbTongDC = ws1.Cells[iDong, 1, iDong + dtsumtotal.Rows.Count, dtsumtotal.Columns.Count];
            // Assign borders
            modeltbTongDC.Style.Border.Top.Style = ExcelBorderStyle.Dashed;
            modeltbTongDC.Style.Border.Left.Style = ExcelBorderStyle.Dashed;
            modeltbTongDC.Style.Border.Right.Style = ExcelBorderStyle.Dashed;
            modeltbTongDC.Style.Border.Bottom.Style = ExcelBorderStyle.Dashed;

            iDong += dtsumtotal.Rows.Count + 2;
            sSql = "SELECT TEN_NGUYEN_NHAN,ROUND(SUM([1]),2) AS [1],ROUND(SUM([2]),2)AS [2],ROUND(SUM([3]),2)AS [3],ROUND(SUM([4]),2)AS [4],ROUND(SUM([5]),2)AS [5],ROUND(SUM([6]),2)AS [6],ROUND(SUM([7]),2)AS [7],ROUND(SUM([8]),2)AS [8],ROUND(SUM([9]),2)AS [9],ROUND(SUM([10]),2)AS [10],ROUND(SUM([11]),2)AS [11],ROUND(SUM([12]),2)AS [12],ROUND(SUM([13]),2)AS [Total]  FROM " + btSummaryinHour + " WHERE TEN_NGUYEN_NHAN != 'total' GROUP BY TEN_NGUYEN_NHAN";
            DataTable dtsumnottotal = new DataTable();
            dtsumnottotal.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            DataTable tempt4 = new DataTable();
            tempt4 = dtsumnottotal.Copy();
            dtsumnottotal.Columns["TEN_NGUYEN_NHAN"].ColumnName = " ";
            RenameColumsMonth(dtsumnottotal);
            VeTable(ws1, dtsumnottotal, iDong);
            iDong += dtsumnottotal.Rows.Count + 2;
            DataTable tempt2 = new DataTable();
            tempt2.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TEN_NGUYEN_NHAN,ROUND(SUM([13]),2)AS [Total] FROM " + btSummaryinHour + " WHERE TEN_NGUYEN_NHAN != 'total' GROUP BY TEN_NGUYEN_NHAN"));
            tempt2.Columns["TEN_NGUYEN_NHAN"].ColumnName = " ";
            VeTable(ws1, tempt2, iDong);
            VeBieuDoColumnClustered(ws1, iDong, tempt2, "Downtime Factors " + dTNgay.Year.ToString());
            iDong += tempt2.Rows.Count < 18 ? 20 : tempt2.Rows.Count + 2;
            DataTable tempt3 = new DataTable();
            tempt3.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM " + btSummaryinHour + " WHERE TEN_NGUYEN_NHAN = 'total'"));
            for (int i = 0; i < tableHT.Rows.Count; i++)
            {
                tempt3.Rows[i]["TEN_NGUYEN_NHAN"] = tableHT.Rows[i]["TEN_HE_THONG"].ToString();
            }
            tempt3.Columns.Remove("STT");
            //tempt3.Columns.Remove("-1");
            tempt3.Columns["13"].ColumnName = "Total";
            tempt3.Columns["TEN_NGUYEN_NHAN"].ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachSanXuat", "HeThong", Commons.Modules.TypeLanguage);
            RenameColumsMonth(tempt3);
            VeTable(ws1, tempt3, iDong);
            VeBieudoLine(ws1, iDong, tempt3, dTNgay.Date.Year.ToString() + " Machine Performance");

            iDong += tempt3.Rows.Count < 18 ? 20 : tempt3.Rows.Count + 2;
            DataTable tableSum = new DataTable();
            tableSum.Columns.Add(" ", typeof(string));
            for (int i = 1; i <= 13; i++)
            {
                tableSum.Columns.Add(i.ToString(), typeof(double));
            }
            createTabeDowntime(tempt5);
            sSql = "SELECT 'Schedule Run Hours' AS' ' ,ROUND(SUM([1]),2) AS [1],ROUND(SUM([2]),2)AS [2],ROUND(SUM([3]),2)AS [3],ROUND(SUM([4]),2)AS [4],ROUND(SUM([5]),2)AS [5],ROUND(SUM([6]),2)AS [6],ROUND(SUM([7]),2)AS [7],ROUND(SUM([8]),2)AS [8],ROUND(SUM([9]),2)AS [9],ROUND(SUM([10]),2)AS [10],ROUND(SUM([11]),2)AS [11],ROUND(SUM([12]),2)AS [12],ROUND(SUM([13]),2)AS [13] FROM " + btDowntime + " UNION SELECT 'Total Downtime' AS' ',ROUND(SUM([1]),2) AS[1],ROUND(SUM([2]),2)AS[2],ROUND(SUM([3]),2)AS[3],ROUND(SUM([4]),2)AS[4],ROUND(SUM([5]),2)AS[5],ROUND(SUM([6]),2)AS[6],ROUND(SUM([7]),2)AS[7],ROUND(SUM([8]),2)AS[8],ROUND(SUM([9]),2)AS[9],ROUND(SUM([10]),2)AS[10],ROUND(SUM([11]),2)AS[11],ROUND(SUM([12]),2)AS[12],ROUND(SUM([13]),2)AS[13] FROM " + btSummaryinHour + " WHERE TEN_NGUYEN_NHAN = 'total'";
            DataTable sumdowtime = new DataTable();
            sumdowtime.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            tableSum.Merge(sumdowtime);
            tableSum.Rows.Add("Run Time", GetRuntime(tableSum, 1), GetRuntime(tableSum, 2), GetRuntime(tableSum, 3), GetRuntime(tableSum, 4), GetRuntime(tableSum, 5), GetRuntime(tableSum, 6), GetRuntime(tableSum, 7), GetRuntime(tableSum, 8), GetRuntime(tableSum, 9), GetRuntime(tableSum, 10), GetRuntime(tableSum, 11), GetRuntime(tableSum, 12), GetRuntime(tableSum, 13));
            tableSum.Rows.Add("% Availability", GetPhanTram(tableSum, 1), GetPhanTram(tableSum, 2), GetPhanTram(tableSum, 3), GetPhanTram(tableSum, 4), GetPhanTram(tableSum, 5), GetPhanTram(tableSum, 6), GetPhanTram(tableSum, 7), GetPhanTram(tableSum, 8), GetPhanTram(tableSum, 9), GetPhanTram(tableSum, 10), GetPhanTram(tableSum, 11), GetPhanTram(tableSum, 12), GetPhanTram(tableSum, 13));
            RenameColumsMonth(tableSum);
            tableSum.Columns["13"].ColumnName = "Total";
            VeTable(ws1, tableSum, iDong);
            //ws1.Column(icount).Style.Numberformat.Format = "0.0%";
            ExcelRange title1 = ws1.Cells[iDong + 4, 1, iDong + 4, tableSum.Columns.Count];
            title1.Style.Font.Color.SetColor(Color.Red);
            title1.Style.Numberformat.Format = "0.0%";

            var charttoltal = (ws1.Drawings.AddChart("toltal" + iDong, eChartType.ColumnClustered) as ExcelBarChart);
            charttoltal.SetPosition(iDong - 1, 0, tableSum.Columns.Count + 1, 0);
            charttoltal.SetSize(700, 375);
            charttoltal.Title.Text = "Equipment Availabity";
            charttoltal.Axis[0].Title.Text = "Month";
            charttoltal.Axis[1].Title.Text = "% Equipment Availability";
            ExcelRange x_range = ws1.Cells[iDong, 2, iDong, tableSum.Columns.Count - 1];
            ExcelRange y_range = ws1.Cells[iDong + 4, 2, iDong + 4, tableSum.Columns.Count - 1];
            var css = charttoltal.Series.Add(y_range, x_range);
            css.Fill.Color = Color.MidnightBlue;
            css.Border.Fill.Color = Color.Lime;
            charttoltal.DataLabel.ShowValue = true;
            charttoltal.Legend.Border.Fill.Color = Color.DarkBlue;
            charttoltal.Legend.Remove();

            //cập nhật Output (MT/hr)
            for (int i = 2; i <= 13; i++)
            {
                var cellrow = ws1.Cells[iDong1 + dtsumtotal.Rows.Count, i];
                try
                {
                    //cellrow.Formula = ws1.Cells[iDong1 + 2, i].Address + " / 1000 / " + tableSum.Rows[2][i - 1].ToString();
                    double gt1 = Convert.ToDouble(dtsumtotal.Rows[1][i - 1]);
                    double gt2 = Convert.ToDouble(tableSum.Rows[2][i - 1]);
                    cellrow.Value = Math.Round(gt1 / 1000 / gt2, 2);
                }
                catch (Exception)
                {
                    cellrow.Value = DBNull.Value;
                }
            }



            iDong += tableSum.Rows.Count + 2;
            double n = Math.Round(Convert.ToDouble(tableSum.Rows[3]["Total"]), 5);
            DataTable tablephantram = new DataTable();
            tablephantram.Columns.Add(" ", typeof(string));
            tablephantram.Columns.Add("%", typeof(double));
            tablephantram.Rows.Add("YTD Availability:", n);
            tablephantram.Rows.Add("Equipment Down:", 1 - n);
            VeTable(ws1, tablephantram, iDong);
            ExcelRange title2 = ws1.Cells[iDong, 2, iDong + 2, 2];
            title2.Style.Numberformat.Format = "0.0%";
            VeBieuDoPie(ws1, iDong, tablephantram);
            iDong += tablephantram.Rows.Count + 12;
            //chưa theo dây chuyền
            //table tổng khối lượng nhóm lile làm ra bao nhiêu
            // sSql = "SELECT  pvt.* FROM(SELECT T2.NHOM_LINE AS 'LOAI','Total FG Line ' + CONVERT(NVARCHAR(10),T2.NHOM_LINE) AS 'MONTHLY PACKING RUN RATE',MONTH(NGAY) AS Thang, GIO_KH  FROM dbo.KHSX_NGAY T1 INNER JOIN dbo.HE_THONG T2 ON T2.MS_HE_THONG = T1.MS_HE_THONG WHERE LOAI = 2 AND NGAY BETWEEN CONVERT(DATE,'01/01/" + dTNgay.Year + "') AND CONVERT(DATE,'12/31/" + dTNgay.Year + "')) A PIVOT(SUM(A.GIO_KH) FOR A.THANG IN([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) AS pvt UNION SELECT 99,'Run Hours Line ' + CONVERT(NVARCHAR(10), t1.NAME),t1.[1] - t2.[1] AS[1],t1.[2] - t2.[2] AS[2],t1.[3] - t2.[3] AS[3],t1.[4] - t2.[4] AS[4],t1.[5] - t2.[5] AS[5],t1.[6] - t2.[6] AS[6],t1.[7] - t2.[7] AS[7],t1.[8] - t2.[8] AS[8],t1.[9] - t2.[9] AS[9],t1.[10] - t2.[10] AS[10],t1.[11] - t2.[11] AS[11] ,t1.[12] - t2.[12] AS[12] FROM (SELECT NAME, ROUND(SUM([1]), 2) AS[1],ROUND(SUM([2]),2)AS[2],ROUND(SUM([3]),2)AS[3],ROUND(SUM([4]),2)AS[4],ROUND(SUM([5]),2)AS[5],ROUND(SUM([6]),2)AS[6],ROUND(SUM([7]),2)AS[7],ROUND(SUM([8]),2)AS[8],ROUND(SUM([9]),2)AS[9],ROUND(SUM([10]),2)AS[10],ROUND(SUM([11]),2)AS[11],ROUND(SUM([12]),2)AS[12] FROM " + btDowntime + " GROUP BY NAME) t1 INNER JOIN (SELECT STT, ROUND(SUM([1]), 2) AS[1],ROUND(SUM([2]),2)AS[2],ROUND(SUM([3]),2)AS[3],ROUND(SUM([4]),2)AS[4],ROUND(SUM([5]),2)AS[5],ROUND(SUM([6]),2)AS[6],ROUND(SUM([7]),2)AS[7],ROUND(SUM([8]),2)AS[8],ROUND(SUM([9]),2)AS[9],ROUND(SUM([10]),2)AS[10],ROUND(SUM([11]),2)AS[11],ROUND(SUM([12]),2)AS[12] FROM " + btSummaryinHour + " WHERE TEN_NGUYEN_NHAN = 'total' GROUP BY STT) t2 ON t1.NAME = t2.STT";
            sSql = "SELECT  pvt.* FROM(SELECT T1.NHOM_LINE AS 'LOAI','Total FG Line ' + CONVERT(NVARCHAR(10),T1.NHOM_LINE) AS 'MONTHLY PACKING RUN RATE',MONTH(NGAY) AS Thang, GIO_KH  FROM dbo.HE_THONG T1 LEFT JOIN (SELECT * FROM  dbo.KHSX_NGAY  WHERE LOAI = 2 AND NGAY BETWEEN CONVERT(DATE,'01/01/"+ dTNgay.Year + "') AND CONVERT(DATE,'12/31/"+ dTNgay.Year + "'))T2 ON T2.MS_HE_THONG = T1.MS_HE_THONG AND T2.MS_HE_THONG IN ("+sResulst+")) A PIVOT(SUM(A.GIO_KH) FOR A.THANG IN([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) AS pvt UNION SELECT 99,'Run Hours Line ' + CONVERT(NVARCHAR(10), t1.NAME),t1.[1] - t2.[1] AS[1],t1.[2] - t2.[2] AS[2],t1.[3] - t2.[3] AS[3],t1.[4] - t2.[4] AS[4],t1.[5] - t2.[5] AS[5],t1.[6] - t2.[6] AS[6],t1.[7] - t2.[7] AS[7],t1.[8] - t2.[8] AS[8],t1.[9] - t2.[9] AS[9],t1.[10] - t2.[10] AS[10],t1.[11] - t2.[11] AS[11] ,t1.[12] - t2.[12] AS[12] FROM (SELECT NAME, ROUND(SUM([1]), 2) AS[1],ROUND(SUM([2]),2)AS[2],ROUND(SUM([3]),2)AS[3],ROUND(SUM([4]),2)AS[4],ROUND(SUM([5]),2)AS[5],ROUND(SUM([6]),2)AS[6],ROUND(SUM([7]),2)AS[7],ROUND(SUM([8]),2)AS[8],ROUND(SUM([9]),2)AS[9],ROUND(SUM([10]),2)AS[10],ROUND(SUM([11]),2)AS[11],ROUND(SUM([12]),2)AS[12] FROM " + btDowntime + " GROUP BY NAME) t1 INNER JOIN (SELECT STT, ROUND(SUM([1]), 2) AS[1],ROUND(SUM([2]),2)AS[2],ROUND(SUM([3]),2)AS[3],ROUND(SUM([4]),2)AS[4],ROUND(SUM([5]),2)AS[5],ROUND(SUM([6]),2)AS[6],ROUND(SUM([7]),2)AS[7],ROUND(SUM([8]),2)AS[8],ROUND(SUM([9]),2)AS[9],ROUND(SUM([10]),2)AS[10],ROUND(SUM([11]),2)AS[11],ROUND(SUM([12]),2)AS[12] FROM " + btSummaryinHour + " WHERE TEN_NGUYEN_NHAN = 'total' GROUP BY STT) t2 ON t1.NAME = t2.STT";

            DataTable tempt7 = new DataTable();
            tempt7.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            tempt7.Columns.Remove("LOAI");
            var nhomline = tableHT.AsEnumerable().Select(row => new
            {
                NHOM_LINE = row.Field<int>("NHOM_LINE")
            }).Distinct().OrderBy(x => x.NHOM_LINE).ToList();
            for (int i = 0; i < nhomline.Count; i++)
            {
                DataRow row = tempt7.NewRow();
                row[0] = "Run Rate Line " + nhomline[i].NHOM_LINE;

                for (int j = 1; j <= 12; j++)
                {
                    try
                    {
                        double x = Convert.ToDouble(tempt7.Rows[i][j]);
                        double y = Convert.ToDouble(tempt7.Rows[i + nhomline.Count][j]);
                        row[j] = Math.Round(x / y * 2, 2);
                    }
                    catch (Exception)
                    {
                        row[j] = DBNull.Value;
                    }
                }
                tempt7.Rows.Add(row);
            }
            RenameColumsMonth(tempt7);
            VeTable(ws1, tempt7, iDong);
            iDong += tempt7.Rows.Count + 2;
            for (int i = 0; i < tempt4.Rows.Count; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    tempt4.Columns[j].ReadOnly = false;
                    try
                    {
                        tempt4.Rows[i][j] = Math.Round(Convert.ToDouble(tempt4.Rows[i][j]) / Convert.ToDouble(tableSum.Rows[0][j]), 5);
                    }
                    catch (Exception ex)
                    {
                        tempt4.Rows[i][j] = DBNull.Value;
                    }

                }
            }
            tempt4.Rows.Add("% Downtime", null, null, null, null, null, null, null, null, null, null, null, null, null);
            RenameColumsMonth(tempt4);
            tempt4.Columns["TEN_NGUYEN_NHAN"].ColumnName = " ";
            VeTable(ws1, tempt4, iDong);
            for (int i = 2; i <= 13; i++)
            {
                var cellrow = ws1.Cells[iDong + tempt4.Rows.Count, i];
                cellrow.Formula = "=SUM(" + ws1.Cells[iDong + 1, i].Address + ":" + ws1.Cells[iDong + tempt4.Rows.Count - 1, i].Address + ")";
            }
            for (int i = 1; i <= tempt4.Rows.Count; i++)
            {
                var cell = ws1.Cells[iDong + i, tempt4.Columns.Count];
                cell.Formula = "=SUM(" + ws1.Cells[iDong + i, 2].Address + ":" + ws1.Cells[iDong + i, tempt4.Columns.Count - 1].Address + ")";
            }
            ExcelRange title3 = ws1.Cells[iDong, 2, iDong + tempt4.Rows.Count, tempt4.Columns.Count];
            title3.Style.Numberformat.Format = "0.0%";

            VeBieuDoColumnProduction(ws1, iDong1, dtsumtotal,tempt4,iDong, "" + dTNgay.Year + " production time");



            iDong += tempt4.Rows.Count + 2;

            sSql = "SELECT'Actual Working DAYS' as 'Productivity',ROUND(SUM([1]),2) AS [1],ROUND(SUM([2]),2)AS [2],ROUND(SUM([3]),2)AS [3],ROUND(SUM([4]),2)AS [4],ROUND(SUM([5]),2)AS [5],ROUND(SUM([6]),2)AS [6],ROUND(SUM([7]),2)AS [7],ROUND(SUM([8]),2)AS [8],ROUND(SUM([9]),2)AS [9],ROUND(SUM([10]),2)AS [10],ROUND(SUM([11]),2)AS [11],ROUND(SUM([12]),2)AS [12] FROM " + btDowntime + "";
            DataTable tempt6 = new DataTable();
            tempt6.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            for (int i = 0; i < nhomline.Count; i++)
            {
                DataRow row = tempt6.NewRow();
                row[0] = "Line " + nhomline[i].NHOM_LINE;

                for (int j = 1; j <= 12; j++)
                {
                    tempt6.Columns[j].ReadOnly = false;
                    if (i == 0)
                    {
                        try
                        {
                            tempt6.Rows[0][j] = Math.Round(Convert.ToDouble(tempt6.Rows[0][j]) / (tableHT.Rows.Count * 24), 2);
                        }
                        catch (Exception)
                        {
                            tempt6.Rows[0][j] = DBNull.Value;
                        }
                    }
                    try
                    {
                        double x = Convert.ToDouble(tempt7.Rows[i][j]);
                        double y = Convert.ToDouble(tempt6.Rows[0][j]) * 24;
                        row[j] = Math.Round(x / y, 2);
                    }
                    catch (Exception)
                    {
                        row[j] = DBNull.Value;
                    }
                }
                tempt6.Rows.Add(row);
      
            }
            RenameColumsMonth(tempt6);
            VeTable(ws1, tempt6, iDong);

            VeBieudoLineProductivity(ws1, iDong, tempt6, "Productivity");
            //auto colums từ cột 2 đến cột 14
            ws1.Cells["B1:N"+iDong+""].AutoFitColumns();
        }

        private void LoadWordShert(ExcelPackage pck, DateTime dTNgay, DateTime dDNgay, string Name, DataTable tableHT)
        {
            DataTable tbTongDC = new DataTable();
            DataTable tbTongNN = new DataTable();
            var ws1 = pck.Workbook.Worksheets.Add(Name);
            //var ws1 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ucBCThoiGianCVNhanVienTieuDe", Commons.Modules.TypeLanguage));
            ws1.Cells.Style.Font.Name = "Trebuchet MS";
            ws1.Cells.Style.Font.Size = 11;
            //#region "in Thong Tin Chung"
            //Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws1, "C");
            //#endregion
            //#region "In Thong Tin Sheet 1"
            //int iDong = 5;
            //ws1.Row(4).Height = 9;
            //Commons.Modules.MExcel.MText(ws1, sBC, "ucBCTGNMTieuDe", iDong, 1, iDong, dtData.Columns.Count, true, true, 16, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);
            //iDong++;
            //#endregion
            int iDong = 1;
            List<List<Object>> WidthColumns = new List<List<Object>>();
            List<Object> WidthColumnsName = new List<Object>();
            iDong++;
            int icount = 0, iAllRow = 0;
            WidthColumnsName = new List<Object>()
                    {"TEN_NGUYEN_NHAN",60};
            WidthColumns.Add(WidthColumnsName);
            foreach (DataRow item in tableHT.Rows)
            {
                DataSet dataset = getdataset(Convert.ToInt32(item["MS_HE_THONG"].ToString()), dTNgay, dDNgay);
                DataTable tbTGNM_Tuan = new DataTable();
                DataTable tbTGNM_NN = new DataTable();
                DataTable tbBC = new DataTable();
                //gan du lieu vao data table
                tbBC = dataset.Tables[0];
                tbTGNM_Tuan = dataset.Tables[1];
                tbTGNM_NN = dataset.Tables[2];
                //lấy những dòng chứa tổng của một dây chuyền
                DataTable tempt = tbBC.AsEnumerable().Where(x => x.Field<int>("MS_NGUYEN_NHAN") == 9998).CopyToDataTable();
                tempt.Columns.Remove("35");
                tempt.Columns.Remove("37");
                tempt.Columns.Remove("STT");
                tempt.Columns.Remove("MS_NGUYEN_NHAN");
                tempt.Rows[0]["TEN_NGUYEN_NHAN"] = item["TEN_HE_THONG"].ToString();
                tempt.Columns["TEN_NGUYEN_NHAN"].ColumnName = "Date";
                tempt.Columns["36"].ColumnName = "Total Hrs";
                for (int i = 1; i <= 31; i++)
                {
                    try
                    {
                        tempt.Rows[0]["" + i + ""] = Math.Round((Convert.ToDouble(tempt.Rows[0]["" + i + ""]) / 60), 2);
                    }
                    catch (Exception)
                    {

                    }
                }
                //gán dòng tổng vào table tổng dây chuyển
                tbTongDC.Merge(tempt);


                //in table báo cáo thời gian ngừng mấy theo ngày

                tbBC.AsEnumerable().Select(x => x["MS_NGUYEN_NHAN"] = Convert.ToInt32(item["NHOM_IN"].ToString())).ToList();
                tbBC.Columns.Add("MS_HE_THONG", typeof(int));
                tbBC.AsEnumerable().Select(x => x["MS_HE_THONG"] = Convert.ToInt32(item["MS_HE_THONG"].ToString())).ToList();
                tbTongNN.Merge(tbBC);
                tbBC.Columns.Remove("MS_HE_THONG");
                tbBC.Columns.Remove("STT");
                tbBC.Columns.Remove("MS_NGUYEN_NHAN");
                tbBC.Columns["TEN_NGUYEN_NHAN"].ColumnName = item["TEN_HE_THONG"].ToString();
                tbBC.Columns["35"].ColumnName = "Total";
                tbBC.Columns["36"].ColumnName = "Hr";
                tbBC.Columns["37"].ColumnName = "%";
                ExcelRange allCells = ws1.Cells[iDong, 1, iDong + tbBC.Rows.Count, tbBC.Columns.Count - 3];
                allCells.Style.Numberformat.Format = @"_(* #,##0_);_(* (#,##0);_(* "" - ""??_);_(@_)";

                if (tbBC.Rows.Count > 0)
                {
                    icount = tbBC.Columns.Count;
                    ws1.Cells[iDong, 1].LoadFromDataTable(tbBC, true);
                    Commons.Modules.MExcel.MFormatExcel(ws1, tbBC, iDong, sBC, WidthColumns, false, false, false);
                    ws1.Column(icount - 1).Style.Numberformat.Format = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                    ws1.Column(icount).Style.Numberformat.Format = "0.0%";
                }
                ExcelRange title1 = ws1.Cells[iDong + tbBC.Rows.Count - 1, tbBC.Columns.Count - 2, iDong + tbBC.Rows.Count - 1, tbBC.Columns.Count];
                title1.Style.Font.Color.SetColor(Color.Red);
                //in table báo cáo thời gian ngừng mấy theo tuần không theo nguyên nhân
                for (int i = 0; i < tbTGNM_Tuan.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        tbTGNM_Tuan.Columns[i].ColumnName = "last week in" + dTNgay.AddMonths(-1).ToString("MMM");
                    }
                    if (i == 1)
                    {
                        tbTGNM_Tuan.Columns[i].ColumnName = "1st Week in " + dTNgay.ToString("MMM") + "";
                    }
                    if (i == 2)
                    {
                        tbTGNM_Tuan.Columns[i].ColumnName = "2nd Week in " + dTNgay.ToString("MMM") + "";
                    }
                    if (i == 3)
                    {
                        tbTGNM_Tuan.Columns[i].ColumnName = "3rd Week in " + dTNgay.ToString("MMM") + "";
                    }
                    if (i > 3)
                    {
                        tbTGNM_Tuan.Columns[i].ColumnName = i + "th Week in " + dTNgay.ToString("MMM") + "";
                    }
                }
                ws1.Cells[iDong, tbBC.Columns.Count + 2].LoadFromDataTable(tbTGNM_Tuan, true);
                Commons.Modules.MExcel.MFormatExcel(ws1, tbTGNM_Tuan, iDong, sBC, false, false, false);

                var modelTable = ws1.Cells[iDong, tbBC.Columns.Count + 2, iDong + 1, tbBC.Columns.Count + 1 + tbTGNM_Tuan.Columns.Count];
                // Assign borders
                modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                var chart = (ws1.Drawings.AddChart("ColumnWeek" + iDong, eChartType.ColumnClustered3D) as ExcelBarChart);
                chart.Title.Text = "Downtime in " + item["TEN_HE_THONG"].ToString();
                chart.SetPosition(iDong + 2, 0, tbBC.Columns.Count + 1, 0);
                chart.SetSize(tbTGNM_Tuan.Columns.Count > 6 ? 450 : 400, 300);
                ExcelAddress valueAddress = new ExcelAddress(iDong + 1, tbBC.Columns.Count + 2, iDong + 1, tbBC.Columns.Count + 1 + tbTGNM_Tuan.Columns.Count);
                ExcelAddress valueAddresscolum = new ExcelAddress(iDong, tbBC.Columns.Count + 2, iDong, tbBC.Columns.Count + 1 + tbTGNM_Tuan.Columns.Count);

                var serie1 = chart.Series.Add(valueAddress.Address, valueAddresscolum.Address);
                chart.DataLabel.ShowValue = true;
                chart.Legend.Border.Fill.Style = eFillStyle.SolidFill;
                chart.Legend.Border.Fill.Color = Color.DarkBlue;
                chart.Legend.Remove();

                //in table báo cáo thời gian ngừng mấy theo tuần theo nguyên nhân
                tbTGNM_NN.Columns[0].ColumnName = "Nguyên Nhân Ngừng Máy";
                for (int i = 0; i < tbTGNM_NN.Columns.Count; i++)
                {
                    if (i == 1)
                    {
                        tbTGNM_NN.Columns[i].ColumnName = "last week in" + dTNgay.AddMonths(-1).ToString("MMM");
                    }
                    if (i == 2)
                    {
                        tbTGNM_NN.Columns[i].ColumnName = "1st Week in " + dTNgay.ToString("MMM") + "";
                    }
                    if (i == 3)
                    {
                        tbTGNM_NN.Columns[i].ColumnName = "2nd Week in " + dTNgay.ToString("MMM") + "";
                    }
                    if (i == 4)
                    {
                        tbTGNM_NN.Columns[i].ColumnName = "3rd Week in " + dTNgay.ToString("MMM") + "";
                    }
                    if (i > 4)
                    {
                        tbTGNM_NN.Columns[i].ColumnName = i - 1 + "th Week in " + dTNgay.ToString("MMM") + "";
                    }
                }

                ws1.Cells[iDong, tbBC.Columns.Count + tbTGNM_Tuan.Columns.Count + 3].LoadFromDataTable(tbTGNM_NN, true);
                Commons.Modules.MExcel.MFormatExcel(ws1, tbTGNM_NN, iDong, sBC, false, false, false);

                var modelTableNN = ws1.Cells[iDong, tbBC.Columns.Count + tbTGNM_Tuan.Columns.Count + 3, iDong + tbTGNM_NN.Rows.Count, tbBC.Columns.Count + 2 + tbTGNM_Tuan.Columns.Count + tbTGNM_NN.Columns.Count];
                // Assign borders
                modelTableNN.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTableNN.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTableNN.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTableNN.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws1.Column(tbBC.Columns.Count + tbTGNM_Tuan.Columns.Count + 3).Width = 60;
                loadbieudoNN(ws1, iDong, tbBC.Columns.Count + tbTGNM_Tuan.Columns.Count + 4, iDong + tbTGNM_NN.Rows.Count, tbBC, tbTGNM_Tuan, tbTGNM_NN);
                allCells.AutoFitColumns();

                iDong += tbBC.Rows.Count < 18 ? 19 : tbBC.Rows.Count + 3;
            }

            //in table tổng các dây chuyển
            ws1.Cells[iDong, 1].LoadFromDataTable(tbTongDC, true);
            Commons.Modules.MExcel.MFormatExcel(ws1, tbTongDC, iDong, sBC, false, false, false);
            var modeltbTongDC = ws1.Cells[iDong, 1, iDong + tbTongDC.Rows.Count, tbTongDC.Columns.Count];
            // Assign borders
            modeltbTongDC.Style.Border.Top.Style = ExcelBorderStyle.Dashed;
            modeltbTongDC.Style.Border.Left.Style = ExcelBorderStyle.Dashed;
            modeltbTongDC.Style.Border.Right.Style = ExcelBorderStyle.Dashed;
            modeltbTongDC.Style.Border.Bottom.Style = ExcelBorderStyle.Dashed;
            iDong += tbTongDC.Rows.Count + 2;
            //in table tổng thời gian của các dây chuyền theo từng nguyên nhân
            var dtNhomIn = tableHT.AsEnumerable().Select(row => new
            {
                NHOM_IN = row.Field<int>("NHOM_IN")
            })
            .Distinct().OrderBy(x=>x.NHOM_IN).ToList();
            if (dtNhomIn.Count == 0) return;
            createTabeDSTGNM(tbTongNN);
            double resulst, runrate;
            foreach (var row in dtNhomIn)
            {
                string sSql = "SELECT TEN_NGUYEN_NHAN,SUM([1]) AS [1],SUM([2]) AS [2],SUM([3]) AS [3],SUM([4])AS [4],SUM([5])AS [5],SUM([6])AS [6],SUM([7])AS [7],SUM([8])AS [8],SUM([9])AS [9],SUM([10])AS [10],SUM([11])AS [11],SUM([12])AS [12],SUM([13])AS [13],SUM([14])AS [14],SUM([15])AS [15],SUM([16])AS [16],SUM([17])AS [17],SUM([18])AS [18],SUM([19])AS [19],SUM([20])AS [20],SUM([21])AS [21],SUM([22])AS [22],SUM([23])AS [23],SUM([24])AS [24],SUM([25])AS [25],SUM([26])AS [26],SUM([27])AS [27],SUM([28])AS [28],SUM([29])AS [29],SUM([30])AS [30],SUM([31])AS [31],SUM([35])AS [Total],SUM([36]) AS [Hr],CASE WHEN ROUND(SUM([36])/ (SELECT SUM([36]) FROM " + btTongNN + " WHERE STT = 9999 AND MS_NGUYEN_NHAN =  " + row.NHOM_IN + "),5) = 1 THEN NULL ELSE ROUND(SUM([36])/ (SELECT SUM([36]) FROM " + btTongNN + " WHERE STT = 9999 AND MS_NGUYEN_NHAN = " + row.NHOM_IN + " ),5) END  AS  [%] FROM " + btTongNN + " WHERE MS_NGUYEN_NHAN = " + row.NHOM_IN + " GROUP BY STT,TEN_NGUYEN_NHAN ORDER BY STT ";
                DataTable dttempt = new DataTable();
                dttempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dttempt.Columns["TEN_NGUYEN_NHAN"].ColumnName = "" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachSanXuat", "nhomDC", Commons.Modules.TypeLanguage) + " :" + row.NHOM_IN.ToString();
                ws1.Cells[iDong, 1].LoadFromDataTable(dttempt, true);
                Commons.Modules.MExcel.MFormatExcel(ws1, dttempt, iDong, sBC, false, false, false);
                var modeltbTongNN = ws1.Cells[iDong, 1, iDong + dttempt.Rows.Count, dttempt.Columns.Count];
                // Assign borders
                modeltbTongNN.Style.Border.Top.Style = ExcelBorderStyle.Hair;
                modeltbTongNN.Style.Border.Left.Style = ExcelBorderStyle.Hair;
                modeltbTongNN.Style.Border.Right.Style = ExcelBorderStyle.Hair;
                modeltbTongNN.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                int colbd = dttempt.Columns.Count + 2;
                //tiêu đề
                Commons.Modules.MExcel.MText(ws1, "", "Running day:", iDong + 1, colbd, iDong + 1, colbd + 2, true);
                Commons.Modules.MExcel.MText(ws1, "", "Actual running hours:", iDong + 2, colbd, iDong + 2, colbd + 2, true);
                Commons.Modules.MExcel.MText(ws1, "", "FG in month (EF):", iDong + 3, colbd, iDong + 3, colbd + 2, true);
                Commons.Modules.MExcel.MText(ws1, "", "Run rate:", iDong + 4, colbd, iDong + 4, colbd + 2, true);
                int count = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) FROM " + btTongNN + " WHERE STT = 9999 and MS_NGUYEN_NHAN= " + row.NHOM_IN + ""));
                try
                {
                    //giá trị
                    double dRunningDay = Math.Round(Convert.ToDouble(dttempt.Rows[dttempt.Rows.Count - 1]["Hr"].ToString()) / (count * 24), 2);
                    double dRunningHount = Math.Round(Convert.ToDouble(dttempt.Rows[dttempt.Rows.Count - 1]["Hr"].ToString()) - Convert.ToDouble(dttempt.Rows[dttempt.Rows.Count - 2]["Hr"].ToString()), 2);
                    Commons.Modules.MExcel.MText(ws1, "", dRunningDay.ToString(), iDong + 1, colbd + 3, false, 11, ExcelHorizontalAlignment.Right, ExcelVerticalAlignment.Center);
                    Commons.Modules.MExcel.MText(ws1, "", dRunningHount.ToString(), iDong + 2, colbd + 3, false, 11, ExcelHorizontalAlignment.Right, ExcelVerticalAlignment.Center);
                    sSql = "SELECT SUM(GIO_KH) FROM dbo.KHSX_NGAY WHERE NGAY BETWEEN CONVERT(DATE,'" + dTNgay.Month + "/" + dTNgay.Day + "/" + dTNgay.Year + "') AND CONVERT(DATE,'" + dDNgay.Month + "/" + dDNgay.Day + "/" + dDNgay.Year + "') AND LOAI=2 AND MS_HE_THONG IN(SELECT MS_HE_THONG FROM " + btTongNN + " WHERE MS_NGUYEN_NHAN = " + row.NHOM_IN + " AND STT = 9999)";
                    try
                    {
                        resulst = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                        resulst = Math.Round(resulst / 1000, 2);
                        runrate = Math.Round(resulst / dRunningHount, 2);
                    }
                    catch (Exception ex)
                    {
                        resulst = 0;
                        runrate = 0;
                    }
                    Commons.Modules.MExcel.MText(ws1, "", resulst.ToString(), iDong + 3, colbd + 3, false, 11, ExcelHorizontalAlignment.Right, ExcelVerticalAlignment.Center);
                    Commons.Modules.MExcel.MText(ws1, "", runrate.ToString(), iDong + 4, colbd + 3, false, 11, ExcelHorizontalAlignment.Right, ExcelVerticalAlignment.Center);
                }
                catch (Exception ex)
                {

                }
                //đơn vị
                Commons.Modules.MExcel.MText(ws1, "", "hrs", iDong + 2, colbd + 4, false, 11, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Center);
                Commons.Modules.MExcel.MText(ws1, "", "tons", iDong + 3, colbd + 4, false, 11, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Center);
                Commons.Modules.MExcel.MText(ws1, "", "t/hr", iDong + 4, colbd + 4, false, 11, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Center);
                iDong += dttempt.Rows.Count + 2;

            }
            ws1.View.FreezePanes(1, 2);
        }

        private double? GetPhanTram(DataTable dt, int col)
        {
            double? resulst;
            double row1, row2;
            try
            {
                try
                {
                    row1 = Convert.ToDouble(dt.Rows[2][col.ToString()]);
                }
                catch (Exception)
                {
                    row1 = 0;
                }
                try
                {
                    row2 = Convert.ToDouble(dt.Rows[0][col.ToString()]);

                }
                catch (Exception)
                {
                    row2 = 0;
                }
                resulst = row1 / row2;
            }
            catch
            {
                resulst = null;
            }
            return resulst == 0 ? null : resulst;
        }
        private double? GetRuntime(DataTable dt, int col)
        {
            double? resulst;
            double row1, row2;
            try
            {
                try
                {
                    row1 = Convert.ToDouble(dt.Rows[0][col.ToString()]);

                }
                catch (Exception)
                {
                    row1 = 0;
                }
                try
                {
                    row2 = Convert.ToDouble(dt.Rows[1][col.ToString()]);

                }
                catch (Exception)
                {
                    row2 = 0;
                }
                resulst = row1 - row2;
            }
            catch
            {
                resulst = null;
            }
            return resulst == 0 ? null : resulst;
        }
        private void VeTable(ExcelWorksheet ws1, DataTable dtsumnottotal, int iDong)
        {
            ws1.Cells[iDong, 1].LoadFromDataTable(dtsumnottotal, true);
            Commons.Modules.MExcel.MFormatExcel(ws1, dtsumnottotal, iDong, sBC, false, false, false);
            var modeltbNN = ws1.Cells[iDong, 1, iDong + dtsumnottotal.Rows.Count, dtsumnottotal.Columns.Count];
            modeltbNN.Style.Border.Top.Style = ExcelBorderStyle.Dashed;
            modeltbNN.Style.Border.Left.Style = ExcelBorderStyle.Dashed;
            modeltbNN.Style.Border.Right.Style = ExcelBorderStyle.Dashed;
            modeltbNN.Style.Border.Bottom.Style = ExcelBorderStyle.Dashed;
        }
        private void VeBieuDoColumnClustered(ExcelWorksheet ws1, int iDong, DataTable tempt, string title)
        {
            var charttoltal = (ws1.Drawings.AddChart("toltal" + iDong, eChartType.ColumnClustered) as ExcelBarChart);
            charttoltal.SetPosition(iDong - 1, 0, tempt.Columns.Count + 1, 0);
            charttoltal.SetSize(700, 375);
            charttoltal.Title.Text = title;
            charttoltal.Axis[1].Title.Text = "Downtime(Hr)";
            ExcelRange x_range = ws1.Cells[iDong + 1, 1, iDong + tempt.Rows.Count, 1];
            ExcelRange y_range = ws1.Cells[iDong + 1, tempt.Columns.Count, iDong + tempt.Rows.Count, tempt.Columns.Count];
            var seri0 = charttoltal.Series.Add(y_range, x_range);
            charttoltal.DataLabel.ShowValue = true;
            seri0.Fill.Color = Color.DarkBlue;
            charttoltal.Legend.Remove();
            charttoltal.GapWidth = 0;
        }
        private void VeBieuDoColumnProduction(ExcelWorksheet ws1, int iDong, DataTable tempt,DataTable tempt1,int iDong1, string title)
        {
            var charttoltal = (ws1.Drawings.AddChart("toltal" + iDong, eChartType.ColumnClustered) as ExcelBarChart);
            charttoltal.SetPosition(iDong - 1, 0, tempt.Columns.Count + 2, 0);
            charttoltal.SetSize(1500, 375);
            charttoltal.Title.Text = title;
            charttoltal.Axis[0].Title.Text = "Month";
            charttoltal.Axis[1].Title.Text = "Output(MT/hr)";
           ExcelRange x_range = ws1.Cells[iDong, 2, iDong, tempt.Columns.Count];
            ExcelRange y_range = ws1.Cells[iDong + 3, 2, iDong + 3, tempt.Columns.Count];
            var css = charttoltal.Series.Add(y_range, x_range);
            css.Fill.Color = Color.Green;
            charttoltal.DataLabel.ShowValue = true;
            charttoltal.Legend.Border.Fill.Color = Color.Green;
            charttoltal.YAxis.Font.Color = Color.Green;
            charttoltal.Legend.Remove();
            ExcelRange y_range1 = ws1.Cells[iDong1 + tempt1.Rows.Count, 2, iDong1 + tempt1.Rows.Count, tempt1.Columns.Count - 1];
            var chart2b = charttoltal.PlotArea.ChartTypes.Add(eChartType.XYScatterLines);
            var serie2b = chart2b.Series.Add(y_range1, x_range);
            serie2b.Border.Fill.Color = Color.Blue;
            serie2b.Border.Width = 3;
            chart2b.UseSecondaryAxis = true;
            chart2b.YAxis.Title.Text = "% Downtime";
            chart2b.YAxis.Font.Color = Color.Blue;
        }

        private void VeBieuDoPie(ExcelWorksheet ws1, int iDong, DataTable tempt)
        {
            var charttoltal = (ws1.Drawings.AddChart("toltal" + iDong, eChartType.Pie));
            charttoltal.SetPosition(iDong - 1, 0, tempt.Columns.Count + 1, 0);
            charttoltal.SetSize(400, 250);
            charttoltal.Title.Text = "YTD Equipment Availabity";


            var series = charttoltal.Series.Add(ws1.Cells[iDong + 1, 2, iDong + 2, 2], ws1.Cells[iDong + 1, 1, iDong + 2, 1]);
            var pieSeries = (ExcelPieChartSerie)series;
            pieSeries.Explosion = 5;
        }
        private void VeBieudoLine(ExcelWorksheet ws1, int iDong, DataTable tempt, string title)
        {
            var chart = (ws1.Drawings.AddChart("SummaryinHour" + iDong, eChartType.Line) as ExcelLineChart);
            chart.SetPosition(iDong - 1, 0, tempt.Columns.Count + 1, 0);
            chart.SetSize(1000, 400);
            chart.Title.Text = title;
            chart.Axis[1].Title.Text = "Downtime(Hr)";
            chart.Axis[0].Title.Text = "Month";
            int iRow = iDong;
            ExcelAddress valueAddresscolum = new ExcelAddress(iRow, 2, iRow, tempt.Columns.Count);
            for (int i = 1; i <= tempt.Rows.Count; i++)
            {
                ExcelAddress valueAddress0 = new ExcelAddress(iRow + 1, 2, iRow + 1, tempt.Columns.Count);
                var serie0 = chart.Series.Add(valueAddress0.Address, valueAddresscolum.Address);
                serie0.Border.Width = 3;
                serie0.Header = ws1.Cells[iRow + 1, 1].Value.ToString();
                iRow++;
            }
            chart.Legend.Border.Fill.Style = eFillStyle.NoFill;
            chart.Legend.Position = eLegendPosition.Bottom;
        }


        private void VeBieudoLineProductivity(ExcelWorksheet ws1, int iDong, DataTable tempt, string title)
        {
            try
            {
                var chart = (ws1.Drawings.AddChart("SummaryinHour" + iDong, eChartType.Line) as ExcelLineChart);
                chart.SetPosition(iDong - 1, 0, tempt.Columns.Count + 1, 0);
                chart.SetSize(1000, 400);
                chart.Title.Text = title;
                chart.Axis[1].Title.Text = "MT FG/hr";
                int iRow = iDong;
                ExcelAddress valueAddresscolum = new ExcelAddress(iRow, 2, iRow, tempt.Columns.Count);
                for (int i = 2; i <= tempt.Rows.Count; i++)
                {
                    ExcelAddress valueAddress0 = new ExcelAddress(iRow + i, 2, iRow + i, tempt.Columns.Count);
                    var serie0 = chart.Series.Add(valueAddress0.Address, valueAddresscolum.Address);
                    serie0.Border.Width = 3;
                    serie0.Header = ws1.Cells[iRow + i, 1].Value.ToString();
                }
                chart.Legend.Border.Fill.Style = eFillStyle.NoFill;
                chart.Legend.Position = eLegendPosition.Right;

            }
            catch (Exception ex)
            {

            }
        }

        //create sheet tất cả các tháng
        private void loadbieudoSummaryNhomTheoHT(ExcelWorksheet ws1, int iDong, DataTable tempt)
        {
            var chart = (ws1.Drawings.AddChart("Summary" + iDong, eChartType.Line) as ExcelLineChart);
            chart.SetPosition(iDong - 1, 0, tempt.Columns.Count + 1, 0);
            chart.SetSize(1000, 375);
            int iRow = iDong;
            ExcelAddress valueAddresscolum = new ExcelAddress(iDong, 2, iDong, tempt.Columns.Count);
            foreach (var item in tempt.Rows)
            {
                ExcelAddress valueAddress0 = new ExcelAddress(iRow + 1, 2, iRow + 1, tempt.Columns.Count);
                var serie0 = chart.Series.Add(valueAddress0.Address, valueAddresscolum.Address);
                serie0.Border.Width = 3;
                serie0.Header = ws1.Cells[iRow + 1, 1].Value.ToString();
                if (iRow == iDong + tempt.Rows.Count - 1)
                {
                    serie0.Border.Fill.Color = Color.Red;
                }
                iRow++;

            }



            chart.Legend.Border.Fill.Style = eFillStyle.NoFill;
            chart.Legend.Position = eLegendPosition.Right;
        }
        private void loadbieudoSummaryInHour(ExcelWorksheet ws1, int iDong, DataTable tempt, DataTable tableHT, string tenHT)
        {
            var chart = (ws1.Drawings.AddChart("SummaryinHour" + iDong, eChartType.Line) as ExcelLineChart);
            chart.SetPosition(iDong - 1, 0, tempt.Columns.Count + 1, 0);
            chart.SetSize(1000, 375);
            chart.Title.Text = datTNgay.DateTime.Year + " " + tenHT + " Performance";
            chart.Axis[1].Title.Text = "Downtime(Hr)";
            chart.Axis[1].Title.Font.Color = Color.DarkBlue;
            int iRow = iDong;
            ExcelAddress valueAddresscolum = new ExcelAddress(iRow, 2, iRow, tempt.Columns.Count - 1);
            for (int i = 1; i < tempt.Rows.Count; i++)
            {
                ExcelAddress valueAddress0 = new ExcelAddress(iRow + 1, 2, iRow + 1, tempt.Columns.Count - 1);
                var serie0 = chart.Series.Add(valueAddress0.Address, valueAddresscolum.Address);
                serie0.Border.Width = 3;
                serie0.Header = ws1.Cells[iRow + 1, 1].Value.ToString();
                iRow++;
            }
            chart.Legend.Border.Fill.Style = eFillStyle.NoFill;
            chart.Legend.Position = eLegendPosition.Right;

            var charttoltal = (ws1.Drawings.AddChart("toltal" + iDong, eChartType.ColumnClustered) as ExcelBarChart);
            charttoltal.SetPosition(iDong - 1, 0, tempt.Columns.Count + 18, 0);
            charttoltal.SetSize(800, 375);
            charttoltal.Title.Text = "Frequency plot of " + tenHT + " Defects";
            charttoltal.Axis[1].Title.Text = "Downtime(Hr)";
            charttoltal.Axis[1].Title.Font.Color = Color.DarkBlue;
            ExcelRange x_range = ws1.Cells[iDong + 1, 1, iDong + tempt.Rows.Count - 1, 1];
            ExcelRange y_range = ws1.Cells[iDong + 1, tempt.Columns.Count, iDong + tempt.Rows.Count - 1, tempt.Columns.Count];
            charttoltal.Series.Add(y_range, x_range);
            charttoltal.DataLabel.ShowValue = true;
            charttoltal.Legend.Border.Fill.Style = eFillStyle.SolidFill;
            charttoltal.Legend.Border.Fill.Color = Color.DarkBlue;
            charttoltal.Legend.Remove();
            charttoltal.GapWidth = 0;
        }
        private void loadbieudoSummary(ExcelWorksheet ws1, int iDong, DataTable tempt, DataTable tableHT)
        {
            var chart = (ws1.Drawings.AddChart("Summary" + iDong, eChartType.ColumnStacked));
            chart.SetPosition(iDong - 1, 0, tempt.Columns.Count + 1, 0);
            chart.SetSize(1000, 375);

            int iRow = iDong;
            ExcelAddress valueAddresscolum = new ExcelAddress(iDong, 2, iDong, tempt.Columns.Count);
            for (int i = 1; i < tempt.Rows.Count - 1; i++)
            {
                ExcelAddress valueAddress0 = new ExcelAddress(iRow + 1, 2, iRow + 1, tempt.Columns.Count);
                var serie0 = chart.Series.Add(valueAddress0.Address, valueAddresscolum.Address);
                serie0.Header = ws1.Cells[iRow + 1, 1].Value.ToString();
                iRow++;
            }
            ExcelAddress valueAddress1 = new ExcelAddress(iDong + tempt.Rows.Count, 2, iDong + tempt.Rows.Count, tempt.Columns.Count);
            var cs3 = chart.PlotArea.ChartTypes.Add(eChartType.Line);
            var serie1 = cs3.Series.Add(valueAddress1.Address, valueAddresscolum.Address);
            serie1.Header = ws1.Cells[iDong + tempt.Rows.Count, 1].Value.ToString();
            serie1.Border.Width = 3;
            serie1.Border.Fill.Color = Color.Red;
            chart.Legend.Border.Fill.Style = eFillStyle.NoFill;
            chart.Legend.Position = eLegendPosition.Right;
        }
        private void loadbieudoNN(ExcelWorksheet ws1, int iDong, int icolums, int itorow, DataTable tbBC, DataTable tbTGNM_Tuan, DataTable tbTGNM_NN)
        {
            var chart = (ws1.Drawings.AddChart("ColumnNN" + iDong, eChartType.ColumnClustered3D) as ExcelBarChart);
            chart.SetPosition(iDong - 1, 0, tbBC.Columns.Count + tbTGNM_Tuan.Columns.Count + tbTGNM_NN.Columns.Count + 3, 0);
            chart.SetSize(1500, 375);

            ExcelAddress valueAddresscolum = new ExcelAddress(iDong + 1, icolums - 1, iDong + tbTGNM_NN.Rows.Count, icolums - 1);

            ExcelAddress valueAddress0 = new ExcelAddress(iDong + 1, icolums, iDong + tbTGNM_NN.Rows.Count, icolums);
            var serie0 = chart.Series.Add(valueAddress0.Address, valueAddresscolum.Address);
            serie0.Header = ws1.Cells[iDong, icolums].Value.ToString();


            ExcelAddress valueAddress1 = new ExcelAddress(iDong + 1, icolums + 1, itorow, icolums + 1);
            var serie1 = chart.Series.Add(valueAddress1.Address, valueAddresscolum.Address);
            serie1.Header = ws1.Cells[iDong, icolums + 1].Value.ToString();

            ExcelAddress valueAddress2 = new ExcelAddress(iDong + 1, icolums + 2, itorow, icolums + 2);
            var serie2 = chart.Series.Add(valueAddress2.Address, valueAddresscolum.Address);
            serie2.Header = ws1.Cells[iDong, icolums + 2].Value.ToString();

            ExcelAddress valueAddress3 = new ExcelAddress(iDong + 1, icolums + 3, itorow, icolums + 3);
            var serie3 = chart.Series.Add(valueAddress3.Address, valueAddresscolum.Address);
            serie3.Header = ws1.Cells[iDong, icolums + 3].Value.ToString();

            ExcelAddress valueAddress4 = new ExcelAddress(iDong + 1, icolums + 4, itorow, icolums + 4);
            var serie4 = chart.Series.Add(valueAddress4.Address, valueAddresscolum.Address);
            serie4.Header = ws1.Cells[iDong, icolums + 4].Value.ToString();

            ExcelAddress valueAddress5 = new ExcelAddress(iDong + 1, icolums + 5, itorow, icolums + 5);
            var serie5 = chart.Series.Add(valueAddress5.Address, valueAddresscolum.Address);
            serie5.Header = ws1.Cells[iDong, icolums + 5].Value.ToString();
            if (tbTGNM_Tuan.Columns.Count > 6)
            {
                ExcelAddress valueAddress6 = new ExcelAddress(iDong + 1, icolums + 6, itorow, icolums + 6);
                var serie6 = chart.Series.Add(valueAddress6.Address, valueAddresscolum.Address);
                serie6.Header = ws1.Cells[iDong, icolums + 6].Value.ToString();
            }
            chart.DataLabel.ShowValue = true;
            chart.Legend.Border.Fill.Style = eFillStyle.SolidFill;
            chart.Legend.Position = eLegendPosition.Bottom;
        }
        private DataSet getdataset(int HeThong, DateTime dTNgay, DateTime dDNgay)
        {
            DataSet dsTmp = new DataSet();
            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
                connection.Open();
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandText = "ReportTGNM";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Tu_Ngay", dTNgay.Date));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Den_Ngay", dDNgay.Date));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HeThong", HeThong));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sbTGNN", btDSNN));
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                adapter.Fill(dsTmp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            return dsTmp;
        }
        private DataSet getdatasetInhour(int HeThong, DateTime dTNgay)
        {
            DataSet dsTmp = new DataSet();
            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
                connection.Open();
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandText = "spGetBCTGNMTong";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Nam", dTNgay.Date));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HeThong", HeThong));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PTram", 0));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sbTGNN", btDSNN));
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                adapter.Fill(dsTmp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            return dsTmp;
        }
        #endregion

        #region tạo bảng tạm
        //tạo table bảng tạm chứa nguyên nhân ngừng mấy đã chọn
        private void createTableTGNN()
        {
            try
            {
                Commons.Modules.ObjSystems.XoaTable(btDSNN);
            }
            catch { }
            DataTable dt = (DataTable)grdNNNgungMay.DataSource;
            DataTable TGNNM = dt.AsEnumerable().Where(x => x.Field<bool>("CHON") == true).CopyToDataTable();
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, btDSNN, TGNNM, "");
        }
        //tao table Downtime
        private void createTabeDowntime(DataTable dt)
        {
            try
            {
                Commons.Modules.ObjSystems.XoaTable(btDowntime);
            }
            catch { }
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, btDowntime, dt, "");
        }

        //tạo table bảng tạm chứa nguyên nhân ngừng mấy đã chọn
        private void createTabeDSTGNM(DataTable dt)
        {
            try
            {
                Commons.Modules.ObjSystems.XoaTable(btTongNN);
            }
            catch { }
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, btTongNN, dt, "");
        }

        //tạo bảng tạm summary
        private void createTabeSummary(DataTable dt)
        {

            try
            {
                Commons.Modules.ObjSystems.XoaTable(btSummary);
            }
            catch { }
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, btSummary, dt, "");
        }

        //tạo bảng tạm summaryInHour
        private void createTabeSummaryInHour(DataTable dt)
        {
            try
            {
                Commons.Modules.ObjSystems.XoaTable(btSummaryinHour);
            }
            catch { }
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, btSummaryinHour, dt, "");
        }

        #endregion

        #region tìm kiếm trên lưới
        private void txtTKNNNM_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtBC = new DataTable();
            dtBC = (DataTable)grdNNNgungMay.DataSource;
            try
            {
                string dk = "";
                if (txtTKNNNM.Text.Length != 0) dk = "TEN_NGUYEN_NHAN  LIKE '%" + txtTKNNNM.Text + "%' ";
                dtBC.DefaultView.RowFilter = dk;
            }
            catch { dtBC.DefaultView.RowFilter = ""; }
        }
        private void txtTKHeThong_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtBC = new DataTable();
            dtBC = (DataTable)grdHeThong.DataSource;

            try
            {
                string dk = "";
                if (txtTKHeThong.Text.Length != 0) dk = "TEN_HE_THONG  LIKE '%" + txtTKHeThong.Text + "%' ";
                dtBC.DefaultView.RowFilter = dk;
            }
            catch { dtBC.DefaultView.RowFilter = ""; }
        }
        #endregion

        private void grvHeThong_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string sSql = "UPDATE dbo.HE_THONG SET NHOM_IN = " + grvHeThong.GetFocusedRowCellValue("NHOM_IN").ToString() + ",NHOM_LINE = " + grvHeThong.GetFocusedRowCellValue("NHOM_LINE").ToString() + " WHERE MS_HE_THONG = " + grvHeThong.GetFocusedRowCellValue("MS_HE_THONG").ToString() + "";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
        }
        private void btn_KeHoach_Click(object sender, EventArgs e)
        {
            frmKeHoachSanXuat frm = new frmKeHoachSanXuat();
            frm.ShowDialog();
        }
    }
}
