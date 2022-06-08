using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using DevExpress.XtraEditors;

namespace MVControl
{
    public partial class ucBCThoiGianCVNhanVien : UserControl
    {
        public ucBCThoiGianCVNhanVien()
        {
            InitializeComponent();
        }
        public void LoadcboDON_VI1()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll", 1, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDonVi, dt, "MS_DON_VI", "TEN_DON_VI", "");

        }
        public void LoadcboTO()
        {
            if (cboDonVi.EditValue == null)
            {
                cboPhongBan.Properties.DataSource = new DataTable();
                return;
            }

            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanUserAll", 1, cboDonVi.EditValue.ToString(), Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPhongBan, dt, "MS_PB", "TEN_PB", "");

        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if(cboDonVi.EditValue == null)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgChonDonVi", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboPhongBan.EditValue == null)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgChonPhongBan", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCGioCongNhanVien", cboDonVi.EditValue, cboPhongBan.EditValue, Commons.Modules.UserName, datTNgay.DateTime, datDNgay.DateTime));

                if (dt.Rows.Count  == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                if (sPath == "") return;

                Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
                t.Start(dt);

            }
            catch (Exception ex)
            {
            
            }
        }



        private delegate void CallProcessBar(object dt);
        string sPath = "";
        private bool flagLoad;

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
                var ws1 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ucBCThoiGianCVNhanVienTieuDe", Commons.Modules.TypeLanguage));
                pck.SaveAs(fi);

                #region "in Thong Tin Chung"
                Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws1, "C");
                #endregion

                #region "In Thong Tin Sheet 1"
                int iDong = 5;
                ws1.Row(iDong - 1).Height = 9;

                Commons.Modules.MExcel.MText(ws1, this.Name , "ucBCThoiGianCVNhanVienTieuDe", iDong, 1, iDong, dtData.Columns.Count, true, true, 16, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center);
               
                iDong++;

                ws1.SetValue(iDong, 2, lblTNgay.Text + ": " + datTNgay.Text);
                ws1.SetValue(iDong, 4, lblDNgay.Text + ": " + datDNgay.Text);
                ws1.SetValue(iDong + 1, 2, lblDonVi.Text + ": " + cboDonVi.Text);
                ws1.SetValue(iDong + 1, 4, lblPhongBan.Text + ": " + cboPhongBan.Text);
               



                iDong++;
                #endregion

                

                List<List<Object>> WidthColumns = new List<List<Object>>();
                List<Object> WidthColumnsName = new List<Object>();


                iDong++;
                ws1.Row(iDong).Height = 9;
                iDong++;
        
                WidthColumnsName = new List<Object>()
                    {"MS_CONG_NHAN",20};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TEN_CONG_NHAN",30};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"PBT" ,20};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"GSTT" ,20};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"CVVP" ,20};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TONG_CONG",20};
                WidthColumns.Add(WidthColumnsName);

                if (dtData.Rows.Count > 0)
                    ws1.Cells[iDong, 1].LoadFromDataTable(dtData, true);

                Commons.Modules.MExcel.MFormatExcel(ws1, dtData, iDong, this.Name, WidthColumns); //FORMAT
                //    #endregion


                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);


                System.Diagnostics.Process.Start(fi.FullName);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "XuatExcelKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                BeginInvoke((Action)(() =>
                {
                    this.Cursor = Cursors.Default;
                    btnExecute.Enabled = true;
                    btnThoat.Enabled = true;
                    prbIN.Properties.Stopped = true;
                }));
                sPath = "";
            }
            catch { }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            (ParentForm).Close();
        }

        private void ucBCThoiGianCVNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                datTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                datDNgay.DateTime = datTNgay.DateTime.AddMonths(1).AddDays(-1);

                flagLoad = true;
                LoadcboDON_VI1();
                LoadcboTO();
                flagLoad = false;
            }
            catch
            {

            }
        }
    

        private void cboDonVi_EditValueChanged(object sender, EventArgs e)
        {
            if (flagLoad == true) return;
            LoadcboTO();
        }
    }
}
