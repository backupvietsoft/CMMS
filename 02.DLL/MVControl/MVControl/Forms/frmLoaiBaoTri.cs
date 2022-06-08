using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System.Drawing;


namespace MVControl
{
    public partial class frmBaoTri : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoTri()
        {
            InitializeComponent();
        }

        private void frmLoaiBaoTri_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnStyles[0].Width = 0;
            tableLayoutPanel1.ColumnStyles[tableLayoutPanel1.ColumnCount - 1].Width = 0;

            Commons.Modules.SQLString = "0Load";
            LoadHinhThucBT(-1);
            Commons.Modules.SQLString = "";
            LoadLoaiBaoTri(-1);
            grvHinhThucBT_FocusedRowChanged(null, null);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            btQH.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btQH", Commons.Modules.TypeLanguage);

            if (Commons.Modules.PermisString.ToUpper() == "Read only".ToUpper())
                EnableButton(false);
        }

        private void EnableButton(Boolean bEnable)
        {
            btnThemSua.Visible = bEnable;
            btnXoa.Visible = bEnable;
            btQH.Visible = bEnable;
            btnColor.Visible = bEnable;

        }
        private void LoadHinhThucBT(int iMS_HT_BT)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHINH_THUC_BAO_TRIs"));

                System.Data.DataColumn newColumn = new System.Data.DataColumn("MOI_CU", typeof(System.Boolean));
                newColumn.DefaultValue = false;
                dtTmp.Columns.Add(newColumn);
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["MS_HT_BT"] };
                
                dtTmp.Columns["TEN_HT_BT"].AllowDBNull = true;
                dtTmp.Columns["TEN_HT_BT"].ReadOnly = false;
                dtTmp.Columns["PHONG_NGUA"].ReadOnly = false;
                dtTmp.Columns["PHONG_NGUA"].AllowDBNull = true;

                if (grdHinhThucBT.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdHinhThucBT, grvHinhThucBT, dtTmp, false, true, true, true, true, this.Name);
                    grvHinhThucBT.Columns["MS_HT_BT"].Visible = false;
                    grvHinhThucBT.Columns["MOI_CU"].Visible = false;
                    grvHinhThucBT.Columns["PHONG_NGUA"].Width = 100;
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdHinhThucBT, grvHinhThucBT, dtTmp, false, false, true, false, true, this.Name);
                }
                if (iMS_HT_BT != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(iMS_HT_BT));
                    grvHinhThucBT.FocusedRowHandle = grvHinhThucBT.GetRowHandle(index);
                }
                if (dtTmp.Rows.Count == 0)
                {
                    LoadLoaiBaoTri(-1);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Commons.Modules.SQLString != "0Load") LoadLoaiBaoTri(-1);
        }

        private void LoadLoaiBaoTri(int iMS_LOAI_BT)
        {
            try
            {
                grdLoaiBT.DataSource = null;
                if (grdHinhThucBT.DataSource == null) return;
                if (Commons.Modules.SQLString == "0Load") return;
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GetLOAI_BAO_TRI", -1));
                System.Data.DataColumn newColumn = new System.Data.DataColumn("MOI_CU", typeof(System.Boolean));
                newColumn.DefaultValue = false;
                dtTmp.Columns.Add(newColumn);

                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["MS_LOAI_BT"] };
                dtTmp.Columns["MS_LOAI_CV"].ReadOnly = false;
                dtTmp.Columns["MS_LOAI_CV"].AllowDBNull = true;

                dtTmp.Columns["HU_HONG"].ReadOnly = false;
                dtTmp.Columns["HU_HONG"].AllowDBNull = true;

                dtTmp.Columns["R"].ReadOnly = false;
                dtTmp.Columns["R"].AllowDBNull = true;
                dtTmp.Columns["G"].ReadOnly = false;
                dtTmp.Columns["G"].AllowDBNull = true;
                dtTmp.Columns["B"].ReadOnly = false;
                dtTmp.Columns["B"].AllowDBNull = true;

                if (grdLoaiBT.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdLoaiBT, grvLoaiBT, dtTmp, false, true, true, true, true, this.Name);
                    grvLoaiBT.Columns["MS_HT_BT"].Visible = false;
                    grvLoaiBT.Columns["MS_LOAI_BT"].Visible = false;
                    grvLoaiBT.Columns["MOI_CU"].Visible = false;


                    grvLoaiBT.Columns["R"].Visible = false;
                    grvLoaiBT.Columns["G"].Visible = false;
                    grvLoaiBT.Columns["B"].Visible = false;

                    grvLoaiBT.Columns["MS_LOAI_CV"].Width = 80;
                    grvLoaiBT.Columns["THU_TU"].Width = 50;
                    grvLoaiBT.Columns["HU_HONG"].Width = 50;
                    grvLoaiBT.Columns["MAU"].Width = 50;
                    grvLoaiBT.Columns["MAU"].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdLoaiBT, grvLoaiBT, dtTmp, false, false, true, false, true, this.Name);
                }

                DataTable dLCV = new DataTable();
                dLCV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_LOAI_CV,TEN_LOAI_CV FROM LOAI_CONG_VIEC UNION SELECT -99,'ALL' ORDER BY TEN_LOAI_CV"));

                RepositoryItemLookUpEdit cboLCV = new RepositoryItemLookUpEdit();
                cboLCV.Name = "LOAI_CV";
                cboLCV.DataSource = dLCV;
                cboLCV.NullText = "";
                cboLCV.PopulateColumns();
                cboLCV.ValueMember = "MS_LOAI_CV";
                cboLCV.DisplayMember = "TEN_LOAI_CV";
                cboLCV.Columns["MS_LOAI_CV"].Visible = false;


                cboLCV.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cboLCV.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cboLCV.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                cboLCV.ShowHeader = false;
            
                grvLoaiBT.Columns["MS_LOAI_CV"].ColumnEdit = cboLCV;
                
                
                if (grvHinhThucBT.GetFocusedRowCellValue("PHONG_NGUA").ToString().ToUpper() == "TRUE")
                {
                    grvLoaiBT.Columns["MAU"].Visible = true;
                    grvLoaiBT.Columns["HU_HONG"].Visible = false;
                    btQH.Visible = true;
                }
                else
                {
                    grvLoaiBT.Columns["MAU"].Visible = false;
                    grvLoaiBT.Columns["HU_HONG"].Visible = true;
                    btQH.Visible = false;
                }

                

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void grvHinhThucBT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grdLoaiBT.DataSource == null) return;
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = new DataTable();
                dtTmp = (DataTable)grdLoaiBT.DataSource;
                if (string.IsNullOrEmpty(grvHinhThucBT.GetFocusedRowCellValue("MS_HT_BT").ToString()))
                    dtTmp.DefaultView.RowFilter = " MS_HT_BT = -1" ;
                else
                    dtTmp.DefaultView.RowFilter = " MS_HT_BT = " + grvHinhThucBT.GetFocusedRowCellValue("MS_HT_BT").ToString();

                dtTmp = dtTmp.DefaultView.ToTable();
            }
            catch { dtTmp.DefaultView.RowFilter = " MS_HT_BT = -1"; }

            try
            {
                if (grvHinhThucBT.GetFocusedRowCellValue("PHONG_NGUA").ToString().ToUpper() == "TRUE")
                {
                    grvLoaiBT.Columns["MAU"].Visible = true;
                    grvLoaiBT.Columns["HU_HONG"].Visible = false;
                    if (!btnGhi.Visible) btQH.Visible = true;
                }
                else
                {
                    grvLoaiBT.Columns["MAU"].Visible = false;
                    grvLoaiBT.Columns["HU_HONG"].Visible = true;
                    if (!btnGhi.Visible) btQH.Visible = false;
                }
            }
            catch { }
            if (btnTroVe.Visible) btQH.Visible = false;

        }

        private void grvLoaiBT_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            
            GridView View = sender as GridView;
            try
            {
                if (e.Column.FieldName == "MAU")
                {
                    if (string.IsNullOrEmpty(View.GetRowCellValue(e.RowHandle, "R").ToString()) && string.IsNullOrEmpty(View.GetRowCellValue(e.RowHandle, "G").ToString()) && string.IsNullOrEmpty(View.GetRowCellValue(e.RowHandle, "B").ToString())) return;

                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(
                        Convert.ToInt32(Convert.ToByte(View.GetRowCellValue(e.RowHandle, "R").ToString())),
                        Convert.ToInt32(Convert.ToByte(View.GetRowCellValue(e.RowHandle, "G").ToString())),
                        Convert.ToInt32(Convert.ToByte(View.GetRowCellValue(e.RowHandle, "B").ToString()))
                        );

                }
            }
            catch { }
        }

        public void bThemSua(Boolean bTSua)
        {
            btnColor.Visible = !btnColor.Visible;
            btnGhi.Visible = !btnGhi.Visible;
            btnKhongghi.Visible = !btnKhongghi.Visible;
            btQH.Visible = false;

            btnThemSua.Visible = !btnThemSua.Visible;
            btnXoa.Visible = !btnXoa.Visible;
            btnThoat.Visible = !btnThoat.Visible;

            if (bTSua)
            {
                grvLoaiBT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                grvLoaiBT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                grvLoaiBT.OptionsBehavior.Editable = true;

                grvHinhThucBT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                grvHinhThucBT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                grvHinhThucBT.OptionsBehavior.Editable = true;

            }
            else
            {
                grvLoaiBT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                grvLoaiBT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                grvLoaiBT.OptionsBehavior.Editable = false;

                grvHinhThucBT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                grvHinhThucBT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                grvHinhThucBT.OptionsBehavior.Editable = false;
            }
            try
            {
                if (btnGhi.Visible == true) return;
                if (grdHinhThucBT.DataSource == null) return;
                if (grvHinhThucBT.GetFocusedRowCellValue("PHONG_NGUA").ToString().ToUpper() == "TRUE")
                {
                    grvLoaiBT.Columns["MAU"].Visible = true;
                    grvLoaiBT.Columns["HU_HONG"].Visible = false;
                    if (!btnGhi.Visible) btQH.Visible = true;
                }
                else
                {
                    grvLoaiBT.Columns["MAU"].Visible = false;
                    grvLoaiBT.Columns["HU_HONG"].Visible = true;

                    if (!btnGhi.Visible) btQH.Visible = false;
                }
            }catch { }
        }

        public void AnXoa(Boolean AnHien)
        {
            btnXoa.Visible = AnHien;
            BtnXoaNhomBT.Visible = AnHien;
            BtnXoaLoai.Visible = AnHien;
            btnTroVe.Visible = AnHien;

            btnThemSua.Visible = !AnHien;
            btnXoa.Visible = !AnHien;
            btnThoat.Visible = !AnHien;
            btQH.Visible = false;
            if(!AnHien)
            {
                try
                {
                    if (grvHinhThucBT.GetFocusedRowCellValue("PHONG_NGUA").ToString().ToUpper() == "TRUE")
                    {
                        grvLoaiBT.Columns["MAU"].Visible = true;
                        grvLoaiBT.Columns["HU_HONG"].Visible = false;
                        if (!btnGhi.Visible) btQH.Visible = true;
                    }
                    else
                    {
                        grvLoaiBT.Columns["MAU"].Visible = false;
                        grvLoaiBT.Columns["HU_HONG"].Visible = true;
                        if (!btnGhi.Visible) btQH.Visible = false;
                    }
                }
                catch { }

            }
            if (btnTroVe.Visible) btQH.Visible = false;
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            bThemSua(true);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            DataTable dtHTBT = new DataTable();
            Boolean iCheck = false;
            Int32 iMS_HT_BT = -1;
            Int32 iMS_LOAI_BT = -1;
            String sSql = "";
            dtHTBT = (DataTable)grdHinhThucBT.DataSource;


            DataTable dtLoaiBTri = new DataTable();
            dtLoaiBTri = (DataTable)grdLoaiBT.DataSource;
            string sBTam = "LBT_LUU" + Commons.Modules.UserName;

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtLoaiBTri, "");
            try
            {
                foreach (DataRow drRow in dtHTBT.Rows)
                {
                    iCheck = false;
                    try
                    {
                        if (Convert.ToBoolean(drRow["PHONG_NGUA"].ToString()))
                            iCheck = true;
                    }
                    catch { }

                    iMS_HT_BT = -1;
                    iMS_HT_BT = int.Parse(drRow["MS_HT_BT"].ToString());

                   
                    //Commons du lieu thi update
                    if (!Convert.ToBoolean(drRow["MOI_CU"].ToString()))
                    {
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateHINH_THUC_BAO_TRI", iMS_HT_BT, drRow["TEN_HT_BT"].ToString(), iCheck);
                        try
                        {//Luu du lieu Log
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_HINH_THUC_BAO_TRI_LOG", iMS_HT_BT, this.Name, Commons.Modules.UserName, 2);
                        }
                        catch { }
                    }
                    //Khong co thi Insert
                    else
                    {
                        iMS_HT_BT = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddHINH_THUC_BAO_TRI", drRow["TEN_HT_BT"].ToString(), iCheck));
                        try
                        {//Luu du lieu Log
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_HINH_THUC_BAO_TRI_LOG", iMS_HT_BT, this.Name, Commons.Modules.UserName, 1);
                        }
                        catch { }
                    }

                    DataTable dtLBT = new DataTable();
                    sSql = "SELECT * FROM " + sBTam + " WHERE MS_HT_BT = " + drRow["MS_HT_BT"].ToString();
                    dtLBT = new DataTable();
                    dtLBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    foreach (DataRow drRowLBT in dtLBT.Rows)
                    {
                        iCheck = false;
                        try
                        {
                            if (Convert.ToBoolean(drRowLBT["HU_HONG"].ToString()))
                                iCheck = true;
                        }
                        catch { }
                        int iTHU_TU;
                        try
                        {
                            iTHU_TU = int.Parse(drRowLBT["THU_TU"].ToString());
                        }
                        catch { iTHU_TU = -1; }


                        if (!Convert.ToBoolean(drRowLBT["MOI_CU"].ToString()))
                        {
                            iMS_LOAI_BT = Convert.ToInt32(drRowLBT["MS_LOAI_BT"].ToString());
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateLOAI_BAO_TRI", iMS_LOAI_BT, Convert.ToInt32(drRowLBT["MS_HT_BT"].ToString()), drRowLBT["TEN_LOAI_BT"].ToString(), drRowLBT["GHI_CHU"].ToString(), iTHU_TU, iCheck);
                            try
                            {//Luu du lieu Log
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_LOAI_BAO_TRI_LOG", Convert.ToInt32(drRowLBT["MS_LOAI_BT"].ToString()), this.Name, Commons.Modules.UserName, 2);
                            }
                            catch { }
                        }
                        //Khong co thi Insert
                        else
                        {
                            iMS_LOAI_BT = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddLOAI_BAO_TRI", iMS_HT_BT, drRowLBT["TEN_LOAI_BT"].ToString(), drRowLBT["GHI_CHU"].ToString(), iTHU_TU, iCheck));
                            try
                            {//Luu du lieu Log
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_LOAI_BAO_TRI_LOG", iMS_LOAI_BT, this.Name, Commons.Modules.UserName, 1);
                            }
                            catch { }
                        }

                        int R = 0;
                        int G = 0;
                        int B = 0;
                        try
                        {
                            R = Convert.ToInt32(drRowLBT["R"].ToString()); G = Convert.ToInt32(drRowLBT["G"].ToString()); B = Convert.ToInt32(drRowLBT["B"].ToString());
                        }
                        catch { }
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_DATA_MAU", iMS_LOAI_BT, R, G, B);

                        if (drRowLBT["MS_LOAI_CV"].ToString() != "-99")
                            sSql = " UPDATE LOAI_BAO_TRI SET MS_LOAI_CV = " + drRowLBT["MS_LOAI_CV"].ToString() + " WHERE MS_LOAI_BT = " + iMS_LOAI_BT.ToString();
                        else
                            sSql = " UPDATE LOAI_BAO_TRI SET MS_LOAI_CV = NULL WHERE MS_LOAI_BT = " + iMS_LOAI_BT.ToString();
                        try
                        {
                            
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        }
                        catch { }

                    }
                }
            }
            catch
            { }
            Commons.Modules.ObjSystems.XoaTable(sBTam);
            int.TryParse(grvHinhThucBT.GetFocusedRowCellValue("MS_HT_BT").ToString(), out iMS_HT_BT);
            int.TryParse(grvLoaiBT.GetFocusedRowCellValue("MS_LOAI_BT").ToString(), out iMS_LOAI_BT);
            Commons.Modules.SQLString = "0Load";
            LoadHinhThucBT(iMS_HT_BT);
            Commons.Modules.SQLString = "";
            LoadLoaiBaoTri(iMS_LOAI_BT);
            grvHinhThucBT_FocusedRowChanged(null, null);
            bThemSua(false);
        }

        private void btnKhongghi_Click(object sender, EventArgs e)
        {
            int iMS_HT_BT, iMS_LOAI_BT;
            try
            {
                try
                {
                    int.TryParse(grvHinhThucBT.GetFocusedRowCellValue("MS_HT_BT").ToString(), out iMS_HT_BT);
                }
                catch { iMS_HT_BT = -1; }
                try
                {
                    int.TryParse(grvLoaiBT.GetFocusedRowCellValue("MS_LOAI_BT").ToString(), out iMS_LOAI_BT);
                }
                catch { iMS_LOAI_BT = -1; }

                Commons.Modules.SQLString = "0Load";
                LoadHinhThucBT(iMS_HT_BT);
                Commons.Modules.SQLString = "";
                LoadLoaiBaoTri(iMS_LOAI_BT);
                grvHinhThucBT_FocusedRowChanged(null, null);
            }
            catch { }
            bThemSua(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            AnXoa(true);
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            AnXoa(false);
        }

        private void grvHinhThucBT_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (!btnGhi.Visible) return;
                if (String.IsNullOrEmpty(grvHinhThucBT.GetFocusedRowCellValue("MS_HT_BT").ToString())) grvHinhThucBT.SetFocusedRowCellValue("MS_HT_BT", grvHinhThucBT.RowCount + 1);
                grvHinhThucBT.SetFocusedRowCellValue("MOI_CU", true);
            }
            catch { }
        }

        private void grvHinhThucBT_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (!btnGhi.Visible) return;
            if (grdHinhThucBT.DataSource == null) return;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Columns.GridColumn sTenHinhThuc = view.Columns["TEN_HT_BT"];
            grvHinhThucBT.Columns.View.ClearColumnErrors();

            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, sTenHinhThuc).ToString()))
            {
                e.Valid = false;
                view.SetColumnError(sTenHinhThuc, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThemsua", Commons.Modules.TypeLanguage));
                return;
            }
            

            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdHinhThucBT.DataSource;
            string sBT = "HTBT_TMP" + Commons.Modules.UserName ;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM " + sBT + " WHERE MS_HT_BT <> " + view.GetRowCellValue(e.RowHandle, "MS_HT_BT").ToString() + " AND TEN_HT_BT = N'" + view.GetRowCellValue(e.RowHandle, "TEN_HT_BT").ToString() + "'"));
            if (dtTmp.Rows.Count > 0)
            {
                e.Valid = false;
                view.SetColumnError(sTenHinhThuc, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTEN_HT_BT", Commons.Modules.TypeLanguage));
                return;
            }
            Commons.Modules.ObjSystems.XoaTable(sBT);


            if (view.GetRowCellValue(e.RowHandle, "PHONG_NGUA").ToString().ToUpper() == "TRUE")
            {
                DataTable dtLBT = new DataTable();
                dtLBT = ((DataTable)grdLoaiBT.DataSource).Copy();
                dtLBT.DefaultView.RowFilter = "HU_HONG = 1 AND MS_HT_BT = " + grvHinhThucBT.GetFocusedRowCellValue("MS_HT_BT").ToString();
                dtLBT = dtLBT.DefaultView.ToTable();
                if (dtLBT.Rows.Count > 0)
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["PHONG_NGUA"], Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCoLoaiBaoTriHuHongKhongDoiDuoc", Commons.Modules.TypeLanguage));
                    return;

                }


            }
            
            
            e.Valid = true;
            grvHinhThucBT.UpdateCurrentRow();

            try
            {
                if (grvHinhThucBT.GetFocusedRowCellValue("PHONG_NGUA").ToString().ToUpper() == "TRUE")
                {
                    grvLoaiBT.Columns["MAU"].Visible = true;
                    grvLoaiBT.Columns["HU_HONG"].Visible = false;
                    if (!btnGhi.Visible) btQH.Visible = true;
                }
                else
                {
                    grvLoaiBT.Columns["MAU"].Visible = false;
                    grvLoaiBT.Columns["HU_HONG"].Visible = true;
                    if (!btnGhi.Visible) btQH.Visible = false;
                }
            }
            catch { }
        }

        private void grvLoaiBT_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (!btnGhi.Visible) return;
                if (String.IsNullOrEmpty(grvLoaiBT.GetFocusedRowCellValue("MS_HT_BT").ToString())) grvLoaiBT.SetFocusedRowCellValue("MS_HT_BT", grvHinhThucBT.GetFocusedRowCellValue("MS_HT_BT").ToString());
                if (String.IsNullOrEmpty(grvLoaiBT.GetFocusedRowCellValue("MS_LOAI_BT").ToString())) grvLoaiBT.SetFocusedRowCellValue("MS_LOAI_BT", grvLoaiBT.RowCount + 1);

                grvLoaiBT.SetFocusedRowCellValue("MOI_CU", true);

            }
            catch { }

        }

        private void grvLoaiBT_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (!btnGhi.Visible) return;
            if (grdLoaiBT.DataSource == null) return;
            
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Columns.GridColumn sTenLoaiBT = view.Columns["TEN_LOAI_BT"];
            grvLoaiBT.Columns.View.ClearColumnErrors();

            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, sTenLoaiBT).ToString()))
            {
                e.Valid = false;
                view.SetColumnError(sTenLoaiBT, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTEN_LOAI_BT22", Commons.Modules.TypeLanguage));
                return;
            }
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM LOAI_BAO_TRI WHERE MS_LOAI_BT <> " + view.GetRowCellValue(e.RowHandle, "MS_LOAI_BT").ToString() + " AND TEN_LOAI_BT = N'" + view.GetRowCellValue(e.RowHandle, "TEN_LOAI_BT").ToString() + "'"));
            if (dtTmp.Rows.Count > 0)
            {
                e.Valid = false;
                view.SetColumnError(sTenLoaiBT, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTEN_LOAI_BT", Commons.Modules.TypeLanguage));
                return;
            }

            dtTmp = new DataTable();
            dtTmp = (DataTable)grdLoaiBT.DataSource;
            string sBT = "LBT_TMP" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM " + sBT + " WHERE MS_LOAI_BT <> " + view.GetRowCellValue(e.RowHandle, "MS_LOAI_BT").ToString() + " AND TEN_LOAI_BT = N'" + view.GetRowCellValue(e.RowHandle, "TEN_LOAI_BT").ToString() + "' AND MS_HT_BT = " + view.GetRowCellValue(e.RowHandle, "MS_HT_BT").ToString()));
            if (dtTmp.Rows.Count > 0)
            {
                e.Valid = false;
                view.SetColumnError(sTenLoaiBT, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTEN_LOAI_BT", Commons.Modules.TypeLanguage));
                return;
            }
            Commons.Modules.ObjSystems.XoaTable(sBT);
            grvLoaiBT.UpdateCurrentRow();


        }

        private void grvHinhThucBT_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvLoaiBT_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        

        private void btnColor_Click(object sender, EventArgs e)
        {

            GetMau();
        }
        
        private void GetMau()
        {
            if (!btnGhi.Visible) return;

                if ((ColorDialog1.ShowDialog().Equals(DialogResult.OK)))
            {
                Color col = default(Color);
                col = ColorDialog1.Color;
                try
                {
                    if (ColorDialog1.Color.Name.ToString().ToUpper() != "WHITE")
                    {

                        DataTable dtTmp = new DataTable();
                        dtTmp = (DataTable)grdLoaiBT.DataSource;


                        DataTable _tb_Temp = new DataTable();
                        _tb_Temp = dtTmp.Copy();
                        _tb_Temp.DefaultView.RowFilter = "R=" + col.R.ToString() + " AND G=" + col.G.ToString() + " AND B=" + col.B.ToString();
                        _tb_Temp = _tb_Temp.DefaultView.ToTable();
                        if (_tb_Temp.Rows.Count > 0)
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "tontaimau", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    grvLoaiBT.SetFocusedRowCellValue("R", col.R);
                    grvLoaiBT.SetFocusedRowCellValue("G", col.G);
                    grvLoaiBT.SetFocusedRowCellValue("B", col.B);
                    grvLoaiBT.UpdateCurrentRow();
                    //grvLoaiBT.LayoutChanged();
                }
                catch { }


            }

        }

 


        private void grvLoaiBT_DoubleClick(object sender, EventArgs e)
        {

            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {

            GetMau();
        }

        private void BtnXoaNhomBT_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdHinhThucBT.DataSource == null) return;
                if (grvHinhThucBT.RowCount <= 0) return;
                if (string.IsNullOrEmpty(grvHinhThucBT.GetFocusedRowCellValue("MS_HT_BT").ToString())) return;
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedHINH_THUC_BAO_TRI_LOAI_BAO_TRI", grvHinhThucBT.GetFocusedRowCellValue("MS_HT_BT").ToString()));
                if(dtTmp.Rows.Count>0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgLoaiBaoTriDangSuDungKhongTheXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXacNhanXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) return;

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteHINH_THUC_BAO_TRI", grvHinhThucBT.GetFocusedRowCellValue("MS_HT_BT").ToString());
            }
            catch
            {}
            
            Commons.Modules.SQLString = "0Load";
            LoadHinhThucBT(-1);
            Commons.Modules.SQLString = "";
            LoadLoaiBaoTri(-1);
            grvHinhThucBT_FocusedRowChanged(null, null);
        }

        private void BtnXoaLoai_Click(object sender, EventArgs e)
        {
            if(grvLoaiBT.RowCount <=0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Int32 iLoai = 0;
            try
            {
                iLoai = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "CheckLoaiBaoTri", grvLoaiBT.GetFocusedRowCellValue("MS_LOAI_BT").ToString()));
            }
            catch { }
            switch (iLoai)
            {
                //Xoa
                case 0:
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoa2", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    {
                        try
                        {
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteLOAI_BAO_TRI", grvLoaiBT.GetFocusedRowCellValue("MS_LOAI_BT").ToString());
                        }
                        catch(Exception ex)
                        { XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    LoadLoaiBaoTri(-1);
                    grvHinhThucBT_FocusedRowChanged(null, null);
                    break;
                //Cach Thuc Hien
                case 1:
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgXoaDSDCachThucHien", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                break;
                //may loai bao tri phong ngua
                case 2:
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgXoaDSDMayLoaiBaoTriPhongNgua", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                //Ke hoach tong the
                case 3:
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgXoaDSDKeHoachTongThe", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                //loai bao tri quan he
                case 4:
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgXoaDSDLoaiBaoTriQuanHe", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                //Phieu bao tri
                case 5:
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgXoaDSDPhieuBaoTri", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            
            //AnXoa(true);
        }

        private void btQH_Click(object sender, EventArgs e)
        {
            try
            {
                Report1.FrmLoaiBTQH vFrm = new Report1.FrmLoaiBTQH();
                string sQuyen = null;

                sQuyen = Commons.Modules.PermisString;
                Commons.Modules.PermisString = "";
                if (Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "FrmLoaiBTQH"))
                {
                    vFrm.ShowDialog();
                }
                Commons.Modules.PermisString = sQuyen;
            }catch (Exception EX)
            {
                XtraMessageBox.Show(EX.Message.ToString());
            }

        }
        
    }
}
