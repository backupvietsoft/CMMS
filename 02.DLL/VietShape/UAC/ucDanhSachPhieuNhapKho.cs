using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using OfficeOpenXml;
using System.Threading;
using OfficeOpenXml.Style;

namespace VietShape
{
    public partial class ucDanhSachPhieuNhapKho : DevExpress.XtraEditors.XtraUserControl
    {
        String sBC = "ucDanhSachPhieuNhapKho";


        public ucDanhSachPhieuNhapKho()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        
        private void ucDanhSachPhieuNhapKho_Load(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.SQLString = "0Load";
                datTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                datDNgay.DateTime = datTNgay.DateTime.Date.AddMonths(1).AddDays(-1);

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, Commons.Modules.ObjSystems.MLoadDataKho(1), "MS_KHO", "TEN_KHO", "");
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLVT, Commons.Modules.ObjSystems.MLoadDataLoaiVatTu(1), "MS_LOAI_VT", "TEN_LOAI_VT", "");
            }
            catch { }
        }
        
        private void btnExecute_Click(object sender, EventArgs e)
        {
            sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            if (sPath == "") return;

            if (datDNgay.DateTime.Date < datTNgay.DateTime.Date)
            {
                Commons.MssBox.Show(sBC, "msgTuNgayLonHonDenNgay");
                return;
            }

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

        public DateTime TNgay, DNgay;
        public string sMsLVT, Uname, sTenLoaiVatTu, sTenKho;
        public int iMsKho, iNN;


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
                t = new Thread(new ParameterizedThreadStart(InExcel));
                t.Start(false);

            }
        }

        private bool TaoData(bool bMail , DateTime TNgay, DateTime DNgay,string sMsLVT ,int iMsKho,string sUserName,int iNNgu, out DataTable dtData)
        {
            Commons.Modules.SQLString = "";
            dtData = null;
            #region "TaoData"
            try
            {
                dtData = new DataTable();
                dtData.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCDanhSachPhieuNhapKho", TNgay.Date, DNgay.Date, sMsLVT, iMsKho, sUserName, iNNgu));

                if (dtData.Rows.Count == 0)
                {
                    if (bMail == false)
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgKhongCoDuLieuXuatExcel", Commons.Modules.TypeLanguage));
                    Commons.Modules.SQLString = "Data Null";
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (bMail == false)
                    XtraMessageBox.Show(ex.Message);

                Commons.Modules.SQLString = ex.Message;
                return false;
            }
            return true;
            #endregion

        }

        public bool GoiMail(string sFile, out string sLoi)
        {
            try
            {
                sPath = sFile;
                InExcel(true);
                sLoi = Commons.Modules.SQLString;
                if (Commons.Modules.SQLString == "")
                    return true;
                else
                {
                    Commons.Modules.ObjSystems.Xoahinh(sFile);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Commons.Modules.ObjSystems.Xoahinh(sFile);
                sLoi = ex.Message.ToString();
                return false;
            }
        }

        private void InExcel(object goiMail)
        {
            Commons.Modules.SQLString = "";
            try
            {
                
                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }

                ExcelPackage pck = new ExcelPackage();
                var ws1 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, sBC, Commons.Modules.TypeLanguage));
                pck.SaveAs(fi);

                DataTable dtData = new DataTable();
                //dtData.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCDanhSachPhieuNhapKho", datTNgay.DateTime.Date, datDNgay.DateTime.Date,cboLVT.EditValue,cboKho.EditValue,Commons.Modules.UserName, Commons.Modules.TypeLanguage));

                #region "Tao Data"
                Commons.Modules.SQLString = "";

                //DateTime TNgay, DNgay;
                //string sMsLVT,Uname;
                //int iMsKho,iNN;
                if (bool.Parse(goiMail.ToString()) == false)
                {
                    TNgay = datTNgay.DateTime.Date;
                    DNgay = datDNgay.DateTime.Date;
                    sMsLVT = cboLVT.EditValue.ToString();
                    iMsKho = int.Parse(cboKho.EditValue.ToString());
                    Uname = Commons.Modules.UserName;
                    iNN = Commons.Modules.TypeLanguage;
                    sTenLoaiVatTu = cboLVT.Text;
                    sTenKho = cboKho.Text;
                }
                if (TaoData(bool.Parse(goiMail.ToString()), TNgay, DNgay, sMsLVT, iMsKho, Uname, iNN,out dtData) == false)
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
                    if (Commons.Modules.SQLString == "") Commons.Modules.SQLString = "Create Data Error";
                    return;
                }
                #endregion

                #region "in Thong Tin Chung"
                Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws1,"C");
                #endregion


                #region "In Thong Tin Sheet 1"
                int iDong = 5;
                ws1.Row(4).Height = 9;

                var allCells = ws1.Cells[iDong, 1, iDong, dtData.Columns.Count];
                Commons.Modules.MExcel.MText(ws1, sBC, "tdBaoCaoNhapKho", iDong, 1, iDong, dtData.Columns.Count, true, true, 16, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);

                iDong++;

                Commons.Modules.MExcel.MText(ws1, "", Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "lblTNgay", Commons.Modules.TypeLanguage) + " " + TNgay.ToShortDateString() + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "lblDNgay", Commons.Modules.TypeLanguage) + " " + DNgay.ToShortDateString(), iDong, 1, iDong, dtData.Columns.Count, true, true, 13, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);
                
                iDong++;
                Commons.Modules.MExcel.MText(ws1, "", lblLVT.Text + " : " + sTenLoaiVatTu, iDong, 3, true);
                Commons.Modules.MExcel.MText(ws1, "", lblKH.Text + " : " + sTenKho, iDong, 6, true);
                
                #endregion

                List<List<Object>> WidthColumns = new List<List<Object>>();
                List<Object> WidthColumnsName = new List<Object>();


                iDong++;
                ws1.Row(iDong).Height = 9;
                iDong++;



                #region "In"
                WidthColumnsName = new List<Object>()
                    {"MS_DH_NHAP_PT",20};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"MS_PT",15};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"TEN_PT",25};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TEN_LOAI_VT",20};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"GHI_CHU",30};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"MS_DDH",20};
                WidthColumns.Add(WidthColumnsName);
                if (dtData.Rows.Count > 0)
                    ws1.Cells[iDong, 1].LoadFromDataTable(dtData, true);

                Commons.Modules.MExcel.MFormatExcel(ws1, dtData, iDong, sBC, null, "dd/MM/yyyy", WidthColumns);

                ws1.Column(1).Width = 4;
                ws1.Column(8).Width = 15;
                ws1.Column(6).Width = 12;
                ws1.Column(9).Width = 25;
                ws1.Column(11).Width = 15;
                ws1.Column(12).Width = 15;
                ws1.Column(13).Width = 20;
                #endregion


                if (fi.Exists)
                    fi.Delete();

                pck.SaveAs(fi);
                if (bool.Parse(goiMail.ToString()) == false)
                    System.Diagnostics.Process.Start(fi.FullName.ToString());

            }
            catch (Exception ex)
            {
                if (bool.Parse(goiMail.ToString()) != false)
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sBC, "XuatExcelKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                        ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Commons.Modules.SQLString = ex.Message;
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
            Commons.Modules.SQLString =  "";
        }

        private void EnableControl(bool flag)
        {
            btnExecute.Enabled = flag;
            btnThoat.Enabled = flag;
            

            datTNgay.Properties.ReadOnly = !flag;
            datDNgay.Properties.ReadOnly = !flag;

            cboLVT.Properties.ReadOnly = !flag;
            cboKho.Properties.ReadOnly = !flag;
            
        }


    }
}
