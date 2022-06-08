using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using Microsoft.ApplicationBlocks.Data;

namespace ExportExcels
{
    public partial class frmIncidents : DevExpress.XtraEditors.XtraForm
    {
        GridControl grid = new GridControl();
        DataTable _table1 = new DataTable();
        public DateTime _tu_ngay, _den_ngay;
        public string tinh,quan,loai_may, nhom_may;
        public string _date, _city, _district, _cat,_group;
        public frmIncidents()
        {
            InitializeComponent();
        }
        private void frmIncidents_Load(object sender, EventArgs e)
        {
            LoadData();
            btnExport.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "btnExport", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "btnExit", Commons.Modules.TypeLanguage);
        }
        private void LoadData()
        {
          
            DataTable _table = new DataTable();
            DataTable _table_amount = new DataTable();
            grid.Dock = DockStyle.Fill;
            grid.Visible = true;
            tableLayoutPanel1.Controls.Add(grid, 1, 0);
            tableLayoutPanel1.SetColumnSpan(grid, 4);
           
            grid.Visible = true;

            DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            gridView.BeginInit();
            grid.MainView = gridView;

            gridView.OptionsBehavior.Editable = false;
            grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });

            gridView.Columns.Clear();
           
          
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_INCIDENTS", _tu_ngay, _den_ngay,loai_may,nhom_may,tinh,quan));
            _table1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_GROUP_MACHINE_REPORT", loai_may,nhom_may));

            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandNo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();

            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBandNo });

            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();

            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand2 });
            gridView.OptionsBehavior.Editable = false;

           

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn column6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            column6.OptionsColumn.AllowMove = false;
            column6.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "NhomMay", Commons.Modules.TypeLanguage);
            column6.Name = "NM";
            column6.FieldName = "TEN_NHOM_MAY";
            
            column6.AppearanceHeader.Options.UseTextOptions = true;
            column6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            column6.AppearanceHeader.TextOptions.VAlignment=DevExpress.Utils.VertAlignment.Center;
            column6.Visible = true;
            gridBand2.Columns.Add(column6);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn columnNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            columnNo.OptionsColumn.AllowMove = false;
            columnNo.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "NO", Commons.Modules.TypeLanguage);
            columnNo.Name = "NO";
            columnNo.FieldName = "NO";
            columnNo.AppearanceHeader.Options.UseTextOptions = true;
            columnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            columnNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            columnNo.Visible = true;
            gridBandNo.Columns.Add(columnNo);

            int sl = 0;
                for (DateTime t = _tu_ngay; t <= _den_ngay; t.AddMonths(1))
                {
                  
                    _table1.Columns.Add("SL_May" + t.Month + "" + t.Year,System.Type.GetType("System.Int32"));

                    _table1.Columns.Add("SL_SU_CO" + t.Month + "" + t.Year, System.Type.GetType("System.Int32"));

                    _table1.Columns.Add("SL_BAO_TRI" + t.Month + "" + t.Year, System.Type.GetType("System.Int32"));
                    _table1.Columns.Add("TI_LE_SU_CO" + t.Month + "" + t.Year, System.Type.GetType("System.Double"));
                    _table1.Columns.Add("TI_LE_BAO_TRI" + t.Month + "" + t.Year, System.Type.GetType("System.Double"));
                  
                    foreach (DataRow row in _table1.Rows)
                    {

                        sl = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_AMOUNT_INCIDENT", t, row["MS_NHOM_MAY"], tinh, quan,"-1"));
                        row["SL_May" + t.Month + "" + t.Year] = sl;
                        row["SL_SU_CO" + t.Month + "" + t.Year] = 0;
                        row["SL_BAO_TRI" + t.Month + "" + t.Year] = 0;
                        row["TI_LE_SU_CO" + t.Month + "" + t.Year] = 0;
                        row["TI_LE_BAO_TRI" + t.Month + "" + t.Year] =0;
                        
                        _table.DefaultView.RowFilter = "MS_NHOM_MAY='" + row["MS_NHOM_MAY"] + "'  AND M=" + t.Month + " and Y=" + t.Year;

                        foreach (DataRow row2 in _table.DefaultView.ToTable().Rows)
                        {
                            //row["SL_May" + t.Month + "" + t.Year] =Convert.ToInt16(row2["SL_May"]);
                            row["SL_SU_CO" + t.Month + "" + t.Year] =Convert.ToInt16(row2["SL_SU_CO"]);
                            row["SL_BAO_TRI" + t.Month + "" + t.Year] = Convert.ToInt16(row2["SL_BAO_TRI"]);
                            row["TI_LE_SU_CO" + t.Month + "" + t.Year] =Math.Round(Convert.ToDouble(row2["SL_SU_CO"]) / Convert.ToInt32(row["SL_May" + t.Month + "" + t.Year])*100,2);
                            row["TI_LE_BAO_TRI" + t.Month + "" + t.Year] = Math.Round(Convert.ToDouble(row2["SL_BAO_TRI"]) / Convert.ToInt32(row["SL_May" + t.Month + "" + t.Year]) * 100,2);
                        }
                    }

                    DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                    gridBand1.AppearanceHeader.Options.UseTextOptions = true;
                    gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand1 });
                    gridBand1.Caption = t.Month + "/" + t.Year;
                    
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn column5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    column5.OptionsColumn.AllowMove = false;
                    column5.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "SLTu", Commons.Modules.TypeLanguage);
                    column5.Name = "SL_May" + t.Month + "" + t.Year;
                    column5.FieldName = "SL_May" + t.Month + "" + t.Year;

                    column5.Visible = true;

                   
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn column4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    column4.OptionsColumn.AllowMove = false;
                    column4.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "SL_SU_CO", Commons.Modules.TypeLanguage);
                    column4.Name = "SL_SU_CO" + t.Month + "" + t.Year;
                    column4.FieldName = "SL_SU_CO" + t.Month + "" + t.Year;
                    column4.Visible = true;
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn column3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    column3.OptionsColumn.AllowMove = false;
                    column3.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "SL_BAO_TRI", Commons.Modules.TypeLanguage);
                    column3.Name = "SL_BAO_TRI" + t.Month + "" + t.Year;
                    column3.FieldName = "SL_BAO_TRI" + t.Month + "" + t.Year;
                    column3.Visible = true;
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn column2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    column2.OptionsColumn.AllowMove = false;
                    column2.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "TI_LE_SU_CO", Commons.Modules.TypeLanguage);
                    column2.Name = "TI_LE_SU_CO" + t.Month + "" + t.Year;
                    column2.FieldName = "TI_LE_SU_CO" + t.Month + "" + t.Year;
                   
                    column2.Visible = true;
                    column2.AppearanceCell.Options.UseTextOptions = true;
                    column2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    column2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn column1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    column1.OptionsColumn.AllowMove = false;
                    column1.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmIncidents", "TI_LE_BAO_TRI", Commons.Modules.TypeLanguage);
                    column1.Name = "TI_LE_BAO_TRI" + t.Month + "" + t.Year;
                    column1.FieldName = "TI_LE_BAO_TRI" + t.Month + "" + t.Year;
                    column1.Visible = true;
                    column1.AppearanceHeader.Options.UseTextOptions = true;
                    column1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    column2.AppearanceHeader.Options.UseTextOptions = true;
                    column2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    column3.AppearanceHeader.Options.UseTextOptions = true;
                    column3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    column4.AppearanceHeader.Options.UseTextOptions = true;
                    column4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    column5.AppearanceHeader.Options.UseTextOptions = true;
                    column5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                   
                    gridBand1.Columns.Add(column1);
                    gridBand1.Columns.Add(column2);
                    gridBand1.Columns.Add(column3);
                    gridBand1.Columns.Add(column4);
                    gridBand1.Columns.Add(column5);


                    t = t.AddMonths(1);

                    gridBand1.OptionsBand.AllowMove = false;
                    gridBand1.OptionsBand.AllowPress = false;

                }
                grid.LookAndFeel.UseDefaultLookAndFeel = false;
                grid.LookAndFeel.SkinName = "Blue";
             
                grid.DataSource = _table1;
             


        }

        private void btnExport_Click(object sender, EventArgs e)
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
            grid.ExportToXls(path);
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            int count_column = _table1.Columns.Count;
            int count_row = _table1.Rows.Count;
            Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);

            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            //title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xl;
            excelWorkSheet.Cells[1, 1] = lblTitle.Text;


            Excel.Range a2 = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count_column]);
            a2.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range _dateFrom = excelWorkSheet.get_Range(excelWorkSheet.Cells[2, 1], excelWorkSheet.Cells[2, count_column]);
            _dateFrom.Merge(true);
            _dateFrom.Font.Bold = true;
          
            excelWorkSheet.Cells[2, 1] = _date;

            Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            a3.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range catmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            catmachine.Merge(true);
            catmachine.Font.Bold = true;
            excelWorkSheet.Cells[3, 1] = _cat ;
            catmachine.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Excel.Range a4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            a4.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range groupmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            groupmachine.Merge(true);
            groupmachine.Font.Bold = true;
            excelWorkSheet.Cells[4, 1] = _group;
            Excel.Range a5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            a5.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range city = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            city.Merge(true);
            city.Font.Bold = true;
            excelWorkSheet.Cells[5, 1] = _city ;
            Excel.Range a6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            a6.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range district = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            district.Merge(true);
            district.Font.Bold = true;
            excelWorkSheet.Cells[6, 1] = _district;

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[8, 1]);
            a1.MergeCells = true;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 2], excelWorkSheet.Cells[8, 2]);
            a1.MergeCells = true;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            excelWorkSheet.Columns.AutoFit();
            excelWorkSheet.Rows.AutoFit();

            excelApplication.ActiveWindow.DisplayGridlines = true;


            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
