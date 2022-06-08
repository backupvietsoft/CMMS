using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;
using System.Threading;

namespace MVControl
{
    public partial class ucTongHopTinhHinhBaoTri : DevExpress.XtraEditors.XtraUserControl
    {
        String sBC = "ucTongHopTinhHinhBaoTri";
        public ucTongHopTinhHinhBaoTri()
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

        private void ucTongHopTinhHinhBaoTri_Load(object sender, EventArgs e)
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

        private Boolean TaoData (out DataTable dtPBT, out DataTable dtGSTT, out DataTable dtHC)
        {
            dtPBT = null;
            dtGSTT = null;
            dtHC = null;

            #region "TaoData"
            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
                connection.Open();

                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandText = "spTongHopTinhHinhbaoTri";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TNgay", datTNgay.DateTime.Date));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DNgay", datDNgay.DateTime.Date));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USERNAME", Commons.Modules.UserName));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NNGU", Commons.Modules.TypeLanguage));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MS_NHA_XUONG", cboDDiem.EditValue));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MS_HE_THONG", cboDChuyen.EditValue));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MS_LOAI_MAY", cboLMay.EditValue));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MS_NHOM_MAY", cboNMay.EditValue));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iTre", (chkTT.GetItemChecked(0) ? 0 : 1000000)));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iDungHan", (chkTT.GetItemChecked(1) ? 0 : 1000000)));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iTruocHan", (chkTT.GetItemChecked(2) ? 0 : -1000000)));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iChuaLam", (chkTT.GetItemChecked(3) ? -123456789 : 123456789)));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iLoai", (optNgay.SelectedIndex == 0 ? 0 : 1)));

                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                DataSet dsTmp = new DataSet();
                adapter.Fill(dsTmp);
                dtPBT = dsTmp.Tables[0];
                dtGSTT = dsTmp.Tables[1];
                dtHC = dsTmp.Tables[2];

                if (dtPBT.Rows.Count + dtGSTT.Rows.Count + dtHC.Rows.Count == 0)
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

                DataTable dtPBT = new DataTable();
                DataTable dtGSTT = new DataTable();
                DataTable dtHC = new DataTable();

                #region "Tao Data"
                if (TaoData(out dtPBT, out dtGSTT, out dtHC) == false)
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

                var allCells = ws1.Cells[iDong, 1, iDong, dtPBT.Columns.Count];
                Commons.Modules.MExcel.MText(ws1, sBC, "sBaoCaoTongHopTinhHinhBaoTriTieuDe", iDong, 1, iDong, dtPBT.Columns.Count,true,true,16,ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);

                iDong++;
                if (optNgay.SelectedIndex == 0)
                    Commons.Modules.MExcel.MText(ws1, "", lblTNgay.Text + " " + datTNgay.Text + " " + lblDNgay.Text + " " + datDNgay.Text, iDong, 1, iDong, dtPBT.Columns.Count, true, true, 13, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);
                else
                    Commons.Modules.MExcel.MText(ws1, "", lblDNgay.Text + " " + datDNgay.Text, iDong, 1, iDong, dtPBT.Columns.Count, true, true, 13, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);

                iDong++;
                Commons.Modules.MExcel.MText(ws1, "", lblDDiem.Text + " : " + cboDDiem.TextValue, iDong, 2, true);
                Commons.Modules.MExcel.MText(ws1, "", lblDChuyen.Text + " : " + cboDChuyen.TextValue, iDong, 5, true);

                iDong++;
                Commons.Modules.MExcel.MText(ws1, "", lblLMay.Text + " : " + cboLMay.Text, iDong, 2, true);
                Commons.Modules.MExcel.MText(ws1, "", lblNhomMay.Text + " : " + cboNMay.Text, iDong, 5, true);

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
                            "NGAY_BD_BT",
                            "NGAY_BD_TT"
                    };

                WidthColumnsName = new List<Object>()
                    {"MS_MAY",18};
                WidthColumns.Add(WidthColumnsName);

                if (dtPBT.Rows.Count > 0)
                    ws1.Cells[iDong, 1].LoadFromDataTable(dtPBT, true);

                Commons.Modules.MExcel.MFormatExcel(ws1, dtPBT, iDong, sBC, sCotNgay, "dd/MM/yyyy", WidthColumns);
                ws1.Column(1).Width = 20;
                ws1.Column(9).Width = 15;
                #endregion

                sCotNgay = new List<string>();
                #region "In GSTT"
                iDong = 1;
                var ws2 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sGSTTSheet", Commons.Modules.TypeLanguage));
                ws2.Row(iDong).Height = 9;
                
                iDong++;
                Commons.Modules.MExcel.MText(ws2, sBC, "sBCGiamSatTinhTrangTieuDe", iDong, 1, iDong, dtGSTT.Columns.Count, true, true, 16, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);      
                iDong++;
                ws2.Row(iDong).Height = 9;                
                iDong++;
                sCotNgay = new List<string>()
                    {
                        "NGAY_GS_KH",
                        "NGAY_GS_TT"
                    };

                if (dtGSTT.Rows.Count > 0)
                    ws2.Cells[iDong, 1].LoadFromDataTable(dtGSTT, true);

                Commons.Modules.MExcel.MFormatExcel(ws2, dtGSTT, iDong, sBC, sCotNgay, "dd/MM/yyyy");
                if (ws2.Column(5).Width > 50) ws2.Column(5).Width = 50;
                if (ws2.Column(7).Width > 40) ws2.Column(7).Width = 50;
                ws2.Column(12).Width = 10;
                #endregion

                sCotNgay = new List<string>();
                #region "In Hieu Chuan"
                iDong = 1;
                var ws3 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sHCSheet", Commons.Modules.TypeLanguage));
                ws3.Row(iDong).Height = 9;
                
                iDong++;
                Commons.Modules.MExcel.MText(ws3, sBC, "sBCHieuChuanTieuDe", iDong, 1, iDong, dtHC.Columns.Count, true, true, 16, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);
                                                
                iDong++;
                ws3.Row(iDong).Height = 9;
                iDong++;
                sCotNgay = new List<string>()
                    {
                        "NGAY_HC_KH",
                        "NGAY_HC_TT"
                    };
                if (dtHC.Rows.Count > 0)
                {
                    ws3.Cells[iDong, 1].LoadFromDataTable(dtHC, true);
                }
                Commons.Modules.MExcel.MFormatExcel(ws3, dtHC, iDong, sBC, sCotNgay, "dd/MM/yyyy");
                ws3.Column(11).Width = 10;
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
            chkTT.Enabled = flag;


        }
        
    }
}