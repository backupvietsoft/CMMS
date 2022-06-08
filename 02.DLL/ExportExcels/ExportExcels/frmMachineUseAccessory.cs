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
    public partial class frmMachineUseAccessory : DevExpress.XtraEditors.XtraForm
    {
        
        DataTable _table1 = new DataTable();
        GridControl grid = new GridControl();
        //public DateTime _tu_ngay, _den_ngay;
        public string tinh,quan,loai_may, nhom_may,nha_xuong;
        public string _date;
        private DataTable _tableSource = new DataTable();
        public DataTable _TableSource
        {
            get
            {
                return _tableSource;
            }
            set
            {
                _tableSource = value;
            }
        }
        public frmMachineUseAccessory()
        {
            InitializeComponent();
        }
       
        private void LoadData()
        {
           
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
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand1 });
            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand2 });
            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand3 });
            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand4 });
            gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand5 });
            
            gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridBand5.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "SoLuongVTTT", Commons.Modules.TypeLanguage);
            gridView.OptionsBehavior.Editable = false;
            _tableSource.Columns.Add("NO", typeof(int));
            
            
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn0 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            bandedGridColumn0.OptionsColumn.AllowMove = false;
            bandedGridColumn0.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandedGridColumn0.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            bandedGridColumn0.AppearanceHeader.Options.UseTextOptions = true;
            bandedGridColumn0.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NO", Commons.Modules.TypeLanguage);
            bandedGridColumn0.FieldName = "NO";
            bandedGridColumn0.Visible = true;
            gridBand1.Columns.Add(bandedGridColumn0);
            for (int i = 0; i < 3; i++)
            {
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                bandedGridColumn.Name = "band" + i;
                bandedGridColumn.OptionsColumn.AllowMove = false;
                bandedGridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                bandedGridColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                bandedGridColumn.AppearanceHeader.Options.UseTextOptions = true;
                bandedGridColumn.Caption = _tableSource.Columns[i].Caption;
                bandedGridColumn.FieldName = _tableSource.Columns[i].Caption;
                bandedGridColumn.Visible = true;
                switch (i)
                {
                    case 0:
                        gridBand2.Columns.Add(bandedGridColumn);
                        break;
                    case 1:
                        gridBand3.Columns.Add(bandedGridColumn);
                        break;
                    case 2:
                        gridBand4.Columns.Add(bandedGridColumn);
                        break;
                }
                
               
                
            }

          
            for (int i = 3; i < _tableSource.Columns.Count-1;i++)
            {
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                bandedGridColumn.Name = "band" + i;
                bandedGridColumn.OptionsColumn.AllowMove = false;
                bandedGridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                bandedGridColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                bandedGridColumn.AppearanceHeader.Options.UseTextOptions = true;
                bandedGridColumn.Caption = _tableSource.Columns[i].Caption;
                bandedGridColumn.FieldName = _tableSource.Columns[i].Caption;
                bandedGridColumn.OptionsColumn.AllowMove  = false;
                bandedGridColumn.OptionsColumn.AllowMove = false;
                
                bandedGridColumn.Visible = true;
                gridBand5.Columns.Add(bandedGridColumn); 
               
            }
            //for (int i = 3; i < _tableSource.Columns.Count; i++)
            for (int i = 0; i < _tableSource.Rows.Count; i++)
                _tableSource.Rows[i]["NO"] = i + 1;
            grid.DataSource = _tableSource;
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
            int count_column = _tableSource.Columns.Count;
            int count_row = _tableSource.Rows.Count;
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
            Excel.Range factory = excelWorkSheet.get_Range(excelWorkSheet.Cells[3, 1], excelWorkSheet.Cells[3, count_column]);
            factory.Merge(true);
            factory.Font.Bold = true;
            excelWorkSheet.Cells[3, 1] = nha_xuong;

            Excel.Range a4 = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            a4.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range catmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[4, 1], excelWorkSheet.Cells[4, count_column]);
            catmachine.Merge(true);
            catmachine.Font.Bold = true;
            excelWorkSheet.Cells[4, 1] = loai_may ;
            catmachine.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Excel.Range a5 = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            a5.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range groupmachine = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, 1], excelWorkSheet.Cells[5, count_column]);
            groupmachine.Merge(true);
            groupmachine.Font.Bold = true;
            excelWorkSheet.Cells[5, 1] = nhom_may;
            Excel.Range a6 = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            a5.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range city = excelWorkSheet.get_Range(excelWorkSheet.Cells[6, 1], excelWorkSheet.Cells[6, count_column]);
            city.Merge(true);
            city.Font.Bold = true;
            excelWorkSheet.Cells[6, 1] = tinh ;
            Excel.Range a7 = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
            a7.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range district = excelWorkSheet.get_Range(excelWorkSheet.Cells[7, 1], excelWorkSheet.Cells[7, count_column]);
            district.Merge(true);
            district.Font.Bold = true;
            excelWorkSheet.Cells[7, 1] = quan;
            Excel.Range a8 = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 1], excelWorkSheet.Cells[8, count_column]);
            a8.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range temp = excelWorkSheet.get_Range(excelWorkSheet.Cells[8, 1], excelWorkSheet.Cells[8, count_column]);
            temp.Merge(true);

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 1], excelWorkSheet.Cells[10, 1]);
            a1.MergeCells = true;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 2], excelWorkSheet.Cells[10, 2]);
            a1.MergeCells = true;

            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 3], excelWorkSheet.Cells[10, 3]);
            a1.MergeCells = true;
            a1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            a1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[9, 4], excelWorkSheet.Cells[10, 4]);
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

        private void frmMachineUseAccessory_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            LoadData();
            btnExport.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExport", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExit", Commons.Modules.TypeLanguage);
        }
    }
}
