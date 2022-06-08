using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class frmPBTTaiLieu : DevExpress.XtraEditors.XtraForm
    {
        public static string MS_PHIEU_BAO_TRI = "";
        public static string flag = "false";
        DataTable dt = new DataTable();
        public frmPBTTaiLieu()
        {
            InitializeComponent();
        }
        private void VisibleButton(bool check)
        {
            btnXemTL.Visible = check;
            btnXoa.Visible = check;
            btnThoat.Visible = check;
            btnThem.Visible = check;
            btnGhi.Visible = !check;
            btnKhongGhi.Visible = !check;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                VisibleButton(false);
                grvTaiLieuPBT.AddNewRow();

                //Get the handle of the new row 
                int newRowHandle = grvTaiLieuPBT.FocusedRowHandle;

                grvTaiLieuPBT.SetRowCellValue(newRowHandle, "MS_PHIEU_BAO_TRI", MS_PHIEU_BAO_TRI);
                grvTaiLieuPBT.SetRowCellValue(newRowHandle, "HINH", "\\");


                string str = "";
                try
                {
                    str = "DROP TABLE TAM12" + Commons.Modules.UserName;
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

                }
                catch
                {

                }
                try
                {
                    str = "create TABLE [dbo].TAM12" + Commons.Modules.UserName + " (STT INT,DUONG_DAN NVARCHAR(255),TEN_TAI_LIEU NVARCHAR(255),STT_YC_NSD INT,STT_GSTT INT,HINH NVARCHAR(150))";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    str = "SELECT DUONG_DAN FROM PHIEU_BAO_TRI_HINH WHERE MS_PHIEU_BAO_TRI='" + MS_PHIEU_BAO_TRI + "'";
                    intSTT = Commons.Modules.ObjSystems.LaySTTChoTaiLieu(str);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch
            {

            }
        }

        private void frmPBTTaiLieu_Load(object sender, EventArgs e)
        {
            try
            {
                BindData();
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                lblMSPBT1.Text = MS_PHIEU_BAO_TRI;
            }
            catch
            { }
        }
        private void BindData()
        {
            try
            {
               
                if (grvTaiLieuPBT.Columns.Count == 0)
                {
                    dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGET_PHIEU_BAO_TRI_HINH", MS_PHIEU_BAO_TRI));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdTaiLieuPBT, grvTaiLieuPBT, dt, false, true, false, true);                
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdTaiLieuPBT, grvTaiLieuPBT, dt, false, false, false, true);

                }
                grvTaiLieuPBT.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
                grvTaiLieuPBT.Columns["STT"].Visible = false;
                grvTaiLieuPBT.Columns["HINH"].Visible = false;
                grvTaiLieuPBT.Columns["STT_YC_NSD"].Visible = false;
                grvTaiLieuPBT.Columns["STT_GSTT"].Visible = false;
                grvTaiLieuPBT.Columns["TEN_TAI_LIEU"].OptionsColumn.ReadOnly = true;
                grvTaiLieuPBT.Columns["DUONG_DAN"].OptionsColumn.ReadOnly = true;


                grvTaiLieuPBT.Columns["TEN_TAI_LIEU"].Width = 300;
                grvTaiLieuPBT.Columns["DUONG_DAN"].Width = 500;
                grvTaiLieuPBT.Columns["STT"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvTaiLieuPBT.RowCount > 0)
                {
                    if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThemTaiLieu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        string str = "";
                        DataTable tb = new DataTable();
                        str = "SELECT DUONG_DAN,HINH FROM TAM12" + Commons.Modules.UserName + " WHERE STT_YC_NSD =0 AND STT_GSTT=0 ";
                        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables[0];
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            if (tb.Rows[i]["DUONG_DAN"].ToString() != "")
                            {
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spINSERT_PHIEU_BAO_TRI_HINH", MS_PHIEU_BAO_TRI, "", tb.Rows[i]["DUONG_DAN"].ToString());
                                Commons.Modules.ObjSystems.LuuDuongDan(tb.Rows[i]["HINH"].ToString(), tb.Rows[i]["DUONG_DAN"].ToString());
                                flag = "true";
                            }
                        }
                        str = "DELETE FROM TAM12" + Commons.Modules.UserName;
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        try
                        {
                            str = "DROP TABLE TAM12" + Commons.Modules.UserName;
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        }
                        catch 
                        {

                        }
                        VisibleButton(true);
                        grdTaiLieuPBT.Enabled = true;
                        DeleteRowEmpty();

                        BindData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNotSuccess", Commons.Modules.TypeLanguage) + ": " + ex.Message);
            }
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            VisibleButton(true);
            grdTaiLieuPBT.Enabled = true;
            DeleteRowEmpty();
            BindData();
        }
        private void DeleteRowEmpty()
        {
            for (int i = 0; i <= grvTaiLieuPBT.RowCount - 1; i++)
            {
                if (grvTaiLieuPBT.GetDataRow(i)["DUONG_DAN"].ToString().Trim() == "")
                {
                    grvTaiLieuPBT.DeleteRow(i);
                }
            }
        }



        private void grvTaiLieuPBT_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }
        int intSTT = 0;

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            if (btnGhi.Visible == true)
            {
                GridHitInfo info = view.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    if (info.Column.Name.Contains("DUONG_DAN"))
                    {
                        OpenFileDialog openDialog = new OpenFileDialog();
                        openDialog.Multiselect = true;
                        if (openDialog.ShowDialog() == DialogResult.OK)
                        {
                            grvTaiLieuPBT.DeleteRow(grvTaiLieuPBT.FocusedRowHandle);
                            string[] FILE_PATHs = openDialog.FileNames;
                            string SERVER_PATH = Commons.Modules.ObjSystems.CapnhatTL(true, MS_PHIEU_BAO_TRI);

                            Cursor = Cursors.WaitCursor;
                            DataTable tb = new DataTable();
                            tb = dt.Copy();
                            for (int i = 0; i <= FILE_PATHs.Length - 1; i++)
                            {
                                DataRow dr = default(DataRow);
                                dr = tb.NewRow();
                                dr[0] = MS_PHIEU_BAO_TRI;
                                dr[1] = 0;
                                dr[2] = "";
                                dr[3] = SERVER_PATH + "\\" + MS_PHIEU_BAO_TRI + "_" + ((DateTime.Now.Day).ToString().Length < 2 ? (0 + DateTime.Now.Day) : (DateTime.Now.Day)) + ((DateTime.Now.Month).ToString().Length < 2 ? (0 + DateTime.Now.Month) : (DateTime.Now.Month)) + (DateTime.Now.Year.ToString()) + "_" + intSTT + Commons.Modules.ObjSystems.LayDuoiFile(FILE_PATHs[i]);
                                dr[4] = 0;
                                dr[5] = 0;
                                dr[6] = "";
                                tb.Rows.Add(dr);
                                string str = "INSERT INTO TAM12" + Commons.Modules.UserName + " (DUONG_DAN,HINH,STT_YC_NSD,STT_GSTT ) VALUES(N'" + SERVER_PATH + "\\" + MS_PHIEU_BAO_TRI + "_" + ((DateTime.Now.Day).ToString().Length < 2 ? (0 + DateTime.Now.Day).ToString() : DateTime.Now.Day.ToString()) + ((DateTime.Now.Month).ToString().Length < 2 ? (0 + DateTime.Now.Month) : (DateTime.Now.Month + DateTime.Now.Year)) + "_" + intSTT + Commons.Modules.ObjSystems.LayDuoiFile(FILE_PATHs[i]) + "','" + FILE_PATHs[i] + "'," + 0 + "," + 0 + ")";
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                                intSTT = intSTT + 1;
                            }
                            dt = tb.Copy();
                            BindData();
                            Cursor = Cursors.Default;
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvTaiLieuPBT.GetFocusedDataRow()["STT"].ToString() != "")
                {
                    if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoaTaiLieu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        string str = "DELETE FROM PHIEU_BAO_TRI_HINH WHERE STT = " + grvTaiLieuPBT.GetFocusedDataRow()["STT"];
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        grvTaiLieuPBT.DeleteRow(grvTaiLieuPBT.FocusedRowHandle);
                    }
                }
                else
                {
                    grvTaiLieuPBT.DeleteRow(grvTaiLieuPBT.FocusedRowHandle);
                }
            }
            catch
            { }
        }

        private void btnXemTL_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvTaiLieuPBT.RowCount > 0)
                {
                    Process.Start(grvTaiLieuPBT.GetFocusedDataRow()["DUONG_DAN"].ToString());
                }
                else
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKhongCoTaiLieu", Commons.Modules.TypeLanguage));

                }
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
