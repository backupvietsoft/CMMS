using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vietsoft.Reminder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //gridView1.OptionsView.ColumnAutoWidth = false;
            //gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            //gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            //gridView1.ColumnPanelRowHeight = 40;



            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable TbTB = new DataTable();
                try
                {
                    TbTB.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_MAY", Commons.Modules.UserName, Commons.Modules.TypeLanguage, "-1", "-1", -1, "-1", "-1", "-1"));
                    TbTB.Rows.Add("-1", " < ALL > ", "-1");
                    TbTB.DefaultView.Sort = "MS_MAY";
                    TbTB = TbTB.DefaultView.ToTable();


                    Commons.Modules.SQLString = "0LOAD";

                    cboThietBi2.Properties.DataSource = TbTB;
                    cboThietBi2.Properties.DisplayMember = "TEN_MAY";
                    cboThietBi2.Properties.ValueMember = "MS_MAY";
                    cboThietBi2.EditValue = TbTB.Rows[0][0];


                    cboThietbi.Properties.DataSource = TbTB;
                    cboThietbi.Properties.DisplayMember = "TEN_MAY";
                    cboThietbi.Properties.ValueMember = "MS_MAY";
                    cboThietbi.EditValue = TbTB.Rows[0][0];
                }
                catch { }
                this.Cursor = Cursors.Default;
            }
            catch { }
            Commons.Modules.SQLString = "";
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {

        }
    }

    
}
