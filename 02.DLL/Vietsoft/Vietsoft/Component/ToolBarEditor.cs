using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Vietsoft
{
    public class ToolBarEditor : BindingNavigator
    {
        /// <summary>
        /// Declare public
        /// </summary>                                              
        private System.Windows.Forms.ToolStripButton _AddNewEditor = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton _UpdateEditor = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton _DeleteEditor = new ToolStripButton();        
        private System.Windows.Forms.ToolStripButton _LockEditor = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton _PrintEditor = new ToolStripButton();        
        private System.Windows.Forms.ToolStripButton _FilterEditor = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton _RefreshEditor = new ToolStripButton();
        private System.Windows.Forms.ToolStripButton _HelpEditor = new ToolStripButton();
        private System.Windows.Forms.ToolStripSeparator _Separator4 = new ToolStripSeparator();
        private System.Windows.Forms.ToolStripSeparator _Separator5 = new ToolStripSeparator();
        private System.Windows.Forms.ToolStripSeparator _Separator6 = new ToolStripSeparator();
        private System.Windows.Forms.ToolStripSeparator _Separator7 = new ToolStripSeparator();        
        private string _CurrentState = String.Empty;
        private string _BackState = String.Empty;
        private string _FormName = String.Empty;        
        /// <summary>
        /// Declare function
        /// </summary>                                              
        public ToolBarEditor()
        {
            try
            {                                
                this.GripStyle = ToolStripGripStyle.Hidden;                
            }
            catch
            {
            }
        }
        /// <summary>
        /// AddNewEditor
        /// </summary> 
        public ToolStripButton AddNewEditor
        {
            get
            {
                return _AddNewEditor;
            }
            set
            {
                _AddNewEditor = value;
            }
        }
        /// <summary>
        /// UpdateEditor
        /// </summary> 
        public ToolStripButton UpdateEditor
        {
            get
            {
                return _UpdateEditor;
            }
            set
            {
                _UpdateEditor = value;
            }
        }
        /// <summary>
        /// DeleteEditor
        /// </summary> 
        public ToolStripButton DeleteEditor
        {
            get
            {
                return _DeleteEditor;
            }
            set
            {
                _DeleteEditor = value;
            }
        }       
        /// <summary>
        /// LockEditor
        /// </summary> 
        public ToolStripButton LockEditor
        {
            get
            {
                return _LockEditor;
            }
            set
            {
                _LockEditor = value;
            }
        }
        /// <summary>
        /// LockEditor
        /// </summary> 
        public ToolStripButton HelpEditor
        {
            get
            {
                return _HelpEditor;
            }
            set
            {
                _HelpEditor = value;
            }
        }
        /// <summary>
        /// PrintEditor
        /// </summary> 
        public ToolStripButton PrintEditor
        {
            get
            {
                return _PrintEditor;
            }
            set
            {
                _PrintEditor = value;
            }
        }
        /// <summary>
        /// FilterEditor
        /// </summary> 
        public ToolStripButton FilterEditor
        {
            get
            {
                return _FilterEditor;
            }
            set
            {
                _FilterEditor = value;
            }
        }
        /// <summary>
        /// RefreshEditor
        /// </summary> 
        public ToolStripButton RefreshEditor
        {
            get
            {
                return _RefreshEditor;
            }
            set
            {
                _RefreshEditor = value;
            }
        }
        /// <summary>
        /// AddStandardItems
        /// </summary>         
        public override void AddStandardItems()
        {
            base.AddStandardItems();
            this.Items.Remove(base.AddNewItem);
            this.Items.Remove(base.DeleteItem);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBarEditor));
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this._AddNewEditor = new System.Windows.Forms.ToolStripButton();
            this._UpdateEditor = new System.Windows.Forms.ToolStripButton();
            this._DeleteEditor = new System.Windows.Forms.ToolStripButton();            
            this._PrintEditor = new System.Windows.Forms.ToolStripButton();
            this._LockEditor = new System.Windows.Forms.ToolStripButton();
            this._FilterEditor = new System.Windows.Forms.ToolStripButton();
            this._RefreshEditor = new System.Windows.Forms.ToolStripButton();
            this._HelpEditor = new System.Windows.Forms.ToolStripButton();
            this._Separator4 = new System.Windows.Forms.ToolStripSeparator();
            this._Separator5 = new System.Windows.Forms.ToolStripSeparator();
            this._Separator6 = new System.Windows.Forms.ToolStripSeparator();
            this._Separator7 = new System.Windows.Forms.ToolStripSeparator();
            this.SuspendLayout();
            /// <summary>
            /// AddNewEditor
            /// </summary> 
            this._AddNewEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this._AddNewEditor.Image = base.AddNewItem.Image;
            this._AddNewEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this._AddNewEditor.Name = "AddNewEditor";
            this._AddNewEditor.Size = new System.Drawing.Size(23, 23);
            this._AddNewEditor.Text = "&AddNew";
            /// <summary>
            /// UpdateEditor
            /// </summary> 
            this._UpdateEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this._UpdateEditor.Image = Vietsoft.Properties.Resources.Update;
            this._UpdateEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this._UpdateEditor.Name = "UpdateEditor";
            this._UpdateEditor.Size = new System.Drawing.Size(23, 23);
            this._UpdateEditor.Text = "&Edit";
            /// <summary>
            /// DeleteEditor
            /// </summary> 
            this._DeleteEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this._DeleteEditor.Image = base.DeleteItem.Image;
            this._DeleteEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this._DeleteEditor.Name = "DeleteEditor";
            this._DeleteEditor.Size = new System.Drawing.Size(23, 23);
            this._DeleteEditor.Text = "&Delete";            
            /// <summary>
            /// LockEditor
            /// </summary> 
            this._LockEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this._LockEditor.Image = Vietsoft.Properties.Resources.Cancel;
            this._LockEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this._LockEditor.Name = "LockEditor";
            this._LockEditor.Size = new System.Drawing.Size(23, 23);
            this._LockEditor.Text = "&Lock";
            /// <summary>
            /// PrintEditor
            /// </summary> 
            this._PrintEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this._PrintEditor.Image = Vietsoft.Properties.Resources.Print;
            this._PrintEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this._PrintEditor.Name = "PrintEditor";
            this._PrintEditor.Size = new System.Drawing.Size(23, 23);
            this._PrintEditor.Text = "&Print";
            /// <summary>
            /// FilterEditor
            /// </summary>            
            this._FilterEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this._FilterEditor.Image = Vietsoft.Properties.Resources.Filter;
            this._FilterEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this._FilterEditor.Name = "FilterEditor";
            this._FilterEditor.Size = new System.Drawing.Size(23, 23);
            this._FilterEditor.Text = "&Filter";
            /// <summary>
            /// RefreshEditor
            /// </summary>  
            this._RefreshEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this._RefreshEditor.Image = Vietsoft.Properties.Resources.Refresh;
            this._RefreshEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this._RefreshEditor.Name = "RefreshEditor";
            this._RefreshEditor.Size = new System.Drawing.Size(23, 23);
            this._RefreshEditor.Text = "&Refresh";
            /// <summary>
            /// HelpEditor
            /// </summary>  
            this._HelpEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this._HelpEditor.Image = Vietsoft.Properties.Resources.Refresh;
            this._HelpEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this._HelpEditor.Name = "HelpEditor";
            this._HelpEditor.Size = new System.Drawing.Size(23, 23);
            this._HelpEditor.Text = "&Help";
            /// <summary>
            /// Separator4
            /// </summary>  
            this._Separator4.Name = "Separator4";
            this._Separator4.Size = new System.Drawing.Size(6, 23);
            /// <summary>
            /// Separator5
            /// </summary>  
            this._Separator5.Name = "Separator5";
            this._Separator5.Size = new System.Drawing.Size(6, 23);
            /// <summary>
            /// Separator6
            /// </summary>  
            this._Separator6.Name = "Separator6";
            this._Separator6.Size = new System.Drawing.Size(6, 23);
            /// <summary>
            /// Separator7
            /// </summary>  
            this._Separator7.Name = "Separator7";
            this._Separator7.Size = new System.Drawing.Size(6, 23);
                        
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._AddNewEditor});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._UpdateEditor});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._DeleteEditor});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Separator4});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._FilterEditor});                      
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._RefreshEditor});                
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Separator5});                 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._LockEditor});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Separator6});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._PrintEditor});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Separator7});
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._HelpEditor});
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }
        /// <summary>
        /// WndProc
        /// </summary>
        protected override void WndProc(ref Message m)
        {         
            switch (m.Msg)
            {
                case 0x000F:
                    base.WndProc(ref m);
                    Graphics g = Graphics.FromHwnd(Handle);
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.SunkenOuter);
                    g.Dispose();
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        /// <summary>
        /// StatusSoft
        /// </summary>       
        public string CurrentState
        {
            get
            {
                return _CurrentState;
            }
            set
            {
                _BackState = _CurrentState;
                _CurrentState = value;                
            }
        }
        /// <summary>
        /// StatusBack
        /// </summary>        
        public string BackState
        {
            get
            {
                return _BackState;
            }           
        }
        /// <summary>
        /// FormName
        /// </summary>        
        public string FormName
        {
            get
            {
                return _FormName;
            }
            set
            {
                _FormName = value;
            }
        }
        /// <summary>
        /// OnItemClicked
        /// </summary>  
        protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            base.OnItemClicked(e);
            this.CurrentState = e.ClickedItem.Name;            
        }            
    }                  
}
