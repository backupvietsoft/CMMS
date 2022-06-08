

-- EXEC GetBCPhieuCongViec '01/27/2015','01/27/2016','-1',-1,'101039','ADMIN',1,1, N'Làm phần việc liên quan đến QLCL'
ALTER PROC [dbo].[GetBCPhieuCongViec]
	@TNgay datetime,
	@DNgay datetime,
	@MSNX NVARCHAR(150),
	@MSHT INT,
	@MsNV NVARCHAR(50),
	@USERNAME NVARCHAR(50),
	@NNgu int, 
	@NVIEN BIT, --Công việc văn phòng
	@CVHN NVARCHAR(500)
AS


DECLARE @DTNGAY TABLE (NGAY DATETIME)
DECLARE @NgayTam datetime
set @NgayTam = @TNgay
-- Them ngay vao bang tam
WHILE @NgayTam <= @DNgay
BEGIN
	INSERT  @DTNGAY  (NGAY) VALUES (@NgayTam)
    SET @NgayTam = DATEADD (DAY,1,@NgayTam)  
END
Set @TNgay = CONVERT(DATETIME, @TNgay +  ' 00:00:00' )
Set @DNgay = CONVERT(DATETIME, @DNgay + ' 23:59:59')


IF @NVIEN = 1 -- Xoa cac ngay da ton tai trong PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET+KE_HOACH_THUC_HIEN	khi co check Công việc văn phòng
	BEGIN
		DELETE FROM @DTNGAY  WHERE NGAY IN ( 
						SELECT DISTINCT MIN(NGAY) AS NGAY_MIN FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET
						GROUP BY MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_CONG_NHAN
						HAVING      (MIN(NGAY) BETWEEN @TNgay AND @DNgay) AND (MS_CONG_NHAN = @MsNV)
						UNION 
						SELECT DISTINCT NGAY FROM dbo.KE_HOACH_THUC_HIEN WHERE (NGAY BETWEEN @TNgay AND @DNgay) AND   (MS_CONG_NHAN = @MsNV))	
	END
ELSE -- Xoa cac ngay da ton tai PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET
	BEGIN
		DELETE FROM @DTNGAY  WHERE NGAY IN ( 
						SELECT DISTINCT MIN(NGAY) AS NGAY_MIN
						FROM         dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET
						GROUP BY MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_CONG_NHAN
						HAVING      (MIN(NGAY) BETWEEN @TNgay AND @DNgay) AND (MS_CONG_NHAN = @MsNV))	
	
	END 

SELECT * INTO #MAY_TB FROM [dbo].[MGetMayUserNgay]( @DNgay,@USERNAME,@MSNX,@MSHT,-1,'-1','-1','-1',@NNgu)

SELECT MIN(PBTNSCT.NGAY) AS NGAY_WHERE, CONVERT(INT, NULL) AS STT, 
			CASE @NNgu WHEN 0 THEN  CV.MO_TA_CV WHEN 1 THEN CV.MO_TA_CV_ANH ELSE MO_TA_CV_HOA END AS MO_TA_CV, 
			CASE ISNULL(HU_HONG,0) WHEN   0 THEN SUM(PBTNSCT.SO_GIO) ELSE 0 END AS CO_KH,
			CASE ISNULL(HU_HONG,0) WHEN   1 THEN SUM(PBTNSCT.SO_GIO) ELSE 0 END AS KG_KH,
			dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN, PBT.MS_MAY, M.TEN_MAY, PBTCV.DANH_GIA, PBTNSCT.MS_PHIEU_BAO_TRI INTO #PBT_TMP
                       FROM          #MAY_TB AS M INNER JOIN
                                              dbo.PHIEU_BAO_TRI AS PBT ON M.MS_MAY = PBT.MS_MAY INNER JOIN
                                              dbo.PHIEU_BAO_TRI_CONG_VIEC AS PBTCV ON PBT.MS_PHIEU_BAO_TRI = PBTCV.MS_PHIEU_BAO_TRI INNER JOIN
                                              dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET AS PBTNSCT INNER JOIN
                                              dbo.CONG_VIEC AS CV ON PBTNSCT.MS_CV = CV.MS_CV  ON 
                                              PBTCV.MS_PHIEU_BAO_TRI = PBTNSCT.MS_PHIEU_BAO_TRI AND PBTCV.MS_CV = PBTNSCT.MS_CV AND PBTCV.MS_BO_PHAN = PBTNSCT.MS_BO_PHAN INNER JOIN
                                              dbo.CAU_TRUC_THIET_BI ON M.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND PBTCV.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN INNER JOIN 
											  LOAI_BAO_TRI LBT ON PBT.MS_LOAI_BT = LBT.MS_LOAI_BT
                       WHERE      (PBTNSCT.MS_CONG_NHAN = @MsNV)
                       GROUP BY PBTNSCT.MS_PHIEU_BAO_TRI, CASE @NNgu WHEN 0 THEN  CV.MO_TA_CV WHEN 1 THEN CV.MO_TA_CV_ANH ELSE MO_TA_CV_HOA END, 
                       PBT.MS_MAY, M.TEN_MAY, PBTCV.DANH_GIA, dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN,HU_HONG


SELECT     NGAY_WHERE, STT , MO_TA_CV, CO_KH,KG_KH, TEN_BO_PHAN, MS_MAY + ' - ' + TEN_MAY AS MS_TEN_MAY, DANH_GIA, MS_PHIEU_BAO_TRI INTO #DT_DL
FROM         #PBT_TMP AS A
WHERE     (NGAY_WHERE BETWEEN @TNgay AND @DNgay)
ORDER BY NGAY_WHERE , MS_PHIEU_BAO_TRI, MO_TA_CV,TEN_BO_PHAN
	
IF @NVIEN = 0
	BEGIN  
		SELECT NGAY_WHERE, ROW_NUMBER() OVER(PARTITION BY NGAY_WHERE ORDER BY NGAY_WHERE , MS_PHIEU_BAO_TRI, MO_TA_CV,TEN_BO_PHAN) AS STT,
		MO_TA_CV, CO_KH,KG_KH, TEN_BO_PHAN, MS_TEN_MAY, DANH_GIA, MS_PHIEU_BAO_TRI FROM 
		(SELECT  NGAY_WHERE,  MO_TA_CV, CO_KH,KG_KH, TEN_BO_PHAN, MS_TEN_MAY, DANH_GIA, MS_PHIEU_BAO_TRI FROM #DT_DL	
		UNION SELECT NGAY ,  NULL , NULL, NULL , NULL , NULL ,  NULL , NULL  FROM @DTNGAY ) A
		ORDER BY NGAY_WHERE , MS_PHIEU_BAO_TRI, MO_TA_CV,TEN_BO_PHAN
	END
ELSE
	BEGIN
		SELECT NGAY_WHERE, ROW_NUMBER() OVER(PARTITION BY NGAY_WHERE ORDER BY NGAY_WHERE , MS_PHIEU_BAO_TRI, MO_TA_CV,TEN_BO_PHAN) AS STT, 
		MO_TA_CV, CO_KH,KG_KH, TEN_BO_PHAN, MS_TEN_MAY, DANH_GIA, CONVERT(NVARCHAR(1000) ,MS_PHIEU_BAO_TRI) AS MS_PHIEU_BAO_TRI FROM 
		(SELECT  NGAY_WHERE,  MO_TA_CV, CO_KH,KG_KH, TEN_BO_PHAN, MS_TEN_MAY, DANH_GIA, MS_PHIEU_BAO_TRI FROM #DT_DL	
		UNION SELECT NGAY ,  NULL , NULL , NULL ,NULL , NULL ,  NULL , NULL  FROM @DTNGAY 
		UNION SELECT     NGAY, TEN_CONG_VIEC, THOI_GIAN_DK, NULL , NULL, NULL , GHI_CHU, @CVHN AS CV
		FROM         dbo.KE_HOACH_THUC_HIEN WHERE (NGAY BETWEEN @TNgay AND @DNgay) AND   (MS_CONG_NHAN = @MsNV) ) A
		ORDER BY NGAY_WHERE , MS_PHIEU_BAO_TRI, MO_TA_CV,TEN_BO_PHAN

	END
