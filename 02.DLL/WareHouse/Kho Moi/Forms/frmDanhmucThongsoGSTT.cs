using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WareHouse
{
    public partial class frmDanhmucThongsoGSTT : DevExpress.XtraEditors.XtraForm
    {
        //Member Class

        // Khai báo biến 
        private bool blnThem;
        private int ID = 0;
        private string MS_KH_TMP = "";
        private string SQL_TMP = "";
        private SqlDataReader dtReader;
        private bool flag = true;
        private bool flag1 = true;
        private bool flagGhi = false;
        private int rowcount = 0;
        private bool Dinhtinh_TM;
        private int row;
        private string MS_TS_GSTT_TM_s;
        private int MS_BP;
        DataTable TBGiaTri = new DataTable();
        DataTable TBThongso = new DataTable();
        BindingSource BindingSour = new BindingSource();
        private string strDuongDan = "";
        private string strPath_DH = "";

        public frmDanhmucThongsoGSTT()
        {
            InitializeComponent();
        }

        private void frmDanhmucThongsoGSTT_Load(object sender, EventArgs e)
        {
            LockData(true);
            VisibleButton(true);
            VisibleButton1(false);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            rdDinhluong.Visible = true;
            rdDinhtinh.Visible = true;
            LoadMS_BP_GSTT();
            Load_cboDonvido();
            LoadLocMS_BP_GSTT();
            LoadcbodonvidoLoc();
            BindData();
            InitData();

            lblChonTenbophan.Visible = true;
            cboLoctenbophan.Visible = true;
            lblDonvido_loc.Visible = false;
            cboDonvido_loc.Visible = false;

        }

        public void Load_cboDonvido()
        {
            Vietsoft.SqlInfo SqlGSTT = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable dt = new DataTable();
            dt.Load(SqlGSTT.ExecuteReader(CommandType.StoredProcedure, "GetDON_VI_DOs"));
            DataRow dtRow = null;
            dtRow = dt.NewRow();
            dtRow["MS_DV_DO"] = 0;
            dtRow["TEN_DV_DO"] = "";
            dt.Rows.InsertAt(dtRow, 0);

            cboDonvido.ValueMember = "MS_DV_DO";
            cboDonvido.DisplayMember = "TEN_DV_DO";

            cboDonvido.DataSource = dt;
        }
        public void LoadMS_BP_GSTT()
        {
            Vietsoft.SqlInfo SqlGSTT = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            
            DataTable dt = new DataTable();
            dt.Load(SqlGSTT.ExecuteReader(CommandType.StoredProcedure, "GetBO_PHAN_GSTT_NGON_NGUs", Commons.Modules.TypeLanguage));

            cboMS_BP_GSTT.ValueMember = "MS_BP_GSTT";
            cboMS_BP_GSTT.DisplayMember = "TEN_BP_GSTT";

            cboMS_BP_GSTT.DataSource = dt;
        }
        public void LoadLocMS_BP_GSTT()
        {
            Vietsoft.SqlInfo SqlGSTT = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable dt = new DataTable();
            dt.Load(SqlGSTT.ExecuteReader(CommandType.StoredProcedure, "GetTHONG_SO_GSTT_MS_BP_GSTT_NGON_NGUs", Commons.Modules.TypeLanguage));
            DataRow dtRow = null;
            dtRow = dt.NewRow();
            dtRow["MS_BP_GSTT"] = -1;
            dtRow["TEN_BP_GSTT"] = "<All>";
            dt.Rows.InsertAt(dtRow, 0);
            cboLoctenbophan.ValueMember = "MS_BP_GSTT";
            cboLoctenbophan.DisplayMember = "TEN_BP_GSTT";
            cboLoctenbophan.DataSource = dt;
        }
        public void LoadcbodonvidoLoc()
        {
            Vietsoft.SqlInfo SqlGSTT = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable dt = new DataTable();
            dt.Load(SqlGSTT.ExecuteReader(CommandType.StoredProcedure, "GetTHONG_SO_GSTT_MS_DV_DO"));
            DataRow dtRow = null;
            dtRow = dt.NewRow();
            dtRow["MS_DV_DO"] = -1;
            dtRow["TEN_DV_DO"] = "<All>";
            dt.Rows.InsertAt(dtRow, 0);
            cboDonvido_loc.DisplayMember = "TEN_DV_DO";
            cboDonvido_loc.ValueMember = "MS_DV_DO";
            cboDonvido_loc.DataSource = dt;
        }

        public void BindData()
        {
            Vietsoft.SqlInfo SqlGSTT = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

            TBThongso = new DataTable();
            if (rdDinhtinh.Checked)
            {
                if (cboLoctenbophan.SelectedIndex == 0)
                {
                    TBThongso.Load(SqlGSTT.ExecuteReader(CommandType.StoredProcedure, "GetTHONG_SO_GSTTs",Commons.Modules.TypeLanguage, 1));
                }
                else
                {
                    TBThongso.Load(SqlGSTT.ExecuteReader(CommandType.StoredProcedure, "GetTHONG_SO_GSTTs_Theo_MS_BP_GSTT", Commons.Modules.TypeLanguage, cboLoctenbophan.SelectedValue));
                }
            }
            else
            {
                if (cboDonvido_loc.SelectedValue.ToString() == "-1")
                {
                    TBThongso.Load(SqlGSTT.ExecuteReader(CommandType.StoredProcedure, "GetTHONG_SO_GSTTs", Commons.Modules.TypeLanguage, 0));
                }
                else
                {
                    TBThongso.Load(SqlGSTT.ExecuteReader(CommandType.StoredProcedure, "GetTHONG_SO_GSTTs_Theo_DON_VI_DO", Commons.Modules.TypeLanguage, cboDonvido_loc.SelectedValue));
                }
            }
            BindingSour = new BindingSource();
            BindingSour.DataSource = TBThongso;
            //grdDanhmucthongso.Columns.Add("MS_TS_GSTT", "DFDFD")
            //grdDanhmucthongso.Columns.Add("TEN_TS_GSTT", "DFDFDF")

            //grdDanhmucthongso.AutoGenerateColumns = False
            //grdDanhmucthongso.Columns("MS_TS_GSTT").DataPropertyName = "MS_TS_GSTT"
            //grdDanhmucthongso.Columns("TEN_TS_GSTT").DataPropertyName = "TEN_TS_GSTT"

            grdDanhmucthongso.DataSource = TBThongso;
            if (flag)
            {
                grdDanhmucthongso.Columns["MS_TS_GSTT"].Width = 150;
                grdDanhmucthongso.Columns["TEN_TS_GSTT"].Width = 350;
                grdDanhmucthongso.Columns["DUONG_DAN"].Width = 275;
                grdDanhmucthongso.Columns["MS_DV_DO"].Visible = false;
                grdDanhmucthongso.Columns["GHI_CHU"].Visible = false;
                grdDanhmucthongso.Columns["MS_BP_GSTT"].Visible = false;
                grdDanhmucthongso.Columns["TEN_BP_GSTT"].Visible = false;
                this.grdDanhmucthongso.Columns["TEN_DV_DO"].Visible = false;
                this.grdDanhmucthongso.Columns["LOAI_TS"].Visible = false;
                flag = false;
            }
            if (this.grdDanhmucthongso.RowCount > 0)
            {
                BtnSua.Enabled = true;
                BtnXoa.Enabled = true;
                BtnXoathongso.Enabled = true;
            }
            else
            {
                BtnSua.Enabled = false;
                BtnXoa.Enabled = false;
                BtnXoathongso.Enabled = false;
            }
            //If str_permission.Equals("Read only") Then
            //    EnableButton(False)
            //End If

            BindingSour.CurrentChanged += BindingSour_CurrentChanged;
            TBThongso.TableNewRow += TbDonDatHang_TableNewRow;

        }

        public void InitData()
        {
            cboDonvido.DataBindings.Clear();
            cboDonvido.DataBindings.Add("SelectedValue", BindingSour, "MS_DV_DO", true, DataSourceUpdateMode.OnPropertyChanged);
            cboMS_BP_GSTT.DataBindings.Clear();
            cboMS_BP_GSTT.DataBindings.Add("SelectedValue", BindingSour, "MS_BP_GSTT", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtMaso.DataBindings.Clear();
            TxtMaso.DataBindings.Add("Text", BindingSour, "MS_TS_GSTT", false, DataSourceUpdateMode.OnPropertyChanged);
            TxtTenthongso.DataBindings.Clear();
            TxtTenthongso.DataBindings.Add("Text", BindingSour, "TEN_TS_GSTT", false, DataSourceUpdateMode.OnPropertyChanged);
            txtGhichu.DataBindings.Clear();
            txtGhichu.DataBindings.Add("Text", BindingSour, "GHI_CHU", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDuongDan.DataBindings.Clear();
            txtDuongDan.DataBindings.Add("Text", BindingSour, "DUONG_DAN", false, DataSourceUpdateMode.OnPropertyChanged);
            chkDinhtinh.DataBindings.Clear();
            chkDinhtinh.DataBindings.Add("Checked", BindingSour, "LOAI_TS", false, DataSourceUpdateMode.OnPropertyChanged);


        }

        public void VisibleButton(bool blnVisible)
        {
            BtnThem.Visible = blnVisible;
            BtnSua.Visible = blnVisible;
            BtnThoat.Visible = true;
            BtnXoa.Visible = blnVisible;
            grdGiatrithongsoGSTT.ReadOnly = blnVisible;
            BtnGhi.Visible = !blnVisible;
            BtnKhongghi.Visible = !blnVisible;
        }

        public void VisibleButton1(bool blnVisible)
        {
            BtnTrove.Visible = blnVisible;
            BtnXoathongso.Visible = blnVisible;
            BtnXoagiatri.Visible = blnVisible;
            BtnXoathongso.Enabled = false;
            BtnXoagiatri.Enabled = true;
            BtnThem.Visible = !blnVisible;
            BtnSua.Visible = !blnVisible;
            BtnXoa.Visible = !blnVisible;
        }

        public void LockData(bool blnLock)
        {
            TxtMaso.ReadOnly = true;
            TxtTenthongso.ReadOnly = blnLock;
            txtGhichu.ReadOnly = blnLock;
            cboDonvido.Enabled = !blnLock;
            chkDinhtinh.Enabled = !blnLock;
            cboMS_BP_GSTT.Enabled = !blnLock;
            cboLoctenbophan.Enabled = blnLock;
            cboDonvido_loc.Enabled = blnLock;
            rdDinhluong.Enabled = blnLock;
            rdDinhtinh.Enabled = blnLock;
            //Me.grdDanhmucthongso.Enabled = blnLock
            txtDuongDan.ReadOnly = true;
            BtnDuongDan.Enabled = !blnLock;
            grdDanhmucthongso.ReadOnly = true;
            grdDanhmucthongso.Enabled = blnLock;
            grdGiatrithongsoGSTT.ReadOnly = !blnLock;
        }
        public void Refesh()
        {
            TxtTenthongso.Text = "";
            txtGhichu.Text = "";
            cboMS_BP_GSTT.SelectedIndex = -1;
            //cboDonvido.SelectedIndex = -1
            chkDinhtinh.Checked = rdDinhtinh.Checked;

            txtDuongDan.Text = "";

        }
        private void BindingSour_CurrentChanged(System.Object sender, EventArgs e)
        {
            
        }

        private void TbDonDatHang_TableNewRow(System.Object sender, DataTableNewRowEventArgs e)
        {
            Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            row = Int32.Parse(SqlDonDatHang.ExecuteScalar(CommandType.Text, "SELECT MAX(MS_TS_GSTT) FROM THONG_SO_GSTT").ToString());
            TxtMaso.Text = (row + 1).ToString();
            e.Row["MS_TS_GSTT"] = TxtMaso.Text;
            //e.Row["TEN_TS_GSTT"] = TxtTenthongso.Text;
            
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if ((BindingSour.Position >= 0) & grdDanhmucthongso.CurrentRow.Index > 0)
                {
                    ID = BindingSour.Position;
                }
                else
                {
                    ID = -1;
                }   
                LockData(true);
                VisibleButton(false);
                //BindingSour.AllowNew = true;
                //BindingSour.AddNew();
                TBThongso.NewRow();
                //Vietsoft.SqlInfo SqlDonDatHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                //row = Int32.Parse(SqlDonDatHang.ExecuteScalar(CommandType.Text, "SELECT MAX(MS_TS_GSTT) FROM THONG_SO_GSTT").ToString());
                //TxtMaso.Text = (row + 1).ToString();

                //grdDanhmucthongso.CurrentCell= grdDanhmucthongso.Rows[BindingSour.Count-1].Cells[0];
                LockData(false);
                Refesh();
            }
            catch (Exception ex)
            {
            }

        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                LockData(false);
                VisibleButton(false);
                if ((grdDanhmucthongso.Rows.Count > 0) & grdDanhmucthongso.CurrentRow.Index > 0)
                {
                    ID = grdDanhmucthongso.CurrentRow.Index;
                }
                else
                {
                    ID = -1;
                }

            }
            catch (Exception ex)
            {
            }

        }

        private void BtnXoagiatri_Click(object sender, EventArgs e)
        {

        }

        private void BtnXoathongso_Click(object sender, EventArgs e)
        {

        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                BindingSour.EndEdit();
                //save here

                LockData(true);
                VisibleButton(true);
                VisibleButton1(false);

            }
            catch (Exception ex)
            {
                //Finally
                //    BindingSour.RaiseListChangedEvents = True
                //    BindingSour.ResetBindings(False)
            }

        }

        private void BtnKhongghi_Click(object sender, EventArgs e)
        {
            try
            {
                BindingSour.RaiseListChangedEvents = true;
                grdDanhmucthongso.AllowUserToAddRows = false;
                LockData(true);
                VisibleButton(true);
                VisibleButton1(false);
                BindData();
                InitData();
                if (ID >= 0)
                {
                    grdDanhmucthongso.Rows[ID].Selected = true;
                    grdDanhmucthongso.CurrentCell = grdDanhmucthongso.Rows[ID].Cells[0];
                }
            }
            catch (Exception ex)
            {
                //Finally
                //    BindingSour.RaiseListChangedEvents = True
                //    BindingSour.ResetBindings(False)
            }

        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            VisibleButton1(true);

        }

        private void BtnTrove_Click(object sender, EventArgs e)
        {
            VisibleButton1(false);

        }

        private void cboDonvido_loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();

        }

        private void rdDinhtinh_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BindData();
                InitData();
                cboLoctenbophan.SelectedIndex = 0;
                cboDonvido_loc.SelectedIndex = 0;
                if (rdDinhtinh.Checked)
                {
                    lblChonTenbophan.Visible = true;
                    cboLoctenbophan.Visible = true;
                    lblDonvido_loc.Visible = false;
                    cboDonvido_loc.Visible = false;
                }
                else
                {
                    lblChonTenbophan.Visible = false;
                    cboLoctenbophan.Visible = false;
                    lblDonvido_loc.Visible = true;
                    cboDonvido_loc.Visible = true;
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void chkDinhtinh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDinhtinh.Checked)
            {
                //If flagGhi Then
                //    Addrow(True)
                //End If
                lblDonvido.Visible = false;
                cboDonvido.Visible = false;
                LblMS_BP_GSTT.Visible = true;
                cboMS_BP_GSTT.Visible = true;
            }
            else
            {
                //Addrow(False)
                LblMS_BP_GSTT.Visible = false;
                cboMS_BP_GSTT.Visible = false;
                lblDonvido.Visible = true;
                cboDonvido.Visible = true;
            }

        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

    }
}
