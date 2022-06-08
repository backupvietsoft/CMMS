using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;


namespace ReportHuda.UControl
{
    public partial class ucMTTRMTBF : DevExpress.XtraEditors.XtraUserControl
    {
        public ucMTTRMTBF()
        {
            InitializeComponent();
        }

        private void ucMTTRMTBF_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (System.Environment.MachineName.ToUpper() == "MASHIMARO") grdChung.Visible = true; else grdChung.Visible = false;

                DateTime Ngay;
                Commons.Modules.SQLString = "0Load";

                Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
                datTThang.DateTime = Ngay.AddMonths(-6);
                datDThang.DateTime = Ngay.AddMonths(1).AddDays(-1);
            

                LoadNX();
                LoadDChuyen();
                LoadLoaiMay();
                Commons.Modules.SQLString = "";
                LoadMay();
               
                lblTongSo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucMTTRMTBF", "lblTSo", Commons.Modules.TypeLanguage) + " : " + grvMay.RowCount.ToString() + "   ";

                grvMay.Columns["CHON"].Width = 100;
                grvMay.Columns["MS_MAY"].Width = 150;
                grvMay.Columns["TEN_MAY"].Width = 500;
                grvMay.Columns["MODEL"].Width = 500;
            }
            catch { }
            
        }
#region Load Du Lieu


        private void LoadNX()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = Commons.Modules.ObjSystems.MLoadDataNhaXuong(0,"-1","-1","-1");
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem,dtTmp,"MS_N_XUONG", "TEN_N_XUONG","");
            }
            catch { }
        }        
        private void LoadDChuyen()
        {
            try
            {

                DataTable dtTmp = new DataTable();
                dtTmp = Commons.Modules.ObjSystems.MLoadDataDayChuyen(1);
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen,dtTmp,"MS_HE_THONG", "TEN_HE_THONG","");
            }
            catch { }
        }
        private void LoadLoaiMay()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = Commons.Modules.ObjSystems.MLoadDataLoaiMay(1);
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");


            }
            catch { }
        }
        private void LoadMay()
        {
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;
                //DataTable dtTmp = new DataTable();
                DateTime TThang, DThang;
                TThang = Convert.ToDateTime("01/" + datTThang.DateTime.Month + "/" + datTThang.DateTime.Year);
                DThang = Convert.ToDateTime("01/" + datDThang.DateTime.Month + "/" + datDThang.DateTime.Year);

                //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMayMTTRMTBF",
                //            DThang, cboTinh.EditValue, cboQuan.EditValue, cboDuong.EditValue,
                //            cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue));
                //dtTmp.Columns["CHON"].ReadOnly = false;
                //Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, false, true, false);

                //dtTmp.Columns["MS_MAY"].ReadOnly = true;
                //dtTmp.Columns["TEN_MAY"].ReadOnly = true;
                //dtTmp.Columns["MODEL"].ReadOnly = true;

                //lblTongSo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                //        "ucMTTRMTBF", "lblTSo", Commons.Modules.TypeLanguage) + " : " + grvMay.RowCount.ToString() + "   ";


                DataTable dtTmp = new DataTable();
                string sSql;
                sSql = " SELECT  DISTINCT CONVERT(BIT,0) AS CHON, MS_MAY,TEN_MAY, Ten_N_XUONG, TEN_HE_THONG,TEN_LOAI_MAY FROM dbo.MGetMayUserNgay('" + DThang.ToString("MM/dd/yyyy") + "','" + Commons.Modules.UserName +
                        "' , '" + cboDDiem.EditValue.ToString() + "','" + cboDChuyen.EditValue.ToString() + "',-1, '" + cboLMay.EditValue.ToString() +
                        "','-1','-1'," + Commons.Modules.TypeLanguage + ") A  ORDER BY Ten_N_XUONG, TEN_HE_THONG, MS_MAY";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));

                dtTmp.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, false, true, false);

                dtTmp.Columns["MS_MAY"].ReadOnly = true;
                dtTmp.Columns["TEN_MAY"].ReadOnly = true;
                dtTmp.Columns["MODEL"].ReadOnly = true;                


            }
            catch
            { }        
        }

        public static int MonthDiff(DateTime from, DateTime to)
        {
            if (from > to)
            {
                var temp = from;
                from = to;
                to = temp;
            }

            var months = 0;
            while (from <= to) // at least one time
            {
                from = from.AddMonths(1);
                months++;
            }

            return months - 1;
        }

        private void cboTinh_EditValueChanged(object sender, EventArgs e)
        {
            LoadNX();
        }

        private void cboQuan_EditValueChanged(object sender, EventArgs e)
        {
            LoadNX();
        }

        private void cboDuong_EditValueChanged(object sender, EventArgs e)
        {
            LoadNX();
        }
#endregion

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            LoadData();
            this.Cursor = Cursors.Default;
        }

        private Boolean KiemDLieu()
        {
            #region Kiem Du Lieu
            DateTime TThang, DThang;
            if (datTThang.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "KhongCoTuThang", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return false;
            }
            if (datDThang.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "KhongCoDenThang", Commons.Modules.TypeLanguage));
                datDThang.Focus();
                return false;
            }

            TThang = Convert.ToDateTime("01/" + datTThang.DateTime.Month + "/" + datTThang.DateTime.Year);
            DThang = Convert.ToDateTime("01/" + datDThang.DateTime.Month + "/" + datDThang.DateTime.Year);
            if (TThang >= DThang)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "TuThangLonHonDenThang", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return false;

            }
            int SoThang = MonthDiff(DThang, TThang);

            if (SoThang < 2)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "LonHonMotThang", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return false;

            }

            if (SoThang > 24)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "LonHonHaiNam", Commons.Modules.TypeLanguage));
                datTThang.Focus();
                return false;

            }


            if (cboDDiem.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return false;
            }

            if (cboDChuyen.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }

            if (cboLMay.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return false;
            }

            #endregion

            #region Lay du lieu chon in
            DataTable dtTmp = new DataTable();
            DataTable dtTmp1 = new DataTable();

            dtTmp1 = (DataTable)grdMay.DataSource;
            dtTmp = dtTmp1.DefaultView.ToTable();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuDoChiPhiTheoNX", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                return false;
            }
#endregion  

            return true;
        }

        private void LoadData()
        {
            string  sql, sA, sB, sC, sD, sE, SCot;
            string BTam;
            BTam = "BTMTTR" + Commons.Modules.UserName;

            DateTime TThang, DThang;
            TThang = Convert.ToDateTime("01/" + datTThang.DateTime.Month + "/" + datTThang.DateTime.Year);
            DThang = Convert.ToDateTime("01/" + datDThang.DateTime.Month + "/" + datDThang.DateTime.Year);
            string sMayuser;
            sMayuser = "MAY_USER" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.XoaTable(sMayuser);

            sql = " SELECT DISTINCT * INTO " + sMayuser + " FROM dbo.MGetMayUserNgay('" + DThang.ToString("MM/dd/yyyy") + "','" + Commons.Modules.UserName +
                    "' , '" + cboDDiem.EditValue.ToString() + "','" + cboDChuyen.EditValue.ToString() + "',-1, '" + cboLMay.EditValue.ToString() + 
                    "','-1','-1'," + Commons.Modules.TypeLanguage + ") A ";
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql);
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdMay.DataSource).Copy();            
            dtTmp.DefaultView.RowFilter = "CHON = TRUE";
            dtTmp = dtTmp.DefaultView.ToTable();

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString,BTam,dtTmp,"");



            string sTongA, sTongB, sTongC, sTongD, sTongE;

            sA = ""; sB = ""; sC = ""; sD = ""; sE = ""; SCot = "";
            sTongA = ""; sTongB = ""; sTongC = ""; sTongD = ""; sTongE = "";

            int iSoNgay;
            iSoNgay = 0;
            for (DateTime Thang = TThang; Thang <= DThang; )
            {
                DateTime TNgay, DNgay;
                TNgay = Convert.ToDateTime("01/" + Thang.Month + "/" + Thang.Year);
                DNgay = Thang.AddMonths(1).AddDays(-1);

                string sNgayNghi = "SELECT DBO.MNgayNghiTrongThang ('" + TNgay.ToString("MM/dd/yyyy") + "')";
                try
                {
                    sNgayNghi = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sNgayNghi));
                }
                catch { sNgayNghi = "0"; }

                iSoNgay = iSoNgay + int.Parse(sNgayNghi);

                sA = sA + " , CONVERT (FLOAT,DBO.MNgayNghiTrongThang ('" + TNgay.ToString("MM/dd/yyyy") + "') ) AS [" + Thang.ToString("MM/yyyy") + "] ";

                sTongA = sTongA + " + ISNULL([" + Thang.ToString("MM/yyyy") + "],0) ";

                sB = sB + " , CONVERT (FLOAT,DBO.MGetTGNMay('" + TNgay.ToString("MM/dd/yyyy") + "', '" + DNgay.ToString("MM/dd/yyyy") + "',A.MS_MAY ) ) * 60 AS [" + Thang.ToString("MM/yyyy") + "] ";
                sTongB = sTongB + " + ISNULL([" + Thang.ToString("MM/yyyy") + "],0) ";

                sC = sC + " , CONVERT (FLOAT,DBO.MGetSLanNgungMay('" + TNgay.ToString("MM/dd/yyyy") + "', '" + DNgay.ToString("MM/dd/yyyy") + "',A.MS_MAY ) ) AS [" + Thang.ToString("MM/yyyy") + "] ";
                //(B*60)/c
                //MTTR thoi gian ngung may / so lan hu hong
                sD = sD + " , CONVERT (FLOAT, CASE " +
                    " DBO.MGetSLanNgungMay('" + TNgay.ToString("MM/dd/yyyy") + "', '" + DNgay.ToString("MM/dd/yyyy") + "',A.MS_MAY ) WHEN 0 THEN 0 ELSE " +
                    " ( DBO.MGetTGNMay('" + TNgay.ToString("MM/dd/yyyy") + "', '" + DNgay.ToString("MM/dd/yyyy") + "',A.MS_MAY ) * 60 ) / " +
                    " DBO.MGetSLanNgungMay('" + TNgay.ToString("MM/dd/yyyy") + "', '" + DNgay.ToString("MM/dd/yyyy") + "',A.MS_MAY ) END " +
                    " ) AS [" + Thang.ToString("MM/yyyy") + "] ";
                //(A-B)/C Nếu C=0 thì =A
                //MTBF case so lan ngung may neu = 0 thi lay MNgayNghiTrongThang  else( MNgayNghiTrongThang - (MGetTGNMay/60)) / so lan hu hong

                


                sE = sE + " , CONVERT (FLOAT, CASE " +
                    " DBO.MGetSLanNgungMay('" + TNgay.ToString("MM/dd/yyyy") + "', '" + DNgay.ToString("MM/dd/yyyy") + "',A.MS_MAY ) WHEN 0 " +
                    " THEN DBO.MNgayNghiTrongThang ('" + TNgay.ToString("MM/dd/yyyy") + "') ELSE " +
                    " ( DBO.MNgayNghiTrongThang ('" + TNgay.ToString("MM/dd/yyyy") + "') - DBO.MGetTGNMay('" + TNgay.ToString("MM/dd/yyyy") + "', '" + DNgay.ToString("MM/dd/yyyy") + "',A.MS_MAY )  ) / " +
                    " DBO.MGetSLanNgungMay('" + TNgay.ToString("MM/dd/yyyy") + "', '" + DNgay.ToString("MM/dd/yyyy") + "',A.MS_MAY ) END " +
                    " ) AS [" + Thang.ToString("MM/yyyy") + "] ";

                SCot = SCot + " , [" + Thang.ToString("MM/yyyy") + "] ";               

                Thang = Thang.AddMonths(1);
            }
            string sTong, sThoiGian, sSoLan,sMTTR,sMTBF;

            sTong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "TongThoiGian", Commons.Modules.TypeLanguage);
            sThoiGian = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "ThoiGianHuHong", Commons.Modules.TypeLanguage);
            sSoLan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "SoLanHuHong", Commons.Modules.TypeLanguage);
            sMTTR = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "MTTR", Commons.Modules.TypeLanguage);
            sMTBF = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "MTBF", Commons.Modules.TypeLanguage);

            sTongB = " , CONVERT (FLOAT," + sTongA.Substring(3, sTongA.Length - 3) + ") AS [TONG] ";
            sTongC = " , CONVERT (FLOAT,DBO.MGetSLanNgungMay('" + TThang.ToString("MM/dd/yyyy") + "', '" + 
                            DThang.ToString("MM/dd/yyyy") + "',A.MS_MAY ) ) AS [TONG] ";

            sTongD = sTongD + " , CONVERT (FLOAT, CASE " +
                " DBO.MGetSLanNgungMay('" + TThang.ToString("MM/dd/yyyy") + "', '" + DThang.ToString("MM/dd/yyyy") + "',A.MS_MAY ) WHEN 0 THEN 0 ELSE " +
                " ( DBO.MGetTGNMay('" + TThang.ToString("MM/dd/yyyy") + "', '" + DThang.ToString("MM/dd/yyyy") + "',A.MS_MAY ) * 60 ) / " +
                " DBO.MGetSLanNgungMay('" + TThang.ToString("MM/dd/yyyy") + "', '" + DThang.ToString("MM/dd/yyyy") + "',A.MS_MAY ) END " +
                " ) AS [TONG] ";

            sTongE = sTongE + " , CONVERT (FLOAT, CASE " +
                " DBO.MGetSLanNgungMay('" + TThang.ToString("MM/dd/yyyy") + "', '" + DThang.ToString("MM/dd/yyyy") + "',A.MS_MAY ) WHEN 0 " +
                " THEN " + iSoNgay + " ELSE " +
                " ( " + iSoNgay + " - DBO.MGetTGNMay('" + TThang.ToString("MM/dd/yyyy") + "', '" + DThang.ToString("MM/dd/yyyy") + "',A.MS_MAY )  ) / " +
                " DBO.MGetSLanNgungMay('" + TThang.ToString("MM/dd/yyyy") + "', '" + DThang.ToString("MM/dd/yyyy") + "',A.MS_MAY ) END " +
                " ) AS [TONG] ";


            //sql = " SELECT MS_MAY, CHI_TIET , GHI_CHU " + SCot + " FROM ( " 

            sql = " SELECT MS_MAY, CHI_TIET , GHI_CHU " + SCot + sTongB + " ,THU_TU FROM ( " +
                    " SELECT A.MS_MAY, CONVERT(NVARCHAR(250) ,N'" + sTong + "') AS CHI_TIET , N'' AS GHI_CHU " + sA + " , CONVERT(INT,1) AS THU_TU " +
                    " FROM " + BTam + " A  ) AS A ";

            sql = sql + " UNION SELECT MS_MAY, CHI_TIET , GHI_CHU " + SCot + sTongB + ",THU_TU FROM ( " +
                        " SELECT A.MS_MAY, N'" + sThoiGian + "' AS CHI_TIET , N'' AS GHI_CHU " + sB + " , CONVERT(INT,2) AS THU_TU " +
                        " FROM " + BTam + " A  ) AS A ";

            sql = sql + " UNION SELECT MS_MAY, CHI_TIET , GHI_CHU " + SCot + sTongC + ",THU_TU FROM ( " +
                        " SELECT A.MS_MAY, N'" + sSoLan + "' AS CHI_TIET , N'' AS GHI_CHU " + sC + " , CONVERT(INT,3) AS THU_TU " +
                        " FROM  " + BTam + " A  ) AS A ";

            sql = sql + " UNION SELECT MS_MAY, CHI_TIET , GHI_CHU " + SCot + sTongD + ",THU_TU FROM ( " +
                        " SELECT A.MS_MAY, N'" + sMTTR + "' AS CHI_TIET, N'' AS GHI_CHU " + sD + " , CONVERT(INT,4) AS THU_TU " +
                        " FROM  " + BTam + " A  ) AS A ";

            sql =  sql + " UNION SELECT MS_MAY, CHI_TIET , GHI_CHU " + SCot + sTongE + ",THU_TU FROM ( " +
                        " SELECT A.MS_MAY, N'" + sMTBF + "' AS CHI_TIET, N'' AS GHI_CHU " + sE + " , CONVERT(INT,5) AS THU_TU " +
                        " FROM  " + BTam + " A   ) AS A ";

            sql = " SELECT A.MS_MAY, A.CHI_TIET , A.GHI_CHU " + SCot + ",A.TONG FROM ( " + sql + " ) A ORDER BY A.MS_MAY,THU_TU ";
            
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,sql));
            if (dtTmp.Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "KhongCoDuLieu", Commons.Modules.TypeLanguage));
                return;
            }
            grdChung.DataSource = dtTmp;
            grvChung.OptionsBehavior.Editable = false;
            grvChung.PopulateColumns();
            grvChung.OptionsView.ColumnAutoWidth = false;
            grvChung.OptionsView.AllowHtmlDrawHeaders = true;
            grvChung.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvChung.BestFitColumns();

            grvChung.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(
                            Commons.Modules.ModuleName, "ucMTTRMTBF", "MS_MAY", Commons.Modules.TypeLanguage);

            grvChung.Columns["CHI_TIET"].Caption = Commons.Modules.ObjLanguages.GetLanguage(
                Commons.Modules.ModuleName, "ucMTTRMTBF", "CHI_TIET", Commons.Modules.TypeLanguage);

            grvChung.Columns["GHI_CHU"].Caption = " ";

            grvChung.Columns["TONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(
                Commons.Modules.ModuleName, "ucMTTRMTBF", "TONG", Commons.Modules.TypeLanguage);


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
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;  

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum =grvChung.RowCount + 11 + TCot - 4;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;
                


                grdChung.ExportToXls(sPath);
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
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong);

                int SCot;
                SCot = (TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot ));

#region prb
                prbIN.PerformStep();
                prbIN.Update();
#endregion
                Dong++;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "TieuDe", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, (TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter), 
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot > 16 ? 16 : TCot));

#region prb
                prbIN.PerformStep();
                prbIN.Update();
#endregion
                Dong++;
                string stmp = "";
                stmp = lblTThang.Text + " : " + datTThang.DateTime.ToString("MM/yyyy") + " " + lblDThang.Text + " : " + datDThang.DateTime.ToString("MM/yyyy");
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

#region prb
                prbIN.PerformStep();
                prbIN.Update();
#endregion
                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

#region prb
                prbIN.PerformStep();
                prbIN.Update();
#endregion
                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

#region prb
                prbIN.PerformStep();
                prbIN.Update();
#endregion
                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, SCot);

                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
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
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 90);

                
         
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

#region prb
                prbIN.PerformStep();
                prbIN.Update();
#endregion
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 0, "@", true, Dong + 1, 3, TDong + Dong, 3);

#region prb
                prbIN.PerformStep();
                prbIN.Update();
#endregion


                for (int i = 4; i <= TCot; i++)
                {
    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
#endregion
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7.57, "#,##0", true, Dong + 1, i, TDong + Dong, i);
                }
                Dong = 13;
                int cot = 1;

#region prb
                prbIN.PerformStep();
                prbIN.Update();
#endregion
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, TCot + 2, Dong, TCot + 2);
                double iLeft = double.Parse(title.Left.ToString());// 490;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 13, TCot + 2, 13, TCot + 2);
                double iTop = double.Parse(title.Top.ToString());// 490;
                
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 13, TCot + 2, 27, TCot + 2);
                double iHeight = double.Parse(title.Height.ToString());// 490;

                for (int i= 12; i < grvChung.RowCount + 12 ;i++)
                {
#region prb
                    prbIN.PerformStep();
                    prbIN.Update();
#endregion
                    LoadBieuDo(excelWorkSheet, i, TCot, grvChung.GetDataRow(i - 11)["MS_MAY"].ToString(), cot, iLeft, iTop, iHeight*2, iHeight);
                    i = i + 4;
#region prb
                    prbIN.PerformStep();
                    prbIN.Update();
#endregion
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i - 2, 1, i + 1, 1);
                    title.Value2 = null;

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i - 3, 1, i + 1, 1);
                    title.MergeCells = true;

                    cot++;
            
                }

                excelWorkbook.Save();
                excelApplication.Visible = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception EX)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMTTRMTBF", "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + EX.Message);
                excelApplication.Visible = true;

                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }
        
        
        }

        private void LoadBieuDo(Excel.Worksheet ExcelSheets, int vDong, int iColum, string sTitle, int iSoLan, double iLeft,
            double iTop, double iWidth, double iHeight)
        {
            try
            {   
                double iTmp = (iSoLan - 1);
                iTmp = Math.Floor(iTmp / 3);
                double iLan = (iSoLan - 1) % 3;
                iLeft = iLeft + iLan * iWidth;
                iTop = iTop + iHeight * iTmp;
#region prb
                prbIN.PerformStep(); prbIN.Update();
#endregion
                Excel.ChartObjects chartObjs = (Excel.ChartObjects)ExcelSheets.ChartObjects(Type.Missing);
                Excel.ChartObject chartObj = chartObjs.Add(iLeft, iTop, iWidth, iHeight);
                Excel.Chart xlChart = chartObj.Chart;
                Excel.SeriesCollection xlSeriesCollection = (Excel.SeriesCollection)xlChart.SeriesCollection(Type.Missing);
                
                xlChart.ChartType = Excel.XlChartType.xlLineMarkers;
                

                
#region prb
                prbIN.PerformStep(); prbIN.Update();
#endregion
                //if (optBCao.SelectedIndex == 0 || optBCao.SelectedIndex == 1)
                //{
                //    Excel.Series xlSeries = xlSeriesCollection.NewSeries();
                //    var _with1 = xlSeries;
                //    _with1.AxisGroup = Excel.XlAxisGroup.xlPrimary;
                //    _with1.Name = "MTTR";
                //    _with1.XValues = ExcelSheets.get_Range("D12", LayCot(iColum - 1) + "12");
                //    _with1.Values = ExcelSheets.get_Range("D" + (vDong + 4), LayCot(iColum - 1) + (vDong + 4));
                //}
                //if (optBCao.SelectedIndex == 0 || optBCao.SelectedIndex == 2)
                //{

                //    Excel.Series xlSeries1 = xlSeriesCollection.NewSeries();
                //    var _with2 = xlSeries1;
                //    _with2.AxisGroup = Excel.XlAxisGroup.xlSecondary;
                //    _with2.Name = "MTBF";
                //    _with2.XValues = ExcelSheets.get_Range("D12", LayCot(iColum - 1) + "12");
                //    _with2.Values = ExcelSheets.get_Range("D" + (vDong + 5).ToString(), LayCot(iColum - 1) + (vDong + 5));
                //}
                Excel.Series xlSeries = xlSeriesCollection.NewSeries();
                var _with1 = xlSeries;
                _with1.AxisGroup = Excel.XlAxisGroup.xlPrimary;
                _with1.Name = "MTTR";
                _with1.XValues = ExcelSheets.get_Range("D12", LayCot(iColum - 1) + "12");
                _with1.Values = ExcelSheets.get_Range("D" + (vDong + 4), LayCot(iColum - 1) + (vDong + 4));

                Excel.Series xlSeries1 = xlSeriesCollection.NewSeries();
                var _with2 = xlSeries1;
                _with2.AxisGroup = Excel.XlAxisGroup.xlSecondary;
                _with2.Name = "MTBF";
                _with2.XValues = ExcelSheets.get_Range("D12", LayCot(iColum - 1) + "12");
                _with2.Values = ExcelSheets.get_Range("D" + (vDong + 5).ToString(), LayCot(iColum - 1) + (vDong + 5));

                xlChart.Refresh();
                
#region prb
                prbIN.PerformStep();
                prbIN.Update();
#endregion
                xlChart.HasTitle = true;
                //xlChart.ChartTitle.Text = ExcelSheets.get_Range("D12", LayCot(iColum - 1) + "12");     //sTitle;
                xlChart.ChartTitle.Text = "=Sheet1!$A$" + (vDong + 1);                 //"=A" + vDong;

                xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;
                xlChart.ChartArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(10, 10, 255)); 
                xlChart.PlotArea.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
                xlChart.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
                xlChart.Legend.Border.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
            }
            catch
            {}
        }

        private string LayCot(int iCot)
        {
            string sTmp = "";
            if (iCot > 26)
            {
                sTmp = Convert.ToChar(Convert.ToInt32((iCot - 1) / 26) + 64).ToString();
                sTmp = sTmp + Convert.ToChar(((Convert.ToInt32(iCot) - 1) % 26) + 65).ToString();
            }
            else
            { 
                sTmp = Convert.ToChar(64 + iCot).ToString(); 
            }

            return sTmp;
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void datDThang_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void cboDDiem_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void cboDChuyen_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();

        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();

        }

        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
                view.UpdateCurrentRow();
            }

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvMay);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvMay);
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)grdMay.DataSource;

                if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTmp.DefaultView.RowFilter = dk;

            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

    }
}
