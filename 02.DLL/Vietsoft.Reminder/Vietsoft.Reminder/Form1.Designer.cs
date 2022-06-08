namespace Vietsoft.Reminder
{
    partial class Form1
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
            this.cboThietBi2 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.cboThietBi2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboThietbi = new DevExpress.XtraEditors.GridLookUpEdit();
            this.cboThietbiView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietBi2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietBi2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietbi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietbiView)).BeginInit();
            this.SuspendLayout();
            // 
            // cboThietBi2
            // 
            this.cboThietBi2.EditValue = " ";
            this.cboThietBi2.Location = new System.Drawing.Point(12, 52);
            this.cboThietBi2.Name = "cboThietBi2";
            this.cboThietBi2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboThietBi2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboThietBi2.Properties.ImmediatePopup = true;
            this.cboThietBi2.Properties.NullText = "";
            this.cboThietBi2.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.cboThietBi2.Properties.View = this.cboThietBi2View;
            this.cboThietBi2.Properties.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView;
            this.cboThietBi2.Size = new System.Drawing.Size(1054, 20);
            this.cboThietBi2.TabIndex = 107;
            // 
            // cboThietBi2View
            // 
            this.cboThietBi2View.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cboThietBi2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cboThietBi2View.Name = "cboThietBi2View";
            this.cboThietBi2View.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.cboThietBi2View.OptionsFilter.UseNewCustomFilterDialog = true;
            this.cboThietBi2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cboThietBi2View.OptionsView.ShowAutoFilterRow = true;
            this.cboThietBi2View.OptionsView.ShowGroupPanel = false;
            // 
            // cboThietbi
            // 
            this.cboThietbi.EditValue = " ";
            this.cboThietbi.Location = new System.Drawing.Point(0, 186);
            this.cboThietbi.Name = "cboThietbi";
            this.cboThietbi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboThietbi.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.cboThietbi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboThietbi.Properties.NullText = "";
            this.cboThietbi.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.FrameResize;
            this.cboThietbi.Properties.PopupSizeable = false;
            this.cboThietbi.Properties.View = this.cboThietbiView;
            this.cboThietbi.Properties.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView;
            this.cboThietbi.Size = new System.Drawing.Size(953, 20);
            this.cboThietbi.TabIndex = 107;
            // 
            // cboThietbiView
            // 
            this.cboThietbiView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cboThietbiView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cboThietbiView.Name = "cboThietbiView";
            this.cboThietbiView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cboThietbiView.OptionsView.ShowAutoFilterRow = true;
            this.cboThietbiView.OptionsView.ShowGroupPanel = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 545);
            this.Controls.Add(this.cboThietbi);
            this.Controls.Add(this.cboThietBi2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboThietBi2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietBi2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietbi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThietbiView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit cboThietBi2;
        private DevExpress.XtraGrid.Views.Grid.GridView cboThietBi2View;
        private DevExpress.XtraEditors.GridLookUpEdit cboThietbi;
        private DevExpress.XtraGrid.Views.Grid.GridView cboThietbiView;
    }
}