using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public class Toolbarvs : BindingNavigator
    {
        // 
        // Khai báo 
        // 
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddItem = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton bindingNavigatorUpdateItem = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton bindingNavigatorSaveItem = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton bindingNavigatorPrintItem = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton bindingNavigatorCancelItem = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton bindingNavigatorFillterItem = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton bindingNavigatorRefreshItem = new ToolStripButton();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4 = new ToolStripSeparator();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5 = new ToolStripSeparator();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6 = new ToolStripSeparator();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7 = new ToolStripSeparator();
        // 
        // Khởi tạo
        // 
        public Toolbarvs()
        {
            try
            {
                this.GripStyle = ToolStripGripStyle.Hidden;
            }
            catch
            {
            }

        }
        // 
        // Add Item
        // 
        public ToolStripButton AddItem
        {
            get
            {
                return bindingNavigatorAddItem;
            }
            set
            {
                bindingNavigatorAddItem = value;
            }
        }
        // 
        // Update Item
        // 
        public ToolStripButton UpdateItem
        {
            get
            {
                return bindingNavigatorUpdateItem;
            }
            set
            {
                bindingNavigatorUpdateItem = value;
            }
        }
        // 
        // Delete Item
        //         
        public ToolStripButton DelItem
        {
            get
            {
                return bindingNavigatorDeleteItem;
            }
            set
            {
                bindingNavigatorDeleteItem = value;
            }
        }
        // 
        // Save Item
        // 
        public ToolStripButton SaveItem
        {
            get
            {
                return bindingNavigatorSaveItem;
            }
            set
            {
                bindingNavigatorSaveItem = value;
            }
        }
        // 
        // Print Item
        // 
        public ToolStripButton PrintItem
        {
            get
            {
                return bindingNavigatorPrintItem;
            }
            set
            {
                bindingNavigatorPrintItem = value;
            }
        }
        // 
        // Cancel Item
        // 
        public ToolStripButton CancelItem
        {
            get
            {
                return bindingNavigatorCancelItem;
            }
            set
            {
                bindingNavigatorCancelItem = value;
            }
        }
        // 
        // Filter Item
        // 
        public ToolStripButton FilterItem
        {
            get
            {
                return bindingNavigatorFillterItem;
            }
            set
            {
                bindingNavigatorFillterItem = value;
            }
        }
        // 
        // Refresh Item
        // 
        public ToolStripButton RefreshItem
        {
            get
            {
                return bindingNavigatorRefreshItem;
            }
            set
            {
                bindingNavigatorRefreshItem = value;
            }
        }
        // 
        // Định nghĩa lại AddStandardItems
        // 
        public override void AddStandardItems()
        {
            base.AddStandardItems();
            this.Items.Remove(this.AddNewItem);
            this.AddNewItem.Dispose();
            this.Items.Remove(this.DeleteItem);
            this.DeleteItem.Dispose();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toolbarvs));
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.bindingNavigatorAddItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorUpdateItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorPrintItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCancelItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorFillterItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorRefreshItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.SuspendLayout();
            // 
            // bindingNavigatorAddItem
            // 
            this.bindingNavigatorAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorAddItem.Image = Vietsoft.Admin.Properties.Resources.AddNew;
            this.bindingNavigatorAddItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.bindingNavigatorAddItem.Name = "bindingNavigatorAddItem";
            this.bindingNavigatorAddItem.Size = new System.Drawing.Size(23, 23);
            this.bindingNavigatorAddItem.Text = "Add New";
            // 
            // bindingNavigatorUpdateItem
            // 
            this.bindingNavigatorUpdateItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorUpdateItem.Image = Vietsoft.Admin.Properties.Resources.Update;
            this.bindingNavigatorUpdateItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.bindingNavigatorUpdateItem.Name = "bindingNavigatorUpdateItem";
            this.bindingNavigatorUpdateItem.Size = new System.Drawing.Size(23, 23);
            this.bindingNavigatorUpdateItem.Text = "Update";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorDeleteItem.Image = Vietsoft.Admin.Properties.Resources.Delete;
            this.bindingNavigatorDeleteItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 23);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorSaveItem
            // 
            this.bindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorSaveItem.Image = Vietsoft.Admin.Properties.Resources.Save;
            this.bindingNavigatorSaveItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.bindingNavigatorSaveItem.Name = "bindingNavigatorSaveItem";
            this.bindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.bindingNavigatorSaveItem.Text = "Save";
            // 
            // bindingNavigatorCancelItem
            // 
            this.bindingNavigatorCancelItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorCancelItem.Image = Vietsoft.Admin.Properties.Resources.Cancel;
            this.bindingNavigatorCancelItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.bindingNavigatorCancelItem.Name = "bindingNavigatorCancelItem";
            this.bindingNavigatorCancelItem.Size = new System.Drawing.Size(23, 23);
            this.bindingNavigatorCancelItem.Text = "Cancel";
            // 
            // bindingNavigatorPrintItem
            // 
            this.bindingNavigatorPrintItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorPrintItem.Image = Vietsoft.Admin.Properties.Resources.Print;
            this.bindingNavigatorPrintItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.bindingNavigatorPrintItem.Name = "bindingNavigatorPrintItem";
            this.bindingNavigatorPrintItem.Size = new System.Drawing.Size(23, 23);
            this.bindingNavigatorPrintItem.Text = "Print";
            // 
            // bindingNavigatorFillterItem
            // 
            this.bindingNavigatorFillterItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorFillterItem.Image = Vietsoft.Admin.Properties.Resources.Filter;
            this.bindingNavigatorFillterItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.bindingNavigatorFillterItem.Name = "bindingNavigatorFillterItem";
            this.bindingNavigatorFillterItem.Size = new System.Drawing.Size(23, 23);
            this.bindingNavigatorFillterItem.Text = "Filter";
            // 
            // bindingNavigatorRefreshItem
            // 
            this.bindingNavigatorRefreshItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorRefreshItem.Image = Vietsoft.Admin.Properties.Resources.Refresh;
            this.bindingNavigatorRefreshItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.bindingNavigatorRefreshItem.Name = "bindingNavigatorRefreshItem";
            this.bindingNavigatorRefreshItem.Size = new System.Drawing.Size(23, 23);
            this.bindingNavigatorRefreshItem.Text = "Refresh";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // 
            // BindingNavigatorVietsoft
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddItem});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorUpdateItem});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorDeleteItem});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSaveItem});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorCancelItem});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorPrintItem});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorFillterItem});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorRefreshItem});
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
