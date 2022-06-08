
--EXEC sp_ThongTinPT 'AIC-0001','01.01.03',0
ALTER procedure [dbo].[sp_ThongTinPT]
	@MS_MAY Nvarchar(30),
	@MS_BO_PHAN nvarchar(30),
	@NNGU int
AS

SELECT T2.MS_PT,MIN(T2.DON_GIA * T2.TY_GIA) AS DGVND_MIN,MAX(T2.DON_GIA *  T2.TY_GIA) AS DGVND_MAX INTO #TEMTP FROM dbo.IC_DON_HANG_NHAP T1 INNER JOIN dbo.IC_DON_HANG_NHAP_VAT_TU T2 ON T2.MS_DH_NHAP_PT = T1.MS_DH_NHAP_PT WHERE T1.MS_DANG_NHAP =2
GROUP BY T2.MS_PT

SELECT     dbo.IC_PHU_TUNG.MS_PT,MS_VI_TRI_PT,dbo.IC_PHU_TUNG.MS_PT_CTY,
			 TEN_PT,dbo.IC_PHU_TUNG.MS_PT_NCC,CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG, 
			SL_TON,DGVND_MIN,DGVND_MAX,
            CASE @NNgu WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS DVT,TUOI_THO,dbo.IC_PHU_TUNG.QUY_CACH,CAU_TRUC_THIET_BI_PHU_TUNG.CHUC_NANG,
			dbo.IC_PHU_TUNG.TEN_PT_VIET,CAU_TRUC_THIET_BI_PHU_TUNG.ACTIVE,
			dbo.IC_PHU_TUNG.MS_PT + MS_VI_TRI_PT AS PTVT
FROM         dbo.CAU_TRUC_THIET_BI INNER JOIN
                      dbo.CAU_TRUC_THIET_BI_PHU_TUNG ON dbo.CAU_TRUC_THIET_BI.MS_MAY = dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY AND 
                      dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN INNER JOIN
                      dbo.IC_PHU_TUNG ON dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN 
                      DON_VI_TINH ON IC_PHU_TUNG.DVT=DON_VI_TINH.DVT LEFT JOIN 
                      (SELECT MS_PT,SUM(SL_VT) AS SL_TON FROM VI_TRI_KHO_VAT_TU GROUP BY MS_PT) SLT ON 
                      dbo.IC_PHU_TUNG.MS_PT = SLT.MS_PT 
					  LEFT JOIN #TEMTP ON #TEMTP.MS_PT = IC_PHU_TUNG.MS_PT
WHERE dbo.CAU_TRUC_THIET_BI.MS_MAY = @MS_MAY 
	AND dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN=@MS_BO_PHAN
	



