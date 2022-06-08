using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmChonDonHang : DevExpress.XtraEditors.XtraForm
    {
        string ms_ddh = string.Empty;
        string ms_kh = string.Empty;
        string ms_phieu_nhap = string.Empty;
        string nguoi_nhap = string.Empty;
        private DataTable _tblPhieuNhapKho = new DataTable();
        private BindingSource _bindingPhieuNhapKho = new BindingSource();
        public BindingSource BindingNhapKho
        {
            get
            {
                return _bindingPhieuNhapKho;
            }
            set
            {
                _bindingPhieuNhapKho = value;
            }
        }
        public string MS_DDH
        {
            get
            {
                return ms_ddh;
            }
            set
            {
                ms_ddh = value;
            }
        }
        public string NGUOI_NHAP
        {
            get
            {
                return nguoi_nhap;
            }
            set
            {
                nguoi_nhap = value;
            }
        }
        public string MS_KH
        {
            get
            {
                return ms_kh;
            }
            set
            {
                ms_kh = value;
            }
        }
        public string MS_DH_NHAP_PT
        {
            get
            {
                return ms_phieu_nhap;
            }
            set
            {
                ms_phieu_nhap = value;
            }
        }
        public DataTable TblPhieuNhapKho
        {
            get
            {
                return _tblPhieuNhapKho;
            }
            set
            {
                _tblPhieuNhapKho = value;
            }
        }
        public frmChonDonHang()
        {
            InitializeComponent();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void UpdateDDH()
        {
          
            if (DgvSelect.CurrentRow != null)
            {

                ms_ddh = DgvSelect.CurrentRow.Cells["COL_MS_DON_DAT_HANG"].Value.ToString().Trim();
                Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                string sql = "SELECT MS_KH FROM KHACH_HANG WHERE TEN_CONG_TY=N'" + DgvSelect.CurrentRow.Cells["COL_NHA_CUNG_CAP"].Value.ToString() + "'";
                 ms_kh = Convert.ToString(SqlDeXuatMuaHang.ExecuteScalar(sql));
                 if (ms_kh.Equals(nguoi_nhap))
                {

                    SqlDeXuatMuaHang.ExecuteNonQuery("UPDATE IC_DON_HANG_NHAP SET MS_DANG_NHAP=3,NGUOI_NHAP='" + ms_kh + "',MS_DDH='" + ms_ddh + "' WHERE MS_DH_NHAP_PT='" + MS_DH_NHAP_PT + "' ");
                    BindingNhapKho.EndEdit();
                    _tblPhieuNhapKho.AcceptChanges();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (Vietsoft.Information.MsgBox(this, "khachhangkhongtrung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        SqlDeXuatMuaHang.ExecuteNonQuery("UPDATE IC_DON_HANG_NHAP SET MS_DANG_NHAP=3,NGUOI_NHAP='" + ms_kh + "',MS_DDH='" + ms_ddh + "' WHERE MS_DH_NHAP_PT='" + MS_DH_NHAP_PT + "' ");
                        BindingNhapKho.EndEdit();   
                        _tblPhieuNhapKho.AcceptChanges();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                  
                }


            }
            else
            {
                ms_ddh = string.Empty;
            }

        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            UpdateDDH();
        }
        private void frmChonDeXuat_Load(object sender, EventArgs e)
        {            
            Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbDeXuatMuaHang = new System.Data.DataTable();
            SqlDeXuatMuaHang.ExecuteNonQuery("EXEC SP_NHU_Y_GET_DON_DAT_HANG_NHAP_KHO");
            TbDeXuatMuaHang.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure,"SP_NHU_Y_GET_DON_DAT_HANG_HUDA",ms_phieu_nhap));
            DataTable _Temp= TbDeXuatMuaHang.DefaultView.ToTable(true, "MS_DON_DAT_HANG", "SO_DON_DAT_HANG", "NGAY_DAT", "NHA_CUNG_CAP");
            DgvSelect.AutoGenerateColumns = false;
            DgvSelect.DataSource = _Temp;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
          
        }

        private void DgvSelect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDDH();
        }
    }
}