
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;

namespace MVControl.Forms
{
    public partial class frmChonNhanSuChoPBT : DevExpress.XtraEditors.XtraForm
    {
        public string sBTNVien = "tmpNhanVien" + Commons.Modules.UserName;
        public frmChonNhanSuChoPBT()
        {
            InitializeComponent();
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            
            //if (grdNhanSu.DataSource != null)
            //{
            //    try
            //    {
            //        DataTable dt = new DataTable();
            //        dt = (((DataTable)grdNhanSu.DataSource).Copy());
            //        dt.DefaultView.RowFilter = "CHON = TRUE";
            //        dt = dt.DefaultView.ToTable();
            //        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTNVien, dt, "");
            //    }
            //    catch { }
            //}


            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadcboDON_VI()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDON_VI3, Commons.Modules.ObjSystems.MLoadDataDonVi(1), "MS_DON_VI", "TEN_DON_VI", "TEN_DON_VI");
        }
        public void LoadCboToPhongBan()
        {
            cboToPhongBan3.Properties.DataSource = null;
            if (cboDON_VI3.EditValue == null)
                return;
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboToPhongBan3, Commons.Modules.ObjSystems.MLoadDataPhongBan(1, cboDON_VI3.EditValue.ToString()), "MS_PB", "TEN_PB", "TEN_PB");
            }
            catch 
            {
            }
        }
        public void LoadTo()
        {
            cboTo3.Properties.DataSource = null;
            if (cboToPhongBan3.EditValue == null)
                return;
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTo3, Commons.Modules.ObjSystems.MLoadDataTo(1, cboDON_VI3.EditValue.ToString(), Convert.ToInt32(cboToPhongBan3.EditValue)), "MS_TO1", "TEN_TO", "TEN_TO");
            }
            catch 
            {
            }
        }

        public void BindData()
        {
            try
            {
                grdNhanSu.DataSource = null;
                grvNhanSu.Columns.Clear();
            }
            catch 
            {
            }
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN_PBT", cboDON_VI3.EditValue, cboToPhongBan3.EditValue, cboTo3.EditValue));
            dt.Columns["CHON"].ReadOnly = false;
            dt.Columns["MS_CONG_NHAN"].ReadOnly = true;
            dt.Columns["HO_TEN"].ReadOnly = true;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhanSu, grvNhanSu, dt, true, true, true, true, true, this.Name);
            grvNhanSu.Columns["TEN_TO"].Visible = false;
            grvNhanSu.Columns["THUE_NGOAI"].Visible = false;

        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = (DataTable)grdNhanSu.DataSource;
                string str = null;
                if (string.IsNullOrEmpty(txtTimKiem.Text))
                    str = "";
                else
                    str = " MS_CONG_NHAN like '%" + txtTimKiem.Text + "%' OR HO_TEN like '%" + txtTimKiem.Text + "%' ";
                dtTmp.DefaultView.RowFilter = str;
            }
            catch 
            {
                dtTmp.DefaultView.RowFilter = "";
            }
            dtTmp = dtTmp.DefaultView.ToTable();
        }

        private void frmChonNhanSuChoPBT_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            LoadcboDON_VI();
            LoadCboToPhongBan();
            LoadTo();
            Commons.Modules.SQLString = "";
            if (!string.IsNullOrEmpty(Commons.Modules.sDonViMacDinh))
            {
                cboDON_VI3.EditValue = Commons.Modules.sDonViMacDinh;
            }
            else
            {
                BindData();
            }
            string Str = null;
            try
            {
                Str = "drop table " + sBTNVien;
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Str);

            }
            catch 
            {
            }
            Str = "CREATE TABLE " + sBTNVien + " ( MS_CONG_NHAN NVARCHAR(9),HO_TEN NVARCHAR(80),THUE_NGOAI BIT)";
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Str);


            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void cboDON_VI3_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load")
                return;
            Commons.Modules.SQLString = "0Load";
            LoadCboToPhongBan();
            LoadTo();
            Commons.Modules.SQLString = "";
            BindData();
        }

        private void cboToPhongBan3_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load")
                return;
            Commons.Modules.SQLString = "0Load";
            LoadTo();
            Commons.Modules.SQLString = "";
            BindData();
        }

        private void cboTo3_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load")
                return;
            BindData();
        }


        private void grvNhanSu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string str = "";
            if (Convert.ToBoolean(grvNhanSu.GetDataRow(e.RowHandle)["CHON"].ToString()))
            {
                str = "INSERT INTO " + sBTNVien + " values(N'" + grvNhanSu.GetDataRow(e.RowHandle)["MS_CONG_NHAN"].ToString() + "',N'" + grvNhanSu.GetDataRow(e.RowHandle)["HO_TEN"].ToString().Replace("'", " ") + "'," + (grvNhanSu.GetDataRow(e.RowHandle)["THUE_NGOAI"].ToString() == "False" ? "0" : "1" ) + ")";


                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            else if (!Convert.ToBoolean(grvNhanSu.GetDataRow(e.RowHandle)["CHON"].ToString()))
            {
                str = "DELETE FROM " + sBTNVien + " WHERE MS_CONG_NHAN='" + grvNhanSu.GetDataRow(e.RowHandle)["MS_CONG_NHAN"].ToString() + "'";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
        }
       
    }
}