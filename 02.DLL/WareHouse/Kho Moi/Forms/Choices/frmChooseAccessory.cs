using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
namespace WareHouse
{
    public partial class frmChooseAccessory : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _TbSource = new DataTable();
        private DataTable _TbCurrent = new DataTable();
        private string phieu_xuat;
        public frmChooseAccessory()
        {
            InitializeComponent();
        }
        public string Phieu_Xuat
        {
            get
            {
                return phieu_xuat;
            }
            set
            {
                phieu_xuat = value;
            }
        }
        private void SetLanguage()
        {


            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChooseAccessory_Issued", "btnExecute", Commons.Modules.TypeLanguage);

            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmChooseAccessory_Issued", "btnExit", Commons.Modules.TypeLanguage);
            
            grvList.Columns["CHON"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmChooseAccessory_Issued", "chon", Commons.Modules.TypeLanguage);
            grvList.Columns["MS_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmChooseAccessory_Issued", "masophutung", Commons.Modules.TypeLanguage);
            grvList.Columns["TEN_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmChooseAccessory_Issued", "tenphutung", Commons.Modules.TypeLanguage);
            grvList.Columns["LOAI_VAT_TU"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmChooseAccessory_Issued", "loaivattu", Commons.Modules.TypeLanguage);
            grvList.Columns["MS_PT_NCC"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmChooseAccessory_Issued", "partno", Commons.Modules.TypeLanguage);
            grvList.Columns["TEN_DV"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmChooseAccessory_Issued", "tendonvi", Commons.Modules.TypeLanguage);
            grvList.Columns["SL"].Caption = Commons.Modules.ObjLanguages.GetLanguage( Commons.Modules.ModuleName, "frmChooseAccessory_Issued", "soluong", Commons.Modules.TypeLanguage);
            
        }
        private void LoadData()
        {
           
            _TbSource = new DataTable();
            _TbSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_PHU_TUNG",Commons.Modules.TypeLanguage,phieu_xuat));
            foreach (DataColumn ClPhuTung in _TbSource.Columns)
            {
                
                ClPhuTung.ReadOnly = true;
            }

            _TbSource.Columns["CHON"].ReadOnly = false;
            DataColumn[] clKeyPhuTung = new DataColumn[1];
            clKeyPhuTung[0] = _TbSource.Columns["MS_PT"];            
            _TbSource.PrimaryKey = clKeyPhuTung;
            for (int i = 0; i < _TbCurrent.Rows.Count; i++)
            {
                try
                {
                    _TbSource.Rows.Remove(_TbSource.Rows.Find(_TbCurrent.Rows[i]["MS_PT"]));
                }
                catch { }
            }
            
            grdList.DataSource = _TbSource;
         
          
        }
        public DataTable DataSource
        {
            get
            {
                return _TbSource;
            }
        }
        /// <summary>
        /// DataSource
        /// </summary> 
        public DataTable CurrentSource
        {
            set
            {
                _TbCurrent = value;
            }
        }

        private void frmChooseAccessory_Load(object sender, EventArgs e)
        {
            LoadData();
            SetLanguage();
           Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtTK_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = (DataTable)grdList.DataSource;
                dtTmp.DefaultView.RowFilter = " MS_PT like '%" + txtTK.Text + "%' OR TEN_PT like '%" + txtTK.Text + "%'";
                dtTmp = dtTmp.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                dtTmp.DefaultView.RowFilter = "";
                dtTmp = dtTmp.DefaultView.ToTable();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grvList.RowCount; i++)
            {
                grvList.GetDataRow(i)["CHON"] = true;
                grdList.Update();
            }
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grvList.RowCount; i++)
            {
                grvList.GetDataRow(i)["CHON"] = false;
                grdList.Update();
            }
        }
    }
}
