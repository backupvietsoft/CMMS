using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WareHouse
{
    public partial class EcomaintGrid : DevExpress.XtraGrid.GridControl
    {
        public EcomaintGrid()
        {
            InitializeComponent();
        }
        public void ExpressionSum(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, column,gridView1.Columns[column],"{0:N2}")});
           
        }
        public void ExpressionCount(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, column ,gridView1.Columns[column],"")});

        }
        public void ExpressionAvegare(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, column ,gridView1.Columns[column],"")});

        }
        public void ExpressionMax(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, column ,gridView1.Columns[column],"")});

        }
        public void ExpressionMin(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, column ,gridView1.Columns[column],"")});

        }
        public void ExpresSumFooter(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, column, gridView1.Columns[column], "{0:N2}");
            gridView1.Columns[column].SummaryItem.DisplayFormat = "{0:N2}";
            gridView1.Columns[column].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        }
        public void ExpressionGroupBy(DevExpress.XtraGrid.Views.Grid.GridView gridView1, string column)
        {
            try
            {
                gridView1.Columns[column].Group();
                gridView1.ExpandAllGroups();
            }
            catch { }

        }
    }
}
