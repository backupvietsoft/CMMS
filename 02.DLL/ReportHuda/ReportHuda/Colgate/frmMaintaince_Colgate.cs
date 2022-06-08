using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Linq;

namespace ReportHuda.Colgate
{
    public partial class frmMaintaince_Colgate : DevExpress.XtraEditors.XtraForm
    {
        public int iLoad = 0;
        // iLoad form == 0 view goc Colgate --   
        //iLoad == 1 Load form view Vifon bang ke phieu bao tri  
        //iLoad == 2 Load form view Vifon bang ke TGNM 
        //iLoad == 3 load giam sat tinh trang



        public DataTable _tableSource = new DataTable();
        public DataTable _tableMaintaince = new DataTable();
        bool isFirst = true;
        public string date;
        public int inTheoThangNam = 0;
        string sBC = "ucBangKePBT";
        public string sNX, sDC;
        public frmMaintaince_Colgate()
        {
            InitializeComponent();
        }

        private void frmMaintaince_Colgate_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            switch (iLoad)
            {
                case 0:
                    ColgateLoad();
                    break;
                case 1:
                case 2:
                    LoadBangKe();
                    break;
                case 3:
                    this.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "loadGSTT", Commons.Modules.TypeLanguage);
                    loadGiamSatTinhTrang();
                    break;
                default:
                    ColgateLoad();
                    break;
            }
        }
        #region Load GSTT
        private void loadGiamSatTinhTrang()
        {
            //thay doi lable
            if (inTheoThangNam == 1)
            {
                lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTitlegs", Commons.Modules.TypeLanguage);
            }
            else if (inTheoThangNam == 2)
            {
                lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTitleNamgs", Commons.Modules.TypeLanguage);
            }
            else
            {
                lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTitleTuangs", Commons.Modules.TypeLanguage);
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(gdMachine, gridView1, _tableSource, false, true, false, true, false, sBC);
            try
            {
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView1.Columns[i].AppearanceHeader.Options.UseTextOptions = true;
                    if (i > (Commons.Modules.sPrivate == "VIFON" ? 4 : 6))
                    {
                        gridView1.Columns[i].Width = inTheoThangNam == 0 ? 80 : 50;
                        if (inTheoThangNam == 1)
                        {
                            gridView1.Columns[i].Caption = convertDateTime(gridView1.Columns[i].Name);
                        }
                    }
                }
            }
            catch { }

            gridView1.Columns["MS_MAY"].Width = 80;
            //tao ngon nghu cho colums

            gridView1.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmAccessory", "MS_MAY", Commons.Modules.TypeLanguage);
            gridView1.Columns["MS_N_XUONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBranch", "MS_N_XUONG", Commons.Modules.TypeLanguage);
            gridView1.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmAccessory", "TEN_MAY", Commons.Modules.TypeLanguage);

            if (Commons.Modules.sPrivate != "VIFON")
            {
                gridView1.Columns["TEN_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonCongViecChoBoPhan", "TEN_BO_PHAN", Commons.Modules.TypeLanguage);
                gridView1.Columns["TEN_TS_GSTT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonTSGSTT", "TEN_TS_GSTT", Commons.Modules.TypeLanguage);
            }
            else
            {
                gridView1.Columns["NGAY_KT_CUOI"].Visible = false;

            }
            gridView1.Columns["CHU_KY_DO"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonTSGSTT", "CHU_KY_DO", Commons.Modules.TypeLanguage);
            gridView1.Columns["NGAY_KT_CUOI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonTSGSTT", "NGAY_KT_CUOI", Commons.Modules.TypeLanguage);

            gridView1.Columns["CL"].Visible = false;
            //group theo ma nha xuong
            gridView1.OptionsCustomization.AllowGroup = true;
            gridView1.Columns["MS_N_XUONG"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            GridColumn nhaxuong = gridView1.Columns["MS_N_XUONG"];
            nhaxuong.GroupIndex = 0;
            gridView1.ExpandAllGroups();
            gridView1.OptionsView.ShowGroupPanel = false;
        }
        #endregion
        #region "Colgate Load"
        private void ColgateLoad()
        {
            gdMachine.DataSource = _tableSource;

            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExecute", Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnCancel", Commons.Modules.TypeLanguage);
            if (inTheoThangNam == 1)
            {
                lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTitle", Commons.Modules.TypeLanguage);
            }
            else if (inTheoThangNam == 2)
            {
                lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTitleNam", Commons.Modules.TypeLanguage);
            }
            else
            {
                lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTitleTuan", Commons.Modules.TypeLanguage);
            }
            int c = gridView1.Columns.Count;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
            {
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (!col.Name.Equals("colMachineName") && !col.Name.Equals("colTotal") && !col.Name.Equals("colCHU_KY_DO") && !col.Name.Equals("colNGAY_CUOI"))
                {
                    if (inTheoThangNam == 2)
                        col.Width = 80;
                    else
                        col.Width = 50;


                    if (inTheoThangNam == 1)
                    {
                        col.Caption = convertDateTime(col.Name);
                    }
                    else if (inTheoThangNam == 2)
                    {
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", col.Name.Substring(3, col.Name.Length - 3), Commons.Modules.TypeLanguage);
                    }
                    else
                    {
                        col.Caption = col.Name.Split('!')[1];
                    }
                }
                else
                {
                    if (col.Name.Equals("colTotal")) col.Visible = false;
                    if (col.Name.Equals("colMachineName")) col.Width = 300;
                    if (col.Name.Equals("colNGAY_CUOI")) col.Width = 100;
                    if (col.Name.Equals("colCHU_KY_DO")) col.Width = 200;
                }

            }
            try
            {
                gridView1.Columns["CHU_KY_DO"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonTSGSTT", "CHU_KY_DO", Commons.Modules.TypeLanguage);
                gridView1.Columns["NGAY_CUOI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonTSGSTT", "NGAY_KT_CUOI", Commons.Modules.TypeLanguage);
                //gridView1.Columns[0].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;

                gridView1.OptionsCustomization.AllowGroup = true;
                gridView1.Columns[0].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }

        private string convertDateTime(string dateofweek)
        {
            switch (dateofweek.Split('!')[1].ToLower())
            {
                case "mon":
                    return Commons.Modules.TypeLanguage == 0 ? "H" : "M";
                case "tue":
                    return Commons.Modules.TypeLanguage == 0 ? "B" : "TU";
                case "wed":
                    return Commons.Modules.TypeLanguage == 0 ? "T" : "W";
                case "thu":
                    return Commons.Modules.TypeLanguage == 0 ? "N" : "TH";
                case "fri":
                    return Commons.Modules.TypeLanguage == 0 ? "S" : "F";
                case "sat":
                    return Commons.Modules.TypeLanguage == 0 ? "B" : "SA";
                case "sun":
                    return Commons.Modules.TypeLanguage == 0 ? "CN" : "SU";
            }
            return "";
        }
        private string convertColWeek(string dateofweek)
        {
            switch (dateofweek)
            {
                case "Tu":
                    return Commons.Modules.TypeLanguage == 0 ? "H" : "M";
                case "tue":
                    return Commons.Modules.TypeLanguage == 0 ? "B" : "TU";
                case "wed":
                    return Commons.Modules.TypeLanguage == 0 ? "T" : "W";
                case "thu":
                    return Commons.Modules.TypeLanguage == 0 ? "N" : "TH";
                case "fri":
                    return Commons.Modules.TypeLanguage == 0 ? "S" : "F";
                case "sat":
                    return Commons.Modules.TypeLanguage == 0 ? "B" : "SA";
                case "sun":
                    return Commons.Modules.TypeLanguage == 0 ? "CN" : "SU";
            }
            return "";
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (isFirst && iLoad == 3)
            {
                DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.RowHandle == 0 && inTheoThangNam == 1)
                {
                    e.Appearance.BackColor = Color.FromArgb(155, 194, 230);

                    string ngay = View.GetRowCellValue(e.RowHandle, gridView1.Columns["NGAY_KT_CUOI"]).ToString();
                    if (e.CellValue.ToString() == ngay)
                        e.Appearance.ForeColor = Color.FromArgb(155, 194, 230);
                }
                else
                {
                    string c = "";
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
                    {
                        //MS_N_XUONG ,MS_MAY,TEN_MAY,TEN_BO_PHAN,TEN_TS_GSTT
                        if (col.Name != "colMS_N_XUONG" && col.Name != "colMS_MAY" && col.Name != "colTEN_MAY" && col.Name != "colTEN_BO_PHAN" && col.Name != "colTEN_TS_GSTT" && col.Name != "colCHU_KY_DO" && col.Name != "colNGAY_KT_CUOI")
                        {
                            int n;
                            if (string.IsNullOrEmpty(e.CellValue.ToString())) return;
                            if (!int.TryParse(e.CellValue.ToString(), out n)) return;

                            string category = View.GetRowCellValue(e.RowHandle, gridView1.Columns["CL"]).ToString();
                            c += View.GetRowCellValue(e.RowHandle, col).ToString();
                            string[] color;
                            color = category.Split(',');
                            if (color.Length > 2)
                            {
                                try
                                {

                                    if (int.TryParse(e.CellValue.ToString(), out n))
                                    {
                                        e.Appearance.BackColor = Color.FromArgb(Convert.ToInt16(color[0]), Convert.ToInt16(color[1]), Convert.ToInt16(color[2]));
                                        if (Commons.Modules.sPrivate == "VIFON")
                                        {
                                            e.Appearance.ForeColor = Color.FromArgb(Convert.ToInt16(color[0]), Convert.ToInt16(color[1]), Convert.ToInt16(color[2]));
                                        }
                                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                        e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                                    }

                                }
                                catch { }
                            }

                        }
                    }

                }

            }

            if (isFirst && iLoad == 0)
            {
                DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.RowHandle == 0)
                {
                    e.Appearance.BackColor = Color.FromArgb(155, 194, 230);
                    //e.Appearance.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                int count = 0;
                string c = "";
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
                {
                    if (col.Name != "colMachineName" && col.Name != "colTotal" && col.Name != "colCHU_KY_DO" && col.Name != "colTEN_LOAI_BT")
                    {
                        string category = View.GetRowCellValue(e.RowHandle, col).ToString();
                        c += View.GetRowCellValue(e.RowHandle, col).ToString();
                        string[] color;
                        color = category.Split(' ');
                        if (color.Length > 2)
                        {
                            if (e.Column.Name == col.Name)
                            {
                                e.Appearance.ForeColor = Color.FromArgb(Convert.ToInt16(color[0]), Convert.ToInt16(color[1]), Convert.ToInt16(color[2]));
                                e.Appearance.BackColor = Color.FromArgb(Convert.ToInt16(color[0]), Convert.ToInt16(color[1]), Convert.ToInt16(color[2]));
                                //isFirst = false;
                            }
                        }
                        count = e.RowHandle;
                    }
                }

                if (string.IsNullOrEmpty(c))
                {
                    e.Appearance.BackColor = Color.FromArgb(227, 239, 255);
                }

                if (e.Column.Name == "colTotal")
                {
                    e.Appearance.BackColor = Color.FromArgb(204, 255, 204);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void GetImage(byte[] Logo)
        {
            //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
            string strPath = Application.StartupPath + "\\logo.bmp";
            System.IO.MemoryStream stream = new System.IO.MemoryStream(Logo);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(strPath);
        }

        private void ExecuteColgate()
        {
            try
            {
                string path = "";
                try
                {
                    path = "";
                    path = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                    if (path == "") return;

                    if (inTheoThangNam == 1)
                    {
                        if (Commons.Modules.sPrivate == "REMINGTON") InTheoThangRil(path); else InTheoThang(path);
                    }
                    else if (inTheoThangNam == 2)
                    {
                        if (Commons.Modules.sPrivate == "REMINGTON") InTheoNamRIL(path);else InTheoNam(path);
                    }
                    else
                    {
                        if (Commons.Modules.sPrivate == "REMINGTON") InTheoTuanRil(path); else InTheoTuan(path);
                    }
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
                this.Cursor = Cursors.WaitCursor;

            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            this.Cursor = Cursors.Default;
        }
        private void InTheoTuanRil(string path)
        {
            Excel.Application excelApplication = new Excel.Application();
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook;
            Excel.Worksheet excelWorkSheet;
            try
            {
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                gdMachine.ExportToXlsx(path);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                DataTable dtTmp = new DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    " SELECT CASE WHEN " + Commons.Modules.TypeLanguage + "=0 " +
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " +
                        " CASE WHEN " + Commons.Modules.TypeLanguage + "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,'Phone : ' + Phone + '. Fax : ' + Fax AS PHONE , EMAIL FROM THONG_TIN_CHUNG "));

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;
                int Dong = 1;
                excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                //int count_column = _tableSource.Columns.Count - (iLoad == 0 ? 1 : 0);
                int count_column = _tableSource.Columns.Count - (iLoad == 0 ? 1 : (Commons.Modules.sPrivate == "VIFON" ? 2 : 1));

                var n = 0;
                try
                {
                    n = _tableSource.AsEnumerable().Select(x => x.Field<string>("MS_N_XUONG")).Distinct().Count();
                }
                catch (Exception)
                {
                    n = 0;
                }
                int count_row = iLoad == 0 ? _tableSource.Rows.Count : _tableSource.Rows.Count + n;
                //int count_row = _tableSource.Rows.Count;

                //Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1,1, 1, count_column);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //huong sua gstr
                //excelApplication.Visible = true;
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                Excel.Range title;
                if (iLoad == 0 || iLoad == 3)
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, count_column - 4]);
                else
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, count_column]);
                
                title.Merge(true);
                title.Font.Bold = true;
                //title.Font.Size = iLoad == 0 ? 11 : 16;
                if (Commons.Modules.sPrivate == "VIFON")
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }
                else
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.WrapText = true;

                if (Commons.Modules.sPrivate == "VIFON")
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"];
                else
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"] + "\n" + dtTmp.Rows[0]["DIA_CHI"];// + "\n" + dtTmp.Rows[0]["PHONE"];

                title.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                if (iLoad == 0 || iLoad == 3)
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, count_column -2], excelWorkSheet.Cells[1, count_column ]);
                    title.Merge(true);
                    title.Font.Italic = true;
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    title.WrapText = true;
                    title.Font.Size = 9;
                    string stmp = "";
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "sSTLKHTuan" + iLoad.ToString(), Commons.Modules.TypeLanguage);
                    stmp = stmp + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "sPhienBanKHTuan" + iLoad.ToString(), Commons.Modules.TypeLanguage);
                    stmp = stmp + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "sNgayApDungKHTuan" + iLoad.ToString(), Commons.Modules.TypeLanguage);

                    title.Value2 = stmp;
                    title.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                }
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);


                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 1, 1], excelWorkSheet.Cells[Dong + 1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Font.Size = 16;

                


                if (Commons.Modules.sPrivate == "VIFON")
                    title.Value2 = lblTitle.Text;
                else
                    title.Value2 = lblTitle.Text + " " + (Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTuan", Commons.Modules.TypeLanguage) + " " + date + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNam", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year).ToUpper() + "\n" + sNX + "     " + sDC;

                //title.AutoFit();

                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                if (Commons.Modules.sPrivate != "VIFON") title.RowHeight = 80;


                //huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, (iLoad == 0 ? 1 : 2)], excelWorkSheet.Cells[3, iLoad == 0 ? 3 : Commons.Modules.sPrivate == "VIFON" ? 4 : 7]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                //title.NumberFormat = "yyy";
                title.Font.Size = 11;
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTuan", Commons.Modules.TypeLanguage) + " " + date + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNam", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, iLoad == 0 ? 4 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8], excelWorkSheet.Cells[3, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, iLoad == 0 ? "lblDatesofMantenance" : "lblNgayGS", Commons.Modules.TypeLanguage);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                title.Font.Size = 11;
                excelWorkSheet.Columns.ColumnWidth = 11;

                //huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Range content = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 1], excelWorkSheet.Cells[count_row, 1]);
                content.ColumnWidth = (iLoad == 0 ? 30 : 0);

                //huong sua gstr
                if (iLoad == 3)
                {
                    if (iLoad == 3)
                    {
                        Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                        content2.ColumnWidth = 18;

                        Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                        content3.ColumnWidth = 25;

                        if (Commons.Modules.sPrivate == "VIFON")
                        {
                            Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                            content4.ColumnWidth = 8;

                            //Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                            //content5.ColumnWidth = 10;
                        }
                        else
                        {
                            Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                            content4.ColumnWidth = 30;

                            Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                            content5.ColumnWidth = 25;

                            Excel.Range content6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 6], excelWorkSheet.Cells[count_row, 6]);
                            content6.ColumnWidth = 8;

                            Excel.Range content7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 7], excelWorkSheet.Cells[count_row, 7]);
                            content7.ColumnWidth = 10;
                        }
                    }

                }
                else
                {

                    Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                    content2.EntireColumn.AutoFit();
                    Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                    content3.ColumnWidth = 10;
                }
                //huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.Range backTitle = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
                backTitle.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 255, 204));
                //huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                int rowMaintaince = count_row + 6;
                Excel.Range r;
                // huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Range CurCell = (Excel.Range)excelWorkSheet.get_Range("A1", (iLoad == 0 ? "A1" : "B1"));
                CurCell.RowHeight = 42;
                try
                {
                    GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                    excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 100, 42);
                    System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");

                }
                catch (Exception)
                {
                }

                // huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (iLoad == 0)
                {//ghi chú phiếu bảo trì
                   
                    int dong = 5;
                    int iCotMau = count_column;
                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 6;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 2;



                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 2];
                        //r = (Excel.Range)excelWorkSheet.Cells[dong, 2];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][3]), Convert.ToInt16(_tableMaintaince.Rows[i][4]), Convert.ToInt16(_tableMaintaince.Rows[i][5])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 3], excelWorkSheet.Cells[dong, iCotMau + 3]);
                        //r = (Excel.Range)excelWorkSheet.Cells[dong, 3];
                        r.Value2 = _tableMaintaince.Rows[i][2];
                        //r.Merge(true);
                        dong += 1;
                    }

                }
                else
                  if (Commons.Modules.sPrivate != "VIFON")
                {
                    
                    int dong = 6;
                    int iCotMau = count_column;

                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 6;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 5;



                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 3];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][1]), Convert.ToInt16(_tableMaintaince.Rows[i][2]), Convert.ToInt16(_tableMaintaince.Rows[i][3])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 4], excelWorkSheet.Cells[dong, iCotMau + 6]);
                        r.Merge(true);
                        //r.Value2 = _tableMaintaince.Rows[k][2];

                        switch (Convert.ToInt32(_tableMaintaince.Rows[i][0]))
                        {
                            case 1: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNgay", Commons.Modules.TypeLanguage); break;
                            case 2: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTuan", Commons.Modules.TypeLanguage); break;
                            case 3: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTThang", Commons.Modules.TypeLanguage); break;
                            case 4: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNam", Commons.Modules.TypeLanguage); break;
                            default:
                                break;
                        }
                        dong += 1;
                    }
                }
                //ve bottom
                //huong sua gstr
                rowMaintaince = count_row + 6;//600
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (iLoad == 0)
                {//chử ký của phiếu bảo trì
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 1], excelWorkSheet.Cells[rowMaintaince, 2]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 1] = "Người Lập Phiếu";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 3], excelWorkSheet.Cells[rowMaintaince, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 3] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                }
                else
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 2], excelWorkSheet.Cells[rowMaintaince, 2]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 2] = "Người Lập";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 3], excelWorkSheet.Cells[rowMaintaince, 3]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 3] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 4], excelWorkSheet.Cells[rowMaintaince, 7]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 4] = "Admin CMMS";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 8], excelWorkSheet.Cells[rowMaintaince, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 8] = "Giám Đốc Thiết Bị";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; 
                //title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                // huong sua gstr
                if (iLoad == 3)
                {

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, _tableSource.Columns.Count], excelWorkSheet.Cells[_tableSource.Rows.Count, _tableSource.Columns.Count]);
                    title.EntireColumn.Delete(Type.Missing);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 8], excelWorkSheet.Cells[4, 8]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 9], excelWorkSheet.Cells[4, 9]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 10], excelWorkSheet.Cells[4, 10]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 11], excelWorkSheet.Cells[4, 11]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 5 : 12], excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 5 : 12]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 6 : 13], excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 6 : 13]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 7 : 14], excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 7 : 14]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);
                    //title.NumberFormat = "dd-mm";

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, 14]);
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }
                else
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, 10]);
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                excelApplication.ActiveWindow.DisplayGridlines = true;
                excelWorkbook.Save();
                excelApplication.Visible = true;


                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch
            {
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = false;
                excelApplication.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
        }

        private void InTheoTuan(string path)
        {
            Excel.Application excelApplication = new Excel.Application();
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook;
            Excel.Worksheet excelWorkSheet;
            try
            {
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                gdMachine.ExportToXlsx(path);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                DataTable dtTmp = new DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    " SELECT CASE WHEN " + Commons.Modules.TypeLanguage + "=0 " +
                        " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " +
                        " CASE WHEN " + Commons.Modules.TypeLanguage + "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,'Phone : ' + Phone + '. Fax : ' + Fax AS PHONE , EMAIL FROM THONG_TIN_CHUNG "));

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;
                int Dong = 1;
                excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                //int count_column = _tableSource.Columns.Count - (iLoad == 0 ? 1 : 0);
                int count_column = _tableSource.Columns.Count - (iLoad == 0 ? 1 : (Commons.Modules.sPrivate == "VIFON" ? 2 : 1));

                var n = 0;
                try
                {
                    n = _tableSource.AsEnumerable().Select(x => x.Field<string>("MS_N_XUONG")).Distinct().Count();
                }
                catch (Exception)
                {
                    n = 0;
                }
                int count_row = iLoad == 0 ? _tableSource.Rows.Count : _tableSource.Rows.Count + n;
                //int count_row = _tableSource.Rows.Count;

                //Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1,1, 1, count_column);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //huong sua gstr
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.Font.Size = iLoad == 0 ? 11 : 16;
                if (Commons.Modules.sPrivate == "VIFON")
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }
                else
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.WrapText = true;

                if (Commons.Modules.sPrivate == "VIFON")
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"];
                else
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"] + "\n" + dtTmp.Rows[0]["DIA_CHI"];// + "\n" + dtTmp.Rows[0]["PHONE"];
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);



                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 1, 1], excelWorkSheet.Cells[Dong + 1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Font.Size = 16;
                if (Commons.Modules.sPrivate == "VIFON")
                    title.Value2 = lblTitle.Text;
                else
                    title.Value2 = lblTitle.Text + " " + (Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTuan", Commons.Modules.TypeLanguage) + " " + date + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNam", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year).ToUpper() + "\n" + sNX + "     " + sDC;

                //title.AutoFit();

                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                if (Commons.Modules.sPrivate != "VIFON") title.RowHeight = 80;


                //huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, (iLoad == 0 ? 1 : 2)], excelWorkSheet.Cells[3, iLoad == 0 ? 3 : Commons.Modules.sPrivate == "VIFON" ? 4 : 7]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                //title.NumberFormat = "yyy";
                title.Font.Size = 11;
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTuan", Commons.Modules.TypeLanguage) + " " + date + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNam", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Year;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, iLoad == 0 ? 4 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8], excelWorkSheet.Cells[3, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, iLoad == 0 ? "lblDatesofMantenance" : "lblNgayGS", Commons.Modules.TypeLanguage);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                title.Font.Size = 11;
                excelWorkSheet.Columns.ColumnWidth = 4.14;

                //huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Range content = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 1], excelWorkSheet.Cells[count_row, 1]);
                content.ColumnWidth = (iLoad == 0 ? 30 : 0);

                //huong sua gstr
                if (iLoad == 3)
                {
                    if (iLoad == 3)
                    {
                        Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                        content2.ColumnWidth = 18;

                        Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                        content3.ColumnWidth = 25;

                        if (Commons.Modules.sPrivate == "VIFON")
                        {
                            Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                            content4.ColumnWidth = 8;

                            //Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                            //content5.ColumnWidth = 10;
                        }
                        else
                        {
                            Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                            content4.ColumnWidth = 30;

                            Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                            content5.ColumnWidth = 25;

                            Excel.Range content6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 6], excelWorkSheet.Cells[count_row, 6]);
                            content6.ColumnWidth = 8;

                            Excel.Range content7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 7], excelWorkSheet.Cells[count_row, 7]);
                            content7.ColumnWidth = 10;
                        }
                    }

                }
                else
                {

                    Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                    content2.EntireColumn.AutoFit();
                    Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                    content3.ColumnWidth = 10;
                }
                //huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.Range backTitle = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
                backTitle.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 255, 204));
                //huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                int rowMaintaince = count_row + 6;
                Excel.Range r;
                // huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Range CurCell = (Excel.Range)excelWorkSheet.get_Range("A1", (iLoad == 0 ? "A1" : "B1"));
                CurCell.RowHeight = 42;
                try
                {
                    GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                    excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 100, 42);
                    System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");

                }
                catch (Exception)
                {
                }

                // huong sua gstr
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (iLoad == 0)
                {//ghi chú phiếu bảo trì

                    int dong = 5;
                    int iCotMau = count_column;
                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 6;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 2;



                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 2];
                        //r = (Excel.Range)excelWorkSheet.Cells[dong, 2];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][3]), Convert.ToInt16(_tableMaintaince.Rows[i][4]), Convert.ToInt16(_tableMaintaince.Rows[i][5])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 3], excelWorkSheet.Cells[dong, iCotMau + 3]);
                        //r = (Excel.Range)excelWorkSheet.Cells[dong, 3];
                        r.Value2 = _tableMaintaince.Rows[i][2];
                        //r.Merge(true);
                        dong += 1;
                    }

                }
                else
                  if (Commons.Modules.sPrivate != "VIFON")
                {

                    int dong = 6;
                    int iCotMau = count_column;

                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 6;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 5;



                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 3];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][1]), Convert.ToInt16(_tableMaintaince.Rows[i][2]), Convert.ToInt16(_tableMaintaince.Rows[i][3])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 4], excelWorkSheet.Cells[dong, iCotMau + 6]);
                        r.Merge(true);
                        //r.Value2 = _tableMaintaince.Rows[k][2];

                        switch (Convert.ToInt32(_tableMaintaince.Rows[i][0]))
                        {
                            case 1: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNgay", Commons.Modules.TypeLanguage); break;
                            case 2: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTuan", Commons.Modules.TypeLanguage); break;
                            case 3: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTThang", Commons.Modules.TypeLanguage); break;
                            case 4: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNam", Commons.Modules.TypeLanguage); break;
                            default:
                                break;
                        }
                        dong += 1;
                    }
                }
                //ve bottom
                //huong sua gstr
                rowMaintaince = count_row + 6;//600
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (iLoad == 0)
                {//chử ký của phiếu bảo trì
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 1], excelWorkSheet.Cells[rowMaintaince, 2]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 1] = "Người Lập Phiếu";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 3], excelWorkSheet.Cells[rowMaintaince, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 3] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                }
                else
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 2], excelWorkSheet.Cells[rowMaintaince, 2]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 2] = "Người Lập";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 3], excelWorkSheet.Cells[rowMaintaince, 3]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 3] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 4], excelWorkSheet.Cells[rowMaintaince, 7]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 4] = "Admin CMMS";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 8], excelWorkSheet.Cells[rowMaintaince, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 8] = "Giám Đốc Thiết Bị";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; 
                //title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                // huong sua gstr
                if (iLoad == 3)
                {

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, _tableSource.Columns.Count], excelWorkSheet.Cells[_tableSource.Rows.Count, _tableSource.Columns.Count]);
                    title.EntireColumn.Delete(Type.Missing);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 8], excelWorkSheet.Cells[4, 8]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 9], excelWorkSheet.Cells[4, 9]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 10], excelWorkSheet.Cells[4, 10]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 11], excelWorkSheet.Cells[4, 11]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 5 : 12], excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 5 : 12]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 6 : 13], excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 6 : 13]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 7 : 14], excelWorkSheet.Cells[4, Commons.Modules.sPrivate == "VIFON" ? 7 : 14]);
                    title.NumberFormat = "@";
                    title.Value2 = title.Value.ToString().Substring(0, 5);
                    //title.NumberFormat = "dd-mm";

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, 14]);
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }
                else
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, 10]);
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                excelApplication.ActiveWindow.DisplayGridlines = true;
                excelWorkbook.Save();
                excelApplication.Visible = true;


                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch
            {
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = false;
                excelApplication.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
        }

        private void InTheoThangRil(string path)
        {
            Excel.Application excelApplication = new Excel.Application();
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook;
            Excel.Worksheet excelWorkSheet;
            try
            {
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grvChung.RowCount + 11 + TCot - 4;
                gdMachine.ExportToXlsx(path);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                DataTable dtTmp = new DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                   " SELECT CASE WHEN " + Commons.Modules.TypeLanguage + "=0 " +
                       " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " +
                       " CASE WHEN " + Commons.Modules.TypeLanguage + "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,'Phone : ' + Phone + '. Fax : ' + Fax AS PHONE , EMAIL FROM THONG_TIN_CHUNG "));

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                //excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                int count_column = _tableSource.Columns.Count - (iLoad == 0 ? 1 : (Commons.Modules.sPrivate == "VIFON" ? 2 : 1));
                var n = 0;
                try
                {
                    n = _tableSource.AsEnumerable().Select(x => x.Field<string>("MS_N_XUONG")).Distinct().Count();
                }
                catch (Exception)
                {
                    n = 0;
                }
                int count_row = iLoad == 0 ? _tableSource.Rows.Count : _tableSource.Rows.Count + n;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //int count_row = _tableSource.Rows.Count;
                //huong sua gstr
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, iLoad == 0 ? 12 : Commons.Modules.sPrivate == "VIFON" ? 4 : 7]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, iLoad == 0 ? 15 : Commons.Modules.sPrivate == "VIFON" ? 4 : 7]);
                title.Merge(true);
                title.Font.Bold = true;
                //HUONG SUA 11 THÀNH 1
                //title.Font.Size = iLoad == 0 ? 11 : 16;
                if (Commons.Modules.sPrivate == "VIFON")
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }
                else
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                }
                
                title.WrapText = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //huong sua gstr
                if (Commons.Modules.sPrivate == "VIFON")
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"];
                else
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"] + "\n" + dtTmp.Rows[0]["DIA_CHI"];// + "\n" + dtTmp.Rows[0]["PHONE"];

                title.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;

                if (iLoad == 0 || iLoad == 3) {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, count_column-10], excelWorkSheet.Cells[1, count_column]);
                    title.Merge(true);
                    title.Font.Italic = true;
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    title.Font.Size = 9;
                    string stmp = "";
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "sSTLKHThang" + iLoad.ToString(), Commons.Modules.TypeLanguage);
                    stmp = stmp + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "sPhienBanKHThang" + iLoad.ToString(), Commons.Modules.TypeLanguage);
                    stmp = stmp + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "sNgayApDungKHThang" + iLoad.ToString(), Commons.Modules.TypeLanguage);

                    title.Value2 = stmp;
                    title.RowHeight = 45;
                    title.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                } else
                {

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 13 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8], excelWorkSheet.Cells[1, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    title.Font.Size = 16;
                    if (Commons.Modules.sPrivate == "VIFON")
                        excelWorkSheet.Cells[1, iLoad == 0 ? 13 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8] = lblTitle.Text;
                    else
                        excelWorkSheet.Cells[1, iLoad == 0 ? 13 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8] = lblTitle.Text + " : " + date.ToString() + "\n" + sNX + "     " + sDC;

                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion





                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                if (Commons.Modules.sPrivate != "VIFON") title.RowHeight = 80;
                if (iLoad == 0 ) title.RowHeight = 45;


                //huong sua gstr
                //title = (Excel.Range)excelWorkSheet.Cells[2, iLoad == 0 ? 1 : 2];
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, (iLoad == 0 ? 3 : Commons.Modules.sPrivate == "VIFON" ? 4 : 7)]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                title.NumberFormat = "MM/yyy";
                title.Value2 = date;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, iLoad == 0 ? 4 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8], excelWorkSheet.Cells[2, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, iLoad == 0 ? "lblDatesofMantenance" : "lblNgayGS", Commons.Modules.TypeLanguage);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.Font.Size = 11;
                title.Font.Bold = true;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                excelWorkSheet.Columns.ColumnWidth = 2;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Range content = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 1], excelWorkSheet.Cells[count_row, 1]);
                content.ColumnWidth = iLoad == 0 ? 30 : 0;
                if (iLoad == 0)
                {
                    //Excel.Range content1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, count_column], excelWorkSheet.Cells[count_row, count_column]);
                    //content1.ColumnWidth = 5;

                    Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                    content2.EntireColumn.AutoFit();

                    Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                    content3.ColumnWidth = 10;
                }
                else
                {
                    if (iLoad == 3)
                    {
                        Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                        content2.ColumnWidth = 18;

                        Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                        content3.ColumnWidth = 25;

                        if (Commons.Modules.sPrivate == "VIFON")
                        {
                            Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                            content4.ColumnWidth = 8;

                            //Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                            //content5.ColumnWidth = 10;
                        }
                        else
                        {
                            Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                            content4.ColumnWidth = 30;

                            Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                            content5.ColumnWidth = 25;

                            Excel.Range content6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 6], excelWorkSheet.Cells[count_row, 6]);
                            content6.ColumnWidth = 8;

                            Excel.Range content7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 7], excelWorkSheet.Cells[count_row, 7]);
                            content7.ColumnWidth = 10;
                        }
                    }
                }

                //huong sua gstr
                Excel.Range backTitle = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, iLoad == 0 ? 1 : 2], excelWorkSheet.Cells[3, count_column]);
                backTitle.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 255, 204));
                int rowMaintaince = count_row + 5;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.Range r;
                Excel.Range CurCell = (Excel.Range)excelWorkSheet.get_Range("A1", "A1");
                //CurCell.RowHeight = 42;
                try
                {
                    GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                    excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 100, 42);
                    System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
                }
                catch (Exception)
                {
                }
                //huong sua
                if (iLoad == 0)
                {//ghi chu
                    int dong = 5;
                    int iCotMau = count_column;
                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 5;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 2;


                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 2];                        
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][3]), Convert.ToInt16(_tableMaintaince.Rows[i][4]), Convert.ToInt16(_tableMaintaince.Rows[i][5])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 3], excelWorkSheet.Cells[dong, iCotMau + 3]);     
                        r.Value2 = _tableMaintaince.Rows[i][2];
                        r.Merge(true);
                        dong += 1;
                    }
                }
                else if (Commons.Modules.sPrivate != "VIFON")
                {
                    int dong = 7;
                    int iCotMau = count_column;

                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 6;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 5;




                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 3];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][1]), Convert.ToInt16(_tableMaintaince.Rows[i][2]), Convert.ToInt16(_tableMaintaince.Rows[i][3])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 4], excelWorkSheet.Cells[dong, iCotMau + 6]);
                        r.Merge(true);
                        //r.Value2 = _tableMaintaince.Rows[k][2];

                        switch (Convert.ToInt32(_tableMaintaince.Rows[i][0]))
                        {
                            case 1: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNgay", Commons.Modules.TypeLanguage); break;
                            case 2: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTuan", Commons.Modules.TypeLanguage); break;
                            case 3: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTThang", Commons.Modules.TypeLanguage); break;
                            case 4: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNam", Commons.Modules.TypeLanguage); break;
                            default:
                                break;
                        }
                        dong += 1;
                    }
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                if (iLoad == 0)
                {//chu ky
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 1], excelWorkSheet.Cells[rowMaintaince, 8]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 1] = "Người Lập Phiếu";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 9], excelWorkSheet.Cells[rowMaintaince, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 9] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }

                else
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 2], excelWorkSheet.Cells[rowMaintaince, 2]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 2] = "Người Lập";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 3], excelWorkSheet.Cells[rowMaintaince, 6]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 3] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 7], excelWorkSheet.Cells[rowMaintaince, 3 + ((count_column) / 2)]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 7] = "Admin CMMS";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 4 + ((count_column) / 2)], excelWorkSheet.Cells[rowMaintaince, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 4 + ((count_column) / 2)] = "Giám Đốc Thiết Bị";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    //title.Borders.LineStyle = 1;
                    //title.Borders.Weight = 4;
                }


                // huong sua gstr
                if (iLoad == 3)
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
                    title.EntireRow.Delete(Type.Missing);
                }

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[4, 1]);
                title.MergeCells = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 255, 204));

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 2], excelWorkSheet.Cells[4, 2]);
                title.MergeCells = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 3], excelWorkSheet.Cells[4, 3]);
                title.MergeCells = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                if (iLoad == 3)
                {

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 4], excelWorkSheet.Cells[4, 4]);
                    title.MergeCells = true;
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;



                    if (Commons.Modules.sPrivate != "VIFON")
                    {

                        title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 5], excelWorkSheet.Cells[4, 5]);
                        title.MergeCells = true;
                        title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                        title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 6], excelWorkSheet.Cells[4, 6]);
                        title.MergeCells = true;
                        title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                        title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 7], excelWorkSheet.Cells[4, 7]);
                        title.MergeCells = true;
                        title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    }

                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                // huong sua gstr
                if (iLoad == 3)
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, Commons.Modules.sPrivate == "VIFON" ? 3 : 6], excelWorkSheet.Cells[4, count_column]);
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, _tableSource.Columns.Count], excelWorkSheet.Cells[_tableSource.Rows.Count, _tableSource.Columns.Count]);
                    title.EntireColumn.Delete(Type.Missing);
                }



                if (iLoad == 0 || iLoad == 3)
                {
                    Excel.Range a2 = (Excel.Range)excelWorkSheet.Cells[2, 1];
                    a2.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    title.Font.Size = 16;
                    title.Value2 = lblTitle.Text + " : " + date.ToString() + "\n" + sNX + "     " + sDC;
                    title.RowHeight = 80;
                    
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 1, 1, count_column);
                    title.RowHeight = 45;

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 3, 1, 3, count_column);
                    title.RowHeight = 15;
                }
                excelApplication.ActiveWindow.DisplayGridlines = true;
                excelWorkbook.Save();
                excelApplication.Visible = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch 
            {
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = false;
                excelApplication.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
        }

        private void InTheoThang(string path)
        {
            Excel.Application excelApplication = new Excel.Application();
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook;
            Excel.Worksheet excelWorkSheet;
            try
            {
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grvChung.RowCount + 11 + TCot - 4;
                gdMachine.ExportToXlsx(path);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                DataTable dtTmp = new DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                   " SELECT CASE WHEN " + Commons.Modules.TypeLanguage + "=0 " +
                       " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " +
                       " CASE WHEN " + Commons.Modules.TypeLanguage + "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,'Phone : ' + Phone + '. Fax : ' + Fax AS PHONE , EMAIL FROM THONG_TIN_CHUNG "));

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                int count_column = _tableSource.Columns.Count - (iLoad == 0 ? 1 : (Commons.Modules.sPrivate == "VIFON" ? 2 : 1));
                var n = 0;
                try
                {
                    n = _tableSource.AsEnumerable().Select(x => x.Field<string>("MS_N_XUONG")).Distinct().Count();
                }
                catch (Exception)
                {
                    n = 0;
                }
                int count_row = iLoad == 0 ? _tableSource.Rows.Count : _tableSource.Rows.Count + n;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //int count_row = _tableSource.Rows.Count;
                //huong sua gstr
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, iLoad == 0 ? 12 : Commons.Modules.sPrivate == "VIFON" ? 4 : 7]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, iLoad == 0 ? 12 : Commons.Modules.sPrivate == "VIFON" ? 4 : 7]);
                title.Merge(true);
                title.Font.Bold = true;
                //HUONG SUA 11 THÀNH 1
                title.Font.Size = iLoad == 0 ? 11 : 16;
                if (Commons.Modules.sPrivate == "VIFON")
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }
                else
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                }

                title.WrapText = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //huong sua gstr
                if (Commons.Modules.sPrivate == "VIFON")
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"];
                else
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"] + "\n" + dtTmp.Rows[0]["DIA_CHI"];// + "\n" + dtTmp.Rows[0]["PHONE"];


                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 13 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Font.Size = 16;
                if (Commons.Modules.sPrivate == "VIFON")
                    excelWorkSheet.Cells[1, iLoad == 0 ? 13 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8] = lblTitle.Text;
                else
                    excelWorkSheet.Cells[1, iLoad == 0 ? 13 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8] = lblTitle.Text + " : " + date.ToString() + "\n" + sNX + "     " + sDC;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                if (Commons.Modules.sPrivate != "VIFON") title.RowHeight = 80;


                //huong sua gstr
                //title = (Excel.Range)excelWorkSheet.Cells[2, iLoad == 0 ? 1 : 2];
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, (iLoad == 0 ? 3 : Commons.Modules.sPrivate == "VIFON" ? 4 : 7)]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                title.NumberFormat = "MM/yyy";
                title.Value2 = date;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, iLoad == 0 ? 4 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8], excelWorkSheet.Cells[2, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, iLoad == 0 ? "lblDatesofMantenance" : "lblNgayGS", Commons.Modules.TypeLanguage);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.Font.Size = 11;
                title.Font.Bold = true;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                excelWorkSheet.Columns.ColumnWidth = 3;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Range content = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 1], excelWorkSheet.Cells[count_row, 1]);
                content.ColumnWidth = iLoad == 0 ? 30 : 0;
                if (iLoad == 0)
                {
                    //Excel.Range content1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, count_column], excelWorkSheet.Cells[count_row, count_column]);
                    //content1.ColumnWidth = 5;

                    Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                    content2.EntireColumn.AutoFit();

                    Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                    content3.ColumnWidth = 10;
                }
                else
                {
                    if (iLoad == 3)
                    {
                        Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                        content2.ColumnWidth = 18;

                        Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                        content3.ColumnWidth = 25;

                        if (Commons.Modules.sPrivate == "VIFON")
                        {
                            Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                            content4.ColumnWidth = 8;

                            //Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                            //content5.ColumnWidth = 10;
                        }
                        else
                        {
                            Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                            content4.ColumnWidth = 30;

                            Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                            content5.ColumnWidth = 25;

                            Excel.Range content6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 6], excelWorkSheet.Cells[count_row, 6]);
                            content6.ColumnWidth = 8;

                            Excel.Range content7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 7], excelWorkSheet.Cells[count_row, 7]);
                            content7.ColumnWidth = 10;
                        }
                    }
                }

                //huong sua gstr
                Excel.Range backTitle = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, iLoad == 0 ? 1 : 2], excelWorkSheet.Cells[3, count_column]);
                backTitle.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 255, 204));
                int rowMaintaince = count_row + 5;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.Range r;
                Excel.Range CurCell = (Excel.Range)excelWorkSheet.get_Range("A1", "A1");
                //CurCell.RowHeight = 42;
                try
                {
                    GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                    excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 100, 42);
                    System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
                }
                catch (Exception)
                {
                }
                //huong sua
                if (iLoad == 0)
                {//ghi chu
                    int dong = 5;
                    int iCotMau = count_column;
                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 5;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 2;


                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 2];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][3]), Convert.ToInt16(_tableMaintaince.Rows[i][4]), Convert.ToInt16(_tableMaintaince.Rows[i][5])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 3], excelWorkSheet.Cells[dong, iCotMau + 3]);
                        r.Value2 = _tableMaintaince.Rows[i][2];
                        r.Merge(true);
                        dong += 1;
                    }
                }
                else if (Commons.Modules.sPrivate != "VIFON")
                {
                    int dong = 7;
                    int iCotMau = count_column;

                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 6;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 5;




                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 3];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][1]), Convert.ToInt16(_tableMaintaince.Rows[i][2]), Convert.ToInt16(_tableMaintaince.Rows[i][3])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 4], excelWorkSheet.Cells[dong, iCotMau + 6]);
                        r.Merge(true);
                        //r.Value2 = _tableMaintaince.Rows[k][2];

                        switch (Convert.ToInt32(_tableMaintaince.Rows[i][0]))
                        {
                            case 1: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNgay", Commons.Modules.TypeLanguage); break;
                            case 2: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTuan", Commons.Modules.TypeLanguage); break;
                            case 3: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTThang", Commons.Modules.TypeLanguage); break;
                            case 4: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNam", Commons.Modules.TypeLanguage); break;
                            default:
                                break;
                        }
                        dong += 1;
                    }
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                if (iLoad == 0)
                {//chu ky
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 1], excelWorkSheet.Cells[rowMaintaince, 8]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 1] = "Người Lập Phiếu";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 9], excelWorkSheet.Cells[rowMaintaince, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 9] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }

                else
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 2], excelWorkSheet.Cells[rowMaintaince, 2]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 2] = "Người Lập";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 3], excelWorkSheet.Cells[rowMaintaince, 6]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 3] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 7], excelWorkSheet.Cells[rowMaintaince, 3 + ((count_column) / 2)]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 7] = "Admin CMMS";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 4 + ((count_column) / 2)], excelWorkSheet.Cells[rowMaintaince, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 4 + ((count_column) / 2)] = "Giám Đốc Thiết Bị";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    //title.Borders.LineStyle = 1;
                    //title.Borders.Weight = 4;
                }


                // huong sua gstr
                if (iLoad == 3)
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
                    title.EntireRow.Delete(Type.Missing);
                }

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[4, 1]);
                title.MergeCells = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 255, 204));

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 2], excelWorkSheet.Cells[4, 2]);
                title.MergeCells = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 3], excelWorkSheet.Cells[4, 3]);
                title.MergeCells = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                if (iLoad == 3)
                {

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 4], excelWorkSheet.Cells[4, 4]);
                    title.MergeCells = true;
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;



                    if (Commons.Modules.sPrivate != "VIFON")
                    {

                        title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 5], excelWorkSheet.Cells[4, 5]);
                        title.MergeCells = true;
                        title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                        title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 6], excelWorkSheet.Cells[4, 6]);
                        title.MergeCells = true;
                        title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                        title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 7], excelWorkSheet.Cells[4, 7]);
                        title.MergeCells = true;
                        title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    }

                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                // huong sua gstr
                if (iLoad == 3)
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, Commons.Modules.sPrivate == "VIFON" ? 3 : 6], excelWorkSheet.Cells[4, count_column]);
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, _tableSource.Columns.Count], excelWorkSheet.Cells[_tableSource.Rows.Count, _tableSource.Columns.Count]);
                    title.EntireColumn.Delete(Type.Missing);
                }

                excelApplication.ActiveWindow.DisplayGridlines = true;
                excelWorkbook.Save();
                excelApplication.Visible = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch
            {
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = false;
                excelApplication.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
        }

        private void InTheoNamRIL(string path)
        {
            Excel.Application excelApplication = new Excel.Application();
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook;
            Excel.Worksheet excelWorkSheet;
            try
            {
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grv

                gdMachine.ExportToXlsx(path);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                DataTable dtTmp = new DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text," SELECT CASE WHEN " + Commons.Modules.TypeLanguage + "=0 " +
                    " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " +
                    " CASE WHEN " + Commons.Modules.TypeLanguage + "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,'Phone : ' + Phone + '. Fax : ' + Fax AS PHONE , EMAIL FROM THONG_TIN_CHUNG "));


                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;
                int Dong = 1;
                excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                // int count_column = _tableSource.Columns.Count - (Commons.Modules.sPrivate == "VIFON" ? 2 :1 );
                int count_column = _tableSource.Columns.Count - (iLoad == 0 ? 1 : (Commons.Modules.sPrivate == "VIFON" ? 2 : 1));

                //HUONG SUA GSTR
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                var n = 0;
                try
                {
                    n = _tableSource.AsEnumerable().Select(x => x.Field<string>("MS_N_XUONG")).Distinct().Count();
                }
                catch
                {
                    n = 0;
                }
                int count_row = iLoad == 0 ? _tableSource.Rows.Count : _tableSource.Rows.Count + n;
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);


                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, count_column-7]);
                title.Merge(true);
                title.Font.Bold = true;
                //title.Font.Size = iLoad == 0 ? 11 : 16;
                if (Commons.Modules.sPrivate == "VIFON")
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }
                else
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.WrapText = true;
                if (Commons.Modules.sPrivate == "VIFON")
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"];
                else
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"] + "\n" + dtTmp.Rows[0]["DIA_CHI"];// + "\n" + dtTmp.Rows[0]

                title.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (iLoad == 0 || iLoad == 3)
                {
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, count_column - 3], excelWorkSheet.Cells[1, count_column]);
                    title.Merge(true);
                    title.Font.Italic = true;
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    title.WrapText = true;
                    title.Font.Size = 9;
                    string stmp = "";
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "sSTLKHNam" + iLoad.ToString(), Commons.Modules.TypeLanguage);
                    stmp = stmp + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "sPhienBanKHNam" + iLoad.ToString(), Commons.Modules.TypeLanguage);
                    stmp = stmp + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "sNgayApDungKHNam" + iLoad.ToString(), Commons.Modules.TypeLanguage);

                    title.Value2 = stmp;


                    title.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;

                }



                //if (iLoad == 0) count_column = 14;
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 1, 1], excelWorkSheet.Cells[Dong + 1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Font.Size = 16;
                if (Commons.Modules.sPrivate == "VIFON")
                    title.Value2 = lblTitle.Text;
                else
                    title.Value2 = lblTitle.Text + "\n" + sNX + "     " + sDC;


                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                if (Commons.Modules.sPrivate != "VIFON") title.RowHeight = 80;
                //gstt
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, (iLoad == 0 ? 3 : Commons.Modules.sPrivate == "VIFON" ? 4 : 7)]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));

                title.Font.Size = 11;
                title.Value2 = date;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //gstt
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, (iLoad == 0 ? 4 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8)], excelWorkSheet.Cells[3, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, iLoad == 0 ? "lblDatesofMantenance" : "lblThangGS", Commons.Modules.TypeLanguage);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                title.Font.Size = 11;
                excelWorkSheet.Columns.ColumnWidth = 3;
                //gstt
                Excel.Range content = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 1], excelWorkSheet.Cells[count_row, (iLoad == 0 ? 1 : 5)]);
                content.ColumnWidth = (iLoad == 0 ? 30 : 0);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (iLoad == 3)
                {
                    Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                    content2.ColumnWidth = 18;

                    Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                    content3.ColumnWidth = 25;

                    if (Commons.Modules.sPrivate == "VIFON")
                    {
                        Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                        content4.ColumnWidth = 8;

                        //Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                        //content5.ColumnWidth = 10;
                    }
                    else
                    {
                        Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                        content4.ColumnWidth = 30;

                        Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                        content5.ColumnWidth = 25;

                        Excel.Range content6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 6], excelWorkSheet.Cells[count_row, 6]);
                        content6.ColumnWidth = 8;

                        Excel.Range content7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 7], excelWorkSheet.Cells[count_row, 7]);
                        content7.ColumnWidth = 10;
                    }
                }
                else
                {
                    Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                    content2.EntireColumn.AutoFit();

                    Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                    content3.ColumnWidth = 10;

                    Excel.Range content1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 15]);
                    content1.ColumnWidth = 8;
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Range backTitle = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
                backTitle.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 255, 204));
                //gstt
                int rowMaintaince = count_row + 6;
                Excel.Range r;
                Excel.Range CurCell = (Excel.Range)excelWorkSheet.get_Range("A1", "A1");
                CurCell.RowHeight = 42;
                try
                {
                    GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                    excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 100, 42);
                    System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
                }
                catch (Exception)
                {
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (iLoad == 0)
                {//ghi chú
                    int dong = 5;
                    int iCotMau = count_column;
                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 5;                    
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 2;

                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 2];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][3]), Convert.ToInt16(_tableMaintaince.Rows[i][4]), Convert.ToInt16(_tableMaintaince.Rows[i][5])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 3], excelWorkSheet.Cells[dong, iCotMau + 3]);
                        r.Value2 = _tableMaintaince.Rows[i][2];
                        r.Merge(true);
                        dong += 1;
                    }
                }
                else if (Commons.Modules.sPrivate != "VIFON")
                {
                    int dong = 6;
                    int iCotMau = count_column;
                    
                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 6;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 6;

                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 2];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][1]), Convert.ToInt16(_tableMaintaince.Rows[i][2]), Convert.ToInt16(_tableMaintaince.Rows[i][3])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 3], excelWorkSheet.Cells[dong, iCotMau + 5]);
                        r.Merge(true);
                        //r.Value2 = _tableMaintaince.Rows[k][2];

                        switch (Convert.ToInt32(_tableMaintaince.Rows[i][0]))
                        {
                            case 1: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNgay", Commons.Modules.TypeLanguage); break;
                            case 2: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTuan", Commons.Modules.TypeLanguage); break;
                            case 3: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTThang", Commons.Modules.TypeLanguage); break;
                            case 4: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNam", Commons.Modules.TypeLanguage); break;
                            default:
                                break;
                        }
                        dong += 1;
                    }
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //gstt
                rowMaintaince = count_row + 6;
                if (iLoad == 0)
                {//ký tên
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 1], excelWorkSheet.Cells[rowMaintaince, 4]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 1] = "Người Lập Phiếu";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 5], excelWorkSheet.Cells[rowMaintaince, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 5] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                }
                else
                {

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 2], excelWorkSheet.Cells[rowMaintaince, 2]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 2] = "Người Lập";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 3], excelWorkSheet.Cells[rowMaintaince, 4]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 3] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 5], excelWorkSheet.Cells[rowMaintaince, 10]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 5] = "Admin CMMS";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 11], excelWorkSheet.Cells[rowMaintaince, (Commons.Modules.sPrivate == "VIFON" ? 16 : 19)]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 11] = "Giám Đốc Thiết Bị";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 7], excelWorkSheet.Cells[1, count_column]);
                title.ColumnWidth = 7;


                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 6], excelWorkSheet.Cells[1, 6]);
                title.ColumnWidth = 8;

                excelApplication.ActiveWindow.DisplayGridlines = true;
                excelWorkbook.Save();
                excelApplication.Visible = true;

                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch
            {
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = false;
                excelApplication.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
        }

        private void InTheoNam(string path)
        {
            Excel.Application excelApplication = new Excel.Application();
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook;
            Excel.Worksheet excelWorkSheet;
            try
            {
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grv

                gdMachine.ExportToXlsx(path);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                DataTable dtTmp = new DataTable();
                dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, " SELECT CASE WHEN " + Commons.Modules.TypeLanguage + "=0 " +
                    " THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CTY,LOGO, " +
                    " CASE WHEN " + Commons.Modules.TypeLanguage + "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH  END AS DIA_CHI,'Phone : ' + Phone + '. Fax : ' + Fax AS PHONE , EMAIL FROM THONG_TIN_CHUNG "));


                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;
                int Dong = 1;
                excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                // int count_column = _tableSource.Columns.Count - (Commons.Modules.sPrivate == "VIFON" ? 2 :1 );
                int count_column = _tableSource.Columns.Count - (iLoad == 0 ? 1 : (Commons.Modules.sPrivate == "VIFON" ? 2 : 1));

                //HUONG SUA GSTR
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                var n = 0;
                try
                {
                    n = _tableSource.AsEnumerable().Select(x => x.Field<string>("MS_N_XUONG")).Distinct().Count();
                }
                catch
                {
                    n = 0;
                }
                int count_row = iLoad == 0 ? _tableSource.Rows.Count : _tableSource.Rows.Count + n;
                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, count_column]);
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, iLoad == 0 ? 2 : 3], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.Font.Size = iLoad == 0 ? 11 : 16;
                if (Commons.Modules.sPrivate == "VIFON")
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }
                else
                {
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.WrapText = true;
                if (Commons.Modules.sPrivate == "VIFON")
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"];
                else
                    title.Value2 = dtTmp.Rows[0]["TEN_CTY"] + "\n" + dtTmp.Rows[0]["DIA_CHI"];// + "\n" + dtTmp.Rows[0]
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                //if (iLoad == 0) count_column = 14;
                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 1, 1], excelWorkSheet.Cells[Dong + 1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Font.Size = 16;
                if (Commons.Modules.sPrivate == "VIFON")
                    title.Value2 = lblTitle.Text;
                else
                    title.Value2 = lblTitle.Text + "\n" + sNX + "     " + sDC;


                a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                if (Commons.Modules.sPrivate != "VIFON") title.RowHeight = 80;
                //gstt
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, (iLoad == 0 ? 3 : Commons.Modules.sPrivate == "VIFON" ? 4 : 7)]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));

                title.Font.Size = 11;
                title.Value2 = date;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //gstt
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, (iLoad == 0 ? 4 : Commons.Modules.sPrivate == "VIFON" ? 5 : 8)], excelWorkSheet.Cells[3, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                title.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, iLoad == 0 ? "lblDatesofMantenance" : "lblThangGS", Commons.Modules.TypeLanguage);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 51, 0));
                title.Font.Size = 11;
                excelWorkSheet.Columns.ColumnWidth = 3;
                //gstt
                Excel.Range content = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 1], excelWorkSheet.Cells[count_row, (iLoad == 0 ? 1 : 5)]);
                content.ColumnWidth = (iLoad == 0 ? 30 : 0);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (iLoad == 3)
                {
                    Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                    content2.ColumnWidth = 18;

                    Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                    content3.ColumnWidth = 25;

                    if (Commons.Modules.sPrivate == "VIFON")
                    {
                        Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                        content4.ColumnWidth = 8;

                        //Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                        //content5.ColumnWidth = 10;
                    }
                    else
                    {
                        Excel.Range content4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 4]);
                        content4.ColumnWidth = 30;

                        Excel.Range content5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 5], excelWorkSheet.Cells[count_row, 5]);
                        content5.ColumnWidth = 25;

                        Excel.Range content6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 6], excelWorkSheet.Cells[count_row, 6]);
                        content6.ColumnWidth = 8;

                        Excel.Range content7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 7], excelWorkSheet.Cells[count_row, 7]);
                        content7.ColumnWidth = 10;
                    }
                }
                else
                {
                    Excel.Range content2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 2], excelWorkSheet.Cells[count_row, 2]);
                    content2.EntireColumn.AutoFit();

                    Excel.Range content3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 3], excelWorkSheet.Cells[count_row, 3]);
                    content3.ColumnWidth = 10;

                    Excel.Range content1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row, 4], excelWorkSheet.Cells[count_row, 15]);
                    content1.ColumnWidth = 8;
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Range backTitle = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
                backTitle.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(204, 255, 204));
                //gstt
                int rowMaintaince = count_row + 6;
                Excel.Range r;
                Excel.Range CurCell = (Excel.Range)excelWorkSheet.get_Range("A1", "A1");
                CurCell.RowHeight = 42;
                try
                {
                    GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                    excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 100, 42);
                    System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
                }
                catch (Exception)
                {
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (iLoad == 0)
                {//ghi chú
                    int dong = 5;
                    int iCotMau = count_column;
                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 5;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 2;

                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 2];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][3]), Convert.ToInt16(_tableMaintaince.Rows[i][4]), Convert.ToInt16(_tableMaintaince.Rows[i][5])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 3], excelWorkSheet.Cells[dong, iCotMau + 3]);
                        r.Value2 = _tableMaintaince.Rows[i][2];
                        r.Merge(true);
                        dong += 1;
                    }
                }
                else if (Commons.Modules.sPrivate != "VIFON")
                {
                    int dong = 6;
                    int iCotMau = count_column;

                    if (Commons.Modules.sPrivate == "REMINGTON") dong = rowMaintaince + 6;
                    if (Commons.Modules.sPrivate == "REMINGTON") iCotMau = 6;

                    for (int i = 0; i < _tableMaintaince.Rows.Count; i++)
                    {
                        r = (Excel.Range)excelWorkSheet.Cells[dong, iCotMau + 2];
                        r.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(Convert.ToInt16(_tableMaintaince.Rows[i][1]), Convert.ToInt16(_tableMaintaince.Rows[i][2]), Convert.ToInt16(_tableMaintaince.Rows[i][3])));
                        r = excelWorkSheet.get_Range(excelWorkSheet.Cells[dong, iCotMau + 3], excelWorkSheet.Cells[dong, iCotMau + 5]);
                        r.Merge(true);
                        //r.Value2 = _tableMaintaince.Rows[k][2];

                        switch (Convert.ToInt32(_tableMaintaince.Rows[i][0]))
                        {
                            case 1: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNgay", Commons.Modules.TypeLanguage); break;
                            case 2: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTuan", Commons.Modules.TypeLanguage); break;
                            case 3: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblTThang", Commons.Modules.TypeLanguage); break;
                            case 4: r.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", "lblNam", Commons.Modules.TypeLanguage); break;
                            default:
                                break;
                        }
                        dong += 1;
                    }
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //gstt
                rowMaintaince = count_row + 6;
                if (iLoad == 0)
                {//ký tên
                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 1], excelWorkSheet.Cells[rowMaintaince, 4]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 1] = "Người Lập Phiếu";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 5], excelWorkSheet.Cells[rowMaintaince, count_column]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 5] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                }
                else
                {

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 2], excelWorkSheet.Cells[rowMaintaince, 2]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 2] = "Người Lập";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 3], excelWorkSheet.Cells[rowMaintaince, 4]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 3] = "Trưởng Bộ Phận";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 5], excelWorkSheet.Cells[rowMaintaince, 10]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 5] = "Admin CMMS";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[rowMaintaince, 11], excelWorkSheet.Cells[rowMaintaince, (Commons.Modules.sPrivate == "VIFON" ? 16 : 19)]);
                    title.Merge(true);
                    title.Font.Bold = true;
                    excelWorkSheet.Cells[rowMaintaince, 11] = "Giám Đốc Thiết Bị";
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                    title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
                    title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 6], excelWorkSheet.Cells[1, 6]);
                title.ColumnWidth = 8;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                excelApplication.ActiveWindow.DisplayGridlines = true;
                excelWorkbook.Save();
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch
            {
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = false;
                excelApplication.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
        }

        private void TKiemColgate()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)gdMachine.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " [Machine Name] LIKE '%" + txtTKiem.Text + "%' ";
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }

        }

        private void TKiemGS()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)gdMachine.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " [MS_MAY] LIKE '%" + txtTKiem.Text + "%' ";
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }

        }

        private void TKiemBangKe()
        {

            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)gdMachine.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " NGAY_LAP LIKE '%" + txtTKiem.Text + "%' OR MS_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' OR TEN_TINH_TRANG LIKE '%" + txtTKiem.Text + "%' OR NGUON_DL LIKE '%" + txtTKiem.Text + "%' OR MS_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR MS_N_XUONG LIKE '%" + txtTKiem.Text + "%'  OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR MS_HE_THONG LIKE '% " + txtTKiem.Text + "%' OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' OR MS_BP_CHIU_PHI LIKE '%" + txtTKiem.Text + "%' OR TEN_BP_CHIU_PHI LIKE '%" + txtTKiem.Text + "%'  OR MS_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTKiem.Text + "%' OR MS_LOAI_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_MAY LIKE '%" + txtTKiem.Text + "%' OR MS_BO_PHAN LIKE '%" + txtTKiem.Text + "%'  OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR MS_HE_THONG LIKE '% " + txtTKiem.Text + "%' OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' OR MS_BP_CHIU_PHI LIKE '%" + txtTKiem.Text + "%' OR TEN_BO_PHAN LIKE '%" + txtTKiem.Text + "%' OR LOAI_CV LIKE '%" + txtTKiem.Text + "%' OR TEN_CV LIKE '%" + txtTKiem.Text + "%'  ";
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }

        }

        #endregion
        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (iLoad == 0) TKiemColgate();
            else
                if (iLoad == 3)
            {
                TKiemGS();
            }
            else
                TKiemBangKe();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            switch (iLoad)
            {
                case 0:
                case 3:
                    ExecuteColgate();
                    break;
                case 1:
                case 2:
                    ExecuteBangKe();
                    break;
                default:
                    ExecuteColgate();
                    break;
            }
        }
        #region "Bang Ke"
        private void ExecuteBangKe()
        {
            try
            {
                this.Cursor = Cursors.Default;
                DataTable dt = new DataTable();
                dt = _tableSource.Clone();
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dt, false, true, true, true, true, sBC);
                if (iLoad == 1) InDuLieuPBT(_tableSource); else InDuLieuTGNM(_tableSource);

            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }

            this.Cursor = Cursors.Default;
        }

        private void LoadBangKe()
        {
            this.Name = sBC;
            if (iLoad == 2)
            {
                gridView1.OptionsCustomization.AllowGroup = false;
                gridView1.OptionsCustomization.AllowSort = false;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(gdMachine, gridView1, _tableSource, false, true, false, true, true, sBC);
            if (iLoad == 1)
            {
                gridView1.OptionsCustomization.AllowGroup = true;
                gridView1.OptionsCustomization.AllowSort = true;
                gridView1.Columns["NGAY_LAP"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["MS_PHIEU_BAO_TRI"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["TEN_TINH_TRANG"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["TEN_LOAI_BT"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["MS_N_XUONG"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["Ten_N_XUONG"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["MS_HE_THONG"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["TEN_HE_THONG"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;

                gridView1.Columns["MS_BP_CHIU_PHI"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["TEN_BP_CHIU_PHI"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["MS_MAY"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["TEN_MAY"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["MS_LOAI_MAY"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["TEN_LOAI_MAY"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;

                gridView1.Columns["MS_BO_PHAN"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["LOAI_CV"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
                gridView1.Columns["TEN_CV"].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;

                RepositoryItemTextEdit rNLap = new RepositoryItemTextEdit();
                rNLap.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                rNLap.Mask.UseMaskAsDisplayFormat = true;
                rNLap.Mask.EditMask = "dd/MM/yyyy";
                gridView1.Columns["NGAY_LAP"].ColumnEdit = rNLap;

                RepositoryItemTextEdit NGAY_BD_KH = new RepositoryItemTextEdit();
                NGAY_BD_KH.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                NGAY_BD_KH.Mask.UseMaskAsDisplayFormat = true;
                NGAY_BD_KH.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
                gridView1.Columns["NGAY_BD_KH"].ColumnEdit = NGAY_BD_KH;

                RepositoryItemTextEdit rNGAY_KT_KH = new RepositoryItemTextEdit();
                rNGAY_KT_KH.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                rNGAY_KT_KH.Mask.UseMaskAsDisplayFormat = true;
                rNGAY_KT_KH.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
                gridView1.Columns["NGAY_KT_KH"].ColumnEdit = rNGAY_KT_KH;

                RepositoryItemTextEdit rNGAY_BD_TT = new RepositoryItemTextEdit();
                rNGAY_BD_TT.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                rNGAY_BD_TT.Mask.UseMaskAsDisplayFormat = true;
                rNGAY_BD_TT.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
                gridView1.Columns["NGAY_BD_TT"].ColumnEdit = rNGAY_BD_TT;

                RepositoryItemTextEdit rNGAY_KT_TT = new RepositoryItemTextEdit();
                rNGAY_KT_TT.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                rNGAY_KT_TT.Mask.UseMaskAsDisplayFormat = true;
                rNGAY_KT_TT.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
                gridView1.Columns["NGAY_KT_TT"].ColumnEdit = rNGAY_KT_TT;

                RepositoryItemTextEdit NGAY_NGHIEM_THU = new RepositoryItemTextEdit();
                NGAY_NGHIEM_THU.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                NGAY_NGHIEM_THU.Mask.UseMaskAsDisplayFormat = true;
                NGAY_NGHIEM_THU.Mask.EditMask = "dd/MM/yyyy";
                gridView1.Columns["NGAY_NGHIEM_THU"].ColumnEdit = NGAY_NGHIEM_THU;

                string sDinhDang = "";
                if (Commons.Modules.iPBTTheoGio == 0)
                    sDinhDang = "N2";
                else
                    sDinhDang = "N";


                RepositoryItemTextEdit rTONG_TG_NM = new RepositoryItemTextEdit();
                rTONG_TG_NM.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                rTONG_TG_NM.Mask.UseMaskAsDisplayFormat = true;
                rTONG_TG_NM.Mask.EditMask = sDinhDang;
                gridView1.Columns["TONG_TG_NM"].ColumnEdit = rTONG_TG_NM;

                RepositoryItemTextEdit rTG_KT = new RepositoryItemTextEdit();
                rTG_KT.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                rTG_KT.Mask.UseMaskAsDisplayFormat = true;
                rTG_KT.Mask.EditMask = sDinhDang;
                gridView1.Columns["TG_KT"].ColumnEdit = rTG_KT;

                RepositoryItemTextEdit TG_CK = new RepositoryItemTextEdit();
                TG_CK.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                TG_CK.Mask.UseMaskAsDisplayFormat = true;
                TG_CK.Mask.EditMask = sDinhDang;
                gridView1.Columns["TG_CK"].ColumnEdit = TG_CK;

                RepositoryItemTextEdit TG_LVT = new RepositoryItemTextEdit();
                TG_LVT.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                TG_LVT.Mask.UseMaskAsDisplayFormat = true;
                TG_LVT.Mask.EditMask = sDinhDang;
                gridView1.Columns["TG_LVT"].ColumnEdit = TG_LVT;

                RepositoryItemTextEdit TG_SC = new RepositoryItemTextEdit();
                TG_SC.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                TG_SC.Mask.UseMaskAsDisplayFormat = true;
                TG_SC.Mask.EditMask = sDinhDang;
                gridView1.Columns["TG_SC"].ColumnEdit = TG_SC;

                RepositoryItemTextEdit TG_CCL = new RepositoryItemTextEdit();
                TG_CCL.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                TG_CCL.Mask.UseMaskAsDisplayFormat = true;
                TG_CCL.Mask.EditMask = sDinhDang;
                gridView1.Columns["TG_CCL"].ColumnEdit = TG_CCL;

                RepositoryItemTextEdit TG_S = new RepositoryItemTextEdit();
                TG_S.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                TG_S.Mask.UseMaskAsDisplayFormat = true;
                TG_S.Mask.EditMask = sDinhDang;
                gridView1.Columns["TG_S"].ColumnEdit = TG_S;

                RepositoryItemTextEdit TY_LE = new RepositoryItemTextEdit();
                TY_LE.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                TY_LE.Mask.UseMaskAsDisplayFormat = true;
                TY_LE.Mask.EditMask = "p";
                gridView1.Columns["TY_LE"].ColumnEdit = TY_LE;


                RepositoryItemTextEdit CHI_PHI_PHU_TUNG = new RepositoryItemTextEdit();
                CHI_PHI_PHU_TUNG.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                CHI_PHI_PHU_TUNG.Mask.UseMaskAsDisplayFormat = true;
                CHI_PHI_PHU_TUNG.Mask.EditMask = sDinhDang;
                gridView1.Columns["CHI_PHI_PHU_TUNG"].ColumnEdit = CHI_PHI_PHU_TUNG;

                RepositoryItemTextEdit CHI_PHI_VAT_TU = new RepositoryItemTextEdit();
                CHI_PHI_VAT_TU.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                CHI_PHI_VAT_TU.Mask.UseMaskAsDisplayFormat = true;
                CHI_PHI_VAT_TU.Mask.EditMask = sDinhDang;
                gridView1.Columns["CHI_PHI_VAT_TU"].ColumnEdit = CHI_PHI_VAT_TU;

                RepositoryItemTextEdit CHI_PHI_NHAN_CONG = new RepositoryItemTextEdit();
                CHI_PHI_NHAN_CONG.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                CHI_PHI_NHAN_CONG.Mask.UseMaskAsDisplayFormat = true;
                CHI_PHI_NHAN_CONG.Mask.EditMask = sDinhDang;
                gridView1.Columns["CHI_PHI_NHAN_CONG"].ColumnEdit = CHI_PHI_NHAN_CONG;

                RepositoryItemTextEdit CHI_PHI_DV = new RepositoryItemTextEdit();
                CHI_PHI_DV.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                CHI_PHI_DV.Mask.UseMaskAsDisplayFormat = true;
                CHI_PHI_DV.Mask.EditMask = sDinhDang;
                gridView1.Columns["CHI_PHI_DV"].ColumnEdit = CHI_PHI_DV;

                RepositoryItemTextEdit CHI_PHI_KHAC = new RepositoryItemTextEdit();
                CHI_PHI_KHAC.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                CHI_PHI_KHAC.Mask.UseMaskAsDisplayFormat = true;
                CHI_PHI_KHAC.Mask.EditMask = sDinhDang;
                gridView1.Columns["CHI_PHI_KHAC"].ColumnEdit = CHI_PHI_KHAC;

                RepositoryItemTextEdit TONG = new RepositoryItemTextEdit();
                TONG.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                TONG.Mask.UseMaskAsDisplayFormat = true;
                TONG.Mask.EditMask = sDinhDang;
                gridView1.Columns["TONG"].ColumnEdit = TONG;

            }
            else
            {

                gridView1.OptionsView.ShowGroupPanel = false;
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void InDuLieuPBT(DataTable dtTmp)
        {
            string sPath = "";
            string sDinhDang = "";
            if (Commons.Modules.iPBTTheoGio == 0)
                sDinhDang = "#,##0.00";
            else
                sDinhDang = "#,##0";

            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            if (sPath == "") return;


            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            try
            {

                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 23;
                prbIN.Properties.Minimum = 0;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                grvChung.ExportToXlsx(sPath);
                int TCot = dtTmp.Columns.Count;
                int TDong = dtTmp.Rows.Count;


                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (Commons.Modules.bDoiFontReport)
                    xlApp.Cells.Font.Name = Commons.Modules.sFontReport;


                Excel.Range title;
                TDong = TDong + 2;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, TDong, TCot);
                title.Borders.LineStyle = 1;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, 1], xlWorkSheet.Cells[Dong + 1, 1]).Interior.Color;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                #region Dinh Dang
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3, "##", true, 3, 1, TDong + 6, 1);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 2, TDong + 6, 2);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                title.NumberFormat = "dd/MM/yyyy";
                title.ColumnWidth = 12;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 3, TDong + 6, 21);
                title.NumberFormat = "@";

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, sDinhDang, true, 3, 22, TDong + 6, 24);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 25, TDong + 6, 26);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                title.NumberFormat = "dd/MM/yyyy HH:mm:ss";
                title.ColumnWidth = 12;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, sDinhDang, true, 3, 27, TDong + 6, 29);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 30, TDong + 6, 32);
                title.NumberFormat = "@";
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 33, TDong + 6, 34);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                title.NumberFormat = "dd/MM/yyyy HH:mm:ss";
                title.ColumnWidth = 12;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, sDinhDang, true, 3, 35, TDong + 6, 41);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 42, TDong + 6, 43);
                title.NumberFormat = "@";
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 44, TDong + 6, 44);
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                title.NumberFormat = "dd/MM/yyyy";
                title.ColumnWidth = 12;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 45, TDong + 6, 48);
                title.NumberFormat = "@";

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, "0%", true, 3, 49, TDong + 6, 49);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, sDinhDang, true, 3, 50, TDong + 6, 55);

                #endregion
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 2, 1, TDong, dtTmp.Columns.Count);
                Commons.Modules.MExcel.MExportExcel(dtTmp, xlWorkSheet, title);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion




                ((Excel.Range)xlWorkSheet.Rows[2, Type.Missing]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                xlWorkSheet.Columns.AutoFit();
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlWorkSheet.Rows.AutoFit();
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlApp.ActiveWindow.DisplayGridlines = true;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 3, 1);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "bcTieuDe", Commons.Modules.TypeLanguage), 2, 1, "@", 15, true);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, TCot);
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 1, 3, 1);
                title.RowHeight = 9;

                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, "0%", true, 1, 41, TDong, 41);
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 6, "##", true, 5, 1, TDong+4, 1);





                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 2, TDong + 4, TCot + 2);
                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 22, TDong + 4, 24);
                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //title.NumberFormat = sDinhDang;
                //title.ColumnWidth = 20;

                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 25, TDong + 4, 26);
                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 27, TDong + 4, 31);
                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //title.NumberFormat = sDinhDang;
                //title.ColumnWidth = 17;


                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 35, TDong + 4, 36);
                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 45, TDong + 4, 50);
                //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //title.NumberFormat = sDinhDang;
                //title.ColumnWidth = 12;
                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, sDinhDang, true, 1, 27, TDong, 28);

                //Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, "0%", true, 5, 44, TDong+4, 44);

                xlWorkBook.Save();
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
        }
        private void InDuLieuTGNM(DataTable dtTmp)
        {
            string sPath = "";
            string sDinhDang = "";
            if (Commons.Modules.iPBTTheoGio == 0)
                sDinhDang = "#,##0.00";
            else
                sDinhDang = "#,##0";

            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            if (sPath == "") return;


            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            try
            {
                int TCot = dtTmp.Columns.Count;
                int TDong = dtTmp.Rows.Count;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 23;
                prbIN.Properties.Minimum = 0;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                grvChung.ExportToXlsx(sPath);



                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlWorkSheet.Name = "BCChiTiet";

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (Commons.Modules.bDoiFontReport)
                    xlApp.Cells.Font.Name = Commons.Modules.sFontReport;


                Excel.Range title;
                TDong = TDong + 2;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, TDong, TCot);
                title.Borders.LineStyle = 1;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, 1], xlWorkSheet.Cells[Dong + 1, 1]).Interior.Color;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                #region Dinh Dang
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, "##", true, 1, 1, TDong, 1);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 2, TDong, 24);
                title.NumberFormat = "@";

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                //////////title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 4, TDong, 4);
                //////////title.ColumnWidth = 12;
                //////////title.NumberFormat = "@"; //System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;                
                //////////title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                //////////title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 5, TDong, 6);
                //////////title.ColumnWidth = 12;
                ////////////title.NumberFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                //////////title.NumberFormat = "@";
                //////////title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, sDinhDang, true, 1, 9, TDong, 10);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 40, sDinhDang, true, 1, 11, TDong, 11);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 40, sDinhDang, true, 1, 13, TDong, 13);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 2, 1, TDong, dtTmp.Columns.Count);
                Commons.Modules.MExcel.MExportExcel(dtTmp, xlWorkSheet, title);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                ((Excel.Range)xlWorkSheet.Rows[2, Type.Missing]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                xlWorkSheet.Columns.AutoFit();

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                xlWorkSheet.Rows.AutoFit();

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, sDinhDang, true, 1, 9, TDong, 10);


                xlApp.ActiveWindow.DisplayGridlines = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 3, 1);
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "bcTieuDeTGNM", Commons.Modules.TypeLanguage), 2, 1, "@", 15, true);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 4, 1, 4, TCot);
                title.Font.Bold = true;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 3, 1, 3, 1);
                title.RowHeight = 9;

                xlWorkBook.Save();
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
        }

        #endregion

    }
}