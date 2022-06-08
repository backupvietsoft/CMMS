using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
namespace WareHouse
{
    public class MaskedTextBoxControlLinksoft : MaskedTextBox, IDataGridViewEditingControl
    {
        protected int rowIndex;
        protected DataGridView dataGridView;
        protected bool valueChanged = false;
        public MaskedTextBoxControlLinksoft()
        {
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            NotifyDataGridViewOfValueChange();
        }
        protected virtual void NotifyDataGridViewOfValueChange()
        {
            this.valueChanged = true;
            if (this.dataGridView != null)
            {
                this.dataGridView.NotifyCurrentCellDirty(true);
            }
        }
        public Cursor EditingPanelCursor
        {
            get
            {
                return Cursors.IBeam;
            }
        }
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return this.dataGridView;
            }

            set
            {
                this.dataGridView = value;
            }
        }
        public object EditingControlFormattedValue
        {
            set
            {
                this.Text = value.ToString();
                NotifyDataGridViewOfValueChange();
            }
            get
            {
                return this.Text;
            }

        }
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Text;
        }
        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Right:
                    if (!(this.SelectionLength == 0
                          && this.SelectionStart == this.ToString().Length))
                    {
                        return true;
                    }
                    break;

                case Keys.Left:
                    if (!(this.SelectionLength == 0
                          && this.SelectionStart == 0))
                    {
                        return true;
                    }
                    break;

                case Keys.Home:
                case Keys.End:
                    if (this.SelectionLength != this.ToString().Length)
                    {
                        return true;
                    }
                    break;

                case Keys.Prior:
                case Keys.Next:
                    if (this.valueChanged)
                    {
                        return true;
                    }
                    break;

                case Keys.Delete:
                    if (this.SelectionLength > 0 || this.SelectionStart < this.ToString().Length)
                    {
                        return true;
                    }
                    break;
            }
            return !dataGridViewWantsInputKey;
        }
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            if (selectAll)
            {
                SelectAll();
            }
            else
            {
                this.SelectionStart = this.ToString().Length;
            }
        }
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }
        public int EditingControlRowIndex
        {
            get
            {
                return this.rowIndex;
            }

            set
            {
                this.rowIndex = value;
            }
        }
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
            this.TextAlign = translateAlignment(dataGridViewCellStyle.Alignment);
        }
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }

            set
            {
                this.valueChanged = value;
            }
        }
        private static HorizontalAlignment translateAlignment(DataGridViewContentAlignment align)
        {
            switch (align)
            {
                case DataGridViewContentAlignment.TopLeft:
                case DataGridViewContentAlignment.MiddleLeft:
                case DataGridViewContentAlignment.BottomLeft:
                    return HorizontalAlignment.Left;

                case DataGridViewContentAlignment.TopCenter:
                case DataGridViewContentAlignment.MiddleCenter:
                case DataGridViewContentAlignment.BottomCenter:
                    return HorizontalAlignment.Center;

                case DataGridViewContentAlignment.TopRight:
                case DataGridViewContentAlignment.MiddleRight:
                case DataGridViewContentAlignment.BottomRight:
                    return HorizontalAlignment.Right;
            }
            throw new ArgumentException("Error: Invalid Content Alignment!");
        }
    }


    public class ColumnMaskedTextBoxLinksoft : DataGridViewColumn
    {
        private string mask;
        private char promptChar;
        private bool includePrompt;
        private bool includeLiterals;
        private Type validatingType;
        public ColumnMaskedTextBoxLinksoft()
            : base(new MaskedTextBoxCellLinksoft())
        {
        }
        private static DataGridViewTriState TriBool(bool value)
        {
            return value ? DataGridViewTriState.True
                         : DataGridViewTriState.False;
        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }

            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(MaskedTextBoxCellLinksoft)))
                {
                    string s = "Cell type is not based upon the MaskedTextBoxCellLinksoft.";//CustomColumnMain.GetResourceManager().GetString("excNotMaskedTextBox");
                    throw new InvalidCastException(s);
                }

                base.CellTemplate = value;
            }
        }
        public virtual string Mask
        {
            get
            {
                return this.mask;
            }
            set
            {
                MaskedTextBoxCellLinksoft mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.mask != value)
                {
                    this.mask = value;
                    mtbc = (MaskedTextBoxCellLinksoft)this.CellTemplate;
                    mtbc.Mask = value;
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is MaskedTextBoxCellLinksoft)
                            {
                                mtbc = (MaskedTextBoxCellLinksoft)dgvc;
                                mtbc.Mask = value;
                            }
                        }
                    }
                }
            }
        }
        public virtual char PromptChar
        {
            get
            {
                return this.promptChar;
            }
            set
            {
                MaskedTextBoxCellLinksoft mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.promptChar != value)
                {
                    this.promptChar = value;
                    mtbc = (MaskedTextBoxCellLinksoft)this.CellTemplate;
                    mtbc.PromptChar = value;
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is MaskedTextBoxCellLinksoft)
                            {
                                mtbc = (MaskedTextBoxCellLinksoft)dgvc;
                                mtbc.PromptChar = value;
                            }
                        }
                    }
                }
            }
        }
        public virtual bool IncludePrompt
        {
            get
            {
                return this.includePrompt;
            }
            set
            {
                MaskedTextBoxCellLinksoft mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.includePrompt != value)
                {
                    this.includePrompt = value;
                    mtbc = (MaskedTextBoxCellLinksoft)this.CellTemplate;
                    mtbc.IncludePrompt = TriBool(value);
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is MaskedTextBoxCellLinksoft)
                            {
                                mtbc = (MaskedTextBoxCellLinksoft)dgvc;
                                mtbc.IncludePrompt = TriBool(value);
                            }
                        }
                    }
                }
            }
        }
        public virtual bool IncludeLiterals
        {
            get
            {
                return this.includeLiterals;
            }
            set
            {
                MaskedTextBoxCellLinksoft mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.includeLiterals != value)
                {
                    this.includeLiterals = value;
                    mtbc = (MaskedTextBoxCellLinksoft)this.CellTemplate;
                    mtbc.IncludeLiterals = TriBool(value);
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {

                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is MaskedTextBoxCellLinksoft)
                            {
                                mtbc = (MaskedTextBoxCellLinksoft)dgvc;
                                mtbc.IncludeLiterals = TriBool(value);
                            }
                        }
                    }
                }
            }
        }
        public virtual Type ValidatingType
        {
            get
            {
                return this.validatingType;
            }
            set
            {
                MaskedTextBoxCellLinksoft mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.validatingType != value)
                {
                    this.validatingType = value;
                    mtbc = (MaskedTextBoxCellLinksoft)this.CellTemplate;
                    mtbc.ValidatingType = value;
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is MaskedTextBoxCellLinksoft)
                            {
                                mtbc = (MaskedTextBoxCellLinksoft)dgvc;
                                mtbc.ValidatingType = value;
                            }
                        }
                    }
                }
            }
        }

    }
    class MaskedTextBoxCellLinksoft : DataGridViewTextBoxCell
    {
        private string mask;
        private char promptChar;
        private DataGridViewTriState includePrompt;
        private DataGridViewTriState includeLiterals;
        private Type validatingType;
        public MaskedTextBoxCellLinksoft()
            : base()
        {
            this.mask = string.Empty;
            this.promptChar = '_';
            this.includePrompt = DataGridViewTriState.NotSet;
            this.includeLiterals = DataGridViewTriState.NotSet;
            this.validatingType = typeof(string);
        }
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            MaskedTextBoxControlLinksoft mtbec;
            ColumnMaskedTextBoxLinksoft mtbcol;
            DataGridViewColumn dgvc;

            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                                          dataGridViewCellStyle);
            mtbec = DataGridView.EditingControl as MaskedTextBoxControlLinksoft;
            dgvc = this.OwningColumn;
            if (dgvc is ColumnMaskedTextBoxLinksoft)
            {
                mtbcol = dgvc as ColumnMaskedTextBoxLinksoft;
                if (string.IsNullOrEmpty(this.mask))
                {
                    mtbec.Mask = mtbcol.Mask;
                }
                else
                {
                    mtbec.Mask = this.mask;
                   
                }
                mtbec.PromptChar = this.PromptChar;
                if (this.includePrompt == DataGridViewTriState.NotSet)
                {
                }
                else
                {
                }
                if (this.includeLiterals == DataGridViewTriState.NotSet)
                {
                }
                else
                {
                }
                if (this.ValidatingType == null)
                {
                    mtbec.ValidatingType = mtbcol.ValidatingType;
                }
                else
                {
                    mtbec.ValidatingType = this.ValidatingType;
                }
                if (this.Value is DateTime)
                    mtbec.Text = ((DateTime)this.Value).ToString(mtbcol.DefaultCellStyle.Format);
                else
                    mtbec.Text = this.Value.ToString();
            }
        }
        public override Type EditType
        {
            get
            {
                return typeof(MaskedTextBoxControlLinksoft);
            }
        }
        public virtual string Mask
        {
            get
            {
                return this.mask;
            }
            set
            {
                this.mask = value;
            }
        }
        public virtual char PromptChar
        {
            get
            {
                return this.promptChar;
            }
            set
            {
                this.promptChar = value;
            }
        }
        public virtual DataGridViewTriState IncludePrompt
        {
            get
            {
                return this.includePrompt;
            }
            set
            {
                this.includePrompt = value;
            }
        }
        public virtual DataGridViewTriState IncludeLiterals
        {
            get
            {
                return this.includeLiterals;
            }
            set
            {
                this.includeLiterals = value;
            }
        }
        public virtual Type ValidatingType
        {
            get
            {
                return this.validatingType;
            }
            set
            {
                this.validatingType = value;
            }
        }
        protected static bool BoolFromTri(DataGridViewTriState tri)
        {
            return (tri == DataGridViewTriState.True) ? true : false;
        }
    }
}
