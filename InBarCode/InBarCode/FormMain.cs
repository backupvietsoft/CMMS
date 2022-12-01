using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Microsoft.ApplicationBlocks.Data;

namespace InBarCode
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }
        string ConnectionString = "";
        private void Getconnect()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\vsconfig.xml");
            //string s = ds.Tables[0].Rows[0]["D"].ToString();
            string s = "CMMS_SHISEIDO";
            ConnectionString = "Server=" + ds.Tables[0].Rows[0]["S"].ToString() + ";database=" + s + ";uid=" + ds.Tables[0].Rows[0]["U"].ToString() + ";pwd=" + ds.Tables[0].Rows[0]["P"].ToString() + ";Connect Timeout=9999;";
        }
        private void btn_ThucHien_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = ((DataTable)grdChung.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = "CHON = TRUE";
            if (dtTmp.DefaultView.ToTable().Rows.Count == 0)
            {
                XtraMessageBox.Show("Xin vui lòng chọn máy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (rdo_LoaiCode.SelectedIndex)
            {
                case 0:
                case 1:
                    {
                        rptThietBi report = new rptThietBi(dtTmp.DefaultView.ToTable(), rdo_LoaiCode.SelectedIndex);
                        report.ShowPreview();
                        break;
                    }
                case 2:
                    {
                        rptVTPT report = new rptVTPT(dtTmp.DefaultView.ToTable());
                        report.ShowPreview();
                        break;
                    }
                default:
                    break;
            }
 
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            Getconnect();
            LoadNX();
            LoadDC();
            LoadBPChiuPhi();
            LoadLoaiMay();
            LoadNhomMay("-1");
            LoadMay();

        }
        #region Load form
        private void LoadNX()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(ConnectionString, "GetNhaXuongTreeList", true, "ADMIN", 0));
                treeListLK_DD.Properties.DataSource = dt;
                treeListLK_DD.Properties.DisplayMember = "TEN_N_XUONG";
                treeListLK_DD.Properties.ValueMember = "MS_N_XUONG";

                treeListLK_DD.Properties.TreeList.KeyFieldName = "MS_N_XUONG";
                treeListLK_DD.Properties.TreeList.ParentFieldName = "MS_CHA";
                treeListLK_DD.Properties.TreeList.RootValue = DBNull.Value;

                //Hide the key columns. An end-user can access them from the Customization Form. 
                //treeListLK_DC.Properties.TreeList.Columns["MS_CHA"].Visible = false;
                //treeListLK_DC.Properties.TreeList.Columns["MS_N_XUONG"].Visible = false;

                treeListLK_DD.EditValue = "-1";
            }
            catch
            {
            }
        }
        private void LoadDC()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(ConnectionString, "GetHeThongTreeListAll", true, "ADMIN", 0));
                treeListLK_DC.Properties.DataSource = dt;
                treeListLK_DC.Properties.DisplayMember = "TEN_HE_THONG";
                treeListLK_DC.Properties.ValueMember = "MS_HE_THONG";

                treeListLK_DC.Properties.TreeList.KeyFieldName = "MS_HE_THONG";
                treeListLK_DC.Properties.TreeList.ParentFieldName = "MS_CHA";
                treeListLK_DC.Properties.TreeList.RootValue = DBNull.Value;
                treeListLK_DC.Properties.TreeList.Columns["STT"].Visible = false;
                treeListLK_DC.EditValue = -1;
            }
            catch
            {
            }
        }
        private void LoadBPChiuPhi()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, "SELECT MS_BP_CHIU_PHI , TEN_BP_CHIU_PHI  FROM BO_PHAN_CHIU_PHI UNION SELECT '-1',' < ALL > ' ORDER BY TEN_BP_CHIU_PHI"));
                lookkup_BPCP.Properties.DataSource = dt;
                lookkup_BPCP.Properties.DisplayMember = "TEN_BP_CHIU_PHI";
                lookkup_BPCP.Properties.ValueMember = "MS_BP_CHIU_PHI";
                lookkup_BPCP.EditValue = -1;
            }
            catch
            {
            }
        }
        private void LoadLoaiMay()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(ConnectionString, "GetLoaiMayAll", 1, "ADMIN", 0));
                lookup_LTB.Properties.DataSource = dt;
                lookup_LTB.Properties.DisplayMember = "TEN_LOAI_MAY";
                lookup_LTB.Properties.ValueMember = "MS_LOAI_MAY";
                lookup_LTB.EditValue = "-1";
            }
            catch
            {
            }
        }
        private void LoadNhomMay(string sMSLM)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(ConnectionString, "GetNhomMayAll", 1, sMSLM, "ADMIN", 0));
                lookup_NTB.Properties.DataSource = dt;
                lookup_NTB.Properties.DisplayMember = "TEN_NHOM_MAY";
                lookup_NTB.Properties.ValueMember = "MS_NHOM_MAY";
                lookup_NTB.EditValue = "-1";
            }
            catch
            {
            }
        }
        private void LoadMay()
        {
            if (treeListLK_DD.EditValue == "" || treeListLK_DD.EditValue == null) return;
            if (treeListLK_DC.EditValue == "" || treeListLK_DC.EditValue == null) return;
            if (lookkup_BPCP.EditValue == "" || lookup_LTB.EditValue == null) return;
            if (lookup_LTB.EditValue == "" || lookup_LTB.EditValue == null) return;
            if (lookup_NTB.EditValue == "" || lookup_NTB.EditValue == null) return;
            Cursor.Current = Cursors.WaitCursor;

            DataTable dtMay = new DataTable();
            dtMay.Load(SqlHelper.ExecuteReader(ConnectionString, "spInQRCodeMay", treeListLK_DD.EditValue, treeListLK_DC.EditValue, lookkup_BPCP.EditValue, lookup_LTB.EditValue, lookup_NTB.EditValue, "-1", DateTime.Now,0));
            System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
            newColumn.DefaultValue = "0";
            dtMay.Columns.Add(newColumn);
            newColumn.SetOrdinal(0);
            dtMay.Columns["CHON"].ReadOnly = false;
            dtMay.Columns["MS_MAY"].ReadOnly = true;
            dtMay.Columns["TEN_MAY"].ReadOnly = true;
            dtMay.Columns["TEN_NHOM_MAY"].ReadOnly = true;
            dtMay.Columns["TEN_LOAI_MAY"].ReadOnly = true;
            dtMay.Columns["TEN_HE_THONG"].ReadOnly = true;
            dtMay.Columns["Ten_N_XUONG"].ReadOnly = true;
            dtMay.Columns["TEN_BP_CHIU_PHI"].ReadOnly = true;
            grdChung.DataSource = dtMay;
            grvChung.PopulateColumns();

            grvChung.Columns["MS_MAY"].Caption = "Mã máy";
            grvChung.Columns["TEN_MAY"].Caption = "Tên máy";
            grvChung.Columns["TEN_NHOM_MAY"].Caption = "Nhóm máy";
            grvChung.Columns["TEN_LOAI_MAY"].Caption = "Loại máy";
            grvChung.Columns["TEN_HE_THONG"].Caption = "Hệ thống";
            grvChung.Columns["Ten_N_XUONG"].Caption = "Nhà xưởng";
            grvChung.Columns["TEN_BP_CHIU_PHI"].Caption = "Bộ phận chịu phí";

            grvChung.Columns["MS_MAY"].VisibleIndex = 1;
            grvChung.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvChung.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grvChung.OptionsSelection.CheckBoxSelectorField = "CHON";
            grvChung.Columns["CHON"].Visible = false;
            Cursor.Current = Cursors.Default;
        }

        private void LoadTaiSan()
        {
            if (treeListLK_DD.EditValue == "" || treeListLK_DD.EditValue == null) return;
            if (treeListLK_DC.EditValue == "" || treeListLK_DC.EditValue == null) return;
            if (lookkup_BPCP.EditValue == "" || lookup_LTB.EditValue == null) return;
            if (lookup_LTB.EditValue == "" || lookup_LTB.EditValue == null) return;
            if (lookup_NTB.EditValue == "" || lookup_NTB.EditValue == null) return;
            Cursor.Current = Cursors.WaitCursor;

            DataTable dtMay = new DataTable();
            dtMay.Load(SqlHelper.ExecuteReader(ConnectionString, "spInQRCodeMay", treeListLK_DD.EditValue, treeListLK_DC.EditValue, lookkup_BPCP.EditValue, lookup_LTB.EditValue, lookup_NTB.EditValue, "-1", DateTime.Now, 1));
            System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
            newColumn.DefaultValue = "0";
            dtMay.Columns.Add(newColumn);
            newColumn.SetOrdinal(0);
            dtMay.Columns["CHON"].ReadOnly = false;
            dtMay.Columns["MS_TS"].ReadOnly = true;
            dtMay.Columns["TEN_MAY"].ReadOnly = true;
            dtMay.Columns["TEN_NHOM_MAY"].ReadOnly = true;
            dtMay.Columns["TEN_LOAI_MAY"].ReadOnly = true;
            dtMay.Columns["TEN_HE_THONG"].ReadOnly = true;
            dtMay.Columns["Ten_N_XUONG"].ReadOnly = true;
            grdChung.DataSource = dtMay;
            grvChung.PopulateColumns();

            grvChung.Columns["MS_TS"].Caption = "Mã tài sản";
            grvChung.Columns["TEN_MAY"].Caption = "Tên tài sản";
            grvChung.Columns["TEN_NHOM_MAY"].Caption = "Nhóm máy";
            grvChung.Columns["TEN_LOAI_MAY"].Caption = "Loại máy";
            grvChung.Columns["TEN_HE_THONG"].Caption = "Hệ thống";
            grvChung.Columns["Ten_N_XUONG"].Caption = "Nhà xưởng";
            grvChung.Columns["TEN_BP_CHIU_PHI"].Caption = "Bộ phận chịu phí";

            grvChung.Columns["MS_TS"].VisibleIndex = 1;
            grvChung.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvChung.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grvChung.OptionsSelection.CheckBoxSelectorField = "CHON";
            grvChung.Columns["CHON"].Visible = false;
            Cursor.Current = Cursors.Default;
        }
        private void LoadVTPT()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dtMay = new DataTable();
            dtMay.Load(SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, "SELECT A.MS_PT,A.TEN_PT,CONVERT(DATE,A.NGAY_INSERT_PT) AS NGAY,B.TEN_VI_TRI,C.TEN_KHO,A.TON_TOI_THIEU AS [MIN] FROM dbo.IC_PHU_TUNG A INNER JOIN   dbo.VI_TRI_KHO B ON A.MS_KHO = B.MS_KHO AND B.MS_VI_TRI = A.MS_VI_TRI INNER JOIN dbo.IC_KHO C ON C.MS_KHO = B.MS_KHO WHERE A.THEO_KHO = 0 UNION SELECT A.MS_PT, A.TEN_PT, CONVERT(DATE, ISNULL(A.NGAY_INSERT_PT, A.NGAY_UPDATE_PT)) AS NGAY, D.TEN_VI_TRI, C.TEN_KHO, B.TON_TOI_THIEU AS[MIN] FROM dbo.IC_PHU_TUNG A INNER JOIN dbo.IC_PHU_TUNG_KHO B ON B.MS_PT = A.MS_PT INNER JOIN dbo.IC_KHO C ON C.MS_KHO = B.MS_KHO INNER JOIN dbo.VI_TRI_KHO D ON D.MS_VI_TRI = B.MS_VI_TRI AND D.MS_VI_TRI = B.MS_VI_TRI WHERE A.THEO_KHO = 1 ORDER BY A.MS_PT"));
            System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
            newColumn.DefaultValue = "0";
            dtMay.Columns.Add(newColumn);
            newColumn.SetOrdinal(0);
            dtMay.Columns["CHON"].ReadOnly = false;
            dtMay.Columns["MS_PT"].ReadOnly = true;
            dtMay.Columns["TEN_PT"].ReadOnly = true;
            dtMay.Columns["NGAY"].ReadOnly = false;
            dtMay.Columns["MIN"].ReadOnly = true;
            dtMay.Columns["TEN_VI_TRI"].ReadOnly = true;
            grdChung.DataSource = dtMay;
            grvChung.PopulateColumns();

            grvChung.Columns["MS_PT"].Caption = "Mã PT";
            grvChung.Columns["TEN_PT"].Caption = "Tên PT";
            grvChung.Columns["NGAY"].Caption = "Ngày nhập";
            grvChung.Columns["MIN"].Caption = "Tồn tối thiểu";
            grvChung.Columns["TEN_VI_TRI"].Caption = "Vị trí";


            grvChung.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvChung.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grvChung.OptionsSelection.CheckBoxSelectorField = "CHON";
            grvChung.Columns["CHON"].Visible = false;
            Cursor.Current = Cursors.Default;
        }
        #endregion

        private void lookup_LTB_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay(lookup_LTB.EditValue.ToString());
            rdo_LoaiCode_SelectedIndexChanged(null, null);
        }

        private void lookup_NTB_EditValueChanged(object sender, EventArgs e)
        {
            rdo_LoaiCode_SelectedIndexChanged(null, null);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dl = XtraMessageBox.Show("Bạn có muốn thoát chương trình!", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void readonlyControl(bool readol)
        {
            treeListLK_DD.Properties.ReadOnly = readol;
            treeListLK_DC.Properties.ReadOnly = readol;
            lookkup_BPCP.Properties.ReadOnly = readol;
            lookup_LTB.Properties.ReadOnly = readol;
            lookup_NTB.Properties.ReadOnly = readol;
        }


        private void rdo_LoaiCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdo_LoaiCode.SelectedIndex)
            {
                case 0:
                    {
                        readonlyControl(false);
                        LoadMay(); break;
                    }
                case 1:
                    {
                        readonlyControl(false);
                        LoadTaiSan();
                        break;
                    }
                case 2:
                    {
                        readonlyControl(true);
                        LoadVTPT(); break;
                    }
                default:
                    break;
            }
        }

      
    }
}