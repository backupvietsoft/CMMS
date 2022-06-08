using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmChonPTNhapKho : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Khai báo chung
        /// </summary> 
        private DataTable _TbSource = new DataTable();
        private DataTable _TbCurrent = new DataTable();
        private int _MsKho = -1;
        private int _MsDangNhap = -1;
        private string _MsDDH = String.Empty;
        /// <summary>
        /// DataSource
        /// </summary> 
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
        /// <summary>
        /// Kho
        /// </summary> 
        public int Kho
        {
            set
            {
                _MsKho = value;
            }
        }
        /// <summary>
        /// Dang xuất
        /// </summary> 
        public int DangNhap
        {
            set
            {
                _MsDangNhap = value;
            }
        }
        /// <summary>
        /// Mã số đơn đặt hàng
        /// </summary> 
        public string DonDatHang
        {
            set
            {
                _MsDDH = value;
            }
        }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary> 
        public frmChonPTNhapKho()
        {
            InitializeComponent();
        }

        private void frmChonPTNhapKho_Load(object sender, EventArgs e)
        {
            Vietsoft.SqlInfo SqlPhuTung = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            _TbSource = new DataTable();
            _TbSource.Load(SqlPhuTung.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_PHU_TUNG_NHAP_KHO", _MsKho , _MsDangNhap,_MsDDH));
            foreach (DataColumn ClPhuTung in _TbSource.Columns)
            {
                ClPhuTung.ReadOnly = true;
            }
            _TbSource.Columns["CHON"].ReadOnly = false;
            if (_MsDDH != "-1")
            {
                for (int i = 0; i < _TbCurrent.Rows.Count; i++)
                {
                    try
                    {
                        _TbSource.Rows.Remove(_TbSource.Rows.Find(_TbCurrent.Rows[i]["MS_PT"]));
                    }
                    catch { }
                }
            }
            else
            {
                if (Commons.Modules.sPrivate.ToUpper() == "greenfeed".ToUpper())
                    btnImport.Visible = false;
                else
                    btnImport.Visible = true;
            }

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdPhuTung, grvPhuTung, _TbSource, true, false, false, false);
            grvPhuTung.Columns["CHON"].OptionsColumn.ReadOnly = false;

            grvPhuTung.Columns["MS_CHI_TIET_DH"].Visible = false;
            grvPhuTung.Columns["NGOAI_TE"].Visible = false;
            grvPhuTung.Columns["MS_VI_TRI"].Visible = false;
            grvPhuTung.Columns["THUE_VAT"].Visible = false;
      
            grvPhuTung.Columns["TEN_LOAI_VT"].Visible = false;
            //grvPhuTung.Columns["PART_NO"].Visible = false;
            //grvPhuTung.Columns["QUY_CACH"].Visible = false;

            grvPhuTung.Columns["CHON"].Width = 75;
            grvPhuTung.Columns["MS_PT"].Width = 100;
            grvPhuTung.Columns["TEN_LOAI_VT"].Width = 100;
            grvPhuTung.Columns["SL_DAT_HANG"].Width = 110;
            grvPhuTung.Columns["DVT"].Width = 70;

            grvPhuTung.Columns["DON_GIA"].Width = 150;
            grvPhuTung.Columns["SL_DAT_HANG"].DisplayFormat.FormatString = "N" + Commons.Modules.iSoLeSL;
            grvPhuTung.Columns["DON_GIA"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
            grvPhuTung.Columns["SL_DAT_HANG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            grvPhuTung.Columns["DON_GIA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            try
            {
                grvPhuTung.Columns["ID_XUAT"].Visible = false;
                grvPhuTung.Columns["MS_CHI_TIET_DH"].Visible = false;
                grvPhuTung.Columns["XUAT_XU"].Visible = false;
                grvPhuTung.Columns["BAO_HANH_DEN_NGAY"].Visible = false;
            }
            catch { }


            Commons.Modules.ObjSystems.ThayDoiNN(this);
            
        }

        private void ChooseAll(bool choose)
        {
            for(int i = 0; i < grvPhuTung.RowCount; i++)
            {
                grvPhuTung.GetDataRow(i)["CHON"] = choose;
                grdPhuTung.Update();
            }
        }
        private void txtMS_TextChanged(object sender, EventArgs e)
        {
            LocData();
        }
        private void LocData()
        {
            try
            {
                string dk = "";
                if (txtMS.Text.Length != 0) dk = " MS_PT LIKE '%" + txtMS.Text + "%' " + " OR TEN_LOAI_VT LIKE '%" + txtMS.Text + "%' " + " OR  PART_NO LIKE '%" + txtMS.Text + "%' " + " OR TEN_PT LIKE '%" + txtMS.Text + "%' "+ " OR QUY_CACH LIKE '%" + txtMS.Text + "%' ";
                _TbSource.DefaultView.RowFilter = dk;
            }
            catch (Exception ex)
            { _TbSource.DefaultView.RowFilter = ""; }

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ChooseAll(true);
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            ChooseAll(false);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            
            string sPath = "";
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm | All Files(*.*) | *.*";
            if (of.ShowDialog() == DialogResult.Cancel) return;
            sPath = of.FileName;
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            DataTable dt = GetDataTableFromExcel(sPath);
            //dt.Rows[0].Delete();
            //dt.AcceptChanges();
            _TbSource.Columns["SL_DAT_HANG"].ReadOnly = false;
            _TbSource.Columns["DON_GIA"].ReadOnly = false;
            try
            {
                _TbSource.AsEnumerable()
                .Join(dt.AsEnumerable(),
                        dt1_Row => dt1_Row.ItemArray[1],
                        dt2_Row => dt2_Row.ItemArray[0],
                        (dt1_Row, dt2_Row) => new { dt1_Row, dt2_Row })
                .ToList()
                .ForEach(o =>
                {
                    o.dt1_Row.SetField(7, o.dt2_Row.ItemArray[2]);
                    o.dt1_Row.SetField(0, 1);
                    o.dt1_Row.SetField(8, o.dt2_Row.ItemArray[3]);
                }      
                        ) ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            int i = 0;
            try
            {
                _TbSource.AsEnumerable()
                .Join(dt.AsEnumerable(),
                        dt1_Row => dt1_Row.ItemArray[4],
                        dt2_Row => dt2_Row.ItemArray[1],
                        (dt1_Row, dt2_Row) => new { dt1_Row, dt2_Row })
                .ToList()
                .ForEach(o =>
                {
                    o.dt1_Row.SetField(7, o.dt2_Row.ItemArray[2]);
                    o.dt1_Row.SetField(0, 1);
                    o.dt1_Row.SetField(8, o.dt2_Row.ItemArray[3]);
                }
                        );
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
            this.Cursor = Cursors.Default;
        }



        private  DataTable GetDataTableFromExcel(string path)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                tbl.Columns.AddRange(new DataColumn[] { new DataColumn ("MS_PT",typeof(string)),
                    new DataColumn ("TEN_PT",typeof(string)),
                    new DataColumn ("SO_LUONG",typeof(string)),
                    new DataColumn ("DON_GIA",typeof(string))
                    });

                var startRow = 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                return tbl;
            }
        }
    }
}