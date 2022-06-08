
-- exec GetDSDMVT 0, 'admin','WO-201510000299','S',1
ALTER PROCEDURE [dbo].[GetDSDMVT]
	@TYPE INT,
	@USERNAME NVARCHAR(50),	
	@MS_PHIEU_BAO_TRI NVARCHAR(50),
	@MS_BO_PHAN NVARCHAR(50),	
	@MS_CV INT
AS

CREATE TABLE #PTUNG ([MS_PT] NVARCHAR(255))

DECLARE @sSQL NVARCHAR(4000)
SET @sSQL = 'INSERT INTO #PTUNG (MS_PT) SELECT DISTINCT MS_PT
		FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP' +  @USERNAME  + ' WHERE MS_BO_PHAN = '''+ @MS_BO_PHAN + 
		''' AND MS_CV = ' + CONVERT(NVARCHAR,@MS_CV) + ' AND MS_PHIEU_BAO_TRI = ''' + @MS_PHIEU_BAO_TRI + ''''
EXEC (@sSQL)


SELECT DISTINCT T1.MS_PT INTO #LPT_USER FROM IC_PHU_TUNG_LOAI_PHU_TUNG T1 INNER JOIN NHOM_LOAI_PHU_TUNG T2 ON T1.MS_LOAI_PT = T2.MS_LOAI_PT 
	INNER JOIN USERS T3 ON T2.GROUP_ID = T3.GROUP_ID WHERE USERNAME = @USERNAME
SELECT DISTINCT  T1.MS_PT INTO #LM_USER FROM IC_PHU_TUNG_LOAI_MAY T1 INNER JOIN NHOM_LOAI_MAY T2 ON T1.MS_LOAI_MAY = T2.MS_LOAI_MAY 
	INNER JOIN USERS T3 ON T2.GROUP_ID = T3.GROUP_ID WHERE USERNAME = @USERNAME

SELECT DISTINCT A.MS_PT, A.TEN_PT, A.TEN_PT_VIET, A.QUY_CACH, A.MS_PT_NCC, A.MS_PT_CTY, 1 AS SL_KH, 
		CASE 0 WHEN 0 THEN B.TEN_LOAI_VT_TV WHEN 1 THEN B.TEN_LOAI_VT_TA ELSE B.TEN_LOAI_VT_TV END AS TEN_LOAI_VT_TV, 
		CASE 0 WHEN 0 THEN C.TEN_1 WHEN 1 THEN C.TEN_2 ELSE C.TEN_3 END AS TEN_1,
		@MS_BO_PHAN AS MS_BO_PHAN, @MS_CV AS MS_CV,@MS_PHIEU_BAO_TRI AS MS_PHIEU_BAO_TRI,
		CONVERT(NVARCHAR(250),@MS_CV) +  CONVERT(NVARCHAR(250),@MS_BO_PHAN) AS MSCVBT 
INTO #BTVT		
FROM dbo.IC_PHU_TUNG AS A INNER JOIN
                  dbo.LOAI_VT AS B ON A.MS_LOAI_VT = B.MS_LOAI_VT INNER JOIN
                  dbo.DON_VI_TINH AS C ON A.DVT = C.DVT  
WHERE ACTIVE_PT = 1 


SELECT 	A.MS_PT, TEN_PT, TEN_PT_VIET, QUY_CACH, MS_PT_NCC, MS_PT_CTY, SL_KH, TEN_LOAI_VT_TV, TEN_1,
	MS_BO_PHAN, MS_CV,MS_PHIEU_BAO_TRI,MSCVBT 	
INTO #BT1	
FROM #BTVT A INNER JOIN 
	#LPT_USER AS D ON D.MS_PT = A.MS_PT INNER JOIN
    #LM_USER AS E ON E.MS_PT = A.MS_PT 
ORDER BY A.MS_PT, A.TEN_PT




SELECT DISTINCT
CONVERT(BIT,CASE ISNULL(T2.MS_PT,'') WHEN '' THEN 0 ELSE 1 END) AS CHON,T1.MS_PT, TEN_PT,
	TEN_PT_VIET,QUY_CACH ,SL_KH, TEN_LOAI_VT_TV,   MS_PT_NCC, MS_PT_CTY, TEN_1,
	@MS_BO_PHAN AS MS_BO_PHAN, @MS_CV AS MS_CV,@MS_PHIEU_BAO_TRI AS MS_PHIEU_BAO_TRI,MSCVBT
FROM #BT1  T1 LEFT JOIN #PTUNG T2 ON T1.MS_PT = T2.MS_PT 
ORDER BY MS_PHIEU_BAO_TRI, MS_BO_PHAN,MS_CV,MS_PT,TEN_PT

