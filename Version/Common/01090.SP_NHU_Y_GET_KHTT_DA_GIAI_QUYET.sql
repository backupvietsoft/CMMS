
--EXEC SP_NHU_Y_GET_KHTT_DA_GIAI_QUYET '-1','-1','-1','ADMINISTRATOR', '08/01/2014', '01/01/2017','-1',-1

ALTER PROC [dbo].[SP_NHU_Y_GET_KHTT_DA_GIAI_QUYET]
	@MS_LOAI_MAY NVARCHAR(50),
	@MS_NHOM_MAY NVARCHAR(50),
	@MS_MAY NVARCHAR(50),
	@USERNAME NVARCHAR(50),
	@TU_NGAY DATETIME,
	@DEN_NGAY DATETIME ,
	@MS_NHA_XUONG NVARCHAR(50),
	@MS_HE_THONG INT
AS


SELECT DISTINCT TEN_MAY, MS_MAY INTO #TMP2 FROM dbo.MGetMayUserNgay(@DEN_NGAY, @USERNAME, @MS_NHA_XUONG, @MS_HE_THONG, -1, @MS_LOAI_MAY, @MS_NHOM_MAY,@MS_MAY, 0) A 

SELECT * INTO #KHTT FROM KE_HOACH_TONG_THE
	WHERE (CONVERT(DATETIME, CONVERT(NVARCHAR(10), NGAY, 103), 103) BETWEEN @TU_NGAY AND @DEN_NGAY)

SELECT SUM(ISNULL(THOI_GIAN_DU_KIEN,0)) AS TONG_TG, T1.HANG_MUC_ID INTO #TGIAN
FROM #KHTT T1 INNER JOIN 
KE_HOACH_TONG_CONG_VIEC T2 ON T1.HANG_MUC_ID = T2.HANG_MUC_ID AND T1.MS_MAY = T2.MS_MAY
WHERE  ((MS_PHIEU_BAO_TRI IS NOT NULL) AND (CONVERT(DATETIME, CONVERT(NVARCHAR(10), NGAY, 103), 103) BETWEEN @TU_NGAY AND @DEN_NGAY)) 
OR ( (CONVERT(DATETIME, CONVERT(NVARCHAR(10), NGAY, 103), 103) BETWEEN @TU_NGAY AND @DEN_NGAY) AND (EOR_ID IS NOT NULL))
GROUP BY T1.HANG_MUC_ID

       
SELECT DISTINCT  CONVERT(bit,0) as Choose, CONVERT(int,0) as RecordAction, TEMP.MS_MAY, TEN_MAY, TEMP.TEN_HANG_MUC, TEMP.HANG_MUC_ID, TEMP.NGAY, TEMP.NGAY_DK_HT, TEMP.GHI_CHU, 
TEMP.MS_LOAI_BT, TEMP.NGAY_BTPN, TEMP.LY_DO_SC, TEMP.MS_CACH_TH, TEMP.USERNAME,TEMP.MS_UU_TIEN,  CONVERT(NVARCHAR(50),MS_CN_PT) AS MS_CONG_NHAN
	,dbo.GetThongSoYCSD(TEMP.HANG_MUC_ID,1) AS YC_CHUNG,
	dbo.GetThongSoYCSD(TEMP.HANG_MUC_ID,2) AS	YC_MO_TA,
	dbo.GetThongSoYCSD(TEMP.HANG_MUC_ID,3) AS	YC,
	ISNULL(T2.TONG_TG,0) AS TONG_THOI_GIAN,
	TEMP.NGAY as NGAY_OLD, TEMP.NGAY_DK_HT  as NGAY_KT_OLD,  NGAY_BTDK_GOC
	
FROM #KHTT TEMP INNER JOIN
      dbo.KE_HOACH_TONG_CONG_VIEC AS KHTCV ON TEMP.MS_MAY = KHTCV.MS_MAY AND 
      TEMP.HANG_MUC_ID = KHTCV.HANG_MUC_ID INNER JOIN #TMP2 T1 ON TEMP.MS_MAY = T1.MS_MAY 
	  LEFT JOIN #TGIAN T2 ON TEMP.HANG_MUC_ID = T2.HANG_MUC_ID
WHERE      ((KHTCV.MS_PHIEU_BAO_TRI IS NOT NULL) AND (CONVERT(DATETIME, CONVERT(NVARCHAR(10), TEMP.NGAY, 103), 103) BETWEEN @TU_NGAY AND @DEN_NGAY)) 
OR ( (CONVERT(DATETIME, CONVERT(NVARCHAR(10), TEMP.NGAY, 103), 103) BETWEEN @TU_NGAY AND @DEN_NGAY) AND (KHTCV.EOR_ID IS NOT NULL))
ORDER BY HANG_MUC_ID DESC