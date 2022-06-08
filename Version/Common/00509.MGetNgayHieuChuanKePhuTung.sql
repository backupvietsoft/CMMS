

--	SELECT * FROM [dbo].[MGetNgayHieuChuanKePhuTung]('01/01/2013','12/01/2018',2,'Administrator','-1',-1,'-1','-1',0)  A ORDER BY MS_MAY, MS_PT, MS_VI_TRI, MS_DV_TG,CHU_KY,NGAY_KE

ALTER FUNCTION [dbo].[MGetNgayHieuChuanKePhuTung]
(
	@NgayBD DATETIME,
	@NgayKT DATETIME,
	@LoaiHC INT,
	@UserName NVARCHAR(255),
	@MsNXuong nvarchar(50),
	@NHeThong int,
	@LoaiMay NVARCHAR (20),
	@NhomMay NVARCHAR (20),
	@MLoai bit
)
--@LoaiHC  
--1	Hiệu chuẩn nội
--2	Hiệu chuẩn ngoại
--3	Kiểm định
--4	Kiểm tra
--select * from LOAI_HIEU_CHUAN
	

returns  @MAY_NGAY_CUOI TABLE (
	[MS_MAY] [nvarchar](30) NOT NULL,
	[MS_PT] [nvarchar](25) NOT NULL,
	[MS_VI_TRI] [nvarchar](50) NOT NULL,
	[NGAY_HC_CUOI] [datetime] NULL,
	[CHU_KY] [smallint] NULL,
	[MS_DV_TG] [int] NULL,
	[SO_NGAY] [int] NULL,
	[SO_NGAY_CK] [int] NULL,
	[NGAY_KE] [datetime] NULL)
as
begin	
--Lấy dữ liệu theo nha xuong, he thong và tính ngày bảo trì định kỳ cuoi
DECLARE @MAY_USER TABLE (MS_MAY NVARCHAR(30))
INSERT INTO @MAY_USER
SELECT DISTINCT MS_MAY FROM [dbo].[MGetMayUserNgay](@NgayKT,@UserName,@MsNXuong,@NHeThong,-1,@LoaiMay,@NhomMay,'-1',0)


INSERT INTO @MAY_NGAY_CUOI
SELECT DISTINCT MS_MAY ,MS_PT,MS_VI_TRI, NGAY_HC_CUOI , CHU_KY, MS_DV_TG, SO_NGAY, SO_NGAY_CK,
	CASE MS_DV_TG WHEN 1 THEN CASE WHEN NGAY_HC_CUOI >= @NgayBD THEN DATEADD (DAY,CHU_KY,NGAY_HC_CUOI) 
						ELSE DATEADD (DAY,CASE ISNULL(SO_NGAY_CK,0) WHEN 0 THEN CHU_KY ELSE ISNULL(SO_NGAY_CK,0) END,NGAY_HC_CUOI)	END 
					WHEN 2 THEN CASE WHEN NGAY_HC_CUOI >= @NgayBD THEN DATEADD (WEEK,CHU_KY,NGAY_HC_CUOI)
						ELSE DATEADD (WEEK,CASE ISNULL(SO_NGAY_CK,0) WHEN 0 THEN CHU_KY ELSE ISNULL(SO_NGAY_CK,0) END,NGAY_HC_CUOI) END 							
					WHEN 3 THEN CASE WHEN NGAY_HC_CUOI >= @NgayBD THEN DATEADD (MONTH,CHU_KY,NGAY_HC_CUOI)
							ELSE DATEADD (MONTH,CASE ISNULL(SO_NGAY_CK,0) WHEN 0 THEN CHU_KY ELSE ISNULL(SO_NGAY_CK,0) END,NGAY_HC_CUOI) END 
					WHEN 4 THEN CASE WHEN NGAY_HC_CUOI >= @NgayBD THEN DATEADD (YEAR,CHU_KY,NGAY_HC_CUOI)
							ELSE DATEADD (YEAR,CASE ISNULL(SO_NGAY_CK,0) WHEN 0 THEN CHU_KY ELSE ISNULL(SO_NGAY_CK,0) END,NGAY_HC_CUOI) END END AS NGAY_KE
FROM 
(
	SELECT MS_MAY ,MS_PT,MS_VI_TRI, NGAY_HC_CUOI , CHU_KY, MS_DV_TG, SO_NGAY, 
	CASE MS_DV_TG WHEN 1 THEN CONVERT(int,SO_NGAY / CHU_KY ) * CHU_KY 
					WHEN 2 THEN CONVERT(int,(SO_NGAY / 7 ) / CHU_KY ) * CHU_KY
					WHEN 3 THEN CONVERT(int,dbo.MGetSoThang(NGAY_HC_CUOI,@NgayBD) / CHU_KY ) * CHU_KY 				
					WHEN 4 THEN CONVERT(int,(SO_NGAY / 12 ) / CHU_KY ) * CHU_KY END AS SO_NGAY_CK
	FROM 
		(
			SELECT     T2.MS_MAY,T2.MS_PT, T2.MS_VI_TRI, T1.NGAY_HC_CUOI , 
					CASE @LoaiHC WHEN 1 THEN CHU_KY_HC_NOI 
									WHEN 2 THEN CHU_KY_HC_NGOAI 
									WHEN 3 THEN CHU_KY_KD 
									ELSE CHU_KY_KT END AS CHU_KY, MS_DV_TG , 
					CASE MS_DV_TG WHEN 1 THEN DATEDIFF (DAY, NGAY_HC_CUOI,@NgayBD) 
											WHEN 2 THEN DATEDIFF (DAY,NGAY_HC_CUOI,@NgayBD)
											WHEN 3 THEN dbo.MGetSoThang(NGAY_HC_CUOI,@NgayBD)
											ELSE  dbo.MGetSoThang(NGAY_HC_CUOI,@NgayBD) END 
					AS SO_NGAY 		
				FROM        (SELECT T1.MS_MAY, MS_PT, MS_VI_TRI, MAX(NGAY) AS NGAY_HC_CUOI FROM dbo.HIEU_CHUAN_DHD T1 INNER JOIN 
								@MAY_USER T3 ON T1.MS_MAY = T3.MS_MAY	
								WHERE (MS_LOAI_HIEU_CHUAN = @LoaiHC) 
								GROUP BY T1.MS_MAY, MS_PT, MS_VI_TRI
							) AS T1 INNER JOIN dbo.CHU_KY_HIEU_CHUAN AS T2 ON T1.MS_MAY = T2.MS_MAY 
								AND T1.MS_PT = T2.MS_PT AND T1.MS_VI_TRI = T2.MS_VI_TRI
				WHERE ISNULL(MS_DV_TG, 0 ) <> 0	
		) SO_NGAY WHERE CHU_KY <> 0
) TINH_SO_NGAY ORDER BY MS_MAY,MS_PT,MS_VI_TRI , MS_DV_TG 

IF @MLoai = 1
	BEGIN
		DECLARE @MS_MAY NVARCHAR(30),@MS_PT nvarchar (25),@MS_VI_TRI nvarchar(50) ,
		@NGAY_CUOI DATETIME ,@NGAY_KE DATETIME, @CHU_KY INT, @MS_DV_TG INT
	
		DECLARE BTDK_CURSOR CURSOR FOR
			SELECT DISTINCT MS_MAY,MS_PT,MS_VI_TRI,MS_DV_TG, CHU_KY,NGAY_HC_CUOI AS NGAY_CUOI,NGAY_KE FROM @MAY_NGAY_CUOI 	
			WHERE MS_DV_TG IN (1,2,3,4) AND CHU_KY IS NOT NULL AND CHU_KY > 0


		OPEN BTDK_CURSOR
		FETCH NEXT FROM BTDK_CURSOR 
		INTO @MS_MAY, @MS_PT,@MS_VI_TRI,@MS_DV_TG,@CHU_KY,@NGAY_CUOI,@NGAY_KE
		WHILE @@FETCH_STATUS = 0  
		BEGIN	
			SET @NGAY_KE = (SELECT CASE @MS_DV_TG
						WHEN 1 THEN  DATEADD(DAY,@CHU_KY,@NGAY_KE)
						WHEN 2 THEN DATEADD(DAY,7 * @CHU_KY ,@NGAY_KE)
						WHEN 3 THEN DATEADD(MONTH,@CHU_KY,@NGAY_KE) 
						WHEN 4 THEN DATEADD(YEAR,@CHU_KY,@NGAY_KE)												
						ELSE 
							DATEADD(YEAR,1,@NgayKT)												
						END )
			
			WHILE @NGAY_KE <= @NgayKT	
				BEGIN	
					INSERT INTO @MAY_NGAY_CUOI (MS_MAY,MS_PT,MS_VI_TRI,NGAY_HC_CUOI,CHU_KY,MS_DV_TG,NGAY_KE) 
					VALUES (@MS_MAY,@MS_PT,@MS_VI_TRI,@NGAY_CUOI,@CHU_KY,@MS_DV_TG,@NGAY_KE ) 

					SET @NGAY_KE = (SELECT CASE @MS_DV_TG
						WHEN 1 THEN  DATEADD(DAY,@CHU_KY,@NGAY_KE)
						WHEN 2 THEN DATEADD(DAY,7 * @CHU_KY ,@NGAY_KE)
						WHEN 3 THEN DATEADD(MONTH,@CHU_KY,@NGAY_KE) 
						WHEN 4 THEN DATEADD(YEAR,@CHU_KY,@NGAY_KE)												
						ELSE 
							DATEADD(YEAR,1,@NgayKT)												
						END )
							
				 END	
			FETCH NEXT FROM BTDK_CURSOR 
			INTO @MS_MAY,@MS_PT,@MS_VI_TRI, @MS_DV_TG,@CHU_KY,@NGAY_CUOI,@NGAY_KE
		END	
		CLOSE BTDK_CURSOR 
		DEALLOCATE  BTDK_CURSOR 	
	END
	DELETE FROM @MAY_NGAY_CUOI WHERE NGAY_KE  >@NgayKT
	return 
END 	


