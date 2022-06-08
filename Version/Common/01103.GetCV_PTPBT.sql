

ALTER function [dbo].[GetCV_PTPBT]
(
	@MS_PHIEU_BAO_TRI NVARCHAR(20), 
	@MS_CV INT,
	@MS_BO_PHAN NVARCHAR(50),
	@MS_CV_PHU INT,
	@LOAI INT, 
	@NN INT
)
returns nvarchar(4000)
as
begin

--@LOAI = 0: JOIN CONG NHAN
--@LOAI = 1: JOIN PHU TUNG
--@LOAI = 2: TONG THOI GIAN
--@LOAI = 3: TONG NHAN SU 
declare @sName nvarchar(4000)
IF @MS_CV <> 0 
BEGIN
	IF @LOAI = 0 
	BEGIN
		SELECT    @sName = COALESCE(ISNULL(@sName,'') + 
		CASE LEN(ISNULL(@sName,'')) WHEN 0 THEN '' ELSE ', ' END  ,'') + 
		ISNULL(TEN,'')
		FROM 	(
			SELECT DISTINCT MS_CONG_NHAN,MS_PHIEU_BAO_TRI FROM  
				dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI AND MS_CV = @MS_CV AND MS_BO_PHAN = @MS_BO_PHAN
			)AS A 
			INNER JOIN dbo.CONG_NHAN AS B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN
			ORDER BY TEN		
	END
	ELSE IF @LOAI = 1
	BEGIN
		SELECT    @sName = COALESCE(ISNULL(@sName,'') + 
		CASE LEN(ISNULL(@sName,'')) WHEN 0 THEN '' ELSE CHAR(13)+ CHAR(10) END  ,'') + 
		CASE @NN WHEN 0 THEN ISNULL(TEN_PT,'') WHEN  1 THEN ISNULL(TEN_PT_ANH ,'') ELSE ISNULL(TEN_PT_HOA ,'') END + ' - ' + ISNULL(B.MS_PT_NCC, '')
		FROM 	(
			SELECT DISTINCT MS_PT ,MS_PHIEU_BAO_TRI FROM  
				dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI AND MS_CV = @MS_CV AND MS_BO_PHAN = @MS_BO_PHAN
			)AS A 
			INNER JOIN IC_PHU_TUNG AS B ON A.MS_PT  = B.MS_PT
	END
	ELSE IF @LOAI = 2
	BEGIN
		SELECT @sName = ISNULL(SUM(SO_GIO), 0) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET
			WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI AND MS_CV = @MS_CV  AND MS_BO_PHAN = @MS_BO_PHAN
			GROUP BY MS_PHIEU_BAO_TRI
	END
	ELSE IF @LOAI = 3
	BEGIN

			SELECT @sName = COUNT(MS_CONG_NHAN)  FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU 
			WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI AND MS_CV = @MS_CV AND MS_BO_PHAN = @MS_BO_PHAN 
			GROUP BY MS_PHIEU_BAO_TRI 			
	END
END
ELSE
BEGIN
	IF @LOAI = 0
	BEGIN
		SELECT    @sName = COALESCE(ISNULL(@sName,'') + 
		CASE LEN(ISNULL(@sName,'')) WHEN 0 THEN '' ELSE ', ' END  ,'') + 
		ISNULL(TEN,'') 
		FROM 	(
			SELECT DISTINCT MS_CONG_NHAN,MS_PHIEU_BAO_TRI FROM  
				dbo.PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI AND STT = @MS_CV_PHU 
			)AS A 
			INNER JOIN dbo.CONG_NHAN AS B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN
		ORDER BY HO, TEN 
	END
	ELSE IF @LOAI = 1
	BEGIN
		SELECT    @sName = COALESCE(ISNULL(@sName,'') + 
		CASE LEN(ISNULL(@sName,'')) WHEN 0 THEN '' ELSE CHAR(13)+ CHAR(10) END  ,'') + 
		CASE @NN WHEN 0 THEN ISNULL(TEN_PT,'') WHEN  1 THEN ISNULL(TEN_PT_ANH ,'') ELSE ISNULL(TEN_PT_HOA ,'') END + ' - ' + ISNULL(B.MS_PT_NCC, '')
		FROM 	(
			SELECT DISTINCT MS_PT ,MS_PHIEU_BAO_TRI FROM  
				dbo.PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI AND STT = @MS_CV_PHU
			) AS A 
			INNER JOIN IC_PHU_TUNG AS B ON A.MS_PT  = B.MS_PT
	END
	ELSE IF @LOAI = 2
	BEGIN
		SELECT @sName = ISNULL(SUM(SO_GIO), 0) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO 
			WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI AND STT = @MS_CV_PHU 
			GROUP BY MS_PHIEU_BAO_TRI
	END
	ELSE IF @LOAI = 3
	BEGIN

			SELECT @sName = COUNT(MS_CONG_NHAN)  FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO
			WHERE MS_PHIEU_BAO_TRI = @MS_PHIEU_BAO_TRI AND STT = @MS_CV_PHU 
			GROUP BY MS_PHIEU_BAO_TRI 			
	END
END


return @sName
end
