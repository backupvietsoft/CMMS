

--	exec GET_THONG_SO_KHONG_DAT_KHTT '-1','-1','-1','02/01/2016','12/30/2016',1,'-1', 'Admin',-1

ALTER procedure [dbo].[GET_THONG_SO_KHONG_DAT_KHTT]
	@MAY VARCHAR(19),
	@LOAIMAY VARCHAR(19),
	@NHOMMAY VARCHAR (19),
	@TUNGAY DATETIME,
	@DENNGAY DATETIME,
	@DK INT,
	@MS_NHA_XUONG VARCHAR(50),
	@USERNAME VARCHAR(50),
	@MS_HE_THONG VARCHAR(50)
as
begin

SELECT B.STT, B.MS_MAY, B.MS_BO_PHAN, B.MS_TS_GSTT, B.MS_TT, NGAY_GIO AS NGAY_GIO_KT_MAX INTO #GSTT_KKTT FROM 
(
SELECT B.STT,B.MS_MAY, B.MS_BO_PHAN, B.MS_TS_GSTT, B.MS_TT, CONVERT(CHAR(10), A.NGAY_KT, 103) + ' ' + CONVERT(CHAR(5), A.GIO_KT, 8) AS NGAY_GIO
	FROM         dbo.GIAM_SAT_TINH_TRANG AS A INNER JOIN
						  dbo.GIAM_SAT_TINH_TRANG_TS_DT AS B ON A.STT = B.STT
) B             
INNER JOIN
(SELECT MS_MAY, MS_BO_PHAN, MS_TS_GSTT, MS_TT, MAX(NGAY_GIO) AS NGAY_MAX FROM
	(SELECT B.MS_MAY, B.MS_BO_PHAN, B.MS_TS_GSTT, B.MS_TT, CONVERT(CHAR(10), A.NGAY_KT, 103) + ' ' + CONVERT(CHAR(5), A.GIO_KT, 8) AS NGAY_GIO
	FROM         dbo.GIAM_SAT_TINH_TRANG AS A INNER JOIN
						  dbo.GIAM_SAT_TINH_TRANG_TS_DT AS B ON A.STT = B.STT
	) A GROUP BY MS_MAY, MS_BO_PHAN, MS_TS_GSTT, MS_TT
) C ON B.NGAY_GIO = NGAY_MAX AND C.MS_BO_PHAN = B.MS_BO_PHAN AND C.MS_MAY = B.MS_MAY AND C.MS_TS_GSTT = B.MS_TS_GSTT AND C.MS_TT = B.MS_TT

SELECT DISTINCT MS_MAY,TEN_MAY INTO #MAY_USER FROM [dbo].[MGetMayUserNgay](@DENNGAY,@USERNAME,@MS_NHA_XUONG,@MS_HE_THONG,-1,@LOAIMAY,@NHOMMAY,@MAY,0)

CREATE TABLE #TS1(
	[STT] [int]  NULL,
	[MS_TS_GSTT] [nvarchar](100)  NULL,
	[MS_TT] [int]  NULL,
	[NGAY_GIO_KT_MAX] [varchar](16) NULL,
	[MS_MAY] [nvarchar](100)  NULL,
	[TEN_MAY] [nvarchar](255)  NULL,
	[TEN_BO_PHAN] [nvarchar](100)  NULL,
	[TEN_TS_GSTT] [nvarchar](255)  NULL,
	[GT_DL] [nvarchar](100) NULL,
	[GIOI_HAN] [nvarchar](100) NULL,
	[GT_DT] [nvarchar](255)  NULL,
	[MS_CACH_TH] [nvarchar](100) NULL,
	[MS_PBT] [nvarchar](100) NULL,
	[MS_CONG_NHAN] [nvarchar](100) NULL,
	[TG_XU_LY] [datetime] NULL,
	[USERNAME] [nvarchar](100) NULL,
	[STT_GT] [int]  NULL--,
	--[MS_BO_PHAN] [nvarchar](50) NULL
) ON [PRIMARY]

DECLARE @SQL VARCHAR(8000)
--#TS1 
SET @SQL=' INSERT INTO #TS1 
SELECT DT.STT, A.MS_TS_GSTT, A.MS_TT,  CONVERT(NVARCHAR(10), A.NGAY_GIO_KT_MAX, 101) AS NGAY_GIO_KT_MAX, A.MS_MAY,E.TEN_MAY, (DT.MS_BO_PHAN + '' - '' + H.TEN_BO_PHAN) AS TEN_BO_PHAN, D.TEN_TS_GSTT, CAST(NULL AS NVARCHAR) AS GT_DL, CAST(NULL AS NVARCHAR) AS GIOI_HAN, 
C.TEN_GIA_TRI AS GT_DT, DT.MS_CACH_TH, DT.MS_PBT, DT.MS_CONG_NHAN, DT.TG_XU_LY, DT.USERNAME, DT.STT_GT --, DT.MS_BO_PHAN 
FROM #MAY_USER AS E INNER JOIN
                      dbo.CAU_TRUC_THIET_BI AS H ON E.MS_MAY = H.MS_MAY INNER JOIN
                      #GSTT_KKTT AS A INNER JOIN
                      dbo.GIAM_SAT_TINH_TRANG_TS_DT AS DT ON 
						A.STT = DT.STT AND 
						A.MS_MAY = DT.MS_MAY AND A.MS_TS_GSTT = DT.MS_TS_GSTT 
						AND A.MS_BO_PHAN = DT.MS_BO_PHAN AND A.MS_TT = DT.MS_TT  
                      INNER JOIN                      
                      ( SELECT *, CONVERT(CHAR(10), NGAY_KT, 103) + '' '' + CONVERT(CHAR(5), GIO_KT, 8) AS NGAY_GIO FROM dbo.GIAM_SAT_TINH_TRANG)
                      AS B ON DT.STT = B.STT AND A.NGAY_GIO_KT_MAX = B.NGAY_GIO 
                      
                      INNER JOIN
                      dbo.GIA_TRI_TS_GSTT AS C ON A.MS_TS_GSTT = C.MS_TS_GSTT AND DT.STT_GT = C.STT INNER JOIN
                      dbo.THONG_SO_GSTT AS D ON D.MS_TS_GSTT = A.MS_TS_GSTT ON H.MS_BO_PHAN = A.MS_BO_PHAN AND H.MS_MAY = A.MS_MAY 
                      LEFT OUTER JOIN dbo.KE_HOACH_TONG_THE AS K ON DT.HANG_MUC_ID_KE_HOACH = K.HANG_MUC_ID 
                      INNER JOIN MAY ON E.MS_MAY = MAY.MS_MAY 
                      INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY
'
IF @DK=1 
	SET @SQL = @SQL+'WHERE C.DAT=0 AND TG_XU_LY IS NULL AND (DT.MS_CACH_TH<>''03'' OR DT.MS_CACH_TH IS NULL) '
ELSE IF @DK = 2
	SET @SQL = @SQL+'WHERE C.DAT=0 AND LOAI_TS=1 AND DT.MS_CACH_TH=''03''  '
ELSE
	SET @SQL = @SQL+'WHERE DT.MS_CACH_TH<>''03'' AND LOAI_TS=1 AND TG_XU_LY>='''+CONVERT(VARCHAR,@TUNGAY,101)+''' AND TG_XU_LY <='''+CONVERT(VARCHAR,@DENNGAY,101)+'''  '
IF @MAY <>'-1'
	SET @SQL = @SQL+' AND DT.MS_MAY=N'''+@MAY+''''
IF @LOAIMAY <>'-1'
	SET @SQL = @SQL+' AND NHOM_MAY.MS_LOAI_MAY = '''+@LOAIMAY + ''''
IF @NHOMMAY <>'-1'
	SET @SQL = @SQL+' AND NHOM_MAY.MS_NHOM_MAY='''+@NHOMMAY + ''''
IF @MS_HE_THONG <> '-1'
	SET @SQL = @SQL+' AND dbo.MGetHTTheoNgay(DT.MS_MAY , '''+CONVERT(VARCHAR,@DENNGAY,101)+''')  ='''+ @MS_HE_THONG + '''
'

print (@SQL)
EXEC (@SQL)
--select * from #TS1
SET @SQL = '  INSERT INTO #TS1
SELECT DISTINCT 
                      A.STT, A.MS_TS_GSTT, A.MS_TT, CONVERT(NVARCHAR(10), A.NGAY_GIO_KT_MAX, 101) AS NGAY_GIO_KT_MAX, A.MS_MAY,MAY.TEN_MAY,  (A.MS_BO_PHAN + '' - '' + dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN) AS TEN_BO_PHAN, D.TEN_TS_GSTT, CAST(A.GIA_TRI_DO AS NVARCHAR) 
                      + '' '' + E.TEN_DV_DO AS GT_DL, CAST(NULL AS NVARCHAR) AS GIOI_HAN, CAST(A.GIA_TRI_DO AS NVARCHAR) + '' '' + E.TEN_DV_DO AS GT_DT, A.MS_CACH_TH, A.MS_PBT, A.MS_CONG_NHAN, 
                      A.TG_XU_LY, A.USERNAME, NULL AS STT_GT --,A.MS_BO_PHAN
FROM         (SELECT     GIAM_SAT_TINH_TRANG_TS_1.STT, PHU.MS_MAY, PHU.MS_BO_PHAN, PHU.MS_TS_GSTT, PHU.MS_TT, PHU.NGAY_GIO_KT_MAX, GIAM_SAT_TINH_TRANG_TS_1.GIA_TRI_DO, 
                                              GIAM_SAT_TINH_TRANG_TS_1.MS_CACH_TH, GIAM_SAT_TINH_TRANG_TS_1.MS_CONG_NHAN, GIAM_SAT_TINH_TRANG_TS_1.TG_XU_LY, GIAM_SAT_TINH_TRANG_TS_1.MS_PBT, 
                                              GIAM_SAT_TINH_TRANG_TS_1.HANG_MUC_ID_KE_HOACH, GIAM_SAT_TINH_TRANG_TS_1.USERNAME
                       FROM          (SELECT     dbo.GIAM_SAT_TINH_TRANG_TS.MS_MAY, dbo.GIAM_SAT_TINH_TRANG_TS.MS_BO_PHAN, dbo.GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT, 
                                                                      dbo.GIAM_SAT_TINH_TRANG_TS.MS_TT, CONVERT(CHAR(10), dbo.GIAM_SAT_TINH_TRANG.NGAY_KT, 103) + '' '' + CONVERT(CHAR(5), dbo.GIAM_SAT_TINH_TRANG.GIO_KT, 8) 
                                                                      AS NGAY_GIO_KT_MAX
                                               FROM          dbo.GIAM_SAT_TINH_TRANG INNER JOIN
                                                                      dbo.GIAM_SAT_TINH_TRANG_TS ON dbo.GIAM_SAT_TINH_TRANG.STT = dbo.GIAM_SAT_TINH_TRANG_TS.STT) AS PHU INNER JOIN
                                              dbo.GIAM_SAT_TINH_TRANG_TS AS GIAM_SAT_TINH_TRANG_TS_1 ON PHU.MS_MAY = GIAM_SAT_TINH_TRANG_TS_1.MS_MAY AND 
                                              PHU.MS_TS_GSTT = GIAM_SAT_TINH_TRANG_TS_1.MS_TS_GSTT INNER JOIN
                                              dbo.GIAM_SAT_TINH_TRANG AS GIAM_SAT_TINH_TRANG_1 ON GIAM_SAT_TINH_TRANG_TS_1.STT = GIAM_SAT_TINH_TRANG_1.STT AND CONVERT(DATETIME, 
                                              LEFT(PHU.NGAY_GIO_KT_MAX, 10), 103) = GIAM_SAT_TINH_TRANG_1.NGAY_KT AND CONVERT(DATETIME, RIGHT(PHU.NGAY_GIO_KT_MAX, 5), 103) 
                                              = GIAM_SAT_TINH_TRANG_1.GIO_KT) AS A INNER JOIN
                                              
                      dbo.GIAM_SAT_TINH_TRANG AS B ON A.STT = B.STT INNER JOIN
                      dbo.CAU_TRUC_THIET_BI_TS_GSTT AS C ON A.MS_MAY = C.MS_MAY AND A.MS_TS_GSTT = C.MS_TS_GSTT AND A.MS_BO_PHAN = C.MS_BO_PHAN INNER JOIN
                      dbo.THONG_SO_GSTT AS D ON D.MS_TS_GSTT = A.MS_TS_GSTT INNER JOIN
                      dbo.DON_VI_DO AS E ON D.MS_DV_DO = E.MS_DV_DO INNER JOIN
                      #MAY_USER XX ON A.MS_MAY = XX.MS_MAY INNER JOIN
                      dbo.CAU_TRUC_THIET_BI ON C.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND C.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN AND 
                      XX.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND A.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND A.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN LEFT OUTER JOIN
                      dbo.KE_HOACH_TONG_THE ON A.HANG_MUC_ID_KE_HOACH = dbo.KE_HOACH_TONG_THE.HANG_MUC_ID 
					  INNER JOIN MAY ON A.MS_MAY = MAY.MS_MAY 
                      INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY
'
IF @DK=1 
	SET @SQL=@SQL+'WHERE (C.DAT is NULL or C.DAT=0) and  (GIA_TRI_DO>= GIA_TRI_TREN OR GIA_TRI_DO<GIA_TRI_DUOI) AND LOAI_TS=0 AND TG_XU_LY IS NULL AND (A.MS_CACH_TH<>''03'' OR A.MS_CACH_TH IS NULL) '
ELSE IF @DK = 2
	SET @SQL=@SQL+'WHERE (C.DAT is NULL or C.DAT=0) and (GIA_TRI_DO>= GIA_TRI_TREN OR GIA_TRI_DO<=GIA_TRI_DUOI) AND LOAI_TS=0 AND A.MS_CACH_TH=''03''  '
ELSE
	SET @SQL=@SQL+'WHERE (C.DAT is NULL or C.DAT=0) and (GIA_TRI_DO>= GIA_TRI_TREN OR GIA_TRI_DO<=GIA_TRI_DUOI) AND LOAI_TS=0 AND A.MS_CACH_TH<>''03'' 
					 AND TG_XU_LY>='''+CONVERT(VARCHAR,@TUNGAY,101)+''' AND TG_XU_LY <=''' + CONVERT(VARCHAR,@DENNGAY,101) +''''
IF @MAY <>'-1'
	SET @SQL = @SQL+' AND A.MS_MAY=N'''+@MAY+''''
IF @LOAIMAY <>'-1'
	SET @SQL = @SQL+' AND NHOM_MAY.MS_LOAI_MAY = '''+@LOAIMAY + ''''
IF @NHOMMAY <>'-1'
	SET @SQL = @SQL+'  AND NHOM_MAY.MS_NHOM_MAY='''+@NHOMMAY + ''''

IF @MS_HE_THONG <> '-1'
	SET @SQL = @SQL+' AND dbo.MGetHTTheoNgay(A.MS_MAY , '''+CONVERT(VARCHAR,@DENNGAY,101)+''')  ='''+ @MS_HE_THONG + ''''	
--EXEC (@SQL)

--print (@SQL)
EXEC (@SQL)
--select * from #TS1

	
SELECT DISTINCT * FROM #TS1 A  
ORDER BY NGAY_GIO_KT_MAX DESC

end
