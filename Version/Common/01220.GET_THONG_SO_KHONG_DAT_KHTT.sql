
--exec GET_THONG_SO_KHONG_DAT_KHTT '-1','-1','-1','01/01/2017','01/31/2017',1,'-1', 'Admin',-1

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

SELECT B.STT, B.MS_MAY, B.MS_BO_PHAN, B.MS_TS_GSTT, B.MS_TT, NGAY_GIO AS NGAY_GIO_KT_MAX INTO #GSTT_KKTT FROM (
SELECT B.STT,B.MS_MAY, B.MS_BO_PHAN, B.MS_TS_GSTT, B.MS_TT, 
	CONVERT(DATETIME, CONVERT(NVARCHAR(10), A.NGAY_KT, 101) + ' '+ CONVERT(NVARCHAR(8), A.GIO_KT, 108)) AS NGAY_GIO
	FROM         dbo.GIAM_SAT_TINH_TRANG AS A INNER JOIN
						  dbo.GIAM_SAT_TINH_TRANG_TS_DT AS B ON A.STT = B.STT
) B             
INNER JOIN
(SELECT MS_MAY, MS_BO_PHAN, MS_TS_GSTT, MS_TT, MAX(NGAY_GIO) AS NGAY_MAX FROM
	(SELECT B.MS_MAY, B.MS_BO_PHAN, B.MS_TS_GSTT, B.MS_TT, 
		CONVERT(DATETIME, CONVERT(NVARCHAR(10), A.NGAY_KT, 101) + ' '+ CONVERT(NVARCHAR(8), A.GIO_KT, 108)) AS NGAY_GIO
	FROM         dbo.GIAM_SAT_TINH_TRANG AS A INNER JOIN
						  dbo.GIAM_SAT_TINH_TRANG_TS_DT AS B ON A.STT = B.STT
	) A GROUP BY MS_MAY, MS_BO_PHAN, MS_TS_GSTT, MS_TT
) C ON B.NGAY_GIO = NGAY_MAX AND C.MS_BO_PHAN = B.MS_BO_PHAN AND C.MS_MAY = B.MS_MAY AND C.MS_TS_GSTT = B.MS_TS_GSTT AND C.MS_TT = B.MS_TT


SELECT DISTINCT MS_MAY,TEN_MAY INTO #MAY_USER FROM [dbo].[MGetMayUserNgay](@DENNGAY,@USERNAME,@MS_NHA_XUONG,@MS_HE_THONG,-1,@LOAIMAY,@NHOMMAY,@MAY,0)
 

SELECT        T2.STT, T3.MS_MAY, T3.MS_BO_PHAN, T3.MS_TS_GSTT, T3.MS_TT, CONVERT(DATETIME, T3.NGAY_GIO_KT_MAX) AS NGAY_GIO_KT_MAX, T2.GIA_TRI_DO, T2.MS_CACH_TH, T2.MS_CONG_NHAN, T2.TG_XU_LY, T2.MS_PBT, 
                         T2.HANG_MUC_ID_KE_HOACH, T2.USERNAME, T4.DAT
INTO #GSTT_TS
FROM            (SELECT        dbo.GIAM_SAT_TINH_TRANG_TS.MS_MAY, dbo.GIAM_SAT_TINH_TRANG_TS.MS_BO_PHAN, dbo.GIAM_SAT_TINH_TRANG_TS.MS_TS_GSTT, dbo.GIAM_SAT_TINH_TRANG_TS.MS_TT, CONVERT(CHAR(10), 
                                                    dbo.GIAM_SAT_TINH_TRANG.NGAY_KT, 101) + ' ' + CONVERT(CHAR(5), dbo.GIAM_SAT_TINH_TRANG.GIO_KT, 8) AS NGAY_GIO_KT_MAX
                          FROM            dbo.GIAM_SAT_TINH_TRANG INNER JOIN
                                                    dbo.GIAM_SAT_TINH_TRANG_TS ON dbo.GIAM_SAT_TINH_TRANG.STT = dbo.GIAM_SAT_TINH_TRANG_TS.STT) AS T3 INNER JOIN
                         dbo.GIAM_SAT_TINH_TRANG_TS AS T2 ON T3.MS_MAY = T2.MS_MAY AND T3.MS_TS_GSTT = T2.MS_TS_GSTT AND T3.MS_BO_PHAN = T2.MS_BO_PHAN AND T3.MS_TT = T2.MS_TT INNER JOIN
                         dbo.GIAM_SAT_TINH_TRANG AS T1 ON T2.STT = T1.STT INNER JOIN
                         dbo.CAU_TRUC_THIET_BI_TS_GSTT AS T4 ON T2.MS_MAY = T4.MS_MAY AND T2.MS_BO_PHAN = T4.MS_BO_PHAN AND T2.MS_TS_GSTT = T4.MS_TS_GSTT AND T2.MS_TT = T4.MS_TT
WHERE        (T4.DAT = 0) AND 
(CONVERT(DATETIME, LEFT(T3.NGAY_GIO_KT_MAX, 10), 101) = T1.NGAY_KT AND CONVERT(DATETIME, RIGHT(T3.NGAY_GIO_KT_MAX, 5), 103) = T1.GIO_KT)





SELECT CONVERT(BIT,0) AS CHON, DT.STT, A.MS_TS_GSTT, A.MS_TT,   A.NGAY_GIO_KT_MAX, A.MS_MAY,E.TEN_MAY, (DT.MS_BO_PHAN + ' - ' + H.TEN_BO_PHAN) AS TEN_BO_PHAN, D.TEN_TS_GSTT, CAST(NULL AS NVARCHAR) AS GT_DL, 
C.TEN_GIA_TRI AS GT_DT, F.TEN_TIENG_VIET AS TEN_CACH_TH, DT.MS_CACH_TH, DT.MS_PBT, DT.MS_CONG_NHAN, DT.TG_XU_LY, DT.USERNAME, DT.STT_GT, DT.MS_BO_PHAN
FROM #MAY_USER AS E INNER JOIN
                      dbo.CAU_TRUC_THIET_BI AS H ON E.MS_MAY = H.MS_MAY INNER JOIN
                      #GSTT_KKTT AS A INNER JOIN
                      dbo.GIAM_SAT_TINH_TRANG_TS_DT AS DT ON 
						A.STT = DT.STT AND 
						A.MS_MAY = DT.MS_MAY AND A.MS_TS_GSTT = DT.MS_TS_GSTT 
						AND A.MS_BO_PHAN = DT.MS_BO_PHAN AND A.MS_TT = DT.MS_TT  
                      INNER JOIN                      
                      ( SELECT *, CONVERT(DATETIME, CONVERT(NVARCHAR(10), NGAY_KT, 101) + ' '+ CONVERT(NVARCHAR(8), GIO_KT, 108)) AS NGAY_GIO FROM dbo.GIAM_SAT_TINH_TRANG)
                      AS B ON DT.STT = B.STT AND A.NGAY_GIO_KT_MAX = B.NGAY_GIO 
                      
                      INNER JOIN
                      dbo.GIA_TRI_TS_GSTT AS C ON A.MS_TS_GSTT = C.MS_TS_GSTT AND DT.STT_GT = C.STT INNER JOIN
                      dbo.THONG_SO_GSTT AS D ON D.MS_TS_GSTT = A.MS_TS_GSTT ON H.MS_BO_PHAN = A.MS_BO_PHAN AND H.MS_MAY = A.MS_MAY 
                      LEFT OUTER JOIN dbo.KE_HOACH_TONG_THE AS K ON DT.HANG_MUC_ID_KE_HOACH = K.HANG_MUC_ID 
                      INNER JOIN MAY ON E.MS_MAY = MAY.MS_MAY 
                      INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY 
					  LEFT JOIN CACH_THUC_HIEN F ON DT.MS_CACH_TH = F.MS_CACH_TH
WHERE
CASE
WHEN @DK = 1 AND C.DAT = 0 AND C.DAT=0 AND TG_XU_LY IS NULL AND (DT.MS_CACH_TH<>'03' OR DT.MS_CACH_TH IS NULL) THEN 1
WHEN @DK = 2 AND C.DAT = 0 AND C.DAT=0 AND LOAI_TS=1 AND DT.MS_CACH_TH='03' THEN 1 
WHEN @DK = 3 AND DT.MS_CACH_TH<>'03' AND LOAI_TS=1 AND TG_XU_LY>=CONVERT(DATE,@TUNGAY)  AND TG_XU_LY <=CONVERT(DATE,@DENNGAY)  THEN 1
ELSE 0
END  = 1

UNION

SELECT DISTINCT CONVERT(BIT,0) AS CHON,
                      A.STT, A.MS_TS_GSTT, A.MS_TT, A.NGAY_GIO_KT_MAX AS NGAY_GIO_KT_MAX, A.MS_MAY,MAY.TEN_MAY,  
					  (A.MS_BO_PHAN + ' - ' + dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN) AS TEN_BO_PHAN, D.TEN_TS_GSTT, CAST(A.GIA_TRI_DO AS NVARCHAR)+ ' ' + E.TEN_DV_DO AS GT_DL,  
					  CAST(NULL AS NVARCHAR)  AS GT_DT, F.TEN_TIENG_VIET, A.MS_CACH_TH, A.MS_PBT, A.MS_CONG_NHAN, 
                      A.TG_XU_LY, A.USERNAME, NULL AS STT_GT,A.MS_BO_PHAN
FROM         #GSTT_TS AS A INNER JOIN
                                              
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
					  LEFT JOIN CACH_THUC_HIEN F ON A.MS_CACH_TH = F.MS_CACH_TH
WHERE
CASE
WHEN @DK = 1 AND  -- (GIA_TRI_DO>= GIA_TRI_TREN OR GIA_TRI_DO<GIA_TRI_DUOI) AND
 LOAI_TS=0 AND TG_XU_LY IS NULL AND (A.MS_CACH_TH<>'03' OR A.MS_CACH_TH IS NULL) THEN 1
WHEN @DK = 2 --AND   (GIA_TRI_DO>= GIA_TRI_TREN OR GIA_TRI_DO<=GIA_TRI_DUOI) 
AND LOAI_TS=0 AND A.MS_CACH_TH='03' THEN 1 
WHEN @DK = 3 --AND  (GIA_TRI_DO>= GIA_TRI_TREN OR GIA_TRI_DO<=GIA_TRI_DUOI) 
AND LOAI_TS=0 AND A.MS_CACH_TH<>'03'
					 AND TG_XU_LY>=CONVERT(DATE,@TUNGAY) AND TG_XU_LY <=CONVERT(DATE,@DENNGAY)  THEN 1
ELSE 0
END  = 1

ORDER BY NGAY_GIO_KT_MAX DESC


end
