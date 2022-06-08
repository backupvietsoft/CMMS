using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Vietsoft
{
    public class DataGridViewEditor : DataGridView
    {
        /// <summary>
        /// Declare public
        /// </summary>
        private int _Index = -1;
        private string[] _ColumnFilter;
        private ArrayList _FilterValue = new ArrayList();
        private BindingSource _BindingSource = new BindingSource();
        private DataView _DataView = new DataView();
        private ToolStripDropDown _DropDownFilter = new ToolStripDropDown();
        private DataGridViewFilter _PupGridView = new DataGridViewFilter();
        /// <summary>
        ///ColumnFilter
        /// </summary>
        public void ColumnFilter(params string[]ColFilter)
        {
            _ColumnFilter = new string[ColFilter.Length];
            _ColumnFilter = ColFilter;            
        }
        /// <summary>
        /// DataSourceChanged
        /// </summary>
        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            _BindingSource = null;
            _DataView = new DataView();
            if (this.DataSource != null)
            {
                object objDataSource = this.DataSource;
                string strDataMember = this.DataMember;

                while (!(objDataSource is DataView))
                {
                    if (objDataSource is BindingSource)
                    {
                        _BindingSource = (BindingSource)objDataSource;
                        strDataMember = ((BindingSource)objDataSource).DataMember;
                        objDataSource = ((BindingSource)DataSource).DataSource;
                        continue;
                    }
                    if (objDataSource is DataSet)
                    {
                        objDataSource = ((DataSet)objDataSource).Tables[strDataMember];
                        DataMember = String.Empty;
                        continue;
                    }
                    if (objDataSource is DataTable)
                    {
                        objDataSource = ((DataTable)objDataSource).DefaultView;
                        break;
                    }
                    if (objDataSource is DataView)
                    {
                        objDataSource = ((DataView)objDataSource).Table.DefaultView;
                        break;
                    }
                }
                _DataView = (DataView)objDataSource;
            }
        }
        /// <summary>
        ///HeaderMouseClick
        /// </summary>
        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnColumnHeaderMouseClick(e);
            this.FindForm().Validate();
            try
            {               
                if (e.Button == MouseButtons.Right)
                {
                    _DropDownFilter = new ToolStripDropDown();
                    _Index = -1;
                    if (_ColumnFilter != null && _ColumnFilter.Length > 0)
                    {
                        bool Flag = false;
                        for (int i = 0; i < _ColumnFilter.Length; i++)
                        {
                            if (_ColumnFilter[i].Equals(this.Columns[e.ColumnIndex].Name))
                            {
                                _Index = e.ColumnIndex;
                                Flag = true;
                                break;
                            }
                        }
                        if (Flag)
                        {
                            ToolStripControlHost ControlHost;
                            _PupGridView = new DataGridViewFilter();
                            DataTable TbTypeFilter = new DataTable();
                            TbTypeFilter.Columns.Add("TYPE_FILTER", typeof(string));
                            Type TypeData = _DataView.Table.Columns[this.Columns[e.ColumnIndex].DataPropertyName].DataType;
                            if (TypeData == typeof(int) || TypeData == typeof(float) || TypeData == typeof (double) || TypeData == typeof (decimal) || TypeData == typeof(DateTime))
                            {
                                TbTypeFilter.Rows.Add("=");
                                TbTypeFilter.Rows.Add("<");
                                TbTypeFilter.Rows.Add("<=");
                                TbTypeFilter.Rows.Add(">");
                                TbTypeFilter.Rows.Add(">=");
                                TbTypeFilter.Rows.Add("<>");                                
                            }
                            else
                            {
                                if (TypeData == typeof(string))
                                {
                                    TbTypeFilter.Rows.Add("=");
                                    TbTypeFilter.Rows.Add("LIKE");
                                    TbTypeFilter.Rows.Add("%LIKE");
                                    TbTypeFilter.Rows.Add("LIKE%");
                                    TbTypeFilter.Rows.Add("<>");
                                }
                                else
                                {
                                    if (TypeData == typeof(bool))
                                    {
                                        TbTypeFilter.Rows.Add("=");
                                        TbTypeFilter.Rows.Add("<>");
                                    }
                                }
                            }
                            _PupGridView.Title = this.Columns[e.ColumnIndex].HeaderText;
                            _PupGridView.SourceTypeFilter = TbTypeFilter;
                            DataTable TbValueFilter = new DataTable();
                            TbValueFilter = _DataView.Table.Copy().DefaultView.ToTable(true, this.Columns[e.ColumnIndex].DataPropertyName);                            
                            _PupGridView.SourceValueFilter = TbValueFilter;
                            _PupGridView.ClearFilter.Click += new EventHandler(ClearFilter_Click);
                            _PupGridView.DeleteFilter.Click += new EventHandler(DeleteFilter_Click);
                            _PupGridView.AndFilter.Click += new EventHandler(AndFilter_Click);
                            _PupGridView.OrFilter.Click += new EventHandler(OrFilter_Click);
                            _PupGridView.ExitFilter.Click += new EventHandler(ExitFilter_Click);
                            if (_FilterValue.Count > 0)
                            {
                                _PupGridView.OrFilter.Enabled = true;
                            }
                            else
                            {
                                _PupGridView.OrFilter.Enabled = false;
                            }
                            ControlHost = new ToolStripControlHost(_PupGridView);                            
                            ControlHost.Padding = Padding.Empty;
                            ControlHost.Margin = Padding.Empty;
                            ControlHost.AutoSize = false;
                            _DropDownFilter.Padding = Padding.Empty;
                            _DropDownFilter.Items.Add(ControlHost);
                            _DropDownFilter.Region = this.Region;
                            _DropDownFilter.Show(this, this.GetCellDisplayRectangle(e.ColumnIndex, -1, false).X + this.GetCellDisplayRectangle(e.ColumnIndex, -1, false).Width, this.GetCellDisplayRectangle(e.ColumnIndex, -1, false).Y - 1);
                            _DropDownFilter.Focus();
                        }
                    }
                }
            }
            catch { }
        }      
        /// <summary>
        ///ExitFilter
        /// </summary>
        void ExitFilter_Click(object sender, EventArgs e)
        {
            _DropDownFilter.Close();
        }
        /// <summary>
        ///Filterdata
        /// </summary>
        void AndFilter_Click(object sender, EventArgs e)
        {
            try
            {
                _PupGridView.Validate();                
                if (_Index != -1)
                {
                    Type DataType = _DataView.Table.Columns[this.Columns[_Index].DataPropertyName].DataType;                                      
                    ArrayList NodeFilter = new ArrayList();
                    NodeFilter.Add(this.Columns[_Index].DataPropertyName);
                    NodeFilter.Add(DataType);
                    NodeFilter.Add(_PupGridView.TypeFilter.Text);
                    NodeFilter.Add(_PupGridView.ValueFilter.Text);
                    NodeFilter.Add(" And ");
                    bool Flag = false;
                    for (int i = 0; i < _FilterValue.Count; i++)
                    {
                        if ((ArrayList)_FilterValue[i] == NodeFilter)
                        {
                            Flag = true;
                            break;
                        }
                    }
                    if (Flag == false)
                    {
                        _FilterValue.Add(NodeFilter);
                    }
                    if (_BindingSource != null)
                    {
                        _BindingSource.Filter = StringFilter();
                    }
                    else
                    {
                        _DataView.RowFilter = StringFilter();
                    }
                }
                foreach (DataGridViewColumn DgvCol in this.Columns)
                {
                    DgvCol.ToolTipText  = ToolTipColumn();
                }
            }
            catch
            {
                _FilterValue.Clear();
                if (_BindingSource != null)
                {
                    _BindingSource.Filter = StringFilter();
                }
                else
                {
                    _DataView.RowFilter = StringFilter();
                }
                _DropDownFilter.Close();
                foreach (DataGridViewColumn DgvCol in this.Columns)
                {
                    DgvCol.ToolTipText = String.Empty;
                }
            }
            if (_FilterValue.Count > 0)
            {
                _PupGridView.OrFilter.Enabled = true;
            }
            else
            {
                _PupGridView.OrFilter.Enabled = false;
            }
        }
        void OrFilter_Click(object sender, EventArgs e)
        {
            try
            {
                _PupGridView.Validate();
                if (_Index != -1)
                {
                    Type DataType = _DataView.Table.Columns[this.Columns[_Index].DataPropertyName].DataType;
                    ArrayList NodeFilter = new ArrayList();
                    NodeFilter.Add(this.Columns[_Index].DataPropertyName);
                    NodeFilter.Add(DataType);
                    NodeFilter.Add(_PupGridView.TypeFilter.Text);
                    NodeFilter.Add(_PupGridView.ValueFilter.Text);
                    NodeFilter.Add(" Or ");
                    bool Flag = false;
                    for (int i = 0; i < _FilterValue.Count; i++)
                    {
                        if ((ArrayList)_FilterValue[i] == NodeFilter)
                        {
                            Flag = true;
                            break;
                        }
                    }
                    if (Flag == false)
                    {
                        _FilterValue.Add(NodeFilter);
                    }
                    if (_BindingSource != null)
                    {
                        _BindingSource.Filter = StringFilter();
                    }
                    else
                    {
                        _DataView.RowFilter = StringFilter();
                    }
                }
                foreach (DataGridViewColumn DgvCol in this.Columns)
                {
                    DgvCol.ToolTipText = ToolTipColumn();
                }
            }
            catch
            {
                _FilterValue.Clear();
                if (_BindingSource != null)
                {
                    _BindingSource.Filter = StringFilter();
                }
                else
                {
                    _DataView.RowFilter = StringFilter();
                }
                _DropDownFilter.Close();
                foreach (DataGridViewColumn DgvCol in this.Columns)
                {
                    DgvCol.ToolTipText = String.Empty;
                }
            }            
        }
        /// <summary>
        ///Delete filter
        /// </summary>
        void DeleteFilter_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _FilterValue.Count; i++)
            {
                if (((ArrayList)_FilterValue[i])[0].Equals(this.Columns[_Index].DataPropertyName))
                {
                    _FilterValue.RemoveAt(i);                    
                }
            }
            if (_BindingSource != null)
            {
                _BindingSource.Filter = StringFilter();
            }
            else
            {
                _DataView.RowFilter = StringFilter();
            }
            _DropDownFilter.Close();
            foreach (DataGridViewColumn DgvCol in this.Columns)
            {
                DgvCol.ToolTipText = ToolTipColumn();
            }
        }
        /// <summary>
        ///Clear filter
        /// </summary>
        void ClearFilter_Click(object sender, EventArgs e)
        {
            _FilterValue.Clear();
            if (_BindingSource != null)
            {
                _BindingSource.Filter = StringFilter();
            }
            else
            {
                _DataView.RowFilter = StringFilter();
            }
            _DropDownFilter.Close();
            foreach (DataGridViewColumn DgvCol in this.Columns)
            {
                DgvCol.ToolTipText = String.Empty;
            }
        }              
        /// <summary>
        /// Lấy điều kiện lọc
        /// </summary>
        private string StringFilter()
        {
            string RowFilter = "1=1";
            for (int k = 0; k < _FilterValue.Count; k++)
            {               
                if (((ArrayList)_FilterValue[k])[3] != null && !((ArrayList)_FilterValue[k])[3].ToString().Trim().Equals(String.Empty))
                {
                    Type DataType = (Type)((ArrayList)_FilterValue[k])[1];
                    switch (((ArrayList)_FilterValue[k])[2].ToString().ToUpper())
                    {
                        case "=":                       
                        case "<>":
                            if (k < _FilterValue.Count - 1)
                            {
                                if (DataType == typeof(int) || DataType == typeof(float) || DataType == typeof(double) || DataType == typeof(bool))
                                {
                                    RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[3].ToString();
                                }
                                else
                                {
                                    if (DataType == typeof(string) || DataType == typeof(DateTime))
                                    {
                                        RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                    }
                                }
                            }
                            else
                            {
                                if (DataType == typeof(int) || DataType == typeof(float) || DataType == typeof(double) || DataType == typeof(bool))
                                {
                                    RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper()  + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[3].ToString();
                                }
                                else
                                {
                                    if (DataType == typeof(string) || DataType == typeof(DateTime))
                                    {
                                        RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                    }
                                }
                            }
                            break;
                        case ">":
                        case "<":
                        case ">=":
                        case "<=":
                            if (k < _FilterValue.Count - 1)
                            {
                                if (DataType == typeof(int) || DataType == typeof(float) || DataType == typeof(double))
                                {
                                    RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[3].ToString();
                                }
                                else
                                {
                                    if (DataType == typeof(string) || DataType == typeof(DateTime))
                                    {
                                        RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                    }
                                }
                            }
                            else
                            {
                                if (DataType == typeof(int) || DataType == typeof(float) || DataType == typeof(double) )
                                {
                                    RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[3].ToString();
                                }
                                else
                                {
                                    if (DataType == typeof(string) || DataType == typeof(DateTime))
                                    {
                                        RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                    }
                                }
                            }
                            break;
                        case "LIKE":
                            if (DataType == typeof(string))
                            {
                                if (k < _FilterValue.Count - 1)
                                {
                                    RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '%" + ((ArrayList)_FilterValue[k])[3].ToString() + "%'";
                                }
                                else
                                {
                                    RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '%" + ((ArrayList)_FilterValue[k])[3].ToString() + "%'";
                                }
                            }
                            break;
                        case "%LIKE":
                            if (DataType == typeof(string))
                            {
                                if (k < _FilterValue.Count - 1)
                                {
                                    RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " LIKE '%" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                }
                                else
                                {
                                    RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " LIKE '%" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                }
                            }
                            break;
                        case "LIKE%":
                            if (DataType == typeof(string))
                            {
                                if (k < _FilterValue.Count - 1)
                                {
                                    RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " LIKE '" + ((ArrayList)_FilterValue[k])[3].ToString() + "%'";
                                }
                                else
                                {
                                    RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " LIKE '" + ((ArrayList)_FilterValue[k])[3].ToString() + "%'";
                                }
                            }
                            break;
                    }
                }
                else
                {
                    switch (((ArrayList)_FilterValue[k])[2].ToString().ToUpper())
                    {
                        case "=":
                            if (k < _FilterValue.Count - 1)
                            {
                                RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " IS NULL ";
                            }
                            else
                            {
                                RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " IS NULL ";
                            }
                            break;
                        case "<>":
                            if (k < _FilterValue.Count - 1)
                            {
                                RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " IS NOT NULL ";
                            }
                            else
                            {
                                RowFilter = RowFilter + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " IS NOT NULL ";
                            }
                            break;
                    }
                }                
            }
            return RowFilter;
        }
        /// <summary>
        /// ToolTipColumn
        /// </summary>
        private string ToolTipColumn ()
        {
            string ToolTipString = String.Empty;
            bool Flag = false;
            for (int k = 0; k < _FilterValue.Count; k++)
            {
                if (((ArrayList)_FilterValue[k])[3] != null && !((ArrayList)_FilterValue[k])[3].ToString().Trim().Equals(String.Empty))
                {
                    Type DataType = (Type)((ArrayList)_FilterValue[k])[1];
                    switch (((ArrayList)_FilterValue[k])[2].ToString().ToUpper())
                    {
                        case "=":
                        case "<>":                                            
                            if (Flag)
                            {
                                if (DataType == typeof(int) || DataType == typeof(float) || DataType == typeof(double) || DataType == typeof(bool))
                                {
                                    ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[3].ToString();
                                }
                                else
                                {
                                    if (DataType == typeof(string) || DataType == typeof(DateTime))
                                    {
                                        ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                    }
                                }
                            }
                            else
                            {
                                if (DataType == typeof(int) || DataType == typeof(float) || DataType == typeof(double) || DataType == typeof(bool))
                                {
                                    ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[3].ToString();
                                }
                                else
                                {
                                    if (DataType == typeof(string) || DataType == typeof(DateTime))
                                    {
                                        ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                    }
                                }
                            }
                            break;
                        case ">":
                        case "<":
                        case ">=":
                        case "<=":
                            if (Flag)
                            {
                                if (DataType == typeof(int) || DataType == typeof(float) || DataType == typeof(double) )
                                {
                                    ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[3].ToString();
                                }
                                else
                                {
                                    if (DataType == typeof(string) || DataType == typeof(DateTime))
                                    {
                                        ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                    }
                                }
                            }
                            else
                            {
                                if (DataType == typeof(int) || DataType == typeof(float) || DataType == typeof(double) )
                                {
                                    ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[3].ToString();
                                }
                                else
                                {
                                    if (DataType == typeof(string) || DataType == typeof(DateTime))
                                    {
                                        ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                    }
                                }
                            }
                            break;
                        case "LIKE":
                            if (DataType == typeof(string))
                            {
                                if (Flag)
                                {
                                    ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                }
                                else
                                {
                                    ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " " + ((ArrayList)_FilterValue[k])[2].ToString().ToUpper() + " '" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                }
                            }
                            break;
                        case "%LIKE":
                            if (DataType == typeof(string))
                            {
                                if (Flag)
                                {
                                    ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " LIKE '%" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                }
                                else
                                {
                                    ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " LIKE '%" + ((ArrayList)_FilterValue[k])[3].ToString() + "'";
                                }
                            }
                            break;
                        case "LIKE%":
                            if (DataType == typeof(string))
                            {
                                if (Flag)
                                {
                                    ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " LIKE '" + ((ArrayList)_FilterValue[k])[3].ToString() + "%'";
                                }
                                else
                                {
                                    ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " LIKE '" + ((ArrayList)_FilterValue[k])[3].ToString() + "%'";
                                }
                            }
                            break;
                    }
                }
                else
                {
                    switch (((ArrayList)_FilterValue[k])[2].ToString().ToUpper())
                    {
                        case "=":
                            if (Flag)
                            {
                                ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " IS NULL";
                            }
                            else
                            {
                                ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " IS NULL ";
                            }
                            break;
                        case "<>":
                            if (Flag)
                            {
                                ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[4].ToString().ToUpper() + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " IS NOT NULL";
                            }
                            else
                            {
                                ToolTipString = ToolTipString + ((ArrayList)_FilterValue[k])[0].ToString().ToUpper() + " IS NOT NULL ";
                            }
                            break;
                    }
                }
                Flag = true;
            }                                                                                         
            return ToolTipString;
        }
        /// <summary>
        /// CellPainting
        /// </summary>
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);

            if (e.RowIndex == -1 && e.ColumnIndex == -1 && _FilterValue.Count > 0)
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
                e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.Background);
                Rectangle r = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                e.Graphics.DrawImage(Vietsoft.Properties.Resources.Filter1, (e.CellBounds.Width - Vietsoft.Properties.Resources.Filter1.Width) / 2, (e.CellBounds.Height - Vietsoft.Properties.Resources.Filter1.Height) / 2, Vietsoft.Properties.Resources.Filter1.Width, Vietsoft.Properties.Resources.Filter1.Height);
                e.Graphics.DrawRectangle(Pens.Transparent, r);
                e.Handled = true;
            }
        }
    }
}
