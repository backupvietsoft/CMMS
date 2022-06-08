
--DROP TABLE A_HT 
--	SELECT * INTO A_HT FROM HE_THONG WHERE TEN_HE_THONG = 'Cranes'
--	EXEC getBCHieuQuaDuDoan 'ADMIN','11/01/2016','11/30/2016','-1','-1','A_HT',0
ALTER PROC [dbo].[getBCHieuQuaDuDoan]
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


SELECT 
ROW_NUMBER() OVER (ORDER BY  T1.MS_MAY, T4.TEN_MAY,T4.TEN_HE_THONG,T4.Ten_N_XUONG,T4.TEN_LOAI_MAY, T1.MS_PHIEU_BAO_TRI) AS STT,
T1.MS_MAY, T4.TEN_MAY,T4.TEN_HE_THONG,T4.Ten_N_XUONG,T4.TEN_LOAI_MAY,T1.MS_PHIEU_BAO_TRI,
ROUND(T2.CONG_TT,2) AS CONG_TT, ROUND(T3.CONG_KH,2) AS CONG_KH,
CASE ISNULL(CONG_KH,0) WHEN 0 THEN NULL ELSE 
ROUND(((ISNULL(CONG_KH,0) - ISNULL(CONG_TT,0)) / ISNULL(CONG_KH,0)) * 100,2)
--((G -H)/ H) * 100)
END AS TY_LE 
FROM 
(SELECT DISTINCT MS_MAY, MS_PHIEU_BAO_TRI FROM dbo.PHIEU_BAO_TRI WHERE TINH_TRANG_PBT > 2 and CONVERT(DATETIME,CONVERT(NVARCHAR(10),  NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay ) T1 INNER JOIN 
	#MAY  AS T4 ON T1.MS_MAY = T4.MS_MAY  INNER JOIN 
#HT T5 ON T4.MS_HE_THONG = T5.MS_HE_THONG 
LEFT JOIN                       
(

	SELECT T.MS_MAY, T.MS_PHIEU_BAO_TRI, SUM(T.CONG_TT) AS CONG_TT FROM (
	SELECT     A.MS_MAY, A.MS_PHIEU_BAO_TRI, SUM(B.SO_GIO) AS CONG_TT
	FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
						  dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET AS B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI
	WHERE TINH_TRANG_PBT > 2 and ( CONVERT(DATETIME,CONVERT(NVARCHAR(10),  NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay)							  
	GROUP BY A.MS_MAY, A.MS_PHIEU_BAO_TRI
	UNION ALL 
	SELECT     A.MS_MAY, A.MS_PHIEU_BAO_TRI, SUM(B.SO_GIO) AS CONG_TT
	FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
						  dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO AS B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI
	WHERE TINH_TRANG_PBT > 2 and ( CONVERT(DATETIME,CONVERT(NVARCHAR(10),  NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay)							  
	GROUP BY A.MS_MAY, A.MS_PHIEU_BAO_TRI
	) AS T 
	GROUP BY  T.MS_MAY, T.MS_PHIEU_BAO_TRI
) T2 ON T1.MS_MAY = T2.MS_MAY  AND T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI LEFT JOIN
(
	SELECT T.MS_MAY, T.MS_PHIEU_BAO_TRI, SUM(T.CONG_KH) AS CONG_KH FROM (
	SELECT     A.MS_MAY, A.MS_PHIEU_BAO_TRI, SUM(B.SO_GIO_KH) AS CONG_KH
	FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
						  dbo.PHIEU_BAO_TRI_CONG_VIEC AS B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI 
	WHERE TINH_TRANG_PBT > 2 and ( CONVERT(DATETIME,CONVERT(NVARCHAR(10),  A.NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay)						  
	GROUP BY A.MS_MAY, A.MS_PHIEU_BAO_TRI
	UNION ALL
	SELECT     A.MS_MAY, A.MS_PHIEU_BAO_TRI, SUM(B.SO_GIO_KH) AS CONG_KH
	FROM         dbo.PHIEU_BAO_TRI AS A INNER JOIN
						  dbo.PHIEU_BAO_TRI_CV_PHU_TRO AS B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI 
	WHERE TINH_TRANG_PBT > 2 and ( CONVERT(DATETIME,CONVERT(NVARCHAR(10),  A.NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay)						  
	GROUP BY A.MS_MAY, A.MS_PHIEU_BAO_TRI
	) AS T
	GROUP BY T.MS_MAY, T.MS_PHIEU_BAO_TRI
) T3 ON T1.MS_MAY = T3.MS_MAY AND T1.MS_PHIEU_BAO_TRI = T3.MS_PHIEU_BAO_TRI 

ORDER BY T1.MS_MAY, T4.TEN_MAY,T4.TEN_HE_THONG,T4.Ten_N_XUONG,T4.TEN_LOAI_MAY, T1.MS_PHIEU_BAO_TRI
