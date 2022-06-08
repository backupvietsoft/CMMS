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
    public partial class frmAllocateNhapTra : DevExpress.XtraEditors.XtraForm
    {
        public frmAllocateNhapTra()
        {
            InitializeComponent();
        }

        private void frmAllocateNhapTra_Load(object sender, EventArgs e)
        {

            try
            {
                LoadVTConLai();
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                lblTVT.Text = lblTongSo.Text + " : " + grvVatTu.RowCount.ToString(Commons.Modules.sSoLeSL) + " " + grvVatTu.Columns["MS_PT"].Caption.ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgLoadFormKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LoadVTConLai()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_FOR_ALLOCATED"));
                dtTmp.Columns["SL_TRA"].ReadOnly = false;
                dtTmp.Columns["SL_TRA"].AllowDBNull = true;
                if (grvVatTu.Columns.Count > 0)
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdVatTu, grvVatTu, dtTmp, false, false, false, true);
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdVatTu, grvVatTu, dtTmp, false, true, false, true);
                    grvVatTu.Columns[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvVatTu.Columns[1].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvVatTu.Columns[2].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvVatTu.Columns["MS_KHO"].Visible = false;
                    grvVatTu.Columns["SL_CL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grvVatTu.Columns["SL_CL"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeSL.ToString() + "}"; 

                    grvVatTu.Columns["SL_TRA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grvVatTu.Columns["SL_TRA"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeSL.ToString() + "}";

                    grvVatTu.Columns["DON_GIA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grvVatTu.Columns["DON_GIA"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeDG.ToString() + "}";

                    grvVatTu.Columns["TY_GIA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grvVatTu.Columns["TY_GIA"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeDG.ToString() + "}";

                    grvVatTu.Columns["TY_GIA_USD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grvVatTu.Columns["TY_GIA_USD"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeDG.ToString() + "}";
                    
                    grvVatTu.Columns["TEN_PT"].Width = 300;
                    grvVatTu.Columns["SL_CL"].Width = 80;
                    grvVatTu.Columns["SL_TRA"].Width = 80;
                }

                //grvVatTu.Columns["SL_TRA"].OptionsColumn.ReadOnly = false;
                for (int i = 0; i < grvVatTu.Columns.Count; i++)
                {
                    grvVatTu.Columns[i].OptionsColumn.ReadOnly = true;
                    grvVatTu.Columns["SL_TRA"].OptionsColumn.ReadOnly = false;
                }
                lblTVT.Text = lblTongSo.Text + " : " + grvVatTu.RowCount.ToString(Commons.Modules.sSoLeSL) + " " + grvVatTu.Columns["MS_PT"].Caption.ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgLoadVatTuKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ThemSua(false);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string sBT = "SYS_TRA_TMP" + Commons.Modules.UserName;
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdVatTu.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = " ISNULL(SL_TRA,0) > 0 ";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0 )
            {
                ThemSua(true);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            System.Data.SqlClient.SqlTransaction tran;

            if (con.State == ConnectionState.Closed) con.Open();
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
            tran = con.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(tran, "INTEGRATION_INSERT_RETURN_ALLOCATED", sBT);                
                tran.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                LoadVTConLai();
                this.Cursor = Cursors.Default;
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgCapNhapKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                
                ThemSua(true);                
                return;
            }
            
            LoadVTConLai();
            this.Cursor = Cursors.Default;
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                "msgCapNhapThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ThemSua(true);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            ThemSua(true);
        }

        private void ThemSua(Boolean bVi)
        {
            btnSua.Visible = bVi;
            btnExit.Visible = bVi;
            btnGhi.Visible = !bVi;
            btnKhong.Visible = !bVi;

            grvVatTu.OptionsBehavior.Editable = !bVi;
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)grdVatTu.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " OR MS_DH_XUAT_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR MS_DH_NHAP_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR MS_PT_NCC LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR QUY_CACH LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR MS_KHO LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR TEN_KHO LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
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

        private void grvVatTu_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (!btnGhi.Visible) return;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view.FocusedColumn.FieldName == "SL_TRA")
            {
                
                Double dSCL = 0;
                Double dSTra = 0;
                try
                {
                    Double.TryParse(grvVatTu.GetFocusedRowCellValue("SL_CL").ToString(), out dSCL);
                }
                catch { }
                try
                {
                    Double.TryParse(e.Value.ToString(), out dSTra);
                }
                catch { }
                if (dSTra > dSCL)
                {
                    e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                "msgSLTraLonHonSLConLai", Commons.Modules.TypeLanguage);
                    e.Valid = false;
                }
                if (e.Value.ToString().Trim() == "")
                    e.Value = DBNull.Value;
            }
        }


    }
}