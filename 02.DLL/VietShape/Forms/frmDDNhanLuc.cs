using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Threading;
using System.Reflection;

namespace VietShape
{
    public partial class frmDDNhanLuc : DevExpress.XtraEditors.XtraForm
    {
        public int iID = -1;
        public string sMsDD = "-1", sUserDD = "Admin";
        public DateTime dNgayDD = Convert.ToDateTime("01/01/1900"), dDDTuNgay = Convert.ToDateTime("01/01/2018"), dDDDenNgay = Convert.ToDateTime("02/02/2018"), dDDCVTuNgay = Convert.ToDateTime("01/01/1900"), dDDCVDenNgay = Convert.ToDateTime("01/01/1900");


        public int iNhanLuc = 0;
        public int iMsNhomDD = 0;
        public string sNhomDD = "";

        public string sBTGSTT = "DD_NS_GSTT" + Commons.Modules.UserName;
        public string sBTPBT = "DD_NS_PBT" + Commons.Modules.UserName;
        public string sBTKHTT = "DD_NS_KHTT" + Commons.Modules.UserName;
        public string sBTCVVP = "DD_NS_CVVP" + Commons.Modules.UserName;
        public string sBTDD = "DD_TT_TMP" + Commons.Modules.UserName;
        public string sBTNS = "DD_CHART_NS_TMP" + Commons.Modules.UserName;
        public string sBTNSLuu = "DD_NS" + Commons.Modules.UserName;

        

        private void cboPBan_EditValueChanged(object sender, EventArgs e)
        {
            if (grdNhanLuc.DataSource == null) return;
            NhanVien();
        }
        private void NhanVien()
        {
            if (Commons.Modules.SQLString == "0load") return;
            
            try
            {
                txtNL.Text = iNhanLuc.ToString();
            }
            catch { txtNL.Text = "0"; }
            txtNL_ButtonClick(null, null);
        }
        private void txtGioLV_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            double dTmp = 0;
            try
            { dTmp = double.Parse(txtGioLV.Text); }
            catch { }
            CapNhapLuoi("GIO_LV", dTmp);
        }


        private void CapNhapLuoi(string CotCN, double dCapNhap)
        {
            if (grdNhanLuc.DataSource == null) return;
            try
            {
                DataTable dtTMP = new DataTable();
                dtTMP = (DataTable)grdNhanLuc.DataSource;
                var rowsToUpDate = dtTMP.AsEnumerable().Where(x => int.Parse(x["NGAY_NGHI"].ToString()) == 0)
                                 .ToList();
                foreach (var row in rowsToUpDate.ToList())
                {
                    row[CotCN] = dCapNhap;
                    double dNV = 0;
                    double dGLV = 0;
                    double dHS = 0;
                    try
                    { dNV = double.Parse(row["NV"].ToString()); }
                    catch { }
                    try
                    { dGLV = double.Parse(row["GIO_LV"].ToString()) * 60; }
                    catch { }
                    try
                    { dHS = double.Parse(row["HIEU_SUAT"].ToString()) / 100; }
                    catch { }
                    try
                    { row["SP_NGAY"] = dNV * dGLV * dHS; }
                    catch { }

                    try
                    { row["SO_PHUT_NGAY"] = double.Parse(row["SP_NGAY"].ToString()) - double.Parse(row["SP_DA_DD"].ToString()); }
                    catch { }
                }
                dtTMP.AcceptChanges();
            }
            catch { }

        }
        private void txtNL_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            double dTmp = 0;
            try
            { dTmp = double.Parse(txtNL.Text); }
            catch { }
            CapNhapLuoi("NV", dTmp);
        }

        private void txtHSuat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            double dTmp = 0;
            try
            { dTmp = double.Parse(txtHSuat.Text); }
            catch { }
            CapNhapLuoi("HIEU_SUAT", dTmp);
        }

        private void grvNhanLuc_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (e.Column.Name.ToLower() == "colSO_PHUT_NGAY".ToLower()) return;
            double dNV = 0;
            double dGLV = 0;
            double dHS = 0;
            if (e.Column.Name.ToLower() == "colNV".ToLower() || e.Column.Name.ToLower() == "colGIO_LV".ToLower() || e.Column.Name.ToLower() == "colHIEU_SUAT".ToLower())
            {
                try
                { dNV = double.Parse(grvNhanLuc.GetFocusedRowCellValue("NV").ToString()); }
                catch { }
                try
                { dGLV = double.Parse(grvNhanLuc.GetFocusedRowCellValue("GIO_LV").ToString()) * 60; }
                catch { }
                try
                { dHS = double.Parse(grvNhanLuc.GetFocusedRowCellValue("HIEU_SUAT").ToString()) / 100; }
                catch { }

                try
                {
                    Commons.Modules.SQLString = "0LOAD";
                    grvNhanLuc.SetFocusedRowCellValue("SP_NGAY", dNV * dGLV * dHS);
                    Commons.Modules.SQLString = "";
                }
                catch { }
            }

            double dDaDD = 0;
            try
            { dDaDD = double.Parse(grvNhanLuc.GetFocusedRowCellValue("SP_DA_DD").ToString()); }
            catch { }
            try
            {
                Commons.Modules.SQLString = "0LOAD";
                grvNhanLuc.SetFocusedRowCellValue("SO_PHUT_NGAY", double.Parse(grvNhanLuc.GetFocusedRowCellValue("SP_NGAY").ToString()) - dDaDD);
                Commons.Modules.SQLString = "";
            }
            catch { grvNhanLuc.SetFocusedRowCellValue("SO_PHUT_NGAY", 0); }

            Commons.Modules.SQLString = "";

            
        }


        private void grvNhanLuc_MouseDown(object sender, MouseEventArgs e)
        {
            //If Not clNewRowUser.Contains(info.RowHandle) Then
            //        If(info.Column.Name = "USERNAME") Then
            //            DirectCast(e, DXMouseEventArgs).Handled = True
            //        End If
            //        'If (info.Column.Name = "FULL_NAME") Then
            //        '    DirectCast(e, DXMouseEventArgs).Handled = True
            //        'End If
            //        'If (info.Column.Name = "ACTIVE") Then
            //        '    DirectCast(e, DXMouseEventArgs).Handled = True
            //        'End If
            //    End If
            try
            {
                GridHitInfo info = new GridHitInfo();
                info = grvNhanLuc.CalcHitInfo(e.Location);
                if (info.Column.Name.ToUpper() == "colNGAY".ToUpper())
                {
                    ((DXMouseEventArgs)e).Handled = true;
                }
                if (info.Column.Name.ToUpper() == "colNGAY_THU".ToUpper())
                {
                    ((DXMouseEventArgs)e).Handled = true;
                }
            }
            catch { }
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dtDDDNgay_EditValueChanged(object sender, EventArgs e)
        {
            if(Commons.Modules.SQLString == "0load") return;

            if (dtDDTNgay.DateTime > dtDDDNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTuNgayLonHonDenNgay", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LoadNhanLuc();
        }

        public frmDDNhanLuc()
        {
            InitializeComponent();
        }
        
        private void frmDDNhanLuc_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0load";
            dtDDTNgay.DateTime = dDDTuNgay;
            dtDDDNgay.DateTime = dDDDenNgay;

            txtID.Text = iID.ToString();
            txtMsDD.Text = sMsDD;
            dtNgayDD.DateTime = dNgayDD;
            txtUserDD.Text = sUserDD;
            
            Commons.Modules.SQLString = "";
            NhanVien();
            LoadNhanLuc();
            if(txtID.Text != "-1")
            {
                dtDDTNgay.Properties.ReadOnly = true;
                dtDDDNgay.Properties.ReadOnly = true;

                txtNL.Properties.ReadOnly = true;
                txtGioLV.Properties.ReadOnly = true;
                txtHSuat.Properties.ReadOnly = true;
                txtSPhutDD.Properties.ReadOnly = true;
                btnPhut.Visible = false;
                btnCapNhap.Visible = false;
                Commons.Modules.SQLString = "0load";
                txtNL.Text = sBTKHTT;
                txtGioLV.Text = sBTCVVP;
                txtHSuat.Text = sBTDD;
                txtSPhutDD.Text = sBTNS;

                Commons.Modules.SQLString = "";
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void LoadNhanLuc()
        {

            if (Commons.Modules.SQLString == "0load") return;
            if (txtNL.Text == "") return;
            String sSql = "";
            DataTable dtTmp = new DataTable();

            if (txtID.Text == "-1")
            {
                sSql = "SELECT * FROM " + sBTNSLuu;
                try
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    sSql = "";

                    if (dtTmp.Rows.Count > 0)
                    {
                        Commons.Modules.SQLString = "0load";
                        sSql = "SELECT *, CONVERT(DATETIME,'" + dtDDTNgay.DateTime.Date.ToString("MM/dd/yyyy") + "') AS dtDDTNgay , CONVERT(DATETIME,'" + dtDDDNgay.DateTime.Date.ToString("MM/dd/yyyy") + "') AS dtDDDNgay, CONVERT(FLOAT," + txtNL.Text + ") AS txtNL, CONVERT(FLOAT," + txtGioLV.Text + ") AS txtGioLV, CONVERT(FLOAT," + txtHSuat.Text + ") AS txtHSuat, CONVERT(FLOAT," + txtSPhutDD.Text + ") AS txtSPhutDD INTO " + sBTNSLuu + " FROM " + sBTNS;

                        dtDDTNgay.DateTime = DateTime.Parse(dtTmp.Rows[0]["dtDDTNgay"].ToString());
                        dtDDDNgay.DateTime = DateTime.Parse(dtTmp.Rows[0]["dtDDDNgay"].ToString());
                        

                        txtNL.Text = dtTmp.Rows[0]["txtNL"].ToString();
                        txtGioLV.Text = dtTmp.Rows[0]["txtGioLV"].ToString();
                        txtHSuat.Text = dtTmp.Rows[0]["txtHSuat"].ToString();
                        txtSPhutDD.Text = dtTmp.Rows[0]["txtSPhutDD"].ToString();
                        dtTmp = new DataTable();
                        sSql = "SELECT NGAY, NGAY_THU, NV, GIO_LV, HIEU_SUAT, NGAY_NGHI, NGAY_TUAN, NHANSU, SP_NGAY, SP_DA_DD, SO_PHUT_NGAY FROM " + sBTNSLuu + " ORDER BY NGAY";
                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                        Commons.Modules.SQLString = "";
                        Commons.Modules.ObjSystems.XoaTable(sBTNSLuu);
                    }
                    else
                    {
                        dtTmp = new DataTable();
                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetNgayLV", txtID.Text, dtDDTNgay.DateTime.Date, dtDDDNgay.DateTime.Date, iMsNhomDD, txtHSuat.Text, txtGioLV.Text, txtNL.Text));
                    }
                }
                catch
                {
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetNgayLV", txtID.Text, dtDDTNgay.DateTime.Date, dtDDDNgay.DateTime.Date, iMsNhomDD, txtHSuat.Text, txtGioLV.Text, txtNL.Text));

                }
            }
            else
            {
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetNgayLV", txtID.Text, dtDDTNgay.DateTime.Date, dtDDDNgay.DateTime.Date, iMsNhomDD, txtHSuat.Text, txtGioLV.Text, txtNL.Text));
            }

            if (grdNhanLuc.DataSource == null)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhanLuc, grvNhanLuc, dtTmp, true, true, true, false, true, this.Name);
            }
            else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhanLuc, grvNhanLuc, dtTmp, true, false, true, false, true, this.Name);

            if (txtID.Text != "-1")
                grvNhanLuc.OptionsBehavior.Editable = false;

            for (int i = 2; i <= grvNhanLuc.Columns.Count - 1; i++)
            {
                dtTmp.Columns[i].ReadOnly = false;
                grvNhanLuc.Columns[i].OptionsColumn.ReadOnly = false;
            }
            grvNhanLuc.Columns["NGAY"].OptionsColumn.ReadOnly = true;
            grvNhanLuc.Columns["NGAY_THU"].OptionsColumn.ReadOnly = true;

            if (grvNhanLuc.Columns["NGAY_TUAN"].Visible)
            {
                grvNhanLuc.Columns["NGAY_TUAN"].Visible = false;
                grvNhanLuc.Columns["NGAY_NGHI"].Visible = false;
                grvNhanLuc.Columns["NHANSU"].Visible = false;
            }
        }

        private void btnTinhLaiPhut_Click(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0load") return;
            if (grdNhanLuc.DataSource == null) return;

            double dNV = 0;
            try
            { dNV = double.Parse(txtNL.Text); }
            catch { }

            double dHSuat = 0;
            try
            { dHSuat = double.Parse(txtHSuat.Text); }
            catch { }

            double dGioLV = 0;
            try
            { dGioLV = double.Parse(txtGioLV.Text); }
            catch { }


            if (grdNhanLuc.DataSource == null) return;
            try
            {
                DataTable dtTMP = new DataTable();
                dtTMP = (DataTable)grdNhanLuc.DataSource;
                var rowsToUpDate = dtTMP.AsEnumerable().Where(x => int.Parse(x["NGAY_NGHI"].ToString()) == 0)
                                 .ToList();
                foreach (var row in rowsToUpDate.ToList())
                {
                    row["NV"] = dNV;
                    row["HIEU_SUAT"] = dHSuat;
                    row["GIO_LV"] = dGioLV;

                   
                    try
                    { row["SP_NGAY"] = dNV * (dGioLV * 60) * (dHSuat / 100); }
                    catch { }

                    try
                    { row["SO_PHUT_NGAY"] = double.Parse(row["SP_NGAY"].ToString()) - double.Parse(row["SP_DA_DD"].ToString()); }
                    catch 
                    {
                        //XtraMessageBox.Show(ex.Message);
                    }
                }
                dtTMP.AcceptChanges();
            }
            catch { }


        }


        Thread t = null;
        private delegate void CallProcessBar(object flag);

        private void EnableControl(bool flag)
        {
            btnPhut.Enabled = flag;
            btnChart.Enabled = flag;
            btnThoat.Enabled = flag;
            btnCapNhap.Enabled = flag;


            dtDDTNgay.Properties.ReadOnly = !flag;
            dtDDDNgay.Properties.ReadOnly = !flag;
            
            if (bDD && flag)
            {
                bDD = false;
                frmDDChart frm = new frmDDChart();
                frm.txtID.Text = txtID.Text;
                frm.ShowDialog();
            }
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            string sSql = "";
            DataTable dtTmp = new DataTable();
            sSql = "SELECT TOP 1 * FROM " + sBTDD + " WHERE NGAY_DD IS NULL";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
            if(dtTmp.Rows.Count>0)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
            string sBTNSTmp = "DD_NS_TMP" + Commons.Modules.UserName;
            
            Commons.Modules.ObjSystems.XoaTable(sBTNS);
            
            if (grdNhanLuc.DataSource != null)
            {

                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTNSTmp, (DataTable)grdNhanLuc.DataSource, "");


                
                sSql ="SELECT *, CONVERT(DATETIME,'"  + dtDDTNgay.DateTime.Date.ToString("MM/dd/yyyy") + "') AS dtDDTNgay , CONVERT(DATETIME,'" + dtDDDNgay.DateTime.Date.ToString("MM/dd/yyyy") + "') AS dtDDDNgay,  CONVERT(FLOAT," + txtNL.Text + ") AS txtNL, CONVERT(FLOAT," + txtGioLV.Text + ") AS txtGioLV, CONVERT(FLOAT," + txtHSuat.Text + ") AS txtHSuat, CONVERT(FLOAT," + txtSPhutDD.Text + ") AS txtSPhutDD INTO " + sBTNSLuu + " FROM " + sBTNSTmp;

                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                Commons.Modules.ObjSystems.XoaTable(sBTNSTmp);


                dDDTuNgay = dtDDTNgay.DateTime;
                dDDDenNgay = dtDDDNgay.DateTime;
                DialogResult = DialogResult.OK;
            }
            else
                DialogResult = DialogResult.Cancel;
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "-1")
            {
                frmDDChart frm = new frmDDChart();
                frm.txtID.Text = txtID.Text;
                frm.ShowDialog();
                return;
            }
            DataTable dtTmp = new DataTable();
            string sSql = "";
            string sBT = "DD_CHART_TMP" + Commons.Modules.UserName;
            #region "Kiem da dieu do"
            try
            {
                sSql = " SELECT TOP 1 * FROM " + sBTNS;
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    sSql = " SELECT TOP 1 * FROM " + sBTDD;
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDaDieuDoBanCoMuonDieuDoLai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                        {
                            frmDDChart frm = new frmDDChart();
                            frm.txtID.Text = txtID.Text;
                            frm.ShowDialog();
                            return;
                        }
                    }



                }
            }
            catch { }
            #endregion
            sSql = " UPDATE " + sBTDD + " SET NGAY_DD =  NULL";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

            dtTmp = new DataTable();
            DevExpress.XtraGrid.Views.Base.ColumnView view = grdNhanLuc.FocusedView as DevExpress.XtraGrid.Views.Base.ColumnView;
            view.CloseEditor();
            view.UpdateCurrentRow();


            dtTmp = ((DataTable)grdNhanLuc.DataSource).Copy();

            dtTmp.DefaultView.Sort = "NGAY";
            dtTmp = dtTmp.DefaultView.ToTable();

            if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, dtTmp, ""))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTaoTableDDNSKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            Commons.Modules.ObjSystems.XoaTable(sBTNS);
            sSql = "SELECT NGAY, SP_NGAY,SO_PHUT_NGAY,NV,CONVERT(DATETIME, NULL) AS NGAY_DD, CONVERT(FLOAT, NULL) AS SP_DA_DD, SO_PHUT_NGAY AS SP_CL, CONVERT(INT, NULL) AS MA_SO, CONVERT(INT, NULL) AS LOAI, CONVERT(BIT, 1) AS GOC INTO " + sBTNS + "  FROM " + sBT + " ORDER BY NGAY";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

            BeginInvoke((Action)(() =>
            {
                prbIN.Properties.Stopped = false;
            }));
            bDD = false;
            Thread t = new Thread(new ParameterizedThreadStart(ShowProcessBar));
            t.Start(true);


        }

        private void ShowProcessBar(object flag)
        {
            if (prbIN.InvokeRequired)
            {
                prbIN.Invoke(new CallProcessBar(ShowProcessBar), true);
            }
            else
            {
                BeginInvoke((Action)(() =>
                {
                    prbIN.Properties.Stopped = false;
                    EnableControl(false);
                    this.Cursor = Cursors.WaitCursor;

                }));

                t = new Thread((DieuDo));
                t.Start();

            }

        }

        private bool bDD = false;
        private void DieuDo()
        {

            try
            {
                #region "Cap nhap cac dieu do co ngay khong the doi NGAY_BD_KH = NGAY_TRUOC -- SO_NGAY_PHAI_BD TRONG MUC_UU_TIEN = 0 "
                if (DDKhongDoiNgay())
                {
                    if (DDDoiNgay())
                    {
                        try
                        {
                            BeginInvoke((Action)(() =>
                            {
                                this.Cursor = Cursors.Default;
                                bDD = true;
                                EnableControl(true);
                                prbIN.Properties.Stopped = true;
                            }));
                        }
                        catch { }
                        
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                BeginInvoke((Action)(() =>
                {
                    this.Cursor = Cursors.Default;
                    EnableControl(true);
                    prbIN.Properties.Stopped = true;
                }));

            }
            catch { }

        }

        private bool DDKhongDoiNgay()
        {
            string sSql = "";
            try
            {
                sSql = "SELECT NGAY_KH, NGAY_TRUOC, NGAY_SAU, MA_SO, TG_KH, NGAY_DD,  MS_UU_TIEN,LOAI FROM " + sBTDD + " WHERE NGAY_TRUOC = NGAY_SAU ORDER BY NGAY_KH, MS_UU_TIEN,LOAI";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));

                if (dtTmp.Rows.Count > 0)
                {
                    #region "Cap nhap ngay DD vao bang ngay"
                    foreach (DataRow drRow in dtTmp.Rows)
                    {

                        sSql = "SELECT * FROM " + sBTNS + " WHERE GOC = 1 AND NGAY = '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "' ";
                        DataTable dtDD = new DataTable();
                        dtDD.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                        
                        double dSoPhutNgay = 0;
                        try
                        { dSoPhutNgay = double.Parse(dtDD.Rows[0]["SO_PHUT_NGAY"].ToString()); }
                        catch { }
                        double dspNgay = 0;
                        try
                        { dspNgay = double.Parse(dtDD.Rows[0]["SP_NGAY"].ToString()); }
                        catch { }
                        double dNV = 0;
                        try
                        { dNV = double.Parse(dtDD.Rows[0]["NV"].ToString()); }
                        catch { }



                        double dSoPhutKH = 0;
                        try
                        { dSoPhutKH = double.Parse(drRow["TG_KH"].ToString()); }
                        catch { }
                        try
                        {
                            sSql = "INSERT INTO " + sBTNS + " (NGAY,SP_DA_DD,SO_PHUT_NGAY, NGAY_DD, MA_SO,LOAI,SP_CL,GOC,SP_NGAY,NV) VALUES( '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "', " + dSoPhutKH.ToString() + ", " + dSoPhutNgay.ToString() + ",  '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "', " + drRow["MA_SO"].ToString() + " ,  " + drRow["LOAI"].ToString() + ",0,0," + dspNgay.ToString() + "," + dNV.ToString() + ")";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                        }
                        catch { }

                        sSql = "UPDATE " + sBTNS + " SET SP_CL = CASE WHEN ISNULL(SO_PHUT_NGAY,0) - (SELECT ISNULL(SUM(SP_DA_DD),0) AS SP FROM " + sBTNS + " WHERE NGAY = '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "' AND GOC = 0) <= 0 THEN 0 ELSE ISNULL(SO_PHUT_NGAY,0) - (SELECT ISNULL(SUM(SP_DA_DD),0) AS SP FROM " + sBTNS + " WHERE NGAY = '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "' AND GOC = 0) END WHERE NGAY = '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "' AND GOC = 1 ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                        try
                        {
                            sSql = " UPDATE " + sBTDD + " SET NGAY_DD =  '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "', SO_NGUOI_DD = " + dNV.ToString() + " WHERE MA_SO = " + drRow["MA_SO"].ToString();
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                        }
                        catch { }

                    }
                    #endregion
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        private bool DDDoiNgay()
        {
            string sSql = "";
            DataTable dtTmp = new DataTable();
            try
            {
                sSql = "SELECT MA_SO, NGAY_KH, NGAY_TRUOC, NGAY_SAU,TG_KH, NGAY_DD,LOAI FROM " + sBTDD + " WHERE NGAY_DD IS NULL ORDER BY NGAY_KH, MS_UU_TIEN,LOAI";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {

                    foreach (DataRow drRow in dtTmp.Rows)
                    {
                        //txtSPhutDD so phut con lai de dieu do phai lon hon so phut nay moi lay de dieu do tiep
                        sSql = "SELECT *, CASE WHEN ISNULL(SP_CL,-99) = -99 THEN SO_PHUT_NGAY ELSE SP_CL END AS SP_DD,SO_PHUT_NGAY FROM " + sBTNS + " WHERE GOC = 1 AND CASE WHEN ISNULL(SP_CL,-99) = -99 THEN SO_PHUT_NGAY ELSE SP_CL END > " + Convert.ToDouble(txtSPhutDD.Text) + " AND NGAY = '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "' ORDER BY NGAY";

                        DataTable dtDD = new DataTable();
                        dtDD.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                        if (dtDD.Rows.Count == 0)
                        {
                            if (!DDCapNhapNgay(DateTime.Parse(drRow["NGAY_TRUOC"].ToString()), DateTime.Parse(drRow["NGAY_SAU"].ToString()), double.Parse(drRow["TG_KH"].ToString()), int.Parse(drRow["MA_SO"].ToString()), int.Parse(drRow["LOAI"].ToString()))) return true;
                        }
                        else
                        {
                            double dSoPhutKH = 0;
                            try
                            { dSoPhutKH = double.Parse(drRow["TG_KH"].ToString()); }
                            catch { }
                            double dSoPhutNgay = 0;
                            try
                            { dSoPhutNgay = double.Parse(dtDD.Rows[0]["SO_PHUT_NGAY"].ToString()); }
                            catch { }
                            double dspNgay = 0;
                            try
                            { dspNgay = double.Parse(dtDD.Rows[0]["SP_NGAY"].ToString()); }
                            catch { }
                            double dNV = 0;
                            try
                            { dNV = double.Parse(dtDD.Rows[0]["NV"].ToString()); }
                            catch { }
                            sSql = "INSERT INTO " + sBTNS + " (NGAY,SP_DA_DD,SO_PHUT_NGAY, NGAY_DD, MA_SO,LOAI,SP_CL,GOC,SP_NGAY,NV) VALUES( '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "', " + dSoPhutKH.ToString() + ", " + dSoPhutNgay.ToString() + ",  '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "', " + drRow["MA_SO"].ToString() + " ,  " + drRow["LOAI"].ToString() + ",0,0," + dspNgay.ToString() + "," + dNV.ToString() + ")";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                            sSql = "UPDATE " + sBTNS + " SET SP_CL = CASE WHEN ISNULL(SO_PHUT_NGAY,0) - (SELECT ISNULL(SUM(SP_DA_DD),0) AS SP FROM " + sBTNS + " WHERE NGAY = '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "' AND GOC = 0) <= 0 THEN 0 ELSE ISNULL(SO_PHUT_NGAY,0) - (SELECT ISNULL(SUM(SP_DA_DD),0) AS SP FROM " + sBTNS + " WHERE NGAY = '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "' AND GOC = 0) END WHERE NGAY = '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "' AND GOC = 1 ";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                            try
                            {
                                sSql = " UPDATE " + sBTDD + " SET NGAY_DD =  '" + DateTime.Parse(drRow["NGAY_KH"].ToString()).ToString("MM/dd/yyyy") + "', SO_NGUOI_DD = " + dNV.ToString() + " WHERE MA_SO = " + drRow["MA_SO"].ToString();
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                            }
                            catch { }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private bool DDCapNhapNgay(DateTime dNgayTruoc, DateTime dNgaySau, double dSoPhutKH, int iMaSo, int iLoai)
        {

            string sSql = "";

            sSql = "SELECT * FROM " + sBTNS + " WHERE GOC = 1 AND NGAY = '" + dNgayTruoc.ToString("MM/dd/yyyy") + "' ";
            DataTable dtDD = new DataTable();
            dtDD.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
            double dSoPhutNgay = 0;
            try
            { dSoPhutNgay = double.Parse(dtDD.Rows[0]["SO_PHUT_NGAY"].ToString()); }
            catch { }
            double dspNgay = 0;
            try
            { dspNgay = double.Parse(dtDD.Rows[0]["SP_NGAY"].ToString()); }
            catch { }
            double dNV = 0;
            try
            { dNV = double.Parse(dtDD.Rows[0]["NV"].ToString()); }
            catch { }



            if (dNgayTruoc >= dNgaySau)
            {
                sSql = "INSERT INTO " + sBTNS + " (NGAY,SP_DA_DD,SO_PHUT_NGAY, NGAY_DD, MA_SO,LOAI,SP_CL,GOC,SP_NGAY,NV) VALUES( '" + dNgayTruoc.ToString("MM/dd/yyyy") + "', " + dSoPhutKH.ToString() + ", " + dSoPhutNgay.ToString() + ",  '" + dNgaySau.ToString("MM/dd/yyyy") + "', " + iMaSo.ToString() + " ,  " + iLoai.ToString() + ",0,0, " + dspNgay.ToString() + ", " + dNV.ToString() + ")";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                sSql = "UPDATE " + sBTNS + " SET SP_CL = CASE WHEN ISNULL(SO_PHUT_NGAY,0) - (SELECT ISNULL(SUM(SP_DA_DD),0) AS SP FROM " + sBTNS + " WHERE NGAY = '" + dNgayTruoc.ToString("MM/dd/yyyy") + "' AND GOC = 0) <= 0 THEN 0 ELSE ISNULL(SO_PHUT_NGAY,0) - (SELECT ISNULL(SUM(SP_DA_DD),0) AS SP FROM " + sBTNS + " WHERE NGAY = '" + dNgayTruoc.ToString("MM/dd/yyyy") + "' AND GOC = 0) END WHERE NGAY = '" + dNgayTruoc.ToString("MM/dd/yyyy") + "' AND GOC = 1 ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                try
                {
                    sSql = " UPDATE " + sBTDD + " SET NGAY_DD =  '" + dNgaySau.ToString("MM/dd/yyyy") + "' , SO_NGUOI_DD = " + dNV.ToString() + "  WHERE MA_SO = " + iMaSo.ToString();
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                }
                catch { }
                return true;
            }
            
            try
            {
                #region "Doi Ngay"
                sSql = "SELECT *, CASE WHEN ISNULL(SP_CL,-99) = -99 THEN SO_PHUT_NGAY ELSE SP_CL END AS SP_DD FROM " + sBTNS + " WHERE  GOC = 1 AND CASE WHEN ISNULL(SP_CL,-99) = -99 THEN SO_PHUT_NGAY ELSE SP_CL END > " + Convert.ToDouble(txtSPhutDD.Text) + " AND NGAY = '" + dNgayTruoc.ToString("MM/dd/yyyy") + "' ORDER BY NGAY";
                DataTable dtDDDoi = new DataTable();
                dtDDDoi.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                if (dtDDDoi.Rows.Count == 0)
                {
                    DateTime dNgayDD = dNgayTruoc.Date.AddDays(1);
                    if (!DDCapNhapNgay(dNgayDD, dNgaySau, dSoPhutKH, iMaSo, iLoai)) return true;

                }
                else
                {
                    sSql = "INSERT INTO " + sBTNS + " (NGAY,SP_DA_DD,SO_PHUT_NGAY, NGAY_DD, MA_SO,LOAI,SP_CL,GOC,SP_NGAY,NV) VALUES( '" + dNgayTruoc.ToString("MM/dd/yyyy") + "', " + dSoPhutKH.ToString() + ", " + dSoPhutNgay.ToString() + ",  '" + dNgayTruoc.ToString("MM/dd/yyyy") + "', " + iMaSo.ToString() + " ,  " + iLoai.ToString() + ",0,0, " + dspNgay.ToString() + ", " + dNV.ToString() + ")";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                    sSql = "UPDATE " + sBTNS + " SET SP_CL = CASE WHEN ISNULL(SO_PHUT_NGAY,0) - (SELECT ISNULL(SUM(SP_DA_DD),0) AS SP FROM " + sBTNS + " WHERE NGAY = '" + dNgayTruoc.ToString("MM/dd/yyyy") + "' AND GOC = 0) <= 0 THEN 0 ELSE ISNULL(SO_PHUT_NGAY,0) - (SELECT ISNULL(SUM(SP_DA_DD),0) AS SP FROM " + sBTNS + " WHERE NGAY = '" + dNgayTruoc.ToString("MM/dd/yyyy") + "' AND GOC = 0) END WHERE NGAY = '" + dNgayTruoc.ToString("MM/dd/yyyy") + "' AND GOC = 1 ";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                    try
                    {
                        sSql = " UPDATE " + sBTDD + " SET NGAY_DD =  '" + dNgayTruoc.ToString("MM/dd/yyyy") + "', SO_NGUOI_DD = " + dNV.ToString() + "  WHERE MA_SO = " + iMaSo.ToString();
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                    }
                    catch { }
                }
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
