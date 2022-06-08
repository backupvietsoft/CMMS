using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Threading;

namespace VietShape
{
    public partial class ucTinhTrangThietbi : DevExpress.XtraEditors.XtraUserControl
    {
        String sBC = "ucTinhTrangThietbi";
        public ucTinhTrangThietbi()
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
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
        }

        private void LoadNhomMay(string sLMay)
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNMay, Commons.Modules.ObjSystems.MLoadDataNhomMay(1, sLMay), "MS_NHOM_MAY", "TEN_NHOM_MAY", "");
            }
            catch { }
        }


        #endregion

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (cboLMay.Text == "") return;
            string sLMay = "-1";
            try
            {
                sLMay = cboLMay.EditValue.ToString();
            }
            catch { sLMay = "-1"; }
            Commons.Modules.SQLString = "0LM";
            LoadNhomMay(sLMay);
            Commons.Modules.SQLString = "";
        }

        private void ucTinhTrangThietbi_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            datTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datDNgay.DateTime = datTNgay.DateTime.Date.AddMonths(1).AddDays(-1);

            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay("-1");
            Commons.Modules.SQLString = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {

                if (datDNgay.DateTime.Date < datTNgay.DateTime.Date)
                {
                    Commons.MssBox.Show(sBC, "msgTuNgayLonHonDenNgay");
                    return;
                }
                sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                if (sPath == "") return;

                BeginInvoke((Action)(() =>
                {
                    prbIN.Properties.Stopped = false;
                }));



                Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
                t.Start(true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


        Thread t = null;
        private delegate void CallProcessBar(object flag);
        string sPath = "";

        private void ShowProcessBar(object flag)
        {
            if (prbIN.InvokeRequired)
            {
                prbIN.Invoke(new CallProcessBar(ShowProcessBar), true);
            }
            else
            {
                BeginInvoke((Action)(() =>
                {
                    prbIN.Properties.Stopped = false;
                    EnableControl(false);
                    this.Cursor = Cursors.WaitCursor;

                }));
                t = new Thread(new ThreadStart(InExcel));
                t.Start();
                
            }
        }

        private Boolean TaoData (out DataTable dtData)
        {
            dtData = null;
            #region "TaoData"
            try
            {

                dtData = new DataTable();
                dtData.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCTinhTrangThietbi", datTNgay.DateTime.Date, datDNgay.DateTime.Date, (optNgay.SelectedIndex == 0 ? 0 : 1), Commons.Modules.UserName, cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNMay.EditValue, Commons.Modules.TypeLanguage,chkBThuong.Checked,chkYCSD.Checked,chkKHTT.Checked,chkBaoTri.Checked,chkDangBaoTri.Checked));
                
                    
                if (dtData.Rows.Count  == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgKhongCoDuLieuXuatExcel", Commons.Modules.TypeLanguage));
                    return false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
            return true;
            #endregion

        }
        
        private void InExcel ()
        {
            try
            {
                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }

                ExcelPackage pck = new ExcelPackage();
                var ws1 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sBTDKSheet", Commons.Modules.TypeLanguage));
                pck.SaveAs(fi);

                DataTable dtData = new DataTable();

                #region "Tao Data"
                if (TaoData(out dtData) == false)
                {
                    try
                    {
                        BeginInvoke((Action)(() =>
                        {
                            this.Cursor = Cursors.Default;
                            EnableControl(true);
                            prbIN.Properties.Stopped = true;
                        }));
                        sPath = "";
                    }
                    catch { }
                    return;
                }
                #endregion

                #region "in Thong Tin Chung"
                Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws1);
                #endregion


                #region "In Thong Tin Sheet 1"
                int iDong = 5;
                ws1.Row(4).Height = 9;

                var allCells = ws1.Cells[iDong, 1, iDong, dtData.Columns.Count];
                Commons.Modules.MExcel.MText(ws1, sBC, "sBaoCaoTinhTrangThietbi", iDong, 1, iDong, dtData.Columns.Count,true,true,16,ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);

                iDong++;
                if (optNgay.SelectedIndex == 0)
                    Commons.Modules.MExcel.MText(ws1, "", lblTNgay.Text + " " + datTNgay.Text + " " + lblDNgay.Text + " " + datDNgay.Text, iDong, 1, iDong, dtData.Columns.Count, true, true, 13, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);
                else
                    Commons.Modules.MExcel.MText(ws1, "", lblDNgay.Text + " " + datDNgay.Text, iDong, 1, iDong, dtData.Columns.Count, true, true, 13, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);

                iDong++;
                Commons.Modules.MExcel.MText(ws1, "", lblDDiem.Text + " : " + cboDDiem.TextValue, iDong, 2, true);
                Commons.Modules.MExcel.MText(ws1, "", lblDChuyen.Text + " : " + cboDChuyen.TextValue, iDong, 4, true);

                iDong++;
                Commons.Modules.MExcel.MText(ws1, "", lblLMay.Text + " : " + cboLMay.Text, iDong, 2, true);
                Commons.Modules.MExcel.MText(ws1, "", lblNhomMay.Text + " : " + cboNMay.Text, iDong, 4, true);

                #endregion

                List<string> sCotNgay = new List<string>() { };
                List<List<Object>> WidthColumns = new List<List<Object>>();
                List<Object> WidthColumnsName = new List<Object>();


                iDong++;
                ws1.Row(iDong).Height = 9;
                iDong++;



                #region "In BTDK"
                sCotNgay = new List<string>()
                    {
                            "NGAY_BD",
                            "NGAY_KT"
                    };

                WidthColumnsName = new List<Object>()
                    {"MS_MAY",15};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TEN_MAY",30};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TINH_TRANG_MAY",25};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TT_CT",60};
                WidthColumns.Add(WidthColumnsName);

                if (dtData.Rows.Count > 0)
                    ws1.Cells[iDong, 1].LoadFromDataTable(dtData, true);

                
                Commons.Modules.MExcel.MFormatExcel(ws1, dtData, iDong, sBC,sCotNgay,"dd/MM/yyyy",WidthColumns,true,true,true);

                #endregion


                if (fi.Exists)
                    fi.Delete();
                
                pck.SaveAs(fi);
                System.Diagnostics.Process.Start(fi.FullName.ToString());                

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
                    EnableControl(true);
                    prbIN.Properties.Stopped = true;
                }));
                sPath = "";
            }
            catch { }
        }

        private void EnableControl(bool flag)
        {
            btnExecute.Enabled = flag;
            btnThoat.Enabled = flag;

            optNgay.Properties.ReadOnly =! flag;
            

            datTNgay.Properties.ReadOnly =! flag;
            datDNgay.Properties.ReadOnly =! flag;

            cboDDiem.ReadOnly =! flag;
            cboDChuyen.ReadOnly =! flag;
            
            cboLMay.Properties.ReadOnly =! flag;
            cboNMay.Properties.ReadOnly =! flag;
            
            chkBaoTri.Enabled = flag;
            chkDangBaoTri.Enabled = flag;
            chkBThuong.Enabled = flag;
            chkKHTT.Enabled = flag;
            chkYCSD.Enabled = flag;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}