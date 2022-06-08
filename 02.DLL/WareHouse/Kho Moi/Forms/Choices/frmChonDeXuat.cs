using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmChonDeXuat : DevExpress.XtraEditors.XtraForm
    {
        string _MS_DE_XUAT = string.Empty;
        public string MS_DE_XUAT
        {
            get
            {
                return _MS_DE_XUAT;
            }            
        }
        public frmChonDeXuat()
        {
            InitializeComponent();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (DgvSelect.CurrentRow != null)
            {
                _MS_DE_XUAT = DgvSelect.CurrentRow.Cells["ClMS_DE_XUAT"].Value.ToString().Trim();
            }
            else
            {
                _MS_DE_XUAT = string.Empty;
            }
            this.Close();
        }
        private void frmChonDeXuat_Load(object sender, EventArgs e)
        {            
            Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbDeXuatMuaHang = new System.Data.DataTable();
            TbDeXuatMuaHang.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DE_XUAT_MUA_HANG"));
            DgvSelect.AutoGenerateColumns = false;
            DgvSelect.DataSource = TbDeXuatMuaHang;
            DgvSelect.Columns["ClMS_DE_XUAT"].DataPropertyName = "MS_DE_XUAT";
            DgvSelect.Columns["ClSO_DE_XUAT"].DataPropertyName = "SO_DE_XUAT";
            DgvSelect.Columns["ClPHONG_BAN"].DataPropertyName = "PHONG_BAN";
            DgvSelect.Columns["ClNGAY_DE_XUAT"].DataPropertyName = "NGAY_DE_XUAT";
            DgvSelect.Columns["ClNGUOI_DE_XUAT"].DataPropertyName = "NGUOI_DE_XUAT";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            DgvSelect.ColumnFilter("ClMS_DE_XUAT", "ClSO_DE_XUAT", "ClPHONG_BAN", "ClNGAY_DE_XUAT", "ClNGUOI_DE_XUAT");
        }
    }
}