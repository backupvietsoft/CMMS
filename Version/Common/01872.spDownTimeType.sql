IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spDownTimeType')
exec('CREATE PROCEDURE spDownTimeType AS BEGIN SET NOCOUNT ON; END')
GO
ALTER	PROCEDURE [dbo].[spDownTimeType]
	@Loai NVARCHAR(50) = 'grd',
	@ID BIGINT = 3,
	@DownTimeTypeName NVARCHAR(250) = '-1',
	@DownTimeTypeNameA NVARCHAR(250) = '-1',
	@DownTimeTypeNameH NVARCHAR(250) = '-1',
	@Note NVARCHAR(500) = '-1',
	@Planned BIT = 0,
	@Active BIT = 0
AS
BEGIN
--Get luoi 
IF UPPER(@Loai) = UPPER('Grd')
BEGIN
   SELECT ID, DownTimeTypeName, DownTimeTypeNameA, DownTimeTypeNameH, ISNULL(Note,'') AS Note,ISNULL(Planned,0) AS Planned,ISNULL(Active,0) AS Active  FROM dbo.DownTimeType ORDER BY DownTimeTypeName
END

--Save
IF UPPER(@Loai) = UPPER('Save')
BEGIN
--THEM
	IF @ID = -1
	BEGIN
		INSERT INTO	dbo.DownTimeType ( DownTimeTypeName, DownTimeTypeNameA,
		                            DownTimeTypeNameH, Note,Planned,Active)
		VALUES(@DownTimeTypeName,@DownTimeTypeNameA,@DownTimeTypeNameH, @Note,@Planned,@Active)
		SELECT SCOPE_IDENTITY();
	END
--SUA
	ELSE
	BEGIN
		UPDATE dbo.DownTimeType SET DownTimeTypeName = @DownTimeTypeName,DownTimeTypeNameA = @DownTimeTypeNameA,DownTimeTypeNameH = @DownTimeTypeNameH, Note = @Note,
		Active = @Active,Planned = @Planned
		WHERE ID = @ID
		SELECT @ID;
	END
	END

--Delete 
IF UPPER(@Loai) = UPPER('Delete')
BEGIN
	IF EXISTS (SELECT	* FROM dbo.NGUYEN_NHAN_DUNG_MAY WHERE DownTimeTypeID = @ID)
	BEGIN
		SELECT 1 AS TT		
	END
	ELSE
	BEGIN
		DELETE dbo.DownTimeType WHERE ID = @ID
		DBCC CHECKIDENT (DownTimeType,RESEED,0)
		DBCC CHECKIDENT (DownTimeType,RESEED)
		SELECT 0 AS TT		
	END
END	

END


