using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Commons.VS.Classes.Catalogue;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;

namespace MVControl
{
    public partial class ucMonitoring : UserControl
    {
        public static string diaDiemID;
        public static string dayChuyenID;
        public static string loaiMayID;
        public static string mayID;
        public static string nhomMayID;

        public ucMonitoring()
        {
            InitializeComponent();
        }        

        public void SetValueForFilter(string _diaDiemID, string _dayChuyenID, string _loaiMayID, string _mayID, string _nhomMayID)
        {
            diaDiemID = _diaDiemID;
            dayChuyenID = _dayChuyenID;
            loaiMayID = _loaiMayID;
            mayID = _mayID;
            nhomMayID = _nhomMayID;
        }

        public ucMonitoring(string _diaDiemID, string _dayChuyenID, string _loaiMayID, string _mayID, string _nhomMayID)
        {            
            InitializeComponent();

            diaDiemID = _diaDiemID;
            dayChuyenID = _dayChuyenID;
            loaiMayID = _loaiMayID;
            mayID = _mayID;
            nhomMayID = _nhomMayID;

            dtFromDate.EditValue = DateTime.Now.AddYears(-7);
            dtToDate.EditValue = DateTime.Now.AddYears(2);
            LoadStaff();
        }
   
        public void LoadMonitoringByPlan()
        {
            SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Connection = conn;
            sqlcommand.CommandTimeout = 9999;
            sqlcommand.CommandText = "GetTSGS";
            SqlParameter[] param =
            {
                new SqlParameter("@username", Commons.Modules.UserName),
                new SqlParameter("@lang", Commons.Modules.TypeLanguage),
                new SqlParameter("@tuNgay", dtFromDate.DateTime.Date),
                new SqlParameter("@denNgay", dtToDate.DateTime.Date),
                new SqlParameter("@diaDiemID", diaDiemID),
                new SqlParameter("@dayChuyenID", dayChuyenID),
                new SqlParameter("@loaiMayID", loaiMayID),
                new SqlParameter("@nhomMayID", nhomMayID),
                new SqlParameter("@mayID", mayID)
            };
            sqlcommand.Parameters.AddRange(param);

            DataTable dt = new DataTable();
            dt.Load(sqlcommand.ExecuteReader());
            dt.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(gdMonitoring, gvMonitoring, dt, true, true, false, true, true, "frmGiamsattinhtrang");
           
            foreach (GridColumn col in gvMonitoring.Columns)
            {
                col.OptionsColumn.ReadOnly = true;
                col.OptionsColumn.AllowEdit = false;
            }

            gvMonitoring.OptionsBehavior.AutoExpandAllGroups = true;
            gvMonitoring.Columns["CHON"].Width = 70;
            gvMonitoring.Columns["CHON"].OptionsColumn.ReadOnly = false;
            gvMonitoring.Columns["CHON"].OptionsColumn.AllowEdit = true;
            gvMonitoring.Columns["MS_MAY"].Width = 100;
            gvMonitoring.Columns["TEN_MAY"].Width = 200;
            gvMonitoring.Columns["TEN_BO_PHAN"].Width = 150;
            gvMonitoring.Columns["STT_BP"].Visible = false;
            gvMonitoring.Columns["MS_TS_GSTT"].Visible = false;
            gvMonitoring.Columns["MS_BO_PHAN"].Visible = false;
            gvMonitoring.Columns["TEN_LOAI_MAY"].Visible = false;
            gvMonitoring.Columns["MS_TT"].Visible = false;
            gvMonitoring.Columns["NGAY_KT_CUOI"].Width = 70;
            gvMonitoring.Columns["NGAY_KT_KE"].Width = 70;
            OptionChanged();
        }
        
        private int Count()
        {
            try
            {
                (gdMonitoring.DataSource as DataTable).DefaultView.RowFilter = "CHON = TRUE";
                var tmp = (gdMonitoring.DataSource as DataTable).DefaultView.ToTable().Copy();
                return tmp.Rows.Count;
            }
            catch { return 0; }
        }

        private void LoadStaff()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", -1, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboStaff, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "");
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Count() == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKehoachtongthe_odd", "MsgVuiLongChon", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKehoachtongthe_odd", "frmKehoachtongthe_odd", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Count() > 20)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKehoachtongthe_odd", "MsgKhongDuocChonQua20ItemTrongMotPhieuGiamSat", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKehoachtongthe_odd", "frmKehoachtongthe_odd", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GIAM_SAT_TINH_TRANGController db = new GIAM_SAT_TINH_TRANGController();
                int ID = db.AddGIAM_SAT_TINH_TRANG_1(new GIAM_SAT_TINH_TRANGInfo()
                {
                    DEN_GIO = DateTime.Now.ToString("HH:mm"),
                    GIO_CHAY_MAY = 0,
                    GIO_KT = DateTime.Now.ToString("HH:mm"),
                    HOAN_THANH = 1,
                    MS_CONG_NHAN = cboStaff.EditValue.ToString(),
                    NGAY_KT = DateTime.Now.ToString(),
                    NGAY_KT_GOC = DateTime.Now,
                    NHAN_XET = "",
                    SO_PHIEU = Vietsoft.Information.GetID("CM"),
                    USERNAME = Commons.Modules.UserName
                });

                DataTable dt = gdMonitoring.DataSource as DataTable;
                dt.DefaultView.RowFilter = "CHON = TRUE";

                var tmp = dt.DefaultView.ToTable().Copy();
                tmp.AsEnumerable().ToList().ForEach(x =>
                {
                    new clsGIAM_SAT_TINH_TRANG_TSController().AddGIAM_SAT_TINH_TRANG_TS(
                     new clsGIAM_SAT_TINH_TRANG_TSInfo()
                     {
                         STT = ID,
                         MS_MAY = x["MS_MAY"].ToString(),
                         MS_TS_GSTT = x["MS_TS_GSTT"].ToString(),
                         MS_BO_PHAN = x["MS_BO_PHAN"].ToString(),                       
                         MS_TT = 1,
                         GIA_TRI_DO = "0",
                         //TG_XU_LY = Convert.ToDateTime("1900/01/01 00:00"),
                         //DD_NGAY = Convert.ToDateTime("1900/01/01 00:00"),
                         MS_CONG_NHAN = cboStaff.EditValue.ToString()
                     });
                });
                LoadMonitoringByPlan();
            }
            catch(Exception ex)
            { }
        }

        private void optGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvMonitoring.RowCount <= 0) return;
            foreach (GridColumn col in gvMonitoring.Columns)
            {
                col.UnGroup();
            }
            if (optGroup.SelectedIndex == 1)
            {
                gvMonitoring.Columns["MS_N_XUONG"].Group();
            }
            else if (optGroup.SelectedIndex == 2)
            {
                gvMonitoring.Columns["MS_MAY"].Group();
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            LoadMonitoringByPlan();
        }

        private void ucMonitoring_Load(object sender, EventArgs e)
        {
            dtFromDate.EditValue = DateTime.Now.AddYears(-2);
            dtToDate.EditValue = DateTime.Now;
            LoadStaff();
        }

        public void OptionChanged()
        {
            Action<object, EventArgs> obj = optGroup_SelectedIndexChanged;
            obj(null, null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            (ParentForm).Close();
            
        }

        private void btnDeselectedAll_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < gvMonitoring.RowCount)
            {
                gvMonitoring.SetRowCellValue(i, "CHON", false);
                gvMonitoring.UpdateCurrentRow();
                i++;
            }
        }

        private void btnSelectedAll_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i <= 20)
            {
                gvMonitoring.SetRowCellValue(i, "CHON", true);
                gvMonitoring.UpdateCurrentRow();
                i++;
            }
        }
    }
}
