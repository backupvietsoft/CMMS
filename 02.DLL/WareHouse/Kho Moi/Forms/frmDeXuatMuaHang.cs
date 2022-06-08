using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using System.Security.Cryptography;
using System.Security;
using System.Security.Cryptography;

using System.Web;

using System.Linq;
using DevExpress.XtraEditors.Repository;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraPrinting;

namespace WareHouse
{
    public partial class frmDeXuatMuaHang_New : DevExpress.XtraEditors.XtraForm
    {
        #region "Khai Bao"
        /// <summary>
        /// Khai báo toàn cục
        /// </summary>
        private BindingSource BindingDeXuatMuaHang = new BindingSource();
        private System.Data.DataTable TbDeXuatMuaHang = new System.Data.DataTable();
        private System.Data.DataTable TbDeXuatMuaHangChiTiet = new System.Data.DataTable();
        private System.Data.DataTable TbDeXuatMuaHangDichVu = new System.Data.DataTable();
        private System.Data.DataTable TbDuyetDeXuatMuaHang = new System.Data.DataTable();
        private string TrangThai = String.Empty;
        private bool isFirst = false;
        private bool bQDeXuat = false;

        private bool bCoDuyet = false;

        private string sTT1DangSoan = "Đang soạn";
        private string sTT2TrinhDuyet = "Trình duyệt";
        private string sTT3Duyet = "Duyệt";
        private string sTT4Dong = "Đóng";
        private string sTTDX = "";
        private Boolean bUnLock = false;
        private Boolean bThayDoiDuyet = false;
        private Boolean bSuaDuyet = false;
        private Boolean bCNDuyet = false;
        string sDuongDanTLDichVu = "D:\\Tai_Lieu_May\\DeXuatDichVu\\";

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// 
        private System.Windows.Forms.DataGridViewCheckBoxColumn BUYING_NEW_CT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn REPLACING_FOR_CT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SPARE_CT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MAINTENANCE_CT;
        private System.Windows.Forms.DataGridViewComboBoxColumn TEN_MAY_CT;
        private Vietsoft.DataGridViewColumnEditor LIFE_TIME_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BY_WHOM_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN_N_XUONG_CT;
        private System.Windows.Forms.DataGridViewComboBoxColumn TRANSFER_TO_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUONG_DAN_TL_CT;


        private System.Windows.Forms.DataGridViewComboBoxColumn NHA_CUNG_CAP_DV;
        private new Vietsoft.DataGridViewColumnEditor NGAY_GIAO_HANG_DV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN_N_XUONG_DV;
        private System.Windows.Forms.DataGridViewComboBoxColumn TEN_MAY_DV;
        private Vietsoft.DataGridViewColumnEditor LIFE_TIME_DV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BUYING_NEW_DV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn REPLACING_FOR_DV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SPARE_DV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MAINTENANCE_DV;
        private System.Windows.Forms.DataGridViewTextBoxColumn BY_WHOM_DV;
        private System.Windows.Forms.DataGridViewComboBoxColumn TRANSFER_TO_DV;
        //private System.Windows.Forms.DataGridViewTextBoxColumn DUONG_DAN_TL_DV;

        #endregion

        public frmDeXuatMuaHang_New()
        {
            InitializeComponent();
            #region "An cot Veco"
            if (Commons.Modules.sPrivate == "VECO")
            {
                try
                {
                    DgvDeXuatMuaHangDichVu.Columns["DON_GIA_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["NGOAI_TE_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["TY_GIA_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["TY_GIA_USD_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["THANH_TIEN_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["THANH_TIEN_VND_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["THANH_TIEN_USD_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["NGAY_DX"].Visible = false;

                }
                catch { }

                try
                {
                    DgvDeXuatMuaHangChiTiet.Columns["TON_MIN"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["MS_PT_CTY"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["PART_NO"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["QUY_CACH"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["SL_DA_DUYET"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["DON_GIA"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["TY_GIA"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["TY_GIA_USD"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["THANH_TIEN"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["THANH_TIEN_VND"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["THANH_TIEN_USD"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["THUE_VAT"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["CONG_DUNG"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["HAN_SU_DUNG"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["TON_KHO"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["TON_MAX"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["DA_DAT_MUA"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["DA_DE_XUAT"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["SO_HOA_DON"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["NGAY_DE_XUAT_CUOI"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["DON_GIA_CUOI"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["NHA_CUNG_CAP_CUOI"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE_CUOI"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["SL_DA_NHAP"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["TEN_TRANG_THAI"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["MS_TTHAI"].Visible = false;

                }
                catch
                {

                }


                BUYING_NEW_CT = new DataGridViewCheckBoxColumn();
                BUYING_NEW_CT.Name = "BUYING_NEW";
                BUYING_NEW_CT.HeaderText = "BUYING_NEW";
                BUYING_NEW_CT.MinimumWidth = 120;
                BUYING_NEW_CT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                BUYING_NEW_CT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                BUYING_NEW_CT.Width = 120;

                REPLACING_FOR_CT = new DataGridViewCheckBoxColumn();
                REPLACING_FOR_CT.Name = "REPLACING_FOR";
                REPLACING_FOR_CT.HeaderText = "REPLACING_FOR";
                REPLACING_FOR_CT.MinimumWidth = 120;
                REPLACING_FOR_CT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                REPLACING_FOR_CT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                REPLACING_FOR_CT.Width = 120;

                SPARE_CT = new DataGridViewCheckBoxColumn();
                SPARE_CT.Name = "SPARE";
                SPARE_CT.HeaderText = "SPARE";
                SPARE_CT.MinimumWidth = 120;
                SPARE_CT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                SPARE_CT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                SPARE_CT.Width = 120;

                MAINTENANCE_CT = new DataGridViewCheckBoxColumn();
                MAINTENANCE_CT.Name = "MAINTENANCE";
                MAINTENANCE_CT.HeaderText = "MAINTENANCE";
                MAINTENANCE_CT.MinimumWidth = 120;
                MAINTENANCE_CT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                MAINTENANCE_CT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                MAINTENANCE_CT.Width = 120;

                TEN_MAY_CT = new DataGridViewComboBoxColumn();
                TEN_MAY_CT.Name = "TEN_MAY";
                TEN_MAY_CT.HeaderText = "TEN_MAY";
                TEN_MAY_CT.MinimumWidth = 120;
                TEN_MAY_CT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                TEN_MAY_CT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                TEN_MAY_CT.Width = 180;
                TEN_MAY_CT.DropDownWidth = 200;

                TEN_N_XUONG_CT = new DataGridViewTextBoxColumn();
                TEN_N_XUONG_CT.Name = "TEN_N_XUONG";
                TEN_N_XUONG_CT.HeaderText = "TEN_N_XUONG";
                TEN_N_XUONG_CT.MinimumWidth = 120;
                TEN_N_XUONG_CT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                TEN_N_XUONG_CT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                TEN_N_XUONG_CT.Width = 120;




                LIFE_TIME_CT = new Vietsoft.DataGridViewColumnEditor();
                LIFE_TIME_CT.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                LIFE_TIME_CT.DataType = 2;
                LIFE_TIME_CT.HeaderText = "LIFE_TIME";
                LIFE_TIME_CT.InPutMask = "";
                LIFE_TIME_CT.MaxLength = 32700;
                LIFE_TIME_CT.MinimumWidth = 80;
                LIFE_TIME_CT.Name = "LIFE_TIME";
                LIFE_TIME_CT.StringFormat = "N0";
                LIFE_TIME_CT.Width = 80;




                BY_WHOM_CT = new DataGridViewTextBoxColumn();
                BY_WHOM_CT.Name = "BY_WHOM";
                BY_WHOM_CT.HeaderText = "BY_WHOM";
                BY_WHOM_CT.MinimumWidth = 120;
                BY_WHOM_CT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                BY_WHOM_CT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                BY_WHOM_CT.Width = 120;

                TRANSFER_TO_CT = new DataGridViewComboBoxColumn();
                TRANSFER_TO_CT.Name = "TRANSFER_TO";
                TRANSFER_TO_CT.HeaderText = "TRANSFER_TO";
                TRANSFER_TO_CT.MinimumWidth = 120;
                TRANSFER_TO_CT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                TRANSFER_TO_CT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                TRANSFER_TO_CT.Width = 120;


                DUONG_DAN_TL_CT = new DataGridViewTextBoxColumn();
                DUONG_DAN_TL_CT.Name = "DUONG_DAN_TL";
                DUONG_DAN_TL_CT.HeaderText = "DUONG_DAN_TL";
                DUONG_DAN_TL_CT.MinimumWidth = 120;
                DUONG_DAN_TL_CT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                DUONG_DAN_TL_CT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                DUONG_DAN_TL_CT.Width = 120;


                this.DgvDeXuatMuaHangChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                   TEN_MAY_CT, TEN_N_XUONG_CT,LIFE_TIME_CT, BUYING_NEW_CT,
                    REPLACING_FOR_CT,
                    SPARE_CT,
                    MAINTENANCE_CT,
                     BY_WHOM_CT, TRANSFER_TO_CT
                     ,DUONG_DAN_TL_CT
                });


                NHA_CUNG_CAP_DV = new DataGridViewComboBoxColumn();
                NHA_CUNG_CAP_DV.Name = "NHA_CUNG_CAP";
                NHA_CUNG_CAP_DV.HeaderText = "NHA_CUNG_CAP";
                NHA_CUNG_CAP_DV.MinimumWidth = 120;
                NHA_CUNG_CAP_DV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                NHA_CUNG_CAP_DV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                NHA_CUNG_CAP_DV.Width = 120;

                NGAY_GIAO_HANG_DV = new Vietsoft.DataGridViewColumnEditor();

                NGAY_GIAO_HANG_DV.DataPropertyName = "NGAY_GIAO_HANG";
                NGAY_GIAO_HANG_DV.DataType = 4;
                // NGAY_GIAO_HANG_DV.DefaultCellStyle.Format = "dd/MM/yyyy";
                NGAY_GIAO_HANG_DV.FillWeight = 90F;
                NGAY_GIAO_HANG_DV.HeaderText = "NGAY_GIAO_HANG";
                NGAY_GIAO_HANG_DV.InPutMask = "00/00/0000";
                NGAY_GIAO_HANG_DV.MaxLength = 32700;
                NGAY_GIAO_HANG_DV.MinimumWidth = 90;
                NGAY_GIAO_HANG_DV.Name = "NGAY_GIAO_HANG";
                NGAY_GIAO_HANG_DV.StringFormat = "dd/MM/yyyy";
                NGAY_GIAO_HANG_DV.Width = 90;



                TEN_MAY_DV = new DataGridViewComboBoxColumn();
                TEN_MAY_DV.Name = "TEN_MAY";
                TEN_MAY_DV.HeaderText = "TEN_MAY";
                TEN_MAY_DV.MinimumWidth = 180;
                TEN_MAY_DV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                TEN_MAY_DV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                TEN_MAY_DV.Width = 180;
                TEN_MAY_DV.DropDownWidth = 200;


                TEN_N_XUONG_DV = new DataGridViewTextBoxColumn();
                TEN_N_XUONG_DV.Name = "TEN_N_XUONG";
                TEN_N_XUONG_DV.HeaderText = "TEN_N_XUONG";
                TEN_N_XUONG_DV.MinimumWidth = 120;
                TEN_N_XUONG_DV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                TEN_N_XUONG_DV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                TEN_N_XUONG_DV.Width = 120;

                LIFE_TIME_DV = new Vietsoft.DataGridViewColumnEditor();
                LIFE_TIME_DV.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                LIFE_TIME_DV.DataType = 2;
                LIFE_TIME_DV.HeaderText = "LIFE_TIME";
                LIFE_TIME_DV.InPutMask = "";
                LIFE_TIME_DV.MaxLength = 32700;
                LIFE_TIME_DV.MinimumWidth = 80;
                LIFE_TIME_DV.Name = "LIFE_TIME";
                LIFE_TIME_DV.StringFormat = "N0";
                LIFE_TIME_DV.Width = 80;

                BUYING_NEW_DV = new DataGridViewCheckBoxColumn();
                BUYING_NEW_DV.Name = "BUYING_NEW";
                BUYING_NEW_DV.HeaderText = "BUYING_NEW";
                BUYING_NEW_DV.MinimumWidth = 120;
                BUYING_NEW_DV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                BUYING_NEW_DV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                BUYING_NEW_DV.Width = 120;

                REPLACING_FOR_DV = new DataGridViewCheckBoxColumn();
                REPLACING_FOR_DV.Name = "REPLACING_FOR";
                REPLACING_FOR_DV.HeaderText = "REPLACING_FOR";
                REPLACING_FOR_DV.MinimumWidth = 120;
                REPLACING_FOR_DV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                REPLACING_FOR_DV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                REPLACING_FOR_DV.Width = 120;

                SPARE_DV = new DataGridViewCheckBoxColumn();
                SPARE_DV.Name = "SPARE";
                SPARE_DV.HeaderText = "SPARE";
                SPARE_DV.MinimumWidth = 120;
                SPARE_DV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                SPARE_DV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                SPARE_DV.Width = 120;

                MAINTENANCE_DV = new DataGridViewCheckBoxColumn();
                MAINTENANCE_DV.Name = "MAINTENANCE";
                MAINTENANCE_DV.HeaderText = "MAINTENANCE";
                MAINTENANCE_DV.MinimumWidth = 120;
                MAINTENANCE_DV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                MAINTENANCE_DV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                MAINTENANCE_DV.Width = 120;

                BY_WHOM_DV = new DataGridViewTextBoxColumn();
                BY_WHOM_DV.Name = "BY_WHOM";
                BY_WHOM_DV.HeaderText = "BY_WHOM";
                BY_WHOM_DV.MinimumWidth = 120;
                BY_WHOM_DV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                BY_WHOM_DV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                BY_WHOM_DV.Width = 120;

                TRANSFER_TO_DV = new DataGridViewComboBoxColumn();
                TRANSFER_TO_DV.Name = "TRANSFER_TO";
                TRANSFER_TO_DV.HeaderText = "TRANSFER_TO";
                TRANSFER_TO_DV.MinimumWidth = 120;
                TRANSFER_TO_DV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                TRANSFER_TO_DV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                TRANSFER_TO_DV.Width = 120;

                //DUONG_DAN_TL_DV = new DataGridViewTextBoxColumn();
                //DUONG_DAN_TL_DV.Name = "DUONG_DAN_TL";
                //DUONG_DAN_TL_DV.HeaderText = "DUONG_DAN_TL";
                //DUONG_DAN_TL_DV.MinimumWidth = 120;
                //DUONG_DAN_TL_DV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                //DUONG_DAN_TL_DV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                //DUONG_DAN_TL_DV.Width = 120;

                this.DgvDeXuatMuaHangDichVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                NHA_CUNG_CAP_DV, NGAY_GIAO_HANG_DV,TEN_MAY_DV,TEN_N_XUONG_DV, BUYING_NEW_DV,REPLACING_FOR_DV, SPARE_DV,MAINTENANCE_DV,
                LIFE_TIME_DV, BY_WHOM_DV, TRANSFER_TO_DV
                //, DUONG_DAN_TL_DV
                });
            }

            #endregion

            #region "An cot Vinh Hoan"
            if (Commons.Modules.sPrivate == "VINHHOAN")
            {
                try
                {
                    DgvDeXuatMuaHangDichVu.Columns["DON_GIA_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["NGOAI_TE_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["TY_GIA_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["TY_GIA_USD_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["THANH_TIEN_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["THANH_TIEN_VND_DV"].Visible = false;
                    DgvDeXuatMuaHangDichVu.Columns["THANH_TIEN_USD_DV"].Visible = false;

                }
                catch { }

                try
                {
                    DgvDeXuatMuaHangChiTiet.Columns["MS_PT_CTY"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["DON_GIA"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["TY_GIA"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["TY_GIA_USD"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["THANH_TIEN"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["THANH_TIEN_VND"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["THANH_TIEN_USD"].Visible = false;
                    DgvDeXuatMuaHangChiTiet.Columns["THUE_VAT"].Visible = false;
                }
                catch
                { }
            }
            #endregion

            #region "Chuyen Cot Trung nguyen"
            if (Commons.Modules.sPrivate == "TRUNGNGUYEN")
            {
                int iMsPT, iTT;
                iMsPT = DgvDeXuatMuaHangChiTiet.Columns["MS_PT"].DisplayIndex;
                iTT = DgvDeXuatMuaHangChiTiet.Columns["TEN_TRANG_THAI"].DisplayIndex;

                this.MS_PT.Frozen = false;
                DgvDeXuatMuaHangChiTiet.Columns["MS_PT"].DisplayIndex = iTT;
                DgvDeXuatMuaHangChiTiet.Columns["TEN_TRANG_THAI"].DisplayIndex = iMsPT;
                this.MS_PT_CTY.Frozen = true;

                DgvDeXuatMuaHangChiTiet.Columns["MS_PT_CTY"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DgvDeXuatMuaHangChiTiet.Columns["MS_PT_CTY"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            #endregion

        }
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// 
        private void LoadDXMH()
        {
            try
            {
                Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                TbDeXuatMuaHang = new System.Data.DataTable();

                int iTT = -1;
                try
                {
                    if (chkIsLock.Checked)
                    {
                        cboTinhTrang.EditValue = -1;
                        cboTinhTrang.Enabled = false;
                        iTT = 4;
                    }
                    else
                    {
                        cboTinhTrang.Enabled = true;
                        iTT = int.Parse(cboTinhTrang.EditValue.ToString());
                    }
                }
                catch { }
                TbDeXuatMuaHang.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_GET_DE_XUAT_MUA_HANG",
                        lokPhongBan.EditValue.ToString(), datFromDate.DateTime,
                        Convert.ToDateTime(datToDate.DateTime.AddDays(1).ToShortDateString()),
                        iTT, Commons.Modules.UserName));
                CNhapPT();
                foreach (DataColumn ClDeXuatMuaHang in TbDeXuatMuaHang.Columns)
                {
                    ClDeXuatMuaHang.AllowDBNull = true;
                }
                DateTime NgayHT = Commons.Modules.ObjSystems.GetNgayHeThong();
                TbDeXuatMuaHang.Columns["NGAY_LAP"].DefaultValue = NgayHT;
                TbDeXuatMuaHang.Columns["NGAY_DE_XUAT"].DefaultValue = NgayHT;
                TbDeXuatMuaHang.Columns["NGUOI_LAP"].DefaultValue = Commons.Modules.UserName;
                TbDeXuatMuaHang.Columns["THEO_YEU_CAU"].DefaultValue = false;
                TbDeXuatMuaHang.Columns["THEO_KE_HOACH"].DefaultValue = false;
                TbDeXuatMuaHang.Columns["TRANG_THAI"].DefaultValue = 1;
                TbDeXuatMuaHang.Columns["TEN_TRANG_THAI"].DefaultValue = sTT1DangSoan;
                //TbDeXuatMuaHang.Columns["MS_TT"].DefaultValue = 0;
                //TbDeXuatMuaHang.Columns["TEN_TTHAI"].DefaultValue = sTTDX;
                BindingDeXuatMuaHang.DataSource = TbDeXuatMuaHang;
                TbDeXuatMuaHang.TableNewRow += new DataTableNewRowEventHandler(TbDeXuatMuaHang_TableNewRow);
                isFirst = true;
                Commons.Modules.ObjSystems.MVisGrid(DgvDeXuatMuaHangChiTiet, this.Name.ToString(),
                    DgvDeXuatMuaHangChiTiet.Name.ToString(), Commons.Modules.UserName);
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            try { DoiMau(); }
            catch { }

        }
        private void InitializeDatabase()
        {
            Commons.Modules.SQLString = "0Load";
            DateTime NgayHT = Commons.Modules.ObjSystems.GetNgayHeThong();
            Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            datFromDate.DateTime = Convert.ToDateTime("01/" + NgayHT.Month + "/" + NgayHT.Year);
            datToDate.DateTime = NgayHT;
            System.Data.DataTable TbPhongBan = new System.Data.DataTable();

            TbPhongBan.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_GET_PHONG_BAN", Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(lokPhongBan, TbPhongBan, "MS_TO", "TEN_PHONG_BAN", "");
            lokPhongBan.EditValue = -1;

            string sTmp = "";
            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TTDangSoan", Commons.Modules.TypeLanguage);
            if (sTmp.Substring(0, 1) != "@" && sTmp.Substring(0, 1) != "?")
                sTT1DangSoan = sTmp;

            if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO")
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TTDuyetDeNghi", Commons.Modules.TypeLanguage);
            else
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TTTrinhDuyet", Commons.Modules.TypeLanguage);
            if (sTmp.Substring(0, 1) != "@" && sTmp.Substring(0, 1) != "?")
                sTT2TrinhDuyet = sTmp;

            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TTDuyet", Commons.Modules.TypeLanguage);
            if (sTmp.Substring(0, 1) != "@" && sTmp.Substring(0, 1) != "?")
                sTT3Duyet = sTmp;
            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TTDong", Commons.Modules.TypeLanguage);
            if (sTmp.Substring(0, 1) != "@" && sTmp.Substring(0, 1) != "?")
                sTT4Dong = sTmp;
            string sSql = "";
            sSql = " SELECT -1 AS MS_TT , N' < ALL > ' AS TEN_TT " +
                        " UNION SELECT 1 AS MS_TT , N'" + sTT1DangSoan + "' AS TEN_TT " +
                        " UNION SELECT 2 AS MS_TT , N'" + sTT2TrinhDuyet + "' AS TEN_TT " +
                        " UNION SELECT 3 AS MS_TT , N'" + sTT3Duyet + "' AS TEN_TT ORDER BY MS_TT ";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTinhTrang, sSql, "MS_TT", "TEN_TT", "");


            sSql = " SELECT 1 AS MS_TT , N'" + sTT1DangSoan + "' AS TEN_TT " +
                        " UNION SELECT 2 AS MS_TT , N'" + sTT2TrinhDuyet + "' AS TEN_TT " +
                        " UNION SELECT 3 AS MS_TT , N'" + sTT3Duyet + "' AS TEN_TT " +
                        " UNION SELECT 4 AS MS_TT , N'" + sTT4Dong + "' AS TEN_TT  ORDER BY MS_TT ";

            TbPhongBan = new System.Data.DataTable();
            TbPhongBan.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.Text, sSql));
            cboTTrang.DataSource = TbPhongBan;

            cboTTrang.ValueMember = "MS_TT";
            cboTTrang.DisplayMember = "TEN_TT";
            Commons.Modules.SQLString = "";
            LoadDXMH();



            BindingDeXuatMuaHang.CurrentChanged += new EventHandler(BindingDeXuatMuaHang_CurrentChanged);
            TbDeXuatMuaHang.TableNewRow += new DataTableNewRowEventHandler(TbDeXuatMuaHang_TableNewRow);
            DgvDeXuatMuaHang.AutoGenerateColumns = false;
            DgvDeXuatMuaHang.DataSource = BindingDeXuatMuaHang;
            DgvDeXuatMuaHang.Columns["MS_DE_XUAT"].DataPropertyName = "MS_DE_XUAT";


            TbPhongBan = new System.Data.DataTable();
            TbPhongBan.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_PHONG_BAN", Commons.Modules.UserName));
            CboPHONG_BAN.DataSource = TbPhongBan;
            CboPHONG_BAN.ValueMember = "MS_TO";
            CboPHONG_BAN.DisplayMember = "TEN_PHONG_BAN";
            CboPHONG_BAN.SelectedIndex = -1;

            string str = "	SELECT Distinct MS_DON_VI, MS_TO INTO #TO_USER FROM [dbo].[MGetDonViPhongBanUser]('" + Commons.Modules.UserName + "') " +
            " SELECT A.MS_CONG_NHAN AS NGUOI_TN, (HO + ' ' +  TEN)  AS HO_TEN, TEN FROM CONG_NHAN A " +
            " INNER JOIN TO_PHONG_BAN T1 ON T1.MS_TO = A.MS_TO " +
            " INNER JOIN #TO_USER T ON T1.MS_TO = T.MS_TO	AND T.MS_DON_VI = T1.MS_DON_VI 	 " +
            " UNION SELECT '','','' " +
            " ORDER BY TEN ";

            TbPhongBan = new System.Data.DataTable();
            TbPhongBan.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.Text, str));
            cboNGUOI_TN.DataSource = TbPhongBan;
            cboNGUOI_TN.ValueMember = "NGUOI_TN";
            cboNGUOI_TN.DisplayMember = "HO_TEN";
            cboNGUOI_TN.SelectedIndex = -1;

            System.Data.DataTable TbNhaCungCap1 = new System.Data.DataTable();
            TbNhaCungCap1.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NHA_CUNG_CAP"));
            DataRow dr = TbNhaCungCap1.NewRow();
            dr["MS_NCC"] = "";
            dr["TEN_NHA_CUNG_CAP"] = "";
            TbNhaCungCap1.Rows.Add(dr);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNCC, TbNhaCungCap1, "MS_NCC", "TEN_NHA_CUNG_CAP", "");
            cboNCC.EditValue = "";

            System.Data.DataTable tbKho = new System.Data.DataTable();
            tbKho.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "[SP_Y_GET_KHO_PT_NEW]"));
            cmbKho.DataSource = tbKho;
            cmbKho.ValueMember = "MS_KHO";
            cmbKho.DisplayMember = "TEN_KHO";
            System.Data.DataTable _table = new System.Data.DataTable();
            _table.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "[SP_Y_GET_LOAI_VT]"));
            cmbLoaiVT.ValueMember = "MS_LOAI_VT";
            cmbLoaiVT.DisplayMember = "TEN_VT";
            cmbLoaiVT.SelectedValue = -1;
            cmbLoaiVT.DataSource = _table;
            BindingControl();

            if (Commons.Modules.sPrivate == "VECO")
            {
                TbDeXuatMuaHangChiTiet.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DE_XUAT_MUA_HANG_CHI_TIET_VECO"));
            }
            else
            {
                TbDeXuatMuaHangChiTiet.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DE_XUAT_MUA_HANG_CHI_TIET"));
            }
            foreach (DataColumn ClDeXuatMuaHangChiTiet in TbDeXuatMuaHangChiTiet.Columns)
                ClDeXuatMuaHangChiTiet.AllowDBNull = true;
            try
            {
                TbDeXuatMuaHangChiTiet.Columns["MS_DE_XUAT"].DefaultValue = ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["MS_DE_XUAT"];
                TbDeXuatMuaHangChiTiet.DefaultView.RowFilter = "MS_DE_XUAT = '" + ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["MS_DE_XUAT"].ToString().Trim() + "'";
            }
            catch
            {
                TbDeXuatMuaHangChiTiet.DefaultView.RowFilter = "0=1";
            }
            System.Data.DataTable TbHangSanXuat = new System.Data.DataTable();
            TbHangSanXuat.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_HANG_SAN_XUAT"));
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["HANG_SX"]).DataSource = TbHangSanXuat;
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["HANG_SX"]).ValueMember = "TEN_HANG_SAN_XUAT";
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["HANG_SX"]).DisplayMember = "TEN_HANG_SAN_XUAT";


            System.Data.DataTable TbNgoaiTe = new System.Data.DataTable();
            TbNgoaiTe.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NGOAI_TE"));
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE"]).DataSource = TbNgoaiTe;
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE"]).ValueMember = "TEN_NGOAI_TE";
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE"]).DisplayMember = "TEN_NGOAI_TE";

            System.Data.DataTable TbNhaCungCap = new System.Data.DataTable();
            TbNhaCungCap.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NHA_CUNG_CAP"));
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NHA_CUNG_CAP"]).DataSource = TbNhaCungCap;
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NHA_CUNG_CAP"]).ValueMember = "TEN_NHA_CUNG_CAP";
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NHA_CUNG_CAP"]).DisplayMember = "TEN_NHA_CUNG_CAP";

            System.Data.DataTable TbNhaCungCapCuoi = new System.Data.DataTable();
            TbNhaCungCapCuoi.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NHA_CUNG_CAP"));
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NHA_CUNG_CAP_CUOI"]).DataSource = TbNhaCungCapCuoi;
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NHA_CUNG_CAP_CUOI"]).ValueMember = "TEN_NHA_CUNG_CAP";
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NHA_CUNG_CAP_CUOI"]).DisplayMember = "TEN_NHA_CUNG_CAP";

            System.Data.DataTable TbNgoaiTeCuoi = new System.Data.DataTable();
            TbNgoaiTeCuoi.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NGOAI_TE"));
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE_CUOI"]).DataSource = TbNgoaiTeCuoi;
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE_CUOI"]).ValueMember = "TEN_NGOAI_TE";
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE_CUOI"]).DisplayMember = "TEN_NGOAI_TE";


            System.Data.DataTable TbMAY = new System.Data.DataTable();
            System.Data.DataTable TbCNhan = new System.Data.DataTable();

            //HN--------------------------------------------------------------------------------
            if (Commons.Modules.sPrivate == "VECO")
            {
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["TEN_N_XUONG"]).DataSource = Commons.Modules.ObjSystems.MLoadDataNhaXuong(0);
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["TEN_N_XUONG"]).ValueMember = "TEN_N_XUONG";
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["TEN_N_XUONG"]).DisplayMember = "TEN_N_XUONG";

                TbMAY.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "GetMayUserALL", Commons.Modules.UserName, "-1", -1, -1, "-1", "-1", "-1", DateTime.Now, Commons.Modules.TypeLanguage));
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["TEN_MAY"]).DataSource = TbMAY;
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["TEN_MAY"]).ValueMember = "MS_MAY";
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["TEN_MAY"]).DisplayMember = "MS_MAY";

                System.Data.DataTable TbTransfer = new System.Data.DataTable();
                TbTransfer.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "GetTRANSFER_TO"));
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["TRANSFER_TO"]).DataSource = TbTransfer;
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["TRANSFER_TO"]).ValueMember = "TRANSFER_TO_NAME";
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["TRANSFER_TO"]).DisplayMember = "TRANSFER_TO_NAME";

                //TbCNhan.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.Text, "SELECT MS_CONG_NHAN, HO + ' ' +  TEN AS HO_TEN FROM dbo.CONG_NHAN"));
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["BY_WHOM"]).DataSource = TbCNhan;
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["BY_WHOM"]).ValueMember = "MS_CONG_NHAN";
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns["BY_WHOM"]).DisplayMember = "HO_TEN";
            }
            DgvDeXuatMuaHangChiTiet.AutoGenerateColumns = false;
            DgvDeXuatMuaHangChiTiet.DataSource = TbDeXuatMuaHangChiTiet.DefaultView;

            foreach (DataGridViewColumn ClDeXuatMuaHangChiTiet in DgvDeXuatMuaHangChiTiet.Columns)
            {
                ClDeXuatMuaHangChiTiet.DataPropertyName = ClDeXuatMuaHangChiTiet.Name;
            }
            if (Commons.Modules.sPrivate == "VECO")
            {
                TbDeXuatMuaHangDichVu.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DE_XUAT_MUA_HANG_DICH_VU_VECO"));

            }
            else
            {
                TbDeXuatMuaHangDichVu.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DE_XUAT_MUA_HANG_DICH_VU"));
            }

            foreach (DataColumn ClDeXuatMuaHangDichVu in TbDeXuatMuaHangDichVu.Columns)
            {
                ClDeXuatMuaHangDichVu.AllowDBNull = true;
            }
            try
            {
                TbDeXuatMuaHangDichVu.Columns["MS_DE_XUAT"].DefaultValue = ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["MS_DE_XUAT"];
                TbDeXuatMuaHangDichVu.DefaultView.RowFilter = "MS_DE_XUAT = '" + ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["MS_DE_XUAT"].ToString().Trim() + "'";
            }
            catch
            {
                TbDeXuatMuaHangDichVu.DefaultView.RowFilter = "0=1";
            }
            TbDeXuatMuaHangDichVu.TableNewRow += new DataTableNewRowEventHandler(TbDeXuatMuaHangDichVu_TableNewRow);
            System.Data.DataTable TbNgoaiTeDichVu = new System.Data.DataTable();
            TbNgoaiTeDichVu.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NGOAI_TE"));
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["NGOAI_TE_DV"]).DataSource = TbNgoaiTeDichVu;
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["NGOAI_TE_DV"]).ValueMember = "TEN_NGOAI_TE";
            ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["NGOAI_TE_DV"]).DisplayMember = "TEN_NGOAI_TE";

            //HN--------------------------------------------------------------------------------
            if (Commons.Modules.sPrivate == "VECO")
            {
                TbMAY = new System.Data.DataTable();
                TbMAY.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "GetMayUserALL", Commons.Modules.UserName, "-1", -1, -1, "-1", "-1", "-1", DateTime.Now, Commons.Modules.TypeLanguage));
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["TEN_MAY"]).DataSource = TbMAY;
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["TEN_MAY"]).ValueMember = "MS_MAY";
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["TEN_MAY"]).DisplayMember = "MS_MAY";

                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["TEN_N_XUONG"]).DataSource = Commons.Modules.ObjSystems.MLoadDataNhaXuong(0);
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["TEN_N_XUONG"]).ValueMember = "TEN_N_XUONG";
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["TEN_N_XUONG"]).DisplayMember = "TEN_N_XUONG";

                System.Data.DataTable tbNhaCC = new System.Data.DataTable();
                tbNhaCC.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NHA_CUNG_CAP"));
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["NHA_CUNG_CAP"]).DataSource = tbNhaCC;
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["NHA_CUNG_CAP"]).ValueMember = "TEN_NHA_CUNG_CAP";
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["NHA_CUNG_CAP"]).DisplayMember = "TEN_NHA_CUNG_CAP";

                System.Data.DataTable TbTransfer1 = new System.Data.DataTable();
                TbTransfer1.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "GetTRANSFER_TO"));
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["TRANSFER_TO"]).DataSource = TbTransfer1;
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["TRANSFER_TO"]).ValueMember = "TRANSFER_TO_NAME";
                ((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["TRANSFER_TO"]).DisplayMember = "TRANSFER_TO_NAME";

                //TbCNhan = new System.Data.DataTable();
                //TbCNhan.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.Text, "SELECT MS_CONG_NHAN, HO + ' ' +  TEN AS HO_TEN FROM dbo.CONG_NHAN"));
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["BY_WHOM"]).DataSource = TbCNhan;
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["BY_WHOM"]).ValueMember = "MS_CONG_NHAN";
                //((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns["BY_WHOM"]).DisplayMember = "HO_TEN";
            }
            DgvDeXuatMuaHangDichVu.AutoGenerateColumns = false;
            DgvDeXuatMuaHangDichVu.DataSource = TbDeXuatMuaHangDichVu.DefaultView;
            foreach (DataGridViewColumn ClDeXuatMuaHangDichVu in DgvDeXuatMuaHangDichVu.Columns)
            {
                ClDeXuatMuaHangDichVu.DataPropertyName = ClDeXuatMuaHangDichVu.Name.Replace("_DV", String.Empty);
            }

            TbDuyetDeXuatMuaHang.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DUYET_DE_XUAT_MUA_HANG"));
            foreach (DataColumn ClDuyetDeXuatMuaHang in TbDuyetDeXuatMuaHang.Columns)
            {
                ClDuyetDeXuatMuaHang.AllowDBNull = true;
            }
            try
            {
                TbDuyetDeXuatMuaHang.Columns["MS_DE_XUAT"].DefaultValue = ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["MS_DE_XUAT"];
                TbDuyetDeXuatMuaHang.DefaultView.RowFilter = "MS_DE_XUAT = '" + ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["MS_DE_XUAT"].ToString().Trim() + "'";
            }
            catch
            {
                TbDuyetDeXuatMuaHang.DefaultView.RowFilter = "0=1";
            }
            System.Data.DataTable TbNguoiDuyet = new System.Data.DataTable();
            TbNguoiDuyet.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_NGUOI_DUYET"));
            ((DataGridViewComboBoxColumn)DgvDuyetDeXuatMuaHang.Columns["NGUOI_DUYET"]).DataSource = TbNguoiDuyet;
            ((DataGridViewComboBoxColumn)DgvDuyetDeXuatMuaHang.Columns["NGUOI_DUYET"]).ValueMember = "USERNAME";
            ((DataGridViewComboBoxColumn)DgvDuyetDeXuatMuaHang.Columns["NGUOI_DUYET"]).DisplayMember = "TEN_NGUOI_DUYET";

            TbNguoiDuyet = new System.Data.DataTable();
            TbNguoiDuyet.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.Text, "SELECT A.USERNAME AS MS_CN, B.HO + ' ' +  B.TEN AS HO_TEN FROM dbo.USERS AS A INNER JOIN dbo.CONG_NHAN AS B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN UNION SELECT '-1','' UNION SELECT '','' "));
            TbNguoiDuyet.Columns["MS_CN"].AllowDBNull = true;
            ((DataGridViewComboBoxColumn)DgvDuyetDeXuatMuaHang.Columns["MS_CN"]).DataSource = TbNguoiDuyet;
            ((DataGridViewComboBoxColumn)DgvDuyetDeXuatMuaHang.Columns["MS_CN"]).ValueMember = "MS_CN";
            ((DataGridViewComboBoxColumn)DgvDuyetDeXuatMuaHang.Columns["MS_CN"]).DisplayMember = "HO_TEN";

            System.Data.DataTable TbDonVi = new System.Data.DataTable();
            TbDonVi.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_VI"));
            ((DataGridViewComboBoxColumn)DgvDuyetDeXuatMuaHang.Columns["DON_VI"]).DataSource = TbDonVi;
            ((DataGridViewComboBoxColumn)DgvDuyetDeXuatMuaHang.Columns["DON_VI"]).ValueMember = "TEN_DON_VI";
            ((DataGridViewComboBoxColumn)DgvDuyetDeXuatMuaHang.Columns["DON_VI"]).DisplayMember = "TEN_DON_VI";

            DgvDuyetDeXuatMuaHang.AutoGenerateColumns = false;
            DgvDuyetDeXuatMuaHang.DataSource = TbDuyetDeXuatMuaHang.DefaultView;
            foreach (DataGridViewColumn ClDuyetDeXuatMuaHang in DgvDuyetDeXuatMuaHang.Columns)
            {
                ClDuyetDeXuatMuaHang.DataPropertyName = ClDuyetDeXuatMuaHang.Name;
            }

        }

        private void DgvDeXuatMuaHang_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(DgvDeXuatMuaHang.Rows[e.RowIndex].Cells[DgvDeXuatMuaHang.ColumnCount - 1].Value) == 1)
                    DgvDeXuatMuaHang[DgvDeXuatMuaHang.ColumnCount - 2, e.RowIndex].Style.BackColor = Color.Beige;
                if (Convert.ToInt32(DgvDeXuatMuaHang.Rows[e.RowIndex].Cells[DgvDeXuatMuaHang.ColumnCount - 1].Value) == 0)
                    DgvDeXuatMuaHang[DgvDeXuatMuaHang.ColumnCount - 2, e.RowIndex].Style.BackColor = Color.Bisque;
            }
            catch { }
        }

        //private void DgvDeXuatMuaHangChiTiet_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        //{
        //    try
        //    {
        //        //if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED")
        //        //{
        //        //    //. Những vật tư nào đạt quá tồn max thì hiện màu đỏ còn vật tư không có qui định tồn max và tồn min mà đặt hàng thì hiện màu vàng.Làm như vậy trước khi duyệt Sang sẽ hỏi lại A / e phía dưới.
        //        //    double dMin, dMax, dDXuat;
        //        //    try
        //        //    {
        //        //        dDXuat = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["SL_DE_XUAT"].Value);
        //        //    }
        //        //    catch { dDXuat = 0; }

        //        //    try
        //        //    {
        //        //        dMin = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TON_MIN"].Value);
        //        //    }
        //        //    catch { dMin = 0; }

        //        //    try
        //        //    {
        //        //        dMax = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TON_MAX"].Value);
        //        //    }
        //        //    catch { dMax = 0; }
        //        //    try
        //        //    {
        //        //        if (dDXuat > dMax)
        //        //            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
        //        //    }
        //        //    catch { DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; }


        //        //    try
        //        //    {
        //        //        if (dMax == 0 && dMin == 0)
        //        //            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
        //        //    }
        //        //    catch
        //        //    {
        //        //        DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        //        //    }
        //        //}

        //        //if (Convert.ToInt32(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells[DgvDeXuatMuaHangChiTiet.ColumnCount - 1].Value) == 1)
        //        //    DgvDeXuatMuaHangChiTiet[DgvDeXuatMuaHangChiTiet.ColumnCount - 2, e.RowIndex].Style.BackColor = Color.Beige;
        //        //if (Convert.ToInt32(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells[DgvDeXuatMuaHangChiTiet.ColumnCount - 1].Value) == 0)
        //        //    DgvDeXuatMuaHangChiTiet[DgvDeXuatMuaHangChiTiet.ColumnCount - 2, e.RowIndex].Style.BackColor = Color.Bisque;



        //    }
        //    catch { }
        //}
        /// <summary>
        /// Điều khiển form
        /// </summary>
        private void InitializeForm()
        {
            MskNGAY_LAP.Enabled = false;
            TxtNGUOI_LAP.Enabled = false;
            MskNGAY_SUA.Enabled = false;
            TxtNGUOI_SUA.Enabled = false;
            MskNGAY_DUYET.Enabled = false;
            TxtNGUOI_DUYET.Enabled = false;
            cboTTrang.Enabled = false;

            TxtMS_DE_XUAT.Enabled = false;
            bCoDuyet = false;

            switch (TrangThai)
            {
                case "Add":
                case "Edit":
                    if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO" || (int)((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"] != 2)
                    {
                        TxtSO_DE_XUAT.Enabled = true;
                        txtTimKiem.Enabled = false;
                        //btnTimCX.Enabled = false;
                        CboPHONG_BAN.Enabled = true;
                        cboNGUOI_TN.Enabled = true;
                        cmbKho.Enabled = true;
                        cmbLoaiVT.Enabled = true;
                        MskNGAY_DE_XUAT.Enabled = true;
                        TxtNGUOI_DE_XUAT.Enabled = true;
                        MskNGAY_NHAN.Enabled = true;
                        TxtNGUOI_NHAN.Enabled = true;
                        MskNGAY_GIAO.Enabled = true;
                        TxtNGUOI_GIAO.Enabled = true;
                        TxtGHI_CHU.Enabled = true;
                        cboNCC.Enabled = true;
                        ChkTHEO_YEU_CAU.Enabled = true;
                        ChkTHEO_KE_HOACH.Enabled = true;
                        BtnChonPT.Visible = true;
                        btnAuto.Visible = true;
                        if (TrangThai == "Add")
                        {
                            BtnCopy.Visible = true;
                        }
                        else
                        {
                            BtnCopy.Visible = false;
                        }
                    }
                    DgvDeXuatMuaHang.ReadOnly = true;
                    DgvDeXuatMuaHang.Enabled = false;

                    DgvDeXuatMuaHangChiTiet.Enabled = true;
                    DgvDeXuatMuaHangChiTiet.ReadOnly = false;
                    DgvDeXuatMuaHangChiTiet.AllowUserToDeleteRows = false;
                    foreach (DataGridViewColumn ClDeXuatMuaHangChiTiet in DgvDeXuatMuaHangChiTiet.Columns)
                    {
                        ClDeXuatMuaHangChiTiet.ReadOnly = true;
                    }
                    DgvDeXuatMuaHangChiTiet.Columns["NHA_CUNG_CAP"].ReadOnly = false;
                    DgvDeXuatMuaHangChiTiet.Columns["NHAN_HIEU"].ReadOnly = false;
                    DgvDeXuatMuaHangChiTiet.Columns["HANG_SX"].ReadOnly = false;
                    DgvDeXuatMuaHangChiTiet.Columns["CONG_DUNG"].ReadOnly = false;
                    DgvDeXuatMuaHangChiTiet.Columns["HAN_SU_DUNG"].ReadOnly = false;
                    if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO" || (int)((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"] != 2)
                    {
                        DgvDeXuatMuaHangChiTiet.Columns["SL_DE_XUAT"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["SL_DA_DUYET"].ReadOnly = false;
                    }
                    DgvDeXuatMuaHangChiTiet.Columns["DON_GIA"].ReadOnly = false;
                    DgvDeXuatMuaHangChiTiet.Columns["THUE_VAT"].ReadOnly = false;
                    if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED")
                    {
                        DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE"].ReadOnly = true;
                        DgvDeXuatMuaHangChiTiet.Columns["TY_GIA"].ReadOnly = true;
                    }
                    else
                    {
                        DgvDeXuatMuaHangChiTiet.Columns["NGOAI_TE"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["TY_GIA"].ReadOnly = false;
                    }
                    DgvDeXuatMuaHangChiTiet.Columns["TY_GIA_USD"].ReadOnly = false;
                    DgvDeXuatMuaHangChiTiet.Columns["GHI_CHU"].ReadOnly = false;
                    DgvDeXuatMuaHangChiTiet.Columns["PART_NO"].ReadOnly = false;
                    DgvDeXuatMuaHangChiTiet.Columns["QUY_CACH"].ReadOnly = false;
                    DgvDeXuatMuaHangChiTiet.Columns["NGAY_GIAO_HANG"].ReadOnly = false;



                    if (Commons.Modules.sPrivate.ToUpper() == "VECO")
                    {
                        DgvDeXuatMuaHangChiTiet.Columns["BUYING_NEW"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["REPLACING_FOR"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["SPARE"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["MAINTENANCE"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["TEN_MAY"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["LIFE_TIME"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["BY_WHOM"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["TRANSFER_TO"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["DUONG_DAN_TL"].ReadOnly = false;
                        DgvDeXuatMuaHangChiTiet.Columns["TEN_N_XUONG"].ReadOnly = false;
                    }

                    DgvDeXuatMuaHangDichVu.Enabled = true;
                    DgvDeXuatMuaHangDichVu.ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.AllowUserToAddRows = true;
                    DgvDeXuatMuaHangDichVu.AllowUserToDeleteRows = false;
                    foreach (DataGridViewColumn ClDeXuatMuaHangDichVu in DgvDeXuatMuaHangDichVu.Columns)
                    {
                        ClDeXuatMuaHangDichVu.ReadOnly = true;
                    }

                    DgvDeXuatMuaHangDichVu.Columns["TEN_DICH_VU_DV"].ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.Columns["DVT_DV"].ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.Columns["SL_DE_XUAT_DV"].ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.Columns["DON_GIA_DV"].ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.Columns["NGOAI_TE_DV"].ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.Columns["TY_GIA_DV"].ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.Columns["TY_GIA_USD_DV"].ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.Columns["GHI_CHU_DV"].ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.Columns["LY_DO"].ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.Columns["NGAY_DX"].ReadOnly = false;
                    DgvDeXuatMuaHangDichVu.Columns["DUONG_DAN_TL"].ReadOnly = false;


                    if (Commons.Modules.sPrivate.ToUpper() == "VECO")
                    {
                        DgvDeXuatMuaHangDichVu.Columns["NHA_CUNG_CAP"].ReadOnly = false;
                        DgvDeXuatMuaHangDichVu.Columns["NGAY_GIAO_HANG"].ReadOnly = false;
                        DgvDeXuatMuaHangDichVu.Columns["TEN_N_XUONG"].ReadOnly = false;
                        DgvDeXuatMuaHangDichVu.Columns["TEN_MAY"].ReadOnly = false;
                        DgvDeXuatMuaHangDichVu.Columns["LIFE_TIME"].ReadOnly = false;
                        DgvDeXuatMuaHangDichVu.Columns["BUYING_NEW"].ReadOnly = false;
                        DgvDeXuatMuaHangDichVu.Columns["REPLACING_FOR"].ReadOnly = false;
                        DgvDeXuatMuaHangDichVu.Columns["SPARE"].ReadOnly = false;
                        DgvDeXuatMuaHangDichVu.Columns["MAINTENANCE"].ReadOnly = false;
                        DgvDeXuatMuaHangDichVu.Columns["BY_WHOM"].ReadOnly = false;
                        DgvDeXuatMuaHangDichVu.Columns["TRANSFER_TO"].ReadOnly = false;
                    }




                    DgvDuyetDeXuatMuaHang.Enabled = true;
                    DgvDuyetDeXuatMuaHang.ReadOnly = false;
                    foreach (DataGridViewColumn ClDuyetDeXuatMuaHang in DgvDuyetDeXuatMuaHang.Columns)
                    {
                        ClDuyetDeXuatMuaHang.ReadOnly = true;
                    }
                    DgvDuyetDeXuatMuaHang.Columns["NOI_DUNG"].ReadOnly = false;
                    DgvDuyetDeXuatMuaHang.Columns["DUYET"].ReadOnly = false;

                    BtnLuu.Visible = true;
                    BtnHuy.Visible = true;
                    BtnThem.Visible = false;
                    if (bCNDuyet) btnCNDuyet.Visible = true; else btnCNDuyet.Visible = false;
                    BtnSua.Visible = false;
                    BtnXoa.Visible = false;
                    if (Commons.Modules.sPrivate.Trim().ToUpper() == "CS") btnPrintImage.Visible = false;
                    BtnIn.Visible = false;
                    BtnThoat.Visible = false;
                    BtnDong.Visible = false;
                    if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO") BtnTrinhDuyet.Visible = false;
                    if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO") btnDeNghi.Visible = false;

                    btnPhieumuonhang.Visible = false;
                    break;
                default:
                    TxtSO_DE_XUAT.Enabled = false;
                    txtTimKiem.Enabled = true;
                    //btnTimCX.Enabled = true;

                    CboPHONG_BAN.Enabled = false;
                    cboNGUOI_TN.Enabled = false;
                    cmbKho.Enabled = false;
                    cmbLoaiVT.Enabled = false;
                    MskNGAY_DE_XUAT.Enabled = false;
                    TxtNGUOI_DE_XUAT.Enabled = false;
                    MskNGAY_NHAN.Enabled = false;
                    TxtNGUOI_NHAN.Enabled = false;
                    MskNGAY_GIAO.Enabled = false;
                    TxtNGUOI_GIAO.Enabled = false;
                    TxtGHI_CHU.Enabled = false;
                    cboNCC.Enabled = false;
                    ChkTHEO_YEU_CAU.Enabled = false;
                    ChkTHEO_KE_HOACH.Enabled = false;

                    DgvDeXuatMuaHang.ReadOnly = true;
                    DgvDeXuatMuaHang.Enabled = true;

                    DgvDeXuatMuaHangChiTiet.Enabled = true;
                    DgvDeXuatMuaHangChiTiet.ReadOnly = true;
                    DgvDeXuatMuaHangChiTiet.AllowUserToDeleteRows = true;

                    DgvDeXuatMuaHangDichVu.Enabled = true;
                    DgvDeXuatMuaHangDichVu.ReadOnly = true;
                    DgvDeXuatMuaHangDichVu.AllowUserToAddRows = false;
                    DgvDeXuatMuaHangDichVu.AllowUserToDeleteRows = true;

                    DgvDuyetDeXuatMuaHang.Enabled = true;
                    DgvDuyetDeXuatMuaHang.ReadOnly = true;

                    BtnLuu.Visible = false;


                    BtnHuy.Visible = false;
                    BtnThem.Visible = true;
                    if (bCNDuyet) btnCNDuyet.Visible = true; else btnCNDuyet.Visible = false;
                    BtnChonPT.Visible = false;
                    btnAuto.Visible = false;
                    BtnCopy.Visible = false;
                    BtnThoat.Visible = true;
                    if (BindingDeXuatMuaHang.Count > 0)
                    {
                        BtnSua.Visible = true;
                        BtnXoa.Visible = true;
                        BtnIn.Visible = true;
                        if (Commons.Modules.sPrivate.Trim().ToUpper() == "CS") btnPrintImage.Visible = true;
                        BtnDong.Visible = true;

                        if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO") BtnTrinhDuyet.Visible = true;
                        if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO") btnDeNghi.Visible = true;


                        btnPhieumuonhang.Visible = true;
                    }
                    else
                    {
                        BtnSua.Visible = false;
                        BtnXoa.Visible = false;
                        BtnIn.Visible = false;
                        if (Commons.Modules.sPrivate.Trim().ToUpper() == "CS") btnPrintImage.Visible = false;
                        BtnDong.Visible = false;

                        if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO") BtnTrinhDuyet.Visible = false;
                        if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO") btnDeNghi.Visible = false;

                        btnPhieumuonhang.Visible = false;
                    }
                    break;
            }
            InitializeControl();

        }
        /// <summary>
        /// Gắn source
        /// </summary>
        private void BindingControl()
        {
            TxtMS_DE_XUAT.DataBindings.Clear();
            TxtMS_DE_XUAT.DataBindings.Add("Text", BindingDeXuatMuaHang, "MS_DE_XUAT");
            TxtSO_DE_XUAT.DataBindings.Clear();
            TxtSO_DE_XUAT.DataBindings.Add("Text", BindingDeXuatMuaHang, "SO_DE_XUAT");

            CboPHONG_BAN.DataBindings.Clear();
            try
            {
                CboPHONG_BAN.DataBindings.Add("SelectedValue", BindingDeXuatMuaHang, "MS_TO");
            }
            catch { CboPHONG_BAN.SelectedValue = "-1"; }

            cboNGUOI_TN.DataBindings.Clear();
            try
            {
                cboNGUOI_TN.DataBindings.Add("SelectedValue", BindingDeXuatMuaHang, "NGUOI_TN");
            }
            catch { cboNGUOI_TN.SelectedValue = "-1"; }

            cmbKho.DataBindings.Clear();
            try
            {
                cmbKho.DataBindings.Add("SelectedValue", BindingDeXuatMuaHang, "MS_Kho");
            }
            catch { cmbKho.SelectedValue = "-1"; }
            cmbLoaiVT.DataBindings.Clear();

            try
            {
                cmbLoaiVT.DataBindings.Add("SelectedValue", BindingDeXuatMuaHang, "MS_LOAI_VT");
            }
            catch
            {
                cmbLoaiVT.SelectedValue = "-1";
            }

            cboNCC.DataBindings.Clear();
            try
            {
                cboNCC.DataBindings.Add("EditValue", BindingDeXuatMuaHang, "MS_NCC");
            }
            catch { cboNCC.EditValue = ""; }

            MskNGAY_DE_XUAT.DataBindings.Clear();
            MskNGAY_DE_XUAT.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGAY_DE_XUAT");
            TxtNGUOI_DE_XUAT.DataBindings.Clear();
            TxtNGUOI_DE_XUAT.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGUOI_DE_XUAT");
            MskNGAY_NHAN.DataBindings.Clear();
            MskNGAY_NHAN.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGAY_NHAN");
            TxtNGUOI_NHAN.DataBindings.Clear();
            TxtNGUOI_NHAN.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGUOI_NHAN");
            MskNGAY_GIAO.DataBindings.Clear();
            MskNGAY_GIAO.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGAY_GIAO");
            TxtNGUOI_GIAO.DataBindings.Clear();
            TxtNGUOI_GIAO.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGUOI_GIAO");
            TxtGHI_CHU.DataBindings.Clear();
            TxtGHI_CHU.DataBindings.Add("Text", BindingDeXuatMuaHang, "GHI_CHU");
            MskNGAY_LAP.DataBindings.Clear();
            MskNGAY_LAP.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGAY_LAP");
            TxtNGUOI_LAP.DataBindings.Clear();
            TxtNGUOI_LAP.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGUOI_LAP");
            MskNGAY_SUA.DataBindings.Clear();
            MskNGAY_SUA.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGAY_SUA");
            TxtNGUOI_SUA.DataBindings.Clear();
            TxtNGUOI_SUA.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGUOI_SUA");
            MskNGAY_DUYET.DataBindings.Clear();
            MskNGAY_DUYET.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGAY_DUYET");
            TxtNGUOI_DUYET.DataBindings.Clear();
            TxtNGUOI_DUYET.DataBindings.Add("Text", BindingDeXuatMuaHang, "NGUOI_DUYET");
            try
            {
                txtKEY_DUYET.DataBindings.Clear();
                txtKEY_DUYET.DataBindings.Add("Text", BindingDeXuatMuaHang, "KEY_DUYET");
            }
            catch { }
            try
            {
                cboTTrang.DataBindings.Clear();
                cboTTrang.DataBindings.Add("SelectedValue", BindingDeXuatMuaHang, "TRANG_THAI");
            }
            catch { }
            ChkTHEO_YEU_CAU.DataBindings.Clear();
            ChkTHEO_YEU_CAU.DataBindings.Add("Checked", BindingDeXuatMuaHang, "THEO_YEU_CAU");
            ChkTHEO_KE_HOACH.DataBindings.Clear();
            ChkTHEO_KE_HOACH.DataBindings.Add("Checked", BindingDeXuatMuaHang, "THEO_KE_HOACH");
        }
        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        void TbDeXuatMuaHang_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (e.Row["MS_DE_XUAT"].ToString() == "")
            {
                e.Row["MS_DE_XUAT"] = Vietsoft.Information.GetID("DX");

                if (Commons.Modules.iDefault == 1 | Commons.Modules.iDefault == 2) e.Row["SO_DE_XUAT"] = e.Row["MS_DE_XUAT"];


                try
                {
                    System.Data.DataTable dtTmp = new System.Data.DataTable();
                    string sSql = "SELECT TOP 1 A.MS_TO, TEN_TO FROM dbo.USERS A INNER JOIN TO_PHONG_BAN B ON A.MS_TO = B.MS_TO " +
                                    " WHERE     (USERNAME = '" + Commons.Modules.UserName + "') ";
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    try
                    {
                        if (dtTmp.Rows.Count > 0)
                        {
                            e.Row["MS_TO"] = dtTmp.Rows[0][0].ToString();
                            e.Row["PHONG_BAN"] = dtTmp.Rows[0][1].ToString();
                        }
                    }
                    catch
                    {
                        CboPHONG_BAN.SelectedValue = "";
                        CboPHONG_BAN.Text = "";
                    }
                    DateTime NgayIn = Commons.Modules.ObjSystems.GetNgayHeThong();

                    e.Row["NGAY_DE_XUAT"] = NgayIn.ToShortDateString();
                    e.Row["NGAY_NHAN"] = NgayIn.ToShortDateString();
                    e.Row["NGUOI_DE_XUAT"] = Commons.Modules.sTenNhanVienMD;

                    if (Commons.Modules.iMaKhoMD != -1) e.Row["MS_KHO"] = Commons.Modules.iMaKhoMD;


                }
                catch { }


            }
        }
        void TbDeXuatMuaHangDichVu_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["MS_DICH_VU"] = Vietsoft.Information.GetID("DV");
        }
        /// <summary>
        /// Chọn dữ liệu mới
        /// </summary>        
        void BindingDeXuatMuaHang_CurrentChanged(object sender, EventArgs e)
        {

            try
            {
                TbDeXuatMuaHangChiTiet.Columns["MS_DE_XUAT"].DefaultValue = ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"];
                TbDeXuatMuaHangChiTiet.DefaultView.RowFilter = "MS_DE_XUAT = '" + ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"].ToString().Trim() + "'";
            }
            catch
            {
                TbDeXuatMuaHangChiTiet.DefaultView.RowFilter = "0=1";
            }
            try
            {
                TbDeXuatMuaHangDichVu.Columns["MS_DE_XUAT"].DefaultValue = ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"];
                TbDeXuatMuaHangDichVu.DefaultView.RowFilter = "MS_DE_XUAT = '" + ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"].ToString().Trim() + "'";
            }
            catch
            {
                TbDeXuatMuaHangDichVu.DefaultView.RowFilter = "0=1";
            }
            try
            {
                TbDuyetDeXuatMuaHang.Columns["MS_DE_XUAT"].DefaultValue = ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"];
                TbDuyetDeXuatMuaHang.DefaultView.RowFilter = "MS_DE_XUAT = '" + ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"].ToString().Trim() + "'";
            }
            catch
            {
                TbDuyetDeXuatMuaHang.DefaultView.RowFilter = "0=1";
            }
            //TbDeXuatMuaHangChiTiet.Columns["MS_TTHAI"].DefaultValue = 0;
            //TbDeXuatMuaHangChiTiet.Columns["TEN_TRANG_THAI"].DefaultValue = sTTDX;
            InitializeForm();
            DoiMau();
        }

        private void InitializeControl()
        {
            if ("GREENFEED" == Commons.Modules.sPrivate) BtnIn.Visible = false;
            Vietsoft.SqlInfo SqlDuyetDeXuat = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            btnKhongDuyet.Visible = false;
            if (TrangThai != "Add" && TrangThai != "Edit")
            {
                if (BindingDeXuatMuaHang.Current != null)
                {
                    switch ((int)((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"])
                    {
                        case 4:
                            BtnSua.Visible = false;
                            btnKhongDuyet.Visible = false;
                            btnCNDuyet.Visible = false;
                            BtnXoa.Visible = false;

                            if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO") BtnTrinhDuyet.Visible = false;
                            if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO") btnDeNghi.Visible = false;
                            if (Commons.Modules.sPrivate.Trim().ToUpper() == "GREENFEED") BtnIn.Visible = true;
                            BtnDong.Visible = false;
                            btnPhieumuonhang.Visible = true;
                            break;
                        case 3:
                            if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO") BtnTrinhDuyet.Visible = false;
                            if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO") btnDeNghi.Visible = false;
                            if (Commons.Modules.sPrivate.Trim().ToUpper() == "GREENFEED") BtnIn.Visible = true;

                            if (((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_DUYET"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim()))
                            {
                                BtnDong.Visible = true;
                                if ((int)SqlDuyetDeXuat.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_DON_DAT_HANG_DE_XUAT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"]) > 0)
                                {
                                    BtnSua.Visible = false;
                                    btnCNDuyet.Visible = false;
                                    BtnXoa.Visible = false;
                                    btnPhieumuonhang.Visible = true;
                                }
                                else
                                {
                                    BtnSua.Visible = true;
                                    if (bCNDuyet) btnCNDuyet.Visible = true; else btnCNDuyet.Visible = false;
                                    BtnXoa.Visible = true;
                                    btnPhieumuonhang.Visible = true;
                                }
                            }
                            else
                            {
                                if (Commons.Modules.sPrivate == "TRUNGNGUYEN")
                                {
                                    BtnDong.Visible = true;
                                }
                                else
                                {
                                    BtnDong.Visible = false;
                                }
                                BtnSua.Visible = false;
                                btnKhongDuyet.Visible = false;
                                btnCNDuyet.Visible = false;
                                BtnXoa.Visible = false;
                                btnPhieumuonhang.Visible = true;
                                BtnIn.Visible = true;
                            }
                            break;
                        case 2:
                            BtnIn.Visible = false;
                            BtnDong.Visible = false;
                            if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO") BtnTrinhDuyet.Visible = false;
                            if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO") btnDeNghi.Visible = false;

                            if ((int)SqlDuyetDeXuat.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_NGUOI_DUYET_DE_XUAT", Commons.Modules.UserName, ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"]) > 0)
                            {
                                BtnSua.Visible = true;
                                btnKhongDuyet.Visible = true;
                                if (bCNDuyet) btnCNDuyet.Visible = true; else btnCNDuyet.Visible = false;
                                BtnXoa.Visible = true;
                                btnPhieumuonhang.Visible = false;
                                if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO") BtnTrinhDuyet.Visible = false;
                                if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO") btnDeNghi.Visible = false;

                            }
                            else
                            {
                                if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO")
                                {
                                    if (((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim()))
                                    {
                                        BtnSua.Visible = true;
                                        btnKhongDuyet.Visible = true;
                                        if (bCNDuyet) btnCNDuyet.Visible = true; else btnCNDuyet.Visible = false;
                                    }
                                    else
                                    {
                                        BtnSua.Visible = false;
                                        btnKhongDuyet.Visible = false;
                                        if (bCNDuyet) btnCNDuyet.Visible = true; else btnCNDuyet.Visible = false;
                                    }
                                }
                                else
                                {
                                    BtnSua.Visible = false;
                                    btnKhongDuyet.Visible = false;
                                    if (bCNDuyet) btnCNDuyet.Visible = true; else btnCNDuyet.Visible = false;
                                }
                                BtnXoa.Visible = false;
                                btnPhieumuonhang.Visible = false;
                                if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO") BtnTrinhDuyet.Visible = false;
                                if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO") btnDeNghi.Visible = false;
                            }
                            KiemNutKhongDuyet();

                            break;
                        case 1:
                            BtnIn.Visible = false;
                            BtnDong.Visible = false;
                            if (((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim()))
                            {
                                BtnSua.Visible = true;
                                if (bCNDuyet) btnCNDuyet.Visible = true; else btnCNDuyet.Visible = false;
                                BtnXoa.Visible = true;
                                if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO") BtnTrinhDuyet.Visible = true;

                                btnPhieumuonhang.Visible = false;
                            }
                            else
                            {
                                btnPhieumuonhang.Visible = false;
                                BtnSua.Visible = false;
                                btnKhongDuyet.Visible = false;
                                if (bCNDuyet) btnCNDuyet.Visible = true; else btnCNDuyet.Visible = false;
                                BtnXoa.Visible = false;
                                if (Commons.Modules.sPrivate.Trim().ToUpper() != "DOFICO") BtnTrinhDuyet.Visible = false;

                            }
                            if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO")
                                if (DgvDeXuatMuaHangChiTiet.RowCount != 0) if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 58)) btnDeNghi.Visible = true; else btnDeNghi.Visible = false; else btnDeNghi.Visible = false;

                            break;
                    }
                }
                bQDeXuat = false;
                string sSql = "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME = '" + Commons.Modules.UserName + "' AND STT = 0 ";
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    try
                    {
                        sSql = Convert.ToString(((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"]);
                    }
                    catch { sSql = "-1"; }

                    if (!BtnSua.Visible)
                    {
                        if ((int)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "SP_Y_CHECK_DON_DAT_HANG_DE_XUAT", sSql) < 0)
                        {
                            BtnSua.Visible = true;
                            bQDeXuat = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Load form
        /// </summary>
        private void frmRequire_Load(object sender, EventArgs e)
        {
            //private string sTT1DangSoan = "Đang soạn";
            //private string sTT2TrinhDuyet = "Trình duyệt";
            //private string sTT3Duyet = "Duyệt";
            //private string sTT4Dong = "Đóng";

            try
            {
                sDuongDanTLDichVu = Commons.Modules.ObjSystems.GetDUONG_DAN_HINH(1).Rows[0][0].ToString() + "\\DeXuatDichVu\\";
            }
            catch { }

            if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 62)) bCNDuyet = true; else bCNDuyet = false;


            this.DgvDeXuatMuaHang.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvDeXuatMuaHang_RowPrePaint);
            //this.DgvDeXuatMuaHangChiTiet.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvDeXuatMuaHangChiTiet_RowPrePaint);
            if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO") sTT2TrinhDuyet = "Duyệt đề nghị";

            string sTmp = "";
            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TTDangSoan", Commons.Modules.TypeLanguage);
            if (sTmp.Substring(0, 1) != "@" && sTmp.Substring(0, 1) != "?")
                sTT1DangSoan = sTmp;

            if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO")
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TTDuyetDeNghi", Commons.Modules.TypeLanguage);
            else
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TTTrinhDuyet", Commons.Modules.TypeLanguage);
            if (sTmp.Substring(0, 1) != "@" && sTmp.Substring(0, 1) != "?")
                sTT2TrinhDuyet = sTmp;


            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TTDuyet", Commons.Modules.TypeLanguage);
            if (sTmp.Substring(0, 1) != "@" && sTmp.Substring(0, 1) != "?")
                sTT3Duyet = sTmp;
            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TTDong", Commons.Modules.TypeLanguage);
            if (sTmp.Substring(0, 1) != "@" && sTmp.Substring(0, 1) != "?")
                sTT4Dong = sTmp;
            string sSql = "";
            try
            {
                sSql = "SELECT TEN_TT FROM TRANG_THAI_DX WHERE MS_TT = 0";
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                    sTTDX = dtTmp.Rows[0][0].ToString();



                bQDeXuat = false;
                sSql = "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME = '" + Commons.Modules.UserName + "' AND STT = 0 ";
                dtTmp = new System.Data.DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                    bQDeXuat = true;

                InitializeDatabase();
                TrangThai = String.Empty;
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                Commons.Modules.ObjSystems.MVisGrid(DgvDeXuatMuaHangChiTiet, this.Name, DgvDeXuatMuaHangChiTiet.Name.ToString(), Commons.Modules.UserName);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            btnUnLock.Visible = false;


            TrangThai = String.Empty;
            InitializeForm();

        }


        /// <summary>
        /// Thêm dữ liệu
        /// </summary> 
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string sTmp;
            try
            {
                bThayDoiDuyet = false;
                if (Commons.Modules.sPrivate == "ACECOOK")
                {
                    DateTime dTNgay, dDNgay;
                    dTNgay = DateTime.Now.Date;
                    dTNgay = Convert.ToDateTime("01/" + dTNgay.Month.ToString() + "/" + dTNgay.Year.ToString());
                    try
                    {
                        dDNgay = Convert.ToDateTime(MskNGAY_LAP.Text);
                    }
                    catch { dDNgay = dTNgay; }
                    System.Data.DataTable dtTmp = new System.Data.DataTable();
                    sTmp = " SELECT * FROM ( SELECT T1.*, ISNULL(TI_GIA,-1) AS TGIA FROM NGOAI_TE T1 LEFT JOIN " +
                                    " (SELECT A.* FROM TI_GIA_NT A INNER JOIN (SELECT NGOAI_TE, MAX(NGAY) AS NMAX FROM TI_GIA_NT  " +
                                    " WHERE NGAY_NHAP BETWEEN '" + dTNgay.ToString("MM/dd/yyyy") + "' AND '" + dDNgay.ToString("MM/dd/yyyy") + "' GROUP BY NGOAI_TE)B ON A.NGOAI_TE = B.NGOAI_TE AND A.NGAY = B.NMAX " +
                                    " )T2 ON T1.NGOAI_TE = T2.NGOAI_TE) A WHERE TGIA = -1 ";
                    dtTmp = new System.Data.DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sTmp));
                    if (dtTmp.Rows.Count > 0)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanChuaNhapTiGia", Commons.Modules.TypeLanguage));
                        return;
                    }
                }

                Commons.Modules.SQLString = "0Load";
                cboTinhTrang.EditValue = -1;
                Commons.Modules.SQLString = "";
                Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                BindingDeXuatMuaHang.AddNew();
                TrangThai = "Add";
                InitializeForm();
                tblCondition.Enabled = false;
                if (Commons.Modules.iDefault == 2) TxtSO_DE_XUAT.Enabled = false; else TxtSO_DE_XUAT.Focus();
                bSuaDuyet = false;
            }
            catch { }
        }
        /// <summary>
        /// Sửa dữ liệu
        /// </summary> 
        private void BtnSua_Click(object sender, EventArgs e)
        {
            TrangThai = "Edit";
            if (TabCTDX.SelectedTabPageIndex == 2)
                bSuaDuyet = true;

            InitializeForm();

            cmbKho.Enabled = cmbLoaiVT.Enabled = false;
            tblCondition.Enabled = false;
            TxtSO_DE_XUAT.Focus();
            bThayDoiDuyet = false;
            if (TabCTDX.SelectedTabPageIndex == 2)
            {
                bSuaDuyet = true;
            }
            if (bQDeXuat || bSuaDuyet)
            {
                BtnChonPT.Visible = false;
                btnAuto.Visible = false;
                TxtSO_DE_XUAT.Enabled = false;
                txtTimKiem.Enabled = true;
                //btnTimCX.Enabled = true;

                CboPHONG_BAN.Enabled = false;
                cboNGUOI_TN.Enabled = false;
                cmbKho.Enabled = false;
                cmbLoaiVT.Enabled = false;
                MskNGAY_DE_XUAT.Enabled = false;
                TxtNGUOI_DE_XUAT.Enabled = false;
                MskNGAY_NHAN.Enabled = false;
                TxtNGUOI_NHAN.Enabled = false;
                MskNGAY_GIAO.Enabled = false;
                TxtNGUOI_GIAO.Enabled = false;
                TxtGHI_CHU.Enabled = false;
                cboNCC.Enabled = false;
                ChkTHEO_YEU_CAU.Enabled = false;
                ChkTHEO_KE_HOACH.Enabled = false;
            }

            if (Commons.Modules.iDefault == 2) TxtSO_DE_XUAT.Enabled = false;
        }
        /// <summary>
        /// Chọn vật tư phụ tùng
        /// </summary> 
        private void BtnChonPT_Click(object sender, EventArgs e)
        {
            try
            {
                if (CboPHONG_BAN.SelectedValue == null || CboPHONG_BAN.SelectedValue.Equals(DBNull.Value))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChonBoPhan", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    CboPHONG_BAN.Focus();
                    return;
                }
                if (MskNGAY_DE_XUAT.Text == null || MskNGAY_DE_XUAT.Text.Equals(DBNull.Value))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChonNgayDeXuat", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    MskNGAY_DE_XUAT.Focus();
                    return;
                }
                frmChonPhuTung frmPhuTung = new frmChonPhuTung();
                frmPhuTung.Name = "frmChonPhuTung_DX";
                int kho = Convert.ToInt32(cmbKho.SelectedValue);
                if (kho == 0)
                    kho = -1;
                frmPhuTung._ms_kho = kho;
                frmPhuTung.CurrentSource = TbDeXuatMuaHangChiTiet.DefaultView.ToTable();
                if (frmPhuTung.ShowDialog(this) == DialogResult.OK)
                {
                    int t = frmPhuTung._ms_kho;
                    frmPhuTung.DataSource.DefaultView.RowFilter = "CHON = true";
                    for (int i = 0; i < frmPhuTung.DataSource.DefaultView.Count; i++)
                    {
                        DataRow rDeXuatMuaHangChiTiet = TbDeXuatMuaHangChiTiet.NewRow();
                        rDeXuatMuaHangChiTiet["MS_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT"];
                        rDeXuatMuaHangChiTiet["MS_PT_CTY"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT_CTY"];
                        rDeXuatMuaHangChiTiet["TEN_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["TEN_PT"];
                        rDeXuatMuaHangChiTiet["HANG_SX"] = frmPhuTung.DataSource.DefaultView[i].Row["TEN_HSX"];
                        rDeXuatMuaHangChiTiet["PART_NO"] = frmPhuTung.DataSource.DefaultView[i].Row["PART_NO"];
                        rDeXuatMuaHangChiTiet["QUY_CACH"] = frmPhuTung.DataSource.DefaultView[i].Row["QUY_CACH"];
                        rDeXuatMuaHangChiTiet["DVT"] = frmPhuTung.DataSource.DefaultView[i].Row["DVT"];
                        rDeXuatMuaHangChiTiet["TON_KHO"] = frmPhuTung.DataSource.DefaultView[i].Row["TON_KHO"];
                        rDeXuatMuaHangChiTiet["TON_MIN"] = frmPhuTung.DataSource.DefaultView[i].Row["TON_MIN"];
                        rDeXuatMuaHangChiTiet["TON_MAX"] = frmPhuTung.DataSource.DefaultView[i].Row["TON_MAX"];
                        rDeXuatMuaHangChiTiet["DA_DAT_MUA"] = frmPhuTung.DataSource.DefaultView[i].Row["SL_DAT_HANG"];
                        rDeXuatMuaHangChiTiet["DA_DE_XUAT"] = frmPhuTung.DataSource.DefaultView[i].Row["SL_DE_XUAT"];
                        rDeXuatMuaHangChiTiet["THUE_VAT"] = 0;
                        if (Commons.Modules.sPrivate == "TRUNGNGUYEN")
                        {
                            rDeXuatMuaHangChiTiet["SL_DE_XUAT"] = 0;
                        }
                        else
                        {
                            double SoLuong = (iKiemGT(frmPhuTung.DataSource.DefaultView[i].Row["TON_MAX"].ToString()) -
                                (iKiemGT(frmPhuTung.DataSource.DefaultView[i].Row["TON_KHO"].ToString()) +
                                iKiemGT(frmPhuTung.DataSource.DefaultView[i].Row["SL_DE_XUAT"].ToString()) +
                                iKiemGT(frmPhuTung.DataSource.DefaultView[i].Row["SL_DAT_HANG"].ToString())));
                            if (SoLuong > 0)
                            {
                                rDeXuatMuaHangChiTiet["SL_DE_XUAT"] = SoLuong;
                            }
                            else
                            {
                                rDeXuatMuaHangChiTiet["SL_DE_XUAT"] = 1;
                            }
                        }

                        rDeXuatMuaHangChiTiet["SL_DA_DUYET"] = rDeXuatMuaHangChiTiet["SL_DE_XUAT"];
                        rDeXuatMuaHangChiTiet["NGAY_DE_XUAT_CUOI"] = frmPhuTung.DataSource.DefaultView[i].Row["NGAY_CUOI"];
                        rDeXuatMuaHangChiTiet["NHA_CUNG_CAP_CUOI"] = frmPhuTung.DataSource.DefaultView[i].Row["NHA_CUNG_CAP_CUOI"];
                        rDeXuatMuaHangChiTiet["DON_GIA"] = frmPhuTung.DataSource.DefaultView[i].Row["DON_GIA_CUOI"];

                        if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED")
                            rDeXuatMuaHangChiTiet["NGOAI_TE"] = "VND";
                        else
                            if (Commons.Modules.sTienTeMD != "") rDeXuatMuaHangChiTiet["NGOAI_TE"] = Commons.Modules.sTienTeMD; else rDeXuatMuaHangChiTiet["NGOAI_TE"] = frmPhuTung.DataSource.DefaultView[i].Row["NGOAI_TE_CUOI"];

                        if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED")
                            rDeXuatMuaHangChiTiet["NGOAI_TE_CUOI"] = "VND";
                        else
                            if (Commons.Modules.sTienTeMD != "") rDeXuatMuaHangChiTiet["NGOAI_TE_CUOI"] = Commons.Modules.sTienTeMD; else rDeXuatMuaHangChiTiet["NGOAI_TE_CUOI"] = frmPhuTung.DataSource.DefaultView[i].Row["NGOAI_TE_CUOI"];

                        Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                        System.Data.DataTable TbNgoaiTe = new System.Data.DataTable();

                        if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED")
                            TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", "VND"));
                        else
                            TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", rDeXuatMuaHangChiTiet["NGOAI_TE_CUOI"]));

                        if (TbNgoaiTe.Rows.Count > 0)
                        {
                            try
                            {
                                double vnd = Convert.ToDouble(TbNgoaiTe.Rows[0]["TI_GIA"].ToString());
                                rDeXuatMuaHangChiTiet["TY_GIA"] = vnd.ToString("###,##0.00");
                                double usd = Convert.ToDouble(TbNgoaiTe.Rows[0]["TI_GIA_USD"].ToString());
                                rDeXuatMuaHangChiTiet["TY_GIA_USD"] = usd;
                                double thanhtien = 0;
                                try
                                {
                                    thanhtien = (Convert.ToInt32(rDeXuatMuaHangChiTiet["SL_DE_XUAT"]) * Convert.ToDouble(frmPhuTung.DataSource.DefaultView[i].Row["DON_GIA_CUOI"]));
                                }
                                catch { }

                                rDeXuatMuaHangChiTiet["THANH_TIEN"] = thanhtien;
                                rDeXuatMuaHangChiTiet["THANH_TIEN_VND"] = vnd * thanhtien;
                                rDeXuatMuaHangChiTiet["THANH_TIEN_USD"] = usd * thanhtien;
                            }
                            catch { }
                        }

                        rDeXuatMuaHangChiTiet["DON_GIA_CUOI"] = frmPhuTung.DataSource.DefaultView[i].Row["DON_GIA_CUOI"];
                        int SoNgay = 0;

                        try
                        {
                            SoNgay = int.Parse(frmPhuTung.DataSource.DefaultView[i].Row["SO_NGAY_DAT_MUA_HANG"].ToString());
                        }
                        catch { }
                        rDeXuatMuaHangChiTiet["NGAY_GIAO_HANG"] = Convert.ToDateTime(MskNGAY_DE_XUAT.Text).AddDays(SoNgay);

                        TbDeXuatMuaHangChiTiet.Rows.Add(rDeXuatMuaHangChiTiet);
                        cmbKho.SelectedValue = t;
                        cmbKho.Enabled = false;
                        cmbLoaiVT.Enabled = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        /// <summary>
        /// Xóa dữ liệu
        /// </summary> 
        private void BtnXoa_Click(object sender, EventArgs e)
        {

            if (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgCheckDelete", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int n = Convert.ToInt32((SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) FROM dbo.IC_DON_HANG_NHAP WHERE MS_DDH ='" + TxtMS_DE_XUAT.Text.Trim() + "'")));
                if (n > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgDeleteError", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                SqlDeXuatMuaHang.BeginTransaction();
                try
                {
                    Vietsoft.DataInfo.DeleteDataView(SqlDeXuatMuaHang, "SP_Y_DELETE_DE_XUAT_MUA_HANG_CHI_TIET", TbDeXuatMuaHangChiTiet.DefaultView, "MS_DE_XUAT", "MS_PT");
                    Vietsoft.DataInfo.DeleteDataView(SqlDeXuatMuaHang, "SP_Y_DELETE_DE_XUAT_MUA_HANG_DICH_VU", TbDeXuatMuaHangDichVu.DefaultView, "MS_DE_XUAT", "MS_DICH_VU");
                    Vietsoft.DataInfo.DeleteDataView(SqlDeXuatMuaHang, "SP_Y_DELETE_DUYET_DE_XUAT_MUA_HANG", TbDuyetDeXuatMuaHang.DefaultView, "MS_DE_XUAT", "NGUOI_DUYET");
                    Vietsoft.DataInfo.DeleteDataRow(SqlDeXuatMuaHang, "SP_Y_DELETE_DE_XUAT_MUA_HANG", ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row, "MS_DE_XUAT");
                    Vietsoft.DataInfo.ClearData(TbDeXuatMuaHangChiTiet.DefaultView);
                    Vietsoft.DataInfo.ClearData(TbDeXuatMuaHangDichVu.DefaultView);
                    Vietsoft.DataInfo.ClearData(TbDuyetDeXuatMuaHang.DefaultView);

                    if (Commons.Modules.iTRFData == 1 && Commons.Modules.sPrivate == "GREENFEED")
                    {
                        System.Data.DataTable dttmp = new System.Data.DataTable();
                        dttmp.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "spTRFDelDeXuat", TxtMS_DE_XUAT.Text, "-1"));
                        if (dttmp.Rows.Count > 0)
                        {
                            MessageBox.Show(dttmp.Rows[0][3].ToString() + "\n" + dttmp.Rows[0][5].ToString());
                            SqlDeXuatMuaHang.RollbackTransaction();
                            return;
                        }
                    }
                    SqlDeXuatMuaHang.CommitTransaction();
                    BindingDeXuatMuaHang.RemoveCurrent();
                    TbDeXuatMuaHang.AcceptChanges();
                    TbDeXuatMuaHangChiTiet.AcceptChanges();
                    TbDuyetDeXuatMuaHang.AcceptChanges();

                    InitializeForm();
                }
                catch
                {
                    SqlDeXuatMuaHang.RollbackTransaction();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgDeleteError", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
        private void DgvDeXuatMuaHangChiTiet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (BtnXoa.Visible == false)
            {
                e.Cancel = true;
                return;
            }
            Vietsoft.SqlInfo SqlDuyetDeXuat = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            if (TrangThai != "Add" && TrangThai != "Edit")
            {
                if (BindingDeXuatMuaHang.Current != null)
                {
                    switch ((int)((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"])
                    {
                        case 4:
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case 2:
                        case 3:
                            {
                                string sSql = "SELECT COUNT(*) FROM dbo.IC_DON_HANG_NHAP A INNER JOIN dbo.IC_DON_HANG_NHAP_VAT_TU B ON B.MS_DH_NHAP_PT = A.MS_DH_NHAP_PT WHERE A.MS_DDH ='" + ((DataRowView)e.Row.DataBoundItem).Row["MS_DE_XUAT"] + "' AND B.MS_PT = '" + ((DataRowView)e.Row.DataBoundItem).Row["MS_PT"] + "' ";
                                if (Convert.ToUInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql)) > 0)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                            }
                            break;
                        case 1:
                            if (!(((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim())))
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                    }
                }
            }

            if (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgCheckDelete", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    SqlDuyetDeXuat.BeginTransaction();
                    Vietsoft.DataInfo.DeleteDataRow(SqlDuyetDeXuat, "SP_Y_DELETE_DE_XUAT_MUA_HANG_CHI_TIET", ((DataRowView)e.Row.DataBoundItem).Row, "MS_DE_XUAT", "MS_PT");
                    if (Commons.Modules.iTRFData == 1)
                    {
                        System.Data.DataTable dttmp = new System.Data.DataTable();
                        dttmp.Load(SqlDuyetDeXuat.ExecuteReader(CommandType.StoredProcedure, "spTRFDelDeXuat",
                            ((DataRowView)e.Row.DataBoundItem).Row["MS_DE_XUAT"], ((DataRowView)e.Row.DataBoundItem).Row["MS_PT"]));

                        if (dttmp.Rows.Count > 0)
                        {
                            MessageBox.Show(dttmp.Rows[0][3].ToString() + "\n" + dttmp.Rows[0][5].ToString());
                            e.Cancel = true;
                            SqlDuyetDeXuat.RollbackTransaction();
                            return;
                        }
                    }
                    SqlDuyetDeXuat.CommitTransaction();
                }
                catch
                {
                    SqlDuyetDeXuat.RollbackTransaction();
                    e.Cancel = true;
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgDeleteError", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void DgvDeXuatMuaHangChiTiet_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TbDeXuatMuaHangChiTiet.AcceptChanges();
        }
        private void DgvDeXuatMuaHangDichVu_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (BtnXoa.Visible == false)
            {
                e.Cancel = true;
                return;
            }
            Vietsoft.SqlInfo SqlDuyetDeXuat = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            if (TrangThai != "Add" && TrangThai != "Edit")
            {
                if (BindingDeXuatMuaHang.Current != null)
                {
                    switch ((int)((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"])
                    {
                        case 4:
                            e.Cancel = true;
                            return;

                        case 2:
                        case 3:
                            if (!((int)SqlDuyetDeXuat.ExecuteScalar(CommandType.StoredProcedure, "SP_Y_CHECK_NGUOI_DUYET_DE_XUAT", Commons.Modules.UserName, ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"]) > 0 || ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim())))
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case 1:
                            if (!(((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_LAP"].ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim())))
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                    }
                }
            }
            if (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgCheckDelete", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    Vietsoft.DataInfo.DeleteDataRow(Vietsoft.Information.ConnectionString, "SP_Y_DELETE_DE_XUAT_MUA_HANG_DICH_VU", ((DataRowView)e.Row.DataBoundItem).Row, "MS_DE_XUAT", "MS_DICH_VU");
                }
                catch
                {
                    e.Cancel = true;
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgDeleteError", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void DgvDeXuatMuaHangDichVu_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TbDeXuatMuaHangDichVu.AcceptChanges();
        }
        /// <summary>
        /// Lọc dữ liệu
        /// </summary> 

        /// <summary>
        /// In dữ liệu
        /// </summary> 
        private void InVARD()
        {
            frmReport frmRptDexuat = new frmReport();
            frmRptDexuat.rptName = "rptDeXuatMuaHangNew_VARD";
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            System.Data.DataTable TbDX = new System.Data.DataTable();
            TbDX.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
            TbDX.TableName = "rptDeXuatMuaHang";
            frmRptDexuat.AddDataTableSource(TbDX);
            System.Data.DataTable TbPT = new System.Data.DataTable();
            TbPT.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_PT_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
            TbPT.TableName = "rptDeXuatMuaHangPT";
            frmRptDexuat.AddDataTableSource(TbPT);
            System.Data.DataTable TbDV = new System.Data.DataTable();
            TbDV.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_DV_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
            TbDV.TableName = "rptDeXuatMuaHangDV";
            frmRptDexuat.AddDataTableSource(TbDV);
            System.Data.DataTable TbDU = new System.Data.DataTable();
            TbDU.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_DU_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
            TbDU.TableName = "rptDonDatHangDU";
            frmRptDexuat.AddDataTableSource(TbDU);

            System.Data.DataTable TbTieuDe = new System.Data.DataTable();
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("DS_VTPT");
            TbTieuDe.Columns.Add("DS_DICH_VU");
            TbTieuDe.Columns.Add("MS_DE_XUAT");
            TbTieuDe.Columns.Add("SO_DE_XUAT");
            TbTieuDe.Columns.Add("BO_PHAN");
            TbTieuDe.Columns.Add("NGUOI_LAP");
            TbTieuDe.Columns.Add("NGAY_LAP");
            TbTieuDe.Columns.Add("GHI_CHU_DX");
            TbTieuDe.Columns.Add("NGUOI_KY_1");
            TbTieuDe.Columns.Add("NGUOI_KY_2");
            TbTieuDe.Columns.Add("NGUOI_KY_3");
            TbTieuDe.Columns.Add("NGUOI_KY_4");
            TbTieuDe.Columns.Add("NGUOI_KY_5");
            TbTieuDe.Columns.Add("NGUOI_KY_6");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("QUY_CACH");
            TbTieuDe.Columns.Add("DVT");
            TbTieuDe.Columns.Add("TON_MIN");
            TbTieuDe.Columns.Add("TON_MAX");
            TbTieuDe.Columns.Add("TON_KHO");
            TbTieuDe.Columns.Add("SO_LUONG");
            TbTieuDe.Columns.Add("SL_CTU");
            TbTieuDe.Columns.Add("SL_DE_XUAT");
            TbTieuDe.Columns.Add("DON_GIA_VND");
            TbTieuDe.Columns.Add("THANH_TIEN_VND");
            TbTieuDe.Columns.Add("GHI_CHU");
            TbTieuDe.Columns.Add("TEN_DICH_VU");
            TbTieuDe.Columns.Add("DVT_DV");
            TbTieuDe.Columns.Add("SO_LUONG_DV");
            TbTieuDe.Columns.Add("DON_GIA_DV_VND");
            TbTieuDe.Columns.Add("THANH_TIEN_DV_VND");
            TbTieuDe.Columns.Add("GHI_CHU_DV");
            TbTieuDe.Columns.Add("TONG_PT");
            TbTieuDe.Columns.Add("TONG_DV");
            TbTieuDe.Columns.Add("TIEN_TE");
            TbTieuDe.Columns.Add("TMP1");
            TbTieuDe.Columns.Add("TMP2");
            TbTieuDe.Columns.Add("TMP3");
            TbTieuDe.Columns.Add("DPT_No");
            TbTieuDe.Columns.Add("Account_No");
            TbTieuDe.Columns.Add("Part_No");

            System.Data.DataTable dtTmp = new System.Data.DataTable();
            string sSql = "";
            sSql = "SELECT KEYWORD , CASE " + Commons.Modules.TypeLanguage +
                        " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'rptDeXuatMuaHangNew' ";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


            TbTieuDe.Columns.Add("TMP4");
            TbTieuDe.Columns.Add("TMP5");
            DataRow rTitle = TbTieuDe.NewRow();

            rTitle["TIEU_DE"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TIEU_DE", "rptDeXuatMuaHangNew");
            rTitle["DS_VTPT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DS_VTPT", "rptDeXuatMuaHangNew");
            rTitle["DS_DICH_VU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DS_DICH_VU", "rptDeXuatMuaHangNew");
            rTitle["MS_DE_XUAT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "MS_DE_XUAT", "rptDeXuatMuaHangNew");
            rTitle["SO_DE_XUAT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SO_DE_XUAT", "rptDeXuatMuaHangNew");
            rTitle["BO_PHAN"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "BO_PHAN", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_LAP"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_LAP", "rptDeXuatMuaHangNew");
            rTitle["NGAY_LAP"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGAY_LAP", "rptDeXuatMuaHangNew");
            rTitle["GHI_CHU_DX"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "GHI_CHU_DX", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_1"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_1", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_2"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_2", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_3"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_3", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_4"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_4", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_5"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_5", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_6"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_6", "rptDeXuatMuaHangNew");
            rTitle["STT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "STT", "rptDeXuatMuaHangNew");
            rTitle["MS_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "MS_PT", "rptDeXuatMuaHangNew");
            rTitle["TEN_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TEN_PT", "rptDeXuatMuaHangNew");
            rTitle["QUY_CACH"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "QUY_CACH", "rptDeXuatMuaHangNew");
            rTitle["DVT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DVT", "rptDeXuatMuaHangNew");
            rTitle["TON_MIN"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TON_MIN", "rptDeXuatMuaHangNew");
            rTitle["TON_MAX"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TON_MAX", "rptDeXuatMuaHangNew");
            rTitle["TON_KHO"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TON_KHO", "rptDeXuatMuaHangNew");
            rTitle["SO_LUONG"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SO_LUONG", "rptDeXuatMuaHangNew");
            rTitle["SL_CTU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SL_CTU", "rptDeXuatMuaHangNew");
            rTitle["SL_DE_XUAT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SL_DE_XUAT", "rptDeXuatMuaHangNew");
            rTitle["DON_GIA_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DON_GIA_VND", "rptDeXuatMuaHangNew");
            rTitle["THANH_TIEN_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "THANH_TIEN_VND", "rptDeXuatMuaHangNew");
            rTitle["GHI_CHU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "GHI_CHU", "rptDeXuatMuaHangNew");
            rTitle["TEN_DICH_VU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TEN_DICH_VU", "rptDeXuatMuaHangNew");
            rTitle["DVT_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DVT_DV", "rptDeXuatMuaHangNew");
            rTitle["SO_LUONG_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SO_LUONG_DV", "rptDeXuatMuaHangNew");
            rTitle["DON_GIA_DV_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DON_GIA_DV_VND", "rptDeXuatMuaHangNew");
            rTitle["THANH_TIEN_DV_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "THANH_TIEN_DV_VND", "rptDeXuatMuaHangNew");
            rTitle["GHI_CHU_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "GHI_CHU_DV", "rptDeXuatMuaHangNew");
            rTitle["TONG_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TONG_PT", "rptDeXuatMuaHangNew");
            rTitle["TONG_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TONG_DV", "rptDeXuatMuaHangNew");
            rTitle["TIEN_TE"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TIEN_TE", "rptDeXuatMuaHangNew");
            rTitle["TMP1"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP1", "rptDeXuatMuaHangNew");
            rTitle["TMP2"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP2", "rptDeXuatMuaHangNew");
            rTitle["TMP3"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP3", "rptDeXuatMuaHangNew");
            rTitle["TMP4"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP4", "rptDeXuatMuaHangNew");
            rTitle["TMP5"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP5", "rptDeXuatMuaHangNew");
            rTitle["DPT_No"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DPT_No", "rptDeXuatMuaHangNew");
            rTitle["Account_No"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "Account_No", "rptDeXuatMuaHangNew");
            rTitle["Part_No"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "MS_PT_NCC", "rptDeXuatMuaHangNew");


            TbTieuDe.TableName = "rptTieuDeDeXuatMuaHangNew";
            TbTieuDe.Rows.Add(rTitle);
            frmRptDexuat.AddDataTableSource(TbTieuDe);
            frmRptDexuat.ShowDialog(this);
        }



        private void BtnIn_Click(object sender, EventArgs e)
        {
            if (Commons.Modules.sPrivate.Trim().ToUpper() == "VECO")
            {
                try
                {
                    if (TabCTDX.SelectedTabPageIndex == 0)
                    {
                        InPurchaseItem();
                    }
                    else if (TabCTDX.SelectedTabPageIndex == 1)
                    {
                        InPurchaseService();
                    }
                    Cursor = Cursors.Default;
                    return;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            }

            if (Commons.Modules.sPrivate.Trim().ToUpper() == "SHISEIDO")
            {
                InSSD();
                return;
            }

            if (Commons.Modules.sPrivate.Trim().ToUpper() == "ADC")
            {
                InRongAChau();
                return;
            }
            if (Commons.Modules.sPrivate.Trim().ToUpper() == "ACECOOK")
            {
                InAceCook();
                return;
            }
            if (Commons.Modules.sPrivate.Trim().ToUpper() == "GREENFEED")
            {
                InGreenFeed();
                return;
            }
            //if (Commons.Modules.sPrivate.Trim().ToUpper() == "SHISEIDO")
            //{
            //    InSHISEIDO();
            //    return;
            //}

            if (Commons.Modules.sPrivate.Trim().ToUpper() == "VINHHOAN")
            {
                InDeNghiMuaHangVinhHoan(0);
                return;
            }
            if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO")
            {
                frmInDeXuatDFC frm = new frmInDeXuatDFC();
                frm.sMsDXuat = ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"].ToString();
                frm.sNguoiDXuat = ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_DE_XUAT"].ToString();
                try
                {
                    frm.dNgayDXuat = Convert.ToDateTime(MskNGAY_DE_XUAT.Text);
                }
                catch { }
                frm.ShowDialog();
                return;
            }

            if (Commons.Modules.sPrivate.Trim().ToUpper() == "SABECOBL")
            {
                InSabeCo();
                return;
            }
            if (Commons.Modules.sPrivate.Trim().ToUpper() == "NUTIFOOD")
            {
                InNutiFood();
                return;
            }



            if (Commons.Modules.sPrivate.Trim().ToUpper() == "VARD")
            {
                InVARD();
                return;
            }


            frmReport frmRptDexuat = new frmReport();
            if (Commons.Modules.sPrivate.Trim().ToUpper() == "HCVT")
                frmRptDexuat.rptName = "rptDeXuatMuaHangNew_HCVT";
            if (Commons.Modules.sPrivate.Trim().ToUpper() == "TRUNGNGUYEN")
                frmRptDexuat.rptName = "rptDeXuatMuaHangNew_TN";
            else if (Commons.Modules.sPrivate.Trim().ToUpper() == "KKTL")
                frmRptDexuat.rptName = "rptDeXuatMuaHangNew_KKTL";
            else if (Commons.Modules.sPrivate.Trim().ToUpper() == "TAPACK")
                frmRptDexuat.rptName = "rptDeXuatMuaHangNew_TAPACK";
            else
                frmRptDexuat.rptName = "rptDeXuatMuaHangNew";

            if (Commons.Modules.sPrivate.Trim().ToUpper() == "CS")
                frmRptDexuat.rptName = "rptDeXuatMuaHangCS";

            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            System.Data.DataTable TbDX = new System.Data.DataTable();
            TbDX.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
            TbDX.TableName = "rptDeXuatMuaHang";
            frmRptDexuat.AddDataTableSource(TbDX);
            System.Data.DataTable TbPT = new System.Data.DataTable();
            TbPT.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_PT_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
            TbPT.TableName = "rptDeXuatMuaHangPT";
            frmRptDexuat.AddDataTableSource(TbPT);
            System.Data.DataTable TbDV = new System.Data.DataTable();
            TbDV.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_DV_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
            TbDV.TableName = "rptDeXuatMuaHangDV";
            frmRptDexuat.AddDataTableSource(TbDV);
            System.Data.DataTable TbDU = new System.Data.DataTable();
            TbDU.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_DU_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
            TbDU.TableName = "rptDonDatHangDU";
            frmRptDexuat.AddDataTableSource(TbDU);

            System.Data.DataTable TbTieuDe = new System.Data.DataTable();
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("DS_VTPT");
            TbTieuDe.Columns.Add("DS_DICH_VU");
            TbTieuDe.Columns.Add("MS_DE_XUAT");
            TbTieuDe.Columns.Add("SO_DE_XUAT");
            TbTieuDe.Columns.Add("BO_PHAN");
            TbTieuDe.Columns.Add("NGUOI_LAP");
            TbTieuDe.Columns.Add("NGAY_LAP");
            TbTieuDe.Columns.Add("GHI_CHU_DX");
            TbTieuDe.Columns.Add("NGUOI_KY_1");
            TbTieuDe.Columns.Add("NGUOI_KY_2");
            TbTieuDe.Columns.Add("NGUOI_KY_3");
            TbTieuDe.Columns.Add("NGUOI_KY_4");
            TbTieuDe.Columns.Add("NGUOI_KY_5");
            TbTieuDe.Columns.Add("NGUOI_KY_6");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("QUY_CACH");
            TbTieuDe.Columns.Add("DVT");
            TbTieuDe.Columns.Add("TON_MIN");
            TbTieuDe.Columns.Add("TON_MAX");
            TbTieuDe.Columns.Add("TON_KHO");
            TbTieuDe.Columns.Add("SO_LUONG");
            TbTieuDe.Columns.Add("SL_CTU");
            TbTieuDe.Columns.Add("SL_DE_XUAT");
            TbTieuDe.Columns.Add("DON_GIA_VND");
            TbTieuDe.Columns.Add("THANH_TIEN_VND");
            TbTieuDe.Columns.Add("GHI_CHU");
            TbTieuDe.Columns.Add("TEN_DICH_VU");
            TbTieuDe.Columns.Add("DVT_DV");
            TbTieuDe.Columns.Add("SO_LUONG_DV");
            TbTieuDe.Columns.Add("DON_GIA_DV_VND");
            TbTieuDe.Columns.Add("THANH_TIEN_DV_VND");
            TbTieuDe.Columns.Add("GHI_CHU_DV");
            TbTieuDe.Columns.Add("TONG_PT");
            TbTieuDe.Columns.Add("TONG_DV");
            TbTieuDe.Columns.Add("TIEN_TE");
            TbTieuDe.Columns.Add("TMP1");
            TbTieuDe.Columns.Add("TMP2");
            TbTieuDe.Columns.Add("TMP3");
            System.Data.DataTable dtTmp = new System.Data.DataTable();
            string sSql = "";
            sSql = "SELECT KEYWORD , CASE " + Commons.Modules.TypeLanguage +
                        " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'rptDeXuatMuaHangNew' ";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


            TbTieuDe.Columns.Add("TMP4");
            TbTieuDe.Columns.Add("TMP5");
            DataRow rTitle = TbTieuDe.NewRow();

            rTitle["TIEU_DE"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TIEU_DE", "rptDeXuatMuaHangNew");
            rTitle["TIEU_DE"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TIEU_DE", "rptDeXuatMuaHangNew");
            rTitle["DS_VTPT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DS_VTPT", "rptDeXuatMuaHangNew");
            rTitle["DS_DICH_VU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DS_DICH_VU", "rptDeXuatMuaHangNew");
            rTitle["MS_DE_XUAT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "MS_DE_XUAT", "rptDeXuatMuaHangNew");
            rTitle["SO_DE_XUAT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SO_DE_XUAT", "rptDeXuatMuaHangNew");
            rTitle["BO_PHAN"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "BO_PHAN", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_LAP"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_LAP", "rptDeXuatMuaHangNew");
            rTitle["NGAY_LAP"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGAY_LAP", "rptDeXuatMuaHangNew");
            rTitle["GHI_CHU_DX"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "GHI_CHU_DX", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_1"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_1", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_2"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_2", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_3"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_3", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_4"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_4", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_5"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_5", "rptDeXuatMuaHangNew");
            rTitle["NGUOI_KY_6"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_6", "rptDeXuatMuaHangNew");
            rTitle["STT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "STT", "rptDeXuatMuaHangNew");
            rTitle["MS_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "MS_PT", "rptDeXuatMuaHangNew");
            rTitle["TEN_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TEN_PT", "rptDeXuatMuaHangNew");
            rTitle["QUY_CACH"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "QUY_CACH", "rptDeXuatMuaHangNew");
            rTitle["DVT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DVT", "rptDeXuatMuaHangNew");
            rTitle["TON_MIN"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TON_MIN", "rptDeXuatMuaHangNew");
            rTitle["TON_MAX"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TON_MAX", "rptDeXuatMuaHangNew");
            rTitle["TON_KHO"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TON_KHO", "rptDeXuatMuaHangNew");
            rTitle["SO_LUONG"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SO_LUONG", "rptDeXuatMuaHangNew");
            rTitle["SL_CTU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SL_CTU", "rptDeXuatMuaHangNew");
            rTitle["SL_DE_XUAT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SL_DE_XUAT", "rptDeXuatMuaHangNew");
            rTitle["DON_GIA_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DON_GIA_VND", "rptDeXuatMuaHangNew");
            rTitle["THANH_TIEN_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "THANH_TIEN_VND", "rptDeXuatMuaHangNew");
            rTitle["GHI_CHU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "GHI_CHU", "rptDeXuatMuaHangNew");
            rTitle["TEN_DICH_VU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TEN_DICH_VU", "rptDeXuatMuaHangNew");
            rTitle["DVT_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DVT_DV", "rptDeXuatMuaHangNew");
            rTitle["SO_LUONG_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SO_LUONG_DV", "rptDeXuatMuaHangNew");
            rTitle["DON_GIA_DV_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DON_GIA_DV_VND", "rptDeXuatMuaHangNew");
            rTitle["THANH_TIEN_DV_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "THANH_TIEN_DV_VND", "rptDeXuatMuaHangNew");
            rTitle["GHI_CHU_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "GHI_CHU_DV", "rptDeXuatMuaHangNew");
            rTitle["TONG_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TONG_PT", "rptDeXuatMuaHangNew");
            rTitle["TONG_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TONG_DV", "rptDeXuatMuaHangNew");
            rTitle["TIEN_TE"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TIEN_TE", "rptDeXuatMuaHangNew");
            rTitle["TMP1"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP1", "rptDeXuatMuaHangNew");
            rTitle["TMP2"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP2", "rptDeXuatMuaHangNew");
            rTitle["TMP3"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP3", "rptDeXuatMuaHangNew");
            rTitle["TMP4"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP4", "rptDeXuatMuaHangNew");
            rTitle["TMP5"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP5", "rptDeXuatMuaHangNew");

            TbTieuDe.TableName = "rptTieuDeDeXuatMuaHangNew";
            TbTieuDe.Rows.Add(rTitle);
            frmRptDexuat.AddDataTableSource(TbTieuDe);
            frmRptDexuat.ShowDialog(this);
        }
        private void DinhDangText(ExcelWorksheet ws, int fRow, int fCol, int tRow, int tCol, string text, bool bold = false, bool merge = false, bool wraptext = false, string CotRange = "")
        {
            ws.Cells[fRow, fCol, tRow, tCol].Value = text;
            if (bold == true)
                ws.Cells[fRow, fCol, tRow, tCol].Style.Font.Bold = true;

            if (merge == true)
                ws.Cells[fRow, fCol, tRow, tCol].Merge = true;
            if (wraptext == true)
                ws.Cells[fRow, fCol, tRow, tCol].Style.WrapText = true;
            if (CotRange != "")
            {
                ws.Cells[CotRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[CotRange].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ccc"));
            }
        }

        private void DinhDangTextAlignMent(ExcelWorksheet ws, int fRow, int fCol, int tRow, int tCol, string text, bool bold = false, bool merge = false, bool wraptext = false, ExcelHorizontalAlignment hAlignment = ExcelHorizontalAlignment.Center, ExcelVerticalAlignment vAlignment = ExcelVerticalAlignment.Center)
        {
            ws.Cells[fRow, fCol, tRow, tCol].Value = text;
            if (bold == true)
                ws.Cells[fRow, fCol, tRow, tCol].Style.Font.Bold = true;

            if (merge == true)
                ws.Cells[fRow, fCol, tRow, tCol].Merge = true;
            if (wraptext == true)
                ws.Cells[fRow, fCol, tRow, tCol].Style.WrapText = true;
            ws.Cells[fRow, fCol, tRow, tCol].Style.HorizontalAlignment = hAlignment;
            ws.Cells[fRow, fCol, tRow, tCol].Style.VerticalAlignment = vAlignment;
        }
        private void InSSD()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDeXuatChiTiet", TxtMS_DE_XUAT.Text));

                if (dt.Rows.Count == 0)
                {
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "KhongCoDuLieu", Commons.Modules.TypeLanguage);
                    Cursor = Cursors.Default;
                    return;
                }

                string sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                if (sPath == "") return;
                var fi = new System.IO.FileInfo(sPath);
                if (fi.Exists)
                {
                    fi.Delete();
                }

                ExcelPackage pck = new ExcelPackage();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("PR");
                pck.SaveAs(fi);

                #region "in Thong Tin Chung"
                Commons.Modules.MExcel.MTTChung(0, 0, 0, 0, ws, "");
                #endregion

                using (var range = ws.Cells["A1:AZ1000"])
                {
                    range.Style.Font.Color.SetColor(Color.Black);
                    range.Style.Font.SetFromFont(new System.Drawing.Font("Times New Roman", 11));
                }

                ws.Cells[1, 5, 1, 10].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "InternaleMemorandum", Commons.Modules.TypeLanguage);
                ws.Cells[1, 5, 1, 10].Style.Font.Size = 14;
                ws.Cells[1, 5, 1, 10].Style.Font.Bold = true;
                ws.Cells[1, 5, 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 5, 1, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 5, 1, 10].Merge = true;
                ws.Cells[1, 5, 1, 10].Style.Font.UnderLine = true;
                int iDong = 4;
                int iCot = 1, TCot = 10;

                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "TenCongTyEng", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong + 1, iCot, iDong + 1, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "TenCongTyViet", Commons.Modules.TypeLanguage), true);

                iDong = iDong + 3;

                DinhDangText(ws, iDong, iCot, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "PurchaseRequestTitleEng", Commons.Modules.TypeLanguage), true, true, true);
                ws.Cells[iDong, iCot, iDong, TCot].Style.Font.Size = 20;
                ws.Cells[iDong, iCot, iDong, TCot].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[iDong, iCot, iDong, TCot].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(iDong).Height = 25;
                DinhDangText(ws, iDong + 1, iCot, iDong + 1, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "PurchaseRequestTitleViet", Commons.Modules.TypeLanguage), false, true, false);
                ws.Row(iDong + 1).Height = 15;
                ws.Cells[iDong + 1, iCot, iDong + 1, TCot].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[iDong + 1, iCot, iDong + 1, TCot].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                DinhDangText(ws, iDong + 2, iCot, iDong + 2, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "No.", Commons.Modules.TypeLanguage));
                ws.Cells[iDong + 2, iCot + 1, iDong + 2, iCot + 1].Value = TxtSO_DE_XUAT.Text;

                DinhDangText(ws, iDong + 2, iCot + 5, iDong + 2, iCot + 5, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                ws.Cells[iDong + 2, iCot + 6, iDong + 2, iCot + 6].Value = MskNGAY_LAP.Text;

                iDong = iDong + 3;
                int fDong = iDong;

                DinhDangText(ws, iDong, iCot, iDong, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "EmployeeRequest", Commons.Modules.TypeLanguage), true, true, true);
                ws.Cells[iDong, iCot + 2, iDong, iCot + 2].Value = TxtNGUOI_DE_XUAT.Text;
                ws.Cells[iDong, iCot + 6, iDong, iCot + 6].Value = TxtSO_DE_XUAT.Text.Length > 11 ? TxtSO_DE_XUAT.Text.Substring(0, 2) : "";
                DinhDangText(ws, iDong + 1, iCot, iDong + 1, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "ProjectsWork", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangText(ws, iDong + 1, iCot + 2, iDong + 1, TCot, TxtGHI_CHU.Text, false, true, true);
                DinhDangText(ws, iDong + 2, iCot, iDong + 2, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Purpose", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangText(ws, iDong + 3, iCot, iDong + 3, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Seller", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangText(ws, iDong + 4, iCot, iDong + 4, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "DeliveryTerms", Commons.Modules.TypeLanguage), true, true, true);
                System.Data.DataTable dtTmp;
                try
                {
                    dtTmp = new System.Data.DataTable();
                    string sSql = " SELECT * FROM DIEU_KHOAN_MAC_DINH ";
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        DinhDangTextAlignMent(ws, iDong + 4, iCot + 2, iDong + 4, iCot + 4, Commons.Modules.TypeLanguage == 0 ? dtTmp.Rows[4][2].ToString() : dtTmp.Rows[5][2].ToString(), false, true, true, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Top);

                        DinhDangTextAlignMent(ws, iDong + 4, iCot + 6, iDong + 4, TCot, Commons.Modules.TypeLanguage == 0 ? dtTmp.Rows[1][2].ToString() : dtTmp.Rows[0][2].ToString(), false, true, true, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Top);
                    }
                }
                catch
                {
                }
                DinhDangText(ws, iDong, iCot + 5, iDong, iCot + 5, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Dept", Commons.Modules.TypeLanguage), true, true, true);

                DinhDangText(ws, iDong + 3, iCot + 5, iDong + 3, iCot + 5, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Address", Commons.Modules.TypeLanguage), true, true, true);

                try
                {
                    string DIACHI = "";
                    string sSql = " SELECT DIA_CHI FROM KHACH_HANG WHERE MS_KH = '" + cboNCC.EditValue + "'";
                    DIACHI = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, sSql).ToString();
                    DinhDangTextAlignMent(ws, iDong + 3, iCot + 6, iDong + 3, TCot, DIACHI, false, true, true, ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Top);
                }
                catch
                {
                }


                DinhDangText(ws, iDong + 4, iCot + 5, iDong + 4, iCot + 5, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "TimeToDelivery", Commons.Modules.TypeLanguage), true, true, true);

                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 1, iCot, iDong + 1, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 2, iCot, iDong + 2, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 3, iCot, iDong + 3, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 4, iCot, iDong + 4, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                ws.Row(iDong).Height = 30;
                ws.Row(iDong + 1).Height = 35;
                ws.Row(iDong + 2).Height = 0;
                ws.Row(iDong + 3).Height = 35;
                ws.Row(iDong + 4).Height = 60;

                ws.Column(1).Width = 5.75;
                ws.Column(2).Width = 14;
                ws.Column(3).Width = 5;
                ws.Column(4).Width = 20;
                ws.Column(5).Width = 12;
                ws.Column(6).Width = 15;
                ws.Column(7).Width = 18;
                ws.Column(8).Width = 8;
                ws.Column(9).Width = 13;
                ws.Column(10).Width = 27;

                iDong = iDong + 6;

                DinhDangText(ws, iDong, iCot, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "OthersVendor", Commons.Modules.TypeLanguage), false, true);


                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].IsRichText = true;
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].RichText.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Yes", Commons.Modules.TypeLanguage) + " ");
                ExcelRichText ert = ws.Cells[iDong, iCot + 4, iDong, iCot + 4].RichText.Add("c");
                ert.FontName = "Webdings";

                ws.Cells[iDong, iCot + 5, iDong, iCot + 5].IsRichText = true;
                ws.Cells[iDong, iCot + 5, iDong, iCot + 5].RichText.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "No", Commons.Modules.TypeLanguage) + " ");
                ert = ws.Cells[iDong, iCot + 5, iDong, iCot + 5].RichText.Add("c");
                ert.FontName = "Webdings";







                DinhDangText(ws, iDong + 1, iCot, iDong + 1, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Vendor1", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong + 2, iCot, iDong + 2, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Vendor2", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong + 3, iCot, iDong + 3, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Vendor3", Commons.Modules.TypeLanguage));

                iDong = iDong + 4;


                ws.Cells[iDong, iCot + 1, iDong, iCot + 3].Merge = true;

                DinhDangTextAlignMent(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "STT", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 1, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Item", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Quantity", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 5, iDong, iCot + 5, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Unit", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 6, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Estimates", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, iCot + 7, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "VAT", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 8, iDong, iCot + 8, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "VATValue", Commons.Modules.TypeLanguage), false, false, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 9, iDong, iCot + 9, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "AmountIn", Commons.Modules.TypeLanguage) + (Commons.Modules.TypeLanguage == 0 ? "VND" : "USD"), false, false, true);

                ws.Row(iDong).Height = 30;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                iDong++;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ws.Cells[iDong, iCot].Value = dt.Rows[i]["STT"];
                    ws.Cells[iDong, iCot, iDong + dt.Rows.Count, iCot].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 1].Value = dt.Rows[i]["TEN_PT"];
                    ws.Cells[iDong, iCot + 1, iDong, iCot + 3].Merge = true;
                    ws.Cells[iDong, iCot + 3, iDong + dt.Rows.Count, iCot + 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 4].Value = dt.Rows[i]["SL_DAT_HANG"];
                    ws.Cells[iDong, iCot + 4, iDong + dt.Rows.Count, iCot + 4].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 5].Value = dt.Rows[i]["DVT"];
                    ws.Cells[iDong, iCot + 5, iDong + dt.Rows.Count, iCot + 5].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 6].Value = dt.Rows[i]["DON_GIA"];
                    ws.Cells[iDong, iCot + 6, iDong + dt.Rows.Count, iCot + 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 7].Value = dt.Rows[i]["THUE_VAT"];
                    ws.Cells[iDong, iCot + 7, iDong + dt.Rows.Count, iCot + 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 8].Value = dt.Rows[i]["TIEN_THUE"];
                    ws.Cells[iDong, iCot + 8, iDong + dt.Rows.Count, iCot + 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells[iDong, iCot + 9].Value = dt.Rows[i]["THANH_TIEN"];
                    ws.Row(iDong).Height = 18;
                    iDong++;
                }
                ws.Cells[iDong, iCot, iDong + 2, iCot].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong + 2, iCot].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 4, iDong + 2, TCot].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 4, iDong + 2, TCot].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                iDong = iDong + 3;
                DinhDangTextAlignMent(ws, iDong, iCot, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Total", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangTextAlignMent(ws, iDong + 1, iCot, iDong + 1, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "VATGTGT", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangTextAlignMent(ws, iDong + 2, iCot, iDong + 2, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "TotalInclude", Commons.Modules.TypeLanguage), true, true, true);

                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 2, iCot, iDong + 2, TCot].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong + 2, iCot, iDong + 2, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                ws.Cells[iDong, TCot].Formula = "=+SUMPRODUCT(G21:G" + (iDong - 1).ToString() + ",E21:E" + (iDong - 1).ToString() + ")";
                ws.Cells[iDong + 1, TCot].Formula = "=SUMPRODUCT(E21:E" + (iDong - 1).ToString() + ",I21:I" + (iDong - 1).ToString() + ")";
                ws.Cells[iDong + 2, TCot].Formula = "=J" + iDong.ToString() + "+J" + (iDong + 1).ToString();

                iDong = iDong + 3;

                DinhDangText(ws, iDong, iCot + 1, iDong, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "PriceIncludingVAT", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong + 1, iCot + 1, iDong + 1, iCot + 1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "PriceIncludingCharge", Commons.Modules.TypeLanguage));

                DinhDangTextAlignMent(ws, iDong, iCot + 6, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Yes", Commons.Modules.TypeLanguage), false, false, false, ExcelHorizontalAlignment.Right);
                DinhDangText(ws, iDong + 1, iCot + 6, iDong + 1, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Yes", Commons.Modules.TypeLanguage));
                ws.Cells[iDong + 1, iCot + 6, iDong + 1, iCot + 6].IsRichText = true;
                ws.Cells[iDong + 1, iCot + 6, iDong + 1, iCot + 6].RichText.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Yes", Commons.Modules.TypeLanguage) + " ");
                ert = ws.Cells[iDong + 1, iCot + 6, iDong + 1, iCot + 6].RichText.Add("c");
                ert.FontName = "Webdings";
                ws.Cells[iDong + 1, iCot + 6, iDong + 1, iCot + 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                DinhDangTextAlignMent(ws, iDong, TCot, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "No", Commons.Modules.TypeLanguage), false, false, false, ExcelHorizontalAlignment.Right);

                ws.Cells[iDong + 1, TCot, iDong + 1, TCot].IsRichText = true;
                ws.Cells[iDong + 1, TCot, iDong + 1, TCot].RichText.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "No", Commons.Modules.TypeLanguage) + " ");
                ert = ws.Cells[iDong + 1, TCot, iDong + 1, TCot].RichText.Add("c");
                ert.FontName = "Webdings";
                ws.Cells[iDong + 1, TCot, iDong + 1, TCot].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;


                ws.Cells[iDong + 1, iCot, iDong + 1, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                iDong = iDong + 2;

                DinhDangTextAlignMent(ws, iDong, iCot, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "RequestedDept", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 4, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedDept ", Commons.Modules.TypeLanguage), true, true, true);
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Approved", Commons.Modules.TypeLanguage), true, true, true);
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                iDong++;



                //Requested by, Date: 	Checked by, Date:	"Name & sign (PD S manager)
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "RequestedBy", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong, iCot + 3, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedBy", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                DinhDangText(ws, iDong, iCot + 6, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage) + " " +
                     Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "PDManager", Commons.Modules.TypeLanguage), false, true, false, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Top
                     );
                ws.Cells[iDong, iCot, iDong, iCot + 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 58;




                iDong++;
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage), true);
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign1", Commons.Modules.TypeLanguage), false, true
                     );
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 52;

                iDong++;
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedBy", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong, iCot + 3, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedBy", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                DinhDangText(ws, iDong, iCot + 6, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage) + " " +
                     Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "FAManager", Commons.Modules.TypeLanguage), false, true, false, ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Top
                     );
                ws.Cells[iDong, iCot, iDong, iCot + 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 58;

                iDong++;
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage));
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign2", Commons.Modules.TypeLanguage), false, true
                     );
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 52;

                iDong++;
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedBy", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong, iCot + 3, iDong, iCot + 3, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "CheckedBy", Commons.Modules.TypeLanguage));
                DinhDangText(ws, iDong, iCot + 6, iDong, iCot + 6, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Date", Commons.Modules.TypeLanguage));
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage) + " " +
                     Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "Director", Commons.Modules.TypeLanguage), false, true, false,
                     ExcelHorizontalAlignment.Center, ExcelVerticalAlignment.Top
                     );
                ws.Cells[iDong, iCot, iDong, iCot + 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 58;
                iDong++;
                DinhDangText(ws, iDong, iCot, iDong, iCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage), true);
                DinhDangText(ws, iDong, iCot + 4, iDong, iCot + 4, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign", Commons.Modules.TypeLanguage));
                DinhDangTextAlignMent(ws, iDong, iCot + 7, iDong, TCot, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NameSign3", Commons.Modules.TypeLanguage), false, true
                     );
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 4, iDong, iCot + 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot + 7, iDong, iCot + 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[iDong, iCot, iDong, TCot].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Row(iDong).Height = 52;
                ws.Cells[fDong, TCot, iDong, TCot].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                iDong = iDong + 2;
                ws.Cells[iDong, iCot, iDong, iCot].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NotesEng", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 1, iCot, iDong + 1, iCot].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "NotesViet", Commons.Modules.TypeLanguage);
                iDong = iDong + 3;
                ws.Cells[iDong, iCot, iDong, iCot].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "POAuthorization", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 1, iCot, iDong + 1, iCot].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "POExpense", Commons.Modules.TypeLanguage);
                iDong = iDong + 3;
                ws.Cells[iDong, iCot + 1, iDong, iCot + 1].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "SeniorManager", Commons.Modules.TypeLanguage);
                ws.Cells[iDong + 1, iCot + 1, iDong + 1, iCot + 1].Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDXMH_SSD", "GeneralDirector", Commons.Modules.TypeLanguage);
                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);
                System.Diagnostics.Process.Start(fi.FullName);
            }
            catch
            {
            }
            Cursor = Cursors.Default;
        }



        #region VECO

        private void InPurchaseService()
        {

            System.Data.DataTable dtTmp = new System.Data.DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "MGetDXDVVECO",
                ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], 1));
            try
            {
                grdChung.DataSource = null;
                grvChung.Columns.Clear();
                grdChung.RepositoryItems.Clear();
            }
            catch { }

            if (dtTmp.Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtTmp.Columns.Add("IMAGE", typeof(Image));
            dtTmp.Columns["IMAGE"].ReadOnly = false;
            grdChung.DataSource = dtTmp;
            grvChung.RowHeight = 120;
            grvChung.Columns["IMAGE"].Width = 265;
            grvChung.Columns["IMAGE"].MaxWidth = 265;
            grvChung.Columns["IMAGE"].MinWidth = 265;

            int tmp = grvChung.Columns["IMAGE"].VisibleIndex;
            grvChung.Columns["IMAGE"].VisibleIndex = grvChung.Columns["Picture to refer"].VisibleIndex;
            grvChung.Columns["Picture to refer"].VisibleIndex = tmp;

            grvChung.Columns["Picture to refer"].Visible = false;
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "frmDeXuatMuaHang_New", 1);

            RepositoryItemPictureEdit repositoryItemPictureEdit1 = new RepositoryItemPictureEdit();
            repositoryItemPictureEdit1.Name = "IMAGE";
            repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            repositoryItemPictureEdit1.NullText = (" ");
            repositoryItemPictureEdit1.PictureAlignment = ContentAlignment.MiddleCenter;
            grdChung.RepositoryItems.Add(repositoryItemPictureEdit1);
            grvChung.Columns[grvChung.Columns.Count - 1].ColumnEdit = repositoryItemPictureEdit1;


            for (int i = 0; i < grvChung.RowCount; i++)
            {
                try
                {
                    Image imageFromFile = Image.FromFile(grvChung.GetDataRow(i)["Picture to refer"].ToString());
                    grvChung.SetRowCellValue(i, "IMAGE", imageFromFile);
                }
                catch { }
            }
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();
            int TCot = grvChung.Columns.Count - 1;
            int TDong = grvChung.RowCount;
            int Dong = 1;
            Excel.Range title;

            grdChung.ExportToXls(sPath);
            excelApplication.DisplayAlerts = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            try
            {


                Commons.Modules.MExcel.ThemDong(excelWorkSheet, XlInsertShiftDirection.xlShiftDown, 7, Dong);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, System.Windows.Forms.Application.StartupPath);

                string stmp;
                Dong = 1;

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, false,
false, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 55);

                excelApplication.Cells.Font.Name = "Calibri";
                excelApplication.Cells.Font.Size = 14;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "sbcTieuDeDXDV", 1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 14, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, 1);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 2, 8);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.MergeCells = true;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                 this.Name, "lblMauCode", 1), Dong, 9, "@", 10, false,
                 Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 10);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "lblNgayBanHanh", 1), Dong + 1, 9, "@", 10, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong + 1, 10);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "lblPage", 1), Dong + 2, 9, "@", 10, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong + 2, 10);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                  this.Name, "MauCode", 1), Dong, 11, "@", 10, false,
                  Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 13);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "NgayBanHanh", 1), Dong + 1, 11, "@", 10, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong + 1, 13);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "Page", 1), Dong + 2, 11, "@", 10, false,
                    Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong + 2, 13);


                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
            this.Name, "lblReQuestPurchase", 1), Dong + 5, 1, "@", Commons.Modules.iFontsize, true,
            Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + 5, TCot);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 5, 1, Dong + 5, 1);
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 255));

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                this.Name, "Item", 1), Dong + 6, 2, "@", Commons.Modules.iFontsize, false,
                Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + 6, 9);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                this.Name, "Purpose", 1), Dong + 6, 10, "@", Commons.Modules.iFontsize, false,
                Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + 6, 13);

                for (int i = 1; i < 5; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 6, 13 + i, Dong + 7, 13 + i);
                    title.MergeCells = true;

                }
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 6, 1, Dong + 7, 1);
                title.MergeCells = true;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 2, 8);
                title.MergeCells = true;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 2, 13);
                title.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                title.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;




                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 2, 13);
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 6, 1, Dong + 7, TCot);
                title.Font.Bold = true;
                title.WrapText = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 1, 1], excelWorkSheet.Cells[Dong + 1, 1]).Interior.Color;
                title.RowHeight = 51;


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 6, 1, Dong + 6, TCot);
                title.RowHeight = 33;


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 2, 13);

                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                title.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 8, 1, Dong + TDong + 7, TCot);
                title.WrapText = true;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));



                Commons.Modules.MExcel.ThemDong(excelWorkSheet, XlInsertShiftDirection.xlShiftDown, 1, 9);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 9, 1, 9, TCot);
                title.RowHeight = 15;

                for (int i = 1; i <= TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 9, i, 9, i);
                    title.Value = i;
                    title.Font.Name = "Calibri";
                    title.Font.Size = 14;
                    title.Font.Bold = false;

                }

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.57, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 51.43, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 37.43, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 27.57, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21.17, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.86, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14.57, "@", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.00, "@", true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20.86, "@", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12.00, "@", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12.00, "@", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12.00, "@", true, Dong + 1, 12, TDong + Dong, 12);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12.00, "@", true, Dong + 1, 13, TDong + Dong, 13);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 40, "@", true, Dong + 1, 14, TDong + Dong, 14);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21.43, "@", true, Dong + 1, 15, TDong + Dong, 15);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.71, "@", true, Dong + 1, 16, TDong + Dong, 16);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 17, "@", true, Dong + 1, 17, TDong + Dong, 17);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                this.Name, "lblApplication", 1), TDong + 11, 2, "@", 14, true,
                Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, TDong + 11, 2);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, TDong + 13, 2, TDong + 13, 2);
                title.Value = DateTime.Now.ToString("dd-MMM-yy");
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "ISO_revision",
                  1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, TDong + 14, 2, "@", 12, false, true, TDong + 14, 3);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, TDong + 14, 2, TDong + 14, 3);
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 255));

                //  Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                //this.Name, "lblAllModule", 1) + ":", TDong + 11, 3, "@", 14, true,
                //Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, TDong + 11, 3);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
              this.Name, "lblDepartmentManager", 1), TDong + 11, 14, "@", 14, true,
              Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, TDong + 11, TCot);


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 8, 9, TDong + Dong + 8, 12);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                excelApplication.Visible = true;
                excelWorkbook.Save();
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
        }
        #endregion

        #region InSabeCo
        private void InSabeCo()
        {
            System.Data.DataTable dtTmp = new System.Data.DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "MGetDXMHSabeco",
                ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, false, true, true, true);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "frmDeXuatMuaHang_New");


            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count;
                int TDong = grvChung.RowCount;
                int Dong = 1;


                grdChung.ExportToXls(sPath);

                excelApplication.Visible = true;
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                excelApplication.Visible = false;
                excelApplication.Cells.Font.Name = "Times New Roman";
                excelApplication.Cells.Font.Size = 12;

                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot - 2);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, System.Windows.Forms.Application.StartupPath);

                Commons.Modules.MExcel.ThemDong(excelWorkSheet, XlInsertShiftDirection.xlShiftDown, 8, Dong);

                string stmp;
                Dong = 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "So", Commons.Modules.TypeLanguage) +
                    " : " + (TxtSO_DE_XUAT.Text == "" ? "" : TxtSO_DE_XUAT.Text);

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, TCot - 1, "@", 12, false, true, Dong, TCot);
                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "NguoiThuchien", Commons.Modules.TypeLanguage) +
                    " : " + (TxtNGUOI_GIAO.Text == "" ? "...................................." : TxtNGUOI_GIAO.Text);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, TCot - 1, "@", 12, false, true, Dong, TCot);
                Dong++;
                stmp = LabNgayGiao.Text + " : " + (MskNGAY_GIAO.Text == "  /  /" ? " ................................................." : MskNGAY_GIAO.Text);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, TCot - 1, "@", 12, false, true, Dong, TCot);

                Excel.Range title;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 2, TCot - 1, Dong + 1, TCot);
                title.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexNone,
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));


                Dong++;
                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "TieuDe", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "Ngay",
                    Commons.Modules.TypeLanguage) + " : " + MskNGAY_LAP.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 12, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot);

                Dong++;
                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "HoTen",
                    Commons.Modules.TypeLanguage) + " : " + TxtNGUOI_DE_XUAT.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 12, false, true, Dong, 2);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "BoPhanCongTac",
                    Commons.Modules.TypeLanguage) + " : " + CboPHONG_BAN.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 12, false, true, Dong, 7);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "ChucVu",
                    Commons.Modules.TypeLanguage) + " : " + TxtNGUOI_NHAN.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 8, "@", 12, false, true, Dong, 9);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "DeNghiCongTyCungCapVatTuNhuSau",
                    Commons.Modules.TypeLanguage) + " : ";
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 12, false, true, Dong, 9);



                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true,
                        true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 10, 10, 30, 30, 100);
                //if (System.Environment.MachineName.ToUpper() == "MASHIMARO") excelApplication.Visible = true;

                Dong++;
                Dong++;

                for (int i = 1; i <= TCot; i++)
                {
                    if (i != 6 && i != 7)
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, i, Dong + 1, i);
                        title.MergeCells = true;
                    }
                }
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "SoLuong",
                        Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 6, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, 7);




                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 1, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = Excel.XlColorIndex.xlColorIndexNone;
                title.Borders.Color = Excel.XlColorIndex.xlColorIndexNone;




                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 12, 1, TDong + 13, TCot);
                title.Interior.Color = Excel.XlColorIndex.xlColorIndexNone;
                title.Borders.Color = Excel.XlColorIndex.xlColorIndexNone;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 12, 1, TDong + 13, TCot);
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));




                ////title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                //title.Interior.Color = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).Interior.Color;
                //title.RowHeight = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong - 1, 1], excelWorkSheet.Cells[Dong - 1, 1]).RowHeight;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 5, 1, 5, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 8, 1, 8, 1);
                title.RowHeight = 9;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 11, 1, 11, 1);
                title.RowHeight = 9;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 13, 1, 13, 1);
                title.RowHeight = excelWorkSheet.get_Range(excelWorkSheet.Cells[Dong + 3, 1], excelWorkSheet.Cells[Dong + 3, 1]).RowHeight;


                ////20	35	11	5	8	8	14	34
                //5	36.43	23	14.71	5	9	9	24.86	13.14

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "##", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 33.86, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 23, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14.71, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "0.00", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "0.00", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 24, "@", true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 17.71, "dd/MM/yyyy", true, Dong + 1, 9, TDong + Dong, 9);


                Dong = Dong + TDong + 2;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, 1);
                title.RowHeight = 5;
                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "GhiChu",
                    Commons.Modules.TypeLanguage) + " : ";
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, 2);
                title.MergeCells = true;
                title.Value2 = stmp;
                title.Font.Bold = true;
                title.Font.Italic = true;
                title.Font.Underline = true;

                for (int i = 1; i <= 4; i++)
                {
                    Dong++;
                    stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "GhiChu" + i.ToString(),
                        Commons.Modules.TypeLanguage);
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, false, true, Dong, TCot);
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 2, Dong, TCot);
                    title.WrapText = true;
                }

                Dong = Dong + 2;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "BanGiamDoc", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 12, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, 2);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "....../....../............", Dong + 1, 1, "@", 12, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong + 1, 2);


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "TPKyThuat", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 12, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, 3);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "....../....../............", Dong + 1, 3, "@", 12, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + 1, 3);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "TruongPhongQuanDoc", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 12, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, 6);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "....../....../............", Dong + 1, 4, "@", 12, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + 1, 6);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "ThuKho", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 7, "@", 12, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, 8);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "....../....../............", Dong + 1, 7, "@", 12, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + 1, 8);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "NguoiDeNghi", Commons.Modules.TypeLanguage);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 9, "@", 12, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, Dong, 9);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "....../....../............", Dong + 1, 9, "@", 12, false,
                    Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong + 1, 9);

                excelApplication.Visible = true;

            }
            catch
            { }

            this.Cursor = Cursors.Default;
        }
        #endregion

        #region InRongAChau
        private void InRongAChau()
        {
            this.Cursor = Cursors.WaitCursor;
            frmReport frmRptDexuat = new frmReport();
            try
            {
                frmRptDexuat.rptName = "rptDeXuatMuaHangADC";
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                //dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetDXMHADC",
                //    ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
                //dtTmp.TableName = "DON_DAT_HANG_DAC";
                //frmRptDexuat.AddDataTableSource(dtTmp);

                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
                connection.Open();

                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandText = "GetDXMHADC";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MS_DE_XUAT", TxtMS_DE_XUAT.Text));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NNgu", Commons.Modules.TypeLanguage));


                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                DataSet dsTmp = new DataSet();

                try
                {
                    adapter.Fill(dsTmp);
                }
                catch { }
                Int32 i = 0;
                for (i = 0; i <= dsTmp.Tables.Count - 1; i++)
                {
                    dtTmp = new System.Data.DataTable();
                    dtTmp = dsTmp.Tables[i];
                    switch (i)
                    {
                        case 0:
                            dtTmp.TableName = "DON_DAT_HANG_DAC";
                            break;
                        case 1:
                            dtTmp.TableName = "DNMH_DV_ADC";
                            break;
                    }
                    frmRptDexuat.AddDataTableSource(dtTmp);
                }


                System.Data.DataTable TbTieuDe = new System.Data.DataTable();
                TbTieuDe.Columns.Add("MAU_SO");
                TbTieuDe.Columns.Add("LB_HANH");
                TbTieuDe.Columns.Add("NGAY_BH");
                TbTieuDe.Columns.Add("TIEU_DE_RAC");
                TbTieuDe.Columns.Add("NGAY_DH");
                TbTieuDe.Columns.Add("SO");
                TbTieuDe.Columns.Add("REF");
                TbTieuDe.Columns.Add("KINH_GOI");
                TbTieuDe.Columns.Add("STT");
                TbTieuDe.Columns.Add("MHH");
                TbTieuDe.Columns.Add("TEN");
                TbTieuDe.Columns.Add("DVT");

                TbTieuDe.Columns.Add("SL_DH");
                TbTieuDe.Columns.Add("SL_TON");
                TbTieuDe.Columns.Add("SL_DHANG");
                TbTieuDe.Columns.Add("DON_GIA");
                TbTieuDe.Columns.Add("NGAY_COVT");
                TbTieuDe.Columns.Add("NHA_CC");
                TbTieuDe.Columns.Add("GHI_CHU");

                TbTieuDe.Columns.Add("MSKT");
                TbTieuDe.Columns.Add("MS_PT");


                TbTieuDe.Columns.Add("TGD");
                TbTieuDe.Columns.Add("TRUONG_BP");
                TbTieuDe.Columns.Add("MUA_HANG");
                TbTieuDe.Columns.Add("KE_HOACH");
                TbTieuDe.Columns.Add("NGUOI_LAP");

                TbTieuDe.Columns.Add("NGUOI_NHAN");
                TbTieuDe.Columns.Add("NGUOI_DX");
                TbTieuDe.Columns.Add("TEN_DV");

                TbTieuDe.Columns.Add("TMP1");
                TbTieuDe.Columns.Add("TMP2");
                TbTieuDe.Columns.Add("TMP3");
                TbTieuDe.Columns.Add("TMP4");
                TbTieuDe.Columns.Add("TMP5");

                DataRow rTitle = TbTieuDe.NewRow();

                rTitle["MAU_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "MAU_SO", Commons.Modules.TypeLanguage);
                rTitle["LB_HANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "LB_HANH", Commons.Modules.TypeLanguage);
                rTitle["NGAY_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "NGAY_BH", Commons.Modules.TypeLanguage);

                rTitle["TIEU_DE_RAC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "TIEU_DE_RAC", Commons.Modules.TypeLanguage);
                rTitle["NGAY_DH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "NGAY_DH", Commons.Modules.TypeLanguage);
                rTitle["SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "SO", Commons.Modules.TypeLanguage);
                rTitle["REF"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "REF", Commons.Modules.TypeLanguage);
                rTitle["KINH_GOI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "KINH_GOI", Commons.Modules.TypeLanguage) +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "TGD", Commons.Modules.TypeLanguage);

                rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "STT", Commons.Modules.TypeLanguage);
                rTitle["MHH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "MHH", Commons.Modules.TypeLanguage);
                rTitle["TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "TEN", Commons.Modules.TypeLanguage);
                rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "DVT", Commons.Modules.TypeLanguage);
                rTitle["SL_DH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "SL_DH", Commons.Modules.TypeLanguage);
                rTitle["SL_TON"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "SL_TON", Commons.Modules.TypeLanguage);
                rTitle["SL_DHANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "SL_DHANG", Commons.Modules.TypeLanguage);
                rTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "DON_GIA", Commons.Modules.TypeLanguage);
                rTitle["NGAY_COVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "NGAY_COVT", Commons.Modules.TypeLanguage);
                rTitle["NHA_CC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "NHA_CC", Commons.Modules.TypeLanguage);
                rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "GHI_CHU", Commons.Modules.TypeLanguage);

                rTitle["TGD"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "TGD", Commons.Modules.TypeLanguage);
                rTitle["TRUONG_BP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "TRUONG_BP", Commons.Modules.TypeLanguage);
                rTitle["MUA_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "MUA_HANG", Commons.Modules.TypeLanguage);
                rTitle["KE_HOACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "KE_HOACH", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "NGUOI_LAP", Commons.Modules.TypeLanguage);


                rTitle["NGUOI_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "NGUOI_NHAN", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_DX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "NGUOI_DX", Commons.Modules.TypeLanguage);

                rTitle["TEN_DV"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "TEN_DV", Commons.Modules.TypeLanguage);

                rTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "SLUONG", Commons.Modules.TypeLanguage);
                rTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "TTIEN", Commons.Modules.TypeLanguage);
                rTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "NGIAO", Commons.Modules.TypeLanguage);
                rTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "DX_VTPT", Commons.Modules.TypeLanguage);
                rTitle["TMP5"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangADC", "DXDV", Commons.Modules.TypeLanguage);

                TbTieuDe.TableName = "TIEU_DE_DAC";

                TbTieuDe.Rows.Add(rTitle);
                frmRptDexuat.AddDataTableSource(TbTieuDe);
                this.Cursor = Cursors.Default;
                frmRptDexuat.ShowDialog(this);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region InNutiFood
        private void InNutiFood()
        {
            this.Cursor = Cursors.WaitCursor;
            frmReport frmRptDexuat = new frmReport();

            frmRptDexuat.rptName = "rptDeXuatMuaHangNF";
            System.Data.DataTable dtTmp = new System.Data.DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetDXMHNF",
                ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
            dtTmp.TableName = "DON_DAT_HANG_NF";
            frmRptDexuat.AddDataTableSource(dtTmp);

            System.Data.DataTable TbTieuDe = new System.Data.DataTable();
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("NGAY");
            TbTieuDe.Columns.Add("SO_PHIEU");
            TbTieuDe.Columns.Add("TINH_TRANG");
            TbTieuDe.Columns.Add("MA_PROPOSAL");
            TbTieuDe.Columns.Add("THEO_DU_AN");
            TbTieuDe.Columns.Add("THEO_TG");
            TbTieuDe.Columns.Add("GAP");
            TbTieuDe.Columns.Add("HO_TEN");
            TbTieuDe.Columns.Add("PHONG_BAN1");
            TbTieuDe.Columns.Add("LY_DO_MUA_HANG");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("DVT");
            TbTieuDe.Columns.Add("SO_LUONG");
            TbTieuDe.Columns.Add("TON_KHO");
            TbTieuDe.Columns.Add("NGAY_GIAO_HANG");
            TbTieuDe.Columns.Add("MA_PB");
            TbTieuDe.Columns.Add("MA_CP");
            TbTieuDe.Columns.Add("TONG_CONG");
            TbTieuDe.Columns.Add("DIA_DIEM_GIAO_HANG");
            TbTieuDe.Columns.Add("NGUOI_NHAN");
            TbTieuDe.Columns.Add("PHONG_BAN2");
            TbTieuDe.Columns.Add("DIEN_THOAI");
            TbTieuDe.Columns.Add("DUYET");
            TbTieuDe.Columns.Add("TRUONG_PB");
            TbTieuDe.Columns.Add("THU_KHO");
            TbTieuDe.Columns.Add("NGUOI_DE_NGHI");
            TbTieuDe.Columns.Add("KY_NHAN");
            TbTieuDe.Columns.Add("LAN_BAN_HANH");
            TbTieuDe.Columns.Add("NHP002_F1");



            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "TIEU_DE", Commons.Modules.TypeLanguage);
            rTitle["NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "NGAY", Commons.Modules.TypeLanguage);
            rTitle["SO_PHIEU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "SO_PHIEU", Commons.Modules.TypeLanguage);
            rTitle["TINH_TRANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "TINH_TRANG", Commons.Modules.TypeLanguage);
            rTitle["MA_PROPOSAL"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "MA_PROPOSAL", Commons.Modules.TypeLanguage);
            rTitle["THEO_DU_AN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "THEO_DU_AN", Commons.Modules.TypeLanguage);
            rTitle["THEO_TG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "THEO_TG", Commons.Modules.TypeLanguage);
            rTitle["GAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "GAP", Commons.Modules.TypeLanguage);
            rTitle["HO_TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "HO_TEN", Commons.Modules.TypeLanguage);
            rTitle["PHONG_BAN1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "PHONG_BAN1", Commons.Modules.TypeLanguage);
            rTitle["LY_DO_MUA_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "LY_DO_MUA_HANG", Commons.Modules.TypeLanguage);
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "STT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "TEN_PT", Commons.Modules.TypeLanguage);
            rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "DVT", Commons.Modules.TypeLanguage);
            rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "SO_LUONG", Commons.Modules.TypeLanguage);
            rTitle["TON_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "TON_KHO", Commons.Modules.TypeLanguage);
            rTitle["NGAY_GIAO_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "NGAY_GIAO_HANG", Commons.Modules.TypeLanguage);
            rTitle["MA_PB"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "MA_PB", Commons.Modules.TypeLanguage);
            rTitle["MA_CP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "MA_CP", Commons.Modules.TypeLanguage);
            rTitle["TONG_CONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "TONG_CONG", Commons.Modules.TypeLanguage);
            rTitle["DIA_DIEM_GIAO_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "DIA_DIEM_GIAO_HANG", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "NGUOI_NHAN", Commons.Modules.TypeLanguage);
            rTitle["PHONG_BAN2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "PHONG_BAN2", Commons.Modules.TypeLanguage);
            rTitle["DIEN_THOAI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "DIEN_THOAI", Commons.Modules.TypeLanguage);
            rTitle["DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "DUYET", Commons.Modules.TypeLanguage);
            rTitle["TRUONG_PB"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "TRUONG_PB", Commons.Modules.TypeLanguage);
            rTitle["THU_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "THU_KHO", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_DE_NGHI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "NGUOI_DE_NGHI", Commons.Modules.TypeLanguage);
            rTitle["KY_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "KY_NHAN", Commons.Modules.TypeLanguage);
            rTitle["LAN_BAN_HANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "LAN_BAN_HANH", Commons.Modules.TypeLanguage);
            rTitle["NHP002_F1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangNF", "NHP002_F1", Commons.Modules.TypeLanguage);


            TbTieuDe.TableName = "TIEU_DE_NF";
            TbTieuDe.Rows.Add(rTitle);
            frmRptDexuat.AddDataTableSource(TbTieuDe);
            this.Cursor = Cursors.Default;
            frmRptDexuat.ShowDialog(this);

        }
        #endregion


        /// <summary>
        /// In dữ liệu
        /// </summary> 
        #region InCu
        private void InCu()
        {

        }
        #endregion
        /// <Lưu dữ liệu>
        /// Lưu dữ liệu
        /// </summary> 
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            Validate();
            if (((DataRowView)BindingDeXuatMuaHang.Current).Row["SO_DE_XUAT"] == null || ((DataRowView)BindingDeXuatMuaHang.Current).Row["SO_DE_XUAT"].Equals(DBNull.Value))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgSoDXNull", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                TxtSO_DE_XUAT.Focus();
                return;
            }
            if (TxtSO_DE_XUAT.Text.Trim() != "")
            {
                Vietsoft.SqlInfo SqlDx = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                System.Data.DataTable Tb = new System.Data.DataTable();
                Tb.Load(SqlDx.ExecuteReader(CommandType.StoredProcedure, "CheckSoDX", TxtSO_DE_XUAT.Text.Trim(), TxtMS_DE_XUAT.Text.ToString()));
                if (Tb.Rows.Count > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgSoDXTontai", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    TxtSO_DE_XUAT.Focus();
                    return;
                }
            }
            if (CboPHONG_BAN.SelectedValue == null || CboPHONG_BAN.SelectedValue.Equals(DBNull.Value))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChonBoPhan", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                CboPHONG_BAN.Focus();
                return;
            }

            try
            {
                string k = Convert.ToString(cmbKho.SelectedValue);
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChonKho", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbKho.Focus();
                return;
            }
            try
            {
                string k = Convert.ToString(cmbLoaiVT.SelectedValue);
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChonLoaiVT", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbLoaiVT.Focus();
                return;
            }
            #region  "Duyety theo key"
            //////////if (Commons.Modules.sPrivate == "VINHHOAN")
            //////////{
            //////////    try
            //////////    {
            //////////        //if (bCoDuyet && TxtNGUOI_DUYET.Text != "" && cboTTrang.SelectedValue.ToString() == "3")
            //////////        //{

            //////////        //    string input = Microsoft.VisualBasic.Interaction.InputBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
            //////////        //            "frmDeXuatMuaHang_New", "sVuiLongNhapMaPin", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
            //////////        //            "frmDeXuatMuaHang_New", "sNhapMaPin", Commons.Modules.TypeLanguage), "", -1, -1);

            //////////        //    try
            //////////        //    {
            //////////        //        int.Parse(input);
            //////////        //    }
            //////////        //    catch
            //////////        //    {
            //////////        //        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgMaPinPhaiLaSoNguyen", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //////////        //        return;
            //////////        //    }
            //////////        //    if (input.Length > 4)
            //////////        //    {
            //////////        //        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgMaPin4So", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //////////        //        return;
            //////////        //    }
            //////////        //    //txtKEY_DUYET.Text = Commons.Modules.ObjSystems.MEncryptMD5(TxtNGUOI_DUYET.Text + "&&" + TxtMS_DE_XUAT.Text.Replace("-", "").Replace("DX", ""), input);

            //////////        //    //txtKEY_DUYET.Text = Commons.Modules.ObjSystems.MDecryptMD5("wrxc+umcgkloJES1hSZPvwC2KKnZbIwV", input);

            //////////        //    string Key;
            //////////        //    Key = EncryptOrDecrypt(TxtMS_DE_XUAT.Text.Replace("-", "").Replace("DX", ""), input);
            //////////        //    Key = ConvertStringToHex(Key, System.Text.Encoding.ASCII);

            //////////        //    //Key = ConvertHexToString(Key, System.Text.Encoding.ASCII);
            //////////        //    //Key = EncryptOrDecrypt(Key, input);
            //////////        //    txtKEY_DUYET.Text = Key;


            //////////        //    ((DataRowView)BindingDeXuatMuaHang.Current).Row["KEY_DUYET"] = Key;
            //////////        //}
            //////////        //else
            //////////        //{
            //////////            if (TxtNGUOI_DUYET.Text == "" && cboTTrang.SelectedValue.ToString() != "3")
            //////////                ((DataRowView)BindingDeXuatMuaHang.Current).Row["KEY_DUYET"] = "";
            //////////        //}
            //////////    }
            //////////    catch
            //////////    {
            //////////        txtKEY_DUYET.Text = "";
            //////////        ((DataRowView)BindingDeXuatMuaHang.Current).Row["KEY_DUYET"] = "";

            //////////    }
            //////////}
            #endregion

            bCoDuyet = false;

            BindingDeXuatMuaHang.EndEdit();
            TbDeXuatMuaHang.AcceptChanges();

            foreach (DataGridViewRow rDeXuatMuaHangChiTiet in DgvDeXuatMuaHangChiTiet.Rows)
            {
                if (((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["SL_DE_XUAT"] == null || ((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["SL_DE_XUAT"].Equals(DBNull.Value) || Convert.ToDouble(((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["SL_DE_XUAT"]) <= 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgSLDXLONHON0", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvDeXuatMuaHangChiTiet.CurrentCell = rDeXuatMuaHangChiTiet.Cells["SL_DE_XUAT"];
                    return;
                }
                if (((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["SL_DA_DUYET"] == null || ((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["SL_DA_DUYET"].Equals(DBNull.Value) || Convert.ToDouble(((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["SL_DA_DUYET"]) < 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgSLDUYETLONHON0", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvDeXuatMuaHangChiTiet.CurrentCell = rDeXuatMuaHangChiTiet.Cells["SL_DA_DUYET"];
                    return;
                }
                if (Commons.Modules.sPrivate == "GREENFEED")
                {
                    if (((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["GHI_CHU"] == null || ((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["GHI_CHU"].Equals(DBNull.Value))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhaiNhapGhiChu", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        DgvDeXuatMuaHangChiTiet.CurrentCell = rDeXuatMuaHangChiTiet.Cells["GHI_CHU"];
                        return;
                    }
                }
                //if (Commons.Modules.sPrivate == "VECO")
                //{
                //    if (((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["TEN_MAY"] == null || ((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["TEN_MAY"].Equals(DBNull.Value))
                //    {
                //        Vietsoft.Information.MsgBox(this, "msgPhaiNhapTEN_MAY", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //        DgvDeXuatMuaHangChiTiet.CurrentCell = rDeXuatMuaHangChiTiet.Cells["TEN_MAY"];
                //        return;
                //    }
                //    if (((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["TEN_N_XUONG"] == null || ((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["TEN_N_XUONG"].Equals(DBNull.Value))
                //    {
                //        Vietsoft.Information.MsgBox(this, "msgPhaiNhapTEN_N_XUONG", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //        DgvDeXuatMuaHangChiTiet.CurrentCell = rDeXuatMuaHangChiTiet.Cells["TEN_N_XUONG"];
                //        return;
                //    }
                //    if (((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["SL_dE_XUAT"] == null || ((DataRowView)rDeXuatMuaHangChiTiet.DataBoundItem).Row["SL_dE_XUAT"].Equals(DBNull.Value))
                //    {
                //        Vietsoft.Information.MsgBox(this, "msgPhaiNhapSL_dE_XUAT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //        DgvDeXuatMuaHangChiTiet.CurrentCell = rDeXuatMuaHangChiTiet.Cells["SL_dE_XUAT"];
                //        return;
                //    }
                //}
            }
            for (int i = 0; i < DgvDeXuatMuaHangDichVu.Rows.Count - 1; i++)
            {
                if (((DataRowView)DgvDeXuatMuaHangDichVu.Rows[i].DataBoundItem).Row["TEN_DICH_VU"] == null || ((DataRowView)DgvDeXuatMuaHangDichVu.Rows[i].DataBoundItem).Row["TEN_DICH_VU"].Equals(DBNull.Value) || ((DataRowView)DgvDeXuatMuaHangDichVu.Rows[i].DataBoundItem).Row["TEN_DICH_VU"].ToString().Trim().Equals(String.Empty))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNullTenDichVu", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);


                    DgvDeXuatMuaHangDichVu.CurrentCell = DgvDeXuatMuaHangDichVu.Rows[i].Cells["TEN_DICH_VU_DV"];
                    return;
                }
                if (((DataRowView)DgvDeXuatMuaHangDichVu.Rows[i].DataBoundItem).Row["DVT"] == null || ((DataRowView)DgvDeXuatMuaHangDichVu.Rows[i].DataBoundItem).Row["DVT"].Equals(DBNull.Value) || ((DataRowView)DgvDeXuatMuaHangDichVu.Rows[i].DataBoundItem).Row["DVT"].ToString().Trim().Equals(String.Empty))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNullDVT", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    DgvDeXuatMuaHangDichVu.CurrentCell = DgvDeXuatMuaHangDichVu.Rows[i].Cells["DVT_DV"];
                    return;
                }
                if (((DataRowView)DgvDeXuatMuaHangDichVu.Rows[i].DataBoundItem).Row["SL_DE_XUAT"] == null || ((DataRowView)DgvDeXuatMuaHangDichVu.Rows[i].DataBoundItem).Row["SL_DE_XUAT"].Equals(DBNull.Value) || Convert.ToDouble(((DataRowView)DgvDeXuatMuaHangDichVu.Rows[i].DataBoundItem).Row["SL_DE_XUAT"]) <= 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgSLDXDVLONHON0", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvDeXuatMuaHangDichVu.CurrentCell = DgvDeXuatMuaHangDichVu.Rows[i].Cells["SL_DE_XUAT_DV"];
                    return;
                }
            }

            DataRow dr = ((DataRowView)BindingDeXuatMuaHang.Current).Row;
            if (string.IsNullOrEmpty(dr["MS_TO"].ToString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChonBoPhan", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                CboPHONG_BAN.Text = "";
                CboPHONG_BAN.Focus();
                return;
            }
            Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            if (TrangThai == "Add")
            {
                System.Data.DataTable TbDuyetDeXuatMH = new System.Data.DataTable();
                TbDuyetDeXuatMH.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DUYET_DE_XUAT_MH", (CboPHONG_BAN.Text == "" ? "-1" : CboPHONG_BAN.SelectedValue)));
                foreach (DataColumn ClDuyetDeXuatMH in TbDuyetDeXuatMH.Columns)
                {
                    ClDuyetDeXuatMH.ReadOnly = false;
                    ClDuyetDeXuatMH.AllowDBNull = true;
                }
                foreach (DataRow rDuyetDeXuatMH in TbDuyetDeXuatMH.Rows)
                {
                    rDuyetDeXuatMH["MS_DE_XUAT"] = ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["MS_DE_XUAT"];
                    TbDuyetDeXuatMuaHang.Rows.Add(rDuyetDeXuatMH.ItemArray);
                }
            }
            #region Cap Nhap Tal Lieu Len server
            string sSql = "";
            System.Data.DataTable dtTmp = new System.Data.DataTable();

            string sDDan = sDuongDanTLDichVu + DateTime.Now.Date.ToString("yyyyMMdd");

            try
            {
                if (!System.IO.Directory.Exists(sDDan))
                {
                    System.IO.Directory.CreateDirectory(sDDan);
                }

                dtTmp = TbDeXuatMuaHangDichVu.DefaultView.ToTable();

                try
                {
                    foreach (DataRowView drRow in TbDeXuatMuaHangDichVu.DefaultView)
                    {
                        if (System.IO.File.Exists(drRow["DUONG_DAN_TL"].ToString()))
                        {
                            string sNewPath = sDDan + "\\" + System.IO.Path.GetFileName(drRow["DUONG_DAN_TL"].ToString()).ToString();
                            if (!System.IO.File.Exists(sNewPath))
                                Commons.Modules.ObjSystems.LuuDuongDan(drRow["DUONG_DAN_TL"].ToString(), sNewPath);
                            drRow["DUONG_DAN_TL"] = sNewPath;
                        }
                    }
                    TbDeXuatMuaHangDichVu.AcceptChanges();
                }
                catch { }


            }
            catch { }
            #endregion


            SqlDeXuatMuaHang.BeginTransaction();
            try
            {
                DataRow drView = ((DataRowView)BindingDeXuatMuaHang.Current).Row;
                switch (TrangThai)
                {
                    case "Add":
                        string MSDXKiem = Vietsoft.Information.GetID("DX");
                        if (MSDXKiem != TxtMS_DE_XUAT.Text) CapNhapMaSoDX(TxtMS_DE_XUAT.Text, MSDXKiem);
                        Vietsoft.DataInfo.InsertDataRow(SqlDeXuatMuaHang, "SP_Y_INSERT_DE_XUAT_MUA_HANG", drView);

                        if (Commons.Modules.sPrivate == "VECO")
                        {
                            Vietsoft.DataInfo.InsertDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DE_XUAT_MUA_HANG_CHI_TIET_VECO", TbDeXuatMuaHangChiTiet.DefaultView);
                            Vietsoft.DataInfo.InsertDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DE_XUAT_MUA_HANG_DICH_VU_VECO", TbDeXuatMuaHangDichVu.DefaultView);
                        }
                        else
                        {
                            Vietsoft.DataInfo.InsertDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DE_XUAT_MUA_HANG_CHI_TIET", TbDeXuatMuaHangChiTiet.DefaultView);
                            Vietsoft.DataInfo.InsertDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DE_XUAT_MUA_HANG_DICH_VU", TbDeXuatMuaHangDichVu.DefaultView);
                        }
                        Vietsoft.DataInfo.InsertDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DUYET_DE_XUAT_MUA_HANG", TbDuyetDeXuatMuaHang.DefaultView);

                        break;
                    case "Edit":
                        drView["NGAY_SUA"] = Commons.Modules.ObjSystems.GetNgayHeThong();
                        drView["NGUOI_SUA"] = Commons.Modules.UserName;
                        Vietsoft.DataInfo.UpdateDataRow(SqlDeXuatMuaHang, "SP_Y_EDIT_DE_XUAT_MUA_HANG", drView);
                        if (Commons.Modules.sPrivate == "VECO")
                        {
                            Vietsoft.DataInfo.UpdateDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DE_XUAT_MUA_HANG_CHI_TIET_VECO", "SP_Y_EDIT_DE_XUAT_MUA_HANG_CHI_TIET_VECO", "SP_Y_CHECK_DE_XUAT_MUA_HANG_CHI_TIET", TbDeXuatMuaHangChiTiet.DefaultView, "MS_DE_XUAT", "MS_PT");

                            Vietsoft.DataInfo.UpdateDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DE_XUAT_MUA_HANG_DICH_VU_VECO", "SP_Y_EDIT_DE_XUAT_MUA_HANG_DICH_VU_VECO", "SP_Y_CHECK_DE_XUAT_MUA_HANG_DICH_VU", TbDeXuatMuaHangDichVu.DefaultView, "MS_DE_XUAT", "MS_DICH_VU");
                        }
                        else
                        {
                            Vietsoft.DataInfo.UpdateDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DE_XUAT_MUA_HANG_CHI_TIET", "SP_Y_EDIT_DE_XUAT_MUA_HANG_CHI_TIET", "SP_Y_CHECK_DE_XUAT_MUA_HANG_CHI_TIET", TbDeXuatMuaHangChiTiet.DefaultView, "MS_DE_XUAT", "MS_PT");

                            Vietsoft.DataInfo.UpdateDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DE_XUAT_MUA_HANG_DICH_VU", "SP_Y_EDIT_DE_XUAT_MUA_HANG_DICH_VU", "SP_Y_CHECK_DE_XUAT_MUA_HANG_DICH_VU", TbDeXuatMuaHangDichVu.DefaultView, "MS_DE_XUAT", "MS_DICH_VU");
                        }


                        Vietsoft.DataInfo.UpdateDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DUYET_DE_XUAT_MUA_HANG", "SP_Y_EDIT_DUYET_DE_XUAT_MUA_HANG", "SP_Y_CHECK_DUYET_DE_XUAT_MUA_HANG", TbDuyetDeXuatMuaHang.DefaultView, "MS_DE_XUAT", "NGUOI_DUYET");
                        break;
                }
                string exec = "";


                if (Commons.Modules.iTRFData == 1)
                {
                    if (!TRFDeXuat(SqlDeXuatMuaHang, TxtMS_DE_XUAT.Text, -1))
                    {
                        SqlDeXuatMuaHang.RollbackTransaction();
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCapNhapDataTrungGianLoi", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                        return;
                    }
                }
                SqlDeXuatMuaHang.CommitTransaction();
                BindingDeXuatMuaHang.EndEdit();
                TbDeXuatMuaHang.AcceptChanges();
                TbDeXuatMuaHangChiTiet.AcceptChanges();
                TbDeXuatMuaHangDichVu.AcceptChanges();
                TbDuyetDeXuatMuaHang.AcceptChanges();





                if (bSuaDuyet && bThayDoiDuyet)
                {
                    dtTmp = new System.Data.DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT * FROM DE_XUAT_MUA_HANG_DUYET WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "' AND NGUOI_DUYET = '" + Commons.Modules.UserName + "' AND DUYET = 1"));
                    if (dtTmp.Rows.Count > 0 && bThayDoiDuyet)
                    {
                        InDeNghiMuaHangVinhHoan(2);
                    }
                }

                TrangThai = String.Empty;
                InitializeForm();
                tblCondition.Enabled = true;
            }
            catch (Exception EX)
            {
                SqlDeXuatMuaHang.RollbackTransaction();
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgUpdateError", Commons.Modules.TypeLanguage) + "\n" + EX.Message.ToString(), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            bSuaDuyet = false;
            Cursor = Cursors.Default;
        }
        //Chuyen du lieu wa trung gian
        private bool TRFDeXuat(Vietsoft.SqlInfo objTrans, string MsDXuat, int TrangThai)
        {
            try
            {
                System.Data.DataTable dttmp = new System.Data.DataTable();
                dttmp.Load(objTrans.ExecuteReader(CommandType.StoredProcedure, "spTRFDeXuat", MsDXuat, TrangThai));
                if (dttmp.Rows.Count > 0)
                {
                    MessageBox.Show(dttmp.Rows[0][3].ToString() + "\n" + dttmp.Rows[0][5].ToString());
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        //Cap nhap ma so de xuat khi ghi neu ma so da ton tai
        private void CapNhapMaSoDX(string sMSDXCu, string sMSDXMoi)
        {
            DataRow dr = ((DataRowView)BindingDeXuatMuaHang.Current).Row;

            dr["MS_DE_XUAT"] = sMSDXMoi;
            if (dr["SO_DE_XUAT"].ToString() == sMSDXCu)
                dr["SO_DE_XUAT"] = sMSDXMoi;

            DataRow[] rows = TbDeXuatMuaHangChiTiet.Select("MS_DE_XUAT = '" + sMSDXCu + "' ");
            for (int i = 0; i < rows.Length; i++)
                rows[i]["MS_DE_XUAT"] = sMSDXMoi;

            rows = TbDeXuatMuaHangDichVu.Select("MS_DE_XUAT = '" + sMSDXCu + "' ");
            for (int i = 0; i < rows.Length; i++)
                rows[i]["MS_DE_XUAT"] = sMSDXMoi;

            rows = TbDuyetDeXuatMuaHang.Select("MS_DE_XUAT = '" + sMSDXCu + "' ");
            for (int i = 0; i < rows.Length; i++)
                rows[i]["MS_DE_XUAT"] = sMSDXMoi;


        }
        /// <summary>
        /// Không lưu dữ liệu
        /// </summary> 
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            BindingDeXuatMuaHang.CancelEdit();
            TbDeXuatMuaHang.RejectChanges();
            TbDeXuatMuaHangChiTiet.RejectChanges();
            TbDeXuatMuaHangDichVu.RejectChanges();
            TbDuyetDeXuatMuaHang.RejectChanges();
            TrangThai = String.Empty;
            InitializeForm();
            tblCondition.Enabled = true;
            bSuaDuyet = false;
        }
        /// <summary>
        /// Trình duyệt
        /// </summary>       
        private void BtnTrinhDuyet_Click(object sender, EventArgs e)
        {
            Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            try
            {

                SqlDeXuatMuaHang.BeginTransaction();
                ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["TRANG_THAI"] = 2;
                ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["TEN_TRANG_THAI"] = "Trình duyệt";
                Vietsoft.DataInfo.UpdateDataRow(SqlDeXuatMuaHang, "SP_Y_EDIT_DE_XUAT_MUA_HANG", ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row);
                if (Commons.Modules.iTRFData == 1)
                {
                    if (!TRFDeXuat(SqlDeXuatMuaHang, TxtMS_DE_XUAT.Text, 2))
                    {
                        SqlDeXuatMuaHang.RollbackTransaction();
                        BindingDeXuatMuaHang.CancelEdit();
                        InitializeControl();
                        return;
                    }
                }
                SqlDeXuatMuaHang.CommitTransaction();
                BindingDeXuatMuaHang.EndEdit();
                InDeNghiMuaHangVinhHoan(1);
            }
            catch
            {
                SqlDeXuatMuaHang.RollbackTransaction();
                BindingDeXuatMuaHang.CancelEdit();
            }

            InitializeControl();
        }
        /// <summary>
        /// Đóng tài liệu
        /// </summary> 
        private void BtnDong_Click(object sender, EventArgs e)
        {
            if (Commons.Modules.sPrivate == "TRUNGNGUYEN")
            {
                if (((DataRowView)BindingDeXuatMuaHang.Current).Row["TEN_TTHAI"].ToString().Trim() != "Hoàn thành")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhieuChuaHoanThanhKhongTheNT", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        ; return;
                }
                else
                {
                    //nếu là trung nguyên thì cập nhật tất cả phiếu nhập và tự động tạo phiếu xuất theo phiếu nhập
                    System.Data.DataTable dtpn = new System.Data.DataTable();
                    dtpn.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT MS_DH_NHAP_PT FROM dbo.IC_DON_HANG_NHAP WHERE MS_DDH = '" + TxtMS_DE_XUAT.Text + "'"));
                    for (int i = 0; i < dtpn.Rows.Count; i++)
                    {
                        //get ID
                        try
                        {
                            //cập nhật lại lock phiếu nhập
                            string mspx = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "sp_get_id", "PX", DateTime.Now));
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.IC_DON_HANG_NHAP SET LOCK = 1 WHERE MS_DH_NHAP_PT = '"+ dtpn.Rows[i][0].ToString() + "'");
                            if (Convert.ToInt32(SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET WHERE MS_DH_NHAP_PT ='"+ dtpn.Rows[i][0].ToString() +"'")) == 0)
                            {
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spUpdateAutoXuatDeXuat", mspx, dtpn.Rows[i][0].ToString());
                            }
                        }
                        catch
                        {
                        }
                    }


                }
            }
            Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            try
            {
                SqlDeXuatMuaHang.BeginTransaction();
                ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["TRANG_THAI"] = 4;
                ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["TEN_TRANG_THAI"] = "Đóng";
                Vietsoft.DataInfo.UpdateDataRow(SqlDeXuatMuaHang, "SP_Y_EDIT_DE_XUAT_MUA_HANG", ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row);
                if (Commons.Modules.iTRFData == 1)
                {
                    if (!TRFDeXuat(SqlDeXuatMuaHang, TxtMS_DE_XUAT.Text, 4))
                    {
                        SqlDeXuatMuaHang.RollbackTransaction();
                        BindingDeXuatMuaHang.CancelEdit();
                        InitializeControl();
                        return;
                    }
                }
                string sSql = "UPDATE DE_XUAT_MUA_HANG SET NGAY_DONG = GETDATE(), NGUOI_DONG = N'" + Commons.Modules.UserName + "' WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "' ";
                SqlDeXuatMuaHang.ExecuteNonQuery(sSql);

                SqlDeXuatMuaHang.CommitTransaction();
                BindingDeXuatMuaHang.EndEdit();
                BindingDeXuatMuaHang.RemoveCurrent();
                TbDeXuatMuaHang.AcceptChanges();
                TbDeXuatMuaHangChiTiet.AcceptChanges();

                CNhapPT();
            }
            catch
            {
                SqlDeXuatMuaHang.RollbackTransaction();
                BindingDeXuatMuaHang.CancelEdit();
            }

            InitializeControl();
        }
        private void CNhapPT()
        {

            int iTT = -1;
            try
            {
                if (chkIsLock.Checked)
                {
                    cboTinhTrang.EditValue = -1;
                    cboTinhTrang.Enabled = false;
                    iTT = 4;
                }
                else
                {
                    cboTinhTrang.Enabled = true;
                    iTT = int.Parse(cboTinhTrang.EditValue.ToString());
                }
            }
            catch { }

            lbl.Text = "Tổng vật tư đề xuất : 0\n" + "Tổng vật tư hoàn thành : 0\n" + "Phần trăm hoàn thành : 0";
            System.Data.DataTable dtTT = new System.Data.DataTable();
            try
            {
                dtTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPTHTDX",
                        lokPhongBan.EditValue.ToString(), datFromDate.DateTime,
                        Convert.ToDateTime(datToDate.DateTime.AddDays(1).ToShortDateString()),
                        iTT, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

                lbl.Text = dtTT.Rows[0][0].ToString();
            }
            catch { }
        }
        private void DgvDuyetDeXuatMuaHang_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = "";
            if (!DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["NGUOI_DUYET"].Value.ToString().ToUpper().Trim().Equals(Commons.Modules.UserName.ToUpper().Trim()))
            {
                DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhacUserDuyet", Commons.Modules.TypeLanguage);
                e.Cancel = true;
                return;
            }
            else
            {
                if (!((((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"].Equals(2) || ((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"].Equals(3))))
                {
                    DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTrangThaiChuaDuyet", Commons.Modules.TypeLanguage);
                    e.Cancel = true;
                    return;
                }
                string sSql = "SELECT * FROM DE_XUAT_MUA_HANG_DUYET WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "' AND TT_DUYET < " +
                        DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["TT_DUYET"].Value.ToString() + " AND BAT_BUOC = 1 ORDER BY TT_DUYET DESC  ";
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    sSql = "SELECT * FROM DE_XUAT_MUA_HANG_DUYET WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "' AND TT_DUYET = " +
                        dtTmp.Rows[0]["TT_DUYET"].ToString() + " AND BAT_BUOC = 1 AND ISNULL(DUYET,0) = 0 ORDER BY TT_DUYET DESC  ";
                    dtTmp = new System.Data.DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBuocTruocBacBuocChuaDuyet", Commons.Modules.TypeLanguage);
                        e.Cancel = true;
                        return;
                    }
                }


                sSql = "SELECT * FROM DE_XUAT_MUA_HANG_DUYET WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "' AND TT_DUYET > " +
                       DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["TT_DUYET"].Value.ToString() + " AND DUYET = 1 ORDER BY TT_DUYET DESC  ";
                dtTmp = new System.Data.DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBuocSauDaDuyet", Commons.Modules.TypeLanguage);
                    e.Cancel = true;
                    return;

                }
            }
            bThayDoiDuyet = true;
            DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = "";
        }
        private void DgvDuyetDeXuatMuaHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                DateTime NgayHT = Commons.Modules.ObjSystems.GetNgayHeThong();

                if (DgvDuyetDeXuatMuaHang.Columns[e.ColumnIndex].Name == "DUYET")
                {


                    if (DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["QUYET_DINH"].Value.Equals(true) && DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["DUYET"].Value.Equals(true))
                    {

                        if (KiemDuyet(int.Parse(DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["TT_DUYET"].Value.ToString())))
                        {
                            ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGAY_DUYET"] = NgayHT;
                            ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_DUYET"] = Commons.Modules.UserName;
                            ((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"] = 3;
                            ((DataRowView)BindingDeXuatMuaHang.Current).Row["TEN_TRANG_THAI"] = "Duyệt";
                            bCoDuyet = true;
                        }
                        else
                        {
                            bCoDuyet = false;
                            ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGAY_DUYET"] = DBNull.Value;
                            ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_DUYET"] = DBNull.Value;
                            if (((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"].Equals(3))
                            {
                                ((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"] = 2;
                                ((DataRowView)BindingDeXuatMuaHang.Current).Row["TEN_TRANG_THAI"] = "Trình duyệt";
                            }
                        }

                        DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["NGAY_DUYET"].Value = NgayHT;
                        //if (DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["QUYET_DINH"].Value.Equals(true))
                        //{
                        //    ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGAY_DUYET"] = NgayHT;
                        //    ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_DUYET"] = Commons.Modules.UserName;
                        //    ((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"] = 3;
                        //    ((DataRowView)BindingDeXuatMuaHang.Current).Row["TEN_TRANG_THAI"] = "Duyệt";
                        //}
                    }
                    else
                    {
                        DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["NGAY_DUYET"].Value = DBNull.Value;
                        if (DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["QUYET_DINH"].Value.Equals(true))
                        {
                            ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGAY_DUYET"] = DBNull.Value;
                            ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_DUYET"] = DBNull.Value;
                            if (((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"].Equals(3))
                            {
                                ((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"] = 2;
                                ((DataRowView)BindingDeXuatMuaHang.Current).Row["TEN_TRANG_THAI"] = "Trình duyệt";
                            }
                        }
                        else
                        {
                            ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGAY_DUYET"] = DBNull.Value;
                            ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_DUYET"] = DBNull.Value;
                            if (((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"].Equals(3))
                            {
                                ((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"] = 2;
                                ((DataRowView)BindingDeXuatMuaHang.Current).Row["TEN_TRANG_THAI"] = "Trình duyệt";
                            }
                        }
                    }

                    if (DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["DUYET"].Value.Equals(true))
                        DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["NGAY_DUYET"].Value = NgayHT;
                    else
                        DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["NGAY_DUYET"].Value = DBNull.Value;
                }




            }
        }
        private Boolean KiemDuLieyKey(int STTDuyet)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmDeXuatMuaHang_New", "sVuiLongNhapMaPin", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                    "frmDeXuatMuaHang_New", "sNhapMaPin", Commons.Modules.TypeLanguage), "", -1, -1);

            return true;
        }

        private Boolean KiemDuyet(int STTDuyet)
        {
            string sSql = "SELECT CASE WHEN COUNT (*) IS NULL THEN 0 ELSE COUNT (*) END FROM DE_XUAT_MUA_HANG_DUYET WHERE QUYET_DINH = 1 AND TT_DUYET > " + STTDuyet.ToString() + " AND BAT_BUOC = 1 AND MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "' ";
            if ((int)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql) > 0)
            {
                return false;
            }
            return true;
        }
        private Boolean KiemCheck(int STTDuyet)
        {
            string sSql = "SELECT CASE WHEN COUNT (*) IS NULL THEN 0 ELSE COUNT (*) END FROM DE_XUAT_MUA_HANG_DUYET WHERE TT_DUYET > 3 AND BAT_BUOC = 1";
            if ((int)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql) > 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// DgvDeXuatMuaHangChiTiet
        /// </summary> 
        private void DgvDeXuatMuaHangChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (DgvDeXuatMuaHangChiTiet.Columns[e.ColumnIndex].Name)
                {
                    case "SL_DE_XUAT":
                        DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["SL_DA_DUYET"].Value = DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["SL_DE_XUAT"].Value;
                        break;
                    case "SL_DA_DUYET":
                    case "DON_GIA":
                        try
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["SL_DA_DUYET"].Value) * Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["DON_GIA"].Value);
                        }
                        catch
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value = DBNull.Value;
                        }
                        break;
                    case "THANH_TIEN":
                        try
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_VND"].Value = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value) * Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value);
                        }
                        catch
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_VND"].Value = DBNull.Value;
                        }
                        try
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_USD"].Value = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value) * Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value);
                        }
                        catch
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_USD"].Value = DBNull.Value;
                        }
                        break;
                    case "TY_GIA":
                        try
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_VND"].Value = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value) * Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value);
                        }
                        catch
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_VND"].Value = DBNull.Value;
                        }
                        break;
                    case "TY_GIA_USD":
                        try
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_USD"].Value = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN"].Value) * Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value);
                        }
                        catch
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["THANH_TIEN_USD"].Value = DBNull.Value;
                        }
                        break;
                    case "NGOAI_TE":
                        try
                        {
                            Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                            System.Data.DataTable TbNgoaiTe = new System.Data.DataTable();
                            TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["NGOAI_TE"].Value));
                            if (TbNgoaiTe.Rows.Count > 0)
                            {
                                DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = TbNgoaiTe.Rows[0]["TI_GIA"];
                                DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                            }
                            else
                            {
                                DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = DBNull.Value;
                                DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = DBNull.Value;
                            }
                        }
                        catch
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = DBNull.Value;
                            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = DBNull.Value;
                        }
                        break;
                }
            }
        }

        private void DgvDeXuatMuaHangDichVu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (DgvDeXuatMuaHangDichVu.Columns[e.ColumnIndex].Name)
                {
                    case "SL_DE_XUAT_DV":
                    case "DON_GIA_DV":
                        try
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value = Convert.ToDouble(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["SL_DE_XUAT_DV"].Value) * Convert.ToDouble(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["DON_GIA_DV"].Value);
                        }
                        catch
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value = DBNull.Value;
                        }
                        break;
                    case "THANH_TIEN_DV":
                        try
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_VND_DV"].Value = Convert.ToDouble(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value) * Convert.ToDouble(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_DV"].Value);
                        }
                        catch
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_VND_DV"].Value = DBNull.Value;
                        }
                        try
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_USD_DV"].Value = Convert.ToDouble(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value) * Convert.ToDouble(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value);
                        }
                        catch
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_USD_DV"].Value = DBNull.Value;
                        }
                        break;
                    case "TY_GIA_DV":
                        try
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_VND_DV"].Value = Convert.ToDouble(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value) * Convert.ToDouble(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_DV"].Value);
                        }
                        catch
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_VND_DV"].Value = DBNull.Value;
                        }
                        break;
                    case "TY_GIA_USD_DV":
                        try
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_USD_DV"].Value = Convert.ToDouble(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_DV"].Value) * Convert.ToDouble(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value);
                        }
                        catch
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["THANH_TIEN_USD_DV"].Value = DBNull.Value;
                        }
                        break;
                    case "NGOAI_TE_DV":
                        try
                        {
                            Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                            System.Data.DataTable TbNgoaiTe = new System.Data.DataTable();
                            TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["NGOAI_TE_DV"].Value));
                            if (TbNgoaiTe.Rows.Count > 0)
                            {
                                DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_DV"].Value = TbNgoaiTe.Rows[0]["TI_GIA"];
                                DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                            }
                            else
                            {
                                DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_DV"].Value = DBNull.Value;
                                DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value = DBNull.Value;
                            }
                        }
                        catch
                        {
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_DV"].Value = DBNull.Value;
                            DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value = DBNull.Value;
                        }
                        break;
                    case "NGAY_DX":
                        DateTime dNgay;
                        try
                        {
                            DateTime.TryParse(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["NGAY_DX"].Value.ToString(), out dNgay);
                        }
                        catch { DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TY_GIA_USD_DV"].Value = DBNull.Value; }
                        break;

                }
            }
        }

        private void btnPhieumuonhang_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtSO_DE_XUAT.Text.Trim() != String.Empty && TbDeXuatMuaHang.Rows.Count > 0)
                {

                    Excel.Application ExcelApp;
                    Excel.Workbook objBook;
                    Excel.Worksheet objSheet;

                    ExcelApp = new Excel.ApplicationClass();

                    objBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                    objSheet = (Excel.Worksheet)objBook.Sheets["Sheet1"];
                    objSheet.Name = "Materials borrowed";

                    objSheet.Cells[1, 1] = "Details";

                    string sSql = "SELECT CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END AS TEN_CT FROM THONG_TIN_CHUNG";
                    try
                    {
                        sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    }
                    catch
                    {
                        sSql = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "nameCompany", Commons.Modules.TypeLanguage);
                    }

                    Excel.Range namecompany = objSheet.get_Range("A1", "D1");
                    namecompany.Font.Bold = true;
                    namecompany.MergeCells = true;
                    namecompany.Font.Bold = true;
                    namecompany.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    namecompany.Value2 = sSql;

                    sSql = "SELECT CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN DIA_CHI_VIET ELSE DIA_CHI_ANH END AS TEN_CT FROM THONG_TIN_CHUNG";
                    try
                    {
                        sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    }
                    catch
                    {
                        sSql = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "addressCompany", Commons.Modules.TypeLanguage);
                    }


                    Excel.Range dccty = objSheet.get_Range("A2", "D2");
                    dccty.Font.Bold = true;
                    dccty.MergeCells = true;
                    dccty.Font.Bold = true;
                    dccty.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    dccty.Value2 = sSql;


                    Excel.Range TieuDe = objSheet.get_Range("A4", "J4");
                    TieuDe.Merge(true);
                    TieuDe.MergeCells = true;
                    TieuDe.Font.Bold = true;
                    TieuDe.Font.Size = 18;
                    TieuDe.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "TitleEXEL", Commons.Modules.TypeLanguage);
                    TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                    Excel.Range ghichu = objSheet.get_Range("A6", "J6");
                    ghichu.Font.Bold = true;
                    ghichu.Merge(true);
                    ghichu.MergeCells = true;
                    ghichu.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    ghichu.Value2 = TxtGHI_CHU.Text;



                    //header table
                    Excel.Range date = objSheet.get_Range("A8", "A8");
                    date.Font.Bold = true;
                    date.ColumnWidth = 10;
                    date.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    date.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    date.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "xlDate", Commons.Modules.TypeLanguage);
                    //Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "TitleEXEL", Commons.Modules.TypeLanguage); 
                    Range company = objSheet.get_Range("B8", "B8");
                    company.Font.Bold = true;
                    company.ColumnWidth = 15;
                    company.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    company.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    company.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "xlCompany", Commons.Modules.TypeLanguage);

                    Range request = objSheet.get_Range("C8", "C8");
                    request.Font.Bold = true;
                    request.ColumnWidth = 15;
                    request.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    request.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    request.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "xlRequestNo", Commons.Modules.TypeLanguage);

                    Range materialcode = objSheet.get_Range("D8", "D8");
                    materialcode.ColumnWidth = 15;
                    materialcode.Font.Bold = true;
                    materialcode.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    materialcode.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    materialcode.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "xlMaterialCode", Commons.Modules.TypeLanguage);

                    Range Part = objSheet.get_Range("E8", "E8");
                    Part.ColumnWidth = 15;
                    Part.Font.Bold = true;
                    Part.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    Part.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    Part.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "PART_NO", Commons.Modules.TypeLanguage);

                    Range materialname = objSheet.get_Range("F8", "F8");
                    materialname.Font.Bold = true;
                    materialname.ColumnWidth = 25;
                    materialname.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    materialname.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    materialname.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "xlMaterialNam", Commons.Modules.TypeLanguage);

                    Range spec = objSheet.get_Range("G8", "G8");
                    spec.Font.Bold = true;
                    spec.ColumnWidth = 20;
                    spec.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    spec.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    spec.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "xlSpec", Commons.Modules.TypeLanguage);

                    Range unit = objSheet.get_Range("H8", "H8");
                    unit.Font.Bold = true;
                    unit.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    unit.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    unit.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "xlUnit", Commons.Modules.TypeLanguage);

                    Range qty = objSheet.get_Range("I8", "I8");
                    qty.Font.Bold = true;
                    qty.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    qty.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    qty.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "xlQty", Commons.Modules.TypeLanguage);

                    Range remark = objSheet.get_Range("J8", "J8");
                    remark.Font.Bold = true;
                    remark.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    remark.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    remark.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "xlRemark", Commons.Modules.TypeLanguage);

                    Range approval = objSheet.get_Range("K8", "K8");
                    approval.Font.Bold = true;
                    approval.ColumnWidth = 20;
                    approval.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    approval.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    approval.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang", "xlAproval", Commons.Modules.TypeLanguage);




                    //data
                    int rowcount = DgvDeXuatMuaHangChiTiet.RowCount;
                    int rowx = 8 + rowcount;

                    Range date1 = objSheet.get_Range("A9", "A" + rowx.ToString());
                    date1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    date1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    date1.Merge(true);
                    date1.MergeCells = true;
                    date1.Value2 = "";

                    Range company1 = objSheet.get_Range("B9", "B" + rowx.ToString());
                    company1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    company1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    company1.Merge(true);
                    company1.MergeCells = true;
                    company1.Value2 = "";


                    Range REQUESTNO = objSheet.get_Range("C9", "C" + rowx.ToString());
                    REQUESTNO.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    REQUESTNO.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    REQUESTNO.VerticalAlignment = XlHAlign.xlHAlignCenter;
                    REQUESTNO.Merge(true);
                    REQUESTNO.MergeCells = true;
                    REQUESTNO.Value2 = TxtSO_DE_XUAT.Text;


                    Range APPROVAL1 = objSheet.get_Range("K9", "K" + rowx.ToString());
                    APPROVAL1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    APPROVAL1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    APPROVAL1.Value2 = "";


                    for (int i = 0; i < rowcount; i++)
                    {
                        Range MS_PT = objSheet.get_Range("D" + (9 + i).ToString(), "D" + (9 + i).ToString());
                        MS_PT.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        MS_PT.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        MS_PT.Value2 = DgvDeXuatMuaHangChiTiet.Rows[i].Cells["MS_PT"].Value.ToString();

                        Range PART_NO = objSheet.get_Range("E" + (9 + i).ToString(), "E" + (9 + i).ToString());
                        PART_NO.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        PART_NO.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        PART_NO.Value2 = DgvDeXuatMuaHangChiTiet.Rows[i].Cells["PART_NO"].Value.ToString();

                        Range TEN_PT = objSheet.get_Range("F" + (9 + i).ToString(), "F" + (9 + i).ToString());
                        TEN_PT.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        TEN_PT.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        TEN_PT.Value2 = DgvDeXuatMuaHangChiTiet.Rows[i].Cells["TEN_PT"].Value.ToString();

                        Range QUY_CACH = objSheet.get_Range("G" + (9 + i).ToString(), "G" + (9 + i).ToString());
                        QUY_CACH.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        QUY_CACH.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        QUY_CACH.Value2 = DgvDeXuatMuaHangChiTiet.Rows[i].Cells["QUY_CACH"].Value.ToString();

                        Range DVT = objSheet.get_Range("H" + (9 + i).ToString(), "H" + (9 + i).ToString());
                        DVT.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        DVT.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        DVT.Value2 = DgvDeXuatMuaHangChiTiet.Rows[i].Cells["DVT"].Value.ToString();

                        Range SL_DE_XUAT = objSheet.get_Range("I" + (9 + i).ToString(), "I" + (9 + i).ToString());
                        SL_DE_XUAT.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        SL_DE_XUAT.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        SL_DE_XUAT.Value2 = DgvDeXuatMuaHangChiTiet.Rows[i].Cells["SL_DA_DUYET"].Value.ToString();

                        Range GHI_CHU = objSheet.get_Range("J" + (9 + i).ToString(), "J" + (9 + i).ToString());
                        GHI_CHU.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                        GHI_CHU.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        GHI_CHU.Value2 = DgvDeXuatMuaHangChiTiet.Rows[i].Cells["GHI_CHU"].Value.ToString();
                    }
                    ExcelApp.Visible = true;
                }
            }
            catch { }
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            frmChonDeXuat frmChonDeXuat = new frmChonDeXuat();
            if (frmChonDeXuat.ShowDialog(this) == DialogResult.OK)
            {
                Vietsoft.SqlInfo SqlPhuTung = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                System.Data.DataTable _TbSource = new System.Data.DataTable();
                _TbSource.Load(SqlPhuTung.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_PHU_TUNG_DE_XUAT_COPY", frmChonDeXuat.MS_DE_XUAT));
                for (int i = 0; i < _TbSource.DefaultView.Count; i++)
                {
                    DataRow rDeXuatMuaHangChiTiet = TbDeXuatMuaHangChiTiet.NewRow();
                    rDeXuatMuaHangChiTiet["MS_PT"] = _TbSource.DefaultView[i].Row["MS_PT"];
                    rDeXuatMuaHangChiTiet["TEN_PT"] = _TbSource.DefaultView[i].Row["TEN_PT"];
                    rDeXuatMuaHangChiTiet["PART_NO"] = _TbSource.DefaultView[i].Row["PART_NO"];
                    rDeXuatMuaHangChiTiet["QUY_CACH"] = _TbSource.DefaultView[i].Row["QUY_CACH"];
                    rDeXuatMuaHangChiTiet["DVT"] = _TbSource.DefaultView[i].Row["DVT"];
                    rDeXuatMuaHangChiTiet["TON_KHO"] = _TbSource.DefaultView[i].Row["TON_KHO"];
                    rDeXuatMuaHangChiTiet["TON_MIN"] = _TbSource.DefaultView[i].Row["TON_MIN"];
                    rDeXuatMuaHangChiTiet["TON_MAX"] = _TbSource.DefaultView[i].Row["TON_MAX"];
                    rDeXuatMuaHangChiTiet["DA_DAT_MUA"] = _TbSource.DefaultView[i].Row["SL_DA_DAT_HANG"];
                    rDeXuatMuaHangChiTiet["DA_DE_XUAT"] = _TbSource.DefaultView[i].Row["SL_DA_DE_XUAT"];
                    rDeXuatMuaHangChiTiet["SL_DE_XUAT"] = _TbSource.DefaultView[i].Row["SL_DE_XUAT"];
                    rDeXuatMuaHangChiTiet["SL_DA_DUYET"] = _TbSource.DefaultView[i].Row["SL_DA_DUYET"];
                    rDeXuatMuaHangChiTiet["DON_GIA"] = _TbSource.DefaultView[i].Row["DON_GIA"];
                    rDeXuatMuaHangChiTiet["NGOAI_TE"] = _TbSource.DefaultView[i].Row["NGOAI_TE"];
                    rDeXuatMuaHangChiTiet["TY_GIA"] = _TbSource.DefaultView[i].Row["TY_GIA"];
                    rDeXuatMuaHangChiTiet["TY_GIA_USD"] = _TbSource.DefaultView[i].Row["TY_GIA_USD"];
                    rDeXuatMuaHangChiTiet["THANH_TIEN"] = _TbSource.DefaultView[i].Row["THANH_TIEN"];
                    rDeXuatMuaHangChiTiet["THANH_TIEN_VND"] = _TbSource.DefaultView[i].Row["THANH_TIEN_VND"];
                    rDeXuatMuaHangChiTiet["THANH_TIEN_USD"] = _TbSource.DefaultView[i].Row["THANH_TIEN_USD"];
                    rDeXuatMuaHangChiTiet["GHI_CHU"] = _TbSource.DefaultView[i].Row["GHI_CHU"];
                    rDeXuatMuaHangChiTiet["NHAN_HIEU"] = _TbSource.DefaultView[i].Row["NHAN_HIEU"];
                    rDeXuatMuaHangChiTiet["HANG_SX"] = _TbSource.DefaultView[i].Row["HANG_SX"];
                    rDeXuatMuaHangChiTiet["CONG_DUNG"] = _TbSource.DefaultView[i].Row["CONG_DUNG"];
                    rDeXuatMuaHangChiTiet["HAN_SU_DUNG"] = _TbSource.DefaultView[i].Row["HAN_SU_DUNG"];
                    rDeXuatMuaHangChiTiet["NGAY_DE_XUAT_CUOI"] = _TbSource.DefaultView[i].Row["NGAY_CUOI"];
                    rDeXuatMuaHangChiTiet["NHA_CUNG_CAP_CUOI"] = _TbSource.DefaultView[i].Row["NHA_CUNG_CAP_CUOI"];
                    rDeXuatMuaHangChiTiet["DON_GIA_CUOI"] = _TbSource.DefaultView[i].Row["DON_GIA_CUOI"];
                    rDeXuatMuaHangChiTiet["NGOAI_TE_CUOI"] = _TbSource.DefaultView[i].Row["NGOAI_TE_CUOI"];
                    TbDeXuatMuaHangChiTiet.Rows.Add(rDeXuatMuaHangChiTiet);
                }
                System.Data.DataTable _TbSourceDichVu = new System.Data.DataTable();
                _TbSourceDichVu.Load(SqlPhuTung.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DICH_VU_DE_XUAT_COPY", frmChonDeXuat.MS_DE_XUAT));
                for (int j = 0; j < _TbSourceDichVu.DefaultView.Count; j++)
                {
                    DataRow rDeXuatMuaHangDichVu = TbDeXuatMuaHangDichVu.NewRow();
                    rDeXuatMuaHangDichVu["MS_DICH_VU"] = _TbSourceDichVu.DefaultView[j].Row["MS_DICH_VU"];
                    rDeXuatMuaHangDichVu["TEN_DICH_VU"] = _TbSourceDichVu.DefaultView[j].Row["TEN_DICH_VU"];
                    rDeXuatMuaHangDichVu["DVT"] = _TbSourceDichVu.DefaultView[j].Row["DVT"];
                    rDeXuatMuaHangDichVu["SL_DE_XUAT"] = _TbSourceDichVu.DefaultView[j].Row["SL_DE_XUAT"];
                    rDeXuatMuaHangDichVu["DON_GIA"] = _TbSourceDichVu.DefaultView[j].Row["DON_GIA"];
                    rDeXuatMuaHangDichVu["NGOAI_TE"] = _TbSourceDichVu.DefaultView[j].Row["NGOAI_TE"];
                    rDeXuatMuaHangDichVu["TY_GIA"] = _TbSourceDichVu.DefaultView[j].Row["TY_GIA"];
                    rDeXuatMuaHangDichVu["TY_GIA_USD"] = _TbSourceDichVu.DefaultView[j].Row["TY_GIA_USD"];
                    rDeXuatMuaHangDichVu["THANH_TIEN"] = _TbSourceDichVu.DefaultView[j].Row["THANH_TIEN"];
                    rDeXuatMuaHangDichVu["THANH_TIEN_VND"] = _TbSourceDichVu.DefaultView[j].Row["THANH_TIEN_VND"];
                    rDeXuatMuaHangDichVu["THANH_TIEN_USD"] = _TbSourceDichVu.DefaultView[j].Row["THANH_TIEN_USD"];
                    rDeXuatMuaHangDichVu["GHI_CHU"] = _TbSourceDichVu.DefaultView[j].Row["GHI_CHU"];
                    TbDeXuatMuaHangDichVu.Rows.Add(rDeXuatMuaHangDichVu);
                }
                BtnCopy.Visible = false;
            }
        }

        private void DgvDeXuatMuaHang_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmDanhsachDDHtuDexuat frm = new frmDanhsachDDHtuDexuat(TxtMS_DE_XUAT.Text);
            frm.ShowDialog(this);
        }

        private void BtnPrintImage_Click(object sender, EventArgs e)
        {
            try
            {

                Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                if (Commons.Modules.sPrivate.Trim().ToUpper() == "CS")
                {
                    frmReport frmRptDexuat = new frmReport();
                    frmRptDexuat.rptName = "rptDeXuatMuaHang_Image";
                    System.Data.DataTable TbDX = new System.Data.DataTable();
                    TbDX.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
                    TbDX.TableName = "rptDeXuatMuaHang";
                    frmRptDexuat.AddDataTableSource(TbDX);
                    System.Data.DataTable TbPT = new System.Data.DataTable();
                    TbPT.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_PT_RPT1", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
                    if (TbPT.Rows.Count <= 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKhongcodulieuin", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    TbPT.TableName = "rptDeXuatMuaHang_PT";
                    TbPT.Columns.Add("Image", typeof(Byte[]));
                    foreach (DataRow row in TbPT.Rows)
                    {
                        if (!row["ANH_PT"].ToString().Equals(""))
                        {
                            try
                            {
                                row["Image"] = GetByteFromFile(row["ANH_PT"].ToString());
                            }
                            catch
                            { }
                        }
                    }
                    frmRptDexuat.AddDataTableSource(TbPT);
                    System.Data.DataTable TbDV = new System.Data.DataTable();
                    TbDV.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_DV_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
                    TbDV.TableName = "rptDeXuatMuaHang_DV";
                    frmRptDexuat.AddDataTableSource(TbDV);
                    System.Data.DataTable TbDU = new System.Data.DataTable();
                    TbDU.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DXMH_DU_RPT", ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"], Commons.Modules.TypeLanguage));
                    TbDU.TableName = "rptDonDatHangDU";
                    frmRptDexuat.AddDataTableSource(TbDU);

                    System.Data.DataTable TbTieuDe = new System.Data.DataTable();
                    TbTieuDe.Columns.Add("TIEU_DE");
                    TbTieuDe.Columns.Add("DS_VTPT");
                    TbTieuDe.Columns.Add("DS_DICH_VU");
                    TbTieuDe.Columns.Add("MS_DE_XUAT");
                    TbTieuDe.Columns.Add("SO_DE_XUAT");
                    TbTieuDe.Columns.Add("BO_PHAN");
                    TbTieuDe.Columns.Add("NGUOI_LAP");
                    TbTieuDe.Columns.Add("NGAY_LAP");
                    TbTieuDe.Columns.Add("GHI_CHU_DX");
                    TbTieuDe.Columns.Add("NGUOI_KY_1");
                    TbTieuDe.Columns.Add("NGUOI_KY_2");
                    TbTieuDe.Columns.Add("NGUOI_KY_3");
                    TbTieuDe.Columns.Add("NGUOI_KY_4");
                    TbTieuDe.Columns.Add("NGUOI_KY_5");
                    TbTieuDe.Columns.Add("NGUOI_KY_6");
                    TbTieuDe.Columns.Add("STT");
                    TbTieuDe.Columns.Add("MS_PT");
                    TbTieuDe.Columns.Add("TEN_PT");
                    TbTieuDe.Columns.Add("QUY_CACH");
                    TbTieuDe.Columns.Add("DVT");
                    TbTieuDe.Columns.Add("TON_MIN");
                    TbTieuDe.Columns.Add("TON_MAX");
                    TbTieuDe.Columns.Add("TON_KHO");
                    TbTieuDe.Columns.Add("SO_LUONG");
                    TbTieuDe.Columns.Add("SL_CTU");
                    TbTieuDe.Columns.Add("SL_DE_XUAT");
                    TbTieuDe.Columns.Add("DON_GIA_VND");
                    TbTieuDe.Columns.Add("THANH_TIEN_VND");
                    TbTieuDe.Columns.Add("GHI_CHU");
                    TbTieuDe.Columns.Add("TEN_DICH_VU");
                    TbTieuDe.Columns.Add("DVT_DV");
                    TbTieuDe.Columns.Add("SO_LUONG_DV");
                    TbTieuDe.Columns.Add("DON_GIA_DV_VND");
                    TbTieuDe.Columns.Add("THANH_TIEN_DV_VND");
                    TbTieuDe.Columns.Add("GHI_CHU_DV");
                    TbTieuDe.Columns.Add("TONG_PT");
                    TbTieuDe.Columns.Add("TONG_DV");
                    TbTieuDe.Columns.Add("TIEN_TE");
                    TbTieuDe.Columns.Add("TMP1");
                    TbTieuDe.Columns.Add("TMP2");
                    TbTieuDe.Columns.Add("TMP3");
                    TbTieuDe.Columns.Add("TMP4");
                    TbTieuDe.Columns.Add("TMP5");
                    TbTieuDe.Columns.Add("TMP6");



                    System.Data.DataTable dtTmp = new System.Data.DataTable();
                    string sSql = "";
                    sSql = "SELECT KEYWORD , CASE " + Commons.Modules.TypeLanguage +
                                " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'rptDeXuatMuaHangNew' ";
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));



                    DataRow rTitle = TbTieuDe.NewRow();
                    rTitle["TIEU_DE"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TIEU_DE", "rptDeXuatMuaHangNew");
                    //Commons.Modules.ObjSystems.GetNN(dtTmp, "TIEU_DE", Commons.Modules.TypeLanguage);
                    rTitle["DS_VTPT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DS_VTPT", "rptDeXuatMuaHangNew");
                    rTitle["DS_DICH_VU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DS_DICH_VU", "rptDeXuatMuaHangNew");
                    rTitle["MS_DE_XUAT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "MS_DE_XUAT", "rptDeXuatMuaHangNew");
                    rTitle["SO_DE_XUAT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SO_DE_XUAT", "rptDeXuatMuaHangNew");
                    rTitle["BO_PHAN"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "BO_PHAN", "rptDeXuatMuaHangNew");
                    rTitle["NGUOI_LAP"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_LAP", "rptDeXuatMuaHangNew");
                    rTitle["NGAY_LAP"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGAY_LAP", "rptDeXuatMuaHangNew");
                    rTitle["GHI_CHU_DX"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "GHI_CHU_DX", "rptDeXuatMuaHangNew");
                    rTitle["NGUOI_KY_1"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_1", "rptDeXuatMuaHangNew");
                    rTitle["NGUOI_KY_2"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_2", "rptDeXuatMuaHangNew");
                    rTitle["NGUOI_KY_3"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_3", "rptDeXuatMuaHangNew");
                    rTitle["NGUOI_KY_4"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_4", "rptDeXuatMuaHangNew");
                    rTitle["NGUOI_KY_5"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_5", "rptDeXuatMuaHangNew");
                    rTitle["NGUOI_KY_6"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "NGUOI_KY_6", "rptDeXuatMuaHangNew");
                    rTitle["STT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "STT", "rptDeXuatMuaHangNew");
                    rTitle["MS_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "MS_PT", "rptDeXuatMuaHangNew");
                    rTitle["TEN_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TEN_PT", "rptDeXuatMuaHangNew");
                    rTitle["QUY_CACH"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "QUY_CACH", "rptDeXuatMuaHangNew");
                    rTitle["DVT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DVT", "rptDeXuatMuaHangNew");
                    rTitle["TON_MIN"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TON_MIN", "rptDeXuatMuaHangNew");
                    rTitle["TON_MAX"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TON_MAX", "rptDeXuatMuaHangNew");
                    rTitle["TON_KHO"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TON_KHO", "rptDeXuatMuaHangNew");
                    rTitle["SO_LUONG"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SO_LUONG", "rptDeXuatMuaHangNew");
                    rTitle["SL_CTU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SL_CTU", "rptDeXuatMuaHangNew");
                    rTitle["SL_DE_XUAT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SL_DE_XUAT", "rptDeXuatMuaHangNew");
                    rTitle["DON_GIA_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DON_GIA_VND", "rptDeXuatMuaHangNew");
                    rTitle["THANH_TIEN_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "THANH_TIEN_VND", "rptDeXuatMuaHangNew");
                    rTitle["GHI_CHU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "GHI_CHU", "rptDeXuatMuaHangNew");
                    rTitle["TEN_DICH_VU"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TEN_DICH_VU", "rptDeXuatMuaHangNew");
                    rTitle["DVT_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DVT_DV", "rptDeXuatMuaHangNew");
                    rTitle["SO_LUONG_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "SO_LUONG_DV", "rptDeXuatMuaHangNew");
                    rTitle["DON_GIA_DV_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "DON_GIA_DV_VND", "rptDeXuatMuaHangNew");
                    rTitle["THANH_TIEN_DV_VND"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "THANH_TIEN_DV_VND", "rptDeXuatMuaHangNew");
                    rTitle["GHI_CHU_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "GHI_CHU_DV", "rptDeXuatMuaHangNew");
                    rTitle["TONG_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TONG_PT", "rptDeXuatMuaHangNew");
                    rTitle["TONG_DV"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TONG_DV", "rptDeXuatMuaHangNew");
                    rTitle["TIEN_TE"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TIEN_TE", "rptDeXuatMuaHangNew");
                    rTitle["TMP1"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP1", "rptDeXuatMuaHangNew");
                    rTitle["TMP2"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP2", "rptDeXuatMuaHangNew");
                    rTitle["TMP3"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP3", "rptDeXuatMuaHangNew");
                    rTitle["TMP4"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP4", "rptDeXuatMuaHangNew");
                    rTitle["TMP5"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP5", "rptDeXuatMuaHangNew");
                    rTitle["TMP6"] = Commons.Modules.ObjSystems.GetNN(dtTmp, "TMP6", "rptDeXuatMuaHangNew");
                    TbTieuDe.TableName = "rptTieuDerptDeXuatMuaHangNew";
                    TbTieuDe.Rows.Add(rTitle);
                    frmRptDexuat.AddDataTableSource(TbTieuDe);
                    frmRptDexuat.ShowDialog(this);
                }
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKhongcodulieuin", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
        }

        private Byte[] GetByteFromFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes 
            //to read from file.
            //In this case we want to read entire file. 
            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;

        }
        //chỉ tính những vật tư có tồn tối thiểu > tồn hiện tại, số lượng đề xuất = tồn tối thiểu - tồn hiện tại
        private void btnAuto_Click(object sender, EventArgs e)
        {
            System.Data.DataTable _TbSource = new System.Data.DataTable();
            Vietsoft.SqlInfo SqlPhuTung = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            int kho = -1;
            string loai_vt = "-1";

            try
            {
                kho = Convert.ToInt32(cmbKho.SelectedValue.ToString());
                if (kho == 0 || kho == -1)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChuaChonKho", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbKho.Focus();
                    return;
                }
            }
            catch
            {

                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChuaChonKho", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbKho.Focus();
                return;
            }
            try
            {
                loai_vt = cmbLoaiVT.SelectedValue.ToString();
                if (loai_vt == "-1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChuaChonLoaiVT", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbLoaiVT.Focus();
                    return;
                }
            }
            catch
            {

                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChuaChonLoaiVT", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmbLoaiVT.Focus();
                return;
            }
            System.Data.DataTable _table = ((DataView)DgvDeXuatMuaHangChiTiet.DataSource).ToTable();
            _TbSource.Load(SqlPhuTung.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_GET_PHU_TUNG_DE_XUAT", kho, loai_vt));
            string _ms_pt = "";
            if (_TbSource.Rows.Count <= 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKhongCoDL", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
                cmbKho.Enabled = cmbLoaiVT.Enabled = false;
            for (int i = 0; i < _TbSource.DefaultView.Count; i++)
            {
                DataRow rDeXuatMuaHangChiTiet = TbDeXuatMuaHangChiTiet.NewRow();
                rDeXuatMuaHangChiTiet["MS_PT"] = _TbSource.DefaultView[i].Row["MS_PT"];
                _ms_pt = "MS_PT='" + _TbSource.DefaultView[i].Row["MS_PT"] + "'";
                System.Data.DataTable _new_table = new System.Data.DataTable();
                _new_table = _table;
                _new_table.DefaultView.RowFilter = _ms_pt;
                _new_table = _new_table.DefaultView.ToTable();
                if (_new_table.Rows.Count > 0)
                {
                    DialogResult res = DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgMSPTDuplicate", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (DialogResult.Yes.Equals(res))
                    {
                        rDeXuatMuaHangChiTiet["MS_PT"] = _TbSource.DefaultView[i].Row["MS_PT"];
                        rDeXuatMuaHangChiTiet["TEN_PT"] = _TbSource.DefaultView[i].Row["TEN_PT"];
                        rDeXuatMuaHangChiTiet["PART_NO"] = _TbSource.DefaultView[i].Row["PART_NO"];
                        rDeXuatMuaHangChiTiet["QUY_CACH"] = _TbSource.DefaultView[i].Row["QUY_CACH"];
                        rDeXuatMuaHangChiTiet["DVT"] = _TbSource.DefaultView[i].Row["DVT"];
                        rDeXuatMuaHangChiTiet["TON_KHO"] = _TbSource.DefaultView[i].Row["TON_KHO"];
                        rDeXuatMuaHangChiTiet["TON_MIN"] = _TbSource.DefaultView[i].Row["TON_MIN"];
                        rDeXuatMuaHangChiTiet["TON_MAX"] = _TbSource.DefaultView[i].Row["TON_MAX"];
                        rDeXuatMuaHangChiTiet["DA_DAT_MUA"] = _TbSource.DefaultView[i].Row["SL_DAT_HANG"];
                        rDeXuatMuaHangChiTiet["DA_DE_XUAT"] = _TbSource.DefaultView[i].Row["SL_DE_XUAT"];

                        //chỉ tính những vật tư có tồn tối thiểu > tồn hiện tại, số lượng đề xuất = tồn tối thiểu - tồn hiện tại
                        double SoLuong = (Convert.ToDouble(_TbSource.DefaultView[i].Row["TON_MIN"]) - (Convert.ToDouble(_TbSource.DefaultView[i].Row["TON_KHO"])));

                        if (SoLuong > 0)
                        {
                            rDeXuatMuaHangChiTiet["SL_DE_XUAT"] = SoLuong;
                        }
                        else
                        {
                            rDeXuatMuaHangChiTiet["SL_DE_XUAT"] = 1;
                        }
                        rDeXuatMuaHangChiTiet["SL_DA_DUYET"] = rDeXuatMuaHangChiTiet["SL_DE_XUAT"];
                        rDeXuatMuaHangChiTiet["NGAY_DE_XUAT_CUOI"] = _TbSource.DefaultView[i].Row["NGAY_CUOI"];
                        rDeXuatMuaHangChiTiet["NHA_CUNG_CAP_CUOI"] = _TbSource.DefaultView[i].Row["NHA_CUNG_CAP_CUOI"];
                        rDeXuatMuaHangChiTiet["DON_GIA"] = _TbSource.DefaultView[i].Row["DON_GIA_CUOI"];
                        rDeXuatMuaHangChiTiet["THUE_VAT"] = 0;
                        try
                        {
                            Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                            System.Data.DataTable TbNgoaiTe = new System.Data.DataTable();
                            TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", _TbSource.DefaultView[i].Row["NGOAI_TE_CUOI"]));
                            if (TbNgoaiTe.Rows.Count > 0)
                            {
                                double vnd = Convert.ToDouble(TbNgoaiTe.Rows[0]["TI_GIA"].ToString());
                                rDeXuatMuaHangChiTiet["TY_GIA"] = vnd.ToString("###,##0.00");
                                double usd = Convert.ToDouble(TbNgoaiTe.Rows[0]["TI_GIA_USD"].ToString());
                                rDeXuatMuaHangChiTiet["TY_GIA_USD"] = usd;
                                double thanhtien = (Convert.ToInt32(rDeXuatMuaHangChiTiet["SL_DE_XUAT"]) * Convert.ToDouble(_TbSource.DefaultView[i].Row["DON_GIA_CUOI"]));
                                rDeXuatMuaHangChiTiet["THANH_TIEN"] = thanhtien;
                                rDeXuatMuaHangChiTiet["THANH_TIEN_VND"] = vnd * thanhtien;
                                rDeXuatMuaHangChiTiet["THANH_TIEN_USD"] = usd * thanhtien;
                            }
                        }
                        catch
                        {
                        }
                        TbDeXuatMuaHangChiTiet.Rows.Add(rDeXuatMuaHangChiTiet);
                    }
                }
                else
                {

                    rDeXuatMuaHangChiTiet["MS_PT"] = _TbSource.DefaultView[i].Row["MS_PT"];
                    rDeXuatMuaHangChiTiet["TEN_PT"] = _TbSource.DefaultView[i].Row["TEN_PT"];
                    rDeXuatMuaHangChiTiet["PART_NO"] = _TbSource.DefaultView[i].Row["PART_NO"];
                    rDeXuatMuaHangChiTiet["QUY_CACH"] = _TbSource.DefaultView[i].Row["QUY_CACH"];
                    rDeXuatMuaHangChiTiet["DVT"] = _TbSource.DefaultView[i].Row["DVT"];
                    rDeXuatMuaHangChiTiet["TON_KHO"] = _TbSource.DefaultView[i].Row["TON_KHO"];
                    rDeXuatMuaHangChiTiet["TON_MIN"] = _TbSource.DefaultView[i].Row["TON_MIN"];
                    rDeXuatMuaHangChiTiet["TON_MAX"] = _TbSource.DefaultView[i].Row["TON_MAX"];
                    rDeXuatMuaHangChiTiet["DA_DAT_MUA"] = _TbSource.DefaultView[i].Row["SL_DAT_HANG"];
                    rDeXuatMuaHangChiTiet["DA_DE_XUAT"] = _TbSource.DefaultView[i].Row["SL_DE_XUAT"];
                    //rDeXuatMuaHangChiTiet["GHI_CHU"] = frmPhuTung.DataSource.DefaultView[i].Row["GHI_CHU"];
                    double SoLuong = (Convert.ToDouble(_TbSource.DefaultView[i].Row["TON_MIN"]) - (Convert.ToDouble(_TbSource.DefaultView[i].Row["TON_KHO"])));
                    if (SoLuong > 0)
                    {
                        rDeXuatMuaHangChiTiet["SL_DE_XUAT"] = SoLuong;
                    }
                    else
                    {
                        rDeXuatMuaHangChiTiet["SL_DE_XUAT"] = 1;
                    }
                    rDeXuatMuaHangChiTiet["SL_DA_DUYET"] = rDeXuatMuaHangChiTiet["SL_DE_XUAT"];
                    rDeXuatMuaHangChiTiet["NGAY_DE_XUAT_CUOI"] = _TbSource.DefaultView[i].Row["NGAY_CUOI"];
                    rDeXuatMuaHangChiTiet["NHA_CUNG_CAP_CUOI"] = _TbSource.DefaultView[i].Row["NHA_CUNG_CAP_CUOI"];
                    rDeXuatMuaHangChiTiet["DON_GIA"] = _TbSource.DefaultView[i].Row["DON_GIA_CUOI"];
                    rDeXuatMuaHangChiTiet["THUE_VAT"] = 0;
                    ////////
                    Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                    System.Data.DataTable TbNgoaiTe = new System.Data.DataTable();
                    TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", _TbSource.DefaultView[i].Row["NGOAI_TE_CUOI"]));
                    if (TbNgoaiTe.Rows.Count > 0)
                    {
                        double vnd = Convert.ToDouble(TbNgoaiTe.Rows[0]["TI_GIA"].ToString());
                        rDeXuatMuaHangChiTiet["TY_GIA"] = vnd.ToString("###,##0.00");
                        double usd = Convert.ToDouble(TbNgoaiTe.Rows[0]["TI_GIA_USD"].ToString());
                        rDeXuatMuaHangChiTiet["TY_GIA_USD"] = usd;
                        double thanhtien = (Convert.ToInt32(rDeXuatMuaHangChiTiet["SL_DE_XUAT"]) * Convert.ToDouble(_TbSource.DefaultView[i].Row["DON_GIA_CUOI"]));
                        rDeXuatMuaHangChiTiet["THANH_TIEN"] = thanhtien;
                        rDeXuatMuaHangChiTiet["THANH_TIEN_VND"] = vnd * thanhtien;
                        rDeXuatMuaHangChiTiet["THANH_TIEN_USD"] = usd * thanhtien;
                    }

                    /////////
                    rDeXuatMuaHangChiTiet["DON_GIA_CUOI"] = _TbSource.DefaultView[i].Row["DON_GIA_CUOI"];
                    rDeXuatMuaHangChiTiet["NGOAI_TE"] = _TbSource.DefaultView[i].Row["NGOAI_TE_CUOI"];
                    rDeXuatMuaHangChiTiet["NGOAI_TE_CUOI"] = _TbSource.DefaultView[i].Row["NGOAI_TE_CUOI"];
                    TbDeXuatMuaHangChiTiet.Rows.Add(rDeXuatMuaHangChiTiet);
                }
            }
        }

        private void chkIsLock_CheckedChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 57))
                if (chkIsLock.Checked) btnUnLock.Visible = true; else btnUnLock.Visible = false;
            else btnUnLock.Visible = false;


            LoadDXMH();


        }


        private void lokPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                LoadDXMH();
            }
            catch { }
        }

        private void datFromDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                if (isFirst)
                {
                    if (datFromDate.DateTime > datToDate.DateTime)
                    {
                        // Vietsoft.Information.MsgBox(this, "MsgToDateLonFromDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //datFromDate.Focus();
                    }
                    else
                        LoadDXMH();
                }
            }
            catch { }
        }

        private void datFromDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue > datToDate.DateTime)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        e.Cancel = true;
                    }
                }
            }
            catch { }
        }

        private void datToDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                if (isFirst)
                {
                    if ((DateTime)e.NewValue < datFromDate.DateTime)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        e.Cancel = true;
                    }

                }
            }
            catch { }
        }

        private double iKiemGT(string sGiaTriKiem)
        {
            if (string.IsNullOrEmpty(sGiaTriKiem))
                return 0;
            else
                return Convert.ToDouble(sGiaTriKiem);

        }

        private void datToDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                if (isFirst)
                {
                    if (datFromDate.DateTime > datToDate.DateTime)
                    {
                        // Vietsoft.Information.MsgBox(this, "MsgToDateLonFromDate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //datToDate.Focus();
                    }
                    else
                        LoadDXMH();
                }
            }
            catch { }
        }


        #region InAceCook
        private void InAceCook()
        {
            this.Cursor = Cursors.WaitCursor;
            frmReport frmRptDexuat = new frmReport();
            string sMsDX = "";
            sMsDX = ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"].ToString();
            //sMsDX = "DX-1111-0002";

            frmRptDexuat.rptName = "rptDeXuatMuaHangACE";
            System.Data.DataTable dtTmp = new System.Data.DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetDXMACE", sMsDX, Commons.Modules.TypeLanguage));
            dtTmp.TableName = "DE_XUAT_ACE";
            frmRptDexuat.AddDataTableSource(dtTmp);

            System.Data.DataTable TbTieuDe = new System.Data.DataTable();
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("NGAY");
            TbTieuDe.Columns.Add("HO_TEN");
            TbTieuDe.Columns.Add("PHONG_BAN1");
            TbTieuDe.Columns.Add("NGAY_DX");
            TbTieuDe.Columns.Add("TEN_KHO");
            TbTieuDe.Columns.Add("LY_DO_MUA_HANG");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("QUY_CACH");
            TbTieuDe.Columns.Add("HSX");
            TbTieuDe.Columns.Add("DVT");
            TbTieuDe.Columns.Add("SO_LUONG");
            TbTieuDe.Columns.Add("TON_KHO");
            TbTieuDe.Columns.Add("GHI_CHU");
            TbTieuDe.Columns.Add("TONG_CONG");
            TbTieuDe.Columns.Add("DUYET");
            TbTieuDe.Columns.Add("TRUONG_PB");
            TbTieuDe.Columns.Add("THU_KHO");
            TbTieuDe.Columns.Add("NGUOI_DE_NGHI");
            TbTieuDe.Columns.Add("LAN_BAN_HANH");
            TbTieuDe.Columns.Add("NHP002_F1");
            TbTieuDe.Columns.Add("DU1");
            TbTieuDe.Columns.Add("DU2");
            TbTieuDe.Columns.Add("DU3");

            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "TIEU_DE", Commons.Modules.TypeLanguage);
            rTitle["NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "NGAY", Commons.Modules.TypeLanguage);
            rTitle["HO_TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "HO_TEN",
                    Commons.Modules.TypeLanguage) + " : " + TxtNGUOI_DE_XUAT.Text;
            rTitle["PHONG_BAN1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "PHONG_BAN1",
                    Commons.Modules.TypeLanguage) + " : " + CboPHONG_BAN.Text;
            rTitle["NGAY_DX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "NGAY_DX",
                    Commons.Modules.TypeLanguage) + " : " + MskNGAY_DE_XUAT.Text;
            rTitle["TEN_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "TEN_KHO",
                    Commons.Modules.TypeLanguage) + " : " + cmbKho.Text;
            rTitle["LY_DO_MUA_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "LY_DO_MUA_HANG",
                    Commons.Modules.TypeLanguage) + " : " + TxtGHI_CHU.Text;
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "STT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "TEN_PT", Commons.Modules.TypeLanguage);
            rTitle["QUY_CACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "QUY_CACH", Commons.Modules.TypeLanguage);
            rTitle["HSX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "HSX", Commons.Modules.TypeLanguage);
            rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "DVT", Commons.Modules.TypeLanguage);
            rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "SO_LUONG", Commons.Modules.TypeLanguage);
            rTitle["TON_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "TON_KHO", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "GHI_CHU", Commons.Modules.TypeLanguage);
            rTitle["TONG_CONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "TONG_CONG", Commons.Modules.TypeLanguage);
            rTitle["DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "DUYET", Commons.Modules.TypeLanguage);
            rTitle["TRUONG_PB"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "TRUONG_PB", Commons.Modules.TypeLanguage);
            rTitle["THU_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "THU_KHO", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_DE_NGHI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "NGUOI_DE_NGHI", Commons.Modules.TypeLanguage);
            rTitle["LAN_BAN_HANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "LAN_BAN_HANH", Commons.Modules.TypeLanguage);
            rTitle["NHP002_F1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "NHP002_F1", Commons.Modules.TypeLanguage);
            rTitle["DU1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "Trang", Commons.Modules.TypeLanguage);
            rTitle["DU2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "DU2", Commons.Modules.TypeLanguage);
            rTitle["DU3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangACE", "DU3", Commons.Modules.TypeLanguage);

            TbTieuDe.TableName = "TIEU_DE_DXACE";
            TbTieuDe.Rows.Add(rTitle);
            frmRptDexuat.AddDataTableSource(TbTieuDe);
            this.Cursor = Cursors.Default;
            frmRptDexuat.ShowDialog(this);

        }
        #endregion

        #region InGreenFeed
        private void InGreenFeed()
        {

            frmReport frmRptDexuat = new frmReport();
            string sMsDX = "";
            string sBCao = "rptDeXuatMuaHangGRE";
            sMsDX = ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"].ToString();


            frmRptDexuat.rptName = sBCao;
            System.Data.DataTable dtTmp = new System.Data.DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDXMGre", sMsDX, Commons.Modules.TypeLanguage));

            System.Data.DataColumn col = new System.Data.DataColumn("CHON", typeof(System.Boolean));
            col.DefaultValue = "0";
            dtTmp.Columns.Add(col);

            col.DefaultValue = false;
            col.SetOrdinal(0);
            frmChonInDeXuat frm = new frmChonInDeXuat();
            frm.dtDeXuat = dtTmp;
            if (frm.ShowDialog() == DialogResult.Cancel) return;

            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, this.Name, "MsgChuaChonVatTuIn", Commons.Modules.TypeLanguage));

                return;
            }
            this.Cursor = Cursors.WaitCursor;


            dtTmp.TableName = "DE_XUAT_GRE";
            frmRptDexuat.AddDataTableSource(dtTmp);

            System.Data.DataTable TbTieuDe = new System.Data.DataTable();
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("NGAY");
            TbTieuDe.Columns.Add("HO_TEN");
            TbTieuDe.Columns.Add("PHONG_BAN1");
            TbTieuDe.Columns.Add("NGAY_DX");
            TbTieuDe.Columns.Add("TEN_KHO");
            TbTieuDe.Columns.Add("LY_DO_MUA_HANG");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("QUY_CACH");
            TbTieuDe.Columns.Add("HSX");
            TbTieuDe.Columns.Add("DVT");
            TbTieuDe.Columns.Add("SO_LUONG");
            TbTieuDe.Columns.Add("SL_DX");
            TbTieuDe.Columns.Add("TON_KHO");
            TbTieuDe.Columns.Add("TON_MIN");
            TbTieuDe.Columns.Add("TON_MAX");
            TbTieuDe.Columns.Add("GIA_CUOI");
            TbTieuDe.Columns.Add("TG_GH");
            TbTieuDe.Columns.Add("GHI_CHU");
            TbTieuDe.Columns.Add("TONG_CONG");
            TbTieuDe.Columns.Add("DUYET");
            TbTieuDe.Columns.Add("TRUONG_PB");
            TbTieuDe.Columns.Add("THU_KHO");
            TbTieuDe.Columns.Add("NGUOI_DE_NGHI");
            TbTieuDe.Columns.Add("LAN_BAN_HANH");
            TbTieuDe.Columns.Add("NHP002_F1");
            TbTieuDe.Columns.Add("SO_DE_XUAT");
            TbTieuDe.Columns.Add("DU1");
            TbTieuDe.Columns.Add("DU2");
            TbTieuDe.Columns.Add("DU3");
            TbTieuDe.Columns.Add("DU4");
            TbTieuDe.Columns.Add("DU5");
            TbTieuDe.Columns.Add("DU6");

            System.Data.DataTable dtTmp1 = new System.Data.DataTable();
            string sSql = "";
            sSql = "SELECT KEYWORD , CASE " + Commons.Modules.TypeLanguage +
                        " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + sBCao + "' ";
            dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));


            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["TIEU_DE"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "TIEU_DE", sBCao);
            rTitle["NGAY"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "NGAY", sBCao) + MskNGAY_LAP.Text.ToString();
            rTitle["HO_TEN"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "HO_TEN", sBCao) + " : " + TxtNGUOI_DE_XUAT.Text;
            rTitle["PHONG_BAN1"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "PHONG_BAN1", sBCao) + " : " + CboPHONG_BAN.Text;
            rTitle["NGAY_DX"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "NGAY_DX", sBCao) + " : " + MskNGAY_DE_XUAT.Text;
            rTitle["TEN_KHO"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "TEN_KHO", sBCao) + " : " + cmbKho.Text;
            rTitle["LY_DO_MUA_HANG"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "LY_DO_MUA_HANG", sBCao) + " : " + TxtGHI_CHU.Text;
            rTitle["STT"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "STT", sBCao);
            rTitle["MS_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "MS_PT", sBCao);
            rTitle["TEN_PT"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "TEN_PT", sBCao);
            rTitle["QUY_CACH"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "QUY_CACH", sBCao);
            rTitle["HSX"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "HSX", sBCao);
            rTitle["DVT"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "DVT", sBCao);
            rTitle["SO_LUONG"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "SO_LUONG", sBCao);
            rTitle["TON_KHO"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "TON_KHO", sBCao);
            rTitle["GHI_CHU"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "GHI_CHU", sBCao);
            rTitle["TONG_CONG"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "TONG_CONG", sBCao);

            rTitle["DUYET"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "DUYET", sBCao);
            rTitle["TRUONG_PB"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "TRUONG_PB", sBCao);
            rTitle["THU_KHO"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "THU_KHO", sBCao);
            rTitle["NGUOI_DE_NGHI"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "NGUOI_LAP", sBCao);

            rTitle["LAN_BAN_HANH"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "LAN_BAN_HANH", sBCao);
            rTitle["SL_DX"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "SL_DX", sBCao);
            rTitle["DU1"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "Trang", sBCao);
            rTitle["SO_DE_XUAT"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "SO_DE_XUAT", sBCao) + " : " + TxtMS_DE_XUAT.Text;

            rTitle["TON_MIN"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "TON_MIN", sBCao);
            rTitle["TON_MAX"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "TON_MAX", sBCao);
            rTitle["GIA_CUOI"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "GIA_CUOI", sBCao);
            rTitle["TG_GH"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "TG_GH", sBCao);
            rTitle["DU2"] = Commons.Modules.ObjSystems.GetNN(dtTmp1, "UserIn", sBCao) + " : " + Commons.Modules.UserName.ToString();
            rTitle["DU3"] = TxtNGUOI_DE_XUAT.Text;


            DateTime NgayIn = Commons.Modules.ObjSystems.GetNgayHeThong();

            rTitle["DU4"] = Commons.Modules.ObjSystems.GetNN(dtTmp1,
                "NgayHT", sBCao) + " : " + NgayIn.Date.ToString("dd/MM/yyyy");

            TbTieuDe.TableName = "TIEU_DE_DXGRE";
            TbTieuDe.Rows.Add(rTitle);
            frmRptDexuat.AddDataTableSource(TbTieuDe);
            this.Cursor = Cursors.Default;
            frmRptDexuat.ShowDialog(this);

        }
        #endregion

        #region InSHISEIDO
        private void InSHISEIDO()
        {


            this.Cursor = Cursors.WaitCursor;
            frmReport frmRptDexuat = new frmReport();
            string sMsDX = "";
            sMsDX = ((DataRowView)BindingDeXuatMuaHang.Current).Row["MS_DE_XUAT"].ToString();
            try
            {
                frmRptDexuat.rptName = "rptDeXuatMuaHangSSD";

                System.Data.DataTable dtTmp = new System.Data.DataTable();
                DataSet dtSet = new DataSet();
                dtSet = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetBCDeXuatVatTuSSD",
                     sMsDX, Commons.Modules.TypeLanguage);


                dtTmp = new System.Data.DataTable();
                dtTmp = dtSet.Tables[0];
                dtTmp.TableName = "DE_XUAT_SSD";
                frmRptDexuat.AddDataTableSource(dtTmp);


                dtTmp = new System.Data.DataTable();
                dtTmp = dtSet.Tables[1];
                dtTmp.TableName = "DE_XUAT_SSD_CT";
                frmRptDexuat.AddDataTableSource(dtTmp);
            }
            catch (Exception EX)
            { }
            System.Data.DataTable TbTieuDe = new System.Data.DataTable();
            TbTieuDe.Columns.Add("TIEU_DE");
            TbTieuDe.Columns.Add("MS_DE_XUAT");
            TbTieuDe.Columns.Add("NGAY_DX");
            TbTieuDe.Columns.Add("NGUOI_DX");
            TbTieuDe.Columns.Add("PHONG_BAN");
            TbTieuDe.Columns.Add("NGAY_CAN_HANG");
            TbTieuDe.Columns.Add("NGUOI_THEO_DOI");
            TbTieuDe.Columns.Add("LY_DO_DX");

            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("PART_NO");

            TbTieuDe.Columns.Add("DVT");
            TbTieuDe.Columns.Add("SO_LUONG");
            TbTieuDe.Columns.Add("TON_KHO");
            TbTieuDe.Columns.Add("GHI_CHU");

            TbTieuDe.Columns.Add("PHU_TRACH_KHO");
            TbTieuDe.Columns.Add("NGUOI_DUYET");
            TbTieuDe.Columns.Add("KY_HO_TEN");
            TbTieuDe.Columns.Add("TMP1");
            TbTieuDe.Columns.Add("TMP2");
            TbTieuDe.Columns.Add("TMP3");
            TbTieuDe.Columns.Add("TMP4");
            TbTieuDe.Columns.Add("TMP5");

            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "TD_DX_SSD", Commons.Modules.TypeLanguage);
            rTitle["MS_DE_XUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "MS_DE_XUAT", Commons.Modules.TypeLanguage) + " : ";
            rTitle["NGAY_DX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "NGAY_DX", Commons.Modules.TypeLanguage) + " : ";
            rTitle["NGUOI_DX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "NGUOI_DX", Commons.Modules.TypeLanguage) + " : ";
            rTitle["PHONG_BAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "PHONG_BAN", Commons.Modules.TypeLanguage) + " : ";
            rTitle["NGAY_CAN_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "NGAY_CAN_HANG", Commons.Modules.TypeLanguage) + " : ";
            rTitle["NGUOI_THEO_DOI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "NGUOI_THEO_DOI", Commons.Modules.TypeLanguage) + " : ";
            rTitle["LY_DO_DX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "LY_DO_DX", Commons.Modules.TypeLanguage) + " : ";
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "STT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "TEN_PT", Commons.Modules.TypeLanguage);
            rTitle["PART_NO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "PART_NO", Commons.Modules.TypeLanguage);
            rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "DVT", Commons.Modules.TypeLanguage);
            rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "SO_LUONG", Commons.Modules.TypeLanguage);
            rTitle["TON_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "TON_KHO", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "GHI_CHU", Commons.Modules.TypeLanguage);
            rTitle["PHU_TRACH_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "PHU_TRACH_KHO", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "NGUOI_DUYET", Commons.Modules.TypeLanguage);
            rTitle["KY_HO_TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "KY_HO_TEN", Commons.Modules.TypeLanguage);
            rTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "TMP1", Commons.Modules.TypeLanguage);
            rTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "TMP2", Commons.Modules.TypeLanguage);
            rTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "TMP3", Commons.Modules.TypeLanguage);
            rTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "TMP4", Commons.Modules.TypeLanguage);
            rTitle["TMP5"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHangSSD", "TMP5", Commons.Modules.TypeLanguage);


            TbTieuDe.TableName = "TIEU_DE_DX_SSD";
            TbTieuDe.Rows.Add(rTitle);
            frmRptDexuat.AddDataTableSource(TbTieuDe);
            this.Cursor = Cursors.Default;
            frmRptDexuat.ShowDialog(this);

        }


        #endregion

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            if (TxtMS_DE_XUAT.Text == "") return;
            try
            {
                string sSql = "SELECT SUM(CONVERT(INT,ISNULL(DUYET,0))) SL FROM DE_XUAT_MUA_HANG_DUYET WHERE QUYET_DINH = 1 AND MS_DE_XUAT = N'" + TxtMS_DE_XUAT.Text + "' ";
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (Convert.ToInt16(sSql) == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                        Commons.Modules.ModuleName, this.Name, "msgDeXuatChuaDuyetKhongTheBoLock", Commons.Modules.TypeLanguage));
                    return;
                }

                sSql = " UPDATE DE_XUAT_MUA_HANG SET TRANG_THAI = 3 WHERE TRANG_THAI = 4 AND  MS_DE_XUAT = N'" + TxtMS_DE_XUAT.Text + "' ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                LoadDXMH();
            }
            catch { }
        }

        private void btnDeNghi_Click(object sender, EventArgs e)
        {
            //            if (Commons.Modules.sPrivate.Trim().ToUpper() == "DOFICO") sTT2TrinhDuyet = "Duyệt đề nghị";
            Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            try
            {
                SqlDeXuatMuaHang.BeginTransaction();
                ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["TRANG_THAI"] = 2;
                ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["TEN_TRANG_THAI"] = "Duyệt đề nghị";
                Vietsoft.DataInfo.UpdateDataRow(SqlDeXuatMuaHang, "SP_Y_EDIT_DE_XUAT_MUA_HANG", ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row);
                if (Commons.Modules.iTRFData == 1)
                {
                    if (!TRFDeXuat(SqlDeXuatMuaHang, TxtMS_DE_XUAT.Text, 2))
                    {
                        SqlDeXuatMuaHang.RollbackTransaction();
                        BindingDeXuatMuaHang.CancelEdit();
                        InitializeControl();
                        return;
                    }
                }
                SqlDeXuatMuaHang.CommitTransaction();
                BindingDeXuatMuaHang.EndEdit();
            }
            catch
            {
                SqlDeXuatMuaHang.RollbackTransaction();
                BindingDeXuatMuaHang.CancelEdit();
            }
            InitializeControl();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocData();
        }
        private void LocData()
        {
            try
            {
                string dk = "";
                if (txtTimKiem.Text.Length != 0) dk = dk + " OR MS_DE_XUAT LIKE '%" + txtTimKiem.Text + "%' ";
                if (txtTimKiem.Text.Length != 0) dk = dk + " OR SO_DE_XUAT LIKE '%" + txtTimKiem.Text + "%' ";
                TbDeXuatMuaHang.DefaultView.RowFilter = dk.Substring(4, dk.Length - 4);
            }
            catch { TbDeXuatMuaHang.DefaultView.RowFilter = ""; }
        }

        private void btnTimCX_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.ToString().Trim() == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "msgVuiLongNhapGiaTriCanTim", Commons.Modules.TypeLanguage));
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            System.DateTime dNgay = DateTime.Parse("01/01/1900");
            int iLock = 0;
            try
            {
                Commons.Modules.ObjSystems.mGetSoPhieu("DE_XUAT_MUA_HANG", "MS_DE_XUAT", "NGAY_LAP", "CONVERT(INT, CASE TRANG_THAI WHEN 4 THEN 1 ELSE 0 END)", txtTimKiem.Text, ref dNgay, ref iLock);
                if (dNgay.Date != DateTime.Parse("01/01/1900"))
                {
                    isFirst = false;
                    Commons.Modules.SQLString = "0Load";
                    if (iLock == 1) chkIsLock.Checked = true; else chkIsLock.Checked = false;
                    cboTinhTrang.EditValue = -1;
                    lokPhongBan.EditValue = -1;
                    datFromDate.DateTime = dNgay;
                    datToDate.DateTime = dNgay;
                    Commons.Modules.SQLString = "";
                    isFirst = true;
                    LoadDXMH();
                    LocData();
                }
            }
            catch (Exception ex)
            {
                txtTimKiem_TextChanged(sender, e);
            }
            this.Cursor = Cursors.Default;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (txtTimKiem.Text.Trim() == "")
            {
                TbDeXuatMuaHang.DefaultView.RowFilter = "";
                return;
            }
            string dk = " MS_DE_XUAT = '" + txtTimKiem.Text + "' ";
            try
            {
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                dtTmp = TbDeXuatMuaHang.Copy();

                dtTmp.DefaultView.RowFilter = dk;
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count == 0)
                {
                    string sSql = "";
                    sSql = " SELECT  MS_DE_XUAT, TRANG_THAI,MS_TO,NGAY_LAP FROM DE_XUAT_MUA_HANG WHERE MS_DE_XUAT = '" + txtTimKiem.Text + "' ";
                    dtTmp = new System.Data.DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        Commons.Modules.SQLString = "0Load";

                        if (int.Parse(cboTinhTrang.EditValue.ToString()) != -1)
                        {
                            cboTinhTrang.EditValue = int.Parse(dtTmp.Rows[0]["TRANG_THAI"].ToString());
                        }
                        if (int.Parse(lokPhongBan.EditValue.ToString()) != -1)
                        {
                            lokPhongBan.EditValue = int.Parse(dtTmp.Rows[0]["MS_TO"].ToString());
                        }
                        if (int.Parse(dtTmp.Rows[0]["TRANG_THAI"].ToString()) == 4)
                        {
                            chkIsLock.Checked = true;
                        }
                        else
                        {
                            chkIsLock.Checked = false;
                        }
                        datToDate.DateTime = DateTime.Parse(dtTmp.Rows[0]["NGAY_LAP"].ToString());
                        datFromDate.DateTime = DateTime.Parse(dtTmp.Rows[0]["NGAY_LAP"].ToString());
                        Commons.Modules.SQLString = "";
                        LoadDXMH();
                    }
                }
            }
            catch { TbDeXuatMuaHang.DefaultView.RowFilter = ""; }
            try
            {
                TbDeXuatMuaHang.DefaultView.RowFilter = dk;
            }
            catch { TbDeXuatMuaHang.DefaultView.RowFilter = ""; }
        }


        #region InDeNghiMuaHangVinhHoan
        //iloai = 0 in binh thuong
        //iloai = 1 goi mail luc trinh duyet
        //iloai = 2 goi mail duyet
        private void InDeNghiMuaHangVinhHoan(int iLoai)
        {
            Cursor = Cursors.WaitCursor;
            string sFile = "";
            sFile = "DeXuatMuaHang-" + TxtMS_DE_XUAT.Text;
            try
            {
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                frmReport frmRpt = new frmReport();
                Vietsoft.MLoadReport MExport = new Vietsoft.MLoadReport();

                //VSMail.MClass.MLoadReport Mload = new VSMail.MClass.MLoadReport();
                //TbTSGSTT.TableName = "TINH_TRANG_THIET_BI";
                //vtbLg = LoadNNPGSTTDHKT(NNgu, TNgay, DNgay);
                //vtbLg.TableName = "TIEU_DE_TINH_TRANG_THIET_BI";

                frmRpt.rptName = "rptDeNghiMuaHang_VH";
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
                connection.Open();

                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandText = "spDXMH_VH";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MS_DE_XUAT", TxtMS_DE_XUAT.Text));


                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                DataSet dsTmp = new DataSet();

                try
                {
                    adapter.Fill(dsTmp);
                }
                catch { }
                Int32 i = 0;
                for (i = 0; i <= dsTmp.Tables.Count - 1; i++)
                {
                    dtTmp = new System.Data.DataTable();
                    dtTmp = dsTmp.Tables[i];
                    switch (i)
                    {
                        case 0:
                            dtTmp.TableName = "DNMH_INFO";
                            break;
                        case 1:
                            dtTmp.TableName = "DNMH_DETAIL";
                            break;
                        case 2:
                            dtTmp.TableName = "DNMH_DV";
                            break;
                    }
                    if (iLoai == 0) frmRpt.AddDataTableSource(dtTmp); else MExport.AddDataTableSource(dtTmp);
                }
                dtTmp = new System.Data.DataTable();
                dtTmp = LanguageReportVINHHOAN();

                if (iLoai == 0) frmRpt.AddDataTableSource(dtTmp); else MExport.AddDataTableSource(dtTmp);


                switch (iLoai)
                {
                    case 1:
                    case 2:
                        try
                        {
                            if (!MExport.AutoExporttoPDF(System.Windows.Forms.Application.StartupPath + "\\reports\\", frmRpt.rptName,
                                            sFile, System.Windows.Forms.Application.StartupPath, 0))
                            {
                                Cursor = Cursors.Default;
                                return;
                            }

                            string sMail = "";
                            string sSql = "";
                            Boolean BuocCuoi = false;
                            if (iLoai == 1)
                            {
                                sSql = "SELECT TOP 1 ISNULL(USER_MAIL,'') AS USER_MAIL FROM DE_XUAT_MUA_HANG_DUYET A INNER JOIN USERS B ON A.NGUOI_DUYET = B.USERNAME " +
                                        " WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "' ORDER BY TT_DUYET ASC";
                                sMail = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)).Trim();
                            }
                            else
                            {
                                sSql = " SELECT TOP 1 ISNULL(USER_MAIL,'') AS USER_MAIL FROM DE_XUAT_MUA_HANG_DUYET A INNER JOIN " +
                                        " 	USERS B ON A.NGUOI_DUYET = B.USERNAME WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "'  " +
                                        " 	AND TT_DUYET > (SELECT TT_DUYET FROM DE_XUAT_MUA_HANG_DUYET WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "' AND NGUOI_DUYET = '" + Commons.Modules.UserName + "')  " +
                                        " ORDER BY TT_DUYET";
                                dtTmp = new System.Data.DataTable();
                                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                                if (dtTmp.Rows.Count > 0)
                                    sMail = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)).Trim();
                                else
                                {
                                    //Buoc cuoi thi goi cho nguoi TN lun
                                    sSql = " SELECT TOP 1 B.USER_MAIL FROM DE_XUAT_MUA_HANG A INNER JOIN CONG_NHAN B ON A.NGUOI_TN = B.MS_CONG_NHAN WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "'";
                                    sMail = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)).Trim();
                                    //sMail = (sMail == "" ? "" : sMail + ";") + "mashinhat@gmail.com;hiennv@vietsoft.com.vn";
                                    sMail = Commons.Modules.ObjSystems.MBoMailTrung(sMail);
                                    if (sMail.Equals(""))
                                    {
                                        Cursor = Cursors.Default;
                                        Commons.Modules.ObjSystems.Xoahinh(System.Windows.Forms.Application.StartupPath + "\\" + sFile + ".pdf");
                                        return;
                                    }
                                    else
                                    {// GOI MAIL CUOC CUOI =- 3
                                        GoiMail(System.Windows.Forms.Application.StartupPath + "\\" + sFile + ".pdf", sMail, 3);
                                        BuocCuoi = true;
                                        Cursor = Cursors.Default;
                                        Commons.Modules.ObjSystems.Xoahinh(System.Windows.Forms.Application.StartupPath + "\\" + sFile + ".pdf");
                                        return;
                                    }

                                }
                            }
                            //sMail = "mashinhat@gmail.com;hiennv@vietsoft.com.vn;thangvk@vietsoft.com.vn";
                            sMail = Commons.Modules.ObjSystems.MBoMailTrung(sMail);
                            if (sMail.Equals(""))
                            {
                                Cursor = Cursors.Default;
                                Commons.Modules.ObjSystems.Xoahinh(System.Windows.Forms.Application.StartupPath + "\\" + sFile + ".pdf");
                                return;
                            }
                            else
                            {
                                GoiMail(System.Windows.Forms.Application.StartupPath + "\\" + sFile + ".pdf", sMail, iLoai);
                                if (iLoai != 1)
                                {
                                    sSql = "SELECT * FROM DE_XUAT_MUA_HANG_DUYET  WHERE NGUOI_DUYET = '" + Commons.Modules.UserName + "' AND QUYET_DINH = 1 AND DUYET = 1 AND MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "'";
                                    dtTmp = new System.Data.DataTable();
                                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                                    int iGoi = 0;
                                    // Kiem neu nguoi duyet co quyen quyet dinh thi goi cho nguoi mua hang
                                    if (dtTmp.Rows.Count > 0)
                                    {
                                        sSql = " SELECT B.USER_MAIL FROM DE_XUAT_MUA_HANG A INNER JOIN CONG_NHAN B ON A.NGUOI_TN = B.MS_CONG_NHAN WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "'";
                                        sMail = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)).Trim();
                                        //sMail = (sMail == "" ? "" : sMail + ";") + "mashinhat@gmail.com;hiennv@vietsoft.com.vn";
                                        sMail = Commons.Modules.ObjSystems.MBoMailTrung(sMail);
                                        GoiMail(System.Windows.Forms.Application.StartupPath + "\\" + sFile + ".pdf", sMail, 3);
                                    }
                                }
                            }

                        }
                        catch { }
                        break;
                    default:
                        Commons.Modules.SQLString = "";
                        frmRpt.ShowDialog();
                        Commons.Modules.SQLString = "0Design";
                        break;
                }

            }
            catch { }
            Commons.Modules.ObjSystems.Xoahinh(System.Windows.Forms.Application.StartupPath + "\\" + sFile + ".pdf");
            Cursor = Cursors.Default;
        }


        private System.Data.DataTable LanguageReportVINHHOAN()
        {
            System.Data.DataTable vtbTitle = new System.Data.DataTable();
            vtbTitle.TableName = "TIEU_DE_DNMH";
            Int32 i = 0;

            for (i = 0; i <= 30; i++)
            {
                vtbTitle.Columns.Add();
            }
            try
            {
                vtbTitle.Columns[0].ColumnName = "PHIEU_DE_NGHI_MUA_HANG";
                vtbTitle.Columns[1].ColumnName = "MA_SO";
                vtbTitle.Columns[2].ColumnName = "NGAY_HIEU_LUC";
                vtbTitle.Columns[3].ColumnName = "LAN_SOAT_XET";

                vtbTitle.Columns[4].ColumnName = "SO_YEU_CAU";
                vtbTitle.Columns[5].ColumnName = "MA_SO_KIEM_SOAT";
                vtbTitle.Columns[6].ColumnName = "PHONG_BAN_YEU_CAU";


                vtbTitle.Columns[7].ColumnName = "STT";
                vtbTitle.Columns[8].ColumnName = "TEN_HANG_HOA";
                vtbTitle.Columns[9].ColumnName = "MA";

                vtbTitle.Columns[10].ColumnName = "DVT";
                vtbTitle.Columns[11].ColumnName = "TON_HIEN_TAI";

                vtbTitle.Columns[12].ColumnName = "TON_MIN";
                vtbTitle.Columns[13].ColumnName = "SO_LUONG";



                vtbTitle.Columns[14].ColumnName = "DON_GIA";
                vtbTitle.Columns[15].ColumnName = "THOI_HAN_CUNG_CAP";
                vtbTitle.Columns[16].ColumnName = "LY_DO_DE_NGHI";
                vtbTitle.Columns[17].ColumnName = "GHI_CHU";




                vtbTitle.Columns[18].ColumnName = "NGUOI_LAP";
                vtbTitle.Columns[19].ColumnName = "PHE_DUYET";
                vtbTitle.Columns[20].ColumnName = "XEM_XET";



                vtbTitle.Columns[21].ColumnName = "TMP1";
                vtbTitle.Columns[22].ColumnName = "TMP2";
                vtbTitle.Columns[23].ColumnName = "TMP3";
                vtbTitle.Columns[24].ColumnName = "TMP4";
                vtbTitle.Columns[25].ColumnName = "TMP5";

                vtbTitle.Columns[26].ColumnName = "TEN_DV";
                vtbTitle.Columns[27].ColumnName = "THANH_TIEN";
                vtbTitle.Columns[28].ColumnName = "TMP6";
                vtbTitle.Columns[29].ColumnName = "TMP7";
                vtbTitle.Columns[30].ColumnName = "TMP8";


                System.Data.DataRow vRowTitle = vtbTitle.NewRow();
                String sBC = "rptDENGHIMUAHANG_VH";

                vRowTitle["PHIEU_DE_NGHI_MUA_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHIEU_DE_NGHI_MUA_HANG", Commons.Modules.TypeLanguage);

                vRowTitle["MA_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_SO", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_HIEU_LUC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_HIEU_LUC", Commons.Modules.TypeLanguage);
                vRowTitle["LAN_SOAT_XET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LAN_SOAT_XET", Commons.Modules.TypeLanguage);
                vRowTitle["SO_YEU_CAU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_YEU_CAU", Commons.Modules.TypeLanguage);
                vRowTitle["MA_SO_KIEM_SOAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_SO_KIEM_SOAT", Commons.Modules.TypeLanguage);
                vRowTitle["PHONG_BAN_YEU_CAU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHONG_BAN_YEU_CAU", Commons.Modules.TypeLanguage);
                vRowTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "STT", Commons.Modules.TypeLanguage);
                vRowTitle["TEN_HANG_HOA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_HANG_HOA", Commons.Modules.TypeLanguage);
                vRowTitle["MA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA", Commons.Modules.TypeLanguage);
                vRowTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DVT", Commons.Modules.TypeLanguage);
                vRowTitle["TON_HIEN_TAI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TON_HIEN_TAI", Commons.Modules.TypeLanguage);
                vRowTitle["TON_MIN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TON_MIN", Commons.Modules.TypeLanguage);
                vRowTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_LUONG", Commons.Modules.TypeLanguage);
                vRowTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DON_GIA", Commons.Modules.TypeLanguage);
                vRowTitle["THOI_HAN_CUNG_CAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THOI_HAN_CUNG_CAP", Commons.Modules.TypeLanguage);
                vRowTitle["LY_DO_DE_NGHI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LY_DO_DE_NGHI", Commons.Modules.TypeLanguage);
                vRowTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "GHI_CHU", Commons.Modules.TypeLanguage);
                vRowTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_LAP", Commons.Modules.TypeLanguage);
                vRowTitle["PHE_DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHE_DUYET", Commons.Modules.TypeLanguage);
                vRowTitle["XEM_XET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "XEM_XET", Commons.Modules.TypeLanguage);
                vRowTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY", Commons.Modules.TypeLanguage);
                vRowTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP2", Commons.Modules.TypeLanguage);
                vRowTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DE_NGHI", Commons.Modules.TypeLanguage);
                vRowTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "XAC_NHAN", Commons.Modules.TypeLanguage);
                vRowTitle["TMP5"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THUC_TE", Commons.Modules.TypeLanguage);
                vRowTitle["TEN_DV"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_DV", Commons.Modules.TypeLanguage);
                vRowTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THANH_TIEN", Commons.Modules.TypeLanguage);
                vRowTitle["TMP6"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DX_VAT_TU", Commons.Modules.TypeLanguage);
                vRowTitle["TMP7"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DX_DICH_VU", Commons.Modules.TypeLanguage);
                vRowTitle["TMP8"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP8", Commons.Modules.TypeLanguage);
                vtbTitle.Rows.Add(vRowTitle);
            }
            catch { }
            return vtbTitle;

        }
        #endregion

        private void DgvDuyetDeXuatMuaHang_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnCNDuyet_Click(object sender, EventArgs e)
        {

            DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacCapNhapLaiDuyet", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (Interaction.MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacCapNhapLaiDuyet", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo) == MsgBoxResult.No) return;
            //if (Vietsoft.Information.MsgBox(this, "msgBanCoChacCapNhapLaiDuyet", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No) return;
            Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

            try
            {
                Vietsoft.DataInfo.DeleteDataView(SqlDeXuatMuaHang, "SP_Y_DELETE_DUYET_DE_XUAT_MUA_HANG", TbDuyetDeXuatMuaHang.DefaultView, "MS_DE_XUAT", "NGUOI_DUYET");
                Vietsoft.DataInfo.ClearData(TbDuyetDeXuatMuaHang.DefaultView);
                TbDuyetDeXuatMuaHang.AcceptChanges();
            }
            catch
            {
                SqlDeXuatMuaHang.RollbackTransaction();
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgDeleteError", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            try
            {

                System.Data.DataTable TbDuyetDeXuatMH = new System.Data.DataTable();
                TbDuyetDeXuatMH.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DUYET_DE_XUAT_MH", (CboPHONG_BAN.Text == "" ? "-1" : CboPHONG_BAN.SelectedValue)));
                foreach (DataColumn ClDuyetDeXuatMH in TbDuyetDeXuatMH.Columns)
                {
                    ClDuyetDeXuatMH.ReadOnly = false;
                    ClDuyetDeXuatMH.AllowDBNull = true;
                }
                foreach (DataRow rDuyetDeXuatMH in TbDuyetDeXuatMH.Rows)
                {
                    rDuyetDeXuatMH["MS_DE_XUAT"] = ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["MS_DE_XUAT"];
                    TbDuyetDeXuatMuaHang.Rows.Add(rDuyetDeXuatMH.ItemArray);
                }
                ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGAY_DUYET"] = DBNull.Value;
                ((DataRowView)BindingDeXuatMuaHang.Current).Row["NGUOI_DUYET"] = DBNull.Value;
                if (((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"].Equals(3))
                {
                    ((DataRowView)BindingDeXuatMuaHang.Current).Row["TRANG_THAI"] = 2;
                    ((DataRowView)BindingDeXuatMuaHang.Current).Row["TEN_TRANG_THAI"] = "Trình duyệt";
                }
                Vietsoft.DataInfo.UpdateDataRow(SqlDeXuatMuaHang, "SP_Y_EDIT_DE_XUAT_MUA_HANG", ((DataRowView)BindingDeXuatMuaHang.Current).Row);
                Vietsoft.DataInfo.UpdateDataView(SqlDeXuatMuaHang, "SP_Y_INSERT_DUYET_DE_XUAT_MUA_HANG", "SP_Y_EDIT_DUYET_DE_XUAT_MUA_HANG", "SP_Y_CHECK_DUYET_DE_XUAT_MUA_HANG", TbDuyetDeXuatMuaHang.DefaultView, "MS_DE_XUAT", "NGUOI_DUYET");
                TbDuyetDeXuatMuaHang.AcceptChanges();
                InitializeForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void GoiMail(string sFileGoi, string sMail, int iLoai)
        {
            string sKetQua = "";
            string sNguoiDuyet = "";
            try
            {
                string sTieuDe = "";
                if (iLoai == 1)
                    sTieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name.ToString(), "TieuDeMailDXMH1", Commons.Modules.TypeLanguage) + " : " + TxtMS_DE_XUAT.Text;

                if (iLoai == 2)
                    sTieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name.ToString(), "TieuDeMailDXMH2", Commons.Modules.TypeLanguage) + " : " + TxtMS_DE_XUAT.Text;

                if (iLoai == 3)
                    sTieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name.ToString(), "TieuDeMailDXMH3", Commons.Modules.TypeLanguage) + " : " + TxtMS_DE_XUAT.Text;

                string sNoiDung = "";
                string sBody = "";

                if (iLoai == 3)
                    sBody = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                                           "frmDeXuatMuaHang_New", "sBody3", Commons.Modules.TypeLanguage);
                else
                    sBody = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                       "frmDeXuatMuaHang_New", "sNoiDung", Commons.Modules.TypeLanguage);


                string sNLap = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                            "SELECT TOP 1 HO + ' ' + TEN AS HOTEN FROM USERS A INNER JOIN CONG_NHAN B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN WHERE USERNAME = '" + TxtNGUOI_LAP.Text + "'")).Trim();
                string sNguoiLap = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmDeXuatMuaHang_New", "sNguoiLap", Commons.Modules.TypeLanguage) + " : " + sNLap;
                string sUNameLap = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmDeXuatMuaHang_New", "sUNameLap", Commons.Modules.TypeLanguage) + " : " + TxtNGUOI_LAP.Text;

                string sPhongBan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                        "frmDeXuatMuaHang_New", "sPhongBan", Commons.Modules.TypeLanguage) + " : " + CboPHONG_BAN.Text;
                if (iLoai != 1)
                {
                    string sNDuyet = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmDeXuatMuaHang_New", "sNguoiDuyet", Commons.Modules.TypeLanguage) + " : " + Commons.Modules.UserName;

                    string sNgayDuyet = "";

                    try
                    {
                        sNgayDuyet = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                                " SELECT TOP 1 CONVERT(NVARCHAR(10),ISNULL(NGAY_DUYET,''),103) AS NGAY_DUYET FROM DE_XUAT_MUA_HANG_DUYET " +
                                    " WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "' AND NGUOI_DUYET = '" + Commons.Modules.UserName + "' ")).Trim();
                        sNgayDuyet = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                                                "frmDeXuatMuaHang_New", "sNgayDuyet", Commons.Modules.TypeLanguage) + " : " + sNgayDuyet;
                    }
                    catch { }
                    sNguoiDuyet = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNDuyet + "<br>" +
                                        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNgayDuyet + "<br>";
                }
                sNoiDung = "";
                sBody = "<body>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNoiDung + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sBody + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNguoiLap + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sUNameLap + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sPhongBan + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + LabNgayDX.Text + " : " + MskNGAY_DE_XUAT.Text + "<br>" +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + LabGhiChu.Text + " : " + TxtGHI_CHU.Text + "<br>" +
                               sNguoiDuyet +
                               "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</body>";

                sKetQua = Commons.Modules.MMail.MSendEmail(sMail, Commons.Modules.sMailFrom,
                            Commons.Modules.sMailFromPass, sTieuDe, sBody, sFileGoi, Commons.Modules.sMailFromSmtp,
                            Commons.Modules.sMailFromPort);
            }
            catch { }
        }

        private void TabCTDX_Selecting(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (!BtnLuu.Visible) return;
            if (!bSuaDuyet && TabCTDX.SelectedTabPageIndex == 2) e.Cancel = true;
            if (bSuaDuyet && TabCTDX.SelectedTabPageIndex != 2) e.Cancel = true;

        }


        private void DgvDeXuatMuaHangDichVu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDeXuatMuaHangDichVu.Columns[e.ColumnIndex].Name != "DUONG_DAN_TL") return;
            if (!BtnLuu.Visible)
            {
                try
                {
                    if (DgvDeXuatMuaHangDichVu.RowCount <= 0) return;
                    if (DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["DUONG_DAN_TL"].Value.ToString() == "") return;
                    System.Diagnostics.Process.Start(DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["DUONG_DAN_TL"].Value.ToString());
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

                //if (DgvDeXuatMuaHangDichVu.Columns[e.ColumnIndex].Name != "DUONG_DAN_TL") return;
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Multiselect = false;
                oFile.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp) | *.jpg; *.jpeg; *.png, *.bmp";
                if (oFile.ShowDialog() != DialogResult.OK) return;
                try
                {
                    DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["DUONG_DAN_TL"].Value = oFile.FileName;
                    //Image image = new Image);



                }
                catch { }
                // TbDeXuatMuaHangDichVu.AcceptChanges();
            }

        }


        //     private void DgvDeXuatMuaHangChiTiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (DgvDeXuatMuaHangChiTiet.Columns[e.ColumnIndex].Name != "DUONG_DAN_TL") return;
        //    if (!BtnLuu.Visible)
        //    {
        //        try
        //        {
        //            if (DgvDeXuatMuaHangChiTiet.RowCount <= 0) return;
        //            if (DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["DUONG_DAN_TL"].Value.ToString() == "") return;
        //            System.Diagnostics.Process.Start(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["DUONG_DAN_TL"].Value.ToString());
        //        }
        //        catch (Exception ex)
        //        {
        //            XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    else
        //    {

        //        //if (DgvDeXuatMuaHangDichVu.Columns[e.ColumnIndex].Name != "DUONG_DAN_TL") return;
        //        OpenFileDialog oFile = new OpenFileDialog();
        //        oFile.Multiselect = false;
        //        oFile.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp) | *.jpg; *.jpeg; *.png, *.bmp";
        //        if (oFile.ShowDialog() != DialogResult.OK) return;
        //        try
        //        {
        //            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["DUONG_DAN_TL"].Value = oFile.FileName;
        //            Bitmap bitmap = new Bitmap(oFile.FileName);
        //            DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["IMAGES"].Value = Commons.Modules.ObjSystems.MImageToByteArray(bitmap);

        //        }
        //        catch { }
        //        TbDeXuatMuaHangChiTiet.AcceptChanges();
        //    }



        private Boolean KiemNutKhongDuyet()
        {
            string sSql = "";
            string sMsDX = TxtMS_DE_XUAT.Text;
            //--[13:31:00] Hien Bac Dau: Kiểm tra: Có trong duyệt + Chưa duyệt + Chưa có user nào có STT lớn hơn duyệt+ Chưa có user nào có STT nhỏ hơn, bắt buộc và chưa duyệt
            //--[13:31:49] Hien Bac Dau: nếu cái điều kiện cuối cùng khó quá
            //--[13:31:53] Hien Bac Dau: thì bỏ qua cũng dc
            //--[13:34:18] ]\/[®shi  ]\\[h®t: kiem tren don hang va phieu nhap khong co dx

            //SELECT * FROM DE_XUAT_MUA_HANG_DUYET WHERE MS_DE_XUAT = 'DX-1511-0006' AND
            //TT_DUYET > ()
            try
            {
                sSql = "SELECT TT_DUYET FROM DE_XUAT_MUA_HANG_DUYET WHERE MS_DE_XUAT = '" + sMsDX + "' AND NGUOI_DUYET = '" + Commons.Modules.UserName + "' AND DUYET = 0";
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            }
            catch { }
            return true;
        }

        private void DgvDuyetDeXuatMuaHang_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DgvDuyetDeXuatMuaHang.Rows[e.RowIndex].Cells["DUYET"].ErrorText = "";
        }

        private static int Mod(int dividend, int divisor)
        {
            int remainder = dividend % divisor;
            return remainder < 0 ? remainder + divisor : remainder;
        }


        /// <summary>
        /// Thoát form
        /// </summary> 


        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }


        public static string Encrypt(string strIn, string strKey)
        {
            string sbOut = String.Empty;
            for (int i = 0; i < strIn.Length; i++)
            {
                sbOut += String.Format("{0:00}", strIn[i] ^ strKey[i % strKey.Length]);
            }

            return sbOut;
        }

        public static string Decrypt(string strIn, string strKey)
        {
            string sbOut = String.Empty;
            for (int i = 0; i < strIn.Length; i += 2)
            {
                byte code = Convert.ToByte(strIn.Substring(i, 2));
                sbOut += (char)(code ^ strKey[(i / 2) % strKey.Length]);
            }

            return sbOut;
        }


        public static string ConvertStringToHex(String input, System.Text.Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }


        public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }

        private void btnKhongDuyet_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                                    Commons.Modules.ModuleName, this.Name, "msgChacKhongDuyetDeXuatNay", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;



            Vietsoft.SqlInfo SqlDeXuatMuaHang = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            try
            {

                SqlDeXuatMuaHang.BeginTransaction();
                ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["TRANG_THAI"] = 1;
                ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row["TEN_TRANG_THAI"] = sTT1DangSoan;
                Vietsoft.DataInfo.UpdateDataRow(SqlDeXuatMuaHang, "SP_Y_EDIT_DE_XUAT_MUA_HANG", ((DataRowView)DgvDeXuatMuaHang.CurrentRow.DataBoundItem).Row);
                if (Commons.Modules.iTRFData == 1)
                {
                    if (!TRFDeXuat(SqlDeXuatMuaHang, TxtMS_DE_XUAT.Text, 1))
                    {
                        SqlDeXuatMuaHang.RollbackTransaction();
                        BindingDeXuatMuaHang.CancelEdit();
                        InitializeControl();
                        return;
                    }
                }
                SqlDeXuatMuaHang.CommitTransaction();
                BindingDeXuatMuaHang.EndEdit();

            }
            catch
            {
                SqlDeXuatMuaHang.RollbackTransaction();
                BindingDeXuatMuaHang.CancelEdit();
                return;
            }



            this.Cursor = Cursors.WaitCursor;

            string sTieuDe = "";
            string sMail = "";
            try
            {
                sMail = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT B.USER_MAIL FROM DE_XUAT_MUA_HANG A INNER JOIN USERS B ON A.NGUOI_LAP = B.USERNAME WHERE NGUOI_LAP = N'" + TxtNGUOI_LAP.Text + "'"));

            }
            catch { sMail = ""; }

            try
            {
                if (TxtNGUOI_SUA.Text != "")
                {
                    sTieuDe = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT B.USER_MAIL FROM DE_XUAT_MUA_HANG A INNER JOIN USERS B ON A.NGUOI_SUA = B.USERNAME WHERE NGUOI_SUA = N'" + TxtNGUOI_SUA.Text + "'"));

                }

            }
            catch { sTieuDe = ""; }
            sTieuDe = (sTieuDe != "" ? ";" + sTieuDe : "");
            sMail = (sMail == "" ? sTieuDe : sMail + sTieuDe);
            sTieuDe = "";


            string sKetQua = "";
            string sNoiDung, sBody;
            sNoiDung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sMailDeXuatKhongDuyet", Commons.Modules.TypeLanguage);
            sTieuDe = sNoiDung + " : " + TxtMS_DE_XUAT.Text;


            sBody = "";
            sBody = "<body>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNoiDung + "<br>" +
                           "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sBody + "<br>" +
                           "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + LabMSDX.Text + " : " + TxtMS_DE_XUAT.Text + "<br>" +
                           "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + LabNgayDX.Text + " : " + MskNGAY_DE_XUAT.Text + "<br>" +
                           "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + LabGhiChu.Text + " : " + TxtGHI_CHU.Text + "<br>" +
                           "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name.ToString(), "sMailUserKhongDuyet", Commons.Modules.TypeLanguage) + " : " + Commons.Modules.UserName + "<br>" +
                           "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</body>";

            sMail = "mashinhat@gmail.com";
            sKetQua = Commons.Modules.MMail.MSendEmail(sMail, Commons.Modules.sMailFrom,
                        Commons.Modules.sMailFromPass, sTieuDe, sBody, "", Commons.Modules.sMailFromSmtp,
                        Commons.Modules.sMailFromPort);


            InitializeControl();

            this.Cursor = Cursors.Default;
        }

        private void DgvDeXuatMuaHangChiTiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDeXuatMuaHangChiTiet.Columns[e.ColumnIndex].Name != "DUONG_DAN_TL") return;
            if (!BtnLuu.Visible)
            {
                try
                {
                    if (DgvDeXuatMuaHangChiTiet.RowCount <= 0) return;
                    if (DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["DUONG_DAN_TL"].Value.ToString() == "") return;
                    System.Diagnostics.Process.Start(DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["DUONG_DAN_TL"].Value.ToString());
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Multiselect = false;
                oFile.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp) | *.jpg; *.jpeg; *.png, *.bmp";
                if (oFile.ShowDialog() != DialogResult.OK) return;
                try
                {
                    DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["DUONG_DAN_TL"].Value = oFile.FileName;
                }
                catch { }
                TbDeXuatMuaHangChiTiet.AcceptChanges();
            }
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private void InPurchaseItem()
        {
            System.Data.DataTable dtTmp = new System.Data.DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetDXCT_VECO", TxtMS_DE_XUAT.Text, 1));
            try
            {
                grdChung.DataSource = null;
                grvChung.Columns.Clear();
                grdChung.RepositoryItems.Clear();
            }
            catch { }

            if (dtTmp.Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "KhongCoDuLieuIn", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            dtTmp.Columns.Add("IMAGE", typeof(Image));
            dtTmp.Columns["IMAGE"].ReadOnly = false;
            grdChung.DataSource = dtTmp;
            grvChung.RowHeight = 120;
            grvChung.Columns["IMAGE"].Width = 265;
            grvChung.Columns["IMAGE"].MaxWidth = 265;
            grvChung.Columns["IMAGE"].MinWidth = 265;

            int tmp = grvChung.Columns["IMAGE"].VisibleIndex;
            grvChung.Columns["IMAGE"].VisibleIndex = grvChung.Columns["Picture to refer"].VisibleIndex;
            grvChung.Columns["Picture to refer"].VisibleIndex = tmp;

            grvChung.Columns["Picture to refer"].Visible = false;
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, "frmDeXuatMuaHang_New", 1);


            RepositoryItemPictureEdit repositoryItemPictureEdit1 = new RepositoryItemPictureEdit();
            repositoryItemPictureEdit1.Name = "IMAGE";
            repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            repositoryItemPictureEdit1.NullText = (" ");
            repositoryItemPictureEdit1.PictureAlignment = ContentAlignment.MiddleCenter;


            grdChung.RepositoryItems.Add(repositoryItemPictureEdit1);
            grvChung.Columns[grvChung.Columns.Count - 1].ColumnEdit = repositoryItemPictureEdit1;

            for (int i = 0; i < grvChung.RowCount; i++)
            {
                try
                {
                    Image imageFromFile = Image.FromFile(grvChung.GetDataRow(i)["Picture to refer"].ToString());

                    grvChung.SetRowCellValue(i, "IMAGE", imageFromFile);
                }
                catch { }
            }



            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();

            int TCot = grvChung.Columns.Count - 1;
            int TDong = grvChung.RowCount;
            int Dong = 1;

            string stmp;

            grdChung.ExportToXls(sPath);
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;

            Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

            try
            {
                excelApplication.Cells.Font.Name = "Calibri";
                excelApplication.Cells.Font.Size = 14;


                Commons.Modules.MExcel.ThemDong(excelWorkSheet, XlInsertShiftDirection.xlShiftDown, 6, Dong);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, System.Windows.Forms.Application.StartupPath);


                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, false,
                    false, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 10, 10, 30, 30, 100);

                excelApplication.Cells.Font.Name = "Calibri";
                excelApplication.Cells.Font.Size = 14;

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "MS_ISO", 1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 1, 9, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, 1, 10);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "MS_ISO_SO", 1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 1, 11, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, 1, 13);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "NGAY_BAN_HANH", 1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 2, 9, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, 2, 10);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "NGAY_BAN_HANH_SO", 1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 2, 11, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, 2, 13);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "SO_TRANG", 1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 3, 9, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, 3, 10);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "SO_TRANG_SO", 1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 3, 11, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, 3, 13);
                //stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "KO_SUA_ISO", 1);
                //Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 1, 14, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                //    Excel.XlVAlign.xlVAlignCenter, true, 3, 14);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "TieuDe_IN", 1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 5, 1, "@", 12, true, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, 5, TCot);

                Dong++;
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "Item",
                    1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 6, 2, "@", 12, false, Excel.XlHAlign.xlHAlignCenter,
                    Excel.XlVAlign.xlVAlignCenter, true, 6, 9);
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "Purpose",
                    1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 6, 10, "@", 12, false, true, 6, 13);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "Application",
                    1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 8 + TDong + 1, 2, "@", 12, false, true, 8 + TDong + 1, 2);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "Dept_Manager",
                    1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 8 + TDong + 1, 15, "@", 12, false, true, 8 + TDong + 1, 17);

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "ISO_revision",
                    1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 8 + TDong + 4, 2, "@", 12, false, true, 8 + TDong + 4, 3);


                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDeXuatMuaHang_New", "TEN_CONG_TY_IN",
                    1);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, 1, 2, "@", 14, false, true, 1, 2);
                Dong++;




                Dong++;
                Dong++;
                Excel.Range title;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 6, 1, 7, TCot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Interior.Color = Excel.XlColorIndex.xlColorIndexNone;
                title.Borders.Color = Excel.XlColorIndex.xlColorIndexNone;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 1, 3, 13);
                title.Borders.LineStyle = 1;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 6, 1, 6 + TDong + 1, TCot);
                title.Borders.LineStyle = 1;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                title.WrapText = true;
                for (int i = 1; i < 4; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i, 9, i, 10);
                    title.MergeCells = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    title.Font.Bold = false;
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i, 11, i, 13);
                    title.MergeCells = true;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    title.Font.Bold = false;
                }

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 8 + TDong + 3, 2, 8 + TDong + 3, 2);
                title.Value = DateTime.Now.ToString("dd-MMM-yy");
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 8 + TDong + 4, 2, 8 + TDong + 4, 3);
                title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 255));


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 8 + TDong + 1, 15, 8 + TDong + 1, 17);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 8 + TDong + 1, 1, 8 + TDong + 1, 2);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 14, 3, 14);
                title.MergeCells = true;
                title.WrapText = true;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 1, 3, 13);
                title.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble;
                title.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 2, 3, 8);
                title.MergeCells = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Font.Bold = true;


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 6, 1, 7, 1);
                title.MergeCells = true;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 6, 14, 7, 14);
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 6, 15, 7, 15);
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 6, 16, 7, 16);
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 6, 17, 7, 17);
                title.MergeCells = true;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 6, 10, 6, 13);
                title.Rows.AutoFit();

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 6, 1, 6, TCot);
                title.RowHeight = 33;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 7, 1, 7, TCot);
                title.RowHeight = 55;

                Commons.Modules.MExcel.ThemDong(excelWorkSheet, XlInsertShiftDirection.xlShiftDown, 1, 8);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 8, 1, 8, TCot);
                title.RowHeight = 15;

                for (int i = 1; i <= TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 8, i, 8, i);
                    title.Value = i;
                    title.Font.Name = "Calibri";
                    title.Font.Size = 14;
                    title.Font.Bold = false;

                }

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.57, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 78.43, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 51.43, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 24.14, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 40.71, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35.43, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15.29, "@", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.29, "@", true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.71, "@", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 11, TDong + Dong, 11);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 12, TDong + Dong, 12);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 13, TDong + Dong, 13);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 40, "@", true, Dong + 1, 14, TDong + Dong, 14);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21.43, "@", true, Dong + 4, 15, TDong + Dong, 15);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.71, "@", true, Dong + 1, 16, TDong + Dong, 16);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13.43, "@", true, Dong + 1, 17, TDong + Dong, 17);








                excelWorkbook.Save();

                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);

                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);

            }
            catch (Exception ex)
            {
                MessageBox.Show("In Không thành công");
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }

            this.Cursor = Cursors.Default;
        }

        private void DgvDeXuatMuaHangChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Commons.Modules.sPrivate != "VECO") return;
            if (DgvDeXuatMuaHangChiTiet.Columns[e.ColumnIndex].Name == "TEN_MAY")
            {
                try
                {
                    System.Data.DataTable dt = ((System.Data.DataTable)(((DataGridViewComboBoxColumn)DgvDeXuatMuaHangChiTiet.Columns[e.ColumnIndex]).DataSource)).Copy();
                    dt.DefaultView.RowFilter = "MS_MAY = '" + DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'";
                    dt = dt.DefaultView.ToTable();
                    DgvDeXuatMuaHangChiTiet.Rows[e.RowIndex].Cells["TEN_N_XUONG"].Value = dt.Rows.Count > 0 ? dt.Rows[0]["Ten_N_XUONG"] : "";
                }
                catch
                { }

            }
        }

        private void DgvDeXuatMuaHangDichVu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Commons.Modules.sPrivate != "VECO") return;
            if (DgvDeXuatMuaHangDichVu.Columns[e.ColumnIndex].Name == "TEN_MAY")
            {
                try
                {
                    System.Data.DataTable dt = ((System.Data.DataTable)(((DataGridViewComboBoxColumn)DgvDeXuatMuaHangDichVu.Columns[e.ColumnIndex]).DataSource)).Copy();
                    dt.DefaultView.RowFilter = "MS_MAY = '" + DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'";
                    dt = dt.DefaultView.ToTable();
                    DgvDeXuatMuaHangDichVu.Rows[e.RowIndex].Cells["TEN_N_XUONG"].Value = dt.Rows.Count > 0 ? dt.Rows[0]["Ten_N_XUONG"] : "";
                }
                catch
                { }
            }


        }

        private void DoiMau()
        {
            try
            {



                for (int i = 0; i < DgvDeXuatMuaHangChiTiet.RowCount; i++)
                {

                    if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED")
                    {

                        //. Những vật tư nào đạt quá tồn max thì hiện màu đỏ còn vật tư không có qui định tồn max và tồn min mà đặt hàng thì hiện màu vàng.Làm như vậy trước khi duyệt Sang sẽ hỏi lại A / e phía dưới.
                        double dMin, dMax, dDXuat;
                        try
                        {
                            dDXuat = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[i].Cells["SL_DE_XUAT"].Value);
                        }
                        catch { dDXuat = 0; }

                        try
                        {
                            dMin = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[i].Cells["TON_MIN"].Value);
                        }
                        catch { dMin = 0; }

                        try
                        {
                            dMax = Convert.ToDouble(DgvDeXuatMuaHangChiTiet.Rows[i].Cells["TON_MAX"].Value);
                        }
                        catch { dMax = 0; }
                        try
                        {
                            if (dDXuat > dMax)
                                DgvDeXuatMuaHangChiTiet.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        catch { DgvDeXuatMuaHangChiTiet.Rows[i].DefaultCellStyle.BackColor = Color.White; }


                        try
                        {
                            if (dMax == 0 && dMin == 0)
                                DgvDeXuatMuaHangChiTiet.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        catch
                        {
                            DgvDeXuatMuaHangChiTiet.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                    }


                    if (Convert.ToInt32(DgvDeXuatMuaHangChiTiet.Rows[i].Cells[DgvDeXuatMuaHangChiTiet.ColumnCount - 1].Value) == 1)
                        DgvDeXuatMuaHangChiTiet[DgvDeXuatMuaHangChiTiet.ColumnCount - 2, i].Style.BackColor = Color.Beige;
                    if (Convert.ToInt32(DgvDeXuatMuaHangChiTiet.Rows[i].Cells[DgvDeXuatMuaHangChiTiet.ColumnCount - 1].Value) == 0)
                        DgvDeXuatMuaHangChiTiet[DgvDeXuatMuaHangChiTiet.ColumnCount - 2, i].Style.BackColor = Color.Bisque;



                }
            }
            catch
            { }
        }

        private void frmDeXuatMuaHang_New_Shown(object sender, EventArgs e)
        {
            DoiMau();
        }

        private void DgvDeXuatMuaHangChiTiet_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }
    }
}




