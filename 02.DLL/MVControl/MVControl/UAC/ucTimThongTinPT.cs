using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using DevExpress.XtraEditors;
using Spire.Xls;

namespace MVControl
{
    public partial class ucTimThongTinPT : UserControl
    {
        public ucTimThongTinPT()
        {
            InitializeComponent();
        }

        private void ucTimThongTinPT_Load(object sender, EventArgs e)
        {

            try
            {
                BindData();
            }
            catch (Exception ex)
            {
            }
        }


        public void BindData()
        {
            DataTable objDataTable = new DataTable();

            objDataTable.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongTinVatTu", 0, "", 0, Commons.Modules.UserName, "", ""));
            objDataTable.Columns["TEN_PT"].ReadOnly = false;
            objDataTable.Columns["QUY_CACH"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grd, grv, objDataTable, false, false, false, false, true, this.Name);

            if (grv.Columns["MS_KHO"].Visible == false)
                return;
            grv.Columns["MS_KHO"].Visible = false;
            grv.Columns["ID"].Visible = false;
            grv.Columns["MS_VI_TRI"].Visible = false;
            try
            {
                grv.Columns["TEN_KHO"].Width = 100;
                grv.Columns["QUY_CACH"].Width = 150;
                grv.Columns["TEN_LOAI_VT"].Width = 100;
                grv.Columns["MS_PT"].Width = 85;
                grv.Columns["TEN_PT"].Width = 250;
                grv.Columns["TEN_VI_TRI"].Width = 90;
                grv.Columns["MS_DH_NHAP_PT"].Width = 95;
                grv.Columns["SL_VT"].Width = 80;
                grv.Columns["MS_PT_NCC"].Width = 85;
                grv.Columns["MS_PT_CTY"].Width = 85;
                grv.Columns["BAO_HANH_DEN_NGAY"].Width = 90;
                grv.Columns["NGAY"].Width = 90;
                this.grv.Columns["BAO_HANH_DEN_NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";
                this.grv.Columns["BAO_HANH_DEN_NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                this.grv.Columns["BAO_HANH_DEN_NGAY"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                this.grv.Columns["NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";
                this.grv.Columns["NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                this.grv.Columns["DON_GIA"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
                this.grv.Columns["DON_GIA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                this.grv.Columns["DON_GIA"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }
            catch (Exception ex)
            {
            }
        }

        private void BtnThoat_Click(System.Object sender, System.EventArgs e)
        {
            (ParentForm).Close();
        }

        private void txtPT_TextChanged(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = (DataTable)grd.DataSource;
                dtTmp.DefaultView.RowFilter = "MS_PT like '%" + txtPT.Text.Trim() + "%' OR TEN_PT like '%" + txtPT.Text.Trim() + "%' OR MS_PT_CTY like '%" + txtPT.Text.Trim() + "%' OR MS_PT_NCC like '%" + txtPT.Text.Trim() + "%' OR QUY_CACH like '%" + txtPT.Text.Trim() + "%' OR TEN_VI_TRI like '%" + txtPT.Text.Trim() + "%' OR TEN_LOAI_VT like '%" + txtPT.Text.Trim() + "%'";
            }
            catch (Exception ex)
            {
                dtTmp.DefaultView.RowFilter = "";
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = ((DataTable)(grd.DataSource)).Copy();
                try
                {
                    dtTmp.Rows.Clear();
                }
                catch { }

                GetFilteredData(grv, ref dtTmp);

                sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                if (sPath == "") return;

                Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
                t.Start(dtTmp);

            }
            catch (Exception ex)
            {
                dtTmp.DefaultView.RowFilter = "";
            }
        }

        private delegate void CallProcessBar(object dt);
        string sPath = "";

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
                    //EnableControl(false);
                    btnIn.Enabled = false;
                    BtnThoat.Enabled = false;
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
                try
                {
                    dtData.Columns.Remove("MS_VI_TRI");
                    dtData.Columns.Remove("ID");
                    dtData.Columns.Remove("MS_KHO");
                }
                catch { }
                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }

                ExcelPackage pck = new ExcelPackage();
                var ws1 = pck.Workbook.Worksheets.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTimThongTinPT", "ucTimThongTinPTTieuDe", Commons.Modules.TypeLanguage));
                pck.SaveAs(fi);

                #region "in Thong Tin Chung"
                Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws1, "C");
                #endregion

                #region "In Thong Tin Sheet 1"
                int iDong = 5;
                ws1.Row(4).Height = 9;

                var allCells = ws1.Cells[iDong, 1, iDong, dtData.Columns.Count];

                Commons.Modules.MExcel.MText(ws1, "frmTimThongTinPT", "ucTimThongTinPTTieuDe", iDong, 1, iDong, dtData.Columns.Count, true, true, 16, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Center); 

                iDong++;
                #endregion

                List<string> sCotNgay = new List<string>() { };
                List<List<Object>> WidthColumns = new List<List<Object>>();
                List<Object> WidthColumnsName = new List<Object>();


                iDong++;
                ws1.Row(iDong).Height = 9;
                iDong++;
                sCotNgay = new List<string>() 
                    {
                            "NGAY"
                    };
                
             
                WidthColumnsName = new List<Object>()
                    {"QUY_CACH",25};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TEN_PT",26};
                WidthColumns.Add(WidthColumnsName);

                WidthColumnsName = new List<Object>()
                    {"MS_PT_NCC",20};
                WidthColumns.Add(WidthColumnsName);
                WidthColumnsName = new List<Object>()
                    {"TEN_LOAI_VT",20};
                WidthColumns.Add(WidthColumnsName);

                if (dtData.Rows.Count > 0)
                    ws1.Cells[iDong, 1].LoadFromDataTable(dtData, true); 

                Commons.Modules.MExcel.MFormatExcel(ws1, dtData, iDong, "frmTimThongTinPT", sCotNgay, "dd/MM/yyyy", WidthColumns); //FORMAT
                //    #endregion


                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);


                System.Diagnostics.Process.Start(fi.FullName);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTimThongTinPT", "XuatExcelKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                BeginInvoke((Action)(() =>
                {
                    this.Cursor = Cursors.Default;
                    btnIn.Enabled = true;
                    BtnThoat.Enabled = true;
                    prbIN.Properties.Stopped = true;
                }));
                sPath = "";
            }
            catch { }
        }

        public void GetFilteredData(DevExpress.XtraGrid.Views.Base.ColumnView view, ref DataTable dt)
        {
            for (int i = 0; i < view.DataRowCount; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < view.Columns.Count; j++)
                    {
                        dr[view.Columns[j].FieldName] = view.GetDataRow(i)[view.Columns[j].FieldName];
                    }
                    dt.Rows.Add(dr);
                }
                catch { }

            }

        }

    }
}
