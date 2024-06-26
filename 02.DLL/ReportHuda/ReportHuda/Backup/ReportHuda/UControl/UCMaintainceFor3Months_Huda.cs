using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;
namespace ReportHuda
{
    public partial class UCMaintainceFor3Months_Huda : DevExpress.XtraEditors.XtraUserControl
    {
       
        DataTable _tableMaintaince;
        DataTable _tableMachine;
        int rownc = 1,rowngay=1,rowdg=1,rowstong=1;
        string filterMachine = "<ROOT>", filterMaintaince = "<ROOT>";
        //string filterBPCP = "<ROOT>", filterBPCPhi = "<ROOT>";

        public UCMaintainceFor3Months_Huda()
        {
            InitializeComponent();
        }

        public void GetImage(byte[] Logo)
        {
            //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Masters");
            string strPath = Application.StartupPath + "\\logo.bmp";
            System.IO.MemoryStream stream = new System.IO.MemoryStream(Logo);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(strPath);
        }
        private void LoadFactory()
        {
            DataTable _table_Factory = new DataTable();
            _table_Factory.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1","-1", "-1"));
            cmbFactory.Properties.ValueMember = "MS_N_XUONG";
            cmbFactory.Properties.DisplayMember = "TEN_N_XUONG"; 
            cmbFactory.EditValue = "-1";
            cmbFactory.Properties.DataSource = _table_Factory;
           
        }
        private void LoadMachine()
        {
            _tableMachine = new DataTable();
            _tableMachine.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DS_MAY_BY_NX", cmbFactory.EditValue));
            string caption = "";
            foreach (DataColumn col in _tableMachine.Columns)
            {
                caption = col.Caption;
                switch (caption)
                {
                    case "CHON":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "CHON", Commons.Modules.TypeLanguage);
                        break;
                    case "MS_MAY":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "MS_MAY", Commons.Modules.TypeLanguage);
                        break;
                    case "TEN_MAY":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "TEN_MAY", Commons.Modules.TypeLanguage);
                        break;
                }
                col.ReadOnly = true;
                
            }
            _tableMachine.Columns["CHON"].ReadOnly = false;
            gdMachine.DataSource = _tableMachine;
        }
        private void LoadMaintaince()
        {
            string sql = "SELECT CONVERT(BIT,0) AS CHON, MS_LOAI_BT,TEN_LOAI_BT FROM LOAI_BAO_TRI WHERE MS_HT_BT=1";
            _tableMaintaince = new DataTable();
            _tableMaintaince.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql));
            string caption = "";
            foreach (DataColumn col in _tableMaintaince.Columns)
            {
                caption = col.Caption;
                switch(caption)
                {
                    case "CHON":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "CHON", Commons.Modules.TypeLanguage);
                        break;
                    case "MS_LOAI_BT":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "MS_LOAI_BT", Commons.Modules.TypeLanguage);
                        break;
                    case "TEN_LOAI_BT":
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "TEN_LOAI_BT", Commons.Modules.TypeLanguage);
                        break;
                }
                col.ReadOnly = true;
            }
            _tableMaintaince.Columns["CHON"].ReadOnly = false;
            gdMaintaince.DataSource = _tableMaintaince;
        }
        private void ChooseAll(bool choose,GridView  view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
            }
        }
        private void btnMachineChooseAll_Click(object sender, EventArgs e)
        {
            ChooseAll(true, gvMachine);
        }

        private void btnMachineUnChooseAll_Click(object sender, EventArgs e)
        {
            ChooseAll(false, gvMachine);
        }

        private void btnMaintaiceChooseAll_Click(object sender, EventArgs e)
        {
            ChooseAll(true, gvMaintaince);
        }

        private void btnMaitainceUnChooseAll_Click(object sender, EventArgs e)
        {
            ChooseAll(false, gvMaintaince);
        }
        private void SetLanguage()
        {
            //btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "btnExecute", Commons.Modules.TypeLanguage);
            //btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "btnThoat", Commons.Modules.TypeLanguage);
            //btnMachineChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "btnMachineChooseAll", Commons.Modules.TypeLanguage);
            //btnMachineUnChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "btnMachineUnChooseAll", Commons.Modules.TypeLanguage);
            //btnMaintaiceChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "btnMaintaiceChooseAll", Commons.Modules.TypeLanguage);
            //btnMaitainceUnChooseAll.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "btnMaitainceUnChooseAll", Commons.Modules.TypeLanguage);
        }
     
      
        
     
        private void cmbFactory_EditValueChanged(object sender, EventArgs e)
        {
            LoadMachine();
        }
    
        private DataTable TableMaintaince
        {
            get
            {
                
                DataTable _tableTemp = _tableMachine.Copy();
                _tableTemp.DefaultView.RowFilter = "CHON=TRUE";
                filterMachine = "<ROOT>";
                filterMaintaince = "<ROOT>";
                foreach (DataRow row in _tableTemp.DefaultView.ToTable().Rows)
                {
                    if (filterMachine == "<ROOT>")
                        filterMachine += "<MAY id=\"" + row["MS_MAY"].ToString() + "\"/>";
                    else
                        filterMachine += "<MAY id=\"" + row["MS_MAY"].ToString() + "\"/>";
                }

                filterMachine += "</ROOT>";
               
                DataTable _tableTemp1 = _tableMaintaince.Copy();
                _tableTemp1.DefaultView.RowFilter = "CHON=TRUE";
                foreach (DataRow row in _tableTemp1.DefaultView.ToTable().Rows)
                {
                    if (filterMaintaince == "<ROOT>")
                        filterMaintaince += "<LOAI_BT id1=\"" + row["MS_LOAI_BT"].ToString() + "\"/>";
                    else
                        filterMaintaince += "<LOAI_BT id1=\"" + row["MS_LOAI_BT"].ToString() + "\"/>";
                }
                filterMaintaince += "</ROOT>";
                DataTable _tableValue = new DataTable();
                _tableValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_NHU_Y_KE_HOACH_BT_TB_HUDA]",filterMachine,filterMaintaince));
                if (_tableValue.Rows.Count > 0)
                {
                    _tableValue = _tableValue.DefaultView.ToTable("DSBT_3THANG", true,"MS_MAY","TEN_MAY","MS_BO_PHAN","TEN_BO_PHAN","MO_TA_CV");
                }
                    return _tableValue;
            }
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable _tableSource = new DataTable();
            try
            {
                _tableSource = TableMaintaince;
                if (_tableSource.Rows.Count > 0)
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
                    Excel.Application excelApplication = new Excel.Application();
                    System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    excelApplication.Visible = false;
                    Excel.Workbook excelWorkbook;
                    object missValue = System.Reflection.Missing.Value;
                    excelWorkbook = excelApplication.Workbooks.Add(missValue);
                    Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

                    int rows = 1;
                    DataTable dtTmp = new DataTable();
                    dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_CHUNG", Commons.Modules.TypeLanguage));
                    Excel.Range CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows + 3, "B"]);
                    CurCell.MergeCells = true;
                    GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
                    excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 180, 50);
                    System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
                    CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "F"]);
                    CurCell.Merge(true);

                    CurCell.Font.Bold = true;
                    CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];
                    rows++;
                    CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "F"]);
                    CurCell.Merge(true);
                    CurCell.Font.Bold = true;
                    CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["DIA_CHI"];
                    rows++;
                    CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "F"]);
                    CurCell.Merge(true);
                    CurCell.Font.Bold = true;
                    CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["phone"] + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["FAX"];
                    rows++;
                    CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "F"]);
                    CurCell.Merge(true);
                    CurCell.Font.Bold = true;
                    CurCell.Value2 = "Email : " + dtTmp.Rows[0]["EMAIL"];

                    rows += 2;
                    Excel.Range a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "F"]);
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "F"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;
                    a3.Font.Size = "14";
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "kehoachbaotrithietbi", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rows++;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "F"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;

                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "dinhky", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rows++;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "F"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;

                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "thoigiandukien", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rows++;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "D"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "kehoachso", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "F"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "ngaylap", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rows++;

                    //STT
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "A"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "STT", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.ColumnWidth = "5";
                    //NOI DUNG CONG VIEC
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "B"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "NOIDUNGCONVIEC", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.ColumnWidth = "30";
                    //NHAN LUC DU KIEN
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "C"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "NHANLUCDUKIEN", Commons.Modules.TypeLanguage);
                    a3.ColumnWidth = "25";
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    // SO NGAY THUC HIEN
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "D"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "SONGAYTHUCHIEN", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.ColumnWidth = "25";
                    // BAT DAU
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "E"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "BATDAU", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.ColumnWidth = "20";
                    // HOAN THANH
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "F"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "HOANTHANH", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.ColumnWidth = "15";

                    DataTable _tableMay = new DataTable();
                    _tableMay = _tableSource.DefaultView.ToTable("MAY", true, "MS_MAY", "TEN_MAY");
                    string ten_tb = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "tenthietbi", Commons.Modules.TypeLanguage);
                    string ms_tb = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "masothietbi", Commons.Modules.TypeLanguage);
                    string kinhphi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "kinhphidukien", Commons.Modules.TypeLanguage);
                    string masobophan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "masobophan", Commons.Modules.TypeLanguage);
                    string tenbophan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "tenbophan", Commons.Modules.TypeLanguage);
                    string ms_may, ten_may, ms_bp, ten_bp;
                    // int[] arr = new int[_tableMay.Rows.Count];
                    int index = -1;
                    int _start_cv = 0;
                    int _start_ngay_cong = rows + 3;
                    int _end_cv = 0;
                    //int _end_ngay_cong=0;
                    foreach (DataRow _row_may in _tableMay.Rows)
                    {
                        rows++;
                        // index++;
                        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "B"]);
                        a3.Merge(true);
                        ms_may = _row_may["MS_MAY"].ToString();
                        ten_may = _row_may["TEN_MAY"].ToString();
                        a3.Value = ten_tb + ": " + ten_may;
                        a3.Font.Bold = true;
                        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "C"], excelWorkSheet.Cells[rows, "D"]);
                        a3.Merge(true);
                        a3.Value = ms_tb + ": " + ms_may;
                        a3.Font.Bold = true;
                        a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "E"]);
                        a3.Merge(true);
                        a3.Value = kinhphi;
                        index = rows;
                        //  arr[index] = rows;
                        a3.Font.Bold = true;

                        DataTable _tableBP = new DataTable();
                        string filter = "MS_MAY='" + ms_may + "'";
                        _tableSource.DefaultView.RowFilter = filter;
                        _tableBP = _tableSource.DefaultView.ToTable("BOPHAN", true, "MS_BO_PHAN", "TEN_BO_PHAN");

                        _start_cv = rows + 2;

                        foreach (DataRow _row_bp in _tableBP.Rows)
                        {
                            rows++;
                            ms_bp = _row_bp["MS_BO_PHAN"].ToString();
                            ten_bp = _row_bp["TEN_BO_PHAN"].ToString();
                            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "C"]);
                            a3.Merge(true);
                            a3.Value = tenbophan + ": " + ten_bp;
                            a3.Font.Bold = true;
                            a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows, "F"]);
                            a3.Merge(true);
                            a3.Value = masobophan + ":" + ms_bp;
                            a3.Font.Bold = true;
                            DataTable _tableCV = new DataTable();
                            filter = "MS_MAY='" + ms_may + "' AND MS_BO_PHAN='" + ms_bp + "'";
                            _tableSource.DefaultView.RowFilter = filter;
                            _tableCV = _tableSource.DefaultView.ToTable();
                            int i = 1;



                            foreach (DataRow _row_cv in _tableCV.Rows)
                            {
                                rows++;

                                a3 = (Excel.Range)excelWorkSheet.Cells[rows, "A"];
                                a3.Value = i;
                                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                a3 = (Excel.Range)excelWorkSheet.Cells[rows, "B"];
                                a3.Value = _row_cv["MO_TA_CV"];
                                a3.WrapText = true;
                                a3 = (Excel.Range)excelWorkSheet.Cells[rows, "C"];
                                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                a3 = (Excel.Range)excelWorkSheet.Cells[rows, "D"];


                                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                                a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                a3 = (Excel.Range)excelWorkSheet.Cells[rows, "E"];
                                a3.NumberFormat = "dd-mm-yyyy";
                                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                a3 = (Excel.Range)excelWorkSheet.Cells[rows, "F"];
                                a3.NumberFormat = "dd-mm-yyyy";
                                string empty = Convert.ToChar(34).ToString() + Convert.ToChar(34).ToString();
                                string a = @"=IF(OR(len(D" + rows + ")=0,len(E" + rows + ")=0)," + empty + ",SUM(D" + rows + ",E" + rows + "))";
                                a3.Value2 = a;
                                a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;



                                a3 = (Excel.Range)excelWorkSheet.Cells[rows, "Z"];
                                a3.ColumnWidth = "0";
                                a3.Value2 = "=(C" + rows + "* D" + rows + ")";
                                i++;
                            }
                            _end_cv = rows;
                            double money = 0;

                            try
                            {
                                money = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_VTPT_HUDA_1_MAY", ms_may));
                            }
                            catch
                            {
                                money = 0;
                            }
                            a3 = (Excel.Range)excelWorkSheet.Cells[index, "F"];
                            a3.Value2 = "=SUM(Z" + _start_cv + ":Z" + _end_cv + ")* (Y" + _start_ngay_cong + ") + " + money;
                            a3.NumberFormat = "##,##0.00";

                        }

                    }
                    rows++;
                    /////tong so nguoi
                    rownc = rows;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "D"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "tongsonguoithamgiadukien", Commons.Modules.TypeLanguage);
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "E"];
                    a3.Value2 = "=SUM(C" + _start_ngay_cong + ":C" + _end_cv + ")";
                    a3.Font.Bold = true;
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "F"];
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "nguoi", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;

                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "Z"];
                    a3.Value2 = "=SUM(Z" + _start_ngay_cong + ":Z" + _end_cv + ")";

                    rows++;
                    rowngay = rows;
                    /////tong so ngay cong
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "D"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "tongsongaycong", Commons.Modules.TypeLanguage);
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "E"];
                    a3.Value2 = "=SUM(D" + _start_ngay_cong + ":D" + _end_cv + ")";
                    a3.Font.Bold = true;
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "F"];
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "cong", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    rows++;
                    ////////don gia ngay cong
                    rowdg = rows;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "D"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "dongiangaycong", Commons.Modules.TypeLanguage);
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "E"];
                    a3.Font.Bold = true;
                    a3.NumberFormat = "###,##0.00";
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "F"];
                    a3.Font.Bold = true;
                    a3.Value2 = "VNĐ";
                    a3 = (Excel.Range)excelWorkSheet.Cells[_start_ngay_cong, "Y"];
                    a3.ColumnWidth = "0";
                    a3.Value2 = "=E" + rows;
                    rows++;

                    ////tong chi phi
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows, "D"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "tongchiphi", Commons.Modules.TypeLanguage);
                    rowstong = rows;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[10, "A"], excelWorkSheet.Cells[rows, "F"]);
                    a3.Borders.LineStyle = 1;
                    rows++;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "C"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "duyet", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "D"];
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "kiemtra", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "F"]);
                    a3.Font.Bold = true;
                    a3.Merge(true);
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "nguoilap", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rows++;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows + 2, "C"]);
                    a3.MergeCells = true;
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows + 2, "D"]);
                    a3.MergeCells = true;
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows + 2, "F"]);
                    a3.MergeCells = true;
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    rows += 3;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "A"], excelWorkSheet.Cells[rows + 2, "G"]);
                    a3.MergeCells = true;
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "danhmucvattuphutung", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rows += 3;
                    //STT
                    int _start_row = rows;
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "A"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "STT", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    //MS VAT TU PHU DUNG
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "B"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "MASOPT", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    //TEN VAT TU PHU DUNG
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "C"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "TENVTPT", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    //THONG SO KY THUAT
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "D"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "THONGSOKYTHUAT", Commons.Modules.TypeLanguage);

                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    // DON VI TINH
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "E"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "DVT", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    // SO LUONG
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "F"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "SOLUONG", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    // DON GIA
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "G"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "DONGIA", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.ColumnWidth = "15";

                    //THANH TIEN
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "H"];
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "THANHTIEN", Commons.Modules.TypeLanguage);
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3.ColumnWidth = "20";
                    int startRow = rows + 1;
                    DataTable _tableVT = new DataTable();
                    _tableVT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_VTPT_HUDA", filterMachine, filterMaintaince,Commons.Modules.TypeLanguage));
                    int j;
                    j = 1;
                    foreach (DataRow _row_vt in _tableVT.Rows)
                    {
                        rows++;
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "A"];
                        a3.Value = j;
                        a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "B"];
                        a3.Value = _row_vt["MS_PT"].ToString();
                        a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "C"];
                        a3.Value = _row_vt["TEN_PT"];
                        a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "D"];
                        a3.WrapText = true;
                        a3.Value = _row_vt["QUI_CACH"];

                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "E"];
                        a3.Value = _row_vt["DVT"];
                        a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "F"];
                        a3.Value = _row_vt["SL"];
                        a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "G"];
                        a3.Value = _row_vt["DON_GIA"];
                        a3.NumberFormat = "###,##0.00";
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "H"];

                        a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3 = (Excel.Range)excelWorkSheet.Cells[rows, "H"];
                        a3.Value = _row_vt["THANH_TIEN"];
                        a3.NumberFormat = "###,##0.00";
                        a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        j++;
                    }
                    int endRow = rows;
                    rows++;
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "G"];
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    a3.Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "TONG", Commons.Modules.TypeLanguage);
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "H"];
                    a3.Value2 = "=SUM(H" + startRow + ":H" + endRow + ")";
                    a3.NumberFormat = "###,##0.00";

                    // a3 = (Excel.Range)excelWorkSheet.Cells[totalRows, "E"];
                    a3 = (Excel.Range)excelWorkSheet.Cells[rowstong, "E"];
                    a3.Font.Bold = true;
                    a3.Value2 = "=Z" + rownc + "*E" + rowdg + "+H" + rows;
                    a3.NumberFormat = "###,##0.00";
                    a3 = (Excel.Range)excelWorkSheet.Cells[rowstong, "F"];
                    a3.Font.Bold = true;
                    a3.Value2 = "VNĐ";
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_start_row, "A"], excelWorkSheet.Cells[rows, "H"]);
                    a3.Borders.LineStyle = 1;
                    rows++;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows, "C"]);
                    a3.Merge(true);
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "duyet", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3 = (Excel.Range)excelWorkSheet.Cells[rows, "D"];
                    a3.Font.Bold = true;
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "kiemtra", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows, "F"]);
                    a3.Font.Bold = true;
                    a3.Merge(true);
                    a3.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "nguoilap", Commons.Modules.TypeLanguage);
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rows++;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "B"], excelWorkSheet.Cells[rows + 2, "C"]);
                    a3.MergeCells = true;
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "D"], excelWorkSheet.Cells[rows + 2, "D"]);
                    a3.MergeCells = true;
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    a3 = excelWorkSheet.get_Range(excelWorkSheet.Cells[rows, "E"], excelWorkSheet.Cells[rows + 2, "F"]);
                    a3.MergeCells = true;
                    a3.Font.Bold = true;
                    a3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    a3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    if (Commons.Modules.bDoiFontReport) excelApplication.Cells.Font.Name = Commons.Modules.sFontReport;


                    this.Cursor = Cursors.Default;

                    excelWorkbook.SaveAs(f.FileName, Excel.XlFileFormat.xlWorkbookNormal, missValue,
                                         missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive,
                                         missValue, missValue, missValue, missValue);
                    excelApplication.Visible = true;


                }
                else
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "UCMaintainceFor3Months_Huda", "khongcodulieu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void UCMaintainceFor_Day_Of_Week_Load(object sender, EventArgs e)
        {
          
            LoadFactory();
            LoadMaintaince();
            SetLanguage();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
