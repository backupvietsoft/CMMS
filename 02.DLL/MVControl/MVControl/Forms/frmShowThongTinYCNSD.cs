using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmShowThongTinYCNSD : DevExpress.XtraEditors.XtraForm
    {
        public string STT { get; set; }
        public string MS_MAY { get; set; }
        public string MS_PBT { get; set; }
        public string STT_VAN_DE { get; set; }
        public frmShowThongTinYCNSD()
        {
            InitializeComponent();
        }

        private void frmShowThongTinYCNSD_Load(object sender, EventArgs e)
        {
            try
            {
                xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InTabControlHeader;
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetThongTinYeuCau", STT, Commons.Modules.TypeLanguage, MS_MAY, Commons.Modules.UserName, MS_PBT, STT_VAN_DE));

                if(dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MsgKhongCoChiTiet", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
                xtraTabPage1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmShowThongTinYCNSD", "xtraTabPage1", Commons.Modules.TypeLanguage);
                xtraTabPage2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmShowThongTinYCNSD", "xtraTabPage2", Commons.Modules.TypeLanguage);
                lblNgayYC.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "lblNgay", Commons.Modules.TypeLanguage);
                lblNguoiyeucau.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "lblNguoiyeucau", Commons.Modules.TypeLanguage);
                lbl1.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_TINH_TRANG", Commons.Modules.TypeLanguage);
                lbl2.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "USERNAME_DSX", Commons.Modules.TypeLanguage);
                lbl3.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "Y_KIEN_DSX", Commons.Modules.TypeLanguage);
                lbl4.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "Y_KIEN_DBT", Commons.Modules.TypeLanguage);
                lbl5.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "THUC_HIEN_DSX", Commons.Modules.TypeLanguage);
                lbl6.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "USERNAME_DBT", Commons.Modules.TypeLanguage);
                lbl7.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_PBT", Commons.Modules.TypeLanguage);
                lbl8.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MO_TA_TINH_TRANG", Commons.Modules.TypeLanguage);
                lbl9.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_CONG_NHAN", Commons.Modules.TypeLanguage);
                lbl10.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "NGAY_BD_KH", Commons.Modules.TypeLanguage);
                lbl11.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "NGAY_KT_KH", Commons.Modules.TypeLanguage);
                lbl12.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TU_NGAY", Commons.Modules.TypeLanguage);
                lbl13.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "DEN_NGAY", Commons.Modules.TypeLanguage);
                lbl14.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MO_TA_CV", Commons.Modules.TypeLanguage);

                //1000, 392         420, 392
                lbl1_1.Text = dtTmp.Rows[0]["TEN_TINH_TRANG"].ToString();
                lbl2_2.Text = dtTmp.Rows[0]["USERNAME_DSX"].ToString();
                lbl3_3.Text = dtTmp.Rows[0]["Y_KIEN_DSX"].ToString();
                lbl4_4.Text = dtTmp.Rows[0]["Y_KIEN_DBT"].ToString();
                lbl5_5.Text = dtTmp.Rows[0]["THUC_HIEN_DSX"].ToString();
                lbl6_6.Text = dtTmp.Rows[0]["USERNAME_DBT"].ToString();
                lbl7_7.Text = dtTmp.Rows[0]["MS_PBT"].ToString() + " " + dtTmp.Rows[0]["TINH_TRANG_PBT"].ToString();
                string MoTaTT = string.Join(", " + Environment.NewLine, dtTmp.Select().Where(x => x.ItemArray.Length > 0).Select(x => x["MO_TA_TINH_TRANG"].ToString()).ToArray());


                try
                {
                    lbl8_8.Text = MoTaTT;

                }
                catch
                {
                    lbl8_8.Text = dtTmp.Rows[0]["MO_TA_TINH_TRANG"].ToString();
                }
                    
                lbl9_9.Text = dtTmp.Rows[0]["MS_CONG_NHAN"].ToString();
                lbl10_10.Text = dtTmp.Rows[0]["NGAY_BD_KH"].ToString();
                lbl11_11.Text = dtTmp.Rows[0]["NGAY_KT_KH"].ToString();
                lbl12_12.Text = dtTmp.Rows[0]["TU_NGAY"].ToString();
                lbl13_13.Text = dtTmp.Rows[0]["DEN_NGAY"].ToString();
                lbl14_14.Text = dtTmp.Rows[0]["MO_TA_CV"].ToString();
                
                lblNgayYC_ND.Text = dtTmp.Rows[0]["NGAY_YC"].ToString();
                lblNguoiyeucau_ND.Text = dtTmp.Rows[0]["NGUOI_YC"].ToString();


                AddSuperTip(lbl1_1, dtTmp.Rows[0]["TEN_TINH_TRANG"].ToString());
                AddSuperTip(lbl2_2, dtTmp.Rows[0]["USERNAME_DSX"].ToString());
                AddSuperTip(lbl3_3, dtTmp.Rows[0]["Y_KIEN_DSX"].ToString());
                AddSuperTip(lbl4_4, dtTmp.Rows[0]["Y_KIEN_DBT"].ToString());
                AddSuperTip(lbl5_5, dtTmp.Rows[0]["THUC_HIEN_DSX"].ToString());
                AddSuperTip(lbl6_6, dtTmp.Rows[0]["USERNAME_DBT"].ToString());
                AddSuperTip(lbl7_7, dtTmp.Rows[0]["MS_PBT"].ToString());
          
                AddSuperTip(lbl8_8, lbl8_8.Text);
                AddSuperTip(lbl9_9, dtTmp.Rows[0]["MS_CONG_NHAN"].ToString());
                AddSuperTip(lbl10_10, dtTmp.Rows[0]["NGAY_BD_KH"].ToString());
                AddSuperTip(lbl11_11, dtTmp.Rows[0]["NGAY_KT_KH"].ToString());
                AddSuperTip(lbl12_12, dtTmp.Rows[0]["TU_NGAY"].ToString());
                AddSuperTip(lbl13_13, dtTmp.Rows[0]["DEN_NGAY"].ToString());
                AddSuperTip(lbl14_14, dtTmp.Rows[0]["MO_TA_CV"].ToString());
                AddSuperTip(lblNgayYC_ND, dtTmp.Rows[0]["NGAY_YC"].ToString());
                AddSuperTip(lblNguoiyeucau_ND, dtTmp.Rows[0]["NGUOI_YC"].ToString());

                LoadBP();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message , "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AddSuperTip(LabelControl lbl, string data)
        {
            SuperToolTip sTooltip1 = new SuperToolTip();
            ToolTipTitleItem titleItem1 = new ToolTipTitleItem();
            titleItem1.Text = data;
            sTooltip1.Items.Add(titleItem1);
            lbl.SuperTip = sTooltip1;
        }

        private void ToolTip_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl == grdBP)
            {
                GridView view = grdBP.FocusedView as GridView;
                GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);
                if (info.InRowCell)
                {
                    string text = view.GetRowCellDisplayText(info.RowHandle, info.Column);
                    string cellKey = info.RowHandle.ToString() + " - " + info.Column.ToString();
                    e.Info = new DevExpress.Utils.ToolTipControlInfo(cellKey, text);
                }
            }
        }

        private void LoadBP()
        {
            try
            {


                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_CHI_TIET_BO_PHAN", STT, MS_MAY, -1));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBP, grvBP, dtTmp, false, false, true, false, true, "");


                ToolTipController toolTip = new ToolTipController();

                grdBP.ToolTipController = toolTip;
                toolTip.GetActiveObjectInfo += ToolTip_GetActiveObjectInfo;
                toolTip.ShowBeak = true;
                toolTip.ToolTipType = ToolTipType.SuperTip;
                grvBP.Columns["STT"].Visible = false;
                grvBP.Columns["MS_MAY"].Visible = false;
                grvBP.Columns["STT_VAN_DE"].Visible = false;
                grvBP.Columns["DEL"].Visible = false;
                grvBP.Columns["STT_BO_PHAN"].Visible = false;
                grvBP.Columns["MS_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_BO_PHAN", Commons.Modules.TypeLanguage);
                grvBP.Columns["TEN_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_BO_PHAN", Commons.Modules.TypeLanguage);
                grvBP.Columns["TEN_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_PT", Commons.Modules.TypeLanguage);
                grvBP.Columns["MS_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_PT", Commons.Modules.TypeLanguage);

            }
            catch
            { }
        }
        private void frmShowThongTinYCNSD_SizeChanged(object sender, EventArgs e)
        {

            //this.Size = new Size(this.Size.Width, 412);

        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowThongTinYCNSD_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(System.Drawing.ColorTranslator.FromHtml("#FFCC66"), 3), this.DisplayRectangle);
        }
    }
}
