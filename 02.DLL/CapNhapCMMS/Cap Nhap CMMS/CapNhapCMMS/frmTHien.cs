using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Transactions;


namespace CapNhapCMMS
{
    public partial class frmTHien : Form
    {
        public frmTHien()
        {
            InitializeComponent();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (!KiemConnect()) return;
            if (txtQuery.Text.Trim() == "")
                return;

            try
            {
                DataTable dtttmp = new DataTable();
                dtttmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, txtQuery.Text));

                grdDuLieu.DataSource = dtttmp;
                MessageBox.Show("Thực hiện thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực hiện không thành công." + "\n" + ex.Message);
            }


        }

        private Boolean KiemConnect()
        {
            try
            {
                if (txtServer.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập server, Vui lòng nhập server.");
                    txtServer.Focus();
                    return false;
                }

                if (txtUser.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập user, Vui lòng nhập user.");
                    txtUser.Focus();
                    return false;
                }
                if (cboData.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập data, Vui lòng nhập data.");
                    cboData.Focus();
                    return false;
                }

                Commons.IConnections.Server = txtServer.Text;
                Commons.IConnections.Database = cboData.Text;
                Commons.IConnections.Username = txtUser.Text;
                Commons.IConnections.Password = txtPass.Text;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực hiện không thành công." + "\n" + ex.Message);
                return false;
            }
            
        }
        private void frmTHien_Load(object sender, EventArgs e)
        {
            LoadConnect();

            LoadData();

        }

        private void LoadConnect()
        {
            if (!File.Exists(Application.StartupPath + "\\VSConfig.ini")) return;

            FileStream inputstream = File.OpenRead(Application.StartupPath + "\\VSConfig.ini");
            string sChuoi;
            StreamReader sFileInclude;
            sFileInclude = File.OpenText(Application.StartupPath + "\\VSConfig.ini");

            sChuoi = sFileInclude.ReadToEnd();
            sChuoi = Commons.Modules.ObjSystems.GiaiMaDL(sChuoi);
            string[] sArr = sChuoi.Split(new Char[] { '!' });

            Commons.IConnections.Server = sArr[0].ToString();
            Commons.IConnections.Database = sArr[1].ToString();
            Commons.IConnections.Username = sArr[2].ToString();
            Commons.IConnections.Password = sArr[3].ToString();
            Commons.Modules.TypeLanguage = int.Parse(sArr[4].ToString());

            txtServer.Text = Commons.IConnections.Server;
            cboData.Text = Commons.IConnections.Database;
            txtUser.Text = Commons.IConnections.Username;
            txtPass.Text = Commons.IConnections.Password;

            //Commons.Modules.UserName = "Administrator";
            //Commons.IConnections.Server = "MASHILOVE";
            //Commons.IConnections.Database = "CMMS_BHS";
            ////Commons.IConnections.Database = "CMMS_MEKO";
            //Commons.IConnections.Database = "CMMS_TEST";
            //Commons.IConnections.Password = "123";
            //Commons.IConnections.Username = "sa";        
            LoadVerThongTin();
        }

        private void LoadVerThongTin()
        {
            try
            {
                string sSql = "SELECT VER FROM THONG_TIN_CHUNG";
                txtVer.Text = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


            }
            catch { txtVer.Text = ""; }
            try
            {
                string sSql = "SELECT VER_HT FROM THONG_TIN_CHUNG";
                txtCom.Text = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


            }
            catch { txtCom.Text = ""; }
            try
            {
                string sSql = "SELECT VER_TB FROM THONG_TIN_CHUNG";
                txtTable.Text = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


            }
            catch { txtTable.Text = ""; }

            try
            {
                string sSql = "SELECT VER_LAN FROM THONG_TIN_CHUNG";
                txtLan.Text = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


            }
            catch { txtLan.Text = ""; }
            try
            {
                string sSql = "SELECT ISNULL(VER_WEB,0) FROM THONG_TIN_CHUNG";
                txtWeb.Text = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


            }
            catch { txtWeb.Text = ""; }
        }
        private void LoadData()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_databases"));
                //dtTmp.DefaultView.RowFilter = "database_name like 'CMMS%'";
                //dtTmp = dtTmp.DefaultView.ToTable();
                cboData.DataSource = dtTmp;
                cboData.ValueMember = "database_name";
                cboData.DisplayMember = "database_name";
                cboData.Text = Commons.IConnections.Database;
            }
            catch
            {
                cboData.Text = Commons.IConnections.Database;
                
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmTHien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 116) return;
            btnThucHien_Click(sender, e);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            DataTable dtTmp1 = new DataTable();
            string sPath = "";
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dtTmp1 = (DataTable)grdDuLieu.DataSource;
                if (dtTmp1.Rows.Count <= 0)
                {
                    MessageBox.Show("Error");
                    return;
                }
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
                if (sPath == "") return;
                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int col = 0, row = 0;
                object[,] rawData = new object[dtTmp1.Rows.Count + 1, dtTmp1.Columns.Count];

                for (col = 0; col <= dtTmp1.Columns.Count - 1; col++)
                {
                    rawData[0, col] = dtTmp1.Columns[col].ColumnName.ToUpper();
                }

                for (col = 0; col <= dtTmp1.Columns.Count - 1; col++)
                {
                    for (row = 0; row <= dtTmp1.Rows.Count - 1; row++)
                    {
                        rawData[row + 1, col] = dtTmp1.Rows[row].ItemArray[col];
                    }
                }

                string finalColLetter, excelRange;
                finalColLetter = Commons.Modules.MExcel.MCotExcel(dtTmp1.Columns.Count);
                excelRange = String.Format("A01:{0}{1}", finalColLetter, 11 + dtTmp1.Rows.Count + 1);
                xlWorkSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;

                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, dtTmp1.Rows.Count + 2, 1, dtTmp1.Rows.Count + 30, dtTmp1.Columns.Count);
                title.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                xlApp.DisplayAlerts = false;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, 1, dtTmp1.Columns.Count);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 1, 1, dtTmp1.Rows.Count + 1, dtTmp1.Columns.Count);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));




                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 40, 10, 75);

                xlWorkBook.SaveAs(sPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue);
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

            }
            catch (Exception ex)
            {
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                MessageBox.Show(ex.Message);
                return;
            }
            this.Cursor = Cursors.Default;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!KiemConnect()) return;
            DataTable dtTmp = new DataTable();
            grdDuLieu.DataSource = null;

            grdDuLieu.Columns.Clear();
            grdDuLieu.Columns.Add("No.", "No.");
            grdDuLieu.Columns.Add("Query", "Query");
            grdDuLieu.Columns.Add("Action", "Action");
            grdDuLieu.Columns.Add("Time", "Time");
            grdDuLieu.Columns.Add("Error", "Error");

            object[] row = new object[] { 1,Commons.IConnections.Server, Commons.IConnections.Database, DateTime.Now.ToString(), 1 };
            grdDuLieu.Rows.Add(row);

            float VerHT = 0,VerLAN = 0, VerWEB = 0, VerKH = 0, VerTB = 0;
            string FolderCM = Application.StartupPath + "\\Common";
            string FolderTB = Application.StartupPath + "\\Table";
            string FolderLAN = Application.StartupPath + "\\Languages";
            string FolderWEB = Application.StartupPath + "\\WEB";
            string FolderKH = "";

            

            string sSql = "";
            try
            {
                sSql = "SELECT TOP 1 * FROM THONG_TIN_CHUNG ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));

                FolderKH = Application.StartupPath + "\\" + dtTmp.Rows[0]["PRIVATE"];
                try
                {
                    if (txtCom.Text == "" || txtCom.Text == "0")
                        VerHT = string.IsNullOrEmpty(dtTmp.Rows[0]["VER_HT"].ToString()) ? 0 : float.Parse(dtTmp.Rows[0]["VER_HT"].ToString()); //float.Parse(dtTmp.Rows[0]["VER_HT"].ToString());
                    else
                        VerHT = float.Parse(txtCom.Text);
                }
                catch
                { VerHT = 0; }



                try
                {

                    if (txtLan.Text == "" || txtLan.Text == "0")
                        VerLAN = string.IsNullOrEmpty(dtTmp.Rows[0]["VER_LAN"].ToString()) ? 0 : float.Parse(dtTmp.Rows[0]["VER_LAN"].ToString()); 
                    else
                        VerLAN = float.Parse(txtLan.Text);


                }
                catch
                { VerLAN = 0; }

                try
                {

                    if (txtWeb.Text == "" || txtWeb.Text == "0")
                        VerWEB = string.IsNullOrEmpty(dtTmp.Rows[0]["VER_WEB"].ToString()) ? 0 : float.Parse(dtTmp.Rows[0]["VER_WEB"].ToString()); 
                    else
                        VerWEB = float.Parse(txtWeb.Text);


                }
                catch
                { VerLAN = 0; }


                try
                {
                    VerKH = string.IsNullOrEmpty(dtTmp.Rows[0]["VER_KH"].ToString()) ? 0 : float.Parse(dtTmp.Rows[0]["VER_KH"].ToString());
                }
                catch
                { VerKH = 0; }

                if (txtTable.Text == "" || txtTable.Text == "0")
                    VerTB = string.IsNullOrEmpty(dtTmp.Rows[0]["VER_TB"].ToString()) ? 0 : float.Parse(dtTmp.Rows[0]["VER_TB"].ToString());
                else
                    VerTB = float.Parse(txtTable.Text);
                
            }
            catch (Exception ex)
            {
                row = new object[] { grdDuLieu.RowCount + 1, "Error", ex.Message , DateTime.Now.ToString(), 2 };
                grdDuLieu.Rows.Add(row);
                ToMau();
                MessageBox.Show("Thực hiện không thành công." + "\n" + ex.Message);
                this.Cursor = Cursors.Default;
                return;
            }

            

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            System.Data.SqlClient.SqlTransaction tran;



            row = new object[] { grdDuLieu.RowCount + 1, FolderTB, "VER TB : " + VerTB.ToString(), DateTime.Now.ToString(), 1 };
            grdDuLieu.Rows.Add(row);
            row = new object[] { grdDuLieu.RowCount + 1, FolderCM, "VER HT : " + VerHT.ToString(), DateTime.Now.ToString(), 1 };
            grdDuLieu.Rows.Add(row);
            row = new object[] { grdDuLieu.RowCount + 1, FolderKH, "VER KH : " + VerKH.ToString(), DateTime.Now.ToString(), 1 };
            grdDuLieu.Rows.Add(row);

            row = new object[] { grdDuLieu.RowCount + 1, FolderLAN, "VER LAN : " + VerLAN.ToString(), DateTime.Now.ToString(), 1 };
            grdDuLieu.Rows.Add(row);

            row = new object[] { grdDuLieu.RowCount + 1, FolderWEB, "VER WEB : " + VerWEB.ToString(), DateTime.Now.ToString(), 1 };
            grdDuLieu.Rows.Add(row);

            this.Cursor = Cursors.WaitCursor;

            #region Table
            if (!ChayQueryNoTransaction(Commons.IConnections.ConnectionString, FolderTB, VerTB, "VER_TB"))
            {
                row = new object[] { grdDuLieu.RowCount + 1, FolderTB, "Error TB : " + VerTB, DateTime.Now.ToString(), 2 };
                grdDuLieu.Rows.Add(row);
                ToMau();
            }
            #endregion

            #region LAN
            if (!ChayQueryNoTransaction(Commons.IConnections.ConnectionString, FolderLAN, VerLAN, "VER_LAN"))
            {
                row = new object[] { grdDuLieu.RowCount + 1, FolderTB, "Error LAN : " + VerLAN, DateTime.Now.ToString(), 2 };
                grdDuLieu.Rows.Add(row);
                ToMau();
            }

            #endregion

            if (con.State == ConnectionState.Closed) con.Open();
            tran = con.BeginTransaction();
            //MessageBox.Show("Cập nhập không thành công");
            if (!ChayQuery(tran, FolderCM, VerHT, "VER_HT"))
            {
                MessageBox.Show("Cập nhập không thành công");
                row = new object[] { grdDuLieu.RowCount + 1, FolderKH, "Error HT : " + VerKH, DateTime.Now.ToString(), 2 };
                grdDuLieu.Rows.Add(row);
                tran.Rollback();
                ToMau();
                this.Cursor = Cursors.Default;
                return;
            }
            else
            {
                if (!ChayQuery(tran, FolderWEB, VerWEB, "VER_WEB"))
                {
                    MessageBox.Show("Cập nhập không thành công");
                    row = new object[] { grdDuLieu.RowCount + 1, FolderKH, "Error WEB : " + VerWEB, DateTime.Now.ToString(), 2 };
                    grdDuLieu.Rows.Add(row);

                    tran.Rollback();
                    ToMau();
                    this.Cursor = Cursors.Default;
                    return;
                }
                else
                {
                    if (Directory.Exists(FolderKH))
                    {
                        if (!ChayQuery(tran, FolderKH, VerKH, "VER_KH"))
                        {
                            MessageBox.Show("Cập nhập không thành công");
                            row = new object[] { grdDuLieu.RowCount + 1, FolderKH, "Error KH : " + VerKH, DateTime.Now.ToString(), 2 };
                            grdDuLieu.Rows.Add(row);
                            tran.Rollback();
                            ToMau();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    else
                    {
                        row = new object[] { grdDuLieu.RowCount + 1, FolderKH, "Folder KH : " + dtTmp.Rows[0]["PRIVATE"].ToString() + " not found.", DateTime.Now.ToString(), 3 };
                        grdDuLieu.Rows.Add(row);
                    }
                }
            }
            tran.Commit();


            string FolderLan = Application.StartupPath + "\\Languages";
            ToMau();

            //grdDuLieu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //int widthCol = grdDuLieu.Columns[1].Width;
            //grdDuLieu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //grdDuLieu.Columns[1].Width = widthCol;

            MessageBox.Show("Cập nhập thành công");
            LoadVerThongTin();
            this.Cursor = Cursors.Default;
        }

        private void ToMau()
        {
            //Error = 1 binh thuong
            //Error = 2 Loi


            foreach (DataGridViewRow dgvr in grdDuLieu.Rows)
            {
                if (int.Parse(dgvr.Cells["Error"].Value.ToString()) == 2)
                    dgvr.DefaultCellStyle.ForeColor = Color.Red;
                if (int.Parse(dgvr.Cells["Error"].Value.ToString()) == 3)
                    dgvr.DefaultCellStyle.ForeColor = Color.Blue;
            }
            grdDuLieu.Columns[4].Visible = false;

            grdDuLieu.AllowUserToResizeColumns = true;
            grdDuLieu.Columns[0].Width = 90;
            grdDuLieu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grdDuLieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private Boolean ChayQuery( SqlTransaction tran, string startFolder, float DK, string sCot)
        {
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
                IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
                IEnumerable<System.IO.FileInfo> fileQuery =
                     from file in fileList
                     where file.Extension == ".sql"
                     orderby file.Name
                     select file;
                var newestFile =
                (from file in fileQuery
                 where float.Parse(file.Name.Substring(0, 5)) > DK
                 orderby file.FullName.Substring(0, 5)
                 select file.FullName)
                .DefaultIfEmpty();

                if (newestFile.Count() == 0)
                {
                    object[] row = new object[] { grdDuLieu.RowCount + 1, "No file in folder" + startFolder, "Successfully", DateTime.Now.ToString(), 1 };
                    grdDuLieu.Rows.Add(row);
                    return true;
                }
                string sName = "";
                try
                {
                    foreach (string FullName in newestFile)
                    {
                        if (string.IsNullOrEmpty(FullName))
                        {
                            object[] row = new object[] { grdDuLieu.RowCount + 1, "File is null or No file in folder " + startFolder + ". Query now in database " + Convert.ToString(DK), "Successfully", DateTime.Now.ToString(), 1 };
                            grdDuLieu.Rows.Add(row);
                        }
                        else
                        {
                            string script = File.ReadAllText(FullName);
                            sName = FullName;
                            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                                     RegexOptions.Multiline | RegexOptions.IgnoreCase);
                            foreach (string commandString in commandStrings)
                            {
                                if (commandString.Trim() != "")
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, commandString);
                            }
                            string sSql = "";
                            sSql = "UPDATE THONG_TIN_CHUNG SET " + sCot + " = " + FullName.Replace(startFolder + "\\", "").Substring(0, 5);
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);
                            object[] row = new object[] { grdDuLieu.RowCount + 1, FullName, "Query executed successfully", DateTime.Now.ToString(), 1 };
                            grdDuLieu.Rows.Add(row);
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    object[] row = new object[] { grdDuLieu.RowCount + 1, sName, "Error : " + ex.ToString(), DateTime.Now.ToString(), 2 };
                    grdDuLieu.Rows.Add(row);
                    return false;
                }
            }
            catch (Exception ex)
            {
                object[] row = new object[] { grdDuLieu.RowCount + 1, "Folder not found : " + startFolder, "Error : " + ex.Message.ToString(), DateTime.Now.ToString(), 2 };
                grdDuLieu.Rows.Add(row);
                return false;
            }
            
        }
        

        private Boolean ChayQueryNoTransaction(string SqlConnect, string startFolder, float DK, string sCot)
        {
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
                IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
                IEnumerable<System.IO.FileInfo> fileQuery =
                     from file in fileList
                     where file.Extension == ".sql"
                     orderby file.Name
                     select file;
                var newestFile =
                (from file in fileQuery
                 where float.Parse(file.Name.Substring(0, 5)) > DK
                 orderby file.FullName.Substring(0, 5)
                 select file.FullName)
                .DefaultIfEmpty();

                if (newestFile.Count() == 0)
                {
                    object[] row = new object[] { grdDuLieu.RowCount + 1, "No file in folder" + startFolder, "Successfully", DateTime.Now.ToString(), 1 };
                    grdDuLieu.Rows.Add(row);
                    return true;
                }
                string sName = "";
                try
                {
                    foreach (string FullName in newestFile)
                    {
                        if (string.IsNullOrEmpty(FullName))
                        {
                            object[] row = new object[] { grdDuLieu.RowCount + 1, "File is null or No file in folder " + startFolder + ". Query now in database " + Convert.ToString(DK), "Successfully", DateTime.Now.ToString(), 1 };
                            grdDuLieu.Rows.Add(row);
                        }
                        else
                        {
                            string script = File.ReadAllText(FullName);
                            sName = FullName;
                            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                                     RegexOptions.Multiline | RegexOptions.IgnoreCase);
                            //foreach (string commandString in commandStrings)
                            //{
                            //    if (commandString.Trim() != "")
                            //        SqlHelper.ExecuteNonQuery(SqlConnect, CommandType.Text, commandString);
                            //}
                            string sSql;

                            sSql = "UPDATE THONG_TIN_CHUNG SET " + sCot + " = " + FullName.Replace(startFolder + "\\", "").Substring(0, 5);
                            //SqlHelper.ExecuteNonQuery(SqlConnect, CommandType.Text, sSql);
                            
                            object[] row = new object[] { grdDuLieu.RowCount + 1, FullName, "Query executed successfully", DateTime.Now.ToString(), 1 };
                            grdDuLieu.Rows.Add(row);
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    object[] row = new object[] { grdDuLieu.RowCount + 1, sName, "Error : " + ex.ToString(), DateTime.Now.ToString(), 2 };
                    grdDuLieu.Rows.Add(row);
                    return false;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    object[] row = new object[] { grdDuLieu.RowCount + 1, "Folder not found : " + startFolder, "Error : " + ex.Message.ToString(), DateTime.Now.ToString(), 2 };
                    grdDuLieu.Rows.Add(row);
                }
                catch { }
                return false;
            }
        }

        private void btnNN_Click(object sender, EventArgs e)
        {
            if (!KiemConnect()) return;
            DataTable dtTmp = new DataTable();
            grdDuLieu.DataSource = null;

            grdDuLieu.Columns.Clear();
            grdDuLieu.Columns.Add("No.", "No.");
            grdDuLieu.Columns.Add("Query", "Query");
            grdDuLieu.Columns.Add("Action", "Action");
            grdDuLieu.Columns.Add("Time", "Time");
            grdDuLieu.Columns.Add("Error", "Error");
            object[] row = new object[] { 1, Commons.IConnections.Server, Commons.IConnections.Database, DateTime.Now.ToString(), 1 };
            grdDuLieu.Rows.Add(row);            
            string FolderLAN = Application.StartupPath + "\\Languages";
                       
            
            #region Languages
            if (txtLan.Text != "")
            {
                ChayQueryNoTransaction(Commons.IConnections.ConnectionString, FolderLAN, float.Parse(txtLan.Text), "VER_LAN");
            }
            else
                ChayQueryNoTransaction(Commons.IConnections.ConnectionString, FolderLAN, 0, "VER_LAN");
            #endregion

            cboData_SelectedIndexChanged(sender, e);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (txtVer.Text.Trim() == "")
            {
                return;
            }
            Commons.Modules.SQLString = "CAPNHAPVER";
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            string sSql = "";
            sSql = "UPDATE THONG_TIN_CHUNG SET VER = N'" +  txtVer.Text + "'  ";
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                MessageBox.Show("Cập nhập thành công");
            }
            catch { MessageBox.Show("Cập nhập không thành công"); }
        }

        private void grdDuLieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                try
                {
                    System.Diagnostics.Process.Start(grdDuLieu.CurrentCell.Value.ToString());
                }
                catch { }
            }
        }

        private void cboData_SelectedIndexChanged(object sender, EventArgs e)
        {
            Commons.IConnections.Database = cboData.Text;
            LoadVerThongTin();
        }
    }
}
