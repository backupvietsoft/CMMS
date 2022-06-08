using DevExpress.XtraPrinting;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmBaoCaoChiPhi : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoCaoChiPhi()
        {
            InitializeComponent();
        }

        private void frmBaoCaoChiPhi_Load(object sender, EventArgs e)
        {
            TaoLuoiChiPhi();
        }


        private void TaoLuoiChiPhi()
        {

            bool bLoad = true;
            try { if (tvwChiPhi.Columns.Count > 0) bLoad = false; else bLoad = true; } catch { bLoad = true; }
            this.Cursor = Cursors.WaitCursor;

            try
            {
                tvwChiPhi.DataSource = null;
                DataTable dtTmp = new DataTable();
                tvwChiPhi.BeginUpdate();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCChiPhiTong", "01/01/2019", "08/01/2019", Commons.Modules.UserName));
                tvwChiPhi.KeyFieldName = "MA_SO";
                tvwChiPhi.ParentFieldName = "MS_CHA";
                tvwChiPhi.OptionsBehavior.Editable = false;
                tvwChiPhi.DataSource = dtTmp;
                if (bLoad) tvwChiPhi.PopulateColumns();
                if (bLoad) tvwChiPhi.Columns["LOAI"].Visible = false;
                tvwChiPhi.EndUpdate();

                if (bLoad)
                {
                    tvwChiPhi.BestFitColumns(true);
                    for (int i = 1; i <= tvwChiPhi.Columns.Count - 1; i++)
                    {

                        tvwChiPhi.Columns[i].Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                        tvwChiPhi.Columns[i].Format.FormatString = "N2";
                        tvwChiPhi.Columns[i].Width = 90;
                    }
                    tvwChiPhi.ExpandAll();
                    tvwChiPhi.OptionsView.ShowRowFooterSummary = true;
                    tvwChiPhi.OptionsView.ShowSummaryFooter = true;
                    //Commons.Modules.ObjSystems.MLoadNNXtraTreeList(tvwChiPhi, /*sBC*/);
                }



                ////Format column headers and cell values. 
                //colMarchSalesPrev.Caption = "<i>Previous <b>March</b> Sales</i>";
                //colSeptemberSalesPrev.Caption = "<i>Previous <b>September</b> Sales</i>";
                //treeList1.OptionsView.AllowHtmlDrawHeaders = true;
                //colMarchSalesPrev.AppearanceCell.Font = new System.Drawing.Font(colMarchSalesPrev.AppearanceCell.Font, System.Drawing.FontStyle.Italic);
                //colSeptemberSalesPrev.AppearanceCell.Font = new System.Drawing.Font(colSeptemberSalesPrev.AppearanceCell.Font, System.Drawing.FontStyle.Italic);


                grdMay.DataSource = dtTmp;

                ////Locate a node by a value it contains. 
                //TreeListNode node1 = treeList1.FindNodeByFieldValue("Region", "North America");
                ////Focus and expand this node. 
                //treeList1.FocusedNode = node1;
                //node1.Expanded = true;

                ////Locate a node by its key field value and expand it. 
                //TreeListNode node2 = treeList1.FindNodeByKeyID(32);//Node 'Asia' 
                //node2.Expand();

                ////Calculate the optimal column widths after the treelist is shown. 
                //this.BeginInvoke(new MethodInvoker(delegate {
                //    treeList1.BestFitColumns();
                //}));
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }



        PrintingSystem printingSystem1 = new PrintingSystem();
        PrintableComponentLink printableComponentLink1 = new PrintableComponentLink();
        private void button1_Click(object sender, EventArgs e)
        {

            printingSystem1.Links.AddRange(new object[] { printableComponentLink1 });

            // Clear the document created by the GridControl's view.


           


            // Assign a control to be printed by this link.
            printableComponentLink1.Component = grdMay;

            // Set the paper orientation to Landscape.
            printableComponentLink1.Landscape = true;

            //printableComponentLink1.PrintingSystem.Document.AutoFitToPagesWidth = 0;


            printableComponentLink1.CreateDocument();

            //printableComponentLink1.PrintingSystem.Document.AutoFitToPagesWidth = 0;

            printableComponentLink1.ShowPreview();
            //printableComponentLink1.PrintingSystem.Document.ScaleFactor = 0;
            //printableComponentLink1.PrintingSystem.Document.AutoFitToPagesWidth = 0;



        }

        private void tvwChiPhi_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            //Color color = tvwChiPhi.GetVisibleIndexByNode(e.Node) % 2 == 0 ? Color.IndianRed : Color.Indigo;
            Color color = Color.Indigo;
            e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);
        }

        private void tvwChiPhi_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            //if (e.Column.FieldName.ToString().ToUpper() != "LOAI") return;

            //e.Appearance.ForeColor = int.Parse(e.Node["LOAI"].ToString()) == 1 ? Color.IndianRed : Color.Indigo;
        }

        private void tvwChiPhi_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            //if (e.Column.FieldName.ToString().ToUpper() != "LOAI") return;


            //cấp nhà máy
            //if (int.Parse(e.Node["LOAI"].ToString()) == 0) e.Appearance.ForeColor = Color.Blue;
            //nha xuong
            if (int.Parse(e.Node["LOAI"].ToString()) == 1) e.Appearance.ForeColor = Color.Blue;

            //loai may
            if (int.Parse(e.Node["LOAI"].ToString()) == 2) e.Appearance.ForeColor = Color.Maroon;

            //if (e.Column.FieldName.ToString().ToUpper() != "LOAI") return;
            //try
            //{
            //    e.Appearance.ForeColor = int.Parse(e.Node["LOAI"].ToString ()) == 2 ? Color.IndianRed : Color.Indigo;
            //}
            //catch { }
            //e.Appearance.BackColor = tvwChiPhi.GetNodeDisplayValue (e.Node) % 2 == 0 ? Color.IndianRed : Color.Indigo;
            //e.Appearance.BackColor = tvwChiPhi.GetNodeDisplayValue(e.Node) % 2 == 0 ? Color.IndianRed : Color.Indigo;
            // tvwChiPhi.Nodes(0)("MS_MAY").ToString().Trim().ToLower() 
        }
    }
}
