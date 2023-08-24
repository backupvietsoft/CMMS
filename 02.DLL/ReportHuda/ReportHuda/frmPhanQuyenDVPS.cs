using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportHuda
{
    public partial class frmPhanQuyenDVPS : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyenDVPS()
        {
            InitializeComponent();
        }

        private void frmPhanQuyenDVPS_Load(object sender, EventArgs e)
        {
            EnableButon(true);
            LoadCombo();
            LoadNhom();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void EnableButon(bool visible)
        {
            btnThem.Visible = visible;
            btnThoat.Visible = visible;
            btnGhi.Visible = !visible;
            btnKhong.Visible = !visible;

            cboUserDuyet.Properties.ReadOnly = visible;
            txtSoTien.Properties.ReadOnly = visible;

        }

        private void LoadCombo()
        {
            try
            {
                DataTable dt = new DataTable();
                Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboUserDuyet, "SELECT USERNAME,FULL_NAME FROM dbo.USERS WHERE ACTIVE = 1", "USERNAME", "FULL_NAME", "");
            }
            catch
            {
            }
        }

        private void LoadNhom()
        {
            try
            {

                DataTable dtTmp = new DataTable();
                //1 là nhóm
                grdNhom.DataSource = null;
                if (btnThem.Visible == true)
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT MS_DUYET,LOAI,TEN FROM DIEU_KIEN_DUYET_PSDV WHERE LOAI IN (1)"));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhom, grvNhom, dtTmp, false, true, true, true, true, Name);
                    grvNhom.Columns["MS_DUYET"].Visible = false;
                    grvNhom.Columns["LOAI"].Visible = false;

                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT MS_DUYET,LOAI,TEN FROM DIEU_KIEN_DUYET_PSDV WHERE LOAI IN (2)"));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhomMay, grvNhomMay, dtTmp, false, true, true, true, true, Name);
                    grvNhomMay.Columns["MS_DUYET"].Visible = false;
                    grvNhomMay.Columns["LOAI"].Visible = false;
                }
                else
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT CONVERT(BIT,CASE ISNULL(B.MS_DUYET,0) WHEN 0 THEN 0 ELSE 1 END) AS CHON , A.GROUP_ID MS_DUYET,1 LOAI, A.GROUP_NAME TEN FROM dbo.NHOM A LEFT JOIN DIEU_KIEN_DUYET_PSDV B ON A.GROUP_ID = B.MS_DUYET AND B.LOAI = 1 ORDER BY CHON DESC, A.GROUP_NAME"));

                    dtTmp.Columns["CHON"].ReadOnly = false;

                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhom, grvNhom, dtTmp, true, true, true, true, true, Name);
                    grvNhom.Columns["MS_DUYET"].Visible = false;
                    grvNhom.Columns["LOAI"].Visible = false;
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT CONVERT(BIT,CASE ISNULL(B.MS_DUYET,'') WHEN '' THEN 0 ELSE 1 END) AS CHON , A.MS_NHOM_MAY MS_DUYET,2 LOAI, A.TEN_NHOM_MAY TEN FROM dbo.NHOM_MAY A LEFT JOIN DIEU_KIEN_DUYET_PSDV B ON A.MS_NHOM_MAY = B.MS_DUYET AND B.LOAI = 2 ORDER BY CHON DESC, A.TEN_NHOM_MAY "));
                    dtTmp.Columns["CHON"].ReadOnly = false;
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhomMay, grvNhomMay, dtTmp, true, true, true, true, true, Name);
                    dtTmp.Columns["CHON"].ReadOnly = false;
                    grvNhomMay.Columns["MS_DUYET"].Visible = false;
                    grvNhomMay.Columns["LOAI"].Visible = false;


                }

                //load tiền và người
                txtSoTien.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 TEN FROM DIEU_KIEN_DUYET_PSDV WHERE LOAI = 3");
                cboUserDuyet.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 TEN FROM DIEU_KIEN_DUYET_PSDV WHERE LOAI = 4").ToString();
            }
            catch
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EnableButon(false);
            LoadNhom();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string sSql = "";
            string sBTNHOM = "sBTNHOM" + Commons.Modules.UserName;
            string sBTNHOMMay = "sBTNHOMMay" + Commons.Modules.UserName;

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTNHOM, (DataTable)grdNhom.DataSource, "");
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTNHOMMay, (DataTable)grdNhomMay.DataSource, "");
            sSql = "DELETE DIEU_KIEN_DUYET_PSDV INSERT INTO dbo.DIEU_KIEN_DUYET_PSDV(MS_DUYET,LOAI,TEN)SELECT CONVERT(NVARCHAR(10),MS_DUYET),LOAI,TEN FROM " + sBTNHOM + " WHERE CHON = 1 " +
             "UNION SELECT CONVERT(NVARCHAR(10), MS_DUYET),LOAI,TEN FROM " + sBTNHOMMay + " WHERE CHON = 1 " +
             "UNION SELECT 'TIEN',3,'" + txtSoTien.EditValue + "' " +
             "UNION SELECT 'Admin',4,'"+ cboUserDuyet.EditValue +"'";
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
            }
            catch 
            {
            }
            EnableButon(true);
            LoadNhom();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            EnableButon(true);
            LoadNhom();
        }
    }
}
