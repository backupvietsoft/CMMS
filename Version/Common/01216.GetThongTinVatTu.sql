--EXEC GetThongTinVatTu -1, N'',0,'ADMIN','',N''

ALTER procedure [dbo].[GetThongTinVatTu]
	@LOAI INT,
	@GIA_TRI NVARCHAR(150),
	@Type int,
	@USERNAME NVARCHAR(50),
	@GT_MSPT NVARCHAR(150),
	@GT_TPT NVARCHAR(150)
AS

SELECT DISTINCT  TMP1.MS_PT,TMP1.MS_PT_CTY,TMP1.MS_PT_NCC,  TEN_PT, QUY_CACH , TMP1.MS_DH_NHAP_PT, NGAY, TMP1.TEN_LOAI_VT,
			TMP1.MS_KHO, TMP1.TEN_KHO,TMP1.MS_VI_TRI,  TMP1.TEN_VI_TRI, 
			TMP1.SL_VT,DON_GIA,TEN_NGOAI_TE,XUAT_XU,TMP1.TEN_HSX,TMP1.BAO_HANH_DEN_NGAY, TMP1.ID , TMP1.GHI_CHU
FROM ( 
	SELECT DISTINCT C.MS_PT, TEN_PT, QUY_CACH ,C.MS_DH_NHAP_PT, CASE @Type WHEN 0 THEN T2.TEN_LOAI_VT_TV ELSE T2.TEN_LOAI_VT_TA END TEN_LOAI_VT, C.MS_KHO, E.TEN_KHO, C.MS_VI_TRI, F.TEN_VI_TRI, 
			C.SL_VT, D.MS_PT_NCC, D.MS_PT_CTY, A.BAO_HANH_DEN_NGAY, C.ID, A.DON_GIA, I.TEN_NGOAI_TE, 
			A.XUAT_XU,T1.TEN_HSX, X.NGAY, CASE D.THEO_KHO WHEN 1 THEN (SELECT GHI_CHU FROM IC_PHU_TUNG_KHO WHERE MS_KHO = E.MS_KHO AND MS_PT = D.MS_PT) ELSE '' END GHI_CHU
	FROM dbo.NGOAI_TE AS I INNER JOIN
			  dbo.IC_DON_HANG_NHAP_VAT_TU AS A ON I.NGOAI_TE = A.NGOAI_TE INNER JOIN
			  IC_PHU_TUNG AS D INNER JOIN
			  dbo.VI_TRI_KHO_VAT_TU AS C ON D.MS_PT = C.MS_PT INNER JOIN
			  dbo.IC_KHO AS E ON C.MS_KHO = E.MS_KHO INNER JOIN
			  dbo.VI_TRI_KHO AS F ON C.MS_VI_TRI = F.MS_VI_TRI INNER JOIN
			  dbo.NHOM_KHO AS G ON E.MS_KHO = G.MS_KHO INNER JOIN
			  dbo.USERS AS H ON G.GROUP_ID = H.GROUP_ID ON A.MS_DH_NHAP_PT = C.MS_DH_NHAP_PT AND A.MS_PT = C.MS_PT AND A.ID = C.ID  
			  LEFT OUTER JOIN dbo.HANG_SAN_XUAT AS T1 ON D.MS_HSX = T1.MS_HSX
			  LEFT JOIN dbo.LOAI_VT AS T2 ON T2.MS_LOAI_VT = D.MS_LOAI_VT
			
			  INNER JOIN dbo.IC_DON_HANG_NHAP AS X ON A.MS_DH_NHAP_PT = X.MS_DH_NHAP_PT 
	WHERE     (C.SL_VT > 0) AND (H.USERNAME = @USERNAME) 
UNION ALL
	SELECT MS_PT, TEN_PT, QUY_CACH, NULL AS MS_DH_NHAP_PT, CASE @Type WHEN 0 THEN T2.TEN_LOAI_VT_TV ELSE T2.TEN_LOAI_VT_TA END TEN_LOAI_VT, NULL AS MS_KHO, NULL AS TEN_KHO, 
			NULL AS MS_VI_TRI, NULL AS TEN_VI_TRI, 0 AS SL_VT, MS_PT_NCC, MS_PT_CTY, 
			NULL AS BAO_HANH_DEN_NGAY, 0 AS ID, 0 AS DON_GIA,NULL AS TEN_NGOAI_TE, 
			NULL AS XUAT_XU,T1.TEN_HSX, NULL AS NGAY, CASE D.THEO_KHO WHEN 1 THEN (SELECT TOP 1 GHI_CHU FROM IC_PHU_TUNG_KHO WHERE  MS_PT = D.MS_PT) ELSE '' END GHI_CHU
	FROM IC_PHU_TUNG AS D LEFT JOIN HANG_SAN_XUAT AS T1 ON D.MS_HSX = T1.MS_HSX
	LEFT JOIN dbo.LOAI_VT AS T2 ON T2.MS_LOAI_VT = D.MS_LOAI_VT

	WHERE (MS_PT NOT IN	(SELECT MS_PT FROM dbo.VI_TRI_KHO_VAT_TU WHERE (SL_VT > 0))) 
) TMP1
ORDER BY MS_PT, MS_DH_NHAP_PT, TEN_KHO
		
