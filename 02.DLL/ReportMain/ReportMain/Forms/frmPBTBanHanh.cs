using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class frmPBTBanHanh : DevExpress.XtraEditors.XtraForm
    {
        //iLoai == 1 la Phieu Bao Tri
        //iLoai == 2 la Yeu Cau Su Dung
        //iLoai == 3 la Duyet Yeu Cau Bao Tri
        //iLoai == 4 la Phan Cong Yeu Cau Nguoi Su Dung

        public int iLoai;
        public string MsPBT;
        public string sNXuong;

        public DataTable dtTmp;

        public frmPBTBanHanh()
        {
            InitializeComponent();
        }
        #region "PhieuBaoTri"
        private void TaoPhieuBaoTri()
        {
            try
            {
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Minimum = 0;

                string sSql;
                sSql = " SELECT MS_CONG_NHAN, HO_TEN , USER_MAIL , PBT_GS FROM  " +
                            " (SELECT DISTINCT A.MS_CONG_NHAN, B.HO + ' ' + B.TEN AS HO_TEN ,B.USER_MAIL , CONVERT(BIT,0) AS PBT_GS" +
                            " FROM         dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU AS A INNER JOIN " +
                                                  " dbo.CONG_NHAN AS B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN " +
                            " WHERE     (A.MS_PHIEU_BAO_TRI = N'" + MsPBT + "')" +
                            " UNION " +
                            " SELECT A.NGUOI_GIAM_SAT ,    B.HO + ' ' + B.TEN AS HO_TEN ,B.USER_MAIL , CONVERT(BIT,1) AS PBT_GS " +
                            " FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN " +
                                                  " dbo.CONG_NHAN AS B ON A.NGUOI_GIAM_SAT = B.MS_CONG_NHAN " +
                            " WHERE     (A.MS_PHIEU_BAO_TRI = N'" + MsPBT + "')     " +
                            " ) A WHERE ISNULL(USER_MAIL,'')  <> '' ";

                DataTable dtCNhan = new DataTable();
                dtCNhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtCNhan.Rows.Count <= 0)
                    return;
                else
                {
                    Commons.Modules.SQLString = "";
                    prbIN.Properties.Maximum = 41 * dtCNhan.Rows.Count;
                    NhanVienJoin = string.Join(", ", dtCNhan.AsEnumerable().Where(x=> Convert.ToBoolean(x["PBT_GS"].ToString()) == false).Select(r => r["HO_TEN"].ToString()).ToArray());
                    foreach (DataRow drCN in dtCNhan.Rows)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(drCN["USER_MAIL"].ToString()))
                                InDuLieuPhieuBaoTri(drCN["MS_CONG_NHAN"].ToString(), drCN["HO_TEN"].ToString(),
                                    drCN["USER_MAIL"].ToString(), bool.Parse(drCN["PBT_GS"].ToString()));
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPBTBanHanh", "KhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string NhanVienJoin = "";
        private void InDuLieuPhieuBaoTri(string MSCN, string HoTen, string sMail, bool bPBTGS)
        {
            if (sMail.ToUpper() == Commons.Modules.sMailUser.ToUpper()) return;

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion
            DataTable dtPBT = new DataTable();
            dtPBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MBaoCaoCongViec", MsPBT, MSCN,
                Commons.Modules.TypeLanguage, (bPBTGS ? 1 : 0)));
            if (dtPBT.Rows.Count <= 0) return;

            dtPBT.DefaultView.Sort = "MO_TA_CV, TEN_BO_PHAN, THOI_GIAN_DU_KIEN";

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion
            
            dtPBT = dtPBT.DefaultView.ToTable();
            dtPBT.Columns[0].ReadOnly = false;

            for (int i = 0; i <= dtPBT.Rows.Count - 1; i++)
            {
                dtPBT.Rows[i][0] = (i + 1).ToString();
            }

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

            grdChung.DataSource = dtPBT;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtPBT, true, true, true, true, true, "frmPBTBanHanh");

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

            grvChung.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
            grvChung.Columns["SO_PHIEU_BAO_TRI"].Visible = false;
            grvChung.Columns["NGAY_LAP"].Visible = false;
            grvChung.Columns["MS_MAY"].Visible = false;
            grvChung.Columns["TEN_MAY"].Visible = false;
            grvChung.Columns["TEN_LOAI_BT"].Visible = false;
            grvChung.Columns["NGAY_BD_KH"].Visible = false;
            grvChung.Columns["NGAY_KT_KH"].Visible = false;
            grvChung.Columns["TEN_UU_TIEN"].Visible = false;
            grvChung.Columns["HO_TEN_GS"].Visible = false;
            grvChung.Columns["MS_NGUYEN_NHAN"].Visible = false;
            grvChung.Columns["TEN_NGUYEN_NHAN"].Visible = false;
            grvChung.Columns["LY_DO_BT"].Visible = false;

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

            string sPath = "";
            string sFile = "";
            sFile = "PBT" + Commons.Modules.UserName + DateTime.Now.ToString ("ddMMyyyHHmmsss") + ".xls";

            sPath = Application.StartupPath + "\\" + sFile;
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

            #region Tao file goi
            try
            {
                int TCot = grvChung.Columns.Count - 13;
                int TDong =  grvChung.RowCount;
                int Dong = 1;



                grdChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlApp.Visible = true;
                Excel.Workbooks xlWorkBooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = xlWorkBooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                if (!bPBTGS )
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 9, Dong);
                else
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                
                int SCot;

                SCot = TCot;// (TCot > 9 ? 9 : TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPBTBanHanh", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                if(Commons.Modules.sPrivate == "ADC")
                {
                       Dong++;
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPBTBanHanh", "NhanVien", Commons.Modules.TypeLanguage) + " : " + NhanVienJoin;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                }
                else if (!bPBTGS)
                {
                    Dong++;
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPBTBanHanh", "NhanVien", Commons.Modules.TypeLanguage) + " : " + HoTen;
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, SCot);
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmPBTBanHanh", "MSPBT", Commons.Modules.TypeLanguage) + " : " + MsPBT; 
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmPBTBanHanh", "SoPBT", Commons.Modules.TypeLanguage) + " : " + dtPBT.Rows[0]["SO_PHIEU_BAO_TRI"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, 7);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmPBTBanHanh", "NgayLap", Commons.Modules.TypeLanguage) + " : " +
                                    DateTime.Parse(dtPBT.Rows[0]["NGAY_LAP"].ToString()).ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, true, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPBTBanHanh", "MaThietBi", Commons.Modules.TypeLanguage) + " : " + dtPBT.Rows[0]["MS_MAY"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmPBTBanHanh", "TenThietBi", Commons.Modules.TypeLanguage) + " : " + dtPBT.Rows[0]["TEN_MAY"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPBTBanHanh", "LoaiBT", Commons.Modules.TypeLanguage) + " : " + dtPBT.Rows[0]["TEN_LOAI_BT"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmPBTBanHanh", "NgayBDKH", Commons.Modules.TypeLanguage) + " : " +
                                    DateTime.Parse(dtPBT.Rows[0]["NGAY_BD_KH"].ToString()).ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, 7);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmPBTBanHanh", "NgayKTKH", Commons.Modules.TypeLanguage) + " : " +
                                    DateTime.Parse(dtPBT.Rows[0]["NGAY_KT_KH"].ToString()).ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, true, true, Dong, TCot);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPBTBanHanh", "MucUTien", Commons.Modules.TypeLanguage) + " : " + dtPBT.Rows[0]["TEN_UU_TIEN"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPBTBanHanh", "GiamSatVien", Commons.Modules.TypeLanguage) + " : " + dtPBT.Rows[0]["HO_TEN_GS"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, 7);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPBTBanHanh", "NguyenNhan", Commons.Modules.TypeLanguage) + " : " + dtPBT.Rows[0]["TEN_NGUYEN_NHAN"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 8, "@", 10, true, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;



                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPBTBanHanh", "LyDo", Commons.Modules.TypeLanguage) + " : " + dtPBT.Rows[0]["LY_DO_BT"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, TCot);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                int DongBD;
                DongBD = Dong + 3;
                Excel.Range title;
                Dong = Dong + 2;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;
                //title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong - 1, 1], xlWorkSheet.Cells[Dong - 1, 1]).Interior.Color;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                 
                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 22, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 8, "#,##0.00", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12.71, "dd/MM/yyyy HH:mm", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12.71, "dd/MM/yyyy HH:mm", true, Dong + 1, 7, TDong + Dong, 7);
                if (bPBTGS)
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 50, "@", true, Dong + 1, 8, TDong + Dong, 8);
                else
                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 26, "@", true, Dong + 1, 8, TDong + Dong, 8);

                if (!bPBTGS) Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 24, "@", true, Dong + 1, 9, TDong + Dong, 9);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, DongBD, TCot + 2, DongBD, TCot + 2);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                this.Cursor = Cursors.Default;
                xlWorkBook.Save();
                xlApp.DisplayAlerts = false;
                
                xlWorkBook.SaveAs(Application.StartupPath + "\\BanHanhPBT-" + MsPBT.Trim() + ".xls", Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange, false, false, Type.Missing, Type.Missing);
                Commons.Modules.ObjSystems.Xoahinh(sPath);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                xlWorkBook.Close(true, Type.Missing, Type.Missing);
                xlApp.Quit();

                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                sPath = Application.StartupPath + "\\BanHanhPBT-" + MsPBT.Trim() + ".xls";
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string sKetQua;
                stmp = "";
                sKetQua = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            "frmPBTBanHanh", "BanHanhPBT" + "-" + MsPBT.Trim(), Commons.Modules.TypeLanguage);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                            "frmPBTBanHanh", "body", Commons.Modules.TypeLanguage);

            #endregion


                if (Commons.Modules.iLoaiGoiMail == 2 || Commons.Modules.iLoaiGoiMail == 3)
                {
                    CapNhapMailVaoCSDL(sFile, sPath, sMail, "", "", sKetQua, stmp);
                }
                
                if (Commons.Modules.iLoaiGoiMail == 1 || Commons.Modules.iLoaiGoiMail == 3)
                {
                    sKetQua = Commons.Modules.MMail.MSendEmail(sMail, Commons.Modules.sMailFrom,
                        Commons.Modules.sMailFromPass, sKetQua, stmp, sPath, Commons.Modules.sMailFromSmtp,
                        Commons.Modules.sMailFromPort, prbIN);

                    switch (sKetQua.ToUpper())
                    {
                        case "Invalid e-mail.":
                            stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmPBTBanHanh", "KhongPhaiMail", Commons.Modules.TypeLanguage);
                            Commons.Modules.SQLString = sMail + ", " + stmp + "\n";
                            break;
                        case "Email not sent":
                            stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmPBTBanHanh", "KhongGoiDuoc", Commons.Modules.TypeLanguage);
                            Commons.Modules.SQLString = sMail + ", " + stmp + "\n";
                            break;
                        case "":
                            break;
                        default:
                            Commons.Modules.SQLString = sMail + ", " + sKetQua + "\n";
                            break;
                    }
                }

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPBTBanHanh", "InKhongThanhCong" + Environment.NewLine + ex.Message , Commons.Modules.TypeLanguage));
                prbIN.Position = prbIN.Properties.Maximum;
                this.Cursor = Cursors.Default;
            }
            Commons.Modules.ObjSystems.Xoahinh(sPath);
            Commons.Modules.ObjSystems.Xoahinh(sPath);
        }

        #endregion

        #region "YeuCauNguoiSuDung"
        private void YeuCauNguoiSuDung()
        {
            string sYCSD = "";
            string sPath = "";
            string sFile = "";
            sFile = "YCNSD" + Commons.Modules.UserName + DateTime.Now.ToString("ddMMyyyHHmmsss") + ".xls";
            sPath = Application.StartupPath + "\\" + sFile;
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            dtTmp.Columns[0].ReadOnly = false;


            prbIN.Visible = true; 
            prbIN.Properties.Maximum = 25;
            prbIN.Properties.Minimum = 0;
            
            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;



            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }

            dtTmp.Columns.Add("IMAGE", typeof(Image));
            dtTmp.Columns["IMAGE"].ReadOnly = false;
            try
            {
                dtTmp.Columns["CHINH"].ReadOnly = false;
            }
            catch { }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true, true, "frmYeucaucuaNSD");
            Excel.Application xlApp = new Excel.Application();

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion

            #region Tao file goi

            grvChung.Columns["MA_SO"].Visible = false;
            grvChung.Columns["NGAY"].Visible = false;
            grvChung.Columns["GIO_YEU_CAU"].Visible = false;
            grvChung.Columns["NGUOI_YEU_CAU"].Visible = false;
            grvChung.Columns["NGAY_HOAN_THANH"].Visible = false;
            grvChung.Columns["EMAIL_NSD"].Visible = false; 


            grvChung.Columns["MS_YEU_CAU"].Visible = false;
            grvChung.Columns["SO_YEU_CAU"].Visible = false;
            grvChung.Columns["MS_N_XUONG"].Visible = false;
            grvChung.Columns["USER_COMMENT"].Visible = false;

            grvChung.RowHeight = 600;
            grvChung.Columns["IMAGE"].Width = 900;
            grvChung.Columns["IMAGE"].MaxWidth = 1024;
            grvChung.Columns["IMAGE"].MinWidth = 1024;

            int tmp = grvChung.Columns["IMAGE"].VisibleIndex;
            grvChung.Columns["IMAGE"].VisibleIndex = grvChung.Columns["DUONG_DAN"].VisibleIndex;
            grvChung.Columns["DUONG_DAN"].VisibleIndex = tmp;

            grvChung.Columns["DUONG_DAN"].Visible = false;
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "frmYeucaucuaNSD", 1);

            RepositoryItemPictureEdit repositoryItemPictureEdit1 = new RepositoryItemPictureEdit();
            repositoryItemPictureEdit1.Name = "IMAGE";
            repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            repositoryItemPictureEdit1.NullText = (" ");
            repositoryItemPictureEdit1.PictureAlignment = ContentAlignment.MiddleCenter;
            grdChung.RepositoryItems.Add(repositoryItemPictureEdit1);
            grvChung.Columns[grvChung.Columns.Count - 1].ColumnEdit = repositoryItemPictureEdit1;
            Boolean bHinh = false;
            for (int i = 0; i < grvChung.RowCount; i++)
            {
                if (!String.IsNullOrEmpty(grvChung.GetDataRow(i)["DUONG_DAN"].ToString()))
                {
                    bHinh = true;
                    try
                    {
                        Image imageFromFile = Image.FromFile(grvChung.GetDataRow(i)["DUONG_DAN"].ToString());
                        grvChung.SetRowCellValue(i, "IMAGE", imageFromFile);
                        try { grvChung.SetRowCellValue(i, "CHINH", 1);}
                        catch { }
                        
                        
                        grvChung.UpdateCurrentRow();
                    }
                    catch
                    {
                        try { grvChung.SetRowCellValue(i, "CHINH", 11); }
                        catch { }
                        
                        grvChung.UpdateCurrentRow();

                    }
                }
            }

            try
            {
                dtTmp = (DataTable)grdChung.DataSource;
                dtTmp.DefaultView.RowFilter = "CHINH = 1 ";
                dtTmp = dtTmp.DefaultView.ToTable();


                int TCot = grvChung.Columns.Count - 16;
                int TDong = grvChung.RowCount - (dtTmp.Rows.Count - int.Parse(dtTmp.Rows[0]["TDONG"].ToString()));
                int Dong = 1;


                grdChung.ExportToXls(sPath);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.Workbooks xlWorkBooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = xlWorkBooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];


                xlApp.DisplayAlerts = false;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmYeucaucuaNSD", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                string stmp = "";
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmYeucaucuaNSD", "NgayYeuCau", Commons.Modules.TypeLanguage) + " : " +
                                    DateTime.Parse(dtTmp.Rows[0]["NGAY"].ToString()).ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmYeucaucuaNSD", "GioYeuCau", Commons.Modules.TypeLanguage) + " : " +
                                    DateTime.Parse(dtTmp.Rows[0]["GIO_YEU_CAU"].ToString()).ToLongTimeString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmYeucaucuaNSD", "NguoiYeuCau", Commons.Modules.TypeLanguage) + " : " +
                                    dtTmp.Rows[0]["NGUOI_YEU_CAU"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, TCot);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmYeucaucuaNSD", "NgayHoanThanh", Commons.Modules.TypeLanguage) +
                                    (dtTmp.Rows[0]["NGAY_HOAN_THANH"].ToString() == "" ? "" : " : " + DateTime.Parse(dtTmp.Rows[0]["NGAY_HOAN_THANH"].ToString()).ToShortDateString());
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmYeucaucuaNSD", "MSYeuCau", Commons.Modules.TypeLanguage) + " : " +
                                    dtTmp.Rows[0]["MS_YEU_CAU"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, 4);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmYeucaucuaNSD", "SoYeuCau", Commons.Modules.TypeLanguage) + " : " +
                    dtTmp.Rows[0]["SO_YEU_CAU"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, TCot);


                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmYeucaucuaNSD", "Xuong", Commons.Modules.TypeLanguage) + " : " +
                                    dtTmp.Rows[0]["MS_N_XUONG"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmYeucaucuaNSD", "UserComment", Commons.Modules.TypeLanguage) + " : " +
                                    dtTmp.Rows[0]["USER_COMMENT"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, TCot);

                Excel.Range title;
                Dong = Dong + 2;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                //Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                //    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);



                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;



                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 12, Dong, 13);
                title.EntireColumn.Delete(System.Reflection.Missing.Value);


                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 33, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 34, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 17, "dd/MM/yyyy HH:mm:ss", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 12, "@", true, Dong + 1, 8, TDong + Dong, 8);

                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 33, "@", true, Dong + 1, 10, TDong + Dong, 10);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 11, 1, TDong + Dong, 1);
                title.WrapText = true;
                title.EntireRow.AutoFit();

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 11, 1, TDong + Dong, 8);
                title.Borders.LineStyle = 1;

                Dong = TDong + Dong + 1;
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 3, Dong);
                Dong = Dong + 3;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 2, Dong + (dtTmp.Rows.Count - int.Parse(dtTmp.Rows[0]["TDONG"].ToString())), 8);
                title.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 8, Dong, 15);

                title.EntireColumn.Delete(System.Reflection.Missing.Value);

                if (bHinh)
                {
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, TDong + Dong - 1, 3);
                    title.Borders.LineStyle = 1;
                }
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 9, Dong, 10);
                title.EntireColumn.Delete(System.Reflection.Missing.Value);
                xlWorkBook.Save();
                #endregion
                string sMailUserLap = "";
                string sMailTo, sMailCC;
                #region Goi them mail theo user lap
                try
                {
                    sMailUserLap = dtTmp.Rows[0]["MAIL_USER_LAP"].ToString();
                    if (sMailUserLap != "")
                    {
                        if (sNXuong == "")
                            sNXuong = sMailUserLap.Trim();
                        else
                            sNXuong = sNXuong.Trim() + ";" + sMailUserLap.Trim();
                    }
                }
                catch { }
                #endregion
                sNXuong = sBoMailUser(sNXuong);
                if (sNXuong != "")
                {
                    if (dtTmp.Rows[0]["EMAIL_NSD"].ToString() != "")
                        sMailCC = sNXuong + ";" + dtTmp.Rows[0]["EMAIL_NSD"].ToString();
                    else
                        sMailCC = sNXuong;

                    sNXuong = sBoMailUser(sNXuong);

                    string[] sMail = sNXuong.Split(new Char[] { ';' });
                    sMailTo = sMail.GetValue(0).ToString();
                    if (sMail.Length > 1) sMailCC = sMailCC.Replace(sMailTo + ";", "");
                    sMailCC = sBoMailUser(sMailCC);
                }
                else
                {
                    sMailCC = dtTmp.Rows[0]["EMAIL_NSD"].ToString();
                    sMailCC = sBoMailUser(sMailCC);
                    string[] sMail = dtTmp.Rows[0]["EMAIL_NSD"].ToString().Split(new Char[] { ';' });
                    sMailTo = sMail.GetValue(0).ToString();
                    if (sMail.Length > 1) sMailCC = sMailCC.Replace(sMailTo + ";", "");
                    sMailTo = sMail.GetValue(0).ToString();
                    sMailCC = (sMailCC == "" ? "" : sMailCC + ";");
                }

                if(sMailCC.Trim() == "" && sMailTo.Trim() == "")
                    return;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = "";
                //if (sMailCC == "") sMailCC = sMailTo;

                string sTieuDe = "";
                string sBody = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeucaucuaNSD", "BodyMail", Commons.Modules.TypeLanguage);
                string sNoiDung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeucaucuaNSD", "sNoiDung0DUYET", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["USER_COMMENT"].ToString();
                string sNguoiYC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeucaucuaNSD", "sNguoiYC", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["NGUOI_YEU_CAU"].ToString();
                string sUNameYC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeucaucuaNSD", "sUNameYC", Commons.Modules.TypeLanguage) + " : " + Commons.Modules.UserName;
                string sNgayYC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeucaucuaNSD", "sNgayYC", Commons.Modules.TypeLanguage) + " : " + DateTime.Parse(dtTmp.Rows[0]["NGAY"].ToString()).ToShortDateString();
                string sGioYC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeucaucuaNSD", "sGioYC", Commons.Modules.TypeLanguage) + " : " + DateTime.Parse(dtTmp.Rows[0]["GIO_YEU_CAU"].ToString()).ToLongTimeString();
                
                try
                {
                    sYCSD = dtTmp.Rows[0]["MS_YEU_CAU"].ToString().Trim().Replace(" ","");
                }
                catch {}

                sTieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeucaucuaNSD",
                    "TieuDeMail", Commons.Modules.TypeLanguage) + " " + sYCSD;
                

                sBody = "<body>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sBody + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNoiDung + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNguoiYC + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sUNameYC + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNgayYC + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sGioYC + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</body>";

                stmp = "";
                if (Commons.Modules.iLoaiGoiMail == 2 || Commons.Modules.iLoaiGoiMail == 3)
                {
                    CapNhapMailVaoCSDL(sFile, sPath, sMailTo, sMailCC, "", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeucaucuaNSD", "TieuDeMail", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeucaucuaNSD", "BodyMail", Commons.Modules.TypeLanguage));
                }
                xlWorkBook.Close(true, Type.Missing, Type.Missing);
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);


                stmp = "";
                if (Commons.Modules.iLoaiGoiMail == 1 || Commons.Modules.iLoaiGoiMail == 3)
                {                  
                    if (!GoiMail(xlWorkBook, sPath, sMailTo, sMailCC, sTieuDe, sBody, ref stmp))
                    XtraMessageBox.Show(stmp);
                }

                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPBTBanHanh", "KhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Commons.Modules.ObjSystems.Xoahinh(sPath);
            Commons.Modules.ObjSystems.Xoahinh(Application.StartupPath + "\\YeuCauNguoiSuDung-" + sYCSD + ".xls");
            prbIN.Position = prbIN.Properties.Maximum;
        }
        #endregion

        private void frmPBTBanHanh_Shown(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.bSSL = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT ISNULL(SSL_MAIL,0) AS SSL_MAIL FROM THONG_TIN_CHUNG "));
            }
            catch { Commons.Modules.bSSL = false; }


            try
            {
                if (iLoai == 1) TaoPhieuBaoTri();
                if (iLoai == 2) YeuCauNguoiSuDung();
                if (iLoai == 3) DuyetYeuCauBaoTri();
                if (iLoai == 4) PhanCongYeuCau();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPBTBanHanh", "KhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        #region "Duyet Yeu Cau Bao Tri"
        private void DuyetYeuCauBaoTri()
        {
            string sPath = "";
            string sFile = "";
            try
            {

                sFile = "DYCBT" + Commons.Modules.UserName + DateTime.Now.ToString("ddMMyyyHHmmsss") + ".xls";
                sPath = Application.StartupPath + "\\" + sFile;
                if (sPath == "") return;
                this.Cursor = Cursors.WaitCursor;
                dtTmp.Columns[0].ReadOnly = false;


                prbIN.Visible = true;
                prbIN.Properties.Maximum = 25;
                prbIN.Properties.Minimum = 0;

                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;



                for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                {
                    dtTmp.Rows[i][0] = (i + 1).ToString();
                }


                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true, true, "frmDuyetSanXuat");
                Excel.Application xlApp = new Excel.Application();

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                grvChung.Columns["USERNAME_DSX"].Visible = false;
                grvChung.Columns["THOI_GIAN_DSX"].Visible = false;
                grvChung.Columns["Y_KIEN_DSX"].Visible = false;
                grvChung.Columns["THUC_HIEN_DSX"].Visible = false;

                string sYCSD = "";
                try
                {
                    sYCSD = dtTmp.Rows[0]["MS_YEU_CAU"].ToString().Trim().Replace(" ", "");
                }
                catch { }

                try
                {
                    #region TaoDu Lieu Goi Mail
                    int TCot = grvChung.Columns.Count - 4;
                    int TDong = grvChung.RowCount;
                    int Dong = 1;



                    grdChung.ExportToXls(sPath);

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    Excel.Workbooks xlWorkBooks = xlApp.Workbooks;
                    Excel.Workbook xlWorkBook = xlWorkBooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                    Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                    



                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                    Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                    Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                    Dong++;

                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmDuyetSanXuat", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    Dong++;
                    string stmp = "";
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmDuyetSanXuat", "NguoiDuyet", Commons.Modules.TypeLanguage) + " : " +
                                        dtTmp.Rows[0]["USERNAME_DSX"].ToString();
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);
                    
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmDuyetSanXuat", "NgayGioDuyet", Commons.Modules.TypeLanguage) + " : " +
                                        DateTime.Parse(dtTmp.Rows[0]["THOI_GIAN_DSX"].ToString());
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 6, "@", 10, true, true, Dong, TCot - 1);

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion



                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    Dong++;
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmDuyetSanXuat", "YKien", Commons.Modules.TypeLanguage) + " : " +
                                        dtTmp.Rows[0]["Y_KIEN_DSX"].ToString();
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 4);


                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmDuyetSanXuat", "DongY", Commons.Modules.TypeLanguage) + " : ";
                                        
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 6, "@", 10, true, true, Dong, 6);


                    

                    Excel.Range title;
                    if (Convert.ToBoolean(dtTmp.Rows[0]["THUC_HIEN_DSX"].ToString()))
                    {
                        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 7, Dong, 7);
                        title.Font.Name = "Wingdings";
                        title.Font.Bold = true;
                        title.Value2 = "ü";
                    }


                    Dong = Dong + 2;
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                    title.Borders.LineStyle = 1;

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion
                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                    title.Font.Bold = true;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);


                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                    title.RowHeight = 9;

                    title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                    title.RowHeight = 9;

                    

                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion


                    Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 17, "dd/MM/yyyy HH:mm:ss", true, Dong + 1, 10, TDong + Dong, 10);


                    xlWorkBook.Save();
                    xlApp.DisplayAlerts = false;


                    #endregion

                    string sMailTo, sMailCC;
                    sNXuong = sBoMailUser(sNXuong);
                    if (sNXuong != "")
                    {
                        sMailCC = sNXuong;
                        string[] sMail = sNXuong.Split(new Char[] { ';' });
                        sMailTo = sMail.GetValue(0).ToString();
                        if (sMail.Length > 1) sMailCC = sMailCC.Replace(sMailTo + ";", "");
                        sMailCC = sBoMailUser(sMailCC);
                    }
                    else
                    {
                        sMailCC = dtTmp.Rows[0]["EMAIL_NSD"].ToString();
                        sMailCC = sBoMailUser(sMailCC);
                        string[] sMail = sMailCC.Split(new Char[] { ';' });
                        sMailTo = sMail.GetValue(0).ToString();
                        if (sMail.Length > 1) sMailCC = sMailCC.Replace(sMailTo + ";", "");
                        
                        sMailCC = (sMailCC == "" ? "" : sMailCC + ";");
                        sMailCC = sBoMailUser(sMailCC);
                    }
                    #region prb
                    prbIN.PerformStep();
                    prbIN.Update();
                    #endregion

                    if (sMailCC.Trim() == "" && sMailTo.Trim() == "")
                        return;

                    stmp = "";

                    string sTieuDe = "";
                    string sBody = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                            "frmDuyetSanXuat", "BodyMail", Commons.Modules.TypeLanguage);
                    if (Commons.Modules.SQLString == "0DUYET")
                        sBody = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                            "frmDuyetSanXuat", "BodyMail0Duyet", Commons.Modules.TypeLanguage);

                    string sNguoiDuyet = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                            "frmDuyetSanXuat", "sNguoiDuyet", Commons.Modules.TypeLanguage) + " : " + Commons.Modules.sTenNhanVienMD;
                    
                    string sUNameDuyet = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                            "frmDuyetSanXuat", "sUNameDuyet", Commons.Modules.TypeLanguage) + " : " + Commons.Modules.UserName;
                    string sNgayDuyet = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                            "frmDuyetSanXuat", "sNgayDuyet", Commons.Modules.TypeLanguage) + " : " + DateTime.Parse(dtTmp.Rows[0]["THOI_GIAN_DSX"].ToString()).ToShortDateString();
                    string sGioDuyet = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                            "frmDuyetSanXuat", "sGioDuyet", Commons.Modules.TypeLanguage) + " : " + DateTime.Parse(dtTmp.Rows[0]["THOI_GIAN_DSX"].ToString()).ToLongTimeString();
                    string sYKien = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                "frmDuyetSanXuat", "sNoiDung", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["Y_KIEN_DSX"].ToString();

                    if (Commons.Modules.SQLString == "0DUYET")
                        sTieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "TieuDeMail0Duyet", Commons.Modules.TypeLanguage) + " " + sYCSD;
                    else
                        sTieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "TieuDeMail", Commons.Modules.TypeLanguage) + " " + sYCSD ;


                    sBody = "<body>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sBody + "<br>" +
                                   "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNguoiDuyet + "<br>" +
                                   "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sUNameDuyet + "<br>" +
                                   "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNgayDuyet + "<br>" +
                                   "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sGioDuyet + "<br>" +
                                   "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sYKien + "<br>" +
                                   "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</body>";
                    stmp = "";

                    xlWorkBook.Close(true, Type.Missing, Type.Missing);
                    xlApp.Quit();
                    Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                    Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                    Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                    if (Commons.Modules.iLoaiGoiMail == 2 || Commons.Modules.iLoaiGoiMail == 3)
                    {
                        CapNhapMailVaoCSDL(sFile, sPath, sMailTo, sMailCC, "", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                            "frmDuyetSanXuat", "TieuDeMail", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                            "frmDuyetSanXuat", "BodyMail", Commons.Modules.TypeLanguage));
                    }
                    stmp = "";
                    if (Commons.Modules.iLoaiGoiMail == 1 || Commons.Modules.iLoaiGoiMail == 3)
                    {
                        if (!GoiMail(xlWorkBook, sPath,sMailTo, sMailCC, sTieuDe, sBody, ref stmp))
                            XtraMessageBox.Show(stmp);
                    }

                    

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPBTBanHanh", "KhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                        ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Commons.Modules.ObjSystems.Xoahinh(sPath);
                Commons.Modules.ObjSystems.Xoahinh(Application.StartupPath + "\\DuyetYeuCauBaoTri" + ".xls");

                prbIN.Position = prbIN.Properties.Maximum;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPBTBanHanh", "KhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Commons.Modules.ObjSystems.Xoahinh(sPath);
        }
        #endregion

        #region " Phan Cong Yeu Cau Nguoi Su Dung"
        private void PhanCongYeuCau()
        {
            string sPath = "";
            string sFile = "";
            sFile = "PCYCBT" + Commons.Modules.UserName + DateTime.Now.ToString("ddMMyyyHHmmsss") + ".xls";
            sPath = Application.StartupPath + "\\" + sFile;
            
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            dtTmp.Columns[0].ReadOnly = false;


            prbIN.Visible = true;
            prbIN.Properties.Maximum = 25;
            prbIN.Properties.Minimum = 0;

            prbIN.Position = 0;
            prbIN.Properties.Step = 1;
            prbIN.Properties.PercentView = true;



            for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
            {
                dtTmp.Rows[i][0] = (i + 1).ToString();
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true, true, "frmDuyetSanXuat");
            Excel.Application xlApp = new Excel.Application();

            #region prb
            prbIN.PerformStep();
            prbIN.Update();
            #endregion
            #region Tao File Goi

            //grvChung.Columns["MA_SO"].Visible = false;
            grvChung.Columns["NGAY"].Visible = false;
            grvChung.Columns["GIO_YEU_CAU"].Visible = false;
            grvChung.Columns["NGUOI_YEU_CAU"].Visible = false;
            grvChung.Columns["NGAY_HOAN_THANH"].Visible = false;
            grvChung.Columns["EMAIL_NSD"].Visible = false;


            grvChung.Columns["MS_YEU_CAU"].Visible = false;
            grvChung.Columns["SO_YEU_CAU"].Visible = false;
            grvChung.Columns["MS_N_XUONG"].Visible = false;
            grvChung.Columns["USER_COMMENT"].Visible = false;


            grvChung.Columns["TEN_HANG_MUC"].Visible = false;
            grvChung.Columns["MS_CACH_TH"].Visible = false;
            grvChung.Columns["USER_LAP"].Visible = false;
            grvChung.Columns["HO_TEN_DSX"].Visible = false;
            //T1.TEN_HANG_MUC, B.MS_CACH_TH, dbo.YEU_CAU_NSD.USER_LAP,HO_TEN_DSX
            

            try
            {
                int TCot = grvChung.Columns.Count - 9;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                grdChung.ExportToXls(sPath);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Excel.Workbooks xlWorkBooks = xlApp.Workbooks;
                Excel.Workbook xlWorkBook = xlWorkBooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);

                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 100, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 6, Dong);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;

                Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmDuyetSanXuat", "TieuDe", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                string stmp = "";
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmDuyetSanXuat", "NgayYeuCau", Commons.Modules.TypeLanguage) + " : " +
                                    DateTime.Parse(dtTmp.Rows[0]["NGAY"].ToString()).ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);
                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmDuyetSanXuat", "GioYeuCau", Commons.Modules.TypeLanguage) + " : " +
                                    DateTime.Parse(dtTmp.Rows[0]["GIO_YEU_CAU"].ToString()).ToLongTimeString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, 4);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmDuyetSanXuat", "NguoiYeuCau", Commons.Modules.TypeLanguage) + " : " +
                                    dtTmp.Rows[0]["NGUOI_YEU_CAU"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, TCot);


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmDuyetSanXuat", "NgayHoanThanh", Commons.Modules.TypeLanguage) +
                                    (dtTmp.Rows[0]["NGAY_HOAN_THANH"].ToString() == "" ? "" : " : " + DateTime.Parse(dtTmp.Rows[0]["NGAY_HOAN_THANH"].ToString()).ToShortDateString());
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmDuyetSanXuat", "MSYeuCau", Commons.Modules.TypeLanguage) + " : " +
                                    dtTmp.Rows[0]["MS_YEU_CAU"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, 4);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmDuyetSanXuat", "SoYeuCau", Commons.Modules.TypeLanguage) + " : " +
                    dtTmp.Rows[0]["SO_YEU_CAU"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 5, "@", 10, true, true, Dong, TCot);


                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmDuyetSanXuat", "Xuong", Commons.Modules.TypeLanguage) + " : " +
                                    dtTmp.Rows[0]["MS_N_XUONG"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmDuyetSanXuat", "UserComment", Commons.Modules.TypeLanguage) + " : " +
                                    dtTmp.Rows[0]["USER_COMMENT"].ToString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, TCot);

                Excel.Range title;
                Dong = Dong + 2;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.Borders.LineStyle = 1;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);
               
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 33, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 34, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong + 1, 6, TDong + Dong, 6);

                xlWorkBook.Save();
                xlApp.DisplayAlerts = false;

            #endregion

                string sMailTo, sMailCC;
                sNXuong = sBoMailUser(sNXuong);
                if (sNXuong != "")
                {
                    sMailCC = sNXuong;
                    string[] sMail = sNXuong.Split(new Char[] { ';' });
                    sMailTo = sMail.GetValue(0).ToString();
                    if (sMail.Length > 1) sMailCC = sMailCC.Replace(sMailTo + ";", "");
                    sMailTo = sMail.GetValue(0).ToString();
                }
                else
                {
                    sMailCC = dtTmp.Rows[0]["EMAIL_NSD"].ToString();
                    string[] sMail = dtTmp.Rows[0]["EMAIL_NSD"].ToString().Split(new Char[] { ';' });
                    sMailTo = sMail.GetValue(0).ToString();
                    if (sMail.Length > 1) sMailCC = sMailCC.Replace(sMailTo + ";", "");
                    sMailTo = sMail.GetValue(0).ToString();
                    sMailCC = (sMailCC == "" ? "" : sMailCC + ";");
                }
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                if (sMailCC.Trim() == "" && sMailTo.Trim() == "")
                    return;

                string sTieuDe = "";
                sTieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauBT", "TieuDeMail", Commons.Modules.TypeLanguage) + " " + dtTmp.Rows[0]["MS_YEU_CAU"].ToString() + " " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauBT", "lblMS_MAY", Commons.Modules.TypeLanguage) + " " + dtTmp.Rows[0]["MS_MAY"].ToString();

                string sBody = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeuCauBT", "BodyMail", Commons.Modules.TypeLanguage);
                string sThietBi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                        "frmYeuCauBT", "sThietBi", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["MS_MAY"].ToString() + "-" + dtTmp.Rows[0]["TEN_MAY"].ToString();
                string sNXNhan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeuCauBT", "sNXNhan", Commons.Modules.TypeLanguage) + " : " + Commons.Modules.sTenNhanVienMD;
                string sUserNhan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeuCauBT", "sUserNhan", Commons.Modules.TypeLanguage) + " : " + Commons.Modules.UserName;

                string sYKienDSX = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeuCauBT", "sYKienDSX", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["Y_KIEN_DSX"].ToString();
                string sCTHien = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeuCauBT", "sCTHien", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["TEN_TIENG_VIET"].ToString();

                string sYKienDBT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                       "frmYeuCauBT", "sYKienDBT", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["Y_KIEN_DBT"].ToString();

                string sPBTHM = ""; //theo hang muc la co he hoach tong the = 01 , 04 la theo PBT
                if (dtTmp.Rows[0]["MS_CACH_TH"].ToString() == "01")
                    sPBTHM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                        "frmYeuCauBT", "sHangMuc", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["TEN_HANG_MUC"].ToString();
                
                if (dtTmp.Rows[0]["MS_CACH_TH"].ToString() == "04")
                    sPBTHM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                            "frmYeuCauBT", "sPBT", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["MS_PBT"].ToString();

                string sNguoiYC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                        "frmYeuCauBT", "sNguoiYC", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["NGUOI_YEU_CAU"].ToString();
                string sUserYC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                        "frmYeuCauBT", "sUserYC", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["USER_LAP"].ToString();
                string sNgayYC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                        "frmYeuCauBT", "sNgayYC", Commons.Modules.TypeLanguage) + " : " + DateTime.Parse(dtTmp.Rows[0]["NGAY"].ToString()).ToShortDateString();
                string sGioYC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                        "frmYeuCauBT", "sGioYC", Commons.Modules.TypeLanguage) + " : " + DateTime.Parse(dtTmp.Rows[0]["GIO_YEU_CAU"].ToString()).ToLongTimeString();

                string sNguoiDuyet = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                        "frmYeuCauBT", "sNguoiDuyet", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["HO_TEN_DSX"].ToString();
                string sUserDuyet = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                        "frmYeuCauBT", "sUserDuyet", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["USERNAME_DSX"].ToString();
                string sNgayDuyet = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                        "frmYeuCauBT", "sNgayDuyet", Commons.Modules.TypeLanguage) + " : " + DateTime.Parse(dtTmp.Rows[0]["THOI_GIAN_DSX"].ToString()).ToShortDateString();
                string sGioDuyet = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                        "frmYeuCauBT", "sGioDuyet", Commons.Modules.TypeLanguage) + " : " + DateTime.Parse(dtTmp.Rows[0]["THOI_GIAN_DSX"].ToString()).ToLongTimeString();
                string sBDKH = "";
                string sKTKH = "";
                if (dtTmp.Rows[0]["MS_CACH_TH"].ToString() == "04")
                {

                       sBDKH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmYeuCauBT", "NGAY_BD_KH", Commons.Modules.TypeLanguage) + " : " + DateTime.Parse(dtTmp.Rows[0]["NGAY_BD_KH"].ToString()).ToShortDateString();
                    sKTKH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmYeuCauBT", "NGAY_KT_KH", Commons.Modules.TypeLanguage) + " : " + DateTime.Parse(dtTmp.Rows[0]["NGAY_KT_KH"].ToString()).ToShortDateString();
                }



                if (sPBTHM == "")
                    sBody = "<body>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sBody + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + sThietBi + "</b><br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNXNhan + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sUserNhan + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sCTHien + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + sYKienDBT + "</b><br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNguoiYC + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sUserYC + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNgayYC + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sGioYC + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + sYKienDSX + "</b><br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNguoiDuyet + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sUserDuyet + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNgayDuyet + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sGioDuyet + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</body>";
                else
                    sBody = "<body>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sBody + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + sThietBi + "</b><br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNXNhan + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sUserNhan + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sCTHien + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + sYKienDBT + "</b><br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sPBTHM + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sBDKH + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sKTKH + "<br>" +

                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + sYKienDSX + "</b><br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNguoiDuyet + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sUserDuyet + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNgayDuyet + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sGioDuyet + "<br>" +

                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNguoiYC + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sUserYC + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNgayYC + "<br>" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sGioYC + "<br>" +


                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</body>";



                //Mã thiết bị: Máy Chiller 10HP(04)
                //Tên người nhận: Nguyễn Quang Trí
                //User nhận: maint1
                //Cách thực hiện : Thực hiện trên PBT
                //Ý kiến duyệt bảo trì: thay đồng hồ nhiệt lạnh
                //Số PBT: WO - 202009090064
                //Ngày BĐKH : 
                //Ngày KTKH : 
                //Người yêu cầu: Thao NM2
                //User yêu cầu: pro5
                //Ngày yêu cầu : 14 / 09 / 2020
                //Giờ yêu cầu: 14:10:00
                //Ý kiến duyệt yêu cầu:
                //Người duyệt : Nguyễn Ngọc Hoan
                //User duyệt: pro02
                //Ngày duyệt: 18 / 09 / 2020
                //Giờ duyệt : 16:20:17

                stmp = "";
                if (Commons.Modules.iLoaiGoiMail == 2 || Commons.Modules.iLoaiGoiMail == 3)
                {
                    CapNhapMailVaoCSDL(sFile, sPath, sMailTo, sMailCC, "", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeuCauBT", "TieuDeMail", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmYeuCauBT", "BodyMail", Commons.Modules.TypeLanguage));
                }
                if (Commons.Modules.iLoaiGoiMail == 1 || Commons.Modules.iLoaiGoiMail == 3)
                {
                    if (!GoiMail(xlWorkBook, sPath,
                                sMailTo, sMailCC, sTieuDe, sBody, ref stmp))
                        XtraMessageBox.Show(stmp);
                }


                xlWorkBook.Close(true, Type.Missing, Type.Missing);
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPBTBanHanh", "KhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            Commons.Modules.ObjSystems.Xoahinh(sPath);
            Commons.Modules.ObjSystems.Xoahinh(Application.StartupPath + "\\PhanCongYeuCau" + ".xls");
        }
        #endregion

        #region Goi Mail
        private Boolean GoiMail(Excel.Workbook xlWorkBook, string sPath,
                string sMail, string sMailCC, string sTieuDe, string sBody, ref string sKetQuaSent)
        {
            try
            {
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string sKetQua;

                sMail = sBoMailUser(sMail);
                sMailCC = sBoMailUser(sMailCC);

                if (sMail == sMailCC)
                    sMailCC = "";


                if (System.Environment.MachineName.ToUpper() == "M4SHI")
                {
                    sMail = "nhattc@vietsoft.com.vn";
                    sMailCC = "";
                }
                if (sMailCC == sMail)
                    sMailCC = "";

                if (sMailCC == "")
                    sKetQua = Commons.Modules.MMail.MSendEmail(sMail, Commons.Modules.sMailFrom,
                        Commons.Modules.sMailFromPass, sTieuDe, sBody, sPath, Commons.Modules.sMailFromSmtp,
                        Commons.Modules.sMailFromPort, prbIN);
                else
                    sKetQua = Commons.Modules.MMail.MSendEmail(sMail, sMailCC, Commons.Modules.sMailFrom,
                        Commons.Modules.sMailFromPass, sTieuDe, sBody, sPath, Commons.Modules.sMailFromSmtp,
                        Commons.Modules.sMailFromPort, prbIN);
                

                Commons.Modules.ObjSystems.Xoahinh(sPath);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                switch (sKetQua.ToUpper())
                {
                    case "Invalid e-mail.":
                        sKetQuaSent = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmPBTBanHanh", "KhongPhaiMail", Commons.Modules.TypeLanguage);
                        return false;
                    case "Email not sent":
                        sKetQuaSent = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmPBTBanHanh", "KhongGoiDuoc", Commons.Modules.TypeLanguage);
                        return false;
                    case "":
                        return true;
                    default:
                        sKetQuaSent = sKetQua;
                        return false;
                }
            }catch  (Exception ex)
            {
                prbIN.Position = prbIN.Properties.Maximum;
                sKetQuaSent = ex.Message;
                return false;
            }

        }
        #endregion

        #region Dua File Vao CSDL
        private void CapNhapMailVaoCSDL(string sFileName, string sPath, string sMailTo, string sMailCC,
            string sMailBCC, string sTieuDe, string sBody)
        {
            try
            {

                if (!Commons.Modules.ObjSystems.KiemThuMucTonTai(Commons.Modules.sDDanMail))
                {
                    System.IO.Directory.CreateDirectory(Commons.Modules.sDDanMail );
                }
                Commons.Modules.ObjSystems.LuuDuongDan(sPath, Commons.Modules.sDDanMail + "\\" + sFileName);
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "MAddMailSent", sFileName, Commons.Modules.sDDanMail + "\\" + sFileName, sMailTo, sMailCC, sMailBCC, sTieuDe, sBody);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPBTBanHanh", "KhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private string sBoMailUser(string sMail) 
        {
            sMail = Commons.Modules.ObjSystems.MBoMailTrung(sMail);
            sMail = sMail.Replace(" ", string.Empty);
            sMail = sMail.Replace("  ", string.Empty);
            sMail = sMail.Replace("   ", string.Empty);

            //if (string.IsNullOrEmpty(Commons.Modules.sMailUser.Trim()))
            //    return sMail;

            //try
            //{
            //    sMail = sMail.Replace(Commons.Modules.sMailUser + ";", "");
            //    sMail = sMail.Replace(";" + Commons.Modules.sMailUser, "");
            //}
            //catch { }

            return sMail;
        }
    }
}