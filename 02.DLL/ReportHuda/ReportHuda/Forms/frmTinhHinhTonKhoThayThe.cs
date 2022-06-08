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
    public partial class frmTinhHinhTonKhoThayThe : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtLuoi;
        private string sMsPT;
        public string _sMsPT
        {
            get
            { return sMsPT; }
            set
            { sMsPT = value; }
        }
        public frmTinhHinhTonKhoThayThe()
        {
            InitializeComponent();
        }

        private void frmTinhHinhTonKhoThayThe_Load(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            #region Load Kho
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetKho", 1));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, dtTmp, "MS_KHO", "TEN_KHO", lblKho.Text);
            #endregion

            Commons.Modules.ObjSystems.ThayDoiNN(this);

            try
            {

                grvChung.Columns["MS_PT"].Width = 100;
                grvChung.Columns["MS_PT_CTY"].Width = 150;
                grvChung.Columns["TEN_PT"].Width = 150;
                grvChung.Columns["TEN_PT_VIET"].Width = 150;
                grvChung.Columns["MS_PT_NCC"].Width = 100;
                grvChung.Columns["QUY_CACH"].Width = 200;
                grvChung.Columns["TEN_CLASS"].Width = 80;
                grvChung.Columns["TON_TOI_THIEU"].Width = 80;
                grvChung.Columns["TON_KHO_MAX"].Width = 80;
                grvChung.Columns["TON_TT"].Width = 80;
                grvChung.Columns["SO_NGAY_DAT_MUA_HANG"].Width = 60;
                grvChung.Columns["DVT"].Width = 60;
                grvChung.Columns["TINH_TRANG"].Width = 90;
                grvChung.Columns["TT"].Visible = false;

                grvChung.Columns["TON_TOI_THIEU"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvChung.Columns["TON_TOI_THIEU"].DisplayFormat.FormatString = "{0:N2}";
                grvChung.Columns["TON_KHO_MAX"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvChung.Columns["TON_KHO_MAX"].DisplayFormat.FormatString = "{0:N2}";
                grvChung.Columns["TON_TT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvChung.Columns["TON_TT"].DisplayFormat.FormatString = "{0:N2}";
                grvChung.Columns["SO_NGAY_DAT_MUA_HANG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvChung.Columns["SO_NGAY_DAT_MUA_HANG"].DisplayFormat.FormatString = "{0:N0}";
                grvChung.Columns[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }
            catch { }
        }
        private void LoadData()
        {
            try
            {
                string Het, Thieu, VuaDu, Du;
                Het = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "HET", Commons.Modules.TypeLanguage);
                Thieu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "Thieu", Commons.Modules.TypeLanguage);
                VuaDu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "VuaDu", Commons.Modules.TypeLanguage);
                Du = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTinhHinhTonKho", "Du", Commons.Modules.TypeLanguage);

                dtLuoi = new DataTable();
                dtLuoi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetTinhHinhTonKhoThayThe", cboKho.EditValue,
                    Commons.Modules.TypeLanguage, Het, Thieu, VuaDu, Du, sMsPT));


                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtLuoi, false, false, false, false);


                Commons.Modules.SQLString = "0Load";
                chkHet.Checked = true;
                chkThieu.Checked = true;
                chkVuaDu.Checked = true;
                chkDu.Checked = true;
                Commons.Modules.SQLString = "";
                try
                {
                    lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmTinhHinhTonKho", "lblTSo", Commons.Modules.TypeLanguage) + " : " + grvChung.RowCount.ToString() + "   ";
                }
                catch { lblTVT.Text = ""; }



            }
            catch { }
            Commons.Modules.SQLString = "";
        }

        private void cboKho_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
            LocDK();
        }

        private void chkHet_CheckedChanged(object sender, EventArgs e)
        {
            LocDK();
        }

        private void chkThieu_CheckedChanged(object sender, EventArgs e)
        {
            LocDK();
        }

        private void chkVuaDu_CheckedChanged(object sender, EventArgs e)
        {
            LocDK();
        }

        private void chkDu_CheckedChanged(object sender, EventArgs e)
        {
            LocDK();
        }
        private void LocDK()
        {
            if (Commons.Modules.SQLString == "0Load") return;

            string sql = "";
            try
            {
                if (chkHet.Checked)
                {
                    sql += " OR TT = 0 ";
                }
                if (chkThieu.Checked)
                {
                    sql += " OR TT = 1 ";
                }
                if (chkVuaDu.Checked)
                {
                    sql += " OR TT = 2 ";
                }
                if (chkDu.Checked)
                {
                    sql += " OR TT = 3 ";
                }

                if (sql == "")
                    sql = " TT = -1";
                else
                    sql = sql.Substring(4, sql.Length - 4);

                sql = "( " + sql + ")";

                string dk = "";



                if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT_CTY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  QUY_CACH LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT_NCC LIKE '%" + txtTKiem.Text + "%' " + dk;

                if (dk.Length > 0) dk = "( " + dk.Substring(5, dk.Length - 5) + ")";
                
                //if (sql.Length > 0 && dk.Length <= 0)
                //    sql = sql;

                if (sql.Length <= 0 && dk.Length > 0)
                    sql = dk;

                if (sql.Length > 0 && dk.Length > 0)
                    sql = sql + " AND " + dk;

                if (sql.Length <= 0 && dk.Length <= 0)
                    sql = "";
            }
            catch { sql = ""; }
            dtLuoi.DefaultView.RowFilter = sql;
            try
            {
                lblTVT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTinhHinhTonKho", "lblTSo", Commons.Modules.TypeLanguage) + " : " + grvChung.RowCount.ToString() + "   ";
            }
            catch { lblTVT.Text = ""; }

        }

        private void grvChung_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in view.Columns)
                {
                    if (col.Name == "colTT")
                    {
                        if (e.RowHandle >= 0)
                        {
                            int TT;
                            TT = int.Parse(view.GetRowCellDisplayText(e.RowHandle, col));
                            switch (TT)
                            {
                                case 0:
                                    e.Appearance.BackColor = Color.Red;
                                    break;
                                case 1:
                                    e.Appearance.BackColor = Color.Yellow;
                                    if (view.FocusedRowHandle == e.RowHandle)
                                        e.Appearance.ForeColor = Color.Black;//BackColor = Color.Brown;
                                    break;
                                case 2:
                                    e.Appearance.BackColor = Color.FromArgb(0, 176, 80);
                                    break;
                                case 3:
                                    e.Appearance.BackColor = Color.FromArgb(155, 187, 89);
                                    break;
                            }
                        }
                    }

                }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LocDK();
        }

    }
}