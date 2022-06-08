using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Vietsoft
{
    public partial class DataGridViewFilter : UserControl
    {
        public DataGridViewFilter()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get
            {
                return BtnTitle.Text;
            }
            set
            {
                BtnTitle.Text = value;
            }
        }
        /// <summary>
        /// Type filter
        /// </summary>
        public MaskedEditor TypeFilter
        {
            get
            {
                return TxtTFilter;
            }            
        }
        /// <summary>
        /// Type filter
        /// </summary>
        public MaskedEditor ValueFilter
        {
            get
            {
                return TxtVFilter;
            }
        }
        /// <summary>
        /// Clear filter
        /// </summary>
        public Button ClearFilter
        {
            get
            {
                return BtnClear;
            }
        }
        /// <summary>
        /// Delete filter
        /// </summary>
        public Button DeleteFilter
        {
            get
            {
                return BtnDelete;
            }
        }
        /// <summary>
        /// And Filter
        /// </summary>
        public Button AndFilter
        {
            get
            {
                return BtnAnd;
            }
        }
        /// <summary>
        /// Or Filter
        /// </summary>
        public Button OrFilter
        {
            get
            {
                return BtnOr;
            }
        }
        /// <summary>
        /// Exit
        /// </summary>
        public Button ExitFilter
        {
            get
            {
                return BtnExit;
            }
        }
        /// <summary>
        /// Source type
        /// </summary>
        public object SourceTypeFilter
        {
            get
            {                
                return DgvTFilter.DataSource;
            }
            set
            {
                DgvTFilter.DataSource = value;
            }
        }
        /// <summary>
        /// Source value
        /// </summary>
        public object SourceValueFilter
        {
            get
            {
                return DgvVFilter.DataSource;
            }
            set
            {
                DgvVFilter.DataSource = value;
                TxtVFilter.StringFormat = DgvVFilter.Columns[0].DefaultCellStyle.Format;
            }
        }
        /// <summary>
        /// Add column
        /// </summary>
        private void DgvTFilter_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        /// <summary>
        /// Add column
        /// </summary>
        private void DgvVFilter_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        /// <summary>
        /// Select value
        /// </summary>
        private void DgvTFilter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TxtTFilter.Text = DgvTFilter.CurrentCell.Value.ToString();
            }
            catch { }            
        }
        private void DgvTFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    TxtTFilter.Text = DgvTFilter.CurrentCell.Value.ToString();
                }
                catch { } 
            }
        }
        private void DgvVFilter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TxtVFilter.Text = DgvVFilter.CurrentCell.Value.ToString();
            }
            catch { }   
        }
        private void DgvVFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    TxtVFilter.Text = DgvVFilter.CurrentCell.Value.ToString();
                }
                catch { }  
            }
        }
    }
}
