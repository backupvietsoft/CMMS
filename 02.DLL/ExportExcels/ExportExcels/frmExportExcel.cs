using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using Excel;
namespace ExportExcels
{
    public partial class frmExportExcel : DevExpress.XtraEditors.XtraForm
    {
        System.Data.DataTable _table = new System.Data.DataTable();
        public frmExportExcel()
        {
            InitializeComponent();
        }
        private void LoadDS()
        {
            //System.Data.DataTable table = new System.Data.DataTable();
            //table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DS_EXPORT", Commons.Modules.TypeLanguage));
            //cmbList.Properties.DataSource = table;
            //cmbList.Properties.DisplayMember = "TEN_EXPORT";
            //cmbList.Properties.ValueMember = "MS";


            string sSql;
            sSql = "SELECT [MS_IMPORT] AS MA_SO , CASE " + Commons.Modules.TypeLanguage +
                " WHEN 0 THEN [TEN_IMPORT] WHEN 1 THEN [TEN_IMPORT_A] ELSE [TEN_IMPORT_H] END TEN FROM [DS_IMPORT]  " +
                " WHERE [SU_DUNG] = 1 AND IMPORT = 0 ORDER BY [MA_SO]";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbList, sSql, "MA_SO", "TEN", lblDanhmuc.Text);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
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
            {}
         
            this.Cursor = Cursors.WaitCursor;
            this.grvSource.ExportToXls(path);
            
            Excel.Application excelApplication = new Excel.Application();
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            excelApplication.Visible = false;
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

            int count_column = _table.Columns.Count;
            int count_row = _table.Rows.Count;
            Excel.Range a1 = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
            a1.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range title = excelWorkSheet.get_Range(excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, count_column]);
            title.Merge(true);
            title.Font.Bold = true;
            string sTDe;
            sTDe = "";
            int iSheet = int.Parse(cmbList.EditValue.ToString());
            excelWorkSheet.Rows.AutoFit();
            excelApplication.ActiveWindow.DisplayGridlines = true;

            switch (iSheet)
            {
                case 11:
                    #region DanhSachNhaXuong
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "DanhSachNhaXuong", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe;
                    break;
                    #endregion
                case 12:
                    #region danhsachthongtinthietbi
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "danhsachthongtinthietbi", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe;
                    ((Excel.Range)excelWorkSheet.Cells[2, 15]).ColumnWidth = "50";
                    ((Excel.Range)excelWorkSheet.Cells[2, 20]).ColumnWidth = "30";
                    ((Excel.Range)excelWorkSheet.Cells[2, 21]).ColumnWidth = "30";
                    break;
                    #endregion
                case 13:
                    #region danhsachicphutung
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "danhsachicphutung", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe;
                    ((Excel.Range)excelWorkSheet.Cells[2, 15]).ColumnWidth = "50";
                    ((Excel.Range)excelWorkSheet.Cells[2, 5]).ColumnWidth = "50";
                    break;
                    #endregion
                case 14:
                    #region CauTrucThietBi
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "CauTrucThietBi", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe;
                    break;
                    #endregion
                case 15:
                    #region CauTrucThietBiPhuTung
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "CauTrucThietBiPhuTung", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe ;
                    break;
                    #endregion
                case 17:
                    #region CauTrucThietBiCongViec
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "CauTrucThietBiCongViec", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe ;
                    break;
                    #endregion
                case 20:
                    #region CauTrucThietBiGSTTDTinh
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "CauTrucThietBiGSTTDTinh", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe;
                    break;
                    #endregion
                case 21:
                    #region CauTrucThietBiGSTTDLuong
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "CauTrucThietBiGSTTDLuong", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe;
                    break;
                    #endregion
                case 25:
                    #region 14-May loai bao tri
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "MayLoaiBaoTri", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe;
                    break;
                    #endregion
                case 26:
                    #region 15-Loai bao tri cong viec
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "LoaiBaoTriCongViec", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe;
                    break;
                    #endregion
                case 27:
                    #region 16-Loai bao tri CV phu tung
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "LoaiBaoTriCongViecPhuTung", Commons.Modules.TypeLanguage);
                    excelWorkSheet.Cells[1, 1] = sTDe;
                    break;
                    #endregion

            }

            if (sTDe != "") if (sTDe.Length < 30) excelWorkSheet.Name = sTDe.Replace("?", "");
            this.Cursor = Cursors.Default;
            excelWorkbook.Save();
            excelApplication.Visible = true;
            
        }

        private void frmExportExcel_Load(object sender, EventArgs e)
        {
            LoadDS();
            groupControl1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "nguondulieu", Commons.Modules.TypeLanguage);
            groupControl2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "dulieuexport", Commons.Modules.TypeLanguage);
            btnExport.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "btnExport", Commons.Modules.TypeLanguage);
            btnExit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "btnExit", Commons.Modules.TypeLanguage);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            try
            {
                lblTSo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "lblTSo",
                    Commons.Modules.TypeLanguage) + " : " + grvSource.RowCount.ToString();
            }
            catch { }
        }

        private void cmbList_EditValueChanged(object sender, EventArgs e)
        {
            string sSql = "";
            //string ms_loai_export = cmbList.EditValue.ToString();
            int iSheet = int.Parse(cmbList.EditValue.ToString());
            this.Cursor = Cursors.WaitCursor;
            switch (iSheet)
            {
                case 11:
                    #region Nha Xuong
                    sSql = " SELECT B.MS_N_XUONG, ISNULL(TEN_N_XUONG, '') AS TEN_N_XUONG, ISNULL(TEN_N_XUONG_A, '') AS TEN_N_XUONG_A, " +
                            " ISNULL(TEN_N_XUONG_H, '') AS TEN_N_XUONG_H, MS_CHA, " +
                            " ISNULL(TRU_SO, '') AS TRU_SO, ISNULL(NGUOI_DAI_DIEN, '') AS NGUOI_DAI_DIEN, " +
                            " (SELECT TEN_QG FROM IC_QUOC_GIA WHERE MA_QG = (SELECT MS_CHA FROM IC_QUOC_GIA WHERE MA_QG = MS_QG)) AS TINH,  " +
                            " (SELECT TEN_QG FROM IC_QUOC_GIA WHERE MA_QG = MS_QG) AS QUAN,  " +
                            " (SELECT TEN_V FROM IC_DUONG WHERE MS = MS_DUONG) AS DUONG, DIA_CHI, DIEN_THOAI, DIEN_TICH, KHOANG_CACH, GHI_CHU,  " +
                            " (SELECT TEN_DON_VI FROM DON_VI A WHERE A.MS_DON_VI = B.MS_DON_VI) AS DON_VI  " +
                            " FROM NHA_XUONG B INNER JOIN NHOM_NHA_XUONG C ON B.MS_N_XUONG = C.MS_N_XUONG " +
                            " INNER JOIN USERS D ON C.GROUP_ID = D.GROUP_ID  " +
                            " WHERE USERNAME = '" +  Commons.Modules.UserName +   "'  ";


                    _table = new System.Data.DataTable();
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    break;
                    #endregion
                case 12:
                    #region Thong Tin Thiet Bi
                    {
                        _table = new System.Data.DataTable();
                        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DS_MAY_EXPORT", 
                            Commons.Modules.TypeLanguage,Commons.Modules.UserName));
                        break;
                    }
                    #endregion
                case 13:
                    #region Vat Tu Thiet Bi
                    _table = new System.Data.DataTable();
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,"SP_NHU_Y_GET_DS_PT_EXPORT",
                            Commons.Modules.TypeLanguage, Commons.Modules.UserName));
                    break;
                    #endregion
                case 14:
                    #region Cau truc Thiet Bi 
                    sSql = " SELECT A.MS_MAY, A.MS_BO_PHAN, A.TEN_BO_PHAN, A.MS_PT, A.SO_LUONG, A.MS_BO_PHAN_CHA, A.GHI_CHU, B.CLASS_NAME "  +
                                " FROM dbo.CAU_TRUC_THIET_BI AS A LEFT JOIN dbo.CLASS_LIST AS B ON A.CLASS_ID = B.CLASS_ID "  +
                                " INNER JOIN (SELECT DISTINCT MS_MAY FROM [dbo].[MashjGetMayUser]('" + Commons.Modules.UserName + "') ) C " + 
                                " ON A.MS_MAY = C.MS_MAY " +
                                " ORDER BY A.MS_MAY, A.MS_BO_PHAN, A.TEN_BO_PHAN ";
                    _table = new System.Data.DataTable();
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,CommandType.Text,sSql));
                    break;
                    #endregion    
                case 15:
                    #region Cau truc Thiet Bi Phu Tung - Phan ra
                    sSql = " SELECT A.MS_MAY ,MS_BO_PHAN, MS_PT, MS_VI_TRI_PT, SO_LUONG, CONVERT(INT,ACTIVE) AS ACTIVE , CHUC_NANG " +
                                " FROM CAU_TRUC_THIET_BI_PHU_TUNG A " +
                                " INNER JOIN (SELECT DISTINCT MS_MAY FROM [dbo].[MashjGetMayUser]('" + Commons.Modules.UserName + "') ) C " +
                                " ON A.MS_MAY = C.MS_MAY " +
                                " ORDER BY A.MS_MAY ,MS_BO_PHAN, MS_PT ";
                    _table = new System.Data.DataTable();
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    break;
                    #endregion
                case 17:
                    #region Cau truc Thiet Bi Phu Tung - Phan ra
                    sSql = " SELECT A.MS_MAY ,MS_BO_PHAN, MS_CV,  ISNULL(GHI_CHU,'') AS GHI_CHU, CONVERT(INT,ACTIVE) AS ACTIVE , TG_KH " +
                                    " FROM CAU_TRUC_THIET_BI_CONG_VIEC A " +
                                    " INNER JOIN (SELECT DISTINCT MS_MAY FROM [dbo].[MashjGetMayUser]('" + Commons.Modules.UserName + "') ) C ON A.MS_MAY = C.MS_MAY " +
                                    " ORDER BY A.MS_MAY ,MS_BO_PHAN, MS_CV ";
                    _table = new System.Data.DataTable();
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    break;
                    #endregion
                case 20:
                    #region Cau truc Thiet Bi Phu Tung - Phan ra
                    sSql = " SELECT ISNULL(A.MS_MAY, N'') AS MS_MAY, ISNULL(A.MS_BO_PHAN, N'') AS MS_BO_PHAN, ISNULL(A.MS_TS_GSTT, N'') AS MS_TS_GSTT, " +
                                " ISNULL(A.CHU_KY_DO, 0) AS CHU_KY_DO,ISNULL(dbo.DON_VI_THOI_GIAN.TEN_DV_TG, N'') AS TEN_DV_TG,  " +
                                " ISNULL(A.GHI_CHU, N'') AS GHI_CHU, ISNULL(CONVERT(INT,A.ACTIVE) , 0) AS ACTIVE " +
                                " FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT AS A INNER JOIN dbo.DON_VI_THOI_GIAN ON " +
                                " A.MS_DV_TG = dbo.DON_VI_THOI_GIAN.MS_DV_TG INNER JOIN dbo.THONG_SO_GSTT AS C ON A.MS_TS_GSTT = C.MS_TS_GSTT " +
                                " INNER JOIN (SELECT DISTINCT MS_MAY FROM [dbo].[MashjGetMayUser]('" + Commons.Modules.UserName + "') ) T1 ON A.MS_MAY = T1.MS_MAY " +
                                " WHERE (C.LOAI_TS = 1) ORDER BY ISNULL(A.MS_MAY, N'') , ISNULL(A.MS_BO_PHAN, N'') , ISNULL(A.MS_TS_GSTT, N'') ";

                    _table = new System.Data.DataTable();
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    break;
                    #endregion
                case 21:
                    #region Cau truc Thiet Bi Phu Tung - Phan ra
                    sSql = " SELECT ISNULL(A.MS_MAY, N'') AS MS_MAY, ISNULL(A.MS_BO_PHAN, N'') AS MS_BO_PHAN, ISNULL(A.MS_TS_GSTT, N'') AS MS_TS_GSTT,  " +
                                " ISNULL(A.TEN_GT, N'') AS TEN_GT, ISNULL(A.GIA_TRI_TREN, 0) AS GIA_TRI_TREN, ISNULL(A.GIA_TRI_DUOI, 0) AS GIA_TRI_DUOI,  " +
                                " ISNULL(A.CHU_KY_DO, 0) AS CHU_KY_DO, ISNULL(B.TEN_DV_TG, N'') AS TEN_DV_TG,ISNULL(CONVERT(INT,A.DAT), 0) AS DAT,  " +
                                " ISNULL(A.GHI_CHU, N'') AS GHI_CHU, ISNULL(CONVERT(INT, A.ACTIVE), 0) AS ACTIVE " +
                                " FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT AS A INNER JOIN dbo.DON_VI_THOI_GIAN AS B ON A.MS_DV_TG = B.MS_DV_TG INNER JOIN " +
                                " dbo.THONG_SO_GSTT AS C ON A.MS_TS_GSTT = C.MS_TS_GSTT   " +
                                " INNER JOIN (SELECT DISTINCT MS_MAY FROM [dbo].[MashjGetMayUser]('" + Commons.Modules.UserName + "') ) T1 ON A.MS_MAY = T1.MS_MAY " +
                                " WHERE (C.LOAI_TS = 0) ORDER BY  ISNULL(A.MS_MAY, N''), ISNULL(A.MS_BO_PHAN, N'') , ISNULL(A.MS_TS_GSTT, N'') ";
                    _table = new System.Data.DataTable();
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    break;
                    #endregion
                case 25:
                    #region 14-May loai bao tri
                    sSql = " SELECT DISTINCT A.MS_MAY, C.TEN_LOAI_BT, B.NGAY_CUOI, B.SO_NGAY, A.NGAY_AD, A.CHU_KY, " +
                                    " D.TEN_DV_TG,ISNULL(A.RUN_TIME,0) AS RUN_TIME, E.TEN_DVT_RT, ISNULL(A.MOVEMENT,'') AS MOVEMENT " +
                                    " FROM dbo.MAY_LOAI_BTPN_CHU_KY AS A INNER JOIN " +
                                    " dbo.MAY_LOAI_BTPN AS B ON A.MS_MAY = B.MS_MAY AND A.MS_LOAI_BT = B.MS_LOAI_BT INNER JOIN " +
                                    " dbo.LOAI_BAO_TRI AS C ON B.MS_LOAI_BT = C.MS_LOAI_BT INNER JOIN " +
                                    " dbo.DON_VI_THOI_GIAN AS D ON A.MS_DV_TG = D.MS_DV_TG INNER JOIN " +
                                    " dbo.DON_VI_TINH_RUN_TIME AS E ON A.MS_DVT_RT = E.MS_DVT_RT " +
                                    " INNER JOIN (SELECT DISTINCT MS_MAY FROM [dbo].[MashjGetMayUser]('" + Commons.Modules.UserName + "') ) T1 ON A.MS_MAY = T1.MS_MAY " +
                                    " ORDER BY A.MS_MAY, C.TEN_LOAI_BT, B.NGAY_CUOI, B.SO_NGAY, A.NGAY_AD, D.TEN_DV_TG, E.TEN_DVT_RT";
                    _table = new System.Data.DataTable();
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    break;
                    #endregion
                case 26:
                    #region 15-Loai bao tri cong viec
                    sSql = "SELECT DISTINCT B.MS_MAY, A.TEN_LOAI_BT, B.MS_CV, B.MS_BO_PHAN FROM dbo.LOAI_BAO_TRI AS A " +
                                " INNER JOIN dbo.MAY_LOAI_BTPN_CONG_VIEC AS B ON A.MS_LOAI_BT = B.MS_LOAI_BT " +
                                " INNER JOIN (SELECT DISTINCT MS_MAY FROM [dbo].[MashjGetMayUser]('" + Commons.Modules.UserName + "') ) T1 ON B.MS_MAY = T1.MS_MAY " +
                                " ORDER BY B.MS_MAY, A.TEN_LOAI_BT, B.MS_CV, B.MS_BO_PHAN ";
                    _table = new System.Data.DataTable();
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    break;
                    #endregion
                case 27:
                    #region 16-Loai bao tri CV phu tung
                    sSql = "SELECT DISTINCT A.MS_MAY, B.TEN_LOAI_BT, A.MS_CV, A.MS_BO_PHAN, A.MS_PT, ISNULL(A.SO_LUONG,0) AS SO_LUONG " +
                                " FROM dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG AS A INNER JOIN dbo.LOAI_BAO_TRI AS B ON A.MS_LOAI_BT = B.MS_LOAI_BT " +
                                " INNER JOIN (SELECT DISTINCT MS_MAY FROM [dbo].[MashjGetMayUser]('" + Commons.Modules.UserName + "') ) T1 ON A.MS_MAY = T1.MS_MAY " +
                                " ORDER BY A.MS_MAY, B.TEN_LOAI_BT, A.MS_CV, A.MS_BO_PHAN, A.MS_PT ";
                    _table = new System.Data.DataTable();
                    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    break;
                    #endregion
            }
            if (_table.Columns.Count < 8)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _table, false, true, true, true,true, "frmExportExcel");
            else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _table, false, true, false, true, true, "frmExportExcel");
            try
            {
                lblTSo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmExportExcel", "lblTSo", 
                    Commons.Modules.TypeLanguage) + " : " + grvSource.RowCount.ToString();
            }
            catch { }
            this.Cursor = Cursors.Default;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}