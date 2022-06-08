using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace WareHouse
{
    public partial class frmChonMay_TGNM : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Khai báo chung
        /// </summary> 
        private DataTable _TbSource = new DataTable();
        /// <summary>
        /// DataSource
        /// </summary> 
        public DataTable DataSource
        {
            get
            {
                return _TbSource;
            }
            set
            {
                _TbSource = value;
            }
        }

        private string sMsMay = "-1";
        public string MsMay { get { return sMsMay; } set { sMsMay = value; } }



        public frmChonMay_TGNM()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void frmChonMay_TGNM_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0load";
            LoadNX();
            LoadDChuyen();

            _TbSource.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, _TbSource, true, true, true, true);
            for (int i = 1; i < grvMay.Columns.Count; i++)
            {
                _TbSource.Columns[i].ReadOnly = true;
            }
            grvMay.Columns["CHON"].Width = 55;
            grvMay.Columns["MS_MAY"].Width = 100;
            grvMay.Columns["TEN_MAY"].Width = 150;
            grvMay.Columns["MODEL"].Width = 100;
            _TbSource.Columns["CHON"].ReadOnly = false;

            if (sMsMay != "-1")
            {
                int index = _TbSource.Rows.IndexOf(_TbSource.Rows.Find(sMsMay));
                grvMay.FocusedRowHandle = grvMay.GetRowHandle(index);
            }
            Commons.Modules.SQLString = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }

        private void txtTKiemNNNM_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LocData();
        }

        private void LocData()
        {
            try
            {
                if (Commons.Modules.SQLString == "0load") return;
                DataTable dtMay = new DataTable();
                dtMay = (DataTable)grdMay.DataSource;

                try
                {
                    string dk = "";
                    string dk1 = "";

                    if (txtTKiemNNNM.Text.Length != 0) dk = " OR (MS_MAY LIKE '%" + txtTKiemNNNM.Text + "%') " + dk;
                    if (txtTKiemNNNM.Text.Length != 0) dk = " OR (TEN_MAY LIKE '%" + txtTKiemNNNM.Text + "%') " + dk;

                    if (int.Parse(cboDChuyen.EditValue.ToString()) != -1) dk1 = " AND (TEN_HE_THONG = '" + cboDChuyen.Text + "') " + dk1;
                    if (int.Parse(cboDDiem.EditValue.ToString()) != -1) dk1 = " AND (Ten_N_XUONG = '" + cboDDiem.Text + "') " + dk1;

                    if (dk.Length > 0) dk = dk.Substring(4, dk.Length - 4);
                    if (dk1.Length > 0)
                    {
                        if (dk.Length > 0)
                        {
                            dk = "(" + dk + ") AND " + "(" +  dk1.Substring(4, dk1.Length - 4) + ")";
                        }
                        else
                        {
                            dk = dk1.Substring(4, dk1.Length - 4);
                        }
                        
                    }
                    dtMay.DefaultView.RowFilter = dk;

                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                    dtMay.DefaultView.RowFilter = ""; }
            }
            catch { }
        }

        private void cboDChuyen_EditValueChanged(object sender, EventArgs e)
        {
            LocData();
        }


        private void LoadNX()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuong(1, "-1", "-1", "-1"), "MS_N_XUONG", "TEN_N_XUONG", lblDDiem.Text);
            }
            catch { }
        }

        private void LoadDChuyen()
        {
            try
            {

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", lblDChuyen.Text);
            }
            catch { }
        }
    }
}