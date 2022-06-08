
ALTER VIEW [dbo].[View_GT_DH_XUAT]
AS
SELECT        T1.MS_DH_XUAT_PT, SUM(T1.SL_VT * T2.DON_GIA * T2.TY_GIA) AS GIA_TRI
FROM            dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS T1 INNER JOIN
                         dbo.IC_DON_HANG_NHAP_VAT_TU AS T2 ON T1.MS_DH_NHAP_PT = T2.MS_DH_NHAP_PT AND T1.MS_PT = T2.MS_PT AND T1.ID_XUAT = T2.ID
GROUP BY T1.MS_DH_XUAT_PT


