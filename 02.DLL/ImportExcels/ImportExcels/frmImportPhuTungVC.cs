
using System;
//using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
//using System.Data.SqlClient;
//using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using DevExpress.XtraGrid.Views.Grid;
//using Microsoft.ApplicationBlocks.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Spire.Xls;
using Microsoft.ApplicationBlocks.Data;
//using System.Text;
//using System.Globalization;
//using System.Linq;
//using OfficeOpenXml;


//using NPOI.HSSF.UserModel;
//using NPOI.SS.UserModel;

namespace ImportExcels
{
    public partial class frmImportPhuTungVC : DevExpress.XtraEditors.XtraForm
    {
        DataTable _table = new DataTable();
        
        Spire.Xls.Workbook workbook;
        string fileName = null;
        
        System.IO.Stream iostream = new System.IO.MemoryStream();

       
        HSSFWorkbook hssfworkbook;

        public frmImportPhuTungVC()
        {
            InitializeComponent();
        }

        
        private void btnFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                grvSource.ColumnPanelRowHeight = 50;
                if (!LoadExcel_Phuong())
                {
                    if (lokSheet.EditValue != null)
                        lokSheet_EditValueChanged(sender, e);
                }
                else
                    lokSheet_EditValueChanged(sender, e);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }

        }
        private void btnFile_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!LoadExcel_Phuong())
                {
                    if (lokSheet.EditValue != null)
                        lokSheet_EditValueChanged(sender, e);
                }
                else
                    lokSheet_EditValueChanged(sender, e);
            }
            catch { }
        }

        private void lokSheet_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sheet = lokSheet.Text;
                btnFile.Text = fileName;
                if (sheet == "")
                {
                    String[] asss;
                    asss = (String[])lokSheet.Properties.DataSource;
                    sheet = asss[0].ToString();
                    lokSheet.EditValue = sheet;
                }

                if (sheet == "") return;

                _table = new DataTable();
                if (chkGT.Checked)
                {
                    if (GetExcel(sheet, out _table) == false)
                    {
                        string sLoi = "";
                        if (!GetNotExcel(sheet, out _table, out sLoi))
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmImportExcel", "DuLieuLoadSai",
                                Commons.Modules.TypeLanguage) + "\n" + sLoi, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            prbIN.Position = prbIN.Properties.Maximum;
                            return;

                        }
                    }
                }
                else
                {
                    OleDbConnection excelCon;
                    excelCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + btnFile.Text +
                        ";Extended Properties=\"Excel 12.0;HDR=YES\";");
                    try
                    {
                        excelCon.Open();
                    }
                    catch
                    {
                        excelCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + btnFile.Text + ";Extended Properties=Excel 8.0");
                        excelCon.Open();
                    }

                    OleDbCommand cmd = new OleDbCommand("select * from [" + sheet + "$]", excelCon);
                    OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds, "general");
                    _table = ds.Tables["general"];
                }

           
                
                #region Status bar
                try
                {
                    prbIN.Position = 0;
                    prbIN.Properties.Step = 1;
                    prbIN.Properties.PercentView = true;
                    prbIN.Properties.Maximum = _table.Rows.Count + 3;
                    prbIN.Properties.Minimum = 0;
                }
                catch { }
                #endregion



                if (txtRowTD.Text != "")
                {
                    string sBT = "TMP_IMPORT_CV" + Commons.Modules.UserName ;
                    string sSql;
                    DataTable dttmp = new DataTable();
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, _table, "");
                    sSql = "SELECT * FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (SELECT 100)) AS SDONG FROM " +  sBT + ") A WHERE SDONG = "  + txtRowTD.Text;
                    dttmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if(dttmp.Rows.Count>0)
                    {
                        int i = 0;
                        foreach (DataColumn col in _table.Columns)
                        {
                            if (dttmp.Rows[0][i].ToString() != "")
                                col.ColumnName = dttmp.Rows[0][i].ToString();
                            i++;
                        }
                    }
                    _table.Rows.RemoveAt(int.Parse(txtRowTD.Text) - 1);
                }

               

                if (_table.Columns.Count <= 13)
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _table, true, true, true, true);
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _table, true, true, false, true);
                #region prb
                try
                {
                    prbIN.PerformStep();
                    prbIN.Update();
                }
                catch { }
                #endregion

                

                #region prb
                try
                {
                    prbIN.PerformStep();
                    prbIN.Update();
                }
                catch { }
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmImportExcel", "DuLieuLoadSai",
                    Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            prbIN.Position = prbIN.Properties.Maximum;


            //try
            //{
            //    Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
            //    Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
            //    Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            //}
            //catch { }
        }


        private void frmImportPhuTungVC_Load(object sender, EventArgs e)
        {
            try
            {
                grvSource.SaveLayoutToStream(iostream);
                iostream.Seek(0, System.IO.SeekOrigin.Begin);
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                LoadInfo();
                if (btnFile.Text == "") return;

                fileName = btnFile.Text;
                //Create a new workbook
                workbook = new Spire.Xls.Workbook();
                //Load a file and imports its data
                workbook.LoadFromFile(fileName);
                //Initialize worksheet
                //Worksheet sheet = workbook.Worksheets[0];
                DataTable dtSheet = new DataTable("Worksheets");
                DataColumn worksheetColumn = new DataColumn();
                worksheetColumn.DataType = System.Type.GetType("System.String");
                worksheetColumn.ColumnName = "Worksheets";
                dtSheet.Columns.Add(worksheetColumn);

                foreach (Worksheet ws in workbook.Worksheets)
                {
                    DataRow rowa;
                    rowa = dtSheet.NewRow();
                    rowa["Worksheets"] = ws.Name;
                    dtSheet.Rows.Add(rowa);
                }

                lokSheet.Properties.DataSource = dtSheet;
                lokSheet.Properties.ValueMember = "Worksheets";
                lokSheet.Properties.DisplayMember = "Worksheets";

                lokSheet.EditValue = lokSheet.Properties.GetDataSourceValue("Worksheets", 0);

                
                lokSheet_EditValueChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool LoadExcel_Phuong()
        {
            try
            {

                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel Files (*.xls;*.xlsx;)|*.xls;*.xlsx;|" + "All Files (*.*)|*.*"; //"XLS Files|*.xls,*.xlsx  |XLSX Files|*.xlsx;
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    fileName = oFile.FileName;
                    btnFile.Text = fileName;
                    //Create a new workbook
                    workbook = new Spire.Xls.Workbook();
                    //Load a file and imports its data
                    workbook.LoadFromFile(fileName);


                    //Initialize worksheet
                    //Worksheet sheet = workbook.Worksheets[0];
                    DataTable dtSheet = new DataTable("Worksheets");
                    DataColumn worksheetColumn = new DataColumn();
                    worksheetColumn.DataType = System.Type.GetType("System.String");
                    worksheetColumn.ColumnName = "Worksheets";
                    dtSheet.Columns.Add(worksheetColumn);

                    foreach (Worksheet ws in workbook.Worksheets)
                    {
                        DataRow rowa;
                        rowa = dtSheet.NewRow();
                        rowa["Worksheets"] = ws.Name;
                        dtSheet.Rows.Add(rowa);
                    }

                    lokSheet.Properties.DataSource = dtSheet;
                    lokSheet.Properties.ValueMember = "Worksheets";
                    lokSheet.Properties.DisplayMember = "Worksheets";

                    lokSheet.EditValue = lokSheet.Properties.GetDataSourceValue("Worksheets", 0);
                    //            d.Close()
                    //d.PrintDocument.Dispose()
                    //d = Nothing
                    //workbook.
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        void InitializeWorkbook(string path)
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
        }
        private Boolean GetNotExcel(string sSheet, out DataTable dtTmp, out string sLoi)
        {
            int iSDong = 0;
            int i = 0;
            System.Globalization.DateTimeFormatInfo dtF = new System.Globalization.DateTimeFormatInfo();
            DataTable dt = new DataTable();
            try
            {
                InitializeWorkbook(btnFile.Text);
                ISheet sheet = hssfworkbook.GetSheet(sSheet);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                rows.MoveNext();
                rows.MoveNext();
                IRow row1Cot = (HSSFRow)rows.Current;
                rows.Reset();
                while (rows.MoveNext())
                {
                    IRow row = (HSSFRow)rows.Current;

                    if (iSDong == 0)
                    {

                        for (int j = 0; j < row.LastCellNum; j++)
                        {
                            string sTenCot;
                            ICell cell1 = row.GetCell(j);
                            ICell cellCot = row1Cot.GetCell(j);

                            //string sTenCot = "";
                            try
                            {
                                sTenCot = cell1.ToString().Trim();
                            }
                            catch { sTenCot = ""; }
                            if (sTenCot == "")
                                sTenCot = "A" + j;
                            try
                            {
                                if (cellCot == null)
                                    dt.Columns.Add(sTenCot, typeof(string));
                                else
                                {
                                    switch (cellCot.CellType)
                                    {
                                        case NPOI.SS.UserModel.CellType.Numeric:
                                            string sFormat = cellCot.CellStyle.GetDataFormatString().ToUpper();
                                            if (sFormat.Contains("M") || sFormat.Contains("D") || sFormat.Contains("Y") || sFormat.Contains("H") || sFormat.Contains("M") || sFormat.Contains("S") || sFormat.Contains(":") || sFormat.Contains("/"))
                                            {
                                                dt.Columns.Add(sTenCot, typeof(DateTime));
                                            }
                                            else
                                            {
                                                dt.Columns.Add(sTenCot, typeof(float));
                                            }
                                            break;
                                        case NPOI.SS.UserModel.CellType.Boolean:
                                            dt.Columns.Add(sTenCot, typeof(bool));
                                            break;
                                        default:
                                            dt.Columns.Add(sTenCot, typeof(string));
                                            break;
                                    }
                                }
                            }
                            catch { dt.Columns.Add(sTenCot, typeof(string)); }

                            //dt.Columns[sTenCot].AllowDBNull = false;
                        }


                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        i = 0;
                        for (i = 0; i < row.LastCellNum; i++)
                        {
                            if (i == 12)
                            {

                            }

                            ICell cell = row.GetCell(i);
                            if (cell != null)
                            {
                                //dr[i] = cell.ToString();

                                try
                                {

                                    switch (cell.CellType)
                                    {
                                        case NPOI.SS.UserModel.CellType.Numeric:

                                            try
                                            {
                                                string sFormat = cell.CellStyle.GetDataFormatString().ToUpper();
                                                if (sFormat.Contains("M") || sFormat.Contains("D") || sFormat.Contains("Y") || sFormat.Contains("H") || sFormat.Contains("M") || sFormat.Contains("S") || sFormat.Contains(":") || sFormat.Contains("/"))
                                                {
                                                    DateTime dtNgay;
                                                    try
                                                    {
                                                        dtNgay = DateTime.Parse(cell.DateCellValue.ToString(), dtF, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                                    }
                                                    catch { DateTime.TryParse(cell.DateCellValue.ToString(), out dtNgay); }

                                                    try
                                                    {
                                                        dr[i] = dtNgay;
                                                    }
                                                    catch
                                                    {
                                                        dr[i] = cell.NumericCellValue;
                                                    }
                                                }
                                                else
                                                {
                                                    double dGTi = 0;
                                                    if (sFormat.Contains("GENERAL"))
                                                    {
                                                        dr[i] = cell.NumericCellValue;
                                                    }
                                                    else
                                                    {

                                                        sFormat = "0.000000";
                                                        int index = sFormat.IndexOf(".");
                                                        if (index > 0)
                                                            dGTi = Math.Round(cell.NumericCellValue, sFormat.Substring(index).Length);
                                                        else
                                                            dGTi = cell.NumericCellValue;

                                                        dr[i] = dGTi;
                                                    }

                                                }


                                            }
                                            catch { dr[i] = cell.NumericCellValue; }

                                            break;
                                        case NPOI.SS.UserModel.CellType.Boolean:
                                            dr[i] = cell.BooleanCellValue.ToString();
                                            break;
                                        case NPOI.SS.UserModel.CellType.Blank:
                                            //dr[i] = null;
                                            break;
                                        default:
                                            dr[i] = cell.ToString();
                                            break;
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        dr[i] = cell.ToString();
                                    }
                                    catch { }
                                    //dt.Columns.Add(sTenCot, typeof(string)); }
                                }
                            }

                        }
                        dt.Rows.Add(dr);
                    }
                    iSDong++;
                }

            }
            catch (Exception ex)
            {

                sLoi = "GNE : " + iSDong.ToString() + "-" + i.ToString() + "\n" + ex.Message;
                dtTmp = null;
                return false;
            }
            //dataSet1.Tables.Add(dt);
            dtTmp = dt;
            sLoi = "";
            return true;
        }

        private Boolean GetExcel(string sSheet, out DataTable dtExcel)
        {
            dtExcel = new DataTable();
            OleDbConnection excelCon;
            excelCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + btnFile.Text + "1;Extended Properties=\"Excel 12.0;HDR=YES\";");
            try
            {
                excelCon.Open();
            }
            catch
            {
                excelCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + btnFile.Text + "1;Extended Properties=Excel 8.0");
                try
                {
                    excelCon.Open();
                }
                catch { return false; }
            }

            try
            {
                OleDbCommand cmd = new OleDbCommand("select * from [" + sSheet + "$]", excelCon);
                OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "general");
                dtExcel = ds.Tables["general"];

            }
            catch { return false; }
            excelCon.Close();
            return true;

        }

        private void txtMS_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            string dk = "";
            try
            {
                dtTmp = (DataTable)grdSource.DataSource;
                foreach (DataColumn col in dtTmp.Columns)
                {
                    if (col.DataType.ToString().ToUpper() == "System.String".ToUpper())
                    {
                        if (txtMS.Text.Length != 0) dk = " OR  [" + col.ColumnName.ToUpper().ToString() + "] LIKE '%" + txtMS.Text + "%' " + dk;

                    }
                }

                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);

                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                dtTmp.DefaultView.RowFilter = "";
            }
        }

        private DataTable datasource = new DataTable();

        private void LoadInfo()
        {
            if (File.Exists(Application.StartupPath + "\\LoadItemInfo.xml"))
            {
                DataSet _dsDatasource = new DataSet();
                _dsDatasource.ReadXml(Application.StartupPath + "\\LoadItemInfo.xml");
                datasource = _dsDatasource.Tables[0];
                if (datasource.Rows.Count > 0)
                {
                    btnFile.Text = datasource.Rows[0]["FileXLS"].ToString();
                    txtRowTD.Text = datasource.Rows[0]["RowTieuDe"].ToString();
                }
                else
                {
                    //btnFile.Text = "";
                    //txtRowTD.Text = "";
                }
            }
            else
            {
                //btnFile.Text = "";
                //txtRowTD.Text = "";
            }
        }
        private bool WriteInfo()
        {
            Init();

            datasource.Rows.Clear();
            datasource.Rows.Add(btnFile.Text.Trim(), txtRowTD.Text.Trim());

            DataSet _dsDatasource = new DataSet();
            _dsDatasource.Tables.Add(datasource.Copy());
            _dsDatasource.WriteXml(Application.StartupPath + "\\LoadItemInfo.xml");

            return true;
        }


        private void Init()
        {
            datasource = new DataTable();
            datasource.Columns.Add("FileXLS", Type.GetType("System.String"));
            datasource.Columns.Add("RowTieuDe", Type.GetType("System.String"));
        }

        private void btnFile_Validated(object sender, EventArgs e)
        {
            WriteInfo();
        }
        
    }
}
