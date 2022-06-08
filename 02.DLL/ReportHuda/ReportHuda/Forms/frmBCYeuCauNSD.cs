using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ReportHuda
{
    public partial class frmBCYeuCauNSD : DevExpress.XtraEditors.XtraForm
    {
        private string sNgay;
        public string _Ngay
        {
            get
            { return sNgay; }
            set
            { sNgay = value; }
        }

        private string sLMay;
        public string _LMay
        {
            get
            { return sLMay; }
            set
            { sLMay = value; }
        }

        private string sNMay;
        public string _NMay
        {
            get
            { return sNMay; }
            set
            { sNMay = value; }
        }

        private string sDDiem;
        public string _DDiem
        {
            get
            { return sDDiem; }
            set
            { sDDiem = value; }
        }

        private string sDChuyen;
        public string _DChuyen
        {
            get
            { return sDChuyen; }
            set
            { sDChuyen = value; }
        }

        private string sTTrang;
        public string _TTrang
        {
            get
            { return sTTrang; }
            set
            { sTTrang = value; }
        }

        private DataTable dtTable;
        public DataTable _dtTable
        {
            get
            { return dtTable; }
            set
            { dtTable = value; }
        }

        public frmBCYeuCauNSD()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);

        }

        private void frmBCYeuCauNSD_Load(object sender, EventArgs e)
        {
            lblTNgay.Text = sNgay;
            lblDDiem.Text = sDDiem;
            lblDChuyen.Text = sDChuyen;
            lblTTrang.Text = sTTrang;
            lblLMay.Text = sLMay;
            lblNMay.Text = sNMay;
            LoadGridcontrol();
            //    lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
            //this.Name, "lblTSo", Commons.Modules.TypeLanguage) + " : " + grvData.RowCount.ToString() + "   ";

        }

        private void LoadGridcontrol()
        {
            try
            {
                lbl.Text = dtTable.Rows[0][dtTable.Columns.Count - 1].ToString();
            }
            catch { }
            //dtTable.Columns[dtTable.Columns.Count - 1].remo
            dtTable.Columns.RemoveAt(dtTable.Columns.Count - 1);
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dtTable, false, false, false, true, true, this.Name);
            grvData.Columns["NGAY"].Width = 100;
            grvData.Columns["GIO_YEU_CAU"].Width = 100;
            grvData.Columns["NGUOI_YEU_CAU"].Width = 100;
            grvData.Columns["MS_MAY"].Width = 70;
            grvData.Columns["Ten_N_XUONG"].Width = 120;
            grvData.Columns["MO_TA_TINH_TRANG"].Width = 200;
            grvData.Columns["YEU_CAU"].Width = 200;
            grvData.Columns["NOI_DUNG_CV"].Width = 200;
            grvData.Columns["NGAY_HOAN_THANH"].Width = 100;
            grvData.Columns["NOI_DUNG_XAC_NHAN"].Width = 120;
            grvData.Columns["NGUOI_XAC_NHAN"].Width = 120;

            RepositoryItemMemoEdit meno = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            meno.WordWrap = true;
            meno.AutoHeight = true;
            meno.BeginInit();

            grvData.Columns["MO_TA_TINH_TRANG"].ColumnEdit = meno;
            grvData.Columns["YEU_CAU"].ColumnEdit = meno;
            grvData.Columns["NOI_DUNG_XAC_NHAN"].ColumnEdit = meno;
            grvData.Columns["NOI_DUNG_CV"].ColumnEdit = meno;
            grdData.RepositoryItems.Add(meno);
        }

        private void btnExecute_Click(object sender, EventArgs e)
         {

            if (grvData.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDSBaoTri", "KhongCoDuLieu", Commons.Modules.TypeLanguage));
                return;
            }

            InDuLieu();
        }
        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();

            try
            {
                int TCot = grvData.Columns.Count;
                int TDong = grvData.RowCount;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grvData.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;



                grdData.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);


                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 9, Dong);
                int SCot;

                SCot = 8;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = 2;
                string stmp = "";
                Excel.Range title;                
                
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sSTLYCNSD", Commons.Modules.TypeLanguage);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, TCot - 2, Dong, TCot - 2);
                title.Font.Italic = true;
                title.Font.Size = 9;
                title.Value2 = stmp;

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sPhienBanYCNSD", Commons.Modules.TypeLanguage);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, TCot - 2, Dong, TCot - 2);
                title.Font.Italic = true;
                title.Font.Size = 9;
                title.Value2 = stmp;

                
                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sNgayApDungYCNSD", Commons.Modules.TypeLanguage);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, TCot - 2, Dong, TCot - 2);
                title.Font.Italic = true;
                title.Font.Size = 9;
                title.Value2 = stmp;

                Dong = 6;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "TieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter),
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 8 ? 8 : SCot));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                
                stmp = sNgay;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = sDDiem;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                Dong++;
                stmp = sDChuyen;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = sLMay;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                stmp = sNMay;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

               

                Dong++;
                stmp = sTTrang;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);


                int DongBD;
                DongBD = Dong + 3;
                
                Dong++;
                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, TCot);
                title.RowHeight = 9;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                if (Commons.Modules.sPrivate == "TRUNGNGUYEN")
                {
                    Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong - 1);
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, lbl.Text, Dong - 1, 2, "@", 10, true, true, Dong - 1, TCot);
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "dd/MM/yyyy", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "HH:mm:ss", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 18, "@", true, Dong + 1, 5, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "dd/MM/yyyy", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 12, TDong + Dong, 12);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "dd/MM/yyyy", true, Dong + 1, 13, TDong + Dong, 13);
                
                
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong + 1, 14, TDong + Dong, 14);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 15, TDong + Dong, 15);

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "dd/MM/yyyy", true, Dong + 1, 16, TDong + Dong, 16);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong + 1, 17, TDong + Dong, 19);

                
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "dd/MM/yyyy", true, Dong + 1, 20, TDong + Dong, 20);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "HH:mm:ss", true, Dong + 1, 21, TDong + Dong, 21);


                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong + 1, 22, TDong + Dong, 24);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "dd/MM/yyyy", true, Dong + 1, 25, TDong + Dong, 25);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                excelWorkbook.Save();
                excelApplication.Visible = true;
                this.Cursor = Cursors.Default;
            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                excelApplication.Visible = true;

                //prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.Info == null && e.SelectedControl == grdData)
            {
                GridView view = grdData.FocusedView as GridView;
                GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);
                if (info.InRowCell)
                {
                    //string text = view.GetRowCellDisplayText(info.RowHandle, info.Column);
                    // lấy text của dòng đang focus vào
                    string text = view.GetRowCellDisplayText(info.RowHandle, "TEN_TINH_TRANG");
                    //đếm số dòng có tình trạng trên
                    DataTable dt = (DataTable)grdData.DataSource;
                    int n = dt.AsEnumerable().Where(x => x["TEN_TINH_TRANG"].ToString().Trim() == text.Trim()).Count();
                    string cellKey = info.RowHandle.ToString();
                    e.Info = new ToolTipControlInfo(cellKey, text + "( "+n.ToString()+" )");
                }
            }
        }
    }
}