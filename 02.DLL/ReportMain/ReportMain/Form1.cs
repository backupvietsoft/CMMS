using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using Microsoft.ApplicationBlocks.Data;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace ReportMain
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        //iLoaiIP=1 là import phụ tùng CHO TRUNG NGUYEN
        //iLoaiIP=2 là import PHIEU XUAT CHO TRUNG NGUYEN
        //iLoaiIP=3 là import danh muc thiet bi
        public int iLoaiIP = 1;
        public string sCap1 = "Ten_N_XUONG", sCap2 = "TEN_LOAI_MAY", sCap3 = "TEN_NHOM_MAY";//Ten_N_XUONG,TEN_HE_THONG,TEN_LOAI_MAY,TEN_NHOM_MAY,TEN_BP_CHIU_PHI
        private void grvBC_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            if (this.grvBC.GroupCount > 0)
            {
                GridView view = sender as GridView;
                GridGroupRowInfo info = e.Info as GridGroupRowInfo;
                string caption = info.Column.Caption;
                if (info.Column.Caption == string.Empty)
                    caption = info.Column.ToString();
                info.GroupText = string.Format("{0} : {1} (count= {2})", caption, info.GroupText, view.GetChildRowCount(e.RowHandle));
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        string sBC = "ucDanhMucMayMocThietBi";
        private void Form1_Load(object sender, EventArgs e)
        {
            grvBC.OptionsView.ShowGroupedColumns = true;
            grvBC.OptionsView.ShowGroupPanel = true;
            grvBC.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, string.Empty);
            DataTable dtTmp = new DataTable();

            string sGroup = "";

            sCap1 = "Ten_N_XUONG";
            sCap2 = "TEN_HE_THONG";
            sCap3 = "TEN_LOAI_MAY";//Ten_N_XUONG,TEN_HE_THONG,TEN_LOAI_MAY,TEN_NHOM_MAY,TEN_BP_CHIU_PHI
            sGroup = (sCap1 == "" ? "" : "" + sCap1) + (sCap2 == "" ? "" : "," + sCap2) + (sCap3 == "" ? "" : "," + sCap3);





            //Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
            t.Start(true);

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDanhMucMayMocThietBi",
                        Commons.Modules.UserName, Commons.Modules.TypeLanguage+ 2, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, sGroup));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, false, true, false, true, true, sBC);

            grvBC.Columns["MS_MAY"].Width = 100;
            grvBC.Columns["NGAY_DUA_VAO_SD"].Width = 100;
            grvBC.Columns["AN_TOAN"].Width = 100;
            grvBC.Columns["TEN_UU_TIEN"].Width = 100;
            grvBC.Columns["MS_N_XUONG"].Width = 100;
            grvBC.OptionsCustomization.AllowGroup = true;

            grvBC.ClearGrouping();
            GridColumn col1 = grvBC.Columns[sCap1];
            GridColumn col2 = grvBC.Columns[sCap2];
            GridColumn col3 = grvBC.Columns[sCap3];

            grvBC.BeginSort();
            try
            {
                grvBC.ClearGrouping();
                if (sCap1 != "") col1.GroupIndex = 0;
                if (sCap2 != "") col2.GroupIndex = 1;
                if (sCap3 != "") col3.GroupIndex = 2;
            }
            finally
            {
                grvBC.EndSort();
            }

        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            
        }


        
        private void btnExecute_Click(object sender, EventArgs e)
        {
            //DataTable dtTmp = new DataTable();
            
            //string sGroup = "";
            //sCap1 = "Ten_N_XUONG";
            //sCap2 = "TEN_HE_THONG";
            //sCap3 = "TEN_LOAI_MAY";//Ten_N_XUONG,TEN_HE_THONG,TEN_LOAI_MAY,TEN_NHOM_MAY,TEN_BP_CHIU_PHI
            //sGroup = (sCap1 == "" ? "" : "" + sCap1) + (sCap2 == "" ? "" : "," + sCap2) + (sCap3 == "" ? "" : "," + sCap3);


            //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDanhMucMayMocThietBi",
            //            Commons.Modules.UserName, Commons.Modules.TypeLanguage, -1, -1, -1, sGroup));
            //Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, false, true, false, true, true, sBC);
            //grvBC.Columns["MS_MAY"].Width = 100;
            //grvBC.Columns["NGAY_DUA_VAO_SD"].Width = 100;
            //grvBC.Columns["AN_TOAN"].Width = 100;
            //grvBC.Columns["TEN_UU_TIEN"].Width = 100;
            //grvBC.Columns["MS_N_XUONG"].Width = 100;
            try
            {
                InReport();
            }
            catch { }
        }



        void composLink_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 18, FontStyle.Bold);
            
            RectangleF rec = new RectangleF(150, 5, e.Graph.ClientPageSize.Width - 200, 60);

            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TieuDe", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);


            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 14, FontStyle.Italic);
            RectangleF rec2 = new RectangleF(150, 35, e.Graph.ClientPageSize.Width - 200, 90);
            e.Graph.DrawString("dddgggdd \n sssgggsssss \n sadasdsadsggga", Color.Black, rec2, BorderSide.None);

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, " SELECT LOGO FROM THONG_TIN_CHUNG"));
            Byte[] data = new Byte[0];
            data = (Byte[])(dtTmp.Rows[0][0]);
            RectangleF rec1 = new RectangleF(1, 5, 150, 50);
            MemoryStream mem = new MemoryStream(data);
            e.Graph.DrawImage(Image.FromStream(mem), rec1);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        void linkGrid2Report_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {


            TextBrick tb = new TextBrick();
            tb.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TieuDe", Commons.Modules.TypeLanguage);
            tb.Font = new Font("Calibri", 18, FontStyle.Bold);
            tb.Rect = new RectangleF(0, 10, e.Graph.ClientPageSize.Width, 40);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);







        }
        
        private void InReport()
        {
            try
            {
                CompositeLink composLink = new CompositeLink(new PrintingSystem());
                composLink.Margins.Left = 30;
                composLink.Margins.Right = 30;
                composLink.Margins.Top = 145;

                
                composLink.PaperKind = System.Drawing.Printing.PaperKind.A2;
                composLink.Landscape = true;               

                composLink.Margins.Clone();
                composLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(composLink_CreateMarginalHeaderArea);//tieu de + logo               
                printableComponentLink1.Component = this.grdBC;              
                
                composLink.Links.Add(printableComponentLink1);


                //composLink.ShowRibbonPreview(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                composLink.ShowPreviewDialog(Owner, DevExpress.LookAndFeel.UserLookAndFeel.Default);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        



    }
}
