
GO
/****** Object:  StoredProcedure [dbo].[GET_DATA_KHTT_BARIA_TO_PRINT]    Script Date: 11/26/2015 09:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- EXEC GET_DATA_KHTT_BARIA_TO_PRINT '-1','-1','-1','admin','-1',-1,'11/01/2015','11/30/2015'

ALTER proc [dbo].[GET_DATA_KHTT_BARIA_TO_PRINT]

    @MS_LOAI_MAY NVARCHAR(50),
 	@MS_NHOM_MAY NVARCHAR(50),
 	@MS_MAY NVARCHAR(50),
 	@USERNAME NVARCHAR(50),
 	@MS_NHA_XUONG NVARCHAR(50),
 	@MS_HE_THONG INT,
 	@TU_NGAY DATETIME,
 	@DEN_NGAY DATETIME
AS

--DECLARE     @MS_LOAI_MAY NVARCHAR(50)
--DECLARE 	@MS_NHOM_MAY NVARCHAR(50)
--DECLARE 	@MS_MAY NVARCHAR(50)
--DECLARE 	@ c NVARCHAR(50)
--DECLARE 	@MS_NHA_XUONG NVARCHAR(50)
--DECLARE 	@MS_HE_THONG INT
--DECLARE 	@TU_NGAY DATETIME
--DECLARE 	@DEN_NGAY DATETIME

--SET @MS_LOAI_MAY = '-1'
--SET @MS_NHOM_MAY = '-1'
--SET @MS_MAY = '-1'
--SET @USERNAME = 'ADMIN'
--SET @MS_NHA_XUONG = '-1'

--SET @MS_HE_THONG = -1
--SET @TU_NGAY = CONVERT(DATETIME,'20150901',112)
--SET @DEN_NGAY = CONVERT(DATETIME,'20151130',112)

DECLARE @TMP2 TABLE (TEN_MAY NVARCHAR(255) , MS_MAY NVARCHAR(255))

INSERT INTO @TMP2 (TEN_MAY,MS_MAY)
SELECT DISTINCT TEN_MAY, MS_MAY FROM dbo.MGetMayUserNgay(@DEN_NGAY, @USERNAME, @MS_NHA_XUONG, @MS_HE_THONG, -1, 
	@MS_LOAI_MAY, @MS_NHOM_MAY,@MS_MAY, 0) A 

DECLARE  @KE_HOACH_TONG_THE_TMP TABLE (
	[MS_MAY] [nvarchar](30) NOT NULL,
	[HANG_MUC_ID] [int] NOT NULL,
	[TEN_HANG_MUC] [nvarchar](250) NULL,
	[NGAY] [datetime] NULL,
	[NGAY_DK_HT] [datetime] NULL,
	[GHI_CHU] [nvarchar](255) NULL,
	[MS_LOAI_BT] [int] NULL,
	[NGAY_BTPN] [datetime] NULL,
	[LY_DO_SC] [int] NULL,
	[MS_CACH_TH] [nvarchar](15) NULL,
	[USERNAME] [nvarchar](50) NULL,
	[CP_VT_NN_NGOAI_DM] [bigint] NULL,
	[CP_VT_NGOAI_DM] [bigint] NULL,
	[CP_THUE_NGOAI] [bigint] NULL,
	[MS_UU_TIEN] [int] NULL,
	[PT_HTHANH] [float] NULL,
	[MS_CN_PT] [nvarchar](9) NULL
)

INSERT INTO @KE_HOACH_TONG_THE_TMP (MS_MAY, HANG_MUC_ID, TEN_HANG_MUC, NGAY, NGAY_DK_HT, GHI_CHU, MS_LOAI_BT, NGAY_BTPN, LY_DO_SC, MS_CACH_TH, USERNAME, CP_VT_NN_NGOAI_DM, 
                      CP_VT_NGOAI_DM, CP_THUE_NGOAI, MS_UU_TIEN, PT_HTHANH, MS_CN_PT)
SELECT dbo.KE_HOACH_TONG_THE.MS_MAY, dbo.KE_HOACH_TONG_THE.HANG_MUC_ID, dbo.KE_HOACH_TONG_THE.TEN_HANG_MUC, dbo.KE_HOACH_TONG_THE.NGAY, dbo.KE_HOACH_TONG_THE.NGAY_DK_HT, dbo.KE_HOACH_TONG_THE.GHI_CHU, dbo.KE_HOACH_TONG_THE.MS_LOAI_BT,
 dbo.KE_HOACH_TONG_THE.NGAY_BTPN, dbo.KE_HOACH_TONG_THE.LY_DO_SC, dbo.KE_HOACH_TONG_THE.MS_CACH_TH, CASE WHEN ISNULL(dbo.KE_HOACH_TONG_THE.MS_CN_PT,'')='' THEN '' ELSE  dbo.CONG_NHAN.TEN END AS USERNAME, dbo.KE_HOACH_TONG_THE.CP_VT_NN_NGOAI_DM, 
                      dbo.KE_HOACH_TONG_THE.CP_VT_NGOAI_DM, dbo.KE_HOACH_TONG_THE.CP_THUE_NGOAI, dbo.KE_HOACH_TONG_THE.MS_UU_TIEN, PT_HTHANH, MS_CN_PT
 FROM KE_HOACH_TONG_THE  LEFT OUTER JOIN
                      dbo.CONG_NHAN ON dbo.KE_HOACH_TONG_THE.MS_CN_PT = dbo.CONG_NHAN.MS_CONG_NHAN
 WHERE (CONVERT(DATETIME, CONVERT(NVARCHAR(10), NGAY, 103), 103) BETWEEN @TU_NGAY AND @DEN_NGAY)

     
DECLARE @MAY_USER_BTDK TABLE (MS_MAY NVARCHAR(255))      
      
INSERT INTO    @MAY_USER_BTDK (MS_MAY)    
SELECT DISTINCT  MS_MAY  FROM dbo.MGetMayUserNgay(@DEN_NGAY, @UserName, @MS_NHA_XUONG, @MS_HE_THONG, -1, @MS_LOAI_MAY, @MS_NHOM_MAY,@MS_MAY, 0) A 

DECLARE @TB_BTDK_TMP TABLE (MS_MAY NVARCHAR(255) , MS_LOAI_BT INT , MS_DV_TG INT ,CHU_KY INT , NGAY_CUOI DATETIME ,NGAY_BTKT DATETIME )

INSERT INTO @TB_BTDK_TMP (MS_MAY,MS_LOAI_BT,MS_DV_TG,CHU_KY,NGAY_CUOI,NGAY_BTKT)
SELECT B.*  FROM @MAY_USER_BTDK AS A
INNER JOIN
(SELECT     dbo.MAY_LOAI_BTPN.MS_MAY, dbo.MAY_LOAI_BTPN.MS_LOAI_BT, T_1.MS_DV_TG, T_1.CHU_KY, 
		MAX(dbo.MAY_LOAI_BTPN.NGAY_CUOI) AS NGAY_CUOI, CONVERT(DATETIME, NULL) AS NGAY_BTKT
FROM         dbo.MAY_LOAI_BTPN INNER JOIN
                          (SELECT     T2.MS_MAY, T2.MS_LOAI_BT, T2.CHU_KY, T2.MS_DV_TG
                            FROM          (SELECT     MS_MAY, MS_LOAI_BT, MAX(NGAY_AD) AS NGAY_AD
                                                    FROM          dbo.MAY_LOAI_BTPN_CHU_KY AS T
                                                    GROUP BY MS_MAY, MS_LOAI_BT) AS T1 INNER JOIN
                                                   dbo.MAY_LOAI_BTPN_CHU_KY AS T2 ON T1.MS_MAY = T2.MS_MAY AND T1.MS_LOAI_BT = T2.MS_LOAI_BT AND 
                                                   T1.NGAY_AD = T2.NGAY_AD) AS T_1 ON dbo.MAY_LOAI_BTPN.MS_MAY = T_1.MS_MAY AND 
                      dbo.MAY_LOAI_BTPN.MS_LOAI_BT = T_1.MS_LOAI_BT
WHERE     (T_1.CHU_KY IS NOT NULL)
GROUP BY dbo.MAY_LOAI_BTPN.MS_MAY, dbo.MAY_LOAI_BTPN.MS_LOAI_BT, T_1.MS_DV_TG, T_1.CHU_KY) AS B  
ON A.MS_MAY = B.MS_MAY   


--Tính thời gian chạy máy 
-- Nếu ngày kế > Now thì tính thời gian chạy máy từ lần bảo trì trước đến ngày kế
-- Nếu ngày kế là Max so với Now thì tính thời gian chạy mấy từ ngày cuối đến Now 
-- Nếu ngày kế nhỏ hơn Max so với Now thì tính thời gian chạy máy từ ngày cuối đến ngày kế

DECLARE   @TB_BTDK_TMP_1 TABLE 
(MS_MAY NVARCHAR (30), MS_LOAI_BT NVARCHAR (30), MS_DV_TG INT , CHU_KY INT ,NGAY_CUOI DATETIME , NGAY_BTKT DATETIME ,THOI_GIAN_CHAY_MAY INT )

DECLARE @MS_MAY_TMP NVARCHAR(30) ,@MS_LOAI_BT_TMP NVARCHAR(30),@NGAY_CUOI_TMP DATETIME ,@NGAY_KE_TMP DATETIME, @CHU_KY_TMP INT, @MS_DV_TG_TMP INT
--SET @NgayBD = CONVERT (NVARCHAR (10),@NgayBD,102) 
--SET @NgayKT = CONVERT (NVARCHAR (10),@NgayKT,102) 

DECLARE BTDK_CURSOR CURSOR FOR
	SELECT * FROM @TB_BTDK_TMP WHERE MS_DV_TG IN (1,2,3,4) AND CHU_KY IS NOT NULL AND CHU_KY > 0

OPEN BTDK_CURSOR
FETCH NEXT FROM BTDK_CURSOR 
INTO @MS_MAY_TMP, @MS_LOAI_BT_TMP ,@MS_DV_TG_TMP,@CHU_KY_TMP,@NGAY_CUOI_TMP,@NGAY_KE_TMP
WHILE @@FETCH_STATUS = 0  
BEGIN	
	DECLARE @NGAY_NEXT DATETIME
	DECLARE @NGAY_NEXT_FIST DATETIME 
	DECLARE @NGAY_NEXT_LAST DATETIME 	
	DECLARE @SNgay INT
	DECLARE @SNgayCK INT
	SET @NGAY_NEXT =  @NGAY_CUOI_TMP		
	SET @NGAY_NEXT_FIST =  @NGAY_CUOI_TMP
	SET @NGAY_NEXT_LAST =  @NGAY_CUOI_TMP
	
	SET @NGAY_NEXT =  @NGAY_CUOI_TMP		
	SET @NGAY_NEXT_FIST =  @NGAY_CUOI_TMP
	SET @NGAY_NEXT_LAST =  @NGAY_CUOI_TMP
	
	
	WHILE @NGAY_NEXT <= @DEN_NGAY	
		BEGIN	
			INSERT INTO @TB_BTDK_TMP_1 (MS_MAY,MS_LOAI_BT,MS_DV_TG,CHU_KY,NGAY_CUOI,NGAY_BTKT) 
			VALUES (@MS_MAY_TMP,@MS_LOAI_BT_TMP,@MS_DV_TG_TMP,@CHU_KY_TMP,@NGAY_CUOI_TMP,@NGAY_NEXT ) 

			SET @NGAY_NEXT = (SELECT CASE @MS_DV_TG_TMP
				WHEN 1 THEN  DATEADD(DAY,@CHU_KY_TMP,@NGAY_NEXT)
				WHEN 2 THEN DATEADD(DAY,7 * @CHU_KY_TMP ,@NGAY_NEXT)
				WHEN 3 THEN DATEADD(MONTH,@CHU_KY_TMP,@NGAY_NEXT) 
				WHEN 4 THEN DATEADD(YEAR,@CHU_KY_TMP,@NGAY_NEXT)												
				ELSE 
					DATEADD(YEAR,1,@DEN_NGAY)												
				END )
					
		 END	
	FETCH NEXT FROM BTDK_CURSOR 
	INTO @MS_MAY_TMP, @MS_LOAI_BT_TMP ,@MS_DV_TG_TMP,@CHU_KY_TMP,@NGAY_CUOI_TMP,@NGAY_KE_TMP
END	
CLOSE BTDK_CURSOR 
DEALLOCATE  BTDK_CURSOR 

--Xoa du lieu ngoai giai doan xem
DELETE FROM @TB_BTDK_TMP_1 WHERE NGAY_BTKT NOT IN (SELECT NGAY_BTKT FROM @TB_BTDK_TMP_1 WHERE NGAY_BTKT  BETWEEN @TU_NGAY AND @DEN_NGAY)

--Xoa du lieu ton tai trong may loai BTPN
DELETE A FROM @TB_BTDK_TMP_1 A INNER JOIN MAY_LOAI_BTPN B ON A.MS_MAY=B.MS_MAY AND A.MS_LOAI_BT =B.MS_LOAI_BT 
	WHERE A.NGAY_BTKT <= B.NGAY_CUOI OR ( A.NGAY_BTKT<@TU_NGAY AND A.NGAY_BTKT>@DEN_NGAY)

--SELECT * INTO TEST01 FROM #TB_BTDK_TMP_1
--Xóa dữ liệu quan hệ trong khoảng 1/4 chu kỳ của bảo trì con
DELETE TB_BTDK_TMP_1_1
FROM         dbo.LOAI_BAO_TRI_QH INNER JOIN
                      @TB_BTDK_TMP_1 AS TB_BTDK_TMP_1_1 ON dbo.LOAI_BAO_TRI_QH.MS_LOAI_BT_CD = TB_BTDK_TMP_1_1.MS_LOAI_BT INNER JOIN
                      @TB_BTDK_TMP_1 AS TB_BTDK_TMP_1 ON TB_BTDK_TMP_1_1.MS_MAY = TB_BTDK_TMP_1.MS_MAY AND 
                      dbo.LOAI_BAO_TRI_QH.MS_LOAI_BT_CT = TB_BTDK_TMP_1.MS_LOAI_BT AND DATEADD(DAY, 
                      CASE TB_BTDK_TMP_1_1.MS_DV_TG WHEN 2 THEN TB_BTDK_TMP_1_1.CHU_KY * 7 WHEN 3 THEN TB_BTDK_TMP_1_1.CHU_KY * 30 WHEN 4 THEN
                       TB_BTDK_TMP_1_1.CHU_KY * 365 ELSE TB_BTDK_TMP_1_1.CHU_KY END / 4, TB_BTDK_TMP_1_1.NGAY_BTKT) 
                      >= TB_BTDK_TMP_1.NGAY_BTKT AND DATEADD(DAY, 
                      - (CASE TB_BTDK_TMP_1_1.MS_DV_TG WHEN 2 THEN TB_BTDK_TMP_1_1.CHU_KY * 7 WHEN 3 THEN TB_BTDK_TMP_1_1.CHU_KY * 30 WHEN 4 THEN
                       TB_BTDK_TMP_1_1.CHU_KY * 365 ELSE TB_BTDK_TMP_1_1.CHU_KY END / 4), TB_BTDK_TMP_1_1.NGAY_BTKT) <= TB_BTDK_TMP_1.NGAY_BTKT 
--Xóa bảo trì định kỳ đã lập bên kế hoạch tổng thể và phiếu bảo trì

DELETE T
FROM @TB_BTDK_TMP_1 T INNER JOIN
dbo.KE_HOACH_TONG_THE T1 ON T.MS_MAY = T1.MS_MAY AND 
T.MS_LOAI_BT = T1.MS_LOAI_BT AND DATEADD(DAY,  CASE T.MS_DV_TG WHEN 2 THEN T.CHU_KY * 7 WHEN 3 THEN T.CHU_KY * 30 WHEN 4 THEN 
T.CHU_KY * 365 ELSE T.CHU_KY END / 4, T.NGAY_BTKT) >= T1.NGAY AND DATEADD(DAY, - (CASE T.MS_DV_TG WHEN 2 THEN T.CHU_KY * 7 WHEN 3 THEN T.CHU_KY * 30 WHEN 4 THEN 
T.CHU_KY * 365 ELSE T.CHU_KY END / 4), T.NGAY_BTKT) <= T1.NGAY 


DELETE T
FROM @TB_BTDK_TMP_1 T INNER JOIN
dbo.PHIEU_BAO_TRI T1 ON T.MS_MAY = T1.MS_MAY AND 
T.MS_LOAI_BT = T1.MS_LOAI_BT AND DATEADD(DAY,  CASE T.MS_DV_TG WHEN 2 THEN T.CHU_KY * 7 WHEN 3 THEN T.CHU_KY * 30 WHEN 4 THEN 
T.CHU_KY * 365 ELSE T.CHU_KY END / 4, T.NGAY_BTKT) >= T1.NGAY_BD_KH AND DATEADD(DAY, - (CASE T.MS_DV_TG WHEN 2 THEN T.CHU_KY * 7 WHEN 3 THEN T.CHU_KY * 30 WHEN 4 THEN 
T.CHU_KY * 365 ELSE T.CHU_KY END / 4), T.NGAY_BTKT) <= T1.NGAY_BD_KH 

DECLARE @TABLE_RESULTS TABLE (MS_MAY NVARCHAR(100),
							 TEN_MAY NVARCHAR(255),
							 TEN_HANG_MUC NVARCHAR(255),
							 TEN_MUC_UT NVARCHAR(255),
							 TEN_NGUOI_LKH NVARCHAR(255),
							 TEN_BO_PHAN NVARCHAR(255),
							 TEN_CONG_VIEC NVARCHAR(255),
							 THOI_GIAN_DU_KIEN INT ,
							 SO_NS INT ,
							 SO_NS_YC NVARCHAR(255),
							 VT_PT NVARCHAR(255),
							 CC_DC NVARCHAR(255),
							 NGAY_KH DATETIME,
							 MS_HANG_MUC NVARCHAR(100),
							 MS_BO_PHAN NVARCHAR(100),
							 MS_CONG_VIEC NVARCHAR(100),
							 KH_TYPE INT 
							 )
-- LAY DU LIEU TU KHTT 
INSERT INTO @TABLE_RESULTS (MS_MAY,TEN_MAY,TEN_HANG_MUC,TEN_MUC_UT,TEN_NGUOI_LKH,TEN_BO_PHAN,TEN_CONG_VIEC,THOI_GIAN_DU_KIEN,SO_NS,SO_NS_YC,VT_PT,CC_DC,NGAY_KH,MS_HANG_MUC,MS_BO_PHAN,MS_CONG_VIEC,KH_TYPE)
SELECT DISTINCT 
                       TEMP.MS_MAY, T1.TEN_MAY, TEMP.TEN_HANG_MUC, dbo.MUC_UU_TIEN.TEN_UU_TIEN, TEMP.USERNAME, CTTB.TEN_BO_PHAN, CV.MO_TA_CV, 0 AS THOI_GIAN_DU_KIEN,
                       KHTTCV.SNGUOI, KHTTCV.YCAU_NS, dbo.GetPhuTungbtpn_baria(TEMP.MS_MAY, TEMP.MS_LOAI_BT, KHTTCV.MS_CV, KHTTCV.MS_BO_PHAN) AS VT_PT, KHTTCV.YCAU_DC, TEMP.NGAY, 
                      TEMP.HANG_MUC_ID, KHTTCV.MS_BO_PHAN, KHTTCV.MS_CV, 1 AS KH_TYPE
FROM         dbo.CAU_TRUC_THIET_BI AS CTTB INNER JOIN
                      dbo.KE_HOACH_TONG_CONG_VIEC AS KHTTCV ON CTTB.MS_MAY = KHTTCV.MS_MAY AND CTTB.MS_BO_PHAN = KHTTCV.MS_BO_PHAN RIGHT OUTER JOIN
                          (SELECT     A.MS_MAY, A.HANG_MUC_ID, A.TEN_HANG_MUC, A.NGAY, A.NGAY_DK_HT, A.GHI_CHU, A.MS_LOAI_BT, A.NGAY_BTPN, A.LY_DO_SC, A.MS_CACH_TH, A.USERNAME, A.MS_UU_TIEN, 
                                                   A.MS_CN_PT
                            FROM          @KE_HOACH_TONG_THE_TMP AS A INNER JOIN
                                                       (SELECT DISTINCT MS_MAY, HANG_MUC_ID
                                                         FROM          dbo.KE_HOACH_TONG_CONG_VIEC AS KHTCV
                                                         WHERE      (MS_PHIEU_BAO_TRI IS NULL) AND (EOR_ID IS NULL) AND (KHONG_GQ = 0 OR
                                                                                KHONG_GQ IS NULL) AND (THUE_NGOAI = 0 OR
                                                                                THUE_NGOAI IS NULL)) AS TEMP_1 ON A.MS_MAY = TEMP_1.MS_MAY AND A.HANG_MUC_ID = TEMP_1.HANG_MUC_ID
                            UNION
                            SELECT     MS_MAY, HANG_MUC_ID, TEN_HANG_MUC, NGAY, NGAY_DK_HT, GHI_CHU, MS_LOAI_BT, NGAY_BTPN, LY_DO_SC, MS_CACH_TH, USERNAME, MS_UU_TIEN, MS_CN_PT
                            FROM         @KE_HOACH_TONG_THE_TMP AS A
                            WHERE     (HANG_MUC_ID NOT IN
                                                      (SELECT     HANG_MUC_ID
                                                        FROM          dbo.KE_HOACH_TONG_CONG_VIEC))) AS TEMP INNER JOIN
                      @TMP2 AS T1 ON TEMP.MS_MAY = T1.MS_MAY LEFT OUTER JOIN
                      dbo.MUC_UU_TIEN ON TEMP.MS_UU_TIEN = dbo.MUC_UU_TIEN.MS_UU_TIEN ON KHTTCV.HANG_MUC_ID = TEMP.HANG_MUC_ID LEFT OUTER JOIN
                      dbo.CONG_VIEC AS CV ON KHTTCV.MS_CV = CV.MS_CV
ORDER BY TEMP.MS_MAY
      
		 
							 
INSERT INTO @TABLE_RESULTS (MS_MAY,TEN_MAY,TEN_HANG_MUC,TEN_MUC_UT,TEN_NGUOI_LKH,TEN_BO_PHAN,TEN_CONG_VIEC,THOI_GIAN_DU_KIEN,SO_NS,SO_NS_YC,VT_PT,CC_DC,NGAY_KH,MS_HANG_MUC,MS_BO_PHAN,MS_CONG_VIEC,KH_TYPE)
SELECT A.MS_MAY, E.TEN_MAY, TEN_LOAI_BT , '' AS TEN_MUC_UT ,'' AS TEN_NGUOI_LKH ,CTTB.TEN_BO_PHAN , CV.MO_TA_CV ,
CV.THOI_GIAN_DU_KIEN , CV.SO_NGUOI , CV.YEU_CAU_NS , dbo.[GetPhuTungbtpn_baria](A.MS_MAY,A.MS_LOAI_BT,M_BTPN_CV.MS_CV,M_BTPN_CV.MS_BO_PHAN) AS VT_PT , CV.YEU_CAU_DUNG_CU , NGAY_BTKT ,A.MS_LOAI_BT , M_BTPN_CV.MS_BO_PHAN , M_BTPN_CV.MS_CV , 2 AS KH_TYPE 
FROM @TB_BTDK_TMP_1  A INNER JOIN LOAI_BAO_TRI B ON B.MS_LOAI_BT = A.MS_LOAI_BT INNER JOIN
V_MAY_LOAI_BTPN_CHU_KY_MAX C ON A.MS_MAY = C.MS_MAY AND C.MS_LOAI_BT = A.MS_LOAI_BT INNER JOIN  
dbo.DON_VI_TINH_RUN_TIME AS D ON C.MS_DVT_RT = D.MS_DVT_RT INNER JOIN 
MAY E ON A.MS_MAY = E.MS_MAY INNER JOIN NHOM_MAY F ON
E.MS_NHOM_MAY = F.MS_NHOM_MAY
INNER JOIN MAY_LOAI_BTPN_CONG_VIEC AS M_BTPN_CV ON A.MS_MAY = M_BTPN_CV.MS_MAY AND A.MS_LOAI_BT = M_BTPN_CV.MS_LOAI_BT
INNER JOIN CAU_TRUC_THIET_BI AS CTTB ON M_BTPN_CV.MS_MAY = CTTB.MS_MAY AND M_BTPN_CV.MS_BO_PHAN = CTTB.MS_BO_PHAN
INNER JOIN CONG_VIEC AS CV ON  M_BTPN_CV.MS_CV = CV.MS_CV 
WHERE NGAY_BTKT BETWEEN @TU_NGAY AND @DEN_NGAY
ORDER BY A.MS_MAY ,A.MS_LOAI_BT, NGAY_CUOI, NGAY_BTKT 
							 
SELECT * FROM @TABLE_RESULTS ORDER BY MS_MAY,TEN_HANG_MUC,TEN_BO_PHAN,TEN_CONG_VIEC