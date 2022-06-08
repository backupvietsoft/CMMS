using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using System.IO;

namespace ReportMain
{
    public partial class ucGiayPhepCatHan : UserControl
    {
        public string ms;
        public Int64 id;
        public ucGiayPhepCatHan(string s, Int64 idsp)
        {
            InitializeComponent();
            ms = s;
            id = idsp;
        }
        private void ucGiayPhepCatHan_Load(object sender, EventArgs e)
        {
            foreach (Control item in tableLayoutPanel1.Controls)
            {
                if (item.GetType().Name.ToString() == "LabelControl")
                {
                    item.Text = Commons.Modules.GetNNgu("frmKhuVucGioiHan", item.Name);
                }
            }
            //bing ding dữ liệu
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT Col1, Col2, Col3, Col4,Col5, Col6, Col7, Col8, Col9 FROM dbo.GIAY_PHEP WHERE ID = " + id + ""));
            if (dt.Rows.Count == 0) return;
            txtKhuVuc2.Text = dt.Rows[0][1].ToString();
            txtTang3.Text = dt.Rows[0][2].ToString();
            txtLoaiCV4.Text = dt.Rows[0][3].ToString();
            txtTenNT5.Text = dt.Rows[0][4].ToString();
            txtNguoiKT6.Text = dt.Rows[0][5].ToString();
            txtNVKT9.Text = dt.Rows[0][8].ToString();
            try
            {
                datNgay1.DateTime = Convert.ToDateTime(dt.Rows[0][0]);
            }
            catch { }
            try
            {
                DatBD7.DateTime = Convert.ToDateTime(dt.Rows[0][6]);
            }
            catch {}
            try
            {
                datKT8.DateTime = Convert.ToDateTime(dt.Rows[0][7]);
            }
            catch { }
        }
        public void UpdateIn(Int64 IDGP)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.GIAY_PHEP SET Col1 = N'" + datNgay1.Text + "',Col2 = N'" + txtKhuVuc2.Text + "',Col3 = N'" + txtTang3.Text + "',Col4 =N'" + txtLoaiCV4.Text + " ',Col5 = N'" + txtTenNT5.Text + " ',Col6 = N'" + txtNguoiKT6.Text + "',Col7 =N'" + DatBD7.Text + "',Col8=N'" + datKT8.Text + "',Col9 = N'" + txtNVKT9.Text + "' WHERE ID =" + IDGP + "");
            }
            catch
            {
            }
        }
        public void IN (string sFile)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            object missing = System.Type.Missing;
            try
            {
                object fileName = Application.StartupPath + Path.DirectorySeparatorChar + @"\Templete\GP_CH.doc";
                doc = word.Documents.Open(ref fileName,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing);
                doc.Activate();
                Commons.Modules.ObjSystems.WordReplace(doc, "<So>", ms);
                Commons.Modules.ObjSystems.WordReplace(doc, "<Ngay>", datNgay1.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<KhuVuc>", txtKhuVuc2.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<Tang>", txtTang3.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<LoaiCV>", txtLoaiCV4.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<TenNV>", txtTenNT5.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<NguoiChoPhep>",txtNguoiKT6.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<BatDau>", DatBD7.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<KetThuc>", datKT8.Text);
                Commons.Modules.ObjSystems.WordReplace(doc, "<NVKT>",txtNVKT9.Text);
                doc.SaveAs(sFile, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                doc.Close(ref missing, ref missing, ref missing);
                word.Application.Quit(ref missing, ref missing, ref missing);
                System.Diagnostics.Process.Start(sFile);
            }
            catch (Exception ex)
            {
                doc.Close(ref missing, ref missing, ref missing);
                word.Application.Quit(ref missing, ref missing, ref missing);
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
