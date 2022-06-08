using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ReportMain
{
    public partial class ucDanhMucMayMocThietBi : DevExpress.XtraEditors.XtraUserControl
    {
        
        string sBC = "ucDanhMucMayMocThietBi";
        public ucDanhMucMayMocThietBi()
        {
            Commons.Modules.SQLString = "0LOAD";
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

        private void LoadBoPhanChiuPhi()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadGridLookUpEdit(cboBPCP, Commons.Modules.ObjSystems.MLoadDataBoPhanChiuPhi(1), "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", sBC);
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadGridLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", sBC);
            }
            catch { }
        }

        private void LoadNhomMay()
        {
            try
            {
                string sLoaiMay;
                try
                {
                    sLoaiMay = cboLMay.EditValue.ToString();
                }catch { sLoaiMay = "-1"; }
                Commons.Modules.ObjSystems.MLoadGridLookUpEdit(cboNMay, Commons.Modules.ObjSystems.MLoadDataNhomMay(1,sLoaiMay), "MS_NHOM_MAY", "TEN_NHOM_MAY", sBC);
            }
            catch { }

        }

        private void LoadCbo()
        {
            string sSql;
           
            try//load hien trang su dung
            {
                DataTable dtTmp = new DataTable();
                sSql = "SELECT MS_HIEN_TRANG,CASE 0 WHEN 0 THEN TEN_HIEN_TRANG WHEN 1 THEN ISNULL(NULLIF(TEN_HIEN_TRANG_ANH,''),TEN_HIEN_TRANG) ELSE ISNULL(NULLIF(TEN_HIEN_TRANG_ANH,''),TEN_HIEN_TRANG) END  AS TEN_HIEN_TRANG FROM dbo.HIEN_TRANG_SU_DUNG_MAY UNION	SELECT -1,' < ALL > '  ORDER BY MS_HIEN_TRANG ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboHienTrangSD, dtTmp, "MS_HIEN_TRANG", "TEN_HIEN_TRANG", "");
            }
            catch { }
            try//load Combo Bảo hành có 3 giá trị: All, Hết bảo hành, Còn bảo hành
            {
                DataTable dtTmp = new DataTable();
                sSql = "SELECT -1 MS_BH,N' < ALL > ' AS TEN_BH UNION SELECT 1 , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sConBaoHanh", Commons.Modules.TypeLanguage) + "' UNION SELECT 2 , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sHetBaoHanh", Commons.Modules.TypeLanguage) + "' ORDER BY MS_BH ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBaoHanh, dtTmp, "MS_BH", "TEN_BH", "");
            }
            catch { }
            try//load Combo Cần đảm bảo an toàn có 3 giá trị: All, Bình thường, ĐB an toàn
            {
                DataTable dtTmp = new DataTable();
                sSql = "SELECT -1 MS_AT,N' < ALL > ' AS TEN_AT UNION SELECT 1 , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sBinhThuong", Commons.Modules.TypeLanguage) + "' UNION SELECT 2 , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sDamBaoAnToan", Commons.Modules.TypeLanguage) + "' ORDER BY MS_AT ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDamBaoAT, dtTmp, "MS_AT", "TEN_AT", "");
            }
            catch { }
            try//load Combo Khấu hao có 3 giá trị: All, Còn khấu hao, Hết khấu hao
            {
                DataTable dtTmp = new DataTable();
                sSql = "SELECT -1 MS_KH,N' < ALL > ' AS TEN_KH UNION SELECT 1 , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sConKhauHao", Commons.Modules.TypeLanguage) + "' UNION SELECT 2 , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sHetKhauHao", Commons.Modules.TypeLanguage) + "' ORDER BY MS_KH ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKhauHao, dtTmp, "MS_KH", "TEN_KH", "");
            }
            catch { }

            try//load Combo group Ten_N_XUONG ,TEN_HE_THONG ,TEN_LOAI_MAY,TEN_NHOM_MAY, TEN_BP_CHIU_PHI
            {
                DataTable dtTmp = new DataTable();
                sSql = "SELECT '' AS MS ,'' AS TEN ,0  AS STT UNION SELECT 'Ten_N_XUONG' AS MS , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "Ten_N_XUONG", Commons.Modules.TypeLanguage) + "', 1 AS STT UNION SELECT 'TEN_HE_THONG' , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_HE_THONG", Commons.Modules.TypeLanguage) + "',2  UNION  SELECT 'TEN_LOAI_MAY' , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_LOAI_MAY", Commons.Modules.TypeLanguage) + "',3 UNION SELECT 'TEN_NHOM_MAY' , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_NHOM_MAY", Commons.Modules.TypeLanguage) + "',4 UNION  SELECT 'TEN_BP_CHIU_PHI' , N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_BP_CHIU_PHI", Commons.Modules.TypeLanguage) + "',5  ORDER BY STT ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboGroup1, dtTmp, "MS", "TEN", "");
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboGroup2, dtTmp, "MS", "TEN", "");
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboGroup3, dtTmp, "MS", "TEN", "");
                cboGroup1.EditValue = "Ten_N_XUONG";
                cboGroup2.EditValue = "TEN_HE_THONG";
                cboGroup3.EditValue = "TEN_LOAI_MAY";

            }
            catch { }



        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            Commons.Modules.SQLString = "0LOAD";
            LoadNhomMay();
            Commons.Modules.SQLString = "";
            LoadLuoi();
        }
        //private void cboLMay_SizeChanged(object sender, EventArgs e)
        //{
        //    GridLookUpEdit editor = (GridLookUpEdit)sender;
        //    DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit properties = editor.Properties;
        //    properties.PopupFormSize = new Size(editor.Width + 20, properties.PopupFormSize.Height);
        //}
        #endregion
            

        private void ucDanhMucMayMocThietBi_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            grvChung.OptionsView.ShowGroupedColumns = true;
            grvChung.OptionsView.ShowGroupPanel = true;
            grvChung.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, string.Empty);
            LoadNX();
            LoadDChuyen();
            LoadBoPhanChiuPhi();
            LoadLoaiMay();
            LoadNhomMay();
            LoadCbo();
            Commons.Modules.SQLString = "";
            LoadLuoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }
        private void LoadLuoi()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            DataTable dtTmp = new DataTable();
            Cursor.Current = Cursors.WaitCursor;

            string sGroup = "";
            try
            {
                string sCap1 = cboGroup1.EditValue.ToString();
                string sCap2 = cboGroup2.EditValue.ToString();
                string sCap3 = cboGroup3.EditValue.ToString();//Ten_N_XUONG,TEN_HE_THONG,TEN_LOAI_MAY,TEN_NHOM_MAY,TEN_BP_CHIU_PHI
                if (sCap1 == sCap2) sCap2 = "";
                if (sCap1 == sCap3) sCap3 = "";
                if (sCap2 == sCap3) sCap3 = "";
                sGroup = (sCap1 == "" ? "" : "" + sCap1) + (sCap2 == "" ? "" : "," + sCap2) + (sCap3 == "" ? "" : "," + sCap3);
                if (sGroup.Length > 0)
                    if (sGroup.Substring(0, 1) == ",") sGroup = sGroup.Substring(1, sGroup.Length - 1);

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDanhMucMayMocThietBi",
                            Commons.Modules.UserName, Commons.Modules.TypeLanguage + 2, 
                            (cboDDiem.TextValue==""?"-1":cboDDiem.EditValue),
                            (cboDChuyen.TextValue == "" ? -1 : cboDChuyen.EditValue),
                            (cboLMay.Text == "" ? "-1" : cboLMay.EditValue),
                            (cboNMay.Text == "" ? "-1" : cboNMay.EditValue),
                            (cboBPCP.Text == "" ? -1 : cboBPCP.EditValue),
                            (cboHienTrangSD.Text == "" ? -1 : cboHienTrangSD.EditValue),
                            (cboBaoHanh.Text == "" ? -1 : cboBaoHanh.EditValue),
                            (cboKhauHao.Text == "" ? -1 : cboKhauHao.EditValue),
                            (cboDamBaoAT.Text == "" ? -1 : cboDamBaoAT.EditValue),
                            sGroup));
                bool bFi = false;
                if (grdChung.DataSource == null) bFi = true;
                if (bFi)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, false, false, true, sBC);
                    grvChung.Columns["MS_MAY"].Width = 180;
                    grvChung.Columns["TEN_MAY"].Width = 300;
                    grvChung.Columns["NGAY_DUA_VAO_SD"].Width = 150;
                    grvChung.Columns["AN_TOAN"].Width = 100;
                    grvChung.Columns["TEN_UU_TIEN"].Width = 100;
                    grvChung.Columns["TEN_LOAI_MAY"].Width = 250;
                    grvChung.Columns["TEN_NHOM_MAY"].Width = 250;
                    grvChung.Columns["GIA_MUA"].Width = 150;
                    grvChung.Columns["SO_THANG_BH"].Width = 150;
                    grvChung.Columns["NGAY_HET_BAO_HANH"].Width = 150;
                    grvChung.Columns["NHIEM_VU_THIET_BI"].Width = 250;
                    grvChung.Columns["NGOAI_TE"].Width = 150;
                    grvChung.Columns["TEN_HIEN_TRANG"].Width = 200;
                    grvChung.Columns["TEN_UU_TIEN"].Width = 200;
                    grvChung.Columns["AN_TOAN"].Width = 150;
                    grvChung.Columns["MS_N_XUONG"].Width = 150;
                    grvChung.Columns["Ten_N_XUONG"].Width = 200;
                    grvChung.Columns["TEN_HE_THONG"].Width = 200;
                    grvChung.Columns["TEN_BP_CHIU_PHI"].Width = 200;
                    grvChung.Columns["TEN_LOAI_BT"].Width = 200;
                    grvChung.Columns["LOAI_BT_GSTT"].Width = 200;
                }
                else grdChung.DataSource = dtTmp;
                grvChung.OptionsCustomization.AllowGroup = true;

                grvChung.ClearGrouping();
                GridColumn col1 = grvChung.Columns[cboGroup1.EditValue.ToString()];
                GridColumn col2 = grvChung.Columns[cboGroup2.EditValue.ToString()];
                GridColumn col3 = grvChung.Columns[cboGroup3.EditValue.ToString()];

                grvChung.BeginSort();
                try
                {
                    grvChung.ClearGrouping();
                    if (sCap1 != "") col1.GroupIndex = 0;
                    if (sCap2 != "") col2.GroupIndex = 1;
                    if (sCap3 != "") col3.GroupIndex = 2;
                }
                finally
                {
                    grvChung.EndSort();
                }
                grvChung.ExpandAllGroups();
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message.ToString()); }


           

            Cursor.Current = Cursors.Default;
        }

        private Boolean KiemDLieu()
        {
            
            if (cboDDiem.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoDiaDiem", Commons.Modules.TypeLanguage));
                cboDDiem.Focus();
                return false;
            }

            if (cboDChuyen.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoDayChuyen", Commons.Modules.TypeLanguage));
                cboDChuyen.Focus();
                return false;
            }
            if (cboBPCP.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoBoPhanChiuPhi", Commons.Modules.TypeLanguage));
                cboBPCP.Focus();
                return false;
            }

            if (cboLMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoLoaiMay", Commons.Modules.TypeLanguage));
                cboLMay.Focus();
                return false;
            }
            

            if (cboNMay.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "msgKhongCoNhomMay", Commons.Modules.TypeLanguage));
                cboNMay.Focus();
                return false;
            }


            return true;
        }



        private void btnExecute_Click(object sender, EventArgs e)
        {            
            if (!KiemDLieu()) return;
            LoadLuoi();
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (grvChung.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC,
                        "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), this.Name);
                    return;
                }

               
                InReport();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sBC, "InKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void composLink_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            
        }
        public void composLink_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, " SELECT LOGO FROM THONG_TIN_CHUNG"));
            Byte[] data = new Byte[0];
            data = (Byte[])(dtTmp.Rows[0][0]);
            RectangleF rec1 = new RectangleF(1, 5, 150, 50);
            MemoryStream mem = new MemoryStream(data);
            e.Graph.DrawImage(Image.FromStream(mem), rec1, BorderSide.None, Color.Transparent);



            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 18, FontStyle.Bold);

            RectangleF rec = new RectangleF(200, 5, e.Graph.ClientPageSize.Width - 600, 25);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TieuDe", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);

            string sTmp = "";

            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 14, FontStyle.Bold);
            //
            RectangleF rec2 = new RectangleF(300, 40, 500, 25);
            e.Graph.DrawString(lblDDiem.Text + " : " + cboDDiem.TextValue, Color.Black, rec2, BorderSide.None);

            RectangleF rec21 = new RectangleF(800, 40, 500, 25);
            e.Graph.DrawString(lblDChuyen.Text + " : " + cboDChuyen.TextValue, Color.Black, rec21, BorderSide.None);

            RectangleF rec22 = new RectangleF(1300, 40, 500, 25);
            e.Graph.DrawString(lblBPCP.Text + " : " + cboBPCP.Text, Color.Black, rec22, BorderSide.None);
            

            //
            RectangleF rec3 = new RectangleF(300, 65, 500, 25);
            e.Graph.DrawString(lblLMay.Text + " : " + cboLMay.Text, Color.Black, rec3, BorderSide.None);

            RectangleF rec31 = new RectangleF(800, 65, 500, 25);
            e.Graph.DrawString(lblNMay.Text + " : " + cboNMay.Text, Color.Black, rec31, BorderSide.None);

            RectangleF rec32 = new RectangleF(1300, 65, 500, 25);
            e.Graph.DrawString(lblHienTrangSD.Text + " : " + cboHienTrangSD.Text, Color.Black, rec32, BorderSide.None);



            //
            RectangleF rec4 = new RectangleF(300, 90, 500, 25);
            e.Graph.DrawString(lblBaoHanh.Text + " : " + cboBaoHanh.Text, Color.Black, rec4, BorderSide.None);

            RectangleF rec41 = new RectangleF(800, 90, 500, 25);
            e.Graph.DrawString(lblKhauHao.Text + " : " + cboKhauHao.Text, Color.Black, rec41, BorderSide.None);

            RectangleF rec42 = new RectangleF(1300, 90, 500, 25);
            e.Graph.DrawString(lblDamBaoAT.Text + " : " + cboDamBaoAT.Text, Color.Black, rec42, BorderSide.None);





            RectangleF rec5 = new RectangleF(300, 110, 500, 10);
            e.Graph.DrawString("", Color.Transparent, rec5, BorderSide.None);

//số tài liệu
            e.Graph.Font = new Font("Tahoma", 9, FontStyle.Italic);
            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sSTLMayMocThietBi", Commons.Modules.TypeLanguage);
            RectangleF rec23 = new RectangleF(1888, 10, 500, 25);
            e.Graph.DrawString(sTmp, Color.Black, rec23, BorderSide.None);


            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sPhienBanMayMocThietBi", Commons.Modules.TypeLanguage);
            RectangleF rec33 = new RectangleF(1888, 35, 500, 25);
            e.Graph.DrawString(sTmp, Color.Black, rec33, BorderSide.None);

            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "sNgayApDungMayMocThietBi", Commons.Modules.TypeLanguage);
            RectangleF rec43 = new RectangleF(1888, 60, 500, 25);
            e.Graph.DrawString(sTmp, Color.Black, rec43, BorderSide.None);
        }
        private void InReport()
        {
            try
            {
                CompositeLink composLink = new CompositeLink(new PrintingSystem());
                composLink.Margins.Left = 60;
                composLink.Margins.Right = 60;
                composLink.Margins.Top = 50;
                composLink.Margins.Bottom = 50;

                composLink.PaperKind = System.Drawing.Printing.PaperKind.A2;
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

        private void cboNMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadLuoi();
        }

        private void cboDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadLuoi();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtMay = new DataTable();
            dtMay = (DataTable)grdChung.DataSource;
            string sDK = "";
            try
            {

                sDK = " MS_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_MAY  LIKE '%" + txtTKiem.Text + "%' OR TEN_UU_TIEN  LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_NHOM_MAY LIKE '%" + txtTKiem.Text + "%' OR NHIEM_VU_THIET_BI LIKE '%" + txtTKiem.Text + "%' OR NGOAI_TE LIKE '%" + txtTKiem.Text + "%' OR TEN_HIEN_TRANG LIKE '%" + txtTKiem.Text + "%' OR TEN_UU_TIEN LIKE '%" + txtTKiem.Text + "%' OR MS_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' OR TEN_BP_CHIU_PHI LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_BT LIKE '%" + txtTKiem.Text + "%' OR LOAI_BT_GSTT LIKE '%" + txtTKiem.Text + "%' ";

                dtMay.DefaultView.RowFilter = sDK;
            }
            catch { dtMay.DefaultView.RowFilter = ""; }
            grvChung.ExpandAllGroups();
        }
    }
}
