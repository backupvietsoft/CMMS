using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vietsoft
{
    public partial class MdiMaint : Form
    {        
        public MdiMaint()
        {
            InitializeComponent();
            MnMaint.InitializeMenuEditor();
            this.ToolBarEditorMaint.BindingSource = new BindingSource();
        }
        /// <summary>
        /// MdiChildActivate
        /// </summary> 
        private void MdiMaint_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ToolBarEditorMaint.CurrentState = ((FormBase)this.ActiveMdiChild).CurrentState;
                this.ToolBarEditorMaint.BindingSource = ((FormBase)this.ActiveMdiChild).BindingSource;
                this.ToolBarEditorMaint.FormName = ((FormBase)this.ActiveMdiChild).Name;
            }
            else
            {
                this.ToolBarEditorMaint.FormName = String.Empty;
            }
        }
        /// <summary>
        /// ItemClicked
        /// </summary> 
        private void ToolBarEditorMaint_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ((FormBase)this.ActiveMdiChild).CurrentState = this.ToolBarEditorMaint.CurrentState;                
            }
        }

        private void AddNewEditor_Click(object sender, EventArgs e)
        {
            MnSystem frm = new MnSystem();
            frm.MdiParent = this;
            frm.Show();
        }         
    }
}
