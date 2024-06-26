using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WareHouse
{
    public partial class frmTaiLieu : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Khai báo toàn cục
        /// </summary>
        private DataTable TbTaiLieu = new DataTable();
        private BindingSource BindingTaiLieu = new BindingSource();
        private DataTable TbQTDuyetTL = new DataTable();
        private string TrangThai = String.Empty;        
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public frmTaiLieu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        private void InitializeDatabase()
        {
            Vietsoft.SqlInfo SqlDocument = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            TbTaiLieu.Load(SqlDocument.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DOCUMENT"));

            foreach (DataColumn DtColumn in TbTaiLieu.Columns)
            {
                DtColumn.AllowDBNull = true;
            }

            TbTaiLieu.Columns["MS_TO"].ReadOnly = false;
            TbTaiLieu.Columns["MS_QT"].ReadOnly = false;
            TbTaiLieu.Columns["MAC_DINH"].ReadOnly = false;


            TbTaiLieu.TableNewRow += new DataTableNewRowEventHandler(TbTaiLieu_TableNewRow);
            BindingTaiLieu.DataSource = TbTaiLieu;
            BindingTaiLieu.CurrentChanged += new EventHandler(BindingTaiLieu_CurrentChanged);
            DgvTaiLieu.AutoGenerateColumns = false;
            DgvTaiLieu.DataSource = BindingTaiLieu;

            DgvTaiLieu.Columns["TEN_TAI_LIEU"].DataPropertyName = "TEN_TL";
            BindingControl();

            TbQTDuyetTL.Load(SqlDocument.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_REVIEW"));
            foreach (DataColumn DtColumn in TbQTDuyetTL.Columns)
            {
                DtColumn.AllowDBNull = true;
            }
            TbQTDuyetTL.Columns["QUYET_DINH"].DefaultValue = false;
            TbQTDuyetTL.Columns["BAT_BUOC"].DefaultValue = false;
            TbQTDuyetTL.TableNewRow += new DataTableNewRowEventHandler(TbQTDuyetTL_TableNewRow);
            try
            {
                TbQTDuyetTL.Columns["MS_TL"].DefaultValue = ((DataRowView)DgvTaiLieu.CurrentRow.DataBoundItem).Row["MS_TL"];
                TbQTDuyetTL.DefaultView.RowFilter = "MS_TL = '" + ((DataRowView)DgvTaiLieu.CurrentRow.DataBoundItem).Row["MS_TL"].ToString().Trim() + "'";
            }
            catch
            {                
                TbQTDuyetTL.DefaultView.RowFilter = "0=1";
            }
            DataTable TbUser = new DataTable ();
            TbUser.Load (SqlDocument.ExecuteReader ( CommandType.StoredProcedure, "SP_Y_GET_USERNAME"));
            ((DataGridViewComboBoxColumn)DgvQTDTL.Columns["UserName"]).DataSource = TbUser;        
            ((DataGridViewComboBoxColumn)DgvQTDTL.Columns["UserName"]).ValueMember = "USERNAME";
            ((DataGridViewComboBoxColumn)DgvQTDTL.Columns["UserName"]).DisplayMember = "FULL_NAME";        

            DataTable TbUnit = new DataTable ();
            TbUnit.Load (SqlDocument.ExecuteReader ( CommandType.StoredProcedure , "SP_Y_GET_UNIT"));
            TbUnit.Columns["MS_DON_VI"].AllowDBNull = true;
            TbUnit.Rows.Add(DBNull.Value, String.Empty);
            ((DataGridViewComboBoxColumn)DgvQTDTL.Columns["DON_VI"]).DataSource = TbUnit;        
            ((DataGridViewComboBoxColumn)DgvQTDTL.Columns["DON_VI"]).ValueMember = "MS_DON_VI";
            ((DataGridViewComboBoxColumn)DgvQTDTL.Columns["DON_VI"]).DisplayMember = "TEN_NGAN";


            TbUnit = new DataTable();
            TbUnit.Load(SqlDocument.ExecuteReader(CommandType.Text, "SELECT A.USERNAME AS MS_CN, B.HO + ' ' +  B.TEN AS HO_TEN FROM dbo.USERS AS A INNER JOIN dbo.CONG_NHAN AS B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN UNION SELECT '-1','' UNION SELECT '','' "));
            TbUnit.Columns["MS_CN"].AllowDBNull = true;

            try
            {
                ((DataGridViewComboBoxColumn)DgvQTDTL.Columns["MS_CN"]).DataSource = TbUnit;
                ((DataGridViewComboBoxColumn)DgvQTDTL.Columns["MS_CN"]).ValueMember = "MS_CN";
                ((DataGridViewComboBoxColumn)DgvQTDTL.Columns["MS_CN"]).DisplayMember = "HO_TEN";
            }
            catch { }


            DgvQTDTL.AutoGenerateColumns = false ;
            DgvQTDTL.DataSource = TbQTDuyetTL.DefaultView;
            DgvQTDTL.Columns["STT_SX"].DataPropertyName = "STT_SX";
            DgvQTDTL.Columns["UserName"].DataPropertyName = "UserName";
            DgvQTDTL.Columns["VAI_TRO"].DataPropertyName = "VAI_TRO";
            DgvQTDTL.Columns["DON_VI"].DataPropertyName = "MS_DV";
            DgvQTDTL.Columns["QUYET_DINH"].DataPropertyName = "QUYET_DINH";
            DgvQTDTL.Columns["BAT_BUOC"].DataPropertyName = "BAT_BUOC";
            DgvQTDTL.Columns["MS_CN"].DataPropertyName = "UserName";

            TbTaiLieu.AcceptChanges ();
            TbQTDuyetTL.AcceptChanges();
        }       
        /// <summary>
        /// BindingControl
        /// </summary>
        private void BindingControl()
        {            
            TxtTL_V.DataBindings.Clear();
            TxtTL_V.DataBindings.Add("Text", BindingTaiLieu, "TEN_TL");
            TxtTL_E.DataBindings.Clear();
            TxtTL_E.DataBindings.Add("Text", BindingTaiLieu, "TEN_TL_E");
            TxtTL_H.DataBindings.Clear();
            TxtTL_H.DataBindings.Add("Text", BindingTaiLieu, "TEN_TL_CH");
            //MS_TO,MS_QT,MAC_DINH
            cboTo.DataBindings.Clear();
            cboTo.DataBindings.Add("EditValue", BindingTaiLieu, "MS_TO");

            cboQT.DataBindings.Clear();
            cboQT.DataBindings.Add("EditValue", BindingTaiLieu, "MS_QT");

            //chkMDinh.DataBindings.Clear();
            //chkMDinh.DataBindings.Add("Checked", BindingTaiLieu, "MAC_DINH");


        }
        /// <summary>
        /// Điều khiển form
        /// </summary>
        private void InitializeForm()
        {
            switch (TrangThai)
            {
                case "Add":                   
                case "Edit":
                    DgvTaiLieu.ReadOnly = true;
                    DgvTaiLieu.Enabled = false;
                    TxtTL_V.Properties.ReadOnly = false;
                    TxtTL_E.Properties.ReadOnly = false;
                    TxtTL_H.Properties.ReadOnly = false;
                    cboTo.Properties.ReadOnly = false;
                    cboQT.Properties.ReadOnly = false;
                    chkMDinh.Properties.ReadOnly = false;
                    DgvQTDTL.ReadOnly = false;
                    DgvQTDTL.Enabled = true;
                    DgvQTDTL.AllowUserToAddRows = true;
                    DgvQTDTL.AllowUserToDeleteRows = false;
                    BtnThem.Visible = false;
                    BtnSua.Visible = false;
                    BtnXoa.Visible = false;
                    BtnIn.Visible = false;
                    BtnThoat.Visible = false;
                    BtnLuu.Visible = true;
                    BtnHuy.Visible = true;
                    break;
                default :
                    DgvTaiLieu.ReadOnly = true;
                    DgvTaiLieu.Enabled = true;
                    TxtTL_V.Properties.ReadOnly = true;
                    TxtTL_E.Properties.ReadOnly = true;
                    TxtTL_H.Properties.ReadOnly = true;
                    cboTo.Properties.ReadOnly = true;
                    cboQT.Properties.ReadOnly = true;
                    chkMDinh.Properties.ReadOnly = true;
                    DgvQTDTL.ReadOnly = true;
                    DgvQTDTL.Enabled = true;
                    DgvQTDTL.AllowUserToAddRows = false;
                    if (TbQTDuyetTL.DefaultView.Count > 0)
                    {
                        DgvQTDTL.AllowUserToDeleteRows = true;
                    }
                    if (TbTaiLieu.DefaultView.Count > 0)
                    {
                        BtnThem.Visible = true;
                        BtnSua.Visible = true;
                        BtnXoa.Visible = true;
                        BtnIn.Visible = true;
                        BtnThoat.Visible = true;
                        BtnLuu.Visible = false;
                        BtnHuy.Visible = false;
                    }
                    else
                    {
                        BtnThem.Visible = true;
                        BtnSua.Visible = false;
                        BtnXoa.Visible = false;
                        BtnIn.Visible = false;
                        BtnThoat.Visible = true;
                        BtnLuu.Visible = false;
                        BtnHuy.Visible = false;
                    }
                    break;
            }
            DgvQTDTL.Columns["MS_CN"].ReadOnly = true;
        }
        /// <summary>
        /// TableNewRow
        /// </summary>
        void TbTaiLieu_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["MS_TL"] = Vietsoft.Information.GetID("TL");
        }
        void TbQTDuyetTL_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["MS_QT"] = Vietsoft.Information.GetID("QT");
        }
        /// <summary>
        /// Chọn tài liệu
        /// </summary>       
        void BindingTaiLieu_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                TbQTDuyetTL.Columns["MS_TL"].DefaultValue = ((DataRowView)BindingTaiLieu.Current).Row["MS_TL"];
                TbQTDuyetTL.DefaultView.RowFilter = "MS_TL = '" + ((DataRowView)BindingTaiLieu.Current).Row["MS_TL"].ToString().Trim() + "'";
            }
            catch
            {
                TbQTDuyetTL.DefaultView.RowFilter = "0=1";
            }
        }
        /// <summary>
        /// Load form
        /// </summary>
        private void frmDocument_Load(object sender, EventArgs e)
        {
            LoadCmb();
            InitializeDatabase();
            InitializeForm();
            
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            chkMDinh.Text = "";
        }
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        private void BtnThem_Click(object sender, EventArgs e)
        {
            BindingTaiLieu.AddNew();
            TrangThai = "Add";            
            InitializeForm();
        }       
        /// <summary>
        ///Sửa dữ liệu
        /// </summary>
        private void BtnSua_Click(object sender, EventArgs e)
        {
            TrangThai = "Edit";            
            InitializeForm();
        }
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Vietsoft.SqlInfo SqlDocument = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                SqlDocument.BeginTransaction();
                try
                {
                    Vietsoft.DataInfo.DeleteDataView(SqlDocument, "SP_Y_DELETE_REVIEW", TbQTDuyetTL.DefaultView, "MS_TL", "MS_QT");
                    Vietsoft.DataInfo.DeleteDataRow(SqlDocument, "SP_Y_DELETE_DOCUMENT", ((DataRowView)BindingTaiLieu.Current).Row, "MS_TL");
                    Vietsoft.DataInfo.ClearData(TbQTDuyetTL.DefaultView);
                    BindingTaiLieu.RemoveCurrent();
                    SqlDocument.CommitTransaction();
                    InitializeForm();
                }
                catch (Exception EX)
                {
                    SqlDocument.RollbackTransaction();
                    Vietsoft.Information.MsgBox(this, "MsgDeleteError" + "\n" + EX.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
        private void DgvQTDTL_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    Vietsoft.DataInfo.DeleteDataRow(Vietsoft.Information.ConnectionString, "SP_Y_DELETE_REVIEW", ((DataRowView)e.Row.DataBoundItem).Row,"MS_TL","MS_QT");
                }
                catch
                {
                    e.Cancel = true;
                    Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void DgvQTDTL_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TbQTDuyetTL.AcceptChanges();
        }  
        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            Validate();
            ErrorProvider.Clear();
            bool Flag = false;
            if (TxtTL_V.Text.Trim().Equals(String.Empty))
            {
                ErrorProvider.SetError(TxtTL_V, "Null data");
                ErrorProvider.SetIconAlignment(TxtTL_V, ErrorIconAlignment.MiddleLeft);
                Flag = true;
            }            
            for (int j = 0; j < DgvQTDTL.Rows.Count; j++)
            {
                for (int k = 0; k < DgvQTDTL.Columns.Count; k++)
                {
                    DgvQTDTL.Rows[j].Cells[k].ErrorText = String.Empty;
                }
            }

            for (int i = 0 ; i < DgvQTDTL.Rows.Count -1 ; i++)
            {
                if (DgvQTDTL.Rows[i].Cells["STT_SX"].Value.Equals(DBNull.Value) || DgvQTDTL.Rows[i].Cells["STT_SX"].Value == null)
                {
                    DgvQTDTL.Rows[i].Cells["STT_SX"].ErrorText = "Null data";
                    Flag = true;
                }
                if (DgvQTDTL.Rows[i].Cells["USERNAME"].Value.Equals(DBNull.Value) || DgvQTDTL.Rows[i].Cells["USERNAME"].Value == null)
                {
                    DgvQTDTL.Rows[i].Cells["USERNAME"].ErrorText = "Null data";
                    Flag = true;
                }
            }
 


            if (chkMDinh.Checked && cboTo.Text != "")
            {
                ErrorProvider.SetError(chkMDinh, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgMacDinhKhongDuocChonTo", Commons.Modules.TypeLanguage));
                ErrorProvider.SetIconAlignment(chkMDinh, ErrorIconAlignment.MiddleLeft);
                Flag = true;
            }

            if (!chkMDinh.Checked && cboTo.Text == "")
            {
                ErrorProvider.SetError(cboTo, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhaiChonTo", Commons.Modules.TypeLanguage));
                ErrorProvider.SetIconAlignment(cboTo, ErrorIconAlignment.MiddleLeft);
                Flag = true;
            }
            string sSql = "";
            Vietsoft.SqlInfo SqlDocument = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

            if (cboQT.Text == "")
            {
                ErrorProvider.SetError(cboQT, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhaiChonQT", Commons.Modules.TypeLanguage));
                ErrorProvider.SetIconAlignment(cboQT, ErrorIconAlignment.MiddleLeft);
                Flag = true;
            }
            if (!chkMDinh.Checked)
            {
                if (cboTo.Text != "")
                {
                    try
                    {
                        sSql = "SELECT CASE COUNT(*) WHEN NULL THEN 0 ELSE COUNT(*) END FROM DS_TL WHERE MS_QT = " + cboQT.EditValue + " AND MS_TO = '" + cboTo.EditValue.ToString() + "' AND MS_TL <> '" + ((DataRowView)DgvTaiLieu.CurrentRow.DataBoundItem).Row["MS_TL"].ToString().Trim() + "' ";
                        sSql = Convert.ToString(SqlDocument.ExecuteScalar(sSql));
                        if (int.Parse(sSql) > 0)
                        {
                            ErrorProvider.SetError(cboTo, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDaCoTo", Commons.Modules.TypeLanguage));
                            ErrorProvider.SetIconAlignment(cboTo, ErrorIconAlignment.MiddleLeft);
                            Flag = true;
                        }
                    }
                    catch { }             
                }
            }

            if (chkMDinh.Checked && cboQT.Text != "")
            {
                sSql = "SELECT CASE COUNT(*) WHEN NULL THEN 0 ELSE COUNT(*) END FROM DS_TL WHERE MS_QT = " + cboQT.EditValue + " AND MAC_DINH = 1 AND MS_TL <> '" + ((DataRowView)DgvTaiLieu.CurrentRow.DataBoundItem).Row["MS_TL"].ToString().Trim() + "' ";
                sSql = Convert.ToString(SqlDocument.ExecuteScalar(sSql));
                if (int.Parse(sSql) > 0)
                {
                    ErrorProvider.SetError(chkMDinh, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDaCoMacDinh", Commons.Modules.TypeLanguage));
                    ErrorProvider.SetIconAlignment(chkMDinh, ErrorIconAlignment.MiddleLeft);
                    Flag = true;
                }             
            }
            DataTable dtTmp = new DataTable();
            DataView dvTmp = new DataView();
            string sBT = "BT_TL_TMP" + Commons.Modules.UserName;
            try
            {
                dvTmp = (DataView)DgvQTDTL.DataSource;
                dtTmp = dvTmp.ToTable();
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
                sSql = " SELECT STT_SX FROM " + sBT + " WHERE QUYET_DINH = 0 ORDER BY STT_SX";
                dtTmp = new DataTable();
                dtTmp.Load( SqlDocument.ExecuteReader(sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTmp.Rows.Count; i++)
                    {
                        sSql = " SELECT CASE COUNT(*) WHEN NULL THEN 0 ELSE COUNT(*) END FROM  BT_TL_TMPADMINISTRATOR WHERE QUYET_DINH = 1 AND STT_SX < " + dtTmp.Rows[i][0].ToString();
                        sSql = Convert.ToString(SqlDocument.ExecuteScalar(sSql));
                        if (int.Parse(sSql) > 0)
                        {
                            
                            for (int j = 0; j < DgvQTDTL.Rows.Count; j++)
                            {
                                if (int.Parse(DgvQTDTL.Rows[j].Cells["STT_SX"].Value.ToString()) == int.Parse(dtTmp.Rows[i][0].ToString()))
                                {
                                    DgvQTDTL.Rows[j].Cells["QUYET_DINH"].ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBuocTruocDaQuyetDinh", Commons.Modules.TypeLanguage);
                                    break;
                                }
                            }
                            Flag = true;
                        }          
                    }
                }
            }
            catch { }



            if (Flag)
            {
                return;
            }

            SqlDocument.BeginTransaction();
            try
            {
                switch (TrangThai)
                {
                    case "Add":
                        Vietsoft.DataInfo.InsertDataRow(SqlDocument, "SP_Y_ADD_DOCUMENT", ((DataRowView)DgvTaiLieu.CurrentRow.DataBoundItem).Row);
                        Vietsoft.DataInfo.InsertDataView(SqlDocument, "SP_Y_ADD_REVIEW", TbQTDuyetTL.DefaultView);
                        break;
                    case "Edit":
                        Vietsoft.DataInfo.UpdateDataRow(SqlDocument, "SP_Y_EDIT_DOCUMENT", ((DataRowView)DgvTaiLieu.CurrentRow.DataBoundItem).Row);
                        Vietsoft.DataInfo.UpdateDataView(SqlDocument, "SP_Y_ADD_REVIEW", "SP_Y_EDIT_REVIEW", "SP_Y_CHECK_REVIEW", TbQTDuyetTL.DefaultView, "MS_TL", "MS_QT");
                        break;
                }

                
                sSql = "UPDATE DS_TL SET MS_TO = " + (cboTo.Text == "" ? "NULL" : cboTo.EditValue) + ", MS_QT = " + (cboQT.Text == "" ? "NULL" : cboQT.EditValue) + ", " +
                            " MAC_DINH = " + (chkMDinh.Checked ? "1" : "0") + " WHERE MS_TL = '" + ((DataRowView)DgvTaiLieu.CurrentRow.DataBoundItem).Row["MS_TL"].ToString().Trim() + "' ";

                SqlDocument.ExecuteNonQuery(sSql);

                SqlDocument.CommitTransaction();
                BindingTaiLieu.EndEdit();
                TbTaiLieu.AcceptChanges();
                TbQTDuyetTL.AcceptChanges();
                TrangThai = String.Empty;
                InitializeForm();
            }
            catch (Exception EX)
            {
                SqlDocument.RollbackTransaction();
                Vietsoft.Information.MsgBox(this, "MsgUpdateError" + "\n" + EX.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            GetMDinh();

        }
        /// <summary>
        /// Không lưu dữ liệu
        /// </summary>
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
            for (int j = 0; j < DgvQTDTL.Rows.Count; j++)
            {
                for (int k = 0; k < DgvQTDTL.Columns.Count; k++)
                {
                    DgvQTDTL.Rows[j].Cells[k].ErrorText = String.Empty;
                }
            }
            TrangThai = String.Empty;
            BindingTaiLieu.CancelEdit();
            TbTaiLieu.RejectChanges();
            TbQTDuyetTL.RejectChanges();
            InitializeForm();
            GetMDinh();
        }
        /// <summary>
        /// Thoát form
        /// </summary>
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvQTDTL_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (BtnThoat.Focus())
                return;
            if (e.ColumnIndex == 1 && BtnHuy.Visible == true)
            {
                for(int i =0 ;i<DgvQTDTL.Rows.Count;i++)
                {
                    string str = DgvQTDTL.Rows[i].Cells["UserName"].FormattedValue.ToString();
                    if (e.FormattedValue.Equals(str) && i != e.RowIndex)
                    {
                        Vietsoft.Information.MsgBox(this, "msgUserdatontai", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        e.Cancel = true;
                        return;
                    }
                }
            }

            if (e.ColumnIndex == 0 && BtnHuy.Visible == true)
            {
                string sSql = "";
                try
                {
                    for (int i = 0; i < DgvQTDTL.Rows.Count; i++)
                    {
                        string str = DgvQTDTL.Rows[i].Cells["STT_SX"].FormattedValue.ToString();
                        if (e.FormattedValue.Equals(str) && i != e.RowIndex)
                        {
                            Vietsoft.Information.MsgBox(this, "msgBuocDaTonTai", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                catch { }
            }
            
            
        }

        private void LoadCmb()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                Vietsoft.SqlInfo SqlDocument = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

                dtTmp.Load(SqlDocument.ExecuteReader(CommandType.Text, "SELECT DISTINCT MS_TO, TEN_TO FROM TO_PHONG_BAN UNION SELECT NULL,NULL ORDER BY TEN_TO"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTo, dtTmp, "MS_TO", "TEN_TO", lblMsTo.Text);
                
            }
            catch (Exception ex)
            {
            }

            try
            {
                DataTable dtTmp = new DataTable();
                Vietsoft.SqlInfo SqlDocument = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                dtTmp.Load(SqlDocument.ExecuteReader(CommandType.Text, "SELECT MS_QT, CASE 0 WHEN 0 THEN [TEN_QT_V] WHEN 1 THEN [TEN_QT_E] ELSE [TEN_QT_H] END AS TEN_QT " +
                        " FROM [DS_QUY_TRINH] UNION SELECT NULL,NULL ORDER BY CASE 0 WHEN 0 THEN [TEN_QT_V] WHEN 1 THEN [TEN_QT_E] ELSE [TEN_QT_H] END "));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboQT, dtTmp, "MS_QT", "TEN_QT", lblMsTo.Text);
            }
            catch (Exception ex)
            {
            }
        
        }

        private void DgvTaiLieu_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            GetMDinh();
        }

        private void GetMDinh()
        {

            try
            {
                chkMDinh.Checked = false;
                Vietsoft.SqlInfo SqlDocument = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                string sSql = "";
                sSql = "SELECT MAC_DINH FROM DS_TL WHERE MS_TL = '" + ((DataRowView)DgvTaiLieu.CurrentRow.DataBoundItem).Row["MS_TL"].ToString().Trim() + "' ";
                sSql = Convert.ToString(SqlDocument.ExecuteScalar(sSql));
                if (Boolean.Parse(sSql))
                {
                    chkMDinh.Checked = true;
                }
            }
            catch { }
        }

        private void chkMDinh_CheckedChanged(object sender, EventArgs e)
        {
            //if (TrangThai=="") return;
            //string sSql = "";
            //Vietsoft.SqlInfo SqlDocument = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            //if (chkMDinh.Checked && cboQT.Text != "")
            //{
            //    sSql = "SELECT COUNT(*) FROM DS_TL WHERE MS_QT = " + cboQT.EditValue + " AND MAC_DINH = 1 AND MS_TL <> '" + ((DataRowView)DgvTaiLieu.CurrentRow.DataBoundItem).Row["MS_TL"].ToString().Trim() + "' ";
            //    sSql = Convert.ToString(SqlDocument.ExecuteScalar(sSql));
            //    if (int.Parse(sSql) > 0)
            //    {
            //        ErrorProvider.SetError(chkMDinh, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDaCoMacDinh", Commons.Modules.TypeLanguage));
            //        ErrorProvider.SetIconAlignment(chkMDinh, ErrorIconAlignment.MiddleLeft);

            //    }
            //}
            //if (!chkMDinh.Checked && cboQT.Text != "")
            //{
            //    sSql = "SELECT COUNT(*) FROM DS_TL WHERE MS_QT = " + cboQT.EditValue + " AND MAC_DINH = 1 AND MS_TL <> '" + ((DataRowView)DgvTaiLieu.CurrentRow.DataBoundItem).Row["MS_TL"].ToString().Trim() + "' ";
            //    sSql = Convert.ToString(SqlDocument.ExecuteScalar(sSql));
            //    if (int.Parse(sSql) == 0)
            //    {
            //        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoMacDin", Commons.Modules.TypeLanguage));
            //        chkMDinh.Checked = true;
                    
            //    }
            //}
        }

        private void DgvQTDTL_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void DgvQTDTL_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void LabTitle_Click(object sender, EventArgs e)
        {

        }

    }
}