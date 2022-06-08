namespace Vietsoft
{
    partial class MdiMaint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiMaint));
            this.StatusStripMaint = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolTipMaint = new System.Windows.Forms.ToolTip(this.components);
            this.MnMaint = new Vietsoft.MenuEditor();
            this.ToolBarEditorMaint = new Vietsoft.ToolBarEditor();
            this.AddNewEditor = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.DeleteEditor = new System.Windows.Forms.ToolStripButton();
            this.FilterEditor = new System.Windows.Forms.ToolStripButton();
            this.HelpEditor = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateEditor = new System.Windows.Forms.ToolStripButton();
            this.Separator4 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshEditor = new System.Windows.Forms.ToolStripButton();
            this.Separator5 = new System.Windows.Forms.ToolStripSeparator();
            this.LockEditor = new System.Windows.Forms.ToolStripButton();
            this.Separator6 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintEditor = new System.Windows.Forms.ToolStripButton();
            this.Separator7 = new System.Windows.Forms.ToolStripSeparator();
            this.StatusStripMaint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolBarEditorMaint)).BeginInit();
            this.ToolBarEditorMaint.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStripMaint
            // 
            this.StatusStripMaint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatus});
            this.StatusStripMaint.Location = new System.Drawing.Point(0, 462);
            this.StatusStripMaint.Name = "StatusStripMaint";
            this.StatusStripMaint.Size = new System.Drawing.Size(780, 22);
            this.StatusStripMaint.TabIndex = 2;
            this.StatusStripMaint.Text = "StatusStrip";
            // 
            // ToolStripStatus
            // 
            this.ToolStripStatus.Name = "ToolStripStatus";
            this.ToolStripStatus.Size = new System.Drawing.Size(38, 17);
            this.ToolStripStatus.Text = "Status";
            // 
            // MnMaint
            // 
            this.MnMaint.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MnMaint.Location = new System.Drawing.Point(0, 0);
            this.MnMaint.Name = "MnMaint";
            this.MnMaint.Padding = new System.Windows.Forms.Padding(6, 2, 1, 2);
            this.MnMaint.Size = new System.Drawing.Size(780, 24);
            this.MnMaint.TabIndex = 4;
            this.MnMaint.Text = "MnMaint";
            // 
            // ToolBarEditorMaint
            // 
            this.ToolBarEditorMaint.AddNewEditor = this.AddNewEditor;
            this.ToolBarEditorMaint.AddNewItem = null;
            this.ToolBarEditorMaint.CountItem = this.bindingNavigatorCountItem;
            this.ToolBarEditorMaint.CurrentState = "";
            this.ToolBarEditorMaint.DeleteEditor = this.DeleteEditor;
            this.ToolBarEditorMaint.DeleteItem = null;
            this.ToolBarEditorMaint.FilterEditor = this.FilterEditor;
            this.ToolBarEditorMaint.FormName = "";
            this.ToolBarEditorMaint.GripMargin = new System.Windows.Forms.Padding(0);
            this.ToolBarEditorMaint.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBarEditorMaint.HelpEditor = this.HelpEditor;
            this.ToolBarEditorMaint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.AddNewEditor,
            this.UpdateEditor,
            this.DeleteEditor,
            this.Separator4,
            this.FilterEditor,
            this.RefreshEditor,
            this.Separator5,
            this.LockEditor,
            this.Separator6,
            this.PrintEditor,
            this.Separator7,
            this.HelpEditor});
            this.ToolBarEditorMaint.Location = new System.Drawing.Point(0, 24);
            this.ToolBarEditorMaint.LockEditor = this.LockEditor;
            this.ToolBarEditorMaint.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.ToolBarEditorMaint.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.ToolBarEditorMaint.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.ToolBarEditorMaint.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.ToolBarEditorMaint.Name = "ToolBarEditorMaint";
            this.ToolBarEditorMaint.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ToolBarEditorMaint.PositionItem = this.bindingNavigatorPositionItem;
            this.ToolBarEditorMaint.PrintEditor = this.PrintEditor;
            this.ToolBarEditorMaint.RefreshEditor = this.RefreshEditor;
            this.ToolBarEditorMaint.Size = new System.Drawing.Size(780, 25);
            this.ToolBarEditorMaint.TabIndex = 13;
            this.ToolBarEditorMaint.Text = "ToolBarEditorMaint";
            this.ToolBarEditorMaint.UpdateEditor = this.UpdateEditor;
            this.ToolBarEditorMaint.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolBarEditorMaint_ItemClicked);
            // 
            // AddNewEditor
            // 
            this.AddNewEditor.Image = ((System.Drawing.Image)(resources.GetObject("AddNewEditor.Image")));
            this.AddNewEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddNewEditor.Name = "AddNewEditor";
            this.AddNewEditor.Size = new System.Drawing.Size(67, 22);
            this.AddNewEditor.Text = "&AddNew";
            this.AddNewEditor.Click += new System.EventHandler(this.AddNewEditor_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // DeleteEditor
            // 
            this.DeleteEditor.Image = ((System.Drawing.Image)(resources.GetObject("DeleteEditor.Image")));
            this.DeleteEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.DeleteEditor.Name = "DeleteEditor";
            this.DeleteEditor.Size = new System.Drawing.Size(58, 22);
            this.DeleteEditor.Text = "&Delete";
            // 
            // FilterEditor
            // 
            this.FilterEditor.Image = ((System.Drawing.Image)(resources.GetObject("FilterEditor.Image")));
            this.FilterEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.FilterEditor.Name = "FilterEditor";
            this.FilterEditor.Size = new System.Drawing.Size(51, 22);
            this.FilterEditor.Text = "&Filter";
            // 
            // HelpEditor
            // 
            this.HelpEditor.Image = ((System.Drawing.Image)(resources.GetObject("HelpEditor.Image")));
            this.HelpEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.HelpEditor.Name = "HelpEditor";
            this.HelpEditor.Size = new System.Drawing.Size(48, 22);
            this.HelpEditor.Text = "&Help";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // UpdateEditor
            // 
            this.UpdateEditor.Image = ((System.Drawing.Image)(resources.GetObject("UpdateEditor.Image")));
            this.UpdateEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.UpdateEditor.Name = "UpdateEditor";
            this.UpdateEditor.Size = new System.Drawing.Size(45, 22);
            this.UpdateEditor.Text = "&Edit";
            // 
            // Separator4
            // 
            this.Separator4.Name = "Separator4";
            this.Separator4.Size = new System.Drawing.Size(6, 25);
            // 
            // RefreshEditor
            // 
            this.RefreshEditor.Image = ((System.Drawing.Image)(resources.GetObject("RefreshEditor.Image")));
            this.RefreshEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.RefreshEditor.Name = "RefreshEditor";
            this.RefreshEditor.Size = new System.Drawing.Size(65, 22);
            this.RefreshEditor.Text = "&Refresh";
            // 
            // Separator5
            // 
            this.Separator5.Name = "Separator5";
            this.Separator5.Size = new System.Drawing.Size(6, 25);
            // 
            // LockEditor
            // 
            this.LockEditor.Image = ((System.Drawing.Image)(resources.GetObject("LockEditor.Image")));
            this.LockEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.LockEditor.Name = "LockEditor";
            this.LockEditor.Size = new System.Drawing.Size(48, 22);
            this.LockEditor.Text = "&Lock";
            // 
            // Separator6
            // 
            this.Separator6.Name = "Separator6";
            this.Separator6.Size = new System.Drawing.Size(6, 25);
            // 
            // PrintEditor
            // 
            this.PrintEditor.Image = ((System.Drawing.Image)(resources.GetObject("PrintEditor.Image")));
            this.PrintEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.PrintEditor.Name = "PrintEditor";
            this.PrintEditor.Size = new System.Drawing.Size(49, 22);
            this.PrintEditor.Text = "&Print";
            // 
            // Separator7
            // 
            this.Separator7.Name = "Separator7";
            this.Separator7.Size = new System.Drawing.Size(6, 25);
            // 
            // MdiMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vietsoft.Properties.Resources.Eco_VICT;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(780, 484);
            this.Controls.Add(this.ToolBarEditorMaint);
            this.Controls.Add(this.StatusStripMaint);
            this.Controls.Add(this.MnMaint);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MnMaint;
            this.Name = "MdiMaint";
            this.Text = "CMMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MdiChildActivate += new System.EventHandler(this.MdiMaint_MdiChildActivate);
            this.StatusStripMaint.ResumeLayout(false);
            this.StatusStripMaint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolBarEditorMaint)).EndInit();
            this.ToolBarEditorMaint.ResumeLayout(false);
            this.ToolBarEditorMaint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip StatusStripMaint;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatus;
        private System.Windows.Forms.ToolTip ToolTipMaint;
        private MenuEditor MnMaint;
        private ToolBarEditor ToolBarEditorMaint;
        private System.Windows.Forms.ToolStripButton AddNewEditor;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton DeleteEditor;
        private System.Windows.Forms.ToolStripButton FilterEditor;
        private System.Windows.Forms.ToolStripButton HelpEditor;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton UpdateEditor;
        private System.Windows.Forms.ToolStripSeparator Separator4;
        private System.Windows.Forms.ToolStripButton RefreshEditor;
        private System.Windows.Forms.ToolStripSeparator Separator5;
        private System.Windows.Forms.ToolStripButton LockEditor;
        private System.Windows.Forms.ToolStripSeparator Separator6;
        private System.Windows.Forms.ToolStripButton PrintEditor;
        private System.Windows.Forms.ToolStripSeparator Separator7;
    }
}



