using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing;

namespace ImportExcels
{
    public partial class frmTest : DevExpress.XtraEditors.XtraForm
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            ImportExcels.UserControl.ucHCKD myUc = new ImportExcels.UserControl.ucHCKD();
            myUc.Location = new Point(0, 0);
            myUc.Dock = DockStyle.Fill;
            this.Controls.Add(myUc);
            Commons.Modules.ObjSystems.ThayDoiNN(myUc, this.Name);


            //string sSql = "Select * from may";
            //System.Data.DataTable dtTmp = new System.Data.DataTable();
            //dtTmp.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
            //            CommandType.Text, sSql));
            //Spire.Xls.Workbook book = new Spire.Xls.Workbook();
            //Spire.Xls.Worksheet sheet = book.Worksheets[0];
            //Spire.Xls.Worksheet sheet1 = book.Worksheets[1];
            //sheet.InsertDataTable(dtTmp, true, 1, 1);
            //sheet1.InsertDataTable(dtTmp, true, 1, 1);
            //book.SaveToFile("D:\\test.xlsX");
            //System.Diagnostics.Process.Start("D:\\test.xlsX");
        }
        private static string _sNNgu = String.Empty;

        public static string sNNgu
        {
            get
            {
                return _sNNgu;
            }
            set
            {
                _sNNgu = value;
            }
        }

        public class XtraInputBox
        {

            private static XtraForm Formulario = new XtraForm();
            private static DevExpress.XtraEditors.SimpleButton cmdAceptar;
            private static DevExpress.XtraEditors.TextEdit txtResultado;
            private static DevExpress.XtraEditors.LabelControl lblPrompt;
            private static DevExpress.XtraEditors.SimpleButton cmdCancelar;


            private static void InitializeComponent()
            {
                txtResultado = new DevExpress.XtraEditors.TextEdit();
                cmdAceptar = new DevExpress.XtraEditors.SimpleButton();
                lblPrompt = new DevExpress.XtraEditors.LabelControl();
                cmdCancelar = new DevExpress.XtraEditors.SimpleButton();
                ((System.ComponentModel.ISupportInitialize)txtResultado.Properties).BeginInit();
                Formulario.SuspendLayout();
                //
                //txtResultado
                //
                txtResultado.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
                txtResultado.Location = new System.Drawing.Point(12, 31);
                txtResultado.Name = "txtResultado";
                txtResultado.Size = new System.Drawing.Size(375, 20);
                txtResultado.TabIndex = 0;
                //
                //cmdAceptar
                //
                cmdAceptar.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
                cmdAceptar.DialogResult = DialogResult.OK;
                cmdAceptar.Location = new System.Drawing.Point(231, 57);
                cmdAceptar.Name = "cmdAceptar";
                cmdAceptar.Size = new System.Drawing.Size(75, 23);
                cmdAceptar.TabIndex = 1;
                cmdAceptar.Text = "&Aceptar";

                cmdAceptar.Click += cmdAceptar_Click;
                //
                //lblPrompt
                //
                lblPrompt.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                lblPrompt.Location = new System.Drawing.Point(12, 12);
                lblPrompt.Name = "lblPrompt";
                lblPrompt.Size = new System.Drawing.Size(42, 13);
                lblPrompt.TabIndex = 2;
                lblPrompt.Text = "prompt";
                //
                //cmdCancelar
                //
                cmdCancelar.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
                cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                cmdCancelar.Location = new System.Drawing.Point(312, 57);
                cmdCancelar.Name = "cmdCancelar";
                cmdCancelar.Size = new System.Drawing.Size(75, 23);
                cmdCancelar.TabIndex = 3;
                cmdCancelar.Text = "&Cancelar";
                //
                //XtraInputBox
                //
                Formulario.AcceptButton = cmdAceptar;
                Formulario.CancelButton = cmdCancelar;
                Formulario.ClientSize = new System.Drawing.Size(399, 91);
                Formulario.Controls.Add(lblPrompt);
                Formulario.Controls.Add(cmdCancelar);
                Formulario.Controls.Add(cmdAceptar);
                Formulario.Controls.Add(txtResultado);
                Formulario.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                Formulario.HelpButton = true;
                Formulario.MaximizeBox = false;
                Formulario.MinimizeBox = false;
                Formulario.Name = "XtraInputBox";
                Formulario.ShowInTaskbar = false;
                Formulario.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                ((System.ComponentModel.ISupportInitialize)txtResultado.Properties).EndInit();
                Formulario.ResumeLayout(false);
                Formulario.PerformLayout();
            }

            public XtraInputBox()
            {
                InitializeComponent();
                cmdAceptar.Click += new System.EventHandler(cmdAceptar_Click);
            }

            private static void cmdAceptar_Click(object sender, System.EventArgs e)
            {
                Formulario.Close();
            }

            public static string Show(string Prompt)
            {
                return Show(Prompt, Application.ProductName).ToString();
            }

            public static object Show(string Prompt, string Title)
            {
                return Show(Prompt, Title, "");
            }

            public static object Show(string Prompt, string Title, string DefaultResponse)
            {
                return Show(Prompt, Title, DefaultResponse, -1);
            }

            public static object Show(string Prompt, string Title, string DefaulResponse, int XPos)
            {
                return Show(Prompt, Title, DefaulResponse, XPos, -1);
            }

            public static string Show(string Prompt, string Title, string DefaultResponse, int XPos, int YPos)
            {
                //(Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2)
                //(Screen.PrimaryScreen.WorkingArea.Height / 2) - (Me.Height / 2)

                InitializeComponent();

                lblPrompt.Text = Prompt;
                Formulario.Text = Title;
                Formulario.Top = XPos;
                Formulario.Left = YPos;
                DialogResult res = Formulario.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    return txtResultado.Text;
                }
                else
                {
                    return DefaultResponse;
                }
            }


        }
        private void btnFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            String sLoi = "";
            Vietsoft.Information.UserID = "admin";
            Vietsoft.MCapNhapNgonNguAnhHoa.Update("sssss", "NGUYEN_NHAN_DUNG_MAY", "TEN_NGUYEN_NHAN_ANH", " WHERE MS_NGUYEN_NHAN = 100 ", out sLoi, "FrmDiChuyenThietBi");



            
            Vietsoft.Information.UserID = "admin";
            Vietsoft.MCapNhapNgonNguAnhHoa.Update("sdfsdfsdfsdfsdfsdfsd", "NGUYEN_NHAN_DUNG_MAY", "TEN_NGUYEN_NHAN_ANH", " WHERE MS_NGUYEN_NHAN = 100 ", out sLoi, "FrmDiChuyenThietBi");


        }// FROM 
    }
}