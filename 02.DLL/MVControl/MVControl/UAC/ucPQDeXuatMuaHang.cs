using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace MVControl.UAC
{
    
    public partial class ucPQDeXuatMuaHang : DevExpress.XtraEditors.XtraUserControl
    {
        public string sTenLoaiForm;
        public ucPQDeXuatMuaHang()
        {
            sTenLoaiForm = Commons.Modules.SQLString;
            InitializeComponent();
        }

        public void TaoLuoi(DevExpress.XtraGrid.GridControl grd,DevExpress.XtraGrid.Views.Grid.GridView grv, string UserName)
        {
            DataTable dtTmp = new DataTable();
            string sDLieuForm = "";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetDsCotVis", sTenLoaiForm, UserName));

            if (dtTmp.Rows.Count > 0)
            {
                sDLieuForm = Convert.ToString(dtTmp.Rows[0]["COL_VIS"].ToString());
            }

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetDsFormVis", sTenLoaiForm));
            if (dtTmp.Rows.Count <= 0) return;

            string sIDFormGoc,sBTam ,sBCao= "";
            sBTam = "AAA_PQ_VIS" + Commons.Modules.UserName;

            sIDFormGoc = "";
            if (dtTmp.Rows.Count > 0)
                sIDFormGoc = Convert.ToString(dtTmp.Rows[0]["ID_GOC"].ToString());

            string sStmp = Convert.ToString(dtTmp.Rows[0]["COL_LUOI"].ToString());
            string[] chuoi_tach = sStmp.Split(new Char[] { ',' });
            int i = 1;
            sBCao = "";
            foreach (string s in chuoi_tach)
            {
                sBCao = sBCao + (sBCao == "" ? "" : " UNION ") + "SELECT CONVERT(BIT,1) AS CHON , " +
                    " CONVERT(NVARCHAR(500),N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    sIDFormGoc, s.ToString().Trim(), Commons.Modules.TypeLanguage) + "') AS TEN , " +
                    " N'" + s.ToString().Trim() + "' AS MA_SO, " + " CONVERT(INT," + i.ToString() + ") AS STT " +
                    (sBCao == "" ? " INTO " + sBTam : "");
                i++;
            }

            Commons.Modules.ObjSystems.XoaTable(sBTam);
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sBCao);

            string StMP;

            dtTmp = new DataTable();
            if (sDLieuForm == "")       {}         
            else
            {
                if (sDLieuForm == "ALL") { }
                else
                {
                    StMP = " '" + sDLieuForm.Replace("@", "','");

                    sBCao = " UPDATE " + sBTam + " SET CHON = 0 WHERE MA_SO IN (" + StMP.Substring(0, StMP.Length - 2) + ")";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sBCao);
                }
            }

            sBCao = "SELECT  CHON, TEN,MA_SO,STT FROM " + sBTam + " ORDER BY STT";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sBCao));

            dtTmp.Columns["CHON"].ReadOnly = false;
            dtTmp.Columns["TEN"].ReadOnly = true;
            dtTmp.Columns["MA_SO"].ReadOnly = true;
            dtTmp.Columns["STT"].ReadOnly = true;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grd, grv, dtTmp, false, true, true, true);
            grv.Columns["STT"].Visible = false;
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

        }
        
        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
                view.UpdateCurrentRow();
            }

        }

        private void ucPQDeXuatMuaHang_Load(object sender, EventArgs e)
        {
            //sTenLoaiForm = "ucPQDeXuatMuaHang";
            
            LockControl(true);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboUser, "GetUSERS", "USERNAME", "FULL_NAME", lblUser.Text, true);
            Commons.Modules.ObjSystems.ThayDoiNN(this.ParentForm);
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            if (cboUser.EditValue.ToString() == "") return;
            TaoLuoi(grdData, grvData, cboUser.EditValue.ToString());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
        }

        private void btnGhi_Click(object sender, EventArgs e)
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
                    sLuoiChon += dtTmp.Rows[i][2].ToString() + "@";

                }
            }
            else sLuoiChon = "ALL";

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "MAddUserFormVisble", sTenLoaiForm, cboUser.EditValue, sLuoiChon);
            TaoLuoi(grdData, grvData, cboUser.EditValue.ToString());

            LockControl(true);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            LockControl(true);
            TaoLuoi(grdData, grvData, cboUser.EditValue.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sTenLoaiForm, "CoMuonXoa",
                Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "MDeleteUserFormVisble", sTenLoaiForm, cboUser.EditValue);
            TaoLuoi(grdData, grvData, cboUser.EditValue.ToString());
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvData);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvData);
        }

    }


}
