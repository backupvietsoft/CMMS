using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace ReportMain
{
    public partial class frmTimVTPT : DevExpress.XtraEditors.XtraForm
    {
        GridView viewChung;
        Point ptChung;
        public string sMsPT = "";
        public string sMsPTTraVe = "";
        private int iLoai = 1;
        public int iLoaiBC { get { return iLoai; } set { iLoai = value; } }
        //iLoaiBC = 1 la vat tu PHU TUNG THAY THE
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvVT);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvVT);
        }

        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvVT.RefreshData();
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            //if (grvVT.RowCount == 0)
            //{
            //    DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //    //MsMay = "";
            //    this.Close();
            //}
            //else
            //{
            //    DialogResult = System.Windows.Forms.DialogResult.OK;
            //    try
            //    {
            //        this.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void grvVT_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);

        }

        public frmTimVTPT()
        {
            InitializeComponent();
        }
        private void LoadLVT()
        { 
            DataTable dtTmp = new DataTable ();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_VAT_TU", Commons.Modules.TypeLanguage, Commons.Modules.UserName));
            DataRow drRow = dtTmp.NewRow();
            drRow["MS_LOAI_VT"] = "-1";
            drRow["TEN_LOAI_VT"] = " < ALL > ";
            dtTmp.Rows.Add(drRow);
            dtTmp.DefaultView.Sort = "TEN_LOAI_VT";
            dtTmp = dtTmp.DefaultView.ToTable();
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLVT, dtTmp, "MS_LOAI_VT", "TEN_LOAI_VT", lblLVT.Text);
        }

        private void frmTimVT_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLVT();
                if (iLoai == 1) LoadVatTu();
            }
            catch { }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void LoadVatTu()
        { 
            DataTable dtTmp = new DataTable ();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhuTungThayThe",sMsPT, 
                    Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            
            if (sMsPTTraVe != "" )
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "VT" + Commons.Modules.UserName, dtTmp, "");
                string sStr = "";
                sMsPTTraVe = "'" + sMsPTTraVe.Replace(",", "','") + "'";
                sStr = "UPDATE VT" + Commons.Modules.UserName + " SET CHON = 1 WHERE MS_PT IN (" + sMsPTTraVe + ") ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sStr);
                dtTmp = new DataTable();
                sStr = "SELECT * FROM VT" + Commons.Modules.UserName + " ORDER BY MS_PT, TEN_PT";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sStr));
            }
            dtTmp.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdVT, grvVT, dtTmp, true, false, false, true);
            for (int i = 1; i <= dtTmp.Columns.Count - 1; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            grvVT.Columns["CHON"].Width = 80;
            grvVT.Columns["MS_PT"].Width = 100;
            grvVT.Columns["TEN_PT"].Width = 250;
            grvVT.Columns["MS_PT_NCC"].Width = 100;
            grvVT.Columns["QUY_CACH"].Width = 200;
            grvVT.Columns["TEN_PT_VIET"].Width = 150;
            grvVT.Columns["TEN_HSX"].Width = 120;
            grvVT.Columns["TEN_DVT"].Width = 70;
            grvVT.Columns["TEN_LOAI_VT"].Width = 140;
            grvVT.Columns["TON_TOI_THIEU"].Width = 110;
            grvVT.Columns["TON_KHO_MAX"].Width = 110;
            grvVT.Columns["MS_PT_GOC"].Visible = false;
            grvVT.Columns["MS_LOAI_VT"].Visible = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void cboLVT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboLVT.Text == "") return;
                DataTable dtTmp = new DataTable();
                try
                {
                    dtTmp = (DataTable)grdVT.DataSource;
                    if (cboLVT.EditValue.ToString() == "-1")
                        dtTmp.DefaultView.RowFilter = "";
                    else
                        dtTmp.DefaultView.RowFilter = " MS_LOAI_VT = '" + cboLVT.EditValue.ToString() + "' ";
                }
                catch
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
            }
            catch { }
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataTable dtVT = new DataTable();
                dtVT = (DataTable)grdVT.DataSource;
                try
                {
                    string dk = "";
                    if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  QUY_CACH LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (txtTKiem.Text.Length != 0) dk = " OR  TEN_LOAI_VT LIKE '%" + txtTKiem.Text + "%' " + dk;
                    if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                    dtVT.DefaultView.RowFilter = dk;
                }
                catch { dtVT.DefaultView.RowFilter = ""; }
            }
            catch { }

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            LayDuLieu();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void LayDuLieu()
        {
            sMsPTTraVe = "";
            DataTable dtVT = new DataTable();
            dtVT = (DataTable)grdVT.DataSource;
            dtVT.DefaultView.RowFilter = "CHON = TRUE";
            dtVT = dtVT.DefaultView.ToTable();
            foreach (DataRow drRow in dtVT.Rows)
            {
                sMsPTTraVe += (sMsPTTraVe == "" ? "" : ",") + drRow["MS_PT"].ToString();
            }
 

        }


    }
}