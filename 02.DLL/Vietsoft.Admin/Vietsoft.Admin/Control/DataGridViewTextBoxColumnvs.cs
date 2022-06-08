using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vietsoft.Admin
{
    public partial class DataGridViewTextBoxColumnvs : DataGridViewColumn
    {
        public DataGridViewTextBoxColumnvs()
            : base(new DataGridviewTextEditorCell())
        {
        }
        /// <summary>
        /// Cho phép nhập số âm 
        /// </summary>
        public int TypeValue
        {
            get
            {
                return ((DataGridviewTextEditorCell)CellTemplate).TypeValue;
            }
            set
            {
                ((DataGridviewTextEditorCell)CellTemplate).TypeValue = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        DataGridviewTextEditorCell cell = rows.SharedRow(i).Cells[base.Index] as DataGridviewTextEditorCell;
                        if (cell != null)
                        {
                            cell.TypeValue = value;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Định dạng số
        /// </summary>
        public string FormatValue
        {
            get
            {
                return ((DataGridviewTextEditorCell)CellTemplate).FormatValue;
            }
            set
            {
                ((DataGridviewTextEditorCell)CellTemplate).FormatValue = value;
                this.DefaultCellStyle.Format = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        DataGridviewTextEditorCell cell = rows.SharedRow(i).Cells[base.Index] as DataGridviewTextEditorCell;
                        if (cell != null)
                        {
                            cell.FormatValue = value;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Mặt lạ nhập liệu 
        /// </summary>
        public string InputMask
        {
            get
            {
                return ((DataGridviewTextEditorCell)CellTemplate).InputMask;
            }
            set
            {
                ((DataGridviewTextEditorCell)CellTemplate).InputMask = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        DataGridviewTextEditorCell cell = rows.SharedRow(i).Cells[base.Index] as DataGridviewTextEditorCell;
                        if (cell != null)
                        {
                            cell.InputMask = value;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Chiều dài dữ liệu
        /// </summary>
        public int Length
        {
            get
            {
                return ((DataGridviewTextEditorCell)CellTemplate).Length;
            }
            set
            {
                ((DataGridviewTextEditorCell)CellTemplate).Length = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        DataGridviewTextEditorCell cell = rows.SharedRow(i).Cells[base.Index] as DataGridviewTextEditorCell;
                        if (cell != null)
                        {
                            cell.Length = value;
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
                    !value.GetType().IsAssignableFrom(typeof(DataGridviewTextEditorCell)))
                {
                    throw new InvalidCastException("Value Type");
                }
                base.CellTemplate = value;
            }
        }
        /// <summary>
        /// Clone
        /// </summary>
        public override object Clone()
        {
            DataGridViewTextBoxColumnvs col = (DataGridViewTextBoxColumnvs)base.Clone();
            col.TypeValue = TypeValue;
            col.FormatValue = FormatValue;
            col.InputMask = InputMask;
            col.CellTemplate = (DataGridviewTextEditorCell)this.CellTemplate.Clone();
            return col;
        }
    }
    /// <summary>
    /// DataGridviewTextEditorCell
    /// </summary>
    public class DataGridviewTextEditorCell : DataGridViewTextBoxCell
    {
        public DataGridviewTextEditorCell()
            : base()
        {
        }
        /// <summary>
        /// Khai báo thành phần dùng chung
        /// </summary>
        private int _intTypevalue = 6;
        private string _strMask = String.Empty;
        private int _Length = 32700;
        private string _strFormatvalue = string.Empty;
        /// <summary>
        /// 0 - Là số nguyên dương
        /// 1 - Là số nguyên cho phép số âm
        /// 2 - Là số thực dương 
        /// 3 - Là số thực cho phép số âm
        /// 4 - Là datetime không lấy mặc định ngày hiện tại
        /// 5 - Là datetime lấy mặc định ngày hiện tại
        /// </summary>
        public int TypeValue
        {
            get
            {
                return _intTypevalue;
            }
            set
            {
                if (value >= 0 && value <= 6)
                {
                    _intTypevalue = value;
                }
                else
                {
                    _intTypevalue = 0;
                }
            }
        }
        /// <summary>
        /// Định dạng dữ liệu
        /// </summary>
        public string FormatValue
        {
            get
            {
                return _strFormatvalue;
            }
            set
            {
                _strFormatvalue = value;
            }
        }
        /// <summary>
        /// Mặt lạ nhập liệu
        /// </summary>
        public string InputMask
        {
            get
            {
                return _strMask;
            }
            set
            {
                _strMask = value;
            }
        }
        /// <summary>
        /// Chiều dài tối đa dữ liệu
        /// </summary>
        public int Length
        {
            get
            {
                return _Length;
            }
            set
            {
                _Length = value;
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
            DataGridviewTextEditorEditingControl ctl =
                DataGridView.EditingControl as DataGridviewTextEditorEditingControl;
            if (ctl != null)
            {
                ctl.TypeValue = _intTypevalue;
                ctl.FormatValue = _strFormatvalue;
                ctl.Mask = _strMask;
                ctl.Length = _Length;
                switch (TypeValue)
                {
                    case 0:
                    case 1:
                        try
                        {
                            ctl.Text = int.Parse(this.Value.ToString()).ToString(FormatValue);
                        }
                        catch
                        {
                            ctl.Text = string.Empty;
                        }
                        break;
                    case 2:
                    case 3:
                        try
                        {
                            ctl.Text = double.Parse(this.Value.ToString()).ToString(FormatValue);
                        }
                        catch
                        {
                            ctl.Text = string.Empty;
                        }
                        break;
                    case 4:
                        try
                        {
                            ctl.Text = DateTime.ParseExact(this.Value.ToString(), FormatValue, System.Globalization.CultureInfo.CurrentCulture).ToString();
                        }
                        catch
                        {
                            ctl.Text = string.Empty;
                        }
                        break;
                    case 5:
                        try
                        {
                            ctl.Text = DateTime.ParseExact(this.Value.ToString(), FormatValue, System.Globalization.CultureInfo.CurrentCulture).ToString();
                        }
                        catch
                        {
                            ctl.Text = DateTime.Now.ToString(FormatValue);
                        }
                        break;
                    case 6:
                        try
                        {
                            ctl.Text = this.Value.ToString();
                        }
                        catch
                        {
                            ctl.Text = String.Empty;
                        }
                        break;
                }
                ctl.SelectAll();
            }
        }
        /// <summary>
        /// EditType
        /// </summary>
        public override Type EditType
        {
            get
            {
                return typeof(DataGridviewTextEditorEditingControl);
            }
        }
        /// <summary>
        /// ValueType
        /// </summary>
        public override Type ValueType
        {
            get
            {
                switch (TypeValue)
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
                    default:
                        return typeof(object);
                }
            }
        }           

        /// <summary>
        /// DefaultNewRowValue
        /// </summary>
        public override object DefaultNewRowValue
        {
            get
            {
                if (_intTypevalue == 5)
                {
                    return DateTime.Now.ToString(_strFormatvalue);
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public override object Clone()
        {
            DataGridviewTextEditorCell cell = base.Clone() as DataGridviewTextEditorCell;
            cell.TypeValue = this.TypeValue;
            cell.FormatValue = this.FormatValue;
            cell.InputMask = this.InputMask;
            cell.Length = this.Length;
            return cell;
        }
    }
    /// <summary>
    /// DataGridviewTextEditorEditingControl
    /// </summary>
    class DataGridviewTextEditorEditingControl : TextBoxColumnvs, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool bolTextChanged = false;
        int rowIndex;
        /// <summary>
        /// Hàm khởi tạo giá trị mặc định
        /// </summary>
        public DataGridviewTextEditorEditingControl()
        {
            this.TypeValue = 6;
            this.FormatValue = string.Empty;
            this.Mask = string.Empty;
            this.Length = 32700;
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
                    switch (this.TypeValue)
                    {
                        case 0:
                        case 1:
                            return int.Parse(double.Parse(this.Text).ToString()).ToString();
                        case 2:
                        case 3:
                            return double.Parse(this.Text).ToString();
                        case 4:
                        case 5:
                            return DateTime.ParseExact(this.Text, this.FormatValue, System.Globalization.CultureInfo.CurrentCulture).ToString();
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
            this.EditingControlDataGridView.NotifyCurrentCellDirty(false);
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
            this.TypeValue = ((DataGridviewTextEditorCell)dataGridView.CurrentCell).TypeValue;
            this.Mask = ((DataGridviewTextEditorCell)dataGridView.CurrentCell).InputMask;
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
                return rowIndex;
            }
            set
            {
                rowIndex = value;
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
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }
        /// <summary>
        /// EditingControlValueChanged
        /// </summary>
        public bool EditingControlValueChanged
        {
            get
            {
                return bolTextChanged;
            }
            set
            {
                bolTextChanged = value;
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
        /// <summary>
        /// OnTextChanged
        /// </summary>
        protected override void OnTextChanged(EventArgs e)
        {
            bolTextChanged = true;
            base.OnTextChanged(e);
        }
    }
}

