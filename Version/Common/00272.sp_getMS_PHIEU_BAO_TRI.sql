


ALTER PROC [dbo].[sp_getMS_PHIEU_BAO_TRI]
	@STT INT,
	@MS_MAY NVARCHAR(50),
	@STT_VAN_DE INT
AS
BEGIN
	declare @NGAY_DSX datetime
	set @NGAY_DSX =(SELECT CONVERT(DATETIME,CONVERT(NVARCHAR(10),YEU_CAU_NSD_CHI_TIET.THOI_GIAN_DSX,101)) 
			FROM YEU_CAU_NSD_CHI_TIET where STT=@STT AND MS_MAY=@MS_MAY AND STT_VAN_DE =@STT_VAN_DE )

IF EXISTS (SELECT * FROM THONG_TIN_CHUNG WHERE UPPER(PRIVATE) = 'BARIA')
BEGIN
	SELECT PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE PHIEU_BAO_TRI.MS_MAY=@MS_MAY 
		AND TINH_TRANG_PBT < 4
	union select '...New' 
	union select '' ORDER BY MS_PHIEU_BAO_TRI ASC   
END	
ELSE
BEGIN
	SELECT PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE PHIEU_BAO_TRI.MS_MAY=@MS_MAY 
		AND PHIEU_BAO_TRI.NGAY_KT_KH >= @NGAY_DSX 
	union select '...New' 
	union select '' ORDER BY MS_PHIEU_BAO_TRI ASC   
END	

END	
	
	
