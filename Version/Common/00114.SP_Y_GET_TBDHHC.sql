

--EXEC [SP_Y_GET_TBDHHC] 'ADMIN',0,'01-01-2014','12-31-2015','-1','-1','-1','-1','-1','-1','-1',3
--SELECT * FROM IC_DUONG 
ALTER procedure [dbo].[SP_Y_GET_TBDHHC]
(
	@USERNAME NVARCHAR (64), 
	@LANGUAGE INT,
	@TU_NGAY DATETIME,
	@DEN_NGAY DATETIME,
	@MS_NHA_XUONG NVARCHAR(50), 
	@MS_HE_THONG INT ,
	@MS_LOAI_MAY NVARCHAR(30),
	@MS_MAY NVARCHAR (30),
	@MS_TINH NVARCHAR(100),
	@MS_QUAN NVARCHAR(100),
	@MS_DUONG NVARCHAR(100),
	@MSLHC INT
)
AS
	CREATE TABLE #NHAC_VIEC(MS_N_XUONG NVARCHAR(50))	
			
	IF @MS_NHA_XUONG = '-1'
	BEGIN
		INSERT INTO #NHAC_VIEC(MS_N_XUONG) SELECT MS_N_XUONG  FROM NHA_XUONG 
	END
	ELSE
	BEGIN
		DECLARE @NewInsertCount int;
		INSERT INTO #NHAC_VIEC(MS_N_XUONG)
		SELECT MS_N_XUONG FROM NHA_XUONG  WHERE MS_N_XUONG = @MS_NHA_XUONG 
		SET @NewInsertCount = @@ROWCOUNT;
		WHILE @NewInsertCount > 0
		BEGIN
		   
			INSERT INTO #NHAC_VIEC(MS_N_XUONG) 
				SELECT MS_N_XUONG FROM NHA_XUONG  WHERE EXISTS
					   (SELECT MS_N_XUONG  FROM #NHAC_VIEC
						WHERE NHA_XUONG.MS_CHA = #NHAC_VIEC.MS_N_XUONG)
				 AND  NOT EXISTS
					  (SELECT MS_N_XUONG FROM #NHAC_VIEC
					   WHERE NHA_XUONG.MS_N_XUONG  = #NHAC_VIEC.MS_N_XUONG);    
		    
				 SET @NewInsertCount = @@ROWCOUNT;
		       
		END
	END


--SELECT * FROM #NHAC_VIEC

SELECT TEMP.MS_MAY,TEMP.TEN_MAY,CONVERT(NVARCHAR(10),TEMP.NGAY_HC,103) NGAY_HC,TEMP.CHU_KY_HC,CONVERT(NVARCHAR(10),TEMP.NGAY_HC_KE,103) NGAY_HC_KE,TEMP.TEN_LOAI_HIEU_CHUAN,TEMP.MS_TINH,TEMP.MS_QUAN,TEMP.MS_DUONG
FROM
(
SELECT DISTINCT dbo.MAY.MS_MAY,
                dbo.MAY.TEN_MAY,dbo.HIEU_CHUAN_MAY.NGAY_HC, 
--1 NOI 2 NGOAI 3 KIEM DINH 
--CHU_KY_HC_TB, CHU_KY_HIEU_CHUAN_TB_NGOAI, CHU_KY_KD_TB,
                CASE HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN 
					WHEN 1 THEN CONVERT(NVARCHAR(10),dbo.MAY.CHU_KY_HC_TB) 
					WHEN 2 THEN CONVERT(NVARCHAR(10),dbo.MAY.CHU_KY_HIEU_CHUAN_TB_NGOAI) 
					ELSE CONVERT(NVARCHAR(10),dbo.MAY.CHU_KY_KD_TB) END                
                + ' ' + (CASE @LANGUAGE  WHEN 0 THEN DON_VI_THOI_GIAN.TEN_DV_TG ELSE DON_VI_THOI_GIAN.TEN_DV_TG_ANH END) AS CHU_KY_HC, 
                CASE MAY.DON_VI_THOI_GIAN WHEN 1 THEN
                DATEADD(DAY, dbo.MAY.CHU_KY_HC_TB, dbo.HIEU_CHUAN_MAY.NGAY_HC)
                WHEN 2 THEN
                DATEADD(DAY, dbo.MAY.CHU_KY_HC_TB*7, dbo.HIEU_CHUAN_MAY.NGAY_HC) 
                WHEN 3 THEN
                DATEADD(MONTH, dbo.MAY.CHU_KY_HC_TB, dbo.HIEU_CHUAN_MAY.NGAY_HC) 
                WHEN 4 THEN
                DATEADD(YEAR, dbo.MAY.CHU_KY_HC_TB, dbo.HIEU_CHUAN_MAY.NGAY_HC) 
                END
                AS NGAY_HC_KE,TEN_LOAI_HIEU_CHUAN,MS_TINH=[dbo].[Get_CityCode](NHA_XUONG.MS_QG),MS_QUAN = NHA_XUONG.MS_QG,NHA_XUONG.MS_DUONG
FROM  dbo.MAY INNER JOIN DON_VI_THOI_GIAN ON MAY.DON_VI_THOI_GIAN = DON_VI_THOI_GIAN.MS_DV_TG INNER JOIN
dbo.HIEU_CHUAN_MAY ON dbo.MAY.MS_MAY = dbo.HIEU_CHUAN_MAY.MS_MAY INNER JOIN
LOAI_HIEU_CHUAN_MAY ON HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = LOAI_HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN INNER JOIN
dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN
dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN
dbo.NHOM_LOAI_MAY ON dbo.LOAI_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN
dbo.USERS ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.USERS.GROUP_ID INNER JOIN
(SELECT T1.MS_MAY , T2.MS_N_XUONG,T1.NGAY_NHAP
FROM (SELECT T.MS_MAY, MAX (T.NGAY_NHAP) AS NGAY_NHAP
FROM dbo.MAY_NHA_XUONG T
GROUP BY T.MS_MAY) T1 INNER JOIN 
dbo.MAY_NHA_XUONG T2 ON T1.MS_MAY = T2.MS_MAY AND T1.NGAY_NHAP = T2.NGAY_NHAP ) MAY_NHA_XUONG_TMP ON dbo.MAY.MS_MAY = MAY_NHA_XUONG_TMP.MS_MAY INNER JOIN
dbo.NHOM_NHA_XUONG ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM_NHA_XUONG.GROUP_ID AND 
MAY_NHA_XUONG_TMP.MS_N_XUONG = dbo.NHOM_NHA_XUONG.MS_N_XUONG INNER JOIN
NHA_XUONG ON MAY_NHA_XUONG_TMP.MS_N_XUONG = NHA_XUONG.MS_N_XUONG INNER JOIN
(SELECT T1.MS_MAY ,T2.MS_HE_THONG, T1.NGAY_NHAP 
FROM (SELECT T.MS_MAY, MAX (T.NGAY_NHAP) AS NGAY_NHAP
FROM dbo.MAY_HE_THONG T
GROUP BY T.MS_MAY) T1 INNER JOIN 
dbo.MAY_HE_THONG T2 ON T1.MS_MAY = T2.MS_MAY AND T1.NGAY_NHAP = T2.NGAY_NHAP ) MAY_HE_THONG_TMP ON dbo.MAY.MS_MAY = MAY_HE_THONG_TMP.MS_MAY INNER JOIN
dbo.NHOM_HE_THONG ON dbo.NHOM_LOAI_MAY.GROUP_ID = dbo.NHOM_HE_THONG.GROUP_ID AND 
MAY_HE_THONG_TMP.MS_HE_THONG = dbo.NHOM_HE_THONG.MS_HE_THONG
WHERE (dbo.USERS.[USERNAME] = @USERNAME)
AND CASE HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN 
		WHEN 1 THEN dbo.MAY.CHU_KY_HC_TB
		WHEN 2 THEN dbo.MAY.CHU_KY_HIEU_CHUAN_TB_NGOAI
		ELSE dbo.MAY.CHU_KY_KD_TB END > 0					
AND (DATEADD(DAY,CHU_KY_HC_TB,NGAY_HC) >=  CONVERT (NVARCHAR (10),@TU_NGAY , 102))
AND (DATEADD(DAY,CHU_KY_HC_TB,NGAY_HC) <= CONVERT (NVARCHAR (10),@DEN_NGAY , 102))
AND (MAY_NHA_XUONG_TMP.MS_N_XUONG IN (SELECT MS_N_XUONG FROM #NHAC_VIEC))
AND (HIEU_CHUAN_MAY.MS_LOAI_HIEU_CHUAN = @MSLHC OR @MSLHC = -1)
AND (MAY_HE_THONG_TMP.MS_HE_THONG = @MS_HE_THONG OR @MS_HE_THONG = -1)
AND (dbo.LOAI_MAY.MS_LOAI_MAY = @MS_LOAI_MAY OR @MS_LOAI_MAY = '-1')
AND (dbo.MAY.MS_MAY = @MS_MAY OR @MS_MAY = '-1')

)TEMP WHERE (TEMP.MS_TINH= @MS_TINH OR @MS_TINH = '-1')

AND (TEMP.MS_QUAN= @MS_QUAN OR @MS_QUAN = '-1')
AND (TEMP.MS_DUONG= @MS_DUONG OR @MS_DUONG = '-1')


