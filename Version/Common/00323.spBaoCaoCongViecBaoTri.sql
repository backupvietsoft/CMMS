IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spBaoCaoCongViecBaoTri')
   exec('CREATE PROCEDURE spBaoCaoCongViecBaoTri AS BEGIN SET NOCOUNT ON; END')
GO



--SELECT * FROM MAY WHERE MS_NHOM_MAY ='EXT-01'
--SELECT * FROM NHOM_MAY WHERE MS_LOAI_MAY IN(SELECT MS_LOAI_MAY  FROM LOAI_MAY WHERE MS_LOAI_MAY = 'EXT')

-- DROP TABLE MAY_CVBT_TMPADMIN
-- SELECT CONVERT(BIT,1) AS CHON, * INTO MAY_CVBT_TMPIN FROM MAY WHERE MS_NHOM_MAY ='EXT-01' 
-- EXEC spBaoCaoCongViecBaoTri 'MAY_CVBT_TMPIN', -1, N'LBTRI', '01/01/2014', '01/01/2016',0,'-1',-1,0
ALTER PROC [dbo].[spBaoCaoCongViecBaoTri]
	@MayTmp NVARCHAR(50),
	@MsLBTri INT,
	@TenLBTri NVARCHAR(50),
	@TNgay DATETIME,
	@DNgay DATETIME,
	@NNgu INT,
	@MSDV NVARCHAR(50),
	@MSTO INT,
	@iLoaiBC INT
AS


-- @iLoaiBC 0 In ALL
-- @iLoaiBC 1 In KHTT
-- @iLoaiBC 2 In PBT
-- @iLoaiBC 3 In Cong Viec VP

DECLARE @sSql NVARCHAR(4000)


CREATE TABLE #MAY_TMP (MS_MAY NVARCHAR(250) NULL, TEN_MAY NVARCHAR(500) NULL)  

SET @sSql = ' INSERT INTO #MAY_TMP SELECT MS_MAY, TEN_MAY FROM ' + @MayTmp + ' WHERE ISNULL(CHON,0) = 1'
EXEC (@sSql)

SET @sSql = ' DROP TABLE ' + @MayTmp
EXEC (@sSql)


SELECT  ROW_NUMBER() OVER(ORDER BY NGAY_BD_KH, MS_MAY, TEN_MAY, TEN_LOAI_BT,TEN_BO_PHAN,TEN_CV) AS STT ,
* FROM
(
-- Lấy bên KHTT cho các Hang mục chưa chuyển PBT
SELECT A.MS_MAY, B.TEN_MAY, D.TEN_LOAI_BT, X.TEN_BO_PHAN, 
	CASE @NNgu WHEN 0 THEN E.MO_TA_CV WHEN 1 THEN E.MO_TA_CV_ANH ELSE E.MO_TA_CV_HOA END AS TEN_CV, 
CONVERT(FLOAT,CASE ISNULL(A.THOI_GIAN_DU_KIEN,0) WHEN 0 THEN NULL ELSE A.THOI_GIAN_DU_KIEN END ) AS TG_KH, 
C.NGAY AS NGAY_BD_KH, C.NGAY_DK_HT AS NGAY_KT_KH, 
CONVERT(FLOAT, NULL) AS TG_TT_CO_KH, CONVERT(FLOAT, NULL) AS TG_DA_TH_THEO_KH, 
CONVERT(FLOAT, NULL) AS TG_TT_KG_KH, CONVERT(FLOAT, NULL) AS PT_TG_SV_KH, 
CONVERT(DATETIME, NULL) AS NGAY_BD_KH_PBT, CONVERT(DATETIME, NULL) AS NGAY_KT_KH_PBT, 
CONVERT(FLOAT, NULL) AS TG_NM, CONVERT(NVARCHAR(150), NULL) AS MS_PBT, 
CONVERT(NVARCHAR(500), NULL) AS TT_SAU_BT, CONVERT(NVARCHAR(4000), NULL) AS NGUOI_TH_PBT, A.GHI_CHU
FROM            dbo.KE_HOACH_TONG_CONG_VIEC AS A INNER JOIN
                         #MAY_TMP AS B ON A.MS_MAY = B.MS_MAY INNER JOIN
                         dbo.KE_HOACH_TONG_THE AS C ON A.HANG_MUC_ID = C.HANG_MUC_ID INNER JOIN
                         dbo.LOAI_BAO_TRI AS D ON C.MS_LOAI_BT = D.MS_LOAI_BT INNER JOIN
                         dbo.CONG_VIEC AS E ON A.MS_CV = E.MS_CV INNER JOIN
                         dbo.CAU_TRUC_THIET_BI AS X ON A.MS_MAY = X.MS_MAY AND A.MS_BO_PHAN = X.MS_BO_PHAN
WHERE (CONVERT(DATETIME,CONVERT(NVARCHAR(10),C.NGAY,101)) BETWEEN @TNgay AND @DNgay) AND (ISNULL(A.MS_PHIEU_BAO_TRI,'') = '') 
	AND (C.MS_LOAI_BT = @MsLBTri  OR @MsLBTri = -1) AND  (@iLoaiBC = 0 OR @iLoaiBC = 1  ) 

UNION
--Lấy all cac PBT
SELECT  A.MS_MAY, TEN_MAY,D.TEN_LOAI_BT, X.TEN_BO_PHAN,
CASE @NNgu WHEN 0 THEN E.MO_TA_CV WHEN 1 THEN E.MO_TA_CV_ANH ELSE E.MO_TA_CV_HOA END AS TEN_CV,
CONVERT(FLOAT,CASE ISNULL(B.SO_GIO_KH,0) WHEN 0 THEN NULL ELSE B.SO_GIO_KH END) AS SO_GIO_KH, 
A.NGAY_BD_KH , A.NGAY_KT_KH ,

CASE D.HU_HONG WHEN 0 THEN 
	CASE ISNULL(T3.SO_GIO_TT,0) WHEN 0 THEN NULL ELSE T3.SO_GIO_TT END
ELSE NULL END AS TG_TT_CO_KH, 

CASE  WHEN (CASE D.HU_HONG WHEN 0 THEN T3.SO_GIO_TT ELSE 0 END ) > 0 THEN 
	CASE ISNULL(B.SO_GIO_KH,0) WHEN 0 THEN NULL ELSE B.SO_GIO_KH END ELSE NULL END AS TG_DA_TH_THEO_KH,
CASE D.HU_HONG WHEN 1 THEN T3.SO_GIO_TT ELSE NULL END AS TG_TT_KG_KH,
CASE ISNULL(B.SO_GIO_KH,0) WHEN 0 THEN NULL ELSE T3.SO_GIO_TT / B.SO_GIO_KH END AS PT_TG_SV_KH,
A.NGAY_BD_KH AS NGAY_BD_KH_PBT, A.NGAY_KT_KH  AS NGAY_KT_KH_PBT,
CASE ISNULL(T4.TG_NM,0) WHEN 0 THEN NULL ELSE T4.TG_NM END AS TG_NM, 
A.MS_PHIEU_BAO_TRI, A.TT_SAU_BT , dbo.GetNhanSuPBT(A.MS_PHIEU_BAO_TRI,B.MS_BO_PHAN,B.MS_CV,0)  AS NGUOI_TH_PBT ,B.GHI_CHU  
FROM            (SELECT        MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, SUM(SO_GIO) AS SO_GIO_TT
                          FROM            dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET
                          GROUP BY MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN) AS T3 RIGHT OUTER JOIN
                         dbo.PHIEU_BAO_TRI AS A INNER JOIN
                         dbo.PHIEU_BAO_TRI_CONG_VIEC AS B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI INNER JOIN
                         #MAY_TMP AS C ON A.MS_MAY = C.MS_MAY INNER JOIN
                         dbo.LOAI_BAO_TRI AS D ON A.MS_LOAI_BT = D.MS_LOAI_BT INNER JOIN
                         dbo.CONG_VIEC AS E ON B.MS_CV = E.MS_CV INNER JOIN
                         dbo.CAU_TRUC_THIET_BI AS X ON A.MS_MAY = X.MS_MAY AND B.MS_BO_PHAN = X.MS_BO_PHAN ON T3.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI AND T3.MS_CV = B.MS_CV AND 
                         T3.MS_BO_PHAN = B.MS_BO_PHAN LEFT JOIN 
(SELECT        MS_PHIEU_BAO_TRI, SUM(THOI_GIAN_SUA_CHUA) AS TG_NM FROM dbo.THOI_GIAN_NGUNG_MAY WHERE ISNULL(MS_PHIEU_BAO_TRI,'') <> '' 
	GROUP BY THOI_GIAN_SUA, MS_PHIEU_BAO_TRI ) T4 ON A.MS_PHIEU_BAO_TRI = T4.MS_PHIEU_BAO_TRI
WHERE (CONVERT(DATETIME,CONVERT(NVARCHAR(10),A.NGAY_BD_KH,101)) BETWEEN @TNgay AND @DNgay )
	AND (A.MS_LOAI_BT = @MsLBTri  OR @MsLBTri = -1)  AND  (@iLoaiBC = 0 OR @iLoaiBC = 2) 

UNION
--Lấy all kế hoach nhan6n viên
SELECT  NULL AS MS_MAY, NULL AS TEN_MAY,@TenLBTri AS TEN_LOAI_BT,NULL AS TEN_BO_PHAN,A.TEN_CONG_VIEC, 
CASE ISNULL(THOI_GIAN_DK,0) WHEN 0 THEN NULL ELSE THOI_GIAN_DK END AS TG_KH,
A.NGAY AS NGAY_BD_KH,  A.THOI_HAN AS NGAY_KT_KH,
CONVERT(FLOAT, NULL) AS TG_TT_CO_KH, CONVERT(FLOAT, NULL) AS TG_DA_TH_THEO_KH,
CASE ISNULL(THOI_GIAN_DK,0) WHEN 0 THEN NULL ELSE THOI_GIAN_DK END AS TG_TT_KG_KH, 
CONVERT(FLOAT, NULL) AS PT_TG_SV_KH,CONVERT(DATETIME, NULL) AS NGAY_BD_KH_PBT, CONVERT(DATETIME, NULL) AS NGAY_KT_KH_PBT, 
CONVERT(FLOAT, NULL) AS TG_NM, CONVERT(NVARCHAR(150), NULL) AS MS_PBT, 
CONVERT(NVARCHAR(500), NULL) AS TT_SAU_BT, CONVERT(NVARCHAR(4000), NULL) AS NGUOI_TH_PBT,A.GHI_CHU
FROM            dbo.CONG_NHAN AS B INNER JOIN
                         dbo.KE_HOACH_THUC_HIEN AS A ON B.MS_CONG_NHAN = A.MS_CONG_NHAN INNER JOIN
                         dbo.[TO] AS C ON B.MS_TO = C.MS_TO1 INNER JOIN
                         dbo.TO_PHONG_BAN AS D ON C.MS_TO = D.MS_TO
WHERE (CONVERT(DATETIME,CONVERT(NVARCHAR(10),A.NGAY,101))  BETWEEN @TNgay AND @DNgay)
	AND  (@iLoaiBC = 0 OR @iLoaiBC = 3)  AND (D.MS_DON_VI = @MSDV OR @MSDV = '-1') 
	 AND (D.MS_TO = @MSTO OR @MSTO = -1)
)	T1


ORDER BY NGAY_BD_KH, MS_MAY, TEN_MAY, TEN_LOAI_BT,TEN_BO_PHAN,TEN_CV


