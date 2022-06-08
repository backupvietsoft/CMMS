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
    public partial class frmLichTau : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bdLTau;
        int IDTauTB;
        DataTable dtList = new DataTable();
        DataTable dtLTTB = new DataTable();
        public frmLichTau()
        {
            InitializeComponent();
        }

        private void frmLichTau_Load(object sender, EventArgs e)
        {
            LockUnLock(false);
            GetLuoi(-1);
            GetLuoiTB(-1);
            Commons.Modules.ObjSystems.ThayDoiNN(this);            
            chkDXong.Text = "";

        }

        private void GetLuoi(int IDLTau)
        {
            dtList = new DataTable();
            dtList.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetLichTau"));
            dtList.PrimaryKey = new DataColumn[] { dtList.Columns["STT"] };
            
            bdLTau = new BindingSource();
            bdLTau.DataSource = dtList.DefaultView;
            grdLTau.DataSource = bdLTau;
            
            //grvLTau.PopulateColumns();
            
            grvLTau.OptionsView.AllowHtmlDrawHeaders = true;
            grvLTau.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;


            if (IDLTau != -1)
            {
                int index = dtList.Rows.IndexOf(dtList.Rows.Find(IDLTau));
                grvLTau.FocusedRowHandle = grvLTau.GetRowHandle(index);
            }

            txtCTau.DataBindings.Clear();
            txtCTau.DataBindings.Add("Text", bdLTau, "TEN_CHUYEN_TAU");

            datCNCuoi.DataBindings.Clear();
            datCNCuoi.DataBindings.Add("DateTime", bdLTau, "NGAY_CAP_NHAT_CUOI", true);

            txtDXong.DataBindings.Clear();
            txtDXong.DataBindings.Add("Text", bdLTau, "DA_XONG", true);
            txtDXong.Visible = false;

            datTN.DataBindings.Clear();
            datTN.DataBindings.Add("DateTime", bdLTau, "TU_NGAY", true);

            datTGio.DataBindings.Clear();
            datTGio.DataBindings.Add("EditValue", bdLTau, "TU_GIO", true);


            datDNgay.DataBindings.Clear();
            datDNgay.DataBindings.Add("DateTime", bdLTau, "DEN_NGAY", true);

            datDGio.DataBindings.Clear();
            datDGio.DataBindings.Add("Text", bdLTau, "DEN_GIO", true);

            txtBen.DataBindings.Clear();
            txtBen.DataBindings.Add("Text", bdLTau, "BEN");

            txtGChu.DataBindings.Clear();
            txtGChu.DataBindings.Add("Text", bdLTau, "GHI_CHU");

            txtSTT.DataBindings.Clear();
            txtSTT.DataBindings.Add("Text", bdLTau, "STT");
            txtSTT.Visible = false;

            if (grvLTau.Columns["STT"].Visible == false) return;
            grvLTau.Columns["STT"].Visible = false;
            grvLTau.Columns["TU_NGAY"].Visible = false;
            grvLTau.Columns["TU_GIO"].Visible = false;
            grvLTau.Columns["DEN_NGAY"].Visible = false;
            grvLTau.Columns["DEN_GIO"].Visible = false;
            grvLTau.Columns["GHI_CHU"].Visible = false;
            grvLTau.Columns["BEN"].Visible = false;
            grvLTau.Columns["NGAY_CAP_NHAT_CUOI"].Visible = false;
            grvLTau.Columns["DA_XONG"].Visible = false;
            grvLTau.BestFitColumns();
            grvLTau.OptionsView.ColumnAutoWidth = true;
        }
        private void GetLuoiTB(int IDLTTB)
        {
            if (txtSTT.Text == "") txtSTT.Text = "-1";
            if (grvLTau.RowCount  == 0) txtSTT.Text = "-1";

            dtLTTB = new DataTable();
            dtLTTB.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetLichTauTB", int.Parse(txtSTT.Text)));
            dtLTTB.PrimaryKey = new DataColumn[] { dtLTTB.Columns["ID"] };
            


            grdTTB.DataSource = dtLTTB;
            //grvTTB.PopulateColumns();
            grvTTB.OptionsView.ColumnAutoWidth = true;
            grvTTB.OptionsView.AllowHtmlDrawHeaders = true;
            grvTTB.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            DataTable dtMay = new DataTable();
            dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT DISTINCT MS_MAY, TEN_MAY FROM dbo.MAY ORDER BY MS_MAY"));

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboMay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboMay.NullText = "";
            cboMay.ValueMember = "MS_MAY";
            cboMay.DisplayMember = "MS_MAY";
            cboMay.DataSource = dtMay;
            cboMay.Columns.Clear();
            cboMay.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_MAY"));
            grvTTB.Columns["MS_MAY"].ColumnEdit = cboMay;
            cboMay.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(cboMay_EditValueChanging);

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboTenMay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboTenMay.NullText = "";
            cboTenMay.ValueMember = "MS_MAY";
            cboTenMay.DisplayMember = "TEN_MAY";
            cboTenMay.DataSource = dtMay;
            cboTenMay.Columns.Clear();
            cboTenMay.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_MAY"));
            grvTTB.Columns["TEN_MAY"].ColumnEdit = cboTenMay;
            cboTenMay.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(cboTenMay_EditValueChanging);
                                               
            DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit colTGio = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            colTGio.Name = "colTGio";
            colTGio.NullText = "00:00";
            colTGio.Mask.EditMask = "HH:mm";
            colTGio.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            colTGio.Mask.UseMaskAsDisplayFormat = true;
            grvTTB.Columns["TU_GIO"].ColumnEdit = colTGio;

            DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit colDgio = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            colDgio.Name = "colDgio";
            colDgio.NullText = "00:00";
            colDgio.Mask.EditMask = "HH:mm";
            colDgio.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            colDgio.Mask.UseMaskAsDisplayFormat = true;
            grvTTB.Columns["DEN_GIO"].ColumnEdit = colDgio;

            if (IDLTTB != -1)
            {
                int index = dtLTTB.Rows.IndexOf(dtLTTB.Rows.Find(IDLTTB));
                grvTTB.FocusedRowHandle = grvTTB.GetRowHandle(index);
            }

            if (grvTTB.Columns["STT"].Visible == false) return;
            grvTTB.Columns["STT"].Visible = false;
            grvTTB.Columns["ID"].Visible = false;
            grvTTB.Columns["MS_MAY_OLD"].Visible = false;
            grvTTB.Columns["TU_NGAY_OLD"].Visible = false;
            grvTTB.Columns["TU_GIO_OLD"].Visible = false;

            grvTTB.BestFitColumns();
            grvTTB.Columns["MS_MAY"].Width = 180;
            grvTTB.Columns["TEN_MAY"].Width = 340;
            grvTTB.Columns["TU_NGAY"].Width = 120;
            grvTTB.Columns["TU_GIO"].Width = 100;
            grvTTB.Columns["DEN_NGAY"].Width = 120;
            grvTTB.Columns["DEN_GIO"].Width = 100;


        }
        private void cboMay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                grvTTB.GetFocusedDataRow()["TEN_MAY"] = e.NewValue.ToString();

            }
            catch { }
        }

        private void cboTenMay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {

                grvTTB.GetFocusedDataRow()["MS_MAY"] = e.NewValue.ToString();

            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                bdLTau.AddNew();
                LockUnLock(true);
                txtSTT.Properties.ReadOnly = true;
                datCNCuoi.DateTime = DateTime.Now;

                datTN.DateTime = DateTime.Now;
                datTGio.Text = DateTime.Now.TimeOfDay.ToString().Substring(0, 5);
                datDNgay.DateTime = DateTime.Now;
                datDGio.Text = DateTime.Now.TimeOfDay.ToString().Substring(0, 5);
                txtCTau.Focus();
                IDTauTB = grvTTB.RowCount;
            }
            catch { }

        }

        private void txtDXong_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDXong.Text == "True") chkDXong.Checked = true; else chkDXong.Checked = false;

        }

        private void LocData()
        {
            try
            {
                string dk = "";
                if (optChon.SelectedIndex.Equals(1)) dk = " AND DA_XONG = 1";
                if (optChon.SelectedIndex.Equals(2)) dk = " AND DA_XONG = 0";
                


                if (txtTKiem.Text.Length != 0) dk = " AND TEN_CHUYEN_TAU LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtList.DefaultView.RowFilter = dk;
                
            }
            catch { dtList.DefaultView.RowFilter = ""; }

            GetLuoiTB(-1);
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LocData();
        }

        private void LockUnLock(Boolean mLock)
        {

            txtCTau.Properties.ReadOnly = !mLock;
            datCNCuoi.Properties.ReadOnly = !mLock;
            txtDXong.Properties.ReadOnly = !mLock;
            chkDXong.Properties.ReadOnly = !mLock;
            datTN.Properties.ReadOnly = !mLock;
            datTGio.Properties.ReadOnly = !mLock;
            datDNgay.Properties.ReadOnly = !mLock;
            datDGio.Properties.ReadOnly = !mLock;
            txtBen.Properties.ReadOnly = !mLock;
            txtGChu.Properties.ReadOnly = !mLock;
            txtSTT.Properties.ReadOnly = !mLock;

            optChon.Properties.ReadOnly = mLock;

            grdLTau.Enabled = !mLock;

            btnThem.Visible = !mLock;
            btnSua.Visible = !mLock;
            btnXoa.Visible = !mLock;
            btnExit.Visible = !mLock;

            btnGhi.Visible = mLock;
            btnKhong.Visible = mLock;
            btnChonMay.Visible = mLock;

            
            grvTTB.OptionsBehavior.Editable = mLock;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                LockUnLock(true);
                txtCTau.Focus();
                IDTauTB = grvTTB.RowCount;
            }
            catch { }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!KiemDL()) return;
            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            SqlTransaction tran;
            if (con.State == ConnectionState.Closed)
                con.Open();
            tran = con.BeginTransaction();

            try
            {

#region Lich Tau
                if (!KiemLTau())
                {
                    tran.Rollback();
                    con.Close();
                    return;
                }
                int STT;
                if (chkDXong.Checked) STT = 1; else STT = 0;

                if (txtSTT.Properties.ReadOnly == false)
                {//sua
                    SqlHelper.ExecuteScalar(tran, "MAddLichTau", Convert.ToInt32(txtSTT.Text),
                                txtCTau.Text.ToString(), datTN.DateTime, datTGio.Text,
                                datDNgay.DateTime, datDGio.Text, txtGChu.Text,txtBen.Text, datCNCuoi.DateTime,STT);
                    STT = int.Parse(txtSTT.Text);
                }
                else
                {//them moi  
                    STT = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, "MAddLichTau", Convert.ToInt32(-1),
                                txtCTau.Text.ToString(), datTN.DateTime, datTGio.Text,
                                datDNgay.DateTime, datDGio.Text, txtGChu.Text, txtBen.Text, datCNCuoi.DateTime, STT));
                }

#endregion

#region Lich Tau TB
    #region Kiem DL

                for (int i = 0; i < grvTTB.RowCount; i++)
                {
                    string MsMay;
                    if (grvTTB.GetDataRow(i)["MS_MAY"].ToString() == "")
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "MS_MAY", Commons.Modules.TypeLanguage));
                        tran.Rollback();
                        con.Close();
                        return;
                    }
                    else
                    {
                        MsMay = grvTTB.GetDataRow(i)["MS_MAY"].ToString();
                    }

                    DateTime TNgay;
                    if (grvTTB.GetDataRow(i)["TU_NGAY"].ToString() == "")
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "TU_NGAY", Commons.Modules.TypeLanguage));
                        tran.Rollback();
                        con.Close();
                        return;
                    }
                    else
                    {
                        TNgay = DateTime.Parse(grvTTB.GetDataRow(i)["TU_NGAY"].ToString());
                    }

                    DateTime TGio;
                    if (grvTTB.GetDataRow(i)["TU_GIO"].ToString() == "")
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "TU_GIO", Commons.Modules.TypeLanguage));
                        tran.Rollback();
                        con.Close();
                        return;
                    }
                    else
                    {
                        TGio = DateTime.Parse(grvTTB.GetDataRow(i)["TU_GIO"].ToString());
                    }

                    DateTime DNgay;
                    if (grvTTB.GetDataRow(i)["DEN_NGAY"].ToString() == "")
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "DEN_NGAY", Commons.Modules.TypeLanguage));
                        tran.Rollback();
                        con.Close();
                        return;
                    }
                    else
                    {
                        DNgay = DateTime.Parse(grvTTB.GetDataRow(i)["DEN_NGAY"].ToString());
                    }

                    DateTime DGio;
                    if (grvTTB.GetDataRow(i)["DEN_GIO"].ToString() == "")
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "DEN_GIO", Commons.Modules.TypeLanguage));
                        tran.Rollback();
                        con.Close();
                        return;
                    }
                    else
                    {
                        DGio = DateTime.Parse(grvTTB.GetDataRow(i)["DEN_GIO"].ToString());
                    }



                    DateTime TNgayOld = DateTime.Parse("01/01/1900");
                    if (grvTTB.GetDataRow(i)["TU_NGAY_OLD"].ToString() != "")
                    {
                        TNgayOld = DateTime.Parse(grvTTB.GetDataRow(i)["TU_NGAY_OLD"].ToString());
                    }

                    DateTime TGioOld = DateTime.Parse("01/01/1900 00:00:00");
                    if (grvTTB.GetDataRow(i)["TU_GIO_OLD"].ToString() != "")
                    {
                        TGioOld = DateTime.Parse(grvTTB.GetDataRow(i)["TU_GIO_OLD"].ToString());
                    }

                    DateTime TNgayK, DNgayK;
                    try
                    {
                        TNgayK = Convert.ToDateTime(TNgay.Date.ToShortDateString() + " " + TGio.TimeOfDay.ToString());
                    }
                    catch { TNgayK = TNgay.Date; }

                    try
                    {
                        DNgayK = Convert.ToDateTime(DNgay.Date.ToShortDateString() + " " + DGio.TimeOfDay.ToString());
                    }
                    catch { DNgayK = DNgay.Date; }

                    if (TNgayK > DNgayK)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                        tran.Rollback();
                        con.Close();                        
                        return;
                    }



    #endregion

                    CapNhap(tran, STT, MsMay, TNgay, TGio, DNgay, DGio, grvTTB.GetDataRow(i)["MS_MAY_OLD"].ToString(), TNgayOld, TGioOld);

                }

#endregion

                tran.Commit();
                bdLTau.EndEdit();
                LockUnLock(false);
                GetLuoi(STT);
                GetLuoiTB(-1);

            }
            catch 
            {

                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "CapNhapKhongThanhCong", Commons.Modules.TypeLanguage));
                tran.Rollback();
                con.Close();
            }

        }
        private void CapNhap( SqlTransaction Sqltran, int STT, string MS_MAY, DateTime TU_NGAY, DateTime TU_GIO, 
            DateTime DEN_NGAY, DateTime DEN_GIO, string MS_MAY_OLD, DateTime TU_NGAY_OLD, DateTime TU_GIO_OLD)
        {
            string sql;
            if (MS_MAY_OLD == "-1")
            {
                sql = "INSERT INTO [LICH_TAU_THIET_BI]([STT],[MS_MAY],[TU_NGAY],[TU_GIO],[DEN_NGAY],[DEN_GIO]) " +
                            " VALUES(" + STT + " , '" + MS_MAY + "' , '" + TU_NGAY.ToString ("MM/dd/yyyy") + "' , " +
                            " '" + TU_GIO.ToString("MM/dd/yyyy HH:mm:ss") + "' , '" + DEN_NGAY.ToString("MM/dd/yyyy") + "' , " +
                            " '" + DEN_GIO.ToString("MM/dd/yyyy HH:mm:ss") + "' ) ";
            }
            else
            {
                sql = "UPDATE LICH_TAU_THIET_BI SET MS_MAY = '" + MS_MAY + "' , TU_NGAY = '" + TU_NGAY.ToString("MM/dd/yyyy") + "' , TU_GIO = '" + TU_GIO.ToString("MM/dd/yyyy HH:mm:ss") + "' ," +
                            " DEN_NGAY = '" +  Commons.Modules.ObjSystems.DoiDDNgay( DEN_NGAY.ToString() ) + "' , DEN_GIO = '" + DEN_GIO.ToString("MM/dd/yyyy HH:mm:ss") + "' " +
                            " WHERE STT = " + STT + " AND MS_MAY = '" + MS_MAY_OLD + "' AND TU_NGAY = '" + Commons.Modules.ObjSystems.DoiDDNgay(TU_NGAY_OLD.ToString()) + "' AND TU_GIO = '" + TU_GIO_OLD.ToString("MM/dd/yyyy HH:mm:ss") + "' ";
            }

            SqlHelper.ExecuteNonQuery(Sqltran, CommandType.Text, sql);

        }


        private Boolean KiemLTau()
        {

            if (txtCTau.Text.ToString().Trim() == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "ChuaNhapTenTau", Commons.Modules.TypeLanguage));
                txtCTau.Focus();
                return false;
            }
            if (datTN.Text.ToString().Trim() == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "ChuaNhapTNgay", Commons.Modules.TypeLanguage));
                datTN.Focus();
                return false;
            }

            if (datTGio.Text.ToString().Trim() == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "ChuaNhapTGio", Commons.Modules.TypeLanguage));
                datTGio.Focus();
                return false;
            }
            else
            {
                if (!KiemGio(datTGio.Text))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "NhapTGioSai", Commons.Modules.TypeLanguage));
                    datTGio.Focus();
                    return false;
                }            
            }

            if (datDNgay.Text.ToString().Trim() == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "ChuaNhapDNgay", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return false;
            }
            if (datDGio.Text.ToString().Trim() == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "ChuaNhapDGio", Commons.Modules.TypeLanguage));
                datDGio.Focus();
                return false;
            }
            else
            {
                if (!KiemGio(datTGio.Text))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "NhapDGioSai", Commons.Modules.TypeLanguage));
                    datDGio.Focus();
                    return false;
                }
            }

            DateTime TNgay, DNgay;
            try
            {
                TNgay = Convert.ToDateTime(datTN.DateTime.Date.ToShortDateString() + " " + datTGio.Text);
            }
            catch { TNgay = datTN.DateTime; }

            try
            {
                DNgay = Convert.ToDateTime(datDNgay.DateTime.Date.ToShortDateString() + " " + datDGio.Text);
            }
            catch { DNgay = datTN.DateTime; }
            if (TNgay > DNgay)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                datTN.Focus();
                return false;
            }

            return true;
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {

            bdLTau.CancelEdit();
            LockUnLock(false);
            GetLuoiTB(-1);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvLTau_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (txtSTT.Text == "") txtSTT.Text = "-1";
            GetLuoiTB(-1);
        }

        private void btnChonMay_Click(object sender, EventArgs e)
        {
            frmChonMay frm = new frmChonMay();
            frm.TuNgay = datTN.DateTime;
            frm.DenNgay = datTN.DateTime;
            frm.TuGio = datTGio.Text;
            frm.DenGio = datDGio.Text;

            if (frm.ShowDialog() != DialogResult.OK) return;
            DataTable dtTmp = new DataTable();
            frm.dtChonMay.DefaultView.RowFilter = "CHON = TRUE";
            dtTmp =  frm.dtChonMay.DefaultView.ToTable ();

            DataRow rowTTB = dtLTTB.NewRow();
            foreach (DataRow row in frm.dtChonMay.DefaultView.ToTable().Rows)
            {
                IDTauTB++;
                rowTTB["MS_MAY"] = row["MS_MAY"];
                rowTTB["TEN_MAY"] = row["MS_MAY"];
                rowTTB["TU_NGAY"] = frm.TuNgay;
                rowTTB["TU_GIO"] = frm.TuGio;
                rowTTB["DEN_NGAY"] = frm.DenNgay;
                rowTTB["DEN_GIO"] = frm.DenGio;
                rowTTB["STT"] = txtSTT.Text;
                rowTTB["ID"] = IDTauTB;//txtSTT.Text + rowTTB["MS_MAY"].ToString() + frm.TuNgay.Date.ToString().Substring(0, 10) + frm.TuGio;
                rowTTB["MS_MAY_OLD"] = "-1";
                rowTTB["TU_NGAY_OLD"] = "01/01/1900";
                rowTTB["TU_GIO_OLD"] = "01/01/1900 00:00:00";
                dtLTTB.Rows.Add(rowTTB);
                rowTTB = dtLTTB.NewRow();
            }

        }

        private Boolean KiemGio(string GioKiem)
        {
            if (int.Parse(GioKiem.ToString().Substring(0, 2)) > 24 || int.Parse(GioKiem.ToString().Substring(0, 2)) < 0)
                return false;
            if (int.Parse(GioKiem.ToString().Substring(3, 2)) > 59 || int.Parse(GioKiem.ToString().Substring(3, 2)) < 0)
                return false;

            return true;
        }

        private void optChon_Click(object sender, EventArgs e)
        {

        }

        private void txtTKiem_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void optChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocData();
        }

        private void btnTV_Click(object sender, EventArgs e)
        {
            btnXoaLT.Visible = false;
            btnXoaLTTB.Visible = false;
            btnXoa1LTTB.Visible = false;
            btnTV.Visible = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnXoaLT.Visible = true;
            btnXoaLTTB.Visible = true;
            btnXoa1LTTB.Visible = true;
            btnTV.Visible = true;
        }

        private void btnXoaLT_Click(object sender, EventArgs e)
        {
            if (grvLTau.RowCount <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "KhongCoDuLieuXoa",
                        Commons.Modules.TypeLanguage));
                return;

            }
            if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "CoXoaLichTau",
                Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (grvTTB.RowCount > 0)
            {
                if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "ConMayCoMuonXoaLuon",
                    Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }

            string sSql;

            sSql = "DELETE FROM LICH_TAU_THIET_BI WHERE (STT = " + int.Parse(txtSTT.Text) + " ) AND (MS_MAY = N'1') AND (TU_NGAY = 1) AND (TU_GIO = 1)";

            //Xoa TB Lich tau
            sSql = "DELETE FROM LICH_TAU_THIET_BI WHERE (STT = " + int.Parse(txtSTT.Text) + " )";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

            //Xoa Lich tau
            sSql = "DELETE FROM LICH_TAU WHERE (STT = " + int.Parse(txtSTT.Text) + " )";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
            GetLuoi(-1);
            GetLuoiTB(-1);

        }

        private void btnXoaLTTB_Click(object sender, EventArgs e)
        {
            if (grvLTau.RowCount <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "KhongCoDuLieuXoa",
                        Commons.Modules.TypeLanguage));
                return;
            }
            if (grvTTB.RowCount <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "KhongCoDuLieuTBXoa",
                        Commons.Modules.TypeLanguage));
                return;
            }

            if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "CoXoaHetThietBi",
                Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            string sSql;

            sSql = "DELETE FROM LICH_TAU_THIET_BI WHERE (STT = " + int.Parse(txtSTT.Text) + " ) AND (MS_MAY = N'1') AND (TU_NGAY = 1) AND (TU_GIO = 1)";

            //Xoa TB Lich tau
            sSql = "DELETE FROM LICH_TAU_THIET_BI WHERE (STT = " + int.Parse(txtSTT.Text) + " )";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

            GetLuoiTB(-1);

        }

        private void btnXoa1LTTB_Click(object sender, EventArgs e)
        {
            if (grvLTau.RowCount <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "KhongCoDuLieuXoa",
                        Commons.Modules.TypeLanguage));
                return;
            }
            if (grvTTB.RowCount <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "KhongCoDuLieuTBXoa",
                        Commons.Modules.TypeLanguage));
                return;

            }

            if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "CoXoaThietBiNay",
                Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            string sSql;

            sSql = "DELETE FROM LICH_TAU_THIET_BI WHERE (STT = " + int.Parse(txtSTT.Text) + " ) " +
                        " AND (MS_MAY = N'" +  grvTTB.GetFocusedDataRow()["MS_MAY"].ToString()  + "') " +
                        " AND (TU_NGAY = '" + DateTime.Parse(grvTTB.GetFocusedDataRow()["TU_NGAY"].ToString()).ToString("MM/dd/yyyy")  + "' ) " +
                        " AND (TU_GIO = '" + DateTime.Parse(grvTTB.GetFocusedDataRow()["TU_GIO"].ToString()).ToString("MM/dd/yyyy HH:mm:ss") + "')";

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
            GetLuoiTB(-1);
        }
        private Boolean KiemDL()
        {
            int col = 0;
            DataTable dtMay = new DataTable();
            Boolean KiemDL = false;
            Boolean KiemTra = true;
            foreach (DataRow dr in dtLTTB.Rows)
            {
                KiemDL = false;
                dr.ClearErrors();
                dtMay = new DataTable();
                dtMay = dtLTTB.DefaultView.ToTable().Copy();
                dtMay.DefaultView.RowFilter = "MS_MAY = '" + dr["MS_MAY"].ToString() + "'";
                dtMay = dtMay.DefaultView.ToTable(true, "MS_MAY", "TU_NGAY", "TU_GIO", "ID").Copy();
                dtMay.DefaultView.Sort = "MS_MAY, TU_NGAY, TU_GIO";
                foreach (DataRow drTmp in dtMay.Rows)
                {
                    if (dr["ID"].ToString() != drTmp["ID"].ToString())
                    {

                        DateTime TNgay, DNgay, Ngay, Gio;
                        TNgay = DateTime.Now;
                        DNgay = DateTime.Now;
                        Ngay = Convert.ToDateTime(dr["TU_NGAY"].ToString());
                        Gio = Convert.ToDateTime(dr["TU_GIO"].ToString());

                        try
                        {
                            TNgay = Convert.ToDateTime(Ngay.Date.ToShortDateString() + " " + Gio.TimeOfDay.ToString());
                        }
                        catch { }

                        Ngay = Convert.ToDateTime(drTmp["TU_NGAY"].ToString());
                        Gio = Convert.ToDateTime(drTmp["TU_GIO"].ToString());
                        try
                        {
                            DNgay = Convert.ToDateTime(Ngay.Date.ToShortDateString() + " " + Gio.TimeOfDay.ToString());
                        }
                        catch { }
                        
                        if (dr["MS_MAY"].ToString() == drTmp["MS_MAY"].ToString() && TNgay == DNgay )
                        {
                            KiemDL = true;
                            KiemTra = false;
                        }

                    }
                }

                col = 0;
                #region MsMay
                if (KiemDL)
                    dr.SetColumnError(grvTTB.Columns[col].FieldName.ToString(), Commons.Modules.ObjLanguages.GetLanguage(
                        Commons.Modules.ModuleName, "frmLichTau", "TrungDuLieu", Commons.Modules.TypeLanguage));
                else
                {
                    if (dr[grvTTB.Columns[col].FieldName.ToString()].ToString().Length <= 0)
                    {
                        dr.SetColumnError(grvTTB.Columns[col].FieldName.ToString(), Commons.Modules.ObjLanguages.GetLanguage(
                            Commons.Modules.ModuleName, "frmLichTau", "ChuaChonMay", Commons.Modules.TypeLanguage));
                        KiemTra = false;
                    }
                }
                #endregion
                col = 1;
                #region TenMay
                if (KiemDL)
                    dr.SetColumnError(grvTTB.Columns[col].FieldName.ToString(), Commons.Modules.ObjLanguages.GetLanguage(
                        Commons.Modules.ModuleName, "frmLichTau", "TrungDuLieu", Commons.Modules.TypeLanguage));
                else
                {
                    if (dr[grvTTB.Columns[col].FieldName.ToString()].ToString().Length <= 0)
                    {
                        dr.SetColumnError(grvTTB.Columns[col].FieldName.ToString(), Commons.Modules.ObjLanguages.GetLanguage(
                            Commons.Modules.ModuleName, "frmLichTau", "ChuaChonMay", Commons.Modules.TypeLanguage));
                        KiemTra = false;
                    }
                }
                #endregion
                col = 2;
                #region Tu Ngay Gio Den ngay gio

                DateTime TNgayK, DNgayK, Ngay1, Gio1;
                TNgayK = DateTime.Now;
                DNgayK = DateTime.Now;
                Ngay1 = Convert.ToDateTime(dr["TU_NGAY"].ToString());
                Gio1 = Convert.ToDateTime(dr["TU_GIO"].ToString());
                try
                {
                    TNgayK = Convert.ToDateTime(Ngay1.Date.ToShortDateString() + " " + Gio1.TimeOfDay.ToString());
                }
                catch { }

                Ngay1 = Convert.ToDateTime(dr["DEN_NGAY"].ToString());
                Gio1 = Convert.ToDateTime(dr["DEN_GIO"].ToString());
                try
                {
                    DNgayK = Convert.ToDateTime(Ngay1.Date.ToShortDateString() + " " + Gio1.TimeOfDay.ToString());
                }
                catch { }

                if (TNgayK > DNgayK)
                {
                    //MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                    dr.SetColumnError(grvTTB.Columns[col].FieldName.ToString(), Commons.Modules.ObjLanguages.GetLanguage(
                            Commons.Modules.ModuleName, "frmLichTau", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                    dr.SetColumnError(grvTTB.Columns[col + 1].FieldName.ToString(), Commons.Modules.ObjLanguages.GetLanguage(
                            Commons.Modules.ModuleName, "frmLichTau", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));

                    KiemTra = false;

                }
                #endregion


            }
            return KiemTra;
        }

        private void grvTTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {


                if (grvTTB.RowCount == 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTTSP", "KhongDuLieuXoa", Commons.Modules.TypeLanguage));
                    return;
                }

                if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "CoXoaThietBiNay",
                    Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) == DialogResult.No) return;


                if (!btnGhi.Visible)
                {


                    SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        string sSql = "DELETE FROM LICH_TAU_THIET_BI WHERE (STT = " + int.Parse(txtSTT.Text) + " ) " +
                                    " AND (MS_MAY = N'" + grvTTB.GetFocusedDataRow()["MS_MAY"].ToString() + "') " +
                                    " AND (TU_NGAY = '" + DateTime.Parse(grvTTB.GetFocusedDataRow()["TU_NGAY"].ToString()).ToString("MM/dd/yyyy") + "' ) " +
                                    " AND (TU_GIO = '" + DateTime.Parse(grvTTB.GetFocusedDataRow()["TU_GIO"].ToString()).ToString("MM/dd/yyyy HH:mm:ss") + "')";

                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);



                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                    GetLuoiTB(-1);
                }
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                view.DeleteRow(view.FocusedRowHandle);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
        
    }
}