namespace ServiceTool
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this._btnStart = new System.Windows.Forms.Button();
            this._btnStop = new System.Windows.Forms.Button();
            this._btnSchedule = new System.Windows.Forms.Button();
            this.btnDBIntegrate = new System.Windows.Forms.Button();
            this.cbxServices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCMMSDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(145, 89);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 23);
            this._btnStart.TabIndex = 0;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _btnStop
            // 
            this._btnStop.Location = new System.Drawing.Point(226, 89);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(75, 23);
            this._btnStop.TabIndex = 2;
            this._btnStop.Text = "Stop";
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this._btnStop_Click);
            // 
            // _btnSchedule
            // 
            this._btnSchedule.Location = new System.Drawing.Point(7, 244);
            this._btnSchedule.Name = "_btnSchedule";
            this._btnSchedule.Size = new System.Drawing.Size(75, 23);
            this._btnSchedule.TabIndex = 3;
            this._btnSchedule.Text = "Schedule";
            this._btnSchedule.UseVisualStyleBackColor = true;
            this._btnSchedule.Click += new System.EventHandler(this._btnSchedule_Click);
            // 
            // btnDBIntegrate
            // 
            this.btnDBIntegrate.Location = new System.Drawing.Point(88, 244);
            this.btnDBIntegrate.Name = "btnDBIntegrate";
            this.btnDBIntegrate.Size = new System.Drawing.Size(117, 23);
            this.btnDBIntegrate.TabIndex = 4;
            this.btnDBIntegrate.Text = "Integration Database";
            this.btnDBIntegrate.UseVisualStyleBackColor = true;
            this.btnDBIntegrate.Click += new System.EventHandler(this.btnDBIntegrate_Click);
            // 
            // cbxServices
            // 
            this.cbxServices.FormattingEnabled = true;
            this.cbxServices.Location = new System.Drawing.Point(98, 52);
            this.cbxServices.Name = "cbxServices";
            this.cbxServices.Size = new System.Drawing.Size(203, 21);
            this.cbxServices.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Service:";
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // btnCMMSDB
            // 
            this.btnCMMSDB.Location = new System.Drawing.Point(211, 244);
            this.btnCMMSDB.Name = "btnCMMSDB";
            this.btnCMMSDB.Size = new System.Drawing.Size(116, 23);
            this.btnCMMSDB.TabIndex = 7;
            this.btnCMMSDB.Text = "CMMS Database";
            this.btnCMMSDB.UseVisualStyleBackColor = true;
            this.btnCMMSDB.Click += new System.EventHandler(this.btnCMMSDB_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 297);
            this.Controls.Add(this.btnCMMSDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxServices);
            this.Controls.Add(this.btnDBIntegrate);
            this.Controls.Add(this._btnSchedule);
            this.Controls.Add(this._btnStop);
            this.Controls.Add(this._btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vietsoft Service Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Button _btnStop;
        private System.Windows.Forms.Button _btnSchedule;
        private System.Windows.Forms.Button btnDBIntegrate;
        private System.Windows.Forms.ComboBox cbxServices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCMMSDB;
    }
}

