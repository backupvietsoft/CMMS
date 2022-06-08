

-- EXEC SP_NHU_Y_GET_DE_XUAT_MUA_HANG -1,'05/01/2010','05/21/2015',-1,'ADMINISTRATOR'
ALTER procedure [dbo].[SP_NHU_Y_GET_DE_XUAT_MUA_HANG]
	@PhongBan INT,
	@TuNgay datetime,
	@DenNgay datetime,
	@IsLock INT,
	@UserName nvarchar(50)
AS
BEGIN
declare @GroupID INT
SELECT @GroupID = GROUP_ID FROM USERS WHERE USERNAME = @UserName

CREATE TABLE #TMP(
	MS_DE_XUAT [nvarchar](250) NULL,	
	SL_DX FLOAT NOT NULL,
	SL_NH FLOAT NOT NULL
 ) 

DECLARE @DDH_XMH BIT
SELECT TOP 1 @DDH_XMH = DDH_DXMH FROM THONG_TIN_CHUNG

IF @DDH_XMH = 0 
BEGIN
	INSERT INTO #TMP (MS_DE_XUAT,SL_DX, SL_NH )
	SELECT MS_DE_XUAT,  ROUND(T1.SL_DX,2) AS SL_DX, ROUND(T2.SL_NH,2) AS SL_NH 
	FROM
	(
			SELECT MS_DE_XUAT, SUM(SL_DA_DUYET) AS SL_DX FROM DE_XUAT_MUA_HANG_CHI_TIET 
			GROUP BY MS_DE_XUAT
	) T1 INNER JOIN 
	(
	SELECT   MS_DDH AS MSDX,SUM(B.SL_THUC_NHAP) AS SL_NH
	FROM         dbo.IC_DON_HANG_NHAP AS A INNER JOIN
						  dbo.IC_DON_HANG_NHAP_VAT_TU AS B ON A.MS_DH_NHAP_PT = B.MS_DH_NHAP_PT
	WHERE     (A.MS_DANG_NHAP = 3) 
	GROUP BY MS_DDH
	) T2 ON T1.MS_DE_XUAT = T2.MSDX 
END
ELSE
BEGIN
	INSERT INTO #TMP (MS_DE_XUAT,  SL_DX, SL_NH )
	SELECT  MS_DE_XUAT,  T1.SL_DX, T2.SL_NH 
	FROM
	(
			SELECT MS_DE_XUAT,  SUM(SL_DA_DUYET) AS SL_DX FROM DE_XUAT_MUA_HANG_CHI_TIET 
			GROUP BY MS_DE_XUAT
	) T1 INNER JOIN 
	(
		SELECT   MS_DE_XUAT AS MSDX,  SUM(SL_DAT_HANG) AS SL_NH FROM  dbo.DON_DAT_HANG_CHI_TIET 
		GROUP BY MS_DE_XUAT
	) T2 ON T1.MS_DE_XUAT = T2.MSDX 
END


IF @IsLock = -1
	BEGIN
		SELECT A.MS_DE_XUAT, A.SO_DE_XUAT,  PHONG_BAN, A.NGUOI_LAP, A.NGAY_LAP, A.NGUOI_SUA, A.NGAY_SUA, 
					A.NGUOI_DE_XUAT, A.NGAY_DE_XUAT, A.NGUOI_NHAN, A.NGAY_NHAN, A.NGUOI_DUYET, A.NGAY_DUYET, A.NGUOI_GIAO, 
					A.NGAY_GIAO, A.THEO_YEU_CAU, A.THEO_KE_HOACH, A.TRANG_THAI, A.TEN_TRANG_THAI, A.GHI_CHU, A.MS_KHO, A.MS_LOAI_VT, A.MS_TO, TEN_TT  AS TEN_TTHAI, MS_TT
		FROM									
			(SELECT  CASE ISNULL(SL_DX,0) WHEN 0 THEN 0 
				ELSE
					CASE ISNULL(SL_DX,0) - ISNULL(SL_NH,0) WHEN 0 THEN 2 
					ELSE 1 END 
				END AS TTHAI,   A.MS_DE_XUAT, A.SO_DE_XUAT, C.TEN_TO AS PHONG_BAN, A.NGUOI_LAP, A.NGAY_LAP, A.NGUOI_SUA, A.NGAY_SUA, 
						A.NGUOI_DE_XUAT, A.NGAY_DE_XUAT, A.NGUOI_NHAN, A.NGAY_NHAN, A.NGUOI_DUYET, A.NGAY_DUYET, A.NGUOI_GIAO, 
						A.NGAY_GIAO, A.THEO_YEU_CAU, A.THEO_KE_HOACH, A.TRANG_THAI, A.TEN_TRANG_THAI, A.GHI_CHU, A.MS_KHO, A.MS_LOAI_VT, A.MS_TO
			FROM         dbo.DE_XUAT_MUA_HANG AS A INNER JOIN
								  dbo.NHOM_TO_PHONG_BAN AS B ON A.MS_TO = B.MS_TO INNER JOIN
								  dbo.TO_PHONG_BAN AS C ON B.MS_TO = C.MS_TO LEFT JOIN 
								  #TMP D ON A.MS_DE_XUAT = D.MS_DE_XUAT
			WHERE (A.NGAY_LAP BETWEEN @TuNgay AND @DenNgay)
			AND (A.MS_TO = @PhongBan OR  @PhongBan = -1 )
			AND (TRANG_THAI <=3) AND (GROUP_ID = @GroupID)) A INNER JOIN TRANG_THAI_DX B ON A.TTHAI = B.MS_TT
			ORDER BY A.MS_DE_XUAT
	END
ELSE 
	BEGIN
		SELECT A.MS_DE_XUAT, A.SO_DE_XUAT, PHONG_BAN, A.NGUOI_LAP, A.NGAY_LAP, A.NGUOI_SUA, A.NGAY_SUA, 
					A.NGUOI_DE_XUAT, A.NGAY_DE_XUAT, A.NGUOI_NHAN, A.NGAY_NHAN, A.NGUOI_DUYET, A.NGAY_DUYET, A.NGUOI_GIAO, 
					A.NGAY_GIAO, A.THEO_YEU_CAU, A.THEO_KE_HOACH, A.TRANG_THAI, A.TEN_TRANG_THAI, A.GHI_CHU, A.MS_KHO, A.MS_LOAI_VT, A.MS_TO, TEN_TT  AS TEN_TTHAI , MS_TT
		FROM						
			(SELECT  CASE ISNULL(SL_DX,0) WHEN 0 THEN 0 
					ELSE
						CASE ISNULL(SL_DX,0) - ISNULL(SL_NH,0) WHEN 0 THEN 2 
						ELSE 1 END 
					END AS TTHAI,A.MS_DE_XUAT, A.SO_DE_XUAT, C.TEN_TO AS PHONG_BAN, A.NGUOI_LAP, A.NGAY_LAP, A.NGUOI_SUA, A.NGAY_SUA, 
						A.NGUOI_DE_XUAT, A.NGAY_DE_XUAT, A.NGUOI_NHAN, A.NGAY_NHAN, A.NGUOI_DUYET, A.NGAY_DUYET, A.NGUOI_GIAO, 
						A.NGAY_GIAO, A.THEO_YEU_CAU, A.THEO_KE_HOACH, A.TRANG_THAI, A.TEN_TRANG_THAI, A.GHI_CHU, A.MS_KHO, A.MS_LOAI_VT, A.MS_TO
			FROM         dbo.DE_XUAT_MUA_HANG AS A INNER JOIN
								  dbo.NHOM_TO_PHONG_BAN AS B ON A.MS_TO = B.MS_TO INNER JOIN
								  dbo.TO_PHONG_BAN AS C ON B.MS_TO = C.MS_TO LEFT JOIN 
								  #TMP D ON A.MS_DE_XUAT = D.MS_DE_XUAT
			WHERE (A.NGAY_LAP BETWEEN @TuNgay AND @DenNgay)
			AND (A.MS_TO = @PhongBan OR  @PhongBan = -1 )
			AND (TRANG_THAI = @IsLock) AND (GROUP_ID = @GroupID)) A INNER JOIN TRANG_THAI_DX B ON A.TTHAI = B.MS_TT
			ORDER BY A.MS_DE_XUAT
	END
END
