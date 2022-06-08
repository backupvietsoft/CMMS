
--DROP TABLE A_HT 
--SELECT * INTO A_HT FROM HE_THONG
--EXEC getBCDieuDoBaoTri 'ADMIN','01/01/2016','11/04/2016','-1','-1','A_HT',0
ALTER PROC [dbo].[getBCDieuDoBaoTri]
	@UserName NVARCHAR(50),
	@TNgay DATETIME,
	@DNgay DATETIME,
	@MsNXuong nvarchar(50),
	@MsLoaiMay NVARCHAR (20),
	@HeThong nvarchar(50),
	@NNgu int
AS

DECLARE @NgayHT DATETIME
SET @NgayHT = GETDATE()	


DECLARE @sSql NVARCHAR(4000)
CREATE TABLE #HT (MS_HE_THONG INT )

SET @sSql = 'INSERT INTO #HT SELECT DISTINCT [MS_HE_THONG] FROM ' + @HeThong
EXEC (@sSql)

SET @sSql = 'DROP TABLE ' + @HeThong
EXEC (@sSql)


SELECT * INTO #MAY FROM dbo.MGetMayUserNgay( @NgayHT,@UserName,@MsNXuong,-1,-1,@MsLoaiMay,'-1','-1',@NNgu) 

SELECT DISTINCT MS_MAY INTO #PBT FROM dbo.PHIEU_BAO_TRI WHERE TINH_TRANG_PBT > 2 AND  CONVERT(DATETIME,CONVERT(NVARCHAR(10),  NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay


SELECT T.MS_MAY, SUM(T.TG_KH) AS TG_KH  INTO #PBT_TG_KH FROM (
SELECT A.MS_MAY, SUM(ISNULL(D.SO_GIO, 0)) AS TG_KH
	FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
						  dbo.LOAI_BAO_TRI AS B ON A.MS_LOAI_BT = B.MS_LOAI_BT INNER JOIN						  
						  dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET AS D ON A.MS_PHIEU_BAO_TRI = D.MS_PHIEU_BAO_TRI
WHERE      TINH_TRANG_PBT > 2 AND (B.HU_HONG = 0) AND ( CONVERT(DATETIME,CONVERT(NVARCHAR(10),  NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay) 
GROUP BY A.MS_MAY
UNION
SELECT A.MS_MAY, SUM(ISNULL(D.SO_GIO, 0)) AS TG_KH
	FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
						  dbo.LOAI_BAO_TRI AS B ON A.MS_LOAI_BT = B.MS_LOAI_BT INNER JOIN						  
						  dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO AS D ON A.MS_PHIEU_BAO_TRI = D.MS_PHIEU_BAO_TRI 
WHERE      TINH_TRANG_PBT > 2 AND (B.HU_HONG = 0) AND ( CONVERT(DATETIME,CONVERT(NVARCHAR(10),  NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay) 
GROUP BY A.MS_MAY
) AS T
GROUP BY T.MS_MAY



SELECT T.MS_MAY, SUM(T.TG_DX) AS TG_DX  INTO #PBT_TG_DX FROM (

SELECT  A.MS_MAY, SUM(ISNULL(D.SO_GIO, 0)) AS TG_DX 
FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
                      dbo.LOAI_BAO_TRI AS B ON A.MS_LOAI_BT = B.MS_LOAI_BT INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET AS D ON A.MS_PHIEU_BAO_TRI = D.MS_PHIEU_BAO_TRI 
WHERE    TINH_TRANG_PBT > 2 AND  (B.HU_HONG = 1) AND ( CONVERT(DATETIME,CONVERT(NVARCHAR(10),  NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay)
GROUP BY A.MS_MAY
UNION
SELECT  A.MS_MAY, SUM(ISNULL(D.SO_GIO, 0)) AS TG_DX
FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
                      dbo.LOAI_BAO_TRI AS B ON A.MS_LOAI_BT = B.MS_LOAI_BT INNER JOIN
                      dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO AS D ON A.MS_PHIEU_BAO_TRI = D.MS_PHIEU_BAO_TRI
WHERE    TINH_TRANG_PBT > 2 AND  (B.HU_HONG = 1) AND ( CONVERT(DATETIME,CONVERT(NVARCHAR(10),  NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay)
GROUP BY A.MS_MAY
) AS T
GROUP BY T.MS_MAY


SELECT ROW_NUMBER() OVER (ORDER BY  T1.MS_MAY, T4.TEN_MAY,T4.TEN_HE_THONG,T4.Ten_N_XUONG,T4.TEN_LOAI_MAY) AS STT,
T1.MS_MAY, T4.TEN_MAY,T4.TEN_HE_THONG,T4.Ten_N_XUONG,T4.TEN_LOAI_MAY,
ROUND(T2.TG_KH,2) AS TG_KH, ROUND(T3.TG_DX,2) AS TG_DX, ROUND(ISNULL(T2.TG_KH,0) +  ISNULL(T3.TG_DX,0),2) AS TONG_TG, 
CASE ISNULL(T2.TG_KH,0) +  ISNULL(T3.TG_DX,0) WHEN 0 THEN 0 ELSE 
ROUND((ISNULL(T2.TG_KH,0) / (ISNULL(T2.TG_KH,0) +  ISNULL(T3.TG_DX,0)) ) * 100,2) END AS PT_KH, 
CASE ISNULL(T2.TG_KH,0) +  ISNULL(T3.TG_DX,0) WHEN 0 THEN 0 ELSE 
ROUND((ISNULL(T3.TG_DX,0) / (ISNULL(T2.TG_KH,0) +  ISNULL(T3.TG_DX,0)) ) * 100,2) END AS PT_DX
FROM #PBT T1 
INNER JOIN #MAY  AS T4 ON T1.MS_MAY = T4.MS_MAY  
INNER JOIN #HT T5 ON T4.MS_HE_THONG = T5.MS_HE_THONG 
LEFT JOIN #PBT_TG_KH T2 ON T1.MS_MAY = T2.MS_MAY
LEFT JOIN #PBT_TG_DX T3 ON T1.MS_MAY = T3.MS_MAY 
ORDER BY T1.MS_MAY, T4.TEN_MAY,T4.TEN_HE_THONG,T4.Ten_N_XUONG,T4.TEN_LOAI_MAY

