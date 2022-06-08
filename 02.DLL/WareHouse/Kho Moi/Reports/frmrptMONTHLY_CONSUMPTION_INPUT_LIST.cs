using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace WareHouse
{
    public partial class frmrptMONTHLY_CONSUMPTION_INPUT_LIST : DevExpress.XtraEditors.XtraUserControl
    {
        string str = "";
        DataTable dtVTu = new DataTable();

        public frmrptMONTHLY_CONSUMPTION_INPUT_LIST()
        {
            InitializeComponent();
        }

        private void TaoLoaiVT()
        {
            str = "SELECT CONVERT (INT,-1) AS LoaiID , CONVERT (NVARCHAR(25),' < ALL > ') AS LoaiVT UNION " +
                    " SELECT 0, N'Spare Part' UNION  SELECT 1 ,N'Consumtion' ORDER BY LoaiVT " ;
            DataTable dtmp = new DataTable();
            dtmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString , CommandType.Text, str));

            cmbLVT.Properties.DataSource = dtmp;
            cmbLVT.Properties.DisplayMember = "LoaiVT";
            cmbLVT.Properties.ValueMember = "LoaiID";

            cmbLVT.Properties.Columns.Clear();
            // Add single column
            cmbLVT.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoaiVT"));
            cmbLVT.Properties.Columns["LoaiVT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmrptMONTHLY_CONSUMPTION_INPUT_LIST", cmbLVT.Properties.Columns["LoaiVT"].FieldName, Commons.Modules.TypeLanguage);
            cmbLVT.EditValue = -1;

        }
        private void TaoQuocGia()
        {

            DataTable dtQG = new DataTable();
            dtQG = new DataTable();
            dtQG.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetQUOC_GIAbyLoaiVT", cmbLVT.EditValue.ToString()));
            dtQG.Columns["CHON"].ReadOnly = false;
            dtQG.Columns["TEN_QG"].ReadOnly = true;

            grdQG.DataSource = dtQG;
            grvQG.Columns["MA_QG"].Visible = false;
            grvQG.OptionsView.ColumnAutoWidth = true;
            grvQG.OptionsView.AllowHtmlDrawHeaders = true;
            grvQG.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvQG.BestFitColumns();
            grvQG.OptionsBehavior.Editable = true;
            
            
            grvQG.Columns["CHON"].Width = 75;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit edit = grvQG.GridControl.RepositoryItems.Add("CheckEdit") as DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit;
            grvQG.Columns["CHON"].ColumnEdit = edit;
            grvQG.Columns["CHON"].OptionsColumn.ReadOnly = false;
            grvQG.Columns["CHON"].OptionsColumn.AllowEdit = true;

            edit.CheckedChanged += new System.EventHandler(this.edit_CheckedChanged);
            edit.ReadOnly = false;

            grvQG.Columns["CHON"].OptionsColumn.AllowEdit = true;
            dtQG.Columns["CHON"].ReadOnly = false;
            grvQG.Columns["CHON"].OptionsColumn.ReadOnly = false;

        }
        private void edit_CheckedChanged(object sender, EventArgs e)
        {
            grvQG.CloseEditor();
            grvQG.UpdateCurrentRow();
            LocVatTu();
        }

        private void TaoKho()
        {

            DataTable dtmp = new DataTable();
            dtmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "MGetKhoMONTHLY_CONSUMPTION_INPUT_LIST", cmbLVT.EditValue.ToString()));
            dtmp.Columns["CHON"].ReadOnly = false;
            grdKho.DataSource = dtmp;
            

            dtmp.Columns["TEN_KHO"].ReadOnly = true;
            grvKho.Columns["MS_KHO"].Visible = false;

            grvKho.OptionsView.ColumnAutoWidth = true;
            grvKho.OptionsView.AllowHtmlDrawHeaders = true;
            grvKho.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvKho.BestFitColumns();
            grvKho.OptionsBehavior.Editable = true;
            grvKho.Columns["CHON"].Width = 75;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckKho = grvKho.GridControl.RepositoryItems.Add("CheckEdit") as DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit;
            grvKho.Columns["CHON"].ColumnEdit = ckKho;
            grvKho.Columns["CHON"].OptionsColumn.ReadOnly = false;
            grvKho.Columns["CHON"].OptionsColumn.AllowEdit = true;

            ckKho.CheckedChanged += new System.EventHandler(this.ckKho_CheckedChanged);
            ckKho.ReadOnly = false;

            grvKho.Columns["CHON"].OptionsColumn.AllowEdit = true;
            dtmp.Columns["CHON"].ReadOnly = false;
            grvKho.Columns["CHON"].OptionsColumn.ReadOnly = false;

        }
        private void ckKho_CheckedChanged(object sender, EventArgs e)
        {
            grvKho.CloseEditor();
            grvKho.UpdateCurrentRow();
            LocVatTu();
        }

        private void TaoVatTu()
        {
            

            if (grvQG.DataSource == null )
                return;

            if (grvKho.DataSource == null)
                return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                str = " SELECT DISTINCT CONVERT (BIT,0) AS CHON, dbo.IC_PHU_TUNG.MS_PT_NCC, dbo.IC_PHU_TUNG.MS_PT, dbo.IC_PHU_TUNG.TEN_PT, " +
                            " dbo.IC_PHU_TUNG.QUY_CACH,  dbo.KHACH_HANG.QUOCGIA, dbo.IC_DON_HANG_NHAP.MS_KHO,dbo.LOAI_VT.VAT_TU " +
                            " FROM         dbo.IC_PHU_TUNG INNER JOIN " +
                            " dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT INNER JOIN " +
                            " dbo.IC_DON_HANG_NHAP_VAT_TU ON dbo.IC_PHU_TUNG.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT INNER JOIN " +
                            " dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT INNER JOIN " +
                            " dbo.KHACH_HANG ON dbo.IC_DON_HANG_NHAP.NGUOI_NHAP = dbo.KHACH_HANG.MS_KH WHERE (-1 =" + cmbLVT.EditValue.ToString() +
                            " OR dbo.LOAI_VT.VAT_TU = " + cmbLVT.EditValue.ToString() + " ) ";
                dtVTu.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, str));
                dtVTu.Columns["CHON"].ReadOnly = false;
                LocVatTu();
                this.Cursor = Cursors.Default;
                if (!grvVT.Columns["MS_KHO"].Visible) return;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvVT.Columns)
                {
                    col.OptionsColumn.ReadOnly = true;
                }
                grvVT.Columns["CHON"].OptionsColumn.ReadOnly = false;

                grvVT.OptionsView.ColumnAutoWidth = true;
                grvVT.OptionsView.AllowHtmlDrawHeaders = true;
                grvVT.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                grvVT.BestFitColumns();
                grvVT.OptionsBehavior.Editable = true;
                grvVT.Columns["CHON"].Width = 75;
                grvVT.Columns["MS_PT"].Width = 85;
                grvVT.Columns["MS_PT_NCC"].Width = 85;
                grvVT.Columns["TEN_PT"].Width = 110;

                DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkVT = grvQG.GridControl.RepositoryItems.Add("CheckEdit") as DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit;
                grvVT.Columns["CHON"].ColumnEdit = chkVT;
                grvVT.Columns["CHON"].OptionsColumn.ReadOnly = false;
                grvVT.Columns["CHON"].OptionsColumn.AllowEdit = true;

                chkVT.CheckedChanged += new System.EventHandler(this.chkVT_CheckedChanged);
                chkVT.ReadOnly = false;

                grvVT.Columns["CHON"].OptionsColumn.AllowEdit = true;
                dtVTu.Columns["CHON"].ReadOnly = false;
                grvVT.Columns["CHON"].OptionsColumn.ReadOnly = false;

                grvVT.Columns["MS_KHO"].Visible = false;
                grvVT.Columns["QUOCGIA"].Visible = false;
                grvVT.Columns["VAT_TU"].Visible = false;
            }
            catch { }
            
        }
        private void chkVT_CheckedChanged(object sender, EventArgs e)
        {
            grvVT.CloseEditor();
            grvVT.UpdateCurrentRow();
            for (int i = 0; i < dtVTu.Rows.Count; i++)
            {

                if (dtVTu.Rows[i]["MS_PT"] == grvVT.GetDataRow(grvVT.FocusedRowHandle)["MS_PT"])
                {
                    if (Convert.ToBoolean(grvVT.GetDataRow(grvVT.FocusedRowHandle)["CHON"]))
                    {
                        dtVTu.Rows[i]["CHON"] = true;
                    }
                    else
                    {
                        dtVTu.Rows[i]["CHON"] = false;
                    }
                
                }
            
            }
            dtVTu.AcceptChanges();
        }
        private void LocVatTu()
        {
            try
            {
                DataTable dtSource = (grdQG.DataSource as DataTable).Copy();
                string DKKho = "";
                string DKQG = "";

                foreach (DataRow dr in dtSource.Rows)
                {
                    if (Convert.ToBoolean(dr["CHON"].ToString()) == true)
                    {
                        string MsQG = dr["MA_QG"].ToString();// row.Cells["MA_QG"].Value.ToString();
                        if (DKQG == null || DKQG == "")
                        {
                            DKQG = " QUOCGIA='" + MsQG + "'";
                        }
                        else
                        {
                            DKQG = DKQG + " or QUOCGIA='" + MsQG + "'";
                        }

                    }

                }

                dtSource = new DataTable();
                dtSource = (grdKho.DataSource as DataTable).Copy();

                foreach (DataRow dr in dtSource.Rows)
                {
                    if (Convert.ToBoolean(dr["CHON"].ToString()) == true)
                    {
                        int MsKho = Convert.ToInt32(dr["MS_KHO"].ToString());
                        if (DKKho == null || DKKho == "")
                        {
                            DKKho = " MS_KHO = " + MsKho;
                        }
                        else
                        {
                            DKKho = DKKho + " or MS_KHO = " + MsKho;
                        }

                    }

                }
                string LVT="";
                if (cmbLVT.EditValue.ToString() != "-1") LVT = " VAT_TU = " + cmbLVT.EditValue.ToString();

                string VT = "";
                try
                {
                    if (!string.IsNullOrEmpty(txtTimVT.EditValue.ToString().Trim())) VT = " MS_PT LIKE '%" + txtTimVT.EditValue.ToString() + "%' ";
                }
                catch { }

                if (DKKho == "") DKKho = " 1 = 1";
                if (DKQG == "") DKQG = " 1 = 1";
                if (LVT == "") LVT = " 1 = 1";
                if (VT == "") VT = " 1 = 1";
                
                dtSource = new DataTable();
                dtSource = dtVTu.Copy();

                dtVTu.DefaultView.RowFilter = " ( " + DKQG + ") AND (" + DKKho + " ) AND (" + LVT + " ) AND (" + VT + " ) ";
 
                dtSource.DefaultView.RowFilter = " ( " + DKQG + ") AND (" + DKKho + " ) AND (" + LVT + " ) AND (" + VT + " ) " ;
                grdVT.DataSource = dtSource.DefaultView.ToTable();
            }
            catch { }

        }
        private void CapNhap(Boolean Chon , DevExpress.XtraGrid.Views.Grid.GridView gView, string CotChon)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                for (int i = 0; i < gView.RowCount; i++)
                {
                    gView.GetDataRow(i)[CotChon] = Chon;
                }
            }
            catch { }
            this.Cursor = Cursors.Default;
        }
        private void frmrptMONTHLY_CONSUMPTION_INPUT_LIST_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            datTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Year);
            datDNgay.DateTime = DateTime.Now;
            TaoLoaiVT();
            TaoQuocGia();
            TaoKho();
            TaoVatTu();
            this.Cursor = Cursors.Default;
        }

        private void btnChonhetQG_Click(object sender, EventArgs e)
        {
            CapNhap(true, grvQG, "CHON");
            LocVatTu();
        }

        private void btnBochonQG_Click(object sender, EventArgs e)
        {
            CapNhap(false, grvQG, "CHON");
            LocVatTu();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            CapNhap(true, grvKho, "CHON");
            LocVatTu();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            CapNhap(false, grvKho, "CHON");
            LocVatTu();
        }

        private void btnChonhetVT_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CapNhap(true, grvVT, "CHON");
            foreach (DataRowView row in dtVTu.DefaultView)
            {
                row["CHON"] = true;
            }
            dtVTu.AcceptChanges();
            this.Cursor = Cursors.Default;
        }

        private void btnBochonVT_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CapNhap(false, grvVT, "CHON");
            foreach (DataRowView row in dtVTu.DefaultView)
            {
                row["CHON"] = false;
            }
            dtVTu.AcceptChanges();
            this.Cursor = Cursors.Default ;
        }
        private Boolean KiemChon(DevExpress.XtraGrid.GridControl grd, string CotChon)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = (grd.DataSource as DataTable).Copy();
            dtTmp.DefaultView.RowFilter = "CHON = 1 ";
            if (dtTmp.DefaultView.ToTable().Rows.Count == 0)
                return false;


            return true;
        }
         
        private void btnThuchien_Click(object sender, EventArgs e)
        {
            if (!KiemChon(grdQG, "CHON"))
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptMONTHLY_CONSUMPTION_INPUT_LIST", "KhongChonQuocGia",
                    Commons.Modules.TypeLanguage));
                return;
            }

            if (!KiemChon(grdKho, "CHON"))
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptMONTHLY_CONSUMPTION_INPUT_LIST", "KhongChonKho",
                    Commons.Modules.TypeLanguage));
                return;
            }

            if (!KiemChon(grdVT, "CHON"))
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptMONTHLY_CONSUMPTION_INPUT_LIST", "KhongChonVatTu",
                    Commons.Modules.TypeLanguage));
                return;
            }


            System.Data.DataTable _table = new System.Data.DataTable();
            _table = List_Table();
            Validate();
            if (_table.Rows.Count ==0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptMONTHLY_CONSUMPTION_INPUT_LIST", "KhongCoDuLieuIn",
                    Commons.Modules.TypeLanguage));
                return;
            }
            frmReportViewer_Y obj = new frmReportViewer_Y();
            obj._TableSource = _table;
            obj.tungay = datTNgay.DateTime;
            obj.denngay = datDNgay.DateTime;
            obj.loaiVt = cmbLVT.EditValue.ToString();
            
            string tenqg1;

            tenqg1 = "";
            for (int i = 0; i < grvQG.RowCount; i++)
            {
                tenqg1 = tenqg1 + " " + grvQG.GetDataRow(i)["TEN_QG"];
            }            

            obj.tenqg = tenqg1;
            obj.curr = rdVND.Checked ? "VNĐ" : "USD";
            string groupColumn = "";
            string amount = "";
            string qty = "";
            string unit = "";
            foreach (DataColumn column in obj._TableSource.Columns)
            {
                string colName = column.ColumnName;
                switch (colName)
                {
                    case "No":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "No", Commons.Modules.TypeLanguage);
                        break;
                    case "SO_DON_DAT_HANG":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "PoNo", Commons.Modules.TypeLanguage);
                        break;
                    case "SO_DE_XUAT":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "RequestNo", Commons.Modules.TypeLanguage);
                        break;
                    case "MS_PT":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "MaterialCode", Commons.Modules.TypeLanguage);
                        break;
                    case "TEN_PT":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "MaterialName", Commons.Modules.TypeLanguage);
                        break;
                    case "QUY_CACH":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "Spec", Commons.Modules.TypeLanguage);
                        break;
                    case "SL_THUC_NHAP":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "Qality", Commons.Modules.TypeLanguage);
                        qty = column.ColumnName;
                        break;
                    case "DVT":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "Unit", Commons.Modules.TypeLanguage);
                        break;
                    case "Unit":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "UPrice", Commons.Modules.TypeLanguage);
                        unit = column.ColumnName;
                        break;
                    case "UPrice":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "Amount", Commons.Modules.TypeLanguage);
                        amount = column.ColumnName;
                        break;
                    case "TEN_CONG_TY":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "Vendor", Commons.Modules.TypeLanguage);
                        break;
                    case "QUOCGIA":

                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "Country", Commons.Modules.TypeLanguage);
                        groupColumn = column.ColumnName;
                        break;
                    case "MS_DH_NHAP_PT":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage);
                        break;
                    case "NGAY":
                        column.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMONTHLY_CONSUMPTION_INPUT_LIST", "NGAY", Commons.Modules.TypeLanguage);
                        break;
                }
            }
            obj.ecomaintGrid1.DataSource = obj._TableSource;
            obj.gridView1.PopulateColumns();
            obj.ecomaintGrid1.ExpressionGroupBy(obj.gridView1, groupColumn);

            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, amount);
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, unit);
            obj.ecomaintGrid1.ExpressionSum(obj.gridView1, qty);
            obj.ShowDialog();
            //LocVatTu();
        }

        private System.Data.DataTable List_Table()
        {
            DateTime tungay;
            DateTime denngay;
            string maqg = "", MsKho = "", tenqg = "", TenKho = "", tenqg1;
            string mvt = "<ROOT>";

            tungay = datTNgay.DateTime;
            denngay = datDNgay.DateTime;
            DataTable dtTmp = new DataTable();
            DataTable dtData = new DataTable();

            dtTmp = (grdVT.DataSource as DataTable).Copy(); ;
            dtTmp.DefaultView.RowFilter = "CHON = 1 " ;
            dtTmp = dtTmp.DefaultView.ToTable();

            foreach (DataRow r in dtTmp.Rows)
            {
                try
                {

                    if (bool.Parse(r["CHON"].ToString()) == true)
                    {

                        if (mvt == "<ROOT>")
                            mvt += "<PHUTUNG id=\"" + r["MS_PT"].ToString() + "\"/>";
                        else
                            mvt += "<PHUTUNG id=\"" + r["MS_PT"].ToString() + "\"/>";
                    }
                }
                catch { }
            }
            mvt += "</ROOT>";
            dtData.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "Getrpt_MonthlyConsumptionInputList", tungay, denngay, 
                cmbLVT.EditValue, mvt, "", Commons.Modules.TypeLanguage, (rdVND.Checked) ? "1" : "0"));

            return dtData;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void cmbLVT_EditValueChanged(object sender, EventArgs e)
        {
            CapNhap(false, grvQG, "CHON");
            CapNhap(false, grvKho, "CHON");
            CapNhap(false, grvVT, "CHON");

            for(int i = 0;i<dtVTu.Rows.Count ;i++)
            {
                dtVTu.Rows[i]["CHON"] = false;
            }
            dtVTu.AcceptChanges();
            
            LocVatTu();
        }

        private void txtTimVT_EditValueChanged(object sender, EventArgs e)
        {
            LocVatTu();
        }

    }
}
