using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace ImportExcels
{
    public partial class frmBoPhanChiuPhiRule : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtBPCP = new DataTable();
        private DataTable dtCost = new DataTable();
        private BindingSource BindingBPCP = new BindingSource();
        private BindingSource BindingCost = new BindingSource();

        public frmBoPhanChiuPhiRule()
        {
            InitializeComponent();
        }

        private void frmBoPhanChiuPhiRule_Load(object sender, EventArgs e)
        {
            AnHien(true);
            TaoDuLieu();
            LoadNN();
            if (Commons.Modules.PermisString.Equals("Read only"))
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;

            }
        }
        private void TaoDuLieu()
        {
            dtCost = new DataTable();
            //dtCost.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                //" SELECT A.MS_COSTCENTER, dbo.COSTCENTER.TEN_COSTCENTER AS TEN , A.TY_LE, A.MS_BP_CHIU_PHI " +
                //" FROM dbo.BO_PHAN_CHIU_PHI_RULE AS A INNER JOIN dbo.COSTCENTER ON " +
                //" A.MS_COSTCENTER = dbo.COSTCENTER.MS_COSTCENTER  "));

            dtCost.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT MS_COSTCENTER, MS_COSTCENTER AS TEN , TY_LE, MS_BP_CHIU_PHI " +
                " FROM dbo.BO_PHAN_CHIU_PHI_RULE ORDER BY MS_COSTCENTER "));

            DataTable tblChiPhi = new DataTable();
            foreach (DataColumn col in dtCost.Columns)
            {
                col.AllowDBNull = true;
            }
            //tblChiPhi.Columns["TEN"].ReadOnly = true;

            BindingCost = new BindingSource();
            BindingCost.DataSource = dtCost;
            
            tblChiPhi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, 
                        "SELECT LOAI_CHI_PHI,TEN_LOAI_CHI_PHI FROM LOAI_CHI_PHI ORDER BY TEN_LOAI_CHI_PHI"));
            lokChiPhi.Properties.DataSource = tblChiPhi;
            lokChiPhi.Properties.DisplayMember = "TEN_LOAI_CHI_PHI";
            lokChiPhi.Properties.ValueMember = "LOAI_CHI_PHI";

            DataTable tblDV = new DataTable();
            tblDV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, 
                        "SELECT MS_DON_VI,TEN_DON_VI FROM DON_VI ORDER BY TEN_DON_VI"));
            lokDVi.Properties.DataSource = tblDV;
            lokDVi.Properties.DisplayMember = "TEN_DON_VI";
            lokDVi.Properties.ValueMember = "MS_DON_VI";
            
            dtBPCP= new DataTable();
            dtBPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                            "SELECT MS_BP_CHIU_PHI, TEN_BP_CHIU_PHI, LOAI_CHI_PHI, MSDV, GHI_CHU " +
                            " FROM dbo.BO_PHAN_CHIU_PHI AS A"));
            BindingBPCP = new BindingSource();
            BindingBPCP.DataSource = dtBPCP;

            grdCP.DataSource = BindingBPCP;
            //grvCP.PopulateColumns();
            //grvCP.OptionsView.ColumnAutoWidth = true;
            //grvCP.OptionsView.AllowHtmlDrawHeaders = true;
            grvCP.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            //grvCP.BestFitColumns();
            grvCP.Columns["MS_BP_CHIU_PHI"].Visible = false;
            grvCP.Columns["LOAI_CHI_PHI"].Visible = false;
            grvCP.Columns["MSDV"].Visible = false;
            BindingData();
            
            if (string.IsNullOrEmpty(txtMS.Text))
                dtCost.DefaultView.RowFilter = "1 = 0";
            else
                dtCost.DefaultView.RowFilter = "MS_BP_CHIU_PHI = " + txtMS.Text;
            grdSource.DataSource = dtCost;
            //grvSource.PopulateColumns();
            //grvSource.OptionsView.ColumnAutoWidth = true;
            //grvSource.OptionsView.AllowHtmlDrawHeaders = true;
            grvSource.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            //grvSource.BestFitColumns();
            grvSource.Columns["MS_BP_CHIU_PHI"].Visible = false;
            TaoCmbLuoi();


       
        }
        private void RepositoryItemLookUpEdit_CloseUp(object sender, CloseUpEventArgs e)
        {
            try
            {
                //grvSource.SetRowCellValue(grvSource.FocusedRowHandle, grvSource.Columns["TEN"], "");
                DataTable dtKTra = new DataTable();
                dtKTra = (dtCost.DefaultView.ToTable());
                string MS = "";
                if (e.Value == null)
                    return;

                MS = e.Value.ToString();
                //grvSource.SetRowCellValue(grvSource.FocusedRowHandle, grvSource.Columns["TEN"], MS);
                foreach (DataRow dr in dtKTra.Rows)
                {
                    if (dr[0].ToString().Equals(MS))
                    {
                        grvSource.SetColumnError(grvSource.Columns["MS_COSTCENTER"],
                            Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                            "MaCostCenterTrung", Commons.Modules.TypeLanguage));
                        e.AcceptValue = false;
                        //grvSource.SetRowCellValue(grvSource.FocusedRowHandle, grvSource.Columns["TEN"],  e.Value.ToString());
                        return;
                    }
                }
                DataRow r = grvSource.GetFocusedDataRow();
                DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                grvSource.SetColumnError(grvSource.Columns["MS_COSTCENTER"], "");
                grvSource.SetRowCellValue(grvSource.FocusedRowHandle, grvSource.Columns["TEN"], MS);

                grvSource.SetRowCellValue(grvSource.FocusedRowHandle, grvSource.Columns["MS_BP_CHIU_PHI"], txtMS.Text);
                grvSource.SetRowCellValue(grvSource.FocusedRowHandle, grvSource.Columns["TY_LE"], "100");

            }
            catch { }
        }
        private void BindingData()
        {
            try
            {
                txtMS.DataBindings.Clear();
                txtMS.DataBindings.Add("Text", BindingBPCP, "MS_BP_CHIU_PHI");
                txtTen.DataBindings.Clear();
                txtTen.DataBindings.Add("Text", BindingBPCP, "TEN_BP_CHIU_PHI");
                txtGChu.DataBindings.Clear();
                txtGChu.DataBindings.Add("Text", BindingBPCP, "GHI_CHU");
                lokChiPhi.DataBindings.Clear();
                lokChiPhi.DataBindings.Add("EditValue", BindingBPCP, "LOAI_CHI_PHI", true, DataSourceUpdateMode.OnPropertyChanged, null);
                lokDVi.DataBindings.Clear();
                lokDVi.DataBindings.Add("EditValue", BindingBPCP, "MSDV", true, DataSourceUpdateMode.OnPropertyChanged, null);
                txtCPhi.DataBindings.Clear();
                txtCPhi.DataBindings.Add("Text", BindingBPCP, "TEN_LOAI_CHI_PHI");
                txtDvi.DataBindings.Clear();
                txtDvi.DataBindings.Add("Text", BindingBPCP, "TEN_DON_VI");

            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void grvCP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            { 
                dtCost.DefaultView.RowFilter = "MS_BP_CHIU_PHI = '" + txtMS.Text  + "'";
            }
            catch
            {
                dtCost.DefaultView.RowFilter = "0=1";
            }

        }
        private void TaoCmbLuoi()
        {
            DataTable tblCos = new DataTable();
            tblCos.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT MS_COSTCENTER ,[TEN_COSTCENTER] FROM [COSTCENTER]"));
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit editor = grdSource.RepositoryItems.Add("LookUpEdit") as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            editor.DataSource = tblCos;
            editor.ValueMember = "MS_COSTCENTER";
            editor.DisplayMember = "MS_COSTCENTER";
            editor.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(RepositoryItemLookUpEdit_CloseUp);
            grvSource.Columns[0].ColumnEdit = editor;

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit editor1 = grdSource.RepositoryItems.Add("LookUpEdit") as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;
            editor1.DataSource = tblCos;
            editor1.ValueMember = "MS_COSTCENTER";
            editor1.DisplayMember = "TEN_COSTCENTER";
            editor1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(RepositoryItemLookUpEdit_CloseUp);
            grvSource.Columns[1].ColumnEdit = editor1;
        }
           

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AnHien(false);
            txtMS.Properties.ReadOnly = false;
            BindingBPCP.AddNew();
        }

        private void grvSource_ShowingEditor(object sender, CancelEventArgs e)
        {
            DataRow r = grvSource.GetFocusedDataRow();
            DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (r == null)
                return;
            if (gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["MS_COSTCENTER"]).ToString() == "")
                return;
            
            if (r["MS_BP_CHIU_PHI"].ToString().Equals(String.Empty))
            {
                gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["MS_BP_CHIU_PHI"], txtMS.Text);
                gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["TY_LE"], "100");
            }

            if (grvSource.FocusedRowHandle == -2147483647)
            { 
                if (!string.IsNullOrEmpty(gv.GetRowCellValue(gv.FocusedRowHandle, "MS_COSTCENTER").ToString()) &&
                        !string.IsNullOrEmpty(gv.GetRowCellValue(gv.FocusedRowHandle, "TY_LE").ToString()))
                {
                    DataTable dtk = new DataTable();
                    dtk = (dtCost.DefaultView.ToTable()); 
                    BindingCost.AddNew();
                }
            }
        }

        private void grvSource_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void grvSource_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            grvSource.UpdateCurrentRow();
            DataRow r = grvSource.GetFocusedDataRow();
            DevExpress.XtraGrid.Views.Base.ColumnView view = sender as DevExpress.XtraGrid.Views.Base.ColumnView;
            grvSource.Columns.View.ClearColumnErrors();
            if (grvSource.FocusedRowHandle != -2147483647)
            {
                if (r["MS_COSTCENTER"].ToString().Equals(String.Empty))
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["MS_COSTCENTER"],
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, 
                        "ChuaNhapMs", Commons.Modules.TypeLanguage));
                }
                if (r["TY_LE"].ToString().Equals(String.Empty))
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["TY_LE"], 
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, 
                        "ChuaNhapTyLe", Commons.Modules.TypeLanguage));
                }
                if (Convert.ToDouble(r["TY_LE"].ToString()) <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["TY_LE"],  
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, 
                        "TyLeKhongDuocNhoHonHayBang0", Commons.Modules.TypeLanguage));
                }

            }

        }

        private void AnHien(bool ahien)
        {
            try
            {
                txtTen.Properties.ReadOnly = ahien;
                txtMS.Properties.ReadOnly = true;
                lokChiPhi.Properties.ReadOnly = ahien;
                lokDVi.Properties.ReadOnly = ahien;
                txtGChu.Properties.ReadOnly = ahien;
                grvSource.OptionsBehavior.Editable = !ahien;
                if (ahien == true)
                {
                    grvSource.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                    grvSource.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                }
                else
                {
                    grvSource.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                    grvSource.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                }
                grdCP.Enabled = ahien;
                btnAdd.Enabled = ahien;
                btnEdit.Enabled = ahien;
                btnExit.Enabled = ahien;
                btnDelete.Enabled = ahien;

                btnCancel.Enabled = !ahien;
                btnSave.Enabled = !ahien;
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (KTra() == false)
                    return;
                DataTable dtKTra = new DataTable();
                dtKTra = (dtCost.DefaultView.ToTable());
                if (dtKTra.Rows.Count == 0)
                {
                    Vietsoft.Information.MsgBox(this, "KhongChonCostCenter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                BindingBPCP.EndEdit();
                Vietsoft.SqlInfo SqlInsert = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
                SqlInsert.BeginTransaction();
                if (txtMS.Properties.ReadOnly == false)
                {
                    SqlInsert.ExecuteNonQuery(CommandType.StoredProcedure, "AddBO_PHAN_CHIU_PHI", 
                            txtTen.Text, lokChiPhi.EditValue, lokDVi.EditValue, txtGChu.Text);
                }
                else
                {
                    SqlInsert.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateBO_PHAN_CHIU_PHI", 
                            txtMS.Text, txtTen.Text, lokChiPhi.EditValue, lokDVi.EditValue, txtGChu.Text);
                }
                if (UpdateRule(SqlInsert))
                    SqlInsert.CommitTransaction();
                else
                    SqlInsert.RollbackTransaction();

                AnHien(true);
                int Dong;
                Dong = grvCP.FocusedRowHandle;
                TaoDuLieu();
                grvCP.FocusedRowHandle = Dong;

            }
            catch { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            AnHien(false);
            txtMS.Properties.ReadOnly = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BindingBPCP.CancelEdit();
            int Dong;
            Dong = grvCP.FocusedRowHandle;
            TaoDuLieu();
            AnHien(true);
            if (txtMS.Properties.ReadOnly)
                grvCP.FocusedRowHandle = Dong;
        }

        private bool UpdateRule(Vietsoft.SqlInfo SqlInsert)
        {
            try
            {
                DataTable dtUpdate = new DataTable();
                dtUpdate = (dtCost.DefaultView.ToTable());
                foreach (DataRow dr in dtUpdate.Rows)
                {
                    SqlInsert.ExecuteNonQuery(CommandType.StoredProcedure, "AddBO_PHAN_CHIU_PHI_RULE",
                            txtTen.Text, dr["MS_COSTCENTER"], dr["TY_LE"]);
                }

                return true;
            }
            catch { return false; }
        
        }

        private bool KTra()
        {
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                Vietsoft.Information.MsgBox(this, "ChuaNhapTen", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(lokChiPhi.Text))
            {
                Vietsoft.Information.MsgBox(this, "ChuaNhapChiPhi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                lokChiPhi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(lokDVi.Text))
            {
                Vietsoft.Information.MsgBox(this, "ChuaNhapDonVi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                lokDVi.Focus();
                return false;
            }
                        
            return true;
        }

        private void txtTen_Validating(object sender, CancelEventArgs e)
        {
            txtTen.ErrorText = "";
            if (txtTen.Properties.ReadOnly)
                return;

            if (string.IsNullOrEmpty(txtTen.Text))
                return;
            DataTable tblKT = new DataTable();

            tblKT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        " SELECT *  FROM [BO_PHAN_CHIU_PHI] WHERE [TEN_BP_CHIU_PHI] = N'" + txtTen.Text + "' " +
                        " AND ([TEN_BP_CHIU_PHI] + CONVERT(NVARCHAR,[MS_BP_CHIU_PHI])) <>  " +
                        " (SELECT TOP 1 ([TEN_BP_CHIU_PHI] + CONVERT(NVARCHAR,[MS_BP_CHIU_PHI])) " +
                        " FROM [BO_PHAN_CHIU_PHI] WHERE [MS_BP_CHIU_PHI] = " +  Convert.ToInt16( txtMS.Text )+ " )"));
            
            if (tblKT.Rows.Count > 0)
            {
                txtTen.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,this.Name,"TenKhongTrung",Commons.Modules.TypeLanguage) ;
                e.Cancel = true;
            }
            
        }

        private void LoadNN()
        {
            btnAdd.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnAdd", Commons.Modules.TypeLanguage);
            btnEdit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnEdit", Commons.Modules.TypeLanguage);
            btnSave.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnSave", Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnCancel", Commons.Modules.TypeLanguage);
            btnDelete.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnDelete", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExit", Commons.Modules.TypeLanguage);

            grvCP.Columns["TEN_BP_CHIU_PHI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_BP_CHIU_PHI", Commons.Modules.TypeLanguage);
            grvCP.Columns["GHI_CHU"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "GHI_CHU", Commons.Modules.TypeLanguage);

            grvSource.Columns["MS_COSTCENTER"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MS_COSTCENTER", Commons.Modules.TypeLanguage);
            grvSource.Columns["TEN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN", Commons.Modules.TypeLanguage);
            grvSource.Columns["TEN"].OptionsColumn.ReadOnly = true;
            grvSource.Columns["TY_LE"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TY_LE", Commons.Modules.TypeLanguage);

            grvSource.Columns["MS_COSTCENTER"].Width = 158;
            grvSource.Columns["TEN"].Width = 352;
            grvSource.Columns["TY_LE"].Width = 246;

            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void lokChiPhi_TextChanged(object sender, EventArgs e)
        {

        }

        private void lokChiPhi_EditValueChanged(object sender, EventArgs e)
        {

        }

        private bool XoaChiPhiRule(string MSoCost,string MsBP)
        {
            Vietsoft.SqlInfo SqlInsert = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            try
            {
                SqlInsert.BeginTransaction();
                string sql = "";
                if (MSoCost == "-1")
                    sql = "DELETE FROM [BO_PHAN_CHIU_PHI_RULE] WHERE [MS_BP_CHIU_PHI] = " + MsBP; 
                else
                    sql = "DELETE FROM [BO_PHAN_CHIU_PHI_RULE] WHERE [MS_COSTCENTER] = N'" + MSoCost + "' AND [MS_BP_CHIU_PHI] = " + MsBP; 
                
                SqlInsert.ExecuteNonQuery(CommandType.Text, sql);
                SqlInsert.CommitTransaction();
                return true;
            }
            catch
            {
                Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                SqlInsert.RollbackTransaction();
                return false;
            }

        }
        private bool XoaChiPhi(string MsBP)
        {
            Vietsoft.SqlInfo SqlInsert = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            try
            {
                SqlInsert.BeginTransaction();
                string sql = "DELETE FROM [BO_PHAN_CHIU_PHI] WHERE [MS_BP_CHIU_PHI] = " + MsBP;
                SqlInsert.ExecuteNonQuery(CommandType.Text, sql);
                SqlInsert.CommitTransaction();
                return true;
            }
            catch
            {
                Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                SqlInsert.RollbackTransaction();
                return false;
            }

        }

        private bool KiemXoa(string MSo)
        {
            try
            {
                string sql = "SELECT TOP 1 * FROM MAY_BO_PHAN_CHIU_PHI WHERE [MS_BP_CHIU_PHI] = " + MSo ;
                DataTable tbTest = new DataTable();
                tbTest = new DataTable();
                tbTest.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sql));
                if (tbTest.Rows.Count > 0)
                {
                    Vietsoft.Information.MsgBox(this, "MsgUsedMayChiuPhi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return true;
                }
                sql = "";
                sql = "SELECT TOP 1 * FROM KINH_PHI_NAM WHERE [MS_BP_CHIU_PHI] = " + MSo;
                tbTest = new DataTable();
                tbTest.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sql));
                if (tbTest.Rows.Count > 0)
                {
                    Vietsoft.Information.MsgBox(this, "MsgUsedKinhPhiNam", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return true;
                }
                else
                {
                    return false;
                }
            
            }
            catch
            {
                return true;
            }
        }

        private void grvSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (txtMS.Text == "") return;
                try
                {
                    if (grvSource.RowCount == 1)
                    {
                        if (Vietsoft.Information.MsgBox(this, "MsgCon1DongXoaLuonChiuPhi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes) return;
                        {
                            if (KiemXoa(txtMS.Text)) return ;
                            if (XoaChiPhiRule(grvSource.GetRowCellValue(grvSource.FocusedRowHandle, "MS_COSTCENTER").ToString(), txtMS.Text))
                            {
                                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                                view.DeleteSelectedRows();
                                XoaChiPhi(txtMS.Text);
                                TaoDuLieu();
                            }
                        }
                    }
                    else
                    {
                        if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes) return;
                        if (XoaChiPhiRule(grvSource.GetRowCellValue(grvSource.FocusedRowHandle, "MS_COSTCENTER").ToString(), txtMS.Text))
                        {
                            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                            view.DeleteSelectedRows();
                        }
                    }
                }
                catch { }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (KiemXoa(txtMS.Text)) return;
            if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes) return;
            if (XoaChiPhiRule("-1", txtMS.Text))
            {
                XoaChiPhi(txtMS.Text);
                TaoDuLieu();
            }

        }

        

        }
}