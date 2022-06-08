using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVControl
{

    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private ucComboboxTreeList cbo;
        public Form1()
        {
            InitializeComponent();
            cbo = new MVControl.ucComboboxTreeList();
            this.cbo.ColumnDisplayName = null;
            this.cbo.DataSource = null;
            this.cbo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo.EditValue = null;
            this.cbo.KeyFieldName = null;
            this.cbo.Location = new System.Drawing.Point(23, 11);
            this.cbo.LookAndFeel.SkinName = "Blue";
            this.cbo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cbo.MaximumSize = new System.Drawing.Size(1000, 20);
            this.cbo.MinimumSize = new System.Drawing.Size(10, 20);
            this.cbo.Name = "cbo";
            this.cbo.ParentFieldName = null;
            this.cbo.SelectedIndex = 0;
            this.cbo.Size = new System.Drawing.Size(768, 20);
            this.cbo.TabIndex = 77;
            this.cbo.EditValuedChanged += cbo_EditValuedChanged;
            Controls.Add(cbo);
        }

        private void cbo_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {

          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", 0, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            cbo.KeyFieldName = "MS_HE_THONG";
            cbo.ParentFieldName = "MS_CHA";
            cbo.ColumnDisplayName = "TEN_HE_THONG";

            cbo.DataSource = dt;
            cbo.DataBind();
            
            cbo.SetValue("21");
        }
    }
}
