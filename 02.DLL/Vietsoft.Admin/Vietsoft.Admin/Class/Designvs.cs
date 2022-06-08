using System;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static class Designvs
    {
        /// <summary>
        /// Định dạng form
        /// </summary>
        public static void DesignForm(Form frmDesign)
        {
            try
            {
                Sqlvs sqlDesign = new Sqlvs();
                DataTable TbFrom = new DataTable();
                TbFrom.Load(sqlDesign.ExecuteReader(CommandType.StoredProcedure, "SP_S_FORM_DESIGN",frmDesign.Name));
                if (TbFrom.Rows.Count > 0)
                {
                    frmDesign.Tag = TbFrom.Rows[0]["ID"].ToString();
                    switch (Adminvs.Language)
                    {
                        case 1:
                            if (!TbFrom.Rows[0].IsNull("FORM_T_2"))
                            {
                                frmDesign.Text = TbFrom.Rows[0]["FORM_T_2"].ToString();
                            }
                            break;
                        case 2:
                            if (!TbFrom.Rows[0].IsNull("FORM_T_3"))
                            {
                                frmDesign.Text = TbFrom.Rows[0]["FORM_T_3"].ToString();
                            }
                            break;
                        default :
                            if (!TbFrom.Rows[0].IsNull("FORM_T_1"))
                            {
                                frmDesign.Text = TbFrom.Rows[0]["FORM_T_1"].ToString();
                            }
                            break;
                    }
                    if (!TbFrom.Rows[0].IsNull("FONT"))
                    {
                        frmDesign.Font = Fontvs.ToFont(TbFrom.Rows[0]["FONT"].ToString());
                    }
                    if (!TbFrom.Rows[0].IsNull("FONT_COLOR"))
                    {
                        frmDesign.ForeColor = Colorvs.ToColor(TbFrom.Rows[0]["FONT_COLOR"].ToString());
                    }
                    if (!TbFrom.Rows[0].IsNull("BACK_COLOR"))
                    {
                        frmDesign.BackColor = Colorvs.ToColor(TbFrom.Rows[0]["BACK_COLOR"].ToString());
                    }
                }
                else
                {
                    DataRow rForm = TbFrom.NewRow();
                    rForm["ID"] = IDvs.CREATE_ID("FORM");
                    frmDesign.Tag = rForm["ID"].ToString();
                    rForm["FORM_ID"] = frmDesign.Name;
                    rForm["REPORT"] = false;
                    Datavs.Insert(Adminvs.ConnectionString, "SP_S_INSERT_FORM", rForm);                    
                }
                DataTable TbDetial = new DataTable();
                TbDetial.Load(sqlDesign.ExecuteReader(CommandType.StoredProcedure, "SP_S_DETIAL_DESIGN", frmDesign.Name));                
                DataColumn[] kDetial = new DataColumn[1];
                kDetial[0] = TbDetial.Columns["DETIAL_ID"];
                TbDetial.PrimaryKey = kDetial;
                DesignDetial(frmDesign,TbDetial);                
            }
            catch { }
        }        
        /// <summary>
        /// Định dạng chi tiết
        /// </summary>
        private static void DesignDetial(Control ctrlDetial, DataTable TbDetial )
        {
            try
            {
                foreach (Control ctrlIn in ctrlDetial.Controls)
                {
                    switch (ctrlIn.GetType().ToString().ToUpper())
                    {
                        case "SYSTEM.WINDOWS.FORMS.TEXTBOX":
                            FormatTextBox((TextBox)ctrlIn, TbDetial);
                            break;
                        case "SYSTEM.WINDOWS.FORMS.TABCONTROL":
                            FormatTabControl((TabControl)ctrlIn, TbDetial);
                            break;
                        case "SYSTEM.WINDOWS.FORMS.RADIOBUTTON":
                            FormatRadioButton((RadioButton)ctrlIn, TbDetial);
                            break;                       
                        case "SYSTEM.WINDOWS.FORMS.MASKEDTEXTBOX":
                            FormatMaskedTextBox((MaskedTextBox)ctrlIn, TbDetial);
                            break;
                        case "SYSTEM.WINDOWS.FORMS.LISTVIEW":
                            FormatListView((ListView)ctrlIn, TbDetial);
                            break;                       
                        case "SYSTEM.WINDOWS.FORMS.LABEL":
                            FormatLabel((Label)ctrlIn, TbDetial);
                            break;                                               
                        case "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEW":
                            FormatDataGridView((DataGridView)ctrlIn, TbDetial);
                            break;                       
                        case "SYSTEM.WINDOWS.FORMS.CHECKBOX":
                            FormatCheckBox((CheckBox)ctrlIn, TbDetial);
                            break;
                        case "SYSTEM.WINDOWS.FORMS.BUTTON":
                            FormatButton((Button)ctrlIn, TbDetial);
                            break;                       
                    }
                    FormatControl(ctrlIn, TbDetial);
                    DesignDetial(ctrlIn, TbDetial);
                }
            }
            catch { }
        }
        /// <summary>
        /// Định dạng chung
        /// </summary>
        private static void FormatControl(Control ctrlIn , DataTable TbDetial )
        {
            if (TbDetial.Rows.Find(ctrlIn.Name) != null)
            {
                switch (Adminvs.Language)
                {
                    case 1:
                        if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("DETIAL_T_2"))
                        {
                            ctrlIn.Text = TbDetial.Rows.Find(ctrlIn.Name)["DETIAL_T_2"].ToString();
                        }
                        break;
                    case 2:
                        if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("DETIAL_T_3"))
                        {
                            ctrlIn.Text = TbDetial.Rows.Find(ctrlIn.Name)["DETIAL_T_3"].ToString();
                        }
                        break;
                    default:
                        if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("DETIAL_T_1"))
                        {
                            ctrlIn.Text = TbDetial.Rows.Find(ctrlIn.Name)["DETIAL_T_1"].ToString();
                        }
                        break;
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("FONT"))
                {
                    ctrlIn.Font = Fontvs.ToFont(TbDetial.Rows.Find(ctrlIn.Name)["FONT"].ToString());
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("FONT_COLOR"))
                {
                    ctrlIn.ForeColor = Colorvs.ToColor(TbDetial.Rows.Find(ctrlIn.Name)["FONT_COLOR"].ToString());
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("BACK_COLOR"))
                {
                    ctrlIn.BackColor = Colorvs.ToColor(TbDetial.Rows.Find(ctrlIn.Name)["BACK_COLOR"].ToString());
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("TOP"))
                {
                    ctrlIn.Top = Convert.ToInt32(TbDetial.Rows.Find(ctrlIn.Name)["TOP"]);
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("HEIGHT"))
                {
                    ctrlIn.Height = Convert.ToInt32(TbDetial.Rows.Find(ctrlIn.Name)["HEIGHT"]);
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("LEFT"))
                {
                    ctrlIn.Left = Convert.ToInt32(TbDetial.Rows.Find(ctrlIn.Name)["LEFT"]);
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("WITH"))
                {
                    ctrlIn.Width = Convert.ToInt32(TbDetial.Rows.Find(ctrlIn.Name)["WITH"]);
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("DOCK"))
                {
                    ctrlIn.Dock = Dockvs.ToDock(TbDetial.Rows.Find(ctrlIn.Name)["DOCK"].ToString());
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("RIGHT_TOLEFT"))
                {
                    if (Convert.ToBoolean(TbDetial.Rows.Find(ctrlIn.Name)["RIGHT_TOLEFT"]))
                    {
                        ctrlIn.RightToLeft = RightToLeft.Yes;
                    }
                    else
                    {
                        ctrlIn.RightToLeft = RightToLeft.Inherit;
                    }
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("VISIBLE"))
                {
                    ctrlIn.Visible = Convert.ToBoolean(TbDetial.Rows.Find(ctrlIn.Name)["VISIBLE"]);
                }
                if (!TbDetial.Rows.Find(ctrlIn.Name).IsNull("READONLY"))
                {
                    ctrlIn.Enabled = !Convert.ToBoolean(TbDetial.Rows.Find(ctrlIn.Name)["READONLY"]);
                }
            }
            else
            {
                if (!ctrlIn.Name.Equals(String.Empty))
                {
                    DataRow rDetial = TbDetial.NewRow();
                    rDetial["ID"] = IDvs.CREATE_ID("DETIAL");
                    rDetial["FORM_ID"] = ctrlIn.FindForm().Tag.ToString();
                    rDetial["DETIAL_ID"] = ctrlIn.Name;
                    rDetial["AUTOSIZE"] = false;
                    rDetial["VISIBLE"] = true;
                    rDetial["READONLY"] = false;
                    rDetial["RIGHT_TOLEFT"] = false;
                    rDetial["MULTI_SELECT"] = false;
                    Datavs.Insert(Adminvs.ConnectionString, "SP_S_INSERT_DETIAL", rDetial);
                }
            }
        }
        /// <summary>
        /// Định dạng TextBox
        /// </summary>
        private static void FormatTextBox(TextBox txtFormat,DataTable TbDetial)
        {
            try
            {
                if (TbDetial.Rows.Find(txtFormat.Name) != null)
                {
                    if (!TbDetial.Rows.Find(txtFormat.Name).IsNull("ALIMENT"))
                    {
                        txtFormat.TextAlign = Alimentvs.HoriAliment(TbDetial.Rows.Find(txtFormat.Name)["ALIMENT"].ToString ());
                    }
                    if (!TbDetial.Rows.Find(txtFormat.Name.Trim()).IsNull("MULTI_SELECT"))
                    {
                        txtFormat.Multiline = Convert.ToBoolean(TbDetial.Rows.Find(txtFormat.Name.Trim())["MULTI_SELECT"]);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// Định dạng TabControl
        /// </summary>
        private static void FormatTabControl(TabControl TabFormat , DataTable TbDetial)
        {
            try
            {
                foreach (TabPage TabPage in TabFormat.TabPages)
                {
                    FormatControl(TabPage, TbDetial);
                    DesignDetial(TabPage, TbDetial);
                }
            }
            catch { }
        }
        /// <summary>
        /// Định dạng RadioButton
        /// </summary>
        private static void FormatRadioButton(RadioButton rdoFormat , DataTable TbDetial)
        {
            try
            {
                if (TbDetial.Rows.Find(rdoFormat.Name) != null)
                {
                    if (!TbDetial.Rows.Find(rdoFormat.Name).IsNull("ALIMENT"))
                    {
                        rdoFormat.TextAlign = Alimentvs.ContentAliment(TbDetial.Rows.Find(rdoFormat.Name)["ALIMENT"].ToString ());
                    }
                }
            }
            catch { }
        }       
        /// <summary>
        /// Định dạng MaskedTextBox
        /// </summary>
        private static void FormatMaskedTextBox(MaskedTextBox mskFormat , DataTable TbDetial)
        {
            try
            {
                if (TbDetial.Rows.Find(mskFormat.Name) != null)
                {
                    if (!TbDetial.Rows.Find(mskFormat.Name).IsNull("ALIMENT"))
                    {
                        mskFormat.TextAlign = Alimentvs.HoriAliment(TbDetial.Rows.Find(mskFormat.Name)["ALIMENT"].ToString ());
                    }
                    if (!TbDetial.Rows.Find(mskFormat.Name.Trim()).IsNull("MULTI_SELECT"))
                    {
                        mskFormat.Multiline = Convert.ToBoolean(TbDetial.Rows.Find(mskFormat.Name)["MULTI_SELECT"]);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// Định dạng ListView
        /// </summary>
        private static void FormatListView(ListView ltvFormat , DataTable TbDetial)
        {
            try
            {
                foreach (ColumnHeader colFormat in ltvFormat.Columns)
                {
                    if (TbDetial.Rows.Find(colFormat.Name) != null)
                    {
                        switch (Adminvs.Language)
                        {
                            case 1:
                                if (!TbDetial.Rows.Find(colFormat.Name).IsNull("DETIAL_T_2"))
                                {
                                    colFormat.Text = TbDetial.Rows.Find(colFormat.Name)["DETIAL_T_2"].ToString();                                    
                                }
                                break;
                            case 2:
                                if (!TbDetial.Rows.Find(colFormat.Name).IsNull("DETIAL_T_3"))
                                {
                                    colFormat.Text = TbDetial.Rows.Find(colFormat.Name)["DETIAL_T_3"].ToString();
                                }
                                break;
                            default :
                                if (!TbDetial.Rows.Find(colFormat.Name).IsNull("DETIAL_T_1"))
                                {
                                    colFormat.Text = TbDetial.Rows.Find(colFormat.Name)["DETIAL_T_1"].ToString();
                                }
                                break;
                        }

                        if (!TbDetial.Rows.Find(colFormat.Name).IsNull("ALIMENT"))
                        {
                            colFormat.TextAlign = Alimentvs.HoriAliment(TbDetial.Rows.Find(colFormat.Name)["ALIMENT"].ToString ());
                        }
                        if (!TbDetial.Rows.Find(colFormat.Name).IsNull("WITH"))
                        {
                            colFormat.Width = Convert.ToInt32(TbDetial.Rows.Find(colFormat.Name)["WITH"]);
                        }
                    }
                }
            }
            catch { }
        }       
        /// <summary>
        /// Định dạng Label
        /// </summary>
        private static void FormatLabel(Label labFormat , DataTable TbDetial)
        {
            try
            {
                if (TbDetial.Rows.Find(labFormat.Name.Trim()) != null)
                {
                    if (!TbDetial.Rows.Find(labFormat.Name).IsNull("ALIMENT"))
                    {
                        labFormat.TextAlign = Alimentvs.ContentAliment(TbDetial.Rows.Find(labFormat.Name)["ALIMENT"].ToString ());
                    }
                    if (!TbDetial.Rows.Find(labFormat.Name).IsNull("AUTOSIZE"))
                    {
                        labFormat.AutoSize = Convert.ToBoolean(TbDetial.Rows.Find(labFormat.Name.Trim())["AUTOSIZE"]);
                    }
                }
            }
            catch { }
        }               
        /// <summary>
        /// Định dạng DataGridView
        /// </summary>
        private static void FormatDataGridView(DataGridView gvFormat, DataTable TbDetial)
        {
            try
            {
                if (TbDetial.Rows.Find(gvFormat.Name) != null)
                {
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("MULTI_SELECT"))
                    {
                        gvFormat.MultiSelect = Convert.ToBoolean(TbDetial.Rows.Find(gvFormat.Name)["MULTI_SELECT"]);
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("MODE"))
                    {
                        gvFormat.SelectionMode = Modevs.SelectMode(TbDetial.Rows.Find(gvFormat.Name)["MODE"].ToString ());
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("FONT_HEADER"))
                    {
                        gvFormat.ColumnHeadersDefaultCellStyle.Font = Fontvs.ToFont(TbDetial.Rows.Find(gvFormat.Name)["FONT_HEADER"].ToString());
                        gvFormat.RowHeadersDefaultCellStyle.Font = Fontvs.ToFont(TbDetial.Rows.Find(gvFormat.Name)["FONT_HEADER"].ToString());
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("FONT_COLOR_HEADER"))
                    {
                        gvFormat.EnableHeadersVisualStyles = false;
                        gvFormat.ColumnHeadersDefaultCellStyle.ForeColor = Colorvs.ToColor(TbDetial.Rows.Find(gvFormat.Name)["FONT_COLOR_HEADER"].ToString());
                        gvFormat.RowHeadersDefaultCellStyle.ForeColor = Colorvs.ToColor(TbDetial.Rows.Find(gvFormat.Name)["FONT_COLOR_HEADER"].ToString());
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("BACK_COLOR_HEADER"))
                    {
                        gvFormat.EnableHeadersVisualStyles = false;
                        gvFormat.ColumnHeadersDefaultCellStyle.BackColor = Colorvs.ToColor(TbDetial.Rows.Find(gvFormat.Name)["BACK_COLOR_HEADER"].ToString());
                        gvFormat.RowHeadersDefaultCellStyle.BackColor = Colorvs.ToColor(TbDetial.Rows.Find(gvFormat.Name)["BACK_COLOR_HEADER"].ToString());
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("ALIMENT_HEADER"))
                    {
                        gvFormat.ColumnHeadersDefaultCellStyle.Alignment = Alimentvs.DataGridViewContentAliment(TbDetial.Rows.Find(gvFormat.Name)["ALIMENT_HEADER"].ToString ());
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("HEADER_HEIGHT"))
                    {
                        gvFormat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                        gvFormat.ColumnHeadersHeight = Convert.ToInt32(TbDetial.Rows.Find(gvFormat.Name)["HEADER_HEIGHT"]);
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("HEADER_WITH"))
                    {
                        gvFormat.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                        gvFormat.RowHeadersWidth = Convert.ToInt32(TbDetial.Rows.Find(gvFormat.Name)["HEADER_WITH"]);
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("FONT_COLOR_ROW"))
                    {
                        gvFormat.AlternatingRowsDefaultCellStyle.ForeColor = Colorvs.ToColor(TbDetial.Rows.Find(gvFormat.Name)["FONT_COLOR_ROW"].ToString());
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("BACK_COLOR_ROW"))
                    {
                        gvFormat.AlternatingRowsDefaultCellStyle.BackColor = Colorvs.ToColor(TbDetial.Rows.Find(gvFormat.Name)["BACK_COLOR_ROW"].ToString());
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("FONT_COLOR_CURRENT"))
                    {
                        gvFormat.AlternatingRowsDefaultCellStyle.SelectionForeColor = Colorvs.ToColor(TbDetial.Rows.Find(gvFormat.Name)["FONT_COLOR_CURRENT"].ToString());
                    }
                    if (!TbDetial.Rows.Find(gvFormat.Name).IsNull("BACK_COLOR_CURRENT"))
                    {
                        gvFormat.AlternatingRowsDefaultCellStyle.SelectionBackColor = Colorvs.ToColor(TbDetial.Rows.Find(gvFormat.Name)["BACK_COLOR_CURRENT"].ToString());
                    }                                      
                }
                foreach (DataGridViewColumn colGridview in gvFormat.Columns)
                {
                    if (TbDetial.Rows.Find(colGridview.Name) != null)
                    {
                        switch (Adminvs.Language)
                        {
                            case 1:
                                if (!TbDetial.Rows.Find(colGridview.Name).IsNull("DETIAL_T_2"))
                                {
                                    colGridview.HeaderText = TbDetial.Rows.Find(colGridview.Name)["DETIAL_T_2"].ToString();
                                }
                                break;
                            case 2:
                                if (!TbDetial.Rows.Find(colGridview.Name).IsNull("DETIAL_T_3"))
                                {
                                    colGridview.HeaderText = TbDetial.Rows.Find(colGridview.Name)["DETIAL_T_3"].ToString();
                                }
                                break;
                            default:
                                if (!TbDetial.Rows.Find(colGridview.Name).IsNull("DETIAL_T_1"))
                                {
                                    colGridview.HeaderText = TbDetial.Rows.Find(colGridview.Name)["DETIAL_T_1"].ToString();
                                }
                                break;
                        }
                        if (!TbDetial.Rows.Find(colGridview.Name).IsNull("WITH"))
                        {
                            colGridview.MinimumWidth = Convert.ToInt32(TbDetial.Rows.Find(colGridview.Name)["WITH"]);
                            colGridview.Width = Convert.ToInt32(TbDetial.Rows.Find(colGridview.Name)["WITH"]);
                        }
                        if (!TbDetial.Rows.Find(colGridview.Name).IsNull("FONT"))
                        {
                            colGridview.DefaultCellStyle.Font = Fontvs.ToFont(TbDetial.Rows.Find(colGridview.Name)["FONT"].ToString());
                        }
                        if (!TbDetial.Rows.Find(colGridview.Name).IsNull("FONT_COLOR"))
                        {
                            colGridview.DefaultCellStyle.ForeColor = Colorvs.ToColor(TbDetial.Rows.Find(colGridview.Name)["FONT_COLOR"].ToString());
                        }
                        if (!TbDetial.Rows.Find(colGridview.Name).IsNull("BACK_COLOR"))
                        {
                            colGridview.DefaultCellStyle.BackColor = Colorvs.ToColor(TbDetial.Rows.Find(colGridview.Name)["BACK_COLOR"].ToString());
                        }
                        if (!TbDetial.Rows.Find(colGridview.Name).IsNull("ALIMENT"))
                        {
                            colGridview.DefaultCellStyle.Alignment = Alimentvs.DataGridViewContentAliment(TbDetial.Rows.Find(colGridview.Name)["ALIMENT"].ToString());
                        }
                        if (!TbDetial.Rows.Find(colGridview.Name).IsNull("DOCK"))
                        {
                            colGridview.AutoSizeMode = Dockvs.AutoSizeMode(TbDetial.Rows.Find(colGridview.Name)["DOCK"].ToString());
                        }
                        if (!TbDetial.Rows.Find(colGridview.Name).IsNull("VISIBLE"))
                        {
                            colGridview.Visible = Convert.ToBoolean(TbDetial.Rows.Find(colGridview.Name)["VISIBLE"]);
                        }
                        if (!TbDetial.Rows.Find(colGridview.Name).IsNull("READONLY"))
                        {
                            colGridview.Visible = Convert.ToBoolean(TbDetial.Rows.Find(colGridview.Name)["READONLY"]);
                        }
                    }
                    else
                    {
                        DataRow rDetial = TbDetial.NewRow();
                        rDetial["ID"] = IDvs.CREATE_ID("DETIAL");
                        rDetial["FORM_ID"] = gvFormat.FindForm().Tag.ToString();
                        rDetial["DETIAL_ID"] = colGridview.Name;
                        rDetial["AUTOSIZE"] = false;
                        rDetial["VISIBLE"] = true;
                        rDetial["READONLY"] = false;
                        rDetial["RIGHT_TOLEFT"] = false;
                        rDetial["MULTI_SELECT"] = false;
                        Datavs.Insert(Adminvs.ConnectionString, "SP_S_INSERT_DETIAL", rDetial);
                    }
                }
            }
            catch { }
        }        
        /// <summary>
        /// Định dạng CheckBox
        /// </summary>
        private static void FormatCheckBox(CheckBox chkFormat, DataTable TbDetial)
        {
            try
            {
                if (TbDetial.Rows.Find(chkFormat.Name) != null)
                {
                    if (!TbDetial.Rows.Find(chkFormat.Name).IsNull("ALIMENT"))
                    {
                        chkFormat.TextAlign = Alimentvs.ContentAliment(TbDetial.Rows.Find(chkFormat.Name)["ALIMENT"].ToString ());
                    }
                    if (!TbDetial.Rows.Find(chkFormat.Name).IsNull("AUTOSIZE"))
                    {
                        chkFormat.AutoSize = Convert.ToBoolean(TbDetial.Rows.Find(chkFormat.Name)["AUTOSIZE"]);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// Định dạng Button
        /// </summary>
        private static void FormatButton(Button btFormat, DataTable TbDetial)
        {
            try
            {
                if (TbDetial.Rows.Find(btFormat.Name) != null)
                {
                    if (!TbDetial.Rows.Find(btFormat.Name).IsNull("ALIMENT"))
                    {
                        btFormat.TextAlign = Alimentvs.ContentAliment(TbDetial.Rows.Find(btFormat.Name)["ALIMENT"].ToString ());
                    }
                    if (!TbDetial.Rows.Find(btFormat.Name).IsNull("AUTOSIZE"))
                    {
                        btFormat.AutoSize = Convert.ToBoolean(TbDetial.Rows.Find(btFormat.Name)["AUTOSIZE"]);
                    }
                }
            }
            catch { }
        }        
    }
}
