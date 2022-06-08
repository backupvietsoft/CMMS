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
using DevExpress.XtraEditors;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting;
using DevExpress.XtraTreeList.ViewInfo;
//Commons.Hyperlink.ToPhieuBaoTri(Me, grv.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString())

namespace MVControl
{
    public partial class ucBaoCaoChiPhi : DevExpress.XtraEditors.XtraUserControl
    {
        String sBC = "ucTongHopTinhHinhBaoTri";
        public ucBaoCaoChiPhi()
        {
            InitializeComponent();
        }

        private void ucBaoCaoChiPhi_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            datTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datDNgay.DateTime = datTNgay.DateTime.Date.AddMonths(1).AddDays(-1);
            Commons.Modules.SQLString = "";
            TaoLuoiChiPhi();
            CreateMenuPBT(tvwChiPhi);
            tvwChiPhi.Columns["TEN"].Width = 250;
        }

        private void TaoLuoiChiPhi()
        {
            
            if (Commons.Modules.SQLString == "0Load") return;

            bool bLoad = true;
            try{ if (tvwChiPhi.Columns.Count > 0) bLoad = false; else bLoad = true; }catch { bLoad = true; }
            this.Cursor = Cursors.WaitCursor;

            try
            {
                tvwChiPhi.DataSource = null;
                DataTable dtTmp = new DataTable();
                tvwChiPhi.BeginUpdate();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCChiPhiTong", datTNgay.DateTime.Date, datDNgay.DateTime.Date, Commons.Modules.UserName));
                //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCChiPhiTong", "01/01/2019", "12/01/2019", Commons.Modules.UserName));
                tvwChiPhi.KeyFieldName = "MA_SO";
                tvwChiPhi.ParentFieldName = "MS_CHA";
                tvwChiPhi.OptionsBehavior.Editable = false;
                tvwChiPhi.DataSource = dtTmp;
                if (bLoad) tvwChiPhi.PopulateColumns();
                if (bLoad) tvwChiPhi.Columns["LOAI"].Visible = false;
                tvwChiPhi.EndUpdate();

                if (tvwChiPhi.Columns["TEN"].Width < 130)
                {
                    //Calculate the optimal column widths after the treelist is shown. 
                    tvwChiPhi.BestFitColumns();
                    this.BeginInvoke(new MethodInvoker(delegate
                     {

                         //tvwChiPhi.Columns["TEN"].Width = tvwChiPhi.Columns["TEN"].Width + 20;
                         Commons.Modules.ObjSystems.MLoadNNXtraTreeList(tvwChiPhi, sBC);
                     }
                    ));


                    tvwChiPhi.OptionsView.AutoWidth = true;
                    tvwChiPhi.ExpandAll();
                    
                }
                Check();

                for (int i = 1; i <= tvwChiPhi.Columns.Count - 1; i++)
                {
                    string sSoLe = "N2";
                    try
                    { sSoLe = "N" + txtNum.Text; }
                    catch
                    { sSoLe = "N2"; }
                    tvwChiPhi.Columns[i].Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                    tvwChiPhi.Columns[i].Format.FormatString = sSoLe;
                    tvwChiPhi.Columns[i].Width = 80;
                }
                


                ////Format column headers and cell values. 
                //colMarchSalesPrev.Caption = "<i>Previous <b>March</b> Sales</i>";
                //colSeptemberSalesPrev.Caption = "<i>Previous <b>September</b> Sales</i>";
                //treeList1.OptionsView.AllowHtmlDrawHeaders = true;
                //colMarchSalesPrev.AppearanceCell.Font = new System.Drawing.Font(colMarchSalesPrev.AppearanceCell.Font, System.Drawing.FontStyle.Italic);
                //colSeptemberSalesPrev.AppearanceCell.Font = new System.Drawing.Font(colSeptemberSalesPrev.AppearanceCell.Font, System.Drawing.FontStyle.Italic);




                //////Locate a node by a value it contains. 
                //DevExpress.XtraTreeList.Nodes.TreeListNode node1 = tvwChiPhi.FindNodeByFieldValue("TEN", "WO-201901000367");
                ////Focus and expand this node. 
                //tvwChiPhi.FocusedNode = node1;
                //node1.Expanded = true;

                ////Locate a node by its key field value and expand it. 
                //TreeListNode node2 = treeList1.FindNodeByKeyID(32);//Node 'Asia' 
                //node2.Expand();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }

        private void Check()
        {
            if (chkShowSummaryFooter.Checked) tvwChiPhi.OptionsView.ShowSummaryFooter = true; else tvwChiPhi.OptionsView.ShowSummaryFooter = false;
            if (chkShowRowFooterSummary.Checked) tvwChiPhi.OptionsView.ShowRowFooterSummary = true; else tvwChiPhi.OptionsView.ShowRowFooterSummary = false;
            if (chkExpandAll.Checked) tvwChiPhi.ExpandAll(); else tvwChiPhi.CollapseAll();

            tvwChiPhi.OptionsView.AutoWidth = !chkAutoWidth.Checked;
        }
        private void chkShowSummaryFooter_CheckedChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void chkShowRowFooterSummary_CheckedChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void chkExpandAll_CheckedChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                printableComponentLink1.Margins.Left = 50;
                printableComponentLink1.Margins.Right = 50;
                printableComponentLink1.Margins.Top = 60;
                printableComponentLink1.Margins.Bottom = 40;
                printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3;
                printableComponentLink1.Landscape = true;
                
                PageFooterArea footer = new PageFooterArea();
                footer.Content.Add("Printed on " + "[Date Printed]" + " by " + Commons.Modules.UserName);
                footer.LineAlignment = BrickAlignment.Near;

                PageHeaderArea header = new PageHeaderArea();
                printableComponentLink1.CreateMarginalHeaderArea += CreateMarginalHeaderArea;
                printableComponentLink1.PageHeaderFooter = new PageHeaderFooter(header, footer);
                tvwChiPhi.OptionsPrint.AutoWidth = true;
                //tvwChiPhi.OptionsPrint.ex
                printableComponentLink1.CreateDocument();
                printableComponentLink1.ShowRibbonPreview(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }

        }
        private void CreateMarginalHeaderArea(object sender,CreateAreaEventArgs e)
        {
            string reportHeader = "Categories Report";
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Tahoma", 16, FontStyle.Bold);
            RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sBC" + sBC, Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);
        }

        public void CreateReport()
        {
            var link = new PrintableComponentLink(new PrintingSystem());
            link.Margins.Left = 50;
            link.Margins.Right = 50;
            link.Margins.Top = 50;
            link.Margins.Bottom = 40;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;


            link.Component = tvwChiPhi;
            link.Landscape = true;


            PageFooterArea footer = new PageFooterArea();
            footer.Content.Add("Printed on " + "[Date Printed]" + " by " + Commons.Modules.UserName);
            footer.LineAlignment = BrickAlignment.Near;
            PageHeaderArea header = new PageHeaderArea();
            link.CreateMarginalHeaderArea += CreateMarginalHeaderArea;
            link.PageHeaderFooter = new PageHeaderFooter(header, footer);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Save, CommandVisibility.None);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.FillBackground, CommandVisibility.None);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.HandTool, CommandVisibility.None);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Open, CommandVisibility.None);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Customize, CommandVisibility.None);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Scale, CommandVisibility.None);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Parameters, CommandVisibility.None);
            //link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SubmitParameters, CommandVisibility.None);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.None, CommandVisibility.None);
            link.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.DocumentMap, CommandVisibility.None);




            //link.PrintingSystem.PreviewRibbonFormEx.RibbonControl.Pages["Print Preview"].Groups["Document"].Visible = false;
            //link.PrintingSystem.PreviewRibbonFormEx.RibbonControl.Pages["Print Preview"].Groups["Background"].Visible = false;
            //link.PrintingSystem.PreviewRibbonFormEx.RibbonControl.Pages["Print Preview"].Groups["Zoom"].Visible = false;
            link.CreateDocument();
            link.PrintingSystem.Document.AutoFitToPagesWidth = 1;
            //link.ShowRibbonPreview(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            link.ShowPreviewDialog();
        }

        // Create the Marginal Header section.  
        private void printableComponentLink1_CreateMarginalHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            //// Specify font and color settings for the brick graphics.  
            //e.Graph.Font = e.Graph.DefaultFont;
            //e.Graph.BackColor = Color.Transparent;


            //// Set the rectangle for a page info brick.  
            //RectangleF r = new RectangleF(0, 0, 0, e.Graph.Font.Height);

            //// Draw a page info brick, which displays page numbers.  
            //PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black,
            //    r, BorderSide.None);

            //// Set a brick's alignment.  
            //brick.Alignment = BrickAlignment.Near;

            //// Enable the auto width option for a brick.  
            //brick.AutoWidth = true;

            //// Draw a page info brick, which displays current date and time.  
            //brick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black, r, BorderSide.None);

            //// Set a brick's alignment.  
            //brick.Alignment = BrickAlignment.Center;

            //// Enable the auto width option for a brick.  
            //brick.AutoWidth = true;
        }

        private void printableComponentLink1_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            // Specify font and color settings for the brick graphics.  
            e.Graph.Font = e.Graph.DefaultFont;
            e.Graph.BackColor = Color.Transparent;

            // Set the format string for a page info brick.  
            string format = "Page {0} of {1}";

            // Set the rectangle for a page info brick.  
            RectangleF r = new RectangleF(0, 0, 0, e.Graph.Font.Height);

            // Draw a page info brick, which displays page numbers.  
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black,
                r, BorderSide.None);

            // Set brick alignment.  
            brick.Alignment = BrickAlignment.Far;

            // Enable the auto width option for a brick.  
            brick.AutoWidth = true;


        }

        ////////////private void datTNgay_EditValueChanged(object sender, EventArgs e)
        ////////////{
        ////////////    if (Commons.Modules.SQLString == "0Load") return;
        ////////////    if (datTNgay.DateTime > datDNgay.DateTime)
        ////////////    {
        ////////////        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgTuNgayLonHonDenNgay", Commons.Modules.TypeLanguage), "");
        ////////////        return;
        ////////////    }
        ////////////    TaoLuoiChiPhi();
        ////////////}

        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                DevExpress.XtraBars.BarManager barMenu = sender as DevExpress.XtraBars.BarManager;

                DevExpress.XtraTreeList.TreeList tvw = this.Controls.Find(barMenu.Form.Name, true).FirstOrDefault() as DevExpress.XtraTreeList.TreeList;
                XtraForm frmMain = new XtraForm();
                string sMsPh="";
                try
                {
                    sMsPh = tvwChiPhi.FocusedNode[0].ToString();
                }catch { sMsPh = ""; }
                if (sMsPh == "") return;
                switch (e.Item.Name)
                {
                    case "mnuPhieuBaoTri":
                        
                        if (sMsPh.Substring(0, 3).ToUpper() == "WO-")
                            Commons.Hyperlink.ToPhieuBaoTri(frmMain, tvwChiPhi.FocusedNode[0].ToString());
                        break;
                    case "mnuMay":
                        if (sMsPh.Substring(0, 3).ToUpper() != "WO-")
                            Commons.Hyperlink.ToMay(frmMain, tvwChiPhi.FocusedNode[0].ToString());
                        break;
                }


            }catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void CreateMenuPBT(DevExpress.XtraTreeList.TreeList tvw)
        {
            try
            {
                foreach (var conTrol in tvw.Controls)
                {
                    if (conTrol is DevExpress.XtraBars.BarDockControl)
                        return;
                }
            }
            catch 
            {}

            DevExpress.XtraBars.BarManager BarManager = new DevExpress.XtraBars.BarManager();
            BarManager.Form = tvw;
            BarManager.ItemClick += barManager_ItemClick;
            BarManager.BeginUpdate();

            DevExpress.XtraBars.PopupMenu popup = new DevExpress.XtraBars.PopupMenu(BarManager);
            popup.BeforePopup += PopupMenu_BeforePopup;
            popup.BeginUpdate();

            BarManager.SetPopupContextMenu(tvw, popup);

            string sStr;
            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkPhieuBaoTri", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuPhieuBaoTri = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuPhieuBaoTri.Name = "mnuPhieuBaoTri";

            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkMay", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuCongViec = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuCongViec.Name = "mnuMay";


            popup.AddItems(new DevExpress.XtraBars.BarItem[] { mnuCongViec, mnuPhieuBaoTri });
            BarManager.EndUpdate();
        }
        private void PopupMenu_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                DevExpress.XtraBars.PopupMenu popupMenu = sender as DevExpress.XtraBars.PopupMenu;

                DevExpress.XtraTreeList.TreeList tvw = this.Controls.Find(popupMenu.Manager.Form.Name, true).FirstOrDefault() as DevExpress.XtraTreeList.TreeList;

                Point p = tvw.PointToClient(Control.MousePosition);
                //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = grv.CalcHitInfo(p);
                DevExpress.XtraTreeList.ViewInfo.TreeListViewInfo hitInfo = tvw.ViewInfo; //tvw.CalcHitInfo(p);
                RowInfo rowInfo = hitInfo.GetRowInfoByPoint(p);
                //if (hitInfo.InColumnPanel)
                //    e.Cancel = true;
                if (rowInfo == null)
                    e.Cancel = true;
                //TreeList tree = sender as TreeList;
                //TreeListViewInfo viewInfo = tree.ViewInfo;
                //RowInfo rowInfo = viewInfo.GetRowInfoByPoint(e.Location);
                //if (rowInfo != null)
                //{
                //    //show a menu  
                //}

            }
            catch (Exception ex)
            {
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        ////////////private void datTNgay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        ////////////{
        ////////////    if (Commons.Modules.SQLString == "0Load") return;
        ////////////    try
        ////////////    {
        ////////////        if ((DateTime)e.NewValue > datDNgay.DateTime)
        ////////////        {
        ////////////            Commons.Modules.SQLString = "0Load";
        ////////////            datTNgay.DateTime = (DateTime)e.OldValue;
        ////////////            Commons.Modules.SQLString = "";
        ////////////            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgTuNgayLonHonDenNgay", Commons.Modules.TypeLanguage), "");
        ////////////            e.Cancel = true;
        ////////////            return;
        ////////////        }
        ////////////    }
        ////////////    catch { }
        ////////////}

        ////////////private void datDNgay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        ////////////{
        ////////////    if (Commons.Modules.SQLString == "0Load") return;
        ////////////    try
        ////////////    {
        ////////////        if (datTNgay.DateTime > (DateTime)e.NewValue )
        ////////////        {
        ////////////            Commons.Modules.SQLString = "0Load";
        ////////////            datDNgay.DateTime = (DateTime)e.OldValue;
        ////////////            Commons.Modules.SQLString = "";
        ////////////            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgTuNgayLonHonDenNgay", Commons.Modules.TypeLanguage), "");
        ////////////            e.Cancel = true;
        ////////////            return;
        ////////////        }
        ////////////    }
        ////////////    catch { }
        ////////////}

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (datTNgay.DateTime > datDNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgTuNgayLonHonDenNgay", Commons.Modules.TypeLanguage), "");
                return;
            }
            TaoLuoiChiPhi();
        }
        private List<string> arrTim = new List<string>();

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
        //    Try
        //    If(e.KeyCode <> 13) Then Exit Sub
        //    Commons.Modules.ObjSystems.HTimXtraTreeList(txtTimThietBi.Text, tvwCTTBi, "MS_BO_PHAN", "TEN_BO_PHAN", arrTim)
        //Catch ex As Exception
        //End Try
            try
            {
                if (e.KeyCode != Keys.Enter) return;
                Commons.Modules.ObjSystems.HTimXtraTreeList(txtFind.Text, tvwChiPhi, "MA_SO", "TEN", ref arrTim);



            }
            catch { }
        }
    }
}
