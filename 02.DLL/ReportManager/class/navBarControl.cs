using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraNavBar;


namespace ReportManager
{//    public partial class navBarControl : NavBarControl

    public class navBarControl : NavBarControl
    {
        #region Property

        private DataContainer dc;
        //private DBIO dbio;
        public EventHandler helpText = null;
        public SortedList ribbonItemList = null;

        #endregion
        public navBarControl()
        {
            dc = new DataContainer();
            ribbonItemList = new SortedList();  
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ContentButtonHint = null;
            this.Location = new System.Drawing.Point(3, 16);
            this.Name = "navBarControl";
            this.Size = new System.Drawing.Size(181, 481);
            this.TabIndex = 0;
            this.Text = "Danh sách báo cáo";
            this.LoadGroup("GetGroupReports", Vietsoft.Information.UserID);

            this.AllowSelectedLink = true;
            this.Appearance.ItemPressed.BackColor = System.Drawing.Color.Blue;
            this.Appearance.ItemPressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Appearance.ItemPressed.ForeColor = System.Drawing.Color.Red;
            this.Appearance.ItemPressed.Options.UseBackColor = true;
            this.Appearance.ItemPressed.Options.UseFont = true;
            this.Appearance.ItemPressed.Options.UseForeColor = true;
            this.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Caramel");
        }


        public void LoadGroup(string storeproceduce, string username)
        {
            try
            {
                dc.Set("groupName", "groupname");
                DataMatrix groupList = DBIO.QueryMultiRow(dc, storeproceduce, "menuList", username,"");
                for (int i = 0; i < groupList.GetRows(); i++)
                {
                    navBarGroup navBarGroup = new navBarGroup();
                    //navBarGroup.Text = groupList.GetCell(0, i);
                    navBarGroup.Name = groupList.GetCell(1, i).ToString();
                    navBarGroup.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReports", groupList.GetCell(1, i), Commons.Modules.TypeLanguage);
                    navBarGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                    navBarGroup.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
                    navBarGroup.Appearance.Options.UseForeColor = true;
                    navBarGroup.Appearance.Options.UseFont = true;
                    navBarGroup.Expanded = false;
                    ribbonItemList[groupList.GetCell(1, i)] = navBarGroup;
                    string ribbonItem = groupList.GetCell(0, i);
                    if (ribbonItem != "")
                    {
                        LoadItem(navBarGroup, ribbonItem, username);
                    }
                    this.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
                                navBarGroup});
                }
            }
            catch
            { }
        }

        private void LoadItem(NavBarGroup navBarGroup, string groupName, string username)
        {
            try
            {
                dc.Set("itemName", groupName);
                DataMatrix itemList = DBIO.QueryMultiRow(dc, "Get_lstDanhsachbaocao", "itemList", username, groupName);
                for (int i = 0; i < itemList.GetRows(); i++)
                {
                    navBarItem navBarItem = new navBarItem();
                    navBarItem.Caption = itemList.GetCell(1, i);
                    navBarItem.Name = itemList.GetCell(0, i);
                    navBarItem.help = itemList.GetCell(2, i);
                    navBarItem.uc = itemList.GetCell(3, i);

                    ribbonItemList[itemList.GetCell(0, i)] = navBarItem;
                    if (itemList.GetCell(4, i) != null && itemList.GetCell(4, i).ToString() != "")
                        navBarItem.SmallImageIndex = Int32.Parse(itemList.GetCell(4, i).ToString());
                    else
                        navBarItem.SmallImageIndex = 0;

                    

                    navBarItem.clickEvent = "barLinkClick";
                    navBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(ClickMenuItem);

                    navBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
                    new DevExpress.XtraNavBar.NavBarItemLink(navBarItem)});
                    this.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] { navBarItem });
                }
            }
            catch
            { }
        }

        private void ClickMenuItem(object obj, NavBarLinkEventArgs e)
        {            
            EventCollection.Invoke(obj, "barLinkClick", null, e.Link);
        }


        public void ReloadControl()
        {
            // Code here to refresh controls on page
        } 

    }
}