namespace Vietsoft
{
    partial class DataGridViewFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TlbLayOut = new System.Windows.Forms.TableLayoutPanel();
            this.DgvVFilter = new System.Windows.Forms.DataGridView();
            this.TxtTFilter = new Vietsoft.MaskedEditor();
            this.PLayOut = new System.Windows.Forms.Panel();
            this.BtnOr = new System.Windows.Forms.Button();
            this.BtnAnd = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.TxtVFilter = new Vietsoft.MaskedEditor();
            this.BtnTitle = new System.Windows.Forms.Button();
            this.DgvTFilter = new System.Windows.Forms.DataGridView();
            this.TlbLayOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVFilter)).BeginInit();
            this.PLayOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // TlbLayOut
            // 
            this.TlbLayOut.ColumnCount = 2;
            this.TlbLayOut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.TlbLayOut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbLayOut.Controls.Add(this.DgvVFilter, 1, 2);
            this.TlbLayOut.Controls.Add(this.TxtTFilter, 0, 1);
            this.TlbLayOut.Controls.Add(this.PLayOut, 0, 3);
            this.TlbLayOut.Controls.Add(this.TxtVFilter, 1, 1);
            this.TlbLayOut.Controls.Add(this.BtnTitle, 0, 0);
            this.TlbLayOut.Controls.Add(this.DgvTFilter, 0, 2);
            this.TlbLayOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlbLayOut.Location = new System.Drawing.Point(0, 0);
            this.TlbLayOut.Margin = new System.Windows.Forms.Padding(0);
            this.TlbLayOut.Name = "TlbLayOut";
            this.TlbLayOut.RowCount = 4;
            this.TlbLayOut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TlbLayOut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TlbLayOut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlbLayOut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.TlbLayOut.Size = new System.Drawing.Size(354, 254);
            this.TlbLayOut.TabIndex = 0;
            // 
            // DgvVFilter
            // 
            this.DgvVFilter.AllowUserToAddRows = false;
            this.DgvVFilter.AllowUserToDeleteRows = false;
            this.DgvVFilter.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DgvVFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVFilter.ColumnHeadersVisible = false;
            this.DgvVFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvVFilter.Location = new System.Drawing.Point(137, 51);
            this.DgvVFilter.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.DgvVFilter.Name = "DgvVFilter";
            this.DgvVFilter.ReadOnly = true;
            this.DgvVFilter.RowHeadersVisible = false;
            this.DgvVFilter.RowHeadersWidth = 30;
            this.DgvVFilter.Size = new System.Drawing.Size(215, 176);
            this.DgvVFilter.TabIndex = 5;
            this.DgvVFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvVFilter_KeyDown);
            this.DgvVFilter.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVFilter_CellDoubleClick);
            this.DgvVFilter.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvVFilter_ColumnAdded);
            // 
            // TxtTFilter
            // 
            this.TxtTFilter.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtTFilter.CharLength = 32700;
            this.TxtTFilter.DataType = 6;
            this.TxtTFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtTFilter.Location = new System.Drawing.Point(2, 27);
            this.TxtTFilter.Margin = new System.Windows.Forms.Padding(2);
            this.TxtTFilter.Name = "TxtTFilter";
            this.TxtTFilter.ReadOnly = true;
            this.TxtTFilter.Size = new System.Drawing.Size(131, 22);
            this.TxtTFilter.StringFormat = "";
            this.TxtTFilter.TabIndex = 0;
            // 
            // PLayOut
            // 
            this.PLayOut.BackColor = System.Drawing.SystemColors.MenuBar;
            this.TlbLayOut.SetColumnSpan(this.PLayOut, 2);
            this.PLayOut.Controls.Add(this.BtnOr);
            this.PLayOut.Controls.Add(this.BtnAnd);
            this.PLayOut.Controls.Add(this.BtnExit);
            this.PLayOut.Controls.Add(this.BtnDelete);
            this.PLayOut.Controls.Add(this.BtnClear);
            this.PLayOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PLayOut.Location = new System.Drawing.Point(0, 228);
            this.PLayOut.Margin = new System.Windows.Forms.Padding(0);
            this.PLayOut.Name = "PLayOut";
            this.PLayOut.Padding = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.PLayOut.Size = new System.Drawing.Size(354, 26);
            this.PLayOut.TabIndex = 1;
            // 
            // BtnOr
            // 
            this.BtnOr.BackColor = System.Drawing.SystemColors.MenuBar;
            this.BtnOr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnOr.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnOr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOr.Image = global::Vietsoft.Properties.Resources.Filter1;
            this.BtnOr.Location = new System.Drawing.Point(212, 1);
            this.BtnOr.Margin = new System.Windows.Forms.Padding(0);
            this.BtnOr.Name = "BtnOr";
            this.BtnOr.Size = new System.Drawing.Size(70, 23);
            this.BtnOr.TabIndex = 4;
            this.BtnOr.Text = "&Or";
            this.BtnOr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOr.UseVisualStyleBackColor = false;
            // 
            // BtnAnd
            // 
            this.BtnAnd.BackColor = System.Drawing.SystemColors.MenuBar;
            this.BtnAnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnAnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnAnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAnd.Image = global::Vietsoft.Properties.Resources.Filter1;
            this.BtnAnd.Location = new System.Drawing.Point(142, 1);
            this.BtnAnd.Margin = new System.Windows.Forms.Padding(0);
            this.BtnAnd.Name = "BtnAnd";
            this.BtnAnd.Size = new System.Drawing.Size(70, 23);
            this.BtnAnd.TabIndex = 3;
            this.BtnAnd.Text = "&And";
            this.BtnAnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAnd.UseVisualStyleBackColor = false;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.SystemColors.MenuBar;
            this.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Image = global::Vietsoft.Properties.Resources.Delete;
            this.BtnExit.Location = new System.Drawing.Point(282, 1);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(0);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(70, 23);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "&Exit";
            this.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExit.UseVisualStyleBackColor = false;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.SystemColors.MenuBar;
            this.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Image = global::Vietsoft.Properties.Resources.Delete;
            this.BtnDelete.Location = new System.Drawing.Point(72, 1);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(70, 23);
            this.BtnDelete.TabIndex = 1;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDelete.UseVisualStyleBackColor = false;
            // 
            // BtnClear
            // 
            this.BtnClear.BackColor = System.Drawing.SystemColors.MenuBar;
            this.BtnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.Image = global::Vietsoft.Properties.Resources.Clear;
            this.BtnClear.Location = new System.Drawing.Point(2, 1);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(0);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(70, 23);
            this.BtnClear.TabIndex = 0;
            this.BtnClear.Text = "&Clear";
            this.BtnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnClear.UseVisualStyleBackColor = false;
            // 
            // TxtVFilter
            // 
            this.TxtVFilter.CharLength = 32700;
            this.TxtVFilter.DataType = 6;
            this.TxtVFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtVFilter.Location = new System.Drawing.Point(137, 27);
            this.TxtVFilter.Margin = new System.Windows.Forms.Padding(2);
            this.TxtVFilter.Name = "TxtVFilter";
            this.TxtVFilter.Size = new System.Drawing.Size(215, 22);
            this.TxtVFilter.StringFormat = "";
            this.TxtVFilter.TabIndex = 2;
            // 
            // BtnTitle
            // 
            this.BtnTitle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TlbLayOut.SetColumnSpan(this.BtnTitle, 2);
            this.BtnTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnTitle.Enabled = false;
            this.BtnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnTitle.Image = global::Vietsoft.Properties.Resources.Filter1;
            this.BtnTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTitle.Location = new System.Drawing.Point(0, 0);
            this.BtnTitle.Margin = new System.Windows.Forms.Padding(0);
            this.BtnTitle.Name = "BtnTitle";
            this.BtnTitle.Size = new System.Drawing.Size(354, 25);
            this.BtnTitle.TabIndex = 3;
            this.BtnTitle.Text = "Filter";
            this.BtnTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTitle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnTitle.UseVisualStyleBackColor = false;
            // 
            // DgvTFilter
            // 
            this.DgvTFilter.AllowUserToAddRows = false;
            this.DgvTFilter.AllowUserToDeleteRows = false;
            this.DgvTFilter.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DgvTFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTFilter.ColumnHeadersVisible = false;
            this.DgvTFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTFilter.Location = new System.Drawing.Point(2, 51);
            this.DgvTFilter.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.DgvTFilter.Name = "DgvTFilter";
            this.DgvTFilter.ReadOnly = true;
            this.DgvTFilter.RowHeadersVisible = false;
            this.DgvTFilter.RowHeadersWidth = 30;
            this.DgvTFilter.Size = new System.Drawing.Size(131, 176);
            this.DgvTFilter.TabIndex = 4;
            this.DgvTFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvTFilter_KeyDown);
            this.DgvTFilter.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTFilter_CellDoubleClick);
            this.DgvTFilter.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvTFilter_ColumnAdded);
            // 
            // DataGridViewFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.TlbLayOut);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(356, 256);
            this.MinimumSize = new System.Drawing.Size(356, 256);
            this.Name = "DataGridViewFilter";
            this.Size = new System.Drawing.Size(354, 254);
            this.TlbLayOut.ResumeLayout(false);
            this.TlbLayOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVFilter)).EndInit();
            this.PLayOut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlbLayOut;
        private MaskedEditor TxtTFilter;
        private System.Windows.Forms.Panel PLayOut;
        private MaskedEditor TxtVFilter;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnAnd;
        private System.Windows.Forms.Button BtnOr;
        private System.Windows.Forms.Button BtnTitle;
        private System.Windows.Forms.DataGridView DgvVFilter;
        private System.Windows.Forms.DataGridView DgvTFilter;        
    }
}
