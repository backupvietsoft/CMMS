using System;
using System.Collections.Generic;
using System.Text;

namespace PhucHoiDLKho.Class
{
    class Class1
    {
    }
}

//for (int i = 0; i < vData.Rows.Count; i++)
//            {
//                DataRow vr = vData.Rows[i];
//                if (vr["LOAI"].ToString().Equals("N"))//nếu là phiếu nhập
//                {
//                    string sqlChiTietDH = "SELECT  dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN, dbo.NHAP_NPL_CHI_TIET_IC.MS_VT, dbo.NHAP_NPL_CHI_TIET_IC.MAU_VT, " +
//                      " dbo.NHAP_NPL_CHI_TIET_IC.KHO_VT, dbo.NHAP_NPL_CHI_TIET_IC.DVT, dbo.NHAP_NPL_VI_TRI_IC.MS_VI_TRI, " +
//                      " dbo.NHAP_NPL_VI_TRI_IC.SO_LUONG, dbo.NHAP_NPL_CHI_TIET_IC.SLTN " +
//                      " FROM  dbo.NHAP_NPL_CHI_TIET_IC INNER JOIN " +
//                      " dbo.NHAP_NPL_VI_TRI_IC ON dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN = dbo.NHAP_NPL_VI_TRI_IC.MS_DHN AND " +
//                      " dbo.NHAP_NPL_CHI_TIET_IC.MS_VT = dbo.NHAP_NPL_VI_TRI_IC.MS_VT AND " +
//                      " dbo.NHAP_NPL_CHI_TIET_IC.MAU_VT = dbo.NHAP_NPL_VI_TRI_IC.MAU_VT AND " +
//                      " dbo.NHAP_NPL_CHI_TIET_IC.KHO_VT = dbo.NHAP_NPL_VI_TRI_IC.KHO_VT AND " +
//                      " dbo.NHAP_NPL_CHI_TIET_IC.DVT = dbo.NHAP_NPL_VI_TRI_IC.DVT " +
//                      " WHERE (dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN = '" + vr["DON_HANG"].ToString() + "')";
                                   
//                    DataTable vDHInfo = new DataTable();
//                    vDHInfo.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, sqlChiTietDH));

//                    DataTable vDHChiTiet = new DataTable();

//                    vDHChiTiet = vDHInfo.DefaultView.ToTable(true, "MS_DHN", "MS_VT", "MAU_VT", "KHO_VT","DVT","SLTN");

//                    foreach (DataRow vrowCT in vDHChiTiet.Rows)
//                    {
//                        DataView dtChiTietVT = new DataView(vDHInfo, "MS_DHN = '" + vrowCT["MS_DHN"].ToString() +
//                        "' AND MS_VT = '" + vrowCT["MS_VT"].ToString() + "' AND  MAU_VT = '" + vrowCT["MAU_VT"].ToString() +
//                        "' AND KHO_VT = '" + vrowCT["KHO_VT"].ToString() + "' AND DVT = '" + vrowCT["DVT"].ToString() + "'", "MS_VI_TRI", DataViewRowState.CurrentRows);

//                        int stt = 0;
//                        float TongTrenVT = 0;
//                        foreach (DataRow vrowVT in dtChiTietVT.ToTable().Rows)
//                        {
//                            TongTrenVT = TongTrenVT + float.Parse(vrowVT["SO_LUONG"].ToString());
//                            stt++;
//                            if (stt != dtChiTietVT.ToTable().Rows.Count)
//                            {
//                                // them vao vi tri kho vat tu ( vi tri n -1 )
//                                string vIS_VitriKhoVT = "INSERT INTO dbo.VI_TRI_KHO_VAT_TU (MS_DHN, MS_VT, MAU_VT, KHO_VT, DVT, MS_KHO, MS_VI_TRI, SO_LUONG) " +
//                                  " VALUES ('" +vrowVT["MS_DHN"].ToString() + "','" + vrowVT["MS_VT"].ToString() + "','" + vrowVT["MAU_VT"].ToString() +
//                                  "','" + vrowVT["KHO_VT"].ToString() + "','" + vrowVT["DVT"].ToString() + "','" + _Kho + "','" + vrowVT["MS_VI_TRI"].ToString() + "','" + vrowVT["SO_LUONG"].ToString() + "')";
//                                SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vIS_VitriKhoVT);
//                            }
//                        }

//                        if (float.Parse(vrowCT["SLTN"].ToString()) != TongTrenVT)
//                        {
//                            float slMoi = float.Parse(dtChiTietVT.ToTable().Rows[stt-1]["SO_LUONG"].ToString()) + (float.Parse(vrowCT["SLTN"].ToString()) - TongTrenVT);

//                            string sqlCNVitri = "UPDATE dbo.NHAP_NPL_VI_TRI_IC SET  SO_LUONG = ROUND(" + slMoi + ",2) WHERE MS_DHN = '" + vrowCT["MS_DHN"].ToString() +
//                                 "' AND MS_VT = '" + vrowCT["MS_VT"].ToString() + "' AND  MAU_VT = '" + vrowCT["MAU_VT"].ToString() +
//                                 "' AND KHO_VT = '" + vrowCT["KHO_VT"].ToString() + "' AND DVT = '" + vrowCT["DVT"].ToString() + "' AND MS_VI_TRI = '" + dtChiTietVT.ToTable().Rows[stt-1]["MS_VI_TRI"].ToString() + "'";
//                            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlCNVitri);

//                            // them vao vi tri kho vat tu (vi tri cuoi)
//                            string vIS_VitriKhoVT = "INSERT INTO dbo.VI_TRI_KHO_VAT_TU (MS_DHN, MS_VT, MAU_VT, KHO_VT, DVT, MS_KHO, MS_VI_TRI, SO_LUONG) " +
//                                  " VALUES ('" + vrowCT["MS_DHN"].ToString() + "',N'" + vrowCT["MS_VT"].ToString() + "',N'" + vrowCT["MAU_VT"].ToString() +
//                                  "',N'" + vrowCT["KHO_VT"].ToString() + "',N'" + vrowCT["DVT"].ToString() + "','" + _Kho + "','" + dtChiTietVT.ToTable().Rows[stt-1]["MS_VI_TRI"].ToString() + "','" + slMoi + "')";
//                            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vIS_VitriKhoVT);
//                        }
//                        else
//                        {
//                            // them vao vi tri kho vat tu (vi tri cuoi)
//                            string vIS_VitriKhoVT = "INSERT INTO dbo.VI_TRI_KHO_VAT_TU (MS_DHN, MS_VT, MAU_VT, KHO_VT, DVT, MS_KHO, MS_VI_TRI, SO_LUONG) " +
//                                  " VALUES ('" + vrowCT["MS_DHN"].ToString() + "',N'" + vrowCT["MS_VT"].ToString() + "',N'" + vrowCT["MAU_VT"].ToString() +
//                                  "',N'" + vrowCT["KHO_VT"].ToString() + "',N'" + vrowCT["DVT"].ToString() + "',N'" + _Kho + "','" + dtChiTietVT.ToTable().Rows[stt-1]["MS_VI_TRI"].ToString() + "','" + dtChiTietVT.ToTable().Rows[stt-1]["SO_LUONG"].ToString() + "')";
//                            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vIS_VitriKhoVT);
//                        }
//                    }
//                }
//                if (vr["LOAI"].ToString().Equals("X"))//nếu là phiếu xuất
//                {
//                    string sqlInfoPX = "SELECT MS_DHX , MS_VT, MAU_VT, KHO_VT, DVT, SO_LUONG " +
//                    " FROM dbo.XUAT_NPL_CHI_TIET_IC WHERE MS_DHX = '" + vr["DON_HANG"].ToString() + "'";
//                    DataTable vDHInfo = new DataTable();
//                    vDHInfo.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, sqlInfoPX));
//                    foreach (DataRow vrs in vDHInfo.Rows)
//                    {
//                        string sqlPN = "SELECT dbo.VI_TRI_KHO_VAT_TU.SO_LUONG, dbo.VI_TRI_KHO_VAT_TU.MS_DHN, dbo.VI_TRI_KHO_VAT_TU.MS_VT, dbo.VI_TRI_KHO_VAT_TU.MAU_VT, " +
//                                      " dbo.VI_TRI_KHO_VAT_TU.KHO_VT, dbo.VI_TRI_KHO_VAT_TU.DVT, dbo.VI_TRI_KHO_VAT_TU.MS_KHO, dbo.VI_TRI_KHO_VAT_TU.MS_VI_TRI, " +
//                                      " CONVERT(DATETIME,CONVERT(NVARCHAR(10),dbo.NHAP_NPL_IC.NGAY_NHAP,101)+ ' ' + CONVERT(NVARCHAR(8),dbo.NHAP_NPL_IC.GIO_NHAP,108),101) as NGAY " +
//                                       " , 0 AS SL_MOI " +
//                                      " FROM    dbo.VI_TRI_KHO_VAT_TU INNER JOIN " +
//                                      " dbo.NHAP_NPL_IC ON dbo.VI_TRI_KHO_VAT_TU.MS_DHN = dbo.NHAP_NPL_IC.MS_DHN " +
//                                      " WHERE dbo.VI_TRI_KHO_VAT_TU.MS_VT = '" + vrs["MS_VT"].ToString() + "' AND " +
//                                      " dbo.VI_TRI_KHO_VAT_TU.MAU_VT = '" + vrs["MAU_VT"].ToString() + "' AND dbo.VI_TRI_KHO_VAT_TU.KHO_VT = '" + vrs["KHO_VT"].ToString() + "' AND " +
//                                      " dbo.VI_TRI_KHO_VAT_TU.DVT = '" + vrs["DVT"].ToString() + "'";
//                        DataTable vtbKho = new DataTable();
//                        vtbKho.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString,CommandType.Text,sqlPN));
//                        vtbKho.Columns["SL_MOI"].ReadOnly = false ;

//                        float slXuat = float.Parse(vr["SO_LUONG"].ToString());
//                        int j = 0 ;
//                        foreach (DataRow vrKho in vtbKho.Rows)
//                        {
//                            if (slXuat > 0)
//                            {
//                                if (float.Parse(vrKho["SO_LUONG"].ToString()) > slXuat)
//                                {
//                                    vtbKho.Rows[j]["SL_MOI"] = slXuat;
//                                    slXuat = 0;
//                                }
//                                else
//                                {
//                                    vtbKho.Rows[j]["SL_MOI"] = slXuat - float.Parse(vrKho["SO_LUONG"].ToString());
//                                    slXuat = slXuat - float.Parse(vrKho["SO_LUONG"].ToString());
//                                }
//                            }
//                            else
//                                break;
//                            j ++ ;
//                        }

//                        DataView DataNew = new DataView(vtbKho, "SL_MOI <> 0", "", DataViewRowState.CurrentRows);
//                        foreach (DataRow vrow in DataNew.ToTable().Rows)
//                        {
//                            float vSL = float.Parse(vrow["SO_LUONG"].ToString()) - float.Parse(vrow["SL_MOI"].ToString());
//                            string sqlUD = "UPDATE dbo.VI_TRI_KHO_VAT_TU SET SO_LUONG = '" + vSL + "'" +
//                                " WHERE   MS_DHN = '" + vrow["MS_DHN"].ToString() + "' AND MS_VT ='" + vrow["MS_VT"].ToString() + "' AND " +
//                                " MAU_VT ='" + vrow["MAU_VT"].ToString() + "' AND KHO_VT ='" + vrow["KHO_VT"].ToString() + "' AND " +
//                                " DVT ='" + vrow["DVT"].ToString() + "' AND MS_KHO ='" + vrow["MS_KHO"].ToString() + "' AND MS_VI_TRI ='" + vrow["MS_VI_TRI"].ToString() + "'";
//                            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlUD); 
//                        }
//                    } 
//                }
//                if (vr["LOAI"].ToString().Equals("K"))//nếu là Kiểm kê
//                {

//                }
                

//            }
