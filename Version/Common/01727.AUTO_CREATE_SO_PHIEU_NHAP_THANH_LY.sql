IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUTO_CREATE_SO_PHIEU_NHAP_THANH_LY]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN	
	DROP FUNCTION AUTO_CREATE_SO_PHIEU_NHAP_THANH_LY
END	
GO
CREATE FUNCTION [dbo].[AUTO_CREATE_SO_PHIEU_NHAP_THANH_LY] (
	@DATE DATETIME )
	RETURNS NVARCHAR(13)
AS 
BEGIN
DECLARE @STTMAX INT 
SELECT 
@STTMAX = MAX(CONVERT(INT,RIGHT (MS_DH_NHAP_PT,4)))  
FROM dbo.IC_DON_HANG_NHAP_X
WHERE  LEFT(MS_DH_NHAP_PT,3) = 'NTL' AND SUBSTRING(MS_DH_NHAP_PT,5,4) = CONVERT(NVARCHAR(4) , @DATE , 12)
DECLARE @STT_NEXT NVARCHAR(10)
SET @STT_NEXT =  '0000' + CONVERT(NVARCHAR(4),ISNULL(@STTMAX,0) +1)
DECLARE @ID NVARCHAR(13)
SET @ID = 'NTL-' +  CONVERT(NVARCHAR(4) , @DATE , 12)  + '-' +  RIGHT (@STT_NEXT,4)
RETURN @ID
END
