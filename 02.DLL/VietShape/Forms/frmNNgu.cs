using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VietShape
{
    public partial class frmNNgu : DevExpress.XtraEditors.XtraForm
    {
        public string sForm = "frmDanhmuccongviec";
        public frmNNgu()
        {
            InitializeComponent();
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            TSua(false);
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            double iSTT = -1;
            string sBT = "NNGU_TMP" + Commons.Modules.UserName;
            try {
                ColumnView view = grdNhanLuc.FocusedView as ColumnView;
                view.CloseEditor();
                view.UpdateCurrentRow();

                view = grdNhanLuc.FocusedView as ColumnView;
                view.CloseEditor();
                view.UpdateCurrentRow();

                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdNhanLuc.DataSource; 
                

                dtTmp = dtTmp.DefaultView.ToTable();
                
                iSTT = Convert.ToDouble(grvNhanLuc.GetFocusedRowCellValue("STT").ToString());
                if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, dtTmp, ""))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTaoTableKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    return;
                }else
                {
                    String sSql = "UPDATE	dbo.LANGUAGES SET VIETNAM = T1.VIETNAM,ENGLISH=T1.ENGLISH,CHINESE=T1.CHINESE FROM " + sBT + " T1 INNER JOIN dbo.LANGUAGES T2 ON T1.STT = T2.STT AND T2.FORM = T1.FORM AND T2.KEYWORD = T1.KEYWORD WHERE T2.FORM = N'" +  sForm + "' ";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            LoadData(iSTT);
            TSua(true);
        }

        private void btnKhongghi_Click(object sender, EventArgs e)
        {
            LoadData(-1);
            TSua(true);
        }

        private void frmNNgu_Load(object sender, EventArgs e)
        {
            TSua(true);
            LoadData(-1);
            Commons.Modules.ObjSystems.ThayDoiNNNew(this);
        }
        private void TSua(bool bVi)
        {
            btnGhi.Visible = !bVi;
            btnKhongghi.Visible = !bVi;
            btnThemSua.Visible = bVi;
            btnThoat.Visible = bVi;
            grvNhanLuc.OptionsBehavior.Editable = !bVi;
        }
        private void LoadData(double iSTT)
        {
            try
            {
                string sSql = "SELECT STT, MS_MODULE, FORM, KEYWORD, VIETNAM, ENGLISH, CHINESE	 FROM dbo.LANGUAGES WHERE FORM = N'" + sForm + "' ORDER BY VIETNAM";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["STT"] };

                if (grdNhanLuc.DataSource == null)
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhanLuc, grvNhanLuc, dtTmp, false, true, true, true);
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhanLuc, grvNhanLuc, dtTmp, false, false, true, true);


                if (iSTT != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(iSTT));
                    grvNhanLuc.FocusedRowHandle = grvNhanLuc.GetRowHandle(index);
                }
                grvNhanLuc.Columns["KEYWORD"].OptionsColumn.ReadOnly = true;
                grvNhanLuc.Columns["MS_MODULE"].Visible = false;
                grvNhanLuc.Columns["STT"].Visible = false;
                grvNhanLuc.Columns["FORM"].Visible = false;
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            txtTKiem_EditValueChanging(null, null);
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdNhanLuc.DataSource;
            try
            {
                string dk = "";
                if (txtTKiem.Text.Length != 0) dk = " OR  KEYWORD LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  VIETNAM LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  ENGLISH LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  CHINESE LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }




    }
}
