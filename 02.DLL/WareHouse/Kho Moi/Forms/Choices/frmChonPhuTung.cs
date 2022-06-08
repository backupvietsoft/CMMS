using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmChonPhuTung : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Khai báo chung
        /// </summary> 
        private DataTable _TbSource = new DataTable();
        private DataTable _TbCurrent = new DataTable();
        public int _ms_kho = 0;
        private bool isFirst = false;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary> 
        public frmChonPhuTung()
        {
            InitializeComponent();
        }
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
        /// Load form
        /// </summary> 
        private void frmSelectItem_Load(object sender, EventArgs e)
        {
            isFirst = true;
            Commons.Modules.ObjSystems.MLoadLookUpEdit(CboKho, Commons.Modules.ObjSystems.MLoadDataKho(1), "MS_KHO", "TEN_KHO", "");
            isFirst = false;
            CboKho.EditValue = _ms_kho;
            CboKho_EditValueChanged(null, null);
            CboKho.Enabled = false;

            Commons.Modules.ObjSystems.ThayDoiNN(this);
            btnNotALL.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnClear",
                Commons.Modules.TypeLanguage);
            if (Commons.Modules.sPrivate.ToUpper() == "CS" && this.Name == "frmChonPhuTung_DX")
            {
                btnAll.Visible = false;
                btnNotALL.Visible = false;
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            _ms_kho = Convert.ToInt32(CboKho.EditValue);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chkTonToiThieu_CheckedChanged(object sender, EventArgs e)
        {
            LocData();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvVatTu);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvVatTu);
        }

        private void txtMSPT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string dk = "";
                if (Commons.Modules.sPrivate.ToUpper() == "CS" && this.Name == "frmChonPhuTung_DX")
                {

                    if (txtTimKiem.Text.Length != 0) dk = " AND MS_PT LIKE '%" + txtTimKiem.Text + "%' " + dk;
                    if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                }
                else
                {
                    if (txtTimKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTimKiem.Text + "%' " + dk;
                    if (txtTimKiem.Text.Length != 0) dk = " OR  TEN_PT LIKE '%" + txtTimKiem.Text + "%' " + dk;
                    if (txtTimKiem.Text.Length != 0) dk = " OR  MS_PT_CTY LIKE '%" + txtTimKiem.Text + "%' " + dk;
                    if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);


                }
                if (chkTonToiThieu.Checked)
                    dk = " (TON_KHO < TON_MIN) AND ( " + dk + " )";

                _TbSource.DefaultView.RowFilter = dk;
            }
            catch { _TbSource.DefaultView.RowFilter = ""; }

        }

        private void CboKho_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isFirst) return;

                if (_ms_kho != 0 && _ms_kho != -1)
                    _ms_kho = Convert.ToInt32(CboKho.EditValue);
                Vietsoft.SqlInfo SqlPhuTung = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                _TbSource = new DataTable();
                _TbSource.Load(SqlPhuTung.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_PHU_TUNG_DE_XUAT", _ms_kho));
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
                    _TbSource.Rows.Remove(_TbSource.Rows.Find(_TbCurrent.Rows[i]["MS_PT"]));
                }
                LoadLuoi();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadLuoi()
        {
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdVatTu, grvVatTu, _TbSource, true, false, false, false);
            grvVatTu.Columns[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            grvVatTu.Columns[1].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                DevExpress.Utils.OptionsLayoutGrid opts = new DevExpress.Utils.OptionsLayoutGrid();
                try
                {
                    opts.Columns.StoreAllOptions = true;
                    grvVatTu.RestoreLayoutFromXml(Application.StartupPath + "\\XML\\GridDeXuatChonPhuTung.xml", opts);
                }
                catch (Exception ex)
                {
                    grdVatTu.MainView.SaveLayoutToXml(Application.StartupPath + @"\XML\GridDeXuatChonPhuTung.xml");
                }

   
        }
        private void LocData()
        {
            string sDK = "";
            try
            {
                sDK = " MS_PT LIKE '%" + txtTimKiem.Text + "%' OR MS_PT_CTY LIKE '%" + txtTimKiem.Text + "%' OR TEN_LOAI_VT_TV LIKE '%" + txtTimKiem.Text + "%' " + sDK + " OR  PART_NO LIKE '%" + txtTimKiem.Text + "%' OR  TEN_PT LIKE '%" + txtTimKiem.Text + "%' ";

                if (chkTonToiThieu.Checked)
                    sDK = " (TON_KHO < TON_MIN) AND ( " + sDK + " )";


                _TbSource.DefaultView.RowFilter = sDK;
            }
            catch { _TbSource.DefaultView.RowFilter = ""; }



            //          TMP1.MS_PT,MS_PT_CTY, TMP1.TEN_LOAI_VT_TV,TMP1.MS_PT_NCC AS PART_NO,TMP1.TEN_PT,
            //TMP1.QUY_CACH, TEN_HSX,TMP1.TEN_1 AS DVT

        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            LocData();
        }

        private void grvVatTu_ColumnPositionChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString != "MenuColumnRemoveColumn")
                return;
            try
            {
                DevExpress.Utils.OptionsLayoutGrid opts = new DevExpress.Utils.OptionsLayoutGrid();
                opts.Columns.StoreAllOptions = true;
                grvVatTu.SaveLayoutToXml(Application.StartupPath + "\\XML\\GridDeXuatChonPhuTung.xml", opts);
                Commons.Modules.SQLString = "";

            }
            catch (Exception ex)
            {
            }
        }

        private void grvVatTu_GridMenuItemClick(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuItemClickEventArgs e)
        {
            if (e.DXMenuItem.Tag.ToString() == DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn.ToString())
            {
                Commons.Modules.SQLString = "MenuColumnRemoveColumn";
            }
        }

        private void grvVatTu_HideCustomizationForm(object sender, EventArgs e)
        {

            try
            {
                DevExpress.Utils.OptionsLayoutGrid opts = new DevExpress.Utils.OptionsLayoutGrid();
                opts.Columns.StoreAllOptions = true;
                grvVatTu.SaveLayoutToXml(Application.StartupPath + "\\XML\\GridDeXuatChonPhuTung.xml", opts);
            }
            catch (Exception ex)
            {
            }

        }
    }
}