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
    public partial class frmTimNhanVien : DevExpress.XtraEditors.XtraForm
    {
        GridView viewChung;
        Point ptChung;
        private string sMsNV;
        public string MsNVien { get { return sMsNV; } set { sMsNV = value; } }

        private string sMsDVi = "-1";
        public string MsDVi { get { return sMsDVi; } set { sMsDVi = value; } }

        private int iMsTo = -1;
        public int MsTo { get { return iMsTo; } set { iMsTo = value; } }

        private int iMsPBan = -1;
        public int MsPBan { get { return iMsPBan; } set { iMsPBan = value; } }

        private int iVaiTro = -1;
        public int VaiTro { get { return iVaiTro; } set { iVaiTro = value; } }


        public frmTimNhanVien()
        {
            InitializeComponent();
            txtTKiem.Focus();
        }

        private void LoadDonVi()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll", 1, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDVi, _table, "MS_DON_VI", "TEN_DON_VI","" );
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPhongBan(string MsDV )
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanUserAll", 1, MsDV, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPBan, _table, "MS_PB", "TEN_PB", "");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTo(string MsDv, int MsPB)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetToPBUserAll", 1, MsDv, MsPB,Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTo, dtTmp, "MS_TO1", "TEN_TO", lblTo.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTimNV(string MsDv, int MsPB, int MsTo)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTimNhanVienUser", MsTo, MsPB, MsDv, iVaiTro,Commons.Modules.UserName));
                for (int i = 0; i <= dtTmp.Columns.Count - 1; )
                {
                    dtTmp.Columns[i].ReadOnly = true;
                    i++;
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNVien, grvNVien, dtTmp, true, false, true, false);
                if (grvNVien.Columns["HO"].Visible == false) return;
                grvNVien.Columns["HO"].Visible = false;
                grvNVien.Columns["TEN"].Visible = false;
                grvNVien.Columns["TRINH_DO_VH"].Visible = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTimNhanVien_Load(object sender, EventArgs e)
        {
            //Commons.Modules.SQLString = "0LOAD";
            LoadDonVi();
            if (grvNVien.RowCount == 0) LoadTimNV("-1", -1, -1);
            Commons.Modules.ObjSystems.ThayDoiNN(this);

            if (sMsDVi != "-1") cboDVi.EditValue = sMsDVi;
            if (iMsPBan != -1) cboPBan.EditValue = iMsPBan;
            if (iMsTo != -1) cboTo.EditValue = iMsTo;
            txtTKiem.Focus();
        }

        private void cboDVi_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDVi.Text == "[EditValue is null]") return;
            if (cboDVi.Text == "") LoadPhongBan("-1"); else LoadPhongBan(cboDVi.EditValue.ToString());
        }

        private void cboPBan_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDVi.Text == "[EditValue is null]") return;
            if (cboPBan.Text == "[EditValue is null]") return;
            if (cboDVi.Text == "") LoadTo("-1", -1); else LoadTo(cboDVi.EditValue.ToString(), int.Parse(cboPBan.EditValue.ToString()));
        }

        private void cboTo_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDVi.Text == "[EditValue is null]") return;
            if (cboPBan.Text == "[EditValue is null]") return;
            if (cboTo.Text == "[EditValue is null]") return;
            LoadTimNV(cboDVi.EditValue.ToString(), int.Parse(cboPBan.EditValue.ToString()), int.Parse(cboTo.EditValue.ToString()));
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtNVien = new DataTable();
            dtNVien = (DataTable)grdNVien.DataSource;

            try
            {
                string dk = "";
                if (txtTKiem.Text.Length != 0) dk = " OR  HO LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  HO_TEN LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_CONG_NHAN LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtNVien.DefaultView.RowFilter = dk;
            }
            catch { dtNVien.DefaultView.RowFilter = ""; }
        }



        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvNVien.RefreshData();
        }


        private void DoRowDoubleClick(GridView view, Point pt)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            try
            {
                MsNVien = grvNVien.GetFocusedRowCellValue("MS_CONG_NHAN").ToString();
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grvNVien_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            try
            {
                MsNVien = grvNVien.GetFocusedRowCellValue("MS_CONG_NHAN").ToString();
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            try
            {
                MsNVien = "";
                this.Close();
            }
            catch (Exception ex)
            {
                MsNVien = "";
                this.Close();
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmTimNhanVien_Shown(object sender, EventArgs e)
        {
            txtTKiem.Focus();
        }

        private void txtTKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            btnExecute_Click(null, null);
        }
    }
}