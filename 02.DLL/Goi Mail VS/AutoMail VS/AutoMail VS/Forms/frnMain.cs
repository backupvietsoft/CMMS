
using DevExpress.XtraBars;
using System;
using System.Windows.Forms;

namespace AutoMail_VS
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DevExpress.Utils.LookAndFeelMenu menu = new DevExpress.Utils.LookAndFeelMenu(this, defaultLookAndFeel1, "Vs");
            //this.defaultLookAndFeel1.LookAndFeel.SkinName = "Black";
            //defaultLookAndFeel1.LookAndFeel.SetSkinStyle(this.defaultLookAndFeel1.LookAndFeel.SkinName);

            //AddBarItems();
        }

        public void AddBarItems()
        {
            #region Main Menu Bar
            BarManager barManager = new BarManager();
            barManager.Form = this;
            // Prevent excessive updates while adding and customizing bars and bar items. 
            // The BeginUpdate must match the EndUpdate method. 
            barManager.BeginUpdate();
            // Create two bars and dock them to the top of the form. 
            // Bar1 - is a main menu, which is stretched to match the form's width. 
            // Bar2 - is a regular bar. 
            Bar bar1 = new Bar(barManager, "My MainMenu");
            Bar bar2 = new Bar(barManager, "My Bar");
            bar1.DockStyle = BarDockStyle.Top;
            bar2.DockStyle = BarDockStyle.Top;
            // Position the bar1 above the bar2 
            bar1.DockRow = 0;
            // The bar1 must act as the main menu. 
            barManager.MainMenu = bar1;

            // Create bar items for the bar1 and bar2 
            BarSubItem subMenuFile = new BarSubItem(barManager, "File");
            BarSubItem subMenuEdit = new BarSubItem(barManager, "Edit");
            BarSubItem subMenuView = new BarSubItem(barManager, "View");

            BarButtonItem buttonOpen = new BarButtonItem(barManager, "Open");
            BarButtonItem buttonExit = new BarButtonItem(barManager, "Exit");
            BarButtonItem buttonCopy = new BarButtonItem(barManager, "Copy");
            BarButtonItem buttonCut = new BarButtonItem(barManager, "Cut");
            BarButtonItem buttonViewOutput = new BarButtonItem(barManager, "Output");

            subMenuFile.AddItems(new BarItem[] { buttonOpen, buttonExit });
            subMenuEdit.AddItems(new BarItem[] { buttonCopy, buttonCut });
            subMenuView.AddItem(buttonViewOutput);

            //Add the sub-menus to the bar1 
            bar1.AddItems(new BarItem[] { subMenuFile, subMenuEdit, subMenuView });

            // Add the buttonViewOutput to the bar2. 
            bar2.AddItem(buttonViewOutput);

            // A handler to process clicks on bar items 
            barManager.ItemClick += new ItemClickEventHandler(barManager_ItemClick);

            barManager.EndUpdate();
            #endregion
        }
        void barManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarSubItem subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            MessageBox.Show("Item '" + e.Item.Caption + "' has been clicked");
        }
    }
}
