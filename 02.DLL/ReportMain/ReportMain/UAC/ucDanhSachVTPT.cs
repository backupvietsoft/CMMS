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
    public partial class ucDanhSachVTPT : DevExpress.XtraEditors.XtraUserControl
    {
        string sUC = "ucDanhSachVTPT";
        public ucDanhSachVTPT()
        {
            InitializeComponent();
        }
        #region Load Du Lieu
        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sNX = "-1";
                if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cboDDiem.EditValue.ToString() != "-1") sNX = cboDDiem.EditValue.ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayTheoNXHT", Commons.Modules.UserName, sNX, iHThong));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (Commons.Modules.SQLString == "0LOADLOAI") return;
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sNX = "-1";
                string sLmay = "-1";
                if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cboLMay.EditValue.ToString() != "-1") sLmay = cboLMay.EditValue.ToString();
                if (cboDDiem.EditValue.ToString() != "-1") sNX = cboDDiem.EditValue.ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayTheoLMNXHT", Commons.Modules.UserName,
                    sLmay, "-1", sNX, iHThong, 0, 1));
                Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboThietBi, dtTmp, "MS_MAY", "TEN_MAY", sUC);
            }
            catch { }
        }
        #endregion

        private void LoadLBT()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_BAO_TRI_PBT"));
                Commons.Modules.ObjSystems.MLoadCheckedComboBoxEdit(cboLoaiBT, dtTmp, "MS_LOAI_BT", "TEN_LOAI_BT");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }        
        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            Commons.Modules.SQLString = "0LOADLOAI";
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
            LoadMay();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ucDanhSachVTPT_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            datTNgay.DateTime = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            datDNgay.DateTime = DateTime.Now;
            LoadNX();
            LoadDChuyen();
            Commons.Modules.SQLString = "0LOADLOAI";
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
            LoadMay();
            LoadLBT();
        }

        private void btnTimMay_Click(object sender, EventArgs e)
        {
            frmTimMay frm = new frmTimMay();
            frm.iLoaiBC = 1;
            frm.MsLoaiMay = cboLMay.EditValue.ToString();
            frm.TuNgay = datTNgay.DateTime;
            frm.DenNgay = datDNgay.DateTime;
            frm.sDiaDiem = cboDDiem.EditValue.ToString();
            frm.iHeThong = int.Parse(cboDChuyen.EditValue.ToString());
            frm.iBoPhan = -1;
            string sLoaiMay;
            sLoaiMay = cboLMay.EditValue.ToString();
            if (frm.ShowDialog() == DialogResult.Cancel) return;
            string sMsMay;

            sMsMay = frm.MsMay;
            sLoaiMay = frm.LoaiMay;
            if (sMsMay == "") return;
            if (sLoaiMay != cboLMay.EditValue.ToString()) cboLMay.EditValue = sLoaiMay;
            cboThietBi.EditValue = sMsMay;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datTNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoTuNgay", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            } 
            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoDenNgay", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoDDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoDChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }
            
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoLMay", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }
            if (cboThietBi.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "KhongCoMay", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return;
            }


            string sLBT = cboLoaiBT.EditValue.ToString();
            //sLBT = Commons.Modules.ObjSystems.SplitString(sLBT);
            sLBT = "*" + sLBT.Replace(", ", "*,*") + "*";
//optBCao = 1 BC group theo NX
//optBCao = 2 BC group He thong
//optBCao = 3 BC loai thiet bi
//optBCao = 4 BC group May
//else no group
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDanhSachVTPTTieuHao", datTNgay.DateTime, datDNgay.DateTime,
                cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue.ToString(), cboThietBi.EditValue.ToString(), Commons.Modules.UserName, Commons.Modules.TypeLanguage, optTuyChon.SelectedIndex, sLBT, optBCao.SelectedIndex));
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC,
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }
            
            try
            {
                if (Commons.Modules.iReport == 1)
                {
                    InReport(dtTmp);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }
            dtTmp.Columns.Remove("TEN_GROUP");
            dtTmp.AcceptChanges();
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, true, true, sUC);
            InDuLieu();
            
        }
#region In Excel
        private void InDuLieu()
        {
            string sPath = "";


            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;
                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 9;
                prbIN.Properties.Minimum = 0;
                grvChung.ExportToXls(sPath);

                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
              


                Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
             
                Excel.Workbook xlWorkBook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);

                //xlWorkBook = excelWorkbooks.Open(sPath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", false, false, 0, true);


                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 4, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(xlWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 8, Dong);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong++;
                if (optTuyChon.SelectedIndex == 0)
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "TieuDeBC1", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                else
                    Commons.Modules.MExcel.DinhDang(xlWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sUC, "TieuDeBC2", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true,
                        Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                string stmp = "";
                Dong++;
                stmp = lblTNgay.Text + " : " + datTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text + " : " + datDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);


                Dong++;
                stmp = lblDDiem.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                Dong++;
                stmp = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                Dong++;
                stmp = lblLMay.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, TCot);
                Dong++;
                stmp = lblMTBi.Text + " : " + cboThietBi.Text;
                Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Dong++;

                Dong++;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong + TDong , TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = xlWorkSheet.get_Range(xlWorkSheet.Cells[Dong + 1, 1], xlWorkSheet.Cells[Dong + 1, 1]).Interior.Color;


                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion

                Commons.Modules.MExcel.ExcelEnd(xlApp, xlWorkBook, xlWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);


                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                                
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                //oldCultureInfo.DateTimeFormat.ShortDatePattern
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 5, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL), true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong + 1, 2, TDong + Dong, TCot);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 30, "@", true, Dong + 1, 4, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 16, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT), true, Dong + 1, TCot, TDong + Dong, TCot);

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion



                xlWorkBook.Save();
                xlApp.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(xlWorkBook);
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(xlApp);

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;


        }
#endregion
        
#region In Report
        private void InReport(DataTable dtTmp)
        {
            try
            {
                dtTmp.TableName = "DL_VTPT";
                frmReport frmBC = new frmReport();
                frmBC.rptName = "rptDanhSachVTPT";
                frmBC.AddDataTableSource(dtTmp);

                dtTmp = new DataTable();
                dtTmp = TieuDe();
                frmBC.AddDataTableSource(dtTmp);
                frmBC.ShowDialog(this);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sUC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable TieuDe()
        {
            DataTable TbTieuDe = new DataTable();
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("NGAY");
            TbTieuDe.Columns.Add("DIA_DIEM");
            TbTieuDe.Columns.Add("DAY_CHUYEN");
            TbTieuDe.Columns.Add("LOAI_TB");
            TbTieuDe.Columns.Add("MSTB");
            TbTieuDe.Columns.Add("STT");

            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("MS_PT_CTY");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("QUY_CACH");
            TbTieuDe.Columns.Add("TEN_DVT");
            TbTieuDe.Columns.Add("SL");
            TbTieuDe.Columns.Add("DU1");
            TbTieuDe.Columns.Add("DU2");
            TbTieuDe.Columns.Add("TONG_TIEN");

            DataRow rTitle = TbTieuDe.NewRow();
            if (optTuyChon.SelectedIndex == 0)
                rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "TieuDeBC1", Commons.Modules.TypeLanguage);
            else
                rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "TieuDeBC2", Commons.Modules.TypeLanguage);

            rTitle["NGAY"] = lblTNgay.Text + " : " + datTNgay.DateTime.Date.ToShortDateString() + " " + lblDNgay.Text + " : " + datDNgay.DateTime.Date.ToShortDateString();
            rTitle["DIA_DIEM"] = lblDDiem.Text + " : " + cboDDiem.TextValue;
            rTitle["DAY_CHUYEN"] = lblDChuyen.Text + " : " + cboDChuyen.TextValue;
            rTitle["LOAI_TB"] = lblLMay.Text + " : " + cboLMay.Text;
            rTitle["MSTB"] = lblMTBi.Text + " : " + cboThietBi.Text;
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "STT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT_CTY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "MS_PT_CTY", Commons.Modules.TypeLanguage);
            rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "TEN_PT", Commons.Modules.TypeLanguage);
            rTitle["QUY_CACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "QUY_CACH", Commons.Modules.TypeLanguage);
            rTitle["TEN_DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "DVT", Commons.Modules.TypeLanguage);
            rTitle["SL"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "SL", Commons.Modules.TypeLanguage);
            rTitle["DU1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "DU1", Commons.Modules.TypeLanguage);
            rTitle["DU2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "DU2", Commons.Modules.TypeLanguage);
            rTitle["TONG_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sUC, "TONG_TIEN", Commons.Modules.TypeLanguage);

            TbTieuDe.TableName = "TD_VTPT";
            TbTieuDe.Rows.Add(rTitle);
            return TbTieuDe;
        }
 
#endregion


    }
}
