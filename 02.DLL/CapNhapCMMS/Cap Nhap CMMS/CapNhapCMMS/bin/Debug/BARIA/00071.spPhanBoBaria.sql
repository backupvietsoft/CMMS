IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spPhanBoBaria')
   exec('CREATE PROCEDURE spPhanBoBaria AS BEGIN SET NOCOUNT ON; END')
GO

--EXEC spPhanBoBaria  N'WO-201511000008' 

ALTER PROC [dbo].[spPhanBoBaria]
	@MsPBT NVARCHAR(50)
AS

DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO WHERE MS_PHIEU_BAO_TRI = @MsPBT

SELECT A.MS_PT, A.SPT, B.SPX, CASE WHEN A.SPT > 1 THEN 1 ELSE 0 END NHIEU INTO #PT
FROM
(
SELECT MS_PT,COUNT(MS_PT) SPT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI =  @MsPBT GROUP BY MS_PT 
) A INNER JOIN 

(SELECT T2.MS_PT, COUNT(T2.MS_PT) AS SPX
	FROM         dbo.IC_DON_HANG_XUAT AS T1 INNER JOIN
						  dbo.IC_DON_HANG_XUAT_VAT_TU AS T2 ON T1.MS_DH_XUAT_PT = T2.MS_DH_XUAT_PT INNER JOIN
						  dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS T3 ON T2.MS_DH_XUAT_PT = T3.MS_DH_XUAT_PT AND T2.MS_PT = T3.MS_PT
	WHERE (T1.MS_PHIEU_BAO_TRI =  @MsPBT) 
GROUP	BY T2.MS_PT
) B ON A.MS_PT = B.MS_PT 
WHERE CASE WHEN A.SPT > 1 THEN 1 ELSE 0 END = 0

UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET SET SL_TT = NULL 
	FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET T1 INNER JOIN #PT T2 ON T1.MS_PT = T2.MS_PT
	WHERE MS_PHIEU_BAO_TRI = @MsPBT AND NHIEU = 0

UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_TT = NULL 
	FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG T1 INNER JOIN #PT T2 ON T1.MS_PT = T2.MS_PT
	WHERE MS_PHIEU_BAO_TRI = @MsPBT AND NHIEU = 0



SELECT ROW_NUMBER() OVER (ORDER BY MS_PHIEU_BAO_TRI, MS_BO_PHAN,MS_CV, MS_PT,MS_DH_XUAT_PT,SL_PX DESC) AS ST,
* INTO #TMP
FROM 
(SELECT MS_PHIEU_BAO_TRI, MS_BO_PHAN,MS_CV,T2.MS_DH_XUAT_PT,T1.STT, T1.MS_PT,SL_XUAT,T1.SL_KH,
CASE 
	WHEN SL_XUAT = SL_KH THEN SL_XUAT 
	WHEN SL_XUAT > SL_KH THEN SL_KH 
	WHEN SL_XUAT < SL_KH THEN SL_XUAT
END AS SL_PX

FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET T1
INNER JOIN
(
	SELECT DISTINCT T1.MS_DH_XUAT_PT, T2.MS_PT, T2.SO_LUONG_THUC_XUAT AS SL_XUAT
	FROM         dbo.IC_DON_HANG_XUAT AS T1 INNER JOIN
						  dbo.IC_DON_HANG_XUAT_VAT_TU AS T2 ON T1.MS_DH_XUAT_PT = T2.MS_DH_XUAT_PT INNER JOIN
						  dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS T3 ON T2.MS_DH_XUAT_PT = T3.MS_DH_XUAT_PT AND T2.MS_PT = T3.MS_PT
	WHERE (T1.MS_PHIEU_BAO_TRI = @MsPBT)  
) T2 ON T1.MS_PT = T2.MS_PT
 INNER JOIN (SELECT * FROM #PT WHERE NHIEU = 0) C ON C.MS_PT = T1.MS_PT 

WHERE MS_PHIEU_BAO_TRI = @MsPBT
)A 
ORDER BY MS_PHIEU_BAO_TRI, MS_BO_PHAN,MS_CV, MS_PT,MS_DH_XUAT_PT,SL_PX DESC


SELECT *,
ISNULL((SELECT SUM(SL_PX) FROM #TMP T2 WHERE T2.ST < T1.ST AND T1.MS_PT = T2.MS_PT 
	AND T1.MS_BO_PHAN = T2.MS_BO_PHAN AND T1.MS_CV = T2.MS_CV),0) AS SL_SS_TRUOC,
ISNULL((SELECT SUM(SL_PX) FROM #TMP T2 WHERE T2.ST <= T1.ST AND T1.MS_PT = T2.MS_PT
	AND T1.MS_BO_PHAN = T2.MS_BO_PHAN AND T1.MS_CV = T2.MS_CV),0) AS SL_SS  
INTO #TMP2
FROM #TMP T1
ORDER BY STT


SELECT *,CASE WHEN SL_SS <= SL_KH THEN SL_PX
ELSE 
	CASE WHEN SL_KH - SL_SS_TRUOC < 0 THEN 0 ELSE SL_KH - SL_SS_TRUOC END
END AS SL_CC INTO #TMP3
FROM #TMP2 



--INSERT INTO [PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO]([MS_PHIEU_BAO_TRI],[MS_CV],[MS_BO_PHAN],[MS_PT],[STT],[MS_DH_XUAT_PT], 
--	[MS_DH_NHAP_PT],[MS_PTTT],[ID],[SL_TT],[DON_GIA],[NGOAI_TE],[TI_GIA],[TI_GIA_USD]) 
--SELECT DISTINCT T0.MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN,T0.MS_PT, T0.STT, T1.MS_DH_XUAT_PT,T3.MS_DH_NHAP_PT, T2.MS_PT, ID_XUAT, SL_CC AS SLTT, DON_GIA, NGOAI_TE, TY_GIA, TY_GIA_USD
--FROM 
--dbo.IC_DON_HANG_XUAT AS T1 INNER JOIN
--dbo.IC_DON_HANG_XUAT_VAT_TU AS T2 ON T1.MS_DH_XUAT_PT = T2.MS_DH_XUAT_PT INNER JOIN
--dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS T3 ON T2.MS_DH_XUAT_PT = T3.MS_DH_XUAT_PT AND T2.MS_PT = T3.MS_PT INNER JOIN
--dbo.IC_DON_HANG_NHAP_VAT_TU AS T6 ON T3.MS_DH_NHAP_PT = T6.MS_DH_NHAP_PT AND T3.ID_XUAT = T6.ID AND T3.MS_PT = T6.MS_PT INNER JOIN 
--#TMP3 T0 ON T1.MS_PHIEU_BAO_TRI = T0.MS_PHIEU_BAO_TRI AND T0.MS_PT = T2.MS_PT AND T0.MS_DH_XUAT_PT = T1.MS_DH_XUAT_PT


