
IF EXISTS (SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'[dbo].[fnGetNguyenNhanNM]')
                  AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
  DROP FUNCTION [dbo].[fnGetNguyenNhanNM]
GO 

CREATE FUNCTION [dbo].[fnGetNguyenNhanNM]
(
	@IDNM BIGINT
)
returns @TGNM TABLE (MS_NM BIGINT)
as
begin	
	DECLARE @ID_TEMP BIGINT = @IDNM
	WHILE (SELECT COUNT(*) FROM dbo.THOI_GIAN_NGUNG_MAY WHERE ID = @ID_TEMP) > 0
	BEGIN
		INSERT INTO @TGNM( MS_NM)
		SELECT TGDM.ID FROM dbo.THOI_GIAN_NGUNG_MAY TGDM
		WHERE ID = @ID_TEMP
		SET @ID_TEMP = (SELECT TOP 1 ID_CHA FROM dbo.THOI_GIAN_NGUNG_MAY WHERE ID = @ID_TEMP)
	END
	SET @ID_TEMP = @IDNM
	WHILE (SELECT COUNT(*) FROM dbo.THOI_GIAN_NGUNG_MAY WHERE ID_CHA = @ID_TEMP) > 0
	BEGIN
		INSERT INTO @TGNM(MS_NM)
		SELECT TOP 1 TGDM.ID FROM dbo.THOI_GIAN_NGUNG_MAY TGDM
		WHERE ID_CHA = @ID_TEMP
		SET @ID_TEMP = (SELECT TOP 1 ID FROM dbo.THOI_GIAN_NGUNG_MAY WHERE ID_CHA = @ID_TEMP)
	END
return 
end
