using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
namespace ReportHuda.General
{
    public partial class frmMaterialStatistical : DevExpress.XtraEditors.XtraForm
    {
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
        private bool isFirst = false;
        public frmMaterialStatistical()
        {
            InitializeComponent();
        }
        public string ms_thiet_bi = "CLF250-01"; // khi lam thuc te nho truyen ms thiet bi vao
        private void PrepareData()
        {
            if (string.IsNullOrEmpty(ms_thiet_bi))
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaCoThietBi", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtMS_May.Text = ms_thiet_bi;
            System.Data.SqlClient.SqlDataReader reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_MAY_PTB_CV_TH", ms_thiet_bi, Commons.Modules.TypeLanguage);
            reader.Read();
            txtTen_May.Text = reader.GetString(1);
            try
            {
                txtNha_Xuong.Text = reader.GetString(4);
            }
            catch
            {
                txtNha_Xuong.Text = "";
            }
            try
            {
                txtDay_Chuyen.Text = reader.GetString(5);
            }
            catch
            {
                txtDay_Chuyen.Text = "";
            }
            try
            {
                txtThong_So.Text = reader.GetString(6);
            }
            catch { }

            string anh = "";
            try
            {
                anh = reader.GetString(7);
            }
            catch
            {
                anh = "";
            }

            if (!string.IsNullOrEmpty(anh))
            {
                imgMay.ImageLocation = anh;
            }
            reader.Close();
            #region
            repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            repositoryItemDateEdit1.EditMask = "dd/MM/yyyy";
            repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy";
            repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy";
            repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit1.LookAndFeel.SkinName = "Blue";
            repositoryItemDateEdit1.LookAndFeel.UseDefaultLookAndFeel = false;
            repositoryItemDateEdit1.Mask.EditMask = "dd/MM/yyyy";
            repositoryItemDateEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            #endregion
            #region
            repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            repositoryItemDateEdit2.EditMask = "dd/MM/yyyy";
            repositoryItemDateEdit2.DisplayFormat.FormatString = "dd/MM/yyyy";
            repositoryItemDateEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit2.EditFormat.FormatString = "dd/MM/yyyy";
            repositoryItemDateEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit2.LookAndFeel.SkinName = "Blue";
            repositoryItemDateEdit2.LookAndFeel.UseDefaultLookAndFeel = false;
            repositoryItemDateEdit2.Mask.EditMask = "dd/MM/yyyy";
            repositoryItemDateEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            #endregion
            #region
            repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            repositoryItemDateEdit3.EditMask = "dd/MM/yyyy HH:mm";
            repositoryItemDateEdit3.DisplayFormat.FormatString = "dd/MM/yyyy";
            repositoryItemDateEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit3.EditFormat.FormatString = "dd/MM/yyyy";
            repositoryItemDateEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit3.LookAndFeel.SkinName = "Blue";
            repositoryItemDateEdit3.LookAndFeel.UseDefaultLookAndFeel = false;
            repositoryItemDateEdit3.Mask.EditMask = "dd/MM/yyyy";
            repositoryItemDateEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            #endregion
            txtTu_Ngay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            txtDen_Ngay.DateTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        }
        private void LoadData()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DS_TKVT_THEO_MAY", ms_thiet_bi, txtTu_Ngay.DateTime, txtDen_Ngay.DateTime));
                foreach (DataColumn col in _table.Columns)
                {
                    col.ReadOnly = false;
                    col.AllowDBNull = true;
                }
                gdList.DataSource = _table;
                gvList.Columns["ID"].Visible = false;
                gvList.Columns["THANH_TIEN"].OptionsColumn.AllowEdit = false;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvList.Columns)
                {
                    col.AppearanceHeader.Options.UseTextOptions = true;
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    col.Width = 250;
                    col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, col.FieldName, Commons.Modules.TypeLanguage);
                    switch (col.FieldName)
                    {
                        case "NGAY":
                            col.ColumnEdit = repositoryItemDateEdit1;
                            col.Width = 100;
                            break;
                        case "NGAY_HH_BH":
                            col.ColumnEdit = repositoryItemDateEdit2;
                            col.Width = 100;
                            break;
                        case "NGAY_THAY_KE":
                            col.ColumnEdit = repositoryItemDateEdit3;
                            col.Width = 100;
                            break;
                        case "SO_LUONG":
                        case "GIA":
                        case "THANH_TIEN":
                            col.Width = 100;
                            break;
                    }
                }
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvList.Columns)
                {
                    col.OptionsColumn.AllowEdit = false;
                    if (col.FieldName == "HINH")
                        col.OptionsColumn.AllowEdit = true;
                }
                txtTongTien.Text = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_TONG_TIEN_THEO_MAY", txtMS_May.Text, txtTu_Ngay.DateTime, txtDen_Ngay.DateTime));
                //.ToString("#,##0.00")

                try
                {
                    double value;
                    value = double.Parse(txtTongTien.Text);
                    txtTongTien.Text = value.ToString("#,##0.00");
                }
                catch { txtTongTien.Text = "0"; }

            }
            catch { }
        }
        private void frmMaterialStatistical_Load(object sender, EventArgs e)
        {
            try
            {
                PrepareData();
                LoadData();
                btnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, btnThem.Name, Commons.Modules.TypeLanguage);
                btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, btnGhi.Name, Commons.Modules.TypeLanguage);
                btnKhongGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, btnKhongGhi.Name, Commons.Modules.TypeLanguage);
                btnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, btnXoa.Name, Commons.Modules.TypeLanguage);
                btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, btnThoat.Name, Commons.Modules.TypeLanguage);
                btnXuatExcel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, btnXuatExcel.Name, Commons.Modules.TypeLanguage);
                isFirst = true;
                mnu_New.Items.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "AddNew", Commons.Modules.TypeLanguage));
                gdList.ContextMenuStrip = mnu_New;
                Commons.Modules.ObjSystems.ThayDoiNN(this);
            }
            catch
            {
                
               MessageBox.Show("Vui lòng truyền mã số máy vào", "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTu_Ngay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if (txtTu_Ngay.DateTime <= txtDen_Ngay.DateTime)
                        LoadData();
                }
            }
            catch { }
        }

        private void txtDen_Ngay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if (txtTu_Ngay.DateTime <= txtDen_Ngay.DateTime)
                        LoadData();
                }
            }
            catch { }
        }

        private void txtTu_Ngay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue > txtDen_Ngay.DateTime)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                }
            }
            catch { }
        }

        private void txtDen_Ngay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if ((DateTime)e.NewValue < txtTu_Ngay.DateTime)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }

                }
            }
            catch { }
        }
        private void EnableControl(bool value)
        {
            btnGhi.Visible = value;
            btnKhongGhi.Visible = value;

            btnThem.Visible = !value;
            btnXuatExcel.Visible = !value;
            btnXoa.Visible = !value;
            btnThoat.Visible = !value;

            txtTu_Ngay.Enabled = !value;
            txtDen_Ngay.Enabled = !value;


            
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvList.Columns)
                col.OptionsColumn.AllowEdit = true;
            //gvList.OptionsBehavior.Editable = value;
            mnu_New.Enabled = value;

        }
        int count = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            EnableControl(true);
            count = gvList.RowCount;
            gvList.AddNewRow();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {

            DateTime ngay = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime? ngay_hh_bh = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime? ngay_thay_ke = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            decimal sl = 0;
            decimal gia = 0;
            string hinh = "";
            string ten_vt, nha_cc, dia_chi;
            long id = 0;
            string s = "";
            hinh = Commons.Modules.ObjSystems.CapnhatTL(false, txtMS_May.Text);
            SqlTransaction tran;
            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            tran = con.BeginTransaction();
            for (int i = 0; i < gvList.RowCount; i++)
            {
                DataRow dr = gvList.GetDataRow(i);
                if (dr != null)
                {
                    #region Prepare data
                    if (!string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["NGAY"]))
                       || !string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["TEN_VT"]))
                       || !string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["NHA_CC"]))
                       || !string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["DIA_CHI"]))
                       || !string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["NGAY_HH_BH"]))
                       || !string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["NGAY_THAY_KE"]))
                       || !string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["SO_LUONG"]))
                       || !string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["GIA"]))
                       || !string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["HINH"]))
                       )
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["NGAY"])))
                            ngay = Convert.ToDateTime(gvList.GetDataRow(i)["NGAY"]);
                        else
                        {
                            gvList.FocusedRowHandle = i;
                            gvList.FocusedColumn = gvList.Columns["NGAY"];
                            tran.Rollback();
                            con.Close();
                            return;
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["TEN_VT"])))
                            ten_vt = Convert.ToString(gvList.GetDataRow(i)["TEN_VT"]);
                        else
                        {
                            gvList.FocusedRowHandle = i;
                            gvList.FocusedColumn = gvList.Columns["TEN_VT"];
                            tran.Rollback();
                            con.Close();
                            return;
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["NGAY_HH_BH"])))
                            ngay_hh_bh = Convert.ToDateTime(gvList.GetDataRow(i)["NGAY_HH_BH"]);
                        else
                            ngay_hh_bh = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["NGAY_THAY_KE"])))
                            ngay_thay_ke = Convert.ToDateTime(gvList.GetDataRow(i)["NGAY_THAY_KE"]);
                        else
                            ngay_thay_ke = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["SO_LUONG"])))
                            sl = Convert.ToDecimal(gvList.GetDataRow(i)["SO_LUONG"]);
                        else
                        {
                            gvList.FocusedRowHandle = i;
                            gvList.FocusedColumn = gvList.Columns["SO_LUONG"];
                            tran.Rollback();
                            con.Close();
                            return;
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["GIA"])))
                            gia = Convert.ToDecimal(gvList.GetDataRow(i)["GIA"]);
                        else
                        {
                            gvList.FocusedRowHandle = i;
                            gvList.FocusedColumn = gvList.Columns["GIA"];
                            tran.Rollback();
                            con.Close();
                            return;
                        }
                        nha_cc = Convert.ToString(gvList.GetDataRow(i)["NHA_CC"]);
                        dia_chi = Convert.ToString(gvList.GetDataRow(i)["DIA_CHI"]);
                        try
                        {
                            id = Convert.ToInt64(gvList.GetDataRow(i)["ID"]);
                        }
                        catch
                        {

                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(gvList.GetDataRow(i)["HINH"])))
                            s = hinh + "/TB_" + txtMS_May.Text.Replace("/", "_") + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_"
                                + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + DateTime.Now.Millisecond + "_" + Commons.Modules.ObjSystems.LayDuoiFile(gvList.GetDataRow(i)["HINH"].ToString());

                    #endregion
                        if (i < count)
                        {
                            try
                            {
                                SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_UPDATE_THONG_KE_VAT_TU_MAY", id, ngay, ten_vt, nha_cc, dia_chi, sl, gia, ngay_hh_bh, ngay_thay_ke, s);
                                if (!string.IsNullOrEmpty(s))
                                    Commons.Modules.ObjSystems.LuuDuongDan(gvList.GetDataRow(i)["HINH"].ToString(), s);
                            }
                            catch
                            {
                                tran.Rollback();
                                con.Close();
                            }

                        }
                        else
                        {
                            try
                            {
                                SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_INSERT_THONG_KE_VAT_TU_MAY", txtMS_May.Text, ngay, ten_vt, nha_cc, dia_chi, sl, gia, ngay_hh_bh, ngay_thay_ke, s);
                                if (!string.IsNullOrEmpty(s))
                                    Commons.Modules.ObjSystems.LuuDuongDan(gvList.GetDataRow(i)["HINH"].ToString(), s);
                            }
                            catch
                            {
                                tran.Rollback();
                                con.Close();
                            }

                        }

                    }
                }
            }
            try
            {
                tran.Commit();
                con.Close();
            }
            catch
            { }
            EnableControl(false);
            LoadData();
        }
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            LoadData();
        }
        private void gvList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string field = e.Column.FieldName;
            gvList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            decimal tong = txtTongTien.Text == "" ? 0 : Convert.ToDecimal(txtTongTien.Text);
            decimal thanh_tien = 0;
            switch (field)
            {
                case "SO_LUONG":
                case "GIA":
                    if (
                        !string.IsNullOrEmpty(Convert.ToString(gvList.GetFocusedDataRow()["SO_LUONG"])) &&
                        !string.IsNullOrEmpty(Convert.ToString(gvList.GetFocusedDataRow()["GIA"]))
                      )
                    {
                        thanh_tien = Convert.ToString(gvList.GetFocusedDataRow()["THANH_TIEN"]) == "" ? 0 : Convert.ToDecimal(gvList.GetFocusedDataRow()["THANH_TIEN"]);
                        gvList.GetFocusedDataRow()["THANH_TIEN"] = Convert.ToDecimal(gvList.GetFocusedDataRow()["SO_LUONG"]) * Convert.ToDecimal(gvList.GetFocusedDataRow()["GIA"]);
                        txtTongTien.Text = Convert.ToString((tong - thanh_tien) + (Convert.ToDecimal(gvList.GetFocusedDataRow()["THANH_TIEN"])));
                    }
                    break;
            }




        }
        private void mnu_New_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(gvList.GetFocusedDataRow()["NGAY"])))
            {
                gvList.FocusedColumn = gvList.Columns["NGAY"];
                return;
            }

            if (string.IsNullOrEmpty(Convert.ToString(gvList.GetFocusedDataRow()["TEN_VT"])))
            {
                gvList.FocusedColumn = gvList.Columns["TEN_VT"];
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(gvList.GetFocusedDataRow()["SO_LUONG"])))
            {
                gvList.FocusedColumn = gvList.Columns["SO_LUONG"];
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(gvList.GetFocusedDataRow()["GIA"])))
            {
                gvList.FocusedColumn = gvList.Columns["GIA"];
                return;
            }

            if (string.IsNullOrEmpty(Convert.ToString(gvList.GetFocusedDataRow()["THANH_TIEN"])))
            {
                gvList.FocusedColumn = gvList.Columns["THANH_TIEN"];
                return;
            }
            gvList.AddNewRow();

        }

        private void gvList_ShownEditor(object sender, EventArgs e)
        {
            BaseEdit inplaceEditor;
            inplaceEditor = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).ActiveEditor;
            inplaceEditor.DoubleClick += inplaceEditor_DoubleClick;
        }
        void inplaceEditor_DoubleClick(object sender, EventArgs e)
        {
            BaseEdit editor = (BaseEdit)sender;
            DevExpress.XtraGrid.GridControl grid = (DevExpress.XtraGrid.GridControl)editor.Parent;
            Point pt = grid.PointToClient(Control.MousePosition);
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)grid.FocusedView;
            DoRowDoubleClick(view, pt);

        }
        private void DoRowDoubleClick(DevExpress.XtraGrid.Views.Grid.GridView view, Point pt)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(pt);
            string s = info.Column.FieldName;
            if (s == "HINH")
            {
                if (!btnThem.Enabled)
                {
                    OpenFileDialog obj = new OpenFileDialog();
                    DialogResult res = obj.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        gvList.GetFocusedDataRow()["HINH"] = obj.FileName;
                        gvList.FocusedColumn = gvList.Columns["NGAY_THAY_KE"];
                    }
                }
                else
                {
                    frmViewFullImage obj = new frmViewFullImage();
                    obj.img1.ImageLocation =Convert.ToString(gvList.GetFocusedDataRow()["HINH"]);
                    obj.ShowDialog();
                }
            }


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "BanCoChacXoaKhong", Commons.Modules.TypeLanguage), "VietSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_NHU_Y_DELETE_THONG_KE_VAT_TU_MAY", gvList.GetFocusedDataRow()["ID"]);
                LoadData();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (gvList.RowCount <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "khongcodulieudein", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog f = new SaveFileDialog();
            string path = "";
            f.Filter = "Excel file (*.xls)|*.xls";
            try
            {
                DialogResult res = f.ShowDialog();
                if (res.Equals(DialogResult.OK))
                {
                    path = f.FileName;

                }
                else
                    return;
            }
            catch
            {

            }
            


            this.Cursor = Cursors.WaitCursor;
            gdList.ExportToXls(path);
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;

            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            
            int count_column = gvList.Columns.Count-1;
            int count_row = gvList.RowCount; 
            int _row = 1;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_THONG_TIN_CHUNG", Commons.Modules.TypeLanguage));
            Excel.Range CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "L"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = dtTmp.Rows[0]["TEN_CTY"];
            _row++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "L"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "diachi", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["DIA_CHI"];
            _row++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "L"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "dienthoai", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["phone"] + "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReportBaoTri_Huda", "fax", Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0]["FAX"];
            _row++;
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "A"]);
            CurCell.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "C"], excelWorkSheet.Cells[_row, "L"]);
            CurCell.Merge(true);
            CurCell.Font.Bold = true;
            CurCell.Borders.LineStyle = 0;
            CurCell.Value2 = "Email : " + dtTmp.Rows[0]["EMAIL"];
            CurCell = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, "A"], excelWorkSheet.Cells[_row, "B"]);
            //CurCell.MergeCells = true;
            CurCell.Borders.LineStyle = 0;

            ReportHuda.Class.PrintExcel.GetImage((byte[])dtTmp.Rows[0]["LOGO"]);
            excelWorkSheet.Shapes.AddPicture(Application.StartupPath + "\\logo.bmp", Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, 0, 0, 180, 50);
            System.IO.File.Delete(Application.StartupPath + "\\logo.bmp");
            _row++;


            Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range title1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            _row++;
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            title1.Merge(true);
            title1.Font.Bold = true;
            title1.Font.Size = 14;
            title1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            title1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            title1.Borders.LineStyle = 0;
            excelWorkSheet.Cells[_row, 1] = lblTitle.Text;
            _row++;


            Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, 1], excelWorkSheet.Cells[_row, count_column]);
            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "B"], excelWorkSheet.Cells[_row, "C"]);
            title.Merge(true);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            title.Borders.LineStyle = 0;
            title.WrapText = true;
            excelWorkSheet.Cells[_row, "B"] = lblMs_May.Text + " : " + txtMS_May.Text;
            title.Font.Size = 10;
            title.Borders.LineStyle = 0;

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "E"], excelWorkSheet.Cells[_row, "J"]);
            title.Merge(true);
            title.WrapText = true;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[_row, "E"] = lblTen_May.Text + " : " + txtTen_May.Text;
            title.Font.Size = 10;
            _row++;

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "B"], excelWorkSheet.Cells[_row, "C"]);
            title.Merge(true);
            title.WrapText = true;
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[_row, "B"] = lblThong_So_Chinh.Text + " : " + txtThong_So.Text;


            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "E"], excelWorkSheet.Cells[_row, "J"]);
            title.Merge(true);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            title.WrapText = true; 
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[_row, "E"] = lblNha_Xuong.Text + " : " + txtNha_Xuong.Text;
            _row++;

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "B"], excelWorkSheet.Cells[_row, "C"]);
            title.Merge(true);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            title.WrapText = true;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[_row, "B"] = lblDay_Chuyen.Text + " : " + txtDay_Chuyen.Text;


            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "E"], excelWorkSheet.Cells[_row, "J"]);
            title.Merge(true);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            title.WrapText = true;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[_row, "E"] = lblTong_Tien.Text + " : " + txtTongTien.Text;
            _row++;

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "B"], excelWorkSheet.Cells[_row, "C"]);
            title.Merge(true);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[_row, "B"] = lblTu_Ngay.Text + " : " + txtTu_Ngay.Text;


            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "E"], excelWorkSheet.Cells[_row, "J"]);
            title.Merge(true);
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            title.Borders.LineStyle = 0;
            excelWorkSheet.Cells[_row, "E"] = lblDen_Ngay.Text + " : " + txtDen_Ngay.Text;
            _row++;

 

            excelWorkSheet.Columns.AutoFit();

            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "A"], excelWorkSheet.Cells[count_row + _row, "A"]);
            title.ColumnWidth =9	;
            title.NumberFormat = "dd/MM/yyyy";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "B"], excelWorkSheet.Cells[count_row + _row, "B"]);
            title.ColumnWidth = 15	;
            title.NumberFormat = "@";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "C"], excelWorkSheet.Cells[count_row + _row, "C"]);
            title.ColumnWidth = 15;
            title.NumberFormat = "@";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "D"], excelWorkSheet.Cells[count_row + _row, "D"]);
            title.ColumnWidth = 20;
            title.NumberFormat = "@";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "E"], excelWorkSheet.Cells[count_row + _row, "E"]);
            title.NumberFormat = "#,##0";
            title.ColumnWidth = 7	;
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "F"], excelWorkSheet.Cells[count_row + _row, "F"]);
            title.ColumnWidth = 11	;
            title.NumberFormat = "#,##0.00";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "G"], excelWorkSheet.Cells[count_row + _row, "G"]);
            title.ColumnWidth = 12	;
            title.NumberFormat = "#,##0.00";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "H"], excelWorkSheet.Cells[count_row + _row, "H"]);
            title.ColumnWidth = 9	;
            title.NumberFormat = "dd/MM/yyyy";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "I"], excelWorkSheet.Cells[count_row + _row, "I"]);
            title.ColumnWidth = 9;
            title.NumberFormat = "dd/MM/yyyy";
            title.WrapText = true;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row + 1, "J"], excelWorkSheet.Cells[count_row + _row, "J"]);
            title.ColumnWidth = 26;
            title.NumberFormat = "@";
            title.WrapText = true;
            excelWorkSheet.Rows.AutoFit();

            a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[_row, "A"], excelWorkSheet.Cells[_row, "B"]);
            title.RowHeight = 9;
            title = excelWorkSheet.get_Range(excelWorkSheet.Cells[5, "A"], excelWorkSheet.Cells[5, "B"]);
            title.RowHeight = 9;


            excelApplication.ActiveWindow.DisplayGridlines = true;
            //excelWorkSheet.PageSetup.PrintTitleRows = "$10:$10";
            excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            excelWorkSheet.PageSetup.LeftMargin = 30;
            excelWorkSheet.PageSetup.RightMargin = 30;
            excelWorkSheet.PageSetup.BottomMargin = 30;
            excelWorkSheet.PageSetup.TopMargin = 30;
            excelWorkSheet.PageSetup.FooterMargin = 50;
            excelWorkSheet.PageSetup.HeaderMargin = 50;
            //excelWorkSheet.PageSetup.Zoom = 70;
            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
            
        }

        private void imgMay_DoubleClick(object sender, EventArgs e)
        {
            frmViewFullImage obj = new frmViewFullImage();
            obj.img1.ImageLocation = imgMay.ImageLocation;
            obj.ShowDialog();
        }



    }
}