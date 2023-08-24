
ALTER PROCEDURE spGetBaoCaoApi
	@UName NVARCHAR(100) ='Admin',  
	@TUNAM INT =2022,
	@DENNAM INT =2025,
	@MSDV NVARCHAR(50) = '-1',
	@NNgu INT =0 
AS	
BEGIN
		DECLARE @TN INT = @TUNAM
		--UPDATE dbo.NHA_XUONG SET MS_DON_VI ='TN'
		--UPDATE dbo.IC_KHO SET MS_DON_VI = 'TN'
		SELECT A.* INTO #MAY FROM  dbo.MGetMayUserNgay(GETDATE(),@UName,-1,-1,-1,'-1','-1','-1',@NNgu) A
		INNER JOIN dbo.NHA_XUONG B ON B.MS_N_XUONG = A.MS_N_XUONG and B.MS_DON_VI = @MSDV OR @MSDV  = '-1'
		
		CREATE TABLE #NAM (NAM INT)
	
	DECLARE @chuoi NVARCHAR(500) =''

	WHILE @TUNAM <= @DENNAM
	BEGIN
		INSERT INTO #NAM(NAM)VALUES(@TUNAM)
		SET @chuoi =@chuoi + '['+ CONVERT(NVARCHAR(4),@TUNAM) +'],'
		SET @TUNAM = @TUNAM + 1
    END

	SET @chuoi = LEFT(@chuoi,LEN(@chuoi) -1)

	--tính thời gian ngừng máy
	SELECT A.NAM,ROUND(SUM(B.THOI_GIAN_SUA_CHUA)/60,0) AS THOI_GIAN_NGUNG INTO #T1 FROM #NAM A
	LEFT JOIN dbo.THOI_GIAN_NGUNG_MAY B ON A.NAM = YEAR(B.NGAY)
	LEFT JOIN #MAY C ON C.MS_MAY = B.MS_MAY
	GROUP BY A.NAM


	--số lần ngừng máy
	SELECT A.NAM,COUNT(B.MS_LAN) AS SO_LAN_NGUNG INTO #T2 FROM #NAM A
	LEFT JOIN dbo.THOI_GIAN_NGUNG_MAY_SO_LAN B ON A.NAM = YEAR(B.NGAY)
	GROUP BY A.NAM
	
	--Số phiếu bảo trì có kế hoạch
	SELECT A.NAM, COUNT(B.MS_PHIEU_BAO_TRI) AS SO_PHIEU_KE_HOACH INTO #T3 FROM #NAM A
	LEFT JOIN dbo.PHIEU_BAO_TRI B ON A.NAM = YEAR(B.NGAY_LAP)
	INNER JOIN dbo.LOAI_BAO_TRI C ON C.MS_LOAI_BT = B.MS_LOAI_BT
	WHERE ISNULL(C.HU_HONG,0) = 0
	GROUP BY A.NAM


	--Số phiếu bảo trì không có kế hoạch
	SELECT A.NAM, COUNT(B.MS_PHIEU_BAO_TRI) AS SO_PHIEU_KHONG_KE_HOACH INTO #T4  FROM #NAM A
	LEFT JOIN dbo.PHIEU_BAO_TRI B ON A.NAM = YEAR(B.NGAY_LAP)
	INNER JOIN dbo.LOAI_BAO_TRI C ON C.MS_LOAI_BT = B.MS_LOAI_BT
	WHERE ISNULL(C.HU_HONG,0) = 1
	GROUP BY A.NAM


	--thời gian bảo trì có kế hoạch
	SELECT A.NAM , ROUND(SUM(ISNULL(C.SO_GIO,0) + ISNULL(D.SO_GIO,0))/60,0) THOI_GIAN_BT_KH INTO #T5 FROM #NAM A
	INNER JOIN dbo.PHIEU_BAO_TRI B ON A.NAM = YEAR(B.NGAY_LAP)
	LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET c ON c.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI
	LEFT JOIN PHIEU_BAO_TRI_NHAN_SU D ON D.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI
	INNER JOIN dbo.LOAI_BAO_TRI E ON E.MS_LOAI_BT = B.MS_LOAI_BT
	WHERE ISNULL(E.HU_HONG,0) = 0
	GROUP BY A.NAM


	--thời gian bảo trì không có kế hoạch
	SELECT A.NAM , ROUND(SUM(ISNULL(C.SO_GIO,0) + ISNULL(D.SO_GIO,0))/60,0) AS THOI_GIAN_BT_KHONG_KH INTO #T6 FROM #NAM A
	INNER JOIN dbo.PHIEU_BAO_TRI B ON A.NAM = YEAR(B.NGAY_LAP)
	LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET c ON c.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI
	LEFT JOIN PHIEU_BAO_TRI_NHAN_SU D ON D.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI
	INNER JOIN dbo.LOAI_BAO_TRI E ON E.MS_LOAI_BT = B.MS_LOAI_BT
	WHERE ISNULL(E.HU_HONG,0) = 1
	GROUP BY A.NAM


	--chi phí bảo trì có kế hoạch
	SELECT A.NAM, ROUND(SUM(CHI_PHI_PHU_TUNG+CHI_PHI_VAT_TU+CHI_PHI_NHAN_CONG+CHI_PHI_DV+CHI_PHI_KHAC),0)  CP_KH 
	INTO #T7
	FROM #NAM A
	LEFT JOIN dbo.PHIEU_BAO_TRI B ON A.NAM =YEAR(B.NGAY_LAP)
	LEFT JOIN dbo.PHIEU_BAO_TRI_CHI_PHI C ON C.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI
	INNER JOIN dbo.LOAI_BAO_TRI D ON D.MS_LOAI_BT = B.MS_LOAI_BT
	WHERE ISNULL(D.HU_HONG,0) = 0
	GROUP BY A.NAM

	--chi phí bảo trì thực tế
	SELECT A.NAM, ROUND(SUM(CHI_PHI_PHU_TUNG+CHI_PHI_VAT_TU+CHI_PHI_NHAN_CONG+CHI_PHI_DV+CHI_PHI_KHAC),0) CP_TT 
	INTO #T8
	FROM #NAM A
	LEFT JOIN dbo.PHIEU_BAO_TRI B ON A.NAM =YEAR(B.NGAY_LAP)
	LEFT JOIN dbo.PHIEU_BAO_TRI_CHI_PHI C ON C.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI
	INNER JOIN dbo.LOAI_BAO_TRI D ON D.MS_LOAI_BT = B.MS_LOAI_BT
	WHERE ISNULL(D.HU_HONG,0) = 1
	GROUP BY A.NAM

	--DECLARE @TonKho AS TypeInventory; 
	--INSERT INTO @TonKho  exec MTinhTonKhoTheoViTri @dCot1, @dCot2,'-1',@sCot1,@icot1,@UserName,0
    --spGetBaoCaoApi


	--giá trị hàng tồn kho
	SELECT A.NAM, CONVERT(FLOAT,0) AS  CP_TON_KHO 
	INTO #T9
	FROM #NAM A

WHILE @TN <= @DENNAM
BEGIN
	DECLARE @TonKho AS TypeInventory; 
	DECLARE @TNgay DATE = ''+CONVERT(NVARCHAR(4),@TN)+'-01-01'
	DECLARE @DNgay DATE = ''+CONVERT(NVARCHAR(4),@TN)+'-12-31'
    INSERT INTO @TonKho 
	EXEC dbo.MTinhTonKhoTheoViTri @TNgay = @TNgay, -- date
	                              @DNgay = @DNgay, -- date
	                              @MsLoaiVTPT = N'-1',     -- nvarchar(50)
	                              @MsPT = N'-1',           -- nvarchar(50)
	                              @MSKho = -1,            -- int
	                              @UserName = @UName,       -- nvarchar(50)
	                              @NNgu = @NNgu              -- int
	
	UPDATE #T9 SET CP_TON_KHO = (SELECT ROUND(SUM(ISNULL(GT_CUOI_KY,0)),0) FROM @TonKho A INNER JOIN dbo.IC_KHO B ON B.MS_KHO = A.MS_KHO AND B.MS_DON_VI =@MSDV OR @MSDV = '-1')
	WHERE NAM = @TN 
		DELETE @TonKho

	SET @TN = @TN + 1; -- Increment the date by 1 day
END




	SELECT #T1.NAM,THOI_GIAN_NGUNG,SO_LAN_NGUNG,SO_PHIEU_KE_HOACH,SO_PHIEU_KHONG_KE_HOACH,CP_KH,CP_TT,CP_TON_KHO
	INTO #TMP_CHUNG
	FROM #T1 
	LEFT JOIN  #T2 ON #T2.NAM = #T1.NAM
	LEFT JOIN #T3 ON #T3.NAM = #T1.NAM
	LEFT JOIN #T4 ON #T4.NAM = #T1.NAM
	--LEFT JOIN #T5 ON #T5.NAM = #T1.NAM
	--LEFT JOIN #T6 ON #T6.NAM = #T1.NAM
	LEFT JOIN #T7 ON #T7.NAM = #T1.NAM
	LEFT JOIN #T8 ON #T8.NAM = #T1.NAM
	LEFT JOIN #T9 ON #T9.NAM = #T1.NAM

	-- Chuyen sang table ngang
	DECLARE @sSql NVARCHAR(MAX)

SET @sSql = N'
SELECT * FROM (
    SELECT NAM,
           1 AS ID_Result,
           N''Thời gian ngừng máy'' AS Name_Result,
		   N''Giờ'' AS DVD,
           ISNULL(THOI_GIAN_NGUNG, 0) AS Result FROM #TMP_CHUNG

    UNION

    SELECT NAM,
           2 AS ID_Result,
           N''Số lần ngừng máy'' AS Name_Result,
		   N''Lần'' AS DVD,
           ISNULL(SO_LAN_NGUNG, 0) AS Result FROM #TMP_CHUNG

    UNION

    SELECT NAM,
           3 AS ID_Result,
           N''Số phiếu bảo trì có kế hoạch'' AS Name_Result,
		   N''Phiếu'' AS DVD,
           ISNULL(SO_PHIEU_KE_HOACH, 0) AS Result FROM #TMP_CHUNG

    UNION

    SELECT NAM,
           4 AS ID_Result,
           N''Số phiếu bảo trì không có kế hoạch'' AS Name_Result,
		   N''Phiếu'' AS DVD,
           ISNULL(SO_PHIEU_KHONG_KE_HOACH, 0) AS Result FROM #TMP_CHUNG

    --UNION

    --SELECT NAM,
    --       5 AS ID_Result,
    --       N''Thời gian bảo trì có kế hoạch'' AS Name_Result,
		  -- N''Giờ'' AS DVD,
    --       ISNULL(THOI_GIAN_BT_KH, 0) AS Result FROM #TMP_CHUNG

	
    --UNION

    --SELECT NAM,
    --       6 AS ID_Result,
    --       N''Thời gian bảo trì không có kế hoạch'' AS Name_Result,
		  -- N''Giờ'' AS DVD,
    --       ISNULL(THOI_GIAN_BT_KHONG_KH, 0) AS Result FROM #TMP_CHUNG

	

    UNION

    SELECT NAM,
           7 AS ID_Result,
           N''Chi phí bảo trì có kế hoạch'' AS Name_Result,
		   N''VNĐ'' AS DVD,
           ISNULL(CP_KH, 0) AS Result FROM #TMP_CHUNG

    UNION

    SELECT NAM,
           8 AS ID_Result,
           N''Chi phí bảo trì không có kế hoạch'' AS Name_Result,
		   N''VNĐ'' AS DVD,
           ISNULL(CP_TT, 0) AS Result FROM #TMP_CHUNG

    UNION

    SELECT NAM,
           9 AS ID_Result,
           N''Giá trị hàng tồn kho vào cuối năm'' AS Name_Result,
		   N''VNĐ'' AS DVD,
           ISNULL(CP_TON_KHO, 0) AS Result FROM #TMP_CHUNG
) src PIVOT
(
    SUM(Result)
    FOR NAM IN ('+@chuoi+')
) piv
ORDER BY piv.ID_Result;
'

EXEC sp_executesql @sSql


END
GO

