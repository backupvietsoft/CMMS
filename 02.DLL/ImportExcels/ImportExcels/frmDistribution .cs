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
using System.Data.OleDb;

namespace ImportExcels
{
    public partial class frmDistribution : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtDist = new DataTable();
        private BindingSource BindingDist = new BindingSource();

        public frmDistribution()
        {
            InitializeComponent();
        }
       
        private void LoadData()
        {
            try
            {
                DataTable tblChiPhi = new DataTable();
                tblChiPhi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT LOAI_CHI_PHI,TEN_LOAI_CHI_PHI FROM LOAI_CHI_PHI ORDER BY TEN_LOAI_CHI_PHI"));
                lokChiPhi.Properties.DataSource = tblChiPhi;
                lokChiPhi.Properties.DisplayMember = "TEN_LOAI_CHI_PHI";
                lokChiPhi.Properties.ValueMember = "LOAI_CHI_PHI";

                DataTable tblDV = new DataTable();
                tblDV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_DON_VI,TEN_DON_VI FROM DON_VI ORDER BY TEN_DON_VI"));
                lokDVi.Properties.DataSource = tblDV;
                lokDVi.Properties.DisplayMember = "TEN_DON_VI";
                lokDVi.Properties.ValueMember = "MS_DON_VI";
                //lokDVi.Properties.Columns["MS_DON_VI"].Visible = false;

                dtDist = new DataTable();
                dtDist.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                                "SELECT A.MS_COSTCENTER, A.TEN_COSTCENTER, C.TEN_LOAI_CHI_PHI, B.TEN_DON_VI, A.GHI_CHU, A.LOAI_CHI_PHI, " + 
                                " A.MSDV FROM dbo.COSTCENTER AS A INNER JOIN dbo.DON_VI AS B ON A.MSDV = B.MS_DON_VI " +
                                " INNER JOIN dbo.LOAI_CHI_PHI AS C ON A.LOAI_CHI_PHI = C.LOAI_CHI_PHI " +
                                " ORDER BY A.TEN_COSTCENTER"));
                BindingDist.DataSource = dtDist;
                grdSource.DataSource = BindingDist;              
                grvSource.PopulateColumns();
                grvSource.OptionsView.ColumnAutoWidth = true;
                grvSource.OptionsView.AllowHtmlDrawHeaders = true;
                grvSource.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                grvSource.BestFitColumns();
                grvSource.Columns["LOAI_CHI_PHI"].Visible = false;
                grvSource.Columns["MSDV"].Visible = false;
                BindingData();
                 
            }
            catch { }

        }
        private void BindingData()
        {
            try
            {
                txtMS.DataBindings.Clear();
                txtMS.DataBindings.Add("Text", BindingDist, "MS_COSTCENTER");
                txtTen.DataBindings.Clear();
                txtTen.DataBindings.Add("Text", BindingDist, "TEN_COSTCENTER");
                txtGChu.DataBindings.Clear();
                txtGChu.DataBindings.Add("Text", BindingDist, "GHI_CHU");
                lokChiPhi.DataBindings.Clear();
                lokChiPhi.DataBindings.Add("EditValue", BindingDist, "LOAI_CHI_PHI", true, DataSourceUpdateMode.OnPropertyChanged, null);
                lokDVi.DataBindings.Clear();
                lokDVi.DataBindings.Add("EditValue", BindingDist, "MSDV", true, DataSourceUpdateMode.OnPropertyChanged, null);
                txtCPhi.DataBindings.Clear();
                txtCPhi.DataBindings.Add("Text", BindingDist, "TEN_LOAI_CHI_PHI");
                txtDvi.DataBindings.Clear();
                txtDvi.DataBindings.Add("Text", BindingDist, "TEN_DON_VI");
                
            }
            catch { }
        }

        private void frmDistribution_Load(object sender, EventArgs e)
        {
            AnHien(true);
            LoadData();
            LoadNN();

            try
            {
                if (Commons.Modules.PermisString.Equals("Read only"))
                {
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;

                }
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AnHien(bool ahien)
        {
            try
            {
                txtMS.Properties.ReadOnly = ahien;
                txtTen.Properties.ReadOnly = ahien;
                lokChiPhi.Properties.ReadOnly = ahien;
                lokDVi.Properties.ReadOnly = ahien;
                txtGChu.Properties.ReadOnly = ahien;
                grvSource.OptionsBehavior.Editable = !ahien;
                grdSource.Enabled = ahien;

                btnAdd.Enabled = ahien;
                btnEdit.Enabled = ahien;
                btnExit.Enabled = ahien;
                btnDelete.Enabled = ahien;

                btnCancel.Enabled = !ahien;
                btnSave.Enabled = !ahien;
                



            }
            catch { }
        }
        
        private bool CheckLuu()
        {
            if (txtMS.Text == "")
            {
                Vietsoft.Information.MsgBox(this, "MsgMaSoNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtMS.Focus();
                return false;
            }

            if (txtTen.Text == "")
            {
                Vietsoft.Information.MsgBox(this, "MsgTenNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtTen.Focus();
                return false;
            }
            if (lokChiPhi.Text == "")
            {
                Vietsoft.Information.MsgBox(this, "MsgChiPhiNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                lokChiPhi.Focus();
                return false;
            }
            if (lokDVi.Text == "")
            {
                Vietsoft.Information.MsgBox(this, "MsgDViNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                lokDVi.Focus();
                return false;
            }
            return true; 
        }
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AnHien(false);
            BindingDist.AddNew();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AnHien(false);
            txtMS.Properties.ReadOnly = true;
            txtTen.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckLuu() == false) { return; }
            Vietsoft.SqlInfo SqlInsert = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            try
            {
                SqlInsert.BeginTransaction();
                string Sql = "";
                if (txtMS.Properties.ReadOnly==false  )
                {
                    SqlInsert.ExecuteNonQuery(CommandType.StoredProcedure, "InsertDISTRIBUTION", txtMS.Text, txtTen.Text, lokChiPhi.EditValue, lokDVi.EditValue, txtGChu.Text);
                }
                else
                {
                    Sql = " UPDATE COSTCENTER SET TEN_COSTCENTER = N'" + txtTen.Text + "' , LOAI_CHI_PHI = " + lokChiPhi.EditValue + " , " +
                                " MSDV = N'" + lokDVi.EditValue + "' , GHI_CHU = N'" + txtGChu.Text + "' " +
                                " WHERE MS_COSTCENTER = N'" + txtMS.Text + "' ";
                    SqlInsert.ExecuteNonQuery(CommandType.Text, Sql);
                }
                txtCPhi.Text = lokChiPhi.Text;
                txtDvi.Text = lokDVi.Text;
                BindingDist.EndEdit();
                AnHien(true);
                SqlInsert.CommitTransaction();
            }
            catch
            {
                Vietsoft.Information.MsgBox(this, "MsgUpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                SqlInsert.RollbackTransaction();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                BindingDist.CancelEdit();
                AnHien(true);
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes) return;
                if (XoaData(txtMS.Text))
                { BindingDist.RemoveCurrent(); }                
            }
            catch { }
        }

        private void grvSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (txtMS.Text == "") return;
                try
                {
                    if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes) return;
                    if (XoaData(txtMS.Text))
                    {
                        GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                        view.DeleteSelectedRows();
                    }
                }
                catch { }
            }
        }

        private bool KiemXoa(string MSo)
        {
            try
            {
                string sql = "SELECT TOP 1 * FROM BO_PHAN_CHIU_PHI_RULE WHERE [MS_COSTCENTER] = N'" + MSo + "'";
                DataTable tbTest = new DataTable();
                tbTest = new DataTable();
                tbTest.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sql));
                if (tbTest.Rows.Count > 0)
                {
                    Vietsoft.Information.MsgBox(this, "MsgUsedError", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return true ;
                }
                else {
                    return false; 
                }
            }
            catch
            {
                return true;
            }
        }

        private bool XoaData(string MSo)
        {
            Vietsoft.SqlInfo SqlInsert = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            try
            {
                if (KiemXoa(MSo)) return false ; 

                SqlInsert.BeginTransaction();
                string sql = "DELETE FROM [COSTCENTER] WHERE [MS_COSTCENTER] = N'" + MSo + "'";
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

        private void txtMS_EditValueChanged(object sender, EventArgs e)
        {

        
        }
        private bool KiemTrung(string MSo)
        {
            try
            {
                string sql = "SELECT TOP 1 * FROM [COSTCENTER] WHERE [MS_COSTCENTER] = N'" + MSo + "'";
                DataTable tbTest = new DataTable();
                tbTest = new DataTable();
                tbTest.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sql));
                if (tbTest.Rows.Count > 0)
                {
                    Vietsoft.Information.MsgBox(this, "MsgTrung", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return true;
                }
                else { return false; }
            }
            catch
            { return false; }
        }

        private void txtMS_Validated(object sender, EventArgs e)
        {
            
            if (txtMS.Properties.ReadOnly) return;
            if (txtMS.Text == "") return;
            if (KiemTrung(txtMS.Text))
            { txtMS.Focus(); }
        }
        private void LoadNN()
        {
            btnAdd.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnAdd", Commons.Modules.TypeLanguage);
            btnEdit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnEdit", Commons.Modules.TypeLanguage);
            btnSave.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnSave", Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnCancel", Commons.Modules.TypeLanguage);
            btnDelete.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnDelete", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExit", Commons.Modules.TypeLanguage);

            grvSource.Columns["MS_COSTCENTER"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MS_COSTCENTER", Commons.Modules.TypeLanguage);
            grvSource.Columns["TEN_COSTCENTER"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_COSTCENTER", Commons.Modules.TypeLanguage);
            grvSource.Columns["TEN_LOAI_CHI_PHI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_LOAI_CHI_PHI", Commons.Modules.TypeLanguage);
            grvSource.Columns["TEN_DON_VI"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_DON_VI", Commons.Modules.TypeLanguage);
            grvSource.Columns["GHI_CHU"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "GHI_CHU", Commons.Modules.TypeLanguage);

            grvSource.Columns["MS_COSTCENTER"].Width = 100;
            grvSource.Columns["TEN_COSTCENTER"].Width = 215;
            grvSource.Columns["TEN_LOAI_CHI_PHI"].Width = 215;
            grvSource.Columns["TEN_DON_VI"].Width = 215;
            grvSource.Columns["GHI_CHU"].Width = 245;

            groupControl1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ThongTinCos", Commons.Modules.TypeLanguage);
            groupControl2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "DuLieuCos", Commons.Modules.TypeLanguage);


            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        

    }

}