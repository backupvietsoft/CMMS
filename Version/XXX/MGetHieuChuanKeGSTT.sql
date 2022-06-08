﻿

--SELECT * FROM dbo.CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY = '163'
 --  SELECT *  FROM [dbo].[MGetHieuChuanKeGSTT]('01/01/2020','05/31/2020','admin','-1',-1,-1,'-1','-1',-1,0,0) ORDER BY MS_MAY,MS_BO_PHAN,MS_TS_GSTT,MS_TT,MS_DV_TG,NGAY_KE
  
 --Chú ý loại = 0 cung như loai = 1 không lấy 1 ngày dc phài lam câu xóa, lấy MIN ngay rùi xóa không làm câu select min ngay
ALTER FUNCTION [dbo].[MGetHieuChuanKeGSTT]
(
	 @NgayBD DATETIME,
	 @NgayKT DATETIME,
	 @UserName NVARCHAR(255),
	 @MsNXuong nvarchar(50),
	 @MsHeThong int,
	 @MsBPCP int,
	 @LoaiMay NVARCHAR (20),
	 @NhomMay NVARCHAR (20), 
	 @MsLCViec INT, 
	 @MLoai BIT,
	 @NNgu INT
)
--@MLoai = 1 Lấy all ngày kế trong giai đoạn
--@MLoai = 0 Lấy 1 ngày kế trong giai đoạn
returns  @MAY_NGAY_CUOI TABLE (
	 [MS_MAY] [nvarchar](30) NOT NULL,
	 [MS_BO_PHAN] NVARCHAR(50) NOT NULL, 
	 [MS_TS_GSTT] NVARCHAR(10) NOT NULL,
	 [MS_TT] INT NULL,
	 [NGAY_CUOI] [datetime] NULL,
	 [CHU_KY_DO] [int] NULL,
	 [MS_DV_TG] [int] NULL, 
	 [NGAY_KE] [datetime] NULL,
	 [TEN_MAY] NVARCHAR(1000)  NULL,
	 [TEN_BO_PHAN] NVARCHAR(1000)  NULL,
	 TEN_TS_GSTT NVARCHAR(1000)  NULL,
	 TEN_DV_TG NVARCHAR(1000)  NULL,
	 STT_CUOI INT,
	 [M_CHA] NVARCHAR(50) NOT NULL
 )
as
begin 
--DECLARE @MAY_USER TABLE (MS_MAY NVARCHAR(30),TEN_MAY NVARCHAR(1000))
--INSERT INTO @MAY_USER
--SELECT DISTINCT MS_MAY,TEN_MAY FROM [dbo].[MGetMayUserNgay](@NgayKT,@UserName,@MsNXuong,@MsHeThong,@MsBPCP,@LoaiMay,@NhomMay,'-1',0)

DECLARE @HC_USER TABLE(
	[STT] [INT] NULL,
	[NGAY_CUOI] [DATETIME] NULL,
	[MS_MAY] [NVARCHAR](30)  NULL,
	[MS_BO_PHAN] [NVARCHAR](50)  NULL,
	[MS_TS_GSTT] [NVARCHAR](10)  NULL,
	[MS_TT] [INT]  NULL,
	[CHU_KY_DO] [FLOAT] NULL,
	[MS_DV_TG] [INT] NULL,
	[SO_NGAY_CK] [INT] NULL,
	[TEN_BO_PHAN] [NVARCHAR](250)  NULL,
	[MS_BO_PHAN_CHA] [NVARCHAR](50) NULL,
	[TEN_MAY] [NVARCHAR](255) NULL
) 


INSERT	INTO @HC_USER(STT,NGAY_CUOI,MS_MAY,MS_BO_PHAN,MS_TS_GSTT,MS_TT,CHU_KY_DO,MS_DV_TG,SO_NGAY_CK,TEN_BO_PHAN,MS_BO_PHAN_CHA,TEN_MAY)
SELECT MAX(Z1.STT) STT,  MAX(CONVERT(DATETIME,CONVERT(NVARCHAR(10),Z1.NGAY_KT,101) +' '+  CONVERT(NVARCHAR(10), Z1.GIO_KT,108))) AS NGAY_CUOI,Z2.MS_MAY,Z2.MS_BO_PHAN,Z2.MS_TS_GSTT,Z2.MS_TT,Z3.CHU_KY_DO,Z3.MS_DV_TG ,
CASE Z3.MS_DV_TG 
	WHEN 1 THEN DATEDIFF (DAY, MAX(CONVERT(DATETIME,CONVERT(NVARCHAR(10),Z1.NGAY_KT,101) +' '+  CONVERT(NVARCHAR(10), Z1.GIO_KT,108))),@NgayBD) 
    WHEN 2 THEN DATEDIFF (DAY,MAX(CONVERT(DATETIME,CONVERT(NVARCHAR(10),Z1.NGAY_KT,101) +' '+  CONVERT(NVARCHAR(10), Z1.GIO_KT,108))),@NgayBD)
	WHEN 3 THEN DATEDIFF (MONTH,MAX(CONVERT(DATETIME,CONVERT(NVARCHAR(10),Z1.NGAY_KT,101) +' '+  CONVERT(NVARCHAR(10), Z1.GIO_KT,108))),@NgayBD)
    ELSE  
	DATEDIFF (MONTH,MAX(CONVERT(DATETIME,CONVERT(NVARCHAR(10),Z1.NGAY_KT,101) +' '+  CONVERT(NVARCHAR(10), Z1.GIO_KT,108))),@NgayBD)
	END 
     AS SO_NGAY_CK,Z5.TEN_BO_PHAN,Z5.MS_BO_PHAN_CHA,Z4.TEN_MAY

FROM dbo.GIAM_SAT_TINH_TRANG Z1 INNER JOIN dbo.GIAM_SAT_TINH_TRANG_TS Z2 ON Z2.STT = Z1.STT  INNER JOIN dbo.CAU_TRUC_THIET_BI_TS_GSTT Z3 ON Z3.MS_MAY = Z2.MS_MAY AND Z3.MS_BO_PHAN = Z2.MS_BO_PHAN AND Z3.MS_TS_GSTT = Z2.MS_TS_GSTT AND Z3.MS_TT = Z2.MS_TT INNER JOIN dbo.MAY Z4 ON Z4.MS_MAY = Z2.MS_MAY INNER JOIN dbo.CAU_TRUC_THIET_BI Z5 ON Z3.MS_MAY = Z5.MS_MAY AND Z3.MS_BO_PHAN = Z5.MS_BO_PHAN

GROUP BY   Z2.MS_MAY, Z2.MS_BO_PHAN, Z2.MS_TS_GSTT, Z2.MS_TT ,Z3.CHU_KY_DO,Z3.MS_DV_TG,Z5.TEN_BO_PHAN,Z5.MS_BO_PHAN_CHA,Z4.TEN_MAY

HAVING MAX(CONVERT(DATETIME,CONVERT(NVARCHAR(10),Z1.NGAY_KT,101) +' '+  CONVERT(NVARCHAR(10), Z1.GIO_KT,108))) <= @NgayBD ORDER BY Z2.MS_MAY,Z2.MS_BO_PHAN
INSERT INTO @MAY_NGAY_CUOI
(
    MS_MAY,
    MS_BO_PHAN,
    MS_TS_GSTT,
    MS_TT,
    NGAY_CUOI,
    CHU_KY_DO,
    MS_DV_TG,
    NGAY_KE,
    TEN_MAY,
    TEN_BO_PHAN,
    TEN_TS_GSTT,
    TEN_DV_TG,
    STT_CUOI,
    M_CHA
)
SELECT MS_MAY,MS_BO_PHAN,T1.MS_TS_GSTT,MS_TT,NGAY_CUOI,CHU_KY_DO,T1.MS_DV_TG,
CONVERT(DATE,
 CASE T1.MS_DV_TG WHEN 1 THEN CASE WHEN NGAY_CUOI >= @NgayBD THEN DATEADD (DAY,CHU_KY_DO,NGAY_CUOI) 
      ELSE DATEADD (DAY,CASE ISNULL(SO_NGAY_CK,0) WHEN 0 THEN CHU_KY_DO ELSE ISNULL(SO_NGAY_CK,0) END,NGAY_CUOI) END 
     WHEN 2 THEN CASE WHEN NGAY_CUOI >= @NgayBD THEN DATEADD (WEEK,CHU_KY_DO,NGAY_CUOI)
      ELSE DATEADD (WEEK,CASE ISNULL(SO_NGAY_CK,0) WHEN 0 THEN CHU_KY_DO ELSE ISNULL(SO_NGAY_CK,0) END,NGAY_CUOI) END        
     WHEN 3 THEN CASE WHEN NGAY_CUOI >= @NgayBD THEN DATEADD (MONTH,CHU_KY_DO,NGAY_CUOI)
       ELSE DATEADD (MONTH,  CASE ISNULL(SO_NGAY_CK,0) WHEN 0 THEN CHU_KY_DO ELSE ISNULL(SO_NGAY_CK,0) END  ,NGAY_CUOI) END 
     WHEN 4 THEN CASE WHEN NGAY_CUOI >= @NgayBD THEN DATEADD (YEAR,CHU_KY_DO,NGAY_CUOI)
       ELSE DATEADD (YEAR,CASE ISNULL(SO_NGAY_CK,0) WHEN 0 THEN CHU_KY_DO ELSE ISNULL(SO_NGAY_CK,0) END,NGAY_CUOI) END END) AS 
       NGAY_KE,
	   T1.TEN_MAY,T1.TEN_BO_PHAN,
CASE 0 WHEN 0 THEN T2.TEN_TS_GSTT  WHEN 1 THEN ISNULL(NULLIF(T2.TEN_TS_GSTT_ANH,''),T2.TEN_TS_GSTT ) ELSE ISNULL(NULLIF(T2.TEN_TS_GSTT_HOA,''),T2.TEN_TS_GSTT ) END  AS TEN_TS_GSTT 

,T3.TEN_DV_TG,T1.STT STT_CUOI
, T1.MS_BO_PHAN_CHA M_CHA 
FROM   @HC_USER T1 INNER JOIN dbo.THONG_SO_GSTT T2 ON T2.MS_TS_GSTT = T1.MS_TS_GSTT INNER JOIN dbo.DON_VI_THOI_GIAN T3 ON   T3.MS_DV_TG = T1.MS_DV_TG

  DECLARE @MS_MAY NVARCHAR(30),@TEN_MAY NVARCHAR(1000),@TEN_BO_PHAN  NVARCHAR(1000), @TEN_TS_GSTT NVARCHAR(1000), @MS_BO_PHAN NVARCHAR(50), @MS_TS_GSTT NVARCHAR(10),@MS_TT int,@NGAY_CUOI DATETIME,@CHU_KY_DO INT ,@MS_DV_TG INT,@NGAY_KE DATETIME,@TEN_DV_TG NVARCHAR(1000),@STT_CUOI int, @M_CHA NVARCHAR(50)

  DECLARE BTDK_CURSOR CURSOR FOR
   SELECT DISTINCT MS_MAY,TEN_MAY, TEN_BO_PHAN,TEN_TS_GSTT,MS_BO_PHAN,MS_TS_GSTT,MS_TT,NGAY_CUOI,CHU_KY_DO ,MS_DV_TG,NGAY_KE,TEN_DV_TG,STT_CUOI,M_CHA FROM @MAY_NGAY_CUOI  
    WHERE MS_DV_TG IN (1,2,3,4) AND CHU_KY_DO IS NOT NULL AND CHU_KY_DO > 0
  OPEN BTDK_CURSOR
  FETCH NEXT FROM BTDK_CURSOR 
  INTO @MS_MAY,@TEN_MAY,@TEN_BO_PHAN,@TEN_TS_GSTT,@MS_BO_PHAN,@MS_TS_GSTT,@MS_TT,@NGAY_CUOI,@CHU_KY_DO ,@MS_DV_TG,@NGAY_KE,@TEN_DV_TG,@STT_CUOI,@M_CHA
  WHILE @@FETCH_STATUS = 0  
  BEGIN 
   SET @NGAY_KE = (SELECT CASE @MS_DV_TG
      WHEN 1 THEN  DATEADD(DAY,@CHU_KY_DO,@NGAY_KE)
      WHEN 2 THEN DATEADD(DAY,7 * @CHU_KY_DO ,@NGAY_KE)
      WHEN 3 THEN DATEADD(MONTH,@CHU_KY_DO,@NGAY_KE) 
      WHEN 4 THEN DATEADD(YEAR,@CHU_KY_DO,@NGAY_KE)         
      ELSE 
       DATEADD(YEAR,1,@NgayKT)            
      END )
   
   WHILE @NGAY_KE <= @NgayKT 
    BEGIN 
     INSERT INTO @MAY_NGAY_CUOI (MS_MAY,TEN_MAY,TEN_BO_PHAN,TEN_TS_GSTT,MS_BO_PHAN,MS_TS_GSTT,MS_TT,NGAY_CUOI,CHU_KY_DO ,MS_DV_TG,NGAY_KE,TEN_DV_TG,STT_CUOI,M_CHA) 
     VALUES (@MS_MAY,@TEN_MAY,@TEN_BO_PHAN,@TEN_TS_GSTT,@MS_BO_PHAN,@MS_TS_GSTT,@MS_TT,@NGAY_CUOI,@CHU_KY_DO ,@MS_DV_TG,@NGAY_KE,@TEN_DV_TG,@STT_CUOI,@M_CHA) 

     SET @NGAY_KE = (SELECT CASE @MS_DV_TG
      WHEN 1 THEN  DATEADD(DAY,@CHU_KY_DO,@NGAY_KE)
      WHEN 2 THEN DATEADD(DAY,7 * @CHU_KY_DO ,@NGAY_KE)
      WHEN 3 THEN DATEADD(MONTH,@CHU_KY_DO,@NGAY_KE) 
      WHEN 4 THEN DATEADD(YEAR,@CHU_KY_DO,@NGAY_KE)            
      ELSE 
       DATEADD(YEAR,1,@NgayKT)            
      END )
       
     END 
   FETCH NEXT FROM BTDK_CURSOR 
   INTO @MS_MAY,@TEN_MAY,@TEN_BO_PHAN,@TEN_TS_GSTT,@MS_BO_PHAN,@MS_TS_GSTT,@MS_TT,@NGAY_CUOI,@CHU_KY_DO ,@MS_DV_TG,@NGAY_KE,@TEN_DV_TG,@STT_CUOI,@M_CHA
  END 
  CLOSE BTDK_CURSOR 
  DEALLOCATE  BTDK_CURSOR 

 
 DELETE @MAY_NGAY_CUOI WHERE CONVERT(DATE,NGAY_KE) NOT BETWEEN @NgayBD AND @NgayKT
 return 
END