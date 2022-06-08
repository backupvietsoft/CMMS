
--SP_get_slmaxtra 'PN-1703-0031', 'PX-1702-0238', 'T3860118304'

ALTER procedure [dbo].[SP_GET_SLMAXTRA]
@MS_DH_NHAP_PT NVARCHAR (14),
@MS_DH_XUAT_PT	nvarchar(14),
@MS_PT NVARCHAR (25)

AS
BEGIN
SELECT DISTINCT ISNULL(A_1.SLX, 0) - (ISNULL(B.SLBT, 0) + ISNULL(C.SLN, 0)) AS SLCL
FROM          (SELECT DISTINCT  IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT, T.MS_PT, T.MS_DH_NHAP_PT , SL_VT AS SLX
                      , ID_XUAT FROM dbo.IC_DON_HANG_XUAT_VAT_TU INNER JOIN IC_DON_HANG_XUAT_VAT_TU_CHI_TIET T ON
                       T.MS_DH_XUAT_PT = IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT 
                       GROUP BY IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT, T.MS_PT,T.MS_DH_NHAP_PT ,ID_XUAT, SL_VT)                                              
                        AS A_1  LEFT OUTER JOIN
                        
               (SELECT     MS_DH_XUAT_PT, MS_PT, ISNULL(SUM(SL_TT), 0) AS SLBT
                                                         FROM          dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO
                                                         GROUP BY MS_DH_XUAT_PT, MS_PT) AS B ON A_1.MS_DH_XUAT_PT = B.MS_DH_XUAT_PT AND A_1.MS_PT = B.MS_PT LEFT OUTER JOIN
                                                      
               ( SELECT     IC_DON_HANG_NHAP_1.MS_DHX, IC_DON_HANG_NHAP_VAT_TU_1.MS_PT, 
   IC_DON_HANG_NHAP_VAT_TU_1.MS_DH_NHAP_PT_GOC,  SUM(t1.SL_VT) AS SLN
  FROM          dbo.IC_DON_HANG_NHAP AS IC_DON_HANG_NHAP_1 INNER JOIN
 dbo.IC_DON_HANG_NHAP_VAT_TU AS IC_DON_HANG_NHAP_VAT_TU_1 ON 
    IC_DON_HANG_NHAP_1.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU_1.MS_DH_NHAP_PT
inner join IC_DON_HANG_NHAP_VAT_TU_CHI_TIET T1 on  T1.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU_1.MS_DH_NHAP_PT and IC_DON_HANG_NHAP_VAT_TU_1.MS_PT = t1.MS_PT 
  WHERE      (ISNULL(IC_DON_HANG_NHAP_1.MS_DHX, N'') <> '') AND IC_DON_HANG_NHAP_1.MS_DH_NHAP_PT <> @MS_DH_NHAP_PT
 GROUP BY IC_DON_HANG_NHAP_1.MS_DHX, IC_DON_HANG_NHAP_VAT_TU_1.MS_PT,  IC_DON_HANG_NHAP_VAT_TU_1.MS_DH_NHAP_PT_GOC)
  AS C ON A_1.MS_DH_XUAT_PT = C.MS_DHX AND A_1.MS_PT = C.MS_PT and  a_1.MS_DH_NHAP_PT = c.MS_DH_NHAP_PT_GOC
  

WHERE      (ISNULL(A_1.SLX, 0) - (ISNULL(B.SLBT, 0) + ISNULL(C.SLN, 0)) > 0) AND (A_1.MS_DH_XUAT_PT = @MS_DH_XUAT_PT)
AND A_1.MS_PT = @MS_PT
	
END
