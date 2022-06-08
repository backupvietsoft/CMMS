using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System.Data;

namespace MVControl
{
    public partial class ucComboboxTreeList : XtraUserControl
    {
        public string KeyFieldName { get; set; }
        public string ParentFieldName { get; set; }
        public object DataSource { get; set; }
        public string ColumnDisplayName { get; set; }
        private object editValue;
        public object EditValue
        {
            get { return editValue; }
            set
            {
                if (EditValue != value)
                {
                    editValue = value;
                    this.Invalidate();
                    if (EditValuedChanged != null)
                        EditValuedChanged(this, null);
                }
            }
        }
        private bool flag = false;

        private int inDex;
        public int SelectedIndex
        {
            get { return inDex; }
            set
            {
                inDex = value;
                if (flag == false)
                {
                    DevExpress.XtraTreeList.Nodes.TreeListNode firstNode = treeList.GetNodeByVisibleIndex(inDex);
                    treeList.SetFocusedNode(firstNode);
                    edit.Refresh();
                    flag = false;
                }
            }

        }

        private string textValue;
        public string TextValue
        {
            get { return textValue; }
            set
            {
                textValue = value;
            }
        }
        
        public string Text
        {
            get { return TextValue; }
            set
            {
                TextValue = value;
            }
        }



        private bool readOnly;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                edit.Properties.ReadOnly = value;
                treeList.Enabled = !value;
            }
        }

        public TreeList treeList;        
        private PopupContainerControl pControl;
        private PopupContainerEdit edit;
        private TextEdit txtSearch;
        public ucComboboxTreeList()
        {
            InitializeComponent();
            edit = new PopupContainerEdit();
            Controls.Add(edit);
            pControl = new PopupContainerControl();
            Controls.Add(pControl);
            pControl.LookAndFeel.SkinName = "Blue";
            pControl.LookAndFeel.UseDefaultLookAndFeel = false;
            edit.LookAndFeel.SkinName = "Blue";
            edit.LookAndFeel.UseDefaultLookAndFeel = false;

            treeList = new TreeList();
            treeList.Dock = DockStyle.Fill;
            treeList.LookAndFeel.SkinName = "Blue";
            treeList.LookAndFeel.UseDefaultLookAndFeel = false;
            treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            treeList.OptionsSelection.EnableAppearanceFocusedRow = false;
            txtSearch = new TextEdit();
            TableLayoutPanel layout = new TableLayoutPanel();
            layout.ColumnCount = 1;
            layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            layout.Controls.Add(txtSearch, 0, 1);
            layout.Controls.Add(treeList, 0, 0);
            layout.Location = new System.Drawing.Point(105, 34);
            layout.Name = "layout";
            layout.RowCount = 2;
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            layout.Size = new System.Drawing.Size(200, 100);
            layout.TabIndex = 2;
            layout.Dock = DockStyle.Fill;

            txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            txtSearch.Location = new System.Drawing.Point(3, 77);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(194, 20);
            txtSearch.TabIndex = 3;
            txtSearch.KeyDown += TxtSearch_KeyDown;


            pControl.Controls.Add(layout);
            edit.Properties.PopupControl = pControl;
            edit.Dock = DockStyle.Fill;
            this.MaximumSize = new Size(1000, edit.Size.Height);
            this.MinimumSize = new Size(10, edit.Size.Height);
            this.Size = new Size(100, 20);
            pControl.Size = new Size(400, 350);
        }

        private System.Collections.Generic.List<string> arrTim = new System.Collections.Generic.List<string>();
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                    return;
                Commons.Modules.ObjSystems.HTimXtraTreeList(txtSearch.Text, treeList, KeyFieldName, ColumnDisplayName, ref arrTim);
                txtSearch.Text = "";
            }
            catch
            {
            }
        }

        public delegate void EventArgs(object sender, EventArgs e);
        public event EventArgs EditValuedChanged;

        private void Edit_QueryDisplayText(object sender, DevExpress.XtraEditors.Controls.QueryDisplayTextEventArgs e)
        {
            try
            {
                e.DisplayText = treeList.FocusedNode[ColumnDisplayName].ToString();
                TextValue = treeList.FocusedNode[ColumnDisplayName].ToString();
            }
            catch
            {
                e.DisplayText = "";
                TextValue = "";
                treeList.Selection.Clear();
            }

        }

        private void Edit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            try
            {
                e.Value = treeList.FocusedNode[KeyFieldName].ToString();
            }
            catch
            {
                e.Value = "";
                treeList.Selection.Clear();
            }
        }

        public void DataBind()
        {
            treeList.BeginUpdate();
            treeList.ParentFieldName = ParentFieldName;
            treeList.KeyFieldName = KeyFieldName;
            treeList.DataSource = DataSource;
            treeList.OptionsBehavior.Editable = false;
            treeList.PopulateColumns();
            foreach (TreeListColumn col in treeList.Columns)
            {
                col.Visible = col.FieldName == ColumnDisplayName ? true : false;
            }
            treeList.Columns[ColumnDisplayName].BestFit();
            treeList.Columns[ColumnDisplayName].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.ParentForm.Name, ColumnDisplayName, Commons.Modules.TypeLanguage);
            treeList.ExpandAll();
            treeList.EndUpdate();
            treeList.FocusedNodeChanged -= TreeList_FocusedNodeChanged;
            treeList.BeforeExpand -= TreeList_BeforeExpand;
            treeList.BeforeCollapse -= TreeList_BeforeCollapse;
            treeList.FocusedNodeChanged += TreeList_FocusedNodeChanged;
            treeList.BeforeExpand += TreeList_BeforeExpand;
            treeList.BeforeCollapse += TreeList_BeforeCollapse;
            DevExpress.XtraTreeList.Nodes.TreeListNode firstNode = treeList.GetNodeByVisibleIndex(0);
            treeList.SetFocusedNode(firstNode);
            EditValue = treeList.FocusedNode[KeyFieldName].ToString();
            edit.EditValue = treeList.FocusedNode[ColumnDisplayName].ToString();
            TextValue = treeList.FocusedNode[ColumnDisplayName].ToString();
        }

        private void TreeList_BeforeCollapse(object sender, BeforeCollapseEventArgs e)
        {
            //e.CanCollapse = false;
        }

        private void TreeList_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            //e.CanExpand = false;
        }

        public void SetValue(object value)
        {
            treeList.SetFocusedNode(treeList.FindNodeByFieldValue(KeyFieldName, value));
            try
            {
                flag = true;
                SelectedIndex = treeList.GetVisibleIndexByNode(treeList.FocusedNode);
                flag = false;
            }
            catch { }
            if (treeList.FocusedNode == null)
            {
                flag = true;
                SelectedIndex = -1;
                flag = false;
            }
            edit.Refresh();
        }

        private void TreeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            edit.QueryResultValue -= Edit_QueryResultValue;
            edit.QueryDisplayText -= Edit_QueryDisplayText;
            try
            {
                EditValue = treeList.FocusedNode[KeyFieldName].ToString();
                TextValue = treeList.FocusedNode[ColumnDisplayName].ToString();
            }
            catch
            {
                EditValue = "";
                TextValue = "";
                treeList.Selection.Clear();
            }
            edit.QueryResultValue += Edit_QueryResultValue;
            edit.QueryDisplayText += Edit_QueryDisplayText;
            if (pControl.OwnerEdit != null)
                pControl.OwnerEdit.ClosePopup();
        }
    }
}