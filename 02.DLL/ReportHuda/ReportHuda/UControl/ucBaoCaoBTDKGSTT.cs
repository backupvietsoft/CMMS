using System;
using System.Drawing;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraPrinting;

namespace ReportHuda
{
    public partial class ucBaoCaoBTDKGSTT : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoBTDKGSTT()
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
            loadGrData();
        }
        private void ucBaoCaoBTDKGSTT_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            datTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datDNgay.DateTime = datTNgay.DateTime.Date.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadNhomMay("-1");
            Commons.Modules.SQLString = "";
            loadGrData();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }
        private void loadGrData()
        {
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;
                if (Commons.Modules.SQLString == "0LM") return;

                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetGSTTBTDK", datTNgay.DateTime.Date, datDNgay.DateTime.Date, cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboNMay.EditValue, -1, optLoaiIn.SelectedIndex - 1, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dt, false, false, true, true, true, this.Name);
            }
            catch (Exception ex)
            {
            }
        }
        private void optLoaiIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGrData();
        }
        private void cboDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            loadGrData();
        }
        private void InReportGSTT()
        {
            try
            {
                printableComponentLink1.Margins.Left = 50;
                printableComponentLink1.Margins.Right = 50;
                //printableComponentLink1.Margins.Top = 60;
                //printableComponentLink1.Margins.Bottom = 40;
                printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4;
                printableComponentLink1.Landscape = true;
                printableComponentLink1.Margins.Clone();
                PageFooterArea footer = new PageFooterArea();
                footer.Content.Add("Printed on " + "[Date Printed]" + " by " + Commons.Modules.UserName);
                footer.LineAlignment = BrickAlignment.Near;
                PageHeaderArea header = new PageHeaderArea();
                printableComponentLink1.CreateMarginalHeaderArea += CreateMarginalHeaderArea;
                printableComponentLink1.PageHeaderFooter = new PageHeaderFooter(header, footer);
                grvData.OptionsPrint.AutoWidth = true;
                printableComponentLink1.Component = grdData;
                printableComponentLink1.CreateDocument();
                printableComponentLink1.ShowRibbonPreview(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            }
            catch (Exception ex)
            {
            }
        }

         private void CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            //string reportHeader = "Categories Report";
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Tahoma", 16, FontStyle.Bold);
            RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 40);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TIEU_DE", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);
            RectangleF rec1 = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 40);
            e.Graph.DrawString(lblDDiem.Text , Color.Black, rec, BorderSide.None);
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            //BeginInvoke((Action)(() =>
            //{
            //    prbIN.Properties.Stopped = false;
            //}));
            //Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
            //t.Start(true);
            InReportGSTT();
        }
        //Thread t = null;
        //private delegate void CallProcessBar(object flag);
        //private void ShowProcessBar(object flag)
        //{
        //    if (prbIN.InvokeRequired)
        //    {
        //        prbIN.Invoke(new CallProcessBar(ShowProcessBar), true);
        //    }
        //    else
        //    {
        //        BeginInvoke((Action)(() =>
        //        {
        //            prbIN.Properties.Stopped = false;
        //            this.Cursor = Cursors.WaitCursor;

        //        }));
        //        t = new Thread(new ThreadStart(InReportGSTT));
        //        t.Start();

        //    }
        //}
    }
}
