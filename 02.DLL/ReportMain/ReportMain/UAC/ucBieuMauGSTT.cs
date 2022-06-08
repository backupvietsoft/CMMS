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

namespace ReportMain
{
    public partial class ucBieuMauGSTT : DevExpress.XtraEditors.XtraUserControl
    {

        public ucBieuMauGSTT()
        {
            InitializeComponent();
        }

        private void LoadNX()
        {
            try
            {
                cboDDiem.KeyFieldName = "MS_N_XUONG";
                cboDDiem.ParentFieldName = "MS_CHA";
                cboDDiem.ColumnDisplayName = "TEN_N_XUONG";
                cboDDiem.DataSource = Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1);
                cboDDiem.DataBind();
            }
            catch { }
        }
        private void LoadDChuyen()
        {
            try
            {
                cboDChuyen.KeyFieldName = "MS_HE_THONG";
                cboDChuyen.ParentFieldName = "MS_CHA";
                cboDChuyen.ColumnDisplayName = "TEN_HE_THONG";
                cboDChuyen.DataSource = Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1);
                cboDChuyen.DataBind();
            }
            catch { }
        }
        private void LoadLoaiMay()
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetLoaiMayTheoNXHTCoAll", (cboDDiem.TextValue == "" ? "-1" : cboDDiem.EditValue), (cboDChuyen.TextValue == "" ? "-1" : cboDChuyen.EditValue), Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                    Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
                }
                catch { }
            }
            catch { }
        }
        private void LoadMay()
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboLMay.Text.ToString())) return;
                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetMayTheoLMNXHT", Commons.Modules.UserName, (cboLMay.Text == "" ? "-1" : cboLMay.EditValue), "-1", (cboDDiem.TextValue == "" ? "-1" : cboDDiem.EditValue), (cboDChuyen.TextValue == "" ? "-1" : cboDChuyen.EditValue), 0, 0));
                    cboThietbi.Properties.DataSource = dt;
                    cboThietbi.Properties.DisplayMember = "TEN_MAY";
                    cboThietbi.Properties.ValueMember = "MS_MAY";
                    if (dt.Rows.Count > 0)
                    {
                        cboThietbi.EditValue = dt.Rows[0][0];
                    }
                    else
                    {
                    }
                    cboThietbi.Properties.View.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "MS_MAY", Commons.Modules.TypeLanguage);
                    cboThietbi.Properties.View.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "TEN_MAY", Commons.Modules.TypeLanguage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch { }
        }

        private void ucKeHoachTuan_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNX();
                LoadDChuyen();
                LoadLoaiMay();
                datTNgay.DateTime = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
                datDNgay.DateTime = datTNgay.DateTime.AddMonths(1).AddDays(-1);
            }
            catch { }
            if (System.Environment.MachineName.ToUpper() == "MASHILOVE")
                grdChung.Visible = true;
            else grdChung.Visible = false;

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_getGSTTTheoMay", Commons.Modules.UserName, Commons.Modules.TypeLanguage, datTNgay.DateTime.Date, datDNgay.DateTime.Date,
                cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue,cboThietbi.EditValue));
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuMauGSTT",
                    "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                return;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, false, true, true, true, "ucBieuMauGSTT");
            grvChung.Columns["STT"].Visible = false;
            grvChung.Columns["CV"].Visible = false;
            InDuLieu();
        }
        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");

            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();
            Excel.Range title;
            string sTmp;
            try
            {
                int TCot = grvChung.Columns.Count - 2;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                prbIN.Visible = true;
                prbIN.Position = 0;
                prbIN.Properties.Step = 1;
                prbIN.Properties.PercentView = true;
                prbIN.Properties.Maximum = 11;// grvChung.RowCount + 11 + TCot - 4;
                prbIN.Properties.Minimum = 0;
                //grdChung.ExportToXls(sPath,);
                grdChung.ExportToXls(sPath, new DevExpress.XtraPrinting.XlsExportOptions(DevExpress.XtraPrinting.TextExportMode.Value, true, true, true, true));

                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                excelApplication.Cells.Font.Name = "Times New Roman";
                excelApplication.Cells.Font.Size = 10;
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 2, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucBieuMauGSTT", "TieuDe", Commons.Modules.TypeLanguage),Dong, 1, "@", 16, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion
                string stmp = "";
                Dong++;
                stmp = lblTuNgay.Text + " : " + datTNgay.DateTime.Date.ToShortDateString() + "   " + lblDenNgay.Text + " : " + datDNgay.DateTime.Date.ToShortDateString();
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@",10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;
                stmp = lblNhaXuong.Text + " : " + cboDDiem.TextValue;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong,3);
                stmp = lblDayChuyen.Text + " : " + cboDChuyen.TextValue; 
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong++;
                stmp = LabLTB.Text + " : " + cboLMay.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 3);
                stmp = LabTB5.Text + " : " + cboThietbi.Text + "( "+ cboThietbi.EditValue+ " )";
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, true,
            Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);
                Dong ++;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 2, TCot);
                title.Interior.Pattern = Excel.Constants.xlNone;
                for (int Cot = 1; Cot <= TCot; Cot++)
                {
                    if (Cot < 4 || Cot > 5)
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, Cot, Dong + 1, Cot);
                        title.MergeCells = true;
                        title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    }
                }
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 4, Dong, 5);
                title.MergeCells = true;
                title.Value2 = "Phạm vi	";
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                #region prb
                prbIN.PerformStep();
                prbIN.Update();
                #endregion


                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                    true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100);

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong, 1, Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong, 2, Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 50, "@", true, Dong, 3, Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", true, Dong, 4, Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", true, Dong, 5, Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong, 6, Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong, 7, Dong, 7);

                DataTable dtTmp = new DataTable();
                DataTable dtMay = new DataTable();
                dtTmp = (DataTable)grdChung.DataSource;

                int iTongDong = 0;
                int iDongBD = Dong + 2;

                for (int i = 0; i < dtTmp.Rows.Count;)
                {
                    sTmp = dtTmp.Rows[i]["DON_VI"].ToString();
                    dtMay = new DataTable();
                    dtMay = dtTmp.Copy();
                    dtMay.DefaultView.RowFilter = "DON_VI = '" + dtTmp.Rows[i]["DON_VI"].ToString() + "' ";
                    dtMay = dtMay.DefaultView.ToTable();
                    iTongDong = dtMay.Rows.Count + iDongBD - 1;

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDongBD, 1, iTongDong, 1);
                    title.Value2 = Convert.ToString(null);
                    title.MergeCells = true;

                    title.Value2 = sTmp;
                    i = i + dtMay.Rows.Count;
                    iDongBD = iTongDong + 1;
                }
                iTongDong = 0;
                iDongBD = Dong + 2;

                for (int i = 0; i < dtTmp.Rows.Count;)
                {
                    sTmp = dtTmp.Rows[i]["VT_KT"].ToString();
                    dtMay = new DataTable();
                    dtMay = dtTmp.Copy();
                    dtMay.DefaultView.RowFilter = "VT_KT = '" + dtTmp.Rows[i]["VT_KT"].ToString() + "' ";
                    dtMay = dtMay.DefaultView.ToTable();
                    iTongDong = dtMay.Rows.Count + iDongBD - 1;

                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, iDongBD, 2, iTongDong, 2);
                    title.Value2 = Convert.ToString(null);
                    title.MergeCells = true;

                    title.Value2 = sTmp;
                    i = i + dtMay.Rows.Count;
                    iDongBD = iTongDong + 1;
                }
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong +1, TCot);
                title.Borders.LineStyle = 1;
                title.Font.Bold = true;

                Dong += grvChung.RowCount + 2;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Người kiểm tra", Dong, 2);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 3, Dong, TCot);
                title.MergeCells = true;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Người chịu trách nhiệm", Dong + 1, 2);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 3, Dong + 1, TCot);
                title.MergeCells = true;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Người duyệt", Dong + 2, 2);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 3, Dong + 2, TCot);
                title.MergeCells = true;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Xác nhận", Dong, 1, "@", 10, true,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 2, 1);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 2, TCot);
                title.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexNone,
                        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                title.Borders.LineStyle = 1;


                Dong += 3;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Ghi chú đặt biệt", Dong, 1, "@", 10, true);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 4, TCot);
                title.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexNone,
                        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                title.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 2;

                Dong += 5;
                var topOffset = 0.0;
                var leftOffset = 0.0;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "1. Trong bảng kết quả đánh dấu kí hiệu xác nhận tình trạng từng hạng mục", Dong, 2, "@", 10, false,
                Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong, TCot - 2);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "OK", Dong, TCot - 1,"@",10,true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter);
                Excel.Range a = (Excel.Range)excelWorkSheet.Cells[Dong + 1, TCot - 1];
                try
                {
                    topOffset = (double)(a.Top);
                    leftOffset = (double)(a.Left);
                    var sharp = excelWorkSheet.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeOval, (float)leftOffset + 30, (float)topOffset + 1, 10, 10);
                    sharp.Fill.ForeColor.RGB = Microsoft.VisualBasic.Information.RGB(255, 255, 255);
                    sharp.Line.ForeColor.RGB = Microsoft.VisualBasic.Information.RGB(0, 0, 0);

                    var sharp2 = excelWorkSheet.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, (float)leftOffset + 90, (float)topOffset + 1, 10, 10);
                    sharp2.Fill.ForeColor.RGB = Microsoft.VisualBasic.Information.RGB(0, 0, 0);
                    sharp2.Line.ForeColor.RGB = Microsoft.VisualBasic.Information.RGB(0, 0, 0);

                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message);
                }

                var s = excelWorkSheet.Cells[1, 1];

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Sữa chữa xong", Dong, TCot, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "2. Các hạng mục có thể kiểm tra đồng thời, sau khi thực hiện xong thì phải đánh dấu xác nhận", Dong + 1, 2, "@", 10, false,
               Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong + 1, TCot - 2);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "3. Người kiểm tra có trách nhiệm ghi chép kết quả và xác nhận trước khi người chịu trách nhiệm và người duyệt xác nhận.", Dong + 2, 2, "@", 10, false,
              Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong + 2, TCot - 2);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "phải sữa chữa", Dong + 2, TCot - 1, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Cần chú ý", Dong + 2, TCot, "@", 10, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter);
                Excel.Range b = (Excel.Range)excelWorkSheet.Cells[Dong + 3, TCot - 1];
                try
                {
                    topOffset = (double)(b.Top);
                    leftOffset = (double)(b.Left);
                    var sharp = excelWorkSheet.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, (float)leftOffset + 30, (float)topOffset + 1, 10, 10);
                    sharp.Fill.ForeColor.RGB = Microsoft.VisualBasic.Information.RGB(255, 255, 255);
                    sharp.Line.ForeColor.RGB = Microsoft.VisualBasic.Information.RGB(0, 0, 0);

                    var sharp2 = excelWorkSheet.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeIsoscelesTriangle, (float)leftOffset + 90, (float)topOffset + 1, 10, 10);
                    sharp2.Fill.ForeColor.RGB = Microsoft.VisualBasic.Information.RGB(255, 255, 255);
                    sharp2.Line.ForeColor.RGB = Microsoft.VisualBasic.Information.RGB(0, 0, 0);

                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message);
                }


                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "4. Khi phát hiện tình trạng bất thường thì phải ghi lại, đưa ra đối sách đồng thời ghi lại ở biên bản sửa chữa.", Dong + 3, 2, "@", 10, false,
Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, TCot - 2);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "Nội dung chủ yếu", Dong, 1, "@", 10, true,
                Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, false, Dong + 3, 1);


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 3, TCot);
                title.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexNone,
                        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                title.Borders.LineStyle = 1;
                excelApplication.Visible = true;
                excelWorkbook.Save();
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBieuMauGSTT",
                    "InKhongThanhCong", Commons.Modules.TypeLanguage), this.Name);
                excelApplication.Visible = true;


            }

            prbIN.Position = prbIN.Properties.Maximum;
            this.Cursor = Cursors.Default;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();

        }

        private void ucKeHoachTuan_Leave(object sender, EventArgs e)
        {

        }

        private void cboDChuyen_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                LoadLoaiMay();
            }
            catch { }
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboLMay.Text.ToString())) return;
                LoadMay();
            }
            catch { }
        }

        private void grvChung_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "HM_KT") //tên cột của gridview
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["CV"]);
                if (category == "1")//Điều kiện là gì ()
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
        }
    }
}
