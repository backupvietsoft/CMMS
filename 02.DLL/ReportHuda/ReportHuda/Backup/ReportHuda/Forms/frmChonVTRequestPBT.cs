using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda
{
    public partial class frmChonVTRequestPBT : DevExpress.XtraEditors.XtraForm
    {
        public string sPBT = "-1";
        public string sMay = "-1";
        
        public string sCN = "-1";
        public DateTime dNgayYC;

        public frmChonVTRequestPBT()
        {
            InitializeComponent();
        }

        private void frmChonVTRequestPBT_Load(object sender, EventArgs e)
        {
            if (sPBT == "-1") return;
            TaoLuoi();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void TaoLuoi()
        { 
            string sSql;
            DataTable dtTmp = new DataTable();
            double slTon = 0;
            sSql = " SELECT CONVERT(BIT,1) AS CHON, T2.MS_PT, T2.TEN_PT , T2.QUY_CACH , CASE " + Commons.Modules.TypeLanguage.ToString() +
                        " WHEN 0 THEN T3.TEN_1 WHEN 1 THEN T3.TEN_2 ELSE T3.TEN_3 END AS TEN_DVT,CONVERT(FLOAT,0) AS SL_TON, SUM(T1.SL_KH) AS SL_KH, CONVERT(FLOAT,0) AS SL_DA_REQUEST, CONVERT(FLOAT,0) AS SL_REQUEST, T3.DVT " +
                        " FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG AS T1 INNER JOIN dbo.IC_PHU_TUNG AS T2 ON T1.MS_PT = T2.MS_PT INNER JOIN " +
                        " dbo.DON_VI_TINH AS T3 ON T2.DVT = T3.DVT WHERE T1.MS_PHIEU_BAO_TRI = '" +  sPBT + "' " +
                        " GROUP BY T2.MS_PT, T2.QUY_CACH, T2.TEN_PT, CASE " + Commons.Modules.TypeLanguage.ToString() +
                        " WHEN 0 THEN T3.TEN_1 WHEN 1 THEN T3.TEN_2 ELSE T3.TEN_3 END, T1.MS_PHIEU_BAO_TRI , T3.DVT ORDER BY T1.MS_PHIEU_BAO_TRI, T2.MS_PT ";
            
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["SL_DA_REQUEST"].ReadOnly = false;
            dtTmp.Columns["SL_REQUEST"].ReadOnly = false;
            dtTmp.Columns["SL_TON"].ReadOnly = false;
            dtTmp.Columns["CHON"].ReadOnly = false;
            if (dtTmp.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTmp.Rows)
                {
                    slTon = 0;
                    dr["SL_DA_REQUEST"] = TinhSLDaRequest(dr["MS_PT"].ToString(), dr["DVT"].ToString(), out slTon);
                    dr["SL_TON"] = slTon;
                    dr["SL_REQUEST"] = Convert.ToDouble(dr["SL_KH"]) - Convert.ToDouble(dr["SL_DA_REQUEST"]);
                    dr.AcceptChanges();
                }
            }

            dtTmp.Columns["SL_DA_REQUEST"].ReadOnly = true;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, false, true, true);
            grvBC.Columns["DVT"].Visible = false;
            for (int j = 1; j < grvBC.Columns.Count - 2; j++)
            {
                grvBC.Columns[j].OptionsColumn.ReadOnly = true;
            }
            //dtTmp.Columns["SL_REQUEST"].DisplayFormat 
            grvBC.Columns["SL_REQUEST"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvBC.Columns["SL_REQUEST"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

            grvBC.Columns["SL_DA_REQUEST"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvBC.Columns["SL_DA_REQUEST"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

            grvBC.Columns["SL_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvBC.Columns["SL_KH"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

            grvBC.Columns["SL_TON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvBC.Columns["SL_TON"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

            grvBC.Columns["CHON"].Width = 40;
            grvBC.Columns["SL_REQUEST"].Width = 60;
            grvBC.Columns["SL_DA_REQUEST"].Width = 60;
            grvBC.Columns["SL_KH"].Width = 60;
            grvBC.Columns["SL_TON"].Width = 60;
            

        }
        private double TinhSLDaRequest(string sMSPT, string sDVT, out double SLTon)
        {
            SLTon = 0;
            double fSLuong = 0;
            string sINTConnect = "";
            string sSql = "";
            try
            {
                sSql = "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG";
                sINTConnect = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
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


            string sINTConnect = "";
            string sSql = "";
            string sBT = "NAV_RE_TMP" + Commons.Modules.UserName;
            try
            {
                sSql = "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG";
                sINTConnect = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
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
                    "msgRequestThanhCong", Commons.Modules.TypeLanguage) , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgRequestKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            }
            Commons.Modules.ObjSystems.XoaTable(sBT);
            this.Close();
        }

        private void grvBC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                if (e.Column.Name.ToString().ToUpper() == "COLSL_REQUEST")
                {
                    Commons.Modules.SQLString = "0LOAD";
                    if (Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_REQUEST").ToString()) == 0)
                        grvBC.SetFocusedRowCellValue("CHON", 0);
                    else
                        grvBC.SetFocusedRowCellValue("CHON", 1);

                    Commons.Modules.SQLString = "";
                }

                if (e.Column.Name.ToString().ToUpper() == "COLCHON")
                {
                    Commons.Modules.SQLString = "0LOAD";
                    if (!Convert.ToBoolean(grvBC.GetFocusedRowCellValue("CHON").ToString()))
                        grvBC.SetFocusedRowCellValue("SL_REQUEST", 0);
                    else
                        grvBC.SetFocusedRowCellValue("SL_REQUEST", Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_KH")) -
                            Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_DA_REQUEST")));
                    Commons.Modules.SQLString = "";
                }
            }
            catch { }

            Commons.Modules.SQLString = "";
        }


        private void grvBC_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
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
                        e.Valid = false;
                    }
                }
            }
            catch { }
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
    }
}