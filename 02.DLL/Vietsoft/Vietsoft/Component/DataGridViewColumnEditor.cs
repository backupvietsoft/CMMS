using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vietsoft
{    
    public partial class DataGridViewColumnEditor : DataGridViewColumn
    {
        public DataGridViewColumnEditor()
            : base(new GridViewEditorCellSoft())
        {           
        }
        /// <summary>
        /// Data type
        /// </summary>
        public int DataType
        {
            get
            {
                return ((GridViewEditorCellSoft)CellTemplate).DataType;
            }
            set
            {
                ((GridViewEditorCellSoft)CellTemplate).DataType = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        GridViewEditorCellSoft GridViewCellSoft = rows.SharedRow(i).Cells[base.Index] as GridViewEditorCellSoft;
                        if (GridViewCellSoft != null)
                        {
                            GridViewCellSoft.DataType = value;
                            if (value == 5)
                            {
                                rows[i].Cells[base.Index].Value = DateTime.Now.ToString(GridViewCellSoft.StringFormat);
                            }
                        }
                    }                   
                }               
            }
        }
        /// <summary>
        /// StringFormat
        /// </summary>
        public string StringFormat
        {
            get
            {
                return ((GridViewEditorCellSoft)CellTemplate).StringFormat;
            }
            set
            {
                ((GridViewEditorCellSoft)CellTemplate).StringFormat = value;
                this.DefaultCellStyle.Format = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        GridViewEditorCellSoft GridViewCellSoft = rows.SharedRow(i).Cells[base.Index] as GridViewEditorCellSoft;
                        if (GridViewCellSoft != null)
                        {
                            GridViewCellSoft.StringFormat = value;
                            if (GridViewCellSoft.DataType == 5)
                            {
                                rows[i].Cells[base.Index].Value = DateTime.Now.ToString(value);
                            }
                        }
                    }
                }               
            }
        }
        /// <summary>
        /// InPutMask
        /// </summary>
        public string InPutMask
        {
            get
            {
                return ((GridViewEditorCellSoft)CellTemplate).InPutMask;
            }
            set
            {
                ((GridViewEditorCellSoft)CellTemplate).InPutMask = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        GridViewEditorCellSoft GridViewCellSoft = rows.SharedRow(i).Cells[base.Index] as GridViewEditorCellSoft;
                        if (GridViewCellSoft != null)
                        {
                            GridViewCellSoft.InPutMask = value;
                        }
                    }
                }
            }
        }       
        /// <summary>
        /// MaxLength
        /// </summary>
        public int MaxLength
        {
            get
            {
                return ((GridViewEditorCellSoft)CellTemplate).MaxLength;
            }
            set
            {
                ((GridViewEditorCellSoft)CellTemplate).MaxLength = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        GridViewEditorCellSoft GridViewCellSoft = rows.SharedRow(i).Cells[base.Index] as GridViewEditorCellSoft;
                        if (GridViewCellSoft != null)
                        {
                            GridViewCellSoft.MaxLength = value;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// CellTemplate
        /// </summary>
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(GridViewEditorCellSoft)))
                {
                    throw new InvalidCastException("DataType");
                }
                base.CellTemplate = value;
            }
        }
        /// <summary>
        /// Clone
        /// </summary>
        public override object Clone()
        {
            DataGridViewColumnEditor GridViewColumn = (DataGridViewColumnEditor)base.Clone();
            GridViewColumn.DataType = this.DataType;
            GridViewColumn.StringFormat = this.StringFormat;
            GridViewColumn.InPutMask = this.InPutMask;
            GridViewColumn.CellTemplate = (GridViewEditorCellSoft)this.CellTemplate.Clone();
            return GridViewColumn;
        }       
    }
    /// <summary>
    /// DataGridviewTextEditorCell
    /// </summary>
    public class GridViewEditorCellSoft : DataGridViewTextBoxCell
    {       
        /// <summary>
        /// Declare public
        /// </summary>
        private int _DataType = 6;
        private string _InPutMask = String.Empty;
        private string _StringFormat = string.Empty;                
        private int _MaxLength = 32700;        
        public GridViewEditorCellSoft()
            : base()
        {           
        }
        /// <summary>
        /// DataType
        /// </summary>
        public int DataType
        {
            get
            {
                return _DataType;
            }
            set
            {
                if (value >= 0 && value <= 6)
                {
                    _DataType = value;
                }
                else
                {
                    _DataType = 6;
                }               
            }
        }
        /// <summary>
        /// StringFormat
        /// </summary>
        public string StringFormat
        {
            get
            {
                return _StringFormat;
            }
            set
            {
                _StringFormat = value;               
            }
        }
        /// <summary>
        /// InPutMask
        /// </summary>
        public string InPutMask
        {
            get
            {
                return _InPutMask;
            }
            set
            {
                _InPutMask = value;
            }
        }
        /// <summary>
        /// MaxLength
        /// </summary>
        public int MaxLength
        {
            get
            {
                return _MaxLength;
            }
            set
            {
                _MaxLength = value;
            }
        }
        /// <summary>
        /// InitializeEditingControl
        /// </summary>
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            GridViewEditorSoft Ctrl =
                DataGridView.EditingControl as GridViewEditorSoft;
            if (Ctrl != null)
            {
                Ctrl.DataType = _DataType;
                Ctrl.StringFormat = _StringFormat;
                Ctrl.Mask = _InPutMask;
                Ctrl.CharLength = _MaxLength;                
                switch (_DataType)
                {
                    case 0:
                    case 1:
                        try
                        {
                            Ctrl.Text = int.Parse(this.Value.ToString()).ToString(_StringFormat);
                        }
                        catch
                        {
                            Ctrl.Text = string.Empty;
                        }
                        break;
                    case 2:
                    case 3:
                        try
                        {
                            Ctrl.Text = double.Parse(this.Value.ToString()).ToString(_StringFormat);
                        }
                        catch
                        {
                            Ctrl.Text = string.Empty;
                        }
                        break;
                    case 4:
                        try
                        {
                            Ctrl.Text = DateTime.ParseExact(this.Value.ToString(), _StringFormat, System.Globalization.CultureInfo.CurrentCulture).ToString();
                        }
                        catch
                        {
                            Ctrl.Text = string.Empty;
                        }
                        break;
                    case 5:
                        try
                        {
                            Ctrl.Text = DateTime.ParseExact(this.Value.ToString(), _StringFormat, System.Globalization.CultureInfo.CurrentCulture).ToString();
                        }
                        catch
                        {
                            Ctrl.Text = string.Empty;
                        }
                        break;
                    case 6:
                        try
                        {
                            Ctrl.Text = this.Value.ToString();
                        }
                        catch
                        {
                            Ctrl.Text = String.Empty;
                        }
                        break;
                }
                Ctrl.SelectAll();
            }
        }
        /// <summary>
        /// ValueType
        /// </summary>
        public override Type ValueType
        {
            get
            {
                switch (_DataType)
                {
                    case 0:
                    case 1:                        
                        return typeof(int);
                    case 2:
                    case 3:
                        return typeof(double);
                    case 4:
                    case 5:
                        return typeof(DateTime);
                    case 6:
                        return typeof(string);                        
                    default:
                        return typeof(object);
                }
            }
        }
        /// <summary>
        /// EditType
        /// </summary>
        public override Type EditType
        {
            get
            {
                return typeof(GridViewEditorSoft);
            }
        }        
        /// <summary>
        /// DefaultNewRowValue
        /// </summary>
        public override object DefaultNewRowValue
        {
            get
            {
                if (_DataType == 5)
                {
                    return DateTime.Now.ToString(_StringFormat);
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Clone
        /// </summary>
        public override object Clone()
        {
            GridViewEditorCellSoft GridViewCellSoft = base.Clone() as GridViewEditorCellSoft;            
            GridViewCellSoft.DataType = _DataType;
            GridViewCellSoft.StringFormat = _StringFormat;
            GridViewCellSoft.InPutMask = _InPutMask;
            GridViewCellSoft.MaxLength = _MaxLength;
            return GridViewCellSoft;
        }
    }
    /// <summary>
    /// GridViewEditingSoft
    /// </summary>
    class GridViewEditorSoft : MaskedEditor, IDataGridViewEditingControl
    {
        DataGridView GridViewSoft;
        private bool FlagTextChange = false;
        int rIndex;
        /// <summary>
        /// Hàm khởi tạo giá trị mặc định
        /// </summary>
        public GridViewEditorSoft()
        {           
        }
        /// <summary>
        /// EditingControlFormattedValue
        /// </summary>
        public object EditingControlFormattedValue
        {
            get
            {
                try
                {
                    switch (this.DataType)
                    {
                        case 0:
                        case 1:
                            return int.Parse(double.Parse(this.Text).ToString()).ToString();
                        case 2:
                        case 3:
                            return double.Parse(this.Text).ToString();
                        case 4:
                        case 5:
                            return DateTime.ParseExact(this.Text, this.StringFormat, System.Globalization.CultureInfo.CurrentCulture).ToString();
                        case 6:
                            return this.Text;
                        default:
                            return String.Empty;
                    }
                }
                catch
                {
                    return String.Empty;
                }
            }
            set
            {
                if (value is String)
                {
                    this.Text = (String)value;
                }
            }
        }
        /// <summary>
        /// GetEditingControlFormattedValue
        /// </summary>
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {            
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            return EditingControlFormattedValue;
        }
        /// <summary>
        /// ApplyCellStyleToEditingContro
        /// </summary>
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
            this.DataType = ((GridViewEditorCellSoft)GridViewSoft.CurrentCell).DataType;
            this.Mask = ((GridViewEditorCellSoft)GridViewSoft.CurrentCell).InPutMask;
            switch (dataGridViewCellStyle.Alignment.ToString().Trim())
            {
                case "BottomLeft":
                case "MiddleLeft":
                case "TopLeft":
                    this.TextAlign = HorizontalAlignment.Left;
                    break;
                case "MiddleCenter":
                case "BottomCenter":
                case "TopCenter":
                    this.TextAlign = HorizontalAlignment.Center;
                    break;
                case "TopRight":
                case "BottomRight":
                case "MiddleRight":
                    this.TextAlign = HorizontalAlignment.Right;
                    break;
                default:
                    this.TextAlign = HorizontalAlignment.Left;
                    break;
            }
        }
        /// <summary>
        /// EditingControlRowIndex
        /// </summary>
        public int EditingControlRowIndex
        {
            get
            {
                return rIndex;
            }
            set
            {
                rIndex = value;
            }
        }
        /// <summary>
        /// EditingControlWantsInputKey
        /// </summary>
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }
        /// <summary>
        /// PrepareEditingControlForEdit
        /// </summary>
        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }
        /// <summary>
        /// RepositionEditingControlOnValueChange
        /// </summary>
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// EditingControlDataGridView
        /// </summary>
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return GridViewSoft;
            }
            set
            {
                GridViewSoft = value;
            }
        }
        /// <summary>
        /// EditingControlValueChanged
        /// </summary>
        public bool EditingControlValueChanged
        {
            get
            {
                return FlagTextChange;
            }
            set
            {
                FlagTextChange = value;
            }
        }
        /// <summary>
        /// EditingPanelCursor
        /// </summary>
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }       
    }
}

