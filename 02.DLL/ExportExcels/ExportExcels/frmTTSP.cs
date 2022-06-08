using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;

namespace ExportExcels
{
    public partial class frmTTSP : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bdSP;
        DataTable dtDL = new DataTable();

        DataTable dtQTCN = new DataTable();
        DataTable dtQTTS = new DataTable();
        string PathServer = "";
        string PathTTSPCT = "";
        string PathQTCN = "";

        public frmTTSP()
        {
            InitializeComponent();
        }
#region TTSP
        private void LoadList(int IDSP)
        {
            if (string.IsNullOrEmpty(IDSP.ToString())) IDSP = -1;
            DataTable dtList = new DataTable();
            dtList.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetThongTinSP"));
            dtList.PrimaryKey = new DataColumn[] { dtList.Columns["ID"] };

            bdSP = new BindingSource();            
            bdSP.DataSource = dtList.DefaultView;
            grdData.DataSource = bdSP;

            if (IDSP != -1)
            {
                int index = dtList.Rows.IndexOf(dtList.Rows.Find(IDSP));
                grvData.FocusedRowHandle = grvData.GetRowHandle(index);
            }

            txtMaSP.DataBindings.Clear();
            txtMaSP.DataBindings.Add("Text", bdSP, "MA_SP");

            txtTenSP.DataBindings.Clear();
            txtTenSP.DataBindings.Add("Text", bdSP, "TEN_SP");

            txtKThuoc.DataBindings.Clear();
            txtKThuoc.DataBindings.Add("Text", bdSP, "KICH_THUONG");

            txtSSKThuoc.DataBindings.Clear();
            txtSSKThuoc.DataBindings.Add("Text", bdSP, "SAI_SO_KT");

            txtTLuong.DataBindings.Clear();
            txtTLuong.DataBindings.Add("Text", bdSP, "TRONG_LUONG");

            txtSSTLuong.DataBindings.Clear();
            txtSSTLuong.DataBindings.Add("Text", bdSP, "SAI_SO_TL");

            txtDTinh.DataBindings.Clear();
            txtDTinh.DataBindings.Add("Text", bdSP, "DAC_TINH");

            btnDDH.DataBindings.Clear();
            btnDDH.DataBindings.Add("Text", bdSP, "DUONG_DAN_HINH");

            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", bdSP, "ID");
            txtID.Visible = false;

            imgHinh.DataBindings.Clear();
            imgHinh.DataBindings.Add("Image", bdSP, "HINH", true);

            if (txtID.Text == "") txtID.Text = "-1";
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvData.Columns)
            {
                if (col.FieldName == "TEN_SP" || col.FieldName == "MA_SP")
                {

                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    //col.AppearanceHeader.Font.Bold = true;
                    col.AppearanceHeader.Options.UseTextOptions = true;
                    col.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    col.AppearanceCell.Options.UseTextOptions = true;
                    col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", col.FieldName, Commons.Modules.TypeLanguage);

                }
                else
                {
                    col.Visible = false;
                }
            }
            grvData.OptionsView.ColumnAutoWidth = true;
            grvData.Columns["MA_SP"].Width = 95;
            grvData.Columns["TEN_SP"].Width = 205;
            if (tabData.SelectedTabPageIndex == 0) LoadCT();
        }

        private void copyColumnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (btnGhi.Visible == false) return;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            try
            {
                DialogResult res = f.ShowDialog();
                if (res.Equals(DialogResult.Cancel))
                    return;
            }
            catch
            {
                return;
            }

            if (PathTTSPCT == "") PathTTSPCT = Commons.Modules.ObjSystems.CapnhatTL(true, "TTSP\\TTSPCT");
            string Tmp = PathTTSPCT + @"\" + "TTSPCT_" + txtID.Text + "_" + grvTTSP.GetDataRow(grvTTSP.FocusedRowHandle)["ID_CT"].ToString() +
                                    Commons.Modules.ObjSystems.LayDuoiFile(f.FileName);
            grvTTSP.GetDataRow(grvTTSP.FocusedRowHandle)["DD_HINH"] = Tmp;
            grvTTSP.GetDataRow(grvTTSP.FocusedRowHandle)["DUONG_DAN"] = f.FileName;
            grvTTSP.UpdateCurrentRow();

        }

        private void LoadCT()
        {
            dtDL = new DataTable();
            dtDL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetThongTinSPCT" , int.Parse( txtID.Text )));
            try
            {
                dtDL.Columns.Add("DUONG_DAN");
            }
            catch { }
            dtDL.Columns["TEN_SP"].AllowDBNull = true;
            dtDL.Columns["MS_KH"].AllowDBNull = true;
            dtDL.Columns["ID"].AllowDBNull = true;
            dtDL.Columns["ID_CT"].AllowDBNull = true;

            grdTTSP.DataSource = dtDL;


            DataTable dtKH = new DataTable();
            dtKH.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHACH_HANGs"));
            
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboKH = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboKH.NullText = "";
            cboKH.ValueMember = "MS_KH";
            cboKH.DisplayMember = "TEN_CONG_TY";
            cboKH.DataSource = dtKH;
            cboKH.Columns.Clear();
            cboKH.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_CONG_TY"));
            cboKH.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DIA_CHI"));
            cboKH.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(cboKH_CloseUp);
            grvTTSP.Columns["MS_KH"].ColumnEdit = cboKH;

            

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboDC = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboDC.NullText = "";
            cboDC.ValueMember = "MS_KH";
            cboDC.DisplayMember = "DC_TEL_FAX";
            cboDC.DataSource = dtKH;
            cboDC.Columns.Clear();
            cboDC.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DC_TEL_FAX"));
            grvTTSP.Columns["DIA_CHI"].ColumnEdit = cboDC;


            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnColumnEdit.AutoHeight = false;
            btnColumnEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(copyColumnEdit_ButtonClick);
            btnColumnEdit.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            btnColumnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            btnColumnEdit.Buttons[0].Appearance.BackColor2 = System.Drawing.Color.Transparent;
            btnColumnEdit.Buttons[0].Appearance.BorderColor = System.Drawing.Color.Transparent;
            grvTTSP.Columns["DD_HINH"].ColumnEdit = btnColumnEdit;

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvTTSP.Columns)
            {
                if (col.FieldName == "HINH" || col.FieldName == "ID" || col.FieldName == "ID_CT")
                {
                    col.Visible = false;
                }
                else
                {
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    
                    //col.AppearanceHeader.Font.Bold = true;
                    col.AppearanceHeader.Options.UseTextOptions = true;
                    col.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    col.AppearanceCell.Options.UseTextOptions = true;
                    col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", col.FieldName, Commons.Modules.TypeLanguage);
                }
            }
            grvTTSP.Columns["TEN_SP"].Width = 180;
            grvTTSP.Columns["MS_KH"].Width = 160;
            grvTTSP.Columns["DIA_CHI"].Width = 160;
            grvTTSP.Columns["HAM_LUONG"].Width = 100;
            grvTTSP.Columns["THONG_SO"].Width = 100;
            grvTTSP.Columns["GHI_CHU"].Width = 188;
            grvTTSP.Columns["DD_HINH"].Width = 200;
            grvTTSP.Columns["DUONG_DAN"].Visible = false;
            grvTTSP.OptionsView.ColumnAutoWidth = true;
            //grvTTSP.OptionsView.ColumnAutoWidth = false;
            
        }

        private void cboKH_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                try
                {
                    grvTTSP.GetDataRow(grvTTSP.FocusedRowHandle)["DIA_CHI"] = e.Value.ToString();
                }
                catch { }
            }
            catch { }
        }

        private void frmTTSP_Load(object sender, EventArgs e)
        {
            try
            {
                txtIDPO.Text = "-1";
                LoadList(-1);
                LoadNN();
            }
            catch {}
            PathServer = Commons.Modules.ObjSystems.CapnhatTL(true, "TTSP");
            PathTTSPCT = Commons.Modules.ObjSystems.CapnhatTL(true, "TTSP\\TTSPCT");
            PathQTCN = Commons.Modules.ObjSystems.CapnhatTL(true, "TTSP\\QTCN");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (tabData.SelectedTabPageIndex == 1)
            {
                if (grvData.SelectedRowsCount == 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "khongcodulieuthem", Commons.Modules.TypeLanguage));
                    return;
                }
            
            }
            txtID.Properties.ReadOnly = true ;
            txtIDPO.Properties.ReadOnly = true;
            HienGhi(false);
            if (tabData.SelectedTabPageIndex == 0)
            {
                bdSP.AddNew();
                txtID.Text = "-1";
                txtTL.Text = "";
                txtH.Text = "";            
            }
            else
            {
                txtIDPO.Text = "-1";
                txtSoPO.Text = "";
                datNLap.DateTime = DateTime.Now;
                txtTTCho.Text = "";
                txtNSoan.Text = "";
                txtNKy1.Text = "";
                txtNKy2.Text = "";
                txtDDan.Text = "";
                txtIDPO.Text = "-1";

                LoadQTCNCT(-1);
            }

        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            int IDSP = -1;
            int IDCT = -1;
            int IDPO = -1;
            int IDPOCT = -1;
            int IDPOCTLUU = -1;

            //IDPOCTLUU = grvQTCN.GetFocusedDataRow("");
            if (tabData.SelectedTabPageIndex == 1)
            {
                try
                {
                    IDPOCTLUU = int.Parse(grvQTCN.GetFocusedDataRow()["BUOC"].ToString());
                }
                catch { }
            }

            string sql = "";
            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            SqlTransaction tran;
            try
            {
                if (tabData.SelectedTabPageIndex == 0)
                {
#region Tab TTSP
    #region Kiem du lieu
                    grvTTSP.UpdateCurrentRow();
                    if (txtMaSP.Text.Trim() == "")
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "ChuaNhapMa", Commons.Modules.TypeLanguage));
                        txtMaSP.Focus();
                        return;
                    }
                    if (txtTenSP.Text.Trim() == "")
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "ChuaNhapTen", Commons.Modules.TypeLanguage));
                        txtTenSP.Focus();
                        return;
                    }

                    string Sql = "";
                    DataTable dtTmp = new DataTable();
                    Sql = " SELECT * FROM THONG_TIN_SP WHERE MA_SP = N'" + txtMaSP.Text + "' ";
                    if (txtID.Properties.ReadOnly == false) Sql = Sql + " AND ID <> " + txtID.Text;

                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        txtMaSP.Focus();
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "MaSPTrung", Commons.Modules.TypeLanguage));
                        return;
                    }

                    dtTmp = new DataTable();
                    Sql = " SELECT * FROM THONG_TIN_SP WHERE TEN_SP = N'" + txtTenSP.Text + "' ";
                    if (txtID.Properties.ReadOnly == false) Sql = Sql + " AND ID <> " + txtID.Text;

                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        txtTenSP.Focus();
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TenSPTrung", Commons.Modules.TypeLanguage));
                        return;
                    }
    #endregion
    #region Begin cap nhap CSDL

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    
                    tran = con.BeginTransaction();
                    IDSP = -1;
                    IDCT = -1;
                    try
                    {
                        if (txtID.Properties.ReadOnly == false)
                        {//sua
                            SqlHelper.ExecuteNonQuery(tran, "MAddThingTinSP", Convert.ToInt32(txtID.Text),
                                        txtMaSP.Text.ToString(), txtTenSP.Text.ToString(), txtKThuoc.Text.ToString(),
                                        txtSSKThuoc.Text.ToString(), txtTLuong.Text.ToString(), txtSSTLuong.Text,
                                        txtDTinh.Text, btnDDH.Text);
                            IDSP = int.Parse(txtID.Text);
                        }
                        else
                        {//them moi  
                            IDSP = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, "MAddThingTinSP", -1,
                            txtMaSP.Text, txtTenSP.Text, txtKThuoc.Text, txtSSKThuoc.Text, txtTLuong.Text, txtSSTLuong.Text,
                            txtDTinh.Text, btnDDH.Text));
                        }
                        //cap nhap chi tiet
                        for (int i = 0; i < grvTTSP.RowCount - 1; i++)
                        {
                            IDCT = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, "MAddThingTinSPCT", Convert.ToInt32(IDSP),
                                        int.Parse(grvTTSP.GetDataRow(i)["ID_CT"].ToString()), grvTTSP.GetDataRow(i)["TEN_SP"].ToString(),
                                        grvTTSP.GetDataRow(i)["MS_KH"].ToString(), grvTTSP.GetDataRow(i)["HAM_LUONG"].ToString(),
                                        grvTTSP.GetDataRow(i)["THONG_SO"].ToString(), grvTTSP.GetDataRow(i)["GHI_CHU"].ToString(),
                                        grvTTSP.GetDataRow(i)["DD_HINH"].ToString()));
                            grvTTSP.GetDataRow(i)["ID_CT"] = IDCT;
                        }

                        tran.Commit();
                        con.Close();
                    }
                    catch
                    {
                        tran.Rollback();
                        con.Close();
                    }
    #endregion
    #region Cap Nhap Hinh
                    try
                    {
                        if (!txtH.Text.ToString().Trim().Equals(string.Empty))
                            sql = " UPDATE THONG_TIN_SP SET HINH = (SELECT BulkColumn FROM " +
                                        " Openrowset( Bulk N'" + txtH.Text + "', Single_Blob) AS HINH) " +
                                        " WHERE ID = " + IDSP;
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql);
                    }
                    catch { }
    #endregion

    #region Cap Nhap Tai Lieu
    try
    {

        if (!btnDDH.Text.ToString().Trim().Equals(string.Empty))
        {
            if (System.IO.File.Exists(txtTL.Text))
            {
                sql = " UPDATE THONG_TIN_SP SET DUONG_DAN_HINH = N'" + btnDDH.Text + "' WHERE ID = " + IDSP;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql);
                Commons.Modules.ObjSystems.LuuDuongDan(txtTL.Text, btnDDH.Text);
            }
            
        }
    }
    catch { }
    #endregion

    #region Cap Nhap Hinh CT
                    for (int i = 0; i < grvTTSP.RowCount - 1; i++)
                    {
                        try
                        {
                            if (!grvTTSP.GetDataRow(i)["DUONG_DAN"].ToString().Trim().Equals(string.Empty))
                                Commons.Modules.ObjSystems.LuuDuongDan(grvTTSP.GetDataRow(i)["DUONG_DAN"].ToString(), grvTTSP.GetDataRow(i)["DD_HINH"].ToString());
                            else
                            {
                                //IDCT = int.Parse(grvTTSP.GetDataRow(i)["ID_CT"].ToString());
                                //sql = " UPDATE THONG_TIN_SP_CHI_TIET SET HINH = NULL,DD_HINH= NULL WHERE ID = " + IDSP + " AND ID_CT = " + IDCT;
                                //SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql);

                            }
                        }
                        catch { }
                    }


    #endregion
#endregion
                }
                else
                {
#region TabQTCN
    #region Kiem du lieu
                    grvQTCN.UpdateCurrentRow();
                    grvTSQT.UpdateCurrentRow();

                    if (txtSoPO.Text.Trim() == "")
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "ChuaNhapSoPo", Commons.Modules.TypeLanguage));
                        txtSoPO.Focus();
                        return;
                    }

                    if (datNLap.Text.Trim() == "")
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "ChuaNhapNgay", Commons.Modules.TypeLanguage));
                        datNLap.Focus();
                        return;
                    }

    #endregion
    #region Begin cap nhap CSDL
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    tran = con.BeginTransaction();
                    IDPO = -1;
                    IDPOCT = -1;
                    try
                    {
                        if (txtIDPO.Properties.ReadOnly == false)
                        {//sua
                            SqlHelper.ExecuteNonQuery(tran, "MAddThongTinSPQTCN", Convert.ToInt32(txtID.Text), Convert.ToInt32(txtIDPO.Text),
                                txtSoPO.Text, datNLap.DateTime, txtTTCho.Text, txtNSoan.Text, txtNKy1.Text, txtNKy2.Text, txtDDan.Text,
                                txtLDTDoi.Text, txtNNhan.Text, txtPXuong.Text);
                            IDPO = int.Parse(txtIDPO.Text);
                        }
                        else
                        {//them moi  
                            IDPO = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, "MAddThongTinSPQTCN", Convert.ToInt32(txtID.Text), -1,
                                txtSoPO.Text, datNLap.DateTime, txtTTCho.Text, txtNSoan.Text, txtNKy1.Text, txtNKy2.Text, txtDDan.Text, 
                                txtLDTDoi.Text, txtNNhan.Text, txtPXuong.Text));
                        }
                        //cap nhap QTCT
                        DataTable dtTmp = new DataTable();
                        dtTmp = dtQTTS.Copy();
                        for (int i = 0; i < grvQTCN.RowCount - 1; i++)
                        {
                            IDPOCT = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, "MAddThongTinSPQTCNCT", Convert.ToInt32(txtID.Text),
                                        IDPO, int.Parse(grvQTCN.GetDataRow(i)["ID_PO_QTCN"].ToString()),grvQTCN.GetDataRow(i)["BUOC"].ToString(),
                                        grvQTCN.GetDataRow(i)["MS_MAY"].ToString(), grvQTCN.GetDataRow(i)["MS_HE_THONG"].ToString(),
                                        grvQTCN.GetDataRow(i)["GHI_CHU"].ToString()));

                        // Xoa TS
                            sql = "DELETE FROM THONG_TIN_SP_QTCN_TS WHERE [ID] = " + Convert.ToInt32(txtID.Text) +
                                    " AND [ID_PO] = " + int.Parse(txtIDPO.Text) + "  AND [ID_PO_QTCN] = " + IDPOCT;
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql);


                            dtTmp.DefaultView.RowFilter = " ID = " + int.Parse(txtID.Text) + " AND ID_PO = " + int.Parse(txtIDPO.Text) +
                                    " AND ID_PO_QTCN = " + int.Parse(grvQTCN.GetDataRow(i)["ID_PO_QTCN"].ToString());
                            foreach (DataRow row in dtTmp.DefaultView.ToTable().Rows)
                            {
                                //row["SL_May" + t.Month + "" + t.Year] =Convert.ToInt16(row2["SL_May"]);
                                SqlHelper.ExecuteNonQuery(tran, "MAddThongTinSPQTCNTS", Convert.ToInt32(txtID.Text), IDPO,
                                    IDPOCT, row["ID_PO_QTCN_TS"], row["MS_THONG_SO_MAY"], row["GIA_TRI"], row["GT_MIN"], row["GT_MAX"], row["GHI_CHU"]);
                                
                            }
                        }

#region Cap Nhap Tai Lieu QTCN
                        try
                        {

                            if (!txtDDan.Text.ToString().Trim().Equals(string.Empty))
                            {
                                if (System.IO.File.Exists(txtTLQTCN.Text))
                                {
                                    sql = " UPDATE THONG_TIN_SP_QTCN SET DUONG_DAN = N'" + txtDDan.Text + "' WHERE [ID] = " + Convert.ToInt32(txtID.Text) +
                                                " AND [ID_PO] = " + int.Parse(txtIDPO.Text);
                                    Commons.Modules.ObjSystems.LuuDuongDan(txtTLQTCN.Text, btnDDH.Text);
                                }

                            }

                            //SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql);
                        }
                        catch { }
#endregion


                        tran.Commit();
                        con.Close();
                    }
                    catch
                    {
                        tran.Rollback();
                        con.Close();
                    }
    #endregion
                }
#endregion
            }
            catch { }
            if (tabData.SelectedTabPageIndex == 0)
                bdSP.EndEdit();
            

            HienGhi(true);
            if (tabData.SelectedTabPageIndex == 0) LoadList(IDSP);
            else
            {
                LoadQTCN(IDPO);
                LoadQTCNCT(IDPOCTLUU);
                LoadQTCNTS();
            }
            txtTL.Text = "";
            txtH.Text = "";
        }

        private void HienGhi(Boolean Hien)
        {
            try
            {
                btnThem.Visible = Hien;
                btnSua.Visible = Hien;
                btnXoa.Visible = Hien;
                btnExit.Visible = Hien;
                btnIn.Visible = Hien;
                btnIn2.Visible = Hien;

                btnGhi.Visible = !Hien;
                btnKhong.Visible = !Hien;
                grdData.Enabled = Hien;

                if (tabData.SelectedTabPageIndex == 0)
                {
                    #region TabTTSP
                    txtMaSP.Focus();
                    if (Hien)
                    {
                        grvTTSP.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        grvTTSP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                    }
                    else
                    {
                        grvTTSP.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        grvTTSP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                    }
                    grvTTSP.OptionsBehavior.Editable = !Hien;
                    txtMaSP.Properties.ReadOnly = Hien;
                    txtTenSP.Properties.ReadOnly = Hien;
                    txtKThuoc.Properties.ReadOnly = Hien;
                    txtSSKThuoc.Properties.ReadOnly = Hien;
                    txtTLuong.Properties.ReadOnly = Hien;
                    txtSSTLuong.Properties.ReadOnly = Hien;
                    txtDTinh.Properties.ReadOnly = Hien;
                    btnDDH.Properties.ReadOnly = Hien;
                    btnCH.Enabled = !Hien;
                    btnXoaH.Enabled = !Hien;
                    grvTTSP.Columns["DIA_CHI"].OptionsColumn.ReadOnly = true;
                    #endregion
                }
                else
                {
                    #region QTCN
                    grvQTCN.OptionsBehavior.Editable = !Hien;
                    grvTSQT.OptionsBehavior.Editable = !Hien;

                    //dtQTCN.Columns["TEN_MAY"].ReadOnly = true;
                    grvQTCN.Columns["TEN_MAY"].OptionsColumn.ReadOnly = true;
                    grvTSQT.Columns["TEN_DV_DO"].OptionsColumn.ReadOnly = true;                    
                    
                    txtSoPO.Properties.ReadOnly = Hien;
                    cboQTCN.Properties.ReadOnly = !Hien;
                    
                    txtTTCho.Properties.ReadOnly = Hien;
                    txtNSoan.Properties.ReadOnly = Hien;
                    txtNKy1.Properties.ReadOnly = Hien;
                    txtNKy2.Properties.ReadOnly = Hien;
                    txtDDan.Properties.ReadOnly = Hien;
                    txtLDTDoi.Properties.ReadOnly = Hien;
                    txtNNhan.Properties.ReadOnly = Hien;
                    txtPXuong.Properties.ReadOnly = Hien;
                    grvQTCN.OptionsBehavior.Editable = !Hien;
                    grvTSQT.OptionsBehavior.Editable = !Hien;
                    if (Hien)
                    {
                        grvQTCN.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        grvQTCN.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;

                        grvTSQT.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        grvTSQT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                        datNLap.Properties.ReadOnly = true;
                    }
                    else
                    {
                        grvQTCN.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        grvQTCN.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;

                        grvTSQT.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        grvTSQT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                        datNLap.Properties.ReadOnly = false;

                    }
                    #endregion
                }

            }
            catch { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (grvData.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "khongcodulieusua", Commons.Modules.TypeLanguage));
                return;
            }
            HienGhi(false);
            txtID.Properties.ReadOnly = false;
            txtIDPO.Properties.ReadOnly = false;
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            txtID.Properties.ReadOnly = true;
            HienGhi(true);
            if (tabData.SelectedTabPageIndex == 0)
            {
                try
                {
                    bdSP.EndEdit();
                    LoadList(int.Parse(txtID.Text));
                }

                catch { }
            }
            else {
                LoadQTCN(-1);
                LoadQTCNCT(-1);
                LoadQTCNTS();
            }
        }

        private void grvTTSP_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (btnGhi.Visible == false) return;
            try
            {

                if (!string.IsNullOrEmpty(grvTTSP.GetDataRow(grvTTSP.FocusedRowHandle)["TEN_SP"].ToString()) &&
                        !string.IsNullOrEmpty(grvTTSP.GetDataRow(grvTTSP.FocusedRowHandle)["MS_KH"].ToString()))
                {
                    grvTTSP.GetDataRow(grvTTSP.FocusedRowHandle)["ID"] = txtID.Text;
                    if (string.IsNullOrEmpty(grvTTSP.GetDataRow(grvTTSP.FocusedRowHandle)["ID_CT"].ToString()))
                        grvTTSP.GetDataRow(grvTTSP.FocusedRowHandle)["ID_CT"] = "-1";
                    grvTTSP.UpdateCurrentRow();
                }
            }
            catch { }

        }

        private void grvTTSP_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (btnGhi.Visible == false) return;
            try
            {
                GridView view = sender as GridView;
                GridColumn ColTenSP = view.Columns["TEN_SP"];
                view.SetColumnError(ColTenSP, "");

                if (view.GetRowCellValue(e.RowHandle, ColTenSP).ToString().Trim() == "")
                {
                    view.SetColumnError(ColTenSP, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TenSPkhongduocrong", Commons.Modules.TypeLanguage));
                    e.Valid = false;
                }
                GridColumn ColMsKH = view.Columns["MS_KH"];
                view.SetColumnError(ColMsKH, "");
                if (view.GetRowCellValue(e.RowHandle, ColMsKH).ToString().Trim() == "")
                {
                    view.SetColumnError(ColMsKH, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "MSKHkhongduocrong", Commons.Modules.TypeLanguage));
                    e.Valid = false;
                }
                
            }
            catch
            { }

        }

        private void grvTTSP_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (txtID.Text == "") txtID.Text = "-1";
            if (txtIDPO.Text == "") txtIDPO.Text = "-1";
            if (tabData.SelectedTabPageIndex == 0) LoadCT();
            else
            {
                LoadQTCN(-1);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDDH_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (btnGhi.Visible == false) return;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "All files (*.*)|*.*";
            try
            {
                DialogResult res = f.ShowDialog();
                if (res.Equals(DialogResult.Cancel ))
                    return;
            }
            catch
            {
                return;
            }

            if (PathServer == "") PathServer = Commons.Modules.ObjSystems.CapnhatTL(true, "TTSP");
            btnDDH.Text = PathServer + @"\" + "TTSP_" + txtID.Text + Commons.Modules.ObjSystems.LayDuoiFile(f.FileName);
            txtTL.Text = f.FileName;
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(pt);
            
            if (info.InRow || info.InRowCell)
            {

                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                if (info.Column.Name != "colDD_HINH") return;
                if (string.IsNullOrEmpty(grvTTSP.GetDataRow(info.RowHandle)["DD_HINH"].ToString())) return;
                System.Diagnostics.Process.Start(grvTTSP.GetDataRow(info.RowHandle)["DD_HINH"].ToString());

            }

        }

        private void grvTTSP_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            
            Point pt = view.GridControl.PointToClient(Control.MousePosition);

            DoRowDoubleClick(view, pt);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tabData.SelectedTabPageIndex == 1 )
            {
                HienXoa(true);
                return;
            }
            if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "chacxoa", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes) return;
            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlTransaction tran = con.BeginTransaction();


            try
            {
                SqlHelper.ExecuteNonQuery(tran, "MDeleteThongTinSP", Convert.ToInt32(txtID.Text),-1);
                tran.Commit();
            }
            catch {
                tran.Rollback();
            }

            LoadList(-1);
        }

        private void grvTTSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnGhi.Visible) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (grvTTSP.RowCount == 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KhongDuLieuXoa", Commons.Modules.TypeLanguage));
                    return;
                }

                if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "Xoa1DongTS", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;


                SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran, "MDeleteThongTinSPQTCT", Convert.ToInt32(txtID.Text), Convert.ToInt32(txtIDPO.Text),
                        Convert.ToInt32(grvQTCN.GetFocusedDataRow()["ID_PO_QTCN"]));
                    GridView view = sender as GridView;
                    view.DeleteRow(view.FocusedRowHandle);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
        }

#endregion    

        private void LoadNN()
        {
            lblTieuDe.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblTieuDe", Commons.Modules.TypeLanguage);
            lblMaSp.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblMaSp", Commons.Modules.TypeLanguage);
            lblTenSp.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblTenSp", Commons.Modules.TypeLanguage);
            lblKThuoc.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblKThuoc", Commons.Modules.TypeLanguage);
            lblTLuong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblTLuong", Commons.Modules.TypeLanguage);
            lblDTinh.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblDTinh", Commons.Modules.TypeLanguage);
            lblDDHinh.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblDDHinh", Commons.Modules.TypeLanguage);
            lblSSKThuoc.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblSSKThuoc", Commons.Modules.TypeLanguage);
            lblSSTLuong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblSSTLuong", Commons.Modules.TypeLanguage);
            groupControl1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "groupControl1", Commons.Modules.TypeLanguage);
            tabData.TabPages[0].Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TAB1", Commons.Modules.TypeLanguage);
            tabData.TabPages[1].Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TAB2", Commons.Modules.TypeLanguage);
            btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "btnGhi", Commons.Modules.TypeLanguage);
            btnKhong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "btnKhong", Commons.Modules.TypeLanguage);
            btnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "btnThem", Commons.Modules.TypeLanguage);
            btnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "btnSua", Commons.Modules.TypeLanguage);
            btnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "btnXoa", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "btnExit", Commons.Modules.TypeLanguage);
            btnIn.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "btnIn", Commons.Modules.TypeLanguage);
            btnIn2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "btnIn2", Commons.Modules.TypeLanguage);
            this.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "frmTTSP", Commons.Modules.TypeLanguage);

            lblSoPO.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblSoPO", Commons.Modules.TypeLanguage);
            lblNLap.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblNLap", Commons.Modules.TypeLanguage);
            lblTTCho.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblTTCho", Commons.Modules.TypeLanguage);
            lblNSoan.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblNSoan", Commons.Modules.TypeLanguage);
            lblNKy1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblNKy1", Commons.Modules.TypeLanguage);
            lblNKy2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblNKy2", Commons.Modules.TypeLanguage);
            lblDDan.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblDDan", Commons.Modules.TypeLanguage);
            grpQTCN.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "grpQTCN", Commons.Modules.TypeLanguage);
            grpTSQT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "grpTSQT", Commons.Modules.TypeLanguage);

            lblLDTDoi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblLDTDoi", Commons.Modules.TypeLanguage);
            lblPXuong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblPXuong", Commons.Modules.TypeLanguage);
            lblNNhan.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "lblNNhan", Commons.Modules.TypeLanguage);

        }

        private void LoadQTCN(int IDPO)
        {
            try
            {
                DataTable dtQTCN = new DataTable();
                dtQTCN = new DataTable();
                dtQTCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetThongTinSPQTCN", int.Parse(txtID.Text)));

                cboQTCN.Properties.DataSource = dtQTCN;
                cboQTCN.Properties.DisplayMember = "NGAY_PO";
                cboQTCN.Properties.ValueMember = "ID_PO";
                if (IDPO != -1)
                {
                    cboQTCN.EditValue = IDPO;
                }
                else
                    if (dtQTCN.Rows.Count <= 0) cboQTCN.EditValue = -1; else cboQTCN.EditValue = int.Parse(dtQTCN.Rows[0]["ID_PO"].ToString());

                LoadTextQTCN();
                cboQTCN.Properties.PopulateColumns();
                cboQTCN.Properties.Columns["ID_PO"].Visible = false;
                cboQTCN.Properties.Columns["NGAY_PO"].Visible = false;
                cboQTCN.Properties.Columns["THAY_THE"].Visible = false;
                cboQTCN.Properties.Columns["NGUOI_SOAN"].Visible = false;
                cboQTCN.Properties.Columns["NGUOI_KY1"].Visible = false;
                cboQTCN.Properties.Columns["NGUOI_KY2"].Visible = false;
                cboQTCN.Properties.Columns["DUONG_DAN"].Visible = false;
                cboQTCN.Properties.Columns["ID_PO"].Visible = false;
                cboQTCN.Properties.Columns["ID"].Visible = false;
                cboQTCN.Properties.Columns["PHAN_XUONG"].Visible = false;
                cboQTCN.Properties.Columns["NOI_NHAN"].Visible = false;
                cboQTCN.Properties.Columns["LY_DO_TD"].Visible = false;        
            }
            catch { }
        }

        private void LoadQTCNCT(int IDPOCT)
        {
            try
            {
                dtQTCN = new DataTable();
                dtQTCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetThongTinSPQTCN_CT", int.Parse(txtID.Text), int.Parse(txtIDPO.Text)));
                grdQTCN.DataSource = dtQTCN;
                dtQTCN.PrimaryKey = new DataColumn[] { dtQTCN.Columns["BUOC"] };

                if (IDPOCT != -1)
                {
                    int index = dtQTCN.Rows.IndexOf(dtQTCN.Rows.Find(IDPOCT));
                    grvQTCN.FocusedRowHandle = grvQTCN.GetRowHandle(index);
                }


                DataTable dtMay = new DataTable();
                dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT DISTINCT MS_MAY, TEN_MAY FROM dbo.MAY ORDER BY MS_MAY"));

                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboMay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                cboMay.NullText = "";
                cboMay.ValueMember = "MS_MAY";
                cboMay.DisplayMember = "TEN_MAY";
                cboMay.DataSource = dtMay;
                cboMay.Columns.Clear();
                cboMay.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_MAY"));
                grvQTCN.Columns["TEN_MAY"].ColumnEdit = cboMay;

                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboMSMay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                cboMSMay.NullText = "";
                cboMSMay.ValueMember = "MS_MAY";
                cboMSMay.DisplayMember = "MS_MAY";
                cboMSMay.DataSource = dtMay;
                cboMSMay.Columns.Clear();
                cboMSMay.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_MAY"));
                cboMSMay.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_MAY"));
                cboMSMay.Columns["TEN_MAY"].Width = 200;
                cboMSMay.Columns["MS_MAY"].Width = 200;
                cboMSMay.PopupWidth = 400;
                
                grvQTCN.Columns["MS_MAY"].ColumnEdit = cboMSMay;
                cboMSMay.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(cboMSMay_EditValueChanging);
                cboMSMay.EditValueChanged += new System.EventHandler(cboMSMay_EditValueChanged);
                

                DataTable dtTS = new DataTable();
                dtTS.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        " SELECT DISTINCT dbo.MAY_HE_THONG_NGAY_MAX.MS_HE_THONG, dbo.HE_THONG.TEN_HE_THONG " +
                        " FROM dbo.MAY_HE_THONG_NGAY_MAX INNER JOIN dbo.HE_THONG ON dbo.MAY_HE_THONG_NGAY_MAX.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG "));

                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboHT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                cboHT.NullText = "";
                cboHT.ValueMember = "MS_HE_THONG";
                cboHT.DisplayMember = "TEN_HE_THONG";
                cboHT.DataSource = dtTS;
                cboHT.Columns.Clear();
                cboHT.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_HE_THONG"));
                grvQTCN.Columns["MS_HE_THONG"].ColumnEdit = cboHT;


                if (grvQTCN.Columns["ID"].Visible == false) return;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvQTCN.Columns)
                {
                    if (col.FieldName == "ID" || col.FieldName == "ID_PO" || col.FieldName == "ID_PO_QTCN")
                    {
                        col.Visible = false;
                    }
                    else
                    {
                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        col.AppearanceHeader.Options.UseTextOptions = true;
                        col.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        col.AppearanceCell.Options.UseTextOptions = true;
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", col.FieldName, Commons.Modules.TypeLanguage);
                    }
                }

                grvQTCN.Columns["BUOC"].Width = 70;
                grvQTCN.Columns["MS_MAY"].Width = 145;
                grvQTCN.Columns["TEN_MAY"].Width = 230;
                grvQTCN.Columns["MS_HE_THONG"].Width = 220;
                grvQTCN.Columns["GHI_CHU"].Width = 260;
            }
            catch { }

        }
        private void cboMSMay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (dtQTTS.DefaultView.Count > 0)
            {
                if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "chacdoiomay", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                for (int i = 0; i <= dtQTTS.DefaultView.Count; i++)
                {
                    dtQTTS.DefaultView.Delete(0);
                }
                dtQTTS.AcceptChanges();
            }
            
        }

        private void cboMSMay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.LookUpEdit cbo = (DevExpress.XtraEditors.LookUpEdit)sender;

                //DevExpress.XtraGrid.GridControl grid = (DevExpress.XtraGrid.GridControl)type

                grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["TEN_MAY"] = cbo.EditValue;

                DataTable dtTS = new DataTable();
                dtTS.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        " SELECT DISTINCT dbo.MAY_HE_THONG_NGAY_MAX.MS_HE_THONG " +
                        " FROM dbo.MAY_HE_THONG_NGAY_MAX INNER JOIN dbo.HE_THONG ON dbo.MAY_HE_THONG_NGAY_MAX.MS_HE_THONG = dbo.HE_THONG.MS_HE_THONG " +
                        " WHERE MS_MAY = '" + cbo.EditValue + "' "));
                if (dtTS.Rows.Count > 0)
                    grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["MS_HE_THONG"] = dtTS.Rows[0]["MS_HE_THONG"].ToString();
                else
                    grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["MS_HE_THONG"] = 0;
            }
            catch { }
        
        }
       

        private void LoadQTCNTS()
        {
            try
            {
                int ID_PO;
                int ID_TS;
                if (cboQTCN.Text == "") ID_PO = -1; else ID_PO = int.Parse(cboQTCN.EditValue.ToString());
                if (grvQTCN.RowCount > 0)
                {
                    if (grvQTCN.GetFocusedDataRow()["ID_PO_QTCN"].ToString() == "")
                        ID_TS = -1;
                    else
                        ID_TS = int.Parse(grvQTCN.GetFocusedDataRow()["ID_PO_QTCN"].ToString());
                }
                else ID_TS = -1;
                dtQTTS = new DataTable();
                dtQTTS.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetThongTinSPQTCN_TS", int.Parse(txtID.Text), ID_PO, ID_TS));
                
                try
                {
                    dtQTTS.DefaultView.RowFilter = " ID_PO = " + int.Parse(txtIDPO.Text) + " AND ID_PO_QTCN = " + int.Parse(grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID_PO_QTCN"].ToString());
                }
                catch { dtQTTS.DefaultView.RowFilter = " ID_PO_QTCN = -1"; }
                grdTSQT.DataSource = dtQTTS;
                TaoCmbTS();

                if (grvTSQT.Columns["ID"].Visible == false) return;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvTSQT.Columns)
                {
                    if (col.FieldName == "ID" || col.FieldName == "ID_PO" || col.FieldName == "ID_PO_QTCN_TS" || col.FieldName == "ID_PO_QTCN")
                    {
                        col.Visible = false;
                    }
                    else
                    {
                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        col.AppearanceHeader.Options.UseTextOptions = true;
                        col.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        col.AppearanceCell.Options.UseTextOptions = true;
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", col.FieldName, Commons.Modules.TypeLanguage);
                    }
                }
                
                grvTSQT.Columns["GT_MIN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvTSQT.Columns["GT_MIN"].DisplayFormat.FormatString = "{0:N2}";
                grvTSQT.Columns["GT_MAX"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvTSQT.Columns["GT_MAX"].DisplayFormat.FormatString = "{0:N2}";
                //grvTSQT.Columns["GIA_TRI"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //grvTSQT.Columns["GIA_TRI"].DisplayFormat.FormatString = "{0:N2}";


                grvTSQT.Columns["MS_THONG_SO_MAY"].Width = 260;
                grvTSQT.Columns["GT_MIN"].Width = 125;
                grvTSQT.Columns["GT_MAX"].Width = 125;
                grvTSQT.Columns["GIA_TRI"].Width = 125;
                grvTSQT.Columns["GHI_CHU"].Width = 250;

            }
            catch { }
        }
        private void LayDLCmbTS(int MSTS)
        {
            try
            {

                string Sql = "SELECT TOP 1 dbo.DON_VI_DO.TEN_DV_DO, ISNULL(GIA_TRI_MIN,0) AS GIA_TRI_MIN , ISNULL(GIA_TRI_MAX,0) AS GIA_TRI_MAX, ISNULL(GIA_TRI,0) AS GIA_TRI  " +
                            " FROM dbo.THONG_SO_MAY INNER JOIN dbo.DON_VI_DO ON dbo.THONG_SO_MAY.MS_DV_DO = dbo.DON_VI_DO.MS_DV_DO LEFT OUTER JOIN " +
                            " dbo.THONG_SO_CHINH_MAY ON dbo.THONG_SO_MAY.MS_THONG_SO_MAY = dbo.THONG_SO_CHINH_MAY.MS_THONG_SO_MAY " +
                            " WHERE (dbo.THONG_SO_MAY.MS_THONG_SO_MAY = " + MSTS + ") ";

                DataTable dtThongSo = new DataTable();
                dtThongSo.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql));

                if (grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["TEN_DV_DO"].ToString().ToUpper() == dtThongSo.Rows[0]["TEN_DV_DO"].ToString().ToUpper()) return;


                try
                {
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["GIA_TRI"] = dtThongSo.Rows[0]["GIA_TRI"].ToString();
                }
                catch
                {
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["GIA_TRI"] = 0;
                }

                try
                {
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["GT_MIN"] = Convert.ToDouble(dtThongSo.Rows[0]["GIA_TRI_MIN"].ToString());
                }
                catch
                {
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["GT_MIN"] = 0;
                }

                try
                {
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["GT_MAX"] = Convert.ToDouble(dtThongSo.Rows[0]["GIA_TRI_MAX"].ToString());
                }
                catch
                {
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["GT_MAX"] = 0;
                }

                try
                {
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["TEN_DV_DO"] = dtThongSo.Rows[0]["TEN_DV_DO"].ToString();
                }
                catch
                {
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["TEN_DV_DO"] = "";
                }
                
                
            }
            catch { }
            
        }

        private void TaoCmbTS()
        {
            string MsMay = "-1";
            try
            {
                if (grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["MS_MAY"].ToString() != "") MsMay = grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["MS_MAY"].ToString();
            }
            catch { }

            DataTable dtTS = new DataTable();
            dtTS.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT dbo.THONG_SO_CHINH_MAY.MS_THONG_SO_MAY, dbo.THONG_SO_MAY.TEN_THONG_SO_MAY FROM dbo.THONG_SO_CHINH_MAY " +
                    " INNER JOIN dbo.THONG_SO_MAY ON dbo.THONG_SO_CHINH_MAY.MS_THONG_SO_MAY = dbo.THONG_SO_MAY.MS_THONG_SO_MAY  " +
                    " WHERE     (dbo.THONG_SO_CHINH_MAY.MS_MAY = N'" + MsMay + "') ORDER BY TEN_THONG_SO_MAY  "));
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboTS = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboTS.NullText = "";
            cboTS.ValueMember = "MS_THONG_SO_MAY";
            cboTS.DisplayMember = "TEN_THONG_SO_MAY";
            cboTS.DataSource = dtTS;
            cboTS.Columns.Clear();
            cboTS.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_THONG_SO_MAY"));
            grvTSQT.Columns["MS_THONG_SO_MAY"].ColumnEdit = cboTS;

            if (btnGhi.Visible)
                if (dtTS.Rows.Count == 0)
                {
                    grvTSQT.OptionsBehavior.Editable = false;
                    grvQTCN.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                }
                else
                {
                    grvTSQT.OptionsBehavior.Editable = true;
                    grvQTCN.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                }
            else
                grvTSQT.OptionsBehavior.Editable = false;
                
            cboTS.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(cboTS_EditValueChanging);
            cboTS.EditValueChanged += new System.EventHandler(this.cboTS_EditValueChanged);


        }
        private void cboTS_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.LookUpEdit cbo = (DevExpress.XtraEditors.LookUpEdit)sender;
                LayDLCmbTS((int)cbo.EditValue);
            }
            catch { }
        
        }
        private void cboTS_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = dtQTTS.Copy();
                dtTmp.DefaultView.RowFilter = " ID = " + int.Parse(txtID.Text) + " AND ID_PO = " + int.Parse(txtIDPO.Text) +
                        " AND ID_PO_QTCN = " + int.Parse(grvQTCN.GetFocusedDataRow()["ID_PO_QTCN"].ToString());
                
                
                for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                {
                    try
                    {
                        if (grvTSQT.GetDataRow(i)["MS_THONG_SO_MAY"].ToString() != "")
                        {
                            if (int.Parse(grvTSQT.GetDataRow(i)["MS_THONG_SO_MAY"].ToString()) == int.Parse(e.NewValue.ToString()))
                            {
                                e.Cancel = true;
                                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "DaChonTS", Commons.Modules.TypeLanguage));
                                return;
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }            
        }

        private void LoadTextQTCN()
        {
            
            try 
            {
                txtSoPO.Text = cboQTCN.GetColumnValue("SO_PO").ToString();
                datNLap.DateTime = Convert.ToDateTime(cboQTCN.GetColumnValue("NGAY_PO"));
                txtTTCho.Text = cboQTCN.GetColumnValue("THAY_THE").ToString();
                txtNSoan.Text = cboQTCN.GetColumnValue("NGUOI_SOAN").ToString();
                txtNKy1.Text = cboQTCN.GetColumnValue("NGUOI_KY1").ToString();
                txtNKy2.Text = cboQTCN.GetColumnValue("NGUOI_KY2").ToString();
                txtDDan.Text = cboQTCN.GetColumnValue("DUONG_DAN").ToString();
                txtIDPO.Text = cboQTCN.GetColumnValue("ID_PO").ToString();
                txtLDTDoi.Text = cboQTCN.GetColumnValue("LY_DO_TD").ToString();
                txtNNhan.Text = cboQTCN.GetColumnValue("NOI_NHAN").ToString();
                txtPXuong.Text = cboQTCN.GetColumnValue("PHAN_XUONG").ToString();                
            }
            catch 
            {
                txtSoPO.Text = "";
                datNLap.Text = "";// DateTime.Now();
                txtTTCho.Text = "";
                txtNSoan.Text = "";
                txtNKy1.Text = "";
                txtNKy2.Text = "";
                txtDDan.Text = "";
                txtIDPO.Text = "-1";
                txtLDTDoi.Text = "";
                txtNNhan.Text = "";
                txtPXuong.Text = "";
            }
        }

        private void cboQTCN_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTextQTCN();
                LoadQTCNCT(-1);
                LoadQTCNTS();

            }
            catch { }
        }

        private void grvQTCN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                dtQTTS.DefaultView.RowFilter = " ID_PO = " + int.Parse(txtIDPO.Text) + " AND ID_PO_QTCN = " + int.Parse(grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID_PO_QTCN"].ToString());
            }
            catch { dtQTTS.DefaultView.RowFilter = " ID_PO_QTCN= -1"; }
            TaoCmbTS();

        }

        private void tabData_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (tabData.SelectedTabPageIndex == 1)
                {
                    LoadQTCN(-1);
                    LoadTextQTCN();
                    LoadQTCNCT(-1);
                    LoadQTCNTS();
                    btnIn.Enabled = true;
                    btnIn2.Enabled = true;
                }
                else
                {
                    btnIn.Enabled = false;
                    btnIn2.Enabled = false;
                }
            }
            catch { }
        }

        private void tabData_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (btnGhi.Visible)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTTSP", "BamGhi", Commons.Modules.TypeLanguage));
                e.Cancel = true;
                return;
            }
            if (btnXoa1PO.Visible)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTTSP", "BamTroVe", Commons.Modules.TypeLanguage));
                e.Cancel = true;
                return;
            }
        }

        private void grvQTCN_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            //e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvQTCN_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (btnGhi.Visible == false) return;
                if (txtID.Text == "") grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID"] = "-1"; else grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID"] = txtID.Text;
                if (txtIDPO.Text == "") grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID_PO"] = "-1"; else grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID_PO"] = txtIDPO.Text;


                if (grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID_PO_QTCN"].ToString() == "")
                {
                    int IDQT = 0;
                    for (int i = 0; i < grvQTCN.RowCount - 1; i++)
                    {
                        if (int.Parse(grvQTCN.GetDataRow(i)["ID_PO_QTCN"].ToString()) > IDQT)
                        {
                            IDQT = int.Parse(grvQTCN.GetDataRow(i)["ID_PO_QTCN"].ToString());
                        }

                    }
                    grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID_PO_QTCN"] = IDQT + 1;
                }
                
            }
            catch { }
        }

        private void grvQTCN_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (btnGhi.Visible == false) return;
                grvQTCN.UpdateCurrentRow();
                TaoCmbTS();
            }
            catch { }
            
        }

        private void grvTSQT_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (btnGhi.Visible == false) return;
                if (string.IsNullOrEmpty(grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID_PO_QTCN"].ToString()))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "ChonQTCN", Commons.Modules.TypeLanguage));
                    return;
                }

                if (txtID.Text == "") grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["ID"] = "-1"; else grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["ID"] = txtID.Text;
                if (txtIDPO.Text == "") grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["ID_PO"] = "-1"; else grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["ID_PO"] = txtIDPO.Text;
                if (grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID_PO_QTCN"].ToString() == "")
                {
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["ID_PO_QTCN"] = "-1";
                }
                else
                {
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["ID_PO_QTCN"] = int.Parse(grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID_PO_QTCN"].ToString());
                }


                if (grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["ID_PO_QTCN_TS"].ToString() == "")
                {
                    int IDTS = 0;
                    for (int i = 0; i < grvTSQT.RowCount - 1; i++)
                    {
                        if (int.Parse(grvTSQT.GetDataRow(i)["ID_PO_QTCN_TS"].ToString()) > IDTS)
                        {
                            IDTS = int.Parse(grvTSQT.GetDataRow(i)["ID_PO_QTCN_TS"].ToString());
                        }

                    }
                    grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["ID_PO_QTCN_TS"] = IDTS + 1;
                }

            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "ChonQTCN", Commons.Modules.TypeLanguage));
            }

        }

        private Boolean KiemGTTS(GridView view)
        {
            grvTSQT.UpdateCurrentRow();
            GridColumn ColMin = view.Columns["GT_MIN"];
            GridColumn ColMax = view.Columns["GT_MAX"];
            
            view.SetColumnError(ColMin, "");
            view.SetColumnError(ColMax, "");
            
            double GTMin = 0;
            double GTMax = 0;
            double GT = 0;

            if (!double.TryParse(grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["GIA_TRI"].ToString(), out GT))
            { return true; }

            if (!double.TryParse(grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["GT_MIN"].ToString(), out GTMin))
            { GTMin = 0; }

            if (!double.TryParse(grvTSQT.GetDataRow(grvTSQT.FocusedRowHandle)["GT_MAX"].ToString(), out GTMax))
            { GTMax = 0; }
            if (GTMin == 0 && GTMax == 0) return true;



            if (GTMin > GT || GTMin > GTMax)
            {
                view.SetColumnError(ColMin, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "GTMin", Commons.Modules.TypeLanguage));
                return false;
            }

            if (GT > GTMax)
            {
                view.SetColumnError(ColMax, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "GTMax", Commons.Modules.TypeLanguage));
                return false;
            }

            return true;
        }

        private void grvTSQT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (btnGhi.Visible == false) return;
                try
                {
                    LayDLCmbTS((int)grvTSQT.GetFocusedDataRow()["MS_THONG_SO_MAY"]);
                }
                catch { }


                if (string.IsNullOrEmpty(grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["ID_PO_QTCN"].ToString()))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "ChonQTCN", Commons.Modules.TypeLanguage));
                    return;
                } 
                grvTSQT.UpdateCurrentRow();
                GridView view = sender as GridView;
                KiemGTTS(view);
            }
            catch {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "ChonQTCN", Commons.Modules.TypeLanguage));
            }



        }

        private void grvTSQT_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvQTCN_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (btnGhi.Visible == false) return;
            try
            {
                GridView view = sender as GridView;
                GridColumn ColBuoc = view.Columns["BUOC"];
                view.SetColumnError(ColBuoc, "");
                int SoLan = 0;
                if (view.GetRowCellValue(e.RowHandle, ColBuoc).ToString().Trim() == "")
                {
                    view.SetColumnError(ColBuoc, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "Buockhongduocrong", Commons.Modules.TypeLanguage));
                    e.Valid = false;
                }
                try
                {
                    for (int i = 0; i <= grvQTCN.RowCount; i++)
                    {
                        try
                        {
                            if (grvQTCN.GetDataRow(i)["BUOC"].ToString() != "")
                            {
                                if (int.Parse(grvQTCN.GetDataRow(i)["BUOC"].ToString()) == int.Parse(grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["BUOC"].ToString()))
                                {
                                    SoLan++;
                                }
                            }
                        }
                        catch { }
                    }
                    if (SoLan > 1)
                    {
                        view.SetColumnError(ColBuoc, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "DaChonBuoc", Commons.Modules.TypeLanguage));
                        e.Valid = false;

                    }
                }
                catch { }
                GridColumn ColMsMay = view.Columns["MS_MAY"];
                view.SetColumnError(ColMsMay, "");
                if (view.GetRowCellValue(e.RowHandle, ColMsMay).ToString().Trim() == "")
                {
                    view.SetColumnError(ColMsMay, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "MSMaykhongduocrong", Commons.Modules.TypeLanguage));
                    e.Valid = false;
                }
            }
            catch
            { }
        }

        private void grvTSQT_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (btnGhi.Visible == false) return;
            try
            {
                grvTSQT.UpdateCurrentRow();
                GridView view = sender as GridView;
                GridColumn ColTS = view.Columns["MS_THONG_SO_MAY"];
                view.SetColumnError(ColTS, "");

                if (view.GetRowCellValue(e.RowHandle, ColTS).ToString().Trim() == "")
                {
                    view.SetColumnError(ColTS, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "ThongSokhongduocrong", Commons.Modules.TypeLanguage));
                    e.Valid = false;
                }
                if (!KiemGTTS(view)) e.Valid = false;
            }
            catch
            { }
        }

        private void grvQTCN_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnGhi.Visible) return;

            if (e.KeyCode == Keys.Delete)
            {
                if (grvQTCN.RowCount == 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KhongDuLieuXoa", Commons.Modules.TypeLanguage));
                    return;
                }

                if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "Xoa1DongQTCT", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran, "MDeleteThongTinSP", Convert.ToInt32(txtID.Text), Convert.ToInt32(grvTTSP.GetFocusedDataRow()["ID_CT"]));
                    GridView view = sender as GridView;
                    view.DeleteRow(view.FocusedRowHandle);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
                LoadQTCNTS();
            }
        }

        private void grvTSQT_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnGhi.Visible) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (grvTSQT.RowCount == 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KhongDuLieuXoa", Commons.Modules.TypeLanguage));
                    return;
                }

                if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "Xoa1DongTS", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;


                SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran, "MDeleteThongTinSPQTTS", Convert.ToInt32(txtID.Text), Convert.ToInt32(txtIDPO.Text),
                        Convert.ToInt32(grvQTCN.GetFocusedDataRow()["ID_PO_QTCN"]), Convert.ToInt32(grvTSQT.GetFocusedDataRow()["ID_PO_QTCN_TS"]));
                    GridView view = sender as GridView;
                    view.DeleteRow(view.FocusedRowHandle);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
        }

        private void btnXoaTS_Click(object sender, EventArgs e)
        {
            if (grvTSQT.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KhongDuLieuXoa", Commons.Modules.TypeLanguage));
                return;
            }

            if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "XoaALLTS", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;


            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(tran, "MDeleteThongTinSPQTTS", Convert.ToInt32(txtID.Text), Convert.ToInt32(txtIDPO.Text),
                    Convert.ToInt32(grvQTCN.GetFocusedDataRow()["ID_PO_QTCN"]), Convert.ToInt32(-1));
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
            LoadQTCNTS();
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (grvQTCN.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KhongDuLieuXoa", Commons.Modules.TypeLanguage));
                return;
            }

            if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "XoaALLQTCT", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;


            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(tran, "MDeleteThongTinSPQTCT", Convert.ToInt32(txtID.Text), Convert.ToInt32(txtIDPO.Text),
                    Convert.ToInt32(-1));
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
            LoadQTCNCT (-1);
        }

        private void btnXoaPO_Click(object sender, EventArgs e)
        {
            if (txtSoPO.Text.ToString().Trim() == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KhongDuLieuXoa", Commons.Modules.TypeLanguage));
                return;
            }

            if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "XoaALLPO", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;


            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(tran, "MDeleteThongTinSPQT", Convert.ToInt32(txtID.Text), Convert.ToInt32(-1));
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
            LoadQTCN(-1);
        }

        private void btnXoa1PO_Click(object sender, EventArgs e)
        {
            if (txtSoPO.Text.ToString().Trim() == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KhongDuLieuXoa", Commons.Modules.TypeLanguage));
                return;
            }

            if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "Xoa1PO", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;


            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(tran, "MDeleteThongTinSPQT", Convert.ToInt32(txtID.Text), Convert.ToInt32(txtIDPO.Text));
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
            LoadQTCN(-1);
        }

        private void HienXoa(bool Hien)
        {
            btnXoa1PO.Visible = Hien;
            btnXoaPO.Visible = Hien;
            btnXoaCT.Visible = Hien;
            btnXoaTS.Visible = Hien;
            btnTV.Visible = Hien;
        }

        private void btnTV_Click(object sender, EventArgs e)
        {
            HienXoa(false);
        }
        private void ShowReport(String BaoCao)
        {


            if (grvData.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KhongDuLieuIn", Commons.Modules.TypeLanguage));
                return;
            }

            if (txtSoPO.Text.ToString().Trim() == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KhongCoPO", Commons.Modules.TypeLanguage));
                return;
            }

            frmReport frmTTSP = new frmReport();
            frmTTSP.rptName = BaoCao; //"rptMThongTinSanPham";

            DataTable dtTTSP = new DataTable();
            dtTTSP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MRGetThongTinSP", int.Parse(txtID.Text)));
            dtTTSP.TableName = "THONG_TIN_SP";
            frmTTSP.AddDataTableSource(dtTTSP);

            DataTable dtTTSPNCC = new DataTable();
            dtTTSPNCC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MRGetThongTinSPCT", int.Parse(txtID.Text)));
            dtTTSPNCC.TableName = "THONG_TIN_NCC";
            frmTTSP.AddDataTableSource(dtTTSPNCC);


            DataTable dtTTSPQT = new DataTable();
            dtTTSPQT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MRGetThongTinQT", int.Parse(txtID.Text), int.Parse(txtIDPO.Text)));
            dtTTSPQT.TableName = "THONG_TIN_QT";
            frmTTSP.AddDataTableSource(dtTTSPQT);


            DataTable dtTTSPQTCT = new DataTable();
            dtTTSPQTCT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MRGetThongTinSPQTTS", int.Parse(txtID.Text), int.Parse(txtIDPO.Text)));
            dtTTSPQTCT.TableName = "THONG_SO_KT";
            frmTTSP.AddDataTableSource(dtTTSPQTCT);

            System.Data.DataTable TbTieuDe = new System.Data.DataTable();
            TbTieuDe.Columns.Add("CTY");
            TbTieuDe.Columns.Add("TDE");
            TbTieuDe.Columns.Add("TRANG");
            TbTieuDe.Columns.Add("SOPO");
            TbTieuDe.Columns.Add("NGAY");
            TbTieuDe.Columns.Add("NSOAN");
            TbTieuDe.Columns.Add("PXUONG");
            TbTieuDe.Columns.Add("GDCLDUYET");
            TbTieuDe.Columns.Add("KSTHLAM");
            TbTieuDe.Columns.Add("DSNQANH");
            TbTieuDe.Columns.Add("DSNTVAN");
            TbTieuDe.Columns.Add("TTVBAN");
            TbTieuDe.Columns.Add("NNHAN");
            TbTieuDe.Columns.Add("PDBCLUONG");
            TbTieuDe.Columns.Add("PXCDIEN");
            TbTieuDe.Columns.Add("TTSPHAM");
            TbTieuDe.Columns.Add("MSP");
            TbTieuDe.Columns.Add("KTHUOC");
            TbTieuDe.Columns.Add("SSKTHUOC");
            TbTieuDe.Columns.Add("TSP");
            TbTieuDe.Columns.Add("TLUONG");
            TbTieuDe.Columns.Add("SSTLUONG");
            TbTieuDe.Columns.Add("TPHAN");
            TbTieuDe.Columns.Add("TTNCCAP");
            TbTieuDe.Columns.Add("STT");
            TbTieuDe.Columns.Add("TEN");
            TbTieuDe.Columns.Add("NCCAP");
            TbTieuDe.Columns.Add("DCHI");
            TbTieuDe.Columns.Add("HLUONG");
            TbTieuDe.Columns.Add("TSO");
            TbTieuDe.Columns.Add("GCHU");
            TbTieuDe.Columns.Add("TSKTTBI");
            TbTieuDe.Columns.Add("BUOC");
            TbTieuDe.Columns.Add("MSMAY");
            TbTieuDe.Columns.Add("TMAY");
            TbTieuDe.Columns.Add("HTHONG");
            TbTieuDe.Columns.Add("GTRI");
            TbTieuDe.Columns.Add("MIN");
            TbTieuDe.Columns.Add("MAX");
            TbTieuDe.Columns.Add("DON_VI_DO");
            TbTieuDe.Columns.Add("TT_LY_DO_TD");


            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["DON_VI_DO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "DON_VI_DO", Commons.Modules.TypeLanguage);
            rTitle["TT_LY_DO_TD"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TT_LY_DO_TD", Commons.Modules.TypeLanguage);
            rTitle["CTY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "CTY", Commons.Modules.TypeLanguage);
            rTitle["TDE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TDE", Commons.Modules.TypeLanguage);
            rTitle["TRANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TRANG", Commons.Modules.TypeLanguage);
            rTitle["SOPO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "SOPO", Commons.Modules.TypeLanguage);
            rTitle["NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "NGAY", Commons.Modules.TypeLanguage);
            rTitle["NSOAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "NSOAN", Commons.Modules.TypeLanguage);
            rTitle["PXUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "PXUONG", Commons.Modules.TypeLanguage);
            rTitle["GDCLDUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "GDCLDUYET", Commons.Modules.TypeLanguage);
            rTitle["KSTHLAM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KSTHLAM", Commons.Modules.TypeLanguage);
            rTitle["DSNQANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "DSNQANH", Commons.Modules.TypeLanguage);
            rTitle["DSNTVAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "DSNTVAN", Commons.Modules.TypeLanguage);
            rTitle["TTVBAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TTVBAN", Commons.Modules.TypeLanguage);
            rTitle["NNHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "NNHAN", Commons.Modules.TypeLanguage);
            rTitle["PDBCLUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "PDBCLUONG", Commons.Modules.TypeLanguage);
            rTitle["PXCDIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "PXCDIEN", Commons.Modules.TypeLanguage);
            rTitle["TTSPHAM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TTSPHAM", Commons.Modules.TypeLanguage);
            rTitle["MSP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "MSP", Commons.Modules.TypeLanguage);
            rTitle["KTHUOC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KTHUOC", Commons.Modules.TypeLanguage);
            rTitle["SSKTHUOC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "SSKTHUOC", Commons.Modules.TypeLanguage);
            rTitle["TSP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TSP", Commons.Modules.TypeLanguage);
            rTitle["TLUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TLUONG", Commons.Modules.TypeLanguage);
            rTitle["SSTLUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "SSTLUONG", Commons.Modules.TypeLanguage);
            rTitle["TPHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TPHAN", Commons.Modules.TypeLanguage);
            rTitle["TTNCCAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TTNCCAP", Commons.Modules.TypeLanguage);
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "STT", Commons.Modules.TypeLanguage);
            rTitle["TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TEN", Commons.Modules.TypeLanguage);
            rTitle["NCCAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "NCCAP", Commons.Modules.TypeLanguage);
            rTitle["DCHI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "DCHI", Commons.Modules.TypeLanguage);
            rTitle["HLUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "HLUONG", Commons.Modules.TypeLanguage);
            rTitle["TSO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TSO", Commons.Modules.TypeLanguage);
            rTitle["GCHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "GCHU", Commons.Modules.TypeLanguage);
            rTitle["TSKTTBI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TSKTTBI", Commons.Modules.TypeLanguage);
            rTitle["BUOC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "BUOC", Commons.Modules.TypeLanguage);
            rTitle["MSMAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "MSMAY", Commons.Modules.TypeLanguage);
            rTitle["TMAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "TMAY", Commons.Modules.TypeLanguage);
            rTitle["HTHONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "HTHONG", Commons.Modules.TypeLanguage);
            rTitle["GTRI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "GTRI", Commons.Modules.TypeLanguage);
            rTitle["MIN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "MIN", Commons.Modules.TypeLanguage);
            rTitle["MAX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "MAX", Commons.Modules.TypeLanguage);

            TbTieuDe.TableName = "TD_TTSP";
            TbTieuDe.Rows.Add(rTitle);
            frmTTSP.AddDataTableSource(TbTieuDe);
            frmTTSP.ShowDialog(this);            
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            ShowReport("rptMThongTinSanPham");
        }

        private void btnCH_Click(object sender, EventArgs e)
        {
            if (btnGhi.Visible == false) return;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            try
            {
                DialogResult res = f.ShowDialog();
                if (res.Equals(DialogResult.Cancel))
                    return;
            }
            catch
            {
                return;
            }
            try
            {
                imgHinh.Image = Image.FromFile(f.FileName);
                txtH.Text = f.FileName;
            }
            catch
            { 
            }
        }

        private void btnXoaH_Click(object sender, EventArgs e)
        {
            imgHinh.Image = null;
            txtH.Text = "";
        }

        private void btnDDH_DoubleClick(object sender, EventArgs e)
        {
            if (btnGhi.Visible) return;
            if (string.IsNullOrEmpty(btnDDH.Text)) return;
            try
            {
                System.Diagnostics.Process.Start(btnDDH.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void imgHinh_DoubleClick(object sender, EventArgs e)
        {

            if (btnThem.Visible)
            {
                if (string.IsNullOrEmpty(grvData.GetFocusedDataRow()["HINH"].ToString())) return;
                frmHinh frm = new frmHinh();
                DataTable dt = new DataTable();
                dt.Columns.Add("HINH", typeof(System.Byte[]));
                dt.Rows.Add();
                dt.Rows[0][0] = grvData.GetFocusedDataRow()["HINH"];

                frm.bdSP = new BindingSource();
                frm.bdSP.DataSource = dt;

                frm.ShowDialog();
                
            }
        }

        private void txtDDan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (btnGhi.Visible == false) return;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "All files (*.*)|*.*";
            try
            {
                DialogResult res = f.ShowDialog();
                if (res.Equals(DialogResult.Cancel))
                    return;
            }
            catch
            {
                return;
            }

            if (PathQTCN == "") PathQTCN = Commons.Modules.ObjSystems.CapnhatTL(true, "TTSP\\QTCN");
            txtDDan.Text = PathQTCN + "\\" + "QTCN_" + txtID.Text + Commons.Modules.ObjSystems.LayDuoiFile(f.FileName);
            txtTLQTCN.Text = f.FileName;
        }

        private void txtDDan_DoubleClick(object sender, EventArgs e)
        {
            if (btnGhi.Visible) return;
            if (string.IsNullOrEmpty(txtDDan.Text)) return;
            try
            {
                System.Diagnostics.Process.Start(txtDDan.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void btnIn2_Click(object sender, EventArgs e)
        {
            ShowReport("rptMThongTinSanPham_KH");
        }

        private void grvQTCN_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            

        }

        private void grvQTCN_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (btnGhi.Visible == false) return;
                

            if (e.PrevFocusedColumn.ColumnHandle != 0) return;
            try
            {
                int SoLan = 0;
                GridView view = sender as GridView;
                GridColumn ColBuoc = view.Columns["BUOC"];
                view.SetColumnError(ColBuoc, "");
                try
                {
                    for (int i = 0; i <= grvQTCN.RowCount; i++)
                    {
                        try
                        {
                            if (grvQTCN.GetDataRow(i)["BUOC"].ToString() != "")
                            {
                                if (int.Parse(grvQTCN.GetDataRow(i)["BUOC"].ToString()) == int.Parse(grvQTCN.GetDataRow(grvQTCN.FocusedRowHandle)["BUOC"].ToString()))
                                {
                                    SoLan++;
                                }
                            }
                        }
                        catch { }
                    }
                    if (SoLan > 1)
                        view.SetColumnError(ColBuoc, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "DaChonBuoc",
                            Commons.Modules.TypeLanguage));
                    //MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "DaChonBuoc", Commons.Modules.TypeLanguage));                                
                    return;
                }
                catch { }
            }
            catch { }            
        }


    }

}