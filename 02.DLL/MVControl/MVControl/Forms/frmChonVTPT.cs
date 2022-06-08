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

namespace MVControl
{
    public partial class frmChonVTPT : DevExpress.XtraEditors.XtraForm
    {
        
        public DataTable dtChon;
        public int iLoaiChon = 0;
        //iLoaiChon = 0 Chon VTPT
        //iLoaiChon = 0 Chon Nhan Su

        public frmChonVTPT()
        {
            InitializeComponent();
        }
        private void LoadCmbChon()
        {
            try
            {
                switch (iLoaiChon)
                {
                    case 0:
                        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboChon, Commons.Modules.ObjSystems.MLoadDataLoaiVatTu(1), "MS_LOAI_VT", "TEN_LOAI_VT", lblLVT.Text);
                        break;
                    case 1:
                        DataTable dtTmp = new DataTable();
                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll", 1, Commons.Modules.UserName));
                        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboChon, dtTmp, "MS_DON_VI", "TEN_DON_VI", "");
                        break;
                }

                cboChon.EditValue = "-1";
            }
            catch { }
        }
        private void frmChonVTPT_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            LoadCmbChon();
            Commons.Modules.SQLString = "";
            LoadForm();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            this.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChonNhanVien",
                          Commons.Modules.TypeLanguage);
        }

        private void LoadForm()
        {
            switch (iLoaiChon)
            {
                case 0:
                    LoadVattu();
                    break;
                case 1:
                    LoadNhanSu();
                    break;

            }


        }
        private void LoadVattu()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;

            dtChon.Columns["CHON"].ReadOnly = false;
           
            if (cboChon.EditValue.ToString() == "-1")
            {
                dtChon.DefaultView.RowFilter = "";
            }
            else
            {
                dtChon.DefaultView.RowFilter = " MS_LOAI_VT = " + cboChon.EditValue;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChon, grvChon, dtChon, true, true, true, true, true, this.Name.ToString());


            for (int i = 1; i <= grvChon.Columns.Count - 1; i++)
            {
                grvChon.Columns[i].OptionsColumn.ReadOnly = true;
                grvChon.Columns[i].OptionsColumn.AllowEdit = false;
            }
            grvChon.Columns["CHON"].Width = 50;
            grvChon.Columns["MS_PT"].Width = 100;
            grvChon.Columns["MS_LOAI_VT"].Visible = false;
        }

        private void LoadNhanSu()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                if (dtChon.Columns[0].ColumnName.ToUpper() != "CHON")
                {
                    System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                    newColumn.DefaultValue = "0";
                    dtChon.Columns.Add(newColumn);

                    newColumn.DefaultValue = false;
                    newColumn.SetOrdinal(0);
                }
            }
            catch { }

            dtChon.Columns["CHON"].ReadOnly = false;

            if (cboChon.EditValue.ToString() == "-1")
            {
                dtChon.DefaultView.RowFilter = "";
            }
            else
            {
                dtChon.DefaultView.RowFilter = " MS_DON_VI = " + cboChon.EditValue;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChon, grvChon, dtChon, true, true, true, true, true, this.Name.ToString());

            grvChon.Columns[1].OptionsColumn.ReadOnly = true;
            grvChon.Columns[2].OptionsColumn.ReadOnly = true;
            grvChon.Columns[1].OptionsColumn.AllowEdit = false;
            grvChon.Columns[2].OptionsColumn.AllowEdit = false;

            for (int i = 3; i <= grvChon.Columns.Count - 1; i++)
            {
                grvChon.Columns[i].OptionsColumn.ReadOnly = true;
                grvChon.Columns[i].Visible = false;
                grvChon.Columns[i].OptionsColumn.AllowEdit = false;
            }
            grvChon.Columns["CHON"].Width = 50;
            //grvChon.Columns["MS_PT"].Width = 100;
            //grvChon.Columns["MS_LOAI_VT"].Visible = false;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        private void cboLVT_EditValueChanged(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void txtTKiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)grdChon.DataSource;
                try
                {
                    dt.DefaultView.RowFilter = " MS_PT LIKE '%" + txtTKiem.Text.Trim() + "%' OR TEN_PT LIKE '%" + txtTKiem.Text.Trim() + 
                        "%' OR TEN_PT_VIET LIKE '%" + txtTKiem.Text.Trim() + "%' OR MS_PT_NCC LIKE '%" + txtTKiem.Text.Trim() +
                        "%' OR MS_PT_CTY LIKE '%" + txtTKiem.Text.Trim() + "%' OR QUY_CACH LIKE '%" + txtTKiem.Text.Trim() + "%' ";
                    dt = dt.DefaultView.ToTable();
                }
                catch (Exception exx)
                {
                    MessageBox.Show(exx.Message);
                    dt.DefaultView.RowFilter = "";
                    dt = dt.DefaultView.ToTable();
                }
            }
            catch { }
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvChon);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvChon);
        }
    }
}