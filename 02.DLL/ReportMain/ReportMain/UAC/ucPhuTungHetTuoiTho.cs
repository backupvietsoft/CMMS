using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ReportMain
{
    public partial class ucPhuTungHetTuoiTho : DevExpress.XtraEditors.XtraUserControl
    {
        string sBC = "ucPhuTungHetTuoiTho";
        string sTSo = Commons.Modules.ObjLanguages.GetLanguage("ucBaoCaoChung", "lblTongSo");
        public ucPhuTungHetTuoiTho()
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
        private void LoadLoaiVatTuPT()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLVatTu, Commons.Modules.ObjSystems.MLoadDataLoaiVatTu(1), "MS_LOAI_VT", "TEN_LOAI_VT", lblLOAI_VT.Text);
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
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }
        private void LoadNhomMay()
        {
            try
            {
                DataTable _table = new DataTable();
                try
                {
                    _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, cboLMay.EditValue.ToString());
                }
                catch { _table = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, "-1"); }
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, _table, "MS_NHOM_MAY", "TEN_NHOM_MAY", lblNhomMay.Text);
            }
            catch { }
        }

        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMayPhuTungHetTuoiTho", Commons.Modules.UserName, Commons.Modules.TypeLanguage, cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNhomMay.EditValue));
    
                NOlblTongSo.Text = Commons.Modules.ObjLanguages.GetLanguage(sBC, "lblTongSo") + " : " + dtTmp.Rows.Count.ToString() + " " ;
                dtTmp.Columns["CHON"].ReadOnly = false;
                if ((DataTable)grdMay.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, true, false, false);
                    grvMay.Columns["CHON"].Width = 90;
                    grvMay.Columns["MS_MAY"].Width = 150;
                    grvMay.Columns["TEN_MAY"].Width = 200;
                    grvMay.Columns["Ten_N_XUONG"].Width = 200;
                    grvMay.Columns["TEN_HE_THONG"].Width = 200;
                    grvMay.Columns["TEN_LOAI_MAY"].Width = 200;
                    grvMay.Columns["TEN_NHOM_MAY"].Width = 200;
                }
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, false, false, false);

                for (int i = 1; i < grvMay.Columns.Count; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                }

               



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
            LoadMay();
        }
        private void datTThang_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }

        private void datDThang_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
        private void cboDDiem_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }
        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }
        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
        private void ucBieuDoChiPhiTheoThang_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            autocomlelte();            
            datDNgay.DateTime = DateTime.Now;
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadLoaiVatTuPT();
            Commons.Modules.SQLString = "";
            LoadMay();
        }
        #endregion
        #region sự kiện form
        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
            }
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvMay);
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }
        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        #endregion

        #region in báo cáo
        private delegate void CallProcessBar(object dt);
        string sPath = "";

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!KiemDLieu()) return;
            if (txtPhanTram.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucPhuTungHetTuoiTho", "MsgBanChuaNhapPhanTramTuoiTho", Commons.Modules.TypeLanguage));
                txtPhanTram.Focus();
                return;
            }
            //tao bảng tạm
            string sBT;
            sBT = "BTPTHHTT" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, (DataTable)grdMay.DataSource, "");
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_GetDSPhuTungHetTuoiThoTheoMay", sBT, datDNgay.EditValue,Convert.ToDouble(txtPhanTram.EditValue), cboLVatTu.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoDuLieuXuatExcel", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }
                sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                if (sPath == "") return;
                Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
                t.Start(dtTmp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }


        private Boolean KiemDLieu()
        {

            if (datDNgay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoDenNgay", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return false;
            }
            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoDiaDiem", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }
            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoDayChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }
            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoLoaiMay", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }
            if (cboNhomMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoNhomMay", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }
            if (cboLVatTu.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoLoaiVatTu", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }
            return true;
        }


        private void ShowProcessBar(object dt)
        {
            if (prbIN.InvokeRequired)
            {
                prbIN.Invoke(new CallProcessBar(ShowProcessBar), dt);
            }
            else
            {
                BeginInvoke((Action)(() =>
                {
                    prbIN.Properties.Stopped = false;
                    btnExecute.Enabled = false;
                    btnALL.Enabled = false;
                    btnNotALL.Enabled = false;
                    btnThoat.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;
                }));
                Thread t = new Thread(new ParameterizedThreadStart(InExcel));
                t.Start(dt);

            }
        }

        private void InExcel(object dt)
        {
            try
            {
                DataTable dtData = dt as DataTable;
                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }

                ExcelPackage pck = new ExcelPackage();
                var ws1 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "bcTuoiTho", Commons.Modules.TypeLanguage));
                pck.SaveAs(fi);

                #region "in Thong Tin Chung"
                Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws1, "C");
                #endregion

                #region "In Thong Tin Sheet 1"
                int iDong = 5;
                ws1.Row(4).Height = 9;

                var allCells = ws1.Cells[iDong, 1, iDong, dtData.Columns.Count];
                
                Commons.Modules.MExcel.MText(ws1, sBC, "TieuDePTHTT", iDong, 1, iDong, dtData.Columns.Count, true, true, 16, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);
                iDong++;
                ws1.Row(iDong).Height = 9;
                iDong++;
                Commons.Modules.MExcel.MText(ws1, sBC, lblDDiem.Name, iDong, 2, true);
                Commons.Modules.MExcel.MText(ws1, "", cboDDiem.TextValue, iDong, 3, true);

                Commons.Modules.MExcel.MText(ws1, sBC, lblDChuyen.Name, iDong, 4, true);
                Commons.Modules.MExcel.MText(ws1, "", cboDChuyen.TextValue, iDong, 5, true);

                iDong++;
                Commons.Modules.MExcel.MText(ws1, sBC, lblLMay.Name, iDong, 2, true);
                Commons.Modules.MExcel.MText(ws1, "", cboLMay.Text, iDong, 3, true);

                Commons.Modules.MExcel.MText(ws1, sBC, lblNhomMay.Name, iDong, 4, true);
                Commons.Modules.MExcel.MText(ws1, "", cboNhomMay.Text, iDong, 5, true);

                iDong++;
                Commons.Modules.MExcel.MText(ws1, sBC, lblLOAI_VT.Name, iDong, 2, true);
                Commons.Modules.MExcel.MText(ws1, "", cboLVatTu.Text, iDong, 3, iDong, 5, true, true);


                List<string> sCotNgay = new List<string>() { };
                List<List<Object>> WidthColumns = new List<List<Object>>();
                List<Object> WidthColumnsName = new List<Object>();


                iDong++;
                ws1.Row(iDong).Height = 9;
                iDong++;
                sCotNgay = new List<string>()
                    {
                            "NGAY_THAY_CUOI",
                            "BAO_HANH_DEN_NGAY"
                    };


                WidthColumnsName = new List<Object>()
                    {"STT",5};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"MS_MAY",15};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TEN_MAY",40};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"MS_BO_PHAN",15};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TEN_BO_PHAN",40};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"MS_PT",15};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TEN_PT",50};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"MS_VI_TRI_PT",15};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TUOI_THO",10};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TG_SD_TT",10};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TG_CL",10};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"MS_DH_NHAP_PT",15};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"XUAT_XU",18};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"GHI_CHU",30};
                WidthColumns.Add(WidthColumnsName);


                if (dtData.Rows.Count > 0)
                    ws1.Cells[iDong, 1].LoadFromDataTable(dtData, true);

                Commons.Modules.MExcel.MFormatExcel(ws1, dtData, iDong, sBC, sCotNgay, "dd/MM/yyyy", WidthColumns); //FORMAT
                #endregion


                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);


                System.Diagnostics.Process.Start(fi.FullName);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "XuatExcelKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                BeginInvoke((Action)(() =>
                {
                    this.Cursor = Cursors.Default;
                    btnExecute.Enabled = true;
                    btnALL.Enabled = true;
                    btnNotALL.Enabled = true;
                    btnThoat.Enabled = true;
                    prbIN.Properties.Stopped = true;
                }));
                sPath = "";
            }
            catch { }
        }
        private void autocomlelte()
        {
            string[] str =  {"10","20","30","40","50","60","70","80","90", "100" };
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(str);
            txtPhanTram.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPhanTram.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPhanTram.MaskBox.AutoCompleteCustomSource = collection;
        }


        #endregion

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdMay.DataSource;

            try
            {
                string dk = "";

                if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_NHOM_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_LOAI_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTmp.DefaultView.RowFilter = dk;

                
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

        private void grvMay_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                NOlblTongSo.Text = sTSo + " : " + grvMay.RowCount.ToString() + " ";
            }catch { }
        }
    }
}
