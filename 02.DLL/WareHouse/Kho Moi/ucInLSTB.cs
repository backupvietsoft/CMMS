using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraPrinting;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using DevExpress.XtraEditors;

namespace WareHouse
{
    public partial class ucInLSTB : DevExpress.XtraEditors.XtraUserControl
    {
        string sBC = "frmThongtinthietbi";
        static DateTime TNgay, DNgay;
        static string sMsMay;
        static string sTenMay;
        static DataTable dtLuoi;
        public ucInLSTB( DateTime _TNgay, DateTime _DNgay,string _sMsMay, string _sTenMay, DataTable _dtLuoi)
        {
            InitializeComponent();

            TNgay = _TNgay;
            DNgay = _DNgay;
            sMsMay = _sMsMay;
            sTenMay = _sTenMay;
            dtLuoi = _dtLuoi;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtLuoi, false, true, true, true, true, sBC);
            try
            {
                grvChung.Columns["NGAY_BD_KH"].Width = 100;
                grvChung.Columns["MS_PHIEU_BAO_TRI"].Width = 120;
                grvChung.Columns["TEN_LOAI_BT"].Width = 230;
                grvChung.Columns["NVBT"].Width = 320;
                grvChung.Columns["TEN_TINH_TRANG"].Width = 140;
                grvChung.Columns["GHI_CHU"].Width = 120;
                
            }
            catch { }

        }
        public void InReport()
        {
            try
            {
                CompositeLink composLink = new CompositeLink(new PrintingSystem());
                composLink.Margins.Left = 60;
                composLink.Margins.Right = 60;
                composLink.Margins.Top = 50;
                composLink.Margins.Bottom = 50;

                composLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
                composLink.Landscape = true;

                string leftColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sTrang", Commons.Modules.TypeLanguage) + "[Page # of Pages #]";
                string middleColumn = "User: " + Commons.Modules.UserName;
                string rightColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sNgayIn", Commons.Modules.TypeLanguage) + "[Date Printed]";

                // Create a PageHeaderFooter object and initializing it with
                // the link's PageHeaderFooter.
                PageHeaderFooter phf = composLink.PageHeaderFooter as PageHeaderFooter;
                // Clear the PageHeaderFooter's contents.
                phf.Footer.Content.Clear();
                // Add custom information to the link's header.
                phf.Footer.Content.AddRange(new string[] { middleColumn, "", leftColumn });
                phf.Footer.LineAlignment = BrickAlignment.Far;



                // Create a PageHeaderFooter object and initializing it with
                // the link's PageHeaderFooter.
                PageHeaderFooter ph = composLink.PageHeaderFooter as PageHeaderFooter;
                // Clear the PageHeaderFooter's contents.
                ph.Header.Content.Clear();
                // Add custom information to the link's header.
                ph.Header.Content.AddRange(new string[] { "", "", rightColumn });
                ph.Header.LineAlignment = BrickAlignment.Far;



                composLink.Margins.Clone();
                composLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(composLink_CreateMarginalHeaderArea);//Ngay IN               
                composLink.CreateReportHeaderArea += new CreateAreaEventHandler(composLink_CreateReportHeaderArea);//tieu de + logo           


                printableComponentLink1.Component = this.grdChung;
                composLink.Links.Add(printableComponentLink1);
                composLink.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        public void composLink_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {

        }

        private void ucInLSTB_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //            CONVERT(DATE, NGAY_BD_KH) AS , T1., T2., 
            // dbo.MGetListAllCNhanPBT(MS_PHIEU_BAO_TRI) AS ,
            //T3., T1.
            try
            {
                InReport();
            }
            catch { }
        }

        public void composLink_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, System.Data.CommandType.Text, " SELECT LOGO FROM THONG_TIN_CHUNG"));
            Byte[] data = new Byte[0];
            data = (Byte[])(dtTmp.Rows[0][0]);
            RectangleF rec1 = new RectangleF(1, 5, 150, 50);
            MemoryStream mem = new MemoryStream(data);
            e.Graph.DrawImage(Image.FromStream(mem), rec1, BorderSide.None, Color.Transparent);
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 18, FontStyle.Bold);

            RectangleF rec = new RectangleF(200, 5, e.Graph.ClientPageSize.Width - 600, 30);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sTDLSTB", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 14, FontStyle.Bold);
            //
            RectangleF rec2 = new RectangleF(200, 40, 300, 25);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "lblTNgay", Commons.Modules.TypeLanguage) + " : " + TNgay.ToShortDateString(), Color.Black, rec2, BorderSide.None);

            RectangleF rec21 = new RectangleF(500, 40, 300, 25);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "lblDNgay", Commons.Modules.TypeLanguage) + " : " + DNgay.ToShortDateString(), Color.Black, rec21, BorderSide.None);


            RectangleF rec3 = new RectangleF(200, 65, 300, 25);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "lblMsMay", Commons.Modules.TypeLanguage) + " : " + sMsMay , Color.Black, rec3, BorderSide.None);

            RectangleF rec31 = new RectangleF(500, 65, 500, 25);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "lblTenMay", Commons.Modules.TypeLanguage) + " : " + sTenMay, Color.Black, rec31, BorderSide.None);



            RectangleF rec5 = new RectangleF(300, 110, 500, 10);
            e.Graph.DrawString("", Color.Transparent, rec5, BorderSide.None);


        }
        //public void composLink_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        //{
        //    DataTable dtTmp = new DataTable();
        //    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, " SELECT LOGO FROM THONG_TIN_CHUNG"));
        //    Byte[] data = new Byte[0];
        //    data = (Byte[])(dtTmp.Rows[0][0]);
        //    RectangleF rec1 = new RectangleF(1, 5, 150, 70);
        //    MemoryStream mem = new MemoryStream(data);
        //    e.Graph.DrawImage(Image.FromStream(mem), rec1, BorderSide.None, Color.Transparent);



        //    e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
        //    e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 18, FontStyle.Bold);

        //    RectangleF rec = new RectangleF(200, 5, e.Graph.ClientPageSize.Width - 600, 25);
        //    e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TieuDe", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);

        //    string sTmp = "";

        //    e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
        //    e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 14, FontStyle.Bold);
        //    ////
        //    //RectangleF rec2 = new RectangleF(300, 40, 500, 25);
        //    //e.Graph.DrawString("Từ ngày" + " : " + TNgay.ToShortDateString(), Color.Black, rec2, BorderSide.None);

        //    //RectangleF rec21 = new RectangleF(800, 40, 500, 25);
        //    //e.Graph.DrawString("Đến ngày" + " : " + DNgay.ToShortDateString(), Color.Black, rec21, BorderSide.None);

        //    //RectangleF rec22 = new RectangleF(1300, 40, 500, 25);
        //    //e.Graph.DrawString(lblBPCP.Text + " : " + cboBPCP.Text, Color.Black, rec22, BorderSide.None);


        //    ////
        //    //RectangleF rec3 = new RectangleF(300, 65, 500, 25);
        //    //e.Graph.DrawString(lblLMay.Text + " : " + cboLMay.Text, Color.Black, rec3, BorderSide.None);

        //    //RectangleF rec31 = new RectangleF(800, 65, 500, 25);
        //    //e.Graph.DrawString(lblNMay.Text + " : " + cboNMay.Text, Color.Black, rec31, BorderSide.None);

        //    //RectangleF rec32 = new RectangleF(1300, 65, 500, 25);
        //    //e.Graph.DrawString(lblHienTrangSD.Text + " : " + cboHienTrangSD.Text, Color.Black, rec32, BorderSide.None);



        //    ////
        //    //RectangleF rec4 = new RectangleF(300, 90, 500, 25);
        //    //e.Graph.DrawString(lblBaoHanh.Text + " : " + cboBaoHanh.Text, Color.Black, rec4, BorderSide.None);

        //    //RectangleF rec41 = new RectangleF(800, 90, 500, 25);
        //    //e.Graph.DrawString(lblKhauHao.Text + " : " + cboKhauHao.Text, Color.Black, rec41, BorderSide.None);

        //    //RectangleF rec42 = new RectangleF(1300, 90, 500, 25);
        //    //e.Graph.DrawString(lblDamBaoAT.Text + " : " + cboDamBaoAT.Text, Color.Black, rec42, BorderSide.None);





        //    //RectangleF rec5 = new RectangleF(300, 110, 500, 10);
        //    //e.Graph.DrawString("", Color.Transparent, rec5, BorderSide.None);

        //    ////số tài liệu
        //    //e.Graph.Font = new Font("Tahoma", 9, FontStyle.Italic);
        //    //sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sSTLMayMocThietBi", Commons.Modules.TypeLanguage);
        //    //RectangleF rec23 = new RectangleF(1888, 10, 500, 25);
        //    //e.Graph.DrawString(sTmp, Color.Black, rec23, BorderSide.None);


        //    //sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sPhienBanMayMocThietBi", Commons.Modules.TypeLanguage);
        //    //RectangleF rec33 = new RectangleF(1888, 35, 500, 25);
        //    //e.Graph.DrawString(sTmp, Color.Black, rec33, BorderSide.None);

        //    //sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sNgayApDungMayMocThietBi", Commons.Modules.TypeLanguage);
        //    //RectangleF rec43 = new RectangleF(1888, 60, 500, 25);
        //    //e.Graph.DrawString(sTmp, Color.Black, rec43, BorderSide.None);
        //}


    }
}
