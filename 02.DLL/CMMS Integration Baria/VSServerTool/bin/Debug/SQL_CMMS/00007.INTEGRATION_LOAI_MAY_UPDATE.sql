IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'INTEGRATION_LOAI_MAY_UPDATE')
   exec('CREATE PROCEDURE [dbo].[INTEGRATION_LOAI_MAY_UPDATE] AS BEGIN SET NOCOUNT ON; END')
GO

ALTER PROC [dbo].[INTEGRATION_LOAI_MAY_UPDATE]	
	@MS_LOAI_MAY nvarchar(10),
	@MS_LOAI_MAY_CU nvarchar(10),
	@TEN_LOAI_MAY nvarchar(50),
	@STATUS nvarchar(1)
AS

IF @STATUS = 'N'
BEGIN
	IF NOT EXISTS (SELECT MS_LOAI_MAY FROM LOAI_MAY WHERE MS_LOAI_MAY = @MS_LOAI_MAY)
	BEGIN
		INSERT INTO LOAI_MAY (MS_LOAI_MAY,TEN_LOAI_MAY,STT_MAY)
		VALUES( @MS_LOAI_MAY, @TEN_LOAI_MAY,(SELECT ISNULL(MAX(STT_MAY),0) + 1 FROM LOAI_MAY) )
		-- Insert vao nhom loai may
		IF NOT EXISTS (SELECT MS_LOAI_MAY FROM NHOM_LOAI_MAY WHERE MS_LOAI_MAY = @MS_LOAI_MAY AND GROUP_ID = 1)
		BEGIN
			INSERT INTO NHOM_LOAI_MAY (MS_LOAI_MAY,GROUP_ID)
			VALUES (@MS_LOAI_MAY,1)
		END
	END	
END

IF @STATUS = 'E'
BEGIN
	IF @MS_LOAI_MAY <> @MS_LOAI_MAY_CU
	BEGIN
		EXEC spCapNhapMaLoaiMay @MS_LOAI_MAY_CU,@MS_LOAI_MAY	
	END
	
	UPDATE LOAI_MAY SET TEN_LOAI_MAY = @TEN_LOAI_MAY
	WHERE MS_LOAI_MAY = @MS_LOAI_MAY 
END	

IF @STATUS = 'D'
BEGIN
	IF NOT EXISTS (SELECT MS_LOAI_MAY FROM NHOM_MAY WHERE MS_LOAI_MAY = @MS_LOAI_MAY)
	BEGIN
		DELETE NHOM_LOAI_MAY WHERE MS_LOAI_MAY = @MS_LOAI_MAY
	
		DELETE LOAI_MAY WHERE MS_LOAI_MAY = @MS_LOAI_MAY
	END
END