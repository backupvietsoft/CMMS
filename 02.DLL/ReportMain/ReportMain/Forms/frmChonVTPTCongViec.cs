using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace ReportMain
{
    public partial class frmChonVTPTCongViec : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtCV;
        public DataTable dtCongViec { get { return dtCV; } set { dtCV = value; } }

        private DataTable dtVTPT;
        public DataTable dtVatTuPhuTung { get { return dtVTPT; } set { dtVTPT = value; } }

        private string sMay;
        public string sMsMay { get { return sMay; } set { sMay = value; } }

        private int iLoaiBT;
        public int iMsLBTri { get { return iLoaiBT; } set { iLoaiBT = value; } }

        private string sBT;
        public string sBangTam { get { return sBT; } set { sBT = value; } }

        public frmChonVTPTCongViec()
        {
            InitializeComponent();
        }

        private void frmChonVTPTCongViec_Load(object sender, EventArgs e)
        {
            TaoLuoiCongViec();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void TaoLuoiCongViec()
        {
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCV, grvCV, dtCV, false, true, true, true); 
        }

        private void grvCV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load((Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                    "GetMAY_LOAI_BTPN_CONG_VIEC", sMsMay, grvCV.GetFocusedRowCellValue("MS_BO_PHAN").ToString(), Commons.Modules.UserName)));


            //GetPhuTungTheoMayBoPhan
        }
    }
}