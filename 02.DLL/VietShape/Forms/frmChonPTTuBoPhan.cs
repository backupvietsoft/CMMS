using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;

namespace VietShape
{
    public partial class frmChonPTTuBoPhan : XtraForm
    {
        public string MS_MAY = "";
        public DataTable dtTTPT1;
        string sBTT = "ChonPhuTungChoMay" + Commons.Modules.UserName;//"ChonBoPhanChoMay"
        public frmChonPTTuBoPhan()
        {
            InitializeComponent();
        }

        DataTable dtTMP = new DataTable();
        private void frmChonPTTuBoPhan_Load(object sender, EventArgs e)
        {

            dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM " + sBTT));
            Commons.Modules.SQLString = "0Check";


            string SqlText1 = null;
            SqlText1 = "SELECT MS_BO_PHAN, MS_BO_PHAN_CHA, (MS_BO_PHAN + ': ' + TEN_BO_PHAN) AS TEN_BO_PHAN  FROM CAU_TRUC_THIET_BI WHERE MS_MAY = '" + MS_MAY + "' ORDER BY ISNULL(STT,999)";

            tlstCauTruc.KeyFieldName = "MS_BO_PHAN";
            tlstCauTruc.ParentFieldName = "MS_BO_PHAN_CHA";

            DataTable dtRoot1 = new DataTable();
            dtRoot1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText1));
            tlstCauTruc.DataSource = dtRoot1;


            DuyetAllNode(tlstCauTruc.Nodes);

            tlstCauTruc.Columns["TEN_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "grpDanhsachcautruc", Commons.Modules.TypeLanguage) + ": " + MS_MAY;
            tlstCauTruc.ExpandAll(); 
        
        
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            Commons.Modules.SQLString = "";
     
        }

        private void DuyetAllNode(TreeListNodes treelistNodes)
        {

            foreach (TreeListNode item in treelistNodes)
            {
                if (dtTMP.Select().Any(x => x["MS_BO_PHAN"].ToString() == item.GetValue("MS_BO_PHAN").ToString() && x["DEL"].ToString() == "0"))
                {
                    item.Checked = true;
                }
                DuyetAllNode(item.Nodes);

            }

        }

        private void ShowVTPT(string MS_BP)
        {
            try
            {
                dtTTPT1 = new DataTable();
                this.grdThongtinPT.DataSource = null;
                dtTTPT1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPTTheoBoPhan", MS_MAY, MS_BP, sBTT));
                dtTTPT1.Columns["CHON"].ReadOnly = false;
                dtTTPT1.Columns["DEL"].ReadOnly = false;

                for (int i = 0; i <= dtTMP.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= dtTTPT1.Rows.Count - 1; j++)
                    {
                        if (dtTMP.Rows[i]["MS_PT"].ToString().Trim() == dtTTPT1.Rows[j]["MS_PT"].ToString().Trim() && dtTMP.Rows[i]["MS_VI_TRI_PT"].ToString().Trim() == dtTTPT1.Rows[j]["MS_VI_TRI_PT"].ToString().Trim() && dtTMP.Rows[i]["MS_BO_PHAN"].ToString().Trim() == dtTTPT1.Rows[j]["MS_BO_PHAN"].ToString().Trim() && dtTMP.Rows[i]["DEL"].ToString().Trim() == "0")
                        {
                            dtTTPT1.Rows[j]["CHON"] = true;
                            dtTTPT1.Rows[j]["DEL"] = dtTMP.Rows[i]["DEL"];
                            break;
                        }
                    }
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdThongtinPT, grvThongtinPT, dtTTPT1, true, true, false, false, true, "");
                grvThongtinPT.Columns["MS_BO_PHAN"].Visible = false;
                grvThongtinPT.Columns["TEN_BO_PHAN"].Visible = false;
                grvThongtinPT.Columns["DEL"].Visible = false;
                grvThongtinPT.Columns["QUY_CACH"].Visible = false;

                grvThongtinPT.Columns["TEN_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_PT", Commons.Modules.TypeLanguage);
                grvThongtinPT.Columns["MS_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MS_PT", Commons.Modules.TypeLanguage);
                grvThongtinPT.Columns["MS_VI_TRI_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MS_VI_TRI_PT", Commons.Modules.TypeLanguage);
                grvThongtinPT.Columns["MS_PT_CTY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MS_PT_CTY", Commons.Modules.TypeLanguage);

                grvThongtinPT.Columns["TEN_PT"].OptionsColumn.ReadOnly = true;
                grvThongtinPT.Columns["MS_PT"].OptionsColumn.ReadOnly = true;
                grvThongtinPT.Columns["MS_VI_TRI_PT"].OptionsColumn.ReadOnly = true;
                grvThongtinPT.Columns["MS_PT_CTY"].OptionsColumn.ReadOnly = true;


                grvThongtinPT.Columns["TEN_PT"].Width = 200;
                grvThongtinPT.Columns["MS_PT"].Width = 100;
                grvThongtinPT.Columns["MS_PT_CTY"].Width = 120;
            }
            catch
            { }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtTMP.Rows.Count > 0)
                {
                    dtTTPT1 = new DataTable();
                    try
                    {
                        dtTMP.DefaultView.RowFilter = "(STT_VAN_DE <> -1) OR (DEL <> 1)";
                    }
                    catch
                    {
                        dtTMP.DefaultView.RowFilter = "(STT <> -1) OR (DEL <> 1)";
                    }
                    dtTTPT1 = dtTMP.DefaultView.ToTable();
                    if (dtTTPT1.Rows.Count == 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonDuLieu", Commons.Modules.TypeLanguage), "");

                    }
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonDuLieu", Commons.Modules.TypeLanguage), "");
                    return;
                }
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        GridView viewChung;
        Point ptChung;
        private void grvThongtinPT_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.Click += new EventHandler(ActiveEditor_Click);
        }

        private void ActiveEditor_Click(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvThongtinPT.RefreshData();
        }
        private void DoRowDoubleClick(GridView view, Point pt)
        {
            try
            { 
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(pt);
                int col = -1;
                col = info.Column.AbsoluteIndex;
                if (col == -1)
                    return;
                System.Data.DataRow row = grvThongtinPT.GetDataRow(info.RowHandle);
                int rowHandle = info.RowHandle;
              
                if (info.Column.FieldName == "CHON")
                {
                    if (!dtTMP.Select().Any(x => x["MS_BO_PHAN"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_BO_PHAN"].ToString() && x["MS_PT"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_PT"].ToString() && x["MS_VI_TRI_PT"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_VI_TRI_PT"].ToString() && x["DEL"].ToString() == "0"))
                    {
                        if (dtTMP.Select().Any(x => x["MS_BO_PHAN"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_BO_PHAN"].ToString() && string.IsNullOrEmpty(x["MS_PT"].ToString()) == true && string.IsNullOrEmpty(x["MS_VI_TRI_PT"].ToString()) == true && x["DEL"].ToString() == "0"))
                        {
                            try
                            {
                                DataRow dr1 = dtTMP.Select().Where(x => x["MS_BO_PHAN"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_BO_PHAN"].ToString() && string.IsNullOrEmpty(x["MS_PT"].ToString()) == true && string.IsNullOrEmpty(x["MS_VI_TRI_PT"].ToString()) == true && x["DEL"].ToString() == "0").First();
                                dr1["MS_MAY"] = MS_MAY;
                                dr1["MS_PT"] = grvThongtinPT.GetDataRow(rowHandle)["MS_PT"].ToString();
                                dr1["MS_VI_TRI_PT"] = grvThongtinPT.GetDataRow(rowHandle)["MS_VI_TRI_PT"].ToString();
                                dr1["TEN_PT"] = grvThongtinPT.GetDataRow(rowHandle)["TEN_PT"].ToString();
                                dr1["DEL"] = 0;
                            }
                            catch
                            {
                                DataRow dr = dtTMP.NewRow();
                                dr["MS_MAY"] = MS_MAY;
                                try
                                {
                                    dr["STT_VAN_DE"] = -1;
                                }
                                catch { }
                                try
                                {
                                    dr["STT_BO_PHAN"] = -1;
                                }
                                catch
                                {
                                    dr["STT"] = -1;
                                }
                                dr["MS_BO_PHAN"] = grvThongtinPT.GetDataRow(rowHandle)["MS_BO_PHAN"].ToString();
                                dr["TEN_BO_PHAN"] = grvThongtinPT.GetDataRow(rowHandle)["TEN_BO_PHAN"].ToString();
                                dr["MS_PT"] = grvThongtinPT.GetDataRow(rowHandle)["MS_PT"].ToString();
                                dr["MS_VI_TRI_PT"] = grvThongtinPT.GetDataRow(rowHandle)["MS_VI_TRI_PT"].ToString();
                                dr["TEN_PT"] = grvThongtinPT.GetDataRow(rowHandle)["TEN_PT"].ToString();

                                dr["DEL"] = 0;
                                dtTMP.Rows.Add(dr);
                            }
                            if (Convert.ToBoolean(grvThongtinPT.GetRowCellValue(rowHandle, "CHON").ToString()) == false)
                                grvThongtinPT.SetRowCellValue(rowHandle, "CHON", true);
                            else
                                grvThongtinPT.SetRowCellValue(rowHandle, "CHON", false);
                        }
                        else
                        {
                            DataRow dr = dtTMP.NewRow();
                            dr["MS_MAY"] = MS_MAY;
                            try
                            {
                                dr["STT_VAN_DE"] = -1;
                            }
                            catch { }
                            try
                            {
                                dr["STT_BO_PHAN"] = -1;
                            }
                            catch
                            {
                                dr["STT"] = -1;
                            }
                            dr["MS_BO_PHAN"] = grvThongtinPT.GetDataRow(rowHandle)["MS_BO_PHAN"].ToString();
                            dr["TEN_BO_PHAN"] = grvThongtinPT.GetDataRow(rowHandle)["TEN_BO_PHAN"].ToString();
                            dr["MS_PT"] = grvThongtinPT.GetDataRow(rowHandle)["MS_PT"].ToString();
                            dr["MS_VI_TRI_PT"] = grvThongtinPT.GetDataRow(rowHandle)["MS_VI_TRI_PT"].ToString();
                            dr["TEN_PT"] = grvThongtinPT.GetDataRow(rowHandle)["TEN_PT"].ToString();

                            dr["DEL"] = 0;

                            dtTMP.Rows.Add(dr);
                            if (Convert.ToBoolean(grvThongtinPT.GetRowCellValue(rowHandle, "CHON").ToString()) == false)
                                grvThongtinPT.SetRowCellValue(rowHandle, "CHON", true);
                            else
                                grvThongtinPT.SetRowCellValue(rowHandle, "CHON", false);
                        }
                        tlstCauTruc.FocusedNode.Checked = tlstCauTruc.FocusedNode.Checked ? true : true;                        
                    }
                    else
                    {
                        DataRow dr = dtTMP.Select().Where(x => x["MS_BO_PHAN"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_BO_PHAN"].ToString() && x["MS_PT"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_PT"].ToString() && x["MS_VI_TRI_PT"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_VI_TRI_PT"].ToString()).First(); //"MS_BO_PHAN = " + grvThongtinPT.GetDataRow(rowHandle)["MS_BO_PHAN"].ToString() + " AND MS_PT = " + grvThongtinPT.GetDataRow(rowHandle)["MS_PT"].ToString()).First();
                        try
                        {
                            DataRow dr1 = dtTMP.Select().Where(x => x["MS_BO_PHAN"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_BO_PHAN"].ToString() && !string.IsNullOrEmpty(x["MS_PT"].ToString()) == true && x["MS_PT"].ToString() != dr["MS_PT"].ToString() && x["MS_VI_TRI_PT"].ToString() != dr["MS_VI_TRI_PT"].ToString() && x["DEL"].ToString() == "0").First(); //"MS_BO_PHAN = " + grvThongtinPT.GetDataRow(rowHandle)["MS_BO_PHAN"].ToString() + " AND MS_PT = " + grvThongtinPT.GetDataRow(rowHandle)["MS_PT"].ToString()).First();
                            dr["MS_PT"] = dr1["MS_PT"];
                            dr["MS_VI_TRI_PT"] = dr1["MS_VI_TRI_PT"];
                            dr["TEN_PT"] = dr1["TEN_PT"].ToString();

                            if (dr1["STT_BO_PHAN"].ToString().Equals("-1"))
                            {
                                dtTMP.Rows.Remove(dr1);
                            }
                            else
                            {
                                dr1["MS_PT"] = "";
                                dr1["MS_VI_TRI_PT"] = "";
                                dr1["DEL"] = 1;
                            }
                        }
                        catch
                        {
                            dr["MS_PT"] = "";
                            dr["MS_VI_TRI_PT"] = "";
                            dr["TEN_PT"] = "";
                        }
                        if (Convert.ToBoolean(grvThongtinPT.GetRowCellValue(rowHandle, "CHON").ToString()) == false)
                            grvThongtinPT.SetRowCellValue(rowHandle, "CHON", true);
                        else
                            grvThongtinPT.SetRowCellValue(rowHandle, "CHON", false);
                    }                
                }
            }
            catch
            {              
            }

        }


        private void grvThongtinPT_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var hitInfo = grvThongtinPT.CalcHitInfo(e.Location);
            if (hitInfo.InRowCell)
            {
                int rowHandle = hitInfo.RowHandle;
            }
        }

        private void tlstCauTruc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Check") return;
            if (e.Node.GetValue("TEN_BO_PHAN").ToString() == MS_MAY) return;
       
            ShowVTPT(tlstCauTruc.FocusedNode["MS_BO_PHAN"].ToString());

        }

        private void tlstCauTruc_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Check") return;
            Commons.Modules.SQLString = "0Check";
            tlstCauTruc.FocusedNode = e.Node;
            Commons.Modules.SQLString = "";
            if (tlstCauTruc.FocusedNode.Checked == false)
            {
                if (dtTMP.Select().Any(x => x["MS_BO_PHAN"].ToString() == tlstCauTruc.FocusedNode["MS_BO_PHAN"].ToString()))
                {
                    var rowsToDelete = dtTMP.AsEnumerable()
                             .Where(x => x["MS_BO_PHAN"].ToString() == tlstCauTruc.FocusedNode["MS_BO_PHAN"].ToString())
                             .ToList();
                    foreach (var row in rowsToDelete.ToList())
                    {
                        row["DEL"] = 1;
                        row["MS_PT"] = "";
                        row["MS_VI_TRI_PT"] = "";
                    }
                    for (int i = 0; i < grvThongtinPT.DataRowCount; i++)
                    {
                        DataRow dr = grvThongtinPT.GetDataRow(i);
                        dr["CHON"] = false;
                    }
                }
            }
            else
            {
                if (!dtTMP.Select().Any(x => x["MS_BO_PHAN"].ToString() == tlstCauTruc.FocusedNode["MS_BO_PHAN"].ToString()))
                {
                    DataRow dr = dtTMP.NewRow();
                    dr["MS_MAY"] = MS_MAY;
                    try
                    {
                        dr["STT_VAN_DE"] = -1;
                    }
                    catch
                    {
                    }
                    try
                    {
                        dr["STT_BO_PHAN"] = -1;
                    }
                    catch
                    {
                        dr["STT"] = -1;
                    }
                    dr["MS_BO_PHAN"] = tlstCauTruc.FocusedNode["MS_BO_PHAN"].ToString();
                    dr["TEN_BO_PHAN"] = tlstCauTruc.FocusedNode["TEN_BO_PHAN"].ToString().Split(':')[1].Trim();
                    dr["MS_PT"] = "";
                    dr["MS_VI_TRI_PT"] = "";
                    dr["TEN_PT"] = "";

                    dr["DEL"] = 0;

                    dtTMP.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = dtTMP.Select().Where(x => x["MS_BO_PHAN"].ToString() == tlstCauTruc.FocusedNode["MS_BO_PHAN"].ToString()).First();
                    dr["DEL"] = 0;
                }
            }
            ShowVTPT(tlstCauTruc.FocusedNode["MS_BO_PHAN"].ToString());
            tlstCauTruc.ExpandAll();
        }
       
    }
}
