IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spBCGioCongNhanVien')
   exec('CREATE PROCEDURE spBCGioCongNhanVien AS BEGIN SET NOCOUNT ON; END')
GO

alter proc [dbo].[spBCGioCongNhanVien]	
	@MS_DV NVARCHAR(50) = '-1',
	@MS_TO NVARCHAR(50) = '-1',
	@USERNAME NVARCHAR(50),
	@TNgay AS DATETIME,
	@DNgay AS DATETIME
AS

BEGIN
	IF GETDATE() < @DNgay
		SET @DNgay = CONVERT(DATE, GETDATE())
		

	SELECT DISTINCT MS_DON_VI, MS_TO INTO #TO_USER FROM [dbo].[MGetDonViPhongBanUser](@Username) 
	WHERE (MS_TO = @MS_TO OR @MS_TO = '-1') AND (MS_DON_VI = @MS_DV OR	@MS_DV = '-1')

	
	SELECT CN.MS_CONG_NHAN, (HO + ' ' +  TEN)  AS HO_TEN, CN.HO,CN.TEN INTO #CONG_NHAN 
	FROM CONG_NHAN CN
	LEFT JOIN TRINH_DO_VAN_HOA ON CN.MS_TRINH_DO = TRINH_DO_VAN_HOA.MS_TRINH_DO 
	INNER JOIN [TO] T1 ON T1.MS_TO1 = CN.MS_TO
	INNER JOIN #TO_USER T ON T1.MS_TO = T.MS_TO
	WHERE BO_VIEC = 0
	ORDER BY HO  , TEN 
	
	--PBT-------------------------------
	
	SELECT T1.MS_CONG_NHAN, SUM(T1.SO_GIO) SO_GIO INTO #PBTTMP FROM PHIEU_BAO_TRI T 
	INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET T1 ON T1.MS_PHIEU_BAO_TRI = T.MS_PHIEU_BAO_TRI AND CONVERT(DATE, CONVERT(NVARCHAR(10), T1.DEN_NGAY, 101) + ' ' + CONVERT(NVARCHAR(8), T1.DEN_GIO, 108)) <= @DNgay
	WHERE T.NGAY_BD_KH BETWEEN @TNgay AND @DNgay AND T.TINH_TRANG_PBT > 2
	GROUP BY T1.MS_CONG_NHAN 
	INSERT INTO #PBTTMP
	SELECT T1.MS_CONG_NHAN, SUM(T1.SO_GIO) SO_GIO FROM PHIEU_BAO_TRI T 
	INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO T1 ON T1.MS_PHIEU_BAO_TRI = T.MS_PHIEU_BAO_TRI AND CONVERT(DATE, CONVERT(NVARCHAR(10), T1.DEN_NGAY, 101) + ' ' + CONVERT(NVARCHAR(8), T1.DEN_GIO, 108)) <= @DNgay
	WHERE T.NGAY_BD_KH BETWEEN @TNgay AND @DNgay AND T.TINH_TRANG_PBT > 2
	GROUP BY T1.MS_CONG_NHAN 

	SELECT MS_CONG_NHAN, SUM(SO_GIO) SO_GIO INTO #PBT FROM #PBTTMP
	GROUP BY MS_CONG_NHAN 

	--GSTT-------------------------------
	
	SELECT T.MS_CONG_NHAN, SUM(TG_TT) SO_GIO INTO #GSTT FROM GIAM_SAT_TINH_TRANG T
	INNER JOIN GIAM_SAT_TINH_TRANG_TS T1 ON T.STT = T1.STT AND T1.MS_CONG_NHAN IS NOT NULL
	WHERE T.MS_CONG_NHAN IS NOT NULL AND NGAY_KT BETWEEN @TNgay AND @DNgay 
	GROUP BY T.MS_CONG_NHAN

	--KHCV--------------------------------

	SELECT MS_CONG_NHAN, SUM(ISNULL(THOI_GIAN_DK,0)) SO_GIO INTO #KHCV FROM KE_HOACH_THUC_HIEN WHERE THOI_HAN < @DNgay AND DA_XONG = 1 AND THOI_HAN BETWEEN @TNgay AND @DNgay 
	GROUP BY MS_CONG_NHAN

	SELECT T.MS_CONG_NHAN, T.HO_TEN, ISNULL(T1.SO_GIO, 0) PBT, ISNULL(T2.SO_GIO, 0) GSTT, ISNULL(T3.SO_GIO, 0) CVVP 
	,  ISNULL(T1.SO_GIO, 0) + ISNULL(T2.SO_GIO, 0) + ISNULL(T3.SO_GIO, 0) TONG
	FROM #CONG_NHAN T
	LEFT JOIN #PBT T1 ON T1.MS_CONG_NHAN = T.MS_CONG_NHAN
	LEFT JOIN #GSTT T2 ON T2.MS_CONG_NHAN = T.MS_CONG_NHAN
	LEFT JOIN #KHCV T3 ON T3.MS_CONG_NHAN = T.MS_CONG_NHAN
	WHERE ISNULL(T1.SO_GIO, 0) <> 0 OR ISNULL(T2.SO_GIO, 0) <> 0 OR ISNULL(T3.SO_GIO, 0) <> 0

END