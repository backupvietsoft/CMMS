
CREATE PROC [dbo].[INTEGRATION_TO_PHONG_BAN_UPDATE]
	@MS_TO nvarchar(50),
	@TEN_TO nvarchar(50) ,
	@MS_DON_VI nvarchar(6) ,
	@TEN_DON_VI nvarchar(255) 
AS
IF @TEN_TO = '-1'
	SET @TEN_TO = @MS_TO

IF @MS_DON_VI = '-1'
BEGIN
	IF NOT EXISTS (SELECT TOP 1 * FROM DON_VI WHERE MAC_DINH = 1)
		BEGIN
			INSERT INTO [DON_VI]([MS_DON_VI],[TEN_DON_VI],[TEN_NGAN],[MAC_DINH])
			VALUES ('ZZZZ',N'Chưa cập nhật',N'Chưa cập nhật',1)
		END
		
		SELECT TOP 1 @MS_DON_VI = MS_DON_VI  FROM DON_VI WHERE MAC_DINH = 1
END
ELSE
BEGIN
	IF NOT EXISTS (SELECT * FROM DON_VI WHERE MS_DON_VI = @MS_DON_VI)
		BEGIN
			INSERT INTO [DON_VI]([MS_DON_VI],[TEN_DON_VI],[TEN_NGAN],[MAC_DINH])
			VALUES (@MS_DON_VI,@MS_DON_VI,@TEN_DON_VI,0)
			
		END
		
		SELECT @MS_DON_VI = MS_DON_VI FROM DON_VI WHERE MS_DON_VI = @MS_DON_VI
		
		
END 

				
IF EXISTS ( SELECT [MS_TO_INT] FROM TO_PHONG_BAN WHERE [MS_TO_INT] = @MS_TO)
	BEGIN
		UPDATE TO_PHONG_BAN SET [TEN_TO] = @TEN_TO, [MS_DON_VI] = @MS_DON_VI
		WHERE [MS_TO_INT] = @MS_TO
	
	END
	ELSE
	BEGIN
		INSERT INTO [TO_PHONG_BAN]([MS_TO_INT], [TEN_TO],[MS_DON_VI])
		VALUES (@MS_TO,@TEN_TO,@MS_DON_VI)
	END	
	
	
