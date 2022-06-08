using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class ucKeHoachKiemDinhNam : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKeHoachKiemDinhNam()
        {
            InitializeComponent();
        }
#region "Load form"
        private void LoadLoaiMay()
        {
            string sSql = "";

            try
            {
                sSql = " SELECT DISTINCT E.MS_LOAI_MAY, F.TEN_LOAI_MAY FROM dbo.HIEU_CHUAN_DHD AS A INNER JOIN " +
                            " dbo.CHU_KY_HIEU_CHUAN AS B ON A.MS_MAY = B.MS_MAY AND A.MS_PT = B.MS_PT AND A.MS_VI_TRI = B.MS_VI_TRI INNER JOIN " +
                            " dbo.MAY AS D ON B.MS_MAY = D.MS_MAY INNER JOIN " +
                            " dbo.NHOM_MAY AS E ON D.MS_NHOM_MAY = E.MS_NHOM_MAY INNER JOIN " +
                            " dbo.LOAI_MAY AS F ON E.MS_LOAI_MAY = F.MS_LOAI_MAY " +
                            " WHERE MS_LOAI_HIEU_CHUAN = 3 UNION SELECT '-1',' < ALL > ' ORDER BY TEN_LOAI_MAY";

                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,sSql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, _table, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }

            try
            {
                sSql = "SELECT DISTINCT D.MS_LOAI_VT, " +
                            " CASE WHEN 0 = " + Commons.Modules.TypeLanguage + " THEN TEN_LOAI_VT_TV ELSE TEN_LOAI_VT_TA END AS TEN_LOAI_VT " +
                            " FROM dbo.HIEU_CHUAN_DHD AS A INNER JOIN dbo.CHU_KY_HIEU_CHUAN AS B ON  " +
                            " A.MS_MAY = B.MS_MAY AND A.MS_PT = B.MS_PT AND A.MS_VI_TRI = B.MS_VI_TRI INNER JOIN " +
                            " dbo.IC_PHU_TUNG AS C ON A.MS_PT = C.MS_PT INNER JOIN " +
                            " dbo.LOAI_VT D ON C.MS_LOAI_VT = D.MS_LOAI_VT " +
                            " WHERE MS_LOAI_HIEU_CHUAN = 3  UNION SELECT '-1',' < ALL > ' ORDER BY TEN_LOAI_VT ";
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLVatTu, _table, "MS_LOAI_VT", "TEN_LOAI_VT", lblLMay.Text);
            }
            catch { }        
        }

        private void LoadNhomMay()
        {
            try
            {
                string sSql;
                sSql = " SELECT DISTINCT D.MS_NHOM_MAY, E.TEN_NHOM_MAY FROM dbo.HIEU_CHUAN_DHD AS A " +
                            " INNER JOIN dbo.CHU_KY_HIEU_CHUAN AS B ON A.MS_MAY = B.MS_MAY AND A.MS_PT = B.MS_PT " +
                            " AND A.MS_VI_TRI = B.MS_VI_TRI INNER JOIN dbo.MAY AS D ON B.MS_MAY = D.MS_MAY INNER JOIN " +
                            " dbo.NHOM_MAY AS E ON D.MS_NHOM_MAY = E.MS_NHOM_MAY  WHERE ( '-1' = '" + cboLMay.EditValue + "' " +
                            " OR MS_LOAI_MAY = '" + cboLMay.EditValue + "' )  AND ( MS_LOAI_HIEU_CHUAN = 3 ) " +
                            " UNION SELECT '-1',' < ALL > ' ORDER BY TEN_NHOM_MAY";
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, _table, "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNhomMay.Text);
            }
            catch { }
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
            LocDuLieu();
        }

        private void LoadMay()
        {
            string sSql = "";
            sSql = "SELECT DISTINCT CONVERT(BIT,1) AS CHON , A.MS_MAY, D.TEN_MAY, dbo.LOAI_VT.MS_LOAI_VT, E.MS_NHOM_MAY, E.MS_LOAI_MAY " +
                        " FROM dbo.HIEU_CHUAN_DHD AS A INNER JOIN " +
                        " dbo.CHU_KY_HIEU_CHUAN AS B ON A.MS_MAY = B.MS_MAY AND A.MS_PT = B.MS_PT AND A.MS_VI_TRI = B.MS_VI_TRI INNER JOIN " +
                        " dbo.IC_PHU_TUNG AS C ON A.MS_PT = C.MS_PT INNER JOIN " +
                        " dbo.MAY AS D ON B.MS_MAY = D.MS_MAY INNER JOIN " +
                        " dbo.NHOM_MAY AS E ON D.MS_NHOM_MAY = E.MS_NHOM_MAY INNER JOIN " +
                        " dbo.LOAI_VT ON C.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT WHERE  MS_LOAI_HIEU_CHUAN = 3 ";
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns[0].ReadOnly = false;
            for (int i = 1; i < dtTmp.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, true, false, false);
            grvMay.Columns["MS_LOAI_VT"].Visible = false;
            grvMay.Columns["MS_NHOM_MAY"].Visible = false;
            grvMay.Columns["MS_LOAI_MAY"].Visible = false;

            grvMay.Columns["CHON"].Width = 50;
            grvMay.Columns["MS_MAY"].Width = 100;
            grvMay.Columns["TEN_MAY"].Width = 200;
            grvMay.OptionsView.ColumnAutoWidth = true;
            //grvMay.BestFitColumns();
            grvMay.Columns["CHON"].Width = 50;
        }

        private void LocDuLieu()
        {
            try
            {
                ChooseAll(false, grvMay);
                DataTable dtMay = new DataTable();
                dtMay = (DataTable)grdMay.DataSource;

                try
                {
                    string dk = "";

                    if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (cboLMay.EditValue.ToString().Trim() != "-1") dk = " OR  MS_LOAI_MAY LIKE '%" + cboLMay.EditValue + "%' " + dk;
                    if (cboNhomMay.EditValue.ToString().Trim() != "-1") dk = " OR  MS_NHOM_MAY LIKE '%" + cboNhomMay.EditValue + "%' " + dk;
                    if (cboLVatTu.EditValue.ToString().Trim() != "-1") dk = " OR  MS_LOAI_VT LIKE '%" + cboLVatTu.EditValue + "%' " + dk;


                    if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                    dtMay.DefaultView.RowFilter = dk;

                }
                catch { dtMay.DefaultView.RowFilter = ""; }
                ChooseAll(true, grvMay);
            }
            catch { }
        }

        private void cboLVatTu_EditValueChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LocDuLieu();
        }

        private Boolean KiemDLieu()
        {

            if (datNam.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "ChuaChonNam", Commons.Modules.TypeLanguage));
                datNam.Focus();
                return false;
            }
            if (cboLVatTu.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "ChuaChonLVatTu", Commons.Modules.TypeLanguage));
                cboLVatTu.Focus();
                return false;
            }

            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "ChuaChonLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return false;
            }
            if (cboNhomMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "ChuaChonNhomMay", Commons.Modules.TypeLanguage));
                cboNhomMay.Focus();
                return false;
            }

             
            #region Lay du lieu chon in
            DataTable dtTmp = new DataTable();
            DataTable dtTmp1 = new DataTable();

            dtTmp1 = (DataTable)grdMay.DataSource;
            dtTmp = dtTmp1.DefaultView.ToTable();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachKiemDinhNam", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                return false;
            }
            #endregion
            return true;
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvMay);

        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvMay);

        }

        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
                view.UpdateCurrentRow();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

#endregion

        private void ucKeHoachKiemDinhNam_Load(object sender, EventArgs e)
        {
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grdChung.Visible = true;
            else grdChung.Visible = false;
            Commons.Modules.SQLString = "0load";
            datNam.DateTime = DateTime.Now;
            LoadLoaiMay();
            LoadMay();
            Commons.Modules.SQLString = "";
        }

        private void TaoDuLieu(string Nam)
        {
            string sSelect, sBTam, sBangTam, sSql = "";
            DateTime NgayBD, NgayKT;
            NgayBD = DateTime.Parse("01/01/" + Nam);
            NgayKT= DateTime.Parse("31/12/" + Nam);
            sBTam = "CKHC_IN_TMP" + Commons.Modules.UserName;
            sBangTam = "CKHC_TMP" + Commons.Modules.UserName;
            sSelect = "";

            DataTable dtNgayKD = new DataTable();
            dtNgayKD.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNgayKDKe", NgayBD, NgayKT));

            for (int i = 1; i <= 12; i++)
            {
                sSql += " , CONVERT (NVARCHAR(10) ,'') AS [" + NgayBD.ToString("MM/yyyy") + "]";
                sSelect += " ,[" + NgayBD.ToString("MM/yyyy") + "] AS [THANG_" + i.ToString() + "]";
                NgayBD = NgayBD.AddMonths(1);
            }
            Commons.Modules.ObjSystems.XoaTable(sBTam);

            sSql = " SELECT TOP 0 MS_MAY, MS_PT, MS_VI_TRI " + sSql + " INTO " + sBTam + " FROM CHU_KY_HIEU_CHUAN ";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

            sBangTam = "CKHC_TMP" + Commons.Modules.UserName;

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBangTam, dtNgayKD, "");

            DataTable dtTmp = new DataTable();
            string sBTMay = "ZZZ_CHON_MAY" + Commons.Modules.UserName;

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTMay, (DataTable)grdMay.DataSource, "");

            sSql = "INSERT INTO " + sBTam + " (MS_MAY,MS_PT,MS_VI_TRI) SELECT DISTINCT A.MS_MAY,A.MS_PT,A.MS_VI_TRI FROM " + sBangTam + 
                " A INNER JOIN " +  sBTMay + " B ON A.MS_MAY = B.MS_MAY WHERE CHON = 1" ;
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM " + sBTam));
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                Commons.Modules.SQLString = "0CoDuLieuIn";
                return;
            }

            DateTime NgayKTIn;
            NgayKTIn = DateTime.Parse("31/12/" + Nam);
            int iSoTuanKT;
            iSoTuanKT = 1;
            //iSoTuanKT = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
            //        "select dbo.isweekofYear('" + NgayKTIn.ToString("MM/dd/yyyy") + "')"));

            iSoTuanKT = Microsoft.VisualBasic.DateAndTime.DatePart("ww",NgayKTIn , Microsoft.VisualBasic.FirstDayOfWeek.Monday, Microsoft.VisualBasic.FirstWeekOfYear.FirstFourDays);

            for (int i = 1; i <= 12; i++)
            {
                NgayBD = DateTime.Parse(i.ToString()  + "/" + Nam);
                NgayKT = NgayBD.AddMonths(1).AddDays(-1);

                sSql = "SELECT * FROM " +  sBangTam + " WHERE NGAY_KE BETWEEN '" + 
                    NgayBD.ToString("MM/dd/yyyy") + "' AND '" + NgayKT.ToString("MM/dd/yyyy") + "'";
                dtNgayKD = new DataTable();
                dtNgayKD.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));

                foreach (DataRow dRow in dtNgayKD.Rows)
                {
#region In Ngay MS_DV_TG = 1
                    if (int.Parse(dRow["MS_DV_TG"].ToString()) == 1)
                    {

                        DateTime NgayHT, NgayCuoi;
                        NgayHT = DateTime.Parse(dRow["NGAY_KE"].ToString());
                        NgayCuoi = NgayKTIn;
                        int k =0;
                        while (NgayCuoi > NgayHT) // at least one time
                        {
                            NgayHT = DateTime.Parse(dRow["NGAY_KE"].ToString());
                            NgayHT = NgayHT.AddDays(k);
                            k = k + int.Parse(dRow["CHU_KY_KD"].ToString());
                            if (NgayHT <= NgayKTIn)
                            {

                                sSql = "UPDATE " + sBTam + " SET [" + NgayHT.ToString("MM/yyyy") + "] = 'X' WHERE MS_MAY = N'" + dRow["MS_MAY"].ToString() +
                                            "' AND MS_PT = N'" + dRow["MS_PT"].ToString() +
                                            "' AND MS_VI_TRI = N'" + dRow["MS_VI_TRI"].ToString() + "'  ";
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                            }
                            else
                                break;

                        }

                    }
#endregion

#region In Tuan MS_DV_TG = 2
                    if (int.Parse(dRow["MS_DV_TG"].ToString()) == 2)
                    {
                        int iSoTuan;
                        iSoTuan = 1;
                        
                        DateTime Thang;
                        Thang = DateTime.Parse(dRow["NGAY_KE"].ToString());
                        iSoTuan = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                                        "select dbo.isweekofYear('" + Thang.ToString("MM/dd/yyyy") + "')"));

                        iSoTuan = Microsoft.VisualBasic.DateAndTime.DatePart("ww",Thang , Microsoft.VisualBasic.FirstDayOfWeek.Monday, Microsoft.VisualBasic.FirstWeekOfYear.FirstFourDays);
                        //Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                        //    "SELECT DatePart(ww,'" + ThangIn.ToString("MM/dd/yyyy") + "')"));
                        
                        int k = 0;
                        for (int j = iSoTuan; j <= iSoTuanKT; )
                        {
                            if (Thang <= NgayKTIn)
                            {
                                Thang = DateTime.Parse(dRow["NGAY_KE"].ToString());                                
                                Thang = Thang.AddDays(7 * k);
                                k = k + int.Parse(dRow["CHU_KY_KD"].ToString());
                                j = j + int.Parse(dRow["CHU_KY_KD"].ToString());
                                if (Thang <= NgayKT)
                                {
                                    sSql = "UPDATE " + sBTam + " SET [" + Thang.ToString("MM/yyyy") + "] = 'X' WHERE MS_MAY = N'" + dRow["MS_MAY"].ToString() +
                                                "' AND MS_PT = N'" + dRow["MS_PT"].ToString() +
                                                "' AND MS_VI_TRI = N'" + dRow["MS_VI_TRI"].ToString() + "'  ";
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                                }
                                else break;
                            }
                            else
                                break;
                        }
                    }
#endregion

#region In Thang  MS_DV_TG = 3
                    if (int.Parse(dRow["MS_DV_TG"].ToString()) == 3)
                    {
                        DateTime Thang;
                        Thang = DateTime.Parse(dRow["NGAY_KE"].ToString());
                        int k = 0;

                        for (int j = Thang.Month; j <= DateTime.Parse("31/12/" + Nam).Month; )
                        {
                            if (Thang <= NgayKTIn)
                            {
                                Thang = DateTime.Parse(dRow["NGAY_KE"].ToString());
                                Thang = Thang.AddMonths(k);
                                k = k + int.Parse(dRow["CHU_KY_KD"].ToString());
                                j = j + int.Parse(dRow["CHU_KY_KD"].ToString());

                                if (Thang <= NgayKTIn)
                                {
                                    sSql = "UPDATE " + sBTam + " SET [" + Thang.ToString("MM/yyyy") + "] = 'X' WHERE MS_MAY = N'" + dRow["MS_MAY"].ToString() +
                                        "' AND MS_PT = N'" + dRow["MS_PT"].ToString() +
                                        "' AND MS_VI_TRI = N'" + dRow["MS_VI_TRI"].ToString() + "'  ";
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                                }
                                else
                                    break;
                            }
                            else
                                break;
                        }
                    }
#endregion

#region In Nam MS_DV_TG = 4
                    if (int.Parse(dRow["MS_DV_TG"].ToString()) == 4)
                    {

                        DateTime NgayHT;
                        NgayHT = DateTime.Parse(dRow["NGAY_KE"].ToString());

                        sSql = "UPDATE " + sBTam + " SET [" + NgayHT.ToString("MM/yyyy") + "] = 'X' WHERE MS_MAY = N'" + dRow["MS_MAY"].ToString() +
                                    "' AND MS_PT = N'" + dRow["MS_PT"].ToString() +
                                    "' AND MS_VI_TRI = N'" + dRow["MS_VI_TRI"].ToString() + "'  ";
                        try
                        {
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        }
                        catch { }

                    }
#endregion
                }

            }

            sSql = " SELECT CONVERT(INT, NULL) AS STT, A.MS_PT, B.TEN_PT , C.GHI_CHU, D.TEN_MAY, A.MS_VI_TRI, CONVERT(INT, 1) AS SL, " +
                        " C.CHU_KY_KD, E.TEN_DV_TG " + sSelect +
                        " FROM " + sBTam + " AS A INNER JOIN dbo.IC_PHU_TUNG AS B ON  " +
                        " A.MS_PT = B.MS_PT INNER JOIN dbo.CHU_KY_HIEU_CHUAN AS C ON A.MS_MAY = C.MS_MAY AND A.MS_PT = C.MS_PT  " +
                        " AND A.MS_VI_TRI = C.MS_VI_TRI INNER JOIN dbo.MAY AS D ON C.MS_MAY = D.MS_MAY INNER JOIN " +
                        " dbo.DON_VI_THOI_GIAN AS E ON C.MS_DV_TG = E.MS_DV_TG " +
                        " ORDER BY A.MS_MAY, D.TEN_MAY, C.GHI_CHU ";

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["STT"].ReadOnly = false;
            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }


            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, false, false, true, "ucKeHoachKiemDinhNam");

            Commons.Modules.ObjSystems.XoaTable(sBTam);
            Commons.Modules.ObjSystems.XoaTable(sBTMay);
            Commons.Modules.ObjSystems.XoaTable(sBangTam);
        }

        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();
            Excel.Range title;
            try
            {
                int TCot = grvChung.Columns.Count + 1;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11 + 12 ;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;

                grdChung.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                excelApplication.Cells.Font.Name = "Times New Roman";
                excelApplication.Cells.Font.Size = 10;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                if (cboLVatTu.EditValue.ToString() != "-1")
                    Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);
                else
                    Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong);
                int SCot;

                SCot = TCot;// (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                 
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachKiemDinhNam", "TieuDe", Commons.Modules.TypeLanguage) + " " + datNam.DateTime.Year.ToString()
                    , Dong, 1, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                if (cboLVatTu.EditValue.ToString() != "-1")
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, cboLVatTu.Text.ToUpper(), Dong, 1, "@", 12, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (cboLVatTu.EditValue.ToString() != "-1")
                    Dong = Dong + 2;
                else
                    Dong = Dong + 1;

                for (int Cot = 1; Cot <= 9; Cot++)
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, Cot, Dong + 1, Cot);
                    title.MergeCells = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "TGChuanHoaThang", Commons.Modules.TypeLanguage)
                    , Dong, 10, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 21);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, 
                    "ucKeHoachKiemDinhNam", "DVChuanHoa", Commons.Modules.TypeLanguage) , Dong, 22, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 22);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucKeHoachKiemDinhNam", "PKT", Commons.Modules.TypeLanguage), Dong, 22, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 22);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong-1, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;


                

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong-1, 1, Dong, TCot);
                title.Font.Bold = true;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);
                

                if (cboLVatTu.EditValue.ToString() != "-1")
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 5, 1, Dong - 5, 1);
                else
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 4, 1, Dong - 4, 1);

                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 2, 1, Dong - 2, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                //6	18	20	20	30	15	5	7	10	2	2	2	2	2	2	2	2	2	2	2	2	15


                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 6, "@", true, Dong, 1, Dong,1 );
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong, 2, Dong,2 );
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong, 3, Dong,3 );
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong, 4, Dong,4 );
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", true, Dong, 5, Dong,5 );
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong, 6, Dong,6 );
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "@", true, Dong, 7, Dong,7 );
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "@", true, Dong, 8, Dong,8 );
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", true, Dong, 9, Dong,9 );
                for (int Cot = 10; Cot <= TCot - 1; Cot++)
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, Cot, Dong, Cot);
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    title.Value2 = Cot - 9;
                    title.NumberFormat = "##";

                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 3, "@", true, Dong, Cot, Dong, Cot);
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, Cot, TDong + Dong, Cot);
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                }
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong, TCot, Dong, TCot);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong-1, 1, Dong, TCot);
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 2, 1], excelWorkSheet.Cells[Dong - 2, 1]).Interior.Color;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                if (cboLVatTu.EditValue.ToString() != "-1")
                    Dong = TDong + 12;
                else
                    Dong = TDong + 11;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;
                 
                string sTmp = "";
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "GhiChu1", Commons.Modules.TypeLanguage);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 1, SCot);
                title.MergeCells = true;
                title.Font.Size = 12;
                title.Value2 = sTmp;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                Dong = Dong + 2;
                sTmp = "";
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "GhiChu2", Commons.Modules.TypeLanguage);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 1, SCot);
                title.MergeCells = true;
                title.Font.Size = 12;
                title.Value2 = sTmp;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                Dong = Dong + 3;
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "BacLieu", Commons.Modules.TypeLanguage) + ", " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "Ngay", Commons.Modules.TypeLanguage) + "     " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "Thang", Commons.Modules.TypeLanguage) + "     " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "Nam", Commons.Modules.TypeLanguage) + "     ";

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 10, "@", 12, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                Dong++;

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "GiamDoc", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 12, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 4);

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "TPKTKN", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 5, "@", 12, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 9);


                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "LapBang", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 10, "@", 12, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                Dong = Dong + 6;

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "LuuY", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 12, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                Dong++;
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "XuongSX", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 2, "@", 12, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                
                excelApplication.Visible = true;
                excelWorkbook.Save();
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKeHoachKiemDinhNam", "InKhongThanhCong", Commons.Modules.TypeLanguage));
                excelApplication.Visible = true;

            }

            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "";
            if (!KiemDLieu()) return;
            TaoDuLieu(datNam.Text);
            if (Commons.Modules.SQLString == "0CoDuLieuIn") return;
            InDuLieu();
            
        }



    }
}
