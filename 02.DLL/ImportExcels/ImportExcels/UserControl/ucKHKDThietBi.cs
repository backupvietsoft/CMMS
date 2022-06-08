using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;


namespace ImportExcels.UserControl
{
    public partial class ucKHKDThietBi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKHKDThietBi()
        {
            InitializeComponent();
        }

        private void ucKHKDThietBi_Load(object sender, EventArgs e)
        {
            try
            {
                datFromDate.DateTime = DateTime.Now.Date;
                datToDate.DateTime = Convert.ToDateTime("31/12/" + DateTime.Now.Year);
                LoadKho();
                grvDL.Columns[0].Width = 90;
                grvDL.Columns[1].Width = 400;
                grvDL.Columns[2].Width = 100;
                grvDL.Columns[3].Width = 250;
                grvDL.Columns[4].Width = 250;
            }
            catch { }
        }
        private void LoadKho()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbKho, Commons.Modules.ObjSystems.MLoadDataNhaXuong(1, "-1", "-1", "-1"), "MS_N_XUONG", "TEN_N_XUONG", "");
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (grvDL.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKDThietBi", "KhongCoDulieu", Commons.Modules.TypeLanguage));
                return;
            }

            Excel.Application excelApplication = new Excel.Application();
            try
            {
                SaveFileDialog f = new SaveFileDialog();
                string path = "";
                f.Filter = "Excel file (*.xls)|*.xls";
                try
                {
                    DialogResult res = f.ShowDialog();
                    if (res.Equals(DialogResult.OK))
                    {
                        path = f.FileName;

                    }
                    else
                        return;
                }
                catch
                {

                }
                this.Cursor = Cursors.WaitCursor;
                grdDuLieu.ExportToXls(path);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                excelApplication.Visible = false;
                excelApplication.Visible = true;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                int count_column = grvDL.Columns.Count; //_tableHCKD.Columns.Count;
                int count_row = grvDL.RowCount; //_tableHCKD.Rows.Count;



                Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
                //for (cot = 3; cot < _tableCost.Columns.Count + 1; cot++)
                for (int i = 1; i <= 8; i++)
                {
                    a1.EntireRow.Insert(Excel.Constants.xlTop);
                }
                //tao tieu de

                Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, 2]);
                title.Merge(true);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                string sTenCty = "";
                sTenCty = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 TEN_CTY_TIENG_VIET FROM  THONG_TIN_CHUNG"));

                excelWorkSheet.Cells[1, 1] = sTenCty;//Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKDThietBi", "TongCongTyCapNuocSaiGon", Commons.Modules.TypeLanguage);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[count_row + 15, count_column]);
                title.Font.Name = "Tahoma";
                title.Font.Size = 12;


                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 4], excelWorkSheet.Cells[1, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[1, 4] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKDThietBi", 
                            "CongHoaXaHoiChuNghiaVietnam", Commons.Modules.TypeLanguage);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, 2]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[2, 1] = cmbKho.Text.Replace("<","").Replace(">","").Trim(); //Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKDThietBi", "NhaMayNuocThuDuc", Commons.Modules.TypeLanguage);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 4], excelWorkSheet.Cells[2, count_column]);
                title.Merge(true);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[2, 4] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKDThietBi", 
                            "DoclapTuDoHanhPhuc", Commons.Modules.TypeLanguage);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 4], excelWorkSheet.Cells[4, count_column]);
                title.Merge(true);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[4, 4] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHKDThietBi", "TPHCMNgay", Commons.Modules.TypeLanguage) + DateTime.Now.Date.Day + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHKDThietBi", "Thang", Commons.Modules.TypeLanguage) + DateTime.Now.Date.Month + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucKHKDThietBi", "Nam", Commons.Modules.TypeLanguage) + DateTime.Now.Date.Year;

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.Font.Size = 14; 
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[6, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKDThietBi", 
                            "DanhsachMayMocThietBi", Commons.Modules.TypeLanguage);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.Font.Size = 14; 
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[7, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKDThietBi", 
                            "PhaiDuocKiemDinhDinhKy", Commons.Modules.TypeLanguage);


                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 11, 1], excelWorkSheet.Cells[count_row + 11, 2]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[count_row + 11, 1] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKDThietBi", "Duyet", Commons.Modules.TypeLanguage);

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 11, 4], excelWorkSheet.Cells[count_row + 11, count_column]);
                title.Merge(true);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                excelWorkSheet.Cells[count_row + 11, 4] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKDThietBi", "NguoiLap", Commons.Modules.TypeLanguage);

 
                excelWorkSheet.Columns.AutoFit();
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
                title.RowHeight = 8;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
                title.RowHeight = 8;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 1], excelWorkSheet.Cells[8, count_column]);
                title.RowHeight = 8;
                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[count_row + 10, 1], excelWorkSheet.Cells[count_row + 10, count_column]);
                title.RowHeight = 8;

                excelWorkSheet.PageSetup.TopMargin = 0.25;
                excelWorkSheet.PageSetup.LeftMargin = 0.25;
                excelWorkSheet.PageSetup.RightMargin = 0.25;
                excelWorkSheet.PageSetup.BottomMargin = 0.25;

                excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 2], excelWorkSheet.Cells[1, 2]);
                title.ColumnWidth = 34;

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 3], excelWorkSheet.Cells[1, 3]);
                title.ColumnWidth = 50;

                title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 6], excelWorkSheet.Cells[1,6]);
                title.ColumnWidth = 22;
                excelWorkSheet.Rows.AutoFit();
                excelWorkSheet.PageSetup.PrintTitleRows = "$9:$9";

                //excelWorkSheet.PageSetup.PrintTitleRows = "$9:$9";

                excelApplication.ActiveWindow.DisplayGridlines = true;
                
                
                this.Cursor = Cursors.Default;
                excelWorkbook.Save();
                excelApplication.Visible = true;
            }
            catch
            {
                excelApplication.Visible = true;
                excelApplication.Quit();
                this.Cursor = Cursors.Default;
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKDThietBi", 
                    "XuatKhongThanhCong", Commons.Modules.TypeLanguage));
                

            }

        }

        private void cmbKho_EditValueChanged(object sender, EventArgs e)
        {
            LoadLuoi();        
        }

        private void datFromDate_EditValueChanged(object sender, EventArgs e)
        {
            LoadLuoi();
        }
        private void LoadLuoi()
        {
            try
            {
                if (datFromDate.Text == "") return;
                if (datToDate.Text == "") return;
                if (string.IsNullOrEmpty(cmbKho.Text) == true) return;


                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MashjGetKHKDThietBi",Commons.Modules.UserName,
                            cmbKho.EditValue.ToString(), datFromDate.Text, datToDate.Text));
                grdDuLieu.DataSource = _table;
                grvDL.OptionsView.ColumnAutoWidth = true;
                grvDL.OptionsView.AllowHtmlDrawHeaders = true;
                grvDL.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            }
            catch { }
        }

        private void datToDate_EditValueChanged(object sender, EventArgs e)
        {
            LoadLuoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
