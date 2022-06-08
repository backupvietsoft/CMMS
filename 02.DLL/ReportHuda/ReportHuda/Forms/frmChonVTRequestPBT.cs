using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Diagnostics;
using System.Threading;

namespace ReportHuda
{
    public partial class frmChonVTRequestPBT : DevExpress.XtraEditors.XtraForm
    {
        public string sPBT = "WO-201812000034";// "WO-201810000113";
        public string sMay = "EXT-01-01";//"FAN-01-07";
        
        public string sCN = "";
        public DateTime dNgayYC = DateTime.Now;
        string sINTConnect = "";
        string sToken = "";

        public frmChonVTRequestPBT()
        {
            InitializeComponent();
        }

        private void frmChonVTRequestPBT_Load(object sender, EventArgs e)
        {
            LoadFormRequest();
        }
        public void LoadFormRequest()
        {
            if (sPBT == "-1") return;
            try
            {
                sINTConnect = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG")));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgChuaCoThongTinCuaDataINT", Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                sINTConnect = "";
            }

            if (sINTConnect == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgChuaCoThongTinCuaDataINT", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            TaoLuoi();
            Commons.Modules.ObjSystems.ThayDoiNN(this);

        }
        private void TaoLuoi()
        {
            if (sINTConnect == "")
            {
                try
                {
                    sINTConnect = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG")));
                }catch { sINTConnect = ""; }

            }
            if (Commons.Modules.sPrivate.ToUpper() == "PILMICO") CallBack();
            Thread t = new Thread(new ParameterizedThreadStart(ThreadLoop));

            string sSql;
            DataTable dtTmp = new DataTable();
            double slTon = 0;
            double slReq = 0;
            sSql = " SELECT CONVERT(BIT,1) AS CHON, T2.MS_PT, T2.TEN_PT , T2.QUY_CACH , CASE " + Commons.Modules.TypeLanguage.ToString() +
                        " WHEN 0 THEN T3.TEN_1 WHEN 1 THEN T3.TEN_2 ELSE T3.TEN_3 END AS TEN_DVT,CONVERT(FLOAT,0) AS SL_TON, SUM(T1.SL_KH) AS SL_KH, CONVERT(FLOAT,0) AS SL_DA_REQUEST, CONVERT(FLOAT,0) AS SL_REQUEST, CONVERT(FLOAT,0) AS SL_RETURN, T3.DVT,CONVERT(INT,0) AS [TYPE] " +
                        " FROM  " +
                        " (SELECT MS_PHIEU_BAO_TRI, MS_PT, SUM(SL_KH) AS SL_KH FROM(SELECT MS_PHIEU_BAO_TRI, MS_PT, SUM(SL_KH) AS SL_KH, 1 AS CVC  FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI = N'" + sPBT + "' GROUP BY MS_PHIEU_BAO_TRI, MS_PT " +
                        " UNION SELECT MS_PHIEU_BAO_TRI, MS_PT,SUM(SL_KH) AS SL_KH, 2 FROM PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG WHERE MS_PHIEU_BAO_TRI = N'" + sPBT + "' GROUP BY MS_PHIEU_BAO_TRI, MS_PT ) A " +
                        " GROUP BY MS_PT, MS_PHIEU_BAO_TRI) AS T1 INNER JOIN dbo.IC_PHU_TUNG AS T2 ON T1.MS_PT = T2.MS_PT INNER JOIN " +
                        " dbo.DON_VI_TINH AS T3 ON T2.DVT = T3.DVT WHERE T1.MS_PHIEU_BAO_TRI = N'" +  sPBT + "' " +
                        " GROUP BY T2.MS_PT, T2.QUY_CACH, T2.TEN_PT, CASE " + Commons.Modules.TypeLanguage.ToString() +
                        " WHEN 0 THEN T3.TEN_1 WHEN 1 THEN T3.TEN_2 ELSE T3.TEN_3 END, T1.MS_PHIEU_BAO_TRI , T3.DVT ORDER BY T1.MS_PHIEU_BAO_TRI, T2.MS_PT ";
            
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["SL_DA_REQUEST"].ReadOnly = false;
            dtTmp.Columns["SL_REQUEST"].ReadOnly = false;
            dtTmp.Columns["SL_RETURN"].ReadOnly = false;
            dtTmp.Columns["SL_TON"].ReadOnly = false;
            dtTmp.Columns["CHON"].ReadOnly = false;
            dtTmp.Columns["TYPE"].ReadOnly = false;

            
            if (Commons.Modules.sPrivate.ToUpper() == "PILMICO")
            {
                CallBack();
                t.Start((Action)CallBack);
            }
            if (dtTmp.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTmp.Rows)
                {
                    slTon = 0;
                    if (Commons.Modules.sPrivate.ToUpper() == "BARIA") dr["SL_DA_REQUEST"] = TinhSLDaRequestBaria(dr["MS_PT"].ToString(), dr["DVT"].ToString(), out slTon);
                    if (Commons.Modules.sPrivate.ToUpper() == "PILMICO") dr["SL_DA_REQUEST"] = TinhSLDaRequestPIL(dr["MS_PT"].ToString(), dr["DVT"].ToString(), out slTon);
                    dr["SL_TON"] = slTon;
                    slReq = 0;
                    try
                    {
                        if (slTon <= 0) slReq = 0; else slReq = Convert.ToDouble(dr["SL_KH"]) - Convert.ToDouble(dr["SL_DA_REQUEST"]);
                    }catch { slReq = 0; }

                    dr["SL_REQUEST"] = slReq;

                    if (Convert.ToDouble(dr["SL_REQUEST"].ToString()) > 0) dr["TYPE"] = 1;
                    dr.AcceptChanges();
                }
            }
            if (Commons.Modules.sPrivate.ToUpper() == "PILMICO")
            {
                t.Abort();
                sToken = "";
            }


            dtTmp.Columns["SL_DA_REQUEST"].ReadOnly = true;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, false, true, true);
            grvBC.Columns["DVT"].Visible = false;
            for (int j = 1; j < grvBC.Columns.Count - 4; j++)
            {
                grvBC.Columns[j].OptionsColumn.ReadOnly = true;
            }

            if (Commons.Modules.sPrivate.ToUpper() == "PILMICO") grvBC.Columns["SL_RETURN"].Visible = true;
            else
                grvBC.Columns["SL_RETURN"].Visible = false;
            

            //dtTmp.Columns["SL_REQUEST"].DisplayFormat 
            grvBC.Columns["SL_REQUEST"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvBC.Columns["SL_REQUEST"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

            grvBC.Columns["SL_DA_REQUEST"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvBC.Columns["SL_DA_REQUEST"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

            grvBC.Columns["SL_RETURN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvBC.Columns["SL_RETURN"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

            grvBC.Columns["SL_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvBC.Columns["SL_KH"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

            grvBC.Columns["SL_TON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvBC.Columns["SL_TON"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

            grvBC.Columns["CHON"].Width = 40;
            grvBC.Columns["SL_REQUEST"].Width = 60;
            grvBC.Columns["SL_RETURN"].Width = 60;
            grvBC.Columns["SL_DA_REQUEST"].Width = 60;
            grvBC.Columns["SL_KH"].Width = 60;
            grvBC.Columns["SL_TON"].Width = 60;

            grvBC.Columns["TYPE"].Visible = false;
        }
        private double TinhSLDaRequestBaria(string sMSPT, string sDVT, out double SLTon)
        {
            SLTon = 0;
            double fSLuong = 0;
            string sSql = "";
            try
            {
                if (sINTConnect == "")
                    return 0;

                sSql = "SELECT ISNULL(SUM(SO_LUONG),0) AS SL FROM NAV_REQUEST WHERE MS_PHIEU_BAO_TRI = '" + sPBT + "' AND MS_MAY = '" + sMay + "' AND MS_PT = '" + sMSPT + "' ";
                fSLuong = Convert.ToDouble(SqlHelper.ExecuteScalar(sINTConnect, CommandType.Text, sSql));
            }
            catch { fSLuong = 0; }

            DataTable dtTmp = new DataTable();
            string sBTam = "VT_REQUEST_TMP" + Commons.Modules.UserName;
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(sINTConnect, "sp_PHU_TUNG_SL", null, null, sMSPT));
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");
                sSql = "SELECT SUM(SL) AS SL_TON FROM " +  sBTam + " WHERE MS_PT = '" + sMSPT + "'";
                SLTon = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            }
            catch { SLTon = 0; }
            Commons.Modules.ObjSystems.XoaTable(sBTam);
            return fSLuong;
        }

        
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBC);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBC);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacRequest",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                if (Commons.Modules.sPrivate.ToUpper() == "BARIA") RequestBaria();
                if (Commons.Modules.sPrivate.ToUpper() == "PILMICO") RequestPil();
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgRequestKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        //REQUEST
        private void RequestBaria()
        {
            string sSql = "";
            string sBT = "INT_RE_TMP" + Commons.Modules.UserName;
            try
            {
                if (sINTConnect == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgChuaCoThongTinCuaDataINT", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, (DataTable)grdBC.DataSource, "");

                DataTable dtTmp = new DataTable();
                dtTmp = ((DataTable)grdBC.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = "ISNULL(SL_REQUEST,0) > 0 AND CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();

                string iBPCP = "-1";
                iBPCP = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                            " SELECT TOP 1 MS_BP_CHIU_PHI FROM MAY_BO_PHAN_CHIU_PHI T1 INNER JOIN(SELECT MAX(NGAY_NHAP) AS NMAX , MS_MAY FROM MAY_BO_PHAN_CHIU_PHI " +
                            " WHERE MS_MAY = '" + sMay + "' AND NGAY_NHAP <= '" + dNgayYC.Date.ToString("MM/dd/yyyy") + "' GROUP BY MS_MAY) T2 ON " +
                            " T1.MS_MAY = T2.MS_MAY AND T1.NGAY_NHAP = T2.NMAX"));

                foreach (DataRow dr in dtTmp.Rows)
                {
                    sSql = "INSERT INTO [NAV_REQUEST]([MS_PHIEU_BAO_TRI],[MS_MAY],[MS_PT],[SO_LUONG],[MS_BP_CHIU_PHI], " +
                                " [MS_CONG_NHAN],[NGAY_YEU_CAU],[INSERT_DATE],[STATUS]) " +
                                " VALUES ('" + sPBT + "', '" + sMay + "', '" + dr["MS_PT"].ToString() + "', " + dr["SL_REQUEST"].ToString() + ", " + iBPCP + "," +
                                " '" + sCN + "', '" + dNgayYC.Date.ToString("MM/dd/yyyy") + "', GETDATE(),'N') ";
                    SqlHelper.ExecuteNonQuery(sINTConnect, CommandType.Text, sSql);
                }
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgRequestThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgRequestKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Commons.Modules.ObjSystems.XoaTable(sBT);


        }

        private void RequestPil()
        {
            
            string sBT = "INT_RE_PIL_TMP";
            try
            {
                if (sINTConnect == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgChuaCoThongTinCuaDataINT", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, (DataTable)grdBC.DataSource, "");
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spINTMaterialRequest", sPBT,Commons.Modules.UserName);


                try
                {
                    if (Convert.ToInt16( SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spSentMailGoodsIssue", sPBT)) == 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgGoiMailKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch { }
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgRequestThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgRequestKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            Commons.Modules.ObjSystems.XoaTable(sBT);
        }


        private void grvBC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (Commons.Modules.SQLString == "0LOAD") return;

            //////////try
            //////////{
            //////////    if (e.Column.Name.ToString().ToUpper() == "COLSL_REQUEST")
            //////////    {
            //////////        Commons.Modules.SQLString = "0LOAD";
            //////////        if (Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_REQUEST").ToString()) == 0)
            //////////            grvBC.SetFocusedRowCellValue("CHON", 0);
            //////////        else
            //////////            grvBC.SetFocusedRowCellValue("CHON", 1);

            //////////        Commons.Modules.SQLString = "";
            //////////    }

            //////////    if (e.Column.Name.ToString().ToUpper() == "COLCHON")
            //////////    {
            //////////        Commons.Modules.SQLString = "0LOAD";
            //////////        if (!Convert.ToBoolean(grvBC.GetFocusedRowCellValue("CHON").ToString()))
            //////////            grvBC.SetFocusedRowCellValue("SL_REQUEST", 0);
            //////////        else
            //////////            grvBC.SetFocusedRowCellValue("SL_REQUEST", Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_KH")) -
            //////////                Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_DA_REQUEST")));
            //////////        Commons.Modules.SQLString = "";
            //////////    }
            //////////}
            //////////catch { }
            //////////if (Commons.Modules.sPrivate.ToUpper() != "PILMICO") return;
            //////////try
            //////////{
            //////////    if (e.Column.Name.ToString().ToUpper() == "COLSL_RETURN")
            //////////    {
            //////////        Commons.Modules.SQLString = "0LOAD";
            //////////        if (Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_RETURN").ToString()) == 0)
            //////////            grvBC.SetFocusedRowCellValue("CHON", 0);
            //////////        else
            //////////            grvBC.SetFocusedRowCellValue("CHON", 1);

            //////////        Commons.Modules.SQLString = "";
            //////////    }
            //////////}
            //////////catch { }

            Commons.Modules.SQLString = "";
        }


        private void grvBC_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (view.FocusedColumn.FieldName == "SL_REQUEST")
                {
                    if ((Convert.ToDouble(e.Value) + Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_DA_REQUEST").ToString())) > Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_KH").ToString()))
                    {
                        e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                                        "msgSLRequestLonHonSLKH", Commons.Modules.TypeLanguage);
                        e.Value = Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_KH")) - Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_DA_REQUEST"));
                        //grvBC.SetFocusedRowCellValue("SL_REQUEST", Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_KH")) - Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_DA_REQUEST")));
                        e.Valid = false;
                    }

                    if ((Convert.ToDouble(e.Value) > Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_TON").ToString())))
                    {
                        e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                                        "msgSLRequestLonHonSLTon", Commons.Modules.TypeLanguage);
                        e.Value = Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_TON"));
                        //grvBC.SetFocusedRowCellValue("SL_REQUEST", Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_TON")));
                        e.Valid = false;
                    }
                }
            }
            catch { }

            
            if (Commons.Modules.sPrivate.ToUpper() != "PILMICO") return;
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (view.FocusedColumn.FieldName == "SL_RETURN")
                {
                    if (Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_REQUEST").ToString()) != 0 && Convert.ToDouble(e.Value) != 0)
                    {
                        e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                                            "msgBanDaNhapSLRequestNenKhongTheNhapSLReturn", Commons.Modules.TypeLanguage);
                        e.Value = 0;
                        grvBC.SetFocusedRowCellValue("SL_RETURN", 0);
                        e.Valid = false;
                        
                    }
                    else
                    {
                        if (Convert.ToDouble(e.Value) > Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_DA_REQUEST").ToString()))
                        {
                            e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                                            "msgSLReturnLonHonSLDaPhanBo", Commons.Modules.TypeLanguage);
                            e.Value = 0;
                            e.Valid = false;
                        }
                    }
                }


                
            }
            catch { }
        }



        private void grvBC_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (Commons.Modules.sPrivate.ToUpper() != "PILMICO") return;
            grvBC.SetFocusedRowCellValue("TYPE", 0);
            if (Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_REQUEST").ToString()) > 0 && Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_RETURN").ToString()) == 0)
            {
                grvBC.SetFocusedRowCellValue("TYPE", 1);
            }
            if (Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_REQUEST").ToString()) == 0 && Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_RETURN").ToString()) > 0)
            {
                grvBC.SetFocusedRowCellValue("TYPE", 2);
            }

            if (Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_REQUEST").ToString()) > 0 || Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_RETURN").ToString()) > 0) grvBC.SetFocusedRowCellValue("CHON", 1); else grvBC.SetFocusedRowCellValue("CHON", 0);
        }


        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)grdBC.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " OR MS_DH_XUAT_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR TEN_KHO LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR QUY_CACH LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(4, dk.Length - 4);
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private double TinhSLDaRequestPIL(string sMSPT, string sDVT, out double SLTon)
        {
            SLTon = 0;
            double fSLuong = 0;
            string sSql = "";
            try
            {
                if (sINTConnect == "")
                    return 0;

                sSql = "SELECT ISNULL(SUM(CASE [TYPE] WHEN 1 THEN Quantity WHEN 2 THEN -Quantity ELSE 0 END),0) AS SL FROM MaterialRequest WHERE WorkOrder = '" + sPBT + "' AND CONVERT(NVARCHAR(50),ItemID) = '" + sMSPT + "'  ";
                fSLuong = Convert.ToDouble(SqlHelper.ExecuteScalar(sINTConnect, CommandType.Text, sSql));
            }
            catch { fSLuong = 0; }

            try
            {
                //exec spGetDataPIL '100000000283678','9WtaCelPwfKkx5rzgSSeAYjRvsGI'
                SLTon = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spGetDataPIL", sMSPT, sToken));
            }
            catch
            {
                SLTon = 0;
            }
            if (SLTon == 0)
            {
                try
                {
                    CallBack();
                    SLTon = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spGetDataPIL", sMSPT, sToken));
                }
                catch 
                {
                    SLTon = 0;
                }
            }
            return fSLuong;
        }
        
        private void CallProcess(string args)
        {
            try
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.Arguments = args;
                start.FileName = Application.StartupPath + "\\GetTokenPIL.exe";
                start.WindowStyle = ProcessWindowStyle.Hidden;
                start.CreateNoWindow = true;
                int exitCode;
                using (Process proc = Process.Start(start))
                {
                    proc.WaitForExit();
                    exitCode = proc.ExitCode;
                    if (exitCode == 0)
                    {
                        sToken = System.IO.File.ReadAllText(Application.StartupPath + "\\GetTokenPIL.txt");
                    }
                }
            }
            catch { sToken = ""; }
            System.IO.File.Delete(Application.StartupPath + "\\GetTokenPIL.txt");
        }

        private void ThreadLoop(object callback)
        {
            while (true)
            {
                ((Delegate)callback).DynamicInvoke(null);
                Thread.Sleep(120000);
            }
        }
        private void CallBack()
        {
            CallProcess("Basic OVg2dXVBUnNHbUdjNkJCUkFzbkU2ZEpTSXdRNXlDbnY6REFEaldrYjRRYzl5d1RGNQ==");
        }

    }

}
