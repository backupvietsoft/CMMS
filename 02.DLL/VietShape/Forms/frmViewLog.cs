using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Windows.Forms;

namespace VietShape
{
    public partial class frmViewLog : DevExpress.XtraEditors.XtraForm
    {
        public frmViewLog()
        {
            InitializeComponent();
        }
        #region Load Du Lieu
        private void LoadCmb()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spViewLogCmb",1, Commons.Modules.TypeLanguage, Commons.Modules.UserName));

                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboMenuLog, dtTmp, "MENU_PARENT", "MENU_ID", "MENU_TEXT");
            }
            catch { }
        }
        #endregion
        private void frmViewLog_Load(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.SQLString = "0LOAD";
                dtDNgay.DateTime = Convert.ToDateTime("01" + "/" + DateTime.Now.AddMonths(1).Month.ToString() + "/" + DateTime.Now.AddMonths(1).Year.ToString()).AddDays(-1);
                dtTNgay.DateTime = dtDNgay.DateTime.AddMonths(-6);
                LoadCmb();
                Commons.Modules.SQLString = "";
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            Commons.Modules.SQLString = "";
        }

        private void cboDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadData();
        }
        private void dtDNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (string.IsNullOrEmpty(cboMenuLog.ToString())) return;
            if (string.IsNullOrEmpty(dtTNgay.ToString())) return;
            if (string.IsNullOrEmpty(dtDNgay.ToString())) return;
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spViewLogData", cboMenuLog.EditValue.ToString(), dtTNgay.DateTime.Date, dtDNgay.DateTime.Date, Commons.Modules.TypeLanguage));
                DataColumnCollection columns = dtTmp.Columns;
                if (!dtTmp.Columns.Contains("TT"))
                {
                    Commons.MssBox.Show(this.Name, "msgChuaCoDuLieuLog",this.Text);
                    grdLog.DataSource = null;
                    grvLog.PopulateColumns();
                    return;
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdLog, grvLog, dtTmp, false, true, false, true, true, this.Name);
                grvLog.Columns["CREATEDATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                grvLog.Columns["CREATEDATE"].DisplayFormat.FormatString = "G";
                grvLog.Columns["TT"].Visible = false;
                if(cboMenuLog.EditValue.ToString()=="-1") grvLog.Columns["MENU_ID"].Visible = false;
                grvLog.BestFitColumns();
            } 
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoDuLieuLog", Commons.Modules.TypeLanguage) + "\n" +  ex.Message);
            }

            try
            {
                
            }
            catch { }

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grvLog_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int TT = Convert.ToInt32(grvLog.GetRowCellValue(e.RowHandle, "TT"));
            if (TT ==0)
            {
                e.Appearance.BackColor = System.Drawing.Color.FromArgb(236, 248, 251);
            }
            if (TT == 3)
            {
                e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 234, 237);
            }
            if (TT == 1)
            {
                e.Appearance.BackColor = System.Drawing.Color.FromArgb(244, 245, 203);
            }

        }

        private System.Collections.Generic.List<string> arrTim = new System.Collections.Generic.List<string>();
        private void grvLog_DoubleClick(object sender, EventArgs e)
        {
            if (cboMenuLog.EditValue.ToString() != "-1") return;
            try
            {
                string NThang = grvLog.GetFocusedRowCellValue("CREATEDATE").ToString();
                cboMenuLog.SetValue(grvLog.GetFocusedRowCellValue("MENU_ID").ToString());
                var colIndex = grvLog.Columns["CREATEDATE"].VisibleIndex;
                int rowHandle = grvLog.LocateByDisplayText(0, grvLog.Columns[colIndex], NThang);
                if (rowHandle != DevExpress.Data.DataController.InvalidRow)
                    grvLog.FocusedRowHandle = rowHandle;
            }catch { }

        }
    }
}
