using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class frmVatTuPhuTung : DevExpress.XtraEditors.XtraForm
    {
        private Boolean bDDH = true;
        private Boolean bLoad = true;

        public frmVatTuPhuTung()
        {
            InitializeComponent();
            try
            {
                bDDH = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT ISNULL(DDH_DXMH,0) AS DDH FROM THONG_TIN_CHUNG"));
            }
            catch { bDDH = false; }

            LoadDesign();
        }

        private void LoadDesign()
        {
            if (!bDDH)
            {
                tableLayoutPanel1.SuspendLayout();
                for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                {
                    Control c = tableLayoutPanel1.GetControlFromPosition(i, 4);
                    tableLayoutPanel1.Controls.Remove(c);
                    try
                    {
                        c.Dispose();
                    }
                    catch { }
                }
                tableLayoutPanel1.Controls.Add(grdNhap, 0, 4);
                tableLayoutPanel1.Controls.Add(grdXuat, 0, 5);
                tableLayoutPanel1.Controls.Add(btnThoat, 9, 6);
                tableLayoutPanel1.RowStyles.RemoveAt(7);
                tableLayoutPanel1.ResumeLayout(false);
                tableLayoutPanel1.PerformLayout();
                tableLayoutPanel1.Refresh();

                TableLayoutRowStyleCollection styles = this.tableLayoutPanel1.RowStyles;
                int j = 0;
                foreach (RowStyle style in styles)
                {

                    if (style.SizeType == SizeType.Percent)
                    {
                        style.Height = 33;
                    }
                    if (style.SizeType == SizeType.AutoSize)
                    {
                        style.SizeType = SizeType.Absolute;
                        style.Height = 38;
                    }

                    j++;
                }
            }
            else
            {
                TableLayoutRowStyleCollection styles = this.tableLayoutPanel1.RowStyles;
                int j = 0;
                foreach (RowStyle style in styles)
                {
                    if (style.SizeType == SizeType.Percent)
                    {
                        style.Height = 25;
                    }
                    if (style.SizeType == SizeType.AutoSize)
                    {
                        style.SizeType = SizeType.Percent;
                        style.Height = 25;
                    }
                    j++;
                }

            }
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel1.Refresh();

        }

        private void LoadLVT()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_VAT_TU", Commons.Modules.TypeLanguage, Commons.Modules.UserName));
            DataRow drRow = dtTmp.NewRow();
            drRow["MS_LOAI_VT"] = "-1";
            drRow["TEN_LOAI_VT"] = " < ALL > ";
            dtTmp.Rows.Add(drRow);
            dtTmp.DefaultView.Sort = "TEN_LOAI_VT";
            dtTmp = dtTmp.DefaultView.ToTable();
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLVT, dtTmp, "MS_LOAI_VT", "TEN_LOAI_VT", lblLVT.Text);
        }

        private void LoadVatTu(string sLVT)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetICPhuTungPQ",  sLVT));
            Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboVatTu, dtTmp, "MS_PT", "MS_PT", lblLVT.Text);
            
        }

        private void LoadDeXuat(string sPhuTung)
        {
            if (bLoad) return;
            bLoad = true;
            DataTable dtTmp = new DataTable();
            DateTime TNgay,DNgay;

            TNgay = datTNgay.DateTime.Date;
            DNgay = datDNgay.DateTime.Date;

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDeXuatTheoPT", sPhuTung,TNgay,DNgay));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDXuat, grvDXuat, dtTmp, false, true, true, true, true, "frmVatTuPhuTung");
            bLoad = false;
        }

        private void LoadDonDatHang(string sPhuTung,string sMaSo)
        {
            if (bLoad) return;
            bLoad = true;

            DataTable dtTmp = new DataTable();
            DateTime TNgay, DNgay;

            TNgay = datTNgay.DateTime.Date;
            DNgay = datDNgay.DateTime.Date;

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonDatHangTheoPT", sPhuTung, sMaSo, TNgay, DNgay));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDHang, grvDHang, dtTmp, false, true, true, true, true, "frmVatTuPhuTung");
            bLoad = false;
        }

        private void LoadPhieuNhap(string sPhuTung, string sPhieuNhap)
        {
            if (bLoad) return;
            bLoad = true;

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhieuNhapTheoPT", sPhuTung, sPhieuNhap, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhap, grvNhap, dtTmp, false, true, true, true, true, "frmVatTuPhuTung");

            grvNhap.Columns["NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            grvNhap.Columns["NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";

            grvNhap.Columns["GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            grvNhap.Columns["GIO"].DisplayFormat.FormatString = "HH:mm:ss";

            bLoad = false;
        }

        private void LoadPhieuXuat(string sPhuTung, string sPhieuNhap)
        {
            if (bLoad) return;
            bLoad = true;

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhieuXuatTheoPT", sPhuTung, sPhieuNhap, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdXuat, grvXuat, dtTmp, false, true, true, true,true,"frmVatTuPhuTung");
            grvXuat.Columns["NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            grvXuat.Columns["NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";

            grvXuat.Columns["GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            grvXuat.Columns["GIO"].DisplayFormat.FormatString = "HH:mm:ss";

            bLoad = false;
        }

        
        private void frmVatTuPhuTung_Load(object sender, EventArgs e)
        {

            datTNgay.DateTime = DateTime.Now.AddYears(-1);
            datDNgay.DateTime = DateTime.Now;
            LoadLVT();          
            bLoad = false;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void cboLVT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadVatTu(cboLVT.EditValue.ToString());
            }
            catch { LoadVatTu("-1"); }
            
        }

        private void cboVatTu_EditValueChanged(object sender, EventArgs e)
        {
            grdDXuat.Enabled = true;
            #region LoadDX
            try
            {
                if (!chkPNhap.Checked) LoadDeXuat(cboVatTu.EditValue.ToString());
                else
                {
                    try
                    {
                        if (grvDXuat.RowCount > 0) LoadDeXuat("-1");
                    }
                    catch { }
                    grdDXuat.Enabled = false;
                }
            }
            catch { LoadDeXuat("-1"); }
            #endregion
                try
                {
                    string sMaSo = "";
                    try
                    { sMaSo = grvDXuat.GetFocusedRowCellValue("MS_DE_XUAT").ToString(); }
                    catch { sMaSo = ""; }
                    if (chkPNhap.Checked)
                    {
                        LoadPhieuNhap(cboVatTu.EditValue.ToString(), "-1");
                    }
                    else
                    {
                        if (bDDH)
                        {
                            LoadDonDatHang(cboVatTu.EditValue.ToString(), sMaSo);
                            #region Load Phieu Nhap
                            try
                            { sMaSo = grvDHang.GetFocusedRowCellValue("MS_DON_DAT_HANG").ToString(); }
                            catch { sMaSo = ""; }
                            LoadPhieuNhap(cboVatTu.EditValue.ToString(), sMaSo);
                            #endregion
                        }
                        else
                            LoadPhieuNhap(cboVatTu.EditValue.ToString(), sMaSo);
                    }
                    #region Load Phieu Xuat
                    try
                    { sMaSo = grvNhap.GetFocusedRowCellValue("MS_DH_NHAP_PT").ToString(); }
                    catch { sMaSo = ""; }
                    LoadPhieuXuat(cboVatTu.EditValue.ToString(), sMaSo);
                    #endregion
                }
                catch
                {
                    LoadDonDatHang("-1", "-1");
                    LoadPhieuNhap("-1", "");
                    LoadPhieuXuat("-1", "-1");
                }
                bLoad = false;
           
            
        }

        private void grvDXuat_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                string sMaSo = "";
                try
                { sMaSo = grvDXuat.GetFocusedRowCellValue("MS_DE_XUAT").ToString(); }
                catch { sMaSo = ""; }
                if (chkPNhap.Checked)
                {
                    LoadPhieuNhap(cboVatTu.EditValue.ToString(), "-1");
                }
                else
                {

                    if (bDDH)
                    {
                        LoadDonDatHang(cboVatTu.EditValue.ToString(), sMaSo);
#region Load Phieu Nhap
                        try
                        { sMaSo = grvDHang.GetFocusedRowCellValue("MS_DON_DAT_HANG").ToString(); }
                        catch { sMaSo = ""; }
                        LoadPhieuNhap(cboVatTu.EditValue.ToString(), sMaSo);
#endregion
                    }
                    else
                    {
                        LoadPhieuNhap(cboVatTu.EditValue.ToString(), sMaSo);
                    }
                }
#region Load Phieu Xuat
                try
                { sMaSo = grvNhap.GetFocusedRowCellValue("MS_DH_NHAP_PT").ToString(); }
                catch { sMaSo = ""; }
                LoadPhieuXuat(cboVatTu.EditValue.ToString(), sMaSo);
#endregion

                
            }
            catch { 
                LoadDonDatHang("-1","-1");
                LoadPhieuNhap("-1", ""); 
                LoadPhieuXuat("-1", "-1"); 
            }
            bLoad = false;
        }

        private void grvDHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                string sMaSo = "";
                try
                { sMaSo = grvDHang.GetFocusedRowCellValue("MS_DON_DAT_HANG").ToString(); }
                catch { }
                LoadPhieuNhap(cboVatTu.EditValue.ToString(), sMaSo);

                #region Load Phieu Xuat
                try
                {
                    try
                    { sMaSo = grvNhap.GetFocusedRowCellValue("MS_DH_NHAP_PT").ToString(); }
                    catch { }
                    LoadPhieuXuat(cboVatTu.EditValue.ToString(), sMaSo);
                }
                catch { LoadPhieuXuat("-1", "-1"); }
                #endregion

            }
            catch
            {
                LoadDonDatHang("-1", "-1");
            }
            bLoad = false;
        }

        private void grvNhap_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                string sPNhap = "";
                try
                { sPNhap = grvNhap.GetFocusedRowCellValue("MS_DH_NHAP_PT").ToString(); }
                catch { }
                LoadPhieuXuat(cboVatTu.EditValue.ToString(), sPNhap);
            }
            catch { LoadPhieuXuat("-1", "-1"); }
            bLoad = false;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void chkPNhap_CheckedChanged(object sender, EventArgs e)
        {
            grdDXuat.Enabled =! grdDXuat.Enabled;
            cboVatTu_EditValueChanged(sender, e);
        }

    }
}