using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace MVControl
{
    public partial class ucVisibleColGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public string sTenForm;
        public string sControl;
        public ucVisibleColGrid()
        {
            sTenForm = Commons.Modules.SQLString;
            InitializeComponent();
        }



        public void TaoLuoi(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView grv, string UserName, string sControl)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                string sDLieuForm = "";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetDsCotVis", sTenForm, sControl, UserName));

                if (dtTmp.Rows.Count > 0)
                {
                    sDLieuForm = Convert.ToString(dtTmp.Rows[0]["COL_VIS"].ToString());
                }

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetDsFormVis", sTenForm, sControl));
                if (dtTmp.Rows.Count <= 0) return;

                string sBTam, sBCao = "";
                sBTam = "AAA_PQ_VIS" + Commons.Modules.UserName;

                string sStmp = Convert.ToString(dtTmp.Rows[0]["COL_LUOI"].ToString()).Trim ();
                string[] chuoi_tach = sStmp.Split(new Char[] { ',' });
                int i = 1;
                sBCao = "";
                foreach (string s in chuoi_tach)
                {
                    sBCao = sBCao + (sBCao == "" ? "" : " UNION ") + "SELECT CONVERT(BIT,1) AS CHON , " +
                        " CONVERT(NVARCHAR(500),N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        sTenForm, s.ToString().Trim(), Commons.Modules.TypeLanguage) + "') AS TEN , " +
                        " N'" + s.ToString().Trim() + "' AS MA_SO, " + " CONVERT(INT," + i.ToString() + ") AS STT " +
                        (sBCao == "" ? " INTO " + sBTam : "");
                    i++;
                }

                Commons.Modules.ObjSystems.XoaTable(sBTam);
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sBCao);

                string sTmp;

                dtTmp = new DataTable();
                if (sDLieuForm == "") { }
                else
                {
                    if (sDLieuForm == "ALL") { }
                    else
                    {
                        sTmp = " '" + sDLieuForm.Replace("@", "','");

                        sBCao = " UPDATE " + sBTam + " SET CHON = 0 WHERE MA_SO IN (" + sTmp.Substring(0, sTmp.Length - 2) + ")";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sBCao);
                    }
                }

                sBCao = "SELECT  CHON, TEN,MA_SO,STT FROM " + sBTam + " ORDER BY STT";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sBCao));
                dtTmp.Columns["CHON"].ReadOnly = false;
                dtTmp.Columns["TEN"].ReadOnly = true;
                dtTmp.Columns["MA_SO"].ReadOnly = true;
                dtTmp.Columns["STT"].ReadOnly = true;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grd, grv, dtTmp, false, false, true, false, true, this.ParentForm.ToString());
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                if (grv.Columns["STT"].Visible == false) return;
                grv.BestFitColumns();
                grv.Columns["CHON"].Width = 60;

                grv.Columns["STT"].Visible = false;
                grv.Columns["MA_SO"].Visible = false;
            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVisibleColGrid", "Loi Tao Luoi" ,
                     Commons.Modules.TypeLanguage), "");
            }
        }

        public void LockControl(Boolean bLock )
        {
            btnSua.Visible = bLock;
            btnThoat.Visible = bLock;
            btnXoa.Visible = bLock;

            btnGhi.Visible = !bLock;
            btnKhong.Visible = !bLock;

            btnALL.Visible = !bLock;
            btnNotALL.Visible = !bLock;

            grvData.OptionsBehavior.Editable = !bLock;
            cboUser.Properties.ReadOnly = !bLock;
            cboControl.Properties.ReadOnly = !bLock;

        }
        
        private void ucVisibleColGrid_Load(object sender, EventArgs e)
        {
            //sTenLoaiForm = "ucPQDeXuatMuaHang";
            try
            {
                LockControl(true);
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetControlVisible", sTenForm, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboControl, dtTmp, "ID_CONTROL", "TEN_CONTROL", lblControl.Text);
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboUser, "GetUSERS", "USERNAME", "FULL_NAME", lblUser.Text, true);
                Commons.Modules.ObjSystems.ThayDoiNN(this.ParentForm);
            }
            catch
            {}
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboUser.Text == "[EditValue is null]") return;
                if (cboUser.EditValue.ToString() == "") return;
                TaoLuoi(grdData, grvData, cboUser.EditValue.ToString(), cboControl.EditValue.ToString());
            }
            catch
            {}
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVisibleColGrid", "KhongCoDuLieu",
                    Commons.Modules.TypeLanguage), "");
                return;
            }
            LockControl(false);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                string sLuoiChon;

                DataTable dtTmp = new DataTable();
                sLuoiChon = "";
                dtTmp = ((DataTable)grdData.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = " CHON = 0";
                dtTmp = dtTmp.DefaultView.ToTable();

                if (dtTmp.Rows.Count != 0)
                {
                    for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                    {
                        sLuoiChon += dtTmp.Rows[i][2].ToString().Trim() + "@";

                    }
                }
                else sLuoiChon = "ALL";

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "MAddUserFormVisble", sTenForm, cboControl.EditValue, cboUser.EditValue, sLuoiChon);
                TaoLuoi(grdData, grvData, cboUser.EditValue.ToString(), cboUser.EditValue.ToString());

                LockControl(true);
            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVisibleColGrid", "Loi" + btnGhi.Text,
                     Commons.Modules.TypeLanguage), "");
            }
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            LockControl(true);
            TaoLuoi(grdData, grvData, cboUser.EditValue.ToString(), cboUser.EditValue.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.RowCount <= 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVisibleColGrid", "KhongCoDuLieu",
                        Commons.Modules.TypeLanguage), "");
                    return;
                }

                if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVisibleColGrid", "CoMuonXoa",
                    Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) == DialogResult.No) return;

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "MDeleteUserFormVisble", sTenForm, cboControl.EditValue, cboUser.EditValue);
                TaoLuoi(grdData, grvData, cboUser.EditValue.ToString(), cboControl.EditValue.ToString());
            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVisibleColGrid", "Loi" + btnXoa.Text,
                     Commons.Modules.TypeLanguage), "");
            }
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvData);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false,"CHON", grvData);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
