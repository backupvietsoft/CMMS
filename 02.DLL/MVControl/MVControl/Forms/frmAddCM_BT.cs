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
using Commons.VS.Classes.Catalogue;
using DevExpress.XtraEditors.Repository;

namespace MVControl
{

    public partial class frmAddCM_BT : XtraForm
    {
        public string MS_CONG_NHAN = "";
        public DataTable dtTTPT1;
        
        public frmAddCM_BT()
        {
            InitializeComponent();
        }

        public DataTable dtTMP = new DataTable();


        private void DuyetAllNode(TreeListNodes treelistNodes)
        {

            foreach (TreeListNode item in treelistNodes)
            {
                if (dtTMP.Select().Any(x => x["MS_CHUYEN_MON"].ToString() == item.GetValue("MS_CHUYEN_MON").ToString() && x["DEL"].ToString() == "0"))
                {

                    item.Checked = !item.Checked ? true : true;
                }
                DuyetAllNode(item.Nodes);

            }

        }

        private void ShowBacTho(string MS_CHUYEN_MON)
        {
            try
            {
                dtTTPT1 = new DataTable();
                this.grdThongtinPT.DataSource = null;
                string SQL = "SELECT CONVERT(BIT, 0) AS CHON, T.*, CONVERT(NVARCHAR(20), '') AS NGAY, MS_CHUYEN_MON, CONVERT(INT, 0) AS DEL FROM BAC_THO T CROSS JOIN CHUYEN_MON WHERE MS_CHUYEN_MON = " + MS_CHUYEN_MON;
                dtTTPT1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL));
                dtTTPT1.Columns["CHON"].ReadOnly = false;
                dtTTPT1.Columns["DEL"].ReadOnly = false;
                dtTTPT1.Columns["NGAY"].ReadOnly = false;

                for (int i = 0; i <= dtTMP.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= dtTTPT1.Rows.Count - 1; j++)
                    {
                        if (dtTMP.Rows[i]["MS_CHUYEN_MON"].ToString().Trim() == dtTTPT1.Rows[j]["MS_CHUYEN_MON"].ToString().Trim() && dtTMP.Rows[i]["MS_BAC_THO"].ToString().Trim() == dtTTPT1.Rows[j]["MS_BAC_THO"].ToString().Trim() && dtTMP.Rows[i]["DEL"].ToString().Trim() == "0")
                        { 
                            dtTTPT1.Rows[j]["CHON"] = true;
                            dtTTPT1.Rows[j]["NGAY"] = dtTMP.Rows[i]["NGAY"];
                            dtTTPT1.Rows[j]["DEL"] = dtTMP.Rows[i]["DEL"];
                            break;
                        }
                    }
                }
                //dtTTPT1.DefaultView.RowFilter = "MS_CHUYEN_MON = '" + tlstCauTruc.

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdThongtinPT, grvThongtinPT, dtTTPT1, true, true, false, false, true, "");

                RepositoryItemDateEdit cboDateEdit = new RepositoryItemDateEdit();
                cboDateEdit.Name = "NGAY";
                cboDateEdit.NullText = "";
                cboDateEdit.NullDate = "";
                cboDateEdit.DisplayFormat.FormatString = "dd/MM/yyyy";
                cboDateEdit.EditMask = "dd/MM/yyyy";
                //grdThongtinPT.RepositoryItems.Add(cboDateEdit);
                grvThongtinPT.Columns["NGAY"].ColumnEdit = cboDateEdit;

                grvThongtinPT.Columns["DEL"].Visible = false;
                grvThongtinPT.Columns["MS_BAC_THO"].Visible = false;
                grvThongtinPT.Columns["MS_CHUYEN_MON"].Visible = false;
                grvThongtinPT.Columns["TEN_BAC_THO"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_BAC_THO", Commons.Modules.TypeLanguage);
                grvThongtinPT.Columns["TEN_BAC_THO"].OptionsColumn.ReadOnly = true;
                grvThongtinPT.Columns["CHON"].OptionsColumn.AllowEdit = true;
                grvThongtinPT.Columns["NGAY"].OptionsColumn.AllowEdit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                        //dtTMP.DefaultView.RowFilter = "(DEL <> 1)";
                    }
                    catch
                    {
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
                    if(string.IsNullOrEmpty(grvThongtinPT.GetDataRow(rowHandle)["NGAY"].ToString()))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChonNgayTruoc", Commons.Modules.TypeLanguage), "");
                        return;
                    }
                    if (!dtTMP.Select().Any(x => x["MS_CHUYEN_MON"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_CHUYEN_MON"].ToString() && x["MS_BAC_THO"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_BAC_THO"].ToString() && x["DEL"].ToString() == "0"))
                    {
                        if (dtTMP.Select().Any(x => x["MS_CHUYEN_MON"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_CHUYEN_MON"].ToString() && x["MS_BAC_THO"].ToString() == "-1" && x["DEL"].ToString() == "0"))
                        {
                            try
                            {
                                DataRow dr1 = dtTMP.Select().Where(x => x["MS_CHUYEN_MON"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_CHUYEN_MON"].ToString() && x["MS_BAC_THO"].ToString() == "-1" && x["DEL"].ToString() == "0").First();
                                dr1["MS_BAC_THO"] = grvThongtinPT.GetDataRow(rowHandle)["MS_BAC_THO"].ToString();
                                dr1["NGAY"] = grvThongtinPT.GetDataRow(rowHandle)["NGAY"].ToString();
                                dr1["TEN_BAC_THO"] = grvThongtinPT.GetDataRow(rowHandle)["TEN_BAC_THO"].ToString();
                                dr1["DEL"] = 0;
                            }
                            catch 
                            {
                                DataRow dr = dtTMP.NewRow();
                                dr["MS_CONG_NHAN"] = MS_CONG_NHAN;
                                dr["MS_BAC_THO"] = grvThongtinPT.GetDataRow(rowHandle)["MS_BAC_THO"].ToString();
                                dr["MS_CHUYEN_MON"] = tlstCauTruc.FocusedNode["MS_CHUYEN_MON"].ToString();
                                dr["TEN_BAC_THO"] = grvThongtinPT.GetDataRow(rowHandle)["TEN_BAC_THO"].ToString();
                                dr["TEN_CHUYEN_MON"] = tlstCauTruc.FocusedNode["TEN_CHUYEN_MON"].ToString();

                                dr["NGAY"] = grvThongtinPT.GetDataRow(rowHandle)["NGAY"].ToString();
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
                            //dr["MS_MAY"] = MS_MAY;
                            dr["MS_CONG_NHAN"] = MS_CONG_NHAN;
                            dr["MS_BAC_THO"] = grvThongtinPT.GetDataRow(rowHandle)["MS_BAC_THO"].ToString();
                            dr["MS_CHUYEN_MON"] = tlstCauTruc.FocusedNode["MS_CHUYEN_MON"].ToString();
                            dr["NGAY"] = grvThongtinPT.GetDataRow(rowHandle)["NGAY"].ToString();
                            dr["TEN_BAC_THO"] = grvThongtinPT.GetDataRow(rowHandle)["TEN_BAC_THO"].ToString();
                            dr["TEN_CHUYEN_MON"] = tlstCauTruc.FocusedNode["TEN_CHUYEN_MON"].ToString();
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
                        DataRow dr = dtTMP.Select().Where(x => x["MS_CHUYEN_MON"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_CHUYEN_MON"].ToString() && x["MS_BAC_THO"].ToString() == grvThongtinPT.GetDataRow(rowHandle)["MS_BAC_THO"].ToString()).First();
                        try
                        {
                          
                            dr["DEL"] = 1;                            
                        }
                        catch
                        {
                        }
                        if (Convert.ToBoolean(grvThongtinPT.GetRowCellValue(rowHandle, "CHON").ToString()) == false)
                            grvThongtinPT.SetRowCellValue(rowHandle, "CHON", true);
                        else
                            grvThongtinPT.SetRowCellValue(rowHandle, "CHON", false);
                    }
                    grvThongtinPT.RefreshData();
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
            ShowBacTho(tlstCauTruc.FocusedNode["MS_CHUYEN_MON"].ToString());
        }

        private void tlstCauTruc_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {

            if (Commons.Modules.SQLString == "0Check") return;
            Commons.Modules.SQLString = "0Check";
            tlstCauTruc.FocusedNode = e.Node;
            Commons.Modules.SQLString = "";
            if (tlstCauTruc.FocusedNode.Checked == false)
            {
                if (dtTMP.Select().Any(x => x["MS_CHUYEN_MON"].ToString() == tlstCauTruc.FocusedNode["MS_CHUYEN_MON"].ToString()))
                {
                    var rowsToDelete = dtTMP.AsEnumerable().Where(x => x["MS_CHUYEN_MON"].ToString() == tlstCauTruc.FocusedNode["MS_CHUYEN_MON"].ToString())
                             .ToList();
                    foreach (var row in rowsToDelete.ToList())
                    {
                        row["DEL"] = 2;
                        row["MS_BAC_THO"] = -1;
                        row["TEN_BAC_THO"] = "";
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
                if (!dtTMP.Select().Any(x => x["MS_CHUYEN_MON"].ToString() == tlstCauTruc.FocusedNode["MS_CHUYEN_MON"].ToString()))
                {
                    DataRow dr = dtTMP.NewRow();
                    dr["MS_CONG_NHAN"] = MS_CONG_NHAN;
                    dr["MS_BAC_THO"] = -1;
                    dr["TEN_BAC_THO"] = "";
                    dr["MS_CHUYEN_MON"] = tlstCauTruc.FocusedNode["MS_CHUYEN_MON"].ToString();
                    dr["TEN_CHUYEN_MON"] = tlstCauTruc.FocusedNode["TEN_CHUYEN_MON"].ToString();
                    dr["DEL"] = 0;
                    dtTMP.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = dtTMP.Select().Where(x => x["MS_CHUYEN_MON"].ToString() == tlstCauTruc.FocusedNode["MS_CHUYEN_MON"].ToString()).First();
                    dr["DEL"] = 0;
                }
            }
            ShowBacTho(tlstCauTruc.FocusedNode["MS_CHUYEN_MON"].ToString());
            tlstCauTruc.ExpandAll();
        }

        private void frmAddCM_BT_Load(object sender, EventArgs e)
        {

            string sql = "SELECT * FROM CHUYEN_MON ORDER BY TEN_CHUYEN_MON";
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql));
            tlstCauTruc.KeyFieldName = "MS_CHUYEN_MON";
            tlstCauTruc.DataSource = dt;

            //dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetChuyenMonBacTho_CONGNHAN", MS_CONG_NHAN));
            dtTMP.Columns["MS_BAC_THO"].AllowDBNull = true;
            dtTMP.Columns["NGAY"].AllowDBNull = true;
            dtTMP.Columns["DEL"].ReadOnly = false;
            dtTMP.Columns["NGAY"].ReadOnly = false;
            dtTMP.Columns["MS_BAC_THO"].ReadOnly = false;
        
            dtTMP.Columns["TEN_CHUYEN_MON"].ReadOnly = false;
            dtTMP.Columns["TEN_BAC_THO"].ReadOnly = false;
            dtTMP.Columns["TEN_CHUYEN_MON"].AllowDBNull = true;
            dtTMP.Columns["TEN_BAC_THO"].AllowDBNull = true;
            DuyetAllNode(tlstCauTruc.Nodes);


            Commons.Modules.ObjSystems.ThayDoiNN(this);
            tlstCauTruc.ExpandAll();

        }
    }

}