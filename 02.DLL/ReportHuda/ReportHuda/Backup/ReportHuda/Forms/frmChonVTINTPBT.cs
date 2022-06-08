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
    public partial class frmChonVTINTPBT : DevExpress.XtraEditors.XtraForm
    {
        public string sPBT = "-1";
        public string sMay = "-1";
        public DataTable dtData;
        public int iLoaiForm = 0;
        string sConnectINT = "";

        //iLoaiForm = 0 -- form phan bo vat tu 
        //iLoaiForm = 1 -- form nhap tra
        

        public frmChonVTINTPBT()
        {
            InitializeComponent();
        }
        private void TaoLuoiNhapTra()
        {
            string sSql;
            string sBTNTra = "NTra_TMP" + Commons.Modules.UserName;
            DataTable dtTmp = new DataTable();
            sSql = "SELECT MS_DH_XUAT_PT,MS_KHO, MS_MAY, MS_PHIEU_BAO_TRI,MS_BP_CHIU_PHI, MS_PT, SUM(SO_LUONG) AS SL_TRA " +
                        " FROM dbo.TB_IC_DON_HANG_XUAT_VAT_TU " +
                        " WHERE (TYPE = 'N') AND (STATUS = 'N') AND (MS_PHIEU_BAO_TRI = '" + sPBT + "'  OR N'" + sPBT + "' = '-1' ) " +
                        " AND (MS_MAY = N'" + sMay + "'  OR N'" + sMay + "' = '-1' )" +
                        " GROUP BY MS_DH_XUAT_PT,MS_KHO, MS_MAY, MS_PHIEU_BAO_TRI,MS_BP_CHIU_PHI, MS_PT ";
                        
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(sConnectINT, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTNTra, dtTmp, "");
                //iLoaiForm = 0 -- ALL
                //iLoaiForm = 1 -- NOT ALL
                if (iLoaiForm == 0)
                    sSql = " CONVERT(BIT,1) ";
                else
                    sSql = " CONVERT(BIT,0) ";

                sSql = " SELECT " +  sSql + " AS CHON, T1.MS_DH_XUAT_PT,T4.TEN_KHO,T1.MS_PHIEU_BAO_TRI,T1.MS_PT,T3.TEN_PT,T3.QUY_CACH, " +
                        " T1.MS_MAY, ISNULL(T1.SL_XUAT,0) AS SL_XUAT ,ISNULL(SL_PB,0) AS SL_PB ,ISNULL(SL_TRA,0) AS SL_TRA, " +
                        " ISNULL(SL_XUAT,0) - ISNULL(SL_PB,0) - ISNULL(SL_TRA,0) AS SL_CL,T1.MS_KHO,DON_GIA,T1.NGAY,T1.MS_BP_CHIU_PHI,NAVEntryNo " +
                        " FROM (SELECT MS_DH_XUAT_PT,MS_PHIEU_BAO_TRI,MS_MAY,MS_PT, SUM(SO_LUONG) AS SL_XUAT, MS_KHO, AVG(DON_GIA) AS DON_GIA,NGAY, MS_BP_CHIU_PHI,[NAV Entry No] AS  NAVEntryNo " +
                        " FROM SYN_TB_IC_DON_HANG_XUAT_VAT_TU_CMMS T1 WHERE     (T1.TYPE = N'X') AND [STATUS] = 'N'  " +
                        " AND (T1.MS_PHIEU_BAO_TRI = N'" + sPBT + "' OR N'" + sPBT + "' = '-1' ) AND (T1.MS_MAY = N'" + sMay + "'  OR N'" + sMay + "' = '-1' )    " +
                        " GROUP BY MS_DH_XUAT_PT,MS_PHIEU_BAO_TRI,MS_MAY,MS_PT, MS_KHO,NGAY,MS_BP_CHIU_PHI,[NAV Entry No] ) T1 LEFT JOIN " +
                        " (SELECT MS_DH_XUAT_PT,MS_PHIEU_BT,MS_MAY,MS_PT, SUM(SO_LUONG_PHAN_BO) AS SL_PB, MS_KHO,MS_BP_CHIU_PHI " +
                        " FROM SYN_TB_ALLOCATION_VTPT_FOR_PBT    " +
                        " WHERE (MS_PHIEU_BT = N'" + sPBT + "' OR N'" + sPBT + "' = '-1') AND (MS_MAY = N'" + sMay + "' OR N'" + sMay + "' = '-1')   " +
                        " GROUP BY MS_DH_XUAT_PT,MS_PHIEU_BT,MS_MAY,MS_PT, MS_KHO,MS_BP_CHIU_PHI) T2 ON T1.MS_DH_XUAT_PT = T2.MS_DH_XUAT_PT AND T1.MS_KHO = T2.MS_KHO AND T1.MS_MAY = T2.MS_MAY " +
                        " AND T1.MS_BP_CHIU_PHI = T2.MS_BP_CHIU_PHI " +
                        " AND T1.MS_PT = T2.MS_PT AND T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BT INNER JOIN IC_PHU_TUNG T3 ON T1.MS_PT = T3.MS_PT INNER JOIN IC_KHO T4 ON T1.MS_KHO = T4.MS_KHO  " +
                        " LEFT JOIN " + sBTNTra + " T5 ON  T1.MS_DH_XUAT_PT = T5.MS_DH_XUAT_PT AND T1.MS_KHO = T5.MS_KHO AND T1.MS_MAY = T5.MS_MAY " +
                        " AND T1.MS_BP_CHIU_PHI = T5.MS_BP_CHIU_PHI AND T1.MS_PT = T5.MS_PT AND T1.MS_PHIEU_BAO_TRI = T5.MS_PHIEU_BAO_TRI " +
                        " WHERE (ISNULL(SL_XUAT,0) - ISNULL(SL_PB,0) - ISNULL(SL_TRA,0)) <> 0 ORDER BY T1.MS_DH_XUAT_PT,T4.TEN_KHO,T1.MS_PHIEU_BAO_TRI";

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dtTmp.Columns["MS_PT"].ReadOnly = true;
                dtTmp.Columns["QUY_CACH"].ReadOnly = true;
                dtTmp.Columns["TEN_PT"].ReadOnly = true;
                dtTmp.Columns["SL_XUAT"].ReadOnly = true;
                dtTmp.Columns["SL_CL"].ReadOnly = false;
                dtTmp.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtTmp, true, false, true, true);
                grvBC.Columns["MS_KHO"].Visible = false;
                grvBC.Columns["MS_MAY"].Visible = false;

                //grvBC.Columns["MS_DH_XUAT_PT"].OptionsColumn.FixedWidth = true;
                
                grvBC.Columns["MS_BP_CHIU_PHI"].Visible = false;
                grvBC.Columns["DON_GIA"].Visible = false;
                grvBC.Columns["NAVEntryNo"].Visible = false;

                for (int j = 1; j < grvBC.Columns.Count; j++)
                {
                    grvBC.Columns[j].OptionsColumn.ReadOnly = true;
                }


                grvBC.Columns["SL_XUAT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvBC.Columns["SL_XUAT"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

                grvBC.Columns["SL_CL"].OptionsColumn.ReadOnly = false;
                grvBC.Columns["CHON"].OptionsColumn.ReadOnly = false;

                grvBC.Columns["SL_CL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvBC.Columns["SL_CL"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

                grvBC.Columns["SL_PB"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvBC.Columns["SL_PB"].DisplayFormat.FormatString = "n" + Commons.Modules.iSoLeSL.ToString();

                grvBC.Columns["SL_XUAT"].Width = 60;
                grvBC.Columns["SL_PB"].Width = 60;
                grvBC.Columns["SL_CL"].Width = 60;
                grvBC.Columns["MS_DH_XUAT_PT"].Width = 60;


                grvBC.OptionsView.ColumnAutoWidth = true;
            }
            catch { }
            Commons.Modules.ObjSystems.XoaTable(sBTNTra);
        }

        private void frmChonVTINTPBT_Load(object sender, EventArgs e)
        {
            try
            {
                sConnectINT = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, 
                        "SELECT ISNULL(SYN_INFO,'') AS SYN_INFO  FROM THONG_TIN_CHUNG")));
                if (sConnectINT.ToString().Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoTho0ngTinKetNoiVoiDataINT",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoTho0ngTinKetNoiVoiDataINT",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TaoLuoiNhapTra();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            //iLoaiForm = 0 -- form phan bo vat tu 
            //iLoaiForm = 1 -- form nhap tra
            //2) Phân bổ vật tư them nút lệnh all/uncheck all; không them trên trả lại
            if (iLoaiForm == 0)
                this.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "frmPhieuBaoTriAllocateVTPT", Commons.Modules.TypeLanguage);
            else
            {
                this.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "frmNhapTraBARIA", Commons.Modules.TypeLanguage);
                btnALL.Visible = false;
                btnNotALL.Visible = false;
            }


        }

        private void grvBC_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (view.FocusedColumn.FieldName == "SL_CL")
                {


                    if ((Convert.ToDouble(e.Value)) > (Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_XUAT").ToString()) -
                        Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_TRA").ToString()) - 
                        Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_PB").ToString())))
                    {
                        e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                                        "msgSLPBLonHonSLINT", Commons.Modules.TypeLanguage);
                        e.Valid = false;
                    }
                }
            }
            catch { }
        }
        private void grvBC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                if (e.Column.Name.ToString().ToUpper() == "COLSL_CL")
                {
                    Commons.Modules.SQLString = "0LOAD";
                    if (Convert.ToDouble(grvBC.GetFocusedRowCellValue("SL_CL").ToString()) == 0)
                        grvBC.SetFocusedRowCellValue("CHON", 0);
                    else
                        grvBC.SetFocusedRowCellValue("CHON", 1);
                    Commons.Modules.SQLString = "";
                }
            }
            catch { }
            Commons.Modules.SQLString = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (iLoaiForm == 1)
            {

                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacNhapTra",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                NhapTra();
                TaoLuoiNhapTra();
                return;
            }

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacPhanBo",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            

            dtData = new DataTable();
            dtData = (DataTable)grdBC.DataSource;
            string sBT = "ALLOCATION_TMP" + Commons.Modules.UserName;

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtData, "");
            string sSql = "INSERT INTO SYN_TB_ALLOCATION_VTPT_FOR_PBT (MS_DH_XUAT_PT,MS_PHIEU_BT,MS_MAY,MS_PT,SO_LUONG_PHAN_BO, MS_KHO, DON_GIA,DA_TAO_PHIEU,MS_BP_CHIU_PHI) " +
                    " SELECT MS_DH_XUAT_PT,MS_PHIEU_BAO_TRI,MS_MAY,MS_PT,SL_CL, MS_KHO, DON_GIA,0,MS_BP_CHIU_PHI FROM " + sBT +
                    " WHERE ISNULL(SL_CL,0) > 0 AND MS_MAY = '" + sMay + "' AND MS_PHIEU_BAO_TRI = '" + sPBT + "' AND ISNULL(CHON,0) = 1";

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
            Commons.Modules.ObjSystems.XoaTable(sBT);

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spCreatePNXAuto", sPBT, sMay);
                tran.Commit();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhanBoThanhCong",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhanBoKhongThanhCong",
                    Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tran.Rollback(); 
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }


        private void NhapTra()
        {
            string sSql = "";
            dtData = new DataTable();
            dtData = (DataTable)grdBC.DataSource;
            string sBT = "ALLOCATION_TMP" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(sConnectINT, sBT, dtData, "");

            sSql = "INSERT INTO [TB_IC_DON_HANG_XUAT_VAT_TU]([MS_DH_XUAT_PT],[NGAY],[MS_PHIEU_BAO_TRI],[MS_MAY],[MS_KHO],[MS_PT], " +
                    " [MS_BP_CHIU_PHI],[SO_LUONG],[DON_GIA],[TYPE],[INSERT_DATE],[STATUS], [NAV Entry No],[MS_CONG_NHAN] )" +
                    " SELECT [MS_DH_XUAT_PT],[NGAY],[MS_PHIEU_BAO_TRI],[MS_MAY],[MS_KHO],[MS_PT], " +
                    " [MS_BP_CHIU_PHI],SL_CL,[DON_GIA],'N',GETDATE(),'N',[NAVEntryNo], " + (string.IsNullOrEmpty(Commons.Modules.sMaNhanVienMD) ? "NULL" : Commons.Modules.sMaNhanVienMD) +
                    " FROM " + sBT + " WHERE (ISNULL(SL_CL,0) > 0)  AND (ISNULL(CHON,0) = 1) ";
            try
            {
                SqlHelper.ExecuteNonQuery(sConnectINT, CommandType.Text, sSql);

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgNhapTraThanhCong",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                try
                {
                    SqlHelper.ExecuteNonQuery(sConnectINT, CommandType.Text, "DROP TABLE " + sBT);
                }
                catch { }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgNhapTraKhongThanhCong",
                        Commons.Modules.TypeLanguage) + "\n" + ex.Message , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBC);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBC);
        }

        private void grvBC_HiddenEditor(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraGrid.Views.Grid.GridView).BestFitColumns();   
        }
    }
}